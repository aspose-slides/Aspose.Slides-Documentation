---
title: Zastosowanie animacji kształtów w prezentacjach w .NET
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/net/shape-animation/
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
- .NET
- C#
- Aspose.Slides
description: "Dowiedz się, jak tworzyć i dostosowywać animacje kształtów w prezentacjach PowerPoint przy użyciu Aspose.Slides dla .NET. Wyróżnij się!"
---
## **Wprowadzenie**

Animacje są efektami wizualnymi, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](/slides/pl/net/animated-charts/). Dodają życia prezentacjom lub ich elementom. 

## **Dlaczego warto używać animacji w prezentacjach?**

* kontrolować przepływ informacji
* podkreślać ważne punkty
* zwiększać zainteresowanie lub zaangażowanie odbiorców
* ułatwiać czytanie, przyswajanie lub przetwarzanie treści
* przyciągać uwagę czytelników lub widzów do ważnych części w prezentacji

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentu** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw [Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/) ,
* Aspose.Slides dostarcza ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype). Efekty te są w zasadzie takie same (lub równoważne) jak te używane w PowerPoint. 

## **Zastosuj animację do pola tekstowego**

Aspose.Slides dla .NET umożliwia zastosowanie animacji do tekstu w kształcie. 

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) .
2. Pobierz odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/textframe).
5. Pobierz główną sekwencję efektów.
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape).
7. Ustaw właściwość [TextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/textanimation/properties/buildtype) na wartość z [wyliczenia BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype).
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod C# pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy klasę prezentacji, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Dodaje nowy AutoShape z tekstem
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    // Dodaje trzy akapity, aby konstrukcja według akapitów miała coś do przetworzenia.
    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph";
    textFrame.Paragraphs.Add(new Paragraph { Text = "Second paragraph" });
    textFrame.Paragraphs.Add(new Paragraph { Text = "Third paragraph" });

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = sld.Timeline.MainSequence;

    // Dodaje efekt animacji Fade do kształtu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje tekst kształtu według akapitów pierwszego poziomu
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="info"  %}} 

Oprócz stosowania animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph). Zobacz [**Animated Text**](/slides/pl/net/animated-text/).

{{% /alert %}} 

## **Zastosuj animację do PictureFrame**

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) .
2. Pobierz odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe) na slajdzie. 
5. Pobierz główną sekwencję efektów.
6. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe).
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod C# pokazuje, jak zastosować efekt `Fly` do ramki obrazu:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    // Wczytuje obraz, który ma zostać dodany do kolekcji obrazów w prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Dodaje efekt animacji Fly od lewej do ramki obrazu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Zastosuj animację do kształtu**

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/) .
2. Pobierz odniesienie do slajdu przy użyciu jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) (gdy ten obiekt zostanie kliknięty, animacja zostanie odtworzona).
5. Utwórz sekwencję efektów na kształcie bevel.
6. Utwórz własny `UserPath`.
7. Dodaj polecenia przemieszczania do `UserPath`.
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod C# pokazuje, jak zastosować efekt `PathFootball` (ścieżka piłkowa) do kształtu:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy obiekt klasy Presentation, który reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Dodaje efekt animacji PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tworzy pewien rodzaj "przycisku".
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tworzy sekwencję efektów dla przycisku.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Tworzy własną ścieżkę użytkownika. Nasz obiekt będzie przesuwany dopiero po kliknięciu przycisku.
    IEffect fxUserPath = seqInter.AddEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

    // Dodaje polecenia ruchu, ponieważ utworzona ścieżka jest pusta.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.Behaviors[0]);

    PointF[] pts = new PointF[1];
    pts[0] = new PointF(0.076f, 0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new PointF(-0.076f, -0.59f);
    motionBhv.Path.Add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.Path.Add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimExample_out.pptx", SaveFormat.Pptx);
}
```

## **Uzyskaj efekty animacji zastosowane do kształtu**

Poniższe przykłady pokazują, jak użyć metody `GetEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/), aby uzyskać wszystkie efekty animacji zastosowane do kształtu.

