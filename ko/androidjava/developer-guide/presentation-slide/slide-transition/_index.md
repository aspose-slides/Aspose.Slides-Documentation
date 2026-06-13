---
title: Android에서 프레젠테이션 슬라이드 전환 관리
linktitle: 슬라이드 전환
type: docs
weight: 80
url: /ko/androidjava/slide-transition/
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
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android via Java에서 슬라이드 전환을 맞춤 설정하는 방법을 알아보고, PowerPoint 및 OpenDocument 프레젠테이션을 위한 단계별 안내를 제공합니다."
---
## **개요**

이 문서에서는 Aspose.Slides를 사용하여 프레젠테이션의 슬라이드 전환을 관리하는 방법을 설명합니다. 슬라이드에 전환 유형을 적용하고, 클릭 시 또는 지정된 시간 후에 전환이 진행되는 등 전환 동작을 구성하는 방법, 자동 진행을 확인하고 비활성화하는 방법, Morph 전환 및 그 유형을 사용하는 방법, 전환 효과 옵션을 설정하는 방법을 보여줍니다. 예제에서는 프레젠테이션을 로드하거나 생성하고, 선택된 슬라이드의 전환 설정을 수정한 뒤 결과를 PPTX 파일로 저장하는 과정을 시연합니다. 또한 전환 속도, 전환 사운드, 여러 슬라이드에 동일한 전환을 적용하는 방법, 슬라이드에 현재 설정된 전환을 확인하는 방법 등에 대한 일반적인 질문에 답변합니다.

## **슬라이드 전환 추가**
간단한 슬라이드 전환 효과를 만들려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. Aspose.Slides for Android via Java가 제공하는 전환 효과 중 하나를 사용하여 TransitionType 열거형을 통해 슬라이드에 슬라이드 전환 유형을 적용합니다.
3. 수정된 프레젠테이션 파일을 저장합니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 슬라이드 1에 원형 전환을 적용합니다
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 슬라이드 2에 빗살 전환을 적용합니다
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // 프레젠테이션을 디스크에 저장합니다
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **고급 슬라이드 전환 추가**
위 섹션에서는 슬라이드에 단순 전환 효과만 적용했습니다. 이제 해당 단순 전환 효과를 더욱 개선하고 제어하려면 아래 단계를 따르세요:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
2. Aspose.Slides for Android via Java가 제공하는 전환 효과 중 하나를 선택하여 슬라이드에 슬라이드 전환 유형을 적용합니다.
3. 전환을 클릭 시 진행, 특정 시간 후 진행 또는 두 가지 모두로 설정할 수 있습니다.
4. 슬라이드 전환이 클릭 시 진행(Advance On Click)으로 설정된 경우, 마우스를 클릭할 때만 전환이 진행됩니다. 또한 Advance After Time 속성이 설정되어 있으면 지정된 시간이 경과한 후 전환이 자동으로 진행됩니다.
5. 수정된 프레젠테이션을 파일로 저장합니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // 슬라이드 1에 원형 전환을 적용합니다
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // 전환 시간을 3초로 설정합니다
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // 슬라이드 2에 빗살 전환을 적용합니다
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // 전환 시간을 5초로 설정합니다
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // 슬라이드 3에 확대 전환을 적용합니다
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // 전환 시간을 7초로 설정합니다
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // 프레젠테이션을 디스크에 저장합니다
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Morph 전환**
{{% alert color="primary" %}} 
Aspose.Slides for Android via Java는 이제 [Morph Transition](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IMorphTransition)을 지원합니다. 이는 PowerPoint 2019에서 도입된 새로운 모프 전환을 나타냅니다.
{{% /alert %}} 

Morph 전환을 사용하면 한 슬라이드에서 다음 슬라이드로 부드러운 움직임을 애니메이션화할 수 있습니다. 이 문서에서는 개념과 Morph 전환 사용 방법을 설명합니다. Morph 전환을 효과적으로 사용하려면 최소 하나의 공통 객체가 있는 두 개의 슬라이드가 필요합니다. 가장 쉬운 방법은 슬라이드를 복제한 다음 두 번째 슬라이드에서 객체를 다른 위치로 이동하는 것입니다.

다음 코드 스니펫은 텍스트가 포함된 슬라이드 복제본을 프레젠테이션에 추가하고 두 번째 슬라이드에 [morph type](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TransitionType) 전환을 설정하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Morph 전환 유형**
새로운 [TransitionMorphType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/TransitionMorphType) 열거형이 추가되었습니다. 이는 다양한 Morph 슬라이드 전환 유형을 나타냅니다.

TransitionMorphType 열거형에는 세 개의 멤버가 있습니다:

- ByObject: 형태를 분리할 수 없는 객체로 간주하여 Morph 전환을 수행합니다.
- ByWord: 가능한 경우 텍스트를 단어 단위로 전송하여 Morph 전환을 수행합니다.
- ByChar: 가능한 경우 텍스트를 문자 단위로 전송하여 Morph 전환을 수행합니다.

다음 코드 스니펫은 슬라이드에 모프 전환을 설정하고 모프 유형을 변경하는 방법을 보여줍니다.

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **전환 효과 설정**
Aspose.Slides for Android via Java는 검은색에서, 왼쪽에서, 오른쪽에서 등과 같은 전환 효과 설정을 지원합니다. 전환 효과를 설정하려면 아래 단계를 따르세요:

- [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
- 슬라이드에 대한 참조를 가져옵니다.
- 전환 효과를 설정합니다.
- 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.

아래 예제에서는 전환 효과를 설정했습니다.

```java
// Presentation 클래스의 인스턴스를 생성합니다
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // 효과를 설정합니다
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // 프레젠테이션을 디스크에 저장합니다
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**슬라이드 전환의 재생 속도를 제어할 수 있나요?**

예. 전환의 [speed](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-)을 [TransitionSpeed](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/transitionspeed/) 설정(예: slow/medium/fast)으로 설정합니다.

**전환에 오디오를 연결하고 반복 재생하도록 할 수 있나요?**

예. 전환에 사운드를 삽입하고 사운드 모드 및 반복과 같은 설정을 통해 동작을 제어할 수 있습니다(예: [setSound](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), 추가 메타데이터로 [setSoundIsBuiltIn](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) 및 [setSoundName](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**모든 슬라이드에 동일한 전환을 적용하는 가장 빠른 방법은?**

각 슬라이드의 전환 설정에 원하는 전환 유형을 구성하면 됩니다. 전환은 슬라이드별로 저장되므로 모든 슬라이드에 동일한 유형을 적용하면 일관된 결과를 얻을 수 있습니다.

**슬라이드에 현재 설정된 전환을 확인하려면 어떻게 해야 하나요?**

슬라이드의 [transition settings](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--)을 확인하고 [transition type](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/slideshowtransition/#setType-int-)을 읽으면 현재 적용된 효과를 정확히 알 수 있습니다.