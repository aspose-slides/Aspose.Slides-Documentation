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
description: "Convertir PowerPoint PPT/PPTX en PDF de haute qualité et interrogeables en C++ avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---

## **Vue d'ensemble**

La conversion de présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C++ offre plusieurs avantages, notamment la compatibilité entre différents appareils et la préservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint vers PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants vers PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, transmettez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l’aide d’une méthode `Save`. La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expose la méthode `Save` qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides for C++ insère ses informations d’API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d’une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur au format "*Aspose.Slides v XX.XX*". **Note** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d’une présentation en PDF

Aspose.Slides exporte les présentations vers PDF, en veillant à ce que les PDF générés correspondent étroitement aux présentations d’origine. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En‑têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard PowerPoint‑vers‑PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux au niveau de qualité maximal.

Ce code C++ vous montre comment convertir une présentation (PPT, PPTX, ODP, etc.) en PDF :
```c++
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Enregistrer la présentation au format PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```


{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint vers PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui illustre le processus de conversion d’une présentation en PDF. Vous pouvez tester ce convertisseur pour une implémentation en temps réel de la procédure décrite ici.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées — des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe ou de spécifier comment le processus de conversion doit s’exécuter.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier le traitement des métafichiers, définir un niveau de compression pour le texte, configurer le DPI des images, etc.

L’exemple de code ci‑dessous montre comment convertir une présentation PowerPoint en PDF avec plusieurs options personnalisées.
```c++
// Instancier la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Définir la qualité pour les images JPG.
pdfOptions->set_JpegQuality(90);

// Définir le DPI pour les images.
pdfOptions->set_SufficientResolution(300);

// Définir le comportement des métafichiers.
pdfOptions->set_SaveMetafilesAsPng(true);

// Définir le niveau de compression du texte pour le contenu textuel.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Définir le mode de conformité PDF.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Enregistrer la présentation en tant que document PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées comme pages dans le PDF résultant.

Ce code C++ montre comment convertir une présentation PowerPoint en PDF en incluant les diapositives masquées :
```c++
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancier la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Ajouter les diapositives masquées.
pdfOptions->set_ShowHiddenSlides(true);

// Enregistrer la présentation au format PDF.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Convertir PowerPoint en PDF protégé par mot de passe**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF protégé par mot de passe en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) :
```c++
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancier la classe PdfOptions.
auto pdfOptions = MakeObject<PdfOptions>();

// Définir un mot de passe PDF et les autorisations d'accès.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Enregistrer la présentation au format PDF.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


### **Détecter les substitutions de polices**

Aspose.Slides fournit la méthode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), vous permettant de détecter les substitutions de polices pendant le processus de conversion de la présentation en PDF.

Ce code C++ montre comment détecter les substitutions de polices :
```c++
// Implémentation du callback d'avertissement.
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
    // Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Définir le callback d'avertissement dans les options PDF.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Enregistrer la présentation au format PDF.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```


{{%  alert color="primary"  %}} 

Pour plus d’informations sur la réception de callbacks lors des substitutions de polices pendant le rendu, consultez [Getting Warning Callbacks for Fonts Substitution](/slides/fr/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d’informations sur les substitutions de polices, consultez l’article [Font Substitution](/slides/fr/cpp/font-substitution/).

{{% /alert %}} 

## **Convertir des diapositives sélectionnées de PowerPoint en PDF**

Ce code C++ montre comment convertir uniquement des diapositives spécifiques d’une présentation PowerPoint en PDF :
```C++
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Définir le tableau des numéros de diapositives.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Enregistrer la présentation au format PDF.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```


## **Convertir PowerPoint en PDF avec une taille de diapositive personnalisée**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF avec une taille de diapositive spécifiée :
```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Créer une nouvelle présentation avec une taille de diapositive ajustée.
auto resizedPresentation = MakeObject<Presentation>();

// Définir la taille de diapositive personnalisée.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Cloner la première diapositive de la présentation originale.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Enregistrer la présentation redimensionnée dans un PDF avec notes.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```


## **Convertir PowerPoint en PDF en affichage des notes de diapositive**

Ce code C++ montre comment convertir une présentation PowerPoint en PDF incluant les notes :
```C++
// Instancier la classe Presentation qui représente un fichier PowerPoint ou OpenDocument.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Configurer les options PDF avec la mise en page des notes.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Enregistrer la présentation dans un PDF avec notes.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```


## **Accessibilité et normes de conformité pour PDF**

Aspose.Slides vous permet d’employer une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en respectant l’une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C++ montre un processus de conversion PowerPoint‑vers‑PDF qui produit plusieurs PDF en fonction de différentes normes de conformité :
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

Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats populaires. Vous pouvez effectuer des conversions [PDF vers HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF vers image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF vers JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), et [PDF vers PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). D’autres conversions PDF vers des formats spécialisés—[PDF vers SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF vers TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), et [PDF vers XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}

## **FAQ**

**Puis‑je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion en lot de plusieurs fichiers PPT ou PPTX vers PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programme.

**Est‑il possible de protéger le PDF converti par un mot de passe ?**

Absolument. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour définir un mot de passe et préciser les autorisations d’accès pendant la conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode `set_ShowHiddenSlides` de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut‑il maintenir une haute qualité d’image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que `set_JpegQuality` et `set_SufficientResolution` de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour garantir des images haute résolution dans votre PDF.

**Aspose.Slides prend‑il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d’exporter des PDF conformes à diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents répondent aux exigences d’accessibilité et d’archivage.

## **Ressources complémentaires**

- [Documentation Aspose.Slides for C++](/slides/fr/cpp/)
- [Référence API Aspose.Slides for C++](https://reference.aspose.com/slides/cpp/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)