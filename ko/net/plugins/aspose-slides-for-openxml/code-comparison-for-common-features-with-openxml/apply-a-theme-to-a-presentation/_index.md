---
title: 프레젠테이션에 테마 적용
type: docs
weight: 30
url: /ko/net/apply-a-theme-to-a-presentation/
---
## **OpenXML 프레젠테이션**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(FileName, ThemeFileName);

// 프레젠테이션에 새로운 테마를 적용합니다. 

public static void ApplyThemeToPresentation(string presentationFile, string themePresentation)

{

    using (PresentationDocument themeDocument = PresentationDocument.Open(themePresentation, false))

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        ApplyThemeToPresentation(presentationDocument, themeDocument);

    }

}

// 프레젠테이션에 새로운 테마를 적용합니다. 

public static void ApplyThemeToPresentation(PresentationDocument presentationDocument, PresentationDocument themeDocument)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    if (themeDocument == null)

    {

        throw new ArgumentNullException("themeDocument");

    }

    // 프레젠테이션 문서의 프레젠테이션 파트를 가져옵니다.
    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 기존 슬라이드 마스터 파트를 가져옵니다.
    SlideMasterPart slideMasterPart = presentationPart.SlideMasterParts.ElementAt(0);

    string relationshipId = presentationPart.GetIdOfPart(slideMasterPart);

    // 새 슬라이드 마스터 파트를 가져옵니다.
    SlideMasterPart newSlideMasterPart = themeDocument.PresentationPart.SlideMasterParts.ElementAt(0);

    // 기존 테마 파트를 제거합니다.
    presentationPart.DeletePart(presentationPart.ThemePart);

    // 기존 슬라이드 마스터 파트를 제거합니다.
    presentationPart.DeletePart(slideMasterPart);

    // 새 슬라이드 마스터 파트를 가져오고, 기존 관계 ID를 재사용합니다.
    newSlideMasterPart = presentationPart.AddPart(newSlideMasterPart, relationshipId);

    // 새 테마 파트로 교체합니다.
    presentationPart.AddPart(newSlideMasterPart.ThemePart);

    Dictionary<string, SlideLayoutPart> newSlideLayouts = new Dictionary<string, SlideLayoutPart>();

    foreach (var slideLayoutPart in newSlideMasterPart.SlideLayoutParts)

    {

        newSlideLayouts.Add(GetSlideLayoutType(slideLayoutPart), slideLayoutPart);

    }

    string layoutType = null;

    SlideLayoutPart newLayoutPart = null;

    // 이 예제의 레이아웃 코드를 삽입합니다.
    string defaultLayoutType = "Title and Content";

    // 모든 슬라이드에서 슬라이드 레이아웃 관계를 제거합니다. 
    foreach (var slidePart in presentationPart.SlideParts)

    {

        layoutType = null;

        if (slidePart.SlideLayoutPart != null)

        {

            // 각 슬라이드의 레이아웃 유형을 결정합니다.
            layoutType = GetSlideLayoutType(slidePart.SlideLayoutPart);

            // 기존 레이아웃 파트를 삭제합니다.
            slidePart.DeletePart(slidePart.SlideLayoutPart);

        }

        if (layoutType != null && newSlideLayouts.TryGetValue(layoutType, out newLayoutPart))

        {

            // 새 레이아웃 파트를 적용합니다.
            slidePart.AddPart(newLayoutPart);

        }

        else

        {

            newLayoutPart = newSlideLayouts[defaultLayoutType];

            // 새 기본 레이아웃 파트를 적용합니다.
            slidePart.AddPart(newLayoutPart);

        }

    }

}

// 슬라이드 레이아웃 유형을 가져옵니다.
public static string GetSlideLayoutType(SlideLayoutPart slideLayoutPart)

{

    CommonSlideData slideData = slideLayoutPart.SlideLayout.CommonSlideData;

    // 비고: 실제 코드에서 사용할 경우 null 참조 여부를 확인해야 합니다.
    return slideData.Name;

}   

``` 
## **Aspose.Slides**
테마를 적용하려면 마스터와 함께 슬라이드를 복제해야 합니다. 아래 단계에 따라 진행하십시오:

- 슬라이드가 복제될 원본 프레젠테이션을 포함하는 Presentation 클래스의 인스턴스를 생성합니다.
- 슬라이드가 복제될 대상 프레젠테이션을 포함하는 Presentation 클래스의 인스턴스를 생성합니다.
- 복제할 슬라이드와 해당 마스터 슬라이드에 접근합니다.
- 대상 프레젠테이션의 Presentation 객체가 노출하는 Masters 컬렉션을 참조하여 IMasterSlideCollection 클래스를 인스턴스화합니다.
- IMasterSlideCollection 객체가 노출하는 AddClone 메서드를 호출하고, 복제할 원본 PPTX의 마스터를 AddClone 메서드의 매개변수로 전달합니다.
- 대상 프레젠테이션의 Presentation 객체가 노출하는 Slides 컬렉션을 참조하도록 설정하여 ISlideCollection 클래스를 인스턴스화합니다.
- ISlideCollection 객체가 노출하는 AddClone 메서드를 호출하고, 복제할 원본 프레젠테이션의 슬라이드와 마스터 슬라이드를 AddClone 메서드의 매개변수로 전달합니다.
- 수정된 대상 프레젠테이션 파일을 기록합니다.

``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Apply Theme to Presentation.pptx";

string ThemeFileName = FilePath + "Theme.pptx";

ApplyThemeToPresentation(ThemeFileName, FileName);

public static void ApplyThemeToPresentation(string presentationFile, string outputFile)

{

    //소스 프레젠테이션 파일을 로드하기 위해 Presentation 클래스를 인스턴스화합니다
    Presentation srcPres = new Presentation(presentationFile);
    //대상 프레젠테이션(슬라이드를 복제할 위치)을 위해 Presentation 클래스를 인스턴스화합니다
    Presentation destPres = new Presentation(outputFile);
    //소스 프레젠테이션의 슬라이드 컬렉션에서 ISlide를 인스턴스화하고
    //마스터 슬라이드
    ISlide SourceSlide = srcPres.Slides[0];
    //소스 프레젠테이션에서 원하는 마스터 슬라이드를 복제하여 대상 프레젠테이션의 마스터 컬렉션에 추가합니다
    //대상 프레젠테이션
    IMasterSlideCollection masters = destPres.Masters;
    IMasterSlide SourceMaster = SourceSlide.LayoutSlide.MasterSlide;
    //소스 프레젠테이션에서 원하는 마스터 슬라이드를 복제하여 대상 프레젠테이션의 마스터 컬렉션에 추가합니다
    //대상 프레젠테이션
    IMasterSlide iSlide = masters.AddClone(SourceMaster);
    //소스 프레젠테이션의 원하는 슬라이드를 원하는 마스터와 함께 대상 프레젠테이션의 슬라이드 컬렉션 끝에 복제합니다
    //대상 프레젠테이션의 슬라이드 컬렉션
    ISlideCollection slds = destPres.Slides;
    slds.AddClone(SourceSlide, iSlide, true);
    //소스 프레젠테이션에서 원하는 마스터 슬라이드를 복제하여 대상 프레젠테이션의 마스터 컬렉션에 추가합니다
    //대상 프레젠테이션을 디스크에 저장합니다
    destPres.Save(outputFile, SaveFormat.Pptx);
}
``` 
## **실행 코드 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
## **샘플 코드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/OpenXML/Common%20Features/Apply%20Theme%20to%20Presentation)