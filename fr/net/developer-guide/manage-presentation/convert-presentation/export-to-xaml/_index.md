---
title: "Exporter des présentations au format XAML en .NET"
linktitle: "Présentation en XAML"
type: docs
weight: 30
url: /fr/net/export-to-xaml/
keywords:
- "exporter PowerPoint"
- "exporter OpenDocument"
- "exporter présentation"
- "convertir PowerPoint"
- "convertir OpenDocument"
- "convertir présentation"
- "PowerPoint vers XAML"
- "OpenDocument vers XAML"
- "présentation vers XAML"
- "PPT vers XAML"
- "PPTX vers XAML"
- "ODP vers XAML"
- "enregistrer PPT en XAML"
- "enregistrer PPTX en XAML"
- "enregistrer ODP en XAML"
- "exporter PPT en XAML"
- "exporter PPTX en XAML"
- "exporter ODP en XAML"
- ".NET"
- "C#"
- "Aspose.Slides"
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML sous .NET avec Aspose.Slides — solution rapide, sans Office, qui préserve votre mise en page."
---

## **Exporter des présentations au format XAML**

{{% alert title="Info" color="info" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/net/aspose-slides-for-net-21-6-release-notes/), nous avons implémenté la prise en charge de l’exportation XAML. Vous pouvez désormais exporter vos présentations au format XAML. 

{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d’écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## **Exporter des présentations au format XAML avec les options par défaut**

Ce code C# montre comment exporter une présentation au format XAML avec les paramètres par défaut :
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
   pres.Save(new XamlOptions());
}
```


## **Exporter des présentations au format XAML avec des options personnalisées**

Vous avez la possibilité de sélectionner des options depuis l’interface [IXamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions) qui contrôlent le processus d’exportation et déterminent la façon dont Aspose.Slides exporte votre présentation au format XAML. 

Par exemple, si vous souhaitez qu’Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l’exportation au format XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/ixamloptions/properties/exporthiddenslides) sur true. Voir ce code C# d’exemple : 
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save(new XamlOptions { ExportHiddenSlides = true });
}
```


## **FAQ**

**Comment garantir des polices prévisibles si la police originale n’est pas disponible sur la machine ?**

Définissez [DefaultRegularFont](https://reference.aspose.com/slides/net/aspose.slides.export.saveoptions/defaultregularfont/) dans [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — elle est utilisée comme police de secours lorsque la police originale est absente. Cela aide à éviter des substitutions inattendues.

**L’XAML exporté est‑il destiné uniquement à WPF ou peut‑il être utilisé dans d’autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L’exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont‑elles prises en charge et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [ExportHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/exporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/net/aspose.slides.export.xaml/xamloptions/) — laissez‑la désactivée si vous n’avez pas besoin de les exporter.