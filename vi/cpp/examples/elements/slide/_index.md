---
title: "Slide"
type: docs
weight: 10
url: /vi/cpp/examples/elements/slide/
keywords:
  - "ví dụ mã"
  - "slide"
  - "PowerPoint"
  - "OpenDocument"
  - "bản trình chiếu"
  - "C++"
  - "Aspose.Slides"
description: "Kiểm soát các slide trong Aspose.Slides for C++: tạo, sao chép, sắp xếp lại, thay đổi kích thước, đặt nền, và áp dụng hiệu ứng chuyển đổi bằng C++ cho các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này cung cấp một loạt các ví dụ minh họa cách làm việc với các slide bằng **Aspose.Slides for C++**. Bạn sẽ học cách thêm, truy cập, sao chép, sắp xếp lại và xóa slide bằng lớp `Presentation`.

Mỗi ví dụ bên dưới bao gồm một giải thích ngắn gọn và một đoạn mã mẫu bằng C++.

## **Thêm Slide**

Để thêm một slide mới, trước tiên bạn phải chọn một bố cục. Trong ví dụ này, chúng tôi sử dụng bố cục `Blank` và thêm một slide trống vào bản trình bày.

```cpp
static void AddSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);

    presentation->get_Slides()->AddEmptySlide(blankLayout);

    presentation->Dispose();
}
```

> 💡 **Note:** Mỗi bố cục slide được tạo ra từ một slide chủ, định nghĩa thiết kế tổng thể và cấu trúc các trình giữ chỗ. Hình ảnh bên dưới minh họa cách các slide chủ và các bố cục liên quan được tổ chức trong PowerPoint.

![Master and Layout Relationship](master-layout-slide.png)

## **Truy cập Slide theo Chỉ mục**

Bạn có thể truy cập slide bằng chỉ mục của chúng, hoặc tìm chỉ mục của một slide dựa trên tham chiếu. Điều này hữu ích khi lặp qua hoặc chỉnh sửa các slide cụ thể.

```cpp
static void AccessSlide()
{
    auto presentation = MakeObject<Presentation>();

    // Thêm một slide trống khác.
    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    presentation->get_Slides()->AddEmptySlide(blankLayout);

    // Truy cập các slide theo chỉ mục.
    auto firstSlide = presentation->get_Slide(0);
    auto secondSlide = presentation->get_Slide(1);

    // Lấy chỉ mục slide từ một tham chiếu, sau đó truy cập nó theo chỉ mục.
    auto secondSlideIndex = presentation->get_Slides()->IndexOf(secondSlide);
    auto secondSlideByIndex = presentation->get_Slide(secondSlideIndex);

    presentation->Dispose();
}
```

## **Sao chép Slide**

Ví dụ này minh họa cách sao chép một slide hiện có. Slide đã sao chép sẽ tự động được thêm vào cuối bộ sưu tập slide.

```cpp
static void CloneSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    auto clonedSlideIndex = presentation->get_Slides()->IndexOf(clonedSlide);

    presentation->Dispose();
}
```

## **Sắp xếp lại Slides**

Bạn có thể thay đổi thứ tự của các slide bằng cách di chuyển một slide tới một chỉ mục mới. Trong trường hợp này, chúng tôi di chuyển slide đã sao chép vào vị trí đầu tiên.

```cpp
static void ReorderSlide()
{
    auto presentation = MakeObject<Presentation>();
    auto firstSlide = presentation->get_Slide(0);

    auto clonedSlide = presentation->get_Slides()->AddClone(firstSlide);

    presentation->get_Slides()->Reorder(0, clonedSlide);

    presentation->Dispose();
}
```

## **Xóa Slide**

Để xóa một slide, chỉ cần tham chiếu tới nó và gọi `Remove`. Ví dụ này thêm một slide thứ hai và sau đó xóa slide gốc, chỉ còn lại slide mới.

```cpp
static void RemoveSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto blankLayout = presentation->get_LayoutSlides()->GetByType(SlideLayoutType::Blank);
    auto secondSlide = presentation->get_Slides()->AddEmptySlide(blankLayout);

    auto firstSlide = presentation->get_Slide(0);
    presentation->get_Slides()->Remove(firstSlide);

    presentation->Dispose();
}
```