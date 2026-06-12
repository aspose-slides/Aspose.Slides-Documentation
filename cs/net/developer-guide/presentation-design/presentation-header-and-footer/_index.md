---
title: Spravovat záhlaví a zápatí prezentace v .NET
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
- rozdělané materiály
- poznámky
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Použijte Aspose.Slides pro .NET k přidání a přizpůsobení záhlaví a zápatí v prezentacích PowerPoint a OpenDocument pro profesionální vzhled."
---
## **Přehled**

Aspose.Slides vám umožňuje spravovat nastavení záhlaví a zápatí v prezentacích PowerPoint. Záhlaví a zápatí jsou zpracovávána na úrovni hlavního souboru prezentace a API poskytuje metody pro nastavení textu zápatí, změnu viditelnosti zápatí a aktualizaci textu záhlaví na hlavních snímcích poznámek.

Můžete také spravovat záhlaví a zápatí pro rozdělané a poznámkové snímky. To zahrnuje změnu viditelnosti a textu zástupných znaků záhlaví, zápatí, čísla snímku a data/času pro hlavní poznámky, všechny podřízené poznámkové snímky nebo jednotlivý poznámkový snímek.

## **Správa textu záhlaví a zápatí**

Poznámky některých konkrétních snímků lze aktualizovat, jak je uvedeno v níže uvedeném příkladu:

```c#
// Načíst prezentaci
Presentation pres = new Presentation("headerTest.pptx");

// Nastavení zápatí
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Přístup a aktualizace záhlaví
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// Uložit prezentaci
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Metoda pro nastavení textu záhlaví/zápatí
public static void UpdateHeaderFooterText(IBaseSlide master)
{
    foreach (IShape shape in master.Shapes)
    {
        if (shape.Placeholder != null)
        {
            if (shape.Placeholder.Type == PlaceholderType.Header)
            {
                ((IAutoShape)shape).TextFrame.Text = "HI there new header";
            }
        }
    }
}
```

## **Správa záhlaví a zápatí na rozdělaných a poznámkových snímcích**
Aspose.Slides pro .NET podporuje záhlaví a zápatí na rozdělaných a poznámkových snímcích. Postupujte podle následujících kroků:

- Načtěte [prezentaci](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation) obsahující video.
- Změňte nastavení záhlaví a zápatí pro hlavní poznámky a všechny poznámkové snímky.
- Nastavte hlavní poznámkový snímek a všechny podřízené zástupné znaky zápatí jako viditelné.
- Nastavte hlavní poznámkový snímek a všechny podřízené zástupné znaky data a času jako viditelné.
- Změňte nastavení záhlaví a zápatí pouze pro první poznámkový snímek.
- Nastavte zástupný znak záhlaví na poznámkovém snímku jako viditelný.
- Nastavte text pro zástupný znak záhlaví na poznámkovém snímku.
- Nastavte text pro zástupný znak data a času na poznámkovém snímku.
- Zapište upravený soubor prezentace.

Ukázkový kód je uveden v příkladu níže.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Změnit nastavení záhlaví a zápatí pro hlavní poznámky a všechny poznámkové snímky
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupné znaky zápatí
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupné znaky záhlaví
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupné znaky čísel snímků
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // zobrazit hlavní poznámkový snímek a všechny podřízené zástupné znaky data a času

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // nastavit text na hlavní poznámkový snímek a všechny podřízené zástupné znaky záhlaví
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // nastavit text na hlavní poznámkový snímek a všechny podřízené zástupné znaky zápatí
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // nastavit text na hlavní poznámkový snímek a všechny podřízené zástupné znaky data a času
	}

	// Změnit nastavení záhlaví a zápatí pouze pro první poznámkový snímek
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // zobrazit tento poznámkový snímek a jeho zástupný znak záhlaví

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // zobrazit tento poznámkový snímek a jeho zástupný znak zápatí

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // zobrazit tento poznámkový snímek a jeho zástupný znak čísla snímku

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // zobrazit tento poznámkový snímek a jeho zástupný znak data a času

		headerFooterManager.SetHeaderText("New header text"); // nastavit text na zástupný znak záhlaví poznámkového snímku
		headerFooterManager.SetFooterText("New footer text"); // nastavit text na zástupný znak zápatí poznámkového snímku
		headerFooterManager.SetDateTimeText("New date and time text"); // nastavit text na zástupný znak data a času poznámkového snímku
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Mohu přidat "záhlaví" do běžných snímků?**

V PowerPointu existuje „Záhlaví“ pouze pro poznámky a rozdělané materiály; na běžných snímcích jsou podporovány pouze zápatí, datum/čas a číslo snímku. V Aspose.Slides to odpovídá stejným omezením: záhlaví pouze pro poznámky/rozdělané materiály a na snímcích — zápatí/datum‑čas/číslo snímku.

**Co když rozložení neobsahuje oblast zápatí — mohu ji „zapnout“?**

Ano. Zkontrolujte viditelnost pomocí správce záhlaví/zápatí a v případě potřeby ji povolte. Tyto indikátory a metody API jsou navrženy pro situace, kdy je zástupný znak chybějící nebo skrytý.

**Jak mohu nastavit, aby číslování snímků začínalo hodnotou jinou než 1?**

Nastavte [první číslo snímku](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/firstslidenumber/) prezentace; poté se všechna číslování přepočítá. Například můžete začít od 0 nebo 10 a číslo na úvodním snímku skrýt.

**Co se stane se záhlavími/zápatími při exportu do PDF/obrázků/HTML?**

Jsou vykresleny jako běžné textové prvky prezentace. To znamená, že pokud jsou prvky viditelné na snímcích nebo stránkách s poznámkami, objeví se také ve výstupním formátu spolu se zbytkem obsahu.