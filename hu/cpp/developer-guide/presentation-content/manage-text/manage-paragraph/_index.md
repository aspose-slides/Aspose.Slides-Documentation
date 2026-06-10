---
title: PowerPoint szövegbekezdések kezelése C++-ban
linktitle: Bekezdés kezelése
type: docs
weight: 40
url: /hu/cpp/manage-paragraph/
keywords:
- szöveg hozzáadása
- bekezdés hozzáadása
- szöveg kezelése
- bekezdés kezelése
- felsorolás kezelése
- bekezdés behúzás
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
description: "Mesteri bekezdésformázás az Aspose.Slides for C++ segítségével – optimalizálja az igazítást, a sorközöket és a stílust PPT, PPTX és ODP prezentációkban C++-ban."
---
## **Bevezetés**

Az Aspose.Slides minden szükséges interfészt és osztályt biztosít a PowerPoint szövegek, bekezdések és részek C++-ban történő kezeléséhez.

* Az Aspose.Slides biztosítja az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) interfészt, amely lehetővé teszi bekezdést képviselő objektumok hozzáadását. Egy `ITextFame` objektum egy vagy több bekezdést tartalmazhat (minden bekezdés egy sortöréssel jön létre).
* Az Aspose.Slides biztosítja az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) interfészt, amely lehetővé teszi részeket képviselő objektumok hozzáadását. Egy `IParagraph` objektum egy vagy több részt tartalmazhat (az iPortions objektumok gyűjteménye).
* Az Aspose.Slides biztosítja az [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) interfészt, amely lehetővé teszi a szöveget és annak formázási tulajdonságait képviselő objektumok hozzáadását.

Egy `IParagraph` objektum képes a szövegeket különböző formázási tulajdonságokkal kezelni az alatta lévő `IPortion` objektumok segítségével.

## **Több bekezdés hozzáadása, amelyek több részt tartalmaznak**

Az alábbi lépések bemutatják, hogyan adhatunk hozzá egy szövegkeretet, amely 3 bekezdést tartalmaz, és minden bekezdés 3 részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Adjon hozzá egy téglalap [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/)-hez társított ITextFrame-et.
5. Hozzon létre két [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumot, és adja hozzá a [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) `IParagraphs` gyűjteményéhez.
6. Minden új `IParagraph` számára hozzon létre három [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) objektumot (alapértelmezett bekezdéshez két Portion objektumot), és adja hozzá az egyes `IPortion` objektumokat az `IPortion` gyűjteményhez az adott `IParagraph`-nél.
7. Állítson be szöveget minden részhez.
8. Alkalmazza a kívánt formázási beállításokat minden részre a `IPortion` objektum által biztosított formázási tulajdonságok segítségével.
9. Mentse a módosított bemutatót.

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/MultipleParagraphs_out.pptx";



// A kívánt bemutató betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Hozzon létre egy téglalap típusú AutoShape-et
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Adjon hozzá TextFrame-et a téglalaphoz
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

// Save PPTX to Disk
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bekezdés felsorolások kezelése**

A felsorolások segítenek az információ gyors és hatékony szervezésében és bemutatásában. A felsorolt bekezdések mindig könnyebben olvashatóak és érthetőek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemét.
5. `TextFrame` alapértelmezett bekezdésének eltávolítása.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével.
7. Állítsa be a bekezdés bullet `Type` értékét `Symbol`-ra, és adja meg a bullet karaktert.
8. Állítsa be a bekezdés `Text` értékét.
9. Állítsa be a bekezdés `Indent` értékét a bullethez.
10. Állítson be színt a bulletnek.
11. Állítson be magasságot a bulletnek.
12. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
13. Adja hozzá a második bekezdést, és ismételje meg a 7‑13. lépésben leírt folyamatot.
14. Mentse a bemutatót.

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/ParagraphBullets_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";
const String ImagePath = u"../templates/Tulips.jpg";

// A kívánt bemutató betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Hozzáad egy téglalap típusú AutoShape-et
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 150, 50);

// Szövegkeret hozzáadása a téglalaphoz
ashp->AddTextFrame(u"");

// A szövegkeret elérése
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();
txtFrame->get_Paragraphs()->Clear();

// A szövegkerethez Paragraph objektum létrehozása
SharedPtr<Paragraph> paragraph = MakeObject<Paragraph>();

// Szöveg beállítása
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Felsorolás behúzásának beállítása
paragraph->get_ParagraphFormat()->set_Indent (25);

