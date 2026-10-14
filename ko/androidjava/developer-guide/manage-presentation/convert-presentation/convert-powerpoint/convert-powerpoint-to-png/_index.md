---
title: Android에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/androidjava/convert-powerpoint-to-png/
keywords:
- PowerPoint 변환
- 프레젠테이션 변환
- 슬라이드 변환
- PPT 변환
- PPTX 변환
- PowerPoint를 PNG로
- 프레젠테이션을 PNG로
- 슬라이드를 PNG로
- PPT를 PNG로
- PPTX를 PNG로
- PPT를 PNG로 저장
- PPTX를 PNG로 저장
- PPT를 PNG로 내보내기
- PPTX를 PNG로 내보내기
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 Java와 함께 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서는 Aspose.Slides for Android를 Java와 함께 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX, ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 다음 별도의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 배율로 렌더링, 배율 확대, 픽셀 단위로 출력 크기 지정, 그리고 그라디언트 렌더링 스타일 선택을 시연합니다.

## **PowerPoint를 PNG로 변환**

프레젠테이션을 [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) 클래스로 로드하고, [Presentation.getSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getSlides--) 컬렉션을 통해 슬라이드에 접근합니다. 예제는 매 슬라이드를 매개변수 없이 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 로 렌더링하여 썸네일을 만들고, 그런 다음 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 에 [ImageFormat.Png](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imageformat/#Png) 을 사용해 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage();
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
매개변수가 없는 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage--) 오버로드는 배율 0.2로 렌더링합니다. 예를 들어 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래에 표시된 배율 인수 또는 명시적인 이미지 크기 오버로드를 사용하십시오.
{{% /alert %}}

## **PowerPoint를 PNG로 사용자 정의 차원으로 변환**

[ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-float-float-) 에 가로 및 세로 배율을 전달하여 렌더링 크기를 제어합니다. 이 예제에서는 두 배율이 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지가 됩니다. 동일한 배율은 슬라이드의 종횡비를 유지합니다. 각 이미지는 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 으로 PNG 형식으로 저장됩니다.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    float scaleX = 2f;
    float scaleY = scaleX;

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(scaleX, scaleY);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **PowerPoint를 PNG로 사용자 정의 크기로 변환**

픽셀 단위로 출력 크기를 지정하려면 배율 대신 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.android.Size-) 에 크기를 전달합니다. 이 예제는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 결과를 [IImage.save](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 저장합니다. 슬라이드의 종횡비와 일치하도록 크기를 선택하면 이미지가 늘어나는 것을 방지할 수 있습니다.
```java
import com.aspose.slides.*;
import com.aspose.slides.android.Size;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Size imageSize = new Size(960, 720);

    int slideCount = presentation.getSlides().size();
    for (int index = 0; index < slideCount; index++) {
        ISlide slide = presentation.getSlides().get_Item(index);
        IImage image = slide.getImage(imageSize);
        try {
            image.save("slide_" + index + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

## **그라디언트 렌더링 스타일 선택**

슬라이드에 그라디언트 채우기가 포함되어 있지만 내보낸 PNG에서 전환이 PowerPoint에서 보는 것보다 밝거나 다르게 보이는 경우가 있습니다. 이때 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/androidjava/com.aspose.slides/saveoptions/#setGradientStyle-int-) 메서드( [RenderingOptions](https://reference.aspose.com/slides/androidjava/com.aspose.slides/renderingoptions/) 에서 상속) 를 사용해 그라디언트 렌더링 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx) 를 다운로드하여 애플리케이션 작업 디렉터리에 배치하십시오. 첫 번째 슬라이드에는 두 개의 선형 그라디언트가 있습니다: 상단은 청록색에서 주황색으로, 하단은 파랑에서 노랑으로 전환됩니다. 각 그라디언트는 0 %와 100 %에 두 개의 정지점을 갖습니다.

다음 예제는 이 프레젠테이션을 로드하고 [ISlide.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 를 사용해 두 모드 모두에서 동일한 첫 번째 슬라이드를 렌더링합니다.
```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("gradient-styles.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    int[] gradientStyles = { GradientStyle.Default, GradientStyle.PowerPointUI };
    for (int style : gradientStyles) {
        RenderingOptions options = new RenderingOptions();
        options.setGradientStyle(style);

        String styleName = style == GradientStyle.Default ? "Default" : "PowerPointUI";
        IImage image = slide.getImage(options, 1f, 1f);
        try {
            image.save("gradient-" + styleName + ".png", ImageFormat.Png);
        } finally {
            image.dispose();
        }
    }
} finally {
    presentation.dispose();
}
```

아래 이미지는 같은 슬라이드에서 두 그라디언트를 각각 렌더링한 결과를 보여줍니다:

| Default | PowerPointUI |
| --- | --- |
| ![기본 스타일로 렌더링된 시안-오렌지 및 파랑-노랑 그라디언트](gradient-Default.png) | ![PowerPointUI로 렌더링된 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default` 는 중간 색상이 더 밝게 나오고, `PowerPointUI` 는 중간 색상이 더 어둡게 나옵니다. 차이는 그라디언트의 색상과 정지점에 따라 달라집니다.

표준 Aspose.Slides 출력이 필요에 맞다면 `Default` 를 선택하십시오. PowerPoint와 외观을 맞추는 것이 우선이라면 `PowerPointUI` 를 시도해 보세요. 두 출력 모두를 원하는 결과와 비교해 보시기 바랍니다; 어느 한쪽이 보편적으로 더 좋다고 말할 수 없습니다.

## **FAQ**

**특정 모양(예: 차트 또는 그림)을 전체 슬라이드가 아닌 별도로 내보내려면 어떻게 해야 하나요?**

Aspose.Slides는 [개별 모양에 대한 썸네일 생성](/slides/ko/androidjava/create-shape-thumbnails/) 을 지원하므로 모양을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환을 지원하나요?**

예. 각 스레드 또는 프로세스마다 별도의 프레젠테이션 인스턴스를 사용하십시오; [스레드 간에 단일 인스턴스를 공유하지 마십시오](/slides/ko/androidjava/multithreading/).

**PNG로 내보낼 때 평가 모드의 제한 사항은 무엇인가요?**

평가 모드에서는 출력 이미지에 워터마크가 추가되고 라이선스를 적용할 때까지 [다른 제한 사항](/slides/ko/androidjava/licensing/) 이 적용됩니다.