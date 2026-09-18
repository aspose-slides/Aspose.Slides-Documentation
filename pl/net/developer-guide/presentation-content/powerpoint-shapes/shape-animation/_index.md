---
title: "Zastosowanie animacji kształtów w prezentacjach w .NET"
linktitle: "Animacja kształtu"
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
description: "Dowiedz się, jak dodawać, sprawdzać i dostosowywać animacje kształtów, synchronizację, dźwięki, zachowanie po animacji oraz animowany tekst przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aby pracować z pojedynczymi zachowaniami wewnątrz efektu lub edytować segmenty ścieżek ruchu, zobacz [Niestandardowa animacja](/slides/pl/net/custom-animation/).

Aspose.Slides for .NET reprezentuje animacje slajdów jako efekty na osi czasu slajdu. Efekt posiada docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po zakończeniu animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarzana jest podczas przechodzenia slajdu.
- **Sekwencja interaktywna** rozpoczyna się po kliknięciu jej kształtu wyzwalacza.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu implementują [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), używasz tej samej metody [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) dla większości treści slajdu. Dostępne efekty są wymienione w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype/).

## **Dodaj animacje kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Dla efektu, który rozpoczyna się po kliknięciu innego kształtu, utwórz sekwencję interaktywną, której wyzwalaczem jest ten inny kształt.

Poniższy przykład tworzy oba typy animacji i zapisuje wynik do `shape-animations.pptx`.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var targetShape = slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Click to animate this shape";

var mainSequence = slide.Timeline.MainSequence;
var entranceEffect = mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
entranceEffect.Timing.Duration = 1.5f;

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

presentation.Save("shape-animations.pptx", SaveFormat.Pptx);
```

Wyzwalacz kontroluje, kiedy efekt się rozpoczyna:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) oczekuje na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalacza w sekcji interaktywnej.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) rozpoczyna się razem z poprzednim efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) rozpoczyna się po zakończeniu poprzedniego efektu.

Aby animować obraz, wykres lub inny typ kształtu, przekaż ten obiekt do [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) zamiast `targetShape`. Opcje grupowania specyficzne dla wykresów znajdziesz w [Animated Charts](/slides/pl/net/animated-charts/).

## **Odczyt animacji kształtów**

Użyj [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/geteffectsbyshape/) gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, wyliczaj główną sekwencję oraz wszystkie sekwencje interaktywne. Wyliczanie zapobiega zakładaniu, że sekwencja zawiera efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej i interaktywnej sekwencji, pobiera efekty skierowane do tego kształtu, a następnie wylicza wszystkie sekwencje na slajdzie.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var targetShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
targetShape.TextFrame.Text = "Animated shape";

var mainSequence = slide.Timeline.MainSequence;
mainSequence.AddEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var triggerShape = slide.Shapes.AddAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
triggerShape.TextFrame.Text = "Move";

var interactiveSequence = slide.Timeline.InteractiveSequences.Add(triggerShape);
interactiveSequence.AddEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

var targetEffects = mainSequence.GetEffectsByShape(targetShape);
Console.WriteLine($"The main sequence contains {targetEffects.Length} effect(s) for {targetShape.Name}.");

PrintSequence("Main sequence", mainSequence);

var interactiveIndex = 1;
foreach (var sequence in slide.Timeline.InteractiveSequences)
{
    var triggerName = sequence.TriggerShape == null ? "unknown" : sequence.TriggerShape.Name;
    var sequenceLabel = $"Interactive sequence {interactiveIndex}, trigger: {triggerName}";
    PrintSequence(sequenceLabel, sequence);
    interactiveIndex++;
}

static void PrintSequence(string label, ISequence sequence)
{
    Console.WriteLine($"  {label}: {sequence.Count} effect(s)");

    foreach (var effect in sequence)
    {
        var targetName = effect.TargetShape == null ? "unknown" : effect.TargetShape.Name;
        var effectDescription = $"{effect.Type} {effect.Subtype}; target: {targetName}; trigger: {effect.Timing.TriggerType}";
        Console.WriteLine($"    {effectDescription}");
    }
}
```

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie pola zastępczego lub innej stałej właściwości; następnie wywołaj [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/geteffectsbyshape/). Nie zakładaj, że [IShapeCollection.Item](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/item/) pod indeksem `0` zawsze jest zamierzonym obiektem.

## **Praca z dziedziczonymi efektami zastępczymi**

Pole zastępcze na zwykłym slajdzie może dziedziczyć zachowanie animacji z odpowiedniego pola zastępczego na slajdzie układu i slajdzie głównym. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/) zwraca ten nadrzędny placeholder lub `null`, gdy nie ma rodzica.

W poniższej przykładowej prezentacji stopka ma **Random Bars** na zwykłym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie głównym.

![Efekt animacji stopki na zwykłym slajdzie](slide-shape-animation.png)

![Efekt animacji pola zastępczego stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji pola zastępczego stopki na slajdzie głównym](master-shape-animation.png)

