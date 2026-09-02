---
title: Récupérer et mettre à jour les informations de présentation en Python
linktitle: Informations de présentation
type: docs
weight: 30
url: /fr/python-net/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés de document
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
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument en utilisant Python pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d’une présentation et lire ses métadonnées de document sans créer un modèle complet d’objet de présentation. Cette fonctionnalité est utile lorsque vous devez classer des fichiers, établir un inventaire ou inspecter des propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre comment réaliser une inspection légère grâce à [PresentationFactory](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/) et [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/), ainsi que des mises à jour ciblées via [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/).

## **Vérifier le format d'une présentation**

Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour inspecter un fichier sans créer une instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). La propriété [PresentationInfo.load_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/load_format/) indique le format détecté, tel que PPTX, PPT ou ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Construire un inventaire de présentations léger**

Lorsque vous traitez de nombreux fichiers de présentation, il peut être nécessaire de disposer d’un inventaire compact pour la validation, l’indexation ou un système de gestion documentaire. Dans ce scénario, utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour obtenir un objet [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/), puis appelez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) pour lire les métadonnées du document. Cette approche ne crée pas d’instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et ne nécessite pas de parcourir le modèle complet d’objet de la présentation.

Les propriétés étendues exposées par [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/) fournissent les valeurs d’inventaire suivantes :

| Propriété | Valeur d'inventaire |
| --- | --- |
| [slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/slides/fr/) | Nombre total de diapositives. |
| [hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/hidden_slides/) | Nombre de diapositives masquées. |
| [notes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/notes/) | Nombre de diapositives contenant des notes. |
| [paragraphs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/paragraphs/) | Nombre total de paragraphes, lorsqu’ils sont disponibles. |
| [words](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/words/) | Nombre total de mots. |
| [multimedia_clips](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/multimedia_clips/) | Nombre total de clips audio et vidéo. |

L’exemple suivant lit ces valeurs sans créer d’objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et affiche un inventaire compact. Il combine également [heading_pairs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/heading_pairs/) avec [titles_of_parts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/titles_of_parts/) pour présenter des groupes de contenu tels que les polices, les thèmes et les titres de diapositives.

```python
import os
import aspose.slides as slides

file_path = "sample.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)
document_properties = presentation_info.read_document_properties()

print(f"File: {os.path.basename(file_path)}")
print(f"Format: {presentation_info.load_format}")
print(f"Title: {document_properties.title}")
print(f"Author: {document_properties.author}")
print("Statistics:")
print(f"  Slides: {document_properties.slides}")
print(f"  Hidden slides: {document_properties.hidden_slides}")
print(f"  Slides with notes: {document_properties.notes}")
print(f"  Paragraphs: {document_properties.paragraphs}")
print(f"  Words: {document_properties.words}")
print(f"  Multimedia clips: {document_properties.multimedia_clips}")

heading_pairs = document_properties.heading_pairs or []
titles_of_parts = document_properties.titles_of_parts or []
part_index = 0

if not heading_pairs or not titles_of_parts:
    print("Content groups: not available")
else:
    print("Content groups:")

    for heading_pair in heading_pairs:
        print(f"  {heading_pair.name} ({heading_pair.count})")

        for _ in range(heading_pair.count):
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

Chaque [HeadingPair](https://reference.aspose.com/slides/fr/python-net/aspose.slides/headingpair/) fournit un nom de groupe et le nombre d’éléments dans ce groupe. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/titles_of_parts/) est une collection plate et ordonnée, il suffit donc de consommer le nombre de titres consécutifs indiqué par chaque paire d’en-tête.

### **Métadonnées stockées et limitations de format**

Les propriétés d’inventaire renvoyées par [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) reflètent les métadonnées présentes dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modèle d’objet de la présentation pour recalculer ces valeurs lors de cet appel. Les propriétés manquantes sont représentées par des valeurs par défaut, et les valeurs stockées peuvent être obsolètes si l’application qui a enregistré le fichier en dernier n’a pas mis à jour ses propriétés de document.

- **PPTX :** Le format fournit des propriétés de document étendues pour le nombre de diapositives, de notes, de diapositives masquées, de paragraphes, de mots et de médias, ainsi que pour les paires d’en-têtes et les titres de parties. Leur disponibilité dépend des propriétés écrites par le producteur du document.
- **PPT :** Le format binaire peut stocker les propriétés de résumé de document correspondantes. Si une propriété est absente ou n’a pas été rafraîchie par le producteur du document, Aspose.Slides renvoie sa valeur stockée ou la valeur par défaut au lieu de la calculer à partir des diapositives.
- **ODP :** Les métadonnées OpenDocument fournissent des statistiques générales (pages, paragraphes, mots), mais ces valeurs ne correspondent pas à toutes les propriétés étendues spécifiques à PowerPoint. Les métadonnées concernant les diapositives masquées, les notes, les médias, les paires d’en‑tête et les titres de parties peuvent être indisponibles, et les propriétés d’inventaire peuvent renvoyer des valeurs par défaut. Ne considérez pas une valeur zéro ou une collection vide comme une preuve définitive de l’absence du contenu correspondant.

Utilisez l’approche métadonnées légères pour les inventaires et les vérifications préliminaires. Chargez la présentation et inspectez son modèle d’objet en mémoire lorsque le résultat doit refléter les modifications en cours ou lorsque vous devez vérifier le contenu réel de la présentation.

## **Mettre à jour les propriétés de la présentation**

Les propriétés renvoyées par [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) peuvent également être modifiées sans créer d’instance de [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Appliquez les changements avec [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/update_document_properties/), puis écrivez la présentation liée avec [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

L’image suivante montre les propriétés du document d’origine.

![Propriétés du document d'origine de la présentation PowerPoint](input_properties.png)

L’exemple suivant modifie le titre et la date de dernière sauvegarde et écrit le résultat dans un nouveau fichier :

```python
import datetime
import aspose.slides as slides

