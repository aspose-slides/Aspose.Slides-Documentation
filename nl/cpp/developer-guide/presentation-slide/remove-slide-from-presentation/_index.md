---
title: "Dia's verwijderen uit presentaties in C++"
linktitle: "Dia verwijderen"
type: docs
weight: 30
url: /nl/cpp/remove-slide-from-presentation/
keywords:
- dia verwijderen
- dia wissen
- ongebruikte dia verwijderen
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Verwijder moeiteloos dia's uit PowerPoint- en OpenDocument-presentaties met Aspose.Slides voor C++. Verkrijg duidelijke code-voorbeelden en verbeter uw workflow."
---
## **Introductie**

Als een dia (of de inhoud ervan) overbodig wordt, kunt u deze verwijderen. Aspose.Slides biedt de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse die [ISlideCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islidecollection/) omvat, een repository voor alle dia's in een presentatie. Door gebruik te maken van pointers (referentie of index) voor een bekende [ISlide](https://reference.aspose.com/slides/nl/cpp/aspose.slides/islide/)‑object, kunt u de dia opgeven die u wilt verwijderen. 

## **Dia verwijderen via referentie**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
1. Verkrijg een referentie naar de dia die u wilt verwijderen via de ID of index.  
1. Verwijder de verwijzende dia uit de presentatie.  
1. Sla de gewijzigde presentatie op. 

Deze C++‑code laat zien hoe u een dia via zijn referentie verwijdert: 

```c++
	// Het pad naar de map met documenten
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByReference.pptx";

	// Instantieert een Presentation object dat een presentatiebestand vertegenwoordigt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Benadert een dia via zijn index in de dia collectie
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Verwijdert een dia via zijn referentie
	pres->get_Slides()->Remove(slide);

	// Slaat de gewijzigde presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```


## **Dia verwijderen via index**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.  
1. Verwijder de dia uit de presentatie via zijn indexpositie.  
1. Sla de gewijzigde presentatie op. 

Deze C++‑code laat zien hoe u een dia via zijn index verwijdert: 

```c++
	// Het pad naar de map met documenten
	const String templatePath = L"../templates/AddSlides.pptx";
	const String outPath = L"../out/RemoveSlidesByID.pptx";

	// Instantieert een Presentation object dat een presentatiewebestand vertegenwoordigt
	SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

	// Verwijdert een dia via zijn index
	pres->get_Slides()->RemoveAt(0);

	// Slaat de gewijzigde presentatie op
	pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Ongebruikte lay‑outdia's verwijderen**

Aspose.Slides biedt de [RemoveUnusedLayoutSlides()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/)‑methode (van de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse) om ongewenste en ongebruikte lay‑outdia's te verwijderen. Deze C++‑code laat zien hoe u een lay‑outdia uit een PowerPoint‑presentatie verwijdert:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedLayoutSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **Ongebruikte masterslides verwijderen**

Aspose.Slides biedt de [RemoveUnusedMasterSlides()](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/)‑methode (van de [Compress](https://reference.aspose.com/slides/nl/cpp/aspose.slides.lowcode/compress/)‑klasse) om ongewenste en ongebruikte masterslides te verwijderen. Deze C++‑code laat zien hoe u een masterslide uit een PowerPoint‑presentatie verwijdert:

```c++
auto pres = System::MakeObject<Presentation>(u"pres.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(pres);

pres->Save(u"pres-out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Wat gebeurt er met de dia‑indexen nadat ik een dia verwijder?**

Na verwijdering wordt de [collection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/slidecollection/) opnieuw geïndexeerd: elke volgende dia verschuift één positie naar links, zodat eerdere indexnummers verouderd zijn. Als u een stabiele referentie nodig hebt, gebruik dan de blijvende ID van elke dia in plaats van de index.

**Is de ID van een dia verschillend van de index, en verandert deze wanneer aangrenzende dia's worden verwijderd?**

Ja. De index is de positie van de dia en verandert wanneer dia's worden toegevoegd of verwijderd. De dia‑ID is een blijvende identifier en verandert niet wanneer andere dia's worden verwijderd.

**Hoe beïnvloedt het verwijderen van een dia de secties?**

Als de dia tot een sectie behoorde, bevat die sectie één dia minder. De sectiestructuur blijft behouden; als een sectie leeg wordt, kunt u [verwijderen of secties reorganiseren](/slides/nl/cpp/slide-section/) naar behoefte.

**Wat gebeurt er met notities en opmerkingen die aan een dia zijn gekoppeld wanneer deze wordt verwijderd?**

[Notes](/slides/nl/cpp/presentation-notes/) en [comments](/slides/nl/cpp/presentation-comments/) zijn gekoppeld aan die specifieke dia en worden samen met de dia verwijderd. De inhoud op andere dia's blijft ongewijzigd.

**Hoe verschilt het verwijderen van dia's van het opschonen van ongebruikte lay-outs/masters?**

Verwijderen verwijdert specifieke normale dia's uit de presentatie. Het opschonen van ongebruikte lay-outs/masters verwijdert lay‑out‑ of masterslides waar niets naar verwijst, waardoor de bestandsgrootte wordt verkleind zonder de resterende dia‑inhoud te wijzigen. Deze handelingen zijn complementair: meestal eerst verwijderen, daarna opschonen.