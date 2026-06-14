---
title: 安裝
type: docs
weight: 70
url: /zh-hant/php-java/installation/
keywords:
- 安裝 Aspose.Slides
- 下載 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安裝
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- PHP
- Aspose.Slides
description: "快速安裝 Aspose.Slides for PHP via Java。逐步指南、系統需求與程式碼範例 — 現在即可開始使用 PowerPoint 簡報！"
---
## **概述**

本文說明如何安裝與設定 Aspose.Slides for PHP via Java。它涵蓋所需的環境設定、透過 Packagist 下載函式庫、使用 PHP/Java Bridge 設定 Apache Tomcat，以及執行範例以驗證安裝是否成功。

## **配置環境**

1. 安裝 PHP 7，將 PHP 路徑加入系統 `PATH` 變數，並在 `php.ini` 檔案中將 `allow_url_include` 設為 `On`。
1. 安裝 JRE 8。將 `JAVA_HOME` 環境變數設定為已安裝 JRE 的路徑。
1. 安裝 Apache Tomcat 8.0。

## **下載 Aspose.Slides for PHP via Java**

`packagist` 是下載 [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides) 的最簡單方式。

若要使用 Packagist 安裝 Aspose.Slides，請執行以下指令：
```bash
   composer require aspose/slides
   ```

## **配置 Apache Tomcat**

1. 從 http://php-java-bridge.sourceforge.net/pjb/download.php 下載 PHP/Java Bridge（`php-java-bridge_x.x.x_documentation.zip`），並將 `JavaBridge.war` 檔案解壓縮至 Tomcat 的 `webapps` 資料夾。
1. 啟動 Apache Tomcat 服務。
1. 下載 [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/zh-hant/php-java) 並解壓縮至 `aspose.slides` 資料夾。將 `jar/aspose-slides-x.x-php.jar` 檔案複製至 `webapps\JavaBridge\WEB-INF\lib` 資料夾。若使用 **PHP 8**，請以 `Java.inc.php8.zip` 中的 `Java.inc` 替換 PHP-Java Bridge 中原有的 `Java.inc`。
1. 重新啟動 Apache Tomcat 服務。
1. 在 `aspose.slides` 資料夾中執行 `example.php`，使用以下指令執行範例：
```bash
   php example.php
   ```

## **常見問題**

**如何驗證 Aspose.Slides 已正確整合？**

建置您的專案，實例化一個空白的 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 並以新名稱儲存。若檔案順利建立且未拋出例外，表示函式庫已成功整合。

**如何在處理大型簡報時限制記憶體消耗？**

僅在需要時提升 JVM 記憶體上限，並在 `finally` 區塊中關閉每個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 實例，以即時釋放快取。此做法可防止記憶體不足錯誤，並在批次作業期間保持整體記憶體使用量可預測。

**我可以排除不需要的匯出格式以減小最終 JAR 檔案大小嗎？**

目前的 Aspose.Slides 版本以單一巨集函式庫發布， therefore無法在建置時停用特定匯出器（例如 PDF 或 SVG）。