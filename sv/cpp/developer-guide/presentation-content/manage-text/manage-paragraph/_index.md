---
title: Hantera PowerPoint-textstycken i C++
linktitle: Hantera stycke
type: docs
weight: 40
url: /sv/cpp/manage-paragraph/
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
- OpenDocument
- presentation
- C++
- Aspose.Slides
description: "Behärska formatering av stycken med Aspose.Slides för C++ — optimera justering, avstånd och stil i PPT-, PPTX- och ODP-presentationer i C++."
---
## **Introduktion**

Aspose.Slides tillhandahåller alla gränssnitt och klasser du behöver för att arbeta med PowerPoint‑texter, stycken och delar i C++.

* Aspose.Slides tillhandahåller gränssnittet [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) så att du kan lägga till objekt som representerar ett stycke. Ett `ITextFame`‑objekt kan ha ett eller flera stycken (varje stycke skapas via ett radbryt).
* Aspose.Slides tillhandahåller gränssnittet [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/) så att du kan lägga till objekt som representerar delar. Ett `IParagraph`‑objekt kan ha ett eller flera delar (samling av iPortions‑objekt).
* Aspose.Slides tillhandahåller gränssnittet [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/) så att du kan lägga till objekt som representerar texter och deras formateringsegenskaper.

Ett `IParagraph`‑objekt kan hantera texter med olika formateringsegenskaper via dess underliggande `IPortion`‑objekt.

## **Lägg till flera stycken som innehåller flera delar**

Följande steg visar hur du lägger till en textram som innehåller 3 stycken och varje stycke innehåller 3 delar:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en rektangel [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
4. Hämta ITextFrame som är associerad med [IAutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/).
5. Skapa två [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/)‑objekt och lägg till dem i `IParagraphs`‑samlingen för [ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
6. Skapa tre [IPortion](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iportion/)‑objekt för varje nytt `IParagraph` (två Portion‑objekt för standardstycket) och lägg till varje `IPortion`‑objekt i IPortion‑samlingen för varje `IParagraph`.
7. Ange lite text för varje del.
8. Applicera dina föredragna formateringsfunktioner på varje del med hjälp av formateringsegenskaperna som exponeras av `IPortion`‑objektet.
9. Spara den ändrade presentationen.

Denna C++‑kod är en implementation av stegen för att lägga till stycken som innehåller delar: 

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Läs in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Kom åt första bilden
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägg till en AutoShape av rektangulär typ
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Lägg till TextFrame till rektangeln
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Hämtar det första stycket
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Lägger till andra stycket
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Lägger till tredje stycket
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

// Spara PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Hantera stycke‑punkter**

Punktlistor hjälper dig att snabbt och effektivt organisera och presentera information. Punkterade stycken är alltid enklare att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) till den valda bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa det första stycke‑instansen med klassen [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/).
7. Ställ in bullet‑`Type` för stycket till `Symbol` och ange bullet‑tecknet.
8. Ange styckets `Text`.
9. Ställ in styckets `Indent` för bullet.
10. Ange en färg för bullet.
11. Ange en höjd för bullet.
12. Lägg till det nya stycket i `TextFrame`‑styckeskollektionen.
13. Lägg till det andra stycket och upprepa processen som beskrivs i steg 7 till 13.
14. Spara presentationen.

Denna C++‑kod visar hur du lägger till en styckepunkt:

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";


// Läs in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Kom åt första bilden
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägg till en AutoShape av rektangulär typ
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Lägg till TextFrame till rektangeln
ashp->AddTextFrame(u"");

// Hämtar textramen
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Skapa Paragraph‑objektet för textramen
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Ställer in text
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ställer in punktindrag
paragraph->get_ParagraphFormat()->set_Indent (25);

// Ställer in punktfärg
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// sätt IsBulletHardColor till true för att använda egen punktfärg
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Ställer in punktens höjd
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Lägger till stycke i textramen
txtFrame->get_Paragraphs()->Add(paragraph);

// Skapar andra stycket
// Skapa Paragraph‑objektet för textramen
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Ställer in text
paragraph2->set_Text(u"This is numbered bullet");

// Ställer in styckepunktens typ och stil
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Ställer in punktindrag
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Ställer in punktfärg
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// sätt IsBulletHardColor till true för att använda egen punktfärg
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Ställer in punktens höjd
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Lägger till stycke i textramen
txtFrame->get_Paragraphs()->Add(paragraph2);


// Spara PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Hantera bildpunkter**

Punktlistor hjälper dig att snabbt och effektivt organisera och presentera information. Bildstycken är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/).
7. Läs in bilden i [IPPImage](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/).
8. Ställ in bullet‑typen till [Picture](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ippimage/) och ange bilden.
9. Ange stycket `Text`.
10. Ställ in stycket `Indent` för bullet.
11. Ange en färg för bullet.
12. Ange en höjd för bullet.
13. Lägg till det nya stycket i `TextFrame`‑styckeskollektionen.
14. Lägg till det andra stycket och upprepa processen baserat på föregående steg.
15. Spara den ändrade presentationen.

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Kom åt den första bilden
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Instansierar bilden för punkter
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Lägger till och hämtar Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Hämtar autoshapens textram
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Tar bort standardstycket
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Skapar ett nytt stycke
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Ställer in styckepunktens stil och bild
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Ställer in punktens höjd
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Lägger till stycke i textramen
paragraphs->Add(paragraph);

