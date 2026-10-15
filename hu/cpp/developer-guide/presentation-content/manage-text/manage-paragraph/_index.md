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
- akasztott behúzás
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
description: Ismerje meg, hogyan hozhat létre és formázhat bekezdéseket, szakaszokat, felsorolásjeleket, számozott listákat, behúzásokat, HTML tartalmakat és bekezdésképeket az Aspose.Slides for C++ segítségével.
---
## **Áttekintés**

Aspose.Slides for C++ a szöveget szövegdobozok, bekezdések és szakaszok hierarchiájában ábrázolja:

* [ITextFrame](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/) egy alakzat szövegtárolója, és hozzáférést biztosít a bekezdésgyűjteményéhez.
* [IParagraph](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/) egy bekezdést képvisel egy szövegdobozban, és hozzáférést biztosít a szakaszokhoz valamint a bekezdés‑szintű formázáshoz.
* [IPortion](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/) egy szövegszakaszt jelent egy bekezdésen belül. Minden szakasz saját szöveggel és karakter‑szintű formázással rendelkezhet.

Egy bekezdés tehát több különböző betűtípust, színt, méretet és egyéb formázást tartalmazhat több szakasz használatával.

## **Bekezdések létrehozása és formázása**

Hozzon létre bekezdéseket egy alakzat szövegdobozában, és használjon szakaszokat az egyedi szövegrészek formázásához. Ez a szakasz bemutatja, hogyan kombinálható több szakasz egy bekezdésben, és hogyan alkalmazhatók különböző színek, betűméretek és stílusok.

### **Bekezdések létrehozása több szakaszzal**

A következő C++ példakód három bekezdést hoz létre, mindegyik három szövegrészt (portion) tartalmaz a [IParagraph::get_Portions](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/get_portions/) gyűjteményében. Újra felhasználja az alapértelmezett bekezdést és annak üres szakaszát, majd hozzáadja a maradék bekezdéseket és szakaszokat. A formázást a [IPortion::get_PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/get_portionformat/) segítségével alkalmazzuk: az első szakasz minden bekezdésben piros, félkövér és 15 pont; a második kék, dőlt és 18 pont. A harmadik szakasz az alapértelmezett formázást őrzi meg:

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
for (auto paragraphIndex = 0; paragraphIndex < paragraphCount; paragraphIndex++)
{
    auto paragraph = textFrame->get_Paragraph(paragraphIndex);
    auto portionCount = paragraph->get_Portions()->get_Count();
    for (auto portionIndex = 0; portionIndex < portionCount; portionIndex++)
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

## **Felsorolások és számozott listák létrehozása**

Rendszerezze a bekezdés szövegét listákba szimbólumokkal, számokkal vagy egyedi képekkel. Ebben a szakaszban a felsorolásformázás, a többszintű listák és az egyedi kezdőszámok kerülnek bemutatásra.

### **Felsorolás vagy számozott lista létrehozása**

A felsorolások és a számozás megkönnyítik az egyetemes elemek áttekintését. Az Aspose.Slides‑ben a lista beállításait a [IBulletFormat](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/) határozza meg.

Ez a C++ példakód egy szimbólum‑felsorolást és egy számozott elemet ad ugyanahhoz a szövegdobozhoz. A [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) kiválasztja a felsorolás típusát, míg a [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) adja meg a szimbólumot, és a [IBulletFormat::set_NumberedBulletStyle](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstyle/) választja ki a számozás stílusát. Mindkét elem fekete felsorolást használ, magassága 100 % és a bekezdés behúzása 25 pont:

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

A képes felsorolások lehetővé teszik egy egyedi kép használatát a szimbólum vagy szám helyett.

A példa a `bullets.png` fájlt igényli a munkakönyvtárban. Ez a C++ példakód egy [IPPImage](https://reference.aspose.com/slides/cpp/aspose.slides/ippimage/) formájában adja hozzá a prezentáció képgyűjteményéhez, és beállítja bekezdés‑felsorolásként. A [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) értékét képes felsorolásra állítja, és a képet a [IBulletFormat::get_Picture](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/get_picture/) adja meg. A [IBulletFormat::set_Height](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_height/) 100 %-ra van állítva, hogy a felsorolás a bekezdés szövegéhez viszonyítva legyen méretezve:

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

Állítsa be a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) értékét, hogy a bekezdéseket egy lista különböző szintjeire helyezze. A legfelső szint mélysége `0`.

Ez a C++ példakód a [IParagraphFormat::set_Depth](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_depth/) értékét 0‑tól 3‑ig adja négy bekezdésnek, egy hierarchiát hozva létre egyetlen szövegdobozban. Minden bekezdés szimbólum‑felsorolást használ, a [IBulletFormat::set_Char](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_char/) egy kör alakú és egy kötőjel szimbólum között váltogat, hogy megkülönböztessék az egymás melletti szinteket:

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

Használja a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) metódust a számozott bekezdés kezdeti számának megadásához.

