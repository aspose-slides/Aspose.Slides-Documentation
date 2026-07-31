---
title: Alapértelmezett prezentációs betűtípusok megadása C++-ban
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/cpp/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- standard betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for C++-ban, hogy biztosítsa a PowerPoint (PPT, PPTX) és az OpenDocument (ODP) megfelelő konvertálását PDF, XPS és képek formátumokra."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi alapértelmezett betűtípusok megadását, amelyeket a bemutató renderelésekor használ. Ez hasznos diaképbélyegek létrehozásakor vagy a bemutató PDF és XPS formátumokba exportálásakor. Az alapértelmezett betűtípusok a `LoadOptions` segítségével konfigurálhatók, mielőtt a bemutatót betöltenék.

`set_DefaultRegularFont` metódus határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a `set_DefaultAsianFont` az ázsiai szöveghez. Miután ezek az opciók be vannak állítva, a bemutatót betölthetjük és renderelhetjük a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata a bemutató rendereléséhez**
Az Aspose.Slides lehetővé teszi az alapértelmezett betűtípus beállítását a bemutató PDF, XPS vagy bélyegképekre való rendereléséhez. Ez a cikk bemutatja, hogyan definiálhatók a DefaultRegular Font és a DefaultAsian Font alapértelmezett betűtípusként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból történő betöltéséhez az Aspose.Slides for C++ API használatával:

1. Hozzon létre egy LoadOptions példányt.
1. Állítsa be a DefaultRegularFont-ot a kívánt betűtípusra. Az alábbi példában Wingdings-et használtam.
1. Állítsa be a DefaultAsianFont-ot a kívánt betűtípusra. A következő mintában Wingdings-et használtam.
1. Töltse be a bemutatót a Presentation osztállyal, és állítsa be a betöltési beállításokat.
1. Ezután generálja a diakép bélyegképet, PDF-et és XPS-et a eredmény ellenőrzéséhez.

A fenti megvalósítás alább található.

```cpp
// Használja a betöltési opciókat az alapértelmezett normál és ázsiai betűtípusok megadásához
auto loadOptions = MakeObject<LoadOptions>(LoadFormat::Auto);
loadOptions->set_DefaultRegularFont(u"Wingdings");
loadOptions->set_DefaultAsianFont(u"Wingdings");

auto pptx = MakeObject<Presentation>(u"DefaultFonts.pptx", loadOptions);

auto image = pptx->get_Slide(0)->GetImage(1, 1);
image->Save(u"DefaultFonts_out.png", ImageFormat::Png);
image->Dispose();

pptx->Save(u"DefaultFonts_out.pdf", SaveFormat::Pdf);
pptx->Save(u"DefaultFonts_out.xps", SaveFormat::Xps);

pptx->Dispose();
```

## **GYIK**

**A DefaultRegularFont és a DefaultAsianFont pontosan mit befolyásol — csak az exportot, vagy a bélyegképeket, PDF-et, XPS-et, HTML-t és SVG-t is?**

Részt vesznek a renderelési folyamatban minden támogatott kimenetnél. Ez magában foglalja a diakép bélyegképeket, a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), a [raszteres képeket](/slides/hu/cpp/convert-powerpoint-to-png/), a [HTML](/slides/hu/cpp/convert-powerpoint-to-html/), és az [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt a elrendezési és glif feloldási logikát alkalmazza ezeken a célokon.

**Alkalmazzák-e az alapértelmezett betűtípusok egyszerűen egy PPTX beolvasásakor és mentésekor, renderelés nélkül?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és rajzolni kell. Egy egyszerű megnyitás‑és‑mentés nem módosítja a tárolt betűtípus‑futtatásokat vagy a fájl struktúráját. Az alapértelmezett betűtípusok olyan műveletek során lépnek életbe, melyek renderelik vagy újraindítják a szöveget.

**Ha saját betűtípus‑könyvtárakat adok hozzá vagy memóriából szolgáltatok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Custom font sources](/slides/hu/cpp/custom-font/) kibővíti a rendelkezésre álló családok és glifek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és minden [fallback rules](/slides/hu/cpp/fallback-font/) elsőként ezekből a forrásokból fognak megoldódni, ami megbízhatóbb lefedettséget biztosít a szervereken és konténerekben.

**Az alapértelmezett betűtípusok befolyásolják a szövegmetrikákat (kerning, előrelépések), és ezáltal a sortöréseket és a sortördelést?**

Igen. A betűtípus megváltoztatása módosítja a glif metrikákat, ami befolyásolhatja a sortöréseket, a sortördelést és a lapozást a renderelés során. A elrendezés stabilitása érdekében [embed the original fonts](/slides/hu/cpp/embedded-font/) vagy válasszon metrikailag kompatibilis alapértelmezett és tartalék családokat.

**Van-e értelme alapértelmezett betűtípusokat beállítani, ha a bemutatóban használt összes betűtípust beágyazzák?**

Gyakran nincs rá szükség, mivel a [embedded fonts](/slides/hu/cpp/embedded-font/) már biztosítja a konzisztens megjelenést. Az alapértelmezett betűtípusok mégis hasznosak védőhálóként azokhoz a karakterekhez, amelyeket a beágyazott részhalmaz nem fed le, vagy amikor egy fájl keveri a beágyazott és a nem beágyazott szöveget.