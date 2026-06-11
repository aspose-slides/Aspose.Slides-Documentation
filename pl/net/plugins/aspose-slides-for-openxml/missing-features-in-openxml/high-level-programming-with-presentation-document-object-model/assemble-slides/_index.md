---
title: Składanie slajdów
type: docs
weight: 10
url: /pl/net/assemble-slides/
---
## **Dodaj slajd do prezentacji**
Zanim przejdziemy do dodawania slajdów do plików prezentacji, omówmy kilka faktów dotyczących slajdów. Każdy plik prezentacji PowerPoint zawiera slajd Master / Layout oraz inne zwykłe slajdy. Oznacza to, że plik prezentacji zawiera co najmniej jeden slajd. Ważne jest, aby wiedzieć, że pliki prezentacji bez slajdów nie są obsługiwane przez Aspose.Slides for .NET. Każdy slajd ma unikalny Id, a wszystkie zwykłe slajdy są uporządkowane zgodnie z indeksem zerowym.

Aspose.Slides for .NET pozwala programistom dodać puste slajdy do ich prezentacji. Aby dodać pusty slajd w prezentacji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy **Presentation**
- Zainicjuj klasę **SlideCollection**, ustawiając odwołanie do właściwości Slides (kolekcja obiektów Slide) udostępnionej przez obiekt Presentation
- Dodaj pusty slajd do prezentacji na końcu kolekcji slajdów treści, wywołując metodę **AddEmptySlide** udostępnioną przez obiekt **SlideCollection**
- Wykonaj operacje na nowo dodanym pustym slajdzie
- Na koniec zapisz plik prezentacji przy użyciu obiektu **Presentation**

``` csharp

 PresentationEx pres = new PresentationEx();

//Zainicjuj klasę SlideCollection

SlideExCollection slds = pres.Slides;

for (int i = 0; i < pres.LayoutSlides.Count; i++)

{

	//Dodaj pusty slajd do kolekcji Slides

	slds.AddEmptySlide(pres.LayoutSlides[i]);

}

//Zapisz plik PPTX na dysku

pres.Write("EmptySlide.pptx");

``` 
## **Dostęp do slajdów w prezentacji**
Aspose.Slides for .NET udostępnia klasę Presentation, którą można używać do znajdowania i uzyskiwania dostępu do dowolnego wymaganego slajdu znajdującego się w prezentacji.

**Używanie kolekcji Slides**

Klasa **Presentation** reprezentuje plik prezentacji i udostępnia wszystkie slajdy w nim jako kolekcję **SlideCollection** (czyli kolekcję obiektów **Slide**). Wszystkie te slajdy można uzyskać z tej kolekcji **Slides** używając indeksu slajdu.

``` csharp

 //Zainicjuj obiekt Presentation, który reprezentuje plik prezentacji

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Uzyskiwanie dostępu do slajdu przy użyciu jego indeksu

SlideEx slide = pres.Slides[0];

``` 
## **Usuń slajdy**
Wiemy, że klasa Presentation w **Aspose.Slides for .NET** reprezentuje plik prezentacji. Klasa Presentation kapsułkuje **SlideCollection**, który działa jako repozytorium wszystkich slajdów będących częścią prezentacji. Programiści mogą usunąć slajd z tej kolekcji Slides na dwa sposoby:

- Za pomocą referencji do slajdu
- Za pomocą indeksu slajdu

**Używanie referencji do slajdu**

Aby usunąć slajd przy użyciu jego referencji, postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj referencję do slajdu, używając jego Id lub Index
- Usuń referencjonowany slajd z prezentacji
- Zapisz zmodyfikowany plik prezentacji

``` csharp

 //Zainicjuj obiekt Presentation, który reprezentuje plik prezentacji

PresentationEx pres = new PresentationEx("Slides Test Presentation.pptx");

//Uzyskiwanie dostępu do slajdu przy użyciu jego indeksu w kolekcji slajdów

SlideEx slide = pres.Slides[0];

//Usuwanie slajdu przy użyciu jego referencji

pres.Slides.Remove(slide);

//Zapisywanie pliku prezentacji

pres.Write("modified.pptx");

``` 
## **Zmień pozycję slajdu**
Zmiana pozycji slajdu w prezentacji jest bardzo prosta. Po prostu postępuj zgodnie z poniższymi krokami:

- Utwórz instancję klasy Presentation
- Uzyskaj referencję do slajdu, używając jego Index
- Zmień właściwość SlideNumber referencjonowanego slajdu
- Zapisz zmodyfikowany plik prezentacji

W podanym poniżej przykładzie zmieniliśmy pozycję slajdu (znajdującego się na indeksie zero pozycja 1) w prezentacji na indeks 1 (Pozycja 2).

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
//Zainicjuj klasę SlideCollection
ISlideCollection slds = pres.Slides;
for (int i = 0; i < pres.LayoutSlides.Count; i++)
{
    //Dodaj pusty slajd do kolekcji Slides
    slds.AddEmptySlide(pres.LayoutSlides[i]);
}
//Zapisz plik PPTX na dysku
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void AccessingSlidesOfPresentation()
{
//Zainicjuj obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
//Uzyskiwanie dostępu do slajdu przy użyciu jego indeksu
ISlide slide = pres.Slides[0];
}

public static void RemovingSlides()
{
//Zainicjuj obiekt Presentation, który reprezentuje plik prezentacji
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
//Uzyskiwanie dostępu do slajdu przy użyciu jego indeksu w kolekcji slajdów
ISlide slide = pres.Slides[0];
//Usuwanie slajdu przy użyciu jego referencji
pres.Slides.Remove(slide);
//Zapisywanie pliku prezentacji
pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}

public static void ChangingPositionOfSlide()
{
//Zainicjuj klasę Presentation, aby załadować źródłowy plik prezentacji
Presentation pres = new Presentation(MyDir + "Assemble Slides.pptx");
{
    //Pobierz slajd, którego pozycja ma zostać zmieniona
    ISlide sld = pres.Slides[0];
    //Ustaw nową pozycję dla slajdu
    sld.SlideNumber = 2;
    //Zapisz prezentację na dysku
    pres.Save(MyDir + "Assemble Slides.pptx", SaveFormat.Pptx);
}
}
``` 
## **Pobierz przykładowy kod**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Assemble%20Slides%20%28Aspose.Slides%29.zip)