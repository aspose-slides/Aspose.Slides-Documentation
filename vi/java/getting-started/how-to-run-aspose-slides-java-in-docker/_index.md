---
title: Chạy Aspose.Slides cho Java trong Docker
linktitle: Docker
type: docs
weight: 150
url: /vi/java/how-to-run-aspose-slides-in-docker/
keywords:
- Docker
- Dockerfile
- container Docker
- xây dựng đa giai đoạn
- image container
- Eclipse Temurin
- Maven
- Linux
- Ubuntu
- Alpine
- Debian
- fontconfig
- phông chữ
- chuyển đổi PDF
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Xây dựng và chạy một ứng dụng Aspose.Slides cho Java trong Docker: Dockerfile đa giai đoạn trên các image chính thức của Maven và Eclipse Temurin, các thư viện Linux và phông chữ mà Aspose.Slides yêu cầu, và cách sao chép các tệp đã tạo về máy của bạn."
---
## **Tổng quan**

Bài viết này chỉ cách chạy Aspose.Slides for Java trong một container Docker. Bạn sẽ xây dựng một dự án Maven nhỏ tạo một bản trình bày có hộp văn bản và chuyển đổi nó sang PDF, đóng gói bằng Dockerfile đa giai đoạn trên các hình ảnh chính thức của Maven và Eclipse Temurin, chạy nó, và sao chép các tệp đã tạo về máy của bạn. Bài viết cũng giải thích Aspose.Slides cần gì trong một image Linux ngoài Java, và kết thúc bằng các biến thể cho Alpine Linux và cho các image cài Java từ các gói của bản phân phối.

