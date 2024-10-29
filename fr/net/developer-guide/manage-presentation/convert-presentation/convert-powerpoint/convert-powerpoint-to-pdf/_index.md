---
title: Convertir PowerPoint en PDF en C#
linktitle: Convertir PowerPoint en PDF
type: docs
weight: 40
url: /fr/net/convert-powerpoint-to-pdf/
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
- C#
- Csharp
- .NET
- Aspose.Slides pour .NET
description: "Convertir des présentations PowerPoint en PDF en C# ou .NET. Enregistrez PowerPoint en tant que PDF avec conformité ou normes d'accessibilité."
---

## **Aperçu**

La conversion de documents PowerPoint en format PDF offre plusieurs avantages, notamment la garantie de compatibilité entre différents appareils et la préservation de la mise en page et du format de votre présentation. Cet article vous montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité de l'image, inclure des diapositives cachées, protéger par mot de passe des documents PDF, détecter les substitutions de polices, sélectionner des diapositives pour la conversion et appliquer les normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

À l'aide d'Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* PPT
* PPTX
* ODP

Pour convertir une présentation en PDF, il vous suffit de passer le nom du fichier en argument dans la classe [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) puis de sauvegarder la présentation en tant que PDF à l'aide d'une méthode [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La classe [`Presentation`](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expose la méthode [`Save`](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/#presentationsave-method-5-of-9) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="REMARQUE"  color="warning"   %}} 

Aspose.Slides pour .NET écrit directement les informations API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour .NET remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Notez** que vous ne pouvez pas demander à Aspose.Slides pour .NET de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* une présentation entière en PDF
* des diapositives spécifiques d'une présentation en PDF
* une présentation 

Aspose.Slides exporte des présentations en PDF d'une manière qui rend le contenu des PDFs résultants très similaire à celui des présentations originales. Ces éléments et attributs connus sont souvent rendus correctement lors des conversions de présentation en PDF :

* images
* zones de texte et autres formes
* textes et leur formatage
* paragraphes et leur formatage
* hyperliens
* en-têtes et pieds de page
* puces
* tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion PowerPoint en PDF est exécutée en utilisant les options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximum.

Ce code C# vous montre comment convertir un PowerPoint (PPT, PPTX, ODP) en PDF :

```c#
// Instancie une classe Presentation qui représente un fichier PowerPoint, cela pourrait être PPT, PPTX, ODP etc.
Presentation presentation = new Presentation("PowerPoint.ppt");

// Sauvegarde la présentation en tant que PDF
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF en ligne gratuit**](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui démontre le processus de conversion de présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez faire un test avec le convertisseur.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides propose des options personnalisées—propriétés sous la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe ou même de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les mét fichiers doivent être traités, définir un niveau de compression pour les textes, définir une résolution DPI pour les images, etc.

L'exemple de code ci-dessous démontre une opération dans laquelle une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :

```c#
// Instancie la classe PdfOptions
PdfOptions pdfOptions = new PdfOptions
{
    // Définit la qualité pour les images JPG
    JpegQuality = 90,

    // Définit DPI pour les images
    SufficientResolution = 300,

    // Définit le comportement pour les mét fichiers
    SaveMetafilesAsPng = true,

    // Définit le niveau de compression pour le contenu textuel
    TextCompression = PdfTextCompression.Flate,

    // Définit le mode de conformité PDF
    Compliance = PdfCompliance.Pdf15
};

// Instancie la classe Presentation qui représente un document PowerPoint
using (Presentation presentation = new Presentation("PowerPoint.pptx"))
{
    // Sauvegarde la présentation en tant que document PDF
    presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
}
```

### **Convertir PowerPoint en PDF avec Diapositives Cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser une option personnalisée—la propriété [`ShowHiddenSlides`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)—pour indiquer à Aspose.Slides d'inclure les diapositives cachées comme pages dans le PDF résultant.

Ce code C# vous montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives cachées :

```c#
// Instancie une classe Presentation qui représente un fichier PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Instancie la classe PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Ajoute les diapositives cachées
pdfOptions.ShowHiddenSlides = true;

// Sauvegarde la présentation en tant que PDF
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code C# vous montre comment convertir un PowerPoint en un PDF protégé par mot de passe (en utilisant les paramètres de protection de la classe [`PdfOptions`](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/)) :

```c#
// Instancie un objet Presentation qui représente un fichier PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

/// Instancie la classe PdfOptions
PdfOptions pdfOptions = new PdfOptions();

// Définit le mot de passe PDF et les autorisations d'accès
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Sauvegarde la présentation en tant que PDF
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la propriété [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) sous la classe [SaveOptions](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/) pour vous permettre de détecter les substitutions de polices dans un processus de conversion de présentation en PDF. 

Ce code C# vous montre comment détecter les substitutions de polices : xxx 

```c#
public static void Main()
{
    LoadOptions loadOptions = new LoadOptions();
    FontSubstSendsWarningCallback warningCallback = new FontSubstSendsWarningCallback();
    loadOptions.WarningCallback = warningCallback;

    using (Presentation pres = new Presentation("pres.pptx", loadOptions))
    {
    }
}

private class FontSubstSendsWarningCallback : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.CompatibilityIssue)
            return ReturnAction.Continue;

        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Avertir sur la substitution de police: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur l'obtention de rappels pour les substitutions de polices dans un processus de rendu, consultez [Obtenir des rappels d'avertissement pour les substitutions de polices](https://docs.aspose.com/slides/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d'informations sur la substitution de polices, consultez l'article [Substitution de polices](https://docs.aspose.com/slides/net/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées dans PowerPoint en PDF**

Ce code C# vous montre comment convertir des diapositives spécifiques d'une présentation PowerPoint en PDF :

```c#
// Instancie un objet Presentation qui représente un fichier PowerPoint
Presentation presentation = new Presentation("PowerPoint.pptx");

// Définit un tableau de positions de diapositives
int[] slides = { 1, 3 };

// Sauvegarde la présentation en tant que PDF
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code C# vous montre comment convertir un PowerPoint lorsque sa taille de diapositive est spécifiée en PDF :

```c#
// Instancie un objet Presentation qui représente un fichier PowerPoint 
Presentation presentation = new Presentation("SelectedSlides.pptx");
Presentation auxPresentation = new Presentation();

ISlide slide = presentation.Slides[0];
auxPresentation.Slides.InsertClone(0, slide);

// Définit le type et la taille de la diapositive 
// auxPresentation.SlideSize.SetSize(presentation.SlideSize.Size.Width, presentation.SlideSize.Size.Height,SlideSizeScaleType.EnsureFit);
auxPresentation.SlideSize.SetSize(612F, 792F,SlideSizeScaleType.EnsureFit);

PdfOptions pdfOptions = new PdfOptions();
INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
options.NotesPosition = NotesPositions.BottomFull;

auxPresentation.Save("PDFnotes_out.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Convertir PowerPoint en PDF en Vue des Notes**

Ce code C# vous montre comment convertir un PowerPoint en PDF notes :

```c#
// Instancie une classe Presentation qui représente un fichier PowerPoint
using (Presentation presentation = new Presentation("NotesFile.pptx"))
{
	PdfOptions pdfOptions = new PdfOptions();
	INotesCommentsLayoutingOptions options = pdfOptions.NotesCommentsLayouting;
	options.NotesPosition = NotesPositions.BottomFull;

	// Sauvegarde la présentation en tant que PDF notes
	presentation.Save("Pdf_Notes_out.tiff", SaveFormat.Pdf, pdfOptions);
}
```

## **Normes d'Accessibilité et de Conformité pour le PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion qui respecte les [Directives d'accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

Ce code C# démontre une opération de conversion PowerPoint en PDF dans laquelle plusieurs PDFs basés sur différentes normes de conformité sont obtenus :

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    pres.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1a
    });
   
    pres.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
    {
        Compliance = PdfCompliance.PdfA1b
    });
   
    pres.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions()
   {
        Compliance = PdfCompliance.PdfUa
    });
}
```

{{% alert title="Note" color="warning" %}} 

Le support d'Aspose.Slides pour les opérations de conversion PDF s'étend à permettre de convertir le PDF dans les formats de fichiers les plus populaires. Vous pouvez faire des conversions [PDF en HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). D'autres opérations de conversion PDF vers des formats spécialisés—[PDF en SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}