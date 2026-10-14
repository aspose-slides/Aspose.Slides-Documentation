---
title: Java에서 PowerPoint 슬라이드를 PNG로 변환
linktitle: PowerPoint를 PNG로
type: docs
weight: 30
url: /ko/java/convert-powerpoint-to-png/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 프레젠테이션을 고품질 PNG 이미지로 빠르게 변환하고, 정확하고 자동화된 결과를 보장합니다."
---
## **개요**

이 문서에서는 Aspose.Slides for Java를 사용하여 프레젠테이션 슬라이드를 PNG 이미지로 변환하는 방법을 설명합니다. PPT, PPTX 및 ODP와 같은 형식의 프레젠테이션을 로드하고, 각 슬라이드를 렌더링한 후 각각을 별도의 PNG 이미지로 저장할 수 있습니다.

아래 예제에서는 기본 배율로 렌더링, 배율 확대, 픽셀 단위로 출력 크기 지정, 그리고 그라디언트 렌더링 스타일 선택을 보여줍니다.

## **PowerPoint를 PNG로 변환**

프레젠테이션을 [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) 클래스 로드하고, 해당 프레젠테이션의 슬라이드에 [Presentation.getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) 컬렉션을 통해 접근합니다. 예제에서는 매 슬라이드를 매개변수 없이 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) 로 렌더링하여 썸네일을 생성합니다. 그런 다음 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-)에 [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/#Png) 을 사용하여 각 렌더링된 슬라이드를 PNG 이미지로 저장합니다.

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
매개변수가 없는 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage--) 오버로드는 배율 0.2로 렌더링합니다. 예를 들어, 720 × 540 포인트 크기의 슬라이드는 144 × 108 픽셀 썸네일을 생성합니다. 출력 크기를 제어하려면 아래에 표시된 대로 배율 인자 또는 명시적인 이미지 크기 오버로드를 사용하십시오.
{{% /alert %}}

## **사용자 지정 크기로 PowerPoint를 PNG로 변환**

렌더링된 크기를 제어하려면 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-float-float-) 에 가로 및 세로 배율을 전달합니다. 이 예제에서는 두 배율이 모두 2이므로 720 × 540 포인트 슬라이드가 1440 × 1080 픽셀 이미지로 생성됩니다. 동일한 배율을 사용하면 슬라이드의 종횡비가 유지됩니다. 각 이미지는 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 PNG 형식으로 저장됩니다.

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

## **픽셀 크기 지정으로 PowerPoint를 PNG로 변환**

출력 크기를 픽셀 단위로 지정하려면 배율 대신 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-java.awt.Dimension-) 에 크기를 전달합니다. 이 예제에서는 모든 슬라이드를 960 × 720 픽셀로 렌더링하고 결과를 [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) 로 저장합니다. 이미지가 늘어나지 않도록 슬라이드의 종횡비와 일치하는 크기를 선택하십시오.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Dimension imageSize = new Dimension(960, 720);

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

슬라이드에 그라디언트 채우기가 포함되어 있지만 내보낸 PNG의 전환이 PowerPoint에서 보는 것보다 더 밝거나 다르게 보이는 경우가 있습니다. 이때 [RenderingOptions](https://reference.aspose.com/slides/java/com.aspose.slides/renderingoptions/) 에서 상속받은 [SaveOptions.setGradientStyle](https://reference.aspose.com/slides/java/com.aspose.slides/saveoptions/#setGradientStyle-int-) 메서드를 사용하여 그라디언트 렌더링 방식을 선택할 수 있습니다.

[gradient-styles.pptx](gradient-styles.pptx) 파일을 다운로드하여 애플리케이션 작업 디렉터리에 배치합니다. 첫 번째 슬라이드에는 두 개의 선형 그라디언트가 있으며, 위쪽은 시안에서 오렌지로, 아래쪽은 파랑에서 노랑으로 전환됩니다. 각 그라디언트는 0%와 100%에 두 개의 정지점을 가집니다.

다음 예제는 이 프레젠테이션을 로드하고 [ISlide.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) 을 사용하여 두 모드 모두에서 동일한 첫 번째 슬라이드를 렌더링합니다.

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

아래 이미지들은 동일한 슬라이드의 출력 결과이며, 각 이미지에 두 개의 그라디언트가 모두 포함되어 있습니다:

| 기본 | PowerPointUI |
| --- | --- |
| ![기본 모드로 렌더링된 시안-오렌지 및 파랑-노랑 그라디언트](gradient-Default.png) | ![PowerPointUI로 렌더링된 동일한 그라디언트](gradient-PowerPointUI.png) |

이 예제에서 `Default`는 중간 색상이 더 밝게 나오고, `PowerPointUI`는 중간 색상이 더 어둡게 나옵니다. 차이는 그라디언트의 색상 및 정지점에 따라 달라집니다.

표준 Aspose.Slides 출력이 필요에 맞는 경우 `Default`를 선택하십시오. PowerPoint와 외관을 맞추는 것이 우선인 경우 `PowerPointUI`를 사용해 보세요. 두 출력 결과를 원하는 결과와 비교하십시오; 어느 모드도 보편적으로 더 우수하지는 않습니다.

## **FAQ**

**전체 슬라이드가 아니라 차트나 그림과 같은 특정 도형을 내보내려면 어떻게 해야 하나요?**  
Aspose.Slides는 [개별 도형에 대한 썸네일 생성](/slides/ko/java/create-shape-thumbnails/)을 지원하므로 도형을 PNG 이미지로 렌더링할 수 있습니다.

**서버에서 병렬 변환이 지원되나요?**  
예. 각 스레드 또는 프로세스마다 별도의 Presentation 인스턴스를 사용하십시오; [스레드 간에 단일 인스턴스를 공유하지 마세요](/slides/ko/java/multithreading/).

**PNG로 내보낼 때 평가 버전의 제한 사항은 무엇인가요?**  
평가 모드에서는 출력 이미지에 워터마크가 추가되고, 라이선스가 적용될 때까지 [기타 제한](/slides/ko/java/licensing/)이 적용됩니다.