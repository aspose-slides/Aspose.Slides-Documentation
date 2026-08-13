---
title: Thêm dấu bản quyền vào bản trình bày trên Android
linktitle: Dấu bản quyền
type: docs
weight: 40
url: /vi/androidjava/watermark/
keywords:
- dấu bản quyền
- dấu bản quyền văn bản
- dấu bản quyền hình ảnh
- thêm dấu bản quyền
- thay đổi dấu bản quyền
- xóa dấu bản quyền
- xoá dấu bản quyền
- thêm dấu bản quyền vào PPT
- thêm dấu bản quyền vào PPTX
- thêm dấu bản quyền vào ODP
- xóa dấu bản quyền khỏi PPT
- xóa dấu bản quyền khỏi PPTX
- xóa dấu bản quyền khỏi ODP
- xoá dấu bản quyền khỏi PPT
- xoá dấu bản quyền khỏi PPTX
- xoá dấu bản quyền khỏi ODP
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Quản lý watermark dạng văn bản và hình ảnh trong các bản trình bày PowerPoint và OpenDocument trên Android bằng Java để chỉ ra bản nháp, thông tin mật, và hơn nữa."
---
## **Giới thiệu**

**Watermark** trong một bản trình bày là một dấu chữ hoặc hình ảnh được dán lên một slide hoặc trên toàn bộ các slide. Thông thường, watermark được dùng để chỉ ra rằng bản trình bày là bản dự thảo (ví dụ, watermark "Draft"), chứa thông tin mật (ví dụ, watermark "Confidential"), chỉ định công ty nào sở hữu (ví dụ, watermark "Company Name"), xác định tác giả bản trình bày, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết bản trình bày không nên được sao chép. Watermark được sử dụng cả trong định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng file PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/android-java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và sửa đổi thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe/) hoặc lấp đầy một hình watermark bằng hình ảnh. `PictureFrame` triển khai giao diện [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), cho phép bạn sử dụng mọi cài đặt linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là một shape và các cài đặt của nó bị giới hạn, nó được bọc trong một đối tượng [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/).

Có hai cách áp dụng watermark: vào một slide duy nhất hoặc vào tất cả các slide của bản trình bày. Slide Master được dùng để áp dụng watermark vào tất cả các slide — watermark được thêm vào Slide Master, thiết kế toàn bộ ở đó và được áp dụng cho mọi slide mà không ảnh hưởng đến quyền sửa đổi watermark trên các slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hay chính shape chứa watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể bị khóa trên một slide bình thường hoặc trên Slide Master. Khi shape watermark bị khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình bày.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xoá, có thể tìm nó trong các shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, nằm phía trước, v.v. Chúng ta sẽ xem cách sử dụng các đặc điểm này trong các ví dụ dưới đây.

## **Watermark dạng Văn bản**

### **Thêm Watermark dạng Văn bản vào một Slide**

Để thêm watermark dạng văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bằng giao diện [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/). Kiểu này không kế thừa từ [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/), nên không có nhiều thuộc tính để định vị watermark một cách linh hoạt. Do đó, đối tượng [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) được bọc trong một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/). Để thêm nội dung watermark vào shape, sử dụng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) như dưới đây.

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
- [Cách sử dụng lớp TextFrame](/slides/vi/androidjava/text-formatting/)
{{% /alert %}}

### **Thêm Watermark dạng Văn bản vào toàn bộ Bản trình bày**

Nếu muốn thêm watermark dạng văn bản vào toàn bộ bản trình bày (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterslide/). Các bước còn lại giống như khi thêm watermark vào một slide — tạo một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/) và sau đó thêm watermark bằng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-).

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
- [Cách sử dụng Slide Master](/slides/vi/androidjava/slide-master/)
{{% /alert %}}

### **Đặt Độ trong suốt cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu nền và màu viền. Các dòng mã sau làm cho shape trong suốt.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.getFillFormat().setFillType(FillType.NoFill);
    watermarkShape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
} finally {
    presentation.dispose();
}
```

### **Đặt Phông chữ cho Watermark dạng Văn bản**

Bạn có thể thay đổi phông chữ của watermark dạng văn bản như dưới đây.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IPortionFormat textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
    textFormat.setLatinFont(new FontData("Arial"));
    textFormat.setFontHeight(50);
} finally {
    presentation.dispose();
}
```

### **Đặt Màu cho Văn bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã sau:

```java
import com.aspose.slides.*;
import java.awt.Color;

int alpha = 150, red = 200, green = 200, blue = 200;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    ITextFrame watermarkFrame = watermarkShape.addTextFrame("CONFIDENTIAL");

    IFillFormat fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
    fillFormat.setFillType(FillType.Solid);
    fillFormat.getSolidFillColor().setColor(new Color(red, green, blue, alpha));
} finally {
    presentation.dispose();
}
```

### **Căn Giữa Watermark dạng Văn bản**

