---
title: JavaScript로 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 35
url: /ko/nodejs-java/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- Node.js
- JavaScript
- Aspose.Slides
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드를 신속하게 복제하세요. 코드 예제를 따라하면 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

클로닝은 무언가를 정확히 복제하거나 동일한 사본을 만드는 과정입니다. Aspose.Slides for Node.js via Java를 사용하면 任意의 슬라이드를 복제하거나 복사한 다음 해당 복제된 슬라이드를 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있습니다. 슬라이드 클로닝 과정은 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 방법에는 여러 가지가 있습니다:

- 프레젠테이션 내에서 끝에 복제.
- 프레젠테이션 내 다른 위치에 복제.
- 다른 프레젠테이션의 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 다른 프레젠테이션의 특정 위치에 복제.

Aspose.Slides for Node.js via Java에서 ([Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 [Slide](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide) 객체 컬렉션) 은 위의 슬라이드 복제 유형을 수행하기 위해 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 및 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 제공합니다.

## **프레젠테이션 내에서 끝에 복제**
같은 프레젠테이션 파일에서 기존 슬라이드 끝에 복제된 슬라이드를 사용하려면 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 노출하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드를 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 같은 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **프레젠테이션 내 다른 위치에 복제**
같은 프레젠테이션 파일에서 다른 위치에 복제된 슬라이드를 사용하려면 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. **Slides**(https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 컬렉션을 참조하여 클래스를 인스턴스화합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 노출하는 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드와 새로운 위치 인덱스를 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 인덱스 1(두 번째 위치) 슬라이드를 인덱스 2(세 번째 위치) 로 복제했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 같은 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    var slds = pres.getSlides();
    // 같은 프레젠테이션의 지정된 인덱스로 원하는 슬라이드를 복제합니다
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **다른 프레젠테이션의 끝에 복제**
슬라이드를 한 프레젠테이션에서 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 삽입하려면:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 복제된 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 **Slides** 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection) 클래스를 인스턴스화합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 노출하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 첫 번째 인덱스 슬라이드를 대상 프레젠테이션 끝으로 복제했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 대상 PPTX(슬라이드를 복제할 위치)를 위한 Presentation 클래스를 인스턴스화합니다
    var destPres = new aspose.slides.Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        var slds = destPres.getSlides();
        slds.addClone(srcPres.getSlides().get_Item(0));
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **다른 프레젠테이션의 다른 위치에 복제**
슬라이드를 한 프레젠테이션에서 복제하여 다른 프레젠테이션 파일의 특정 위치에 삽입하려면:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 노출하는 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 인덱스 0 슬라이드를 대상 프레젠테이션의 인덱스 1(두 번째 위치) 로 복제했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 대상 PPTX(슬라이드를 복제할 위치)를 위한 Presentation 클래스를 인스턴스화합니다
    var destPres = new aspose.slides.Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        var slds = destPres.getSlides();
        slds.insertClone(1, srcPres.getSlides().get_Item(0));
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **다른 프레젠테이션의 특정 위치에 복제**
마스터 슬라이드가 포함된 슬라이드를 한 프레젠테이션에서 복제하여 다른 프레젠테이션에 사용하려면 먼저 원본 프레젠테이션의 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 마스터가 포함된 슬라이드를 복제합니다. [**addClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) 메서드는 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 복제하려면 아래 단계에 따라 진행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 슬라이드를 복제할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
1. 복제할 슬라이드와 해당 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Masters 컬렉션을 참조하여 [MasterSlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterSlideCollection) 클래스를 인스턴스화합니다.
1. [MasterSlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterSlideCollection) 객체가 노출하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 PPTX의 복제할 마스터를 매개변수로 전달합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 설정합니다.
1. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 노출하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 마스터 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 마스터가 포함된 슬라이드(인덱스 0)를 대상 프레젠테이션의 끝으로 복제했으며, 원본 슬라이드의 마스터를 사용했습니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 대상 프레젠테이션(슬라이드를 복제할 위치)을 위한 Presentation 클래스를 인스턴스화합니다
    var destPres = new aspose.slides.Presentation();
    try {
        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 마스터 슬라이드와 함께 인스턴스화합니다
        // 마스터 슬라이드
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        var masters = destPres.getMasters();
        var DestMaster = masters.addClone(SourceMaster);
        // 소스 프레젠테이션에서 원하는 슬라이드를 원하는 마스터와 함께 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        // 대상 프레젠테이션의 슬라이드 컬렉션
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **지정된 섹션의 끝에 복제**
같은 프레젠테이션 파일에서 다른 섹션에 복제된 슬라이드를 사용하려면 [**addClone**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) 메서드를 사용하십시오. Aspose.Slides for Node.js via Java를 사용하면 첫 번째 섹션에서 슬라이드를 복제한 다음 해당 복제된 슬라이드를 동일 프레젠테이션의 두 번째 섹션에 삽입할 수 있습니다.

다음 코드 조각은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여줍니다.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 대상 프레젠테이션을 디스크에 저장합니다
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **슬라이드 크기 일치 확인**

슬라이드를 다른 프레젠테이션으로 복제할 때 대상 프레젠테이션의 슬라이드 크기가 원본과 동일한지 확인하십시오. 슬라이드 크기가 다르면 Aspose.Slides는 복제된 도형의 크기를 자동으로 조정하지 않으며, 원래 좌표와 크기가 유지되어 내용이 잘못 정렬되거나 슬라이드 경계 밖으로 벗어날 수 있습니다.

마스터와 슬라이드를 복제하기 전에 대상 프레젠테이션의 슬라이드 크기를 원본과 일치하도록 설정할 수 있습니다:

```javascript
const sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), aspose.slides.SlideSizeScaleType.DoNotScale);
```

복제하기 전에 마스터와 슬라이드의 크기를 맞추십시오.

## **FAQ**

**스피커 노트와 검토자 댓글도 복제되나요?**

예. 노트 페이지와 검토 댓글이 복제에 포함됩니다. 필요하지 않다면 삽입 후 [remove them](/slides/ko/nodejs-java/presentation-notes/) 하세요.

**차트와 데이터 원본은 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE가 포함된 워크북)에 연결된 경우 해당 연결이 [OLE object](/slides/ko/nodejs-java/manage-ole/) 로 보존됩니다. 파일 간 이동 후 데이터 가용성을 확인하고 새로 고침 동작을 확인하십시오.

**복제 슬라이드의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제본을 삽입하고 원하는 [section](/slides/ko/nodejs-java/slide-section/)에 배치할 수 있습니다. 대상 섹션이 존재하지 않으면 먼저 섹션을 만든 후 슬라이드를 이동하십시오.