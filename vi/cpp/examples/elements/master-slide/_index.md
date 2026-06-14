---
title: Slide mẫu
type: docs
weight: 30
url: /vi/cpp/examples/elements/master-slide/
keywords:
- ví dụ mã
- slide mẫu
- PowerPoint
- OpenDocument
- bài thuyết trình
- C++
- Aspose.Slides
description: "Khám phá các ví dụ slide mẫu trong Aspose.Slides cho C++: tạo, chỉnh sửa và định dạng master, placeholder và theme trong PPT, PPTX và ODP bằng mã C++ rõ ràng."
---
Master slide tạo thành cấp cao nhất của cây kế thừa slide trong PowerPoint. Một **master slide** xác định các yếu tố thiết kế chung như nền, logo và định dạng văn bản. **layout slide** kế thừa từ master slide, và **normal slide** kế thừa từ layout slide.

Bài viết này trình bày cách tạo, chỉnh sửa và quản lý master slide bằng Aspose.Slides cho C++.

## **Thêm Master Slide**

Ví dụ này cho thấy cách tạo một master slide mới bằng cách sao chép master slide mặc định. Sau đó, nó thêm một biểu ngữ tên công ty vào tất cả các slide thông qua việc kế thừa layout.

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Sao chep slide mau mac dinh.
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // Them bieu ngu voi ten cong ty vao phan dau cua slide mau.
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // Gan slide mau moi cho mot layout slide.
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // Gan layout slide cho slide dau tien trong ban trinh chieu.
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Lưu ý 1:** Master slide cung cấp cách áp dụng thương hiệu nhất quán hoặc các yếu tố thiết kế chung cho tất cả các slide. Bất kỳ thay đổi nào được thực hiện trên master sẽ tự động phản ánh trên các layout và normal slide phụ thuộc.
> 
> 💡 **Lưu ý 2:** Bất kỳ hình dạng hoặc định dạng nào được thêm vào master slide đều được kế thừa bởi các layout slide và, từ đó, tất cả các normal slide sử dụng các layout đó. Hình ảnh dưới đây minh họa cách một hộp văn bản được thêm vào master slide sẽ tự động được hiển thị trên slide cuối cùng.

![Ví dụ Kế thừa Master](master-slide-banner.png)

## **Truy cập Master Slide**

Bạn có thể truy cập master slide bằng cách sử dụng bộ sưu tập master của bản trình chiếu. Dưới đây là cách lấy và làm việc với chúng:

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // Thay đổi loại nền.
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **Xóa Master Slide**

Master slide có thể được xóa bằng chỉ mục hoặc bằng tham chiếu.

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // Xóa một slide mẫu bằng chỉ mục.
    presentation->get_Masters()->RemoveAt(0);

    // Xóa một slide mẫu bằng tham chiếu.
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **Xóa Master Slide không sử dụng**

Một số bản trình chiếu chứa các master slide không được sử dụng. Việc xóa các slide này có thể giúp giảm kích thước tệp.

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Xóa tất cả các slide mẫu không dùng (kể cả những slide được đánh dấu Preserve).
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```