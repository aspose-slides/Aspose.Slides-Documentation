---
title: Convertir PPT et PPTX en PDF dans .NET [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
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
- enregistrer PowerPoint en PDF
- enregistrer PPT en PDF
- enregistrer PPTX en PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables dans .NET avec Aspose.Slides, grâce à des exemples de code C# rapides et des options de conversion avancées."
---

## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C# offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Utilisant Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour .NET insère ses informations d’API et son numéro de version dans les documents générés. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du type "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

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
* En‑têtes et pieds‑de‑page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

Ce code C# vous montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```c#
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Enregistrez la présentation au format PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```


{{%  alert  color="primary"  %}} 

Aspose propose un **convertisseur PowerPoint vers PDF** en ligne gratuit qui illustre le processus de conversion d’une présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour mettre en œuvre en direct la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller avec un mot de passe ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, préciser la façon dont les métafi­les doivent être traitées, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.
```c#
// Instancier la classe PdfOptions.
var pdfOptions = new PdfOptions
{
    // Définir la qualité des images JPG.
    JpegQuality = 90,

    // Définir le DPI pour les images.
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


### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF généré.

Ce code C# montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives masquées :
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instancier la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Ajouter les diapositives masquées.
pdfOptions.ShowHiddenSlides = true;

// Enregistrer la présentation en PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```


### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code C# démontre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) :
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


### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la propriété [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion de la présentation en PDF.

Ce code C# montre comment détecter les substitutions de polices :
```c#
public static void Main()
{
    // Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument. 
    using var presentation = new Presentation("sample.pptx");

    // Définir le rappel d'avertissement dans les options PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Enregistrer la présentation en PDF.
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


{{%  alert color="primary"  %}} 

Pour plus d’informations sur la réception de rappels d’avertissement lors de la substitution de polices pendant le rendu, consultez [Obtenir des rappels d’avertissement pour la substitution de polices](/slides/fr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consultez l’article [Substitution de polices](/slides/fr/net/font-substitution/).

{{% /alert %}} 

## **Convertir les Diapositives Sélectionnées de PowerPoint en PDF**

Ce code C# montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```c#
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Définir le tableau des numéros de diapositives.
int[] slides = { 1, 3 };

// Enregistrer la présentation au format PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```


## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code C# montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
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


## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

Ce code C# montre comment convertir une présentation PowerPoint en PDF incluant les notes :
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


## **Normes d'Accessibilité et de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Directives d’Accessibilité du Contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint au format PDF en appliquant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C# montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF selon différentes normes de conformité :
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


{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés—[PDF vers SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors de la conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Définissez la propriété `ShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sur `true` pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en définissant des propriétés telles que `JpegQuality` et `SufficientResolution` dans la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides pour .NET](/slides/fr/net/)
- [Référence API Aspose.Slides pour .NET](https://reference.aspose.com/slides/net/)
- [Convertisseurs En Ligne Gratuits Aspose](https://products.aspose.app/slides/conversion)