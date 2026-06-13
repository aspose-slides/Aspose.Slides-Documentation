---
title: Python에서 프레젠테이션을 애니메이션 GIF로 변환
linktitle: 프레젠테이션을 GIF로
type: docs
weight: 65
url: /ko/python-net/convert-powerpoint-to-animated-gif/
keywords:
- 애니메이션 GIF
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- ODP 변환
- PowerPoint를 GIF로
- OpenDocument를 GIF로
- 프레젠테이션을 GIF로
- 슬라이드를 GIF로
- PPT를 GIF로
- PPTX를 GIF로
- ODP를 GIF로
- 기본 설정
- 맞춤 설정
- Python
- Aspose.Slides
description: "Aspose.Slides for Python을 사용하여 PowerPoint 프레젠테이션(PPT, PPTX) 및 OpenDocument 파일(ODP)을 애니메이션 GIF로 손쉽게 변환합니다. 빠르고 고품질의 결과를 제공합니다."
---
## **개요**

Aspose.Slides는 몇 줄의 코드만으로 PowerPoint 프레젠테이션을 애니메이션 GIF 파일로 변환할 수 있습니다. 이는 웹 페이지, 메신저 또는 문서에 삽입할 수 있는 가볍고 널리 지원되는 애니메이션 형식으로 슬라이드 내용을 공유해야 할 때 유용합니다. 이 문서에서는 기본 설정을 사용하여 프레젠테이션을 GIF로 내보내는 방법과 [GifOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/gifoptions/) 링크를 통해 프레임 크기, 슬라이드 지연 시간, 전환 프레임 레이트와 같은 옵션을 구성하여 출력을 사용자 지정하는 방법을 설명합니다.

## **기본 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

다음은 Python 샘플 코드로 표준 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

pres = slides.Presentation(path + "pres.pptx")
pres.save("pres.gif", slides.export.SaveFormat.GIF)
```

애니메이션 GIF는 기본 매개변수로 생성됩니다.

{{%  alert  title="TIP"  color="primary"  %}} 
GIF 매개변수를 사용자 지정하려면 [GifOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/gifoptions/) 클래스를 사용할 수 있습니다. 아래 샘플 코드를 참조하세요. 
{{% /alert %}} 

## **맞춤 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환**

다음은 Python에서 맞춤 설정을 사용하여 프레젠테이션을 애니메이션 GIF로 변환하는 샘플 코드입니다:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

pres = slides.Presentation(path + "pres.pptx")

options = slides.export.GifOptions()
options.frame_size = drawing.Size(960, 720) # 결과 GIF의 크기  
options.default_delay = 2000 # 각 슬라이드가 다음 슬라이드로 바뀔 때까지 표시되는 시간
options.transition_fps = 35  # 전환 애니메이션 품질을 높이기 위해 FPS를 증가시킵니다

pres.save("pres.gif", slides.export.SaveFormat.GIF, options)
```

{{% alert title="Info" color="info" %}}
Aspose에서 개발한 무료 [Text to GIF](https://products.aspose.app/slides/ko/text-to-gif) 변환기를 확인해 보세요. 
{{% /alert %}}

## **FAQ**

**프레젠테이션에 사용된 글꼴이 시스템에 설치되지 않은 경우에는 어떻게 해야 하나요?**

누락된 글꼴을 설치하거나 [대체 글꼴 구성](/slides/ko/python-net/powerpoint-fonts/)을 설정하세요. Aspose.Slides가 대체하지만 화면이 다르게 표시될 수 있습니다. 브랜드 일관성을 위해 필요한 글꼴이 명시적으로 사용 가능하도록 항상 확인하십시오.

**GIF 프레임에 워터마크를 오버레이할 수 있나요?**

예. 내보내기 전에 마스터 슬라이드 또는 개별 슬라이드에 [반투명 객체/로고 추가](/slides/ko/python-net/watermark/)를 추가하면 워터마크가 모든 프레임에 표시됩니다.