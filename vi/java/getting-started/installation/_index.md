---
title: Cài đặt
type: docs
weight: 70
url: /vi/java/installation/
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
- bản trình chiếu
- Java
- Aspose.Slides
description: "Cài đặt Aspose.Slides cho Java từ kho Maven của Aspose hoặc dưới dạng tệp JAR, thiết lập các yêu cầu trước cho Linux, và kiểm tra cài đặt bằng chương trình đầu tiên."
---
## **Tổng quan**

Bài viết này giải thích cách thêm Aspose.Slides for Java vào một dự án. Aspose.Slides for Java được phát hành trong kho Maven riêng của Aspose, không phải trong Maven Central, vì vậy một dự án Maven phải khai báo kho đó. Bạn cũng có thể tải tệp JAR về và tự đặt nó vào class path. Cả hai cách đều kết thúc bằng một chương trình ngắn xác nhận thư viện hoạt động.

Aspose.Slides for Java không yêu cầu Microsoft PowerPoint. Nó tạo ra các tệp trình chiếu cần thiết một cách lập trình. Tuy nhiên, để xem các trình chiếu được tạo, bạn có thể cần Microsoft PowerPoint hoặc một trình xem trình chiếu khác.

## **Yêu cầu trước**

- Một Java Development Kit (JDK). Dự án và các lệnh trong bài viết này cần JDK 11 hoặc mới hơn. Trên JDK 11, chương trình kiểm tra cài đặt sẽ in ra cảnh báo bắt đầu bằng “WARNING: An illegal reflective access operation has occurred”; cảnh báo này không ảnh hưởng đến kết quả và có thể bỏ qua.
- [Apache Maven](https://maven.apache.org/install.html), nếu bạn dùng cách Maven.
- Trên Linux, thư viện fontconfig và ít nhất một phông chữ đã được cài đặt. Xem [Linux](#linux).

## **Cài đặt từ Maven Repository**

Aspose lưu trữ các thư viện Java của mình trong [kho Maven](https://releases.aspose.com/java/repo/com/aspose/) riêng. Để sử dụng [Aspose.Slides for Java](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) trong một dự án Maven, thêm hai mục vào *pom.xml* của bạn.

1. **Khai báo kho Maven của Aspose.**

   ```xml
   <repositories>
       <repository>
           <id>AsposeJavaAPI</id>
           <name>Aspose Java API</name>
           <url>https://releases.aspose.com/java/repo/</url>
       </repository>
   </repositories>
   ```

2. **Thêm phụ thuộc Aspose.Slides for Java.**

   ```xml
   <dependencies>
       <dependency>
           <groupId>com.aspose</groupId>
           <artifactId>aspose-slides</artifactId>
           <version>26.10</version>
           <classifier>jdk8</classifier>
       </dependency>
   </dependencies>
   ```

Phân loại `jdk8` là bắt buộc: nó chọn bản dựng Java SE của thư viện. Thay `26.10` bằng phiên bản mới nhất được liệt kê trong [kho lưu trữ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Kho lưu trữ công bố một tệp checksum SHA-1 bên cạnh mỗi JAR, mà Maven sẽ kiểm tra khi tải về thư viện.

### **Kiểm tra cài đặt**

Để kiểm tra thiết lập với một dự án mới:

1. Tạo một thư mục cho dự án và lưu *pom.xml* này vào đó:

   ```xml
   <project xmlns="http://maven.apache.org/POM/4.0.0">
       <modelVersion>4.0.0</modelVersion>
       <groupId>com.example</groupId>
       <artifactId>hello-slides</artifactId>
       <version>1.0</version>

       <properties>
           <maven.compiler.release>11</maven.compiler.release>
           <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
           <exec.mainClass>HelloSlides</exec.mainClass>
       </properties>

       <repositories>
           <repository>
               <id>AsposeJavaAPI</id>
               <name>Aspose Java API</name>
               <url>https://releases.aspose.com/java/repo/</url>
           </repository>
       </repositories>

       <dependencies>
           <dependency>
               <groupId>com.aspose</groupId>
               <artifactId>aspose-slides</artifactId>
               <version>26.10</version>
               <classifier>jdk8</classifier>
           </dependency>
       </dependencies>

       <build>
           <plugins>
               <plugin>
                   <groupId>org.apache.maven.plugins</groupId>
                   <artifactId>maven-compiler-plugin</artifactId>
                   <version>3.15.0</version>
               </plugin>
           </plugins>
       </build>
   </project>
   ```

   Ngoài kho và phụ thuộc, *pom.xml* này đặt phiên bản Java để biên dịch, xác định lớp mà `mvn exec:java` sẽ chạy, và cố định plugin biên dịch, vì plugin cũ mà một số cài đặt Maven sử dụng mặc định sẽ bỏ qua thiết lập `maven.compiler.release`.

2. Lưu ví dụ đầu tiên trong [Tạo Bản Trình Chiếu](/slides/vi/java/create-presentation/) dưới dạng *src/main/java/HelloSlides.java*.

3. Trong thư mục dự án, chạy:

   ```bash
   mvn compile exec:java
   ```

Maven sẽ tải Aspose.Slides for Java, biên dịch chương trình và chạy nó. Chương trình sẽ lưu *new_presentation.pptx* trong thư mục dự án.

## **Sử dụng tệp JAR mà không cần Maven**

1. Tải *aspose-slides-26.10-jdk8.jar* từ [thư mục phiên bản](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.10/) trong kho. Đối với phiên bản khác, mở thư mục của nó trong [kho lưu trữ](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) và tải tệp có hậu tố *-jdk8.jar*.
2. Lưu ví dụ đầu tiên trong [Tạo Bản Trình Chiếu](/slides/vi/java/create-presentation/) dưới dạng *HelloSlides.java* trong cùng thư mục với tệp JAR.
3. Trong thư mục đó, chạy:

   ```bash
   java -cp aspose-slides-26.10-jdk8.jar HelloSlides.java
   ```

JDK sẽ biên dịch và chạy tệp nguồn duy nhất, và chương trình sẽ lưu *new_presentation.pptx* trong thư mục. Trong ứng dụng của bạn, thêm tệp JAR vào class path trong công cụ build hoặc IDE bạn dùng.

## **Linux**

Aspose.Slides for Java sử dụng hỗ trợ phông chữ của Java, trên Linux cần thư viện fontconfig và ít nhất một phông chữ đã được cài đặt. Nếu không có, việc lưu trình chiếu sẽ thất bại với lỗi “Fontconfig head is null, check your fonts or fonts configuration”. Các hình ảnh máy chủ và container tối thiểu có thể thiếu cả hai; ví dụ, image container Ubuntu chính thức không có bất kỳ thứ nào trong số này.

Trên Debian và Ubuntu, lệnh sau sẽ cài đặt JDK, Maven, fontconfig và các phông chữ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Các phông chữ được dùng trong các trình chiếu của bạn, hoặc các phông thay thế phù hợp, cũng phải được cài đặt để văn bản được hiển thị đúng.

## **Câu hỏi thường gặp**

### Làm thế nào để xác minh rằng Aspose.Slides đã được tích hợp đúng cách?

Biên dịch dự án, tạo một đối tượng [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) trống và lưu nó dưới một tên mới. Nếu tệp được tạo mà không ném ngoại lệ, thư viện đã được tích hợp thành công.

### Làm thế nào để giới hạn tiêu thụ bộ nhớ khi xử lý các trình chiếu lớn?

Tăng giới hạn bộ nhớ JVM chỉ lên mức cần thiết, và gọi [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) trên mỗi đối tượng [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) trong khối `finally` để giải phóng bộ nhớ đệm kịp thời. Điều này ngăn lỗi thiếu bộ nhớ và giữ mức sử dụng bộ nhớ tổng thể dự đoán được trong các thao tác batch.

### Tôi có thể loại bỏ các định dạng xuất không cần thiết để giảm kích thước JAR cuối cùng không?

Các phiên bản hiện tại của Aspose.Slides được phát hành dưới dạng một thư viện đơn, vì vậy bạn không thể tắt các bộ xuất cụ thể như PDF hoặc SVG tại thời điểm biên dịch.