---
title: Automatizar a localização de apresentações no Android
linktitle: Localização de Apresentação
type: docs
weight: 100
url: /pt/androidjava/presentation-localization/
keywords:
- alterar idioma
- verificação ortográfica
- suprimir verificação ortográfica
- idioma de revisão
- id do idioma
- texto multilíngue
- PowerPoint
- apresentação
- Android
- Java
- Aspose.Slides
description: "Defina idiomas de revisão para textos de apresentações PowerPoint e OpenDocument no Android com Aspose.Slides para Android via Java, incluindo padrões e parágrafos multilíngues."
---
## **Visão geral**

Aspose.Slides para Android via Java permite configurar metadados de revisão para porções individuais de texto. Use [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para identificar o idioma de revisão, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) para permitir ou suprimir verificações ortográficas e [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) para controlar o estado mais amplo de “não provar”. Como essas configurações são aplicadas ao nível da porção, um parágrafo pode conter vários idiomas e diferentes regras de revisão.

Este artigo explica como atribuir um idioma a um texto específico, definir o idioma padrão para textos novos com [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), criar parágrafos multilíngues, escolher entre `SpellCheck` e `ProofDisabled` e preservar as configurações desejadas ao usar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Essas propriedades armazenam metadados para aplicativos de apresentação; elas não traduzem texto, não realizam verificação ortográfica baseada em dicionário nem retornam palavras incorretas.

## **Definir o idioma de revisão para o texto**

Crie ou carregue uma [Presentation](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/), acesse a porção de texto necessária através de [IPortion.getPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getPortionFormat--), e atribua seu identificador de idioma. O exemplo a seguir cria uma forma, define o inglês britânico como idioma de revisão e salva o resultado com [Presentation.save](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Definir o idioma padrão para novo texto**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para especificar o idioma de revisão que o Aspose.Slides atribui ao texto criado recentemente. Essa configuração é útil quando a maior parte ou todo o novo texto de uma apresentação usa o mesmo idioma. Ela não altera os metadados de idioma de textos que já possuam um idioma explícito.

O exemplo a seguir cria uma apresentação cujo novo texto usa as regras de revisão em alemão:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Usar vários idiomas em um parágrafo**

Um [IParagraph](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iparagraph/) contém uma coleção de porções de texto. Crie uma [Portion](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/portion/) separada para cada idioma e defina seu `LanguageId` de forma independente.

Este exemplo cria um parágrafo com porções em inglês e francês:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Habilitar ou suprimir a verificação ortográfica para porções individuais**

[IPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportionformat/) herda as propriedades comuns de texto definidas por [IBasePortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/). Acesse o formato de uma porção através de [IPortion.getPortionFormat](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/iportion/#getPortionFormat--) e use [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) para controlar se um aplicativo de apresentação pode verificar a ortografia dessa porção. O valor padrão é `false`: `true` permite a verificação ortográfica, enquanto `false` a suprime.

A configuração se aplica a porções de texto individuais. Porções diferentes no mesmo parágrafo podem, portanto, usar valores distintos. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) e `setSpellCheck` atendem a propósitos complementares: `setLanguageId` identifica o idioma de revisão, enquanto `setSpellCheck` determina se as verificações ortográficas são permitidas para a porção.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) também controla a revisão, mas representa o estado mais amplo de “não provar” como um [NullableBool](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/nullablebool/). Use `setSpellCheck` quando precisar de um interruptor booleano direto especificamente para verificações ortográficas. Use `setProofDisabled` quando precisar preservar ou controlar explicitamente os metadados de “não provar” da apresentação, inclusive seu estado `NotDefined`. Se definir ambas as propriedades, mantenha seus valores consistentes; não combine `setSpellCheck(true)` com `setProofDisabled(NullableBool.True)`.

Essas propriedades configuram metadados de revisão usados pelo PowerPoint e outros aplicativos de apresentação. O Aspose.Slides não os utiliza para executar verificações ortográficas baseadas em dicionário nem para retornar uma lista de palavras incorretas.

O exemplo completo a seguir cria uma apresentação de entrada, a carrega, atribui diferentes configurações de verificação ortográfica e idiomas de revisão a duas porções no mesmo parágrafo, salva o resultado, reabre-o e verifica os valores armazenados:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 &&
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) &&
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 &&
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) &&
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina porções adjacentes que possuem a mesma formatação. Uma diferença apenas em `SpellCheck` não impede que tais porções sejam unidas; após a união, a porção resultante retém o valor de `SpellCheck` da primeira porção. Se as porções precisarem de configurações de verificação ortográfica diferentes, chame `joinPortionsWithSameFormatting` antes de atribuir essas configurações, ou inspecione os limites das porções resultantes e reaplique as configurações posteriormente. Porções com valores diferentes de `LanguageId` permanecem separadas porque a formatação de idioma de revisão difere.

## **FAQ**

**Um ID de idioma traduz o texto?**

Não. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) armazena metadados de revisão para ortografia e gramática; ele não altera o conteúdo do texto. Traduza o texto separadamente e, em seguida, defina o identificador de idioma apropriado para cada porção traduzida.

**O idioma de revisão controla fontes, hifenização ou quebras de linha?**

Não. O identificador de idioma serve apenas para revisão. A renderização e o layout do texto dependem principalmente das [fonts](/slides/pt/androidjava/powerpoint-fonts/), do sistema de escrita e das configurações da caixa de texto. Para renderização confiável, forneça as fontes necessárias, configure a [substituição de fontes](/slides/pt/androidjava/font-substitution/) ou [incorpore fontes](/slides/pt/androidjava/embedded-font/) na apresentação.

**Um parágrafo pode usar vários idiomas de revisão?**

Sim. Atribua cada idioma a uma porção separada, como demonstrado no exemplo de parágrafo multilíngue.

**Devo usar `setDefaultTextLanguage` ou `setLanguageId`?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) quando quiser um padrão para textos recém‑criados. Use [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/pt/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) quando uma porção específica precisar de um idioma de revisão explícito ou quando um parágrafo contiver vários idiomas.