---
title: Zarządzanie kształtami prezentacji w .NET
linktitle: Manipulacja kształtami
type: docs
weight: 40
url: /pl/net/shape-manipulations/
keywords:
- kształt PowerPoint
- kształt prezentacji
- kształt na slajdzie
- znajdź kształt
- sklonuj kształt
- usuń kształt
- ukryj kształt
- zmień kolejność kształtu
- uzyskaj ID kształtu interop
- alternatywny tekst kształtu
- formaty układu kształtu
- kształt jako SVG
- kształt do SVG
- wyrównaj kształt
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Naucz się tworzyć, edytować i optymalizować kształty w Aspose.Slides dla .NET i dostarczać wysokowydajne prezentacje PowerPoint."
---
## **Przegląd**

Ten artykuł wyjaśnia, jak pracować z kształtami w prezentacjach przy użyciu Aspose.Slides. Pokazuje, jak znaleźć kształt na slajdzie, sklonować go, usunąć, ukryć, zmienić jego kolejność, uzyskać jego identyfikator Interop oraz ustawić tekst alternatywny w celu identyfikacji i dalszego przetwarzania.

Omówiono także, jak uzyskać dostęp do formatów układu dla kształtów, renderować kształt jako SVG, wyrównać kształty na slajdzie oraz używać właściwości odbicia do poziomego i pionowego lustrzanego odbicia. Dodatkowo artykuł zawiera krótkie FAQ dotyczące łączenia kształtów, kolejności warstw i blokowania kształtów.

## **Znajdź kształt na slajdzie**
Ten temat opisuje prostą technikę ułatwiającą programistom znajdowanie konkretnego kształtu na slajdzie bez użycia jego wewnętrznego Id. Należy wiedzieć, że pliki prezentacji PowerPoint nie posiadają żadnego sposobu identyfikacji kształtów na slajdzie poza wewnętrznym unikalnym Id. Dla programistów może być trudne znalezienie kształtu przy użyciu tego wewnętrznego Id. Wszystkie kształty dodane do slajdów mają jakiś tekst alternatywny. Sugerujemy programistom użycie tekstu alternatywnego do znajdowania konkretnego kształtu. Możesz używać MS PowerPoint do określenia tekstu alternatywnego dla obiektów, które planujesz zmienić w przyszłości.

