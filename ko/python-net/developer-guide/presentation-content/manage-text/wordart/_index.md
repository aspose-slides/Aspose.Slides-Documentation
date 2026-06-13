---
title: Python에서 WordArt 효과 생성 및 적용
linktitle: WordArt
type: docs
weight: 110
url: /ko/python-net/wordart/
keywords:
- WordArt
- WordArt 만들기
- WordArt 템플릿
- WordArt 효과
- 그림자 효과
- 디스플레이 효과
- 글로우 효과
- WordArt 변환
- 3D 효과
- 외부 그림자 효과
- 내부 그림자 효과
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET에서 WordArt 효과를 생성하고 사용자 지정하는 방법을 배웁니다. 이 단계별 가이드는 개발자가 Python에서 스타일리시하고 전문적인 텍스트로 프레젠테이션을 향상시키는 데 도움이 됩니다."
---
## **개요**

WordArt 효과를 사용하면 PowerPoint 프레젠테이션에 시각적으로 매력적이고 스타일이 적용된 텍스트를 추가할 수 있습니다. Aspose.Slides를 사용하면 개발자가 Microsoft PowerPoint와 동일하게 WordArt를 프로그래밍 방식으로 만들고, 사용자 지정하고, 관리할 수 있습니다—Office를 설치할 필요 없이. 이 문서는 WordArt 작업에 대한 개요를 제공하며, 텍스트 변환, 채우기 스타일, 윤곽선, 그림자 및 기타 서식 옵션을 적용하여 프레젠테이션 콘텐츠를 보다 표현력 있고 매력적으로 만드는 방법을 포함합니다. WordArt는 텍스트를 그래픽 객체처럼 취급할 수 있게 해줍니다. 텍스트에 적용되는 효과 또는 특수 변형으로 구성되어 텍스트를 더 매력적이거나 눈에 띄게 합니다.

**Microsoft PowerPoint의 WordArt**

Microsoft PowerPoint에서 WordArt를 사용하려면 미리 정의된 WordArt 템플릿 중 하나를 선택해야 합니다. WordArt 템플릿은 텍스트 또는 해당 형태에 적용되는 일련의 효과 집합입니다.

**Aspose.Slides의 WordArt**

Aspose.Slides for Python via .NET 20.10에서 WordArt 지원을 구현했으며 이후 Aspose.Slides for Python via .NET 릴리스에서 해당 기능을 개선했습니다.

Aspose.Slides for Python via .NET을 사용하면 Python에서 자체 WordArt 템플릿(단일 효과 또는 효과 조합)을 쉽게 만들고 텍스트에 적용할 수 있습니다.

## 간단한 WordArt 템플릿 만들기 및 텍스트에 적용하기

**Aspose.Slides 사용** 

먼저, 이 Python 코드를 사용하여 간단한 텍스트를 만듭니다: 

```py
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    autoShape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 200, 200, 400, 200)
    textFrame = autoShape.text_frame

    portion = textFrame.paragraphs[0].portions[0]
    portion.text = "Aspose.Slides"

    pres.save("wordart-1.pptx", slides.export.SaveFormat.PPTX)
```
이제, 텍스트의 글꼴 높이를 더 크게 설정하여 효과를 더 두드러지게 하는 코드는 다음과 같습니다: 

```py 
    fontData = slides.FontData("Arial Black")
    portion.portion_format.latin_font = fontData
    portion.portion_format.font_height = 36
```

**Microsoft PowerPoint 사용**

Microsoft PowerPoint에서 WordArt 효과 메뉴로 이동합니다: 

![todo:image_alt_text](image-20200930113926-1.png)

오른쪽 메뉴에서 미리 정의된 WordArt 효과를 선택할 수 있습니다. 왼쪽 메뉴에서 새 WordArt에 대한 설정을 지정할 수 있습니다. 

다음은 사용 가능한 일부 매개변수 또는 옵션입니다: 

![todo:image_alt_text](image-20200930114015-3.png)

**Aspose.Slides 사용**

