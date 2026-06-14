---
title: Quản lý phông chữ trong bản trình chiếu bằng Java
linktitle: Quản lý phông chữ
type: docs
weight: 10
url: /vi/java/manage-fonts/
keywords:
- quản lý phông chữ
- thuộc tính phông chữ
- đoạn văn
- định dạng văn bản
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Kiểm soát phông chữ trong Java với Aspose.Slides: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình chiếu PPT, PPTX và ODP rõ ràng, an toàn về thương hiệu và nhất quán."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các thuộc tính phông chữ trong văn bản bản trình chiếu trực tiếp từ mã của mình. Bạn có thể truy cập văn bản trong các slide thông qua các hình dạng, khung văn bản, đoạn và phần, sau đó áp dụng định dạng cho văn bản đã chọn.

Bài viết này giải thích cách cấu hình các thuộc tính liên quan đến phông chữ cho văn bản hiện có trong một bản trình chiếu, bao gồm họ phông, kiểu đậm và nghiêng, căn chỉnh đoạn, và màu phông. Ngoài ra, nó cũng chỉ ra cách tạo hộp văn bản, thêm văn bản vào đó, và đặt các thuộc tính phông chữ như họ phông, đậm, nghiêng, gạch chân, kích thước phông và màu trước khi lưu kết quả dưới dạng tệp PPTX.

## **Quản lý các thuộc tính liên quan tới phông chữ**
{{% alert color="primary" %}} 

Bản trình chiếu thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách khác nhau, để làm nổi bật các phần và từ cụ thể hoặc để phù hợp với phong cách doanh nghiệp. Định dạng văn bản giúp người dùng thay đổi giao diện và cảm giác của nội dung bản trình chiếu. Bài viết này chỉ ra cách sử dụng Aspose.Slides for Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên các slide.

{{% /alert %}} 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) trong slide và ép kiểu chúng sang [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/).
1. Lấy [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) được cung cấp bởi [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/).
1. Căn đều đoạn văn.
1. Truy cập phần văn bản [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) của một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/).
1. Xác định phông chữ bằng cách sử dụng [FontData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontdata/) và đặt **Font** cho [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) của văn bản tương ứng.
   1. Đặt phông chữ thành đậm.
   1. Đặt phông chữ thành nghiêng.
1. Đặt màu phông chữ bằng cách sử dụng [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/).
1. Lưu bản trình chiếu đã chỉnh sửa thành tệp PPTX.

Triển khai các bước trên được đưa ra dưới đây. Nó nhận một bản trình chiếu không có định dạng và áp dụng các định dạng phông chữ cho một trong các slide. Các ảnh chụp màn hình sau đây cho thấy tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu và kiểu phông.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản tương tự với định dạng đã cập nhật**|

```java
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Truy cập một slide bằng vị trí của nó
	ISlide slide = pres.getSlides().get_Item(0);

	// Truy cập placeholder đầu tiên và thứ hai trong slide và ép kiểu thành AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Truy cập Paragraph đầu tiên
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Căn đều đoạn văn
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Truy cập phần đầu tiên
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Xác định phông chữ mới
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Gán phông chữ mới cho phần
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Đặt phông chữ thành Đậm
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Đặt phông chữ thành Nghiêng
	port1.getPortionFormat().setFontItalic(NullableBool.True);
	port2.getPortionFormat().setFontItalic(NullableBool.True);

	// Đặt màu phông chữ
	port1.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port1.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	port2.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port2.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.GREEN);

	// Lưu PPTX vào đĩa
	pres.save("WelcomeFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```

## **Đặt thuộc tính phông chữ cho văn bản**
{{% alert color="primary" %}} 

Như đã đề cập trong **Quản lý các thuộc tính liên quan tới phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) được dùng để chứa văn bản có cùng kiểu định dạng trong một đoạn. Bài viết này chỉ ra cách sử dụng Aspose.Slides for Java để tạo một hộp văn bản có một số văn bản và sau đó xác định một phông chữ cụ thể, cùng các thuộc tính khác của danh mục họ phông.

{{% /alert %}} 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) loại **Rectangle** vào slide.
1. Xóa kiểu tô màu liên kết với [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/).
1. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) của [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/).
1. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/).
1. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) liên kết với [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/).
1. Xác định phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/).
1. Đặt các thuộc tính phông chữ khác như đậm, nghiêng, gạch chân, màu và kích thước bằng cách sử dụng các thuộc tính tương ứng được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/).
1. Ghi bản trình chiếu đã chỉnh sửa dưới dạng tệp PPTX.

Triển khai các bước trên được đưa ra dưới đây.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được đặt bởi Aspose.Slides for Java**|

```java
// Tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
	// Lấy slide đầu tiên
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Thêm một AutoShape loại Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Xóa bất kỳ kiểu tô nào liên kết với AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Truy cập TextFrame liên kết với AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Truy cập Portion liên kết với TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Đặt phông chữ cho Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Đặt thuộc tính Đậm cho phông chữ
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Đặt thuộc tính Nghiêng cho phông chữ
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Đặt thuộc tính Gạch chân cho phông chữ
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Đặt kích thước (độ cao) cho phông chữ
	port.getPortionFormat().setFontHeight(25);
	
	// Đặt màu cho phông chữ
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Lưu bản trình chiếu vào đĩa
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```