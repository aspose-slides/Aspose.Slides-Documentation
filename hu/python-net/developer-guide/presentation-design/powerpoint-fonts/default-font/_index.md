---
title: Alapértelmezett betűtípusok testreszabása a prezentációkban Python segítségével
linktitle: Alapértelmezett betűtípus
type: docs
weight: 30
url: /hu/python-net/default-font/
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
- Python
- Aspose.Slides
description: "Állítsa be az alapértelmezett betűtípusokat az Aspose.Slides for Python-ban, hogy biztosítsa a PowerPoint (PPT, PPTX) és OpenDocument (ODP) megfelelő konvertálását PDF, XPS és képek formátumokra."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy megadja az alapértelmezett betűtípusokat, amelyeket a prezentáció renderelésekor használnak. Ez hasznos a diakép bélyegképek generálásakor vagy a prezentáció PDF és XPS formátumokba történő exportálásakor. Az alapértelmezett betűtípusokat a `LoadOptions` segítségével konfigurálják, mielőtt a prezentáció betöltődik.

`default_regular_font` tulajdonság meghatározza az alapértelmezett betűtípust a normál szöveghez, míg a `default_asian_font` meghatározza az alapértelmezett betűtípust az ázsiai szöveghez. Miután ezeket a beállításokat megadta, a prezentáció betölthető és renderelhető a megadott betűtípusokkal.

## **Alapértelmezett betűtípusok használata a prezentáció rendereléséhez**
Az Aspose.Slides lehetővé teszi, hogy beállítsa az alapértelmezett betűtípust a prezentáció PDF, XPS vagy bélyegképek formátumba való rendereléséhez. Ez a cikk bemutatja, hogyan kell meghatározni a DefaultRegular Font és a DefaultAsian Font betűtípusokat alapértelmezettként. Kérjük, kövesse az alábbi lépéseket a betűtípusok külső könyvtárakból történő betöltéséhez az Aspose.Slides for Python via .NET API használatával:

1. Hozzon létre egy LoadOptions példányt.
2. Állítsa be a DefaultRegularFont-ot a kívánt betűtípusra. A következő példában a Wingdings betűtípust használtam.
3. Állítsa be a DefaultAsianFont-ot a kívánt betűtípusra. A következő példában a Wingdings betűtípust használtam.
4. Töltse be a prezentációt a Presentation használatával, és állítsa be a betöltési opciókat.
5. Ezután generálja a diaképet bélyegképet, PDF-et és XPS-t az eredmények ellenőrzéséhez.

A fenti megvalósítás alább látható.

```py
import aspose.slides as slides

# Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához# Használja a betöltési beállításokat az alapértelmezett normál és ázsiai betűtípusok meghatározásához
loadOptions = slides.LoadOptions(slides.LoadFormat.AUTO)
loadOptions.default_regular_font = "Wingdings"
loadOptions.default_asian_font = "Wingdings"

# Töltse be a prezentációt
with slides.Presentation(path + "DefaultFonts.pptx", loadOptions) as pptx:
    # Generálja a dia bélyegképét
    with pptx.slides[0].get_image(1, 1) as img:
        img.save("output_out.png", slides.ImageFormat.PNG)

    # Generálja a PDF-et
    pptx.save("output_out.pdf", slides.export.SaveFormat.PDF)

    # Generálja az XPS-t
    pptx.save("output_out.xps", slides.export.SaveFormat.XPS)
```

## **GYIK**

**A default_regular_font és a default_asian_font pontosan milyen hatással van – csak az exportálásra, vagy a bélyegképekre, PDF-re, XPS-re, HTML-re és SVG-re is?**

Részt vesznek a renderelési csővezetékben minden támogatott kimenethez. Ez magában foglalja a diaképek bélyegképeit, [PDF](/slides/hu/python-net/convert-powerpoint-to-pdf/), [XPS](/slides/hu/python-net/convert-powerpoint-to-xps/), [raszteres képeket](/slides/hu/python-net/convert-powerpoint-to-png/), [HTML](/slides/hu/python-net/convert-powerpoint-to-html/), és [SVG](/slides/hu/python-net/render-a-slide-as-an-svg-image/) formátumokat, mivel az Aspose.Slides ugyanazt a layout és glif feloldási logikát használja ezeken a célokon.

**Alkalmazzák-e az alapértelmezett betűtípusok, ha csak egy PPTX-et olvasunk és mentünk renderelés nélkül?**

Nem. Az alapértelmezett betűtípusok csak akkor számítanak, ha a szöveget mérni és megrajzolni kell. Egy egyszerű megnyitás‑mentés nem módosítja a tárolt betűtípus‑futtatásokat vagy a fájl struktúráját. Az alapértelmezett betűtípusok akkor lépnek működésbe, amikor a szöveget rendereli vagy újra folyósítja.

**Ha saját betűtípus‑mappákat adok hozzá vagy memóriából biztosítok betűtípusokat, figyelembe veszik ezeket az alapértelmezett betűtípusok kiválasztásakor?**

Igen. A [Custom font sources](/slides/hu/python-net/custom-font/) kibővíti a rendelkezésre álló családok és glifek katalógusát, amelyeket a motor használhat. Az alapértelmezett betűtípusok és minden [fallback rules](/slides/hu/python-net/fallback-font/) először ezektől a forrásoktól fognak feloldódni, ami megbízhatóbb lefedettséget biztosít a szervereken és konténerekben.

**Hatással lesznek-e az alapértelmezett betűtípusok a szövegmetrikákra (kerning, eltolások), és ezáltal a sorok törésére és a sortörésre?**

Igen. A betűtípus megváltoztatása módosítja a glif metrikákat, és módosíthatja a sorvégeket, a sortörést és a lapozást a renderelés során. A layout stabilitásáért [embed the original fonts](/slides/hu/python-net/embedded-font/) vagy válasszon metrikailag kompatibilis alapértelmezett és tartalék családokat.

**Van-e értelme alapértelmezett betűtípusokat beállítani, ha a prezentációban használt összes betűtípus be van ágyazva?**

Gyakran nem szükséges, mivel a [embedded fonts](/slides/hu/python-net/embedded-font/) már biztosítja a konzisztens megjelenést. Az alapértelmezett betűtípusok továbbra is hasznosak biztonsági hálóként azokhoz a karakterekhez, amelyeket a beágyazott részhalmaz nem fed le, vagy amikor egy fájl keveri a beágyazott és nem beágyazott szöveget.