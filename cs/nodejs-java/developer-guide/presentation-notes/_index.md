---
title: Správa poznámek prezentace v JavaScriptu
linktitle: Poznámky prezentace
type: docs
weight: 110
url: /cs/nodejs-java/presentation-notes/
keywords:
- poznámky
- snímek s poznámkami
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Přizpůsobte si poznámky prezentace v JavaScriptu pomocí Aspose.Slides pro Node.js. Bez problémů pracujte s poznámkami PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování snímků s poznámkami z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na snímky s poznámkami v prezentaci. Aspose.Slides umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstranit poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranění poznámek ze snímku**
Poznámky některého konkrétního snímku lze odstranit, jak ukazuje příklad níže:

```javascript
// Vytvořte objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Odstraňování poznámek z prvního snímku
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Ukládání prezentace na disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění poznámek z prezentace**
Poznámky ze všech snímků prezentace lze odstranit, jak ukazuje příklad níže:

```javascript
// Vytvořte objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Odstraňování poznámek ze všech snímků
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Ukládání prezentace na disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání NotesStyle**
[getNotesStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) metoda byla přidána do třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v příkladu níže.

```javascript
// Vytvořte objekt Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Získat styl textu MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Nastavit symbolový odrážkový znak pro odstavce první úrovně
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

## **Často kladené otázky**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslidemanager/) a [method](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), která vrací objekt poznámek, nebo `null`, pokud poznámky neexistují.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna funguje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97–novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.