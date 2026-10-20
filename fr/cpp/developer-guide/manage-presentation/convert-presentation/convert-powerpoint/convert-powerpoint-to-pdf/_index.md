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
- enregistrer PowerPoint au format PDF
- enregistrer PPT au format PDF
- enregistrer PPTX au format PDF
- exporter PPT en PDF
- exporter PPTX en PDF
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Convertissez les fichiers PowerPoint PPT/PPTX en PDF de haute qualité et recherchables en C++ avec Aspose.Slides, avec des exemples de code rapides et des options de conversion avancées."
---
## **Vue d'ensemble**

Convertir des présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C++ offre plusieurs avantages, notamment la compatibilité sur différents appareils et la conservation de la disposition et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, protéger les fichiers PDF par mot de passe, détecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion, et appliquer des normes de conformité aux documents de sortie.

## **Conversions de PowerPoint en PDF**

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) puis enregistrez la présentation au format PDF à l'aide d'une méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) qui est généralement utilisée pour convertir une présentation en PDF.

{{% alert color="info" title="Remarque" %}}
Aspose.Slides pour C++ insère ses informations d'API et son numéro de version dans les documents de sortie. Par exemple, lors de la conversion d'une présentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Remarque** que vous ne pouvez pas demander à Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des présentations entières en PDF
* Des diapositives spécifiques d'une présentation en PDF

Aspose.Slides exporte les présentations au format PDF, garantissant que les PDF générés correspondent étroitement aux présentations originales. Les éléments et attributs sont rendus avec précision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Liens hypertexte
* En-têtes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus standard de conversion PowerPoint en PDF utilise les options par défaut. Dans ce cas, Aspose.Slides tente de convertir la présentation fournie en PDF en utilisant des paramètres optimaux aux niveaux de qualité maximale.

