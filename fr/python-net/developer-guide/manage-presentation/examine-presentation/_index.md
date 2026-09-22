---
title: "Récupérer et mettre à jour les informations de présentation en Python"
linktitle: "Informations de présentation"
type: docs
weight: 30
url: /fr/python-net/examine-presentation/
keywords:
- format de présentation
- propriétés de présentation
- propriétés de document
- obtenir des propriétés
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
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument à l'aide de Python pour des analyses plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Aspose.Slides peut identifier le format d'une présentation et lire ses métadonnées de document sans créer un modèle d'objet de présentation complet. Cela est utile lorsque vous devez classer des fichiers, créer un inventaire ou inspecter des propriétés avant de décider de charger et de traiter le contenu de la présentation.

Cet article montre une inspection légère via [PresentationFactory](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/) et [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/), ainsi que des mises à jour ciblées via [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/).

## **Verifier le format d'une presentation**

Si vous avez déjà une présentation chargee, consultez [Determine the Original Presentation Format](/slides/fr/python-net/detect-presentation-source-format/) pour la detection apres chargement et les limites des flux PPT, PPS et POT herites.

Utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour inspecter un fichier sans creer d'instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). La propriete [PresentationInfo.load_format](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/load_format/) indique le format detecte, tel que PPTX, PPT ou ODP.

```python
import aspose.slides as slides

file_names = ["pres.pptx", "pres.ppt", "pres.odp"]

for file_name in file_names:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_name)
    print(f"{file_name}: {presentation_info.load_format}")
```

## **Construire un inventaire de presentation leger**

Lorsque vous traitez de nombreux fichiers de presentation, vous pouvez avoir besoin d'un inventaire compact pour la validation, l'indexation ou un systeme de gestion de documents. Dans ce scenario, utilisez [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) pour obtenir un objet [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/), puis appelez [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) pour lire les metadonnees du document. Cette approche ne cree pas d'instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et ne vous oblige pas a parcourir le modele d'objet complet de la presentation.

Les proprietes etendues exposees par [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/) fournissent les valeurs d'inventaire suivantes :

| Propriete | Valeur d'inventaire |
| --- | --- |
| [slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/slides/fr/) | Nombre total de diapositives. |
| [hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/hidden_slides/) | Nombre de diapositives masquees. |
| [notes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/notes/) | Nombre de diapositives contenant des notes. |
| [paragraphs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/paragraphs/) | Nombre total de paragraphes, lorsqu'il est disponible. |
| [words](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/words/) | Nombre total de mots. |
| [multimedia_clips](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/multimedia_clips/) | Nombre total de clips audio et video. |

L'exemple suivant lit ces valeurs sans creer un objet [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/) et imprime un inventaire compact. Il combine egalement [heading_pairs](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/heading_pairs/) avec [titles_of_parts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/titles_of_parts/) pour afficher des groupes de contenu tels que les polices, les themes et les titres de diapositives.

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

