---
title: Tối ưu quản lý hình ảnh trong các bản trình chiếu bằng PHP
linktitle: Quản lý hình ảnh
type: docs
weight: 10
url: /vi/php-java/image/
keywords:
- thêm hình ảnh
- thêm hình
- thay thế hình ảnh
- bộ sưu tập hình ảnh
- khung ảnh
- hình ảnh liên kết
- nền
- thêm PNG
- thêm JPG
- thêm SVG
- SVG thành hình dạng
- tài nguyên SVG bên ngoài
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách thêm, tái sử dụng, liên kết, thay thế và quản lý hình ảnh raster và SVG trong các bản trình chiếu PowerPoint và OpenDocument với Aspose.Slides cho PHP thông qua Java."
---
## **Introduction**

Aspose.Slides cho PHP thông qua Java cung cấp một số cách làm việc với hình ảnh, mỗi cách phục vụ một mục đích khác nhau. Bạn có thể lưu trữ một hình ảnh trong bản trình chiếu, hiển thị nó trong khung ảnh, sử dụng nó làm nền slide, liên kết tới một hình ảnh bên ngoài, thay thế tài nguyên hình ảnh được chia sẻ, hoặc chuyển nội dung SVG thành các hình dạng có thể chỉnh sửa.

Bài viết này tập trung vào tài nguyên hình ảnh và cách chúng được sử dụng trong toàn bộ bản trình chiếu. Đối với việc cắt, độ trong suốt, hiệu ứng, kéo dãn và các định dạng khác áp dụng cho một khung ảnh riêng lẻ, xem [Picture Frame](/slides/vi/php-java/picture-frame/).

## **Hiểu mô hình hình ảnh**

Các khái niệm API sau liên quan chặt chẽ nhưng không thể hoán đổi cho nhau:

- [Bộ sưu tập hình ảnh của bản trình chiếu](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) lưu trữ các tài nguyên hình ảnh được sử dụng bởi bản trình chiếu. Sử dụng [ImageCollection::addImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) để thêm dữ liệu hình ảnh và nhận một tài nguyên [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/).
- Một [khung ảnh](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe/) là một hình dạng hiển thị hình ảnh trên slide, bố cục hoặc master. Sử dụng [ShapeCollection::addPictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addpictureframe/) để đặt tài nguyên hình ảnh lên slide.
- Nền slide sử dụng hình ảnh như một phần của nền slide thay vì là một hình dạng. Do đó nó không hoạt động giống như một khung ảnh.
- [PPImage::replaceImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) thay thế một tài nguyên hình ảnh. Nếu nhiều phần tử trong bản trình chiếu sử dụng tài nguyên đó, chúng đều sẽ sử dụng bản thay thế.
- Chuyển đổi SVG thành các hình dạng tạo ra các hình dạng slide có thể chỉnh sửa. Sau khi chuyển đổi, nội dung không còn được quản lý như một tài nguyên hình ảnh duy nhất.

Do đó, một quy trình điển hình là: thêm dữ liệu hình ảnh vào bộ sưu tập hình ảnh, nhận một [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/), và sau đó sử dụng tài nguyên đó trong một hoặc nhiều khung ảnh hoặc nền.

## **Thêm hình ảnh nhúng**

