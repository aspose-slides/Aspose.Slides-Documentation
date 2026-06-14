---
title: 母片
type: docs
weight: 30
url: /zh-hant/cpp/examples/elements/master-slide/
keywords:
- 程式碼範例
- 母片
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "探索 Aspose.Slides for C++ 的母片示例：在 PPT、PPTX 與 ODP 中建立、編輯與樣式化母片、佔位符與主題，並提供清晰的 C++ 程式碼。"
---
母片構成 PowerPoint 投影片繼承層級的最上層。**母片** 定義背景、標誌和文字格式等共通設計元素。**版面投影片** 繼承自母片，而 **普通投影片** 繼承自版面投影片。

本文示範如何使用 Aspose.Slides for C++ 來建立、修改與管理母片。

## **新增母片**

此範例示範如何透過複製預設母片來建立新的母片，並透過版面繼承在所有投影片上加入公司名稱橫幅。

```cpp
static void AddMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 複製預設母片。
    auto defaultMasterSlide = presentation->get_Master(0);
    auto newMasterSlide = presentation->get_Masters()->AddClone(defaultMasterSlide);

    // 在母片頂部加入公司名稱橫幅。
    auto textBox = newMasterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 0, 0, 720, 25);
    textBox->get_TextFrame()->set_Text(u"Company Name");
    auto paragraph = textBox->get_TextFrame()->get_Paragraph(0);
    auto textFormat = paragraph->get_ParagraphFormat()->get_DefaultPortionFormat();
    textFormat->get_FillFormat()->set_FillType(FillType::Solid);
    textFormat->get_FillFormat()->get_SolidFillColor()->set_Color(Color::get_Black());
    textBox->get_FillFormat()->set_FillType(FillType::NoFill);

    // 將新母片指派給版面投影片。
    auto layoutSlide = presentation->get_LayoutSlide(0);
    layoutSlide->set_MasterSlide(newMasterSlide);

    // 將版面投影片指派給簡報中的第一張投影片。
    presentation->get_Slide(0)->set_LayoutSlide(layoutSlide);

    presentation->Dispose();
}
```

> 💡 **注意 1:** 母片提供在所有投影片上套用一致品牌或共用設計元素的方式。對母片所做的任何變更皆會自動反映於相依的版面投影片與普通投影片。  
> 💡 **注意 2:** 在母片上加入的任何圖形或格式化都會被版面投影片繼承，進而被使用該版面的所有普通投影片繼承。  
> 下圖說明了在母片上加入的文字方塊如何自動呈現在最終投影片上。

![Master Inheritance Example](master-slide-banner.png)

## **存取母片**

您可以使用簡報的母片集合來存取母片。以下說明如何擷取並操作它們：

```cpp
static void AccessMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    auto firstMasterSlide = presentation->get_Master(0);

    // 更改背景類型。
    firstMasterSlide->get_Background()->set_Type(BackgroundType::OwnBackground);

    presentation->Dispose();
}
```

## **移除母片**

母片可以依索引或依參照方式移除。

```cpp
static void RemoveMasterSlide()
{
    auto presentation = MakeObject<Presentation>(u"sample.pptx");

    // 依索引移除母片。
    presentation->get_Masters()->RemoveAt(0);

    // 依參照移除母片。
    auto firstMasterSlide = presentation->get_Master(0);
    presentation->get_Masters()->Remove(firstMasterSlide);

    presentation->Dispose();
}
```

## **移除未使用的母片**

某些簡報可能包含未使用的母片。移除這些母片可協助減少檔案大小。

```cpp
static void RemoveUnusedMasterSlide()
{
    auto presentation = MakeObject<Presentation>();

    // 移除所有未使用的母片（即使是標記為 Preserve 的）。
    presentation->get_Masters()->RemoveUnused(true);

    presentation->Dispose();
}
```