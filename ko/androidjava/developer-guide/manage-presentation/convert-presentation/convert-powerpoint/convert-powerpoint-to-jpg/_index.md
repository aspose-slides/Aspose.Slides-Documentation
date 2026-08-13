---
title: Android에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/androidjava/convert-powerpoint-to-jpg/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 JPG로
- 프레젠테이션을 JPG로
- 슬라이드를 JPG로
- PPT를 JPG로
- PPTX를 JPG로
- PowerPoint를 JPG로 저장
- 프레젠테이션을 JPG로 저장
- 슬라이드를 JPG로 저장
- PPT를 JPG로 저장
- PPTX를 JPG로 저장
- PPT를 JPG로 내보내기
- PPTX를 JPG로 내보내기
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 Java에서 PowerPoint(PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 빠르고 안정적인 코드 예제로 변환합니다."
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화 및 웹사이트나 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides for Android via Java를 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드에서는 다양한 변환 방법을 설명합니다.

이러한 기능을 통해 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 쉽게 만들 수 있습니다. 프레젠테이션 슬라이드를 복제로부터 보호하거나 읽기 전용 모드에서 프레젠테이션을 시연하려는 경우에 유용할 수 있습니다. Aspose.Slides는 전체 프레젠테이션 또는 특정 슬라이드를 이미지 형식으로 변환할 수 있도록 지원합니다.

## **프레젠테이션 슬라이드를 JPG 이미지로 변환**

PPT, PPTX 또는 ODP 파일을 JPG로 변환하는 단계:

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/) 클래스를 인스턴스화합니다.
1. [Presentation.getSlides()](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/presentation/#getSlides--) 메서드가 반환하는 컬렉션에서 [ISlide](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/) 유형의 슬라이드 객체를 가져옵니다.
1. [ISlide.getImage(float, float)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getImage-float-float-) 메서드를 사용하여 슬라이드의 이미지를 생성합니다.
1. 이미지 객체에 대해 [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 메서드를 호출합니다. 출력 파일 이름과 이미지 형식을 인수로 전달합니다.

{{% alert color="info" %}} 

**Note:** PPT, PPTX 또는 ODP를 JPG로 변환하는 방식은 Aspose.Slides Android via Java API에서 다른 형식으로 변환하는 방식과 다릅니다. 다른 형식의 경우 일반적으로 [IPresentation.save(String, SaveFormat, ISaveOptions)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ipresentation/#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드를 사용합니다. 그러나 JPG 변환의 경우 [IImage.save(string, ImageFormat)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 메서드를 사용해야 합니다.

{{% /alert %}} 

```java
import com.aspose.slides.*;

int scaleX = 1;
int scaleY = scaleX;

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 지정된 배율로 슬라이드 이미지를 생성합니다.
        IImage slideImage = slide.getImage(scaleX, scaleY);

        try {
            // 이미지를 JPEG 형식으로 디스크에 저장합니다.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **맞춤형 크기로 슬라이드를 JPG로 변환**

결과 JPG 이미지의 크기를 변경하려면 [ISlide.getImage(Size)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 메서드에 크기를 전달하여 이미지 크기를 설정할 수 있습니다. 이를 통해 특정 너비와 높이 값을 가진 이미지를 생성할 수 있어 출력이 해상도 및 종횡비 요구 사항을 충족하도록 보장합니다. 이러한 유연성은 웹 애플리케이션, 보고서 또는 문서용 이미지를 생성할 때 특히 유용하며, 정확한 이미지 크기가 필요합니다.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Size imageSize = new Size(1200, 800);

Presentation presentation = new Presentation("PowerPoint_Presentation.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        // 지정된 크기로 슬라이드 이미지를 생성합니다.
        IImage slideImage = slide.getImage(imageSize);

        try {
            // 이미지를 JPEG 형식으로 디스크에 저장합니다.
            String fileName = String.format("Slide_%d.jpg", slide.getSlideNumber());
            slideImage.save(fileName, ImageFormat.Jpeg);
        } finally {
            slideImage.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **이미지로 슬라이드 저장 시 주석 렌더링**

Aspose.Slides for Android via Java는 프레젠테이션 슬라이드를 JPG 이미지로 변환할 때 주석을 렌더링할 수 있는 기능을 제공합니다. 이 기능은 PowerPoint 프레젠테이션에 협업자가 추가한 주석, 피드백 또는 토론을 보존하는 데 특히 유용합니다. 이 옵션을 활성화하면 생성된 이미지에 주석이 표시되어 원본 프레젠테이션 파일을 열지 않고도 피드백을 검토하고 공유하기 쉬워집니다.

예를 들어, 주석이 포함된 슬라이드를 가진 프레젠테이션 파일 "sample.pptx"가 있다고 가정해 보겠습니다:

![주석이 있는 슬라이드](slide_with_comments.png)

다음 Java 코드는 슬라이드를 주석을 유지한 채 JPG 이미지로 변환합니다:

```java
import com.aspose.slides.*;
import java.awt.Color;

int scaleX = 2;
int scaleY = scaleX;

Presentation presentation = new Presentation("sample.pptx");
try {
    NotesCommentsLayoutingOptions commentsOptions = new NotesCommentsLayoutingOptions();
    commentsOptions.setCommentsPosition(CommentsPositions.Right);
    commentsOptions.setCommentsAreaWidth(200);
    commentsOptions.setCommentsAreaColor(new Color(255, 140, 0));

    IRenderingOptions options = new RenderingOptions();
    options.setSlidesLayoutOptions(commentsOptions);

    // 첫 번째 슬라이드를 이미지로 변환합니다.
    IImage slideImage = presentation.getSlides().get_Item(0).getImage(options, scaleX, scaleY);
    try {
        slideImage.save("Slide_1.jpg", ImageFormat.Jpeg);
    } finally {
        slideImage.dispose();
    }
} finally {
    presentation.dispose();
}
```

결과:

![주석이 포함된 JPG 이미지](image_with_comments.png)

## **관련 항목**

PPT, PPTX 또는 ODP를 이미지로 변환하는 다른 옵션을 확인하십시오, 예:

- [PowerPoint를 GIF로 변환](/slides/ko/androidjava/convert-powerpoint-to-animated-gif/)
- [PowerPoint를 PNG로 변환](/slides/ko/androidjava/convert-powerpoint-to-png/)
- [PowerPoint를 TIFF로 변환](/slides/ko/androidjava/convert-powerpoint-to-tiff/)
- [PowerPoint를 SVG로 변환](/slides/ko/androidjava/render-a-slide-as-an-svg-image/)

{{% alert color="info" %}} 

Aspose.Slides가 PowerPoint 프레젠테이션을 JPG 이미지로 변환하는 방식을 확인하려면, 다음 무료 온라인 변환기를 사용해 보세요: PowerPoint [PPTX to JPG](https://products.aspose.app/slides/ko/conversion/pptx-to-jpg) 및 [PPT to JPG](https://products.aspose.app/slides/ko/conversion/ppt-to-jpg). 

{{% /alert %}} 

![무료 온라인 PPTX to JPG 변환기](ppt-to-jpg.png)

{{% alert title="Tip" color="info" %}}

Aspose는 [FREE Collage web app](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 

이 문서에 설명된 동일한 원칙을 사용하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 확인하십시오: [image to JPG](https://products.aspose.com/slides/ko/java/conversion/image-to-jpg/); [JPG to image](https://products.aspose.com/slides/ko/java/conversion/jpg-to-image/); [JPG to PNG](https://products.aspose.com/slides/ko/java/conversion/jpg-to-png/), [PNG to JPG](https://products.aspose.com/slides/ko/java/conversion/png-to-jpg/); [PNG to SVG](https://products.aspose.com/slides/ko/java/conversion/png-to-svg/), [SVG to PNG](https://products.aspose.com/slides/ko/java/conversion/svg-to-png/).

{{% /alert %}}

## **FAQ**

### 이 방법이 배치 변환을 지원합니까?

예, Aspose.Slides를 사용하면 여러 슬라이드를 한 번에 JPG로 배치 변환할 수 있습니다.

### 변환이 SmartArt, 차트 및 기타 복잡한 개체를 지원합니까?

예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 다만 사용자 정의 폰트나 누락된 폰트를 사용할 경우 PowerPoint와 비교했을 때 렌더링 정확도가 약간 달라질 수 있습니다.

### 처리할 수 있는 슬라이드 수에 제한이 있습니까?

Aspose.Slides 자체는 처리할 수 있는 슬라이드 수에 엄격한 제한을 두지 않습니다. 그러나 대용량 프레젠테이션이나 고해상도 이미지를 다룰 경우 메모리 부족 오류가 발생할 수 있습니다.