---
title: Exporter vers XAML
type: docs
weight: 30
url: /androidjava/export-to-xaml/

---

# Exporter des présentations vers XAML

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté le support de l'exportation XAML. Vous pouvez maintenant exporter vos présentations vers XAML.

{{% /alert %}} 

# À propos de XAML

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et les formulaires Xamarin.

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous êtes probablement amené à utiliser un designer pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et éditer votre interface graphique. 

## Exporter des présentations vers XAML avec les options par défaut

Ce code Java vous montre comment exporter une présentation vers XAML avec les paramètres par défaut :

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Exporter des présentations vers XAML avec des options personnalisées

Vous pouvez sélectionner des options à partir de l'interface [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives cachées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voici un exemple de code Java :

```java
Presentation pres = new Presentation("pres.pptx");
try {
	XamlOptions xamlOptions = new XamlOptions();
	xamlOptions.setExportHiddenSlides(true);
	pres.save(xamlOptions);
} finally {
	if (pres != null) pres.dispose();
}
```