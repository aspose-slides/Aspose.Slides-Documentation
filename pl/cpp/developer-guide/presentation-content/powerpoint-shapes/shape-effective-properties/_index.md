---
title: Pobieranie efektywnych właściwości kształtu z prezentacji w C++
linktitle: Właściwości efektywne
type: docs
weight: 50
url: /pl/cpp/shape-effective-properties/
keywords:
- właściwości kształtu
- właściwości kamery
- zestaw oświetlenia
- kształt fazowy
- ramka tekstowa
- styl tekstu
- wysokość czcionki
- format wypełnienia
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj, jak Aspose.Slides dla C++ oblicza i stosuje efektywne właściwości kształtu, aby zapewnić precyzyjne renderowanie w PowerPoint."
---
## **Przegląd**

Ten temat wyjaśnia różnicę między **lokalnymi** a **efektywnymi** właściwościami. Wartości lokalne to wartości ustawiane bezpośrednio na określonym poziomie formatowania, takie jak:

1. Właściwości fragmentów na slajdzie.  
1. Style tekstu prototypu kształtu w układzie lub slajdzie‑mistrzu, jeśli kształt ramki tekstowej fragmentu posiada je.  
1. Globalne ustawienia tekstu w prezentacji.

Wartości lokalne mogą być definiowane lub pomijane na dowolnym poziomie. Gdy Aspose.Slides potrzebuje ostatecznego formatowania „takiego jak wyświetlane”, rozwiązuje łańcuch dziedziczenia i zwraca **efektywne** wartości. Można je uzyskać, wywołując metodę `GetEffective` na obiekcie lokalnego formatu.

Poniższy przykład pokazuje, jak uzyskać wartości efektywne. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową i co najmniej jednym fragmentem.

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
Efektywne dane formatowania reprezentują bieżące wyliczone formatowanie po zastosowaniu dziedziczenia. W bieżącej implementacji niektóre obiekty danych efektywnych, takie jak [IPortionFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iportionformateffectivedata/), mogą być buforowane wewnętrznie. Ponowne wywołanie `GetEffective` po zmianie formatowania rodzica lub dziedziczonego może odświeżyć buforowane dane, a wcześniej uzyskany obiekt może już nie odzwierciedlać poprzedniego stanu. Jeśli musisz zachować wartości efektywne do późniejszego użycia, skopiuj wymagane właściwości, takie jak wysokość czcionki, kolor wypełnienia, styl czcionki lub wyrównanie, do własnego obiektu danych.
{{% /alert %}}

## **Uzyskiwanie efektywnych właściwości kamery**

