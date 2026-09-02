---
title: Exportar ecuaciones matemáticas desde presentaciones en .NET
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/net/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- exportar ecuaciones a LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentación
- .NET
- C#
- Aspose.Slides
description: "Exportar ecuaciones matemáticas desde presentaciones PowerPoint a LaTeX o MathML directamente con Aspose.Slides para .NET."
---
## **Introducción**

Aspose.Slides para .NET le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 

Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático usado en la web y en muchas aplicaciones.

{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se requiere un archivo intermedio de MathML ni un conversor externo. Una ecuación matemática se almacena en un marco de texto como una [MathPortion](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathportion/). Use [MathPortion.MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathportion/mathparagraph/) para obtener un [IMathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathparagraph/), y luego llame a [IMathParagraph.ToLatex](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/imathparagraph/tolatex/). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar más adelante.

El siguiente ejemplo examina cada marco de texto en cada diapositiva, encuentra todas las porciones matemáticas y escribe cada ecuación en un archivo `.tex` separado:

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/es/net/aspose.slides.util/slideutil/getalltextboxes/) devuelve todos los marcos de texto encontrados en una diapositiva. La comprobación de tipo [MathPortion](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathportion/) separa las ecuaciones editables genuinas del texto e imágenes ordinarios.

Los motores de LaTeX y las plantillas de documento no admiten todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor de LaTeX usado por su aplicación. Si un símbolo o elemento de Office Math no tiene una representación adecuada en ese entorno, sustitúyalo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos escriben fácilmente el código de algunos formatos de ecuación como LaTeX, les cuesta escribir el código de MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML sin problemas porque su código está en XML, por lo que MathML se usa habitualmente como formato de salida e impresión en muchos campos. 

Este código de ejemplo le muestra cómo exportar una ecuación matemática de una presentación a MathML:

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

## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto normal o una imagen?**

Una fórmula vive en una [MathPortion](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathparagraph/). Las imágenes y las porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación tiene como objetivo MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está ampliamente usado en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/es/net/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas genuinas de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.