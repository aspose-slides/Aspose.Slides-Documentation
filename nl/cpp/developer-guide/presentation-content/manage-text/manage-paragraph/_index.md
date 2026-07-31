---
title: Beheer PowerPoint-tekstalinea's in C++
linktitle: Beheer alinea
type: docs
weight: 40
url: /nl/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- tekst toevoegen
- alinea toevoegen
- tekst beheren
- alinea beheren
- opsommingstekens beheren
- alinea-inspringing
- hangende inspringing
- alinea-bullet
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
- OpenDocument
- presentatie
- C++
- Aspose.Slides
description: "Beheers alinea-opmaak met Aspose.Slides voor C++ — optimaliseer uitlijning, afstand en stijl in PPT-, PPTX- en ODP-presentaties in C++."
---
## **Inleiding**

Aspose.Slides biedt alle interfaces en klassen die u nodig hebt om met PowerPoint‑teksten, alinea’s en delen in C++ te werken.

* Aspose.Slides biedt de [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) interface om objecten toe te voegen die een alinea vertegenwoordigen. Een `ITextFame`‑object kan één of meerdere alinea’s bevatten (elke alinea wordt aangemaakt via een regeleinde).
* Aspose.Slides biedt de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/) interface om objecten toe te voegen die delen vertegenwoordigen. Een `IParagraph`‑object kan één of meerdere delen bevatten (een collectie van iPortions‑objecten).
* Aspose.Slides biedt de [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/) interface om objecten toe te voegen die teksten en hun opmaak­eigenschappen vertegenwoordigen.

Een `IParagraph`‑object kan teksten met verschillende opmaak­eigenschappen verwerken via de onderliggende `IPortion`‑objecten.

## **Meerdere alinea’s met meerdere delen toevoegen**

