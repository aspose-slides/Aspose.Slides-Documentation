---
title: Prezentáció dia mestereinek kezelése C++-ban
linktitle: Dia mester
type: docs
weight: 80
url: /hu/cpp/slide-master/
keywords:
- dia mester
- mester dia
- PPT mester dia
- több mester dia
- mester diák összehasonlítása
- háttér
- helyőrző
- mester dia klónozása
- mester dia másolása
- mester dia duplikálása
- használaton kívüli mester dia
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Dia mesterek kezelése az Aspose.Slides for C++-ban: hozzáférés, szerkesztés, klónozás, összehasonlítás és mester diák eltávolítása PowerPoint és OpenDocument prezentációkban."
---
## **Áttekintés**

A **dia mester** meghatározza a csoport diái számára közös tervezési beállításokat. Tartalmazhat közös alakzatokat, logókat, háttereket, szövegstílusokat, téma beállításokat és láblécbeállításokat. PowerPointban a dia mester szerkesztése a szokásos módja annak, hogy a bemutató egységes maradjon anélkül, hogy minden diára külön-külön alkalmaznánk ugyanazt a formázást.

Az Aspose.Slides for C++ ugyanazt a modellt támogatja. Egy bemutató egy vagy több mester diát tartalmazhat, és minden mester dia több elrendezési diát is tartalmazhat. A normál diák általában nem hivatkoznak közvetlenül egy mester diára. Ehelyett egy normál dia egy elrendezési diát használ, amely egy mester diához tartozik.

A hierarchia:

1. **Dia mester** – meghatározza a közös tervezést és témát.  
1. **Elrendezési dia** – meghatározza a helyőrzők és elrendezési szintű formázás konkrét elrendezését.  
1. **Normál dia** – a tényleges bemutató tartalmat tartalmazza, és egy elrendezési diát használ.

![A mester diák, elrendezési diák és normál diák hierarchiája](slide-master_2.jpg)

