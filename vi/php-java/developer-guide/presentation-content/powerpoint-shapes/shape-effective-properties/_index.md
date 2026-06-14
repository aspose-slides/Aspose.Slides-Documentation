---
title: Lấy Thuộc tính Hiệu lực của Hình dạng từ Bản trình bày trong PHP
linktitle: Thuộc tính Hiệu lực
type: docs
weight: 50
url: /vi/php-java/shape-effective-properties/
keywords:
- thuộc tính hình dạng
- thuộc tính camera
- bộ đèn chiếu sáng
- hình dạng bo góc
- khung văn bản
- kiểu văn bản
- chiều cao phông chữ
- định dạng nền
- PowerPoint
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá cách Aspose.Slides cho PHP thông qua Java tính toán và áp dụng các thuộc tính hiệu lực của hình dạng để hiển thị PowerPoint một cách chính xác."
---
## **Tổng quan**

Chủ đề này giải thích sự khác nhau giữa các thuộc tính **cục bộ** và **hiệu lực**. Giá trị cục bộ là những giá trị được đặt trực tiếp ở một cấp độ định dạng cụ thể, chẳng hạn như:

1. Thuộc tính phần trên một slide.  
1. Kiểu văn bản hình dạng mẫu trên bố cục hoặc slide chủ, khi hình dạng khung văn bản của phần có một kiểu.  
1. Cài đặt văn bản toàn cục trong một bản trình bày.

Giá trị cục bộ có thể được xác định hoặc bỏ qua ở bất kỳ cấp độ nào. Khi Aspose.Slides cần định dạng “như đã hiển thị” cuối cùng, nó giải quyết chuỗi kế thừa và trả về các giá trị **hiệu lực**. Bạn có thể lấy chúng bằng cách gọi phương thức `getEffective` trên đối tượng định dạng cục bộ.

