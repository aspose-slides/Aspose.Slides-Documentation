---
title: Récupérer et mettre à jour les informations de présentation en Python
linktitle: Informations de présentation
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

Aspose.Slides pour Python via .NET vous permet d'examiner une présentation afin d'en connaître les propriétés et de comprendre son comportement. 

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contiennent les propriétés et les méthodes utilisées dans les opérations présentées ici.

{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir dans quel format (PPT, PPTX, ODP, etc.) elle se trouve actuellement.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code Python :
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

Ce code Python vous montre comment obtenir les propriétés de la présentation (informations sur la présentation) :
```py
import aspose.slides as slides

info = slides.PresentationFactory.instance.get_presentation_info("pres.pptx")
props = info.read_document_properties()
print(props.created_time)
print(props.subject)
print(props.title)
```


Vous pouvez également consulter les [propriétés de la classe DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) qui permet de modifier les propriétés d'une présentation.

Imaginons que nous ayons une présentation PowerPoint avec les propriétés de document illustrées ci‑dessous.

![Original document properties of the PowerPoint presentation](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :
```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```


Les résultats de la modification des propriétés de document sont présentés ci‑dessous.

![Changed document properties of the PowerPoint presentation](output_properties.png)

## **Liens utiles**

Pour obtenir davantage d'informations sur une présentation et ses attributs de sécurité, ces liens peuvent vous être utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant son chargement](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les [informations sur les polices incorporées](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) pour identifier les polices essentielles au rendu.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) et inspectez le [drapeau de visibilité](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille ou une orientation de diapositive personnalisée est utilisée, et si elle diffère des paramètres par défaut ?**

Oui. Comparez la [taille de diapositive actuelle](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) et son orientation avec les préréglages standards ; cela permet d’anticiper le comportement lors de l’impression ou de l’exportation.

**Existe‑t‑il un moyen rapide de voir si des graphiques font référence à des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) et notez si les données sont internes ou liées, y compris les liens cassés.

**Comment évaluer les diapositives « lourdes » qui peuvent ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez les objets et repérez les images volumineuses, les transparences, les ombres, les animations et les contenus multimédias ; attribuez un score de complexité approximatif afin d’identifier les points de performance potentiels.