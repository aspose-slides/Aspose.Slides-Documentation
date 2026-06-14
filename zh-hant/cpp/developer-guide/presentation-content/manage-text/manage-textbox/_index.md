---
title: 使用 C++ 管理簡報中的文字方塊
linktitle: 管理文字方塊
type: docs
weight: 20
url: /zh-hant/cpp/manage-textbox/
keywords:
- 文字方塊
- 文字框架
- 新增文字
- 更新文字
- 建立文字方塊
- 檢查文字方塊
- 新增文字欄
- 新增超連結
- PowerPoint
- 簡報
- C++
- Aspose.Slides
description: "Aspose.Slides for C++ 讓您能輕鬆在 PowerPoint 與 OpenDocument 檔案中建立、編輯與複製文字方塊，提升簡報自動化效能。"
---
## **簡介**

投影片上的文字通常位於文字方塊或圖形中。因此，要在投影片上加入文字，必須先新增文字方塊，然後在文字方塊中放入文字。Aspose.Slides for C++ 提供了 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 介面，允許您新增包含文字的圖形。

{{% alert title="Info" color="info" %}}
Aspose.Slides 也提供了 [IShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_shape) 介面，允許您向投影片新增圖形。但是，透過 `IShape` 介面新增的所有圖形並不一定能容納文字。但透過 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 介面新增的圖形可能包含文字。 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
因此，當處理想要加入文字的圖形時，您可能需要檢查並確認它是透過 `IAutoShape` 介面轉型的。只有這樣才能使用 `IAutoShape` 下的屬性 [TextFrame](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.text_frame)。請參閱本頁面的 [Update Text](https://docs.aspose.com/slides/zh-hant/cpp/manage-textbox/#update-text) 章節。 
{{% /alert %}}

## **在投影片上建立文字方塊**

要在投影片上建立文字方塊，請遵循以下步驟：

1. 建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.presentation) 類別的實例。 
2. 取得新建立的簡報中第一張投影片的參考。 
3. 在投影片上指定位置新增一個 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_auto_shape) 物件，將 [ShapeType](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_geometry_shape#ad941a828a2d9dd58ae1417b5c00c9a5c) 設為 `Rectangle`，並取得新新增的 `IAutoShape` 物件的參考。 
4. 為 `IAutoShape` 物件新增 `TextFrame` 屬性以容納文字。在下例中，我們加入的文字為：*Aspose TextBox* 
5. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

以下 C++ 程式碼—上述步驟的實作範例—示範如何在投影片中加入文字：

```cpp
// 實例化 Presentation
// 取得簡報中的第一張投影片
// 新增 AutoShape，類型設定為 Rectangle
// 為 Rectangle 新增 TextFrame
// 取得文字框架
// 為文字框架建立 Paragraph 物件
// 為段落建立 Portion 物件
// 設定文字
// 將簡報儲存到磁碟
auto pres = System::MakeObject<Presentation>();

auto sld = pres->get_Slides()->idx_get(0);

auto ashp = sld->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 75.0f, 150.0f, 50.0f);

ashp->AddTextFrame(u" ");

auto txtFrame = ashp->get_TextFrame();

auto para = txtFrame->get_Paragraphs()->idx_get(0);

auto portion = para->get_Portions()->idx_get(0);

portion->set_Text(u"Aspose TextBox");

pres->Save(u"TextBox_out.pptx", SaveFormat::Pptx);
```

## **檢查文字方塊圖形**

Aspose.Slides 從 [IAutoShape](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/) 介面提供 [get_IsTextBox](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iautoshape/get_istextbox/) 方法，讓您檢查圖形並辨識文字方塊。

![Text box and shape](istextbox.png)

以下 C++ 程式碼示範如何檢查圖形是否是文字方塊： 

```c++
auto presentation = MakeObject<Presentation>(u"sample.pptx");
for (auto&& slide : presentation->get_Slides())
{
    for (auto&& shape : slide->get_Shapes())
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

請注意，如果僅使用 [IShapeCollection](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ishapecollection/) 介面的 `AddAutoShape` 方法新增自動圖形，該自動圖形的 `get_IsTextBox` 方法將返回 `false`。但在使用 `AddTextFrame` 方法或 `set_Text` 方法為自動圖形加入文字後，`get_IsTextBox` 方法會返回 `true`。

```cpp
auto presentation = MakeObject<Presentation>();
auto slide = presentation->get_Slide(0);

auto shape1 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 10, 100, 40);
// shape1->get_IsTextBox() 傳回 false
shape1->AddTextFrame(u"shape 1");
// shape1->get_IsTextBox() 傳回 true

auto shape2 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 110, 100, 40);
// shape2->get_IsTextBox() 傳回 false
shape2->get_TextFrame()->set_Text(u"shape 2");
// shape2->get_IsTextBox() 傳回 true

auto shape3 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 210, 100, 40);
// shape3->get_IsTextBox() 傳回 false
shape3->AddTextFrame(u"");
// shape3->get_IsTextBox() 傳回 false

