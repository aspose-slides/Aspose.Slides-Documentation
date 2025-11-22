---
title: Personnaliser les polices PowerPoint en Python
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/python-net/custom-font/
keywords:
- police
- police personnalisée
- police externe
- charger police
- gérer les polices
- dossier de polices
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Intégrez des polices personnalisées dans les diapositives PowerPoint avec Aspose.Slides pour Python via .NET afin de garder vos présentations nettes et cohérentes sur n'importe quel appareil."
---

## **Vue d'ensemble**

Aspose.Slides for Python vous permet de fournir des polices personnalisées à l'exécution afin que les présentations s'affichent correctement même lorsque les polices requises ne sont pas installées sur le système hôte. Lors de l'exportation vers PDF ou images, vous pouvez fournir des dossiers de polices ou des données de police en mémoire pour préserver la mise en page du texte, les métriques des glyphes et la typographie. Cela rend le rendu côté serveur prévisible sur différents environnements, élimine les dépendances de polices au niveau du système d'exploitation et empêche les substitutions ou le remaniement indésirables. L'article montre comment enregistrer des sources de police.

Aspose.Slides vous permet de charger les polices suivantes à l'aide des méthodes `load_external_font` et `load_external_fonts` de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) :

- Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices pour le rendu des présentations sans les installer. Les polices sont chargées à partir d'un répertoire personnalisé.

1. Appelez la méthode `load_external_fonts` depuis [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).
1. Chargez la présentation à rendre.
1. Videz le cache dans la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

Le code Python suivant illustre le processus de chargement des polices :
```python
import aspose.slides as slides

# Dossiers à rechercher pour les polices.
font_folders = [ "C:\\MyFonts", "D:\\MyAdditionalFonts" ]

# Charger les polices à partir des répertoires personnalisés.
slides.FontsLoader.load_external_fonts(font_folders)

# Rendre la présentation.
with slides.Presentation("Fonts.pptx") as presentation:
    presentation.save("Fonts_out.pdf", slides.export.SaveFormat.PDF)

# Vider le cache des polices.
slides.FontsLoader.clear_cache()
```


## **Obtenir le dossier des polices personnalisées**

Aspose.Slides fournit la méthode `get_font_folders` pour récupérer les dossiers de polices. Elle renvoie à la fois les dossiers ajoutés via `load_external_fonts` et les dossiers de polices du système.

Ce code Python montre comment utiliser `get_font_folders` :
```python
import aspose.slides as slides

# Cet appel renvoie les dossiers vérifiés pour les fichiers de police.
# Ceux-ci incluent les dossiers ajoutés via la méthode load_external_fonts et les dossiers de police système.
font_folders = slides.FontsLoader.get_font_folders()
```


## **Spécifier des polices personnalisées pour une présentation**

Aspose.Slides fournit la propriété `document_level_font_sources`, qui vous permet de spécifier les polices externes à utiliser avec une présentation.

L'exemple Python suivant montre comment utiliser `document_level_font_sources` :
```python
import aspose.slides as slides

with open("CustomFont1.ttf", "br") as font1_stream:
    font1_data = font1_stream.read()
    
with open("CustomFont2.ttf", "br") as font2_stream:
    font2_data = font2_stream.read()

load_options = slides.LoadOptions()
load_options.document_level_font_sources.font_folders = ["assets\\fonts", "global\\fonts"] 
load_options.document_level_font_sources.memory_fonts = [font1_data, font2_data]

with slides.Presentation("Fonts.pptx", load_options) as presentation:
    # ...
    # Travailler avec la présentation.
    # CustomFont1, CustomFont2 et les polices issues des dossiers assets\fonts et global\fonts (et leurs sous‑dossiers) sont disponibles pour la présentation.
    # ...
    print(len(presentation.slides))
```


## **Charger des polices externes à partir de données binaires**

Aspose.Slides fournit la méthode `load_external_font` pour charger des polices externes à partir de données binaires.

L'exemple Python suivant démontre le chargement d'une police depuis un tableau d'octets :
```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Charger les polices externes à partir de tableaux d'octets.
slides.FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
slides.FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with slides.Presentation() as presentation:
        # Les polices externes sont disponibles pendant toute la durée de vie de cette instance de présentation.
        print("processing")
finally:
    slides.FontsLoader.clear_cache()
```


## **FAQ**

**Les polices personnalisées affectent-elles l'exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d'exportation.

**Les polices personnalisées sont‑elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’incorporer dans un PPTX. Si vous devez que la police soit intégrée au fichier de présentation, utilisez les fonctionnalités d’[incorporation](/slides/fr/python-net/embedded-font/).

**Puis‑je contrôler le comportement de substitution lorsqu’une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de police](/slides/fr/python-net/font-substitution/), les [règles de remplacement](/slides/fr/python-net/font-replacement/) et les [ensembles de secours](/slides/fr/python-net/fallback-font/) pour définir exactement quelle police est utilisée lorsque le glyphe demandé est manquant.

**Puis‑je utiliser des polices sous Linux/Docker sans les installer globalement ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez les polices depuis des tableaux d’octets. Cela supprime toute dépendance aux répertoires de polices système dans l’image du conteneur.

**Qu'en est‑il de la licence — puis‑je incorporer n’importe quelle police personnalisée sans restriction ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’incorporation ou l’usage commercial. Veillez toujours à examiner le contrat de licence de la police avant de distribuer les résultats.