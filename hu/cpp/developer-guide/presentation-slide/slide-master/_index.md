---
title: "Kezelje a bemutató diamestereket C++-ban"
linktitle: "Dia Master"
type: docs
weight: 80
url: /hu/cpp/slide-master/
keywords:
- "dia mester"
- "mester dia"
- "PPT mester dia"
- "több mester dia"
- "mester diák összehasonlítása"
- "háttér"
- "helyfoglaló"
- "mester dia klónozása"
- "mester dia másolása"
- "mester dia duplikálása"
- "nem használt mester dia"
- PowerPoint
- OpenDocument
- "bemutató"
- C++
- Aspose.Slides
description: "Kezelje a diamestereket az Aspose.Slides C++-ban: hozzáférés, szerkesztés, klónozás, összehasonlítás és a mester diák eltávolítása PowerPoint és OpenDocument bemutatókban."
---
## **Áttekintés**

A **slide master** közös tervezési beállításokat határoz meg egy diacsoport számára. Tartalmazhat közös alakzatokat, logókat, háttereket, szövegstílusokat, téma beállításokat és lábléc beállításokat. A PowerPointban a slide master szerkesztése a szokásos módja annak, hogy a bemutató konzisztens maradjon anélkül, hogy minden dián ismételné a formázást.

Az Aspose.Slides for C++ támogatja ugyanazt a modellt. Egy bemutató egy vagy több mester diát tartalmazhat, és minden mester dia több elrendezés diát (layout slide) tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy mester diára. Ehelyett egy normál dia egy elrendezés diát használ, és ez az elrendezés dia egy mester diához tartozik.

A hierarchia a következő:

1. **Slide master** - meghatározza a közös tervezést és témát.  
1. **Layout slide** - meghatároz egy konkrét elrendezést helyfoglalókkal és elrendezés-szintű formázással.  
1. **Normal slide** - tartalmazza a tényleges bemutató tartalmat és egy elrendezés diát használ.

![A mester diákok, elrendezés diák és normál diákok hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ban egy slide master-t a [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) interfész képviseli. A bemutató összes mester diája elérhető a [Presentation::get_Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) gyűjteményen keresztül, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) interfészt valósítja meg.

{{% alert color="info" title="Inheritance" %}}
Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyeri el a hatást. Például, ha egy mester dia és egy elrendezés dia is meghatároz egy hátteret, akkor a layoutot használó diák a layout háttérét alkalmazzák. További információért az elrendezés diákról lásd a [Apply or Change Slide Layouts](/slides/hu/cpp/slide-layout/) oldalt.
{{% /alert %}}

## **Slide Master elérése**

A PowerPointban a Slide Master nézetet a **View** > **Slide Master** menüpontból nyithatja meg.

![A Slide Master parancs a PowerPoint Nézet (View) lapon](slide-master_3.jpg)

Az Aspose.Slides-ban használja a `get_Masters()` gyűjteményt a mester diák eléréséhez:

```cpp
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

A normál dia által használt mester diát az elrendezésén keresztül is lekérdezheti:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Mi található egy Slide Master-ben**

A master slide egy dia-szerű objektum. Implementálja a [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) interfészt, ezért ugyanazokat a dia tulajdonságokat teszi elérhetővé, mint a normál és elrendezés diák. A master-specifikus tagok a [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) API oldalán találhatók.

Az általánosan használt master slide tagok a következők:

| Tag | Leírás |
| --- | --- |
| `get_Background()` | Beállítja a master szintű dia hátterét. |
| `get_Shapes()` | A masterre elhelyezett alakzatokat tárolja, például logókat, képkereteket és megosztott szöveget. |
| `get_LayoutSlides()` | A masterhez tartozó elrendezés diák tárolja. |
| `get_ThemeManager()` | Hozzáférést biztosít a master téma API-khoz. |
| `get_HeaderFooterManager()` | A fejlécek, láblécek, dátumok és dia számok vezérlése a master és annak gyermek elrendezései számára. |
| `GetDependingSlides()` | Visszaadja azokat a normál diákot, amelyek a masterhez tartoznak az elrendezésükön keresztül. |

## **Kép hozzáadása egy Slide Master-hez**

Amikor egy képet ad hozzá egy master diához, az a masterhez tartozó elrendezéseket használó diákon megjelenik. Ez hasznos logók, vízjelek, díszbövetek és egyéb ismétlődő vizuális elemek esetén.

A következő példa egy logót ad az első master diához:

```cpp
#include <DOM/IImageCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::IO;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto logoBytes = System::IO::File::ReadAllBytes(u"logo.png");
auto logoImage = presentation->get_Images()->AddImage(logoBytes);

