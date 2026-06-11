---
title: Tworzenie i stosowanie efektów WordArt w C++
linktitle: WordArt
type: docs
weight: 110
url: /pl/cpp/wordart/
keywords:
- WordArt
- tworzenie WordArt
- szablon WordArt
- efekt WordArt
- efekt cienia
- efekt wyświetlania
- efekt poświaty
- przekształcenie WordArt
- efekt 3D
- efekt zewnętrznego cienia
- efekt wewnętrznego cienia
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Tworzenie i dostosowywanie efektów WordArt w Aspose.Slides dla C++. Ten szczegółowy przewodnik pomaga programistom ulepszyć prezentacje profesjonalnym tekstem w C++."
---
## **Przegląd**

Efekty WordArt pozwalają dodawać wizualnie atrakcyjny, stylizowany tekst do prezentacji PowerPoint. Dzięki Aspose.Slides programiści mogą programowo tworzyć, dostosowywać i zarządzać WordArt tak jak w Microsoft PowerPoint — bez konieczności instalacji Office. Ten artykuł przedstawia przegląd pracy z WordArt, w tym jak stosować przekształcenia tekstu, style wypełnienia, kontury, cienie i inne opcje formatowania, aby treść prezentacji była bardziej ekspresyjna i angażująca. WordArt pozwala traktować tekst jako obiekt graficzny. Składa się z efektów lub specjalnych modyfikacji stosowanych do tekstu, aby uczynić go bardziej atrakcyjnym lub zauważalnym.

## **Utwórz prosty szablon WordArt i zastosuj go do tekstu**

**Używanie Aspose.Slides**

Najpierw tworzymy prosty tekst przy użyciu tego kodu C++:

``` cpp 
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 200.0f, 200.0f, 400.0f, 200.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
portion->set_Text(u"Aspose.Slides");
```

Teraz ustawiamy wysokość czcionki tekstu na większą wartość, aby efekt był bardziej zauważalny, przy użyciu tego kodu:

``` cpp 
auto fontData = System::MakeObject<FontData>(u"Arial Black");
portion->get_PortionFormat()->set_LatinFont(fontData);
portion->get_PortionFormat()->set_FontHeight(36.0f);
```

**Używanie Microsoft PowerPoint**

Przejdź do menu efektów WordArt w Microsoft PowerPoint:

![todo:image_alt_text](image-20200930113926-1.png)

Z menu po prawej możesz wybrać predefiniowany efekt WordArt. Z menu po lewej możesz określić ustawienia nowego WordArt.

Oto niektóre dostępne parametry lub opcje:

![todo:image_alt_text](image-20200930114015-3.png)

**Używanie Aspose.Slides**

Tutaj stosujemy kolor wzoru SmallGrid do tekstu i dodajemy czarną obwódkę o szerokości 1 przy użyciu tego kodu:

``` cpp 
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Pattern);
fillFormat->get_PatternFormat()->get_ForeColor()->set_Color(Color::get_DarkOrange());
fillFormat->get_PatternFormat()->get_BackColor()->set_Color(Color::get_White());
fillFormat->get_PatternFormat()->set_PatternStyle(PatternStyle::SmallGrid);

auto lineFillFormat = portion->get_PortionFormat()->get_LineFormat()->get_FillFormat();
lineFillFormat->set_FillType(FillType::Solid);
lineFillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
```

Wynikowy tekst:

![todo:image_alt_text](image-20200930114108-4.png)

## **Zastosuj inne efekty WordArt**

**Używanie Microsoft PowerPoint**

Z interfejsu programu możesz zastosować te efekty do tekstu, bloku tekstowego, kształtu lub podobnego elementu:

![todo:image_alt_text](image-20200930114129-5.png)

Na przykład efekty Cień, Odbicie i Poświata można zastosować do tekstu; efekty Format 3D i Obrót 3D można zastosować do bloku tekstowego; właściwość Miękkie krawędzie można zastosować do obiektu Shape (działa również gdy nie ustawiono właściwości Format 3D).

### **Zastosuj efekty cienia do tekstu**

Tutaj zamierzamy ustawić właściwości dotyczące wyłącznie tekstu. Stosujemy efekt cienia do tekstu przy użyciu tego kodu w C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableOuterShadowEffect();

