---
title: 효율적으로 .NET에서 프레젠테이션 병합하기
linktitle: 프레젠테이션 병합
type: docs
weight: 40
url: /ko/net/merge-presentation/
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
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET를 사용하여 PowerPoint(PPT, PPTX) 및 OpenDocument(ODP) 프레젠테이션을 손쉽게 병합하고 워크플로를 간소화합니다."
---
## **개요**

Aspose.Slides는 하나의 프레젠테이션에서 슬라이드를 복제하여 다른 프레젠테이션에 병합할 수 있습니다. 이 문서에서는 전체 프레젠테이션 또는 선택한 슬라이드를 병합하는 방법, 병합 중 슬라이드 마스터 또는 특정 레이아웃을 사용하는 방법, 슬라이드 크기가 다른 프레젠테이션을 처리하는 방법, 병합된 슬라이드를 프레젠테이션 섹션에 추가하는 방법을 설명합니다. 또한 연설자 노트, 댓글, 비밀번호로 보호된 원본 파일 및 스레드 사용과 같은 병합된 내용과 관련된 실용적인 주의 사항도 다룹니다.

## **프레젠테이션 병합 최적화**

[Aspose.Slides for .NET](https://products.aspose.com/slides/ko/net/)를 사용하면 스타일, 레이아웃 및 모든 요소를 보존하면서 PowerPoint 프레젠테이션을 손쉽게 결합할 수 있습니다. 다른 도구와 달리 Aspose.Slides는 품질을 손상시키거나 데이터를 잃지 않고 프레젠테이션을 결합합니다. 전체 프레젠테이션, 특정 슬라이드, 심지어 서로 다른 파일 형식(PPT에서 PPTX 등)도 병합할 수 있습니다.

### **병합 기능**

- **전체 프레젠테이션 병합:** 모든 슬라이드를 하나의 파일로 조합합니다.
- **특정 슬라이드 병합:** 선택한 슬라이드를 선택하고 결합합니다.
- **크로스 포맷 병합:** 다양한 형식의 프레젠테이션을 통합하여 무결성을 유지합니다.

{{% alert title="Tip" color="primary" %}}  

빠르고 **무료 온라인 도구**로 **PowerPoint 프레젠테이션을 병합**하고 싶으신가요? [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/ko/merger)를 사용해 보세요.  

- **PowerPoint 파일을 쉽게 병합**: 여러 **PPT, PPTX, ODP** 프레젠테이션을 하나의 파일로 결합합니다.  
- **다양한 형식 지원**: **PPT를 PPTX로**, **PPTX를 ODP로** 등으로 병합합니다.  
- **설치 필요 없음**: 브라우저에서 바로 작동하며 빠르고 안전합니다.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/ko/merger)  

오늘 바로 **Aspose 무료 온라인 도구**로 PowerPoint 파일을 병합해 보세요!  

{{% /alert %}}

## **프레젠테이션 병합**

