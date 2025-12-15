---
title: Exportar ecuaciones matemáticas desde presentaciones en Android
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/androidjava/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Exporta sin problemas ecuaciones matemáticas de PowerPoint a MathML usando Aspose.Slides para Android vía Java, conservando el formato y mejorando la compatibilidad."
---

## **Exportar ecuaciones matemáticas desde presentaciones**

Aspose.Slides for Android a través de Java le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas en diapositivas (de una presentación específica) y usarlas en otro programa o plataforma.

{{% alert color="primary" %}} 
Puede exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 
{{% /alert %}}

Mientras los humanos pueden escribir fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está destinado a generarse automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se usa comúnmente como formato de salida e impresión en muchos campos. 

Este código de ejemplo le muestra cómo exportar una ecuación matemática de una presentación a MathML:
```java
Presentation pres = new Presentation();
try {
    IAutoShape autoShape = pres.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50);
    IMathParagraph mathParagraph = ((MathPortion)autoShape.getTextFrame().getParagraphs().get_Item(0).
            getPortions().get_Item(0)).getMathParagraph();

    mathParagraph.add(new MathematicalText("a").
            setSuperscript("2").
            join("+").
            join(new MathematicalText("b").setSuperscript("2")).
            join("=").
            join(new MathematicalText("c").setSuperscript("2")));

    FileOutputStream stream = new FileOutputStream("mathml.xml");
    mathParagraph.writeAsMathMl(stream);
} catch (IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar ya sea un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/)) o un bloque individual ([MathBlock](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto o una imagen normal?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/). Las imágenes y porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación—es específico de PowerPoint o es un estándar?**

La exportación se dirige al MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que se usa ampliamente en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/androidjava/com.aspose.slides/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.