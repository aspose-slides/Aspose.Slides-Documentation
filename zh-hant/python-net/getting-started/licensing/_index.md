---
title: 授權
type: docs
weight: 80
url: /zh-hant/python-net/licensing/
keywords:
- 授權
- 暫時授權
- 設定授權
- 使用授權
- 驗證授權
- 授權檔案
- 評估版
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中套用、管理與排除授權問題。透過我們的逐步授權指南，確保不間斷使用完整功能。"
---
## **概述**

Aspose.Slides 可在評估模式或使用有效授權下使用。評估版提供與授權版相同的功能，但在開啟或儲存簡報時會加入評估浮水印，且文字擷取僅限於一張投影片。

## **評估 Aspose.Slides**

您可以從其[下載頁面](https://pypi.org/project/Aspose.Slides/)下載 **Aspose.Slides for Python via .NET** 的評估版。評估版提供與授權產品相同的功能。評估套件與購買的套件相同，加入幾行程式碼套用授權後即為授權版。

當您對 **Aspose.Slides** 的評估滿意後，您可以[購買授權](https://purchase.aspose.com/buy)。我們建議檢視可用的訂閱選項。如有疑問，請聯絡 Aspose 銷售團隊。

每份 Aspose 授權皆包括一年訂閱，期間可免費升級至新版本並取得修正。授權使用者與評估使用者皆可獲得免費、無限制的技術支援。

## **評估版的限制**

* 雖然 Aspose.Slides 評估版（未套用授權時）提供完整功能，但每次開啟或儲存文件時，會在文件頂部加入評估浮水印。
* 從簡報擷取文字時，僅限於一張投影片。

{{% alert color="primary" %}}
若要在無限制的情況下測試 Aspose.Slides，您可以請求 **30 天臨時授權**。請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面取得詳細資訊。
{{% /alert %}}

## **Aspose.Slides 的授權**

* 評估版在您購買授權並加入幾行程式碼套用後，即轉為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、涵蓋的開發人員數量、訂閱到期日等資訊。
* 授權檔案已經數位簽章，禁止修改。即使僅新增一個換行也會使其失效。
* Aspose.Slides for Python via .NET 通常會在以下位置搜尋授權檔案：
  * 您提供的明確路徑
  * 呼叫 Aspose.Slides for Python via .NET 的 Python 腳本所在的資料夾
* 為避免評估限制，請在使用 Aspose.Slides 前先設定授權。每個應用程式或處理序只需設定一次。

{{% alert color="primary" %}}
您也可能想要檢視[計量授權](/slides/zh-hant/python-net/metered-licensing/)。
{{% /alert %}}

## **套用授權**

授權可以從 **檔案**、**串流** 或 **內嵌資源** 載入。

{{% alert color="primary" %}}
Aspose.Slides 提供 [License](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/license/) 類別來處理授權。
{{% /alert %}}

{{% alert color="warning" %}}
新授權只能在 21.4 版或更新版本的 Aspose.Slides 中啟用。較早的版本使用不同的授權機制，無法辨識這些授權。
{{% /alert %}}

### **檔案**

設定授權最簡單的方式是將授權檔案放在與元件 DLL 相同的資料夾中，並僅指定檔名（不含路徑）。

以下 Python 程式碼示範如何設定授權檔案：

```py
import aspose.slides as slides

# 實例化 License 類別。 
license = slides.License()

# 設定授權檔案路徑。 
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" %}}
如果您將授權檔案放在其他目錄，當呼叫 [License.set_license()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/license/set_license/#str) 時，明確路徑最後的檔名必須與授權檔案名稱相符。

例如，您可以將授權檔案重新命名為 *Aspose.Slides.lic.xml*。然後在程式碼中，將該檔案的完整路徑（以 Aspose.Slides.lic.xml 結尾）傳遞給 [License.set_license()](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/license/set_license/#str) 方法。
{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Python 範例示範如何從串流套用授權：

```py
import aspose.slides as slides

# 實例化 License 類別。
license = slides.License()

# 從串流設定授權。
license.set_license(stream)
```

## **驗證授權**

要驗證授權是否正確套用，您可以進行驗證。以下 Python 程式碼示範如何驗證授權：

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **執行緒安全性**

{{% alert title="Note" color="warning" %}}
[License.set_license](https://reference.aspose.com/slides/zh-hant/python-net/aspose.slides/license/) 方法不是執行緒安全的。若需在多執行緒中同時呼叫，請使用同步原語（例如 `threading.Lock`）以避免問題。
{{% /alert %}}

## **常見問題**

**我可以在完全離線的環境（沒有網路）中套用授權嗎？**

是的。授權驗證在本機使用授權檔案完成，無需網路連線。

**一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？**

不會。授權為永久性：您仍可使用訂閱結束日前發佈的版本；但若未續約，將無法使用更新的版本。