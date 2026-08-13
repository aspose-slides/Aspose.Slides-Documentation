---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu C++
linktitle: Animacja Kształtu
type: docs
weight: 60
url: /pl/cpp/shape-animation/
keywords:
- kształt
- animacja
- efekt
- animowany kształt
- animowany tekst
- dodaj animację
- pobierz animację
- wyodrębnij animację
- dodaj efekt
- pobierz efekt
- wyodrębnij efekt
- dźwięk efektu
- zastosuj animację
- PowerPoint
- prezentacja
- C++
- Aspose.Slides
description: "Odkryj, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla C++. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje to efekty wizualne, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](/slides/pl/cpp/animated-charts/). Ożywiają prezentacje i ich elementy.

## **Dlaczego używać animacji w prezentacjach?**

Stosując animacje, możesz  

* kontrolować przepływ informacji  
* podkreślać ważne punkty  
* zwiększyć zainteresowanie lub zaangażowanie odbiorców  
* ułatwić czytanie, przyswajanie lub przetwarzanie treści  
* skierować uwagę czytelników lub widzów na istotne części prezentacji  

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentu** i **ścieżek ruchu**.

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw [Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation).  
* Aspose.Slides oferuje ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Efekty te są w zasadzie tymi samymi (lub równoważnymi) efektami używanymi w PowerPoint.

## **Zastosowanie animacji do TextBox**

Aspose.Slides for C++ umożliwia zastosowanie animacji do tekstu wewnątrz kształtu.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Pobierz referencję do slajdu przez jego indeks.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).  
5. Pobierz główną sekwencję efektów.  
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
7. Ustaw właściwość [TextAnimation.BuildType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) na wartość z [wyliczenia BuildType](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Zapisz prezentację na dysku jako plik PPTX.  

Poniższy kod C++ pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```c++
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaje nowy AutoShape z tekstem
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Dodaje efekt animacji Fade do kształtu
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Animuje tekst kształtu według akapitów pierwszego poziomu
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="info"  %}} 

Oprócz stosowania animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_paragraph). Zobacz [**Animowany tekst**](/slides/pl/cpp/animated-text/).  

{{% /alert %}} 

## **Zastosowanie animacji do PictureFrame**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Pobierz referencję do slajdu przez jego indeks.  
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_picture_frame) na slajdzie.  
4. Pobierz główną sekwencję efektów.  
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_picture_frame).  
6. Zapisz prezentację na dysku jako plik PPTX.  

Poniższy kod C++ pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IImageCollection.h>
#include <DOM/IPPImage.h>
#include <DOM/IPictureFrame.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <IImage.h>
#include <Util/Images.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Wczytuje obraz, który zostanie dodany do kolekcji obrazów w prezentacji
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Dodaje ramkę obrazu do slajdu
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Dodaje efekt animacji Fly from Left do ramki obrazu
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zastosowanie animacji do Shape**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Pobierz referencję do slajdu przez jego indeks.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape) (gdy obiekt zostanie kliknięty, animacja zostanie odtworzona).  
5. Utwórz sekwencję efektów na kształcie bevel.  
6. Utwórz niestandardowy `UserPath`.  
7. Dodaj komendy poruszające się po `UserPath`.  
8. Zapisz prezentację na dysku jako plik PPTX.  

Poniższy kod C++ pokazuje, jak zastosować efekt `PathFootball` (ścieżka piłka nożna) do kształtu:

```c++
#include <DOM/Animation/EffectSubtype.h>
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/EffectType.h>
#include <DOM/Animation/IBehaviorCollection.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/IMotionPath.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ISequenceCollection.h>
#include <DOM/Animation/MotionCommandPathType.h>
#include <DOM/Animation/MotionEffect.h>
#include <DOM/Animation/MotionPathPointsType.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <drawing/point_f.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System;
using namespace System::Drawing;

	// Ścieżka do katalogu dokumentów.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Wczytuje prezentację
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Uzyskuje dostęp do pierwszego slajdu
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Uzyskuje dostęp do kolekcji kształtów wybranego slajdu
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Dodaje efekt animacji PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Tworzy pewnego rodzaju "przycisk".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Tworzy sekwencję efektów dla tego przycisku.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt zostanie przesunięty dopiero po kliknięciu przycisku.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Dodaje polecenia ruchu, ponieważ utworzona ścieżka jest pusta.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 // Zapisuje plik PPTX na dysku
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Pobieranie efektów animacji zastosowanych do kształtu**

Poniższe przykłady pokazują, jak użyć metody `GetEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/isequence/) w celu uzyskania wszystkich efektów animacji zastosowanych do kształtu.

**Przykład 1: Pobranie efektów animacji zastosowanych do kształtu na zwykłym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykład kodu pokazuje, jak pobrać efekty zastosowane do pierwszego kształtu na pierwszym zwykłym slajdzie prezentacji `AnimExample_out.pptx`.

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Pobiera główną sekwencję animacji slajdu.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Pobiera pierwszy kształt na pierwszym slajdzie.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Pobiera efekty animacji zastosowane do kształtu.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Przykład 2: Pobranie wszystkich efektów animacji, w tym dziedziczonych z placeholderów**

Jeśli kształt na zwykłym slajdzie ma placeholdery znajdujące się na slajdzie układu i/lub masterze, a do tych placeholderów dodano efekty animacji, wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem „Made with Aspose.Slides” oraz zastosowano do niego efekt **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Załóżmy również, że efekt **Split** został zastosowany do placeholdera stopki na **slajdzie układu**.

![Layout shape animation effect](layout-shape-animation.png)

I w końcu, efekt **Fly In** został zastosowany do placeholdera stopki na **slajdzie master**.

![Master shape animation effect](master-shape-animation.png)

Poniższy przykład kodu pokazuje, jak użyć metody `GetBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) w celu uzyskania dostępu do placeholderów kształtu i pobrania efektów animacji zastosowanych do kształtu stopki, w tym tych dziedziczonych z placeholderów znajdujących się na slajdach układu i mastera.

