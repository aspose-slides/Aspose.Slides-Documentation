---
title: PDF 변환
type: docs
weight: 30
url: /ko/net/conversion-to-pdf/
---
PDF 문서는 조직, 정부 부처 및 개인 간에 문서를 교환하는 표준 형식으로 널리 사용됩니다. 이 형식이 인기가 있어 개발자들은 종종 Microsoft PowerPoint 프레젠테이션 파일을 PDF 문서로 변환하도록 요청받습니다. 이러한 요구가 발생할 수 있음을 인식하고, Aspose.Slides for .NET는 다른 구성 요소를 사용하지 않고 프레젠테이션을 PDF 문서로 변환하는 기능을 지원합니다.

**Aspose.Slides for .NET**는 프레젠테이션 파일을 나타내는 Presentation 클래스를 제공합니다. **Presentation** 클래스는 전체 프레젠테이션을 **PDF** 문서로 변환하기 위해 호출할 수 있는 Save 메서드를 노출합니다. **PdfOptions** 클래스는 JpegQuality, TextCompression, Compliance 등과 같은 **PDF** 생성 옵션을 제공합니다. 이러한 옵션을 사용하여 원하는 PDF 표준을 얻을 수 있습니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to PDF.pdf";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation(srcFileName);

//프레젠테이션을 기본 옵션으로 PDF에 저장합니다

pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Pdf);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20PDF%20%28Aspose.Slides%29.zip)