---
title: Diaelrendezések alkalmazása vagy módosítása C++-ban
linktitle: Diaelrendezés
type: docs
weight: 60
url: /hu/cpp/slide-layout/
keywords:
- diaelrendezés
- tartalomelrendezés
- helyőrző
- bemutatótervezés
- diatervezés
- használaton kívüli elrendezés
- lábléc láthatóság
- címdia
- cím és tartalom
- szakaszcím
- két tartalom
- összehasonlítás
- csak cím
- üres elrendezés
- tartalom felirattal
- kép felirattal
- cím és függőleges szöveg
- függőleges cím és szöveg
- PowerPoint
- OpenDocument
- bemutató
- C++
- Aspose.Slides
description: "Kezeld és testre szabj diaelrendezéseket az Aspose.Slides for C++-ban. Fedezd fel az elrendezéstípusokat, a helyőrzők vezérlését és a lábléc láthatóságát C++ kódpéldákon keresztül."
---
## **Bevezetés**

A diaelrendezés meghatározza a helyőrződobozok elrendezését és a dián lévő tartalom formázását. Szabályozza, hogy mely helyőrzők állnak rendelkezésre, és hol jelennek meg. A diaelrendezések segítenek a bemutatók gyors és következetes megtervezésében – legyen szó egyszerű vagy összetettebb tartalomról. A PowerPoint leggyakoribb diaelrendezései a következők:

**Címdia elrendezés** – Két szöveges helyőrzőt tartalmaz: egyet a címhez és egyet az alcímhez.

**Cím és tartalom elrendezés** – Kisebb címhelyőrzőt tartalmaz a tetején, és alatta egy nagyobbat a fő tartalom számára (például szöveg, pontlista, diagramok, képek és egyéb elemek).

**Üres elrendezés** – Nem tartalmaz helyőrzőket, teljes irányítást biztosítva a dia teljesen újratervezéséhez.

A diaelrendezések a dia mester részei, amely a legfelső szintű dia, és meghatározza a prezentáció elrendezési stílusait. A dia mester segítségével elérheted és módosíthatod az elrendezési diát – típusa, neve vagy egyedi azonosítója alapján. Alternatív megoldásként közvetlenül a prezentációban szerkeszthetsz egy adott elrendezési diát.

A diaelrendezésekkel való munka Aspose.Slides for Android esetén a következőket használhatod:

- Olyan metódusok, mint a [get_LayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_layoutslides/) és a [get_Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályban
- Olyan típusok, mint a [ILayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/), a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterlayoutslidecollection/), a [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/), és a [ILayoutSlideHeaderFooterManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslideheaderfootermanager/)

{{% alert title="Info" color="info" %}}
További információért a mesterdiák használatáról nézd meg a [Dia mester](/slides/hu/cpp/slide-master/) cikket.
{{% /alert %}}

## **Diaelrendezések hozzáadása a bemutatókhoz**

A diák megjelenésének és felépítésének testreszabásához szükség lehet új elrendezési diák hozzáadására a bemutatóhoz. Az Aspose.Slides for Android lehetővé teszi, hogy ellenőrizd, létezik-e már egy adott elrendezés, szükség esetén újat adj hozzá, és azt használva diát szúrj be az adott elrendezés alapján.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Érd el a [IMasterLayoutSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterlayoutslidecollection/).
1. Ellenőrizd, hogy a kívánt elrendezési dia már létezik-e a gyűjteményben. Ha nem, add hozzá a szükséges elrendezési diát.
1. Adj hozzá egy üres diát az új elrendezési dia alapján.
1. Mentsd el a bemutatót.

A következő C++ kód bemutatja, hogyan lehet diaelrendezést hozzáadni egy PowerPoint bemutatóhoz:

```cpp
// Példányosítja a Presentation osztályt, amely egy PowerPoint fájlt képvisel.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// Go through the layout slide types to select a layout slide.
auto layoutSlides = presentation->get_Master(0)->get_LayoutSlides();
SharedPtr<ILayoutSlide> layoutSlide;
if (layoutSlides->GetByType(SlideLayoutType::TitleAndObject) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::TitleAndObject);
}
else if (layoutSlides->GetByType(SlideLayoutType::Title) != nullptr)
{
    layoutSlide = layoutSlides->GetByType(SlideLayoutType::Title);
}

if (layoutSlide == nullptr)
{
    // Olyan helyzet, amikor a bemutató nem tartalmazza az összes elrendezéstípust.
    // A bemutatófájl csak Üres és Egyedi elrendezéstípusokat tartalmaz.
    // Azonban az egyedi típusú elrendezési diák felismerhető nevekkel is rendelkezhetnek,
    // például "Title", "Title and Content", stb., amelyeket felhasználhatunk elrendezési dia kiválasztásához.
    // Szintén támaszkodhatsz egy helyőrző alakzat típuskészletre.
    // Például egy Címdia csak a Cím helyőrzőtípust tartalmazza, és így tovább.
    for (int i = 0; i < layoutSlides->get_Count(); i++)
    {
        auto titleAndObjectLayoutSlide = layoutSlides->idx_get(i);

        if (titleAndObjectLayoutSlide->get_Name().Equals(u"Title and Object"))
        {
            layoutSlide = titleAndObjectLayoutSlide;
            break;
        }
    }

    if (layoutSlide == nullptr)
    {
        for (int i = 0; i < layoutSlides->get_Count(); i++)
        {
            auto titleLayoutSlide = layoutSlides->idx_get(i);

            if (titleLayoutSlide->get_Name() == u"Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
        }

        if (layoutSlide == nullptr)
        {
            layoutSlide = layoutSlides->GetByType(SlideLayoutType::Blank);
            if (layoutSlide == nullptr)
            {
                layoutSlide = layoutSlides->Add(SlideLayoutType::TitleAndObject, u"Title and Object");
            }
        }
    }
}

// Add an empty slide using the added layout slide.
presentation->get_Slides()->InsertEmptySlide(0, layoutSlide);

// Save the presentation to disk.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Használaton kívüli elrendezési diák eltávolítása**

Az Aspose.Slides a [Compress](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/) osztály [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódusát biztosítja, hogy eltávolíthasd a nem kívánt és használaton kívüli elrendezési diát.

A következő C++ kód megmutatja, hogyan lehet elrendezési diát eltávolítani egy PowerPoint bemutatóból:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.pptx");

Compress::RemoveUnusedLayoutSlides(presentation);

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Helyőrzők hozzáadása a diaelrendezésekhez**

Az Aspose.Slides biztosítja az [ILayoutSlide.get_PlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_placeholdermanager/) metódust, amely lehetővé teszi új helyőrzők hozzáadását egy elrendezési diához.

Ez a menedzser a következő helyőrző típusokhoz tartalmaz metódusokat:

| PowerPoint helyőrző              | [ILayoutPlaceholderManager](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutplaceholdermanager/) Metódus |
| --------------------------------- | ------------------------------------------------------------ |
| ![Tartalom](content.png)          | AddContentPlaceholder(float x, float y, float width, float height) |
| ![Tartalom (Függőleges)](contentV.png) | AddVerticalContentPlaceholder(float x, float y, float width, float height) |
| ![Szöveg](text.png)               | AddTextPlaceholder(float x, float y, float width, float height) |
| ![Szöveg (Függőleges)](textV.png) | AddVerticalTextPlaceholder(float x, float y, float width, float height) |
| ![Kép](picture.png)               | AddPicturePlaceholder(float x, float y, float width, float height) |
| ![Diagram](chart.png)             | AddChartPlaceholder(float x, float y, float width, float height) |
| ![Táblázat](table.png)            | AddTablePlaceholder(float x, float y, float width, float height) |
| ![SmartArt](smartart.png)         | AddSmartArtPlaceholder(float x, float y, float width, float height) |
| ![Média](media.png)               | AddMediaPlaceholder(float x, float y, float width, float height) |
| ![Online kép](onlineimage.png)    | AddOnlineImagePlaceholder(float x, float y, float width, float height) |

A következő C++ kód bemutatja, hogyan lehet új helyőrző alakzatokat hozzáadni az Üres elrendezés diához:

```cpp
auto presentation = MakeObject<Presentation>();

// Szerezze be az Üres elrendezési diát.
auto layout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

// Szerezze be a helyőrzőkezelőt az elrendezési diáról.
auto placeholderManager = layout->get_PlaceholderManager();

// Különböző helyőrzők hozzáadása az Üres elrendezési diához.
placeholderManager->AddContentPlaceholder(20, 20, 310, 270);
placeholderManager->AddVerticalTextPlaceholder(350, 20, 350, 270);
placeholderManager->AddChartPlaceholder(20, 310, 310, 180);
placeholderManager->AddTablePlaceholder(350, 310, 350, 180);

// Add a new slide with the Blank layout.
auto newSlide = presentation->get_Slides()->AddEmptySlide(layout);

