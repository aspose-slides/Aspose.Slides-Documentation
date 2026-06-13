---
title: JavaScript에서 PPT 및 PPTX를 JPG로 변환
linktitle: PowerPoint를 JPG로
type: docs
weight: 60
url: /ko/nodejs-java/convert-powerpoint-to-jpg/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js via Java를 사용하여 JavaScript에서 PowerPoint (PPT, PPTX) 슬라이드를 고품질 JPG 이미지로 변환하고 빠르고 신뢰할 수 있는 코드 예제를 제공합니다."
---
## **소개**

PowerPoint와 OpenDocument 프레젠테이션을 JPG 이미지로 변환하면 슬라이드 공유, 성능 최적화 및 웹사이트나 애플리케이션에 콘텐츠를 삽입하는 데 도움이 됩니다. Aspose.Slides를 사용하면 PPTX, PPT 및 ODP 파일을 고품질 JPEG 이미지로 변환할 수 있습니다. 이 가이드에서는 다양한 변환 방법을 설명합니다.

이 기능들을 활용하면 자체 프레젠테이션 뷰어를 구현하고 각 슬라이드에 대한 썸네일을 만들 수 있습니다. 프레젠테이션 슬라이드를 복사 방지하거나 읽기 전용 모드로 시연하려는 경우에 유용할 수 있습니다. Aspose.Slides는 전체 프레젠테이션이나 특정 슬라이드를 이미지 형식으로 변환할 수 있습니다.

## **PowerPoint PPT/PPTX를 JPG로 변환**
PPT/PPTX를 JPG로 변환하는 단계는 다음과 같습니다:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 타입의 인스턴스를 생성합니다.
2. [Presentation.getSlides()](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 컬렉션에서 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide) 타입의 슬라이드 객체를 가져옵니다.
3. 각 슬라이드의 썸네일을 만든 후 JPG로 변환합니다. [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide#getImage-float-float-) 메서드는 슬라이드의 썸네일을 가져오는 데 사용되며, 결과로 [Imagess](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Images) 객체를 반환합니다. [getImage](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide#getImage-aspose.slides.IRenderingOptions-float-float-) 메서드는 필요한 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide) 타입의 슬라이드에서 호출해야 하며, 생성된 썸네일의 스케일을 메서드에 전달합니다.
4. 슬라이드 썸네일을 얻은 후, 썸네일 객체에서 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/#save) 메서드를 호출합니다. 여기서 파일 이름과 이미지 형식을 전달합니다. 

{{% alert color="primary" %}}

**Note**: PPT/PPTX를 JPG로 변환하는 방식은 Aspose.Slides API에서 다른 형식으로 변환할 때와 다릅니다. 다른 형식의 경우 일반적으로 [**Presentation.Save(String fname, int format, ISaveOptions options)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#save-java.lang.String-int-aspose.slides.ISaveOptions-) 메서드를 사용하지만, 여기서는 [**IImage.save(String formatName, int imageFormat)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/iimage/#save) 메서드를 사용해야 합니다.

{{% /alert %}} 

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 전체 크기의 이미지를 생성합니다
        var slideImage = sld.getImage(1.0, 1.0);
        // JPEG 형식으로 디스크에 이미지를 저장합니다
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **맞춤형 크기로 PowerPoint PPT/PPTX를 JPG로 변환**
결과 썸네일 및 JPG 이미지의 크기를 변경하려면 *ScaleX*와 *ScaleY* 값을 [**Slide.getImage(float scaleX, float scaleY)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide#getImage-float-float-) 메서드에 전달하면 됩니다:

```javascript
var pres = new aspose.slides.Presentation("PowerPoint-Presentation.pptx");
try {
    // 차원 정의
    var desiredX = 1200;
    var desiredY = 800;
    // X와 Y의 스케일된 값 가져오기
    var ScaleX = 1.0 / pres.getSlideSize().getSize().getWidth() * desiredX;
    var ScaleY = 1.0 / pres.getSlideSize().getSize().getHeight() * desiredY;
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        // 전체 크기의 이미지를 생성합니다
        var slideImage = sld.getImage(ScaleX, ScaleY);
        // JPEG 형식으로 디스크에 이미지를 저장합니다
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.jpg", sld.getSlideNumber()), aspose.slides.ImageFormat.Jpeg);
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **프레젠테이션을 이미지로 저장할 때 주석 렌더링**
Aspose.Slides for Node.js via Java는 슬라이드를 이미지로 변환할 때 프레젠테이션 슬라이드의 주석을 렌더링할 수 있는 기능을 제공합니다. 다음 JavaScript 코드는 이 동작을 보여줍니다:

```javascript
var pres = new aspose.slides.Presentation("presentation.pptx");
try {
    var notesOptions = new aspose.slides.NotesCommentsLayoutingOptions();
    notesOptions.setNotesPosition(aspose.slides.NotesPositions.BottomTruncated);
    var opts = new aspose.slides.RenderingOptions();
    opts.setSlidesLayoutOptions(notesOptions);
    for (let i = 0; i < pres.getSlides().size(); i++) {
        let sld = pres.getSlides().get_Item(i);
        var slideImage = sld.getImage(opts, java.newInstanceSync("java.awt.Dimension", 740, 960));
        try {
            slideImage.save(java.callStaticMethodSync("java.lang.String", "format", "Slide_%d.png", sld.getSlideNumber()));
        } finally {
            if (slideImage != null) {
                slideImage.dispose();
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{% alert title="Tip" color="primary" %}}

Aspose는 [무료 Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [포토 그리드](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 

{{% /alert %}}

## **또한 보기**

PPT/PPTX를 이미지로 변환하는 다른 옵션을 확인하세요:

- [PPT/PPTX를 SVG로 변환](/slides/ko/nodejs-java/render-a-slide-as-an-svg-image/).

## **FAQ**

**이 방법이 배치 변환을 지원합니까?**

예, Aspose.Slides를 사용하면 여러 슬라이드를 한 번에 JPG로 배치 변환할 수 있습니다.

**변환이 SmartArt, 차트 및 기타 복잡한 개체를 지원합니까?**

예, Aspose.Slides는 SmartArt, 차트, 표, 도형 등 모든 콘텐츠를 렌더링합니다. 그러나 렌더링 정확도는 사용자 정의 글꼴이나 누락된 글꼴을 사용할 경우 PowerPoint와 약간 차이가 있을 수 있습니다.

**처리할 수 있는 슬라이드 수에 제한이 있나요?**

Aspose.Slides 자체에는 처리할 슬라이드 수에 대한 엄격한 제한이 없습니다. 하지만 대용량 프레젠테이션이나 고해상도 이미지를 다룰 경우 메모리 부족 오류가 발생할 수 있습니다.