---
title: Enregistrer des présentations en Python
linktitle: Enregistrer une présentation
type: docs
weight: 80
url: /fr/python-net/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer présentation
- enregistrer diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Office Open XML strict
- mode Zip64
- actualisation de la vignette
- progression de l’enregistrement
- Python
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument dans des fichiers ou des flux en Python avec Aspose.Slides, et configurez les options de sortie PPTX."
---
## **Vue d'ensemble**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/python-net/open-presentation/), utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/) pour enregistrer le résultat. Aspose.Slides for Python via .NET peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et d’autres formats. Les sections suivantes couvrent les opérations d’enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer les présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L’exemple suivant crée une présentation et l’enregistre au format PPTX :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Ajouter ou modifier le contenu de la présentation ici.

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX)
```

## **Enregistrer les présentations dans leur format d'origine**

Pour les exemples de détection de fichier et de flux, le comportement des présentations nouvellement créées et la distinction entre les formats source et de sortie, consultez [Determine the Original Presentation Format](/slides/fr/python-net/detect-presentation-source-format/).

Dans une application de traitement par lots, le format d’entrée peut ne pas être connu à l’avance. Après avoir chargé un fichier, lisez son format d’origine à partir de la propriété [Presentation.source_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/source_format/). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sourceformat/) ainsi obtenue à [SlideUtil.to_save_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/to_save_format/) pour obtenir la valeur [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) correspondante, puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/) pour écrire la présentation modifiée.

L’exemple complet suivant traite chaque fichier d’un répertoire d’entrée, met à jour son titre et l’enregistre dans un répertoire de sortie au même format que celui d’origine :

```py
from pathlib import Path

import aspose.slides as slides
from aspose.slides.util import SlideUtil

input_directory = Path("Input")
output_directory = Path("Output")

output_directory.mkdir(exist_ok=True)

for input_path in input_directory.iterdir():
    if not input_path.is_file():
        continue

    try:
        with slides.Presentation(str(input_path)) as presentation:
            source_format = presentation.source_format
            save_format = SlideUtil.to_save_format(source_format)

            presentation.document_properties.title = "Processed by the batch application"

            output_path = output_directory / input_path.name
            presentation.save(str(output_path), save_format)
    except Exception as exception:
        print(f"Cannot process '{input_path}': {exception}")
```

[SlideUtil.to_save_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides.util/slideutil/to_save_format/) associe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML à leurs formats d’enregistrement correspondants. Il ne mappe que les formats source de présentation ; il ne doit pas être utilisé pour sélectionner des formats d’exportation tels que PDF, HTML, TIFF ou images. Fournir une valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sourceformat/) non prise en charge ou invalide déclenche une exception.

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu’une telle présentation est chargée à partir d’un flux sans extension de fichier, un fichier PPS ou POT peut alors être identifié comme PPT. Si la conservation de ces sous‑types hérités est requise, conservez séparément le nom de fichier ou les métadonnées de format d’origine et utilisez‑les lors du choix du nom de fichier et du format de sortie.

## **Enregistrer les présentations dans des flux**

Pour écrire une présentation sans recourir à un chemin de fichier final, transmettez un flux [BinaryIO](https://docs.python.org/3/library/typing.html#typing.BinaryIO) accessible en écriture et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service Web, stockée dans une base de données ou traitée en mémoire.

L’exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    with open("Output.pptx", "wb") as output_stream:
        presentation.save(output_stream, slides.export.SaveFormat.PPTX)
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Définissez la propriété [ViewProperties.last_view](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/last_view/) sur une valeur [ViewType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewtype/) avant l’enregistrement.

L’exemple suivant configure la vue Masque des diapositives comme vue initiale :

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("SlideMasterView.pptx", slides.export.SaveFormat.PPTX)
```

## **Enregistrer les présentations au format Office Open XML strict**

Pour créer un fichier PPTX conforme au profil Strict d’Office Open XML, créez une instance de [PptxOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/) et définissez sa propriété [conformance](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/conformance/) sur `Conformance.ISO_29500_2008_STRICT`. Transmettez ensuite les options à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-net/aspose.slides/ipresentation/save/).

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

with slides.Presentation() as presentation:
    presentation.save("StrictOfficeOpenXml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l’archive et le nombre d’entrées. Comme un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d’entrées applicables.

Utilisez la propriété [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- `IF_NECESSARY` utilise ZIP64 uniquement lorsque la présentation dépasse les limites ZIP standard. C’est le mode par défaut.
- `NEVER` désactive les extensions ZIP64.
- `ALWAYS` écrit toujours les extensions ZIP64.

L’exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

    presentation.save("OutputZip64.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="warning" title="Warning" %}}
Si `Zip64Mode.NEVER` est utilisé et que la présentation ne tient pas dans les limites ZIP standard, l’opération d’enregistrement déclenche une [PptxException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec des niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d’enregistrement et la taille du fichier en définissant la propriété [PptxOptions.compression_level](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/compression_level/). L’énumération [CompressionLevel](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/) propose les valeurs suivantes :

- `NONE` stocke les données sans compression.
- `LEVEL1` offre la compression la plus rapide et le fichier compressé le plus volumineux.
- `LEVEL2` à `LEVEL5` favorisent progressivement une taille de sortie plus petite au détriment de la vitesse d’enregistrement.
- `LEVEL6` équilibre vitesse d’enregistrement et taille du fichier. C’est le niveau par défaut.
- `LEVEL7` et `LEVEL8` privilégient davantage une taille de sortie réduite.
- `LEVEL9` fournit la compression la plus forte et nécessite le plus de temps de traitement.

L’exemple suivant enregistre une présentation sans compression :

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.NONE

    presentation.save("OutputNoCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

L’exemple suivant utilise le niveau de compression maximal :

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.compression_level = slides.export.CompressionLevel.LEVEL9

    presentation.save("OutputMaximumCompression.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Enregistrer les présentations sans actualiser la vignette**

Lorsque une présentation est enregistrée au format PPTX, la propriété [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) contrôle la vignette du document :

- `True` régénère la vignette pendant l’opération d’enregistrement. C’est la valeur par défaut.
- `False` conserve la vignette existante. Si la présentation ne possède pas de vignette, Aspose.Slides n’en crée pas.

L’exemple suivant enregistre une présentation sans actualiser sa vignette :

```py
import aspose.slides as slides

with slides.Presentation("Sample.pptx") as presentation:
    options = slides.export.PptxOptions()
    options.refresh_thumbnail = False

    presentation.save("Output.pptx", slides.export.SaveFormat.PPTX, options)
```

{{% alert color="info" title="Note" %}}
Désactiver l’actualisation de la vignette peut réduire le temps nécessaire à l’enregistrement d’un fichier PPTX.
{{% /alert %}}

{{% alert color="info" title="Note" %}}
Aspose propose un **PowerPoint Splitter** gratuit (https://products.aspose.app/slides/fr/splitter) construit avec l’API Aspose.Slides. Il enregistre les diapositives sélectionnées d’une présentation en fichiers PPT ou PPTX séparés.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge l’enregistrement incrémentiel ou le « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier complet plutôt que de mettre à jour uniquement les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance de Presentation ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) **n’est pas thread‑safe** (/slides/fr/python-net/multithreading/). Accédez et enregistrez chaque instance depuis un seul thread à la fois.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement d’une présentation ?**

Les [hyperliens](/slides/fr/python-net/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, de sorte que la présentation enregistrée doit toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/python-net/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.