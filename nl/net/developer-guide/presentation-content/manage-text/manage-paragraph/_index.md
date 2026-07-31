---
title: Beheer PowerPoint-tekstalinea's in .NET
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/net/manage-paragraph/
aliases:
  - /net/paragraph/
  - /net/portion/
keywords:
  - tekst toevoegen
  - alinea toevoegen
  - tekst beheren
  - alinea beheren
  - opsommingstekens beheren
  - alinea-insprong
  - hangende insprong
  - alinea-opsommingsteken
  - genummerde lijst
  - opsommingslijst
  - alinea-eigenschappen
  - HTML importeren
  - tekst naar HTML
  - alinea naar HTML
  - alinea naar afbeelding
  - tekst naar afbeelding
  - alinea exporteren
  - PowerPoint
  - presentatie
  - .NET
  - C#
  - Aspose.Slides
description: "Beheers alinea-opmaak met Aspose.Slides voor .NET—optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP-presentaties in C#."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig heeft om met PowerPoint-teksten, alinea’s en fragmenten te werken in C#.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) interface waarmee u objecten kunt toevoegen die een alinea vertegenwoordigen. Een `ITextFame` object kan één of meerdere alinea’s hebben (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) interface waarmee u objecten kunt toevoegen die fragmenten vertegenwoordigen. Een `IParagraph` object kan één of meerdere fragmenten hebben (een verzameling iPortions‑objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/) interface waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `IParagraph` object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion`‑objecten.

## **Meerdere alinea’s toevoegen die meerdere fragmenten bevatten**