auto shape4 = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 10, 310, 100, 40);
// shape4->get_IsTextBox() 傳回 false
shape4->get_TextFrame()->set_Text(u"");
// shape4->get_IsTextBox() 傳回 false
```

## **在文字方塊中添加欄**

Aspose.Slides 提供 [set_ColumnCount](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 與 [set_ColumnSpacing](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a5254ce6acdc2cd90f4db1c861a94716a) 方法（分別來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 介面與 [TextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 類別），允許您在文字方塊中加入欄。您可以指定文字方塊的欄數，並以點為單位設定欄與欄之間的間距。 

以下 C++ 程式碼示範上述操作： 

```cpp
auto presentation = System::MakeObject<Presentation>();
// 取得簡報中的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 新增 AutoShape，類型設定為 Rectangle
auto aShape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 100.0f, 100.0f, 300.0f, 300.0f);

// 為 Rectangle 新增 TextFrame
aShape->AddTextFrame(String(u"All these columns are limited to be within a single text container -- ") 
    + u"you can add or delete text and the new or remaining text automatically adjusts " 
    + u"itself to flow within the container. You cannot have text flow from one container " 
    + u"to other though -- we told you PowerPoint's column options for text are limited!");

// 取得 TextFrame 的文字格式
auto format = aShape->get_TextFrame()->get_TextFrameFormat();

// 指定 TextFrame 中的欄數
format->set_ColumnCount(3);

// 指定欄與欄之間的間距
format->set_ColumnSpacing(10);

// 儲存簡報
presentation->Save(u"ColumnCount.pptx", SaveFormat::Pptx);
```

## **在文字框架中添加欄**

Aspose.Slides for C++ 提供 [set_ColumnCount](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format#a969f998a2573e1540250855ce67df620) 方法（來自 [ITextFrameFormat](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_text_frame_format) 介面），允許您在文字框架中加入欄。透過此方法，您可以指定文字框架的欄數。 

以下 C++ 程式碼示範如何在文字框架中加入欄：

```cpp
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

Aspose.Slides 允許您變更或更新文字方塊中的文字，或更新簡報中所有的文字。 

以下 C++ 程式碼示範將簡報中所有文字更新或變更的操作：

```cpp
auto pres = System::MakeObject<Presentation>(u"text.pptx");
for (const auto& slide : pres->get_Slides())
{
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<IAutoShape>(shape))
        {
            auto autoShape = System::AsCast<IAutoShape>(shape);
            for (const auto& paragraph : autoShape->get_TextFrame()->get_Paragraphs())
            {
                for (const auto& portion : paragraph->get_Portions())
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

## **新增帶有超連結的文字方塊** 

您可以在文字方塊中插入連結。當使用者點擊文字方塊時，會開啟該連結。 

要新增包含連結的文字方塊，請遵循以下步驟：

1. 建立 `Presentation` 類別的實例。 
2. 取得新建立的簡報中第一張投影片的參考。 
3. 在投影片上指定位置新增一個 `AutoShape` 物件，將 `ShapeType` 設為 `Rectangle`，並取得新新增的 AutoShape 物件的參考。 
4. 為 `AutoShape` 物件新增 `TextFrame`，其預設文字為 *Aspose TextBox*。 
5. 建立 `IHyperlinkManager` 類別的實例。 
6. 將 `IHyperlinkManager` 物件指派給 `TextFrame` 中您想要的文字區段所對應的 [set_HyperlinkClick](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.shape#a617f857c862b71ac2093ed7866677a5c) 方法。 
7. 最後，透過 `Presentation` 物件寫入 PPTX 檔案。 

以下 C++ 程式碼—上述步驟的實作範例—示範如何在投影片中新增帶有超連結的文字方塊：

```cpp
// 實例化表示 PPTX 的 Presentation 類別
auto presentation = System::MakeObject<Presentation>();

// 取得簡報中的第一張投影片
auto slide = presentation->get_Slides()->idx_get(0);

// 新增 AutoShape 物件，類型設定為 Rectangle
auto shape = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150.0f, 150.0f, 150.0f, 50.0f);

// 將圖形轉型為 AutoShape
auto autoShape = System::ExplicitCast<IAutoShape>(shape);

// 存取與 AutoShape 相關聯的 ITextFrame 屬性
autoShape->AddTextFrame(u"");

auto textFrame = autoShape->get_TextFrame();

// 為框架新增文字
textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->set_Text(u"Aspose.Slides");

// 設定文字區段的超連結
auto linkManager = textFrame->get_Paragraphs()->idx_get(0)->get_Portions()->idx_get(0)->get_PortionFormat()->get_HyperlinkManager();
linkManager->SetExternalHyperlinkClick(u"http://www.aspose.com");

// 儲存 PPTX 簡報
presentation->Save(u"hLinkPPTX_out.pptx", SaveFormat::Pptx);
```

## **FAQ**

**在使用母片時，文字方塊與文字佔位符有何差異？**

[佔位符](/slides/zh-hant/cpp/manage-placeholder/) 會從 [母片](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/masterslide/) 繼承樣式/位置，且可在 [版面配置](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/layoutslide/) 上覆寫；而一般的文字方塊則是特定投影片上的獨立物件，切換版面配置時不會變動。

**如何在整份簡報中批次取代文字，同時不影響圖表、表格與 SmartArt 內的文字？**

將遍歷限制於具有文字框的自動圖形，並排除嵌入式物件（[圖表](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.charts/chart/)、[表格](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/table/)、[SmartArt](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides.smartart/smartart/)），可分別遍歷它們的集合或直接跳過這些物件類型。