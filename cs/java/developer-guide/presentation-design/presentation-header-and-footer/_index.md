---
title: Správa záhlaví a zápatí prezentace v Javě
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
description: "Naučte se, jak spravovat zástupné symboly zápatí, datum‑času, čísla snímků a záhlaví na snímcích, stránkách poznámek a podkladech pomocí Aspose.Slides pro Java."
---
## **Overview**

PowerPoint používá různé zástupné symboly záhlaví a zápatí podle typu stránky. Aspose.Slides for Java vám umožňuje řídit text a viditelnost těchto zástupných symbolů pomocí rozhraní správce záhlaví/zápatí.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/strany |
|---|---|---|---|---|
| Běžný snímek | Ne | Ano | Ano | Ano |
| Master poznámek | Ano | Ano | Ano | Ano |
| Snímek poznámek | Ano | Ano | Ano | Ano |
| Master podkladů | Ano | Ano | Ano | Ano |

Běžný snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a podkladů. Pro běžné snímky použijte místo toho zástupné symboly zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na použitém správci. Rozhraní [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideheaderfootermanager/) řídí jeden běžný snímek. Rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotesslideheaderfootermanager/) řídí jeden snímek poznámek. Správci master a rozvržení mohou také propagovat nastavení na podřízené snímky, zatímco rozhraní [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) řídí master podkladů.

## **Set Footer, Date/Time, and Slide Numbers on Regular Slides**

Pro běžné snímky je základní postup: přistupte ke správci záhlaví/zápatí každého snímku, nastavte text zápatí a datum/čas, povolte požadované zástupné symboly a uložte prezentaci. Čísla snímků generuje prezentace, takže stačí řídit jejich viditelnost.

