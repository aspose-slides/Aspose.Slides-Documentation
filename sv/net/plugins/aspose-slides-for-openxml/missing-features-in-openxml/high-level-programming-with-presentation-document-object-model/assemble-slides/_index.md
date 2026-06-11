---
title: Sätt ihop bilder
type: docs
weight: 10
url: /sv/net/assemble-slides/
---
## **Lägg till en bild i en presentation**
Innan vi pratar om att lägga till bilder i presentationsfilerna, låt oss diskutera några fakta om bilderna. Varje PowerPoint‑presentationfil innehåller en Master‑/Layout‑bild och andra vanliga bilder. Det betyder att en presentationsfil innehåller minst en eller flera bilder. Det är viktigt att veta att presentationsfiler utan bilder inte stöds av Aspose.Slides for .NET. Varje bild har ett unikt Id och alla vanliga bilder är ordnade i en följd som specificeras av ett nollbaserat index.

Aspose.Slides for .NET låter utvecklare lägga till tomma bilder i deras presentation. För att lägga till en tom bild i presentationen, följ stegen nedan:

- Skapa en instans av **Presentation**‑klassen
- Instansiera **SlideCollection**‑klassen genom att sätta en referens till egenskapen Slides (samling av innehålls‑Slide‑objekt) som exponeras av Presentation‑objektet.
- Lägg till en tom bild i presentationen i slutet av samlingen av innehållsbilder genom att anropa metoden **AddEmptySlide** som exponeras av **SlideCollection**‑objektet.
- Utför någon åtgärd med den nylagda tomma bilden
- Skriv slutligen presentationsfilen med hjälp av **Presentation**‑objektet

``` csharp

 PresentationEx pres = new PresentationEx;

//Instansiera SlideCollection-klassen

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Lägg till en tom bild i Slides-samlingen

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Spara PPTX-filen till disken

pres.Write("EmptySlide.pptx");

``` 
## **Åtkomst till bilder i en presentation**
Aspose.Slides for .NET tillhandahåller Presentation‑klassen som kan användas för att hitta och komma åt någon önskad bild som finns i presentationen.

**Använda Slides‑samling**

**Presentation**‑klassen representerar en presentationsfil och exponerar alla bilder i den som en **SlideCollection**‑samling (det är en samling av **Slide**‑objekt). Alla dessa bilder kan nås från **Slides**‑samlingen med hjälp av ett bildindex.

``` csharp

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Kommer åt en bild med hjälp av dess bildindex

SlideEx slide = pres.Slides[0];

``` 
## **Ta bort bilder**
Vi vet att Presentation‑klassen i **Aspose.Slides for .NET** representerar en presentationsfil. Presentation‑klassen kapslar in en **SlideCollection** som fungerar som ett arkiv för alla bilder som är en del av presentationen. Utvecklare kan ta bort en bild från denna Slides‑samling på två sätt:

- Med bildreferens
- Med bildindex

**Använda bildreferens**

För att ta bort en bild med dess referens, följ stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess Id eller Index
- Ta bort den refererade bilden från presentationen
- Skriv den modifierade presentationsfilen

``` csharp

 //Instansiera ett Presentation-objekt som representerar en presentationsfil

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Kommer åt en bild med hjälp av dess index i bildsamlingen

SlideEx slide = pres.Slides[0];

//Tar bort en bild med dess referens

pres.Slides.Remove(slide);

//Skriver presentationsfilen

pres.Write("modified.pptx");

``` 
## **Ändra positionen för en bild**
Det är mycket enkelt att ändra positionen för en bild i presentationen. Följ bara stegen nedan:

- Skapa en instans av Presentation‑klassen
- Hämta referensen till en bild genom att använda dess Index
- Ändra SlideNumber för den refererade bilden
- Skriv den modifierade presentationsfilen

I exemplet nedan har vi ändrat positionen för en bild (som ligger på nollbaserad indexposition 1) i presentationen till index 1 (Position 2).

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

//Instansiera SlideCollection-klassen

ISlideCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

    //Lägg till en tom bild i Slides-samlingen

    slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Spara PPTX-filen till disken

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void AccessingSlidesOfPresentation()

{

//Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Kommer åt en bild med hjälp av dess bildindex

ISlide slide = pres.Slides[0];

}

public static void RemovingSlides()

{

//Instansiera ett Presentation-objekt som representerar en presentationsfil

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

//Kommer åt en bild med hjälp av dess index i bildsamlingen

ISlide slide = pres.Slides[0];

//Tar bort en bild med dess referens

pres.Slides.Remove(slide);

//Skriver presentationsfilen

pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

public static void ChangingPositionOfSlide()

{

//Instansiera Presentation-klassen för att läsa in källpresentationsfilen

Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");

{

    //Hämta bilden vars position ska ändras

    ISlide sld = pres.Slides[0];

    //Ställ in den nya positionen för bilden

    sld.SlideNumber = 2;

    //Skriv presentationen till disken

    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);

}

}

``` 
## **Ladda ner exempelkod**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)