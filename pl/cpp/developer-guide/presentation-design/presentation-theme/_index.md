---
title: Zarządzaj motywami prezentacji w C++
linktitle: Motyw prezentacji
type: docs
weight: 10
url: /pl/cpp/presentation-theme/
keywords:
- Motyw PowerPoint
- motyw prezentacji
- motyw slajdu
- ustaw motyw
- zmień motyw
- zarządzaj motywem
- zewnętrzny motyw
- THMX
- kolor motywu
- dodatkowa paleta
- czcionka motywu
- styl motywu
- efekt motywu
- PowerPoint
- OpenDocument
- prezentacja
- C++
- Aspose.Slides
description: "Główne motywy prezentacji w Aspose.Slides dla C++, umożliwiające tworzenie, dostosowywanie i konwertowanie plików PowerPoint z zachowaniem spójnej identyfikacji wizualnej."
---
## **Wprowadzenie**

Motyw prezentacji definiuje skoordynowany zestaw kolorów, czcionek, stylów tła, wypełnień, linii i efektów. Obiekty świadome motywu odwołują się do tych współdzielonych definicji zamiast przechowywać każdą właściwość wizualną jako stałą wartość, więc zmiana motywu może zaktualizować wiele obiektów jednocześnie.

W Aspose.Slides motyw na poziomie prezentacji jest dostępny przez [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_mastertheme/). Prezentacja może również zawierać nadpisania motywu na niższych poziomach. Master może nadpisać motyw prezentacji za pomocą [MasterThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/masterthememanager/get_overridetheme/), natomiast układ lub pojedynczy slajd może używać [IOverrideThemeManager::get_OverrideTheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ioverridethememanager/get_overridetheme/). W praktyce skuteczny motyw slajdu jest rozwiązywany w następującej kolejności dziedziczenia: motyw prezentacji, nadpisanie mastera, nadpisanie układu i nadpisanie slajdu.

![Theme components: colors, fonts, background styles, and effects](theme-constituents.png)

Poniższe sekcje przedstawiają najczęstsze scenariusze pracy z motywem: przeglądanie motywu, zmiana kolorów i czcionek, kopiowanie lub zastosowanie motywu, aktualizacja stylów tła i efektów oraz odczyt skutecznych wartości po rozstrzygnięciu dziedziczenia i nadpisań.

## **Sprawdź motyw**

Obiekt [MasterTheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/mastertheme/) udostępnia metody [get_ColorScheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/mastertheme/get_colorscheme/), [get_FontScheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/mastertheme/get_fontscheme/) oraz [get_FormatScheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/mastertheme/get_formatscheme/). Przeglądanie tych kolekcji przed ich zmianą jest szczególnie przydatne, gdy prezentacja pochodzi ze źródła zewnętrznego, ponieważ liczba i zawartość wpisów stylów może się różnić.

Poniższy przykład odczytuje podstawowe właściwości motywu i podaje, ile stylów tła, wypełnienia, linii i efektów jest przechowywanych w motywie:

```cpp
#include <DOM/IColorFormat.h>
#include <DOM/IFonts.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto theme = presentation->get_MasterTheme();
auto formatScheme = theme->get_FormatScheme();

Console::WriteLine(u"Theme name: {0}", theme->get_Name());
Console::WriteLine(u"Accent 1: {0}", theme->get_ColorScheme()->get_Accent1()->get_Color());
Console::WriteLine(u"Major Latin font: {0}", theme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Minor Latin font: {0}", theme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Background fill styles: {0}", formatScheme->get_BackgroundFillStyles()->get_Count());
Console::WriteLine(u"Fill styles: {0}", formatScheme->get_FillStyles()->get_Count());
Console::WriteLine(u"Line styles: {0}", formatScheme->get_LineStyles()->get_Count());
Console::WriteLine(u"Effect styles: {0}", formatScheme->get_EffectStyles()->get_Count());
```