**Przykład 1: Pobierz efekty animacji zastosowane do kształtu na normalnym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak uzyskać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("AnimExample_out.pptx"))
{
    ISlide firstSlide = presentation.Slides[0];

    // Pobiera główną sekwencję animacji slajdu.
    ISequence sequence = firstSlide.Timeline.MainSequence;

    // Pobiera pierwszy kształt na pierwszym slajdzie.
    IShape shape = firstSlide.Shapes[0];

    // Pobiera efekty animacji zastosowane do kształtu.
    IEffect[] shapeEffects = sequence.GetEffectsByShape(shape);

    if (shapeEffects.Length > 0)
        Console.WriteLine($"The shape {shape.Name} has {shapeEffects.Length} animation effects.");
}
```

**Przykład 2: Pobierz wszystkie efekty animacji, w tym dziedziczone z placeholderów**

Jeśli kształt na normalnym slajdzie ma placeholdery znajdujące się na slajdzie układu i/lub slajdzie głównym, a do tych placeholderów dodano efekty animacji, wtedy wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" oraz zastosowanym efektem **Random Bars**.

![Slide shape animation effect](slide-shape-animation.png)

Załóżmy również, że efekt **Split** został zastosowany do placeholdera stopki na slajdzie **layout**.

![Layout shape animation effect](layout-shape-animation.png)

I w końcu, efekt **Fly In** został zastosowany do placeholdera stopki na slajdzie **master**.

![Master shape animation effect](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak użyć metody `GetBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), aby uzyskać dostęp do placeholderów kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym dziedziczone z placeholderów znajdujących się na slajdach layout i master.

```cs
using System;
using System.Collections.Generic;
using Aspose.Slides;
using Aspose.Slides.Animation;

using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz efekty animacji kształtu na normalnym slajdzie.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Pobierz efekty animacji placeholdera na slajdzie layout.
    IShape layoutShape = shape.GetBasePlaceholder();
    IEffect[] layoutShapeEffects = slide.LayoutSlide.Timeline.MainSequence.GetEffectsByShape(layoutShape);

    // Pobierz efekty animacji placeholdera na slajdzie master.
    IShape masterShape = layoutShape.GetBasePlaceholder();
    IEffect[] masterShapeEffects = slide.LayoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(masterShape);

    Console.WriteLine("Main sequence of shape effects:");
    PrintEffects(masterShapeEffects);
    PrintEffects(layoutShapeEffects);
    PrintEffects(shapeEffects);
}

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```
```cs
using Aspose.Slides.Animation;

static void PrintEffects(IEnumerable<IEffect> effects)
{
    foreach (IEffect effect in effects)
    {
        Console.WriteLine($"{effect.Type} {effect.Subtype}");
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Zmień właściwości czasu efektu animacji**

Aspose.Slides dla .NET pozwala zmienić właściwości czasu (Timing) efektu animacji.

To jest panel Timing animacji oraz rozszerzone menu w Microsoft PowerPoint:

![example1_image](shape-animation.png)

Oto odpowiedniki pomiędzy Timingiem PowerPointa a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/properties/timing):

- Lista rozwijana PowerPoint Timing **Start** odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/triggertype).
- PowerPoint Timing **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/duration). Czas trwania animacji (w sekundach) to łączny czas potrzebny na zakończenie jednego cyklu animacji.
- PowerPoint Timing **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/triggerdelaytime).
- PowerPoint Timing **Repeat** lista rozwijana odpowiada tym właściwościom:
  * [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount) właściwość opisująca *liczbę* powtórzeń efektu;
  * [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide) flaga określająca, czy efekt ma być powtarzany aż do końca slajdu;
  * [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick) flaga określająca, czy efekt ma być powtarzany do następnego kliknięcia.
- Pole wyboru PowerPoint Timing **Rewind when done playing** odpowiada właściwości [Effect.Timing.Rewind](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/rewind/). 

Oto jak zmienić właściwości czasu efektu:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw nowe wartości dla właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/properties/timing), których potrzebujesz. 
3. Zapisz zmodyfikowany plik PPTX.

Ten kod C# demonstruje tę operację:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Pobiera pierwszy efekt z głównej sekwencji.
    IEffect effect = sequence[0];

    // Zmienia TriggerType efektu na uruchamianie po kliknięciu
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Zmienia czas trwania efektu
    effect.Timing.Duration = 3f;

    // Zmienia TriggerDelayTime efektu
    effect.Timing.TriggerDelayTime = 0.5f;

    // Jeśli wartość Repeat efektu to "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Zmienia Repeat efektu na "Do następnego kliknięcia"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Zmienia Repeat efektu na "Do końca slajdu"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Włącza Rewind efektu
    effect.Timing.Rewind = true;
    
    // Zapisuje plik PPTX na dysku
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z dźwiękami w efektach animacji: 
- [IEffect.Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Dodaj dźwięk efektu animacji**

Ten kod C# pokazuje, jak dodać dźwięk do efektu animacji i zatrzymać go, gdy rozpocznie się kolejny efekt:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Dodaje dźwięk do kolekcji audio prezentacji
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Pobiera główną sekwencję slajdu.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Pobiera pierwszy efekt z głównej sekwencji
	IEffect firstEffect = sequence[0];

	// Sprawdza efekt pod kątem "No Sound"
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Dodaje dźwięk do pierwszego efektu
		firstEffect.Sound = effectSound;
	}

	// Pobiera pierwszą interaktywną sekwencję slajdu.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Ustawia flagę "Stop previous sound" efektu
	interactiveSequence[0].StopPreviousSound = true;

	// Zapisuje plik PPTX na dysku
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Wyodrębnij dźwięk efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/) .
2. Pobierz odniesienie do slajdu poprzez jego indeks. 
3. Pobierz główną sekwencję efektów. 
4. Wyodrębnij [Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/sound/) osadzony w każdym efekcie animacji. 

Ten kod C# pokazuje, jak wyodrębnić dźwięk osadzony w efekcie animacji:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Wyodrębnia dźwięk efektu do tablicy bajtów
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Po animacji**

Aspose.Slides dla .NET pozwala zmienić właściwość After animation efektu animacji.

To jest panel Animation Effect oraz rozszerzone menu w Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Lista rozwijana PowerPoint Effect **After animation** odpowiada następującym właściwościom: 

- Właściwość [IEffect.AfterAnimationType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationtype/) opisuje typ After animation:
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/) (domyślny typ After animation);
  * PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
- Właściwość [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationcolor/) definiuje format koloru po animacji. Działa w połączeniu z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/). Jeśli zmienisz typ na inny, kolor po animacji zostanie wyczyszczony.

Ten kod C# pokazuje, jak zmienić efekt after animation:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Pobiera pierwszy efekt z głównej sekwencji
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Zmienia typ po animacji na Color
    firstEffect.AfterAnimationType = AfterAnimationType.Color;

    // Ustawia kolor przyciemnienia po animacji
    firstEffect.AfterAnimationColor.Color = Color.AliceBlue;

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
}
```

