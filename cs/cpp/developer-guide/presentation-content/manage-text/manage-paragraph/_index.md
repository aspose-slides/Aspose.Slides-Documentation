---
title: Správa odstavců textu PowerPoint v C++
linktitle: Správa odstavce
type: docs
weight: 40
url: /cs/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
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
description: "Mistrovské formátování odstavců s Aspose.Slides pro C++ — optimalizujte zarovnání, rozestupy a styl v prezentacích PPT, PPTX a ODP v C++."
---
## **Úvod**

Aspose.Slides poskytuje všechny rozhraní a třídy, které potřebujete pro práci s texty, odstavci a částmi v PowerPointu v C++.

* Aspose.Slides poskytuje rozhraní [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) umožňující přidávat objekty reprezentující odstavec. Objekt `ITextFame` může obsahovat jeden nebo více odstavců (každý odstavec se vytvoří pomocí návratu vozíku).
* Aspose.Slides poskytuje rozhraní [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) umožňující přidávat objekty reprezentující části. Objekt `IParagraph` může mít jednu nebo více částí (kolekci objektů iPortions).
* Aspose.Slides poskytuje rozhraní [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) umožňující přidávat objekty reprezentující texty a jejich vlastnosti formátování. 

Objekt `IParagraph` dokáže zpracovávat texty s různými vlastnostmi formátování prostřednictvím svých podřazených objektů `IPortion`.

## **Přidání více odstavců obsahujících více částí**

