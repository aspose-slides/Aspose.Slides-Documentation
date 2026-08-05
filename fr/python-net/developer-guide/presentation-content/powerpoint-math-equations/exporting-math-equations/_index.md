---
title: Exporter des équations mathématiques depuis des présentations en Python
linktitle: Exporter des équations
type: docs
weight: 30
url: /fr/python-net/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Exportez des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour Python via .NET."
---
## **Introduction**

Aspose.Slides for Python via .NET vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pouvez avoir besoin d'extraire des équations de diapositives spécifiques et de les réutiliser dans un autre programme ou une autre plateforme.

{{% alert color="primary" %}}
Vous pouvez exporter des équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le Web et dans de nombreuses applications.
{{% /alert %}}

## **Exporter les équations mathématiques vers LaTeX**

Aspose.Slides peut convertir directement une équation mathématique PowerPoint en LaTeX ; un fichier MathML intermédiaire et un convertisseur externe ne sont pas nécessaires. Une équation mathématique est stockée dans un cadre de texte sous forme de [MathPortion](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathportion/). Utilisez [MathPortion.math_paragraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathportion/math_paragraph/) pour obtenir un [MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/), puis appelez [MathParagraph.to_latex](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/to_latex/). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque cadre de texte de chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` séparé :

```py
import aspose.slides as slides

with slides.Presentation("equations.pptx") as presentation:
    for slide_number, slide in enumerate(presentation.slides, start=1):
        equation_number = 1
        text_frames = slides.util.SlideUtil.get_all_text_boxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.paragraphs:
                for portion in paragraph.portions:
                    if not isinstance(portion, slides.mathtext.MathPortion):
                        continue

                    math_paragraph = portion.math_paragraph
                    latex_path = f"slide_{slide_number}_equation_{equation_number}.tex"

                    latex_text = math_paragraph.to_latex()
                    with open(latex_path, "w", encoding="utf-8") as latex_file:
                        latex_file.write(latex_text)
                    equation_number += 1
```

[SlideUtil.get_all_text_boxes](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/get_all_text_boxes/) renvoie tous les cadres de texte trouvés sur une diapositive. La vérification de type [MathPortion](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathportion/) sépare les véritables équations éditables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne prennent pas tous en charge les mêmes commandes, paquets ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n'a pas de représentation adaptée dans cet environnement, remplacez‑le dans la chaîne renvoyée par une commande spécifique au projet ou ignorez l'équation et consignez le problème pour révision.

## **Enregistrer les équations mathématiques au format MathML**

Bien que les humains puissent écrire facilement du LaTeX, le MathML est généralement généré automatiquement par les applications. Comme le MathML est basé sur XML, les programmes peuvent le lire et le analyser de manière fiable, il est donc couramment utilisé comme format de sortie et d'impression dans de nombreux domaines.

Le code d'exemple suivant montre comment exporter une équation mathématique d'une présentation vers MathML :

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

**Qu'est-ce qui est exactement exporté vers MathML — un paragraphe ou un bloc de formule individuel ?**  
Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**  
Une formule se trouve dans une [MathPortion](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/). Les images et les portions de texte ordinaires sans [MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation — est-il spécifique à PowerPoint ou s'agit-il d'un standard ?**  
L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML — le sous‑ensemble de présentation du standard — qui est largement utilisé dans les applications et sur le Web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est‑elle prise en charge ?**  
Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/python-net/aspose.slides.mathtext/mathparagraph/) (c’est‑à‑dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d'image, elle ne l'est pas.

**L'exportation vers MathML modifie‑t‑elle la présentation originale ?**  
Non. L'écriture du MathML consiste en une sérialisation du contenu de la formule ; elle ne modifie pas le fichier de présentation.