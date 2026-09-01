---
title: Automatizar la localización de presentaciones en Android
linktitle: Localización de presentaciones
type: docs
weight: 100
url: /es/androidjava/presentation-localization/
keywords:
- cambiar idioma
- corrección ortográfica
- suprimir corrección ortográfica
- idioma de corrección
- identificador de idioma
- texto multilingüe
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Establecer idiomas de corrección para el texto de presentaciones PowerPoint y OpenDocument en Android con Aspose.Slides for Android vía Java, incluidos los valores predeterminados y los párrafos multilingües."
---
## **Descripción general**

Aspose.Slides for Android vía Java le permite configurar los metadatos de corrección para porciones de texto individuales. Utilice [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) para identificar el idioma de corrección, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) para permitir o suprimir la verificación ortográfica, y [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) para controlar el estado más amplio de “no corregir”. Dado que estas configuraciones se aplican a nivel de porción, un párrafo puede contener varios idiomas y diferentes reglas de corrección.

Este artículo explica cómo asignar un idioma a un texto específico, establecer el idioma predeterminado para texto nuevo con [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), crear párrafos multilingües, elegir entre `SpellCheck` y `ProofDisabled`, y conservar la configuración prevista al usar [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Estas propiedades almacenan metadatos para aplicaciones de presentación; no traducen el texto, no realizan comprobaciones ortográficas basadas en diccionario ni devuelven palabras mal escritas.

## **Establecer el idioma de corrección para el texto**

Cree o cargue una [Presentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/), acceda a la porción de texto requerida mediante [IPortion.getPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/#getPortionFormat--), y asigne su identificador de idioma. El siguiente ejemplo crea una forma, establece el inglés británico como idioma de corrección y guarda el resultado con [Presentation.save](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-):

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

## **Establecer el idioma predeterminado para texto nuevo**

Utilice [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) para especificar el idioma de corrección que Aspose.Slides asigna al texto creado recientemente. Esta configuración es útil cuando la mayor parte o todo el texto nuevo en una presentación utiliza el mismo idioma. No cambia los metadatos de idioma del texto que ya tiene un idioma explícito.

El siguiente ejemplo crea una presentación cuyo texto nuevo utiliza reglas de corrección en alemán:

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

## **Usar varios idiomas en un mismo párrafo**

Un [IParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iparagraph/) contiene una colección de porciones de texto. Cree una [Portion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/portion/) separada para cada idioma y establezca su `LanguageId` de forma independiente.

Este ejemplo crea un párrafo con porciones en inglés y francés:

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

## **Activar o suprimir la comprobación ortográfica para porciones individuales**

[IPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportionformat/) hereda las propiedades de texto comunes definidas por [IBasePortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/). Acceda al formato de una porción mediante [IPortion.getPortionFormat](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/iportion/#getPortionFormat--) y utilice [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) para controlar si una aplicación de presentación puede verificar la ortografía de esa porción. El valor predeterminado es `false`: `true` permite la verificación ortográfica, mientras que `false` la suprime.

La configuración se aplica a porciones de texto individuales. Por tanto, diferentes porciones en el mismo párrafo pueden usar valores distintos. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) y `setSpellCheck` cumplen propósitos complementarios: `setLanguageId` identifica el idioma de corrección, mientras que `setSpellCheck` determina si se permiten las comprobaciones ortográficas para la porción.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) también controla la corrección, pero representa el estado más amplio de “no corregir” como un [NullableBool](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/nullablebool/). Use `setSpellCheck` cuando necesite un interruptor booleano directo específicamente para verificaciones ortográficas. Use `setProofDisabled` cuando necesite preservar o controlar explícitamente los metadatos de “no corrección” de la presentación, incluido su estado `NotDefined`. Si establece ambas propiedades, mantenga sus valores consistentes; no combine `setSpellCheck(true)` con `setProofDisabled(NullableBool.True)`.

Estas propiedades configuran los metadatos de corrección utilizados por PowerPoint y otras aplicaciones de presentación. Aspose.Slides no los usa para ejecutar comprobaciones ortográficas basadas en diccionario ni para devolver una lista de palabras mal escritas.

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) combina porciones adyacentes que tienen el mismo formato. Una diferencia únicamente en `SpellCheck` no mantiene esas porciones separadas; después de unirlas, la porción resultante conserva el valor `SpellCheck` de la primera porción. Si las porciones necesitan configuraciones de verificación ortográfica diferentes, llame a `joinPortionsWithSameFormatting` antes de asignar esas configuraciones, o inspeccione los límites de la porción resultante y vuelva a aplicar las configuraciones posteriormente. Las porciones con valores de `LanguageId` diferentes permanecen separadas porque su formato de idioma de corrección difiere.

## **Preguntas frecuentes**

**¿Un identificador de idioma traduce el texto?**

No. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) almacena metadatos de corrección para ortografía y gramática; no altera el contenido del texto. Traduzca el texto por separado y, a continuación, establezca el identificador de idioma apropiado para cada porción traducida.

**¿El idioma de corrección controla fuentes, guiones o ajuste de línea?**

No. El identificador de idioma es solo para corrección. La representación y el diseño del texto dependen principalmente de las [fuentes](/slides/es/androidjava/powerpoint-fonts/), del sistema de escritura y de la configuración del marco de texto. Para un renderizado fiable, proporcione las fuentes necesarias, configure la [sustitución de fuentes](/slides/es/androidjava/font-substitution/) o [incorpore fuentes](/slides/es/androidjava/embedded-font/) en la presentación.

**¿Puede un párrafo usar varios idiomas de corrección?**

Sí. Asigne cada idioma a una porción separada, como se muestra en el ejemplo del párrafo multilingüe.

**¿Debería usar `setDefaultTextLanguage` o `setLanguageId`?**

Use [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) cuando desee un valor predeterminado para el texto creado recientemente. Use [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) cuando una porción específica necesite un idioma de corrección explícito o cuando un párrafo contenga varios idiomas.