---
title: "Python에서 PPTX를 PPT로 변환"
linktitle: "PPTX를 PPT로"
type: docs
weight: 21
url: /ko/python-net/convert-pptx-to-ppt/
keywords:
- "PPTX를 PPT로"
- "PPTX를 PPT로 변환"
- "PowerPoint 변환"
- "프레젠테이션 변환"
- "Python"
- "Aspose.Slides"
description: "Aspose.Slides for Python을 .NET을 통해 사용하여 PPTX를 PPT로 손쉽게 변환합니다—프레젠테이션의 레이아웃과 품질을 유지하면서 PowerPoint 형식과 원활하게 호환됩니다."
---
## **개요**

Aspose.Slides for Python을 사용하면 최신 PPTX 프레젠테이션을 코드만으로 레거시 PPT 형식으로 변환할 수 있습니다. PPTX를 열어 PPT로 내보내면서 프레젠테이션의 내용과 레이아웃을 유지하므로 결과물이 이전 버전 PowerPoint와 호환됩니다. 동일한 워크플로를 사용해 PDF, XPS, ODP, HTML, 이미지와 같은 다른 출력도 생성할 수 있어 스크립트, CI 파이프라인 및 배치 처리에 원활하게 통합됩니다.

## **PPTX를 PPT로 변환**

PPTX를 PPT로 변환하려면 파일 이름과 저장 형식을 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스의 [save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/save/) 메서드에 그대로 전달하면 됩니다. 아래 Python 예제는 기본 옵션을 사용해 PPTX 프레젠테이션을 PPT로 변환합니다.

```py
import aspose.slides as slides

# PPTX 파일을 나타내는 Presentation 클래스를 인스턴스화합니다.
presentation = slides.Presentation("presentation.pptx")

# 프레젠테이션을 PPT 파일로 저장합니다.
presentation.save("presentation.ppt", slides.export.SaveFormat.PPT)
```

## **FAQ**

**레거시 PPT(97–2003) 형식으로 저장할 때 모든 PPTX 효과와 기능이 유지됩니까?**

항상 그런 것은 아닙니다. PPT 형식은 최신 기능 중 일부(예: 특정 효과, 개체 및 동작)를 지원하지 않아 변환 과정에서 기능이 단순화되거나 래스터화될 수 있습니다.

**전체 프레젠테이션이 아니라 선택한 슬라이드만 PPT로 변환할 수 있나요?**

직접 저장은 전체 프레젠테이션을 대상으로 합니다. 특정 슬라이드만 변환하려면 해당 슬라이드만 포함한 새 프레젠테이션을 만든 후 PPT로 저장하십시오; 또는 슬라이드별 변환 매개변수를 지원하는 서비스/API를 사용할 수 있습니다.

**비밀번호로 보호된 프레젠테이션이 지원되나요?**

예. 파일이 보호되었는지 감지하고 비밀번호로 열 수 있으며 저장된 PPT에 대해 [보호/암호화 설정을 구성](/slides/ko/python-net/password-protected-presentation/)할 수도 있습니다.

**또한 보기:**
- [Python에서 PPT 및 PPTX를 PDF로 변환 | 고급 옵션](/slides/ko/python-net/convert-powerpoint-to-pdf/)
- [Python에서 PowerPoint 프레젠테이션을 XPS로 변환](/slides/ko/python-net/convert-powerpoint-to-xps/)
- [Python에서 PowerPoint 프레젠테이션을 HTML로 변환](/slides/ko/python-net/convert-powerpoint-to-html/)
- [Python에서 PowerPoint 슬라이드를 PNG로 변환](/slides/ko/python-net/convert-powerpoint-to-png/)