---
title: Quản lý hộp văn bản trong bài thuyết trình bằng C++
linktitle: Quản lý hộp văn bản
type: docs
weight: 20
url: /vi/cpp/manage-textbox/
keywords:
- hộp văn bản
- khung văn bản
- thêm văn bản
- cập nhật văn bản
- tạo hộp văn bản
- kiểm tra hộp văn bản
- thêm cột văn bản
- thêm siêu liên kết
- PowerPoint
- bài thuyết trình
- C++
- Aspose.Slides
description: "Aspose.Slides cho C++ giúp bạn dễ dàng tạo, chỉnh sửa và sao chép các hộp văn bản trong các tệp PowerPoint và OpenDocument, nâng cao khả năng tự động hoá bài thuyết trình của bạn."
---
## **Giới thiệu**

Văn bản trên các slide thường tồn tại trong các hộp văn bản hoặc hình dạng. Do đó, để thêm văn bản vào một slide, bạn phải thêm một hộp văn bản và sau đó đặt một số văn bản bên trong hộp văn bản. Aspose.Slides cho C++ cung cấp giao diện [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape) cho phép bạn thêm một hình dạng chứa một số văn bản.

{{% alert title="Info" color="info" %}}

Aspose.Slides cũng cung cấp giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_shape) cho phép bạn thêm hình dạng vào slide. Tuy nhiên, không phải tất cả các hình dạng được thêm thông qua giao diện `IShape` đều có thể chứa văn bản. Nhưng các hình dạng được thêm thông qua giao diện [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape) có thể chứa văn bản. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

Vì vậy, khi làm việc với một hình dạng mà bạn muốn thêm văn bản, bạn có thể muốn kiểm tra và xác nhận rằng nó đã được ép kiểu qua giao diện `IAutoShape`. Chỉ khi đó bạn mới có thể làm việc với [TextFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame), là một thuộc tính của `IAutoShape`. Xem phần [Update Text](https://docs.aspose.com/slides/vi/cpp/manage-textbox/#update-text) trên trang này. 

{{% /alert %}}

## **Tạo một Hộp Văn Bản trên Slide**

Để tạo một hộp văn bản trên slide, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation). 
2. Lấy tham chiếu tới slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape) với [ShapeType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu cho đối tượng `IAutoShape` vừa được thêm. 
4. Thêm thuộc tính `TextFrame` vào đối tượng `IAutoShape` sẽ chứa một văn bản. Trong ví dụ dưới đây, chúng tôi đã thêm văn bản: *Aspose TextBox* 
5. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Đoạn mã C++—một triển khai của các bước trên—cho bạn thấy cách thêm văn bản vào slide:

```cpp
// Khởi tạo Presentation
auto pres = System::MakeObject<Presentation>();

// Lấy slide đầu tiên trong bản trình bày
auto sld = pres->get_Slides()->idx_get(0);

// Thêm AutoShape với kiểu được đặt là Rectangle
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// Thêm TextFrame vào Rectangle
ashp->AddTextFrame(u" ");

// Truy cập khung văn bản
auto txtFrame = ashp->get_TextFrame();

// Tạo đối tượng Paragraph cho khung văn bản
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// Tạo đối tượng Portion cho đoạn văn
auto portion = para->get_Portions()->idx_get(0);

// Đặt văn bản
portion->set_Text(u"Aspose TextBox");

// Lưu bản trình bày ra đĩa
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **Kiểm tra Hình dạng Hộp Văn Bản**

Aspose.Slides cung cấp phương thức [get_IsTextBox](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/get_istextbox/) từ giao diện [IAutoShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iautoshape/) cho phép bạn kiểm tra các hình dạng và xác định các hộp văn bản.

![Hộp văn bản và hình dạng](istextbox.png)

Đoạn mã C++ này cho bạn thấy cách kiểm tra xem một hình dạng có được tạo dưới dạng hộp văn bản hay không: 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

Lưu ý rằng nếu bạn chỉ thêm một autoshape bằng phương thức `AddAutoShape` từ giao diện [IShapeCollection](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ishapecollection/) , phương thức `get_IsTextBox` của autoshape sẽ trả về `false`. Tuy nhiên, sau khi bạn thêm văn bản vào autoshape bằng phương thức `AddTextFrame` hoặc phương thức `set_Text`, phương thức `get_IsTextBox` sẽ trả về `true`.

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() trả về false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() trả về true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() trả về false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() trả về true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() trả về false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() trả về false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() trả về false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() trả về false
```

## **Thêm Cột vào Hộp Văn Bản**

Aspose.Slides cung cấp các phương thức [set_ColumnCount](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) và [set_ColumnSpacing](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format) và lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format)) cho phép bạn thêm cột vào các hộp văn bản. Bạn có thể chỉ định số cột trong một hộp văn bản và đặt khoảng cách giữa các cột tính bằng điểm.