// Felsorolás színének beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType ( ColorType::RGB);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
	
// Állítsa az IsBulletHardColor értékét true-ra, hogy saját felsorolásszínt használjon
paragraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True); 
																					
// Felsorolás magasságának beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph hozzáadása a szövegkerethez
txtFrame->get_Paragraphs()->Add(paragraph);

// Második bekezdés létrehozása
// A szövegkerethez Paragraph objektum létrehozása
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

// Állítsa az IsBulletHardColor értékét true-ra, hogy saját felsorolásszínt használjon
paragraph2->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);

// Felsorolás magasságának beállítása
paragraph2->get_ParagraphFormat()->get_Bullet()->set_Height(100);

// Paragraph hozzáadása a szövegkerethez
txtFrame->get_Paragraphs()->Add(paragraph2);


// PPTX mentése a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Képes felsorolások kezelése**

A felsorolások segítenek az információ gyors és hatékony szervezésében és bemutatásában. A képes bekezdések könnyen olvashatóak és érthetőek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemét.
5. `TextFrame` alapértelmezett bekezdésének eltávolítása.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével.
7. Töltse be a képet az [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) segítségével.
8. Állítsa be a bullet típusát [Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/) -ra, és adja meg a képet.
9. Állítsa be a Paragraph `Text` értékét.
10. Állítsa be a Paragraph `Indent` értékét a bullethez.
11. Állítson be színt a bulletnek.
12. Állítson be magasságot a bulletnek.
13. Adja hozzá az új bekezdést a `TextFrame` bekezdéggyűjteményéhez.
14. Adja hozzá a második bekezdést, és ismételje meg a folyamatot az előző lépések alapján.
15. Mentse a módosított bemutatót.

```c++
// PPTX fájlt reprezentáló Presentation osztály példányosítása
System::SharedPtr<Presentation> presentation = System::MakeObject<Presentation>();

// Az első dia elérése
System::SharedPtr<ISlide> slide = presentation->get_Slide(0);

// A felsoroláshoz használandó kép példányosítása
System::SharedPtr<IImage> image = Images::FromFile(u"bullets.png");
System::SharedPtr<IPPImage> ippxImage = presentation->get_Images()->AddImage(image);

// Autoshape hozzáadása és elérése
System::SharedPtr<IAutoShape> autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// Az autoshape szövegkeretének elérése
System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();

// Az alapértelmezett bekezdés eltávolítása
System::SharedPtr<IParagraphCollection> paragraphs = textFrame->get_Paragraphs();
paragraphs->RemoveAt(0);

// Új bekezdés létrehozása
System::SharedPtr<Paragraph> paragraph = System::MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");

// Bekezdés felsorolás stílusának és képének beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(ippxImage);

// A felsorolás magasságának beállítása
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100.0f);

// Bekezdés hozzáadása a szövegkerethez
paragraphs->Add(paragraph);

// A bemutató mentése PPTX fájlként
presentation->Save(u"ParagraphPictureBulletsPPTX_out.pptx", SaveFormat::Pptx);

// A bemutató mentése PPT fájlként
presentation->Save(u"ParagraphPictureBulletsPPT_out.ppt", SaveFormat::Ppt);
```

## **Többszintű felsorolások kezelése**

A felsorolások segítenek az információ gyors és hatékony szervezésében és bemutatásában. A többszintű bullet-ek könnyen olvashatóak és érthetőek.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet az új dián.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemét.
5. `TextFrame` alapértelmezett bekezdésének eltávolítása.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével, és állítsa be a mélységet 0-ra.
7. Hozza létre a második bekezdés példányát a `Paragraph` osztály segítségével, és állítsa be a mélységet 1-re.
8. Hozza létre a harmadik bekezdés példányát a `Paragraph` osztály segítségével, és állítsa be a mélységet 2-re.
9. Hozza létre a negyedik bekezdés példányát a `Paragraph` osztály segítségével, és állítsa be a mélységet 3-ra.
10. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
11. Mentse a módosított bemutatót.

