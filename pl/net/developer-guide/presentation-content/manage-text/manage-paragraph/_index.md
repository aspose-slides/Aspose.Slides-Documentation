---
title: Zarządzanie akapitami tekstowymi PowerPoint w .NET
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
- wypunktowanie akapitu
- lista numerowana
- lista wypunktowana
- właściwości akapitu
- import HTML
- tekst do HTML
- akapit do HTML
- akapit do obrazu
- tekst do obrazu
- eksport akapitu
- PowerPoint
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować akapity, fragmenty, wypunktowania, listy numerowane, wcięcia, treść HTML oraz obrazy akapitów przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET reprezentuje tekst jako hierarchię ramek tekstowych, akapitów i fragmentów:

* [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) reprezentuje kontener tekstowy w kształcie i zapewnia dostęp do jego kolekcji akapitów.
* [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) reprezentuje jeden akapit w ramce tekstowej i zapewnia dostęp do jego fragmentów oraz formatowania na poziomie akapitu.
* [IPortion](https://reference.aspose.com/slides/net/aspose.slides/iportion/) reprezentuje ciąg tekstowy w obrębie akapitu. Każdy fragment może mieć własny tekst i formatowanie na poziomie znaków.

Akapit może więc zawierać tekst w różnych czcionkach, kolorach, rozmiarach i innych formatach przy użyciu wielu fragmentów.

## **Tworzenie i formatowanie akapitów**

Twórz akapity w ramce tekstowej kształtu i używaj fragmentów do formatowania pojedynczych ciągów tekstowych. Ta sekcja pokazuje, jak łączyć wiele fragmentów w każdym akapicie oraz stosować różne kolory, rozmiary czcionek i style.

### **Tworzenie akapitów z wieloma fragmentami**

Poniższy przykład w C# tworzy trzy akapity, z których każdy zawiera trzy ciągi tekstowe w swojej kolekcji [IParagraph.Portions](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/portions/). Ponownie używa domyślnego akapitu i jego pustego fragmentu, a następnie dodaje pozostałe akapity i fragmenty. Formatowanie jest stosowane przez [IPortion.PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iportion/portionformat/): pierwszy fragment w każdym akapicie jest czerwony, pogrubiony i ma 15 punktów; drugi jest niebieski, pochylony i ma 18 punktów. Trzeci fragment zachowuje domyślne formatowanie:

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

## **Tworzenie list wypunktowanych i numerowanych**

Organizuj tekst akapitu w listy ze znakami, numerami lub własnymi obrazkami. Przykłady w tej sekcji obejmują formatowanie wypunktowania, listy wielopoziomowe oraz własne liczby początkowe.

### **Tworzenie listy wypunktowanej lub numerowanej**

Wypunktowanie i numeracja ułatwiają przeglądanie powiązanych elementów. W Aspose.Slides ustawienia listy definiowane są przez [IBulletFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/).

Ten przykład w C# dodaje symbol wypunktowania i numerowaną pozycję do tej samej ramki tekstowej. [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) wybiera typ wypunktowania, podczas gdy [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) dostarcza symbol, a [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstyle/) wybiera styl numeracji. Oba elementy używają czarnych wypunktowań o wysokości 100 % i wcięciu akapitu wynoszącym 25 punktów:

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

### **Użycie wypunktowania obrazkowego**

Wypunktowanie obrazkowe pozwala użyć własnego obrazu zamiast symbolu lub liczby.

Ten przykład w C# dodaje obraz do kolekcji obrazów prezentacji jako [IPPImage](https://reference.aspose.com/slides/net/aspose.slides/ippimage/) i używa go jako wypunktowania akapitu. Ustawia [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) na użycie wypunktowania obrazkowego i przypisuje obraz przez [IBulletFormat.Picture](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/picture/). [IBulletFormat.Height](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/height/) jest ustawione na 100 % w celu dopasowania rozmiaru wypunktowania względem tekstu akapitu:

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

### **Tworzenie listy wielopoziomowej**

Ustaw [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) aby umieścić akapity na różnych poziomach listy. Najwyższy poziom ma głębokość `0`.

Ten przykład w C# przypisuje wartości [IParagraphFormat.Depth](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/depth/) od 0 do 3 czterem akapitom, tworząc hierarchię w jednej ramce tekstowej. Każdy akapit używa symbolu wypunktowania, przy czym [IBulletFormat.Char](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/char/) naprzemiennie przełącza się między okrągłym wypunktowaniem a myślnikiem, aby odróżnić sąsiednie poziomy:

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

### **Rozpoczęcie elementów listy numerowanej od własnych wartości**

Użyj [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) aby ustawić początkowy numer wyświetlany dla numerowanego akapitu.

Ten przykład w C# ustawia [IBulletFormat.Type](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/type/) na użycie numeracji dla trzech akapitów i przypisuje wartości [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/net/aspose.slides/ibulletformat/numberedbulletstartwith/) równą 2, 3 i 7. Wartość początkowa jest konfigurowana oddzielnie dla każdego akapitu, co pozwala pomijać niektóre liczby:

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

Dostosuj marginesy i wcięcia akapitu, aby kontrolować pozycję pierwszej linii i linii zawijanych. Możesz także formatować znak końcowy akapitu oddzielnie od widocznych fragmentów tekstu.

### **Ustawienie wcięcia pierwszej linii**

Użyj własności [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) aby kontrolować wcięcie pierwszej linii akapitu. Właściwość ta przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, podczas gdy pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) gdy potrzebujesz przesunąć tylko pierwszą linię.

