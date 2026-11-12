---
title: Thêm Phương Trình Toán Học vào Bản Trình Chiếu PowerPoint bằng Python
linktitle: Phương Trình Toán Học PowerPoint
type: docs
weight: 80
url: /vi/python-java/powerpoint-math-equations/
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
- Java
- Aspose.Slides
description: "Chèn và chỉnh sửa các phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho Python qua Java, hỗ trợ OMML, kiểm soát định dạng, và các mẫu mã Python rõ ràng."
---
## **Tổng quan**

PowerPoint lưu trữ các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho Python thông qua Java, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường thêm phương trình thông qua **Insert > Equation**:

![Thanh Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/python-java/aspose.slides/mathblock/).

Hầu hết các ví dụ dưới đây sử dụng [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) và các phương thức fluent từ [MathElementBase](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/) để giữ cho mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Export Math Equations from Presentations in Python](/slides/vi/python-java/exporting-math-equations/).

## **Tạo một Phương trình**

Ví dụ này sử dụng [addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) để tạo một hình toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_squared = MathematicalText("a").setSuperscript("2")
    b_squared = MathematicalText("b").setSuperscript("2")
    equation = MathematicalText("c").setSuperscript("2").join("=").join(a_squared).join("+").join(b_squared)

    math_paragraph.add(equation)

    presentation.save("pythagorean-theorem.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Note" %}}
[addMathShape](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addMathShape) tạo một hình đã chứa sẵn một đoạn toán học. Truy cập [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/) đầu tiên, gọi [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), và thêm các khối toán học hoặc các phần tử toán học vào đó.
{{% /alert %}}

## **Thêm Phân Số**

Sử dụng [divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) để tạo một phân số. Bạn có thể lựa chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/).

