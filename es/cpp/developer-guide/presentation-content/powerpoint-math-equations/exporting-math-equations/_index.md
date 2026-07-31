---
title: Exportar ecuaciones matemáticas desde presentaciones en C++
linktitle: Exportar ecuaciones
type: docs
weight: 30
url: /es/cpp/exporting-math-equations/
keywords:
- exportar ecuaciones matemáticas
- MathML
- LaTeX
- PowerPoint
- presentación
- C++
- Aspose.Slides
description: "Desbloquee una exportación sin problemas de ecuaciones matemáticas desde PowerPoint a MathML usando Aspose.Slides para C++ — preservar el formato y mejorar la compatibilidad."
---
## **Introducción**

Aspose.Slides for C++ le permite exportar ecuaciones matemáticas desde presentaciones. Por ejemplo, puede necesitar extraer las ecuaciones matemáticas de diapositivas (de una presentación concreta) y utilizarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 

Puede exportar ecuaciones a MathML, un formato popular o estándar para ecuaciones matemáticas y contenido similar que se ve en la web y en muchas aplicaciones. 

{{% /alert %}}

## **Guardar ecuaciones matemáticas como MathML**

Mientras que los humanos escriben fácilmente el código para algunos formatos de ecuaciones como LaTeX, les cuesta escribir el código para MathML porque este último está pensado para ser generado automáticamente por las aplicaciones. Los programas leen y analizan MathML con facilidad porque su código está en XML, por lo que MathML se utiliza habitualmente como formato de salida e impresión en muchos campos. 

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

## **Preguntas frecuentes**

**¿Qué se exporta exactamente a MathML, un párrafo o un bloque de fórmula individual?**

Puede exportar tanto un párrafo matemático completo ([MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/)) como un bloque individual ([MathBlock](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathblock/)) a MathML. Ambos tipos proporcionan un método para escribir en MathML.

**¿Cómo puedo saber si un objeto en una diapositiva es una fórmula matemática en lugar de texto normal o una imagen?**

Una fórmula se encuentra dentro de un [MathPortion](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathportion/) y posee un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/). Las imágenes y los fragmentos de texto normales que no contienen un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) no son fórmulas exportables.

**¿De dónde proviene el MathML en una presentación, es específico de PowerPoint o es un estándar?**

La exportación se dirige a MathML estándar (XML). Aspose utiliza Presentation MathML, el subconjunto de presentación del estándar, que está ampliamente adoptado en aplicaciones y en la web.

**¿Se admite la exportación de fórmulas dentro de tablas, SmartArt, grupos, etc.?**

Sí, si esos objetos contienen fragmentos de texto con un [MathParagraph](https://reference.aspose.com/slides/es/cpp/aspose.slides.mathtext/mathparagraph/) (es decir, fórmulas reales de PowerPoint), se exportan. Si una fórmula está incrustada como imagen, no se exporta.

**¿La exportación a MathML modifica la presentación original?**

No. Escribir MathML es una serialización del contenido de la fórmula; no modifica el archivo de la presentación.