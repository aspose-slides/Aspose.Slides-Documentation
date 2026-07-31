---
title: Hantera PowerPoint‑textstycken i .NET
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
- lägga till text
- lägga till stycke
- hantera text
- hantera stycke
- hantera punkt
- styckeindrag
- hängande indrag
- styckepunkt
- numrerad lista
- punktlista
- styckegenskaper
- importera HTML
- text till HTML
- stycke till HTML
- stycke till bild
- text till bild
- exportera stycke
- PowerPoint
- presentation
- .NET
- C#
- Aspose.Slides
description: "Behärska styckeformatering med Aspose.Slides för .NET—optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer i C#."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla gränssnitt och klasser du behöver för att arbeta med PowerPoint‑texter, stycken och delar i C#.

* Aspose.Slides tillhandahåller gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/) för att låta dig lägga till objekt som representerar ett stycke. Ett `ITextFame`‑objekt kan ha ett eller flera stycken (varje stycke skapas genom ett radbrytningstecken).
* Aspose.Slides tillhandahåller gränssnittet [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/) för att låta dig lägga till objekt som representerar delar. Ett `IParagraph`‑objekt kan ha en eller flera delar (samling av iPortions‑objekt).
* Aspose.Slides tillhandahåller gränssnittet [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/) för att låta dig lägga till objekt som representerar texter och deras formateringsegenskaper. 

Ett `IParagraph`‑objekt kan hantera texter med olika formateringsegenskaper via sina underliggande `IPortion`‑objekt.

## **Lägg till flera stycken som innehåller flera delar**

Dessa steg visar hur du lägger till en textruta som innehåller 3 stycken och varje stycke innehåller 3 delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Kom åt den relevanta bildens referens via dess index.
3. Lägg till en rektangel‑[IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Hämta ITextFrame som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).
5. Skapa två [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/)‑objekt och lägg till dem i samlingen `IParagraphs` för [ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/).
6. Skapa tre [IPortion](https://reference.aspose.com/slides/sv/net/aspose.slides/iportion/)‑objekt för varje nytt `IParagraph` (två Portion‑objekt för standardstycke) och lägg varje `IPortion`‑objekt i IPortion‑samlingen för respektive `IParagraph`.
7. Sätt någon text för varje del.
8. Applicera dina föredragna formateringsfunktioner på varje del med hjälp av formaterings­egenskaperna i `IPortion`‑objektet.
9. Spara den modifierade presentationen.

Denna C#‑kod är en implementering av stegen för att lägga till stycken som innehåller delar:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 using (Presentation pres = new Presentation())
 {
     // Kom åt den första bilden
     ISlide slide = pres.Slides[0];

     // Lägger till en rektangel IAutoShape
     IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

     // Kom åt AutoShape TextFrame
     ITextFrame tf = ashp.TextFrame;

     // Skapar stycken och delar med olika textformat
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
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.FillType = FillType.Solid;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FillFormat.SolidFillColor.Color = Color.Blue;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontItalic = NullableBool.True;
                 tf.Paragraphs[i].Portions[j].PortionFormat.FontHeight = 18;
             }
         }
     // Sparar den modifierade presentationen
     pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```


## **Hantera styckespunkter**
Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Punkterade stycken är alltid lättare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Kom åt den relevanta bildens referens via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på den valda bilden.
4. Kom åt autoshapens [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/).
8. Ställ in punktens `Type` för stycket till `Symbol` och ange punkttecknet.
9. Ställ in styckets `Text`.
10. Ställ in styckets `Indent` för punkten.
11. Ange en färg för punkten.
12. Ange en höjd för punkten.
13. Lägg till det nya stycket i `TextFrame`‑samlingen för stycken.
14. Lägg till det andra stycket och upprepa processen som beskrivs i steg 7‑13.
15. Spara presentationen.

Denna C#‑kod visar hur du lägger till en punkt i ett stycke:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 using (Presentation pres = new Presentation())
 {
 
     // Kom åt den första bilden
     ISlide slide = pres.Slides[0];
 
 
     // Lägger till och kommer åt Autoshape
     IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
 
     // Kom åt autoshapens textruta
     ITextFrame txtFrm = aShp.TextFrame;
 
     // Tar bort standardstycket
     txtFrm.Paragraphs.RemoveAt(0);
 
     // Skapar ett stycke
     Paragraph para = new Paragraph();
 
     // Anger ett styckespunkstil och -symbol
     para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
 
     // Anger stycketext
     para.Text = "Welcome to Aspose.Slides";
 
     // Anger punktindrag
     para.ParagraphFormat.Indent = 25;
 
     // Anger punktfärg
     para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
     para.ParagraphFormat.Bullet.Color.Color = Color.Black;
     para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // sätt IsBulletHardColor till true för att använda egen punktfärg
 
     // Anger punktens höjd
     para.ParagraphFormat.Bullet.Height = 100;
 
     // Lägger till stycke i textrutan
     txtFrm.Paragraphs.Add(para);
 
     // Skapar andra stycket
     Paragraph para2 = new Paragraph();
 
     // Anger stycke punkt typ och stil
     para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
     para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;
 
     // Lägger till stycketext
     para2.Text = "This is numbered bullet";
 
     // Anger punktindrag
     para2.ParagraphFormat.Indent = 25;
 
     para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
     para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
     para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // sätt IsBulletHardColor till true för att använda egen punktfärg
 
     // Anger punktens höjd
     para2.ParagraphFormat.Bullet.Height = 100;
 
     // Lägger till stycke i textrutan
     txtFrm.Paragraphs.Add(para2);
 
 
     // Sparar den modifierade presentationen
     pres.Save("Bullet_out.pptx", SaveFormat.Pptx);
 
 }
```


