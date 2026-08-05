---
title: Zarządzanie paragrafami tekstu PowerPoint w .NET
linktitle: Zarządzanie paragrafem
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
  - wcięcie zwisające
  - punktowanie akapitu
  - lista numerowana
  - lista wypunktowana
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
description: "Opanuj formatowanie akapitów w Aspose.Slides dla .NET — zoptymalizuj wyrównanie, odstępy i styl w prezentacjach PPT, PPTX i ODP w C#."
---
## **Wprowadzenie**

Aspose.Slides udostępnia wszystkie interfejsy i klasy potrzebne do pracy z tekstami, akapitami i fragmentami PowerPoint w języku C#.

* Aspose.Slides udostępnia interfejs [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) umożliwiający dodawanie obiektów reprezentujących akapit. Obiekt `ITextFame` może zawierać jeden lub wiele akapitów (każdy akapit tworzony jest przy użyciu znaku końca wiersza).
* Aspose.Slides udostępnia interfejs [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) umożliwiający dodawanie obiektów reprezentujących fragmenty. Obiekt `IParagraph` może zawierać jeden lub wiele fragmentów (kolekcja obiektów iPortions).
* Aspose.Slides udostępnia interfejs [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) umożliwiający dodawanie obiektów reprezentujących teksty oraz ich właściwości formatowania.

Obiekt `IParagraph` może obsługiwać teksty o różnych właściwościach formatowania za pośrednictwem swoich podrzędnych obiektów `IPortion`.

## **Dodawanie wielu akapitów zawierających wiele fragmentów**

