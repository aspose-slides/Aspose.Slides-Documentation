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
- PowerPoint
- 簡報
- PHP
- Aspose.Slides
description: "在 Linux 和 Windows 上安裝 Aspose.Slides for PHP via Java：設定 PHP、Java、Apache Tomcat 與 PHP/Java Bridge，使用 Composer 加入套件，並透過短腳本驗證設定。"
---
## **概述**

Aspose.Slides for PHP via Java 以兩個程序執行。您的 PHP 腳本使用 PHP 類別，透過 PHP/Java Bridge 將每一次呼叫傳遞給在 Apache Tomcat 內部以 Java 執行的 Aspose.Slides。本文說明如何設定雙方、使用 Composer 安裝套件，並執行簡短腳本驗證安裝。

## **先決條件**

- **PHP 7.0 到 8.3**，在 `php.ini` 中將 `allow_url_include = On`。您的腳本會從 Tomcat 透過 HTTP 載入橋接器的客戶端程式庫 `Java.inc`。在 PHP 8.4 之後，只要載入 PHP 的 `xml` 擴充套件，`Java.inc` 就會因錯誤 “end() expects exactly 1 argument” 而停止，而 Windows 版的 PHP 總是載入該擴充套件。
- **[Composer](https://getcomposer.org/)**。
- **Java 8 或更新版本**。只需要 JRE 即可。
- **Apache Tomcat 9**。PHP/Java Bridge 建立於 `javax.servlet` API 上，Tomcat 10 及更高版本不再提供此 API，因此橋接器無法在其上啟動。
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**，最新發行版。其 Web 應用程式 `JavaBridge.war` 於 Tomcat 中執行。

本文在同一台電腦上同時執行 Tomcat 與您的 PHP 腳本。Aspose.Slides 會在 Tomcat 內部開啟與儲存檔案，因此您傳遞給它的每一個路徑必須在 Tomcat 中是有效的。

## **在 Linux 上安裝**

以下指令會在 Ubuntu 24.04 的使用者主目錄下安裝所有必要項目。其他發行版請使用相應的套件管理員安裝相同套件。

1. 安裝 PHP、Composer、Java 以及下載工具，並為 PHP 命令列開啟 `allow_url_include`：

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

2. 下載 Apache Tomcat 9 與 PHP/Java Bridge，將橋接器的 `JavaBridge.war` 放入 Tomcat 的 `webapps` 資料夾，然後啟動 Tomcat。Tomcat 會在啟動時將 WAR 檔解壓至 `webapps/JavaBridge`：

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. 建立專案資料夾，並從 [Packagist](https://packagist.org/packages/aspose/slides) 安裝 Aspose.Slides for PHP via Java：

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. 停止 Tomcat，將套件中的 Aspose.Slides JAR 檔案複製到橋接器的 `WEB-INF/lib` 資料夾，使用套件中提供的 PHP 8 版 `Java.inc` 取代原有檔案，然後再次啟動 Tomcat：

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/zh-hant/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/zh-hant/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   在 PHP 7 環境下，請略過 `Java.inc` 的取代。Tomcat 需要數秒鐘才能啟動，且只要您的腳本使用 Aspose.Slides，就必須保持 Tomcat 正在執行。

## **在 Windows 上安裝**

1. 下載並安裝 [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows)，將其目錄加入 `PATH` 環境變數。將 `php.ini-production` 複製為同目錄下的 `php.ini`，在檔案中設定 `allow_url_include = On`，並取消註解 `extension_dir = "ext"`、`extension=openssl`、`extension=zip` 三行。Composer 需要 `openssl` 下載套件，`zip` 用於解壓縮（除非已安裝 7‑Zip 或 `unzip` 指令在 `PATH` 中）。
2. 下載並安裝 [Composer](https://getcomposer.org/download/)。
3. 下載並安裝 Java，並將 `JAVA_HOME` 環境變數指向其安裝目錄。未設定此變數 Tomcat 無法啟動。
4. 在命令提示字元中下載 Apache Tomcat 9 與 PHP/Java Bridge，將橋接器的 `JavaBridge.war` 放入 Tomcat 的 `webapps` 資料夾，然後啟動 Tomcat。Tomcat 會透過 `CATALINA_HOME` 變數找到自身，因此請在同一個命令提示字元視窗中執行後續步驟。Tomcat 會在啟動時將 WAR 檔解壓至 `webapps\JavaBridge`：

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. 建立專案資料夾，並從 [Packagist](https://packagist.org/packages/aspose/slides) 安裝 Aspose.Slides for PHP via Java：

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. 停止 Tomcat，將套件中的 Aspose.Slides JAR 檔案複製到橋接器的 `WEB-INF\lib` 資料夾，使用套件中提供的 PHP 8 版 `Java.inc` 取代原有檔案，然後再次啟動 Tomcat：

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   在 PHP 7 環境下，請略過 `Java.inc` 的取代。Tomcat 需要數秒鐘才能啟動，且只要您的腳本使用 Aspose.Slides，就必須保持 Tomcat 正在執行。

## **驗證安裝**

將以下腳本另存為 *hello.php* 放在專案資料夾中。它會建立一個包含單一文字方塊的簡報，並儲存於腳本同一目錄下：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh-hant/lib/aspose.slides.php");

use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 400, 100);
    $shape->getTextFrame()->setText("Hello, Aspose.Slides!");
    $presentation->save(__DIR__ . "/hello.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

在專案資料夾執行：

```bash
php hello.php
```

腳本會產生 *hello.pptx*，其中包含一張帶有文字方塊的投影片。若未套用授權，投影片會顯示評估水印；請參閱 [Licensing](/slides/zh-hant/php-java/licensing/)。

腳本直接引入 `aspose.slides.php`：Composer 的自動載入器無法載入這些類別，因為它們全部定義於同一個檔案中。`save` 時使用絕對路徑，因為 Aspose.Slides 於 Tomcat 內部執行，會以 Tomcat 的工作目錄作為相對路徑的基準，而非腳本所在目錄。

## **常見問題**

**如何驗證 Aspose.Slides 已正確整合？**

執行 [驗證安裝](#verify-the-installation) 中的腳本。若能順利產生 *hello.pptx* 而不拋出錯誤，表示 PHP、PHP/Java Bridge 與 Aspose.Slides 已正常協同工作。

**為何腳本會因 “Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'” 而中止？**

PHP 無法從 Tomcat 載入 `Java.inc`。如果錯誤訊息指出 `http://` 包裝器被停用，請在 PHP 命令列使用的 `php.ini` 中將 `allow_url_include = On`，可透過 `php --ini` 查詢正使用的設定檔。若訊息為 “Connection refused”，表示 Tomcat 尚未啟動：請先啟動 Tomcat，或等待數秒鐘後再重試。

**如何在處理大型簡報時限制記憶體消耗？**

僅將 JVM 記憶體上限調高至必要的程度，並在 `finally` 區塊中關閉每個 [Presentation](https://reference.aspose.com/slides/zh-hant/php-java/aspose.slides/presentation/) 例項，以即時釋放快取。這可防止記憶體不足錯誤，並在批次作業期間維持可預測的記憶體使用量。

**能否排除不需要的匯出格式以縮減最終 JAR 檔案大小？**

目前的 Aspose.Slides 版本以單一完整的程式庫發佈，無法在建置時停用特定匯出器（例如 PDF 或 SVG）。