---
title: "Aspose.Slides for Java 14.9.0에서 공개 API 및 이전 버전과 호환되지 않는 변경 사항"
linktitle: "Aspose.Slides for Java 14.9.0"
type: docs
weight: 80
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- "마이그레이션"
- "레거시 코드"
- "현대 코드"
- "레거시 접근 방식"
- "현대 접근 방식"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java의 공개 API 업데이트와 파괴적 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="info" %}} 

이 페이지에서는 Aspose.Slides for Java 14.9.0 API와 함께 도입된 모든 [added](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) 클래스, 메서드, 속성 등, 새로운 제한 사항 및 기타 [changes](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/)을 나열합니다.

{{% /alert %}} 
## **공용 API 변경 사항**
### **이미지를 PPImage, IPPImage로 교체하기 위한 추가 메서드**
새로운 메서드가 추가되었습니다:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // 첫 번째 방법
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // 두 번째 방법
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **페이지 번호를 유지하면서 슬라이드를 저장하기 위한 추가 메서드**
다음 메서드가 추가되었습니다:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

이 메서드들은 지정된 프레젠테이션 슬라이드를 PDF, XPS, TIFF, HTML 형식으로 저장할 수 있습니다. 'slides' 배열은 1부터 시작하는 페이지 번호를 지정하도록 허용합니다.

``` java
// IPresentation에 추가된 오버로드 (SaveFormat 값은 Java의 int 상수입니다):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // 슬라이드 위치 배열

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **SmartArtLayoutType.Custom 열거형 값 추가**
이 SmartArt 레이아웃 유형은 사용자 정의 템플릿을 가진 다이어그램을 나타냅니다. 사용자 정의 다이어그램은 프레젠테이션 파일에서만 로드할 수 있으며 ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom) 메서드로는 생성할 수 없습니다.
### **SmartArtShape 클래스 및 ISmartArtShape 인터페이스 추가**
Aspose.Slides.SmartArt.SmartArtShape 클래스(및 인터페이스 Aspose.Slides.SmartArt.ISmartArtShape)는 SmartArt 다이어그램 내부의 개별 형태에 대한 접근을 제공합니다. SmartArtShape를 사용하여 FillFormat, LineFormat를 변경하거나 하이퍼링크 등을 추가할 수 있습니다.

{{% alert color="info" %}} 

SmartArtShape는 IShape 속성인 RawFrame, Frame, Rotation, X, Y, Width, Height를 지원하지 않으며, 해당 속성에 접근하려고 하면 System.NotSupportedException이 발생합니다.

{{% /alert %}} 

사용 예시:

``` java
import com.aspose.slides.*;
import java.awt.Color;


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
### **SmartArtShapeCollection 클래스, ISmartArtShapeCollection 인터페이스 및 ISmartArtNode.getShapes() 메서드가 추가되었습니다**
Aspose.Slides.SmartArt.SmartArtShapeCollection 클래스(및 인터페이스 Aspose.Slides.SmartArt.ISmartArtShapeCollection)는 SmartArt 다이어그램 내부의 개별 형태에 대한 접근을 제공합니다. 이 컬렉션은 SmartArtNode와 연관된 형태들을 포함합니다. SmartArtNode.Shapes 속성은 해당 노드와 연관된 모든 형태의 컬렉션을 반환합니다.

{{% alert color="info" %}} 

SmartArtLayoutType에 따라 하나의 SmartArtShape가 여러 노드 간에 공유될 수 있습니다.

{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


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