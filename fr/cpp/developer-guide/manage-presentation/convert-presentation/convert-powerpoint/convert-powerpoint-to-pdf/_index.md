---
title: Convertir PPT et PPTX en PDF en C++ [Fonctionnalités avancées incluses]
linktitle: PowerPoint en PDF
type: docs
weight: 40
url: /fr/cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides
description: "Convertir les présentations PowerPoint PPT/PPTX en PDF de haute qualité et consultables en C++ avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---

## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C++ offre plusieurs avantages, notamment la compatibilité avec différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir les présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide de la méthode `Save`. La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expose la méthode `Save` qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ insère ses informations d’API et son numéro de version dans les documents générés. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur du type "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents générés.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, en veillant à ce que les PDF obtenus correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

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

Ce code C++ montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```c++
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Enregistrez la présentation au format PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui illustre le processus de conversion présentation‑vers‑PDF. Vous pouvez tester ce convertisseur pour une implémentation en direct de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de le verrouiller par mot de passe ou de spécifier comment la conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

Avec des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier la façon dont les métafichiers doivent être traités, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.
```c++
// Instanciez la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Définissez la qualité pour les images JPG.
pdfOptions->set_JpegQuality(90);

// Définissez le DPI pour les images.
pdfOptions->set_SufficientResolution(300);

// Définissez le comportement pour les métafichiers.
pdfOptions->set_SaveMetafilesAsPng(true);

// Définissez le niveau de compression du texte pour le contenu textuel.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Définissez le mode de conformité du PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Enregistrez la présentation au format PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Convertir PowerPoint en PDF avec Diapositives Masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

Ce code C++ montre comment convertir une présentation PowerPoint en PDF avec les diapositives masquées incluses :
```c++
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciez la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ajoutez les diapositives masquées.
pdfOptions->set_ShowHiddenSlides(true);

// Enregistrez la présentation au format PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) :
```c++
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instanciez la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Définissez un mot de passe PDF et les permissions d'accès.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Enregistrez la présentation au format PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) sous la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion présentation‑vers‑PDF.

Ce code C++ montre comment détecter les substitutions de polices :
```c++
// Implémentation du rappel d'avertissement.
class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override;
};

ReturnAction FontSubstitutionHandler::Warning(SharedPtr<IWarningInfo> warning)
{
    if (warning->get_WarningType() == WarningType::DataLoss && 
        warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
    }

    return ReturnAction::Continue;
}

int main()
{
    // Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Définissez le rappel d'avertissement dans les options PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Enregistrez la présentation au format PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

Pour plus d’informations sur la réception de callbacks pour les substitutions de polices pendant le rendu, consultez [Receiving Warning Callbacks for Fonts Substitution](/slides/fr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur la substitution de polices, consultez l’article [Font Substitution](/slides/fr/cpp/font-substitution/).

{{% /alert %}} 

## **Convertir Diapositives Sélectionnées de PowerPoint en PDF**

Ce code C++ montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```C++
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Définissez le tableau des numéros de diapositives.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Enregistrez la présentation au format PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instantiate the Presentation class that represents a PowerPoint or OpenDocument file.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Create a new presentation with an adjusted slide size.
auto resizedPresentation = MakeObject<Presentation>();

// Set the custom slide size.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Clone the first slide from the original presentation.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Save the resized presentation to a PDF with notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **Convertir PowerPoint en PDF en Vue Notes de Diapositive**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF incluant les notes :
```C++
// Instanciez la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configurez les options PDF avec la mise en page des notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Enregistrez la présentation au format PDF avec les notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **Accessibilité et Normes de Conformité pour le PDF**

Aspose.Slides vous permet d’utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C++ montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF selon différentes normes de conformité :
```C++
auto presentation = MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = MakeObject<PdfOptions>();

pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
presentation->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
presentation->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);

presentation->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);

presentation->Dispose();
```


{{% alert title="Note" color="warning" %}} 

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats courants. Vous pouvez réaliser les conversions : [PDF vers HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés — [PDF vers SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programme.

**Est‑il possible de protéger le PDF converti par mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d’accès lors de la conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `set_ShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `set_JpegQuality` et `set_SufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour garantir des images haute résolution dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents respectent les exigences d’accessibilité et d’archivage.

## **Ressources Supplémentaires**

- [Documentation Aspose.Slides pour C++](/slides/fr/cpp/)
- [Référence API Aspose.Slides pour C++](https://reference.aspose.com/slides/cpp/)
- [Convertisseurs En Ligne Gratuits Aspose](https://products.aspose.app/slides/conversion)