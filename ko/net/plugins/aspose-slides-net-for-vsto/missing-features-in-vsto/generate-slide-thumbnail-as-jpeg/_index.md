---
title: 슬라이드 썸네일을 JPEG 형식으로 생성
type: docs
weight: 90
url: /ko/net/generate-slide-thumbnail-as-jpeg/
---
Aspose.Slides for .NET을 사용하여 원하는 슬라이드의 썸네일을 생성하려면:

- Presentation 클래스의 인스턴스를 생성합니다.
- ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
- 지정된 비율로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
- 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

## **예제**
```cs
//프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))
{
    //첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.Slides[0];

    //전체 비율 이미지 생성
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //이미지를 JPEG 형식으로 디스크에 저장합니다
        image.Save("Test Thumbnail.jpg", ImageFormat.Jpeg);
    }
}
``` 

## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Slide%20Thumbnail%20to%20JPEG)

## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

자세한 내용은 [PPT 및 PPTX를 .NET에서 JPG로 변환](/slides/ko/net/convert-powerpoint-to-jpg/) 페이지를 방문하십시오.

{{% /alert %}}