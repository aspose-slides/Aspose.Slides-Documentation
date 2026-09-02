---
title: Exportar ecuaciones matemáticas desde presentaciones en C++
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
description: "Exporta ecuaciones matemáticas desde presentaciones de PowerPoint a LaTeX o MathML directamente con Aspose.Slides para C++."
---
## **Introducción**

Aspose.Slides para C++ le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de las diapositivas (de una presentación concreta) y utilizarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 
Puede exportar ecuaciones directamente a LaTeX o a MathML, un estándar popular para contenido matemático usado en la web y en muchas aplicaciones.
{{% /alert %}}

## **Exportar ecuaciones matemáticas a LaTeX**

Aspose.Slides puede convertir una ecuación matemática de PowerPoint directamente a LaTeX; no se necesita un archivo intermedio MathML ni un conversor externo. Una ecuación matemática se almacena en un marco de texto como un [IMathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathportion/). Utilice [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) para obtener un [IMathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathparagraph/), y a continuación llame a [IMathParagraph::ToLatex](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). El método devuelve una cadena que puede guardar, mostrar, enviar a otra aplicación o procesar más adelante.

El siguiente ejemplo examina cada marco de texto en cada diapositiva, encuentra todas las porciones matemáticas y escribe cada ecuación en un archivo `.tex` separado:

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/es/cpp/aspose.slides.util/slideutil/getalltextboxes/) devuelve todos los marcos de texto encontrados en una diapositiva. La comprobación de tipo [IMathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/imathportion/) separa las ecuaciones editables reales del texto e imágenes ordinarios.

Los motores LaTeX y las plantillas de documento no admiten todos los mismos comandos, paquetes o caracteres Unicode. Pruebe la cadena devuelta con el motor LaTeX utilizado por su aplicación. Si un símbolo o elemento de Office Math no tiene una representación adecuada en ese entorno, reemplácelo en la cadena devuelta con un comando específico del proyecto o omita la ecuación y registre el problema para su revisión.

## **Guardar ecuaciones matemáticas como MathML**

Mientras los humanos pueden escribir fácilmente el código de algunos formatos de ecuaciones como LaTeX, les resulta difícil escribir el código de MathML porque este último está pensado para ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML con facilidad porque su código está en XML, de modo que MathML se usa habitualmente como formato de salida e impresión en muchos campos. 

Este fragmento de código muestra cómo exportar una ecuación matemática desde una presentación a MathML:

``` cpp
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

## **FAQ**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/)) o un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática y no texto normal o una imagen?**

Una fórmula se encuentra en un [MathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathportion/) y tiene un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/). Las imágenes y las porciones de texto normales sin un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación se dirige a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está muy extendido en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen porciones de texto con un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no lo es.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.