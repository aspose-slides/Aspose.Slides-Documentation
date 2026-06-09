---
title: Suporte para Biblioteca Interruptável
type: docs
weight: 150
url: /pt/net/support-for-interruptable-library/
keywords:
- biblioteca interruptável
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
description: "Torne tarefas de longa duração canceláveis com Aspose.Slides para .NET. Interrompa a renderização e as conversões de PowerPoint e OpenDocument com segurança, com exemplos."
---
## **Visão geral**

Aspose.Slides for .NET fornece um mecanismo de processamento interrompível para tarefas de apresentação de longa duração, como desserialização, serialização e renderização. Esse mecanismo baseia‑se nas classes `InterruptionToken` e `InterruptionTokenSource`.

`InterruptionToken` pode ser atribuído a `LoadOptions` e passado ao construtor `Presentation`. Quando `InterruptionTokenSource.Interrupt()` é chamado, a tarefa de longa duração associada é interrompida. O artigo também mostra como usar esse mecanismo juntamente com o `CancellationToken` padrão do .NET, monitorando solicitações de cancelamento e chamando `Interrupt()` quando o cancelamento é solicitado.

## **Biblioteca Interrompível**

Em [Aspose.Slides 18.4](https://releases.aspose.com/slides/pt/net/release-notes/2018/aspose-slides-for-net-18-4-release-notes/), introduzimos as classes [InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontokensource/). Elas permitem interromper tarefas de longa duração, como desserialização, serialização e renderização.

- [InterruptionTokenSource](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontokensource/) é a fonte do(s) token(s) passado(s) para [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/iloadoptions/interruptiontoken/).
- Quando [ILoadOptions.InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/iloadoptions/interruptiontoken/) está definido e a instância [LoadOptions](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/) é passada ao construtor [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/), invocar [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontokensource/interrupt/) interrompe qualquer tarefa de longa duração associada a esse [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/).

O trecho de código a seguir demonstra a interrupção de uma tarefa em execução:

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
    Run(action, tokenSource.Token); // executa a ação em uma thread separada
    Thread.Sleep(10000);            // tempo limite
    tokenSource.Interrupt();        // interrompe a conversão
}

private static void Run(Action<IInterruptionToken> action, IInterruptionToken token)
{
    Task.Run(() => { action(token); });
}
```

## **CancellationToken .NET e Biblioteca Interrompível**

Quando for necessário usar um [CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) juntamente com a biblioteca Interruptible do Aspose.Slides, envolva o processamento do [Presentation](https://reference.aspose.com/slides/pt/net/aspose.slides/presentation/) e interrompa o [InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontoken/) quando [CancellationToken.IsCancellationRequested](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken.iscancellationrequested) for `true`.

Este código C# demonstra a operação:

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
    Task task = Run(action, tokenSource.Token); // execute a ação em uma thread separada

    while (!task.Wait(500)) // espera e monitora se cancellationToken.IsCancellationRequested está definido
    {
        if (cancellationToken.IsCancellationRequested)
        {
            Console.WriteLine("Presentation processing was canceled");
            tokenSource.Interrupt(); // interrompe o processamento de Presentation
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

**Qual é o objetivo da biblioteca de interrupção do Aspose.Slides?**

Ela fornece um mecanismo para interromper operações de longa duração — como carregar, salvar ou renderizar apresentações — antes que sejam concluídas. Isso é útil quando o tempo de processamento deve ser limitado ou a tarefa não é mais necessária.

**Qual é a diferença entre [InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontoken/) e [InterruptionTokenSource](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/)?**

- `InterruptionToken` é passado para a API Aspose.Slides e verificado durante operações de longa duração.
- `InterruptionTokenSource` é usado no seu código para criar tokens e disparar interrupções chamando `Interrupt()`.

**Posso usar o .NET [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) com a biblioteca de interrupção?**

Sim. Você pode monitorar o [CancellationToken](https://learn.microsoft.com/en-us/dotnet/api/system.threading.cancellationtoken) na lógica da sua aplicação e chamar [InterruptionTokenSource.Interrupt()](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/interrupt/) quando o cancelamento for solicitado. Isso permite que o Aspose.Slides se integre aos fluxos de cancelamento padrão do .NET.

**Quais tarefas podem ser interrompidas?**

Qualquer tarefa do Aspose.Slides que aceite um [InterruptionToken](https://reference.aspose.com/slides/pt/net/aspose.slides/interruptiontoken/) — como carregar uma apresentação com `Presentation(path, loadOptions)` ou salvar com `Presentation.Save(...)` — pode ser interrompida.

**A interrupção ocorre imediatamente?**

Não. A interrupção é cooperativa: a operação verifica periodicamente o token e para assim que detecta que [Interrupt()](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/interrupt/) foi chamado.

**O que acontece se eu chamar [Interrupt()](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/interrupt/) após uma tarefa já ter sido concluída?**

Nada — a chamada não tem efeito se a tarefa correspondente já foi concluída.

**Posso reutilizar o mesmo [InterruptionTokenSource](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/) para várias tarefas?**

Sim — mas depois de chamar [Interrupt()](https://reference.aspose.com/slides/pt/net/aspose.slides/iinterruptiontokensource/interrupt/) nesse source, todas as tarefas que utilizam seus tokens serão interrompidas. Use fontes de token separadas para gerenciar tarefas de forma independente.