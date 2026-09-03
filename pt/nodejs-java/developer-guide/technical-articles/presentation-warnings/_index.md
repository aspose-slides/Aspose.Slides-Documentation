---
title: Manipular avisos de apresentação no Node.js
type: docs
weight: 90
url: /pt/nodejs-java/presentation-warnings/
aliases:
- /nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Saiba como coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para Node.js via Java."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Os exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que um aplicativo registre essas condições e decida se a operação atual pode continuar.

Use `java.newProxy` para implementar a interface Java [IWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarningcallback/) em JavaScript e examine os valores [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) fornecidos por meio de [IWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/). Retorne [ReturnAction.Continue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/returnaction/#Continue) para aceitar o aviso ou [ReturnAction.Abort](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/returnaction/#Abort) para interromper a operação.

Use [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setWarningCallback) para avisos gerados ao abrir uma apresentação. Classes de opções de renderização e exportação herdam [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/saveoptions/#setWarningCallback), que recebe avisos da renderização de slides, conversão e gravação. Como o aviso em si não identifica a operação do aplicativo, associe cada instância de callback a um estágio da operação ao construir um relatório combinado.

## **Avisos e exceções**

Um aviso descreve uma condição da qual Aspose.Slides pode se recuperar se o callback retornar `ReturnAction.Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de aviso.

Retornar `ReturnAction.Abort` solicita ao despachante de avisos que termine a operação atual lançando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, ao carregar pode surgir uma [PptxReadException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptreadexception/), enquanto ao salvar ou exportar pode surgir uma [PptxException](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/pptxexception/). Capture o erro da ponte Java no limite da operação e use o relatório de avisos para determinar se a política do aplicativo causou a interrupção, em vez de depender de um subtipo de exceção ou mensagem. O callback registra o aviso antes de retornar `ReturnAction.Abort`, garantindo que o motivo permaneça disponível ao aplicativo.

## **Categorias de Aviso**

A classe [WarningType](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/) fornece constantes inteiras para as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#SourceFileCorruption) | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | Abort​ar. |
| [DataLoss](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou a gravação. | Abort​ar. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#MajorFormattingLoss) | A apresentação pode perder formatação importante. | Abort​ar no modo de validação estrita; caso contrário registrar e continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#MinorFormattingLoss) | Pode ocorrer uma diferença limitada de formatação. | Registrar para diagnóstico e continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#CompatibilityIssue) | O resultado pode não abrir ou se comportar corretamente em alguns aplicativos ou versões mais antigas. | Registrar e continuar, a menos que a compatibilidade seja obrigatória. |
| [UnexpectedContent](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/warningtype/#UnexpectedContent) | A origem contém conteúdo não suportado ou não reconhecido cujo efeito pode ainda ser desconhecido. | Registrar e continuar, ou tratar como erro em uma política estrita. |

A categoria deve orientar a decisão de política. Armazene o valor retornado por [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, mas não dependa da redação para lógica de aplicativo, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e classificar avisos**

O exemplo JavaScript a seguir usa um relatório de nível de aplicação para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e gravação de PPTX. A política aborta em corrupção da fonte ou perda de dados, opcionalmente aborta em perda de formatação maior e continua para outros avisos.

```javascript
const java = require("java");
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

class WarningPolicy {
    constructor(abortOnMajorFormattingLoss) {
        this.abortOnMajorFormattingLoss = abortOnMajorFormattingLoss;
    }

    getAction(warningType) {
        if (warningType === aspose.slides.WarningType.SourceFileCorruption || warningType === aspose.slides.WarningType.DataLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        if (warningType === aspose.slides.WarningType.MajorFormattingLoss && this.abortOnMajorFormattingLoss) {
            return aspose.slides.ReturnAction.Abort;
        }

        return aspose.slides.ReturnAction.Continue;
    }
}

function createReportingWarningCallback(stage, report, policy) {
    return java.newProxy("com.aspose.slides.IWarningCallback", {
        warning: function (warning) {
            const type = warning.getWarningType();
            const description = warning.getDescription();
            report.push({ stage, type, description });
            return policy.getAction(type);
        }
    });
}

function processPresentation(inputPath, report, policy) {
    try {
        const loadOptions = new aspose.slides.LoadOptions();
        const callback = createReportingWarningCallback("Loading", report, policy);
        loadOptions.setWarningCallback(callback);

        const presentation = new aspose.slides.Presentation(inputPath, loadOptions);
        try {
            if (!renderFirstSlide(presentation, report, policy)) {
                return false;
            }

            if (!convertToPdf(presentation, report, policy)) {
                return false;
            }

            return saveValidatedCopy(presentation, report, policy);
        } finally {
            presentation.dispose();
        }
    } catch (error) {
        console.error("Loading stopped: " + error.message);
        return false;
    }
}

function renderFirstSlide(presentation, report, policy) {
    if (presentation.getSlides().size() === 0) {
        console.error("Rendering stopped: the presentation has no slides.");
        return false;
    }

    try {
        const options = new aspose.slides.RenderingOptions();
        const callback = createReportingWarningCallback("Rendering", report, policy);
        options.setWarningCallback(callback);

        const image = presentation.getSlides().get_Item(0).getImage(options);
        try {
            image.save("slide-1.png", aspose.slides.ImageFormat.Png);
            return true;
        } finally {
            image.dispose();
        }
    } catch (error) {
        console.error("Rendering stopped: " + error.message);
        return false;
    }
}

function convertToPdf(presentation, report, policy) {
    try {
        const options = new aspose.slides.PdfOptions();
        const callback = createReportingWarningCallback("Conversion", report, policy);
        options.setWarningCallback(callback);

        presentation.save("converted.pdf", aspose.slides.SaveFormat.Pdf, options);
        return true;
    } catch (error) {
        console.error("Conversion stopped: " + error.message);
        return false;
    }
}

function saveValidatedCopy(presentation, report, policy) {
    try {
        const options = new aspose.slides.PptxOptions();
        const callback = createReportingWarningCallback("Saving", report, policy);
        options.setWarningCallback(callback);

        presentation.save("validated-output.pptx", aspose.slides.SaveFormat.Pptx, options);
        return true;
    } catch (error) {
        console.error("Saving stopped: " + error.message);
        return false;
    }
}

function warningTypeName(warningType) {
    switch (warningType) {
        case aspose.slides.WarningType.SourceFileCorruption:
            return "SourceFileCorruption";
        case aspose.slides.WarningType.DataLoss:
            return "DataLoss";
        case aspose.slides.WarningType.MajorFormattingLoss:
            return "MajorFormattingLoss";
        case aspose.slides.WarningType.MinorFormattingLoss:
            return "MinorFormattingLoss";
        case aspose.slides.WarningType.CompatibilityIssue:
            return "CompatibilityIssue";
        case aspose.slides.WarningType.UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" + warningType + ")";
    }
}

const report = [];
const policy = new WarningPolicy(true);
const completed = processPresentation("input.pptx", report, policy);

console.log(completed ? "Processing completed." : "Processing stopped.");

for (const entry of report) {
    const typeName = warningTypeName(entry.type);
    console.log("[" + entry.stage + "] " + typeName + ": " + entry.description);
}
```

Passe `false` para `abortOnMajorFormattingLoss` ao construir `WarningPolicy` se diferenças maiores de formatação forem aceitáveis. Problemas de compatibilidade, perda de formatação menor e conteúdo inesperado ainda são retidos no relatório mesmo quando a operação continua. Extenda `WarningPolicy.getAction` se o aplicativo precisar rejeitar qualquer uma dessas categorias.

## **Cenários comuns de aviso**

Os avisos podem aparecer em diferentes estágios de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso durante o carregamento de que sua assinatura será perdida durante o processamento. Aspose.Slides relata essa condição `DataLoss` através de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationsignedwarninginfo/). Um callback na fase de carregamento permite que o aplicativo rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fontes:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fontes são reportados como `DataLoss`, portanto a política estrita acima aborta mesmo que o aplicativo considere a substituição visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte indisponível no runtime. A descrição do aviso identifica a substituição; configure as fontes necessárias ou [font substitution rules](/slides/pt/nodejs-java/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Esses avisos podem usar `UnexpectedContent`, ou uma categoria mais severa quando dados ou formatação são afetados.
- **Compatibilidade de formato:** Salvar para outro formato de apresentação pode omitir recursos ou produzir um resultado que se comporte de forma diferente em alguns aplicativos. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais para o formato PPT legado relata um `CompatibilityIssue`. O callback na fase de gravação pode registrar a perda e continuar, ou rejeitá‑la se for necessário preservar todos os guias.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica o uso de um comportamento obsoleto de bloqueio de apresentação como um `CompatibilityIssue`.

Os avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo gera um aviso ou que um cenário sempre mapeia para apenas uma categoria.

## **Manipular operações abortadas com segurança**

Quando um callback retorna `ReturnAction.Abort`, não use um objeto que falhou ao carregar e não presuma que a saída de renderização ou gravação esteja completa. A operação pode terminar após criar um arquivo de saída, mas antes de finalizá‑lo.

Salve resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente após a operação terminar com sucesso, o relatório de avisos atender à política do aplicativo e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo fonte válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todos os recursos da origem foram preservados. Aplique quaisquer verificações de conteúdo e visuais adicionais exigidas pelo aplicativo. Consulte também [Open Presentations](/slides/pt/nodejs-java/open-presentation/) e [Save Presentations](/slides/pt/nodejs-java/save-presentation/).

## **FAQ**

**Um callback de aviso pode tratar todos os erros do Aspose.Slides?**

Não. Ele trata condições recuperáveis relatadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pela aplicação ao redor das chamadas de carregamento, renderização, conversão ou gravação.

**Retornar `ReturnAction.Continue` garante saída idêntica?**

Não. Ele apenas permite que o processamento continue. A condição relatada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos e descrições dos avisos coletados.

**Como o aplicativo pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene um estágio definido pelo aplicativo junto com os valores retornados por [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--), conforme mostrado no exemplo.