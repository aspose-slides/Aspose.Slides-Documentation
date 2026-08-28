---
title: Zarządzanie akapitami tekstu PowerPoint w .NET
linktitle: Zarządzaj akapitem
type: docs
weight: 40
url: /pl/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- dodaj tekst
- dodaj akapit
- zarządzaj tekstem
- zarządzaj akapitem
- zarządzaj wypunktowaniem
- wcięcie akapitu
- wcięcie wiszące
- punktowanie akapitu
- lista numerowana
- lista punktowana
- właściwości akapitu
- importuj HTML
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksportuj akapit
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) reprezentuje pojemnik tekstu w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) reprezentuje fragment tekstu w akapicie. Każdy fragment może mieć własny tekst i formatowanie znaków.

Akapit może więc zawierać tekst o różnych czcionkach, kolorach, rozmiarach i innych formatowaniach, używając wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

### **Tworzenie akapitów z wieloma fragmentami**

Poniższe kroki tworzą ramkę tekstową z trzema akapitami, z których każdy zawiera trzy fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu przez jego indeks.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu.
5. Użyj domyślnego akapitu i dodaj dwa kolejne obiekty [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) do ramki tekstowej.
6. Dodaj wystarczającą liczbę obiektów [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) dla każdego akapitu, aby zawierał trzy fragmenty. Domyślny akapit już zawiera jeden pusty fragment.
7. Ustaw tekst każdego fragmentu.
8. Zastosuj formatowanie znakowe za pomocą [IPortion.PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/portionformat/).
9. Zapisz zmodyfikowaną prezentację.

Ten przykład w C# implementuje kroki:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);
var textFrame = shape.TextFrame;

var firstParagraph = textFrame.Paragraphs[0];
firstParagraph.Portions.Add(new Portion());
firstParagraph.Portions.Add(new Portion());

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
secondParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph();
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
thirdParagraph.Portions.Add(new Portion());
textFrame.Paragraphs.Add(thirdParagraph);

var paragraphCount = textFrame.Paragraphs.Count;
for (var paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    var paragragaph = textFrame.Paragraphs[paragraphIndex];
    var portionCount = paragragaph.Portions.Count;
    for (var portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        var portion = paragragaph.Portions[portionIndex];
        portion.Text = $"Portion {paragraphIndex + 1}.{portionIndex + 1}";

        if (portionIndex == 0)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
            portion.PortionFormat.FontBold = NullableBool.True;
            portion.PortionFormat.FontHeight = 15;
        }
        else if (portionIndex == 1)
        {
            portion.PortionFormat.FillFormat.FillType = FillType.Solid;
            portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
            portion.PortionFormat.FontItalic = NullableBool.True;
            portion.PortionFormat.FontHeight = 18;
        }
    }
}

presentation.Save("paragraphs_with_portions.pptx", SaveFormat.Pptx);
```

## **Tworzenie list punktowanych i numerowanych**

### **Utworzenie listy punktowanej lub numerowanej**

Punkty i numeracja ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy definiowane są za pomocą [IBulletFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/).

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu przez jego indeks.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu.
5. Usuń domyślny akapit z ramki tekstowej.
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) dla symbolu punktu.
7. Ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/) i określ znak punktu.
8. Ustaw tekst akapitu, wcięcie, kolor punktu i wysokość punktu.
9. Dodaj akapit do ramki tekstowej.
10. Utwórz drugi akapit i ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/).
11. Skonfiguruj styl numerowanego punktu i dodaj akapit do ramki tekstowej.
12. Zapisz prezentację.

Ten przykład w C# tworzy punkt symboliczny i punkt numerowany:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var symbolParagraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
symbolParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
symbolParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
symbolParagraph.ParagraphFormat.Indent = 25;
symbolParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
symbolParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
symbolParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
symbolParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(symbolParagraph);

var numberedParagraph = new Paragraph { Text = "This is a numbered item" };
numberedParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
numberedParagraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
numberedParagraph.ParagraphFormat.Indent = 25;
numberedParagraph.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
numberedParagraph.ParagraphFormat.Bullet.Color.Color = Color.Black;
numberedParagraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
numberedParagraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(numberedParagraph);

presentation.Save("bulleted_and_numbered_list.pptx", SaveFormat.Pptx);
```

