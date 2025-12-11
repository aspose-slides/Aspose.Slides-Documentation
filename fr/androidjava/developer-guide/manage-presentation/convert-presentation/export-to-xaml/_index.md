---
title: Exporter les présentations au format XAML sur Android
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/androidjava/export-to-xaml/
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
- enregistrer PPT en XAML
- enregistrer PPTX en XAML
- enregistrer ODP en XAML
- exporter PPT en XAML
- exporter PPTX en XAML
- exporter ODP en XAML
- Android
- Java
- Aspose.Slides
description: "Convertir les diapositives PowerPoint et OpenDocument en XAML avec Java en utilisant Aspose.Slides pour Android - solution rapide, sans besoin d'Office, qui préserve votre mise en page."
---

## **Exportation des présentations vers XAML**

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez désormais exporter vos présentations vers XAML.

{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour les applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface.

## **Exportation des présentations vers XAML avec les options par défaut**

Ce code Java montre comment exporter une présentation vers XAML avec les paramètres par défaut :
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Exportation des présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner les options de l'interface [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous voulez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voir ce code Java d'exemple :
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


## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Définissez [une police régulière par défaut](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — elle est utilisée comme police de secours lorsque la police d'origine est absente. Cela aide à éviter les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — laissez-la désactivée si vous n'avez pas besoin de les exporter.