L'exemple suivant charge une présentation et enregistre toutes les diapositives visibles en PDF en utilisant les paramètres d'exportation par défaut.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);
presentation->Dispose();
```

{{% alert color="info" title="Remarque" %}}
Aspose propose un [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) en ligne gratuit qui montre le processus de conversion de présentation en PDF. Vous pouvez effectuer un test avec ce convertisseur pour une implémentation en direct de la procédure décrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec options**

Aspose.Slides fournit des options personnalisées—des propriétés de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/)—qui vous permettent de personnaliser le PDF résultant, de verrouiller le PDF avec un mot de passe, ou de spécifier comment le processus de conversion doit se dérouler.

### **Convertir PowerPoint en PDF avec options personnalisées**

En utilisant des options de conversion personnalisées, vous pouvez définir votre paramètre de qualité préféré pour les images raster, spécifier comment les métafichiers doivent être traités, fixer un niveau de compression pour le texte, configurer le DPI pour les images, et plus encore.

L'exemple suivant exporte une présentation au format PDF 1.5 avec une qualité JPEG de 90, une résolution d'image de 300 DPI, les métafichiers enregistrés en PNG, et une compression de texte Flate.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_JpegQuality(90);
pdfOptions->set_SufficientResolution(300);
pdfOptions->set_SaveMetafilesAsPng(true);
pdfOptions->set_TextCompression(PdfTextCompression::Flate);
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Sélectionner automatiquement la compression d'image**

Lorsqu'une présentation contient de nombreuses photographies ou captures d'écran, réduire la taille du PDF exporté peut faciliter l'envoi par e‑mail ou le téléchargement. Appelez [PdfOptions::set_BestImagesCompressionRatio](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_bestimagescompressionratio/) avec `true` pour sélectionner automatiquement l'algorithme de compression le plus approprié pour chaque image lors de l'exportation PDF.

L'exemple suivant charge une présentation existante, active la sélection automatique de la compression d'image, et l'enregistre en tant que document PDF. Tous les autres paramètres d'exportation PDF conservent leurs valeurs par défaut.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_BestImagesCompressionRatio(true);

auto presentation = MakeObject<Presentation>(u"image-heavy.pptx");
presentation->Save(u"image-heavy.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Cette option choisit un algorithme de compression pour chaque image. Réduire la qualité JPEG avec [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) diminue la qualité de l'image JPEG, tandis que réduire la résolution avec [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) permet de sous‑échantillonner les images à une résolution inférieure, ce qui peut réduire les détails. Activer la sélection automatique de la compression ne diminue pas ces paramètres.

Sélectionner les algorithmes de compression d'image nécessite du temps de traitement et de la mémoire supplémentaires. La réduction de taille dépend des images de la présentation et des paramètres d'exportation ; une réduction fixe n'est pas garantie pour chaque présentation.

### **Conserver les fichiers OLE incorporés comme pièces jointes PDF**

Si une présentation contient un classeur Excel incorporé, vous pouvez souhaiter que les destinataires du PDF puissent accéder aux données du classeur ainsi que visualiser les diapositives. Appelez [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) avec `true` pour conserver les fichiers OLE incorporés comme pièces jointes dans le PDF résultant.

La valeur par défaut est `false` : l'image d'aperçu ou l'icône de l'objet OLE est rendue sur la page PDF, mais son fichier incorporé n'est pas inclus comme pièce jointe. Mettre l'option à `true` ajoute également les données du fichier. L'aperçu reste une représentation visuelle ; la pièce jointe permet aux destinataires d'ouvrir ou d'enregistrer le fichier incorporé séparément. L'objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L'exemple suivant charge une présentation contenant déjà un classeur Excel incorporé et l'exporte en PDF avec le classeur joint.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_IncludeOleData(true);

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
presentation->Save(u"presentation.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Pour vérifier le résultat :

1. Ouvrez le PDF exporté dans un visualiseur qui prend en charge les pièces jointes de fichiers, comme Adobe Acrobat Reader.
2. Ouvrez le panneau **Attachments** du visualiseur et localisez le classeur incorporé.
3. Enregistrez la pièce jointe et ouvrez‑la dans Excel pour inspecter ses données, ou ouvrez‑la directement si le visualiseur le permet. L'aperçu sur la page PDF est distinct de la pièce jointe.

{{% alert color="info" title="Remarque" %}}
Les normes PDF/A imposent des restrictions sur les pièces jointes : PDF/A‑1 interdit les fichiers incorporés, PDF/A‑2 ne permet que les pièces jointes PDF/A, et PDF/A‑3 autorise d’autres types de fichiers, y compris les classeurs Excel. Il s'agit d'exigences des normes, et non de restrictions propres à Aspose.Slides. Cet exemple utilise le paramètre de conformité PDF par défaut et ne montre pas l'exportation PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec diapositives masquées**

Si une présentation contient des diapositives masquées, vous pouvez utiliser la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées en tant que pages dans le PDF résultant.

L'exemple suivant exporte une présentation en PDF, en incluant toutes les diapositives masquées.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_ShowHiddenSlides(true);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Convertir PowerPoint en PDF protégé par mot de passe**

L'exemple suivant exporte une présentation en PDF qui nécessite le mot de passe `password` pour l'ouvrir. Les autorisations d'accès permettent l'impression, y compris l'impression haute qualité.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

### **Détecter les substitutions de polices**

Aspose.Slides fournit la méthode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), vous permettant de détecter les substitutions de polices durant le processus de conversion de présentation en PDF.

L'exemple suivant exporte une présentation en PDF et affiche les avertissements de substitution de polices dans la console. Un avertissement est affiché uniquement lorsqu'une police non disponible est substituée lors de l'exportation.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <Warnings/IWarningCallback.h>
#include <Warnings/IWarningInfo.h>
#include <Warnings/ReturnAction.h>
#include <Warnings/WarningType.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::Warnings;
using namespace System;

class FontSubstitutionHandler : public IWarningCallback
{
public:
    ReturnAction Warning(SharedPtr<IWarningInfo> warning) override
    {
        if (warning->get_WarningType() == WarningType::DataLoss && warning->get_Description().StartsWith(u"Font will be substituted"))
        {
            Console::WriteLine(u"Font substitution warning: {0}", warning->get_Description());
        }

        return ReturnAction::Continue;
    }
};

auto pdfOptions = MakeObject<PdfOptions>();
auto warningHandler = MakeObject<FontSubstitutionHandler>();
pdfOptions->set_WarningCallback(warningHandler);

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

{{% alert color="info" title="Remarque" %}}
Pour plus d'informations sur la substitution de polices, consultez l'article [Font Substitution](/slides/fr/cpp/font-substitution/).
{{% /alert %}}

### **Gérer les polices sans graisse dédiée**

Une présentation peut appliquer une mise en forme en gras au texte même si sa police n'a pas de graisse dédiée. Le texte peut néanmoins apparaître en gras grâce au gras synthétique, qui épaissit artificiellement les glyphes normaux. Si ce texte semble trop lourd ou diffère de l'apparence prévue dans le PDF, essayez d'appeler [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) avec `true`. Cette option rend le texte concerné sous forme de bitmap lors de l'exportation PDF et peut améliorer son apparence pour certaines polices. Sa valeur par défaut est `false`.

La présentation d'exemple contient deux zones de texte : une avec du texte normal et une avec une mise en forme en gras appliquée à la même police, qui n'a pas de graisse dédiée. L'exemple suivant charge la présentation, active la rasterisation des styles de police non pris en charge, et l'exporte en PDF :

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_RasterizeUnsupportedFontStyles(true);

auto presentation = MakeObject<Presentation>(u"unsupported-bold.pptx");
presentation->Save(u"rasterized.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

Les aperçus suivants montrent la sortie désactivée et la sortie activée. Dans cet exemple, le texte en gras a des traits plus épais avec l'option désactivée. Avec l'option activée, ses traits sont plus légers ; le texte normal reste inchangé. Comparez les résultats avant de choisir le paramètre pour votre présentation.

| Option désactivée (`false`, la valeur par défaut) | Option activée (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, activer l'option transforme uniquement le texte en gras en bitmap : il ne peut pas être sélectionné, copié ou recherché comme texte sans OCR, et ses contours apparaissent plus doux à 800 % de zoom. Le texte normal reste recherchable. Avec l'option désactivée, les deux chaînes restent du texte.

Cette option rasterise le texte formaté en gras lorsque sa police n'a pas de graisse dédiée. [Font substitution](/slides/fr/cpp/font-substitution/) sélectionne plutôt une autre police lorsque l'originale est indisponible.

## **Convertir les diapositives sélectionnées de PowerPoint en PDF**

L'exemple suivant exporte les diapositives 1 et 3 d'une présentation en PDF. Les numéros de diapositives dans ce tableau commencent à 1, et la présentation d'entrée doit contenir au moins trois diapositives.

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");
auto slides = MakeArray<int32_t>({ 1, 3 });
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);
presentation->Dispose();
```