Aspose.Slides umożliwia pobranie efektywnych właściwości kamery. Interfejs [ICameraEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icameraeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości kamery. Instancja [ICameraEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icameraeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które dostarcza efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy fragment kodu pokazuje, jak uzyskać efektywne właściwości kamery. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskiwanie efektywnych właściwości zestawu oświetlenia**

Aspose.Slides umożliwia pobranie efektywnych właściwości zestawu oświetlenia. Interfejs [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrigeffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości zestawu oświetlenia. Instancja [ILightRigEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilightrigeffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które dostarcza efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy fragment kodu pokazuje, jak uzyskać efektywne właściwości zestawu oświetlenia. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskiwanie efektywnych właściwości krawędzi kształtu**

Aspose.Slides umożliwia pobranie efektywnych właściwości fazy kształtu. Interfejs [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) reprezentuje niezmienny obiekt zawierający efektywne właściwości wypukłości (face‑relief) kształtu. Instancja [IShapeBevelEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapebeveleffectivedata/) jest udostępniana przez [IThreeDFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformateffectivedata/), które dostarcza efektywne wartości dla [IThreeDFormat](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ithreedformat/).

Poniższy fragment kodu pokazuje, jak uzyskać efektywne właściwości górnej fazy kształtu. Zakłada, że pierwszy kształt na pierwszym slajdzie ma formatowanie 3D.

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

## **Uzyskiwanie efektywnych właściwości ramki tekstowej**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości ramki tekstowej. Interfejs [ITextFrameFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextframeformateffectivedata/) zawiera efektywne właściwości formatowania ramki tekstowej.

Poniższy fragment kodu pokazuje, jak uzyskać efektywne właściwości formatowania ramki tekstowej. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową.

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

## **Uzyskiwanie efektywnych właściwości stylu tekstu**

Korzystając z Aspose.Slides, możesz uzyskać efektywne właściwości stylu tekstu. Interfejs [ITextStyleEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itextstyleeffectivedata/) zawiera efektywne właściwości stylu tekstu.

Poniższy fragment kodu pokazuje, jak uzyskać efektywne właściwości stylu tekstu. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [IAutoShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/iautoshape/) z ramką tekstową.

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

## **Uzyskanie efektywnej wartości wysokości czcionki**

Korzystając z Aspose.Slides, możesz uzyskać efektywną wysokość czcionki. Poniższy kod demonstruje, jak efektywna wysokość czcionki fragmentu zmienia się po ustawieniu lokalnych wartości wysokości czcionki na różnych poziomach struktury prezentacji.

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

## **Uzyskanie efektywnego formatu wypełnienia tabeli**

Korzystając z Aspose.Slides, możesz uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Interfejs [IFillFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ifillformateffectivedata/) zawiera efektywne właściwości formatowania wypełnienia. Formatowanie komórki ma wyższy priorytet niż formatowanie wiersza, formatowanie wiersza ma wyższy priorytet niż formatowanie kolumny, a formatowanie kolumny ma wyższy priorytet niż formatowanie całej tabeli.

W rezultacie właściwości [ICellFormatEffectiveData](https://reference.aspose.com/slides/pl/cpp/aspose.slides/icellformateffectivedata/) są używane do rysowania komórki tabeli. Poniższy fragment kodu pokazuje, jak uzyskać efektywne formatowanie wypełnienia dla różnych części tabeli. Zakłada, że pierwszy kształt na pierwszym slajdzie jest [ITable](https://reference.aspose.com/slides/pl/cpp/aspose.slides/itable/).

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

## **FAQ**

**Czy `GetEffective` zwraca migawkę?**

Nie zawsze. Dane efektywne reprezentują wyliczone formatowanie po zastosowaniu dziedziczenia, ale niektóre obiekty danych efektywnych mogą być buforowane wewnętrznie. Kolejne wywołanie `GetEffective` może ponownie przeliczyć formatowanie i odświeżyć buforowane dane, więc wcześniej uzyskany obiekt nie powinien być traktowany jako trwała migawka.

**Kiedy powinienem ponownie odczytać efektywne właściwości?**

Wywołaj ponownie `GetEffective` po zmianie lokalnego formatowania, stylów rodzica, formatowania układu, formatowania mastera lub domyślnych ustawień na poziomie prezentacji. Następne wywołanie ponownie oceni hierarchię formatowania i zwróci aktualny wynik efektywny.

**Czy zmiana lub usunięcie slajdu układu/mastera wpływa na już pobrane efektywne właściwości?**

Tak, ale zmiana jest odzwierciedlana przy następnym wywołaniu `GetEffective`. Jeśli źródło formatowania rodzica zostanie zmienione lub usunięte, wcześniej uzyskane dane efektywne mogą stać się nieaktualne. Po ponownym wywołaniu `GetEffective` Aspose.Slides ponownie ocenia drzewo formatowania i wynikowe czcionki, kolory, rozmiary lub inne wartości mogą ulec zmianie.

**Czy mogę modyfikować wartości poprzez obiekty danych efektywnych?**

Nie. Obiekty danych efektywnych udostępniają wyliczone wartości. Wprowadzaj zmiany w obiektach lokalnego formatowania, a następnie ponownie uzyskaj efektywne wartości.

**Co się dzieje, jeśli właściwość nie jest ustawiona na poziomie kształtu, ani w układzie/masterze, ani w ustawieniach globalnych?**

Wartość efektywna jest określana przez mechanizm domyślny, który obejmuje domyślne ustawienia PowerPointa i Aspose.Slides. Rozwiązana wartość staje się częścią bieżących danych efektywnych.

**Czy z efektywnej wartości czcionki mogę określić, który poziom dostarczył rozmiar lub krój?**

Nie bezpośrednio. Dane efektywne zwracają ostateczną wartość. Aby znaleźć źródło, sprawdź lokalne wartości w fragmencie, akapicie, ramce tekstowej oraz stylach tekstu na poziomach układu, mastera i prezentacji, aby zobaczyć, gdzie pojawia się pierwsza explicite definicja.

**Dlaczego efektywne wartości czasami wyglądają identycznie jak lokalne?**

Ponieważ wartość lokalna okazała się końcowa (nie było potrzebne dziedziczenie z wyższego poziomu). W takich przypadkach wartość efektywna jest taka sama jak lokalna.

**Kiedy powinienem używać właściwości efektywnych, a kiedy pracować wyłącznie z lokalnymi?**

Używaj danych efektywnych, gdy potrzebny jest wynik „tak jak wyświetlony” po zastosowaniu całego dziedziczenia, np. aby dopasować kolory, wcięcia lub rozmiary. Jeśli musisz zachować te wartości niezależnie od późniejszych zmian formatowania, skopiuj wymagane właściwości do własnego obiektu. Jeśli chcesz zmienić formatowanie na określonym poziomie, zmodyfikuj właściwości lokalne, a następnie, w razie potrzeby, ponownie odczytaj dane efektywne, aby zweryfikować wynik.