## **Hantera bildpunkter**
Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Bildstycken är enkla att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Kom åt den relevanta bildens referens via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Kom åt autoshapens [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/).
7. Läs in bilden i [IPPImage](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/).
8. Ställ in punktens typ till [Picture](https://reference.aspose.com/slides/sv/net/aspose.slides/ippimage/) och ange bilden.
9. Ställ in styckets `Text`.
10. Ställ in styckets `Indent` för punkten.
11. Ange en färg för punkten.
12. Ange en höjd för punkten.
13. Lägg till det nya stycket i `TextFrame`‑samlingen för stycken.
14. Lägg till det andra stycket och upprepa processen baserat på de föregående stegen.
15. Spara den modifierade presentationen.

Denna C#‑kod visar hur du lägger till och hanterar bildpunkter:

```c#
// Instansierar en Presentation-klass som representerar en PPTX-fil
Presentation presentation = new Presentation();

// Kom åt den första bilden
ISlide slide = presentation.Slides[0];

// Instansierar bilden för punkter
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Lägger till och kommer åt Autoshape
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Kom åt autoshapens textruta
ITextFrame textFrame = autoShape.TextFrame;

// Tar bort standardstycket
textFrame.Paragraphs.RemoveAt(0);

// Skapar ett nytt stycke
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Anger styckespunktsstil och bild
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Anger punktens höjd
paragraph.ParagraphFormat.Bullet.Height = 100;

// Lägger till stycke i textrutan
textFrame.Paragraphs.Add(paragraph);

// Skriver presentationen som en PPTX-fil
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Skriver presentationen som en PPT-fil
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```


## **Hantera flernivåpunkter**
Punktlistor hjälper dig att organisera och presentera information snabbt och effektivt. Flernivåpunkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klass.
2. Kom åt den relevanta bildens referens via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på den nya bilden.
4. Kom åt autoshapens [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa den andra stycke‑instansen med `Paragraph`‑klassen och sätt djupet till 1.
8. Skapa den tredje stycke‑instansen med `Paragraph`‑klassen och sätt djupet till 2.
9. Skapa den fjärde stycke‑instansen med `Paragraph`‑klassen och sätt djupet till 3.
10. Lägg till de nya styckena i `TextFrame`‑samlingen för stycken.
11. Spara den modifierade presentationen.

Denna C#‑kod visar hur du lägger till och hanterar flernivåpunkter:

```c#
 // Instansierar en Presentation-klass som representerar en PPTX-fil
 using (Presentation pres = new Presentation())
 {
 
     // Kom åt den första bilden
     ISlide slide = pres.Slides[0];
     
     // Lägger till och kommer åt Autoshape
     IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);
 
     // Kom åt textramen för den skapade autoshapen
     ITextFrame text = aShp.AddTextFrame("");
     
     // Rensar standardstycket
     text.Paragraphs.Clear();
 
     // Lägger till det första stycket
     IParagraph para1 = new Paragraph();
     para1.Text = "Content";
     para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
     para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Anger punktnivå
     para1.ParagraphFormat.Depth = 0;
 
     // Lägger till det andra stycket
     IParagraph para2 = new Paragraph();
     para2.Text = "Second Level";
     para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para2.ParagraphFormat.Bullet.Char = '-';
     para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Anger punktnivå
     para2.ParagraphFormat.Depth = 1;
 
     // Lägger till det tredje stycket
     IParagraph para3 = new Paragraph();
     para3.Text = "Third Level";
     para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
     para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Anger punktnivå
     para3.ParagraphFormat.Depth = 2;
 
     // Lägger till det fjärde stycket
     IParagraph para4 = new Paragraph();
     para4.Text = "Fourth Level";
     para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
     para4.ParagraphFormat.Bullet.Char = '-';
     para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
     para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
     // Anger punktnivå
     para4.ParagraphFormat.Depth = 3;
 
     // Lägger till stycken i samlingen
     text.Paragraphs.Add(para1);
     text.Paragraphs.Add(para2);
     text.Paragraphs.Add(para3);
     text.Paragraphs.Add(para4);
 
     // Skriver presentationen som en PPTX-fil
     pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
 }
```


## **Hantera ett stycke med en anpassad numrerad lista**
Gränssnittet [IBulletFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/) tillhandahåller egenskapen [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/numberedbulletstartwith) och andra som låter dig hantera stycken med anpassad numrering eller formatering. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation)klass.
2. Kom åt bilden som innehåller stycket.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/iautoshape/) på bilden.
4. Kom åt autoshapens [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/).
5. Ta bort standardstycket i `TextFrame`.
6. Skapa den första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/) och sätt [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/net/aspose.slides/ibulletformat/numberedbulletstartwith) till 2.
7. Skapa den andra stycke‑instansen med `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 3.
8. Skapa den tredje stycke‑instansen med `Paragraph`‑klassen och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya styckena i `TextFrame`‑samlingen för stycken.
10. Spara den modifierade presentationen.

Denna C#‑kod visar hur du lägger till och hanterar stycken med anpassad numrering eller formatering:

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Kom åt textramen för den skapade autoshapen
	ITextFrame textFrame = shape.TextFrame;

	// Tar bort standardstycket som finns
	textFrame.Paragraphs.RemoveAt(0);

	// Första listan
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

## **Ställ in första radens indrag för ett stycke**

Använd egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) för att kontrollera första radens indrag i ett stycke. Denna egenskap flyttar bara den första raden i förhållande till styckets vänstra marginal. Ett positivt värde förskjuter den första raden åt höger, medan de återstående raderna förblir justerade med styckets kropp.

Använd [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/) när du behöver flytta hela stycket. Använd [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika `Indent`‑värden för att demonstrera hur första radens indrag påverkar styckeslayouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
2. Kom åt målbiten.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) i formen och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/)‑värden för dem.
6. Lägg till styckena i textrutan.
7. Spara den modifierade presentationen.

Denna kod visar hur du ställer in ett styckeindrag:

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

Resultatet:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

Ett hängande indrag är en styckeslayout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med egenskapen [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/). Sätt `Indent` till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/) den vänstra positionen för styckets kropp, och [IParagraphFormat.Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/) definierar positionen för den första raden relativt den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, glosor och andra stycken där radbrytningar ska justeras under styckets kropp snarare än under den första tecknet i den första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation/) .
2. Kom åt målbiten.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) i formen och ta bort standardstycket.
5. Skapa stycken och sätt ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/marginleft/)‑värde för varje stycke.
6. Sätt ett negativt [Indent](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraphformat/indent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textrutan.
8. Spara den modifierade presentationen.

Denna kod visar hur du ställer in ett hängande indrag för ett stycke:

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

Resultatet:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Hantera slutliga körningsegenskaper för stycke**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) klass.
1. Hämta referensen för bilden som innehåller stycket via dess position.
1. Lägg till en rektangulär [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden.
1. Lägg till en [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/) med två stycken till rektangeln.
1. Ställ in `FontHeight` och teckensnittstyp för styckena.
1. Ställ in slutliga egenskaper för styckena.
1. Skriv den modifierade presentationen som en PPTX‑fil.

Denna C#‑kod visar hur du ställer in slutliga egenskaper för stycken i PowerPoint:

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


## **Importera HTML‑text i stycken**
Aspose.Slides erbjuder förbättrat stöd för att importera HTML‑text i stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation).
2. Kom åt den relevanta bildens referens via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/net/aspose.slides/autoshape/) på bilden.
4. Lägg till och kom åt `autoshape`‑[ITextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/itextframe/).
5. Ta bort standardstycket i `ITextFrame`.
6. Läs in käll‑HTML‑filen i en TextReader.
7. Skapa den första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll i den lästa TextReadern till TextFrames [ParagraphCollection](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphcollection/).
9. Spara den modifierade presentationen.

Denna C#‑kod är en implementering av stegen för att importera HTML‑texter i stycken:

```c#
// Skapar tom presentationsinstans
using (Presentation pres = new Presentation())
{
    // Kommer åt standardförsta bilden i presentationen
    ISlide slide = pres.Slides[0];

    // Lägger till AutoShape för att rymma HTML-innehållet
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Lägger till textruta till formen
    ashape.AddTextFrame("");

    // Rensar alla stycken i den tillagda textrutan
    ashape.TextFrame.Paragraphs.Clear();

    // Laddar HTML-filen med en StreamReader
    TextReader tr = new StreamReader("file.html");

    // Lägger till texten från HTML-strömmen i textrutan
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Sparar presentationen
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Exportera stycke‑text till HTML**
Aspose.Slides erbjuder förbättrat stöd för att exportera texter (som finns i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/net/aspose.slides/presentation) och ladda den önskade presentationen.
2. Kom åt den relevanta bildens referens via dess index.
3. Kom åt formen som innehåller texten som ska exporteras till HTML.
4. Kom åt formens [TextFrame](https://reference.aspose.com/slides/sv/net/aspose.slides/textframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett start‑index till StreamWriter och exportera dina föredragna stycken.

Denna C#‑kod visar hur du exporterar PowerPoint‑stycke‑texter till HTML:

```c#
// Laddar presentationsfilen
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Kommer åt standardförsta bilden i presentationen
    ISlide slide = pres.Slides[0];

    // Hämtar det nödvändiga indexet
    int index = 0;

    // Kommer åt den tillagda formen
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Skriver stycke-data till HTML genom att ange startindex för stycket och antalet stycken som ska kopieras
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Spara ett stycke som bild**

I detta avsnitt utforskar vi två exempel som demonstrerar hur man sparar ett textstycke, representerat av gränssnittet [IParagraph](https://reference.aspose.com/slides/sv/net/aspose.slides/iparagraph/), som en bild. Båda exemplen inkluderar att hämta bilden av en form som innehåller stycket via `GetImage`‑metoderna i gränssnittet [IShape](https://reference.aspose.com/slides/sv/net/aspose.slides/ishape/), beräkna styckets gränser i formen och exportera det som en bitmap‑bild. Dessa metoder låter dig extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenarier.

Låt oss anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Exempel 1**

I detta exempel hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bildens form från den första sliden i presentationen och beräknar sedan gränserna för det andra stycket i formens textruta. Stycket ritas sedan om på en ny bitmap‑bild, som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar exakt dimension och formatering.

```csharp
using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap.
using var shapeImage = firstShape.GetImage();
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

Resultatet:

![The paragraph image](paragraph_to_image_output.png)

**Exempel 2**

I detta exempel bygger vi vidare på föregående metod genom att lägga till skalningsfaktorer till styckebilden. Formen extraheras från presentationen och sparas som en bild med en skalfaktor på `2`. Detta möjliggör en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalningen. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, exempelvis för tryckt material av hög kvalitet.

```csharp
var imageScaleX = 2f;
var imageScaleY = imageScaleX;

using var presentation = new Presentation("sample.pptx");
var firstShape = presentation.Slides[0].Shapes[0] as IAutoShape;

// Save the shape in memory as a bitmap with scaling.
using var shapeImage = firstShape.GetImage(ShapeThumbnailBounds.Shape, imageScaleX, imageScaleY);
using var shapeImageStream = new MemoryStream();
shapeImage.Save(shapeImageStream, ImageFormat.Png);

// Create a shape bitmap from memory.
shapeImageStream.Seek(0, SeekOrigin.Begin);
using var shapeBitmap = Image.FromStream(shapeImageStream);

// Calculate the boundaries of the second paragraph.
var secondParagraph = firstShape.TextFrame.Paragraphs[1];
var paragraphRectangle = secondParagraph.GetRect();
paragraphRectangle.X *= imageScaleX;
paragraphRectangle.Y *= imageScaleY;
paragraphRectangle.Width *= imageScaleX;
paragraphRectangle.Height *= imageScaleY;

// Calculate the size for the output image (minimum size - 1x1 pixel).
var imageWidth = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Width));
var imageHeight = Math.Max(1, (int)Math.Ceiling(paragraphRectangle.Height));

// Prepare a bitmap for the paragraph.
using var paragraphBitmap = new Bitmap(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
using var imageGraphics = Graphics.FromImage(paragraphBitmap);
var drawingRectangle = new RectangleF(0, 0, paragraphRectangle.Width, paragraphRectangle.Height);
imageGraphics.DrawImage(shapeBitmap, drawingRectangle, paragraphRectangle, GraphicsUnit.Pixel);

paragraphBitmap.Save("paragraph.png", System.Drawing.Imaging.ImageFormat.Png);
```

## **Vanliga frågor**

**Kan jag helt inaktivera radbrytning i en textruta?**

Ja. Använd textrutans omslagningsinställning ([WrapText](https://reference.aspose.com/slides/sv/net/aspose.slides/textframeformat/wraptext/)) för att stänga av omslag så att rader inte bryts vid rutans kanter.

**Hur får jag exakt position för ett specifikt stycke på bilden?**

Du kan hämta styckets (och även ett enskilt portions) avgränsningsrektangel för att veta dess exakta position och storlek på sliden.

**Var styrs styckejustering (vänster/höger/centrerat/justerat)?**

[Alignment](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphformat/alignment/) är en inställning på styckesnivå i [ParagraphFormat](https://reference.aspose.com/slides/sv/net/aspose.slides/paragraphformat/); den gäller hela stycket oavsett individuell portionsformatering.

**Kan jag ange stavningsspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket sätts på portionsnivå ([PortionFormat.LanguageId](https://reference.aspose.com/slides/sv/net/aspose.slides/baseportionformat/languageid/)), så flera språk kan samexistera i samma stycke.