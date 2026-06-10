---
title: Alakzat hatékony tulajdonságainak lekérése előadásokból C++-ban
linktitle: Hatékony tulajdonságok
type: docs
weight: 50
url: /hu/cpp/shape-effective-properties/
keywords:
- alakzat tulajdonságok
- kamera tulajdonságok
- fényrig
- bevel alakzat
- szövegkeret
- szövegstílus
- betűmagasság
- kitöltő formátum
- PowerPoint
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, hogyan számítja és alkalmazza az Aspose.Slides for C++ a hatékony alakzati tulajdonságokat a pontos PowerPoint megjelenítéshez."
---
## **Áttekintés**

Ez a téma elmagyarázza a **helyi** és **hatékony** tulajdonságok közti különbséget. A helyi értékek olyan értékek, amelyeket közvetlenül egy adott formázási szinten állítanak be, például:

1. Rész tulajdonságok egy dián.  
1. Prototípus alakzat szövegstílusok egy elrendezésen vagy mesterdián, ha a rész szövegkeret alakzatának van ilyen.  
1. Globális szövegbeállítások egy előadásban.

A helyi értékek bármely szinten definiálhatók vagy elhagyhatók. Amikor az Aspose.Slides-nek szüksége van a végleges, “renderelt” formázásra, feloldja az öröklődési láncot, és **hatékony** értékeket ad vissza. Ezeket a helyi formátumobjektum `GetEffective` metódusának meghívásával tudod lekérni.

A következő példa bemutatja, hogyan lehet lekérni a hatékony értékeket. Feltételezi, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegkerettel és legalább egy résszel.

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");

auto slide = presentation->get_Slide(0);
auto shape = System::ExplicitCast<IAutoShape>(slide->get_Shape(0));

auto textFrame = shape->get_TextFrame();
auto effectiveTextFrameFormat = textFrame->get_TextFrameFormat()->GetEffective();

auto portion = textFrame->get_Paragraph(0)->get_Portion(0);
auto effectivePortionFormat = portion->get_PortionFormat()->GetEffective();

presentation->Dispose();
```

{{% alert color="primary" %}}
A hatékony formázási adatok a jelenleg számított formázást képviselik az öröklődés alkalmazása után. A jelenlegi megvalósításban bizonyos hatékony adatobjektumok, például a [IPortionFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iportionformateffectivedata/), belsőleg gyorsítótárazottak lehetnek. A `GetEffective` újbóli meghívása a szülő vagy az örökölt formázás módosítása után frissítheti a gyorsítótárat, és egy korábban lekért objektum már nem feltétlenül tükrözi a korábbi állapotot. Ha a hatékony értékeket későbbi felhasználásra kell megőrizned, másold a szükséges tulajdonságokat, például betűmagasságot, kitöltő színt, betűstílust vagy igazítást a saját adatobjektumodba.
{{% /alert %}}

## **A kamera hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a kamera hatékony tulajdonságainak lekérését. A [ICameraEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icameraeffectivedata/) interfész egy immutable objektumot képvisel, amely a kamera hatékony tulajdonságait tartalmazza. Egy [ICameraEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icameraeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) számára.

A következő kódrészlet bemutatja, hogyan lehet a kamera hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```cpp
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

## **A fényrig hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi a fényrig hatékony tulajdonságainak lekérését. A [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrigeffectivedata/) interfész egy immutable objektumot képvisel, amely a fényrig hatékony tulajdonságait tartalmazza. Egy [ILightRigEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ilightrigeffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) számára.

A következő kódrészlet bemutatja, hogyan lehet a fényrig hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```cpp
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

## **A shape bevel hatékony tulajdonságainak lekérése**

Az Aspose.Slides lehetővé teszi egy alakzat bevel hatékony tulajdonságainak lekérését. A [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/) interfész egy immutable objektumot képvisel, amely az alakzat felület-nyúlvány tulajdonságait tartalmazza. Egy [IShapeBevelEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ishapebeveleffectivedata/) példány a [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformateffectivedata/) segítségével érhető el, amely hatékony értékeket biztosít a [IThreeDFormat](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ithreedformat/) számára.

A következő kódrészlet bemutatja, hogyan lehet egy alakzat felső bevel hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat 3D formázással rendelkezik.

```cpp
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

## **A text frame hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheted egy szövegkeret hatékony tulajdonságait. A [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextframeformateffectivedata/) interfész a szövegkeret hatékony formázási tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet a szövegkeret hatékony formázási tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```cpp
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

## **A text style hatékony tulajdonságainak lekérése**

Az Aspose.Slides segítségével lekérheted egy szövegstílus hatékony tulajdonságait. A [ITextStyleEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itextstyleeffectivedata/) interfész a szövegstílus hatékony tulajdonságait tartalmazza.

