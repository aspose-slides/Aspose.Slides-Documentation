---
title: Správa záhlaví a zápatí prezentace v Java
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/java/presentation-header-and-footer/
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
- Java
- Aspose.Slides
description: "Použijte Aspose.Slides pro Java k přidání a přizpůsobení záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Overview**

Aspose.Slides umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí jsou řízena na úrovni hlavního souboru prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na hlavních snímcích poznámek.

Můžete také spravovat záhlaví a zápatí pro listy s podklady a poznámkové snímky. To zahrnuje změnu viditelnosti a textu zástupných objektů záhlaví, zápatí, čísla snímku a data/času pro hlavní poznámkový snímek, všechny podřízené poznámkové snímky nebo jednotlivý poznámkový snímek.

## **Manage Headers and Footers in a Presentation**
Poznámky některých konkrétních snímků mohou být odstraněny, jak je ukázáno v následujícím příkladu:

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

## **Manage Headers and Footers on Handout and Notes Slides**
Aspose.Slides pro Java podporuje Header a Footer v listu s podklady a poznámkových snímcích. Postupujte podle následujících kroků:

- Načtěte prezentaci obsahující video.
- Změňte nastavení Header a Footer pro notes master a všechny notes slides.
- Zobrazte zástupné objekty Footer v master notes slide a ve všech podřízených.
- Zobrazte zástupné objekty Date a time v master notes slide a ve všech podřízených.
- Změňte nastavení Header a Footer pouze pro první notes slide.
- Zobrazte zástupný objekt Header v notes slide.
- Nastavte text do zástupného objektu Header v notes slide.
- Nastavte text do zástupného objektu Date-time v notes slide.
- Zapište upravený soubor prezentace.

Code Snippet provided in below Example.

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    // Změnit nastavení záhlaví a zápatí pro hlavní poznámkový snímek a všechny poznámkové snímky
    IMasterNotesSlide masterNotesSlide = pres.getMasterNotesSlideManager().getMasterNotesSlide();
    if (masterNotesSlide != null)
    {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupce zápatí
        headerFooterManager.setFooterAndChildFootersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupce záhlaví
        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupce čísla snímku
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupce data a času

        headerFooterManager.setHeaderAndChildHeadersText("Header text"); // nastavit text do hlavního poznámkového snímku a všech podřízených zástupců záhlaví
        headerFooterManager.setFooterAndChildFootersText("Footer text"); // nastavit text do hlavního poznámkového snímku a všech podřízených zástupců zápatí
        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text"); // nastavit text do hlavního poznámkového snímku a všech podřízených zástupců data a času
    }

    // Změnit nastavení záhlaví a zápatí pouze pro první poznámkový snímek
    INotesSlide notesSlide = pres.getSlides().get_Item(0).getNotesSlideManager().getNotesSlide();
    if (notesSlide != null)
    {
        INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();
        if (!headerFooterManager.isHeaderVisible())
            headerFooterManager.setHeaderVisibility(true); // zobrazit zástupce záhlaví tohoto poznámkového snímku

        if (!headerFooterManager.isFooterVisible())
            headerFooterManager.setFooterVisibility(true); // zobrazit zástupce zápatí tohoto poznámkového snímku

        if (!headerFooterManager.isSlideNumberVisible())
            headerFooterManager.setSlideNumberVisibility(true); // zobrazit zástupce čísla snímku tohoto poznámkového snímku

        if (!headerFooterManager.isDateTimeVisible())
            headerFooterManager.setDateTimeVisibility(true); // zobrazit zástupce data a času tohoto poznámkového snímku

        headerFooterManager.setHeaderText("New header text"); // nastavit text do zástupce záhlaví poznámkového snímku
        headerFooterManager.setFooterText("New footer text"); // nastavit text do zástupce zápatí poznámkového snímku
        headerFooterManager.setDateTimeText("New date and time text"); // nastavit text do zástupce data a času poznámkového snímku
    }
    pres.save("testresult.pptx",SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Can I add a "header" to regular slides?**

V PowerPointu existuje „Header“ pouze pro poznámky a listy s podklady; na běžných snímcích jsou podporovány pouze Footer, date/time a slide number. V Aspose.Slides to odpovídá stejným omezením: header jen pro Notes/Handout a na snímcích — Footer/DateTime/SlideNumber.

**What if the layout doesn’t contain a footer area—can I "turn on" its visibility?**

Ano. Zkontrolujte viditelnost pomocí správce header/footer a v případě potřeby ji povolte. Tyto ukazatele a metody API jsou navrženy pro případy, kdy je placeholder chybějící nebo skrytý.

**How do I make the slide number start from a value other than 1?**

Nastavte první číslo snímku prezentace pomocí [první číslo snímku](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-); poté se přepočítá celé číslování. Například můžete začít od 0 nebo 10 a číslo skrýt na titulním snímku.

**What happens to headers/footers when exporting to PDF/images/HTML?**

Jsou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na slides/notes pages, objeví se také ve výstupním formátu spolu se zbytkem obsahu.