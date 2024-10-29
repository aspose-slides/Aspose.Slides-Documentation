---
title: Exportando Ecuaciones Matemáticas
type: docs
weight: 30
url: /es/androidjava/exporting-math-equations/

---

## Exportando Ecuaciones Matemáticas de Presentaciones

Aspose.Slides para Android a través de Java te permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, es posible que necesites extraer las ecuaciones matemáticas en las diapositivas (de una presentación específica) y usarlas en otro programa o plataforma.

{{% alert color="primary" %}} 

Puedes exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones.

{{% /alert %}}

Mientras que los humanos escriben fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está diseñado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se utiliza comúnmente como un formato de salida e impresión en muchos campos.

Este código de muestra te muestra cómo exportar una ecuación matemática desde una presentación a MathML:

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