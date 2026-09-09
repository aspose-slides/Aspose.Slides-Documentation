---
title: Récupérer et mettre à jour les informations de présentation en Python via Java
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/python-java/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
- changer les propriétés
- modifier les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Java
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en utilisant Python via Java pour des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d'une présentation et lire ses métadonnées de document sans créer un modèle d'objet complet de la présentation. Ceci est utile lorsque vous devez classer des fichiers, créer un inventaire ou inspecter les propriétés avant de décider de charger et de traiter le contenu de la présentation.

Les exemples nécessitent Aspose.Slides for Python via Java et un runtime Java compatible. Chaque exemple démarre la JVM si elle n'est pas déjà en cours d'exécution. Fournissez les fichiers de présentation existants aux chemins utilisés dans les exemples.

Cet article montre une inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/) et [PresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/), ainsi que des mises à jour ciblées via [DocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/).

## **Vérifier le format d'une présentation**

Utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) pour inspecter un fichier sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). La méthode [PresentationInfo.getLoadFormat](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#getLoadFormat) indique le format détecté, tel que PPTX, PPT ou ODP.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadFormat, PresentationFactory

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_name)
    load_format = presentation_info.getLoadFormat()
    format_name = f"Other ({load_format})"

    if load_format == LoadFormat.Pptx:
        format_name = "PPTX"
    elif load_format == LoadFormat.Ppt:
        format_name = "PPT"
    elif load_format == LoadFormat.Odp:
        format_name = "ODP"

    print(f"{file_name}: {format_name}")
```

## **Construire un inventaire de présentation léger**

Lorsque vous traitez de nombreux fichiers de présentation, vous pouvez avoir besoin d'un inventaire compact pour la validation, l'indexation ou un système de gestion de documents. Dans ce scénario, utilisez [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) pour obtenir un objet [PresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/), puis appelez [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) pour lire les métadonnées du document. Cette approche ne crée pas d'instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et ne nécessite pas de parcourir le modèle d'objet complet de la présentation.

Les propriétés étendues exposées par [DocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/) fournissent les valeurs d'inventaire suivantes :

| Méthode | Valeur d'inventaire |
| --- | --- |
| [getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getSlides) | Nombre total de diapositives. |
| [getHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getHiddenSlides) | Nombre de diapositives masquées. |
| [getNotes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getNotes) | Nombre de diapositives contenant des notes. |
| [getParagraphs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getParagraphs) | Nombre total de paragraphes, lorsqu'ils sont disponibles. |
| [getWords](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getWords) | Nombre total de mots. |
| [getMultimediaClips](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getMultimediaClips) | Nombre total de clips audio et vidéo. |

L'exemple suivant lit ces valeurs sans créer d'objet [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/) et affiche un inventaire compact. Il combine également [getHeadingPairs](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getHeadingPairs) avec [getTitlesOfParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) pour afficher des groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from pathlib import Path
from asposeslides.api import LoadFormat, PresentationFactory

file_path = "sample.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)
document_properties = presentation_info.readDocumentProperties()

load_format = presentation_info.getLoadFormat()
format_name = f"Other ({load_format})"

if load_format == LoadFormat.Pptx:
    format_name = "PPTX"
elif load_format == LoadFormat.Ppt:
    format_name = "PPT"
elif load_format == LoadFormat.Odp:
    format_name = "ODP"

print(f"File: {Path(file_path).name}")
print(f"Format: {format_name}")
print(f"Title: {document_properties.getTitle()}")
print(f"Author: {document_properties.getAuthor()}")
print("Statistics:")
print(f"  Slides: {document_properties.getSlides()}")
print(f"  Hidden slides: {document_properties.getHiddenSlides()}")
print(f"  Slides with notes: {document_properties.getNotes()}")
print(f"  Paragraphs: {document_properties.getParagraphs()}")
print(f"  Words: {document_properties.getWords()}")
print(f"  Multimedia clips: {document_properties.getMultimediaClips()}")

heading_pairs = document_properties.getHeadingPairs()
titles_of_parts = document_properties.getTitlesOfParts()
heading_pairs = heading_pairs if heading_pairs is not None else []
titles_of_parts = titles_of_parts if titles_of_parts is not None else []
part_index = 0

if len(heading_pairs) == 0 or len(titles_of_parts) == 0:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.getName()} ({heading_pair.getCount()})")

        for part_offset in range(heading_pair.getCount()):
            if part_index >= len(titles_of_parts):
                break
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1

    if part_index < len(titles_of_parts):
        print("  Other parts:")

        while part_index < len(titles_of_parts):
            print(f"    - {titles_of_parts[part_index]}")
            part_index += 1
```

