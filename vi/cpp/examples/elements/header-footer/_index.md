---
title: Đầu trang và Chân trang
type: docs
weight: 220
url: /vi/cpp/examples/elements/header-footer/
keywords:
- ví dụ mã
- đầu trang
- chân trang
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Kiểm soát đầu trang và chân trang của slide bằng Aspose.Slides cho C++: thêm ngày, số slide và văn bản tùy chỉnh trong PPT, PPTX và ODP với các ví dụ C++."
---
Bài viết này trình bày cách thêm footer và cập nhật các placeholder ngày và giờ bằng **Aspose.Slides for C++**.

## **Thêm Footer**
Thêm văn bản vào vùng footer của một slide và hiển thị nó.

```cpp
static void AddHeaderFooter()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetFooterText(u"My footer");
    slide->get_HeaderFooterManager()->SetFooterVisibility(true);

    presentation->Dispose();
}
```

## **Cập nhật Ngày và Giờ**
Sửa đổi placeholder ngày và giờ trên một slide.

```cpp
static void UpdateDateTime()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    slide->get_HeaderFooterManager()->SetDateTimeText(u"01/01/2024");
    slide->get_HeaderFooterManager()->SetDateTimeVisibility(true);

    presentation->Dispose();
}
```