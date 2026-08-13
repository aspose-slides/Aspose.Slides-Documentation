---
title: Convertir PPT et PPTX en PDF avec .NET [Fonctionnalités avancées incluses]
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
- enregistrer PowerPoint au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Convertir des présentations PowerPoint PPT/PPTX en PDF de haute qualité et consultables dans .NET avec Aspose.Slides, en utilisant des exemples de code C# rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) en format PDF en C# offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents générés.

## **Conversions PowerPoint vers PDF**

En utilisant Aspose.Slides, vous pouvez convertir des présentations des formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) class puis enregistrez la présentation au format PDF à l’aide d’une méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/fr/net/aspose.slides/presentation/save/) généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 
Aspose.Slides pour .NET insère ses informations d’API et le numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec « *Aspose.Slides* » et le champ PDF Producer avec une valeur du format « *Aspose.Slides v XX.XX* ». **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :
* L’ensemble des présentations en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations en PDF, garantissant que les PDF résultants correspondent étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :
* Images
* Zones de texte et formes
* Formatage du texte
* Formatage des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard de PowerPoint en PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximal.

Ce code C# montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.ppt");

// Enregistrez la présentation au format PDF.
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{%  alert  color="info"  %}} 
Aspose propose un **convertisseur PowerPoint en PDF**(https://products.aspose.app/slides/fr/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion de présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une implémentation en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe, ou de spécifier la manière dont le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier la manière dont les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI pour les images, etc.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe PdfOptions.
var pdfOptions = new PdfOptions
{
    // Définissez la qualité pour les images JPG.
    JpegQuality = 90,

    // Définissez le DPI pour les images.
    SufficientResolution = 300,

    // Définissez le comportement pour les métafichiers.
    SaveMetafilesAsPng = true,

    // Définissez le niveau de compression du texte pour le contenu textuel.
    TextCompression = PdfTextCompression.Flate,

    // Définissez le mode de conformité PDF.
    Compliance = PdfCompliance.Pdf15
};

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Enregistrez la présentation en tant que document PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanciez la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Ajoutez les diapositives masquées.
pdfOptions.ShowHiddenSlides = true;

// Enregistrez la présentation au format PDF.
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code C# montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Instanciez la classe PdfOptions.
var pdfOptions = new PdfOptions();

// Définissez un mot de passe PDF et les autorisations d'accès.
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

// Enregistrez la présentation au format PDF.
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Détecter les substitutions de polices**

Aspose.Slides fournit la propriété [WarningCallback](https://reference.aspose.com/slides/fr/net/aspose.slides.export/saveoptions/warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion de présentation en PDF.

Ce code C# montre comment détecter les substitutions de polices :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;

public static void Main()
{
    // Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
    using var presentation = new Presentation("sample.pptx");

    // Définissez le rappel d'avertissement dans les options PDF.
    var pdfOptions = new PdfOptions();
    pdfOptions.WarningCallback = new FontSubstitutionHandler();

    // Enregistrez la présentation au format PDF.
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

{{%  alert color="info"  %}} 
Pour plus d’informations sur la réception de callbacks pour les substitutions de polices pendant le processus de rendu, voir [Getting Warning Callbacks for Fonts Substitution](/slides/fr/net/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consulter l’article [Font Substitution](/slides/fr/net/font-substitution/).
{{% /alert %}} 

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

Ce code C# montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
using var presentation = new Presentation("PowerPoint.pptx");

// Définissez le tableau des numéros de diapositives.
int[] slides = { 1, 3 };

// Enregistrez la présentation au format PDF.
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

Ce code C# montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

// Chargez une présentation PowerPoint.
using var presentation = new Presentation("SelectedSlides.pptx");

// Créez une nouvelle présentation avec une taille de diapositive ajustée.
using var resizedPresentation = new Presentation();

// Définissez la taille personnalisée de la diapositive.
resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);

// Clonez la première diapositive de la présentation originale.
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Supprimez la diapositive vierge avec laquelle la nouvelle présentation a été créée.
resizedPresentation.Slides.RemoveAt(1);

// Enregistrez la présentation redimensionnée au format PDF.
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convertir PowerPoint en PDF avec les notes de diapositive**

Ce code C# montre comment convertir une présentation PowerPoint en PDF incluant les notes :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Chargez une présentation PowerPoint.
using var presentation = new Presentation("NotesFile.pptx");

// Configurez les options PDF avec la mise en page des notes.
var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

// Enregistrez la présentation au format PDF avec les notes.
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Accessibilité et normes de conformité pour PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Directives d’accessibilité du contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C# montre un processus de conversion de PowerPoint en PDF qui génère plusieurs PDF selon différentes normes de conformité :
```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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
Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichier populaires. Vous pouvez effectuer les conversions [PDF to HTML](https://products.aspose.com/slides/fr/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/fr/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/fr/net/conversion/pdf-to-jpg/), et [PDF to PNG](https://products.aspose.com/slides/fr/net/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés — [PDF to SVG](https://products.aspose.com/slides/fr/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/fr/net/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/fr/net/conversion/pdf-to-xml/) — sont également prises en charge.
{{% /alert %}}

> **Note :** Lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les diagrammes et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

### Puis-je convertir plusieurs fichiers PowerPoint en PDF en masse ?
Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programme.

### Est-il possible de protéger le PDF converti par mot de passe ?
Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès pendant le processus de conversion.

### Comment inclure les diapositives masquées dans le PDF ?
Définissez la propriété `ShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) sur `true` pour inclure les diapositives masquées dans le PDF résultant.

### Aspose.Slides peut-il maintenir une haute qualité d’image dans le PDF ?
Oui, vous pouvez contrôler la qualité des images en définissant des propriétés telles que `JpegQuality` et `SufficientResolution` dans la classe [PdfOptions](https://reference.aspose.com/slides/fr/net/aspose.slides.export/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

### Aspose.Slides prend-il en charge les normes de conformité PDF/A ?
Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides for .NET](/slides/fr/net/)
- [Référence API Aspose.Slides for .NET](https://reference.aspose.com/slides/fr/net/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/fr/conversion)