---
title: Thêm Watermark vào Bản Trình Chiếu trên Android
linktitle: Đánh Dấu Nước
type: docs
weight: 40
url: /vi/androidjava/watermark/
keywords:
- đánh dấu nước
- đánh dấu nước văn bản
- đánh dấu nước hình ảnh
- thêm watermark
- thay đổi watermark
- xóa watermark
- xoá watermark
- thêm watermark vào PPT
- thêm watermark vào PPTX
- thêm watermark vào ODP
- xóa watermark khỏi PPT
- xóa watermark khỏi PPTX
- xóa watermark khỏi ODP
- xoá watermark từ PPT
- xoá watermark từ PPTX
- xoá watermark từ ODP
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý các watermark dạng văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument trên Android bằng Java để chỉ ra bản nháp, thông tin mật, và hơn nữa."
---
## **Giới thiệu**

**Một watermark** trong bản trình chiếu là một dấu văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên tất cả các slide của bản trình chiếu. Thông thường, watermark được dùng để chỉ ra rằng bản trình chiếu là bản nháp (ví dụ, watermark “Draft”), chứa thông tin mật (ví dụ, watermark “Confidential”), xác định công ty sở hữu (ví dụ, watermark “Tên Công Ty”), nhận dạng tác giả của bản trình chiếu, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết rằng bản trình chiếu không được sao chép. Watermark được sử dụng cả trong định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/android-java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) hoặc lấp đầy một shape watermark bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), cho phép bạn sử dụng tất cả các thiết lập linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là một shape và các thiết lập của nó bị giới hạn, nên nó được bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) .

Có hai cách để áp dụng watermark: cho một slide duy nhất hoặc cho tất cả các slide của bản trình chiếu. Slide Master được sử dụng để áp dụng watermark cho toàn bộ slide — watermark được thêm vào Slide Master, thiết kế hoàn chỉnh tại đó và áp dụng cho mọi slide mà không ảnh hưởng tới quyền sửa đổi watermark trên các slide riêng lẻ.

Watermark thường được coi là không cho phép người dùng khác chỉnh sửa. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể bị khóa trên slide thường hoặc trên Slide Master. Khi shape watermark bị khóa trên Slide Master, nó sẽ bị khóa trên mọi slide của bản trình chiếu.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xoá, có thể tìm thấy nó trong các shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, vị trí phía trước, v.v. Chúng ta sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Watermark Văn Bản**

### **Thêm Watermark Văn Bản vào Slide**

Để thêm watermark văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), vốn có một tập hợp rộng các thuộc tính để định vị watermark một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) được bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) như dưới đây.

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Lớp TextFrame](/slides/vi/androidjava/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn Bản vào Toàn Bộ Bản Trình Chiếu**

Nếu bạn muốn thêm watermark văn bản vào toàn bộ bản trình chiếu (tức là tất cả các slide cùng lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterslide/). Phần còn lại của luồng logic giống như khi thêm watermark vào một slide đơn — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) và sau đó thêm watermark vào nó bằng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Slide Master](/slides/vi/androidjava/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suốt Cho Shape Watermark**

Mặc định, shape hình chữ nhật được tạo kiểu với màu nền và màu viền. Các dòng mã sau làm cho shape trong suốt.

```java
watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
```

### **Đặt Phông Chữ Cho Watermark Văn Bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```java
IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Đặt Màu Văn Bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã sau:

```java
int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(Color.argb(alpha, red, green, blue));
```

### **Căn Giữa Watermark Văn Bản**

Bạn có thể căn giữa watermark trên slide, và để làm điều đó, hãy thực hiện các bước sau:

```java
SizeF slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Hình ảnh dưới đây cho thấy kết quả cuối cùng.

![The text watermark](text_watermark.png)

## **Watermark Hình Ảnh**

### **Thêm Watermark Hình Ảnh vào Bản Trình Chiếu**

Để thêm watermark hình ảnh vào một slide bản trình chiếu, bạn có thể thực hiện như sau:

```java
InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
```

### **Khóa Watermark Khỏi Việc Chỉnh Sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa, và nhiều hơn nữa:

```java
// Khóa shape watermark khỏi việc chỉnh sửa
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);
```

### **Đưa Watermark Lên Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương thức [IShapeCollection.reorder](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . Để làm điều này, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền tham chiếu shape cùng số thứ tự của nó vào phương thức. Nhờ đó, có thể đưa một shape lên phía trước hoặc đưa nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi bạn muốn đặt watermark phía trước nội dung bản trình chiếu:

```java
int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Đặt Góc Xoay Cho Watermark**

Dưới đây là ví dụ mã về cách điều chỉnh góc xoay của watermark sao cho nó nằm chéo qua slide:

```java
double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);
```

### **Đặt Tên Cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập vào nó trong tương lai để chỉnh sửa hoặc xoá. Để đặt tên cho shape watermark, gán nó cho phương thức [IAutoShape.setName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
watermarkShape.setName("watermark");
```

### **Xoá Watermark**

Để xoá shape watermark, sử dụng phương thức [IAutoShape.getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection.remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

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

Watermark là một lớp phủ văn bản hoặc hình ảnh áp dụng lên các slide, giúp bảo vệ sở hữu trí tuệ, nâng cao nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản trình chiếu.

**Tôi có thể thêm watermark vào tất cả các slide trong bản trình chiếu không?**

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mỗi slide của bản trình chiếu. Bạn có thể lặp qua tất cả các slide và áp dụng cài đặt watermark riêng lẻ.

**Làm thế nào để điều chỉnh độ trong suốt của watermark?**

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách sửa đổi cài đặt nền ([getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getFillFormat--)) của shape. Điều này giúp watermark mờ nhạt và không gây phân tâm cho nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho watermark?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG, và các định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế bản trình chiếu và duy trì tính nhất quán thương hiệu.

**Làm sao để thay đổi vị trí hoặc hướng của watermark?**

Bạn có thể điều chỉnh vị trí và hướng của watermark bằng cách lập trình thay đổi tọa độ, kích thước và thuộc tính xoay của shape.