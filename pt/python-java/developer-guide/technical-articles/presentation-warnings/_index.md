---
title: Manipular avisos de apresentação em Python via Java
type: docs
weight: 90
url: /pt/python-java/presentation-warnings/
aliases:
- /python-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- Python
- Java
- Aspose.Slides
description: "Aprenda como coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para Python via Java."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que um aplicativo registre essas condições e decida se a operação atual pode continuar.

Implemente a interface `IWarningCallback` através de `jpype.JProxy` e examine os valores `getWarningType` e `getDescription` fornecidos por `IWarningInfo`. Retorne [ReturnAction.Continue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/returnaction/#Continue) para aceitar o aviso ou [ReturnAction.Abort](https://reference.aspose.com/slides/pt/python-java/aspose.slides/returnaction/#Abort) para interromper a operação.

Use [LoadOptions.setWarningCallback](https://reference.aspose.com/slides/pt/python-java/aspose.slides/loadoptions/#setWarningCallback) para avisos gerados ao abrir uma apresentação. As classes de opções de renderização e exportação herdam [SaveOptions.setWarningCallback](https://reference.aspose.com/slides/pt/python-java/aspose.slides/saveoptions/#setWarningCallback), que recebe avisos da renderização de slides, conversão e salvamento. Como o aviso em si não identifica a operação do aplicativo, associe cada instância de callback a uma fase da operação ao criar um relatório combinado.

## **Avisos e Exceções**

Um aviso descreve uma condição da qual o Aspose.Slides pode se recuperar se o callback retornar `ReturnAction.Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de aviso.

Retornar `ReturnAction.Abort` solicita ao despachante de avisos que termine a operação atual levantando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, ao carregar pode surgir uma [PptxReadException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptreadexception/), enquanto ao salvar ou exportar pode surgir uma [PptxException](https://reference.aspose.com/slides/pt/python-java/aspose.slides/pptxexception/). Trate a exceção na fronteira da operação e use o relatório de avisos para determinar se a política do aplicativo causou a interrupção, em vez de depender de um subtipo de exceção ou mensagem. O callback registra o aviso antes de retornar `ReturnAction.Abort`, garantindo que o motivo permaneça disponível para o aplicativo.

## **Categorias de Avisos**

A classe [WarningType](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/) fornece constantes inteiras para as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#SourceFileCorruption) | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | AbortAR. |
| [DataLoss](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou salvamento. | AbortAR. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#MajorFormattingLoss) | A apresentação pode perder formatação importante. | AbortAR em modo de validação estrita; caso contrário registrar e continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#MinorFormattingLoss) | Pode ocorrer uma diferença limitada de formatação. | Registrar para diagnóstico e continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#CompatibilityIssue) | O resultado pode não abrir ou comportar‑se corretamente em alguns aplicativos ou versões antigas. | Registrar e continuar, a menos que a compatibilidade seja obrigatória. |
| [UnexpectedContent](https://reference.aspose.com/slides/pt/python-java/aspose.slides/warningtype/#UnexpectedContent) | A origem contém conteúdo não suportado ou não reconhecido cujo efeito ainda pode ser desconhecido. | Registrar e continuar, ou tratar como erro em uma política estrita. |

A categoria deve orientar a decisão de política. Armazene o valor retornado por `getDescription` para diagnóstico, mas não dependa da redação para lógica de aplicativo, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e Classificar Avisos**

O exemplo a seguir usa um relatório de nível de aplicativo para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e salvamento em PPTX. A política aborta em corrupção de origem ou perda de dados, aborta opcionalmente em perda de formatação maior e continua para outros avisos.

```python
import sys
from dataclasses import dataclass
from enum import Enum

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImageFormat, LoadOptions, PdfOptions, PptxOptions, Presentation, RenderingOptions, ReturnAction, SaveFormat, WarningType


class OperationStage(Enum):
    Loading = "Loading"
    Rendering = "Rendering"
    Conversion = "Conversion"
    Saving = "Saving"


@dataclass(frozen=True)
class WarningEntry:
    stage: OperationStage
    type: int
    description: str


class WarningReport:
    def __init__(self):
        self._entries = []

    def get_entries(self):
        return tuple(self._entries)

    def add(self, stage, warning):
        entry = WarningEntry(stage, warning.getWarningType(), str(warning.getDescription()))
        self._entries.append(entry)


class WarningPolicy:
    def __init__(self, abort_on_major_formatting_loss):
        self.abort_on_major_formatting_loss = abort_on_major_formatting_loss

    def get_action(self, warning_type):
        if warning_type in (WarningType.SourceFileCorruption, WarningType.DataLoss):
            return ReturnAction.Abort
        if warning_type == WarningType.MajorFormattingLoss and self.abort_on_major_formatting_loss:
            return ReturnAction.Abort
        return ReturnAction.Continue


class ReportingWarningCallback:
    def __init__(self, stage, report, policy):
        self.stage = stage
        self.report = report
        self.policy = policy

    def warning(self, warning):
        self.report.add(self.stage, warning)
        return self.policy.get_action(warning.getWarningType())


def process_presentation(input_path, report, policy):
    try:
        load_options = LoadOptions()
        handler = ReportingWarningCallback(OperationStage.Loading, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        load_options.setWarningCallback(callback)
        presentation = Presentation(input_path, load_options)
        try:
            if not render_first_slide(presentation, report, policy):
                return False
            if not convert_to_pdf(presentation, report, policy):
                return False
            return save_validated_copy(presentation, report, policy)
        finally:
            presentation.dispose()
    except Exception as exception:
        print(f"Loading stopped: {exception}", file=sys.stderr)
        return False


def render_first_slide(presentation, report, policy):
    if presentation.getSlides().size() == 0:
        print("Rendering stopped: the presentation has no slides.", file=sys.stderr)
        return False
    try:
        options = RenderingOptions()
        handler = ReportingWarningCallback(OperationStage.Rendering, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        image = presentation.getSlides().get_Item(0).getImage(options)
        try:
            image.save("slide-1.png", ImageFormat.Png)
            return True
        finally:
            image.dispose()
    except Exception as exception:
        print(f"Rendering stopped: {exception}", file=sys.stderr)
        return False


def convert_to_pdf(presentation, report, policy):
    try:
        options = PdfOptions()
        handler = ReportingWarningCallback(OperationStage.Conversion, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("converted.pdf", SaveFormat.Pdf, options)
        return True
    except Exception as exception:
        print(f"Conversion stopped: {exception}", file=sys.stderr)
        return False


def save_validated_copy(presentation, report, policy):
    try:
        options = PptxOptions()
        handler = ReportingWarningCallback(OperationStage.Saving, report, policy)
        callback = jpype.JProxy("com.aspose.slides.IWarningCallback", inst=handler)
        options.setWarningCallback(callback)
        presentation.save("validated-output.pptx", SaveFormat.Pptx, options)
        return True
    except Exception as exception:
        print(f"Saving stopped: {exception}", file=sys.stderr)
        return False


def warning_type_name(warning_type):
    names = {
        WarningType.SourceFileCorruption: "SourceFileCorruption",
        WarningType.DataLoss: "DataLoss",
        WarningType.MajorFormattingLoss: "MajorFormattingLoss",
        WarningType.MinorFormattingLoss: "MinorFormattingLoss",
        WarningType.CompatibilityIssue: "CompatibilityIssue",
        WarningType.UnexpectedContent: "UnexpectedContent",
    }
    return names.get(warning_type, f"Unknown ({warning_type})")


report = WarningReport()
policy = WarningPolicy(True)
completed = process_presentation("input.pptx", report, policy)

print("Processing completed." if completed else "Processing stopped.")
for entry in report.get_entries():
    type_name = warning_type_name(entry.type)
    print(f"[{entry.stage.value}] {type_name}: {entry.description}")
```

Passe `False` para `abort_on_major_formatting_loss` ao construir `WarningPolicy` se diferenças maiores de formatação forem aceitáveis. Problemas de compatibilidade, perda menor de formatação e conteúdo inesperado ainda são mantidos no relatório mesmo quando a operação continua. Estenda `WarningPolicy.get_action` se o aplicativo precisar rejeitar qualquer uma dessas categorias.

## **Cenários Comuns de Avisos**

Avisos podem aparecer em diferentes estágios de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso ao carregar de que sua assinatura será perdida durante o processamento. Aspose.Slides relata essa condição `DataLoss` por meio de `IPresentationSignedWarningInfo`. Um callback na fase de carregamento permite que o aplicativo rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fontes:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fontes são relatados como `DataLoss`, de modo que a política estrita acima aborta mesmo que o aplicativo considere a substituição visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte indisponível no tempo de execução. A descrição do aviso identifica a substituição; configure as fontes necessárias ou [regras de substituição de fontes](/slides/pt/python-java/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Esses avisos podem usar `UnexpectedContent` ou uma categoria mais severa quando dados ou formatação são afetados.
- **Compatibilidade de formato:** Salvar em outro formato de apresentação pode omitir recursos ou produzir um resultado que se comporte de forma diferente em alguns aplicativos. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais para PPT legada gera um `CompatibilityIssue`. O callback na fase de salvamento pode registrar a perda e continuar, ou rejeitá‑la se a preservação de todas as guias for necessária.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, `IObsoletePresLockingBehaviorWarningInfo` identifica o uso de um comportamento obsoleto de bloqueio de apresentação como um `CompatibilityIssue`.

Avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo gera um aviso ou que um cenário sempre se mapeia para apenas uma categoria.

## **Manipular Operações Abortadas com Segurança**

Quando um callback retorna `ReturnAction.Abort`, não use um objeto que falhou ao carregar e não presuma que a saída de renderização ou salvamento está completa. A operação pode terminar após criar um arquivo de saída, mas antes de finalizá‑lo.

Salve resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente após a operação concluir com sucesso, o relatório de avisos atender à política do aplicativo e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo fonte válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todo recurso de origem foi preservado. Aplique quaisquer verificações de conteúdo e visuais adicionais exigidas pelo aplicativo. Consulte também [Abrir apresentações](/slides/pt/python-java/open-presentation/) e [Salvar apresentações](/slides/pt/python-java/save-presentation/).

## **Perguntas frequentes**

**Um callback de aviso pode lidar com todos os erros do Aspose.Slides?**

Não. Ele trata condições recuperáveis relatadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pelo aplicativo ao redor da chamada de carregamento, renderização, conversão ou salvamento.

**Retornar `ReturnAction.Continue` garante saída idêntica?**

Não. Ele apenas permite que o processamento continue. A condição relatada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos e descrições dos avisos coletados.

**Como um aplicativo pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene uma fase definida pelo aplicativo junto com os valores retornados por `getWarningType` e `getDescription`, conforme mostrado no exemplo.