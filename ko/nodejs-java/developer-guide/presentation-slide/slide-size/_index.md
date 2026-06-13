---
title: JavaScript에서 프레젠테이션 슬라이드 크기 변경
linktitle: 슬라이드 크기
type: docs
weight: 70
url: /ko/nodejs-java/slide-size/
keywords:
- 슬라이드 크기
- 종횡비
- 표준
- 와이드스크린
- 4:3
- 16:9
- 슬라이드 크기 설정
- 슬라이드 크기 변경
- 맞춤 슬라이드 크기
- 특수 슬라이드 크기
- 고유 슬라이드 크기
- 전체 크기 슬라이드
- 스크린 유형
- 크기 조정 안 함
- 맞춤 보장
- 최대화
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
descriptions: "Node.js와 Aspose.Slides를 사용하여 PPT, PPTX 및 ODP 파일의 슬라이드를 빠르게 크기 조정하는 방법을 배우고, 품질 손실 없이 모든 화면에 맞게 프레젠테이션을 최적화하세요."
---
## **Introduction**

Aspose.Slides는 프레젠테이션의 슬라이드 크기와 종횡비를 조정하기 위한 포괄적인 도구를 제공하며, 이는 인쇄 및 화면 표시 모두에 중요합니다.

Popular Slide Sizes and Ratios:

- **Standard (4:3 Aspect Ratio)**: 오래된 화면 및 장치에 적합합니다.
- **Widescreen (16:9 Aspect Ratio)**: 최신 프로젝터와 디스플레이에 권장됩니다.

프레젠테이션 전체에 일관성을 유지하려면 모든 슬라이드에 동일한 슬라이드 크기와 종횡비가 적용됩니다. 최상의 결과를 얻으려면 프레젠테이션을 만들기 시작할 때 슬라이드 크기를 설정하여 이후 발생할 수 있는 문제를 방지하십시오.

{{% alert color="primary" %}} 
기본적으로 Aspose.Slides로 만든 프레젠테이션은 표준 4:3 종횡비를 사용합니다.
{{% /alert %}}

## **Changing the Slide Size in Presentations**

 This sample code shows you how to change the slide size in a presentation in JavaScript using Aspose.Slides:

```javascript
var pres = new aspose.slides.Presentation("pres-4x3-aspect-ratio.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.OnScreen16x9, aspose.slides.SlideSizeScaleType.DoNotScale);
    pres.save("pres-4x3-aspect-ratio.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Specifying Custom Slide Sizes in Presentations**

If you find the common slide sizes (4:3 and 16:9) unsuitable for your work, you may decide to use a specific or unique slide size. For example, if you plan to print full-size slides from your presentation on a custom page layout or if you intend to display your presentation on certain screen types, you are likely to benefit from using a custom size setting for your presentation. 

This sample code shows you how to use Aspose.Slides for Node.js via Java to specify a custom slide size for a presentation in JavaScript:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(780, 540, aspose.slides.SlideSizeScaleType.DoNotScale);// A4 용지 크기
    pres.save("pres-a4-slide-size.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Dealing With Issues When Changing the Size of Slides in Presentations**

After you change the slide size for a presentation, the slides’ contents (images or objects, for example) may become distorted. By default, the objects get automatically resized to fit the new slide size. However, when changing a presentation's slide size, you can specify a setting that determines how Aspose.Slides deals with the contents on the slides.

Depending on what you intend to do or achieve, you can use any of these settings:

- `DoNotScale`

  If you do NOT want the objects on the slides to be resized, use this setting.

- `EnsureFit`

  If you want to scale to a smaller slide size and you need Aspose.Slides to scale down the slides’ objects to ensure they all fit on slides (this way, you avoid losing content), use this setting. 

- `Maximize`

  If you want to scale to a larger slide size and you need Aspose.Slides to enlarge the slides’ objects to make them proportional to the new slide size, use this setting. 

This sample code shows you how to use the `Maximize` setting when changing the size of a presentation’s slide:

```javascript
var pres = new aspose.slides.Presentation("pres.pptx");
try {
    pres.getSlideSize().setSize(aspose.slides.SlideSizeType.Ledger, aspose.slides.SlideSizeScaleType.Maximize);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Can I set a custom slide size using units other than inches (for example, points or millimeters)?**

Yes. Aspose.Slides uses points internally, where 1 point equals 1/72 of an inch. You can convert any unit (such as millimeters or centimeters) to points and use the converted values to define slide width and height.

**Will a very large custom slide size affect performance and memory usage during rendering?**

Yes. Larger slide dimensions (in points) combined with higher rendering scale lead to increased memory consumption and longer processing times. Aim for a practical slide size and adjust rendering scale only as needed to achieve the desired output quality.

**Can I define one non-standard slide size and then merge slides from presentations that have different sizes?**

You can’t [merge presentations](/slides/ko/nodejs-java/merge-presentation/) while they have different slide sizes — first, resize one presentation to match the other. When changing the slide size, you can choose how existing content is handled via the [SlideSizeScaleType](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slidesizescaletype/) option. After aligning sizes, you can merge slides while preserving formatting.

**Can I generate thumbnails for individual shapes or specific regions of a slide, and will they respect the new slide size?**

Yes. Aspose.Slides can render thumbnails for [entire slides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/slide/#getImage) as well as for [selected shapes](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/shape/#getImage). The resulting images reflect the current slide size and aspect ratio, ensuring consistent framing and geometry.