Poniższe kroki pokazują, jak dodać ramkę tekstową zawierającą 3 akapity, przy czym każdy akapit zawiera 3 fragmenty:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj prostokątną [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Pobierz ITextFrame powiązany z [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).
5. Utwórz dwa obiekty [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) i dodaj je do kolekcji `IParagraphs` w [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/).
6. Utwórz trzy obiekty [IPortion](https://reference.aspose.com/slides/pl/net/aspose.slides/iportion/) dla każdego nowego `IParagraph` (dwa obiekty Portion dla domyślnego akapitu) i dodaj każdy obiekt `IPortion` do kolekcji IPortion odpowiedniego `IParagraph`.
7. Ustaw tekst dla każdego fragmentu.
8. Zastosuj wybrane funkcje formatowania do każdego fragmentu, używając właściwości formatowania udostępnionych przez obiekt `IPortion`.
9. Zapisz zmodyfikowaną prezentację.

```c#
// Inicjalizuje klasę Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{
    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = pres.Slides[0];

    // Dodaje prostokątny IAutoShape
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Uzyskuje dostęp do TextFrame AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Tworzy akapity i fragmenty o różnych formatach tekstu
    IParagraph para0 = tf.Paragraphs[0];
    IPortion port01 = new Portion();
    IPortion port02 = new Portion();
    para0.Portions.Add(port01);
    para0.Portions.Add(port02);

    IParagraph para1 = new Paragraph();
    tf.Paragraphs.Add(para1);
    IPortion port10 = new Portion();
    IPortion port11 = new Portion();
    IPortion port12 = new Portion();
    para1.Portions.Add(port10);
    para1.Portions.Add(port11);
    para1.Portions.Add(port12);

    IParagraph para2 = new Paragraph();
    tf.Paragraphs.Add(para2);
    IPortion port20 = new Portion();
    IPortion port21 = new Portion();
    IPortion port22 = new Portion();
    para2.Portions.Add(port20);
    para2.Portions.Add(port21);
    para2.Portions.Add(port22);

    for (int i = 0; i < 3; i++)
        for (int j = 0; j < 3; j++)
        {
            tf.Paragraphs[i].Portions[j].Text = "Portion0" + j.ToString();
            if (j == 0)
            {
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Red;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontBold = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 15;
            }
            else if (j == 1)
            {
                tf.Paragraphs[i].Portions[j].FillFormat.FillType = FillType.Solid;
                tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
            }
        }
    // Zapisuje zmodyfikowaną prezentację
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Zarządzanie punktami listy w akapicie**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z punktami są zawsze łatwiejsze do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do wybranego slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu za pomocą klasy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/).
8. Ustaw właściwość `Type` punktu dla akapitu na `Symbol` i określ znak punktu.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla punktu.
11. Ustaw kolor punktu.
12. Ustaw wysokość punktu.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces opisany w krokach 7‑13.
15. Zapisz prezentację.

```c#
// Inicjalizuje klasę Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = pres.Slides[0];


    // Dodaje i uzyskuje dostęp do Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Usuwa domyślny akapit
    txtFrm.Paragraphs.RemoveAt(0);

    // Tworzy akapit
    Paragraph para = new Paragraph();

    // Ustawia styl punktu akapitu i symbol
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Ustawia tekst akapitu
    para.Text = "Welcome to Aspose.Slides";

    // Ustawia wcięcie punktu
    para.ParagraphFormat.Indent = 25;

    // Ustawia kolor punktu
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ustaw IsBulletHardColor na true, aby używać własnego koloru punktu

    // Ustawia wysokość punktu
    para.ParagraphFormat.Bullet.Height = 100;

    // Dodaje akapit do ramki tekstowej
    txtFrm.Paragraphs.Add(para);

    // Tworzy drugi akapit
    Paragraph para2 = new Paragraph();

    // Ustawia typ i styl punktu akapitu
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Dodaje tekst akapitu
    para2.Text = "This is numbered bullet";

    // Ustawia wcięcie punktu
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // ustaw IsBulletHardColor na true, aby używać własnego koloru punktu

    // Ustawia wysokość punktu
    para2.ParagraphFormat.Bullet.Height = 100;

    // Dodaje akapit do ramki tekstowej
    txtFrm.Paragraphs.Add(para2);


    // Zapisuje zmodyfikowaną prezentację
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Zarządzanie punktami graficznymi**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Akapity z obrazkami są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation).
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/).
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu za pomocą klasy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/).
7. Wczytaj obraz przy użyciu [IPPImage](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/).
8. Ustaw typ punktu na [Picture](https://reference.aspose.com/slides/pl/net/aspose.slides/ippimage/) i określ obraz.
9. Ustaw `Text` akapitu.
10. Ustaw `Indent` akapitu dla punktu.
11. Ustaw kolor punktu.
12. Ustaw wysokość punktu.
13. Dodaj nowy akapit do kolekcji akapitów `TextFrame`.
14. Dodaj drugi akapit i powtórz proces na podstawie poprzednich kroków.
15. Zapisz zmodyfikowaną prezentację.

```c#
// Inicjalizuje klasę Presentation, która reprezentuje plik PPTX
Presentation presentation = new Presentation();

// Uzyskuje dostęp do pierwszego slajdu
ISlide slide = presentation.Slides[0];

// Inicjalizuje obraz dla punktów
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Dodaje i uzyskuje dostęp do Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Uzyskuje dostęp do ramki tekstowej autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Usuwa domyślny akapit
textFrame.Paragraphs.RemoveAt(0);

// Tworzy nowy akapit
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Ustawia styl punktu akapitu i obraz
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Ustawia wysokość punktu
paragraph.ParagraphFormat.Bullet.Height = 100;

// Dodaje akapit do ramki tekstowej
textFrame.Paragraphs.Add(paragraph);

// Zapisuje prezentację jako plik PPTX
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Zapisuje prezentację jako plik PPT
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Zarządzanie punktami wielopoziomowymi**

Listy punktowane pomagają szybko i efektywnie organizować oraz prezentować informacje. Punkty wielopoziomowe są łatwe do odczytania i zrozumienia.

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) na nowym slajdzie.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/).
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) i ustaw głębokość na 0.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 1.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 2.
9. Utwórz czwartą instancję akapitu przy użyciu klasy `Paragraph` i ustaw głębokość na 3.
10. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
11. Zapisz zmodyfikowaną prezentację.

```c#
// Inicjalizuje klasę Presentation, która reprezentuje plik PPTX
using (Presentation pres = new Presentation())
{

    // Uzyskuje dostęp do pierwszego slajdu
    ISlide slide = pres.Slides[0];
    
    // Dodaje i uzyskuje dostęp do Autoshape
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Czyści domyślny akapit
    text.Paragraphs.Clear();

    // Dodaje pierwszy akapit
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ustawia poziom punktu
    para1.ParagraphFormat.Depth = 0;

    // Dodaje drugi akapit
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ustawia poziom punktu
    para2.ParagraphFormat.Depth = 1;

    // Dodaje trzeci akapit
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ustawia poziom punktu
    para3.ParagraphFormat.Depth = 2;

    // Dodaje czwarty akapit
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Ustawia poziom punktu
    para4.ParagraphFormat.Depth = 3;

    // Dodaje akapity do kolekcji
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Zapisuje prezentację jako plik PPTX
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Zarządzanie akapitem z niestandardową listą numerowaną**

Interfejs [IBulletFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/) udostępnia właściwość [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstartwith) oraz inne, które umożliwiają zarządzanie akapitami z niestandardowym numerowaniem lub formatowaniem.

1. Utwórz instancję klasy [Presentation ](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj dostęp do slajdu zawierającego akapit.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/) do slajdu.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) autoshape.
5. Usuń domyślny akapit w `TextFrame`.
6. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) i ustaw [NumberedBulletStartWith](https://reference.aspose.com/slides/pl/net/aspose.slides/ibulletformat/numberedbulletstartwith) na 2.
7. Utwórz drugą instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 3.
8. Utwórz trzecią instancję akapitu przy użyciu klasy `Paragraph` i ustaw `NumberedBulletStartWith` na 7.
9. Dodaj nowe akapity do kolekcji akapitów `TextFrame`.
10. Zapisz zmodyfikowaną prezentację.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Uzyskuje dostęp do ramki tekstowej utworzonego autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Usuwa domyślny istniejący akapit
	textFrame.Paragraphs.RemoveAt(0);

	// Pierwsza lista
	var paragraph1 = new Paragraph { Text = "bullet 2" };
	paragraph1.ParagraphFormat.Depth = 4; 
	paragraph1.ParagraphFormat.Bullet.NumberedBulletStartWith = 2;
	paragraph1.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph1);

	var paragraph2 = new Paragraph { Text = "bullet 3" };
	paragraph2.ParagraphFormat.Depth = 4;
	paragraph2.ParagraphFormat.Bullet.NumberedBulletStartWith = 3; 
	paragraph2.ParagraphFormat.Bullet.Type = BulletType.Numbered;  
	textFrame.Paragraphs.Add(paragraph2);

	
	var paragraph5 = new Paragraph { Text = "bullet 7" };
	paragraph5.ParagraphFormat.Depth = 4;
	paragraph5.ParagraphFormat.Bullet.NumberedBulletStartWith = 7;
	paragraph5.ParagraphFormat.Bullet.Type = BulletType.Numbered;
	textFrame.Paragraphs.Add(paragraph5);

	presentation.Save("SetCustomBulletsNumber-slides.pptx", SaveFormat.Pptx);
}
```

## **Ustawianie wcięcia pierwszej linii akapitu**

Użyj właściwości [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) aby kontrolować wcięcie pierwszej linii akapitu. Ta właściwość przesuwa tylko pierwszą linię względem lewego marginesu akapitu. Dodatnia wartość przesuwa pierwszą linię w prawo, natomiast pozostałe linie pozostają wyrównane do ciała akapitu.

Użyj [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) , gdy potrzebujesz przesunąć cały akapit. Użyj [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) , gdy chcesz przesunąć tylko pierwszą linię.

Poniższy przykład tworzy kilka akapitów i stosuje różne wartości `Indent`, aby pokazać, jak wcięcie pierwszej linii wpływa na układ akapitu.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu.
4. Dodaj pustą [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz kilka akapitów i ustaw dla nich różne wartości [Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) .
6. Dodaj akapity do ramki tekstowej.
7. Zapisz zmodyfikowaną prezentację.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "No first-line indent. Wrapped lines start at the same position as the first line.";
    firstParagraph.ParagraphFormat.MarginLeft = 20f;
    firstParagraph.ParagraphFormat.Indent = 0f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.";
    secondParagraph.ParagraphFormat.MarginLeft = 20f;
    secondParagraph.ParagraphFormat.Indent = 20f;

    Paragraph thirdParagraph = new Paragraph();
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    thirdParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    thirdParagraph.Text = "First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.";
    thirdParagraph.ParagraphFormat.MarginLeft = 20f;
    thirdParagraph.ParagraphFormat.Indent = 40f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);
    textFrame.Paragraphs.Add(thirdParagraph);

    presentation.Save("paragraph_indent.pptx", SaveFormat.Pptx);
}
```

