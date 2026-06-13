---
title: Aspose.Slides for .NET 14.9.0에서 공개 API 및 이전 호환되지 않는 변경 사항
linktitle: Aspose.Slides for .NET 14.9.0
type: docs
weight: 110
url: /ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/
keywords:
- 마이그레이션
- 레거시 코드
- 모던 코드
- 레거시 접근 방식
- 모던 접근 방식
- PowerPoint
- OpenDocument
- 프레젠테이션
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET의 공개 API 업데이트 및 파괴적인 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하세요."
---
{{% alert color="primary" %}} 

이 페이지는 Aspose.Slides for .NET 14.9.0 API와 함께 도입된 모든 [added](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) 또는 [removed](/slides/ko/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-9-0/) 클래스, 메서드, 속성 등을 나열하고, 기타 변경 사항을 보여줍니다.

{{% /alert %}} 
## **Public API Changes**
#### **Inheritance from ICollection and Generic IEnumerable Interfaces Added to ISmartArtNodeCollection**
클래스 Aspose.Slides.SmartArt.SmartArtNodeCollection(및 관련 인터페이스 Aspose.Slides.SmartArt.ISmartArtNodeCollection)은 제네릭 인터페이스 IEnumerable<ISmartArtNode>와 인터페이스 ICollection을 상속합니다.
#### **SmartArtLayoutType.Custom Enum Value Added**
Custom SmartArt 레이아웃 유형은 사용자 지정 템플릿을 사용한 다이어그램을 나타냅니다. 사용자 지정 다이어그램은 프레젠테이션 파일에서만 로드할 수 있으며 ShapeCollection.AddSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 메서드를 통해 생성할 수 없습니다.
#### **SmartArtShape Class and ISmartArtShape Interface Added**
Aspose.Slides.SmartArt.SmartArtShape 클래스(및 인터페이스 Aspose.Slides.SmartArt.ISmartArtShape)는 SmartArt 다이어그램의 개별 도형에 대한 액세스를 제공합니다. SmartArtShape를 사용하여 FillFormat, LineFormat을 변경하고, 하이퍼링크를 추가하는 등 다양한 작업을 수행할 수 있습니다.

{{% alert color="primary" %}} 

**Note**: SmartArtShape는 IShape 속성인 RawFrame, Frame, Rotation, X, Y, Width, Height를 지원하지 않으며 해당 속성에 접근하려고 하면 System.NotSupportedException이 발생합니다.

사용 예시:

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **SmartArtShapeCollection Class, ISmartArtShapeCollection Interface and ISmartArtNode.Shapes Property Added**
Aspose.Slides.SmartArt.SmartArtShapeCollection 클래스(및 인터페이스 Aspose.Slides.SmartArt.ISmartArtShapeCollection)는 SmartArt 다이어그램의 개별 도형에 대한 액세스를 추가합니다. 이 컬렉션은 SmartArtNode와 연결된 도형을 포함합니다. SmartArtNode.Shapes 속성은 해당 노드와 연결된 모든 도형 컬렉션을 반환합니다.

{{% alert color="primary" %}} 

**Note**: SmartArtLayoutType에 따라 하나의 SmartArtShape가 여러 노드 사이에서 공유될 수 있습니다.

``` csharp

 using (Presentation pres = new Presentation())

{

  ISmartArt smart = pres.Slides[0].Shapes.AddSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

  ISmartArtNode node = smart.AllNodes[0];

  foreach (SmartArtShape shape in node.Shapes)

  {

    shape.FillFormat.FillType = FillType.Solid;

    shape.FillFormat.SolidFillColor.Color = Color.Red;

  }

  pres.Save("out.pptx", Export.SaveFormat.Pptx);

}

``` 

{{% /alert %}} 
#### **Methods for Saving Slides with Page Numbers Keeping Added**
다음 메서드가 추가되었습니다:

- void IPresentation.Save(string fname, int[] slides, SaveFormat format);
- void IPresentation.Save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.Save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

이 메서드들은 개발자가 지정된 프레젠테이션 슬라이드를 PDF, XPS, TIFF, HTML 형식으로 저장할 수 있게 합니다. 'slides' 배열은 페이지 번호를 지정하는 데 사용되며, 번호는 1부터 시작합니다.
Save(string fname, int[] slides, SaveFormat format);

``` csharp

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //슬라이드 위치 배열

presentation.Save(outFileName, slides, SaveFormat.Pdf);

``` 
#### **Methods for Replacing Images Added to PPImage, IPPImage**
새 메서드가 추가되었습니다:

- IPPImage.ReplaceImage(byte[] newImageData)
- IPPImage.ReplaceImage(Image newImage)
- IPPImage.ReplaceImage(IPPImage newImage)

``` csharp

 Presentation presentation = new Presentation(presentation.pptx);

//첫 번째 메서드

byte[] data = File.ReadAllBytes(image0.jpeg);

IPPImage oldImage = presentation.Images[0];

oldImage.ReplaceImage(data);

//두 번째 메서드

Image newImage = Image.FromFile(image1.png);

oldImage = presentation.Images[1];

oldImage.ReplaceImage(newImage);

//세 번째 메서드

oldImage = presentation.Images[2];

oldImage.ReplaceImage(presentation.Images[3]);

presentation.Save(presentation_out.pptx, SaveFormat.Pptx);

```