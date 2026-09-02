---
title: Pesquisar e Substituir Texto em Apresentações PowerPoint em PHP
linktitle: Pesquisar e Substituir Texto
type: docs
weight: 55
url: /pt/php-java/search-and-replace-text/
keywords:
- texto de pesquisa
- texto destacado
- substituir texto
- expressão regular
- retorno de chamada de resultado
- quadro de texto
- relatório de auditoria
- PowerPoint
- OpenDocument
- apresentação
- PHP
- Aspose.Slides
description: "Pesquisar, destacar e substituir texto em apresentações PowerPoint enquanto coleta cada correspondência com Aspose.Slides for PHP via Java."
---
## **Visão Geral**

Aspose.Slides for PHP via Java pode pesquisar, realçar e substituir texto em um quadro de texto individual ou em toda a apresentação. Cada operação também pode notificar uma aplicação sobre cada correspondência por meio de um retorno de chamada de resultado. Isso permite atualizar uma apresentação e, simultaneamente, criar um registro de auditoria contendo o texto encontrado, seu contexto, posição, quadro de texto e número do slide.

Essas funcionalidades são úteis para revisão, redação, verificação de terminologia, limpeza de modelos e fluxos de trabalho de relatórios automatizados.

Nos primeiros exemplos abaixo, usamos um arquivo chamado “sample.pptx”, que contém uma única caixa de texto no primeiro slide com o seguinte conteúdo:

![Sample text](sample_text.png)

## **Escolher o Escopo da Pesquisa**

Use métodos em [TextFrame](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/) para limitar uma operação a um quadro de texto. Use métodos em [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/) para processar todo o texto aplicável na apresentação.

| Operação | Um quadro de texto | Apresentação inteira |
|---|---|---|
| Realçar texto literal | [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText) | [Presentation::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightText) |
| Realçar correspondências de expressão regular | [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex) | [Presentation::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightRegex) |
| Substituir texto literal | [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) | [Presentation::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceText) |
| Substituir correspondências de expressão regular | [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) | [Presentation::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceRegex) |

## **Configurar Correspondência de Texto**

Para operações de texto literal, use [TextSearchOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/) para controlar a correspondência:

- [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) limita as correspondências a palavras completas.
- [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) controla se a capitalização dos caracteres deve coincidir.
- [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) inclui notas de slide nas operações de pesquisa, substituição e realce em nível de apresentação.

Operações com expressão regular utilizam um `Pattern` Java, portanto regras de correspondência como sensibilidade a maiúsculas/minúsculas e limites de palavra são definidas pela própria expressão e seus flags.

## **Coletar Informações de Correspondência com um Retorno de Chamada**

Passe um retorno de chamada proxy Java para um método de realce ou substituição para receber uma notificação para cada correspondência. O método de retorno de chamada recebe o quadro de texto relacionado, o texto fonte, o texto correspondido e a posição da correspondência.

O retorno de chamada não recebe diretamente o número do slide. A implementação abaixo o obtém a partir do slide pai e também trata texto encontrado nas notas do slide. O array de resultado usa `null` quando o texto está associado a outro tipo de slide.

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
        $parentSlide = $textFrame->getSlide();
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

Crie um proxy para este objeto PHP antes de passá‑lo para uma operação:

```php
$callbackHandler = new TextSearchCallback();
$callbackInterface = java("com.aspose.slides.IFindResultCallback");
$callback = java_closure(
    $callbackHandler,
    null,
    $callbackInterface
);
```

Para operações de substituição, `foundText` contém o texto original correspondido, de modo que o retorno de chamada pode registrar exatamente quais termos foram substituídos.

## **Realçar Texto**

Use o método [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText) para realçar correspondências de texto literal em um quadro de texto. Passe [TextSearchOptions](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/) para controlar a pesquisa.

O exemplo de código abaixo realça todas as ocorrências dos caracteres **"try"** e, em seguida, realça apenas a palavra completa **"to"**.

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

    // Realce cada ocorrência de "try" no quadro de texto.
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

    // Realce apenas a palavra completa "to".
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

![The highlighted text](highlighted_text.png)

## **Realçar Texto Usando Expressões Regulares**

O método [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex) realça correspondências de texto encontradas por uma expressão regular em um quadro de texto.

O código a seguir realça todas as palavras que contêm sete ou mais caracteres:

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

![The highlighted text using the regular expression](highlighted_text_using_regex.png)

## **Realçar Texto em Toda a Apresentação**

Use [Presentation::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightText) e [Presentation::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#highlightRegex) para pesquisar todos os quadros de texto aplicáveis em uma apresentação. O exemplo a seguir realça um termo literal e todos os endereços de e‑mail:

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

## **Substituir Texto em um Quadro de Texto**

Use [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) para texto literal e [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) para substituição baseada em padrão. Esses métodos atualizam o texto correspondido dentro do quadro de texto existente, mantendo a formatação das partes circundantes em vez de reconstruir o quadro de texto a partir de uma string simples.

O exemplo a seguir padroniza uma variante ortográfica e, depois, substitui rótulos de versão:

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

Se uma correspondência abranger partes com formatação diferente, revise a saída para confirmar qual formatação deve ser aplicada ao texto substituído.

## **Substituir Texto em Toda a Apresentação**

Use [Presentation::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceText) e [Presentation::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#replaceRegex) para aplicar as mesmas operações em toda a apresentação. Isso é útil para limpeza de modelos, atualizações de terminologia e redação.

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

## **Agrupar Correspondências para Relatório**

Como cada resultado armazena o número do slide e o quadro de texto, as aplicações podem agrupar as correspondências para auditoria, relatórios ou fluxos de trabalho de revisão. O exemplo a seguir agrupa os resultados coletados primeiro por slide e depois por quadro de texto:

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

## **Perguntas Frequentes**

**Como posso pesquisar apenas uma caixa de texto em vez de toda a apresentação?**

Obtenha o quadro de texto da forma e chame [TextFrame::highlightText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightText), [TextFrame::highlightRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#highlightRegex), [TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) ou [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) nesse quadro de texto. Os métodos em nível de apresentação processam todos os quadros de texto aplicáveis.

**Como posso corresponder palavras completas com a capitalização correta?**

Defina [TextSearchOptions::setWholeWordsOnly](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setWholeWordsOnly) e [TextSearchOptions::setCaseSensitive](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setCaseSensitive) como `true` e passe as opções para um método de realce ou substituição de texto literal. Para expressões regulares, defina limites de palavra e sensibilidade a maiúsculas/minúsculas no próprio `Pattern` Java.

**A pesquisa e substituição podem incluir texto nas notas de slide?**

Sim. Defina [TextSearchOptions::setIncludeNotes](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textsearchoptions/#setIncludeNotes) como `true` ao usar uma operação de texto literal em nível de apresentação.

**Como criar um relatório sem analisar a apresentação uma segunda vez?**

Passe um retorno de chamada proxy Java para a operação de realce ou substituição. Ele recebe cada correspondência enquanto a operação é executada, permitindo que a aplicação armazene o texto fonte, o texto correspondido, a posição, o quadro de texto e o número do slide derivado para posterior agrupamento ou exportação.

**A substituição de texto preserva sua formatação?**

[TextFrame::replaceText](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceText) e [TextFrame::replaceRegex](https://reference.aspose.com/slides/pt/php-java/aspose.slides/textframe/#replaceRegex) modificam o texto correspondido dentro do quadro de texto existente e mantêm a formatação das partes circundantes. Se uma correspondência abranger partes com formatação diferente, inspecione o resultado para garantir que a substituição use o estilo desejado.