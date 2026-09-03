---
title: Betűtípusok beágyazása prezentációkba C++-ban
linktitle: Beágyazott betűtípusok
type: docs
weight: 40
url: /hu/cpp/embedded-font/
keywords:
- betűtípus hozzáadása
- betűtípus beágyazása
- betűtípus beágyazás
- beágyazott betűtípus lekérése
- beágyazott betűtípus hozzáadása
- beágyazott betűtípus eltávolítása
- beágyazott betűtípus tömörítése
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Kezelezze a beágyazott betűtípusokat a PowerPointban az Aspose.Slides for C++ segítségével. Betűtípusok hozzáadása, lekérése, eltávolítása és tömörítése a szöveg megjelenésének megőrzése és a fájlméret csökkentése érdekében."
---
## **Bevezetés**

A betűtípusok beágyazása a betűtípus adatokat egy PowerPoint‑prezentációba tárolja. Amikor egy megjelenítő támogatja a beágyazott betűtípusokat, képes megjeleníteni a szöveget ezekkel a betűtípusokkal, még akkor is, ha nincsenek telepítve a célrendszeren. Ez segít megőrizni a sortöréseket, a szövegközöket és a diák elrendezését.

Az Aspose.Slides for C++ lehetővé teszi a beágyazott betűtípusok lekérdezését, hozzáadását és eltávolítását a [Presentation::get_FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_fontsmanager/) metóduson keresztül egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/)-ben. A beágyazott betűtípus adat méretét is csökkentheted a prezentáció által nem használt karakterek eltávolításával.

Az alábbi példák PPTX fájlokkal működnek. Mielőtt betűtípust ágyaznál be, győződj meg róla, hogy a betűtípus adata elérhető az Aspose.Slides számára, és a licenc engedélyezi a beágyazást.

## **Beágyazott betűtípusok lekérdezése és eltávolítása**

Használd a [IFontsManager::GetEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getembeddedfonts/) metódust a prezentációban tárolt betűtípusok listázásához. Egy betűtípus eltávolításához add át a listából származó betűtípust a [IFontsManager::RemoveEmbeddedFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/removeembeddedfont/) metódusnak, majd mentsd el a prezentációt.

Az alábbi példa listázza az `EmbeddedFonts.pptx` fájl beágyazott betűtípusait, és eltávolítja a Calibrít, ha jelen van:

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparison.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
SharedPtr<IFontData> fontToRemove;

for (auto&& font : embeddedFonts)
{
    Console::WriteLine(font->get_FontName());

    if (String::Equals(font->get_FontName(), u"Calibri", StringComparison::OrdinalIgnoreCase))
    {
        fontToRemove = font;
    }
}

