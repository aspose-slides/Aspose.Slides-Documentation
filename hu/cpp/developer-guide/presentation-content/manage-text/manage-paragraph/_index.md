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
- függőbehúzás
- bekezdés felsorolás
- számozott lista
- felsorolt lista
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
description: "Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, részeket, felsorolásokat, számozott listákat, behúzásokat, HTML tartalmat és bekezdésképeket az Aspose.Slides for C++ használatával."
---
## **Áttekintés**

Az Aspose.Slides for C++ a szöveget szövegdobozok, bekezdések és részek hierarchiájaként ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) a formában lévő szövegkonténert képviseli, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) egy bekezdést képvisel a szövegdobozban, és hozzáférést biztosít a részeihez és a bekezdés‑szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) egy szövegfolyamot képvisel egy bekezdésen belül. Minden résznek saját szövege és karakter‑szintű formázása lehet.

Ezáltal egy bekezdés több rész használatával különböző betűtípusú, színű, méretű és egyéb formázású szöveget tartalmazhat.

## **Bekezdések létrehozása és formázása**

### **Több részből álló bekezdések létrehozása**

Az alábbi lépések egy szövegdobozt hoznak létre három bekezdéssel, mindegyik három részt tartalmazva:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását indexe alapján.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Használja az alapértelmezett bekezdést, és adjon hozzá még két [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) objektumot a szövegdobozhoz.
6. Adjon elegendő [IPortion](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/) objektumot minden bekezdéshez, hogy három részük legyen. Az alapértelmezett bekezdés már tartalmaz egy üres részt.
7. Állítsa be minden rész szövegét.
8. Alkalmazzon karakter‑szintű formázást a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/get_portionformat/) segítségével.
9. Mentse a módosított prezentációt.

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

## **Felsorolás‑ és számozott listák létrehozása**

### **Felsorolás vagy számozott lista létrehozása**

A felsorolás jelei és a számozás megkönnyítik az elemek áttekintését. Az Aspose.Slides‑ben a lista beállításait az [IBulletFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/) határozza meg.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a kiválasztott diára.
4. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
5. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) objektumot egy szimbólum‑felsoroláshoz.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Symbol](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)‑ra, és adja meg a felsorolás karakterét.
8. Állítsa be a bekezdés szövegét, behúzását, a felsorolás színét és magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Hozzon létre egy második bekezdést, és állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Numbered](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)‑ra.
11. Konfigurálja a számozott felsorolás stílusát, majd adja hozzá a bekezdést a szövegdobozhoz.
12. Mentse a prezentációt.

Ez a C++ példa szimbólum‑ és számozott felsorolást hoz létre:

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

### **Képes felsorolás használata**

A képes felsorolások lehetővé teszik, hogy egy egyedi képet használjon szimbólum vagy szám helyett.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg a megfelelő dia hivatkozását indexe alapján.
3. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és szerezze meg annak [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
4. Távolítsa el az alapértelmezett bekezdést a szövegdobozból.
5. Töltse be a felsorolás képet, és adja hozzá a prezentáció képgyűjteményéhez [IPPImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ippimage/)ként.
6. Hozzon létre egy [Paragraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/paragraph/) objektumot, és állítsa be a szövegét.
7. Állítsa be a [IBulletFormat::set_Type](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_type/) értékét a [BulletType::Picture](https://reference.aspose.com/slides/hu/cpp/aspose.slides/bullettype/)‑ra.
8. Az [ISlidesPicture::set_Image](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidespicture/set_image/) segítségével rendelje hozzá a képet, és állítsa be a felsorolás magasságát.
9. Adja hozzá a bekezdést a szövegdobozhoz.
10. Mentse a módosított prezentációt.

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

Állítsa be az [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) értékét, hogy a bekezdéseket a lista különböző szintjein helyezze el. A legfelső szint mélysége `0`.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot, és nyisson meg egy diát.
2. Adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és törölje az alapértelmezett bekezdést a szövegdobozából.
3. Hozzon létre négy bekezdést, és konfigurálja azok felsorolás‑szimbólumait.
4. Állítsa be a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_depth/) értékeit `0`, `1`, `2` és `3`‑ra.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

Ez a C++ példa négy szintű felsorolást hoz létre:

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

Használja a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) metódust, hogy a számozott bekezdés kezdeti számát egyéni értékre állítsa.

1. Hozzon létre egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot, és adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet egy diához.
2. Törölje a forma szövegdobozából az alapértelmezett bekezdést.
3. Hozzon létre három számozott bekezdést.
4. Állítsa be a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékét `2`, `3` és `7`‑re a megfelelő bekezdéseknél.
5. Adja hozzá a bekezdéseket a szövegdobozhoz, majd mentse a prezentációt.

