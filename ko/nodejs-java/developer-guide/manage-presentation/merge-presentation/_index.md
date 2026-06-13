---
title: JavaScript에서 프레젠테이션을 효율적으로 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/nodejs-java/merge-presentation/
keywords:
- PowerPoint 병합
- 프레젠테이션 병합
- 슬라이드 병합
- PPT 병합
- PPTX 병합
- ODP 병합
- PowerPoint 결합
- 프레젠테이션 결합
- 슬라이드 결합
- PPT 결합
- PPTX 결합
- ODP 결합
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 JavaScript에서 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하여 작업 흐름을 간소화합니다."
---
## **개요**

Aspose.Slides는 한 프레젠테이션의 슬라이드를 복제하여 다른 프레젠테이션에 병합할 수 있게 해줍니다. 이 문서에서는 전체 프레젠테이션 또는 선택된 슬라이드를 병합하는 방법, 병합 중 슬라이드 마스터 또는 특정 레이아웃을 사용하는 방법, 서로 다른 슬라이드 크기의 프레젠테이션을 처리하는 방법, 병합된 슬라이드를 프레젠테이션 섹션에 추가하는 방법을 설명합니다. 또한 스피커 노트, 주석, 비밀번호로 보호된 원본 파일, 스레드 사용과 같은 병합된 콘텐츠와 관련된 실용적인 참고 사항도 다룹니다.

## **프레젠테이션 병합**

하나의 프레젠테이션을 다른 프레젠테이션에 병합하면, 실질적으로 슬라이드를 하나의 프레젠테이션으로 결합하여 하나의 파일을 얻는 것입니다.

{{% alert title="Info" color="info" %}}

대부분의 프레젠테이션 프로그램(PowerPoint 또는 OpenOffice)에는 사용자가 이러한 방식으로 프레젠테이션을 결합할 수 있는 기능이 없습니다.