```cpp
#include <DOM/Animation/IEffect.h>
#include <system/array.h>
#include <system/console.h>
#include <system/smart_ptr.h>
#include <system/string.h>
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};
```
```cpp
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ILayoutSlide.h>
#include <DOM/IMasterSlide.h>
#include <DOM/IShape.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace System;

auto PrintEffects = [](ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
};

SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Pobierz efekty animacji kształtu na normalnym slajdzie.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Pobierz efekty animacji placeholdera na slajdzie układu.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Pobierz efekty animacji placeholdera na slajdzie master.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Lot, Dół
Type: 134, subtype: 45            // Rozdzielenie, PionowoWewnątrz
Type: 126, subtype: 22            // LosowePaski, Poziomo
```

## **Zmiana właściwości czasowych efektu animacji**

Aspose.Slides for C++ umożliwia zmianę właściwości Timing efektu animacji.

Jest to panel Timing animacji w Microsoft PowerPoint:

![example1_image](shape-animation.png)

Oto powiązania między Timingiem w PowerPoint a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Lista rozwijana PowerPoint **Start** odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- PowerPoint **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Czas trwania animacji (w sekundach) to całkowity czas potrzebny na wykonanie jednego cyklu.  
- PowerPoint **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

Tak zmieniasz właściwości Timing efektu:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.  
2. Ustaw nowe wartości właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c), które są potrzebne.  
3. Zapisz zmodyfikowany plik PPTX.  

Poniższy kod C++ demonstruje tę operację:

```c++
#include <DOM/Animation/EffectTriggerType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITiming.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Pobiera pierwszy efekt z głównej sekwencji.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Zmienia TriggerType efektu na rozpoczęcie po kliknięciu
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Zmienia czas trwania efektu
effect->get_Timing()->set_Duration(3.f);

// Zmienia TriggerDelayTime efektu
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji:  

- [set_Sound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **Dodanie dźwięku do efektu animacji**

Ten kod C++ pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/IAudioCollection.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/io/file.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;
using namespace System::IO;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Dodaje dźwięk do kolekcji audio prezentacji
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Pobiera pierwszy efekt z głównej sekwencji
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Sprawdza, czy efekt nie ma dźwięku
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Dodaje dźwięk do pierwszego efektu
    firstEffect->set_Sound(effectSound);
}

// Pobiera pierwszą interaktywną sekwencję slajdu.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Ustawia flagę efektu "Stop previous sound"
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Wyodrębnienie dźwięku z efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).  
2. Pobierz referencję do slajdu przez jego indeks.  
3. Pobierz główną sekwencję efektów.  
4. Wyodrębnij metodą [set_Sound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_sound/) wbudowany dźwięk każdego efektu animacji.  

Ten kod C++ pokazuje, jak wyodrębnić dźwięk osadzony w efekcie animacji:

```c++
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IAudio.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Po animacji**

