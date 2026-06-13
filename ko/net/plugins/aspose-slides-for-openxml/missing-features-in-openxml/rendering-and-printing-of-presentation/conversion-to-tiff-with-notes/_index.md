---
title: 노트가 포함된 Tiff 변환
type: docs
weight: 10
url: /ko/net/conversion-to-tiff-with-notes/
---
TIFF는 Aspose.Slides for .NET이 노트가 포함된 프레젠테이션을 이미지로 변환할 때 지원하는 여러 널리 사용되는 이미지 형식 중 하나입니다. 또한 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수 있습니다. 아래는 노트 슬라이드 보기에서 프레젠테이션의 TIFF 이미지를 생성하는 두 개의 코드 스니펫을 보여줍니다.

**Presentation** 클래스가 제공하는 **Save** 메서드를 사용하여 노트 슬라이드 보기의 전체 프레젠테이션을 TIFF로 변환할 수 있습니다. 또한 개별 슬라이드에 대해 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수 있습니다.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

Presentation pres = new Presentation(srcFileName);

//프레젠테이션을 TIFF 노트 형식으로 저장합니다

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)