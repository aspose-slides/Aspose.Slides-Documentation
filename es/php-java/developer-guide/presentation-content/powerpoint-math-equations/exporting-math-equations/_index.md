---
title: Exportar ecuaciones matemáticas desde presentaciones en PHP
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/php-java/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Desbloquee una exportación sin problemas de ecuaciones matemáticas desde PowerPoint a MathML usando Aspose.Slides para PHP a través de Java - conserve el formato y mejore la compatibilidad."
---

## **Exportar ecuaciones matemáticas desde presentaciones**

Aspose.Slides for PHP a través de Java le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma.

{{% alert color="primary" %}} 
Puede exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 
{{% /alert %}}

Aunque los humanos pueden escribir fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está destinado a ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML con facilidad porque su código está en XML, por lo que MathML se utiliza comúnmente como formato de salida e impresión en muchos campos. 

Este fragmento de código muestra cómo exportar una ecuación matemática desde una presentación a MathML:
```php
  $pres = new Presentation();
  try {
    $autoShape = $pres->getSlides()->get_Item(0)->getShapes()->addMathShape(0, 0, 500, 50);
    $mathParagraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();
    $mathParagraph->add(new MathematicalText("a")->setSuperscript("2")->join("+")->join(new MathematicalText("b")->setSuperscript("2"))->join("=")->join(new MathematicalText("c")->setSuperscript("2")));
    $stream = new Java("java.io.FileOutputStream", "mathml.xml");
    $mathParagraph->writeAsMathMl($stream);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**

Puede exportar ya sea un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/)) o un bloque individual ([MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto normal o una imagen?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/). Las imágenes y los fragmentos de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación—es específico de PowerPoint o es un estándar?**

La exportación apunta a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que se usa ampliamente en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿La exportación a MathML modifica la presentación original?**

No. Generar MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.