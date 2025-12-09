---
title: Extracción avanzada de texto de presentaciones en Java
linktitle: Extraer texto
type: docs
weight: 90
url: /es/java/extract-text-from-presentation/
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
- Java
- Aspose.Slides
description: "Extraiga texto rápidamente de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Java. Siga nuestra guía simple, paso a paso, para ahorrar tiempo."
---

{{% alert color="primary" %}} 

No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX usando Aspose.Slides. 

{{% /alert %}} 
## **Extraer texto de diapositivas**
Aspose.Slides para Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Esta clase expone una serie de métodos estáticos sobrescritos para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, use el método estático sobrescrito [getAllTextBoxes](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextBoxes-com.aspose.slides.IBaseSlide-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil). Este método acepta el objeto Slide como parámetro.
Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame). Esto significa que cualquier formato de texto asociado está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
```java
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    for (ISlide slide : pres.getSlides()) 
    {
        //Obtener una matriz de objetos ITextFrame de todas las diapositivas en el PPTX
        ITextFrame[] textFramesPPTX = SlideUtil.getAllTextBoxes(slide);

        //Recorrer la matriz de TextFrames
        for (int i = 0; i < textFramesPPTX.length; i++) {
            //Recorrer los párrafos en el ITextFrame actual
            for (IParagraph para : textFramesPPTX[i].getParagraphs()) {
                //Recorrer las porciones en el IParagraph actual
                for (IPortion port : para.getPortions()) {
                    //Mostrar el texto en la porción actual
                    System.out.println(port.getText());

                    //Mostrar la altura de fuente del texto
                    System.out.println(port.getPortionFormat().getFontHeight());

                    //Mostrar el nombre de fuente del texto
                    if (port.getPortionFormat().getLatinFont() != null)
                        System.out.println(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Extraer texto de presentaciones**
Para escanear el texto de toda la presentación, use el método estático [getAllTextFrames](https://reference.aspose.com/slides/java/com.aspose.slides/SlideUtil#getAllTextFrames-com.aspose.slides.IPresentation-boolean-) expuesto por la clase SlideUtil. Toma dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) que representa la presentación de la cual se extrae el texto.
2. Segundo, un valor booleano que determina si la diapositiva maestra debe incluirse al escanear el texto de la presentación.
   El método devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/TextFrame), completa con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.
```java
//Instanciar la clase Presentation que representa un archivo PPTX
Presentation pres = new Presentation("demo.pptx");
try {
    //Obtener una matriz de objetos ITextFrame de todas las diapositivas en el PPTX
    ITextFrame[] textFramesPPTX = SlideUtil.getAllTextFrames(pres, true);

    //Recorrer la matriz de TextFrames
    for (int i = 0; i < textFramesPPTX.length; i++) 
    {
        //Recorrer los párrafos en el ITextFrame actual
        for (IParagraph para : textFramesPPTX[i].getParagraphs())
        {
            //Recorrer las porciones en el IParagraph actual
            for (IPortion port : para.getPortions())
            {
                //Mostrar el texto en la porción actual
                System.out.println(port.getText());

                //Mostrar la altura de la fuente del texto
                System.out.println(port.getPortionFormat().getFontHeight());

                //Mostrar el nombre de la fuente del texto
                if (port.getPortionFormat().getLatinFont() != null)
                    System.out.println(port.getPortionFormat().getLatinFont().getFontName());
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Extracción de texto categorizada y rápida**
El nuevo método estático getPresentationText se ha añadido a la clase Presentation. Hay tres sobrecargas para este método:
```java
public IPresentationText getPresentationText(String file, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode);
public IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/java/com.aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[IPresentationText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/java/com.aspose.slides/IPresentationText#getSlidesText--) method which returns an array of [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) objects. Every object represent the text on the corresponding slide. [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) object have the following methods:

- [ISlideText.getText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getText--) - The text on the slide's shapes
- [ISlideText.getMasterText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getMasterText--) - The text on the master page's shapes for this slide
- [ISlideText.getLayoutText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getLayoutText--) - The text on the layout page's shapes for this slide
- [ISlideText.getNotesText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText#getNotesText--) - The text on the notes page's shapes for this slide

There is also a [SlideText](https://reference.aspose.com/slides/java/com.aspose.slides/SlideText) class which implements the [ISlideText](https://reference.aspose.com/slides/java/com.aspose.slides/ISlideText) interface.

The new API can be used like this:

```java
IPresentationText text1 = PresentationFactory.getInstance().getPresentationText("presentation.pptx", TextExtractionArrangingMode.Unarranged);
System.out.println(text1.getSlidesText()[0].getText());
System.out.println(text1.getSlidesText()[0].getLayoutText());
System.out.println(text1.getSlidesText()[0].getMasterText());
System.out.println(text1.getSlidesText()[0].getNotesText());
```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa de manera eficiente incluso [presentaciones grandes](/slides/es/java/open-presentation/), lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí, Aspose.Slides admite completamente la extracción de texto de tablas, gráficos y otros elementos complejos de diapositivas, lo que le permite acceder y analizar todo el contenido textual fácilmente.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá ciertas limitaciones, como procesar solo un número limitado de diapositivas. Para un uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.