---
title: 프레젠테이션에 도형 추가
type: docs
weight: 30
url: /ko/net/adding-shapes-to-presentation/
---
## **VSTO**
아래는 선 모양을 추가하는 코드 스니펫입니다:

``` csharp

   Slide slide = Application.ActivePresentation.Slides[1];

  slide.Shapes.AddLine(10, 10, 100, 10);

``` 
## **Aspose.Slides**
프레젠테이션의 선택된 슬라이드에 단순한 직선을 추가하려면 아래 단계를 따라 주세요:

- Presentation 클래스를 인스턴스화합니다.
- 인덱스를 사용하여 슬라이드의 참조를 가져옵니다.
- Shapes 객체가 제공하는 AddAutoShape 메서드를 사용하여 선 유형의 AutoShape을 추가합니다.
- 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

아래 예시에서는 프레젠테이션의 첫 번째 슬라이드에 선을 추가했습니다.

``` csharp

   //PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  Presentation pres = new Presentation();
  //첫 번째 슬라이드를 가져옵니다
  ISlide slide = pres.Slides[0];
  //라인 타입의 자동 도형을 추가합니다
  slide.Shapes.AddAutoShape(ShapeType.Line, 50, 150, 300, 0);
``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Adding%20Shape%20to%20Presentation)