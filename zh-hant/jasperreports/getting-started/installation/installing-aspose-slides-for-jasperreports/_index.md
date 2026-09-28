---
title: 安裝 Aspose.Slides for JasperReports
type: docs
weight: 40
url: /zh-hant/jasperreports/installing-aspose-slides-for-jasperreports/
description: "選取與您的 JasperReports 版本相符的 Aspose.Slides for JasperReports JAR 檔，並將它們加入 JasperReports、Maven 專案或 JasperReports Server。"
---
## **選擇適用於您的 JasperReports 版本的 JAR 檔案**

Aspose.Slides for JasperReports 以 ZIP 檔案形式提供，位於[下載頁面](https://releases.aspose.com/slides/jasperreport/)。其 *lib* 資料夾依 JasperReports 版本區間有一個子資料夾。請從符合您使用的 JasperReports 版本的子資料夾取得 JAR 檔案：

| JasperReports 版本 | *lib* 子資料夾 |
| :- | :- |
| 3.7.2 to 5.5.1 | *JasperReports 3.7.2 - 5.5.1 (JDK 1.6)* |
| 5.5.2 to 6.4.0 | *JasperReports 5.5.2 - 6.4.0 (JDK 1.6)* |
| 6.5.0 to 6.16.0 | *JasperReports 6.5.0 - 6.16.0 (JDK 1.6)* |

JasperReports 6.17.0 之後（包括 JasperReports 7）沒有相對的子資料夾。*JasperReports 2.0.3 - 3.7.1 (JDK 1.4)* 子資料夾不包含任何 JAR，僅有一則註記，說明對這些版本的支援於 Aspose.Slides for JasperReports 17.6 結束。

每個子資料夾包含兩個 JAR；名稱中的 *xx.x* 代表產品版本：

- *aspose.slides.jasperreports.library-xx.x.jar* 包含 JasperReports Library 的匯出器（`ASPptExporter`、`ASPptxExporter`、`ASPdfExporter` 和 `ASHtmlExporter`）以及 `License` 類別。
- *aspose.slides.jasperreports.server-xx.x.jar* 包含 JasperReports Server 的匯出動作。它基於 library jar，因此 Server 總是需要同一子資料夾中的兩個 JAR。

## **將 library JAR 加入 JasperReports 或您的應用程式**

將相符子資料夾中的 *aspose.slides.jasperreports.library-xx.x.jar* 複製到 JasperReports 的 *lib* 資料夾，或是您的應用程式的 classpath。之後，您的應用程式即可在程式碼中建立匯出器。

{{% alert color="info" title="Note" %}}
在 Linux 上，JasperReports 需要 fontconfig 並且至少安裝一種字型才能填充報表。若缺少字型，填充會失敗，錯誤訊息為「Error initializing graphic environment」。
{{% /alert %}}

## **將 library JAR 加入 Maven 專案**

JAR 檔隨 ZIP 包提供，而非來自 Maven 套件庫。若要在 Maven 構建中使用，需將其安裝至本機 Maven 套件庫。針對版本 26.6，請在存放該 JAR 的資料夾中執行以下指令：

```bash
mvn install:install-file "-Dfile=aspose.slides.jasperreports.library-26.6.jar" "-DgroupId=com.aspose" "-DartifactId=aspose-slides-jasperreports" "-Dversion=26.6" "-Dpackaging=jar"
```

然後在 *pom.xml* 中的相依性加入它，並搭配該 JAR 子資料夾所支援的 JasperReports 版本：

```xml
<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides-jasperreports</artifactId>
    <version>26.6</version>
</dependency>
```

group 與 artifact ID 為您在安裝指令中自行指定的，只要相互匹配即可。使用 JasperReports 6.16.0 的完整專案可在[您的第一次匯出](/slides/zh-hant/jasperreports/#your-first-export) 中取得。

## **將 JAR 加入 JasperReports Server**

將兩個 JAR 從相符的子資料夾複製到 JasperReports Server 網路應用程式的 *WEB-INF/lib* 資料夾，然後依照[與 JasperServer 整合](/slides/zh-hant/jasperreports/integration-with-jasperserver/) 中的說明註冊匯出器。