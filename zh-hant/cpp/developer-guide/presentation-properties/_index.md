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
description: "在 Aspose.Slides for C++ 中管理簡報屬性，並在您的 PowerPoint 與 OpenDocument 檔案中簡化搜尋、品牌化與工作流程。"
---
## **簡介**

Aspose.Slides for C++ 支援 **內建** 和 **自訂** 文件屬性。使用這些屬性來讀取和更新簡報的中繼資料，例如作者、標題和使用者定義的值。

Aspose.Slides 允許您透過 [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) 介面操作簡報文件屬性。此介面的實例由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 回傳。以下範例說明如何讀取、修改和管理這些屬性。

{{% alert color="info" title="Note" %}}
Aspose.Slides 在儲存簡報時會管理應用程式和製作者的中繼資料；這些欄位用於識別建立輸出的軟體。
{{% /alert %}}

## **管理簡報屬性**

文件屬性會在簡報內容旁儲存描述性資訊。它們分為兩類：

- **內建屬性** 包含標準中繼資料，例如標題、作者和文件統計資訊。
- **自訂屬性** 儲存使用者定義的名稱/值組。

Aspose.Slides for C++ 提供存取兩種屬性。在 PowerPoint 中，選取 **File → Info → Properties → Advanced Properties** 以檢查文件中繼資料。此對話方塊將資訊分為 **Summary**、**Statistics**、**Contents**、**Custom** 等分頁。使用 **Custom** 分頁來管理使用者定義的屬性。

## **從加密簡報讀取公開屬性**

開啟密碼通常會保護簡報內容與文件屬性。當簡報透過將 `false` 傳遞給 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 來加密時，其文件屬性仍保持公開。此時應用程式可以將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)，在不提供開啟密碼的情況下讀取公開的中繼資料。

[LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 控制 Aspose.Slides 載入的內容；它不會解密任何資料。如果屬性已包含在加密中，未提供密碼即載入會失敗。若簡報未加密，則此選項會被忽略，完整的簡報會被載入。

此範例需要一個文件屬性已設定為公開的加密簡報。它透過 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/) 驗證載入模式，然後透過 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 讀取內建屬性：

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

在此模式下，幻燈片內容不會被載入。幻燈片、母片、版面配置、圖形、媒體及其他簡報物件皆不可用。應用程式在執行需要完整簡報物件模型的操作前，應始終檢查 [IProtectionManager::get_IsOnlyDocumentPropertiesLoaded](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/get_isonlydocumentpropertiesloaded/)。

{{% alert color="warning" title="Security" %}}
公開的中繼資料可能會揭露作者姓名、標題、主題、關鍵字、公司資訊、註解以及自訂值。請將敏感屬性與簡報一起加密。僅在索引、分類、搜尋或文件管理系統有特定需求必須在不使用密碼的情況下存取時，才將其保留為公開。
{{% /alert %}}

## **更新加密簡報的屬性**

對於已加密的 PPTX 檔案，將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/) 取得的簡報僅供讀取公開的中繼資料。Aspose.Slides 無法從僅含文件屬性的物件保存變更，因為公開屬性必須與加密簡報內相對應的資料保持一致。因此，更新必須使用正確的開啟密碼並完整載入簡報。

此範例需要一個文件屬性為公開且已知開啟密碼的加密 PPTX 簡報。它使用 [LoadOptions::set_Password](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_password/) 完整載入簡報，更新公開的內建屬性，然後保存結果。接著使用 [IPresentationInfo::get_IsEncrypted](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/get_isencrypted/) 驗證加密狀態，並在不提供密碼的情況下重新開啟公開的中繼資料以驗證新值：

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

如果應用程式無法解密或載入簡報內容，則必須將加密 PPTX 檔案的公開屬性視為唯讀。

## **存取內建屬性**

[IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/) 介面透過型別化的 getter 透露內建中繼資料，包括 [get_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_author/)、[get_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_title/) 和 [get_CreatedTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_createdtime/)。此範例開啟現有簡報，並將其儲存的中繼資料輸出至主控台。值取決於輸入的簡報，某些欄位可能為空。

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

### **報告修訂編號與編輯時間**

