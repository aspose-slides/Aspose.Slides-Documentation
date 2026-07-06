---
title: Bekezdés határok lekérése bemutatókból C++-ban
linktitle: Bekezdés határok
type: docs
weight: 43
url: /hu/cpp/paragraph-bounds/
keywords:
- bekezdés határok
- bekezdés koordináta
- bekezdés méret
- szövegkeret
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Ismerje meg, hogyan kérheti le a bekezdés határait az Aspose.Slides C++-hoz, hogy optimalizálja a szöveg elhelyezését PowerPoint bemutatókban."
---
## **Áttekintés**

Ez a cikk bemutatja, hogyan lehet lekérni a bekezdések határait, méretét és koordinátáit az Aspose.Slides-ban. Megmutatja, hogyan lehet egy bekezdés téglalapot lekérni egy [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) segítségével a [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getrect/) használatával, hogyan lehet a bekezdés koordinátáit egy táblázatcellában lévő szövegkeretben lekérni, és kiemeli a fontos részleteket, például a mérési egységeket, a szöveg tördelés hatását a határokra, a pixel átalakítást, valamint a hatékony bekezdésformázási értékeket.

## **Bekezdés téglalap koordinátáinak lekérése**

Használja a [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getrect/) függvényt a bekezdés körülhatároló téglalapjának lekéréséhez.

```cpp
auto presentation = System::MakeObject<Presentation>(u"Shapes.pptx");
auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto paragraph = shape->get_TextFrame()->get_Paragraph(0);
auto rectangle = paragraph->GetRect();

presentation->Dispose();
```

## **Bekezdés méretének lekérése egy táblázatcellában lévő TextFrame-ben**

Az [IParagraph](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/) méretének és koordinátáinak lekéréséhez egy táblázatcellában lévő szövegkeretben, használja a [IParagraph::GetRect](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iparagraph/getrect/) függvényt. A visszaadott téglalap a táblázatcellás szövegkerethez relatív, így a diára vonatkozó koordinátákhoz hozzá kell adni a táblázat pozícióját és a cella eltolását.

Az alábbi példa lekéri a bekezdés határait egy táblázatcellában, és téglalapokat rajzol a diára a határok megjelenítéséhez:

```cpp
auto presentation = System::MakeObject<Presentation>(u"source.pptx");
auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));
auto cell = table->get_Row(1)->idx_get(1);

auto cellX = table->get_X() + cell->get_OffsetX();
auto cellY = table->get_Y() + cell->get_OffsetY();
auto paragraphs = cell->get_TextFrame()->get_Paragraphs();

for (const auto& paragraph : paragraphs)
{
    if (paragraph->get_Text().IsEmpty())
    {
        continue;
    }

    auto paragraphRectangle = paragraph->GetRect();
    auto paragraphRectangleX = paragraphRectangle.get_X() + cellX;
    auto paragraphRectangleY = paragraphRectangle.get_Y() + cellY;

    auto paragraphBoundsShape = slide->get_Shapes()->AddAutoShape(
        ShapeType::Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.get_Width(),
        paragraphRectangle.get_Height());

    paragraphBoundsShape->get_FillFormat()->set_FillType(FillType::NoFill);
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(System::Drawing::Color::get_Yellow());
    paragraphBoundsShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Milyen egységben mérik a bekezdés koordinátáit?**

A koordinátákat pontban (points) mérik, ahol 1 hüvelyk 72 pontnak felel meg. Ez minden koordinátára és méretre a dián vonatkozik.

**A szöveg tördelése befolyásolja a bekezdés határait?**

Igen. Ha a [ITextFrameFormat::set_WrapText](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformat/set_wraptext/) engedélyezve van az [ITextFrame](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframe/) számára, a szöveg megtörik a terület szélességéhez, ami megváltoztatja a bekezdés tényleges határait.

**A bekezdés koordinátái megbízhatóan leképezhetők pixelekre az exportált képen?**

Igen. A pontokat pixelekre a következő képlettel lehet átalakítani: pixel = pont × (DPI / 72). Az eredmény a rendereléshez vagy exportáláshoz választott DPI-től függ.

**Hogyan kapom meg a "hatékony" bekezdésformázási paramétereket a stílusöröklődés figyelembevételével?**

Használja a [effective paragraph formatting data structure](/slides/hu/cpp/shape-effective-properties/) struktúrát; ez visszaadja a behúzások, távolságok, tördelés, RTL és egyéb beállítások végső, összevont értékeit.