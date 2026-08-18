---
title: Správa záhlaví a zápatí prezentace na Androidu
linktitle: Záhlaví a zápatí
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
- podklad
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak spravovat zápatí, datum-čas, číslo snímku a zástupné symboly záhlaví na snímcích, stránkách poznámek a podkladech pomocí Aspose.Slides pro Android přes Java."
---
## **Přehled**

PowerPoint používá různé zástupné symboly záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides pro Android přes Java vám umožňuje kontrolovat text a viditelnost těchto zástupných symbolů pomocí rozhraní správců záhlaví/zápatí.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Normální snímek | Ne | Ano | Ano | Ano |
| Poznámkový master | Ano | Ano | Ano | Ano |
| Poznámkový snímek | Ano | Ano | Ano | Ano |
| Podkladový master | Ano | Ano | Ano | Ano |

Normální snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a podkladových výtiscích. Pro normální snímky používejte místo toho zástupné symboly zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na použitém správci. Rozhraní [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideheaderfootermanager/) ovládá jeden normální snímek. Rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) ovládá jeden poznámkový snímek. Správci master a layout mohou také propagovat nastavení na podřízené snímky, zatímco rozhraní [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) ovládá podkladový master.

## **Nastavení zápatí, data/času a čísel snímků na normálních snímcích**

Pro normální snímky je základní postup přistoupit k manageru záhlaví/zápatí každého snímku, nastavit text zápatí a data/času, povolit požadované zástupné symboly a prezentaci uložit. Čísla snímků generuje prezentace, takže je potřeba řídit pouze jejich viditelnost.

Použijte [`setFooterText`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterText-java.lang.String-) a [`setDateTimeText`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeText-java.lang.String-) k nastavení textu a použijte [`setFooterVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-), [`setDateTimeVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setDateTimeVisibility-boolean-), a [`setSlideNumberVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setSlideNumberVisibility-boolean-) k zobrazení odpovídajících zástupných symbolů.

Následující kompletní příklad použije stejný text zápatí, data/času a viditelnost čísel snímků na všechny normální snímky:

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

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k němu přímo pomocí metody [`getSlides`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlides--) místo iterace celou kolekcí.

## **Nastavení záhlaví a zápatí na poznámkovém masteru**

Poznámkový master určuje společné formátování a chování zástupných symbolů pro stránky poznámek. Použijte rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) když chcete měnit jen samotný poznámkový master.

Následující příklad nastaví záhlaví, zápatí a text data/času na poznámkovém masteru a zobrazí všechny podporované zástupné symboly:

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

Metoda [`getMasterNotesSlide`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslidemanager/#getMasterNotesSlide--) vrací `null`, pokud prezentace neobsahuje poznámkový master.

## **Použití nastavení poznámkového masteru na podřízené poznámkové snímky**

Poznámkový master může aplikovat nastavení záhlaví a zápatí na sebe i na všechny podřízené poznámkové snímky. Použijte dedikované metody propagace na rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) když mají být stejná nastavení použita napříč hierarchií poznámek.

Například [`setHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersText-java.lang.String-) a [`setHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setHeaderAndChildHeadersVisibility-boolean-) aktualizují záhlaví poznámkového masteru a všech podřízených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas i čísla snímků.

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

Metody propagace použité výše jsou [`setFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersText-java.lang.String-), [`setFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setFooterAndChildFootersVisibility-boolean-), [`setDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesText-java.lang.String-), [`setDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setDateTimeAndChildDateTimesVisibility-boolean-), a [`setSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/#setSlideNumberAndChildSlideNumbersVisibility-boolean-).

## **Nastavení záhlaví a zápatí na jednotlivém poznámkovém snímku**

Poznámkový snímek patří ke konkrétnímu normálnímu snímku. Použijte jeho rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) když chcete přizpůsobit jen tuto stránku poznámek.

Metoda [`addNotesSlide`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotesslidemanager/#addNotesSlide--) vrací poznámkový snímek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek přiřazenou k prvnímu snímku prezentace:

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

Pokud nejprve propagujete nastavení z poznámkového masteru a následně změníte jednotlivý poznámkový snímek, pozdější nastavení na úrovni snímku vám umožní přizpůsobit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a zápatí na podkladovém masteru**

Stránky podkladů používají podkladový master pro své zástupné symboly záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení podkladů spravována přes podkladový master, nikoli přes jednotlivé podkladové snímky.

Použijte metodu [`getMasterHandoutSlide`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslidemanager/#getMasterHandoutSlide--) k přístupu k podkladovému masteru. Pokud není přítomen, zavolejte [`setDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) k vytvoření výchozího podkladového masteru.

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

## **Porozumění rozsahu a dědičnosti**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islideheaderfootermanager/) mění nastavení zápatí, data/času a čísla snímku pro jeden normální snímek.
- [`ILayoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ilayoutslideheaderfootermanager/) ovládá snímek layoutu a může propagovat podporovaná nastavení na podřízené snímky.
- [`IMasterSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterslideheaderfootermanager/) ovládá standardní master snímků a může propagovat podporovaná nastavení na podřízené snímky.
- [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasternotesslideheaderfootermanager/) ovládá poznámkový master a může propagovat nastavení na všechny podřízené poznámkové snímky.
- [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotesslideheaderfootermanager/) mění jeden poznámkový snímek a podporuje zástupný symbol záhlaví kromě zápatí, data/času a čísla snímku.
- [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/imasterhandoutslideheaderfootermanager/) mění podkladový master a podporuje všechny čtyři typy zástupných symbolů.

Používejte propagaci z masteru nebo layoutu, když má být stejné nastavení použito v celé jeho hierarchii. Používejte správce jednotlivého snímku nebo poznámkového snímku, když potřebujete lokální nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví k normálnímu snímku?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro normální snímky. Na normálních snímcích používejte zástupné symboly zápatí, datum/čas a číslo snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a podkladových výtiscích.

**Co když zástupný symbol zápatí, datum/čas nebo číslo snímku není viditelný?**

Použijte příslušný správce záhlaví/zápatí k ověření jeho viditelnosti a povolte jej podle potřeby. Například metoda [`isFooterVisible`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#isFooterVisible--) hlásí, zda je zástupný symbol zápatí přítomen, a metoda [`setFooterVisibility`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/baseslideheaderfootermanager/#setFooterVisibility-boolean-) mění jeho viditelnost.

**Jak mohu začít číslovat snímky od hodnoty jiné než 1?**

Zavolejte metodu prezentace [`setFirstSlideNumber`](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#setFirstSlideNumber-int-). Zástupné symboly čísla snímku pak použijí aktualizovanou číselnou sekvenci.

**Co se stane se záhlavími a zápatími při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace v cílovém formátu. Jejich vzhled závisí na typu stránky, která se exportuje, a na nastaveních viditelnosti odpovídajících zástupných symbolů.