Po ustawieniu tekstu alternatywnego dowolnego kształtu możesz otworzyć tę prezentację za pomocą Aspose.Slides dla .NET i przeiterować wszystkie kształty dodane do slajdu. Podczas każdej iteracji możesz sprawdzić tekst alternatywny kształtu, a kształt z pasującym tekstem alternatywnym będzie tym, którego potrzebujesz. Aby lepiej zilustrować tę technikę, stworzyliśmy metodę [FindShape](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/findshape/#findshape_1), która umożliwia znalezienie konkretnego kształtu na slajdzie i zwraca go.

```c#
public static void Run()
{
    // Utwórz instancję klasy Presentation, która reprezentuje plik prezentacji
    using (Presentation p = new Presentation("FindingShapeInSlide.pptx"))
    {

        ISlide slide = p.Slides[0];
        // Tekst alternatywny szukanego kształtu
        IShape shape = FindShape(slide, "Shape1");
        if (shape != null)
        {
            Console.WriteLine("Shape Name: " + shape.Name);
        }
    }
}
        
// Implementacja metody znajdującej kształt na slajdzie przy użyciu jego tekstu alternatywnego
public static IShape FindShape(ISlide slide, string alttext)
{
    // Iterowanie przez wszystkie kształty na slajdzie
    for (int i = 0; i < slide.Shapes.Count; i++)
    {
        // Jeśli tekst alternatywny kształtu na slajdzie jest zgodny z wymaganym, to
        // Zwróć kształt
        if (slide.Shapes[i].AlternativeText.CompareTo(alttext) == 0)
            return slide.Shapes[i];
    }
    return null;
}
```

## **Klonowanie kształtu**
Aby sklonować kształt na slajdzie przy użyciu Aspose.Slides dla .NET:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
1. Uzyskaj odwołanie do slajdu, używając jego indeksu.
1. Uzyskaj dostęp do kolekcji kształtów slajdu źródłowego.
1. Dodaj nowy slajd do prezentacji.
1. Sklonuj kształty z kolekcji kształtów slajdu źródłowego do nowego slajdu.
1. Zapisz zmodyfikowaną prezentację jako plik PPTX.

Poniższy przykład dodaje grupowy kształt do slajdu.

```c#
// Utwórz instancję klasy Presentation
using (Presentation srcPres = new Presentation("Source Frame.pptx"))
{
	IShapeCollection sourceShapes = srcPres.Slides[0].Shapes;
	ILayoutSlide blankLayout = srcPres.Masters[0].LayoutSlides.GetByType(SlideLayoutType.Blank);
	ISlide destSlide = srcPres.Slides.AddEmptySlide(blankLayout);
	IShapeCollection destShapes = destSlide.Shapes;
	destShapes.AddClone(sourceShapes[1], 50, 150 + sourceShapes[0].Height);
	destShapes.AddClone(sourceShapes[2]);                 
	destShapes.InsertClone(0, sourceShapes[0], 50, 150);

	// Zapisz plik PPTX na dysku
	srcPres.Save("CloneShape_out.pptx", SaveFormat.Pptx);
}
```

## **Usuwanie kształtu**
Aspose.Slides dla .NET umożliwia programistom usunięcie dowolnego kształtu. Aby usunąć kształt z dowolnego slajdu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Usuń kształt.
1. Zapisz plik na dysku.

```c#
// Utwórz obiekt Presentation
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = pres.Slides[0];

// Dodaj autoshape typu prostokąt
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
    AutoShape ashp = (AutoShape)sld.Shapes[0];
    if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
    {
        sld.Shapes.Remove(ashp);
    }
}

// Zapisz prezentację na dysku
pres.Save("RemoveShape_out.pptx", SaveFormat.Pptx);
```

## **Ukrywanie kształtu**
Aspose.Slides dla .NET umożliwia programistom ukrycie dowolnego kształtu. Aby ukryć kształt na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Znajdź kształt o określonym AlternativeText.
1. Ukryj kształt.
1. Zapisz plik na dysku.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = pres.Slides[0];

// Dodaj autoshape typu prostokąt
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
String alttext = "User Defined";
int iCount = sld.Shapes.Count;
for (int i = 0; i < iCount; i++)
{
	AutoShape ashp = (AutoShape)sld.Shapes[i];
	if (String.Compare(ashp.AlternativeText, alttext, StringComparison.Ordinal) == 0)
	{
		ashp.Hidden = true;
	}
}

// Zapisz prezentację na dysku
pres.Save("Hiding_Shapes_out.pptx", SaveFormat.Pptx);
```

## **Zmiana kolejności kształtu**
Aspose.Slides dla .NET umożliwia programistom zmianę kolejności kształtów. Zmiana kolejności określa, który kształt znajduje się z przodu, a który z tyłu. Aby zmienić kolejność kształtów na dowolnym slajdzie, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj kształt.
1. Dodaj trochę tekstu w ramce tekstowej kształtu.
1. Dodaj kolejny kształt z tymi samymi współrzędnymi.
1. Zmień kolejność kształtów.
1. Zapisz plik na dysku.

```c#
Presentation presentation1 = new Presentation("HelloWorld.pptx");
ISlide slide = presentation1.Slides[0];
IAutoShape shp3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 365, 400, 150);
shp3.FillFormat.FillType = FillType.NoFill;
shp3.AddTextFrame(" ");

ITextFrame txtFrame = shp3.TextFrame;
IParagraph para = txtFrame.Paragraphs[0];
IPortion portion = para.Portions[0];
portion.Text="Watermark Text Watermark Text Watermark Text";
shp3 = slide.Shapes.AddAutoShape(ShapeType.Triangle, 200, 365, 400, 150);
slide.Shapes.Reorder(2, shp3);
presentation1.Save( "Reshape_out.pptx", SaveFormat.Pptx);
```

## **Uzyskanie Interop Shape ID**
Aspose.Slides dla .NET umożliwia programistom uzyskanie unikalnego identyfikatora kształtu w zakresie slajdu, w przeciwieństwie do właściwości UniqueId, która pozwala uzyskać unikalny identyfikator w zakresie prezentacji. W interfejsach IShape oraz klasie Shape dodano właściwość OfficeInteropShapeId. Wartość zwracana przez właściwość OfficeInteropShapeId odpowiada wartości Id obiektu Microsoft.Office.Interop.PowerPoint.Shape. Poniżej przedstawiono przykładowy kod.

```c#
public static void Run()
{
	using (Presentation presentation = new Presentation("Presentation.pptx"))
	{
		// Pobieranie unikalnego identyfikatora kształtu w zakresie slajdu
		long officeInteropShapeId = presentation.Slides[0].Shapes[0].OfficeInteropShapeId;
	}
}
```

## **Ustawianie tekstu alternatywnego dla kształtu**
Aspose.Slides dla .NET umożliwia programistom ustawienie AlternateText dowolnego kształtu. Kształty w prezentacji mogą być rozróżniane na podstawie właściwości AlternativeText lub nazwy kształtu. Właściwość AlternativeText może być odczytywana lub ustawiana zarówno przy użyciu Aspose.Slides, jak i Microsoft PowerPoint. Korzystając z tej właściwości, możesz oznaczyć kształt i wykonać różne operacje, takie jak usuwanie kształtu, ukrywanie kształtu lub zmiana kolejności kształtów na slajdzie.

Aby ustawić AlternateText kształtu, postępuj zgodnie z poniższymi krokami:

1. Utwórz instancję klasy `Presentation`.
1. Uzyskaj dostęp do pierwszego slajdu.
1. Dodaj dowolny kształt do slajdu.
1. Wykonaj pewne operacje na nowo dodanym kształcie.
1. Przeglądaj kształty, aby znaleźć określony kształt.
1. Ustaw AlternativeText.
1. Zapisz plik na dysku.

```c#
// Utwórz instancję klasy Presentation, która reprezentuje plik PPTX
Presentation pres = new Presentation();

