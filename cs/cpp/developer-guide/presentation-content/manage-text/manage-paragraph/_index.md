---
title: Správa textových odstavců PowerPoint v C++
linktitle: Spravovat odstavec
type: docs
weight: 40
url: /cs/cpp/manage-paragraph/
keywords:
- přidat text
- přidat odstavec
- spravovat text
- spravovat odstavec
- spravovat odrážku
- odsazení odstavce
- závěsné odsazení
- odrážka odstavce
- číslovaný seznam
- seznam s odrážkami
- vlastnosti odstavce
- import HTML
- text do HTML
- odstavec do HTML
- odstavec na obrázek
- text na obrázek
- exportovat odstavec
- PowerPoint
- OpenDocument
- prezentace
- C++
- Aspose.Slides
description: "Ovladněte formátování odstavců pomocí Aspose.Slides pro C++ - optimalizujte zarovnání, mezery a styl v prezentacích PPT, PPTX a ODP v C++."
---
## **Úvod**

Aspose.Slides poskytuje všechny rozhraní a třídy, které potřebujete k práci s texty, odstavci a částmi v PowerPointu v C++.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) , které vám umožňuje přidávat objekty představující odstavec. Objekt `ITextFame` může mít jeden nebo více odstavců (každý odstavec se vytvoří pomocí konce řádku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) , které vám umožňuje přidávat objekty představující části. Objekt `IParagraph` může mít jednu nebo více částí (sbírku objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) , které vám umožňuje přidávat objekty představující texty a jejich vlastnosti formátování.

Objekt `IParagraph` je schopen zpracovávat texty s různými vlastnostmi formátování pomocí svých podřízených objektů `IPortion`.

## **Přidání vícero odstavců obsahujících vícero částí**

Tyto kroky ukazují, jak přidat textový rámec obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) do snímku.
4. Získejte ITextFrame přidružený k [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) a přidejte je do kolekce `IParagraphs` [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).
6. Vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) pro každý nový `IParagraph` (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion každého `IParagraph`.
7. Nastavte text pro každou část.
8. Použijte požadované vlastnosti formátování na každou část pomocí vlastností formátování exposeovaných objektem `IPortion`.
9. Uložte upravenou prezentaci.

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přístup k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Přidat TextFrame do obdélníku
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Přístup k prvnímu odstavci
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Přidání druhého odstavce
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Přidání třetího odstavce
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

// Uložit PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Správa odrážek odstavců**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážkové odstavce jsou vždy snazší číst a pochopit.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
7. Nastavte typ odrážky `Type` odstavce na `Symbol` a nastavte znak odrážky.
8. Nastavte `Text` odstavce.
9. Nastavte `Indent` odstavce pro odrážku.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte proces uvedený v krocích 7 až 13.
14. Uložte prezentaci.

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přístup k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Přidat TextFrame do obdélníku
ashp->AddTextFrame(u"");

// Přístup k textovému rámci
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Vytvořit objekt odstavce pro textový rámec
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Nastavení textu
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Nastavení odsazení odrážky
paragraph->get_ParagraphFormat()->set_Indent (25);

// Nastavení barvy odrážky
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Nastavení výšky odrážky
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Přidání odstavce do textového rámce
txtFrame->get_Paragraphs()->Add(paragraph);

// Vytvoření druhého odstavce
// Vytvořit objekt odstavce pro textový rámec
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Nastavení textu
paragraph2->set_Text(u"This is numbered bullet");

// Nastavení typu a stylu odrážky odstavce
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Nastavení odsazení odrážky
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Nastavení barvy odrážky
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// nastavit IsBulletHardColor na true pro použití vlastní barvy odrážky
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Nastavení výšky odrážky
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Přidání odstavce do textového rámce
txtFrame->get_Paragraphs()->Add(paragraph2);


// Uložit PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Správa obrázkových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Obrázkové odstavce jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první instanci odstavce pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
7. Načtěte obrázek pomocí [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) a nastavte obrázek.
9. Nastavte `Text` odstavce.
10. Nastavte `Indent` odstavce pro odrážku.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a opakujte proces na základě předchozích kroků.
15. Uložte upravenou prezentaci.

```c++
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Vytvoří instanci obrázku pro odrážky
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Přidá a získá přístup k AutoShape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Získá přístup k textovému rámci autoshape
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Odstraní výchozí odstavec
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Vytvoří nový odstavec
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Nastaví styl odrážky odstavce a obrázek
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Nastaví výšku odrážky
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Přidá odstavec do textového rámce
paragraphs->Add(paragraph);

// Zapíše prezentaci jako soubor PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Zapíše prezentaci jako soubor PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Správa víceúrovňových odrážek**

Seznamy s odrážkami vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a srozumitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) do nového snímku.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

```c++
// Vytvoří instanci třídy Presentation, která představuje soubor PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Přidá a získá přístup k AutoShape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Získá přístup k textovému rámci vytvořeného AutoShape
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Vymaže výchozí odstavec
text->get_Paragraphs()->Clear();

// Přidá první odstavec
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Nastaví úroveň odrážky
para1Format->set_Depth(0);

// Přidá druhý odstavec
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Nastaví úroveň odrážky
para2Format->set_Depth(1);

// Přidá třetí odstavec
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Nastaví úroveň odrážky
para3Format->set_Depth(2);

// Přidá čtvrtý odstavec
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Nastaví úroveň odrážky
para4Format->set_Depth(3);

// Přidá odstavce do kolekce
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// Zapíše prezentaci jako soubor PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Správa odstavce s vlastním číslovaným seznamem**

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a další, které vám umožňují spravovat odstavce s vlastním číslováním nebo formátováním.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) a nastavte [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) na 2.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 3.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte `NumberedBulletStartWith` na 7.
9. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
10. Uložte upravenou prezentaci.

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Získá přístup k textovému rámci vytvořeného autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Odstraní výchozí existující odstavec
textFrame->get_Paragraphs()->RemoveAt(0);

