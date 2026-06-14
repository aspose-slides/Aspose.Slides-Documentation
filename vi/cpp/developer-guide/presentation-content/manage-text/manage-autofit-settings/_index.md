---
title: Nâng cao bài thuyết trình của bạn với AutoFit trong C++
linktitle: Cài đặt Autofit
type: docs
weight: 30
url: /vi/cpp/manage-autofit-settings/
keywords:
- hộp văn bản
- tự động vừa
- không tự động vừa
- vừa văn bản
- thu nhỏ văn bản
- ngắt dòng văn bản
- điều chỉnh kích thước hình dạng
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Tìm hiểu cách quản lý cài đặt AutoFit trong Aspose.Slides cho C++ để tối ưu hiển thị văn bản trong các bài thuyết trình PowerPoint và OpenDocument và cải thiện khả năng đọc nội dung."
---
## **Introduction**

Mặc định, khi bạn thêm một hộp văn bản, Microsoft PowerPoint sử dụng cài đặt **Resize shape to fix text** cho hộp văn bản — nó tự động thay đổi kích thước hộp văn bản để đảm bảo văn bản luôn vừa vào trong.

![textbox-in-powerpoint](textbox-in-powerpoint.png)

* Khi văn bản trong hộp văn bản dài hơn hoặc lớn hơn, PowerPoint tự động mở rộng hộp văn bản — tăng chiều cao — để cho phép chứa nhiều văn bản hơn. 
* Khi văn bản trong hộp văn bản ngắn hơn hoặc nhỏ hơn, PowerPoint tự động giảm hộp văn bản — giảm chiều cao — để loại bỏ không gian dư thừa. 

Trong PowerPoint, có 4 tham số hoặc tùy chọn quan trọng điều khiển hành vi autofit cho hộp văn bản:

* **Do not Autofit**
* **Shrink text on overflow**
* **Resize shape to fit text**
* **Wrap text in shape.**

![autofit-options-powerpoint](autofit-options-powerpoint.png)

Aspose.Slides for C++ cung cấp các tùy chọn tương tự — một số phương thức trong lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format) — cho phép bạn kiểm soát hành vi autofit cho các hộp văn bản trong bài thuyết trình.

## **Resize a Shape to Fit Text**

Nếu bạn muốn văn bản trong một ô luôn vừa vào ô đó sau khi thay đổi nội dung, bạn phải sử dụng tùy chọn **Resize shape to fix text**. Để chỉ định cài đặt này, hãy đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format)) thành `Shape`.

![alwaysfit-setting-powerpoint](alwaysfit-setting-powerpoint.png)

Đoạn mã C++ này cho bạn thấy cách chỉ định rằng văn bản luôn phải vừa vào hộp của nó trong một bài thuyết trình PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Shape);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Nếu văn bản dài hơn hoặc lớn hơn, hộp văn bản sẽ tự động thay đổi kích thước (tăng chiều cao) để đảm bảo toàn bộ văn bản vừa vào. Nếu văn bản ngắn hơn, quá trình ngược lại sẽ xảy ra.

## **Do Not Autofit**

Nếu bạn muốn một hộp văn bản hoặc hình dạng giữ nguyên kích thước bất kể các thay đổi của văn bản bên trong, bạn phải sử dụng tùy chọn **Do not Autofit**. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format)) thành `None`. 

![donotautofit-setting-powerpoint](donotautofit-setting-powerpoint.png)

Đoạn mã C++ này cho bạn thấy cách chỉ định rằng một hộp văn bản luôn phải giữ nguyên kích thước trong một bài thuyết trình PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::None);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

Khi văn bản quá dài so với hộp của nó, nó sẽ tràn ra.

## **Shrink Text on Overflow**

