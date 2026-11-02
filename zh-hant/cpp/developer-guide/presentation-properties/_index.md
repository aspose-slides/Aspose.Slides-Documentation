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
description: "在 Aspose.Slides for C++ 中掌握簡報屬性，並在 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for C++ 支援 **內建** 與 **自訂** 文件屬性。使用這些屬性可讀取與更新簡報的中繼資料，例如作者、標題以及使用者自訂的值。

Aspose.Slides 讓您透過 [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 回傳。以下範例示範如何讀取、修改與管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式與製作者的中繼資料；這些欄位用於識別建立輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標題、作者與文件統計等標準中繼資料。
- **自訂屬性** 儲存使用者定義的名稱/值配對。

Aspose.Slides for C++ 皆提供對這兩類屬性的存取。在 PowerPoint 中，選取 **檔案 → 資訊 → 屬性 → 進階屬性** 以檢視文件中繼資料。對話方塊會將資訊分成 **摘要**、**統計**、**內容** 與 **自訂** 等索引標籤。使用 **自訂** 索引標籤可管理使用者定義的屬性。

## **從已加密的簡報讀取公開屬性**

開啟密碼通常同時保護簡報內容與文件屬性。當簡報透過將 `false` 傳遞給 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 來加密文件屬性時，這些屬性仍保留為公開。此時應用程式可將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 以在未提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 控制 Aspose.Slides 載入的內容；它不會解密任何資料。若屬性已納入加密，未提供密碼而載入將失敗。若簡報未加密，則會忽略此選項，完整載入簡報。

此範例需要一個文件屬性已設為公開的已加密簡報。它透過 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) 驗證載入模式，然後透過 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 讀取內建屬性：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>

using namespace Aspose::Slides;

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_OnlyLoadDocumentProperties(true);

auto presentation = System::MakeObject<Presentation>(u"public-properties-encrypted.pptx", loadOptions);

if (presentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    auto documentProperties = presentation->get_DocumentProperties();

    System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
    System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

在此模式下，投影片內容不會被載入。投影片、母片、版面配置、圖形、媒體與其他簡報物件皆無法使用。應用程式在執行需要完整簡報物件模型的操作前，務必先檢查 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會洩漏作者名稱、標題、主題、關鍵字、公司資訊、註解與自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在不提供密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新已加密簡報的屬性**

對於已加密的 PPTX 檔案，透過將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 載入的簡報僅供讀取公開中繼資料。Aspose.Slides 無法從此僅含屬性的物件儲存變更，因為公共屬性必須與加密簡報內的相應資料保持一致。因此，必須使用正確的開啟密碼並完整載入簡報才能更新。

此範例需要一個文件屬性為公開且已知開啟密碼的已加密 PPTX 簡報。它使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) 完整開啟簡報，更新公開的內建屬性，然後儲存結果。接著使用 [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) 驗證加密仍然保留，並在未提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <DOM/LoadOptions.h>
#include <DOM/IProtectionManager.h>
#include <DOM/PresentationFactory.h>
#include <DOM/IPresentationInfo.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

const System::String inputPath = u"public-properties-encrypted.pptx";
const System::String outputPath = u"updated-public-properties-encrypted.pptx";

auto loadOptions = System::MakeObject<LoadOptions>();
loadOptions->set_Password(u"open_password");

auto presentation = System::MakeObject<Presentation>(inputPath, loadOptions);

auto documentProperties = presentation->get_DocumentProperties();
documentProperties->set_Title(u"Updated Product Roadmap");
documentProperties->set_Keywords(u"roadmap, planning, indexed");

presentation->Save(outputPath, SaveFormat::Pptx);

auto presentationInfo = PresentationFactory::get_Instance()->GetPresentationInfo(outputPath);
System::Console::WriteLine(u"The presentation is encrypted: {0}", presentationInfo->get_IsEncrypted());

auto metadataLoadOptions = System::MakeObject<LoadOptions>();
metadataLoadOptions->set_OnlyLoadDocumentProperties(true);

auto metadataPresentation = System::MakeObject<Presentation>(outputPath, metadataLoadOptions);

