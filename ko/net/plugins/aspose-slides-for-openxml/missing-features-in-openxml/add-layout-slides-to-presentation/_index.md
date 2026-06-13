---
title: 프레젠테이션에 레이아웃 슬라이드 추가
type: docs
weight: 20
url: /ko/net/add-layout-slides-to-presentation/
---
Aspose.Slides for .NET은 개발자가 프레젠테이션에 새로운 레이아웃 슬라이드를 추가할 수 있도록 합니다. 레이아웃 슬라이드를 추가하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다
- 마스터 슬라이드 컬렉션에 접근합니다
- 레이아웃 슬라이드 컬렉션에 필요한 레이아웃 슬라이드가 이미 있는지 확인하기 위해 기존 레이아웃 슬라이드를 찾습니다
- 원하는 레이아웃이 없으면 새 레이아웃 슬라이드를 추가합니다
- 새로 추가된 레이아웃 슬라이드와 함께 빈 슬라이드를 추가합니다
- 마지막으로 Presentation 객체를 사용해 프레젠테이션 파일을 저장합니다
## **예제**
``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string FileName = FilePath + "Adding Layout Slides.pptx";

//Instantiate Presentation class that represents the presentation file

using (Presentation p = new Presentation(FileName))

{

    // Try to search by layout slide type

    IMasterLayoutSlideCollection layoutSlides = p.Masters[0].LayoutSlides;

    ILayoutSlide layoutSlide =

        layoutSlides.GetByType(SlideLayoutType.TitleAndObject) ??

        layoutSlides.GetByType(SlideLayoutType.Title);

    if (layoutSlide == null)

    {

        // The situation when a presentation doesn't contain some type of layouts.

        // Technographics.pptx presentation only contains Blank and Custom layout types.

        // But layout slides with Custom types has different slide names,

        // like "Title", "Title and Content", etc. And it is possible to use these

        // names for layout slide selection.

        // Also it is possible to use the set of placeholder shape types. For example,

        // Title slide should have only Title plecaholder type, etc.

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

    //Adding empty slide with added layout slide 

    p.Slides.InsertEmptySlide(0, layoutSlide);

    //Save presentation    

    p.Save(FileName, SaveFormat.Pptx);

}

``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Missing%20Features/Adding%20Layout%20Slides)

{{% alert color="primary" %}} 
자세한 내용은 [Apply or Change Slide Layouts in .NET](/slides/ko/net/slide-layout/)를 확인하십시오.
{{% /alert %}}