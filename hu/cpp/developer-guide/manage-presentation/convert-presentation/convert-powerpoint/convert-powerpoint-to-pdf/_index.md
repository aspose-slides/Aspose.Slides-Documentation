---
title: "PPT és PPTX konvertálása PDF-re C++-ban [Haladó funkciók beépítve]"
linktitle: "PowerPoint PDF-re"
type: docs
weight: 40
url: /hu/cpp/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint konvertálása"
- "bemutató konvertálása"
- "PowerPoint PDF-re"
- "bemutató PDF-re"
- "PPT PDF-re"
- "PPT konvertálása PDF-re"
- "PPTX PDF-re"
- "PPTX konvertálása PDF-re"
- "PowerPoint mentése PDF-ként"
- "PPT mentése PDF-ként"
- "PPTX mentése PDF-ként"
- "PPT exportálása PDF-be"
- "PPTX exportálása PDF-be"
- "melléklet"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "C++"
- "Aspose.Slides"
description: "PowerPoint PPT/PPTX konvertálása kiváló minőségű, kereshető PDF-ekre C++-ban az Aspose.Slides használatával, gyors kódrészletekkel és haladó konvertálási beállításokkal."
---
## **Áttekintés**

PowerPoint bemutatók (PPT, PPTX, ODP stb.) PDF formátumba konvertálása C++-ban számos előnyt kínál, többek között a különböző eszközök közötti kompatibilitást és a bemutató elrendezésének és formázásának megőrzését. Ez az útmutató bemutatja, hogyan konvertálhatók a bemutatók PDF dokumentumokká, hogyan használhatók különféle lehetőségek a képek minőségének szabályozására, hogyan vehetők bele a rejtett diák, hogyan védhetők jelszóval a PDF fájlok, hogyan lehet észlelni a betűkészlet-helyettesítéseket, hogyan választhatók ki konkrét diák a konvertáláshoz, és hogyan alkalmazhatók megfelelőségi szabványok a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides segítségével a következő formátumú bemutatókat konvertálhatja PDF-be:

* **PPT**
* **PPTX**
* **ODP**

