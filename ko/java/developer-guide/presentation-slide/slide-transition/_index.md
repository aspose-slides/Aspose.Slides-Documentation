---
title: Java를 사용한 프레젠테이션에서 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/java/slide-transition/
keywords:
- 슬라이드 전환
- 슬라이드 전환 추가
- 슬라이드 전환 적용
- 고급 슬라이드 전환
- Morph 전환
- 전환 유형
- 전환 효과
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 슬라이드 전환을 적용하고, 자동 슬라이드 진행을 구성하며, Morph 및 기타 전환 효과를 사용자 지정합니다."
---
## **개요**

슬라이드 전환은 슬라이드 쇼 중 슬라이드가 표시되는 방식을 제어합니다. Aspose.Slides for Java를 사용하면 각 슬라이드에 전환 효과를 선택하고, 마우스 클릭이나 타이머에 의한 진행을 구성하며, 효과에 특화된 옵션을 조정할 수 있습니다. 이 문서는 Java 예제를 사용하여 전환을 적용하고, 정확한 전환 지속 시간을 설정하고, 슬라이드 타이밍을 관리하며, 두 슬라이드 사이에 Morph 전환을 만드는 방법을 보여줍니다. 또한 설정을 PPTX 파일에 저장하는 방법도 예제로 보여줍니다.

## **슬라이드 전환 추가**

전환을 적용하려면 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스로 프레젠테이션을 로드하고 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--)을 통해 슬라이드의 전환 설정에 접근합니다. [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)에 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 열거형에서 값을 전달한 뒤 프레젠테이션을 저장합니다.

다음 예제는 첫 번째 슬라이드에 Circle 전환을, 두 번째 슬라이드에 Comb 전환을 적용합니다. 최소 두 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

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

## **휠 전환**

[IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/)의 [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) 메서드는 목적 슬라이드를 드러내는 방사형 섹터 수를 제어합니다. 전환 유형을 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)에서 Wheel로 설정하고([setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)) 나서 [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/)으로 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)에 접근합니다.

이 예제는 검은색 슬라이드와 금색 사각형이 있는 슬라이드를 차례로 배치한 두 개의 동일한 슬라이드 쌍을 생성합니다. 목적 슬라이드의 스포크 수는 각각 1과 8이며, 동일한 속도([setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-))와 명시적 지속 시간 8,000밀리초([setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-))를 설정하여 차이를 쉽게 관찰할 수 있게 했습니다.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

출력 프레젠테이션을 PowerPoint에서 열고 슬라이드 쇼를 실행하십시오. 슬라이드 1에서 슬라이드 2로, 이어서 슬라이드 3에서 슬라이드 4로 진행합니다. PowerPoint 재생에서는 스포크 수 1인 경우 시계 방향으로 한 번 스윕하여 슬라이드가 드러나고, 스포크 수 8인 경우 8개의 방사형 섹터가 동시에 드러납니다. 목적 내용과 전환 타이밍은 동일하므로 차이는 드러내는 섹터 수뿐입니다.

## **Reveal 전환을 사용한 검은색을 통한 페이드**

목적 슬라이드의 전환 유형을 Reveal로 설정한 뒤, 해당 슬라이드의 [IRevealTransition](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/) 설정에 대해 [setThroughBlack](https://reference.aspose.com/slides/java/com.aspose.slides/irevealtransition/#setThroughBlack-boolean-)을 호출합니다. 예제는 청록색 소스 슬라이드와 산호색 목적 슬라이드를 만들고 두 슬라이드를 복제합니다. 각각의 쌍은 2초 Reveal 전환을 사용하고, 두 번째 쌍만 검은색을 통해 페이드됩니다.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide source = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addClone(source);
    ISlide[] slides = { source, destination };
    Color[] backgrounds = { new Color(0, 128, 128), new Color(255, 127, 80) };
    String[] labels = { "Source", "Destination" };

    for (int i = 0; i < slides.length; i++) {
        ISlide slide = slides[i];
        slide.getBackground().setType(BackgroundType.OwnBackground);
        slide.getBackground().getFillFormat().setFillType(FillType.Solid);
        slide.getBackground().getFillFormat().getSolidFillColor().setColor(backgrounds[i]);

        IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 160, 180, 400, 130);
        shape.getTextFrame().setText(labels[i]);
        shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setFontHeight(44);
    }

    presentation.getSlides().addClone(source);
    ISlide clonedDestination = presentation.getSlides().addClone(destination);
    for (ISlide slide : new ISlide[] { destination, clonedDestination }) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Reveal);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(2000);

        IRevealTransition reveal = (IRevealTransition) transition.getValue();
        reveal.setDirection(TransitionLeftRightDirectionType.Left);
        reveal.setThroughBlack(slide == clonedDestination);
    }

    presentation.save("reveal-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

저장된 프레젠테이션을 PowerPoint에서 열고 슬라이드 쇼를 시작하십시오. 슬라이드 1에서 슬라이드 2로 진행하면 청록색이 바로 산호색으로 페이드됩니다. 이어서 슬라이드 3에서 슬라이드 4로 진행하면 화면이 잠시 거의 검은색으로 어두워졌다가 산호색 슬라이드가 나타납니다. 두 슬라이드 모두 원래 배경 색을 유지합니다.

아래 행은 0.5초 간격으로 캡처한 PowerPoint 프레임을 보여줍니다. 각 행의 중간 프레임을 비교하여 효과를 확인하십시오.

![검은색을 통한 페이드가 비활성화된 (위) 및 활성화된 (아래) PowerPoint 재생. 아래 행만 거의 검은색을 통과합니다.](reveal-through-black.png)

## **고급 슬라이드 전환 추가**

슬라이드가 화면에 남아 있는 시간과 마우스 클릭으로 슬라이드 쇼를 진행할지 여부를 구성할 수 있습니다. 다음 메서드가 해당 동작을 제어합니다.

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) : 마우스 클릭으로 진행할 수 있도록 허용합니다.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) : 자동 진행을 활성화합니다.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) : 자동 진행 전 지연 시간을 밀리초 단위로 지정합니다.

