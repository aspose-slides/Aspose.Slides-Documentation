---
title: Thêm các Phương Trình Toán Học vào Bản Trình Chiếu PowerPoint trong PHP
linktitle: Phương Trình Toán Học PowerPoint
type: docs
weight: 80
url: /vi/php-java/powerpoint-math-equations/
keywords:
- phương trình toán học
- ký hiệu toán học
- công thức toán học
- văn bản toán học
- thêm phương trình toán học
- thêm ký hiệu toán học
- thêm công thức toán học
- thêm văn bản toán học
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho PHP qua Java, hỗ trợ OMML, các điều khiển định dạng, và các mẫu mã PHP rõ ràng."
---
## **Tổng quan**

PowerPoint lưu các công thức dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho PHP qua Java, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường thêm công thức từ **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation đã được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên trang trình chiếu:

![Một slide PowerPoint chứa một công thức toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape), là hình chứa công thức.
- [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/php-java/aspose.slides/mathblock/) .

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) và các phương thức fluent từ [MathElementBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) để giữ mã ngắn gọn và dễ đọc.

Xem [Xuất công thức toán học từ bài thuyết trình trong PHP qua Java](/slides/vi/php-java/exporting-math-equations/).

## **Tạo công thức**

Ví dụ này sử dụng [addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) để tạo một hình toán học và thêm định lý Pythagoras:

