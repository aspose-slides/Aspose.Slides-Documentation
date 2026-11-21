---
title: Prezentációjegyzetek kezelése JavaScriptben
linktitle: Prezentációjegyzetek
type: docs
weight: 110
url: /hu/nodejs-java/presentation-notes/
keywords:
- jegyzetek
- jegyzetdia
- jegyzetek hozzáadása
- jegyzetek eltávolítása
- jegyzetstílus
- mesterjegyzetek
- PowerPoint
- OpenDocument
- prezentáció
- Node.js
- JavaScript
- Aspose.Slides
description: "Testreszabhatja a prezentációjegyzeteket JavaScriptben az Aspose.Slides for Node.js segítségével. Zökkenőmentesen dolgozhat PowerPoint és OpenDocument jegyzetekkel a hatékonyság növelése érdekében."
---
## **Áttekintés**

Az Aspose.Slides támogatja a jegyzetdiák eltávolítását egy bemutatóból. Ebben a témában bemutatjuk ezt a funkciót, beleértve a jegyzetek eltávolítását és a jegyzetdiákra való stílusalkalmazást egy bemutatóban. Az Aspose.Slides lehetővé teszi a jegyzetek eltávolítását bármely diáról, valamint a meglévő jegyzetek stílusának alkalmazását. A fejlesztők a következő módokon távolíthatják el a jegyzeteket:

- Egy adott dia jegyzeteinek eltávolítása egy bemutatóban.
- Az összes dia jegyzeteinek eltávolítása egy bemutatóban.

A jegyzetoldal méretének olvasásához vagy módosításához, az orientáció váltásához és az export viselkedésének ellenőrzéséhez lásd a [Jegyzetoldal Mérete](/slides/hu/nodejs-java/notes-size/) oldalt.

## **Jegyzetek eltávolítása egy diáról**
Egy adott diáról a jegyzetek a lenti példában látható módon távolíthatók el:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Az első dia jegyzeteinek eltávolítása
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // A prezentáció mentése lemezre
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Jegyzetek eltávolítása egy bemutatóból**
Az összes diáról a jegyzetek a lenti példában látható módon távolíthatók el:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

//    Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    //    Az összes dia jegyzeteinek eltávolítása
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    //    A prezentáció mentése lemezre
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Jegyzetstílus hozzáadása**
[getNotesStyle](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metódus lett hozzáadva a [MasterNotesSlide](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/MasterNotesSlide) osztályhoz. Ez a tulajdonság a jegyzet szövegének stílusát határozza meg. A megvalósítást a lenti példa mutatja be.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Létrehozza a Presentation objektumot, amely egy prezentációs fájlt képvisel
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Lekéri a MasterNotesSlide szövegstílusát
        var notesStyle = notesMaster.getNotesStyle();
        // Szimbólum pontot állít be az első szintű bekezdésekhez
        var paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(java.newByte(aspose.slides.BulletType.Symbol));
    }
    pres.save("NotesSlideWithNotesStyle.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **GYIK**

**Melyik API entitás biztosít hozzáférést egy adott dia jegyzeteihez?**

A jegyzetek a dia jegyzetkezelőjén keresztül érhetők el: a diához tartozik egy [NotesSlideManager](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslidemanager/) és egy [metódus](https://reference.aspose.com/slides/hu/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), amely visszaadja a jegyzetobjektumot, vagy `null` értéket, ha nincsenek jegyzetek.

**Vannak-e különbségek a jegyzetek támogatásában a különböző PowerPoint verziók között, amelyeken a könyvtár működik?**

A könyvtár széles körű Microsoft PowerPoint formátumot (97‑től napjainkig) és ODP‑t támogat; a jegyzetek ezeken a formátumokon belül támogatottak, függetlenül attól, hogy a felhasználó telepítve rendelkezik‑e PowerPoint példánnyal.