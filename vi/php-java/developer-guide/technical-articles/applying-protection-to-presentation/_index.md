---
title: Hạn chế chỉnh sửa bản trình chiếu bằng Khóa Hình dạng trong PHP
linktitle: Hạn chế chỉnh sửa bản trình chiếu
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
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách khóa và mở khóa các hình dạng trong bản trình chiếu PPTX bằng Aspose.Slides cho PHP qua Java để hạn chế việc lựa chọn, di chuyển, thay đổi kích thước và nhóm."
---
## **Tổng quan**

Một cách sử dụng phổ biến của Aspose.Slides for PHP qua Java là tạo, cập nhật và lưu các bản trình chiếu PowerPoint (PPTX) như một phần của quy trình làm việc tự động. Khi người dùng nhận các bản trình chiếu này, việc hạn chế thay đổi các hình dạng có thể giúp bảo tồn bố cục và nội dung dự định.

Bài viết này giải thích cách các hình dạng được tổ chức trên các slide và cách áp dụng và xóa khóa hình dạng trong một bản trình chiếu PPTX. Những khóa này cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng.

## **Thành phần của một Slide**

Một slide trình chiếu được tạo thành từ các thành phần như autoshapes, tables, OLE objects, grouped shapes, picture frames, video frames, connectors và các yếu tố khác dùng để xây dựng một bản trình chiếu. Trong Aspose.Slides for PHP qua Java, mỗi yếu tố trên slide được đại diện bằng một đối tượng kế thừa từ lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) .

Các loại hình dạng khác nhau cung cấp các tùy chọn khóa khác nhau. Lớp [BaseShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/baseshapelock/) là lớp cơ sở cho các khóa hình dạng. Aspose.Slides for PHP qua Java cung cấp các lớp khóa sau:

- [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/) khóa các hình dạng tự động.  
- [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) khóa các hình dạng kết nối.  
- [GraphicalObjectLock](https://reference.aspose.com/slides/php-java/aspose.slides/graphicalobjectlock/) khóa các đối tượng đồ họa.  
- [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/) khóa các hình dạng nhóm.  
- [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/) khóa các khung ảnh.  

Để áp dụng khóa trên toàn bộ một [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/), lặp lại qua các slide và đặt các khóa thích hợp trên mỗi hình dạng được hỗ trợ.

## **Áp dụng và Xóa Bảo vệ**

Khóa hình dạng hạn chế các thao tác như chọn, di chuyển và thay đổi kích thước các hình dạng. Chúng không khiến toàn bộ bản trình chiếu trở nên không thể chỉnh sửa.

### **Áp dụng Bảo vệ cho các Hình dạng PPTX**

Aspose.Slides for PHP qua Java cung cấp lớp [Shape](https://reference.aspose.com/slides/php-java/aspose.slides/shape/) để làm việc với các hình dạng trên slide.

Ví dụ gọi [setSelectLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSelectLocked), [setPositionLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setPositionLocked) và [setSizeLocked](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/#setSizeLocked) với `true` cho autoshapes, với các khóa tương đương cho group shapes, connectors và picture frames. Connectors sử dụng [setPositionMove](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/#setPositionMove) cho việc di chuyển; groups cũng sử dụng [setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) để hạn chế việc nhóm.

Ví dụ tải một bản trình chiếu PPTX hiện có, kiểm tra các hình dạng trong bộ sưu tập hình dạng của mỗi slide và lưu một bản sao với những hạn chế này được áp dụng. Các hình dạng ngoài bốn loại được xử lý sẽ không bị thay đổi. Vòng lặp không duyệt các hình dạng con bên trong một nhóm.

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

Để xóa một khóa hình dạng, đặt giá trị của nó thành `false`. Ví dụ sau tải một bản trình chiếu có các khóa hình dạng và xóa các hạn chế lựa chọn, di chuyển và thay đổi kích thước thông qua [AutoShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/autoshapelock/), [GroupShapeLock](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/), [ConnectorLock](https://reference.aspose.com/slides/php-java/aspose.slides/connectorlock/) và [PictureFrameLock](https://reference.aspose.com/slides/php-java/aspose.slides/pictureframelock/). Nó cũng xóa hạn chế nhóm bằng cách truyền `false` cho [GroupShapeLock::setGroupingLocked](https://reference.aspose.com/slides/php-java/aspose.slides/groupshapelock/#setGroupingLocked) và lưu một bản sao của bản trình chiếu. Các cài đặt khóa khác vẫn được giữ nguyên.

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

### **Kết luận**

Aspose.Slides for PHP qua Java cho phép bạn hạn chế các thao tác chỉnh sửa cụ thể trên từng hình dạng hoặc áp dụng cùng một nhóm hạn chế trên toàn bộ các slide. Chọn các khóa được hỗ trợ bởi mỗi loại hình dạng, và đặt giá trị của chúng thành `false` khi bạn cần xóa những hạn chế này.

## **Câu hỏi thường gặp**

**Tôi có thể kết hợp khóa hình dạng và bảo vệ bằng mật khẩu trong cùng một bản trình chiếu không?**

Có. Khóa hình dạng hạn chế các thao tác chỉnh sửa cụ thể, trong khi [bảo vệ bằng mật khẩu](/slides/vi/php-java/password-protected-presentation/) có thể hạn chế việc mở hoặc chỉnh sửa bản trình chiếu. Bạn có thể dùng cả hai trong cùng một tệp.

**Tôi có thể hạn chế việc chỉnh sửa trên các slide cụ thể mà không ảnh hưởng đến các slide khác không?**

Có. Áp dụng khóa chỉ trên các hình dạng của các slide đã chọn. Điều này sẽ không thay đổi cài đặt khóa trên các slide khác.

**Làm sao tôi có thể áp dụng khóa cho các hình dạng riêng lẻ bên trong một nhóm?**

Lặp lại qua bộ sưu tập trả về bởi phương thức [getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/groupshape/#getShapes) của nhóm và áp dụng các khóa thích hợp cho mỗi hình dạng con. Lặp lại quá trình này cho bất kỳ nhóm lồng nhau nào. Các ví dụ ở trên chỉ xử lý bộ sưu tập hình dạng của slide, vì vậy chúng không đặt khóa cho các thành viên riêng lẻ trong nhóm.