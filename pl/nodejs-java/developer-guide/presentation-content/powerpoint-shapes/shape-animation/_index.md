---
title: Zastosowanie animacji kształtów w prezentacjach przy użyciu JavaScript
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/nodejs-java/shape-animation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, ich czasy, dźwięki, zachowanie po animacji oraz animowany tekst przy użyciu Aspose.Slides dla Node.js via Java."
---
## **Przegląd**

Aspose.Slides for Node.js via Java reprezentuje animacje slajdów jako efekty na osi czasu slajdu. Efekt ma docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po zakończeniu animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarzana jest w miarę przechodzenia do kolejnego slajdu.
- **Sekwencja interaktywna** rozpoczyna się po kliknięciu kształtu wyzwalającego.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu są obiektami [Shape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/), używasz tej samej metody [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect) dla większości zawartości slajdu. Dostępne efekty są wymienione w wyliczeniu [EffectType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttype/).

## **Dodawanie animacji kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Dla efektu, który rozpoczyna się po kliknięciu innego kształtu, utwórz sekwencję interaktywną, której wyzwalaczem jest ten drugi kształt.

Poniższy przykład tworzy oba typy animacji i zapisuje wynik do `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Wyzwalacz określa, kiedy efekt się rozpoczyna:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttriggertype/#OnClick) czeka na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w sekwencji interaktywnej.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) rozpoczyna się razem z poprzedzającym efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) rozpoczyna się po zakończeniu poprzedzającego efektu.

Aby animować obraz, wykres lub inny typ kształtu, przekaż ten obiekt do [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect) zamiast `targetShape`. Opcje grupowania specyficzne dla wykresów znajdziesz w sekcji [Animated Charts](/slides/pl/nodejs-java/animated-charts/).

## **Odczyt animacji kształtów**

Użyj [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#getEffectsByShape), gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, enumeruj główną sekwencję i wszystkie sekwencje interaktywne. Enumeracja zapobiega zakładaniu, że sekwencja zawiera efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej i interaktywnej sekwencji, pobiera efekty skierowane do tego kształtu, a następnie enumeruje wszystkie sekwencje na slajdzie.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj go po nazwie, typie pola zastępczego lub innej stabilnej właściwości; potem wywołaj [Sequence.getEffectsByShape](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Nie zakładaj, że [ShapeCollection.get_Item](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shapecollection/#get_Item) pod indeksem `0` zawsze jest pożądanym obiektem.

## **Praca z dziedziczonymi efektami pól zastępczych**

Pole zastępcze na normalnym slajdzie może dziedziczyć zachowanie animacji z odpowiadającego mu pola zastępczego na slajdzie układu i slajdzie master. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) zwraca ten nadrzędny placeholder lub `null`, gdy nie istnieje rodzic.

W przykładzie prezentacji stopka ma **Random Bars** na normalnym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie master.

![Stopka animacja efekt na normalnym slajdzie](slide-shape-animation.png)

![Stopka animacja efekt na slajdzie układu](layout-shape-animation.png)

![Stopka animacja efekt na slajdzie master](master-shape-animation.png)

Następny przykład używa hierarchii placeholderów z nowej prezentacji. Dodaje efekty do placeholdera w masterze, placeholdera w układzie oraz odpowiadającego mu placeholdera na normalnym slajdzie. Każde wywołanie [Shape.getBasePlaceholder](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/shape/#getBasePlaceholder) jest sprawdzane przed użyciem zwróconego kształtu.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Zmiana czasu trwania animacji**

Dialog PowerPoint **Timing** odpowiada właściwościom klasy [Timing](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/).

![Okno dialogowe PowerPoint Timing dla efektu animacji](shape-animation.png)

- **Start** mapuje na [Timing.getTriggerType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** mapuje na [Timing.getDuration](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getDuration) w sekundach.
- **Delay** mapuje na [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) w sekundach.
- **Repeat** mapuje na [Timing.getRepeatCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) lub [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** mapuje na [Timing.getRewind](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#getRewind).

Ten niezależny przykład dodaje efekt, zmienia jego czas przy użyciu obiektu zwróconego przez [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect) i zapisuje wynik. Przechowywanie zwróconego odwołania do [Effect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/) eliminuje potrzebę niepotrzebnego indeksu kolekcji.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Używaj jednego trybu powtórzeń świadomie. Łączenie liczby powtórzeń z flagą „until” może dawać mylące wyniki w różnych odtwarzaczach. Przy zmianie trybu powtórzeń ustaw najpierw [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) i [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide), a dopiero potem [Timing.setRepeatCount](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/timing/#setRepeatCount), ponieważ ustawienie którejkolwiek flagi zmienia aktywny tryb powtórzeń.

## **Dodawanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego audio poprzez [Effect.getSound](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#setStopPreviousSound) instruuje efekt, aby zatrzymał dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład wymaga lokalnego pliku audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk dla pierwszego efektu i konfiguruje drugi efekt, aby zatrzymał dźwięk. Używa obiektów zwróconych przez [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect), więc indeks sekwencji nie jest potrzebny.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Wyodrębnij osadzone dźwięki efektów**

Poniższy przykład wymaga lokalnej prezentacji o nazwie `presentation-with-animation-sounds.pptx`. Przeszukuje zarówno główną, jak i interaktywną sekwencję oraz zapisuje każdy osadzony dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio zwracanego przez [Audio.getContentType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Dla dużych obiektów audio użyj [Audio.getStream](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/audio/#getStream) i skopiuj strumień do pliku zamiast wczytywać cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** określa, co się stanie z kształtem po zakończeniu jego efektu.

![Okno dialogowe PowerPoint Effect Options pokazujące ustawienia After animation](shape-after-animation.png)

Wyliczenie [AfterAnimationType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/) umożliwia pozostawienie kształtu niezmienionym, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typ jest [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#Color), ustaw także [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji poprzez zwrócony obiekt efektu i zapisuje wynik.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Zmiana typu z [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/afteranimationtype/#Color) usuwa ustawienie koloru po animacji.

## **Animacja tekstu**

Animacja tekstu ma dwa powiązane sterowanie:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/textanimation/#getBuildType) określa, czy akapity pojawiają się razem, czy poziomowo.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getAnimateTextType) określa, czy tekst pojawia się jednocześnie, słowami lub literami. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) ustawia opóźnienie między słowami lub literami. Wartość dodatnia to procent czasu trwania efektu; wartość ujemna to opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/buildtype/#AsOneObject) wyłącza budowanie akapit po akapicie, tak aby ustawienie słowa dotyczyło całej ramki tekstowej.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (lub inny poziom akapitu). Aby zastosować oddzielny efekt do pojedynczego akapitu, użyj przeciążenia [Sequence.addEffect](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/sequence/#addEffect), które przyjmuje [Paragraph](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/paragraph/). Zobacz [Animated Text](/slides/pl/nodejs-java/animated-text/) po przykłady na poziomie akapitu.

## **Uwagi dotyczące eksportu i kompatybilności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie zależy od używanego przeglądarki prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [HTML5 export](/slides/pl/nodejs-java/export-to-html5/), animowanego GIF lub [konwersji wideo](/slides/pl/nodejs-java/convert-powerpoint-to-video/), gdy wyjście musi pokazywać ruch.
- Dla HTML5 włącz [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/#setAnimateShapes) i w razie potrzeby [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pl/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżek ruchu, ale nie wszystkie efekty PowerPoint są obsługiwane. Sprawdź aktualną listę [supported animations and effects](/slides/pl/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje z docelową wersją Aspose.Slides.
- Zaawansowane niestandardowe efekty oraz efekty importowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderować się inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany wynik zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, a nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF lub wideo, gdy konieczne jest zachowanie ruchu.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem w produkcji.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Kolejność warstw (z‑order) kontroluje nakładanie się kształtów, natomiast kolejność sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmień oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.