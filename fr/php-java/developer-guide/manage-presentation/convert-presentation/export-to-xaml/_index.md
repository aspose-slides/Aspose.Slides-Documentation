---
title: Exporter des présentations vers XAML en PHP
linktitle: Présentation vers XAML
type: docs
weight: 30
url: /fr/php-java/export-to-xaml/
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
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- PHP
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Aspose.Slides pour PHP via Java — une solution rapide, sans Office, qui conserve votre mise en page intacte."
---

## **Exporter des présentations vers XAML**

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez désormais exporter vos présentations vers XAML.

{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface. 

## **Exporter des présentations vers XAML avec les options par défaut**

Ce code PHP montre comment exporter une présentation vers XAML avec les paramètres par défaut :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $pres->save(new XamlOptions());
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **Exporter des présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner des options depuis l'interface [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) qui contrôle le processus d'exportation et détermine comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voir ce code PHP d'exemple :
```php
  $pres = new Presentation("pres.pptx");
  try {
    $xamlOptions = new XamlOptions();
    $xamlOptions->setExportHiddenSlides(true);
    $pres->save($xamlOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```


## **FAQ**

**Comment garantir des polices prévisibles si la police originale n'est pas disponible sur la machine ?**

Définissez [une police régulière par défaut](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — elle est utilisée comme police de secours lorsque la police d'origine est manquante. Cela permet d'éviter les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation cible la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — laissez-le désactivé si vous n'avez pas besoin de les exporter.