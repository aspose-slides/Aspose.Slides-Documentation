---
title: PowerPoint 프레젠테이션을 .NET에서 TIFF로 변환
titlelink: PowerPoint에서 TIFF로
type: docs
weight: 90
url: /ko/net/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint에서 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint(PPT, PPTX) 프레젠테이션을 고품질 TIFF 이미지로 쉽게 변환하는 방법을 배우세요. C# 코드 예제."
---
## **소개**

TIFF(**Tagged Image File Format**)는 뛰어난 품질과 그래픽의 세밀한 보존으로 알려진 널리 사용되는 무손실 래스터 이미지 포맷입니다. 디자이너, 사진작가 및 데스크톱 퍼블리셔는 레이어, 색 정확도 및 원본 설정을 유지하기 위해 TIFF를 자주 선택합니다.

Aspose.Slides를 사용하면 PowerPoint 슬라이드(PPT, PPTX)와 OpenDocument 슬라이드(ODP)를 고품질 TIFF 이미지로 손쉽게 변환할 수 있어 프레젠테이션이 최대 시각적 충실도를 유지합니다.

## **프레젠테이션을 TIFF로 변환**

[Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 클래스가 제공하는 [Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/save/) 메서드를 사용하면 전체 PowerPoint 프레젠테이션을 빠르게 TIFF로 변환할 수 있습니다. 생성된 TIFF 이미지는 기본 슬라이드 크기에 해당합니다.

다음 C# 코드는 PowerPoint 프레젠테이션을 TIFF로 변환하는 방법을 보여줍니다:

```cs
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    // 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.Save("Output.tiff", SaveFormat.Tiff);
}
```

## **프레젠테이션을 흑백 TIFF로 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/) 클래스의 [BwConversionMode](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/bwconversionmode/) 속성을 사용하면 컬러 슬라이드 또는 이미지를 흑백 TIFF로 변환할 때 사용할 알고리즘을 지정할 수 있습니다. 이 설정은 [CompressionType](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/compressiontype/) 속성이 `CCITT4` 또는 `CCITT3`으로 설정된 경우에만 적용됩니다.

예를 들어, 다음과 같은 슬라이드가 포함된 "sample.pptx" 파일이 있다고 가정해 보겠습니다:

![프레젠테이션 슬라이드](slide_black_and_white.png)

다음 C# 코드는 컬러 슬라이드를 흑백 TIFF로 변환하는 방법을 보여줍니다:

```cs
TiffOptions tiffOptions = new TiffOptions
{
    CompressionType = TiffCompressionTypes.CCITT4,
    BwConversionMode = BlackWhiteConversionMode.Dithering
};

using (Presentation presentation = new Presentation("sample.pptx"))
{
    presentation.Save("output.tiff", SaveFormat.Tiff, tiffOptions);
}
```

결과:

![흑백 TIFF](TIFF_black_and_white.png)

## **사용자 지정 크기의 TIFF로 프레젠테이션 변환**

특정 치수의 TIFF 이미지가 필요하면 [TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/)에 있는 속성을 사용해 원하는 값을 설정할 수 있습니다. 예를 들어, [ImageSize](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/imagesize/) 속성을 사용하면 결과 이미지의 크기를 정의할 수 있습니다.

다음 C# 코드는 사용자 지정 크기의 TIFF 이미지로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```cs
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("sample.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();

    // 압축 유형을 설정합니다.
    tiffOptions.CompressionType = TiffCompressionTypes.Default;
    /* 
        압축 유형:
            Default - 기본 압축 방식(LZW)을 지정합니다.
            None - 압축을 사용하지 않음을 지정합니다.
            CCITT3
            CCITT4
            LZW
            RLE
    */

    // 깊이는 압축 유형에 따라 결정되며 수동으로 설정할 수 없습니다.

    // 이미지 DPI를 설정합니다.
    tiffOptions.DpiX = 200;
    tiffOptions.DpiY = 200;

    // 이미지 크기를 설정합니다.
    tiffOptions.ImageSize = new Size(1728, 1078);

    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    // 지정된 크기로 프레젠테이션을 TIFF로 저장합니다.
    presentation.Save("custom_size.tiff", SaveFormat.Tiff, tiffOptions);
}
```

## **사용자 지정 픽셀 형식의 TIFF로 프레젠테이션 변환**

[TiffOptions](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions) 클래스의 [PixelFormat](https://reference.aspose.com/slides/ko/net/aspose.slides.export/tiffoptions/pixelformat/) 속성을 사용하면 결과 TIFF 이미지에 원하는 픽셀 형식을 지정할 수 있습니다.

다음 C# 코드는 사용자 지정 픽셀 형식의 TIFF 이미지로 PowerPoint 프레젠테이션을 변환하는 방법을 보여줍니다:

```cs
// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
using (Presentation presentation = new Presentation("Demo_File.pptx"))
{
    TiffOptions tiffOptions = new TiffOptions();
   
    tiffOptions.PixelFormat = ImagePixelFormat.Format8bppIndexed;
    /*
    ImagePixelFormat은 문서에 명시된 다음 값들을 포함합니다:
        Format1bppIndexed - 픽셀당 1비트, 인덱스됨.
        Format4bppIndexed - 픽셀당 4비트, 인덱스됨.
        Format8bppIndexed - 픽셀당 8비트, 인덱스됨.
        Format24bppRgb    - 픽셀당 24비트, RGB.
        Format32bppArgb   - 픽셀당 32비트, ARGB.
    */

    // 지정된 이미지 크기로 프레젠테이션을 TIFF로 저장합니다.
    presentation.Save("Custom_Image_Pixel_Format.tiff", SaveFormat.Tiff, tiffOptions);
}
```

{{% alert title="Tip" color="primary" %}}
Aspose의 무료 PowerPoint 포스터 변환기를 확인해 보세요.
{{% /alert %}}

## **FAQ**

**전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드를 TIFF로 변환할 수 있나요?**

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

**프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?**

없습니다. Aspose.Slides는 슬라이드 수에 제한을 두지 않으며, 크기에 관계없이 모든 프레젠테이션을 TIFF 형식으로 변환할 수 있습니다.

**슬라이드를 TIFF로 변환할 때 PowerPoint 애니메이션 및 전환 효과가 유지되나요?**

아니요. TIFF는 정적 이미지 형식이므로 애니메이션 및 전환 효과는 유지되지 않으며 슬라이드의 정적인 스냅샷만 내보내집니다.