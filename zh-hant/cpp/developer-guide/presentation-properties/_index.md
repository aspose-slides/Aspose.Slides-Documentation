---
title: 在 C++ 中管理簡報屬性
linktitle: 簡報屬性
type: docs
weight: 70
url: /zh-hant/cpp/presentation-properties/
keywords:
- PowerPoint 屬性
- 簡報屬性
- 文件屬性
- 內建屬性
- 自訂屬性
- 進階屬性
- 管理屬性
- 修改屬性
- 文件中繼資料
- 編輯中繼資料
- 校對語言
- 預設語言
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中精通簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種文件屬性類型：**Built-in** 和 **Custom**。這兩種類型的屬性均可透過 Aspose.Slides API 輕鬆存取與管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.i_document_properties) 介面來操作簡報文件屬性。此介面的實例是由 [Presentation::get_DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/get_documentproperties/) 方法返回。以下範例說明如何讀取、修改與管理這些屬性。

{{% alert color="primary" %}} 
請注意，您無法設定 **Application** 和 **Producer** 欄位的值，因為會顯示 Aspose Ltd. 與 Aspose.Slides for C++ x.x.x 的資訊於這些欄位。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供在簡報檔案中加入屬性的功能。這些文件屬性允許將有用的資訊與文件（簡報檔案）一起儲存。文件屬性分為以下兩種：

- 系統定義（Built-in）屬性
- 使用者自訂（Custom）屬性

**Built-in** 屬性包含關於文件的一般資訊，例如文件標題、作者名稱、文件統計資料等。**Custom** 屬性則是使用者以 **Name/Value** 配對自行定義的屬性，名稱與值皆由使用者決定。使用 Aspose.Slides for C++，開發人員可以存取並修改內建屬性與自訂屬性的值。Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。只要點選 Office 圖示，接著選取 **Prepare | Properties | Advanced Properties** 功能表項目，即可開啟對話方塊管理 PowerPoint 檔案的文件屬性。在 **Properties Dialog** 中，您會看到多個分頁，如 **General、Summary、Statistics、Contents** 與 **Custom**。這些分頁允許設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **存取內建屬性**

由 **IDocumentProperties** 物件公開的屬性包括：**Creator(Author)**、**Description**、**KeyWords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最後列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們一樣簡單。您只要將字串值指派給任意屬性，即可修改該屬性的值。以下範例示範了如何修改簡報檔案的內建文件屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **新增自訂簡報屬性**

Aspose.Slides for C++ 也允許開發人員為簡報文件屬性新增自訂值。以下範例說明如何為簡報設定自訂屬性。

``` cpp
// 實例化 Presentation 類別
auto presentation = System::MakeObject<Presentation>();

// 取得文件屬性
auto documentProperties = presentation->get_DocumentProperties();

// 新增自訂屬性
documentProperties->idx_set(u"New Custom", ObjectExt::Box<int32_t>(12));
documentProperties->idx_set(u"My Name", ObjectExt::Box<String>(u"Mudassir"));
documentProperties->idx_set(u"Custom", ObjectExt::Box<int32_t>(124));

// 取得特定索引的屬性名稱
String getPropertyName = documentProperties->GetCustomPropertyName(2);

// 移除選取的屬性
documentProperties->RemoveCustomProperty(getPropertyName);

// 儲存簡報
presentation->Save(u"CustomDocumentProperties_out.pptx", SaveFormat::Pptx);
```

## **存取與修改自訂屬性**

Aspose.Slides for C++ 亦可讓開發人員存取自訂屬性的值。以下範例示範如何存取與修改簡報的所有自訂屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **設定校對語言**

Aspose.Slides 提供 [LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 屬性（由 [PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portionformat/) 類別公開），讓您為 PowerPoint 文件設定校對語言。校對語言是檢查 PowerPoint 拼寫與文法的目標語言。

以下 C++ 程式碼示範如何為 PowerPoint 設定校對語言：

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(pptxFileName);
System::SharedPtr<AutoShape> autoShape = System::ExplicitCast<AutoShape>(pres->get_Slide(0)->get_Shape(0));

System::SharedPtr<IParagraph> paragraph = autoShape->get_TextFrame()->get_Paragraph(0);
System::SharedPtr<IPortionCollection> portions = paragraph->get_Portions();
portions->Clear();

System::SharedPtr<Portion> newPortion = System::MakeObject<Portion>();

System::SharedPtr<IFontData> font = System::MakeObject<FontData>(u"SimSun");
System::SharedPtr<IPortionFormat> portionFormat = newPortion->get_PortionFormat();
portionFormat->set_ComplexScriptFont(font);
portionFormat->set_EastAsianFont(font);
portionFormat->set_LatinFont(font);

portionFormat->set_LanguageId(u"zh-CN");
// 設定校對語言的 Id

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **設定預設語言**

以下 C++ 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```c++
System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 新增帶文字的矩形形狀
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 檢查第一個文字區段的語言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **即時範例**

嘗試線上應用程式 **[Aspose.Slides Metadata](https://products.aspose.app/slides/zh-hant/metadata)**，了解如何透過 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## ***常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以更改其值，或在允許的情況下將其設定為空白。

**如果新增的自訂屬性已存在會發生什麼情況？**

若新增的自訂屬性已存在，其現有值將被新值覆蓋。您不必先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以，您可以使用 [PresentationFactory](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentationfactory/) 類別的 `GetPresentationInfo` 方法取得簡報資訊，然後利用 [IPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/) 介面的 `ReadDocumentProperties` 方法有效讀取屬性，從而節省記憶體並提升效能。