Następny przykład tworzy samą hierarchię pól zastępczych. Dodaje efekty do pola zastępczego głównego, pola zastępczego układu i odpowiadającego pola zastępczego na zwykłym slajdzie. Każde wywołanie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/) jest sprawdzane przed użyciem zwróconego kształtu.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var layoutSlide = presentation.LayoutSlides.GetByType(SlideLayoutType.Blank);
var layoutPlaceholder = layoutSlide.PlaceholderManager.AddTextPlaceholder(100, 100, 400, 80);
layoutSlide.Timeline.MainSequence.AddEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

var masterPlaceholder = layoutPlaceholder.GetBasePlaceholder();
if (masterPlaceholder != null)
{
    var masterSequence = layoutSlide.MasterSlide.Timeline.MainSequence;
    masterSequence.AddEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
}

var slide = presentation.Slides.AddEmptySlide(layoutSlide);
var slidePlaceholder = FindPlaceholderWithBase(slide);

if (slidePlaceholder == null)
{
    throw new InvalidOperationException("The slide does not contain a placeholder linked to its layout slide.");
}

slide.Timeline.MainSequence.AddEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
PrintEffects("Normal slide", slide.Timeline.MainSequence.GetEffectsByShape(slidePlaceholder));

var baseLayoutPlaceholder = slidePlaceholder.GetBasePlaceholder();
if (baseLayoutPlaceholder != null)
{
    PrintEffects("Layout slide", layoutSlide.Timeline.MainSequence.GetEffectsByShape(baseLayoutPlaceholder));

    var baseMasterPlaceholder = baseLayoutPlaceholder.GetBasePlaceholder();
    if (baseMasterPlaceholder != null)
    {
        PrintEffects("Master slide", layoutSlide.MasterSlide.Timeline.MainSequence.GetEffectsByShape(baseMasterPlaceholder));
    }
}

presentation.Save("placeholder-animations.pptx", SaveFormat.Pptx);

static IShape FindPlaceholderWithBase(ISlide slide)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape.GetBasePlaceholder() != null)
        {
            return shape;
        }
    }

    return null;
}

static void PrintEffects(string source, IEffect[] effects)
{
    Console.WriteLine($"{source}: {effects.Length} effect(s)");

    foreach (var effect in effects)
    {
        Console.WriteLine($"  {effect.Type} {effect.Subtype}");
    }
}
```

## **Zmień synchronizację animacji**

Dialog PowerPoint **Timing** odpowiada właściwościom [ITiming](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/).

![Dialog Timing programu PowerPoint dla efektu animacji](shape-animation.png)

- **Start** odpowiada [ITiming.TriggerType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/triggertype/).
- **Duration** odpowiada [ITiming.Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/duration/), w sekundach.
- **Delay** odpowiada [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/triggerdelaytime/), w sekundach.
- **Repeat** odpowiada [ITiming.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick/), lub [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide/).
- **Rewind when done playing** odpowiada [ITiming.Rewind](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/rewind/).

Ten niezależny przykład dodaje efekt, zmienia jego synchronizację za pomocą obiektu zwróconego przez [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), i zapisuje wynik. Przechowywanie zwróconego odniesienia do [IEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/) unika niepotrzebnego indeksu kolekcji.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Timed animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.Timing.TriggerType = EffectTriggerType.OnClick;
effect.Timing.Duration = 2.0f;
effect.Timing.TriggerDelayTime = 0.5f;
effect.Timing.RepeatUntilNextClick = false;
effect.Timing.RepeatUntilEndSlide = false;
effect.Timing.RepeatCount = 2.0f;
effect.Timing.Rewind = true;

presentation.Save("shape-animation-timing.pptx", SaveFormat.Pptx);
```

Używaj jednego trybu powtarzania świadomie. Łączenie liczby powtórzeń z flagą „until” może dawać mylące wyniki w różnych odtwarzaczach. Przy zmianie trybów powtarzania najpierw ustaw [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick/) i [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide/), a dopiero potem [ITiming.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount/), ponieważ ustawienie którejkolwiek flagi zmienia również aktywny tryb powtarzania.

## **Dodaj i wyodrębnij dźwięki animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku poprzez [IEffect.Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/stopprevioussound/) instruuje efekt, aby zatrzymał dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład zakłada lokalny plik audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk pierwszego efektu i konfiguruje drugi efekt, aby zatrzymał dźwięk. Używa obiektów zwróconych przez [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), więc nie jest wymagany indeks sekwencji.

```csharp
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var firstShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
var secondShape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
firstShape.TextFrame.Text = "Starts sound";
secondShape.TextFrame.Text = "Stops sound";

var sequence = slide.Timeline.MainSequence;
var firstEffect = sequence.AddEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
var secondEffect = sequence.AddEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

var audioData = File.ReadAllBytes("animation-sound.wav");
var effectSound = presentation.Audios.AddAudio(audioData);
firstEffect.Sound = effectSound;
secondEffect.StopPreviousSound = true;

presentation.Save("shape-animation-sound.pptx", SaveFormat.Pptx);
```

### **Wyodrębnij osadzone dźwięki efektów**

