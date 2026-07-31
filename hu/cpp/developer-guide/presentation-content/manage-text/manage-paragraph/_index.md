---
title: PowerPoint szövegbekezdések kezelése C++-ban
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/cpp/manage-paragraph/
aliases:
  - /cpp/paragraph/
  - /cpp/portion/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzása
- függő behúzás
- bekezdés felsorolás
- számozott lista
- pontozott lista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Mesteri bekezdésformázás az Aspose.Slides for C++-val - optimalizálja az igazítást, a távolságot és a stílust PPT, PPTX és ODP prezentációkban C++-ban."
---
## **Bevezetés**

Az Aspose.Slides minden interfészt és osztályt biztosít, amelyekre szüksége van a PowerPoint szövegek, bekezdések és részek C++‑ban történő kezeléséhez.

* Az Aspose.Slides biztosítja az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek egy bekezdést képviselnek. Egy `ITextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek részeket képviselnek. Egy `IParagraph` objektum egy vagy több részt (az iPortions objektumok gyűjteményét) tartalmazhat.
* Az Aspose.Slides biztosítja az [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) interfészt, amely lehetővé teszi, hogy olyan objektumokat adjunk hozzá, amelyek szövegeket és azok formázási tulajdonságait képviselik.

Egy `IParagraph` objektum képes különböző formázási tulajdonságokkal rendelkező szövegek kezelésére az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása, amely több részt tartalmaz**

Az alábbi lépések megmutatják, hogyan adjon hozzá egy szövegkeretet, amely 3 bekezdést, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzatot a diára.
4. Szerezze meg az ITextFrame-et, amely a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzathoz tartozik.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumot, és adja hozzá őket az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) `IParagraphs` gyűjteményéhez.
6. Hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) objektumot minden új `IParagraph` számára (két Portion objektum az alapértelmezett bekezdéshez), és adja hozzá az egyes `IPortion` objektumokat minden `IParagraph` IPortion gyűjteményéhez.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási beállításokat minden részre a `IPortion` objektum által biztosított formázási tulajdonságok segítségével.
9. Mentse a módosított prezentációt.

Ez a C++ kód a bekezdések és részek hozzáadásának lépéseinek megvalósítása:

```c++
// Az adatkönyvtár elérési útja.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Automatikus alakzat hozzáadása téglalap típusban
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Szövegkeret hozzáadása a téglalaphoz
SharedPtr<ITextFrame> tf=ashp->AddTextFrame(u" ");


// Az első bekezdés elérése
SharedPtr<IParagraph> para0 = tf->get_Paragraphs()->idx_get(0);
	
SharedPtr<Portion> port01 = MakeObject<Portion>();
SharedPtr<Portion> port02 = MakeObject<Portion>();
para0->get_Portions()->Add(port01);
para0->get_Portions()->Add(port02);

// Második bekezdés hozzáadása
SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
tf->get_Paragraphs()->Add(para1);
SharedPtr<Portion> port10 = MakeObject<Portion>();
SharedPtr<Portion> port11 = MakeObject<Portion>();
SharedPtr<Portion> port12 = MakeObject<Portion>();
para1->get_Portions()->Add(port10);
para1->get_Portions()->Add(port11);
para1->get_Portions()->Add(port12);

// Harmadik bekezdés hozzáadása
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

// PPTX mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bekezdés-felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A felsorolt bekezdések mindig könnyebben olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzatot a kiválasztott diához.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály használatával.
7. Állítsa be a bekezdés bullet `Type` értékét `Symbol`‑ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés `Text` értékét.
9. Állítsa be a bekezdés `Indent` értékét a bullethez.
10. Állítson be színt a bullethez.
11. Állítson be magasságot a bulletnek.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑től 13‑ig lépéseket.
14. Mentse a prezentációt.

Ez a C++ kód megmutatja, hogyan adjon hozzá egy bekezdés bullet‑t:

```c++
// Az adatkönyvtár elérési útja.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// A kívánt prezentáció betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Téglalap típusú AutoShape hozzáadása
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Szövegkeret hozzáadása a téglalaphoz
ashp->AddTextFrame(u"");

// A szövegkeret elérése
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// Bekezdés objektum létrehozása a szövegkerethez
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Szöveg beállítása
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Felsorolás behúzásának beállítása
paragraph->get_ParagraphFormat()->set_Indent (25);

// Felsorolás színének beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// Az IsBulletHardColor beállítása true értékre a saját felsorolásszín használatához
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Felsorolás magasságának beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Bekezdés hozzáadása a szövegkerethez
txtFrame->get_Paragraphs()->Add(paragraph);

// Második bekezdés létrehozása
// Bekezdés objektum létrehozása a szövegkerethez
SharedPtr<Paragraph> paragraph2 = MakeObject<Paragraph>();

// Szöveg beállítása
paragraph2->set_Text(u"This is numbered bullet");

// Bekezdés felsorolás típusának és stílusának beállítása
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Type ( BulletType::Numbered);
paragraph2->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle ( NumberedBulletStyle::BulletCircleNumWDBlackPlain);

// Felsorolás behúzásának beállítása
paragraph2->get_ParagraphFormat()->set_Indent(25);

// Felsorolás színének beállítása
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
paragraph2->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());

// Az IsBulletHardColor beállítása true értékre a saját felsorolásszín használatához
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Felsorolás magasságának beállítása
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Bekezdés hozzáadása a szövegkerethez
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Képes felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A képes bekezdések könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzatot a diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ből.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály használatával.
7. Töltse be a képet a [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) segítségével.
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/)‑ra, és adja meg a képet.
9. Állítsa be a Paragraph `Text` értékét.
10. Állítsa be a Paragraph `Indent` értékét a bullethez.
11. Állítson be színt a bullethez.
12. Állítson be magasságot a bulletnek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdésgyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a korábbi lépések alapján.
15. Mentse a módosított prezentációt.

Ez a C++ kód megmutatja, hogyan adjon hozzá és kezeljen képes bullet‑eket:

```c++
// Létrehozza a Presentation osztályt, amely egy PPTX fájlt képvisel
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Eléri az első diát
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Létrehozza a felsoroláshoz használt képet
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Hozzáadja és eléri az Autoshape-et
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Eléri az autoshape szövegkeretét
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Eltávolítja az alapértelmezett bekezdést
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Létrehoz egy új bekezdést
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Beállítja a bekezdés bullet stílusát és képét
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// Beállítja a bullet magasságát
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Hozzáadja a bekezdést a szövegkerethez
paragraphs->Add(paragraph);

// A prezentációt PPTX fájlként menti
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// A prezentációt PPT fájlként menti
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Többszintű felsorolások kezelése**

A felsorolások segítenek gyorsan és hatékonyan rendszerezni és bemutatni az információkat. A többszintű bulletok könnyen olvashatók és érthetők.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet az új diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`-ben.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével, és állítsa be a mélységet 0‑ra.
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 1‑re.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 2‑re.
9. Hozza létre a negyedik bekezdést a `Paragraph` osztály segítségével, és állítsa be a mélységet 3‑ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
11. Mentse a módosított prezentációt.

Ez a C++ kód megmutatja, hogyan adjon hozzá és kezeljen többszintű bullet‑eket:

```c++
// Példányosít egy Presentation osztályt, amely egy PPTX fájlt képvisel
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Eléri az első diát
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Hozzáadja és eléri az Autoshape-et
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Eléri a létrehozott autoshape szövegkeretét
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Törli az alapértelmezett bekezdést
text->get_Paragraphs()->Clear();

// Hozzáadja az első bekezdést
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Beállítja a felsorolás szintjét
para1Format->set_Depth(0);

// Hozzáadja a második bekezdést
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Beállítja a felsorolás szintjét
para2Format->set_Depth(1);

// Hozzáadja a harmadik bekezdést
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Beállítja a felsorolás szintjét
para3Format->set_Depth(2);

