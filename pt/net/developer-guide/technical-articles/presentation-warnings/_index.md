---
title: Manipular avisos de apresentação no .NET
type: docs
weight: 120
url: /pt/net/presentation-warnings/
aliases:
- /net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- política de aviso
- perda de dados
- corrupção da origem
- problema de compatibilidade
- substituição de fontes
- assinatura digital
- carregamento de apresentação
- renderização de apresentação
- conversão de apresentação
- salvamento de apresentação
- PowerPoint
- OpenDocument
- .NET
- C#
- Aspose.Slides
description: "Aprenda como coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para .NET."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que uma aplicação registre essas condições e decida se a operação atual pode continuar.

Implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iwarningcallback/) e examine as propriedades [WarningType](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iwarninginfo/warningtype/) e [Description](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iwarninginfo/description/) fornecidas através de [IWarningInfo](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iwarninginfo/). Retorne [ReturnAction.Continue](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/returnaction/) para aceitar o aviso ou `ReturnAction.Abort` para interromper a operação.

Use [LoadOptions.WarningCallback](https://reference.aspose.com/slides/pt/net/aspose.slides/loadoptions/warningcallback/) para avisos gerados ao abrir uma apresentação. As classes de opções de renderização e exportação herdam [SaveOptions.WarningCallback](https://reference.aspose.com/slides/pt/net/aspose.slides.export/saveoptions/warningcallback/), que recebe avisos da renderização de slides, conversão e salvamento. Como o aviso em si não identifica a operação da aplicação, associe cada instância de callback a uma etapa da operação ao construir um relatório combinado.

## **Avisos e Exceções**

Um aviso descreve uma condição da qual o Aspose.Slides pode se recuperar se o callback retornar `ReturnAction.Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de avisos.

Retornar `ReturnAction.Abort` solicita ao despachante de avisos que encerre a operação atual levantando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, o carregamento pode gerar uma [PptxReadException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptreadexception/), enquanto salvar ou exportar pode gerar uma [PptxException](https://reference.aspose.com/slides/pt/net/aspose.slides/pptxexception/). Trate a exceção na fronteira da operação e use o relatório de avisos para determinar se a política da aplicação causou a interrupção, em vez de depender de um subtipo de exceção ou mensagem. O callback registra o aviso antes de retornar `ReturnAction.Abort`, garantindo que o motivo permaneça disponível para a aplicação.

## **Categorias de Avisos**

A enumeração [WarningType](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/warningtype/) fornece as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| `SourceFileCorruption` | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | Abort. |
| `DataLoss` | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou salvamento. | Abort. |
| `MajorFormattingLoss` | A apresentação pode perder formatação importante. | Abort em modo de validação estrita; caso contrário, registrar e continuar. |
| `MinorFormattingLoss` | Pode ocorrer uma diferença de formatação limitada. | Registrar para diagnóstico e continuar. |
| `CompatibilityIssue` | O resultado pode não abrir ou comportar‑se corretamente em alguns aplicativos ou versões mais antigas. | Registrar e continuar a menos que a compatibilidade seja obrigatória. |
| `UnexpectedContent` | A origem contém conteúdo não suportado ou não reconhecido cujo efeito ainda pode ser desconhecido. | Registrar e continuar, ou tratar como erro em política estrita. |

A categoria deve orientar a decisão de política. Armazene `Description` para diagnóstico, mas não dependa de sua redação para a lógica da aplicação, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e Classificar Avisos**

O exemplo a seguir usa um relatório de nível de aplicação para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e salvamento em PPTX. A política aborta em caso de corrupção da origem ou perda de dados, opcionalmente aborta em perda de formatação maior e continua para outros avisos.

```csharp
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

internal static class PresentationWarningExample
{
    public static void Main()
    {
        var report = new WarningReport();
        var policy = new WarningPolicy(abortOnMajorFormattingLoss: true);
        var completed = ProcessPresentation("input.pptx", report, policy);

        Console.WriteLine(completed ? "Processing completed." : "Processing stopped.");

        foreach (var entry in report.Entries)
        {
            Console.WriteLine($"[{entry.Stage}] {entry.Type}: {entry.Description}");
        }
    }

    private static bool ProcessPresentation(string inputPath, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var loadOptions = new LoadOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Loading, report, policy)
            };

            using var presentation = new Presentation(inputPath, loadOptions);

            if (!RenderFirstSlide(presentation, report, policy))
            {
                return false;
            }

            if (!ConvertToPdf(presentation, report, policy))
            {
                return false;
            }

            return SaveValidatedCopy(presentation, report, policy);
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Loading stopped: {exception.Message}");
            return false;
        }
    }

    private static bool RenderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new RenderingOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Rendering, report, policy)
            };

            using var image = presentation.Slides[0].GetImage(options);
            image.Save("slide-1.png", ImageFormat.Png);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Rendering stopped: {exception.Message}");
            return false;
        }
    }

    private static bool ConvertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PdfOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Conversion, report, policy)
            };

            presentation.Save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Conversion stopped: {exception.Message}");
            return false;
        }
    }

    private static bool SaveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy)
    {
        try
        {
            var options = new PptxOptions
            {
                WarningCallback = new ReportingWarningCallback(OperationStage.Saving, report, policy)
            };

            presentation.Save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception)
        {
            Console.Error.WriteLine($"Saving stopped: {exception.Message}");
            return false;
        }
    }

    private enum OperationStage
    {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private sealed class WarningEntry
    {
        public WarningEntry(OperationStage stage, WarningType type, string description)
        {
            Stage = stage;
            Type = type;
            Description = description;
        }

        public OperationStage Stage { get; }

        public WarningType Type { get; }

        public string Description { get; }
    }

    private sealed class WarningReport
    {
        private readonly List<WarningEntry> _entries = new List<WarningEntry>();

        public IReadOnlyList<WarningEntry> Entries => _entries;

        public void Add(OperationStage stage, IWarningInfo warning)
        {
            _entries.Add(new WarningEntry(stage, warning.WarningType, warning.Description));
        }
    }

    private sealed class WarningPolicy
    {
        private readonly bool _abortOnMajorFormattingLoss;

        public WarningPolicy(bool abortOnMajorFormattingLoss)
        {
            _abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        public ReturnAction GetAction(WarningType warningType)
        {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss)
            {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && _abortOnMajorFormattingLoss)
            {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private sealed class ReportingWarningCallback : IWarningCallback
    {
        private readonly OperationStage _stage;
        private readonly WarningReport _report;
        private readonly WarningPolicy _policy;

        public ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy)
        {
            _stage = stage;
            _report = report;
            _policy = policy;
        }

        public ReturnAction Warning(IWarningInfo warning)
        {
            _report.Add(_stage, warning);
            return _policy.GetAction(warning.WarningType);
        }
    }
}
```

Defina `abortOnMajorFormattingLoss` para `false` quando diferenças de formatação maiores forem aceitáveis. Problemas de compatibilidade, perda de formatação menor e conteúdo inesperado ainda são retidos no relatório mesmo quando a operação continua. Estenda `WarningPolicy.GetAction` se a aplicação precisar rejeitar qualquer uma dessas categorias.

## **Cenários Comuns de Avisos**

Avisos podem aparecer em diferentes estágios de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso durante o carregamento de que sua assinatura será perdida durante o processamento. Aspose.Slides relata essa condição `DataLoss` através de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/ipresentationsignedwarninginfo/). Um callback na fase de carregamento permite que a aplicação rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fontes:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fontes são relatados como `DataLoss`, portanto a política estrita acima aborta mesmo se a aplicação considerasse a substituição visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte indisponível para o runtime. A descrição do aviso identifica a substituição; configure as fontes necessárias ou [font substitution rules](/slides/pt/net/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Esses avisos podem usar `UnexpectedContent`, ou uma categoria mais severa quando dados ou formatação são conhecidos por serem afetados.
- **Compatibilidade de formato:** Salvar em outro formato de apresentação pode omitir recursos ou produzir um resultado que se comporte de forma diferente em alguns aplicativos. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais para PPT legada relata um `CompatibilityIssue`. O callback na fase de salvamento pode registrar a perda e continuar, ou rejeitá‑la se for necessário preservar todas as guias.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pt/net/aspose.slides.warnings/iobsoletepreslockingbehaviorwarninginfo/) identifica o uso de um comportamento de bloqueio de apresentação obsoleto como um `CompatibilityIssue`.

Os avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo produz um aviso ou que um cenário sempre se mapeia para apenas uma categoria.

## **Manipular Operações Abortadas com Segurança**

Quando um callback retorna `ReturnAction.Abort`, não use um objeto que falhou ao carregar e não presuma que uma saída de renderização ou salvamento esteja completa. A operação pode ser encerrada após criar um arquivo de saída, mas antes de finalizá‑lo.

Salve resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente após a operação terminar com sucesso, o relatório de avisos atender à política da aplicação e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo de origem válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todos os recursos de origem foram preservados. Aplique quaisquer verificações de conteúdo e visuais adicionais exigidas pela aplicação. Veja também [Open Presentations](/slides/pt/net/open-presentation/) e [Save Presentations](/slides/pt/net/save-presentation/).

## **FAQ**

**Pode um callback de aviso lidar com todos os erros do Aspose.Slides?**

Não. Ele lida com condições recuperáveis relatadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pela aplicação ao redor da chamada de carregamento, renderização, conversão ou salvamento.

**Retornar `ReturnAction.Continue` garante saída idêntica?**

Não. Ele apenas permite que o processamento continue. A condição relatada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos de aviso coletados e suas descrições.

**Como a aplicação pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene uma etapa definida pela aplicação juntamente com `WarningType` e `Description`, conforme mostrado no exemplo.