Ez a C++ példa minden bekezdéshez egyedi kezdőszámot ad meg:

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

## **Bekezdéselrendezés és végjellemzők vezérlése**

### **Első sor behúzásának beállítása**

Használja a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásának szabályozásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolják az első sort, míg a többi sor a bekezdés szövegéhez igazodik.

Használja a [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑t, ha a teljes bekezdést szeretné eltolni. Az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) akkor használandó, ha csak az első sort kell mozgatni.

Az alábbi példa több bekezdést hoz létre, és különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket alkalmaz, hogy bemutassa, miként befolyásolja az első sor behúzása a bekezdés elrendezését.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg a céldiat.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre több bekezdést, és állítson be különböző [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értékeket.
6. Adja hozzá a bekezdéseket a szövegdobozhoz.
7. Mentse a módosított prezentációt.

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

![A bekezdések első sorának behúzása](first_line_indent.png)

### **Függőleges behúzás beállítása**

A függőleges behúzás egy olyan bekezdéselrendezés, ahol az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides‑ben ezt a hatást az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) segítségével hozhatja létre. Állítson negatív értéket a behúzásra, hogy az első sor balra tolódjon a bekezdés törzsehez képest.

Gyakorlatban az [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) határozza meg a bekezdés törzsének bal pozícióját, míg az [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) az első sor pozícióját a már meglévő margóhoz képest. Függőleges behúzás létrehozásához állítson be pozitív left‑margin értéket és negatív behúzást.