다른 프레젠테이션에 [프레젠테이션 하나를 병합](https://products.aspose.com/slides/ko/net/merger/ppt/)하면, 실질적으로 슬라이드를 하나의 프레젠테이션으로 결합해 하나의 파일을 얻는 것입니다. 

{{% alert title="Info" color="info" %}}

대부분의 프레젠테이션 프로그램(PowerPoint 또는 OpenOffice)에는 사용자가 이렇게 프레젠테이션을 결합할 수 있는 기능이 없습니다.  

하지만 [**Aspose.Slides for .NET**](https://products.aspose.com/slides/ko/net/)을 사용하면 다양한 방식으로 프레젠테이션을 병합할 수 있습니다. 모양, 스타일, 텍스트, 서식, 댓글, 애니메이션 등 모든 요소를 잃지 않고 프레젠테이션을 병합할 수 있습니다.  

**또한 보기**

[Clone Slides](https://docs.aspose.com/slides/ko/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **병합할 수 있는 항목**

Aspose.Slides를 사용하면 다음을 병합할 수 있습니다.

* 전체 프레젠테이션. 모든 프레젠테이션의 슬라이드가 하나의 프레젠테이션에 포함됩니다.
* 특정 슬라이드. 선택한 슬라이드가 하나의 프레젠테이션에 포함됩니다.
* 동일한 형식(PPT에서 PPT, PPTX에서 PPTX 등) 및 서로 다른 형식(PPT에서 PPTX, PPTX에서 ODP 등)의 프레젠테이션을 서로 병합합니다.

{{% alert title="Note" color="warning" %}} 

프레젠테이션 외에도 Aspose.Slides를 사용하면 다른 파일도 병합할 수 있습니다:

* [이미지](https://products.aspose.com/slides/ko/net/merger/image-to-image/), 예를 들어 [JPG to JPG](https://products.aspose.com/slides/ko/net/merger/jpg-to-jpg/) 또는 [PNG to PNG](https://products.aspose.com/slides/ko/net/merger/png-to-png/)
* 문서, 예를 들어 [PDF to PDF](https://products.aspose.com/slides/ko/net/merger/pdf-to-pdf/) 또는 [HTML to HTML](https://products.aspose.com/slides/ko/net/merger/html-to-html/)
* 그리고 서로 다른 두 파일, 예를 들어 [image to PDF](https://products.aspose.com/slides/ko/net/merger/image-to-pdf/) 또는 [JPG to PDF](https://products.aspose.com/slides/ko/net/merger/jpg-to-pdf/) 또는 [TIFF to PDF](https://products.aspose.com/slides/ko/net/merger/tiff-to-pdf/).

{{% /alert %}}

### **병합 옵션**

다음과 같은 옵션을 적용하여 결정할 수 있습니다.

* 출력 프레젠테이션의 각 슬라이드가 고유한 스타일을 유지할지 여부
* 출력 프레젠테이션의 모든 슬라이드에 특정 스타일을 적용할지 여부.

프레젠테이션을 병합하기 위해 Aspose.Slides는 [AddClone](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone) 메서드([ISlideCollection](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection) 인터페이스에서)를 제공합니다. `AddClone` 메서드에는 병합 프로세스 매개변수를 정의하는 여러 구현이 있습니다. 모든 Presentation 객체에는 [Slides](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/properties/slides) 컬렉션이 있으므로, 슬라이드를 병합하려는 프레젠테이션에서 `AddClone` 메서드를 호출할 수 있습니다.

`AddClone` 메서드는 원본 슬라이드의 복제본인 `ISlide` 객체를 반환합니다. 출력 프레젠테이션의 슬라이드는 원본 슬라이드의 복사본에 불과합니다. 따라서 원본 프레젠테이션에 영향을 주지 않고 결과 슬라이드에 변경을 적용할 수 있습니다(예: 스타일, 서식 옵션 또는 레이아웃 적용).

## **프레젠테이션 병합** 

Aspose.Slides는 슬라이드의 레이아웃과 스타일을 유지하면서 슬라이드를 결합할 수 있는 [**AddClone (ISlide)**](https://reference.aspose.com/slides/ko/net/aspose.slides/islidecollection/methods/addclone) 메서드를 제공합니다(기본 매개변수).

다음 C# 코드는 프레젠테이션을 병합하는 방법을 보여줍니다:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **슬라이드 마스터를 사용한 프레젠테이션 병합**

Aspose.Slides는 슬라이드 마스터 프레젠테이션 템플릿을 적용하면서 슬라이드를 결합할 수 있는 [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/ko/net/aspose.slides.islidecollection/addclone/methods/2) 메서드를 제공합니다. 이를 통해 필요할 경우 출력 프레젠테이션의 슬라이드 스타일을 변경할 수 있습니다.

다음 C# 코드는 위에서 설명한 작업을 보여줍니다:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}} 

슬라이드 마스터의 레이아웃은 자동으로 결정됩니다. 적절한 레이아웃을 결정할 수 없을 경우, `AddClone` 메서드의 `allowCloneMissingLayout` 불리언 매개변수가 true로 설정되어 있으면 원본 슬라이드의 레이아웃이 사용됩니다. 그렇지 않으면 [PptxEditException](https://reference.aspose.com/slides/ko/net/aspose.slides/pptxeditexception)이 발생합니다. 

{{% /alert %}}

출력 프레젠테이션의 슬라이드에 다른 레이아웃을 적용하려면 병합 시 대신 [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/ko/net/aspose.slides.islidecollection/addclone/methods/1) 메서드를 사용하십시오. 

## **프레젠테이션에서 특정 슬라이드 병합**

여러 프레젠테이션에서 특정 슬라이드를 병합하면 맞춤형 슬라이드 데크를 만들 때 유용합니다. Aspose.Slides for .NET를 사용하면 필요한 슬라이드만 선택하고 가져올 수 있습니다. API는 원본 슬라이드의 서식, 레이아웃 및 디자인을 보존합니다.

다음 C# 코드는 새 프레젠테이션을 생성하고 두 다른 프레젠테이션에서 타이틀 슬라이드를 추가한 뒤 결과를 파일에 저장합니다:

```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **슬라이드 레이아웃을 사용한 프레젠테이션 병합**

다음 C# 코드는 프레젠테이션의 슬라이드를 결합하면서 원하는 슬라이드 레이아웃을 적용해 하나의 출력 프레젠테이션을 만드는 방법을 보여줍니다:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **다른 슬라이드 크기를 가진 프레젠테이션 병합**

{{% alert title="Note" color="warning" %}} 

다른 슬라이드 크기의 프레젠테이션을 병합할 수 없습니다. 

{{% /alert %}}

다른 슬라이드 크기를 가진 두 프레젠테이션을 병합하려면, 한 프레젠테이션의 크기를 조정하여 다른 프레젠테이션과 크기를 맞춰야 합니다. 

이 샘플 코드는 위에서 설명한 작업을 시연합니다:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **프레젠테이션 섹션에 슬라이드 병합**

다음 C# 코드는 특정 슬라이드를 프레젠테이션 섹션에 병합하는 방법을 보여줍니다:

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

슬라이드는 섹션의 끝에 추가됩니다. 

{{% alert title="Tip" color="primary" %}}

Aspose는 [무료 Collage 웹 앱](https://products.aspose.app/slides/ko/collage)을 제공합니다. 이 온라인 서비스를 사용하면 [JPG to JPG](https://products.aspose.app/slides/ko/collage/jpg) 또는 PNG to PNG 이미지를 병합하고, [photo grids](https://products.aspose.app/slides/ko/collage/photo-grid)를 만들 수 있습니다. 

{{% /alert %}}

## **FAQ**

**병합 중 연설자 노트가 보존됩니까?**

예. 슬라이드를 복제할 때 Aspose.Slides는 노트, 서식 및 애니메이션을 포함한 모든 슬라이드 요소를 그대로 전달합니다.

**댓글 및 작성자 정보가 전송됩니까?**

댓글은 슬라이드 내용의 일부로 복사되며, 댓글 작성자 라벨도 결과 프레젠테이션의 댓글 객체로 보존됩니다.

**원본 프레젠테이션이 비밀번호로 보호된 경우 어떻게 해야 합니까?**

비밀번호가 설정된 경우 [비밀번호로 열어야 합니다](/slides/ko/net/password-protected-presentation/) ([LoadOptions.Password](https://reference.aspose.com/slides/ko/net/aspose.slides/loadoptions/password/) 사용). 로드한 후 해당 슬라이드를 보호되지 않은 대상 파일(또는 보호된 파일)로 안전하게 복제할 수 있습니다.

**병합 작업은 스레드 안전합니까?**

동일한 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/) 인스턴스를 [여러 스레드](/slides/ko/net/multithreading/)에서 사용하지 마십시오. 권장 규칙은 "문서 하나당 하나의 스레드"이며, 다른 파일은 별도 스레드에서 병렬 처리할 수 있습니다.