if (fontToRemove != nullptr)
{
    fontsManager->RemoveEmbeddedFont(fontToRemove);
    presentation->Save(u"WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
}
else
{
    Console::WriteLine(u"Calibri is not embedded. No output file was created.");
}

presentation->Dispose();
```

Egy beágyazott betűtípus eltávolítása a tárolt betűtípus adatot törli; ez nem módosítja a szöveghez rendelt betűtípust. Ha a betűtípus telepítve van a célrendszeren, a szöveg továbbra is azt használhatja. Ellenkező esetben a megjelenítéshez [betűtípus-helyettesítés](/slides/hu/cpp/font-substitution/) lehet szükséges, ami befolyásolhatja az elrendezést.

## **Betűtípusadatok és beágyazási engedélyek vizsgálata**

Használd az [IFontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/) interfészt a betűtípusok beágyazása előtt történő ellenőrzéshez. Hívd meg a [IFontsManager::GetFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getfonts/) metódust a prezentációban használt betűtípusok lekéréséhez. Minden betűtípushoz add át egy [IFontData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontdata/) objektumot és a kívánt [FontStyleType](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontstyletype/) értéket a [IFontsManager::GetFontBytes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getfontbytes/) metódusnak. A metódus visszaadja a betűtípus stílus bináris adatait, vagy `nullptr`‑t, ha a kért betűtípus vagy stílus nem érhető el. Ne add át a `nullptr` eredményt a [IFontsManager::GetFontEmbeddingLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getfontembeddinglevel/) metódusnak, mivel ez a metódus egy bájt tömböt vár.

A [EmbeddingLevel](https://reference.aspose.com/slides/hu/cpp/aspose.slides/embeddinglevel/) egy zászlók enumerációja, amely a betűtípusban tárolt beágyazási korlátozásokat jelenti:

- `Installable` engedélyezi a beágyazást és a végleges telepítést egy másik rendszeren, a betűtípus licencétől függően.
- `Restricted` megtiltja a beágyazást, hacsak nem kapunk engedélyt a betűtípus jogtulajdonosától, ha ez az egyetlen használati engedély zászló.
- `PreviewPrint` ideiglenes használatot enged meg megtekintéshez és nyomtatáshoz; a betűtípust tartalmazó dokumentumnak csak olvashatónak kell lennie.
- `Editable` ideiglenes használatot enged meg, és lehetővé teszi a dokumentum szerkesztését és mentését.
- `NoSubsetting` egy további korlátozás, amely megtiltja a betűtípus csak egy részhalmazának beágyazását. Ha ez a zászló jelen van, az összes karaktert be kell ágyazni.
- `BitmapOnly` egy további korlátozás, amely csak a bitmap változatok beágyazását engedélyezi, nem az outline adatokat. Ha a betűtípusnak nincs bitmap változata, nem ágyazható be.

Az első négy érték a használati engedélyt írja le, míg a `NoSubsetting` és `BitmapOnly` kombinálható velük. Ellenőrizd a módosítókat bitenkénti műveletekkel. Mivel az `Installable` értéke nulla, maszkolj a használati engedély biteket, és hasonlítsd össze az eredményt az `Installable`‑val. A jelenlegi betűtípusoknak legfeljebb egy használati engedély bitet kell beállítaniuk. A régebbi betűtípusokkal való kompatibilitás érdekében, amelyek több engedélyt is beállíthatnak, az alábbi segédfüggvény a legkevésbé korlátozó engedélyt választja: `Editable`, majd `PreviewPrint`, majd `Restricted`.

Az alábbi példa auditálja a szabályos, félkövér, dőlt és félkövér‑dőlt adatokat minden betűtípushoz, amelyet a `GetFonts` visszaad. Kihagyja a nem elérhető stílusokat, a korlátozott betűtípusokat, a csak bitmap‑változatot, a csak előnézet‑nyomtatásra korlátozott betűtípusokat, mert a kimenet szerkeszthető marad, valamint a már beágyazott betűtípusokat. Ha valamely elérhető stílus `NoSubsetting`‑et tartalmaz, az összes karaktert beágyazza az adott betűtípuscsoporthoz.

```cpp
#include <DOM/EmbeddingLevel.h>
#include <DOM/FontStyleType.h>
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/array.h>
#include <system/collections/list.h>
#include <system/collections/sorted_set.h>
#include <system/console.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto getUsagePermission = [](EmbeddingLevel level)
{
    const auto permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    auto permissions = level & permissionMask;

    if ((permissions & EmbeddingLevel::Editable) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Editable;
    }

    if ((permissions & EmbeddingLevel::PreviewPrint) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::PreviewPrint;
    }

    if ((permissions & EmbeddingLevel::Restricted) != EmbeddingLevel::Installable)
    {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
};

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto fontStyles = MakeArray<FontStyleType>({
    FontStyleType::Regular,
    FontStyleType::Bold,
    FontStyleType::Italic,
    FontStyleType::Bold | FontStyleType::Italic
});
auto fontStyleNames = MakeArray<String>({u"regular", u"bold", u"italic", u"bold-italic"});

auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());
for (auto&& embeddedFont : fontsManager->GetEmbeddedFonts())
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

auto fontsToEmbedAll = MakeObject<List<SharedPtr<IFontData>>>();
auto fontsToEmbedUsedOnly = MakeObject<List<SharedPtr<IFontData>>>();
for (auto&& font : fontsManager->GetFonts())
{
    if (embeddedFontNames->Contains(font->get_FontName()))
    {
        Console::WriteLine(u"{0}: already embedded.", font->get_FontName());
        continue;
    }

    auto hasAvailableData = false;
    auto allAvailableStylesCanBeEmbedded = true;
    auto previewPrintOnly = false;
    auto requiresFullFont = false;

    for (auto styleIndex = 0; styleIndex < fontStyles->get_Length(); styleIndex++)
    {
        auto fontStyle = fontStyles[styleIndex];
        auto fontBytes = fontsManager->GetFontBytes(font, fontStyle);
        if (fontBytes == nullptr)
        {
            Console::WriteLine(u"{0} ({1}): font data is unavailable.", font->get_FontName(), fontStyleNames[styleIndex]);
            continue;
        }

        hasAvailableData = true;
        auto embeddingLevel = fontsManager->GetFontEmbeddingLevel(fontBytes, font->get_FontName());
        auto usagePermission = getUsagePermission(embeddingLevel);
        auto noSubsetting = (embeddingLevel & EmbeddingLevel::NoSubsetting) != EmbeddingLevel::Installable;
        auto bitmapOnly = (embeddingLevel & EmbeddingLevel::BitmapOnly) != EmbeddingLevel::Installable;

        requiresFullFont |= noSubsetting;
        previewPrintOnly |= usagePermission == EmbeddingLevel::PreviewPrint;
        allAvailableStylesCanBeEmbedded &= usagePermission != EmbeddingLevel::Restricted && !bitmapOnly;

        Console::WriteLine(u"{0} ({1}): embedding level {2}.", font->get_FontName(), fontStyleNames[styleIndex], static_cast<uint16_t>(embeddingLevel));
    }

    if (!hasAvailableData)
    {
        Console::WriteLine(u"{0}: skipped because no requested style is available.", font->get_FontName());
    }
    else if (!allAvailableStylesCanBeEmbedded)
    {
        Console::WriteLine(u"{0}: skipped because at least one available style does not permit outline embedding.", font->get_FontName());
    }
    else if (previewPrintOnly)
    {
        Console::WriteLine(u"{0}: skipped because this example produces an editable presentation.", font->get_FontName());
    }
    else if (requiresFullFont)
    {
        fontsToEmbedAll->Add(font);
    }
    else
    {
        fontsToEmbedUsedOnly->Add(font);
    }
}

for (auto&& font : fontsToEmbedAll)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
}

