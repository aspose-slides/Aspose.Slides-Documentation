---
title: Quản lý phông chữ trong bản trình bày trên Android
linktitle: Quản lý phông chữ
type: docs
weight: 10
url: /vi/androidjava/manage-fonts/
keywords:
- quản lý phông chữ
- thuộc tính phông chữ
- đoạn văn
- định dạng văn bản
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Kiểm soát phông chữ trong Java với Aspose.Slides cho Android: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình bày PPT, PPTX và ODP rõ ràng, an toàn với thương hiệu và nhất quán."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các thuộc tính phông chữ trong văn bản bản trình bày trực tiếp từ mã của mình. Bạn có thể truy cập văn bản trong các slide thông qua các hình dạng, khung văn bản, đoạn và phần, rồi áp dụng định dạng cho văn bản đã chọn.

Bài viết này giải thích cách cấu hình các thuộc tính liên quan đến phông chữ cho văn bản hiện có trong bản trình bày, bao gồm họ phông chữ, kiểu chữ in đậm và nghiêng, căn chỉnh đoạn và màu phông chữ. Nó cũng chỉ ra cách tạo một hộp văn bản, thêm văn bản vào đó và đặt các thuộc tính phông chữ như họ phông chữ, in đậm, nghiêng, gạch dưới, kích thước và màu sắc trước khi lưu kết quả dưới dạng tệp PPTX.

## **Quản lý các Thuộc tính Liên quan đến Phông chữ**
{{% alert color="info" %}} 

Bản trình bày thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách, để làm nổi bật các phần và từ cụ thể hoặc để phù hợp với phong cách doanh nghiệp. Định dạng văn bản giúp người dùng thay đổi giao diện và cảm giác của nội dung bản trình bày. Bài viết này chỉ ra cách sử dụng Aspose.Slides cho Android qua Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên slide.

{{% /alert %}} 

Để quản lý các thuộc tính phông chữ của một đoạn văn bằng Aspose.Slides cho Android qua Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/placeholder/) trong slide và ép kiểu chúng thành [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/).
1. Lấy [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/) được cung cấp bởi [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/).
1. Căn đều đoạn văn.
1. Truy cập phần văn bản [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) của một [Paragraph](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/paragraph/).
1. Định nghĩa phông chữ bằng [FontData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fontdata/) và đặt **Font** cho phần văn bản [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) tương ứng.
   1. Đặt phông chữ thành in đậm.
   1. Đặt phông chữ thành nghiêng.
1. Đặt màu phông chữ bằng [FillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/fillformat/) được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/).
1. Lưu bản trình bày đã sửa đổi thành tệp PPTX.

Việc triển khai các bước trên được đưa ra bên dưới. Nó lấy một bản trình bày chưa được định dạng và định dạng các phông chữ trên một trong các slide. Các ảnh chụp màn hình sau đây hiển thị tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu sắc và kiểu phông chữ.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|

|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản tương tự với định dạng được cập nhật**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation("FontProperties.pptx");
try {
	// Truy cập slide bằng vị trí của nó
	ISlide slide = pres.getSlides().get_Item(0);

	// Truy cập placeholder thứ nhất và thứ hai trong slide và ép kiểu thành AutoShape
	ITextFrame tf1 = ((IAutoShape) slide.getShapes().get_Item(0)).getTextFrame();
	ITextFrame tf2 = ((IAutoShape) slide.getShapes().get_Item(1)).getTextFrame();

	// Truy cập Paragraph đầu tiên
	IParagraph para1 = tf1.getParagraphs().get_Item(0);
	IParagraph para2 = tf2.getParagraphs().get_Item(0);

	// Căn đều đoạn văn
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Truy cập phần văn bản đầu tiên
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Xác định phông chữ mới
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Gán phông chữ mới cho phần văn bản
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Đặt phông chữ in đậm
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Đặt phông chữ nghiêng
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

## **Đặt Thuộc tính Phông chữ cho Văn bản**
{{% alert color="info" %}} 

Như đã đề cập trong **Quản lý các Thuộc tính Liên quan đến Phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) được dùng để giữ văn bản có cùng kiểu định dạng trong một đoạn. Bài viết này chỉ ra cách sử dụng Aspose.Slides cho Android qua Java để tạo một hộp văn bản với một số văn bản và sau đó xác định một phông chữ cụ thể, cùng các thuộc tính khác của danh mục họ phông chữ.

{{% /alert %}} 

Để tạo một hộp văn bản và đặt thuộc tính phông chữ cho văn bản trong đó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ mục của nó.
1. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/) có kiểu **Rectangle** vào slide.
1. Xóa kiểu nền liên quan đến [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/).
1. Truy cập [TextFrame] của [AutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/autoshape/).
1. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/).
1. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/) liên kết với [TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/textframe/).
1. Định nghĩa phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/).
1. Đặt các thuộc tính phông chữ khác như in đậm, nghiêng, gạch dưới, màu và chiều cao bằng các thuộc tính tương ứng của đối tượng [Portion](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portion/).
1. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc triển khai các bước trên được đưa ra bên dưới.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được đặt bởi Aspose.Slides cho Android qua Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
	// Lấy slide đầu tiên
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Thêm một AutoShape kiểu Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Xóa bất kỳ kiểu nền nào liên quan đến AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Truy cập TextFrame liên kết với AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Truy cập Portion liên kết với TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Đặt phông chữ cho Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Đặt thuộc tính in đậm cho phông chữ
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Đặt thuộc tính nghiêng cho phông chữ
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Đặt thuộc tính gạch dưới cho phông chữ
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Đặt kích thước chiều cao cho phông chữ
	port.getPortionFormat().setFontHeight(25);
	
	// Đặt màu cho phông chữ
	port.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
	port.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);
	
	// Lưu bản trình bày vào đĩa
	pres.save("pptxFont.pptx", SaveFormat.Pptx);
} finally {
	if (pres != null) pres.dispose();
}
```