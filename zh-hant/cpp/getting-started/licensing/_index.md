---
title: 授權
type: docs
weight: 120
url: /zh-hant/cpp/licensing/
keywords:
- 授權
- 暫時授權
- 設定授權
- 使用授權
- 驗證授權
- 授權檔案
- 評估版
- PowerPoint
- OpenDocument
- 簡報
- C++
- Aspose.Slides
description: "在 Aspose.Slides for C++ 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保不中斷使用完整功能。"
---
## **概觀**

Aspose.Slides 可以在評估模式或使用有效授權下使用。評估版提供與授權版相同的功能，但在開啟或儲存簡報時會加上評估浮水印，且文字擷取僅限於一張投影片。

本文說明 Aspose.Slides 的授權運作方式，以及如何在使用程式庫之前套用授權。授權可以透過 `License` 類別從檔案、串流或嵌入式資源載入。本文亦示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" %}} 

您可以從[其 NuGet 下載頁面](https://www.nuget.org/packages/Aspose.Slides.CPP/)下載 **Aspose.Slides for C++** 的評估版。評估版提供與授權產品相同的功能。事實上，評估套件與購買版完全相同——只要在程式碼中加入少數幾行以套用授權，即可變為授權版。

當您對 **Aspose.Slides** 的評估滿意後，即可[購買授權](https://purchase.aspose.com/buy)。我們建議您檢視可用的訂閱類型。如有任何問題，歡迎聯絡 Aspose 銷售團隊。

每份 Aspose 授權皆包含一年免費升級訂閱，期間內的新版本與錯誤修正皆可免費取得。無論使用授權版或評估版，都能獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版限制**

* 雖然 Aspose.Slides 評估版（未套用授權時）提供完整的產品功能，但在開啟與儲存作業時會在文件頂部插入評估浮水印。
* 使用評估版時，文字擷取僅限於一張投影片。

{{% alert color="info" %}} 

若要在不受限制的情況下測試 Aspose.Slides，您可以請求**30 天暫時授權**。更多資訊請參閱[如何取得暫時授權](https://purchase.aspose.com/temporary-license)頁面。

{{% /alert %}}

## **Aspose.Slides 的授權**

* 評估版在您購買授權並透過幾行程式碼套用後，即成為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔案已數位簽章，禁止修改。即使是意外的換行也會使檔案失效。
* Aspose.Slides for C++ 通常會在以下位置尋找授權檔案：
  * 程式碼中明確指定的路徑
  * 含有元件 DLL 的資料夾（包含於 Aspose.Slides）
  * 呼叫元件 DLL 的組件所在的資料夾
* 為避免評估版的限制，必須在使用 Aspose.Slides 前設定授權。授權僅需於每個應用程式或處理序設定一次。

## **套用授權**

授權可以從**檔案**、**串流**或**嵌入式資源**載入。

{{% alert color="info" %}}

Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/cpp/class/aspose.slides.license/) 類別以執行授權相關操作。

{{% /alert %}} 

{{% alert color="warning" %}}

新授權只能在版本 21.4 或更新的 Aspose.Slides 中啟用。較早的版本使用不同的授權機制，無法辨識這些授權。

{{% /alert %}}

### **檔案**

設定授權最簡單的方式是將授權檔案放在元件 DLL 所在的同一資料夾（已包含於 Aspose.Slides），僅指定檔名即可，無需路徑。

以下 C++ 程式碼示範如何設定授權檔案：

```c++
#include <Util/License.h>
#include <system/smart_ptr.h>
#include <system/string.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    return 0;
}
```

{{% alert color="warning" %}} 

若將授權檔案放在其他目錄，呼叫 [License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法時，指定的完整路徑最後的檔名必須完全與授權檔案名稱相符。

例如，若將授權檔案重新命名為 *Aspose.Slides.lic.xml*，必須將結尾為 *Aspose.Slides.lic.xml* 的完整路徑傳遞給 [License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法。

{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 C++ 程式碼示範如何從串流套用授權：

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>
using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

auto license = MakeObject<License>();

auto stream = File::OpenRead(u"Aspose.Slides.lic");

license->SetLicense(stream);
```

## **驗證授權**

若要檢查授權是否正確設定，可進行驗證。以下 C++ 程式碼示範如何驗證授權：

```c++
#include <Util/License.h>
#include <system/console.h>
using namespace Aspose::Slides;
using namespace System;

auto license = MakeObject<License>();

license->SetLicense(u"Aspose.Slides.lic");

if (license->IsLicensed())
{
    Console::WriteLine(u"License is good!");
    Console::ReadKey();
}
```

## **執行緒安全性**

{{% alert title="Note" color="warning" %}} 

[License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法**不具執行緒安全性**。若需同時從多個執行緒呼叫此方法，建議使用同步基元（例如 lock）以避免潛在問題。

{{% /alert %}}

## **常見問題**

### 可以在完全離線的環境（無網路）套用授權嗎？

可以。授權驗證全部在本機使用授權檔案完成，無需網路連線。

### 一年訂閱到期後會怎樣？程式庫會停止運作嗎？

不會。授權為永久授權：您仍可繼續使用訂閱到期日前發布的版本，只是若要使用更新的版本則需要重新續約。