```c++
// PPTX fájlt reprezentáló Presentation osztály példányosítása
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Az első dia elérése
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Autoshape hozzáadása és elérése
System::SharedPtr<IAutoShape> aShp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);

// A létrehozott autoshape szövegkeretének elérése
System::SharedPtr<ITextFrame> text = aShp->AddTextFrame(u"");

// Az alapértelmezett bekezdés törlése
text->get_Paragraphs()->Clear();

// Az első bekezdés hozzáadása
System::SharedPtr<IParagraph> para1 = System::MakeObject<Paragraph>();
para1->set_Text(u"Content");
System::SharedPtr<IParagraphFormat> para1Format = para1->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet1Format = para1Format->get_Bullet();
bullet1Format->set_Type(BulletType::Symbol);
bullet1Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat1 = para1Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat1->set_FillType(FillType::Solid);
defaultFillFormat1->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// A bullet szint beállítása
para1Format->set_Depth(0);

// A második bekezdés hozzáadása
System::SharedPtr<IParagraph> para2 = System::MakeObject<Paragraph>();
para2->set_Text(u"Second Level");
System::SharedPtr<IParagraphFormat> para2Format = para2->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet2Format = para2Format->get_Bullet();
bullet2Format->set_Type(BulletType::Symbol);
bullet2Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat2 = para2Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat2->set_FillType(FillType::Solid);
defaultFillFormat2->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// A bullet szint beállítása
para2Format->set_Depth(1);

// A harmadik bekezdés hozzáadása
System::SharedPtr<IParagraph> para3 = System::MakeObject<Paragraph>();
para3->set_Text(u"Third Level");
System::SharedPtr<IParagraphFormat> para3Format = para3->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet3Format = para3Format->get_Bullet();
bullet3Format->set_Type(BulletType::Symbol);
bullet3Format->set_Char(System::Convert::ToChar(8226));
System::SharedPtr<IFillFormat> defaultFillFormat3 = para3Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat3->set_FillType(FillType::Solid);
defaultFillFormat3->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// A bullet szint beállítása
para3Format->set_Depth(2);

// A negyedik bekezdés hozzáadása
System::SharedPtr<IParagraph> para4 = System::MakeObject<Paragraph>();
para4->set_Text(u"Fourth Level");
System::SharedPtr<IParagraphFormat> para4Format = para4->get_ParagraphFormat();
System::SharedPtr<IBulletFormat> bullet4Format = para4Format->get_Bullet();
bullet4Format->set_Type(BulletType::Symbol);
bullet4Format->set_Char(u'-');
System::SharedPtr<IFillFormat> defaultFillFormat4 = para4Format->get_DefaultPortionFormat()->get_FillFormat();
defaultFillFormat4->set_FillType(FillType::Solid);
defaultFillFormat4->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Black());
// A bullet szint beállítása
para4Format->set_Depth(3);

// Bekezdések hozzáadása a gyűjteményhez
System::SharedPtr<IParagraphCollection> paragraphs = text->get_Paragraphs();
paragraphs->Add(para1);
paragraphs->Add(para2);
paragraphs->Add(para3);
paragraphs->Add(para4);

// A bemutató mentése PPTX fájlként
pres->Save(u"MultilevelBullet.pptx", SaveFormat::Pptx);
```

## **Bekezdés kezelése egy egyéni számozott listával**

Az [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) interfész biztosítja a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) tulajdonságot és másokat, amelyek lehetővé teszik a bekezdések egyéni számozással vagy formázással történő kezelését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el azt a diát, amelyik a bekezdést tartalmazza.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Érje el az autoshape [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemét.
5. `TextFrame` alapértelmezett bekezdésének eltávolítása.
6. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével, és állítsa be a [NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét 2-re.
7. Hozza létre a második bekezdés példányát a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 3-ra.
8. Hozza létre a harmadik bekezdés példányát a `Paragraph` osztály segítségével, és állítsa be a `NumberedBulletStartWith` értékét 7-re.
9. Adja hozzá az új bekezdéseket a `TextFrame` bekezdéggyűjteményéhez.
10. Mentse a módosított bemutatót.

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

## **Első sor behúzás beállítása egy bekezdéshez**

Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozdítja el a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) metódust, ha a teljes bekezdést szeretné elmozdítani. Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust, ha csak az első sort szeretné elmozdítani.

Az alábbi példa több bekezdést hoz létre, és különböző `Indent` értékeket alkalmaz, hogy bemutassa, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/) elemet a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

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

The result:
![The first-line indent of the paragraphs](first_line_indent.png)

## **Függő behúzás beállítása egy bekezdéshez**

A függő behúzás egy bekezdéselrendezés, amelyben az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódussal hozhatja létre. Állítsa a behúzást negatív értékre, hogy az első sor balra tolódjon a bekezdés törzséhez képest.

