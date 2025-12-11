---
title: Convertir PPT et PPTX en PDF sur Android [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/androidjava/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- convertir PPT en PDF
- PPTX en PDF
- convertir PPTX en PDF
- enregistrer PowerPoint en PDF
- enregistrer PPT en PDF
- enregistrer PPTX en PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Android
- Java
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et recherchables en Java avec Aspose.Slides pour Android, avec des exemples de code rapides et des options de conversion avancées."
---

## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) en PDF sous Android offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Présentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide d’une méthode `save`. La classe [Présentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) expose la méthode `save` qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java insère ses informations d’API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du format "*Aspose.Slides v XX.XX*". **Remarque** : vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, en veillant à ce que les PDF obtenus correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Formatage du texte
* Formatage des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant les réglages optimaux au niveau de qualité maximal.

Ce code montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Enregistrer la présentation au format PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


{{%  alert  color="primary"  %}} 

Aspose propose un convertisseur en ligne gratuit [**PowerPoint vers PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui démontre le processus de conversion présentation‑vers‑PDF. Vous pouvez tester ce convertisseur pour une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller avec un mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la façon dont les métafichiers doivent être gérés, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.
```java
// Instancier la classe PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Définir la qualité des images JPG.
pdfOptions.setJpegQuality((byte)90);

// Définir le DPI pour les images.
pdfOptions.setSufficientResolution(300);

/// Définir le comportement pour les métafichiers.
pdfOptions.setSaveMetafilesAsPng(true);

// Définir le niveau de compression du texte pour le contenu textuel.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Définir le mode de conformité PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Enregistrer la présentation en tant que document PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

Ce code montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives masquées :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instancier la classe PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Ajouter les diapositives masquées.
    pdfOptions.setShowHiddenSlides(true);

    // Enregistrer la présentation au format PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe à l’aide des paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instancier la classe PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Définir un mot de passe PDF et les autorisations d’accès.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Enregistrer la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de polices pendant le processus de conversion présentation‑vers‑PDF.

Ce code montre comment détecter les substitutions de polices :
```java
public static void main(String[] args) {
    // Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Définir le rappel d'avertissement dans les options PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    // Enregistrer la présentation au format PDF.
    presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implémentation du rappel d'avertissement.
private static class FontSubstitutionHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted")) {
            System.out.println("Font substitution warning: " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```


{{%  alert color="primary"  %}} 

Pour plus d’informations sur la réception des callbacks de substitution de polices pendant le rendu, consultez [Obtention de Callbacks d’Avertissement pour les Substitutions de Polices](/slides/fr/androidjava/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consultez l’article [Substitution de Polices](/slides/fr/androidjava/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

Ce code montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Définir le tableau des numéros de diapositives.
    int[] slides = { 1, 3 };

    // Enregistrer la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```


## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
```java
float slideWidth = 612;
float slideHeight = 792;

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");

// Créer une nouvelle présentation avec une taille de diapositive ajustée.
Presentation resizedPresentation = new Presentation();

try {
    // Définir la taille de diapositive personnalisée.
    resizedPresentation.getSlideSize().setSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

    // Cloner la première diapositive de la présentation d'origine.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Enregistrer la présentation redimensionnée en PDF avec les notes.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```


## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

Ce code montre comment convertir une présentation PowerPoint en PDF incluant les notes :
```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configurer les options PDF avec la mise en page des notes.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation en PDF avec les notes.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


## **Accessibilité et Normes de Conformité pour les PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Directives d’Accessibilité du Contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF selon différentes normes de conformité :
```java
Presentation presentation = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();

    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    presentation.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    presentation.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    presentation.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats populaires. Vous pouvez effectuer les conversions [PDF vers HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion de façon programmatique.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les permissions d’accès lors de la conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `setShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `setJpegQuality` et `setSufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents respectent les exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides for Android via Java](/slides/fr/androidjava/)
- [Référence API Aspose.Slides for Android via Java](https://reference.aspose.com/slides/androidjava/)
- [Convertisseurs En Ligne Gratuits Aspose](https://products.aspose.app/slides/conversion)