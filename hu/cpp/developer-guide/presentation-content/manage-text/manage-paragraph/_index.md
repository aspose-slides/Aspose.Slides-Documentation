---
title: PowerPoint szöveg bekezdések kezelése C++-ban
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
- bekezdés behúzás
- lanyúló behúzás
- bekezdés felsorolás
- számozott lista
- felsoroláslista
- bekezdés tulajdonságai
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- bemutató
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmakat és bekezdésképeket az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a szöveget szövegkeretek, bekezdések és részek (portions) hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) a szövegtárolót képviseli egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményhez.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) egy bekezdést jelöl egy szövegkeretben, és hozzáférést ad a részekhez és a bekezdés‑szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) egy szövegrészt (run) jelöl egy bekezdésen belül. Minden részlet saját szöveggel és karakter‑szintű formázással rendelkezhet.

Egy bekezdés tehát különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat több részlet használatával.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részlettel**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, amelyek mindegyike három részt tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához.
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részletet tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden részlet szövegét.
8. Alkalmazzon karakter‑szintű formázást a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) segítségével.
9. Mentse a módosított bemutatót.

Ez a C++ példa megvalósítja a lépéseket:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 150, 300, 150);
auto textFrame = shape->get_TextFrame();

auto firstParagraph = textFrame->get_Paragraph(0);
firstParagraph->get_Portions()->Add(MakeObject<Portion>());
firstParagraph->get_Portions()->Add(MakeObject<Portion>());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
secondParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
thirdParagraph->get_Portions()->Add(MakeObject<Portion>());
textFrame->get_Paragraphs()->Add(thirdParagraph);

auto paragraphCount = textFrame->get_Paragraphs()->get_Count();
for (int paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (int portionIndex = 0; portionIndex < portionCount; portionIndex++)
    {
        auto portion = paragraph->get_Portion(portionIndex);
        portion->set_Text(String::Format(u"Portion {0}.{1}", paragraphIndex + 1, portionIndex + 1));
        auto portionFormat = portion->get_PortionFormat();

        if (portionIndex == 0)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());
            portionFormat->set_FontBold(NullableBool::True);
            portionFormat->set_FontHeight(15);
        }
        else if (portionIndex == 1)
        {
            portionFormat->get_FillFormat()->set_FillType(FillType::Solid);
            portionFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Blue());
            portionFormat->set_FontItalic(NullableBool::True);
            portionFormat->set_FontHeight(18);
        }
    }
}

presentation->Save(u"paragraphs_with_portions.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Felsorolási és számozott listák létrehozása**

### **Felsorolási vagy számozott lista létrehozása**

A felsorolások és számok megkönnyítik a kapcsolódó elemek áttekintését. Az Aspose.Slides-ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) segítségével definiáljuk.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához.
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) elemet egy szimbólum felsoroláshoz.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) típusra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) típusra.
11. Konfigurálja a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez a C++ példa szimbólum és számozott felsorolást hoz létre:

