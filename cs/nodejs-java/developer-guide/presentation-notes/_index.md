---
title: Spravovat poznámky k prezentaci v JavaScriptu
linktitle: Poznámky k prezentaci
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
description: "Přizpůsobte poznámky k prezentaci v JavaScriptu pomocí Aspose.Slides pro Node.js. Bez problémů pracujte s poznámkami PowerPoint a OpenDocument a zvýšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat formátování na existující poznámky. Vývojáři mohou poznámky odstranit následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Pro čtení nebo změnu rozměrů stránky poznámek, změnu orientace a kontrolu chování při exportu viz [Notes Page Size](/slides/cs/nodejs-java/notes-size/).

## **Odstranění poznámek ze snímku**
Poznámky z konkrétního snímku lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoření objektu Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Odstranění poznámek z prvního snímku
    var mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();
    // Uložení prezentace na disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Odstranění poznámek z prezentace**
Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Vytvoření objektu Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("presWithNotes.pptx");
try {
    // Odstranění poznámek ze všech snímků
    var mgr = null;
    for (var i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    // Uložení prezentace na disk
    pres.save("test.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Přidání NotesStyle**
Metoda [getNotesStyle](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide#getNotesStyle--) byla přidána do třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/MasterNotesSlide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Vytvoření objektu Presentation, který představuje soubor prezentace
var pres = new aspose.slides.Presentation("demo.pptx");
try {
    var notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        // Získání stylu textu MasterNotesSlide
        var notesStyle = notesMaster.getNotesStyle();
        // Nastavit symbol bulletu pro odstavce první úrovně
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

## **FAQ**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

K poznámkám se přistupuje přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslidemanager/) a [metodu](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/notesslidemanager/getnotesslide/), která vrací objekt poznámek, nebo `null`, pokud poznámky neexistují.

**Existují rozdíly v podpoře poznámek mezi různými verzemi PowerPointu, se kterými knihovna funguje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97‑a novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.