Deze stappen laten zien hoe u een tekstkader toevoegt dat 3 alinea’s bevat en waarbij elke alinea 3 fragmenten bevat:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het ITextFrame dat bij de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) hoort.
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) objecten aan en voeg ze toe aan de `IParagraphs`‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/) objecten voor elke nieuwe `IParagraph` (twee Portion‑objecten voor de standaard alinea) en voeg elk `IPortion` object toe aan de IPortion‑collectie van elke `IParagraph`.
7. Stel tekst in voor elk fragment.
8. Pas uw gewenste opmaakopties toe op elk fragment via de opmaak‑eigenschappen van het `IPortion`‑object.
9. Sla de aangepaste presentatie op.

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{
    // Verkrijgt de eerste dia
    ISlide slide = pres.Slides[0];

    // Voegt een rechthoekige IAutoShape toe
    IAutoShape ashp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 150, 300, 150);

    // Verkrijgt het TextFrame van de AutoShape
    ITextFrame tf = ashp.TextFrame;

    // Creëert alinea's en fragmenten met verschillende tekstformaten
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
    // Slaat de gewijzigde presentatie op
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);

}
```

## **Opsommingstekens van alinea beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan met de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
8. Stel het bullet‑`Type` van de alinea in op `Symbol` en bepaal het bullet‑teken.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal de stappen 7 tot 13.
15. Sla de presentatie op.

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Verkiijkt de eerste dia
    ISlide slide = pres.Slides[0];


    // Voegt een Autoshape toe en krijgt toegang tot deze
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Verkrijgt het tekstkader van de autoshape
    ITextFrame txtFrm = aShp.TextFrame;

    // Verwijdert de standaard alinea
    txtFrm.Paragraphs.RemoveAt(0);

    // Maakt een alinea aan
    Paragraph para = new Paragraph();

    // Stelt het bullet-type en -symbool van de alinea in
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Stelt de alinea-tekst in
    para.Text = "Welcome to Aspose.Slides";

    // Stelt de bullet-insprong in
    para.ParagraphFormat.Indent = 25;

    // Stelt de bullet-kleur in
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // stel IsBulletHardColor in op true om je eigen bullet-kleur te gebruiken

    // Stelt de bullet-hoogte in
    para.ParagraphFormat.Bullet.Height = 100;

    // Voeg de alinea toe aan het tekstkader
    txtFrm.Paragraphs.Add(para);

    // Maakt een tweede alinea aan
    Paragraph para2 = new Paragraph();

    // Stelt het bullet-type en de stijl van de alinea in
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Voegt de alinea-tekst toe
    para2.Text = "This is numbered bullet";

    // Stelt de bullet-insprong in
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // stel IsBulletHardColor in op true om je eigen bullet-kleur te gebruiken

    // Stelt de bullet-hoogte in
    para2.ParagraphFormat.Bullet.Height = 100;

    // Voeg de alinea toe aan het tekstkader
    txtFrm.Paragraphs.Add(para2);


    // Slaat de gewijzigde presentatie op
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Afbeeldings‑opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea’s met afbeeldingen zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan met de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) en stel de afbeelding in.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Stel een kleur in voor de bullet.
12. Stel een hoogte in voor de bullet.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de vorige stappen.
15. Sla de aangepaste presentatie op.

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation();

// Verkrijgt de eerste dia
ISlide slide = presentation.Slides[0];

// Instantieert de afbeelding voor opsommingstekens
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Voegt een Autoshape toe en krijgt toegang tot deze
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Verkrijgt het tekstkader van de autoshape
ITextFrame textFrame = autoShape.TextFrame;

// Verwijdert de standaard alinea
textFrame.Paragraphs.RemoveAt(0);

// Maakt een nieuwe alinea aan
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Stelt de bullet-stijl en afbeelding van de alinea in
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Stelt de bullet-hoogte in
paragraph.ParagraphFormat.Bullet.Height = 100;

// Voegt de alinea toe aan het tekstkader
textFrame.Paragraphs.Add(paragraph);

// Schrijft de presentatie weg als een PPTX-bestand
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Schrijft de presentatie weg als een PPT-bestand
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Meerdere niveaus voor opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Opsommingstekens met meerdere niveaus zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de nieuwe dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie aan via de `Paragraph`‑klasse en stel de diepte in op 1.
8. Maak de derde alinea‑instantie aan via de `Paragraph`‑klasse en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie aan via de `Paragraph`‑klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de aangepaste presentatie op.

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Verkrijgt de eerste dia
    ISlide slide = pres.Slides[0];
    
    // Voegt een Autoshape toe en krijgt toegang tot deze
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Verkrijgt het tekstkader van de aangemaakte autoshape
    ITextFrame text = aShp.AddTextFrame("");
    
    // Verwijdert de standaard alinea
    text.Paragraphs.Clear();

    // Voegt de eerste alinea toe
    IParagraph para1 = new Paragraph();
    para1.Text = "Content";
    para1.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para1.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para1.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het bullet-niveau in
    para1.ParagraphFormat.Depth = 0;

    // Voegt de tweede alinea toe
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het bullet-niveau in
    para2.ParagraphFormat.Depth = 1;

    // Voegt de derde alinea toe
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het bullet-niveau in
    para3.ParagraphFormat.Depth = 2;

    // Voegt de vierde alinea toe
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het bullet-niveau in
    para4.ParagraphFormat.Depth = 3;

    // Voegt alinea's toe aan de collectie
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Schrijft de presentatie weg als een PPTX-bestand
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/) interface biedt de [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith) eigenschap en andere die u in staat stellen alinea’s met aangepaste nummering of opmaak te beheren. 

1. Maak een instantie van de [Presentation ](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation)klasse.
2. Open de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie aan via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith) in op 2.
7. Maak de tweede alinea‑instantie aan via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie aan via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de aangepaste presentatie op.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Verkrijgt het tekstkader van de aangemaakte autoshape
	ITextFrame textFrame = shape.TextFrame;

	// Verwijdert de standaard bestaande alinea
	textFrame.Paragraphs.RemoveAt(0);

	// Eerste lijst
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

## **Eerste‑regels insprong instellen voor een alinea**

Gebruik de [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) eigenschap om de eerste‑regels insprong van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het voorbeeld hieronder maakt verschillende alinea’s en past verschillende `Indent`‑waarden toe om te demonstreren hoe de eerste‑regels insprong de opmaak van de alinea beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea’s aan en stel verschillende [Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) waarden in.
6. Voeg de alinea’s toe aan het tekstkader.
7. Sla de aangepaste presentatie op.

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

The result:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Hangende insprong instellen voor een alinea**

Een hangende insprong is een alinea‑indeling waarbij de eerste regel links van de resterende regels begint. In Aspose.Slides creëert u dit effect met de [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) eigenschap. Stel `Indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk definieert [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) de linkermarge van de alinea‑inhoud, en [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) definieert de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te creëren, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is handig voor bibliografieën, referenties, woordenlijst‑items en andere alinea’s waarbij de gewikkelde regels onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea’s aan en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) waarde in om het hangende effect te verkrijgen.
7. Voeg de alinea’s toe aan het tekstkader.
8. Sla de aangepaste presentatie op.

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

