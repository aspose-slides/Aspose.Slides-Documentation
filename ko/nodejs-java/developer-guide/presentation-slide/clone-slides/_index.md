---
title: JavaScript에서 프레젠테이션 슬라이드 복제
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
description: "Aspose.Slides for Node.js를 사용하여 PowerPoint 슬라이드를 빠르게 복제하십시오. 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수작업을 없앨 수 있습니다."
---
## **소개**

클로닝은 무언가를 정확히 복제하거나 복사하는 과정이다. Aspose.Slides for Node.js via Java는 또한 모든 슬라이드의 복사 또는 클론을 만들고 해당 복제된 슬라이드를 현재 또는 다른 열린 프레젠테이션에 삽입하는 것을 가능하게 한다. 슬라이드 클론을 만들면 원본 슬라이드를 변경하지 않고 개발자가 새 슬라이드를 수정할 수 있다. 슬라이드를 복제하는 방법에는 여러 가지가 있다.

- 프레젠테이션 내 끝에 복제하기.
- 프레젠테이션 내 다른 위치에 복제하기.
- 다른 프레젠테이션의 끝에 복제하기.
- 다른 프레젠테이션의 다른 위치에 복제하기.
- 다른 프레젠테이션의 특정 위치에 복제하기.

Aspose.Slides for Node.js via Java에서는 ( [슬라이드](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Slide) 객체의 컬렉션) 을 제공하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 위의 슬라이드 복제 유형을 수행하기 위해 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 및 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 제공한다.

## **프레젠테이션 내 끝에 복제하기**
같은 프레젠테이션 파일 내 기존 슬라이드 끝에 슬라이드를 복제하여 사용하려면 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 사용한다.

