---
title: Convertir PPT et PPTX en PDF en C# [Fonctionnalités avancées incluses]
linktitle: Convertir PPT et PPTX en PDF
type: docs
weight: 40
url: /fr/net/convert-powerpoint-to-pdf/
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
- enregistrer PowerPoint au format PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- C#
- Csharp
- .NET
- Aspose.Slides pour .NET
description: "Apprenez comment convertir des présentations PPT, PPTX et ODP en PDF en C# ou .NET à l’aide d’Aspose.Slides. Mettez en œuvre des fonctionnalités avancées telles que la protection par mot de passe, les normes de conformité et les options personnalisées pour des documents PDF de haute qualité et accessibles."
---

## **Aperçu**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C# offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives cachées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l'aide de la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for .NET insère ses informations d'API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d'une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Remarque** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Présentations entières en PDF
* Diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations au format PDF, garantissant que les PDF résultants correspondent étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard de PowerPoint en PDF utilise les options par défaut. Dans ce cas, Aspose.Slides essaie de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximale.

```csharp
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Enregistrer la présentation au format PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

```

{{%  alert  color="primary"  %}} 

Aspose propose un **convertisseur PowerPoint en PDF** gratuit en ligne (https://products.aspose.app/slides/conversion/ppt-to-pdf) qui montre le processus de conversion de présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour voir une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec des Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

```csharp
```c#
// Instancier la classe PdfOptions.
var pdfOptions = new PdfOptions
{
    // Définir la qualité des images JPG.
    JpegQuality = 90,

    // Définir le DPI des images.
    SufficientResolution = 300,

    // Définir le comportement des métafichiers.
    SaveMetafilesAsPng = true,

    // Définir le niveau de compression du texte pour le contenu textuel.
    TextCompression = PdfTextCompression.Flate,

    // Définir le mode de conformité PDF.
    Compliance = PdfCompliance.Pdf15
};

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Enregistrer la présentation en tant que document PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

```

### **Convertir PowerPoint en PDF avec Diapositives Cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour inclure les diapositives cachées comme pages dans le PDF résultant.

```csharp
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instancier la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Ajouter les diapositives cachées.
pdfOptions.ShowHiddenSlides = true;

// Enregistrer la présentation en PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code C# montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) :

```csharp
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instancier la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Définir un mot de passe PDF et les autorisations d'accès.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Enregistrer la présentation en PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la propriété [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) qui vous permet de détecter les substitutions de polices pendant le processus de conversion de présentation en PDF.

```csharp
```c#
public static void Main()
{
    // Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Définir le rappel d'avertissement dans les options PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Enregistrer la présentation au format PDF.
    presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);
}

// Implémentation du rappel d'avertissement.
private class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss &&
            warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur la réception de callbacks pour les substitutions de polices pendant le rendu, consultez [Getting Warning Callbacks for Fonts Substitution](/slides/fr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d'informations sur la substitution de polices, consultez l'article [Font Substitution](/slides/fr/net/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées de PowerPoint en PDF**

Ce code C# montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :

```csharp
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Définir le tableau des numéros de diapositives.
int[] slides = { 1, 3 };

// Enregistrer la présentation au format PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

```

## **Convertir PowerPoint en PDF avec une Taille de Diapositive Personnalisée**

Ce code C# montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :

```csharp
```c#
var slideWidth = 612;
var slideHeight = 792;

// Load a PowerPoint presentation.
using var presentation = new Presentation("SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
using var resizedPresentation = new Presentation();

// Set the custom slide size.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clone the first slide from the original presentation.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf);
```

```

## **Convertir PowerPoint en PDF avec les Notes de Diapositives**

Ce code C# montre comment convertir une présentation PowerPoint en PDF incluant les notes :

```csharp
```c#
// Charger une présentation PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configurer les options PDF avec la disposition des notes.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Enregistrer la présentation en PDF avec notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

```

## **Accessibilité et Normes de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C# montre un processus de conversion PowerPoint‑to‑PDF qui génère plusieurs PDF selon différentes normes de conformité :

```csharp
```c#
using var presentation = new Presentation("pres.pptx");

presentation.Save("pres-a1a-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1a
});

presentation.Save("pres-a1b-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfA1b
});

presentation.Save("pres-ua-compliance.pdf", SaveFormat.Pdf, new PdfOptions
{
    Compliance = PdfCompliance.PdfUa
});
```

```

{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichier populaires. Vous pouvez réaliser les conversions [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), et [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)\— sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis-je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion en lot de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion de manière programmatique.

**Est-il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors du processus de conversion.

**Comment inclure les diapositives cachées dans le PDF ?**

Définissez la propriété `ShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sur `true` pour inclure les diapositives cachées dans le PDF résultant.

**Aspose.Slides peut-il maintenir une haute qualité d'image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en définissant des propriétés telles que `JpegQuality` et `SufficientResolution` dans la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend-il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDFs conformes à différentes normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides pour .NET](/slides/fr/net/)
- [Référence API Aspose.Slides pour .NET](https://reference.aspose.com/slides/net/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)