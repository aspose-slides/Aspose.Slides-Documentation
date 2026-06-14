---
title: 在 C++ 中管理簡報圖形
linktitle: 圖形操作
type: docs
weight: 40
url: /zh-hant/cpp/shape-manipulations/
keywords:
- PowerPoint 圖形
- 簡報圖形
- 投影片上的圖形
- 尋找圖形
- 複製圖形
- 移除圖形
- 隱藏圖形
- 變更圖形順序
- 取得 Interop 圖形 ID
- 圖形替代文字
- 圖形版面配置格式
- 圖形為 SVG
- 圖形轉 SVG
- 對齊圖形
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "學習在 Aspose.Slides for C++ 中建立、編輯與最佳化圖形，並製作高效能的 PowerPoint 簡報。"
---
## **概覽**

本文說明如何使用 Aspose.Slides 在簡報中處理圖形。它展示了如何在投影片上尋找圖形、複製圖形、移除圖形、隱藏圖形、更改圖形順序、取得其 Interop 圖形 ID，以及設定替代文字以供辨識和後續處理。  

此外，本文還涵蓋了如何取得圖形的版面配置格式、將圖形渲染為 SVG、在投影片上對齊圖形，以及使用翻轉屬性進行水平和垂直鏡像。除此之外，文章還包含了關於圖形合併、堆疊順序和圖形鎖定的簡短 FAQ。

## **在投影片上尋找圖形**
本主題將說明一種簡單技術，讓開發人員在不使用內部 Id 的情況下更容易在投影片上找到特定圖形。必須了解，PowerPoint 簡報檔案除了內部唯一 Id 之外，沒有其他方式辨識投影片上的圖形。開發人員使用內部唯一 Id 來尋找圖形往往相當困難。所有加入投影片的圖形都具有某些替代文字 (Alt Text)。我們建議開發人員使用替代文字來尋找特定圖形。您可以使用 Microsoft PowerPoint 為未來可能變更的物件定義替代文字。  

在設定好任何所需圖形的替代文字後，您即可使用 Aspose.Slides for C++ 開啟該簡報，並遍歷投影片中所有的圖形。在每次迭代時，檢查圖形的替代文字，符合的圖形即為您需要的圖形。為了更好地示範此技術，我們建立了一個方法 [FindShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) ，可在投影片中搜尋特定圖形並直接回傳該圖形。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **複製圖形**
使用 Aspose.Slides for C++ 複製圖形至投影片的步驟如下：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 使用索引取得投影片的參考。
3. 存取來源投影片的圖形集合。
4. 向簡報新增一張投影片。
5. 將圖形從來源投影片的圖形集合複製到新投影片。
6. 將修改後的簡報儲存為 PPTX 檔案。

以下範例將群組圖形新增至投影片。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **移除圖形**
Aspose.Slides for C++ 允許開發人員移除任何圖形。若要從投影片中移除圖形，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 存取第一張投影片。
3. 尋找具有特定 AlternativeText 的圖形。
4. 移除該圖形。
5. 將檔案儲存至磁碟。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **隱藏圖形**
Aspose.Slides for C++ 允許開發人員隱藏任何圖形。若要在投影片中隱藏圖形，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 存取第一張投影片。
3. 尋找具有特定 AlternativeText 的圖形。
4. 隱藏該圖形。
5. 將檔案儲存至磁碟。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **變更圖形順序**
Aspose.Slides for C++ 允許開發人員重新排列圖形。重新排列可決定哪個圖形位於前端、哪個圖形位於後端。若要在投影片中重新排列圖形，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 存取第一張投影片。
3. 新增一個圖形。
4. 在圖形的文字框中加入一些文字。
5. 再新增一個具有相同座標的圖形。
6. 重新排列這些圖形。
7. 將檔案儲存至磁碟。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **取得 Interop 圖形 ID**
Aspose.Slides for C++ 允許開發人員取得投影片範圍內的唯一圖形識別碼，與 UniqueId 屬性（取得簡報範圍內的唯一識別碼）相對應。OfficeInteropShapeId 屬性已分別新增至 IShape 介面與 Shape 類別。OfficeInteropShapeId 屬性回傳的值對應於 Microsoft.Office.Interop.PowerPoint.Shape 物件的 Id。以下示範程式碼如下。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **設定 AlternativeText 屬性**
Aspose.Slides for C++ 允許開發人員設定任何圖形的 AlternateText。若要設定圖形的 AlternateText，請依照以下步驟操作：

