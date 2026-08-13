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
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et consultables en Java avec Aspose.Slides pour Android, avec des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir les présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF sous Android offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir les présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode `save`. La classe [Présentation](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/presentation/) expose la méthode `save` généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for Android via Java insère les informations de son API ainsi que le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ Producteur PDF avec une valeur du type "*Aspose.Slides v XX.XX*". **Note** : vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Formatage du texte
* Formatage des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard PowerPoint vers PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximal.

Ce code montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.ppt");
try {
    // Enregistrer la présentation au format PDF.
    presentation.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    presentation.dispose();
}
```

{{%  alert  color="info"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) en ligne gratuit qui illustre le processus de conversion d’une présentation en PDF. Vous pouvez tester ce convertisseur pour une mise en œuvre en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées—des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/)—qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec options personnalisées**

À l’aide d’options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les métafi­les doivent être traitées, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.

```java
import com.aspose.slides.*;

// Instancier la classe PdfOptions.
PdfOptions pdfOptions = new PdfOptions();

// Définir la qualité des images JPG.
pdfOptions.setJpegQuality((byte)90);

// Définir le DPI des images.
pdfOptions.setSufficientResolution(300);

/// Définir le comportement des métafichiers.
pdfOptions.setSaveMetafilesAsPng(true);

// Définir le niveau de compression du texte pour le contenu textuel.
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Définir le mode de conformité du PDF.
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Enregistrer la présentation au format PDF.
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/#setShowHiddenSlides-boolean-) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

Ce code montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives masquées :

```java
import com.aspose.slides.*;

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

Ce code montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe à l’aide des paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) :

```java
import com.aspose.slides.*;

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

### **Détecter les substitutions de police**

Aspose.Slides propose la méthode [setWarningCallback](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/saveoptions/#setWarningCallback-com.aspose.slides.IWarningCallback-) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de police pendant le processus de conversion d’une présentation en PDF.

Ce code montre comment détecter les substitutions de police :

```java
import com.aspose.slides.*;

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

{{%  alert color="info"  %}} 

Pour plus d’informations sur la substitution de police, consultez l’article [Substitution de police](/slides/fr/androidjava/font-substitution/).

{{% /alert %}} 

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

Ce code montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :

```java
import com.aspose.slides.*;

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

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

Ce code montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :

```java
import com.aspose.slides.*;

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

    // Supprimer la diapositive vide avec laquelle la nouvelle présentation a été créée.
    resizedPresentation.getSlides().removeAt(1);

    // Enregistrer la présentation redimensionnée au format PDF.
    resizedPresentation.save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
} finally {
    resizedPresentation.dispose();
    presentation.dispose();
}
```

## **Convertir PowerPoint en PDF en affichage des notes de diapositive**

Ce code montre comment convertir une présentation PowerPoint en PDF incluant les notes :

```java
import com.aspose.slides.*;

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
Presentation presentation = new Presentation("SelectedSlides.pptx");
try {
    // Configurer les options PDF avec la mise en page des notes.
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(notesOptions);

    // Enregistrer la présentation au format PDF avec les notes.
    presentation.save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

## **Accessibilité et normes de conformité pour PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une des normes de conformité suivantes : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint‑vers‑PDF qui génère plusieurs PDF selon différentes normes de conformité :

```java
import com.aspose.slides.*;

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

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats populaires. Vous pouvez réaliser des conversions [PDF vers HTML](https://products.aspose.com/slides/fr/java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/fr/java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés—[PDF vers SVG](https://products.aspose.com/slides/fr/java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/fr/java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/fr/java/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}

> **Remarque :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les diagrammes et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

### Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmé.

### Est‑il possible de protéger le PDF converti par un mot de passe ?

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès pendant la conversion.

### Comment inclure les diapositives masquées dans le PDF ?

Utilisez la méthode `setShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

### Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `setJpegQuality` et `setSufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/androidjava/com.aspose.slides/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

### Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides for Android via Java](/slides/fr/androidjava/)
- [Référence API Aspose.Slides for Android via Java](https://reference.aspose.com/slides/fr/androidjava/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/fr/conversion)