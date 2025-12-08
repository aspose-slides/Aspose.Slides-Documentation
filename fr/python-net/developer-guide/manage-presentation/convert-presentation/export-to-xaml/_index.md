---
title: Exporter des présentations vers XAML avec Python
linktitle: Exporter vers XAML
type: docs
weight: 30
url: /fr/python-net/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir présentation
- PowerPoint vers XAML
- OpenDocument vers XAML
- présentation vers XAML
- PPT vers XAML
- PPTX vers XAML
- ODP vers XAML
- Python
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Python et Aspose.Slides — solution rapide, sans Office, qui conserve votre mise en page intacte."
---

## **Vue d'ensemble**

{{% alert title="Info" color="info" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/python-net/aspose-slides-for-net-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez désormais exporter vos présentations vers XAML. 

{{% /alert %}} 

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## **Exporter des présentations vers XAML avec les options par défaut**

Ce code Python vous montre comment exporter une présentation vers XAML avec les paramètres par défaut :
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **Exporter des présentations vers XAML avec des options personnalisées**

Vous pouvez choisir des options depuis l'interface [IXamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/ixamloptions/) sur true. Voir cet exemple de code Python : 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Définissez [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) dans [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — elle est utilisée comme police de secours lorsque la police d'origine est absente. Cela aide à éviter les substitutions inattendues.

**Le XAML exporté est‑il destiné uniquement à WPF, ou peut‑il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont‑elles prises en charge, et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) dans [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — maintenez‑le désactivé si vous n'avez pas besoin de les exporter.