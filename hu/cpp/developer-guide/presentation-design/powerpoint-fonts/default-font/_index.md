---
title: Alapértelmezett prezentációs betűtípusok megadása C++-ban
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/cpp/default-font/
keywords:
  - alapértelmezett betűtípus
  - normál betűtípus
  - normál betűtípus
  - ázsiai betűtípus
  - PDF export
  - XPS export
  - kép export
  - PowerPoint
  - OpenDocument
  - prezentáció
  - C++
  - Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides C++-hoz, hogy biztosítsa a PowerPoint (PPT, PPTX) és OpenDocument (ODP) helyes konvertálását PDF‑be, XPS‑be és képekké."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket a prezentáció renderelése során használ. Ez akkor hasznos, amikor diaképek előnézeteket generál vagy egy prezentációt olyan formátumokba exportál, mint a PDF és az XPS. Az alapértelmezett betűtípusok a `LoadOptions` segítségével állíthatók be, mielőtt a prezentáció betöltésre kerül.

A `set_DefaultRegularFont` metódus határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a `set_DefaultAsianFont` az ázsiai szöveg alapértelmezett betűtípusát definiálja. Ezeknek a lehetőségeknek a beállítása után a prezentáció betölthető és a megadott betűtípusokkal renderelhető.

## **Alapértelmezett betűtípusok használata egy prezentáció rendereléséhez**

Az Aspose.Slides lehetővé teszi, hogy beállítsa az alapértelmezett betűtípust a prezentáció PDF, XPS vagy bélyegképek formátumba történő rendereléséhez. Ez a cikk bemutatja, hogyan lehet meghatározni a DefaultRegularFont és a DefaultAsianFont betűtípusokat alapértelmezettként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból történő betöltéséhez az Aspose.Slides for C++ API használatával:

1. Hozzon létre egy LoadOptions példányt.
1. Állítsa be a DefaultRegularFont-ot a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.
1. Állítsa be a DefaultAsianFont-ot a kívánt betűtípusra. Az alábbi példában a Wingdings-et használtam.
1. Töltse be a prezentációt a Presentation osztállyal, és állítsa be a betöltési beállításokat.
1. Ezután generálja a diák bélyegképét, a PDF-et és az XPS-et az eredmények ellenőrzéséhez.

A fenti megvalósítás alább található.

```cpp
// Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok megadásához
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

**Pontosan mire hat a DefaultRegularFont és a DefaultAsianFont – csak az exportálásra, vagy a bélyegképekre, PDF-re, XPS-re, HTML-re és SVG-re is?**

Részt vesznek a renderelési csővezetékben minden támogatott kimenetnél. Ez magában foglalja a diák bélyegképeit, a [PDF](/slides/hu/cpp/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/cpp/convert-powerpoint-to-xps/), a [raszteres képeket](/slides/hu/cpp/convert-powerpoint-to-png/), a [HTML](/slides/hu/cpp/convert-powerpoint-to-html/) és a [SVG](/slides/hu/cpp/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt a layout és glif feloldási logikát használja ezeken a célokon.

**Alkalmazzák az alapértelmezett betűtípusok egyszerűen egy PPTX beolvasása és mentése esetén bármilyen renderelés nélkül?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és rajzolni kell. Egy egyszerű megnyitás‑mentés művelet nem változtatja meg a tárolt betűtípus‑futamokat vagy a fájl szerkezetét. Az alapértelmezett betűtípusok akkor lépnek működésbe, amikor a szöveget renderelik vagy újraelrendezik.

**Ha saját betűtípus-mappákat adok hozzá vagy memóriából biztosítok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Egyéni betűtípus források](/slides/hu/cpp/custom-font/) kibővíti a rendelkezésre álló családok és glifyek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és minden [helyettesítő szabályok](/slides/hu/cpp/fallback-font/) először ezekkel a forrásokkal kerülnek egyeztetésre, így megbízhatóbb lefedettséget biztosítanak a szervereken és a konténerekben.

**Hatnak az alapértelmezett betűtípusok a szövegmetrikákra (kerning, advance), és ezáltal a sortörésekre és a tördelésre?**

Igen. A betűtípus megváltoztatása módosítja a glif metrikákat, és befolyásolhatja a sorvágásokat, a tördelést és a lapozást renderelés közben. A layout stabilitása érdekében [beágyazni az eredeti betűtípusokat](/slides/hu/cpp/embedded-font/) vagy olyan metrikailag kompatibilis alapértelmezett és helyettesítő családokat kell választani.

**Van értelme alapértelmezett betűtípusokat beállítani, ha a prezentációban használt összes betűtípus be van ágyazva?**

Gyakran nincs rá szükség, mivel a [beágyazott betűtípusok](/slides/hu/cpp/embedded-font/) már biztosítják a konzisztens megjelenést. Az alapértelmezett betűtípusok továbbra is segítenek biztonsági hálóként azokhoz a karakterekhez, amelyeket a beágyazott részhalmaz nem fed le, vagy ha egy fájl vegyesen tartalmaz beágyazott és nem beágyazott szöveget.