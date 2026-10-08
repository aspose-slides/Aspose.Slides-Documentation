---
title: Convertir PPT et PPTX en PDF sous .NET [Fonctionnalités avancées incluses]
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
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- .NET
- C#
- Aspose.Slides
description: "Convertir les fichiers PowerPoint PPT/PPTX en PDFs de haute qualité et recherchables sous .NET à l’aide d’Aspose.Slides, avec des exemples de code C# rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C# offre plusieurs avantages, notamment la compatibilité sur différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer les normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

En utilisant Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants vers PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide d’une méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pour .NET insère ses informations d’API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec « *Aspose.Slides* » et le champ PDF Producer avec une valeur sous la forme « *Aspose.Slides v XX.XX* ». **Remarque** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :
* Présentations entières en PDF
* Diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations au format PDF, en veillant à ce que les PDF résultants correspondent étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :
* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L’exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d’exportation par défaut.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.ppt");
presentation.Save("PDF-result.pdf", SaveFormat.Pdf);
```

{{% alert color="info" title="Note" %}}
Aspose propose un [**convertisseur PowerPoint vers PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) gratuit en ligne qui montre le processus de conversion de la présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une mise en œuvre en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier la façon dont le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier comment les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, et plus encore.

L’exemple suivant exporte une présentation au format PDF 1.5 avec une qualité JPEG fixée à 90, une résolution d’image de 300 DPI, les métafichiers enregistrés au format PNG, et une compression de texte Flate.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    JpegQuality = 90,
    SufficientResolution = 300,
    SaveMetafilesAsPng = true,
    TextCompression = PdfTextCompression.Flate,
    Compliance = PdfCompliance.Pdf15
};

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Conserver les fichiers OLE incorporés en tant que pièces jointes PDF**

Si une présentation contient un classeur Excel incorporé, vous pouvez souhaiter que les destinataires du PDF accèdent aux données du classeur ainsi qu’aux diapositives. Définissez [PdfOptions.IncludeOleData](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/includeoledata/) sur `true` pour conserver les fichiers OLE incorporés en tant que pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l’image d’aperçu ou l’icône de l’objet OLE est rendue sur la page PDF, mais son fichier incorporé n’est pas inclus en tant que pièce jointe. Le fait de définir l’option sur `true` ajoute également les données du fichier. L’aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d’ouvrir ou d’enregistrer le fichier incorporé séparément. L’objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L’exemple suivant charge une présentation contenant déjà un classeur Excel incorporé et l’exporte en PDF avec le classeur joint.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions { IncludeOleData = true };

using var presentation = new Presentation("presentation.pptx");
presentation.Save("presentation.pdf", SaveFormat.Pdf, pdfOptions);
```

Pour vérifier le résultat :
1. Ouvrez le PDF exporté dans un visualiseur qui prend en charge les pièces jointes, tel qu’Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du visualiseur et localisez le classeur incorporé.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour examiner ses données, ou ouvrez‑la directement si le visualiseur le permet. L’aperçu sur la page PDF est distinct de la pièce jointe.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers incorporés, PDF/A‑2 ne permet que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s’agit d’exigences des normes, pas de restrictions propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne démontre pas l’exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

L’exemple suivant exporte une présentation en PDF, en incluant les éventuelles diapositives masquées.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.ShowHiddenSlides = true;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PowerPoint-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L’exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour s’ouvrir. Les permissions d’accès autorisent l’impression, y compris l’impression de haute qualité.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions();
pdfOptions.Password = "password";
pdfOptions.AccessPermissions = PdfAccessPermissions.PrintDocument | PdfAccessPermissions.HighQualityPrint;

using var presentation = new Presentation("PowerPoint.pptx");
presentation.Save("PPTX-to-PDF.pdf", SaveFormat.Pdf, pdfOptions);
```

### **Détecter les substitutions de polices**

Aspose.Slides fournit la propriété [WarningCallback](https://reference.aspose.com/slides/net/aspose.slides.export/saveoptions/warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) permettant de détecter les substitutions de polices pendant le processus de conversion de la présentation en PDF.

L’exemple suivant exporte une présentation en PDF et imprime les avertissements de substitution de police dans la console. Un avertissement est affiché uniquement lorsqu’une police indisponible est substituée lors de l’exportation.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Warnings;
using System;

var pdfOptions = new PdfOptions();
pdfOptions.WarningCallback = new FontSubstitutionHandler();

using var presentation = new Presentation("sample.pptx");
presentation.Save("output.pdf", SaveFormat.Pdf, pdfOptions);

class FontSubstitutionHandler : IWarningCallback
{
    public ReturnAction Warning(IWarningInfo warning)
    {
        if (warning.WarningType == WarningType.DataLoss && warning.Description.StartsWith("Font will be substituted"))
        {
            Console.WriteLine($"Font substitution warning: {warning.Description}");
        }

        return ReturnAction.Continue;
    }
}
```

{{% alert color="info" title="Note" %}}
Pour plus d’informations sur la substitution de polices, consultez l’article [Substitution de polices](/slides/fr/net/font-substitution/).
{{% /alert %}}