Jeśli plik używa wielu masterów, nie zakładaj, że każdy slajd ma taki sam skuteczny motyw. Sprawdź master powiązany ze slajdem i użyj workflowu skutecznego motywu przedstawionego dalej w tym artykule, gdy mogą występować nadpisania układu lub slajdu.

## **Zmień kolory motywu**

Wypełnienia, linie i tekst świadome motywu mogą odwoływać się do logicznego koloru z wyliczenia [SchemeColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/schemecolor/). Gdy zmienisz odpowiedni wpis w motywie [IColorScheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/icolorscheme/), wszystkie obiekty nadal odwołujące się do tego koloru motywu zostaną rozpoznane względem nowej wartości. Obiekty używające bezpośredniego koloru RGB nie są zmieniane przez aktualizację koloru motywu.

Poniższy kompletny przykład tworzy kształt używający `Accent4`, zmienia kolor `Accent4` w motywie na czerwony, zapisuje prezentację, otwiera ją ponownie i wypisuje skuteczny kolor wypełnienia:

```cpp
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IColorScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);
presentation->get_MasterTheme()->get_ColorScheme()->get_Accent4()->set_Color(Color::get_Red());
presentation->Save(u"theme-color.pptx", SaveFormat::Pptx);

auto savedPresentation = MakeObject<Presentation>(u"theme-color.pptx");
auto savedSlide = savedPresentation->get_Slide(0);
auto savedShape = savedSlide->get_Shape(0);
auto effectiveFill = savedShape->get_FillFormat()->GetEffective();
Console::WriteLine(u"Effective fill color: {0}", effectiveFill->get_SolidFillColor());
```

Ponieważ prostokąt pozostaje powiązany z `Accent4`, jego widoczny kolor staje się czerwony po zmianie motywu. Jeśli zamienisz kolor schematu na bezpośredni kolor w kształcie, późniejsze zmiany `Accent4` nie będą już wpływać na to wypełnienie.

### **Użyj kolorów z dodatkowej palety**

PowerPoint tworzy jaśniejsze i ciemniejsze warianty koloru motywu poprzez przekształcenia kolorów. Aspose.Slides udostępnia te przekształcenia za pośrednictwem [ColorTransformOperation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/colortransformoperation/).

![Main theme colors and lighter and darker colors generated from the additional palette](additional-palette-colors.png)

**1** - Główne kolory motywu.

**2** - Jaśniejsze i ciemniejsze warianty wyprodukowane z głównych kolorów motywu.

Poniższy przykład tworzy sześć prostokątów opartych na `Accent4`, stosuje przekształcenia luminancji do pięciu z nich i zapisuje wynik:

```cpp
#include <DOM/ColorTransformOperation.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IColorOperationCollection.h>
#include <DOM/IFillFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/SchemeColor.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape1 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 10.0f, 50.0f, 50.0f);
auto fillFormat1 = shape1->get_FillFormat();
fillFormat1->set_FillType(FillType::Solid);
fillFormat1->get_SolidFillColor()->set_SchemeColor(SchemeColor::Accent4);

auto shape2 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 70.0f, 50.0f, 50.0f);
auto fillFormat2 = shape2->get_FillFormat();
auto solidFillColor2 = fillFormat2->get_SolidFillColor();
fillFormat2->set_FillType(FillType::Solid);
solidFillColor2->set_SchemeColor(SchemeColor::Accent4);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.2f);
solidFillColor2->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.8f);

auto shape3 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 130.0f, 50.0f, 50.0f);
auto fillFormat3 = shape3->get_FillFormat();
auto solidFillColor3 = fillFormat3->get_SolidFillColor();
fillFormat3->set_FillType(FillType::Solid);
solidFillColor3->set_SchemeColor(SchemeColor::Accent4);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.4f);
solidFillColor3->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.6f);

auto shape4 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 190.0f, 50.0f, 50.0f);
auto fillFormat4 = shape4->get_FillFormat();
auto solidFillColor4 = fillFormat4->get_SolidFillColor();
fillFormat4->set_FillType(FillType::Solid);
solidFillColor4->set_SchemeColor(SchemeColor::Accent4);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.6f);
solidFillColor4->get_ColorTransform()->Add(ColorTransformOperation::AddLuminance, 0.4f);

auto shape5 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 250.0f, 50.0f, 50.0f);
auto fillFormat5 = shape5->get_FillFormat();
auto solidFillColor5 = fillFormat5->get_SolidFillColor();
fillFormat5->set_FillType(FillType::Solid);
solidFillColor5->set_SchemeColor(SchemeColor::Accent4);
solidFillColor5->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.75f);

auto shape6 = shapes->AddAutoShape(ShapeType::Rectangle, 10.0f, 310.0f, 50.0f, 50.0f);
auto fillFormat6 = shape6->get_FillFormat();
auto solidFillColor6 = fillFormat6->get_SolidFillColor();
fillFormat6->set_FillType(FillType::Solid);
solidFillColor6->set_SchemeColor(SchemeColor::Accent4);
solidFillColor6->get_ColorTransform()->Add(ColorTransformOperation::MultiplyLuminance, 0.5f);

presentation->Save(u"theme-color-palette.pptx", SaveFormat::Pptx);
```