여기서는 SmallGrid 패턴 색상을 텍스트에 적용하고 이 코드를 사용하여 1픽셀 너비의 검정 텍스트 테두리를 추가합니다: 

```py 
    portion.portion_format.fill_format.fill_type = slides.FillType.PATTERN
    portion.portion_format.fill_format.pattern_format.fore_color.color = draw.Color.dark_orange
    portion.portion_format.fill_format.pattern_format.back_color.color = draw.Color.white
    portion.portion_format.fill_format.pattern_format.pattern_style = slides.PatternStyle.SMALL_GRID
                
    portion.portion_format.line_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.line_format.fill_format.solid_fill_color.color = draw.Color.black
```

결과 텍스트는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114108-4.png)

## 기타 WordArt 효과 적용

**Microsoft PowerPoint 사용**

프로그램 인터페이스에서 이러한 효과를 텍스트, 텍스트 블록, 도형 또는 유사한 요소에 적용할 수 있습니다: 

![todo:image_alt_text](image-20200930114129-5.png)

예를 들어, 그림자, 반사 및 글로우 효과는 텍스트에 적용할 수 있고; 3D 형식 및 3D 회전 효과는 텍스트 블록에 적용할 수 있으며; Soft Edges 속성은 도형 객체에 적용할 수 있습니다(3D 형식 속성이 설정되지 않은 경우에도 효과가 적용됩니다).

### 그림자 효과 적용

여기서는 텍스트에만 관련된 속성을 설정하려고 합니다. Python에서 다음 코드를 사용하여 텍스트에 그림자 효과를 적용합니다: 

```py 
    portion.portion_format.effect_format.enable_outer_shadow_effect()
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color = draw.Color.black
    portion.portion_format.effect_format.outer_shadow_effect.scale_horizontal = 100
    portion.portion_format.effect_format.outer_shadow_effect.scale_vertical = 65
    portion.portion_format.effect_format.outer_shadow_effect.blur_radius = 4.73
    portion.portion_format.effect_format.outer_shadow_effect.direction = 230
    portion.portion_format.effect_format.outer_shadow_effect.distance = 2
    portion.portion_format.effect_format.outer_shadow_effect.skew_horizontal = 30
    portion.portion_format.effect_format.outer_shadow_effect.skew_vertical = 0
    portion.portion_format.effect_format.outer_shadow_effect.shadow_color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.32)
```

Aspose.Slides API는 OuterShadow, InnerShadow 및 PresetShadow의 세 가지 유형의 그림자를 지원합니다.  

PresetShadow를 사용하면 사전 정의된 값을 사용하여 텍스트에 그림자를 적용할 수 있습니다. 

**Microsoft PowerPoint 사용**

PowerPoint에서는 하나의 그림자 유형만 사용할 수 있습니다. 예시는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114225-6.png)

**Aspose.Slides 사용**

Aspose.Slides는 실제로 두 종류의 그림자를 동시에 적용할 수 있습니다: InnerShadow와 PresetShadow. 

**참고:** 

- OuterShadow와 PresetShadow를 함께 사용할 경우, OuterShadow 효과만 적용됩니다. 
- OuterShadow와 InnerShadow를 동시에 사용할 경우, 적용되는 효과는 PowerPoint 버전에 따라 다릅니다. 예를 들어, PowerPoint 2013에서는 효과가 두 배가 되지만, PowerPoint 2007에서는 OuterShadow 효과만 적용됩니다. 

### 텍스트에 디스플레이 적용

Python 코드 샘플을 통해 텍스트에 디스플레이를 추가합니다: 

