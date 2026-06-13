---
title: Android에서 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 35
url: /ko/androidjava/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides for Android를 사용하여 PowerPoint 슬라이드를 복제합니다. 명확한 Java 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

복제는 무언가를 정확히 복사하거나 복제하는 과정입니다. Aspose.Slides for Android via Java를 사용하면 슬라이드 전체를 복사하거나 복제한 뒤 현재 프레젠테이션이나 다른 열린 프레젠테이션에 삽입할 수 있습니다. 슬라이드 복제 과정은 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 방법에는 여러 가지가 있습니다.

- 프레젠테이션 내에서 끝에 복제.
- 프레젠테이션 내에서 다른 위치에 복제.
- 다른 프레젠테이션의 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 다른 프레젠테이션의 특정 위치에 복제.

Aspose.Slides for Android via Java에서는 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 개체가 노출하는 (ISlide) 객체 컬렉션을 통해 위와 같은 슬라이드 복제 유형을 수행하는 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 및 [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 복제**
동일한 프레젠테이션 파일 내에서 기존 슬라이드 끝에 복제된 슬라이드를 사용하려면 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 개체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.  
1. [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드를 매개변수로 전달합니다.  
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **프레젠테이션 내 다른 위치에 슬라이드 복제**
동일한 프레젠테이션 파일 내에서 다른 위치에 복제된 슬라이드를 사용하려면 [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 사용합니다.

1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 개체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.  
1. [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 호출하고 복제할 슬라이드와 새 위치 인덱스를 매개변수로 전달합니다.  
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0, 실제 위치 1)에 있는 슬라이드를 인덱스 1(위치 2)으로 복제했습니다.

```java
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.getSlides();

    // 동일한 프레젠테이션의 지정된 인덱스로 원하는 슬라이드를 복제합니다
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **다른 프레젠테이션 끝에 슬라이드 복제**
한 프레젠테이션의 슬라이드를 다른 프레젠테이션 파일 끝에 복제하려면 다음과 같이 진행합니다.

1. 복제할 슬라이드가 포함된 원본 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 복제본을 추가할 대상 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 대상 프레젠테이션의 Presentation 개체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection) 클래스를 인스턴스화합니다.  
1. 대상 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 매개변수로 전달합니다.  
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션 끝으로 복제했습니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드가 복제될 대상 PPTX를 위해 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
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
한 프레젠테이션의 슬라이드를 다른 프레젠테이션 파일의 특정 위치에 복제하려면 다음과 같이 진행합니다.

1. 슬라이드를 복제할 원본 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드를 추가할 대상 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 대상 프레젠테이션의 Presentation 개체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.  
1. 대상 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치 인덱스를 매개변수로 전달합니다.  
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드가 복제될 대상 PPTX를 위해 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
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

## **다른 프레젠테이션의 지정된 섹션 끝에 슬라이드 복제**
마스터 슬라이드가 포함된 슬라이드를 한 프레젠테이션에서 다른 프레젠테이션으로 복제하려면 먼저 원본 프레젠테이션에서 대상 프레젠테이션으로 원하는 마스터 슬라이드를 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 슬라이드를 복제합니다. [addClone(ISlide,IMasterSlide,boolean)](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 메서드는 대상 프레젠테이션의 마스터 슬라이드를 요구합니다. 아래 단계에 따라 진행하십시오.

1. 슬라이드를 복제할 원본 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 슬라이드를 복제할 대상 [Presentation](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.  
1. 복제할 슬라이드와 해당 마스터 슬라이드에 접근합니다.  
1. 대상 프레젠테이션의 Presentation 개체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IMasterSlideCollection) 클래스를 인스턴스화합니다.  
1. [IMasterSlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/IMasterSlideCollection) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고 원본 PPTX에서 복제할 마스터를 매개변수로 전달합니다.  
1. 대상 프레젠테이션의 Presentation 개체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 클래스를 설정합니다.  
1. [ISlideCollection](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 복제된 마스터 슬라이드를 매개변수로 전달합니다.  
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 마스터가 포함된 슬라이드를 대상 프레젠테이션 끝에 복제했습니다(마스터는 원본 슬라이드에서 가져옴).

```java
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 슬라이드가 복제될 대상 프레젠테이션을 위해 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 인스턴스화하고
        // 마스터 슬라이드
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlide iSlide = masters.addClone(SourceMaster);

        // 소스 프레젠테이션의 원하는 슬라이드를 원하는 마스터와 함께 대상 프레젠테이션 슬라이드 컬렉션 끝에 복제합니다
        // 대상 프레젠테이션의 슬라이드 컬렉션
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
동일한 프레젠테이션 파일 내에서 다른 섹션에 복제된 슬라이드를 사용하려면 [**addClone**](https://reference.aspose.com/slides/ko/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 메서드를 사용합니다. Aspose.Slides for Android via Java를 사용하면 첫 번째 섹션에서 슬라이드를 복제한 뒤 같은 프레젠테이션의 두 번째 섹션에 삽입할 수 있습니다.

다음 코드 조각은 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여 줍니다.

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

**강연자 메모와 검토자 코멘트도 복제되나요?**

네. 메모 페이지와 검토 코멘트가 복제에 포함됩니다. 삽입 후 필요 없으면 [/slides/ko/androidjava/presentation-notes/](/slides/ko/androidjava/presentation-notes/)에서 제거하십시오.

**차트와 데이터 원본은 어떻게 처리되나요?**

차트 개체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)에 연결되어 있으면 해당 연결이 [OLE 객체](/slides/ko/androidjava/manage-ole/)로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

**복제 위치와 섹션을 제어할 수 있나요?**

네. 특정 슬라이드 인덱스에 복제를 삽입하고 원하는 [섹션](/slides/ko/androidjava/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 생성한 뒤 슬라이드를 이동하십시오.