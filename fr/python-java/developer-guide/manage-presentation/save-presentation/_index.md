---
title: Enregistrer les présentations en Python via Java
linktitle: Enregistrer la présentation
type: docs
weight: 80
url: /fr/python-java/save-presentation/
keywords:
- enregistrer PowerPoint
- enregistrer OpenDocument
- enregistrer la présentation
- enregistrer la diapositive
- enregistrer PPT
- enregistrer PPTX
- enregistrer ODP
- présentation en fichier
- présentation en flux
- type de vue prédéfini
- format Office Open XML strict
- mode Zip64
- actualisation de la vignette
- progression de l'enregistrement
- Python
- Java
- Aspose.Slides
description: "Enregistrez des présentations PowerPoint et OpenDocument dans des fichiers ou des flux en Python via Java avec Aspose.Slides, et configurez la sortie PPTX ainsi que le rapport de progression."
---
## **Vue d'ensemble**

Après avoir créé une présentation ou [ouvrir une présentation existante](/slides/fr/python-java/open-presentation/), utilisez la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour enregistrer le résultat. Aspose.Slides for Python via Java peut enregistrer une présentation dans un fichier ou un flux aux formats PowerPoint, OpenDocument, PDF et autres. Les sections suivantes couvrent les opérations d'enregistrement standard et les options disponibles pour la sortie PPTX.

## **Enregistrer les présentations dans des fichiers**

Pour enregistrer une présentation dans un fichier, transmettez le chemin de sortie et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save). La valeur du format détermine le type de fichier créé par Aspose.Slides.

