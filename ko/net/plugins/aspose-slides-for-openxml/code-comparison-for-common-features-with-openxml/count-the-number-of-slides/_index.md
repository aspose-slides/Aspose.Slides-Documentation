---
title: 슬라이드 수 세기
type: docs
weight: 50
url: /ko/net/count-the-number-of-slides/
---
## **OpenXML SDK**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",
CountSlides(FileName));

Console.ReadKey();

// 프레젠테이션 객체를 가져와 다음 CountSlides 메서드에 전달합니다.

public static int CountSlides(string presentationFile)

{

    // 프레젠테이션을 읽기 전용으로 엽니다.

    using (PresentationDocument presentationDocument = PresentationDocument.Open(presentationFile, false))

    {

        // 프레젠테이션을 다음 CountSlide 메서드에 전달합니다
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
``` 
## **Aspose.Slides**
``` csharp

 string FilePath = @"..\..\..\..\Sample Files\";

string FileName = FilePath + "Count the number of slides.pptx";

Console.WriteLine("Number of slides = {0}",
CountSlides(FileName));

Console.ReadKey();

public static int CountSlides(string presentationFile)

{

  //PPTX 파일을 나타내는 PresentationEx 객체를 생성합니다
  using (Presentation pres = new Presentation(presentationFile))
  {
     return pres.Slides.Count;
  }

}  
``` 
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsOpenXML1.1)
- [Sourceforge](https://sourceforge.net/projects/asposeopenxml/files/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides%20%28Aspose.Slides%29.zip/download)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/src/master/Aspose.Slides%20Vs%20OpenXML/Count%20the%20number%20of%20Slides/)