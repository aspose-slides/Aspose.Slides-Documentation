---
title: Mettre à jour automatiquement les objets OLE à l'aide d'un module complémentaire PowerPoint
type: docs
weight: 10
url: /fr/java/updating-ole-objects-automatically-using-ms-powerpoint-add-in/
keywords:
- OLE
- objet OLE
- mise à jour OLE
- automatiquement
- module complémentaire
- PowerPoint
- présentation
- Java
- Aspose.Slides
description: "Découvrez comment mettre à jour automatiquement les graphiques et objets OLE dans PowerPoint à l'aide d'un module complémentaire et d'Aspose.Slides pour Java, avec du code pratique et des conseils d'optimisation."
---

## **Mettre à jour automatiquement les objets OLE**

Une des questions les plus fréquentes posées par les clients d'Aspose.Slides for Java est de savoir comment créer ou modifier des graphiques modifiables (ou d'autres objets OLE) afin qu'ils se mettent à jour automatiquement à l'ouverture de la présentation. Malheureusement, PowerPoint ne prend pas en charge les macros automatiques de la même manière qu'Excel et Word. Les seules macros disponibles sont `Auto_Open` et `Auto_Close`, et elles ne s'exécutent automatiquement que depuis un module complémentaire. Ce court conseil technique montre comment y parvenir.

Tout d'abord, plusieurs modules complémentaires gratuits existent qui ajoutent la fonctionnalité de macro Auto_Open à PowerPoint, par exemple [AutoEvents Add-in](http://skp.mvps.org/autoevents.htm) et [Event Generator](https://www.officeoneonline.com/eventgen/eventgen.html).

Après avoir installé l'un de ces modules complémentaires, ajoutez simplement la macro `Auto_Open()` (ou `OnPresentationOpen()` si vous utilisez Event Generator) à votre présentation modèle comme indiqué ci-dessous :
```java
// Parcourir chaque diapositive de la présentation.
for (var oSlide : ActivePresentation.Slides) {
    // Parcourir toutes les formes de la diapositive actuelle.
    for (var oShape : oSlide.Shapes) {
        // Vérifier si la forme est un objet OLE.
        if ((oShape.Type == msoEmbeddedOLEObject)) {
            // Objet OLE trouvé. Obtenir sa référence d'objet puis le mettre à jour.
            oObject = oShape.OLEFormat.Object;
            oObject.Application.Update();
            // Maintenant, quitter le programme serveur OLE.
            // Cela libère la mémoire et évite tout problème.
            // Aussi, mettre oObject à Nothing pour libérer l'objet.
            oObject.Application.Quit();
            oObject = null;
        }
    }
}
```


Toutes les modifications apportées aux objets OLE avec Aspose.Slides for Java seront automatiquement mises à jour lorsque PowerPoint ouvrira la présentation. Si vous avez de nombreux objets OLE et que vous ne souhaitez pas tous les mettre à jour, ajoutez simplement une balise personnalisée aux formes que vous devez traiter et vérifiez-la dans la macro.