---
title: Quản lý phông chữ trong bản trình bày bằng Java
linktitle: Quản lý Phông chữ
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
- bản trình bày
- Java
- Aspose.Slides
description: "Kiểm soát phông chữ trong Java với Aspose.Slides: nhúng, thay thế và tải phông chữ tùy chỉnh để giữ cho các bản trình bày PPT, PPTX và ODP rõ ràng, an toàn về thương hiệu và nhất quán."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các thuộc tính phông chữ trong văn bản bản trình bày trực tiếp từ mã của mình. Bạn có thể truy cập văn bản trong các slide thông qua hình dạng, khung văn bản, đoạn văn và các phần, sau đó áp dụng định dạng cho văn bản đã chọn.

Bài viết này giải thích cách cấu hình các thuộc tính liên quan đến phông chữ cho văn bản đã tồn tại trong một bản trình bày, bao gồm họ phông chữ, kiểu chữ in đậm và in nghiêng, căn chỉnh đoạn văn và màu phông chữ. Nó cũng chỉ ra cách tạo một hộp văn bản, thêm văn bản vào và đặt các thuộc tính phông chữ như họ phông, in đậm, in nghiêng, gạch chân, kích thước phông và màu trước khi lưu kết quả dưới dạng tệp PPTX.

## **Quản lý các Thuộc tính Liên quan đến Phông chữ**
{{% alert color="info" %}} 

Bản trình bày thường chứa cả văn bản và hình ảnh. Văn bản có thể được định dạng theo nhiều cách khác nhau, hoặc để làm nổi bật các phần và từ cụ thể, hoặc để phù hợp với phong cách công ty. Định dạng văn bản giúp người dùng thay đổi giao diện nội dung bản trình bày. Bài viết này cho thấy cách sử dụng Aspose.Slides for Java để cấu hình các thuộc tính phông chữ của các đoạn văn bản trên các slide.

{{% /alert %}} 

Để quản lý các thuộc tính phông chữ của một đoạn văn bằng Aspose.Slides for Java:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
2. Lấy tham chiếu slide bằng cách sử dụng chỉ số của nó.
3. Truy cập các hình dạng [Placeholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/placeholder/) trong slide và ép kiểu chúng thành [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) .
4. Lấy [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) từ [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) được cung cấp bởi [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) .
5. Căn chỉnh đoạn văn.
6. Truy cập phần văn bản [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) của một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/paragraph/) .
7. Định nghĩa phông chữ bằng [FontData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontdata/) và đặt **Font** cho phần văn bản [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) tương ứng.
   1. Đặt phông chữ thành in đậm.
   1. Đặt phông chữ thành in nghiêng.
8. Đặt màu phông chữ bằng [FillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fillformat/) được cung cấp bởi đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) .
9. Lưu bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc thực hiện các bước trên được minh họa dưới đây. Nó nhận một bản trình bày chưa được định dạng và định dạng phông chữ trên một trong các slide. Các ảnh chụp màn hình sau cho thấy tệp đầu vào và cách các đoạn mã thay đổi nó. Mã thay đổi phông chữ, màu sắc và kiểu phông.

|![todo:image_alt_text](http://i.imgur.com/rqpPgJn.jpg)|
| :- |
|**Hình: Văn bản trong tệp đầu vào**|


|![todo:image_alt_text](http://i.imgur.com/rY27Lt9.png)|
| :- |
|**Hình: Văn bản giống nhau với định dạng đã cập nhật**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một đối tượng Presentation đại diện cho tệp PPTX
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

	// Canh lề đoạn văn
	para2.getParagraphFormat().setAlignment(TextAlignment.JustifyLow);

	// Truy cập phần (portion) đầu tiên
	IPortion port1 = para1.getPortions().get_Item(0);
	IPortion port2 = para2.getPortions().get_Item(0);

	// Xác định phông chữ mới
	FontData fd1 = new FontData("Elephant");
	FontData fd2 = new FontData("Castellar");

	// Gán phông chữ mới cho phần
	port1.getPortionFormat().setLatinFont(fd1);
	port2.getPortionFormat().setLatinFont(fd2);

	// Đặt phông chữ thành In đậm
	port1.getPortionFormat().setFontBold(NullableBool.True);
	port2.getPortionFormat().setFontBold(NullableBool.True);

	// Đặt phông chữ thành In nghiêng
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

Như đã đề cập trong **Quản lý các Thuộc tính Liên quan đến Phông chữ**, một [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) được dùng để chứa văn bản có cùng kiểu định dạng trong một đoạn văn. Bài viết này cho thấy cách sử dụng Aspose.Slides for Java để tạo một hộp văn bản với một số văn bản và sau đó định nghĩa một phông chữ cụ thể, cùng các thuộc tính khác của danh mục họ phông chữ.

{{% /alert %}} 

Để tạo một hộp văn bản và đặt các thuộc tính phông chữ cho văn bản trong đó:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
2. Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó.
3. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) loại **Rectangle** vào slide.
4. Xóa kiểu nền được gắn liền với [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) .
5. Truy cập [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) của [AutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/autoshape/) .
6. Thêm một số văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) .
7. Truy cập đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) liên kết với [TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/textframe/) .
8. Định nghĩa phông chữ sẽ được sử dụng cho [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) .
9. Đặt các thuộc tính phông chữ khác như in đậm, in nghiêng, gạch chân, màu và chiều cao thông qua các thuộc tính tương ứng của đối tượng [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) .
10. Ghi bản trình bày đã chỉnh sửa thành tệp PPTX.

Việc thực hiện các bước trên được minh họa dưới đây.

|![todo:image_alt_text](http://i.imgur.com/n5r12dS.jpg)|
| :- |
|**Hình: Văn bản với một số thuộc tính phông chữ được đặt bằng Aspose.Slides for Java**|

```java
import com.aspose.slides.*;
import java.awt.Color;

// Tạo một đối tượng Presentation đại diện cho tệp PPTX
Presentation pres = new Presentation();
try {
	// Lấy slide đầu tiên
	ISlide sld = pres.getSlides().get_Item(0);
	
	// Thêm một AutoShape loại Rectangle
	IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 200, 50);
	
	// Xóa bất kỳ kiểu nền nào liên quan đến AutoShape
	ashp.getFillFormat().setFillType(FillType.NoFill);
	
	// Truy cập TextFrame liên quan đến AutoShape
	ITextFrame tf = ashp.getTextFrame();
	tf.setText("Aspose TextBox");
	
	// Truy cập Portion liên quan đến TextFrame
	IPortion port = tf.getParagraphs().get_Item(0).getPortions().get_Item(0);
	
	// Đặt phông chữ cho Portion
	port.getPortionFormat().setLatinFont(new FontData("Times New Roman"));
	
	// Đặt thuộc tính In đậm cho phông chữ
	port.getPortionFormat().setFontBold(NullableBool.True);
	
	// Đặt thuộc tính In nghiêng cho phông chữ
	port.getPortionFormat().setFontItalic(NullableBool.True);
	
	// Đặt thuộc tính Gạch chân cho phông chữ
	port.getPortionFormat().setFontUnderline(TextUnderlineType.Single);
	
	// Đặt chiều cao của phông chữ
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