```py 
    portion.portion_format.effect_format.enable_reflection_effect()
    portion.portion_format.effect_format.reflection_effect.blur_radius = 0.5 
    portion.portion_format.effect_format.reflection_effect.distance = 4.72 
    portion.portion_format.effect_format.reflection_effect.start_pos_alpha = 0 
    portion.portion_format.effect_format.reflection_effect.end_pos_alpha = 60
    portion.portion_format.effect_format.reflection_effect.direction = 90 
    portion.portion_format.effect_format.reflection_effect.scale_horizontal = 100 
    portion.portion_format.effect_format.reflection_effect.scale_vertical = -100
    portion.portion_format.effect_format.reflection_effect.start_reflection_opacity = 60
    portion.portion_format.effect_format.reflection_effect.end_reflection_opacity = 0.9
    portion.portion_format.effect_format.reflection_effect.rectangle_align = slides.RectangleAlignment.BOTTOM_LEFT  
```

### 텍스트에 글로우 효과 적용

다음 코드를 사용하여 텍스트에 글로우 효과를 적용해 빛나거나 돋보이게 합니다: 

```py 
    portion.portion_format.effect_format.enable_glow_effect()
    portion.portion_format.effect_format.glow_effect.color.r = 255
    portion.portion_format.effect_format.glow_effect.color.color_transform.add(slides.ColorTransformOperation.SET_ALPHA, 0.54)
    portion.portion_format.effect_format.glow_effect.radius = 7
```

작업 결과는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114621-7.png)

{{% alert color="primary" %}} 그림자, 디스플레이 및 글로우 매개변수를 변경할 수 있습니다. 효과 속성은 텍스트의 각 부분에 개별적으로 설정됩니다. {{% /alert %}} 

### WordArt 변환 사용

다음 코드를 통해 Transform 속성(전체 텍스트 블록에 내재)을 사용합니다: 

```py 
textFrame.text_frame_format.transform = slides.TextShapeType.ARCH_UP_POUR
```

결과는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114712-8.png)

{{% alert color="primary" %}} Microsoft PowerPoint와 Aspose.Slides for Python via .NET 모두 일정 수의 미리 정의된 변환 유형을 제공합니다. {{% /alert %}} 

**PowerPoint 사용** 

미리 정의된 변환 유형에 접근하려면 다음 경로를 따라갑니다: **Format** -> **TextEffect** -> **Transform** 

**Aspose.Slides 사용** 

변환 유형을 선택하려면 TextShapeType 열거형을 사용합니다. 

### 텍스트 및 도형에 3D 효과 적용

다음 샘플 코드를 사용하여 텍스트 도형에 3D 효과를 설정합니다: 

```py 
    autoShape.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_bottom.height = 10.5
    autoShape.three_d_format.bevel_bottom.width = 10.5

    autoShape.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    autoShape.three_d_format.bevel_top.height = 12.5
    autoShape.three_d_format.bevel_top.width = 11

    autoShape.three_d_format.extrusion_color.color = draw.Color.orange
    autoShape.three_d_format.extrusion_height = 6

    autoShape.three_d_format.contour_color.color = draw.Color.dark_red
    autoShape.three_d_format.contour_width = 1.5

    autoShape.three_d_format.depth = 3

    autoShape.three_d_format.material = slides.MaterialPresetType.PLASTIC

    autoShape.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    autoShape.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    autoShape.three_d_format.light_rig.set_rotation(0, 0, 40)

    autoShape.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

결과 텍스트와 도형은 다음과 같습니다: 

![todo:image_alt_text](image-20200930114816-9.png)

다음 Python 코드를 사용하여 텍스트에 3D 효과를 적용합니다: 

```py 
    textFrame.text_frame_format.three_d_format.bevel_bottom.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_bottom.height = 3.5
    textFrame.text_frame_format.three_d_format.bevel_bottom.width = 3.5

    textFrame.text_frame_format.three_d_format.bevel_top.bevel_type = slides.BevelPresetType.CIRCLE
    textFrame.text_frame_format.three_d_format.bevel_top.height = 4
    textFrame.text_frame_format.three_d_format.bevel_top.width = 4

    textFrame.text_frame_format.three_d_format.extrusion_color.color = draw.Color.orange
    textFrame.text_frame_format.three_d_format.extrusion_height= 6

    textFrame.text_frame_format.three_d_format.contour_color.color = draw.Color.dark_red
    textFrame.text_frame_format.three_d_format.contour_width = 1.5

    textFrame.text_frame_format.three_d_format.depth= 3

    textFrame.text_frame_format.three_d_format.material = slides.MaterialPresetType.PLASTIC

    textFrame.text_frame_format.three_d_format.light_rig.direction = slides.LightingDirection.TOP
    textFrame.text_frame_format.three_d_format.light_rig.light_type = slides.LightRigPresetType.BALANCED
    textFrame.text_frame_format.three_d_format.light_rig.set_rotation(0, 0, 40)

    textFrame.text_frame_format.three_d_format.camera.camera_type = slides.CameraPresetType.PERSPECTIVE_CONTRASTING_RIGHT_FACING
