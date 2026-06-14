---
title: Slide Bố cục
type: docs
weight: 20
url: /vi/cpp/examples/elements/layout-slide/
keywords:
- ví dụ mã
- slide bố cục
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Quản lý slide bố cục trong Aspose.Slides cho C++: chọn, áp dụng và tùy chỉnh bố cục slide, các trình giữ chỗ và mẫu chính với các ví dụ C++ cho bản trình bày PPT, PPTX và ODP."
---
Bài viết này trình bày cách làm việc với **Layout Slides** trong Aspose.Slides cho C++. Một layout slide định nghĩa thiết kế và định dạng được kế thừa bởi các slide thông thường. Bạn có thể thêm, truy cập, sao chép và xóa layout slides, cũng như dọn dẹp các layout không sử dụng để giảm kích thước bản trình bày.

## **Thêm Layout Slide**

Bạn có thể tạo một layout slide tùy chỉnh để định nghĩa định dạng có thể tái sử dụng. Ví dụ, bạn có thể thêm một hộp văn bản xuất hiện trên tất cả các slide sử dụng layout này.

```cpp
static void AddLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto masterSlide = presentation->get_Master(0);

    // Tạo một layout slide với loại bố cục trống và tên tùy chỉnh.
    auto layoutSlide = presentation->get_LayoutSlides()->Add(masterSlide, SlideLayoutType::Blank, u"Main layout");

    // Thêm một hộp văn bản vào layout slide.
    auto layoutTextBox = layoutSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 75, 75, 150, 150);
    layoutTextBox->get_TextFrame()->set_Text(u"Layout Slide Text");

    // Thêm hai slide sử dụng layout này; cả hai sẽ kế thừa văn bản từ layout.
    presentation->get_Slides()->AddEmptySlide(layoutSlide);
    presentation->get_Slides()->AddEmptySlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **Lưu ý 1:** Layout slides đóng vai trò như mẫu cho các slide riêng lẻ. Bạn có thể định nghĩa các yếu tố chung một lần và tái sử dụng chúng trên nhiều slide.

> 💡 **Lưu ý 2:** Khi bạn thêm hình dạng hoặc văn bản vào một layout slide, tất cả các slide dựa trên layout đó sẽ tự động hiển thị nội dung chung này.
> Ảnh chụp màn hình bên dưới cho thấy hai slide, mỗi slide kế thừa một hộp văn bản từ cùng một layout slide.

![Slides Kế thừa Nội dung Layout](layout-slide-result.png)

## **Truy cập Layout Slide**

```cpp
static void AccessLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Truy cập một layout slide theo chỉ mục.
    auto firstLayoutSlide = presentation->get_LayoutSlide(0);

    // Truy cập một layout slide theo loại.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->Dispose();
}
```

## **Xóa Layout Slide**

Bạn có thể xóa một layout slide cụ thể nếu nó không còn cần thiết.

```cpp
static void RemoveLayoutSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Lấy một layout slide theo loại và xóa nó.
    auto blankLayoutSlide = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Custom);
    presentation->get_LayoutSlides()->Remove(blankLayoutSlide);

    presentation->Dispose();
}
```

## **Xóa Layout Slides Không Sử Dụng**

Để giảm kích thước bản trình bày, bạn có thể muốn xóa các layout slide không được bất kỳ slide thông thường nào sử dụng.

```cpp
static void RemoveUnusedLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Tự động xóa tất cả các layout slide không được bất kỳ slide nào tham chiếu.
    presentation->get_LayoutSlides()->RemoveUnused();

    presentation->Dispose();
}
```

## **Sao chép Layout Slide**

Bạn có thể sao chép một layout slide bằng cách sử dụng phương thức `AddClone`.

```cpp
static void CloneLayoutSlides()
{
    auto presentation = MakeObject<Presentation>();

    // Lấy một layout slide hiện có theo loại.
    // Sao chép layout slide tới cuối bộ sưu tập layout slide.
    auto clonedLayoutSlide = presentation->get_LayoutSlides()->AddClone(blankLayoutSlide);

    presentation->Dispose();
}
```

> ✅ **Tóm tắt:** Layout slides là công cụ mạnh mẽ để quản lý định dạng nhất quán trên các slide. Aspose.Slides cho phép kiểm soát đầy đủ việc tạo, quản lý và tối ưu hóa layout slides.