Ví dụ dưới đây cho thấy cách lấy các giá trị hiệu lực. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có khung văn bản và ít nhất một phần.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $localTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $effectiveTextFrameFormat = $localTextFrameFormat->getEffective();

    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $portion = $paragraph->getPortions()->get_Item(0);

    $localPortionFormat = $portion->getPortionFormat();
    $effectivePortionFormat = $localPortionFormat->getEffective();
} finally {
    $presentation->dispose();
}
```

{{% alert color="primary" %}}
Dữ liệu định dạng hiệu lực đại diện cho định dạng hiện tại đã được tính toán sau khi áp dụng kế thừa. Trong triển khai hiện tại, một số đối tượng dữ liệu hiệu lực được trả về bởi các phương thức như [PortionFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/geteffective/) có thể được lưu trong bộ nhớ cache nội bộ. Gọi lại `getEffective` sau khi thay đổi định dạng cha hoặc kế thừa sẽ làm làm mới dữ liệu đã cache, và đối tượng đã lấy trước đó có thể không còn phản ánh trạng thái trước nữa. Nếu bạn cần bảo lưu các giá trị hiệu lực để sử dụng lại sau, hãy sao chép các thuộc tính cần thiết, chẳng hạn như chiều cao phông chữ, màu nền, kiểu phông hoặc căn lề, vào đối tượng dữ liệu riêng của bạn.
{{% /alert %}}

## **Lấy Thuộc tính Hiệu lực của Camera**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của một camera. Dữ liệu hiệu lực được trả về bởi [ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/) chứa các thuộc tính camera cuối cùng cho một [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho camera. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $camera = $threeDEffectiveData->getCamera();
    $cameraType = $camera->getCameraType();
    $fieldOfViewAngle = $camera->getFieldOfViewAngle();
    $zoom = $camera->getZoom();

    echo "= Effective camera properties =" . PHP_EOL;
    echo "Type: " . $cameraType . PHP_EOL;
    echo "Field of view: " . $fieldOfViewAngle . PHP_EOL;
    echo "Zoom: " . $zoom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Light Rig**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của một light rig. Dữ liệu hiệu lực được trả về bởi [ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/) chứa các thuộc tính light rig cuối cùng cho một [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho light rig. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $lightRig = $threeDEffectiveData->getLightRig();
    $lightType = $lightRig->getLightType();
    $direction = $lightRig->getDirection();

    echo "= Effective light rig properties =" . PHP_EOL;
    echo "Type: " . $lightType . PHP_EOL;
    echo "Direction: " . $direction . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Độ Bo Hình**

Aspose.Slides cho phép bạn lấy các thuộc tính hiệu lực của một độ bo hình. Dữ liệu hiệu lực được trả về bởi [ThreeDFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/geteffective/) chứa các thuộc tính relief mặt cuối cùng cho một [ThreeDFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/threedformat/).

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính hiệu lực cho độ bo trên của một hình dạng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên có định dạng 3D.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $threeDEffectiveData = $shape->getThreeDFormat()->getEffective();
    $bevelTop = $threeDEffectiveData->getBevelTop();
    $bevelType = $bevelTop->getBevelType();
    $bevelWidth = $bevelTop->getWidth();
    $bevelHeight = $bevelTop->getHeight();

    echo "= Effective shape's top face relief properties =" . PHP_EOL;
    echo "Type: " . $bevelType . PHP_EOL;
    echo "Width: " . $bevelWidth . PHP_EOL;
    echo "Height: " . $bevelHeight . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Khung Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của một khung văn bản. Dữ liệu hiệu lực được trả về bởi [TextFrameFormat.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/geteffective/) chứa các thuộc tính định dạng khung văn bản.

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính định dạng khung văn bản hiệu lực. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có khung văn bản.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $effectiveTextFrameFormat = $shape->getTextFrame()->getTextFrameFormat()->getEffective();
    $anchoringType = $effectiveTextFrameFormat->getAnchoringType();
    $autofitType = $effectiveTextFrameFormat->getAutofitType();
    $textVerticalType = $effectiveTextFrameFormat->getTextVerticalType();
    $marginLeft = $effectiveTextFrameFormat->getMarginLeft();
    $marginTop = $effectiveTextFrameFormat->getMarginTop();
    $marginRight = $effectiveTextFrameFormat->getMarginRight();
    $marginBottom = $effectiveTextFrameFormat->getMarginBottom();

    echo "Anchoring type: " . $anchoringType . PHP_EOL;
    echo "Autofit type: " . $autofitType . PHP_EOL;
    echo "Text vertical type: " . $textVerticalType . PHP_EOL;
    echo "Margins" . PHP_EOL;
    echo "   Left: " . $marginLeft . PHP_EOL;
    echo "   Top: " . $marginTop . PHP_EOL;
    echo "   Right: " . $marginRight . PHP_EOL;
    echo "   Bottom: " . $marginBottom . PHP_EOL;
} finally {
    $presentation->dispose();
}
```

## **Lấy Thuộc tính Hiệu lực của Kiểu Văn bản**

Sử dụng Aspose.Slides, bạn có thể lấy các thuộc tính hiệu lực của một kiểu văn bản. Dữ liệu hiệu lực được trả về bởi [TextStyle.getEffective](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textstyle/geteffective/) chứa các thuộc tính kiểu văn bản.

