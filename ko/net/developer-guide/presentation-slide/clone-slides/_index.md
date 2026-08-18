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
description: "Aspose.Slides for .NET을 사용하여 PowerPoint 슬라이드를 빠르게 복제하십시오. 명확한 코드 예제를 따라 몇 초 만에 PPT 생성을 자동화하고 수동 작업을 없앨 수 있습니다."
---
## **소개**

복제는 무언가를 정확히 복사하거나 복제본을 만드는 과정입니다. Aspose.Slides는 슬라이드를 복사(복제)하여 현재 프레젠테이션이나 다른 열려 있는 프레젠테이션에 삽입할 수 있도록 합니다. 슬라이드 복제는 원본 슬라이드에 영향을 주지 않고 개발자가 수정할 수 있는 새 슬라이드를 생성합니다. 슬라이드를 복제하는 방법에는 여러 가지가 있습니다:

- 프레젠테이션 끝에 복제.
- 프레젠테이션 내 다른 위치에 복제.
- 다른 프레젠테이션 끝에 복제.
- 다른 프레젠테이션의 다른 위치에 복제.
- 마스터 슬라이드와 함께 다른 프레젠테이션에 복제.

Aspose.Slides for .NET에서는 [Presentation] 객체가 노출하는 슬라이드 컬렉션([ISlide] 객체 컬렉션)을 통해 위에서 설명한 슬라이드 복제 작업을 수행하는 [AddClone] 및 [InsertClone] 메서드를 제공합니다.

## **프레젠테이션 끝에 슬라이드 복제**

슬라이드를 복제하고 동일한 프레젠테이션 파일의 기존 슬라이드 끝에 사용하려면 아래 단계에 따라 [AddClone] 메서드를 사용하십시오:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 노출하는 [AddClone] 메서드를 호출하고 복제할 슬라이드를 [AddClone] 메서드의 매개변수로 전달합니다.
1. 수정된 프레젠테이션 파일을 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 위치(인덱스 0)에 있는 슬라이드를 프레젠테이션 끝으로 복제했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("CloneWithinSamePresentationToEnd.pptx"))
{

    // 같은 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.Slides;

    slds.AddClone(pres.Slides[0]);

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.Save("Aspose_CloneWithinSamePresentationToEnd_out.pptx", SaveFormat.Pptx);

}
```

## **프레젠테이션 내 다른 위치에 슬라이드 복제**

슬라이드를 복제하고 동일한 프레젠테이션 파일에서 다른 위치에 사용하려면 [InsertClone] 메서드를 사용하십시오:

1. [Presentation] 클래스의 인스턴스를 생성합니다.
1. [Presentation] 객체가 노출하는 **Slides** 컬렉션을 참조하여 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 노출하는 [InsertClone] 메서드를 호출하고 복제할 슬라이드와 새로운 위치 인덱스를 [InsertClone] 메서드의 매개변수로 전달합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 인덱스 1(위치 2)에 있는 슬라이드를 인덱스 2(위치 3)로 복제했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("CloneWithInSamePresentation.pptx"))
{

    // 같은 프레젠테이션의 슬라이드 컬렉션 끝에 원하는 슬라이드를 복제합니다
    ISlideCollection slds = pres.Slides;

    // 같은 프레젠테이션에서 지정된 인덱스로 원하는 슬라이드를 복제합니다
    slds.InsertClone(2, pres.Slides[1]);

    // 수정된 프레젠테이션을 디스크에 저장합니다
    pres.Save("Aspose_CloneWithInSamePresentation_out.pptx", SaveFormat.Pptx);

}
```

## **다른 프레젠테이션 끝에 슬라이드 복제**