![Wcięcie pierwszej linii akapitów](first_line_indent.png)

## **Ustawianie wcięcia zwisającego dla akapitu**

Wcięcie zwisające to układ akapitu, w którym pierwsza linia zaczyna się po lewej stronie pozostałych linii. W Aspose.Slides tworzysz ten efekt za pomocą właściwości [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/). Ustaw `Indent` na ujemną wartość, aby przesunąć pierwszą linię w lewo względem ciała akapitu.

W praktyce [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) definiuje lewą pozycję ciała akapitu, a [IParagraphFormat.Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) określa pozycję pierwszej linii względem tego marginesu. Aby uzyskać wcięcie zwisające, ustaw dodatnią wartość `MarginLeft` i ujemną wartość `Indent`.

Takie formatowanie jest przydatne w bibliografiach, odniesieniach, hasłach słownika oraz innych akapitach, w których wiersze łamane muszą być wyrównane pod ciałem akapitu, a nie pod pierwszym znakiem pierwszej linii.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Uzyskaj dostęp do docelowego slajdu.
3. Dodaj prostokątną [AutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu.
4. Dodaj pustą [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) do kształtu i usuń domyślny akapit.
5. Utwórz akapity i ustaw dodatnią wartość [MarginLeft](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/marginleft/) dla każdego akapitu.
6. Ustaw ujemną wartość [Indent](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraphformat/indent/) aby uzyskać efekt wcięcia zwisającego.
7. Dodaj akapity do ramki tekstowej.
8. Zapisz zmodyfikowaną prezentację.

```cs
using (Presentation presentation = new Presentation())
{
    ISlide slide = presentation.Slides[0];

    IAutoShape rectangleShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 220);
    rectangleShape.FillFormat.FillType = FillType.NoFill;
    rectangleShape.LineFormat.FillFormat.FillType = FillType.Solid;
    rectangleShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Gray;

    ITextFrame textFrame = rectangleShape.AddTextFrame(string.Empty);
    textFrame.TextFrameFormat.AutofitType = TextAutofitType.Shape;
    textFrame.Paragraphs.RemoveAt(0);

    Paragraph firstParagraph = new Paragraph();
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    firstParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    firstParagraph.Text = "A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.";
    firstParagraph.ParagraphFormat.MarginLeft = 40f;
    firstParagraph.ParagraphFormat.Indent = -20f;

    Paragraph secondParagraph = new Paragraph();
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    secondParagraph.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    secondParagraph.Text = "This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.";
    secondParagraph.ParagraphFormat.MarginLeft = 60f;
    secondParagraph.ParagraphFormat.Indent = -30f;

    textFrame.Paragraphs.Add(firstParagraph);
    textFrame.Paragraphs.Add(secondParagraph);

    presentation.Save("hanging_indent.pptx", SaveFormat.Pptx);
}
```

![Wcięcie zwisające akapitów](hanging_indent.png)

## **Zarządzanie właściwościami końcowymi akapitu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do slajdu zawierającego akapit za pomocą jego pozycji.
3. Dodaj prostokątny [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu.
4. Dodaj [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) z dwoma akapitami do prostokąta.
5. Ustaw `FontHeight` oraz typ czcionki dla akapitów.
6. Ustaw właściwości End dla akapitów.
7. Zapisz zmodyfikowaną prezentację jako plik PPTX.

```c#
using (Presentation pres = new Presentation("Test.pptx"))
{
	IAutoShape shape = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 200, 250);

	Paragraph para1 = new Paragraph();
	para1.Portions.Add(new Portion("Sample text"));

	Paragraph para2 = new Paragraph();
	para2.Portions.Add(new Portion("Sample text 2"));
	PortionFormat endParagraphPortionFormat = new PortionFormat();
	endParagraphPortionFormat.FontHeight = 48;
	endParagraphPortionFormat.LatinFont = new FontData("Times New Roman");
	para2.EndParagraphPortionFormat = endParagraphPortionFormat;

	shape.TextFrame.Paragraphs.Add(para1);
	shape.TextFrame.Paragraphs.Add(para2);

	pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **Importowanie tekstu HTML do akapitów**

Aspose.Slides zapewnia rozszerzone wsparcie przy importowaniu tekstu HTML do akapitów.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) .
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Dodaj [autoshape](https://reference.aspose.com/slides/pl/net/aspose.slides/autoshape/) do slajdu.
4. Dodaj i uzyskaj dostęp do [ITextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/itextframe/) autoshape.
5. Usuń domyślny akapit w `ITextFrame`.
6. Odczytaj źródłowy plik HTML przy użyciu TextReader.
7. Utwórz pierwszą instancję akapitu przy użyciu klasy [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraph/) .
8. Dodaj zawartość pliku HTML odczytaną przez TextReader do [ParagraphCollection](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphcollection/) ramki tekstowej.
9. Zapisz zmodyfikowaną prezentację.

```c#
// Tworzy pustą instancję prezentacji
using (Presentation pres = new Presentation())
{
    // Uzyskuje dostęp do domyślnego pierwszego slajdu prezentacji
    ISlide slide = pres.Slides[0];

    // Dodaje AutoShape, aby pomieścić treść HTML
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Dodaje ramkę tekstową do kształtu
    ashape.AddTextFrame("");

    // Czyści wszystkie akapity w dodanej ramce tekstowej
    ashape.TextFrame.Paragraphs.Clear();

    // Wczytuje plik HTML przy użyciu StreamReader
    TextReader tr = new StreamReader("file.html");

    // Dodaje tekst z czytnika strumienia HTML do ramki tekstowej
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Zapisuje prezentację
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Eksportowanie tekstu akapitu do HTML**

Aspose.Slides zapewnia rozszerzone wsparcie przy eksportowaniu tekstów (zawartych w akapitach) do HTML.

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation) i wczytaj żądaną prezentację.
2. Uzyskaj odwołanie do odpowiedniego slajdu za pomocą jego indeksu.
3. Uzyskaj dostęp do kształtu zawierającego tekst, który ma zostać wyeksportowany do HTML.
4. Uzyskaj dostęp do [TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/textframe/) kształtu.
5. Utwórz instancję `StreamWriter` i dodaj nowy plik HTML.
6. Podaj początkowy indeks do StreamWriter i wyeksportuj wybrane akapity.

```c#
// Ładuje plik prezentacji
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Uzyskuje dostęp do domyślnego pierwszego slajdu prezentacji
    ISlide slide = pres.Slides[0];

    // Uzyskuje dostęp do wymaganego indeksu
    int index = 0;

    // Uzyskuje dostęp do dodanego kształtu
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Zapisuje dane akapitów do HTML, określając indeks początkowy akapitu i liczbę akapitów do skopiowania
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Zapis akapitu jako obrazu**

W tej sekcji przedstawimy dwa przykłady pokazujące, jak zapisać akapit tekstowy, reprezentowany przez interfejs [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/) jako obraz. Oba przykłady obejmują uzyskanie obrazu kształtu zawierającego akapit przy użyciu metod `GetImage` z interfejsu [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) , obliczenie granic akapitu w kształcie oraz wyeksportowanie go jako obrazu bitmapowego. Te podejścia umożliwiają wyodrębnienie konkretnych części tekstu z prezentacji PowerPoint i zapisanie ich jako oddzielnych obrazów, co może być przydatne w różnych scenariuszach.

Załóżmy, że mamy plik prezentacji o nazwie sample.pptx z jednym slajdem, gdzie pierwszy kształt jest polem tekstowym zawierającym trzy akapity.

![Pole tekstowe z trzema akapitami](paragraph_to_image_input.png)

**Przykład 1**

W tym przykładzie uzyskujemy drugi akapit jako obraz. W tym celu wyodrębniamy obraz kształtu z pierwszego slajdu prezentacji, a następnie obliczamy granice drugiego akapitu w ramce tekstowej kształtu. Akapit jest następnie rysowany na nowym obrazie bitmapowym, który jest zapisywany w formacie PNG. Metoda ta jest szczególnie przydatna, gdy trzeba zapisać konkretny akapit jako oddzielny obraz, zachowując dokładne wymiary i formatowanie tekstu.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Zapisz kształt w pamięci jako bitmapę.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Utwórz bitmapę kształtu z pamięci.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Oblicz granice drugiego akapitu.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Oblicz rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Przygotuj bitmapę dla akapitu.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Przerysuj akapit z bitmapy kształtu na bitmapę akapitu.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

![Obraz akapitu](paragraph_to_image_output.png)

**Przykład 2**

W tym przykładzie rozszerzamy poprzednie podejście, dodając współczynniki skalowania do obrazu akapitu. Kształt jest wyodrębniany z prezentacji i zapisywany jako obraz ze współczynnikiem skalowania `2`. Pozwala to uzyskać wyjście o wyższej rozdzielczości przy eksportowaniu akapitu. Granice akapitu są następnie obliczane z uwzględnieniem skali. Skalowanie może być szczególnie przydatne, gdy potrzebny jest bardziej szczegółowy obraz, np. do użycia w wysokiej jakości materiałach drukowanych.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Zapisz kształt w pamięci jako bitmapę ze skalowaniem.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Utwórz bitmapę kształtu z pamięci.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Oblicz granice drugiego akapitu.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Oblicz rozmiar obrazu wyjściowego (minimalny rozmiar - 1x1 piksel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Przygotuj bitmapę dla akapitu.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Przerysuj akapit z bitmapy kształtu na bitmapę akapitu.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **FAQ**

**Czy mogę całkowicie wyłączyć łamanie linii wewnątrz ramki tekstowej?**

Tak. Użyj ustawienia zawijania ramki tekstowej ([WrapText](https://reference.aspose.com/slides/pl/net/aspose.slides/textframeformat/wraptext/)), aby wyłączyć zawijanie, dzięki czemu linie nie będą łamane przy krawędziach ramki.

**Jak mogę uzyskać dokładne granice konkretnego akapitu na slajdzie?**

Możesz pobrać prostokąt ograniczający akapit (a nawet pojedynczy fragment), aby poznać jego dokładną pozycję i rozmiar na slajdzie.

**Gdzie kontrolowane jest wyrównanie akapitu (lewo/prawo/środek/wyjustowanie)?**

[Alignment](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphformat/alignment/) jest ustawieniem na poziomie akapitu w [ParagraphFormat](https://reference.aspose.com/slides/pl/net/aspose.slides/paragraphformat/); ma zastosowanie do całego akapitu, niezależnie od formatowania poszczególnych fragmentów.

**Czy mogę ustawić język sprawdzania pisowni tylko dla części akapitu (np. jednego słowa)?**

Tak. Język jest ustawiany na poziomie fragmentu ([PortionFormat.LanguageId](https://reference.aspose.com/slides/pl/net/aspose.slides/baseportionformat/languageid/)), dzięki czemu w jednym akapicie mogą współistnieć różne języki.