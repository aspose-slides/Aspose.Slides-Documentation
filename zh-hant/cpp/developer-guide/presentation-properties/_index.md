---
title: 管理 C++ 簡報屬性
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
description: "在 Aspose.Slides for C++ 中掌握簡報屬性，並在 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides 支援兩種類型的文件屬性：**內建**和**自訂**。這兩種屬性類型都可以輕鬆地透過 Aspose.Slides API 進行存取和管理。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/idocumentproperties/) 介面來處理簡報文件屬性。此介面的實例是由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_documentproperties/) 取得。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
請注意，您無法對 **Application** 與 **Producer** 欄位設定值，因為會顯示 Aspose Ltd. 與 Aspose.Slides for C++ x.x.x 於這些欄位。
{{% /alert %}} 

## **管理簡報屬性**

Microsoft PowerPoint 提供了一項功能，可將某些屬性加入簡報檔案。這些文件屬性允許在文件（簡報檔案）中儲存一些有用資訊。文件屬性分為以下兩類：

- 系統定義（內建）屬性
- 使用者定義（自訂）屬性

**內建** 屬性包含有關文件的一般資訊，如文件標題、作者名稱、文件統計資料等。**自訂** 屬性則是使用者以 **Name/Value**（名稱/值）配對定義的屬性，名稱與值皆由使用者自行決定。使用 Aspose.Slides for C++，開發人員可以存取與修改內建屬性以及自訂屬性的值。Microsoft PowerPoint 2007 允許管理簡報檔案的文件屬性。只要點選 Office 圖示，然後在 Microsoft PowerPoint 2007 中選取 **Prepare | Properties | Advanced Properties** 功能表項目。選取 **Advanced Properties** 後，會出現對話方塊，讓您管理 PowerPoint 檔案的文件屬性。在 **Properties Dialog** 中，您會看到多個分頁，例如 **General、Summary、Statistics、Contents** 與 **Custom**。所有這些分頁皆可設定與 PowerPoint 檔案相關的不同資訊。**Custom** 分頁用於管理 PowerPoint 檔案的自訂屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會同時保護簡報內容與文件屬性。當簡報透過將 `false` 傳遞給 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 進行加密時，其文件屬性仍保留為公開。此時應用程式可將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)，在未提供開啟密碼的情況下讀取公開的中繼資料。

`set_OnlyLoadDocumentProperties` 控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已被加密，未提供密碼而載入將失敗。若簡報未加密，則會忽略此選項，完整簡報會被載入。

以下範例透過 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) 驗證載入模式，然後透過 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentation/get_documentproperties/) 讀取內建屬性：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;
using namespace System;

auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto properties = presentation->get_DocumentProperties();

    Console::WriteLine(u"Author: " + properties->get_Author());
    Console::WriteLine(u"Title: " + properties->get_Title());
    Console::WriteLine(u"Keywords: " + properties->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

presentation->Dispose();
```

在此模式下，不會載入投影片內容。投影片、母片、版面配置、形狀、媒體以及其他簡報物件皆無法使用。應用程式應在執行需要完整簡報物件模型的操作前，先檢查 `get_IsOnlyDocumentPropertiesLoaded`。

{{% alert color="warning" title="Warning" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一起加密，僅在索引、分類、搜尋或文件管理系統明確需要在無密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，透過 `set_OnlyLoadDocumentProperties(true)` 載入的簡報僅用於讀取公開的中繼資料。Aspose.Slides 無法從僅含中繼資料的物件儲存變更的屬性，因為公開屬性必須與加密簡報內的對應資料保持一致。因此，更新必須在提供正確的開啟密碼且完整載入簡報後才可進行。

以下範例使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/loadoptions/set_password/) 開啟簡報，更新公開的內建屬性，並儲存結果。接著使用 [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) 驗證加密仍被保留，最後在未提供密碼的情況下重新開啟公開中繼資料以驗證新值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/IProtectionManager.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/PresentationFactory.h>
#include <Export/SaveFormat.h>
#include <system/console.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

const String inputPath = u"public-properties-encrypted.pptx";
const String outputPath = u"updated-public-properties-encrypted.pptx";

{
    auto loadOptions = MakeObject<LoadOptions>();
    loadOptions->set_Password(u"open_password");

    auto presentation = MakeObject<Presentation>(inputPath, loadOptions);
    presentation->get_DocumentProperties()->set_Title(u"Updated Product Roadmap");
    presentation->get_DocumentProperties()->set_Keywords(u"roadmap, planning, indexed");
    presentation->Save(outputPath, SaveFormat::Pptx);
    presentation->Dispose();
}

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
Console::WriteLine(presentationInfo->get_IsEncrypted() ? u"The presentation is encrypted." : u"The presentation is not encrypted.");

auto metadataLoadOptions = MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    Console::WriteLine(u"Title: " + metadataPresentation->get_DocumentProperties()->get_Title());
    Console::WriteLine(u"Keywords: " + metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}

metadataPresentation->Dispose();
```

如果應用程式不允許解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

這些由 **IDocumentProperties** 物件公開的屬性包括：**Creator(Author)**、**Description**、**KeyWords**、**Created**（建立日期）、**Modified**（修改日期）、**Printed**（最近列印日期）、**LastModifiedBy**、**Keywords**、**SharedDoc**（是否在不同製作者之間共享？）、**PresentationFormat**、**Subject** 與 **Title**。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessBuiltinProperties-AccessBuiltinProperties.cpp" >}}

## **修改內建屬性**

修改簡報檔案的內建屬性與存取它們同樣簡單。您只需將字串值指派給任意想要的屬性，即可完成修改。以下範例示範如何修改簡報檔案的內建文件屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-UpdatePresentationProperties-UpdatePresentationProperties.cpp" >}}

## **新增自訂簡報屬性**

Aspose.Slides for C++ 也允許開發人員為簡報文件屬性新增自訂值。以下範例說明如何為簡報設定自訂屬性。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>
#include <system/string.h>
using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;
using namespace System;

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

Aspose.Slides for C++ 亦允許開發人員存取自訂屬性的值。以下範例說明如何存取與修改簡報的所有自訂屬性。

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-AccessModifyingProperties-AccessModifyingProperties.cpp" >}}

## **設定校對語言**

Aspose.Slides 提供了 [LanguageId](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/baseportionformat/set_languageid/) 屬性（由 [PortionFormat](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/portionformat/) 類別公開），讓您設定 PowerPoint 文件的校對語言。校對語言是用於檢查 PowerPoint 拼寫與文法的語言。

以下 C++ 程式碼示範如何為 PowerPoint 設定校對語言：

```c++
#include <DOM/AutoShape.h>
#include <DOM/Fonts/FontData.h>
#include <DOM/IFontData.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortionCollection.h>
#include <DOM/IPortionFormat.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/Portion.h>
#include <DOM/Presentation.h>
using namespace Aspose::Slides;

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"sample.pptx");
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
// set the Id of a proofing language

newPortion->set_Text(u"1。");
portions->Add(newPortion);
```

## **設定預設語言**

以下 C++ 程式碼示範如何為整個 PowerPoint 簡報設定預設語言：

```c++
#include <DOM/IAutoShape.h>
#include <DOM/IParagraph.h>
#include <DOM/IPortion.h>
#include <DOM/IPortionFormat.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ITextFrame.h>
#include <DOM/LoadOptions.h>
#include <DOM/Presentation.h>
#include <DOM/ShapeType.h>
#include <system/console.h>
using namespace Aspose::Slides;

System::SharedPtr<LoadOptions> loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_DefaultTextLanguage(u"en-US");

System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(loadOptions);

// 新增一個帶文字的矩形形狀
System::SharedPtr<IAutoShape> shp = pres->get_Slide(0)->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 50.0f, 50.0f, 150.0f, 50.0f);
System::SharedPtr<ITextFrame> textFrame = shp->get_TextFrame();
textFrame->set_Text(u"New Text");

// 檢查第一段落的語言
System::Console::WriteLine(textFrame->get_Paragraph(0)->get_Portion(0)->get_PortionFormat()->get_LanguageId());
```

## **即時範例**

試玩線上應用程式 [**Aspose.Slides Metadata**](https://products.aspose.app/slides/zh-hant/metadata) 以了解如何透過 Aspose.Slides API 操作文件屬性：

[![查看與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/zh-hant/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法完全移除。然而，您可以依需求變更其值，或在該屬性允許的情況下將其設為空值。

**如果我新增的自訂屬性已經存在，會發生什麼情況？**

若新增的自訂屬性已存在，其原有值會被新值覆寫。您不需要事先移除或檢查該屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [IPresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationfactory/getpresentationinfo/) 後接著 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 即可在不建立 [Presentation](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。請參閱 [建立輕量級簡報清單](/slides/zh-hant/cpp/examine-presentation/) 以取得完整的報表範例與格式限制說明。

**我可以在沒有開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。前提是簡報在加密時將 `set_EncryptDocumentProperties` 設為 `false`，且載入時將 `set_OnlyLoadDocumentProperties` 設為 `true`。

**我可以在僅文件屬性模式下更新加密的 PPTX 檔案嗎？**

不能。公開屬性與加密屬性必須保持一致，因此在僅文件屬性模式下無法更新加密的 PPTX 檔案，必須使用正確的開啟密碼完整載入簡報後才能進行更新。