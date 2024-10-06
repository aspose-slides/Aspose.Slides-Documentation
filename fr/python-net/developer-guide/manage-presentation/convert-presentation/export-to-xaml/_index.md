---
title: Exporter vers XAML
type: docs
weight: 30
url: /python-net/export-to-xaml/
keywords: "Exporter une présentation PowerPoint, Convertir PowerPoint, XAML, PowerPoint en XAML, PPT en XAML, PPTX en XAML, Python"
description: "Exporter ou convertir une présentation PowerPoint en XAML"
---

# Exportation de présentations vers XAML

{{% alert title="Info" color="info" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), nous avons mis en œuvre le support de l'exportation XAML. Vous pouvez désormais exporter vos présentations en XAML. 

{{% /alert %}} 

# À propos de XAML

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous êtes susceptible d'utiliser un designer pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et éditer votre interface graphique. 

## Exportation de présentations vers XAML avec les options par défaut

Ce code Python vous montre comment exporter une présentation en XAML avec les paramètres par défaut :

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```

## Exportation de présentations vers XAML avec des options personnalisées

Vous pouvez sélectionner des options depuis l'interface [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation en XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives cachées de votre présentation lors de son exportation en XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) sur true. Voici un exemple de code Python : 

```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```