// Pobierz pierwszy slajd
ISlide sld = pres.Slides[0];

// Dodaj autoshape typu prostokąt
IShape shp1 = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 40, 150, 50);
IShape shp2 = sld.Shapes.AddAutoShape(ShapeType.Moon, 160, 40, 150, 50);
shp2.FillFormat.FillType = FillType.Solid;
shp2.FillFormat.SolidFillColor.Color = Color.Gray;

for (int i = 0; i < sld.Shapes.Count; i++)
{
    var shape = sld.Shapes[i] as AutoShape;
    if (shape != null)
    {
        AutoShape ashp = shape;
        ashp.AlternativeText = "User Defined";
    }
}

// Zapisz prezentację na dysku
pres.Save("Set_AlternativeText_out.pptx", SaveFormat.Pptx);
```

## **Dostęp do formatów układu dla kształtu**
Aspose.Slides dla .NET udostępnia prosty interfejs API do uzyskania dostępu do formatów układu dla kształtu. Ten artykuł pokazuje, jak można uzyskać dostęp do formatów układu.

Poniżej przedstawiono przykładowy kod.

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
	foreach (ILayoutSlide layoutSlide in pres.LayoutSlides)
	{
		IFillFormat[] fillFormats = layoutSlide.Shapes.Select(shape => shape.FillFormat).ToArray();
		ILineFormat[] lineFormats = layoutSlide.Shapes.Select(shape => shape.LineFormat).ToArray();
	}
}
```

## **Renderowanie kształtu jako SVG**
Teraz Aspose.Slides dla .NET obsługuje renderowanie kształtu jako SVG. Metoda WriteAsSvg (oraz jej przeciążenie) została dodana do klasy Shape oraz interfejsu IShape. Metoda ta umożliwia zapisanie zawartości kształtu jako pliku SVG. Poniższy fragment kodu pokazuje, jak wyeksportować kształt ze slajdu do pliku SVG.

```c#
public static void Run()
{
	string outSvgFileName = "SingleShape.svg";
	using (Presentation pres = new Presentation("TestExportShapeToSvg.pptx"))
	{
		using (Stream stream = new FileStream(outSvgFileName, FileMode.Create, FileAccess.Write))
		{
			pres.Slides[0].Shapes[0].WriteAsSvg(stream);
		}
	}
}
```

## **Wyrównywanie kształtu**

