---
title: Exportar ecuaciones matemáticas
type: docs
weight: 30
url: /es/nodejs-java/exporting-math-equations/
---

## **Exportar ecuaciones matemáticas de presentaciones**

Aspose.Slides for Node.js a través de Java le permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y usarlas en otro programa o plataforma.

{{% alert color="primary" %}} 
Puede exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 
{{% /alert %}}

Mientras que los humanos escriben fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se usa comúnmente como formato de salida e impresión en muchos campos. 

Este código de ejemplo le muestra cómo exportar una ecuación matemática de una presentación a MathML:
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


## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto regular o una imagen?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/). Las imágenes y las porciones de texto regular sin un [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación: es específico de PowerPoint o es un estándar?**

La exportación se dirige a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que se usa ampliamente en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/nodejs-java/aspose.slides/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no se exporta.

**¿Exportar a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.