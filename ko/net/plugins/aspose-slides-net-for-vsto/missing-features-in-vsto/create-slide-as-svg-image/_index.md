---
title: 슬라이드를 SVG 이미지로 만들기
type: docs
weight: 70
url: /ko/net/create-slide-as-svg-image/
---
Aspose.Slides.Pptx for .NET을 사용하여 원하는 슬라이드에서 SVG 이미지를 생성하려면 아래 단계를 따르세요:

- Presentation 클래스의 인스턴스를 생성합니다.
- 원하는 슬라이드의 ID 또는 인덱스를 사용하여 해당 슬라이드에 대한 참조를 얻습니다.
- 메모리 스트림에 SVG 이미지를 가져옵니다.
- 메모리 스트림을 파일로 저장합니다.
## **예제**

```

 //Presentation 클래스를 인스턴스화하여 프레젠테이션 파일을 나타냅니다

using (Presentation pres = new Presentation("Slides Test Presentation.pptx"))

{

   //두 번째 슬라이드에 접근합니다
   ISlide sld = pres.Slides[1];

   //메모리 스트림 객체를 생성합니다
   MemoryStream SvgStream = new MemoryStream();

   //슬라이드의 SVG 이미지를 생성하고 메모리 스트림에 저장합니다
   sld.WriteAsSvg(SvgStream);
   SvgStream.Position = 0;

   //메모리 스트림을 파일에 저장합니다
   using (Stream fileStream = System.IO.File.OpenWrite("PresentatoinTemplate.svg"))
   {

     byte[] buffer = new byte[8 * 1024];
     int len;
     while ((len = SvgStream.Read(buffer, 0, buffer.Length)) > 0)
     {

       fileStream.Write(buffer, 0, len);
     }

   }

}

SvgStream.Close();

``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Creating%20Slide%20SVG%20Image)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

자세한 내용은 [Render Presentation Slides as SVG Images in .NET](/slides/ko/net/render-a-slide-as-an-svg-image/)을(를) 확인하십시오.

{{% /alert %}}