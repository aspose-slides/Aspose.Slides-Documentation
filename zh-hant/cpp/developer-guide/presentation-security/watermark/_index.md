---
title: 在 C++ 中為簡報新增浮水印
linktitle: 浮水印
type: docs
weight: 40
url: /zh-hant/cpp/watermark/
keywords:
- 浮水印
- 文字浮水印
- 圖片浮水印
- 新增浮水印
- 更改浮水印
- 移除浮水印
- 刪除浮水印
- 新增浮水印至 PPT
- 新增浮水印至 PPTX
- 新增浮水印至 ODP
- 從 PPT 移除浮水印
- 從 PPTX 移除浮水印
- 從 ODP 移除浮水印
- 從 PPT 刪除浮水印
- 從 PPTX 刪除浮水印
- 從 ODP 刪除浮水印
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 C++ 中管理 PowerPoint 與 OpenDocument 簡報的文字與圖片浮水印，以標示草稿、機密資訊、版權等。"
---
## **簡介**

**浮水印** 在簡報中是用於單一投影片或整個簡報的文字或圖片印記。通常，浮水印用來表示簡報是草稿（例如「Draft」浮水印）、含有機密資訊（例如「Confidential」浮水印）、屬於哪家公司（例如「Company Name」浮水印）、辨識簡報作者等。浮水印有助於防止版權侵害，表明簡報不應被複製。浮水印同時支援 PowerPoint 與 OpenOffice 簡報格式。於 Aspose.Slides 中，您可以在 PowerPoint PPT、PPTX 與 OpenOffice ODP 檔案格式中加入浮水印。

在 [**Aspose.Slides**](https://products.aspose.com/slides/zh-hant/cpp/)，有多種方式可以在 PowerPoint 或 OpenOffice 文件中建立浮水印，並修改其設計與行為。共同點是加入文字浮水印時，應使用 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 介面；加入圖片浮水印時，使用 [PictureFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/pictureframe/) 類別或以圖片填滿浮水印形狀。`PictureFrame` 實作 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 介面，讓您可以使用形狀物件的全部彈性設定。由於 `ITextFrame` 不是形狀且設定受限，會將其包裝成 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/) 物件。

浮水印可透過兩種方式套用：套用於單一投影片或套用於所有簡報投影片。使用 Slide Master 可將浮水印套用至所有投影片——浮水印被加入 Slide Master，於該處完成完整設計，然後套用至全部投影片，且不會影響個別投影片對浮水印的修改權限。

浮水印通常被視為不允許其他使用者編輯。為防止浮水印（或其父形狀）被編輯，Aspose.Slides 提供形狀鎖定功能。特定形狀可以在普通投影片或 Slide Master 上鎖定。當浮水印形狀在 Slide Master 上被鎖定時，所有簡報投影片的該形狀也會被鎖定。

您可以為浮水印設定名稱，未來若要刪除時，可依名稱在投影片的形狀集合中找到它。

浮水印的設計方式多樣；然而，浮水印通常具有一些共通特徵，例如置中對齊、旋轉、置於最前等。我們將在以下範例中說明如何使用這些特性。

## **文字浮水印**

### **將文字浮水印新增至投影片**

要在 PPT、PPTX 或 ODP 中加入文字浮水印，首先在投影片上新增一個形狀，然後在該形狀上新增文字框。文字框由 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 介面表示。此類型未繼承自 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)，因此其定位屬性較受限制。因此，會將 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 物件包裝在 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 物件中。要將浮水印文字加入形狀，請使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/addtextframe/) 方法，如下所示。

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto watermarkShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- [如何使用 TextFrame 類別](/slides/zh-hant/cpp/text-formatting/)
{{% /alert %}}

### **將文字浮水印新增至簡報**

若要將文字浮水印加入整個簡報（即一次性套用於所有投影片），請將其加入 [MasterSlide](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/masterslide/)。其餘流程與在單一投影片上加入浮水印相同——建立一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 物件，然後使用 [AddTextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/addtextframe/) 方法將浮水印加入。

```cpp
auto watermarkText = u"CONFIDENTIAL";

auto presentation = MakeObject<Presentation>();
auto masterSlide = presentation->get_Master(0);

auto watermarkShape = masterSlide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100, 100, 400, 40);
auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);

presentation->Dispose();
```

{{% alert color="primary" title="另請參閱" %}} 
- [如何使用投影片母片](/slides/zh-hant/cpp/slide-master/)
{{% /alert %}}

### **設定浮水印形狀透明度**

預設情況下，矩形形狀具有填充與線條顏色。以下程式碼行可將形狀設為透明。

```cpp
watermarkShape->get_FillFormat()->set_FillType(FillType::NoFill);
watermarkShape->get_LineFormat()->get_FillFormat()->set_FillType(FillType::NoFill);
```

### **設定文字浮水印的字型**

您可以如下面範例所示變更文字浮水印的字型。

```cpp
auto textFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat();
textFormat->set_LatinFont(MakeObject<FontData>(u"Arial"));
textFormat->set_FontHeight(50);
```

### **設定浮水印文字顏色**

若要設定浮水印文字的顏色，請使用以下程式碼：

```cpp
auto alpha = 150, red = 200, green = 200, blue = 200;

auto fillFormat = watermarkFrame->get_Paragraph(0)->get_ParagraphFormat()->get_DefaultPortionFormat()->get_FillFormat();
fillFormat->set_FillType(FillType::Solid);
fillFormat->get_SolidFillColor()->set_Color(Color::FromArgb(alpha, red, green, blue));
```