Gyakorlatilag az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) határozza meg a bekezdés törzsének bal pozícióját, az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) pedig az első sor helyzetét ehhez a margóhoz képest. A függő behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedetek és egyéb bekezdések esetén, ahol a sortöréseknek a bekezdés törzse alatt kell igazodniuk, nem pedig az első karakter alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap [AutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/autoshape/) elemet a diára.
4. Adjon egy üres [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/) elemet a formához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon bekezdéseket, és állítson be pozitív [MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket mindegyikhez.
6. Állítson be negatív [Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értéket a függő behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

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

The result:
![The hanging indent of the paragraphs](hanging_indent.png)

## **Bekezdés Végségi Futtatási Tulajdonságok kezelése**

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezze meg a bekezdést tartalmazó dia hivatkozását a pozíciója alapján.
1. Adjon hozzá egy téglalap [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
1. Adjon egy [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemet két bekezdéssel a téglalaphoz.
1. Állítsa be a `FontHeight` és a betűtípus értékét a bekezdésekhez.
1. Állítsa be a vég (End) tulajdonságokat a bekezdésekhez.
1. Írja ki a módosított bemutatót PPTX fájlként.

```c++
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/EndParaGraphProperties_out.pptx";
//const String templatePath = u"../templates/DefaultFonts.pptx";


// A kívánt bemutató betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Téglalap típusú AutoShape hozzáadása
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 300);

// TextFrame hozzáadása a téglalaphoz
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

// PPTX mentése a lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);

```

## **HTML szöveg importálása bekezdésekbe**

Az Aspose.Slides kibővített támogatást nyújt a HTML szöveg bekezdésekbe importálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Adjon hozzá egy [autoshape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Adja hozzá és érje el az `autoshape` [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemet.
5. `ITextFrame` alapértelmezett bekezdésének eltávolítása.
6. Olvassa be a forrás HTML-fájlt egy TextReader‑ben.
7. Hozza létre az első bekezdés példányát a [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) osztály segítségével.
8. Adja hozzá a beolvasott TextReader HTML-fájl tartalmát a TextFrame [ParagraphCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphcollection/) gyűjteményéhez.
9. Mentse a módosított bemutatót.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/ImportingHTMLText_out.pptx";
const String sampleHtml = u"../templates/file.html";

	
// A kívánt bemutató betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>();

// Az első dia elérése
SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Téglalap típusú AutoShape hozzáadása
SharedPtr<IAutoShape>  ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 700, 500);
	
//Alapértelmezett kitöltőszín visszaállítása
ashp->get_FillFormat()->set_FillType(FillType::NoFill);
	
// TextFrame hozzáadása a téglalaphoz
ashp->AddTextFrame(u" ");

// A szövegkeret elérése
SharedPtr<ITextFrame>  txtFrame = ashp->get_TextFrame();

//GetParagraphs collection
SharedPtr<Aspose::Slides::IParagraphCollection>ParaCollection = txtFrame->get_Paragraphs();

// Az added text frame-ben lévő összes bekezdés törlése
ParaCollection->Clear();

// HTML fájl betöltése stream reader-rel
SharedPtr<System::IO::StreamReader>  tr = MakeObject<System::IO::StreamReader>(sampleHtml);

// Szöveg hozzáadása HTML stream reader-ből a szövegkeretbe
ParaCollection->AddFromHtml(tr->ReadToEnd());


// Paragraph objektum létrehozása a szövegkerethez
SharedPtr<IParagraph> paragraph = txtFrame->get_Paragraphs()->idx_get(0);

// Portion objektum létrehozása a bekezdéshez
SharedPtr<IPortion> portion = paragraph->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose TextBox");

//Get portion format
SharedPtr<IPortionFormat> pf = portion->get_PortionFormat();

// A Portion betűtípusának beállítása
pf->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));

// A betű félkövér tulajdonság beállítása
pf->set_FontBold(NullableBool::True);

// A betű dőlt tulajdonság beállítása
pf->set_FontItalic(NullableBool::True);

// A betű aláhúzott tulajdonság beállítása
pf->set_FontUnderline(TextUnderlineType::Single);

// A betű méretének beállítása
pf->set_FontHeight(25);

// A betű színének beállítása
pf->get_FillFormat()->set_FillType(FillType::Solid);
pf->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());

// PPTX mentése lemezre
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Bekezdés szöveg exportálása HTML-be**

Az Aspose.Slides kibővített támogatást nyújt a szövegek (amelyek bekezdésekben vannak) HTML-be exportálásához.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és töltse be a kívánt bemutatót.
2. A megfelelő dia hivatkozását érje el az indexe segítségével.
3. Érje el azt a formát, amelyik a HTML‑be exportálandó szöveget tartalmazza.
4. Érje el a forma [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) elemét.
5. Hozzon létre egy `StreamWriter` példányt, és adja hozzá az új HTML-fájlt.
6. Adjon meg egy kezdő indexet a StreamWriternek, és exportálja a kívánt bekezdéseket.

```c++
For complete examples and data files, please go to https://github.com/aspose-slides/Aspose.Slides-for-C
// A dokumentumok könyvtárának elérési útja.
const String outPath = u"../out/output.html";
const String tempplatePath = u"../templates/DefaultFonts.pptx";

// A kívánt bemutató betöltése
SharedPtr<Presentation> pres = MakeObject<Presentation>(tempplatePath);


// Az alapértelmezett első dia elérése a bemutatóban
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Kívánt index
int index = 0;

// A hozzáadott alakzat elérése
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);

SharedPtr<AutoShape> ashape = DynamicCast<Aspose::Slides::AutoShape>(shape);

// Az első bekezdés kinyerése HTML-ként
SharedPtr<System::IO::StreamWriter> sw = MakeObject<System::IO::StreamWriter>(outPath, false, Encoding::get_UTF8());
//  System::IO::StreamWriter^ sr = gcnew System::IO::StreamWriter("TestFile.txt", false, Encoding::get_UTF8());

// Bekezdések adatainak írása HTML-be a bekezdés kezdő indexének és másolandó bekezdések számának megadásával
sw->Write(ashape->get_TextFrame()->get_Paragraphs()->ExportToHtml(0, ashape->get_TextFrame()->get_Paragraphs()->get_Count(), nullptr));

sw->Close();
```

## **Bekezdés mentése képként**

Ebben a szakaszban két példát mutatunk be, amelyek azt demonstrálják, hogyan menthetünk egy szövegbekezdést, amelyet az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) interfész képvisel, képként. Mindkét példa magában foglalja a bekezdést tartalmazó forma képének lekérését a [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfész `GetImage` metódusaival, a bekezdés alakzatbeli határainak kiszámítását, és bitmap képként való exportálását. Ezek a megközelítések lehetővé teszik a PowerPoint bemutatók szövegének specifikus részeinek kinyerését és különálló képként történő mentését, ami különböző helyzetekben hasznos lehet.

![The text box with three paragraphs](paragraph_to_image_input.png)

**Példa 1**

Ebben a példában a második bekezdést képként nyerjük ki. Ehhez a prezentáció első diájáról kinyerjük a forma képét, majd kiszámítjuk a második bekezdés határait a forma szövegkeretében. Ezután a bekezdést egy új bitmap képre rajzoljuk, amelyet PNG formátumban mentünk. Ez a módszer különösen hasznos, ha egy adott bekezdést külön képként kell menteni, miközben megőrzik a szöveg pontos méretét és formázását.

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

The result:
![A bekezdés képe](paragraph_to_image_output.png)

**Példa 2**

Ebben a példában kiterjesztjük az előző megközelítést úgy, hogy a bekezdés képéhez méretezési faktorokat adunk. A formát a bemutatóból kinyerjük, és `2` méretezési faktorral képként mentjük. Ez magasabb felbontású kimenetet tesz lehetővé a bekezdés exportálásakor. A bekezdés határait ezután a méretezés figyelembevételével számítjuk ki. A méretezés különösen hasznos lehet, ha részletesebb képre van szükség, például nyomtatott, magas minőségű anyagokhoz.

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

## **GYIK**

**Letilthatom teljesen a sorok tördelését egy szövegkereten belül?**

Igen. Használja a szövegkeret tördelési metódusát ([set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_wraptext/)), hogy kikapcsolja a tördelést, így a sorok nem törnek meg a keret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos dián belüli határait?**

Elérhető a bekezdés (sőt egyetlen rész) határoló téglalapja, amely megmutatja a pontos helyzetét és méretét a dián.

**Hol szabályozható a bekezdés igazítása (balra/jobbra/középre/széthúzott)?**

[Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/set_alignment/) egy bekezdés szintű beállítás a [ParagraphFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraphformat/)‑ben; a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

**Beállíthatok helyesírási nyelvet csak a bekezdés egy részére (például egy szóra)?**

Igen. A nyelvet a rész (portion) szintjén állítják be a ([PortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/baseportionformat/set_languageid/)) használatával, így több nyelv is létezhet egy bekezdésen belül.