The result:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Einde‑alinea‑run‑eigenschappen beheren**

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Verkrijg de referentie voor de dia die de alinea bevat via de positie.
3. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) met twee alinea’s toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea’s.
6. Stel de End‑eigenschappen in voor de alinea’s.
7. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

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

## **HTML‑tekst importeren in alinea’s**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML‑tekst in alinea’s.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een `autoshape` [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) toe en open deze.
5. Verwijder de standaard alinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑instantie aan via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
8. Voeg de HTML‑bestandinhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de aangepaste presentatie op.

```c#
// Maakt een lege presentatie instantie
using (Presentation pres = new Presentation())
{
    // Verkrijgt de standaard eerste dia van de presentatie
    ISlide slide = pres.Slides[0];

    // Voegt de AutoShape toe om de HTML inhoud te huisvesten
    IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

    ashape.FillFormat.FillType = FillType.NoFill;

    // Voegt een tekstframe toe aan de vorm
    ashape.AddTextFrame("");

    // Verwijdert alle alinea's in het toegevoegde tekstframe
    ashape.TextFrame.Paragraphs.Clear();

    // Laadt het HTML bestand met een stream reader
    TextReader tr = new StreamReader("file.html");

    // Voegt de tekst van de HTML stream reader toe aan het tekstframe
    ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

    // Slaat de presentatie op
    pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van teksten (gehouden in alinea’s) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de gewenste presentatie.
2. Open de referentie van de betreffende dia via de index.
3. Open de vorm die de te exporteren tekst bevat.
4. Open de vorm [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/).
5. Maak een instantie van `StreamWriter` aan en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index aan StreamWriter en exporteer de door u gewenste alinea’s.

```c#
// Laadt het presentatiebestand
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Verkrijgt de standaard eerste dia van de presentatie
    ISlide slide = pres.Slides[0];

    // Verkrijgt de vereiste  index
    int index = 0;

    // Verkrijgt de toegevoegde vorm
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Schrijft alinea‑gegevens naar HTML door de start‑index van de alinea en het aantal te kopiëren alinea’s op te geven
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Een alinea opslaan als afbeelding**

In deze sectie bekijken we twee voorbeelden die laten zien hoe u een tekstalinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) interface, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `GetImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren daarvan als bitmap‑afbeelding. Deze benaderingen stellen u in staat om specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en op te slaan als afzonderlijke afbeeldingen, wat nuttig kan zijn voor verder gebruik in verschillende scenario’s.

Laten we aannemen dat we een presentatiebestand hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea’s bevat.

![Het tekstvak met drie alinea’s](paragraph_to_image_input.png)

**Example 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Daartoe halen we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt daarna opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is bijzonder nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan, terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

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

The result:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Example 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te voegen aan de alinea‑afbeelding. De vorm wordt uit de presentatie geëxtraheerd en opgeslagen als een afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een output met hogere resolutie bij het exporteren van de alinea. De grenzen van de alinea worden vervolgens berekend met inachtneming van de schaal. Schalen kan bijzonder nuttig zijn wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige drukmaterialen.

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

## **FAQ**

**Kan ik volledig regelomslag binnen een tekstkader uitschakelen?**

Ja. Gebruik de omslaginstelling van het tekstkader ([WrapText](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/wraptext/)) om omslag uit te schakelen zodat regels niet afbreken aan de randen van het kader.

**Hoe kan ik de exacte positie van een specifieke alinea op de dia verkrijgen?**

U kunt de begrenzingsrechthoek van de alinea (en zelfs van een enkel fragment) opvragen om de precieze positie en grootte ervan op de dia te kennen.

**Waar wordt de alinea‑uitlijning (links/rechts/centreren/uitvullen) bepaald?**

[Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/alignment/) is een instelling op alinea‑niveau in [ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/); deze wordt toegepast op de hele alinea ongeacht de opmaak van individuele fragmenten.

**Kan ik een spellingscontrole‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op fragmentniveau ([PortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/languageid/)), zodat meerdere talen binnen één alinea naast elkaar kunnen bestaan.