---
title: PowerPoint szövegbekezdések kezelése C++-ban
linktitle: Bekezdések kezelése
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
- függő behúzás
- bekezdés felsorolás
- számozott lista
- felsoroláslista
- bekezdés tulajdonságok
- HTML importálása
- szöveg HTML-re
- bekezdés HTML-re
- bekezdés képre
- szöveg képre
- bekezdés exportálása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Tanulja meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for C++ segítségével."
---
## **Áttekintés**

Az Aspose.Slides for C++ a szöveget szövegkeretek, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) a szövegkonténert jelöli egy alakzatban, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegkeretben, és hozzáférést biztosít a részekhez és a bekezdés szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) egy szövegrészletet jelöl egy bekezdésen belül. Minden részletnek saját szövege és karakter szintű formázása lehet.

Egy bekezdés tehát több részlet használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Bekezdések létrehozása több részegységgel**

A következő lépések egy szövegkeretet hoznak létre három bekezdéssel, amelyek mindegyike három részegységet tartalmaz:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/).
5. Használja az alapértelmezett bekezdést, és adjon hozzá további két [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumot a szövegkerethez.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részletet tartalmazzon. Az alapértelmezett bekezdés már egy üres részt tartalmaz.
7. Állítsa be minden részlet szövegét.
8. Alkalmazzon karakter szintű formázást a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_portionformat/).
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

## **Felsorolt és számozott listák létrehozása**

### **Felsorolt vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik az összefüggő elemek áttekintését. Az Aspose.Slides-ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a kiválasztott diához.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/).
5. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) elemet egy szimbólum felsoroláshoz.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét [BulletType::Symbol](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/) értékre, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, a behúzást, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét [BulletType::Numbered](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/).
11. Állítsa be a számozott felsorolás stílusát, és adja hozzá a bekezdést a szövegkerethez.
12. Mentse a bemutatót.

Ez a C++ példa egy szimbólum és egy számozott felsorolást hoz létre:

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

### **Képes felsorolások használata**

A képes felsorolások lehetővé teszik egy saját kép használatát a szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a megfelelő dia referenciáját az indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és érje el annak [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/).
4. Távolítsa el az alapértelmezett bekezdést a szövegkeretből.
5. Töltse be a felsorolás képet, és adja hozzá a bemutató képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/).
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) elemet, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét [BulletType::Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/).
8. Rendelje hozzá a képet a [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/set_image/) segítségével, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegkerethez.
10. Mentse a módosított bemutatót.

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

Állítsa be a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) értékét, hogy a bekezdéseket a lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegkeretéből.
3. Hozzon létre négy bekezdést, és állítsa be a felsorolás szimbólumaikat.
4. Állítsa be a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) értékeiket `0`, `1`, `2`, és `3`-ra.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a bemutatót.

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

### **Számozott listaelemek egyedi kezdőértékkel**

Használja a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) metódust, hogy beállítsa a számozott bekezdés kezdeti számát.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) elemet, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet egy diához.
2. Törölje az alapértelmezett bekezdést az alakzat szövegkeretből.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét `2`, `3`, és `7`-re a megfelelő bekezdésekhez.
5. Adja hozzá a bekezdéseket a szövegkerethez, és mentse a bemutatót.

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

## **Bekezdés elrendezésének és végjellemzőinek vezérlése**

### **Első sor behúzás beállítása**

Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásának vezérlésére. Ez a módszer csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés testhez igazodik.

Használja az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) metódust, ha a teljes bekezdést szeretné eltolni. Használja az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust, ha csak az első sort szeretné eltolni.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket alkalmaz, hogy bemutassa, miként befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegkerethez.
7. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be egy bekezdés behúzása:

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

![The first-line indent of the paragraphs](first_line_indent.png)

### **Függő behúzás beállítása**

Függő behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides-ben ezt a hatást az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) használatával hozhatja létre. Állítsa a behúzást negatív értékre, hogy az első sor a bekezdés testhez képest balra mozduljon.

