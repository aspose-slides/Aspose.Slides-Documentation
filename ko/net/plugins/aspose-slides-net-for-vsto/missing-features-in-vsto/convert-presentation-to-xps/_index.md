---
title: 프레젠테이션을 XPS로 변환
type: docs
weight: 60
url: /ko/net/convert-presentation-to-xps/
---
**XPS** 형식은 데이터 교환에 널리 사용됩니다. Aspose.Slides for .NET은 그 중요성을 인식하고 프레젠테이션을 XPS 문서로 변환하기 위한 내장 지원을 제공합니다.

Presentation 클래스에서 제공하는 **Save** 메서드를 사용하여 전체 프레젠테이션을 **XPS** 문서로 변환할 수 있습니다. 또한 **XpsOptions** 클래스는 **SaveMetafileAsPng** 속성을 제공하며, 필요에 따라 true 또는 false로 설정할 수 있습니다.
## **Example**

``` 

 //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation("Conversion.ppt");

//프레젠테이션을 TIFF 문서로 저장합니다

pres.Save("converted.xps", Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **Download Running Example**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Converting%20to%20XPS)
## **Download Sample Code**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

자세한 내용은 [PowerPoint 프레젠테이션을 .NET에서 XPS로 변환](/slides/ko/net/convert-powerpoint-to-xps/)을 참조하십시오.

{{% /alert %}}