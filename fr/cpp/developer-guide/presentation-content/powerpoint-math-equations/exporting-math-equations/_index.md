---
title: Exporter des équations mathématiques depuis des présentations en C++
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/cpp/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- C++
- Aspose.Slides
description: "Exporter des équations mathématiques depuis les présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour C++."
---
## **Introduction**

Aspose.Slides for C++ vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, il se peut que vous deviez extraire les équations mathématiques des diapositives (d'une présentation spécifique) et les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 

Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le Web et dans de nombreuses applications.

{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides peut convertir une équation mathématique PowerPoint directement en LaTeX ; aucun fichier MathML intermédiaire ni convertisseur externe n'est nécessaire. Une équation mathématique est stockée dans un cadre de texte sous forme d'[IMathPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathportion/). Utilisez [IMathPortion::get_MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathportion/get_mathparagraph/) pour obtenir un [IMathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathparagraph/), puis appelez [IMathParagraph::ToLatex](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathparagraph/tolatex/). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque cadre de texte sur chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` distinct :

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

[SlideUtil::GetAllTextBoxes](https://reference.aspose.com/slides/fr/cpp/aspose.slides.util/slideutil/getalltextboxes/) renvoie tous les cadres de texte trouvés sur une diapositive. Le type [IMathPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/imathportion/) permet de séparer les véritables équations éditables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne supportent pas tous les mêmes commandes, packages ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n'a pas de représentation adaptée dans cet environnement, remplacez‑le dans la chaîne par une commande spécifique au projet ou ignorez l'équation et consignez le problème pour révision.

## **Save Math Equations as MathML**

Alors que les humains écrivent facilement le code de certains formats d'équations comme LaTeX, ils ont du mal à rédiger le code de MathML car ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

Ce code d'exemple montre comment exporter une équation mathématique d'une présentation vers MathML :

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

**Qu'est‑ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathparagraph/)), soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ou une image ordinaire ?**

Une formule réside dans un [MathPortion](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D'où vient le MathML dans une présentation — est‑ce spécifique à PowerPoint ou un standard ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation du standard—qui est largement employé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/cpp/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est incorporée sous forme d'image, elle ne l’est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation d'origine ?**

Non. L'écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.