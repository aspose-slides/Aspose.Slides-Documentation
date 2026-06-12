---
title: Beheer presentatie-headers en -footers in .NET
linktitle: Koptekst en voettekst
type: docs
weight: 140
url: /nl/net/presentation-header-and-footer/
keywords:
- koptekst
- koptekst tekst
- voettekst
- voettekst tekst
- koptekst instellen
- voettekst instellen
- hand-out
- notities
- PowerPoint
- OpenDocument
- presentatie
- .NET
- C#
- Aspose.Slides
description: "Gebruik Aspose.Slides voor .NET om kopteksten en voetteksten toe te voegen en aan te passen in PowerPoint- en OpenDocument-presentaties voor een professionele uitstraling."
---
## **Overzicht**

Aspose.Slides biedt u de mogelijkheid om de header‑ en footersettings in PowerPoint‑presentaties te beheren. Headers en footers worden op het master‑nivo van de presentatie afgehandeld, en de API levert methoden om footertekst in te stellen, de zichtbaarheid van de footer te wijzigen en headertekst op master‑notitieslides bij te werken.

U kunt ook headers en footers beheren voor handout‑ en notitieslides. Dit omvat het wijzigen van de zichtbaarheid en tekst van header, footer, slidennummer en datum‑tijd‑plaatsaanduidingen voor de notities‑master, alle onderliggende notitieslides of een individuele notitieslide.

## **Beheer Header- en Footertekst**

Notities van een specifieke slide kunnen worden bijgewerkt zoals weergegeven in het voorbeeld hieronder:

```c#
// Presentatie laden
Presentation pres = new Presentation("headerTest.pptx");

// Voettekst instellen
pres.HeaderFooterManager.SetAllFootersText("My Footer text");
pres.HeaderFooterManager.SetAllFootersVisibility(true);

// Header openen en bijwerken
IMasterNotesSlide masterNotesSlide = pres.MasterNotesSlideManager.MasterNotesSlide;
if (null != masterNotesSlide)
{
	UpdateHeaderFooterText(masterNotesSlide);
}

// Presentatie opslaan
pres.Save("HeaderFooterJava.pptx", SaveFormat.Pptx);
```



