---
title: Python via Java에서 PowerPoint 프레젠테이션을 XML로 변환
linktitle: PowerPoint에서 XML로
type: docs
weight: 145
url: /ko/python-java/convert-powerpoint-to-xml/
keywords:
- PowerPoint를 XML로 변환
- 프레젠테이션을 XML로 변환
- PPT를 XML로
- PPTX를 XML로
- ODP를 XML로
- PowerPoint XML 프레젠테이션
- SaveFormat.Xml
- 프레젠테이션을 XML로 저장
- 프레젠테이션을 XML로 내보내기
- XML 스트림
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 Python via Java 환경에서 PowerPoint 및 OpenDocument 프레젠테이션을 PowerPoint XML 파일이나 스트림으로 변환합니다."
---
## **개요**

Aspose.Slides for Python via Java은 PowerPoint 프레젠테이션을 PowerPoint XML 프레젠테이션 형식으로 변환할 수 있습니다. XML 출력은 프레젠테이션 구조를 검사하고, 생성된 문서를 문제 해결하며, 자동화 테스트에서 출력물을 비교하거나, 프레젠테이션 패키지 대신 XML을 사용하는 워크플로와 통합해야 할 때 텍스트 기반 표현이 유용합니다.

Presentation.save 메서드와 [Xml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Xml) 값을 [SaveFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/) 클래스에서 사용합니다. 결과를 파일에 직접 쓰거나 스트림에 쓸 수 있습니다.

{{% alert color="info" title="참고" %}}

[SaveFormat.Xml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Xml)은 PowerPoint XML 프레젠테이션을 생성합니다. PPTX 패키지 내부에 저장된 개별 Office Open XML 파트를 추출하지 않습니다. `ppt/presentation.xml` 와 같은 정확한 PPTX 패키지 파트나 개별 슬라이드 XML 파일이 필요하면 PPTX 패키지를 직접 검사하십시오.

{{% /alert %}}

## **프레젠테이션을 XML 파일로 변환**

Presentation 클래스를 사용하여 소스 프레젠테이션을 로드한 다음, 출력 경로와 [SaveFormat.Xml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Xml)을 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)에 전달합니다. 소스는 PPT, PPTX 또는 ODP와 같이 로드가 지원되는 모든 프레젠테이션 형식일 수 있습니다.

다음 예제는 PPTX 프레젠테이션을 XML 파일로 변환합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    presentation.save("presentation.xml", SaveFormat.Xml)
finally:
    presentation.dispose()
```

## **XML 출력을 스트림에 쓰기**

[Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)의 스트림 오버로드를 사용하여 XML을 메모리 내에 유지하거나 웹 서비스, 스토리지 제공자, XML 처리 파이프라인 등 다른 구성 요소에 전달할 수 있습니다. 다음 예제는 결과를 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html) 에 쓰고, 생성된 XML을 Python 바이트 객체로 얻습니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

ByteArrayOutputStream = jpype.JClass("java.io.ByteArrayOutputStream")

presentation = Presentation("presentation.pptx")
try:
    xml_stream = ByteArrayOutputStream()
    try:
        presentation.save(xml_stream, SaveFormat.Xml)
        java_bytes = xml_stream.toByteArray()
        xml_data = bytes(java_bytes)

        # 워크플로의 다음 구성 요소에 xml_data를 전달합니다.
    finally:
        xml_stream.close()
finally:
    presentation.dispose()
```

## **XML을 프레젠테이션 및 내보내기 형식과 비교**

결과 사용 방식에 따라 출력 형식을 선택하십시오:

| 형식 | 출력 | 일반적인 사용 |
| --- | --- | --- |
| PowerPoint XML (`.xml`) | PowerPoint XML 프레젠테이션 | 구조 검사, 문제 해결, 생성된 출력 비교 및 XML 기반 통합 |
| PPT (`.ppt`) | 레거시 바이너리 프레젠테이션 파일 | 이전 PowerPoint 워크플로와의 호환성 |
| PPTX (`.pptx`) | 여러 파트를 포함하는 Office Open XML 패키지 | 일반 PowerPoint 편집 및 프레젠테이션 교환 |
| PDF or TIFF | 고정 레이아웃 페이지 또는 다중 페이지 이미지 | 보기, 인쇄 및 보관 |
| PNG, JPEG, or SVG | 개별 슬라이드의 렌더링된 표현 | 썸네일, 프리뷰 및 이미지 자산 |
| HTML or HTML5 | 웹 지향 프레젠테이션 출력 | 브라우저 보기 및 웹 게시 |

PPT 및 PPTX와 달리 XML 출력은 주로 검사 및 데이터 중심 워크플로를 위해 사용됩니다. PDF, TIFF, HTML 및 슬라이드 이미지 형식과 달리 슬라이드를 페이지나 시각적 자산으로 렌더링하는 것이 아니라 프레젠테이션 데이터를 나타냅니다. [supported file formats](/slides/ko/python-java/supported-file-formats/) 표에서는 PowerPoint XML 프레젠테이션을 저장 전용 형식으로 나열하므로, 워크플로에서 내보낸 파일을 다시 Aspose.Slides에 로드하여 계속 편집해야 할 경우에는 사용하지 마십시오.

## **FAQ**

**XML 내보내기가 PPTX 파일 저장과 동일합니까?**

아니요. PPTX는 여러 Office Open XML 파트를 포함하는 패키지이며, [SaveFormat.Xml](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Xml)은 PowerPoint XML 프레젠테이션 파일을 생성합니다.

**XML 출력을 디스크에 파일을 만들지 않고 저장할 수 있습니까?**

예. 쓰기 가능한 Java 출력 스트림을 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)에 전달하십시오. 예를 들어, 메모리 내 처리에는 [ByteArrayOutputStream](https://docs.oracle.com/en/java/javase/16/docs/api/java.base/java/io/ByteArrayOutputStream.html)을 사용할 수 있습니다.

**Aspose.Slides가 내보낸 XML 파일을 다시 로드할 수 있습니까?**

아니요. PowerPoint XML 프레젠테이션은 현재 저장은 지원하지만 로드는 지원하지 않습니다. 왕복 편집이 필요할 경우 PPTX 또는 다른 지원되는 프레젠테이션 형식을 사용하십시오.

**XML 변환이 각 슬라이드를 페이지나 이미지로 렌더링합니까?**

아니요. XML 변환은 구조화된 프레젠테이션 데이터를 기록합니다. 페이지 지향 출력이 필요하면 PDF 또는 TIFF를, 개별 슬라이드 이미지가 필요하면 PNG, JPEG 및 SVG를 사용하십시오.