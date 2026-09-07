---
title: Python에서 OpenDocument 프레젠테이션 변환
linktitle: OpenDocument 변환
type: docs
weight: 10
url: /ko/python-java/convert-openoffice-odp/
keywords:
- ODP 변환
- ODP를 PDF로
- ODP를 HTML로
- ODP를 TIFF로
- ODP를 PPT로
- ODP를 PPTX로
- ODP를 XPS로
- OpenDocument
- 프레젠테이션
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 OpenDocument (ODP) 프레젠테이션을 PDF, HTML 및 기타 형식으로 변환합니다. OpenOffice 또는 LibreOffice를 설치할 필요가 없습니다."
---
## **소개**

Aspose.Slides for Python via Java은 OpenDocument (ODP) 프레젠테이션을 PDF, HTML, TIFF, XPS, PPT, PPTX와 같은 형식으로 변환할 수 있게 해줍니다. ODP 변환은 PowerPoint 변환과 동일한 API를 사용합니다: 소스 파일을 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)으로 로드하고 출력 형식을 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/)으로 선택합니다.

## **ODP를 PDF로 변환**

예제를 실행하기 전에 [설치 안내](/slides/ko/python-java/installation/)를 따르세요. `pres.odp`라는 이름의 ODP 프레젠테이션을 작업 디렉터리에 배치합니다. 다음 코드는 필요에 따라 JVM을 시작하고, 프레젠테이션을 로드한 뒤 `pres.pdf`로 저장합니다.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.odp")
try:
    presentation.save("pres.pdf", SaveFormat.Pdf)
finally:
    presentation.dispose()
```

## **다른 응용 프로그램에서 OpenDocument 프레젠테이션**

PowerPoint와 LibreOffice/OpenOffice Impress는 서로 다른 프레젠테이션 기능과 렌더링 동작을 지원하므로 ODP 프레젠테이션이 다르게 보일 수 있습니다. 레이아웃이 복잡한 서식에 의존하는 경우 변환된 프레젠테이션을 검토하십시오.

호환성 차이는 다음에 영향을 줄 수 있습니다:

- 다른 도형에 대한 쌓임 순서 및 그림 채우기 지원을 포함한 표
- 텍스트 회전 및 정렬
- 텍스트에 적용된 그림, 그라데이션 및 패턴 채우기
- 번호 매기기 및 글머리표 목록

아래 이미지는 LibreOffice Impress에서 만든 목록 예시입니다:

![LibreOffice Impress에서 만든 ODP 목록 예시](odp-list-example.png)

Aspose.Slides는 LibreOffice/OpenOffice Impress와의 호환성을 위해 ODP 목록을 저장합니다.

기능 호환성에 대한 자세한 내용은 [Microsoft의 OpenDocument 프레젠테이션 형식 가이드](https://support.microsoft.com/en-us/office/use-powerpoint-to-save-or-open-a-presentation-in-the-opendocument-presentation-odp-format-94805e84-1b09-4c98-a8b5-0da2a52242a0)를 참조하십시오.

## **FAQ**

**변환 후 ODP 파일의 서식이 변경되면 어떻게 하나요?**

ODP와 PowerPoint는 서로 다른 프레젠테이션 모델을 사용합니다. 표, 글꼴, 채우기 스타일이 다르게 렌더링될 수 있습니다. 필요한 글꼴이 있는지 확인하고, 출력물을 검토한 뒤 레이아웃이나 서식을 조정하십시오.

**ODP 파일을 변환하려면 OpenOffice 또는 LibreOffice를 설치해야 하나요?**

아니요. Aspose.Slides for Python via Java은 해당 응용 프로그램 없이도 프레젠테이션을 처리합니다. 호환되는 Java 런타임과 Python 패키지만 있으면 됩니다.

**ODP 프레젠테이션을 변환할 때 PDF 출력을 사용자 지정할 수 있나요?**

예. [PdfOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/pdfoptions/)을 사용하여 이미지 품질 및 압축과 같은 PDF 내보내기 설정을 구성할 수 있습니다.

**서버나 컨테이너에서 ODP 프레젠테이션을 변환할 수 있나요?**

예. Python 패키지, 호환되는 Java 런타임 및 프레젠테이션에 필요한 글꼴을 대상 환경에 설치하면 됩니다. 별도의 오피스 응용 프로그램은 필요하지 않습니다.