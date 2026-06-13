---
title: OpenOffice 문서 변환
type: docs
weight: 30
url: /ko/net/conversion-of-openoffice-document/
---
Aspose.Slides for .NET은 프레젠테이션 파일을 나타내는 **Presentation** 클래스를 제공합니다. 이제 **Presentation** 클래스는 객체가 인스턴스화될 때 Presentation 생성자를 통해 **ODP**에도 접근할 수 있습니다.

다음은 ODP를 PPT/PPTX로 변환하는 예제입니다.
## **예제**
```

 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

using(PresentationEx pres = new PresentationEx("OpenOfficePresentation.odp"))

{

   //PPTX 형식으로 PPTX 프레젠테이션을 저장합니다

   pres.Save("ConvertedFromOdp",Aspose.Slides.Export.SaveFormat.Pptx);

}

``` 

다음은 PPT/PPTX를 ODP로 변환하는 예제입니다.
## **예제**
``` 
 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

using (PresentationEx pres = new PresentationEx("ConversionFromPresentation.pptx"))

{

   //PPTX 형식으로 PPTX 프레젠테이션을 저장합니다

   pres.Save("ConvertedToOdp", Aspose.Slides.Export.SaveFormat.Odp);

}

``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Conversion%20from%20ODP%20to%20PPTX)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)