// Skriver presentationen som en PPTX-fil
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Skriver presentationen som en PPT-fil
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Hantera flernivå‑punkter**

Punktlistor hjälper dig att snabbt och effektivt organisera och presentera information. Flernivå‑punkter är lätta att läsa och förstå.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på den nya bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/) och sätt djupet till 0.
7. Skapa det andra stycket via klassen `Paragraph` och sätt djupet till 1.
8. Skapa det tredje stycket via klassen `Paragraph` och sätt djupet till 2.
9. Skapa det fjärde stycket via klassen `Paragraph` och sätt djupet till 3.
10. Lägg till de nya styckena i `TextFrame`‑styckeskollektionen.
11. Spara den ändrade presentationen.

```c++
// Instansierar en Presentation-klass som representerar en PPTX-fil
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Hämtar den första bilden
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lägger till och hämtar Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Hämtar textramen för den skapade Autoshapen
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Rensar standardstycket
text->get_Paragraphs()->Clear();

// Lägger till det första stycket
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ställer in punktnivån
para1Format->set_Depth(0);

// Lägger till det andra stycket
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ställer in punktnivån
para2Format->set_Depth(1);

// Lägger till det tredje stycket
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ställer in punktnivån
para3Format->set_Depth(2);

// Lägger till det fjärde stycket
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Ställer in punktnivån
para4Format->set_Depth(3);

// Lägger till stycken i samlingen
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Skriver presentationen som en PPTX-fil
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Hantera ett stycke med en anpassad numrerad lista**

[IBulletFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/)‑gränssnittet tillhandahåller egenskapen [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) och andra som låter dig hantera stycken med anpassad numrering eller formatering. 

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta bilden som innehåller stycket.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) till bilden.
4. Hämta autoshapens [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/). 
5. Ta bort standardstycket i `TextFrame`.
6. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/) och sätt [NumberedBulletStartWith](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) till 2.
7. Skapa det andra stycket via klassen `Paragraph` och sätt `NumberedBulletStartWith` till 3.
8. Skapa det tredje stycket via klassen `Paragraph` och sätt `NumberedBulletStartWith` till 7.
9. Lägg till de nya styckena i `TextFrame`‑styckeskollektionen.
10. Spara den ändrade presentationen.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Hämtar textramen för den skapade autoshapen
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Tar bort det befintliga standardstycket
textFrame->get_Paragraphs()->RemoveAt(0);

// Första listan
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

## **Ställ in första radens indrag för ett stycke**

Använd metoden [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) för att kontrollera första radens indrag i ett stycke. Denna metod flyttar endast den första raden i förhållande till styckets vänstermarginal. Ett positivt värde flyttar den första raden åt höger, medan de återstående raderna förblir justerade med styckets kropp.

Använd [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/) när du behöver flytta hela stycket. Använd [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) när du bara vill flytta den första raden.

Exemplet nedan skapar flera stycken och applicerar olika `Indent`‑värden för att demonstrera hur första radens indrag påverkar stycke‑layouten.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa flera stycken och sätt olika [Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/)‑värden för dem.
6. Lägg till styckena i textramen.
7. Spara den ändrade presentationen.

Den här koden visar hur du ställer in ett styckeindrag:

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

Resultatet:

![The first-line indent of the paragraphs](first_line_indent.png)

## **Ställ in hängande indrag för ett stycke**

A hanging indent är en stycke‑layout där den första raden börjar till vänster om de återstående raderna. I Aspose.Slides skapar du denna effekt med metoden [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/). Sätt indraget till ett negativt värde för att flytta den första raden åt vänster i förhållande till styckets kropp.

I praktiken definierar [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/) den vänstra positionen för styckets kropp, och [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/) definierar positionen för den första raden i förhållande till den marginalen. För att skapa ett hängande indrag, sätt ett positivt `MarginLeft`‑värde och ett negativt `Indent`‑värde.

Denna formatering är användbar för bibliografier, referenser, förkortningsposter och andra stycken där radbrytna rader måste justeras under styckets kropp snarare än under den första tecknet i första raden.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta målbilden.
3. Lägg till en rektangulär [AutoShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/autoshape/) på bilden.
4. Lägg till en tom [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframe/) till formen och ta bort standardstycket.
5. Skapa stycken och sätt ett positivt [MarginLeft](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑värde för varje stycke.
6. Sätt ett negativt [Indent](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraphformat/set_indent/)‑värde för att skapa hängande indrag.
7. Lägg till styckena i textramen.
8. Spara den ändrade presentationen.

Den här koden visar hur du ställer in ett hängande indrag för ett stycke:

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

Resultatet:

![The hanging indent of the paragraphs](hanging_indent.png)

## **Hantera slutegenskaper för stycke**

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/)‑klassen.
1. Hämta referensen till bilden som innehåller stycket via dess position.
1. Lägg till en rektangulär [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) på bilden.
1. Lägg till en [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) med två stycken till rektangeln.
1. Ställ in `FontHeight` och typsnitt för styckena.
1. Ställ in slut‑egenskaperna för styckena.
1. Skriv den ändrade presentationen som en PPTX‑fil.

Denna C++‑kod visar hur du ställer in slut‑egenskaperna för stycken i PowerPoint: 

```c++
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Läs in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Kom åt första bilden
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägg till en AutoShape av rektangulär typ
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Lägg till TextFrame till rektangeln
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Lägger till det första stycket
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Lägger till det andra stycket
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// Spara PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **Importera HTML‑text till stycken**

