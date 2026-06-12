---
title: Dia's samenstellen
type: docs
weight: 10
url: /nl/net/assemble-slides/
---
## **Een dia toevoegen aan een presentatie**
Voordat we het hebben over het toevoegen van dia's aan presentatiebestanden, laten we enkele feiten over de dia's bespreken. Elk PowerPoint‑presentatiebestand bevat een master‑/lay‑outdia en andere normale dia's. Dit betekent dat een presentatiebestand ten minste één of meer dia's bevat. Het is belangrijk te weten dat presentatiebestanden zonder dia's niet worden ondersteund door Aspose.Slides for .NET. Elke dia heeft een unieke Id en alle normale dia's zijn gerangschikt in een volgorde die wordt gespecificeerd door de nulgebaseerde index.

Aspose.Slides for .NET staat ontwikkelaars toe lege dia's aan hun presentatie toe te voegen. Om een lege dia aan de presentatie toe te voegen, volgt u de onderstaande stappen:

- Maak een instantie van de **Presentation**‑klasse
- Instantieer de **SlideCollection**‑klasse door een verwijzing in te stellen naar de Slides (een verzameling van inhoudsdia‑objecten) eigenschap die wordt blootgelegd door het Presentation‑object
- Voeg een lege dia toe aan de presentatie aan het einde van de verzameling inhoudsdia's door de **AddEmptySlide**‑methoden aan te roepen die beschikbaar zijn via het **SlideCollection**‑object
- Voer enige bewerkingen uit met de nieuw toegevoegde lege dia
- Schrijf tenslotte het presentatiebestand weg met behulp van het **Presentation**‑object

``` csharp

 PresentationEx pres = new PresentationEx;

//Instantieer de SlideCollection-klasse

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Voeg een lege dia toe aan de Slides-collectie

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Sla het PPTX-bestand op naar de schijf

pres.Write("EmptySlide.pptx");

``` 
## **Toegang tot dia's van een presentatie**
Aspose.Slides for .NET biedt de Presentation‑klasse die kan worden gebruikt om elke gewenste dia in de presentatie te vinden en te benaderen.

**Gebruik van Slides-collectie**

**Presentation**‑klasse vertegenwoordigt een presentatiebestand en maakt alle dia's beschikbaar als een **SlideCollection**‑collectie (dat is een verzameling van **Slide**‑objecten). Al deze dia's kunnen vanuit deze **Slides**‑collectie worden benaderd met behulp van een dia‑index.

``` csharp

 //Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Toegang tot een dia met behulp van zijn dia-index
SlideEx slide = pres.Slides[0];

``` 
## **Dia's verwijderen**
Wij weten dat de Presentation‑klasse in **Aspose.Slides for .NET** een presentatiebestand vertegenwoordigt. De Presentation‑klasse omvat een **SlideCollection** die fungeert als een opslagplaats voor alle dia's die deel uitmaken van de presentatie. Ontwikkelaars kunnen een dia uit deze Slides‑collectie op twee manieren verwijderen:

- Met behulp van een dia‑referentie
- Met behulp van een dia‑index

**Gebruik van dia‑referentie**

Om een dia te verwijderen met behulp van zijn referentie, volgt u de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse
- Verkrijg de referentie van een dia door gebruik te maken van zijn Id of Index
- Verwijder de gerefereerde dia uit de presentatie
- Schrijf het gewijzigde presentatiebestand weg

``` csharp

 //Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt
PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Toegang tot een dia met behulp van zijn index in de dia-collectie
SlideEx slide = pres.Slides[0];

//Verwijderen van een dia met behulp van zijn referentie
pres.Slides.Remove(slide);

//Schrijven van het presentatiebestand
pres.Write("modified.pptx");

``` 
## **Positie van een dia wijzigen**
Het is heel eenvoudig om de positie van een dia in de presentatie te wijzigen. Volg gewoon de onderstaande stappen:

- Maak een instantie van de Presentation‑klasse
- Verkrijg de referentie van een dia door gebruik te maken van zijn Index
- Wijzig het SlideNumber van de gerefereerde dia
- Schrijf het gewijzigde presentatiebestand weg

In het onderstaande voorbeeld hebben we de positie van een dia (die zich op nul‑indexpositie 1 bevond) van de presentatie gewijzigd naar index 1 (Positie 2).

``` csharp

 private static string MyDir = @"..\..\..\Sample Files\";

static void Main(string[] args)

{

AddingSlidetoPresentation();

AccessingSlidesOfPresentation();

RemovingSlides();

ChangingPositionOfSlide();

}

public static void AddingSlidetoPresentation()

{

Presentation pres = new Presentation();

//Instantieer de SlideCollection-klasse

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Voeg een lege dia toe aan de Slides-collectie

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Sla het PPTX-bestand op naar de schijf

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Toegang tot een dia met behulp van zijn dia-index

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instantieer een Presentation-object dat een presentatiebestand vertegenwoordigt

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Toegang tot een dia met behulp van zijn index in de dia-collectie

ISlide slide = pres.Slides[0];

//Verwijderen van een dia met behulp van zijn referentie

pres.Slides.Remove(slide);

//Schrijven van het presentatiebestand

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instantieer de Presentation-klasse om het bronpresentatiebestand te laden

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Haal de dia op waarvan de positie moet worden gewijzigd

    ISlide sld = pres.Slides[0];

    //Stel de nieuwe positie voor de dia in

    sld.SlideNumber = 2;

    //Schrijf de presentatie naar schijf

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Voorbeeldcode downloaden**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)