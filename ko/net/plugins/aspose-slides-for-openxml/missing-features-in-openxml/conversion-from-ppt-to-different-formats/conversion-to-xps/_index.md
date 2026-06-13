---
title: XPS로 변환
type: docs
weight: 40
url: /ko/net/conversion-to-xps/
---
**XPS** 형식은 데이터 교환에 널리 사용됩니다. Aspose.Slides for .NET은 그 중요성을 인식하고 프레젠테이션을 XPS 문서로 변환하기 위한 내장 지원을 제공합니다.

Presentation 클래스에 노출된 **Save** 메서드를 사용하여 전체 프레젠테이션을 **XPS** 문서로 변환할 수 있습니다. 또한 **XpsOptions** 클래스는 요구 사항에 따라 true 또는 false로 설정할 수 있는 **SaveMetafileAsPng** 속성을 노출합니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to XPS.xps";

//프레젠테이션 파일을 나타내는 Presentation 개체를 인스턴스화합니다

Presentation pres = new Presentation(srcFileName);

//프레젠테이션을 TIFF 문서로 저장합니다

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Xps);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20XPS%20%28Aspose.Slides%29.zip)