```cpp
#include <DOM/BulletType.h>
#include <DOM/ColorType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/NumberedBulletStyle.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto symbolParagraph = MakeObject<Paragraph>();
symbolParagraph->set_Text(u"Welcome to Aspose.Slides");
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
symbolParagraph->get_ParagraphFormat()->set_Indent(25);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
symbolParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(symbolParagraph);

auto numberedParagraph = MakeObject<Paragraph>();
numberedParagraph->set_Text(u"This is a numbered item");
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStyle(NumberedBulletStyle::BulletCircleNumWDBlackPlain);
numberedParagraph->get_ParagraphFormat()->set_Indent(25);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_ColorType(ColorType::RGB);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->get_Color()->set_Color(Color::get_Black());
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_IsBulletHardColor(NullableBool::True);
numberedParagraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(numberedParagraph);

presentation->Save(u"bulleted_and_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Képes felsorolásjelek használata**

A képes felsorolásjelek lehetővé teszik egy egyedi kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) osztályból.
2. Hozzáférés a megfelelő dia hivatkozásához az indexén keresztül.
3. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet, és férjen hozzá annak [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához.
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a felsorolás képet, és adja hozzá a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) formájában.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/cpp/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Picture](https://reference.aspose.com/slides/cpp/aspose.slides/bullettype/) típusra.
8. Rendelje hozzá a képet a [ISlidesPicture::set_Image](https://reference.aspose.com/slides/cpp/aspose.slides/islidespicture/set_image/) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

Ez a C++ példa képes felsorolást hoz létre:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IImageCollection.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto bulletImage = Images::FromFile(u"bullets.png");
auto presentationImage = presentation->get_Images()->AddImage(bulletImage);
bulletImage->Dispose();

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto paragraph = MakeObject<Paragraph>();
paragraph->set_Text(u"Welcome to Aspose.Slides");
paragraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Picture);
paragraph->get_ParagraphFormat()->get_Bullet()->get_Picture()->set_Image(presentationImage);
paragraph->get_ParagraphFormat()->get_Bullet()->set_Height(100);
textFrame->get_Paragraphs()->Add(paragraph);

presentation->Save(u"picture_bullet.pptx", SaveFormat::Pptx);
presentation->Save(u"picture_bullet.ppt", SaveFormat::Ppt);
presentation->Dispose();
```

### **Többszintű lista létrehozása**

Állítsa be az [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) értékét a bekezdések különböző lista‑szintjeinek meghatározásához. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, és férjen hozzá egy diához.
2. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretből.
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolás szimbólumait.
4. Állítsa be a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) értékeket `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez a C++ példa négy szintű felsorolási listát hoz létre:

```cpp
#include <DOM/BulletType.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/convert.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Content");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_Depth(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Second level");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_Depth(1);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Third level");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(Convert::ToChar(0x2022));
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_Depth(2);

auto fourthParagraph = MakeObject<Paragraph>();
fourthParagraph->set_Text(u"Fourth level");
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Symbol);
fourthParagraph->get_ParagraphFormat()->get_Bullet()->set_Char(u'-');
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
fourthParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
fourthParagraph->get_ParagraphFormat()->set_Depth(3);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);
textFrame->get_Paragraphs()->Add(fourthParagraph);

presentation->Save(u"multilevel_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Számozott listaelemek indítása egyedi értékekkel**

Használja a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) metódust a számozott bekezdés kezdeti számának beállításához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) objektumot, és adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretéből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegkerethez, majd mentse a bemutatót.

Ez a C++ példa egyedi kezdő számmal látja el a bekezdéseket:

```cpp
#include <DOM/BulletType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200, 200, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"Start at 2");
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
firstParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(2);
textFrame->get_Paragraphs()->Add(firstParagraph);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Start at 3");
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
secondParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(3);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"Start at 7");
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_Type(BulletType::Numbered);
thirdParagraph->get_ParagraphFormat()->get_Bullet()->set_NumberedBulletStartWith(7);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"custom_numbered_list.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Bekezdés elrendezésének és befejező tulajdonságainak vezérlése**

### **Első sor behúzásának beállítása**

Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához viszonyítva. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzséhez igazodik.

Használja az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑t, ha a teljes bekezdést szeretné eltolni. Az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) csak az első sort módosítja.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) értékekkel demonstrálja, hogyan befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt.
2. Hozzáférés a cél diához.
3. Adj hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a kód bemutatja, hogyan állítható be egy bekezdés behúzása:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"No first-line indent. Wrapped lines start at the same position as the first line.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(20);
firstParagraph->get_ParagraphFormat()->set_Indent(0);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"First-line indent of 20 points. The first line moves to the right, while wrapped lines remain aligned to the paragraph body.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(20);
secondParagraph->get_ParagraphFormat()->set_Indent(20);

auto thirdParagraph = MakeObject<Paragraph>();
thirdParagraph->set_Text(u"First-line indent of 40 points. This paragraph shows a larger first-line offset to make the effect easier to see.");
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
thirdParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
thirdParagraph->get_ParagraphFormat()->set_MarginLeft(20);
thirdParagraph->get_ParagraphFormat()->set_Indent(40);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);
textFrame->get_Paragraphs()->Add(thirdParagraph);

presentation->Save(u"paragraph_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Lenyúló behúzás beállítása**

A lanyúló behúzás olyan bekezdéselrendezés, amelyben az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides‑ben ezt a hatást a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) segítségével hozhatja létre. A negatív érték balra mozgatja az első sort a bekezdéstörzshöz képest.

Gyakorlatban az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) határozza meg a bekezdés törzsének bal pozícióját, az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) pedig az első sor helyzetét ehhez a margóhoz képest. Lenyúló behúzás létrehozásához állítson be pozitív margin‑left értéket és negatív indent értéket.

Ez a formázás hasznos bibliográfiákhoz, hivatkozásokhoz, szószedet-bejegyzésekhez és egyéb bekezdésekhez, ahol a sortörés alatti soroknak a bekezdéstörzs alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt.
2. Hozzáférés a cél diához.
3. Adj hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket minden bekezdéshez.
6. Állítson be egy negatív [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) értéket a lanyúló behúzás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

Ez a kód bemutatja, hogyan állítható be a lanyúló behúzás egy bekezdéshez:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 420, 220);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Gray());

auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::Shape);
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->set_Text(u"A hanging indent is created by combining a positive left margin with a negative indent. The first line starts to the left, while wrapped lines align with the paragraph body.");
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
firstParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
firstParagraph->get_ParagraphFormat()->set_MarginLeft(40);
firstParagraph->get_ParagraphFormat()->set_Indent(-20);

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"This second example uses a deeper hanging indent so the difference between the first line and the wrapped lines is easier to compare.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->set_FillType(FillType::Solid);
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
secondParagraph->get_ParagraphFormat()->set_MarginLeft(60);
secondParagraph->get_ParagraphFormat()->set_Indent(-30);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"hhang_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A bekezdések lanyúló behúzása](hanging_indent.png)

### **Bekezdés befejező futtatási tulajdonságainak beállítása**

Az [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) a bekezdés zárójelének formázását szabályozza. Az alábbi példa egy betűméretet és latin betűtípust állít be a második bekezdés zárójelére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) fájlt, és férjen hozzá egy diához.
2. Adj hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet, és távolítsa el az alapértelmezett bekezdést.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrészeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) objektumot a második bekezdés zárójeléhez.
5. Állítsa be az [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) és az [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) metódussal, majd mentse a bemutatót.

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortionCollection.h>
#include <DOM/Paragraph.h>
#include <DOM/Portion.h>
#include <DOM/PortionFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Test.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 200, 250);
auto textFrame = shape->get_TextFrame();
textFrame->get_Paragraphs()->Clear();

auto firstParagraph = MakeObject<Paragraph>();
firstParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text"));

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->get_Portions()->Add(MakeObject<Portion>(u"Sample text 2"));

auto endParagraphFormat = MakeObject<PortionFormat>();
endParagraphFormat->set_FontHeight(48);
endParagraphFormat->set_LatinFont(MakeObject<FontData>(u"Times New Roman"));
secondParagraph->set_EndParagraphPortionFormat(endParagraphFormat);

textFrame->get_Paragraphs()->Add(firstParagraph);
textFrame->get_Paragraphs()->Add(secondParagraph);

presentation->Save(u"end_paragraph_format.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Megjelenített sorok számlálása**

A bekezdés szabályai, amelyek az automatikus sortörést és a vonalatmondó írásjelet befolyásolják, megtalálhatók a [Control Line Breaking](/slides/hu/cpp/text-formatting/#control-line-breaking) és a [Control Hanging Punctuation](/slides/hu/cpp/text-formatting/#control-hanging-punctuation) témakörökben.

Használja az [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározására a szöveg elrendezése után, beleértve az automatikus sortörést. Ez akkor hasznos, ha a szöveg hossza és elrendezése kell, hogy illeszkedjen a prezentációs sablonokba.

Egy bekezdés a [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/) egyik eleme, és több megjelenített sort is elfoglalhat. A bekezdésen belüli explicit sortörés új sort hoz létre anélkül, hogy újabb bekezdést generálna. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy a szövegbe explicit sortöréseket illesztene. Így a bekezdések vagy sortörő karakterek számlálása nem adja meg a tényleges megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja sorait, szűkíti az alakzatot, majd rövidebb szöveggel helyettesíti a tartalmat. A sortörés be van kapcsolva, az automatikus méretezés (autofit) ki van kapcsolva, így a alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveg automatikusan összezsugorodna vagy az alakzat mérete változna. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összeadja a sorok számát a szövegkeretben.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/NullableBool.h>
#include <DOM/Paragraph.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextAutofitType.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50, 50, 400, 200);
auto textFrame = shape->get_TextFrame();
textFrame->get_TextFrameFormat()->set_WrapText(NullableBool::True);
textFrame->get_TextFrameFormat()->set_AutofitType(TextAutofitType::None);

auto paragraph = textFrame->get_Paragraph(0);
paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
paragraph->set_Text(u"This text demonstrates how automatic wrapping changes the number of rendered lines.");
Console::WriteLine(u"Original width: {0}", paragraph->GetLinesCount());

shape->set_Width(150);
Console::WriteLine(u"Narrower shape: {0}", paragraph->GetLinesCount());

paragraph->set_Text(u"Short text.");
Console::WriteLine(u"Shorter text: {0}", paragraph->GetLinesCount());

auto secondParagraph = MakeObject<Paragraph>();
secondParagraph->set_Text(u"Another paragraph.");
secondParagraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(20);
textFrame->get_Paragraphs()->Add(secondParagraph);

auto totalLineCount = 0;
for (auto currentParagraph : textFrame->get_Paragraphs())
{
    totalLineCount += currentParagraph->GetLinesCount();
}
Console::WriteLine(u"Total lines in the text frame: {0}", totalLineCount);
presentation->Dispose();
```

