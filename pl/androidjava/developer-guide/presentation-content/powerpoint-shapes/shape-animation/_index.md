---
title: Zastosuj animacje kształtów w prezentacjach na Androidzie
linktitle: Animacja kształtu
type: docs
weight: 60
url: /pl/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Dowiedz się, jak dodawać, przeglądać i dostosowywać animacje kształtów, czasowanie, dźwięki, zachowanie po animacji oraz animowany tekst przy użyciu Aspose.Slides dla Androida w Javie."
---
## **Przegląd**

Aspose.Slides for Android via Java przedstawia animacje slajdów jako efekty w osi czasu slajdu. Efekt ma docelowy kształt, typ i podtyp animacji, wyzwalacz, ustawienia czasu oraz opcjonalne właściwości, takie jak dźwięk lub zachowanie po animacji.

Oś czasu zawiera dwa rodzaje sekwencji:

- **Główna sekwencja** odtwarza się podczas przechodzenia do kolejnego slajdu.
- **Sekwencja interaktywna** rozpoczyna się, gdy jej kształt wyzwalający zostanie kliknięty.

Ponieważ pola tekstowe, obrazy, wykresy, tabele i inne obiekty slajdu implementują [IShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/), używasz tej samej metody [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) dla większości treści slajdu. Dostępne efekty są wymienione w klasie [EffectType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttype/).

## **Dodaj animacje kształtów**

Aby dodać animację, pobierz główną sekwencję slajdu i wywołaj [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) z docelowym kształtem, typem efektu, podtypem i wyzwalaczem. Aby efekt rozpoczął się po kliknięciu innego kształtu, utwórz sekwencję interaktywną, której wyzwalaczem jest ten inny kształt.

