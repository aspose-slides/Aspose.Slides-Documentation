---
title: Aspose.Slides에서 PPT를 PPTX 형식으로 변환
type: docs
weight: 10
url: /ko/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** for .NET은 이제 개발자가 Presentation 클래스 인스턴스를 사용하여 PPT에 액세스하고 이를 해당 PPTX 형식으로 변환할 수 있도록 지원합니다. 현재 PPT를 PPTX로 부분 변환하는 것을 지원합니다. PPT를 PPTX로 변환할 때 지원되는 기능과 지원되지 않는 기능에 대한 자세한 내용은 이 문서 링크를 참조하십시오.

**Aspose.Slides** for .NET은 PPTX 프레젠테이션 파일을 나타내는 Presentation 클래스를 제공합니다. 이제 객체가 인스턴스화될 때 Presentation를 통해 PPT에 액세스할 수도 있습니다.

``` csharp

 //PPTX 파일을 나타내는 Presentation 객체를 인스턴스화합니다
PresentationEx pres = new PresentationEx("Conversion.ppt");
//PPTX 프레젠테이션을 PPTX 형식으로 저장합니다
pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Download Sample Code**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)