---
title: Optymalizacja zarządzania obrazami w prezentacjach w .NET
linktitle: Zarządzanie obrazami
type: docs
weight: 10
url: /pl/net/image/
keywords:
  - dodaj obraz
  - dodaj zdjęcie
  - dodaj bitmapę
  - zastąp obraz
  - zastąp zdjęcie
  - z internetu
  - tło
  - dodaj PNG
  - dodaj JPG
  - dodaj SVG
  - dodaj EMF
  - dodaj WMF
  - dodaj TIFF
  - PowerPoint
  - OpenDocument
  - prezentacja
  - .NET
  - C#
  - Aspose.Slides
description: "Usprawnij zarządzanie obrazami w PowerPoint i OpenDocument przy użyciu Aspose.Slides dla .NET, optymalizując wydajność i automatyzując przepływ pracy."
---
## **Wprowadzenie**

Obrazy sprawiają, że prezentacje są bardziej atrakcyjne i interesujące. W programie Microsoft PowerPoint można wstawiać obrazy z pliku, Internetu lub innych lokalizacji na slajdy. Podobnie Aspose.Slides umożliwia dodawanie obrazów do slajdów w prezentacjach przy użyciu różnych metod.

{{% alert  title="Wskazówka" color="primary" %}} 

Aspose udostępnia darmowe konwertery—[JPEG to PowerPoint](https://products.aspose.app/slides/pl/import/jpg-to-ppt) i [PNG to PowerPoint](https://products.aspose.app/slides/pl/import/png-to-ppt)—pozwalające szybko tworzyć prezentacje z obrazów. 

{{% /alert %}} 

{{% alert title="Informacja" color="info" %}}

Jeśli chcesz dodać obraz jako obiekt ramki — szczególnie jeśli zamierzasz używać standardowych opcji formatowania, aby zmienić jego rozmiar, dodać efekty itp. — zobacz [Picture Frame](https://docs.aspose.com/slides/pl/net/picture-frame/). 

{{% /alert %}} 

{{% alert title="Uwaga" color="warning" %}}

Możesz manipulować operacjami wejścia/wyjścia związanymi z obrazami i prezentacjami PowerPoint, aby konwertować obraz z jednego formatu na inny. Zobacz te strony: konwertuj [obraz do JPG](https://products.aspose.com/slides/pl/net/conversion/image-to-jpg/); konwertuj [JPG do obrazu](https://products.aspose.com/slides/pl/net/conversion/jpg-to-image/); konwertuj [JPG do PNG](https://products.aspose.com/slides/pl/net/conversion/jpg-to-png/), konwertuj [PNG do JPG](https://products.aspose.com/slides/pl/net/conversion/png-to-jpg/); konwertuj [PNG do SVG](https://products.aspose.com/slides/pl/net/conversion/png-to-svg/), konwertuj [SVG do PNG](https://products.aspose.com/slides/pl/net/conversion/svg-to-png/).

{{% /alert %}}

Aspose.Slides obsługuje operacje na obrazach w tych popularnych formatach: JPEG, PNG, BMP, GIF i innych. 

## **Dodawanie obrazów przechowywanych lokalnie do slajdów**

Możesz dodać jeden lub kilka obrazów z komputera na slajd w prezentacji. Ten przykładowy kod w C# pokazuje, jak dodać obraz do slajdu:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów z sieci do slajdów**

Jeśli obraz, który chcesz dodać do slajdu, nie jest dostępny na komputerze, możesz dodać go bezpośrednio z sieci. 

Ten przykładowy kod pokazuje, jak dodać obraz z sieci do slajdu w C#:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];

    byte[] imageData;
    using (WebClient webClient = new WebClient()) 
    {
        imageData = webClient.DownloadData(new Uri("[REPLACE WITH URL]"));
    }
    
    IPPImage image = pres.Images.AddImage(imageData);
    slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów do masterów slajdów**

Master slajdu to górny slajd, który przechowuje i kontroluje informacje (motyw, układ itp.) dotyczące wszystkich znajdujących się pod nim slajdów. Dlatego dodając obraz do mastera slajdu, obraz ten pojawia się na każdym slajdzie pod tym masterem. 

Ten przykładowy kod w C# pokazuje, jak dodać obraz do mastera slajdu:

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides[0];
    IMasterSlide masterSlide = slide.LayoutSlide.MasterSlide;
    
    IPPImage image = pres.Images.AddImage(File.ReadAllBytes("image.png"));
    masterSlide.Shapes.AddPictureFrame(ShapeType.Rectangle, 10, 10, 100, 100, image);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Dodawanie obrazów jako tła slajdów**

Możesz zdecydować się na użycie obrazu jako tła dla konkretnego slajdu lub kilku slajdów. W takim przypadku należy zapoznać się z *[Setting Images as Backgrounds for Slides](https://docs.aspose.com/slides/pl/net/presentation-background/#setting-images-as-background-for-slides)*.

## **Dodawanie SVG do prezentacji**
Możesz dodać lub wstawić dowolny obraz do prezentacji, korzystając z metody [AddPictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/methods/addpictureframe) należącej do interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection).

Aby utworzyć obiekt obrazu na podstawie obrazu SVG, możesz zrobić to w następujący sposób:

1. Utwórz obiekt SvgImage, aby wstawić go do ImageShapeCollection
2. Utwórz obiekt PPImage z ISvgImage
3. Utwórz obiekt PictureFrame przy użyciu interfejsu IPPImage

Ten przykładowy kod pokazuje, jak wdrożyć powyższe kroki, aby dodać obraz SVG do prezentacji:
``` csharp 
// Ścieżka do katalogu dokumentów
string dataDir = @"D:\Documents\";

// Nazwa pliku źródłowego SVG
string svgFileName = dataDir + "sample.svg";

// Nazwa pliku wyjściowej prezentacji
string outPptxPath = dataDir + "presentation.pptx";

// Utwórz nową prezentację
using (var p = new Presentation())
{
    // Odczytaj zawartość pliku SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Utwórz obiekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Utwórz obiekt PPImage
    IPPImage ppImage = p.Images.AddImage(svgImage);

    // Tworzy nową ramkę obrazu 
    p.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 200, 100, ppImage.Width, ppImage.Height, ppImage);

    // Zapisz prezentację w formacie PPTX
    p.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Konwersja SVG na zestaw kształtów**
Konwersja SVG do zestawu kształtów w Aspose.Slides jest podobna do funkcjonalności PowerPoint używanej do pracy z obrazami SVG:

![Menu podręczne PowerPoint](img_01_01.png)

Funkcjonalność jest udostępniana przez jedną z przeciążeń metody [AddGroupShape](https://reference.aspose.com/slides/pl/net/aspose.slides.ishapecollection/addgroupshape/methods/1) interfejsu [IShapeCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection), które przyjmuje obiekt [ISvgImage](https://reference.aspose.com/slides/pl/net/aspose.slides/isvgimage) jako pierwszy argument.

Ten przykładowy kod pokazuje, jak użyć opisanej metody, aby przekonwertować plik SVG na zestaw kształtów:

``` csharp 
// Ścieżka do katalogu dokumentów
string dataDir = @"D:\Documents\";

// Nazwa pliku źródłowego SVG
string svgFileName = dataDir + "sample.svg";

// Nazwa pliku wyjściowej prezentacji
string outPptxPath = dataDir + "presentation.pptx";

// Utwórz nową prezentację
using (IPresentation presentation = new Presentation())
{
    // Odczytaj zawartość pliku SVG
    string svgContent = File.ReadAllText(svgFileName);

    // Utwórz obiekt SvgImage
    ISvgImage svgImage = new SvgImage(svgContent);

    // Pobierz rozmiar slajdu
    SizeF slideSize = presentation.SlideSize.Size;

    // Konwertuj obraz SVG na grupę kształtów skalując go do rozmiaru slajdu
    presentation.Slides[0].Shapes.AddGroupShape(svgImage, 0f, 0f, slideSize.Width, slideSize.Height);

    // Zapisz prezentację w formacie PPTX
    presentation.Save(outPptxPath, SaveFormat.Pptx);
}
```

## **Dodawanie obrazów jako EMF do slajdów**
Aspose.Slides for .NET umożliwia generowanie obrazów EMF z arkuszy Excel i dodawanie tych obrazów jako EMF na slajdach przy pomocy Aspose.Cells. 

Ten przykładowy kod pokazuje, jak wykonać opisane zadanie:

``` csharp 
using (Workbook book = new Workbook(dataDir + "chart.xlsx"))
{
    Worksheet sheet = book.Worksheets[0];
    ImageOrPrintOptions options = new ImageOrPrintOptions();
    options.HorizontalResolution = 200;
    options.VerticalResolution = 200;
    options.ImageFormat = System.Drawing.Imaging.ImageFormat.Emf;

    // Zapisz skoroszyt do strumienia
    SheetRender sr = new SheetRender(sheet, options);
    using (Presentation pres = new Presentation())
    {
        pres.Slides.RemoveAt(0);

        String EmfSheetName = "";
        for (int j = 0; j < sr.PageCount; j++)
        {
            EmfSheetName = dataDir + "test" + sheet.Name + " Page" + (j + 1) + ".out.emf";
            sr.ToImage(j, EmfSheetName);

            var bytes = File.ReadAllBytes(EmfSheetName);
            var emfImage = pres.Images.AddImage(bytes);
            ISlide slide = pres.Slides.AddEmptySlide(pres.LayoutSlides.GetByType(SlideLayoutType.Blank));
            slide.Shapes.AddPictureFrame(ShapeType.Rectangle, 0, 0, pres.SlideSize.Size.Width, pres.SlideSize.Size.Height, emfImage);
        }

        pres.Save(dataDir + "Saved.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
    }
}
```

## **Zastępowanie obrazów w kolekcji obrazów**

Aspose.Slides pozwala na zastępowanie obrazów przechowywanych w kolekcji obrazów prezentacji (w tym tych używanych przez kształty slajdów). W tej sekcji przedstawiono kilka podejść do aktualizacji obrazów w kolekcji. API udostępnia proste metody zastępowania obrazu przy użyciu surowych danych bajtowych, instancji [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) lub innego obrazu, który już istnieje w kolekcji.

Wykonaj poniższe kroki:

1. Załaduj plik prezentacji zawierający obrazy przy użyciu klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Załaduj nowy obraz z pliku do tablicy bajtów.
3. Zastąp docelowy obraz nowym obrazem przy użyciu tablicy bajtów.
4. W drugim podejściu załaduj obraz do obiektu [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/) i zastąp docelowy obraz tym obiektem.
5. W trzecim podejściu zastąp docelowy obraz obrazem, który już istnieje w kolekcji obrazów prezentacji.
6. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```cs
// Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji.
using Presentation presentation = new Presentation("sample.pptx");

// Pierwszy sposób.
byte[] imageData = File.ReadAllBytes("image0.jpeg");
IPPImage oldImage = presentation.Images[0];
oldImage.ReplaceImage(imageData);

// Drugi sposób.
using IImage newImage = Images.FromFile("image1.png");
oldImage = presentation.Images[1];
oldImage.ReplaceImage(newImage);

// Trzeci sposób.
oldImage = presentation.Images[2];
oldImage.ReplaceImage(presentation.Images[3]);

// Zapisz prezentację do pliku.
presentation.Save("output.pptx", SaveFormat.Pptx);
```

{{% alert title="Informacja" color="info" %}}

Korzystając z darmowego konwertera Aspose FREE [Text to GIF](https://products.aspose.app/slides/pl/text-to-gif), możesz łatwo animować teksty, tworzyć GIF‑y z tekstów itp. 

{{% /alert %}}

## **FAQ**

**Czy oryginalna rozdzielczość obrazu pozostaje niezmieniona po wstawieniu?**

Tak. Piksele źródłowe są zachowane, ale ostateczny wygląd zależy od tego, jak [picture](/slides/pl/net/picture-frame/) jest skalowany na slajdzie i od ewentualnej kompresji przy zapisie.

**Jaki jest najlepszy sposób, aby jednocześnie zastąpić to samo logo na dziesiątkach slajdów?**

Umieść logo w masterze slajdu lub układzie i wymień je w kolekcji obrazów prezentacji — zmiany rozpropagują się do wszystkich elementów korzystających z tego zasobu.

**Czy wstawiony SVG można przekonwertować na edytowalne kształty?**

Tak. SVG można skonwertować do grupy kształtów, po czym poszczególne części stają się edytowalne przy użyciu standardowych właściwości kształtów.

**Jak ustawić obraz jako tło dla wielu slajdów jednocześnie?**

[Przypisz obraz jako tło](/slides/pl/net/presentation-background/) na masterze slajdu lub odpowiednim układzie — wszystkie slajdy korzystające z tego mastera/układu odziedziczą tło.

**Jak zapobiec „puchnięciu” rozmiaru prezentacji z powodu licznych obrazów?**

Używaj jednego zasobu obrazu zamiast duplikatów, wybieraj umiarkowane rozdzielczości, stosuj kompresję przy zapisie i, w miarę możliwości, umieszczaj powtarzające się grafiki w masterze.