Te warianty pozostają oparte na kolorze motywu. Jeśli `Accent4` zmieni się później, przekształcone kolory zostaną ponownie obliczone na podstawie nowej wartości `Accent4`.

### **Mapuj wartości `SchemeColor` na sloty `IColorScheme`**

Wyliczenie [SchemeColor](https://reference.aspose.com/slides/pl/cpp/aspose.slides/schemecolor/) używa `Text1`, `Background1`, `Text2` i `Background2`, natomiast [IColorScheme](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/icolorscheme/) udostępnia te same sloty motywu jako `Dark1`, `Light1`, `Dark2` i `Light2`. Mapowanie jest stałe:

* `Text1` = `Dark1`
* `Background1` = `Light1`
* `Text2` = `Dark2`
* `Background2` = `Light2`

Są to alternatywne nazwy tych samych slotów motywu; nie są to wartości dynamicznie konwertowane z jednej formy na drugą.

## **Zmień czcionki motywu**

Schemat czcionek motywu zawiera zestaw głównych czcionek dla nagłówków oraz zestaw pomniejszych czcionek dla tekstu głównego. Metody [FontScheme::get_Major()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/fontscheme/get_major/) i [FontScheme::get_Minor()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/fontscheme/get_minor/) udostępniają te zestawy.

Identyfikatory czcionek zgodne z PowerPoint mogą być używane w formatowaniu tekstu:

* `+mn-lt` - Czcionka ciała Latin (Minor Latin Font)
* `+mj-lt` - Czcionka nagłówka Latin (Major Latin Font)
* `+mn-ea` - Czcionka ciała East Asian (Minor East Asian Font)
* `+mj-ea` - Czcionka nagłówka East Asian (Major East Asian Font)

Poniższy przykład tworzy jeden nagłówek używający głównej czcionki Latin oraz jedną linię tekstu używającą pomniejszej czcionki Latin. Następnie zmienia czcionki motywu i zapisuje wynik:

```cpp
#include <DOM/Fonts/FontData.h>
#include <DOM/IAutoShape.h>
#include <DOM/IFonts.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/Theme/IFontScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto heading = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 40.0f, 500.0f, 60.0f);
heading->get_TextFrame()->set_Text(u"Theme heading");
heading->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mj-lt"));

auto body = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 40.0f, 120.0f, 500.0f, 60.0f);
body->get_TextFrame()->set_Text(u"Theme body text");
body->get_TextFrame()->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->set_LatinFont(MakeObject<FontData>(u"+mn-lt"));

presentation->get_MasterTheme()->get_FontScheme()->get_Major()->set_LatinFont(MakeObject<FontData>(u"Aptos Display"));
presentation->get_MasterTheme()->get_FontScheme()->get_Minor()->set_LatinFont(MakeObject<FontData>(u"Arial"));
presentation->Save(u"theme-fonts.pptx", SaveFormat::Pptx);
```

Nagłówek podąża za czcionką główną, a tekst główny za czcionką pomniejszą. Tekst, który ma jawnie określoną nazwę czcionki zamiast identyfikatora motywu, nie zostanie automatycznie zmieniony po zmianie schematu czcionek motywu.

Zbiory czcionek głównych i pomniejszych mogą także zawierać mapowania czcionek dla poszczególnych systemów pisma, takich jak cyrylica, arabski, japoński, gruziński i thaana. Aby przeglądać, dodawać, zastępować lub usuwać te mapowania, zobacz [Script-Specific Theme Fonts](/slides/pl/cpp/script-specific-font-mappings/).

{{% alert color="info" title="Porada" %}}

Po więcej informacji o czcionkach w prezentacjach zobacz [PowerPoint Fonts](/slides/pl/cpp/powerpoint-fonts/).

{{% /alert %}}

## **Kopiuj lub zastosuj motyw**

Poniższe workflowy rozwiązują różne problemy związane z motywem.

### **Zastosuj zewnętrzny motyw do slajdów zależnych od mastera**

Użyj [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) gdy masz plik motywu PowerPoint (`.thmx`) i chcesz przeformatować każdy slajd zależny od określonego mastera. Wybierz master z kolekcji [Presentation::get_Masters](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_masters/), która implementuje [IMasterSlideCollection](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/), i przekaż ścieżkę do pliku motywu metodzie.

Metoda wykonuje następujące operacje:

1. Tworzy nowy master‑slide na podstawie wybranego mastera.
1. Zastosowuje zewnętrzny motyw do nowego mastera.
1. Przypisuje nowy master do wszystkich slajdów, które wcześniej zależały od wybranego mastera.
1. Zwraca nowo utworzony [IMasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/).

Poniższy przykład stosuje zewnętrzny motyw do slajdów zależnych od pierwszego mastera i zapisuje prezentację:

```cpp
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"presentation.pptx");
auto selectedMaster = presentation->get_Master(0);
auto themedMaster = selectedMaster->ApplyExternalThemeToDependingSlides(u"corporate-theme.thmx");

Console::WriteLine(u"Created master: {0}", themedMaster->get_Name());
presentation->Save(u"presentation-with-external-theme.pptx", SaveFormat::Pptx);
```

Nieprawidłowy, uszkodzony lub nieobsługiwany motyw może spowodować [PptxException](https://reference.aspose.com/slides/pl/cpp/aspose.slides/pptxexception/) lub jedną z jej podklas związanych z formatem. Waliduj ścieżki podawane przez użytkowników, obsługuj błędy dostępu do systemu plików i zapisuj prezentację dopiero po pomyślnym zastosowaniu motywu.

Jedynie slajdy, które zależały od wybranego mastera, są ponownie przypisane. Slajdy powiązane z innymi masterami zachowują istniejące mastery i motywy. Kolory, czcionki, wypełnienia, linie, tła i efekty świadome motywu są rozwiązywane względem zewnętrznego motywu. Bezpośrednio przydzielone kolory, czcionki, wypełnienia i inne explicite formatowanie mogą pozostać niezmienione. Nadpisania na poziomie układu i slajdu mogą również mieć pierwszeństwo przed wartościami dziedziczonymi z nowego mastera.

Motyw może odwoływać się do czcionek, które nie są dostępne w środowisku uruchomieniowym. Aby zapewnić spójne renderowanie i eksport, zainstaluj wymagane czcionki, udostępnij je przez [custom font sources](/slides/pl/cpp/custom-font/), lub skonfiguruj [font substitution](/slides/pl/cpp/font-substitution/).

Jest to bezpośredni workflow na poziomie mastera: metoda przyjmuje ścieżkę do pliku `.thmx` i nie wymaga ręcznego tworzenia nadpisań motywu na poziomie slajdu lub układu.

### **Zastosuj różne zewnętrzne motywy w prezentacji z wieloma masterami**

Gdy odpowiedni master nie jest znany z góry, pobierz go z reprezentatywnego slajdu za pomocą [ISlide::get_LayoutSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/get_layoutslide/) i [ILayoutSlide::get_MasterSlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ilayoutslide/get_masterslide/). Zachowaj oryginalne referencje masterów przed zastosowaniem jakichkolwiek motywów, ponieważ każde wywołanie tworzy kolejny master w prezentacji.

Poniższy przykład używa slajdów z dwóch sekcji, aby zlokalizować ich mastery i stosuje różny zewnętrzny motyw do każdej grupy:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <iostream>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"multi-master-presentation.pptx");

if (presentation->get_Slides()->get_Count() < 5)
{
    std::cout << "The presentation does not contain the expected representative slides." << std::endl;
}
else
{
    auto firstGroupMaster = presentation->get_Slide(0)->get_LayoutSlide()->get_MasterSlide();
    auto secondGroupMaster = presentation->get_Slide(4)->get_LayoutSlide()->get_MasterSlide();

    if (firstGroupMaster->get_SlideId() == secondGroupMaster->get_SlideId())
    {
        std::cout << "The representative slides use the same master." << std::endl;
    }
    else
    {
        auto firstThemedMaster = firstGroupMaster->ApplyExternalThemeToDependingSlides(u"blue-theme.thmx");
        auto secondThemedMaster = secondGroupMaster->ApplyExternalThemeToDependingSlides(u"green-theme.thmx");

        Console::WriteLine(u"First themed master: {0}", firstThemedMaster->get_Name());
        Console::WriteLine(u"Second themed master: {0}", secondThemedMaster->get_Name());
        presentation->Save(u"multi-master-with-external-themes.pptx", SaveFormat::Pptx);
    }
}
```

Pierwsze wywołanie wpływa tylko na slajdy zależne od `firstGroupMaster`, a drugie wywołanie wpływa tylko na slajdy zależne od `secondGroupMaster`. Slajdy należące do innych masterów nie są przestylizowane.

### **Zachowaj źródłowy motyw przy przenoszeniu slajdów**

Jeśli chcesz przenieść slajd do innej prezentacji i zachować jego pierwotny projekt, sklonuj źródłowy master do docelowej prezentacji za pomocą [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/addclone/), a następnie sklonuj slajd wraz ze sklonowanym masterem przy użyciu [ISlideCollection::AddClone()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/). To przenosi master, jego układy oraz powiązany motyw razem.

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IMasterSlideCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto sourceSlide = source->get_Slide(0);
auto sourceMaster = sourceSlide->get_LayoutSlide()->get_MasterSlide();
auto clonedMaster = target->get_Masters()->AddClone(sourceMaster);
target->get_Slides()->AddClone(sourceSlide, clonedMaster, true);
target->Save(u"theme-preserved.pptx", SaveFormat::Pptx);
```

Jest to preferowany workflow, gdy źródłowy slajd musi wyglądać identycznie w miejscu docelowym. Proste klonowanie zawartości na niepowiązany master docelowy może zmienić kolory, czcionki, tła i efekty sterowane motywem.

### **Zastosuj wartości motywu do istniejącego slajdu**

Jeśli docelowy slajd musi pozostać na bieżącym masterze i układzie, zainicjuj nadpisanie na poziomie slajdu z motywu źródłowego. Metody [OverrideTheme::InitColorSchemeFrom()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/overridetheme/initcolorschemefrom/), [OverrideTheme::InitFontSchemeFrom()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/overridetheme/initfontschemefrom/) i [OverrideTheme::InitFormatSchemeFrom()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/overridetheme/initformatschemefrom/) kopiują trzy główne komponenty motywu do nadpisania.

```cpp
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto overrideTheme = targetSlide->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-slide.pptx", SaveFormat::Pptx);
```

To zmienia motyw używany przez ten slajd bez zmiany motywu dziedziczonego przez inne slajdy. Aby usunąć lokalne nadpisanie i powrócić do wartości dziedziczonych, wywołaj [OverrideTheme::Clear()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/overridetheme/clear/).

### **Zastosuj nadpisanie motywu do układu**

Nadpisanie na poziomie układu ma zastosowanie do slajdów używających tego układu, o ile dany slajd nie ma własnego nadpisania. Te same metody inicjalizacji można użyć poprzez [IOverrideThemeManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ioverridethememanager/) układu:

```cpp
#include <DOM/ILayoutSlide.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IOverrideTheme.h>
#include <DOM/Theme/IOverrideThemeManager.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto source = MakeObject<Presentation>(u"source-theme.pptx");
auto target = MakeObject<Presentation>(u"target.pptx");
auto targetSlide = target->get_Slide(0);
auto targetLayout = targetSlide->get_LayoutSlide();
auto overrideTheme = targetLayout->get_ThemeManager()->get_OverrideTheme();
overrideTheme->InitColorSchemeFrom(source->get_MasterTheme()->get_ColorScheme());
overrideTheme->InitFontSchemeFrom(source->get_MasterTheme()->get_FontScheme());
overrideTheme->InitFormatSchemeFrom(source->get_MasterTheme()->get_FormatScheme());
target->Save(u"theme-applied-to-layout.pptx", SaveFormat::Pptx);
```

Użyj motywu mastera lub prezentacji, gdy wiele układów i slajdów ma współdzielić tę samą bazową koncepcję, nadpisania układu, gdy jedna rodzina układów potrzebuje innego stylu, oraz nadpisania slajdu wyłącznie dla prawdziwych wyjątków. Nadmierne nadpisania na poziomie slajdu utrudniają przewidywanie późniejszych globalnych zmian motywu.

## **Aktualizuj style tła motywu**

Wypełnienia tła motywu są przechowywane w [FormatScheme::get_BackgroundFillStyles()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/formatscheme/get_backgroundfillstyles/). PowerPoint może prezentować w interfejsie więcej opcji tła niż liczba definicji wypełnień fizycznie przechowywanych w tej kolekcji, ponieważ UI może łączyć wypełnienia motywu z kolorami motywu i innymi odwołaniami stylów.

![PowerPoint background style gallery for a presentation theme](presentation-design_8.png)

Zanim użyjesz stylu tła, przeglądnij przechowywaną kolekcję oraz bieżącą wartość [Background::get_StyleIndex()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/background/get_styleindex/). `StyleIndex` używa `0` dla braku tematycznego wypełnienia; wartości dodatnie są odwołaniami do stylów tła motywu. Jest to inne niż indeksowanie kolekcji C++ bezpośrednio przez `idx_get(0)`, gdzie `0` oznacza pierwszy zapisany element. Nie zakładaj, że każda prezentacja zawiera tę samą liczbę stylów wypełnień tła.

Poniższy przykład podaje liczbę dostępnych wypełnień tła, przypisuje odwołanie tematycznego tła do pierwszego mastera i zapisuje prezentację:

```cpp
#include <DOM/BackgroundType.h>
#include <DOM/IBackground.h>
#include <DOM/IMasterSlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto backgroundStyles = presentation->get_MasterTheme()->get_FormatScheme()->get_BackgroundFillStyles();
Console::WriteLine(u"Background fill styles: {0}", backgroundStyles->get_Count());

if (backgroundStyles->get_Count() > 0)
{
    auto masterSlide = presentation->get_Master(0);
    masterSlide->get_Background()->set_Type(BackgroundType::Themed);
    masterSlide->get_Background()->set_StyleIndex(1);
    presentation->Save(u"theme-background.pptx", SaveFormat::Pptx);
}
```

Widoczny rezultat zależy od wpisu motywu, do którego odnosi się master, oraz od wszelkich nadpisań tła na poziomie układu lub slajdu. Jeśli slajd używa własnego tła, zmiana samego tła mastera może nie zmieni tego slajdu. Użyj [Background::GetEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/background/geteffective/) gdy potrzebujesz znać ostateczne tło po zastosowaniu dziedziczenia.

{{% alert color="warning" title="Ostrzeżenie" %}}

Nie traktuj `StyleIndex` jako indeks kolekcji zerobazowy. Unikaj także twardego kodowania numeru stylu z jednego pliku i zakładania, że będzie miał taki sam wygląd w innym pliku; definicje stylów motywu są specyficzne dla prezentacji.

{{% /alert %}}

{{% alert color="info" title="Porada" %}}

W przypadku bezpośredniego formatowania tła i dziedziczenia tła zobacz [Presentation Background](/slides/pl/cpp/presentation-background/).

{{% /alert %}}

## **Aktualizuj efekty motywu**

Schemat formatu motywu zawiera oddzielne kolekcje [FormatScheme::get_FillStyles()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/formatscheme/get_fillstyles/), [FormatScheme::get_LineStyles()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/formatscheme/get_linestyles/) i [FormatScheme::get_EffectStyles()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/formatscheme/get_effectstyles/). Typowe motywy Office często zawierają trzy główne wpisy stylów, które wizualnie odpowiadają subtelnemu, umiarkowanemu i intensywnemu formatowaniu, ale kod powinien przeglądać każdą kolekcję zamiast zakładać stałą liczbę elementów.

![Subtle, moderate, and intense theme effects applied to the same shape](presentation-design_10.png)

Podczas dostępu do tych kolekcji w C++ indeks kolekcji jest zerobazowy: `idx_get(0)` jest pierwszym zapisanym stylem, a `idx_get(2)` trzecim. Indeksy odwołań stylu kształtu to odrębna koncepcja, udostępniona przez [IShapeStyle](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishapestyle/). Modyfikacja stylu motywu wpływa na kształty odwołujące się do tego stylu; kształty z bezpośrednim formatowaniem mogą pozostać niezmienione.

Poniższy przykład sprawdza, czy wymagane wpisy stylów istnieją, zmienia pierwszy styl linii, zmienia trzeci styl wypełnienia, włącza zewnętrzny cień w trzecim stylu efektu i zapisuje wynik:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/FillType.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IEffectStyle.h>
#include <DOM/Theme/IEffectStyleCollection.h>
#include <DOM/Theme/IFillFormatCollection.h>
#include <DOM/Theme/IFormatScheme.h>
#include <DOM/Theme/ILineFormatCollection.h>
#include <DOM/Theme/IMasterTheme.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

auto presentation = MakeObject<Presentation>(u"Subtle_Moderate_Intense.pptx");
auto formatScheme = presentation->get_MasterTheme()->get_FormatScheme();
auto lineStyles = formatScheme->get_LineStyles();
auto fillStyles = formatScheme->get_FillStyles();
auto effectStyles = formatScheme->get_EffectStyles();

if (lineStyles->get_Count() < 1 || fillStyles->get_Count() < 3 || effectStyles->get_Count() < 3)
{
    Console::WriteLine(u"The theme does not contain the style entries required by this example.");
}
else
{
    auto lineStyle = lineStyles->idx_get(0);
    lineStyle->get_FillFormat()->set_FillType(FillType::Solid);
    lineStyle->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Red());

    auto fillStyle = fillStyles->idx_get(2);
    fillStyle->set_FillType(FillType::Solid);
    fillStyle->get_SolidFillColor()->set_Color(Color::get_ForestGreen());

    auto effectFormat = effectStyles->idx_get(2)->get_EffectFormat();
    effectFormat->EnableOuterShadowEffect();
    effectFormat->get_OuterShadowEffect()->set_Distance(10.0f);

    presentation->Save(u"theme-effects.pptx", SaveFormat::Pptx);
}
```

Dla kształtów odwołujących się do tych slotów, pierwszy styl linii motywu staje się czerwony, trzeci styl wypełnienia motywu staje się jednolitym leśnym zielonym, a trzeci styl efektu zyskuje zewnętrzny cień o odległości 10 punktów. Dokładny wygląd nadal zależy od tego, które sloty stylów są odwoływane przez poszczególne kształty oraz czy bezpośrednie formatowanie nadpisuje motyw.

![Theme effect styles after changing line, fill, and shadow settings](presentation-design_11.png)

## **Odczytaj skuteczne wartości motywu**

Surowe obiekty motywu informują, co jest zdefiniowane na danym poziomie. Skuteczne wartości mówią, co slajd lub kształt faktycznie używa po rozstrzygnięciu dziedziczenia i lokalnych nadpisań. Dla slajdu wywołaj [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/). Dla tła użyj [Background::GetEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/background/geteffective/), a dla wypełnienia [FillFormat::GetEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/geteffective/).

Poniższy przykład odczytuje skuteczny motyw, tło oraz pierwsze wypełnienie kształtu ze slajdu:

```cpp
#include <DOM/FillType.h>
#include <DOM/IBackground.h>
#include <DOM/IBackgroundEffectiveData.h>
#include <DOM/IFillFormat.h>
#include <DOM/IFillFormatEffectiveData.h>
#include <DOM/IFontsEffectiveData.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/Theme/IFontSchemeEffectiveData.h>
#include <DOM/Theme/IThemeEffectiveData.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"input.pptx");
auto slide = presentation->get_Slide(0);
auto effectiveTheme = slide->CreateThemeEffective();
auto effectiveBackground = slide->get_Background()->GetEffective();

