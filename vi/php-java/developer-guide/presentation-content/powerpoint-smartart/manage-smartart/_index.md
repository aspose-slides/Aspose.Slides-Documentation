---
title: Quản lý SmartArt trong Bản trình chiếu PowerPoint bằng PHP
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/php-java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho PHP qua Java bằng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides cho PHP qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng nút, lặp qua [SmartArt::getAllNodes](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/getallnodes/), sau đó đọc [TextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape::getTextFrame](https://reference.aspose.com/slides/php-java/aspose.slides/smartartshape/gettextframe/).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt là hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản có sẵn ra console.

```php
use aspose\slides\Presentation;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->get_Item(0);
    for ($i = 0; $i < java_values($smartArt->getAllNodes()->size()); $i++) {
        $node = $smartArt->getAllNodes()->get_Item($i);
        for ($j = 0; $j < java_values($node->getShapes()->size()); $j++) {
            $nodeShape = $node->getShapes()->get_Item($j);
            if (!java_is_null($nodeShape->getTextFrame())) {
                echo $nodeShape->getTextFrame()->getText() . PHP_EOL;
            }
        }
    }
} finally {
    $presentation->dispose();
}
```

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu. Vị trí và kích thước truyền vào [ShapeCollection::addSmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addsmartart/) được đo bằng điểm. Sử dụng [SmartArt::setLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setlayout/) để thay đổi bố cục.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::BasicBlockList);
    $smartArt->setLayout(SmartArtLayoutType::BasicProcess);

    $presentation->save("ChangeSmartArtLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[SmartArtNode::isHidden](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử sơ đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút vừa thêm. Nó in thông báo nếu nút bị ẩn và lưu sơ đồ.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::RadialCycle);
    $node = $smartArt->getAllNodes()->addNode();
    $isHidden = java_values($node->isHidden());

    if ($isHidden) {
        echo "The node is hidden in the SmartArt data model." . PHP_EOL;
    }

    $presentation->save("CheckSmartArtHiddenProperty.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode::getOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/getorganizationchartlayout/) và [SmartArtNode::setOrganizationChartLayout](https://reference.aspose.com/slides/php-java/aspose.slides/smartartnode/setorganizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo phía trái, phải hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Chỉ mục dựa trên zero `0` chọn nút cấp cao nhất đầu tiên; các nút con của nó sẽ sử dụng sắp xếp đã chọn. Bản trình chiếu đã chỉnh sửa sau đó được lưu.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;
use aspose\slides\OrganizationChartLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(10, 10, 400, 300, SmartArtLayoutType::OrganizationChart);
    $rootNode = $smartArt->getNodes()->get_Item(0);
    $rootNode->setOrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

    $presentation->save("OrganizationChartLayout.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các trình giữ chỗ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/php-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide. Ví dụ này lưu một sơ đồ có các trình giữ chỗ hình ảnh; nó không điền các trình giữ chỗ bằng hình ảnh.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SmartArtLayoutType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $smartArt = $slide->getShapes()->addSmartArt(0, 0, 400, 400, SmartArtLayoutType::PictureOrganizationChart);

    $presentation->save("PictureOrganizationChart.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Chuyển đổi Sơ đồ Di sản thành Nhóm Hình dạng**

Khi hiện đại hóa một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo ban đầu trong PowerPoint 97–2003. Aspose.Slides đại diện cho các sơ đồ di sản này dưới dạng các đối tượng [LegacyDiagram](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/). Sử dụng [LegacyDiagram::convertToGroupShape](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/converttogroupshape/) để chuyển một sơ đồ thành một nhóm hình dạng, cho phép bạn chỉnh sửa các yếu tố hình ảnh riêng lẻ. Tham khảo [LegacyDiagram API Reference](https://reference.aspose.com/slides/php-java/aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [ShapeCollection::remove](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/remove/) để tránh nội dung trùng lặp. Thu thập các sơ đồ di sản vào danh sách trước khi chuyển đổi để việc thêm và xóa hình dạng không làm gián đoạn vòng lặp.

Ví dụ sau mở một bản trình chiếu, tìm kiếm trên mọi slide, chuyển các sơ đồ thành nhóm hình dạng và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("legacy-diagrams.ppt");
try {
    $legacyDiagramType = new JavaClass("com.aspose.slides.ILegacyDiagram");
    for ($i = 0; $i < java_values($presentation->getSlides()->size()); $i++) {
        $slide = $presentation->getSlides()->get_Item($i);
        $legacyDiagrams = [];
        for ($j = 0; $j < java_values($slide->getShapes()->size()); $j++) {
            $shape = $slide->getShapes()->get_Item($j);
            if (java_instanceof($shape, $legacyDiagramType)) {
                $legacyDiagrams[] = $shape;
            }
        }

        foreach ($legacyDiagrams as $legacyDiagram) {
            $groupShape = $legacyDiagram->convertToGroupShape();

            if (!java_is_null($groupShape)) {
                $slide->getShapes()->remove($legacyDiagram);
            }
        }
    }

    $presentation->save("modernized.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Bản trình chiếu đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ di sản đã chuyển đổi, không còn sơ đồ gốc nào còn lại bên cạnh chúng. Mở file PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Phương thức [SmartArt::setReversed](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/setreversed/) chuyển hướng sơ đồ từ trái‑sang‑phải sang phải‑sang‑trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [clone the SmartArt shape](/slides/vi/php-java/shape-manipulations/) bằng [ShapeCollection::addClone](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/addclone/) hoặc [clone the whole slide](/slides/vi/php-java/clone-slides/) chứa SmartArt. Cả hai cách đều bảo toàn kích thước, vị trí và định dạng.

**Làm sao để render SmartArt thành ảnh raster để xem trước hoặc xuất ra web?**

[Render the slide](/slides/vi/php-java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt sẽ được render như một phần của slide.

**Làm thế nào tìm một đối tượng SmartArt cụ thể trên một slide nếu có nhiều đối tượng?**

Sử dụng [Shape::setAlternativeText](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setalternativetext/) hoặc [Shape::setName](https://reference.aspose.com/slides/php-java/aspose.slides/shape/setname/) để gán văn bản thay thế hoặc tên đặc trưng cho hình dạng SmartArt, tìm giá trị đó trong [BaseSlide::getShapes](https://reference.aspose.com/slides/php-java/aspose.slides/baseslide/#getShapes), và sau đó kiểm tra xem hình dạng khớp có phải là một [SmartArt](https://reference.aspose.com/slides/php-java/aspose.slides/smartart/) không.