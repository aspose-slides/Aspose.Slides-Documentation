---
title: 프레젠테이션에 레이아웃 슬라이드 추가
type: docs
weight: 10
url: /ko/net/add-layout-slide-to-presentation/
---
Aspose.Slides for .NET은 개발자가 프레젠테이션에 새로운 레이아웃 슬라이드를 추가할 수 있도록 합니다. 레이아웃 슬라이드를 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- Master Slide 컬렉션에 접근합니다
- 기존 레이아웃 슬라이드를 찾아서 원하는 슬라이드가 레이아웃 슬라이드 컬렉션에 이미 있는지 확인합니다
- 원하는 레이아웃이 없을 경우 새로운 레이아웃 슬라이드를 추가합니다
- 새로 추가된 레이아웃 슬라이드와 함께 빈 슬라이드를 추가합니다
- 마지막으로 Presentation 객체를 사용하여 프레젠테이션 파일을 씁니다.
## **예제**
``` csharp

 //프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation p = new Presentation("Test.pptx"))
{
   //레이아웃 슬라이드 유형으로 검색을 시도합니다
   IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;
   ILayoutSlide layoutSlide =
   layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??
   layoutSlides.GetByType(SlideLayoutType.Title);
   if (layoutSlide == null)
   {
     //프레젠테이션에 특정 유형의 레이아웃이 포함되지 않은 경우의 상황입니다.
     //Technographics.pptx 프레젠테이션은 Blank 및 Custom 레이아웃 유형만 포함합니다.
     //하지만 Custom 유형의 레이아웃 슬라이드에는 서로 다른 슬라이드 이름이 있습니다,
     //"Title", "Title and Content" 등과 같은 이름이 있으며, 이러한
     //이름을 레이아웃 슬라이드 선택에 사용할 수 있습니다.
     //또한 자리표시자 형태 유형 집합을 사용할 수 있습니다. 예를 들어,
     //Title 슬라이드에는 Title 자리표시자 유형만 있어야 하며, 등.
     foreach (ILayoutSlide titleAndObjectLayoutSlide in layoutSlides)
     {
       if (titleAndObjectLayoutSlide.Name == "Title and Object")
       {
          layoutSlide = titleAndObjectLayoutSlide;
          break;
       }
      }
      if (layoutSlide == null)
      {
         foreach (ILayoutSlide titleLayoutSlide in layoutSlides)
         {
            if (titleLayoutSlide.Name == "Title")
            {
                layoutSlide = titleLayoutSlide;
                break;
            }
          }
          if (layoutSlide == null)
          {
             layoutSlide = layoutSlides.GetByType(SlideLayoutType.Blank);
             if (layoutSlide == null)
             {
                  layoutSlide = layoutSlides.Add(SlideLayoutType.TitleAndObject, "Title and Object");
             }
          }
      }
  }
  //추가된 레이아웃 슬라이드로 빈 슬라이드를 추가합니다
  p.Slides.InsertEmptySlide(0, layoutSlide);
  //프레젠테이션을 저장합니다
  p.Save("Output.pptx", SaveFormat.Pptx);
}
``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Adding%20Layout%20Slides)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
자세한 내용은 [.NET에서 슬라이드 레이아웃 적용 또는 변경](/slides/ko/net/slide-layout/)를 방문하세요.
{{% /alert %}}