// První seznam
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

## **Nastavení odsazení první řádky odstavce**

Použijte metodu [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) k řízení odsazení první řádky odstavce. Tato metoda posune jen první řádek vzhledem k levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnané k tělu odstavce.

Použijte [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/) když potřebujete posunout celý odstavec. Použijte [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) když potřebujete posunout jen první řádek.

Příklad níže vytvoří několik odstavců a použije různé hodnoty `Indent` k demonstraci, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

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

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení závěsného odsazení odstavce**

Závěsné odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbytku řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul vlevo vzhledem k tělu odstavce.

V praxi [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/) určuje levý polohový okraj těla odstavce a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) určuje polohu první řádky vzhledem k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, reference, položky glosáře a další odstavce, kde musí být zalomené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý odstavec kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) pro vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

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

![Závěsné odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností běhu odstavce**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na snímek obsahující odstavec pomocí jeho pozice.
3. Přidejte obdélníkový [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) se dvěma odstavci do obdélníku.
5. Nastavte `FontHeight` a typ písma pro odstavce.
6. Nastavte koncové vlastnosti pro odstavce.
7. Zapište upravenou prezentaci jako soubor PPTX.

```c++
// Cesta k adresáři dokumentů.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přístup k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Přidat TextFrame do obdélníku
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Přidání prvního odstavce
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// Přidání druhého odstavce
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);


// Uložit PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Import HTML textu do odstavců**

Aspose.Slides poskytuje rozšířenou podporu pro import HTML textu do odstavců.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Přidejte a získejte přístup k `autoshape` [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec v `ITextFrame`.
6. Přečtěte zdrojový HTML soubor pomocí TextReaderu.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru ze čteného TextReaderu do [ParagraphCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphcollection/) TextFrame.
9. Uložte upravenou prezentaci.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Cesta k adresáři dokumentů.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přístup k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidat AutoShape typu Obdélník
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Resetování výchozí barvy výplně
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Přidat TextFrame do obdélníku
ashp->AddTextFrame(u" ");

// Přistupování k textovému rámci
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//Získání kolekce odstavců
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Vymazání všech odstavců v přidaném textovém rámci
ParaCollection->Clear();

// Načítání HTML souboru pomocí StreamReaderu
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Přidání textu z HTML stream readeru do textového rámce
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Vytvořit objekt odstavce pro textový rámec
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Vytvořit objekt části pro odstavec
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Získání formátu části
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Nastavit písmo pro část
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Nastavit tučný styl písma
pf->set_FontBold(NullableBool::True);

// Nastavit kurzívu písma
pf->set_FontItalic(NullableBool::True);

// Nastavit podtržení písma
pf->set_FontUnderline(TextUnderlineType::Single);

// Nastavit výšku písma
pf->set_FontHeight(25);

// Nastavit barvu písma
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Uložit PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na příslušný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a přidejte nový HTML soubor.
6. Poskytněte počáteční index StreamWriteru a exportujte požadované odstavce.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Cesta k adresáři dokumentů.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Načíst požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Přístup k výchozímu prvnímu snímku prezentace
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Požadovaný index
int index = 0;

// Přístup k přidanému tvaru
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Extrahování prvního odstavce jako HTML
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Zapisování dat odstavců do HTML poskytnutím počátečního indexu odstavce a celkového počtu odstavců k zkopírování
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Uložení odstavce jako obrázku**

Obě ukázky zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `GetImage` z rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/) , výpočet ohraničení odstavce v rámci tvaru a export jako bitmapového obrázku. Tyto přístupy vám umožňují extrahovat konkrétní části textu z PowerPoint prezentací a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové pole obsahující tři odstavce.

![Textové pole se třemi odstavci](paragraph_to_image_input.png)

**Example 1**

V tomto příkladu získáme druhý odstavec jako obrázek. Provedeme to tak, že extrahujeme obrázek tvaru z prvního snímku prezentace a následně vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je pak překreslen na nový bitmapový obrázek, který je uložen ve formátu PNG. Tato metoda je zvláště užitečná, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

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

![Obrázek odstavce](paragraph_to_image_output.png)

**Example 2**

V tomto příkladu rozšiřujeme předchozí přístup přidáním škálovacích faktorů k obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek se škálovacím faktorem `2`. To umožňuje výstup ve vyšším rozlišení při exportu odstavce. Ohraničení odstavce je pak vypočítáno s ohledem na škálu. Škálování může být zvláště užitečné, když je potřeba podrobnější obrázek, například pro použití ve vysoce kvalitních tištěných materiálech.

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

## **Často kladené otázky**

**Mohu zcela vypnout zalamování řádků uvnitř textového rámce?**

Ano. Použijte metodu pro zalamování textového rámce ([set_WrapText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_wraptext/)) a vypněte zalamování, aby řádky nebyly přerušovány na okrajích rámce.

**Jak mohu získat přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat ohraničující obdélník odstavce (a dokonce i jednotlivé části), abyste znali jeho přesnou polohu a velikost na snímku.

**Kde se řídí zarovnání odstavce (vlevo/vpravo/na střed/justify)?**

Zarovnání je nastavení na úrovni odstavce v ParagraphFormat; vztahuje se na celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části pomocí (PortionFormat::set_LanguageId), takže v jednom odstavci mohou koexistovat různé jazyky.