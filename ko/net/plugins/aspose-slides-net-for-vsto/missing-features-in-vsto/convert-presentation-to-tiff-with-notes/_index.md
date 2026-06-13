---
title: 노트가 포함된 프레젠테이션을 Tiff로 변환
type: docs
weight: 50
url: /ko/net/convert-presentation-to-tiff-with-notes/
---
TIFF는 Aspose.Slides for .NET이 노트가 포함된 프레젠테이션을 이미지로 변환하는 데 지원하는 여러 널리 사용되는 이미지 형식 중 하나입니다. 또한 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수 있습니다. 아래는 노트 슬라이드 보기에서 프레젠테이션의 TIFF 이미지를 생성하는 방법을 보여주는 두 개의 코드 스니펫입니다.

[Save](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation/methods/save) 메서드와 [Presentation](https://reference.aspose.com/slides/ko/net/aspose.slides/presentation) 클래스는 노트 슬라이드 보기에서 전체 프레젠테이션을 TIFF로 변환하는 데 사용할 수 있습니다. 개별 슬라이드에 대해서도 노트 슬라이드 보기에서 슬라이드 썸네일을 생성할 수 있습니다.
## **예제**

``` 

  //프레젠테이션 파일을 나타내는 Presentation 객체를 인스턴스화합니다

 Presentation pres = new Presentation("Conversion.pptx");

 //프레젠테이션을 TIFF 노트로 저장합니다

 pres.Save("ConvertedwithNotes.tiff", SaveFormat.TiffNotes);

``` 
## **실행 예제 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Aspose.Slides%20Features%20missing%20in%20VSTO/Tiff%20conversion%20with%20note)
## **샘플 코드 다운로드**
- [GitHub](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/Aspose.SlidesFeaturesmissingInVSTOv1.1)

{{% alert color="primary" %}} 

자세한 내용은 [PowerPoint 프레젠테이션을 .NET에서 노트와 함께 TIFF로 변환](/slides/ko/net/convert-powerpoint-to-tiff-with-notes/)을 방문하십시오.

{{% /alert %}}