A bemutató PDF-be konvertálásához adja át a fájl nevét argumentumként a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztálynak, majd mentse a bemutatót PDF-ként a [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) metódussal. A [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztály elérhetővé teszi a [Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) metódust, amelyet általában a bemutató PDF-be konvertálásához használnak.

{{% alert color="info" title="Note" %}}
Az Aspose.Slides for C++ a kimeneti dokumentumokba beilleszti az API-információkat és a verziószámot. Például, amikor egy bemutatót PDF-be konvertál, az Aspose.Slides az Application (alkalmazás) mezőt "*Aspose.Slides*" értékkel, a PDF Producer mezőt pedig "*Aspose.Slides v XX.XX*" formában tölti ki. **Megjegyzés**, hogy nem adhatja meg az Aspose.Slides számára, hogy módosítsa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.
{{% /alert %}}

Az Aspose.Slides lehetővé teszi a konvertálást:

* Teljes bemutatók PDF-be
* Kijelölt diák egy bemutatóból PDF-be

Az Aspose.Slides a bemutatókat PDF-be exportálja, biztosítva, hogy a létrejövő PDF-ek szorosan megegyezzenek az eredeti bemutatókkal. Az elemek és attribútumok pontosan kerülnek renderelésre a konvertálás során, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejlécek és láblécek
* Felsorolások
* Táblázatok

## **PowerPoint PDF konvertálása**

Az alapértelmezett PowerPoint-PDF konverziós folyamat alapbeállításokat használ. Ebben az esetben az Aspose.Slides a megadott bemutatót a legjobb beállításokkal, a legmagasabb minőségi szinteken próbálja PDF-be konvertálni.

A következő példa betölt egy bemutatót, és az alapértelmezett exportbeállításokkal menti az összes látható diát PDF-be.

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
Az Aspose ingyenes online [**PowerPoint to PDF konverter**](https://products.aspose.app/slides/conversion/ppt-to-pdf) biztosít, amely bemutatja a bemutató PDF-be konvertálási folyamatát. Tesztet futtathat ezzel a konverterrel, hogy élőben lássa a leírt eljárást.
{{% /alert %}}

## **PowerPoint PDF konvertálása beállításokkal**

Az Aspose.Slides egyedi beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztályban—biztosít, amelyekkel testre szabhatja a létrehozott PDF-et, jelszóval zárolhatja, vagy meghatározhatja a konvertálási folyamat menetét.

### **PowerPoint PDF konvertálása egyedi beállításokkal**

Egyedi konvertálási beállítások használatával meghatározhatja a raszteres képek kívánt minőségét, megadhatja, hogyan kezelje a metafájlokat, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI értékét, és további lehetőségeket.

A következő példa egy bemutatót exportál PDF 1.5 formátumba, JPEG minőséget 90-re, kép felbontást 300 DPI-re, a metafájlokat PNG-ként menti, és Flate szövegtömörítést használ.

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

### **Beágyazott OLE fájlok megőrzése PDF mellékletként**

Ha egy bemutató beágyazott Excel munkafüzetet tartalmaz, előfordulhat, hogy a PDF-fogadók szeretnék elérni a munkafüzet adatait, valamint megtekinteni a diákot. Hívja a [PdfOptions::set_IncludeOleData](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_includeoledata/) metódust `true` értékkel, hogy a beágyazott OLE fájlok a kimeneti PDF-ben mellékletként megmaradjanak.

Az alapértelmezett érték `false`: az OLE objektum előnézeti képe vagy ikonja megjelenik a PDF oldalon, de a beágyazott fájl nem kerül mellékletként. Ha az opciót `true`-ra állítja, a fájl adatai is mellékletként kerülnek. Az előnézet vizuális ábrázolás marad; a melléklet lehetővé teszi a fogadók számára, hogy külön nyissák vagy mentsék a beágyazott fájlt. Az OLE objektum nem alakul interaktív Excel munkalappá a PDF oldalon.

A következő példa betölt egy olyan bemutatót, amely már tartalmaz beágyazott Excel munkafüzetet, és PDF-be exportálja azt a munkafüzettel mellékletként.

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

Az eredmény ellenőrzéséhez:

1. Nyissa meg az exportált PDF-et egy olyan megjelenítőben, amely támogatja a fájl mellékleteket, például az Adobe Acrobat Readerben.
2. Nyissa meg a megjelenítő **Attachments** paneljét, és keresse meg a beágyazott munkafüzetet.
3. Mentse a mellékletet, és nyissa meg Excelben az adatok ellenőrzéséhez, vagy közvetlenül nyissa meg, ha a megjelenítő engedélyezi. Az előnézet a PDF oldalon különálló a melléklettől.

{{% alert color="info" title="Note" %}}
A PDF/A szabványok korlátozásokat vezetnek be a mellékletekre: a PDF/A-1 tiltja a beágyazott fájlokat, a PDF/A-2 csak PDF/A mellékleteket engedélyez, a PDF/A-3 pedig más fájltípusok, köztük az Excel munkafüzetek használatát engedélyezi. Ezek a szabványok követelményei, nem az Aspose.Slides-specifikus korlátozások. Ez a példa az alapértelmezett PDF megfelelőségi beállítást használja, és nem mutat PDF/A exportot.
{{% /alert %}}

### **PowerPoint PDF konvertálása rejtett diák esetén**

Ha egy bemutató rejtett diákat tartalmaz, a [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztályból használhatja, hogy a rejtett diák is megjelenjenek az eredményül kapott PDF oldalak között.

A következő példa egy bemutatót exportál PDF-be, beleértve minden rejtett diát.

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

### **PowerPoint PDF konvertálása jelszóval védett PDF-be**

A következő példa egy bemutatót exportál olyan PDF-be, amely megnyitásához a `password` jelszó szükséges. A hozzáférési engedélyek lehetővé teszik a nyomtatást, beleértve a magas minőségű nyomtatást.

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

### **Betűkészlet helyettesítések felismerése**

Az Aspose.Slides a [set_WarningCallback](https://reference.aspose.com/slides/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metódust a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztály alatt biztosítja, amely lehetővé teszi a betűkészlet helyettesítések észlelését a bemutató PDF-be konvertálása során.

A következő példa egy bemutatót exportál PDF-be, és a konzolra írja ki a betűkészlet helyettesítési figyelmeztetéseket. Figyelmeztetés csak akkor jelenik meg, ha egy nem elérhető betűkészlet helyettesítésre kerül az export során.

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
A betűkészlet helyettesítésről további információkért tekintse meg a [Font Substitution](/slides/hu/cpp/font-substitution/) cikket.
{{% /alert %}}

## **Kijelölt diák konvertálása PowerPointból PDF-be**

A következő példa a bemutatóból az 1. és 3. diát exportálja PDF-be. A tömbben szereplő diaszámok egy-alapúak, és a bemeneti bemutatónak legalább három diát kell tartalmaznia.

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

## **PowerPoint PDF konvertálása egyedi dia mérettel**

A következő példa átmásolja a bemutató első diáját egy új bemutatóba, amelynek a dia mérete 612 × 792 pont (8,5 × 11 hüvelyk). A dia tartalmát átméretezi, hogy illeszkedjen, és a egyetlen diát PDF-be exportálja.

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

## **PowerPoint PDF konvertálása megjegyzés dia nézetben**

A következő példa egy bemutatót exportál PDF-be, minden dia előadói megjegyzéseit a dia alá helyezve. Használjon olyan bemutatót, amely tartalmaz előadói megjegyzéseket, hogy láthassa az eredményt.

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

## **PDF hozzáférhetőségi és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konvertálási eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) irányelveinek. A PowerPoint dokumentumot PDF-be exportálhatja a következő megfelelőségi szabványok bármelyikével: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a C++ kód bemutat egy PowerPoint-PDF konverziós folyamatot, amely különböző megfelelőségi szabványok alapján több PDF-et állít elő:

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
Az Aspose.Slides támogatja a PDF konvertálási műveleteket, lehetővé téve a PDF fájlok átalakítását népszerű formátumokra. Végrehajthat [PDF HTML-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-html/), [PDF képre](https://products.aspose.com/slides/cpp/conversion/pdf-to-image/), [PDF JPG-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-jpg/), és [PDF PNG-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-png/) konverziókat. Más, speciális formátumokra történő PDF konvertálások – [PDF SVG-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-svg/), [PDF TIFF-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-tiff/), és [PDF XML-re](https://products.aspose.com/slides/cpp/conversion/pdf-to-xml/) – szintén támogatottak.
{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt-ot, diagramokat és képleteket egyetlen ábraként kezeli. Az egyedi útvonal elemek nem maradnak meg különálló tartalomként, és esetleg artefaktként lesznek jelölve; alternatív szöveg csak az egész ábrához kerül biztosításra.

## **GYIK**

**Több PowerPoint fájlt konvertálhatok egyszerre PDF-be?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt PDF-re konvertálását. A fájlokon programozottan iterálhat, és alkalmazhatja a konvertálási folyamatot.

**Lehetőség van a konvertált PDF jelszóval védésére?**

Igen. Használja a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési engedélyek meghatározásához a konvertálási folyamat során.

**Hogyan tudom a rejtett diákokat belefoglalni a PDF-be?**

Használja a [set_ShowHiddenSlides](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztályban, hogy a rejtett diák belekerüljenek a létrehozott PDF-be.

**Az Aspose.Slides képes magas képi minőséget biztosítani a PDF-ben?**

Igen, a képek minőségét szabályozhatja úgy, mint például a [set_JpegQuality](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_jpegquality/) és a [set_SufficientResolution](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/set_sufficientresolution/) metódusok használatával a [PdfOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/pdfoptions/) osztályban, hogy biztosítsa a magas minőségű képeket a PDF-ben.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi, hogy olyan PDF-eket exportáljon, amelyek megfelelnek különböző szabványoknak, beleértve a PDF/A1a, PDF/A1b és PDF/UA szabványokat, ezáltal biztosítva, hogy dokumentumai megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides C++ dokumentáció](/slides/hu/cpp/)
- [Aspose.Slides C++ API referenciája](https://reference.aspose.com/slides/cpp/)
- [Aspose ingyenes online konverterek](https://products.aspose.app/slides/conversion)