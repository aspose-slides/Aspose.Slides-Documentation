---
title: Android에서 PowerPoint 프레젠테이션을 TIFF로 변환
titlelink: PowerPoint를 TIFF로
type: docs
weight: 90
url: /ko/androidjava/convert-powerpoint-to-tiff/
keywords:
- PowerPoint 변환
- OpenDocument 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 TIFF로
- 프레젠테이션을 TIFF로
- 슬라이드를 TIFF로
- PPT를 TIFF로
- PPTX를 TIFF로
- PPT를 TIFF로 저장
- PPTX를 TIFF로 저장
- PPT를 TIFF로 내보내기
- PPTX를 TIFF로 내보내기
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android와 Java 코드 예제를 사용하여 PowerPoint(PPT, PPTX) 프레젠테이션을 고품질 TIFF 이미지로 쉽게 변환하는 방법을 배우세요."
---
## **소개**

TIFF(**Tagged Image File Format**)는 뛰어난 품질과 그래픽의 상세한 보존으로 알려진 널리 사용되는 무손실 래스터 이미지 형식입니다. 디자이너, 사진작가, 데스크톱 출판자는 종종 이미지의 레이어, 색 정확도 및 원본 설정을 유지하기 위해 TIFF를 선택합니다.

Aspose.Slides를 사용하면 PowerPoint 슬라이드(PPT, PPTX)와 OpenDocument 슬라이드(ODP)를 고품질 TIFF 이미지로 손쉽게 직접 변환할 수 있어 프레젠테이션이 최대 시각적 충실도를 유지하도록 할 수 있습니다. 

## **프레젠테이션을 TIFF로 변환**

Using the [save](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) method provided by the [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) class, you can quickly convert an entire PowerPoint presentation to TIFF. The resulting TIFF images correspond to the default slide size.

This code demonstrates how to convert a PowerPoint presentation to TIFF:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("presentation.pptx");
try {
    // 프레젠테이션을 TIFF 형식으로 저장합니다.
    presentation.save("output.tiff", SaveFormat.Tiff);
} finally {
    presentation.dispose();
}
```

## **프레젠테이션을 흑백 TIFF로 변환**

The method [setBwConversionMode](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/#setBwConversionMode-int-) in the [TiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/) class allows you to specify the algorithm used when converting a colored slide or image to a black-and-white TIFF. Note that this setting applies only when the [setCompressionType](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/#setCompressionType-int-) method is set to `CCITT4` or `CCITT3`.

"sample.pptx" 파일에 다음 슬라이드가 있다고 가정해 보겠습니다:

![프레젠테이션 슬라이드](slide_black_and_white.png)

This code demonstrates how to convert the colored slide to a black-and-white TIFF:

```java
import com.aspose.slides.*;

TiffOptions tiffOptions = new TiffOptions();
tiffOptions.setCompressionType(TiffCompressionTypes.CCITT4);
tiffOptions.setBwConversionMode(BlackWhiteConversionMode.Dithering);

Presentation presentation = new Presentation("sample.pptx");
try {
    presentation.save("output.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

결과:

![흑백 TIFF](TIFF_black_and_white.png)

## **맞춤 크기의 TIFF로 프레젠테이션 변환**

If you require a TIFF image with specific dimensions, you can set your desired values using methods available in [TiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/). For instance, the [setImageSize](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/#setImageSize-com.aspose.slides.android.Size-) method allows you to define the size of the resulting image.

This code demonstrates how to convert a PowerPoint presentation to TIFF images with a custom size:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    // 압축 유형을 설정합니다.
    tiffOptions.setCompressionType(TiffCompressionTypes.Default);
    /*
    압축 유형:
        Default - 기본 압축 방식(LZW)을 지정합니다.
        None - 압축을 하지 않음을 지정합니다.
        CCITT3
        CCITT4
        LZW
        RLE
    */

    // 깊이는 압축 유형에 따라 결정되며 수동으로 설정할 수 없습니다.

    // 이미지 DPI를 설정합니다.
    tiffOptions.setDpiX(200);
    tiffOptions.setDpiY(200);

    // 이미지 크기를 설정합니다.
    tiffOptions.setImageSize(new Size(1728, 1078));

    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomFull);
    tiffOptions.setSlidesLayoutOptions(notesOptions);

    // 지정된 크기로 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("tiff-ImageSize.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}   
```

## **맞춤 이미지 픽셀 형식으로 TIFF 변환**

Using the [setPixelFormat](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/#setPixelFormat-int-) method from the [TiffOptions](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/tiffoptions/) class, you can specify your preferred pixel format for the resulting TIFF image.

This code demonstrates how to convert a PowerPoint presentation to a TIFF image with a custom pixel format:

```java
import com.aspose.slides.*;

// 프레젠테이션 파일(PPT, PPTX, ODP 등)을 나타내는 Presentation 클래스를 인스턴스화합니다.
Presentation presentation = new Presentation("presentation.pptx");
try {
    TiffOptions tiffOptions = new TiffOptions();

    tiffOptions.setPixelFormat(ImagePixelFormat.Format8bppIndexed);
    /*
    ImagePixelFormat에는 다음 값이 포함되어 있습니다(문서에 명시된 대로):
        Format1bppIndexed - 1 비트당 픽셀, 인덱스됨.
        Format4bppIndexed - 4 비트당 픽셀, 인덱스됨.
        Format8bppIndexed - 8 비트당 픽셀, 인덱스됨.
        Format24bppRgb    - 24 비트당 픽셀, RGB.
        Format32bppArgb   - 32 비트당 픽셀, ARGB.
    */
    
    // 지정된 픽셀 형식으로 프레젠테이션을 TIFF로 저장합니다.
    presentation.save("Tiff-PixelFormat.tiff", SaveFormat.Tiff, tiffOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Tip" color="info" %}}
Aspose의 [FREE PowerPoint to Poster converter](https://products.aspose.app/slides/ko/conversion/convert-ppt-to-poster-online)를 확인해 보세요.
{{% /alert %}}

## **FAQ**

### 전체 PowerPoint 프레젠테이션이 아니라 개별 슬라이드만 TIFF로 변환할 수 있나요?

예. Aspose.Slides를 사용하면 PowerPoint 및 OpenDocument 프레젠테이션의 개별 슬라이드를 별도로 TIFF 이미지로 변환할 수 있습니다.

### 프레젠테이션을 TIFF로 변환할 때 슬라이드 수에 제한이 있나요?

아니요, Aspose.Slides는 슬라이드 수에 제한을 두지 않습니다. 원하는 크기의 프레젠테이션을 TIFF 형식으로 변환할 수 있습니다.

### 슬라이드를 TIFF로 변환할 때 PowerPoint 애니메이션 및 전환 효과가 유지되나요?

아니요, TIFF는 정적 이미지 형식이므로 애니메이션 및 전환 효과는 보존되지 않으며 슬라이드의 정적 스냅샷만 내보내집니다.