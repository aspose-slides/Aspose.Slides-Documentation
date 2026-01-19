---
title: Exporter des présentations en HTML avec des images liées à l'extérieur en Python
linktitle: Exporter des présentations en HTML avec des images liées à l'extérieur
type: docs
weight: 100
url: /fr/python-net/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- exporter diapositive
- exporter PPT
- exporter PPTX
- exporter ODP
- PowerPoint vers HTML
- OpenDocument vers HTML
- présentation vers HTML
- diapositive vers HTML
- PPT vers HTML
- PPTX vers HTML
- ODP vers HTML
- image liée
- image liée à l'extérieur
- Python
- Aspose.Slides
description: "Apprenez comment exporter des présentations en HTML avec des images liées à l'extérieur dans Aspose.Slides pour Python via .NET, couvrant les formats PowerPoint et OpenDocument."
---

{{% alert color="primary" %}} 

Le processus d'exportation de la présentation vers HTML vous permet de spécifier :

1. les ressources qui sont incorporées dans le fichier HTML résultant, et
1. les ressources qui sont enregistrées à l'extérieur et référencées à partir du fichier HTML.

{{% /alert %}} 

## **Contexte**

Par défaut, l'exportation HTML intègre toutes les ressources directement dans le HTML en utilisant l'encodage Base64. Cela produit un seul fichier HTML autonome, pratique pour la visualisation et la distribution. Cependant, cette approche présente des inconvénients :

* Le fichier résultant est nettement plus volumineux que les ressources d'origine en raison de la surcharge du Base64.
* Les images et autres ressources incorporées sont difficiles à mettre à jour ou à remplacer.

## **Approche alternative**

Une approche alternative utilisant [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) évite ces limitations.

La classe `LinkController` ci‑dessous implémente [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) et est transmise au constructeur [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/__init__/#ilinkembedcontroller). La classe expose trois méthodes qui contrôlent la façon dont les ressources sont incorporées ou liées lors de l'exportation HTML :

[get_object_storing_location(id, entity_data, semantic_name, content_type, recommended_extension)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_object_storing_location/#int-bytes-str-str-str) : Appelée lorsque l'exportateur rencontre une ressource et doit décider où la stocker. Les paramètres les plus importants sont `id` (l'identifiant unique de la ressource pour cette exécution d'exportation) et `content_type` (le type MIME de la ressource). Retournez [LinkEmbedDecision.LINK](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) pour lier la ressource, ou [LinkEmbedDecision.EMBED](https://reference.aspose.com/slides/python-net/aspose.slides.export/linkembeddecision/) pour l'incorporer.

[get_url(id, referrer)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/get_url/#int-int) : Retourne l'URL qui apparaîtra dans le HTML résultant pour la ressource identifiée par `id` (en tenant éventuellement compte de l'objet référent).

[save_external(id, entity_data)](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/save_external/#int-bytes) : Appelée lorsqu'une ressource sélectionnée pour le lien doit être écrite à l'extérieur. Comme l'identifiant et le contenu sont fournis (sous forme de tableau d'octets), vous pouvez persister la ressource comme vous le souhaitez.

L'implémentation Python de `LinkController` de [ILinkEmbedController](https://reference.aspose.com/slides/python-net/aspose.slides.export/ilinkembedcontroller/) suit ci‑dessous.
```py
# [TODO[not_supported_yet]: implémentation Python des interfaces .NET]
```


Après avoir implémenté la classe `LinkController`, vous pouvez l'utiliser avec la classe [HtmlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export/htmloptions/) pour exporter la présentation vers HTML avec des images liées à l'extérieur, comme illustré ci‑dessous :
```py
# [TODO[not_supported_yet]: implémentation Python des interfaces .NET]
```


Nous avons attribué `SlideImageFormat.SVG` à la propriété `slide_image_format` afin que le fichier HTML résultant contienne des données SVG pour rendre le contenu de la présentation.

Types de contenu : Si la présentation contient des images bitmap raster, le code de la classe doit être préparé à traiter les deux types de contenu `image/jpeg` et `image/png`. Le contenu des images bitmap exportées peut ne pas correspondre à ce qui était stocké dans la présentation. Les algorithmes internes d'Aspose.Slides effectuent une optimisation de taille et utilisent le codec JPEG ou PNG (selon celui qui produit la taille de fichier la plus petite). Les images contenant un canal alpha (transparence) sont toujours encodées en PNG.