Bạn có thể căn giữa watermark trên slide bằng cách thực hiện như sau:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

String watermarkText = "CONFIDENTIAL";

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    float watermarkWidth = 400;
    float watermarkHeight = 40;
    float watermarkX = ((float)slideSize.getWidth() - watermarkWidth) / 2;
    float watermarkY = ((float)slideSize.getHeight() - watermarkHeight) / 2;

    IAutoShape watermarkShape = slide.getShapes().addAutoShape(
            ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

    ITextFrame watermarkFrame = watermarkShape.addTextFrame(watermarkText);
} finally {
    presentation.dispose();
}
```

Hình dưới đây cho thấy kết quả cuối cùng.

![Chữ mờ](text_watermark.png)

## **Watermark dạng Hình ảnh**

### **Thêm Watermark dạng Hình ảnh vào Bản trình bày**

Để thêm watermark dạng hình ảnh vào một slide của bản trình bày, bạn có thể thực hiện các bước sau:

```java
import com.aspose.slides.*;
import java.io.FileInputStream;
import java.io.InputStream;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    InputStream imageStream = new FileInputStream("watermark.png");
    IPPImage image = presentation.getImages().addImage(imageStream);

    watermarkShape.getFillFormat().setFillType(FillType.Picture);
    watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
    watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
} finally {
    presentation.dispose();
}
```

### **Khóa Watermark khỏi việc chỉnh sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [IAutoShape.getAutoShapeLock](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape/#getAutoShapeLock--) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa, và nhiều hơn nữa:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    // Khóa shape watermark khỏi việc chỉnh sửa
    watermarkShape.getAutoShapeLock().setSelectLocked(true);
    watermarkShape.getAutoShapeLock().setSizeLocked(true);
    watermarkShape.getAutoShapeLock().setTextLocked(true);
    watermarkShape.getAutoShapeLock().setPositionLocked(true);
    watermarkShape.getAutoShapeLock().setGroupingLocked(true);
} finally {
    presentation.dispose();
}
```

### **Đưa Watermark lên phía trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được thiết lập qua phương thức [IShapeCollection.reorder](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-). Để làm điều này, bạn cần gọi phương thức này từ danh sách các slide của bản trình bày và truyền tham chiếu shape cùng với số thứ tự vào phương thức. Nhờ đó, bạn có thể đưa một shape lên phía trước hoặc gửi nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi bạn muốn đặt watermark ở phía trước nội dung bản trình bày:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    int shapeCount = slide.getShapes().size();
    slide.getShapes().reorder(shapeCount - 1, watermarkShape);
} finally {
    presentation.dispose();
}
```

### **Đặt Góc xoay cho Watermark**

Dưới đây là ví dụ mã để điều chỉnh góc xoay của watermark sao cho nó nằm chéo trên slide:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);
    Dimension2D slideSize = presentation.getSlideSize().getSize();

    double diagonalAngle = Math.atan((slideSize.getHeight() / slideSize.getWidth())) * 180 / Math.PI;

    watermarkShape.setRotation((float)diagonalAngle);
} finally {
    presentation.dispose();
}
```

### **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để sửa đổi hoặc xoá. Để đặt tên cho shape watermark, gán nó cho phương thức [IAutoShape.setName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#setName-java.lang.String-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape watermarkShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 40);

    watermarkShape.setName("watermark");
} finally {
    presentation.dispose();
}
```

### **Xoá Watermark**

Để xoá shape watermark, sử dụng phương thức [IAutoShape.getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/#getName--) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [IShapeCollection.remove](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-):

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("watermarked.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape[] slideShapes = slide.getShapes().toArray();
    for (IShape shape : slideShapes) {
        if ("watermark".equals(shape.getName()))
        {
            slide.getShapes().remove(shape);
        }
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi Thường gặp**

### Watermark là gì và tại sao tôi nên sử dụng nó?

Watermark là lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide, giúp bảo vệ tài sản trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản trình bày.

### Tôi có thể thêm watermark vào tất cả các slide trong một bản trình bày không?

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mọi slide của một bản trình bày. Bạn có thể lặp qua tất cả các slide và áp dụng cài đặt watermark cho từng slide.

### Làm sao tôi điều chỉnh độ trong suốt của watermark?

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách sửa đổi cài đặt nền ([getFillFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getFillFormat--)) của shape. Điều này giúp watermark vừa đủ rõ mà không gây xao lạc nội dung slide.

### Các định dạng hình ảnh nào được hỗ trợ cho watermark?

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và các định dạng khác.

### Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark dạng văn bản không?

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế bản trình bày và duy trì tính nhất quán thương hiệu.

### Làm sao tôi thay đổi vị trí hoặc hướng của watermark?

Bạn có thể thay đổi vị trí và hướng của watermark một cách lập trình bằng cách sửa đổi tọa độ, kích thước và thuộc tính xoay của shape.