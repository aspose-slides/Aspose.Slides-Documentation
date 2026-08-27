---
title: C++ használatával szövegdobozok kezelése prezentációkban
linktitle: Szövegdoboz kezelése
type: docs
weight: 20
url: /hu/cpp/manage-textbox/
keywords:
- szövegdoboz
- szövegkeret
- szöveg hozzáadása
- szöveg frissítése
- szövegdoboz létrehozása
- szövegdoboz ellenőrzése
- szövegoszlop hozzáadása
- hiperhivatkozás hozzáadása
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Az Aspose.Slides for C++ megkönnyíti a szövegdobozok létrehozását, szerkesztését és másolását PowerPoint és OpenDocument fájlokban, ezáltal javítva a prezentáció automatizálását."
---
## **Bevezetés**

A diákon lévő szövegek általában szövegdobozokban vagy alakzatokban vannak. Ezért egy szöveg hozzáadásához a diára szövegdobozt kell hozzáadni, majd szöveget helyezni a szövegdobozba. Az Aspose.Slides for C++ biztosítja a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) interfészt, amely lehetővé teszi olyan alakzat hozzáadását, amely szöveget tartalmaz.

{{% alert title="Info" color="info" %}}
Az Aspose.Slides emellett biztosítja az [IShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_shape) interfészt, amely lehetővé teszi alakzatok hozzáadását a diákhoz. Azonban nem minden, az `IShape` interfészen keresztül hozzáadott alakzat képes szöveget tárolni. Azonban a [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) interfészen keresztül hozzáadott alakzatok tartalmazhatnak szöveget. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
Ezért, amikor egy olyan alakzattal dolgozunk, amelyhez szöveget szeretnénk hozzáadni, érdemes ellenőrizni és megerősíteni, hogy az `IAutoShape` interfészen keresztül lett átalakítva. Csak ekkor lesz lehetőség a [TextFrame](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.text_frame) használatára, amely az `IAutoShape` egy tulajdonsága. Lásd a [Update Text](https://docs.aspose.com/slides/hu/cpp/manage-textbox/#update-text) szakaszt ezen az oldalon. 
{{% /alert %}}

## **Szövegdoboz létrehozása a dián**

Egy szövegdoboz létrehozásához a dián, kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.presentation) osztályból. 
2. Szerezzen egy hivatkozást az újonnan létrehozott prezentáció első diájához. 
3. Adjunk hozzá egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_auto_shape) objektumot, amelynek a [ShapeType](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) `Rectangle`-re van állítva, a dia megadott pozíciójában, és szerezzük meg az újonnan hozzáadott `IAutoShape` objektum hivatkozását. 
4. Adjunk egy `TextFrame` tulajdonságot a `IAutoShape` objektumhoz, amely szöveget fog tartalmazni. Az alábbi példában ezt a szöveget adtuk hozzá: *Aspose TextBox*
5. Végül írjuk ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C++ kód – a fenti lépések megvalósítása – bemutatja, hogyan lehet szöveget hozzáadni egy diához:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Példányosítja a Presentation objektumot
auto pres = System::MakeObject<Presentation>();

// Lekéri a prezentáció első diát
auto sld = pres->get_Slides()->idx_get(0);

// Hozzáad egy AutoShape-ot, típusát Téglalapra állítva
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Hozzáad TextFrame-et a Téglalaphoz
ashp->AddTextFrame(u" ");

// Hozzáfér a szövegkerethez
auto txtFrame = ashp->get_TextFrame();

// Létrehozza a Paragraph objektumot a szövegkerethez
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Létrehozza a Portion objektumot a bekezdéshez
auto portion = para->get_Portions()->idx_get(0);

// Beállítja a szöveget
portion->set_Text(u"Aspose TextBox");

// Elmenti a prezentációt a lemezre
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Szövegdoboz alakzat ellenőrzése**

Az Aspose.Slides biztosítja a [get_IsTextBox](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_istextbox/) metódust az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) interfészen, amely lehetővé teszi az alakzatok vizsgálatát és a szövegdobozok azonosítását.

![Text box and shape](istextbox.png)

Ez a C++ kód bemutatja, hogyan ellenőrizhető, hogy egy alakzat szövegdobozként lett-e létrehozva: 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Vegye figyelembe, hogy ha egyszerűen egy autóalakzatot ad hozzá az [IShapeCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/) interfész `AddAutoShape` metódusával, az autóalakzat `get_IsTextBox` metódusa `false` értéket ad vissza. Azonban, ha szöveget ad hozzá az autóalakzathoz a `AddTextFrame` vagy a `set_Text` metódussal, a `get_IsTextBox` metódus `true` értéket ad vissza.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() hamis értéket ad vissza
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() igaz értéket ad vissza

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() hamis értéket ad vissza
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() igaz értéket ad vissza

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() hamis értéket ad vissza
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() hamis értéket ad vissza

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() hamis értéket ad vissza
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() hamis értéket ad vissza
```

## **A szövegkeretet birtokló alakzat megtalálása**

Általános szövegfeldolgozó kódban előfordulhat, hogy egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) objektumot kapunk anélkül, hogy tudnánk, mely prezentációs objektum tartalmazza. Használja az [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) metódust, hogy visszatérjen a tulajdonos [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) objektumhoz.

Egy szövegkeret esetén, amely egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) vagy egy másik szöveget tartalmazó alakzathoz tartozik, az [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) a tulajdonost adja vissza, míg az [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr`-t. Mindkét metódus csak olvasási navigációt biztosít, ezért a hívásuk nem változtatja meg a tulajdonjogot. Mindig ellenőrizze a visszaadott értéket `nullptr`-ra, mielőtt hozzáférne az alakzathoz.

