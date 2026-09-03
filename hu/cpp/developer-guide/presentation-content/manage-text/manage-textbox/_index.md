---
title: Szövegdobozok kezelése prezentációkban C++ használatával
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
description: "Szövegdobozok létrehozása, azonosítása, formázása és frissítése PowerPoint és OpenDocument prezentációkban az Aspose.Slides for C++ használatával."
---
## **Bevezetés**

Az Aspose.Slides for C++-ban a diák szövege szövegkeretekben tárolódik, amelyek alakzatokhoz tartoznak. A [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) interfész a leggyakoribb szöveget tartalmazó alakzatot képviseli, és a szövegét a [IAutoShape::get_TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_textframe/) metódussal teszi elérhetővé.

{{% alert color="info" title="Megjegyzés" %}}

Minden automatikus alakzat megvalósítja az [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/) interfészt, de nem minden alakzat automatikus alakzat vagy támogat szövegkeretet. Egy meglévő prezentáció feldolgozásakor ellenőrizze, hogy az alakzat implementálja‑e az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) interfészt, mielőtt hozzáférne a szövegéhez.

{{% /alert %}}

## **Szövegdoboz létrehozása egy dián**

Egy szövegdoboz létrehozásához adjon egy automatikus alakzatot a diához, szöveget adjon a szövegkeretéhez, majd mentse a prezentációt. A következő példa egy téglalap alakú szövegdobozt hoz létre:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 75, 300, 50);
textBox->AddTextFrame(u"Aspose TextBox");

presentation->Save(u"TextBox.pptx", SaveFormat::Pptx);
```

A [IShapeCollection::AddAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapecollection/addautoshape/)‑nek átadott koordinátákat és méreteket pontokban mérik. Az [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) inicializálja a szövegkeretet a megadott szöveggel.

## **Szövegdoboz alakzat ellenőrzése**

Használja az [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_istextbox/) metódust annak meghatározására, hogy egy automatikus alakzat szövegdobozként kezelhető‑e. Ez hasznos, ha egy prezentáció szöveget tartalmazó és kizárólag grafikus automatikus alakzatokat egyaránt tartalmaz.

![Egy szövegdoboz és egy alakzat](istextbox.png)

A következő példa minden automatikus alakzatot vizsgál meg egy prezentációban:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 120, 40);
textBox->AddTextFrame(u"Text box");
slide->get_Shapes()->AddAutoShape(ShapeType::Ellipse, 150, 10, 40, 40);

for (const auto& currentSlide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(currentSlide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape != nullptr)
        {
            Console::WriteLine(autoShape->get_IsTextBox() ? u"The shape is a text box." : u"The shape is not a text box.");
        }
    }
}
```

