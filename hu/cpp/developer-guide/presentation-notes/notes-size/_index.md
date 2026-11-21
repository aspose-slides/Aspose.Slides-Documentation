---
title: Jegyzetoldal méretének és tájolásának módosítása C++-ban
linktitle: Jegyzetoldal mérete
type: docs
weight: 10
url: /hu/cpp/notes-size/
keywords:
- jegyzetoldal mérete
- jegyzet tájolás
- fekvő jegyzet
- álló jegyzet
- szórólap mérete
- PowerPoint
- bemutató
- PPT
- PPTX
- C++
- Aspose.Slides
description: "Olvassa és módosítsa a jegyzetoldal méreteit az Aspose.Slides C++-ban, váltsa át a tájolást, ellenőrizze a mentett méreteket, és exportálja a jegyzeteket vagy szórólapokat PDF-be és képekbe."
---
## **Áttekintés**

Használja a [Presentation::get_NotesSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_notessize/) a bemutató jegyzetoldal beállításainak eléréséhez. Egy [INotesSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotessize/) objektumot ad vissza, amelynek a [set_Size](https://reference.aspose.com/slides/hu/cpp/aspose.slides/inotessize/set_size/) metódusa állítja be a méreteket. Bár a jegyzetbeállítási objektum nem cserélhető le, a méretét módosíthatja.

A szélességet és magasságot **pontban** adják meg, 72 pont per hüvelyk. Például a 900 × 600 pont 12,5 × 8⅓ hüvelyknek felel meg. Ezek a beállítások a teljes bemutatóra vonatkoznak, nem egyetlen dia jegyzeteire.

| Beállítás | Cél |
| --- | --- |
| [Presentation::get_NotesSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_notessize/) | A jegyzetoldal méreteit és a szórólap exportáláshoz használt oldalméreteket szabályozza. |
| [Presentation::get_SlideSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_slidesize/) | A szokásos bemutató dia méreteit szabályozza az [ISlideSize](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/) segítségével. |

Az egyik beállítás módosítása nem változtatja meg automatikusan a másikat. A jegyzetoldal tájolásának módosítása szintén nem forgatja el a szokásos diát. Lásd a [Slide Size](/slides/hu/cpp/slide-size/) oldalt a szokásos diák átméretezéséhez.

Az alábbi példák egy meglévő `sample.pptx` fájlt használnak. Az export példáknál használjon egy bemutatót, amely legalább egy diához tartozó előadói jegyzetet tartalmaz. Minden példát önállóan futtathat.

## **Olvassa be a jegyzetoldal méretét és tájolását**

Olvassa be a szélességet és magasságot, és hasonlítsa össze őket a tájolás meghatározásához: a szélesebb oldal fekvő, a magasabb álló, az azonos méretek négyzetes oldalt jelentenek. Ez a példa a tényleges méreteket pontban írja ki, anélkül, hogy a szabványos papírméretet feltételezné.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();
auto orientation = String(u"Square");

if (size.get_Width() > size.get_Height())
    orientation = u"Landscape";
else if (size.get_Width() < size.get_Height())
    orientation = u"Portrait";

Console::WriteLine(u"Notes page: {0} x {1} points", size.get_Width(), size.get_Height());
Console::WriteLine(u"Orientation: {0}", orientation);
```

## **Váltás fekvő módra a papírméret megváltoztatása nélkül**

A tájolás csak módosításához cserélje fel a meglévő szélességet és magasságot. Ez megőrzi mindkét oldal hosszát, beleértve az egyedi papírméretét is. Az alábbi feltétel megakadályozza, hogy egy már fekvő oldal visszavonuljon álló módba, és egy négyzetes oldal változatlan maradjon.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto size = presentation->get_NotesSize()->get_Size();

if (size.get_Width() < size.get_Height())
    presentation->get_NotesSize()->set_Size(SizeF(size.get_Height(), size.get_Width()));

presentation->Save(u"landscape-notes.pptx", SaveFormat::Pptx);
```

Álló tájolás esetén használja ugyanezt a hozzárendelést, ha `size.get_Width() > size.get_Height()`. Ne helyettesítse A4 vagy Letter méretekkel, hacsak nem szeretné egyidejűleg megváltoztatni a papírméretet.

## **Egyedi jegyzetoldal méret beállítása és ellenőrzése**

Állítsa be mindkét méretet egyszerre, majd használja a [Presentation::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/save/) metódust a bemutató mentéséhez. Ez a példa egy 900 × 600 pontos fekvő oldalt állít be, PPTX-ként menti, majd újra megnyitja a mentett fájlt a mentett értékek ellenőrzéséhez. Az összehasonlítás 0,01 pont toleranciát enged meg a lebegőpontos értékeknél; ez nem garancia a pontosságra minden fájlformátumnál.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <cmath>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto expectedSize = SizeF(900, 600);
presentation->get_NotesSize()->set_Size(expectedSize);
presentation->Save(u"custom-notes.pptx", SaveFormat::Pptx);

auto reopened = MakeObject<Presentation>(u"custom-notes.pptx");
auto actualSize = reopened->get_NotesSize()->get_Size();
auto widthMatches = std::abs(actualSize.get_Width() - expectedSize.get_Width()) < 0.01f;
auto heightMatches = std::abs(actualSize.get_Height() - expectedSize.get_Height()) < 0.01f;
auto preserved = widthMatches && heightMatches;

Console::WriteLine(u"Stored notes page: {0} x {1} points", actualSize.get_Width(), actualSize.get_Height());
Console::WriteLine(u"Size preserved: {0}", preserved);
```

## **Jegyzetek és szórólapok exportálása**

Az oldalméretek határozzák meg a jegyzetek vagy szórólap elrendezések rendelkezésre álló területét. Nem aktiválják ezeket az elrendezéseket önmagukban: az export beállításait is konfigurálni kell. A szokásos dia exportálás továbbra is a dia méreteit használja.

### **Jegyzetek exportálása PDF-be és PNG-be**

Rendelje hozzá a [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notescommentslayoutingoptions/) a [PdfOptions::set_SlidesLayoutOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/pdfoptions/set_slideslayoutoptions/) metódushoz, hogy a jegyzetek megjelenjenek a PDF-ben. Ez a példa a jegyzetekkel ellátott első diát PNG-re is rendereli a [Slide::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/getimage/) és a [RenderingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/renderingoptions/) használatával.

A [BottomTruncated](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notespositions/) mód a jegyzeteket egy oldalon tartja; a nem elférő jegyzetek levágásra kerülhetnek. A PDF 900 × 600 pontos oldalakat használ. Az alább használt 1 × 1 képmérettel a PNG 900 × 600 képpont. A pontok az oldal geometriáját írják le; a képpontok a raszteres kimenetet, amelynek mérete a renderelési skálától is függ.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <DOM/ISlide.h>
#include <Export/NotesCommentsLayoutingOptions.h>
#include <Export/NotesPositions.h>
#include <Export/PdfOptions.h>
#include <Export/RenderingOptions.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<NotesCommentsLayoutingOptions>();
layout->set_NotesPosition(NotesPositions::BottomTruncated);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"notes.pdf", SaveFormat::Pdf, pdfOptions);

auto renderingOptions = MakeObject<RenderingOptions>();
renderingOptions->set_SlidesLayoutOptions(layout);

auto image = presentation->get_Slide(0)->GetImage(renderingOptions, 1.0f, 1.0f);
image->Save(u"first-slide-notes.png", ImageFormat::Png);
image->Dispose();
```

Hosszú jegyzetek PDF-exportálásához a [BottomFull](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/notespositions/) lehetővé teszi a szükséges további oldalakat. Ne használja ezt a módot a fenti egyetlen dia képkérésekor, amely nem támogatja. Átméretezés után ellenőrizze a kimenetet a levágott jegyzetek és a meglévő notes-master objektumok elhelyezkedése szempontjából; csak az oldalméretek megváltoztatását nem szabad garanciaként tekinteni arra, hogy minden tartalom elfér. További információkért a jegyzetek exportjáról lásd a [Convert PowerPoint to PDF with Notes](/slides/hu/cpp/convert-powerpoint-to-pdf-with-notes/) oldalt.

### **Szórólapok exportálása PDF-be**

Használja a [HandoutLayoutingOptions](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handoutlayoutingoptions/) több dia bélyegkép egy oldalon való elhelyezéséhez. A következő példa egy 900 × 600 pontos oldalt állít be, és a [HandoutType::Handouts4Horizontal](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/handouttype/) metódust használja, hogy legfeljebb négy diát helyezzen el egy oldalon. A vízszintes előre beállítás a diák sorrendjét szabályozza; az oldal tájolása a szélességéből és magasságából származik.

```cpp
#include <DOM/Presentation.h>
#include <DOM/INotesSize.h>
#include <Export/HandoutLayoutingOptions.h>
#include <Export/HandoutType.h>
#include <Export/PdfOptions.h>
#include <Export/SaveFormat.h>
#include <drawing/size_f.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
presentation->get_NotesSize()->set_Size(SizeF(900, 600));

auto layout = MakeObject<HandoutLayoutingOptions>();
layout->set_Handout(HandoutType::Handouts4Horizontal);

auto pdfOptions = MakeObject<PdfOptions>();
pdfOptions->set_SlidesLayoutOptions(layout);

presentation->Save(u"handouts.pdf", SaveFormat::Pdf, pdfOptions);
```

Az oldalméret módosítása a szórólap rács rendelkezésre álló területét változtatja meg, anélkül, hogy a forrásdiák mérete megváltozna. Szórólap képekhez használja a [Presentation::GetImages](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/getimages/) metódust a szórólap elrendezéssel, nem pedig egyedi dia képmódszerrel. Az Aspose.Slides-ban a bemutató szintű szórólap renderelés a jegyzetoldal méreteit használja, míg az egyedi dia képkérése nem hoz létre szórólap oldalt. A elrendezési lehetőségekért lásd a [Handout Mode](/slides/hu/cpp/convert-powerpoint-in-handout-mode/) oldalt.

## **Az oldal mérete a megjelenítőkben, exportálásnál és nyomtatásnál**

Tartsa meg a tárolt bemutató méretét, az exportált oldalméretet és a nyomtatott papír méretét különállóként:

- **Presentation viewers:** A megjelenítő képes a jegyzeteket megjeleníteni vagy nyomtatni saját elrendezési szabályai szerint. Ha egy másik alkalmazás menti a fájlt, nyissa meg újra és ellenőrizze újra a méreteket; az adott alkalmazás formátumkonverziója normalizálhatja azokat.
- **Export formats:** A fenti jegyzet- és szórólap PDF példák a beállított oldalméreteket használják. A raszteres képek egész számú képpont méreteket és egy renderelési skálát használnak, így a tört pontértékek a képkimenetben kerekíthetők. A szokásos diák exportálása nem alkalmazza a jegyzetoldal méretét.
- **Printer drivers:** A papírválasztás, az automatikus forgatás és a mérethez igazítás beállítások megváltoztathatják a fizikai kimenetet anélkül, hogy a bemutatóban vagy a PDF-ben tárolt méreteket módosítanák. Egy adott papírméret esetén igazítsa a nyomtató beállításait és ellenőrizze a nyomtatási előnézetet.

## **GYIK**

**Beállíthatom a jegyzet méretét csak egy diára?**

A jegyzetoldal mérete a teljes bemutató szintű beállítás. Az egyes diák különböző jegyzettartalommal rendelkezhetnek, de ez a tulajdonság nem biztosít különálló oldalméretet minden dia számára.

**Miért nem változtatta meg a jegyzet tájolásának módosítása a diáimat?**

A jegyzetoldalak és a szokásos diák független méretekkel rendelkeznek. Használja a szokásos dia méret beállításait, ha a diák méretét szeretné módosítani.

**Miért más méretű a mentett vagy nyomtatott eredmény?**

Először nyissa meg újra a mentett bemutatót, és hasonlítsa össze a jegyzet méreteit. Ha azok megváltoztak, ellenőrizze, hogy egy másik alkalmazásban történt-e mentés vagy konvertálás során az oldalbeállítások módosítása. Ha nem, vizsgálja meg az export elrendezést, a képméret skálát, a megjelenítő beállításait és a nyomtató papírválasztását.