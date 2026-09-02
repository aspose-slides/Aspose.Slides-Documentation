---
title: 사용자 정의 값으로 슬라이드를 썸네일 JPEG로 렌더링
type: docs
weight: 70
url: /ko/net/render-slide-as-thumbnail-to-jpeg-by-user-defined-values/
---
Aspose.Slides for .NET를 사용하여 원하는 슬라이드의 썸네일을 생성하려면:

1. **Presentation** 클래스의 인스턴스를 생성합니다.
1. ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
1. 사용자가 정의한 X 및 Y 차원을 기반으로 X와 Y 스케일링 요소를 가져옵니다.
1. 지정된 배율로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
1. 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

``` csharp
using Aspose.Slides;

string filePath = @"..\..\..\Sample Files\";
string srcFileName = filePath + "User Defined Thumbnail.pptx";
string destFileName = filePath + "User Defined Thumbnail.jpg";

//Instantiate the Presentation class that represents the presentation file
//Access the first slide
//User defined dimension
//Getting scaled value  of X and Y
//Create a full scale image
//Save the image to disk in JPEG format
using (Presentation pres = new Presentation(srcFileName))
{
    //Access the first slide
    ISlide sld = pres.Slides[0];

    //User defined dimension
    int desiredX = 1200;
    int desiredY = 800;

    //Getting scaled value  of X and Y
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //Create a full scale image
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //Save the image to disk in JPEG format
        image.Save(destFileName, ImageFormat.Jpeg);
    }
}
``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/User%20Defined%20Thumbnail%20%28Aspose.Slides%29.zip)