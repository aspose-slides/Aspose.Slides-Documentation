---
title: Exporter des présentations vers XAML sur Android
linktitle: Présentation en XAML
type: docs
weight: 30
url: /fr/androidjava/export-to-xaml/
keywords:
- exporter PowerPoint
- exporter OpenDocument
- exporter une présentation
- convertir PowerPoint
- convertir OpenDocument
- convertir une présentation
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
description: "Convertissez les diapositives PowerPoint et OpenDocument en XAML avec Java en utilisant Aspose.Slides pour Android - solution rapide, sans Office, qui préserve votre mise en page."
---

## **Exporter les présentations vers XAML**

{{% alert color="primary" %}} 
Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/androidjava/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez désormais exporter vos présentations vers XAML.
{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d’écrire des interfaces utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.  
XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utilisez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez également écrire et modifier votre interface graphique. 

## **Exporter les présentations vers XAML avec les options par défaut**

Ce code Java montre comment exporter une présentation vers XAML avec les paramètres par défaut :
```java
Presentation pres = new Presentation("pres.pptx");
try {
	pres.save(new XamlOptions());
} finally {
	if (pres != null) pres.dispose();
}
```


## **Exporter les présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner des options dans l’interface [IXamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions) qui contrôlent le processus d’exportation et déterminent la façon dont Aspose.Slides exporte votre présentation vers XAML.  

Par exemple, si vous souhaitez qu’Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l’exportation vers XAML, vous pouvez régler la propriété [ExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/IXamlOptions#setExportHiddenSlides-boolean-) sur true. Voir ce code Java d’exemple :
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

**Comment garantir des polices prévisibles si la police originale n’est pas disponible sur la machine ?**

Définissez [une police régulière par défaut](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setDefaultRegularFont-java.lang.String-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/). Elle est utilisée comme police de secours lorsque la police originale est manquante. Cela aide à éviter les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d’autres piles XAML également ?**

XAML est un langage de balisage d’interface utilisateur général utilisé dans WPF, UWP et Xamarin.Forms. L’exportation cible la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de certaines constructions dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge et comment les empêcher d’être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/#setExportHiddenSlides-boolean-) dans [XamlOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/xamloptions/) — laissez-le désactivé si vous n’avez pas besoin de les exporter.