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

Animacje są efektami wizualnymi, które można zastosować do tekstów, obrazów, kształtów lub [wykresów](/slides/pl/net/animated-charts/). Dodają one życia prezentacjom lub ich elementom. 

## **Dlaczego używać animacji w prezentacjach?**

* kontrolować przepływ informacji
* podkreślać ważne punkty
* zwiększać zainteresowanie lub zaangażowanie publiczności
* ułatwiać czytanie, przyswajanie lub przetwarzanie treści
* przyciągać uwagę czytelników lub widzów do ważnych części w prezentacji

PowerPoint oferuje wiele opcji i narzędzi do animacji oraz efektów animacji w kategoriach **wejścia**, **wyjścia**, **akcentowania** i **ścieżek ruchu**. 

## **Animacje w Aspose.Slides**

* Aspose.Slides udostępnia klasy i typy potrzebne do pracy z animacjami w przestrzeni nazw [Aspose.Slides.Animation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/),
* Aspose.Slides udostępnia ponad **150 efektów animacji** w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype). Efekty te są zasadniczo takie same (lub równoważne) jak te używane w PowerPoint.

## **Zastosuj animację do TextBox**

Aspose.Slides dla .NET umożliwia zastosowanie animacji do tekstu w kształcie. 

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 
4. Dodaj tekst do [IAutoShape.TextFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape/properties/textframe).
5. Uzyskaj główną sekwencję efektów.
6. Dodaj efekt animacji do [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape).
7. Ustaw właściwość [TextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/textanimation/properties/buildtype) na wartość z [wyliczenia BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype).
8. Zapisz prezentację na dysku jako plik PPTX.

Ten kod C# pokazuje, jak zastosować efekt `Fade` do AutoShape i ustawić animację tekstu na wartość *By 1st Level Paragraphs*:

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];
    
    // Dodaje nowy AutoShape z tekstem
    IAutoShape autoShape = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.TextFrame;
    textFrame.Text = "First paragraph \nSecond paragraph \n Third paragraph";

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = sld.Timeline.MainSequence;

    // Dodaje efekt animacji Fade do kształtu
    IEffect effect = sequence.AddEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Animuje tekst kształtu według pierwszego poziomu akapitów
    effect.TextAnimation.BuildType = BuildType.ByLevelParagraphs1;

    // Zapisuje plik PPTX na dysku
    pres.Save(path + "AnimTextBox_out.pptx", SaveFormat.Pptx);
}
```

{{%  alert color="primary"  %}} 

Poza stosowaniem animacji do tekstu, możesz także zastosować animacje do pojedynczego [Paragraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph). Zobacz [**Animated Text**](/slides/pl/net/animated-text/).

{{% /alert %}} 

## **Zastosuj animację do PictureFrame**

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj lub pobierz [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe) na slajdzie. 
5. Uzyskaj główną sekwencję efektów.
6. Dodaj efekt animacji do [PictureFrame](https://reference.aspose.com/slides/pl/net/aspose.slides/ipictureframe).
8. Zapisz prezentację na dysku jako plik PPTX.

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    // Ładuje obraz, który zostanie dodany do kolekcji obrazów w prezentacji
    IImage image = Images.FromFile("aspose-logo.jpg");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Dodaje ramkę obrazu do slajdu
    IPictureFrame picFrame = pres.Slides[0].Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, ppImage);

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Dodaje efekt animacji Fly z lewej strony do ramki obrazu
    IEffect effect = sequence.AddEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimImage_out.pptx", SaveFormat.Pptx);
}
```

## **Zastosuj animację do kształtu**

