---
title: Automatizar a localização de apresentações em JavaScript
linktitle: Localização de apresentação
type: docs
weight: 100
url: /pt/nodejs-java/presentation-localization/
keywords:
- mudar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id de idioma
- texto multilíngue
- PowerPoint
- apresentação
- Node.js
- JavaScript
- Aspose.Slides
description: "Define idiomas de revisão para texto de apresentações PowerPoint e OpenDocument em JavaScript com Aspose.Slides, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides for Node.js via Java permite configurar metadados de revisão para trechos individuais de texto. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) para identificar o idioma de revisão, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) para permitir ou suprimir a verificação ortográfica e [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) para controlar o estado mais amplo de não‑revisão. Como essas configurações são aplicadas ao nível do trecho, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para novo texto com [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), criar parágrafos multilíngues, escolher entre `SpellCheck` e `ProofDisabled` e preservar as configurações desejadas ao usar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Essas propriedades armazenam metadados para aplicativos de apresentação; elas não traduzem texto, não realizam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/), acesse o trecho de texto desejado através de [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getPortionFormat--), e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o Inglês britânico como idioma de revisão e salva o resultado com [Presentation.save](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o idioma padrão para novo texto**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para especificar o idioma de revisão que o Aspose.Slides atribui ao texto recém‑criado. Essa configuração é útil quando a maior parte ou todo o novo texto em uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma de texto que já possui um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto usa regras de revisão em alemão:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usar vários idiomas em um parágrafo**

Um [Paragraph](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/paragraph/) contém uma coleção de trechos de texto. Crie um [Portion](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/) separado para cada idioma e defina seu `LanguageId` de forma independente.

Este exemplo cria um parágrafo com trechos em inglês e francês:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Habilitar ou suprimir a verificação ortográfica para trechos individuais**

[PortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portionformat/) herda as propriedades de texto comuns definidas por [BasePortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/). Acesse o formato de um trecho através de [Portion.getPortionFormat](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/portion/#getPortionFormat--) e use [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) para controlar se um aplicativo de apresentação pode verificar a ortografia desse trecho. O valor padrão é `false`: `true` permite a verificação ortográfica, enquanto `false` a suprime.

A configuração se aplica a trechos individuais de texto. Trechos diferentes no mesmo parágrafo podem, portanto, usar valores diferentes. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) e `setSpellCheck` têm propósitos complementares: `setLanguageId` identifica o idioma de revisão, enquanto `setSpellCheck` determina se a verificação ortográfica é permitida para o trecho.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) também controla a revisão, mas representa o estado mais amplo de "não revisar" como um [NullableBool](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/nullablebool/). Use `setSpellCheck` quando precisar de um interruptor Boolean direto especificamente para verificações ortográficas. Use `setProofDisabled` quando precisar preservar ou controlar explicitamente os metadados de não‑revisão da apresentação, incluindo seu estado `NotDefined`. Se definir ambas as propriedades, mantenha seus valores consistentes; não combine `setSpellCheck(true)` com `setProofDisabled(NullableBool.True)`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não as utiliza para executar verificações ortográficas baseadas em dicionário nem para retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, carrega‑a, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a dois trechos no mesmo parágrafo, salva o resultado, reabre‑o e verifica os valores armazenados:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina trechos adjacentes que possuem a mesma formatação. Uma diferença apenas em `SpellCheck` não mantém tais trechos separados; após a junção, o trecho resultante mantém o valor de `SpellCheck` do primeiro trecho. Se os trechos precisarem de configurações de verificação ortográfica diferentes, chame `joinPortionsWithSameFormatting` antes de atribuir essas configurações, ou inspecione os limites dos trechos resultantes e reaplique as configurações posteriormente. Trechos com valores diferentes de `LanguageId` permanecem separados porque a formatação do idioma de revisão difere.

## **Perguntas frequentes**

**Um ID de idioma traduz o texto?**

Não. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) armazena metadados de revisão para ortografia e gramática; não altera o conteúdo do texto. Traduza o texto separadamente e, em seguida, defina o identificador de idioma apropriado para cada trecho traduzido.

**O idioma de revisão controla fontes, hifenização ou quebra de linha?**

Não. O identificador de idioma serve para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/nodejs-java/powerpoint-fonts/) disponíveis, do sistema de escrita e das configurações da caixa de texto. Para uma renderização confiável, forneça as fontes necessárias, configure a [font substitution](/slides/pt/nodejs-java/font-substitution/) ou [embed fonts](/slides/pt/nodejs-java/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a um trecho separado, como mostrado no exemplo de parágrafo multilíngue.

**Devo usar `setDefaultTextLanguage` ou `setLanguageId`?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) quando desejar um padrão para texto recém‑criado. Use [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) quando um trecho específico precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.