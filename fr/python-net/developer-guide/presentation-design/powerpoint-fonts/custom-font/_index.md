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
- dossier de police
- PowerPoint
- présentation
- Python
- Aspose.Slides
description: "Intégrez des polices personnalisées dans les diapositives PowerPoint avec Aspose.Slides pour Python via .NET afin de garder vos présentations nettes et cohérentes sur tout appareil."
---

## **Aperçu**

Aspose.Slides pour Python vous permet de fournir des polices personnalisées à l'exécution afin que les présentations s'affichent correctement même lorsque les polices requises ne sont pas installées sur le système hôte. Lors de l'exportation vers PDF ou images, vous pouvez fournir des dossiers de polices ou des données de police en mémoire afin de conserver la mise en page du texte, les métriques des glyphes et la typographie. Cela rend le rendu côté serveur prévisible entre différents environnements, supprime les dépendances aux polices du système d'exploitation et évite les substitutions ou les réajustements indésirables. L'article montre comment enregistrer des sources de polices.

Aspose.Slides vous permet de charger les polices suivantes à l'aide des méthodes `load_external_font` et `load_external_fonts` de la classe [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/) :

- Polices TrueType (.ttf) et collections TrueType (.ttc). Voir [TrueType](https://en.wikipedia.org/wiki/TrueType).
- Polices OpenType (.otf). Voir [OpenType](https://en.wikipedia.org/wiki/OpenType).

## **Charger des polices personnalisées**

Aspose.Slides permet de charger les polices utilisées dans une présentation sans les installer sur le système. Cela affecte la sortie d'exportation — comme PDF, images et autres formats pris en charge — afin que les documents résultants conservent la même apparence entre les environnements. Les polices sont chargées à partir de répertoires personnalisés.

1. Spécifiez un ou plusieurs dossiers contenant les fichiers de police.
2. Appelez la méthode statique [FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) pour charger les polices depuis ces dossiers.
3. Chargez et rendez/exportez la présentation.
4. Appelez [FontsLoader.clear_cache](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/clear_cache/) pour vider le cache des polices.

L'exemple de code suivant montre le processus de chargement des polices :
```py
import aspose.slides as slides

# Définir les dossiers contenant les fichiers de polices personnalisées.
font_folders = [ external_font_folder1, external_font_folder2 ]

# Charger les polices personnalisées depuis les dossiers spécifiés.
slides.FontsLoader.load_external_fonts(font_folders)

with slides.Presentation("sample.pptx") as presentation:
    # Rendre/exporter la présentation (p. ex., en PDF, images ou autres formats) en utilisant les polices chargées.
    presentation.save("output.pdf", slides.export.SaveFormat.PDF)

# Vider le cache des polices après la fin du travail.
slides.FontsLoader.clear_cache()
```


{{% alert color="info" title="Note" %}}

[FontsLoader.load_external_fonts](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/load_external_fonts/) ajoute des dossiers supplémentaires aux chemins de recherche des polices, mais ne modifie pas l'ordre d'initialisation des polices.  
Les polices sont initialisées dans cet ordre :

1. Le chemin de police par défaut du système d'exploitation.  
1. Les chemins chargés via [FontsLoader](https://reference.aspose.com/slides/python-net/aspose.slides/fontsloader/).

{{%/alert %}}

## **Obtenir le dossier des polices personnalisées**

Aspose.Slides fournit la méthode `get_font_folders` pour récupérer les dossiers de polices. Elle renvoie à la fois les dossiers ajoutés via `load_external_fonts` et les dossiers de polices du système.

Ce code Python montre comment utiliser `get_font_folders` :
```python
import aspose.slides as slides

# Cet appel renvoie les dossiers vérifiés pour les fichiers de police.
# Ils comprennent les dossiers ajoutés via la méthode load_external_fonts ainsi que les dossiers de polices du système.
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
    # CustomFont1, CustomFont2 et les polices provenant des dossiers assets\fonts et global\fonts (ainsi que leurs sous-dossiers) sont disponibles pour la présentation.
    # ...
    print(len(presentation.slides))
```


## **Charger des polices externes à partir de données binaires**

Aspose.Slides fournit la méthode `load_external_font` pour charger des polices externes à partir de données binaires.

L'exemple Python suivant démontre le chargement d'une police à partir d'un tableau d'octets :
```python
import aspose.slides as slides

def read_all_bytes(file_path):
    with open(file_path, "rb") as file_stream:
        file_data = file_stream.read()
    return file_data

# Charger des polices externes depuis des tableaux d'octets.
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

**Les polices personnalisées sont-elles automatiquement incorporées dans le PPTX résultant ?**

Non. Enregistrer une police pour le rendu n'est pas équivalent à l'incorporer dans un PPTX. Si vous avez besoin que la police soit incluse dans le fichier de présentation, vous devez utiliser les fonctions d'[incorporation](/slides/fr/python-net/embedded-font/).

**Puis‑je contrôler le comportement de substitution lorsqu'une police personnalisée ne possède pas certains glyphes ?**

Oui. Configurez la [substitution de polices](/slides/fr/python-net/font-substitution/), les [règles de remplacement](/slides/fr/python-net/font-replacement/) et les [ensembles de secours](/slides/fr/python-net/fallback-font/) pour définir exactement quelle police est utilisée lorsqu'un glyphe demandé est absent.

**Puis‑je utiliser des polices sous Linux/Docker sans les installer system‑wide ?**

Oui. Pointez vers vos propres dossiers de polices ou chargez des polices à partir de tableaux d'octets. Cela supprime toute dépendance aux répertoires de polices du système dans l'image du conteneur.

**Qu'en est‑il de la licence — puis‑je incorporer n'importe quelle police personnalisée sans restriction ?**

Vous êtes responsable du respect des licences des polices. Les conditions varient ; certaines licences interdisent l'incorporation ou l'utilisation commerciale. Examinez toujours le contrat de licence de la police (EULA) avant de distribuer les résultats.