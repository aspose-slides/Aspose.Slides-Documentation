---
title: Hantera presentationens sidhuvuden och sidfötter i C++
linktitle: Sidhuvud och sidfot
type: docs
weight: 140
url: /sv/cpp/presentation-header-and-footer/
keywords:
- sidhuvud
- sidhuvudstext
- sidfot
- sidfotstext
- ställ in sidhuvud
- ställ in sidfot
- utskrift
- anteckningar
- PowerPoint
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Använd Aspose.Slides för C++ för att lägga till och anpassa sidhuvuden och sidfötter i PowerPoint- och OpenDocument-presentationer för ett professionellt utseende."
---
## **Översikt**

Aspose.Slides låter dig hantera inställningar för sidhuvud och sidfot i PowerPoint-presentationer. Sidhuvuden och sidfötter hanteras på presentationsmästarens nivå, och API:et tillhandahåller metoder för att ställa in sidfotstext, ändra sidfotens synlighet och uppdatera sidhuvudstext på huvudsakliga notssidor.

Du kan också hantera sidhuvuden och sidfötter för utskrifts- och notsidor. Detta inkluderar att ändra synligheten och texten för platshållare för sidhuvud, sidfot, bildnummer och datum/tid för notsmästarna, alla underordnade notsidor eller en enskild notsida.

## **Hantera sidhuvud- och sidfottext**

Anteckningar för en specifik bild kan uppdateras som visas i exemplet nedan:

``` cpp
// Funktion för att ange sidhuvud-/sidfottext
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
// Ladda presentation
auto pres = System::MakeObject<Presentation>(u"headerTest.pptx");

// Ställa in sidfot
pres->get_HeaderFooterManager()->SetAllFootersText(u"My Footer text");
pres->get_HeaderFooterManager()->SetAllFootersVisibility(true);

// Åtkomst och uppdatera sidhuvud
auto masterNotesSlide = pres->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (nullptr != masterNotesSlide)
{
    UpdateHeaderFooterText(masterNotesSlide);
}

// Spara presentation
pres->Save(u"HeaderFooterJava.pptx", SaveFormat::Pptx);
```

## **Hantera sidhuvuden och sidfötter på utskrifts- och notsidor**
Aspose.Slides för C++ stöder sidhuvud och sidfot i utskrifts- och notsidor. Följ stegen nedan:

- Läs in en [Presentation ](https://reference.aspose.com/slides/sv/cpp/class/aspose.slides.presentation) som innehåller en video.
- Ändra inställningarna för sidhuvud och sidfot för notsmästaren och alla notsidor.
- Gör sidfotssplatshållare på huvudnotssidan och alla underordnade synliga.
- Gör datum- och tidsplatshållare på huvudnotssidan och alla underordnade synliga.
- Ändra inställningarna för sidhuvud och sidfot enbart för den första notsidan.
- Gör sidhuvudplatshållare för notsidan synlig.
- Ställ in text för sidhuvudplatshållaren på notsidan.
- Ställ in text för datum‑tidsplatshållaren på notsidan.
- Skriv den modifierade presentationsfilen.

Kodexempel finns i exemplet nedan.

``` cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");
// Ändra inställningarna för sidhuvud och sidfot för notsmästaren och alla notsidor
auto masterNotesSlide = presentation->get_MasterNotesSlideManager()->get_MasterNotesSlide();
if (masterNotesSlide != nullptr)
{
	auto headerFooterManager = masterNotesSlide->get_HeaderFooterManager();

	// gör master‑notssidan och alla underordnade sidfot‑platshållare synliga
	headerFooterManager->SetHeaderAndChildHeadersVisibility(true);
	// gör master‑notssidan och alla underordnade sidhuvud‑platshållare synliga
	headerFooterManager->SetFooterAndChildFootersVisibility(true);
	// gör master‑notssidan och alla underordnade bildnummer‑platshållare synliga
	headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
	// gör master‑notssidan och alla underordnade datum‑och‑tids‑platshållare synliga
	headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

	// sätt text på master‑notssidan och alla underordnade sidhuvud‑platshållare
	headerFooterManager->SetHeaderAndChildHeadersText(u"Header text");
	// sätt text på master‑notssidan och alla underordnade sidfot‑platshållare
	headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
	// sätt text på master‑notssidan och alla underordnade datum‑och‑tids‑platshållare
	headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");
}

// Ändra inställningarna för sidhuvud och sidfot endast för den första notssidan
auto notesSlide = presentation->get_Slides()->idx_get(0)->get_NotesSlideManager()->get_NotesSlide();
if (notesSlide != nullptr)
{
	auto headerFooterManager = notesSlide->get_HeaderFooterManager();
	if (!headerFooterManager->get_IsHeaderVisible())
	{
		// gör denna notssidas sidhuvud‑platshållare synlig
		headerFooterManager->SetHeaderVisibility(true);
	}

	if (!headerFooterManager->get_IsFooterVisible())
	{
		// gör denna notssidas sidfot‑platshållare synlig
		headerFooterManager->SetFooterVisibility(true);
	}

	if (!headerFooterManager->get_IsSlideNumberVisible())
	{
		// gör denna notssidas bildnummer‑platshållare synlig
		headerFooterManager->SetSlideNumberVisibility(true);
	}
	
	if (!headerFooterManager->get_IsDateTimeVisible())
	{
		// gör denna notssidas datum‑tid‑platshållare synlig
		headerFooterManager->SetDateTimeVisibility(true);
	}
	
	// sätt text på notssidans sidhuvud‑platshållare
	headerFooterManager->SetHeaderText(u"New header text");
	// sätt text på notssidans sidfot‑platshållare
	headerFooterManager->SetFooterText(u"New footer text");
	// sätt text på notssidans datum‑tid‑platshållare
	headerFooterManager->SetDateTimeText(u"New date and time text");
}

presentation->Save(u"testresult.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Kan jag lägga till ett "sidhuvud" på vanliga bilder?**

I PowerPoint finns "sidhuvud" bara för noteringar och utdelningar; på vanliga bilder är de stödda elementen sidfot, datum/tid och bildnummer. I Aspose.Slides gäller samma begränsningar: sidhuvud endast för Noteringar/Utdelning, och på bilder – Sidfot/DatumTid/Bildnummer.

**Vad händer om layouten inte innehåller ett sidfotområde – kan jag "aktivera" dess synlighet?**

Ja. Kontrollera synligheten via sidhuvud-/sidfot‑hanteraren och aktivera den om det behövs. Dessa API‑indikatorer och metoder är avsedda för situationer när platshållaren saknas eller är dold.

**Hur får jag bildnumret att börja från ett annat värde än 1?**

Ställ in presentationens [first slide number](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/set_firstslidenumber/); därefter räknas all numrering om. Till exempel kan du börja på 0 eller 10, och dölja numret på titelsliden.

**Vad händer med sidhuvuden/sidfötter vid export till PDF/bilder/HTML?**

De renderas som vanliga textelement i presentationen. Det betyder att om elementen är synliga på bild-/notssidor, så kommer de också att visas i utdataformatet tillsammans med resten av innehållet.