Az Aspose.Slides-ben egy dia mester a [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) interfésszel van ábrázolva. A bemutató összes mester diája a [Presentation::get_Masters](https://reference.aspose.com/slides/hu/cpp/aspose.slides/presentation/get_masters/) gyűjteményen keresztül érhető el, amely a [IMasterSlideCollection](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/) implementációja.

{{% alert color="info" title="Öröklődés" %}}

Ha ugyanaz a tulajdonság több szinten is definiálva van, a specifikusabb szint nyeri el a hatalmat. Például, ha egy mester dia és egy elrendezési dia is meghatároz egy hátteret, az adott elrendezésre épülő diák az elrendezési hátteret használják. Az elrendezési diákról további információért lásd a [Diaelrendezések Alkalmazása vagy Módosítása](/slides/hu/cpp/slide-layout/) oldalt.

{{% /alert %}}

## **Dia Mesterek Elérése**

PowerPointban a **Nézet** > **Dia mester** menüpontból nyithatja meg a Dia Mester nézetet.

![A Dia Mester parancs a PowerPoint Nézet lapon](slide-master_3.jpg)

Az Aspose.Slides-ban a `get_Masters()` gyűjteményt használva érheti el a mester diákat:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto firstMasterSlide = presentation->get_Master(0);
auto masterSlideCount = presentation->get_Masters()->get_Count();
auto firstMasterLayoutSlideCount = firstMasterSlide->get_LayoutSlides()->get_Count();

System::Console::WriteLine(System::String(u"Master slides: ") + masterSlideCount);
System::Console::WriteLine(System::String(u"Layouts in the first master: ") + firstMasterLayoutSlideCount);

presentation->Dispose();
```

A normál dia által használt mester diát a saját elrendezésén keresztül is lekérheti:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto slide = presentation->get_Slide(0);
auto layoutSlide = slide->get_LayoutSlide();
auto masterSlide = layoutSlide->get_MasterSlide();
auto masterSlideName = masterSlide->get_Name();

System::Console::WriteLine(masterSlideName);

presentation->Dispose();
```

## **Mi Van Egy Dia Mesterben**

A mester dia egy dia-szerű objektum. Implementálja az [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) interfészt, így ugyanazok a dia tulajdonságok érhetők el, mint a normál és elrendezési diák esetén. A mesterre jellemző tagok a [IMasterSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslide/) API oldalon vannak felsorolva.

A gyakran használt mester dia tagok:

| Tag | Cél |
| --- | --- |
| `get_Background()` | Beállítja a mester szintű dia háttérét. |
| `get_Shapes()` | Tárolja a mesteren elhelyezett alakzatokat, például logókat, képkereteket és megosztott szöveget. |
| `get_LayoutSlides()` | Tárolja a mesterhez tartozó elrendezési diákot. |
| `get_ThemeManager()` | Hozzáférést biztosít a mester téma API-khoz. |
| `get_HeaderFooterManager()` | A mester és gyermek elrendezései fejlécét, láblécét, dátumát és dia számait szabályozza. |
| `GetDependingSlides()` | Visszaadja a normál diákokat, amelyek az elrendezéseiken keresztül függnek a mestertől. |

## **Kép Hozzáadása Egy Dia Mesterhez**

Amikor képet ad hozzá egy mester diához, az a mesterhez tartozó elrendezéseket használó diákon is megjelenik. Hasznos logók, vízjelek, díszszalagok és egyéb ismétlődő vizuális elemek esetén.

Az alábbi példa egy logót ad az első mester diához:

```cpp
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

A képkeretekről további információért lásd a [Képkeret](/slides/hu/cpp/picture-frame/) oldalt.

## **Munka Helyőrzőkkel**

A helyőrzőket általában elrendezési diákon definiálják. A mester dia biztosítja a közös stílust és témát, amit ezek az elrendezések örökölnek, míg minden elrendezés dönt arról, hogy mely helyőrzők állnak rendelkezésre és hol helyezkednek el.

PowerPointban a helyőrzőparancsok a Dia Mester nézetben érhetők el.

![A Helyőrző Beszúrása parancs a PowerPoint Dia Mester nézetben](slide-master_5.png)

Új helyőrzők hozzáadásához az Aspose.Slides-ban a mesterhez tartozó elrendezési diával dolgozzunk:

```cpp
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

Már meglévő helyőrző alakzatok formázása is lehetséges egy mester dián. Az alábbi példa megtalálja a cím helyőrzőt, és lineáris színátmenetes kitöltést alkalmaz rá:

```cpp
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

![Formázott cím helyőrző, amelyet a normál diák örökölnek](slide-master_8.png)

További helyőrző- és szövegformázási lehetőségekért lásd a [Helyőrző Szöveg Beállítása](/slides/hu/cpp/manage-placeholder/) és a [Szövegformázás](/slides/hu/cpp/text-formatting/) oldalakat.

## **Dia Mester Háttér Módosítása**

A mester háttér öröklődik az elrendezések és azok a diák, amelyek nem írják felül. Az alábbi példa egy szilárd háttérszínt állít be az első mester diához:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

auto masterSlide = presentation->get_Master(0);
auto masterBackgroundColor = System::Drawing::Color::get_ForestGreen();

masterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);
masterSlide->get_Background()->get_FillFormat()->set_FillType(FillType::Solid);
masterSlide->get_Background()->get_FillFormat()->get_SolidFillColor()->set_Color(masterBackgroundColor);

presentation->Save(u"presentation-master-background.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Kapcsolódó témák: [Bemutató Háttér](/slides/hu/cpp/presentation-background/) és [Bemutató Téma](/slides/hu/cpp/presentation-theme/).

## **Dia Mester Klónozása Másik Bemutatóba**

Használja az [IMasterSlideCollection::AddClone](https://reference.aspose.com/slides/hu/cpp/aspose.slides/imasterslidecollection/addclone/) metódust egy mester dia másik bemutatóba másolásához. A másolt mester ezután használható az elrendezések és diák számára a célbemutatóban.

```cpp
auto sourcePresentation = System::MakeObject<Presentation>(u"source.pptx");
auto destinationPresentation = System::MakeObject<Presentation>(u"destination.pptx");

auto sourceMasterSlide = sourcePresentation->get_Master(0);
auto clonedMasterSlide = destinationPresentation->get_Masters()->AddClone(sourceMasterSlide);

destinationPresentation->Save(u"destination-with-master.pptx", SaveFormat::Pptx);
destinationPresentation->Dispose();
sourcePresentation->Dispose();
```

Ha normál diákot szeretne klónozni a mesterével együtt, lásd a [Diák Klónozása](/slides/hu/cpp/clone-slides/) oldalt.

## **Több Dia Mester Hozzáadása**

Egy bemutató több mester diát is tartalmazhat. Hasznos, ha különböző szekciók különféle márkázást, oldalstruktúrát vagy téma beállításokat igényelnek.

![PowerPoint parancsok mester diák beszúrásához és kezeléséhez](slide-master_9.jpg)

Az alábbi példa klónozza az alapértelmezett mestert, a klónnak más hátteret ad, létrehozza egy elrendezést az úgy klónozott mester alatt, és egy új diát ad hozzá, amely azt az elrendezést használja:

```cpp
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

## **Dia Mesterek Összehasonlítása**

A mester diák összehasonlíthatók a [IBaseSlide](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ibaseslide/) által örökölt `Equals` metódussal. Az összehasonlítás a struktúrát és a statikus tartalmat vizsgálja, például alakzatokat, szöveget, formázást, animációkat és egyéb dia beállításokat. Nem hasonlítja össze az egyedi azonosítókat, például a dia‑azonosítókat, vagy a dinamikus helyőrző értékeket, például az aktuális dátumot.

```cpp
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

További információért lásd a [Bemutató Diák Összehasonlítása](/slides/hu/cpp/compare-slides/) oldalt.

## **Dia Mester Nézet Beállítása Alapértelmezett Nézetként**

Használja a `set_LastView` metódust a [ViewProperties](https://reference.aspose.com/slides/hu/cpp/aspose.slides/viewproperties/) osztályon, hogy meghatározza, melyik nézetet nyissa meg a PowerPoint elsőként. Az alábbi példa a bemutatót Dia Mester nézetben nyitja meg:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);
presentation->Save(u"presentation-master-view.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

További nézetbeállításokért lásd a [Bemutató Mentése](/slides/hu/cpp/save-presentation/) oldalt.

## **Nem Használt Mester Diák Eltávolítása**

Előfordulhat, hogy egy bemutató olyan mester diákat tartalmaz, amelyeket már egyetlen normál dia sem használ. A nem használt mesterek eltávolítása csökkentheti a fájlméretet és egyszerűsítheti a sablon karbantartását.

Használja a [MasterSlideCollection::RemoveUnused](https://reference.aspose.com/slides/hu/cpp/aspose.slides/masterslidecollection/removeunused/) metódust a `get_Masters()` gyűjteményből a nem használt mesterek eltávolításához:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

presentation->get_Masters()->RemoveUnused(true);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Alacsony kódú módszerként használhatja a [Compress::RemoveUnusedMasterSlides](https://reference.aspose.com/slides/hu/cpp/aspose.slides.lowcode/compress/removeunusedmasterslides/) metódust is:

```cpp
auto presentation = System::MakeObject<Presentation>(u"presentation.pptx");

LowCode::Compress::RemoveUnusedMasterSlides(presentation);
presentation->Save(u"presentation-clean.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **GYIK**

**Mi a különbség egy dia mester és egy elrendezési dia között?**

A dia mester meghatározza a közös tervezési beállításokat, például a témát, hátteret, közös alakzatokat és szövegstílusokat. Egy elrendezési dia egy mester diához tartozik, és egy konkrét helyőrző elrendezést definiál. Egy normál dia egy elrendezési diát használ, így a elrendezésből és a mesterből egyaránt örököl.

**Több dia mester is lehet egy bemutatóban?**

Igen. Egy bemutató tartalmazhat több dia mestert is. Több mestert használjon, ha a különböző szekcióknak eltérő vizuális rendszerekre vagy márkázásra van szükségük.

**Helyőrzőket a mester diára vagy az elrendezési diára kell-e feltenni?**

A legtöbb esetben az elrendezési diákba érdemes helyőrzőket tenni. A közös vizuális elemeket és formázást a mester diára helyezze, a tartalomhelyőrzőket pedig azokra az elrendezési diákra, amelyeket a normál diák használnak.

**Törölhetek-e egy még használt mester diát?**

Nem. A mester diát, amelyhez függő diák tartoznak, nem lehet biztonságosan közvetlenül eltávolítani. Először mozgassa át ezeket a diákat egy másik mester alatti elrendezésbe, vagy használja a nem használt mesterek tisztítási módszerét, amely csak a nem használt mestereket távolítja el.