Bạn chỉ cần Docker trên máy. JDK và Maven đã có trong image xây dựng, vì vậy bạn không phải cài chúng. Để cài Docker, xem [Lấy Docker](https://docs.docker.com/get-started/get-docker/).

## **Chọn hình ảnh cơ sở**

Dockerfile trong bài này sử dụng hai image chính thức từ Docker Hub:

- [maven](https://hub.docker.com/_/maven) với thẻ `3.9-eclipse-temurin-21` để biên dịch ứng dụng. Nó chứa Apache Maven 3.9 và Eclipse Temurin JDK 21.
- [eclipse-temurin](https://hub.docker.com/_/eclipse-temurin) với thẻ `21-jre` để chạy ứng dụng. Nó chứa runtime Eclipse Temurin Java 21 trên Ubuntu, không có JDK và Maven.

Aspose.Slides for Java vẽ văn bản bằng hỗ trợ phông chữ của Java, trên Linux cần các thư viện fontconfig và FreeType và ít nhất một phông chữ được cài đặt. Các image Eclipse Temurin đã có sẵn fontconfig, FreeType và các phông DejaVu, vì vậy Dockerfile trong bài này không cài thêm gói nào. Trong một image không có phông nào, việc lưu bản trình bày sẽ dừng với lỗi “Fontconfig head is null, check your fonts or fonts configuration”. Nếu bạn xây dựng trên một base image khác, xem [Sử dụng hình ảnh cơ sở khác](#use-another-base-image).

## **Tạo dự án**

Tạo một thư mục có tên *hello-slides-docker* và thêm các tệp sau vào đó.

*pom.xml* khai báo kho Maven của Aspose và phụ thuộc Aspose.Slides for Java, như mô tả trong [Cài đặt](/slides/vi/java/installation/); Aspose.Slides for Java không được công bố trên Maven Central, vì vậy mục kho là bắt buộc. Thành phần `finalName` đặt tên tệp JAR của ứng dụng thành *hello-slides.jar*, và [maven-dependency-plugin](https://maven.apache.org/plugins/maven-dependency-plugin/) sao chép các phụ thuộc của ứng dụng vào *target/lib* khi Maven đóng gói. Đặt phiên bản Aspose.Slides thành phiên bản mới nhất được liệt kê trong [kho](https://releases.aspose.com/java/repo/com/aspose/aspose-slides/).

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>hello-slides</artifactId>
    <version>1.0</version>

    <properties>
        <maven.compiler.release>11</maven.compiler.release>
        <project.build.sourceEncoding>UTF-8</project.build.sourceEncoding>
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
        <finalName>hello-slides</finalName>
        <plugins>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-compiler-plugin</artifactId>
                <version>3.15.0</version>
            </plugin>
            <plugin>
                <groupId>org.apache.maven.plugins</groupId>
                <artifactId>maven-dependency-plugin</artifactId>
                <version>3.11.0</version>
                <executions>
                    <execution>
                        <phase>package</phase>
                        <goals>
                            <goal>copy-dependencies</goal>
                        </goals>
                        <configuration>
                            <outputDirectory>${project.build.directory}/lib</outputDirectory>
                        </configuration>
                    </execution>
                </executions>
            </plugin>
        </plugins>
    </build>
</project>
```

*src/main/java/HelloSlides.java* tạo một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), thêm một hình chữ nhật chứa văn bản vào slide đầu tiên, và lưu bản trình bày hai lần bằng phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-): dưới dạng PPTX và PDF. Cả hai tệp đều được lưu vào thư mục *output* trong thư mục làm việc. Chương trình sau đó liệt kê các phông chữ mà Aspose.Slides thay thế khi render bản trình bày, bằng cách gọi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--), để bạn có thể thấy container có những phông nào mà bản trình bày sử dụng.

```java
import com.aspose.slides.*;
import java.io.File;

public class HelloSlides {
    public static void main(String[] args) {
        File outputFolder = new File("output");
        outputFolder.mkdirs();

        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello from a Docker container!");

            String pptxPath = new File(outputFolder, "hello.pptx").getPath();
            String pdfPath = new File(outputFolder, "hello.pdf").getPath();
            presentation.save(pptxPath, SaveFormat.Pptx);
            presentation.save(pdfPath, SaveFormat.Pdf);

            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                System.out.println("Font substitution: " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
            }

            System.out.println("Saved " + pptxPath + " and " + pdfPath);
        } finally {
            presentation.dispose();
        }
    }
}
```

*.dockerignore* giữ thư mục *target* của bản dựng cục bộ và các đầu ra của các lần chạy trước, tránh chúng xuất hiện trong ngữ cảnh xây dựng Docker, vì vậy image chỉ được xây dựng từ các tệp nguồn.

```text
target/
output/
```

## **Viết Dockerfile**

Thêm một tệp có tên *Dockerfile* vào thư mục *hello-slides-docker*:

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Tệp có hai giai đoạn:

- **Giai đoạn xây dựng** bắt đầu từ image Maven. Nó sao chép *pom.xml* trước và chạy `mvn dependency:go-offline`, tải về Aspose.Slides for Java và các plugin Maven, vì vậy Docker sẽ tái sử dụng lớp này miễn là *pom.xml* không thay đổi. Sau đó sao chép mã nguồn và chạy `mvn package`, biên dịch chương trình thành *target/hello-slides.jar* và sao chép tệp JAR Aspose.Slides vào *target/lib*. Tuỳ chọn `-B` chạy Maven ở chế độ không tương tác (batch).
- **Giai đoạn runtime** bắt đầu từ image runtime Java nhỏ hơn và chỉ sao chép tệp JAR của ứng dụng và thư mục *lib*. Nó tạo thư mục *output*, cấp quyền cho người dùng `ubuntu` (người dùng không phải root mà image dựa trên Ubuntu định nghĩa), và chạy ứng dụng dưới người dùng đó. Đường classpath `hello-slides.jar:lib/*` chứa ứng dụng và mọi tệp JAR trong *lib*; Java tự mở rộng `*`.

Dự án được biên dịch cho Java 11 (thuộc tính `maven.compiler.release`), vì vậy giai đoạn runtime có thể dùng một phiên bản Java mới hơn. Ví dụ, để chạy ứng dụng trên Java 25, thay đổi image của giai đoạn runtime thành `eclipse-temurin:25-jre`.

## **Xây dựng và chạy container**

Mở terminal trong thư mục *hello-slides-docker*. Xây dựng image, sau đó chạy một container từ nó:

```bash
docker build -t hello-slides .
docker run --name hello-slides-run hello-slides
```

Lần xây dựng đầu tiên tải các image cơ sở, các plugin Maven và Aspose.Slides for Java, vì vậy mất vài phút; các lần sau tái sử dụng chúng. Container chạy ứng dụng và dừng lại. Nó in ra:

```text
Font substitution: Calibri -> DejaVu Sans
Saved output/hello.pptx and output/hello.pdf
```

Dòng đầu tiên cho thấy văn bản sử dụng phông Calibri, phông mặc định của một bản trình bày mới, và Calibri không được cài trong image, vì vậy Aspose.Slides đã vẽ văn bản bằng DejaVu Sans. Văn bản trong PDF là chữ thực, có thể chọn được với phông đó. Nếu không có giấy phép, Aspose.Slides cũng sẽ thêm một watermark đánh giá vào mọi slide được lưu; xem [Cấp phép](/slides/vi/java/licensing/).

## **Sao chép đầu ra về máy của bạn**

Các tệp nằm trong thư mục */app/output* của container đã dừng. Sao chép chúng vào một thư mục *output* trên máy của bạn, sau đó xóa container:

```bash
docker cp hello-slides-run:/app/output/. ./output
docker rm hello-slides-run
```

Hai lệnh này hoạt động tương tự trong Bash, PowerShell và Windows Command Prompt.

Trên Linux, bạn có thể gắn một thư mục trên máy vào container, để ứng dụng ghi trực tiếp vào đó:

```bash
mkdir -p output
docker run --rm --user "$(id -u):$(id -g)" -v "$(pwd)/output:/app/output" hello-slides
```

Tuỳ chọn `--user` chạy ứng dụng với UID và GID của bạn, vì vậy nó có thể ghi vào thư mục bạn tạo và các tệp sẽ thuộc về bạn. `--rm` xóa container khi nó dừng.

## **Chạy trên Alpine Linux**

Eclipse Temurin cũng có sẵn dưới dạng image dựa trên Alpine Linux, nhẹ hơn. Nó cũng chứa fontconfig, FreeType và các phông DejaVu, vì vậy ứng dụng không cần gói bổ sung nào ở đây. Để sử dụng, thay thế giai đoạn runtime trong *Dockerfile* (từ dòng `FROM` thứ hai trở đi) bằng:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Image Alpine không có người dùng `ubuntu`, vì vậy giai đoạn này tạo người dùng `app` bằng `adduser` và chạy ứng dụng dưới người dùng đó. Xây dựng, chạy và sao chép đầu ra bằng các lệnh như trên. Ứng dụng in ra hai dòng giống nhau.

## **Sử dụng hình ảnh cơ sở khác**

Nếu image của bạn cài Java từ các gói của bản phân phối Linux, hãy cài thêm các thư viện phông chữ của Java và một phông chữ. Trên Debian và Ubuntu, gói `openjdk-21-jre-headless` liệt kê fontconfig, FreeType và HarfBuzz chỉ là các gói đề nghị, vì vậy `apt-get install --no-install-recommends` sẽ bỏ chúng, và ứng dụng dừng với `UnsatisfiedLinkError` cho `libfontmanager.so`. Giai đoạn runtime này cài Java 21, các thư viện và phông DejaVu trên Debian 13, và tạo người dùng không root tên `app`:

```dockerfile
FROM debian:trixie
RUN apt-get update \
    && apt-get install -y --no-install-recommends openjdk-21-jre-headless libfontconfig1 libfreetype6 libharfbuzz0b fonts-dejavu-core \
    && rm -rf /var/lib/apt/lists/*
WORKDIR /app
COPY --from=build /src/target/hello-slides.jar .
COPY --from=build /src/target/lib ./lib
RUN useradd --create-home app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "hello-slides.jar:lib/*", "HelloSlides"]
```

Cùng giai đoạn này cũng hoạt động trên Ubuntu 26.04 với `FROM ubuntu:26.04`.

## **Câu hỏi thường gặp**

**Lưu bản trình bày dừng lại với “Fontconfig head is null, check your fonts or fonts configuration”. Thiếu gì?**

Thiếu phông chữ. Hỗ trợ phông chữ của Java không tìm thấy phông nào được cài trong image. Cài một gói phông, ví dụ `fonts-dejavu-core` trên Debian và Ubuntu, như trong [Sử dụng hình ảnh cơ sở khác](#use-another-base-image). [Triển khai phông](/slides/vi/java/deploy-fonts/) liệt kê các gói phông khác.

**Ứng dụng dừng với UnsatisfiedLinkError cho libfontmanager.so. Thiếu gì?**

Thiếu thư viện gốc của hỗ trợ phông chữ Java; thông báo chỉ ra tệp không thể tải, ví dụ `libharfbuzz.so.0`. Điều này xảy ra khi Java được cài từ các gói của bản phân phối mà không có các gói đề nghị. Cài các thư viện được liệt kê trong [Sử dụng hình ảnh cơ sở khác](#use-another-base-image).

**Tại sao văn bản trong PDF có phông khác với PowerPoint?**

Các phông chữ mà bản trình bày sử dụng không được cài trong image, vì vậy Aspose.Slides vẽ chúng bằng phông thay thế. Đầu ra của ứng dụng liệt kê mỗi phông đã được thay thế. [Triển khai phông](/slides/vi/java/deploy-fonts/) giải thích cách cài phông trong image hoặc tải chúng từ thư mục ứng dụng.

**Ứng dụng có thể dùng bao nhiêu bộ nhớ trong container?**

Mặc định, Java giới hạn heap ở một phần tư bộ nhớ của container, ví dụ khoảng 250 MB khi bạn khởi chạy container với `docker run -m 1g`. Để xử lý các bản trình bày lớn, tăng tỷ lệ chia sẻ bằng tuỳ chọn `MaxRAMPercentage`, ví dụ `docker run --rm -m 1g -e JAVA_TOOL_OPTIONS=-XX:MaxRAMPercentage=75 hello-slides`. Java sẽ in dòng “Picked up JAVA_TOOL_OPTIONS” trước khi hiển thị đầu ra của ứng dụng.

**Tôi có cần JDK hoặc Maven trên máy không?**

Không. Giai đoạn build biên dịch ứng dụng trong image Maven. Bạn chỉ cần JDK và Maven nếu muốn xây dựng và chạy ứng dụng ngoài Docker; xem [Cài đặt](/slides/vi/java/installation/).