Aspose.Slides erbjuder förbättrat stöd för att importera HTML‑text till stycken.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/).
2. Hämta referensen till den relevanta bilden via dess index.
3. Lägg till en [autoshape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iautoshape/) till bilden.
4. Lägg till och hämta `autoshape`‑[ITextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/) 
5. Ta bort standardstycket i `ITextFrame`.
6. Läs käll‑HTML‑filen med en TextReader.
7. Skapa det första stycket via klassen [Paragraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraph/).
8. Lägg till HTML‑filens innehåll från den lästa TextReader‑objektet till TextFrames [ParagraphCollection](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraphcollection/).
9. Spara den ändrade presentationen.

Denna C++‑kod är en implementation av stegen för att importera HTML‑texter i stycken: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Läs in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Hämta första bilden
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Lägg till en AutoShape av rektangulär typ
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Återställer standardfyllningsfärg
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Lägg till TextFrame till rektangeln
ashp->AddTextFrame(u" ");

// Hämtar textramen
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Hämta Paragraphs‑samlingen
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Rensar alla stycken i den tillagda textramen
ParaCollection->Clear();

// Laddar HTML‑filen med StreamReader
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Lägger till text från HTML‑streamreader i textramen
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Skapa Paragraph‑objektet för textramen
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Skapa Portion‑objekt för stycket
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Hämta portionsformat
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Ställ in teckensnittet för portionen
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Ställ in fet stil för teckensnittet
pf->set_FontBold(NullableBool::True);

// Ställ in kursiv stil för teckensnittet
pf->set_FontItalic(NullableBool::True);

// Ställ in understrykning för teckensnittet
pf->set_FontUnderline(TextUnderlineType::Single);

// Ställ in teckensnittshöjd
pf->set_FontHeight(25);

// Ställ in teckensnittets färg
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Spara PPTX till disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);


