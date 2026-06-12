---
title: Diaovergangen
type: docs
weight: 80
url: /nl/net/slide-transitions/
---
Om het makkelijker te begrijpen, hebben we het gebruik van Aspose.Slides for .NET gedemonstreerd om eenvoudige diaovergangen te beheren. Ontwikkelaars kunnen niet alleen verschillende diaovergangseffecten op de dia's toepassen, maar ook het gedrag van deze overgangseffecten aanpassen. Om een eenvoudig diaovergangseffect te creëren, volgt u de onderstaande stappen:

- Maak een instantie van de klasse Presentation
- Pas een Slide Transition Type toe op de dia vanuit een van de overgangseffecten die door Aspose.Slides for .NET worden aangeboden via de **TransitionType**-enum
- Schrijf het gewijzigde presentatie-bestand weg.
## **Voorbeeld**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Instantieer de Presentation-klasse die een presentatiebestand voorstelt

using (Presentation pres = new Presentation(FileName))

{

    //Pas een cirkeltype overgang toe op dia 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Pas een kamtype overgang toe op dia 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Pas een zoomtype overgang toe op dia 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Schrijf de presentatie naar schijf

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Download Voorbeeldcode**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Download Werkend Voorbeeld**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 

Voor meer details, bezoek [Beheer van Diaovergangen](/slides/nl/net/slide-transition/).

{{% /alert %}}