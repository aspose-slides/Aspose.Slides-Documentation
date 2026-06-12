---
title: Beheer PowerPoint-tekstparagrafen in C++
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/cpp/manage-paragraph/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsomming beheren
- alinea-insprong
- hangende insprong
- alinea-opsomming
- genummerde lijst
- opsomming met opsommingstekens
- paragraafeigenschappen
- HTML importeren
- tekst naar HTML
- alinea naar HTML
- alinea naar afbeelding
- tekst naar afbeelding
- alinea exporteren
- PowerPoint
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheers de paragraafopmaak met Aspose.Slides voor C++—optimaliseer uitlijning, spatiëring en stijl in PPT, PPTX en ODP-presentaties in C++."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig hebt om met PowerPoint-teksten, alinea's en gedeelten te werken in C++.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) interface om objecten toe te voegen die een alinea vertegenwoordigen. Een `ITextFame` object kan één of meerdere alinea's hebben (elke alinea wordt gecreeerd via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) interface om objecten toe te voegen die gedeelten vertegenwoordigen. Een `IParagraph` object kan één of meerdere gedeelten hebben (collectie van iPortions-objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) interface om objecten toe te voegen die teksten en hun opmaak-eigenschappen vertegenwoordigen. 

Een `IParagraph` object kan teksten met verschillende opmaak-eigenschappen verwerken via de onderliggende `IPortion` objecten.

## **Meerdere alinea's met meerdere gedeelten toevoegen**

Deze stappen laten zien hoe je een tekstvak toevoegt met 3 alinea's en elke alinea met 3 gedeelten:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat gekoppeld is aan de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/).
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) objecten aan en voeg ze toe aan de `IParagraphs`-collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) objecten aan voor elke nieuwe `IParagraph` (twee Portion-objecten voor de standaard alinea) en voeg elk `IPortion` object toe aan de IPortion-collectie van elke `IParagraph`.
7. Stel tekst in voor elk gedeelte.
8. Pas uw gewenste opmaakkenmerken toe op elk gedeelte met behulp van de opmaak-eigenschappen van het `IPortion` object.
9. Sla de aangepaste presentatie op.

```c++
// Het pad naar de documentmap.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Open de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Voeg TextFrame toe aan de rechthoek
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Accessing the first Paragraph
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Adding second Paragraph
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Adding third Paragraph
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para2);
SharedPtr<Portion> port20 = MakeObject<Portion>();
SharedPtr<Portion> port21 = MakeObject<Portion>();
SharedPtr<Portion> port22 = MakeObject<Portion>();
para2->get_Portions()->Add(port20);
para2->get_Portions()->Add(port21);
para2->get_Portions()->Add(port22);


for (int i = 0; i < 3; i++)
{
	for (int j = 0; j < 3; j++)
	{
		tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->set_Text(u"Portion_"+j);
		SharedPtr<IPortionFormat>format = tf->get_Paragraphs()->idx_get(i)->get_Portions()->idx_get(j)->get_PortionFormat();

		if (j == 0)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(15);
		}
		else if (j == 1)
		{
			format->get_FillFormat()->set_FillType(FillType::Solid);
			format->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
			format->set_FontBold(NullableBool::True);
			format->set_FontHeight(18);
		}
	}

}

// Sla PPTX op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alinea-opsommingstekens beheren**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met opsommingstekens zijn altijd makkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea-instantie aan met de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) klasse.
7. Stel het bullet-`Type` van de alinea in op `Symbol` en stel het opsommingsteken in.
8. Stel de alinea-`Text` in.
9. Stel de alinea-`Indent` in voor het opsommingsteken.
10. Stel een kleur in voor het opsommingsteken.
11. Stel een hoogte in voor het opsommingsteken.
12. Voeg de nieuwe alinea toe aan de alinea-collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal het proces zoals beschreven in stap 7 tot 13.
14. Sla de presentatie op.

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Open de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Voeg TextFrame toe aan de rechthoek
ashp->AddTextFrame(u"");

// Toegang tot het tekstkader
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Maak het Paragraph-object voor het tekstkader
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

//Tekst instellen
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Bulletinsprong instellen
paragraph->get_ParagraphFormat()->set_Indent (25);

// Bulletkleur instellen
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// stel IsBulletHardColor in op true om eigen bulletkleur te gebruiken
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Bullethoogte instellen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph toevoegen aan tekstkader
txtFrame->get_Paragraphs()->Add(paragraph);

// Tweede alinea maken
// Maak het Paragraph-object voor het tekstkader
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

//Tekst instellen
paragraph2->set_Text(u"This is numbered bullet");

// Instelling alinea bullettype en stijl
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Bulletinsprong instellen
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Bulletkleur instellen
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// stel IsBulletHardColor in op true om eigen bulletkleur te gebruiken
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Bullethoogte instellen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph toevoegen aan tekstkader
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX opslaan naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Beheer van afbeelding-opsommingstekens**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Alinea's met afbeeldingen zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea-instantie aan met de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/).
8. Stel het bullet-type in op [Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) en stel de afbeelding in.
9. Stel de `Text` van de alinea in.
10. Stel de alinea-`Indent` in voor het opsommingsteken.
11. Stel een kleur in voor het opsommingsteken.
12. Stel een hoogte in voor het opsommingsteken.
13. Voeg de nieuwe alinea toe aan de alinea-collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal het proces op basis van de eerdere stappen.
15. Sla de aangepaste presentatie op.

```c++
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Verkrijgt de eerste dia
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instantieert de afbeelding voor opsommingstekens
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Voegt een Autoshape toe en krijgt toegang tot deze
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Verkrijgt het tekstframe van de autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Verwijdert de standaard alinea
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Maakt een nieuwe alinea
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Stelt de bulletstijl en afbeelding van de alinea in
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Stelt de bullethoogte in
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Voegt de alinea toe aan het tekstframe
paragraphs->Add(paragraph);

