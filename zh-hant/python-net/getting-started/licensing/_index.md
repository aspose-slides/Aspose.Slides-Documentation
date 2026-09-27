---
title: 授權
type: docs
weight: 80
url: /zh-hant/python-net/licensing/
keywords:
- 授權
- 臨時授權
- 設定授權
- 使用授權
- 驗證授權
- 授權檔案
- 評估版本
- Python
- Aspose.Slides
description: "了解如何在 Aspose.Slides for Python via .NET 中套用、管理與排除授權問題。透過我們的步驟指南，確保不間斷存取全部功能。"
---
## **概覽**

Aspose.Slides 可以以評估模式或使用有效授權使用。評估版本提供與授權版本相同的功能，但會在每個保存的簡報的每張投影片上添加評估水印，並截斷程式從簡報中讀取的文字。

## **評估 Aspose.Slides**

您可以從其[下載頁面](https://pypi.org/project/Aspose.Slides/)下載 **Aspose.Slides for Python via .NET** 的評估版本。評估版本提供與授權產品相同的功能。評估套件與購買套件完全相同，加入少量程式碼以套用授權後即可轉為授權版。

當您對 **Aspose.Slides** 的評估感到滿意時，您可以[購買授權](https://purchase.aspose.com/pricing/slides/python-net/)。建議您檢視可用的訂閱選項。如有疑問，請聯絡 Aspose 銷售團隊。

每個 Aspose 授權都包含一年訂閱，期間可免費升級至新版本以及取得修補程式。授權使用者與評估使用者皆可獲得免費、無限制的技術支援。

**評估版本的限制**

* 評估版本（未套用授權時）提供完整功能，但會在每個保存的簡報的每張投影片上添加評估水印文字方塊。
* 程式從簡報中讀取的文字會被截斷為前幾個字符，並附加評估限制的說明。程式寫入的文字則會完整保存。

{{% alert color="info" title="Note" %}}

若要在無限制的情況下測試 Aspose.Slides，您可以申請 **30 天臨時授權**。請參閱[如何取得臨時授權](https://purchase.aspose.com/temporary-license)頁面取得詳細資訊。

{{% /alert %}}

## **Aspose.Slides 的授權方式**

* 評估版本在您購買授權並加入幾行程式碼以套用授權後即會轉為授權版。
* 授權是一個純文字 XML 檔案，內含產品名稱、可覆蓋的開發人員數量、訂閱到期日等資訊。
* 授權檔案已經數位簽章，請勿修改。即使只加入一個換行符也會使其失效。
* Aspose.Slides for Python via .NET 會在您提供的路徑尋找授權。相對路徑或僅檔名會以目前工作目錄為基準解析，而該目錄未必是放置 Python 腳本的資料夾。
* 為避免評估限制，請在使用 Aspose.Slides 前先設定授權。每個應用程式或行程只需設定一次。

{{% alert color="info" title="Note" %}}

您也可以檢視[計量授權](/slides/zh-hant/python-net/metered-licensing/)。

{{% /alert %}}

## **套用授權**

授權可以從**檔案**或**串流**載入。

{{% alert color="info" title="Note" %}}

Aspose.Slides 提供[License](https://reference.aspose.com/slides/python-net/aspose.slides/license/)類別以處理授權事宜。

{{% /alert %}}

{{% alert color="warning" title="Warning" %}}

新授權只能在版本 21.4 或更新版本中啟用 Aspose.Slides。較舊版本使用不同的授權機制，無法辨識這些授權。

{{% /alert %}}

### **檔案**

設定授權最簡單的方式是將授權檔案的路徑傳遞給[set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/)方法。如果僅傳遞檔名，如下例所示，Aspose.Slides 會在目前工作目錄中尋找該檔案。

以下 Python 程式碼示範如何設定授權檔案：

```py
import aspose.slides as slides

# 實例化 License 類別。 
license = slides.License()

# 設定授權檔案路徑。
license.set_license("Aspose.Slides.lic")
```

{{% alert color="warning" title="Warning" %}}

如果您將授權檔案放在其他目錄，呼叫[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str)時，明確路徑最後的檔名必須與授權檔案的名稱相符。

例如，您可以將授權檔案重新命名為 *Aspose.Slides.lic.xml*。然後在程式碼中傳遞該檔案的完整路徑（以 Aspose.Slides.lic.xml 結尾）給[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/#str)方法。

{{% /alert %}}

### **串流**

您可以從串流載入授權。以下 Python 範例示範如何從串流套用授權：

```py
import aspose.slides as slides

# 實例化 License 類別。
license = slides.License()

# 從串流設定授權。
with open("Aspose.Slides.lic", "rb") as stream:
    license.set_license(stream)
```

## **驗證授權**

為確認授權已正確套用，您可以驗證它。以下 Python 程式碼示範如何驗證授權：

```py
import aspose.slides as slides

license = slides.License()

license.set_license("Aspose.Slides.lic")

if license.is_licensed():
    print("License is good!")
```

## **執行緒安全性**

{{% alert color="warning" title="Warning" %}}

[License.set_license](https://reference.aspose.com/slides/python-net/aspose.slides/license/set_license/) 方法不是執行緒安全的。如果需要在多個執行緒中同時呼叫，請使用同步基元（例如 `threading.Lock`）以避免問題。

{{% /alert %}}

## **FAQ**

### 我可以在完全離線的環境（無網路）中套用授權嗎？

可以。授權驗證是使用本機授權檔案完成的，無需網路連線。

### 一年訂閱到期後會發生什麼事？函式庫會停止運作嗎？

不會。授權是永久性的：您仍可使用訂閱結束日前發布的版本，只是若不續約則無法使用更新的版本。