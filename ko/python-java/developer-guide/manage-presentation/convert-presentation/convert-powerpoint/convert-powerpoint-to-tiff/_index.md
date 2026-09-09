---
title: Python에서 PowerPoint 프리젠테이션을 TIFF로 변환
linktitle: PowerPoint를 TIFF로
type: docs
weight: 90
url: /ko/python-java/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프리젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로
- 프리젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- Python
- Java
- Aspose.Slides
description: "Python via Java용 Aspose.Slides를 사용하여 PowerPoint(PPT, PPTX) 프리젠테이션을 고품질 TIFF 이미지로 손쉽게 변환하는 방법을 코드 예제와 함께 배우세요."
---
## **소개**

TIFF (**Tagged Image File Format**)는 다중 페이지와 무손실 압축을 지원하는 래스터 이미지 포맷입니다. 하나의 이미지 파일에 렌더링된 슬라이드를 저장하는 데 유용합니다.

Aspose.Slides for Python via Java를 사용하면 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 TIFF로 변환할 수 있습니다. 아래 예제는 필요 시 Java 가상 머신을 시작하고 사용 후 프레젠테이션을 해제합니다.

## **프레젠테이션을 TIFF로 변환**

[Presentation](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/) 클래스가 제공하는 [save](https://reference.aspose.com/slides/ko/python-java/aspose.slides/presentation/#save) 메서드를 사용하면 전체 PowerPoint 프레젠테이션을 빠르게 TIFF로 변환할 수 있습니다. 결과 멀티페이지 TIFF에는 기본 크기의 각 슬라이드가 렌더링된 이미지가 포함됩니다.

다음 코드는 PowerPoint 프레젠테이션을 TIFF로 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("presentation.pptx")
try:
    # 모든 슬라이드를 다중 페이지 TIFF 파일로 저장합니다.
    presentation.save("output.tiff", SaveFormat.Tiff)
finally:
    presentation.dispose()
```

## **프레젠테이션을 흑백 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/) 클래스의 [setBwConversionMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setBwConversionMode) 메서드를 사용하면 색상이 있는 슬라이드나 이미지를 흑백 TIFF로 변환할 때 사용할 알고리즘을 지정할 수 있습니다. 이 설정은 [setCompressionType](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setCompressionType) 메서드가 [TiffCompressionTypes.CCITT4](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffcompressiontypes/#CCITT4) 또는 [TiffCompressionTypes.CCITT3](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffcompressiontypes/#CCITT3) 로 설정된 경우에만 적용됩니다.

{{% alert color="info" title="참고" %}}

[TiffOptions.setBwConversionMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setBwConversionMode)은 전체 TIFF 이미지에 대한 픽셀 변환 알고리즘을 선택하는 내보내기 수준 설정입니다. 개별 도형이 흑백 표시 모드에서 어떻게 표시될지 정의하려면 [Shape.setBlackWhiteMode](https://reference.aspose.com/slides/ko/python-java/aspose.slides/shape/#setBlackWhiteMode)을 사용하십시오. 예제는 [Control Black-and-White Rendering for Shapes](/slides/ko/python-java/shape-formatting/#control-black-and-white-rendering-for-shapes)를 참고하세요.

{{% /alert %}}

예를 들어 "sample.pptx" 파일에 다음과 같은 슬라이드가 있다고 가정합니다:

![프레젠테이션 슬라이드](slide_black_and_white.png)

다음 코드는 컬러 슬라이드를 흑백 TIFF로 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BlackWhiteConversionMode, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions

tiff_options = TiffOptions()
tiff_options.setCompressionType(TiffCompressionTypes.CCITT4)
tiff_options.setBwConversionMode(BlackWhiteConversionMode.Dithering)

presentation = Presentation("sample.pptx")
try:
    presentation.save("output.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

결과:

![흑백 TIFF](TIFF_black_and_white.png)

## **사용자 정의 크기의 TIFF로 프레젠테이션 변환**

특정 크기의 TIFF 이미지가 필요한 경우 [TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/)에서 제공하는 메서드를 사용해 원하는 값을 설정할 수 있습니다. 예를 들어 [setImageSize](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setImageSize) 메서드를 사용하면 결과 이미지의 크기를 정의할 수 있습니다.

다음 코드는 사용자 정의 크기의 TIFF 이미지로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NotesCommentsLayoutingOptions, NotesPositions, Presentation, SaveFormat, TiffCompressionTypes, TiffOptions
from java.awt import Dimension

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setCompressionType(TiffCompressionTypes.Default)

    # 수평 및 수직 해상도를 설정합니다.
    tiff_options.setDpiX(200)
    tiff_options.setDpiY(200)

    # 출력 크기를 픽셀 단위로 설정합니다.
    image_size = Dimension(1728, 1078)
    tiff_options.setImageSize(image_size)

    # 각 슬라이드 아래에 전체 발표자 메모를 포함합니다.
    notes_options = NotesCommentsLayoutingOptions()
    notes_options.setNotesPosition(NotesPositions.BottomFull)
    tiff_options.setSlidesLayoutOptions(notes_options)

    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

## **사용자 정의 이미지 픽셀 형식의 TIFF로 프레젠테이션 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/) 클래스의 [setPixelFormat](https://reference.aspose.com/slides/ko/python-java/aspose.slides/tiffoptions/#setPixelFormat) 메서드를 사용하면 결과 TIFF 이미지에 원하는 픽셀 형식을 지정할 수 있습니다.

다음 코드는 사용자 정의 픽셀 형식의 TIFF 이미지로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ImagePixelFormat, Presentation, SaveFormat, TiffOptions

presentation = Presentation("presentation.pptx")
try:
    tiff_options = TiffOptions()
    tiff_options.setPixelFormat(ImagePixelFormat.Format8bppIndexed)

    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiff_options)
finally:
    presentation.dispose()
```

{{% alert title="팁" color="success" %}}

Aspose의 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.

{{% /alert %}}

## **FAQ**

**전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드를 TIFF로 변환할 수 있나요?**

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

**프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?**

TIFF 내보내기에 고정된 슬라이드 수 제한은 없습니다. 사용 가능한 메모리, 슬라이드 복잡도 및 출력 크기에 따라 처리 가능한 프레젠테이션 크기가 달라집니다.

**슬라이드를 TIFF로 변환할 때 PowerPoint 애니메이션 및 전환 효과가 유지되나요?**

아니요, TIFF는 정적 이미지 포맷입니다. 따라서 애니메이션 및 전환 효과는 보존되지 않으며 슬라이드의 정적 스냅샷만 내보내집니다.