---
title: Enregistrer des présentations en Python
linktitle: Enregistrer des présentations
type: docs
weight: 80
url: /fr/python-net/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer une présentation
- enregistrer une diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation vers fichier
- présentation vers flux
- type de vue prédéfini
- format Strict Office Open XML
- mode Zip64
- actualisation de la miniature
- progression de l'enregistrement
- Python
- Aspose.Slides
description: "Découvrez comment enregistrer des présentations en Python avec Aspose.Slides — exportez vers PowerPoint ou OpenDocument tout en conservant la mise en page, les polices et les effets."
---
## **Vue d'ensemble**

[Ouvrir une présentation en Python](/slides/fr/python-net/open-presentation/) décrivait comment utiliser la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) pour ouvrir une présentation. Cet article explique comment créer et enregistrer des présentations. La classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) contient le contenu d’une présentation. Que vous créiez une présentation à partir de zéro ou que vous modifiiez une présentation existante, vous voudrez l’enregistrer une fois terminé. Avec Aspose.Slides pour Python, vous pouvez enregistrer dans un **fichier** ou un **flux**. Cet article explique les différentes manières d’enregistrer une présentation.

## **Enregistrer des présentations dans des fichiers**

Enregistrez une présentation dans un fichier en appelant la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Passez le nom de fichier et le format d’enregistrement à la méthode. L’exemple suivant montre comment enregistrer une présentation avec Aspose.Slides pour Python.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    
    # Effectuer un travail ici...

    # Enregistrer la présentation dans un fichier.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Enregistrer des présentations dans des flux**

Vous pouvez enregistrer une présentation dans un flux en passant un flux de sortie à la méthode `save` de la classe [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Une présentation peut être écrite vers de nombreux types de flux. Dans l’exemple ci‑dessous, nous créons une nouvelle présentation et l’enregistrons dans un flux de fichier.

```py
import aspose.slides as slides

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    with open("output.pptx", "bw") as file_stream:
        # Enregistrer la présentation dans le flux.
        presentation.save(file_stream, slides.export.SaveFormat.PPTX)
```

## **Enregistrer des présentations avec un type de vue prédéfini**

Aspose.Slides pour Python vous permet de définir la vue initiale que PowerPoint utilise lorsque la présentation générée s’ouvre via la classe [ViewProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewproperties/). Définissez la propriété `last_view` sur une valeur de l’énumération [ViewType](https://reference.aspose.com/slides/fr/python-net/aspose.slides/viewtype/).

```py
import aspose.slides as slides

with slides.Presentation() as presentation:
    presentation.view_properties.last_view = slides.ViewType.SLIDE_MASTER_VIEW
    presentation.save("slide_master_view.pptx", slides.export.SaveFormat.PPTX)
```

## **Enregistrer des présentations au format Strict Office Open XML**

Aspose.Slides vous permet d’enregistrer une présentation au format Strict Office Open XML. Utilisez la classe [PptxOptions](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/) et définissez sa propriété `conformance` lors de l’enregistrement. Si vous définissez `Conformance.ISO_29500_2008_STRICT`, le fichier de sortie est enregistré au format Strict Office Open XML.

L’exemple ci‑dessous crée une présentation et l’enregistre au format Strict Office Open XML.

```py
import aspose.slides as slides

options = slides.export.PptxOptions()
options.conformance = slides.export.Conformance.ISO_29500_2008_STRICT

# Instancier la classe Presentation qui représente un fichier de présentation.
with slides.Presentation() as presentation:
    # Enregistrer la présentation au format Strict Office Open XML.
    presentation.save("strict_office_open_xml.pptx", slides.export.SaveFormat.PPTX, options)
```

## **Enregistrer des présentations au format Office Open XML en mode Zip64**

Un fichier Office Open XML est une archive ZIP qui impose des limites de 4 Go (2^32 octets) sur la taille non compressée d’un fichier, la taille compressée d’un fichier et la taille totale de l’archive, ainsi qu’une limite de 65 535 (2^16‑1) fichiers. Les extensions du format ZIP64 élèvent ces limites à 2^64.

La propriété [PptxOptions.zip_64_mode](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/zip_64_mode/) vous permet de choisir quand utiliser les extensions du format ZIP64 lors de l’enregistrement d’un fichier Office Open XML.

Cette propriété propose les modes suivants :

- `IF_NECESSARY` utilise les extensions ZIP64 uniquement si la présentation dépasse les limites ci‑dessus. C’est le mode par défaut.
- `NEVER` n’utilise jamais les extensions ZIP64.
- `ALWAYS` utilise toujours les extensions ZIP64.

Le code suivant montre comment enregistrer une présentation en tant que fichier PPTX avec les extensions ZIP64 activées :

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.zip_64_mode = slides.export.Zip64Mode.ALWAYS

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output_zip64.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="NOTE" color="warning" %}}

