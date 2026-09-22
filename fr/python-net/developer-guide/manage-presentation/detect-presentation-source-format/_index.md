---
title: Déterminer le format d’origine de la présentation en Python
linktitle: Format source
type: docs
weight: 35
url: /fr/python-net/detect-presentation-source-format/
keywords:
- format source
- détecter le format de présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- Python
- Aspose.Slides
description: "Lire le format d’origine d’une présentation chargée en Python avec Aspose.Slides for Python via .NET, comparer les API de détection et gérer les fichiers, les flux et les formats hérités."
---
## **Vue d'ensemble**

Après le chargement d’une présentation, lisez la propriété en lecture seule [Presentation.source_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/source_format/) pour déterminer son format d’origine. Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l’instance courante a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) sélectionné pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l’instance existante.

## **Lire le format source d’un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d’application en utilisant [Presentation.source_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/source_format/), plutôt que le nom de fichier. Changez le chemin d’entrée pour essayer d’autres formats. L’exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    source_format = presentation.source_format
    if source_format in (slides.SourceFormat.PPT, slides.SourceFormat.PPS, slides.SourceFormat.POT):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == slides.SourceFormat.PPTX:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for {source_format.name}.")
```

## **Reconnaître les valeurs prises en charge**

L’énumération [SourceFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sourceformat/) distingue les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, et non une reconstruction du nom de fichier d’origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `PPT` | `.ppt` | présentation PowerPoint 97–2003 |
| `PPTX` | `.pptx` | présentation Office Open XML |
| `PPTM` | `.pptm` | présentation Office Open XML avec macros |
| `PPS` | `.pps` | diaporama PowerPoint 97–2003 |
| `PPSX` | `.ppsx` | diaporama Office Open XML |
| `PPSM` | `.ppsm` | diaporama Office Open XML avec macros |
| `POT` | `.pot` | modèle PowerPoint 97–2003 |
| `POTX` | `.potx` | modèle Office Open XML |
| `POTM` | `.potm` | modèle Office Open XML avec macros |
| `ODP` | `.odp` | présentation OpenDocument |
| `OTP` | `.otp` | modèle de présentation OpenDocument |
| `FODP` | `.fodp` | présentation ODF XML plat |
| `XML` | `.xml` | présentation PowerPoint XML |

## **Lire le format source d’un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire modélise une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d’octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) ne reçoit que le flux.

```python
import io
import aspose.slides as slides

with open("sample.pps", "rb") as input_file:
    data = input_file.read()

with io.BytesIO(data) as stream:
    with slides.Presentation(stream) as presentation:
        print(f"Source format: {presentation.source_format.name}")
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l’extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu legacy PPS et POT peut être signalé comme `SourceFormat.PPT` ; l’exemple PPS ci‑dessus signale `PPT`.

Si votre application doit conserver la distinction, conservez le nom de fichier d’origine ou les métadonnées de sous‑type séparément. Une extension est un indice utile pour ces sous‑types hérités, mais ne doit pas être le seul critère pour identifier un contenu de présentation arbitraire.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) et [PresentationInfo.load_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/load_format/) lorsque vous devez inspecter un fichier avant de charger son modèle d’objet de présentation complet. Utilisez [Presentation.source_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/source_format/) lorsque l’instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche `PPTX` pour les deux vérifications. En production, choisissez l’API appropriée à votre étape de traitement ; une présentation déjà chargée n’a pas besoin d’une seconde inspection uniquement pour obtenir son format source.

```python
import aspose.slides as slides

path = "sample.pptx"
information = slides.PresentationFactory.instance.get_presentation_info(path)
print(f"Before loading: {information.load_format.name}")

with slides.Presentation(path) as presentation:
    print(f"After loading: {presentation.source_format.name}")
```

Les résultats ont différents types d’énumération : [LoadFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sourceformat/). Ne les comparez pas en castant leurs valeurs numériques ou en supposant que chaque format possède des résultats de détection identiques. Dans le contrôle de sauvegarde‑et‑reouverture décrit ci‑dessous, PowerPoint XML était signalé comme `LoadFormat.UNKNOWN` avant le chargement et `SourceFormat.XML` après le chargement.

## **Conserver séparément les formats source et de sortie**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche `PPTX` avant et après l’enregistrement de l’instance originale. Seule la nouvelle instance chargée à partir du fichier ODP de sortie signale `ODP`.

