---
title: Exportation des équations mathématiques
type: docs
weight: 30
url: /fr/net/exporting-math-equations/
keywords: "Exporter des équations mathématiques, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Exporter des équations mathématiques PowerPoint en C# ou .NET"
---

## **Introduction**

Aspose.Slides for .NET vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, il se peut que vous deviez extraire les équations mathématiques des diapositives (d’une présentation spécifique) et les utiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}} 
Vous pouvez exporter des équations au format MathML, un format ou une norme populaire pour les équations mathématiques et le contenu similaire visible sur le Web et dans de nombreuses applications. 
{{% /alert %}}

## **Enregistrer les équations mathématiques au format MathML**

Alors que les humains écrivent facilement le code de certains formats d’équation comme LaTeX, ils ont du mal à écrire le code de MathML parce que ce dernier est destiné à être généré automatiquement par des applications. Les programmes lisent et analysent facilement le MathML car son code est en XML, de sorte que le MathML est couramment utilisé comme format de sortie et d’impression dans de nombreux domaines.

Ce code d’exemple montre comment exporter une équation mathématique d’une présentation vers MathML:
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

**Qu’est‑ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types fournissent une méthode pour écrire en MathML.

**Comment savoir qu’un objet sur une diapositive est une formule mathématique plutôt qu’un texte ordinaire ou une image ?**

Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D’où provient le MathML dans une présentation — est‑ce spécifique à PowerPoint ou une norme ?**

L’exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation de la norme — qui est largement utilisé dans les applications et sur le Web.

**L’exportation de formules à l’intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/net/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d’image, elle ne l’est pas.

**L’exportation vers MathML modifie‑t‑elle la présentation d’origine ?**

Non. L’écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.