Để chèn một hình ảnh cục bộ, tải tệp, thêm nó vào bộ sưu tập hình ảnh, và tạo một khung ảnh sử dụng `PPImage` được trả về.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $image = Images::fromFile("photo.png");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);

    $presentation->save("presentation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Hình ảnh được thêm theo cách này được nhúng vào bản trình chiếu, vì vậy tệp kết quả không phụ thuộc vào việc tệp hình ảnh gốc còn tồn tại hay không.

### **Thêm hình ảnh từ web**

Khi một hình ảnh có sẵn qua HTTP hoặc HTTPS, tải xuống các byte của nó, thêm chúng vào bộ sưu tập hình ảnh của bản trình chiếu, và sử dụng tài nguyên hình ảnh được trả về theo cùng cách như hình ảnh cục bộ.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $imageUrl = new Java("java.net.URL", "https://example.com/image.png");
    $connection = $imageUrl->openConnection();
    $connection->setConnectTimeout(10000);
    $connection->setReadTimeout(10000);

    $inputStream = $connection->getInputStream();
    $outputStream = new Java("java.io.ByteArrayOutputStream");
    $Array = new JavaClass("java.lang.reflect.Array");
    $Byte = (new JavaClass("java.lang.Byte"))->TYPE;

    try {
        $buffer = $Array->newInstance($Byte, 8192);
        $bufferLength = $Array->getLength($buffer);

        while (($bytesRead = java_values($inputStream->read($buffer, 0, $bufferLength))) != -1) {
            $outputStream->write($buffer, 0, $bytesRead);
        }

        $ppImage = $presentation->getImages()->addImage($outputStream->toByteArray());
        $slide = $presentation->getSlides()->get_Item(0);
        $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, $ppImage);
    } finally {
        if (!java_is_null($inputStream)) {
            $inputStream->close();
        }
        $outputStream->close();
    }

    $presentation->save("presentation-from-web.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Trong các ứng dụng chạy lâu dài, tái sử dụng một client HTTP hoặc chiến lược quản lý kết nối phù hợp với ứng dụng thay vì liên tục tạo ra cơ sở hạ tầng mạng không cần thiết. Ngoài ra, xác thực URL từ xa, kích thước phản hồi và loại nội dung khi nguồn không đáng tin cậy.

## **Tái sử dụng hình ảnh trên các slide**

Nếu cùng một hình ảnh cần được sử dụng nhiều lần, hãy thêm nó vào bản trình chiếu một lần và tái sử dụng [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) khi tạo các khung ảnh bổ sung. Điều này tránh việc tải lại dữ liệu nguồn cùng một lần và làm cho mối quan hệ giữa tài nguyên hình ảnh chia sẻ và các lần sử dụng của nó trở nên rõ ràng.

Đối với các đồ họa nên xuất hiện tự động trên nhiều slide, chẳng hạn như logo công ty, hãy cân nhắc đặt khung ảnh trên một [slide master](/slides/vi/php-java/slide-master/) hoặc bố cục thay vì thêm một hình dạng tương đương vào mỗi slide.

## **Sử dụng hình ảnh làm nền slide**

Một hình ảnh nền được gán vào phần nền slide; nó không được thêm như một hình dạng khung ảnh. Điều này hữu ích khi hình ảnh nên bao phủ nền slide và không được thao tác như một đối tượng slide thông thường.

```php
use aspose\slides\BackgroundType;
use aspose\slides\FillType;
use aspose\slides\Images;
use aspose\slides\PictureFillMode;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $image = Images::fromFile("background.jpg");
    try {
        $ppImage = $presentation->getImages()->addImage($image);
    } finally {
        if (!java_is_null($image)) {
            $image->dispose();
        }
    }

    $slide->getBackground()->setType(BackgroundType::OwnBackground);
    $slide->getBackground()->getFillFormat()->setFillType(FillType::Picture);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->setPictureFillMode(PictureFillMode::Stretch);
    $slide->getBackground()->getFillFormat()->getPictureFillFormat()->getPicture()->setImage($ppImage);

    $presentation->save("background-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để biết thêm các tùy chọn nền, bao gồm nền master và bố cục, xem [Presentation Background](/slides/vi/php-java/presentation-background/).

## **Hình ảnh nhúng và hình ảnh liên kết**

Hình ảnh nhúng và hình ảnh liên kết có các cân bằng khác nhau về tính di động và kích thước tệp:

- **Hình ảnh nhúng:** dữ liệu hình ảnh được lưu trong bản trình chiếu. Bản trình chiếu là độc lập, nhưng kích thước tệp bao gồm dữ liệu hình ảnh.
- **Hình ảnh liên kết:** bản trình chiếu lưu một đường dẫn hoặc URL tới một hình ảnh bên ngoài. Điều này có thể giảm kích thước bản trình chiếu, nhưng tài nguyên bên ngoài phải vẫn có thể truy cập khi bản trình chiếu được mở hoặc render.

Một hình ảnh liên kết có thể được tạo bằng cách gán đường dẫn hoặc URL bên ngoài thông qua [Picture::setLinkPathLong](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picture/) thay vì nhúng dữ liệu hình ảnh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $pictureFrame = $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 320, 180, null);
    $pictureFrame->getPictureFormat()->getPicture()->setLinkPathLong("https://example.com/image.png");

    $presentation->save("linked-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Chỉ sử dụng hình ảnh liên kết khi môi trường triển khai có thể truy cập tài nguyên bên ngoài một cách đáng tin cậy. Đối với các bản trình chiếu phải hoạt động offline hoặc được chuyển giữa các hệ thống, hình ảnh nhúng thường an toàn hơn.

## **Làm việc với hình ảnh SVG**

SVG là định dạng vector, do đó nó hữu ích cho các biểu tượng, sơ đồ và các đồ họa khác cần phóng to mà không mất chi tiết như ảnh raster. Aspose.Slides hỗ trợ SVG cả như một tài nguyên hình ảnh và như nguồn cho các hình dạng slide có thể chỉnh sửa.

### **Thêm SVG dưới dạng hình ảnh**

Tạo một [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/), thêm nó vào bộ sưu tập hình ảnh, và đặt tài nguyên hình ảnh kết quả vào một khung ảnh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("icon.svg");
    $svgImage = new SvgImage($svgContent);

    $ppImage = $presentation->getImages()->addImage($svgImage);
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addPictureFrame(ShapeType::Rectangle, 20, 20, 200, 200, $ppImage);

    $presentation->save("svg-image.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

### **Tập tin SVG với tài nguyên bên ngoài**

Một SVG có thể tham chiếu tới các hình ảnh, stylesheet hoặc phông chữ bên ngoài. Đối với các trường hợp này, [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) cung cấp các hàm khởi tạo chấp nhận một [ExternalResourceResolver](https://reference.aspose.com/slides/vi/php-java/aspose.slides/externalresourceresolver/) và một URI cơ sở. Bộ giải quyết có thể ánh xạ một URI tương đối sang một URI tuyệt đối cho phép và trả về luồng cho tài nguyên được yêu cầu.

Bộ giải quyết làm cho tài nguyên bên ngoài có sẵn trong khi Aspose.Slides xử lý SVG, nhưng nó không ghi lại SVG thành một tài liệu tự chứa. Nếu SVG phải duy trì được tính di động, hãy nhúng các tài nguyên cần thiết vào chính SVG, ví dụ bằng cách sử dụng URI `data:` cho các hình ảnh liên kết.

Khi các tệp SVG đến từ nguồn không đáng tin, hạn chế các scheme, vị trí tệp và máy chủ mà bộ giải quyết có thể truy cập. Các bộ giải quyết mạng cũng nên áp dụng thời gian chờ, giới hạn kích thước phản hồi và kiểm tra nội dung.

### **Chuyển đổi SVG thành các hình dạng có thể chỉnh sửa**

Aspose.Slides có thể chuyển đổi một SVG thành một nhóm các hình dạng slide có thể chỉnh sửa, tương tự như lệnh PowerPoint tương ứng.

![PowerPoint Popup Menu](img_01_01.png)

Sử dụng phiên bản tải trọng của [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addgroupshape/) chấp nhận một [SvgImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgimage/) để thực hiện việc chuyển đổi.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SvgImage;

$presentation = new Presentation();
try {
    $svgContent = file_get_contents("diagram.svg");
    $svgImage = new SvgImage($svgContent);

    $slideSize = $presentation->getSlideSize()->getSize();
    $slide = $presentation->getSlides()->get_Item(0);
    $slide->getShapes()->addGroupShape($svgImage, 0, 0, $slideSize->getWidth(), $slideSize->getHeight());

    $presentation->save("editable-svg-shapes.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Sử dụng chuyển đổi SVG sang các hình dạng khi các phần tử vector riêng lẻ cần được chỉnh sửa dưới dạng hình dạng PowerPoint. Nếu SVG chỉ cần được hiển thị, giữ nó dưới dạng hình ảnh sẽ đơn giản hơn và tránh tạo ra nhiều hình dạng riêng biệt.

## **Thay thế tài nguyên hình ảnh hiện có**

Sử dụng [PPImage::replaceImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) khi bạn muốn thay thế một tài nguyên hình ảnh hiện có. Điều này đặc biệt hữu ích cho các đồ họa chia sẻ như logo.

```php
use aspose\slides\Images;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("input.pptx");
try {
    $imageToReplace = $presentation->getImages()->get_Item(0);

    $replacementImage = Images::fromFile("new-logo.png");
    try {
        $imageToReplace->replaceImage($replacementImage);
    } finally {
        if (!java_is_null($replacementImage)) {
            $replacementImage->dispose();
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Nếu nhiều khung ảnh, nền, master hoặc bố cục sử dụng cùng một tài nguyên hình ảnh, việc thay thế tài nguyên đó sẽ cập nhật tất cả các lần sử dụng. Nếu chỉ một khung ảnh cần thay đổi, hãy gán một hình ảnh khác cho khung đó thay vì thay thế tài nguyên chia sẻ.

`PPImage::replaceImage` cũng cung cấp các phiên bản tải trọng chấp nhận một mảng byte hoặc một [PPImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/) khác.

## **Hướng dẫn thực tiễn quản lý hình ảnh**

### **Kiểm soát kích thước bản trình chiếu**

Các hình ảnh raster lớn có thể làm cho bản trình chiếu trở nên quá lớn. Sử dụng các hình ảnh nguồn với kích thước phù hợp với mục đích hiển thị, tái sử dụng tài nguyên hình ảnh chia sẻ khi có thể, và tránh nhúng các bản sao lặp lại của cùng một đồ họa độ phân giải cao.

Đối với các hình ảnh raster đã được đặt trong khung ảnh, [PictureFillFormat::compressImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/picturefillformat/) có thể giảm dữ liệu hình ảnh dựa trên độ phân giải và cài đặt cắt đã chọn. Đây là xử lý khung ảnh chứ không phải quản lý bộ sưu tập hình ảnh, vì vậy xem [Picture Frame](/slides/vi/php-java/picture-frame/) để biết các thao tác định dạng liên quan.

### **Chọn giữa nội dung nhúng và liên kết**

Việc nhúng làm cho bản trình chiếu di động vì tất cả dữ liệu hình ảnh cần thiết đi kèm với tệp. Liên kết có thể giảm kích thước tệp, nhưng nó tạo ra một phụ thuộc bên ngoài. Chỉ sử dụng liên kết khi phụ thuộc đó chấp nhận được và ổn định.

### **Tái sử dụng thương hiệu chia sẻ**

Đối với các logo, hình mờ, hoặc đồ họa trang trí lặp lại, sử dụng một tài nguyên hình ảnh và tái sử dụng nó. Nếu đồ họa thuộc về thiết kế bản trình chiếu hơn là nội dung slide, hãy đặt nó trên master hoặc layout để các slide thích hợp kế thừa.

### **Giữ tài nguyên SVG có thể di động**

Một SVG tự chứa dễ di chuyển và render nhất quán hơn so với SVG phụ thuộc vào các tệp hoặc tài nguyên mạng bên ngoài. Khi có thể, hãy nhúng các tài nguyên cần thiết trước khi nhập SVG. Chuyển SVG thành các hình dạng chỉ khi các phần tử vector riêng lẻ cần được chỉnh sửa.

### **Sử dụng API hình ảnh hiện đại đa nền tảng**

Đối với mã PHP qua Java mới, sử dụng các API Aspose.Slides [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/) và [Images](https://reference.aspose.com/slides/vi/php-java/aspose.slides/images/) thay vì API công khai legacy dựa trên `java.awt.image.BufferedImage`. Xem [Modern API](/slides/vi/php-java/modern-api/) để biết hướng dẫn di chuyển.

WMF và EMF cần xem xét đặc biệt. Khi các định dạng này được truyền qua một [IImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/iimage/), [ImageCollection::addImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) chuyển đổi metafile thành đại diện PNG raster trước khi chèn. Nếu việc bảo tồn dữ liệu metafile quan trọng, hãy sử dụng phiên bản tải trọng dựa trên stream của [ImageCollection::addImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/imagecollection/) thay thế. Tạo nội dung EMF từ bảng tính hoặc sản phẩm khác là một quy trình tích hợp riêng và nằm ngoài phạm vi của bài viết này.

## **Câu hỏi thường gặp**

**Sự khác nhau giữa bộ sưu tập hình ảnh và khung ảnh là gì?**

Bộ sưu tập hình ảnh lưu trữ các tài nguyên hình ảnh có thể tái sử dụng. Khung ảnh là một hình dạng slide hiển thị một trong những tài nguyên đó và cung cấp các định dạng đặc thù cho hình ảnh như cắt và hiệu ứng.

**Cách tốt nhất để thay thế cùng một logo ở mọi nơi là gì?**

Nếu logo đã được chia sẻ dưới dạng một tài nguyên hình ảnh, hãy thay thế tài nguyên đó bằng [PPImage::replaceImage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ppimage/). Đối với thương hiệu toàn bộ bản trình chiếu, đặt logo trên master hoặc layout cũng có thể giảm nội dung slide trùng lặp.

**Tại sao một hình ảnh liên kết lại biến mất trên máy tính khác?**

Một hình ảnh liên kết phụ thuộc vào tệp hoặc URL bên ngoài. Nếu tài nguyên đó không thể truy cập được từ máy tính khác, hình ảnh liên kết có thể không khả dụng. Nhúng hình ảnh khi bản trình chiếu phải tự chứa.

**Có thể chỉnh sửa SVG được chèn thành các hình dạng PowerPoint không?**

Có. Chuyển đổi SVG bằng [ShapeCollection::addGroupShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addgroupshape/); nhóm kết quả chứa các hình dạng slide có thể chỉnh sửa thay vì một hình ảnh SVG duy nhất.

**Làm thế nào để giữ bản trình chiếu có nhiều hình ảnh mà vẫn nhỏ gọn?**

Tái sử dụng các tài nguyên hình ảnh chia sẻ, tránh các nguồn raster không cần thiết lớn, nén các hình raster phù hợp khi cần, giữ thương hiệu lặp lại trên master hoặc layout, và chỉ sử dụng hình ảnh liên kết khi phụ thuộc bên ngoài được chấp nhận.