Poniższy przykład tworzy oba rodzaje animacji i zapisuje wynik do `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Wyzwalacz kontroluje, kiedy efekt zaczyna się:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttriggertype/#OnClick) oczekuje na kliknięcie w głównej sekwencji lub na kliknięcie kształtu wyzwalającego w sekwencji interaktywnej.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttriggertype/#WithPrevious) rozpoczyna się wraz z poprzedzającym efektem.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/effecttriggertype/#AfterPrevious) rozpoczyna się po zakończeniu poprzedzającego efektu.

Aby animować obraz, wykres lub inny typ kształtu, przekaż ten obiekt do [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), zamiast `targetShape`. Opcje grupowania specyficzne dla wykresów znajdziesz w [Animated Charts](/slides/pl/androidjava/animated-charts/).

## **Odczyt animacji kształtów**

Użyj [ISequence.getEffectsByShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) gdy znasz docelowy kształt. Aby przejrzeć każdy efekt, wylicz główną sekwencję i każdą sekwencję interaktywną. Wyliczanie zapobiega zakładaniu, że sekwencja zawiera efekt pod indeksem `0`.

Poniższy przykład tworzy kształt z efektami w głównej sekwencji i sekwencji interaktywnej, pobiera efekty skierowane do tego kształtu, a następnie wylicza każdą sekwencję na slajdzie.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Jeśli potrzebujesz efektów tylko dla jednego kształtu, najpierw zidentyfikuj kształt po nazwie, typie placeholdera lub innej stabilnej właściwości; następnie wywołaj [ISequence.getEffectsByShape](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Nie zakładaj, że [IShapeCollection.get_Item](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishapecollection/#get_Item-int-) pod indeksem `0` zawsze jest zamierzonym obiektem.

## **Praca z dziedziczonymi efektami placeholderów**

Placeholder na zwykłym slajdzie może dziedziczyć zachowanie animacji z odpowiadającego mu placeholdera na slajdzie układu i slajdzie głównym. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) zwraca ten nadrzędny placeholder lub `null`, gdy nie istnieje.

W poniższej prezentacji przykład, stopka ma **Random Bars** na zwykłym slajdzie, **Split** na slajdzie układu i **Fly In** na slajdzie głównym.

![Efekt animacji stopki na zwykłym slajdzie](slide-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie układu](layout-shape-animation.png)

![Efekt animacji placeholdera stopki na slajdzie głównym](master-shape-animation.png)

Kolejny przykład używa hierarchii placeholderów z nowej prezentacji. Dodaje efekty do placeholdera głównego, placeholdera układu oraz odpowiadającego mu placeholdera na zwykłym slajdzie. Każde wywołanie [IShape.getBasePlaceholder](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ishape/#getBasePlaceholder--) jest sprawdzane przed użyciem zwróconego kształtu.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Zmienianie czasu trwania animacji**

Okno dialogowe PowerPoint **Timing** odpowiada właściwościom [ITiming](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/).

![Okno dialogowe PowerPoint Timing dla efektu animacji](shape-animation.png)

- **Start** odpowiada [ITiming.getTriggerType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getTriggerType--).
- **Czas trwania** odpowiada [ITiming.getDuration](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getDuration--), w sekundach.
- **Opóźnienie** odpowiada [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getTriggerDelayTime--), w sekundach.
- **Powtórzenie** odpowiada [ITiming.getRepeatCount](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatUntilNextClick--), lub [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Cofnięcie po odtworzeniu** odpowiada [ITiming.getRewind](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#getRewind--).

Ten niezależny przykład dodaje efekt, zmienia jego czas przy użyciu obiektu zwróconego przez [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), i zapisuje wynik. Przechowywanie zwróconego odwołania do [IEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/) unika niepotrzebnego indeksu kolekcji.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Używaj jednego trybu powtórzenia celowo. Łączenie liczby powtórzeń z flagą „until” może powodować mylące wyniki w różnych przeglądarkach. Podczas zmiany trybów powtórzenia najpierw ustaw [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) i [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-), a dopiero potem [ITiming.setRepeatCount](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itiming/#setRepeatCount-float-), ponieważ ustawienie którejkolwiek flagi zmienia aktywny tryb powtórzenia.

## **Dodawanie i wyodrębnianie dźwięków animacji**

Efekt animacji może odwoływać się do osadzonego dźwięku za pomocą [IEffect.getSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) informuje efekt, aby zatrzymał dźwięk rozpoczęty przez wcześniejszy efekt.

### **Dodaj dźwięk do efektu**

Poniższy przykład wymaga lokalnego pliku audio o nazwie `animation-sound.wav`. Tworzy dwa efekty, osadza ten plik jako dźwięk dla pierwszego efektu i konfiguruje drugi efekt, aby zatrzymał dźwięk. Używa obiektów zwróconych przez [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), więc nie jest wymagany indeks sekwencji.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Wyodrębnij osadzone dźwięki efektów**

Poniższy przykład wymaga lokalnej prezentacji o nazwie `presentation-with-animation-sounds.pptx`. Przeskanuje zarówno główne, jak i interaktywne sekwencje i zapisze każdy osadzony dźwięk efektu do katalogu `extracted-animation-sounds`. Rozszerzenie jest wybierane na podstawie typu MIME audio zwracanego przez [IAudio.getContentType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Dla dużych obiektów audio użyj [IAudio.getStream](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iaudio/#getStream--) , aby skopiować strumień do pliku zamiast ładować cały obiekt do tablicy bajtów.

## **Ustaw zachowanie po animacji**

Opcja **After animation** kontroluje, co dzieje się z kształtem po zakończeniu jego efektu.

![Okno dialogowe PowerPoint Effect Options pokazujące ustawienia After animation](shape-after-animation.png)

Klasa [AfterAnimationType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/) obsługuje pozostawienie kształtu niezmienionego, zmianę jego koloru, ukrycie po animacji lub ukrycie przy następnym kliknięciu. Gdy typ jest [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color), ustaw także [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Ten niezależny przykład tworzy efekt, ustawia jego zachowanie po animacji za pomocą zwróconego obiektu efektu i zapisuje wynik.

```java
import com.aspose.slides.*;
import android.graphics.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LTGRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Zmiana typu z [AfterAnimationType.Color](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/afteranimationtype/#Color) usuwa ustawienie koloru po animacji.

## **Animowanie tekstu**

Animacja tekstu ma dwa powiązane elementy sterujące:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/itextanimation/#getBuildType--) kontroluje, czy akapity pojawiają się razem, czy po kolei na poziomie akapitu.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getAnimateTextType--) kontroluje, czy tekst pojawia się jednocześnie, słowami lub literami. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) ustawia opóźnienie między słowami lub literami. Wartość dodatnia to procent czasu trwania efektu; wartość ujemna to opóźnienie w sekundach.

Poniższy niezależny przykład animuje słowa w polu tekstowym. [BuildType.AsOneObject](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/buildtype/#AsOneObject) wyłącza budowanie akapit po akapicie, tak aby ustawienie słowa dotyczyło całej ramki tekstowej.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Aby budować pole tekstowe akapit po akapicie, ustaw [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/buildtype/#ByLevelParagraphs1) (lub inny poziom akapitu). Aby skierować pojedynczy akapit do własnego efektu, użyj przeciążenia [ISequence.addEffect](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) , które przyjmuje [IParagraph](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/iparagraph/). Zobacz [Animated Text](/slides/pl/androidjava/animated-text/) dla przykładów na poziomie akapitu.

## **Uwagi dotyczące eksportu i kompatybilności**

- Zapis do PPT lub PPTX zachowuje model animacji, ale ostateczne odtwarzanie jest kontrolowane przez przeglądarkę prezentacji.
- PDF i obrazy statyczne nie odtwarzają animacji. Użyj [HTML5 export](/slides/pl/androidjava/export-to-html5/), animowanego GIF lub [konwersji wideo](/slides/pl/androidjava/convert-powerpoint-to-video/), gdy wyjście musi pokazywać ruch.
- Dla HTML5 włącz [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) , a w razie potrzeby [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/pl/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Renderowanie wideo obsługuje wiele popularnych efektów wejścia, podkreślenia, wyjścia i ścieżki ruchu, ale nie każdy efekt PowerPoint jest obsługiwany. Sprawdź aktualną listę [supported animations and effects](/slides/pl/androidjava/convert-powerpoint-to-video/#supported-animations-and-effects) i przetestuj krytyczne prezentacje w docelowej wersji Aspose.Slides.
- Zaawansowane efekty niestandardowe i efekty zaimportowane z innych formatów prezentacji mogą być zachowane w pliku, ale renderowane inaczej w PowerPoint, HTML5 lub wideo. Zweryfikuj wyeksportowany rezultat zamiast polegać wyłącznie na nazwie efektu.

## **FAQ**

**Dlaczego animacja pojawia się w PowerPoint, ale nie w PDF?**

PDF jest formatem statycznym, więc animacje i przejścia slajdów nie są odtwarzane. Eksportuj do HTML5, animowanego GIF lub wideo, gdy ruch musi być zachowany.

**Dlaczego efekt odtwarzany jest inaczej w wideo?**

Eksport wideo renderuje animacje zamiast przechowywać oryginalne zachowanie PowerPoint. Niektóre zaawansowane efekty nie są obsługiwane lub są przybliżane. Przejrzyj tabelę obsługiwanych efektów i przetestuj rzeczywistą prezentację przed użyciem w produkcji.

**Czy przeniesienie kształtu do przodu lub do tyłu zmienia kolejność jego animacji?**

Nie. Z‑order kształtu kontroluje nakładanie się, natomiast kolejność sekwencji i wyzwalacze kontrolują odtwarzanie animacji. Zmień oś czasu, jeśli potrzebujesz innej kolejności odtwarzania.