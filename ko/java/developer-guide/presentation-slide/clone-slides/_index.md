---
title: Java에서 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 35
url: /ko/java/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- Java
- Aspose.Slides
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드를 빠르게 복제하십시오. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없애세요."
---
## **소개**

Cloning은 무언가를 정확히 복사하거나 복제하는 과정입니다. Aspose.Slides for Java는 또한任意의 슬라이드를 복사하거나 복제하여 현재 또는 다른 열린 프레젠테이션에 삽입할 수 있게 합니다. 슬라이드 복제 과정은 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 여러 방법이 있습니다:

- 프레젠테이션 내부에서 끝에 복제.
- 프레젠테이션 내부의 다른 위치에 복제.
- 다른 프레젠테이션의 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 다른 프레젠테이션의 특정 위치에 복제.

In Aspose.Slides for Java, (a collection of [ISlide](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlide) objects) exposed by the [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) object provides the [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) and [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) methods to perform the above types of slide cloning

## **프레젠테이션 끝에 슬라이드 복제**
슬라이드를 복제하고 동일한 프레젠테이션 파일 내 기존 슬라이드 끝에 사용하려면, 아래 단계에 따라 [addClone] 메서드를 사용하십시오:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. [ISlideCollection] 클래스를 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하여 인스턴스화합니다.
1. [ISlideCollection] 객체가 제공하는 [addClone] 메서드를 호출하고 복제할 슬라이드를 [addClone] 메서드의 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 위치–인덱스 0–에 있던 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 동일한 프레젠테이션 내 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **프레젠테이션 내부의 다른 위치에 슬라이드 복제**
슬라이드를 복제하고 동일한 프레젠테이션 파일 내 다른 위치에 사용하려면, [insertClone] 메서드를 사용합니다:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. 프레젠테이션 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 제공하는 [insertClone] 메서드를 호출하고 복제할 슬라이드와 새 위치의 인덱스를 [insertClone] 메서드의 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 인덱스 0(위치 1)에 있던 슬라이드를 인덱스 1(위치 2)으로 복제했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 동일한 프레젠테이션 내 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.getSlides();

    // 동일한 프레젠테이션 내 지정된 인덱스에 원하는 슬라이드를 복제합니다
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **다른 프레젠테이션 끝에 슬라이드 복제**
하나의 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용하려면:

1. 복제할 슬라이드가 포함된 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 복제된 슬라이드가 추가될 대상 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 제공하는 [addClone] 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 [addClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 첫 번째 인덱스에 있던 슬라이드를 대상 프레젠테이션 끝으로 복제했습니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드를 복제할 대상 PPTX용 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 복제하여 대상 프레젠테이션의 슬라이드 컬렉션 끝에 추가합니다
        ISlideCollection slds = destPres.getSlides();

        slds.addClone(srcPres.getSlides().get_Item(0));

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **다른 프레젠테이션의 다른 위치에 슬라이드 복제**
하나의 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 사용하려면:

1. 복제할 슬라이드가 포함된 원본 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 슬라이드가 추가될 대상 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 제공하는 [insertClone] 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 [insertClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 인덱스 0에 있던 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드를 복제할 대상 PPTX용 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 복제하여 대상 프레젠테이션의 슬라이드 컬렉션 끝에 추가합니다
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(2, srcPres.getSlides().get_Item(0));

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **다른 프레젠테이션의 특정 위치에 슬라이드 복제**
하나의 프레젠테이션에서 마스터 슬라이드가 포함된 슬라이드를 복제하여 다른 프레젠테이션에 사용하려면, 먼저 원본 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제해야 합니다. 그 후 해당 마스터 슬라이드를 사용해 마스터가 포함된 슬라이드를 복제합니다. [addClone(ISlide, IMasterSlide, boolean)] 메서드는 원본이 아닌 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 복제하려면 아래 단계에 따라 진행하십시오:

1. 복제할 슬라이드가 포함된 원본 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 슬라이드가 복제될 대상 프레젠테이션을 나타내는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 복제할 슬라이드와 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection] 클래스를 인스턴스화합니다.
1. [IMasterSlideCollection] 객체가 제공하는 [addClone] 메서드를 호출하고 복제할 원본 PPTX의 마스터를 [addClone] 메서드의 매개변수로 전달합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하도록 설정하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 제공하는 [addClone] 메서드를 호출하고 원본 프레젠테이션의 복제할 슬라이드와 마스터 슬라이드를 [addClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 인덱스 0에 있던 마스터가 포함된 슬라이드를 원본 슬라이드의 마스터를 사용하여 대상 프레젠테이션 끝으로 복제했습니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 대상 프레젠테이션을 위한 Presentation 클래스를 인스턴스화합니다 (슬라이드를 복제할 위치)
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를
        // 마스터 슬라이드와 함께
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 원하는 마스터 슬라이드를 소스 프레젠테이션에서
        // 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 원하는 마스터 슬라이드를 소스 프레젠테이션에서
        // 대상 프레젠테이션의 마스터 컬렉션으로 복제합니다
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 원하는 마스터와 함께 소스 프레젠테이션의 원하는 슬라이드를
        // 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, iSlide, true);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **지정된 섹션 끝에 슬라이드 복제**
슬라이드를 복제하고 동일한 프레젠테이션 파일 내 다른 섹션에 사용하려면, [ISlideCollection] 인터페이스가 제공하는 [addClone] 메서드를 사용합니다. Aspose.Slides for Java는 첫 번째 섹션에서 슬라이드를 복제하고 해당 복제된 슬라이드를 같은 프레젠테이션의 두 번째 섹션에 삽입할 수 있게 합니다.

다음 코드 스니펫은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여줍니다.

```java
IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);
    
	// 대상 프레젠테이션을 디스크에 저장합니다
    presentation.save(dataDir + "CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **FAQ**

**발표자 메모와 검토자 댓글도 복제되나요?**

네. 노트 페이지와 검토 댓글이 복제에 포함됩니다. 원하지 않을 경우 삽입 후 [remove them](/slides/ko/java/presentation-notes/) 링크를 통해 삭제하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)와 연결되어 있었다면 해당 연결이 [OLE object](/slides/ko/java/manage-ole/) 로 유지됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

**복제된 슬라이드의 삽입 위치와 섹션을 제어할 수 있나요?**

네. 복제본을 특정 슬라이드 인덱스에 삽입하고 원하는 [section](/slides/ko/java/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 생성한 뒤 슬라이드를 이동하십시오.