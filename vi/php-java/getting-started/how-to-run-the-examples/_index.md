---
title: Cách chạy các ví dụ
type: docs
weight: 140
url: /vi/php-java/how-to-run-the-examples/
keywords:
- ví dụ
- yêu cầu phần mềm
- GitHub
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Chạy nhanh các ví dụ Aspose.Slides cho PHP qua Java: sao chép repo, khôi phục gói, sau đó biên dịch và kiểm thử các tính năng cho PPT, PPTX và ODP."
---
## **Tải xuống từ GitHub**
Tất cả các ví dụ của Aspose.Slides cho PHP qua Java được lưu trữ trên [Github](https://github.com/aspose-slides/Aspose.Slides-for-Java). Bạn có thể sao chép kho lưu trữ bằng client Github yêu thích hoặc tải tệp ZIP từ [here](https://codeload.github.com/aspose-slides/Aspose.Slides-for-Java/zip/master).

Giải nén nội dung của tệp ZIP vào bất kỳ thư mục nào trên máy tính của bạn. Tất cả các ví dụ nằm trong thư mục **Examples**.

![todo:image_alt_text](examples_directory.png)

## **Nhập các ví dụ vào IDE**
Dự án sử dụng hệ thống xây dựng Maven. Bất kỳ IDE hiện đại nào cũng có thể dễ dàng mở hoặc nhập dự án và các phụ thuộc của nó. Dưới đây chúng tôi trình bày cách sử dụng các IDE phổ biến để biên dịch và chạy các ví dụ.

### **IntelliJ IDEA**
Nhấn vào menu **File** và chọn **Open**. Duyệt tới thư mục dự án và chọn tệp **pom.xml**.

![todo:image_alt_text](idea_select_file_or_directory_to_import.png)

IDE sẽ mở dự án và tự động tải các phụ thuộc. Từ thẻ Project, duyệt các ví dụ trong thư mục **src/main/java**. Để chạy một ví dụ, chỉ cần nhấp chuột phải vào tệp và chọn “Run …”, ví dụ sẽ được thực thi và kết quả sẽ hiển thị trong cửa sổ console tích hợp.

![todo:image_alt_text](idea_run_example.png)

### **Eclipse**
Nhấn vào menu **File** và chọn **Import**. Chọn **Maven** - Existing Maven Projects.

![todo:image_alt_text](eclipse_import.png)

Duyệt tới thư mục bạn đã sao chép hoặc tải về từ GitHub và chọn tệp **pom.xml**. IDE sẽ mở dự án và tự động tải các phụ thuộc. Từ thẻ Package Explorer, duyệt các ví dụ trong thư mục **src/main/java**. Để chạy một ví dụ, chỉ cần nhấp chuột phải vào tệp và chọn **Run As** - **Java Application**, ví dụ sẽ được thực thi và kết quả sẽ hiển thị trong cửa sổ console tích hợp.

![todo:image_alt_text](eclipse_run_example.png)

### **NetBeans**
Nhấn vào menu **File** và chọn **Open Project**. Duyệt tới thư mục bạn đã sao chép hoặc tải về từ GitHub. Biểu tượng của thư mục **Examples** sẽ cho thấy đây là một dự án Maven. Chọn **Examples** và mở nó.

![todo:image_alt_text](netbeans_openproject.png)

IDE sẽ mở dự án và tự động tải các phụ thuộc. Từ thẻ Projects, duyệt các ví dụ trong **source packages**. Để chạy một ví dụ, chỉ cần nhấp chuột phải vào tệp và chọn **Run File**, ví dụ sẽ được thực thi và kết quả sẽ hiển thị trong cửa sổ console tích hợp.

![todo:image_alt_text](netbeans_run_example.png)

## **Thêm thư viện Aspose.Slides vào Maven Local Repository**
Khi bạn nhập dự án **Aspose.Slides Examples** vào IDE, Maven sẽ tự động tải tệp JAR aspose.slides từ [Aspose Maven Repository](https://releases.aspose.com/php-java/repo/com/aspose/). Trong trường hợp bạn không có kết nối internet, bạn có thể thêm tệp JAR vào kho lưu trữ cục bộ thủ công.

### **mvn install**
Tải xuống [aspose.slides](https://releases.aspose.com/php-java/repo/com/aspose/aspose-slides/), giải nén và sao chép tệp aspose.slides‑version.jar vào một vị trí nào đó, ví dụ ổ C. Thực thi lệnh sau:

```php

```
mvn install:install-file
    - Dfile=c:\aspose.slides-version.jar
    - DgroupId=com.aspose
    - DartifactId=aspose-slides
    - Dversion={version}
    - Dpackaging=jar
```php

```

Bây giờ, tệp **aspose.slides** đã được sao chép vào Maven local repository của bạn.

### **pom.xml**
Sau khi cài đặt, chỉ cần khai báo tọa độ **aspose.slides** trong pom.xml. Thêm repository sau vào thẻ repositories và dependency vào thẻ dependencies.

``` xml
<repository>
    <id>aspose-maven-repository</id>
    <url>http://repository.aspose.com/repo/</url>
</repository>

<dependency>
    <groupId>com.aspose</groupId>
    <artifactId>aspose-slides</artifactId>
    <version>18.6</version>
    <classifier>jdk16</classifier>
</dependency>
```php

### **Done**
Biên dịch, bây giờ tệp **aspose.slides** có thể được lấy từ Maven local repository của bạn.

## **Cộng tác**
Nếu bạn muốn thêm hoặc cải thiện một ví dụ, chúng tôi khuyến khích bạn đóng góp cho dự án. Tất cả các ví dụ và dự án showcase trong kho này là mã nguồn mở và có thể được sử dụng tự do trong các ứng dụng của bạn.

Để đóng góp, bạn có thể fork kho lưu trữ, chỉnh sửa mã nguồn và gửi Pull Request. Chúng tôi sẽ xem xét các thay đổi và đưa chúng vào kho nếu thấy hữu ích.