Egy újonnan hozzáadott automatikus alakzat nem tekinthető szövegdoboznak, amíg nem tartalmaz nem üres szöveget. Ezt a szöveget megadhatja az [IAutoShape::AddTextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/addtextframe/) vagy az [ITextFrame::set_Text](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/set_text/) segítségével. Üres karakterlánc hozzáadása vagy hozzárendelése azt eredményezi, hogy az [IAutoShape::get_IsTextBox](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/get_istextbox/) `false` értéket ad vissza:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
shape1->AddTextFrame(u"Shape 1");
Console::WriteLine(shape1->get_IsTextBox());

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 70, 100, 40);
shape2->get_TextFrame()->set_Text(u"Shape 2");
Console::WriteLine(shape2->get_IsTextBox());

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 130, 100, 40);
shape3->AddTextFrame(u"");
Console::WriteLine(shape3->get_IsTextBox());

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 190, 100, 40);
shape4->get_TextFrame()->set_Text(u"");
Console::WriteLine(shape4->get_IsTextBox());
```

Az első két ellenőrzés `true`‑t ad vissza; az utolsó két `false`‑t.

## **Szövegkeretet birtokló alakzat megtalálása**

Általános szövegfeldolgozó kód megkaphat egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/)-et anélkül, hogy tudná, melyik prezentációs objektum tartalmazza. Használja az [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) metódust a tulajdonos [IShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishape/)-hez való visszavezetéshez.

Ha a szövegkeret egy automatikus alakzat vagy más szöveget tartalmazó alakzat tulajdona, az [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentshape/) visszaadja a tulajdonost, míg az [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/get_parentcell/) `nullptr`‑t ad. Mindkét metódus csak olvasási célú navigációt biztosít. A visszaadott értéket ellenőrizze `nullptr`‑ra, mielőtt felhasználná. Az alakzat‑ és táblacella‑tulajdonosok egyidejű azonosításához, beleértve a SmartArt‑csomópontokhoz kapcsolódó alakzatokat, lásd a [Keresés és csere szöveg](/slides/hu/cpp/search-and-replace-text/) oldalt.

## **Oszlopok hozzáadása egy szövegdobozhoz**

Az [ITextFrameFormat::set_ColumnCount](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_columncount/) metódus a szövegkeretet oszlopokra osztja, míg az [ITextFrameFormat::set_ColumnSpacing](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_columnspacing/) beállítja az oszlopok közti távolságot pontokban. Mindkét metódus az [ITextFrameFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/) része, és egy meglévő szövegdoboz szövegkeretén keresztül hívható. A szöveg az oszlopok között ugyanazon alakzaton belül újraoszlik; nem folytatódik egy másik alakzatba.

A következő példa egy háromoszlopos szövegdobozt hoz létre, amelynek oszlopai között 10 pont távolság van, elmenti a prezentációt, és visszaolvassa a beállításokat a kimeneti fájlból:

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 300, 200);
textBox->AddTextFrame(u"This text is distributed automatically across all columns in the text box.");

auto textFrameFormat = textBox->get_TextFrame()->get_TextFrameFormat();
textFrameFormat->set_ColumnCount(3);
textFrameFormat->set_ColumnSpacing(10);

presentation->Save(u"TextBoxColumns.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"TextBoxColumns.pptx");
auto savedTextBox = ExplicitCast<IAutoShape>(savedPresentation->get_Slide(0)->get_Shape(0));
auto savedFormat = savedTextBox->get_TextFrame()->get_TextFrameFormat();
Console::WriteLine(u"Columns: {0}; spacing: {1} points", savedFormat->get_ColumnCount(), savedFormat->get_ColumnSpacing());
```

## **Szöveg kinyerése egyes oszlopokból**

Használja az [ITextFrame::SplitTextByColumns](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/splittextbycolumns/) metódust, hogy visszanyerje az egyes vizuális oszlopokhoz rendelt szöveget egy meglévő szövegkeretben. A metódus minden oszlophoz egy karakterláncot ad vissza, oszlop‑alapú olvasási sorrendben. Egy egyoszlopos szövegkeret egy elemmel rendelkező tömböt eredményez, és egy üres oszlop egy üres karakterlánccal van reprezentálva. A karakterláncok csak egyszerű szöveget tartalmaznak; a részlet‑szintű formázás nem marad meg.

Ez akkor hasznos, ha:

- Szöveget kell kinyerni úgy, hogy megmaradjon az oszlop‑alapú olvasási sorrend.
- Többoszlopos diák tartalmát indexelni vagy összehasonlítani kívánja.
- Minden oszlopot külön fájlba, adatbázismezőbe vagy más célba szeretné exportálni.
- Szeretné ellenőrizni, hogyan oszlik újra a szöveg az oszlopszám [ITextFrameFormat::set_ColumnCount] vagy a távolság [ITextFrameFormat::set_ColumnSpacing] beállítása, illetve a betűtípus vagy a szövegkeret méretének módosítása után.

A metódus a jelenlegi [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/)‑ben elosztott szöveget jelenti; nem folyik automatikusan szöveg más alakzatok vagy szövegdobozok közé. Az oszlopeloszlás függhet a rendelkezésre álló betűtípusoktól és egyéb szöveg‑elrendezési beállításoktól, ezért győződjön meg róla, hogy a szükséges betűtípusok elérhetők, ha konzisztens eredményre van szükség.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <system/array.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/io/file.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto presentation = MakeObject<Presentation>(u"MultiColumnText.pptx");

