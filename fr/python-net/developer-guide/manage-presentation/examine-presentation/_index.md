---
title: Examiner la présentation
type: docs
weight: 30
url: /python-net/examine-presentation/
keywords:
- PowerPoint
- présentation
- format de présentation
- propriétés de présentation
- propriétés du document
- obtenir des propriétés
- lire des propriétés
- changer des propriétés
- modifier des propriétés
- PPTX
- PPT
- Python
description: "Lire et modifier les propriétés de la présentation PowerPoint en Python"
---

Aspose.Slides pour Python via .NET vous permet d'examiner une présentation pour découvrir ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 

Les classes [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations ici.

{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous voudrez peut-être savoir dans quel format (PPT, PPTX, ODP, et autres) se trouve actuellement la présentation.

Vous pouvez vérifier le format d'une présentation sans charger la présentation. Voir ce code Python :

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

Vous voudrez peut-être voir les [propriétés sous la classe DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/#properties).

## **Mettre à jour les propriétés de la présentation**

Aspose.Slides fournit la méthode [PresentationInfo.update_document_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/update_document_properties/#idocumentproperties) qui vous permet de modifier les propriétés de la présentation.

Disons que nous avons une présentation PowerPoint avec les propriétés du document montrées ci-dessous.

![Propriétés du document originales de la présentation PowerPoint](input_properties.png)

Cet exemple de code vous montre comment modifier certaines propriétés de la présentation :

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "Mon titre"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Les résultats des modifications des propriétés du document sont montrés ci-dessous.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d'informations sur une présentation et ses attributs de sécurité, vous trouverez ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par un mot de passe avant de la charger](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).