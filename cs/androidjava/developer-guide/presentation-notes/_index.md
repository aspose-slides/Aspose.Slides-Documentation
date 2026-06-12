---
title: Správa poznámek k prezentaci na Androidu
linktitle: Poznámky k prezentaci
type: docs
weight: 110
url: /cs/androidjava/presentation-notes/
keywords:
- poznámky
- poznámkový snímek
- přidat poznámky
- odebrat poznámky
- styl poznámek
- hlavní poznámky
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Přizpůsobte si poznámky k prezentaci pomocí Aspose.Slides pro Android v Javě. Plynule pracujte s poznámkami PowerPoint a OpenDocument a zvyšte svou produktivitu."
---
## **Přehled**

Aspose.Slides podporuje odstraňování poznámkových snímků z prezentace. V tomto tématu představíme tuto funkci, včetně toho, jak odstranit poznámky a jak použít styl na poznámkové snímky v prezentaci. Aspose.Slides vám umožňuje odstranit poznámky z libovolného snímku a také aplikovat stylování na existující poznámky. Vývojáři mohou poznámky odstranit následujícími způsoby:

- Odstranit poznámky ze specifického snímku v prezentaci.
- Odstranit poznámky ze všech snímků v prezentaci.

## **Odstranit poznámky ze snímku**
Poznámky z konkrétního snímku lze odstranit, jak je ukázáno v příkladu níže:

```java
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

## **Odstranit poznámky z prezentace**
Poznámky ze všech snímků v prezentaci lze odstranit, jak je ukázáno v příkladu níže:

```java
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

## **Přidat styl poznámek**
Metoda [getNotesStyle](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMasterNotesSlide#getNotesStyle--) byla přidána do rozhraní [IMasterNotesSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IMasterNotesSlide) a třídy [MasterNotesSlide](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/MasterNotesSlide). Tato vlastnost určuje styl textu poznámek. Implementace je demonstrována v níže uvedeném příkladu.

```java
// Vytvořte objekt Presentation, který představuje soubor prezentace
Presentation pres = new Presentation("demo.pptx");
try {
    IMasterNotesSlide notesMaster = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    
    if (notesMaster != null)
    {
        // Získat styl textu MasterNotesSlide
        ITextStyle notesStyle = notesMaster.getNotesStyle();
    
        // Nastavit symbolový odrážkový znak pro odstavce první úrovně
        IParagraphFormat paragraphFormat = notesStyle.getLevel(0);
        paragraphFormat.getBullet().setType(BulletType.Symbol);
    }
    pres.save("NotesSlideWithNotesStyle.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Který objekt API poskytuje přístup k poznámkám konkrétního snímku?**

Poznámky jsou přístupné prostřednictvím správce poznámek snímku: snímek má [NotesSlideManager](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notesslidemanager/) a [method](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notesslidemanager/#getNotesSlide--) která vrací objekt poznámek, nebo `null`, pokud poznámky neexistují.

**Existují rozdíly v podpoře poznámek mezi verzemi PowerPoint, se kterými knihovna pracuje?**

Knihovna cílí na širokou škálu formátů Microsoft PowerPoint (97 a novější) a ODP; poznámky jsou v těchto formátech podporovány bez závislosti na nainstalované kopii PowerPointu.