---
title: Personnaliser les polices par défaut dans les présentations avec Python
linktitle: Police par défaut
type: docs
weight: 30
url: /fr/python-net/default-font/
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
- Aspose.Slides
description: "Définissez les polices par défaut dans Aspose.Slides pour Python afin d'assurer une conversion correcte de PowerPoint (PPT, PPTX) et OpenDocument (ODP) vers PDF, XPS et images."
---

## **Utilisation des polices par défaut pour le rendu de la présentation**
Aspose.Slides vous permet de définir la police par défaut pour le rendu de la présentation en PDF, XPS ou vignettes. Cet article montre comment définir DefaultRegularFont et DefaultAsianFont à utiliser comme polices par défaut. Veuillez suivre les étapes ci-dessous pour charger des polices depuis des répertoires externes en utilisant Aspose.Slides pour Python via l'API .NET :

1. Créez une instance de LoadOptions.  
2. Définissez DefaultRegularFont sur la police souhaitée. Dans l'exemple suivant, j'ai utilisé Wingdings.  
3. Définissez DefaultAsianFont sur la police souhaitée. J'ai utilisé Wingdings dans l'exemple suivant.  
4. Chargez la présentation avec Presentation en définissant les options de chargement.  
5. Maintenant, générez la vignette de diapositive, le PDF et le XPS pour vérifier les résultats.  

L'implémentation ci-dessus est fournie ci-dessous.
```py
import aspose.slides as slides

# Utilisez les options de chargement pour définir les polices par défaut régulières et asiatiques# Utilisez les options de chargement pour définir les polices par défaut régulières et asiatiques
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Charger la présentation
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Générer la vignette de la diapositive
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Générer le PDF
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Générer le XPS
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```


## **FAQ**

**Que affectent exactement default_regular_font et default_asian_font — uniquement l’exportation ou également les vignettes, PDF, XPS, HTML et SVG ?**

Ils participent au pipeline de rendu pour toutes les sorties prises en charge. Cela inclut les vignettes de diapositive, [PDF](/slides/fr/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/fr/python-net/convert-powerpoint-to-xps/), [images raster](/slides/fr/python-net/convert-powerpoint-to-png/), [HTML](/slides/fr/python-net/convert-powerpoint-to-html/), et [SVG](/slides/fr/python-net/render-a-slide-as-an-svg-image/), car Aspose.Slides utilise la même logique de mise en page et de résolution des glyphes pour ces cibles.

**Les polices par défaut sont‑elles appliquées lors d’une simple lecture et sauvegarde d’un PPTX sans aucun rendu ?**

Non. Les polices par défaut sont importantes lorsque le texte doit être mesuré et dessiné. Un simple enregistrement‑ouverture d’une présentation ne modifie pas les runs de police stockés ni la structure du fichier. Les polices par défaut interviennent lors des opérations qui rendent ou ré‑organisent le texte.

**Si j’ajoute mes propres dossiers de polices ou fournis des polices depuis la mémoire, seront‑elles prises en compte lors du choix des polices par défaut ?**

Oui. [Sources de polices personnalisées](/slides/fr/python-net/custom-font/) élargissent le catalogue des familles et glyphes disponibles que le moteur peut utiliser. Les polices par défaut et les [règles de secours](/slides/fr/python-net/fallback-font/) seront résolues d’abord par rapport à ces sources, offrant une couverture plus fiable sur les serveurs et dans les conteneurs.

**Les polices par défaut affecteront‑elles les métriques du texte (crénage, avances) et donc les sauts de ligne et le retour à la ligne ?**

Oui. Modifier la police modifie les métriques des glyphes et peut changer les sauts de ligne, le retour à la ligne et la pagination lors du rendu. Pour la stabilité de la mise en page, [intégrez les polices d’origine](/slides/fr/python-net/embedded-font/) ou choisissez des familles par défaut et de secours compatibles métriquement.

**Y a‑t‑il un intérêt à définir des polices par défaut si toutes les polices utilisées dans la présentation sont intégrées ?**

Souvent ce n’est pas nécessaire, car les [polices intégrées](/slides/fr/python-net/embedded-font/) garantissent déjà une apparence cohérente. Les polices par défaut restent utiles comme filet de sécurité pour les caractères non couverts par le sous‑ensemble intégré ou lorsqu’un fichier mélange du texte intégré et non intégré.