---
title: Extraire des objets Flash des présentations en C++
linktitle: Flash
type: docs
weight: 10
url: /fr/cpp/flash/
keywords:
- extraire flash
- objet flash
- PowerPoint
- OpenDocument
- présentation
- C++
- Aspose.Slides
description: "Apprenez comment extraire les objets Flash des diapositives PowerPoint et OpenDocument en C++ avec Aspose.Slides, des exemples de code complets et les meilleures pratiques."
---

## **Extraire des objets Flash des présentations**
Aspose.Slides for C++ fournit une fonctionnalité d'extraction d'objets flash d'une présentation. Vous pouvez accéder au contrôle flash par son nom et l'extraire de la présentation, y compris stocker les données d'objet SWF.
``` cpp
auto pres = System::MakeObject<Presentation>(u"withFlash.pptm");
auto controls = pres->get_Slides()->idx_get(0)->get_Controls();
System::SharedPtr<Control> flashControl;
for (const auto& control : controls)
{
    if (control->get_Name() == u"ShockwaveFlash1")
    {
        flashControl = System::ExplicitCast<Control>(control);
    }
}
```


## **FAQ**

**Quels formats de présentation sont pris en charge lors de l'extraction de contenu Flash ?**

[Aspose.Slides supports](/slides/fr/cpp/supported-file-formats/) les principaux formats PowerPoint tels que PPT et PPTX, car il peut charger ces conteneurs et accéder à leurs contrôles, y compris les éléments ActiveX liés à Flash.

**Puis-je convertir une présentation contenant du Flash en HTML5 et préserver l'interactivité Flash ?**

Non. Aspose.Slides n'exécute pas le contenu SWF ni ne convertit son interactivité. Bien que l'exportation vers [HTML](/slides/fr/cpp/convert-powerpoint-to-html/)/[HTML5](/slides/fr/cpp/export-to-html5/) soit prise en charge, le Flash ne fonctionnera pas dans les navigateurs modernes en raison de la fin de son support. Le chemin recommandé est de remplacer le Flash par des alternatives telles que la vidéo ou des animations HTML5 avant l'exportation.

**D'un point de vue sécurité, Aspose.Slides exécute-t-il des fichiers SWF lors de la lecture d'une présentation ?**

Non. Aspose.Slides considère le Flash comme des données binaires intégrées au fichier et n'exécute pas le contenu SWF pendant le traitement.

**Comment gérer les présentations incluant du Flash ainsi que d'autres fichiers intégrés via OLE ?**

Aspose.Slides prend en charge [extraction d'objets OLE intégrés](/slides/fr/cpp/manage-ole/), vous pouvez donc traiter tout le contenu intégré associé en une seule passe, en manipulant les contrôles Flash et les autres documents intégrés via OLE ensemble.