source_file = "sample.pptx"
output_file = "sample_with_updated_properties.pptx"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(source_file)
document_properties = presentation_info.read_document_properties()

document_properties.title = "Quarterly sales report"
document_properties.last_saved_time = datetime.datetime.now(datetime.timezone.utc)

presentation_info.update_document_properties(document_properties)

with open(output_file, "wb") as output_stream:
    presentation_info.write_binded_presentation(output_stream)
```

L’image suivante montre les propriétés du document mises à jour.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour les vérifications de sécurité associées et les paramètres de protection, consultez les articles suivants :

- [Password-Protect Presentations](/slides/fr/python-net/password-protected-presentation/)
- [Write-Protect Presentations](/slides/fr/python-net/write-protected-presentation/)

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Chargez la présentation et utilisez [Presentation.fonts_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/fonts_manager/). Appelez [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pour obtenir les polices incorporées et [FontsManager.get_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_fonts/) pour obtenir les polices utilisées par la présentation. Comparez les deux résultats pour identifier les polices nécessaires au rendu mais non incorporées.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Lorsque les métadonnées du document stockées sont suffisantes, lisez [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/hidden_slides/) via [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) et [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/). Cette méthode convient pour un inventaire léger. Si la présentation a été modifiée en mémoire, les métadonnées stockées peuvent être manquantes ou obsolètes ; parcourez alors [Presentation.slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) et inspectez la propriété [Slide.hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille de diapositive personnalisée et une orientation sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Chargez la présentation et lisez [Presentation.slide_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slide_size/). Vérifiez [SlideSize.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/size/) et [SlideSize.orientation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/orientation/) pour comparer les paramètres actuels avec les paramètres prédéfinis attendus.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/) et inspectez [ChartData.data_source_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/data_source_type/). Pour un classeur externe, lisez [ChartData.external_workbook_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Le type de source de données et le chemin identifient une référence externe, mais la vérification de la disponibilité de la cible nécessite un contrôle de ressource distinct.

**Comment évaluer les « diapositives lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**

Il n’existe pas de propriété unique de complexité. Parcourez [Presentation.slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) et la collection [BaseSlide.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/shapes/) de chaque diapositive. Utilisez le nombre de formes et la présence d’images volumineuses, d’effets, d’animations ou de médias comme indicateurs de filtrage, et mesurez un rendu ou une exportation représentative avant de considérer une diapositive comme un goulot d’étranglement confirmé.