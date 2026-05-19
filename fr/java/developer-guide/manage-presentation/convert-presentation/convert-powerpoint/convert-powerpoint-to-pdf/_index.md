---
title: Convertir PPT et PPTX en PDF avec Java [Fonctionnalités avancées incluses]
linktitle: PowerPoint vers PDF
type: docs
weight: 40
url: /fr/java/convert-powerpoint-to-pdf/
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
- Java
- Aspose.Slides
description: Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables en Java avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées.
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) en format PDF en Java offre plusieurs avantages, notamment la compatibilité sur différents appareils et la conservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir les présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide d’une méthode `save`. La classe [Presentation](https://reference.aspose.com/slides/fr/java/com.aspose.slides/presentation/) expose la méthode `save` qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Java insère ses informations d’API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Remarque** : vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximal.

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

Aspose propose un [**convertisseur PowerPoint vers PDF**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) en ligne gratuit qui démontre le processus de conversion de présentation en PDF. Vous pouvez tester ce convertisseur pour une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides propose des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.

```java
// Instancier la classe PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Définir la qualité des images JPG.
pdfOptions.setJpegQuality((byte)90);

// Définir le DPI des images.
pdfOptions.setSufficientResolution(300);

// Définir le comportement des métafichiers.
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

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

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

### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe à l’aide des paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) :

```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Instancier la classe PdfOptions.
    PdfOptions pdfOptions = new PdfOptions();

    // Définir un mot de passe PDF et les autorisations d'accès.
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);

    // Enregistrer la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Détecter les substitutions de polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/fr/java/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de polices pendant le processus de conversion de la présentation en PDF.

Ce code montre comment détecter les substitutions de polices :

```java
public static void main(String[] args) {
    // Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
    Presentation presentation = new Presentation("sample.pptx");

    // Définir le rappel d'avertissement dans les options PDF.
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setWarningCallback(new FontSubstitutionHandler());

    try {
        // Enregistrer la présentation au format PDF.
        presentation.save("output.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        presentation.dispose();
    }
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

Pour plus d’informations sur la réception d’appels de rappel pour les substitutions de polices pendant le rendu, consultez [Getting Warning Callbacks for Fonts Substitution](/slides/fr/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur les substitutions de polices, consultez l’article [Font Substitution](/slides/fr/java/font-substitution/).

{{% /alert %}} 

## **Convertir des diapositives sélectionnées en PDF**

Ce code montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :

```java
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Définir le tableau de numéros de diapositives.
    int[] slides = { 1, 3 };

    // Enregistrer la présentation au format PDF.
    presentation.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

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
    
    // Cloner la première diapositive de la présentation originale.
    ISlide slide = presentation.getSlides().get_Item(0);
    resizedPresentation.getSlides().insertClone(0, slide);

    // Enregistrer la présentation redimensionnée au format PDF avec notes.
    resizedPresentation.save("PDF_with_notes.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint en PDF en mode notes de diapositive**

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

    // Enregistrer la présentation au format PDF avec notes.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibilité et normes de conformité pour PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en vous basant sur l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

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

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats courants. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/fr/java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/fr/java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-jpg/) et [PDF vers PNG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/fr/java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/fr/java/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

> **Remarque :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) pour définir un mot de passe et préciser les autorisations d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `setShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `setJpegQuality` et `setSufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à [diverses normes](https://reference.aspose.com/slides/fr/java/com.aspose.slides/pdfcompliance/), notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides for Java](/slides/fr/java/)
- [Référence API Aspose.Slides for Java](https://reference.aspose.com/slides/fr/java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/fr/conversion)