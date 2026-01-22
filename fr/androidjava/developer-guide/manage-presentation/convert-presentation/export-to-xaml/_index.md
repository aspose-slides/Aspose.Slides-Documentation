---
title: Exporter des présentations vers XAML sur Android
linktitle: Présentation vers XAML
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
- Android
- Java
- Aspose.Slides
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML en Java avec Aspose.Slides pour Android — solution rapide, sans Office, qui préserve la mise en page."
---

## **Exporter des présentations vers XAML**

Aspose.Slides prend en charge l'exportation XAML. Vous pouvez convertir vos présentations au format XAML.

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  
XAML, qui est un langage basé sur XML, est la variante Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez toujours écrire et modifier votre interface graphique.

## **Exporter des présentations vers XAML avec les options par défaut**

Ce code Java montre comment exporter une présentation vers XAML avec les paramètres par défaut :
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Exporter des présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner des options dans l'interface [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation vers XAML.

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voir cet exemple de code Java :
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

Définissez [une police régulière par défaut](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — elle est utilisée comme police de secours lorsque l'originale est manquante. Cela permet d'éviter des substitutions inattendues.

**Le XAML exporté est‑il destiné uniquement à WPF ou peut‑il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation vise la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont‑elles prises en charge et comment empêcher leur exportation par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — conservez‑le désactivé si vous n'avez pas besoin de les exporter.