---
title: Exporter des équations mathématiques depuis les présentations en C++
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/cpp/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- MathML
- LaTeX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Débloquez l'exportation transparente des équations mathématiques de PowerPoint vers MathML avec Aspose.Slides pour C++ — préservez la mise en forme et améliorez la compatibilité."
---

## **Exporter les équations mathématiques depuis les présentations**

Aspose.Slides for C++ vous permet d'exporter les équations mathématiques depuis des présentations. Par exemple, il se peut que vous deviez extraire les équations mathématiques des diapositives (d'une présentation spécifique) et les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="primary" %}} 
Vous pouvez exporter les équations vers MathML, un format ou une norme populaire pour les équations mathématiques et les contenus similaires visibles sur le Web et dans de nombreuses applications. 
{{% /alert %}}

Alors que les humains écrivent facilement le code pour certains formats d'équations comme LaTeX, ils ont du mal à rédiger le code pour MathML car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, de sorte que le MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines. 

Ce code d'exemple vous montre comment exporter une équation mathématique depuis une présentation vers MathML :
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


## **FAQ**

**Qu'est-ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation — est‑il spécifique à PowerPoint ou s'agit‑il d'une norme ?**

L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation de la norme — qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur des tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/cpp/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est incorporée sous forme d’image, elle ne l’est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation d'origine ?**

Non. La génération de MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.