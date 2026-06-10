---
title: JavaScript-ben a bemutató jegyzeteinek kezelése
linktitle: Bemutató jegyzetek
type: docs
weight: 110
url: /hu/nodejs-java/presentation-notes/
keywords:
- jegyzetek
- jegyzet dia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzet stílus
- fő jegyzetek
- PowerPoint
- OpenDocument
- bemutató
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabhatja a bemutató jegyzeteit JavaScript-ben az Aspose.Slides for Node.js segítségével. Zökkenőmentesen dolgozhat a PowerPoint és OpenDocument jegyzetekkel, hogy növelje a hatékonyságát."
---
## **Áttekintés**

Aspose.Slides támogatja a jegyzetdiák eltávolítását egy bemutatóból. Ebben a témában bemutatjuk ezt a funkciót, beleértve, hogyan távolítható el a jegyzet, illetve hogyan alkalmazható stílus a jegyzetdiákra egy bemutatóban. Az Aspose.Slides lehetővé teszi, hogy jegyzeteket távolítson el bármely diáról, valamint alkalmazzon formázást a meglévő jegyzetekre. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Jegyzetek eltávolítása egy adott diáról egy bemutatóban.
- Jegyzetek eltávolítása az összes diáról egy bemutatóban.

## **Jegyzetek eltávolítása diáról**
Az egyes diák jegyzetei eltávolíthatók, ahogy az alábbi példában látható:

```javascript
// Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Az első dia jegyzeteinek eltávolítása
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // A bemutató mentése lemezre
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Jegyzetek eltávolítása a bemutatóból**
A bemutató összes diájának jegyzetei eltávolíthatók, ahogy az alábbi példában látható:

```javascript
// Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Az összes dia jegyzeteinek eltávolítása
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // A bemutató mentése lemezre
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **NotesStyle hozzáadása**
[getNotesStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metódus hozzá lett adva a [MasterNotesSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterNotesSlide) osztályhoz, és a [MasterNotesSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság meghatározza egy jegyzet szövegének stílusát. A megvalósítást az alábbi példában mutatjuk be.

```javascript
// Hozzon létre egy Presentation objektumot, amely egy bemutató fájlt képvisel
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // A MasterNotesSlide szövegstílusának lekérése
        var notesStyle = notesMaster.getNotesStyle();
        // Szimbólum típusú golyó beállítása az első szintű bekezdésekhez
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(aspose.slides.BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Melyik API entitás biztosítja a hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diának van egy [NotesSlideManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslidemanager/) és egy [metódus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/) amely visszaadja a jegyzetobjektumot, vagy `null`, ha nincsenek jegyzetek.

**Vannak különbségek a jegyzetek támogatásában a könyvtár által támogatott PowerPoint verziók között?**

A könyvtár a Microsoft PowerPoint széles körű formátumait (97‑újabb) és az ODP‑t célozza; a jegyzetek támogatottak ezekben a formátumokban, anélkül, hogy a PowerPoint telepített példányára támaszkodna.