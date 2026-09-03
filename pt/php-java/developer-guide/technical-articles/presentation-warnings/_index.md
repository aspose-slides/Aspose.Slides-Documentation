---
title: Manipular avisos de apresentação em PHP
type: docs
weight: 90
url: /pt/php-java/presentation-warnings/
aliases:
- /php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
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
- PHP
- Aspose.Slides
description: "Aprenda a coletar, classificar e agir sobre avisos ao carregar, renderizar, converter e salvar apresentações com Aspose.Slides para PHP via Java."
---
## **Visão geral**

Aspose.Slides pode relatar problemas recuperáveis enquanto carrega, renderiza, converte ou salva uma apresentação. Exemplos incluem registros de origem danificados, conteúdo que não pode ser preservado, substituição de fontes e limitações de um formato de destino. Um callback de aviso permite que uma aplicação registre essas condições e decida se a operação atual pode continuar.

Crie uma classe PHP com um método público `warning` e exponha-a através do PHP Java Bridge como a interface Java [IWarningCallback](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarningcallback/) usando `java_closure`. Examine os valores fornecidos por [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) em [IWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/). Retorne [ReturnAction::Continue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/returnaction/#Continue) para aceitar o aviso ou [ReturnAction::Abort](https://reference.aspose.com/slides/pt/php-java/aspose.slides/returnaction/#Abort) para interromper a operação.

Use [LoadOptions::setWarningCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setWarningCallback) para avisos levantados ao abrir uma apresentação. As classes de opções de renderização e exportação herdam [SaveOptions::setWarningCallback](https://reference.aspose.com/slides/pt/php-java/aspose.slides/saveoptions/#setWarningCallback), que recebe avisos da renderização de slides, conversão e salvamento. Como o aviso em si não identifica a operação da aplicação, associe cada instância de callback a um estágio da operação ao construir um relatório combinado.

## **Avisos e Exceções**

Exceções Java são expostas ao PHP através do PHP Java Bridge; capture‑as no limite da operação, como mostrado no exemplo abaixo. Os links de interface Java neste artigo descrevem o contrato de callback usado pela ponte.

Um aviso descreve uma condição da qual Aspose.Slides pode se recuperar se o callback retornar `ReturnAction::Continue`. Uma exceção significa que a operação solicitada não pode ser concluída normalmente; exceções não são convertidas em avisos e não podem ser tratadas por uma política de aviso.

Retornar `ReturnAction::Abort` solicita ao despachante de avisos que interrompa a operação atual levantando uma exceção. A exceção pública depende da operação e do formato da apresentação. Por exemplo, o carregamento pode gerar uma [PptxReadException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxreadexception/) ou [PptReadException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptreadexception/), enquanto o salvamento ou exportação pode gerar uma [PptxException](https://reference.aspose.com/slides/pt/php-java/aspose.slides/pptxexception/). Trate a exceção no limite da operação e use o relatório de avisos para determinar se a política da aplicação causou a interrupção, em vez de depender de um subtipo ou mensagem de exceção única. O callback registra o aviso antes de retornar `ReturnAction::Abort`, garantindo que o motivo permaneça disponível para a aplicação.

## **Categorias de Aviso**

A classe [WarningType](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/) fornece constantes inteiras para as seguintes categorias:

| Tipo de aviso | Significado | Política típica |
| --- | --- | --- |
| [SourceFileCorruption](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#SourceFileCorruption) | A apresentação de origem contém corrupção que pode tornar um documento salvo em seu formato original inutilizável. | AbortAR. |
| [DataLoss](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#DataLoss) | Texto, gráficos, imagens ou outros dados podem estar ausentes após o carregamento ou salvamento. | AbortAR. |
| [MajorFormattingLoss](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#MajorFormattingLoss) | A apresentação pode perder formatação importante. | AbortAR no modo de validação estrita; caso contrário registrar e continuar. |
| [MinorFormattingLoss](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#MinorFormattingLoss) | Pode ocorrer uma diferença de formatação limitada. | Registrar para diagnóstico e continuar. |
| [CompatibilityIssue](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#CompatibilityIssue) | O resultado pode não abrir ou comportar‑se corretamente em algumas aplicações ou versões mais antigas. | Registrar e continuar a menos que a compatibilidade seja obrigatória. |
| [UnexpectedContent](https://reference.aspose.com/slides/pt/php-java/aspose.slides/warningtype/#UnexpectedContent) | A origem contém conteúdo não suportado ou não reconhecido cujo efeito ainda pode ser desconhecido. | Registrar e continuar, ou tratar como erro em uma política estrita. |

A categoria deve orientar a decisão de política. Armazene o valor retornado por [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--) para diagnóstico, mas não dependa da sua redação para lógica de aplicação, pois o texto da mensagem pode variar entre cenários de aviso e versões do produto.

## **Coletar e Classificar Avisos**

O exemplo a seguir usa um relatório de nível de aplicação para todo o pipeline de processamento. Uma instância de callback separada rotula avisos de carregamento, renderização, conversão para PDF e salvamento em PPTX. A política aborta em corrupção de origem ou perda de dados, aborta opcionalmente em perda de formatação maior e continua para outros avisos. O callback converte valores de aviso para valores PHP nativos com `java_values` antes de registrá‑los e compará‑los.

```php
use aspose\slides\ImageFormat;
use aspose\slides\LoadOptions;
use aspose\slides\PdfOptions;
use aspose\slides\PptxOptions;
use aspose\slides\Presentation;
use aspose\slides\RenderingOptions;
use aspose\slides\ReturnAction;
use aspose\slides\SaveFormat;
use aspose\slides\WarningType;

class WarningReport {
    private $entries = [];

    public function getEntries() {
        return $this->entries;
    }

    public function add($stage, $type, $description) {
        $this->entries[] = [
            "stage" => $stage,
            "type" => $type,
            "description" => $description
        ];
    }
}

class WarningPolicy {
    private $abortOnMajorFormattingLoss;

    public function __construct($abortOnMajorFormattingLoss) {
        $this->abortOnMajorFormattingLoss = $abortOnMajorFormattingLoss;
    }

    public function getAction($warningType) {
        if ($warningType === WarningType::SourceFileCorruption || $warningType === WarningType::DataLoss) {
            return ReturnAction::Abort;
        }

        if ($warningType === WarningType::MajorFormattingLoss && $this->abortOnMajorFormattingLoss) {
            return ReturnAction::Abort;
        }

        return ReturnAction::Continue;
    }
}

class ReportingWarningCallback {
    private $stage;
    private $report;
    private $policy;

    public function __construct($stage, WarningReport $report, WarningPolicy $policy) {
        $this->stage = $stage;
        $this->report = $report;
        $this->policy = $policy;
    }

    public function warning($warning) {
        $type = (int) java_values($warning->getWarningType());
        $description = (string) java_values($warning->getDescription());
        $this->report->add($this->stage, $type, $description);
        return $this->policy->getAction($type);
    }
}

function createWarningCallback($stage, WarningReport $report, WarningPolicy $policy) {
    $handler = new ReportingWarningCallback($stage, $report, $policy);
    $warningInterface = java("com.aspose.slides.IWarningCallback");
    return java_closure($handler, null, $warningInterface);
}

function processPresentation($inputPath, WarningReport $report, WarningPolicy $policy) {
    try {
        $loadOptions = new LoadOptions();
        $callback = createWarningCallback("Loading", $report, $policy);
        $loadOptions->setWarningCallback($callback);

        $presentation = new Presentation($inputPath, $loadOptions);
        try {
            if (!renderFirstSlide($presentation, $report, $policy)) {
                return false;
            }

            if (!convertToPdf($presentation, $report, $policy)) {
                return false;
            }

            return saveValidatedCopy($presentation, $report, $policy);
        } finally {
            $presentation->dispose();
        }
    } catch (Throwable $exception) {
        echo "Loading stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function renderFirstSlide($presentation, WarningReport $report, WarningPolicy $policy) {
    if ((int) java_values($presentation->getSlides()->size()) === 0) {
        echo "Rendering stopped: the presentation has no slides." . PHP_EOL;
        return false;
    }

    try {
        $options = new RenderingOptions();
        $callback = createWarningCallback("Rendering", $report, $policy);
        $options->setWarningCallback($callback);

        $image = $presentation->getSlides()->get_Item(0)->getImage($options);
        try {
            $image->save("slide-1.png", ImageFormat::Png);
            return true;
        } finally {
            $image->dispose();
        }
    } catch (Throwable $exception) {
        echo "Rendering stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function convertToPdf($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PdfOptions();
        $callback = createWarningCallback("Conversion", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("converted.pdf", SaveFormat::Pdf, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Conversion stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function saveValidatedCopy($presentation, WarningReport $report, WarningPolicy $policy) {
    try {
        $options = new PptxOptions();
        $callback = createWarningCallback("Saving", $report, $policy);
        $options->setWarningCallback($callback);

        $presentation->save("validated-output.pptx", SaveFormat::Pptx, $options);
        return true;
    } catch (Throwable $exception) {
        echo "Saving stopped: " . $exception->getMessage() . PHP_EOL;
        return false;
    }
}

function warningTypeName($warningType) {
    switch ($warningType) {
        case WarningType::SourceFileCorruption:
            return "SourceFileCorruption";
        case WarningType::DataLoss:
            return "DataLoss";
        case WarningType::MajorFormattingLoss:
            return "MajorFormattingLoss";
        case WarningType::MinorFormattingLoss:
            return "MinorFormattingLoss";
        case WarningType::CompatibilityIssue:
            return "CompatibilityIssue";
        case WarningType::UnexpectedContent:
            return "UnexpectedContent";
        default:
            return "Unknown (" . $warningType . ")";
    }
}

$report = new WarningReport();
$policy = new WarningPolicy(true);
$completed = processPresentation("input.pptx", $report, $policy);

echo ($completed ? "Processing completed." : "Processing stopped.") . PHP_EOL;

foreach ($report->getEntries() as $entry) {
    $typeName = warningTypeName($entry["type"]);
    echo "[" . $entry["stage"] . "] " . $typeName . ": " . $entry["description"] . PHP_EOL;
}
```

Passe `false` para `abortOnMajorFormattingLoss` ao construir `WarningPolicy` se diferenças de formatação maiores forem aceitáveis. Problemas de compatibilidade, perda de formatação menor e conteúdo inesperado ainda são mantidos no relatório mesmo quando a operação continua. Estenda `WarningPolicy::getAction` se a aplicação precisar rejeitar qualquer uma dessas categorias.

## **Cenários Comuns de Aviso**

Avisos podem aparecer em diferentes estágios de um fluxo de trabalho:

- **Assinaturas digitais:** Uma apresentação assinada pode gerar um aviso durante o carregamento de que sua assinatura será perdida durante o processamento. Aspose.Slides relata essa condição `DataLoss` através de [IPresentationSignedWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/ipresentationsignedwarninginfo/). Um callback na fase de carregamento permite que a aplicação rejeite o arquivo ou aceite explicitamente a perda relatada.
- **Substituição de fonte:** Uma fonte indisponível pode ser substituída enquanto um slide é renderizado ou exportado. Avisos de substituição de fonte são reportados como `DataLoss`, portanto a política estrita acima aborta mesmo que a aplicação considere a substituição visualmente aceitável. Para observar esse comportamento, use uma apresentação de entrada contendo texto em uma fonte indisponível no runtime. A descrição do aviso identifica a substituição; configure as fontes necessárias ou [font substitution rules](/slides/pt/php-java/font-substitution/) antes de tentar novamente.
- **Conteúdo não suportado ou inesperado:** Um carregador pode encontrar registros ou recursos da apresentação que não reconhece. Tais avisos podem usar `UnexpectedContent` ou uma categoria mais severa quando dados ou formatação são conhecidos por estar afetados.
- **Compatibilidade de formato:** Salvar em outro formato de apresentação pode omitir recursos ou gerar um resultado que se comporte de forma diferente em algumas aplicações. Por exemplo, salvar uma apresentação com mais de oito guias de desenho horizontais ou verticais para o PPT legado relata um `CompatibilityIssue`. O callback na fase de salvamento pode registrar a perda e continuar, ou rejeitar se for necessário preservar todas as guias.
- **Comportamento de carregamento:** Opções de carregamento e comportamentos legados também podem gerar avisos. Por exemplo, [IObsoletePresLockingBehaviorWarningInfo](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iobsoletepreslockingbehaviorwarninginfo/) identifica o uso de um comportamento de bloqueio de apresentação obsoleto como um `CompatibilityIssue`.

Avisos dependem do documento de origem, do formato de destino, da operação e da versão do Aspose.Slides. Não presuma que todo arquivo gerar‑á um aviso ou que um cenário sempre mapeie para apenas uma categoria.

## **Manipular Operações Abortadas com Segurança**

Quando um callback retorna `ReturnAction::Abort`, não use um objeto que falhou ao carregar e não presuma que a saída de renderização ou salvamento está completa. A operação pode terminar após criar um arquivo de saída, mas antes de finalizá‑lo.

Salve resultados validados em um caminho separado, como `validated-output.pptx`. Substitua uma apresentação existente somente depois que a operação terminar com sucesso, o relatório de avisos atender à política da aplicação e a saída puder ser aberta e verificada. Isso evita sobrescrever um arquivo de origem válido com um resultado parcial ou rejeitado.

Um relatório de avisos vazio não garante que todos os recursos de origem foram preservados. Aplique quaisquer verificações adicionais de conteúdo e visual exigidas pela aplicação. Consulte também [Open Presentations](/slides/pt/php-java/open-presentation/) e [Save Presentations](/slides/pt/php-java/save-presentation/).

## **FAQ**

**Um callback de aviso pode lidar com todos os erros do Aspose.Slides?**

Não. Ele lida com condições recuperáveis relatadas como avisos. Exceções que ocorrem independentemente do callback devem ser tratadas pela aplicação ao redor da chamada de carregamento, renderização, conversão ou salvamento.

**Retornar `ReturnAction::Continue` garante saída idêntica?**

Não. Ele apenas permite que o processamento continue. A condição reportada ainda pode causar diferenças de dados, formatação ou compatibilidade, portanto revise os tipos e descrições de aviso coletados.

**Como a aplicação pode identificar a operação que gerou um aviso?**

Crie uma instância de callback para cada operação e armazene um estágio definido pela aplicação junto com os valores retornados por [getWarningType](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getWarningType--) e [getDescription](https://reference.aspose.com/slides/pt/java/com.aspose.slides/iwarninginfo/#getDescription--), como mostrado no exemplo.