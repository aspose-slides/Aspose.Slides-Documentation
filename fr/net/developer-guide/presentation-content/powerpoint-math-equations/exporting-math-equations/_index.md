---
title: Exporter des équations mathématiques depuis des présentations en .NET
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/net/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- .NET
- C#
- Aspose.Slides
description: "Exporter des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour .NET."
---
## **Introduction**

Aspose.Slides for .NET vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pouvez avoir besoin d'extraire les équations mathématiques des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="primary" %}} 
Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le Web et dans de nombreuses applications.
{{% /alert %}}

## **Export Math Equations to LaTeX**

Aspose.Slides peut convertir une équation mathématique PowerPoint directement en LaTeX ; un fichier intermédiaire MathML et un convertisseur externe ne sont pas nécessaires. Une équation mathématique est stockée dans un cadre de texte comme une [MathPortion](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathportion/). Utilisez [MathPortion.MathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathportion/mathparagraph/) pour obtenir un [IMathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/imathparagraph/), puis appelez [IMathParagraph.ToLatex](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/imathparagraph/tolatex/). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque cadre de texte sur chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` distinct :

```csharp
using var presentation = new Presentation("equations.pptx");

for (var slideIndex = 0; slideIndex < presentation.Slides.Count; slideIndex++)
{
    var slide = presentation.Slides[slideIndex];
    var slideNumber = slideIndex + 1;
    var equationNumber = 1;
    var textFrames = SlideUtil.GetAllTextBoxes(slide);

    foreach (var textFrame in textFrames)
    {
        foreach (var paragraph in textFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                if (portion is not MathPortion mathPortion)
                    continue;

                IMathParagraph mathParagraph = mathPortion.MathParagraph;
                var latexPath = $"slide_{slideNumber}_equation_{equationNumber}.tex";

                var latexText = mathParagraph.ToLatex();
                File.WriteAllText(latexPath, latexText);
                equationNumber++;
            }
        }
    }
}
```

[SlideUtil.GetAllTextBoxes](https://reference.aspose.com/slides/fr/net/aspose.slides.util/slideutil/getalltextboxes/) renvoie tous les cadres de texte trouvés sur une diapositive. Le contrôle de type [MathPortion](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathportion/) sépare les véritables équations modifiables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne supportent pas tous les mêmes commandes, paquets ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n’a pas de représentation adéquate dans cet environnement, remplacez‑le dans la chaîne renvoyée par une commande spécifique au projet ou ignorez l’équation et consignez le problème pour révision.

## **Save Math Equations as MathML**

Alors que les humains écrivent facilement le code de certains formats d’équations comme LaTeX, ils peinent à écrire le code de MathML car ce dernier est destiné à être généré automatiquement par les applications. Les programmes lisent et analysent facilement le MathML parce que son code est en XML, ainsi le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines. 

Ce code d’exemple vous montre comment exporter une équation mathématique d’une présentation vers MathML :

```c#
using (Presentation pres = new Presentation())
        {
            var autoShape = pres.Slides[0].Shapes.AddMathShape(0, 0, 500, 50);
            var mathParagraph = ((MathPortion)autoShape.TextFrame.Paragraphs[0].Portions[0]).MathParagraph;

            mathParagraph.Add(new MathematicalText("a").SetSuperscript("2").Join("+").Join(new MathematicalText("b").SetSuperscript("2")).Join("=").Join(new MathematicalText("c").SetSuperscript("2")));

       using (Stream stream = new FileStream("mathml.xml", FileMode.Create))
                mathParagraph.WriteAsMathMl(stream);
        }
```

## **FAQ**

**Que exporte exactement MathML — un paragraphe ou un bloc de formule individuel ?**  
Vous pouvez exporter soit un paragraphe complet ([MathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types fournissent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**  
Une formule réside dans une [MathPortion](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D'où vient le MathML dans une présentation — est‑il spécifique à PowerPoint ou un standard ?**  
L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation du standard — qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**  
Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/net/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d’image, elle ne l’est pas.

**L'exportation vers MathML modifie‑elle la présentation d'origine ?**  
Non. L'écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.