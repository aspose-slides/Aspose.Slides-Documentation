---
title: OLE 物件
type: docs
weight: 210
url: /zh-hant/cpp/examples/elements/ole-object/
keywords:
- 程式碼範例
- OLE 物件
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中處理 OLE 物件：插入、連結、更新，以及使用 C++ 從 PPT、PPTX 和 ODP 簡報中提取嵌入的內容。"
---
本文示範如何將檔案嵌入為 OLE 物件，並使用 **Aspose.Slides for C++** 更新其資料。

## **新增 OLE 物件**

將 PDF 檔案嵌入投影片中。

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

## **存取 OLE 物件**

取得投影片上第一個 OLE 物件框架。

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

## **移除 OLE 物件**

從投影片中刪除已嵌入的 OLE 物件。

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

## **更新 OLE 物件資料**

取代已存在 OLE 物件中嵌入的資料。

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