---
title: Soporte para la biblioteca Interrumpible
type: docs
weight: 150
url: /es/net/support-for-interruptable-library/
keywords:
- biblioteca interrumpible
- token de interrupción
- token de cancelación
- tarea de larga duración
- interrumpir tarea
- PowerPoint
- OpenDocument
- presentación
- .NET
- C#
- Aspose.Slides
description: "Haga que las tareas de larga duración sean cancelables con Aspose.Slides para .NET. Interrumpa de forma segura la renderización y las conversiones de PowerPoint y OpenDocument, con ejemplos."
---

## **Biblioteca Interrumpible**

En [Aspose.Slides 18.4](https://releases.aspose.com/slides/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), introdujimos las clases [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/). Permiten interrumpir tareas de larga duración como deserialización, serialización y renderizado.

- [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/) es la fuente del(los) token(s) que se pasan a [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/).
- Cuando se establece [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iloadoptions/interruptiontoken/) y la instancia de [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/) se pasa al constructor de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/), invocar [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) interrumpe cualquier tarea de larga duración asociada a esa [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).

El siguiente fragmento de código muestra cómo interrumpir una tarea en ejecución:
```c#
public static void Run()
{
    Action<IInterruptionToken> action = (IInterruptionToken token) =>
    {
        LoadOptions options = new LoadOptions { InterruptionToken = token };
        using (Presentation presentation = new Presentation("sample.pptx", options))
        {
            presentation.Save("sample.ppt", SaveFormat.Ppt);
        }
    };

    InterruptionTokenSource tokenSource = new InterruptionTokenSource();
    Run(action, tokenSource.Token); // ejecutar la acción en un hilo separado
    Thread.Sleep(10000);            // tiempo de espera
    tokenSource.Interrupt();        // detener la conversión
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```


## **.NET CancellationToken y Biblioteca Interrumpible**

Cuando necesite usar un [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) junto con la biblioteca Interrumpible de Aspose.Slides, envuelva el procesamiento de [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) e interrumpa el [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) cuando [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) sea `true`.

Este código C# demuestra la operación:
```cs
public static void Main()
{
    CancellationTokenSource tokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(20));
    ProcessPresentation("sample.pptx", "sample.pdf", tokenSource.Token);
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
    Task task = Run(action, tokenSource.Token); // ejecutar la acción en un hilo separado

    while (!task.Wait(500)) // esperar y vigilar si cancellationToken.IsCancellationRequested está activado
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrumpir el procesamiento de la presentación
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


## **FAQ**

**¿Cuál es el propósito de la biblioteca interrumpible de Aspose.Slides?**

Proporciona un mecanismo para interrumpir operaciones de larga duración —como cargar, guardar o renderizar presentaciones— antes de que se completen. Esto es útil cuando el tiempo de procesamiento debe limitarse o la tarea ya no es necesaria.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` se pasa a la API de Aspose.Slides y se verifica durante las operaciones de larga duración.
- `InterruptionTokenSource` se utiliza en su código para crear tokens y desencadenar interrupciones llamando a `Interrupt()`.

**¿Puedo usar .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) con la biblioteca interrumpible?**

Sí. Puede supervisar el [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) en la lógica de su aplicación y llamar a [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) cuando se solicite la cancelación. Esto permite que Aspose.Slides se integre con los flujos de cancelación estándar de .NET.

**¿Qué tareas pueden interrumpirse?**

Cualquier tarea de Aspose.Slides que acepte un [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) —como cargar una presentación con `Presentation(path, loadOptions)` o guardar con `Presentation.Save(...)`— puede interrumpirse.

**¿La interrupción ocurre de inmediato?**

No. La interrupción es cooperativa: la operación verifica periódicamente el token y se detiene tan pronto como detecta que se ha llamado a [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/).

**¿Qué ocurre si llamo a [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) después de que una tarea ya haya finalizado?**

Nada: la llamada no tiene efecto si la tarea correspondiente ya se ha completado.

**¿Puedo reutilizar el mismo [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/) para varias tareas?**

Sí, pero después de llamar a [Interrupt()](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontokensource/interrupt/) en esa fuente, todas las tareas que usan sus tokens serán interrumpidas. Use fuentes de tokens separadas para gestionar las tareas de forma independiente.