Ez a formázás hasznos például bibliográfiák, hivatkozások, szószedetek és más olyan bekezdések esetén, ahol a tördelődő soroknak a bekezdés törzs alatt kell elhelyezkedniük, nem pedig az első sor első karaktere alatt.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Szerezze meg a céldiat.
3. Adjon hozzá egy téglalap alakú [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet a diára.
4. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
5. Hozzon létre bekezdéseket, és állítson be pozitív [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket minden bekezdéshez.
6. Állítson be negatív [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_indent/) értéket a függőleges behúzás eléréséhez.
7. Adja hozzá a bekezdéseket a szövegdobozhoz.
8. Mentse a módosított prezentációt.

Ez a kód megmutatja, hogyan állítható be egy bekezdés függőleges behúzása:

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

![A bekezdések függőleges behúzása](hanging_indent.png)

### **Befejező bekezdésrész tulajdonságainak beállítása**

Az [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) szabályozza a bekezdés záró karakterének formázását. Az alábbi példa egy betűméretet és latin betűtípust állít be a második bekezdés záró karakterére:

1. Töltsön be egy [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) objektumot, és nyisson meg egy diát.
2. Adjon egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, és törölje annak alapértelmezett bekezdését.
3. Hozzon létre két bekezdést, és adjon hozzá szövegrétegeket.
4. Hozzon létre egy [PortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/portionformat/) objektumot a második bekezdés záró karakteréhez.
5. Állítsa be a [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_fontheight/) és a [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_latinfont/) értékeket.
6. Rendelje hozzá a formátumot az [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) metódussal, majd mentse a prezentációt.

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

Használja az [IParagraph::GetLinesCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által a szöveg elrendezése után elfoglalt sorok számának lekérdezésére, beleértve az automatikus tördelést is. Ez hasznos a szöveg hossza és elrendezése ellenőrzésénél prezentációs sablonokban.

Egy bekezdés a [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_paragraphs/) gyűjtemény egyik eleme, és több megjelenített sorban is megjelenhet. Egy explicit sortörés a bekezdésen belül új sort hoz létre anélkül, hogy új bekezdést generálna. Az automatikus tördelés a rendelkezésre álló szélesség alapján hoz létre sorokat anélkül, hogy expliciten sortörést illesztene a szövegbe. Így a bekezdések vagy sortörés karakterek számlálása nem adja meg a megjelenített sorok számát.

Az alábbi példa egy szöveges alakzatot hoz létre, megszámolja a sorait, szűkíti az alakzatot, majd rövidebb szövegre cseréli a tartalmat. A tördelés engedélyezve van, az automatikus méretezés le van tiltva, így az alakzat szélessége szabályozza a tördelést anélkül, hogy a szöveget automatikusan zsugorítaná vagy az alakzat méretét változtatná. Az alakzat mérete pontokban van megadva. Végül a példa egy további bekezdést ad hozzá, és összeadja a sorok számát a szövegdobozon belül.

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

Ezzel a szöveggel és ezzel a mérettel a forma szűkítése növeli a sorok számát, míg a szöveg rövid stringre cserélése csökkenti azt. A pontos számok változhatnak a betűtípus elérhetőségétől, a betűmérettől, a margóktól, a behúzásoktól, a tördeléstől és az automatikus illesztés beállításaitól. A sablon ellenőrzésekor használja azt a betűkészletet és elrendezést, amely a célkörnyezetben lesz alkalmazva.

A sorok száma önmagában nem határozza meg, hogy a szöveg kilóg-e a tárolóból. A rendelkezésre álló magasság, a sormagasságok, a bekezdés‑ és sorköz, valamint az automatikus illesztés viselkedése is számít; még egyetlen sor is túlnyúlhat a rendelkezésre álló szélességen, ha a tördelés le van tiltva.

## **Bekezdés tartalmának importálása és exportálása**

### **HTML szöveg importálása bekezdésekbe**

Használja az [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódust a HTML jelölés bekezdésekké és részekké konvertálásához egy szövegdobozban.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
2. Nyisson meg egy diát, és adjon hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet.
3. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát, és távolítsa el az alapértelmezett bekezdést.
4. Olvassa be a forrás HTML‑fájlt.
5. Adja át a HTML‑szöveget az [IParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/addfromhtml/) metódusnak.
6. Mentse a módosított prezentációt.

Ez a C++ példa HTML‑t importál egy szövegdobozba:

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

### **Paragraph szöveg exportálása HTML‑be**

Használja az [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust, hogy a kiválasztott bekezdéstarományt HTML‑ként exportálja.

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból, és töltse be a kívánt prezentációt.
2. Nyissa meg a diát, és keresse meg azt a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) elemet, amely a szöveget tartalmazza.
3. Szerezze meg a forma [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumát.
4. Hívja meg az [IParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphcollection/exporttohtml/) metódust a kezdő bekezdés indexével és az exportálandó bekezdések számával.
5. Írja a visszaadott HTML‑szöveget egy fájlba.

Ez a C++ példa az első szöveges alakzat összes bekezdését exportálja:

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

### **Bekezdés renderelése képként**

Az [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) közvetlenül renderel egy egyedi bekezdést, és visszaad egy [IImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/) objektumot. A visszakapott képet vagy fájlba, vagy adatfolyamba mentheti az [IImage::Save](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iimage/save/) metódussal. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet manuálisan vágni.

Az [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) `nullptr`‑t adhat vissza, ha a bekezdés nem található a szülő gyűjteményben, nincs érvényes renderelési határa, vagy nem lehet renderelni. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése az alapértelmezett mérettel**

Tegyük fel, hogy van egy `sample.pptx` nevű prezentációs fájlunk, egy diával, amelynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A három bekezdést tartalmazó szövegdoboz](paragraph_to_image_input.png)

Az alábbi példa a második bekezdést egy szabályos szövegdobozban az alapértelmezett mérettel rendereli, és PNG formátumban menti a visszakapott képet.

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

Használja az [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) azon túlterhelését, amely a `float scaleX` és `float scaleY` paramétereket fogadja, hogy beállítsa a vízszintes és függőleges méretezési tényezőket. Az alábbi példa egy táblázatot hoz létre, a bekezdést az első cellájában kétszeres szélességgel és magassággal rendereli, majd a képet PNG formátumban menti.

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

Az `1` tényező megtartja az adott tengely alapértelmezett pixelméretét. Például a `2` mindkét tényező esetén egy olyan képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alapértelmezett dimenzióknak, ezáltal négyszer annyi pixel. A nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagy felbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet is. Az `1`‑nél kisebb tényezők kisebb, részletgazdagabb képet adnak. A hányadosok egységessége megőrzi a bekezdés képarányát; a különböző vízszintes és függőleges hányadosok önállóan nyújtják a kimenetet.

Egy teljes alakzat renderelése az [IShape::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/getimage/) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy kizárólag bekezdés‑képre van szükség, akkor használja az [IParagraph::GetImage](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getimage/) metódust.

## **GYIK**

**Teljesen letiltható a sortördelés egy szövegdobozon belül?**

Igen. Használja az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust a tördelés letiltásához, hogy a sorok ne törjenek a szövegdoboz szélén.

**Hogyan kaphatom meg egy adott bekezdés pontos, dián lévő határait?**

Használja az [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getrect/) metódust a bekezdés körülhatároló téglalap lekérdezéséhez. Az [IPortion::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportion/getrect/) egy egyedi rész határait adja vissza.

**Hol van szabályozva a bekezdés igazítása (balra, jobbra, középre vagy sorkizárásra)?**

Az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraphformat/set_alignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésra vonatkozik, függetlenül az egyedi részformázástól.

**Beállítható a nyelvellenőrzés egy bekezdés egy részére?**

Igen. Használja az [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódust egyedi részeknél, így egy bekezdés több nyelven is tartalmazhat szöveget.