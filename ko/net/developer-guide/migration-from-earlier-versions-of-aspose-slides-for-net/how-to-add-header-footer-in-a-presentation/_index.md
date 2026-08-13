---
title: 프레젠테이션에 헤더와 푸터를 추가하는 방법 (.NET)
linktitle: 헤더 및 푸터 추가
type: docs
weight: 20
url: /ko/net/how-to-add-header-footer-in-a-presentation/
keywords:
- 마이그레이션
- 헤더 추가
- 푸터 추가
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 현대 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: ".NET에서 레거시와 최신 Aspose.Slides API를 사용하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션에 헤더와 푸터를 추가하는 방법을 배웁니다."
---
{{% alert color="info" %}}
새로운 [Aspose.Slides for .NET API](/slides/ko/net/)가 릴리스되었으며, 이제 이 단일 제품은 처음부터 PowerPoint 문서를 생성하고 기존 문서를 편집하는 기능을 지원합니다.
{{% /alert %}}
## **레거시 코드 지원**
13.x 이전 Aspose.Slides for .NET 버전으로 개발된 레거시 코드를 사용하려면 코드에 약간의 수정만 하면 이전과 같이 작동합니다. 이전 Aspose.Slides for .NET에서 Aspose.Slide 및 Aspose.Slides.Pptx 네임스페이스 아래에 있던 모든 클래스가 이제 단일 Aspose.Slides 네임스페이스로 통합되었습니다. 레거시 Aspose.Slides API에서 프레젠테이션에 헤더와 푸터를 추가하는 아래 간단한 코드 스니펫을 살펴보고, 새 통합 API로 마이그레이션하는 방법을 설명하는 단계들을 따라 주세요.
## **레거시 Aspose.Slides for .NET 접근 방식**
```c#
PresentationEx sourcePres = new PresentationEx();

//헤더 및 푸터 표시 속성 설정
sourcePres.UpdateSlideNumberFields = true;

//날짜 및 시간 필드 업데이트
sourcePres.UpdateDateTimeFields = true;

//날짜 및 시간 자리 표시자 표시
sourcePres.HeaderFooterManager.IsDateTimeVisible = true;

//푸터 자리 표시자 표시
sourcePres.HeaderFooterManager.IsFooterVisible = true;

//슬라이드 번호 표시
sourcePres.HeaderFooterManager.IsSlideNumberVisible = true;

//제목 슬라이드에서 헤더 및 푸터 표시 설정
sourcePres.HeaderFooterManager.SetVisibilityOnTitleSlide(true);

//프레젠테이션을 디스크에 저장
sourcePres.Write("NewSource.pptx");
```

```c#
using Aspose.Slides;

//프레젠테이션 생성
Presentation pres = new Presentation();

//첫 번째 슬라이드 가져오기
Slide sld = pres.GetSlideByPosition(1);

//슬라이드의 헤더/푸터에 접근
HeaderFooter hf = sld.HeaderFooter;

//페이지 번호 표시 설정
hf.PageNumberVisible = true;

//푸터 표시 설정
hf.FooterVisible = true;

//헤더 표시 설정
hf.HeaderVisible = true;

//날짜 및 시간 표시 설정
hf.DateTimeVisible = true;

//날짜 및 시간 형식 설정
hf.DateTimeFormat = DateTimeFormat.DateTime_dMMMMyyyy;

//헤더 텍스트 설정
hf.HeaderText = "Header Text";

//푸터 텍스트 설정
hf.FooterText = "Footer Text";

//프레젠테이션을 디스크에 저장
pres.Write("HeadFoot.ppt");
```



## **새 Aspose.Slides for .NET 13.x 접근 방식**
```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation sourcePres = new Presentation())
{
    //헤더 및 푸터 표시 속성 설정
    sourcePres.HeaderFooterManager.SetAllSlideNumbersVisibility(true);

    //날짜 및 시간 필드 업데이트
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //날짜 및 시간 자리 표시자 표시
    sourcePres.HeaderFooterManager.SetAllDateTimesVisibility(true);

    //푸터 자리 표시자 표시
    sourcePres.HeaderFooterManager.SetAllFootersVisibility(true);
    
    //제목 슬라이드에서 헤더 푸터 표시 설정
    sourcePres.HeaderFooterManager.SetVisibilityOnAllTitleSlides(true);

    //프레젠테이션을 디스크에 저장
    sourcePres.Save("NewSource.pptx", SaveFormat.Pptx);
}
```