Ez a C++ példakód a [IBulletFormat::set_Type](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_type/) értékét számozásra állítja három bekezdésnél, és a [IBulletFormat::set_NumberedBulletStartWith](https://reference.aspose.com/slides/cpp/aspose.slides/ibulletformat/set_numberedbulletstartwith/) értékeit 2, 3 és 7‑re állítja. A kezdőérték minden bekezdésnél külön van konfigurálva, lehetővé téve, hogy a megjelenített számok kihagyjanak értékeket:

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

Állítsa be a bekezdés margóit és behúzásait az első sor és a sortörés pozíciójának szabályozásához. A bekezdés végjelét is formázhatja külön a látható szövegszakaszoktól.

### **Első sor behúzásának beállítása**

Használja a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) metódust a bekezdés első sorának behúzásához. Ez a metódus csak az első sort mozgatja a bekezdés bal margójához képest. A pozitív érték jobbra tolja az első sort, míg a többi sor a bekezdés törzsön marad.

Használja a [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/)‑t, ha a teljes bekezdést szeretné eltolni. Használja a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/)‑t, ha csak az első sort akarja eltolni.

A következő példa három bekezdésnek 20 pont [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) értéket és 0, 20, 40 pont [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) értéket ad. Az első sorok fokozatosan nagyobb eltolással kezdődnek, míg a tördelő sorok megőrzik ugyanazt a bal margót:

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

![Az első sor behúzása a bekezdésekben](first_line_indent.png)

### **Akasztott behúzás beállítása**

Az akasztott behúzás olyan bekezdéselrendezés, amelyben az első sor a többi sor bal oldalán kezdődik. Az Aspose.Slides‑ben ezt a hatást a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) metódussal hozhatja létre. Negatív értéket adva a metódusnak az első sor balra mozdul a bekezdés törzséhez képest.

Gyakorlatban a [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) határozza meg a bekezdés törzs bal pozícióját, a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) pedig az első sor helyzetét a margón belül. Akasztott behúzás létrehozásához állítson be pozitív `MarginLeft` értéket és negatív `Indent` értéket.

Ez a formázás hasznos bibliográfiák, hivatkozások, szószedet-bejegyzések és egyéb bekezdések esetén, ahol a tördelő soroknak a bekezdés törzse alá kell illeszkedniük, nem pedig az első sor első karaktere alá.

A következő C++ példakód a [IParagraphFormat::set_MarginLeft](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_marginleft/) 40  és 60 pont értékét párosítja a [IParagraphFormat::set_Indent](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_indent/) –20  és –30 pont értékeivel. Minden bekezdésnél az első sor a tördelő sorok bal oldalán kezdődik; a második bekezdés mélyebb akasztott behúzást kap:

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

![Az akasztott behúzás a bekezdésekben](hanging_indent.png)

### **Befejező bekezdés futás tulajdonságainak beállítása**

