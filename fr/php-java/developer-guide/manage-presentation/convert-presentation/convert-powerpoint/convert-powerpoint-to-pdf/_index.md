---
title: Convertir PPT et PPTX en PDF avec PHP [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/php-java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- convertir présentation
- PowerPoint en PDF
- présentation en PDF
- PPT en PDF
- convertir PPT en PDF
- PPTX en PDF
- convertir PPTX en PDF
- enregistrer PowerPoint au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- PHP
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables en PHP avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Aperçu**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) en format PDF avec PHP offre plusieurs avantages, notamment la compatibilité avec différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir les présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) puis enregistrez la présentation au format PDF à l’aide d’une méthode `save`. La classe [Presentation](https://reference.aspose.com/slides/fr/php-java/aspose.slides/Presentation) expose la méthode `save` généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for PHP via Java insère ses informations d’API et son numéro de version dans les documents générés. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du type "*Aspose.Slides v XX.XX*". **Remarque** : vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations complètes en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, garantissant que les PDF résultants correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint → PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximale.

Ce code montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :

```php
# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Enregistrer la présentation au format PDF.
    $presentation->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose propose un **convertisseur PowerPoint en PDF** en ligne gratuit [**PowerPoint to PDF converter**](https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) qui illustre le processus de conversion présentation → PDF. Vous pouvez tester ce convertisseur pour voir une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PdfOptions) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller par mot de passe ou de spécifier le déroulement du processus de conversion.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier la façon dont les métafichiers sont gérés, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.

```php
# Instancier la classe PdfOptions.
$pdfOptions = new PdfOptions();

# Définir la qualité des images JPG.
$pdfOptions->setJpegQuality(90);

# Définir le DPI des images.
$pdfOptions->setSufficientResolution(300);

# Définir le comportement des métafichiers.
$pdfOptions->setSaveMetafilesAsPng(true);

# Définir le niveau de compression du texte pour le contenu textuel.
$pdfOptions->setTextCompression(PdfTextCompression::Flate);

# Définir le mode de conformité PDF.
$pdfOptions->setCompliance(PdfCompliance::Pdf15);

# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Enregistrer la présentation au format PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [setShowHiddenSlides](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/#setShowHiddenSlides) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/PdfOptions) pour inclure les diapositives masquées comme pages dans le PDF résultant.

Ce code montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives masquées :

```php
# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instancier la classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Ajouter les diapositives masquées.
    $pdfOptions->setShowHiddenSlides(true);

    # Enregistrer la présentation au format PDF.
    $presentation->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/) :

```php
# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Instancier la classe PdfOptions.
    $pdfOptions = new PdfOptions();

    # Définir un mot de passe PDF et les autorisations d'accès.
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

    # Enregistrer la présentation au format PDF.
    $presentation->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [setWarningCallback](https://reference.aspose.com/slides/fr/php-java/aspose.slides/saveoptions/#setWarningCallback) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/) qui vous permet de détecter les substitutions de polices pendant le processus de conversion présentation → PDF.

Ce code montre comment détecter les substitutions de polices :

```php
class FontSubstitutionHandler {
    function warning($warning)
    {
        if (java_values($warning->getWarningType()) == WarningType::DataLoss &&
        $warning->getDescription()->startsWith("Font will be substituted")) {
            echo("Font substitution warning: " . $warning->getDescription());
        }

        return ReturnAction::Continue;
    }
}

// Définir le rappel d'avertissement dans les options PDF.
$pdfOptions = new PdfOptions();
$warningCallback = java_closure(new FontSubstitutionHandler(), null, java("com.aspose.slides.IWarningCallback"));
$pdfOptions->setWarningCallback($warningCallback);

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("sample.pptx");
try {
    // Enregistrer la présentation au format PDF.
    $presentation->save("output.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{%  alert color="primary"  %}} 

Pour plus d’informations sur les substitutions de polices, consultez l’article [Font Substitution](/slides/fr/php-java/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées en PDF**

Ce code montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :

```php
# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("PowerPoint.pptx");
try {
    # Définir le tableau des numéros de diapositives.
    $slides = array(1, 3);

    # Enregistrer la présentation au format PDF.
    $presentation->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
} finally {
    $presentation->dispose();
}
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :

```php
$slideWidth = 612.0;
$slideHeight = 792.0;

# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");

# Créer une nouvelle présentation avec une taille de diapositive ajustée.
$resizedPresentation = new Presentation();

try {
    # Définir la taille de diapositive personnalisée.
    $resizedPresentation->getSlideSize()->setSize($slideWidth, $slideHeight, SlideSizeScaleType::EnsureFit);

    # Cloner la première diapositive de la présentation originale.
    $slide = $presentation->getSlides()->get_Item(0);
    $resizedPresentation->getSlides()->insertClone(0, $slide);

    # Enregistrer la présentation redimensionnée au format PDF avec notes.
    $resizedPresentation->save("PDFnotes_out.pdf", SaveFormat::Pdf);
} finally {
    $resizedPresentation->dispose();
    $presentation->dispose();
}
```

## **Convertir PowerPoint en PDF en Vue Notes de Diapositive**

Ce code montre comment convertir une présentation PowerPoint en PDF incluant les notes :

```php
# Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
$presentation = new Presentation("SelectedSlides.pptx");
try {
    # Configurer les options PDF avec la mise en page des notes.
    $notesOptions = new NotesCommentsLayoutingOptions();
    $notesOptions->setNotesPosition(NotesPositions::BottomFull);
    $pdfOptions = new PdfOptions();
    $pdfOptions->setSlidesLayoutOptions($notesOptions);

    # Enregistrer la présentation au format PDF avec notes.
    $presentation->save("PDF_with_notes.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

## **Accessibilité et Normes de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une des normes de conformité suivantes : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code montre un processus de conversion PowerPoint → PDF qui génère plusieurs PDF selon différentes normes de conformité :

```php
$presentation = new Presentation("pres.pptx");
try {
    $pdfOptions = new PdfOptions();

    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $presentation->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $presentation->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);

    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $presentation->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
} finally {
    $presentation->dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats courants. Vous pouvez effectuer les conversions [PDF vers HTML](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/fr/php-java/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

> **Remarque :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, diagrammes et formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenus séparés et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lot de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmétiquement.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/) pour définir un mot de passe et définir les autorisations d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `setShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/) pour inclure les diapositives masquées dans le PDF généré.

**Aspose.Slides peut‑il conserver une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `setJpegQuality` et `setSufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/php-java/aspose.slides/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents respectent les exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides for PHP via Java](/slides/fr/php-java/)
- [Référence API Aspose.Slides for PHP via Java](https://reference.aspose.com/slides/fr/php-java/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/fr/conversion)