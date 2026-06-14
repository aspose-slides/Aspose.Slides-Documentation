---
title: 使用 C++ 管理 PowerPoint 簡報中的 SmartArt
linktitle: 管理 SmartArt
type: docs
weight: 10
url: /zh-hant/cpp/manage-smartart/
keywords:
- SmartArt
- SmartArt 文字
- 版面配置類型
- 隱藏屬性
- 組織圖
- 圖片組織圖
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習使用 Aspose.Slides for C++ 建構與編輯 PowerPoint SmartArt，透過清晰的程式碼範例加速投影片設計與自動化。"
---
## **概覽**

SmartArt 是由節點、節點形狀和版面配置組成的 PowerPoint 圖表。使用 Aspose.Slides for C++，您可以建立 SmartArt、讀取其節點中的文字、更改其版面配置、檢查隱藏節點、設定組織圖版面配置，並建立圖片組織圖。

## **取得 SmartArt 物件的文字**

SmartArt 節點可以包含一個或多個形狀。若要讀取可見文字，請遍歷 [ISmartArt::get_AllNodes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/get_allnodes/)，然後讀取由 [ISmartArtShape::get_TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartshape/get_textframe/) 回傳的 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/)。

```cpp
auto presentation = System::MakeObject<Presentation>(u"sample.pptx");
auto slide = presentation->get_Slide(0);
auto shape = slide->get_Shape(0);

if (System::ObjectExt::Is<ISmartArt>(shape))
{
    auto smartArt = System::ExplicitCast<ISmartArt>(shape);

    for (int nodeIndex = 0; nodeIndex < smartArt->get_AllNodes()->get_Count(); nodeIndex++)
    {
        auto node = smartArt->get_AllNodes()->idx_get(nodeIndex);

        for (int shapeIndex = 0; shapeIndex < node->get_Shapes()->get_Count(); shapeIndex++)
        {
            auto nodeShape = node->get_Shape(shapeIndex);

            if (nodeShape->get_TextFrame() != nullptr)
            {
                System::Console::WriteLine(nodeShape->get_TextFrame()->get_Text());
            }
        }
    }
}

presentation->Dispose();
```

## **變更 SmartArt 物件的版面配置類型**

SmartArt 版面配置決定節點的排列方式與連接方式。以下範例使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartlayouttype/) 的 `BasicBlockList` 值建立 SmartArt 物件，將其更改為 `BasicProcess` 值，並儲存簡報。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::BasicBlockList);

smartArt->set_Layout(SmartArtLayoutType::BasicProcess);

presentation->Save(u"ChangeSmartArtLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **檢查 SmartArt 節點是否為隱藏**

[ISmartArtNode::get_IsHidden](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartnode/get_ishidden/) 表示該節點在 SmartArt 資料模型中是否為隱藏。即使所選版面配置未將其顯示為可見圖表元素，隱藏節點仍可能存在於結構中。

以下範例向使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartlayouttype/) `RadialCycle` 值的 SmartArt 物件新增一個節點，並檢查該節點的隱藏狀態。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::RadialCycle);

auto node = smartArt->get_AllNodes()->AddNode();
bool isHidden = node->get_IsHidden();

if (isHidden)
{
    System::Console::WriteLine(u"The node is hidden in the SmartArt data model.");
}

presentation->Save(u"CheckSmartArtHiddenProperty_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **取得或設定組織圖版面配置**

對於使用組織圖版面配置的 SmartArt 圖表，[ISmartArtNode::get_OrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartnode/get_organizationchartlayout/) 與 [ISmartArtNode::set_OrganizationChartLayout](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartnode/set_organizationchartlayout/) 定義子節點在父節點下的排列方式。例如，您可以根據所選的 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/organizationchartlayouttype/)，將子節點掛在左側、右側或兩側。

以下範例建立組織圖，並將第一個節點的版面配置設定為 [OrganizationChartLayoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/organizationchartlayouttype/) 的 `LeftHanging` 值。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    10.0f, 10.0f, 400.0f, 300.0f, SmartArtLayoutType::OrganizationChart);

auto rootNode = smartArt->get_Node(0);
rootNode->set_OrganizationChartLayout(OrganizationChartLayoutType::LeftHanging);

presentation->Save(u"OrganizationChartLayout_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **建立圖片組織圖**

圖片組織圖是針對包含圖片佔位符的階層圖而設計的 SmartArt 版面配置。將 SmartArt 物件新增至投影片時，使用 [SmartArtLayoutType](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartartlayouttype/) 的 `PictureOrganizationChart` 值。

```cpp
auto presentation = System::MakeObject<Presentation>();

auto smartArt = presentation->get_Slide(0)->get_Shapes()->AddSmartArt(
    0.0f, 0.0f, 400.0f, 400.0f, SmartArtLayoutType::PictureOrganizationChart);

presentation->Save(u"PictureOrganizationChart_out.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **常見問題**

**SmartArt 是否支援 RTL（從右至左）語言的鏡像或反轉？**

是。當所選 SmartArt 版面配置支援反轉時，[SmartArt::set_IsReversed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/set_isreversed/) 方法可將圖表方向從左到右切換為右到左，或反向切換。

**如何在保留格式的情況下，將 SmartArt 複製到相同投影片或其他簡報？**

您可以使用 [ShapeCollection::AddClone](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapecollection/addclone/) 來 [clone the SmartArt shape](/slides/zh-hant/cpp/shape-manipulations/)，或 [clone the whole slide](/slides/zh-hant/cpp/clone-slides/) 以複製包含 SmartArt 的整張投影片。兩種方法皆會保留大小、位置與格式。

**如何將 SmartArt 呈現為點陣圖以供預覽或 Web 匯出？**

將投影片或整個簡報[Render the slide](/slides/zh-hant/cpp/convert-powerpoint-to-png/) 為 PNG 或 JPEG。SmartArt 會作為投影片的一部分被渲染。

**如果投影片上有多個 SmartArt，如何找到特定的 SmartArt 物件？**

在 SmartArt 形狀上設定獨特的 [Shape::set_AlternativeText](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/set_alternativetext/) 或 [Shape::set_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/set_name/) 值，於 [BaseSlide::get_Shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseslide/get_shapes/) 中搜尋該值，然後確認匹配的形狀是 [ISmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/ismartart/)。