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
- macOS
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Cài đặt nhanh Aspose.Slides cho PHP qua Java. Hướng dẫn chi tiết từng bước, yêu cầu hệ thống và mẫu mã — bắt đầu làm việc với các bản trình bày PowerPoint ngay hôm nay!"
---
## **Tổng quan**

Bài viết này giải thích cách cài đặt và cấu hình Aspose.Slides cho PHP qua Java. Nó bao gồm việc thiết lập môi trường cần thiết, tải xuống thư viện qua Packagist, cấu hình Apache Tomcat với PHP/Java Bridge, và chạy một ví dụ để xác minh việc cài đặt.

## **Cấu hình môi trường**

1. Cài đặt PHP 7, thêm đường dẫn PHP vào biến hệ thống `PATH` và đặt `allow_url_include` thành `On` trong tệp `php.ini` file.
1. Cài đặt JRE 8. Đặt biến môi trường `JAVA_HOME` tới đường dẫn của JRE đã cài đặt.
1. Cài đặt Apache Tomcat 8.0.

## **Tải Aspose.Slides cho PHP qua Java** 

`packagist` là cách dễ nhất để tải [Aspose.Slides for PHP via Java](https://packagist.org/packages/aspose/slides). 

Để cài đặt Aspose.Slides bằng Packagist, chạy lệnh sau: 
   ```bash
   composer require aspose/slides
   ```

## **Cấu hình Apache Tomcat**

1. Tải PHP/Java Bridge (`php-java-bridge_x.x.x_documentation.zip`) từ http://php-java-bridge.sourceforge.net/pjb/download.php và giải nén tệp `JavaBridge.war` vào thư mục `webapps` của Tomcat.
1. Khởi động dịch vụ Apache Tomcat.
1. Tải [“Aspose.Slides for PHP via Java”](https://downloads.aspose.com/slides/vi/php-java) và giải nén vào thư mục `aspose.slides`. Sao chép tệp `jar/aspose-slides-x.x-php.jar` vào thư mục `webapps\JavaBridge\WEB-INF\lib`. Nếu bạn đang sử dụng **PHP 8**, thay thế `Java.inc` gốc từ PHP-Java Bridge bằng `Java.inc` từ `Java.inc.php8.zip`.
1. Khởi động lại dịch vụ Apache Tomcat.
1. Chạy `example.php` trong thư mục `aspose.slides` để thực thi ví dụ bằng lệnh sau:
   ```bash
   php example.php
   ```

## **Câu hỏi thường gặp**

**Làm thế nào để tôi xác minh rằng Aspose.Slides đã được tích hợp đúng cách?**

Xây dựng dự án của bạn, khởi tạo một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trống và lưu nó với tên mới. Nếu tệp được tạo mà không ném ra ngoại lệ, thư viện đã được tích hợp thành công.

**Làm thế nào để tôi hạn chế tiêu thụ bộ nhớ khi xử lý các bản trình bày lớn?**

Tăng giới hạn bộ nhớ JVM chỉ vừa đủ, và đóng mỗi thể hiện [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) trong khối `finally` để giải phóng bộ nhớ đệm kịp thời. Điều này ngăn ngừa lỗi hết bộ nhớ và giữ cho việc sử dụng bộ nhớ tổng thể dự đoán được trong các thao tác batch.

**Tôi có thể loại bỏ các định dạng xuất không mong muốn để giảm kích thước JAR cuối cùng không?**

Các bản phát hành hiện tại của Aspose.Slides được cung cấp dưới dạng một thư viện đơn khối, vì vậy bạn không thể tắt các bộ xuất cụ thể như PDF hoặc SVG ở thời điểm biên dịch.