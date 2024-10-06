---
title: Convertir PowerPoint en PDF en C++
linktitle: Convertir PowerPoint en PDF
type: docs
weight: 40
url: /cpp/convert-powerpoint-to-pdf/
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
- C++
- Aspose.Slides pour C++
description: "Convertir des présentations PowerPoint en PDF en C++. Enregistrez PowerPoint en tant que PDF avec des normes de conformité ou d'accessibilité."
---

## **Aperçu**

La conversion de documents PowerPoint au format PDF offre plusieurs avantages, y compris l'assurance de la compatibilité sur différents dispositifs et la préservation de la mise en page et du formatage de votre présentation. Cet article vous montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure des diapositives masquées, protéger par mot de passe les documents PDF, détecter les substitutions de polices, sélectionner des diapositives à convertir et appliquer des normes de conformité aux documents de sortie.

## **Conversions PowerPoint en PDF**

En utilisant Aspose.Slides, vous pouvez convertir des présentations dans ces formats en PDF :

* PPT
* PPTX
* ODP

Pour convertir une présentation en PDF, vous devez simplement passer le nom du fichier comme argument dans la classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) puis enregistrer la présentation sous forme de PDF en utilisant une méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e). La classe [Presentation](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation/) expose la méthode [Save](https://reference.aspose.com/slides/cpp/class/aspose.slides.presentation#afcd59ec697bf05c10f78c3869de2ec9e) qui est généralement utilisée pour convertir une présentation en PDF.

{{%  alert title="NOTE"  color="warning"   %}} 

Aspose.Slides pour C++ écrit directement des informations sur l'API et le numéro de version dans les documents de sortie. Par exemple, lorsqu'il convertit une présentation en PDF, Aspose.Slides pour C++ remplit le champ Application avec la valeur '*Aspose.Slides*' et le champ PDF Producer avec une valeur sous la forme '*Aspose.Slides v XX.XX*'. **Remarque** que vous ne pouvez pas demander à Aspose.Slides pour C++ de modifier ou de supprimer ces informations des documents de sortie.

{{% /alert %}}

Aspose.Slides vous permet de convertir :

* une présentation entière en PDF
* des diapositives spécifiques d'une présentation en PDF
* une présentation 

Aspose.Slides exporte les présentations en PDF d'une manière qui rend le contenu des PDF résultants très similaire à celui des présentations d'origine. Ces éléments et attributs connus sont souvent correctement rendus dans les conversions de présentation en PDF :

* images
* zones de texte et autres formes
* textes et leur formatage
* paragraphes et leur formatage
* hyperliens
* en-têtes et pieds de page
* puces
* tableaux

## **Convertir PowerPoint en PDF**

L'opération standard de conversion PowerPoint en PDF est exécutée en utilisant des options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximum.

<a name="cpp-powerpoint-to-pdf" id="cpp-powerpoint-to-pdf"><strong>Étapes : Convertir PowerPoint en PDF en C++</strong></a> |
<a name="cpp-ppt-to-pdf" id="cpp-ppt-to-pdf"><strong>Étapes : Convertir PPT en PDF en C++</strong></a> |
<a name="cpp-pptx-to-pdf" id="cpp-pptx-to-pdf"><strong>Étapes : Convertir PPTX en PDF en C++</strong></a> |
<a name="cpp-odp-to-pdf" id="cpp-odp-to-pdf"><strong>Étapes : Convertir ODP en PDF en C++</strong></a>

Ce code C++ vous montre comment convertir un PowerPoint en PDF :

```c++
// Instancie une classe Presentation qui représente un fichier PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.ppt");

// Enregistre la présentation comme un PDF
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
```

{{%  alert  color="primary"  %}} 

Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui démontre le processus de conversion de la présentation en PDF. Pour une mise en œuvre en direct de la procédure décrite ici, vous pouvez faire un test avec le convertisseur.

{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisées—propriétés sous la classe [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)—qui vous permettent de personnaliser le PDF (résultant du processus de conversion), de verrouiller le PDF avec un mot de passe, ou même de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec Options Personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre réglage de qualité préféré pour les images raster, spécifier comment les mét fichiers doivent être traités, définir un niveau de compression pour les textes, définir la DPI pour les images, etc.

L'exemple de code ci-dessous démontre une opération dans laquelle une présentation PowerPoint est convertie en PDF avec plusieurs options personnalisées :

```c++
// Instancie la classe PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Définit la qualité pour les images JPG
pdfOptions->set_JpegQuality(90);

// Définit la DPI pour les images
pdfOptions->set_SufficientResolution(300);

// Définit le comportement pour les mét fichiers
pdfOptions->set_SaveMetafilesAsPng(true);

// Définit le niveau de compression pour le contenu textuel
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Définit le mode de conformité PDF
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Instancie la classe Presentation qui représente un document PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Enregistre la présentation comme un document PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Convertir PowerPoint en PDF avec Diapositives Cachées**

Si une présentation contient des diapositives cachées, vous pouvez utiliser une option personnalisée—la propriété [ShowHiddenSlides](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options#ad11e5a17110d70456df91cc1a5dade23) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)—pour demander à Aspose.Slides d'inclure les diapositives cachées en tant que pages dans le PDF résultant.

Ce code C++ vous montre comment convertir une présentation PowerPoint en PDF avec les diapositives cachées incluses :

```c++
// Instancie une classe Presentation qui représente un fichier PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Instancie la classe PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Ajoute des diapositives cachées
pdfOptions->set_ShowHiddenSlides(true);

// Enregistre la présentation comme un PDF
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Convertir PowerPoint en PDF Protégé par Mot de Passe**

Ce code C++ vous montre comment convertir un PowerPoint en un PDF protégé par mot de passe (en utilisant les paramètres de protection de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/class/aspose.slides.export.pdf_options/)) :

```c++
// Instancie un objet Presentation qui représente un fichier PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

/// Instancie la classe PdfOptions
auto pdfOptions = System::MakeObject<PdfOptions>();

// Définit le mot de passe PDF et les permissions d'accès
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Enregistre la présentation comme un PDF
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
```

### **Détecter les Substitutions de Polices**

Aspose.Slides fournit la méthode [get_WarningCallback()](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/get_warningcallback/) de la classe [SaveOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/) pour vous permettre de détecter les substitutions de polices dans un processus de conversion de présentation en PDF. 

Ce code C++ vous montre comment détecter les substitutions de polices :

```c++
class FontSubstSendsWarningCallback : public Warnings::IWarningCallback
{
public:
    Warnings::ReturnAction Warning(System::SharedPtr<Warnings::IWarningInfo> warning) override;
};

Warnings::ReturnAction FontSubstSendsWarningCallback::Warning(System::SharedPtr<Warnings::IWarningInfo> warning)
{
    if (warning->get_WarningType() == Warnings::WarningType::CompatibilityIssue)
    {
        return Warnings::ReturnAction::Continue;
    }

    if (warning->get_WarningType() == Warnings::WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
    {
        System::Console::WriteLine(u"Alerte de substitution de police : {0}", warning->get_Description());
    }

    return Warnings::ReturnAction::Continue;
}
```

et le code C++ suivant montre comment utiliser la classe précédente :

```c++
int main()
{
    System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
    System::SharedPtr<FontSubstSendsWarningCallback> warningCallback = System::MakeObject<FontSubstSendsWarningCallback>();
    loadOptions->set_WarningCallback(warningCallback);

    System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"pres.pptx", loadOptions);
    return 0;
}
```

{{%  alert color="primary"  %}} 

Pour plus d'informations sur l'obtention des rappels pour les substitutions de polices dans un processus de rendu, voir [Obtenir des rappels d'avertissement pour la substitution de polices](https://docs.aspose.com/slides/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/).

Pour plus d'informations sur la substitution de polices, voir l'article [Substitution de polices](https://docs.aspose.com/slides/cpp/font-substitution/).

{{% /alert %}} 

## **Convertir des Diapositives Sélectionnées en PowerPoint en PDF**

Ce code C++ vous montre comment convertir des diapositives spécifiques d'une présentation PowerPoint en PDF :

```C++
// Instancie un objet Presentation qui représente un fichier PowerPoint
auto presentation = System::MakeObject<Presentation>(u"PowerPoint.pptx");

// Définit un tableau de positions de diapositives
auto slides = System::MakeArray<int32_t>({1, 3});

// Enregistre la présentation comme un PDF
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
```

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisée**

Ce code C++ vous montre comment convertir un PowerPoint lorsque sa taille de diapositive est spécifiée en PDF :

```C++
// Le chemin vers le répertoire des documents.
String dataDir = GetDataPath()

// Instancie un objet Presentation qui représente un fichier PowerPoint 
auto presentation = System::MakeObject<Presentation>(dataDir + u"SelectedSlides.pptx");
auto auxPresentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slides()->idx_get(0);

auxPresentation->get_Slides()->InsertClone(0, slide);

// Définit le type et la taille de la diapositive 
auxPresentation->get_SlideSize()->SetSize(612.F, 792.F, SlideSizeScaleType::EnsureFit);

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

auxPresentation->Save(dataDir + u"PDFnotes_out.pdf", SaveFormat::Pdf, pdfOptions);
```

## **Convertir PowerPoint en PDF en Mode Notes**

Ce code C++ vous montre comment convertir un PowerPoint en PDF notes :

```C++
// Le chemin vers le répertoire des documents.
System::String dataDir = u"";

// Instancie une classe Presentation qui représente un fichier PowerPoint
auto presentation = System::MakeObject<Presentation>(dataDir + u"NotesFile.pptx");

auto pdfOptions = System::MakeObject<PdfOptions>();
auto options = pdfOptions->get_NotesCommentsLayouting();
options->set_NotesPosition(NotesPositions::BottomFull);

// Enregistre la présentation en tant que PDF de notes
presentation->Save(dataDir + u"Pdf_Notes_out.tiff", SaveFormat::Pdf, pdfOptions);
```

## **Normes d'Accessibilité et de Conformité pour PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion qui respecte les [Directives d'Accessibilité au Contenu Web (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

Ce code C++ démontre une opération de conversion PowerPoint en PDF dans laquelle plusieurs PDF basés sur différentes normes de conformité sont obtenus :

```C++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

auto pdfOptionsA1a = System::MakeObject<PdfOptions>();
pdfOptionsA1a->set_Compliance(PdfCompliance::PdfA1a);
pres->Save(u"pres-a1a-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1a);

auto pdfOptionsA1b = System::MakeObject<PdfOptions>();
pdfOptionsA1b->set_Compliance(PdfCompliance::PdfA1b);
pres->Save(u"pres-a1b-compliance.pdf", SaveFormat::Pdf, pdfOptionsA1b);

auto pdfOptionsUa = System::MakeObject<PdfOptions>();
pdfOptionsUa->set_Compliance(PdfCompliance::PdfUa);
pres->Save(u"pres-ua-compliance.pdf", SaveFormat::Pdf, pdfOptionsUa);
```

{{% alert title="Note" color="warning" %}} 

Le support d'Aspose.Slides pour les opérations de conversion PDF s'étend à vous permettre de convertir PDF dans les formats de fichiers les plus populaires. Vous pouvez effectuer des conversions [PDF en HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF en image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF en JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), et [PDF en PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). D'autres opérations de conversion PDF dans des formats spécialisés—[PDF en SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF en TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), et [PDF en XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—sont également prises en charge.

{{% /alert %}}