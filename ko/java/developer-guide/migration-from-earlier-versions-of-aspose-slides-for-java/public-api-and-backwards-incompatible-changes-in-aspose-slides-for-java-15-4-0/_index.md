---
title: "Aspose.Slides for Java 15.4.0의 공개 API 및 이전 호환성 깨짐 변경 사항"
linktitle: "Aspose.Slides for Java 15.4.0"
type: docs
weight: 120
url: /ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- "마이그레이션"
- "레거시 코드"
- "모던 코드"
- "레거시 접근 방식"
- "현대 접근 방식"
- "PowerPoint"
- "OpenDocument"
- "프레젠테이션"
- "Java"
- "Aspose.Slides"
description: "Aspose.Slides for Java의 공개 API 업데이트와 주요 변경 사항을 검토하여 PowerPoint PPT, PPTX 및 ODP 프레젠테이션 솔루션을 원활하게 마이그레이션하십시오."
---
{{% alert color="primary" %}} 
이 페이지는 Aspose.Slides for Java 15.4.0 API와 함께 도입된 모든 [추가된](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) 클래스, 메서드, 속성 등과 새로운 제한 사항 및 기타 [변경 사항](/slides/ko/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/)을 나열합니다.
{{% /alert %}} 
## **공용 API 변경 사항**
### **Enum OrganizationChartLayoutType이 추가되었습니다**
com.aspose.slides.OrganizationChartLayoutType 열거형은 조직도에서 하위 노드의 서식 유형을 나타냅니다.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts()가 추가되었습니다**
com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts 메서드는 글머리표가 활성화된 경우(PowerPoint에서 단락 글머리표/번호 매기기를 사용하면 그렇듯) 효과적인 단락 들여쓰기와 MarginLeft에 대한 기본 비영(非零) 이동 값을 설정합니다. 글머리표가 비활성화된 경우에는 단락 들여쓰기와 MarginLeft를 기본값으로 재설정합니다(PowerPoint에서 단락 글머리표/번호 매기기를 사용하지 않을 때와 동일하게).
### **Method IConnector.reroute()가 추가되었습니다**
com.aspose.slides.IConnector.reroute() 메서드는 연결된 도형 사이의 최단 경로를 찾도록 커넥터를 재배치합니다. 이를 위해 reroute() 메서드는 StartShapeConnectionSiteIndex와 EndShapeConnectionSiteIndex를 변경할 수 있습니다.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 300, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

connector.reroute();

input.save("output.pptx", SaveFormat.Pptx);

```
### **Method IPresentation.getSlideById(long)가 추가되었습니다**
Aspose.Slides.IPresentation.getSlideById(int) 메서드는 슬라이드 ID로 Slide, MasterSlide 또는 LayoutSlide을 반환합니다.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes()가 추가되었습니다**
com.aspose.slides.ISmartArt.getNodes() 메서드는 SmartArt 개체의 루트 노드 컬렉션을 반환합니다.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // 두 번째 루트 노드 선택

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int)가 추가되었습니다**
com.aspose.slides.ISmartArt.setLayout(int) 속성에 대한 메서드가 추가되었습니다. 이를 통해 기존 다이어그램의 레이아웃 유형을 변경할 수 있습니다.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden()가 추가되었습니다**
com.aspose.slides.ISmartArtNode.isHidden() 메서드는 현재 노드가 데이터 모델에서 숨겨진 노드인지 여부를 true로 반환합니다.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); // true를 반환합니다

if(hidden) {

    // 일부 작업 또는 알림 수행

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArt.isReversed(), setReserved()가 추가되었습니다**
com.aspose.slides.ISmartArt.IsReversed 속성은 다이어그램이 좌우 반전(LTR/RTL)을 지원하는 경우 해당 상태를 가져오거나 설정할 수 있게 합니다.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int)가 추가되었습니다**
com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) 메서드는 현재 노드와 연결된 조직도 유형을 가져오거나 설정할 수 있습니다.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount()가 추가되었습니다**
com.aspose.slides.getConnectionSiteCount() 속성은 도형의 연결 지점 수를 반환합니다.

``` java

 Presentation input = new Presentation();

IShapeCollection shapes = input.getSlides().get_Item(0).getShapes();

IConnector connector = shapes.addConnector(ShapeType.BentConnector2, 0, 0, 10, 10);

IAutoShape ellipse = shapes.addAutoShape(ShapeType.Ellipse, 0, 100, 100, 100);

IAutoShape rectangle = shapes.addAutoShape(ShapeType.Rectangle, 100, 200, 100, 100);

connector.setStartShapeConnectedTo(ellipse);

connector.setEndShapeConnectedTo(rectangle);

long wantedIndex = 6;

if (ellipse.getConnectionSiteCount() > wantedIndex) {

  connector.setStartShapeConnectionSiteIndex(wantedIndex);

}

input.save("output.pptx", SaveFormat.Pptx);

```
### **마이너 변경 사항**
다음은 마이너 API 변경 사항 목록입니다:

|Enum com.aspose.slides.BevelColorMode |삭제됨, 사용되지 않는 열거형 |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |삭제됨, 사용되지 않는 속성 |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |추가됨 |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |삭제됨 |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |obsolete(구식)로 삭제됨 |