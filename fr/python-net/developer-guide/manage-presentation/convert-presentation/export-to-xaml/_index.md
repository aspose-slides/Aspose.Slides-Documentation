---
title: Exporter des présentations au format XAML avec Python
linktitle: Exporter en XAML
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
- PowerPoint en XAML
- OpenDocument en XAML
- présentation en XAML
- PPT en XAML
- PPTX en XAML
- ODP en XAML
- Python
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Python en utilisant Aspose.Slides—solution rapide, sans Office, qui préserve votre mise en page."
---

## **Vue d'ensemble**

XAML est un langage de programmation descriptif qui vous permet de créer ou d’écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utiliserez très probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## **Exporter des présentations au format XAML avec les options par défaut**

Ce code Python vous montre comment exporter une présentation en XAML avec les paramètres par défaut :
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")
pres.save(slides.export.xaml.XamlOptions())
```


## **Exporter des présentations au format XAML avec des options personnalisées**

Vous pouvez sélectionner des options de la classe [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) qui contrôlent le processus d’exportation et déterminent la façon dont Aspose.Slides exporte votre présentation en XAML. 

Par exemple, si vous souhaitez qu’Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l’exportation en XAML, vous pouvez définir la propriété [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) sur `True`. Voir cet exemple de code Python : 
```py
import aspose.slides as slides

pres = slides.Presentation("pres.pptx")

opt = slides.export.xaml.XamlOptions()
opt.export_hidden_slides = True

pres.save(opt)
```


## **FAQ**

**Comment garantir des polices prévisibles si la police d’origine n’est pas disponible sur la machine ?**

Définissez [default_regular_font](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/default_regular_font/) dans [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — c’est la police de secours utilisée lorsque la police originale est manquante. Cela évite les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d’autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L’exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont‑elles prises en charge, et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [export_hidden_slides](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/export_hidden_slides/) dans [XamlOptions](https://reference.aspose.com/slides/python-net/aspose.slides.export.xaml/xamloptions/) — laissez‑la désactivée si vous ne devez pas les exporter.