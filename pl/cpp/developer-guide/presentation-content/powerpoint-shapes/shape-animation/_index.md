---
title: Zastosuj animacje kształtów w prezentacjach przy użyciu C++
linktitle: Animacja kształtu
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

Animacje są efektami wizualnymi, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](/slides/pl/cpp/animated-charts/). Ożywiają prezentacje lub ich elementy. 

## **Dlaczego używać animacji w prezentacjach?**

Korzystając z animacji, możesz  

* kontrolować przepływ informacji  
* wyeksponować ważne punkty  
* zwiększyć zainteresowanie lub zaangażowanie odbiorców  
* uczynić treść łatwiejszą do czytania, przyswajania lub przetwarzania  
* przyciągnąć uwagę czytelników lub widzów na ważne części w prezentacji  

PowerPoint udostępnia wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentu** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw [Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation).  
* Aspose.Slides oferuje ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Efekty te są zasadniczo takie same (lub równoważne) jak te używane w PowerPoint.  

## **Zastosuj animację do pola tekstowego**

Aspose.Slides dla C++ pozwala zastosować animację do tekstu w kształcie.  

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).  
5. Uzyskaj główną sekwencję efektów.  
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
7. Ustaw właściwość [TextAnimation.BuildType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) na wartość z [wyliczenia BuildType](https://reference.aspose.com/slides/pl/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).  
8. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod C++ pokazuje, jak zastosować efekt `Fade` do AutoShape oraz ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Dodaje nową AutoShape z tekstem
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
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Oprócz stosowania animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_paragraph). Zobacz [**Animowany tekst**](/slides/pl/cpp/animated-text/).

{{% /alert %}} 

## **Zastosuj animację do ramki obrazu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_picture_frame) na slajdzie.  
4. Uzyskaj główną sekwencję efektów.  
5. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_picture_frame).  
6. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod C++ pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Ładuje obraz, który zostanie dodany do kolekcji obrazów w prezentacji
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Dodaje ramkę obrazu do slajdu
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Dodaje efekt animacji Fly z lewej do ramki obrazu
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Zapisuje plik PPTX na dysku
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Zastosuj animację do kształtu**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.presentation/).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape).  
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.i_auto_shape). (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).  
5. Utwórz sekwencję efektów na kształcie bevel.  
6. Utwórz własny `UserPath`.  
7. Dodaj polecenia do przemieszczania się po `UserPath`.  
8. Zapisz prezentację na dysku jako plik PPTX.  

Ten kod C++ pokazuje, jak zastosować efekt `PathFootball` (path football) do kształtu:

```c++
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

	// Dodaje efekt animacji PathFootball
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
	 
	 // Zapisuje plik PPTX na dysk
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Pobierz efekty animacji zastosowane do kształtu**

Poniższe przykłady pokazują, jak używać metody `GetEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/isequence/) aby uzyskać wszystkie efekty animacji zastosowane do kształtu.  

**Przykład 1: Pobierz efekty animacji zastosowane do kształtu na normalnym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak uzyskać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Przykład 2: Pobierz wszystkie efekty animacji, w tym te dziedziczone z placeholderów**

Jeśli kształt na normalnym slajdzie ma placeholdery znajdujące się na slajdzie układu i/lub slajdzie głównym, a do tych placeholderów dodano efekty animacji, wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym te dziedziczone z placeholderów.  

Powiedzmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem „Made with Aspose.Slides” i zastosowano do niego efekt **Random Bars**.  

![Efekt animacji kształtu slajdu](slide-shape-animation.png)

Załóżmy również, że efekt **Split** został zastosowany do placeholdera stopki na **slajdzie układu**.  

![Efekt animacji kształtu układu](layout-shape-animation.png)

I w końcu, efekt **Fly In** został zastosowany do placeholdera stopki na **slajdzie nadrzędnym**.  

![Efekt animacji kształtu nadrzędnego](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak używać metody `GetBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/cpp/aspose.slides/ishape/) aby uzyskać dostęp do placeholderów kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym te dziedziczone z placeholderów znajdujących się na slajdach układu i nadrzędnym.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Get animation effects of the shape on the normal slide.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Wyjście:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Lot, dół
Type: 134, subtype: 45            // Rozdzielenie, pionowo w środku
Type: 126, subtype: 22            // Losowe paski, poziome
```

## **Zmień właściwości timingowe efektu animacji**

Aspose.Slides dla C++ pozwala zmienić właściwości Timing efektu animacji.  

Panel Timing animacji w Microsoft PowerPoint:

![example1_image](shape-animation.png)

Odpowiedniości między Timing w PowerPoint a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c):

- Lista rozwijana **Start** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3).  
- Wartość **Duration** w PowerPoint Timing odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Czas trwania animacji (w sekundach) to całkowity czas potrzebny na zakończenie jednego cyklu animacji.  
- Wartość **Delay** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b).  

