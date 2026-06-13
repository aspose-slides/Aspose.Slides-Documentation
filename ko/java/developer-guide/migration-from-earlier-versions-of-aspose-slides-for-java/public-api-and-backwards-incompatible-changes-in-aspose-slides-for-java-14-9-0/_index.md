---
title: Aspose.Slides for Java 14.9.0의 공개 API 및 호환되지 않는 변경 사항
linktitle: Aspose.Slides for Java 14.9.0
type: docs
weight: 80
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- 마이그레이션
- 레거시 코드
- 최신 코드
- 레거시 접근 방식
- 최신 접근 방식
- 파워포인트
- 오픈문서
- 프레젠테이션
- 자바
- Aspose.Slides
description: Aspose.Slides for Java의 공개 API 업데이트 및 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오.
---
{{% alert color="primary" %}} 
이 페이지에서는 Aspose.Slides for Java 14.9.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) 클래스, 메서드, 속성 등을 나열하고, 새로운 제한 사항 및 기타 [changes](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)을 소개합니다.
{{% /alert %}} 
## **Public API Changes**
### **Added Methods for Replacing Image to PPImage, IPPImage**
추가된 메서드:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//첫 번째 방법

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//두 번째 방법

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Added Methods for Saving Slides Keeping Page Numbers**
다음 메서드가 추가되었습니다:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

이 메서드들을 사용하면 지정된 프레젠테이션 슬라이드를 PDF, XPS, TIFF, HTML 형식으로 저장할 수 있습니다. 'slides' 배열을 통해 페이지 번호를 지정할 수 있으며, 번호는 1부터 시작합니다.

``` java

 save(string fname, int[] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //슬라이드 위치 배열

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Added the SmartArtLayoutType.Custom Enum Value**
SmartArtLayoutType.Custom 열거형 값은 맞춤 템플릿을 사용한 다이어그램을 나타냅니다. 맞춤 다이어그램은 프레젠테이션 파일에서만 로드할 수 있으며, ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 메서드로 생성할 수 없습니다.
### **Added the SmartArtShape Class and ISmartArtShape Interface**
Aspose.Slides.SmartArt.SmartArtShape 클래스(및 해당 인터페이스 Aspose.Slides.SmartArt.ISmartArtShape)는 SmartArt 다이어그램 내부 개별 도형에 대한 접근을 제공합니다. SmartArtShape를 사용하여 FillFormat, LineFormat을 변경하거나 하이퍼링크를 추가하는 등 다양한 작업을 수행할 수 있습니다.

{{% alert color="primary" %}} 
SmartArtShape는 IShape 속성인 RawFrame, Frame, Rotation, X, Y, Width, Height를 지원하지 않으며, 해당 속성에 접근하려고 하면 System.NotSupportedException이 발생합니다.
{{% /alert %}} 

사용 예시:

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **SmartArtShapeCollection class, ISmartArtShapeCollection interface and ISmartArtNode.getShapes() method have been added**
Aspose.Slides.SmartArt.SmartArtShapeCollection 클래스(및 해당 인터페이스 Aspose.Slides.SmartArt.ISmartArtShapeCollection)는 SmartArt 다이어그램 내부 개별 도형에 대한 접근을 제공합니다. 컬렉션에는 SmartArtNode와 연결된 도형이 포함됩니다. SmartArtNode.Shapes 속성은 해당 노드와 연결된 모든 도형 컬렉션을 반환합니다.

{{% alert color="primary" %}} 
SmartArtLayoutType에 따라 하나의 SmartArtShape가 여러 노드에 공유될 수 있습니다.
{{% /alert %}} 

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```