### **Użycie punktów obrazkowych**

Punkty obrazkowe pozwalają użyć własnego obrazu zamiast symbolu lub liczby.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu przez jego indeks.
3. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i uzyskaj dostęp do jego [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/).
4. Usuń domyślny akapit z ramki tekstowej.
5. Wczytaj obraz punktu i dodaj go do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).
6. Utwórz [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) i ustaw jego tekst.
7. Ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/).
8. Przypisz obraz przez [IBulletFormat.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/picture/) i ustaw wysokość punktu.
9. Dodaj akapit do ramki tekstowej.
10. Zapisz zmodyfikowaną prezentację.

Ten przykład w C# tworzy punkt obrazkowy:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

using var bulletImage = Images.FromFile("bullets.png");
var presentationImage = presentation.Images.AddImage(bulletImage);

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph = new Paragraph { Text = "Welcome to Aspose.Slides" };
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = presentationImage;
paragraph.ParagraphFormat.Bullet.Height = 100;
textFrame.Paragraphs.Add(paragraph);

presentation.Save("picture_bullet.pptx", SaveFormat.Pptx);
presentation.Save("picture_bullet.ppt", SaveFormat.Ppt);
```

### **Utworzenie listy wielopoziomowej**

Ustaw [IParagraphFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/depth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i usuń domyślny akapit z jego ramki tekstowej.
3. Utwórz cztery akapity i skonfiguruj ich symbole punktów.
4. Ustaw ich wartości [IParagraphFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/depth/) na `0`, `1`, `2` i `3`.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w C# tworzy czteropoziomową listę punktowaną:

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Content" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
firstParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.Depth = 0;

var secondParagraph = new Paragraph { Text = "Second level" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
secondParagraph.ParagraphFormat.Bullet.Char = '-';
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.Depth = 1;

var thirdParagraph = new Paragraph { Text = "Third level" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
thirdParagraph.ParagraphFormat.Bullet.Char = Convert.ToChar(0x2022);
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.Depth = 2;

var fourthParagraph = new Paragraph { Text = "Fourth level" };
fourthParagraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
fourthParagraph.ParagraphFormat.Bullet.Char = '-';
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
fourthParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
fourthParagraph.ParagraphFormat.Depth = 3;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);
textFrame.Paragraphs.Add(fourthParagraph);

presentation.Save("multilevel_list.pptx", SaveFormat.Pptx);
```

### **Rozpoczęcie elementów listy numerowanej od niestandardowych wartości**

