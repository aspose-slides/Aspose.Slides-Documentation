---
title: Java를 사용한 프레젠테이션 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/java/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- 모프 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 정의합니다."
---
## **개요**

Slide transitions control how slides appear during a slide show. With Aspose.Slides for Java, you can choose a transition effect for each slide, configure advancement by mouse click or timer, and adjust options specific to an effect. This article uses Java examples to apply transitions, set exact transition durations, manage slide timing, and create a Morph transition between two slides. The examples also show how to save the settings to a PPTX file.

## **슬라이드 전환 추가**

To apply a transition, load a presentation with the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/) class and access the slide's transition settings through [getSlideShowTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Use [setType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setType-int-) with a value from the [TransitionType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitiontype/) enumeration, then save the presentation.

The following example applies a Circle transition to the first slide and a Comb transition to the second. Use an `input.pptx` file with at least two slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **고급 슬라이드 전환 추가**

You can configure how long a slide remains on screen and whether a mouse click advances the slide show. The following methods control this behavior:

- [setAdvanceOnClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) allows the viewer to advance by clicking the mouse.
- [setAdvanceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) enables automatic advancement.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) specifies the delay before automatic advancement, in milliseconds.

Enable both click and timed advancement to let the viewer move on with a click or wait for the timer. To use only the timer, pass `false` to [setAdvanceOnClick](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). The delay controls when the slide show advances; it does not set the duration of the visual transition effect.

This example assigns different effects to the first three slides and enables automatic advancement after 3, 5, and 7 seconds, respectively. Mouse clicks can also advance these slides. Use an `input.pptx` file with at least three slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

To check whether timed advancement is enabled, call [getAdvanceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). A stored delay alone does not indicate that the timer is active.

The next example opens the file saved above, reports each enabled timer, and disables automatic advancement for slides with a delay greater than two seconds. It enables mouse clicks for those slides and saves the updated settings.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **전환 타이밍을 정확하게 제어**

Use [setDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setDuration-int-) to specify the exact length of a transition effect in milliseconds. The slide's [getSlideShowTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) method exposes these settings through [ISlideShowTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/):

| 메서드 | 목적 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 슬라이드가 자동으로 전환되기 전의 지연 시간을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [setAdvanceAfter](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-)에 `true`를 전달하십시오. |
| [setSpeed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | TransitionSpeed 열거형에서 미리 정의된 속도 범주(Slow, Medium, Fast)를 선택합니다. 정확한 지속 시간이 지정되지 않은 경우 사용됩니다. |

[setDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setDuration-int-) controls only the transition effect; it does not determine how long the slide remains visible. Configure the automatic advancement delay separately. When no explicit duration is set, Aspose.Slides determines the effect duration from the transition type and the [getSpeed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getSpeed--) value.

### **모든 슬라이드에 동일한 지속 시간 적용**

For consistent pacing, apply the same effect and exact duration to every slide. This example loads `input.pptx`, selects Fade from [TransitionType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitiontype/), and gives each transition a duration of 750 milliseconds. It separately enables automatic advancement after 5,000 milliseconds and disables advancement by mouse click, then saves the result as PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 전환 지속 시간과 별도로 자동 진행을 구성합니다.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **개별 슬라이드에 서로 다른 지속 시간 설정**

Different slides can use different effect durations. For example, use a brief transition for a title slide and a longer transition for a section introduction. This example sets 500 milliseconds for the first slide and 1,200 milliseconds for the second. Use an `input.pptx` file with at least two slides.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **애니메이션 출력과 전환 조정**

When preparing an [animated GIF](/slides/ko/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/java/export-to-html5/), or [video](/slides/ko/java/convert-powerpoint-to-video/), set exact transition durations before export to match the intended pacing. For example, use a 600-millisecond fade between scenes, and adjust each slide's advancement delay separately to allow time for its narration or content.

For GIF and video, coordinate the output frame rate with the effect duration: 600 milliseconds corresponds to 18 frames at 30 frames per second. In HTML5, enable animated transitions in the export settings. Check the chosen export format's supported effects and timing options, and preview the output to confirm synchronization.

### **기존 전환 지속 시간 읽기**

Call [getDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getDuration--) before modifying the transition to determine whether an explicit value is stored. A value of `-1` means no explicit duration is set; a nonnegative value specifies the stored duration in milliseconds. The unset value is not the calculated playback duration: Aspose.Slides uses the transition type and the [getSpeed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getSpeed--) value to determine that duration. Setting a transition type can initialize a duration, so inspect the original settings first.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Morph 전환**

The Morph transition animates changes between objects on consecutive slides. To create a simple Morph effect, clone a slide, move or resize an object on the clone, and apply the Morph transition to the second slide. This gives the transition corresponding objects to animate between their original and modified states.

The following example creates a slide with a text rectangle, clones the slide, and changes the rectangle's position and size on the clone. It then selects Morph from the [TransitionType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitiontype/) enumeration for the second slide. Open the saved file in a presentation viewer that supports Morph to see the effect during a slide show.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Morph 전환 유형**

The [TransitionMorphType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionmorphtype/) enumeration controls how Morph matches and animates content:

- [ByObject](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionmorphtype/#ByObject) treats each shape as a whole object.
- [ByWord](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionmorphtype/#ByWord) animates text by matching words where possible.
- [ByChar](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionmorphtype/#ByChar) animates text by matching characters where possible.

Use [setType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setType-int-) to select Morph before accessing [getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getValue--). The value then provides the [IMorphTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imorphtransition/) interface, whose [setMorphType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/imorphtransition/#setMorphType-int-) method selects the matching mode.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **전환 효과 설정**

Some transitions expose additional options, such as direction or whether the effect starts from a black screen. The available options depend on the transition selected with [setType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setType-int-). Set the type first, then use the appropriate interface from [getValue](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getValue--).

The following example applies a Cut transition to the first slide of `input.pptx`. It calls [setFromBlack](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) through [IOptionalBlackTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ioptionalblacktransition/) so that the transition starts from a black screen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

Yes. Prefer [setDuration](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setDuration-int-) when you need an exact effect duration in milliseconds. Use [setSpeed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) when a predefined [TransitionSpeed](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionspeed/) category—Slow, Medium, or Fast—is sufficient and no explicit duration is set. These settings control the transition effect independently of the automatic advancement delay.

**전환에 오디오를 연결하고 루프하도록 할 수 있나요?**

Yes. Assign embedded audio with [setSound](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), pass StartSound from the [TransitionSoundMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitionsoundmode/) enumeration to [setSoundMode](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), and enable [setSoundLoop](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) with `true`. The audio loops until the next sound event in the slide show.

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은 무엇인가요?**

Loop through the presentation's [getSlides](https://reference.aspose.com/slides/ko/java/com.aspose.slides/presentation/#getSlides--) collection and call [setType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#setType-int-) with the same value for each slide's transition. Set any timing and effect options in the same loop to keep the behavior consistent across slides.

**슬라이드에 현재 설정된 전환을 어떻게 확인할 수 있나요?**

Call [getType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/islideshowtransition/#getType--) on the slide's [getSlideShowTransition](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) result. It returns a value from the [TransitionType](https://reference.aspose.com/slides/ko/java/com.aspose.slides/transitiontype/) enumeration; None means that no transition effect is applied.