auto outerShadowEffect = effectFormat->get_OuterShadowEffect();
outerShadowEffect->get_ShadowColor()->set_Color(Color::get_Black());
outerShadowEffect->set_ScaleHorizontal(100);
outerShadowEffect->set_ScaleVertical(65);
outerShadowEffect->set_BlurRadius(4.73);
outerShadowEffect->set_Direction(230.0f);
outerShadowEffect->set_Distance(2);
outerShadowEffect->set_SkewHorizontal(30);
outerShadowEffect->set_SkewVertical(0);
outerShadowEffect->get_ShadowColor()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.32f);
```

API Aspose.Slides obsługuje trzy typy cieni: OuterShadow, InnerShadow i PresetShadow.  
Za pomocą PresetShadow możesz zastosować cień do tekstu (korzystając z wartości wstępnie ustawionych).

**Używanie Microsoft PowerPoint**

W PowerPoint możesz używać jednego typu cienia. Oto przykład:

![todo:image_alt_text](image-20200930114225-6.png)

**Używanie Aspose.Slides**

Aspose.Slides faktycznie pozwala zastosować dwa typy cieni jednocześnie: InnerShadow i PresetShadow.

**Uwaga:**

- Gdy OuterShadow i PresetShadow są używane razem, stosowany jest tylko efekt OuterShadow.  
- Jeśli OuterShadow i InnerShadow są używane jednocześnie, wynikowy lub zastosowany efekt zależy od wersji PowerPoint. Na przykład w PowerPoint 2013 efekt zostaje podwojony, a w PowerPoint 2007 stosowany jest efekt OuterShadow.

### **Zastosuj efekty odbicia**

Dodajemy odbicie do tekstu za pomocą tego przykładu kodu w C++:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableReflectionEffect();

auto reflectionEffect = effectFormat->get_ReflectionEffect();
reflectionEffect->set_BlurRadius(0.5);
reflectionEffect->set_Distance(4.72);
reflectionEffect->set_StartPosAlpha(0.f);
reflectionEffect->set_EndPosAlpha(60.f);
reflectionEffect->set_Direction(90.0f);
reflectionEffect->set_ScaleHorizontal(100);
reflectionEffect->set_ScaleVertical(-100);
reflectionEffect->set_StartReflectionOpacity(60.f);
reflectionEffect->set_EndReflectionOpacity(0.9f);
reflectionEffect->set_RectangleAlign(RectangleAlignment::BottomLeft);
```

### **Zastosuj efekty poświaty**

Stosujemy efekt poświaty do tekstu, aby go rozświetlić lub wyróżnić, używając tego kodu:

``` cpp 
auto effectFormat = portion->get_PortionFormat()->get_EffectFormat();
effectFormat->EnableGlowEffect();

auto glowEffect = effectFormat->get_GlowEffect();
glowEffect->get_Color()->set_R(255);
glowEffect->get_Color()->get_ColorTransform()->Add(ColorTransformOperation::SetAlpha, 0.54f);
glowEffect->set_Radius(7);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 
Możesz zmienić parametry cienia, wyświetlania i poświaty. Właściwości efektów są ustawiane osobno dla każdej części tekstu. 
{{% /alert %}} 

### **Użyj przekształceń w WordArt**

Używamy metody set_Transform (obowiązującej dla całego bloku tekstu) przy użyciu tego kodu:

``` cpp 
textFrame->get_TextFrameFormat()->set_Transform(TextShapeType::ArchUpPour);
```

Wynik:

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} 
Zarówno Microsoft PowerPoint, jak i Aspose.Slides dla C++ udostępniają pewną liczbę predefiniowanych typów przekształceń. 
{{% /alert %}} 

**Używanie PowerPoint**

Aby uzyskać dostęp do predefiniowanych typów przekształceń, przejdź przez: **Format** -> **TextEffect** -> **Transform**

**Używanie Aspose.Slides**

Aby wybrać typ przekształcenia, użyj wyliczenia TextShapeType.

### **Zastosuj efekty 3D do tekstu i kształtów**

Ustawiamy efekt 3D dla kształtu tekstowego przy użyciu tego przykładowego kodu:

``` cpp 
auto threeDFormat = autoShape->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(10.5);
threeDFormat->get_BevelBottom()->set_Width(10.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(12.5);
threeDFormat->get_BevelTop()->set_Width(11);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Wynikowy tekst i jego kształt:

![todo:image_alt_text](image-20200930114816-9.png)

Stosujemy efekt 3D do tekstu przy użyciu tego kodu C++:

``` cpp 
auto threeDFormat = textFrame->get_TextFrameFormat()->get_ThreeDFormat();

threeDFormat->get_BevelBottom()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelBottom()->set_Height(3.5);
threeDFormat->get_BevelBottom()->set_Width(3.5);

threeDFormat->get_BevelTop()->set_BevelType(BevelPresetType::Circle);
threeDFormat->get_BevelTop()->set_Height(4);
threeDFormat->get_BevelTop()->set_Width(4);

threeDFormat->get_ExtrusionColor()->set_Color(Color::get_Orange());
threeDFormat->set_ExtrusionHeight(6);

threeDFormat->get_ContourColor()->set_Color(Color::get_DarkRed());
threeDFormat->set_ContourWidth(1.5);

threeDFormat->set_Depth(3);

threeDFormat->set_Material(MaterialPresetType::Plastic);

threeDFormat->get_LightRig()->set_Direction(LightingDirection::Top);
threeDFormat->get_LightRig()->set_LightType(LightRigPresetType::Balanced);
threeDFormat->get_LightRig()->SetRotation(0.0f, 0.0f, 40.0f);

threeDFormat->get_Camera()->set_CameraType(CameraPresetType::PerspectiveContrastingRightFacing);
```

Wynik operacji:

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 
Zastosowanie efektów 3D do tekstów lub ich kształtów oraz interakcje między efektami opierają się na określonych regułach.  

Rozważ scenę dla tekstu i kształtu zawierającego ten tekst. Efekt 3D zawiera reprezentację obiektu 3D oraz scenę, na której obiekt został umieszczony.  

- Gdy scena jest ustawiona zarówno dla figury, jak i tekstu, scena figury ma wyższy priorytet — scena tekstu jest ignorowana.  
- Gdy figura nie ma własnej sceny, ale posiada reprezentację 3D, używana jest scena tekstu.  
- W przeciwnym razie — gdy kształt pierwotnie nie ma efektu 3D — kształt jest płaski i efekt 3D jest stosowany tylko do tekstu.  

Te opisy są powiązane z metodami ThreeDFormat.getLightRig() i ThreeDFormat.getCamera(). 
{{% /alert %}} 

## **Zastosuj efekty zewnętrznego cienia do kształtów**
Aspose.Slides dla C++ udostępnia klasy [**IOuterShadow**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.effects.i_outer_shadow) i [**IInnerShadow**](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.effects.i_inner_shadow), które pozwalają zastosować efekty cienia do tekstu znajdującego się w TextFrame. Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).  
2. Uzyskaj odwołanie do slajdu, używając jego indeksu.  
3. Dodaj AutoShape typu Rectangle do slajdu.  
4. Uzyskaj dostęp do TextFrame powiązanego z AutoShape.  
5. Ustaw FillType AutoShape na NoFill.  
6. Zainstaluj klasę OuterShadow.  
7. Ustaw BlurRadius cienia.  
8. Ustaw Direction cienia.  
9. Ustaw Distance cienia.  
10. Ustaw RectanglelAlign na TopLeft.  
11. Ustaw PresetColor cienia na Black.  
12. Zapisz prezentację jako plik PPTX.  

Ten przykładowy kod w C++ — implementacja powyższych kroków — pokazuje, jak zastosować efekt zewnętrznego cienia do tekstu:

``` cpp
auto pres = System::MakeObject<Presentation>();
// Pobierz odniesienie do slajdu
auto sld = pres->get_Slides()->idx_get(0);

// Dodaj AutoShape typu prostokąt
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Dodaj TextFrame do prostokąta
ashp->AddTextFrame(u"Aspose TextBox");

// Wyłącz wypełnienie kształtu, jeśli chcemy uzyskać cień tekstu
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Dodaj zewnętrzny cień i ustaw wszystkie niezbędne parametry
ashp->get_EffectFormat()->EnableOuterShadowEffect();
auto shadow = ashp->get_EffectFormat()->get_OuterShadowEffect();
shadow->set_BlurRadius(4.0);
shadow->set_Direction(45.0f);
shadow->set_Distance(3);
shadow->set_RectangleAlign(RectangleAlignment::TopLeft);
shadow->get_ShadowColor()->set_PresetColor(PresetColor::Black);

// Zapisz prezentację na dysku
pres->Save(u"pres_out.pptx", SaveFormat::Pptx);
```

## **Zastosuj efekty wewnętrznego cienia do kształtów**
Przejdź przez następujące kroki:

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation).  
2. Uzyskaj odwołanie do slajdu.  
3. Dodaj AutoShape typu Rectangle.  
4. Włącz InnerShadowEffect.  
5. Ustaw wszystkie niezbędne parametry.  
6. Ustaw ColorType na Scheme.  
7. Ustaw Scheme Color.  
8. Zapisz prezentację jako plik [PPTX](https://docs.fileformat.com/presentation/pptx/).  

Ten przykładowy kod (oparty na powyższych krokach) pokazuje, jak dodać łącznik między dwoma kształtami w C++:

``` cpp
auto presentation = System::MakeObject<Presentation>();
// Pobierz odniesienie do slajdu
auto slide = presentation->get_Slides()->idx_get(0);

// Dodaj AutoShape typu prostokąt
auto ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 400.0f, 300.0f);
ashp->get_FillFormat()->set_FillType(FillType::NoFill);

// Dodaj TextFrame do prostokąta
ashp->AddTextFrame(u"Aspose TextBox");
auto port = ashp->get_TextFrame()->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0);
auto pf = port->get_PortionFormat();
pf->set_FontHeight(50.0f);

// Włącz efekt wewnętrznego cienia    
auto ef = pf->get_EffectFormat();
ef->EnableInnerShadowEffect();

// Ustaw wszystkie niezbędne parametry
auto shadow = ef->get_InnerShadowEffect();
shadow->set_BlurRadius(8.0);
shadow->set_Direction(90.0F);
shadow->set_Distance(6.0);
shadow->get_ShadowColor()->set_B(189);

// Ustaw ColorType jako Scheme
shadow->get_ShadowColor()->set_ColorType(ColorType::Scheme);

// Ustaw kolor schematu
shadow->get_ShadowColor()->set_SchemeColor(SchemeColor::Accent1);

// Zapisz prezentację
presentation->Save(u"WordArt_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Czy mogę używać efektów WordArt z różnymi czcionkami lub skryptami (np. arabski, chiński)?**

Tak, Aspose.Slides obsługuje Unicode i działa ze wszystkimi głównymi czcionkami i skryptami. Efekty WordArt, takie jak cień, wypełnienie i kontur, mogą być stosowane niezależnie od języka, choć dostępność czcionek i renderowanie mogą zależeć od czcionek systemowych.

**Czy mogę zastosować efekty WordArt do elementów master slajdu?**

Tak, możesz zastosować efekty WordArt do kształtów na slajdach master, w tym do pól tekstowych tytułu, stopek lub tekstu w tle. Zmiany w układzie master będą odzwierciedlane we wszystkich powiązanych slajdach.

**Czy efekty WordArt wpływają na rozmiar pliku prezentacji?**

Nieznacznie. Efekty WordArt, takie jak cienie, poświaty i gradientowe wypełnienia, mogą nieco zwiększyć rozmiar pliku ze względu na dodatkowe metadane formatowania, ale różnica zazwyczaj jest pomijalna.

**Czy mogę podglądać wynik efektów WordArt bez zapisywania prezentacji?**

Tak, możesz renderować slajdy zawierające WordArt do obrazów (np. PNG, JPEG) używając metody `GetImage` z interfejsów [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) lub [ISlide](https://reference.aspose.com/slides/pl/cpp/aspose.slides/islide/). Pozwala to podglądać wynik w pamięci lub na ekranie przed zapisaniem lub wyeksportowaniem pełnej prezentacji.