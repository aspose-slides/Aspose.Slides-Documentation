---
title: Aspose.Slides for Python via .NET
second_title: Aspose.Slides for Python
type: docs
weight: 35
url: /ko/python-net/
is_root: true
keywords:
- Aspose.Slides for Python
- Python용 PowerPoint 자동화
- Python PPT 라이브러리
- Python에서 PowerPoint를 PDF로 내보내기
- Python에서 PowerPoint를 SVG로 내보내기
- Python에서 PowerPoint 편집
- Microsoft Office 없이 Python PowerPoint
- Python으로 PPTX 관리
- Python 슬라이드 미리보기
- Python에서 슬라이드에 오디오 추가
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET은 텍스트, 도형, 표 및 애니메이션 관리, 슬라이드에 오디오와 비디오 추가, 슬라이드 미리보기, SVG, PDF 등 다양한 형식으로 내보내기 등 포괄적인 기능을 제공합니다."
---
{{% alert color="primary" %}}

**Aspose.Slides for Python via .NET에 오신 것을 환영합니다**

![Aspose.Slides for Python via .NET Product Logo](aspose_slides-for-python.png)

Aspose.Slides for Python via .NET은 Microsoft PowerPoint® 없이도 애플리케이션에서 PowerPoint® 프레젠테이션을 읽고 쓸 수 있는 강력한 클래스 라이브러리입니다.

Python 개발자를 위해 전체 기능의 PowerPoint® 문서 관리를 제공하는 최초이자 유일한 구성 요소입니다.

Aspose.Slides for Python via .NET은 텍스트, 도형, 표, 애니메이션 작업; 오디오 및 비디오 추가; 슬라이드 미리 보기; SVG, PDF 등 다양한 형식으로 슬라이드 내보내기와 같은 광범위한 기능을 포함합니다.

{{% /alert %}}

## Aspose.Slides for Python via .NET 설치

```bash
pip install aspose.slides
```

패키지에는 필요한 .NET 런타임이 포함되어 있어 별도로 설치할 것이 없으며 Microsoft PowerPoint가 필요하지 않습니다. Windows, Linux 또는 macOS에서 Python 3.7 이상을 지원합니다.

## Python에서 PowerPoint 프레젠테이션 만들기

이 예제는 프레젠테이션을 생성하고, 첫 번째 슬라이드에 텍스트가 포함된 도형을 추가한 뒤 결과를 PPTX와 PDF 형식으로 저장합니다.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    shape = slide.shapes.add_auto_shape(slides.ShapeType.RECTANGLE, 50, 150, 600, 100)
    shape.text_frame.text = "Created with Aspose.Slides for Python via .NET"

    presentation.save("presentation.pptx", slides.export.SaveFormat.PPTX)
    presentation.save("presentation.pdf", slides.export.SaveFormat.PDF)
```

실행하면 작업 디렉터리에 `presentation.pptx`(약 34 KB)와 `presentation.pdf`(약 36 KB)가 생성됩니다.

라이선스가 없으면 라이브러리가 평가 모드로 실행되어 워터마크가 추가되고 슬라이드 수가 제한됩니다. 라이선스를 적용하려면 [라이선스](/slides/ko/python-net/licensing/)를 참조하세요.

## Aspose.Slides for Python via .NET 리소스

다음 유용한 리소스를 살펴보세요:

- [Aspose.Slides for Python via .NET 온라인 문서](/slides/ko/python-net/)
- [Aspose.Slides for Python via .NET 기능](/slides/ko/python-net/features-overview/)
- [Aspose.Slides for Python via .NET 릴리즈 노트](https://releases.aspose.com/slides/ko/python-net/release-notes/)
- [Aspose.Slides for Python via .NET 제품 페이지](https://products.aspose.com/slides/ko/python-net/)
- [Aspose.Slides for Python via .NET 다운로드](https://releases.aspose.com/slides/ko/python-net/)
- [Aspose.Slides for Python via .NET PyPi 패키지 설치](https://pypi.org/project/aspose.slides/)
- [Aspose.Slides for Python via .NET API 참조 가이드](https://reference.aspose.com/slides/ko/python-net/)
- [Aspose.Slides for Python via .NET 무료 지원 포럼](https://forum.aspose.com/c/slides/ko/11)
- [Aspose.Slides for Python via .NET 유료 지원 헬프데스크](https://helpdesk.aspose.com/)

## FAQ

### Aspose.Slides for Python via .NET란 무엇입니까?

Aspose.Slides for Python via .NET은 Microsoft PowerPoint가 설치되지 않은 상태에서도 PowerPoint 프레젠테이션(PPT, PPTX, ODP)을 프로그래밍 방식으로 만들고, 편집하고, 변환할 수 있는 강력한 Python 라이브러리입니다.

### Aspose.Slides가 지원하는 프레젠테이션 기능은 무엇입니까?

이 라이브러리는 텍스트, 도형, 표, 차트, 애니메이션, 마스터 슬라이드, 오디오, 비디오 등 다양한 요소를 관리할 수 있습니다. 또한 슬라이드 미리 보기, 렌더링, 인쇄, PDF, SVG, HTML 및 이미지와 같은 형식으로 내보내기도 지원합니다.

### Aspose.Slides를 사용해 프레젠테이션을 다른 형식으로 변환할 수 있습니까?

네. Aspose.Slides는 PowerPoint 파일을 PDF, SVG, HTML, JPG, PNG, TIFF 등 다양한 형식으로 고품질 및 높은 성능으로 변환할 수 있습니다.

### Aspose.Slides 사용에 Microsoft PowerPoint가 필요합니까?

아니요. Aspose.Slides는 독립형 API이며 Microsoft Office나 타사 소프트웨어가 필요하지 않습니다.

### Aspose.Slides for Python via .NET가 지원하는 플랫폼은 무엇입니까?

이 제품은 크로스 플랫폼이며 Windows, Linux 및 macOS 환경에서 동작합니다.

### Aspose.Slides for Python을 시작하려면 어떻게 해야 합니까?

PyPi를 통해 설치하고 [개발자 가이드](/slides/ko/python-net/developer-guide/)를 살펴보면 예제, API 참조 및 튜토리얼을 통해 시작할 수 있습니다.