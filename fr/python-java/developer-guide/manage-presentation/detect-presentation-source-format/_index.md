---
title: Déterminer le format original de la présentation en Python via Java
linktitle: Format source
type: docs
weight: 35
url: /fr/python-java/detect-presentation-source-format/
keywords:
- format source
- détecter le format de la présentation
- PowerPoint
- OpenDocument
- présentation
- PPT
- PPTX
- Python
- Java
- Aspose.Slides
description: "Lire le format original d’une présentation chargée en Python via Java avec Aspose.Slides pour Python via Java, comparer les API de détection et gérer les fichiers, flux et formats hérités."
---
## **Aperçu**

Après avoir chargé une présentation, appelez la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSourceFormat) pour déterminer son format d'origine. Utilisez‑la lorsque le traitement ultérieur dépend du format à partir duquel l'instance actuelle a été chargée.

Le format source est distinct du [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/) choisi pour un fichier de sortie. Enregistrer dans un autre format ne modifie pas le format source de l'instance existante.

Les exemples nécessitent Aspose.Slides pour Python via Java et un runtime Java compatible. Chaque exemple démarre la JVM si elle n’est pas déjà en cours d’exécution.

## **Lire le format source d'un fichier**

Cet exemple nécessite un fichier `sample.pptx` existant. Il charge le fichier et sélectionne une politique de traitement d’application en utilisant [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSourceFormat), plutôt que le nom de fichier. Modifiez le chemin d’entrée pour essayer d’autres formats. L’exemple affiche la politique sélectionnée ; remplacez les messages par la logique de votre application.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

presentation = Presentation("sample.pptx")
try:
    source_format = presentation.getSourceFormat()
    if source_format in (SourceFormat.Ppt, SourceFormat.Pps, SourceFormat.Pot):
        print("Use the legacy PowerPoint processing policy.")
    elif source_format == SourceFormat.Pptx:
        print("Use the standard PPTX processing policy.")
    else:
        print(f"Use the general policy for source format {source_format}.")
finally:
    presentation.dispose()
```

## **Reconnaître les valeurs prises en charge**

La classe [SourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sourceformat/) définit des constantes entières qui distinguent les formats de présentation suivants. Les extensions ci‑dessous sont des extensions conventionnelles, pas une reconstruction du nom de fichier d’origine.

| Valeur SourceFormat | Extension | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | présentation PowerPoint 97–2003 |
| `Pptx` | `.pptx` | présentation Office Open XML |
| `Pptm` | `.pptm` | présentation Office Open XML avec macros |
| `Pps` | `.pps` | diaporama PowerPoint 97–2003 |
| `Ppsx` | `.ppsx` | diaporama Office Open XML |
| `Ppsm` | `.ppsm` | diaporama Office Open XML avec macros |
| `Pot` | `.pot` | modèle PowerPoint 97–2003 |
| `Potx` | `.potx` | modèle Office Open XML |
| `Potm` | `.potm` | modèle Office Open XML avec macros |
| `Odp` | `.odp` | présentation OpenDocument |
| `Otp` | `.otp` | modèle de présentation OpenDocument |
| `Fodp` | `.fodp` | présentation ODF XML plat |
| `Xml` | `.xml` | présentation PowerPoint XML |

## **Lire le format source d’un flux**

Cet exemple nécessite un fichier `sample.pps` existant. Lire ses octets dans un flux mémoire simule une entrée reçue sans nom de fichier, comme une valeur de base de données ou un tableau d’octets téléchargé. Le constructeur [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) ne reçoit que le flux. Python lit les octets du fichier, et JPype les convertit en un tableau d’octets Java pour le flux mémoire Java.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation

try:
    data = Path("sample.pps").read_bytes()
    java_bytes = jpype.JArray(jpype.JByte)(data)
    stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
    try:
        presentation = Presentation(stream)
        try:
            print(f"Source format: {presentation.getSourceFormat()}")
        finally:
            presentation.dispose()
    finally:
        stream.close()
except OSError as exception:
    print(f"Cannot read the presentation: {exception}")
```

PPT, PPS et POT utilisent le même format binaire sous‑jacent. Lors du chargement par chemin de fichier, l’extension peut aider à distinguer un diaporama ou un modèle. Sans nom de fichier, le contenu legacy PPS et POT peut être signalé comme `SourceFormat.Ppt` ; l’exemple PPS ci‑dessus affiche la valeur entière de `SourceFormat.Ppt`.

Si votre application doit conserver la distinction, conservez séparément le nom de fichier d’origine ou les métadonnées de sous‑type. Une extension est un indice utile pour ces sous‑types legacy, mais ne doit pas être le seul critère pour identifier un contenu de présentation quelconque.

## **Comparer la détection avant et après le chargement**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) et [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#getLoadFormat) lorsque vous devez inspecter un fichier avant de charger son modèle d’objet de présentation complet. Utilisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSourceFormat) lorsque l’instance existe déjà.

Cet exemple nécessite `sample.pptx` et affiche les valeurs entières de `LoadFormat.Pptx` et `SourceFormat.Pptx`, respectivement. En production, choisissez l’API adaptée à votre étape de traitement ; une présentation déjà chargée n’a pas besoin d’une seconde inspection uniquement pour obtenir son format source.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, PresentationFactory

path = "sample.pptx"
information = PresentationFactory.getInstance().getPresentationInfo(path)
print(f"Before loading: {information.getLoadFormat()}")

presentation = Presentation(path)
try:
    print(f"After loading: {presentation.getSourceFormat()}")
finally:
    presentation.dispose()
