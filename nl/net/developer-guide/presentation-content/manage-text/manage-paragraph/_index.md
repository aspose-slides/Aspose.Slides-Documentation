---
title: Beheer PowerPoint-tekstalinea's in .NET
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/net/manage-paragraph/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea-inspringing
- hangende inspringing
- alinea-opsomming
- genummerde lijst
- opsomming met opsommingstekens
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
description: "Beheers de opmaak van alinea's met Aspose.Slides voor .NET—optimaliseer uitlijning, afstand en stijl in PPT, PPTX en ODP-presentaties in C#."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig heeft om met PowerPoint-teksten, alinea's en delen te werken in C#.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) interface waarmee u objecten kunt toevoegen die een alinea vertegenwoordigen. Een `ITextFame` object kan één of meerdere alinea's hebben (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) interface waarmee u objecten kunt toevoegen die delen vertegenwoordigen. Een `IParagraph` object kan één of meerdere delen hebben (een verzameling iPortions-objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/) interface waarmee u objecten kunt toevoegen die teksten en hun opmaak‑eigenschappen vertegenwoordigen.

Een `IParagraph` object kan teksten met verschillende opmaak‑eigenschappen verwerken via de onderliggende `IPortion` objecten.

## **Meerdere alinea's met meerdere delen toevoegen**

Deze stappen laten zien hoe u een tekstkader toevoegt dat 3 alinea's bevat, en elke alinea bevat 3 delen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat geassocieerd is met de [IAutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/).
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) objecten aan en voeg ze toe aan de `IParagraphs` collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/net/aspose.slides/iportion/) objecten voor elke nieuwe `IParagraph` (twee Portion‑objecten voor de standaard alinea) en voeg elk `IPortion` object toe aan de IPortion‑collectie van elke `IParagraph`.
7. Stel wat tekst in voor elk deel.
8. Pas uw gewenste opmaakfuncties toe op elk deel via de opmaak‑eigenschappen die door het `IPortion` object worden blootgesteld.
9. Sla de gewijzigde presentatie op.

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

    // Creëert alinea's en delen met verschillende tekstopmaak
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
    // Slaat de aangepaste presentatie op
    pres.Save("multiParaPort_out.pptx", SaveFormat.Pptx);
}
```

## **Alinea opsommingstekens beheren**

Opsommingsteksten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
8. Stel het bullet `Type` voor de alinea in op `Symbol` en stel het bullet‑teken in.
9. Stel de alinea `Text` in.
10. Stel de alinea `Indent` in voor het bullet.
11. Stel een kleur in voor het bullet.
12. Stel een hoogte in voor het bullet.
13. Voeg de nieuwe alinea toe aan de `TextFrame` alinea‑collectie.
14. Voeg de tweede alinea toe en herhaal het proces zoals beschreven in stappen 7 t/m 13.
15. Sla de presentatie op.

```c#
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haalt de eerste dia op
    ISlide slide = pres.Slides[0];


    // Voegt een AutoShape toe en krijgt deze op
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Haalt het tekstkader van de AutoShape op
    ITextFrame txtFrm = aShp.TextFrame;

    // Verwijdert de standaard alinea
    txtFrm.Paragraphs.RemoveAt(0);

    // Creëert een alinea
    Paragraph para = new Paragraph();

    // Stelt de opsommingstekenstijl en symbool van de alinea in
    para.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);

    // Stelt de alinea-tekst in
    para.Text = "Welcome to Aspose.Slides";

    // Stelt de inspringing van het opsommingsteken in
    para.ParagraphFormat.Indent = 25;

    // Stelt de kleur van het opsommingsteken in
    para.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // stel IsBulletHardColor in op true om de eigen kleur van het opsommingsteken te gebruiken

    // Stelt de hoogte van het opsommingsteken in
    para.ParagraphFormat.Bullet.Height = 100;

    // Voegt de alinea toe aan het tekstkader
    txtFrm.Paragraphs.Add(para);

    // Creëert een tweede alinea
    Paragraph para2 = new Paragraph();

    // Stelt het type en de stijl van het opsommingsteken in voor de alinea
    para2.ParagraphFormat.Bullet.Type = BulletType.Numbered;
    para2.ParagraphFormat.Bullet.NumberedBulletStyle = NumberedBulletStyle.BulletCircleNumWDBlackPlain;

    // Voegt alinea-tekst toe
    para2.Text = "This is numbered bullet";

    // Stelt de inspringing van het opsommingsteken in
    para2.ParagraphFormat.Indent = 25;

    para2.ParagraphFormat.Bullet.Color.ColorType = ColorType.RGB;
    para2.ParagraphFormat.Bullet.Color.Color = Color.Black;
    para2.ParagraphFormat.Bullet.IsBulletHardColor = NullableBool.True; // stel IsBulletHardColor in op true om de eigen kleur van het opsommingsteken te gebruiken

    // Stelt de hoogte van het opsommingsteken in
    para2.ParagraphFormat.Bullet.Height = 100;

    // Voegt de alinea toe aan het tekstkader
    txtFrm.Paragraphs.Add(para2);


    // Slaat de aangepaste presentatie op
    pres.Save("Bullet_out.pptx", SaveFormat.Pptx);

}
```

## **Afbeeldings‑opsommingstekens beheren**

Opsommingsteksten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met afbeeldingen zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea aan met behulp van de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/net/aspose.slides/ippimage/) en stel de afbeelding in.
9. Stel de alinea `Text` in.
10. Stel de alinea `Indent` in voor het bullet.
11. Stel een kleur in voor het bullet.
12. Stel een hoogte in voor het bullet.
13. Voeg de nieuwe alinea toe aan de `TextFrame` alinea‑collectie.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de voorgaande stappen.
15. Sla de gewijzigde presentatie op.

```c#
// Instancieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
Presentation presentation = new Presentation();