Tyto kroky ukazují, jak přidat textové pole obsahující 3 odstavce a každý odstavec obsahující 3 části:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte obdélníkový [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Získejte `ITextFrame` přidružený k [IAutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/).
5. Vytvořte dva objekty [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) a přidejte je do kolekce `IParagraphs` objektu [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).
6. Pro každý nový `IParagraph` vytvořte tři objekty [IPortion](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iportion/) (dvě objekty Portion pro výchozí odstavec) a přidejte každý objekt `IPortion` do kolekce IPortion příslušného `IParagraph`.
7. Nastavte text pro každou část.
8. Použijte požadované vlastnosti formátování na každou část pomocí vlastností formátování exponovaných objektem `IPortion`.
9. Uložte upravenou prezentaci.

Tento C++ kód je implementací výše uvedených kroků pro přidání odstavců obsahujících části:

```c++
// Cesta k adresáři s dokumenty.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Načtěte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získat první snímek
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidejte AutoShape typu Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Přidejte TextFrame do obdélníku
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

Odrážkové seznamy vám pomáhají rychle a efektivně organizovat a prezentovat informace. Odrážkové odstavce jsou vždy snadněji čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na vybraný snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
7. Nastavte pro odstavec typ odrážky `Type` na `Symbol` a určete znak odrážky.
8. Nastavte text odstavce.
9. Nastavte odsazení `Indent` odrážky pro odstavec.
10. Nastavte barvu odrážky.
11. Nastavte výšku odrážky.
12. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
13. Přidejte druhý odstavec a opakujte proces uvedený v krocích 7‑13.
14. Uložte prezentaci.

Tento C++ kód ukazuje, jak přidat odrážku odstavce:

```c++
// Cesta k adresáři s dokumenty.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// Načtěte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Získat první snímek
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidejte AutoShape typu Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Přidejte TextFrame do obdélníku
ashp->AddTextFrame(u"");

// Přístup k textovému rámci
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Vytvořte objekt Paragraph pro textový rámec
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
// Vytvořte objekt Paragraph pro textový rámec
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

Odrážkové seznamy vám pomáhají rychle a efektivně organizovat a prezentovat informace. Obrázkové odstavce jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
7. Načtěte obrázek v [IPPImage](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/).
8. Nastavte typ odrážky na [Picture](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ippimage/) a přiřaďte obrázek.
9. Nastavte text odstavce.
10. Nastavte odsazení `Indent` odrážky pro odstavec.
11. Nastavte barvu odrážky.
12. Nastavte výšku odrážky.
13. Přidejte nový odstavec do kolekce odstavců `TextFrame`.
14. Přidejte druhý odstavec a zopakujte postup podle předchozích kroků.
15. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak přidat a spravovat obrázkové odrážky:

```c++
// Vytváří objekt třídy Presentation, který představuje soubor PPTX
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Vytváří obrázek pro odrážky
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Přidá a získá Autoshape
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Získá textový rámec autoshape
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

// Uloží prezentaci jako soubor PPTX
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// Uloží prezentaci jako soubor PPT
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Správa víceúrovňových odrážek**

Odrážkové seznamy vám pomáhají rychle a efektivně organizovat a prezentovat informace. Víceúrovňové odrážky jsou snadno čitelné a pochopitelné.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na nový snímek.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) autoshape.
5. Odstraňte výchozí odstavec v `TextFrame`.
6. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/) a nastavte hloubku na 0.
7. Vytvořte druhý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 1.
8. Vytvořte třetí odstavec pomocí třídy `Paragraph` a nastavte hloubku na 2.
9. Vytvořte čtvrtý odstavec pomocí třídy `Paragraph` a nastavte hloubku na 3.
10. Přidejte nové odstavce do kolekce odstavců `TextFrame`.
11. Uložte upravenou prezentaci.

Tento C++ kód ukazuje, jak přidat a spravovat víceúrovňové odrážky:

```c++
// Vytvoří objekt třídy Presentation, který představuje soubor PPTX
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Přidá a získá Autoshape
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Získá textový rámec vytvořeného autoshape
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

// Uloží prezentaci jako soubor PPTX
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Správa odstavce s vlastní číslovanou seznamovou položkou**

Rozhraní [IBulletFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/) poskytuje vlastnost [NumberedBulletStartWith](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) a další, které umožňují spravovat odstavce s vlastním číslováním nebo formátováním. 

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

Tento C++ kód ukazuje, jak přidat a spravovat odstavce s vlastním číslováním nebo formátováním:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Přistupuje k textovému rámci vytvořeného autoshape
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Odstraňuje výchozí existující odstavec
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

Použijte metodu [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) k řízení odsazení první řádky odstavce. Tato metoda posune jen první řádek vůči levému okraji odstavce. Kladná hodnota posune první řádek doprava, zatímco zbylé řádky zůstávají zarovnané ke tělu odstavce.

Použijte [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/) když potřebujete posunout celý odstavec. Použijte [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) když chcete posunout pouze první řádek.

Níže uvedený příklad vytváří několik odstavců a aplikuje různé hodnoty `Indent`, aby ukázal, jak odsazení první řádky ovlivňuje rozvržení odstavce.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte několik odstavců a nastavte pro ně různé hodnoty [Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/).
6. Přidejte odstavce do textového rámce.
7. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit odsazení odstavce:

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

Výsledek:

![Odsazení první řádky odstavců](first_line_indent.png)

## **Nastavení závěsného odsazení odstavce**

Závěsné odsazení je rozvržení odstavce, ve kterém první řádek začíná vlevo od zbytku řádků. V Aspose.Slides vytvoříte tento efekt pomocí metody [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/). Nastavte odsazení na zápornou hodnotu, aby se první řádek posunul doleva vůči tělu odstavce.

V praxi [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/) určuje levý okraj těla odstavce a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) určuje pozici první řádky relativně k tomuto okraji. Pro vytvoření závěsného odsazení nastavte kladnou hodnotu `MarginLeft` a zápornou hodnotu `Indent`.

Toto formátování je užitečné pro bibliografie, reference, položky glosáře a jiné odstavce, kde mají zabalené řádky zarovnány pod tělo odstavce, nikoli pod první znak první řádky.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
2. Získejte cílový snímek.
3. Přidejte obdélníkový [AutoShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/autoshape/) na snímek.
4. Přidejte prázdný [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframe/) do tvaru a odstraňte výchozí odstavec.
5. Vytvořte odstavce a nastavte pro každý kladnou hodnotu [MarginLeft](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_marginleft/).
6. Nastavte zápornou hodnotu [Indent](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraphformat/set_indent/) pro vytvoření efektu závěsného odsazení.
7. Přidejte odstavce do textového rámce.
8. Uložte upravenou prezentaci.