![Công thức c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equation = (new MathematicalText("c"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("a"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("b"))->setSuperscript("2"));

    $mathParagraph->add($equation);

    $presentation->save("pythagorean-theorem.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/php-java/aspose.slides/shapecollection/#addMathShape) tạo một hình đã chứa sẵn một đoạn toán học. Truy cập [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/) đầu tiên, gọi [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), và thêm các khối hoặc phần tử toán học vào đó.
{{% /alert %}}

## **Thêm phân số**

Sử dụng [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#divide) để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/).

![Một phân số nghiêng hiển thị một chia cho x](powerpoint-math-equations_4.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $fraction = (new MathematicalText("1"))
        - >divide("x", MathFractionTypes::Skewed);

    $mathParagraph->add(new MathBlock($fraction));

    $presentation->save("fraction.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Đối với phân số chồng, sử dụng [MathFractionTypes::Bar](https://reference.aspose.com/slides/php-java/aspose.slides/mathfractiontypes/#Bar):

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Thêm căn bậc**

Sử dụng [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#radical) để tạo căn bậc hai, căn bậc ba hoặc các căn bậc khác. Phần tử hiện tại trở thành cơ sở, và đối số trở thành bậc.

![Biểu thức căn bậc n với x dưới dấu căn](powerpoint-math-equations_5.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $radical = (new MathematicalText("x"))
        - >radical("n");

    $mathParagraph->add(new MathBlock($radical));

    $presentation->save("radical.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Hiển thị hoặc Ẩn bậc của căn bậc hai**

Căn bậc hai có thể hiển thị số 2 rõ ràng hoặc sử dụng ký hiệu chuẩn √x. Phương thức [setHideDegree](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/#setHideDegree) của [MathRadical](https://reference.aspose.com/slides/php-java/aspose.slides/mathradical/) kiểm soát dạng nào hiển thị. Cả hai dạng đều giữ bậc 2 và radicand x trong công thức có thể chỉnh sửa.

![Cùng một căn bậc hai với bậc hiển thị ở bên trái và ẩn ở bên phải](square-root-degree.png)

Ví dụ lưu cùng một căn bậc hai hai lần. Trong `visible-degree.pptx`, số 2 hiển thị. Trong `hidden-degree.pptx`, nó được ẩn.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $radical = (new MathematicalText("x"))->radical("2");

    $shape = $slide->getShapes()->addMathShape(20, 20, 200, 100);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getMathParagraph()->add(new MathBlock($radical));

    $radical->setHideDegree(false);
    $presentation->save("visible-degree.pptx", SaveFormat::Pptx);

    $radical->setHideDegree(true);
    $presentation->save("hidden-degree.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Thêm hàm và giới hạn**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) hoặc [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathlimit/) hoặc sử dụng [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setLowerLimit).

![Giới hạn của x khi x tiến tới vô cực](powerpoint-math-equations_8.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $limit = (new MathematicalText("lim"))
        - >setLowerLimit("x\u{2192}\u{221E}")
        - >function("x");

    $mathParagraph->add(new MathBlock($limit));

    $presentation->save("functions-and-limits.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại và gọi [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#function) với đối số của nó:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Thêm toán tử N-ary và tích phân**

Sử dụng [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#nary) cho các tổng, hợp, giao và các toán tử lớn khác. Sử dụng [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral) cho các tích phân. Cả hai phương thức cho phép bạn đặt giới hạn dưới và trên.

![Một tổng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $summationBase = (new MathematicalText("x"))
        - >setSuperscript("k")
        - >join((new MathematicalText("a"))->setSuperscript("n-k"));

    $summation = $summationBase->nary(MathNaryOperatorTypes::Summation, "k=0", "n");

    $mathParagraph->add(new MathBlock($summation));

    $presentation->save("nary-operators.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

Toán tử N-ary dành cho các toán tử lớn có tùy chọn giới hạn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) và ghép vào biểu thức.

Đối với một tích phân, sử dụng [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#integral):

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Thêm ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) cho các hàng và cột. Ma trận không bao gồm ngoặc vuông theo mặc định, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, vuông hoặc ngoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $matrix = new MathMatrix(2, 3);
    $matrix->set_Item(0, 0, new MathematicalText("1"));
    $matrix->set_Item(0, 1, new MathematicalText("x"));
    $matrix->set_Item(1, 0, new MathematicalText("x"));
    $matrix->set_Item(1, 1, new MathematicalText("2"));
    $matrix->set_Item(1, 2, new MathematicalText("y"));

    $mathParagraph->add(new MathBlock($matrix));

    $presentation->save("matrix.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Chỉnh sửa ma trận hiện có**

Giả sử một bài học đại số tuyến tính bắt đầu với ma trận hệ số trong `matrix.pptx`, được lưu bởi ví dụ trước. Đối với bài tập tiếp theo, giữ lại công thức đầu tiên, thay thế công thức thứ hai bằng hai công thức mới, và sửa đổi bộ biến. Mở ma trận hiện có qua [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) để giữ các hệ số vẫn còn áp dụng.

![Ma trận hệ số hai hàng gốc với các mục 1, x và một ô trống ở hàng đầu, và x, 2, y ở hàng thứ hai](matrix-before-edit.png)

Chỉ số hàng và cột bắt đầu từ zero và tham chiếu tới ma trận tại thời điểm mỗi lần gọi. Chèn một hàng trước chỉ số 1 sẽ đẩy hàng thứ hai gốc sang chỉ số 2. Chèn sau chỉ số 2 sau đó sẽ thêm một hàng. Xóa hàng 2 sẽ loại bỏ công thức thứ hai gốc và di chuyển hàng đã thêm lên một vị trí. Các cột dịch chuyển tương tự.

```php
use aspose\slides\MathematicalText;
use aspose\slides\MathHorizontalAlignment;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("matrix.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $block = $portion->getMathParagraph()->get_Item(0);
    $matrix = $block->get_Item(0);

    $matrix->insertRowBefore(1);
    $matrix->insertRowAfter(2);
    $matrix->deleteRow(2);

    $matrix->insertColumnBefore(1);
    $matrix->insertColumnAfter(3);
    $matrix->deleteColumn(3);

    // Các ô mới ban đầu là null. Đặt các hệ số khác không trước tiên.
    $matrix->set_Item(1, 0, new MathematicalText("12"));
    $matrix->set_Item(1, 1, new MathematicalText("1"));
    $matrix->set_Item(2, 2, new MathematicalText("10"));
    $matrix->set_Item(2, 3, new MathematicalText("1"));
    $rowCount = java_values($matrix->getRowCount());
    $columnCount = java_values($matrix->getColumnCount());
    for ($row = 0; $row < $rowCount; $row++) {
        for ($column = 0; $column < $columnCount; $column++) {
            $coefficient = $matrix->get_Item($row, $column);
            if (java_is_null($coefficient)) {
                $matrix->set_Item($row, $column, new MathematicalText("0"));
            }
        }
    }

    $matrix->setColumnAlignment(0, MathHorizontalAlignment::Left);
    $matrix->setColumnsAlignment(1, 3, MathHorizontalAlignment::Right);

    $presentation->save("updated-matrix.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

[setColumnAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnAlignment) căn lề cột đầu tiên sang trái. [setColumnsAlignment](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/#setColumnsAlignment) căn ba cột liên tiếp sang phải, bắt đầu từ chỉ số 1. Trong `updated-matrix.pptx`, ma trận có ba công thức và bốn biến. Các hệ số hàng đầu gốc `1` và `x` giờ xuất hiện ở cột đầu tiên và cột thứ ba.

![Ma trận ba hàng đã cập nhật hiển thị các hàng 1, 0, x, 0; 12, 1, 0, 0; và 0, 0, 10, 1](matrix-after-edit.png)

## **Thêm mảng công thức**

Sử dụng [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toMathArray) khi bạn cần các công thức căn chỉnh hoặc một ngăn xếp dọc các biểu thức.

![Một mảng toán học dọc với x trên y](powerpoint-math-equations_11.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 140);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $equationArray = (new MathematicalText("x"))
        - >join("y")
        - >toMathArray();

    $mathParagraph->add(new MathBlock($equationArray));

    $presentation->save("equation-array.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Căn chỉnh mảng với các phần tử xung quanh**

[setBaseJustification](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setBaseJustification) kiểm soát việc căn dọc của một mảng so với các phần tử toán học bên cạnh nó. Ví dụ dưới so sánh việc căn với hàng đầu, trung tâm của mảng và hàng cuối.

Ví dụ sau tạo ba mảng giống hệt nhau, mỗi mảng có ba hàng và các phần tử lân cận `A=` và `=B`. Toàn bộ văn bản toán học sử dụng Cambria Math cỡ 24 điểm. Chỉ việc căn mảng thay đổi.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$alignments = ["Top" => MathVerticalAlignment::Top, "Center" => MathVerticalAlignment::Center, "Bottom" => MathVerticalAlignment::Bottom];
$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(780, 200, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);
    $x = 20;
    foreach ($alignments as $name => $alignment) {
        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $x, 10, 240, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($name);
        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(16);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $mathShape = $slide->getShapes()->addMathShape($x, 60, 240, 130);
        $mathShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification($alignment);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $x += 260;
    }
    $presentation->save("equation-array-alignment.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

So sánh dưới đây hiển thị bản thuyết trình đã lưu trong PowerPoint. Lưu ý vị trí của `A=` và `=B` bên cạnh mỗi mảng.

![Các mảng công thức trong PowerPoint với căn trên, trung tâm và dưới và các phần tử lân cận giống nhau](equation-array-alignment.png)

### **Cấu hình khoảng cách hàng**

[setRowSpacingRule](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacingRule) chọn quy tắc khoảng cách cho các hàng trong mảng. [setRowSpacing](https://reference.aspose.com/slides/php-java/aspose.slides/matharray/#setRowSpacing) cung cấp giá trị số cho quy tắc khoảng cách cụ thể và bị bỏ qua bởi các quy tắc mặc định.

Đối với khoảng cách chính xác, giá trị được đo bằng điểm. Đối với khoảng cách tỷ lệ, nó được đo bằng nửa dòng: giá trị `3` trong ví dụ tương đương 1,5 dòng. Đặt cả hai thuộc tính khi chỉ định một giá trị cụ thể; việc thay đổi chỉ số mà không thay đổi quy tắc không có hiệu lực.

Ví dụ dưới lưu năm bản thuyết trình với cùng các công thức, căn chỉnh và cài đặt phông chữ. Ba bản đầu dùng chế độ mặc định; hai bản cuối hiển thị các giá trị cụ thể.

```php
use aspose\slides\FontData;
use aspose\slides\MathArray;
use aspose\slides\MathBlock;
use aspose\slides\MathJustification;
use aspose\slides\MathRowSpacingRule;
use aspose\slides\MathVerticalAlignment;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$settings = [
    "SingleLineGap" => [MathRowSpacingRule::SingleLineGap, 0],
    "OneAndAHalfLineGap" => [MathRowSpacingRule::OneAndAHalfLineGap, 0],
    "TwoLineGap" => [MathRowSpacingRule::TwoLineGap, 0],
    "Exactly" => [MathRowSpacingRule::Exactly, 20],
    "Multiple" => [MathRowSpacingRule::Multiple, 3],
];

foreach ($settings as $name => [$rule, $spacing]) {
    $presentation = new Presentation();
    try {
        $mathShape = $presentation->getSlides()->get_Item(0)->getShapes()->addMathShape(20, 20, 600, 300);
        $paragraph = $mathShape->getTextFrame()->getParagraphs()->get_Item(0);
        $paragraph->getParagraphFormat()->setSpaceBefore(0);
        $paragraph->getParagraphFormat()->setSpaceAfter(0);
        $mathParagraph = $paragraph->getPortions()->get_Item(0)->getMathParagraph();
        $mathParagraph->setJustification(MathJustification::LeftJustified);

        $firstRow = $createText("x+y=3");
        $equationArray = new MathArray($firstRow);
        foreach (["x-y=1", "x=2"] as $value) {
            $row = $createText($value);
            $equationArray->getArguments()->add($row);
        }
        $equationArray->setBaseJustification(MathVerticalAlignment::Center);
        $equationArray->setRowSpacingRule($rule);
        $equationArray->setRowSpacing($spacing);
        $leftText = $createText("A=");
        $rightText = $createText("=B");
        $equation = (new MathBlock($leftText))->join($equationArray)->join($rightText);
        $mathParagraph->add($equation);
        $presentation->save("equation-array-$name.pptx", SaveFormat::Pptx);
    } finally {
        $presentation->dispose();
    }
}
```

Khoảng cách hàng của mảng riêng biệt với khoảng cách đoạn văn. [setSpaceBefore](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceBefore) và [setSpaceAfter](https://reference.aspose.com/slides/php-java/aspose.slides/paragraphformat/#setSpaceAfter) thêm không gian quanh đoạn văn chứa, không phải giữa các hàng của mảng. Tương tự, [MathParagraph::setJustification](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#setJustification) định vị toàn bộ đoạn toán học theo chiều ngang; nó không thay thế cài đặt căn dọc của mảng.

## **Thêm hàm lượng giác**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#asArgumentOfFunction) khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $cosine = (new MathematicalText("2x"))
        - >asArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

    $mathParagraph->add(new MathBlock($cosine));

    $presentation->save("trigonometric-function.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Thêm chỉ số xuống và chỉ số lên**

Sử dụng các trợ giúp chỉ số xuống và chỉ số lên cho các chỉ mục và lũy thừa. Khi các chỉ mục phải xuất hiện ở phía bên trái của cơ sở, sử dụng [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Một ký tự Y in hoa với chỉ số xuống 1 phía bên trái và chỉ số lên n](powerpoint-math-equations_9.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $scripts = (new MathematicalText("Y"))
        - >setSubSuperscriptOnTheLeft("1", "n");

    $mathParagraph->add(new MathBlock($scripts));

    $presentation->save("subscript-superscript.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Thêm dấu phân cách**

Sử dụng [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#enclose) để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được phân tách bằng các thanh dọc](powerpoint-math-equations_13.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $delimiter = (new MathematicalText("x"))
        - >join("y")
        - >join("z")
        - >enclose(new Java("java.lang.Character", "<"), new Java("java.lang.Character", ">"));
    $delimiter->setSeparatorCharacter(new Java("java.lang.Character", "|"));

    $mathParagraph->add(new MathBlock($delimiter));

    $presentation->save("delimiters.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Kích thước và căn chỉnh dấu phân cách**

Pass `true` to [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) to let the parentheses grow around a tall operand, or pass `false` to keep them at their normal size. Use [setDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimiter/#setDelimiterShape) with one of two [MathDelimiterShape](https://reference.aspose.com/slides/php-java/aspose.slides/mathdelimitershape/) values. `Centered` centers the parentheses on the math axis, which runs through the middle of the equals sign. `Match` aligns them with the enclosed content. Both settings affect only the delimiters. The expression inside stays the same.

The example places a fraction in the exponent of `x` so the expression extends farther above the baseline than below it. All four equations use the same parentheses and font settings.

```php
use aspose\slides\MathDelimiterShape;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $opening = new Java("java.lang.Character", "(");
    $closing = new Java("java.lang.Character", ")");
    for ($row = 0; $row < 2; $row++) {
        for ($column = 0; $column < 2; $column++) {
            $fraction = (new MathematicalText("a + b"))->divide("c + d");
            $power = (new MathematicalText("x"))->setSuperscript($fraction);
            $delimiter = $power->enclose($opening, $closing);
            $delimiter->setGrowToMatchOperandHeight($row === 0);
            $delimiter->setDelimiterShape($column === 0 ? MathDelimiterShape::Centered : MathDelimiterShape::Match);

            $mathShape = $slide->getShapes()->addMathShape(20 + 330 * $column, 20 + 120 * $row, 300, 100);
            $portion = $mathShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $portion->getPortionFormat()->setFontHeight(32);
            $equation = (new MathematicalText("y = "))->join($delimiter);
            $portion->getMathParagraph()->add($equation);
        }
    }
    $presentation->save("delimiter-sizing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

In PowerPoint, compare the rows to see the effect of growth. In the top row, the parentheses grow to enclose the exponent and look alike for both shapes. In the bottom row, growth is off. The smaller parentheses on the left (`Centered`) align with the equals sign, while those on the right (`Match`) sit higher around the expression.

![Bốn công thức trong PowerPoint với dấu phân cách mở rộng ở trên và tắt ở dưới, và Centered ở bên trái và Match ở bên phải](delimiter-sizing.png)

## **Thêm khung viền**

Call [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#toBorderBox) on a fraction to frame the entire expression. The returned [MathBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/) shows all four sides by default. Use [setHideTop](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideLeft), and [setHideRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setHideRight) to remove individual sides.

The example places six copies of the same fraction on one slide. To show cancellation, hide all four sides and pass `true` to [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) for a rising diagonal (↗) or [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) for a falling diagonal (↘). You can also use [setStrikethroughHorizontal](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) or [setStrikethroughVertical](https://reference.aspose.com/slides/php-java/aspose.slides/mathborderbox/#setStrikethroughVertical) with any combination of visible sides.

```php
use aspose\slides\MathBlock;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SlideSizeScaleType;

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(540, 220, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $addFraction = function ($x, $y, $hideBorder) use ($slide) {
        $fraction = (new MathematicalText("x+1"))->divide("y+2");
        $box = $fraction->toBorderBox();
        $box->setHideTop($hideBorder);
        $box->setHideBottom($hideBorder);
        $box->setHideLeft($hideBorder);
        $box->setHideRight($hideBorder);

        $shape = $slide->getShapes()->addMathShape($x, $y, 160, 90);
        $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $portion->getPortionFormat()->setFontHeight(28);
        $mathBlock = new MathBlock($box);
        $portion->getMathParagraph()->add($mathBlock);
        return $box;
    };

    $addFraction(10, 10, false);

    $partial = $addFraction(190, 10, false);
    $partial->setHideTop(true);
    $partial->setHideRight(true);

    $addFraction(370, 10, true)->setStrikethroughBottomLeftToTopRight(true);
    $addFraction(10, 120, true)->setStrikethroughTopLeftToBottomRight(true);
    $addFraction(190, 120, true)->setStrikethroughHorizontal(true);
    $addFraction(370, 120, false)->setStrikethroughVertical(true);

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Sáu phân số có thể chỉnh sửa trong PowerPoint. Hàng trên: viền đầy đủ, các mặt dưới và trái, đường chéo lên. Hàng dưới: đường chéo xuống, gạch ngang, gạch dọc với viền đầy đủ](border-box-fractions.png)

Trên phân số này, đường gạch ngang chồng lên thanh phân số. Đường gạch dọc cắt cả tử và mẫu trong khi viền bao quanh vẫn hiển thị. Các đường này trang trí toàn bộ biểu thức. Gạch ngang thường áp dụng cho các ký tự trong một đoạn văn bản. Sau khi mở lại bản thuyết trình trong PowerPoint, bạn vẫn có thể chỉnh sửa tử và mẫu độc lập.

## **Kiểm soát hiển thị và bố cục với phần tử ảo**

Wrap an expression in [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) to control its visibility and the space it contributes to an equation independently. The [MathPhantom](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/) methods control the following:

| Phương thức | Hiệu ứng |
| --- | --- |
| [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) | Đặt `false` để ẩn biểu thức. Kích thước của nó vẫn đóng góp vào bố cục trừ khi các phương thức tương ứng bên dưới nhận `true`. |
| [setZeroWidth](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroWidth) | Coi độ rộng ngang của biểu thức là zero, cho phép các phần tử lân cận di chuyển gần nhau hơn. |
| [setZeroAsc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroAsc) | Coi phần lên, chiều cao trên đường baseline, là zero. Điều này có thể giảm không gian dành cho phía trên các phần tử lân cận. |
| [setZeroDesc](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setZeroDesc) | Coi phần xuống, độ sâu dưới baseline, là zero. Điều này có thể di chuyển thanh phân số hoặc nội dung khác dưới biểu thức gần hơn tới các phần tử lân cận. |

The baseline is the reference line on which ordinary mathematical letters sit. Hiding content does not remove its dimensions, and treating a dimension as zero does not delete the expression. The underlying expression remains available through [getBase](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#getBase). Pass `true` to [setShow](https://reference.aspose.com/slides/php-java/aspose.slides/mathphantom/#setShow) to display it again; the dimension settings remain unchanged.

The example below creates five side-by-side variants: a visible fraction, a hidden fraction that reserves space, and three hidden fractions with one dimension treated as zero. Each variant uses the same surrounding expression and Cambria Math at 24 points. All equation shapes have the same top position, marked by the gray guide. Placing the phantom in the numerator of an outer fraction makes the vertical layout changes easier to see.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\MathBlock;
use aspose\slides\MathFraction;
use aspose\slides\MathPhantom;
use aspose\slides\MathematicalText;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\SlideSizeScaleType;
use aspose\slides\TextAnchorType;

$createText = static function (string $value) {
    $text = new MathematicalText($value);
    $text->getFormat()->setFontHeight(24);
    $text->getFormat()->setLatinFont(new FontData("Cambria Math"));
    return $text;
};

$presentation = new Presentation();
try {
    $presentation->getSlideSize()->setSize(1000, 180, SlideSizeScaleType::DoNotScale);
    $slide = $presentation->getSlides()->get_Item(0);

    $labels = ["Visible", "Hidden: reserves space", "Hidden: ZeroWidth", "Hidden: ZeroAsc", "Hidden: ZeroDesc"];

    $guide = $slide->getShapes()->addAutoShape(ShapeType::Line, 10, 60, 980, 0);
    $guide->getLineFormat()->getFillFormat()->setFillType(FillType::Solid);
    $guide->getLineFormat()->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    foreach ($labels as $i => $labelText) {
        $left = 10 + $i * 200;

        $label = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, $left, 10, 190, 30);
        $label->getFillFormat()->setFillType(FillType::NoFill);
        $label->getLineFormat()->getFillFormat()->setFillType(FillType::NoFill);
        $label->getTextFrame()->setText($labelText);

        $labelFormat = $label->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0)->getPortionFormat();
        $labelFormat->setFontHeight(14);
        $labelFormat->getFillFormat()->setFillType(FillType::Solid);
        $labelFormat->getFillFormat()->getSolidFillColor()->setColor(java("java.awt.Color")->BLACK);

        $fractionNumerator = $createText("a+b");
        $fractionDenominator = $createText("c+d");
        $fraction = new MathFraction($fractionNumerator, $fractionDenominator);
        $phantom = new MathPhantom($fraction);
        $phantom->setShow($i === 0);
        $phantom->setZeroWidth($i === 2);
        $phantom->setZeroAsc($i === 3);
        $phantom->setZeroDesc($i === 4);

        $leftText = $createText("x+");
        $rightText = $createText("+y");
        $numerator = (new MathBlock($leftText))->join($phantom)->join($rightText);
        $denominator = $createText("z");
        $equation = new MathFraction($numerator, $denominator);

        $shape = $slide->getShapes()->addMathShape($left, 60, 190, 100);
        $shape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Top);

        $mathPortion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $mathParagraph = $mathPortion->getMathParagraph();
        $mathBlock = new MathBlock($equation);
        $mathParagraph->add($mathBlock);
    }

    $presentation->save("math-phantom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

![Năm công thức trong PowerPoint so sánh một phân số hiển thị, một phân số ẩn giữ không gian, và các phân số ẩn với ZeroWidth, ZeroAsc hoặc ZeroDesc được bật](math-phantom.png)

## **Nhóm các phần tử**

Use [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#group) to place a grouping character above or below an expression. Add a limit to label the grouped terms.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản bên dưới](powerpoint-math-equations_15.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 120);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $grouped = (new MathematicalText("x + y"))
        - >group(new Java("java.lang.Character", "\u{23DF}"), MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >setLowerLimit("any text");

    $mathParagraph->add(new MathBlock($grouped));

    $presentation->save("grouped-terms.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Định dạng các phần tử toán học**

Use formatting helpers only where they clarify the formula. For example, [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#overbar) places a bar above a math element.

![Một biểu thức toán học ABC với một thanh trên](powerpoint-math-equations_14.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $overbar = (new MathematicalText("ABC"))->overbar();

    $mathParagraph->add(new MathBlock($overbar));

    $presentation->save("overbar.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

### **Định dạng văn bản trong công thức hiện có**

To format text throughout an existing equation, traverse each math block's element tree. [MathElementBase::getChildren](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/#getChildren) returns only the immediate children, so call it recursively to reach text inside fractions, scripts, radicals, and other nested structures. Check the current element as well as its children to include the starting element when it is [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/).

This example assumes that `input.pptx` contains an equation such as `z = xᵢ / ∛y`, with a fraction containing a subscript in its numerator and a radical in its denominator. Processing only the block's top-level elements would miss the text inside the fraction. The example finds mathematical portions in slide text frames, accesses their blocks through [MathPortion::getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), and uses [setFontHeight](https://reference.aspose.com/slides/php-java/aspose.slides/baseportionformat/#setFontHeight) to set the font size to 28 points through each text element's [getFormat](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/#getFormat) method.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function formatMathText($element, $mathematicalTextClass) {
    if (java_instanceof($element, $mathematicalTextClass)) {
        $element->getFormat()->setFontHeight(28);
    }

    foreach ($element->getChildren() as $child) {
        formatMathText($child, $mathematicalTextClass);
    }
}

$mathematicalTextClass = new JavaClass("com.aspose.slides.MathematicalText");
$autoShapeClass = new JavaClass("com.aspose.slides.IAutoShape");
$mathPortionClass = new JavaClass("com.aspose.slides.IMathPortion");

$presentation = new Presentation("input.pptx");
try {
    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {
        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }

            $textFrame = $shape->getTextFrame();
            if (java_is_null($textFrame)) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textFrame->getParagraphs()->getCount()); $paragraphIndex++) {
                $paragraph = $textFrame->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    if (java_instanceof($portion, $mathPortionClass)) {
                        for ($blockIndex = 0; $blockIndex < java_values($portion->getMathParagraph()->getCount()); $blockIndex++) {
                            $block = $portion->getMathParagraph()->get_Item($blockIndex);
                            formatMathText($block, $mathematicalTextClass);
                        }
                    }
                }
            }
        }
    }

    $presentation->save("formatted-equations.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

The saved presentation contains the updated text formatting at every level of each processed equation, while preserving its text content and mathematical structure.

## **Tham khảo nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/php-java/aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [join](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Tạo phân số | [divide](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số lên hoặc chỉ số xuống | [setSuperscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm hàm | [function](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm căn bậc | [radical](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số bên trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/php-java/aspose.slides/mathmatrix/) |
| Thêm mảng công thức | [toMathArray](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Thêm thanh và viền | [overbar](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |
| Nhóm các phần tử | [group](https://reference.aspose.com/slides/php-java/aspose.slides/mathelementbase/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa công thức PowerPoint hiện có không?**

Yes. Open the presentation, find the shape that contains a [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), call [getMathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/#getMathParagraph), and update the math blocks in that paragraph.

**Các công thức có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Yes. When you save to PPTX, Aspose.Slides writes the equation as editable Office math content.

**Tôi có thể xuất công thức sang LaTeX không?**

Yes. Get the equation's [MathParagraph](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/) from its [MathPortion](https://reference.aspose.com/slides/php-java/aspose.slides/mathportion/), and call [MathParagraph::toLatex](https://reference.aspose.com/slides/php-java/aspose.slides/mathparagraph/#toLatex) to export it directly. For a complete example, see [Xuất công thức toán học từ bài thuyết trình trong PHP qua Java](/slides/vi/php-java/exporting-math-equations/#export-math-equations-to-latex).