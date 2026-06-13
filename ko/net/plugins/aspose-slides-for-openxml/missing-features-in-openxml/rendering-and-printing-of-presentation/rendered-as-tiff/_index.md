---
title: Tiff 형식으로 렌더링
type: docs
weight: 30
url: /ko/net/rendered-as-tiff/
---
TIFF 형식은 다중 페이지 이미지와 데이터를 수용할 수 있는 유연성으로 알려져 있습니다. TIFF 형식의 중요성과 인기를 고려하여, Aspose.Slides for .NET은 프레젠테이션을 TIFF 문서로 변환하는 지원을 제공합니다.
이 문서에서는 다양한 TIFF 내보내기 옵션에 대해 설명합니다:

- 기본 크기로 프레젠테이션을 TIFF로 변환합니다.
- 사용자 지정 크기로 프레젠테이션을 TIFF로 변환합니다.

**Presentation** 클래스에서 제공하는 **Save** 메서드를 개발자가 호출하면 전체 프레젠테이션을 **TIFF** 문서로 변환할 수 있습니다. 또한, TiffOptions 클래스는 ImageSize 속성을 노출하여 필요에 따라 이미지 크기를 정의할 수 있게 합니다.

``` csharp
 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Conversion to Tiff.tiff";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
using (Presentation pres = new Presentation(srcFileName))
{
    //프레젠테이션을 TIFF 문서로 저장합니다
    pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff);
}
``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20to%20Tiff%20%28Aspose.Slides%29.zip)