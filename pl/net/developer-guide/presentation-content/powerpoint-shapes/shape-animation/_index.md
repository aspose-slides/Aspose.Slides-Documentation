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
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, ich czas, dźwięki, zachowanie po animacji oraz animowany tekst przy użyciu Aspose.Slides dla .NET."
---
## **Przegląd**

Aspose.Slides dla .NET reprezentuje animacje slajdów jako efekty na osi czasu slajdu. Efekt posiada docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po zakończeniu animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarzana jest podczas przechodzenia do kolejnego slajdu.  
- **Interaktywna sekwencja** rozpoczyna się, gdy jej kształt wyzwalający zostanie kliknięty.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu implementują [IShape](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/), używasz tej samej metody [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) dla większości treści slajdu. Dostępne efekty są wymienione w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttype/).

## **Dodawanie animacji kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Aby uzyskać efekt, który zaczyna się po kliknięciu innego kształtu, utwórz interaktywną sekwencję, którego wyzwalaczem jest ten inny kształt.

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

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) oczekuje na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w interaktywnej sekwencji.  
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) rozpoczyna się razem z poprzedzającym efektem.  
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/effecttriggertype/) rozpoczyna się po zakończeniu poprzedzającego efektu.

Aby animować obraz, wykres lub inny rodzaj kształtu, przekaż ten obiekt do [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/) zamiast `targetShape`. Opcje grupowania specyficzne dla wykresów znajdziesz w [Animated Charts](/slides/pl/net/animated-charts/).

## **Odczytywanie animacji kształtów**

