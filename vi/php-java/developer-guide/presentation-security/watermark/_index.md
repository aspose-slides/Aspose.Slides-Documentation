---
title: Thêm Watermark vào Bản Trình bày trong PHP
linktitle: Dấu Nước
type: docs
weight: 40
url: /vi/php-java/watermark/
keywords:
- dấu nước
- dấu nước văn bản
- dấu nước hình ảnh
- thêm dấu nước
- thay đổi dấu nước
- xóa bỏ dấu nước
- xóa dấu nước
- thêm dấu nước vào PPT
- thêm dấu nước vào PPTX
- thêm dấu nước vào ODP
- xóa dấu nước khỏi PPT
- xóa dấu nước khỏi PPTX
- xóa dấu nước khỏi ODP
- xóa dấu nước khỏi PPT
- xóa dấu nước khỏi PPTX
- xóa dấu nước khỏi ODP
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Quản lý dấu nước văn bản và hình ảnh trong các bản trình bày PowerPoint và OpenDocument bằng PHP để biểu thị bản nháp, thông tin bí mật, bản quyền và hơn thế nữa."
---
## **Giới thiệu**

**A watermark** trong một bản trình bày là một dấu văn bản hoặc hình ảnh được đặt trên một slide hoặc trên toàn bộ các slide của bản trình bày. Thông thường, watermark được dùng để chỉ ra rằng bản trình bày là bản nháp (ví dụ, watermark “Draft”), chứa thông tin bảo mật (ví dụ, watermark “Confidential”), chỉ định công ty nào sở hữu (ví dụ, watermark “Company Name”), xác định tác giả của bản trình bày, v.v. Watermark giúp ngăn vi phạm bản quyền bằng cách cho biết bản trình bày không nên được sao chép. Watermark được sử dụng trong cả định dạng PowerPoint và OpenOffice. Trong Aspose.Slides, bạn có thể thêm watermark vào các định dạng tệp PowerPoint PPT, PPTX và OpenOffice ODP.

Trong [**Aspose.Slides**](https://products.aspose.com/slides/vi/php-java/), có nhiều cách để tạo watermark trong tài liệu PowerPoint hoặc OpenOffice và chỉnh sửa thiết kế và hành vi của chúng. Điểm chung là để thêm watermark dạng văn bản, bạn nên sử dụng lớp [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/), và để thêm watermark dạng hình ảnh, sử dụng lớp [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) hoặc lấp đầy hình dạng watermark bằng một hình ảnh. `PictureFrame` thực hiện lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), cho phép bạn sử dụng tất cả các cài đặt linh hoạt của đối tượng shape. Vì `ITextFrame` không phải là shape và các cài đặt của nó có hạn, nó được bọc trong một đối tượng [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/).

Có hai cách để áp dụng watermark: vào một slide duy nhất hoặc vào tất cả các slide của bản trình bày. Slide Master được sử dụng để áp dụng watermark cho tất cả các slide — watermark được thêm vào Slide Master, thiết kế đầy đủ ở đó, và được áp dụng cho mọi slide mà không ảnh hưởng đến quyền chỉnh sửa watermark trên các slide riêng lẻ.

Watermark thường được coi là không thể chỉnh sửa bởi người dùng khác. Để ngăn watermark (hoặc shape cha của watermark) bị chỉnh sửa, Aspose.Slides cung cấp chức năng khóa shape. Một shape cụ thể có thể được khóa trên một slide bình thường hoặc trên Slide Master. Khi shape watermark được khóa trên Slide Master, nó sẽ bị khóa trên tất cả các slide của bản trình bày.

Bạn có thể đặt tên cho watermark để sau này, nếu muốn xóa, có thể tìm nó trong các shape của slide bằng tên.

Bạn có thể thiết kế watermark theo bất kỳ cách nào; tuy nhiên, thường có một số đặc điểm chung của watermark, chẳng hạn như căn giữa, xoay, vị trí ở phía trước, v.v. Chúng tôi sẽ xem xét cách sử dụng các đặc điểm này trong các ví dụ dưới đây.

## **Watermark Văn Bản**

### **Thêm Watermark Văn Bản vào Slide**

Để thêm watermark dạng văn bản trong PPT, PPTX hoặc ODP, bạn có thể đầu tiên thêm một shape vào slide, sau đó thêm một text frame vào shape này. Text frame được biểu diễn bởi lớp [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/). Kiểu này không kế thừa từ [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/), lớp có tập hợp rộng các thuộc tính để định vị watermark một cách linh hoạt. Do đó, đối tượng [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) được bọc trong một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/). Để thêm văn bản watermark vào shape, sử dụng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#addTextFrame) như dưới đây.

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

$watermarkShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Lớp TextFrame](/slides/vi/php-java/text-formatting/)
{{% /alert %}}

### **Thêm Watermark Văn Bản vào Bản Trình Bày**

Nếu bạn muốn thêm watermark dạng văn bản vào toàn bộ bản trình bày (tức là tất cả các slide cùng một lúc), thêm nó vào [MasterSlide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/masterslide/). Phần logic còn lại giống như khi thêm watermark vào một slide duy nhất — tạo một đối tượng [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) và sau đó thêm watermark vào nó bằng phương thức [addTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#addTextFrame).

```php
$watermarkText = "CONFIDENTIAL";

$presentation = new Presentation();
$masterSlide = $presentation->getMasters()->get_Item(0);

$watermarkShape = $masterSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);

$presentation->dispose();
```

{{% alert color="primary" title="Xem thêm" %}} 
- [Cách Sử Dụng Slide Master](/slides/vi/php-java/slide-master/)
{{% /alert %}}

### **Đặt Độ Trong Suất cho Shape Watermark**

Mặc định, shape hình chữ nhật được định dạng với màu nền và màu đường viền. Các dòng mã sau làm cho shape trong suốt.

```php
$watermarkShape->getFillFormat()->setFillType(FillType::NoFill);
$watermarkShape->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
```

### **Đặt Phông Chữ cho Watermark Văn Bản**

Bạn có thể thay đổi phông chữ của watermark văn bản như dưới đây.

```php
$textFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat();
$textFormat->setLatinFont(new FontData("Arial"));
$textFormat->setFontHeight(50);
```

### **Đặt Màu Văn Bản Watermark**

Để đặt màu cho văn bản watermark, sử dụng đoạn mã này:

```php
$alpha = 150;
$red = 200;
$green = 200;
$blue = 200;
$textColor = new Java("java.awt.Color", $red, $green, $blue, $alpha);

$fillFormat = $watermarkFrame->getParagraphs()->get_Item(0)->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();
$fillFormat->setFillType(FillType::Solid);
$fillFormat->getSolidFillColor()->setColor($textColor);
```

### **Căn Giữa Watermark Văn Bản**

Bạn có thể căn giữa watermark trên slide, thực hiện như sau:

```php
$slideSize = $presentation->getSlideSize()->getSize();
$slideWidth = java_values($slideSize->getWidth());
$slideHeight = java_values($slideSize->getHeight());

$watermarkWidth = 400;
$watermarkHeight = 40;
$watermarkX = ($slideWidth - $watermarkWidth) / 2;
$watermarkY = ($slideHeight - $watermarkHeight) / 2;

$watermarkShape = $slide->getShapes()->addAutoShape(
        ShapeType::Rectangle, $watermarkX, $watermarkY, $watermarkWidth, $watermarkHeight);

$watermarkFrame = $watermarkShape->addTextFrame($watermarkText);
```

Hình ảnh bên dưới cho thấy kết quả cuối cùng.

![Watermark văn bản](text_watermark.png)

## **Watermark Hình Ảnh**

### **Thêm Watermark Hình Ảnh vào Bản Trình Bày**

Để thêm watermark hình ảnh vào một slide của bản trình bày, bạn có thể thực hiện các bước sau:

```php
$image = Images::fromFile("watermark.png");
$picture = $presentation->getImages()->addImage($image);
$image->dispose();

$watermarkShape->getFillFormat()->setFillType(FillType::Picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($picture);
$watermarkShape->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
```

### **Khóa Watermark khỏi Việc Chỉnh Sửa**

Nếu cần ngăn watermark bị chỉnh sửa, sử dụng phương thức [AutoShape.getAutoShapeLock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#getAutoShapeLock) trên shape. Với thuộc tính này, bạn có thể bảo vệ shape khỏi việc chọn, thay đổi kích thước, di chuyển, nhóm với các yếu tố khác, khóa văn bản khỏi việc chỉnh sửa, và nhiều hơn nữa:

```php
// Khóa shape watermark khỏi việc chỉnh sửa
$watermarkShape->getAutoShapeLock()->setSelectLocked(true);
$watermarkShape->getAutoShapeLock()->setSizeLocked(true);
$watermarkShape->getAutoShapeLock()->setTextLocked(true);
$watermarkShape->getAutoShapeLock()->setPositionLocked(true);
$watermarkShape->getAutoShapeLock()->setGroupingLocked(true);
```

### **Đưa Watermark Lên Trước**

Trong Aspose.Slides, thứ tự Z của các shape có thể được đặt qua phương thức [ShapeCollection.reorder](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#reorder). Để làm điều này, bạn cần gọi phương thức này từ danh sách các slide của bản trình bày và truyền tham chiếu shape cùng số thứ tự của nó vào phương thức. Nhờ đó, có thể đưa một shape lên phía trước hoặc đưa nó ra phía sau slide. Tính năng này rất hữu ích khi bạn cần đặt watermark ở phía trước bản trình bày:

```php
$shapeCount = java_values($slide->getShapes()->size());
$slide->getShapes()->reorder($shapeCount - 1, $watermarkShape);
```

### **Đặt Góc Xoay cho Watermark**

Dưới đây là ví dụ mã cách điều chỉnh góc xoay của watermark sao cho nó đặt chéo trên slide:

```php
$diagonalAngle = atan($slideWidth / $slideHeight) * 180 / M_PI;

$watermarkShape->setRotation($diagonalAngle);
```

### **Đặt Tên cho Watermark**

Aspose.Slides cho phép bạn đặt tên cho một shape. Bằng cách sử dụng tên shape, bạn có thể truy cập vào nó trong tương lai để sửa đổi hoặc xóa. Để đặt tên cho shape watermark, gọi phương thức [AutoShape.setName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#setName):

```php
$watermarkShape->setName("watermark");
```

### **Xóa Watermark**

Để xóa shape watermark, sử dụng phương thức [AutoShape.getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/#getName) để tìm nó trong các shape của slide. Sau đó, truyền shape watermark vào phương thức [ShapeCollection.remove](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#remove):

```php
$slideShapes = $slide->getShapes()->toArray();
foreach ($slideShapes as $shape) {
    if ($shape->getName() === "watermark") {
        $slide->getShapes()->remove($shape);
    }
}
```

## **FAQ**

**Watermark là gì và tại sao tôi nên sử dụng?**

Watermark là lớp phủ văn bản hoặc hình ảnh được áp dụng lên các slide giúp bảo vệ quyền sở hữu trí tuệ, tăng nhận diện thương hiệu, hoặc ngăn việc sử dụng trái phép bản trình bày.

**Tôi có thể thêm watermark vào tất cả các slide trong một bản trình bày không?**

Có, Aspose.Slides cho phép bạn lập trình thêm watermark vào mọi slide trong một bản trình bày. Bạn có thể lặp qua tất cả các slide và áp dụng cài đặt watermark cho từng slide.

**Làm sao tôi có thể điều chỉnh độ trong suốt của watermark?**

Bạn có thể điều chỉnh độ trong suốt của watermark bằng cách thay đổi cài đặt fill ([getFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getfillformat/)) của shape. Điều này giúp watermark trở nên nhẹ nhàng và không gây mất tập trung cho nội dung slide.

**Các định dạng hình ảnh nào được hỗ trợ cho watermark?**

Aspose.Slides hỗ trợ nhiều định dạng hình ảnh như PNG, JPEG, GIF, BMP, SVG và các định dạng khác.

**Tôi có thể tùy chỉnh phông chữ và kiểu dáng của watermark văn bản không?**

Có, bạn có thể chọn bất kỳ phông chữ, kích thước và kiểu dáng nào để phù hợp với thiết kế bản trình bày và duy trì tính nhất quán thương hiệu.

**Làm sao tôi thay đổi vị trí hoặc hướng của watermark?**

Bạn có thể điều chỉnh vị trí và hướng của watermark bằng cách lập trình thay đổi tọa độ, kích thước và thuộc tính xoay của shape.