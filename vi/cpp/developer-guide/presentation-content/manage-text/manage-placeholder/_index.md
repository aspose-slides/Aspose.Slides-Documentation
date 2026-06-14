---
title: Quản lý Placeholder trong Bản trình chiếu bằng C++
linktitle: Quản lý Placeholder
type: docs
weight: 10
url: /vi/cpp/manage-placeholder/
keywords:
- trình giữ chỗ
- trình giữ chỗ văn bản
- trình giữ chỗ hình ảnh
- trình giữ chỗ biểu đồ
- văn bản nhắc
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý placeholder trong Aspose.Slides cho C++ một cách dễ dàng: thay thế văn bản, tùy chỉnh lời nhắc và đặt độ trong suốt cho hình ảnh trong PowerPoint và OpenDocument."
---
## **Tổng quan**

Aspose.Slides cho phép bạn quản lý các placeholder trong bản trình chiếu một cách lập trình. Bài viết này giải thích cách tìm placeholder trên các slide và thay đổi văn bản của chúng, đặt văn bản nhắc tùy chỉnh cho các bố cục placeholder, và điều chỉnh độ trong suốt của hình ảnh được sử dụng làm nền placeholder. Nó cũng bao gồm một phần FAQ ngắn giải thích sự khác biệt giữa placeholder cơ bản và shape cục bộ, mô tả cách áp dụng thay đổi placeholder thông qua bố cục hoặc master, và chỉ dẫn quản lý placeholder header và footer.

## **Thay đổi Văn bản trong Placeholder**
Sử dụng [Aspose.Slides for C++](/slides/vi/cpp/), bạn có thể tìm và chỉnh sửa các placeholder trên các slide trong bản trình chiếu. Aspose.Slides cho phép bạn thực hiện các thay đổi đối với văn bản trong một placeholder.

**Yêu cầu trước**: Bạn cần một bản trình chiếu chứa placeholder. Bạn có thể tạo bản trình chiếu như vậy bằng ứng dụng Microsoft PowerPoint tiêu chuẩn.

Đây là cách bạn sử dụng Aspose.Slides để thay thế văn bản trong placeholder trong bản trình chiếu đó:

1. Khởi tạo lớp [`Presentation`](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/) và truyền bản trình chiếu làm đối số.
2. Lấy tham chiếu slide bằng chỉ mục của nó.
3. Duyệt qua các shape để tìm placeholder.
4. Ép kiểu shape placeholder thành một [`AutoShape`](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.auto_shape/) và thay đổi văn bản bằng cách sử dụng [`TextFrame`](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.text_frame/) liên kết với [`AutoShape`](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.auto_shape/).
5. Lưu bản trình chiếu đã sửa đổi.

Đoạn mã C++ dưới đây cho thấy cách thay đổi văn bản trong placeholder:

```c++
// Đường dẫn tới thư mục tài liệu.
const String outPath = u"../out/ReplacingText_out.pptx";
const String templatePath = u"../templates/DefaultFonts.pptx";


// Loads the desired the presentation
SharedPtr<Presentation> pres = MakeObject<Presentation>(templatePath);

// Accesses the first slide
SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

// Accesses the first and second placeholder in the slide and typecasts it as an AutoShape
SharedPtr<IShape> shape = slide->get_Shapes()->idx_get(0);
SharedPtr<AutoShape> ashp = ExplicitCast<Aspose::Slides::AutoShape>(shape);

SharedPtr<ITextFrame> textframe = ashp->get_TextFrame();

textframe->set_Text(u"This is Placeholder");
	
// Lưu bản trình chiếu vào đĩa
pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Đặt Văn bản Nhắc trong Placeholder**
Các bố cục tiêu chuẩn và đã dựng sẵn chứa các văn bản nhắc placeholder như ***Click to add a title*** hoặc ***Click to add a subtitle***. Sử dụng Aspose.Slides, bạn có thể chèn các văn bản nhắc ưa thích của mình vào các bố cục placeholder.

Đoạn mã C++ dưới đây cho thấy cách đặt văn bản nhắc trong placeholder:

```c++
const System::String templatePath = u"../templates/Presentation2.pptx";
    
auto pres = System::MakeObject<Presentation>(templatePath);
auto slide = pres->get_Slides()->idx_get(0);

for (auto& shape : slide->get_Shapes())
{
    if (shape->get_Placeholder() != NULL)
    {
        System::String text = u"";
        if (shape->get_Placeholder()->get_Type() == PlaceholderType::CenteredTitle) // Khi không có văn bản nào trong đó, PowerPoint hiển thị "Click to add title".
        {
            text = u"Click to add title";
        }
        else if (shape->get_Placeholder()->get_Type() == PlaceholderType::Subtitle) // Thực hiện tương tự cho phụ đề.
        {
            text = u"Click to add subtitle";
        }
        System::Console::WriteLine(u"Placeholder : {0}", text);
    }
}

pres->Save(u"../out/Placeholders_PromptText.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Đặt Độ trong suốt Hình ảnh Placeholder**

Aspose.Slides cho phép bạn đặt độ trong suốt của hình ảnh nền trong một placeholder văn bản. Bằng cách điều chỉnh độ trong suốt của hình ảnh trong khung này, bạn có thể làm cho văn bản hoặc hình ảnh nổi bật (tùy thuộc vào màu sắc của văn bản và hình ảnh).

Đoạn mã C++ dưới đây cho thấy cách đặt độ trong suốt cho nền hình ảnh (bên trong một shape):

```c++
auto presentation = System::MakeObject<Presentation>();
    
auto autoShape = presentation->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 10.0f, 10.0f, 100.0f, 100.0f);
    
auto fillFormat = autoShape->get_FillFormat();
fillFormat->set_FillType(Aspose::Slides::FillType::Picture);
fillFormat->get_PictureFillFormat()->get_Picture()->set_Image(presentation->get_Images()->AddImage(System::IO::File::ReadAllBytes(u"image.png")));

auto pictureFillFormat = fillFormat->get_PictureFillFormat();
pictureFillFormat->set_PictureFillMode(Aspose::Slides::PictureFillMode::Stretch);
pictureFillFormat->get_Picture()->get_ImageTransform()->AddAlphaModulateFixedEffect(75.0f);
```

## **Câu hỏi thường gặp**

**Placeholder cơ bản là gì, và nó khác gì so với shape cục bộ trên một slide?**

Placeholder cơ bản là shape gốc trên một layout hoặc master mà shape của slide kế thừa—loại, vị trí và một số định dạng được lấy từ nó. Shape cục bộ là độc lập; nếu không có placeholder cơ bản, việc kế thừa sẽ không áp dụng.

**Làm thế nào để cập nhật tất cả tiêu đề hoặc chú thích trong toàn bộ bản trình chiếu mà không cần duyệt qua từng slide?**

Chỉnh sửa placeholder tương ứng trên layout hoặc master. Các slide dựa trên các layout/master đó sẽ tự động kế thừa thay đổi.

**Làm thế nào để kiểm soát các placeholder tiêu chuẩn cho header/footer—ngày & giờ, số slide và văn bản footer?**

Sử dụng các trình quản lý HeaderFooter ở phạm vi phù hợp (slide thường, layout, master, notes/handouts) để bật hoặc tắt các placeholder đó và đặt nội dung của chúng.