### **將文字浮水印置中**

您可以將浮水印置中於投影片，方法如下：

```cpp
auto slideSize = presentation->get_SlideSize()->get_Size();

auto watermarkWidth = 400;
auto watermarkHeight = 40;
auto watermarkX = (slideSize.get_Width() - watermarkWidth) / 2;
auto watermarkY = (slideSize.get_Height() - watermarkHeight) / 2;

auto watermarkShape = slide->get_Shapes()->AddAutoShape(
    ShapeType::Rectangle, watermarkX, watermarkY, watermarkWidth, watermarkHeight);

auto watermarkFrame = watermarkShape->AddTextFrame(watermarkText);
```

下圖顯示最終結果。

![文字浮水印](text_watermark.png)

## **圖片浮水印**

### **將圖片浮水印新增至簡報**

要在簡報投影片中加入圖片浮水印，您可以執行以下步驟：

```cpp
auto imageStream = File::ReadAllBytes(u"watermark.png");
auto image = presentation->get_Images()->AddImage(imageStream);

watermarkShape->get_FillFormat()->set_FillType(FillType::Picture);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->get_Picture()->set_Image(image);
watermarkShape->get_FillFormat()->get_PictureFillFormat()->set_PictureFillMode(PictureFillMode::Stretch);
```

## **鎖定浮水印以防編輯**

若需防止浮水印被編輯，請於形狀上使用 [IAutoShape::get_AutoShapeLock](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/get_autoshapelock/) 方法。透過此屬性，您可以保護形狀不被選取、調整大小、重新定位、與其他元素群組、鎖定其文字編輯等多種操作：

```cpp
// 鎖定浮水印形狀以防修改
watermarkShape->get_AutoShapeLock()->set_SelectLocked(true);
watermarkShape->get_AutoShapeLock()->SizeLocked(true);
watermarkShape->get_AutoShapeLock()->TextLocked(true);
watermarkShape->get_AutoShapeLock()->PositionLocked(true);
watermarkShape->get_AutoShapeLock()->GroupingLocked(true);
```

## **將浮水印置於最前**

在 Aspose.Slides 中，可透過 [IShapeCollection::Reorder](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/reorder/) 方法設定形狀的 Z 順序。您需要從簡報的投影片清單呼叫此方法，並傳入形狀參考與其順序編號。如此即可將形狀移至前方或移至投影片的最背後。此功能在需要將浮水印放在簡報前景時特別有用：

```cpp
auto shapeCount = slide->get_Shapes()->get_Count();
slide->get_Shapes()->Reorder(shapeCount - 1, watermarkShape);
```

## **設定浮水印旋轉角度**

以下程式碼示範如何調整浮水印的旋轉，使其呈對角線方式佈局於投影片上：

```cpp
auto diagonalAngle = Math::Atan((slideSize.get_Height() / slideSize.get_Width())) * 180 / Math::PI;

watermarkShape->set_Rotation((float)diagonalAngle);
```

## **為浮水印設定名稱**

Aspose.Slides 允許為形狀設定名稱。使用形狀名稱，未來您可透過名稱存取該形狀以進行修改或刪除。若要設定浮水印形狀的名稱，請呼叫 [IAutoShape::set_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/set_name/) 方法：

```cpp
watermarkShape->set_Name(u"watermark");
```

## **移除浮水印**

要移除浮水印形狀，先使用 [IAutoShape::get_Name](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/get_name/) 方法在投影片形狀集合中找到它，然後將該形狀傳入 [IShapeCollection::Remove](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/remove/) 方法：

```cpp
auto slideShapes = slide->get_Shapes()->ToArray();
for(auto shape : slideShapes)
{
    if (String::Compare(shape->get_Name(), u"watermark", StringComparison::Ordinal) == 0)
    {
        slide->get_Shapes()->Remove(watermarkShape);
    }
}
```

## **即時範例**

您或許想要試試 **Aspose.Slides free** 的線上工具 [Add Watermark](https://products.aspose.app/slides/zh-hant/watermark) 與 [Remove Watermark](https://products.aspose.app/slides/zh-hant/watermark/remove-watermark)。

![線上新增與移除浮水印的工具](online_tools.png)

## **常見問題**

**什麼是浮水印，為什麼要使用它？**

浮水印是加在投影片上的文字或圖片覆蓋層，可用於保護智慧財產、提升品牌辨識度，或防止未授權使用簡報。

**我可以將浮水印加入簡報的所有投影片嗎？**

可以，Aspose.Slides 允許您以程式方式將浮水印加入簡報的每一張投影片，您可以遍歷所有投影片並個別套用浮水印設定。

**如何調整浮水印的透明度？**

您可以透過修改形狀的填充設定（[FillFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/shape/get_fillformat/)）來調整浮水印的透明度，讓浮水印呈現柔和且不會干擾投影片內容。

**浮水印支援哪些影像格式？**

Aspose.Slides 支援多種影像格式，包括 PNG、JPEG、GIF、BMP、SVG 等。

**我可以自訂文字浮水印的字型與樣式嗎？**

可以，您可依簡報設計需求選擇任何字型、大小與樣式，以維持品牌一致性。

**如何變更浮水印的位置或方向？**

您可程式化調整形狀的座標、大小與旋轉屬性，以變更浮水印的位置或方向。