// Haalt de eerste dia op
ISlide slide = presentation.Slides[0];

// Instancieert de afbeelding voor opsommingstekens
IImage image = Images.FromFile("bullets.png");
IPPImage ippxImage = presentation.Images.AddImage(image);
image.Dispose();

// Voegt een AutoShape toe en krijgt deze op
IAutoShape autoShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

// Haalt het tekstkader van de AutoShape op
ITextFrame textFrame = autoShape.TextFrame;

// Verwijdert de standaard alinea
textFrame.Paragraphs.RemoveAt(0);

// Creëert een nieuwe alinea
Paragraph paragraph = new Paragraph();
paragraph.Text = "Welcome to Aspose.Slides";

// Stelt de opsommingstekenstijl en afbeelding van de alinea in
paragraph.ParagraphFormat.Bullet.Type = BulletType.Picture;
paragraph.ParagraphFormat.Bullet.Picture.Image = ippxImage;

// Stelt de hoogte van het opsommingsteken in
paragraph.ParagraphFormat.Bullet.Height = 100;

// Voegt de alinea toe aan het tekstkader
textFrame.Paragraphs.Add(paragraph);

// Schrijft de presentatie weg als een PPTX-bestand
presentation.Save("ParagraphPictureBulletsPPTX_out.pptx", SaveFormat.Pptx);

