---
title: Python에서 PowerPoint 프레젠테이션을 애니메이션 GIF로 변환
linktitle: PowerPoint를 GIF로
type: docs
weight: 65
url: /ko/python-java/convert-powerpoint-to-animated-gif/
keywords:
- 애니메이션 GIF
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 GIF로
- 프레젠테이션을 GIF로
- 슬라이드를 GIF로
- PPT를 GIF로
- PPTX를 GIF로
- PPT를 GIF로 저장
- PPTX를 GIF로 저장
- PPT를 GIF로 내보내기
- PPTX를 GIF로 내보내기
- 기본 설정
- 사용자 정의 설정
- PowerPoint
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 프레젠테이션(PPT, PPTX)을 쉽게 애니메이션 GIF로 변환합니다. 빠르고 고품질의 결과를 제공합니다."
---
## **개요**

Aspose.Slides for Python via Java은 몇 줄의 코드만으로 PowerPoint 프레젠테이션을 애니메이션 GIF 파일로 변환할 수 있게 해줍니다. 이는 웹 페이지, 메신저 또는 문서에서 슬라이드 내용을 공유할 때 유용합니다. 이 문서에서는 기본 설정을 사용하여 프레젠테이션을 내보내는 방법과 [GifOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/gifoptions/)를 통해 프레임 크기, 슬라이드 지연 시간 및 전환 프레임 속도를 사용자 정의하는 방법을 설명합니다.

## **기본 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

다음 Python 예제는 `pres.pptx`를 로드하고 표준 설정을 사용하여 애니메이션 GIF로 저장합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.save("pres.gif", SaveFormat.Gif)
finally:
    presentation.dispose()
```

{{% alert color="success" title="Tip" %}}
GIF 출력을 사용자 정의하려면 저장할 때 [GifOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/gifoptions/) 개체를 전달하면 됩니다. 아래 예제를 참고하세요.
{{% /alert %}}

## **사용자 정의 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

[setFrameSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/gifoptions/#setFrameSize)를 사용하여 출력 차원을 픽셀 단위로 지정하고, [setDefaultDelay](https://reference.aspose.com/slides/ko/python-java/aspose.slides/gifoptions/#setDefaultDelay)를 사용하여 기본 슬라이드 지연 시간을 밀리초 단위로 설정하며, [setTransitionFps](https://reference.aspose.com/slides/ko/python-java/aspose.slides/gifoptions/#setTransitionFps)를 사용하여 전환 프레임 속도를 제어합니다.

다음 예제는 960 × 720 GIF를 기본 슬라이드 지연 시간 2초와 전환을 위한 초당 35프레임으로 내보냅니다. 슬라이드의 자동 진행 시간이 설정되지 않은 경우 기본 지연 시간이 적용됩니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import GifOptions, Presentation, SaveFormat

Dimension = jpype.JClass("java.awt.Dimension")

presentation = Presentation("pres.pptx")
try:
    gif_options = GifOptions()
    frame_size = Dimension(960, 720)
    gif_options.setFrameSize(frame_size)
    gif_options.setDefaultDelay(2000)
    gif_options.setTransitionFps(35)

    presentation.save("pres.gif", SaveFormat.Gif, gif_options)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
Aspose의 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기도 사용해 볼 수 있습니다.
{{% /alert %}}

## **FAQ**

**프레젠테이션에 사용된 폰트가 시스템에 설치되지 않은 경우 어떻게 하나요?**

누락된 폰트를 설치하거나 [fallback 폰트 구성](/slides/ko/python-java/powerpoint-fonts/)을 수행하십시오. 폰트 대체는 내보낸 GIF의 모양을 변경할 수 있습니다. 프레젠테이션 디자인과 일치하도록 원본 폰트를 사용할 수 있도록 하는 것이 중요합니다.

**GIF 프레임에 워터마크를 오버레이할 수 있나요?**

예. 내보내기 전에 해당 마스터 슬라이드 또는 개별 슬라이드에 [반투명 개체 또는 로고 추가](/slides/ko/python-java/watermark/)를 수행하면 됩니다. 워터마크는 렌더링된 슬라이드 내용의 일부가 됩니다.