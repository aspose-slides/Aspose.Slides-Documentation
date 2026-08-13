---
title: PPT és PPTX konvertálása PDF‑be C++‑ban [Haladó funkciókkal]
linktitle: PowerPoint PDF‑re
type: docs
weight: 40
url: /hu/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint PDF‑re
- prezentáció PDF‑re
- PPT PDF‑re
- PPT konvertálása PDF‑re
- PPTX PDF‑re
- PPTX konvertálása PDF‑re
- PowerPoint mentése PDF‑ként
- PPT mentése PDF‑ként
- PPTX mentése PDF‑ként
- PPT exportálása PDF‑be
- PPTX exportálása PDF‑be
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, kereshető PDF‑ekre C++‑ban az Aspose.Slides használatával, gyors kódrészletekkel és haladó konverziós beállításokkal."
---
## **Áttekintés**

A PowerPoint előadások (PPT, PPTX, ODP stb.) C++-ban PDF formátumba konvertálása több előnnyel jár, köztük különböző eszközök közti kompatibilitással és az előadás elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertáljunk előadásokat PDF dokumentumokká, hogyan használjunk különböző beállításokat a képminőség szabályozásához, hogyan vegyük bele a rejtett diákat, hogyan védjünk jelszóval PDF fájlokat, hogyan észleljük a betűkészlethelyettesítéseket, hogyan válasszunk ki konkrét diákot a konvertáláshoz, és hogyan alkalmazzunk megfelelőségi szabványokat a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumú előadásokat konvertálhatja PDF‑be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑re konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a `Save` metódussal. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály a `Save` metódust biztosítja, amelyet általában a prezentáció PDF‑re konvertálására használnak.

{{%  alert title="NOTE"  color="warning"   %}} 
Az Aspose.Slides for C++ a kimeneti dokumentumokba beilleszti az API információkat és a verziószámot. Például prezentáció PDF‑re konvertálásakor az Aspose.Slides az Application mezőt "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig "*Aspose.Slides v XX.XX*" formában tölti ki. **Megjegyzés** hogy nem adható meg az Aspose.Slides számára, hogy módosítsa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.
{{% /alert %}}

Az Aspose.Slides lehetővé teszi:

* Teljes prezentációk PDF‑re konvertálását
* Konkrét diák PDF‑re konvertálását

Az Aspose.Slides exportálja a prezentációkat PDF‑be, biztosítva, hogy a kapott PDF‑ek szorosan megfeleljenek az eredeti előadásoknak. Az elemek és attribútumok pontosan megjelennek a konverzió során, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és láblécek
* Felsorolások
* Táblázatok

## **PowerPoint PDF‑re konvertálása**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapbeállításokat használja. Ebben az esetben az Aspose.Slides a megadott prezentációt a legoptimálisabb beállításokkal, maximális minőségi szinten konvertálja PDF‑be.

Ez a C++ kód megmutatja, hogyan konvertálhat egy prezentációt (PPT, PPTX, ODP stb.) PDF‑be:

```c++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Save the presentation as a PDF.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="info"  %}} 
Az Aspose ingyenes online **[PowerPoint PDF konverter](https://products.aspose.app/slides/hu/conversion/ppt-to-pdf)**-t kínál, amely bemutatja a prezentáció‑PDF konverziós folyamatot. Tesztelheti ezt a konvertert egy élő megvalósításhoz.
{{% /alert %}}

## **PowerPoint PDF‑re konvertálás beállításokkal**

Az Aspose.Slides egyéni beállításokat biztosít a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban, amelyekkel testreszabhatja a kimeneti PDF‑et, jelszóval zárolhatja, vagy meghatározhatja a konverzió menetét.

### **PowerPoint PDF‑re konvertálás egyéni beállításokkal**

Egyéni konvertálási beállításokkal meghatározhatja a raszteres képek kívánt minőségét, szabályozhatja a metafájlok kezelését, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI‑jét és egyebeket.

Az alábbi kódrészlet bemutatja, hogyan konvertáljon PowerPoint előadást PDF‑be több egyéni beállítással:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfCompliance.h>
#include <Export/PdfOptions.h>
#include <Export/PdfTextCompression.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Beállítja a JPG képek minőségét.
pdfOptions->set_JpegQuality(90);

// Beállítja a képek DPI‑ját.
pdfOptions->set_SufficientResolution(300);

// Beállítja a metafájlok viselkedését.
pdfOptions->set_SaveMetafilesAsPng(true);

// Beállítja a szöveges tartalom tömörítési szintjét.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// Meghatározza a PDF megfelelőségi módot.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Mentse a prezentációt PDF dokumentumként.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint PDF‑re konvertálás rejtett diákkal**

Ha egy prezentáció rejtett diákot tartalmaz, a [set_ShowHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályból használhatja a rejtett diák PDF‑beli oldalakként való belefoglalásához.

Ez a C++ kód megmutatja, hogyan konvertálja a PowerPoint előadást PDF‑be rejtett diák befogadásával:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Hozzáadja a rejtett diákat.
pdfOptions->set_ShowHiddenSlides(true);

// Mentse a prezentációt PDF‑ként.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint PDF‑re konvertálás jelszóval védett PDF‑ként**

Ez a C++ kód bemutatja, hogyan konvertáljon egy PowerPoint előadást jelszóval védett PDF‑be a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály védelmi paraméterei segítségével:

```c++
#include <DOM/Presentation.h>
#include <Export/PdfAccessPermissions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Beállít egy PDF jelszót és hozzáférési jogosultságokat.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Mentse a prezentációt PDF‑ként.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Betűkészlethelyettesítések észlelése**

