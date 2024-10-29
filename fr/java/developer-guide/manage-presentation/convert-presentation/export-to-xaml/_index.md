---
title: Exporter en XAML
type: docs
weight: 30
url: /fr/java/export-to-xaml/

---

# Exportation de Présentations en XAML

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/java/aspose-slides-for-java-21-6-release-notes/), nous avons mis en œuvre le support de l'exportation en XAML. Vous pouvez désormais exporter vos présentations en XAML. 

{{% /alert %}} 

# À propos de XAML

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et les formulaires Xamarin.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous êtes susceptibles d'utiliser un concepteur pour travailler sur des fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique. 

## Exportation de Présentations en XAML avec Options Par Défaut

Ce code Java vous montre comment exporter une présentation en XAML avec les paramètres par défaut :

```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```

## Exportation de Présentations en XAML avec Options Personnalisées

Vous pouvez sélectionner des options dans l'interface [IXamlOptions](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation en XAML. 

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute des diapositives masquées de votre présentation lors de l'exportation en XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voici cet exemple de code Java : 

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