Chaque [HeadingPair](https://reference.aspose.com/slides/fr/python-java/aspose.slides/headingpair/) fournit un nom de groupe et le nombre d'éléments dans ce groupe. [DocumentProperties.getTitlesOfParts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getTitlesOfParts) renvoie un tableau plat et ordonné, il faut donc consommer le nombre de titres consécutifs spécifié par chaque paire d'en-tête.

### **Métadonnées stockées et limitations du format**

Les propriétés d'inventaire renvoyées par [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) reflètent les métadonnées disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d'objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l'application qui a enregistré le fichier en dernier n'a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour les comptes de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de multimédias, ainsi que les paires d'en-têtes et les titres de parties. La disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumé de document correspondantes. Si une propriété est absente ou n'a pas été rafraîchie par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou la valeur par défaut plutôt que de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales du document, telles que le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas à toutes les propriétés étendues spécifiques à PowerPoint. Les métadonnées de diapositives masquées, de notes, de multimédias, de paires d'en-têtes et de titres de parties peuvent être indisponibles, et les propriétés d'inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou un tableau vide comme une preuve autoritaire que le contenu correspondant est absent.

Utilisez l'approche de métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d'objet en direct lorsque le résultat doit refléter les modifications en mémoire ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties) peuvent également être modifiées sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/). Appliquez les modifications avec [PresentationInfo.updateDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#updateDocumentProperties), puis écrivez la présentation liée avec [PresentationInfo.writeBindedPresentation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#writeBindedPresentation).

L'image suivante montre les propriétés du document d'origine de la présentation PowerPoint.

![Propriétés du document original de la présentation PowerPoint](input_properties.png)

L'exemple suivant modifie le titre et l'heure de dernière sauvegarde et écrit le résultat dans un nouveau fichier :

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import PresentationFactory
from java.io import FileOutputStream
from java.util import Date

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(source_file)
document_properties = presentation_info.readDocumentProperties()

document_properties.setTitle("Quarterly sales report")
last_saved_time = Date()
document_properties.setLastSavedTime(last_saved_time)

presentation_info.updateDocumentProperties(document_properties)
output_stream = FileOutputStream(output_file)
try:
    presentation_info.writeBindedPresentation(output_stream)
finally:
    output_stream.close()
```

L'image suivante montre les propriétés du document modifiées de la présentation PowerPoint.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour les contrôles de sécurité associés et les paramètres de protection, consultez les articles suivants :

- [Présentations protégées par mot de passe](/slides/fr/python-java/password-protected-presentation/)
- [Présentations protégées en écriture](/slides/fr/python-java/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles le sont ?**

Chargez la présentation et utilisez [Presentation.getFontsManager](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getFontsManager). Appelez [FontsManager.getEmbeddedFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getEmbeddedFonts) pour obtenir les polices incorporées et [FontsManager.getFonts](https://reference.aspose.com/slides/fr/python-java/aspose.slides/fontsmanager/#getFonts) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour identifier les polices nécessaires au rendu mais non incorporées.

**Comment savoir rapidement si le fichier comporte des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [DocumentProperties.getHiddenSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/documentproperties/#getHiddenSlides) via [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationfactory/#getPresentationInfo) et [PresentationInfo.readDocumentProperties](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentationinfo/#readDocumentProperties). Cela convient à un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes, ou si vous devez vérifier les valeurs en direct, parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) et inspectez la méthode [Slide.getHidden](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slide/#getHidden) de chaque diapositive à la place.

**Puis-je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et appelez [Presentation.getSlideSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlideSize). Utilisez [SlideSize.getType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#getType), [SlideSize.getSize](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#getSize) et [SlideSize.getOrientation](https://reference.aspose.com/slides/fr/python-java/aspose.slides/slidesize/#getOrientation) pour comparer les paramètres actuels avec le préréglage et les dimensions attendus.

**Existe-t-il un moyen rapide de savoir si les graphiques référencent des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chart/) et appelez [ChartData.getDataSourceType](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getDataSourceType). Pour un classeur externe, appelez [ChartData.getExternalWorkbookPath](https://reference.aspose.com/slides/fr/python-java/aspose.slides/chartdata/#getExternalWorkbookPath). Le type de source de données et le chemin identifient une référence externe, mais vérifier si la cible est disponible nécessite une vérification de ressource séparée.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l'exportation PDF ?**

Il n'existe pas de propriété unique de complexité. Parcourez [Presentation.getSlides](https://reference.aspose.com/slides/fr/python-java/aspose.slides/presentation/#getSlides) et la collection [BaseSlide.getShapes](https://reference.aspose.com/slides/fr/python-java/aspose.slides/baseslide/#getShapes) de chaque diapositive. Utilisez le nombre de formes et la présence d'images volumineuses, d'effets, d'animations ou de multimédias comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentative avant de considérer une diapositive comme un goulot d'étranglement de performance confirmé.