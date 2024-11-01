---
title: Mise à jour automatique des objets OLE à l'aide du module complémentaire MS PowerPoint
type: docs
weight: 10
url: /fr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
---

## **À propos de la mise à jour automatique des objets OLE**
L'une des questions les plus fréquemment posées par les clients d'Aspose.Slides est de savoir comment créer ou modifier des graphiques modifiables ou tout autre objet OLE et les faire mettre à jour automatiquement lors de l'ouverture de la présentation. Malheureusement, PowerPoint ne prend pas en charge les macros automatiques, qui sont disponibles dans Excel et Word. Celles qui sont disponibles sont uniquement les macros Auto_Open et Auto_Close. Cependant, celles-ci ne s'exécutent automatiquement que depuis un module complémentaire. Ce court conseil technique montre comment y parvenir.

Tout d'abord, plusieurs modules complémentaires gratuits sont disponibles pour ajouter la fonctionnalité de macro Auto_Open à PowerPoint, par exemple [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) et [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Après avoir installé un tel module complémentaire, ajoutez simplement la macro Auto_Open() (OnPresentationOpen() dans le cas de "Event Generator") à votre présentation modèle comme indiqué ci-dessous :

{{< gist "mannanfazil" "c31114d3fe29596f0a53817b8f8705ac" "Examples-src-main-java-com-aspose-slides-examples-Slides-Shapes-UpdateOLEObject-UpdateOLEObject.java" >}}



{{% alert color="primary" %}} 

Toute modification apportée aux objets OLE avec Aspose.Slides sera mise à jour automatiquement lorsque PowerPoint ouvrira la présentation. Si vous avez de nombreux objets OLE dans une présentation et que vous ne souhaitez pas tous les mettre à jour, ajoutez simplement une balise personnalisée aux formes que vous devez traiter et vérifiez-la dans la macro.

{{% /alert %}}