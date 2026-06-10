---
title: Elrendezési dia
type: docs
weight: 20
url: /hu/nodejs-java/examples/elements/layout-slide/
keywords:
- kód példa
- elrendezési dia
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Az Aspose.Slides for Node.js mesterelrendezési diák: válasszon, alkalmazzon és testreszabjon diák elrendezéseit, helyőrzőket és mesterlapokat PPT, PPTX és ODP prezentációk példáival."
---
Ez a cikk bemutatja, hogyan dolgozhat a **Layout Slides** használatával az Aspose.Slides for Node.js via Java környezetben. Egy elrendezési dia meghatározza a normál diák által örökölt tervezést és formázást. Hozzáadhat, elérhet, klónozhat és eltávolíthat elrendezési diákat, valamint megtisztíthatja a nem használtakat a prezentáció méretének csökkentése érdekében.

## **Elrendezési dia hozzáadása**

Létrehozhat egy egyéni elrendezési diát az újrahasznosítható formázás meghatározásához.

```js
function addLayoutSlide() {
    let presentation = new aspose.slides.Presentation();
    try {
        let masterSlide = presentation.getMasters().get_Item(0);

        // Hozzon létre egy elrendezési diát üres elrendezéstípussal és egy egyéni névvel.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().add(masterSlide, layoutType, "Main layout");

        presentation.save("layout_slide.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> 💡 **Megjegyzés 1:** Az elrendezési diák sablonként szolgálnak az egyes diákhoz. A közös elemeket egyszer definiálhatja, és sok dián újra felhasználhatja őket.
> 
> 💡 **Megjegyzés 2:** Amikor alakzatokat vagy szöveget ad hozzá egy elrendezési diához, az az alapján készült összes dia automatikusan megjeleníti ezt a megosztott tartalmat.
> 
> Az alábbi képernyőképen két dia látható, amelyek mindegyike ugyanabból az elrendezési diából származó szövegdobozt örököl.

![Diák, amelyek öröklik az elrendezés tartalmát](layout-slide-result.png)

## **Elrendezési dia elérése**

Az elrendezési diák index vagy elrendezéstípus (például `Blank`, `Title`, `SectionHeader` stb.) alapján érhetők el.

```js
function accessLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Elrendezési dia elérése index szerint.
        let firstLayoutSlide = presentation.getLayoutSlides().get_Item(0);

        // Elrendezési dia elérése típus szerint.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Blank);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
    } finally {
        presentation.dispose();
    }
}
```

## **Elrendezési dia eltávolítása**

Egy adott elrendezési diát eltávolíthat, ha már nincs rá szükség.

```js
function removeLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Szerezzen be egy elrendezési diát típus szerint és távolítsa el.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Custom);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);
        presentation.getLayoutSlides().remove(layoutSlide);

        presentation.save("layout_slide_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Nem használt elrendezési diák eltávolítása**

A prezentáció méretének csökkentése érdekében érdemes eltávolítani azokat az elrendezési diákat, amelyeket egyetlen normál dia sem használ.

```js
function removeUnusedLayoutSlides() {
    let presentation = new aspose.slides.Presentation();
    try {
        // Automatikusan eltávolít minden elrendezési diát, amelyet egyetlen diák sem hivatkozik.
        presentation.getLayoutSlides().removeUnused();

        presentation.save("unused_layout_slides_removed.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

## **Elrendezési dia klónozása**

Az `addClone` metódussal megkettőzheti az elrendezési diát.

```js
function cloneLayoutSlide() {
    let presentation = new aspose.slides.Presentation("layout_slide.pptx");
    try {
        // Szerezzen be egy meglévő elrendezési diát típus szerint.
        let layoutType = java.newByte(aspose.slides.SlideLayoutType.Title);
        let layoutSlide = presentation.getLayoutSlides().getByType(layoutType);

        // Klónozza az elrendezési diát a elrendezési diák gyűjteményének végére.
        let clonedLayoutSlide = presentation.getLayoutSlides().addClone(layoutSlide);

        presentation.save("layout_slide_cloned.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        presentation.dispose();
    }
}
```

> ✅ **Összefoglaló:** Az elrendezési diák hatékony eszközök a konzisztens formázás kezelésére a diák között. Az Aspose.Slides teljes ellenőrzést biztosít az elrendezési diák létrehozása, kezelése és optimalizálása felett.