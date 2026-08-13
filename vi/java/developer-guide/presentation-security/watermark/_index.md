---
title: Thêm Watermark vào Bài thuyết trình trong Java
linktitle: Watermark
type: docs
weight: 40
url: /vi/java/watermark/
keywords:
- đánh dấu
- watermark văn bản
- watermark hình ảnh
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
- xoá watermark khỏi PPT
- xoá watermark khỏi PPTX
- xoá watermark khỏi ODP
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Quản lý watermark văn bản và hình ảnh trong các bản trình chiếu PowerPoint và OpenDocument bằng Java để chỉ ra bản nháp, thông tin bí mật, bản quyền và hơn nữa."
---
## **Giới thiệu**

**Một watermark** trong bản trình chiếu là một tem văn bản hoặc hình ảnh được sử dụng trên một slide hoặc trên toàn bộ các slide của bản trình chiếu. Thông thường, watermark được dùng để chỉ ra rằng bản trình chiếu là bản nháp (ví dụ, watermark "Draft"), chứa thông tin bí mật (ví dụ, watermark "Confidential"), chỉ định công ty sở hữu (ví dụ, watermark "Company Name"), xác định tác giả của bản trình chiếu, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết bản trình chiếu không được sao chép. Watermark được sử dụng trong cả định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe/) hoặc lấp đầy một shape watermark bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) , cho phép bạn sử dụng tất cả các thiết lập linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là một shape và các thiết lập của nó hạn chế, nên nó được đóng gói trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) .

Có hai cách để áp dụng watermark: cho một slide riêng lẻ hoặc cho tất cả các slide của bản trình chiếu. Slide Master được sử dụng để áp dụng watermark cho toàn bộ các slide — watermark được thêm vào Slide Master, thiết kế đầy đủ ở đó và được áp dụng cho mọi slide mà không ảnh hưởng đến quyền chỉnh sửa watermark trên các slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc chính shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên slide thường hoặc trên Slide Master. Khi shape watermark được khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình chiếu.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xóa nó, bạn có thể tìm thấy trong các shape của slide theo tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có những đặc điểm chung trong watermark, như căn giữa, xoay, vị trí phía trước, v.v. Chúng tôi sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Watermark Văn bản**

### **Thêm Watermark Văn bản vào Slide**

Để thêm watermark dạng văn bản trong PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bởi giao diện [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), cái mà có một bộ thuộc tính rộng để định vị watermark một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) được đóng gói trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) như dưới đây.

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Xem thêm" %}} 
- [Cách sử dụng lớp TextFrame](/slides/vi/java/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn bản vào Bản trình chiếu**

Nếu bạn muốn thêm watermark dạng văn bản vào toàn bộ bản trình chiếu (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/masterslide/). Phần còn lại của logic tương tự như khi thêm watermark vào một slide riêng — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/) và sau đó thêm watermark vào nó bằng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

```java
import com.aspose.slides.*;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
IMasterSlide masterSlide = presentation.getMasters().get_Item(0);

IAutoShape watermarkShape = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="info" title="Xem thêm" %}} 
- [Cách sử dụng Slide Master](/slides/vi/java/slide-master/)
{{% /alert %}}

### **Đặt Độ trong suốt cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu nền và màu viền. Các dòng mã sau làm cho shape trở nên trong suốt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.getFillFormat().setFillType(FillType.NoFill);
watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

presentation.dispose();
```

### **Đặt Phông chữ cho Watermark Văn bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new FontData("Arial"));
textFormat.setFontHeight(50);

presentation.dispose();
```

### **Đặt Màu cho Văn bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã này:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

int alpha = 150, red = 200, green = 200, blue = 200;

IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(FillType.Solid);
fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));

presentation.dispose();
```

### **Cân giữa Watermark Văn bản**

Có thể căn giữa watermark trên một slide, và để làm điều đó, bạn có thể thực hiện như sau:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

Dimension2D slideSize = presentation.getSlideSize().getSize();

