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
description: "Cài đặt Aspose.Slides cho Java từ kho Maven của Aspose hoặc dưới dạng tệp JAR, thiết lập các yêu cầu trước cho Linux, và kiểm tra việc cài đặt bằng một chương trình đầu tiên."
---
## **Tổng quan**

Bài viết này giải thích cách thêm Aspose.Slides for Java vào một dự án. Aspose.Slides for Java được phát hành trong kho Maven riêng của Aspose, không phải trên Maven Central, vì vậy một dự án Maven phải khai báo kho đó. Bạn cũng có thể tải xuống tệp JAR và đặt nó vào classpath của mình. Cả hai cách đều kết thúc bằng một chương trình ngắn để xác nhận thư viện hoạt động.

Aspose.Slides for Java không yêu cầu Microsoft PowerPoint. Nó tạo ra các tệp trình chiếu cần thiết một cách lập trình. Tuy nhiên, để xem các trình chiếu được tạo, bạn có thể cần Microsoft PowerPoint hoặc một trình xem trình chiếu khác.

## **Yêu cầu trước**

- Một Java Development Kit (JDK). Dự án và các lệnh trong bài viết này cần JDK 11 trở lên. Trên JDK 11, chương trình kiểm tra cài đặt sẽ in ra cảnh báo bắt đầu bằng "WARNING: An illegal reflective access operation has occurred"; nó không ảnh hưởng đến kết quả và có thể bỏ qua.
- [Apache Maven](https://maven.apache.org/install.html), nếu bạn sử dụng cách Maven.
- Trên Linux, thư viện fontconfig và ít nhất một phông chữ đã được cài đặt. Xem [Linux](#linux).

## **Cài đặt từ kho Maven**

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
           <version>26.9</version>
           <classifier>jdk16</classifier>
       </dependency>
   </dependencies>
   ```

Phân loại `jdk16` là bắt buộc: nó chọn bản dựng Java SE của thư viện. Thay thế `26.9` bằng phiên bản mới nhất được liệt kê trong [kho](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/). Kho sẽ xuất bản một tệp kiểm tra SHA-1 bên cạnh mỗi JAR, mà Maven sẽ kiểm tra khi tải thư viện.

### **Kiểm tra cài đặt**

Để kiểm tra cấu hình với một dự án mới:

1. Tạo một thư mục cho dự án và lưu *pom.xml* này vào trong đó:

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
               <version>26.9</version>
               <classifier>jdk16</classifier>
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

   Ngoài kho và phụ thuộc, *pom.xml* này thiết lập phiên bản Java để biên dịch, đặt tên lớp mà `mvn exec:java` chạy, và cố định plugin biên dịch, vì plugin cũ mà một số cài đặt Maven sử dụng mặc định sẽ bỏ qua thiết lập `maven.compiler.release`.

2. Lưu ví dụ đầu tiên trong [Create Presentations](/slides/vi/java/create-presentation/) dưới dạng *src/main/java/HelloSlides.java*.

3. Trong thư mục dự án, chạy:

   ```bash
   mvn compile exec:java
   ```

Maven tải xuống Aspose.Slides for Java, biên dịch chương trình và chạy nó. Chương trình lưu *new_presentation.pptx* trong thư mục dự án.

## **Sử dụng tệp JAR mà không cần Maven**

1. Tải xuống *aspose-slides-26.9-jdk16.jar* từ [thư mục phiên bản](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/26.9/) trong kho. Đối với phiên bản khác, mở thư mục của nó trong [kho](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/) và tải về tệp có hậu tố *-jdk16.jar*.
2. Lưu ví dụ đầu tiên trong [Create Presentations](/slides/vi/java/create-presentation/) dưới dạng *HelloSlides.java* trong cùng thư mục với tệp JAR.
3. Trong thư mục đó, chạy:

   ```bash
   java -cp aspose-slides-26.9-jdk16.jar HelloSlides.java
   ```

JDK sẽ biên dịch và chạy tệp nguồn duy nhất, và chương trình sẽ lưu *new_presentation.pptx* trong thư mục. Trong ứng dụng của bạn, thêm tệp JAR vào classpath trong công cụ xây dựng hoặc IDE của bạn.

## **Linux**

Aspose.Slides for Java sử dụng hỗ trợ phông chữ của Java, trên Linux cần thư viện fontconfig và ít nhất một phông chữ đã được cài đặt. Nếu không có chúng, việc lưu trình chiếu sẽ thất bại với lỗi "Fontconfig head is null, check your fonts or fonts configuration". Các hình ảnh máy chủ và container tối thiểu có thể thiếu cả hai; ví dụ, hình ảnh container Ubuntu chính thức không có bất kỳ thứ nào.

Trên Debian và Ubuntu, lệnh này cài đặt JDK, Maven, fontconfig và phông chữ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y default-jdk maven fontconfig fonts-dejavu-core
```

Các phông chữ được sử dụng trong trình chiếu của bạn, hoặc các sự thay thế phù hợp, cũng phải được cài đặt để văn bản hiển thị đúng.

## **FAQ**

### Làm sao tôi có thể xác minh rằng Aspose.Slides đã được tích hợp đúng?

Xây dựng dự án của bạn, tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) trống và lưu nó với một tên mới. Nếu tệp được tạo mà không ném ngoại lệ, thư viện đã được tích hợp thành công.

### Làm sao tôi có thể giới hạn việc tiêu thụ bộ nhớ khi xử lý các trình chiếu lớn?

Tăng giới hạn bộ nhớ JVM chỉ lên mức cần thiết, và gọi [dispose](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#dispose--) trên mỗi đối tượng [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) trong một khối `finally` để giải phóng bộ nhớ đệm kịp thời. Điều này ngăn lỗi hết bộ nhớ và giữ cho việc sử dụng bộ nhớ tổng thể dự đoán được trong các hoạt động batch.

### Tôi có thể loại bỏ các định dạng xuất không mong muốn để giảm kích thước JAR cuối cùng không?

Các phiên bản hiện tại của Aspose.Slides được phát hành dưới dạng một thư viện đơn lẻ, vì vậy bạn không thể tắt các trình xuất cụ thể như PDF hoặc SVG trong quá trình xây dựng.