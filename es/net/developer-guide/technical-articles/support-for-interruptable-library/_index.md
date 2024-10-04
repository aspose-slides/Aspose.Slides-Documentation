---
title: Soporte para Biblioteca Interrumpible
type: docs
weight: 150
url: /net/support-for-interruptable-library/

---

## **Biblioteca Interrumpible**

En [Aspose.Slides 18.4](https://docs.aspose.com/slides/net/aspose-slides-for-net-18-4-release-notes/), añadimos la clase [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) y la clase [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource). Proporcionan soporte para la interrupción de tareas de larga duración, como deserialización, serialización o representación.

- InterruptionTokenSource representa la fuente del token o múltiples tokens pasados a **ILoadOptions.InterruptionToken**. 
- Cuando se establece ILoadOptions.InterruptionToken y la instancia de LoadOptions se pasa al constructor de Presentation, invocar el método InterruptionTokenSource.Interrupt provoca la interrupción de cualquier tarea de larga duración relacionada con la Presentación.

Este fragmento de código a continuación demuestra la interrupción de una tarea en ejecución:

```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("pres.pptx", options))
        {
            presentation.Save("pres.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // ejecutar acción en un hilo separado
    Thread.Sleep(10000);            // tiempo de espera
    tokenSource.Interrupt();        // detener conversión


}
private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}

```

## **.NET CancellationToken y Biblioteca Interrumpible**

Cuando necesite usar el [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) junto con la Biblioteca Interrumpible de Slides, puede envolver el procesamiento de la Presentación e interrumpir [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken) si [cancellationToken.IsCancellationRequested](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) está establecido en verdadero.

Este código C# demuestra la operación descrita:

``` csharp
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("pres.pptx", "pres.pdf", tokenSource.Token);
}

static void ProcessPresentation(string path, string outPath, CancellationToken cancellationToken)
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions {InterruptionToken = token};
        using (Presentation presentation = new Presentation(path, options))
        {
            presentation.Save(outPath, SaveFormat.Pdf);
        }
    };
    
    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Task task = Run(action, tokenSource.Token); // ejecutar acción en un hilo separado

    while (!task.Wait(500)) // esperar para monitorear si cancellationToken.IsCancellationRequested está establecido. 
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("El procesamiento de la presentación fue cancelado");
            tokenSource.Interrupt(); // interrumpir el procesamiento de la Presentación
        }
    }
}

private static Task Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    return Task.Run(() =>
    {
        action(token);
    });
}
```