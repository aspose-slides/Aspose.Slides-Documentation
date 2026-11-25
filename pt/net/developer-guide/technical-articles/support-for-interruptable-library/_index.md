---
title: Interromper Operações de Apresentação de Longa Duração em .NET
linktitle: Interromper Operações de Apresentação
type: docs
weight: 150
url: /pt/net/support-for-interruptable-library/
keywords:
- operações interrompíveis
- token de interrupção
- token de cancelamento
- tarefa de longa duração
- interromper tarefa
- PowerPoint
- OpenDocument
- apresentação
- .NET
- C#
- Aspose.Slides
description: "Aprenda como cancelar operações de apresentação de longa duração no Aspose.Slides for .NET e retornar um resultado parcial ao exportar slides em um loop."
---
## **Visão geral**

Aspose.Slides for .NET pode interromper operações de longa duração, como carregamento, gravação e renderização de apresentações. Seu aplicativo pode usar o mesmo token de interrupção para parar um loop antes que ele comece a processar o próximo slide.

## **Interromper uma Operação de Apresentação**

Crie um [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/), atribua seu [Token](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/token/) a [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/) e passe as opções de carregamento para o [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Para solicitar cancelamento, chame [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na origem. Uma operação interrompível para quando observa a solicitação.

O exemplo inicia a conversão de `sample.pptx` para `sample.ppt` em uma tarefa em segundo plano e solicita cancelamento após 10 segundos. Se a conversão terminar antes, a saída já está completa.

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
    Run(action, tokenSource.Token); // executar a ação em uma thread separada
    Thread.Sleep(10000);            // tempo limite
    tokenSource.Interrupt();        // parar a conversão
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **Conectar Cancelamento .NET ao Aspose.Slides**

Se seu aplicativo usa um .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken), encaminhe sua solicitação de cancelamento para o Aspose.Slides. O exemplo inicia a exportação de `sample.pptx` para `sample.pdf` e define um tempo limite de 20 segundos. Enquanto a exportação está em execução, ele verifica [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) a cada 500 milissegundos. Quando a propriedade passa a `true`, ele chama [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/).

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
    Task task = Run(action, tokenSource.Token); // executar a ação em uma thread separada

    while (!task.Wait(500)) // esperar e monitorar se cancellationToken.IsCancellationRequested está definido
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interromper o processamento da apresentação
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

## **Parar Antes de Processar o Próximo Slide**

Use o mesmo [IInterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/) tanto para a apresentação quanto para o loop que exporta seus slides. Verifique [IsInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/isinterruptionrequested/) antes de iniciar cada exportação. Se o chamador puder usar um resultado parcial, retorne os números dos slides cujas exportações foram concluídas com sucesso.

Use uma apresentação chamada `sample.pptx` com pelo menos dois slides. O exemplo solicita cancelamento imediatamente após registrar a primeira exportação bem-sucedida.

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

O exemplo grava `slide-1.pdf` e imprime `Starting slide 1` seguido de `Completed: [1]`. O loop vê a solicitação antes de iniciar o slide 2. Se o cancelamento interromper [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) durante uma exportação, o bloco `catch` sai do loop antes que o código registre o slide atual como concluído.

Se o chamador precisar lidar com o cancelamento, substitua a verificação `if` e seu `break` no início do loop por uma chamada a [ThrowIfInterruptionRequested](https://reference.aspose.com/slides/net/aspose.slides/iinterruptiontoken/throwifinterruptionrequested/) no token. Remova o `try`/`catch` ao redor da exportação para que o cancelamento durante uma gravação também chegue ao chamador. Com a mesma entrada, o exemplo imprime apenas `Starting slide 1` e grava `slide-1.pdf`. No início da segunda iteração, o chamador recebe uma [OperationCanceledException](https://learn.microsoft.com/en-us/dotnet/api/system.operationcanceledexception) antes que a exportação inicie. O método não retorna lista.

## **Perguntas Frequentes**

**When should I request cancellation?**  
Solicite o cancelamento quando uma operação exceder seu limite de tempo ou quando seu aplicativo não precisar mais do resultado.

**What is the difference between [InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/interruptiontoken/) and [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**  
A origem permite que seu aplicativo solicite o cancelamento. O token permite que o Aspose.Slides e seu aplicativo verifiquem essa solicitação.

**Can I use a .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) with Aspose.Slides?**  
Sim. Quando seu token .NET sinaliza cancelamento, chame [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) na origem associada à apresentação.

**Which operations can I interrupt?**  
Você pode interromper o carregamento, a gravação e a renderização. Passe o token para o [Presentation constructor](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/) através de [LoadOptions.InterruptionToken](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/interruptiontoken/). A apresentação então pode observar o cancelamento durante operações subsequentes, como [Presentation.Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/).

**Does an operation stop immediately?**  
O cancelamento é cooperativo. Uma operação verifica o token periodicamente e para quando observa a solicitação.

**What happens if I call [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) after an operation finishes?**  
A operação concluída mantém seu resultado.

**Can multiple operations share an [InterruptionTokenSource](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/)?**  
Sim. Chamar [InterruptionTokenSource.Interrupt](https://reference.aspose.com/slides/net/aspose.slides/interruptiontokensource/interrupt/) solicita cancelamento para todas as operações que usam um token daquela origem. Use uma origem separada para cada operação que você deseja cancelar de forma independente.