---
title: Spécifier les polices de présentation par défaut en Python via Java
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/python-java/default-font/
keywords:
- police par défaut
- police régulière
- police normale
- police asiatique
- export PDF
- export XPS
- export d'images
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Définir les polices par défaut dans Aspose.Slides pour Python via Java afin d’assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---
## **Vue d'ensemble**

Aspose.Slides vous permet de spécifier les polices par défaut utilisées lors du rendu d’une présentation. Ceci est utile lors de la génération de miniatures de diapositives ou de l’exportation d’une présentation vers des formats tels que PDF et XPS. Les polices par défaut sont configurées via [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/) avant le chargement de la présentation.

La méthode [setDefaultRegularFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) définit la police par défaut pour le texte normal, tandis que [setDefaultAsianFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) définit la police par défaut pour le texte asiatique. Après avoir défini ces options, la présentation peut être chargée et rendue en utilisant les polices spécifiées.

## **Utiliser les polices par défaut pour le rendu d’une présentation**

Aspose.Slides vous permet de définir des polices par défaut pour le rendu d’une présentation au format PDF, XPS ou sous forme de miniatures. Cette section montre comment définir des polices par défaut pour le texte normal et asiatique à l’aide d’Aspose.Slides pour Python via Java :

1. Créez une instance de [LoadOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/).
1. Utilisez [setDefaultRegularFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultRegularFont) pour spécifier la police souhaitée. L’exemple suivant utilise Wingdings.
1. Utilisez [setDefaultAsianFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#setDefaultAsianFont) pour spécifier la police souhaitée. L’exemple suivant utilise également Wingdings.
1. Chargez la présentation avec [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) en utilisant les options de chargement.
1. Générez la miniature de la diapositive, le PDF et le XPS pour vérifier le résultat.

L’exemple suivant met en œuvre ces étapes :

```python
from asposeslides.api import ImageFormat, LoadFormat, LoadOptions, Presentation, SaveFormat

# Utilisez les options de chargement pour définir les polices normales et asiatiques par défaut.
load_options = LoadOptions(LoadFormat.Auto)
load_options.setDefaultRegularFont("Wingdings")
load_options.setDefaultAsianFont("Wingdings")

# Charger la présentation.
presentation = Presentation("DefaultFonts.pptx", load_options)
try:
    # Générer une miniature de diapositive.
    slide_image = presentation.getSlides().get_Item(0).getImage(1.0, 1.0)
    try:
        # Enregistrer l'image sur le disque.
        slide_image.save("output.png", ImageFormat.Png)
    finally:
        slide_image.dispose()

    # Générer un PDF.
    presentation.save("output_out.pdf", SaveFormat.Pdf)

    # Générer un document XPS.
    presentation.save("output_out.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

## **FAQ**

**Que affectent exactement les polices par défaut normales et asiatiques — seulement l’exportation ou aussi les miniatures, PDF, XPS, HTML et SVG ?**

Elles interviennent dans le pipeline de rendu pour toutes les sorties prises en charge. Cela comprend les miniatures de diapositives, [PDF](/slides/fr/python-java/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-java/convert-powerpoint-to-xps/), [images raster](/slides/fr/python-java/convert-powerpoint-to-png/), [HTML](/slides/fr/python-java/convert-powerpoint-to-html/), et [SVG](/slides/fr/python-java/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut entrent en jeu lorsque le texte doit être mesuré et dessiné. Un simple enregistrement ouvert d’une présentation ne modifie pas les runs de police stockés ni la structure du fichier. Les polices par défaut sont utilisées durant les opérations qui rendent ou réagencent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑ils pris en compte lors du choix des polices par défaut ?**

Oui. Les [Custom font sources](/slides/fr/python-java/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et les [fallback rules](/slides/fr/python-java/fallback-font/) seront résolues en priorité contre ces sources, offrant une meilleure couverture sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le renvoi à la ligne ?**

Oui. Modifier la police modifie les métriques des glyphes et peut changer les sauts de ligne, le renvoi à la ligne et la pagination lors du rendu. Pour garantir la stabilité de la mise en page, [embed the original fonts](/slides/fr/python-java/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont incorporées ?**

Souvent ce n’est pas nécessaire, car les [embedded fonts](/slides/fr/python-java/embedded-font/) assurent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble incorporé ou lorsqu’un fichier mélange du texte incorporé et non incorporé.