### **Gérer les polices sans variante gras dédiée**

Une présentation peut appliquer un format gras au texte même si la police ne possède pas de variante gras dédiée. Le texte peut néanmoins apparaître en gras grâce à un gras synthétique, qui épaissit artificiellement les glyphes normaux. Si ce texte semble trop lourd ou diffère de l’apparence souhaitée dans le PDF, essayez de définir [PdfOptions.RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/rasterizeunsupportedfontstyles/) sur `true`. Cette option rend le texte concerné sous forme de bitmap lors de l’exportation PDF et peut améliorer son apparence pour certaines polices. Sa valeur par défaut est `false`.

La présentation d’exemple contient deux zones de texte : une avec du texte normal et une avec un format gras appliqué à la même police, qui ne possède pas de variante gras dédiée. L’exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge et l’exporte en PDF :

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    RasterizeUnsupportedFontStyles = true
};

using var presentation = new Presentation("unsupported-bold.pptx");
presentation.Save("rasterized.pdf", SaveFormat.Pdf, pdfOptions);
```

Les aperçus suivants montrent la sortie désactivée et la sortie activée. Dans cet exemple, le texte en gras a des traits plus épais lorsque l’option est désactivée. Avec l’option activée, ses traits sont plus fins ; le texte normal reste inchangé. Comparez les résultats avant de choisir le paramètre pour votre présentation.

| Option désactivée (`false`, la valeur par défaut) | Option activée (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, activer l’option transforme uniquement le texte en gras en bitmap : il ne peut plus être sélectionné, copié ou recherché comme texte sans OCR, et ses bords paraissent plus doux à 800 % de zoom. Le texte normal reste recherchable. Avec l’option désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte mis en forme gras lorsque la police ne possède pas de variante gras dédiée. [Substitution de polices](/slides/fr/net/font-substitution/) sélectionne à la place une autre police lorsque l’originale n’est pas disponible.

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

L’exemple suivant exporte les diapositives 1 et 3 d’une présentation en PDF. Les numéros de diapositives dans ce tableau sont indexés à partir de 1, et la présentation d’entrée doit contenir au moins trois diapositives.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("PowerPoint.pptx");
var slides = new[] { 1, 3 };
presentation.Save("PPTX-to-PDF.pdf", slides, SaveFormat.Pdf);
```

## **Convertir PowerPoint en PDF avec une taille de diapositive personnalisée**

L’exemple suivant copie la première diapositive d’une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il redimensionne le contenu de la diapositive pour l’ajuster et exporte la seule diapositive en PDF.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var slideWidth = 612;
var slideHeight = 792;

using var presentation = new Presentation("SelectedSlides.pptx");
using var resizedPresentation = new Presentation();

resizedPresentation.SlideSize.SetSize(slideWidth, slideHeight, SlideSizeScaleType.EnsureFit);
var slide = presentation.Slides[0];
resizedPresentation.Slides.InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation.Slides.RemoveAt(1);
resizedPresentation.Save("PDF_with_custom_slide_size.pdf", SaveFormat.Pdf);
```

## **Convertir PowerPoint en PDF en vue des notes de diapositive**

L’exemple suivant exporte une présentation en PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes du présentateur pour voir le résultat.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var pdfOptions = new PdfOptions
{
    SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    }
};

using var presentation = new Presentation("NotesFile.pptx");
presentation.Save("PDF_with_notes.pdf", SaveFormat.Pdf, pdfOptions);
```

## **Normes d’accessibilité et de conformité pour PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C# montre un processus de conversion PowerPoint‑vers‑PDF qui génère plusieurs PDFs en fonction de différentes normes de conformité :

```csharp
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

{{% alert color="info" title="Note" %}}
Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF en formats de fichiers populaires. Vous pouvez effectuer les conversions [PDF to HTML](https://products.aspose.com/slides/net/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/net/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/net/conversion/pdf-to-jpg/), et [PDF to PNG](https://products.aspose.com/slides/net/conversion/pdf-to-png/). D’autres opérations de conversion PDF vers des formats spécialisés—[PDF to SVG](https://products.aspose.com/slides/net/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/net/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/net/conversion/pdf-to-xml/)—sont également prises en charge.
{{% /alert %}}

> **Note** : lors de l’exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une figure unique. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis-je convertir plusieurs fichiers PowerPoint en PDF en masse ?**  
Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est-il possible de protéger par mot de passe le PDF converti ?**  
Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les permissions d’accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**  
Définissez la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) sur `true` pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut-il conserver une haute qualité d’image dans le PDF ?**  
Oui, vous pouvez contrôler la qualité des images en définissant des propriétés telles que [JpegQuality](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/jpegquality/) et [SufficientResolution](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/sufficientresolution/) dans la classe [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) afin d’assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend-il en charge les normes de conformité PDF/A ?**  
Oui, Aspose.Slides vous permet d’exporter des PDFs conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour .NET](/slides/fr/net/)
- [Référence API Aspose.Slides pour .NET](https://reference.aspose.com/slides/net/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)