![Một phân số nghiêng cho thấy một chia cho x](powerpoint-math-equations_4.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFractionTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    fraction = MathematicalText("1").divide("x", MathFractionTypes.Skewed)

    math_block = MathBlock(fraction)
    math_paragraph.add(math_block)

    presentation.save("fraction.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với phân số chồng, sử dụng [MathFractionTypes.Bar](https://reference.aspose.com/slides/python-java/aspose.slides/mathfractiontypes/#Bar):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathFractionTypes, MathematicalText

stacked_fraction = MathematicalText("x + 1").divide("y - 1", MathFractionTypes.Bar)
```

## **Thêm Căn Bậc**

Sử dụng [radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành cơ số, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x nằm dưới dấu căn](powerpoint-math-equations_5.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    radical = MathematicalText("x").radical("n")

    math_block = MathBlock(radical)
    math_paragraph.add(math_block)

    presentation.save("radical.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Hàm và Giới Hạn**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) hoặc [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathlimit/) hoặc sử dụng [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit).

![Giới hạn của x khi x tiến tới vô cùng](powerpoint-math-equations_8.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    limit = MathematicalText("lim").setLowerLimit("x\u2192\u221E").function("x")

    math_block = MathBlock(limit)
    math_paragraph.add(math_block)

    presentation.save("functions-and-limits.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Đối với tên hàm tùy chỉnh, biến tên hàm thành phần tử hiện tại và gọi [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function) với đối số của nó:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathematicalText

custom_function = MathematicalText("f").function("x + 1")
```

## **Thêm Toán tử N-ary và Tích Phân**

Sử dụng [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary) cho các phép tổng, hợp, giao, và các toán tử lớn khác. Sử dụng [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) cho tích phân. Cả hai phương thức đều cho phép bạn đặt giới hạn dưới và trên.

![Một phép tổng với giới hạn dưới và trên](powerpoint-math-equations_7.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathNaryOperatorTypes, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    a_power = MathematicalText("a").setSuperscript("n-k")
    summation_base = MathematicalText("x").setSuperscript("k").join(a_power)

    summation = summation_base.nary(MathNaryOperatorTypes.Summation, "k=0", "n")

    math_block = MathBlock(summation)
    math_paragraph.add(math_block)

    presentation.save("nary-operators.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Toán tử N-ary dùng cho các toán tử lớn có tùy chọn giới hạn. Các toán tử đơn giản như `+`, `-`, và `=` thường được thêm dưới dạng [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) và nối vào biểu thức.

Đối với tích phân, sử dụng [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral):

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathIntegralTypes, MathematicalText

differential = MathematicalText("dx").toBox()
integral_base = MathematicalText("x").join(differential)
integral = integral_base.integral(MathIntegralTypes.Simple, "0", "1")
```

## **Thêm Ma Trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) cho các hàng và cột. Ma trận mặc định không bao gồm dấu ngoặc, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, vuông hoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathMatrix, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    matrix = MathMatrix(2, 3)
    cell_0_0 = MathematicalText("1")
    matrix.set_Item(0, 0, cell_0_0)
    cell_0_1 = MathematicalText("x")
    matrix.set_Item(0, 1, cell_0_1)
    cell_1_0 = MathematicalText("x")
    matrix.set_Item(1, 0, cell_1_0)
    cell_1_1 = MathematicalText("2")
    matrix.set_Item(1, 1, cell_1_1)
    cell_1_2 = MathematicalText("y")
    matrix.set_Item(1, 2, cell_1_2)

    math_block = MathBlock(matrix)
    math_paragraph.add(math_block)

    presentation.save("matrix.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Mảng Phương Trình**

Sử dụng [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) khi bạn cần các phương trình căn chỉnh hoặc một chồng dọc các biểu thức.

![Một mảng toán học dọc với x trên y](powerpoint-math-equations_11.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 140)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    equation_array = MathematicalText("x").join("y").toMathArray()

    math_block = MathBlock(equation_array)
    math_paragraph.add(math_block)

    presentation.save("equation-array.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Căn chỉnh Mảng với Các Phần Tử Xung Quanh**

[setBaseJustification](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setBaseJustification) kiểm soát việc căn chỉnh dọc của một mảng so với các phần tử toán học bên cạnh nó. Ví dụ dưới đây so sánh căn chỉnh với hàng đầu tiên, trung tâm mảng và hàng cuối cùng.

Ví dụ sau tạo ba mảng giống hệt nhau, mỗi mảng có ba hàng và các phần tử lân cận `A=` và `=B`. Tất cả văn bản toán học sử dụng Cambria Math kích thước 24 điểm. Chỉ việc căn chỉnh mảng thay đổi.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathVerticalAlignment, Presentation, SaveFormat, ShapeType, SlideSizeScaleType, TextAnchorType
from java.awt import Color

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


presentation = Presentation()
try:
    presentation.getSlideSize().setSize(780, 200, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)
    
    alignments = (("Top", MathVerticalAlignment.Top), ("Center", MathVerticalAlignment.Center), ("Bottom", MathVerticalAlignment.Bottom))
    for index, (name, alignment) in enumerate(alignments):
        x = 20 + index * 260
        label = slide.getShapes().addAutoShape(ShapeType.Rectangle, x, 10, 240, 30)
        label.getFillFormat().setFillType(FillType.NoFill)
        label.getLineFormat().getFillFormat().setFillType(FillType.NoFill)
        label.getTextFrame().setText(name)
        label_format = label.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat()
        label_format.setFontHeight(16)
        label_format.getFillFormat().setFillType(FillType.Solid)
        label_format.getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        math_shape = slide.getShapes().addMathShape(x, 60, 240, 130)
        math_shape.getTextFrame().getTextFrameFormat().setAnchoringType(TextAnchorType.Top)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(alignment)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

    presentation.save("equation-array-alignment.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

So sánh dưới đây hiển thị bản trình bày đã lưu trong PowerPoint. Lưu ý vị trí của `A=` và `=B` bên cạnh mỗi mảng.

![Các mảng phương trình trong PowerPoint với căn trên, trung tâm và dưới và các phần tử lân cận giống nhau](equation-array-alignment.png)

### **Cấu Hình Khoảng Cách Hàng**

[setRowSpacingRule](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacingRule) chọn quy tắc khoảng cách cho các hàng trong mảng. [setRowSpacing](https://reference.aspose.com/slides/python-java/aspose.slides/matharray/#setRowSpacing) cung cấp giá trị số cho quy tắc khoảng cách cụ thể và sẽ bị bỏ qua bởi các quy tắc mặc định.

Đối với khoảng cách chính xác, giá trị được đo bằng điểm. Đối với khoảng cách tỉ lệ, nó được đo bằng nửa dòng: giá trị `3` trong ví dụ tương đương 1.5 dòng. Khi chỉ định giá trị cụ thể, hãy đặt cả hai thuộc tính; thay đổi chỉ giá trị số không chọn quy tắc khoảng cách.

Ví dụ dưới đây lưu năm bản trình bày với cùng các phương trình, căn chỉnh và cài đặt phông chữ. Ba bản đầu sử dụng cài đặt sẵn; hai bản cuối hiển thị giá trị cụ thể.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FontData, MathArray, MathBlock, MathJustification, MathematicalText, MathRowSpacingRule, MathVerticalAlignment, Presentation, SaveFormat

def create_text(value):
    text = MathematicalText(value)
    text.getFormat().setFontHeight(24)
    text.getFormat().setLatinFont(FontData("Cambria Math"))
    return text


settings = (("SingleLineGap", MathRowSpacingRule.SingleLineGap, 0), ("OneAndAHalfLineGap", MathRowSpacingRule.OneAndAHalfLineGap, 0), ("TwoLineGap", MathRowSpacingRule.TwoLineGap, 0), ("Exactly", MathRowSpacingRule.Exactly, 20), ("Multiple", MathRowSpacingRule.Multiple, 3))
for name, rule, spacing in settings:
    presentation = Presentation()
    try:
        slide = presentation.getSlides().get_Item(0)
        math_shape = slide.getShapes().addMathShape(20, 20, 600, 300)
        paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0)
        paragraph.getParagraphFormat().setSpaceBefore(0)
        paragraph.getParagraphFormat().setSpaceAfter(0)
        math_paragraph = paragraph.getPortions().get_Item(0).getMathParagraph()
        math_paragraph.setJustification(MathJustification.LeftJustified)

        equation_array = MathArray(create_text("x+y=3"))
        equation_array.getArguments().add(create_text("x-y=1"))
        equation_array.getArguments().add(create_text("x=2"))
        equation_array.setBaseJustification(MathVerticalAlignment.Center)
        equation_array.setRowSpacingRule(rule)
        equation_array.setRowSpacing(spacing)
        equation = MathBlock(create_text("A=")).join(equation_array).join(create_text("=B"))
        math_paragraph.add(equation)

        presentation.save(f"equation-array-{name}.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

Khoảng cách hàng của mảng riêng biệt với khoảng cách đoạn văn. [setSpaceBefore](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceBefore) và [setSpaceAfter](https://reference.aspose.com/slides/python-java/aspose.slides/paragraphformat/#setSpaceAfter) thêm không gian quanh đoạn chứa, không phải giữa các hàng của mảng. Tương tự, [MathParagraph.setJustification](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#setJustification) định vị toàn bộ đoạn toán học theo chiều ngang; nó không thay thế cài đặt căn chỉnh dọc của mảng.

## **Thêm Hàm Lượng Giác**

Sử dụng [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos được áp dụng cho 2x](powerpoint-math-equations_6.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathFunctionsOfOneArgument, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    cosine = MathematicalText("2x").asArgumentOfFunction(MathFunctionsOfOneArgument.Cos)

    math_block = MathBlock(cosine)
    math_paragraph.add(math_block)

    presentation.save("trigonometric-function.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Chỉ Số Dưới và Chỉ Số Trên**

Sử dụng các trợ giúp chỉ số dưới và chỉ số trên cho chỉ mục và lũy thừa. Khi các chỉ số phải xuất hiện ở phía bên trái của cơ số, sử dụng [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft).

![Chữ Y viết hoa với chỉ số dưới 1 ở phía bên trái và chỉ số trên n](powerpoint-math-equations_9.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    scripts = MathematicalText("Y").setSubSuperscriptOnTheLeft("1", "n")

    math_block = MathBlock(scripts)
    math_paragraph.add(math_block)

    presentation.save("subscript-superscript.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Thêm Dấu Phân Cách**

Sử dụng [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách chứa nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được ngăn cách bằng các thanh dọc](powerpoint-math-equations_13.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    delimiter = MathematicalText("x").join("y").join("z").enclose('<', '>')
    delimiter.setSeparatorCharacter('|')

    math_block = MathBlock(delimiter)
    math_paragraph.add(math_block)

    presentation.save("delimiters.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Kích Thước và Căn Dấu Phân Cách**

Gửi `True` tới [setGrowToMatchOperandHeight](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setGrowToMatchOperandHeight) để cho dấu ngoặc tròn mở rộng quanh một toán hạng cao, hoặc gửi `False` để giữ chúng ở kích thước bình thường. Sử dụng [setDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimiter/#setDelimiterShape) với một trong hai giá trị của [MathDelimiterShape](https://reference.aspose.com/slides/python-java/aspose.slides/mathdelimitershape/). `Centered` đặt dấu ngoặc ở giữa trục toán học, trục này chạy qua giữa dấu bằng. `Match` căn chúng với nội dung được bao quanh. Cả hai cài đặt chỉ ảnh hưởng tới dấu phân cách. Biểu thức bên trong vẫn giữ nguyên.

Ví dụ đặt một phân số trong lũy thừa của `x` để biểu thức mở rộng cao hơn so với đường cơ sở. Bốn phương trình đều sử dụng cùng dấu ngoặc và cài đặt phông chữ.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathDelimiterShape, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    for row, grow in enumerate((True, False)):
        for column, shape in enumerate((MathDelimiterShape.Centered, MathDelimiterShape.Match)):
            fraction = MathematicalText("a + b").divide("c + d")
            power = MathematicalText("x").setSuperscript(fraction)
            delimiter = power.enclose("(", ")")
            delimiter.setGrowToMatchOperandHeight(grow)
            delimiter.setDelimiterShape(shape)

            math_shape = slide.getShapes().addMathShape(20 + 330 * column, 20 + 120 * row, 300, 100)
            portion = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
            portion.getPortionFormat().setFontHeight(32)
            equation = MathematicalText("y = ").join(delimiter)
            portion.getMathParagraph().add(equation)

    presentation.save("delimiter-sizing.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Trong PowerPoint, so sánh các hàng để thấy hiệu ứng mở rộng. Ở hàng trên, dấu ngoặc mở rộng để bao quanh lũy thừa và trông giống nhau cho cả hai dạng. Ở hàng dưới, tính năng mở rộng được tắt. Dấu ngoặc nhỏ hơn bên trái (`Centered`) căn với dấu bằng, trong khi dấu ngoặc bên phải (`Match`) nằm cao hơn quanh biểu thức.

![Bốn phương trình trong PowerPoint với dấu phân cách mở rộng bật ở trên và tắt ở dưới, và Centered bên trái, Match bên phải](delimiter-sizing.png)

## **Thêm Hộp Viền**

Gọi [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) trên một phân số để đóng khung toàn bộ biểu thức. [MathBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/) trả về hiển thị cả bốn phía theo mặc định. Sử dụng [setHideTop](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideTop), [setHideBottom](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideBottom), [setHideLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideLeft), và [setHideRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setHideRight) để loại bỏ các mặt riêng lẻ.

Ví dụ đặt sáu bản sao của cùng một phân số trên một slide. Để hiển thị việc gạch bỏ, ẩn cả bốn mặt và gửi `True` tới [setStrikethroughBottomLeftToTopRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughBottomLeftToTopRight) cho đường chéo lên (↗) hoặc [setStrikethroughTopLeftToBottomRight](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughTopLeftToBottomRight) cho đường chéo xuống (↘). Bạn cũng có thể sử dụng [setStrikethroughHorizontal](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughHorizontal) hoặc [setStrikethroughVertical](https://reference.aspose.com/slides/python-java/aspose.slides/mathborderbox/#setStrikethroughVertical) với bất kỳ kết hợp nào của các mặt hiển thị.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat, SlideSizeScaleType

presentation = Presentation()
try:
    presentation.getSlideSize().setSize(540, 220, SlideSizeScaleType.DoNotScale)
    slide = presentation.getSlides().get_Item(0)

    def add_fraction(x, y, hide_border):
        fraction = MathematicalText("x+1").divide("y+2")
        box = fraction.toBorderBox()
        box.setHideTop(hide_border)
        box.setHideBottom(hide_border)
        box.setHideLeft(hide_border)
        box.setHideRight(hide_border)

        shape = slide.getShapes().addMathShape(x, y, 160, 90)
        portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0)
        portion.getPortionFormat().setFontHeight(28)
        math_block = MathBlock(box)
        portion.getMathParagraph().add(math_block)
        return box

    add_fraction(10, 10, False)

    partial = add_fraction(190, 10, False)
    partial.setHideTop(True)
    partial.setHideRight(True)

    add_fraction(370, 10, True).setStrikethroughBottomLeftToTopRight(True)
    add_fraction(10, 120, True).setStrikethroughTopLeftToBottomRight(True)
    add_fraction(190, 120, True).setStrikethroughHorizontal(True)
    add_fraction(370, 120, False).setStrikethroughVertical(True)

    presentation.save("border-box.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

![Sáu phân số có thể chỉnh sửa trong PowerPoint. Hàng trên: viền đầy đủ, các mặt dưới và trái, đường chéo lên. Hàng dưới: đường chéo xuống, gạch ngang, gạch dọc với viền đầy đủ](border-box-fractions.png)

Ở phân số này, gạch ngang chồng lên thanh phân số. Gạch dọc cắt cả tử và mẫu trong khi viền xung quanh vẫn hiển thị. Những đường này trang trí toàn bộ biểu thức. Gạch xuyên thường áp dụng cho các ký tự trong một đoạn văn bản. Sau khi mở lại bản trình bày trong PowerPoint, bạn vẫn có thể chỉnh sửa tử và mẫu riêng biệt.

## **Nhóm Các Thuật Ngữ**

Sử dụng [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) để đặt ký tự nhóm lên trên hoặc dưới một biểu thức. Thêm giới hạn để ghi nhãn các thuật ngữ đã nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ văn bản nào bên dưới](powerpoint-math-equations_15.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathTopBotPositions, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 120)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    grouped = MathematicalText("x + y").group('\u23DF', MathTopBotPositions.Bottom, MathTopBotPositions.Top).setLowerLimit("any text")

    math_block = MathBlock(grouped)
    math_paragraph.add(math_block)

    presentation.save("grouped-terms.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Định Dạng Các Phần Tử Toán Học**

Chỉ sử dụng các trợ giúp định dạng khi chúng làm rõ công thức. Ví dụ, [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar) đặt một thanh trên phần tử toán học.

![Một biểu thức toán học ABC có thanh trên](powerpoint-math-equations_14.png)

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import MathBlock, MathematicalText, Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    math_shape = slide.getShapes().addMathShape(20, 20, 700, 100)
    math_paragraph = math_shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getMathParagraph()

    overbar = MathematicalText("ABC").overbar()

    math_block = MathBlock(overbar)
    math_paragraph.add(math_block)

    presentation.save("overbar.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Định Dạng Văn Bản trong Phương Trình Đã Tồn Tại**

Để định dạng văn bản trong toàn bộ một phương trình đã tồn tại, duyệt qua cây phần tử của mỗi khối toán học. [MathElementBase.getChildren](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#getChildren) trả về chỉ các trẻ trực tiếp, vì vậy hãy gọi đệ quy để tiếp cận văn bản bên trong phân số, chỉ số, căn bậc và các cấu trúc lồng nhau khác. Kiểm tra phần tử hiện tại cũng như các trẻ của nó để bao gồm phần tử bắt đầu khi nó là [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/).

Ví dụ này giả sử rằng `input.pptx` chứa một phương trình như `z = xᵢ / ∛y`, với một phân số có chỉ số dưới trong tử và một căn bậc trong mẫu. Chỉ xử lý các phần tử cấp cao nhất của khối sẽ bỏ qua văn bản bên trong phân số. Ví dụ tìm các phần toán học trong khung văn bản slide, truy cập các khối của chúng qua [MathPortion.getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), và sử dụng [setFontHeight](https://reference.aspose.com/slides/python-java/aspose.slides/baseportionformat/#setFontHeight) để đặt kích thước phông chữ thành 28 điểm qua mỗi phần tử văn bản bằng phương pháp [getFormat](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/#getFormat).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import AutoShape, MathematicalText, MathPortion, Presentation, SaveFormat


def format_math_text(element):
    if isinstance(element, MathematicalText):
        element.getFormat().setFontHeight(28)

    for child in element.getChildren():
        format_math_text(child)


presentation = Presentation("input.pptx")
try:
    for slide in presentation.getSlides():
        for shape in slide.getShapes():
            if not isinstance(shape, AutoShape):
                continue

            if shape.getTextFrame() is None:
                continue

            for paragraph in shape.getTextFrame().getParagraphs():
                for portion in paragraph.getPortions():
                    if isinstance(portion, MathPortion):
                        for block in portion.getMathParagraph():
                            format_math_text(block)

    presentation.save("formatted-equations.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Bản trình bày đã lưu chứa định dạng văn bản đã cập nhật ở mọi cấp độ của mỗi phương trình đã xử lý, đồng thời bảo toàn nội dung văn bản và cấu trúc toán học.

## **Tham Khảo Nhanh**

| Nhiệm vụ | API chính |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/python-java/aspose.slides/mathematicaltext/) |
| Kết hợp các phần tử | [MathElementBase.join](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#join) |
| Tạo phân số | [MathElementBase.divide](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#divide) |
| Thêm chỉ số trên hoặc chỉ số dưới | [setSuperscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSuperscript), [setSubscript](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubscript) |
| Thêm hàm | [function](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#function), [asArgumentOfFunction](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#asArgumentOfFunction) |
| Thêm căn bậc | [MathElementBase.radical](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#radical) |
| Thêm giới hạn | [setLowerLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setLowerLimit), [setUpperLimit](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setUpperLimit) |
| Thêm chỉ số bên trái | [setSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#setSubSuperscriptOnTheLeft) |
| Thêm tổng và tích phân | [nary](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#nary), [integral](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#integral) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/python-java/aspose.slides/mathmatrix/) |
| Thêm mảng phương trình | [toMathArray](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toMathArray) |
| Thêm dấu phân cách | [enclose](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#enclose) |
| Thêm thanh và viền | [overbar](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#overbar), [toBorderBox](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#toBorderBox) |
| Nhóm các thuật ngữ | [group](https://reference.aspose.com/slides/python-java/aspose.slides/mathelementbase/#group) |

## **Câu Hỏi Thường Gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình bày, tìm hình chứa một [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), gọi [getMathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/#getMathParagraph), và cập nhật các khối toán học trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung Office Math có thể chỉnh sửa.

**Tôi có thể xuất các phương trình sang LaTeX không?**

Có. Lấy [MathParagraph](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/) của phương trình thông qua [MathPortion](https://reference.aspose.com/slides/python-java/aspose.slides/mathportion/), và gọi [MathParagraph.toLatex](https://reference.aspose.com/slides/python-java/aspose.slides/mathparagraph/#toLatex) để xuất trực tiếp. Đối với ví dụ đầy đủ, xem [Export Math Equations from Presentations in Python](/slides/vi/python-java/exporting-math-equations/#export-math-equations-to-latex).