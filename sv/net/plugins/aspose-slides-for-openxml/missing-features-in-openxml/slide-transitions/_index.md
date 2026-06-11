---
title: Bildövergångar
type: docs
weight: 80
url: /sv/net/slide-transitions/
---
För att göra det enklare att förstå har vi demonstrerat användningen av Aspose.Slides för .NET för att hantera enkla bildövergångar. Utvecklare kan inte bara tillämpa olika bildövergångseffekter på bilderna, utan även anpassa beteendet för dessa övergångseffekter. För att skapa en enkel bildövergångseffekt, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Tillämpa en bildövergångstyp på bilden från en av de övergångseffekter som erbjuds av Aspose.Slides för .NET via **TransitionType**‑enumet
- Skriv den modifierade presentationsfilen.

## **Exempel**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Managing Slides Transitions.pptx";

//Skapa en Presentation‑klass som representerar en presentationsfil

using (Presentation pres = new Presentation(FileName))

{

    //Tillämpa cirkeltypens övergång på bild 1

    pres.Slides[0].SlideShowTransition.Type = TransitionType.Circle;

    //Tillämpa kamtypens övergång på bild 2

    pres.Slides[1].SlideShowTransition.Type = TransitionType.Comb;

    //Tillämpa zoom‑typens övergång på bild 3

    pres.Slides[2].SlideShowTransition.Type = TransitionType.Zoom;

    //Spara presentationen till disk

    pres.Save(FileName, SaveFormat.Pptx);

}

``` 
## **Ladda ner exempel kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **Ladda ner körbart exempel**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Managing%20Slides%20Transitions)

{{% alert color="primary" %}} 
För mer information, besök [Hantera bildövergångar](/slides/sv/net/slide-transition/).
{{% /alert %}}