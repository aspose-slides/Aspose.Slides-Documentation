---
title: Thêm Phương Trình Toán Học vào Bản Trình Chiếu PowerPoint trong C++
linktitle: Phương Trình Toán Học PowerPoint
type: docs
weight: 80
url: /vi/cpp/powerpoint-math-equations/
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
- C++
- Aspose.Slides
description: "Chèn và chỉnh sửa phương trình toán học trong PowerPoint PPT và PPTX bằng Aspose.Slides cho C++, hỗ trợ OMML, các điều khiển định dạng, và các mẫu mã C++ rõ ràng."
---
## **Tổng quan**

PowerPoint lưu các phương trình dưới dạng Office Math Markup Language (OMML). Với Aspose.Slides cho C++, bạn có thể tạo cùng loại nội dung toán học một cách lập trình: phân số, căn bậc, hàm, giới hạn, toán tử N-ary, ma trận, mảng và các khối toán học được định dạng.

Trong PowerPoint, người dùng thường thêm phương trình bằng cách vào **Insert > Equation**:

![Tab Insert của PowerPoint với lệnh Equation được chọn](powerpoint-math-equations_1.png)

Kết quả là văn bản toán học có thể chỉnh sửa trên slide:

![Một slide PowerPoint chứa một phương trình toán học có thể chỉnh sửa](powerpoint-math-equations_2.png)

Aspose.Slides xây dựng văn bản toán học đó thông qua ba đối tượng chính:

- Một hình toán học, được tạo bằng [AddMathShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shapecollection/), là hình chứa phương trình.
- [MathPortion](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathportion/) lưu trữ nội dung toán học trong khung văn bản của hình.
- [MathParagraph](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathparagraph/) chứa một hoặc nhiều đối tượng [MathBlock](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathblock/).

Hầu hết các ví dụ bên dưới sử dụng [MathematicalText](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathematicaltext/) và các phương thức fluent từ [IMathElement](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/) để giữ cho mã ngắn gọn và dễ đọc.

Đối với các kịch bản xuất MathML, xem [Export Math Equations from Presentations in C++](/slides/vi/cpp/exporting-math-equations/).

## **Tạo một Phương trình**

Ví dụ này tạo một hình toán học và thêm định lý Pythagoras:

![Phương trình c bình phương bằng a bình phương cộng b bình phương](powerpoint-math-equations_3.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equation = System::MakeObject<MathematicalText>(u"c")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"));

mathParagraph->Add(equation);

presentation->Save(u"pythagorean-theorem.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

{{% alert color="primary" %}}
`AddMathShape` tạo một hình đã chứa sẵn một đoạn toán học. Truy cập `MathPortion` đầu tiên, lấy `MathParagraph` của nó và thêm các khối toán học hoặc các phần tử toán học vào đó.
{{% /alert %}}

## **Thêm Phân Số**

Sử dụng `Divide` để tạo một phân số. Bạn có thể chọn kiểu phân số bằng [MathFractionTypes](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathfractiontypes/).

![Một phân số toán học nghiêng hiển thị 1 chia cho x](powerpoint-math-equations_4.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto fraction = System::MakeObject<MathematicalText>(u"1")
        - >Divide(u"x", MathFractionTypes::Skewed);

mathParagraph->Add(System::MakeObject<MathBlock>(fraction));

presentation->Save(u"fraction.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Đối với phân số chồng, sử dụng `MathFractionTypes::Bar`:

```cpp
auto stackedFraction = System::MakeObject<MathematicalText>(u"x + 1")->Divide(u"y - 1", MathFractionTypes::Bar);
```

## **Thêm Căn Bậc**

Sử dụng `Radical` để tạo căn bậc hai, căn bậc ba hoặc các căn khác. Phần tử hiện tại trở thành mẫu, và đối số trở thành bậc.

![Một biểu thức căn bậc n với x dưới dấu căn](powerpoint-math-equations_5.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto radical = System::MakeObject<MathematicalText>(u"x")
        - >Radical(u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(radical));

presentation->Save(u"radical.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Hàm và Giới Hạn**

Sử dụng `AsArgumentOfFunction` hoặc `Function` cho các hàm như `sin(x)`, `log(x)`, hoặc tên hàm tùy chỉnh. Đối với giới hạn, đặt `lim` trong một [MathLimit](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathlimit/) hoặc sử dụng `SetLowerLimit`.

![Giới hạn của x khi x tiến tới vô cùng](powerpoint-math-equations_8.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto limit = System::MakeObject<MathematicalText>(u"lim")
        - >SetLowerLimit(u"x→∞")
        - >Function(u"x");

mathParagraph->Add(System::MakeObject<MathBlock>(limit));

presentation->Save(u"functions-and-limits.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Đối với tên hàm tùy chỉnh, đặt tên hàm làm phần tử hiện tại:

```cpp
auto customFunction = System::MakeObject<MathematicalText>(u"f")->Function(u"x + 1");
```

## **Thêm Toán Tử N-ary và Tích Phân**

Sử dụng `Nary` cho các phép cộng, hợp, giao và các toán tử lớn khác. Sử dụng `Integral` cho tích phân. Cả hai phương pháp đều cho phép bạn đặt giới hạn dưới và trên.

![Một phép cộng có giới hạn dưới và trên](powerpoint-math-equations_7.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto summationBase = System::MakeObject<MathematicalText>(u"x")
        - >SetSuperscript(u"k")
        - >Join(System::MakeObject<MathematicalText>(u"a")->SetSuperscript(u"n-k"));

auto summation = summationBase->Nary(MathNaryOperatorTypes::Summation, u"k=0", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(summation));

presentation->Save(u"nary-operators.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

Các toán tử N-ary dành cho các toán tử lớn có thể có hoặc không có giới hạn. Các toán tử đơn giản như `+`, `-` và `=` thường được thêm dưới dạng `MathematicalText` và nối vào biểu thức.

Đối với tích phân, sử dụng `Integral`:

```cpp
auto integralBase = System::MakeObject<MathematicalText>(u"x")->Join(System::MakeObject<MathematicalText>(u"dx")->ToBox());
auto integral = integralBase->Integral(MathIntegralTypes::Simple, u"0", u"1");
```

## **Thêm Ma Trận**

Sử dụng [MathMatrix](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathmatrix/) cho các hàng và cột. Ma trận không bao gồm dấu ngoặc đơn mặc định, vì vậy hãy bao quanh ma trận khi bạn cần dấu ngoặc tròn, ngoặc vuông hoặc ngoặc nhọn.

![Một ma trận toán học hai hàng với một ô trống](powerpoint-math-equations_10.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto matrix = System::MakeObject<MathMatrix>(2, 3);
matrix->idx_set(0, 0, System::MakeObject<MathematicalText>(u"1"));
matrix->idx_set(0, 1, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 0, System::MakeObject<MathematicalText>(u"x"));
matrix->idx_set(1, 1, System::MakeObject<MathematicalText>(u"2"));
matrix->idx_set(1, 2, System::MakeObject<MathematicalText>(u"y"));

mathParagraph->Add(System::MakeObject<MathBlock>(matrix));

presentation->Save(u"matrix.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Mảng Phương Trình**

Sử dụng `ToMathArray` khi bạn cần các phương trình được căn chỉnh hoặc một chuỗi dọc các biểu thức.

![Một mảng toán học dọc với x ở trên y](powerpoint-math-equations_11.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 140.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto equationArray = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >ToMathArray();

mathParagraph->Add(System::MakeObject<MathBlock>(equationArray));

presentation->Save(u"equation-array.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Hàm Lượng Giác**

Sử dụng `AsArgumentOfFunction` khi đối số là phần tử hiện tại và tên hàm đã biết.

![Hàm lượng giác cos áp dụng cho 2x](powerpoint-math-equations_6.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto cosine = System::MakeObject<MathematicalText>(u"2x")
        - >AsArgumentOfFunction(MathFunctionsOfOneArgument::Cos);

mathParagraph->Add(System::MakeObject<MathBlock>(cosine));

presentation->Save(u"trigonometric-function.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Chỉ Số Dưới và Chỉ Số Trên**

Sử dụng các công cụ phụ trợ chỉ số dưới và chỉ số trên cho các chỉ mục và lũy thừa. Khi các chỉ số cần xuất hiện phía bên trái của mẫu, sử dụng `SetSubSuperscriptOnTheLeft`.

![Một ký tự Y in hoa với chỉ số dưới 1 và chỉ số trên n ở phía bên trái](powerpoint-math-equations_9.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto scripts = System::MakeObject<MathematicalText>(u"Y")
        - >SetSubSuperscriptOnTheLeft(u"1", u"n");

mathParagraph->Add(System::MakeObject<MathBlock>(scripts));

presentation->Save(u"subscript-superscript.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Dấu Phân Cách**

Sử dụng `Enclose` để đặt một biểu thức bên trong dấu phân cách. Bạn cũng có thể đặt ký tự phân tách cho các biểu thức dấu phân cách có nhiều phần tử.

![Một biểu thức dấu phân cách chứa x, y và z được ngăn cách bằng các thanh dọc](powerpoint-math-equations_13.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto delimiter = System::MakeObject<MathematicalText>(u"x")
        - >Join(u"y")
        - >Join(u"z")
        - >Enclose(u'<', u'>', u'|');

mathParagraph->Add(System::MakeObject<MathBlock>(delimiter));

presentation->Save(u"delimiters.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Thêm Khung Viền**

Sử dụng `ToBorderBox` khi phương trình cần được đóng khung.

![Một phương trình được đóng khung hiển thị a bình phương bằng b bình phương cộng c bình phương](powerpoint-math-equations_12.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto boxedEquation = System::MakeObject<MathematicalText>(u"a")
        - >SetSuperscript(u"2")
        - >Join(u"=")
        - >Join(System::MakeObject<MathematicalText>(u"b")->SetSuperscript(u"2"))
        - >Join(u"+")
        - >Join(System::MakeObject<MathematicalText>(u"c")->SetSuperscript(u"2"))
        - >ToBorderBox();

mathParagraph->Add(System::MakeObject<MathBlock>(boxedEquation));

presentation->Save(u"border-box.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Nhóm Các Thuật Ngữ**

Sử dụng `Group` để đặt ký tự nhóm phía trên hoặc phía dưới một biểu thức. Thêm một giới hạn để gắn nhãn cho các thuật ngữ đã nhóm.

![Biểu thức x cộng y được nhóm với nhãn bất kỳ phía dưới](powerpoint-math-equations_15.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 120.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto grouped = System::MakeObject<MathematicalText>(u"x + y")
        - >Group(u'\u23DF', MathTopBotPositions::Bottom, MathTopBotPositions::Top)
        - >SetLowerLimit(u"any text");

mathParagraph->Add(System::MakeObject<MathBlock>(grouped));

presentation->Save(u"grouped-terms.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Định Dạng Các Phần Tử Toán Học**

Chỉ sử dụng các công cụ định dạng khi chúng làm rõ công thức. Ví dụ, `Overbar` đặt một thanh phía trên một phần tử toán học.

![Một biểu thức toán học ABC với một thanh trên](powerpoint-math-equations_14.png)

```cpp
auto presentation = System::MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto mathShape = slide->get_Shapes()->AddMathShape(20.0f, 20.0f, 700.0f, 100.0f);
auto mathPortion = System::ExplicitCast<MathPortion>(mathShape->get_TextFrame()->get_Paragraph(0)->get_Portion(0));
auto mathParagraph = mathPortion->get_MathParagraph();

auto overbar = System::MakeObject<MathematicalText>(u"ABC")->Overbar();

mathParagraph->Add(System::MakeObject<MathBlock>(overbar));

presentation->Save(u"overbar.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Tham Khảo Nhanh**

| Nhiệm vụ | Main API |
| --- | --- |
| Tạo văn bản toán học | [MathematicalText](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathematicaltext/) |
| Kết hợp các phần tử | [IMathElement.Join](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/join/) |
| Tạo phân số | [IMathElement.Divide](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/divide/) |
| Thêm chỉ số trên hoặc chỉ số dưới | [SetSuperscript](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/setsuperscript/), [SetSubscript](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/setsubscript/) |
| Thêm hàm | [Function](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/function/), [AsArgumentOfFunction](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/asargumentoffunction/) |
| Thêm căn bậc | [IMathElement.Radical](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/radical/) |
| Thêm giới hạn | [SetLowerLimit](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/setlowerlimit/), [SetUpperLimit](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/setupperlimit/) |
| Thêm chỉ số bên trái | [SetSubSuperscriptOnTheLeft](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/setsubsuperscriptontheleft/) |
| Thêm phép cộng và tích phân | [Nary](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/nary/), [Integral](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/integral/) |
| Thêm ma trận | [MathMatrix](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/mathmatrix/) |
| Thêm mảng phương trình | [ToMathArray](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/tomatharray/) |
| Thêm dấu phân cách | [Enclose](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/enclose/) |
| Thêm thanh và viền | [Overbar](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/overbar/), [ToBorderBox](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/toborderbox/) |
| Nhóm các thuật ngữ | [Group](https://reference.aspose.com/slides/vi/cpp/aspose.slides.mathtext/imathelement/group/) |

## **Câu hỏi thường gặp**

**Tôi có thể chỉnh sửa một phương trình PowerPoint hiện có không?**

Có. Mở bản trình chiếu, tìm hình chứa một `MathPortion`, lấy `MathParagraph` của nó và cập nhật các khối toán học trong đoạn đó.

**Các phương trình có được lưu dưới dạng toán học PowerPoint có thể chỉnh sửa không?**

Có. Khi lưu dưới dạng PPTX, Aspose.Slides ghi phương trình dưới dạng nội dung Office math có thể chỉnh sửa.

**Tôi có thể xuất phương trình sang LaTeX không?**

Aspose.Slides xuất các phương trình toán học sang MathML. Nếu bạn cần LaTeX, hãy xuất sang MathML trước rồi chuyển đổi MathML bằng công cụ hỗ trợ định dạng LaTeX mục tiêu của bạn.