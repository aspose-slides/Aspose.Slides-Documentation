---
title: Python에서 PPT를 PPTX로 변환
linktitle: PPT를 PPTX로
type: docs
weight: 20
url: /ko/python-net/convert-ppt-to-pptx/
keywords:
- PPT 변환
- PPT를 PPTX로
- 파워포인트
- 프레젠테이션
- Python
- Aspose.Slides
description: "Python과 Aspose.Slides를 사용하여 레거시 PPT 프레젠테이션을 최신 PPTX로 빠르게 변환합니다 — 명확한 튜토리얼, 무료 코드 샘플, Microsoft Office 없이도 사용 가능."
---
## **개요**

이 문서에서는 Python을 사용하고 온라인 PPT to PPTX 변환 앱을 통해 PPT 형식의 PowerPoint 프레젠테이션을 PPTX 형식으로 변환하는 방법을 설명합니다. 다음 주제를 다룹니다:

- Python에서 PPT를 PPTX로 변환

## **Python PPT를 PPTX로 변환**

Python 샘플 코드를 보려면 아래 섹션, 즉 [PPT를 PPTX로 변환](#convert-ppt-to-pptx)을 참조하십시오. 코드는 PPT 파일을 로드하고 PPTX 형식으로 저장합니다. 저장 형식을 다르게 지정하면 PDF, XPS, ODP, HTML 등 다양한 형식으로도 저장할 수 있으며, 이에 대한 자세한 내용은 다음 기사에서 확인할 수 있습니다:

- [Python에서 PPT를 PDF로 변환](/slides/ko/python-net/convert-powerpoint-to-pdf/)
- [Python에서 PPT를 XPS로 변환](/slides/ko/python-net/convert-powerpoint-to-xps/)
- [Python에서 PPT를 HTML로 변환](/slides/ko/python-net/convert-powerpoint-to-html/)
- [Python에서 PPT를 ODP로 저장](/slides/ko/python-net/save-presentation/)
- [Python에서 PPT를 PNG로 변환](/slides/ko/python-net/convert-powerpoint-to-png/)

## **PPT to PPTX 변환에 대하여**
Aspose.Slides API를 사용하여 오래된 PPT 형식을 PPTX로 변환합니다. 수천 개의 PPT 프레젠테이션을 PPTX 형식으로 변환해야 하는 경우 프로그래밍 방식으로 처리하는 것이 최적의 솔루션입니다. Aspose.Slides API를 이용하면 몇 줄의 코드만으로 변환이 가능하며, API는 PPT 프레젠테이션을 PPTX로 변환하는 완전한 호환성을 지원합니다. 수행 가능한 작업은 다음과 같습니다:

- 마스터, 레이아웃 및 슬라이드의 복잡한 구조 변환
- 차트가 포함된 프레젠테이션 변환
- 그룹 도형, 자동 도형(사각형 및 타원 등) 및 사용자 정의 기하학 도형 변환
- 자동 도형에 텍스처 및 이미지 채우기 스타일이 적용된 프레젠테이션 변환
- 플레이스홀더, 텍스트 프레임 및 텍스트 홀더가 포함된 프레젠테이션 변환

{{% alert color="primary" %}}

다음 **Aspose.Slides PPT to PPTX 변환** 앱을 확인해 보세요:

[](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

[![todo:image_alt_text](ppt-to-pptx.png)](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx)

이 앱은 **Aspose.Slides API** 기반으로 구축되었으며, 기본 PPT to PPTX 변환 기능을 실시간으로 확인할 수 있습니다. Aspose.Slides Conversion은 PPT 형식의 프레젠테이션 파일을 드롭하면 PPTX로 변환하여 다운로드할 수 있는 웹 앱입니다.

다른 실시간 **Aspose.Slides Conversion** 예제를 찾아보세요.
{{% /alert %}}

## **PPT를 PPTX로 변환**
PPT를 PPTX로 변환하려면 파일 이름과 저장 형식을 [**Save**](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 메서드에 전달하면 됩니다. 아래 Python 코드 샘플은 기본 옵션을 사용하여 PPT를 PPTX로 변환합니다.

```python
import aspose.slides as slides

# PPT 파일을 나타내는 Presentation 객체를 생성합니다
pres = slides.Presentation("PPTtoPPTX.ppt")

# 프레젠테이션을 PPTX 형식으로 저장합니다
pres.save("PPTtoPPTX_out.pptx", slides.export.SaveFormat.PPTX)
```

[PPT와 PPTX](/slides/ko/python-net/ppt-vs-pptx/) 프레젠테이션 형식에 대한 자세한 내용과 [Aspose.Slides가 PPT to PPTX 변환을 지원하는 방법](/slides/ko/python-net/convert-ppt-to-pptx/)을 확인하십시오.

## **FAQ**

**PPT와 PPTX 형식의 차이점은 무엇인가요?**

PPT는 Microsoft PowerPoint에서 사용하던 오래된 바이너리 파일 형식이며, PPTX는 Microsoft Office 2007부터 도입된 XML 기반의 최신 형식입니다. PPTX 파일은 성능이 우수하고 파일 크기가 작으며 데이터 복구가 향상됩니다.

**Python을 사용해 PPT를 PPTX로 변환할 수 있나요?**

예, Aspose.Slides for Python via .NET 라이브러리를 사용하면 몇 줄의 코드만으로 PPT 파일을 로드하고 PPTX 형식으로 저장할 수 있습니다.

**Aspose.Slides가 여러 PPT 파일을 PPTX로 일괄 변환하는 것을 지원하나요?**

예, 루프 내에서 Aspose.Slides를 사용하면 여러 PPT 파일을 프로그래밍 방식으로 PPTX로 일괄 변환할 수 있어 배치 변환 시나리오에 적합합니다.

**변환 후 내용과 서식이 유지되나요?**

Aspose.Slides는 프레젠테이션을 고품질로 변환합니다. 슬라이드 레이아웃, 애니메이션, 도형, 차트 및 기타 디자인 요소가 PPT to PPTX 변환 과정에서 그대로 유지됩니다.

**PPT 파일에서 PDF나 HTML 같은 다른 형식으로 변환할 수 있나요?**

예, Aspose.Slides는 PPT 파일을 PDF, XPS, HTML, ODP 및 PNG, JPEG과 같은 이미지 형식으로 변환하는 것을 지원합니다.

**Microsoft PowerPoint가 설치되지 않아도 PPT를 PPTX로 변환할 수 있나요?**

예, Aspose.Slides for Python via .NET는 독립형 API이며 Microsoft PowerPoint나 타사 소프트웨어 없이도 변환을 수행할 수 있습니다.

**PPT to PPTX 변환을 위한 온라인 도구가 있나요?**

예, 코드를 작성하지 않고도 브라우저에서 직접 변환할 수 있는 무료 [Aspose.Slides PPT to PPTX Converter](https://products.aspose.app/slides/ko/conversion/ppt-to-pptx) 웹 애플리케이션을 사용할 수 있습니다.