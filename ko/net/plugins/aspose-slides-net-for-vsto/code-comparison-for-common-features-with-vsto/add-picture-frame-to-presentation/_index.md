---
title: 프레젠테이션에 그림 프레임 추가
type: docs
weight: 50
url: /ko/net/add-picture-frame-to-presentation/
---
## **VSTO**
아래는 VSTO 프레젠테이션에 이미지를 추가하는 코드입니다:

``` csharp

  string ImageFilePath="AddPicture.jpg";

 Slide slide = Application.ActivePresentation.Slides[1];

 slide.Shapes.AddPicture(ImageFilePath, Microsoft.Office.Core.MsoTriState.msoFalse,

 Microsoft.Office.Core.MsoTriState.msoCTrue, 0, 0);

``` 
## **Aspose.Slides**
슬라이드에 간단한 그림 프레임을 추가하려면 아래 단계를 따르세요:

1. Presentation 클래스의 인스턴스를 생성합니다.
1. 인덱스를 사용하여 슬라이드에 대한 참조를 가져옵니다.
1. Presentation 객체와 연결된 Images 컬렉션에 이미지를 추가하여 Shape을 채우는 데 사용할 Image 객체를 생성합니다.
1. 이미지의 너비와 높이를 계산합니다.
1. 참조된 슬라이드와 연결된 Shapes 객체가 제공하는 AddPictureFrame 메서드를 사용하여 이미지의 너비와 높이에 맞는 PictureFrame을 생성합니다.
1. 슬라이드에 그림이 포함된 PictureFrame을 추가합니다.
1. 수정된 프레젠테이션을 PPTX 파일로 저장합니다.

위 단계는 아래 예제에서 구현됩니다.

``` csharp

   string ImageFilePath = "AddPicture.jpg";

  //PPTX를 나타내는 Presentation 클래스를 인스턴스화합니다
  Presentation pres = new Presentation();

  //첫 번째 슬라이드를 가져옵니다
  ISlide sld = pres.Slides[0];

  //ImageEx 클래스를 인스턴스화합니다
  using IImage img = Images.FromFile(ImageFilePath);

  IPPImage imgx = pres.Images.AddImage(img);

  //그림과 동일한 높이와 너비를 가진 그림 프레임을 추가합니다
  sld.Shapes.AddPictureFrame(ShapeType.Rectangle, 50, 150, imgx.Width, imgx.Height, imgx);

``` 
## **실행 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **샘플 코드 다운로드**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Add%20Picture%20Frame)