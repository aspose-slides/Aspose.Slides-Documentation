---
title: Exportation d'équations mathématiques
type: docs
weight: 30
url: /fr/cpp/exporting-math-equations/

---

# Exportation d'équations mathématiques à partir de présentations

Aspose.Slides pour C++ vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pourriez avoir besoin d'extraire les équations mathématiques sur des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou plateforme. 

{{% alert color="primary" %}} 

Vous pouvez exporter des équations au format MathML, un format ou standard populaire pour les équations mathématiques et un contenu similaire vu sur le web et dans de nombreuses applications. 

{{% /alert %}}

Bien que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à écrire le code pour MathML car ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement MathML car son code est en XML, donc MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines. 

Ce code d'exemple vous montre comment exporter une équation mathématique d'une présentation vers MathML :

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