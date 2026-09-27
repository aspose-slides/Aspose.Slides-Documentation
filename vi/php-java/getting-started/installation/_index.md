---
title: Cài đặt
type: docs
weight: 70
url: /vi/php-java/installation/
keywords:
- cài đặt Aspose.Slides
- tải xuống Aspose.Slides
- sử dụng Aspose.Slides
- cài đặt Aspose.Slides
- Windows
- Linux
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Cài đặt Aspose.Slides cho PHP qua Java trên Linux và Windows: cấu hình PHP, Java, Apache Tomcat và PHP/Java Bridge, thêm gói bằng Composer, và xác minh cài đặt bằng một script ngắn."
---
## **Tổng quan**

Aspose.Slides for PHP via Java chạy trong hai tiến trình. Kịch bản PHP của bạn sử dụng các lớp PHP chuyển mọi lời gọi qua PHP/Java Bridge tới Aspose.Slides, chạy trên Java bên trong Apache Tomcat. Bài viết này giải thích cách thiết lập cả hai phía, cài đặt gói bằng Composer và chạy một kịch bản ngắn để xác nhận việc cài đặt.

## **Yêu cầu trước**

- **PHP 7.0 đến 8.3**, với `allow_url_include = On` trong `php.ini`. Các kịch bản của bạn tải thư viện khách hàng của bridge, `Java.inc`, từ Tomcat qua HTTP. Trên PHP 8.4 trở lên, `Java.inc` dừng lại với lỗi "end() expects exactly 1 argument" mỗi khi phần mở rộng `xml` của PHP được tải, và bản dựng Windows của PHP luôn tải nó.
- **[Composer](https://getcomposer.org/)**.
- **Java 8 hoặc mới hơn.** Một JRE là đủ.
- **Apache Tomcat 9.** PHP/Java Bridge được xây dựng trên API `javax.servlet`, mà Tomcat 10 trở lên không còn cung cấp, vì vậy bridge không khởi động được trên đó.
- **[PHP/Java Bridge](https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/) 7.2.1**, bản phát hành mới nhất. Ứng dụng web của nó, `JavaBridge.war`, chạy trong Tomcat.

Bài viết này chạy Tomcat và các kịch bản PHP của bạn trên cùng một máy tính. Aspose.Slides mở và lưu tệp bên trong Tomcat, vì vậy mọi đường dẫn mà kịch bản của bạn truyền cho nó đều phải hợp lệ ở đó.

## **Cài đặt trên Linux**

Các lệnh này cài đặt mọi thứ trong thư mục home của bạn trên Ubuntu 24.04. Trên các bản phân phối khác, cài đặt các gói tương tự bằng trình quản lý gói của bản phân phối.

1. Cài đặt PHP, Composer, Java và các công cụ tải xuống, sau đó bật `allow_url_include` cho dòng lệnh PHP:

   ```bash
   sudo apt-get update
   sudo apt-get install -y php-cli composer default-jre-headless curl unzip
   sudo sed -i 's/^allow_url_include = Off/allow_url_include = On/' "$(php -r 'echo php_ini_loaded_file();')"
   ```

1. Tải Apache Tomcat 9 và PHP/Java Bridge, đặt `JavaBridge.war` của bridge vào thư mục `webapps` của Tomcat, và khởi động Tomcat. Tomcat giải nén file WAR vào `webapps/JavaBridge` khi khởi động:

   ```bash
   cd ~
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122.tar.gz
   tar -xzf apache-tomcat-9.0.122.tar.gz
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   unzip -o php-java-bridge.zip JavaBridge.war -d apache-tomcat-9.0.122/webapps
   apache-tomcat-9.0.122/bin/startup.sh
   ```

1. Tạo thư mục dự án và cài đặt Aspose.Slides for PHP via Java từ [Packagist](https://packagist.org/packages/aspose/slides):

   ```bash
   mkdir ~/hello-slides
   cd ~/hello-slides
   composer require aspose/slides
   ```

1. Dừng Tomcat, sao chép file JAR Aspose.Slides từ gói vào thư mục `WEB-INF/lib` của bridge, thay thế `Java.inc` của bridge bằng phiên bản PHP 8 từ gói, và khởi động lại Tomcat:

   ```bash
   ~/apache-tomcat-9.0.122/bin/shutdown.sh
   cp vendor/aspose/slides/vi/jar/aspose-slides-*-php.jar ~/apache-tomcat-9.0.122/webapps/JavaBridge/WEB-INF/lib/
   unzip -o vendor/aspose/slides/vi/Java.inc.php8.zip -d ~/apache-tomcat-9.0.122/webapps/JavaBridge/java/
   ~/apache-tomcat-9.0.122/bin/startup.sh
   ```

   Trên PHP 7, bỏ qua việc thay thế `Java.inc`. Tomcat mất vài giây để khởi động, và nó phải chạy mỗi khi các kịch bản của bạn sử dụng Aspose.Slides.

## **Cài đặt trên Windows**

1. Cài đặt [PHP 8.3 cho Windows](https://www.php.net/downloads.php?os=windows) và thêm thư mục của nó vào biến môi trường `PATH`. Sao chép `php.ini-production` thành `php.ini` trong cùng thư mục. Trong `php.ini`, đặt `allow_url_include = On` và bỏ chú thích các dòng `extension_dir = "ext"`, `extension=openssl`, và `extension=zip`. Composer cần `openssl` để tải gói, và `zip` để giải nén trừ khi đã cài đặt 7‑Zip hoặc có lệnh `unzip` trong `PATH`.
1. Cài đặt [Composer](https://getcomposer.org/download/).
1. Cài đặt Java và đặt biến môi trường `JAVA_HOME` trỏ tới thư mục của nó. Tomcat không khởi động nếu không có biến này.
1. Trong Command Prompt, tải Apache Tomcat 9 và PHP/Java Bridge, đặt `JavaBridge.war` của bridge vào thư mục `webapps` của Tomcat, và khởi động Tomcat. Các script của Tomcat tìm Tomcat thông qua biến `CATALINA_HOME`, vì vậy hãy tiếp tục dùng cùng một cửa sổ Command Prompt cho các bước tiếp theo. Tomcat giải nén file WAR vào `webapps\JavaBridge` khi khởi động:

   ```bat
   cd %USERPROFILE%
   curl -fsSLO https://archive.apache.org/dist/tomcat/tomcat-9/v9.0.122/bin/apache-tomcat-9.0.122-windows-x64.zip
   tar -xf apache-tomcat-9.0.122-windows-x64.zip
   set CATALINA_HOME=%USERPROFILE%\apache-tomcat-9.0.122
   curl -fsSL -o php-java-bridge.zip "https://sourceforge.net/projects/php-java-bridge/files/Binary%20package/php-java-bridge_7.2.1/php-java-bridge_7.2.1_documentation.zip/download"
   tar -xf php-java-bridge.zip -C "%CATALINA_HOME%\webapps" JavaBridge.war
   "%CATALINA_HOME%\bin\startup.bat"
   ```

1. Tạo thư mục dự án và cài đặt Aspose.Slides for PHP via Java từ [Packagist](https://packagist.org/packages/aspose/slides):

   ```bat
   mkdir %USERPROFILE%\hello-slides
   cd %USERPROFILE%\hello-slides
   composer require aspose/slides
   ```

1. Dừng Tomcat, sao chép file JAR Aspose.Slides từ gói vào thư mục `WEB-INF\lib` của bridge, thay thế `Java.inc` của bridge bằng phiên bản PHP 8 từ gói, và khởi động lại Tomcat:

   ```bat
   "%CATALINA_HOME%\bin\shutdown.bat"
   copy vendor\aspose\slides\jar\aspose-slides-*-php.jar "%CATALINA_HOME%\webapps\JavaBridge\WEB-INF\lib\"
   tar -xf vendor\aspose\slides\Java.inc.php8.zip -C "%CATALINA_HOME%\webapps\JavaBridge\java"
   "%CATALINA_HOME%\bin\startup.bat"
   ```

   Trên PHP 7, bỏ qua việc thay thế `Java.inc`. Tomcat mất vài giây để khởi động, và nó phải chạy mỗi khi các kịch bản của bạn sử dụng Aspose.Slides.

## **Xác minh việc cài đặt**

Lưu kịch bản này dưới tên *hello.php* trong thư mục dự án. Nó tạo một bản trình chiếu với một hộp văn bản và lưu nó bên cạnh kịch bản:

```php
<?php
require_once("http://localhost:8080/JavaBridge/java/Java.inc");
require_once(__DIR__ . "/vendor/aspose/slides/vi/lib/aspose.slides.php");

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

Chạy nó từ thư mục dự án:

```bash
php hello.php
```

Kịch bản sẽ ghi *hello.pptx*, với một slide chứa hộp văn bản. Khi không có giấy phép, slide cũng sẽ hiển thị watermark đánh giá; xem [Licensing](/slides/vi/php-java/licensing/).

Kịch bản bao gồm trực tiếp `aspose.slides.php`: trình tự động tải của Composer không thể tải các lớp này, vì chúng đều được định nghĩa trong một file duy nhất. Nó cũng truyền một đường dẫn tuyệt đối tới `save`, vì Aspose.Slides chạy bên trong Tomcat và giải quyết đường dẫn tương đối dựa trên thư mục làm việc của Tomcat, không phải của kịch bản của bạn.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể xác minh rằng Aspose.Slides đã được tích hợp đúng?**

Chạy kịch bản trong [Xác minh việc cài đặt](#xác-mính-việc-cài-đặt). Nếu nó ghi *hello.pptx* mà không có lỗi, PHP, PHP/Java Bridge và Aspose.Slides đang hoạt động cùng nhau.

**Tại sao kịch bản của tôi dừng lại với lỗi "Failed opening required 'http://localhost:8080/JavaBridge/java/Java.inc'"?**

PHP không thể tải `Java.inc` từ Tomcat. Nếu thông báo trước đó cho biết trình bao `http://` bị tắt, hãy đặt `allow_url_include = On` trong file `php.ini` mà dòng lệnh PHP của bạn tải; `php --ini` sẽ cho biết file đó là nào. Nếu thông báo là "Connection refused", Tomcat chưa chạy: hãy khởi động nó, hoặc chờ vài giây cho đến khi nó sẵn sàng.

**Làm sao tôi có thể giới hạn tiêu thụ bộ nhớ khi xử lý các bản trình chiếu lớn?**

Tăng giới hạn bộ nhớ JVM chỉ lên mức cần thiết, và đóng mỗi đối tượng [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trong khối `finally` để giải phóng bộ nhớ cache kịp thời. Điều này ngăn lỗi hết bộ nhớ và giữ mức tiêu thụ bộ nhớ tổng thể ổn định trong các thao tác batch.

**Tôi có thể loại bỏ các định dạng xuất không cần thiết để giảm kích thước JAR cuối cùng không?**

Các phiên bản hiện tại của Aspose.Slides được phát hành dưới dạng một thư viện đơn khối, vì vậy bạn không thể tắt các trình xuất cụ thể như PDF hoặc SVG ở thời điểm biên dịch.