Użyj [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstartwith/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

1. Utwórz [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
2. Usuń domyślny akapit z ramki tekstowej kształtu.
3. Utwórz trzy numerowane akapity.
4. Ustaw [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstartwith/) na `2`, `3` i `7` dla kolejnych akapitów.
5. Dodaj akapity do ramki tekstowej i zapisz prezentację.

Ten przykład w C# przypisuje niestandardowy numer startowy każdemu akapitowi:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "Start at 2" };
firstParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
firstParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
textFrame.Paragraphs.Add(firstParagraph);

var secondParagraph = new Paragraph { Text = "Start at 3" };
secondParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
secondParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 3;
textFrame.Paragraphs.Add(secondParagraph);

var thirdParagraph = new Paragraph { Text = "Start at 7" };
thirdParagraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
thirdParagraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("custom_numbered_list.pptx", SaveFormat.Pptx);
```

## **Kontrola układu akapitu i właściwości końcowych**

### **Ustawienie wcięcia pierwszej linii**

Użyj właściwości [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) aby kontrolować wcięcie pierwszej linii akapitu. Właściwość ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) gdy potrzebujesz przesunąć tylko pierwszą linię.

Przykład poniżej tworzy kilka akapitów i stosuje różne wartości [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw różne wartości [Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) dla nich.
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie akapitu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "No first-line indent. Wrapped lines start at the same position as the first line." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 20;
firstParagraph.ParagraphFormat.Indent = 0;

var secondParagraph = new Paragraph { Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 20;
secondParagraph.ParagraphFormat.Indent = 20;

var thirdParagraph = new Paragraph { Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see." };
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
thirdParagraph.ParagraphFormat.MarginLeft = 20;
thirdParagraph.ParagraphFormat.Indent = 40;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);
textFrame.Paragraphs.Add(thirdParagraph);

presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
```

Wynik:

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

### **Ustawienie wcięcia wiszącego**

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt za pomocą właściwości [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/). Ustaw `Indent` na wartość ujemną, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) definiuje lewą pozycję ciała akapitu, a [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) definiuje pozycję pierwszej linii względem tego marginesu. Aby utworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

Takie formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których zawinięte linie muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątny [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) aby uzyskać efekt wcięcia wiszącego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

Ten kod pokazuje, jak ustawić wcięcie wiszące dla akapitu:

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
shape.FillFormat.FillType = FillType.NoFill;
shape.LineFormat.FillFormat.FillType = FillType.Solid;
shape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph { Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body." };
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
firstParagraph.ParagraphFormat.MarginLeft = 40;
firstParagraph.ParagraphFormat.Indent = -20;

var secondParagraph = new Paragraph { Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
secondParagraph.ParagraphFormat.MarginLeft = 60;
secondParagraph.ParagraphFormat.Indent = -30;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
```

Wynik:

![Wcięcie wiszące akapitów](hanging_indent.png)

### **Ustawienie właściwości końcowych akapitu**

Właściwość [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/endparagraphportionformat/) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład przypisuje rozmiar czcionki i czcionkę łacińską do znaku końcowego drugiego akapitu:

1. Wczytaj [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) i uzyskaj dostęp do slajdu.
2. Dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) i wyczyść jego domyślny akapit.
3. Utwórz dwa akapity i dodaj do nich fragmenty tekstu.
4. Utwórz [PortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/portionformat/) dla znaku końcowego drugiego akapitu.
5. Ustaw [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/fontheight/) i [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/latinfont/).
6. Przypisz format do [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/endparagraphportionformat/) i zapisz prezentację.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Test.pptx");
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);
var textFrame = shape.TextFrame;
textFrame.Paragraphs.Clear();

var firstParagraph = new Paragraph();
firstParagraph.Portions.Add(new Portion("Sample text"));

var secondParagraph = new Paragraph();
secondParagraph.Portions.Add(new Portion("Sample text 2"));

var endParagraphFormat = new PortionFormat();
endParagraphFormat.FontHeight = 48;
endParagraphFormat.LatinFont = new FontData("Times New Roman");
secondParagraph.EndParagraphPortionFormat = endParagraphFormat;

textFrame.Paragraphs.Add(firstParagraph);
textFrame.Paragraphs.Add(secondParagraph);

presentation.Save("end_paragraph_format.pptx", SaveFormat.Pptx);
```

## **Import i Eksport Treści Akapitów**

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphcollection/addfromhtml/) aby skonwertować znacznik HTML na akapity i fragmenty w ramce tekstowej.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj dostęp do slajdu i dodaj [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu i wyczyść jego domyślny akapit.
4. Odczytaj plik źródłowy HTML.
5. Przekaż łańcuch HTML do [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphcollection/addfromhtml/).
6. Zapisz zmodyfikowaną prezentację.

Ten przykład w C# importuje HTML do ramki tekstowej:

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shapeWidth = presentation.SlideSize.Size.Width - 20;
var shapeHeight = presentation.SlideSize.Size.Height - 20;
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, shapeWidth, shapeHeight);
shape.FillFormat.FillType = FillType.NoFill;
shape.TextFrame.Paragraphs.Clear();

using var reader = new StreamReader("file.html");
var html = reader.ReadToEnd();
shape.TextFrame.Paragraphs.AddFromHtml(html);

presentation.Save("html_text.pptx", SaveFormat.Pptx);
```

### **Eksport tekstu akapitu do HTML**

Użyj [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphcollection/exporttohtml/) aby wyeksportować wybrany zakres akapitów jako HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i wczytaj żądaną prezentację.
2. Uzyskaj dostęp do slajdu i znajdź [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/), który zawiera tekst.
3. Uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) kształtu.
4. Wywołaj [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphcollection/exporttohtml/) z indeksem początkowego akapitu i liczbą akapitów do wyeksportowania.
5. Zapisz zwrócony łańcuch HTML do pliku.

Ten przykład w C# eksportuje wszystkie akapity z pierwszego kształtu tekstowego:

```csharp
using System;
using System.IO;
using System.Text;
using Aspose.Slides;

using var presentation = new Presentation("ExportingHTMLText.pptx");
var shape = presentation.Slides[0].Shapes[0];

if (shape is IAutoShape textShape && textShape.TextFrame != null)
{
    var paragraphs = textShape.TextFrame.Paragraphs;
    var html = paragraphs.ExportToHtml(0, paragraphs.Count, null);
    using var writer = new StreamWriter("paragraphs.html", false, Encoding.UTF8);
    writer.Write(html);
}
else
{
    Console.WriteLine("The first shape is not a text shape.");
}
```

### **Renderowanie akapitu jako obrazu**

[IParagraph.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getimage/) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia za pomocą [IImage.Save](https://reference.aspose.com/slides/pl/net/aspose.slides/iimage/save/). Nie musisz renderować zawierającego kształtu ani ręcznie przycinać bitmapy.

[IParagraph.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getimage/) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji nadrzędnej, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, w którym pierwszy kształt to pole tekstowe zawierające trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład renderuje drugi akapit w zwykłym kształcie tekstowym w domyślnej skali i zapisuje zwrócony obraz w formacie PNG. Deklaracja `using` zapewnia prawidłowe zwolnienie obrazu.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

var shape = presentation.Slides[0].Shapes[0];
if (shape is IAutoShape textShape && 
    textShape.TextFrame != null && 
    textShape.TextFrame.Paragraphs.Count > 1)
{
    var paragraph = textShape.TextFrame.Paragraphs[1];
    using var paragraphImage = paragraph.GetImage();

    if (paragraphImage != null)
    {
        paragraphImage.Save("paragraph.png", ImageFormat.Png);
    }
    else
    {
        Console.WriteLine("The paragraph could not be rendered.");
    }
}
else
{
    Console.WriteLine("The expected text shape or paragraph was not found.");
}
```

Wynik:

![Obraz akapitu](paragraph_to_image_output.png)

#### **Renderowanie akapitu w komórce tabeli ze skalowaniem**

Użyj przeciążenia [IParagraph.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getimage/), które przyjmuje parametry `float scaleX` i `float scaleY`, aby ustawić czynniki skalowania w poziomie i pionie. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej domyślnej szerokości i wysokości oraz zapisuje wynik jako obraz PNG.

```csharp
using System;
using Aspose.Slides;

var scaleX = 2f;
var scaleY = 2f;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var table = slide.Shapes.AddTable(50, 50, new[] { 300d }, new[] { 80d });
var paragraph = table[0, 0].TextFrame.Paragraphs[0];
paragraph.Text = "Text in a table cell";

using var paragraphImage = paragraph.GetImage(scaleX, scaleY);
if (paragraphImage != null)
{
    paragraphImage.Save("table_paragraph.png", ImageFormat.Png);
}
else
{
    Console.WriteLine("The paragraph could not be rendered.");
}
```

Współczynnik skali `1` zachowuje domyślny rozmiar w pikselach dla danej osi. Na przykład `2` dla obu współczynników powoduje, że szerokość i wysokość obrazu są w przybliżeniu dwukrotnie większe niż domyślne wymiary, co daje cztery razy więcej pikseli. Większe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wysokiej rozdzielczości, ale zwiększają także zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` dają mniejsze obrazy z mniejszą ilością szczegółów. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki w poziomie i pionie rozciągają obraz niezależnie.

Renderowanie całego kształtu za pomocą [IShape.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getimage/) pozostaje przydatne, gdy wynik musi zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Do obrazu wyłącznie akapitu użyj [IParagraph.GetImage](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Czy mogę całkowicie wyłączyć zawijanie linii wewnątrz ramki tekstowej?**

Tak. Ustaw [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframeformat/wraptext/) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak mogę uzyskać dokładne granice określonego akapitu na slajdzie?**

Użyj [IParagraph.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/getrect/) aby pobrać prostokąt otaczający akapit. [IPortion.GetRect](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/getrect/) dostarcza granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub wyjustowane)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/alignment/) jest ustawieniem na poziomie akapitu i obowiązuje dla całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/ibaseportionformat/languageid/) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.