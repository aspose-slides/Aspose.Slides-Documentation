---
title: 授權
type: docs
weight: 50
url: /zh-hant/jasperreports/licensing/
description: "了解 Aspose.Slides for JasperReports 評估版在匯出檔案中加入了什麼，以及如何在 JasperReports 與 JasperReports Server 中套用授權。"
---
{{% alert color="info" title="Note" %}}

Aspose.Slides for JasperReports 可於[download page](https://releases.aspose.com/slides/zh-hant/jasperreport/)免費且時間無限制地評估。評估版與授權版使用相同的下載檔案。

當您對評估滿意時，[buy a license](https://purchase.aspose.com/pricing/slides/zh-hant/jasperreports/)。請確保您已了解並同意訂閱條款。

授權於訂單完成付款後可從訂單頁面下載。授權是一個純文字、經數位簽名的 XML 檔案，內含客戶名稱、購買的產品與授權類型等資訊。切勿以任何方式修改授權檔案內容：這會使授權失效。

將授權檔下載至電腦，並複製到適當的資料夾（例如您的應用程式資料夾或 **JasperReports\lib**）。
{{% /alert %}}

## **Evaluation Version Limitation**
Aspose.Slides for JasperReports 的評估版（未指定授權）會匯出報表的每一頁，但會在每張投影片或頁面的中心加入評估水印，四種輸出格式（PPT、PPTX、PDF 與 HTML）皆如此，如下圖所示。詳情請參閱[Evaluate Aspose.Slides](/slides/zh-hant/jasperreports/evaluate-aspose-slides/)。

![The evaluation watermark at the center of an exported slide](evaluation_watermark.png)

## **Applying a License**
有多種方式可套用授權，取決於您是使用 JasperReports 還是 JasperServer。

### **Applying a License for JasperReports**
呼叫 `License` 類別的 `setLicense` 方法，傳入讀取授權檔的串流，如同 Aspose.Slides for Java：

```java
import java.io.FileInputStream;

import com.aspose.slides.jasperreports.License;

public class ApplyLicense {
    public static void main(String[] args) {
        try {
            // 建立包含授權檔案的串流物件。
            FileInputStream fstream = new FileInputStream("Aspose.Slides.JasperReports.Developer.lic");

            // 實例化 License 類別。
            License license = new License();

            // 透過串流物件設定授權。
            license.setLicense(fstream);
        } catch (Exception ex) {
            System.out.println(ex.toString());
        }
    }
}
```

或者，將授權檔的路徑傳給匯出器的 `ASExporterParameters.PPT_LICENSE` 參數。在此範例中，`jasperPrint` 為已填寫的報表，參考[Your first export](/slides/zh-hant/jasperreports/#your-first-export)：

```java
ASPptExporter exporter = new ASPptExporter();
exporter.setParameter(JRExporterParameter.JASPER_PRINT, jasperPrint);
exporter.setParameter(JRExporterParameter.OUTPUT_FILE_NAME, "report.ppt");
exporter.setParameter(ASExporterParameters.PPT_LICENSE, "Aspose.Slides.JasperReports.Developer.lic");
exporter.exportReport();
```

### **Applying a License on JasperServer**
在 *applicationContext.xml* 中將 `pptExportParameters` bean 的 `licenseFile` 屬性設為授權檔的路徑，如同[Integration with JasperServer](/slides/zh-hant/jasperreports/integration-with-jasperserver/#set-font-mapping-and-the-license) 所示。