## **Convertir PowerPoint en PDF avec taille de diapositive personnalisée**

L'exemple suivant copie la première diapositive d'une présentation dans une nouvelle présentation avec une taille de diapositive de 612 × 792 points (8,5 × 11 pouces). Il ajuste le contenu de la diapositive pour qu'il s'adapte et exporte la diapositive unique en PDF.

```cpp
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto slideWidth = 612;
auto slideHeight = 792;

auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");
auto resizedPresentation = MakeObject<Presentation>();

resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Remove the blank slide that the new presentation was created with.
resizedPresentation->get_Slides()->RemoveAt(1);

resizedPresentation->Save(u"PDF_with_custom_slide_size.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **Convertir PowerPoint en PDF en affichage des notes de diapositive**

L'exemple suivant exporte une présentation en PDF, plaçant les notes du présentateur de chaque diapositive sous la diapositive. Utilisez une présentation contenant des notes de présentateur pour voir le résultat.

```cpp
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

auto presentation = MakeObject<Presentation>(u"NotesFile.pptx");
presentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf, pdfOptions);
presentation->Dispose();
```

## **Accessibilité et normes de conformité pour PDF**

Aspose.Slides vous permet d'utiliser une procédure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b**, et **PDF/UA**.

```cpp
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

{{% alert color="info" title="Remarque" %}}
Aspose.Slides prend en charge les opérations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichiers populaires. Vous pouvez effectuer les conversions [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), et [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). D'autres conversions PDF vers des formats spécialisés—[PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/)—sont également prises en charge.
{{% /alert %}}

> **Remarque :** Lors de l'exportation vers PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une seule figure. Les éléments de chemin individuels ne sont pas conservés comme contenu séparé et peuvent être marqués comme artefacts ; le texte alternatif est fourni uniquement pour la figure entière.

## **FAQ**

**Puis-je convertir plusieurs fichiers PowerPoint en PDF en masse ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion programmatiquement.

**Est-il possible de protéger par mot de passe le PDF converti ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour définir un mot de passe et spécifier les autorisations d'accès pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la méthode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées dans le PDF résultant.

**Aspose.Slides peut-il maintenir une haute qualité d'image dans le PDF ?**

Oui, vous pouvez contrôler la qualité des images en utilisant des méthodes telles que [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) et [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) dans la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) afin d'assurer des images de haute qualité dans votre PDF.

**Aspose.Slides prend-il en charge les normes de conformité PDF/A ?**

Oui, Aspose.Slides vous permet d'exporter des PDF conformes à diverses normes, dont PDF/A1a, PDF/A1b et PDF/UA, garantissant que vos documents répondent aux exigences d'accessibilité et d'archivage.

## **Ressources supplémentaires**

- [Documentation Aspose.Slides pour C++](/slides/fr/cpp/)
- [Référence API Aspose.Slides pour C++](https://reference.aspose.com/slides/cpp/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)