Użyj [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/geteffectsbyshape/) gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, wyliczaj główną sekwencję oraz wszystkie interaktywne sekwencje. Wyliczanie unika założenia, że sekwencja zawiera efekt pod indeksem `0`.

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

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie placeholdera lub innej stabilnej właściwości; następnie wywołaj [ISequence.GetEffectsByShape](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/geteffectsbyshape/). Nie zakładaj, że [IShapeCollection.Item](https://reference.aspose.com/slides/pl/net/aspose.slides/ishapecollection/item/) pod indeksem `0` jest zawsze pożądanym obiektem.

## **Praca z odziedziczonymi efektami dla elementów zastępczych**

Placeholder na normalnym slajdzie może odziedziczyć zachowanie animacji z odpowiedniego placeholdera na slajdzie układu i slajdzie wzorca. [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/) zwraca ten nadrzędny placeholder lub `null`, gdy nie ma nadrzędnego elementu.

W poniższej przykładowej prezentacji stopka ma **Random Bars** na normalnym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie wzorca.

![Efekt animacji stopki na normalnym slajdzie](slide-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie wzorca](master-shape-animation.png)

Następny przykład buduje samą hierarchię placeholderów. Dodaje efekty do placeholdera wzorca, placeholdera układu i odpowiadającego placeholdera na normalnym slajdzie. Każde wywołanie [IShape.GetBasePlaceholder](https://reference.aspose.com/slides/pl/net/aspose.slides/ishape/getbaseplaceholder/) jest sprawdzane przed użyciem zwróconego kształtu.

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

## **Zmiana czasu trwania animacji**

Dialog PowerPoint **Timing** odpowiada właściwościom [ITiming](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/).

![Okno dialogowe Timing w PowerPoint dla efektu animacji](shape-animation.png)

- **Start** odpowiada [ITiming.TriggerType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/triggertype/).  
- **Duration** odpowiada [ITiming.Duration](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/duration/), w sekundach.  
- **Delay** odpowiada [ITiming.TriggerDelayTime](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/triggerdelaytime/), w sekundach.  
- **Repeat** odpowiada [ITiming.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount/), [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick/) lub [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide/).  
- **Rewind when done playing** odpowiada [ITiming.Rewind](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/rewind/).

Ten niezależny przykład dodaje efekt, zmienia jego czas przy użyciu obiektu zwróconego przez [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), i zapisuje wynik. Przechowywanie odniesienia do zwróconego [IEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/) zapobiega niepotrzebnemu indeksowaniu kolekcji.

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

Używaj jednego trybu powtarzania celowo. Łączenie liczby powtórzeń z flagą „until” może prowadzić do mylących rezultatów w różnych odtwarzaczach. Przy zmianie trybów powtarzania ustaw najpierw [ITiming.RepeatUntilNextClick](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilnextclick/) i [ITiming.RepeatUntilEndSlide](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatuntilendslide/), a dopiero potem [ITiming.RepeatCount](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itiming/repeatcount/), ponieważ ustawienie którejkolwiek flagi zmienia aktywny tryb powtarzania.

## **Dodanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku przez [IEffect.Sound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/sound/). [IEffect.StopPreviousSound](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/stopprevioussound/) nakazuje efektowi zatrzymać dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodanie dźwięku do efektu**

Poniższy przykład zakłada, że w lokalnym katalogu znajduje się plik audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk pierwszego efektu i konfiguruje drugi efekt do zatrzymania dźwięku. Używa obiektów zwróconych przez [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), więc nie jest wymagany indeks sekwencji.

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

### **Wyodrębnianie wbudowanych dźwięków efektów**

Poniższy przykład zakłada, że w lokalnym katalogu znajduje się prezentacja o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główne, jak i interaktywne sekwencje i zapisuje każdy wbudowany dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio udostępnianego przez [IAudio.ContentType](https://reference.aspose.com/slides/pl/net/aspose.slides/iaudio/contenttype/).

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

## **Ustawienie zachowania po animacji**

Opcja **After animation** kontroluje, co się stanie z kształtem po zakończeniu jego efektu.

![Okno dialogowe opcji efektu PowerPoint pokazujące ustawienia After animation](shape-after-animation.png)

Wyliczenie [AfterAnimationType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/) obsługuje pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typ jest [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/afteranimationtype/), ustaw także [IEffect.AfterAnimationColor](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/afteranimationcolor/).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji przy użyciu zwróconego obiektu efektu i zapisuje wynik.

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

## **Animowanie tekstu**

Animacja tekstu posiada dwa powiązane elementy sterujące:

- [ITextAnimation.BuildType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/itextanimation/buildtype/) kontroluje, czy akapity pojawiają się razem, czy poziomowo.  
- [IEffect.AnimateTextType](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/animatetexttype/) kontroluje, czy tekst pojawia się jednorazowo, słowo po słowie lub litera po literze. [IEffect.DelayBetweenTextParts](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/ieffect/delaybetweentextparts/) ustawia opóźnienie między słowami lub literami. Wartość dodatnia to procent czasu trwania efektu; wartość ujemna to opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype/) wyłącza budowanie akapitu po akapicie, tak aby ustawienie słowa dotyczyło całej ramki tekstowej.

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

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/buildtype/) (lub inny poziom akapitu). Aby skierować pojedynczy akapit własnym efektem, użyj przeciążenia [ISequence.AddEffect](https://reference.aspose.com/slides/pl/net/aspose.slides.animation/isequence/addeffect/), które przyjmuje [IParagraph](https://reference.aspose.com/slides/pl/net/aspose.slides/iparagraph/). Zobacz [Animated Text](/slides/pl/net/animated-text/) po przykłady na poziomie akapitu.

## **Uwagi dotyczące eksportu i zgodności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie jest kontrolowane przez przeglądarkę prezentacji.  
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [eksportu HTML5](/slides/pl/net/export-to-html5/), animowanego GIF-a lub [konwersji wideo](/slides/pl/net/convert-powerpoint-to-video/), gdy wynik musi pokazywać ruch.  
- Dla HTML5 włącz [Html5Options.AnimateShapes](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animateshapes/) oraz, w razie potrzeby, [Html5Options.AnimateTransitions](https://reference.aspose.com/slides/pl/net/aspose.slides.export/html5options/animatetransitions/).  
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie każdy efekt PowerPoint jest obsługiwany. Sprawdź aktualną [listę obsługiwanych animacji i efektów](/slides/pl/net/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje z wybraną wersją Aspose.Slides.  
- Zaawansowane efekty niestandardowe oraz efekty zaimportowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderowane inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany wynik, a nie tylko nazwę efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, ale nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF-a lub wideo, gdy ruch musi być zachowany.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywania oryginalnego zachowania PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem produkcyjnym.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się, natomiast kolejność sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmień oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.