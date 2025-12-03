---
title: Exportar ecuaciones matemáticas desde presentaciones en Java
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/java/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- Java
- Aspose.Slides
description: "Desbloquee la exportación fluida de ecuaciones matemáticas de PowerPoint a MathML usando Aspose.Slides para Java—preserve el formato y mejore la compatibilidad."
---

## Exportar ecuaciones matemáticas desde presentaciones

Aspose.Slides for Java le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y usarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 
Puede exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 
{{% /alert %}}

Mientras que los humanos pueden escribir fácilmente el código para algunos formatos de ecuaciones como LaTeX, les resulta difícil escribir el código para MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas pueden leer y analizar MathML con facilidad porque su código está en XML, por lo que MathML se utiliza comúnmente como formato de salida e impresión en muchos campos. 

Este fragmento de código muestra cómo exportar una ecuación matemática desde una presentación a MathML:
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

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**  

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/java/com.aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.  

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto regular o una imagen?**  

Una fórmula vive en un [MathPortion](https://reference.aspose.com/slides/java/com.aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/). Las imágenes y los fragmentos de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) no son fórmulas exportables.  

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**  

La exportación se dirige a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está ampliamente usado en aplicaciones y en la web.  

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**  

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/java/com.aspose.slides/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.  

**¿La exportación a MathML modifica la presentación original?**  

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.