클릭과 타이머 진행을 모두 활성화하면 사용자는 클릭으로 이동하거나 타이머가 끝날 때까지 기다릴 수 있습니다. 타이머만 사용하려면 [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-)에 `false`를 전달하십시오. 지연은 슬라이드 쇼가 언제 진행되는지를 제어하며, 시각적 전환 효과의 지속 시간을 지정하지는 않습니다.

이 예제는 첫 세 슬라이드에 서로 다른 효과를 지정하고 각각 3초, 5초, 7초 후 자동 진행을 활성화합니다. 마우스 클릭으로도 슬라이드를 진행할 수 있습니다. 최소 세 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

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

타이머 진행이 활성화되었는지 확인하려면 [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--)를 호출합니다. 저장된 지연만으로는 타이머가 활성화되었는지 여부를 판단할 수 없습니다.

다음 예제는 위에서 저장한 파일을 열어 각 활성화된 타이머를 보고, 2초 초과 지연을 가진 슬라이드의 자동 진행을 비활성화하고 해당 슬라이드에 마우스 클릭을 허용한 뒤 설정을 저장합니다.

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

## **전환 타이밍을 정확히 제어**

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-)을 사용하여 전환 효과의 정확한 길이를 밀리초 단위로 지정합니다. 슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 메서드를 통해 [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/) 인터페이스에서 이러한 설정에 접근할 수 있습니다.

| 메서드 | 목적 |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | 전환 효과 자체의 지속 시간을 밀리초 단위로 설정합니다. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | 슬라이드가 자동으로 진행되기 전의 지연을 밀리초 단위로 설정합니다. 이 타이머를 활성화하려면 [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-)에 `true`를 전달하십시오. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 열거형에서 Slow, Medium, Fast 중 하나를 선택합니다. 정확한 지속 시간을 지정하지 않을 때 사용됩니다. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-)은 전환 효과만 제어하며, 슬라이드가 화면에 남아 있는 시간을 결정하지는 않습니다. 자동 진행 지연은 별도로 설정하십시오. 명시적 지속 시간이 없을 경우 Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 값을 기반으로 효과 지속 시간을 판단합니다.

