---
title: Java를 사용하여 프레젠테이션에 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/java/shape-animation/
keywords:
- 도형
- 애니메이션
- 효과
- 애니메이션 도형
- 애니메이션 텍스트
- 애니메이션 추가
- 애니메이션 가져오기
- 애니메이션 추출
- 효과 추가
- 효과 가져오기
- 효과 추출
- 효과 사운드
- 애니메이션 적용
- PowerPoint
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 도형 애니메이션, 타이밍, 사운드, 애니메이션 후 동작 및 애니메이션 텍스트를 추가, 검사 및 사용자 정의하는 방법을 배웁니다."
---
## **개요**

Aspose.Slides for Java는 슬라이드 애니메이션을 슬라이드 타임라인의 효과로 나타냅니다. 효과에는 대상 도형, 애니메이션 유형 및 하위 유형, 트리거, 타이밍 설정 및 소리나 애니메이션 후 동작과 같은 선택적 속성이 포함될 수 있습니다.

타임라인에는 두 가지 종류의 시퀀스가 있습니다:

- **주 시퀀스**는 슬라이드가 진행될 때 재생됩니다.
- **대화형 시퀀스**는 트리거 도형을 클릭하면 시작됩니다.

텍스트 상자, 사진, 차트, 표 및 기타 슬라이드 개체는 모두 [IShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/)를 구현하므로 대부분의 슬라이드 콘텐츠에 대해 동일한 [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 메서드를 사용합니다. 사용할 수 있는 효과는 [EffectType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttype/) 클래스에 나와 있습니다.

## **도형 애니메이션 추가**

애니메이션을 추가하려면 슬라이드의 주 시퀀스를 가져와 대상 도형, 효과 유형, 하위 유형 및 트리거와 함께 [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 를 호출합니다. 다른 도형을 클릭할 때 시작되는 효과의 경우 해당 도형을 트리거로 하는 대화형 시퀀스를 만듭니다.

다음 예제는 두 종류의 애니메이션을 모두 생성하고 결과를 `shape-animations.pptx` 파일에 저장합니다.

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

트리거는 효과가 언제 시작되는지를 제어합니다:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttriggertype/#OnClick) 은 주 시퀀스에서는 클릭을 기다리며, 대화형 시퀀스에서는 트리거 도형의 클릭을 기다립니다.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttriggertype/#WithPrevious) 은 앞선 효과와 동시에 시작합니다.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/ko/java/com.aspose.slides/effecttriggertype/#AfterPrevious) 은 앞선 효과가 끝난 후 시작합니다.

사진, 차트 또는 다른 도형 유형을 애니메이트하려면 `targetShape` 대신 해당 객체를 [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-)에 전달합니다. 차트 전용 그룹화 옵션은 [Animated Charts](/slides/ko/java/animated-charts/)를 참조하세요.

## **도형 애니메이션 읽기**

대상 도형을 알고 있을 때는 [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) 를 사용합니다. 모든 효과를 검사하려면 주 시퀀스와 모든 대화형 시퀀스를 열거합니다. 열거는 시퀀스에 인덱스 `0` 에 효과가 있다고 가정하는 것을 피합니다.

다음 예제는 주 시퀀스와 대화형 효과가 포함된 도형을 만들고, 해당 도형을 대상으로 하는 효과를 가져온 다음 슬라이드의 모든 시퀀스를 열거합니다.

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

하나의 도형에 대한 효과만 필요하다면 이름, 자리표시자 유형 또는 다른 안정적인 속성으로 도형을 식별한 후 [ISequence.getEffectsByShape](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) 를 호출하세요. 인덱스 `0` 의 [IShapeCollection.get_Item](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishapecollection/#get_Item-int-) 이 항상 의도한 객체라고 가정하지 마세요.

## **상속된 자리표시자 효과 작업**

일반 슬라이드의 자리표시자는 레이아웃 슬라이드 및 마스터 슬라이드의 해당 자리표시자로부터 애니메이션 동작을 상속할 수 있습니다. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getBasePlaceholder--) 은 부모 자리표시자를 반환하거나, 부모가 없으면 `null` 을 반환합니다.

다음 예제 프레젠테이션에서 바닥글은 일반 슬라이드에서는 **Random Bars**, 레이아웃 슬라이드에서는 **Split**, 마스터 슬라이드에서는 **Fly In** 효과를 가집니다.

![일반 슬라이드의 바닥글 애니메이션 효과](slide-shape-animation.png)

![레이아웃 슬라이드의 바닥글 자리표시자 애니메이션 효과](layout-shape-animation.png)

![마스터 슬라이드의 바닥글 자리표시자 애니메이션 효과](master-shape-animation.png)

다음 예제는 새 프레젠테이션의 자리표시자 계층 구조를 사용합니다. 마스터 자리표시자, 레이아웃 자리표시자 및 일반 슬라이드의 해당 자리표시자에 효과를 추가합니다. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ishape/#getBasePlaceholder--) 호출 결과가 `null` 인지 확인한 후에만 반환된 도형을 사용합니다.

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

## **애니메이션 타이밍 변경**

PowerPoint **Timing** 대화상자는 [ITiming](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/) 의 속성과 매핑됩니다.

![애니메이션 효과에 대한 PowerPoint 타이밍 대화상자](shape-animation.png)

- **Start** 는 [ITiming.getTriggerType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getTriggerType--) 에 매핑됩니다.
- **Duration** 은 [ITiming.getDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getDuration--) (초) 에 매핑됩니다.
- **Delay** 은 [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getTriggerDelayTime--) (초) 에 매핑됩니다.
- **Repeat** 은 [ITiming.getRepeatCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), 또는 [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--) 에 매핑됩니다.
- **Rewind when done playing** 은 [ITiming.getRewind](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#getRewind--) 에 매핑됩니다.

이 독립 예제는 효과를 추가하고, [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 로 반환된 객체를 통해 타이밍을 변경한 뒤 결과를 저장합니다. 반환된 [IEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/) 참조를 유지하면 불필요한 컬렉션 인덱스를 피할 수 있습니다.

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

반복 모드는 하나만 사용하세요. 반복 횟수와 “until” 플래그를 동시에 사용하면 뷰어마다 서로 다른 결과가 나타날 수 있습니다. 반복 모드를 변경할 때는 [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) 와 [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) 을 먼저 설정하고, 그 다음에 [ITiming.setRepeatCount](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itiming/#setRepeatCount-float-) 를 호출하세요. 플래그를 설정하면 활성 반복 모드도 변경됩니다.

## **애니메이션 사운드 추가 및 추출**

애니메이션 효과는 [IEffect.getSound](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getSound--) 로 포함된 오디오를 참조할 수 있습니다. [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) 은 이전 효과가 시작한 오디오를 중지하도록 지정합니다.

### **효과에 사운드 추가**

다음 예제는 로컬 오디오 파일 `animation-sound.wav` 가 존재한다고 가정합니다. 두 개의 효과를 만들고 첫 번째 효과에 해당 파일을 사운드로 포함시키며, 두 번째 효과는 사운드를 중지하도록 설정합니다. [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) 로 반환된 객체를 사용하므로 시퀀스 인덱스가 필요하지 않습니다.

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

### **포함된 효과 사운드 추출**

다음 예제는 로컬 프레젠테이션 `presentation-with-animation-sounds.pptx` 가 존재한다고 가정합니다. 주 시퀀스와 대화형 시퀀스를 모두 스캔하고, 포함된 모든 효과 사운드를 `extracted-animation-sounds` 디렉터리로 기록합니다. 확장자는 [IAudio.getContentType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaudio/#getContentType--) 로 노출되는 오디오 MIME 타입에 따라 선택됩니다.

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

대용량 오디오 객체의 경우 [IAudio.getStream](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iaudio/#getStream--) 을 사용해 스트림을 파일로 복사하고, 전체 객체를 바이트 배열로 로드하는 것을 피하세요.

## **애니메이션 후 동작 설정**

**After animation** 옵션은 효과가 끝난 후 도형에 어떤 일이 일어나는지를 제어합니다.

![After animation 설정을 보여주는 PowerPoint 효과 옵션 대화상자](shape-after-animation.png)

[AfterAnimationType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/) 클래스는 도형을 그대로 두거나 색상을 변경하거나 애니메이션 후 숨기거나 다음 클릭 시 숨기는 옵션을 지원합니다. 유형이 [AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) 일 때는 [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getAfterAnimationColor--) 도 설정합니다.

이 독립 예제는 효과를 만든 뒤 반환된 효과 객체를 통해 애니메이션 후 동작을 설정하고 결과를 저장합니다.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

[AfterAnimationType.Color](https://reference.aspose.com/slides/ko/java/com.aspose.slides/afteranimationtype/#Color) 로부터 타입을 변경하면 애니메이션 후 색상 설정이 삭제됩니다.

## **텍스트 애니메이션**

텍스트 애니메이션에는 두 가지 관련 제어가 있습니다:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/itextanimation/#getBuildType--) 은 단락이 함께 나타날지 단락 별로 나타날지를 제어합니다.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getAnimateTextType--) 은 텍스트가 한 번에, 단어별, 문자별 중 어떻게 나타날지를 제어합니다. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) 은 단어 또는 문자 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율이며, 음수 값은 초 단위 지연입니다.

다음 독립 예제는 텍스트 상자의 단어들을 애니메이트합니다. [BuildType.AsOneObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/buildtype/#AsOneObject) 은 단락별 빌드를 비활성화하여 전체 텍스트 프레임에 단어 설정이 적용되도록 합니다.

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

텍스트 상자를 단락별로 빌드하려면 [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/ko/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (또는 다른 단락 수준) 을 설정하세요. 단일 단락에만 효과를 적용하려면 [ISequence.addEffect](https://reference.aspose.com/slides/ko/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) 로 [IParagraph](https://reference.aspose.com/slides/ko/java/com.aspose.slides/iparagraph/) 을 받아들이는 오버로드를 사용하세요. 단락 수준 예제는 [Animated Text](/slides/ko/java/animated-text/) 를 참고하세요.

## **내보내기 및 호환성 참고**

- PPT 또는 PPTX 로 저장하면 애니메이션 모델이 보존되지만 최종 재생은 프레젠테이션 뷰어에 의해 제어됩니다.
- PDF 및 정적 이미지는 애니메이션을 재생하지 않습니다. 움직임을 보여줘야 할 경우 [HTML5 export](/slides/ko/java/export-to-html5/), 애니메이션 GIF 또는 [video conversion](/slides/ko/java/convert-powerpoint-to-video/) 을 사용하세요.
- HTML5 에서는 [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) 를 활성화하고, 필요시 [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/ko/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-) 도 설정하세요.
- 비디오 렌더링은 일반적인 입장, 강조, 퇴장 및 경로 효과를 많이 지원하지만 모든 PowerPoint 효과를 지원하지는 않습니다. 현재 [supported animations and effects](/slides/ko/java/convert-powerpoint-to-video/#supported-animations-and-effects) 를 확인하고 대상 Aspose.Slides 버전에서 중요한 프레젠테이션을 테스트하세요.
- 고급 사용자 정의 효과 및 다른 프레젠테이션 형식에서 가져온 효과는 파일에 보존될 수 있지만 PowerPoint, HTML5 또는 비디오에서 다르게 렌더링될 수 있습니다. 효과 이름에만 의존하지 말고 내보낸 결과를 검증하세요.

## **FAQ**

**왜 애니메이션은 PowerPoint에서는 보이지만 PDF에서는 보이지 않나요?**

PDF는 정적 형식이므로 애니메이션과 슬라이드 전환이 재생되지 않습니다. 움직임을 유지해야 할 경우 HTML5, 애니메이션 GIF 또는 비디오로 내보내세요.

**왜 영상에서는 효과가 다르게 재생되나요?**

비디오 내보내기는 원본 PowerPoint 동작을 저장하지 않고 애니메이션을 렌더링합니다. 일부 고급 효과는 지원되지 않거나 근사 처리됩니다. 지원되는 효과 표를 확인하고 실제 프레젠테이션을 테스트하세요.

**도형을 앞으로 또는 뒤로 이동하면 애니메이션 순서가 바뀌나요?**

아니요. 도형 z‑order는 겹침을 제어하고, 시퀀스 순서와 트리거가 애니메이션 재생을 제어합니다. 재생 순서를 바꾸려면 타임라인을 조정하세요.