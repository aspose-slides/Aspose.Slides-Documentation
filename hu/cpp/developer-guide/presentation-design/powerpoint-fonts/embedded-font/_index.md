---
title: Betűtípusok beágyazása prezentációkba C++ használatával
linktitle: Betűtípus beágyazása
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
- OpenDocument
- prezentáció
- С++
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Aspose.Slides for C++ segítségével, biztosítva a pontos megjelenítést minden platformon."
---
## **Bevezetés**

**A PowerPointba beágyazott betűtípusok** segítenek biztosítani, hogy bemutatója megtartsa a kívánt megjelenést, amikor bármely rendszeren vagy eszközön megnyitják. Ez különösen fontos egyedi, harmadik féltől származó vagy nem szabványos betűtípusok használatakor a márkaépítés vagy a kreatív célok érdekében. Beágyazott betűtípusok hiányában a szöveget helyettesíthetik, az elrendezések megbomolhatnak, és a karakterek olvashatatlan szimbólumokként vagy négyzetekként jelenhetnek meg, ami aláássa a teljes dizájnt.

Aspose.Slides for C++ egy erőteljes API-készletet biztosít a beágyazott betűtípusok programozott kezeléséhez. Használhatja a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) és a [FontData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontdata/) osztályokat a betűtípusok vizsgálatához, hozzáadásához vagy eltávolításához a prezentáció fájljaiban. Emellett a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztály lehetővé teszi a fájlméret optimalizálását a betűtípus‑adatok tömörítésével, anélkül hogy a minőség vagy a megjelenés romlana.

Ezek az eszközök teljes körű irányítást adnak a betűtípus‑beágyazás felett, segítve a tipográfia következetes megtartását különböző platformokon, miközben szükség esetén csökkentik a fájlméretet.

## **Beágyazott betűtípusok lekérése egy prezentációból**

Aspose.Slides for C++ a `GetEmbeddedFonts` metódust biztosítja a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályon keresztül, amely lehetővé teszi a PowerPoint‑prezentációba beágyazott betűtípusok listájának lekérését. Ez hasznos lehet a betűtípus‑használat auditálásához, a márka‑irányelvek betartásának biztosításához, vagy annak ellenőrzéséhez, hogy minden szükséges betűtípus helyesen legyen beágyazva a fájl megosztása előtt.

Az alábbi C++ kód bemutatja, hogyan lehet beágyazott betűtípusokat lekérni egy prezentációfájlból:

```cpp
// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Lekéri az összes beágyazott betűtípust.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Kiírja a beágyazott betűtípusok neveit.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Beágyazott betűtípusok hozzáadása egy prezentációhoz**

Aspose.Slides for C++ lehetővé teszi betűtípusok beágyazását egy PowerPoint‑prezentációba a [AddEmbeddedFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/addembeddedfont/) metódus segítségével, amely két túlterheléssel biztosít rugalmas használatot. A beágyazott karakterek mennyiségét a [EmbedFontCharacters](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedfontcharacters/) felsorolás használatával szabályozhatja – például csak a használt karakterek vagy a teljes betűtípus‑készlet beágyazásával. Ez a funkció különösen hasznos a prezentáció megosztására vagy terjesztésére való előkészítésekor, biztosítva, hogy az egyedi vagy nem szabványos betűtípusok helyesen jelenjenek meg minden rendszeren, még akkor is, ha azok nincsenek telepítve.

Az alábbi C++ kód ellenőrzi a prezentációban használt összes betűtípust, és beágyazza azokat, amelyek még nincsenek beágyazva:

```cpp
// Betölt egy prezentációfájlt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Ellenőrzi, hogy a betűtípus már be van-e ágyazva.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Beágyazza a betűtípust a prezentációba.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Mentse a prezentációt a lemezen.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Beágyazott betűtípusok eltávolítása egy prezentációból**

Aspose.Slides for C++ a `RemoveEmbeddedFont` metódust biztosítja a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályon keresztül, amely lehetővé teszi a PowerPoint‑prezentációban beágyazott konkrét betűtípusok eltávolítását. Ez segíthet a fájlméret csökkentésében, különösen ha a beágyazott betűtípusok már nem szükségesek vagy nem használtak. A nem használt betűtípusok eltávolítása javíthatja a teljesítményt, és biztosíthatja, hogy a prezentáció csak a lényeges erőforrásokat tartalmazza.

Az alábbi C++ kód bemutatja, hogyan lehet egy beágyazott betűtípust eltávolítani egy prezentációból:

```cpp
auto fontName = u"Calibri";

// Példányosítja a Presentation osztályt, amely egy prezentációfájlt képvisel.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Lekéri az összes beágyazott betűtípust.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : embeddedFonts)
{
    if (fontData->get_FontName().Equals(fontName))
    {
        // Eltávolítja a beágyazott betűtípust.
        presentation->get_FontsManager()->RemoveEmbeddedFont(fontData);

        break;
    }
}

presentation->Save(u"removed_font.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

## **Beágyazott betűtípusok tömörítése**

Aspose.Slides for C++ a `CompressEmbeddedFonts` metódust biztosítja a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztályon keresztül, lehetővé téve a prezentáció összes fájlméretének csökkentését a beágyazott betűtípus‑adatok optimalizálásával. Ez különösen hasznos, ha a prezentáció nagy vagy több betűtípust tartalmaz, és a fájlt könnyűsúlyúvá szeretné tenni megosztás, tárolás vagy online használat céljából – anélkül, hogy a tartalom vizuális hűségét veszélyeztetné.

Az alábbi C++ kód bemutatja, hogyan lehet beágyazott betűtípusokat tömöríteni egy PowerPoint‑prezentációban:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Hogyan tudhatom, hogy egy adott betűtípus a prezentációban még mindig helyettesítésre kerül a renderelés során a beágyazás ellenére?**  
Ellenőrizze a [substitution information](/slides/hu/cpp/font-substitution/) és a [fallback/substitution rules](/slides/hu/cpp/fallback-font/) információkat a betűtípus‑kezelőben: ha a betűtípus nem elérhető vagy korlátozott, egy helyettesítő lesz használva.

**Érdemes-e a “rendszer” betűtípusokat, például az Arial/Calibri‑t beágyazni?**  
Általában nem – ezek szinte mindig elérhetők. De „vékony” környezetekben (Docker, Linux‑szerver előre telepített betűtípusok nélkül) a rendszer‑betűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.