Použijte [`setFooterText`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) a [`setDateTimeText`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) pro nastavení textu a použijte [`setFooterVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) pro zobrazení odpovídajících zástupných symbolů.

Následující příklad od začátku použije stejný text zápatí, datum/čas a viditelnost čísla snímku pro všechny běžné snímky:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideHeaderFooterManager headerFooterManager = slide.getHeaderFooterManager();

        headerFooterManager.setFooterText("Company Confidential");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud potřebujete aktualizovat jen jeden snímek, přistupte k němu přímo pomocí metody [`getSlides`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlides--) místo iterace přes celou kolekci.

## **Set Headers and Footers on the Notes Master**

Master poznámek určuje společné formátování a chování zástupných symbolů pro stránky poznámek. Použijte rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/) pokud chcete měnit pouze samotný master poznámek.

Následující příklad nastaví záhlaví, zápatí a text datum/čas na master poznámek a zobrazí všechny podporované zástupné symboly na tomto masteru:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Notes header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Notes footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) vrací `null`, když prezentace neobsahuje master poznámek.

## **Apply Notes Master Settings to Child Notes Slides**

Master poznámek může aplikovat nastavení záhlaví a zápatí na sebe i na všechny podřízené snímky poznámek. Použijte specializované metody propagace na rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/) když mají být stejná nastavení použita napříč hierarchií poznámek.

Například metody [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) aktualizují záhlaví masteru poznámek a všech podřazených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterNotesSlide masterNotesSlide = presentation.getMasterNotesSlideManager().getMasterNotesSlide();

    if (masterNotesSlide != null) {
        IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderAndChildHeadersText("Notes header");
        headerFooterManager.setHeaderAndChildHeadersVisibility(true);

        headerFooterManager.setFooterAndChildFootersText("Notes footer");
        headerFooterManager.setFooterAndChildFootersVisibility(true);

        headerFooterManager.setDateTimeAndChildDateTimesText("Date and time text");
        headerFooterManager.setDateTimeAndChildDateTimesVisibility(true);

        headerFooterManager.setSlideNumberAndChildSlideNumbersVisibility(true);
    }

    presentation.save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Metody propagace použité výše jsou [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Set Headers and Footers on an Individual Notes Slide**

Snímek poznámek patří ke konkrétnímu běžnému snímku. Použijte jeho rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotesslideheaderfootermanager/) pokud chcete upravit jen tuto stránku poznámek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotesslidemanager/#addNotesSlide--) vrací snímek poznámek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek přidruženou k prvnímu snímku prezentace:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    INotesSlide notesSlide = slide.getNotesSlideManager().addNotesSlide();
    INotesSlideHeaderFooterManager headerFooterManager = notesSlide.getHeaderFooterManager();

    headerFooterManager.setHeaderText("Header for the first notes page");
    headerFooterManager.setHeaderVisibility(true);

    headerFooterManager.setFooterText("Footer for the first notes page");
    headerFooterManager.setFooterVisibility(true);

    headerFooterManager.setDateTimeText("Date and time text");
    headerFooterManager.setDateTimeVisibility(true);

    headerFooterManager.setSlideNumberVisibility(true);

    presentation.save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pokud nejprve propagujete nastavení z masteru poznámek a poté změníte jednotlivý snímek poznámek, pozdější nastavení per‑snímek vám umožní tuto stránku přizpůsobit nezávisle.

## **Set Headers and Footers on the Handout Master**

Stránky podkladů používají master podkladů pro své zástupné symboly záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení podkladů spravována prostřednictvím masteru podkladů, nikoli jednotlivých slide‑ů podkladů.

Použijte metodu [`getMasterHandoutSlide`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) pro přístup k masteru podkladů. Pokud není přítomen, zavolejte [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) pro vytvoření výchozího masteru podkladů.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterHandoutSlide masterHandoutSlide = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();

    if (masterHandoutSlide == null) {
        masterHandoutSlide = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();
    }

    if (masterHandoutSlide != null) {
        IMasterHandoutSlideHeaderFooterManager headerFooterManager = masterHandoutSlide.getHeaderFooterManager();

        headerFooterManager.setHeaderText("Handout header");
        headerFooterManager.setHeaderVisibility(true);

        headerFooterManager.setFooterText("Handout footer");
        headerFooterManager.setFooterVisibility(true);

        headerFooterManager.setDateTimeText("Date and time text");
        headerFooterManager.setDateTimeVisibility(true);

        headerFooterManager.setSlideNumberVisibility(true);
    }

    presentation.save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Understand Scope and Inheritance**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islideheaderfootermanager/) mění nastavení zápatí, datum/čas a čísla snímku pro jeden běžný snímek.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ilayoutslideheaderfootermanager/) řídí snímek rozvržení a může propagovat podporovaná nastavení na podřízené snímky.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterslideheaderfootermanager/) řídí běžný master snímků a může propagovat podporovaná nastavení na podřízené snímky.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasternotesslideheaderfootermanager/) řídí master poznámek a může propagovat nastavení na všechny podřízené snímky poznámek.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotesslideheaderfootermanager/) mění jeden snímek poznámek a podporuje zástupný symbol záhlaví kromě zápatí, datum/čas a čísla snímku.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mění master podkladů a podporuje všechny čtyři typy zástupných symbolů.

Použijte propagaci z masteru nebo rozvržení, když má být stejné nastavení použito v celé hierarchii. Použijte správce jednotlivého snímku nebo snímku poznámek, pokud potřebujete lokální nastavení pro jednu stránku.

## **FAQ**

**Mohu přidat záhlaví na běžný snímek?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro běžné snímky. Na běžných snímcích použijte zástupné symboly zápatí, datum/čas a čísla snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a podkladů.

**Co když zástupný symbol zápatí, datum/čas nebo číslo snímku není viditelný?**

Použijte odpovídající správce záhlaví/zápatí k ověření jeho viditelnosti a povolte jej podle potřeby. Například metoda [`isFooterVisible`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) oznamuje, zda je zástupný symbol zápatí přítomen, a [`setFooterVisibility`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) mění jeho viditelnost.

**Jak začít číslovat snímky od hodnoty jiného než 1?**

Zavolejte metodu prezentace [`setFirstSlideNumber`](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#setFirstSlideNumber-int-). Zástupné symboly čísla snímku pak používají aktualizovanou sekvenci číslování.

**Co se stane se záhlavími a zápatími při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu stránky, který se exportuje, a na nastavení viditelnosti příslušných zástupných symbolů.