```python
import aspose.slides as slides

with slides.Presentation("sample.pptx") as presentation:
    print(f"Before saving: {presentation.source_format.name}")

    presentation.save("converted.odp", slides.export.SaveFormat.ODP)
    print(f"After saving: {presentation.source_format.name}")

with slides.Presentation("converted.odp") as reopened:
    print(f"Reopened output: {reopened.source_format.name}")
```

Une présentation créée à partir de zéro avec `slides.Presentation()` signale `SourceFormat.PPTX`. Elle n’a pas de fichier d’entrée : il s’agit de la valeur par défaut pour une instance nouvellement créée, pas la preuve qu’un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l’instance si cette distinction est importante.

## **Associer un format source à une extension**

L’exemple suivant nécessite `sample.pptx`. Il associe chaque valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides/sourceformat/) actuellement prise en charge à une extension conventionnelle, sans analyser le nom de fichier d’entrée. Le repli évite d’attribuer silencieusement une extension à une valeur non reconnue.

```python
import aspose.slides as slides

extensions = {
    slides.SourceFormat.PPT: ".ppt",
    slides.SourceFormat.PPTX: ".pptx",
    slides.SourceFormat.PPTM: ".pptm",
    slides.SourceFormat.PPS: ".pps",
    slides.SourceFormat.PPSX: ".ppsx",
    slides.SourceFormat.PPSM: ".ppsm",
    slides.SourceFormat.POT: ".pot",
    slides.SourceFormat.POTX: ".potx",
    slides.SourceFormat.POTM: ".potm",
    slides.SourceFormat.ODP: ".odp",
    slides.SourceFormat.OTP: ".otp",
    slides.SourceFormat.FODP: ".fodp",
    slides.SourceFormat.XML: ".xml",
}

with slides.Presentation("sample.pptx") as presentation:
    extension = extensions.get(presentation.source_format)
    print(extension if extension is not None else "No extension mapping is available.")
```

Cette correspondance ne convertit pas un fichier ni ne récupère un sous‑type legacy PPS/POT perdu lors du chargement depuis un flux. Pour l’enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/python-net/aspose.slides.export/saveformat/) ou utilisez la conversion présentée dans [Save Presentations in Their Original Format](/slides/fr/python-net/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, écrasant les fichiers du même nom. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux routes signalent le format enregistré. Pour PPS, le chargement par chemin signale `PPS`, tandis que le chargement des mêmes octets sans nom de fichier signale `PPT`.

```python
import io
import aspose.slides as slides

formats = [slides.export.SaveFormat.PPTX, slides.export.SaveFormat.ODP, slides.export.SaveFormat.PPS]

with slides.Presentation() as presentation:
    for output_format in formats:
        path = f"roundtrip.{output_format.name.lower()}"
        presentation.save(path, output_format)

        with open(path, "rb") as input_file:
            data = input_file.read()

        with slides.Presentation(path) as from_file:
            with io.BytesIO(data) as stream:
                with slides.Presentation(stream) as from_stream:
                    print(f"{output_format.name}: file={from_file.source_format.name}, stream={from_stream.source_format.name}")
```

Le même contrôle avec tous les formats listés ci‑dessus a produit les résultats suivants pour les présentations générées avec des extensions correspondantes :

| Format enregistré | SourceFormat depuis un chemin de fichier | SourceFormat depuis un flux sans nom |
| --- | --- | --- |
| PPT | `PPT` | `PPT` |
| PPTX, PPTM | `PPTX`, `PPTM` respectivement | Identique au chemin de fichier |
| PPS | `PPS` | `PPT` |
| PPSX, PPSM | `PPSX`, `PPSM` respectivement | Identique au chemin de fichier |
| POT | `POT` | `PPT` |
| POTX, POTM | `POTX`, `POTM` respectivement | Identique au chemin de fichier |
| ODP, OTP | `ODP`, `OTP` respectivement | Identique au chemin de fichier |
| FODP | `FODP` | `FODP` |
| PowerPoint XML | `XML` | `XML` |

Dans ces contrôles, la seule normalisation du format source était PPS/POT vers `PPT` pour les flux sans nom. Le tableau décrit l’identification du format, pas la préservation de chaque fonctionnalité de présentation lors de la conversion.

## **FAQ**

**Enregistrer au format ODP modifie‑t‑il le format source d’une présentation chargée depuis PPTX ?**

Non. L’instance existante signale toujours `PPTX`. Une instance chargée depuis le fichier ODP enregistré signale `ODP`.

**Un flux peut‑il toujours distinguer une présentation legacy, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez le nom de fichier ou les métadonnées de sous‑type séparément quand cette distinction est requise.

**Quelle API dois‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.source_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/source_format/). Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour l’inspection avant le chargement.