// Schrijft de presentatie weg als een PPT-bestand
presentation.Save("ParagraphPictureBulletsPPT_out.ppt", SaveFormat.Ppt);
```

## **Meerlagige opsommingstekens beheren**

Opsommingsteksten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe in de nieuwe dia.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de autoshape.
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea via de `Paragraph` klasse en stel de diepte in op 1.
8. Maak de derde alinea via de `Paragraph` klasse en stel de diepte in op 2.
9. Maak de vierde alinea via de `Paragraph` klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de `TextFrame` alinea‑collectie.
11. Sla de gewijzigde presentatie op.

```c#
// Instancieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
using (Presentation pres = new Presentation())
{

    // Haalt de eerste dia op
    ISlide slide = pres.Slides[0];
    
    // Voegt een AutoShape toe en krijgt deze op
    IAutoShape aShp = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

    // Haalt het tekstkader van de aangemaakte AutoShape op
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
    // Stelt het opsommingsteken-niveau in
    para1.ParagraphFormat.Depth = 0;

    // Voegt de tweede alinea toe
    IParagraph para2 = new Paragraph();
    para2.Text = "Second Level";
    para2.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para2.ParagraphFormat.Bullet.Char = '-';
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para2.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het opsommingsteken-niveau in
    para2.ParagraphFormat.Depth = 1;

    // Voegt de derde alinea toe
    IParagraph para3 = new Paragraph();
    para3.Text = "Third Level";
    para3.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para3.ParagraphFormat.Bullet.Char = Convert.ToChar(8226);
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para3.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het opsommingsteken-niveau in
    para3.ParagraphFormat.Depth = 2;

    // Voegt de vierde alinea toe
    IParagraph para4 = new Paragraph();
    para4.Text = "Fourth Level";
    para4.ParagraphFormat.Bullet.Type = BulletType.Symbol;
    para4.ParagraphFormat.Bullet.Char = '-';
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.FillType = FillType.Solid;
    para4.ParagraphFormat.DefaultPortionFormat.FillFormat.SolidFillColor.Color = Color.Black;
    // Stelt het opsommingsteken-niveau in
    para4.ParagraphFormat.Depth = 3;

    // Voegt alinea's toe aan de verzameling
    text.Paragraphs.Add(para1);
    text.Paragraphs.Add(para2);
    text.Paragraphs.Add(para3);
    text.Paragraphs.Add(para4);

    // Schrijft de presentatie weg als een PPTX-bestand
    pres.Save("MultilevelBullet.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/) interface biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith) en andere, waarmee u alinea's met aangepaste nummering of opmaak kunt beheren.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/iautoshape/) toe aan de dia.
4. Open het autoshape [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/).
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/net/aspose.slides/ibulletformat/numberedbulletstartwith) in op 2.
7. Maak de tweede alinea via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de `TextFrame` alinea‑collectie.
10. Sla de gewijzigde presentatie op.

```c#
using (var presentation = new Presentation())
{
	var shape = presentation.Slides[0].Shapes.AddAutoShape(ShapeType.Rectangle, 200, 200, 400, 200);

	// Haalt het tekstkader van de aangemaakte autoshape op
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

## **Eerste‑regelinspring voor een alinea instellen**

Gebruik de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) om de eerste‑regelinspring van een alinea te regelen. Deze eigenschap verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met de alinea‑inhoud.

Gebruik [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's en past verschillende `Indent` waarden toe om te laten zien hoe de eerste‑regelinspring de lay-out van de alinea beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's aan en stel voor elk verschillende [Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) waarden in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de gewijzigde presentatie op.

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

![De eerste‑regelinspring van de alinea's](first_line_indent.png)

## **Hangende inspring voor een alinea instellen**

Een hangende inspring is een alinea‑lay-out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de eigenschap [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/). Stel `Indent` in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea‑inhoud.

In de praktijk bepaalt [IParagraphFormat.MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) de linkse positie van de alinea‑inhoud, en [IParagraphFormat.Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende inspring te maken, stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, begrippenlijsten en andere alinea's waarbij omslagen onder de alinea‑inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation/) klasse.
2. Open de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's en stel voor elke alinea een positieve [MarginLeft](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/marginleft/) waarde in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraphformat/indent/) waarde in om het hangende‑inspring‑effect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de gewijzigde presentatie op.

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

![De hangende inspring van de alinea's](hanging_indent.png)

## **Eind‑alinea‑run‑eigenschappen beheren**

1. Maak een instantie van [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Haal de referentie op voor de dia die de alinea bevat via de positie.
3. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) met twee alinea's toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea's.
6. Stel de End‑eigenschappen in voor de alinea's.
7. Schrijf de gewijzigde presentatie weg als een PPTX‑bestand.

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

## **HTML‑tekst in alinea's importeren**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML‑tekst in alinea's.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse.
2. Open de referentie van de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/net/aspose.slides/autoshape/) toe aan de dia.
4. Voeg toe en open het `autoshape` [ITextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/itextframe/).
5. Verwijder de standaard alinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea via de [Paragraph](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraph/) klasse.
8. Voeg de inhoud van het HTML‑bestand, gelezen met de TextReader, toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de gewijzigde presentatie op.

```c#
// Creëert een lege presentatie‑instance
using (Presentation pres = new Presentation())
{
	// Benadert de standaard eerste dia van de presentatie
	ISlide slide = pres.Slides[0];

	// Voegt de AutoShape toe om de HTML‑inhoud in te huisvesten
	IAutoShape ashape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, pres.SlideSize.Size.Width - 20, pres.SlideSize.Size.Height - 10);

	ashape.FillFormat.FillType = FillType.NoFill;

	// Voegt een tekstkader toe aan de vorm
	ashape.AddTextFrame("");

	// Verwijdert alle alinea's in het toegevoegde tekstkader
	ashape.TextFrame.Paragraphs.Clear();

	// Laadt het HTML‑bestand met een stream‑reader
	TextReader tr = new StreamReader("file.html");

	// Voegt de tekst uit de HTML‑stream‑reader toe aan het tekstkader
	ashape.TextFrame.Paragraphs.AddFromHtml(tr.ReadToEnd());

	// Slaat de presentatie op
	pres.Save("output_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Alinea‑tekst naar HTML exporteren**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van teksten (geïntegreerd in alinea's) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/net/aspose.slides/presentation) klasse en laad de gewenste presentatie.
2. Open de referentie van de betreffende dia via de index.
3. Open de vorm die de te exporteren tekst naar HTML bevat.
4. Open het [TextFrame](https://reference.aspose.com/slides/nl/net/aspose.slides/textframe/) van de vorm.
5. Maak een instantie van `StreamWriter` en voeg het nieuwe HTML‑bestand toe.
6. Geef een start‑index aan StreamWriter en exporteer de gewenste alinea's.

```c#
// Laadt het presentatiebestand
using (Presentation pres = new Presentation("ExportingHTMLText.pptx"))
{

    // Benadert de standaard eerste dia van de presentatie
    ISlide slide = pres.Slides[0];

    // Benadert de vereiste index
    int index = 0;

    // Benadert de toegevoegde vorm
    IAutoShape ashape = (IAutoShape)slide.Shapes[index];

    StreamWriter sw = new StreamWriter("output_out.html", false, Encoding.UTF8);

    // Schrijft de alinea‑gegevens naar HTML door de startindex van de alinea en het aantal te kopiëren alinea's op te geven
    sw.Write(ashape.TextFrame.Paragraphs.ExportToHtml(0, ashape.TextFrame.Paragraphs.Count, null));

    sw.Close();
}
```

## **Een alinea als afbeelding opslaan**

In dit gedeelte onderzoeken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/net/aspose.slides/iparagraph/) interface, als afbeelding kunt opslaan. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `GetImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/net/aspose.slides/ishape/) interface, het berekenen van de afmetingen van de alinea binnen de vorm, en het exporteren ervan als bitmap‑afbeelding. Deze benaderingen stellen u in staat specifieke delen van de tekst uit PowerPoint‑presentaties te extraheren en op te slaan als losse afbeeldingen, wat nuttig kan zijn voor later gebruik in diverse scenario's.

Laten we aannemen dat we een presentatiedocument hebben genaamd **sample.pptx** met één dia, waarbij de eerste vorm een tekstvak is met drie alinea's.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm uit de eerste dia van de presentatie en berekenen daarna de afmetingen van de tweede alinea in het tekstkader van de vorm. De alinea wordt vervolgens opnieuw getekend op een nieuwe bitmap‑afbeelding, die in PNG‑formaat wordt opgeslagen. Deze methode is vooral handig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

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

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren aan de alinea‑afbeelding toe te voegen. De vorm wordt uit de presentatie geëxtraheerd en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een hogere resolutie bij het exporteren van de alinea. De afmetingen van de alinea worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een gedetailleerdere afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige gedrukte materialen.

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

**Kan ik het automatisch afbreken van tekst in een tekstkader volledig uitschakelen?**

Ja. Gebruik de afbreekinstelling van het tekstkader ([WrapText](https://reference.aspose.com/slides/nl/net/aspose.slides/textframeformat/wraptext/)) om afbreken uit te zetten zodat regels niet worden afgebroken aan de randen van het kader.

**Hoe kan ik de exacte positie van een specifieke alinea op de dia verkrijgen?**

U kunt de begrenzende rechthoek van de alinea (en zelfs van een enkel deel) opvragen om de precieze positie en grootte op de dia te weten.

**Waar wordt de alinea‑uitlijning (links/rechts/centraal/uitvullen) beheerd?**

[Alignment](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/alignment/) is een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/net/aspose.slides/paragraphformat/); deze wordt toegepast op de volledige alinea, ongeacht de opmaak van individuele delen.

**Kan ik een spellingscontrotaling instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op het deel‑niveau ([PortionFormat.LanguageId](https://reference.aspose.com/slides/nl/net/aspose.slides/baseportionformat/languageid/)), waardoor meerdere talen binnen één alinea kunnen coexisteren.