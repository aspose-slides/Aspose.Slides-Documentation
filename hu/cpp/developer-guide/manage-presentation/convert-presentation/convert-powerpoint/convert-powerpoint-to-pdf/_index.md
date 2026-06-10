---
title: PPT és PPTX konvertálása PDF-re C++-ban [Haladó funkciókkal]
linktitle: PowerPoint PDF-re
type: docs
weight: 40
url: /hu/cpp/convert-powerpoint-to-pdf/
keywords:
- PowerPoint konvertálása
- prezentáció konvertálása
- PowerPoint PDF-re
- prezentáció PDF-re
- PPT PDF-re
- PPT konvertálása PDF-re
- PPTX PDF-re
- PPTX konvertálása PDF-re
- PowerPoint mentése PDF-ként
- PPT mentése PDF-ként
- PPTX mentése PDF-ként
- PPT exportálása PDF-be
- PPTX exportálása PDF-be
- PDF/A1a
- PDF/A1b
- PDF/UA
- C++
- Aspose.Slides
description: "PowerPoint PPT/PPTX konvertálása magas minőségű, kereshető PDF-fájlokká C++-ban az Aspose.Slides használatával, gyors kódpéldákkal és haladó konverziós beállításokkal."
---
## **Áttekintés**

A PowerPoint‑prezentációk (PPT, PPTX, ODP stb.) PDF formátumba konvertálása C++‑ban több előnnyel jár, többek között a különböző eszközök közötti kompatibilitással és a prezentáció elrendezésének, formázásának megőrzésével. Ez az útmutató bemutatja, hogyan konvertálhatók a prezentációk PDF‑dokumentumokká, hogyan szabályozhatók a képminőség, hogyan lehet rejtett diákot belefoglalni, jelszóval védeni a PDF‑fájlokat, felismerni a betűkészlet‑helyettesítéseket, kiválasztani bizonyos diákot a konvertáláshoz, valamint hogyan alkalmazhatók megfelelőségi szabványok a kimeneti dokumentumokra.

## **PowerPoint → PDF átalakítások**

Az Aspose.Slides segítségével a következő formátumú prezentációkat konvertálhatja PDF‑be:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑be konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a `Save` metódussal. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály biztosítja a `Save` metódust, amelyet általában prezentációk PDF‑be konvertálására használnak.

{{%  alert title="NOTE"  color="warning"   %}} 

Az Aspose.Slides for C++ a kimeneti dokumentumokba beilleszti API‑információit és verziószámát. Például amikor egy prezentációt PDF‑be konvertál, az Aspose.Slides az Application mezőbe "*Aspose.Slides*"‑t, a PDF Producer mezőbe pedig "*Aspose.Slides v XX.XX*" formátumú értéket helyez. **Megjegyzés:** az Aspose.Slides nem módosítható vagy távolítható el ez az információ a kimeneti dokumentumokból.

{{% /alert %}}

Az Aspose.Slides lehetővé teszi a következőket:

* teljes prezentációk PDF‑be konvertálása
* adott diák PDF‑be konvertálása

Az Aspose.Slides a prezentációkat PDF‑be exportálja, biztosítva, hogy a létrehozott PDF‑ek szorosan egyezzenek az eredeti prezentációkkal. A konverzió során a következő elemek és attribútumok pontosan megjelennek:

* képek
* szövegdobozok és alakzatok
* szövegformázás
* bekezdésformázás
* hiperhivatkozások
* fejléc és lábléc
* felsorolások
* táblázatok

## **PowerPoint PDF‑re konvertálása**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapbeállításokat használja. Ebben az esetben az Aspose.Slides a megadott prezentációt a legmagasabb minőségi szinteken, optimális beállításokkal konvertálja PDF‑be.

Ez a C++ kód megmutatja, hogyan konvertálhat egy prezentációt (PPT, PPTX, ODP stb.) PDF‑be:

```c++
// Példányosítsa a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Mentse a prezentációt PDF-ként.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Az Aspose egy ingyenes online [**PowerPoint to PDF converter**](https://products.aspose.app/slides/hu/conversion/ppt-to-pdf) szolgáltatást kínál, amely bemutatja a prezentáció‑PDF konverziós folyamatot. Ezzel a konverterrel élőben tesztelheti a leírt eljárást.

{{% /alert %}}

## **PowerPoint PDF‑re konvertálása beállításokkal**

Az Aspose.Slides egyedi beállításokat (a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban) biztosít, amelyekkel testreszabhatja a kimeneti PDF‑et, jelszóval zárolhatja, vagy megadhatja, hogyan járjon el a konverzió során.

### **PowerPoint PDF‑re konvertálása egyedi beállításokkal**

Egyedi konverziós beállításokkal meghatározhatja a raszteres képek kívánt minőségét, a metafájlok kezelését, a szöveg tömörítési szintjét, a képek DPI‑ját és egyebeket.

Az alábbi kódrészlet bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt PDF‑be több egyedi beállítással.

```c++
// PdfOptions osztály példányosítása.
auto pdfOptions = MakeObject<PdfOptions>();

// JPG képek minőségének beállítása.
pdfOptions->set_JpegQuality(90);

// Képek DPI-beállítása.
pdfOptions->set_SufficientResolution(300);

// Metafájlok viselkedésének beállítása.
pdfOptions->set_SaveMetafilesAsPng(true);

// Szövegtartalom tömörítési szintjének beállítása.
pdfOptions->set_TextCompression(PdfTextCompression::Flate);

// PDF megfelelőségi mód definiálása.
pdfOptions->set_Compliance(PdfCompliance::Pdf15);

