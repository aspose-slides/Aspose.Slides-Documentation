---
title: Správa poznámek prezentace v Javě
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/java/presentation-notes/
keywords:
- poznámky
- poznámkový snímek
- přidat poznámky
- odstranit poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Přizpůsobte si poznámky k prezentaci pomocí Aspose.Slides pro Javu. Bezproblémově pracujte s poznámkami v PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou odstraňovat poznámky následujícími způsoby:

- Odstranit poznámky z konkrétního snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

Pro přečtení nebo změnu rozměrů stránky s poznámkami, změnu orientace a kontrolu chování exportu viz [Notes Page Size](/slides/cs/java/notes-size/).

## **Odstranění poznámek ze snímku**
Poznámky z konkrétního snímku lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Odstranění poznámek z prvního snímku
    INotesSlideManager mgr = pres.getSlides().get_Item(0).getNotesSlideManager();
    mgr.removeNotesSlide();

    // Uložení prezentace na disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Odstranění poznámek z prezentace**
Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("presWithNotes.pptx");
try {
    // Odstranění poznámek ze všech snímků
    INotesSlideManager mgr = null;
    for (int i = 0; i < pres.getSlides().size(); i++) {
        mgr = pres.getSlides().get_Item(i).getNotesSlideManager();
        mgr.removeNotesSlide();
    }
    
    // Uložení prezentace na disk
    pres.save("test.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Přidání stylu poznámek**
Metoda [getNotesStyle](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) byla přidána do rozhraní [IMasterNotesSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IMasterNotesSlide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/java/com.aspose.slides/MasterNotesSlide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```java
import com.aspose.slides.*;

// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Získejte styl textu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Nastavit symbolovou odrážku pro odstavce první úrovně
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Která entita API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné přes správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notesslidemanager/) a [metodu](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notesslidemanager/#getNotesSlide--) která vrací objekt poznámek, nebo `null`, pokud poznámky neexistují.

**Existují rozdíly v podpoře poznámek napříč verzemi PowerPointu, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97‑novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.