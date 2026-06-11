---
title: Hantera presentationens sidhuvuden och sidfötter i .NET
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/net/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ange sidhuvud
- ange sidfot
- handout
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- .NET
- C#
- Aspose.Slides
description: "Använd Aspose.Slides för .NET för att lägga till och anpassa sidhuvuden och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera inställningar för sidhuvud och sidfot i PowerPoint‑presentationer. Sidhuvuden och sidfötter hanteras på presentations‑masternivå, och API‑et tillhandahåller metoder för att ange text för sidfot, ändra synlighet för sidfot och uppdatera text för sidhuvud på master‑notes‑bilder.

Du kan också hantera sidhuvud och sidfot för handouts och notes‑bilder. Detta inkluderar att ändra synlighet och text för platshållare för header, footer, bildnummer och datum‑tid på notes‑master, alla barn‑notes‑bilder eller en enskild notes‑bild.

## **Hantera text för sidhuvud och sidfot**

Anteckningar för vissa specifika bilder kan uppdateras enligt exemplet nedan:

```c#
// Läs in presentation
Presentation pres = new Presentation("headerTest.pptx");

// Ställer in sidfot
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Åtkomst och uppdatera sidhuvud
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Spara presentation
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Metod för att ange text för sidhuvud/sidfot
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




## **Hantera sidhuvud och sidfot på handout‑ och notes‑bilder**
Aspose.Slides for .NET stöder Header och Footer i handout‑ och notes‑bilder. Följ stegen nedan:

- Ladda en [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) som innehåller en video.
- Ändra Header‑ och Footer‑inställningar för notes‑master och alla notes‑bilder.
- Ställ in att master‑notes‑bild och alla underordnade Footer‑platshållare är synliga.
- Ställ in att master‑notes‑bild och alla underordnade Datum‑och‑tid‑platshållare är synliga.
- Ändra Header‑ och Footer‑inställningar för endast den första notes‑bilden.
- Ställ in att notes‑bildens Header‑platshållare är synlig.
- Ange text för notes‑bildens Header‑platshållare.
- Ange text för notes‑bildens Datum‑tid‑platshållare.
- Skriv den modifierade presentationsfilen.

Kodexempel finns i exemplet nedan.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Ändra inställningar för sidhuvud och sidfot för notes-master och alla notes-bilder
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // gör master notes-bilden och alla underordnade Footer-platshållare synliga
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // gör master notes-bilden och alla underordnade Header-platshållare synliga
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // gör master notes-bilden och alla underordnade SlideNumber-platshållare synliga
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // gör master notes-bilden och alla underordnade datum- och tids-platshållare synliga

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // sätt text till master notes-bilden och alla underordnade Header-platshållare
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // sätt text till master notes-bilden och alla underordnade Footer-platshållare
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // sätt text till master notes-bilden och alla underordnade datum- och tids-platshållare
	}

	// Ändra inställningar för sidhuvud och sidfot endast för den första notes-bilden
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // gör denna notes-bildens Header-platshållare synlig

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // gör denna notes-bildens Footer-platshållare synlig

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // gör denna notes-bildens SlideNumber-platshållare synlig

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // gör denna notes-bildens Date-time-platshållare synlig

		headerFooterManager.SetHeaderText("New header text"); // sätt text till notes-bildens Header-platshållare
		headerFooterManager.SetFooterText("New footer text"); // sätt text till notes-bildens Footer-platshållare
		headerFooterManager.SetDateTimeText("New date and time text"); // sätt text till notes-bildens Date-time-platshållare
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Kan jag lägga till ett "header" i vanliga bilder?**

I PowerPoint finns "Header" endast för notes och handouts; på vanliga bilder är de stödjade elementen footer, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: header endast för Notes/Handout, och på bilder—Footer/DateTime/SlideNumber.

**Vad händer om layouten saknar ett footer‑område—kan jag "aktivera" dess synlighet?**

Ja. Kontrollera synligheten via header/footer‑hanteraren och aktivera den vid behov. Dessa API‑indikatorer och metoder är avsedda för fall där platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ställ in presentationens [first slide number](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/firstslidenumber/); därefter beräknas all numrering om. Till exempel kan du börja på 0 eller 10 och dölja numret på titelbilden.

**Vad händer med header/footer vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det vill säga, om elementen är synliga på bilder/notes‑sidor kommer de också att visas i exportformatet tillsammans med resten av innehållet.