## **Animuj tekst**

Aspose.Slides udostępnia następujące właściwości, które umożliwiają pracę z blokiem *Animate text* efektu animacji:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) opisuje typ animowanego tekstu efektu. Tekst w kształcie może być animowany:
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ustawia opóźnienie między częściami animowanego tekstu (słowami lub literami). Wartość dodatnia określa procent czasu trwania efektu. Wartość ujemna określa opóźnienie w sekundach.

Oto jak można zmienić właściwości Effect Animate text:

1. [Zastosuj](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw właściwość [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itextanimation/buildtype/) na wartość [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype/), aby wyłączyć tryb animacji *By Paragraphs*.
3. Ustaw nowe wartości dla właściwości [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) oraz [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Zapisz zmodyfikowany plik PPTX.

Ten kod C# demonstruje tę operację:

```c#
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

// Tworzy obiekt klasy prezentacji, który reprezentuje plik prezentacji.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
	ISlide firstSlide = pres.Slides[0];

	// Pobiera pierwszy efekt z głównej sekwencji
	IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

	// Zmienia typ animacji tekstu efektu na "As One Object"
	firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

	// Zmienia typ animacji tekstu na "By word"
	firstEffect.AnimateTextType = AnimateTextType.ByWord;

	// Ustawia opóźnienie między słowami na 20% czasu trwania efektu
	firstEffect.DelayBetweenTextParts = 20f;

	// Zapisuje plik PPTX na dysku
	pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

### Jak zapewnić, że animacje są zachowane podczas publikowania prezentacji w sieci?

[Export to HTML5](/slides/pl/net/export-to-html5/) i włącz [opcje](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/) odpowiedzialne za animacje [kształtów](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) i [przejść](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/). Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

### Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?

Animacja i kolejność rysowania są niezależne: efekt kontroluje czas i typ pojawiania/zanikania, podczas gdy [z-order](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/zorderposition/) określa, co co zasłania. Widoczny rezultat jest określony ich kombinacją. (To ogólne zachowanie PowerPointa; model efektów i kształtów Aspose.Slides działa według tej samej logiki.)

### Czy istnieją ograniczenia przy konwertowaniu animacji na wideo dla niektórych efektów?

Ogólnie, [animacje są obsługiwane](/slides/pl/net/convert-powerpoint-to-video/), ale rzadkie przypadki lub konkretne efekty mogą być renderowane inaczej. Zaleca się przetestowanie używanych efektów oraz wersji biblioteki.