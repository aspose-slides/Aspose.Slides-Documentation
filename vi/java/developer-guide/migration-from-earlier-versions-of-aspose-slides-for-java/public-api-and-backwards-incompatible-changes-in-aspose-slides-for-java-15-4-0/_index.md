---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides for Java 15.4.0
linktitle: Aspose.Slides cho Java 15.4.0
type: docs
weight: 120
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides for Java để chuyển đổi suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thứ khác [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) , bất kỳ hạn chế mới nào và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-4-0/) được giới thiệu cùng với API Aspose.Slides for Java 15.4.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Enum OrganizationChartLayoutType đã được thêm vào**
Enum com.aspose.slides.OrganizationChartLayoutType đại diện cho kiểu định dạng của các nút con trong một biểu đồ tổ chức.
### **Method IBulletFormat.applyDefaultParagraphIndentsShifts() đã được thêm vào**
Phương thức com.aspose.slides.IBulletFormat.ApplyDefaultParagraphIndentsShifts đặt các dịch chuyển mặc định khác không cho Indent và MarginLeft của đoạn khi bật dấu đầu dòng (giống như PowerPoint làm khi bật dấu đầu dòng/đánh số trong đoạn). Nếu dấu đầu dòng bị tắt thì chỉ đặt lại Indent và MarginLeft của đoạn (giống như PowerPoint làm khi tắt dấu đầu dòng/đánh số trong đoạn).
### **Method IConnector.reroute() đã được thêm vào**
Phương thức com.aspose.slides.IConnector.reroute() điều hướng lại kết nối sao cho nó đi theo đường ngắn nhất có thể giữa các hình mà nó kết nối. Để thực hiện điều này, phương thức reroute() có thể thay đổi giá trị của StartShapeConnectionSiteIndex và EndShapeConnectionSiteIndex.

``` java
import com.aspose.slides.*;


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
### **Method IPresentation.getSlideById(long) đã được thêm vào**
Phương thức Aspose.Slides.IPresentation.getSlideById(long) trả về một Slide, MasterSlide hoặc LayoutSlide theo Id của slide.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

long id = presentation.getSlides().get_Item(0).getSlideId();

IBaseSlide slide = presentation.getSlideById(id);

```
### **Method ISmartArt.getNodes() đã được thêm vào**
Phương thức com.aspose.slides.ISmartArt.getNodes() trả về một collection các nút gốc trong đối tượng SmartArt.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.VerticalBulletList);

ISmartArtNode node = smart.getNodes().get_Item(1); // chọn nút gốc thứ hai

node.getTextFrame().setText("Second root node");

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArt.setLayout(int) đã được thêm vào**
Phương thức cho thuộc tính com.aspose.slides.ISmartArt.setLayout(int) đã được thêm vào. Nó cho phép thay đổi kiểu bố cục của một sơ đồ hiện có.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

smart.setLayout(SmartArtLayoutType.BasicProcess);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Method ISmartArtNode.isHidden() đã được thêm vào**
Phương thức com.aspose.slides.ISmartArtNode.isHidden() trả về true nếu nút này là một nút ẩn trong mô hình dữ liệu.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

ISmartArtNode node = smart.getAllNodes().addNode();

boolean hidden = node.isHidden(); //trả về true

if(hidden) {

    //thực hiện một số hành động hoặc thông báo

}

pres.save("out.pptx", SaveFormat.Pptx);
```
### **Methods ISmartArt.isReversed(), setReversed() đã được thêm vào**
Thuộc tính com.aspose.slides.ISmartArt.IsReversed cho phép lấy hoặc đặt trạng thái của sơ đồ SmartArt liên quan tới (trái sang phải) LTR hoặc (phải sang trái) RTL, nếu sơ đồ hỗ trợ đảo ngược.

``` java
import com.aspose.slides.*;


 Presentation presentation = new Presentation();

ISmartArt smart = presentation.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicProcess);

smart.setReversed(true);

presentation.save("out.pptx", SaveFormat.Pptx);

```
### **Methods ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) đã được thêm vào**
Các phương thức com.aspose.slides.ISmartArtNode.getOrganizationChartLayout(), setOrganizationChartLayout(int) cho phép lấy hoặc đặt kiểu biểu đồ tổ chức liên kết với nút hiện tại.

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

smart.getNodes().get_Item(0).setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Property IShape.getConnectionSiteCount() đã được thêm vào**
Thuộc tính com.aspose.slides.getConnectionSiteCount() trả về số lượng các site kết nối trên hình dạng.

``` java
import com.aspose.slides.*;


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

|Enum com.aspose.slides.BevelColorMode |đã xóa, enum không được sử dụng |
| :- | :- |
|Method ThreeDFormatEffectiveData.getBevelColorMode() |đã xóa, thuộc tính không được sử dụng |
|Method com.aspose.slides.ChartSeriesGroup.getChart() |đã thêm |
|Inheritance of IParagraphFormatEffectiveData from ISlideComponent <br>Inheritance of IThreeDFormat from ISlideComponent |đã xóa |
|Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletChar() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletFont() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletHeight() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getBulletType() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStartWith() <br>Method com.aspose.slides.ParagraphFormatEffectiveData.getNumberedBulletStyle() |đã xóa vì lỗi thời |