masterSlide->get_Shapes()->AddPictureFrame(
    ShapeType::Rectangle,
    20.0f,
    20.0f,
    80.0f,
    80.0f,
    logoImage);

presentation->Save(u"presentation-with-logo.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Az képkeretekről további információk a [Picture Frame](/slides/hu/cpp/picture-frame/) oldalon találhatók.

## **A master grafika láthatóságának vezérlése**

A [IBaseSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/set_showmastershapes/) használatával elrejtheti a örökölt master grafikákat, például logókat vagy dísz alakzatokat, anélkül, hogy törölné azokat a masterről. Adjon `false` értéket a [Slide::set_ShowMasterShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/slide/set_showmastershapes/) metódusnak azon dián, amelynek el kell rejtenie ezeket a grafikákat, és `true`-t azoknál a diákon, amelyeknél meg kell jeleníteni.

A következő önálló példa egy kék díszbövetet hoz létre egy masteren, valamint két diát, amelyek ugyanazt az üres elrendezést használják. A bövet látható az első dián, a másodikon rejtett. Nem szükséges bemeneti bemutató vagy kép.

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/ILineFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ISlideSize.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);
auto layoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
layoutSlide->set_ShowMasterShapes(true);

auto slideHeight = presentation->get_SlideSize()->get_Size().get_Height();
auto band = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0.0f, 0.0f, 60.0f, slideHeight);
band->get_FillFormat()->set_FillType(FillType::Solid);
band->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
band->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

auto visibleSlide = presentation->get_Slide(0);
visibleSlide->set_LayoutSlide(layoutSlide);
visibleSlide->get_Shapes()->Clear();

auto hiddenSlide = presentation->get_Slides()->AddEmptySlide(layoutSlide);

visibleSlide->set_ShowMasterShapes(true);
hiddenSlide->set_ShowMasterShapes(false);