Deze stappen laten zien hoe u een tekstvak met 3 alinea’s en in elke alinea 3 delen kunt toevoegen:

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Voeg een rechthoekige [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Haal het ITextFrame op dat aan de [IAutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) is gekoppeld.
5. Maak twee [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/)‑objecten en voeg ze toe aan de `IParagraphs`‑collectie van het [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/).
6. Maak drie [IPortion](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iportion/)‑objecten voor elke nieuwe `IParagraph` (twee Portion‑objecten voor een standaard alinea) en voeg elk `IPortion`‑object toe aan de IPortion‑collectie van de betreffende `IParagraph`.
7. Stel voor elk deel tekst in.
8. Pas de gewenste opmaak‑eigenschappen toe op elk deel via de `IPortion`‑objecten.
9. Sla de aangepaste presentatie op.

Deze C++‑code implementeert de stappen voor het toevoegen van alinea’s met delen:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Voeg een TextFrame toe aan de rechthoek
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// De eerste alinea benaderen
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Tweede alinea toevoegen
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Derde alinea toevoegen
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

// PPTX opslaan op schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alinea‑opsommingstekens beheren**

Opsommingstekens helpen u om snel en efficiënt informatie te organiseren en te presenteren. Alinea’s met opsommingstekens zijn altijd gemakkelijker te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de geselecteerde dia.
4. Haal het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape op. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑klasse.
7. Stel het bullet‑`Type` in op `Symbol` en definieer het bullet‑teken.
8. Stel de alinea‑`Text` in.
9. Stel de alinea‑`Indent` in voor de bullet.
10. Geef de bullet een kleur.
11. Geef de bullet een hoogte.
12. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
13. Voeg de tweede alinea toe en herhaal de stappen 7 tot 13.
14. Sla de presentatie op.

Deze C++‑code laat zien hoe u een alinea‑bullet toevoegt:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Voeg een TextFrame toe aan de rechthoek
ashp->AddTextFrame(u"");

// Toegang tot het tekstvak
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Maak het Paragraph‑object voor het tekstvak
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Tekst instellen
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Bullet‑inspringing instellen
paragraph->get_ParagraphFormat()->set_Indent (25);

// Bullet‑kleur instellen
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// IsBulletHardColor op true zetten om eigen bullet‑kleur te gebruiken
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Bullet‑hoogte instellen
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph toevoegen aan het tekstvak
txtFrame->get_Paragraphs()->Add(paragraph);

// Tweede alinea maken
// Maak het Paragraph‑object voor het tekstvak
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Tekst instellen
paragraph2->set_Text(u"This is numbered bullet");

// Alinea‑bullet‑type en -stijl instellen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Bullet‑inspringing instellen
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Bullet‑kleur instellen
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// IsBulletHardColor op true zetten om eigen bullet‑kleur te gebruiken
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Bullet‑hoogte instellen
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph toevoegen aan het tekstvak
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX opslaan op schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Afbeeldings‑bullets beheren**

Opsommingstekens helpen u om snel en efficiënt informatie te organiseren en te presenteren. Afbeeldings‑alinea’s zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Haal het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape op. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie met de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑klasse.
7. Laad de afbeelding in [IPPImage](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/).
8. Stel het bullet‑type in op [Picture](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ippimage/) en wijs de afbeelding toe.
9. Stel de alinea‑`Text` in.
10. Stel de alinea‑`Indent` in voor de bullet.
11. Geef de bullet een kleur.
12. Geef de bullet een hoogte.
13. Voeg de nieuwe alinea toe aan de alinea‑collectie van het `TextFrame`.
14. Voeg de tweede alinea toe en herhaal de stappen van eerder.
15. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe u afbeelding‑bullets toevoegt en beheert:

```c++
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instantieert de afbeelding voor bullets
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Voegt een AutoShape toe en krijgt toegang tot de AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Toegang tot het tekstframe van de autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Verwijdert de standaard alinea
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Maakt een nieuwe alinea
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Stelt de bullet‑stijl en afbeelding van de alinea in
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Stelt de bullet‑hoogte in
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Voegt de alinea toe aan het tekstframe
paragraphs->Add(paragraph);

// Schrijft de presentatie weg als een PPTX-bestand
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Schrijft de presentatie weg als een PPT-bestand
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Meerlagige bullets beheren**

Opsommingstekens helpen u om snel en efficiënt informatie te organiseren en te presenteren. Meerlagige bullets zijn gemakkelijk te lezen en te begrijpen.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe in de nieuwe dia.
4. Haal het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape op. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑klasse en stel de diepte in op 0.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 1.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 2.
9. Maak de vierde alinea‑instantie via de `Paragraph`‑klasse en stel de diepte in op 3.
10. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
11. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe u meerlagige bullets toevoegt en beheert:

```c++
// Instantieert een Presentation-klasse die een PPTX-bestand vertegenwoordigt
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Toegang tot de eerste dia
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Voegt een AutoShape toe en krijgt er toegang tot
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Toegang tot het tekstframe van de aangemaakte autoshape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Verwijdert de standaard alinea
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
// Stelt het bullet‑niveau in
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
// Stelt het bullet‑niveau in
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
// Stelt het bullet‑niveau in
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
// Stelt het bullet‑niveau in
para4Format->set_Depth(3);

// Voegt alinea’s toe aan de collectie
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Slaat de presentatie op als een PPTX-bestand
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Een alinea met een aangepaste genummerde lijst beheren**

De [IBulletFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/)‑interface biedt de eigenschap [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) en andere die u in staat stellen alinea’s met aangepaste nummering of opmaak te beheren. 

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg de dia die de alinea bevat.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Haal het [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de autoshape op. 
5. Verwijder de standaard alinea in het `TextFrame`.
6. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑klasse en stel [NumberedBulletStartWith](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) in op 2.
7. Maak de tweede alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 3.
8. Maak de derde alinea‑instantie via de `Paragraph`‑klasse en stel `NumberedBulletStartWith` in op 7.
9. Voeg de nieuwe alinea’s toe aan de alinea‑collectie van het `TextFrame`.
10. Sla de aangepaste presentatie op.

Deze C++‑code laat zien hoe u alinea’s met aangepaste nummering of opmaak toevoegt en beheert:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Toegang tot het tekstframe van de aangemaakte autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Verwijdert de standaard bestaande alinea
textFrame->get_Paragraphs()->RemoveAt(0);

// Eerste lijst
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

## **Eerste‑regel‑inspringing voor een alinea instellen**

Gebruik de methode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) om de eerste‑regel‑inspringing van een alinea te regelen. Deze methode verschuift alleen de eerste regel ten opzichte van de linkermarge van de alinea. Een positieve waarde verschuift de eerste regel naar rechts, terwijl de overige regels uitgelijnd blijven met het alinea‑lichaam.

Gebruik [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) wanneer u de hele alinea wilt verplaatsen. Gebruik [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) wanneer u alleen de eerste regel wilt verschuiven.

Het voorbeeld hieronder maakt verschillende alinea’s aan en past verschillende `Indent`‑waarden toe om te demonstreren hoe de eerste‑regel‑inspringing de lay‑out beïnvloedt.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak verschillende alinea’s aan en stel voor elk verschillende [Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/)‑waarden in.
6. Voeg de alinea’s toe aan het tekstvak.
7. Sla de aangepaste presentatie op.

Deze code toont hoe u een alinea‑inspringing instelt:

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

Resultaat:

![De eerste‑regel‑inspringing van de alinea’s](first_line_indent.png)

## **Hangende inspringing voor een alinea instellen**

Een hangende inspringing is een lay‑out waarbij de eerste regel links van de overige regels begint. In Aspose.Slides creëert u dit effect met de methode [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/). Stel de inspringing in op een negatieve waarde om de eerste regel naar links te verplaatsen ten opzichte van het alinea‑lichaam.

In de praktijk bepaalt [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/) de linkermarge van het alinea‑lichaam, en [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/) de positie van de eerste regel ten opzichte van die marge. Voor een hangende inspringing stelt u een positieve `MarginLeft`‑waarde en een negatieve `Indent`‑waarde in.

Deze opmaak is nuttig voor bibliografieën, referenties, glossarium‑items en andere alinea’s waarbij ingesprongen regels onder het alinea‑lichaam moeten uitgelijnd blijven in plaats van onder het eerste teken van de eerste regel.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg de doel‑dia.
3. Voeg een rechthoekige [AutoShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/autoshape/) toe aan de dia.
4. Voeg een leeg [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframe/) toe aan de vorm en verwijder de standaard alinea.
5. Maak alinea’s aan en stel voor elke alinea een positieve [MarginLeft](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑waarde in.
6. Stel een negatieve [Indent](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraphformat/set_indent/)‑waarde in om het hangende‑inspringing‑effect te verkrijgen.
7. Voeg de alinea’s toe aan het tekstvak.
8. Sla de aangepaste presentatie op.

Deze code toont hoe u een hangende inspringing voor een alinea instelt:

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

Resultaat:

![De hangende inspringing van de alinea’s](hanging_indent.png)

## **Eind‑run‑eigenschappen van een alinea beheren**

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
1. Haal de referentie op voor de dia die de alinea bevat via de positie.
1. Voeg een rechthoekige [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
1. Voeg een [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) met twee alinea’s toe aan de rechthoek.
1. Stel `FontHeight` en het lettertype in voor de alinea’s.
1. Stel de End‑eigenschappen in voor de alinea’s.
1. Schrijf de aangepaste presentatie weg als een PPTX‑bestand.

Deze C++‑code toont hoe u de End‑eigenschappen voor alinea’s in PowerPoint instelt:

```c++
// Het pad naar de documentenmap.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Voeg een TextFrame toe aan de rechthoek
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// De eerste alinea toevoegen
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// De tweede alinea toevoegen
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX opslaan op schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **HTML‑tekst importeren in alinea’s**

Aspose.Slides biedt uitgebreide ondersteuning voor het importeren van HTML‑tekst in alinea’s.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Voeg een [autoshape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iautoshape/) toe aan de dia.
4. Voeg een [ITextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) toe aan en haal de autoshape op.
5. Verwijder de standaard alinea in het `ITextFrame`.
6. Lees het bron‑HTML‑bestand in met een TextReader.
7. Maak de eerste alinea‑instantie via de [Paragraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraph/)‑klasse.
8. Voeg de HTML‑inhoud uit de gelezen TextReader toe aan de [ParagraphCollection](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphcollection/) van het TextFrame.
9. Sla de aangepaste presentatie op.

Deze C++‑code implementeert de stappen voor het importeren van HTML‑teksten in alinea’s:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Het pad naar de documentenmap.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Laad de gewenste presentatie
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Toegang tot de eerste dia
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Voeg een AutoShape van het type Rechthoek toe
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Standaard vulkleur resetten
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Voeg een TextFrame toe aan de rechthoek
ashp->AddTextFrame(u" ");

// Toegang tot het tekstframe
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Haal de alinea-collectie op
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Alle alinea's in het toegevoegde tekstframe wissen
ParaCollection->Clear();

// HTML-bestand laden met stream reader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Tekst uit HTML-stream reader toevoegen aan tekstframe
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Maak het Paragraph-object voor het tekstframe
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Maak Portion-object voor alinea
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Haal portion-formaat op
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Stel het lettertype in voor de Portion
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Stel eigenschap Bold van het lettertype in
pf->set_FontBold(NullableBool::True);

// Stel eigenschap Italic van het lettertype in
pf->set_FontItalic(NullableBool::True);

// Stel eigenschap Underline van het lettertype in
pf->set_FontUnderline(TextUnderlineType::Single);

// Stel de hoogte van het lettertype in
pf->set_FontHeight(25);

// Stel de kleur van het lettertype in
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX opslaan op schijf
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Alinea‑tekst exporteren naar HTML**

Aspose.Slides biedt uitgebreide ondersteuning voor het exporteren van teksten (geplaatst in alinea’s) naar HTML.

1. Maak een instantie van de [Presentation](https://reference.aspose.com/slides/nl/cpp/aspose.slides/presentation/)‑klasse en laad de gewenste presentatie.
2. Verkrijg een referentie naar de betreffende dia via de index.
3. Haal de vorm op die de te exporteren tekst bevat.
4. Haal de [TextFrame](https://reference.aspose.com/slides/nl/cpp/aspose.slides/itextframe/) van de vorm op.
5. Maak een `StreamWriter`‑instantie en maak een nieuw HTML‑bestand aan.
6. Geef een start‑index door aan de StreamWriter en exporteer de gewenste alinea’s.

Deze C++‑code toont hoe u PowerPoint‑alinea‑teksten exporteert naar HTML:

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

// Het eerste alinea extraheren als HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Paragraafgegevens naar HTML schrijven door de startindex en het aantal te kopiëren alinea's op te geven
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Een alinea opslaan als afbeelding**

In dit gedeelte bekijken we twee voorbeelden die laten zien hoe u een tekst‑alinea, vertegenwoordigd door de [IParagraph](https://reference.aspose.com/slides/nl/cpp/aspose.slides/iparagraph/)‑interface, opslaat als afbeelding. Beide voorbeelden omvatten het verkrijgen van de afbeelding van een vorm die de alinea bevat via de `GetImage`‑methoden van de [IShape](https://reference.aspose.com/slides/nl/cpp/aspose.slides/ishape/)‑interface, het berekenen van de grenzen van de alinea binnen de vorm, en het exporteren als bitmap‑afbeelding. Deze methoden stellen u in staat specifieke tekst‑delen uit PowerPoint‑presentaties te extraheren en op te slaan als losse afbeeldingen, wat nuttig kan zijn voor verdere verwerking in diverse scenario’s.

Stel dat we een presentatie‑bestand hebben genaamd **sample.pptx** met één dia, waarbij de eerste vorm een tekstvak is met drie alinea’s.

![Het tekstvak met drie alinea’s](paragraph_to_image_input.png)

**Voorbeeld 1**

In dit voorbeeld halen we de tweede alinea als afbeelding op. Hiervoor extraheren we de afbeelding van de vorm op de eerste dia van de presentatie en berekenen vervolgens de grenzen van de tweede alinea in het tekstvak van de vorm. De alinea wordt daarna opnieuw getekend op een nieuwe bitmap‑afbeelding, die wordt opgeslagen in PNG‑formaat. Deze methode is bijzonder handig wanneer u een specifieke alinea apart wilt opslaan terwijl de exacte afmetingen en opmaak behouden blijven.

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

Resultaat:

![De alinea‑afbeelding](paragraph_to_image_output.png)

**Voorbeeld 2**

In dit voorbeeld breiden we de vorige aanpak uit door schaalfactoren toe te passen op de alinea‑afbeelding. De vorm wordt uit de presentatie geëxtraheerd en opgeslagen als afbeelding met een schaalfactor van `2`. Hierdoor ontstaat een hogere resolutie‑output bij het exporteren van de alinea. De alinea‑grenzen worden vervolgens berekend rekening houdend met de schaal. Schalen kan vooral nuttig zijn wanneer een meer gedetailleerde afbeelding vereist is, bijvoorbeeld voor gebruik in hoogwaardige drukmaterialen.

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

**Kan ik het automatisch afbreken van tekst binnen een tekstvak volledig uitschakelen?**

Ja. Gebruik de omloop‑methode van het tekstvak ([set_WrapText](https://reference.aspose.com/slides/nl/cpp/aspose.slides/textframeformat/set_wraptext/)) om omloop uit te schakelen zodat regels niet worden afgebroken aan de randen van het vak.

**Hoe krijg ik de exacte positie van een specifieke alinea op de dia?**

U kunt het begrenzings‑rechthoekje van de alinea (en zelfs van een enkele portion) ophalen om de precieze positie en afmetingen op de dia te bepalen.

**Waar wordt de uitlijning van alinea’s (links/rechts/midden/uitvullen) geregeld?**

[Alignment](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/set_alignment/) is een alinea‑niveau instelling in [ParagraphFormat](https://reference.aspose.com/slides/nl/cpp/aspose.slides/paragraphformat/); deze wordt toegepast op de gehele alinea, ongeacht de afzonderlijke opmaak van delen.

**Kan ik een spellings‑taal instellen voor slechts een deel van een alinea (bijv. één woord)?**

Ja. De taal wordt ingesteld op portion‑niveau via ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/nl/cpp/aspose.slides/baseportionformat/set_languageid/)), waardoor meerdere talen binnen één alinea kunnen bestaan.