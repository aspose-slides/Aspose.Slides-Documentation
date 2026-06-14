---
title: Đối tượng OLE
type: docs
weight: 210
url: /vi/cpp/examples/elements/ole-object/
keywords:
- ví dụ mã
- đối tượng OLE
- PowerPoint
- OpenDocument
- bản trình bày
- C++
- Aspose.Slides
description: "Xử lý các đối tượng OLE trong Aspose.Slides for C++: chèn, liên kết, cập nhật và trích xuất nội dung nhúng bằng C++ trong các bản trình chiếu PPT, PPTX và ODP."
---
Bài viết này trình bày cách nhúng tệp dưới dạng đối tượng OLE và cập nhật dữ liệu của nó bằng **Aspose.Slides for C++**.

## **Thêm đối tượng OLE**
Nhúng tệp PDF vào bản trình bày.

```cpp
static void AddOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    presentation->Dispose();
}
```

## **Truy cập đối tượng OLE**
Lấy khung đối tượng OLE đầu tiên trên một slide.

```cpp
static void AccessOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto firstOleFrame = SharedPtr<IOleObjectFrame>();
    for (auto&& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IOleObjectFrame>(shape))
        {
            firstOleFrame = ExplicitCast<IOleObjectFrame>(shape);
            break;
        }
    }

    presentation->Dispose();
}
```

## **Xóa đối tượng OLE**
Xóa đối tượng OLE đã nhúng khỏi slide.

```cpp
static void RemoveOleObject()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    slide->get_Shapes()->Remove(oleFrame);

    presentation->Dispose();
}
```

## **Cập nhật dữ liệu đối tượng OLE**
Thay thế dữ liệu đã nhúng trong một đối tượng OLE hiện có.

```cpp
static void UpdateOleObjectData()
{
    auto presentation = MakeObject<Presentation>();
    auto slide = presentation->get_Slide(0);

    auto pdfData = File::ReadAllBytes(u"doc.pdf");
    auto dataInfo = MakeObject<OleEmbeddedDataInfo>(pdfData, u"pdf");
    auto oleFrame = slide->get_Shapes()->AddOleObjectFrame(20, 20, 50, 50, dataInfo);

    auto newData = File::ReadAllBytes(u"Picture.png");
    auto newDataInfo = MakeObject<OleEmbeddedDataInfo>(newData, u"png");
    oleFrame->SetEmbeddedData(newDataInfo);

    presentation->Dispose();
}
```