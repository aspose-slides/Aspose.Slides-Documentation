---
title: Exportation vers XAML
type: docs
weight: 30
url: /fr/nodejs-java/export-to-xaml/
---

## **Exportation de présentations vers XAML**

{{% alert color="primary" %}} 

Dans [Aspose.Slides 21.6](https://docs.aspose.com/slides/nodejs-java/aspose-slides-for-java-21-6-release-notes/), nous avons implémenté la prise en charge de l'exportation XAML. Vous pouvez maintenant exporter vos présentations au format XAML.

{{% /alert %}} 

## **À propos de XAML**

XAML est un langage de programmation descriptif qui vous permet de créer ou d'écrire des classes utilisateur pour des applications, en particulier celles qui utilisent WPF (Windows Presentation Foundation), UWP (Universal Windows Platform) et Xamarin Forms.

XAML, qui est un langage basé sur XML, est la variante de Microsoft pour décrire une interface graphique. Vous utiliserez probablement un concepteur pour travailler sur les fichiers XAML la plupart du temps, mais vous pouvez également écrire et modifier votre interface graphique. 

## **Exportation de présentations vers XAML avec les options par défaut**

Ce code JavaScript vous montre comment exporter une présentation au format XAML avec les paramètres par défaut :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.save(new aspose.slides.XamlOptions());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **Exportation de présentations vers XAML avec des options personnalisées**

Vous pouvez sélectionner des options de la classe [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions) qui contrôlent le processus d'exportation et déterminent comment Aspose.Slides exporte votre présentation au format XAML.

Par exemple, si vous souhaitez qu'Aspose.Slides ajoute les diapositives masquées de votre présentation lors de l'exportation vers XAML, vous pouvez définir la méthode [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/XamlOptions#setExportHiddenSlides-boolean-) sur true. Voir ce code JavaScript d'exemple :
```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    var xamlOptions = new aspose.slides.XamlOptions();
    xamlOptions.setExportHiddenSlides(true);
    pres.save(xamlOptions);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```


## **FAQ**

**Comment garantir des polices prévisibles si la police d'origine n'est pas disponible sur la machine ?**

Utilisez [setDefaultRegularFont](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setDefaultRegularFont) dans [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — il est utilisé comme police de secours lorsque la police d'origine est manquante. Cela permet d'éviter les substitutions inattendues.

**Le XAML exporté est-il destiné uniquement à WPF ou peut-il être utilisé dans d'autres piles XAML également ?**

XAML est un langage de balisage UI général utilisé dans WPF, UWP et Xamarin.Forms. L'exportation cible la compatibilité avec les piles XAML de Microsoft ; le comportement exact et la prise en charge de constructions spécifiques dépendent de la plateforme cible. Testez le balisage dans votre environnement.

**Les diapositives masquées sont-elles prises en charge et comment les empêcher d'être exportées par défaut ?**

Par défaut, les diapositives masquées ne sont pas incluses. Vous pouvez contrôler ce comportement via [setExportHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/setexporthiddenslides/) dans [XamlOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/xamloptions/) — conservez-le désactivé si vous n'avez pas besoin de les exporter.