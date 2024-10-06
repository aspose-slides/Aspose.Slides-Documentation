---
title: Police PowerPoint personnalisée en Python
linktitle: Police personnalisée
type: docs
weight: 20
url: /python-net/custom-font/
keywords: "Polices, polices personnalisées, présentation PowerPoint, Python, Aspose.Slides pour Python via .NET"
description: "Polices personnalisées PowerPoint en Python"
---

{{% alert color="primary" %}} 

Aspose Slides permet de charger ces polices en utilisant la méthode `load_external_fonts` de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) :

* Polices TrueType (.ttf) et collection TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Charger des polices personnalisées**

Aspose.Slides vous permet de charger des polices qui sont rendues dans les présentations sans avoir à les installer. Les polices sont chargées à partir d'un répertoire personnalisé.

1. Créez une instance de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) et appelez la méthode `load_external_fonts`.
2. Chargez la présentation qui sera rendue.
3. Videz le cache de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

Ce code Python démontre le processus de chargement de polices :

```python
import aspose.slides as slides

# Le chemin vers le répertoire des documents.
dataDir = "C:\\"

# dossiers pour rechercher des polices
folders = [ dataDir ]

# Charge les polices du répertoire personnalisé
slides.FontsLoader.load_external_fonts(folders)

# Faites un travail et effectuez le rendu de la présentation / des diapositives
with slides.Presentation(path + "DefaultFonts.pptx") as presentation:
    presentation.save("NewFonts_out.pptx", slides.export.SaveFormat.PPTX)

# Vider le cache des polices
slides.FontsLoader.clear_cache()
```

## **Obtenir le dossier des polices personnalisées**
Aspose.Slides fournit la méthode `get_font_folders()` pour vous permettre de trouver des dossiers de polices. Cette méthode renvoie les dossiers ajoutés via la méthode `LoadExternalFonts` et les dossiers de polices système.

Ce code Python vous montre comment utiliser `get_font_folders()` :

```python
#  Cette ligne affiche les dossiers vérifiés pour les fichiers de polices.
# Ce sont des dossiers ajoutés via la méthode load_external_fonts et des dossiers de polices système.
fontFolders = slides.FontsLoader.get_font_folders()

```


## **Spécifiez les polices personnalisées utilisées avec la présentation**
Aspose.Slides fournit la propriété `document_level_font_sources` pour vous permettre de spécifier des polices externes qui seront utilisées avec la présentation.

Ce code Python vous montre comment utiliser la propriété `document_level_font_sources` :

```python
import aspose.slides as slides

with open(path + "CustomFont1.ttf", "br") as font1:
    memoryFont1 = font1.read()
    with open(path + "CustomFont2.ttf", "br") as font2:
        memoryFont2 = font2.read()

        loadOptions = slides.LoadOptions()
        loadOptions.document_level_font_sources.font_folders =  ["assets\\fonts", "global\\fonts"] 
        loadOptions.document_level_font_sources.memory_fonts = [ memoryFont1, memoryFont2 ]
        with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as presentation:
            # Travailler avec la présentation
            # CustomFont1, CustomFont2, et les polices des dossiers assets\fonts & global\fonts et leurs sous-dossiers sont disponibles pour la présentation
            print(len(presentation.slides))
```

## **Gérer les polices de manière externe**

Aspose.Slides fournit la méthode `load_external_font`(data) pour vous permettre de charger des polices externes à partir de données binaires.

Ce code Python démontre le processus de chargement de polices à partir d'un tableau d'octets :

```python
from aspose.slides import FontsLoader, Presentation

def read_all_bytes(path):
    with open(path, "rb") as in_file:
        bytes = in_file.read()
    return bytes

FontsLoader.load_external_font(read_all_bytes("ARIALN.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNBI.TTF"))
FontsLoader.load_external_font(read_all_bytes("ARIALNI.TTF"))

try:
    with Presentation() as pres:
        # police externe chargée pendant la durée de vie de la présentation
        print("traitement")
finally:
    FontsLoader.clear_cache()

```