---
title: Python에서 PowerPoint 프레젠테이션을 TIFF로 변환
titlelink: PowerPoint에서 TIFF로
type: docs
weight: 90
url: /ko/python-net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PowerPoint에서 TIFF로
- OpenDocument에서 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- ODP를 TIFF로
- Python
- Aspose.Slides
description: "Aspose.Slides for Python via .NET를 사용하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 고품질 TIFF 이미지로 쉽게 변환하는 방법을 배웁니다. 단계별 가이드와 코드 예제가 포함되어 있습니다."
---
## **소개**

TIFF (**Tagged Image File Format**)는 뛰어난 품질과 그래픽 상세 보존으로 널리 사용되는 비손실 래스터 이미지 형식입니다. 디자이너, 사진작가, 데스크톱 출판자는 종종 TIFF를 선택하여 이미지의 레이어, 색상 정확도 및 원본 설정을 유지합니다.

Aspose.Slides를 사용하면 PowerPoint 슬라이드(PPT, PPTX)와 OpenDocument 슬라이드(ODP)를 고품질 TIFF 이미지로 손쉽게 변환할 수 있어 프레젠테이션의 시각적 충실도를 최대한 유지할 수 있습니다.

## **프레젠테이션을 TIFF로 변환**

[save](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/#methods) 메서드를 사용하여 [Presentation](https://reference.aspose.com/slides/ko/python-net/aspose.slides/presentation/) 클래스로 전체 PowerPoint 프레젠테이션을 빠르게 TIFF로 변환할 수 있습니다. 결과 TIFF 이미지는 기본 슬라이드 크기에 해당합니다.

다음 Python 코드는 PowerPoint 프레젠테이션을 TIFF로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("presentation.pptx") as presentation:
    # 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF)
```

## **프레젠테이션을 흑백 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스의 [bw_conversion_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/) 속성을 사용하면 색상 슬라이드 또는 이미지를 흑백 TIFF로 변환할 때 사용할 알고리즘을 지정할 수 있습니다. 이 설정은 [compression_type](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/compression_type/) 속성이 `CCITT4` 또는 `CCITT3`으로 설정된 경우에만 적용됩니다.

{{% alert color="info" title="Note" %}}

[TiffOptions.bw_conversion_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/bw_conversion_mode/)은 전체 TIFF 이미지에 대한 픽셀 변환 알고리즘을 선택하는 내보내기 수준 설정입니다. 흑백 표시 모드가 활성화된 경우 개별 도형이 어떻게 표시될지 정의하려면 [Shape.black_white_mode](https://reference.aspose.com/slides/ko/python-net/aspose.slides/shape/black_white_mode/)을 사용하세요. 예제는 [Control Black-and-White Rendering for Shapes](/python-net/shape-formatting/#control-black-and-white-rendering-for-shapes) 를 참조하십시오.

{{% /alert %}}

예를 들어 "sample.pptx" 파일에 다음 슬라이드가 있다고 가정합니다:

![프레젠테이션 슬라이드](slide_black_and_white.png)

다음 Python 코드는 컬러 슬라이드를 흑백 TIFF로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

tiff_options = slides.export.TiffOptions()
tiff_options.compression_type = slides.export.TiffCompressionTypes.CCITT4
tiff_options.bw_conversion_mode = slides.export.BlackWhiteConversionMode.DITHERING

with slides.Presentation("sample.pptx") as presentation:
    presentation.save("output.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

결과:

![흑백 TIFF](TIFF_black_and_white.png)

## **사용자 지정 크기로 프레젠테이션을 TIFF로 변환**

특정 치수의 TIFF 이미지가 필요한 경우 [TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/)에 있는 속성을 사용하여 원하는 값을 설정할 수 있습니다. 예를 들어 [image_size](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/image_size/) 속성을 사용하면 결과 이미지의 크기를 정의할 수 있습니다.

다음 Python 코드는 사용자 지정 크기로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides
import aspose.pydrawing as drawing

# 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("sample.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    # 압축 유형을 설정합니다.
    tiff_options.compression_type = slides.export.TiffCompressionTypes.DEFAULT
    """
    Compression types:
        Default - Specifies the default compression scheme (LZW).
        None - Specifies no compression.
        CCITT3
        CCITT4
        LZW
        RLE
    """

    # 이미지 DPI를 설정합니다.
    tiff_options.dpi_x = 200
    tiff_options.dpi_y = 200

    # 이미지 크기를 설정합니다.
    tiff_options.image_size = drawing.Size(1728, 1078)

    notes_options = slides.export.NotesCommentsLayoutingOptions()
    notes_options.notes_position = slides.export.NotesPositions.BOTTOM_FULL
    tiff_options.slides_layout_options = notes_options

    # 지정된 크기로 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.save("custom_size.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

## **사용자 지정 이미지 픽셀 형식으로 프레젠테이션을 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/) 클래스의 [pixel_format](https://reference.aspose.com/slides/ko/python-net/aspose.slides.export/tiffoptions/pixel_format/) 속성을 사용하면 결과 TIFF 이미지에 원하는 픽셀 형식을 지정할 수 있습니다.

다음 Python 코드는 사용자 지정 픽셀 형식으로 PowerPoint 프레젠테이션을 TIFF 이미지로 변환하는 방법을 보여줍니다:

```py
import aspose.slides as slides

# 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
with slides.Presentation("Presentation.pptx") as presentation:
    tiff_options = slides.export.TiffOptions()

    tiff_options.pixel_format = slides.export.ImagePixelFormat.FORMAT_8BPP_INDEXED
    """
    ImagePixelFormat contains the following values (as stated in the documentation):
        FORMAT_1BPP_INDEXED - 1 bit per pixel, indexed.
        FORMAT_4BPP_INDEXED - 4 bits per pixel, indexed.
        FORMAT_8BPP_INDEXED - 8 bits per pixel, indexed.
        FORMAT_24BPP_RGB    - 24 bits per pixel, RGB.
        FORMAT_32BPP_ARGB   - 32 bits per pixel, ARGB.
    """

    # 지정된 픽셀 형식으로 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.save("Custom_Image_Pixel_Format.tiff", slides.export.SaveFormat.TIFF, tiff_options)
```

{{% alert title="Tip" color="info" %}}

Aspose의 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.

{{% /alert %}}

## **FAQ**

**전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드를 TIFF로 변환할 수 있나요?**

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

**프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?**

없습니다. Aspose.Slides는 슬라이드 수에 제한을 두지 않으며, 크기에 관계없이 프레젠테이션을 TIFF 형식으로 변환할 수 있습니다.

**슬라이드를 TIFF로 변환할 때 PowerPoint 애니메이션 및 전환 효과가 유지되나요?**

아니요, TIFF는 정적 이미지 형식입니다. 따라서 애니메이션과 전환 효과는 보존되지 않으며 슬라이드의 정적인 스냅샷만 내보내집니다.