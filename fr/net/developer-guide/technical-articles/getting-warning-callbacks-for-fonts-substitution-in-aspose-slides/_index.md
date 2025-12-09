---
title: Obtenir des rappels d'avertissement pour la substitution de police en .NET
type: docs
weight: 120
url: /fr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- rappel d'avertissement
- substitution de police
- processus de rendu
- PowerPoint
- OpenDocument
- présentation
- .NET
- C#
- Aspose.Slides
description: "Apprenez à obtenir des rappels d'avertissement pour la substitution de police dans Aspose.Slides pour .NET et à afficher les présentations PowerPoint et OpenDocument avec précision."
---

## **Vue d'ensemble**

Aspose.Slides for .NET vous permet de recevoir des rappels d’avertissement pour la substitution de police lorsqu’une police requise n’est pas disponible sur la machine pendant le rendu. Ces rappels aident à diagnostiquer les problèmes de polices manquantes ou inaccessibles.

## **Activer les rappels d’avertissement**

Aspose.Slides for .NET propose des API simples pour recevoir des rappels d’avertissement lors du rendu des diapositives de présentation. Suivez ces étapes pour configurer les rappels d’avertissement :

1. Créez une classe de rappel personnalisée qui implémente l’interface [IWarningCallback](https://reference.aspose.com/slides/net/aspose.slides.warnings/iwarningcallback/) pour gérer les avertissements.
1. Définissez le rappel d’avertissement à l’aide des classes d’options telles que [RenderingOptions](https://reference.aspose.com/slides/net/aspose.slides.export/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/net/aspose.slides.export/htmloptions/) et d’autres.
1. Chargez une présentation qui utilise une police non disponible sur la machine cible.
1. Générez une miniature de diapositive ou exportez la présentation pour observer l’effet.

**Classe de rappel d’avertissement personnalisée :**  
```c#
class FontWarningHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss)
        {
            Console.WriteLine(warning.Description);
        }

        return ReturnAction.Continue;
    }
}

// Exemple de sortie:
//
// La police sera substituée de XYZ à {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```


**Générer une miniature de diapositive :**  
```c#
 // Configurer un rappel d’avertissement pour gérer les avertissements liés aux polices lors du rendu des diapositives.
 var options = new RenderingOptions();
 options.WarningCallback = new FontWarningHandler();

 // Charger la présentation depuis le chemin de fichier spécifié.
 using var presentation = new Presentation("sample.pptx");

 // Générer une image miniature pour chaque diapositive de la présentation.
 foreach (var slide in presentation.Slides)
 {
     // Obtenir l’image miniature de la diapositive en utilisant les options de rendu spécifiées.
     using var image = slide.GetImage(options);
     // ...
 }
```


**Exporter au format PDF :**  
```c#
// Configurer un rappel d’avertissement pour gérer les avertissements liés aux polices lors de l’exportation PDF.
var options = new PdfOptions();
options.WarningCallback = new FontWarningHandler();

// Charger la présentation depuis le chemin de fichier spécifié.
using var presentation = new Presentation("sample.pptx");

// Exporter la présentation au format PDF.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Pdf, options);
// ...
```


**Exporter au format HTML :**  
```c#
// Configurer un rappel d'avertissement pour gérer les avertissements liés aux polices lors de l'exportation HTML.
var options = new HtmlOptions();
options.WarningCallback = new FontWarningHandler();

// Charger la présentation depuis le chemin de fichier spécifié.
using var presentation = new Presentation("sample.pptx");

// Exporter la présentation au format HTML.
using var stream = new MemoryStream();
presentation.Save(stream, SaveFormat.Html, options);
// ...
```
