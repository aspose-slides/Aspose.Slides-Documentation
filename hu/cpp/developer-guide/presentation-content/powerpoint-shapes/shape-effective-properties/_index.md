---
title: Alakzat hatékony tulajdonságainak lekérdezése a prezentációkból C++-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/cpp/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- világítási rendszer
- relesz alakzat
- szövegdoboz
- szövegstílus
- betűmagasság
- kitöltő formátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan számítja ki és alkalmazza az Aspose.Slides for C++ a hatékony alakzat tulajdonságokat a pontos PowerPoint megjelenítés érdekében."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közti különbséget. A helyi értékek olyan értékek, amelyek közvetlenül egy adott formázási szinten vannak beállítva, például:

1. Szövegrész tulajdonságok egy dián.  
1. Prototype alakzat szövegstílusok egy elrendezésen vagy mesterdián, ha a szövegrész szövegdoboz alakzata rendelkezik ilyennel.  
1. Globális szövegbeállítások egy prezentációban.  

A helyi értékek meghatározhatók vagy elhagyhatók bármely szinten. Amikor az Aspose.Slidesnek szüksége van a végleges, “rendereltként” megjelenő formázásra, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektum `GetEffective` metódusának meghívásával kaphatja meg.

A következő példa bemutatja, hogyan lehet lekérni a hatékony értékeket. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegdobozzal és legalább egy szövegrészlettel rendelkezik.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="info" %}}
A hatékony formázási adatok a jelenleg kiszámított formázást jelentik az öröklődés alkalmazása után. A jelenlegi megvalósításban egyes hatékony adatobjektumok, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformateffectivedata/), akár belsőleg is gyorsítótárazva lehetnek. A `GetEffective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha a hatékony értékeket későbbi felhasználásra meg kell őrizni, másolja a szükséges tulajdonságokat, például a betűmagasságot, kitöltőszínt, betűstílust vagy igazítást saját adatobjektumába.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérdezése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérdezését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icameraeffectivedata/) interfész egy változtathatatlan objektumot képvisel, amely a kamera hatékony tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) hatékony értékeit biztosítja.

A következő kódrészlet bemutatja, hogyan lehet lekérni a kamera hatékony tulajdonságait. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```cpp
#include <DOM/ICameraEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto camera = threeDEffectiveData->get_Camera();

System::Console::WriteLine(u"= Effective camera properties =");
auto cameraType = System::ObjectExt::ToString(camera->get_CameraType());
System::Console::WriteLine(System::String(u"Type: ") + cameraType);

auto fieldOfViewAngle = camera->get_FieldOfViewAngle();
System::Console::WriteLine(System::String(u"Field of view: ") + fieldOfViewAngle);

auto cameraZoom = camera->get_Zoom();
System::Console::WriteLine(System::String(u"Zoom: ") + cameraZoom);

presentation->Dispose();
```

## **A fényrendszer hatékony tulajdonságainak lekérdezése**

Az Aspose.Slides lehetővé teszi a fényrendszer hatékony tulajdonságainak lekérdezését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrigeffectivedata/) interfész egy változtathatatlan objektumot képvisel, amely a fényrendszer hatékony tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) hatékony értékeit biztosítja.

A következő kódrészlet bemutatja, hogyan lehet lekérni a fényrendszer hatékony tulajdonságait. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```cpp
#include <DOM/ILightRigEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto lightRig = threeDEffectiveData->get_LightRig();

System::Console::WriteLine(u"= Effective light rig properties =");
auto lightType = System::ObjectExt::ToString(lightRig->get_LightType());
System::Console::WriteLine(System::String(u"Type: ") + lightType);

auto lightDirection = System::ObjectExt::ToString(lightRig->get_Direction());
System::Console::WriteLine(System::String(u"Direction: ") + lightDirection);

presentation->Dispose();
```

## **A relesz alakzat hatékony tulajdonságainak lekérdezése**

Az Aspose.Slides lehetővé teszi egy alakzat releszének hatékony tulajdonságainak lekérdezését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/) interfész egy változtathatatlan objektumot képvisel, amely az alakzat hatékony felületi-relief tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) hatékony értékeit biztosítja.

A következő kódrészlet bemutatja, hogyan lehet lekérni egy alakzat felső releszének hatékony tulajdonságait. Feltételezi, hogy az első dia első alakzata 3D formázással rendelkezik.

```cpp
#include <DOM/IShape.h>
#include <DOM/IShapeBevelEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/IThreeDFormat.h>
#include <DOM/IThreeDFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto shape = presentation->get_Slide(0)->get_Shape(0);

auto threeDEffectiveData = shape->get_ThreeDFormat()->GetEffective();
auto bevelTop = threeDEffectiveData->get_BevelTop();

System::Console::WriteLine(u"= Effective shape's top face relief properties =");
auto bevelType = System::ObjectExt::ToString(bevelTop->get_BevelType());
System::Console::WriteLine(System::String(u"Type: ") + bevelType);

auto bevelWidth = bevelTop->get_Width();
System::Console::WriteLine(System::String(u"Width: ") + bevelWidth);

