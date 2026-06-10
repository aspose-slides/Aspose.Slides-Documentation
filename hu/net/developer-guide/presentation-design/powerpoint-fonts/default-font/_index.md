---
title: Alapértelmezett prezentációs betűtípusok megadása .NET-ben
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/net/default-font/
keywords:
- alapértelmezett betűtípus
- normál betűtípus
- szokásos betűtípus
- ázsiai betűtípus
- PDF export
- XPS export
- kép export
- PowerPoint
- OpenDocument
- prezentáció
- .NET
- C#
- Aspose.Slides
description: "Az Aspose.Slides for .NET alapértelmezett betűtípusainak beállítása a megfelelő PowerPoint (PPT, PPTX) és OpenDocument (ODP) konverzió biztosítása érdekében PDF, XPS és képek formátumokra."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi alapértelmezett betűtípusok megadását, amelyeket a bemutató renderelésekor használnak. Ez hasznos dia bélyegképek létrehozásakor vagy a bemutató PDF és XPS formátumokra való exportálásakor. Az alapértelmezett betűtípusok a `LoadOptions` segítségével állíthatók be, mielőtt a bemutató betöltésre kerül.

`DefaultRegularFont` tulajdonság határozza meg az alapértelmezett betűtípust a normál szöveghez, míg a `DefaultAsianFont` az ázsiai szöveg alapértelmezett betűtípusát. Miután ezeket a beállításokat megadta, a bemutató betölthető és renderelhető a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata egy bemutató rendereléséhez**
Aspose.Slides lehetővé teszi az alapértelmezett betűtípus beállítását a bemutató PDF, XPS vagy bélyegképek formátumba való rendereléséhez. Ez a cikk bemutatja, hogyan kell definiálni a DefaultRegularFont és a DefaultAsianFont betűtípusokat alapértelmezettként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból való betöltéséhez az Aspose.Slides for .NET API használatával:

1. Hozzon létre egy LoadOptions példányt.  
2. Állítsa be a DefaultRegularFont-ot a kívánt betűtípusra. Az alábbi példában a Wingdings-ot használtam.  
3. Állítsa be a DefaultAsianFont-ot a kívánt betűtípusra. Az alábbi példában szintén a Wingdings-ot használtam.  
4. Töltse be a bemutatót a Presentation osztály segítségével, a betöltési opciók megadásával.  
5. Ezután generálja a dia bélyegképet, a PDF-et és az XPS-et a eredmények ellenőrzéséhez.  

A fenti megvalósítás alább található.

```c#
// Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok megadásához
LoadOptions loadOptions = new LoadOptions(LoadFormat.Auto);
loadOptions.DefaultRegularFont = "Wingdings";
loadOptions.DefaultAsianFont = "Wingdings";

using (Presentation pptx = new Presentation("DefaultFonts.pptx", loadOptions))
{
    using (IImage image = pptx.Slides[0].GetImage(1, 1))
    {
        image.Save("DefaultFonts_out.png", ImageFormat.Png);
    }

    pptx.Save("DefaultFonts_out.pdf", SaveFormat.Pdf);
    pptx.Save("DefaultFonts_out.xps", SaveFormat.Xps);
}
```

## **GYIK**

**A DefaultRegularFont és a DefaultAsianFont pontosan mit érint – csak az exportot, vagy a bélyegképeket, PDF-et, XPS-et, HTML-t és SVG-t is?**  
Részt vesznek a renderelési csővezetékben minden támogatott kimenet esetén. Ez magában foglalja a dia bélyegképeket, a [PDF](/slides/hu/net/convert-powerpoint-to-pdf/), a [XPS](/slides/hu/net/convert-powerpoint-to-xps/), a [raszter képeket](/slides/hu/net/convert-powerpoint-to-png/), a [HTML](/slides/hu/net/convert-powerpoint-to-html/), és a [SVG](/slides/hu/net/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt az elrendezési és glyf feloldási logikát használja ezeken a célokon.

**Alapértelmezett betűtípusok alkalmazásra kerülnek, ha csak egy PPTX-et olvasunk és mentünk, anélkül hogy renderelnénk?**  
Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és rajzolni kell. Egy egyszerű megnyitás‑mentés nem módosítja a tárolt betűtípus-futtatásokat vagy a fájl szerkezetét. Az alapértelmezett betűtípusok akkor lépnek működésbe, amikor a szöveg renderelését vagy újrafolyását végző műveletek történnek.

**Ha saját betűtípus mappákat adok hozzá, vagy memóriából szolgáltatok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**  
Igen. A [Custom font sources](/slides/hu/net/custom-font/) kibővítik a rendelkezésre álló családok és glyfek katalógusát, amelyet a motor használhat. Az alapértelmezett betűtípusok és minden [fallback rules](/slides/hu/net/fallback-font/) először ezeken a forrásokon keresztül kerülnek feloldásra, ami megbízhatóbb lefedettséget biztosít a szervereken és konténerekben.

**Az alapértelmezett betűtípusok befolyásolják a szöveg metrikáit (kerning, előrehaladások), és ezáltal a sortöréseket és a tördelést?**  
Igen. A betűtípus módosítása megváltoztatja a glif metrikákat, ami befolyásolhatja a sortöréseket, a tördelést és a lapozást renderelés közben. A elrendezés stabilitása érdekében [embed the original fonts](/slides/hu/net/embedded-font/) vagy válasszon metrikailag kompatibilis alap- és visszatérő családokat.

**Van értelme alapértelmezett betűtípusokat beállítani, ha a bemutatóban használt összes betűtípus be van ágyazva?**  
Gyakran nincs szükség rá, mivel a [embedded fonts](/slides/hu/net/embedded-font/) már biztosítja a konzisztens megjelenést. Az alapértelmezett betűtípusok továbbra is hasznosak védőhálóként azokhoz a karakterekhez, amelyek nincsenek lefedve a beágyazott részhalmazban, vagy amikor egy fájl keveri a beágyazott és a nem beágyazott szöveget.