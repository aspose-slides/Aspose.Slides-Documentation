---
title: Convertir PowerPoint en PDF
linktitle: Convertir PowerPoint en PDF
type: docs
weight: 40
url: /fr/php-java/convert-powerpoint-to-pdf/
keywords: "Convertir PowerPoint, Présentation, PowerPoint en PDF, PPT en PDF, PPTX en PDF, Enregistrer PowerPoint en PDF, PDF/A1a, PDF/A1b, PDF/UA, Java"
description: "Convertir la présentation PowerPoint en PDF. Enregistrer PowerPoint en PDF avec conformité ou normes d'accessibilité"

---
## **Vue d'ensemble**

Cet article explique comment vous pouvez convertir des formats de fichiers PowerPoint en PDF en utilisant PHP. Il couvre un large éventail de sujets, par exemple :

- Convertir PPT en PDF
- Convertir PPTX en PDF
- Convertir ODP en PDF
- Convertir PowerPoint en PDF

## **Conversions Java PowerPoint en PDF**

En utilisant Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* PPT
* PPTX
* ODP

Pour convertir une présentation en PDF, il vous suffit de passer le nom du fichier comme argument dans la classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) et ensuite d'enregistrer la présentation en tant que PDF en utilisant une méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-). La classe [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation) expose la méthode [Save](https://reference.aspose.com/slides/php-java/aspose.slides/Presentation#save-java.lang.String-int-) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour PHP via Java écrit directement des informations API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour PHP via Java remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Notez** que vous ne pouvez pas demander à Aspose.Slides pour PHP via Java de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}


Aspose.Slides vous permet de convertir :

* une présentation entière en PDF
* des diapositives spécifiques d'une présentation en PDF
* une présentation 

Aspose.Slides exporte des présentations en PDF de manière à ce que le contenu des PDF résultants soit très similaire à celui des présentations originales. Ces éléments et attributs connus sont souvent rendus correctement lors des conversions de présentation en PDF :

* images
* zones de texte et autres formes
* textes et leur mise en forme
* paragraphes et leur mise en forme
* hyperliens
* en-têtes et pieds de page
* puces
* tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion PowerPoint en PDF est exécutée en utilisant des options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximum.

Ce code PHP vous montre comment convertir un PowerPoint en PDF :

```php
  # Instancie une classe Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("PowerPoint.ppt");
  try {
    # Enregistre la présentation en tant que PDF
    $pres->save("PPT-to-PDF.pdf", SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert  color="primary"  %}} 

Aspose fournit un [**convertisseur PowerPoint en PDF en ligne gratuit**](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui démontre le processus de conversion de présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez faire un test avec le convertisseur.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées—propriétés sous la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)—qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe, ou même de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images JPG, spécifier comment les mét fichiers doivent être traités, définir un niveau de compression pour les textes, etc.

Ce code PHP démontre une opération dans laquelle un PowerPoint est converti en PDF avec plusieurs options personnalisées :

```php
// Instancie une classe Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instancie la classe PdfOptions
    $pdfOptions = new PdfOptions();
    # Définit la qualité Jpeg
    $pdfOptions->setJpegQuality(90);
    # Définit le comportement pour les mét fichiers
    $pdfOptions->setSaveMetafilesAsPng(true);
    # Définit le niveau de compression pour les textes
    $pdfOptions->setTextCompression(PdfTextCompression::Flate);
    # Définit la norme PDF
    $pdfOptions->setCompliance(PdfCompliance::Pdf15);
    # Enregistre la présentation en tant que PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convertir PowerPoint en PDF avec Diapositives Cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser une option personnalisée—la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/php-java/aspose.slides/IPdfOptions#getShowHiddenSlides--) de la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)—pour demander à Aspose.Slides d'inclure les diapositives cachées comme pages dans le PDF résultant.

Ce code PHP vous montre comment convertir une présentation PowerPoint en PDF avec des diapositives cachées incluses :

