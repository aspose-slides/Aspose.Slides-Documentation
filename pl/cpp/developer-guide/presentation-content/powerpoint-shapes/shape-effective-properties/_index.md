---
title: Uzyskiwanie efektywnych właściwości kształtu z prezentacji w C++
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/cpp/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- system oświetlenia
- ksztalt fazowy
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Poznaj, jak Aspose.Slides dla C++ oblicza i stosuje efektywne właściwości kształtu, aby precyzyjnie renderować prezentacje w PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między właściwościami **lokalnymi** i **efektywnymi**. Wartości lokalne to wartości ustawione bezpośrednio na określonym poziomie formatowania, takie jak:

1. Właściwości fragmentu na slajdzie.
1. Style tekstu prototypowego kształtu na układzie lub slajdzie‑mistrzu, gdy forma ramki tekstowej fragmentu ma taki styl.
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „jak wyświetlane”, rozwiązuje łańcuch dziedziczenia i zwraca wartości **efektywne**. Można je uzyskać, wywołując metodę `GetEffective` na obiekcie formatu lokalnego.

Poniższy przykład pokazuje, jak uzyskać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową i co najmniej jednym fragmentem.

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
Dane formatowania efektywnego reprezentują bieżące obliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformateffectivedata/), mogą być buforowane wewnętrznie. Ponowne wywołanie `GetEffective` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać wcześniejszego stanu. Jeśli potrzebujesz zachować wartości efektywne do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Uzyskaj efektywne właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icameraeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskaj efektywne właściwości systemu oświetlenia**

Aspose.Slides umożliwia pobranie efektywnych właściwości systemu oświetlenia. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości systemu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrigeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości systemu oświetlenia. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskaj efektywne właściwości fazy kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości fazy kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości reliefu kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które zapewnia efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości górnej fazy kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskaj efektywne właściwości ramki tekstowej**

Korzystając z Aspose.Slides, możesz pobrać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową.

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

## **Uzyskaj efektywne właściwości stylu tekstu**

Korzystając z Aspose.Slides, możesz pobrać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

Poniższy przykład kodu pokazuje, jak uzyskać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową.

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

## **Uzyskaj efektywną wartość wysokości czcionki**

Korzystając z Aspose.Slides, możesz uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

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

## **Uzyskaj efektywny format wypełnienia tabeli**

Korzystając z Aspose.Slides, możesz uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórek ma wyższy priorytet niż formatowanie wierszy, formatowanie wierszy ma wyższy priorytet niż formatowanie kolumn, a formatowanie kolumn ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy przykład kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/).

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

## **FAQ**

### Czy `GetEffective` zwraca migawkę?

Nie zawsze. Dane efektywne reprezentują obliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `GetEffective` może ponownie obliczyć formatowanie i odświeżyć buforowane dane, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

### Kiedy powinienem ponownie odczytać efektywne właściwości?

Wywołaj `GetEffective` ponownie po zmianie formatowania lokalnego, stylów rodzica, formatowania układu, formatowania mistrza lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

### Czy zmiana lub usunięcie slajdu układu/mistrza wpływa na efektywne właściwości, które już zostały pobrane?

Tak, ale zmiana zostanie odzwierciedlona przy następnym wywołaniu `GetEffective`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `GetEffective` Aspose.Slides ponownie oceni drzewo formatowania i wyniki – czcionki, kolory, rozmiary lub inne wartości – mogą się zmienić.

### Czy mogę modyfikować wartości za pomocą obiektów danych efektywnych?

Nie. Obiekty danych efektywnych udostępniają jedynie wyliczone wartości. Wprowadzaj zmiany w obiektach formatowania lokalnego, a następnie ponownie pobieraj wartości efektywne.

### Co się stanie, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/mistrzu, ani w ustawieniach globalnych?

Wartość efektywna zostanie określona przez mechanizm domyślny, który obejmuje domyślne wartości PowerPointa i Aspose.Slides. Ta rozwiązana wartość staje się częścią bieżących danych efektywnych.

### Na podstawie efektywnej wartości czcionki, czy mogę określić, który poziom podał rozmiar lub krój?

Nie bezpośrednio. Dane efektywne zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź lokalne wartości w fragmencie, akapicie, ramce tekstowej oraz style tekstu na poziomach układu, mistrza i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicytna definicja.

### Dlaczego wartości efektywne czasami wyglądają identycznie jak lokalne?

Ponieważ wartość lokalna okazała się ostateczna (nie było konieczne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest taka sama jak lokalna.

### Kiedy powinienem używać właściwości efektywnych, a kiedy pracować wyłącznie z lokalnymi?

Używaj danych efektywnych, gdy potrzebny jest wynik „jak wyświetlane” po zastosowaniu całego dziedziczenia, np. do dopasowania kolorów, wcięć lub rozmiarów. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj potrzebne właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, modyfikuj właściwości lokalne, a następnie, w razie potrzeby, odczytaj ponownie dane efektywne, aby zweryfikować rezultat.