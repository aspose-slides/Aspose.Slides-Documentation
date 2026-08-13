---
title: Aspose.Slides for .NET 14.8.0의 공개 API 및 이전 버전과 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.8.0
type: docs
weight: 100
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트와 주요 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션할 수 있습니다."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for .NET 14.8.0 API와 함께 도입된 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-8-0/) 클래스, 메서드, 속성 등과 기타 변경 사항을 모두 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
### **변경된 속성**
#### **Added the IVbaProject Interface, Changed the Presentation.VbaProject Property**
Presentation 클래스의 VbaProject 속성이 교체되었습니다. VBA 프로젝트의 원시 바이트 표현 대신, 새로운 IVbaProject 인터페이스 구현이 추가되었습니다.

IVbaProject 속성을 사용하여 프레젠테이션에 포함된 VBA 프로젝트를 관리할 수 있습니다. 새 프로젝트 참조를 추가하고, 기존 모듈을 편집하며, 새 모듈을 만들 수 있습니다.

또한 IVbaProject 인터페이스를 구현하는 VbaProject 클래스를 사용하여 새 VBA 프로젝트를 생성할 수도 있습니다.

다음 예제는 하나의 모듈을 포함하고 두 개의 필수 라이브러리 참조를 추가하는 간단한 VBA 프로젝트를 만드는 방법을 보여줍니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;


 using (Presentation pres = new Presentation())

{

    // 새 VBA 프로젝트 생성

    pres.VbaProject = new VbaProject();

    // VBA 프로젝트에 빈 모듈 추가

    IVbaModule module = pres.VbaProject.Modules.AddEmptyModule("Module");

    // 모듈 소스 코드를 설정

    module.SourceCode =

        @"Sub Test(oShape As Shape)

            MsgBox ""Test""

        End Sub";

    // <stdole>에 대한 참조 생성

    VbaReferenceOleTypeLib stdoleReference =

        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Office에 대한 참조 생성

    VbaReferenceOleTypeLib officeReference =

        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // VBA 프로젝트에 참조 추가

    pres.VbaProject.References.Add(stdoleReference);

    pres.VbaProject.References.Add(officeReference);

    pres.Save("test.pptm", SaveFormat.Pptm);

}
``` 

이 예제는 기존 프레젠테이션에서 VBA 프로젝트를 복사하여 새 프레젠테이션에 적용하는 방법을 보여줍니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Vba;


 using (Presentation pres1 = new Presentation("PresentationWithMacroses.pptm"), pres2 = new Presentation())

{

    pres2.VbaProject = new VbaProject(pres1.VbaProject.ToBinary());

}
``` 
### **Added Interfaces, Properties and Enumeration Options**
#### **Added the Aspose.Slides.Charts.IChartSeries.Overlap Property**
Aspose.Slides.Charts.IChartSeries.Overlap 속성은 2D 차트에서 막대와 열이 겹치는 정도를 -100에서 100 사이의 값으로 지정합니다.

이 속성은 해당 시리즈뿐만 아니라 상위 시리즈 그룹에 속한 모든 시리즈에 적용되는 그룹 속성의 투영이며, 읽기 전용입니다.

- ParentSeriesGroup 속성을 사용하여 상위 시리즈 그룹에 접근합니다.
- ParentSeriesGroup.Overlap 읽기/쓰기 속성을 사용하여 값을 변경합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;


 using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   if (series[0].Overlap == 0)

      {

            series[0].ParentSeriesGroup.Overlap = -30;

      }

}
``` 
#### **Added the Aspose.Slides.Charts.IChartSeriesGroup.Overlap Property**
Aspose.Slides.Charts.IChartSeriesGroup.Overlap 속성은 2D 차트에서 막대와 열이 겹치는 정도를 -100에서 100 사이의 값으로 지정합니다.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Charts;




using (Presentation pres = new Presentation())

{

   IChart chart = pres.Slides[0].Shapes.AddChart(ChartType.ClusteredColumn, 50, 50, 600, 400, true);

   IChartSeriesCollection series = chart.ChartData.Series;

   series[0].ParentSeriesGroup.Overlap = -30;

}
``` 
#### **Added the ShapeThumbnailBounds.Appearance Enum Value**
이 메서드를 사용하면 모양 썸네일을 해당 모양의 외관 경계 안에서 생성할 수 있습니다. 모든 모양 효과를 고려하며, 생성된 썸네일은 슬라이드 경계에 제한됩니다.

``` csharp
using Aspose.Slides;

using (Presentation p = new Presentation("Presentation.pptx"))
{
    using (IImage image = p.Slides[0].Shapes[0].GetImage(ShapeThumbnailBounds.Appearance, 1, 1))
    {
        image.Save("ShapeThumbnail.png", ImageFormat.Png);
    }
}
```