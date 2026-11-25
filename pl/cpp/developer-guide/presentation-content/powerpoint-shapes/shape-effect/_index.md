---
title: Zastosowanie efektów kształtów w prezentacjach przy użyciu C++
linktitle: Efekt kształtu
type: docs
weight: 30
url: /pl/cpp/shape-effect/
keywords:
- efekt kształtu
- efekt cienia
- efekt odbicia
- efekt poświaty
- efekt miękkich krawędzi
- format efektu
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Transformuj swoje pliki PPT i PPTX za pomocą zaawansowanych efektów kształtów przy użyciu Aspose.Slides dla C++ — twórz efektowne, profesjonalne slajdy w kilka sekund."
---
## **Wprowadzenie**

Podczas gdy efekty w PowerPoint mogą być używane, aby wyróżnić kształt, różnią się od [wypełnień](/slides/pl/cpp/shape-formatting/#gradient-fill) lub konturów. Korzystając z efektów PowerPoint, możesz tworzyć przekonujące odbicia kształtu, rozpraszać poświatę kształtu itp.

![Shape effect](shape-effect.png)

PowerPoint udostępnia sześć efektów, które można zastosować do kształtów. Możesz zastosować jeden lub więcej efektów do kształtu.

Niektóre kombinacje efektów wyglądają lepiej niż inne. Z tego powodu PowerPoint ma opcje w sekcji **Preset**. Opcje Preset to zasadniczo kombinacja dwóch lub więcej efektów, które razem wyglądają dobrze. Dzięki temu, wybierając preset, nie musisz tracić czasu na testowanie lub łączenie różnych efektów w poszukiwaniu udanej kombinacji.

Aspose.Slides udostępnia właściwości i metody w klasie [EffectFormat](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/), które pozwalają zastosować te same efekty do kształtów w prezentacjach PowerPoint.

## **Zastosowanie efektu cienia**

Aspose.Slides dla C++ obsługuje cienie zewnętrzne i wewnętrzne dla kształtów. Możesz dostosować ich kolor, kierunek, odległość oraz promień rozmycia, aby pasowały do projektu prezentacji.

### **Zastosowanie cienia zewnętrznego**

Użyj cienia zewnętrznego, aby karta lub panel wyróżniały się na tle slajdu. Cień wykracza poza krawędzie kształtu, tworząc wrażenie, że kształt jest podniesiony nad slajdem. Dostosuj jego kolor, kierunek, odległość i promień rozmycia, aby pasowały do oświetlenia i stylu szablonu.

Ten kod C++ pokazuje, jak zastosować [efekt cienia zewnętrznego](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_outershadoweffect/) do prostokąta:

```cpp
#include <DOM/Effects/IOuterShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();
auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_DarkGray());
outerShadowEffect->set_Distance(10);
outerShadowEffect->set_Direction(45.0f);

presentation->Save(u"shadow_effect.pptx", SaveFormat::Pptx);
```

![Shadow effect](shadow_effect.png)

### **Zastosowanie cienia wewnętrznego**

Podczas odtwarzania wizualnego stylu szablonu użyj cienia wewnętrznego, aby nadać karcie lub panelowi wklęsły wygląd. Cień zewnętrzny rozciąga się poza kształt i sprawia, że wydaje się podniesiony, natomiast cień wewnętrzny przyciemnia wnętrze jego krawędzi.

Wywołaj [EnableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/enableinnershadoweffect/), a następnie skonfiguruj [InnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_innershadoweffect/). Większe wartości promienia rozmycia dają miększe krawędzie.

Ten przykład C++ tworzy jasno niebieską kartę z ciemnoszarym cieniem wewnętrznym i zapisuje ją jako plik PPTX:

```cpp
#include <DOM/Effects/IInnerShadow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 20.0f, 20.0f, 200.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_LightBlue());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);

shape->get_EffectFormat()->EnableInnerShadowEffect();
auto shadow = shape->get_EffectFormat()->get_InnerShadowEffect();
shadow->get_ShadowColor()->set_Color(Color::get_DimGray());
shadow->set_Direction(225);
shadow->set_Distance(7);
shadow->set_BlurRadius(6);

presentation->Save(u"inner_shadow_effect.pptx", SaveFormat::Pptx);
```

![Light blue rectangle with an inner shadow](inner_shadow_effect.png)

Aby usunąć cień wewnętrzny, wywołaj [DisableInnerShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/disableinnershadoweffect/) na formacie efektu kształtu.

### **Zastosowanie, zmiana i usunięcie cienia predefiniowanego**

Wywołaj [EnablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/enablepresetshadoweffect/) i użyj [set_Preset](https://reference.aspose.com/slides/cpp/aspose.slides.effects/ipresetshadow/set_preset/), aby wybrać [PresetShadowType](https://reference.aspose.com/slides/cpp/aspose.slides/presetshadowtype/). Aby zmienić styl, zmień preset na tym samym kształcie. Wywołaj [DisablePresetShadowEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disablepresetshadoweffect/), aby usunąć cień, zachowując wypełnienie i kontur.

Ten przykład zachowuje kopię prostokąta na każdym etapie. Oba cienie są przesunięte o 10 punktów. Kierunek 225° umieszcza pierwszy cień powyżej i po lewej stronie prostokąta, a 45° drugi poniżej i po prawej stronie.

```cpp
#include <DOM/Effects/IPresetShadow.h>
#include <DOM/FillType.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphFormat.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideSize.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/PresetShadowType.h>
#include <DOM/ShapeType.h>
#include <DOM/SlideSizeScaleType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/enum.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
presentation->get_SlideSize()->SetSize(800, 120, SlideSizeScaleType::DoNotScale);
auto shapes = presentation->get_Slide(0)->get_Shapes();

auto shape = shapes->AddAutoShape(ShapeType::Rectangle, 15, 30, 170, 60);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_SteelBlue());
auto outline = shape->get_LineFormat()->get_FillFormat();
outline->set_FillType(FillType::Solid);
outline->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
auto textFrame = shape->get_TextFrame();
textFrame->set_Text(u"No shadow");
textFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->set_FontHeight(14);
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnablePresetShadowEffect();
auto shadow = effectFormat->get_PresetShadowEffect();
shadow->set_Preset(PresetShadowType::TopLeftDropShadow);
shadow->set_Distance(10);
shadow->set_Direction(225);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
shadow->set_Preset(PresetShadowType::BottomRightDropShadow);
shadow->set_Direction(45);
textFrame->set_Text(System::Enum<PresetShadowType>::GetName(shadow->get_Preset()));
shapes->AddClone(shape);

shape->set_X(shape->get_X() + 200);
effectFormat->DisablePresetShadowEffect();
textFrame->set_Text(u"No shadow");

presentation->Save(u"preset_shadows.pptx", SaveFormat::Pptx);
```

| Oryginalny | Pierwszy preset | Drugi preset | Po usunięciu |
| :---: | :---: | :---: | :---: |
| ![Brak cienia](preset_shadow_original.png) | ![Cień w lewym górnym rogu](preset_shadow_top_left.png) | ![Cień w prawym dolnym rogu](preset_shadow_bottom_right.png) | ![Brak cienia po usunięciu](preset_shadow_removed.png) |

## **Zastosowanie efektu odbicia**

Aby zastosować efekt odbicia w Aspose.Slides dla C++, możesz dodać lustrzane odbicie do kształtów, dostosowując parametry takie jak odległość, przezroczystość i rozmiar. Efekt ten podnosi estetykę prezentacji, nadając kształtom bardziej wyrafinowany i dopracowany wygląd. Jest łatwy do wdrożenia przy użyciu prostego kodu, umożliwiając szybkie zastosowanie na wielu elementach dla spójnego projektu.

Ten kod C++ pokazuje, jak zastosować [efekt odbicia](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_reflectioneffect/) do kształtu:

```cpp
#include <DOM/Effects/IReflection.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/RectangleAlignment.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableReflectionEffect();
auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_RectangleAlign(RectangleAlignment::Bottom);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_Distance(40);
reflectionEffect->set_BlurRadius(2);

presentation->Save(u"reflection_effect.pptx", SaveFormat::Pptx);
```

![Reflection effect](reflection_effect.png)

## **Zastosowanie efektu poświaty**

Aby zastosować efekt poświaty do kształtu w Aspose.Slides dla C++, możesz dodać miękką, luminescencyjną aurę wokół kształtów, regulując właściwości takie jak kolor i rozmiar. Efekt ten pomaga wyróżnić kształty i dodaje atrakcyjny, przyciągający uwagę element wizualny do prezentacji. Jest łatwy do wdrożenia przy minimalnym kodzie, podnosząc ogólny wygląd slajdów.

Ten kod C++ pokazuje, jak zastosować [efekt poświaty](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_gloweffect/) do kształtu:

```cpp
#include <DOM/Effects/IGlow.h>
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 100.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableGlowEffect();
auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_Color(Color::get_Magenta());
glowEffect->set_Radius(15);

presentation->Save(u"glow_effect.pptx", SaveFormat::Pptx);
```

![Glow effect](glow_effect.png)

## **Zastosowanie efektu miękkich krawędzi**

Aby zastosować efekt miękkich krawędzi w Aspose.Slides dla C++, możesz stworzyć płynne, rozmyte przejście wokół krawędzi kształtu. Efekt ten dodaje subtelny i wyrafinowany wygląd, idealny dla projektów wymagających łagodnego, delikatnego wyglądu. Możesz łatwo regulować parametry, takie jak promień, aby uzyskać pożądany efekt na różnych kształtach w prezentacji.

Ten kod C++ pokazuje, jak zastosować [miękkie krawędzie](https://reference.aspose.com/slides/cpp/aspose.slides/effectformat/get_softedgeeffect/) do kształtu:

```cpp
#include <DOM/Effects/ISoftEdge.h>
#include <DOM/IAutoShape.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::RoundCornerRectangle, 20.0f, 20.0f, 200.0f, 150.0f);
auto effectFormat = shape->get_EffectFormat();
effectFormat->EnableSoftEdgeEffect();
auto softEdgeEffect = effectFormat->get_SoftEdgeEffect();
softEdgeEffect->set_Radius(8);

presentation->Save(u"soft_edges_effect.pptx", SaveFormat::Pptx);
```

![Soft edges effect](soft_edges_effect.png)

## **Zastosowanie efektu rozmycia**

Użyj rozmycia kształtu, aby zmiękczyć wypełnienie i kontur kształtu, zachowując jednocześnie możliwość edycji kształtu. Wywołaj [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/) na formacie efektu kształtu. Promień jest mierzony w punktach (1/72 cala): użyj wartości nieujemnej, przy czym większe wartości powodują silniejsze rozmycie. Promień równy zero pozostawia wygląd niezmieniony.

Ustawienie [Grow](https://reference.aspose.com/slides/cpp/aspose.slides.effects/iblur/get_grow/) kontroluje widoczne granice efektu. Przy `false` rozmycie jest przycięte do pierwotnych malowanych granic, łącznie z konturem. Przy `true` rozmycie może wykraczać poza te granice. Żadne z ustawień nie zmienia położenia ani wymiarów kształtu.

Poniższe porównanie używa tego samego wypełnienia, konturu i wymiarów kształtu w całym przykładzie. Górny wiersz używa `grow = false`; dolny wiersz używa `grow = true`.

![Original rectangle compared with blur radii of 5 and 15 points, with grow disabled and enabled](shape_blur_comparison.png)

Ten przykład C++ tworzy pomarańczowy prostokąt z ciemnoniebieskim konturem, stosuje rozmycie o promieniu 5 punktów, a następnie aktualizuje je do rozmycia o 15 punktów, ponownie wywołując [SetBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/setblureffect/). Zapisuje oba stany rozmycia, a potem wywołuje [DisableBlurEffect](https://reference.aspose.com/slides/cpp/aspose.slides/ieffectformat/disableblureffect/) i zapisuje kształt bez rozmycia.

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IColorFormat.h>
#include <DOM/IEffectFormat.h>
#include <DOM/IFillFormat.h>
#include <DOM/ILineFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <DOM/FillType.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System::Drawing;

auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 80.0f, 160.0f, 100.0f);
shape->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Orange());
shape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::Solid);
shape->get_LineFormat()->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_DarkBlue());
shape->get_LineFormat()->set_Width(8);

shape->get_EffectFormat()->SetBlurEffect(5, false);
presentation->Save(u"shape_blur_5.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->SetBlurEffect(15, true);
presentation->Save(u"shape_blur_15.pptx", SaveFormat::Pptx);

shape->get_EffectFormat()->DisableBlurEffect();
presentation->Save(u"shape_blur_removed.pptx", SaveFormat::Pptx);
```

Rozmycie kształtu wpływa jednocześnie na wypełnienie i kontur. Efekt miękkich krawędzi rozmywa krawędzie kształtu, podczas gdy rozmycie cienia zmiękcza tylko cień. Efekty transformacji obrazu działają na zawartość obrazu; ten przykład stosuje rozmycie bezpośrednio na formacie efektu kształtu, bez konwersji kształtu na obraz.

## **FAQ**

**Czy mogę zastosować wiele efektów do tego samego kształtu?**

Tak, możesz łączyć różne efekty, takie jak cień, odbicie i poświata, na jednym kształcie, aby uzyskać bardziej dynamiczny wygląd.

**Do jakich kształtów mogę zastosować efekty?**

Możesz stosować efekty do różnych kształtów, w tym autokształtów, wykresów, tabel, obrazów, obiektów SmartArt, obiektów OLE i innych.

**Czy mogę stosować efekty do grupowanych kształtów?**

Tak, możesz stosować efekty do grupowanych kształtów. Efekt zostanie zastosowany do całej grupy.