A következő kódrészlet bemutatja, hogyan lehet a szövegstílus hatékony tulajdonságait lekérni. Feltételezi, hogy az első dián az első alakzat egy [IAutoShape](https://reference.aspose.com/slides/hu/cpp/aspose.slides/iautoshape/) szövegkerettel rendelkezik.

```cpp
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

## **A hatékony betűmagasság értékének lekérése**

Az Aspose.Slides segítségével lekérheted a hatékony betűmagasságot. A következő kód bemutatja, hogyan változik egy rész hatékony betűmagassága, amikor a helyi betűmagasság értékek különböző előadási struktúra szinteken kerülnek beállításra.

```cpp
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

## **A táblázat hatékony kitöltő formátumának lekérése**

Az Aspose.Slides segítségével lekérheted a táblázat különböző részeinek hatékony kitöltő formázását. A [IFillFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/ifillformateffectivedata/) interfész a kitöltő formázás hatékony tulajdonságait tartalmazza. A cella formázásának nagyobb prioritása van, mint a sor formázásának, a sor formázásnak nagyobb prioritása van, mint az oszlop formázásának, és az oszlop formázásnak nagyobb prioritása van, mint a teljes táblázat formázásának.

Ennek következtében a [ICellFormatEffectiveData](https://reference.aspose.com/slides/hu/cpp/aspose.slides/icellformateffectivedata/) tulajdonságai használatosak a táblázat cellájának megrajzolásához. A következő kódrészlet bemutatja, hogyan lehet a táblázat különböző részeinek hatékony kitöltő formázását lekérni. Feltételezi, hogy az első dián az első alakzat egy [ITable](https://reference.aspose.com/slides/hu/cpp/aspose.slides/itable/) példány.

```cpp
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

**A `GetEffective` egy pillanatképet ad vissza?**

Nem mindig. A hatékony adatok az öröklődés alkalmazása után számított formázást képviselik, de egyes hatékony adatobjektumok belsőleg gyorsítótárazottak lehetnek. Egy későbbi `GetEffective` hívás újraszámolhatja a formázást és frissítheti a gyorsítótárat, így a korábban kapott objektum nem tekinthető tartós pillanatképként.

**Mikor kell újra beolvasni a hatékony tulajdonságokat?**

Hívd meg újból a `GetEffective` metódust a helyi formázás, a szülő stílusok, az elrendezés formázása, a mester formázása vagy az előadás szintű alapértelmezések módosítása után. A következő hívás újraértékeli a formázási hierarchiát és visszaadja a jelenlegi hatékony eredményt.

**A layout/mesterdia módosítása vagy eltávolítása befolyásolja a már lekért hatékony tulajdonságokat?**

Igen, de a változás a következő `GetEffective` híváskor jelenik meg. Ha egy szülő formázási forrást módosítanak vagy eltávolítanak, a korábban lekért hatékony adatok elavultak lehetnek. Amint a `GetEffective` újra meghívásra kerül, az Aspose.Slides újraértékeli a formázási fát, és a betűtípusok, színek, méretek vagy egyéb értékek megváltozhatnak.

**Módosíthatók a értékek hatékony adatobjektumokon keresztül?**

Nem. A hatékony adatobjektumok csak a kiszámított értékeket exponálnak. Változtass a helyi formázási objektumokon, majd szerezd be újra a hatékony értékeket.

**Mi történik, ha egy tulajdonság nincs beállítva sem az alakzat szintjén, sem a layout/mester szintjén, sem a globális beállításokban?**

A hatékony értéket az alapértelmezett mechanizmus határozza meg, amely magában foglalja a PowerPoint és az Aspose.Slides alapértelmezéseit. Ez a feloldott érték része lesz a jelenlegi hatékony adatnak.

**A hatékony betűértékből megállapítható, melyik szint biztosította a méretet vagy a betűtípust?**

Nem közvetlenül. A hatékony adatok a végső értéket adják vissza. A forrás megtalálásához ellenőrizd a helyi értékeket a rész, bekezdés, szövegkeret és a szövegstílusok szintjein a layout, master és előadás szintjén, hogy lásd, hol jelent meg először az explicit meghatározás.

**Miért néznek ki a hatékony értékek néha azonosnak a helyi értékekkel?**

Mert a helyi érték végsővé vált (nem volt szükség magasabb szintű öröklődésre). Ilyen esetben a hatékony érték megegyezik a helyivel.

**Mikor használjam a hatékony tulajdonságokat, és mikor csak a helyieket?**

Használd a hatékony adatokat, ha a „renderelt” eredményre van szükséged az összes öröklődés alkalmazása után, például színek, beljebb húzások vagy méretek összehangolásához. Ha meg akarod őrizni ezeket az értékeket a későbbi formázási változások ellenére, másold a szükséges tulajdonságokat saját objektumodba. Ha egy adott szinten szeretnél formázást változtatni, módosítsd a helyi tulajdonságokat, majd szükség esetén olvasd be újra a hatékony adatokat a végeredmény ellenőrzéséhez.