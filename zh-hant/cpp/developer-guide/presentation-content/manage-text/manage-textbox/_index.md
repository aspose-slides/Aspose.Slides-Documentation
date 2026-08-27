---
title: 使用 C++ 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/cpp/manage-textbox/
keywords:
- 文字方塊
- 文字框
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄位
- 新增超連結
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 使您能輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化的效能。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上新增文字，必須先新增文字方塊，然後將文字放入該文字方塊。Aspose.Slides for C++ 提供了 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 介面，可讓您新增包含文字的圖形。

{{% alert title="資訊" color="info" %}}

Aspose.Slides 亦提供 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape) 介面，可讓您將圖形新增至投影片。然而，透過 `IShape` 介面新增的圖形並非全部都能容納文字。但透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 介面新增的圖形可能包含文字。 

{{% /alert %}}

{{% alert title="注意" color="warning" %}} 

因此，當處理想要新增文字的圖形時，您可能需要檢查並確認該圖形已透過 `IAutoShape` 介面轉型。只有這樣才可以使用 `IAutoShape` 之下的屬性 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame)，請參閱本頁面的 [更新文字](https://docs.aspose.com/slides/zh-hant/cpp/manage-textbox/#update-text) 章節。 

{{% /alert %}}

## **在投影片上建立文字方塊**

要在投影片上建立文字方塊，請依照以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。 
2. 取得新建立簡報中第一張投影片的參考。 
3. 在投影片的指定位置加入一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 物件，將 [ShapeType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) 設為 `Rectangle`，並取得新加入的 `IAutoShape` 物件的參考。 
4. 在 `IAutoShape` 物件上加入 `TextFrame` 屬性以容納文字。在下例中，我們加入的文字為：*Aspose TextBox*
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 實例化 Presentation
auto pres = System::MakeObject<Presentation>();

// 取得簡報中的第一張投影片
auto sld = pres->get_Slides()->idx_get(0);

// 新增類型設定為 Rectangle 的 AutoShape
auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

// 在矩形上新增 TextFrame
ashp->AddTextFrame(u" ");

// 存取文字框
auto txtFrame = ashp->get_TextFrame();

// 為文字框建立 Paragraph 物件
auto para = txtFrame->get_Paragraphs()->idx_get(0);

// 為段落建立 Portion 物件
auto portion = para->get_Portions()->idx_get(0);

// 設定文字
portion->set_Text(u"Aspose TextBox");

// 將簡報儲存至磁碟
pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **檢查文字方塊圖形**

Aspose.Slides 從 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 介面提供 [get_IsTextBox](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/get_istextbox/) 方法，使您能檢查圖形並辨識文字方塊。

![文字方塊與圖形](istextbox.png)

以下 C++ 程式碼示範如何檢查圖形是否已建立為文字方塊： 

```c++
#include <DOM/IAutoShape.h>
#include <DOM/Presentation.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <system/console.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : System::IterateOver(presentation->get_Slides()))
{
    for (auto&& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = ExplicitCast<IAutoShape>(shape);
            Console::WriteLine(autoShape->get_IsTextBox() ? u"shape is a text box" : u"shape is not a text box");
        }
    }
}

presentation->Dispose();
```

請注意，如果僅使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/) 介面的 `AddAutoShape` 方法新增自動圖形，該自動圖形的 `get_IsTextBox` 方法將回傳 `false`。但是，當您使用 `AddTextFrame` 方法或 `set_Text` 方法為自動圖形加入文字後，`get_IsTextBox` 方法會回傳 `true`。

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() 回傳 false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() 回傳 true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() 回傳 false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() 回傳 true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() 回傳 false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() 回傳 false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() 回傳 false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() 回傳 false
```

## **尋找擁有文字框的圖形**

在一般的文字處理程式碼中，您可能會取得一個 [ITextFrame](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/) 卻未事先知道它屬於哪個簡報物件。使用 [ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentshape/) 可返回其擁有者 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishape/)。

對於屬於 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 或其他含文字圖形的文字框，[ITextFrame::get_ParentShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentshape/) 會返回其擁有者，而 [ITextFrame::get_ParentCell](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/itextframe/get_parentcell/) 會返回 `nullptr`。這兩個方法僅提供唯讀的導覽，呼叫它們不會改變所有權。在存取圖形前，務必先檢查回傳值是否為 `nullptr`。

欲取得完整示例，說明如何辨識圖形與表格儲存格的擁有者（包括與 SmartArt 節點相關的圖形），請參考 [搜尋與取代文字](/slides/zh-hant/cpp/search-and-replace-text/)。

## **為文字方塊新增欄位**

Aspose.Slides 提供 [set_ColumnCount](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 與 [set_ColumnSpacing](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) 方法（來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 介面與 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 類別），可為文字方塊新增欄位。您可以指定文字方塊的欄位數量，並設定欄位之間的點數間距。 

以下 C++ 程式碼示範上述操作： 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/ITextFrameFormat.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto presentation = System::MakeObject<Presentation>();
// 取得簡報中的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 新增類型設定為 Rectangle 的 AutoShape
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// 在矩形上新增 TextFrame
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// 取得 TextFrame 的文字格式
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// 指定 TextFrame 的欄位數量
format->set_ColumnCount(3);

// 指定欄位之間的間距
format->set_ColumnSpacing(10);

// 儲存簡報
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **為文字框新增欄位**
Aspose.Slides for C++ 提供 [set_ColumnCount](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 方法（來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 介面），可在文字框中新增欄位。透過此方法，您可以指定文字框的欄位數量。 

以下 C++ 程式碼示範如何在文字框內新增欄位：

```cpp
#include <DOM/AutoShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <DOM/TextFrameFormat.h>
#include <Export/SaveFormat.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

