---
title: Thêm Đánh dấu vào Bản thuyết trình trong JavaScript
linktitle: Đánh dấu
type: docs
weight: 40
url: /vi/nodejs-java/watermark/
keywords:
- đánh dấu
- đánh dấu văn bản
- đánh dấu hình ảnh
- thêm đánh dấu
- thay đổi đánh dấu
- xóa đánh dấu
- xoá đánh dấu
- thêm đánh dấu vào PPT
- thêm đánh dấu vào PPTX
- thêm đánh dấu vào ODP
- xóa đánh dấu khỏi PPT
- xóa đánh dấu khỏi PPTX
- xóa đánh dấu khỏi ODP
- xoá đánh dấu khỏi PPT
- xoá đánh dấu khỏi PPTX
- xoá đánh dấu khỏi ODP
- PowerPoint
- OpenDocument
- bản thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các watermark văn bản và hình ảnh trong các bản thuyết trình PowerPoint và OpenDocument trên Node.js để chỉ ra bản nháp, thông tin mật, bản quyền và hơn thế nữa."
---
## **Giới thiệu**

**Một watermark** trong bản thuyết trình là một dấu văn bản hoặc hình ảnh được áp dụng trên một slide hoặc trên toàn bộ các slide của bản thuyết trình. Thông thường, watermark được dùng để chỉ ra rằng bản thuyết trình là bản nháp (ví dụ: watermark “Draft”), chứa thông tin mật (ví dụ: watermark “Confidential”), chỉ định công ty sở hữu (ví dụ: watermark “Company Name”), xác định tác giả bản thuyết trình, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết bản thuyết trình không nên được sao chép. Watermark được sử dụng trong cả định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/nodejs-java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế cũng như hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng kiểu [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe/) hoặc lấp đầy một shape watermark bằng hình ảnh. `PictureFrame` triển khai kiểu [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), cho phép bạn sử dụng mọi cài đặt linh hoạt của đối tượng shape. Vì `TextFrame` không phải là shape và các cài đặt của nó có hạn, nên nó được bao bọc trong một đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/).

Có hai cách áp dụng watermark: cho một slide duy nhất hoặc cho tất cả các slide của bản thuyết trình. Slide Master được dùng để áp dụng watermark cho mọi slide — watermark được thêm vào Slide Master, thiết kế hoàn chỉnh tại đó và sau đó được áp dụng cho mọi slide mà không ảnh hưởng đến quyền chỉnh sửa watermark trên từng slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên slide bình thường hoặc trên Slide Master. Khi shape watermark bị khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản thuyết trình.

Bạn có thể đặt tên cho watermark để trong tương lai, nếu muốn xóa nó, có thể tìm thấy shape theo tên trong các slide.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung như căn giữa, xoay, đặt ở vị trí phía trước, v.v. Chúng ta sẽ xem cách sử dụng chúng trong các ví dụ dưới đây.

## **Watermark dạng Văn bản**

### **Thêm Watermark Văn bản vào Slide**
Để thêm watermark văn bản vào PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bởi kiểu [**TextFrame**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame). Kiểu này không kế thừa từ [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape), vì vậy nó được bao bọc trong một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape). Để thêm văn bản watermark vào shape, sử dụng phương thức [**addTextFrame**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) và truyền vào văn bản watermark:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let slide = presentation.getSlides().get_Item(0);

let watermarkShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- Cách sử dụng [TextFrame](/slides/vi/nodejs-java/text-formatting/).
{{% /alert %}}

### **Thêm Watermark Văn bản vào Toàn bộ Bản thuyết trình**

Nếu muốn thêm watermark văn bản cho toàn bộ bản thuyết trình (tức là tất cả các slide cùng một lúc), hãy thêm nó vào [**MasterSlide**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MasterSlide). Phần logic còn lại giống như khi thêm watermark vào một slide đơn — tạo một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape) rồi sử dụng phương thức [**addTextFrame**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-) để thêm watermark:

```javascript
const watermarkText = "CONFIDENTIAL";

let presentation = new aspose.slides.Presentation();
let masterSlide = presentation.getMasters().get_Item(0);

let watermarkShape = masterSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 40);
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);

presentation.dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách sử dụng ](/slides/vi/nodejs-java/slide-master/)[Slide Master](/slides/vi/nodejs-java/slide-master/)
{{% /alert %}}

### **Đặt Độ trong suốt cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu nền và màu viền. Các dòng code sau sẽ làm cho shape trong suốt.

```javascript
watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
watermarkShape.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
```

### **Đặt Phông chữ cho Watermark Văn bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```javascript
let textFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat();
textFormat.setLatinFont(new aspose.slides.FontData("Arial"));
textFormat.setFontHeight(50);
```

### **Đặt Màu cho Văn bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn code sau:

```java
let alpha = 150;
let red = 200;
let green = 200;
let blue = 200;