auto bevelHeight = bevelTop->get_Height();
System::Console::WriteLine(System::String(u"Height: ") + bevelHeight);

presentation->Dispose();
```

## **A szövegdoboz hatékony tulajdonságainak lekérdezése**

Az Aspose.Slides segítségével lekérheti egy szövegdoboz hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformateffectivedata/) interfész a szövegdoboz hatékony formázási tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet lekérni a szövegdoboz hatékony formázási tulajdonságait. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegdobozzal rendelkezik.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextFrameFormatEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto effectiveTextFrameFormat = shape->get_TextFrame()->get_TextFrameFormat()->GetEffective();

auto anchoringType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AnchoringType());
System::Console::WriteLine(System::String(u"Anchoring type: ") + anchoringType);

auto autofitType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_AutofitType());
System::Console::WriteLine(System::String(u"Autofit type: ") + autofitType);

auto textVerticalType = System::ObjectExt::ToString(effectiveTextFrameFormat->get_TextVerticalType());
System::Console::WriteLine(System::String(u"Text vertical type: ") + textVerticalType);

System::Console::WriteLine(u"Margins");
auto marginLeft = effectiveTextFrameFormat->get_MarginLeft();
System::Console::WriteLine(System::String(u"   Left: ") + marginLeft);

auto marginTop = effectiveTextFrameFormat->get_MarginTop();
System::Console::WriteLine(System::String(u"   Top: ") + marginTop);

auto marginRight = effectiveTextFrameFormat->get_MarginRight();
System::Console::WriteLine(System::String(u"   Right: ") + marginRight);

auto marginBottom = effectiveTextFrameFormat->get_MarginBottom();
System::Console::WriteLine(System::String(u"   Bottom: ") + marginBottom);

presentation->Dispose();
```

## **A szövegstílus hatékony tulajdonságainak lekérdezése**

Az Aspose.Slides segítségével lekérheti a szövegstílus hatékony tulajdonságait. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextstyleeffectivedata/) interfész a szövegstílus hatékony tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet lekérni a szövegstílus hatékony tulajdonságait. Feltételezi, hogy az első dia első alakzata egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegdobozzal rendelkezik.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraphFormatEffectiveData.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/ITextStyle.h>
#include <DOM/ITextStyleEffectiveData.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));
auto effectiveTextStyle = shape->get_TextFrame()->get_TextFrameFormat()->get_TextStyle()->GetEffective();
int levelCount = 9;

for (int levelIndex = 0; levelIndex < levelCount; levelIndex++)
{
    auto effectiveStyleLevel = effectiveTextStyle->GetLevel(levelIndex);

    auto depth = effectiveStyleLevel->get_Depth();
    auto indent = effectiveStyleLevel->get_Indent();
    auto alignment = System::ObjectExt::ToString(effectiveStyleLevel->get_Alignment());
    auto fontAlignment = System::ObjectExt::ToString(effectiveStyleLevel->get_FontAlignment());

    System::Console::WriteLine(System::String(u"= Effective paragraph formatting for style level #") + levelIndex + u" =");
    System::Console::WriteLine(System::String(u"Depth: ") + depth);
    System::Console::WriteLine(System::String(u"Indent: ") + indent);
    System::Console::WriteLine(System::String(u"Alignment: ") + alignment);
    System::Console::WriteLine(System::String(u"Font alignment: ") + fontAlignment);
}

