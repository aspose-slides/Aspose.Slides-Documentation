---
title: Exporter vers XAML
type: docs
weight: 30
url: /fr/php-java/export-to-xaml/

---

# Exportation de présentations vers XAML

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/php-java/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté le support pour l'exportation XAML. Vous pouvez désormais exporter vos présentations vers XAML.

{{% /alert %}} 

# À propos de XAML

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et les formulaires Xamarin.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous êtes probablement amené à utiliser un concepteur pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## Exportation de présentations vers XAML avec des options par défaut

Ce code PHP vous montre comment exporter une présentation vers XAML avec les paramètres par défaut :

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

## Exportation de présentations vers XAML avec des options personnalisées

Vous pouvez sélectionner des options à partir de l'interface [IXamlOptions](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives cachées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voici un exemple de code PHP :

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