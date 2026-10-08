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
- pièce jointe
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "Convertir PowerPoint PPT/PPTX en PDF de haute qualité et consultables en C++ avec Aspose.Slides, grâce à des exemples de code rapides et des options de conversion avancées."
---
## **Aperçu**

Convertir les présentations PowerPoint (PPT, PPTX, ODP, etc.) au format PDF en C++ offre plusieurs avantages, notamment la compatibilité sur différents appareils et la preservation de la mise en page et du formatage de votre présentation. Ce guide montre comment convertir des présentations en documents PDF, utiliser diverses options pour contrôler la qualité des images, inclure les diapositives masquées, proteger les fichiers PDF par mot de passe, detecter les substitutions de polices, sélectionner des diapositives spécifiques pour la conversion et appliquer des normes de conformité aux documents de sortie.

## **Conversions de PowerPoint en PDF**

Avec Aspose.Slides, vous pouvez convertir des présentations dans les formats suivants en PDF :

* **PPT**
* **PPTX**
* **ODP**

Pour convertir une présentation en PDF, passez le nom du fichier en argument à la classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) et puis enregistrez la présentation au format PDF a l'aide de la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/). La classe [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) expose la méthode [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) qui est généralement utilisee pour convertir une presentation en PDF.

{{% alert color="info" title="Note" %}}
Aspose.Slides pour C++ insere ses informations d'API et le numero de version dans les documents de sortie. Par exemple, lors de la conversion d'une presentation en PDF, Aspose.Slides remplit le champ Application avec "*Aspose.Slides*" et le champ PDF Producer avec une valeur sous la forme "*Aspose.Slides v XX.XX*". **Remarque** que vous ne pouvez pas demander a Aspose.Slides de modifier ou de supprimer ces informations des documents de sortie.
{{% /alert %}}

Aspose.Slides vous permet de convertir :

* Des presentations entieres en PDF
* Des diapositives specifiques d'une presentation en PDF

Aspose.Slides exporte les presentations au format PDF, en veillant a ce que les PDF resultants correspondent etroitement aux presentations d'origine. Les elements et attributs sont renders avec precision lors de la conversion, notamment :

* Images
* Zones de texte et formes
* Mise en forme du texte
* Mise en forme des paragraphes
* Hyperliens
* En-tetes et pieds de page
* Puces
* Tableaux

## **Convertir PowerPoint en PDF**

Le processus de conversion standard de PowerPoint en PDF utilise les options par defaut. Dans ce cas, Aspose.Slides tente de convertir la presentation fournie en PDF en utilisant des parametres optimaux aux niveaux de qualite maximale.

L'exemple suivant charge une presentation et enregistre toutes les diapositives visibles au format PDF en utilisant les parametres d'exportation par defaut.

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

{{% alert color="info" title="Note" %}}
Aspose propose un convertisseur en ligne gratuit [**convertisseur PowerPoint en PDF**](https://products.aspose.app/slides/conversion/ppt-to-pdf) qui montre le processus de conversion de presentation en PDF. Vous pouvez executer un test avec ce convertisseur pour une implementation en direct de la procedure descrite ici.
{{% /alert %}}

## **Convertir PowerPoint en PDF avec Options**

Aspose.Slides fournit des options personnalisees — des proprietes de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) — qui vous permettent de personnaliser le PDF resultant, de verrouiller le PDF avec un mot de passe ou de specifier comment le processus de conversion doit se derouler.

### **Convertir PowerPoint en PDF avec Options Personnalisees**

En utilisant des options de conversion personnalisees, vous pouvez definir le reglage de qualite prefere pour les images raster, specifier la facon dont les metafichiers doivent etre traites, definir un niveau de compression pour le texte, configurer le DPI pour les images, etc.

L'exemple suivant exporte une presentation au format PDF 1.5 avec une qualite JPEG reglée a 90, une resolution d'image de 300 DPI, les metafichiers enregistres en PNG et une compression de texte Flate.

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

### **Conserver les fichiers OLE integres comme pieces jointes PDF**

Si une presentation contient un classeur Excel integre, vous pouvez souhaiter que les destinataires du PDF accedent aux donnees du classeur ainsi qu'aux diapositives. Appelez [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) avec `true` pour conserver les fichiers OLE integres comme pieces jointes dans le PDF resultant.