Gyakorlatban az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) a bekezdés test bal pozícióját határozza meg, és az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) az első sor pozícióját a margóhoz képest. Függő behúzás létrehozásához állítson be pozitív margin-left értéket és negatív indent értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedeti bejegyzések és más bekezdések esetén, ahol a sortöréses soroknak a bekezdés test alatt kell igazodniuk, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el a cél diát.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be egy pozitív [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket minden bekezdéshez.
6. Állítson be egy negatív [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értéket a függő behúzás hatás létrehozásához.
7. Adja hozzá a bekezdéseket a szövegkerethez.
8. Mentse a módosított bemutatót.

Ez a kód megmutatja, hogyan állítható be a függő behúzás egy bekezdéshez:

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

presentation->Save(u"hanging_indent.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![The hanging indent of the paragraphs](hanging_indent.png)

### **Bekezdés végi rész tulajdonságainak beállítása**

[IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) vezérli a bekezdés végjelének formázását. A következő példa betűméretet és Latin betűtípust rendel a második bekezdés végjeléhez:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) elemet, és érje el egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szöveg részeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) elemet a második bekezdés végjeléhez.
5. Állítsa be a [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_fontheight/) és a [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_latinfont/) értékeket.
6. Rendelje hozzá a formátumot a [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) metódussal, és mentse a bemutatót.

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

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja a [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódust, hogy HTML jelölőnyelvet alakítsa bekezdésekké és részekké egy szövegkeretben.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Érje el egy diát és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/).
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) és törölje az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML fájlt.
5. Adja át a HTML karakterláncot a [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódusnak.
6. Mentse a módosított bemutatót.

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

Használja a [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust, hogy a kiválasztott bekezdés tartományt HTML-ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és töltse be a kívánt bemutatót.
2. Érje el a diát, és keresse meg a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, amely a szöveget tartalmazza.
3. Érje el az alakzat [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/).
4. Hívja meg a [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszakapott HTML karakterláncot egy fájlba.

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

[IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) közvetlenül rendereli az egyes bekezdést és visszaad egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumot. A visszakapott eredményt fájlba vagy streambe mentheti a [IImage::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/save/) használatával. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan levágni.

[IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) `nullptr`-t adhat vissza, ha a bekezdés nem található meg a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

Tegyük fel, hogy van egy sample.pptx nevű bemutató fájlunk, amely egy diát tartalmaz, és az első alakzat egy három bekezdést tartalmazó szövegdoboz.

![The text box with three paragraphs](paragraph_to_image_input.png)

A következő példa a második bekezdést rendereli egy normál szöveges alakzatban alapértelmezett méretezésben, és a visszakapott képet PNG formátumban menti.

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

![The paragraph image](paragraph_to_image_output.png)

#### **Bekezdés renderelése táblacellában méretezéssel**

Használja a [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) túlterhelést, amely `float scaleX` és `float scaleY` paramétereket fogad, hogy beállítsa a vízszintes és függőleges méretezési tényezőket. A következő példa egy táblát hoz létre, rendereli a bekezdést az első cellájában a alapértelmezett szélesség és magasság kétszeresével, és a eredményt PNG képként menti.

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

A `1` skálafaktor az adott tengelyt az alapértelmezett pixelméretben tartja. Például a `2` mindkét tényezőre azt eredményezi, hogy a kép szélessége és magassága megközelítőleg kétszerese az alapértelmezett dimenzióknak, ami négyzetes növekedés a pixelek számában. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet is. Az `1` alatti tényezők kisebb képeket hoznak kevesebb részletre. Egyenlő tényezők használata megőrzi a bekezdés képarányát; különböző vízszintes és függőleges tényezők önállóan nyújtják a kimenetet.

Egy teljes alakzat renderelése a [IShape::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getimage/) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Ha csak bekezdéskép szükséges, használja a [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegkereten belül?**  
Igen. Használja a [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust a tördelés letiltásához, így a sorok nem törnek a szövegkeret szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos helyi határait a dián?**  
Használja az [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getrect/) egy egyedi részlet határait adja meg.

**Hol állítható be a bekezdés igazítása (balra, jobbra, középre vagy sorkizárás)?**  
Az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) a bekezdés szintű beállítás, és a teljes bekezdésre vonatkozik, függetlenül az egyedi részletformázástól.

**Beállíthatom a helyesírási nyelvet a bekezdés egy részére?**  
Igen. Használja a [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódust az egyedi részekhez, így egy bekezdés több nyelven írt szöveget is tartalmazhat.