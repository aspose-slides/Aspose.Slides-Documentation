---
title: Convertir PowerPoint en PDF en Java
linktitle: Convertir PowerPoint en PDF
type: docs
weight: 40
url: /fr/java/convert-powerpoint-to-pdf/
keywords:
- convertir PowerPoint
- présentation
- PowerPoint en PDF
- PPT en PDF
- PPTX en PDF
- enregistrer PowerPoint en tant que PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- Java
- Aspose.Slides pour Java
description: "Convertir des présentations PowerPoint en PDF en Java. Enregistrer PowerPoint en tant que PDF avec conformité ou normes d'accessibilité."
---

## **Aperçu**

La conversion de documents PowerPoint en format PDF offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Cet article vous montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure des diapositives cachées, protéger par mot de passe les documents PDF, détecter les substitutions de police, sélectionner des diapositives pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

À l'aide d'Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* PPT
* PPTX
* ODP

Pour convertir une présentation en PDF, vous devez simplement passer le nom du fichier comme argument dans la classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) et ensuite enregistrer la présentation sous forme de PDF en utilisant une méthode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-). La classe [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) expose la méthode [Save](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation#save-java.lang.String-int-) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour Java écrit directement des informations sur l'API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour Java remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur de forme '*Aspose.Slides v XX.XX*'. **Remarque** que vous ne pouvez pas demander à Aspose.Slides pour Java de changer ou de supprimer ces informations des documents de sortie.

{{% /alert %}}


Aspose.Slides vous permet de convertir :

* une présentation entière en PDF
* des diapositives spécifiques d'une présentation en PDF
* une présentation 

Aspose.Slides exporte des présentations en PDF de manière à ce que le contenu des PDF résultants soit très similaire à celui des présentations originales. Ces éléments et attributs connus sont souvent rendus correctement lors des conversions de présentation en PDF :

* images
* zones de texte et autres formes
* textes et leur formatage
* paragraphes et leur formatage
* hyperliens
* en-têtes et pieds de page
* puces
* tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion de PowerPoint en PDF est exécutée à l'aide des options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximaux.

Ce code Java vous montre comment convertir un PowerPoint en PDF :

```java
// Instancie une classe Presentation qui représente un fichier PowerPoint
Presentation pres = new Presentation("PowerPoint.ppt");
try {
    // Enregistre la présentation en tant que PDF
    pres.save("PPT-to-PDF.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui démontre le processus de conversion de présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez tester le convertisseur.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées—propriétés sous la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)—qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe, ou même de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec des Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les mét fichiers doivent être gérés, définir un niveau de compression pour les textes, définir la résolution DPI pour les images, etc.

L'exemple de code ci-dessous démontre une opération dans laquelle une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :

```java
// Instancie la classe PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Définit la qualité des images JPG
pdfOptions.setJpegQuality((byte)90);

// Définit la résolution DPI pour les images
pdfOptions.setSufficientResolution(300);

// Définit le comportement pour les mét fichiers
pdfOptions.setSaveMetafilesAsPng(true);

// Définit le niveau de compression pour le contenu textuel
pdfOptions.setTextCompression(PdfTextCompression.Flate);

// Définit le mode de conformité PDF
pdfOptions.setCompliance(PdfCompliance.Pdf15);

// Instancie la classe Presentation qui représente un document PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");
try {
    // Enregistre la présentation en tant que document PDF
    presentation.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Convertir PowerPoint en PDF avec Diapositives Cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser une option personnalisée—la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/java/com.aspose.slides/IPdfOptions#getShowHiddenSlides--) de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)—pour demander à Aspose.Slides d'inclure les diapositives cachées comme pages dans le PDF résultant.

Ce code Java vous montre comment convertir une présentation PowerPoint en PDF avec les diapositives cachées incluses :

```java
// Instancie une classe Presentation qui représente un fichier PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancie la classe PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Ajoute des diapositives cachées
    pdfOptions.setShowHiddenSlides(true);
    
    // Enregistre la présentation en tant que PDF
    pres.save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code Java vous montre comment convertir un PowerPoint en PDF protégé par mot de passe (en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/java/com.aspose.slides/PdfOptions)) :

```java
// Instancie un objet Presentation qui représente un fichier PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Instancie la classe PdfOptions
    PdfOptions pdfOptions = new PdfOptions();
    
    // Définit le mot de passe PDF et les autorisations d'accès
    pdfOptions.setPassword("password");
    pdfOptions.setAccessPermissions(PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint);
    
    // Enregistre la présentation en tant que PDF
    pres.save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [getWarningCallback](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#getWarningCallback--) sous la classe [SaveOptions](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/) pour vous permettre de détecter les substitutions de polices dans un processus de conversion de présentation en PDF. 

Ce code Java vous montre comment détecter les substitutions de polices : 

```java
public void main(String[] args)
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.setWarningCallback(warningCallback);

    Presentation pres = new Presentation("pres.pptx", loadOptions);
    try {
        
    } finally {
        if (pres != null) pres.dispose();
    }
}

private class FontSubstSendsWarningCallback implements IWarningCallback
{
    public int warning(IWarningInfo warning)
    {
        if (warning.getWarningType() == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.getWarningType() == WarningType.DataLoss &&
                warning.getDescription().startsWith("Font will be substituted"))
        {
            System.out.println("Avertissement de substitution de police : " + warning.getDescription());
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur la réception de rappels pour les substitutions de polices dans un processus de rendu, consultez [Obtenir des rappels d'avertissement pour les substitutions de polices](https://docs.aspose.com/slides/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d'informations sur la substitution de polices, consultez l'article [Substitution de Polices](https://docs.aspose.com/slides/java/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

Ce code Java vous montre comment convertir des diapositives spécifiques d'une présentation PowerPoint en PDF :

```java
// Instancie un objet Presentation qui représente un fichier PowerPoint
Presentation pres = new Presentation("PowerPoint.pptx");
try {
    // Définit un tableau de positions de diapositives
    int[] slides = { 1, 3 };
    
    // Enregistre la présentation en tant que PDF
    pres.save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code Java vous montre comment convertir un PowerPoint lorsque sa taille de diapositive est spécifiée en PDF :

```java
// Instancie un objet Presentation qui représente un fichier PowerPoint 
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    Presentation outPres = new Presentation();
    try {
        ISlide slide = pres.getSlides().get_Item(0);

        outPres.getSlides().insertClone(0, slide);
        
        // Définit le type et la taille de la diapositive 
        outPres.getSlideSize().setSize(612F, 792F, SlideSizeScaleType.EnsureFit);
        
        PdfOptions pdfOptions = new PdfOptions();
        INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
        options.setNotesPosition(NotesPositions.BottomFull);

        outPres.save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
    } finally {
        if (pres != null) pres.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Convertir PowerPoint en PDF en Vue de Diapositive de Notes**

Ce code Java vous montre comment convertir un PowerPoint en PDF de notes :

```java
// Instancie une classe Presentation qui représente un fichier PowerPoint
Presentation pres = new Presentation("SelectedSlides.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    INotesCommentsLayoutingOptions options = pdfOptions.getNotesCommentsLayouting();
    options.setNotesPosition(NotesPositions.BottomFull);

    pres.save("Pdf_With_Notes.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Normes d'Accessibilité et de Conformité pour les PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion qui respecte les [lignes directrices pour l'accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

Ce code Java démontre une opération de conversion de PowerPoint en PDF dans laquelle plusieurs PDF basés sur différentes normes de conformité sont obtenus :

```java
Presentation pres = new Presentation("pres.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    
    pdfOptions.setCompliance(PdfCompliance.PdfA1a);
    pres.save("pres-a1a-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfA1b);
    pres.save("pres-a1b-compliance.pdf", SaveFormat.Pdf, pdfOptions);

    pdfOptions.setCompliance(PdfCompliance.PdfUa);
    pres.save("pres-ua-compliance.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Note" color="warning" %}} 

Le support d'Aspose.Slides pour les opérations de conversion PDF s'étend à la possibilité de convertir le PDF vers les formats de fichiers les plus populaires. Vous pouvez effectuer des conversions de [PDF en HTML](https://products.aspose.com/slides/java/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/java/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/java/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/java/conversion/pdf-to-png/). D'autres opérations de conversion PDF vers des formats spécialisés—[PDF en SVG](https://products.aspose.com/slides/java/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/java/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/java/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}