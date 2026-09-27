---
title: 安装
type: docs
weight: 70
url: /zh/php-java/installation/
keywords:
- 安装 Aspose.Slides
- 下载 Aspose.Slides
- 使用 Aspose.Slides
- Aspose.Slides 安装
- Windows
- Linux
- PowerPoint
- 演示文稿
- PHP
- Aspose.Slides
description: "在 Linux 和 Windows 上安装 Aspose.Slides for PHP via Java：配置 PHP、Java、Apache Tomcat 和 PHP/Java Bridge，使用 Composer 添加包，并通过短脚本验证设置。"
---
## **概述**

Aspose.Slides for PHP via Java 在两个进程中运行。您的 PHP 脚本使用 PHP 类，将每个调用通过 PHP/Java Bridge 传递给运行在 Apache Tomcat 中的 Java 版 Aspose.Slides。本文解释如何设置两端、使用 Composer 安装包以及运行短脚本来验证安装。

## **先决条件**

- **PHP 7.0 到 8.3**，在 `php.ini` 中设置 `allow_url_include = On`。您的脚本从 Tomcat 通过 HTTP 加载桥接的客户端库 `Java.inc`。在 PHP 8.4 及以后版本，如果加载了 PHP 的 `xml` 扩展，`Java.inc` 会因错误 “end() expects exactly 1 argument” 而停止，且 Windows 版 PHP 总是加载该扩展。
- **[Composer](https://getcomposer.org/)**。
- **Java 8 或更高版本。** JRE 即可。
- **Apache Tomcat 9。** PHP/Java Bridge 基于 `javax.servlet` API，而 Tomcat 10 及以后不再提供该 API，因此桥接在这些版本上无法启动。
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**，最新发布版本。它的 Web 应用 `JavaBridge.war` 在 Tomcat 中运行。

本文在同一台计算机上运行 Tomcat 和您的 PHP 脚本。Aspose.Slides 在 Tomcat 内部打开和保存文件，因此脚本传递给它的每个路径都必须在 Tomcat 中有效。

## **在 Linux 上安装**

这些命令在 Ubuntu 24.04 的用户主目录中安装所有内容。对于其他发行版，请使用相应的包管理器安装相同的软件包。

1. 安装 PHP、Composer、Java 和下载工具，然后为 PHP 命令行打开 `allow_url_include`：

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
```

2. 下载 Apache Tomcat 9 和 PHP/Java Bridge，将桥接的 `JavaBridge.war` 放入 Tomcat 的 `webapps` 文件夹，然后启动 Tomcat。Tomcat 启动时会将 WAR 文件解压到 `webapps/JavaBridge`：

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

3. 创建项目文件夹，并从 [Packagist](https://packagist.org/packages/aspose/slides) 安装 Aspose.Slides for PHP via Java：

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

4. 停止 Tomcat，将包中的 Aspose.Slides JAR 文件复制到桥接的 `WEB-INF/lib` 文件夹，用包中的 PHP 8 版本 `Java.inc` 替换桥接的 `Java.inc`，然后再次启动 Tomcat：

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/zh/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/zh/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   对于 PHP 7，跳过 `Java.inc` 的替换。Tomcat 启动需要几秒钟，且在脚本使用 Aspose.Slides 时必须保持运行。

## **在 Windows 上安装**

1. 安装 [PHP 8.3 for Windows](https://www.php.net/downloads.php?os=windows)，并将其文件夹添加到 `PATH` 环境变量。将 `php.ini-production` 复制为同文件夹下的 `php.ini`。在 `php.ini` 中，设置 `allow_url_include = On` 并取消注释 `extension_dir = "ext"`、`extension=openssl` 和 `extension=zip` 行。Composer 需要 `openssl` 来下载包，需要 `zip` 来解压，除非已安装 7‑Zip 或 `PATH` 中已有 `unzip` 命令。
2. 安装 [Composer](https://getcomposer.org/download/)。
3. 安装 Java 并将 `JAVA_HOME` 环境变量设置为其安装目录。没有该变量 Tomcat 将无法启动。
4. 在命令提示符中，下载 Apache Tomcat 9 和 PHP/Java Bridge，将桥接的 `JavaBridge.war` 放入 Tomcat 的 `webapps` 文件夹并启动 Tomcat。Tomcat 的脚本通过 `CATALINA_HOME` 变量找到 Tomcat，因此后续步骤请继续使用同一命令提示符窗口。Tomcat 启动时会将 WAR 文件解压到 `webapps\\JavaBridge`：

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

5. 创建项目文件夹，并从 [Packagist](https://packagist.org/packages/aspose/slides) 安装 Aspose.Slides for PHP via Java：

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

6. 停止 Tomcat，将包中的 Aspose.Slides JAR 文件复制到桥接的 `WEB-INF\\lib` 文件夹，用包中的 PHP 8 版本 `Java.inc` 替换桥接的 `Java.inc`，然后再次启动 Tomcat：

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   对于 PHP 7，跳过 `Java.inc` 的替换。Tomcat 启动需要几秒钟，且在脚本使用 Aspose.Slides 时必须保持运行。

## **验证安装**

将此脚本保存为项目文件夹中的 *hello.php*。它会创建一个包含一个文本框的演示文稿，并将其保存于脚本所在目录旁边：

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/zh/lib/aspose.slides.php");

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

在项目文件夹中运行它：

```bash
php hello.php
```

脚本会生成 *hello.pptx*，其中包含一个包含文本框的幻灯片。未授权时，幻灯片还会带有试用水印；参见 [Licensing](/slides/zh/php-java/licensing/)。

脚本直接包含 `aspose.slides.php`：Composer 的自动加载器无法加载这些类，因为它们全部定义在同一个文件中。它还向 `save` 传递了绝对路径，因为 Aspose.Slides 在 Tomcat 中运行，并将相对路径解析为 Tomcat 的工作文件夹，而不是脚本所在的文件夹。

## **常见问题**

**如何验证已正确集成 Aspose.Slides？**

运行 [验证安装](#verify-the-installation) 中的脚本。如果它能够在无错误的情况下生成 *hello.pptx*，则 PHP、PHP/Java Bridge 和 Aspose.Slides 已成功协同工作。

**为什么我的脚本会因 "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'" 而停止？**

PHP 无法从 Tomcat 加载 `Java.inc`。如果前面的提示信息显示 `http://` 包装器被禁用，请在 PHP 命令行使用的 `php.ini` 文件中将 `allow_url_include` 设置为 `On`；可以通过 `php --ini` 查看使用的是哪个文件。如果提示 “Connection refused”，说明 Tomcat 尚未启动：请启动它，或等待几秒钟直至启动完成。

**在处理大型演示文稿时，如何限制内存消耗？**

仅在需要时提升 JVM 内存上限，并在 `finally` 块中关闭每个 [Presentation](https://reference.aspose.com/slides/zh/php-java/aspose.slides/presentation/) 实例，以及时释放缓存。这样可防止内存不足错误，并在批处理操作期间保持整体内存使用的可预测性。

**我能排除不需要的导出格式以减小最终 JAR 大小吗？**

当前的 Aspose.Slides 发行版以单一整体库的形式提供，无法在构建时禁用像 PDF 或 SVG 等特定导出器。