let fillFormat = watermarkFrame.getParagraphs().get_Item(0).getParagraphFormat().getDefaultPortionFormat().getFillFormat();
fillFormat.setFillType(java.newByte(aspose.slides.FillType.Solid));
fillFormat.getSolidFillColor().setColor(java.newInstanceSync("java.awt.Color", red, green, blue, alpha));
```

### **Căn giữa Watermark Văn bản**
Bạn có thể căn giữa watermark trên slide bằng cách thực hiện các bước sau:

```javascript
const watermarkWidth = 400;
const watermarkHeight = 40;
const watermarkX = (slideSize.getWidth() - watermarkWidth) / 2;
const watermarkY = (slideSize.getHeight() - watermarkHeight) / 2;

let watermarkShape = masterSlide.getShapes().addAutoShape(
        aspose.slides.ShapeType.Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);
        
let watermarkFrame = watermarkShape.addTextFrame(watermarkText);
```

Hình ảnh dưới đây cho thấy kết quả cuối cùng.

![The text watermark](text_watermark.png)

## **Watermark dạng Hình ảnh**

### **Thêm Watermark Hình ảnh vào Bản thuyết trình**

Để thêm watermark hình ảnh vào tất cả các slide của bản thuyết trình, bạn có thể thực hiện như sau:

```javascript
let watermarkImage = aspose.slides.Images.fromFile("watermark.png");
let image = presentation.getImages().addImage(watermarkImage);

// ...

watermarkShape.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Picture));
watermarkShape.getFillFormat().getPictureFillFormat().getPicture().setImage(image);
watermarkShape.getFillFormat().getPictureFillFormat().setPictureFillMode(aspose.slides.PictureFillMode.Stretch);
```

### **Khóa Watermark khỏi việc Chỉnh sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [**AutoShape.getShapeLock**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape#getShapeLock--) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc được chọn, thay đổi kích thước, di chuyển, nhóm với các yếu tố khác, khóa văn bản khỏi chỉnh sửa, và nhiều hơn nữa:

```javascript
// Khóa shape watermark khỏi việc chỉnh sửa
watermarkShape.getShapeLock().setSelectLocked(true);
watermarkShape.getShapeLock().setSizeLocked(true);
watermarkShape.getShapeLock().setTextLocked(true);
watermarkShape.getShapeLock().setPositionLocked(true);
watermarkShape.getShapeLock().setGroupingLocked(true);
```

### **Đưa Watermark lên phía Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được thiết lập qua phương thức [**SlideCollection.reorder**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SlideCollection#reorder-int-aspose.slides.ISlide...-). Để thực hiện, gọi phương thức này từ danh sách các slide của bản thuyết trình và truyền tham chiếu shape cùng số thứ tự vào phương thức. Nhờ đó, bạn có thể đưa shape lên phía trước hoặc gửi nó ra phía sau slide. Tính năng này đặc biệt hữu ích khi cần đặt watermark ở phía trước bản thuyết trình:

```javascript
let shapeCount = slide.getShapes().size();
slide.getShapes().reorder(shapeCount - 1, watermarkShape);
```

### **Đặt Góc Xoay cho Watermark**

Dưới đây là ví dụ mã để điều chỉnh góc xoay của watermark sao cho nó đặt chéo qua slide:

```javascript
const diagonalAngle = Math.atan(slideSize.getHeight() / slideSize.getWidth()) * 180 / Math.PI;

watermarkShape.setRotation(diagonalAngle);
```

### **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape watermark, gán nó cho phương thức [**AutoShape.getName**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getName--):

```javascript
watermarkShape.setName("watermark");
```

### **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [AutoShape.getName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getName--) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [**ShapeCollection.remove**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ShapeCollection#remove-aspose.slides.IShape-):

```javascript
for (var i = 0; i < slide.getShapes().size(); i++) {
    var shape = slide.getShapes().get_Item(i);
    if ("watermark" == shape.getName()) {
        slide.getShapes().remove(watermarkShape);
    }
}
```

## **Câu hỏi Thường gặp**

**Watermark là gì và tại sao tôi nên sử dụng?**

Watermark là lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide, giúp bảo vệ sở hữu trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản thuyết trình.

**Tôi có thể thêm watermark vào tất cả các slide trong một bản thuyết trình không?**

Có, Aspose.Slides cho phép bạn thêm watermark vào mỗi slide trong bản thuyết trình. Bạn có thể lặp qua tất cả các slide và áp dụng cài đặt watermark cho từng slide.

**Làm sao tôi điều chỉnh độ trong suốt của watermark?**

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách thay đổi [cài đặt màu nền](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getfillformat/) của shape. Điều này giúp watermark trở nên nhẹ nhàng và không làm phân tán sự chú ý khỏi nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho watermark?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG, và các định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu cho watermark văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu nào để phù hợp với thiết kế của bản thuyết trình và duy trì tính nhất quán thương hiệu.

**Làm sao tôi thay đổi vị trí hoặc hướng của watermark?**

Bạn có thể điều chỉnh vị trí và hướng của watermark bằng cách thay đổi tọa độ, kích thước và các thuộc tính xoay của shape.