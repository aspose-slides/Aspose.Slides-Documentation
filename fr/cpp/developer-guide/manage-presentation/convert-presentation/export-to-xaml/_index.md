---
title: Exporter des présentations vers XAML en C++
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/cpp/export-to-xaml/
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
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT vers XAML
- exporter PPTX vers XAML
- exporter ODP vers XAML
- C++
- Aspose.Slides
description: "Convertir les diapositives PowerPoint et OpenDocument en XAML en C++ avec Aspose.Slides — solution rapide, sans Office, qui conserve votre mise en page intacte."
---

## **Exporter des présentations vers XAML**

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez désormais exporter vos présentations au format XAML. 

{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin forms.  

XAML, qui est un langage basé sur XML, est la variante Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## **Exporter les présentations vers XAML avec les options par défaut**

Ce code C++ montre comment exporter une présentation vers XAML avec les paramètres par défaut :
``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```


## **Exporter les présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner des options depuis l'interface [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation au format XAML, vous pouvez passer true à la méthode [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Voir ce code C++ d'exemple : 
``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```


## **FAQ**

**Comment garantir des polices prévisibles si la police originale n'est pas disponible sur la machine ?**

Utilisez [set_DefaultRegularFont](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_defaultregularfont/) dans [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — il est utilisé comme police de secours lorsque la police originale est manquante. Cela aide à éviter des substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF, ou peut-il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'export cible la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge, et comment empêcher qu'elles soient exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [set_ExportHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/set_exporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export.xaml/xamloptions/) — maintenez-le désactivé si vous n’avez pas besoin de les exporter.