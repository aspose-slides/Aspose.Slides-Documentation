---
title: Exportar ecuaciones matemáticas desde presentaciones en Android
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/androidjava/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- exportar ecuaciones a LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentación
- Android
- Java
- Aspose.Slides
description: "Exportar ecuaciones matemáticas desde presentaciones de PowerPoint a LaTeX o MathML directamente con Aspose.Slides for Android via Java."
---
## **Introducción**

Aspose.Slides for Android via Java le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma.

{{% alert color="primary" %}}
Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático usado en la web y en muchas aplicaciones.
{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se necesita un archivo intermedio de MathML ni un conversor externo. Una ecuación matemática se almacena en un marco de texto como un [IMathPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imathportion/). Utilice [IMathPortion.getMathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imathportion/#getMathParagraph--) para obtener un [IMathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imathparagraph/), y luego llame a [IMathParagraph.toLatex](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imathparagraph/#toLatex--). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar más adelante.

El siguiente ejemplo examina cada marco de texto en cada diapositiva, encuentra todas las porciones de matemáticas y escribe cada ecuación en un archivo `.tex` separado:

```java
Presentation presentation = new Presentation("equations.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int slideIndex = 0; slideIndex < slideCount; slideIndex++) {
        ISlide slide = presentation.getSlides().get_Item(slideIndex);
        int slideNumber = slideIndex + 1;
        int equationNumber = 1;
        ITextFrame[] textFrames = SlideUtil.getAllTextBoxes(slide);

        for (ITextFrame textFrame : textFrames) {
            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    if (!(portion instanceof IMathPortion))
                        continue;

                    IMathPortion mathPortion = (IMathPortion) portion;
                    IMathParagraph mathParagraph = mathPortion.getMathParagraph();
                    String latexFileName = "slide_" + slideNumber + "_equation_" + equationNumber + ".tex";

                    String latexText = mathParagraph.toLatex();
                    File latexFile = new File(latexFileName);
                    byte[] latexBytes = latexText.getBytes(StandardCharsets.UTF_8);
                    FileOutputStream outputStream = new FileOutputStream(latexFile);
                    try {
                        outputStream.write(latexBytes);
                    } finally {
                        outputStream.close();
                    }
                    equationNumber++;
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/slideutil/#getAllTextBoxes-com.aspose.slides.IBaseSlide-) devuelve todos los marcos de texto encontrados en una diapositiva. La verificación de tipo [IMathPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/imathportion/) separa las ecuaciones editables reales del texto e imágenes ordinarios.

Los motores de LaTeX y las plantillas de documentos no admiten todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor de LaTeX que utiliza su aplicación. Si un símbolo o elemento de Office Math no tiene una representación adecuada en ese entorno, reemplácelo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos escriben fácilmente el código de algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código de MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML con facilidad porque su código está en XML, por lo que MathML se usa habitualmente como formato de salida e impresión en muchos campos.

Este fragmento de código muestra cómo exportar una ecuación matemática de una presentación a MathML:

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

Puede exportar ya sea un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathparagraph/)) o un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto o una imagen regular?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathportion/) y posee un [MathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathparagraph/). Las imágenes y las porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación se dirige al estándar MathML (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está ampliamente usado en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/es/androidjava/com.aspose.slides/mathparagraph/) (es decir, fórmulas genuinas de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no lo está.

**¿Exportar a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.