presentation->Dispose();
```

## **A hatékony betűmagasság értékének lekérdezése**

Az Aspose.Slides segítségével lekérheti a hatékony betűmagasságot. A következő kód bemutatja, hogyan változik egy szövegrész hatékony betűmagassága, miután a helyi betűmagasság értékeket a prezentáció különböző szintjein beállították.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IPortionFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextStyle.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();

auto slide = presentation->get_Slide(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 400.0f, 75.0f, false);
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();
auto paragraph = textFrame->get_Paragraph(0);
auto portions = paragraph->get_Portions();
portions->Clear();

auto firstPortion = System::MakeObject<Portion>(u"Sample text with first portion");
auto secondPortion = System::MakeObject<Portion>(u" and second portion.");

portions->Add(firstPortion);
portions->Add(secondPortion);

System::Console::WriteLine(u"Effective font height just after creation:");
auto firstPortionFormat = firstPortion->get_PortionFormat();
auto secondPortionFormat = secondPortion->get_PortionFormat();

auto printEffectiveFontHeights = [&]()
{
    auto firstPortionFontHeight = firstPortionFormat->GetEffective()->get_FontHeight();
    auto secondPortionFontHeight = secondPortionFormat->GetEffective()->get_FontHeight();

    System::Console::WriteLine(System::String(u"Portion #0: ") + firstPortionFontHeight);
    System::Console::WriteLine(System::String(u"Portion #1: ") + secondPortionFontHeight);
};

printEffectiveFontHeights();

presentation->get_DefaultTextStyle()->GetLevel(0)->get_DefaultPortionFormat()->set_FontHeight(24.0f);

System::Console::WriteLine(u"Effective font height after setting the presentation default font height:");
printEffectiveFontHeights();

paragraph->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(40.0f);

System::Console::WriteLine(u"Effective font height after setting paragraph default font height:");
printEffectiveFontHeights();

firstPortionFormat->set_FontHeight(55.0f);

System::Console::WriteLine(u"Effective font height after setting portion #0 font height:");
printEffectiveFontHeights();

secondPortionFormat->set_FontHeight(18.0f);

System::Console::WriteLine(u"Effective font height after setting portion #1 font height:");
printEffectiveFontHeights();

presentation->Save(u"SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **A táblázat hatékony kitöltőformátumának lekérdezése**

Az Aspose.Slides segítségével lekérheti a különböző táblázatrészek hatékony kitöltőformázását. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/) interfész a hatékony kitöltőformázási tulajdonságokat tartalmazza. A cella formázása magasabb prioritással bír, mint a sor formázása, a sor formázása magasabb prioritással bír, mint az oszlop formázása, és az oszlop formázása magasabb prioritással bír, mint a teljes táblázat formázása.

Ennek következtében az [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icellformateffectivedata/) tulajdonságok használatosak a táblázatcellák kirajzolásához. A következő kódrészlet bemutatja, hogyan lehet lekérni a különböző táblázatrészek hatékony kitöltőformázását. Feltételezi, hogy az első dia első alakzata egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) objektum.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Table/ICell.h>
#include <DOM/Table/ICellFormat.h>
#include <DOM/Table/ICellFormatEffectiveData.h>
#include <DOM/Table/IColumn.h>
#include <DOM/Table/IColumnFormat.h>
#include <DOM/Table/IColumnFormatEffectiveData.h>
#include <DOM/Table/IRow.h>
#include <DOM/Table/IRowFormat.h>
#include <DOM/Table/IRowFormatEffectiveData.h>
#include <DOM/Table/ITable.h>
#include <DOM/Table/ITableFormat.h>
#include <DOM/Table/ITableFormatEffectiveData.h>
using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto table = System::ExplicitCast<ITable>(slide->get_Shape(0));

auto tableFillFormatEffective = table->get_TableFormat()->GetEffective()->get_FillFormat();
auto rowFillFormatEffective = table->get_Row(0)->get_RowFormat()->GetEffective()->get_FillFormat();
auto columnFillFormatEffective = table->get_Column(0)->get_ColumnFormat()->GetEffective()->get_FillFormat();
auto cellFillFormatEffective = table->idx_get(0, 0)->get_CellFormat()->GetEffective()->get_FillFormat();

presentation->Dispose();
```

## **GYIK**

### A `GetEffective` egy pillanatfelvételt ad vissza?

Nem mindig. A hatékony adatok az öröklődés alkalmazása után kiszámított formázást jelentik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazva lehetnek. Egy későbbi `GetEffective` hívás újraszámíthatja a formázást és frissítheti a gyorsítótárat, ezért egy korábban lekért objektumot nem szabad tartós pillanatfelvételnek tekinteni.

### Mikor kell újból beolvasni a hatékony tulajdonságokat?

Hívja meg újra a `GetEffective`‑et a helyi formázás, a szülő stílusok, az elrendezés formázása, a mester formázása vagy a prezentáció szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát, és a jelenlegi hatékony eredményt adja vissza.

### A elrendezés/mester dia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?

Igen, de a változás a következő `GetEffective` hívásakor fog megjelenni. Ha egy szülő formázási forrás módosul vagy eltávolításra kerül, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `GetEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és az eredményül kapott betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

### Módosíthatok értékeket a hatékony adatobjektumokon keresztül?

Nem. A hatékony adatobjektumok csak a kiszámított értékeket mutatják. Végezze a módosításokat a helyi formázási objektumokban, majd kérje le újból a hatékony értékeket.

### Mi történik, ha egy tulajdonság nincs beállítva sem az alakzatszinten, sem az elrendezésen/mesteren, sem a globális beállításokban?

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a meghatározott érték a jelenlegi hatékony adatok részévé válik.

### Egy hatékony betűértékből meg tudom határozni, hogy melyik szint szolgáltatta a méretet vagy a betűtípust?

Nem közvetlenül. A hatékony adatok a végső értéket adják vissza. A forrás megtalálásához ellenőrizze a helyi értékeket a szövegrész, bekezdés, szövegdoboz és a szövegstílusok szintjén az elrendezés, a mester és a prezentáció szintjein, hogy hol jelenik meg az első explicit definíció.

### Miért tűnnek a hatékony értékek néha azonosnak a helyi értékekkel?

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetekben a hatékony érték megegyezik a helyi értékkel.

### Mikor kell hatékony tulajdonságokat használni, és mikor csak a helyi tulajdonságokkal kell dolgozni?

Használjon hatékony adatokat, amikor a teljes öröklődés után a „rendereltként” megjelenő eredményre van szükség, például színek, behúzások vagy méretek igazításához. Ha ezeket az értékeket későbbi formázási változásoktól függetlenül meg kell őrizni, másolja a szükséges tulajdonságokat saját objektumába. Ha egy adott szinten szeretne formázást módosítani, változtassa meg a helyi tulajdonságokat, majd szükség esetén olvassa be újra a hatékony adatokat a kimenet ellenőrzéséhez.