Poniższy przykład nadaje trzem akapitom taki sam [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) równy 20 punktów oraz wartości [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) równą 0, 20 i 40 punktów. Pierwsze linie zaczynają się przy kolejno większych odsunięciach, podczas gdy linie zawijane zachowują ten sam lewy margines:

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

Wcięcie wiszące to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt przy pomocy własności [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/). Ustaw `Indent` na ujemną wartość, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) określa lewą pozycję ciała akapitu, a [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) określa pozycję pierwszej linii względem tego marginesu. Aby stworzyć wcięcie wiszące, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

To formatowanie jest przydatne w bibliografiach, odnośnikach, hasłach słownika i innych akapitach, w których linie zawijane muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

Poniższy przykład w C# paruje wartości [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginleft/) równe 40 i 60 punktów z wartościami [IParagraphFormat.Indent](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/indent/) równymi -20 i -30 punktów. W każdym akapicie pierwsza linia zaczyna się po lewej stronie linii zawijanych; drugi akapit ma głębsze wcięcie wiszące:

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

Własność [IParagraph.EndParagraphPortionFormat](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/endparagraphportionformat/) kontroluje formatowanie znaku końcowego akapitu. Poniższy przykład tworzy [PortionFormat](https://reference.aspose.com/slides/net/aspose.slides/portionformat/) z [IBasePortionFormat.FontHeight](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/fontheight/) ustawionym na 48 punktów oraz [IBasePortionFormat.LatinFont](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/latinfont/) ustawionym na Times New Roman. Przypisuje ten format do znaku końcowego drugiego akapitu, pozostawiając niezmienione widoczne fragmenty tekstu:

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

## **Liczenie renderowanych linii**

W odniesieniu do reguł akapitu, które wpływają na automatyczne zawijanie i interpunkcję przy końcach linii, zobacz [Control Line Breaking](/slides/pl/net/text-formatting/#control-line-breaking) oraz [Control Hanging Punctuation](/slides/pl/net/text-formatting/#control-hanging-punctuation).

Użyj [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/) aby policzyć linie zajmowane przez akapit po rozmieszczeniu tekstu, w tym automatyczne zawijanie. Przydaje się przy sprawdzaniu długości tekstu i układu w szablonach prezentacji.

Akapit jest jednym elementem w [ITextFrame.Paragraphs](https://reference.aspose.com/slides/net/aspose.slides/itextframe/paragraphs/), i może zajmować kilka renderowanych linii. Jawny podział wiersza w akapicie wymusza nową linię bez tworzenia kolejnego akapitu. Automatyczne zawijanie tworzy linie w oparciu o dostępną szerokość, nie wstawiając jawnych podziałów wiersza do tekstu. Dlatego liczenie akapitów lub znaków podziału wiersza nie daje liczby renderowanych linii.

Poniższy przykład tworzy kształt tekstowy, liczy jego linie, zwęża kształt, a następnie zamienia tekst na krótszy ciąg. Przykład włącza [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) i wyłącza [ITextFrameFormat.AutofitType](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/autofittype/), tak aby szerokość kształtu kontrolowała zawijanie bez automatycznego zmniejszania tekstu lub zmiany rozmiaru kształtu. Każdy pomiar używa [IParagraph.GetLinesCount](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getlinescount/). Wymiary kształtu podawane są w punktach. Na koniec przykład dodaje kolejny akapit i sumuje liczby linii w całej ramce tekstowej.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 400, 200);
var textFrame = shape.TextFrame;
textFrame.TextFrameFormat.WrapText = NullableBool.True;
textFrame.TextFrameFormat.AutofitType = TextAutofitType.None;

var paragraph = textFrame.Paragraphs[0];
paragraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
paragraph.Text = "This text demonstrates how automatic wrapping changes the number of rendered lines.";
Console.WriteLine($"Original width: {paragraph.GetLinesCount()}");

shape.Width = 150;
Console.WriteLine($"Narrower shape: {paragraph.GetLinesCount()}");

paragraph.Text = "Short text.";
Console.WriteLine($"Shorter text: {paragraph.GetLinesCount()}");

var secondParagraph = new Paragraph { Text = "Another paragraph." };
secondParagraph.ParagraphFormat.DefaultPortionFormat.FontHeight = 20;
textFrame.Paragraphs.Add(secondParagraph);

var totalLineCount = 0;
foreach (var currentParagraph in textFrame.Paragraphs)
{
    totalLineCount += currentParagraph.GetLinesCount();
}
Console.WriteLine($"Total lines in the text frame: {totalLineCount}");
```

Przy tym tekście i wymiarach zwężenie kształtu zwiększa liczbę linii, natomiast zamiana tekstu na krótki ciąg ją zmniejsza. Dokładne liczby mogą się różnić w zależności od dostępności i substytucji czcionek, rozmiaru czcionki, marginesów, wcięć, zawijania i ustawień autofitu. Używaj czcionek i ustawień układu przeznaczonych dla docelowego środowiska przy sprawdzaniu szablonu.

Sama liczba linii nie określa, czy tekst przekracza swój pojemnik. Ważna jest dostępna wysokość, wysokość linii, interlinia akapitu i linii oraz zachowanie autofitu; nawet pojedyncza linia może przekroczyć dostępną szerokość, gdy zawijanie jest wyłączone.

## **Import i eksport treści akapitu**

Użyj HTML, aby wprowadzić tekst do prezentacji lub wyeksportować istniejące akapity do użycia poza nią. Ta sekcja pokazuje również, jak renderować pojedyncze akapity jako obrazy, w tym akapity w komórkach tabel.

### **Importowanie tekstu HTML do akapitów**

Użyj [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/) aby przekształcić znacznik HTML w akapity i fragmenty w ramce tekstowej.

Ten przykład w C# odczytuje HTML z pliku i przekazuje znacznik do [ParagraphCollection.AddFromHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/addfromhtml/). Czyści domyślny akapit ramki tekstowej, tak aby ramka zawierała tylko zaimportowaną zawartość. Prostokątny kształt pozostawia margines 10 punktów po każdej stronie slajdu:

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

Użyj [ParagraphCollection.ExportToHtml](https://reference.aspose.com/slides/net/aspose.slides/paragraphcollection/exporttohtml/) aby wyeksportować wybrany zakres akapitów jako HTML. Przy ponownym użyciu tekstu prezentacji na stronie internetowej możesz chcieć zachować lokalne wyróżnienia bez przenoszenia czcionki, rozmiaru ani stylów pola tekstowego z prezentacji. Ustaw [TextToHtmlConversionOptions.TextInheritanceLimit](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/textinheritancelimit/) aby kontrolować, jak daleko eksporter podąża za dziedziczeniem formatowania.

Pobierz [przykładową prezentację](text-inheritance.pptx) i umieść ją w katalogu roboczym aplikacji. Jej pierwszy slajd zawiera jedną formę tekstową z tekstem „Inherited text; explicit red 18pt”. Wejście celowo używa kilku poziomów formatowania:

- Domyślny styl tekstu prezentacji dostarcza czcionkę Calibri i rozmiar 28 pt.
- Styl tekstu pierwszego poziomu ramki tekstowej dostarcza niebieski kolor i kursywę.
- Akapit wyraźnie ustawia pogrubiony tekst.
- Drugi fragment, „explicit red 18pt”, wyraźnie ustawia czerwony kolor i rozmiar 18 pt.

Poniższy kompletny przykład eksportuje te same akapity trzy razy. Przekazuje [TextToHtmlConversionOptions](https://reference.aspose.com/slides/net/aspose.slides.export/texttohtmlconversionoptions/) do metody eksportu i zapisuje każdy wynik jako osobny plik HTML w kodowaniu UTF‑8:

```csharp
using System.IO;
using System.Text;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("text-inheritance.pptx");
var textShape = (IAutoShape)presentation.Slides[0].Shapes[0];

var paragraphs = textShape.TextFrame.Paragraphs;
var modes = new[] { TextInheritanceLimit.All, TextInheritanceLimit.TextBox, TextInheritanceLimit.ParagraphOnly };

foreach (var mode in modes)
{
    var options = new TextToHtmlConversionOptions { TextInheritanceLimit = mode };

    var html = paragraphs.ExportToHtml(0, paragraphs.Count, options);
    File.WriteAllText($"{mode}.html", html, Encoding.UTF8);
}
```

Wygenerowany HTML zawiera następujący CSS dla pierwszego fragmentu, „Inherited text; “. Tabela wymienia odpowiednie deklaracje; inne wygenerowane właściwości zostały pominięte dla przejrzystości.

| Wyjście | Odpowiedni CSS dla pierwszego fragmentu | Wygląd |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa tekstu 28 pt w Calibri, jeśli ta czcionka jest dostępna. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Niebieski, pogrubiony, kursywa; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki i rozmiar. |
| `ParagraphOnly.html` | `font-weight:bold` | Pogrubiony tekst; otaczająca strona lub przeglądarka dostarcza rodzinę czcionki, rozmiar, kolor i styl kursywy. |

Drugi fragment zachowuje `color:#ff0000`, `font-size:18pt` i `font-weight:bold` we wszystkich trzech wyjściach. Zachowuje także kursywę w `All` i `TextBox`, lecz nie w `ParagraphOnly`. Ograniczenie dziedziczenia nie usuwa więc formatowania przypisanego explicite do akapitu lub fragmentu.

Otwórz pliki w tej samej przeglądarce, aby je porównać. W dwóch ograniczonych trybach pominięte właściwości CSS są rozwiązywane przez style docelowej strony lub domyślne ustawienia przeglądarki, więc ostateczny wygląd zależy od miejsca użycia HTML.

### **Renderowanie akapitu jako obrazu**

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) renderuje pojedynczy akapit bezpośrednio i zwraca [IImage](https://reference.aspose.com/slides/net/aspose.slides/iimage/). Zapisz wynik do pliku lub strumienia za pomocą [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/). Nie musisz renderować zawierającego kształtu ani ręcznie przycinać bitmapy.

[IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) może zwrócić `null`, jeśli akapit nie zostanie znaleziony w kolekcji rodzica, nie ma prawidłowych granic renderowania lub nie może być renderowany. Sprawdź wynik przed zapisem i zwolnij zwrócony obraz po użyciu.

#### **Renderowanie akapitu w domyślnej skali**

Przykład używa prezentacji z jednym slajdem, którego pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

Poniższy przykład wybiera drugi akapit o indeksie 1 i wywołuje [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/) bez parametrów skali. Sprawdza, czy kształt zawiera wymaganego akapitu i czy renderowanie zwróciło obraz przed wywołaniem [IImage.Save](https://reference.aspose.com/slides/net/aspose.slides/iimage/save/) w celu zapisania go w formacie PNG. Deklaracja `using` zwalnia obraz po użyciu.

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

Użyj przeciążenia [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/), które akceptuje parametry `float scaleX` i `float scaleY` w celu ustawienia współczynników skali poziomej i pionowej. Poniższy przykład tworzy tabelę, renderuje akapit w jej pierwszej komórce przy dwukrotnej domyślnej szerokości i wysokości i zapisuje wynik jako obraz PNG.

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

Współczynnik skali `1` utrzymuje dany oś w domyślnym rozmiarze pikseli. Na przykład `2` dla obu współczynników daje obraz, którego szerokość i wysokość są w przybliżeniu dwukrotne względem domyślnych wymiarów, co skutkuje czterokrotnie większą liczbą pikseli. Większe współczynniki zazwyczaj dają ostrzejszy tekst przy powiększaniu lub wyjściu o wysokiej rozdzielczości, ale zwiększają także zużycie pamięci i rozmiar pliku. Współczynniki poniżej `1` tworzą mniejsze obrazy o mniejszej szczegółowości. Używaj równych współczynników, aby zachować proporcje akapitu; różne współczynniki poziome i pionowe rozciągają wynik niezależnie.

Renderowanie całego kształtu przy pomocy [IShape.GetImage](https://reference.aspose.com/slides/net/aspose.slides/ishape/getimage/) pozostaje przydatne, gdy wynik ma zawierać wypełnienie, obramowanie lub inny kontekst wizualny kształtu. Dla obrazu wyłącznie akapitu użyj [IParagraph.GetImage](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getimage/).

## **FAQ**

**Czy mogę całkowicie wyłączyć automatyczne zawijanie w ramce tekstowej?**

Tak. Ustaw [ITextFrameFormat.WrapText](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/wraptext/) aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki tekstowej.

**Jak uzyskać dokładne granice na slajdzie konkretnego akapitu?**

Użyj [IParagraph.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/getrect/) aby pobrać prostokąt granicowy akapitu. [IPortion.GetRect](https://reference.aspose.com/slides/net/aspose.slides/iportion/getrect/) podaje granice pojedynczego fragmentu.

**Gdzie kontrolowane jest wyrównanie akapitu (lewe, prawe, wyśrodkowane lub justowane)?**

[IParagraphFormat.Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) jest ustawieniem na poziomie akapitu i ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

Aby pionowo wyrównać fragmenty o różnych rozmiarach czcionki w każdej linii, zobacz [Align Fonts Within a Line](/slides/pl/net/text-formatting/#align-fonts-within-a-line).

**Czy mogę ustawić język korekty dla części akapitu?**

Tak. Ustaw [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/net/aspose.slides/ibaseportionformat/languageid/) dla poszczególnych fragmentów, aby jeden akapit mógł zawierać tekst w wielu językach.