// Hozzáadja a negyedik bekezdést
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// Beállítja a felsorolás szintjét
para4Format->set_Depth(3);

// Hozzáadja a bekezdéseket a gyűjteményhez
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// A prezentációt PPTX fájlként menti
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Egyéni számozott lista használatával történő bekezdéskezelés**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) tulajdonságot és másokat, amelyek lehetővé teszik a bekezdések egyéni számozású vagy formázott kezelését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a bekezdést tartalmazó diát.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzatot a diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a `TextFrame`‑ben.
6. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével, és állítsa be a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét 2‑re.
7. Hozza létre a második bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 3‑ra.
8. Hozza létre a harmadik bekezdést a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 7‑re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdésgyűjteményéhez.
10. Mentse a módosított prezentációt.

Ez a C++ kód megmutatja, hogyan adjon hozzá és kezeljen bekezdéseket egyéni számozással vagy formázással:

```c++
auto presentation = System::MakeObject<Presentation>();

auto shape = presentation->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Eléri a létrehozott autoshape szövegkeretét
System::SharedPtr<ITextFrame> textFrame = shape->get_TextFrame();

// Eltávolítja az alapértelmezett meglévő bekezdést
textFrame->get_Paragraphs()->RemoveAt(0);

// Első lista
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

## **Első sor behúzás beállítása egy bekezdéshez**

Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazodik.

Használja az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) metódust, ha a teljes bekezdést szeretné mozgatni. Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust, ha csak az első sort akarja mozgatni.

A lenti példa több bekezdést hoz létre, és különböző `Indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) elemet a alakzathoz, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állítson be bekezdésbehúzást:

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

![A bekezdések első sorának behúzása](first_line_indent.png)

## **Függő behúzás beállítása egy bekezdéshez**

A függő behúzás egy olyan bekezdéselrendezés, ahol az első sor balra kezdődik a többi sorhoz képest. Az Aspose.Slides‑ban ezt a hatást az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódussal hozhatja létre. Állítsa a behúzást negatív értékre, hogy az első sor a bekezdés testhez képest balra mozduljon.

Gyakorlatban az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) határozza meg a bekezdés test bal pozícióját, míg az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) határozza meg az első sor helyzetét a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és egyéb bekezdések esetén, ahol a sortöréses soroknak a bekezdés test alatt, nem pedig az első sor első karaktere alatt kell igazodniuk.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/) elemet a diához.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) elemet a alakzathoz, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket minden bekezdéshez.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értéket a függő behúzás hatásának létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állítson be függő behúzást egy bekezdéshez:

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

![A bekezdések függő behúzása](hanging_indent.png)

