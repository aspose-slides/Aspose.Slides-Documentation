---
title: .NET에서 프레젠테이션 슬라이드 복제
linktitle: 슬라이드 복제
type: docs
weight: 40
url: /ko/net/clone-slides/
keywords:
- 슬라이드 복제
- 슬라이드 복사
- 슬라이드 저장
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드를 빠르게 복제합니다. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

클론은 무언가를 정확히 복제하거나 복사하는 과정입니다. Aspose.Slides는 슬라이드(클론)를 복사하고 복제된 슬라이드를 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있게 해줍니다. 슬라이드 클론을 하면 원본 슬라이드에 영향을 주지 않고 새 슬라이드를 수정할 수 있습니다. 슬라이드를 클론하는 방법은 다음과 같습니다.

- 프레젠테이션 끝에 클론하기.
- 프레젠테이션 내 다른 위치에 클론하기.
- 다른 프레젠테이션 끝에 클론하기.
- 다른 프레젠테이션의 다른 위치에 클론하기.
- 다른 프레젠테이션의 특정 위치에 클론하기.

Aspose.Slides for .NET에서 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 객체가 노출하는 슬라이드 컬렉션([ISlide](https://reference.aspose.com/slides/ko/net/aspose.slides/islide/) 객체들의 컬렉션)은 위에 설명된 슬라이드 클론 작업을 수행하기 위해 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/addclone/) 및 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides/ishapecollection/insertclone/) 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 클론하기**

동일한 프레젠테이션 파일 내에서 기존 슬라이드 끝에 클론된 슬라이드를 사용하려면 아래 단계에 따라 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 사용하십시오.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 클래스를 인스턴스화합니다.
1. [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 호출하고, 클론할 슬라이드를 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드에 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 클론했습니다.

```c#
// Presentation 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 원하는 슬라이드를 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **프레젠테이션 내 다른 위치에 슬라이드 클론하기**

동일한 프레젠테이션 파일 내에서 다른 위치에 슬라이드를 클론하려면 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/insertclone/methods/1) 메서드를 사용하십시오.

1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스의 인스턴스를 생성합니다.
1. [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
1. [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 객체가 제공하는 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/insertclone/methods/1) 메서드를 호출하고, 클론할 슬라이드와 새 위치에 대한 인덱스를 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/insertclone/methods/1) 메서드에 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예제에서는 프레젠테이션의 첫 번째 위치(인덱스 0, 즉 위치 1)에 있던 슬라이드를 인덱스 1(위치 2)으로 클론했습니다.

```c#
// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 원하는 슬라이드를 동일한 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
    ISlideCollection slds = pres.Slides;

    // 원하는 슬라이드를 동일한 프레젠테이션의 지정된 인덱스로 복제합니다
    slds.InsertClone(2, pres.Slides[1]);

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **다른 프레젠테이션 끝에 슬라이드 클론하기**

한 프레젠테이션에서 슬라이드를 클론하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용하려면 다음 단계를 따르십시오.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 복제된 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 클래스를 인스턴스화합니다.
1. [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드를 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드에 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 첫 번째 인덱스에 있던 슬라이드를 대상 프레젠테이션 끝으로 클론했습니다.

```c#
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 대상 PPTX(슬라이드를 복제할 위치)를 위한 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {
        // 소스 프레젠테이션에서 원하는 슬라이드를 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **다른 프레젠테이션의 다른 위치에 슬라이드 클론하기**

한 프레젠테이션에서 슬라이드를 클론하여 다른 프레젠테이션 파일의 특정 위치에 사용하려면 다음을 수행합니다.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 클래스를 인스턴스화합니다.
1. [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 객체가 제공하는 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/insertclone/methods/1) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드와 원하는 위치를 [InsertClone](https://reference.aspose.com/slides/ko/net/aspose.slides.ishapecollection/insertclone/methods/1) 메서드에 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있던 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 클론했습니다.

```c#
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 대상 PPTX(슬라이드를 복제할 위치)를 위한 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **다른 프레젠테이션의 특정 위치에 마스터 슬라이드와 함께 클론하기**

한 프레젠테이션에서 마스터 슬라이드를 포함한 슬라이드를 다른 프레젠테이션에 클론하려면 먼저 원본 프레젠테이션의 원하는 마스터 슬라이드를 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용해 슬라이드를 클론합니다. **AddClone(ISlide, IMasterSlide)** 은 원본이 아니라 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 클론하려면 아래 단계를 따르십시오.

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스 인스턴스를 생성합니다.
1. 클론할 슬라이드와 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection) 클래스를 인스턴스화합니다.
1. [IMasterSlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/imasterslidecollection) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 호출하고, 원본 PPTX에서 복제할 마스터를 매개변수로 전달합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 클래스를 인스턴스화합니다.
1. [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 객체가 제공하는 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 호출하고, 원본 프레젠테이션의 슬라이드와 복제된 마스터 슬라이드를 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예제에서는 원본 프레젠테이션의 인덱스 0에 있는 마스터와 함께 슬라이드를 대상 프레젠테이션 끝으로 클론했습니다.

```c#
// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 대상 프레젠테이션(슬라이드를 복제할 위치)을 위한 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {

        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 마스터 슬라이드와 함께 인스턴스화합니다
        // 마스터 슬라이드
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 소스 프레젠테이션에서 원하는 마스터와 함께 원하는 슬라이드를 끝에 복제합니다
        // 대상 프레젠테이션의 슬라이드 컬렉션
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 마스터 컬렉션에 복제합니다 // 대상 프레젠테이션
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **지정된 섹션 끝에 슬라이드 클론하기**

Aspose.Slides for .NET을 사용하면 한 프레젠테이션의 섹션에서 슬라이드를 클론하여 동일한 프레젠테이션의 다른 섹션에 삽입할 수 있습니다. 이 경우 [ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 인터페이스의 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone/index) 메서드를 사용해야 합니다.

다음 C# 코드는 슬라이드를 클론하고 지정된 섹션에 삽입하는 방법을 보여줍니다.

```c#
using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 복제할 슬라이드
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **FAQ**

**강연자 노트와 검토자 주석도 클론되나요?**

네. 노트 페이지와 검토 주석이 복제에 포함됩니다. 필요하지 않다면 삽입 후 [제거](/slides/ko/net/presentation-notes/)하십시오.

**차트와 차트 데이터 원본은 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)에 연결된 경우 해당 연결이 [OLE 객체](/slides/ko/net/manage-ole/)로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로고침 동작을 확인하십시오.

**클론의 삽입 위치와 섹션을 제어할 수 있나요?**

네. 특정 슬라이드 인덱스에 클론을 삽입하고 원하는 [섹션](/slides/ko/net/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 섹션을 만든 뒤 슬라이드를 이동하십시오.