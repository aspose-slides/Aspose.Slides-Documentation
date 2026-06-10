---
title: Alakzatok átméretezése a bemutató diákon
type: docs
weight: 100
url: /hu/cpp/re-sizing-shapes-on-slide/
keywords:
- alakzat átméretezése
- alakzat méretének módosítása
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Könnyedén átméretezheti az alakzatokat PowerPoint és OpenDocument diákon az Aspose.Slides for C++ segítségével—automatizálja a diaelrendezés módosítását és növelje a hatékonyságot."
---
## **Overview**

Az Aspose.Slides for C++ ügyfelei gyakran felteszik a kérdést, hogyan lehet átméretezni az alakzatokat úgy, hogy a dia méretének változása esetén az adatok ne vágódjanak le. Ez a rövid technikai cikk bemutatja, hogyan hajtható végre ez.

## **Resize Shapes**

Az alakzatok elcsúszásának megakadályozása érdekében a dia méretének változása során frissíteni kell minden alakzat pozícióját és méretét, hogy azok illeszkedjenek az új diaelrendezéshez.

```cpp
// Töltsük be a bemutatófájlt.
auto presentation = MakeObject<Presentation>(u"sample.ppt");

// Szerezzük meg az eredeti dia méretét.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Módosítsuk a dia méretét a meglévő alakzatok méretezése nélkül.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);

// Szerezzük meg az új dia méretét.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

// Resize and reposition shapes on every slide.
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Méretezzük az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Méretezzük az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}} 
Ha egy dián táblázat szerepel, a fenti kód nem fog helyesen működni. Ebben az esetben a táblázat minden celláját át kell méretezni.
{{% /alert %}} 

Használja a következő kódot saját környezetében a táblázatot tartalmazó diák átméretezéséhez. A táblázatoknál a szélesség vagy magasság beállítása külön eset: egyedi sormagasságokat és oszlopszélességeket kell módosítani a táblázat teljes méretének megváltoztatásához.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

// Szerezze meg az eredeti dia méretét.
float currentHeight = presentation->get_SlideSize()->get_Size().get_Height();
float currentWidth = presentation->get_SlideSize()->get_Size().get_Width();

// Módosítsa a dia méretét a meglévő alakzatok méretezése nélkül.
presentation->get_SlideSize()->SetSize(SlideSizeType::A4Paper, SlideSizeScaleType::DoNotScale);
//presentation.SlideSize.Orientation = SlideOrienation.Portrait;

// Szerezze meg az új dia méretét.
float newHeight = presentation->get_SlideSize()->get_Size().get_Height();
float newWidth = presentation->get_SlideSize()->get_Size().get_Width();

float heightRatio = newHeight / currentHeight;
float widthRatio = newWidth / currentWidth;

for (auto&& master : presentation->get_Masters())
{
    for (auto&& shape : master->get_Shapes())
    {
        // Méretezze az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Méretezze az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);
    }

    for (auto&& layoutSlide : master->get_LayoutSlides())
    {
        for (auto&& shape : layoutSlide->get_Shapes())
        {
            // Méretezze az alakzat méretét.
            shape->set_Height(shape->get_Height() * heightRatio);
            shape->set_Width(shape->get_Width() * widthRatio);

            // Méretezze az alakzat pozícióját.
            shape->set_Y(shape->get_Y() * heightRatio);
            shape->set_X(shape->get_X() * widthRatio);
        }
    }
}

for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        // Méretezze az alakzat méretét.
        shape->set_Height(shape->get_Height() * heightRatio);
        shape->set_Width(shape->get_Width() * widthRatio);

        // Méretezze az alakzat pozícióját.
        shape->set_Y(shape->get_Y() * heightRatio);
        shape->set_X(shape->get_X() * widthRatio);

        if (ObjectExt::Is<ITable>(shape))
        {
            SharedPtr<ITable> table = ExplicitCast<ITable>(shape);
            for (auto&& row : table->get_Rows())
            {
                row->set_MinimalHeight(row->get_MinimalHeight() * heightRatio);
            }
            for (auto&& column : table->get_Columns())
            {
                column->set_Width(column->get_Width() * widthRatio);
            }
        }
    }
}

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Why are shapes distorted or cut off after resizing a slide?**

A dia átméretezésekor az alakzatok megtartják eredeti pozíciójukat és méretüket, hacsak a méretezést kifejezetten nem módosítják. Ennek következtében a tartalom levágódhat vagy az alakzatok elcsúszhatnak.

**Does the provided code work for all shape types?**

Az alap példa a legtöbb alakzattípusra (szövegdobozok, képek, diagramok stb.) működik. Azonban táblázatok esetén a sorokat és oszlopokat külön kell kezelni, mivel egy táblázat magasságát és szélességét az egyes cellák méretei határozzák meg.

**How do I resize tables when resizing a slide?**

A táblázat összes sorát és oszlopát végig kell járni, majd a magasságukat és szélességüket arányosan átméretezni, ahogyan a második kódrészletben látható.

**Will this resizing work for master slides and layout slides?**

Igen, de a [Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) és a [Layout slides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_layoutslides/) elemein is végig kell menni, és ugyanazt a méretezési logikát alkalmazni kell az alakzataikra, hogy a bemutató egységes maradjon.

**Can I change the orientation of a slide (portrait/landscape) along with the resizing?**

Igen. A [presentation->get_SlideSize()->set_Orientation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islidesize/set_orientation/) metódussal megváltoztatható a tájolás. Ügyeljen arra, hogy a méretezési logikát ennek megfelelően állítsa be a kialakítás megőrzése érdekében.

**Is there a limit to the slide size I can set?**

Az Aspose.Slides támogatja az egyedi méreteket, de a nagyon nagy méretek befolyásolhatják a teljesítményt vagy a kompatibilitást néhány PowerPoint verzióval.

**How can I prevent fixed aspect ratio shapes from becoming distorted?**

A méretezés előtt ellenőrizhető az alakzat `get_AspectRatioLocked` metódusa. Ha zárolt, a szélességet vagy magasságot arányosan kell módosítani, ahelyett, hogy külön-külön skálázná őket.