Console::WriteLine(u"Effective major Latin font: {0}", effectiveTheme->get_FontScheme()->get_Major()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective minor Latin font: {0}", effectiveTheme->get_FontScheme()->get_Minor()->get_LatinFont()->get_FontName());
Console::WriteLine(u"Effective background fill type: {0}", effectiveBackground->get_FillFormat()->get_FillType());

if (slide->get_Shapes()->get_Count() > 0)
{
    auto effectiveFill = slide->get_Shape(0)->get_FillFormat()->GetEffective();
    Console::WriteLine(u"First shape effective fill type: {0}", effectiveFill->get_FillType());
    if (effectiveFill->get_FillType() == FillType::Solid)
    {
        Console::WriteLine(u"First shape effective fill color: {0}", effectiveFill->get_SolidFillColor());
    }
}
```

Używaj danych skutecznych do diagnostyki renderowania, walidacji i porównań. Jeśli przeglądasz wyłącznie [Presentation::get_MasterTheme()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/get_mastertheme/), możesz przegapić nadpisania mastera, układu, slajdu lub kształtu, które zmieniają ostateczny wygląd.

## **FAQ**

**Czy zastosowanie zewnętrznego motywu wpływa na każdy slajd w prezentacji?**

Nie. [IMasterSlide::ApplyExternalThemeToDependingSlides](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslide/applyexternalthemetodependingslides/) przypisuje tylko slajdy, które zależą od wybranego mastera. Slajdy używające innych masterów zachowują istniejące motywy.

**Czy mogę zastosować motyw do jednego slajdu bez zmiany mastera?**

Tak. Użyj [IOverrideThemeManager](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ioverridethememanager/) slajdu i zainicjuj jego nadpisanie motywu. Zmiana pozostaje lokalna dla tego slajdu; inne slajdy nadal dziedziczą swoje istniejące motywy.

**Jaki jest najbezpieczniejszy sposób przeniesienia motywu z jednej prezentacji do drugiej?**

Podczas przenoszenia slajdu i zachowania jego pierwotnego wyglądu, sklonuj źródłowy master do docelowej prezentacji i sklonuj slajd z tym masterem, używając [IMasterSlideCollection::AddClone()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/imasterslidecollection/addclone/) oraz [ISlideCollection::AddClone()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islidecollection/addclone/). To utrzymuje master, układy i motyw razem.

**Jak mogę zobaczyć skuteczne wartości po dziedziczeniu i nadpisaniach?**

Użyj [IThemeable::CreateThemeEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.theme/ithemeable/createthemeeffective/) dla motywu slajdu lub układu oraz odpowiednich metod danych skutecznych dla obiektów formatowania, takich jak [Background::GetEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/background/geteffective/) i [FillFormat::GetEffective()](https://reference.aspose.com/slides/pl/cpp/aspose.slides/fillformat/geteffective/). Te API zwracają rozstrzygnięte wartości po zastosowaniu dziedziczenia i nadpisań.