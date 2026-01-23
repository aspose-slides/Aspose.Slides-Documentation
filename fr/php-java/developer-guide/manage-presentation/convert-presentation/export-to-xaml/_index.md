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
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML à l'aide d'Aspose.Slides pour PHP via Java — solution rapide, sans Office, qui conserve votre mise en page intacte."
---

## **Exporter des présentations vers XAML**

Aspose.Slides prend en charge l'exportation XAML. Vous pouvez convertir vos présentations en XAML.

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## **Exporter des présentations vers XAML avec les options par défaut**

Ce code PHP vous montre comment exporter une présentation vers XAML avec les paramètres par défaut:
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

Vous pouvez sélectionner des options dans la classe [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) qui contrôle le processus d'exportation et détermine comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous voulez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez utiliser la méthode [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) avec la valeur `true`. Voir cet exemple de code PHP:
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

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Définissez [une police régulière par défaut](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — elle est utilisée comme police de secours lorsque la police d'origine est absente. Cela permet d'éviter les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge des constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/setexporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/xamloptions/) — laissez-le désactivé si vous n'avez pas besoin de les exporter.