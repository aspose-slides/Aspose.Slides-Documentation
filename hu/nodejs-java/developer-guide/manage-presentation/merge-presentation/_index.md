---
title: Hatékony bemutatók egyesítése JavaScript-ben
linktitle: Bemutatók egyesítése
type: docs
weight: 40
url: /hu/nodejs-java/merge-presentation/
keywords:
- PowerPoint egyesítése
- bemutatók egyesítése
- diák egyesítése
- PPT egyesítése
- PPTX egyesítése
- ODP egyesítése
- PowerPoint összevonása
- bemutatók összevonása
- diák összevonása
- PPT összevonása
- PPTX összevonása
- ODP összevonása
- Node.js
- JavaScript
- Aspose.Slides
description: "Könnyedén egyesítheti a PowerPoint (PPT, PPTX) és OpenDocument (ODP) bemutatókat JavaScript-ben az Aspose.Slides for Node.js segítségével, egyszerűsítve a munkafolyamatát."
---
## **Áttekintés**

Az Aspose.Slides lehetővé teszi, hogy bemutatókat egyesítsen azáltal, hogy egy bemutató diáját egy másikba klónozza. Ez a cikk elmagyarázza, hogyan lehet teljes bemutatókat vagy kiválasztott diákot egyesíteni, a diamestert vagy egy adott elrendezést használni az egyesítés során, különböző diaméretekkel rendelkező bemutatókat kezelni, és az egyesített diát egy bemutató szekciójához adni. Emellett gyakorlati megjegyzéseket tartalmaz az egyesített tartalommal kapcsolatban, beleértve az előadói jegyzeteket, megjegyzéseket, jelszóval védett forrásfájlokat és a szálhasználatot.

## **Bemutatók egyesítése**

Amikor egy bemutatót egy másikba egyesít, gyakorlatilag egyetlen bemutatóba egyesíti a diákat, hogy egy fájlt kapjon.

{{% alert title="Info" color="info" %}}

A legtöbb bemutatóprogram (PowerPoint vagy OpenOffice) nem rendelkezik olyan funkcióval, amely lehetővé tenné a felhasználók számára, hogy ilyen módon egyesítsék a bemutatókat.

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/hu/nodejs-java/), azonban lehetővé teszi a bemutatók különböző módon történő egyesítését. Megkapja a lehetőséget, hogy a bemutatókat az összes alakzatukkal, stílusukkal, szövegükkel, formázásukkal, megjegyzéseikkel, animációikkal stb. egyesítse, anélkül hogy a minőség vagy az adatok elvesztésétől kellene aggódnia.

**Lásd még**