Az [IParagraph::set_EndParagraphPortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/set_endparagraphportionformat/) metódus szabályozza a bekezdés végjellel kapcsolatos formázást. A példa betölti a `Test.pptx`‑et, amelynek legalább egy diát kell tartalmaznia. A következő példa egy [PortionFormat](https://reference.aspose.com/slides/cpp/aspose.slides/portionformat/) objektumot hoz létre, amelynek [IBasePortionFormat::set_FontHeight](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_fontheight/) értéke 48 pont, és [IBasePortionFormat::set_LatinFont](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_latinfont/) Times New Roman. Ezt a formátumot a második bekezdés végjelére alkalmazza, a látható szövegszakaszokat változatlanul hagyva:

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

Azokra a bekezdés‑szabályokra, amelyek az automatikus sortörést és a sorvégi írásjeleket befolyásolják, lásd a [Vonalbontás vezérlése](/slides/hu/cpp/text-formatting/#control-line-breaking) és a [Akadásos írásjelek vezérlése](/slides/hu/cpp/text-formatting/#control-hanging-punctuation) oldalakat.

Használja az [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) metódust a bekezdés által elfoglalt sorok számának meghatározásához a szöveg elrendezése után, beleértve az automatikus sortörést. Ez akkor hasznos, amikor a szöveg hosszát és elrendezését kell ellenőrizni prezentációs sablonokban.

Egy bekezdés az [ITextFrame::get_Paragraphs](https://reference.aspose.com/slides/cpp/aspose.slides/itextframe/get_paragraphs/) egyik eleme, és több megjelenített sort is elfoglalhat. Egy explicit sortörés egy bekezdésen belül új sort kényszerít anélkül, hogy egy új bekezdést hozna létre. Az automatikus sortörés a rendelkezésre álló szélesség alapján hoz létre sorokat, anélkül, hogy explicit sortörés‑karaktereket szúrna be a szövegbe. Ezért a bekezdések vagy sortörés‑karakterek számlálása nem adja meg a megjelenített sorok számát.

A következő példa egy szöveges alakzatot hoz létre, megszámolja annak sorait, szűkíti az alakzatot, majd egy rövidebb szövegre cseréli a tartalmat. A példa engedélyezi az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) engedélyezését, és letiltja az [ITextFrameFormat::set_AutofitType](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_autofittype/) automatikus méretezését, hogy az alakzat szélessége szabályozza a sortörést anélkül, hogy a szöveget automatikusan zsugorítaná vagy az alakzat méretét változtatná. Minden mérés a [IParagraph::GetLinesCount](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getlinescount/) segítségével történik. Az alakzat méretei pontban vannak megadva. Végül a példa egy újabb bekezdést ad hozzá, és összegzi a sorok számát a teljes szövegdobozban.

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

Ezzel a szöveggel és ezekkel a méretekkel a forma szűkítése növeli a sorok számát, míg a szöveg rövidebb változatra cserélése csökkenti azt. A pontos számok a betűkészletek elérhetőségétől és helyettesítésétől, a betűmérettől, a margóktól, a behúzásoktól, a sortöréstől és az autofit beállításoktól függnek. Használja a célkörnyezethez tervezett betűkészleteket és elrendezési beállításokat a sablon ellenőrzésekor.

A sorok száma önmagában nem határozza meg, hogy a szöveg túlcsordul-e a tárolóban. A rendelkezésre álló magasság, a sormagasságok, a bekezdés‑ és sorköz, valamint az autofit viselkedés is számít; még egyetlen sor is túllépheti a rendelkezésre álló szélességet, ha a sortörés ki van kapcsolva.

## **Bekezdés tartalmának importálása és exportálása**

Használja a HTML‑t a szöveg prezentációba hozatalához vagy a meglévő bekezdések exportálásához külső használatra. Ez a szakasz bemutatja, hogyan renderelhet egyedi bekezdéseket képként, beleértve a táblázatcellákban lévő bekezdéseket is.

### **HTML szöveg importálása bekezdésekbe**

Használja a [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) metódust, hogy a HTML‑markupt bekezdésekké és szakaszokká konvertálja egy szövegdobozban.

Ez a C++ példakód beolvassa a HTML‑t egy fájlból, és átadja a [ParagraphCollection::AddFromHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/addfromhtml/) metódusnak. Törli a szövegdoboz alapértelmezett bekezdését, hogy a keret csak a importált tartalmat tartalmazza. A téglalap alakzat 10 pont margót hagy minden dián a széleken:

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

### **Bekezdés szövegének exportálása HTML‑be**

Használja a [ParagraphCollection::ExportToHtml](https://reference.aspose.com/slides/cpp/aspose.slides/paragraphcollection/exporttohtml/) metódust, hogy a kiválasztott bekezdés‑tartományt HTML‑ként exportálja. Ha a prezentáció szövegét egy weboldalon szeretné újra felhasználni, előfordulhat, hogy meg akarja őrizni a helyi kiemeléseket anélkül, hogy a prezentáció betűtípusa, mérete vagy szövegdoboz‑stílusa átkerülne. Állítsa be a [TextToHtmlConversionOptions::set_TextInheritanceLimit](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/set_textinheritancelimit/) értékét, hogy szabályozza, mennyire követi a konvertáló a formázási öröklődést.

Töltse le a [mintaprezentációt](text-inheritance.pptx), és helyezze az alkalmazás munkakönyvtárába. Az első dián egy szövegdoboz található a „Inherited text; explicit red 18pt” szöveggel. A bemenet szándékosan több formázási szintet használ:

- A prezentáció alapértelmezett szövegstílusa a Calibri‑t és 28 pt méretet biztosítja.
- A szövegdoboz első‑szintű szövegstílusa kék szöveget és dőlt betűt biztosít.
- A bekezdés kifejezetten félkövér szöveget állít be.
- A második szakasz, „explicit red 18pt”, kifejezetten piros szöveget és 18 pt méretet állít be.

A következő példakód háromszor exportálja ugyanazokat a bekezdéseket. A [TextToHtmlConversionOptions](https://reference.aspose.com/slides/cpp/aspose.slides.export/texttohtmlconversionoptions/) objektumot adja át az exportáló metódusnak, és minden eredményt egy külön UTF‑8 HTML‑fájlba ír:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/Presentation.h>
#include <Export/TextInheritanceLimit.h>
#include <Export/TextToHtmlConversionOptions.h>
#include <system/array.h>
#include <system/console.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/text/encoding.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::IO;
using namespace System::Text;

auto presentation = MakeObject<Presentation>(u"text-inheritance.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);
auto textShape = AsCast<IAutoShape>(shape);

if (textShape != nullptr && textShape->get_TextFrame() != nullptr)
{
    auto paragraphs = textShape->get_TextFrame()->get_Paragraphs();
    auto modes = MakeArray<TextInheritanceLimit>({TextInheritanceLimit::All, TextInheritanceLimit::TextBox, TextInheritanceLimit::ParagraphOnly});
    auto fileNames = MakeArray<String>({u"All.html", u"TextBox.html", u"ParagraphOnly.html"});

    for (auto i = 0; i < modes->get_Length(); i++)
    {
        auto options = MakeObject<TextToHtmlConversionOptions>();
        options->set_TextInheritanceLimit(modes[i]);

        auto html = paragraphs->ExportToHtml(0, paragraphs->get_Count(), options);
        File::WriteAllText(fileNames[i], html, Encoding::get_UTF8());
    }
}
else
{
    Console::WriteLine(u"The first shape is not a text shape.");
}

presentation->Dispose();
```

Az előállított HTML a következő CSS‑t tartalmazza az első szakaszhoz, „Inherited text; “. A táblázat a releváns deklarációkat listázza; a többi generált tulajdonság el van hagyva az átláthatóság kedvéért.

| Kimenet | Az első szakaszhoz tartozó releváns CSS | Megjelenés |
| --- | --- | --- |
| `All.html` | `font-family:'Calibri'; font-size:28pt; color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg 28 pt Calibri betűtípussal, ha az a betűtípus elérhető. |
| `TextBox.html` | `color:#0000ff; font-style:italic; font-weight:bold` | Kék, félkövér, dőlt szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot és a méretet. |
| `ParagraphOnly.html` | `font-weight:bold` | Félkövér szöveg; a környező oldal vagy böngésző biztosítja a betűcsaládot, méretet, színt és dőlt stílust. |

A második szakasz megtartja a `color:#ff0000`, `font-size:18pt` és `font-weight:bold` értékeket mindhárom kimenetben. Emellett az `All` és `TextBox` esetében megtartja a dőlt formázást, de a `ParagraphOnly` esetben nem. Az öröklődés korlátozása ezért nem távolítja el a bekezdéshez vagy szakaszhoz kifejezetten hozzárendelt formázást.

Nyissa meg a fájlokat ugyanabban a böngészőben a közti összehasonlításhoz. A két korlátozott módban a kihagyott CSS‑tulajdonságokat a céllap stílusai vagy a böngésző alapértékei oldják fel, ezért a végeredmény attól függ, hogy hol használják a HTML‑t.

### **Bekezdés renderelése képként**

Az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) közvetlenül egy egyedi bekezdést renderel, és egy [IImage](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/) objektumot ad vissza. Mentse az eredményt fájlba vagy adatfolyamba az [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/) segítségével. Nem szükséges a tartalmazó alakzatot renderelni vagy a bitmapet kézzel levágni.

Az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) `nullptr`‑t ad vissza, ha a bekezdés nem található a szülőgyűjteményben, nincs érvényes renderelési határa, vagy nem renderelhető. Ellenőrizze az eredményt a mentés előtt, és a használat után szabadítsa fel a visszakapott képet.

#### **Bekezdés renderelése alapértelmezett méretezésben**

A példa a `sample.pptx`‑et használja, egyetlen diával, amelynek első alakzata egy három bekezdést tartalmazó szövegdoboz.

![A szövegdoboz három bekezdéssel](paragraph_to_image_input.png)

A következő példakód a második bekezdést (index 1) választja ki, és a [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)‑t skálaparaméterek nélkül hívja. Ellenőrzi, hogy az alakzat tartalmazza a szükséges bekezdést, és hogy a renderelés képet ad vissza, mielőtt a [IImage::Save](https://reference.aspose.com/slides/cpp/aspose.slides/iimage/save/)‑vel PNG‑ként mentené. A példa a mentés után felszabadítja a képet.

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

#### **Bekezdés renderelése táblacellában méretezéssel**

Használja az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/) túlterhelését, amely `float scaleX` és `float scaleY` paramétereket fogad, a vízszintes és függőleges méretezési tényezők beállításához. A következő példakód táblát hoz létre, és a bekezdést az első cellájában kétszeres alap szélességgel és magassággal rendereli, majd PNG képként menti.

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

Az 1‑es méretezési tényező az adott tengelyet az alap pixelméreten tartja. Például a 2‑es tényező mindkét tengelyen egy képet eredményez, amelynek szélessége és magassága megközelítőleg kétszerese az alap méretnek, így négyzetes többszöröse a pixelnek. Nagyobb tényezők általában élesebb szöveget eredményeznek nagyítás vagy nagyfelbontású kimenet esetén, de növelik a memóriahasználatot és a fájlméretet. Az 1‑nél kisebb tényezők kisebb képet, kevesebb részlettel állítanak elő. A képarány megőrzéséhez használjon egyenlő tényezőket; a különböző vízszintes és függőleges tényezők a kimenetet különbözőképpen nyújtják.

Egy teljes alakzat renderelése az [IShape::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/ishape/getimage/) segítségével akkor hasznos, ha a kimenetnek tartalmaznia kell az alakzat kitöltését, szegélyét vagy egyéb vizuális kontextusát. Egy csak bekezdést tartalmazó képhez használja az [IParagraph::GetImage](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getimage/)‑t.

## **GYIK**

**Teljesen letilthatom a sortörést egy szövegdobozban?**

Igen. Használja az [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/cpp/aspose.slides/itextframeformat/set_wraptext/) metódust a sortörés letiltásához, így a sorok nem törnek a szövegdoboz szélein.

**Hogyan kaphatom meg egy konkrét bekezdés pontos diára vonatkozó határait?**

Használja az [IParagraph::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraph/getrect/) metódust a bekezdés határoló téglalapjának lekéréséhez. Az [IPortion::GetRect](https://reference.aspose.com/slides/cpp/aspose.slides/iportion/getrect/) egy egyes szakasz határait adja vissza.

**Hol szabályozható a bekezdés igazítása (balra, jobbra, középre vagy szövegtördelés)?**

Az [IParagraphFormat::set_Alignment](https://reference.aspose.com/slides/cpp/aspose.slides/iparagraphformat/set_alignment/) bekezdés‑szintű beállítás, amely a teljes bekezdésre vonatkozik, függetlenül az egyes szakaszok formázásától.

A soron belül különböző betűméretű szakaszok függőleges igazításához lásd a [Betűk igazítása egy soron belül](/slides/hu/cpp/text-formatting/#align-fonts-within-a-line) oldalt.

**Beállítható a helyesírási nyelv egy bekezdés részére?**

Igen. Használja az [IBasePortionFormat::set_LanguageId](https://reference.aspose.com/slides/cpp/aspose.slides/ibaseportionformat/set_languageid/) metódust egyes szakaszokhoz, így egy bekezdés több nyelven is tartalmazhat szöveget.