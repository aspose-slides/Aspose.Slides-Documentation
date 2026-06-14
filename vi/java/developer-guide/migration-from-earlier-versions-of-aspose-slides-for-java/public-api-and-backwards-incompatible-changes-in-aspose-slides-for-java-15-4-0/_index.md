---
title: Thay đổi API công cộng và không tương thích ngược trong Aspose.Slides cho Java 15.4.0
linktitle: Aspose.Slides cho Java 15.4.0
type: docs
weight: 120
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/), bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) được giới thiệu trong API Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Thay đổi API công cộng**
### **Enum OrganizationChartLayoutType đã được thêm vào**
Enum com.aspose.slides.OrganizationChartLayoutType đại diện cho loại định dạng của các nút con trong biểu đồ tổ chức.
### **Phương thức IBulletFormat.applyDefaultParagraphIndentsShifts() đã được thêm vào**
Phương thức com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts đặt các giá trị dịch mặc định khác 0 cho Indent và MarginLeft của đoạn văn khi bật dấu đầu dòng (giống như PowerPoint khi bật dấu đầu dòng/đánh số cho đoạn). Nếu tắt dấu đầu dòng thì chỉ đặt lại Indent và MarginLeft của đoạn (giống như PowerPoint khi tắt dấu đầu dòng/đánh số cho đoạn).
### **Phương thức IConnector.reroute() đã được thêm vào**
Phương thức com.aspose.slides.IConnector.reroute() định tuyến lại connector sao cho nó lấy đường ngắn nhất có thể giữa các hình dạng mà nó kết nối. Để thực hiện điều này, phương thức reroute() có thể thay đổi StartShapeConnectionSiteIndex và EndShapeConnectionSiteIndex.

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
### **Phương thức IPresentation.getSlideById(long) đã được thêm vào**
Phương thức Aspose.Slides.IPresentation.getSlideById(int) trả về một Slide, MasterSlide hoặc LayoutSlide theo Id của slide.

``` java

 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Phương thức ISmartArt.getNodes() đã được thêm vào**
Phương thức com.aspose.slides.ISmartArt.getNodes() trả về tập hợp các nút gốc trong đối tượng SmartArt.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // chọn nút gốc thứ hai

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Phương thức ISmartArt.setLayout(int) đã được thêm vào**
Phương thức cho thuộc tính com.aspose.slides.ISmartArt.setLayout(int) đã được thêm vào. Nó cho phép thay đổi kiểu bố cục của một sơ đồ hiện có.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Phương thức ISmartArtNode.isHidden() đã được thêm vào**
Phương thức com.aspose.slides.ISmartArtNode.isHidden() trả về true nếu nút này là nút ẩn trong mô hình dữ liệu.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //trả về true

if(hidden) {

    //thực hiện một số hành động hoặc thông báo

}

pres.Save("out.pptx", SaveFormat.Pptx);

```
### **Phương thức ISmartArt.isReversed(), setReserved() đã được thêm vào**
Thuộc tính com.aspose.slides.ISmartArt.IsReversed cho phép lấy hoặc đặt trạng thái của sơ đồ SmartArt liên quan đến (trái sang phải) LTR hoặc (phải sang trái) RTL, nếu sơ đồ hỗ trợ đảo ngược.

``` java

 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Phương thức ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) đã được thêm vào**
Phương thức com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) cho phép lấy hoặc đặt loại biểu đồ tổ chức liên kết với nút hiện tại.

``` java

 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Thuộc tính IShape.getConnectionSiteCount() đã được thêm vào**
Thuộc tính com.aspose.slides.getConnectionSiteCount() trả về số lượng vị trí kết nối trên hình dạng.

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
### **Thay đổi nhỏ**
Đây là danh sách các thay đổi API nhỏ:

|Enum com.aspose.slides.BevelColorMode |đã xóa, enum không sử dụng |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |đã xóa, thuộc tính không sử dụng |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |đã thêm |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |đã xóa |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |đã xóa vì lỗi thời |