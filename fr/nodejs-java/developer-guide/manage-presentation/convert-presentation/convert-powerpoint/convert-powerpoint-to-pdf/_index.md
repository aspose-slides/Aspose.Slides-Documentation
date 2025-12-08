---
title: Convertir PPT et PPTX en PDF en JavaScript [Fonctionnalités avancées incluses]
linktitle: Convertir PPT et PPTX en PDF
type: docs
weight: 40
url: /fr/nodejs-java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- convertir PPT en PDF
- PPTX en PDF
- convertir PPTX en PDF
- ODP en PDF
- convertir ODP en PDF
- enregistrer PowerPoint en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- JavaScript
- Node.js
- Aspose.Slides for Node.js via Java
description: "Apprenez à convertir les présentations PPT, PPTX et ODP en PDF en JavaScript à l'aide d'Aspose.Slides. Implémentez des fonctionnalités avancées telles que la protection par mot de passe, les normes de conformité et des options personnalisées pour des documents PDF de haute qualité et accessibles."
---

## **Vue d'ensemble**

La conversion de présentations PowerPoint et OpenDocument (PPT, PPTX, ODP, etc.) en format PDF avec JavaScript offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode `save`. La classe [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) expose la méthode `save` qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Node.js via Java insère ses informations d’API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, garantissant que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximal.

Ce code montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```js
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.ppt");
try {
    // Enregistrez la présentation au format PDF.
    presentation.save("PPT-to-PDF.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose propose un convertisseur en ligne gratuit [**PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui illustre le processus de conversion présentation‑vers‑PDF. Vous pouvez effectuer un test avec ce convertisseur pour une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/pdfoptions/) — qui permettent de personnaliser le PDF résultant, de le verrouiller avec un mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier la manière dont les métafichiers doivent être gérés, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.
```js
// Instanciez la classe PdfOptions.
let pdfOptions = new aspose.slides.PdfOptions();

// Définissez la qualité des images JPG.
pdfOptions.setJpegQuality(java.newByte(90));

// Définissez le DPI des images.
pdfOptions.setSufficientResolution(300);

// Définissez le comportement des métafichiers.
pdfOptions.setSaveMetafilesAsPng(true);

// Définissez le niveau de compression du texte pour le contenu textuel.
pdfOptions.setTextCompression(aspose.slides.PdfTextCompression.Flate);

// Définissez le mode de conformité PDF.
pdfOptions.setCompliance(aspose.slides.PdfCompliance.Pdf15);

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument file.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Enregistrez la présentation en tant que document PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) pour inclure les diapositives masquées comme pages dans le PDF résultant.

Ce code JavaScript montre comment convertir une présentation PowerPoint en PDF avec les diapositives masquées incluses :
```js
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciez la classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Ajoutez les diapositives masquées.
    pdfOptions.setShowHiddenSlides(true);

    // Enregistrez la présentation au format PDF.
    presentation.save("PowerPoint-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint en PDF protégé par Mot de Passe**

Ce code JavaScript montre comment convertir une présentation PowerPoint en PDF protégé par un mot de passe à l’aide des paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) :
```js
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Instanciez la classe PdfOptions.
    let pdfOptions = new aspose.slides.PdfOptions();

    // Définissez un mot de passe PDF et les permissions d'accès.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(aspose.slides.PdfAccessPermissions.PrintDocument | aspose.slides.PdfAccessPermissions.HighQualityPrint);

    // Enregistrez la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/nodejs-java/aspose.slides/saveoptions/#setWarningCallback) de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions), vous permettant de détecter les substitutions de polices pendant le processus de conversion présentation‑vers‑PDF.

Ce code JavaScript montre comment détecter les substitutions de polices :
```js
// Définir le rappel d'avertissement dans les options PDF.
let pdfOptions = new aspose.slides.PdfOptions();
pdfOptions.setWarningCallback(FontSubstitutionHandler);

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("sample.pptx");

// Enregistrer la présentation au format PDF.
presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
presentation.dispose();
```

```js
const FontSubstitutionHandler = java.newProxy("com.aspose.slides.IWarningCallback", {
	warning: function (warning) {
		if (warning.getWarningType() === aspose.slides.WarningType.DataLoss) {
			console.warn("Font substitution warning: " + warning.getDescription());
		}
		return aspose.slides.ReturnAction.Continue;
	}
});
```


{{%  alert color="primary"  %}} 

Pour plus d’informations sur la réception de callbacks de substitution de polices pendant le rendu, voir [Receiving Warning Callbacks for Fonts Substitution](/slides/fr/nodejs-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consultez l’article [Font Substitution](/slides/fr/nodejs-java/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositives Sélectionnées en PDF**

Ce code JavaScript montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```js
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("PowerPoint.pptx");
try {
    // Définissez le tableau des numéros de diapositives.
    let slides = java.newArray("int", [1, 3]);

    // Enregistrez la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, aspose.slides.SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code JavaScript montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
```js
const slideWidth = 612;
const slideHeight = 792;

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
let resizedPresentation = new aspose.slides.Presentation();

try {
    // Définissez la taille de diapositive personnalisée.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, aspose.slides.SlideSizeScaleType.EnsureFit);

    // Clonez la première diapositive de la présentation d'origine.
    let slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Enregistrez la présentation redimensionnée en PDF avec les notes.
    resizedPresentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

Ce code JavaScript montre comment convertir une présentation PowerPoint en PDF incluant les notes :
```js
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
let presentation = new aspose.slides.Presentation("SelectedSlides.pptx");
try {
    // Configurez les options PDF avec la disposition des notes.
    let notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomFull);
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrez la présentation au format PDF avec les notes.
    presentation.save("PDF_with_notes.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Accessibilité et Normes de Conformité pour PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code JavaScript montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF selon différentes normes de conformité :
```js
let presentation = new aspose.slides.Presentation("pres.pptx");
try {
    let pdfOptions = new aspose.slides.PdfOptions();
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
    pdfOptions.setCompliance(aspose.slides.PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", aspose.slides.SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats populaires. Vous pouvez réaliser des conversions [PDF vers HTML](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-html/), [PDF vers JPG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-jpg/) et [PDF vers PNG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/nodejs-java/conversion/pdf-to-tiff/) — sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez itérer sur vos fichiers et appliquer le processus de conversion par programme.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) pour définir un mot de passe et spécifier les autorisations d’accès pendant la conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `setShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `setJpegQuality` et `setSufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PdfOptions) pour garantir des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents respectent les exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides for Node.js via Java](/slides/fr/nodejs-java/)
- [Référence API Aspose.Slides for Node.js via Java](https://reference.aspose.com/slides/nodejs-java/)
- [Convertisseurs En Ligne Gratuits Aspose](https://products.aspose.app/slides/conversion)