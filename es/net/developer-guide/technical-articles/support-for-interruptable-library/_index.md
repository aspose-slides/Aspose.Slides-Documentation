---
title: Interrumpir operaciones de presentación de larga duración en .NET
linktitle: Interrumpir operaciones de presentación
type: docs
weight: 150
url: /es/net/support-for-interruptable-library/
keywords:
- operaciones interrumpibles
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
description: "Aprenda cómo cancelar operaciones de presentación de larga duración en Aspose.Slides para .NET y devolver un resultado parcial al exportar diapositivas en un bucle."
---
## **Descripción general**

Aspose.Slides para .NET puede interrumpir operaciones de larga duración, como la carga, el guardado y la renderización de presentaciones. Su aplicación puede usar el mismo token de interrupción para detener un bucle antes de que comience a procesar la diapositiva siguiente.

## **Interrumpir una operación de presentación**

Cree un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), asigne su [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) a [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/), y pase las opciones de carga al [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Para solicitar la cancelación, llame a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) en la fuente. Una operación interrumpible se detiene cuando observa la solicitud.

El ejemplo comienza a convertir `sample.pptx` a `sample.ppt` en una tarea en segundo plano y solicita la cancelación después de 10 segundos. Si la conversión termina antes, la salida ya está completa.

```c#
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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
## **Conectar la cancelación de .NET a Aspose.Slides**

Si su aplicación utiliza un .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), reenvíe su solicitud de cancelación a Aspose.Slides. El ejemplo comienza a exportar `sample.pptx` a `sample.pdf` y establece un tiempo de espera de 20 segundos. Mientras la exportación se está ejecutando, verifica [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) cada 500 milisegundos. Cuando la propiedad pasa a `true`, llama a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

```cs
using System.Threading;
using Aspose.Slides;
using Aspose.Slides.Export;

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

    while (!task.Wait(500)) // esperar y monitorizar si se ha establecido cancellationToken.IsCancellationRequested
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
## **Detenerse antes de procesar la diapositiva siguiente**

Utilice el mismo [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) tanto para la presentación como para el bucle que exporta sus diapositivas. Compruebe [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) antes de iniciar cada exportación. Si el llamador puede usar un resultado parcial, devuelva los números de diapositiva de las exportaciones que se completaron correctamente.

Utilice una presentación llamada `sample.pptx` con al menos dos diapositivas. El ejemplo solicita la cancelación inmediatamente después de registrar la primera exportación exitosa.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;

var source = new InterruptionTokenSource();
var completed = ExportSlides("sample.pptx", source);
Console.WriteLine($"Completed: [{string.Join(", ", completed)}]");

static List<int> ExportSlides(string path, IInterruptionTokenSource source)
{
    var completed = new List<int>();
    IInterruptionToken token = source.Token;
    var options = new LoadOptions { InterruptionToken = token };
    using var presentation = new Presentation(path, options);

    for (var number = 1; number <= presentation.Slides.Count; number++)
    {
        if (token.IsInterruptionRequested)
            break;

        Console.WriteLine($"Starting slide {number}");
        try
        {
            presentation.Save($"slide-{number}.pdf", new[] { number }, SaveFormat.Pdf);
        }
        catch (OperationCanceledException) when (token.IsInterruptionRequested)
        {
            break;
        }

        completed.Add(number);
        if (number == 1)
            source.Interrupt();
    }

    return completed;
}
```
El ejemplo escribe `slide-1.pdf` y muestra `Starting slide 1` seguido de `Completed: [1]`. El bucle detecta la solicitud antes de iniciar la diapositiva 2. Si la cancelación interrumpe en su lugar a [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) durante una exportación, el bloque `catch` sale del bucle antes de que el código registre la diapositiva actual como completada.

Si el llamador necesita gestionar la cancelación, reemplace la comprobación `if` y su `break` al inicio del bucle por una llamada a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) en el token. Elimine el bloque `try`/`catch` alrededor de la exportación para que la cancelación durante un guardado también llegue al llamador. Con la misma entrada, el ejemplo solo muestra `Starting slide 1` y escribe `slide-1.pdf`. Al iniciar la segunda iteración, el llamador recibe una [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) antes de que comience la exportación. El método no devuelve ninguna lista.

## **Preguntas frecuentes**

**¿Cuándo debo solicitar la cancelación?**

Solicite la cancelación cuando una operación supere su límite de tiempo o cuando su aplicación ya no necesite el resultado.

**¿Cuál es la diferencia entre [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) y [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

La fuente permite que su aplicación solicite la cancelación. El token permite que Aspose.Slides y su aplicación comprueben esa solicitud.

**¿Puedo usar un .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) con Aspose.Slides?**

Sí. Cuando su token .NET indica cancelación, llame a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) en la fuente asociada a la presentación.

**¿Qué operaciones puedo interrumpir?**

Puede interrumpir la carga, el guardado y la renderización. Pase el token al [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) mediante [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). La presentación entonces podrá observar la cancelación durante operaciones posteriores como [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**¿Se detiene una operación inmediatamente?**

La cancelación es cooperativa. Una operación comprueba el token periódicamente y se detiene cuando observa la solicitud.

**¿Qué ocurre si llamo a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) después de que una operación finaliza?**

La operación completada conserva su resultado.

**¿Pueden varias operaciones compartir un [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**

Sí. Llamar a [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) solicita la cancelación para cada operación que utilice un token de esa fuente. Use una fuente separada para cada operación que desee cancelar de forma independiente.