Poniższy przykład zakłada lokalną prezentację o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główne, jak i interaktywne sekwencje i zapisuje każdy osadzony dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio udostępnionego przez [IAudio.ContentType](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudio/contenttype/).

```csharp
using System;
using System.IO;
using Aspose.Slides;
using Aspose.Slides.Animation;

var inputPath = "presentation-with-animation-sounds.pptx";
var outputDirectory = "extracted-animation-sounds";

Directory.CreateDirectory(outputDirectory);

using var presentation = new Presentation(inputPath);
var soundIndex = 1;

foreach (var slide in presentation.Slides)
{
    SaveSounds(slide.Timeline.MainSequence, outputDirectory, ref soundIndex);

    foreach (var sequence in slide.Timeline.InteractiveSequences)
    {
        SaveSounds(sequence, outputDirectory, ref soundIndex);
    }
}

Console.WriteLine($"Extracted {soundIndex - 1} sound file(s) to {Path.GetFullPath(outputDirectory)}.");

static void SaveSounds(ISequence sequence, string outputDirectory, ref int soundIndex)
{
    foreach (var effect in sequence)
    {
        if (effect.Sound == null)
            continue;

        var extension = GetAudioExtension(effect.Sound.ContentType);
        var outputPath = Path.Combine(outputDirectory, $"effect-sound-{soundIndex}{extension}");
        File.WriteAllBytes(outputPath, effect.Sound.BinaryData);
        soundIndex++;
    }
}

static string GetAudioExtension(string contentType)
{
    var normalizedType = contentType == null ? string.Empty : contentType.ToLowerInvariant();

    if (normalizedType == "audio/mpeg")
        return ".mp3";

    if (normalizedType == "audio/mp4")
        return ".m4a";

    if (normalizedType == "audio/ogg")
        return ".ogg";

    if (normalizedType == "audio/wav" || normalizedType == "audio/x-wav")
        return ".wav";

    return ".bin";
}
```

Dla dużych obiektów audio użyj [IAudio.GetStream](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudio/getstream/) i skopiuj strumień do pliku zamiast ładować cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** kontroluje, co dzieje się z kształtem po zakończeniu jego efektu.

![Dialog opcji efektu PowerPoint pokazujący ustawienia After animation](shape-after-animation.png)

Wyliczenie [AfterAnimationType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/) obsługuje pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typem jest [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/), ustaw również [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji za pomocą zwróconego obiektu efektu i zapisuje wynik.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
shape.TextFrame.Text = "Dim after animation";

var effect = slide.Timeline.MainSequence.AddEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.AfterAnimationType = AfterAnimationType.Color;
effect.AfterAnimationColor.Color = Color.LightGray;

presentation.Save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
```

Zmiana typu z [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/) usuwa ustawienie koloru po animacji.

## **Animuj tekst**

Animacja tekstu posiada dwa powiązane sterowania:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itextanimation/buildtype/) kontroluje, czy akapity pojawiają się razem, czy poziom po poziomie.
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) kontroluje, czy tekst pojawia się jednocześnie, słowo po słowie lub litera po literze. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ustawia opóźnienie między słowami lub literami. Dodatnia wartość jest procentem czasu trwania efektu; wartość ujemna oznacza opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype/) wyłącza budowanie akapit po akapicie, tak aby ustawienie słowa dotyczyło całej ramki tekstowej.

```csharp
using Aspose.Slides;
using Aspose.Slides.Animation;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
textBox.TextFrame.Text = "Aspose.Slides animates this sentence word by word.";

var effect = slide.Timeline.MainSequence.AddEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
effect.TextAnimation.BuildType = BuildType.AsOneObject;
effect.AnimateTextType = AnimateTextType.ByWord;
effect.DelayBetweenTextParts = 20.0f;

presentation.Save("animated-text.pptx", SaveFormat.Pptx);
```

Aby zbudować pole tekstowe akapit po akapicie, ustaw [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype/) (lub inny poziom akapitu). Aby skierować pojedynczy akapit do własnego efektu, użyj przeciążenia [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), które przyjmuje [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/). Zobacz [Animated Text](/slides/pl/net/animated-text/) po przykłady na poziomie akapitu.

## **Uwagi dotyczące eksportu i kompatybilności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie jest kontrolowane przez przeglądarkę prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [HTML5 export](/slides/pl/net/export-to-html5/), animowanego GIF‑a lub [konwersji wideo](/slides/pl/net/convert-powerpoint-to-video/), gdy wyjście musi pokazywać ruch.
- Dla HTML5 włącz [Html5Options.AnimateShapes](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) i w razie potrzeby [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie każdy efekt PowerPoint jest obsługiwany. Sprawdź aktualną listę [obsługiwanych animacji i efektów](/slides/pl/net/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje w docelowej wersji Aspose.Slides.
- Zaawansowane efekty niestandardowe oraz efekty importowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderowane inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany rezultat zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, ale nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF‑a lub wideo, gdy ruch musi zostać zachowany.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem produkcyjnym.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się elementów, natomiast kolejność w sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmień oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.