float watermarkWidth = 400;
float watermarkHeight = 40;
float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

IAutoShape watermarkShape = slide.getShapes().addAutoShape(
        ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

Hình dưới đây cho thấy kết quả cuối cùng.

![Watermark văn bản](text_watermark.png)

## **Watermark Hình ảnh**

### **Thêm Watermark Hình ảnh vào Bản trình chiếu**

Để thêm watermark hình ảnh vào một slide của bản trình chiếu, bạn có thể làm như sau:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

InputStream imageStream = new FileInputStream("watermark.png");
IPPImage image = presentation.getImages().addImage(imageStream);

watermarkShape.getFillFormat().setFillType(FillType.Picture);
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);

presentation.dispose();
```

### **Khóa Watermark để Không thể chỉnh sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape/#getAutoShapeLock--) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc chọn, thay đổi kích thước, di chuyển vị trí, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa, và nhiều hơn nữa:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

// Khóa shape watermark khỏi việc sửa đổi
watermarkShape.getAutoShapeLock().setSelectLocked(true);
watermarkShape.getAutoShapeLock().setSizeLocked(true);
watermarkShape.getAutoShapeLock().setTextLocked(true);
watermarkShape.getAutoShapeLock().setPositionLocked(true);
watermarkShape.getAutoShapeLock().setGroupingLocked(true);

presentation.dispose();
```

### **Đưa Watermark lên phía trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương thức [IShapeCollection.reorder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) . Để thực hiện, bạn cần gọi phương thức này từ danh sách các slide của bản trình chiếu và truyền tham chiếu shape cùng số thứ tự của nó vào phương thức. Cách này cho phép đưa một shape lên phía trước hoặc xuống phía sau slide. Tính năng này đặc biệt hữu ích nếu bạn cần đặt watermark ở trước nội dung của bản trình chiếu:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

int shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);

presentation.dispose();
```

### **Đặt Góc xoay cho Watermark**

Dưới đây là ví dụ mã về cách điều chỉnh góc xoay của watermark sao cho nó nằm chéo trên slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

Dimension2D slideSize = presentation.getSlideSize().getSize();

double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

watermarkShape.setRotation((float)diagonalAngle);

presentation.dispose();
```

### **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để chỉnh sửa hoặc xóa. Để đặt tên cho shape watermark, gọi phương thức [IAutoShape.setName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);
IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

watermarkShape.setName("watermark");

presentation.dispose();
```

### **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [IAutoShape.getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getName--) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection.remove](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

IShape[] slideShapes = slide.getShapes().toArray();
for (IShape shape : slideShapes) {
    if ("watermark".equals(shape.getName()))
    {
        slide.getShapes().remove(shape);
    }
}

presentation.dispose();
```

## **Câu hỏi thường gặp**

### Watermark là gì và tại sao tôi nên sử dụng nó?

Watermark là lớp phủ văn bản hoặc hình ảnh áp dụng lên các slide, giúp bảo vệ bản quyền sở hữu trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn chặn việc sử dụng trái phép các bản trình chiếu.

### Tôi có thể thêm watermark vào mọi slide trong bản trình chiếu không?

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mỗi slide trong một bản trình chiếu. Bạn có thể duyệt qua tất cả các slide và áp dụng cài đặt watermark một cách riêng lẻ.

### Làm thế nào tôi có thể điều chỉnh độ trong suốt của watermark?

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách sửa đổi cài đặt fill ([getFillFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getFillFormat--)) của shape. Điều này giúp watermark trở nên nhẹ nhàng và không gây mất tập trung vào nội dung slide.

### Các định dạng hình ảnh nào được hỗ trợ cho watermark?

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và các định dạng khác.

### Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế bản trình chiếu và duy trì tính nhất quán thương hiệu.

### Làm sao tôi thay đổi vị trí hoặc hướng của watermark?

Bạn có thể thay đổi vị trí và hướng của watermark một cách lập trình bằng cách điều chỉnh tọa độ, kích thước và thuộc tính xoay của shape.