---
title: "PPT és PPTX konvertálása PDF-re C++-ban [Haladó funkciók beépítve]"
linktitle: "PowerPoint PDF-re"
type: docs
weight: 40
url: /hu/cpp/convert-powerpoint-to-pdf/
keywords:
- "PowerPoint konvertálás"
- "prezentáció konvertálása"
- "PowerPoint PDF-re"
- "prezentáció PDF-re"
- "PPT PDF-re"
- "PPT konvertálása PDF-re"
- "PPTX PDF-re"
- "PPTX konvertálása PDF-re"
- "PowerPoint mentése PDF-ként"
- "PPT mentése PDF-ként"
- "PPTX mentése PDF-ként"
- "PPT exportálása PDF-be"
- "PPTX exportálása PDF-be"
- "PDF/A1a"
- "PDF/A1b"
- "PDF/UA"
- "C++"
- "Aspose.Slides"
description: "Konvertálja a PowerPoint PPT/PPTX fájlokat magas minőségű, kereshető PDF-ekre C++-ban az Aspose.Slides használatával, gyors kódrészletekkel és haladó konverziós beállításokkal."
---
## **Áttekintés**

A PowerPoint‑prezentációk (PPT, PPTX, ODP stb.) PDF formátumba történő konvertálása C++‑ban több előnnyel jár, többek között kompatibilitással a különböző eszközök között, valamint a bemutató elrendezésének és formázásának megőrzésével. Ez az útmutató bemutatja, hogyan lehet a prezentációkat PDF‑dokumentumokká konvertálni, különböző beállításokkal szabályozni a képek minőségét, rejtett diákot belefoglalni, PDF‑fájlokat jelszóval védeni, betűkicseréket észlelni, meghatározott diákat kiválasztani a konvertáláshoz, és megfelelőségi szabványokat alkalmazni a kimeneti dokumentumokra.

## **PowerPoint PDF konverziók**

Az Aspose.Slides használatával a következő formátumú prezentációkat konvertálhatja PDF‑re:

* **PPT**
* **PPTX**
* **ODP**

