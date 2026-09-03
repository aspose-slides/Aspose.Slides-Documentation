---
title: Manipular avisos de apresentação em Java
type: docs
weight: 90
url: /pt/java/presentation-warnings/
aliases:
- /java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- callback de aviso
- política de aviso
- perda de dados
- corrupção de origem
- problema de compatibilidade
- substituição de fonte
- assinatura digital
- carregamento de apresentação
- renderização de apresentação
- conversão de apresentação
- salvamento de apresentação
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Aprenda como coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para Java."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que a aplicação registre essas condições e decida se a operação atual pode continuar.

Implemente a interface [IWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarningcallback/) e examine os valores fornecidos por [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) através de [IWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/). Retorne [ReturnAction.Continue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/returnaction/#Continue) para aceitar o aviso ou [ReturnAction.Abort](https://reference.aspose.com/slides/pt/java/com.aspose.slides/returnaction/#Abort) para interromper a operação.

Use [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/loadoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) para avisos levantados ao abrir uma apresentação. Classes de opções de renderização e exportação herdam [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-), que recebem avisos da renderização de slides, conversão e gravação. Como o aviso em si não identifica a operação da aplicação, associe cada instância de callback a uma fase da operação ao montar um relatório combinado.

## **Avisos e exceções**

Um aviso descreve uma condição da qual o Aspose.Slides pode se recuperar se o callback retornar `ReturnAction.Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de avisos.

Retornar `ReturnAction.Abort` solicita ao despachante de avisos que finalize a operação atual lançando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, ao carregar pode aparecer uma [PptxReadException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptreadexception/), enquanto ao salvar ou exportar pode surgir uma [PptxException](https://reference.aspose.com/slides/pt/java/com.aspose.slides/pptxexception/). Manipule a exceção no limite da operação e use o relatório de avisos para determinar se a política da aplicação causou a interrupção, em vez de confiar em um subtipo ou mensagem de exceção. O callback registra o aviso antes de retornar `ReturnAction.Abort`, garantindo que a razão permaneça disponível para a aplicação.

## **Categorias de aviso**

A classe [WarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/) fornece constantes inteiras para as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#SourceFileCorruption) | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | Abort​ar. |
| [DataLoss](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou a gravação. | Abort​ar. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#MajorFormattingLoss) | A apresentação pode perder formatação importante. | Abort​ar no modo de validação estrita; caso contrário registrar e continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#MinorFormattingLoss) | Uma diferença de formatação limitada pode ocorrer. | Registrar para diagnóstico e continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#CompatibilityIssue) | O resultado pode não abrir ou se comportar corretamente em alguns aplicativos ou versões mais antigas. | Registrar e continuar, a menos que a compatibilidade seja obrigatória. |
| [UnexpectedContent](https://reference.aspose.com/slides/pt/java/com.aspose.slides/warningtype/#UnexpectedContent) | A origem contém conteúdo não suportado ou não reconhecido cujo efeito ainda pode ser desconhecido. | Registrar e continuar, ou tratar como erro em uma política estrita. |

A categoria deve conduzir a decisão de política. Armazene o valor retornado por [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, mas não dependa da sua redação para lógica da aplicação, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e classificar avisos**

O exemplo a seguir usa um relatório de nível de aplicação para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e gravação em PPTX. A política aborta em corrupção de origem ou perda de dados, opcionalmente aborta em perda de formatação maior e continua para os demais avisos.

```java
import com.aspose.slides.IImage;
import com.aspose.slides.IWarningCallback;
import com.aspose.slides.IWarningInfo;
import com.aspose.slides.ImageFormat;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.PdfOptions;
import com.aspose.slides.PptxOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.RenderingOptions;
import com.aspose.slides.ReturnAction;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.WarningType;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

class PresentationWarningExample {
    public static void main(String[] args) {
        WarningReport report = new WarningReport();
        WarningPolicy policy = new WarningPolicy(true);
        boolean completed = processPresentation("input.pptx", report, policy);

        System.out.println(completed ? "Processing completed." : "Processing stopped.");

        for (WarningEntry entry : report.getEntries()) {
            String typeName = warningTypeName(entry.type);
            System.out.println("[" + entry.stage + "] " + typeName + ": " + entry.description);
        }
    }

    private static boolean processPresentation(String inputPath, WarningReport report, WarningPolicy policy) {
        try {
            LoadOptions loadOptions = new LoadOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Loading, report, policy);
            loadOptions.setWarningCallback(callback);

            Presentation presentation = new Presentation(inputPath, loadOptions);
            try {
                if (!renderFirstSlide(presentation, report, policy)) {
                    return false;
                }

                if (!convertToPdf(presentation, report, policy)) {
                    return false;
                }

                return saveValidatedCopy(presentation, report, policy);
            }
            finally {
                presentation.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Loading stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean renderFirstSlide(Presentation presentation, WarningReport report, WarningPolicy policy) {
        if (presentation.getSlides().size() == 0) {
            System.err.println("Rendering stopped: the presentation has no slides.");
            return false;
        }

        try {
            RenderingOptions options = new RenderingOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Rendering, report, policy);
            options.setWarningCallback(callback);

            IImage image = presentation.getSlides().get_Item(0).getImage(options);
            try {
                image.save("slide-1.png", ImageFormat.Png);
                return true;
            }
            finally {
                image.dispose();
            }
        }
        catch (Exception exception) {
            System.err.println("Rendering stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean convertToPdf(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PdfOptions options = new PdfOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Conversion, report, policy);
            options.setWarningCallback(callback);

            presentation.save("converted.pdf", SaveFormat.Pdf, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Conversion stopped: " + exception.getMessage());
            return false;
        }
    }

    private static boolean saveValidatedCopy(Presentation presentation, WarningReport report, WarningPolicy policy) {
        try {
            PptxOptions options = new PptxOptions();
            ReportingWarningCallback callback = new ReportingWarningCallback(OperationStage.Saving, report, policy);
            options.setWarningCallback(callback);

            presentation.save("validated-output.pptx", SaveFormat.Pptx, options);
            return true;
        }
        catch (Exception exception) {
            System.err.println("Saving stopped: " + exception.getMessage());
            return false;
        }
    }

    private static String warningTypeName(int warningType) {
        switch (warningType) {
            case WarningType.SourceFileCorruption:
                return "SourceFileCorruption";
            case WarningType.DataLoss:
                return "DataLoss";
            case WarningType.MajorFormattingLoss:
                return "MajorFormattingLoss";
            case WarningType.MinorFormattingLoss:
                return "MinorFormattingLoss";
            case WarningType.CompatibilityIssue:
                return "CompatibilityIssue";
            case WarningType.UnexpectedContent:
                return "UnexpectedContent";
            default:
                return "Unknown (" + warningType + ")";
        }
    }

    private enum OperationStage {
        Loading,
        Rendering,
        Conversion,
        Saving
    }

    private static final class WarningEntry {
        final OperationStage stage;
        final int type;
        final String description;

        WarningEntry(OperationStage stage, int type, String description) {
            this.stage = stage;
            this.type = type;
            this.description = description;
        }
    }

    private static final class WarningReport {
        private final List<WarningEntry> entries = new ArrayList<WarningEntry>();

        List<WarningEntry> getEntries() {
            return Collections.unmodifiableList(entries);
        }

        void add(OperationStage stage, IWarningInfo warning) {
            WarningEntry entry = new WarningEntry(stage, warning.getWarningType(), warning.getDescription());
            entries.add(entry);
        }
    }

    private static final class WarningPolicy {
        private final boolean abortOnMajorFormattingLoss;

        WarningPolicy(boolean abortOnMajorFormattingLoss) {
            this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
        }

        int getAction(int warningType) {
            if (warningType == WarningType.SourceFileCorruption || warningType == WarningType.DataLoss) {
                return ReturnAction.Abort;
            }

            if (warningType == WarningType.MajorFormattingLoss && abortOnMajorFormattingLoss) {
                return ReturnAction.Abort;
            }

            return ReturnAction.Continue;
        }
    }

    private static final class ReportingWarningCallback implements IWarningCallback {
        private final OperationStage stage;
        private final WarningReport report;
        private final WarningPolicy policy;

        ReportingWarningCallback(OperationStage stage, WarningReport report, WarningPolicy policy) {
            this.stage = stage;
            this.report = report;
            this.policy = policy;
        }

        @Override
        public int warning(IWarningInfo warning) {
            report.add(stage, warning);
            return policy.getAction(warning.getWarningType());
        }
    }
}
```

Passe `false` para `abortOnMajorFormattingLoss` ao construir `WarningPolicy` se diferenças de formatação maiores forem aceitáveis. Problemas de compatibilidade, perda de formatação menor e conteúdo inesperado ainda são mantidos no relatório mesmo quando a operação continua. Extenda `WarningPolicy.getAction` se a aplicação precisar rejeitar quaisquer dessas categorias.

## **Cenários comuns de aviso**

Avisos podem aparecer em diferentes estágios de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso durante o carregamento indicando que sua assinatura será perdida durante o processamento. O Aspose.Slides relata essa condição `DataLoss` através de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationsignedwarninginfo/). Um callback na fase de carregamento permite que a aplicação rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fontes:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fonte são reportados como `DataLoss`, portanto a política estrita acima aborta mesmo que a aplicação considere a substituição visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte inexistente no tempo de execução. A descrição do aviso identifica a substituição; configure as fontes necessárias ou as [regras de substituição de fonte](/slides/pt/java/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Esses avisos podem usar `UnexpectedContent` ou uma categoria mais severa quando dados ou formatação são afetados.
- **Compatibilidade de formato:** Salvar para outro formato de apresentação pode omitir recursos ou produzir um resultado que se comporte de forma diferente em alguns aplicativos. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais para o legado PPT gera um `CompatibilityIssue`. O callback na fase de gravação pode registrar a perda e continuar, ou rejeitá‑la se for necessário preservar todas as guias.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica o uso de um comportamento obsoleto de bloqueio de apresentação como `CompatibilityIssue`.

Os avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo gere um aviso ou que um cenário mapeie sempre para uma única categoria.

## **Manipular operações abortadas com segurança**

Quando um callback retorna `ReturnAction.Abort`, não use um objeto que falhou ao carregar e não presuma que a saída de renderização ou gravação está completa. A operação pode terminar após criar um arquivo de saída, mas antes de finalizá‑lo.

Salve os resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente depois que a operação terminar com sucesso, o relatório de avisos atender à política da aplicação e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo de origem válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todos os recursos da origem foram preservados. Aplique quaisquer verificações de conteúdo e visuais adicionais exigidas pela aplicação. Veja também [Abrir apresentações](/slides/pt/java/open-presentation/) e [Salvar apresentações](/slides/pt/java/save-presentation/).

## **Perguntas frequentes**

**Um callback de aviso pode tratar todos os erros do Aspose.Slides?**

Não. Ele trata condições recuperáveis que são reportadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pela aplicação ao redor da chamada de carregamento, renderização, conversão ou gravação.

**Retornar `ReturnAction.Continue` garante saída idêntica?**

Não. Apenas permite que o processamento continue. A condição reportada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos e descrições dos avisos coletados.

**Como a aplicação pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene um estágio definido pela aplicação junto com os valores retornados por [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--), conforme demonstrado no exemplo.