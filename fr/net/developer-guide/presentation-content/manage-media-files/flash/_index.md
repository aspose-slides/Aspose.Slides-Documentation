---
title: Flash
type: docs
weight: 10
url: /fr/net/flash/
keywords: "Extraire le flash, présentation PowerPoint, C#, Csharp, Aspose.Slides for .NET"
description: "Extraire l'objet flash d'une présentation PowerPoint en C# ou .NET"
---

## **Extraire les objets Flash d’une présentation**
Aspose.Slides for .NET offre une fonctionnalité d’extraction d’objets flash d’une présentation. Vous pouvez accéder au contrôle flash par son nom, l’extraire de la présentation et enregistrer les données de l’objet SWF.
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

**Quels formats de présentation sont pris en charge lors de l’extraction de contenu Flash ?**

[Aspose.Slides supports](/slides/fr/net/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 tout en conservant l’interactivité Flash ?**

Non. Aspose.Slides n’exécute pas le contenu SWF et ne convertit pas son interactivité. Bien que l’exportation vers [HTML](/slides/fr/net/convert-powerpoint-to-html/)/[HTML5](/slides/fr/net/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. La solution recommandée consiste à remplacer le Flash par des alternatives telles que la vidéo ou des animations HTML5 avant l’exportation.

**D’un point de vue sécuritaire, Aspose.Slides exécute-t‑il des fichiers SWF lors de la lecture d’une présentation ?**

Non. Aspose.Slides considère le Flash comme des données binaires intégrées au fichier et n’exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations qui contiennent du Flash ainsi que d’autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [l’extraction d’objets OLE intégrés](/slides/fr/net/manage-ole/), vous permettant de traiter tout le contenu intégré lié en une seule passe, en gérant les contrôles Flash et les autres documents intégrés via OLE ensemble.