La valeur par defaut est `false` : l'image ou l'icone d'aperçu de l'objet OLE est rendue sur la page PDF, mais son fichier integre n'est pas inclus en tant que piece jointe. Definir l'option sur `true` ajoute egalement les donnees du fichier. L'aperçu reste une representation visuelle ; la piece jointe permet aux destinataires d'ouvrir ou d'enregistrer le fichier integre separement. L'objet OLE ne devient pas une feuille de calcul Excel interactive sur la page PDF.

L'exemple suivant charge une presentation contenant deja un classeur Excel integre et l'exporte en PDF avec le classeur attache.

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

Pour verifier le resultat :

1. Ouvrez le PDF exporte dans un visualiseur qui prend en charge les pieces jointes, tel qu'Adobe Acrobat Reader.
2. Ouvrez le panneau **Pieces jointes** du visualiseur et localisez le classeur integre.
3. Enregistrez la piece jointe et ouvrez-la dans Excel pour examiner ses donnees, ou ouvrez-la directement si le visualiseur le permet. L'aperçu sur la page PDF est separe du fichier attache.

{{% alert color="info" title="Note" %}}
Les normes PDF/A imposent des restrictions sur les pieces jointes : PDF/A-1 interdit les fichiers integres, PDF/A-2 autorise uniquement les pieces jointes PDF/A, et PDF/A-3 autorise d'autres types de fichiers, y compris les classeurs Excel. Il s'agit d'exigences des normes, et non de restrictions propres a Aspose.Slides. Cet exemple utilise le parametre de conformite PDF par defaut et ne montre pas d'export PDF/A.
{{% /alert %}}

### **Convertir PowerPoint en PDF avec Diapositives Masquees**

Si une presentation contient des diapositives masqueees, vous pouvez utiliser la methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masqueees en tant que pages dans le PDF resultant.

L'exemple suivant exporte une presentation en PDF, en incluant les eventuelles diapositives masqueees.

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

### **Convertir PowerPoint en PDF protege par mot de passe**

L'exemple suivant exporte une presentation en PDF qui necessite le mot de passe `password` pour l'ouvrir. Les autorisations d'acces autorisent l'impression, y compris l'impression de haute qualite.

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

### **Detecter les Substitutions de Polices**

Aspose.Slides fournit la methode [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/), vous permettant de detecter les substitutions de police lors du processus de conversion de presentation en PDF.

L'exemple suivant exporte une presentation en PDF et affiche les avertissements de substitution de police dans la console. Un avertissement est affiche uniquement lorsqu'une police indisponible est substituee lors de l'exportation.

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

{{% alert color="info" title="Note" %}}
Pour plus d'informations sur la substitution de polices, consultez l'article [Font Substitution](/slides/fr/cpp/font-substitution/).
{{% /alert %}}

### **Gerer les Polices sans Variante Grasse Dediee**

Une presentation peut appliquer le format gras a du texte meme si sa police ne possede pas de variante grasse dediee. Le texte peut néanmoins apparaitre en gras grace a un gras synthetique, qui epaisseur artificiellement les glyphes normaux. Si ce texte semble trop lourd ou differe de l'apparence souhaitee dans le PDF, essayez d'appeler [PdfOptions::set_RasterizeUnsupportedFontStyles](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_rasterizeunsupportedfontstyles/) avec `true`. Cette option rend le texte concerne sous forme de bitmap lors de l'export PDF et peut améliorer son apparence pour certaines polices. Sa valeur par defaut est `false`.

La presentation d'exemple contient deux zones de texte : l'une avec du texte normal et l'autre avec un format gras applique a la meme police, qui n'a pas de variante grasse dediee. L'exemple suivant charge la presentation, active la rasterisation des styles de police non pris en charge, et l'exporte en PDF :

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

Les aperçus suivants montrent la sortie desactivee et la sortie activee. Dans cet exemple, le texte en gras a des traits plus epais avec l'option desactivee. Avec l'option activee, ses traits sont plus legers ; le texte normal reste inchange. Comparez les resultats avant de choisir le reglage pour votre presentation.

| Option desactivee (`false`, la valeur par défaut) | Option activee (`true`) |
|---|---|
| ![PDF with unsupported font style rasterization disabled](unsupported-bold-disabled.png) | ![PDF with unsupported font style rasterization enabled](unsupported-bold-enabled.png) |

