---
title: Thêm Phương trình Toán học vào Bản trình chiếu PowerPoint trong Python
linktitle: Phương trình Toán học PowerPoint
type: docs
weight: 80
url: /vi/python-net/powerpoint-math-equations/
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
- Python
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX với Aspose.Slides cho Python qua .NET, hỗ trợ OMML, điều khiển định dạng, và các mẫu mã Python rõ ràng."
---
## **Tổng quan**

PowerPoint lưu trữ các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho Python qua .NET, bạn có thể tạo các nội dung toán học tương tự một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường thêm phương trình từ **Insert > Equation**:

![Thanh Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó qua ba đối tượng chính:

- Một hình dạng toán học, được tạo bằng [add_math_shape](https://reference.aspose.com/slides/vi/python-net/aspose.slides/shapecollection/add_math_shape/), là hình dạng chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình dạng.
- [MathParagraph](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathematicaltext/) và các phương thức thông suốt từ [IMathElement](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/) để giữ mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Export Math Equations from Presentations in Python via .NET](/slides/vi/python-net/exporting-math-equations/).

## **Tạo một Phương trình**

Ví dụ này tạo một hình dạng toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation = (
        math.MathematicalText("c")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("a").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("b").set_superscript("2"))
    )

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", slides.export.SaveFormat.PPTX)
```

{{% alert color="primary" %}}
`add_math_shape` tạo một hình dạng đã chứa sẵn một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó, và thêm các khối toán hoặc các phần tử toán học vào đó.
{{% /alert %}}

## **Thêm Phân số**

Sử dụng [`divide`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/divide/) để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathfractiontypes/).

![Một phân số nghiêng hiển thị 1 chia cho x](powerpoint-math-equations_4.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    fraction = math.MathematicalText("1").divide("x", math.MathFractionTypes.SKEWED)

    math_paragraph.add(math.MathBlock(fraction))

    presentation.save("fraction.pptx", slides.export.SaveFormat.PPTX)
```

Đối với phân số dạng gộp, sử dụng `MathFractionTypes.BAR`:

```py
stacked_fraction = math.MathematicalText("x + 1").divide("y - 1", math.MathFractionTypes.BAR)
```

## **Thêm Căn bậc**

