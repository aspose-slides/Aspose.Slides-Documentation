---
title: "Toegang tot presentatiedia's in C++"
linktitle: Toegang tot dia
type: docs
weight: 20
url: /nl/cpp/access-slide-in-presentation/
keywords:
- toegang tot dia
- dia-index
- dia-id
- dia-positie
- positie wijzigen
- dia-eigenschappen
- dia-nummer
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Leer hoe u dia's kunt benaderen en beheren in PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Verhoog de productiviteit met code-voorbeelden."
---
## **Overzicht**

Dit artikel legt uit hoe je dia's in een presentatie kunt benaderen en beheren met Aspose.Slides. Het laat zien hoe je dia's kunt ophalen via hun nul‑gebaseerde index uit de dia‑verzameling en hoe je een dia kunt benaderen via de unieke ID met de `GetSlideById`-methode.

Je leert ook hoe je de positie van een dia kunt wijzigen met de `set_SlideNumber`-methode en hoe je het beginnende dia‑nummer voor een presentatie kunt definiëren met de `set_FirstSlideNumber`-methode. De voorbeelden tonen hoe je een presentatie laadt, dia‑referenties verkrijgt, de volgorde of nummering van dia's bijwerkt, en de gewijzigde presentatie opslaat.

## **Dia benaderen via index**

Alle dia's in een presentatie zijn numeriek gerangschikt op basis van de positie, beginnend bij 0. De eerste dia is toegankelijk via index 0; de tweede dia via index 1; enzovoort.

De Presentation‑klasse, die een presentatie‑bestand voorstelt, maakt alle dia's beschikbaar als een [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/)‑collectie (collectie van [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/)‑objecten). Deze C++‑code laat zien hoe je een dia via zijn index kunt benaderen:

```c++
	// Het pad naar de documentmap.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instantieert de Presentation-klasse.
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Haal een referentie naar een dia op via zijn index.
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
```

## **Dia benaderen via ID**

Elke dia in een presentatie heeft een unieke ID. Je kunt de [GetSlideById()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/getslidebyid/)‑methode (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse) gebruiken om die ID te targeten. Deze C++‑code laat zien hoe je een geldige dia‑ID opgeeft en die dia benadert via de [GetSlideById()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/getslidebyid/)‑methode:

```c++
	// Het pad naar de documentenmap.
	const String templatePath = u"../templates/AddSlides.pptx";

	// Instantieert de Presentation-klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Haalt een dia-ID op
	int id = pres->get_Slides()->idx_get(0)->get_SlideId();

	// Benadert de dia via zijn ID
	SharedPtr<IBaseSlide> slide = pres->GetSlideById(id);
```

## **Dia‑positie wijzigen**

Aspose.Slides maakt het mogelijk om de positie van een dia te wijzigen. Bijvoorbeeld, je kunt opgeven dat de eerste dia de tweede dia moet worden.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal de referentie van de dia (wiens positie je wilt wijzigen) op via zijn index.
1. Stel een nieuwe positie in voor de dia via de eigenschap [set_SlideNumber()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/set_slidenumber/).
1. Sla de gewijzigde presentatie op.

Deze C++‑code demonstreert een bewerking waarbij de dia op positie 1 naar positie 2 wordt verplaatst:

```c++
	// Het pad naar de documentenmap.
	const String templatePath = u"../templates/AddSlides.pptx";
	const String outPath = u"../out/ChangeSlidePosition.pptx";

	// Instantieert de Presentation-klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Haalt de dia op waarvan de positie wordt gewijzigd
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Stelt de nieuwe positie voor de dia in
	slide->set_SlideNumber(2);

	// Slaat de gewijzigde presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

De eerste dia werd de tweede; de tweede dia werd de eerste. Wanneer je de positie van een dia wijzigt, worden de andere dia's automatisch aangepast.

## **Dia‑nummer instellen**

Met de eigenschap [set_FirstSlideNumber()](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/set_firstslidenumber/) (beschikbaar via de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse) kun je een nieuw nummer opgeven voor de eerste dia in een presentatie. Deze bewerking zorgt ervoor dat de andere dia‑nummers opnieuw worden berekend.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal het dia‑nummer op.
1. Stel het dia‑nummer in.
1. Sla de gewijzigde presentatie op.

Deze C++‑code demonstreert een bewerking waarbij het eerste dia‑nummer wordt ingesteld op 10:

```c++
	// Het pad naar de documentenmap.
	const String outPath = u"../out/SetSlideNumber_out.pptx";
	const String templatePath = u"../templates/AccessSlides.pptx";

	//Instantieert de Presentation-klasse
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Haalt het dia-nummer op
	int firstSlideNumber = pres->get_FirstSlideNumber();

	// Stelt het dia-nummer in
	pres->set_FirstSlideNumber(2);
	
	// Slaat de gewijzigde presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

Als je de eerste dia wilt overslaan, kun je de nummering starten vanaf de tweede dia (en de nummering voor de eerste dia verbergen) op deze manier:

```c++
auto presentation = System::MakeObject<Presentation>();

auto layoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

auto slides = presentation->get_Slides();
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);
slides->AddEmptySlide(layoutSlide);

// Sets the number for the first presentation slide
presentation->set_FirstSlideNumber(0);

// Shows slide numbers for all slides
presentation->get_HeaderFooterManager()->SetAllSlideNumbersVisibility(true);

// Hides the slide number for the first slide
slides->idx_get(0)->get_HeaderFooterManager()->SetSlideNumberVisibility(false);

// Saves the modified presentation
presentation->Save(u"output.pptx", SaveFormat::Pptx);
```

## **Veelgestelde vragen**

**Komt het dia-nummer dat een gebruiker ziet overeen met de nul‑gebaseerde index van de collectie?**

Het nummer dat op een dia wordt getoond kan beginnen met een willekeurige waarde (bijv. 10) en hoeft niet overeen te komen met de index; de relatie wordt bepaald door de instelling voor het [eerste dia‑nummer](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/set_firstslidenumber/) van de presentatie.

**Hebben verborgen dia's invloed op de indexering?**

Ja. Een verborgen dia blijft in de collectie en wordt meegeteld bij het indexeren; “verborgen” betreft alleen de weergave, niet de positie in de collectie.

**Verandert de index van een dia wanneer andere dia's worden toegevoegd of verwijderd?**

Ja. Indexen weerspiegelen altijd de huidige volgorde van de dia's en worden opnieuw berekend bij invoegen, verwijderen en verplaatsen.