// Slaat de presentatie op als een PPTX‑bestand
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Slaat de presentatie op als een PPT‑bestand
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Beheer van meerlagige opsommingstekens**

Opsommingslijsten helpen u om informatie snel en efficiënt te organiseren en te presenteren. Meerlagige opsommingstekens zijn makkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe in de nieuwe dia.
4. Verkrijg het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea-instantie via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) klasse en stel de diepte in op 0.
7. Maak de tweede alinea-instantie via de `Paragraph` klasse en stel de diepte in op 1.
8. Maak de derde alinea-instantie via de `Paragraph` klasse en stel de diepte in op 2.
9. Maak de vierde alinea-instantie via de `Paragraph` klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea's toe aan de alinea-collectie van het `TextFrame`.
11. Sla de aangepaste presentatie op.

```c++
// Instantieert een Presentation‑klasse die een PPTX‑bestand vertegenwoordigt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Verkrijgt de eerste dia
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Voegt een Autoshape toe en krijgt deze
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Verkrijgt het tekstframe van de gemaakte autoshape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Wis de standaard alinea
text->get_Paragraphs()->Clear();

// Voegt de eerste alinea toe
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Stelt het bulletniveau in
para1Format->set_Depth(0);

// Voegt de tweede alinea toe
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Stelt het bulletniveau in
para2Format->set_Depth(1);

// Voegt de derde alinea toe
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Stelt het bulletniveau in
para3Format->set_Depth(2);

// Voegt de vierde alinea toe
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Stelt het bulletniveau in
para4Format->set_Depth(3);

// Voegt alinea's toe aan de collectie
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Slaat de presentatie op als een PPTX‑bestand
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/) interface biedt de [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) eigenschap en andere die u in staat stellen alinea's met aangepaste nummering of opmaak te beheren. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Verkrijg de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea-instantie via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) in op 2.
7. Maak de tweede alinea-instantie via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea-instantie via de `Paragraph` klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea's toe aan de alinea-collectie van het `TextFrame`.
10. Sla de aangepaste presentatie op.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Accesses the text frame of created autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Removes the default existing paragraph
textFrame->get_Paragraphs()->RemoveAt(0);

// First list
auto paragraph1 = System::MakeObject<Paragraph>();
paragraph1->set_Text(u"bullet 2");
auto paragraph1Format = paragraph1->get_ParagraphFormat();
paragraph1Format->set_Depth(4);
auto bullet1Format = paragraph1Format->get_Bullet();
bullet1Format->set_NumberedBulletStartWith(2);
bullet1Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph1);

auto paragraph2 = System::MakeObject<Paragraph>();
paragraph2->set_Text(u"bullet 3");
auto paragraph2Format = paragraph2->get_ParagraphFormat();
paragraph2Format->set_Depth(4);
auto bullet2Format = paragraph2Format->get_Bullet();
bullet2Format->set_NumberedBulletStartWith(3);
bullet2Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph2);

auto paragraph5 = System::MakeObject<Paragraph>();
paragraph5->set_Text(u"bullet 7");
auto paragraph5Format = paragraph5->get_ParagraphFormat();
paragraph5Format->set_Depth(4);
auto bullet5Format = paragraph5Format->get_Bullet();
bullet5Format->set_NumberedBulletStartWith(7);
bullet5Format->set_Type(BulletType::Numbered);
textFrame->get_Paragraphs()->Add(paragraph5);

presentation->Save(u"SetCustomBulletsNumber-slides.pptx", SaveFormat::Pptx);
```

