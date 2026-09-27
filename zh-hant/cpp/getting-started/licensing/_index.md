---
title: 授權
type: docs
weight: 120
url: /zh-hant/cpp/licensing/
keywords:
- 授權
- 臨時授權
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
description: "在 Aspose.Slides for C++ 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保不間斷使用完整功能。"
---
## **概述**

Aspose.Slides 可在評估模式或使用有效授權的情況下使用。評估版本提供與授權版本相同的功能，但會在每個保存的簡報的每張投影片上加入評估水印，並截斷程式從簡報中讀取的文字。

本文說明 Aspose.Slides 的授權運作方式，以及如何在使用函式庫之前套用授權。授權可以透過 `License` 類別從檔案或串流載入。本文同時示範如何驗證授權是否正確套用。

## **評估 Aspose.Slides**

{{% alert color="info" title="Note" %}}

您可以從 [其 NuGet 下載頁面](https://www.nuget.org/packages/Aspose.Slides.Cpp/) 或以 ZIP 套件形式，從[下載頁面](https://releases.aspose.com/slides/zh-hant/cpp/)下載 **Aspose.Slides for C++** 的評估版。評估版提供與授權產品相同的功能。事實上，評估套件與購買版完全相同——只要在程式碼中加入幾行以套用授權，即可變成授權版本。

當您對 **Aspose.Slides** 的評估滿意後，可前往 [購買授權](https://purchase.aspose.com/pricing/slides/zh-hant/cpp/)。我們建議先檢視可用的訂閱類型。如有任何問題，請隨時聯繫 Aspose 銷售團隊。

每份 Aspose 授權皆包含一年的免費升級訂閱，期間內可取得新版本與錯誤修正。無論使用授權版或評估版，皆可獲得免費且無限制的技術支援。

{{% /alert %}} 

**評估版限制**

* 評估版（未指定授權）提供完整產品功能，但會在每個保存的簡報的每張投影片上加入評估水印文字框。
* 程式從簡報讀取的文字會被截斷為前幾個字符，並附加評估限制說明。程式寫入的文字則會完整保存。

{{% alert color="info" title="Note" %}}

若要在無限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。更多資訊請參閱 [如何取得臨時授權](https://purchase.aspose.com/temporary-license) 頁面。

{{% /alert %}}

## **Aspose.Slides 授權**

* 評估版在您購買授權並透過幾行程式碼套用後，即會變為授權版。
* 授權是一個純文字 XML 檔，其中包含產品名稱、授權開發人員數量、訂閱到期日等資訊。
* 授權檔已經數位簽章，不能被修改。即使是意外的換行也會使檔案失效。
* 當您僅傳遞檔名而未指定資料夾時，Aspose.Slides for C++ 只會在目前工作目錄中尋找授權檔。它不會搜尋執行檔或 Aspose.Slides 函式庫的資料夾；若授權檔存放於其他位置，請傳遞完整路徑。
* 為避免評估版的限制，必須在使用 Aspose.Slides 之前設定授權。授權只需在每個應用程式或行程中設定一次。

## **套用授權**

授權可以從 **檔案** 或 **串流** 載入。

{{% alert color="info" title="Note" %}}

Aspose.Slides 提供用於授權操作的 [License](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/) 類別。

{{% /alert %}} 

{{% alert color="warning" title="Warning" %}}

新授權只能在 21.4 或更新的版本中啟用 Aspose.Slides。較舊版本使用不同的授權系統，無法識別這些授權。

{{% /alert %}}

### **檔案**

設定授權最簡單的方式是將授權檔放在程式的工作目錄，僅指定檔名（不含路徑）。若檔案不在工作目錄，請使用完整路徑。

以下 C++ 程式碼從工作目錄中的 *Aspose.Slides.lic* 檔案套用授權：

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

如果授權有效，[License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 會返回且程式不會有任何輸出；此後 Aspose.Slides 將不受評估限制。若檔案不在工作目錄，該方法會拋出 [FileNotFoundException](https://reference.aspose.com/slides/zh-hant/cpp/system.io/filenotfoundexception/) ，訊息為 *License "Aspose.Slides.lic" doesn't exist or access is restricted*。此範例未處理例外，因此程式會停止。

{{% alert color="warning" title="Warning" %}}

如果將授權檔放在其他目錄，呼叫 [License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法時，指定的完整路徑最後的檔名必須與授權檔案名稱完全相符。

例如，若將授權檔重新命名為 *Aspose.Slides.lic.xml*，必須以結尾為 *Aspose.Slides.lic.xml* 的完整路徑傳遞給 [License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法。

{{% /alert %}}

### **串流**

當程式不以可命名的檔案形式保存授權（例如從資料庫讀取授權）時，可從串流載入授權。[License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 接受任何包含授權的 [Stream](https://reference.aspose.com/slides/zh-hant/cpp/system.io/stream/)。為讓範例保持簡潔，以下 C++ 程式碼使用 [File::OpenRead](https://reference.aspose.com/slides/zh-hant/cpp/system.io/file/openread/) 開啟工作目錄中的 *Aspose.Slides.lic*，並從該串流套用授權：

```c++
#include <Util/License.h>
#include <system/io/file.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;
using namespace System::IO;

int main()
{
    auto license = MakeObject<License>();
    auto stream = File::OpenRead(u"Aspose.Slides.lic");
    license->SetLicense(stream);

    return 0;
}
```

有效的授權會產生與檔案範例相同的結果。若檔案不存在，[File::OpenRead](https://reference.aspose.com/slides/zh-hant/cpp/system.io/file/openread/) 會在授權套用前拋出 [FileNotFoundException](https://reference.aspose.com/slides/zh-hant/cpp/system.io/filenotfoundexception/)，程式會停止。

## **驗證授權**

要檢查授權是否正確設定，呼叫 [License::IsLicensed](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/islicensed/)。只有在成功套用有效授權後才會回傳 `true`，否則回傳 `false`。以下 C++ 程式碼從工作目錄套用授權檔，然後檢查結果：

```c++
#include <Util/License.h>
#include <system/console.h>
#include <system/smart_ptr.h>

using namespace Aspose::Slides;
using namespace System;

int main()
{
    auto license = MakeObject<License>();
    license->SetLicense(u"Aspose.Slides.lic");

    if (license->IsLicensed())
    {
        Console::WriteLine(u"License is good!");
    }

    return 0;
}
```

若授權有效，程式會印出 *License is good!*。若檔案遺失或不是授權檔，[License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 會在檢查前拋出例外，程式會在未印出任何內容的情況下停止。若檔案為授權檔但簽章不符（例如被編輯），SetLicense 會在不發生錯誤的情況下返回，但 `IsLicensed` 會回傳 `false`，因此不會印出任何訊息，Aspose.Slides 仍處於評估模式。

## **執行緒安全性**

{{% alert color="warning" title="Warning" %}}

[License::SetLicense](https://reference.aspose.com/slides/zh-hant/cpp/aspose.slides/license/setlicense/) 方法 **不具執行緒安全性**。如果需要同時從多個執行緒呼叫此方法，建議使用同步原語（例如鎖）以防止潛在問題。

{{% /alert %}}

## **常見問答**

### 我可以在完全離線的環境（無網路連線）套用授權嗎？

可以。授權驗證完全在本機使用授權檔進行，無需網路連線。

### 一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？

不會。授權為永久授權：您可繼續使用訂閱結束日前發布的版本，只是若未續約則無法使用更新的版本。