```

작업 결과는 다음과 같습니다: 

![todo:image_alt_text](image-20200930114905-10.png)

{{% alert color="primary" %}} 텍스트 또는 그 도형에 3D 효과를 적용하고 효과 간 상호 작용은 특정 규칙에 따라 이루어집니다.

텍스트와 해당 텍스트를 포함하는 도형에 대한 씬을 고려합니다. 3D 효과는 3D 객체 표현과 객체가 배치된 씬을 포함합니다.

- 도형과 텍스트 모두에 씬이 설정된 경우, 도형 씬이 더 높은 우선순위를 갖고 텍스트 씬은 무시됩니다.
- 도형에 자체 씬이 없고 3D 표현만 있는 경우, 텍스트 씬이 사용됩니다.
- 그 외—도형에 원래 3D 효과가 없을 경우—도형은 평면이며 3D 효과는 텍스트에만 적용됩니다.

이 설명은 [ThreeDFormat.LightRig](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/) 및 [ThreeDFormat.Camera](https://reference.aspose.com/slides/ko/python-net/aspose.slides/threedformat/) 속성과 연결됩니다. {{% /alert %}} 

## **텍스트에 외부 그림자 효과 적용**
Aspose.Slides for Python via .NET은 텍스트 프레임에 포함된 텍스트에 그림자 효과를 적용할 수 있는 [**IOuterShadow**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/ioutershadow/) 및 [**IInnerShadow**](https://reference.aspose.com/slides/ko/python-net/aspose.slides.effects/iinnershadow/) 클래스를 제공합니다. 다음 단계에 따라 진행하십시오: 

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.  
3. 슬라이드에 Rectangle 유형의 AutoShape를 추가합니다.  
4. AutoShape와 연결된 TextFrame에 접근합니다.  
5. AutoShape의 FillType을 NoFill로 설정합니다.  
6. OuterShadow 클래스를 인스턴스화합니다.  
7. 그림자의 BlurRadius를 설정합니다.  
8. 그림자의 Direction을 설정합니다.  
9. 그림자의 Distance를 설정합니다.  
10. RectanglelAlign을 TopLeft로 설정합니다.  
11. 그림자의 PresetColor를 Black으로 설정합니다.  
12. 프레젠테이션을 PPTX 파일로 저장합니다.  

위 단계들을 구현한 Python 샘플 코드는 텍스트에 외부 그림자 효과를 적용하는 방법을 보여줍니다: 

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as pres:

    # 슬라이드의 참조 가져오기
    sld = pres.slides[0]

    # 사각형 타입의 AutoShape 추가
    ashp = sld.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 150, 50)

    # 사각형에 TextFrame 추가
    ashp.add_text_frame("Aspose TextBox")

    # 텍스트 그림자를 얻기 위해 도형 채우기 비활성화
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 외부 그림자 추가 및 필요한 모든 매개변수 설정
    ashp.effect_format.enable_outer_shadow_effect()
    shadow = ashp.effect_format.outer_shadow_effect
    shadow.blur_radius = 4.0
    shadow.direction = 45
    shadow.distance = 3
    shadow.rectangle_align = slides.RectangleAlignment.TOP_LEFT
    shadow.shadow_color.preset_color = slides.PresetColor.BLACK

    #프레젠테이션을 디스크에 저장
    pres.save("pres_out.pptx", slides.export.SaveFormat.PPTX)
```