## **Eerste-regelinferentie voor een alinea instellen**

Gebruik de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) methode om de eerste-regelinferentie van een alinea te regelen. Deze methode verplaatst alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de rest van de regels uitgelijnd blijft met de alinea-inhoud.

Gebruik [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) wanneer u alleen de eerste regel wilt verplaatsen.

Het onderstaande voorbeeld maakt meerdere alinea's aan en past verschillende `Indent`-waarden toe om te laten zien hoe de eerste-regelinferentie de lay-out van de alinea beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de doel-dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea's aan en stel verschillende [Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarden in.
6. Voeg de alinea's toe aan het tekstkader.
7. Sla de aangepaste presentatie op.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
firstParagraph->get_ParagraphFormat()->set_Indent(0.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
secondParagraph->get_ParagraphFormat()->set_Indent(20.f);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20.f);
thirdParagraph->get_ParagraphFormat()->set_Indent(40.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![De eerste-regelinferentie van de alinea's](first_line_indent.png)

## **Hangende insprong voor een alinea instellen**

Een hangende insprong is een alinea-lay-out waarbij de eerste regel links begint ten opzichte van de resterende regels. In Aspose.Slides creëert u dit effect met de [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) methode. Stel de insprong in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van de alinea-inhoud.

In de praktijk definieert [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) de linkerpositie van de alinea-inhoud, en definieert [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) de positie van de eerste regel ten opzichte van die marge. Om een hangende insprong te maken, stelt u een positieve `MarginLeft`-waarde en een negatieve `Indent`-waarde in.

Deze opmaak is handig voor bibliografieën, referenties, woordenboekvermeldingen en andere alinea's waarbij ingesprongen regels onder de alinea-inhoud moeten uitlijnen in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de doel-dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een lege [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea's aan en stel een positieve [MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) waarde in voor elke alinea.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) waarde in om het hangende insprongeffect te creëren.
7. Voeg de alinea's toe aan het tekstkader.
8. Sla de aangepaste presentatie op.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto rectangleShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
rectangleShape->get_FillFormat()->set_FillType(FillType::NoFill);
rectangleShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
rectangleShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = rectangleShape->AddTextFrame(u"");
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->RemoveAt(0);

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40.f);
firstParagraph->get_ParagraphFormat()->set_Indent(-20.f);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60.f);
secondParagraph->get_ParagraphFormat()->set_Indent(-30.f);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![De hangende insprong van de alinea's](hanging_indent.png)

## **Eind-alinea-run-eigenschappen beheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de dia die de alinea bevat via de positie.
3. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) met twee alinea's toe aan de rechthoek.
5. Stel de `FontHeight` en het lettertype in voor de alinea's.
6. Stel de End-eigenschappen in voor de alinea's.
7. Schrijf de aangepaste presentatie weg als een PPTX-bestand.

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Open de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Voeg TextFrame toe aan de rechthoek
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Eerste alinea toevoegen
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Tweede alinea toevoegen
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Sla PPTX op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **HTML-tekst importeren in alinea's**

Aspose.Slides biedt verbeterde ondersteuning voor het importeren van HTML-tekst in alinea's.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een `autoshape` toe en krijg toegang tot de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) .
5. Verwijder de standaard alinea in het `ITextFrame`.
6. Lees het bron-HTML-bestand in met een TextReader.
7. Maak de eerste alinea-instantie aan via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/) klasse.
8. Voeg de inhoud van het HTML-bestand, gelezen met de TextReader, toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de aangepaste presentatie op.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Het pad naar de documentenmap.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Open de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Reset de standaard vulkleur
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Voeg TextFrame toe aan de rechthoek
ashp->AddTextFrame(u" ");

// Toegang tot het tekstframe
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Haal de Paragraphs-collectie op
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Verwijder alle alinea's in het toegevoegde tekstframe
ParaCollection->Clear();

