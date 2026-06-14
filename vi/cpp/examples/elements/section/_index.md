---
title: Phần
type: docs
weight: 90
url: /vi/cpp/examples/elements/section/
keywords:
- ví dụ mã
- phần
- PowerPoint
- OpenDocument
- bản trình chiếu
- C++
- Aspose.Slides
description: "Quản lý các phần slide trong Aspose.Slides for C++: tạo, đổi tên, sắp xếp lại và nhóm các slide với các ví dụ C++ cho PPT, PPTX và ODP."
---
Các ví dụ về việc quản lý các phần trong bản trình chiếu—thêm, truy cập, xóa và đổi tên chúng một cách lập trình bằng **Aspose.Slides for C++**.

## **Thêm Phần**

Tạo một phần bắt đầu tại một slide cụ thể.

```cpp
static void AddSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    // Chỉ định slide đánh dấu phần bắt đầu.
    presentation->get_Sections()->AddSection(u"New Section", slide);

    presentation->Dispose();
}
```

## **Truy cập Phần**

Đọc thông tin phần từ một bản trình chiếu.

```cpp
static void AccessSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"My Section", slide);

    // Truy cập phần theo chỉ mục.
    auto section = presentation->get_Section(0);
    auto sectionName = section->get_Name();

    presentation->Dispose();
}
```

## **Xóa Phần**

Xóa một phần đã được thêm trước đó.

```cpp
static void RemoveSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto section = presentation->get_Sections()->AddSection(u"Temporary Section", slide);

    // Xóa phần đầu tiên.
    presentation->get_Sections()->RemoveSection(section);

    presentation->Dispose();
}
```

## **Đổi tên Phần**

Thay đổi tên của một phần hiện có.

```cpp
static void RenameSection()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    presentation->get_Sections()->AddSection(u"Old Name", slide);

    auto section = presentation->get_Section(0);
    section->set_Name(u"New Name");

    presentation->Dispose();
}
```