```

## **Exportera stycketext till HTML**

Aspose.Slides erbjuder förbättrat stöd för att exportera texter (innehållande i stycken) till HTML.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/cpp/aspose.slides/presentation/) och läs in den önskade presentationen.
2. Hämta referensen till den relevanta bilden via dess index.
3. Hämta formen som innehåller texten som ska exporteras till HTML.
4. Hämta formens [TextFrame](https://reference.aspose.com/slides/sv/cpp/aspose.slides/itextframe/).
5. Skapa en instans av `StreamWriter` och lägg till den nya HTML‑filen.
6. Ange ett startindex till StreamWriter och exportera dina föredragna stycken.

Denna C++‑kod visar hur du exporterar PowerPoint‑stycketexter till HTML: 

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Sökvägen till dokumentkatalogen.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Läs in den önskade presentationen
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Hämta standardförsta bilden i presentationen
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Önskat index
int index = 0;

// Hämtar den tillagda formen
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extraherar första stycket som HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Skriver styckedata till HTML genom att ange stycke startindex, totalt antal stycken att kopiera
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Spara ett stycke som bild**

I detta avsnitt kommer vi att gå igenom två exempel som demonstrerar hur man sparar ett textstycke, representerat av gränssnittet [IParagraph](https://reference.aspose.com/slides/sv/cpp/aspose.slides/iparagraph/), som en bild. Båda exemplen inkluderar att hämta bilden av en form som innehåller stycket med `GetImage`‑metoderna från gränssnittet [IShape](https://reference.aspose.com/slides/sv/cpp/aspose.slides/ishape/), beräkna styckets gränser inom formen och exportera den som en bitmap‑bild. Dessa metoder låter dig extrahera specifika delar av texten från PowerPoint‑presentationer och spara dem som separata bilder, vilket kan vara användbart i olika scenario.

Anta att vi har en presentationsfil som heter sample.pptx med en bild, där den första formen är en textruta som innehåller tre stycken.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Example 1**

I det här exemplet hämtar vi det andra stycket som en bild. För att göra detta extraherar vi bildens bild från den första bilden i presentationen och beräknar sedan gränserna för det andra stycket i formens textram. Stycket ritas sedan om på en ny bitmap‑bild som sparas i PNG‑format. Denna metod är särskilt användbar när du behöver spara ett specifikt stycke som en separat bild samtidigt som du bevarar exakt dimension och formatering av texten.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Spara formen i minnet som en bitmap.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Skapa en bitmap för formen från minnet.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Beräkna gränserna för det andra stycket.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Beräkna storleken för utdatabilden (minsta storlek - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Förbered en bitmap för stycket.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Rita om stycket från formens bitmap till styckets bitmap.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Resultatet:

![The paragraph image](paragraph_to_image_output.png)

**Example 2**

I detta exempel bygger vi vidare på föregående metod genom att lägga till skalningsfaktorer till styckebilden. Formen extraheras från presentationen och sparas som en bild med en skalningsfaktor på `2`. Detta möjliggör en högre upplösning vid export av stycket. Styckets gränser beräknas sedan med hänsyn till skalan. Skalning kan vara särskilt användbart när en mer detaljerad bild behövs, till exempel för användning i högkvalitativt tryckt material.

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

**Kan jag helt inaktivera radbrytning i en textram?**

Ja. Använd textramens omslagningsmetod ([set_WrapText](https://reference.aspose.com/slides/sv/cpp/aspose.slides/textframeformat/set_wraptext/)) för att stänga av omslagning så att rader inte bryts vid ramens kanter.

**Hur kan jag få den exakta positionen på bilden för ett specifikt stycke?**

Du kan hämta stycke‑ (och till och med en enskild portions) omgivande rektangel för att känna till dess exakta position och storlek på bilden.

**Var styrs styckejustering (vänster/höger/centrerad/justerad)?**

[Alignment](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraphformat/set_alignment/) är en inställning på styckesnivå i [ParagraphFormat](https://reference.aspose.com/slides/sv/cpp/aspose.slides/paragraphformat/); den gäller hela stycket oavsett individuell portionsformatering.

**Kan jag ange ett stavningsspråk för bara en del av ett stycke (t.ex. ett ord)?**

Ja. Språket anges på portionsnivå med ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/sv/cpp/aspose.slides/baseportionformat/set_languageid/)), så flera språk kan finnas samtidigt i ett enda stycke.