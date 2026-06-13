---
title: 슬라이드를 새로운 위치로 이동하기
type: docs
weight: 140
url: /ko/net/move-a-slide-to-a-new-position/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 프레젠테이션의 슬라이드 수를 계산합니다.

public static int CountSlides(string presentationFile)

{

    // 프레젠테이션을 읽기 전용으로 엽니다.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 프레젠테이션을 다음 CountSlides 메서드에 전달합니다

        // 그리고 슬라이드 수를 반환합니다.

        return CountSlides(presentationDocument);

    }

}

// 프레젠테이션의 슬라이드를 계산합니다.

public static int CountSlides(PresentationDocument presentationDocument)

{

    // 문서 객체가 null인지 확인합니다.

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    int slidesCount = 0;

    // 문서의 프레젠테이션 파트를 가져옵니다.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // SlideParts에서 슬라이드 수를 가져옵니다.

    if (presentationPart != null)

    {

        slidesCount = presentationPart.SlideParts.Count();

    }

    // 이전 메서드에 슬라이드 수를 반환합니다.

    return slidesCount;

}

// 프레젠테이션에서 슬라이드 순서를 다른 위치로 이동합니다.

public static void MoveSlide(string presentationFile, int from, int to)

{

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, true))

    {

        MoveSlide(presentationDocument, from, to);

    }

}

// 프레젠테이션에서 슬라이드 순서를 다른 위치로 이동합니다.

public static void MoveSlide(PresentationDocument presentationDocument, int from, int to)

{

    if (presentationDocument == null)

    {

        throw new ArgumentNullException("presentationDocument");

    }

    // 프레젠테이션의 슬라이드 수를 얻기 위해 CountSlides 메서드를 호출합니다.

    int slidesCount = CountSlides(presentationDocument);

    // from과 to 위치가 범위 내에 있으며 서로 다른지 확인합니다.

    if (from < 0 || from >= slidesCount)

    {

        throw new ArgumentOutOfRangeException("from");

    }

    if (to < 0 || from >= slidesCount || to == from)

    {

        throw new ArgumentOutOfRangeException("to");

    }

    // 프레젠테이션 문서에서 프레젠테이션 파트를 가져옵니다.

    PresentationPart presentationPart = presentationDocument.PresentationPart;

    // 슬라이드 수가 0이 아니므로 프레젠테이션에 슬라이드가 포함되어야 합니다.            

    Presentation presentation = presentationPart.Presentation;

    SlideIdList slideIdList = presentation.SlideIdList;

    // 소스 슬라이드의 ID를 가져옵니다.

    SlideId sourceSlide = slideIdList.ChildElements[from] as SlideId;

    SlideId targetSlide = null;

    // 소스 슬라이드를 이동할 대상 슬라이드의 위치를 식별합니다.

    if (to == 0)

    {

        targetSlide = null;

    }

    if (from < to)

    {

        targetSlide = slideIdList.ChildElements[to] as SlideId;

    }

    else

    {

        targetSlide = slideIdList.ChildElements[to - 1] as SlideId;

    }

    // 현재 위치에서 소스 슬라이드를 제거합니다.

    sourceSlide.Remove();

    // 대상 슬라이드 뒤에 새로운 위치에 소스 슬라이드를 삽입합니다.

    slideIdList.InsertAfter(sourceSlide, targetSlide);

    // 수정된 프레젠테이션을 저장합니다.

    presentation.Save();

} 
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Move a slide to a new position.pptx";

MoveSlide(FileName, 1, 2);

// 프레젠테이션에서 슬라이드 순서를 다른 위치로 이동합니다.

public static void MoveSlide(string presentationFile, int from, int to)

{

    // 소스 PPTX 파일을 로드하기 위해 PresentationEx 클래스를 인스턴스화합니다

    using (Presentation pres = new Presentation(presentationFile))

    {

        // 위치를 변경할 슬라이드를 가져옵니다

        ISlide sld = pres.Slides[from];

        ISlide sld2 = pres.Slides[to];

        // 슬라이드의 새로운 위치를 설정합니다

        sld2.SlideNumber = from;

        sld.SlideNumber = to;

        // PPTX를 디스크에 저장합니다

        pres.Save(presentationFile,Aspose.Slides.Export.SaveFormat.Pptx);

    }

}

``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Move%20a%20slide%20to%20a%20new%20position/)