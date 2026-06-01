---
title: Extracción avanzada de texto de presentaciones en Android
linktitle: Extraer texto
type: docs
weight: 90
url: /es/androidjava/extract-text-from-presentation/
keywords:
- extraer texto
- extraer texto de diapositiva
- extraer texto de presentación
- extraer texto de PowerPoint
- extraer texto de OpenDocument
- extraer texto de PPT
- extraer texto de PPTX
- extraer texto de ODP
- recuperar texto
- recuperar texto de diapositiva
- recuperar texto de presentación
- recuperar texto de PowerPoint
- recuperar texto de OpenDocument
- recuperar texto de PPT
- recuperar texto de PPTX
- recuperar texto de ODP
- PowerPoint
- OpenDocument
- presentación
- Android
- Java
- Aspose.Slides
description: "Extrae texto rápidamente de presentaciones de PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Sigue nuestra guía simple, paso a paso, para ahorrar tiempo."
---
## **Visión general**

Extraer texto de presentaciones es una tarea habitual pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés manejando archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y obtener datos textuales puede ser fundamental para análisis, automatización, indexación o migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, utilizando Aspose.Slides para Android mediante Java. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para recuperar con precisión el contenido textual que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides para Android mediante Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [getAllTextBoxes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Este método acepta como parámetro un objeto del tipo [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/). Al ejecutarse, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), conservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```java
int slideIndex = 0;

Presentation presentation = new Presentation("demo.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(slideIndex);

    ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, utiliza el método estático [getAllTextFrames](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/). Acepta dos parámetros:

1. En primer lugar, un objeto [IPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/) que representa una presentación de PowerPoint u OpenDocument de la que se extraerá el texto.  
2. En segundo lugar, un valor `boolean` que indica si se deben incluir las diapositivas maestras al escanear el texto de la presentación.

El método devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), incluyendo la información de formato del texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

```java
Presentation presentation = new Presentation("demo.pptx");
try {
    boolean includeMasterSlides = true;
    ITextFrame[] textFrames = SlideUtil.getAllTextFrames(presentation, includeMasterSlides);

    for (ITextFrame textFrame : textFrames) {
        for (IParagraph paragraph : textFrame.getParagraphs()) {
            for (IPortion portion : paragraph.getPortions()) {
                String portionText = portion.getText();
                System.out.println(portionText);

                IPortionFormat portionFormat = portion.getPortionFormat();
                float fontHeight = portionFormat.getFontHeight();
                System.out.println(fontHeight);

                IFontData latinFont = portionFormat.getLatinFont();
                if (latinFont != null) {
                    String fontName = latinFont.getFontName();
                    System.out.println(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extracción de texto categorizada y rápida**

La clase [PresentationFactory](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/) también ofrece métodos para extraer todo el texto de presentaciones:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

El argumento enum [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textextractionarrangingmode/) indica el modo de organización del resultado de la extracción de texto y puede establecerse en los siguientes valores:
- `Unarranged` - El texto sin procesar, sin tener en cuenta su posición en la diapositiva.  
- `Arranged` - El texto está organizado en el mismo orden que aparece en la diapositiva.

El modo `Unarranged` puede usarse cuando la velocidad es crítica; es más rápido que el modo `Arranged`.

[IPresentationText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentationtext/) representa el texto bruto extraído de la presentación. Su método `getSlidesText` devuelve una matriz de objetos del tipo [ISlideText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidetext/). Cada objeto representa el texto de la diapositiva correspondiente. El objeto del tipo [ISlideText](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/islidetext/) dispone de los siguientes métodos:

- `getText` - El texto dentro de las formas de la diapositiva.  
- `getMasterText` - El texto dentro de las formas de la diapositiva maestra asociada a esta diapositiva.  
- `getLayoutText` - El texto dentro de las formas de la diapositiva de diseño asociada a esta diapositiva.  
- `getNotesText` - El texto dentro de las formas de la diapositiva de notas asociada a esta diapositiva.  
- `getCommentsText` - El texto dentro de los comentarios asociados a esta diapositiva.

```java
String presentationPath = "presentation.pptx";
int arrangingMode = TextExtractionArrangingMode.Unarranged;
IPresentationText presentationText = PresentationFactory.getInstance().getPresentationText(presentationPath, arrangingMode);
ISlideText firstSlideText = presentationText.getSlidesText()[0];

System.out.println(firstSlideText.getText());
System.out.println(firstSlideText.getLayoutText());
System.out.println(firstSlideText.getMasterText());
System.out.println(firstSlideText.getNotesText());
System.out.println(firstSlideText.getCommentsText());
```

## **FAQ**

**¿Qué velocidad tiene Aspose.Slides al procesar presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para un alto rendimiento y puede procesar incluso [presentaciones grandes](/slides/es/androidjava/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de las presentaciones?**

Sí. Aspose.Slides puede extraer texto de muchos elementos de diapositivas, incluidas tablas y objetos relacionados con gráficos, para que puedas acceder y analizar el contenido textual en estructuras de presentación habituales.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puedes extraer texto utilizando la versión de prueba gratuita de Aspose.Slides, aunque tendrá [ciertas limitaciones](/slides/es/androidjava/licensing/), como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones de mayor tamaño, se recomienda adquirir una licencia completa.