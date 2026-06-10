---
title: Bekezdés határainak lekérése prezentációkból C++-ban
linktitle: Bekezdés
type: docs
weight: 60
url: /hu/cpp/paragraph/
keywords:
- bekezdés határok
- szövegrész határok
- bekezdés koordináta
- rész koordináta
- bekezdés méret
- szövegrész méret
- szövegkeret
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan lehet lekérni a bekezdés és a szövegrész határait az Aspose.Slides for C++-ban, hogy optimalizálja a szöveg elhelyezését a PowerPoint prezentációkban."
---
## **Áttekintés**

Ez a cikk elmagyarázza, hogyan lehet lekérni a bekezdések és szövegrészek határait, méretét és koordinátáit az Aspose.Slides-ban. Bemutatja, hogyan lehet a `GetRect()` segítségével lekérni egy bekezdés téglalapját egy `TextFrame`-ben, hogyan lehet a bekezdés és a rész koordinátáit egy táblázatcellában lévő szövegdobozban, és kiemeli a fontos részleteket, például a mértékegységeket, a szöveg tördelésének hatását a határokra, a pixel átváltást és a hatékony bekezdésformázási értékeket.

## **Bekezdés- és Részkoordináták lekérése egy TextFrame-ben**

Az Aspose.Slides for C++ használatával a fejlesztők most már lekérhetik a bekezdés téglalap koordinátáit a TextFrame bekezdésgyűjteményén belül. Emellett lehetővé teszi egy bekezdés részegységének koordinátáinak lekérését a részgyűjteményen belül. Ebben a témában egy példán keresztül bemutatjuk, hogyan lehet lekérni a bekezdés téglalap koordinátáit, valamint a rész pozícióját a bekezdésen belül.

## **Bekezdés téglalap koordinátáinak lekérése**

Az új **GetRect()** metódus hozzá lett adva. Lehetővé teszi a bekezdés határ téglalapjának lekérését.

``` cpp
// Hozzon létre egy Presentation objektumot, amely egy prezentációs fájlt képvisel
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto shape = System::ExplicitCast<IAutoShape>(presentation->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));
auto textFrame = shape->get_TextFrame();
auto rect = textFrame->get_Paragraphs()->idx_get(0)->GetRect();
```

## **Bekezdés és Rész méretének lekérése egy táblázatcella TextFrame-ben**

A [Portion](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.portion) vagy [Paragraph](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.paragraph) méretének és koordinátáinak lekéréséhez egy táblázatcella szövegdobozban, használhatja az [IPortion::GetRect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_portion#a9e2fd8b58529d493b40835b8463838a9) és az [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/class/aspose.slides.i_paragraph#a56f6e0026bbb81aa948bb0b000b8cf08t) metódusokat.

Ez a mintakód bemutatja a leírt műveletet:

``` cpp
auto pres = System::MakeObject<Presentation>(u"source.pptx");
auto tbl = System::AsCast<Table>(pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0));

auto cell = tbl->get_Rows()->idx_get(1)->idx_get(1);

double x = tbl->get_X() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetX();
double y = tbl->get_Y() + tbl->get_Rows()->idx_get(1)->idx_get(1)->get_OffsetY();

for (const auto& para : cell->get_TextFrame()->get_Paragraphs())
{
    if (para->get_Text() == u"")
    {
        continue;
    }

    auto rect = para->GetRect();
    auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

    shape->get_FillFormat()->set_FillType(FillType::NoFill);
    shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Yellow());
    shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);

    for (const auto& portion : para->get_Portions())
    {
        if (portion->get_Text().Contains(u"0"))
        {
            rect = portion->GetRect();
            shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, rect.get_X() + x, rect.get_Y() + y, rect.get_Width(), rect.get_Height());

            shape->get_FillFormat()->set_FillType(FillType::NoFill);
        }
    }
}
```

## **GYIK**

**Milyen egységben adják vissza a bekezdés és szövegrészek koordinátáit?**

Pontban, ahol 1 hüvelyk = 72 pont. Ez minden koordinátára és méretre vonatkozik a dián.

**A szövegtördelés hatással van a bekezdés határaira?**

Igen. Ha a [wrapping](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframeformat/set_wraptext/) engedélyezve van a [TextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/textframe/)-ben, a szöveg megtörik, hogy illeszkedjen a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontokat pixelekké a következő képlettel lehet konvertálni: pixels = points × (DPI / 72). Az eredmény a renderelés/exportálás során választott DPI-től függ.

**Hogyan kaphatom meg a „hatékony” bekezdésformázási paramétereket, figyelembe véve a stílus öröklődést?**

Használja a [effective paragraph formatting data structure](/slides/hu/cpp/shape-effective-properties/); ez visszaadja a behúzások, távolságok, tördelés, RTL és egyéb beállítások végső egyesített értékeit.