---
title: Python을 사용한 프레젠테이션에서 도형 애니메이션 적용
linktitle: 도형 애니메이션
type: docs
weight: 60
url: /ko/python-net/shape-animation/
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
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션에서 도형 애니메이션을 만들고 사용자 지정하는 방법을 알아보세요. 눈에 띄게!"
---
## **소개**

애니메이션은 텍스트, 이미지, 도형 또는 [차트](/slides/ko/python-net/animated-charts/)에 적용할 수 있는 시각 효과입니다. 프레젠테이션이나 구성 요소에 생동감을 부여합니다. 

## **프레젠테이션에 애니메이션을 사용하는 이유**

애니메이션을 사용하면  

* 정보 흐름을 제어할 수 있습니다  
* 중요한 포인트를 강조할 수 있습니다  
* 청중의 관심이나 참여도를 높일 수 있습니다  
* 콘텐츠를 더 쉽게 읽고 이해하거나 처리할 수 있습니다  
* 프레젠테이션의 중요한 부분에 독자 또는 시청자의 주의를 끌 수 있습니다  

PowerPoint는 **입장**, **퇴장**, **강조**, **이동 경로** 카테고리 전반에 걸쳐 다양한 애니메이션 옵션과 도구를 제공합니다. 

## **Aspose.Slides의 애니메이션**

* Aspose.Slides는 [Aspose.Slides.Animation](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/) 네임스페이스 아래에서 애니메이션을 작업하는 데 필요한 클래스와 형식을 제공합니다.  
* Aspose.Slides는 [EffectType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttype/) 열거형에 정의된 **150개 이상의 애니메이션 효과**를 제공합니다. 이러한 효과는 기본적으로 PowerPoint에서 사용하는 효과와 동일(또는 동등)합니다.  

## **텍스트 상자에 애니메이션 적용**

Aspose.Slides for Python via .NET을 사용하면 도형의 텍스트에 애니메이션을 적용할 수 있습니다. 

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iautoshape/)을 추가합니다.  
4. `IAutoShape.TextFrame`에 텍스트를 추가합니다.  
5. 메인 효과 시퀀스를 가져옵니다.  
6. [IAutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iautoshape/)에 애니메이션 효과를 추가합니다.  
7. `TextAnimation.BuildType` 속성을 `BuildType` 열거형의 값으로 설정합니다.  
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.  

다음 Python 코드는 AutoShape에 `Fade` 효과를 적용하고 텍스트 애니메이션을 *By 1st Level Paragraphs* 값으로 설정하는 방법을 보여줍니다.

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
with slides.Presentation() as pres:
    sld = pres.slides[0]
    
    # 텍스트가 있는 새 AutoShape를 추가합니다
    autoShape = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 20, 20, 150, 100)

    textFrame = autoShape.text_frame
    textFrame.text = "First paragraph \nSecond paragraph \n Third paragraph"

    # 슬라이드의 메인 시퀀스를 가져옵니다.
    sequence = sld.timeline.main_sequence

    # 도형에 Fade 애니메이션 효과를 추가합니다
    effect = sequence.add_effect(autoShape, slides.animation.EffectType.FADE, slides.animation.EffectSubtype.NONE, slides.animation.EffectTriggerType.ON_CLICK)

    # 도형 텍스트를 1단계 단락별로 애니메이션합니다
    effect.text_animation.build_type = slides.animation.BuildType.BY_LEVEL_PARAGRAPHS1

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimText_out.pptx", slides.export.SaveFormat.PPTX)
```

{{%  alert color="primary"  %}} 

텍스트에 애니메이션을 적용하는 것 외에도 단일 [Paragraph](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iparagraph/)에 애니메이션을 적용할 수 있습니다. 자세한 내용은 [**Animated Text**](/slides/ko/python-net/animated-text/)를 참조하세요.

{{% /alert %}} 

## **PictureFrame에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 슬라이드에 [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)을 추가하거나 가져옵니다.  
4. 메인 효과 시퀀스를 가져옵니다.  
5. [PictureFrame](https://reference.aspose.com/slides/ko/python-net/aspose.slides/pictureframe/)에 애니메이션 효과를 추가합니다.  
6. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.  

다음 Python 코드는 PictureFrame에 `Fly` 효과를 적용하는 방법을 보여줍니다.

```python
import aspose.slides as slides
import aspose.pydrawing as draw


# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
with slides.Presentation() as pres:
    # 프레젠테이션 이미지 컬렉션에 추가될 이미지를 로드합니다
    img = draw.Bitmap("aspose-logo.jpg")
    image = pres.images.add_image(img)

    # 슬라이드에 picture frame을 추가합니다
    picFrame = pres.slides[0].shapes.add_picture_frame(slides.ShapeType.RECTANGLE, 50, 50, 100, 100, image)

    # 슬라이드의 메인 시퀀스를 가져옵니다.
    sequence = pres.slides[0].timeline.main_sequence

    # picture frame에 왼쪽에서 날아오는 애니메이션 효과를 추가합니다
    effect = sequence.add_effect(picFrame, slides.animation.EffectType.FLY,  
        slides.animation.EffectSubtype.LEFT, 
        slides.animation.EffectTriggerType.ON_CLICK)

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimImage_out.pptx", slides.export.SaveFormat.PPTX)
```

## **도형에 애니메이션 적용**

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. `rectangle` [IAutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iautoshape/)을 추가합니다.  
4. `Bevel` [IAutoShape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/iautoshape/)을 추가합니다(이 개체를 클릭하면 애니메이션이 재생됩니다).  
5. 베벨 도형에 대한 효과 시퀀스를 만듭니다.  
6. 사용자 정의 `UserPath`를 생성합니다.  
7. `UserPath`로 이동하는 명령을 추가합니다.  
8. 프레젠테이션을 PPTX 파일로 디스크에 저장합니다.  

다음 Python 코드는 도형에 `PathFootball`(경로 축구) 효과를 적용하는 방법을 보여줍니다.

```python
import aspose.slides.animation as anim
import aspose.slides as slides
import aspose.pydrawing as draw

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
with slides.Presentation() as pres:
    sld = pres.slides[0]

    # 기존 도형에 대해 처음부터 PathFootball 효과를 생성합니다.
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 150, 250, 25)

    ashp.add_text_frame("Animated TextBox")

    # PathFootBall 애니메이션 효과를 추가합니다.
    pres.slides[0].timeline.main_sequence.add_effect(ashp, 
        anim.EffectType.PATH_FOOTBALL,
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.AFTER_PREVIOUS)

    # 일종의 "버튼"을 생성합니다.
    shapeTrigger = pres.slides[0].shapes.add_auto_shape(slides.ShapeType.BEVEL, 10, 10, 20, 20)

    # 버튼에 대한 효과 시퀀스를 생성합니다.
    seqInter = pres.slides[0].timeline.interactive_sequences.add(shapeTrigger)

    # 사용자 지정 경로를 생성합니다. 객체는 버튼을 클릭한 후에만 이동됩니다.
    fxUserPath = seqInter.add_effect(ashp, 
        anim.EffectType.PATH_USER, 
        anim.EffectSubtype.NONE, 
        anim.EffectTriggerType.ON_CLICK)

    # 생성된 경로가 비어 있으므로 이동 명령을 추가합니다.
    motionBhv = fxUserPath.behaviors[0]

    pts = [draw.PointF(0.076, 0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, True)
    pts = [draw.PointF(-0.076, -0.59)]
    motionBhv.path.add(anim.MotionCommandPathType.LINE_TO, pts, anim.MotionPathPointsType.AUTO, False)
    motionBhv.path.add(anim.MotionCommandPathType.END, None, anim.MotionPathPointsType.AUTO, False)

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_out.pptx", slides.export.SaveFormat.PPTX)
```

## **도형에 적용된 애니메이션 효과 가져오기**

다음 예제는 [Sequence](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/sequence/) 클래스의 `get_effects_by_shape` 메서드를 사용하여 도형에 적용된 모든 애니메이션 효과를 가져오는 방법을 보여줍니다.  

**예제 1: 일반 슬라이드에서 도형에 적용된 애니메이션 효과 가져오기**

이전 섹션에서 PowerPoint 프레젠테이션에 도형에 애니메이션 효과를 추가하는 방법을 배웠습니다. 다음 샘플 코드는 프레젠테이션 `AnimExample_out.pptx`의 첫 번째 일반 슬라이드에 있는 첫 번째 도형에 적용된 효과를 가져오는 방법을 보여줍니다.

```python
import aspose.slides as slides

with slides.Presentation("AnimExample_out.pptx") as presentation:
    first_slide = presentation.slides[0]

    # 슬라이드의 메인 애니메이션 시퀀스를 가져옵니다.
    sequence = first_slide.timeline.main_sequence

    # 첫 번째 슬라이드의 첫 번째 도형을 가져옵니다.
    shape = first_slide.shapes[0]

    # 도형에 적용된 애니메이션 효과를 가져옵니다.
    shape_effects = sequence.get_effects_by_shape(shape)

    if len(shape_effects) > 0:
        print("The shape", shape.name, "has", len(shape_effects), "animation effects.")
```

**예제 2: 자리표시자에서 상속된 효과를 포함한 모든 애니메이션 효과 가져오기**

일반 슬라이드의 도형에 레이아웃 슬라이드 및/또는 마스터 슬라이드에 있는 자리표시자가 있고, 이러한 자리표시자에 애니메이션 효과가 추가된 경우 슬라이드 쇼 동안 도형의 모든 효과가 재생됩니다. 여기에는 자리표시자에서 상속된 효과도 포함됩니다.  

예를 들어 `sample.pptx` 파일에 하나의 슬라이드가 있고, 해당 슬라이드에는 텍스트 "Made with Aspose.Slides"가 있는 푸터 도형만 존재하며 **Random Bars** 효과가 적용되어 있다고 가정합니다.

![슬라이드 도형 애니메이션 효과](slide-shape-animation.png)

또한 레이아웃 슬라이드의 푸터 자리표시자에 **Split** 효과가 적용되어 있다고 가정합니다.

![레이아웃 도형 애니메이션 효과](layout-shape-animation.png)

마지막으로 마스터 슬라이드의 푸터 자리표시자에 **Fly In** 효과가 적용되어 있다고 가정합니다.

![마스터 도형 애니메이션 효과](master-shape-animation.png)

다음 샘플 코드는 [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 클래스의 `get_base_placeholder` 메서드를 사용하여 도형 자리표시자를 액세스하고 레이아웃 및 마스터 슬라이드에 있는 자리표시자에서 상속된 효과를 포함한 푸터 도형에 적용된 애니메이션 효과를 가져오는 방법을 보여줍니다.

```py
import aspose.slides as slides

def print_effects(effects):
    for effect in effects:
        print(effect.type.name, effect.subtype.name)
```
```py
with slides.Presentation("sample.pptx") as presentation:
    slide = presentation.slides[0]

    # 일반 슬라이드에 있는 도형의 애니메이션 효과를 가져옵니다.
    shape = slide.shapes[0]
    shape_effects = slide.timeline.main_sequence.get_effects_by_shape(shape)

    # 레이아웃 슬라이드에 있는 자리표시자의 애니메이션 효과를 가져옵니다.
    layout_shape = shape.get_base_placeholder()
    layout_shape_effects = slide.layout_slide.timeline.main_sequence.get_effects_by_shape(layout_shape)

    # 마스터 슬라이드에 있는 자리표시자의 애니메이션 효과를 가져옵니다.
    master_shape = layout_shape.get_base_placeholder()
    master_shape_effects = slide.layout_slide.master_slide.timeline.main_sequence.get_effects_by_shape(master_shape)

    print("Main sequence of shape effects:")
    print_effects(master_shape_effects)
    print_effects(layout_shape_effects)
    print_effects(shape_effects)
```

Output:
```text
Main sequence of shape effects:
FLY BOTTOM
SPLIT VERTICAL_IN
RANDOM_BARS HORIZONTAL
```

## **애니메이션 효과 타이밍 속성 변경**

Aspose.Slides for Python via .NET을 사용하면 애니메이션 효과의 타이밍 속성을 변경할 수 있습니다.  

다음은 Microsoft PowerPoint에서의 애니메이션 타이밍 창입니다.

![example1_image](shape-animation.png)

PowerPoint 타이밍과 `Effect.Timing` 속성 간 대응 관계는 다음과 같습니다.

- PowerPoint 타이밍 **Start** 드롭다운 목록은 [Effect.Timing.TriggerType](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/effecttriggertype/) 속성과 일치합니다.  
- PowerPoint 타이밍 **Duration** 은 `Effect.Timing.Duration` 속성과 일치합니다. 애니메이션의 지속 시간(초)은 애니메이션이 한 사이클을 완료하는 데 걸리는 총 시간입니다.  
- PowerPoint 타이밍 **Delay** 는 `Effect.Timing.TriggerDelayTime` 속성과 일치합니다.  

Effect Timing 속성을 변경하는 방법은 다음과 같습니다.

1. [도형에 애니메이션 적용](#apply-animation-to-shape) 섹션에서 애니메이션 효과를 적용하거나 가져옵니다.  
2. 필요에 따라 `Effect.Timing` 속성에 새로운 값을 설정합니다.  
3. 수정된 PPTX 파일을 저장합니다.  

다음 Python 코드는 해당 작업을 시연합니다.

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
with slides.Presentation("AnimExample_out.pptx") as pres:
    # 슬라이드의 메인 시퀀스를 가져옵니다.
    sequence = pres.slides[0].timeline.main_sequence

    # 메인 시퀀스의 첫 번째 효과를 가져옵니다.
    effect = sequence[0]

    # 효과 TriggerType을 클릭 시 시작하도록 변경합니다
    effect.timing.trigger_type = slides.animation.EffectTriggerType.ON_CLICK

    # 효과 Duration을 변경합니다
    effect.timing.duration = 3

    # 효과 TriggerDelayTime을 변경합니다
    effect.timing.trigger_delay_time = 0.5

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_changed.pptx", slides.export.SaveFormat.PPTX)
```

## **애니메이션 효과 사운드**

Aspose.Slides는 애니메이션 효과에 사운드를 사용할 수 있도록 다음 속성을 제공합니다.  

- `sound`  
- `stop_previous_sound`  

### **애니메이션 효과 사운드 추가**

다음 Python 코드는 애니메이션 효과에 사운드를 추가하고 다음 효과가 시작될 때 사운드를 중지하는 방법을 보여줍니다.

```python
import aspose.slides as slides

with Presentation("AnimExample_out.pptx") as pres:
    # 프레젠테이션 오디오 컬렉션에 오디오를 추가합니다
    effect_sound = pres.audios.add_audio(open("sampleaudio.wav", "rb").read())

    first_slide = pres.slides[0]

    # 슬라이드의 메인 시퀀스를 가져옵니다.
    sequence = first_slide.timeline.main_sequence

    # 메인 시퀀스의 첫 번째 효과를 가져옵니다
    first_effect = sequence[0]

    # 효과가 "소리 없음"인지 확인합니다
    if not first_effect.stop_previous_sound and first_effect.sound is None:
        # 첫 번째 효과에 소리를 추가합니다
        first_effect.sound = effect_sound

    # 슬라이드의 첫 번째 인터랙티브 시퀀스를 가져옵니다.
    interactive_sequence = first_slide.timeline.interactive_sequences[0]

    # 효과의 "이전 소리 중지" 플래그를 설정합니다
    interactive_sequence[0].stop_previous_sound = True

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimExample_Sound_out.pptx", slides.export.SaveFormat.PPTX)
```

### **애니메이션 효과 사운드 추출**

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 통해 슬라이드의 참조를 가져옵니다.  
3. 메인 효과 시퀀스를 가져옵니다.  
4. 각 애니메이션 효과에 포함된 `sound` 를 추출합니다.  

다음 Python 코드는 애니메이션 효과에 포함된 사운드를 추출하는 방법을 보여줍니다.

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다.
with slides.Presentation("EffectSound.pptx") as presentation:
    slide = presentation.slides[0]

    # 슬라이드의 메인 시퀀스를 가져옵니다.
    sequence = slide.timeline.main_sequence

    for effect in sequence:
        if effect.sound is None:
            continue

        # 효과 사운드를 바이트 배열로 추출합니다.
        audio = effect.sound.binary_data
```

## **애니메이션 이후 동작**

Aspose.Slides for .NET을 사용하면 애니메이션 효과의 After animation 속성을 변경할 수 있습니다.  

다음은 Microsoft PowerPoint에서의 애니메이션 효과 창 및 확장 메뉴입니다.

![example1_image](shape-after-animation.png)

PowerPoint Effect **After animation** 드롭다운 목록은 다음 속성과 일치합니다.

- `after_animation_type` 속성은 After animation 유형을 설명합니다.  
  * PowerPoint **More Colors**는 [COLOR](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다.  
  * PowerPoint **Don't Dim** 항목은 [DO_NOT_DIM](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형(기본 After animation 유형)과 일치합니다.  
  * PowerPoint **Hide After Animation** 항목은 [HIDE_AFTER_ANIMATION](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다.  
  * PowerPoint **Hide on Next Mouse Click** 항목은 [HIDE_ON_NEXT_MOUSE_CLICK](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형과 일치합니다.  
- `after_animation_color` 속성은 After animation 색상 형식을 정의합니다. 이 속성은 [COLOR](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/afteranimationtype/) 유형과 함께 작동합니다. 유형을 다른 값으로 변경하면 After animation 색상이 초기화됩니다.  

다음 Python 코드는 After animation 효과를 변경하는 방법을 보여줍니다.

```python
import aspose.slides as slides

# 프레젠테이션 파일을 나타내는 프레젠테이션 클래스를 인스턴스화합니다
with slides.Presentation("AnimImage_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 메인 시퀀스의 첫 번째 효과를 가져옵니다
    first_effect = first_slide.timeline.main_sequence[0]

    # after animation 유형을 Color로 변경합니다
    first_effect.after_animation_type = AfterAnimationType.COLOR

    # after animation 어둡게 할 색을 설정합니다
    first_effect.after_animation_color.color = Color.alice_blue

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimImage_AfterAnimation.pptx", slides.export.SaveFormat.PPTX)
```

## **텍스트 애니메이션**

Aspose.Slides는 애니메이션 효과의 *Animate text* 블록을 제어하기 위한 다음 속성을 제공합니다.

- `animate_text_type` 은 효과의 텍스트 애니메이션 유형을 설명합니다. 텍스트는 다음 방식으로 애니메이션됩니다.  
  - 모두 동시에 ([ALL_AT_ONCE](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/animatetexttype/) 유형)  
  - 단어별 ([BY_WORD](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/animatetexttype/) 유형)  
  - 글자별 ([BY_LETTER](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/animatetexttype/) 유형)  
- `delay_between_text_parts` 는 애니메이션 텍스트 파트(단어 또는 글자) 사이의 지연을 설정합니다. 양수 값은 효과 지속 시간의 백분율을, 음수 값은 초 단위 지연을 지정합니다.  

Effect Animate text 속성을 변경하는 방법은 다음과 같습니다.

1. [도형에 애니메이션 적용](#apply-animation-to-shape) 섹션에서 애니메이션 효과를 적용하거나 가져옵니다.  
2. `build_type` 속성을 [AS_ONE_OBJECT](https://reference.aspose.com/slides/ko/python-net/aspose.slides.animation/buildtype/) 값으로 설정하여 *By Paragraphs* 모드를 해제합니다.  
3. `animate_text_type` 와 `delay_between_text_parts` 속성에 새로운 값을 설정합니다.  
4. 수정된 PPTX 파일을 저장합니다.  

다음 Python 코드는 해당 작업을 시연합니다.

```python
import aspose.slides as slides

with slides.Presentation("AnimTextBox_out.pptx") as pres:
    first_slide = pres.slides[0]

    # 메인 시퀀스의 첫 번째 효과를 가져옵니다
    first_effect = first_slide.timeline.main_sequence[0]

    # 효과 텍스트 애니메이션 유형을 "As One Object"로 변경합니다
    first_effect.text_animation.build_type = slides.animation.BuildType.AS_ONE_OBJECT

    # 효과 Animate text 유형을 "By word"로 변경합니다
    first_effect.animate_text_type = slides.animation.AnimateTextType.BY_WORD

    # 단어 사이의 지연을 효과 지속 시간의 20%로 설정합니다
    first_effect.delay_between_text_parts = 20

    # PPTX 파일을 디스크에 저장합니다
    pres.save("AnimTextBox_AnimateText.pptx", slides.export.SaveFormat.PPTX)

```

## **FAQ**

**프레젠테이션을 웹에 게시할 때 애니메이션이 유지되도록 하려면 어떻게 해야 하나요?**

[Export to HTML5](/slides/ko/python-net/export-to-html5/)를 사용하고 [shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/html5options/animate_shapes/) 및 [transition](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/html5options/animate_transitions/) 애니메이션을 담당하는 [options](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/html5options/)를 활성화합니다. 일반 HTML은 슬라이드 애니메이션을 재생하지 않지만 HTML5는 재생합니다.  

**도형의 z‑order(레이어 순서)를 변경하면 애니메이션에 어떤 영향을 주나요?**

애니메이션 순서와 그리기 순서는 독립적입니다. 효과는 나타나고 사라지는 시점과 유형을 제어하고, [z-order](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/z_order_position/)는 무엇이 무엇을 가리는지를 결정합니다. 두 요소의 조합이 최종 화면 결과를 정의합니다. (이는 일반적인 PowerPoint 동작이며 Aspose.Slides의 효과‑도형 모델도 동일한 논리를 따릅니다.)  

**특정 효과를 비디오로 변환할 때 제한 사항이 있나요?**

일반적으로 [애니메이션은 지원됩니다](/slides/ko/python-net/convert-powerpoint-to-video/), 하지만 드물게 일부 효과가 다르게 렌더링될 수 있습니다. 사용 중인 효과와 라이브러리 버전으로 충분히 테스트하는 것이 권장됩니다.