// See https://aka.ms/new-console-template for more information
using ConsoleGame;
using Microsoft.Extensions.DependencyInjection;

var serviceProider = new ServiceCollection()
    .AddSingleton<IPrinter, Printer>()
    .BuildServiceProvider();

Processor processors = new Processor(serviceProider.GetService<IPrinter>());
processors.Start();