for (auto&& font : fontsToEmbedUsedOnly)
{
    fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::OnlyUsed);
}

presentation->Save(u"WithAuditedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Ez a vizsgálat jelentést ad a betűtípusfájlokban kódolt korlátozásokról. Nem ad licencet, nem bizonyítja, hogy a betűtípust legálisan szerezted be, és nem helyettesíti a betűtípus licencszerződésének ellenőrzését a beágyazott másolat terjesztése előtt.

## **Beágyazott betűtípusok hozzáadása**

Használd a [IFontsManager::AddEmbeddedFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/addembeddedfont/) metódust betűtípus beágyazásához. Az általa biztosított túlterhelések elfogadnak vagy egy [IFontData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontdata/) objektumot, vagy egy betűtípus adatot tartalmazó bájt tömböt. A [EmbedFontCharacters](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedfontcharacters/) enumeráció szabályozza, hogy mely karakterek legyenek belefoglalva:

- [All](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedfontcharacters/) minden karaktert beágyaz a betűtípusban. Ezt a lehetőséget használd, ha a címzetteknek szerkeszteniük kell a prezentációt és új szöveget kell beírniuk.
- [OnlyUsed](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedfontcharacters/) csak a prezentációban használt karaktereket ágyazza be, hogy csökkentse a fájlméretet. Válaszd ezt a beállítást egy kész prezentációhoz, amely elsősorban megtekintésre szánt.

Az alábbi példa a [IFontsManager::GetFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getfonts/) segítségével lekéri a `Fonts.pptx` fájlban használt betűtípusokat, és beágyazza azokat, amelyek még nincsenek beágyazva. A hozzáadandó betűtípusoknak elérhetőnek kell lenniük azon a gépen, amelyen a kód fut. A már létező beágyazott betűtípusok megtartják a jelenlegi karakterkészletüket.

```cpp
#include <DOM/IFontData.h>
#include <DOM/IFontsManager.h>
#include <DOM/Presentation.h>
#include <Export/EmbedFontCharacters.h>
#include <Export/SaveFormat.h>
#include <system/collections/sorted_set.h>
#include <system/shared_ptr.h>
#include <system/string.h>
#include <system/string_comparer.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Collections::Generic;

auto presentation = MakeObject<Presentation>(u"Fonts.pptx");
auto fontsManager = presentation->get_FontsManager();
auto allFonts = fontsManager->GetFonts();
auto embeddedFonts = fontsManager->GetEmbeddedFonts();
auto embeddedFontNames = MakeObject<SortedSet<String>>(StringComparer::get_OrdinalIgnoreCase());

for (auto&& embeddedFont : embeddedFonts)
{
    embeddedFontNames->Add(embeddedFont->get_FontName());
}

for (auto&& font : allFonts)
{
    if (!embeddedFontNames->Contains(font->get_FontName()))
    {
        fontsManager->AddEmbeddedFont(font, EmbedFontCharacters::All);
        embeddedFontNames->Add(font->get_FontName());
    }
}

presentation->Save(u"WithEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Beágyazott betűtípusok tömörítése**

A [Compress::CompressEmbeddedFonts](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/compressembeddedfonts/) csökkenti a beágyazott betűtípus adatokat a nem használt karakterek eltávolításával. Olyan betűtípusokon működik, amelyek már be vannak ágyazva, így a méretcsökkenés attól függ, mennyi fel nem használt betűtípus adatot tartalmaz a prezentáció.

Az alábbi példa tömöríti az `EmbeddedFonts.pptx` fájl betűtípusait, és a eredményt egy külön fájlba menti:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;
using namespace System;

auto presentation = MakeObject<Presentation>(u"EmbeddedFonts.pptx");
Compress::CompressEmbeddedFonts(presentation);
presentation->Save(u"CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Tartsd meg az eredeti fájlt, ha a címzettek később szöveget szeretnének hozzáadni. A tömörítés során eltávolított karakterek már nem érhetők el a beágyazott betűtípusból, még akkor sem, ha eredetileg az összes karaktert beágyaztad.

## **GYIK**

**Hogyan ellenőrizhetem, hogy egy beágyazott betűtípust továbbra is helyettesít-e a renderelés során?**

Hívd meg a [IFontsManager::GetSubstitutions](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifontsmanager/getsubstitutions/) metódust abban a környezetben, ahol a prezentációt rendereled, hogy lásd, mely betűtípusokat fogja az Aspose.Slides helyettesíteni. Emellett ellenőrizd a [betűtípus-helyettesítés](/slides/hu/cpp/font-substitution/) beállításait és a [betűtípus fallback](/slides/hu/cpp/fallback-font/) szabályait. A fallback kezeli a hiányzó karaktereket, így egy betűtípus beágyazása nem oldja meg azokat a karaktereket, amelyeket a betűtípus önmagában nem tartalmaz.

**Érdemes-e általános betűtípusokat, például Arial‑t és Calibri‑t beágyazni?**

A döntést a célkörnyezet alapján hozd meg. Ha a szükséges betűtípusok minden gépen elérhetők, amely a prezentációt megnyitja vagy rendereli, a beágyazás csak felesleges fájlméretet növelhet. Ha a címzettek vagy a szerverek esetleg nem rendelkeznek ezekkel a betűtípusokkal, a beágyazás segíthet megőrizni a kívánt megjelenést, feltéve hogy a licencek ezt megengedik.