1. [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
2. [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화한다.
3. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드를 매개변수로 전달한다.
4. 수정된 프레젠테이션 파일을 저장한다.

아래 예에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제하였다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 같은 프레젠테이션 내 슬라이드 컬렉션의 끝에 원하는 슬라이드를 복제합니다
    var slds = pres.getSlides();
    slds.addClone(pres.getSlides().get_Item(0));
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **프레젠테이션 내 다른 위치에 복제하기**
같은 프레젠테이션 파일 내 다른 위치에 슬라이드를 복제하여 사용하려면 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 사용한다.

1. [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
2. [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화한다.
3. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드와 새로운 위치의 인덱스를 매개변수로 전달한다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장한다.

아래 예에서는 프레젠테이션의 첫 번째 슬라이드(인덱스 0, 위치 1)를 인덱스 1(위치 2)으로 복제하였다.

```javascript
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
var pres = new aspose.slides.Presentation("CloneWithInSamePresentation.pptx");
try {
    // 같은 프레젠테이션 내 슬라이드 컬렉션의 끝에 원하는 슬라이드를 복제합니다
    var slds = pres.getSlides();
    // 같은 프레젠테이션 내 지정된 인덱스로 원하는 슬라이드를 복제합니다
    slds.insertClone(2, pres.getSlides().get_Item(1));
    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **다른 프레젠테이션의 끝에 복제하기**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 삽입하려면 다음 절차를 따른다.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
2. 슬라이드가 추가될 대상 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
3. 대상 프레젠테이션의 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection) 클래스를 인스턴스화한다.
4. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 매개변수로 전달한다.
5. 수정된 대상 프레젠테이션 파일을 저장한다.

아래 예에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션의 끝으로 복제하였다.

```javascript
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드가 복제될 대상 PPTX용 Presentation 클래스를 인스턴스화합니다
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

## **다른 프레젠테이션의 다른 위치에 복제하기**
한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 삽입하려면 다음 절차를 따른다.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
2. 슬라이드가 추가될 대상 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
3. 대상 프레젠테이션의 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화한다.
4. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#insertClone-int-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 매개변수로 전달한다.
5. 수정된 대상 프레젠테이션 파일을 저장한다.

아래 예에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제하였다.

```javascript
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드가 복제될 대상 PPTX용 Presentation 클래스를 인스턴스화합니다
    var destPres = new aspose.slides.Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        var slds = destPres.getSlides();
        slds.insertClone(2, srcPres.getSlides().get_Item(0));
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **다른 프레젠테이션의 특정 위치에 마스터 슬라이드와 함께 복제하기**
마스터 슬라이드가 포함된 슬라이드를 복제하려면 먼저 원본 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제한 뒤 해당 마스터 슬라이드를 사용하여 슬라이드를 복제해야 한다. `addClone(ISlide, IMasterSlide, boolean)` 메서드는 대상 프레젠테이션의 마스터 슬라이드를 기대한다. 마스터와 함께 슬라이드를 복제하려면 아래 단계에 따르라.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
2. 슬라이드가 복제되어 추가될 대상 프레젠테이션을 포함하는 [프레젠테이션](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 클래스의 인스턴스를 만든다.
3. 복제할 슬라이드와 해당 마스터 슬라이드에 접근한다.
4. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 Masters 컬렉션을 참조하여 [MasterSlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterSlideCollection) 클래스를 인스턴스화한다.
5. [MasterSlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/MasterSlideCollection) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 PPTX의 복제할 마스터를 매개변수로 전달한다.
6. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 클래스를 설정한다.
7. [SlideCollection](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 마스터 슬라이드를 매개변수로 전달한다.
8. 수정된 대상 프레젠테이션 파일을 저장한다.

아래 예에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 마스터가 포함된 슬라이드를 대상 프레젠테이션의 끝으로 복제하였다(원본 슬라이드의 마스터 사용).

```javascript
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
var srcPres = new aspose.slides.Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 슬라이드가 복제될 대상 프레젠테이션용 Presentation 클래스를 인스턴스화합니다
    var destPres = new aspose.slides.Presentation();
    try {
        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide을
        // 마스터 슬라이드와 함께 인스턴스화합니다
        var SourceSlide = srcPres.getSlides().get_Item(0);
        var SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 원하는 마스터 슬라이드를 소스 프레젠테이션에서 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
        // 대상 프레젠테이션
        var masters = destPres.getMasters();
        var DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();
        // 원하는 마스터 슬라이드를 소스 프레젠테이션에서 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
        // 대상 프레젠테이션
        var iSlide = masters.addClone(SourceMaster);
        // 원하는 마스터와 함께 소스 프레젠테이션의 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        // 대상 프레젠테이션의 슬라이드 컬렉션
        var slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **지정된 섹션의 끝에 복제하기**
같은 프레젠테이션 파일 내 다른 섹션에 슬라이드를 복제하려면 [**addClone**](https://reference.aspose.com/slides/ko/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ISection-) 메서드를 사용한다. Aspose.Slides for Node.js via Java는 첫 번째 섹션에서 슬라이드를 복제한 뒤 동일한 프레젠테이션의 두 번째 섹션에 삽입할 수 있다.

다음 코드 조각은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여준다.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));
    var section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    // 대상 프레젠테이션을 디스크에 저장합니다
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **FAQ**

**슬라이드 노트와 검토자 댓글도 복제되나요?**

예. 노트 페이지와 검토 댓글이 복제본에 포함된다. 필요 없으면 삽입 후 [제거](/slides/ko/nodejs-java/presentation-notes/)한다.

**차트와 차트 데이터 원본은 어떻게 처리되나요?**

차트 객체, 형식 및 포함된 데이터가 복사된다. 차트가 외부 소스(예: OLE가 포함된 워크북)와 연결돼 있었다면 해당 연결이 [OLE 객체](/slides/ko/nodejs-java/manage-ole/)로 유지된다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인한다.

**복제된 슬라이드의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제본을 삽입하고 원하는 [섹션](/slides/ko/nodejs-java/slide-section/)에 배치할 수 있다. 대상 섹션이 존재하지 않으면 먼저 섹션을 만든 뒤 슬라이드를 이동한다.