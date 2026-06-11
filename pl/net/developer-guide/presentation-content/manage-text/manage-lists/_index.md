---
title: Zarządzanie listami punktowanymi i numerowanymi w prezentacjach w .NET
linktitle: Zarządzaj listami
type: docs
weight: 70
url: /pl/net/manage-lists/
keywords:
- punktor
- lista punktowana
- lista numerowana
- symbol punktora
- punkt graficzny
- niestandardowy punktor
- lista wielopoziomowa
- utwórz punkt
- dodaj punkt
- dodaj listę
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i formatować listy punktowane, graficzne, wielopoziomowe i numerowane w prezentacjach PowerPoint oraz OpenDocument przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides for .NET umożliwia tworzenie i formatowanie list punktowanych i numerowanych w prezentacjach PowerPoint oraz OpenDocument. Element listy to akapit, którego ustawienia punktora są kontrolowane przez format akapitu.

Użyj właściwości [IParagraph.ParagraphFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/paragraphformat/) aby uzyskać dostęp do ustawień list na poziomie akapitu. Głównym punktem wejścia jest [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/bullet/), który zwraca obiekt [IBulletFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/). Za jego pomocą możesz ustawić typ punktora, symbol, obraz, kolor, rozmiar, styl numeracji oraz numer początkowy.

Ten artykuł pokazuje, jak:

- utworzyć listę punktowaną z niestandardowym symbolem
- utworzyć punkt graficzny
- utworzyć listę wielopoziomową ustawiając głębokość akapitu
- utworzyć listę numerowaną
- sprawdzić i zmienić formatowanie listy w istniejącej prezentacji

## **Utwórz listę punktowaną**

Aby utworzyć listę punktowaną, dodaj obiekty [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) i ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Symbol](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/). Następnie możesz ustawić [IBulletFormat.Char](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/char/), [IBulletFormat.Color](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/color/), oraz [IBulletFormat.Height](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/height/) aby kontrolować wygląd punktora.

Poniższy kod C# demonstruje, jak utworzyć listę punktowaną na slajdzie:

```csharp
static Paragraph CreateParagraph(string text)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    paragraph.ParagraphFormat.Bullet.Char = '*';
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True;
    paragraph.ParagraphFormat.Bullet.Color.Color = Color.IndianRed;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = CreateParagraph("The first paragraph");
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph");
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("symbol_bullets.pptx", SaveFormat.Pptx);
```

Wynik:

![Symbole punktów](symbol_bullets.png)

## **Utwórz listę numerowaną**

Używaj list numerowanych, gdy kolejność elementów ma znaczenie. Ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Numbered](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/). Możesz również wybrać format numeracji przy pomocy [IBulletFormat.NumberedBulletStyle](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstyle/) lub ustawić [IBulletFormat.NumberedBulletStartWith](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstartwith/), gdy lista ma zaczynać się od wartości innej niż 1.

Poniższy kod C# pokazuje, jak utworzyć listę numerowaną na slajdzie:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 90, 80);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph1.Text = "Apple";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph2.Text = "Orange";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph3.Text = "Banana";
textFrame.Paragraphs.Add(paragraph3);

presentation.Save("numbered_bullets.pptx", SaveFormat.Pptx);
```

Wynik:

![Punkty numerowane](numbered_bullets.png)

## **Utwórz punkt graficzny**

Aspose.Slides pozwala zamienić zwykły symbol punktora na obraz. Punkty graficzne działają najlepiej z prostymi obrazami, które pozostają czytelne w małym rozmiarze, takimi jak ikony lub małe przezroczyste pliki PNG.

 {{% alert color="primary" %}}
Idealnie, jeśli planujesz zastąpić zwykły symbol punktora obrazem, najlepiej wybrać prostą grafikę z przezroczystym tłem. Takie obrazy dobrze sprawdzają się jako niestandardowe symbole punktora.
{{% /alert %}}

Aby utworzyć punkt graficzny, dodaj obraz do [Presentation.Images](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/images/) i przypisz zwrócony obiekt obrazu do [IBulletFormat.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/picture/). Ustaw [IBulletFormat.Type](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/type/) na [BulletType.Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/bullettype/) przed przypisaniem obrazu.

Załóżmy, że mamy plik "image.png":

![Obraz dla punktów](picture_for_bullets.png)

Poniższy kod C# pokazuje, jak utworzyć punkty graficzne na slajdzie:

```csharp
static Paragraph CreateParagraph(string text, IPPImage image)
{
    var paragraph = new Paragraph();
    paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
    paragraph.ParagraphFormat.Bullet.Picture.Image = image;
    paragraph.ParagraphFormat.Indent = 15;
    paragraph.ParagraphFormat.Bullet.Height = 100;
    paragraph.Text = text;
    return paragraph;
}