if (metadataPresentation->get_ProtectionManager()->get_IsOnlyDocumentPropertiesLoaded())
{
    System::Console::WriteLine(u"Title: {0}", metadataPresentation->get_DocumentProperties()->get_Title());
    System::Console::WriteLine(u"Keywords: {0}", metadataPresentation->get_DocumentProperties()->get_Keywords());
}
else
{
    System::Console::WriteLine(u"The presentation was not loaded in document-properties-only mode.");
}
```

若應用程式未被授權解密或載入簡報內容，則必須將已加密 PPTX 檔案的公共屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) 介面透過型別化的 getter 暴露內建中繼資料，包括 [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)、[get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) 與 [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/)。此範例開啟現有簡報並將其已儲存的中繼資料輸出至主控台。值取決於輸入的簡報；某些欄位可能為空。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>

using namespace Aspose::Slides;

auto presentation = System::MakeObject<Presentation>(u"AccessBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

System::Console::WriteLine(u"Category: {0}", documentProperties->get_Category());
System::Console::WriteLine(u"Content status: {0}", documentProperties->get_ContentStatus());
System::Console::WriteLine(u"Creation date: {0}", documentProperties->get_CreatedTime());
System::Console::WriteLine(u"Author: {0}", documentProperties->get_Author());
System::Console::WriteLine(u"Comments: {0}", documentProperties->get_Comments());
System::Console::WriteLine(u"Keywords: {0}", documentProperties->get_Keywords());
System::Console::WriteLine(u"Last modified by: {0}", documentProperties->get_LastSavedBy());
System::Console::WriteLine(u"Manager: {0}", documentProperties->get_Manager());
System::Console::WriteLine(u"Modified date: {0}", documentProperties->get_LastSavedTime());
System::Console::WriteLine(u"Presentation format: {0}", documentProperties->get_PresentationFormat());
System::Console::WriteLine(u"Last print date: {0}", documentProperties->get_LastPrinted());
System::Console::WriteLine(u"Is shared between producers: {0}", documentProperties->get_SharedDoc());
System::Console::WriteLine(u"Subject: {0}", documentProperties->get_Subject());
System::Console::WriteLine(u"Title: {0}", documentProperties->get_Title());
```

## **修改內建屬性**

若要更新內建中繼資料，請使用由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 回傳的物件上的 setter。此範例開啟現有簡報，呼叫 [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)、[set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/)、[set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/)、[set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/)、[set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/)，然後使用 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 儲存已更新的簡報。儲存後的 PPTX 會包含新的中繼資料。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"ModifyBuiltInProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->set_Author(u"Aspose.Slides for C++");
documentProperties->set_Title(u"Manage PowerPoint Presentation Properties");
documentProperties->set_Subject(u"Modify Built-in Properties");
documentProperties->set_Comments(u"Aspose description");
documentProperties->set_Manager(u"Aspose manager");

presentation->Save(u"DocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **管理 Hyperlink Base**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) 讀取文件層級的相對超連結基礎位址。當將簡報及其連結檔案搬移到其他位置時，這個基礎位址非常有用。它與個別超連結的 [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) 分開：變更基礎位址不會重新寫入已儲存的連結位址，也不會改變絕對目的地。

此範例需要一個同時包含相對連結（例如 `target.html`）與絕對連結（例如 `https://example.org/absolute.html`）的簡報。它讀取現有的基礎位址，使用 [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) 指定新位址，然後儲存並重新開啟簡報以檢查值。接著以 `u""` 清除基礎位址，並在另一個已儲存的檔案中驗證空值。請將範例基礎位址取代為您連結檔案的實際位置。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"hyperlinks.pptx");

System::Console::WriteLine(u"Original base: {0}", presentation->get_DocumentProperties()->get_HyperlinkBase());

const System::String newBase = u"https://example.com/new/";
presentation->get_DocumentProperties()->set_HyperlinkBase(newBase);
presentation->Save(u"hyperlinks-updated.pptx", SaveFormat::Pptx);

auto updatedPresentation = System::MakeObject<Presentation>(u"hyperlinks-updated.pptx");
System::Console::WriteLine(u"Base preserved: {0}", (updatedPresentation->get_DocumentProperties()->get_HyperlinkBase() == newBase));