[Dia másolása](https://docs.aspose.com/slides/hu/nodejs-java/clone-slides/).

{{% /alert %}}

### **Mi egyesíthető**

Az Aspose.Slides használatával a következőket egyesítheti

* teljes bemutatókat. A bemutatók összes diája egy bemutatóba kerül.
* konkrét diák. A kiválasztott diák egy bemutatóba kerülnek.
* bemutatókat ugyanabban a formátumban (PPT → PPT, PPTX → PPTX stb.) és különböző formátumokban (PPT → PPTX, PPTX → ODP stb.) egymás felé.

### **Egyesítési beállítások**

Alkalmazhat beállításokat, amelyek meghatározzák, hogy

* az eredménybemutató minden diája megőrizze az egyedi stílusát
* egy adott stílus legyen használva az összes dián az eredménybemutatóban. 

Az egyesítéshez az Aspose.Slides a [addClone](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódusokat biztosítja (a [SlideCollection](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection) osztályból). Több implementációja létezik a `addClone` metódusoknak, amelyek meghatározzák az egyesítési folyamat paramétereit. Minden Presentation objektumnak van egy [Slides](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/Presentation#getSlides--) gyűjteménye, így a kívánt prezentáció `addClone` metódusát hívhatja meg a diák egyesítéséhez.

Az `addClone` metódus egy `Slide` objektumot ad vissza, amely a forrásdia klónja. A kimeneti prezentáció diái egyszerűen a forrás diák másolatai, így a létrehozott diákon módosításokat (pl. stílusok, formázási beállítások vagy elrendezések alkalmazása) végezhet anélkül, hogy a forrás prezentációkat befolyásolná.

## **Bemutatók egyesítése** 

Az Aspose.Slides a [**AddClone(ISlide)**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) metódust biztosítja, amely lehetővé teszi a diák kombinálását úgy, hogy azok megőrzik az elrendezésüket és stílusukat (alapértelmezett paraméterek).

Ez a JavaScript kód bemutatja, hogyan egyesíthetők a bemutatók:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Bemutatók egyesítése diamesterrel** 

Az Aspose.Slides a [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) metódust biztosítja, amely lehetővé teszi a diák kombinálását miközben egy diamester sablont alkalmaz. Így szükség esetén megváltoztathatja a kimeneti prezentáció diáinak stílusát.

Ez a JavaScript kód bemutatja a leírt műveletet:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 
A diamester elrendezése automatikusan kerül meghatározásra. Ha megfelelő elrendezés nem állapítható meg, és a `allowCloneMissingLayout` logikai paraméter igazra van állítva, akkor a forrásdia elrendezése lesz használva. Ellenkező esetben a [PptxEditException](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/PptxEditException) kivétel kerül dobásra.
{{% /alert %}}

Ha a kimeneti prezentáció diáinak más elrendezése kell, használja a [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) metódust az egyesítéskor.

## **Speciális diák egyesítése bemutatókból** 

Speciális diák több bemutatóból való egyesítése hasznos egyedi diavetítések létrehozásához. Az Aspose.Slides for Node.js via Java lehetővé teszi, hogy csak a szükséges diák kiválasztásával és importálásával dolgozzon. Az API megőrzi az eredeti diák formázását, elrendezését és dizájnját.

A következő JavaScript kód létrehoz egy új bemutatót, hozzáadja a két másik bemutató cím-diáit, és elmenti az eredményt egy fájlba:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Bemutatók egyesítése diák elrendezésével** 

Ez a JavaScript kód bemutatja, hogyan kombinálhatók a diák a bemutatókból, miközben az Ön által preferált diák elrendezését alkalmazzák, hogy egy kimeneti bemutatót kapjon:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Bemutatók egyesítése különböző diaméretekkel** 

{{% alert title="Note" color="warning" %}} 
Nem egyesíthetőek a különböző diaméretekkel rendelkező bemutatók. 
{{% /alert %}}

Két különböző diaméretű bemutató egyesítéséhez át kell méretezni az egyik bemutatót, hogy mérete megegyezzen a másikéval. 

Ez a példakód bemutatja a leírt műveletet:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Diák egyesítése bemutató szekcióba** 

Ez a JavaScript kód bemutatja, hogyan egyesíthető egy adott dia a bemutató egy szekciójába:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

A diát a szekció végére helyezi el.

## **GYIK**

**Megőrzik-e az előadói jegyzetek az egyesítés során?**

Igen. A diák klónozásakor az Aspose.Slides átviszi az összes diaképet, beleértve a jegyzeteket, formázást és animációkat.

**A megjegyzések és szerzőik átkerülnek?**

A megjegyzések, mint a dia tartalmának része, a diával együtt másolódnak. A megjegyzés szerzőjének címkéi megmaradnak megjegyzésobjektumként a létrehozott bemutatóban.

**Mi van, ha a forrás bemutató jelszóval van védve?**

Meg kell [jelszóval megnyitni](/slides/hu/nodejs-java/password-protected-presentation/) a [LoadOptions.setPassword](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/loadoptions/setpassword/) segítségével; betöltés után azok a diák biztonságosan klónozhatók egy védtelen célfájlba (vagy védett fájlba is).

**Mennyire szálbiztos az egyesítési művelet?**

Ne használja ugyanazt a [Presentation](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/presentation/) példányt [több szálról](/slides/hu/nodejs-java/multithreading/). Az ajánlott szabály: „egy dokumentum – egy szál”; különböző fájlok párhuzamosan feldolgozhatók külön szálakon.

## **Lásd még**

Az Aspose egy [FREE Online Collage Maker](https://products.aspose.app/slides/hu/collage) szolgáltatást kínál. Ezzel az online eszközzel [JPG‑t JPG‑re](https://products.aspose.app/slides/hu/collage/jpg) vagy PNG‑t PNG‑re egyesíthet, [fotó‑rácsokat](https://products.aspose.app/slides/hu/collage/photo-grid) hozhat létre, és még sok más funkciót használhat.

Nézze meg az [Aspose FREE Online Merger](https://products.aspose.app/slides/hu/merger) oldalt. Lehetővé teszi PowerPoint bemutatók egyesítését ugyanabban a formátumban (pl. PPT → PPT, PPTX → PPTX) vagy különböző formátumok között (pl. PPT → PPTX, PPTX → ODP).

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/hu/merger)