Chaque [HeadingPair](https://reference.aspose.com/slides/fr/python-net/aspose.slides/headingpair/) fournit un nom de groupe et le nombre d'articles dans ce groupe. [DocumentProperties.titles_of_parts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/titles_of_parts/) est une collection plate et ordonnee, il faut donc consommer le nombre de titres consecutifs specifie par chaque paire d'en-tete.

### **Metadonnees stockees et limites de format**

Les proprietes d'inventaire retournees par [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) reflètent les metadonnees disponibles dans le document source. Aspose.Slides ne charge pas et ne parcourt pas le modele d'objet de la presentation pour recalculer ces valeurs pour cet appel. Les proprietes manquantes sont representees par des valeurs par defaut, et les valeurs stockees peuvent etre obsolètes si l'application qui a enregistre le fichier en dernier n'a pas mis a jour ses proprietes de document.

- **PPTX**: Le format fournit des proprietes de document etendues pour le nombre de diapositives, notes, diapositives masquees, paragraphes, mots et multimedia, ainsi que les paires d'en-tetes et les titres de parties. La disponibilite depend des proprietes ecrites par le producteur du document.
- **PPT**: Le format binaire peut stocker les proprietes de resume de document correspondantes. Si une propriete est absente ou n'a pas ete actualisee par le producteur du document, Aspose.Slides renvoie sa valeur stockee ou par defaut plutot que de la recalculer a partir des diapositives.
- **ODP**: Les metadonnees OpenDocument fournissent des statistiques generales du document, telles que le nombre de pages, de paragraphes et de mots, mais ces valeurs ne correspondent pas a chaque propriete etendue specifique a PowerPoint. Les metadonnees de diapositives masquees, de notes, de multimedia, d'en-tete et de titres de parties peuvent etre indisponibles, et les proprietes d'inventaire peuvent renvoyer des valeurs par defaut. Ne considerez pas une valeur zero ou une collection vide comme une preuve concluante que le contenu correspondant est absent.

Utilisez l'approche de metadonnees legere pour les inventaires et les controles preliminaires. Chargez la presentation et inspectez son modele d'objet en direct lorsque le resultat doit refléter les modifications en memoire ou lorsque vous devez verifier le contenu reel de la presentation.

## **Mettre a jour les proprietes de la presentation**

Les proprietes retournees par [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/) peuvent egalement etre modifiees sans creer d'instance [Presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/). Appliquez les modifications avec [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/update_document_properties/), puis ecrivez la presentation liee avec [PresentationInfo.write_binded_presentation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/write_binded_presentation/).

L'image suivante montre les proprietes du document d'origine de la presentation PowerPoint.

![Proprietes du document d'origine de la presentation PowerPoint](input_properties.png)

L'exemple suivant modifie le titre et la date de derniere sauvegarde et ecrit le resultat dans un nouveau fichier :

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

L'image suivante montre les proprietes du document mises a jour.

![Proprietes du document modifiees de la presentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour des verifications de securite et des parametres de protection lies, consultez les articles suivants :

- [Proteger les presentations par mot de passe](/slides/fr/python-net/password-protected-presentation/)
- [Proteger les presentations en ecriture](/slides/fr/python-net/write-protected-presentation/)

## **FAQ**

**Comment verifier si les polices sont incorporees et lesquelles le sont ?**

Chargez la presentation et utilisez [Presentation.fonts_manager](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/fonts_manager/). Appelez [FontsManager.get_embedded_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) pour obtenir les polices incorporees et [FontsManager.get_fonts](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_fonts/) pour obtenir les polices utilisees par la presentation. Comparez les deux resultats afin de trouver les polices requises pour le rendu mais non incorporees.

**Comment savoir rapidement si le fichier contient des diapositives masquees et combien ?**

Lorsque les metadonnees du document stockees sont suffisantes, lisez [DocumentProperties.hidden_slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/hidden_slides/) via [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationfactory/get_presentation_info/) et [PresentationInfo.read_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/read_document_properties/). Cela convient pour un inventaire leger. Si la presentation a ete modifiee en memoire, les metadonnees stockees peuvent etre manquantes ou obsoletes, ou si vous devez verifier les valeurs en direct, parcourez [Presentation.slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) et inspectez la propriete [Slide.hidden](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/hidden/) de chaque diapositive a la place.

**Puis-je detecter si une taille de diapositive personnalisee et une orientation sont utilisees, et si elles diffèrent des valeurs par defaut ?**

Oui. Chargez la presentation et lisez [Presentation.slide_size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slide_size/). Inspectez [SlideSize.type](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/type/), [SlideSize.size](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/size/) et [SlideSize.orientation](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidesize/orientation/) pour comparer les parametres actuels avec le preset et les dimensions attendus.

**Existe-t-il un moyen rapide de voir si les graphiques font reference a des sources de donnees externes ?**

Oui. Localisez chaque [Chart](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/) et inspectez [ChartData.data_source_type](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/data_source_type/). Pour un classeur externe, lisez [ChartData.external_workbook_path](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/external_workbook_path/). Le type de source de donnees et le chemin identifient une reference externe, mais verifier si la cible est disponible necessite une verification de ressource separee.

**Comment puis-je evaluer les diapositives 'lourdes' qui pourraient ralentir le rendu ou l'export PDF ?**

Il n'existe pas de propriete unique de complexite. Parcourez [Presentation.slides](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slides/fr/) et la collection [BaseSlide.shapes](https://reference.aspose.com/slides/fr/python-net/aspose.slides/baseslide/shapes/) de chaque diapositive. Utilisez le nombre de formes et la presence d'images volumineuses, d'effets, d'animations ou de multimedia comme signaux de filtrage, et mesurez un rendu ou une exportation representative avant de considerer une diapositive comme un goulet d'entree de performance confirme.