presentation->Save(u"Placeholders.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az eredmény:

![A helyőrzők az elrendezési dián](add_placeholders.png)

## **Lábléc láthatóság beállítása egy elrendezési dián**

A PowerPoint bemutatókban a láblécelemek, például a dátum, a dia száma és az egyéni szöveg megjeleníthetők vagy elrejthetők a diaelrendezéstől függően. Az Aspose.Slides for Android lehetővé teszi ezen lábléc helyőrzők láthatóságának szabályozását. Ez akkor hasznos, amikor bizonyos elrendezéseknél szeretnél láblécinformációt megjeleníteni, míg mások tiszták és minimalista megjelenést kapnak.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezz egy elrendezési dia referenciát az indexe alapján.
1. Állítsd a dia lábléc helyőrzőt láthatóvá.
1. Állítsd a dia szám helyőrzőt láthatóvá.
1. Állítsd a dátum-idő helyőrzőt láthatóvá.
1. Mentsd el a bemutatót.

A következő C++ kód megmutatja, hogyan kell beállítani egy dia láblécének láthatóságát és a kapcsolódó feladatokat végrehajtani:

```cpp
auto presentation = MakeObject<Presentation>(u"Presentation.ppt");
auto headerFooterManager = presentation->get_LayoutSlides()->idx_get(0)->get_HeaderFooterManager();

if (!headerFooterManager->get_IsFooterVisible())
{
    headerFooterManager->SetFooterVisibility(true);
}

if (!headerFooterManager->get_IsSlideNumberVisible())
{
    headerFooterManager->SetSlideNumberVisibility(true);
}

if (!headerFooterManager->get_IsDateTimeVisible())
{
    headerFooterManager->SetDateTimeVisibility(true);
}

headerFooterManager->SetFooterText(u"Footer text");
headerFooterManager->SetDateTimeText(u"Date and time text");

presentation->Save(u"Presentation.ppt", SaveFormat::Pptx);
presentation->Dispose();
```

## **Gyermek lábléc láthatóság beállítása egy dián**

A PowerPoint bemutatókban a láblécelemek, például a dátum, a dia száma és az egyéni szöveg a mesterdia szintjén szabályozhatók, hogy konzisztenciát biztosítsanak az összes elrendezési dián. Az Aspose.Slides for Android lehetővé teszi ezen lábléc helyőrzők láthatóságának és tartalmának beállítását a mesterdián, és ezeknek a beállításoknak a terjesztését az összes gyermek elrendezési diára. Ez a megközelítés egységes láblécinformációt biztosít a teljes bemutatóban.

1. Hozz létre egy példányt a [Presentation](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/) osztályból.
1. Szerezz egy referencia a mesterdiára az indexe alapján.
1. Állítsd a mester és az összes gyermek lábléc helyőrzőjét láthatóvá.
1. Állítsd a mester és az összes gyermek dia szám helyőrzőjét láthatóvá.
1. Állítsd a mester és az összes gyermek dátum-idő helyőrzőjét láthatóvá.
1. Mentsd el a bemutatót.

A következő C++ kód bemutatja ezt a műveletet:

```cpp
auto presentation = MakeObject<Presentation>();

auto headerFooterManager = presentation->get_Master(0)->get_HeaderFooterManager();

headerFooterManager->SetFooterAndChildFootersVisibility(true);
headerFooterManager->SetSlideNumberAndChildSlideNumbersVisibility(true);
headerFooterManager->SetDateTimeAndChildDateTimesVisibility(true);

headerFooterManager->SetFooterAndChildFootersText(u"Footer text");
headerFooterManager->SetDateTimeAndChildDateTimesText(u"Date and time text");

presentation->Save(u"Output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Mi a különbség a mesterdia és az elrendezési dia között?**

A mesterdia határozza meg az általános témát és az alapértelmezett formázást, míg az elrendezési diák konkrét helyőrző elrendezéseket definiálnak különböző tartalomtípusok számára.

**Másolhatok elrendezési diát az egyik bemutatóból a másikba?**

Igen, egy elrendezési diát klónozhatsz egy bemutató elrendezési dia gyűjteményéből, amely a [get_LayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_layoutslides/) metódussal érhető el, és egy másik bemutatóba az `AddClone` metódus segítségével illesztheted be.

**Mi történik, ha törlök egy elrendezési diát, amelyet még egy dia használ?**

Ha megpróbálsz törölni egy elrendezési diát, amelyet a bemutató legalább egy diája még hivatkozik, az Aspose.Slides [PptxEditException](https://reference.aspose.com/slides/hu/cpp/aspose.slides/pptxeditexception/) kivételt dob. Ennek elkerülése érdekében használd a [RemoveUnusedLayoutSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedlayoutslides/) metódust, amely biztonságosan csak a nem használt elrendezési diákat távolítja el.