使用 [GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/) 與 [ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 來在不載入幻燈片的情況下讀取每個檔案的 [IDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/)。此範例會對 `presentations` 資料夾中的每個 PPTX 檔案列印一行。標準的 `c` 格式會在錄製的編輯時間達到 24 小時時加入天數。

```cpp
#include <DOM/IDocumentProperties.h>
#include <DOM/IPresentationInfo.h>
#include <DOM/PresentationFactory.h>
#include <system/console.h>
#include <system/io/directory.h>
#include <system/io/path.h>
#include <system/timespan.h>

using namespace Aspose::Slides;
using namespace System::IO;

System::Console::WriteLine(u"File | RevisionNumber | TotalEditingTime");
auto paths = Directory::GetFiles(u"presentations", u"*.pptx");
for (const auto& path : paths)
{
    auto info = PresentationFactory::get_Instance()->GetPresentationInfo(path);
    auto properties = info->ReadDocumentProperties();
    auto fileName = Path::GetFileName(path);
    auto editingTime = properties->get_TotalEditingTime().ToString(u"c");
    System::Console::WriteLine(u"{0} | {1} | {2}", fileName, properties->get_RevisionNumber(), editingTime);
}
```

對於錄製的編輯時間為 1 天、2 小時、5 分鐘的簡報，報告會如下所示：

```text
File | RevisionNumber | TotalEditingTime
long.pptx | 17 | 1.02:05:00
```

[get_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_revisionnumber/) 讀取可由 [set_RevisionNumber](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_revisionnumber/) 變更的中繼資料值。僅憑此值無法判斷簡報儲存了多少次或重建其版本歷史。

[get_TotalEditingTime](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_totaleditingtime/) 回傳檔案中記錄的編輯時長。`00:00:00` 代表儲存的時長為零，簡報仍可能已被編輯過。

## **修改內建屬性**

要更新內建中繼資料，請使用由 [IPresentation::get_DocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentation/get_documentproperties/) 回傳之物件的 setter。此範例開啟現有簡報，呼叫 [set_Author](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_author/)、[set_Title](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_title/)、[set_Subject](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_subject/)、[set_Comments](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_comments/) 與 [set_Manager](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_manager/)，然後使用 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 儲存更新後的簡報。儲存的 PPTX 會包含新的中繼資料。

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

## **管理超連結基礎 URL**

[IDocumentProperties::get_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_hyperlinkbase/) 讀取文件層級的相對超連結基礎 URL。當您將簡報及其相關檔案移動到其他位置時，此資訊非常有用。它與個別超連結的 [IHyperlink::get_ExternalUrl](https://reference.aspose.com/slides/cpp/aspose.slides/ihyperlink/get_externalurl/) 分離：變更基礎 URL 不會重寫已儲存的連結位址或改變絕對目標。

此範例需要一個同時包含相對連結（如 `target.html`）與絕對連結（如 `https://example.org/absolute.html`）的簡報。它讀取現有的基礎 URL，使用 [IDocumentProperties::set_HyperlinkBase](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/set_hyperlinkbase/) 指定新的基礎位址，並儲存與重新開啟簡報以檢查結果。接著以 `u""` 清除基礎，並在另一個儲存檔案中驗證空值。請將範例基礎位址替換為您連結檔案所在的位置。

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

兩個驗證訊息應顯示 `True`。清除基礎不會影響個別超連結的位址。

相對連結 `target.pptx` 在基礎指向 `old` 資料夾時會開啟 `old/target.pptx`。將基礎變更為 `new` 資料夾、儲存並重新開啟簡報後，同一連結會開啟 `new/target.pptx`。絕對連結則仍會開啟原始檔案。請在移動簡報或變更基礎前後於 PowerPoint 中測試您的相對連結。

## **新增自訂簡報屬性**

自訂屬性儲存沒有對應內建欄位的中繼資料。[IDocumentProperties::idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) 允許您依屬性名稱指派值。此範例建立一個簡報，新增兩個文字值與一個整數版本值，並使用 [Presentation::Save](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/save/) 儲存。對已有名稱指派新值會取代該屬性的原有值。

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

此範例開啟包含自訂屬性的簡報，並使用 [get_CountOfCustomProperties](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/get_countofcustomproperties/) 迭代它們。[GetCustomPropertyName](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/getcustompropertyname/) 接受零基索引並回傳由 [IDocumentProperties::idx_get](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_get/) 與 [idx_set](https://reference.aspose.com/slides/cpp/aspose.slides/idocumentproperties/idx_set/) 使用的名稱。範例列印每個原始名稱與值，將所有值替換為編號字串（不論原始型別），並儲存變更。若沒有自訂屬性，迴圈不會產生任何變更。

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

## **即時範例**

嘗試線上應用程式 [**檢視與編輯 PowerPoint 中繼資料**](https://products.aspose.app/slides/metadata) 以了解如何使用 Aspose.Slides API 操作文件屬性：

[![檢視與編輯 PowerPoint 中繼資料](slides-metadata.png)](https://products.aspose.app/slides/metadata)

## **常見問題**

**如何從簡報中移除內建屬性？**

內建屬性是簡報的一部份，無法完全移除。您可以變更其值，或在特定屬性允許的情況下將其設為空白。

**如果新增的自訂屬性已經存在會發生什麼事？**

若新增的自訂屬性已存在，原有的值會被新值覆寫。您不必先移除或檢查屬性，Aspose.Slides 會自動更新屬性的值。

**我可以在不完整載入簡報的情況下存取簡報屬性嗎？**

可以。使用 [PresentationFactory::GetPresentationInfo](https://reference.aspose.com/slides/cpp/aspose.slides/presentationfactory/getpresentationinfo/)，然後呼叫 [IPresentationInfo::ReadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/ipresentationinfo/readdocumentproperties/) 以在不建立 [Presentation](https://reference.aspose.com/slides/cpp/aspose.slides/presentation/) 實例的情況下讀取儲存的文件中繼資料。請參考 [Build a Lightweight Presentation Inventory](/slides/zh-hant/cpp/examine-presentation/) 取得完整報告範例與格式限制說明。

**我能在不提供開啟密碼的情況下讀取加密簡報的公開屬性嗎？**

可以。簡報必須是在將 `false` 傳遞給 [IProtectionManager::set_EncryptDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/iprotectionmanager/set_encryptdocumentproperties/) 後加密，且載入時必須將 `true` 傳遞給 [LoadOptions::set_OnlyLoadDocumentProperties](https://reference.aspose.com/slides/cpp/aspose.slides/loadoptions/set_onlyloaddocumentproperties/)。

**我可以在僅載入文件屬性的模式下更新加密的 PPTX 檔案嗎？**

不能。公開與加密的屬性資料必須保持一致，更新加密的 PPTX 檔案需要使用正確的開啟密碼完整載入簡報。