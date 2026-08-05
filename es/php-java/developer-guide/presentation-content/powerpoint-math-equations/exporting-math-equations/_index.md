---
title: Exportar ecuaciones matemáticas de presentaciones en PHP
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/php-java/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- exportar ecuaciones a LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentación
- PHP
- Aspose.Slides
description: "Exporta ecuaciones matemáticas de presentaciones PowerPoint a LaTeX o MathML directamente con Aspose.Slides para PHP a través de Java."
---
## **Introducción**

Aspose.Slides para PHP a través de Java le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede que necesite extraer las ecuaciones matemáticas de las diapositivas (de una presentación específica) y utilizarlas en otro programa o plataforma.

{{% alert color="primary" %}} 
Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático utilizado en la web y en muchas aplicaciones.
{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se requiere un archivo MathML intermedio ni un conversor externo. Una ecuación matemática se almacena en un marco de texto como una [MathPortion](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/). Utilice [MathPortion::getMathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/#getMathParagraph) para obtener un [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/), y luego llame a [MathParagraph::toLatex](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/#toLatex). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar posteriormente.

El siguiente ejemplo examina cada marco de texto en cada diapositiva, encuentra todas las porciones matemáticas y escribe cada ecuación en un archivo `.tex` separado:

```php
$presentation = new Presentation("equations.pptx");
$arrayClass = new JavaClass("java.lang.reflect.Array");
$mathPortionClass = new JavaClass("com.aspose.slides.MathPortion");

try {
    $slideCount = java_values($presentation->getSlides()->size());
    for ($slideIndex = 0; $slideIndex < $slideCount; $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        $slideNumber = $slideIndex + 1;
        $equationNumber = 1;
        $textFrames = SlideUtil::getAllTextBoxes($slide);
        $textFrameCount = java_values($arrayClass->getLength($textFrames));

        for ($textFrameIndex = 0; $textFrameIndex < $textFrameCount; $textFrameIndex++) {
            $textFrame = $textFrames[$textFrameIndex];
            $paragraphCount = java_values($textFrame->getParagraphs()->getCount());
            for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                $portionCount = java_values($paragraph->getPortions()->getCount());
                for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (!java_instanceof($portion, $mathPortionClass)) {
                        continue;
                    }

                    $mathParagraph = $portion->getMathParagraph();
                    $latexFileName = "slide_" . $slideNumber . "_equation_" . $equationNumber . ".tex";

                    $latexText = java_values($mathParagraph->toLatex());
                    file_put_contents($latexFileName, $latexText);
                    $equationNumber++;
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

[SlideUtil::getAllTextBoxes](https://reference.aspose.com/slides/es/php-java/aspose.slides/slideutil/#getAllTextBoxes) devuelve todos los marcos de texto encontrados en una diapositiva. La verificación de tipo [MathPortion](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/) separa las ecuaciones editables genuinas del texto e imágenes ordinarios.

Los motores LaTeX y las plantillas de documento no soportan todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor LaTeX que usa su aplicación. Si un símbolo o elemento Office Math no tiene una representación adecuada en ese entorno, reemplácelo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos pueden escribir fácilmente el código de algunos formatos de ecuaciones como LaTeX, les resulta difícil escribir el código de MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se utiliza comúnmente como formato de salida e impresión en muchos campos. 

Este código de ejemplo le muestra cómo exportar una ecuación matemática de una presentación a MathML:

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

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto o una imagen normal?**

Una fórmula se encuentra en una [MathPortion](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/). Las imágenes y los fragmentos de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o un estándar?**

La exportación se dirige a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que se usa ampliamente en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/es/php-java/aspose.slides/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como una imagen, no lo está.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.