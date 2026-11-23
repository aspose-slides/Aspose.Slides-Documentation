---
title: Hạn chế chỉnh sửa bản thuyết trình bằng khóa hình dạng trong PHP
linktitle: Hạn chế chỉnh sửa bản thuyết trình
type: docs
weight: 60
url: /vi/php-java/applying-protection-to-presentation/
keywords:
- ngăn chặn chỉnh sửa
- bảo vệ khỏi việc chỉnh sửa
- khóa hình dạng
- khóa vị trí
- khóa lựa chọn
- khóa thay đổi kích thước
- khóa nhóm
- PowerPoint
- PPTX
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản thuyết trình PPTX bằng Aspose.Slides cho PHP thông qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides cho PHP thông qua Java là tạo, cập nhật và lưu các bản thuyết trình PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản thuyết trình này, việc hạn chế thay đổi các hình dạng có thể giúp bảo vệ bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và loại bỏ khóa hình dạng trong một bản thuyết trình PPTX. Những khóa này cho phép bạn giới hạn các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Thành phần của một Slide**

Một slide trong bản thuyết trình được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, các hình dạng nhóm, khung ảnh, khung video, connectors và các yếu tố khác được sử dụng để xây dựng bản thuyết trình. Trong Aspose.Slides cho PHP thông qua Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) là lớp cơ bản cho các khóa hình dạng. Aspose.Slides cho PHP thông qua Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) khóa các hình tự động.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) khóa các hình connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) khóa các hình dạng nhóm.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), duyệt qua các slide của nó và đặt các khóa phù hợp cho từng hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Các trình chỉnh sửa bản thuyết trình tương thích sử dụng khóa hình dạng để hạn chế các thao tác chỉnh sửa riêng lẻ. Mã hóa tệp và bảo vệ ghi ở mức tài liệu là các [cài đặt bảo vệ bản thuyết trình](/slides/vi/php-java/password-protected-presentation/) riêng biệt.

### **Áp dụng Bảo vệ cho Các Hình dạng PPTX**

Aspose.Slides cho PHP thông qua Java cung cấp lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) để làm việc với các hình dạng trên một slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) và [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) với `true` cho các hình tự động, cùng với các khóa tương đương cho các hình nhóm, connectors và picture frames. Các connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bản thuyết trình PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này được áp dụng. Các hình dạng không thuộc bốn loại được xử lý sẽ được để nguyên. Vòng lặp không duyệt qua các hình dạng con bên trong một nhóm.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(true);
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(true);
                $shapeLock->setSelectLocked(true);
                $shapeLock->setSizeLocked(true);
            }
        }
    }

    $presentation->save("ProtectedSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Xóa Bảo vệ**

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản thuyết trình có khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Nó cũng loại bỏ hạn chế nhóm bằng cách truyền `false` vào [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bản thuyết trình. Các cài đặt khóa khác được để nguyên.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("ProtectedSample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        foreach ($slide->getShapes()->toArray() as $shape) {
            if (java_instanceof($shape, new JavaClass("com.aspose.slides.AutoShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.GroupShape"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setGroupingLocked(false);
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.Connector"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionMove(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            } elseif (java_instanceof($shape, new JavaClass("com.aspose.slides.PictureFrame"))) {
                $shapeLock = $shape->getShapeLock();
                $shapeLock->setPositionLocked(false);
                $shapeLock->setSelectLocked(false);
                $shapeLock->setSizeLocked(false);
            }
        }
    }

    $presentation->save("RemovedProtectionSample.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Bảo vệ Cắt ảnh**

Đặt một bức ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ bên trái và 8% từ bên phải, sau đó gọi [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) trên khóa của khung ảnh. Truyền `true` sẽ hạn chế việc cắt thêm và bảo tồn phần cắt hiện tại.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();

    $image = Images::fromFile("photo.jpg");
    try {
        $photo = $presentation->getImages()->addImage($image);
    } finally {
        $image->dispose();
    }

    $pictureFrame = $shapes->addPictureFrame(ShapeType::Rectangle, 20, 30, 270, 160, $photo);
    $pictureFrame->getPictureFormat()->setCropLeft(12);
    $pictureFrame->getPictureFormat()->setCropRight(8);

    $pictureFrameLock = $pictureFrame->getPictureFrameLock();
    $pictureFrameLock->setAspectRatioLocked(false);
    $pictureFrameLock->setCropLocked(true);

    $presentation->save("PictureLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`PictureLocked.pptx` lưu trạng thái khóa cắt là `true`. Trong PowerPoint, lệnh **Crop** sẽ bị vô hiệu hoá khi ảnh được chọn.

### **Giữ sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) trên khóa của nhóm để giữ các thành phần của sơ đồ lại với nhau. Các chỉnh sửa khác, như di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shapes = $presentation->getSlides()->get_Item(0)->getShapes();
    
    $groupShape = $shapes->addGroupShape();
    $groupShape->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 70, 90, 50);
    $groupShape->getShapes()->addAutoShape(ShapeType::RightArrow, 190, 80, 60, 30);
    $groupShape->getGroupShapeLock()->setUngroupingLocked(true);

    $presentation->save("DiagramLocked.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

`DiagramLocked.pptx` lưu trạng thái khóa không tách nhóm là `true`. Trong PowerPoint, lệnh **Ungroup** sẽ bị vô hiệu hoá khi toàn bộ sơ đồ được chọn.

### **Kết luận**

Aspose.Slides cho PHP thông qua Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng các hạn chế trên toàn bộ các slide. Chọn các khóa được hỗ trợ cho mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần loại bỏ các hạn chế đó.

## **FAQ**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản thuyết trình không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/php-java/password-protected-presentation/) có thể hạn chế việc mở hoặc chỉnh sửa bản thuyết trình. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Chỉ áp dụng khóa cho các hình dạng trên các slide đã chọn. Điều này không thay đổi cài đặt khóa trên các slide khác.

**Làm thế nào để tôi áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập được trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.