presentation->Save(u"master-graphics.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

A példa a **Blank** elrendezést használja, amely egy új bemutatóval együtt érkezik, és eltávolítja az első dia saját helyfoglalóit.

### **A beállítás hatókörének kiválasztása**

Egy normál dia a masterét a [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/islide/get_layoutslide/) és a [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilayoutslide/get_masterslide/) segítségével használja. A tulajdonság egyedi dián való beállítása csak azt a diát érinti. `false` átadása a [LayoutSlide::set_ShowMasterShapes](https://reference.aspose.com/slides/hu/cpp/aspose.slides/layoutslide/set_showmastershapes/) metódusnak elrejti a master grafikákat azokat a diákra, amelyek ezt a megosztott elrendezést használják, még akkor is, ha saját beállításuk `true`. Ahhoz, hogy csak egy dián rejtsen el grafikákat, módosítsa a dia tulajdonságát, és hagyja változatlanul a megosztott elrendezést.

A beállítás nem támogatott a master dia láthatóságának vezérlésére. A masteren mindig `false`-t ad vissza, és `true` érték beállítása `System::NotSupportedException`-t dob. Használja normál dián vagy elrendezésen.

### **A grafikák és a háttér megkülönböztetése**

| Művelet | Hatás |
| --- | --- |
| Master grafikák elrejtése | Az örökölt master alakzatok láthatóságát szabályozza, anélkül hogy törölné őket vagy megváltoztatná a dia saját alakzatait. |
| A dia háttér kitöltésének módosítása | Megváltoztatja a háttér színét, gradiensét vagy képét. A master grafikák külön alakzatok, és láthatóak maradhatnak ezen háttér felett. Lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) oldalt. |
| Alakzat törlése a masterből | Eltávolítja a megosztott forrás alakzatot, így már nem érhető el semmilyen, a mastert használó dián. |

## **Helyfoglalók kezelése**

A helyfoglalók általában az elrendezés diákon vannak definiálva. A master slide biztosítja a megosztott stílust és témát, amelyet az elrendezések örökölnek, míg minden elrendezés meghatározza, mely helyfoglalók érhetők el és hol vannak elhelyezve.

A PowerPointban a helyfoglaló parancsok a Slide Master nézetben érhetők el.

![A Helyfoglaló beszúrása parancs a PowerPoint Slide Master nézetben](slide-master_5.png)

Új helyfoglalók hozzáadásához az Aspose.Slides használatával, dolgozzon a masterhez tartozó elrendezés diával:

```cpp
#include <DOM/ILayoutPlaceholderManager.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto blankLayoutSlide = masterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (blankLayoutSlide == nullptr)
{
    blankLayoutSlide = masterSlide->get_LayoutSlides()->Add(SlideLayoutType::Blank, u"Blank");
}

blankLayoutSlide->get_PlaceholderManager()->AddTextPlaceholder(
    60.0f,
    120.0f,
    600.0f,
    80.0f);

presentation->get_Slides()->AddEmptySlide(blankLayoutSlide);
presentation->Save(u"presentation-with-placeholder.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Megformázhatja a master dián már létező helyfoglaló alakzatokat is. A következő példa megtalálja a cím helyfoglalót és lineáris gradiens kitöltést alkalmaz rá:

```cpp
#include <DOM/FillType.h>
#include <DOM/GradientShape.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFillFormat.h>
#include <DOM/IGradientFormat.h>
#include <DOM/IGradientStopCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IPlaceholder.h>
#include <DOM/IShapeCollection.h>
#include <DOM/PlaceholderType.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
System::SharedPtr<IAutoShape> titlePlaceholder;

for (auto&& shape : masterSlide->get_Shapes())
{
    auto autoShape = System::AsCast<IAutoShape>(shape);

    if (autoShape != nullptr &&
        autoShape->get_Placeholder() != nullptr &&
        autoShape->get_Placeholder()->get_Type() == PlaceholderType::Title)
    {
        titlePlaceholder = autoShape;
        break;
    }
}

if (titlePlaceholder != nullptr)
{
    auto fillFormat = titlePlaceholder->get_FillFormat();
    fillFormat->set_FillType(FillType::Gradient);

    auto gradientFormat = fillFormat->get_GradientFormat();
    gradientFormat->set_GradientShape(GradientShape::Linear);

    auto gradientStops = gradientFormat->get_GradientStops();
    auto redGradientColor = System::Drawing::Color::FromArgb(255, 0, 0);
    auto purpleGradientColor = System::Drawing::Color::FromArgb(128, 0, 128);

    gradientStops->Add(0.0f, redGradientColor);
    gradientStops->Add(255.0f, purpleGradientColor);
}

presentation->Save(u"presentation-title-style.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

![Formázott cím helyfoglaló, amely a normál diákra öröklődik](slide-master_8.png)

További helyfoglaló és szövegformázási lehetőségekért lásd a [Set Prompt Text in Placeholder](/slides/hu/cpp/manage-placeholder/) és a [Text Formatting](/slides/hu/cpp/text-formatting/) oldalakat.

## **Slide Master háttér módosítása**

A master háttér az elrendezések és diák által öröklődik, amelyek nem írják felül. A következő példa egy egyszínes háttérszínt állít be az első master diára:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kapcsolódó témákért lásd a [Presentation Background](/slides/hu/cpp/presentation-background/) és a [Presentation Theme](/slides/hu/cpp/presentation-theme/) oldalakat.

## **Slide Master klónozása egy másik bemutatóba**

A [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) használatával egy mester diát másolhat egy másik bemutatóba. A másolt master aztán az elrendezések és diák által a célbemutatóban használható.

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Ha normál diák másolására is szükség van a masterrel együtt, lásd a [Clone Slides](/slides/hu/cpp/clone-slides/) oldalt.

## **Több Slide Master hozzáadása**

Egy bemutató több mester diát is tartalmazhat. Ez akkor hasznos, amikor a különböző szakaszok különböző arculatot, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok mester diák beszúrásához és kezeléséhez](slide-master_9.jpg)

A következő példa klónozza az alapértelmezett mastert, más háttérrel látja el a klónt, létrehoz egy elrendezést a klónozott master alatt, és hozzáad egy új diát, amely ezt az elrendezést használja:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IMasterLayoutSlideCollection.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/SlideLayoutType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto defaultMasterSlide = presentation->get_Master(0);
auto sectionMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);
auto sectionMasterBackgroundColor = System::Drawing::Color::get_LightSteelBlue();

sectionMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
sectionMasterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
sectionMasterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(sectionMasterBackgroundColor);

auto sourceBlankLayout = defaultMasterSlide->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

if (sourceBlankLayout == nullptr)
{
    sourceBlankLayout = defaultMasterSlide->get_LayoutSlide(0);
}

