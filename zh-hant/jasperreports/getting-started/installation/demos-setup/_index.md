---
title: 示範設定
type: docs
weight: 70
url: /zh-hant/jasperreports/demos-setup/
---
Aspose.Slides for JasperReports 所提供的所有示範均為已變更的標準示範。建議將所有示範複製到 JasperReports 的示範資料夾：
...\jasperreports-x.x.x\demo\samples\

使用標準指令序列來建置與匯出報表：

- ant javac
- ant compile
- ant fill
- ant ppt

{{% alert color="info" %}} 
請務必啟動 HSQLDB 並使用測試資料庫，以填充報表資料，並將 aspose.slides.jasperreports.library-xx.x.jar 從 \lib\JasperReports X.X.X - X.X.X 資料夾（位於 aspose-slides-xx.x-jasperreports.zip 中）複製至 &#60;InstallDir&#62;\lib 目錄。
{{% /alert %}} 

大多數示範（Charts 除外）已經產生了投影片檔案，您可以直接略過所有 “ant” 步驟，立即檢視結果。