## **도형에 내부 그림자 효과 적용**
다음 단계에 따라 진행하십시오: 

1. [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 인스턴스를 생성합니다.  
2. 슬라이드의 참조를 가져옵니다.  
3. Rectangle 유형의 AutoShape를 추가합니다.  
4. InnerShadowEffect를 활성화합니다.  
5. 필요한 모든 매개변수를 설정합니다.  
6. ColorType을 Scheme으로 설정합니다.  
7. Scheme Color를 설정합니다.  
8. 프레젠테이션을 [PPTX](https://docs.fileformat.com/presentation/pptx/) 파일로 저장합니다.  

위 단계들을 기반으로 한 이 샘플 코드는 Python에서 두 도형 사이에 커넥터를 추가하는 방법을 보여줍니다: 

```py
import aspose.slides as slides
import aspose.pydrawing as draw

with slides.Presentation() as presentation:
    # 슬라이드의 참조 가져오기
    slide = presentation.slides[0]

    # 사각형 타입의 AutoShape 추가
    ashp = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 150, 75, 400, 300)
    ashp.fill_format.fill_type = slides.FillType.NO_FILL

    # 사각형에 TextFrame 추가
    ashp.add_text_frame("Aspose TextBox")
    port = ashp.text_frame.paragraphs[0].portions[0]
    pf = port.portion_format
    pf.font_height = 50

    # inner_shadow_effect 활성화    
    ef = pf.effect_format
    ef.enable_inner_shadow_effect()

    # 필요한 모든 매개변수 설정
    ef.inner_shadow_effect.blur_radius = 8.0
    ef.inner_shadow_effect.direction = 90.0
    ef.inner_shadow_effect.distance = 6.0
    ef.inner_shadow_effect.shadow_color.b = 189

    # ColorType을 Scheme으로 설정
    ef.inner_shadow_effect.shadow_color.color_type = slides.ColorType.SCHEME

    # Scheme 색상 설정
    ef.inner_shadow_effect.shadow_color.scheme_color = slides.SchemeColor.ACCENT1

    # 프레젠테이션 저장
    presentation.save("WordArt_out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**다른 폰트나 스크립트(예: 아라비아어, 중국어)와 함께 WordArt 효과를 사용할 수 있나요?**  

예, Aspose.Slides는 유니코드를 지원하며 모든 주요 폰트와 스크립트에서 작동합니다. 그림자, 채우기 및 윤곽선과 같은 WordArt 효과는 언어에 관계없이 적용할 수 있지만, 폰트 가용성 및 렌더링은 시스템 폰트에 따라 달라질 수 있습니다.

**WordArt 효과를 슬라이드 마스터 요소에 적용할 수 있나요?**  

예, 마스터 슬라이드의 도형(제목 플레이스홀더, 페이지 번호, 배경 텍스트 등)에 WordArt 효과를 적용할 수 있습니다. 마스터 레이아웃에 대한 변경 사항은 모든 관련 슬라이드에 반영됩니다.

**WordArt 효과가 프레젠테이션 파일 크기에 영향을 미치나요?**  

약간 영향을 줍니다. 그림자, 글로우 및 그라데이션 채우기와 같은 WordArt 효과는 추가 서식 메타데이터로 인해 파일 크기를 약간 증가시킬 수 있지만, 차이는 일반적으로 무시할 수준입니다.

**프레젠테이션을 저장하지 않고 WordArt 효과의 결과를 미리 볼 수 있나요?**  

예, [Shape](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/) 또는 [Slide](https://reference.aspose.com/slides/ko/python-net/aspose.slides/slide/) 클래스의 `get_image` 메서드를 사용하여 WordArt가 포함된 슬라이드를 이미지(PNG, JPEG 등)로 렌더링할 수 있습니다. 이를 통해 전체 프레젠테이션을 저장하거나 내보내기 전에 메모리 내 또는 화면에서 결과를 미리 볼 수 있습니다.