```

Les résultats utilisent des constantes provenant de classes différentes : [LoadFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/loadformat/) et [SourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sourceformat/). Ne comparez pas leurs valeurs numériques et ne supposez pas que chaque format possède des résultats de détection identiques. PowerPoint XML peut être signalé comme `LoadFormat.Unknown` avant le chargement et `SourceFormat.Xml` après le chargement.

## **Conserver les formats source et de sortie séparés**

Cet exemple nécessite `sample.pptx` et écrit `converted.odp`. Il affiche la valeur entière de `SourceFormat.Pptx` avant et après l’enregistrement de l’instance originale. Seule la nouvelle instance chargée à partir du fichier ODP sorti signale `Odp`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("sample.pptx")
try:
    print(f"Before saving: {presentation.getSourceFormat()}")

    presentation.save("converted.odp", SaveFormat.Odp)
    print(f"After saving: {presentation.getSourceFormat()}")

    reopened = Presentation("converted.odp")
    try:
        print(f"Reopened output: {reopened.getSourceFormat()}")
    finally:
        reopened.dispose()
finally:
    presentation.dispose()
```

Une présentation créée de zéro avec `Presentation()` signale `SourceFormat.Pptx`. Elle n’a aucun fichier d’entrée : il s’agit de la valeur par défaut pour une instance nouvellement créée, et non d’une preuve qu’un fichier PPTX a été chargé. Suivez séparément si votre application a créé ou chargé l’instance si cette distinction est importante.

## **Mapper un format source à une extension**

L’exemple suivant nécessite `sample.pptx`. Il associe chaque valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sourceformat/) actuellement prise en charge à une extension conventionnelle, sans analyser le nom de fichier d’entrée. La solution de repli évite d’attribuer silencieusement une extension à une valeur non reconnue.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SourceFormat

extensions = {
    SourceFormat.Ppt: ".ppt",
    SourceFormat.Pptx: ".pptx",
    SourceFormat.Pptm: ".pptm",
    SourceFormat.Pps: ".pps",
    SourceFormat.Ppsx: ".ppsx",
    SourceFormat.Ppsm: ".ppsm",
    SourceFormat.Pot: ".pot",
    SourceFormat.Potx: ".potx",
    SourceFormat.Potm: ".potm",
    SourceFormat.Odp: ".odp",
    SourceFormat.Otp: ".otp",
    SourceFormat.Fodp: ".fodp",
    SourceFormat.Xml: ".xml",
}

presentation = Presentation("sample.pptx")
try:
    extension = extensions.get(presentation.getSourceFormat())
    print(extension if extension is not None else "No extension mapping is available.")
finally:
    presentation.dispose()
```

Cette association ne convertit pas un fichier ni ne récupère un sous‑type legacy PPS/POT perdu lors du chargement du flux. Pour un enregistrement réel, sélectionnez explicitement un [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/), ou utilisez la conversion présentée dans [Enregistrer les présentations dans leur format d’origine](/slides/fr/python-java/save-presentation/#save-presentations-in-their-original-format).

## **Vérifier les formats en enregistrant et en rouvrant**

Cet exemple autonome crée une présentation et écrit trois fichiers dans le répertoire de travail, en écrasant les fichiers portant les mêmes noms. Il rouvre chaque sortie à la fois par chemin et via un flux mémoire. Pour PPTX et ODP, les deux voies signalent le format enregistré. Pour PPS, le chargement par chemin signale `Pps`, tandis que le chargement des mêmes octets sans nom de fichier signale `Ppt`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    formats = [
        (SaveFormat.Pptx, "pptx"),
        (SaveFormat.Odp, "odp"),
        (SaveFormat.Pps, "pps"),
    ]

    for save_format, extension in formats:
        path = f"roundtrip.{extension}"
        presentation.save(path, save_format)

        from_file = Presentation(path)
        try:
            data = Path(path).read_bytes()
            java_bytes = jpype.JArray(jpype.JByte)(data)
            stream = jpype.JClass("java.io.ByteArrayInputStream")(java_bytes)
            try:
                from_stream = Presentation(stream)
                try:
                    print(f"{extension}: file={from_file.getSourceFormat()}, stream={from_stream.getSourceFormat()}")
                finally:
                    from_stream.dispose()
            finally:
                stream.close()
        finally:
            from_file.dispose()
except OSError as exception:
    print(f"Cannot read a saved presentation: {exception}")
finally:
    presentation.dispose()
```

Le tableau suivant résume l’identification du format source pour les présentations avec des extensions correspondantes. Les noms désignent des constantes ; les exemples Python affichent leurs valeurs entières :

| Format enregistré | SourceFormat à partir d’un chemin de fichier | SourceFormat à partir d’un flux sans nom |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectivement | Identique au chemin de fichier |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectivement | Identique au chemin de fichier |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectivement | Identique au chemin de fichier |
| ODP, OTP | `Odp`, `Otp` respectivement | Identique au chemin de fichier |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

Le contenu PPS/POT est identifié comme `Ppt` pour les flux sans nom. Le tableau décrit l’identification des formats, pas la conservation de chaque fonctionnalité de la présentation lors de la conversion.

## **FAQ**

**L’enregistrement au format ODP modifie‑t‑il le format source d’une présentation chargée depuis PPTX ?**

Non. L’instance existante signale toujours `Pptx`. Une instance chargée à partir du fichier ODP enregistré signale `Odp`.

**Un flux peut‑il toujours distinguer une présentation legacy, un diaporama et un modèle ?**

Non. PPT, PPS et POT partagent le même format binaire. Conservez séparément le nom de fichier ou les métadonnées de sous‑type lorsque cette distinction est nécessaire.

**Quelle API dois‑je utiliser si la présentation est déjà chargée ?**

Lisez [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSourceFormat). Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) pour l’inspection avant le chargement.