SharedPtr<IAutoShape> textBox = nullptr;
for (const auto& shape : IterateOver(presentation->get_Slide(0)->get_Shapes()))
{
    auto autoShape = AsCast<IAutoShape>(shape);
    if (autoShape != nullptr && autoShape->get_TextFrame() != nullptr)
    {
        auto columnCount = autoShape->get_TextFrame()->get_TextFrameFormat()->get_ColumnCount();
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox == nullptr)
{
    Console::WriteLine(u"No multi-column text frame was found.");
}
else
{
    auto textFrame = textBox->get_TextFrame();
    auto configuredColumnCount = textFrame->get_TextFrameFormat()->get_ColumnCount();
    auto columnTexts = textFrame->SplitTextByColumns();

    Console::WriteLine(u"Configured columns: {0}", configuredColumnCount);

    for (auto columnIndex = 0; columnIndex < columnTexts->get_Length(); columnIndex++)
    {
        auto columnNumber = columnIndex + 1;
        auto columnText = columnTexts->idx_get(columnIndex);
        Console::WriteLine(u"Column {0}: {1}", columnNumber, columnText);
        auto fileName = String::Format(u"Column-{0}.txt", columnNumber);
        File::WriteAllText(fileName, columnText);
    }
}
```

## **Szöveg frissítése**

A szöveg frissítéséhez egy prezentáción belül iteráljon a diákon és alakzatokon, válassza ki az automatikus alakzatokat, majd szerkessze a szövegrészeiket. A részlet‑szintű munkavégzés lehetővé teszi a szöveg és a karakterformázás együttes módosítását.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
#include <system/shared_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"Text.pptx");

for (const auto& slide : IterateOver(presentation->get_Slides()))
{
    for (const auto& shape : IterateOver(slide->get_Shapes()))
    {
        auto autoShape = AsCast<IAutoShape>(shape);
        if (autoShape == nullptr || autoShape->get_TextFrame() == nullptr)
        {
            continue;
        }

        for (const auto& paragraph : IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
        {
            for (const auto& portion : IterateOver(paragraph->get_Portions()))
            {
                auto text = portion->get_Text();
                if (!String::IsNullOrEmpty(text) && text.Contains(u"years"))
                {
                    portion->set_Text(text.Replace(u"years", u"months"));
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

presentation->Save(u"TextChanged.pptx", SaveFormat::Pptx);
```

Ez a bejárás csak az automatikus alakzatok szövegét módosítja. A táblákban, diagramokban, SmartArt‑ban vagy csoportos alakzatokban tárolt szöveg módosításához azok gyűjteményeit kell bejárni.

## **Szövegdoboz hozzáadása hiperhivatkozással**

Hiperhivatkozást hozzárendelhet egy adott szövegrészlethez, így csak ez a szöveg lesz kattintható link. Használja az [IHyperlinkManager::SetExternalHyperlinkClick](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/) metódust a részlet külső URL‑hez való kapcsolásához.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/shared_ptr.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto textBox = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 200, 50);
textBox->AddTextFrame(u"Aspose.Slides");

auto textPortion = textBox->get_TextFrame()->get_Paragraph(0)->get_Portion(0);
textPortion->get_PortionFormat()->get_HyperlinkManager()->SetExternalHyperlinkClick(u"https://www.aspose.com/");

presentation->Save(u"Hyperlink.pptx", SaveFormat::Pptx);
```

## **GYIK**

**Mi a különbség egy szövegdoboz és egy szöveggelőtag között egy mester‑ vagy elrendezés‑dián?**

A [placeholder](/slides/hu/cpp/manage-placeholder/) örökölheti a pozícióját és formázását egy [master slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslide/) vagy [layout slide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/)‑ról. Egy szabályos szövegdoboz független alakzat a dián, ahol létrehozták, és nem kap placeholder‑szerű viselkedést, ha az elrendezés megváltozik.

**Hogyan cserélhetem le a szöveget anélkül, hogy a diagramok, táblák vagy SmartArt szövegét megváltoztatnám?**

Korlátozza a bejárást csak azokra az alakzatokra, amelyek implementálják az [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/)‑t, ahogyan az a Szöveg frissítése példában látható. A diagramok, táblák és SmartArt saját objektummodellekben tárolják a szöveget, ezért az a ciklus nem módosítja őket.