---
title: Récupérer et mettre à jour les informations de présentation en Python
linktitle: Informations sur la présentation
type: docs
weight: 30
url: /fr/python-net/examine-presentation/
keywords:
- format de présentation
- propriétés de la présentation
- propriétés du document
- obtenir les propriétés
- lire les propriétés
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
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument avec Python pour obtenir des informations plus rapides et des audits de contenu plus intelligents."
---
## **Vue d'ensemble**

Cet article montre comment examiner les informations de présentation dans Aspose.Slides. Il explique comment déterminer le format actuel d’une présentation sans charger le fichier complet, lire ses propriétés de document, et mettre à jour ces propriétés si nécessaire.

Les exemples sont basés sur les API [PresentationInfo](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/) et illustrent les opérations typiques de manipulation des métadonnées d’une présentation.

## **Vérifier le format d’une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir connaître le format (PPT, PPTX, ODP, etc.) de la présentation à ce moment.

Vous pouvez vérifier le format d’une présentation sans la charger. Voir ce code Python :

```py
import aspose.slides as slides

info1 = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
print(info1.load_format, info1.load_format == slides.LoadFormat.PPTX)

info2 = slides.PresentationFactory.instance.get_presentation_info("pres.odp")
print(info2.load_format, info2.load_format == slides.LoadFormat.ODP)

info3 = slides.PresentationFactory.instance.get_presentation_info("pres.ppt")
print(info3.load_format, info3.load_format == slides.LoadFormat.PPT)
```

## **Obtenir les propriétés de la présentation**

Ce code Python montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```

Vous pouvez consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/documentproperties/#properties).

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) qui permet de modifier les propriétés de la présentation.

Supposons que nous ayons une présentation PowerPoint avec les propriétés de document ci‑dessous.

![Propriétés de document d’origine de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :

```py
import aspose.slides as slides
import datetime

file_name = "sample.pptx"

info = slides.PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Les résultats du changement des propriétés de document sont affichés ci‑dessous.

![Propriétés de document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir davantage d’informations sur une présentation et ses attributs de sécurité, ces liens peuvent vous être utiles :

- [Présentations protégées par mot de passe](/slides/fr/python-net/password-protected-presentation/)
- [Présentations protégées en écriture](/slides/fr/python-net/write-protected-presentation/)

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations sur les [polices incorporées](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/fr/python-net/aspose.slides/fontsmanager/get_fonts/) pour identifier les polices critiques pour le rendu.

**Comment savoir rapidement si le fichier comporte des diapositives cachées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/fr/python-net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation de diapositive personnalisées sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive](https://reference.aspose.com/slides/fr/python-net/aspose.slides/presentation/slide_size/) et l’orientation actuelles avec les préréglages standards ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de voir si les graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/fr/python-net/aspose.slides.charts/chartdata/data_source_type/), et notez si les données sont internes ou basées sur un lien, y compris les liens cassés.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’export PDF ?**

Pour chaque diapositive, comptez le nombre d’objets et recherchez les images volumineuses, la transparence, les ombres, les animations et les multimédias ; attribuez un score de complexité approximatif pour identifier les points chauds de performance potentiels.