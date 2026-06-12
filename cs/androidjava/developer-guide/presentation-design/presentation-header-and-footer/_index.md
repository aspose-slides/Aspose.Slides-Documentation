---
title: Správa záhlaví a zápatí prezentace na Androidu
linktitle: Záhlaví & Zápatí
type: docs
weight: 140
url: /cs/androidjava/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- leták
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Android přes Java k přidání a přizpůsobení záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí jsou zpracovávány na úrovni hlavního motivu prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na hlavních snímcích poznámek.

Můžete také spravovat záhlaví a zápatí pro rozdělané a poznámkové snímky. To zahrnuje změnu viditelnosti a textu zástupných symbolů záhlaví, zápatí, čísla snímku a data/času pro hlavní poznámkový motiv, všechny podřízené poznámkové snímky nebo jednotlivý poznámkový snímek.

## **Správa záhlaví a zápatí v prezentaci**
Poznámky některých konkrétních snímků lze odstranit, jak je ukázáno v níže uvedeném příkladu:

```java
// Načíst prezentaci
Presentation pres = new Presentation("headerTest.pptx");
try {
    // Nastavení zápatí
    pres.getHeaderFooterManager().setAllFootersText("My Footer text");
    pres.getHeaderFooterManager().setAllFootersVisibility(true);

    // Přístup a aktualizace záhlaví
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (null != masterNotesSlide)
    {
        updateHeaderFooterText(masterNotesSlide);
    }

    // Uložit prezentaci
    pres.save("HeaderFooterJava.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
```java
// Metoda pro nastavení textu záhlaví/zápatí
public static void updateHeaderFooterText(IBaseSlide master)
{
    for (IShape shape : master.getShapes())
    {
        if (shape.getPlaceholder() != null)
        {
            if (shape.getPlaceholder().getType() == PlaceholderType.Header)
            {
                ((IAutoShape)shape).getTextFrame().setText("HI there new header");
            }
        }
    }
}
```

## **Správa záhlaví a zápatí v rozdělaných a poznámkových snímcích**
Aspose.Slides pro Android via Java podporuje záhlaví a zápatí v rozdělaných a poznámkových snímcích. Postupujte podle níže uvedených kroků:

- Načtěte [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation) obsahující video.
- Změňte nastavení záhlaví a zápatí pro hlavní motiv poznámek a všechny snímky poznámek.
- Nastavte, aby byly viditelné zástupné symboly zápatí v hlavním motivu poznámek a ve všech podřízených snímcích.
- Nastavte, aby byly viditelné zástupné symboly data a času v hlavním motivu poznámek a ve všech podřízených snímcích.
- Změňte nastavení záhlaví a zápatí pouze pro první snímek poznámek.
- Nastavte, aby byl viditelný zástupný symbol záhlaví v snímku poznámek.
- Nastavte text pro zástupný symbol záhlaví v snímku poznámek.
- Nastavte text pro zástupný symbol data a času v snímku poznámek.
- Zapište upravený soubor prezentace.

Ukázkový kód je uveden v níže uvedeném příkladu.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Změnit nastavení záhlaví a zápatí pro hlavní motiv poznámek a všechny poznámkové snímky
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // zobrazit hlavní snímek poznámek a všechny podřízené zástupné symboly zápatí
        headerFooterManager.setFooterAndChildFootersVisibility(true); // zobrazit hlavní snímek poznámek a všechny podřízené zástupné symboly záhlaví
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // zobrazit hlavní snímek poznámek a všechny podřízené zástupné symboly čísla snímku
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // zobrazit hlavní snímek poznámek a všechny podřízené zástupné symboly data a času

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // nastavit text pro hlavní snímek poznámek a všechny podřízené zástupné symboly záhlaví
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // nastavit text pro hlavní snímek poznámek a všechny podřízené zástupné symboly zápatí
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // nastavit text pro hlavní snímek poznámek a všechny podřízené zástupné symboly data a času
    }

    // Změnit nastavení záhlaví a zápatí pouze pro první poznámkový snímek
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // zobrazit zástupný symbol záhlaví v tomto poznámkovém snímku

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // zobrazit zástupný symbol zápatí v tomto poznámkovém snímku

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // zobrazit zástupný symbol čísla snímku v tomto poznámkovém snímku

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // zobrazit zástupný symbol data a času v tomto poznámkovém snímku

        headerFooterManager.setHeaderText("New header text"); // nastavit text pro zástupný symbol záhlaví v poznámkovém snímku
        headerFooterManager.setFooterText("New footer text"); // nastavit text pro zástupný symbol zápatí v poznámkovém snímku
        headerFooterManager.setDateTimeText("New date and time text"); // nastavit text pro zástupný symbol data a času v poznámkovém snímku
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu přidat „záhlaví“ do běžných snímků?**

V PowerPointu existuje „záhlaví“ jen pro poznámky a rozdělané listy; u běžných snímků jsou podporovány pouze zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví jen pro poznámky/rozdělané listy a u snímků – zápatí/datum‑čas/číslo snímku.

**Co když rozvržení neobsahuje oblast zápatí – mohu „zapnout“ její viditelnost?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví/zápatí a případně ji povolte. Tyto indikátory a metody API jsou navrženy pro situace, kdy je zástupný symbol chybějící nebo skrytý.

**Jak mohu nastavit, aby číslo snímku začínalo hodnotou jinou než 1?**

Nastavte [first slide number](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-) prezentace; poté je celé číslo přepočítáno. Například můžete začít od 0 nebo 10 a číslo na úvodním snímku skrýt.

**Co se stane se záhlavími/zápatími při exportu do PDF/obrázků/HTML?**

Budou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na snímcích/poznámkových stránkách, objeví se také ve výstupním formátu spolu se zbytkem obsahu.