// Presentation osztály példányosítása, amely PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Mentse a prezentációt PDF-dokumentumként.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint PDF‑re konvertálása rejtett diák beépítésével**

Ha a prezentáció rejtett diákot tartalmaz, a [set_ShowHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályból használva belefoglalhatja a rejtett diákot a kimeneti PDF‑oldalak közé.

Ez a C++ kód megmutatja, hogyan konvertálhat egy PowerPoint‑prezentációt PDF‑be a rejtett diák beépítésével:

```c++
// A Presentation osztály példányosítása, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// A PdfOptions osztály példányosítása.
auto pdfOptions = MakeObject<PdfOptions>();

// Rejtett diák hozzáadása.
pdfOptions->set_ShowHiddenSlides(true);

// A prezentáció mentése PDF-ként.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint PDF‑re konvertálása jelszóval védett PDF‑ben**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt jelszóval védett PDF‑be a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály védelmi paramétereinek használatával:

```c++
// A Presentation osztály példányosítása, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// A PdfOptions osztály példányosítása.
auto pdfOptions = MakeObject<PdfOptions>();

// PDF jelszó és hozzáférési jogosultságok beállítása.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// A prezentáció mentése PDF-ként.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Betűkészlet‑helyettesítések felismerése**

Az Aspose.Slides a [set_WarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metódust biztosítja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályon, amely lehetővé teszi a betűkészlet‑helyettesítések észlelését a prezentáció‑PDF konverzió során.

Ez a C++ kód megmutatja, hogyan lehet felismerni a betűkészlet‑helyettesítéseket:

```c++
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
    // A Presentation osztály példányosítása, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Figyelmeztető visszahívás beállítása a PDF beállításokban.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // A prezentáció mentése PDF-ként.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

A betűkészlet‑helyettesítésekhez kapcsolódó visszahívások részleteiért tekintse meg a [Getting Warning Callbacks for Fonts Substitution](/slides/hu/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) cikket.

A betűkészlet‑helyettesítésekről további információk a [Font Substitution](/slides/hu/cpp/font-substitution/) oldalon találhatók.

{{% /alert %}} 

## **Kiválasztott diák PDF‑re konvertálása PowerPoint‑ból**

Ez a C++ kód bemutatja, hogyan konvertálhat csak bizonyos diákat egy PowerPoint‑prezentációból PDF‑be:

```C++
// A Presentation osztály példányosítása, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Diák számát tartalmazó tömb beállítása.
auto slides = MakeArray<int32_t>({ 1, 3 });

// A prezentáció mentése PDF-ként.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint PDF‑re konvertálása egyedi diamérettel**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt PDF‑be megadott diamérettel:

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

## **PowerPoint PDF‑re konvertálása jegyzet-diák nézetben**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint‑prezentációt PDF‑be, amely tartalmazza a jegyzeteket:

```C++
// A Presentation osztály példányosítása, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF beállítások konfigurálása jegyzetelrendezéssel.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// A prezentáció mentése jegyzetekkel ellátott PDF-be.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF hozzáférhetőségi és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi olyan konverziós eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) ajánlásainak. A PowerPoint‑dokumentumot bármelyik következő megfelelőségi szabvánnyal exportálhatja PDF‑be: **PDF/A1a**, **PDF/A1b** és **PDF/UA**.

Ez a C++ kód egy PowerPoint‑PDF konverziós folyamatot mutat be, amely különböző megfelelőségi szabványok alapján több PDF‑et hoz létre:

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

Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok népszerű formátumokra történő átalakítását. Végrehajthatja a [PDF to HTML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-jpg/), és [PDF to PNG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-png/) konverziókat. Más, speciális formátumokra irányuló PDF konverziók – [PDF to SVG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-tiff/), és [PDF to XML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-xml/) – szintén támogatottak.

{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt‑ot, diagramokat és képleteket egyetlen ábraként kezeli. Az egyéni útvonal elemek nem maradnak meg különálló tartalomként, és csupán ábrákként jelenhetnek meg; az alternatív szöveg csak az egész ábrához kerül.

## **GYIK**

**Több PowerPoint‑fájlt tudok egyszerre PDF‑be konvertálni?**

Igen, az Aspose.Slides támogatja a több PPT vagy PPTX fájl kötegelt konvertálását PDF‑be. Programból bejárhatja a fájlokat, és alkalmazhatja a konverziós folyamatot.

**Lehetőség van a létrehozott PDF‑et jelszóval védeni?**

Természetesen. A [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály használatával beállíthat jelszót és hozzáférési jogosultságokat a konverzió során.

**Hogyan lehet a rejtett diákat belefoglalni a PDF‑be?**

Használja a `set_ShowHiddenSlides` metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban a rejtett diák kimeneti PDF‑be való beépítéséhez.

**Az Aspose.Slides képes magas képminőséget biztosítani a PDF‑ben?**

Igen, a képminőséget a `set_JpegQuality` és a `set_SufficientResolution` módszerekkel szabályozhatja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban, így biztosíthatja a PDF‑ben a magas minőségű képeket.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi PDF‑ek exportálását, amelyek megfelelnek különböző szabványoknak, többek között PDF/A1a, PDF/A1b és PDF/UA, ezáltal biztosítva a dokumentumok hozzáférhetőségét és archiválási követelményeit.

## **További források**

- [Aspose.Slides for C++ Documentation](/slides/hu/cpp/)
- [Aspose.Slides for C++ API Reference](https://reference.aspose.com/slides/hu/cpp/)
- [Aspose Free Online Converters](https://products.aspose.app/slides/hu/conversion)