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
description: "Extrae rápidamente texto de presentaciones PowerPoint y OpenDocument usando Aspose.Slides for Node.js via Java. Sigue nuestra guía sencilla paso a paso para ahorrar tiempo."
---
## **Descripción general**

Extraer texto de presentaciones es una tarea común pero esencial para los desarrolladores que trabajan con contenido de diapositivas. Ya sea que estés tratando con archivos de Microsoft PowerPoint en formato PPT o PPTX, o presentaciones OpenDocument (ODP), acceder y recuperar datos textuales puede ser crítico para análisis, automatización, indexación o propósitos de migración de contenido.

Este artículo ofrece una guía completa sobre cómo extraer texto de forma eficiente de varios formatos de presentación, incluidos PPT, PPTX y ODP, utilizando Aspose.Slides for Node.js via Java. Aprenderás a iterar sistemáticamente a través de los elementos de la presentación para recuperar con precisión el contenido textual que necesitas.

## **Extraer texto de una diapositiva**

Aspose.Slides for Node.js via Java proporciona la clase [SlideUtil](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/). Esta clase expone varios métodos estáticos sobrecargados para extraer todo el texto de una presentación o diapositiva. Para extraer texto de una diapositiva en una presentación, utiliza el método [getAllTextBoxes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) . Este método acepta como parámetro un objeto diapositiva. Cuando se ejecuta, el método escanea toda la diapositiva en busca de texto y devuelve una matriz de objetos [TextFrame](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/textframe/), preservando cualquier formato de texto.

El siguiente fragmento de código extrae todo el texto de la primera diapositiva de la presentación:

```javascript
const slideIndex = 0;

const presentation = new aspose.slides.Presentation("demo.pptx");
try {
    const slide = presentation.getSlides().get_Item(slideIndex);

    const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

    for (let textFrameIndex = 0; textFrameIndex < textFrames.length; textFrameIndex++) {
        const textFrame = textFrames[textFrameIndex];

        const paragraphs = textFrame.getParagraphs();
        const paragraphCount = paragraphs.getCount();
        for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
            const paragraph = paragraphs.get_Item(paragraphIndex);

            const portions = paragraph.getPortions();
            const portionCount = portions.getCount();
            for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                const portion = portions.get_Item(portionIndex);

                const portionText = portion.getText();
                console.log(portionText);

                const portionFormat = portion.getPortionFormat();
                const fontHeight = portionFormat.getFontHeight();
                console.log(fontHeight);

                const latinFont = portionFormat.getLatinFont();
                if (latinFont !== null) {
                    const fontName = latinFont.getFontName();
                    console.log(fontName);
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Extraer texto de una presentación**

Para escanear texto de toda la presentación, utiliza el método estático