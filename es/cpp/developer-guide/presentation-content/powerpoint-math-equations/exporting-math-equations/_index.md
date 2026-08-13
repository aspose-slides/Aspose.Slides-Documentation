---
title: Exportar ecuaciones matemáticas de presentaciones en C++
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/cpp/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- exportar ecuaciones a LaTeX
- PowerPoint a LaTeX
- MathML
- LaTeX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Exportar ecuaciones matemáticas de presentaciones PowerPoint a LaTeX o MathML directamente con Aspose.Slides para C++."
---
## **Introducción**

Aspose.Slides for C++ le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación concreta) y utilizarlas en otro programa o plataforma. 

{{% alert color="info" %}} 

Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático utilizado en la web y en muchas aplicaciones.

{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se necesita un archivo MathML intermedio ni un convertidor externo. Una ecuación matemática se almacena en un cuadro de texto como un [IMathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathportion/). Utilice [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) para obtener un [IMathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathparagraph/), y a continuación llame a [IMathParagraph::ToLatex](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar más adelante.

El siguiente ejemplo examina cada cuadro de texto en cada diapositiva, encuentra todas las porciones matemáticas y escribe cada ecuación en un archivo `.tex` separado:

```cpp
auto presentation = MakeObject<Presentation>(u"equations.pptx");

auto slideCount = presentation->get_Slides()->get_Count();
for (int slideIndex = 0; slideIndex < slideCount; slideIndex++)
{
    auto slide = presentation->get_Slide(slideIndex);
    int slideNumber = slideIndex + 1;
    int equationNumber = 1;
    auto textFrames = SlideUtil::GetAllTextBoxes(slide);

    for (const auto&& textFrame : textFrames)
    {
        for (const auto&& paragraph : textFrame->get_Paragraphs())
        {
            for (const auto&& portion : paragraph->get_Portions())
            {
                auto mathPortion = System::AsCast<IMathPortion>(portion);
                if (mathPortion == nullptr)
                    continue;

                auto mathParagraph = mathPortion->get_MathParagraph();
                auto latexPath = String::Format(u"slide_{0}_equation_{1}.tex", slideNumber, equationNumber);

                auto latexText = mathParagraph->ToLatex();
                File::WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}

presentation->Dispose();
```

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/getalltextboxes/) devuelve todos los cuadros de texto encontrados en una diapositiva. La comprobación de tipo [IMathPortion] separa las ecuaciones editables reales del texto e imágenes ordinarios.

Los motores LaTeX y las plantillas de documento no admiten todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor LaTeX que utiliza su aplicación. Si un símbolo o elemento de Office Math no tiene una representación adecuada en ese entorno, reemplácelo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Aunque los humanos pueden escribir fácilmente el código para algunos formatos de ecuación como LaTeX, les cuesta escribir el código para MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se usa comúnmente como formato de salida e impresión en muchos campos. 

Este código de ejemplo muestra cómo exportar una ecuación matemática de una presentación a MathML:

``` cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/MathText/IMathBlock.h>
#include <DOM/MathText/IMathParagraph.h>
#include <DOM/MathText/IMathPortion.h>
#include <DOM/MathText/IMathSuperscriptElement.h>
#include <DOM/MathText/MathematicalText.h>
#include <DOM/Presentation.h>
#include <system/io/file_mode.h>
#include <system/io/file_stream.h>
#include <system/io/stream.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::MathText;
using namespace System;
using namespace System::IO;

SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")
                - >SetSuperscript(u"2"))
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"c")
                - >SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```

## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML: un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir a MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto o una imagen normal?**

Una fórmula se encuentra en un [MathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/). Las imágenes y porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación se dirige al MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que se usa ampliamente en aplicaciones y la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no se exporta.

**¿La exportación a MathML modifica la presentación original?**

No. Generar MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.