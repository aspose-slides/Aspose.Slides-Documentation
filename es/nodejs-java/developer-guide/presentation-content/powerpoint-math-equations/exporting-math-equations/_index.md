---
title: Exportar ecuaciones matemáticas de presentaciones en JavaScript
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/nodejs-java/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- exportar ecuaciones a LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentación
- Node.js
- JavaScript
- Aspose.Slides
description: "Exportar ecuaciones matemáticas de presentaciones PowerPoint a LaTeX o MathML directamente con Aspose.Slides para Node.js vía Java."
---
## **Introducción**

Aspose.Slides le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación concreta) y utilizarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 

Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático usado en la web y en muchas aplicaciones.

{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se requiere un archivo intermedio MathML ni un conversor externo. Una ecuación matemática se almacena en un marco de texto como una [MathPortion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathportion/). Utilice [MathPortion.getMathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathportion/#getMathParagraph--) para obtener un [MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/), y a continuación llame a [MathParagraph.toLatex](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/#toLatex--). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar más adelante.

El siguiente ejemplo examina cada marco de texto en cada diapositiva, encuentra todas las porciones matemáticas y escribe cada ecuación en un archivo `.tex` independiente:

```javascript
const presentation = new aspose.slides.Presentation("equations.pptx");
try {
    const slideCount = presentation.getSlides().size();
    for (let slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        const slideNumber = slideIndex + 1;
        let equationNumber = 1;
        const textFrames = aspose.slides.SlideUtil.getAllTextBoxes(slide);

        for (const textFrame of textFrames) {
            const paragraphCount = textFrame.getParagraphs().getCount();
            for (let paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++) {
                const paragraph = textFrame.getParagraphs().get_Item(paragraphIndex);
                const portionCount = paragraph.getPortions().getCount();
                for (let portionIndex = 0; portionIndex < portionCount; portionIndex++) {
                    const portion = paragraph.getPortions().get_Item(portionIndex);
                    if (!java.instanceOf(portion, "com.aspose.slides.MathPortion")) {
                        continue;
                    }

                    const mathParagraph = portion.getMathParagraph();
                    const latexFileName = `slide_${slideNumber}_equation_${equationNumber}.tex`;

                    const latexText = mathParagraph.toLatex();
                    fileSystem.writeFileSync(latexFileName, latexText, "utf8");
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/slideutil/#getAllTextBoxes-aspose.slides.IBaseSlide-) devuelve todos los marcos de texto encontrados en una diapositiva. La comprobación de tipo [MathPortion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathportion/) separa las ecuaciones editables genuinas del texto e imágenes ordinarios.

Los motores de LaTeX y las plantillas de documento no admiten todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor LaTeX utilizado por su aplicación. Si un símbolo o elemento Office Math no tiene una representación adecuada en ese entorno, reemplácelo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos escriben fácilmente el código de algunos formatos de ecuación como LaTeX, les cuesta escribir el código de MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML sin problemas porque su código está en XML, por lo que MathML se usa habitualmente como formato de salida e impresión en muchos ámbitos. 

Este fragmento de código muestra cómo exportar una ecuación matemática de una presentación a MathML:

```javascript
var pres = new aspose.slides.Presentation();
try {
    var autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    var mathParagraph = autoShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph();
    mathParagraph.add(new aspose.slides.MathematicalText("a").setSuperscript("2").join("+").join(new aspose.slides.MathematicalText("b").setSuperscript("2")).join("=").join(new aspose.slides.MathematicalText("c").setSuperscript("2")));
    var stream = null;
    mathParagraph.writeAsMathMl(stream);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto normal o una imagen?**

Una fórmula vive en una [MathPortion](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/). Las imágenes y porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides.mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación apunta a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está muy extendido en aplicaciones y la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/es/nodejs-java/aspose.slides/mathparagraph/) (es decir, fórmulas genuinas de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no lo está.

**¿Exportar a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.