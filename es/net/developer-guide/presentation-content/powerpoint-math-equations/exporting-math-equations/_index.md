---
title: Exportando Ecuaciones Matemáticas
type: docs
weight: 30
url: /es/net/exporting-math-equations/
keywords: "Exportar ecuaciones matemáticas, presentación de PowerPoint, C#, Csharp, Aspose.Slides para .NET"
description: "Exportar ecuaciones matemáticas de PowerPoint en C# o .NET"
---

Aspose.Slides para .NET te permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede que necesites extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma.

{{% alert color="primary" %}} 

Puedes exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar visto en la web y en muchas aplicaciones.

{{% /alert %}}

Mientras que los humanos escriben fácilmente el código para algunos formatos de ecuaciones como LaTeX, luchan por escribir el código para MathML porque este último está destinado a ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se utiliza comúnmente como formato de salida e impresión en muchos campos.

Este código de ejemplo te muestra cómo exportar una ecuación matemática de una presentación a MathML:

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```