---
title: 슬라이드를 썸네일로 JPEG 변환
type: docs
weight: 60
url: /ko/net/render-slide-as-thumbnail-to-jpeg/
---
**Aspose.Slides for .NET**는 슬라이드가 포함된 프레젠테이션 파일을 만드는 데 사용됩니다. 이러한 슬라이드는 Microsoft PowerPoint로 프레젠테이션 파일을 열어 볼 수 있습니다. 그러나 때때로 개발자는 좋아하는 이미지 뷰어를 사용하여 슬라이드를 이미지로 보고 싶어 할 수 있습니다. 이러한 경우 Aspose.Slides for .NET이 슬라이드의 썸네일 이미지를 생성하도록 도와줍니다.

Aspose.Slides for .NET을 사용하여 원하는 슬라이드의 썸네일을 생성하려면:

1. **Presentation** 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. 지정된 비율로 해당 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

```csharp
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