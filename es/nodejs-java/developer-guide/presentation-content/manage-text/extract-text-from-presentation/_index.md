---
title: Extracción avanzada de texto de presentaciones en JavaScript
linktitle: Extraer texto
type: docs
weight: 90
url: /es/nodejs-java/extract-text-from-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Extrae rápidamente texto de presentaciones PowerPoint y OpenDocument usando Aspose.Slides para Node.js. Sigue nuestra guía sencilla, paso a paso, para ahorrar tiempo."
---

{{% alert color="primary" %}} 
No es raro que los desarrolladores necesiten extraer el texto de una presentación. Para hacerlo, es necesario extraer el texto de todas las formas en todas las diapositivas de una presentación. Este artículo explica cómo extraer texto de presentaciones Microsoft PowerPoint PPTX usando Aspose.Slides. 
{{% /alert %}} 

## **Extraer texto de la diapositiva**

Aspose.Slides para Node.js a través de Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer el texto de una diapositiva en una presentación PPTX, utilice el método estático sobrecargado [getAllTextBoxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextBoxes-aspose.slides.IBaseSlide-) expuesto por la clase [SlideUtil](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil). Este método acepta el objeto Slide como parámetro. Al ejecutarse, el método Slide escanea todo el texto de la diapositiva pasada como parámetro y devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) . Esto significa que cualquier formato de texto asociado está disponible. El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:
```javascript
// Instanciar la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    for (var s = 0; s < pres.getSlides().size(); s++) {
        let slide = pres.getSlides().get_Item(s);
        // Obtener una matriz de objetos ITextFrame de todas las diapositivas del PPTX
        var textFramesPPTX = aspose.slides.SlideUtil.getAllTextBoxes(slide);
        // Recorrer la matriz de TextFrames
        for (var i = 0; i < textFramesPPTX.length; i++) {
            // Recorrer los párrafos del ITextFrame actual
            for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
                let para = textFramesPPTX[i].getParagraphs().get_Item(j);
                // Recorrer las porciones del IParagraph actual
                for (let k = 0; k < para.getPortions().getCount(); k++) {
                    let port = para.getPortions().get_Item(k);
                    // Mostrar el texto de la porción actual
                    console.log(port.getText());
                    // Mostrar la altura de fuente del texto
                    console.log(port.getPortionFormat().getFontHeight());
                    // Mostrar el nombre de fuente del texto
                    if (port.getPortionFormat().getLatinFont() != null) {
                        console.log(port.getPortionFormat().getLatinFont().getFontName());
                    }
                });
            }
        }
    });
} finally {
    pres.dispose();
}
```


## **Extraer texto de la presentación**

Para escanear el texto de toda la presentación, utilice el método estático [getAllTextFrames](https://reference.aspose.com/slides/nodejs-java/aspose.slides/SlideUtil#getAllTextFrames-aspose.slides.IPresentation-boolean-) expuesto por la clase SlideUtil. Acepta dos parámetros:

1. Primero, un objeto [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) que representa la presentación de la cual se extrae el texto.
2. Segundo, un valor booleano que determina si la diapositiva maestra debe incluirse al escanear el texto de la presentación.  
   El método devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame) completos con información de formato de texto. El código a continuación escanea el texto y la información de formato de una presentación, incluidas las diapositivas maestras.
```javascript
// Instanciar la clase Presentation que representa un archivo PPTX
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    // Obtener una matriz de objetos ITextFrame de todas las diapositivas del PPTX
    var textFramesPPTX = aspose.slides.SlideUtil.getAllTextFrames(pres, true);
    // Recorrer la matriz de TextFrames
    for (var i = 0; i < textFramesPPTX.length; i++) {
        // Recorrer los párrafos del ITextFrame actual
        for (let j = 0; j < textFramesPPTX[i].getParagraphs().getCount(); j++) {
            let para = textFramesPPTX[i].getParagraphs().get_Item(j);
            // Recorrer las porciones del IParagraph actual
            for (let k = 0; k < para.getPortions().getCount(); k++) {
                let port = para.getPortions().get_Item(k);
                // Mostrar el texto de la porción actual
                console.log(port.getText());
                // Mostrar la altura de fuente del texto
                console.log(port.getPortionFormat().getFontHeight());
                // Mostrar el nombre de fuente del texto
                if (port.getPortionFormat().getLatinFont() != null) {
                    console.log(port.getPortionFormat().getLatinFont().getFontName());
                }
            }
        }
    }
} finally {
    pres.dispose();
}
```


## **Extracción de texto categorizada y rápida**

Se ha añadido el nuevo método estático getPresentationText a la clase Presentation. Existen tres sobrecargas para este método:
```javascript
IPresentationText getPresentationText(String file, int mode);
IPresentationText getPresentationText(InputStream stream, int mode);
IPresentationText getPresentationText(InputStream stream, int mode, ILoadOptions options);
``` 

The [TextExtractionArrangingMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode) enum argument indicates the mode to organize the output of text result and can be set to the following values:
- [Unarranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Unarranged) - The raw text with no respect to position on the slide
- [Arranged](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextExtractionArrangingMode#Arranged) - The text is positioned in the same order as on the slide

**Unarranged** mode can be used when speed is critical, it's faster than Arranged mode.

[PresentationText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText) represents the raw text extracted from the presentation. It contains a [getSlidesText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PresentationText#getSlidesText--) method which returns an array of `SlideText` objects. Every object represent the text on the corresponding slide. `SlideText` object have the following methods:

- `SlideText.getText` - The text on the slide's shapes
- `SlideText.getMasterText` - The text on the master page's shapes for this slide
- `SlideText.getLayoutText` - The text on the layout page's shapes for this slide
- `SlideText.getNotesText` - The text on the notes page's shapes for this slide

There is also a `SlideText` class which implements the `SlideText` class.

The new API can be used like this:

```javascript
var text1 = aspose.slides.PresentationFactory.getInstance().getPresentationText("presentation.pptx", aspose.slides.TextExtractionArrangingMode.Unarranged);
console.log(text1.getSlidesText()[0].getText());
console.log(text1.getSlidesText()[0].getLayoutText());
console.log(text1.getSlidesText()[0].getMasterText());
console.log(text1.getSlidesText()[0].getNotesText());
```


## **Preguntas frecuentes**

**¿Qué tan rápido procesa Aspose.Slides presentaciones grandes durante la extracción de texto?**

Aspose.Slides está optimizado para alto rendimiento y procesa de manera eficiente incluso presentaciones grandes, lo que lo hace adecuado para escenarios de procesamiento en tiempo real o por lotes.

**¿Puede Aspose.Slides extraer texto de tablas y gráficos dentro de presentaciones?**

Sí, Aspose.Slides admite totalmente la extracción de texto de tablas, gráficos y otros elementos complejos de diapositivas, lo que le permite acceder y analizar fácilmente todo el contenido textual.

**¿Necesito una licencia especial de Aspose.Slides para extraer texto de presentaciones?**

Puede extraer texto usando la versión de prueba gratuita de Aspose.Slides, aunque tendrá ciertas limitaciones, como procesar solo un número limitado de diapositivas. Para uso sin restricciones y para manejar presentaciones más grandes, se recomienda adquirir una licencia completa.