[**Aspose.Slides for Node.js via Java**](https://products.aspose.com/slides/ko/nodejs-java/)는 다양한 방식으로 프레젠테이션을 병합할 수 있게 해줍니다. 모든 도형, 스타일, 텍스트, 서식, 주석, 애니메이션 등을 포함한 프레젠테이션을 품질이나 데이터 손실에 대한 걱정 없이 병합할 수 있습니다.

**See also**

[Clone Slides](https://docs.aspose.com/slides/ko/nodejs-java/clone-slides/).

{{% /alert %}}

### **병합할 수 있는 항목**

With Aspose.Slides, you can merge 

* 전체 프레젠테이션. 프레젠테이션의 모든 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 특정 슬라이드. 선택한 슬라이드가 하나의 프레젠테이션에 포함됩니다
* 동일한 형식(PPT에서 PPT, PPTX에서 PPTX 등)의 프레젠테이션과 서로 다른 형식(PPT에서 PPTX, PPTX에서 ODP 등)의 프레젠테이션을 서로 병합할 수 있습니다. 

### **병합 옵션**

다음과 같은 옵션을 적용하여 여부를 결정할 수 있습니다

* 출력 프레젠테이션의 각 슬라이드가 고유한 스타일을 유지하도록
* 출력 프레젠테이션의 모든 슬라이드에 특정 스타일을 적용하도록 

프레젠테이션을 병합하려면, Aspose.Slides는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 제공합니다 ( [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection) 클래스에 있습니다). `addClone` 메서드의 여러 구현이 있으며, 각각은 프레젠테이션 병합 프로세스 매개변수를 정의합니다. 모든 Presentation 객체에는 [Slides](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 컬렉션이 있으므로, 병합하려는 프레젠테이션에서 `addClone` 메서드를 호출할 수 있습니다.

`addClone` 메서드는 원본 슬라이드의 복제본인 `Slide` 객체를 반환합니다. 출력 프레젠테이션의 슬라이드는 원본 슬라이드의 복사본일 뿐입니다. 따라서 결과 슬라이드에(예: 스타일, 서식 옵션 또는 레이아웃 적용) 변경을 가해도 원본 프레젠테이션에 영향을 걱정할 필요가 없습니다.

## **프레젠테이션 병합** 

Aspose.Slides는 슬라이드가 레이아웃과 스타일을 유지하면서 슬라이드를 결합할 수 있는 [**AddClone(ISlide)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 제공합니다(기본 매개변수).

다음 JavaScript 코드는 프레젠테이션을 병합하는 방법을 보여줍니다:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **슬라이드 마스터와 함께 프레젠테이션 병합**

Aspose.Slides는 슬라이드 마스터 프레젠테이션 템플릿을 적용하면서 슬라이드를 결합할 수 있는 [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 메서드를 제공합니다. 이를 통해 필요할 경우 출력 프레젠테이션의 슬라이드 스타일을 변경할 수 있습니다.

다음 JavaScript 코드는 위에서 설명한 작업을 시연합니다:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Note" color="warning" %}} 

슬라이드 마스터의 슬라이드 레이아웃은 자동으로 결정됩니다. 적절한 레이아웃을 결정할 수 없을 경우, `addClone` 메서드의 `allowCloneMissingLayout` 부울 매개변수가 true로 설정되어 있으면 원본 슬라이드의 레이아웃이 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/PptxEditException)이 발생합니다.

{{% /alert %}}

출력 프레젠테이션의 슬라이드가 다른 슬라이드 레이아웃을 갖게 하려면 병합 시 [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-) 메서드를 대신 사용하십시오.

## **프레젠테이션에서 특정 슬라이드 병합**

여러 프레젠테이션에서 특정 슬라이드를 병합하면 맞춤형 슬라이드 덱을 만들 때 유용합니다. Aspose.Slides for Node.js via Java는 필요한 슬라이드만 선택하고 가져올 수 있게 합니다. API는 원본 슬라이드의 서식, 레이아웃 및 디자인을 유지합니다.

다음 JavaScript 코드는 새 프레젠테이션을 만들고, 두 다른 프레젠테이션에서 타이틀 슬라이드를 추가한 뒤 결과를 파일에 저장합니다:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **슬라이드 레이아웃과 함께 프레젠테이션 병합**

다음 JavaScript 코드는 프레젠테이션의 슬라이드를 결합하면서 원하는 슬라이드 레이아웃을 적용하여 하나의 출력 프레젠테이션을 만드는 방법을 보여줍니다:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

{{% alert title="Note" color="warning" %}} 

다른 슬라이드 크기를 가진 프레젠테이션은 병합할 수 없습니다. 

{{% /alert %}}

다른 슬라이드 크기를 가진 두 프레젠테이션을 병합하려면, 한 프레젠테이션의 크기를 다른 프레젠테이션에 맞게 조정해야 합니다. 

이 샘플 코드는 위에서 설명한 작업을 시연합니다:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **프레젠테이션 섹션에 슬라이드 병합**

다음 JavaScript 코드는 특정 슬라이드를 프레젠테이션 섹션에 병합하는 방법을 보여줍니다:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

슬라이드는 섹션의 끝에 추가됩니다.

## **FAQ**

**병합 중에 발표자 노트가 보존됩니까?**

예. 슬라이드를 복제할 때 Aspose.Slides는 노트, 서식 및 애니메이션을 포함한 모든 슬라이드 요소를 그대로 전달합니다.

**주석 및 해당 작성자가 전송됩니까?**

주석은 슬라이드 콘텐츠의 일부로 슬라이드와 함께 복사됩니다. 주석 작성자 라벨은 결과 프레젠테이션의 주석 객체로 보존됩니다.

**원본 프레젠테이션이 비밀번호로 보호된 경우 어떻게 해야 합니까?**

비밀번호로 [열어야 합니다](/slides/ko/nodejs-java/password-protected-presentation/) `LoadOptions.setPassword`(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/loadoptions/setpassword/)를 사용하여; 로드 후 해당 슬라이드를 안전하게 비보호 대상 파일(또는 보호된 파일에도)로 복제할 수 있습니다.

**병합 작업은 스레드 안전한가요?**

[Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/presentation/) 인스턴스를 [다중 스레드](/slides/ko/nodejs-java/multithreading/)에서 사용하지 마십시오. 권장 규칙은 "하나의 문서 — 하나의 스레드"이며, 서로 다른 파일은 별도 스레드에서 병렬 처리할 수 있습니다.

## **관련 항목**

Aspose는 [FREE Online Collage Maker](https://products.aspose.app/slides/ko/collage)를 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 생성하는 등 다양한 작업을 할 수 있습니다.

[Aspose FREE Online Merger](https://products.aspose.app/slides/ko/merger)를 확인하십시오. 동일한 형식(PPT에서 PPT, PPTX에서 PPTX 등) 또는 다른 형식(PPT에서 PPTX, PPTX에서 ODP 등)의 PowerPoint 프레젠테이션을 병합할 수 있습니다.

[![Aspose FREE Online Merger](slides-merger.png)](https://products.aspose.app/slides/ko/merger)