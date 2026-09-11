---
title: Personnaliser les polices PowerPoint en Python via Java
linktitle: Police personnalisée
type: docs
weight: 20
url: /fr/python-java/custom-font/
keywords:
- police
- police personnalisée
- police externe
- charger police
- gérer les polices
- dossier de polices
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Personnalisez les polices des diapositives PowerPoint avec Aspose.Slides pour Python via Java afin de garder vos présentations nettes et cohérentes sur tous les appareils."
---
## **Vue d'ensemble**

Aspose.Slides vous permet d’utiliser des polices personnalisées dans les présentations sans les installer sur le système d’exploitation. Vous pouvez charger des polices depuis des dossiers personnalisés, fournir des polices pour une présentation spécifique via des sources de polices au niveau du document, ou charger des polices externes directement à partir de données binaires.

Les polices chargées sont utilisées lorsqu’une présentation est rendue ou exportée, par exemple vers PDF, images et autres formats pris en charge. Cela permet de conserver une sortie de présentation cohérente dans différents environnements. L’article explique également comment inspecter les dossiers de polices utilisés par Aspose.Slides et comment vider le cache des polices après avoir travaillé avec des polices externes.

L’enregistrement de polices personnalisées pour le rendu est distinct de l’intégration de polices dans un fichier PPTX. Si une police doit être stockée à l’intérieur de la présentation elle‑même, utilisez explicitement les fonctionnalités d’intégration de polices.

Un thème de présentation peut référencer différentes familles de polices pour des systèmes d’écriture individuels. Ces mappages stockent les noms de polices mais n’installent ni ne chargent les fichiers de polices. Consultez [Script-Specific Theme Fonts](/slides/fr/python-java/script-specific-font-mappings/) pour gérer les mappages, et utilisez les options de chargement ci‑dessous pour rendre les polices référencées disponibles pour un rendu cohérent.

{{% alert color="info" title="Note" %}}

Aspose.Slides vous permet de charger ces polices à l’aide de la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFonts) :

* Polices TrueType (.ttf) et TrueType Collection (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d’exportation — comme le PDF, les images et autres formats pris en charge — afin que les documents résultants aient le même aspect dans tous les environnements. Les polices sont chargées depuis des répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de polices.
2. Appelez la méthode statique [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFonts) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.clearCache](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#clearCache) pour vider le cache des polices.

L’exemple de code suivant illustre le processus de chargement des polices :

```python
from jpype import JArray, JString
from asposeslides.api import FontsLoader, Presentation, SaveFormat

# Définir les dossiers contenant les fichiers de polices personnalisées.
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])

# Charger les polices personnalisées depuis les dossiers spécifiés.
FontsLoader.loadExternalFonts(font_folders)

presentation = None
try:
    presentation = Presentation("sample.pptx")

    # Rendre/exporter la présentation en utilisant les polices chargées.
    presentation.save("output.pdf", SaveFormat.Pdf)
finally:
    if presentation is not None:
        presentation.dispose()

    # Vider le cache des polices après la fin du travail.
    FontsLoader.clearCache()
```

{{% alert color="info" title="Note" %}}

[FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFonts) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l’ordre d’initialisation des polices.
Les polices sont initialisées dans cet ordre :

1. Le chemin de polices par défaut du système d’exploitation.
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir les dossiers de polices personnalisées**
Aspose.Slides fournit la méthode [getFontFolders](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#getFontFolders) qui vous permet de trouver les dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode [loadExternalFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFonts) ainsi que les dossiers de polices du système.

Ce code Python montre comment utiliser [getFontFolders](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#getFontFolders) :

```python
from asposeslides.api import FontsLoader

# Obtenir les dossiers ajoutés via loadExternalFonts et les dossiers de polices système.
font_folders = FontsLoader.getFontFolders()
```

## **Spécifier les polices personnalisées utilisées avec une présentation**
Aspose.Slides fournit la méthode [getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) qui vous permet de spécifier les polices externes qui seront utilisées avec la présentation.

Ce code Python montre comment utiliser la méthode [getDocumentLevelFontSources](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadoptions/#getDocumentLevelFontSources) :

```python
from pathlib import Path
from jpype import JArray, JByte, JString
from asposeslides.api import LoadOptions, Presentation

memory_font_primary = Path("customfonts/CustomFont1.ttf").read_bytes()
memory_font_secondary = Path("customfonts/CustomFont2.ttf").read_bytes()

load_options = LoadOptions()
font_folders = JArray(JString)(["assets/fonts", "global/fonts"])
memory_fonts = JArray(JByte, 2)([memory_font_primary, memory_font_secondary])
load_options.getDocumentLevelFontSources().setFontFolders(font_folders)
load_options.getDocumentLevelFontSources().setMemoryFonts(memory_fonts)

presentation = Presentation("MyPresentation.pptx", load_options)
try:
    # Travailler avec la présentation.
    # CustomFont1, CustomFont2, et les polices provenant de assets/fonts et global/fonts
    # et leurs sous-dossiers sont disponibles pour la présentation.
    pass
finally:
    presentation.dispose()
```

## **Gérer les polices de façon externe**

Aspose.Slides fournit la méthode [loadExternalFont](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsloader/#loadExternalFont) qui vous permet de charger des polices externes à partir de données binaires.

Ce code Python démontre le processus de chargement de police à partir d’un tableau d’octets :

```python
from pathlib import Path
from jpype import JArray, JByte
from asposeslides.api import FontsLoader, Presentation

font_data = Path("ARIALN.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNBI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))
font_data = Path("ARIALNI.TTF").read_bytes()
FontsLoader.loadExternalFont(JArray(JByte)(font_data))

try:
    presentation = Presentation()
    try:
        # Les polices externes sont chargées pendant la durée de vie de la présentation.
        pass
    finally:
        presentation.dispose()
finally:
    FontsLoader.clearCache()
```

## **FAQ**

**Les polices personnalisées affectent-elles l’exportation vers tous les formats (PDF, PNG, SVG, HTML) ?**

Oui. Les polices connectées sont utilisées par le moteur de rendu pour tous les formats d’exportation.

**Les polices personnalisées sont‑elles automatiquement intégrées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n’est pas équivalent à l’intégrer dans un PPTX. Si vous avez besoin que la police soit contenue dans le fichier de présentation, vous devez utiliser explicitement les [fonctionnalités d’intégration](/slides/fr/python-java/embedded-font/).

**Puis‑je contrôler le comportement de secours lorsqu’une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de polices](/slides/fr/python-java/font-substitution/), les [règles de remplacement](/slides/fr/python-java/font-replacement/) et les [ensembles de secours](/slides/fr/python-java/fallback-font/) pour définir exactement la police à utiliser lorsque le glyphe demandé est absent.

**Puis‑je utiliser des polices sous Linux/Docker sans les installer globalement ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d’octets. Cela élimine toute dépendance aux répertoires de polices du système dans l’image du conteneur.

**Qu’en est‑il de la licence — puis‑je intégrer n’importe quelle police personnalisée sans restriction ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l’intégration ou l’utilisation commerciale. Vérifiez toujours le contrat de licence (EULA) de la police avant de distribuer les résultats.