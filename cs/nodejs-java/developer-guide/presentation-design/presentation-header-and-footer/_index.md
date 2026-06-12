---
title: Spravovat záhlaví a zápatí prezentace v JavaScriptu
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/nodejs-java/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- podklady
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Použijte JavaScript a Aspose.Slides pro Node.js k přidání a přizpůsobení záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí jsou řízena na úrovni hlavního masteru prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na master snímcích poznámek.

Můžete také spravovat záhlaví a zápatí pro podklady a poznámkové snímky. To zahrnuje změnu viditelnosti a textu zástupných polí záhlaví, zápatí, čísla snímku a data/času pro master poznámek, všechny podřízené poznámkové snímky nebo jednotlivý poznámkový snímek.

## **Správa záhlaví a zápatí v prezentaci**
Poznámky některých konkrétních snímků lze odstranit, jak ukazuje příklad níže:

```javascript
// Načíst prezentaci
var pres = new aspose.slides.Presentation("headerTest.pptx");
try {
    // Nastavení zápatí
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);
    // Přístup a aktualizace záhlaví
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide) {
        updateHeaderFooterText(masterNotesSlide);
    }
    // Uložit prezentaci
    pres.save("HeaderFooterJava.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```
```javascript
function updateHeaderFooterText(master) {
    let shapes = master.getShapes();
    for (let i = 0; i < shapes.size(); i++) {
        let shape = shapes.get_Item(i); 
        if (shape.getPlaceholder() !== null) {
            if (shape.getPlaceholder().getType() === aspose.PlaceholderType.Header) {
                shape.getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Správa záhlaví a zápatí v podklady a poznámkových snímcích**
Aspose.Slides pro Node.js přes Java podporuje záhlaví a zápatí v podkladech a poznámkových snímcích. Postupujte podle níže uvedených kroků:

- Načtěte [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation) obsahující video.
- Změňte nastavení záhlaví a zápatí pro master poznámek a všechny poznámkové snímky.
- Nastavte, aby byl viditelný master poznámkový snímek a všechny podřízené zástupné pole zápatí.
- Nastavte, aby byl viditelný master poznámkový snímek a všechny podřízené zástupné pole datum a čas.
- Změňte nastavení záhlaví a zápatí jen pro první poznámkový snímek.
- Nastavte viditelnost zástupného pole záhlaví poznámkového snímku.
- Nastavte text pro zástupné pole záhlaví poznámkového snímku.
- Nastavte text pro zástupné pole datum‑čas poznámkového snímku.
- Zapište upravený soubor prezentace.

Ukázkový kód je uveden v následujícím příkladu.

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    // Změnit nastavení záhlaví a zápatí pro master poznámek a všechny poznámkové snímky
    var masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null) {
        var headerFooterManager = masterNotesSlide.getHeaderFooterManager();
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);// zobrazit master poznámkový snímek a všechna podřízená zástupná pole zápatí
        headerFooterManager.setFooterAndChildFootersVisibility(true);// zobrazit master poznámkový snímek a všechna podřízená zástupná pole záhlaví
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);// zobrazit master poznámkový snímek a všechna podřízená zástupná pole čísla snímku
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);// zobrazit master poznámkový snímek a všechna podřízená zástupná pole data a času
        headerFooterManager.setHeaderAndChildHeadersText("Header text");// nastavit text pro master poznámkový snímek a všechna podřízená zástupná pole záhlaví
        headerFooterManager.setFooterAndChildFootersText("Footer text");// nastavit text pro master poznámkový snímek a všechna podřízená zástupná pole zápatí
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");// nastavit text pro master poznámkový snímek a všechna podřízená zástupná pole data a času
    }
    // Změnit nastavení záhlaví a zápatí pro první poznámkový snímek pouze
    var notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null) {
        var headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible()) {
            headerFooterManager.setHeaderVisibility(true);
        }// zobrazit zástupné pole záhlaví tohoto poznámkového snímku
        if (!headerFooterManager.isFooterVisible()) {
            headerFooterManager.setFooterVisibility(true);
        }// zobrazit zástupné pole zápatí tohoto poznámkového snímku
        if (!headerFooterManager.isSlideNumberVisible()) {
            headerFooterManager.setSlideNumberVisibility(true);
        }// zobrazit zástupné pole čísla snímku tohoto poznámkového snímku
        if (!headerFooterManager.isDateTimeVisible()) {
            headerFooterManager.setDateTimeVisibility(true);
        }// zobrazit zástupné pole datum‑čas tohoto poznámkového snímku
        headerFooterManager.setHeaderText("New header text");// nastavit text pro zástupné pole záhlaví poznámkového snímku
        headerFooterManager.setFooterText("New footer text");// nastavit text pro zástupné pole zápatí poznámkového snímku
        headerFooterManager.setDateTimeText("New date and time text");// nastavit text pro zástupné pole datum‑čas poznámkového snímku
    }
    pres.save("testresult.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mohu přidat „záhlaví“ k běžným snímkům?**

V PowerPointu existuje „Záhlaví“ pouze pro poznámky a podklady; na běžných snímcích jsou podporovány pouze zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví jen pro Notes/Handout a na snímcích – Footer/DateTime/SlideNumber.

**Co když rozvržení neobsahuje oblast zápatí — mohu „zapnout“ její viditelnost?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví/zápatí a případně ji povolte. Tyto indikátory a metody API jsou navrženy pro situace, kdy je zástupné pole chybějící nebo skryté.

**Jak nastavit, aby číslování snímků začínalo hodnotou jinou než 1?**

Nastavte [first slide number](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/setfirstslidenumber/) prezentace; poté se všechny čísla přepočítají. Například můžete začít od 0 nebo 10 a číslo na titulním snímku skrýt.

**Co se stane se záhlavími/zápatími při exportu do PDF/obrázků/HTML?**

Jsou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na snímcích/stránkách poznámek, objeví se také v exportovaném formátu spolu se zbytkem obsahu.