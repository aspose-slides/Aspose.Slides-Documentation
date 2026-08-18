---
title: Správa záhlaví a zápatí prezentace v .NET
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/net/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- výstřižek
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Zjistěte, jak spravovat zástupné symboly zápatí, datum‑čas, číslo snímku a záhlaví na snímcích, stránkách poznámek a výstřižcích pomocí Aspose.Slides pro .NET."
---
## **Přehled**

PowerPoint používá různé zástupné symboly záhlaví a zápatí v závislosti na typu stránky. Aspose.Slides pro .NET vám umožňuje řídit text a viditelnost těchto zástupných symbolů prostřednictvím rozhraní správce záhlaví/zápatí.

Dostupné zástupné symboly závisí na rozsahu:

| Rozsah | Záhlaví | Zápatí | Datum/čas | Číslo snímku/stránky |
|---|---|---|---|---|
| Normální snímek | Ne | Ano | Ano | Ano |
| Poznámkový master | Ano | Ano | Ano | Ano |
| Poznámkový snímek | Ano | Ano | Ano | Ano |
| Master výstřižků | Ano | Ano | Ano | Ano |

Normální snímek prezentace nemá zástupný symbol záhlaví. Záhlaví jsou k dispozici na stránkách poznámek a výstřižcích. Pro normální snímky použijte místo toho zástupné symboly zápatí, datum/čas a číslo snímku.

Rozsah změny závisí na správci, který používáte. Rozhraní [`ISlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/islideheaderfootermanager/) řídí jeden normální snímek. Rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/inotesslideheaderfootermanager/) řídí jeden poznámkový snímek. Správci master a rozložení mohou také propagovat nastavení na závislé snímky, zatímco rozhraní [`IMasterHandoutSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterhandoutslideheaderfootermanager/) řídí master výstřižků.

## **Nastavení zápatí, data/času a čísel snímků na normálních snímcích**

Pro normální snímky je základní postup získat správce záhlaví/zápatí každého snímku, nastavit text zápatí a datum/čas, povolit požadované zástupné symboly a uložit prezentaci. Čísla snímků generuje prezentace, takže je třeba řídit pouze jejich viditelnost.

Použijte [`SetFooterText`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setfootertext/) a [`SetDateTimeText`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setdatetimetext/) k nastavení textu a použijte [`SetFooterVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/), [`SetDateTimeVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setdatetimevisibility/) a [`SetSlideNumberVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setslidenumbervisibility/) k zobrazení odpovídajících zástupných symbolů.

Následující příklad od začátku do konce použije stejný text zápatí, datum/čas a viditelnost čísla snímku na všechny normální snímky:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

foreach (var slide in presentation.Slides)
{
    var headerFooterManager = slide.HeaderFooterManager;

    headerFooterManager.SetFooterText("Company Confidential");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_slide_footers.pptx", SaveFormat.Pptx);
```

Pokud potřebujete aktualizovat pouze jeden snímek, přistupte k němu přímo přes kolekci [`Slides`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/slides/cs/) místo iterace celé kolekce.

## **Nastavení záhlaví a zápatí na masteru poznámek**

Master poznámek definuje společné formátování a chování zástupných symbolů pro stránky poznámek. Použijte rozhraní [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslideheaderfootermanager/), pokud chcete změnit pouze samotný master poznámek.

Následující příklad nastaví záhlaví, zápatí a text datum/čas na masteru poznámek a zobrazí všechny podporované zástupné symboly na tomto masteru:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Notes header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Notes footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_notes_master_footers.pptx", SaveFormat.Pptx);
```

Vlastnost [`MasterNotesSlide`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslidemanager/masternotesslide/) vrací `null`, pokud prezentace neobsahuje master poznámek.

## **Použití nastavení masteru poznámek na podřízené poznámkové snímky**

Master poznámek může aplikovat nastavení záhlaví a zápatí na sebe i na všechny závislé poznámkové snímky. Použijte vyhrazené metody propagace na [`IMasterNotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasternotesslideheaderfootermanager/), pokud mají být stejná nastavení aplikována napříč hierarchií poznámek.