L'exemple suivant crée une présentation et l'enregistre au format PPTX :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    # Ajoutez ou modifiez le contenu de la présentation ici.

    presentation.save("Output.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Enregistrer les présentations dans leur format d'origine**

Dans une application de traitement par lots, le format d'entrée peut ne pas être connu à l'avance. Après avoir chargé un fichier, lisez son format d'origine à l'aide de la méthode [Presentation.getSourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSourceFormat). Transmettez la valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sourceformat/) obtenue à [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#toSaveFormat) pour obtenir la valeur correspondante de [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/), puis utilisez [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save) pour écrire la présentation modifiée.

L'exemple complet suivant traite chaque fichier d'un répertoire d'entrée, met à jour son titre et l'enregistre dans un répertoire de sortie dans le même format que celui d'origine :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SlideUtil
from pathlib import Path

IllegalArgumentException = jpype.JClass("java.lang.IllegalArgumentException")
input_directory = Path("Input")
output_directory = Path("Output")

try:
    output_directory.mkdir(parents=True, exist_ok=True)
except OSError:
    print("Cannot create the output directory.")

if input_directory.is_dir() and output_directory.is_dir():
    for input_file in input_directory.iterdir():
        if input_file.is_file():
            try:
                presentation = Presentation(str(input_file))
                try:
                    save_format = SlideUtil.toSaveFormat(presentation.getSourceFormat())
                    presentation.getDocumentProperties().setTitle("Processed by the batch application")

                    output_file = output_directory / input_file.name
                    presentation.save(str(output_file), save_format)
                finally:
                    presentation.dispose()
            except IllegalArgumentException as exception:
                print(f"Cannot map the source format of '{input_file}': {exception}")
            except Exception as exception:
                print(f"Cannot process '{input_file}': {exception}")
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slideutil/#toSaveFormat) mappe PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP et PowerPoint XML vers leurs formats d'enregistrement de présentation correspondants. Il ne mappe que les formats source de présentation ; il ne sert pas à sélectionner des formats d'exportation tels que PDF, HTML, TIFF ou images. Transmettre une valeur [SourceFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/sourceformat/) non prise en charge ou invalide entraîne une [IllegalArgumentException](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/lang/IllegalArgumentException.html).

Les fichiers PPT, PPS et POT hérités utilisent le même conteneur binaire. Lorsqu'une telle présentation est chargée depuis un flux sans extension de fichier, un fichier PPS ou POT peut donc être identifié comme PPT. Si la préservation de ces sous‑types hérités est requise, conservez le nom de fichier ou les métadonnées de format d'origine séparément et utilisez‑les lors du choix du nom et du format de sortie.

## **Enregistrer les présentations dans des flux**

Pour écrire une présentation sans dépendre d'un chemin de fichier final, transmettez un flux ouvrable en écriture et une valeur [SaveFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveformat/) à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save). Cette approche est utile lorsque la sortie doit être renvoyée depuis un service web, stockée dans une base de données ou traitée en mémoire.

L'exemple suivant enregistre une nouvelle présentation dans un flux de fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

FileOutputStream = jpype.JClass("java.io.FileOutputStream")

presentation = Presentation()
try:
    output_stream = FileOutputStream("Output.pptx")
    try:
        presentation.save(output_stream, SaveFormat.Pptx)
    finally:
        output_stream.close()
finally:
    presentation.dispose()
```

## **Enregistrer les présentations avec un type de vue prédéfini**

Vous pouvez spécifier la vue dans laquelle PowerPoint ouvre initialement une présentation enregistrée. Utilisez la méthode [ViewProperties.setLastView](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewproperties/#setLastView) avec une valeur [ViewType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/viewtype/) avant l'enregistrement.

L'exemple suivant configure la vue Maîtres des diapositives comme vue initiale :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, ViewType

presentation = Presentation()
try:
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView)
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Enregistrer les présentations au format Office Open XML strict**

Pour créer un fichier PPTX conforme au profil Strict d'Office Open XML, créez une instance [PptxOptions](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxoptions/) et utilisez sa méthode [setConformance](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxoptions/#setConformance) avec [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/fr/python-java/aspose.slides/conformance/#Iso29500_2008_Strict). Transmettez ensuite les options à la méthode [Presentation.save](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#save).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Conformance, PptxOptions, Presentation, SaveFormat

options = PptxOptions()
options.setConformance(Conformance.Iso29500_2008_Strict)

presentation = Presentation()
try:
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Enregistrer les présentations au format Office Open XML en mode Zip64**

Une archive ZIP standard limite la taille compressée et non compressée de chaque entrée, la taille totale de l'archive et le nombre d'entrées. Comme un fichier PPTX est une archive ZIP, une présentation très volumineuse peut dépasser ces limites. Les extensions ZIP64 augmentent les limites de taille et de nombre d'entrées applicables.

Utilisez la méthode [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxoptions/#setZip64Mode) pour contrôler si Aspose.Slides écrit les extensions ZIP64 :

- [IfNecessary](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zip64mode/#IfNecessary) utilise ZIP64 uniquement lorsque la présentation dépasse les limites standard de ZIP. C’est le mode par défaut.
- [Never](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zip64mode/#Never) désactive les extensions ZIP64.
- [Always](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zip64mode/#Always) écrit toujours les extensions ZIP64.

L'exemple suivant active toujours les extensions ZIP64 pour la présentation de sortie :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat, Zip64Mode

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setZip64Mode(Zip64Mode.Always)

    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="warning" title="Warning" %}}
Si [Zip64Mode.Never](https://reference.aspose.com/slides/fr/python-java/aspose.slides/zip64mode/#Never) est utilisé et que la présentation ne peut pas tenir dans les limites standard de ZIP, l'opération d'enregistrement lève une [PptxException](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Enregistrer les présentations au format Office Open XML avec niveaux de compression**

Pour la sortie PPTX, vous pouvez équilibrer la vitesse d'enregistrement et la taille du fichier en utilisant la méthode [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxoptions/#setCompressionLevel). La classe [CompressionLevel](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/) propose ces valeurs :

- [None](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#None) stocke les données sans compression.
- [Level1](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level1) offre la compression la plus rapide et le résultat compressé le plus volumineux.
- [Level2](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level2) à [Level5](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level5) favorisent progressivement une sortie plus petite au détriment de la vitesse d'enregistrement.
- [Level6](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level6) équilibre vitesse d'enregistrement et taille du fichier. C’est le niveau par défaut.
- [Level7](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level7) et [Level8](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level8) favorisent davantage une sortie plus petite au détriment de la vitesse.
- [Level9](https://reference.aspose.com/slides/fr/python-java/aspose.slides/compressionlevel/#Level9) offre la compression la plus forte et requiert le plus de temps de traitement.

L'exemple suivant enregistre une présentation sans compression :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.None_)

    presentation.save("OutputNoCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

L'exemple suivant utilise le niveau de compression maximal :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import CompressionLevel, PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setCompressionLevel(CompressionLevel.Level9)

    presentation.save("OutputMaximumCompression.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

## **Enregistrer les présentations sans rafraîchir la vignette**

Lorsqu'une présentation est enregistrée au format PPTX, la méthode [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/fr/python-java/aspose.slides/pptxoptions/#setRefreshThumbnail) contrôle la vignette du document :

- `True` régénère la vignette pendant l'opération d'enregistrement. C’est la valeur par défaut.
- `False` préserve la vignette existante. Si la présentation n'a pas de vignette, Aspose.Slides n'en génère pas.

L'exemple suivant enregistre une présentation sans rafraîchir sa vignette :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PptxOptions, Presentation, SaveFormat

presentation = Presentation("Sample.pptx")
try:
    options = PptxOptions()
    options.setRefreshThumbnail(False)

    presentation.save("Output.pptx", SaveFormat.Pptx, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Désactiver le rafraîchissement de la vignette peut réduire le temps nécessaire à l'enregistrement d'un fichier PPTX.
{{% /alert %}}

## **Rapporter la progression de l'enregistrement en pourcentage**

Pour suivre une opération d'enregistrement, enregistrez un gestionnaire de progression Python via `jpype.JProxy` et transmettez‑le à la méthode [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/fr/python-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides appellera alors la méthode `reporting` du gestionnaire avec les valeurs de progression pendant l'exportation.

L'exemple suivant rapporte la progression d'une exportation PDF dans la console :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PdfOptions, Presentation, SaveFormat


class ExportProgressHandler:
    def reporting(self, progress_value):
        progress = int(progress_value)
        print(f"{progress}% of the file has been converted.")


handler = ExportProgressHandler()
callback = jpype.JProxy("com.aspose.slides.IProgressCallback", inst=handler)
options = PdfOptions()
options.setProgressCallback(callback)

presentation = Presentation("Sample.pptx")
try:
    presentation.save("Output.pdf", SaveFormat.Pdf, options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose fournit un [PowerPoint Splitter](https://products.aspose.app/slides/fr/splitter) gratuit construit avec l'API Aspose.Slides. Il enregistre les diapositives sélectionnées d'une présentation en fichiers PPT ou PPTX distincts.
{{% /alert %}}

## **FAQ**

**Aspose.Slides prend‑il en charge l’enregistrement incrémental ou le « fast save » ?**

Non. Chaque opération d’enregistrement écrit un fichier complet plutôt que de ne mettre à jour que les parties modifiées.

**Plusieurs threads peuvent‑ils enregistrer la même instance de Presentation ?**

Non. Une instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) **n’est pas thread‑safe** (/slides/fr/python-java/multithreading/). Accédez et enregistrez chaque instance depuis un seul thread à la fois.

**Que se passe‑t‑il avec les hyperliens et les fichiers liés externement lors de l’enregistrement d’une présentation ?**

Les [hyperliens](/slides/fr/python-java/manage-hyperlinks/) restent dans la présentation. Aspose.Slides ne copie pas les fichiers liés externement, de sorte que la présentation enregistrée doit toujours pouvoir accéder à leurs emplacements.

**Puis‑je enregistrer les métadonnées du document telles que l’auteur, le titre, l’entreprise et la date de création ?**

Oui. Définissez les [propriétés du document](/slides/fr/python-java/presentation-properties/) appropriées avant l’enregistrement, et Aspose.Slides les écrit dans le fichier de sortie.