Egy teljes példa, amely az alakzat- és táblacellatulajdonosokat azonosítja, beleértve a SmartArt csomópontokkal kapcsolatos alakzatokat, megtalálható a [Search and Replace Text](/slides/hu/cpp/search-and-replace-text/) oldalon.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az Aspose.Slides biztosítja a [set_ColumnCount](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) és a [set_ColumnSpacing](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) metódusokat (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) interfész és a [TextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) osztály részeként), amelyek lehetővé teszik oszlopok hozzáadását a szövegdobozokhoz. Megadhatja a szövegdobozban lévő oszlopok számát, valamint a pontokban megadott távolságot az oszlopok között. 

Ez a C++ kód bemutatja a leírt műveletet: 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// Lekéri a prezentáció első diát
auto slide = presentation->get_Slides()->idx_get(0);

// Hozzáad egy AutoShape-ot, típusát Téglalapra állítva
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Hozzáad TextFrame-et a Téglalaphoz
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Lekéri a TextFrame szövegformátumát
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Megadja a TextFrame oszlopainak számát
format->set_ColumnCount(3);

// Megadja az oszlopok közötti távolságot
format->set_ColumnSpacing(10);

// Elmenti a prezentációt
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Oszlopok hozzáadása egy szövegkerethez**
Az Aspose.Slides for C++ biztosítja a [set_ColumnCount](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) metódust (az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_text_frame_format) interfészen), amely lehetővé teszi oszlopok hozzáadását a szövegkeretekben. Ezzel a metódussal meghatározhatja a kívánt oszlopszámot egy szövegkeretben. 

Ez a C++ kód bemutatja, hogyan lehet oszlopot hozzáadni egy szövegkerethez:

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Szöveg frissítése**

Az Aspose.Slides lehetővé teszi a szövegdobozban vagy a teljes prezentációban lévő szövegek módosítását vagy frissítését. 

Ez a C++ kód egy olyan műveletet mutat be, amely során a prezentáció összes szövege frissül vagy módosul:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //Szöveget módosít
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Formázást módosít
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Menti a módosított prezentációt
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Szövegdoboz hozzáadása hiperhivatkozással** 

Hozzáadhat egy hivatkozást egy szövegdobozhoz. Ha a szövegdobozt rákattintják, a felhasználók a linket nyitják meg. 

Egy linket tartalmazó szövegdoboz hozzáadásához kövesse az alábbi lépéseket:

1. Hozzon létre egy példányt a `Presentation` osztályból. 
2. Szerezzen hivatkozást az újonnan létrehozott prezentáció első diájához. 
3. Adjunk hozzá egy `AutoShape` objektumot, amelynek a `ShapeType` `Rectangle`-re van állítva a dia megadott pozíciójában, és szerezzük meg az újonnan hozzáadott AutoShape objektum hivatkozását.
4. Adjunk egy `TextFrame`-et az `AutoShape` objektumhoz, amely alapértelmezett szövegként a *Aspose TextBox*-t tartalmazza. 
5. Példányosítsa az `IHyperlinkManager` osztályt. 
6. Rendelje hozzá az `IHyperlinkManager` objektumot a [set_HyperlinkClick](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) metódushoz, amely a `TextFrame` kívánt részéhez tartozik. 
7. Végül írja ki a PPTX fájlt a `Presentation` objektumon keresztül. 

Ez a C++ kód – a fenti lépések megvalósítása – bemutatja, hogyan adhat hozzá egy hiperhivatkozással ellátott szövegdobozt a diához:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// Példányosít egy Presentation osztályt, amely egy PPTX-et képvisel
auto presentation = System::MakeObject<Presentation>();

// Lekéri a prezentáció első diáját
auto slide = presentation->get_Slides()->idx_get(0);

// Hozzáad egy AutoShape objektumot, típusát Téglalapra állítva
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Átkonvertálja az alakzatot AutoShape-re
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Hozzáfér az AutoShape-hez tartozó ITextFrame tulajdonsághoz
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Hozzáad némi szöveget a kerethez
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Beállítja a hiperhivatkozást a szövegrésszel
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Elmenti a PPTX prezentációt
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Mi a különbség egy szövegdoboz és egy szöveghelytartó között a mesterdiák használatakor?**

A [placeholder](/slides/hu/cpp/manage-placeholder/) örökli a stílust és pozíciót a [master](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslide/) diától, és felülírható a [layoutok](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/) során, míg egy normál szövegdoboz egy független objektum egy adott dián, és nem változik a layoutok váltásakor.

**Hogyan végezhetek tömeges szövegcsere műveletet a prezentáción belül anélkül, hogy a diagramok, táblázatok és SmartArt elemek szövegét módosítanám?**

Korlátozza az iterációt azok<|endoftext|>