Đoạn mã C++ dưới đây minh họa hoạt động đã mô tả: 

```cpp
auto presentation = System::MakeObject<Presentation>();
// Lấy slide đầu tiên trong bản trình bày
auto slide = presentation->get_Slides()->idx_get(0);

// Thêm một AutoShape với kiểu được đặt là Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// Thêm TextFrame vào Rectangle
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// Lấy định dạng văn bản của TextFrame
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// Xác định số cột trong TextFrame
format->set_ColumnCount(3);

// Xác định khoảng cách giữa các cột
format->set_ColumnSpacing(10);

// Lưu bản trình bày
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **Thêm Cột vào Khung Văn Bản**

Aspose.Slides cho C++ cung cấp phương thức [set_ColumnCount](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) (từ giao diện [ITextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_text_frame_format)) cho phép bạn thêm cột trong các khung văn bản. Thông qua phương thức này, bạn có thể chỉ định số cột mong muốn trong một khung văn bản. 

Đoạn mã C++ này cho bạn thấy cách thêm một cột vào trong khung văn bản:

```cpp
String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **Cập Nhật Văn Bản**

Aspose.Slides cho phép bạn thay đổi hoặc cập nhật văn bản chứa trong một hộp văn bản hoặc tất cả các văn bản trong một bản trình bày. 

Đoạn mã C++ này minh họa một thao tác mà tất cả các văn bản trong một bản trình bày được cập nhật hoặc thay đổi:

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
                {
                    //Thay đổi văn bản
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //Thay đổi định dạng
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//Lưu bản trình bày đã sửa đổi
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **Thêm Hộp Văn Bản với Siêu Liên Kết** 

Bạn có thể chèn một liên kết bên trong một hộp văn bản. Khi hộp văn bản được nhấp, người dùng sẽ được chuyển đến liên kết đó. 

Để thêm một hộp văn bản chứa liên kết, thực hiện các bước sau:

1. Tạo một thể hiện của lớp `Presentation`. 
2. Lấy tham chiếu tới slide đầu tiên trong bản trình bày mới tạo. 
3. Thêm một đối tượng `AutoShape` với `ShapeType` được đặt là `Rectangle` tại vị trí xác định trên slide và lấy tham chiếu của đối tượng AutoShape vừa được thêm. 
4. Thêm một `TextFrame` vào đối tượng `AutoShape` chứa *Aspose TextBox* làm văn bản mặc định. 
5. Khởi tạo lớp `IHyperlinkManager`. 
6. Gán đối tượng `IHyperlinkManager` vào phương thức [set_HyperlinkClick](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) liên kết với phần bạn muốn trong `TextFrame`. 
7. Cuối cùng, ghi tệp PPTX thông qua đối tượng `Presentation`. 

Đoạn mã C++—một triển khai của các bước trên—cho bạn thấy cách thêm một hộp văn bản có siêu liên kết vào slide:

```cpp
// Khởi tạo một lớp Presentation đại diện cho file PPTX
auto presentation = System::MakeObject<Presentation>();

// Lấy slide đầu tiên trong bản trình bày
auto slide = presentation->get_Slides()->idx_get(0);

// Thêm một đối tượng AutoShape với kiểu được đặt là Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// Ép kiểu hình dạng sang AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// Truy cập thuộc tính ITextFrame liên quan tới AutoShape
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// Thêm một số văn bản vào khung
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// Đặt siêu liên kết cho văn bản phần
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// Lưu bản trình bày PPTX
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **CÂU HỎI THƯỜNG GẶP**

**Sự khác biệt giữa hộp văn bản và trình giữ chỗ văn bản khi làm việc với các slide master là gì?**

Một [placeholder](/slides/vi/cpp/manage-placeholder/) kế thừa kiểu/định vị từ [master](https://reference.aspose.com/slides/vi/cpp/aspose.slides/masterslide/) và có thể bị ghi đè trên [layouts](https://reference.aspose.com/slides/vi/cpp/aspose.slides/layoutslide/), trong khi một hộp văn bản thông thường là một đối tượng độc lập trên một slide cụ thể và không thay đổi khi bạn chuyển đổi layout.

**Làm thế nào để thực hiện việc thay thế văn bản hàng loạt trên toàn bộ bản trình bày mà không ảnh hưởng đến văn bản trong biểu đồ, bảng và SmartArt?**

Hạn chế vòng lặp của bạn chỉ tới các auto‑shape có khung văn bản và loại trừ các đối tượng nhúng ([charts](https://reference.aspose.com/slides/vi/cpp/aspose.slides.charts/chart/), [tables](https://reference.aspose.com/slides/vi/cpp/aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/vi/cpp/aspose.slides.smartart/smartart/)) bằng cách duyệt các bộ sưu tập của chúng riêng biệt hoặc bỏ qua những loại đối tượng đó.