한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 기존 슬라이드 끝에 사용해야 하는 경우:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 **Slides** 컬렉션을 참조하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 노출하는 [AddClone] 메서드를 호출하고 원본 프레젠테이션의 슬라이드를 [AddClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 첫 번째 인덱스에 있는 슬라이드를 대상 프레젠테이션 끝으로 복제했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 대상 PPTX(슬라이드를 복제할 위치)를 위해 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {
        // 소스 프레젠테이션에서 원하는 슬라이드를 복제하여 대상 프레젠테이션 슬라이드 컬렉션의 끝에 추가합니다
        ISlideCollection slds = destPres.Slides;

        slds.AddClone(srcPres.Slides[0]);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **다른 프레젠테이션 내 다른 위치에 슬라이드 복제**

한 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션 파일의 특정 위치에 사용해야 하는 경우:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 슬라이드를 추가할 대상 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 노출하는 [InsertClone] 메서드를 호출하고 원본 프레젠테이션의 슬라이드와 원하는 위치를 [InsertClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 인덱스 0에 있는 슬라이드를 대상 프레젠테이션의 인덱스 1(위치 2)으로 복제했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
using (Presentation srcPres = new Presentation("CloneAtEndOfAnother.pptx"))
{
    // 대상 PPTX(슬라이드를 복제할 위치)를 위해 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {
        ISlideCollection slds = destPres.Slides;

        slds.InsertClone(2, srcPres.Slides[0]);

        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("Aspose2_out.pptx", SaveFormat.Pptx);
    }
}
```

## **마스터 슬라이드와 함께 슬라이드를 다른 프레젠테이션에 복제**

한 프레젠테이션에서 마스터 슬라이드와 함께 슬라이드를 복제하여 다른 프레젠테이션에 사용하려면 먼저 원하는 마스터 슬라이드를 원본 프레젠테이션에서 대상 프레젠테이션으로 복제해야 합니다. 그런 다음 해당 마스터 슬라이드를 사용하여 마스터가 포함된 슬라이드를 복제합니다. **AddClone(ISlide, IMasterSlide)** 메서드는 원본이 아닌 대상 프레젠테이션의 마스터 슬라이드를 기대합니다. 마스터와 함께 슬라이드를 복제하려면 아래 단계에 따라 진행하십시오:

1. 슬라이드를 복제할 원본 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 슬라이드를 복제할 대상 프레젠테이션을 포함하는 [Presentation] 클래스의 인스턴스를 생성합니다.
1. 복제할 슬라이드와 마스터 슬라이드에 접근합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Masters 컬렉션을 참조하여 [IMasterSlideCollection] 클래스를 인스턴스화합니다.
1. [IMasterSlideCollection] 객체가 노출하는 [AddClone] 메서드를 호출하고 복제할 원본 PPTX의 마스터를 [AddClone] 메서드의 매개변수로 전달합니다.
1. 대상 프레젠테이션의 [Presentation] 객체가 노출하는 Slides 컬렉션을 참조하도록 설정하여 [ISlideCollection] 클래스를 인스턴스화합니다.
1. [ISlideCollection] 객체가 노출하는 [AddClone] 메서드를 호출하고 복제할 원본 프레젠테이션의 슬라이드와 마스터 슬라이드를 [AddClone] 메서드의 매개변수로 전달합니다.
1. 수정된 대상 프레젠테이션 파일을 저장합니다.

아래 예시에서는 원본 프레젠테이션의 인덱스 0에 있는 마스터와 함께 슬라이드를 복제하여 해당 마스터를 사용해 대상 프레젠테이션 끝으로 복제했습니다.

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// 소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다

using (Presentation srcPres = new Presentation("CloneToAnotherPresentationWithMaster.pptx"))
{
    // 대상 프레젠테이션(슬라이드를 복제할 위치)을 위해 Presentation 클래스를 인스턴스화합니다
    using (Presentation destPres = new Presentation())
    {

        // 소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 인스턴스화하고
        // 마스터 슬라이드와 함께 가져옵니다
        ISlide SourceSlide = srcPres.Slides[0];
        IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlideCollection masters = destPres.Masters;
        IMasterSlide DestMaster = SourceSlide.LayoutSlide.MasterSlide;

        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다
        // 대상 프레젠테이션
        IMasterSlide iSlide = masters.AddClone(SourceMaster);

        // 소스 프레젠테이션의 원하는 슬라이드를 원하는 마스터와 함께 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
        // 대상 프레젠테이션의 슬라이드 컬렉션
        ISlideCollection slds = destPres.Slides;
        slds.AddClone(SourceSlide, iSlide, true);
      
        // 소스 프레젠테이션에서 원하는 마스터 슬라이드를 대상 프레젠테이션의 마스터 컬렉션에 복제합니다 // 대상 프레젠테이션
        // 대상 프레젠테이션을 디스크에 저장합니다
        destPres.Save("CloneToAnotherPresentationWithMaster_out.pptx", SaveFormat.Pptx);

    }
}
```

## **지정된 섹션 끝에 슬라이드 복제**

Aspose.Slides for .NET를 사용하면 프레젠테이션의 한 섹션에서 슬라이드를 복제하고 동일한 프레젠테이션의 다른 섹션에 삽입할 수 있습니다. 이 경우 [ISlideCollection] 인터페이스의 [AddClone] 메서드를 사용해야 합니다.

다음 C# 코드는 슬라이드를 복제하고 지정된 섹션에 삽입하는 방법을 보여줍니다:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 150, 100, 100); // 복제할 대상
    
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISection section = pres.Sections.AddSection("Section2", slide2);

    pres.Slides.AddClone(slide, section);
    
    pres.Save("pres.pptx", SaveFormat.Pptx);
}
```

## **슬라이드 크기 일치 확인**

슬라이드를 다른 프레젠테이션에 복제할 때는 대상 프레젠테이션이 원본과 동일한 슬라이드 크기를 가지고 있는지 확인하십시오. 슬라이드 크기가 다르면 Aspose.Slides는 복제된 도형을 자동으로 리스케일하지 않으며, 원래 좌표와 크기가 유지되어 내용이 정렬이 맞지 않거나 슬라이드 경계를 넘어 표시될 수 있습니다.

마스터와 슬라이드를 복제하기 전에 대상 프레젠테이션의 슬라이드 크기를 원본에 맞게 설정할 수 있습니다:

```cs
SizeF sourceSize = sourcePresentation.SlideSize.Size;

targetPresentation.SlideSize.SetSize(
    sourceSize.Width, sourceSize.Height, SlideSizeScaleType.DoNotScale);
```

마스터와 슬라이드를 복제하기 전에 이 작업을 수행하십시오.

## **FAQ**

**스피커 노트와 검토자 코멘트도 복제되나요?**

예. 노트 페이지와 검토 코멘트가 복제에 포함됩니다. 원하지 않을 경우 삽입 후 [제거](/slides/ko/net/presentation-notes/)하십시오.

**차트와 데이터 소스는 어떻게 처리되나요?**

차트 객체, 서식 및 포함된 데이터가 복사됩니다. 차트가 외부 소스(예: OLE 삽입 워크북)와 연결되어 있었다면 해당 연결이 [OLE object](/slides/ko/net/manage-ole/)로 보존됩니다. 파일 간 이동 후 데이터 가용성과 새로 고침 동작을 확인하십시오.

**복제의 삽입 위치와 섹션을 제어할 수 있나요?**

예. 특정 슬라이드 인덱스에 복제를 삽입하고 원하는 [section](/slides/ko/net/slide-section/)에 배치할 수 있습니다. 대상 섹션이 없으면 먼저 생성한 뒤 슬라이드를 이동시키십시오.