Sử dụng [`radical`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/radical/) để tạo căn bậc hai, căn bậc ba hoặc các căn bậc khác. Phần tử hiện tại trở thành cơ sở, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x nằm dưới dấu căn](powerpoint-math-equations_5.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    radical = math.MathematicalText("x").radical("n")

    math_paragraph.add(math.MathBlock(radical))

    presentation.save("radical.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hàm và Giới hạn**

Sử dụng [`as_argument_of_function`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) hoặc [`function`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/function/) cho các hàm như `sin(x)`, `log(x)` hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathlimit/) hoặc sử dụng [`set_lower_limit`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/).

![Giới hạn của x khi x tiến tới vô cùng](powerpoint-math-equations_8.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    limit = (
        math.MathematicalText("lim")
        .set_lower_limit("x\u2192\u221E")
        .function("x")
    )

    math_paragraph.add(math.MathBlock(limit))

    presentation.save("functions-and-limits.pptx", slides.export.SaveFormat.PPTX)
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```py
custom_function = math.MathematicalText("f").function("x + 1")
```

## **Thêm Toán tử N-ary và Tích phân**

Sử dụng [`nary`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/nary/) cho các tổng, hợp, giao và các toán tử lớn khác. Sử dụng [`integral`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/integral/) cho các tích phân. Cả hai phương thức đều cho phép đặt giới hạn dưới và trên.

![Một tổng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    summation_base = (
        math.MathematicalText("x")
        .set_superscript("k")
        .join(math.MathematicalText("a").set_superscript("n-k"))
    )

    summation = summation_base.nary(math.MathNaryOperatorTypes.SUMMATION, "k=0", "n")

    math_paragraph.add(math.MathBlock(summation))

    presentation.save("nary-operators.pptx", slides.export.SaveFormat.PPTX)
```

Toán tử N-ary dùng cho các toán tử lớn có tùy chọn giới hạn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng `MathematicalText` và nối vào biểu thức.

Đối với tích phân, sử dụng `integral`:

```py
integral_base = math.MathematicalText("x").join(math.MathematicalText("dx").to_box())
integral = integral_base.integral(math.MathIntegralTypes.SIMPLE, "0", "1")
```

## **Thêm Ma trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathmatrix/) cho các hàng và cột. Ma trận không bao gồm dấu ngoặc theo mặc định, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, dấu ngoặc vuông hoặc dấu ngoặc nhọn.

![Ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    matrix = math.MathMatrix(2, 3)
    matrix[0, 0] = math.MathematicalText("1")
    matrix[0, 1] = math.MathematicalText("x")
    matrix[1, 0] = math.MathematicalText("x")
    matrix[1, 1] = math.MathematicalText("2")
    matrix[1, 2] = math.MathematicalText("y")

    math_paragraph.add(math.MathBlock(matrix))

    presentation.save("matrix.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Mảng Phương trình**

Sử dụng [`to_math_array`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/to_math_array/) khi bạn cần các phương trình căn chỉnh hoặc một dải biểu thức dọc.

![Mảng toán học dọc với x nằm trên y](powerpoint-math-equations_11.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 140)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    equation_array = (
        math.MathematicalText("x")
        .join("y")
        .to_math_array()
    )

    math_paragraph.add(math.MathBlock(equation_array))

    presentation.save("equation-array.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Hàm lượng giác**

Sử dụng [`as_argument_of_function`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    cosine = math.MathematicalText("2x").as_argument_of_function(
        math.MathFunctionsOfOneArgument.COS
    )

    math_paragraph.add(math.MathBlock(cosine))

    presentation.save("trigonometric-function.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Chỉ số dưới và chỉ số trên**

Sử dụng các trợ giúp chỉ số dưới và chỉ số trên cho các chỉ mục và lũy thừa. Khi các chỉ mục phải xuất hiện bên trái của cơ sở, sử dụng [`set_sub_superscript_on_the_left`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/).

![Ký tự Y in hoa với chỉ số dưới 1 và chỉ số trên n ở phía bên trái](powerpoint-math-equations_9.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    scripts = math.MathematicalText("Y").set_sub_superscript_on_the_left("1", "n")

    math_paragraph.add(math.MathBlock(scripts))

    presentation.save("subscript-superscript.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Dấu phân cách**

Sử dụng [`enclose`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/enclose/) để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được ngăn cách bằng dấu gạch đứng](powerpoint-math-equations_13.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    delimiter = (
        math.MathematicalText("x")
        .join("y")
        .join("z")
        .enclose("<", ">")
    )
    delimiter.separator_character = "|"

    math_paragraph.add(math.MathBlock(delimiter))

    presentation.save("delimiters.pptx", slides.export.SaveFormat.PPTX)
```

## **Thêm Khung Viền**

Sử dụng [`to_border_box`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/to_border_box/) khi phương trình cần được khung.

![Một phương trình có khung hiển thị a bình phương bằng b bình phương cộng c bình phương](powerpoint-math-equations_12.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    boxed_equation = (
        math.MathematicalText("a")
        .set_superscript("2")
        .join("=")
        .join(math.MathematicalText("b").set_superscript("2"))
        .join("+")
        .join(math.MathematicalText("c").set_superscript("2"))
        .to_border_box()
    )

    math_paragraph.add(math.MathBlock(boxed_equation))

    presentation.save("border-box.pptx", slides.export.SaveFormat.PPTX)
```

## **Nhóm Các Thuật Ngữ**

Sử dụng [`group`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/group/) để đặt ký tự nhóm phía trên hoặc dưới một biểu thức. Thêm giới hạn để gán nhãn cho các thuật ngữ được nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản nào ở phía dưới](powerpoint-math-equations_15.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 120)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    grouped = (
        math.MathematicalText("x + y")
        .group(chr(0x23DF), math.MathTopBotPositions.BOTTOM, math.MathTopBotPositions.TOP)
        .set_lower_limit("any text")
    )

    math_paragraph.add(math.MathBlock(grouped))

    presentation.save("grouped-terms.pptx", slides.export.SaveFormat.PPTX)
```

## **Định dạng Các Phần Tử Toán học**

Sử dụng các trợ giúp định dạng chỉ khi chúng làm rõ công thức. Ví dụ, [`overbar`](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/overbar/) đặt một thanh gạch trên một phần tử toán học.

![Một biểu thức toán học ABC có thanh gạch trên](powerpoint-math-equations_14.png)

```py
import aspose.slides as slides
import aspose.slides.mathtext as math

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    math_shape = slide.shapes.add_math_shape(20, 20, 700, 100)
    math_paragraph = math_shape.text_frame.paragraphs[0].portions[0].math_paragraph

    overbar = math.MathematicalText("ABC").overbar()

    math_paragraph.add(math.MathBlock(overbar))

    presentation.save("overbar.pptx", slides.export.SaveFormat.PPTX)
```

## **Tham khảo nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathematicaltext/) |
| Kết hợp các phần tử | [IMathElement.join](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/join/) |
| Tạo phân số | [IMathElement.divide](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/divide/) |
| Thêm chỉ số trên hoặc chỉ số dưới | [set_superscript](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_superscript/), [set_subscript](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_subscript/) |
| Thêm hàm | [function](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/function/), [as_argument_of_function](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/as_argument_of_function/) |
| Thêm căn bậc | [radical](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/radical/) |
| Thêm giới hạn | [set_lower_limit](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_lower_limit/), [set_upper_limit](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_upper_limit/) |
| Thêm các chỉ số bên trái | [set_sub_superscript_on_the_left](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/set_sub_superscript_on_the_left/) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/nary/), [integral](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/integral/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/mathmatrix/) |
| Thêm mảng phương trình | [to_math_array](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/to_math_array/) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/enclose/) |
| Thêm thanh và khung viền | [overbar](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/overbar/), [to_border_box](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/to_border_box/) |
| Nhóm các thuật ngữ | [group](https://reference.aspose.com/slides/vi/python-net/aspose.slides.mathtext/imathelement/group/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình bày, tìm hình dạng chứa `MathPortion`, lấy `MathParagraph` của nó, và cập nhật các khối toán trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi bạn lưu thành PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung Office math có thể chỉnh sửa.

**Tôi có thể xuất phương trình sang LaTeX không?**

Aspose.Slides xuất các phương trình toán học sang MathML. Nếu bạn cần LaTeX, hãy xuất sang MathML trước, sau đó chuyển đổi MathML bằng công cụ hỗ trợ định dạng LaTeX mà bạn muốn.