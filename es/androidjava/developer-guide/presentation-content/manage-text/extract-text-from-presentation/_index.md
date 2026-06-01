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
description: "Extrae rápidamente texto de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Android mediante Java. Sigue nuestra sencilla guía paso a paso para ahorrar tiempo."
---
## **Visión general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés manejando archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser crítico para análisis, automatización, indexación o propósitos de migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluyendo PPT, PPTX y ODP, usando Aspose.Slides for Android via Java. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para recuperar con precisión el contenido de texto que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides for Android via Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [getAllTextBoxes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) . Este método acepta un objeto del tipo [IBaseSlide](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ibaseslide/) como parámetro. Al ejecutarse, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), conservando cualquier formato de texto.

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

1. Primero, un objeto [IPresentation](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/ipresentation/) que representa una presentación PowerPoint o OpenDocument de la cual se extraerá el texto.  
2. Segundo, un valor `boolean` que indica si las diapositivas maestras deben incluirse al escanear texto de la presentación.

El método devuelve una matriz de objetos del tipo [ITextFrame](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/itextframe/), incluyendo información de formato de texto. El código a continuación escanea el texto y los detalles de formato de una presentación, incluidas las diapositivas maestras.

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

La clase [PresentationFactory](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/presentationfactory/) también proporciona métodos para extraer todo el texto de presentaciones:

```text
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
```

El argumento del enumerado [TextExtractionArrangingMode](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/textex