A prezentáció PDF‑re konvertálásához adja át a fájlnevet argumentumként a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztálynak, majd mentse a prezentációt PDF‑ként a `Save` metódus használatával. A [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztály biztosítja a `Save` metódust, amelyet általában a prezentáció PDF‑re konvertálásához használnak.

{{%  alert title="NOTE"  color="warning"   %}} 

Az Aspose.Slides for C++ beilleszti API információit és verziószámát a kimeneti dokumentumokba. Például egy prezentáció PDF‑re konvertálásakor az Aspose.Slides a Application mezőt a „*Aspose.Slides*” értékkel, a PDF Producer mezőt pedig „*Aspose.Slides v XX.XX*” formában tölti ki. **Megjegyzés**, hogy nem adhatja meg az Aspose.Slidesnek, hogy módosítsa vagy eltávolítsa ezeket az információkat a kimeneti dokumentumokból.

{{% /alert %}}

Az Aspose.Slides lehetővé teszi a következők konvertálását:

* Teljes prezentációk PDF‑re
* Kijelölt diák egy prezentációból PDF‑re

Az Aspose.Slides a prezentációkat PDF‑be exportálja, biztosítva, hogy a létrejövő PDF‑ek szorosan megegyezzenek az eredeti prezentációkkal. Az elemek és attribútumok pontosan kerülnek renderelésre a konverzió során, többek között:

* Képek
* Szövegdobozok és alakzatok
* Szövegformázás
* Bekezdésformázás
* Hiperhivatkozások
* Fejléc és lábléc
* Feltűtések
* Táblázatok

## **PowerPoint PDF‑re konvertálása**

Az alapértelmezett PowerPoint‑PDF konverziós folyamat az alapértelmezett beállításokat használja. Ebben az esetben az Aspose.Slides a lehető legjobb beállításokkal és a legmagasabb minőségi szintekkel próbálja a megadott prezentációt PDF‑re konvertálni.

Ez a C++ kód megmutatja, hogyan konvertálhat egy prezentációt (PPT, PPTX, ODP stb.) PDF‑re:

```c++
// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.ppt");

// Mentse a prezentációt PDF-ként.
presentation->Save(u"PPT-to-PDF.pdf", SaveFormat::Pdf);

presentation->Dispose();
```

{{%  alert  color="primary"  %}} 

Az Aspose ingyenes online **PowerPoint PDF konvertert** kínál, amely bemutatja a prezentáció PDF‑re konvertálási folyamatát. A konverterrel tesztet végezhet, hogy élőben lássa a leírt eljárást.

{{% /alert %}}

## **PowerPoint PDF‑re konvertálás beállításokkal**

Az Aspose.Slides egyedi beállításokat—tulajdonságokat a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban—biztosít, amelyekkel testreszabhatja a létrehozott PDF‑et, jelszóval zárolhatja azt, vagy meghatározhatja a konverziós folyamat menetét.

### **PowerPoint PDF‑re konvertálás egyedi beállításokkal**

Egyedi konverziós beállítások használatával meghatározhatja a raszteres képek kívánt minőségi beállítását, megadhatja, hogyan kezelje a metafájlokat, beállíthatja a szöveg tömörítési szintjét, konfigurálhatja a képek DPI értékét, és egyebeket.

Az alábbi kódpélda bemutatja, hogyan konvertálhat egy PowerPoint prezentációt PDF‑re több egyedi beállítással.

```c++
// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Beállítja a JPG képek minőségét.
pdfOptions->set_JpegQuality(90);

// Beállítja a képek DPI értékét.
pdfOptions->set_SufficientResolution(300);

// Beállítja a metafájlok viselkedését.
pdfOptions->set_SaveMetafilesAsPng(true);

// Beállítja a szöveges tartalom szövegkompressziós szintjét.
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

Ha egy prezentáció rejtett diákot tartalmaz, használhatja a [set_ShowHiddenSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/set_showhiddenslides/) metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályból, hogy a rejtett diákat is oldalként belefoglalja a létrehozott PDF‑be.

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt PDF‑re, beleértve a rejtett diákat:

```c++
// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Hozzáadja a rejtett diákat.
pdfOptions->set_ShowHiddenSlides(true);

// Mentse a prezentációt PDF-ként.
presentation->Save(u"PowerPoint-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **PowerPoint PDF‑re konvertálás jelszóval védve**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt jelszóval védett PDF‑be a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály védelmi paramétereinek használatával:

```c++
// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Példányosítja a PdfOptions osztályt.
auto pdfOptions = MakeObject<PdfOptions>();

// Beállítja a PDF jelszót és a hozzáférési engedélyeket.
pdfOptions->set_Password(u"password");
pdfOptions->set_AccessPermissions(PdfAccessPermissions::PrintDocument | PdfAccessPermissions::HighQualityPrint);

// Mentse a prezentációt PDF-ként.
presentation->Save(u"PPTX-to-PDF.pdf", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

### **Betűkicserék észlelése**

Az Aspose.Slides a [set_WarningCallback](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/saveoptions/set_warningcallback/) metódust biztosítja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztály alatt, amely lehetővé teszi a betűkicserék észlelését a prezentáció PDF‑re konvertálás folyamata során.

Ez a C++ kód megmutatja, hogyan lehet betűkicseréket észlelni:

```c++
// A figyelmeztetési visszahívás megvalósítása.
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

    // Beállítja a figyelmeztetési visszahívást a PDF beállításokban.
    auto pdfOptions = MakeObject<PdfOptions>();
    pdfOptions->set_WarningCallback(MakeObject<FontSubstitutionHandler>());

    // Mentse a prezentációt PDF-ként.
    presentation->Save(u"output.pdf", SaveFormat::Pdf, pdfOptions);
    
    presentation->Dispose();

    return 0;
}
```

{{%  alert color="primary"  %}} 

További információért a betűkicserékhez kapcsolódó visszahívások fogadásáról a renderelés során, lásd a [Getting Warning Callbacks for Fonts Substitution](/slides/hu/cpp/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/) oldalt.

További információért a betűkicseréről, lásd a [Font Substitution](/slides/hu/cpp/font-substitution/) cikket.

{{% /alert %}} 

## **Kijelölt diák konvertálása PowerPointból PDF‑re**

Ez a C++ kód bemutatja, hogyan konvertálhat csak bizonyos diákat egy PowerPoint prezentációból PDF‑re:

```C++
// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"PowerPoint.pptx");

// Beállítja a diákszámok tömbjét.
auto slides = MakeArray<int32_t>({ 1, 3 });

// Mentse a prezentációt PDF-ként.
presentation->Save(u"PPTX-to-PDF.pdf", slides, SaveFormat::Pdf);

presentation->Dispose();
```

## **PowerPoint PDF‑re konvertálás egyedi dia mérettel**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt PDF‑re meghatározott dia mérettel:

```C++
auto slideWidth = 612;
auto slideHeight = 792;

// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// Új prezentáció létrehozása módosított diamérettel.
auto resizedPresentation = MakeObject<Presentation>();

// Egyedi diaméret beállítása.
resizedPresentation->get_SlideSize()->SetSize(slideWidth, slideHeight, SlideSizeScaleType::EnsureFit);

// Az eredeti prezentáció első diájának klónozása.
auto slide = presentation->get_Slide(0);
resizedPresentation->get_Slides()->InsertClone(0, slide);

// A méretezett prezentáció mentése jegyzetekkel ellátott PDF-be.
resizedPresentation->Save(u"PDF_with_notes.pdf", SaveFormat::Pdf);

resizedPresentation->Dispose();
presentation->Dispose();
```

## **PowerPoint PDF‑re konvertálás jegyzetdiák nézetben**

Ez a C++ kód bemutatja, hogyan konvertálhat egy PowerPoint prezentációt PDF‑re, amely tartalmazza a jegyzeteket:

```C++
// Példányosítja a Presentation osztályt, amely egy PowerPoint vagy OpenDocument fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"SelectedSlides.pptx");

// PDF beállítások konfigurálása jegyzetelrendezéssel.
auto notesOptions = MakeObject<NotesCommentsLayoutingOptions>();
notesOptions->set_NotesPosition(NotesPositions::BottomFull);
auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(notesOptions);

// Mentse a prezentációt jegyzetekkel ellátott PDF-be.
presentation->Save(u"PDF_with_notes.tiff", SaveFormat::Pdf, pdfOptions);

presentation->Dispose();
```

## **PDF hozzáférhetőség és megfelelőségi szabványok**

Az Aspose.Slides lehetővé teszi egy olyan konvertálási eljárás használatát, amely megfelel a [Web Content Accessibility Guidelines (**WCAG**)](https://www.w3.org/TR/WCAG-TECHS/pdf.html) szabványnak. A PowerPoint dokumentumot PDF‑re exportálhatja bármelyik következő megfelelőségi szabvány használatával: **PDF/A1a**, **PDF/A1b**, és **PDF/UA**.

Ez a C++ kód bemutat egy PowerPoint‑PDF konverziós folyamatot, amely különböző megfelelőségi szabványok alapján több PDF‑et hoz létre:

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

Az Aspose.Slides támogatja a PDF konverziós műveleteket, lehetővé téve a PDF fájlok konvertálását népszerű formátumokba. Végrehajthatja a [PDF to HTML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-html/), [PDF to image](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-image/), [PDF to JPG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-jpg/), és [PDF to PNG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-png/) konverziókat. Egyéb PDF konverziós műveletek speciális formátumokba—[PDF to SVG](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-svg/), [PDF to TIFF](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-tiff/), és [PDF to XML](https://products.aspose.com/slides/hu/cpp/conversion/pdf-to-xml/)—szintén támogatottak.

{{% /alert %}}

> **Megjegyzés:** PDF/UA exportálásakor az Aspose.Slides a komplex grafikákat, például a SmartArt, diagramok és képletek egyetlen ábraként kezeli. Az egyedi útvonal elemek nem maradnak meg különálló tartalomként, és jelölhetők artefaktként; az alternatív szöveg csak az egész ábrára vonatkozik.

## **FAQ**

**Konvertálhatok több PowerPoint fájlt egyszerre PDF‑re?**

Igen, az Aspose.Slides támogatja több PPT vagy PPTX fájl kötegelt konvertálását PDF‑re. A fájlokon ciklikusan végigjárhatja a konverziós folyamatot programozott módon.

**Lehet jelszóval védeni a konvertált PDF‑et?**

Természetesen. Használja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályt a jelszó beállításához és a hozzáférési jogok meghatározásához a konverziós folyamat során.

**Hogyan foglalhatom bele a rejtett diákat a PDF‑be?**

Használja a `set_ShowHiddenSlides` metódust a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban a rejtett diák eredményül kapott PDF‑be történő belefoglalásához.

**Az Aspose.Slides képes magas képminőséget fenntartani a PDF‑ben?**

Igen, a képminőséget szabályozhatja a [PdfOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/) osztályban található, például a `set_JpegQuality` és `set_SufficientResolution` metódusok használatával, hogy a PDF magas minőségű képeket tartalmazzon.

**Az Aspose.Slides támogatja a PDF/A megfelelőségi szabványokat?**

Igen, az Aspose.Slides lehetővé teszi, hogy a PDF‑ek olyan szabványoknak feleljenek meg, mint a PDF/A1a, PDF/A1b és PDF/UA, biztosítva, hogy a dokumentumok megfeleljenek a hozzáférhetőségi és archiválási követelményeknek.

## **További források**

- [Aspose.Slides for C++ dokumentáció](/slides/hu/cpp/)
- [Aspose.Slides for C++ API referencia](https://reference.aspose.com/slides/hu/cpp/)
- [Aspose ingyenes online konvertálók](https://products.aspose.app/slides/hu/conversion)