auto sectionBlankLayout = sectionMasterSlide->get_LayoutSlides()->AddClone(sourceBlankLayout);

presentation->get_Slides()->AddEmptySlide(sectionBlankLayout);
presentation->Save(u"presentation-with-multiple-masters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Slide Master összehasonlítása**

A master diák összehasonlíthatók az [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) örökölt `Equals` metódusával. Az összehasonlítás ellenőrzi a szerkezetet és a statikus tartalmat, mint például alakzatok, szöveg, formázás, animációk és egyéb dia beállítások. Nem hasonlítja össze az egyedi azonosítókat, például a dia ID-ket, vagy a dinamikus helyfoglaló értékeket, mint a jelenlegi dátum.

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto firstPresentation = System::MakeObject<Presentation>(u"first.pptx");
auto secondPresentation = System::MakeObject<Presentation>(u"second.pptx");
auto firstPresentationMasterCount = firstPresentation->get_Masters()->get_Count();
auto secondPresentationMasterCount = secondPresentation->get_Masters()->get_Count();

for (int32_t firstMasterIndex = 0;
     firstMasterIndex < firstPresentationMasterCount;
     firstMasterIndex++)
{
    for (int32_t secondMasterIndex = 0;
         secondMasterIndex < secondPresentationMasterCount;
         secondMasterIndex++)
    {
        auto firstMasterSlide = firstPresentation->get_Master(firstMasterIndex);
        auto secondMasterSlide = secondPresentation->get_Master(secondMasterIndex);
        auto areMasterSlidesEqual = firstMasterSlide->Equals(secondMasterSlide);

        if (areMasterSlidesEqual)
        {
            System::Console::WriteLine(
                System::String::Format(
                    u"first.pptx master #{0} equals second.pptx master #{1}",
                    firstMasterIndex,
                    secondMasterIndex));
        }
    }
}

secondPresentation->Dispose();
firstPresentation->Dispose();
```

További információért lásd a [Compare Presentation Slides](/slides/hu/cpp/compare-slides/) oldalt.

## **A Slide Master nézet beállítása alapértelmezett nézetként**

A [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) `set_LastView` metódusával szabályozhatja, hogy a PowerPoint melyik nézetet nyissa meg először. A következő példa a bemutatót Slide Master nézetben nyitja meg:

```cpp
#include <DOM/IViewProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <ViewType.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

További nézetbeállításokért lásd a [Save Presentation](/slides/hu/cpp/save-presentation/) oldalt.

## **Használaton kívüli Master diák eltávolítása**

Néhány bemutató olyan master diákat tartalmaz, amelyeket már egyetlen normál dia sem használ. A használaton kívüli master diák eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

A használaton kívüli master diák eltávolításához használja a [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslidecollection/removeunused/) metódust a `get_Masters()` gyűjteményből:

```cpp
#include <DOM/IMasterSlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alkalmazhatja az alacsony kódú [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) metódust is:

```cpp
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <LowCode/Compress.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace Aspose::Slides::LowCode;

auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **FAQ**

**Mi a különbség egy slide master és egy layout slide között?**

A slide master közös tervezési beállításokat határoz meg, mint a téma, háttér, közös alakzatok és szövegstílusok. Egy layout slide egy master slide-hez tartozik, és egy konkrét helyfoglaló elrendezést definiál. Egy normál dia egy layout slide-ot használ, így mind a layout, mind a master beállításait örökli.

**Tartalmazhat egy bemutató több slide master-t?**

Igen. Egy bemutató több slide master-t is tartalmazhat. Több master használható, ha a különböző szakaszokhoz különböző vizuális rendszerek vagy arculatok szükségesek.

**Hol kell helyfoglalókat hozzáadni: a master slide-hez vagy a layout slide-hez?**

A legtöbb esetben a helyfoglalókat a layout diákhoz kell hozzáadni. A közös vizuális elemeket és közös formázást a master slide-re helyezze, majd a tartalmi helyfoglalókat azokban a layoutokban, amelyeket a normál diák használnak.

**Törölhetek egy még használt master slide-ot?**

Nem. Egy master slide, amelynek függő diái vannak, nem távolítható el biztonságosan. Először helyezze át ezeket a diákat egy másik master alá tartozó layoutokra, vagy használja a nem használt master takarítási módszert, amely csak a nem használt master-diákat távolítja el.