using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 200, 50);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var imageBytes = File.ReadAllBytes("image.png");
var bulletImage = presentation.Images.AddImage(imageBytes);

var paragraph1 = CreateParagraph("The first paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = CreateParagraph("The second paragraph", bulletImage);
textFrame.Paragraphs.Add(paragraph2);

presentation.Save("picture_bullets.pptx", SaveFormat.Pptx);
```

Wynik:

![Punkty graficzne](picture_bullets.png)

## **Utwórz listę wielopoziomową**

Użyj [IParagraphFormat.Depth](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/depth/) aby umieścić elementy listy na różnych poziomach. Poziom 0 to najwyższy poziom, poziom 1 jest zagnieżdżony poniżej niego, i tak dalej.

Poniższy kod C# pokazuje, jak utworzyć wielopoziomową listę punktowaną:

```csharp
using var presentation = new Presentation();

var slide = presentation.Slides[0];
var autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 260, 110);

var textFrame = autoShape.TextFrame;
textFrame.Paragraphs.Clear();

var paragraph1 = new Paragraph();
paragraph1.ParagraphFormat.Depth = 0;
paragraph1.Text = "My text - Depth 0";
textFrame.Paragraphs.Add(paragraph1);

var paragraph2 = new Paragraph();
paragraph2.ParagraphFormat.Depth = 1;
paragraph2.Text = "My text - Depth 1";
textFrame.Paragraphs.Add(paragraph2);

var paragraph3 = new Paragraph();
paragraph3.ParagraphFormat.Depth = 2;
paragraph3.Text = "My text - Depth 2";
textFrame.Paragraphs.Add(paragraph3);

var paragraph4 = new Paragraph();
paragraph4.ParagraphFormat.Depth = 3;
paragraph4.Text = "My text - Depth 3";
textFrame.Paragraphs.Add(paragraph4);

presentation.Save("multilevel_bullets.pptx", SaveFormat.Pptx);
```

Wynik:

![Lista wielopoziomowa](multilevel_list.png)

## **Zmień istniejącą listę**

Aby zmienić formatowanie listy w istniejącej prezentacji, uzyskaj dostęp do docelowego akapitu i zaktualizuj jego ustawienia [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/bullet/). Te same właściwości użyte do tworzenia list mogą być użyte do sprawdzania lub modyfikowania list załadowanych z pliku PPT, PPTX lub ODP.

Poniższy kod C# zmienia pierwszy akapit w ramce tekstowej, aby używał stylu listy numerowanej:

```csharp
using var presentation = new Presentation("input.pptx");

var slide = presentation.Slides[0];
var autoShape = (IAutoShape)slide.Shapes[0];
var paragraph = autoShape.TextFrame.Paragraphs[0];

paragraph.ParagraphFormat.Bullet.Type = BulletType.Numbered;
paragraph.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletRomanUCPeriod;
paragraph.ParagraphFormat.Bullet.NumberedBulletStartWith = 1;
paragraph.ParagraphFormat.MarginLeft = 30;
paragraph.ParagraphFormat.Indent = -20;

presentation.Save("updated_list.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Czy listy punktowane i numerowane mogą być eksportowane do PDF lub obrazów?**

Tak. Aspose.Slides zachowuje formatowanie list, gdy format docelowy obsługuje odpowiednie układy tekstu i funkcje punktora.

**Czy mogę edytować listy w istniejących prezentacjach?**

Tak. Załaduj prezentację, uzyskaj dostęp do docelowego akapitu, sprawdź lub zaktualizuj jego ustawienia [IParagraphFormat.Bullet](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/bullet/), i zapisz prezentację.

**Czy listy mogą zawierać tekst niełaciński?**

Tak. Tekst elementu listy może zawierać znaki Unicode, dzięki czemu możesz tworzyć listy w wielojęzycznych prezentacjach. Upewnij się, że czcionki użyte w prezentacji obsługują potrzebne znaki.