Ezzel a szöveggel és ezekkel a méretekkel a szűkített alakzat növeli a sorok számát, míg a rövid szövegre cserélés csökkenti azt. A pontos számok betűkészlet és helyettesítés, betűméret, margók, behúzás, sortörés és autofit beállítások függvényében változhatnak. Ellenőrzéskor használja azt a betűkészletet és elrendezést, amely a célkörnyezetben lesz alkalmazva.

A sorok száma önmagában nem határozza meg, hogy a szöveg átnyúlik-e a tárolóján. A rendelkezésre álló magasság, sormagasságok, bekezdés‑ és sorköz, valamint az autofit viselkedés is fontos; még egyetlen sor is túlnyúlhat a rendelkezésre álló szélességen, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja az [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódust a HTML jelölőkód bekezdésekké és részekké konvertálásához egy szövegkeretben.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt.
2. Hozzáférés egy diához, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához, és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot az [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódusnak.
6. Mentse a módosított bemutatót.

Ez a C++ példa HTML‑t importál egy szövegkeretbe:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/stream_reader.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto slideSize = presentation->get_SlideSize()->get_Size();
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, slideSize.get_Width() - 20, slideSize.get_Height() - 20);
shape->get_FillFormat()->set_FillType(FillType::NoFill);
shape->get_TextFrame()->get_Paragraphs()->Clear();

auto reader = MakeObject<StreamReader>(u"file.html");
auto html = reader->ReadToEnd();
reader->Close();
shape->get_TextFrame()->get_Paragraphs()->AddFromHtml(html);

presentation->Save(u"html_text.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

### **Bekezdés szövegének exportálása HTML-be**

Használja az [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust a kiválasztott bekezdéstartomány HTML‑ként történő exportálásához.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) példányt, és töltse be a kívánt bemutatót.
2. Hozzáférés a diához, és keresse meg a [IAutoShape](https://reference.aspose.com/slides/cpp/aspose.slides/iautoshape/) elemet, amely a szöveget tartalmazza.
3. Hozzáférés az alakzat [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) objektumához.
4. Hívja meg az [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

Ez a C++ példa az első szöveg alakzat összes bekezdését exportálja:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/io/stream_writer.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"ExportingHTMLText.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), nullptr);
    auto writer = MakeObject<StreamWriter>(u"paragraphs.html", false, Encoding::get_UTF8());
    writer->Write(html);
    writer->Close();
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

### **Bekezdés megjelenítése képként**

Az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) egy egyedi bekezdést renderel közvetlenül, és egy [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) objektumot ad vissza. A kapott eredményt mentse fájlba vagy áramlatba az [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) metódussal. Nem szükséges a környező alakzatot renderelni vagy bitmapet manuálisan vágni.

Az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) `nullptr`‑t adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt mentés előtt, és a használat után dobja el a visszakapott képet.

#### **Bekezdés renderelése az alapértelmezett mérettel**

Tegyük fel, hogy van egy sample.pptx nevű bemutatófájl egy diával, ahol az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabványos szöveges alakzatban rendereli az alapértelmezett mérettel, és PNG formátumban menti a visszakapott képet.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/console.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr && textShape->get_TextFrame()->get_Paragraphs()->get_Count() > 1)
{
    auto paragraph = textShape->get_TextFrame()->get_Paragraph(1);
    auto paragraphImage = paragraph->GetImage();

    if (paragraphImage != nullptr)
    {
        paragraphImage->Save(u"paragraph.png", ImageFormat::Png);
        paragraphImage->Dispose();
    }
    else
    {
        Console::WriteLine(u"The paragraph could not be rendered.");
    }
}
else
{
    Console::WriteLine(u"The expected text shape or paragraph was not found.");
}

presentation->Dispose();
```

Az eredmény:

![A bekezdés képe](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblázatcellában méretezéssel**

Használja az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) túlterhelést, amely elfogadja a `float scaleX` és `float scaleY` paramétereket a vízszintes és függőleges méretezési tényezők beállításához. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres alapméretű szélességgel és magassággal rendereli, majd PNG képként menti az eredményt.

```cpp
#include <DOM/IParagraph.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ITable.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/array.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto scaleX = 2.0f;
auto scaleY = 2.0f;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto table = slide->get_Shapes()->AddTable(50, 50, MakeArray<double>({300}), MakeArray<double>({80}));
auto paragraph = table->idx_get(0, 0)->get_TextFrame()->get_Paragraph(0);
paragraph->set_Text(u"Text in a table cell");

auto paragraphImage = paragraph->GetImage(scaleX, scaleY);
if (paragraphImage != nullptr)
{
    paragraphImage->Save(u"table_paragraph.png", ImageFormat::Png);
    paragraphImage->Dispose();
}
else
{
    Console::WriteLine(u"The paragraph could not be rendered.");
}

presentation->Dispose();
```

Az `1` méretarány megtartja az adott tengely alap pixelméretét. Például a `2` mindkét tényezőnél olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapméretnek, ezáltal négyszeres pixel-számot ad. A nagyobb tényezők általában élesebb szöveget biztosítanak nagyításkor vagy nagy felbontású kimenetnél, de növelik a memóriahasználatot és a fájlméretet. Az `1`‑nél kisebb tényezők kisebb, kevésbé részletgazdag képeket eredményeznek. Azonos tényezők megtartásával megőrizhető a bekezdés képaránya; eltérő vízszintes és függőleges tényezők külön-külön nyújtják a kimenetet.

Egy teljes alakzat renderelése az [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/)‑vel akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Csak bekezdés‑képhez használja az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)‑t.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkeretben?**

Igen. Használja az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust a sortörés letiltásához, így a sorok nem törnek a szövegkeret szélein.

**Hogyan kaphatom meg egy adott bekezdés pontos diákon belüli határait?**

Használja az [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) metódust a bekezdés körülhatároló téglalap lekérdezéséhez. Az [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) egyedi részlet határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**

Az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes részek formázásától.

A különböző betűmérettel rendelkező részek függőleges igazításához lásd a [Align Fonts Within a Line](/slides/hu/cpp/text-formatting/#align-fonts-within-a-line) témát.

**Beállíthatok-e bizonyos nyelvet a bekezdés egy részére?**

Igen. Használja az [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódust egyedi részekhez, így egy bekezdés több nyelven is tartalmazhat szöveget.