---
title: Hạn chế chỉnh sửa bản trình bày bằng khóa hình dạng trong PHP
linktitle: Hạn chế chỉnh sửa bản trình bày
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
- bản trình bày
- PHP
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình bày PPTX bằng Aspose.Slides cho PHP qua Java để hạn chế lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides for PHP via Java là tạo, cập nhật và lưu các bản trình bày PowerPoint (PPTX) như một phần của quy trình tự động. Khi người dùng nhận các bản trình bày này, việc hạn chế thay đổi các hình dạng có thể giúp bảo toàn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên slide và cách áp dụng và loại bỏ các khóa hình dạng trong một bản trình bày PPTX. Các khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ.

## **Thành phần của một Slide**

Một slide trong bài thuyết trình được tạo thành từ các thành phần như autoshapes, bảng, đối tượng OLE, nhóm hình dạng, khung ảnh, khung video, connector và các yếu tố khác được sử dụng để xây dựng bài thuyết trình. Trong Aspose.Slides for PHP via Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for PHP via Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) khóa autoshapes.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) khóa connector.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) khóa đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) khóa nhóm hình dạng.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) khóa khung ảnh.  

Để áp dụng các khóa trên toàn bộ [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), duyệt qua các slide của nó và đặt các khóa phù hợp trên mỗi hình dạng được hỗ trợ.

## **Áp dụng và loại bỏ bảo vệ**

Các trình chỉnh sửa bản trình bày tương thích sử dụng các khóa hình dạng để hạn chế các thao tác chỉnh sửa cá nhân. Mã hoá tệp và bảo vệ ghi ở mức độ tài liệu là các [cài đặt bảo vệ bản trình bày](/slides/vi/php-java/password-protected-presentation/) riêng biệt.

### **Áp dụng bảo vệ cho các hình dạng PPTX**

Aspose.Slides for PHP via Java cung cấp lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) để làm việc với các hình dạng trên slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) và [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) với `true` cho autoshapes, với các khóa tương đương cho nhóm hình dạng, connector và khung ảnh. Connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) để di chuyển; các nhóm cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bản trình bày PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide, và lưu một bản sao với các hạn chế này đã được áp dụng. Các hình dạng không thuộc bốn loại được xử lý sẽ không thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

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

### **Xóa bảo vệ**