Oto jak zmienić właściwości Timing efektu:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.  
2. Ustaw nowe wartości dla potrzebnych właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c).  
3. Zapisz zmodyfikowany plik PPTX.  

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Pobiera pierwszy efekt głównej sekwencji.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Zmienia TriggerType efektu na rozpoczęcie po kliknięciu
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Zmienia czas trwania efektu
effect->get_Timing()->set_Duration(3.f);

// Zmienia TriggerDelayTime efektu
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Zapisuje plik PPTX na dysk
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji:  

- [set_Sound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_sound/)  
- [set_StopPreviousSound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_stopprevioussound/)  

### **Dodaj dźwięk efektu animacji**

Ten kod C++ pokazuje, jak dodać dźwięk efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Dodaje dźwięk do kolekcji audio prezentacji
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera główną sekwencję slajdu.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Pobiera pierwszy efekt głównej sekwencji
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Sprawdza, czy efekt ma ustawiony brak dźwięku
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Dodaje dźwięk do pierwszego efektu
    firstEffect->set_Sound(effectSound);
}

// Pobiera pierwszą interaktywną sekwencję slajdu.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Ustawia flagę „Stop previous sound” dla efektu
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Zapisuje plik PPTX na dysk
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Wyodrębnij dźwięk efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/cpp/aspose.slides/presentation/).  
2. Uzyskaj odniesienie do slajdu poprzez jego indeks.  
3. Uzyskaj główną sekwencję efektów.  
4. Wyodrębnij osadzony [set_Sound()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/effect/set_sound/) z każdego efektu animacji.  

Ten kod C++ pokazuje, jak wyodrębnić dźwięk osadzony w efekcie animacji:

```c++
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

Aspose.Slides dla C++ pozwala zmienić właściwość After animation (Po animacji) efektu animacji.  

Panel efektu animacji i rozszerzone menu w Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Właściwość [set_AfterAnimationType()] opisująca typ po animacji:

- PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/);  
- PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/) (domyślny typ po animacji);  
- PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/);  
- PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/).  

Właściwość [set_AfterAnimationColor()] definiuje format koloru po animacji. Działa ona w połączeniu z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/afteranimationtype/). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.  

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera pierwszy efekt z głównej sekwencji
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Zmienia typ animacji po zakończeniu na Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Ustawia kolor przyciemnienia po animacji
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Zapisuje plik PPTX na dysk
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Animuj tekst**

Aspose.Slides udostępnia te właściwości, które umożliwiają pracę z blokiem *Animate text* efektu animacji:  

- Metoda [set_AnimateTextType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) opisuje typ animowanego tekstu efektu. Tekst kształtu może być animowany:  
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) typ)  
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) typ)  
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/animatetexttype/) typ)  
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) ustawia opóźnienie pomiędzy częściami animowanego tekstu (słowami lub literami). Dodatnia wartość określa procent czasu trwania efektu. Ujemna wartość określa opóźnienie w sekundach.  

Oto jak zmienić właściwości Animate text efektu:

1. Zastosuj ([Apply](#apply-animation-to-shape)) lub pobierz efekt animacji.  
2. Ustaw właściwość [set_BuildType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/itextanimation/set_buildtype/) na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/buildtype/), aby wyłączyć tryb animacji *By Paragraphs*.  
3. Ustaw nowe wartości właściwości [set_AnimateTextType()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) i [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/pl/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).  
4. Zapisz zmodyfikowany plik PPTX.  

```c++
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Pobiera pierwszy efekt z głównej sekwencji
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Zmienia typ animacji tekstu efektu na „Jako jeden obiekt”
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Zmienia typ animacji tekstu efektu na „Słowo po słowie”
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Ustawia opóźnienie między słowami na 20% czasu trwania efektu
firstEffect->set_DelayBetweenTextParts(20.0f);

// Zapisuje plik PPTX na dysk
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Jak mogę zapewnić zachowanie animacji przy publikowaniu prezentacji w sieci?**

[Export to HTML5](/slides/pl/cpp/export-to-html5/) i włącz [opcje](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/) odpowiedzialne za animacje [kształtów](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animateshapes/) i [przejść](https://reference.aspose.com/slides/pl/cpp/aspose.slides.export/html5options/set_animatetransitions/). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.  

**Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?**

Animacja i kolejność rysowania są niezależne: efekt kontroluje moment i typ pojawiania się/zanikania, natomiast [z-order](https://reference.aspose.com/slides/pl/cpp/aspose.slides/shape/get_zorderposition/) określa, co co zasłania. Widoczny rezultat definiowany jest ich połączeniem. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides podąża za tą samą logiką.)  

**Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?**

Ogólnie [animacje są obsługiwane](/slides/pl/cpp/convert-powerpoint-to-video/), ale rzadkie przypadki lub specyficzne efekty mogą być renderowane inaczej. Zaleca się testować używane efekty oraz wersję biblioteki.