Například [`SetHeaderAndChildHeadersText`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheaderstext/) a [`SetHeaderAndChildHeadersVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setheaderandchildheadersvisibility/) aktualizují záhlaví masteru poznámek a všech podřízených záhlaví. Ekvivalentní metody jsou k dispozici pro zápatí, datum/čas a čísla snímků.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;

if (masterNotesSlide != null)
{
    var headerFooterManager = masterNotesSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderAndChildHeadersText("Notes header");
    headerFooterManager.SetHeaderAndChildHeadersVisibility(true);

    headerFooterManager.SetFooterAndChildFootersText("Notes footer");
    headerFooterManager.SetFooterAndChildFootersVisibility(true);

    headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text");
    headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true);

    headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true);
}

presentation.Save("presentation_with_child_notes_footers.pptx", SaveFormat.Pptx);
```

Metody propagace použité výše jsou [`SetFooterAndChildFootersText`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfooterstext/), [`SetFooterAndChildFootersVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setfooterandchildfootersvisibility/), [`SetDateTimeAndChildDateTimesText`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimestext/), [`SetDateTimeAndChildDateTimesVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setdatetimeandchilddatetimesvisibility/) a [`SetSlideNumberAndChildSlideNumbersVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/masternotesslideheaderfootermanager/setslidenumberandchildslidenumbersvisibility/).

## **Nastavení záhlaví a zápatí na jednotlivém poznámkovém snímku**

Poznámkový snímek patří k určitému normálnímu snímku. Použijte jeho rozhraní [`INotesSlideHeaderFooterManager`](https://reference.aspose.com/slides/cs/net/aspose.slides/inotesslideheaderfootermanager/), pokud chcete přizpůsobit pouze tuto stránku poznámek.

Metoda [`AddNotesSlide`](https://reference.aspose.com/slides/cs/net/aspose.slides/inotesslidemanager/addnotesslide/) vrací poznámkový snímek pro aktuální snímek a vytvoří jej, pokud ještě neexistuje. Následující příklad konfiguruje stránku poznámek spojenou s prvním snímkem prezentace:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var notesSlide = presentation.Slides[0].NotesSlideManager.AddNotesSlide();
var headerFooterManager = notesSlide.HeaderFooterManager;

headerFooterManager.SetHeaderText("Header for the first notes page");
headerFooterManager.SetHeaderVisibility(true);

headerFooterManager.SetFooterText("Footer for the first notes page");
headerFooterManager.SetFooterVisibility(true);

headerFooterManager.SetDateTimeText("Date and time text");
headerFooterManager.SetDateTimeVisibility(true);

headerFooterManager.SetSlideNumberVisibility(true);

presentation.Save("presentation_with_custom_notes_footers.pptx", SaveFormat.Pptx);
```

Pokud nejprve propagujete nastavení z masteru poznámek a poté změníte jednotlivý poznámkový snímek, pozdější nastavení na úrovni snímku vám umožní přizpůsobit tuto stránku poznámek nezávisle.

## **Nastavení záhlaví a zápatí na masteru výstřižků**

Stránky výstřižků používají master výstřižků pro své zástupné symboly záhlaví, zápatí, datum/čas a číslo stránky. Na rozdíl od stránek poznámek jsou nastavení výstřižků spravována přes master výstřižků, nikoli přes jednotlivé snímky výstřižků.

Použijte vlastnost [`MasterHandoutSlide`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterhandoutslidemanager/masterhandoutslide/) k přístupu k masteru výstřižků. Pokud není přítomen, zavolejte [`SetDefaultMasterHandoutSlide`](https://reference.aspose.com/slides/cs/net/aspose.slides/imasterhandoutslidemanager/setdefaultmasterhandoutslide/) k vytvoření výchozího masteru výstřižků.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("presentation.pptx");

var masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;

if (masterHandoutSlide == null)
{
    presentation.MasterHandoutSlideManager.SetDefaultMasterHandoutSlide();
    masterHandoutSlide = presentation.MasterHandoutSlideManager.MasterHandoutSlide;
}

if (masterHandoutSlide != null)
{
    var headerFooterManager = masterHandoutSlide.HeaderFooterManager;

    headerFooterManager.SetHeaderText("Handout header");
    headerFooterManager.SetHeaderVisibility(true);

    headerFooterManager.SetFooterText("Handout footer");
    headerFooterManager.SetFooterVisibility(true);

    headerFooterManager.SetDateTimeText("Date and time text");
    headerFooterManager.SetDateTimeVisibility(true);

    headerFooterManager.SetSlideNumberVisibility(true);
}

presentation.Save("presentation_with_handout_footers.pptx", SaveFormat.Pptx);
```

## **Pochopení rozsahu a dědičnosti**

Vyberte správce záhlaví/zápatí, který odpovídá rozsahu, který chcete změnit:

- `ISlideHeaderFooterManager` mění nastavení zápatí, datum/čas a čísla snímku pro jeden normální snímek.
- `ILayoutSlideHeaderFooterManager` řídí rozložení snímku a může propagovat podporovaná nastavení na závislé snímky.
- `IMasterSlideHeaderFooterManager` řídí běžný master snímků a může propagovat podporovaná nastavení na závislé snímky.
- `IMasterNotesSlideHeaderFooterManager` řídí master poznámek a může propagovat nastavení na všechny závislé poznámkové snímky.
- `INotesSlideHeaderFooterManager` mění jeden poznámkový snímek a podporuje zástupný symbol záhlaví kromě zápatí, datum/čas a číslo snímku.
- `IMasterHandoutSlideHeaderFooterManager` mění master výstřižků a podporuje všechny čtyři typy zástupných symbolů.

Použijte propagaci z masteru nebo rozložení, pokud má být stejné nastavení použito v celé jeho hierarchii. Použijte správce jednotlivého snímku nebo poznámkového snímku, pokud potřebujete lokální nastavení pro jednu stránku.

## **Často kladené otázky**

**Mohu přidat záhlaví na normální snímek?**

Ne. PowerPoint nedefinuje zástupný symbol záhlaví pro normální snímky. Na normálních snímcích použijte zástupné symboly zápatí, datum/čas a číslo snímku. Zástupné symboly záhlaví jsou k dispozici na stránkách poznámek a výstřižcích.

**Co když zástupný symbol zápatí, datum/čas nebo číslo snímku není viditelný?**

Použijte odpovídající správce záhlaví/zápatí k ověření jeho viditelnosti a povolte jej podle potřeby. Například [`IsFooterVisible`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/isfootervisible/) uvádí, zda je zástupný symbol zápatí přítomen, a [`SetFooterVisibility`](https://reference.aspose.com/slides/cs/net/aspose.slides/baseslideheaderfootermanager/setfootervisibility/) mění jeho viditelnost.

**Jak nastavit číslování snímků od jiné hodnoty než 1?**

Nastavte vlastnost [`FirstSlideNumber`](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/firstslidenumber/) prezentace. Zástupné symboly čísla snímku pak používají aktualizovanou sekvenci číslování.

**Co se stane se záhlavím a zápatím při exportu do PDF, obrázků nebo HTML?**

Viditelné prvky záhlaví a zápatí jsou vykresleny spolu se zbytkem obsahu prezentace ve výstupním formátu. Jejich vzhled závisí na typu exportované stránky a nastaveních viditelnosti příslušných zástupných symbolů.