---
title: Python via Java에서 프레젠테이션을 XAML으로 내보내기
linktitle: 프레젠테이션을 XAML으로
type: docs
weight: 30
url: /ko/python-java/export-to-xaml/
keywords:
- PowerPoint 내보내기
- OpenDocument 내보내기
- 프레젠테이션 내보내기
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- PowerPoint를 XAML으로
- OpenDocument를 XAML으로
- 프레젠테이션을 XAML으로
- PPT를 XAML으로
- PPTX를 XAML으로
- ODP를 XAML으로
- PPT를 XAML으로 저장
- PPTX를 XAML으로 저장
- ODP를 XAML으로 저장
- PPT를 XAML으로 내보내기
- PPTX를 XAML으로 내보내기
- ODP를 XAML으로 내보내기
- Python
- Java
- Aspose.Slides
description: "Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 XAML으로 내보냅니다. 기본 옵션을 사용하거나 숨겨진 슬라이드를 포함할 수 있습니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Python via Java를 사용하여 PowerPoint 및 OpenDocument 프레젠테이션을 XAML로 내보내는 방법을 설명합니다. XAML을 소개하고 기본 설정으로 내보내는 방법을 보여 주며, [XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)로 숨겨진 슬라이드를 포함하는 방법을 시연합니다.

예제는 Aspose.Slides for Python via Java와 호환되는 Java 런타임이 필요합니다. `pres.pptx` 파일을 현재 작업 디렉터리에 두세요. 각 예제는 JVM이 아직 실행 중이 아닌 경우에만 시작합니다.

## **XAML 소개**

XAML(Extensible Application Markup Language)은 사용자 인터페이스를 설명하기 위한 XML 기반 언어입니다. Windows Presentation Foundation(WPF)과 같은 프레임워크에서 사용됩니다. 시각 디자이너나 텍스트 편집기를 사용하여 XAML을 만들고 편집할 수 있습니다.

## **기본 옵션으로 프레젠테이션을 XAML로 내보내기**

입력 파일에서 [Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/)을 생성한 다음, [XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)를 [Presentation.save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save)에 전달하여 기본 설정으로 내보냅니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **사용자 지정 옵션으로 프레젠테이션을 XAML로 내보내기**

내보내기를 구성하려면 [XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/)를 사용하세요. 숨겨진 슬라이드를 포함하려면 저장하기 전에 `True`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 호출합니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, XamlOptions

presentation = Presentation("pres.pptx")
try:
    xaml_options = XamlOptions()
    xaml_options.setExportHiddenSlides(True)
    presentation.save(xaml_options)
finally:
    presentation.dispose()
```

## **FAQ**

**원본 폰트를 사용할 수 없을 때 폰트 대체를 어떻게 선택합니까?**

[XamlOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/) 객체에서 [setDefaultRegularFont](https://reference.aspose.com/slides/ko/python-java/aspose.slides/saveoptions/#setDefaultRegularFont)를 사용하여 대체 폰트를 지정합니다. 선택한 폰트가 내보내기 환경에 존재하는지 확인하세요.

**내보낸 마크업을 모든 XAML 프레임워크에서 사용할 수 있나요?**

XAML 프레임워크마다 지원하는 요소와 기능이 다릅니다. 애플리케이션에 통합하기 전에 목표 프레임워크에서 내보낸 마크업을 테스트하세요.

**숨겨진 슬라이드가 기본적으로 내보내지나요?**

아니요. 포함하려면 `True`와 함께 [setExportHiddenSlides](https://reference.aspose.com/slides/ko/python-java/aspose.slides/xamloptions/#setExportHiddenSlides)를 호출하십시오. 제외하려면 `False`로 설정해 두세요.