1. Utwórz instancję klasy [Presentation](http://www.aspose.com/api/net/slides/pl/aspose.slides/).
2. Uzyskaj referencję do slajdu za pomocą jego indeksu.
3. Dodaj `rectangle` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape). 
4. Dodaj `Bevel` [IAutoShape](https://reference.aspose.com/slides/pl/net/aspose.slides/iautoshape) (gdy ten obiekt jest kliknięty, animacja jest odtwarzana).
5. Utwórz sekwencję efektów na kształcie Bevel.
6. Utwórz własny `UserPath`.
7. Dodaj polecenia przemieszczania się do `UserPath`.
8. Zapisz prezentację na dysku jako plik PPTX.

```c#
// Tworzy instancję klasy Presentation, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation())
{
    ISlide sld = pres.Slides[0];

    // Tworzy efekt PathFootball dla istniejącego kształtu od podstaw.
    IAutoShape ashp = sld.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);

    ashp.AddTextFrame("Animated TextBox");

    // Dodaje efekt animacji PathFootBall.
    pres.Slides[0].Timeline.MainSequence.AddEffect(ashp, EffectType.PathFootball,
                           EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tworzy rodzaj przycisku.
    IShape shapeTrigger = pres.Slides[0].Shapes.AddAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tworzy sekwencję efektów dla przycisku.
    ISequence seqInter = pres.Slides[0].Timeline.InteractiveSequences.Add(shapeTrigger);

    // Tworzy niestandardową ścieżkę użytkownika. Nasz obiekt zostanie przesunięty dopiero po kliknięciu przycisku.
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

## **Pobierz efekty animacji zastosowane do kształtu**

Poniższe przykłady pokazują, jak używać metody `GetEffectsByShape` z interfejsu [ISequence](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/) , aby uzyskać wszystkie efekty animacji zastosowane do kształtu.

**Przykład 1: Pobierz efekty animacji zastosowane do kształtu na normalnym slajdzie**

Wcześniej nauczyłeś się, jak dodawać efekty animacji do kształtów w prezentacjach PowerPoint. Poniższy przykładowy kod pokazuje, jak uzyskać efekty zastosowane do pierwszego kształtu na pierwszym normalnym slajdzie w prezentacji `AnimExample_out.pptx`.

```c#
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

Jeśli kształt na normalnym slajdzie ma placeholdery, które znajdują się na slajdzie układu i/lub slajdzie nadrzędnym, a do tych placeholderów dodano efekty animacji, wtedy wszystkie efekty kształtu będą odtwarzane podczas pokazu slajdów, w tym dziedziczone z placeholderów.

Załóżmy, że mamy plik prezentacji PowerPoint `sample.pptx` z jednym slajdem zawierającym jedynie kształt stopki z tekstem "Made with Aspose.Slides" i efekt **Random Bars** został zastosowany do tego kształtu.

![Efekt animacji kształtu slajdu](slide-shape-animation.png)

Załóżmy również, że efekt **Split** został zastosowany do placeholdera stopki na slajdzie **layout**.

![Efekt animacji kształtu układu](layout-shape-animation.png)

I wreszcie, efekt **Fly In** został zastosowany do placeholdera stopki na slajdzie **master**.

![Efekt animacji kształtu master](master-shape-animation.png)

Poniższy przykładowy kod pokazuje, jak używać metody `GetBasePlaceholder` z interfejsu [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/) , aby uzyskać dostęp do placeholderów kształtu i pobrać efekty animacji zastosowane do kształtu stopki, w tym dziedziczone z placeholderów znajdujących się na slajdach układu i master.

```cs
using (Presentation presentation = new Presentation("sample.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobierz efekty animacji kształtu na normalnym slajdzie.
    IShape shape = slide.Shapes[0];
    IEffect[] shapeEffects = slide.Timeline.MainSequence.GetEffectsByShape(shape);

    // Pobierz efekty animacji placeholdera na slajdzie układu.
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
```
```cs
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

## **Zmieniaj właściwości czasu efektu animacji**

Aspose.Slides dla .NET umożliwia zmianę właściwości Timing efektu animacji.

To jest panel Timing animacji i rozszerzone menu w Microsoft PowerPoint:

![Panel Timing animacji](shape-animation.png)

Oto odpowiedniki pomiędzy Timingiem w PowerPoint a właściwościami [Effect.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/properties/timing):

- Rozwijana lista **Start** w PowerPoint Timing odpowiada właściwości [Effect.Timing.TriggerType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/triggertype).
- PowerPoint Timing **Duration** odpowiada właściwości [Effect.Timing.Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/duration). Czas trwania animacji (w sekundach) to całkowity czas potrzebny animacji na wykonanie jednego cyklu. 
- PowerPoint Timing **Delay** odpowiada właściwości [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/properties/triggerdelaytime). 
- Rozwijana lista **Repeat** w PowerPoint Timing odpowiada następującym właściwościom: 
  * * właściwość [Effect.Timing.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount) opisująca *liczbę* powtórzeń efektu;
  * * flaga [Effect.Timing.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide) określająca, czy efekt jest powtarzany do końca slajdu;
  * * flaga [Effect.Timing.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick) określająca, czy efekt jest powtarzany do następnego kliknięcia.
- Pole wyboru **Rewind when done playing** w PowerPoint Timing odpowiada właściwości [Effect.Timing.Rewind](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/rewind/). 

Oto jak zmienić właściwości Timing efektu:

1. [Apply](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw nowe wartości właściwości [Effect.Timing](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/properties/timing), które są potrzebne. 
3. Zapisz zmodyfikowany plik PPTX.

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
    // Pobiera główną sekwencję slajdu.
    ISequence sequence = pres.Slides[0].Timeline.MainSequence;

    // Pobiera pierwszy efekt głównej sekwencji.
    IEffect effect = sequence[0];

    // Zmienia TriggerType efektu na start po kliknięciu
    effect.Timing.TriggerType = EffectTriggerType.OnClick;

    // Zmienia czas trwania efektu
    effect.Timing.Duration = 3f;

    // Zmienia TriggerDelayTime efektu
    effect.Timing.TriggerDelayTime = 0.5f;

    // Jeśli wartość Repeat efektu to "none"
    if (effect.Timing.RepeatCount == 1f)
    {
        // Zmienia Repeat efektu na "Until Next Click"
        effect.Timing.RepeatUntilNextClick = true;
    }
    else
    {
        // Zmienia Repeat efektu na "Until End of Slide"
        effect.Timing.RepeatUntilEndSlide = true;
    }

    // Włącza Rewind efektu
        effect.Timing.Rewind = true;
    
    // Zapisuje plik PPTX na dysku
    pres.Save("AnimExample_changed.pptx", SaveFormat.Pptx);
}
```

## **Dźwięk efektu animacji**

Aspose.Slides udostępnia te właściwości, aby umożliwić pracę z dźwiękami w efektach animacji: 
- [IEffect.Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/sound/) 
- [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/stopprevioussound/) 

### **Dodaj dźwięk efektu animacji**

Ten kod C# pokazuje, jak dodać dźwięk efektu animacji i zatrzymać go, gdy zacznie się kolejny efekt:

```c#
using (Presentation pres = new Presentation("AnimExample_out.pptx"))
{
	// Dodaje dźwięk do kolekcji dźwięków prezentacji
	IAudio effectSound = pres.Audios.AddAudio(File.ReadAllBytes("sampleaudio.wav"));

	ISlide firstSlide = pres.Slides[0];

	// Pobiera główną sekwencję slajdu.
	ISequence sequence = firstSlide.Timeline.MainSequence;

	// Pobiera pierwszy efekt głównej sekwencji
	IEffect firstEffect = sequence[0];

	// Sprawdza efekt pod kątem braku dźwięku
	if (!firstEffect.StopPreviousSound && firstEffect.Sound == null)
	{
		// Dodaje dźwięk do pierwszego efektu
		firstEffect.Sound = effectSound;
	}

	// Pobiera pierwszą interaktywną sekwencję slajdu.
	ISequence interactiveSequence = firstSlide.Timeline.InteractiveSequences[0];

	// Ustawia flagę efektu „Stop previous sound”
	interactiveSequence[0].StopPreviousSound = true;

	// Zapisuje plik PPTX na dysku
	pres.Save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
}
```

### **Wyodrębnij dźwięk efektu animacji**

1. Utwórz instancję klasy [Presentation](https://reference.aspose.com/slides/pl/net/aspose.slides/presentation/).
2. Uzyskaj referencję do slajdu przez jego indeks.
3. Uzyskaj główną sekwencję efektów.
4. Wyodrębnij [Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effect/sound/) osadzony w każdym efekcie animacji. 

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
using (Presentation presentation = new Presentation("EffectSound.pptx"))
{
    ISlide slide = presentation.Slides[0];

    // Pobiera główną sekwencję slajdu.
    ISequence sequence = slide.Timeline.MainSequence;

    foreach (IEffect effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        // Wyodrębnia dźwięk efektu jako tablicę bajtów
        byte[] audio = effect.Sound.BinaryData;
    }
}
```

## **Po animacji**

Aspose.Slides dla .NET umożliwia zmianę właściwości After animation efektu animacji.

To jest panel efektu animacji i rozszerzone menu w Microsoft PowerPoint:

![Panel efektu animacji](shape-after-animation.png)

Rozwijana lista **After animation** w PowerPoint odpowiada następującym właściwościom: 

- właściwość [IEffect.AfterAnimationType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationtype/) opisująca typ po animacji:
  * PowerPoint **More Colors** odpowiada typowi [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Don't Dim** odpowiada typowi [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/) (domyślny typ po animacji);
  * PowerPoint **Hide After Animation** odpowiada typowi [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
  * PowerPoint **Hide on Next Mouse Click** odpowiada typowi [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/);
- właściwość [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationcolor/) definiująca format koloru po animacji. Działa ona wraz z typem [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/). Jeśli zmienisz typ na inny, kolor po animacji zostanie usunięty.

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji
using (Presentation pres = new Presentation("AnimImage_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Pobiera pierwszy efekt głównej sekwencji
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

Aspose.Slides udostępnia te właściwości, aby umożliwić pracę z blokiem *Animate text* efektu animacji:

- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) opisująca typ animacji tekstu efektu. Tekst kształtu może być animowany:
  - Wszystko jednocześnie ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
  - Słowo po słowie ([AnimateTextType.ByWord](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
  - Litera po literze ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/animatetexttype/) typ)
- [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ustawia opóźnienie pomiędzy częściami animowanego tekstu (słowami lub literami). Wartość dodatnia określa procent czasu trwania efektu. Wartość ujemna określa opóźnienie w sekundach.

1. [Apply](#apply-animation-to-shape) lub pobierz efekt animacji.
2. Ustaw właściwość [IEffect.TextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itextanimation/buildtype/) na wartość [BuildType.AsOneObject], aby wyłączyć tryb animacji *By Paragraphs*.
3. Ustaw nowe wartości właściwości [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) i [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/).
4. Zapisz zmodyfikowany plik PPTX.

```c#
// Tworzy instancję klasy prezentacji, która reprezentuje plik prezentacji.
using (Presentation pres = new Presentation("AnimTextBox_out.pptx"))
{
    ISlide firstSlide = pres.Slides[0];

    // Pobiera pierwszy efekt głównej sekwencji
    IEffect firstEffect = firstSlide.Timeline.MainSequence[0];

    // Zmienia typ animacji tekstu efektu na "As One Object"
    firstEffect.TextAnimation.BuildType = BuildType.AsOneObject;

    // Zmienia typ animacji tekstu efektu na "By word"
    firstEffect.AnimateTextType = AnimateTextType.ByWord;

    // Ustawia opóźnienie między słowami na 20% czasu trwania efektu
    firstEffect.DelayBetweenTextParts = 20f;

    // Zapisuje plik PPTX na dysku
    pres.Save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**Jak mogę zapewnić, że animacje zostaną zachowane przy publikowaniu prezentacji w sieci?**

[Export to HTML5](/slides/pl/net/export-to-html5/) i włącz opcje [options](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/) odpowiedzialne za [shape](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) i [transition](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/) animacje. Zwykły HTML nie odtwarza animacji slajdów, natomiast HTML5 tak.

**Jak zmiana kolejności warstw (z-order) kształtów wpływa na animację?**

Animacja i kolejność rysowania są od siebie niezależne: efekt kontroluje czas i typ pojawiania/zanikania, podczas gdy [z-order](https://reference.aspose.com/slides/pl/net/aspose.slides/shape/zorderposition/) określa, co co zasłania. Widoczny rezultat jest określany przez ich kombinację. (To ogólne zachowanie PowerPoint; model efektów i kształtów Aspose.Slides działa tak samo.)

**Czy istnieją ograniczenia przy konwertowaniu animacji do wideo dla niektórych efektów?**

Ogólnie [animacje są obsługiwane](/slides/pl/net/convert-powerpoint-to-video/), ale rzadkie przypadki lub specyficzne efekty mogą być renderowane inaczej. Zaleca się testowanie używanych efektów oraz wersji biblioteki.