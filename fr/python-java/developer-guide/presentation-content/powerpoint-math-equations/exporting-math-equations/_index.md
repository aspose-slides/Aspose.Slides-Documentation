---
title: Exporter des équations mathématiques à partir de présentations en Python
linktitle: Exporter les équations
type: docs
weight: 30
url: /fr/python-java/exporting-math-equations/
keywords:
- exporter des équations mathématiques
- exporter des équations vers LaTeX
- PowerPoint vers LaTeX
- MathML
- LaTeX
- PowerPoint
- présentation
- Python
- Java
- Aspose.Slides
description: "Exporter des équations mathématiques depuis des présentations PowerPoint vers LaTeX ou MathML directement avec Aspose.Slides pour Python via Java."
---
## **Introduction**

Aspose.Slides vous permet d'exporter des équations mathématiques à partir de présentations. Par exemple, vous pouvez avoir besoin d'extraire les équations mathématiques des diapositives (d'une présentation spécifique) et de les utiliser dans un autre programme ou une autre plateforme. 

{{% alert color="info" title="Remarque" %}} 

Vous pouvez exporter les équations directement vers LaTeX ou vers MathML, un standard populaire pour le contenu mathématique utilisé sur le web et dans de nombreuses applications.

{{% /alert %}}

## **Exporter les équations mathématiques vers LaTeX**

Aspose.Slides peut convertir directement une équation mathématique PowerPoint en LaTeX; aucun fichier MathML intermédiaire ni convertisseur externe n'est nécessaire. Une équation mathématique est stockée dans un cadre de texte sous forme d'un [MathPortion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathportion/). Utilisez [MathPortion.getMathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathportion/#getMathParagraph) pour obtenir un [MathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/), puis appelez [MathParagraph.toLatex](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/#toLatex). La méthode renvoie une chaîne que vous pouvez enregistrer, afficher, envoyer à une autre application ou traiter davantage.

L'exemple suivant examine chaque cadre de texte de chaque diapositive, trouve toutes les portions mathématiques et écrit chaque équation dans un fichier `.tex` distinct :

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathPortion, Presentation, SlideUtil

presentation = Presentation("equations.pptx")
try:
    slide_count = presentation.getSlides().size()
    for slide_index in range(slide_count):
        slide = presentation.getSlides().get_Item(slide_index)
        slide_number = slide_index + 1
        equation_number = 1
        text_frames = SlideUtil.getAllTextBoxes(slide)

        for text_frame in text_frames:
            for paragraph in text_frame.getParagraphs():
                for portion in paragraph.getPortions():
                    if not isinstance(portion, MathPortion):
                        continue

                    math_paragraph = portion.getMathParagraph()
                    latex_file_name = f"slide_{slide_number}_equation_{equation_number}.tex"
                    latex_text = math_paragraph.toLatex()
                    latex_path = Path(latex_file_name)
                    latex_path.write_text(str(latex_text), encoding="utf-8")
                    equation_number += 1
finally:
    presentation.dispose()
```

[SlideUtil.getAllTextBoxes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#getAllTextBoxes) renvoie tous les cadres de texte trouvés sur une diapositive. Le contrôle de type [MathPortion] sépare les véritables équations modifiables du texte ordinaire et des images.

Les moteurs LaTeX et les modèles de documents ne supportent pas tous les mêmes commandes, packages ou caractères Unicode. Testez la chaîne renvoyée avec le moteur LaTeX utilisé par votre application. Si un symbole ou un élément Office Math n'a aucune représentation adaptée dans cet environnement, remplacez-le dans la chaîne renvoyée par une commande spécifique au projet ou omettez l'équation et consignez le problème pour révision.

## **Enregistrer les équations mathématiques au format MathML**

Bien que les développeurs puissent écrire facilement du code pour certains formats d'équations, comme LaTeX, MathML est plus difficile à rédiger manuellement car il est conçu pour être généré automatiquement par les applications. Les programmes peuvent facilement lire et analyser le MathML puisqu'il est basé sur XML, ce qui fait de MathML un format de sortie et d'impression couramment utilisé dans de nombreux domaines. 

Ce code d'exemple montre comment exporter une équation mathématique d'une présentation vers MathML :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation
from java.io import FileOutputStream

presentation = Presentation()
try:
    math_shape = presentation.getSlides().get_Item(0).getShapes().addMathShape(0, 0, 500, 50)
    math_portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
    math_paragraph = math_portion.getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    c_squared = MathematicalText("c").setSuperscript("2")
    equation = a_squared.join("+").join(b_squared).join("=").join(c_squared)
    math_paragraph.add(equation)

    stream = FileOutputStream("mathml.xml")
    try:
        math_paragraph.writeAsMathMl(stream)
    finally:
        stream.close()
finally:
    presentation.dispose()
```

## **FAQ**

**Qu'est ce qui est exactement exporté vers MathML : un paragraphe ou un bloc de formule individuel ?**

Vous pouvez exporter soit un paragraphe mathématique complet ([MathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/)) soit un bloc individuel ([MathBlock](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathblock/)) vers MathML. Les deux types offrent une méthode pour écrire en MathML.

**Comment savoir si un objet sur une diapositive est une formule mathématique plutôt qu'un texte ordinaire ou une image ?**

Une formule réside dans un [MathPortion](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathportion/) et possède un [MathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/). Les images et les portions de texte ordinaires dépourvues d'un [MathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/) ne sont pas des formules exportables.

**D'où provient le MathML dans une présentation : est-il spécifique à PowerPoint ou s'agit-il d'un standard ?**

L'exportation cible le MathML standard (XML). Aspose utilise le Presentation MathML - le sous-ensemble de présentation du standard - qui est largement utilisé dans les applications et sur le web.

**L'exportation de formules à l'intérieur de tableaux, SmartArt, groupes, etc., est-elle prise en charge ?**

Oui, si ces objets contiennent des portions de texte avec un [MathParagraph](https://reference.aspose.com/slides/fr/python-java/aspose.slides/mathparagraph/) (c'est a dire de véritables formules PowerPoint), elles sont exportées. Si une formule est intégrée sous forme d'image, elle ne l'est pas.

**L'exportation vers MathML modifie-t-elle la présentation d'origine ?**

Non. Générer du MathML consiste à sérialiser le contenu de la formule ; cela ne modifie pas le fichier de présentation.