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
- changer les propriétés
- mettre à jour les propriétés
- examiner PPTX
- examiner PPT
- examiner ODP
- PowerPoint
- OpenDocument
- présentation
- Python
- Aspose.Slides
description: "Explorez les diapositives, la structure et les métadonnées des présentations PowerPoint et OpenDocument avec Python pour des analyses plus rapides et des audits de contenu plus intelligents."
---

Aspose.Slides for Python via .NET vous permet d'examiner une présentation pour connaître ses propriétés et comprendre son comportement.

{{% alert title="Info" color="info" %}} 
Les classes [PresentationInfo](https://reference.aspose.com/slides/python-net/aspose.slides/presentationinfo/) et [DocumentProperties](https://reference.aspose.com/slides/python-net/aspose.slides/documentproperties/) contiennent les propriétés et méthodes utilisées dans les opérations présentées ici.
{{% /alert %}} 

## **Vérifier le format d'une présentation**

Avant de travailler sur une présentation, vous pouvez vouloir savoir quel format (PPT, PPTX, ODP, etc.) la présentation possède actuellement.

Vous pouvez vérifier le format d'une présentation sans la charger. Voir ce code Python :

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

Ce code Python montre comment obtenir les propriétés de la présentation (informations sur la présentation) :

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

Imaginons que nous ayons une présentation PowerPoint avec les propriétés du document affichées ci‑dessous.

![Propriétés du document original de la présentation PowerPoint](input_properties.png)

Cet exemple de code montre comment modifier certaines propriétés de la présentation :

```py
file_name = "sample.pptx"

info = PresentationFactory.instance.get_presentation_info(file_name)

properties = info.read_document_properties()
properties.title = "My title"
properties.last_saved_time = datetime.now()

info.update_document_properties(properties)
info.write_binded_presentation(file_name)
```

Les résultats de la modification des propriétés du document sont affichés ci‑dessous.

![Propriétés du document modifiées de la présentation PowerPoint](output_properties.png)

## **Liens utiles**

Pour obtenir plus d’informations sur une présentation et ses attributs de sécurité, vous trouverez probablement ces liens utiles :

- [Vérifier si une présentation est chiffrée](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-encrypted)
- [Vérifier si une présentation est protégée en écriture (lecture seule)](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-write-protected)
- [Vérifier si une présentation est protégée par mot de passe avant de la charger](https://docs.aspose.com/slides/python-net/password-protected-presentation/#checking-whether-a-presentation-is-password-protected-before-loading-it)
- [Confirmer le mot de passe utilisé pour protéger une présentation](https://docs.aspose.com/slides/python-net/password-protected-presentation/#validating-or-confirming-that-a-specific-password-has-been-used-to-protect-a-presentation).

## **FAQ**

**Comment puis‑je vérifier si les polices sont incorporées et lesquelles ?**

Recherchez les informations de [polices incorporées](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_embedded_fonts/) au niveau de la présentation, puis comparez ces entrées avec l’ensemble des [polices réellement utilisées dans le contenu](https://reference.aspose.com/slides/python-net/aspose.slides/fontsmanager/get_fonts/) afin d’identifier les polices cruciales pour le rendu.

**Comment savoir rapidement si le fichier contient des diapositives masquées et combien ?**

Parcourez la [collection de diapositives](https://reference.aspose.com/slides/python-net/aspose.slides/slidecollection/) et examinez le [drapeau de visibilité](https://reference.aspose.com/slides/python-net/aspose.slides/slide/hidden/) de chaque diapositive.

**Puis‑je détecter si une taille et une orientation personnalisées de diapositive sont utilisées, et si elles diffèrent des valeurs par défaut ?**

Oui. Comparez la [taille de diapositive actuelle](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/slide_size/) et son orientation avec les préréglages standards ; cela aide à anticiper le comportement lors de l’impression et de l’exportation.

**Existe‑t‑il un moyen rapide de voir si des graphiques référencent des sources de données externes ?**

Oui. Parcourez tous les [graphiques](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chart/), vérifiez leur [source de données](https://reference.aspose.com/slides/python-net/aspose.slides.charts/chartdata/data_source_type/) et notez si les données sont internes ou basées sur un lien, y compris les liens rompus.

**Comment évaluer les diapositives « lourdes » qui pourraient ralentir le rendu ou l’exportation PDF ?**

Pour chaque diapositive, comptez les objets et recherchez les images volumineuses, la transparence, les ombres, les animations et le multimédia ; attribuez un score de complexité approximatif afin de signaler les points chauds potentiels de performance.