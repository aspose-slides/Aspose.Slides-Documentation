---
title: Exporter des équations mathématiques depuis des présentations en Python
linktitle: Exporter les équations
type: docs
weight: 30
url: /fr/python-net/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- MathML
- LaTeX
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Découvrez l'exportation fluide des équations mathématiques de PowerPoint vers MathML à l'aide d'Aspose.Slides pour Python via .NET—préservez la mise en forme et améliorez la compatibilité."
---

## **Introduction**

Aspose.Slides pour Python via .NET vous permet d'exporter des équations mathématiques depuis des présentations. Par exemple, il se peut que vous deviez extraire des équations de diapositives spécifiques et les réutiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}}
Vous pouvez exporter les équations vers MathML, un standard largement utilisé pour représenter du contenu mathématique sur le web et dans de nombreuses applications.
{{% /alert %}}

## **Enregistrer les équations mathématiques au format MathML**

Bien que les humains puissent écrire facilement du LaTeX, le MathML est généralement généré automatiquement par les applications. Étant donné que le MathML est basé sur XML, les programmes peuvent le lire et le analyser de manière fiable, ce qui en fait un format de sortie et d'impression couramment utilisé dans de nombreux domaines.

Le code d'exemple suivant montre comment exporter une équation mathématique d'une présentation vers MathML :

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    auto_shape = slide.shapes.add_math_shape(0, 0, 500, 50)
    math_paragraph = auto_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    math_paragraph.add(
        math.MathematicalText("a").
            set_superscript("2").
            join("+").
            join(math.MathematicalText("b").set_superscript("2")).
            join("=").
            join(math.MathematicalText("c").set_superscript("2")))

    with open("mathml.xml", "wb") as file_stream:
        math_paragraph.write_as_math_ml(file_stream)
```

## **FAQ**

**Qu'est-ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment identifier qu'un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**

Une formule réside dans une [MathPortion](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D'où vient le MathML dans une présentation — est-il spécifique à PowerPoint ou s'agit-il d'un standard ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML—le sous-ensemble de présentation du standard—qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est-elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/python-net/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est incorporée sous forme d'image, elle ne l’est pas.

**L'exportation vers MathML modifie-t-elle la présentation originale ?**

Non. L'écriture du MathML est une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.