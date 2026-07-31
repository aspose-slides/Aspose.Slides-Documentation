---
title: Betűtípusok beágyazása prezentációkba C++-ban
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
- C++
- Aspose.Slides
description: "TrueType betűtípusok beágyazása PowerPoint és OpenDocument prezentációkba az Aspose.Slides for C++ segítségével, biztosítva a pontos renderelést minden platformon."
---
## **Bevezetés**

**Beágyazott betűtípusok a PowerPointban** segítenek biztosítani, hogy a prezentáció megőrizze a szándékolt megjelenését bármely rendszer vagy eszköz megnyitásakor. Ez különösen fontos egyedi, harmadik féltől származó vagy nem szabványos betűtípusok használatakor a márkaépítés vagy kreatív célok érdekében. Beágyazott betűtípusok nélkül a szöveget helyettesíthetik, a layoutrak megszakadhatnak, és a karakterek olvashatatlan szimbólumokként vagy négyzetekként jelenhetnek meg, ezzel veszélyeztetve a teljes tervezést.

Aspose.Slides for C++ egy sor hatékony API-t biztosít a beágyazott betűtípusok programozott kezeléséhez. Használhatja a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) és a [FontData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontdata/) osztályokat a betűtípusok ellenőrzéséhez, hozzáadásához vagy eltávolításához a prezentációs fájlokban. Továbbá a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztály lehetővé teszi a fájlméret optimalizálását a betűtípus adatainak tömörítésével anélkül, hogy a minőség vagy a megjelenés változna.

Ezek az eszközök teljes irányítást adnak a betűtípus beágyazása felett, segítve a konzisztens tipográfia fenntartását különböző platformokon, miközben szükség esetén csökkentik a fájlméretet.

## **Beágyazott betűtípusok lekérése a prezentációból**

Az Aspose.Slides for C++ a `GetEmbeddedFonts` metódust a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályon keresztül biztosítja, amely lehetővé teszi a PowerPoint prezentációban beágyazott betűtípusok listájának lekérését. Ez hasznos lehet a betűtípus használatának auditálásához, a márka irányelveinek való megfelelés biztosításához, vagy annak ellenőrzéséhez, hogy minden szükséges betűtípus megfelelően be legyen vonva a fájl megosztása előtt.

Az alábbi C++ kód bemutatja, hogyan lehet beágyazott betűtípusokat lekérni egy prezentációs fájlból:

```cpp
// Példányosítsa a Presentation osztályt, amely egy prezentációs fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"embedded_fonts.pptx");

// Az összes beágyazott betűtípust lekéri.
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

// Kiírja a beágyazott betűtípusok nevét.
for (auto&& fontData : embeddedFonts)
{
    Console::WriteLine(fontData->get_FontName());
}

presentation->Dispose();
```

## **Beágyazott betűtípusok hozzáadása a prezentációhoz**

Aspose.Slides for C++ lehetővé teszi a betűtípusok PowerPoint prezentációba történő beágyazását a [AddEmbeddedFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/addembeddedfont/) metódus használatával, amely két túlterheléssel rendelkezik a rugalmas használathoz. Az [EmbedFontCharacters](https://reference.aspose.com/slides/hu/cpp/aspose.slides.export/embedfontcharacters/) felsorolás segítségével szabályozhatja, hogy a betűtípus mennyire legyen beágyazva – például csak a használt karakterek vagy a teljes betűtípus készlet beágyazását választhatja. Ez a funkció különösen hasznos a prezentáció megosztásra vagy terjesztésre való előkészítésekor, biztosítva, hogy az egyedi vagy nem szabványos betűtípusok helyesen jelenjenek meg minden rendszerben, még akkor is, ha a betűtípusok nincsenek telepítve.

Az alábbi C++ kód ellenőrzi a prezentációban használt összes betűtípust, és beágyazza azokat a betűtípusokat, amelyek még nincsenek beágyazva:

```cpp
// Betölt egy prezentációs fájlt.
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto usedFonts = presentation->get_FontsManager()->GetFonts();
auto embeddedFonts = presentation->get_FontsManager()->GetEmbeddedFonts();

for (auto&& fontData : usedFonts)
{
    std::function<bool(SharedPtr<IFontData> data)> comparer = [&fontData](SharedPtr<IFontData> data) -> bool
        {
            return data == fontData;
        };

    // Ellenőrizze, hogy a betűtípus már be van-e ágyazva.
    bool isEmbeddedFont = Array<SharedPtr<IFontData>>::Exists(embeddedFonts, comparer);
    if (!isEmbeddedFont)
    {
        // Ágyazza be a betűtípust a prezentációba.
        presentation->get_FontsManager()->AddEmbeddedFont(fontData, EmbedFontCharacters::All);
    }

}

// Mentse a prezentációt a lemezre.
presentation->Save(u"embedded_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Beágyazott betűtípusok eltávolítása a prezentációból**

Az Aspose.Slides for C++ a `RemoveEmbeddedFont` metódust a [FontsManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/fontsmanager/) osztályon keresztül biztosítja, amely lehetővé teszi a PowerPoint prezentációban beágyazott konkrét betűtípusok eltávolítását. Ez segíthet a teljes fájlméret csökkentésében, különösen ha a beágyazott betűtípusok már nem használatosak vagy szükségesek. A nem használt betűtípusok eltávolítása javíthatja a teljesítményt, és biztosíthatja, hogy a prezentáció csak a szükséges erőforrásokat tartalmazza.

Az alábbi C++ kód bemutatja, hogyan lehet eltávolítani egy beágyazott betűtípust a prezentációból:

```cpp
auto fontName = u"Calibri";

// Példányosítja a Presentation osztályt, amely egy prezentációs fájlt képvisel.
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

Az Aspose.Slides for C++ a `CompressEmbeddedFonts` metódust a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztályon keresztül biztosítja, lehetővé téve a prezentáció teljes fájlméretének csökkentését a beágyazott betűtípus adatainak optimalizálásával. Ez különösen hasznos, ha a prezentáció nagy vagy több betűtípust tartalmaz, és könnyű fájlt szeretne fenntartani a megosztáshoz, tároláshoz vagy online használathoz – anélkül, hogy a tartalom vizuális hűségét veszélyeztetné.

Az alábbi C++ kód bemutatja, hogyan lehet tömöríteni a beágyazott betűtípusokat egy PowerPoint prezentációban:

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

Compress::CompressEmbeddedFonts(presentation);

presentation->Save(u"compressed_fonts.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Hogyan tudom megállapítani, hogy egy adott betűtípus a prezentációban a beágyazás ellenére is helyettesítésre kerül a renderelés során?**

Ellenőrizze a [helyettesítési információ](/slides/hu/cpp/font-substitution/) a betűtípuskezelőben és a [fallback/substitution szabályok](/slides/hu/cpp/fallback-font/)-at: ha a betűtípus nem elérhető vagy korlátozott, egy tartalék (fallback) lesz használva.

**Érdemes beágyazni a „rendszer” betűtípusokat, például az Arial/Calibri-t?**

Általában nem – ezek szinte mindig elérhetők. Azonban a teljes hordozhatóság érdekében „vékony” környezetekben (Docker, egy előre telepített betűtípusok nélküli Linux szerver), a rendszerbetűtípusok beágyazása kiküszöbölheti a váratlan helyettesítések kockázatát.