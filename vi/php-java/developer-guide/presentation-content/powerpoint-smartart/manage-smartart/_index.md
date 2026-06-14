---
title: Quản lý SmartArt trong bài thuyết trình PowerPoint bằng PHP
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/php-java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Kiểu bố cục
- Thuộc tính ẩn
- Sơ đồ tổ chức
- Sơ đồ tổ chức có hình ảnh
- PowerPoint
- Bài thuyết trình
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho PHP qua Java bằng các mẫu mã rõ ràng, giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và một bố cục. Với Aspose.Slides cho PHP qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức, và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy văn bản từ một đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, duyệt qua [SmartArt::getAllNodes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/#getAllNodes), sau đó đọc [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartshape/#getTextFrame).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.ISmartArt"))) {
        $smartArt = $shape;

        foreach ($smartArt->getAllNodes() as $smartArtNode) {
            foreach ($smartArtNode->getShapes() as $smartArtShape) {
                if (!java_is_null($smartArtShape->getTextFrame())) {
                    echo($smartArtShape->getTextFrame()->getText());
                }
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Thay đổi loại bố cục của một đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);

    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnode/ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục được chọn không hiển thị chúng như các phần tử biểu đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::RadialCycle);

    $smartArtNode = $smartArt->getAllNodes()->addNode();
    $isHidden = $smartArtNode->isHidden();

    if ($isHidden) {
        echo("The node is hidden in the SmartArt data model.");
    }

    $presentation->save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lấy hoặc đặt bố cục biểu đồ tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) và [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ phía trái, phải, hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);

    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tạo biểu đồ tổ chức có hình ảnh**

Biểu đồ tổ chức có hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa khung giữ ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide.

```php
$presentation = new Presentation();
try {
    $smartArt = $presentation->getSlides()->get_Item(0)->getShapes()->addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Phương thức [SmartArt::setReversed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/setreversed/) chuyển hướng biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm thế nào tôi có thể sao chép SmartArt vào cùng một slide hoặc sang bài thuyết trình khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [sao chép hình SmartArt](/slides/vi/php-java/shape-manipulations/) bằng [ShapeCollection::addClone](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/addclone/) hoặc [sao chép toàn bộ slide](/slides/vi/php-java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi có thể render SmartArt thành hình ảnh raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/php-java/convert-powerpoint-to-png/) hoặc toàn bộ bài thuyết trình sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm thế nào tôi có thể tìm một đối tượng SmartArt cụ thể trên một slide nếu có nhiều đối tượng?**

Đặt một giá trị [Shape::getAlternativeText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getalternativetext/) hoặc [Shape::getName](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getname/) đặc trưng trên hình SmartArt, tìm kiếm giá trị đó trong [BaseSlide::getShapes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseslide/#getShapes), và sau đó kiểm tra xem hình khớp có phải là [SmartArt](https://reference.aspose.com/slides/vi/php-java/aspose.slides/smartart/) hay không.