<!-- visual-explanation:slide-transition:start -->
[![별도 막대가 750ms 전환 지속 시간과 5,000ms 자동 전진 설정을 나타냅니다.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*공유 예제는 각 슬라이드에 750ms Fade 전환을 적용하고 자동 전진을 5,000ms에 별도로 활성화합니다. 전환 지속 시간은 효과를 제어하고, 전진은 슬라이드에서 떠나는 시점을 제어합니다. 이러한 막대는 실제 측정된 타임라인이 아닌 설정을 나타내는 도식입니다.*
<!-- visual-explanation:slide-transition:end -->

### **모든 슬라이드에 동일한 지속 시간 적용**

일관된 속도를 위해 모든 슬라이드에 동일한 효과와 정확한 지속 시간을 적용합니다. 이 예제는 `input.pptx`를 로드하고 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/)에서 Fade를 선택한 뒤 각 전환에 750밀리초 지속 시간을 지정합니다. 또한 자동 전진을 5,000밀리초에 별도로 활성화하고 마우스 클릭 전진을 비활성화한 뒤 결과를 PPTX로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // 효과 지속 시간과는 별도로 자동 진행을 구성합니다.
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

슬라이드마다 다른 효과 지속 시간을 사용할 수 있습니다. 예를 들어, 제목 슬라이드에는 짧은 전환을, 섹션 소개 슬라이드에는 긴 전환을 적용합니다. 이 예제는 첫 번째 슬라이드에 500밀리초, 두 번째 슬라이드에 1,200밀리초를 설정합니다. 최소 두 개 슬라이드가 포함된 `input.pptx` 파일을 사용하십시오.

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

### **애니메이션 출력과 전환 동기화**

[animated GIF](/slides/ko/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/ko/java/export-to-html5/), 또는 [video](/slides/ko/java/convert-powerpoint-to-video/)를 준비할 때, 내보내기 전에 정확한 전환 지속 시간을 설정하여 원하는 속도에 맞추십시오. 예를 들어 씬 사이에 600밀리초 페이드를 사용하고, 각 슬라이드의 진행 지연을 개별적으로 조정하여 내레이션이나 콘텐츠에 충분한 시간을 확보합니다.

GIF 및 비디오의 경우, 프레임 레이트를 효과 지속 시간에 맞추어야 합니다. 600밀리초는 30fps에서 18프레임에 해당합니다. HTML5에서는 내보내기 설정에서 애니메이션 전환을 활성화하십시오. 선택한 내보내기 형식이 지원하는 효과와 타이밍 옵션을 확인하고, 출력물을 미리 보면서 동기화를 검증하십시오.

### **기존 전환 지속 시간 읽기**

전환을 수정하기 전에 [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--)을 호출하여 명시적 값이 저장되어 있는지 확인합니다. `-1` 값은 명시적 지속 시간이 설정되지 않았음을 의미하고, 0 이상 값은 밀리초 단위로 저장된 지속 시간을 나타냅니다. 이 값은 재생 중 실제 계산된 지속 시간이 아니며, Aspose.Slides는 전환 유형과 [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) 값을 사용해 지속 시간을 결정합니다. 전환 유형을 설정하면 지속 시간이 초기화될 수 있으므로 원래 설정을 먼저 확인하십시오.

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

Morph 전환은 연속된 슬라이드의 객체 변화에 애니메이션을 적용합니다. 간단한 Morph 효과를 만들려면 슬라이드를 복제하고 복제본에서 객체를 이동하거나 크기를 조정한 뒤 두 번째 슬라이드에 Morph 전환을 적용합니다. 이렇게 하면 원본과 수정된 상태 사이를 애니메이션으로 전환합니다.

다음 예제는 텍스트 사각형이 있는 슬라이드를 만들고 복제한 뒤 복제본에서 사각형의 위치와 크기를 변경합니다. 그런 다음 두 번째 슬라이드에 대해 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 열거형에서 Morph를 선택합니다. Morph를 지원하는 프레젠테이션 뷰어에서 저장된 파일을 열어 슬라이드 쇼 중 효과를 확인하십시오.

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

[TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) 열거형은 Morph가 콘텐츠를 일치시키고 애니메이션하는 방식을 제어합니다:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) : 각 도형을 전체 객체로 취급합니다.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) : 가능한 경우 단어 단위로 텍스트를 일치시켜 애니메이션합니다.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) : 가능한 경우 문자 단위로 텍스트를 일치시켜 애니메이션합니다.

[Morph]를 선택하려면 먼저 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)을 호출한 뒤 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)에 접근합니다. 반환된 [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/) 인터페이스에서 [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) 메서드를 사용해 일치 방식을 선택합니다.

이 예제는 이전 섹션에서 만든 프레젠테이션을 열고 두 번째 슬라이드에 대해 단어 기반 Morph 애니메이션을 구성합니다.

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

일부 전환은 방향이나 검은 화면에서 시작하는지와 같은 추가 옵션을 제공합니다. 사용 가능한 옵션은 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)으로 선택한 전환에 따라 달라집니다. 먼저 유형을 설정한 뒤 [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--)를 통해 적절한 인터페이스를 사용합니다.

다음 예제는 `input.pptx`의 첫 번째 슬라이드에 Cut 전환을 적용합니다. 전환이 검은 화면에서 시작하도록 [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/)을 통해 [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-)을 호출합니다.

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

예. 밀리초 단위의 정확한 효과 지속 시간이 필요할 경우 [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-)을 사용하십시오. 미리 정의된 [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) 카테고리(느림, 보통, 빠름)만으로 충분하고 명시적 지속 시간을 설정하지 않을 경우에는 [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-)을 사용하십시오. 이 설정들은 자동 전진 지연과는 별개로 전환 효과만 제어합니다.

**전환에 오디오를 연결하고 반복 재생하도록 할 수 있나요?**

예. [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-)으로 임베드된 오디오를 지정하고, [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) 열거형의 StartSound를 [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-)에 전달하며, [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-)을 `true`로 설정하십시오. 슬라이드 쇼에서 다음 사운드 이벤트가 발생할 때까지 오디오가 반복 재생됩니다.

**모든 슬라이드에 동일한 전환을 가장 빠르게 적용하는 방법은?**

프레젠테이션의 [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 컬렉션을 순회하면서 각 슬라이드의 전환에 대해 동일한 값으로 [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-)을 호출하십시오. 동일한 루프에서 타이밍 및 효과 옵션을 설정하면 슬라이드 전체에 일관된 동작을 유지할 수 있습니다.

**슬라이드에 현재 설정된 전환을 어떻게 확인할 수 있나요?**

슬라이드의 [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) 결과에 대해 [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--)을 호출합니다. 반환값은 [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) 열거형의 값이며, None이면 전환 효과가 적용되지 않았음을 의미합니다.