Để loại bỏ một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình bày có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Nó cũng loại bỏ hạn chế nhóm bằng cách truyền `false` vào [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bản trình bày. Các cài đặt khóa khác vẫn không thay đổi.

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

### **Bảo tồn cắt ảnh**

Đặt một ảnh có tên `photo.jpg` trong thư mục làm việc. Ví dụ cắt 12% từ phía trái và 8% từ phía phải, sau đó gọi [setCropLocked](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/#setCropLocked) trên khóa của khung ảnh. Truyền `true` sẽ hạn chế việc cắt tiếp theo và giữ nguyên phần cắt hiện có.

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

`PictureLocked.pptx` lưu khóa cắt dưới dạng `true`. Trong PowerPoint, lệnh **Crop** sẽ bị tắt khi ảnh được chọn.

### **Giữ một sơ đồ được nhóm**

Ví dụ nhóm một hình chữ nhật và một mũi tên, sau đó gọi [setUngroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setUngroupingLocked) trên khóa của nhóm để giữ các thành phần của sơ đồ luôn ở cùng nhau. Các chỉnh sửa khác, chẳng hạn di chuyển nhóm hoặc thay đổi màu nền của thành phần, vẫn khả dụng.

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

`DiagramLocked.pptx` lưu khóa gỡ nhóm dưới dạng `true`. Trong PowerPoint, lệnh **Ungroup** sẽ bị tắt khi toàn bộ sơ đồ được chọn.

### **Báo cáo các khóa hình dạng hiện có**

Để xem lại một mẫu, mở nó và đọc đối tượng khóa cho mỗi hình dạng. Phương thức [getNoLocks](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/#getNoLocks) trả về `true` khi tất cả các cờ trên đối tượng đó bị tắt và `false` khi có ít nhất một cờ được bật. Một nhóm và các thành phần con của nó có các đối tượng khóa riêng, vì vậy hãy kiểm tra các thành phần con ngay cả khi nhóm không có khóa.

Ví dụ này kiểm tra di chuyển cho autoshapes, khung ảnh và nhóm. Nó cũng kiểm tra cắt ảnh cho picture và gỡ nhóm cho nhóm. Báo cáo liệt kê các cờ đã bật mà nó nhận diện và đánh dấu các loại hình dạng mà nó không kiểm tra.

```php
use aspose\slides\Presentation;

function reportShapeLocks($shapes, $slideNumber, $prefix = "") {
    foreach ($shapes->toArray() as $shape) {
        $path = $prefix . java_values($shape->getName());
        $type = java_values($shape->getClass()->getSimpleName());
        $label = "Slide $slideNumber | $path | $type";
        $flags = [];
        $isGroup = java_instanceof($shape, java("com.aspose.slides.IGroupShape"));

        if ($isGroup) {
            $lock = $shape->getGroupShapeLock();
            if (java_values($lock->getUngroupingLocked())) {
                $flags[] = "UngroupingLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IPictureFrame"))) {
            $lock = $shape->getPictureFrameLock();
            if (java_values($lock->getCropLocked())) {
                $flags[] = "CropLocked";
            }
        } elseif (java_instanceof($shape, java("com.aspose.slides.IAutoShape"))) {
            $lock = $shape->getAutoShapeLock();
        } else {
            echo "$label | Uninspected", PHP_EOL;
            continue;
        }

        if (java_values($lock->getPositionLocked())) {
            $flags[] = "PositionLocked";
        }
        if (!java_values($lock->getNoLocks())) {
            $restrictions = $flags ? implode(", ", $flags) : "Active flag not identified";
            echo "$label | $restrictions", PHP_EOL;
        }

        if ($isGroup) {
            reportShapeLocks($shape->getShapes(), $slideNumber, $path . "/");
        }
    }
}

$presentation = new Presentation("Sample.pptx");
try {
    foreach ($presentation->getSlides()->toArray() as $slide) {
        reportShapeLocks($slide->getShapes(), java_values($slide->getSlideNumber()));
    }
} finally {
    $presentation->dispose();
}
```

Giả sử slide 1 của `Sample.pptx` chứa một nhóm có tên `Layout` với gỡ nhóm bị khóa, một ảnh có tên `Photo` bên trong nó với cắt ảnh bị khóa, và một hình chữ nhật không khóa có tên `Free`. Báo cáo sẽ bỏ qua `Free` và in ra hai dòng sau:

```text
Slide 1 | Layout | GroupShape | UngroupingLocked
Slide 1 | Layout/Photo | PictureFrame | CropLocked
```

Báo cáo đọc các cờ chỉnh sửa ở mức hình dạng đã lưu mà không thay đổi chúng hoặc lưu lại bản trình bày. Bảo vệ ghi ở mức tài liệu là một cài đặt riêng, và việc thực thi mỗi cờ phụ thuộc vào trình chỉnh sửa.

### **Kết luận**

Aspose.Slides for PHP via Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng riêng lẻ hoặc áp dụng cùng một bộ hạn chế trên nhiều slide. Chọn các khóa được hỗ trợ bởi từng loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần loại bỏ các hạn chế đó.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo mật bằng mật khẩu trong cùng một bản trình bày không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [password protection](/slides/vi/php-java/password-protected-presentation/) có thể hạn chế việc mở hoặc sửa đổi bản trình bày. Bạn có thể sử dụng cả hai trong cùng một tệp.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ cho các hình dạng trên các slide được chọn. Điều này sẽ không thay đổi cài đặt khóa trên các slide khác.

**Làm sao tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Duyệt qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa phù hợp cho mỗi hình dạng con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào, theo cách duyệt trong ví dụ báo cáo.