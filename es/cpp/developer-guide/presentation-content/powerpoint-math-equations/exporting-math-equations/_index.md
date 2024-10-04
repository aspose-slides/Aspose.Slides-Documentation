---
title: Exportar Ecuaciones Matemáticas
type: docs
weight: 30
url: /cpp/exporting-math-equations/

---

# Exportar Ecuaciones Matemáticas desde Presentaciones

Aspose.Slides para C++ te permite exportar ecuaciones matemáticas de presentaciones. Por ejemplo, puede que necesites extraer las ecuaciones matemáticas en las diapositivas (de una presentación específica) y usarlas en otro programa o plataforma. 

{{% alert color="primary" %}} 

Puedes exportar ecuaciones a MathML, un formato o estándar popular para ecuaciones matemáticas y contenido similar visto en la web y en muchas aplicaciones. 

{{% /alert %}}

Mientras que los humanos fácilmente escriben el código para algunos formatos de ecuaciones como LaTeX, luchan por escribir el código para MathML porque este último está destinado a ser generado automáticamente por aplicaciones. Los programas leen y analizan MathML fácilmente porque su código está en XML, por lo que MathML se utiliza comúnmente como un formato de salida e impresión en muchos campos. 

Este código de ejemplo te muestra cómo exportar una ecuación matemática de una presentación a MathML:

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

auto autoShape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddMathShape(0.0f, 0.0f, 500.0f, 50.0f);
auto mathPortion = System::ExplicitCast<IMathPortion>(autoShape->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0));
auto mathParagraph = mathPortion->get_MathParagraph();

mathParagraph->Add(System::MakeObject<MathematicalText>(u"a")
        ->SetSuperscript(u"2")
        ->Join(u"+")
        ->Join(System::MakeObject<MathematicalText>(u"b")
                ->SetSuperscript(u"2"))
        ->Join(u"=")
        ->Join(System::MakeObject<MathematicalText>(u"c")
                ->SetSuperscript(u"2")));

SharedPtr<Stream> stream = System::MakeObject<FileStream>(u"mathml.xml", FileMode::Create);

mathParagraph->WriteAsMathMl(stream);
```