Nếu một đoạn văn bản quá dài so với hộp của nó, bằng tùy chọn **Shrink text on overflow**, bạn có thể chỉ định rằng kích thước và khoảng cách của văn bản phải được giảm để vừa vào hộp. Để chỉ định cài đặt này, đặt thuộc tính [AutofitType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format#acc706fb4d991d137831a6d50eea05e73) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format)) thành `Normal`.

![shrinktextonoverflow-setting-powerpoint](shrinktextonoverflow-setting-powerpoint.png)

Đoạn mã C++ này cho bạn thấy cách chỉ định rằng văn bản phải được thu nhỏ khi tràn trong một bài thuyết trình PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_AutofitType(TextAutofitType::Normal);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Info" color="info" %}}
Khi sử dụng tùy chọn **Shrink text on overflow**, cài đặt chỉ được áp dụng khi văn bản quá dài so với hộp của nó. 
{{% /alert %}}

## **Wrap Text**

Nếu bạn muốn văn bản trong một hình dạng được tự động ngắt dòng bên trong hình dạng khi văn bản vượt quá biên của hình dạng (chỉ chiều rộng), bạn phải sử dụng tham số **Wrap text in shape**. Để chỉ định cài đặt này, bạn cần đặt thuộc tính [WrapText](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format#aecc980adb13e3cf7162d09f99b5bbfd1) (từ lớp [TextFrameFormat](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame_format)) thành `true`. 

Đoạn mã C++ này cho bạn thấy cách sử dụng cài đặt Wrap Text trong một bài thuyết trình PowerPoint:

```cpp
auto pres = System::MakeObject<Presentation>();
auto slide = pres->get_Slides()->idx_get(0);
auto autoShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 30.0f, 30.0f, 350.0f, 100.0f);
auto textFrame = autoShape->get_TextFrame();

auto portion = System::MakeObject<Portion>(u"lorem ipsum...");
auto fillFormat = portion->get_PortionFormat()->get_FillFormat();
fillFormat->get_SolidFillColor()->set_Color(Color::get_Black());
fillFormat->set_FillType(FillType::Solid);
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->Add(portion);

auto textFrameFormat = textFrame->get_TextFrameFormat();
textFrameFormat->set_WrapText(NullableBool::True);

pres->Save(u"Output-presentation.pptx", SaveFormat::Pptx);
```

{{% alert title="Note" color="warning" %}} 
Nếu bạn đặt thuộc tính `WrapText` thành `False` cho một hình dạng, khi văn bản bên trong hình dạng dài hơn chiều rộng của hình dạng, văn bản sẽ kéo dài ra ngoài biên của hình dạng trên một dòng duy nhất. 
{{% /alert %}}

## **FAQ**

**Các lề trong của khung văn bản có ảnh hưởng đến AutoFit không?**

Có. Đệm (lề trong) làm giảm vùng có thể sử dụng cho văn bản, do đó AutoFit sẽ kích hoạt sớm hơn — thu nhỏ phông chữ hoặc thay đổi kích thước hình dạng nhanh hơn. Kiểm tra và điều chỉnh lề trước khi tinh chỉnh AutoFit.

**AutoFit tương tác như thế nào với ngắt dòng thủ công và ngắt dòng mềm?**

Các ngắt dòng bắt buộc vẫn giữ nguyên, và AutoFit điều chỉnh kích thước phông chữ và khoảng cách xung quanh chúng. Loại bỏ các ngắt không cần thiết thường giảm mức độ AutoFit phải thu nhỏ văn bản.

**Việc thay đổi phông chữ chủ đề hoặc kích hoạt việc thay thế phông chữ có ảnh hưởng đến kết quả AutoFit không?**

Có. Thay thế bằng một phông chữ có số liệu glyph khác nhau sẽ thay đổi độ rộng/chiều cao của văn bản, điều này có thể làm thay đổi kích thước phông chữ cuối cùng và cách ngắt dòng. Sau bất kỳ thay đổi hoặc thay thế phông chữ nào, hãy kiểm tra lại các slide.