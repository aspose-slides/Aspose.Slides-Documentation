---
title: 示範設定
type: docs
weight: 70
url: /zh-hant/jasperreports/demos-setup/
description: "設定 Aspose.Slides for JasperReports 下載的示範專案，變更它們使用的匯出類別，並使用 Ant 進行建置。"
---
## **範例是什麼**

Aspose.Slides for JasperReports 下載的 *samples* 資料夾包含八個示範專案：*charts*、*fonts*、*images*、*landscape*、*shapes*、*subreport*、*text* 以及 *xmldatasource*。它們是標準的 JasperReports 示範，已修改以加入 `ppt` 建置目標，將填充的報表匯出為 PPT。下載中不含匯出的簡報；您需要透過建置示範來產生它們。

## **在建置之前變更匯出類別**

依照出貨時的設定，示範的 Java 程式碼使用 `com.aspose.slides.jasperreports.JRPptExporter`，而此類別不在目前的 jar 中，因此示範無法編譯。在示範的應用程式類別中（例如 *shapes* 示範中的 *ShapesApp.java*），將 `JRPptExporter` 替換為 `ASPptExporter`，即同一套件中的 PPT 匯出類別。*fonts* 示範匯入整個套件，僅需變更程式碼中的類別名稱。

示範也使用了後續 JasperReports 版本已移除的類別，例如 `JExcelApiExporter` 與 `JRExporterParameter.FONT_MAP`。做好上述變更後，示範的編譯情況如下：

| JasperReports 版本 | 可編譯的示範 |
| :- | :- |
| 5.5.1 | 全部八個 |
| 5.5.2 and 6.4.0 | *charts*、*images*、*landscape*、*shapes* 以及 *xmldatasource* |
| 6.16.0 | *charts* |

## **建置示範**

每個示範的 *build.xml* 需要符合 JasperReports 專案的資料夾結構：它會相對於示範資料夾，編譯時參考 *../../../build/classes* 以及 *../../../lib* 目錄下的 jar 檔。

1. 將示範資料夾複製到 JasperReports 專案資料夾中的 *demo/samples*。
2. 從下載的 *lib* 子資料夾中，將符合您 JasperReports 版本的 *aspose.slides.jasperreports.library-xx.x.jar* 複製到 JasperReports 專案的 *lib* 資料夾。請參閱 [安裝 Aspose.Slides for JasperReports](/slides/zh-hant/jasperreports/installing-aspose-slides-for-jasperreports/)。
3. 將您的 JasperReports 版本的 jar 以及其相依的 jar 放入相同的 *lib* 資料夾。除了示範檔案外，*build.xml* 只會將 *build/classes* 和 *lib* 目錄下的 jar 加入類別路徑，而 *build/classes* 只有在您從原始碼編譯 JasperReports 後才會包含 JasperReports 類別。
4. *charts*、*subreport* 與 *text* 示範會讀取 JasperReports 的 HSQLDB 範例資料庫（`jdbc:hsqldb:hsql://localhost`），因此請先啟動其伺服器，詳見下載中的 *samples/Readme.txt*。其他示範不需要資料庫。
5. 在示範資料夾中，編譯應用程式、編譯報表設計、填充報表，並將其匯出為 PPT：

```bash
ant javac
ant compile
ant fill
ant ppt
```

`ppt` 目標會將簡報寫入與已填充報表同一目錄，檔名與報表相同（例如 *LandscapeReport.ppt*）。

有兩個示範需要額外步驟：

- *images* 示範在匯出時會從 `http://jasperreports.sourceforge.net/jasperreports.png` 下載一張圖片。該位址現在會重新導向至 HTTPS，導致 `ppt` 步驟不會產生簡報，除非您在 *ImagesReport.jrxml* 中將位址改為 `https://`。在 JasperReports 6.4.0 中，即使使用 HTTPS，匯出該圖片仍會失敗。
- *xmldatasource* 報表使用 Arial 字型。若系統沒有 Arial，`ant fill` 會顯示字型「不提供給 JVM」的訊息且不會產生已填充的報表，導致 `ant ppt` 無可匯出的檔案。即使建置仍顯示成功，也請檢查每個步驟的輸出。