String outPptxFileName = u"ColumnsTest.pptx";
    
auto pres = System::MakeObject<Presentation>();
auto shape = pres->get_Slides()->idx_get(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);
auto format = System::ExplicitCast<TextFrameFormat>(shape->get_TextFrame()->get_TextFrameFormat());

format->set_ColumnCount(2);
shape->get_TextFrame()->set_Text(String(u"All these columns are forced to stay within a single text container -- ") 
    + u"you can add or delete text - and the new or remaining text automatically adjusts " 
    + u"itself to stay within the container. You cannot have text spill over from one container " 
    + u"to other, though -- because PowerPoint's column options for text are limited!");
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format1 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format1->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(std::numeric_limits<double>::quiet_NaN() == format1->get_ColumnSpacing());
}

format->set_ColumnSpacing(20);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format2 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(2 == format2->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(20 == format2->get_ColumnSpacing());
}

format->set_ColumnCount(3);
format->set_ColumnSpacing(15);
pres->Save(outPptxFileName, SaveFormat::Pptx);

{
    auto test = System::MakeObject<Presentation>(outPptxFileName);
    auto format3 = System::ExplicitCast<AutoShape>(test->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0))->get_TextFrame()->get_TextFrameFormat();
    CODEPORTING_DEBUG_ASSERT1(3 == format3->get_ColumnCount());
    CODEPORTING_DEBUG_ASSERT1(15 == format3->get_ColumnSpacing());
}
```

## **更新文字**

Aspose.Slides 允許您變更或更新文字方塊中的文字，或簡報中所有文字。 

以下 C++ 程式碼示範如何更新或變更簡報中所有文字：

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/NullableBool.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <system/enumerator_adapter.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : System::IterateOver(pres->get_Slides()))
{
    for (const auto& shape : System::IterateOver(slide->get_Shapes()))
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : System::IterateOver(autoShape->get_TextFrame()->get_Paragraphs()))
            {
                for (const auto& portion : System::IterateOver(paragraph->get_Portions()))
                {
                    //變更文字
                    portion->set_Text(portion->get_Text().Replace(u"years", u"months"));
                    //變更格式
                    portion->get_PortionFormat()->set_FontBold(NullableBool::True);
                }
            }
        }
    }
}

//儲存已修改的簡報
pres->Save(u"text-changed.pptx", SaveFormat::Pptx);
```

## **為文字方塊新增超連結** 

您可以在文字方塊中插入連結。當使用者點擊該文字方塊時，將會開啟該連結。 

若要新增包含連結的文字方塊，請依照以下步驟執行：

1. 建立 `Presentation` 類別的實例。 
2. 取得新建立簡報中第一張投影片的參考。 
3. 在投影片的指定位置加入 `AutoShape` 物件，將 `ShapeType` 設為 `Rectangle`，並取得新加入的 AutoShape 物件的參考。 
4. 在 `AutoShape` 物件上加入 `TextFrame`，其預設文字為 *Aspose TextBox*。 
5. 建立 `IHyperlinkManager` 類別的實例。 
6. 將 `IHyperlinkManager` 物件指派給 `TextFrame` 中您想要的部分之 [set_HyperlinkClick](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) 方法。 
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

```cpp
#include <DOM/IAutoShape.h>
#include <DOM/IHyperlinkManager.h>
#include <DOM/IParagraph.h>
#include <DOM/IParagraphCollection.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <Export/SaveFormat.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

// 建立表示 PPTX 的 Presentation 類別實例
auto presentation = System::MakeObject<Presentation>();

// 取得簡報中的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 新增類型設定為 Rectangle 的 AutoShape 物件
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// 將圖形轉型為 AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// 存取與 AutoShape 相關聯的 ITextFrame 屬性
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// 為文字框加入文字
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 為文字區段設定超連結
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// 儲存 PPTX 簡報
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **常見問題**

**在使用母片時，文字方塊與文字佔位符有何差異？**

[佔位符](/slides/zh-hant/cpp/manage-placeholder/) 繼承自 [master](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/masterslide/) 的樣式/位置，且可在 [layouts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/layoutslide/) 上覆寫；相較之下，普通的文字方塊是特定投影片上的獨立物件，切換版面配置時不會改變。

**如何在簡報中大量取代文字，同時不影響圖表、表格與 SmartArt 中的文字？**

將遍歷限制在具有文字框的自動圖形，並排除嵌入式物件（[charts](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/)、[tables](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/)），可分別遍歷其集合或跳過這些物件類型。