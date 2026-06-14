---
title: 授權
description: "Aspose.Slides for Python via Java 提供不同的購買方案，或提供免費試用與 30 天臨時授權，讓您依照授權與訂閱政策進行評估。"
type: docs
weight: 80
url: /zh-hant/python-java/licensing/
---
有時為了取得最佳的評估結果，可能需要實際操作。因此，Aspose.Slides 提供了不同的購買方案，並提供免費試用與 30 天臨時授權以供評估。

{{% alert color="primary" %}}
請注意，有多項一般政策與做法可指導您如何評估、正確授權以及購買我們的產品。您可以在[「購買政策與常見問答」](https://purchase.aspose.com/policies)頁面找到相關資訊。
{{% /alert %}}

## **Evaluate Aspose.Slides**
您可以輕鬆下載 Aspose.Slides 進行評估。評估套件與購買套件相同。只要在程式碼中加入幾行授權設定，即可將評估版變為已授權版本。

## **Evaluation Version Limitation**
未指定授權的 Aspose.Slides 評估版提供完整功能，但在文件開啟與儲存時會在頂部插入評估浮水印。從簡報投影片中擷取文字時也僅限於單一投影片。

{{% alert color="primary" %}} 
若您想測試 Aspose.Slides 而不受評估版限制，可申請 **30 Day Temporary License**。請參考[How to get a Temporary License?](https://purchase.aspose.com/temporary-license)取得更多資訊。
{{% /alert %}} 

## **About the License**
您可以從其[download page](https://releases.aspose.com/slides/zh-hant/python-java/)輕鬆下載 Aspose.Slides for Python via Java 的評估版。評估版提供與已授權版**完全相同的功能**。此外，購買授權並在程式碼中加入幾行授權設定後，評估版即會轉為已授權。

授權檔是一個純文字 XML 檔，內含產品名稱、授權開發人員數量、訂閱到期日等資訊。檔案已經數位簽章，請勿修改檔案。即使不小心在檔案內容加入額外換行，也會使其失效。

為避免評估版的限制，您必須在使用 **Aspose.Slides** 前設定授權。每個應用程式或處理程序只需設定一次授權。

## Purchased License

購買後，您需要套用授權檔或串流。 

{{% alert color="primary" %}}
您需要設定授權：
* 每個應用程式域僅一次
* 在使用任何其他 Aspose.Slides 類別之前
{{% /alert %}}

{{% alert color="primary" %}}
您可以在[“Pricing Information”](https://purchase.aspose.com/pricing/slides/zh-hant/family)頁面找到價格資訊。
{{% /alert %}}

### **Setting a License in Aspose.Slides for Python via Java**
授權可以從以下位置套用：

* 明確路徑
* 串流
* 作為 Metered License – 新的授權機制

{{% alert color="primary" %}}
使用 **setLicense** 方法為元件授權。

雖然多次呼叫 **setLicense** 不會造成傷害，但會浪費資源（處理器）。
{{% /alert %}}

{{% alert color="warning" %}}
新授權僅能在版本 21.4 或更高版本的 Aspose.Slides 中啟用。較早版本使用不同的授權系統，無法辨識這些授權。
{{% /alert %}}

#### **Applying a License Using a File**
以下程式碼片段用於設定授權檔：

**Python**
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
pres = Presentation()
license.setLicense("Aspose.Slides.lic");

jpype.shutdownJVM()
```

呼叫 setLicense 方法時，授權名稱應與您的授權檔名稱相同。例如，您可以將授權檔名稱改為 "Aspose.Slides.lic.xml"。然後在程式碼中將新名稱 (Aspose.Slides.lic.xml) 傳遞給 setLicense 方法。

#### **Applying a License from a Bytes**
以下程式碼片段用於從位元組套用授權：

**Python**
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, License

license = License();
input = open("Aspose.Slides.lic", mode="rb")
data = input.read()
pres = Presentation()
license.setLicenseFromBytes(data);

jpype.shutdownJVM()
```

#### Apply Metered License
Aspose.Slides 允許開發人員套用計量金鑰。這是一種新的授權機制。

新的授權機制將與現有授權方式一起使用。希望根據 API 功能使用量計費的客戶可以使用計量授權。

完成取得此類授權的所有必要步驟後，您將收到金鑰，而非授權檔。此計量金鑰可使用專為此目的引入的 **Metered** 類別套用。

以下程式碼示範如何設定計量的公私鑰：
```python
import jpype
import asposeslides

jpype.startJVM()

from asposeslides.api import Presentation, Metered, SaveFormat

# 建立 CAD Metered 類別的實例
metered = Metered();

# 存取 set_metered_key 屬性，並將公鑰與私鑰作為參數傳入
metered.setMeteredKey("*****", "*****");

# 在呼叫 API 前取得計量資料量
amountbefore = Metered.getConsumptionQuantity()

# 顯示資訊
print("Amount Consumed Before: \" + amountbefore + \"" )

# 從磁碟載入文件。
pres = Presentation();

# 取得文件的頁數
print("Amount Consumed After: \" +  pres.getSlides().size()) + \"" )

# 儲存為 PDF
pres.save("out_pdf.pdf", SaveFormat.Pdf);

# 在呼叫 API 後取得計量資料量
amountafter = Metered.getConsumptionQuantity()

# 顯示資訊
print("Amount Consumed After: \" + amountafter + \"" )

jpype.shutdownJVM()
```

{{% alert color="primary" %}}
請注意，使用計量授權必須保持穩定的網際網路連線，因為計量機制需要不斷與我們的服務互動以進行正確計算。詳情請參閱[“Metered Licensing FAQ”](https://purchase.aspose.com/faqs/licensing/metered)章節。
{{% /alert %}}