```c#
// Methode om Header/Footer-tekst in te stellen
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




## **Beheer Headers en Footers op Handout- en Notitieslides**
Aspose.Slides voor .NET ondersteunt Header en Footer in handout‑ en notitieslides. Volg de onderstaande stappen:

- Laad een [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) dat een video bevat.
- Wijzig Header‑ en Footer‑instellingen voor de notities‑master en alle notitieslides.
- Maak de Footer‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Maak de Datum‑en‑tijd‑plaatsaanduidingen op de master‑notitieslide en alle onderliggende slides zichtbaar.
- Wijzig Header‑ en Footer‑instellingen alleen voor de eerste notitieslide.
- Maak de Header‑plaatsaanduiding op de notitieslide zichtbaar.
- Stel tekst in voor de Header‑plaatsaanduiding op de notitieslide.
- Stel tekst in voor de Datum‑tijd‑plaatsaanduiding op de notitieslide.
- Schrijf het gewijzigde presentatie‑bestand weg.

Codevoorbeeld wordt hieronder gegeven.

```c#
using (Presentation presentation = new Presentation("presentation.pptx"))
{
	// Wijzig header- en footersettings voor de notitiesmaster en alle notitieslides
	IMasterNotesSlide masterNotesSlide = presentation.MasterNotesSlideManager.MasterNotesSlide;
	if (masterNotesSlide != null)
	{
		IMasterNotesSlideHeaderFooterManager headerFooterManager = masterNotesSlide.HeaderFooterManager;

		headerFooterManager.SetHeaderAndChildHeadersVisibility(true); // maak de master notitieslide en alle onderliggende Footer-plaatsaanduidingen zichtbaar
		headerFooterManager.SetFooterAndChildFootersVisibility(true); // maak de master notitieslide en alle onderliggende Header-plaatsaanduidingen zichtbaar
		headerFooterManager.SetSlideNumberAndChildSlideNumbersVisibility(true); // maak de master notitieslide en alle onderliggende SlideNumber-plaatsaanduidingen zichtbaar
		headerFooterManager.SetDateTimeAndChildDateTimesVisibility(true); // maak de master notitieslide en alle onderliggende Datum-tijd-plaatsaanduidingen zichtbaar

		headerFooterManager.SetHeaderAndChildHeadersText("Header text"); // stel tekst in voor de master notitieslide en alle onderliggende Header-plaatsaanduidingen
		headerFooterManager.SetFooterAndChildFootersText("Footer text"); // stel tekst in voor de master notitieslide en alle onderliggende Footer-plaatsaanduidingen
		headerFooterManager.SetDateTimeAndChildDateTimesText("Date and time text"); // stel tekst in voor de master notitieslide en alle onderliggende Datum-tijd-plaatsaanduidingen
	}

	// Wijzig header- en footersettings alleen voor de eerste notitieslide
	INotesSlide notesSlide = presentation.Slides[0].NotesSlideManager.NotesSlide;
	if (notesSlide != null)
	{
		INotesSlideHeaderFooterManager headerFooterManager = notesSlide.HeaderFooterManager;
		if (!headerFooterManager.IsHeaderVisible)
			headerFooterManager.SetHeaderVisibility(true); // maak deze notitieslide Header-plaatsaanduiding zichtbaar

		if (!headerFooterManager.IsFooterVisible)
			headerFooterManager.SetFooterVisibility(true); // maak deze notitieslide Footer-plaatsaanduiding zichtbaar

		if (!headerFooterManager.IsSlideNumberVisible)
			headerFooterManager.SetSlideNumberVisibility(true); // maak deze notitieslide SlideNumber-plaatsaanduiding zichtbaar

		if (!headerFooterManager.IsDateTimeVisible)
			headerFooterManager.SetDateTimeVisibility(true); // maak deze notitieslide Datum-tijd-plaatsaanduiding zichtbaar

		headerFooterManager.SetHeaderText("New header text"); // stel tekst in voor notitieslide Header-plaatsaanduiding
		headerFooterManager.SetFooterText("New footer text"); // stel tekst in voor notitieslide Footer-plaatsaanduiding
		headerFooterManager.SetDateTimeText("New date and time text"); // stel tekst in voor notitieslide Datum-tijd-plaatsaanduiding
	}
	presentation.Save("testresult.pptx",SaveFormat.Pptx);
}
		
 }
```

## **FAQ**

**Kan ik een “header” toevoegen aan gewone slides?**

In PowerPoint bestaat een “Header” alleen voor notities en handouts; op gewone slides zijn de ondersteunde elementen de footer, datum/tijd en slidennummer. In Aspose.Slides gelden dezelfde beperkingen: header alleen voor Notities/Handout, en op slides — Footer/DateTime/SlideNumber.

**Wat als de lay-out geen footer‑gebied bevat—kan ik de zichtbaarheid “inschakelen”?**

Ja. Controleer de zichtbaarheid via de header/footer‑manager en activeer deze indien nodig. Deze API‑indicatoren en methoden zijn ontworpen voor situaties waarin de plaatsaanduiding ontbreekt of verborgen is.

**Hoe laat ik het slidennummer beginnen bij een andere waarde dan 1?**

Stel het [first slide number](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/firstslidenumber/) van de presentatie in; daarna wordt alle nummering opnieuw berekend. U kunt bijvoorbeeld beginnen bij 0 of 10, en het nummer op de titel‑slide verbergen.

**Wat gebeurt er met headers/footers bij exporteren naar PDF/afbeeldingen/HTML?**

Ze worden gerenderd als gewone textelementen van de presentatie. Dat wil zeggen, als de elementen zichtbaar zijn op slides/notitiepagina’s, verschijnen ze ook in het geëxporteerde formaat samen met de rest van de inhoud.