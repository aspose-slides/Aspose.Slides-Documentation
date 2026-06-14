---
title: Thêm các Phương trình Toán học vào Bản trình chiếu PowerPoint trong PHP
linktitle: Phương trình Toán học PowerPoint
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

PowerPoint lưu trữ các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho PHP qua Java, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường thêm phương trình bằng **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shapecollection/#addMathShape), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathblock/) .

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathematicaltext/) và các phương thức chuỗi từ [MathElementBase](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) để giữ mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Xuất các phương trình toán học từ bản trình bày trong PHP qua Java](/slides/vi/php-java/exporting-math-equations/).

## **Tạo một Phương trình**

Ví dụ này tạo một hình toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

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

{{% alert color="primary" %}}
`addMathShape` tạo một hình đã chứa sẵn một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó và thêm các khối toán học hoặc các phần tử toán học vào đó.
{{% /alert %}}

## **Thêm Phân Số**

Sử dụng [`divide`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathfractiontypes/).

![Một phân số nghiêng hiển thị 1 chia cho x](powerpoint-math-equations_4.png)

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

Đối với phân số chồng, sử dụng `MathFractionTypes::Bar`:

```php
$stackedFraction = (new MathematicalText("x + 1"))->divide("y - 1", MathFractionTypes::Bar);
```

## **Thêm Căn Bậc**

Sử dụng [`radical`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành cơ số, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x nằm dưới dấu căn](powerpoint-math-equations_5.png)

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

## **Thêm Hàm và Giới Hạn**

Sử dụng [`asArgumentOfFunction`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) hoặc [`function`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathlimit/) hoặc sử dụng [`setLowerLimit`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/).

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

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```php
$customFunction = (new MathematicalText("f"))->function("x + 1");
```

## **Thêm Toán tử N-ary và Tích phân**

Sử dụng [`nary`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng [`integral`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) cho tích phân. Cả hai phương pháp đều cho phép đặt giới hạn dưới và trên.

![Một phép cộng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

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

Các toán tử N-ary dùng cho các toán tử lớn có thể có hoặc không có giới hạn. Các toán tử đơn như `+`, `-`, và `=` thường được thêm dưới dạng `MathematicalText` và nối vào biểu thức.

Đối với tích phân, sử dụng `integral`:

```php
$integralBase = (new MathematicalText("x"))->join((new MathematicalText("dx"))->toBox());
$integral = $integralBase->integral(MathIntegralTypes::Simple, "0", "1");
```

## **Thêm Ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathmatrix/) cho các hàng và cột. Ma trận không bao gồm ngoặc vuông theo mặc định, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, vuông hoặc nhọn.

![Một ma trận toán học hai hàng có một ô trống](powerpoint-math-equations_10.png)

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

## **Thêm Mảng Phương trình**

Sử dụng [`toMathArray`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) khi bạn cần các phương trình được căn chỉnh hoặc một chuỗi dọc các biểu thức.

![Một mảng toán học dọc với x ở trên y](powerpoint-math-equations_11.png)

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

## **Thêm Hàm lượng giác**

Sử dụng [`asArgumentOfFunction`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) khi đối số là phần tử hiện tại và tên hàm đã biết.

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

## **Thêm chỉ số dưới và chỉ số trên**

Sử dụng các trợ giúp chỉ số dưới và chỉ số trên cho các chỉ mục và lũy thừa. Khi các chỉ mục phải xuất hiện ở phía bên trái của cơ sở, sử dụng [`setSubSuperscriptOnTheLeft`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/).

![Chữ Y viết hoa với chỉ số dưới 1 và chỉ số trên n ở phía bên trái](powerpoint-math-equations_9.png)

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

## **Thêm Dấu Phân cách**

Sử dụng [`enclose`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức có nhiều phần tử.

![Một biểu thức với dấu phân cách chứa x, y và z được ngăn cách bằng các dấu gạch đứng](powerpoint-math-equations_13.png)

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

## **Thêm Hộp Viền**

Sử dụng [`toBorderBox`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) khi phương trình cần được bao khung.

![Một phương trình được bao khung cho thấy a bình phương bằng b bình phương cộng c bình phương](powerpoint-math-equations_12.png)

```php
$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $mathShape = $slide->getShapes()->addMathShape(20, 20, 700, 100);
    $mathParagraph = $mathShape->getTextFrame()->getParagraphs()
        - >get_Item(0)->getPortions()->get_Item(0)->getMathParagraph();

    $boxedEquation = (new MathematicalText("a"))
        - >setSuperscript("2")
        - >join("=")
        - >join((new MathematicalText("b"))->setSuperscript("2"))
        - >join("+")
        - >join((new MathematicalText("c"))->setSuperscript("2"))
        - >toBorderBox();

    $mathParagraph->add(new MathBlock($boxedEquation));

    $presentation->save("border-box.pptx", SaveFormat::Pptx);
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Nhóm các Thuật ngữ**

Sử dụng [`group`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) để đặt ký tự nhóm ở trên hoặc dưới một biểu thức. Thêm một giới hạn để gắn nhãn cho các thành phần được nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản nào ở dưới](powerpoint-math-equations_15.png)

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

## **Định dạng Các Phần tử Toán học**

Sử dụng các trợ giúp định dạng chỉ khi chúng làm rõ công thức. Ví dụ, [`overbar`](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) đặt một thanh trên một phần tử toán học.

![Một biểu thức toán học ABC có thanh trên](powerpoint-math-equations_14.png)

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

## **Tham chiếu nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [join](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Tạo phân số | [divide](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số trên hoặc chỉ số dưới | [setSuperscript](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/), [setSubscript](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm hàm | [function](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/), [asArgumentOfFunction](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm căn bậc | [radical](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/), [setUpperLimit](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm chỉ số bên trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/), [integral](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathmatrix/) |
| Thêm mảng phương trình | [toMathArray](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Thêm thanh và viền | [overbar](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/), [toBorderBox](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |
| Nhóm các thành phần | [group](https://reference.aspose.com/slides/vi/php-java/aspose.slides/mathelementbase/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình bày, tìm hình chứa `MathPortion`, lấy `MathParagraph` của nó và cập nhật các khối toán học trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung toán học Office có thể chỉnh sửa.

**Tôi có thể xuất phương trình sang LaTeX không?**

Aspose.Slides xuất các phương trình toán học sang MathML. Nếu bạn cần LaTeX, hãy xuất sang MathML trước rồi chuyển đổi MathML bằng công cụ hỗ trợ định dạng LaTeX mục tiêu của bạn.