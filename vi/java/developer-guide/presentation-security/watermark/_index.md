---
title: Thêm Dấu Nước vào Bản Trình Chiếu trong Java
linktitle: Dấu Nước
type: docs
weight: 40
url: /vi/java/watermark/
keywords:
- dấu nước
- dấu nước văn bản
- dấu nước hình ảnh
- thêm dấu nước
- thay đổi dấu nước
- xóa dấu nước
- xoá dấu nước
- thêm dấu nước vào PPT
- thêm dấu nước vào PPTX
- thêm dấu nước vào ODP
- xóa dấu nước khỏi PPT
- xóa dấu nước khỏi PPTX
- xóa dấu nước khỏi ODP
- xoá dấu nước khỏi PPT
- xoá dấu nước khỏi PPTX
- xoá dấu nước khỏi ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Quản lý các dấu nước văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument bằng Java để chỉ ra bản nháp, thông tin bảo mật, bản quyền và nhiều hơn nữa."
---
## **Giới thiệu**

**Watermark** trong một bản trình chiếu là một dấu văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, watermark được dùng để chỉ ra rằng bản trình chiếu là bản nháp (ví dụ, watermark “Draft”), chứa thông tin mật (ví dụ, watermark “Confidential”), chỉ định công ty sở hữu (ví dụ, watermark “Company Name”), xác định tác giả của bản trình chiếu, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết bản trình chiếu không nên được sao chép. Watermark được sử dụng trong cả hai định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và tùy chỉnh thiết kế cùng hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/) hoặc làm đầy một shape watermark bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), cho phép bạn dùng tất cả các thiết lập linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là shape và các thiết lập của nó hạn chế, nên nó được bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/).

Có hai cách áp dụng watermark: cho một slide duy nhất hoặc cho tất cả các slide trong bản trình chiếu. Slide Master được dùng để áp dụng watermark cho toàn bộ slide — watermark được thêm vào Slide Master, thiết kế đầy đủ ở đó, và được áp dụng cho mọi slide mà không ảnh hưởng đến quyền sửa đổi watermark trên các slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên slide bình thường hoặc trên Slide Master. Khi shape watermark bị khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xóa nó, bạn có thể tìm thấy nó trong các shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung của watermark, chẳng hạn như căn giữa, xoay, vị trí phía trước, v.v. Chúng ta sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Watermark Văn bản**

### **Thêm Watermark Văn bản vào Slide**

Để thêm watermark dạng văn bản trong PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được đại diện bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), vốn có một tập rộng các thuộc tính để định vị watermark một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) được bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) như dưới đây.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách sử dụng lớp TextFrame](/slides/vi/java/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn bản vào Toàn Bộ Bản Trình Chiếu**

Nếu bạn muốn thêm watermark dạng văn bản cho toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/). Phần còn lại của logic tương tự như khi thêm watermark vào một slide đơn — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và sau đó thêm watermark vào nó bằng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách sử dụng Slide Master](/slides/vi/java/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suất cho Shape Watermark**

Mặc định, shape hình chữ nhật được thiết kế với màu nền và màu viền. Các dòng mã sau làm cho shape trong suốt.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Đặt Phông Chữ cho Watermark Văn Bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Đặt Màu Cho Văn Bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã sau:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
```

### **Căn Giữa Watermark Văn Bản**

Bạn có thể căn giữa watermark trên một slide, và để làm điều đó, thực hiện như sau:

```java
Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Hình ảnh bên dưới cho thấy kết quả cuối cùng.

![Watermark văn bản](text_watermark.png)

## **Watermark Hình Ảnh**

### **Thêm Watermark Hình Ảnh vào Bản Trình Chiếu**

Để thêm watermark hình ảnh vào một slide trong bản trình chiếu, bạn có thể thực hiện các bước sau:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Khóa Watermark Khỏi Việc Chỉnh Sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa và nhiều hơn nữa:

```java
// Khóa shape watermark khỏi việc chỉnh sửa
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Đưa Watermark Lên Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương thức [IShapeCollection.reorder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . Để làm vậy, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền tham chiếu shape cùng số thứ tự vào phương thức. Cách này cho phép đưa một shape lên phía trước hoặc đưa nó ra phía sau slide. Tính năng này đặc biệt hữu ích nếu bạn muốn đặt watermark ở phía trước bản trình chiếu:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Đặt Góc Xoay cho Watermark**

Dưới đây là một ví dụ mã về cách điều chỉnh góc xoay của watermark sao cho nó nằm chéo qua slide:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape watermark, gán nó cho phương thức [IAutoShape.setName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [IAutoShape.getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection.remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Câu Hỏi Thường Gặp**

**Watermark là gì và tại sao tôi nên sử dụng nó?**

Watermark là một lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide, giúp bảo vệ tài sản trí tuệ, tăng nhận diện thương hiệu hoặc ngăn việc sử dụng trái phép bản trình chiếu.

**Tôi có thể thêm watermark vào tất cả các slide trong bản trình chiếu không?**

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mọi slide trong bản trình chiếu. Bạn có thể lặp qua tất cả các slide và áp dụng các cài đặt watermark cho từng slide.

**Làm sao tôi điều chỉnh độ trong suốt của watermark?**

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách sửa đổi các thiết lập fill ([getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getFillFormat--)) của shape. Điều này giúp watermark trở nên nhẹ nhàng và không gây phân tâm cho nội dung slide.

**Những định dạng hình ảnh nào được hỗ trợ cho watermark?**

Aspose.Slides hỗ trợ đa dạng định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và nhiều định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế của bản trình chiếu và duy trì sự nhất quán thương hiệu.

**Làm thế nào để thay đổi vị trí hoặc hướng của watermark?**

Bạn có thể thay đổi vị trí và hướng của watermark một cách lập trình bằng cách sửa đổi tọa độ, kích thước và các thuộc tính xoay của shape.