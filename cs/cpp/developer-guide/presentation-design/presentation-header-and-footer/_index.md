---
title: Správa záhlaví a zápatí prezentace v C++
linktitle: Záhlaví a zápatí
type: docs
weight: 140
url: /cs/cpp/presentation-header-and-footer/
keywords:
- záhlaví
- text záhlaví
- zápatí
- text zápatí
- nastavit záhlaví
- nastavit zápatí
- výstupní list
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Použijte Aspose.Slides pro C++ k přidání a přizpůsobení záhlaví a zápatí v PowerPoint a OpenDocument prezentacích pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí jsou zpracovávána na úrovni hlavního podkladu prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na hlavních snímcích poznámek.

Můžete také spravovat záhlaví a zápatí pro výstupní a poznámkové snímky. To zahrnuje změnu viditelnosti a textu zástupných objektů záhlaví, zápatí, čísla snímku a data‑času pro hlavní poznámky, všechny podřízené poznámkové snímky nebo jednotlivý poznámkový snímek.

## **Správa textu záhlaví a zápatí**

Poznámky některých konkrétních snímků lze aktualizovat, jak ukazuje příklad níže:

``` cpp
// Funkce pro nastavení textu záhlaví/zápatí
void UpdateHeaderFooterText(System::SharedPtr<IBaseSlide> master)
{
    for (const auto& shape : System::IterateOver(master->get_Shapes()))
    {
        if (shape->get_Placeholder() != nullptr)
        {
            if (shape->get_Placeholder()->get_Type() == PlaceholderType::Header)
            {
                (System::ExplicitCast<IAutoShape>(shape))->get_TextFrame()->set_Text(u"HI there new header");
            }
        }
    }
}
```

``` cpp
// Načíst prezentaci
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Nastavení zápatí
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Přístup a aktualizace záhlaví
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Uložit prezentaci
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Správa záhlaví a zápatí na výstupních a poznámkových snímcích**
Aspose.Slides pro C++ podporuje záhlaví a zápatí ve výstupních a poznámkových snímcích. Postupujte podle následujících kroků:

- Načtěte [prezentaci](https://reference.aspose.com/slides/cs/cpp/class/aspose.slides.presentation) obsahující video.
- Změňte nastavení záhlaví a zápatí pro hlavní poznámky a všechny poznámkové snímky.
- Nastavte, aby hlavní poznámkový snímek a všechny podřízené zástupné objekty zápatí byly viditelné.
- Nastavte, aby hlavní poznámkový snímek a všechny podřízené zástupné objekty data a času byly viditelné.
- Změňte nastavení záhlaví a zápatí pouze pro první poznámkový snímek.
- Nastavte, aby zástupný objekt záhlaví poznámkového snímku byl viditelný.
- Nastavte text pro zástupný objekt záhlaví poznámkového snímku.
- Nastavte text pro zástupný objekt data a času poznámkového snímku.
- Zapište upravený soubor prezentace.

Ukázkový kód je uveden v níže uvedeném příkladu.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Změnit nastavení záhlaví a zápatí pro hlavní poznámky a všechny poznámkové snímky
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// zobrazit hlavní poznámkový snímek a všechny podřízené zástupné objekty zápatí
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// zobrazit hlavní poznámkový snímek a všechny podřízené zástupné objekty záhlaví
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// zobrazit hlavní poznámkový snímek a všechny podřízené zástupné objekty čísla snímku
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// zobrazit hlavní poznámkový snímek a všechny podřízené zástupné objekty data a času
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// nastavit text hlavního poznámkového snímku a všech podřízených zástupných objektů záhlaví
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// nastavit text hlavního poznámkového snímku a všech podřízených zástupných objektů zápatí
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// nastavit text hlavního poznámkového snému a všech podřízených zástupných objektů data a času
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Změnit nastavení záhlaví a zápatí pouze pro první poznámkový snímek
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// zobrazit zástupný objekt záhlaví tohoto poznámkového snímku
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// zobrazit zástupný objekt zápatí tohoto poznámkového snímku
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// zobrazit zástupný objekt čísla snímku tohoto poznámkového snímku
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// zobrazit zástupný objekt data‑času tohoto poznámkového snímku
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// nastavit text zástupného objektu záhlaví poznámkového snímku
	headerFooterManager->SetHeaderText(u"New header text");
	// nastavit text zástupného objektu zápatí poznámkového snímku
	headerFooterManager->SetFooterText(u"New footer text");
	// nastavit text zástupného objektu data‑času poznámkového snímku
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **Často kladené otázky**

**Mohu přidat „záhlaví“ do běžných snímků?**

V PowerPointu existuje „záhlaví“ jen pro poznámky a výstupní listy; na běžných snímcích jsou podporovány jen zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví jen pro poznámky/výstupní listy a na snímcích – zápatí/datum‑čas/číslo snímku.

**Co když rozvržení neobsahuje oblast zápatí – mohu její viditelnost „zapnout“?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví/zápatí a podle potřeby ji povolte. Tyto indikátory a metody API jsou navrženy pro případy, kdy je zástupný objekt chybějící nebo skrytý.

**Jak nastavit, aby číslování snímků začínalo hodnotou jinou než 1?**

Nastavte [číslo prvního snímku](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/set_firstslidenumber/) prezentace; poté je celé číslování přepočítáno. Například můžete začít od 0 nebo 10 a číslo na úvodním snímku skrýt.

**Co se stane se záhlavími/zápatími při exportu do PDF/obrázků/HTML?**

Budou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na snímcích nebo poznámkových stránkách, objeví se také ve výstupním formátu spolu se zbytkem obsahu.