Mẫu mã dưới đây cho thấy cách lấy các thuộc tính kiểu văn bản hiệu lực. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có khung văn bản.

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->get_Item(0);

    $textFrameFormat = $shape->getTextFrame()->getTextFrameFormat();
    $textStyle = $textFrameFormat->getTextStyle();
    $effectiveTextStyle = $textStyle->getEffective();
    $levelCount = 9;

    for ($levelIndex = 0; $levelIndex < $levelCount; $levelIndex++) {
        $effectiveStyleLevel = $effectiveTextStyle->getLevel($levelIndex);
        $depth = $effectiveStyleLevel->getDepth();
        $indent = $effectiveStyleLevel->getIndent();
        $alignment = $effectiveStyleLevel->getAlignment();
        $fontAlignment = $effectiveStyleLevel->getFontAlignment();

        echo "= Effective paragraph formatting for style level #" . $levelIndex . " =" . PHP_EOL;

        echo "Depth: " . $depth . PHP_EOL;
        echo "Indent: " . $indent . PHP_EOL;
        echo "Alignment: " . $alignment . PHP_EOL;
        echo "Font alignment: " . $fontAlignment . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

## **Lấy Giá trị Chiều cao Phông chữ Hiệu lực**

Sử dụng Aspose.Slides, bạn có thể lấy chiều cao phông chữ hiệu lực. Mã dưới đây minh họa cách chiều cao phông chữ hiệu lực của một phần thay đổi sau khi các giá trị chiều cao phông chữ cục bộ được đặt ở các cấp độ cấu trúc bản trình bày khác nhau.

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 100, 100, 400, 75, false);
    $autoShape->addTextFrame("");

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $firstPortion = new Portion("Sample text with first portion");
    $secondPortion = new Portion(" and second portion.");

    $paragraph->getPortions()->add($firstPortion);
    $paragraph->getPortions()->add($secondPortion);

    $firstEffectivePortionFormat = $firstPortion->getPortionFormat()->getEffective();
    $secondEffectivePortionFormat = $secondPortion->getPortionFormat()->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height just after creation:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $defaultStyleLevel = $presentation->getDefaultTextStyle()->getLevel(0);
    $defaultPortionFormat = $defaultStyleLevel->getDefaultPortionFormat();
    $defaultPortionFormat->setFontHeight(24);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting the presentation default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $paragraphDefaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $paragraphDefaultPortionFormat->setFontHeight(40);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting paragraph default font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $firstPortionFormat->setFontHeight(55);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #0 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $secondPortionFormat->setFontHeight(18);
    $firstEffectivePortionFormat = $firstPortionFormat->getEffective();
    $secondEffectivePortionFormat = $secondPortionFormat->getEffective();

    $firstFontHeight = $firstEffectivePortionFormat->getFontHeight();
    $secondFontHeight = $secondEffectivePortionFormat->getFontHeight();
    echo "Effective font height after setting portion #1 font height:" . PHP_EOL;
    echo "Portion #0: " . $firstFontHeight . PHP_EOL;
    echo "Portion #1: " . $secondFontHeight . PHP_EOL;

    $presentation->save("SetLocalFontHeightValues.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Lấy Định dạng Điền Hiệu lực cho Bảng**

Sử dụng Aspose.Slides, bạn có thể lấy định dạng điền hiệu lực cho các phần khác nhau của bảng. Dữ liệu hiệu lực được trả về bởi các đối tượng định dạng chứa các thuộc tính của [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/). Định dạng ô có độ ưu tiên cao hơn định dạng hàng, định dạng hàng có độ ưu tiên cao hơn định dạng cột, và định dạng cột có độ ưu tiên cao hơn định dạng toàn bảng.

Do đó, các thuộc tính [CellFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cellformat/) hiệu lực được dùng để vẽ ô bảng. Mẫu mã dưới đây cho thấy cách lấy định dạng điền hiệu lực cho các phần khác nhau của bảng. Nó giả định rằng hình dạng đầu tiên trên slide đầu tiên là một [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/).

```php
$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $table = $slide->getShapes()->get_Item(0);
    $tableFormatEffective = $table->getTableFormat()->getEffective();

    $row = $table->getRows()->get_Item(0);
    $rowFormatEffective = $row->getRowFormat()->getEffective();

    $column = $table->getColumns()->get_Item(0);
    $columnFormatEffective = $column->getColumnFormat()->getEffective();

    $cell = $table->get_Item(0, 0);
    $cellFormatEffective = $cell->getCellFormat()->getEffective();

    $tableFillFormatEffective = $tableFormatEffective->getFillFormat();
    $rowFillFormatEffective = $rowFormatEffective->getFillFormat();
    $columnFillFormatEffective = $columnFormatEffective->getFillFormat();
    $cellFillFormatEffective = $cellFormatEffective->getFillFormat();
} finally {
    $presentation->dispose();
}
```

## **Câu hỏi thường gặp**

**Phương thức `getEffective` có trả về một bản sao không?**

Không phải luôn luôn. Dữ liệu hiệu lực đại diện cho định dạng đã được tính toán sau khi áp dụng kế thừa, nhưng một số đối tượng dữ liệu hiệu lực có thể được lưu trong bộ nhớ cache nội bộ. Lần gọi `getEffective` tiếp theo có thể tính lại định dạng và làm mới dữ liệu đã cache, vì vậy đối tượng đã lấy trước không nên được coi là một bản sao bền vững.

**Khi nào tôi nên đọc lại các thuộc tính hiệu lực?**

Gọi `getEffective` lại sau khi thay đổi định dạng cục bộ, kiểu cha, định dạng bố cục, định dạng master hoặc các mặc định ở cấp độ bản trình bày. Lần gọi tiếp theo sẽ đánh giá lại cây định dạng và trả về kết quả hiệu lực hiện tại.

**Việc thay đổi hoặc xóa một slide bố cục/master có ảnh hưởng đến các thuộc tính hiệu lực đã được lấy trước không?**

Có, nhưng thay đổi sẽ được phản ánh ở lần gọi `getEffective` tiếp theo. Nếu nguồn định dạng cha bị thay đổi hoặc xóa, dữ liệu hiệu lực đã lấy trước có thể trở nên lỗi thời. Khi `getEffective` được gọi lại, Aspose.Slides sẽ đánh giá lại cây định dạng và các phông chữ, màu sắc, kích thước hoặc giá trị khác có thể thay đổi.

**Tôi có thể sửa đổi các giá trị thông qua các đối tượng dữ liệu hiệu lực không?**

Không. Các đối tượng dữ liệu hiệu lực chỉ cung cấp các giá trị đã được tính toán. Thực hiện thay đổi trong các đối tượng định dạng cục bộ, sau đó lấy lại các giá trị hiệu lực.

**Nếu một thuộc tính không được đặt ở mức hình dạng, cũng không ở bố cục/master, cũng không ở cài đặt toàn cục thì sao?**

Giá trị hiệu lực sẽ được xác định bởi cơ chế mặc định, bao gồm các giá trị mặc định của PowerPoint và Aspose.Slides. Giá trị đã giải quyết đó sẽ trở thành một phần của dữ liệu hiệu lực hiện tại.

**Từ một giá trị phông chữ hiệu lực, tôi có thể biết được cấp độ nào đã cung cấp kích thước hoặc kiểu chữ không?**

Không trực tiếp. Dữ liệu hiệu lực trả về giá trị cuối cùng. Để tìm nguồn, hãy kiểm tra các giá trị cục bộ ở mức phần, đoạn, khung văn bản và các kiểu văn bản ở bố cục, master và bản trình bày để xem nơi định nghĩa rõ ràng đầu tiên xuất hiện.

**Tại sao đôi khi các giá trị hiệu lực trông giống hệt các giá trị cục bộ?**

Bởi vì giá trị cục bộ đã trở thành giá trị cuối cùng (không cần kế thừa ở cấp cao hơn). Trong các trường hợp này, giá trị hiệu lực trùng với giá trị cục bộ.

**Khi nào tôi nên sử dụng các thuộc tính hiệu lực, và khi nào chỉ làm việc với các thuộc tính cục bộ?**

Sử dụng dữ liệu hiệu lực khi bạn cần kết quả “như đã hiển thị” sau khi tất cả các cấp kế thừa được áp dụng, chẳng hạn để đồng bộ màu sắc, thụt lề hoặc kích thước. Nếu bạn cần bảo lưu các giá trị này bất chấp các thay đổi định dạng sau này, hãy sao chép các thuộc tính cần thiết vào đối tượng của riêng bạn. Nếu bạn cần thay đổi định dạng ở một cấp độ cụ thể, hãy sửa đổi các thuộc tính cục bộ và sau đó, nếu cần, đọc lại dữ liệu hiệu lực để xác minh kết quả.