## **Befejező bekezdés futtatási tulajdonságok kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a bekezdést tartalmazó dia referenciáját a pozíciója alapján.
1. Adjon hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
1. Adjon hozzá egy [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemet két bekezdéssel a téglalaphoz.
1. Állítsa be a `FontHeight` és a betűtípus értékét a bekezdésekhez.
1. Állítsa be a bekezdések End tulajdonságait.
1. Írja ki a módosított prezentációt PPTX fájlként.

Ez a C++ kód megmutatja, hogyan állíthatja be a bekezdések End tulajdonságait a PowerPointban:

```c++
// Az adatkönyvtár elérési útja.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Téglalap típusú AutoShape hozzáadása
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// Szövegkeret hozzáadása a téglalaphoz
SharedPtr<ITextFrame> tf = ashp->AddTextFrame(String::Empty);

// Az első bekezdés hozzáadása
//SharedPtr<IParagraph> para1 = tf->get_Paragraphs()->idx_get(0);

SharedPtr<Paragraph> para1 = MakeObject<Paragraph>();
SharedPtr<Portion> port01 = MakeObject<Portion>(u"Sample text");

para1->get_Portions()->Add(port01);

// A második bekezdés hozzáadása
SharedPtr<Paragraph> para2 = MakeObject<Paragraph>();
SharedPtr<Portion> port02 = MakeObject<Portion>(u"Sample text 2");

para2->get_Portions()->Add(port02);


SharedPtr<PortionFormat> endParagraphPortionFormat = MakeObject< PortionFormat>();
endParagraphPortionFormat->set_FontHeight ( 48);
endParagraphPortionFormat->set_LatinFont ( MakeObject< FontData>(u"Times New Roman"));
para2->set_EndParagraphPortionFormat(endParagraphPortionFormat);

ashp->get_TextFrame()->get_Paragraphs()->Add(para1);
ashp->get_TextFrame()->get_Paragraphs()->Add(para2);



// PPTX mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides kibővített támogatást nyújt a HTML szöveg bekezdésekbe történő importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) alakzatot a diára.
4. Adjon hozzá és érje el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemet.
5. Távolítsa el az alapértelmezett bekezdést a `ITextFrame`‑ből.
6. Olvassa be a forrás HTML fájlt egy TextReader‑ben.
7. Hozza létre az első bekezdést a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével.
8. Adja hozzá a beolvasott TextReader HTML tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphcollection/) gyűjteményéhez.
9. Mentse a módosított prezentációt.

Ez a C++ kód a lépések megvalósítása a HTML szövegek bekezdésekbe importálásához:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// Az adatkönyvtár elérési útja.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Eléri az első diát
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Téglalap típusú AutoShape hozzáadása
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
// Alapértelmezett kitöltőszín visszaállítása
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// Szövegkeret hozzáadása a téglalaphoz
ashp->AddTextFrame(u" ");

// A szövegkeret elérése
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

// Bekezdések gyűjteményének lekérése
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Az hozzáadott szövegkeret összes bekezdésének törlése
ParaCollection->Clear();

// HTML fájl betöltése stream olvasóval
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Szöveg hozzáadása a HTML stream olvasóból a szövegkerethez
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Bekezdés objektum létrehozása a szövegkerethez
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Rész objektum létrehozása a bekezdéshez
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

// Rész formátumának lekérése
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// Betűkészlet beállítása a részhez
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// A betű félkövér tulajdonságának beállítása
pf->set_FontBold(NullableBool::True);

// A betű dőlt tulajdonságának beállítása
pf->set_FontItalic(NullableBool::True);

// A betű aláhúzott tulajdonságának beállítása
pf->set_FontUnderline(TextUnderlineType::Single);

// A betű magasságának beállítása
pf->set_FontHeight(25);

// A betű színének beállítása
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bekezdés szöveg exportálása HTML‑be**

Az Aspose.Slides kibővített támogatást nyújt a szövegek (bekezdésekben található) HTML‑be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Érje el a megfelelő dia referenciaját a sorszámán keresztül.
3. Érje el a szöveget tartalmazó alakzatot, amelyet HTML‑be exportálunk.
4. Érje el az alakzat [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML fájlt.
6. Adjon meg egy kezdő indexet a StreamWriternek, és exportálja a kívánt bekezdéseket.

Ez a C++ kód megmutatja, hogyan exportálja a PowerPoint bekezdésszövegeket HTML‑be:

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// Betölti a kívánt prezentációt
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Hozzáfér az alapértelmezett első diához a prezentációban
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Kívánt index
int index = 0;

// Hozzáfér a hozzáadott alakzathoz
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Az első bekezdés kinyerése HTML-ként
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//	System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Bekezdések adatainak írása HTML-be a bekezdés kezdő indexének és a másolandó bekezdések számának megadásával
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();

```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát vizsgálunk meg, amelyek bemutatják, hogyan menthetünk el egy szövegbekezdést, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példa tartalmazza a bekezdést tartalmazó alakzat képének lekérését a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfész `GetImage` metódusaival, a bekezdés alakzaton belüli határainak kiszámítását, és a bitmap képként való exportálást. Ezek a megközelítések lehetővé teszik a PowerPoint prezentációkból származó szöveg konkrét részeinek kivonását és különálló képként történő mentését, ami különböző forgatókönyvekben hasznos lehet.

Tegyük fel, hogy van egy sample.pptx nevű prezentációs fájlunk egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdéses szövegdoboz](paragraph_to_image_input.png)