Lorsque vous enregistrez avec `Zip64Mode.NEVER`, une [PptxException](https://reference.aspose.com/slides/fr/python-net/aspose.slides/pptxexception/) est levée si la présentation ne peut pas être enregistrée au format ZIP32.

{{% /alert %}}

## **Enregistrer des présentations au format Office Open XML avec niveaux de compression**

Lorsque vous travaillez avec de grandes présentations, vous pouvez ajuster le niveau de compression afin d’équilibrer la taille du fichier et le temps de traitement. En fonction de vos besoins, vous pouvez privilégier un traitement plus rapide ou des fichiers de sortie plus petits.

Aspose.Slides fournit la propriété [PptxOptions.compression_level](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/compression_level/), qui vous permet de spécifier le niveau de compression utilisé lors de l’enregistrement d’une présentation au format Office Open XML.

Les niveaux de compression suivants sont disponibles :

- [**NONE**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): aucune compression n’est appliquée. Les fichiers sont stockés tels quels.
- [**LEVEL1**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): la compression la plus rapide avec le taux de compression le plus bas.
- [**LEVEL2**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): compression plus rapide avec un taux de compression légèrement meilleur que **LEVEL1**.
- [**LEVEL3**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): offre une meilleure compression que **LEVEL2** avec un impact modéré sur le temps de traitement.
- [**LEVEL4**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): offre une meilleure compression que **LEVEL3**.
- [**LEVEL5**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): améliore la compression par rapport à **LEVEL4** avec un temps de traitement supplémentaire.
- [**LEVEL6**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): compression standard offrant un bon équilibre entre vitesse de traitement et taille du fichier. C’est le *niveau de compression par défaut*.
- [**LEVEL7**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): offre une meilleure compression que **LEVEL6** avec un traitement plus lent.
- [**LEVEL8**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): offre une meilleure compression que **LEVEL7**.
- [**LEVEL9**](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/compressionlevel/): compression maximale. Produit la plus petite taille de fichier au prix du temps de traitement le plus long.

L’exemple suivant montre comment enregistrer une présentation en tant que fichier PPTX *sans compression* :

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.NONE

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_out.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

Cet exemple montre comment enregistrer une présentation en tant que fichier PPTX avec *la compression maximale* :

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.compression_level = slides.export.CompressionLevel.LEVEL9

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("sample_level9.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

## **Enregistrer des présentations sans actualiser la miniature**

La propriété [PptxOptions.refresh_thumbnail](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/pptxoptions/refresh_thumbnail/) contrôle la génération de la miniature lors de l’enregistrement d’une présentation au format PPTX :

- Si elle est définie sur `True`, la miniature est actualisée lors de l’enregistrement. C’est la valeur par défaut.
- Si elle est définie sur `False`, la miniature actuelle est conservée. Si la présentation n’a pas de miniature, aucune n’est générée.

Dans le code ci‑dessous, la présentation est enregistrée au format PPTX sans actualiser sa miniature.

```py
import aspose.slides as slides

pptx_options = slides.export.PptxOptions()
pptx_options.refresh_thumbnail = False

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX, pptx_options)
```

{{% alert title="Info" color="info" %}}

Cette option permet de réduire le temps nécessaire pour enregistrer une présentation au format PPTX.

{{% /alert %}}

{{% alert title="Info" color="info" %}}

Aspose a développé une [application gratuite PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) utilisant sa propre API. L’application vous permet de scinder une présentation en plusieurs fichiers en enregistrant les diapositives sélectionnées en tant que nouveaux fichiers PPTX ou PPT.

{{% /alert %}}

## **FAQ**

**La sauvegarde rapide (sauvegarde incrémentielle) est‑elle prise en charge afin que seules les modifications soient écrites ?**

Non. L’enregistrement crée le fichier complet à chaque fois ; la sauvegarde incrémentielle « fast save » n’est pas prise en charge.

**Est‑il sûr d’enregistrer la même instance Presentation depuis plusieurs threads ?**

Non. Une instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) n’est pas sûre pour le multithreading ; enregistrez‑la depuis un seul thread.

**Que se passe‑t‑il pour les hyperliens et les fichiers liés externement lors de l’enregistrement ?**

[Hyperlinks](/slides/fr/python-net/manage-hyperlinks/) sont conservés. Les fichiers liés externes (par exemple, des vidéos via des chemins relatifs) ne sont pas copiés automatiquement — assurez‑vous que les chemins référencés restent accessibles.

**Puis‑je définir/enregistrer les métadonnées du document (Auteur, Titre, Société, Date) ?**

Oui. Les propriétés standard du document sont prises en charge et seront écrites dans le fichier lors de l’enregistrement.