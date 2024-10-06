---
title: Mise à jour automatique des objets OLE à l'aide d'un complément MS PowerPoint
type: docs
weight: 10
url: /php-java/mise-a-jour-automatique-des-objets-ole-a-l-aide-d-un-complement-ms-powerpoint/
---

## **À propos de la mise à jour automatique des objets OLE**
L'une des questions les plus fréquentes posées par les clients d'Aspose.Slides est comment créer ou modifier des graphiques éditables ou tout autre objet OLE et les faire mettre à jour automatiquement lors de l'ouverture de la présentation. Malheureusement, PowerPoint ne prend pas en charge les macros automatiques, disponibles dans Excel et Word. Les seules disponibles sont les macros Auto_Open et Auto_Close. Cependant, celles-ci ne s'exécutent automatiquement que depuis un complément. Ce court conseil technique montre comment y parvenir. 

Tout d'abord, plusieurs compléments gratuits sont disponibles pour ajouter la fonctionnalité de macro Auto_Open à PowerPoint, par exemple [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) et [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Après avoir installé un tel complément, il suffit d'ajouter la macro Auto_Open() (OnPresentationOpen() dans le cas de "Event Generator") à votre présentation modèle comme indiqué ci-dessous : 

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}





{{% alert color="primary" %}} 

Tout changement apporté aux objets OLE avec Aspose.Slides sera mis à jour automatiquement lorsque PowerPoint ouvrira la présentation. Si vous avez de nombreux objets OLE dans une présentation et ne souhaitez pas les mettre tous à jour, il suffit d'ajouter une balise personnalisée aux formes que vous devez traiter et de la vérifier dans la macro. 

{{% /alert %}}