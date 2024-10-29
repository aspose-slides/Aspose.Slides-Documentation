---
title: Exporter vers XAML
type: docs
weight: 30
url: /fr/net/export-to-xaml/
keywords: "Exporter Présentation PowerPoint, Convertir PowerPoint, XAML, PowerPoint en XAML, PPT en XAML, PPTX en XAML, C#, Csharp, .NET"
description: "Exporter ou convertir une présentation PowerPoint en XAML"
---

# Exportation de Présentations vers XAML

{{% alert title="Info" color="info" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), nous avons implémenté le support pour l'exportation XAML. Vous pouvez désormais exporter vos présentations en XAML. 

{{% /alert %}} 

# À Propos de XAML

XAML est un langage de programmation descriptif qui vous permet de construire ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous allez probablement utiliser un designer pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et éditer votre interface graphique. 

## Exportation de Présentations vers XAML avec les Options Par Défaut

Ce code C# vous montre comment exporter une présentation en XAML avec les paramètres par défaut :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```

## Exportation de Présentations vers XAML avec des Options Personnalisées

Vous pouvez sélectionner des options dans l'interface [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation en XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives cachées de votre présentation lors de son exportation en XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) sur true. Voir cet exemple de code C# : 

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```