Aspose.Slides for C++ pozwala zmienić właściwość After animation efektu animacji.

Jest to panel Effect Animation oraz rozszerzone menu w Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Lista rozwijana PowerPoint **After animation** odpowiada następującym właściwościom:  

- Właściwość [set_AfterAnimationType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) opisująca typ po‑animacji:  
  * **More Colors** w PowerPoint odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/);  
  * **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/) (domyślny typ po‑animacji);  
  * **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/);  
  * **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/).  
- Właściwość [set_AfterAnimationColor()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) definiuje format koloru po‑animacji. Działa ona razem z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/). Jeśli zmienisz typ na inny, kolor po‑animacji zostanie wyczyszczony.  

Ten kod C++ pokazuje, jak zmienić efekt po‑animacji:

```c++
#include <DOM/Animation/AfterAnimationType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/IColorFormat.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <drawing/color.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera pierwszy efekt z głównej sekwencji
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Zmienia typ po animacji na Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Ustawia kolor przyciemnienia po animacji
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animowanie tekstu**

Aspose.Slides udostępnia właściwości umożliwiające pracę z blokiem *Animate text* efektu animacji:  

- [set_AnimateTextType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) opisuje typ animacji tekstu. Tekst w kształcie może być animowany:  
  - Wszystko naraz ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) )  
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) )  
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) )  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ustawia opóźnienie między częściami animowanego tekstu (słowami lub literami). Wartość dodatnia określa procent czasu trwania efektu, wartość ujemna – opóźnienie w sekundach.  

Tak zmienisz właściwości Effect Animate text:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.  
2. Ustaw właściwość [set_BuildType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation.itextanimation/set_buildtype/) na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/buildtype/), aby wyłączyć tryb animacji *By Paragraphs*.  
3. Ustaw nowe wartości właściwości [set_AnimateTextType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) oraz [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Zapisz zmodyfikowany plik PPTX.  

Ten kod C++ demonstruje tę operację:

```c++
#include <DOM/Animation/AnimateTextType.h>
#include <DOM/Animation/BuildType.h>
#include <DOM/Animation/IEffect.h>
#include <DOM/Animation/ISequence.h>
#include <DOM/Animation/ITextAnimation.h>
#include <DOM/IAnimationTimeLine.h>
#include <DOM/ISlide.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Animation;
using namespace Aspose::Slides::Export;

// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera pierwszy efekt z głównej sekwencji
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Zmienia typ animacji tekstu efektu na "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Zmienia typ animacji tekstu efektu na "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Ustawia opóźnienie między słowami na 20% czasu trwania efektu
firstEffect->set_DelayBetweenTextParts(20.0f);

// Zapisuje plik PPTX na dysku
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

### Jak zapewnić zachowanie animacji przy publikowaniu prezentacji w sieci?

[Export to HTML5](/slides/pl/cpp/export-to-html5/) i włącz opcje odpowiedzialne za animacje [shape](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animateshapes/) oraz [transition](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animatetransitions/). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

### W jaki sposób zmiana kolejności warstw (z‑order) kształtów wpływa na animację?

Kolejność animacji i rysowania są niezależne: efekt kontroluje moment i sposób pojawiania/zanikania, natomiast [z-order](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_zorderposition/) określa, co co zakrywa. Widoczny rezultat powstaje z ich połączenia. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides działa tak samo.)

### Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?

Ogólnie [animacje są obsługiwane](/slides/pl/cpp/convert-powerpoint-to-video/), ale rzadkie przypadki lub specyficzne efekty mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów oraz wersji biblioteki.