// Laad het HTML-bestand met een streamreader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Voeg tekst van de HTML-streamreader toe aan het tekstframe
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Maak het Paragraph-object voor het tekstframe
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Maak een Portion-object voor de alinea
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Haal het portion-format op
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Stel het lettertype in voor de Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Stel de eigenschap Vet in voor het lettertype
pf->set_FontBold(NullableBool::True);

// Stel de eigenschap Cursief in voor het lettertype
pf->set_FontItalic(NullableBool::True);

// Stel de eigenschap Onderstrepen in voor het lettertype
pf->set_FontUnderline(TextUnderlineType::Single);

// Stel de hoogte van het lettertype in
pf->set_FontHeight(25);

// Stel de kleur van het lettertype in
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Sla PPTX op naar schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alinea-tekst exporteren naar HTML**

Aspose.Slides biedt verbeterde ondersteuning voor het exporteren van teksten (gehouden in alinea's) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/) klasse en laad de gewenste presentatie.
2. Verkrijg de referentie van de gewenste dia via de index.
3. Verkrijg de vorm die de te exporteren tekst bevat.
4. Verkrijg de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm.
5. Maak een instantie van `StreamWriter` aan en voeg het nieuwe HTML-bestand toe.
6. Geef een start-index door aan StreamWriter en exporteer de gewenste alinea's.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Het pad naar de documentenmap.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Toegang tot de standaard eerste dia van de presentatie
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Gewenste index
int index = 0;

// Toegang tot de toegevoegde vorm
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Eerste alinea extraheren als HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Schrijf alinea-gegevens naar HTML door startindex van alinea en totaal aantal alinea's op te geven om te kopiëren
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bekijken we twee voorbeelden die laten zien hoe een tekst-alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) interface, als afbeelding kan worden opgeslagen. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat met de `GetImage`-methoden van de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/) interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren ervan als bitmap-afbeelding. Deze benaderingen stellen u in staat om specifieke delen van de tekst uit PowerPoint-presentaties te extraheren en als afzonderlijke afbeeldingen op te slaan, wat nuttig kan zijn voor verdere toepassingen in verschillende scenario's.

Laten we aannemen dat we een presentatiedocument hebben genaamd sample.pptx met één dia, waarbij de eerste vorm een tekstvak is dat drie alinea's bevat.

![Het tekstvak met drie alinea's](paragraph_to_image_input.png)

**Example 1**

In dit voorbeeld verkrijgen we de tweede alinea als afbeelding. Hiervoor extraheren we de afbeelding van de vorm van de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstkader van de vorm. De alinea wordt vervolgens opnieuw getekend op een nieuw bitmap-beeld, dat opgeslagen wordt in PNG-formaat. Deze methode is vooral nuttig wanneer u een specifieke alinea als afzonderlijke afbeelding wilt opslaan terwijl de exacte afmetingen en opmaak van de tekst behouden blijven.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

![De alinea-afbeelding](paragraph_to_image_output.png)

**Example 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te voegen aan de alinea-afbeelding. De vorm wordt geëxtraheerd uit de presentatie en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een afbeelding met hogere resolutie bij het exporteren van de alinea. De grenzen van de alinea worden vervolgens berekend rekening houdend met de schaal. Schalen kan bijzonder nuttig zijn wanneer een meer gedetailleerde afbeelding nodig is, bijvoorbeeld voor gebruik in hoogwaardige afdrukmaterialen.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Save the shape in memory as a bitmap with scaling.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Create a shape bitmap from memory.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Calculate the boundaries of the second paragraph.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Calculate the size for the output image (minimum size - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Prepare a bitmap for the paragraph.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Redraw the paragraph from the shape bitmap to the paragraph bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Kan ik de automatische regelafbreking in een tekstvak volledig uitschakelen?**

Ja. Gebruik de omloopmethode van het tekstvak ([set_WrapText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_wraptext/)) om afbreken uit te schakelen zodat regels niet worden afgebroken aan de randen van het kader.

**Hoe kan ik de exacte positie op de dia van een specifieke alinea verkrijgen?**

U kunt het omhullende rechthoek van de alinea (en zelfs van een enkel gedeelte) opvragen om de exacte positie en grootte op de dia te kennen.

**Waar wordt de alinea-uitlijning (links/rechts/centraal/uitvullen) beheerd?**

[Alignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/set_alignment/) is een instelling op alinea-niveau in [ParagraphFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/); deze wordt toegepast op de gehele alinea, ongeacht de opmaak van individuele gedeelten.

**Kan ik een spellingscontrole-taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op gedeelte-niveau met ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/)), zodat meerdere talen binnen één alinea kunnen bestaan.