**Example 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez kinyerjük az alakzat képét a prezentáció első diájáról, majd kiszámítjuk a második bekezdés határait az alakzat szövegkeretében. Ezután a bekezdést egy új bitmap képre rajzoljuk, amely PNG formátumban kerül mentésre. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként kell menteni, miközben megőrzük a szöveg pontos méreteit és formázását.

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

![A bekezdés képe](paragraph_to_image_output.png)

**Example 2**

Ebben a példában a korábbi megközelítést kiterjesztjük a bekezdés képére méretezési tényezők hozzáadásával. Az alakzatot a prezentációból kinyerjük, és `2` méretezési tényezővel képként mentjük. Ez magasabb felbontású kimenetet tesz lehetővé a bekezdés exportálásakor. A bekezdés határait ezután a méretezés figyelembevételével számítjuk ki. A méretezés különösen hasznos, ha részletesebb kép szükséges, például magas minőségű nyomtatott anyagokhoz.

```cpp
auto imageScaleX = 2.0f;
auto imageScaleY = imageScaleX;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto firstShape = ExplicitCast<IAutoShape>(presentation->get_Slide(0)->get_Shape(0));

// A formát memóriában bitmapként menti skálázással.
auto shapeImage = firstShape->GetImage(ShapeThumbnailBounds::Shape, imageScaleX, imageScaleY);
auto shapeImageStream = MakeObject<MemoryStream>();
shapeImage->Save(shapeImageStream, ImageFormat::Png);
shapeImage->Dispose();

// Bitmapot hoz létre a formából a memóriából.
shapeImageStream->set_Position(0);
auto shapeBitmap = MakeObject<Bitmap>(Image::FromStream(shapeImageStream));

// Kiszámítja a második bekezdés határait.
auto secondParagraph = firstShape->get_TextFrame()->get_Paragraph(1);
auto paragraphRectangle = secondParagraph->GetRect();
paragraphRectangle.set_X(paragraphRectangle.get_X() * imageScaleX);
paragraphRectangle.set_Y(paragraphRectangle.get_Y() * imageScaleY);
paragraphRectangle.set_Width(paragraphRectangle.get_Width() * imageScaleX);
paragraphRectangle.set_Height(paragraphRectangle.get_Height() * imageScaleY);

// Kiszámítja a kimeneti kép méretét (minimum méret – 1x1 pixel).
auto imageWidth = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Width()));
auto imageHeight = std::max(1, (int)Math::Ceiling(paragraphRectangle.get_Height()));

// Előkészít egy bitmapot a bekezdéshez.
auto paragraphBitmap = MakeObject<Bitmap>(imageWidth, imageHeight);

// Újrarajzolja a bekezdést a forma bitmapjából a bekezdés bitmapjába.
auto imageGraphics = Graphics::FromImage(paragraphBitmap.get());
RectangleF drawingRectangle(0, 0, paragraphRectangle.get_Width(), paragraphRectangle.get_Height());
imageGraphics->DrawImage(shapeBitmap.get(), drawingRectangle, paragraphRectangle, GraphicsUnit::Pixel);
imageGraphics->Dispose();

paragraphBitmap->Save(u"paragraph.png", Imaging::ImageFormat::get_Png());

presentation->Dispose();
```

## **FAQ**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**

Igen. Használja a szövegkeret körbefuttatás‑metódusát ([set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_wraptext/)), hogy kikapcsolja a tördelést, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos, dián lévő határait?**

Lekérheti a bekezdés (vagy akár egyetlen rész) határoló téglalapját, hogy megtudja a pontos pozícióját és méretét a dián.

**Hol szabályozható a bekezdés igazítása (balra/jobbra/középre/széthúzott)?**

[Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/set_alignment/) egy bekezdés‑szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/)‑ben; a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**

Igen. A nyelvet a rész szintjén állíthatja be a ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/)) segítségével, így több nyelv is együtt létezhet egy bekezdésen belül.