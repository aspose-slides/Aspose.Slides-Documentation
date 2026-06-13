---
title: 사용자 정의 차원에 따라 TIFF로 렌더링
type: docs
weight: 40
url: /ko/net/rendered-as-tiff-by-user-defined-dimension/
---
다음 예제는 **TiffOptions** 클래스를 사용하여 맞춤형 이미지 크기로 프레젠테이션을 TIFF 문서로 변환하는 방법을 보여줍니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion.pptx";

string destFileName = FilePath + "Converting to Tiff as defined format.tiff";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다
Presentation pres = new Presentation(srcFileName);

//TiffOptions 클래스를 인스턴스화합니다
Aspose.Slides.Export.TiffOptions opts = new Aspose.Slides.Export.TiffOptions();

//압축 유형 설정
opts.CompressionType = TiffCompressionTypes.Default;

//압축 유형
//Default - 기본 압축 방식(LZW)을 지정합니다.
//None - 압축을 사용하지 않음을 지정합니다.
//CCITT3
//CCITT4
//LZW
//RLE
//Depth - 압축 유형에 따라 달라지며 수동으로 설정할 수 없습니다.
//Resolution unit - 항상 "2"(인치당 도트)와 같습니다.
//이미지 DPI 설정
opts.DpiX = 200;

opts.DpiY = 100;

//이미지 크기 설정
opts.ImageSize = new Size(1728, 1078);

//Save the presentation to TIFF with specified image size
pres.Save(destFileName, Aspose.Slides.Export.SaveFormat.Tiff, opts);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Converting%20to%20Tiff%20as%20defined%20format%20%28Aspose.Slides%29.zip)