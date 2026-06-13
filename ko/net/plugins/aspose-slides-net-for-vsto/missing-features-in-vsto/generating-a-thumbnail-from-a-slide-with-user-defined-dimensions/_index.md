---
title: 사용자 정의 차원을 사용한 슬라이드 썸네일 생성
type: docs
weight: 100
url: /ko/net/generating-a-thumbnail-from-a-slide-with-user-defined-dimensions/
---
Aspose.Slides for .NET을 사용하여 원하는 슬라이드의 썸네일을 생성하려면:

- Presentation 클래스의 인스턴스를 생성합니다.
- ID 또는 인덱스를 사용하여 원하는 슬라이드의 참조를 가져옵니다.
- 사용자가 정의한 X 및 Y 차원에 따라 X와 Y 축 스케일링 계수를 가져옵니다.
- 지정된 스케일로 참조된 슬라이드의 썸네일 이미지를 가져옵니다.
- 원하는 이미지 형식으로 썸네일 이미지를 저장합니다.

## **예제**
```cs
//프레젠테이션 파일을 나타내는 Presentation 클래스를 인스턴스화합니다
using (Presentation pres = new Presentation("TestPresentation.pptx"))
{
    //첫 번째 슬라이드에 접근합니다
    ISlide sld = pres.Slides[0];

    //사용자 정의 차원
    int desiredX = 1200;
    int desiredY = 800;

    //X와 Y의 스케일된 값을 가져옵니다
    float scaleX = (float)(1.0 / pres.SlideSize.Size.Width) * desiredX;
    float scaleY = (float)(1.0 / pres.SlideSize.Size.Height) * desiredY;

    //전체 축척 이미지 생성
    using (IImage image = sld.GetImage(scaleX, scaleY))
    {
        //이미지를 JPEG 형식으로 디스크에 저장합니다
        image.Save("Thumbnail2.jpg", ImageFormat.Jpeg);
    }
}
``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/User%20Defined%20Thumbnail)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 
자세한 내용은 [슬라이드 변환](/slides/ko/net/convert-slide/)를 확인하십시오.
{{% /alert %}}