Az Aspose.Slides a [set_WarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban biztosítja, amely lehetővé teszi a betűkészlethelyettesítések észlelését a prezentáció‑PDF konverzió során.

Ez a C++ kód megmutatja, hogyan észlelhet betűkészlethelyettesítéseket:

```c++
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

// Figyelmeztető visszahívás megvalósítása.
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
    // Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Beállítja a figyelmeztető visszahívást a PDF beállításokban.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Mentse a prezentációt PDF‑ként.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);

    presentation->Dispose();

    return 0;
}
```

{{%  alert color="info"  %}} 
További információk a betűkészlethelyettesítésekhez kapcsolódó visszahívások fogadásáról a renderelés során a [Figyelmeztető visszahívások fogadása betűkészlethelyettesítéshez](/slides/hu/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) című oldalán találhatók.

További információk a betűkészlethelyettesítésről a [Betűkészlethelyettesítés](/slides/hu/cpp/font-substitution/) cikkben.
{{% /alert %}} 

## **PowerPoint PDF‑re konvertálása kiválasztott diákból**

Ez a C++ kód bemutatja, hogyan konvertáljon csak a PowerPoint előadás meghatározott diái közül PDF‑be:

```C++
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Beállítja a dia számok tömbjét.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Mentse a prezentációt PDF‑ként.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint PDF‑re konvertálása egyedi dia mérettel**

Ez a C++ kód bemutatja, hogyan konvertáljon egy PowerPoint előadást PDF‑be megadott dia mérettel:

```C++
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

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Létrehoz egy új prezentációt a módosított dia mérettel.
auto resizedPresentation = MakeObject<Presentation>();

// Beállítja az egyéni dia méretet.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Klónozza az első diát az eredeti prezentációból.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// Mentse a méretezett prezentációt PDF‑be jegyzetekkel.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint PDF‑re konvertálása jegyzetes diaszámban**

Ez a C++ kód bemutatja, hogyan konvertáljon egy PowerPoint előadást PDF‑be, amely tartalmazza a jegyzeteket:

```C++
#include <DOM/Presentation.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Beállítja a PDF beállításokat jegyzetelrendezéssel.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Mentse a prezentációt PDF‑be jegyzetekkel.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF‑hez kapcsolódó akadálymentességi és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) előírásainak. A PowerPoint dokumentumot a következő megfelelőségi szabványok bármelyikével exportálhatja PDF‑be: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a C++ kód több PDF‑et mutat be, amelyek különböző megfelelőségi szabványok alapján kerülnek előállításra:

```C++
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

{{% alert title="Note" color="warning" %}} 
Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF‑fájlok népszerű formátumokra történő átalakítását. Végrehajthatja a [PDF to HTML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-jpg/), és [PDF to PNG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-png/) konverziókat. Egyéb, speciális formátumokra történő PDF konverziók – [PDF to SVG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-tiff/), és [PDF to XML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-xml/) – szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálása esetén az Aspose.Slides a komplex grafikákat, például a SmartArt, diagramok és képletek egyetlen ábraként kezeli. Az egyedi útvonal elemek nem maradnak meg különálló tartalomként, és esetleg artefaktumnak minősülnek; az alternatív szöveg csak az egész ábrára vonatkozik.

## **GYIK**

### Konvertálhatok több PowerPoint fájlt egyszerre PDF‑be?

Igen, az Aspose.Slides támogatja a több PPT vagy PPTX fájl kötegelt konvertálását PDF‑be. Programozottan végigiterálhat a fájlokon, és alkalmazhatja a konverziós folyamatot.

### Lehet jelszóval védeni a konvertált PDF‑et?

Természetesen. A [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály segítségével beállíthat jelszót és hozzáférési engedélyeket a konverzió során.

### Hogyan vehetem fel a rejtett diákot a PDF‑be?

Használja a `set_ShowHiddenSlides` metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban, hogy a rejtett diák a kimeneti PDF‑ben is megjelenjenek.

### Az Aspose.Slides megtartja a magas képmagasságot a PDF‑ben?

Igen, a képminőséget a `set_JpegQuality` és a `set_SufficientResolution` metódusokkal szabályozhatja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban, biztosítva a magas minőségű képeket a PDF‑ben.

### Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?

Igen, az Aspose.Slides lehetővé teszi olyan PDF‑ek exportálását, amelyek megfelelnek a PDF/A1a, PDF/A1b és PDF/UA szabványoknak, ezáltal biztosítva a dokumentumok akadálymentességét és archiválhatóságát.

## **További források**

- [Aspose.Slides for C++ dokumentáció](/slides/hu/cpp/)
- [Aspose.Slides for C++ API referencia](https://reference.aspose.com/slides/hu/cpp/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/hu/conversion)