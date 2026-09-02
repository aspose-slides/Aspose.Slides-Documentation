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
description: "Aspose.Slides for Java를 사용하여 PowerPoint 슬라이드를 빠르게 복제합니다. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

클로닝은 어떤 대상을 정확히 복제하거나 복사하는 과정입니다. Aspose.Slides for Java를 사용하면任의 슬라이드를 복사하거나 클론한 뒤 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있습니다. 슬라이드 클론을 만들면 원본 슬라이드를 변경하지 않고 개발자가 수정할 수 있는 새 슬라이드가 생성됩니다. 슬라이드를 클론하는 방법에는 여러 가지가 있습니다:

- 프레젠테이션 내부에서 마지막에 클론하기.
- 프레젠테이션 내부의 다른 위치에 클론하기.
- 다른 프레젠테이션의 마지막에 클론하기.
- 다른 프레젠테이션의 다른 위치에 클론하기.
- 마스터 슬라이드와 함께 다른 프레젠테이션에 클론하기.

Aspose.Slides for Java에서는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 (ISlide 객체 컬렉션) [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 에서 위와 같은 슬라이드 클론을 수행하기 위해 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 및 [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 클론하기**
같은 프레젠테이션 파일 내에서 기존 슬라이드 끝에 슬라이드를 클론하려면 아래 단계에 따라 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.
3. [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고 클론할 슬라이드를 매개변수로 전달합니다.
4. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 클론했습니다.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx");
try {
    // 원하는 슬라이드를 동일한 프레젠테이션의 슬라이드 컬렉션 끝으로 복제합니다
    ISlideCollection slds = pres.getSlides();

    slds.addClone(pres.getSlides().get_Item(0));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **프레젠테이션 내 다른 위치에 슬라이드 클론하기**
같은 프레젠테이션 파일 내에서 다른 위치에 슬라이드를 클론하려면 [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 사용하십시오:

1. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 클래스의 인스턴스를 생성합니다.
2. [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
3. [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 호출하고, 클론할 슬라이드와 새로운 위치의 인덱스를 매개변수로 전달합니다.
4. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 인덱스 1(위치 2)에 있는 슬라이드를 인덱스 2(위치 3)로 클론했습니다.

```java
import com.aspose.slides.*;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
Presentation pres = new Presentation("CloneWithInSamePresentation.pptx");
try {
    // 프레젠테이션의 슬라이드 컬렉션을 가져옵니다
    ISlideCollection slds = pres.getSlides();

    // 원하는 슬라이드를 동일한 프레젠테이션의 지정된 인덱스로 복제합니다
    slds.insertClone(2, pres.getSlides().get_Item(1));

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **다른 프레젠테이션 끝에 슬라이드 클론하기**
한 프레젠테이션에서 슬라이드를 복제해 다른 프레젠테이션 파일의 기존 슬라이드 끝에 삽입하려면 다음을 수행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
2. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
3. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection) 클래스를 인스턴스화합니다.
4. [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션 끝으로 클론했습니다.

```java
import com.aspose.slides.*;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드를 복제할 대상 PPTX용 Presentation 클래스를 인스턴스화합니다 (복제될 슬라이드가 있는 위치)
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 복제하여 대상 프레젠테이션 슬라이드 컬렉션의 끝에 추가합니다
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

## **다른 프레젠테이션의 특정 위치에 슬라이드 클론하기**
한 프레젠테이션에서 슬라이드를 복제해 다른 프레젠테이션 파일의 특정 위치에 삽입하려면 다음을 수행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
2. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
3. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 클래스를 인스턴스화합니다.
4. [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [insertClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#insertClone-int-com.aspose.slides.ISlide-) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드와 원하는 위치 인덱스를 매개변수로 전달합니다.
5. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 클론했습니다.

```java
import com.aspose.slides.*;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx");
try {
    // 슬라이드가 복제될 대상 PPTX용 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션에서 원하는 슬라이드를 복제하여 대상 프레젠테이션의 지정된 인덱스에 삽입합니다
        ISlideCollection slds = destPres.getSlides();

        slds.insertClone(1, srcPres.getSlides().get_Item(0));

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("Aspose2_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **마스터 슬라이드와 함께 다른 프레젠테이션에 슬라이드 클론하기**
한 프레젠테이션에서 마스터 슬라이드와 함께 슬라이드를 복제해 다른 프레젠테이션에 사용하려면 먼저 원하는 마스터 슬라이드를 원본 프레젠테이션에서 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 그 마스터 슬라이드를 사용해 슬라이드를 복제합니다. [addClone(ISlide, IMasterSlide, boolean)](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) 메서드는 원본이 아닌 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 클론하려면 아래 단계에 따라 진행하십시오:

1. 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
2. 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 인스턴스를 생성합니다.
3. 클론할 슬라이드와 해당 마스터 슬라이드에 접근합니다.
4. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IMasterSlideCollection) 클래스를 인스턴스화합니다.
5. [IMasterSlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/IMasterSlideCollection) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고, 원본 PPTX에서 복제할 마스터를 매개변수로 전달합니다.
6. 대상 프레젠테이션의 [Presentation](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 클래스를 설정합니다.
7. [ISlideCollection](https://reference.aspose.com/slides/ko/java/com.aspose.slides/Presentation#getSlides--) 객체가 제공하는 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드와 마스터 슬라이드를 매개변수로 전달합니다.
8. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드와 마스터를 대상 프레젠테이션 끝에 복제했습니다.

```java
import com.aspose.slides.*;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx");
try {
    // 슬라이드가 복제될 대상 프레젠테이션용 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation();
    try {
        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide을 인스턴스화하고
        // 마스터 슬라이드
        ISlide SourceSlide = srcPres.getSlides().get_Item(0);
        IMasterSlide SourceMaster = SourceSlide.getLayoutSlide().getMasterSlide();

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 복제하여
        // 대상 프레젠테이션의 마스터 컬렉션에 추가합니다
        IMasterSlideCollection masters = destPres.getMasters();
        IMasterSlide DestMaster = masters.addClone(SourceMaster);

        // 소스 프레젠테이션에서 원하는 슬라이드를 원하는 마스터와 함께 복제하여
        // 대상 프레젠테이션 슬라이드 컬렉션의 끝에 추가합니다
        ISlideCollection slds = destPres.getSlides();
        slds.addClone(SourceSlide, DestMaster, true);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);
    } finally {
        destPres.dispose();
    }
} finally {
    srcPres.dispose();
}
```

## **지정 섹션 끝에 슬라이드 클론하기**
같은 프레젠테이션 파일 내에서 다른 섹션에 슬라이드를 클론하려면 [addClone](https://reference.aspose.com/slides/ko/java/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ISection-) 메서드를 사용하십시오. Aspose.Slides for Java를 사용하면 첫 번째 섹션에서 슬라이드를 클론한 뒤 동일 프레젠테이션의 두 번째 섹션에 삽입할 수 있습니다.

다음 코드 스니펫은 슬라이드를 클론하고 지정된 섹션에 삽입하는 방법을 보여줍니다.

```java
import com.aspose.slides.*;

IPresentation presentation = new Presentation();
try {
    presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 200, 50, 300, 100);
    presentation.getSections().addSection("Section 1", presentation.getSlides().get_Item(0));

    ISection section2 = presentation.getSections().appendEmptySection("Section 2");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0), section2);

    // 대상 프레젠테이션을 디스크에 저장합니다
    presentation.save("CloneSlideIntoSpecifiedSection.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **슬라이드 크기 일치 보장**

슬라이드를 다른 프레젠테이션에 클론할 때 대상 프레젠테이션이 원본과 동일한 슬라이드 크기를 가지고 있는지 확인하십시오. 슬라이드 크기가 다르면 Aspose.Slides는 복제된 도형을 자동으로 재조정하지 않으며, 원래 좌표와 크기가 그대로 유지되어 내용이 정렬이 어긋나거나 슬라이드 경계를 넘어 표시될 수 있습니다.

마스터와 슬라이드를 클론하기 전에 대상 프레젠테이션의 슬라이드 크기를 원본에 맞게 설정할 수 있습니다:

```java
Dimension2D sourceSize = sourcePresentation.getSlideSize().getSize();

targetPresentation.getSlideSize().setSize(
        sourceSize.getWidth(), sourceSize.getHeight(), SlideSizeScaleType.DoNotScale);
```

## **FAQ**

**강연자 메모와 검토 의견도 클론되나요?**

예. 메모 페이지와 검토 의견이 클론에 포함됩니다. 필요 없으면 삽입 후 [제거](/slides/ko/java/presentation-notes/)하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)에 연결된 경우 해당 연결이 [OLE 객체](/slides/ko/java/manage-ole/)로 보존됩니다. 파일 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

**클론의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 클론을 삽입하고 원하는 [섹션](/slides/ko/java/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 생성한 뒤 슬라이드를 이동하십시오.