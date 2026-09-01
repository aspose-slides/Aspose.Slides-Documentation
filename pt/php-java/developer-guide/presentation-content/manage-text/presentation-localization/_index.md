---
title: Automatizar a localização de apresentações em PHP
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/php-java/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id do idioma
- texto multilíngue
- PowerPoint
- apresentação
- PHP
- Aspose.Slides
description: "Defina idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em PHP com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides for PHP via Java permite que você configure metadados de revisão para partes individuais de texto. Use [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) para identificar o idioma de revisão, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setSpellCheck) para permitir ou suprimir verificações ortográficas, e [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setProofDisabled) para controlar o estado mais amplo de não‑revisão. Como essas configurações são aplicadas ao nível da parte, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), criar parágrafos multilíngues, escolher entre `SpellCheck` e `ProofDisabled` e preservar as configurações desejadas ao usar [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Essas propriedades armazenam metadados para aplicativos de apresentação; eles não traduzem texto, não executam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para o texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/), acesse a parte de texto necessária através de [Portion::getPortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getPortionFormat) e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o inglês britânico como idioma de revisão e salva o resultado com [Presentation::save](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Definir o idioma padrão para novo texto**

Use [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) para especificar o idioma de revisão que Aspose.Slides atribui ao texto recém‑criado. Esta configuração é útil quando a maior parte ou todo o novo texto em uma apresentação usa o mesmo idioma. Não altera os metadados de idioma de texto que já possui um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto usa regras de revisão em alemão:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Usar vários idiomas em um parágrafo**

Um [Paragraph](https://reference.aspose.com/slides/pt/php-java/aspose.slides/paragraph/) contém uma coleção de partes de texto. Crie uma [Portion](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/) separada para cada idioma e defina seu `LanguageId` independentemente.

O exemplo cria um parágrafo com partes em inglês e francês:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Habilitar ou suprimir a verificação ortográfica para partes individuais**

[PortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portionformat/) herda as propriedades de texto comuns definidas por [BasePortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/). Acesse o formato de uma parte através de [Portion::getPortionFormat](https://reference.aspose.com/slides/pt/php-java/aspose.slides/portion/#getPortionFormat) e use [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setSpellCheck) para controlar se um aplicativo de apresentação pode verificar a ortografia dessa parte. O valor padrão é `false`: `true` permite a verificação ortográfica, enquanto `false` a suprime.

A configuração se aplica a partes individuais de texto. Diferentes partes no mesmo parágrafo podem, portanto, usar valores diferentes. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) e `setSpellCheck` atendem a propósitos complementares: `setLanguageId` identifica o idioma de revisão, enquanto `setSpellCheck` determina se as verificações ortográficas são permitidas para a parte.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setProofDisabled) também controla a revisão, mas representa o estado mais amplo de "não revisar" como um [NullableBool](https://reference.aspose.com/slides/pt/php-java/aspose.slides/nullablebool/). Use `setSpellCheck` quando precisar de um interruptor Boolean direto especificamente para verificações ortográficas. Use `setProofDisabled` quando precisar preservar ou controlar explicitamente os metadados de não revisão da apresentação, incluindo seu estado `NotDefined`. Se definir ambas as propriedades, mantenha seus valores consistentes; não combine `setSpellCheck(true)` com `setProofDisabled(NullableBool::True)`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não os utiliza para executar verificação ortográfica baseada em dicionário ou para retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, carrega‑a, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a duas partes no mesmo parágrafo, salva o resultado, reabre‑o e verifica os valores armazenados:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) combina partes adjacentes que têm a mesma formatação. Uma diferença apenas em `SpellCheck` não mantém tais partes separadas; após a junção, a parte resultante retém o valor `SpellCheck` da primeira parte. Se as partes precisarem de diferentes configurações de verificação ortográfica, chame `joinPortionsWithSameFormatting` antes de atribuir essas configurações, ou inspecione os limites da parte resultante e reaplique as configurações posteriormente. Partes com valores diferentes de `LanguageId` permanecem separadas porque a formatação de idioma de revisão difere.

## **Perguntas frequentes**

**Um ID de idioma traduz o texto?**

Não. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) armazena metadados de revisão para ortografia e gramática; não altera o conteúdo do texto. Traduza o texto separadamente e, em seguida, defina o identificador de idioma apropriado para cada porção traduzida.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma destina‑se à revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/php-java/powerpoint-fonts/), do sistema de escrita e das configurações da caixa de texto. Para renderização confiável, forneça as fontes necessárias, configure a [font substitution](/slides/pt/php-java/font-substitution/) ou [embed fonts](/slides/pt/php-java/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a uma parte separada, como mostrado no exemplo de parágrafo multilíngue.

**Devo usar `setDefaultTextLanguage` ou `setLanguageId`?**

Use [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/pt/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) quando quiser um padrão para texto recém‑criado. Use [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/pt/php-java/aspose.slides/baseportionformat/#setLanguageId) quando uma parte específica precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.