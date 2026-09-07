---
title: Python에서 PowerPoint 프레젠테이션을 XPS로 변환
linktitle: PowerPoint를 XPS로
type: docs
weight: 70
url: /ko/python-java/convert-powerpoint-to-xps/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 XPS로
- 프레젠테이션을 XPS로
- PPT를 XPS로
- PPTX를 XPS로
- PPT를 XPS로 저장
- PPTX를 XPS로 저장
- PPT를 XPS로 내보내기
- PPTX를 XPS로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 Python에서 PowerPoint PPT 및 PPTX 프레젠테이션을 XPS로 변환합니다. 기본 또는 사용자 지정 내보내기 설정을 사용할 수 있습니다."
---
## **개요**

Aspose.Slides for Python via Java은 PPT 또는 PPTX 파일을 XPS 형식으로 저장하여 PowerPoint 프레젠테이션을 XPS로 변환할 수 있도록 합니다. 이 문서에서는 XPS가 언제 유용한지 설명하고 기본 설정 또는 사용자 지정 [XpsOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xpsoptions/) 설정을 사용하여 프레젠테이션을 내보내는 방법을 보여줍니다.

## **XPS에 대하여**

XPS(XML Paper Specification)는 Microsoft에서 개발한 XML 기반 문서 형식입니다. 고정된 페이지를 설명하여 텍스트와 그래픽의 레이아웃을 유지하며 호환 소프트웨어로 보기와 인쇄가 가능합니다.

## **Microsoft XPS 형식을 사용해야 할 때**

문서 워크플로우에서 공유 또는 인쇄를 위해 고정 레이아웃 파일이 필요하고 XPS 호환 도구를 사용할 경우 XPS를 사용합니다. 받는 사람은 XPS를 지원하는 소프트웨어가 필요합니다. 워크플로우에 PDF가 필요하다면 [Convert PowerPoint to PDF](/slides/ko/python-java/convert-powerpoint-to-pdf/)를 참고하세요.

{{% alert color="info" title="Note" %}}
PPT 또는 PPTX 프레젠테이션을 XPS로 변환해 보려면 [무료 온라인 변환기](https://products.aspose.app/slides/ko/conversion)를 사용하십시오.
{{% /alert %}}

| 입력 PowerPoint 프레젠테이션 | 출력 XPS 문서 |
| --- | --- |
| ![원본 PowerPoint 프레젠테이션](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_1.png) | ![XPS로 변환된 프레젠테이션](convert-powerpoint-ppt-and-pptx-to-microsoft-xps-document_2.png) |

## **Aspose.Slides를 사용한 XPS 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스의 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드에 [SaveFormat.Xps](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveformat/#Xps)를 지정하여 프레젠테이션을 내보낼 수 있습니다. 기본 내보내기 설정을 사용하거나 [XpsOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xpsoptions/)를 제공하여 출력을 맞춤 설정할 수 있습니다.

아래 예제는 필요에 따라 Java 가상 머신을 시작하고 사용 후 프레젠테이션을 해제합니다. 입력 파일 이름을 PPT 또는 PPTX 파일 경로로 바꾸십시오.

### **기본 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 Python 코드는 기본 설정을 사용하여 프레젠테이션을 XPS로 변환합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 프레젠테이션을 XPS 문서로 저장합니다.
    presentation.save("output.xps", SaveFormat.Xps)
finally:
    presentation.dispose()
```

### **사용자 지정 설정을 사용하여 프레젠테이션을 XPS로 변환**

다음 예제는 [XpsOptions.setSaveMetafilesAsPng](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xpsoptions/#setSaveMetafilesAsPng) 메서드를 사용하여 메타파일을 PNG 이미지로 저장하고 결과 XPS 문서에 포함시킵니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, XpsOptions

presentation = Presentation("presentation.pptx")
try:
    xps_options = XpsOptions()
    xps_options.setSaveMetafilesAsPng(True)

    # 사용자 지정 XPS 설정으로 프레젠테이션을 저장합니다.
    presentation.save("output_custom.xps", SaveFormat.Xps, xps_options)
finally:
    presentation.dispose()
```

## **자주 묻는 질문**

**스트림에 XPS를 저장하고 파일이 아닌 다른 방식으로 저장할 수 있나요?**

예. [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드에는 Java 출력 스트림을 받을 수 있는 오버로드가 있습니다. Python via Java에서는 JPype를 통해 Java 바이트 배열 출력 스트림과 같은 호환 Java 스트림을 사용하여 내보낸 데이터를 메모리에 유지할 수 있습니다.

**숨긴 슬라이드가 XPS 출력에 포함되나요?**

숨긴 슬라이드는 기본적으로 제외됩니다. 포함하려면 저장 전에 [XpsOptions.setShowHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xpsoptions/#setShowHiddenSlides)를 `True`로 설정하십시오.

**애니메이션 및 슬라이드 전환 효과가 XPS에 보존되나요?**

아니요. XPS는 고정 페이지이므로 내보낸 슬라이드에서는 애니메이션이나 전환 효과가 재생되지 않습니다.