updatedPresentation->get_DocumentProperties()->set_HyperlinkBase(u"");
updatedPresentation->Save(u"hyperlinks-cleared.pptx", SaveFormat::Pptx);

auto clearedPresentation = System::MakeObject<Presentation>(u"hyperlinks-cleared.pptx");
System::Console::WriteLine(u"Base cleared: {0}", (clearedPresentation->get_DocumentProperties()->get_HyperlinkBase() == u""));
```

兩條驗證訊息應顯示 `True`。清除基礎位址不會影響個別超連結的地址。

相對連結 `target.pptx` 在基礎指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎改為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟相同檔案。請在 PowerPoint 中測試相對連結在搬移簡報或變更基礎前後的行為。

## **新增自訂簡報屬性**

自訂屬性用於儲存沒有對應內建欄位的中繼資料。[IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) 允許您以屬性名稱指定值。此範例建立一個簡報，加入兩個文字值與一個整數版本值，最後使用 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 儲存簡報。對已存在的名稱設定值會取代該屬性的現有值。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>();

auto documentProperties = presentation->get_DocumentProperties();

documentProperties->idx_set(u"Reviewed by", System::ObjectExt::Box<System::String>(u"John Smith"));
documentProperties->idx_set(u"Confidentiality level", System::ObjectExt::Box<System::String>(u"Internal"));
documentProperties->idx_set(u"Document version", System::ObjectExt::Box(2));

presentation->Save(u"CustomDocumentProperties_output.pptx", SaveFormat::Pptx);
```

## **存取與修改自訂屬性**

此範例開啟包含自訂屬性的簡報，使用 [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) 迭代所有屬性。 [GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引並回傳名稱，該名稱可供 [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) 與 [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) 使用。範例列印每個原始名稱與值，將所有值取代為編號字串（不論原始類型），最後儲存變更。若沒有自訂屬性，迴圈將不會產生任何變更。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/Presentation.h>
#include <system/console.h>
#include <Export/SaveFormat.h>
#include <system/object_ext.h>

using namespace Aspose::Slides;
using namespace Aspose::Slides::Export;

auto presentation = System::MakeObject<Presentation>(u"AccessAndModifyProperties.pptx");

auto documentProperties = presentation->get_DocumentProperties();

for (auto i = 0; i < documentProperties->get_CountOfCustomProperties(); i++)
{
    auto propertyName = documentProperties->GetCustomPropertyName(i);
    auto propertyValue = documentProperties->idx_get(propertyName);

    System::Console::WriteLine(u"Custom property name: {0}", propertyName);
    System::Console::WriteLine(u"Custom property value: {0}", propertyValue);

    documentProperties->idx_set(propertyName, System::ObjectExt::Box(System::String::Format(u"New Value {0}", i + 1)));
}

presentation->Save(u"CustomProperties_output.pptx", SaveFormat::Pptx);
```

## **線上示範**

試試線上應用程式 [**View & Edit PowerPoint Metadata**](https://products.aspose.app/slides/metadata) 了解如何使用 Aspose.Slides API 操作文件屬性：

[![View & Edit PowerPoint Metadata](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的組成部分，無法全部移除。但您可以更改其值，或在屬性允許的情況下將其設定為空。

**如果新增的自訂屬性已存在會發生什麼事？**

若新增的自訂屬性已存在，其原有值會被新值覆寫。您無需事先移除或檢查屬性，Aspose.Slides 會自動更新屬性值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/)，再呼叫 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/)，即可在不建立 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 實例的情況下讀取已儲存的文件中繼資料。參閱 [Build a Lightweight Presentation Inventory](/slides/zh-hant/cpp/examine-presentation/) 取得完整報告範例與格式限制說明。

**我可以在不提供開啟密碼的情況下讀取已加密簡報的公開屬性嗎？**

可以。簡報必須是透過將 `false` 傳遞給 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 來加密文件屬性，且必須以將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 的方式載入。

**我可以在僅載入文件屬性模式下更新已加密的 PPTX 檔案嗎？**

不能。公共屬性與加密屬性資料必須保持一致，因而更新已加密的 PPTX 檔案必須以正確的開啟密碼完整載入簡報。