```php
// Instancie une classe Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Instancie la classe PdfOptions
    $pdfOptions = new PdfOptions();
    # Ajoute des diapositives cachées
    $pdfOptions->setShowHiddenSlides(true);
    # Enregistre la présentation en tant que PDF
    $pres->save("PowerPoint-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code PHP vous montre comment convertir un PowerPoint en un PDF protégé par mot de passe (en utilisant des paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/php-java/aspose.slides/PdfOptions)) :

```php
// Instancie un objet Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # / Instancie la classe PdfOptions
    $pdfOptions = new PdfOptions();
    # Définit le mot de passe PDF et les permissions d'accès
    $pdfOptions->setPassword("password");
    $pdfOptions->setAccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);
    # Enregistre la présentation en tant que PDF
    $pres->save("PPTX-to-PDF.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### Détecter les Substitutions de Police**

Aspose.Slides fournit la méthode [getWarningCallback](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/#getWarningCallback--) sous la classe [SaveOptions](https://reference.aspose.com/slides/php-java/aspose.slides/saveoptions/) pour vous permettre de détecter les substitutions de police dans un processus de conversion de présentation en PDF.

Ce code PHP vous montre comment détecter les substitutions de police :

```php

class FontSubstSendsWarningCallback {
    function warning($warning)
    {
          if (java_values($warning->getWarningType() == WarningType::CompatibilityIssue)) {
            return ReturnAction::Continue;
          }
          if (java_values($warning->getWarningType() == WarningType::DataLoss && $warning->getDescription()->startsWith("Font will be substituted"))) {
            echo ("Avertissement de substitution de police : " . $warning->getDescription());
          }
          return ReturnAction::Continue;
    }
}

  $loadOptions = new LoadOptions();
  $warningCallback = java_closure(new FontSubstSendsWarningCallback(), null, java("com.aspose.slides.IWarningCallback"));
  $loadOptions->setWarningCallback($warningCallback);
  $pres = new Presentation("pres.pptx", $loadOptions);
  try {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur l'obtention de rappels pour les substitutions de police dans un processus de rendu, voir [Obtenir des rappels d'avertissement pour les substitutions de police](https://docs.aspose.com/slides/php-java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d'informations sur la substitution de police, voir l'article [Substitution de Police](https://docs.aspose.com/slides/php-java/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées dans PowerPoint en PDF**

Ce code PHP vous montre comment convertir des diapositives spécifiques d'une présentation PowerPoint en PDF :

```php
// Instancie un objet Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("PowerPoint.pptx");
  try {
    # Définit un tableau de positions de diapositives
    $slides = array(1, 3 );
    # Enregistre la présentation en tant que PDF
    $pres->save("PPTX-to-PDF.pdf", $slides, SaveFormat::Pdf);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code PHP vous montre comment convertir un PowerPoint lorsque sa taille de diapositive est spécifiée en PDF :

```php
// Instancie un objet Presentation qui représente un fichier PowerPoint 
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $outPres = new Presentation();
    try {
      $slide = $pres->getSlides()->get_Item(0);
      $outPres->getSlides()->insertClone(0, $slide);
      # Définit le type et la taille de la diapositive
      $outPres->getSlideSize()->setSize(612.0, 792.0, SlideSizeScaleType::EnsureFit);
      $pdfOptions = new PdfOptions();
      $options = $pdfOptions->getNotesCommentsLayouting();
      $options->setNotesPosition(NotesPositions::BottomFull);
      $outPres->save("PDFnotes_out.pdf", SaveFormat::Pdf, $pdfOptions);
    } finally {
      if (!java_is_null($pres)) {
        $pres->dispose();
      }
    }
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Convertir PowerPoint en PDF en Mode Diapositive de Notes**

Ce code PHP vous montre comment convertir un PowerPoint en PDF avec des notes :

```php
// Instancie une classe Presentation qui représente un fichier PowerPoint
  $pres = new Presentation("SelectedSlides.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $options = $pdfOptions->getNotesCommentsLayouting();
    $options->setNotesPosition(NotesPositions::BottomFull);
    $pres->save("Pdf_With_Notes.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Normes d'Accessibilité et de Conformité pour PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion qui respecte les [Directives d'Accessibilité du Contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

Ce code PHP démontre une opération de conversion PowerPoint en PDF dans laquelle plusieurs PDF basés sur différentes normes de conformité sont obtenus :

```php
  $pres = new Presentation("pres.pptx");
  try {
    $pdfOptions = new PdfOptions();
    $pdfOptions->setCompliance(PdfCompliance::PdfA1a);
    $pres->save("pres-a1a-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfA1b);
    $pres->save("pres-a1b-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
    $pdfOptions->setCompliance(PdfCompliance::PdfUa);
    $pres->save("pres-ua-compliance.pdf", SaveFormat::Pdf, $pdfOptions);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{% alert title="Note" color="warning" %}} 

Le support d'Aspose.Slides pour les opérations de conversion PDF s'étend à vous permettre de convertir PDF dans les formats de fichiers les plus populaires. Vous pouvez faire des conversions [PDF en HTML](https://products.aspose.com/slides/php-java/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/php-java/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/php-java/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/php-java/conversion/pdf-to-png/). D'autres opérations de conversion PDF dans des formats spécialisés—[PDF en SVG](https://products.aspose.com/slides/php-java/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/php-java/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/php-java/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}