Dans cet exemple, activer l'option transforme uniquement le texte gras en bitmap : il ne peut pas etre selectionne, copie ou recherche comme texte sans OCR, et ses bords apparaissent plus doux a 800% de zoom. Le texte normal reste rechercheable. Avec l'option desactivee, les deux chaines restent du texte.

Cette option rasterise le texte formaté en gras lorsque sa police n'a pas de variante grasse dediee. [Font substitution](/slides/fr/cpp/font-substitution/) selectionne plutot une autre police lorsque l'originale n'est pas disponible.

## **Convertir des Diapositives Selectionnees de PowerPoint en PDF**

L'exemple suivant exporte les diapositives 1 et 3 d'une presentation en PDF. Les numeros de diapositives dans ce tableau sont indexes a partir de 1, et la presentation d'entree doit contenir au moins trois diapositives.

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

## **Convertir PowerPoint en PDF avec Taille de Diapositive Personnalisee**

L'exemple suivant copie la premiere diapositive d'une presentation dans une nouvelle presentation avec une taille de diapositive de 612 x 792 points (8,5 x 11 pouces). Il redimensionne le contenu de la diapositive pour l'adapter et exporte la diapositive unique en PDF.

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

## **Convertir PowerPoint en PDF en Vue des Notes de Diapositive**

L'exemple suivant exporte une presentation en PDF, en plaçant les notes du presentateur de chaque diapositive sous la diapositive. Utilisez une presentation contenant des notes du presentateur pour voir le resultat.

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

## **Accessibilite et Normes de Conformite pour le PDF**

Aspose.Slides vous permet d'utiliser une procedure de conversion conforme aux [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html). Vous pouvez exporter un document PowerPoint en PDF en utilisant l'une de ces normes de conformité : **PDF/A1a**, **PDF/A1b** et **PDF/UA**.

Ce code C++ montre un processus de conversion PowerPoint en PDF qui genere plusieurs PDF selon differentes normes de conformite :

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

{{% alert color="info" title="Note" %}}
Aspose.Slides prend en charge les operations de conversion PDF, vous permettant de convertir des fichiers PDF vers des formats de fichier populaires. Vous pouvez realiser les conversions [PDF to HTML](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/) et [PDF to PNG](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/). D'autres operations de conversion PDF vers des formats specialises — [PDF to SVG](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), et [PDF to XML](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) — sont egalement prises en charge.
{{% /alert %}}

> **Remarque :** Lors de l'exportation en PDF/UA, Aspose.Slides traite les graphiques complexes tels que SmartArt, les graphiques et les formules comme une figure unique. Les elements de chemin individuels ne sont pas conserves comme contenu separe et peuvent etre marques comme artefacts ; le texte alternatif est fourni uniquement pour la figure entiere.

## **FAQ**

**Puis-je convertir plusieurs fichiers PowerPoint en PDF en lot ?**

Oui, Aspose.Slides prend en charge la conversion par lots de plusieurs fichiers PPT ou PPTX en PDF. Vous pouvez parcourir vos fichiers et appliquer le processus de conversion par programme.

**Est-il possible de proteger par mot de passe le PDF converti ?**

Oui. Utilisez la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour definir un mot de passe et definir les autorisations d'acces pendant le processus de conversion.

**Comment inclure les diapositives masquées dans le PDF ?**

Utilisez la methode [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour inclure les diapositives masquées dans le PDF resultante.

**Aspose.Slides peut-il maintenir une haute qualite d'image dans le PDF ?**

Oui, vous pouvez controler la qualite des images en utilisant des methodes telles que [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) et [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) de la classe [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) pour garantir des images de haute qualite dans votre PDF.

**Aspose.Slides prend-il en charge les normes de conformite PDF/A ?**

Oui, Aspose.Slides vous permet d'exporter des PDF conformes a diverses normes, notamment PDF/A1a, PDF/A1b et PDF/UA, assurant que vos documents repondent aux exigences d'accessibilite et d'archivage.

## **Ressources supplementaires**

- [Documentation Aspose.Slides pour C++](/slides/fr/cpp/)
- [Reference API Aspose.Slides pour C++](https://reference.aspose.com/slides/cpp/)
- [Convertisseurs en ligne gratuits Aspose](https://products.aspose.app/slides/conversion)