1. 建立一個 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。
2. 存取第一張投影片。
3. 新增任意圖形至投影片。
4. 對新加入的圖形執行一些操作。
5. 遍歷圖形以尋找目標圖形。
6. 設定 AlternativeText。
7. 將檔案儲存至磁碟。  

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **存取圖形的版面配置格式**
Aspose.Slides for C++ 允許開發人員存取圖形的版面配置格式。本文示範如何取得圖形的 **FillFormat** 與 **LineFormat** 屬性。  

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **將圖形渲染為 SVG**
現在 Aspose.Slides for C++ 支援將圖形渲染為 SVG。WriteAsSvg 方法（及其重載）已新增至 Shape 類別與 IShape 介面。此方法可將圖形內容儲存為 SVG 檔案。以下程式碼片段示範如何將投影片的圖形匯出為 SVG 檔案。  

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **圖形對齊**
Aspose.Slides 可將圖形相對於投影片邊距或彼此之間對齊。為此，已新增一個重載的 [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) 方法。[ShapesAlignmentType](https://reference.aspose.com/slides/zh-hant/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) 列舉則定義了可能的對齊選項。  

**範例 1**  

以下原始碼將索引為 1、2 與 4 的圖形對齊至投影片的上邊緣。  

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**範例 2**  

以下範例示範如何將整個圖形集合相對於集合中最底層的圖形進行對齊。  

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **翻轉屬性**
在 Aspose.Slides 中，[ShapeFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeframe/) 類別透過其 `flipH` 與 `flipV` 屬性提供圖形水平與垂直鏡像的控制。兩個屬性皆為 [NullableBool](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/nullablebool/) 型別，可接受 `True`（表示翻轉）、`False`（不翻轉）或 `NotDefined`（使用預設行為）的值。這些值可透過圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_frame/) 取得。  

若要修改翻轉設定，會建立一個以圖形目前位置與尺寸、期望的 `flipH` 與 `flipV` 值以及旋轉角度為參數的新的 [ShapeFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shapeframe/) 實例。將此實例指定給圖形的 [Frame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_frame/)，再儲存簡報，即可套用鏡像變換並寫入輸出檔案。  

假設我們有一個 sample.pptx 檔案，其第一張投影片包含一個使用預設翻轉設定的單一圖形，如下圖所示。  

![The shape to be flipped](shape_to_be_flipped.png)

以下程式碼範例會取得圖形目前的翻轉屬性，並同時在水平與垂直方向上翻轉它。  

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// 取得圖形的水平翻轉屬性。
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// 取得圖形的垂直翻轉屬性。
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // 水平翻轉。
auto flipV = NullableBool::True; // 水平翻轉。
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

結果：  

![The flipped shape](flipped_shape.png)

## **常見問題**

**我可以像桌面編輯器一樣在投影片上合併圖形（聯集/交集/相減）嗎？**  
目前未提供內建的布林運算 API。您可以自行構建所需的輪廓來近似實現，例如計算結果幾何（使用 [GeometryPath](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/geometrypath/)），然後以該輪廓建立新圖形，必要時移除原始圖形。  

**我如何控制堆疊順序（z-order），使圖形始終位於「最上層」？**  
在投影片的 [shapes](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseslide/get_shapes/) 集合中調整插入或移動順序。為了取得可預測的結果，請在完成所有其他投影片修改後再確定最終的 z-order。  

**我可以「鎖定」圖形，防止使用者在 PowerPoint 中編輯它嗎？**  
可以。設定 [shape-level protection flags](/slides/zh-hant/cpp/applying-protection-to-presentation/)（例如鎖定選取、移動、調整大小、文字編輯）。如有需要，也可以在母片或版面上套用相同限制。請注意，這僅是 UI 級別的保護，並非安全機制；若需更嚴格的保護，請結合檔案層級的限制，如 [唯讀建議或密碼](/slides/zh-hant/cpp/password-protected-presentation/)。