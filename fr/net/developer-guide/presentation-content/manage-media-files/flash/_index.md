---
title: Extraire les objets Flash des présentations en .NET
linktitle: Flash
type: docs
weight: 10
url: /fr/net/flash/
keywords:
- extraire flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Découvrez comment extraire des objets Flash des diapositives PowerPoint et OpenDocument en .NET avec Aspose.Slides, avec des exemples de code C# complets et les meilleures pratiques."
---

## **Extraire des objets Flash des présentations**
Aspose.Slides for .NET offre une fonctionnalité d'extraction des objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris les données d'objet SWF stockées.
```c#
using (Presentation pres = new Presentation("withFlash.pptm"))
{
    IControlCollection controls = pres.Slides[0].Controls;
    Control flashControl = null;
    foreach (IControl control in controls)
    {
        if (control.Name == "ShockwaveFlash1")
        {
            flashControl = (Control)control;
        }
    }
}
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l'extraction de contenu Flash ?**

[Aspose.Slides prend en charge](/slides/fr/net/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et conserver l’interactivité du Flash ?**

Non. Aspose.Slides n'exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l'exportation vers [HTML](/slides/fr/net/convert-powerpoint-to-html/)/[HTML5](/slides/fr/net/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. La solution recommandée est de remplacer le Flash par des alternatives telles que la vidéo ou les animations HTML5 avant l'exportation.

**Du point de vue de la sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d'une présentation ?**

Non. Aspose.Slides traite le Flash comme des données binaires intégrées au fichier et n'exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations qui incluent du Flash ainsi que d'autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [extraction des objets OLE intégrés](/slides/fr/net/manage-ole/), vous permettant de traiter tout le contenu intégré en une seule passe, en gérant les contrôles Flash et les autres documents intégrés via OLE ensemble.