---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em PHP
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/php-java/search-and-replace-text/
keywords:
- pesquisar texto
- destacar texto
- substituir texto
- expressão regular
- callback de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Pesquisar, destacar e substituir texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides for PHP via Java."
---
## **Visão geral**

Aspose.Slides for PHP via Java pode pesquisar, destacar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar um aplicativo sobre cada correspondência por meio de um callback de resultados. Isso possibilita atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto correspondido, seu contexto, posição, quadro de texto e número do slide.

Essas funcionalidades são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado "sample.pptx", que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Texto de exemplo](sample_text.png)

## **Escolher o escopo da busca**

Use os métodos em [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) para limitar uma operação a um único quadro de texto. Use os métodos em [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Destacar texto literal | [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightText) |
| Destacar correspondências de expressão regular | [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightRegex) |
| Substituir texto literal | [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceText) |
| Substituir correspondências de expressão regular | [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configurar correspondência de texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limita as correspondências a palavras completas.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controla se a diferença entre maiúsculas e minúsculas deve ser considerada.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) inclui notas de slides nas operações de busca, substituição e destaque em nível de apresentação.

Operações com expressão regular utilizam um `Pattern` Java, portanto regras de correspondência como sensibilidade a maiúsculas e limites de palavras são definidas pela própria expressão e suas flags.

## **Identificar o proprietário de um quadro de texto**

Os fluxos de trabalho genéricos de processamento de texto frequentemente recebem um [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) ao pesquisar, substituir, validar ou exportar texto. Use [TextFrame::getParentShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentShape) e [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) para determinar qual objeto da apresentação possui o quadro de texto.

Os valores esperados dependem do proprietário:

| Proprietário do quadro de texto | `getParentShape` | `getParentCell` |
|---|---|---|
| Um AutoShape ou outra forma que contenha texto | A [Shape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/shape/) | `null` |
| Uma célula de tabela | `null` | A [Cell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/cell/) |

Ambos os métodos fornecem navegação somente leitura. Chamar esses métodos não move o quadro de texto nem altera seu proprietário. O código genérico deve verificar ambos os valores com `java_is_null` e tratar a possibilidade de que nenhum proprietário esteja disponível.

O exemplo a seguir usa [SlideUtil::getAllTextFrames](https://reference.aspose.com/slides/pt/php-java/aspose.slides/slideutil/#getAllTextFrames) para percorrer os quadros de texto em uma apresentação. Para formas, ele relata o nome da forma, o tipo Java em tempo de execução e o slide contendo. Para células de tabela, ele relata as coordenadas de coluna e linha baseadas em zero e o slide contendo.

```php
use aspose\slides\Presentation;
use aspose\slides\SlideUtil;

$presentation = new Presentation("presentation.pptx");
$arrayClass = new java_class("java.lang.reflect.Array");

try {
    $textFrames = SlideUtil::getAllTextFrames($presentation, false);
    $textFrameCount = java_values($arrayClass->getLength($textFrames));

    for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
        $textFrame = $textFrames[$textFrameIndex];
        $ownerShape = $textFrame->getParentShape();
        if (!java_is_null($ownerShape)) {
            $shapeName = java_values($ownerShape->getName());
            $shapeName = $shapeName === "" ? "(unnamed)" : $shapeName;
            $shapeType = java_values($ownerShape->getClass()->getSimpleName());
            $baseSlide = $ownerShape->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Shape: " . $shapeName . "; type: " . $shapeType . "; " . $slideLabel . "\n");
            continue;
        }

        $ownerCell = $textFrame->getParentCell();
        if (!java_is_null($ownerCell)) {
            $baseSlide = $ownerCell->getSlide();
            $slideClassName = java_values($baseSlide->getClass()->getName());

            if ($slideClassName === "com.aspose.slides.Slide") {
                $slideLabel = "slide " . java_values($baseSlide->getSlideNumber());
            } elseif ($slideClassName === "com.aspose.slides.NotesSlide") {
                $slideLabel = "notes for slide " . java_values($baseSlide->getParentSlide()->getSlideNumber());
            } else {
                $slideLabel = java_values($baseSlide->getClass()->getSimpleName());
            }

            echo("Table cell: column " . java_values($ownerCell->getFirstColumnIndex()) . ", row " . java_values($ownerCell->getFirstRowIndex()) . "; " . $slideLabel . "\n");
            continue;
        }

        echo("The text frame owner is not available as a shape or table cell.\n");
    }
} finally {
    $presentation->dispose();
}
```

Para conteúdo SmartArt, percorra as formas em [SmartArtNode::getShapes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartnode/#getShapes) e acesse cada [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/smartartshape/#getTextFrame). O quadro de texto pode ser rastreado até sua forma associada através de [TextFrame::getParentShape](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentShape), enquanto [TextFrame::getParentCell](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#getParentCell) retorna `null`. Portanto, o ramo de forma no exemplo também trata texto de nós SmartArt.

## **Coletar informações de correspondência com um callback**

Passe um callback proxy Java para um método de destaque ou substituição para receber uma notificação para cada correspondência. O método de callback recebe o quadro de texto relacionado, o texto fonte, o texto correspondido e a posição da correspondência.

O callback não recebe o número do slide diretamente. A implementação abaixo o obtém a partir do slide pai e também trata texto encontrado nas notas do slide. O array de resultados usa `null` quando o texto está associado a outro tipo de slide.

```php
class TextSearchCallback {
    private $results = [];

    public function getResults() {
        return $this->results;
    }

    public function foundResult($textFrame, $sourceText, $foundText, $textPosition) {
        $slideNumber = $this->getSlideNumber($textFrame);
        $this->results[] = [
            "textFrame" => $textFrame,
            "sourceText" => java_values($sourceText),
            "foundText" => java_values($foundText),
            "textPosition" => java_values($textPosition),
            "slideNumber" => $slideNumber
        ];
    }

    private function getSlideNumber($textFrame) {
        $parentShape = $textFrame->getParentShape();
        $parentCell = $textFrame->getParentCell();

        if (!java_is_null($parentShape)) {
            $parentSlide = $parentShape->getSlide();
        } elseif (!java_is_null($parentCell)) {
            $parentSlide = $parentCell->getSlide();
        } else {
            $parentSlide = $textFrame->getSlide();
        }

        if (java_is_null($parentSlide)) {
            return null;
        }

        $parentSlideClass = $parentSlide->getClass();
        $classNameValue = $parentSlideClass->getName();
        $className = java_values($classNameValue);

        if ($className === "com.aspose.slides.Slide") {
            $slideNumber = $parentSlide->getSlideNumber();
            return java_values($slideNumber);
        }

        if ($className === "com.aspose.slides.NotesSlide") {
            $slide = $parentSlide->getParentSlide();
            $slideNumber = $slide->getSlideNumber();
            return java_values($slideNumber);
        }

        return null;
    }
}
```

Crie um proxy para este objeto PHP antes de passá‑lo a uma operação:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Para operações de substituição, `foundText` contém o texto original correspondido, portanto o callback pode registrar exatamente quais termos foram substituídos.

## **Destacar texto**

Use o método [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText) para destacar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/) para controlar a busca.

O exemplo de código abaixo destaca todas as ocorrências dos caracteres **"try"** e depois destaca somente a palavra completa **"to"**.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $callbackHandler = new TextSearchCallback();
    $callbackInterface = java("com.aspose.slides.IFindResultCallback");
    $callback = java_closure(
        $callbackHandler,
        null,
        $callbackInterface
    );

    $substringSearchOptions = new TextSearchOptions();
    $substringSearchOptions->setCaseSensitive(false);
    $substringHighlightColor = new Java("java.awt.Color", 173, 216, 230);

    // Destacar cada ocorrência de "try" no quadro de texto.
    $shape->getTextFrame()->highlightText(
        "try",
        $substringHighlightColor,
        $substringSearchOptions,
        $callback
    );

    $wholeWordSearchOptions = new TextSearchOptions();
    $wholeWordSearchOptions->setWholeWordsOnly(true);
    $wholeWordSearchOptions->setCaseSensitive(false);
    $wholeWordHighlightColor = new Java("java.awt.Color", 238, 130, 238);

    // Destacar somente a palavra completa "to".
    $shape->getTextFrame()->highlightText(
        "to",
        $wholeWordHighlightColor,
        $wholeWordSearchOptions,
        $callback
    );

    foreach ($callbackHandler->getResults() as $result) {
        echo(
            "Found '" . $result["foundText"] . "' at position " .
            $result["textPosition"] . " on slide " .
            $result["slideNumber"] . ".\n"
        );
    }

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

O resultado:

![O texto destacado](highlighted_text.png)

## **Destacar texto usando expressões regulares**

O método [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex) destaca as correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir destaca todas as palavras que contêm sete ou mais caracteres:

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);
    $regex = java("java.util.regex.Pattern")->compile("\\b[^\\s]{7,}\\b");
    $highlightColor = java("java.awt.Color")->YELLOW;

    $shape->getTextFrame()->highlightRegex($regex, $highlightColor, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

O resultado:

![O texto destacado usando a expressão regular](highlighted_text_using_regex.png)

## **Destacar texto em toda a apresentação**

Use [Presentation::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightText) e [Presentation::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightRegex) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir destaca um termo literal e todos os endereços de e‑mail:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);
    $termHighlightColor = java("java.awt.Color")->ORANGE;

    $presentation->highlightText(
        "confidential",
        $termHighlightColor,
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $emailPattern = "\\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,}\\b";
    $emailRegex = $patternClass->compile(
        $emailPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $emailHighlightColor = java("java.awt.Color")->YELLOW;

    $presentation->highlightRegex($emailRegex, $emailHighlightColor, null);
    $presentation->save("highlighted_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Substituir texto em um quadro de texto**

Use [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) para texto literal e [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, que mantém a formatação das porções ao redor em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e depois substitui rótulos de versão:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(false);

    $shape->getTextFrame()->replaceText(
        "colour",
        "color",
        $searchOptions,
        null
    );

    $patternClass = java("java.util.regex.Pattern");
    $versionPattern = "\\bv\\d+(?:\\.\\d+)*\\b";
    $versionRegex = $patternClass->compile(
        $versionPattern,
        $patternClass->CASE_INSENSITIVE
    );
    $shape->getTextFrame()->replaceRegex(
        $versionRegex,
        "current version",
        null
    );

    $presentation->save("updated_text_frame.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

Se uma correspondência abranger porções com formatação diferente, revise o resultado para confirmar qual formatação deve ser aplicada ao texto de substituição.

## **Substituir texto em toda a apresentação**

Use [Presentation::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceText) e [Presentation::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceRegex) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualização de terminologia e redação.

```php
$presentation = new Presentation("presentation.pptx");
try {
    $searchOptions = new TextSearchOptions();
    $searchOptions->setWholeWordsOnly(true);
    $searchOptions->setCaseSensitive(true);

    $presentation->replaceText(
        "Contoso",
        "Example Corp",
        $searchOptions,
        null
    );

    $accountNumberRegex = java("java.util.regex.Pattern")->compile(
        "\\bACCT-\\d{6}\\b"
    );
    $presentation->replaceRegex(
        $accountNumberRegex,
        "ACCT-REDACTED",
        null
    );

    $presentation->save("updated_presentation.pptx", SaveFormat::Pptx);
}
finally {
    $presentation->dispose();
}
```

## **Agrupar correspondências para relatórios**

Como cada resultado armazena seu número de slide e quadro de texto, os aplicativos podem agrupar correspondências para auditoria, relatórios ou fluxos de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

```php
$matchesBySlide = [];
$systemClass = java("java.lang.System");

foreach ($callbackHandler->getResults() as $result) {
    $slideNumber = $result["slideNumber"];
    $slideLabel = $slideNumber === null ? "Other" : (string) $slideNumber;
    $textFrame = $result["textFrame"];
    $textFrameHash = $systemClass->identityHashCode($textFrame);
    $textFrameKey = (string) java_values($textFrameHash);

    if (!isset($matchesBySlide[$slideLabel])) {
        $matchesBySlide[$slideLabel] = [];
    }

    if (!isset($matchesBySlide[$slideLabel][$textFrameKey])) {
        $matchesBySlide[$slideLabel][$textFrameKey] = [
            "textFrame" => $textFrame,
            "matches" => []
        ];
    }

    $matchesBySlide[$slideLabel][$textFrameKey]["matches"][] = $result;
}

foreach ($matchesBySlide as $slideLabel => $textFrameGroups) {
    echo("Slide: " . $slideLabel . "\n");

    foreach ($textFrameGroups as $textFrameGroup) {
        $textFrame = $textFrameGroup["textFrame"];
        echo("  Text frame: " . $textFrame->getText() . "\n");

        foreach ($textFrameGroup["matches"] as $result) {
            echo(
                "    '" . $result["foundText"] . "' at position " .
                $result["textPosition"] . "; context: '" .
                $result["sourceText"] . "'\n"
            );
        }
    }
}
```

## **Perguntas frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) ou [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis em vez disso.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) e [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) como `true` e passe as opções para um método de destaque ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Pattern` Java.

**A pesquisa e substituição podem incluir texto nas notas do slide?**

Sim. Defina [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) como `true` ao usar uma operação de texto literal em nível de apresentação.

**Como posso criar um relatório sem escanear a apresentação uma segunda vez?**

Passe um callback proxy Java para a operação de destaque ou substituição. Ele recebe cada correspondência enquanto a operação é executada, permitindo que o aplicativo armazene o texto fonte, o texto correspondido, a posição, o quadro de texto e o número de slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) e [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação das porções ao redor. Se uma correspondência abranger porções com formatação diferente, examine o resultado para garantir que a substituição use o estilo desejado.