Tento kód ukazuje, jak nastavit závěsné odsazení odstavce:

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

Výsledek:

![Závěsné odsazení odstavců](hanging_indent.png)

## **Správa koncových vlastností odstavce (End Paragraph Run Properties)**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/).
1. Získejte odkaz na snímek obsahující odstavec podle jeho pozice.
1. Přidejte obdélníkový [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
1. Přidejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) se dvěma odstavci do obdélníku.
1. Nastavte `FontHeight` a typ písma pro odstavce.
1. Nastavte koncové (End) vlastnosti pro odstavce.
1. Uložte upravenou prezentaci jako soubor PPTX.

Tento C++ kód ukazuje, jak nastavit koncové vlastnosti odstavců v PowerPointu:

```c++
// Cesta k adresáři s dokumenty.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Načtěte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidá AutoShape typu Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Přidá TextFrame do obdélníku
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
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Přidejte [autoshape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iautoshape/) na snímek.
4. Přidejte a získejte `autoshape` [ITextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/).
5. Odstraňte výchozí odstavec v `ITextFrame`.
6. Načtěte zdrojový HTML soubor pomocí `TextReader`.
7. Vytvořte první odstavec pomocí třídy [Paragraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraph/).
8. Přidejte obsah HTML souboru načtený `TextReader` do kolekce [ParagraphCollection](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphcollection/) textového rámce.
9. Uložte upravenou prezentaci.

Tento C++ kód je implementací kroků pro import HTML textů do odstavců:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Cesta k adresáři s dokumenty.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Načtěte požadovanou prezentaci
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Přistupuje k prvnímu snímku
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Přidá AutoShape typu Rectangle
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Resetování výchozí barvy výplně
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Přidá TextFrame do obdélníku
ashp->AddTextFrame(u" ");

// Přístup k textovému rámci
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs collection
// Získání kolekce odstavců
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Clearing all paragraphs in added text frame
// Vymazání všech odstavců v přidaném textovém rámci
ParaCollection->Clear();

// Loading the HTML file using stream reader
// Načítání HTML souboru pomocí stream readeru
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Adding text from HTML stream reader in text frame
// Přidání textu z HTML stream readeru do textového rámce
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Create the Paragraph object for text frame
// Vytvoření objektu Paragraph pro textový rámec
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Create Portion object for paragraph
// Vytvoření objektu Portion pro odstavec
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
// Získání formátu části
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Set the Font for the Portion
// Nastavení fontu pro část
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// Set Bold property of the Font
// Nastavení vlastnosti tučné písmo pro font
pf->set_FontBold(NullableBool::True);

// Set Italic property of the Font
// Nastavení vlastnosti kurzíva pro font
pf->set_FontItalic(NullableBool::True);

// Set Underline property of the Font
// Nastavení vlastnosti podtržení pro font
pf->set_FontUnderline(TextUnderlineType::Single);

// Set the Height of the Font
// Nastavení výšky fontu
pf->set_FontHeight(25);

// Set the color of the Font
// Nastavení barvy fontu
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// Save PPTX to Disk
// Uložení PPTX na disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Export textu odstavce do HTML**

Aspose.Slides poskytuje rozšířenou podporu pro export textů (obsažených v odstavcích) do HTML.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/cpp/aspose.slides/presentation/) a načtěte požadovanou prezentaci.
2. Získejte odkaz na požadovaný snímek pomocí jeho indexu.
3. Získejte tvar obsahující text, který bude exportován do HTML.
4. Získejte [TextFrame](https://reference.aspose.com/slides/cs/cpp/aspose.slides/itextframe/) tvaru.
5. Vytvořte instanci `StreamWriter` a otevřete nový HTML soubor.
6. Poskytněte počáteční index `StreamWriter` a exportujte požadované odstavce.

Tento C++ kód ukazuje, jak exportovat texty odstavců PowerPointu do HTML:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Cesta k adresáři s dokumenty.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Načtěte požadovanou prezentaci
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
//  System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Zapisování dat odstavců do HTML zadáním počátečního indexu odstavce a celkového počtu odstavců ke zkopírování
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Uložení odstavce jako obrázku**

V této sekci představíme dva příklady, které ukazují, jak uložit textový odstavec reprezentovaný rozhraním [IParagraph](https://reference.aspose.com/slides/cs/cpp/aspose.slides/iparagraph/) jako obrázek. Oba příklady zahrnují získání obrázku tvaru obsahujícího odstavec pomocí metod `GetImage` rozhraní [IShape](https://reference.aspose.com/slides/cs/cpp/aspose.slides/ishape/), výpočet ohraničení odstavce v rámci tvaru a export jako bitmapového obrázku. Tyto přístupy umožňují extrahovat konkrétní části textu z PowerPoint prezentací a uložit je jako samostatné obrázky, což může být užitečné pro další použití v různých scénářích.

Předpokládejme, že máme soubor prezentace nazvaný sample.pptx s jedním snímkem, kde je první tvar textové oblasti obsahující tři odstavce.

![Textová oblast se třemi odstavci](paragraph_to_image_input.png)

**Příklad 1**

V tomto příkladu získáme druhý odstavec jako obrázek. K tomu extrahujeme obrázek tvaru z prvního snímku prezentace a následně vypočítáme ohraničení druhého odstavce v textovém rámci tvaru. Odstavec je pak vykreslen na nový bitmapový obrázek, který se uloží ve formátu PNG. Tento postup je zvláště užitečný, když potřebujete uložit konkrétní odstavec jako samostatný obrázek při zachování přesných rozměrů a formátování textu.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// Uložit tvar do paměti jako bitmapu.
auto shapeImage = firstShape->GetImage();
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Vytvořit bitmapu tvaru z paměti.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Vypočítat ohraničení druhého odstavce.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();

// Vypočítat velikost výstupního obrázku (minimální velikost - 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Připravit bitmapu pro odstavec.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Překreslit odstavec z bitmapy tvaru do bitmapy odstavce.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

Výsledek:

![Obrázek odstavce](paragraph_to_image_output.png)

**Příklad 2**

V tomto příkladu rozšiřujeme předchozí přístup o faktory měřítka obrázku odstavce. Tvar je extrahován z prezentace a uložen jako obrázek s měřítkovým faktorem `2`. To umožňuje získat výstup s vyšším rozlišením při exportu odstavce. Ohraničení odstavce jsou pak vypočítána s ohledem na měřítko. Škálování může být zvláště užitečné, když je potřeba detailnější obrázek, například pro použití v vysoce kvalitních tištěných materiálech.

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

## **Časté dotazy (FAQ)**

**Mohu zcela zakázat zalamování řádků uvnitř textového rámce?**

Ano. Použijte metodu pro zalamování textového rámce ([set_WrapText](https://reference.aspose.com/slides/cs/cpp/aspose.slides/textframeformat/set_wraptext/)) a vypněte zalamování, aby řádky nebyly rozdělovány na okrajích rámce.

**Jak získám přesné ohraničení konkrétního odstavce na snímku?**

Můžete získat obdélník ohraničující odstavec (a dokonce i jednotlivou část), abyste znali jeho přesnou pozici a velikost na snímku.

**Kde se řídí zarovnání odstavce (levé/pravé/střed/justify)?**

[Alignment](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphformat/set_alignment/) je nastavení na úrovni odstavce v [ParagraphFormat](https://reference.aspose.com/slides/cs/cpp/aspose.slides/paragraphformat/); platí pro celý odstavec bez ohledu na formátování jednotlivých částí.

**Mohu nastavit jazyk kontroly pravopisu jen pro část odstavce (např. pro jedno slovo)?**

Ano. Jazyk se nastavuje na úrovni části pomocí ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/cs/cpp/aspose.slides/baseportionformat/set_languageid/)), takže v jednom odstavci mohou koexistovat různé jazyky.