---
title: Exporter vers XAML
type: docs
weight: 30
url: /fr/cpp/export-to-xaml/

---

# Exportation de présentations vers XAML

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/cpp/aspose-slides-for-cpp-21-6-release-notes/), nous avons implémenté le support pour l'exportation XAML. Vous pouvez maintenant exporter vos présentations vers XAML. 

{{% /alert %}} 

# À propos de XAML

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## Exportation de présentations vers XAML avec les options par défaut

Ce code C++ vous montre comment exporter une présentation vers XAML avec les paramètres par défaut :

``` cpp
auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(System::MakeObject<XamlOptions>());
```

## Exportation de présentations vers XAML avec des options personnalisées

Vous pouvez sélectionner des options dans l'interface [IXamlOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives cachées de votre présentation lors de l'exportation vers XAML, vous pouvez passer true au méthode [set_ExportHiddenSlides()](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.xaml.i_xaml_options#a94c59a06cc2163b17e6fa2fe817c0313). Voir cet exemple de code C++ : 

``` cpp
auto xamlOptions = System::MakeObject<XamlOptions>();
xamlOptions->set_ExportHiddenSlides(true);

auto pres = System::MakeObject<Presentation>(u"pres.pptx");
pres->Save(xamlOptions);
```