Poprzez przeciążoną metodę [SlidesUtil.AlignShape()](https://reference.aspose.com/slides/pl/net/aspose.slides.util/slideutil/methods/alignshapes/index) możesz 

* wyrównać kształty względem marginesów slajdu. Zobacz Przykład 1. 
* wyrównać kształty względem siebie nawzajem. Zobacz Przykład 2. 

Wyliczenie [ShapesAlignmentType](https://reference.aspose.com/slides/pl/net/aspose.slides/shapesalignmenttype) definiuje dostępne opcje wyrównywania.

**Example 1**

Ten kod C# pokazuje, jak wyrównać kształty o indeksach 1, 2 i 4 wzdłuż górnej krawędzi slajdu:
Poniższy kod wyrównuje kształty o indeksach 1, 2 i 4 wzdłuż górnej krawędzi slajdu. 

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
     ISlide slide = pres.Slides[0];
     IShape shape1 = slide.Shapes[1];
     IShape shape2 = slide.Shapes[2];
     IShape shape3 = slide.Shapes[4];
     SlideUtil.AlignShapes(ShapesAlignmentType.AlignTop, true, pres.Slides[0], new int[]
     {
          slide.Shapes.IndexOf(shape1),
          slide.Shapes.IndexOf(shape2),
          slide.Shapes.IndexOf(shape3)
     });
}
```

**Example 2**

Ten kod C# pokazuje, jak wyrównać całą kolekcję kształtów względem najniższego kształtu w kolekcji:

``` csharp
using (Presentation pres = new Presentation("example.pptx"))
{
    SlideUtil.AlignShapes(ShapesAlignmentType.AlignBottom, false, pres.Slides[0].Shapes);
}
```

## **Właściwości odbicia**

W Aspose.Slides klasa [ShapeFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/shapeframe/) zapewnia kontrolę nad poziomym i pionowym lustrzanym odbiciem kształtów za pomocą właściwości `FlipH` i `FlipV`. Obie właściwości są typu [NullableBool](https://reference.aspose.com/slides/pl/net/aspose.slides/nullablebool/) i mogą przyjmować wartości `True` (odbij), `False` (brak odbicia) lub `NotDefined` (domyślne zachowanie). Wartości te są dostępne z właściwości [Frame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/frame/) kształtu. 

Aby zmodyfikować ustawienia odbicia, tworzona jest nowa instancja [ShapeFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/shapeframe/) z aktualną pozycją i rozmiarem kształtu, żądanymi wartościami `FlipH` i `FlipV` oraz kątem obrotu. Przypisanie tej instancji do [Frame](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/frame/) kształtu i zapis prezentacji powoduje zastosowanie transformacji lustrzanych i zapisuje je w pliku wyjściowym.

Załóżmy, że mamy plik sample.pptx, w którym pierwszy slajd zawiera pojedynczy kształt z domyślnymi ustawieniami odbicia, jak pokazano poniżej.

![Kształt do odbicia](shape_to_be_flipped.png)

Poniższy przykład kodu pobiera bieżące właściwości odbicia kształtu i odbija go zarówno poziomo, jak i pionowo.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    IShape shape = presentation.Slides[0].Shapes[0];

    // Pobierz właściwość odbicia poziomego kształtu.
    NullableBool horizontalFlip = shape.Frame.FlipH;
    Console.WriteLine($"Horizontal flip: {horizontalFlip}");

    // Pobierz właściwość odbicia pionowego kształtu.
    NullableBool verticalFlip = shape.Frame.FlipV;
    Console.WriteLine($"Vertical flip: {verticalFlip}");

    float x = shape.Frame.X;
    float y = shape.Frame.Y;
    float width = shape.Frame.Width;
    float height = shape.Frame.Height;
    NullableBool flipH = NullableBool.True; // Odbij poziomo.
    NullableBool flipV = NullableBool.True; // Odbij pionowo.
    float rotation = shape.Frame.Rotation;

    shape.Frame = new ShapeFrame(x, y, width, height, flipH, flipV, rotation);

    presentation.Save("output.pptx", SaveFormat.Pptx);
}
```

Rezultat:

![Odbity kształt](flipped_shape.png)

## **FAQ**

**Czy mogę łączyć kształty (union/intersect/subtract) na slajdzie tak jak w edytorze desktopowym?**

Nie ma wbudowanego API operacji Boolean. Można przybliżyć to, samodzielnie budując pożądany kontur – np. obliczając wynikową geometrię (przy użyciu [GeometryPath](https://reference.aspose.com/slides/pl/net/aspose.slides/geometrypath/)) i tworząc nowy kształt z tym konturem, opcjonalnie usuwając oryginały.

**Jak mogę kontrolować kolejność warstw (z‑order), aby kształt zawsze pozostawał „na wierzchu”?**

Zmieniaj kolejność wstawiania/przenoszenia w kolekcji [shapes](https://reference.aspose.com/slides/pl/net/aspose.slides/baseslide/shapes/) slajdu. Aby uzyskać przewidywalne wyniki, sfinalizuj kolejność po wszystkich pozostałych modyfikacjach slajdu.

**Czy mogę „zablokować” kształt, aby użytkownicy nie mogli go edytować w PowerPoint?**

Tak. Ustaw flagi ochrony na poziomie kształtu (np. blokada wyboru, ruchu, zmiany rozmiaru, edycji tekstu). W razie potrzeby zastosuj podobne ograniczenia w szablonie lub układzie. Należy pamiętać, że jest to ochrona na poziomie interfejsu użytkownika, a nie funkcja zabezpieczająca; dla silniejszej ochrony połącz ją z ograniczeniami na poziomie pliku, takimi jak rekomendacje tylko do odczytu lub hasła.