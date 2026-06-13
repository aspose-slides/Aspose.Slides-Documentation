---
title: Java에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/java/convert-powerpoint-to-jpg/
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
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 Java에서 PowerPoint(PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 변환하고 빠르고 안정적인 코드 예제를 제공합니다."
---
## **소개**

PowerPoint 및 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화, 웹사이트 또는 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides를 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드는 변환을 위한 다양한 방법을 설명합니다.

이러한 기능을 통해 자체 프레젠테이션 뷰어를 구현하고 모든 슬라이드에 대한 썸네일을 만들기가 쉽습니다. 프레젠테이션 슬라이드를 복제로부터 보호하거나 읽기 전용 모드로 프레젠테이션을 시연하려는 경우에 유용할 수 있습니다. Aspose.Slides를 사용하면 전체 프레젠테이션이나 특정 슬라이드를 이미지 형식으로 변환할 수 있습니다.

## **PowerPoint PPT/PPTX를 JPG로 변환**

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 유형의 인스턴스를 생성합니다.  
2. [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide) 유형의 슬라이드 객체를 [Presentation.getSlides()](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 컬렉션에서 가져옵니다.  
3. 각 슬라이드의 썸네일을 만든 다음 JPG로 변환합니다. [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide#getImage-float-float-) 메서드는 슬라이드의 썸네일을 가져오는 데 사용되며, 결과로 [Images](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Images) 객체를 반환합니다. [getImage](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide#getImage-com.aspose.slides.IRenderingOptions-float-float-) 메서드는 필요한 [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide) 유형의 슬라이드에서 호출되어야 하며, 결과 썸네일의 스케일이 메서드에 전달됩니다.  
4. 슬라이드 썸네일을 얻은 후, 썸네일 객체에서 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 메서드를 호출합니다. 결과 파일 이름과 이미지 형식을 전달합니다.

{{% alert color="primary" %}}
**Note**: PPT/PPTX를 JPG로 변환하는 방식은 Aspose.Slides API에서 다른 유형으로 변환하는 방식과 다릅니다. 다른 유형의 경우 일반적으로 [**IPresentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IPresentation#save-java.lang.String-int-com.aspose.slides.ISaveOptions-) 메서드를 사용하지만, 여기서는 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IImage#save(String formatName, int imageFormat)) 메서드가 필요합니다.
{{% /alert %}}

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    for (ISlide sld : pres.getSlides()) {
        // 전체 배율 이미지 생성
        IImage slideImage = sld.getImage(1f, 1f);

        // 이미지를 JPEG 형식으로 디스크에 저장합니다
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **맞춤형 크기로 PowerPoint PPT/PPTX를 JPG로 변환**

결과 썸네일 및 JPG 이미지의 크기를 변경하려면, *ScaleX* 및 *ScaleY* 값을 [**ISlide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide#getImage-float-float-) 메서드에 전달하면 됩니다.

```java
Presentation pres = new Presentation("PowerPoint-Presentation.pptx");
try {
    // 차원 정의
    int desiredX = 1200;
    int desiredY = 800;
    // X와 Y의 스케일된 값 가져오기
    float ScaleX = (float) (1.0 / pres.getSlideSize().getSize().getWidth()) * desiredX;
    float ScaleY = (float) (1.0 / pres.getSlideSize().getSize().getHeight()) * desiredY;

    for (ISlide sld : pres.getSlides())
    {
        // 전체 배율 이미지 생성
        IImage slideImage = sld.getImage(ScaleX, ScaleY);

        // 이미지를 JPEG 형식으로 디스크에 저장합니다
        try {
              slideImage.save(String.format("Slide_%d.jpg", sld.getSlideNumber()), ImageFormat.Jpeg);
        } finally {
             if (slideImage != null) slideImage.dispose();
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **슬라이드를 이미지로 저장할 때 주석 렌더링**

Aspose.Slides for Java는 슬라이드를 이미지로 변환할 때 프레젠테이션 슬라이드의 주석을 렌더링할 수 있는 기능을 제공합니다. 이 Java 코드는 해당 작업을 보여줍니다:

```java
Presentation pres = new Presentation("presentation.pptx");
try {
    NotesCommentsLayoutingOptions notesOptions = new NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(NotesPositions.BottomTruncated);

    IRenderingOptions opts = new RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);

    for (ISlide sld : pres.getSlides()) {
        IImage slideImage = sld.getImage(opts, new Dimension(740, 960));
        try {
             slideImage.save(String.format("Slide_%d.png", sld.getSlideNumber()));
        } finally {
                     if (slideImage != null) slideImage.dispose();
                }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

{{% alert title="Tip" color="primary" %}}
Aspose는 [FREE Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다.  

이 문서에 설명된 동일한 원리를 사용하여 이미지를 한 형식에서 다른 형식으로 변환할 수 있습니다. 자세한 내용은 다음 페이지를 참조하십시오: [이미지를 JPG로 변환](https://products.aspose.com/slides/ko/java/conversion/image-to-jpg/); [JPG를 이미지로 변환](https://products.aspose.com/slides/ko/java/conversion/jpg-to-image/); [JPG를 PNG로 변환](https://products.aspose.com/slides/ko/java/conversion/jpg-to-png/), [PNG를 JPG로 변환](https://products.aspose.com/slides/ko/java/conversion/png-to-jpg/); [PNG를 SVG로 변환](https://products.aspose.com/slides/ko/java/conversion/png-to-svg/), [SVG를 PNG로 변환](https://products.aspose.com/slides/ko/java/conversion/svg-to-png/).
{{% /alert %}}

## **FAQ**

**이 방법이 일괄 변환을 지원합니까?**  
예, Aspose.Slides를 사용하면 여러 슬라이드를 한 번에 JPG로 일괄 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복잡한 객체를 지원합니까?**  
예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등을 포함한 모든 콘텐츠를 렌더링합니다. 다만, 사용자 정의 글꼴이나 누락된 글꼴을 사용할 경우 PowerPoint와 비교해 렌더링 정확도가 약간 달라질 수 있습니다.

**처리할 수 있는 슬라이드 수에 제한이 있습니까?**  
Aspose.Slides 자체는 처리할 수 있는 슬라이드 수에 엄격한 제한을 두지 않습니다. 그러나 대용량 프레젠테이션이나 고해상도 이미지를 다룰 때 메모리 부족 오류가 발생할 수 있습니다.

## **관련 항목**

다음과 같이 PPT/PPTX를 이미지로 변환하는 다른 옵션을 참고하십시오:

- [PPT/PPTX를 SVG로 변환](/slides/ko/java/render-a-slide-as-an-svg-image/)