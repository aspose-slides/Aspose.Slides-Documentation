---
title: VSTO 및 Aspose.Slides에서 프레젠테이션 열기
type: docs
weight: 120
url: /ko/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
아래는 프레젠테이션을 여는 코드 스니펫입니다:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides for .NET은 기존 프레젠테이션을 여는 데 사용되는 **Presentation** 클래스를 제공합니다. 몇 가지 오버로드된 생성자를 제공하며, 기존 프레젠테이션을 기반으로 **Presentation** 클래스의 적절한 생성자를 사용하여 객체를 생성할 수 있습니다. 아래 예제에서는 열려는 프레젠테이션 파일의 이름을 Presentation 클래스의 생성자에 전달했습니다. 파일이 열리면 프레젠테이션에 포함된 슬라이드 총 개수를 얻어 화면에 출력합니다.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)