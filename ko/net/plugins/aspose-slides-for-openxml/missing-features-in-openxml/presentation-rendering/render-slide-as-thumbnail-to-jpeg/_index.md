---
title: JPEG 로 슬라이드 썸네일 렌더링
type: docs
weight: 60
url: /ko/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET** 은 슬라이드를 포함하는 프레젠테이션 파일을 만드는 데 사용됩니다. 이 슬라이드는 Microsoft PowerPoint 로 프레젠테이션 파일을 열어 볼 수 있습니다. 하지만 때때로 개발자는 즐겨 사용하는 이미지 뷰어로 슬라이드를 이미지로 보고 싶을 수 있습니다. 이런 경우 Aspose.Slides for .NET 이 슬라이드의 썸네일 이미지를 생성하도록 도와줍니다.

Aspose.Slides for .NET 을 사용하여 원하는 슬라이드의 썸네일을 생성하려면:

1. **Presentation** 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. 지정된 배율로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "Slide Thumbnail to JPEG.pptx";
string destFileName = filePath + "Slide Thumbnail to JPEG.jpg";

//프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation(srcFileName))
{
    //첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.Slides[0];

    //전체 크기의 이미지를 생성합니다
    using (IImage image = sld.GetImage(1f, 1f))
    {
        //이미지를 JPEG 형식으로 디스크에 저장합니다
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 

## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Slide%20Thumbnail%20to%20JPEG%20%28Aspose.Slides%29.zip)