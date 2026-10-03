---
title: Triển khai phông chữ cho Aspose.Slides cho Java trên Linux và trong Docker
linktitle: Triển khai Phông chữ
type: docs
weight: 155
url: /vi/java/deploy-fonts/
keywords:
- triển khai phông chữ
- cài đặt phông chữ
- phông chữ trong Docker
- phông chữ trên Linux
- phông chữ thiếu
- thay thế phông chữ
- phông chữ core của Microsoft
- ttf-mscorefonts-installer
- phông chữ tùy chỉnh
- phông chữ mặc định
- máy chủ
- container
- chuyển đổi PDF
- bản trình chiếu
- Java
- Aspose.Slides
description: "Triển khai phông chữ cho Aspose.Slides cho Java trên máy chủ Linux và trong các container Docker: kiểm tra các phông chữ nào bị thay thế, cài đặt các gói phông chữ trên Debian, Ubuntu và Alpine, thêm các tệp phông chữ của bạn, và đặt một phông chữ mặc định."
---
## **Tổng quan**

Aspose.Slides vẽ văn bản bằng các phông chữ có sẵn khi nó render một bản trình chiếu, ví dụ khi chuyển đổi các slide sang PDF hoặc hình ảnh. Một máy tính để bàn Windows thường có các phông chữ mà bản trình chiếu sử dụng. Các máy chủ và container Linux thường có ít phông chữ, vì vậy Aspose.Slides vẽ văn bản bằng một phông chữ thay thế. Phông chữ thay thế có hình dạng và độ rộng ký tự khác nhau, vì vậy các dòng có thể ngắt khác nhau và văn bản có thể tràn ra khỏi hình dạng của nó, và các ký tự mà phông chữ thay thế không có sẽ không được vẽ đúng. Nếu không có phông chữ nào được cài đặt, hỗ trợ phông chữ của Java không thể khởi động và Aspose.Slides dừng với lỗi.

Bài viết này mô tả cách kiểm tra những phông chữ nào Aspose.Slides thay thế, cách cài đặt phông chữ trên Debian, Ubuntu và Alpine Linux, cách thêm các tệp phông chữ của bạn, và cách đặt phông chữ được sử dụng khi một phông chữ bị thiếu. Các ví dụ chạy trong Docker trên các image chính thức của Eclipse Temurin, như trong [Chạy Aspose.Slides cho Java trong Docker](/slides/vi/java/how-to-run-aspose-slides-in-docker/). Các lệnh gói là các chỉ thị Dockerfile; trên một máy chủ Linux, chạy các lệnh này với quyền root.

Đối với API phông chữ, chẳng hạn như nhúng phông chữ trong một bản trình chiếu và các quy tắc dự phòng và thay thế, xem [Phông chữ PowerPoint](/slides/vi/java/powerpoint-fonts/).

## **Kiểm tra các phông chữ nào bị thay thế**

Dự án Maven sau đây báo cáo các phông chữ mà Aspose.Slides thay thế trong môi trường hiện tại. Tạo một thư mục có tên *font-check* và thêm các tệp bên dưới vào đó.

*pom.xml* là tệp từ [Chạy Aspose.Slides cho Java trong Docker](/slides/vi/java/how-to-run-aspose-slides-in-docker/#create-the-project), với ID artifact và tên tệp JAR được đổi thành *font-check*:

```xml
<project xmlns="http://maven.apache.org/POM/4.0.0">
    <modelVersion>4.0.0</modelVersion>
    <groupId>com.example</groupId>
    <artifactId>font-check</artifactId>
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
        <finalName>font-check</finalName>
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

*src/main/java/FontCheck.java* thêm một hộp văn bản cho mỗi tên phông chữ vào một slide và gán phông chữ bằng phương thức [setLatinFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setLatinFont-com.aspose.slides.IFontData-). Các tên phông chữ được lấy từ dòng lệnh; nếu không có đối số, chương trình sẽ kiểm tra Calibri, Arial và Times New Roman. Nó in ra các thư mục mà Aspose.Slides tìm kiếm phông chữ ([FontsLoader.getFontFolders](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#getFontFolders--)), render slide thành *output/fonts.pdf*, và in ra các phông chữ thay thế được báo cáo bởi [IFontsManager.getSubstitutions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ifontsmanager/#getSubstitutions--). Hai bước tùy chọn ở đầu, tải một thư mục *fonts* và đọc biến `DEFAULT_FONT`, được giải thích ở phần sau của bài viết.

```java
import com.aspose.slides.*;
import java.io.File;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;

public class FontCheck {
    public static void main(String[] args) {
        // Các phông chữ cần kiểm tra: các đối số dòng lệnh, hoặc ba phông chữ Office phổ biến.
        String[] fontNames = args.length > 0 ? args : new String[] { "Calibri", "Arial", "Times New Roman" };

        // Tải các tệp phông chữ từ thư mục fonts trong thư mục làm việc, nếu có.
        File appFontFolder = new File("fonts");
        if (appFontFolder.isDirectory()) {
            FontsLoader.loadExternalFonts(new String[] { appFontFolder.getAbsolutePath() });
        }

        // Sử dụng phông chữ được chỉ định trong biến môi trường DEFAULT_FONT, nếu được đặt, cho văn bản thiếu phông chữ.
        LoadOptions loadOptions = new LoadOptions();
        String defaultFont = System.getenv("DEFAULT_FONT");
        if (defaultFont != null && !defaultFont.isEmpty()) {
            loadOptions.setDefaultRegularFont(defaultFont);
        }

        Set<String> fontFolders = new LinkedHashSet<>(Arrays.asList(FontsLoader.getFontFolders()));
        System.out.println("Font folders: " + String.join(", ", fontFolders));

        Presentation presentation = new Presentation(loadOptions);
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            for (int i = 0; i < fontNames.length; i++) {
                IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50 + i * 80, 600, 60);
                shape.getTextFrame().setText("This text is set in " + fontNames[i] + ".");
                shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setLatinFont(new FontData(fontNames[i]));
            }

            File outputFolder = new File("output");
            outputFolder.mkdirs();
            presentation.save(new File(outputFolder, "fonts.pdf").getPath(), SaveFormat.Pdf);

            List<FontSubstitutionInfo> substitutions = new ArrayList<>();
            for (FontSubstitutionInfo substitution : presentation.getFontsManager().getSubstitutions()) {
                substitutions.add(substitution);
            }

            if (substitutions.isEmpty()) {
                System.out.println("No font substitutions.");
            } else {
                System.out.println("Font substitutions:");
                for (FontSubstitutionInfo substitution : substitutions) {
                    System.out.println("  " + substitution.getOriginalFontName() + " -> " + substitution.getSubstitutedFontName());
                }
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

`getFontFolders` có thể trả về cùng một thư mục nhiều lần, vì vậy chương trình sẽ thu thập các thư mục vào một tập hợp trước khi in ra.

*.dockerignore* giữ các kết quả build cục bộ ra khỏi ngữ cảnh build:

```text
target/
output/
```

*Dockerfile* xây dựng chương trình bằng image Maven và chạy nó trên image runtime Java của Eclipse Temurin, đã chứa sẵn fontconfig và các phông chữ DejaVu. [Chạy Aspose.Slides cho Java trong Docker](/slides/vi/java/how-to-run-aspose-slides-in-docker/) giải thích từng chỉ thị.

```dockerfile
FROM maven:3.9-eclipse-temurin-21 AS build
WORKDIR /src
COPY pom.xml .
RUN mvn -B dependency:go-offline
COPY src ./src
RUN mvn -B package

FROM eclipse-temurin:21-jre
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN mkdir output && chown ubuntu output
USER ubuntu
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

Xây dựng image và chạy kiểm tra:

```bash
docker build -t font-check .
docker run --rm font-check
```

Image chỉ chứa các phông chữ DejaVu, vì vậy cả ba phông chữ đều được thay thế bằng DejaVu Sans:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> DejaVu Sans
  Arial -> DejaVu Sans
  Times New Roman -> DejaVu Sans
```

Để kiểm tra các phông chữ của bản trình chiếu của bạn, truyền tên chúng làm đối số, ví dụ `docker run --rm font-check "Segoe UI" Consolas`. Để sao chép *output/fonts.pdf* ra khỏi container, sử dụng các lệnh trong [Sao chép Kết quả ra Máy của Bạn](/slides/vi/java/how-to-run-aspose-slides-in-docker/#copy-the-output-to-your-machine).

## **Cài đặt phông chữ trên Debian và Ubuntu**

### **Phông chữ Core của Microsoft**

Gói `ttf-mscorefonts-installer` tải về và cài đặt các phông chữ core của Microsoft cho web, trong đó có Arial, Times New Roman, Courier New, Verdana, Georgia và Trebuchet MS. Các phông chữ này được cấp phép theo thỏa thuận giấy phép người dùng cuối (EULA) của Microsoft, và gói chỉ cài đặt chúng sau khi EULA được chấp nhận. Quá trình build Docker không thể trả lời lời nhắc, vì vậy trình cài đặt từ chối EULA và không cài đặt phông chữ nào, trong khi `apt-get install` vẫn báo thành công. Chấp nhận EULA bằng `debconf-set-selections` **trước** khi gói được cài đặt. Chấp nhận nó trong một chỉ thị sau không có hiệu quả: gói đã được cài đặt rồi, và apt không chạy lại trình cài đặt.

Thêm chỉ thị này vào giai đoạn runtime của *Dockerfile*, ngay sau dòng `FROM`, để nó chạy với quyền root, trước chỉ thị `USER`:

```dockerfile
RUN echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

Xây dựng image và chạy lại kiểm tra với hai lệnh giống nhau. Arial và Times New Roman bây giờ đã được cài đặt:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

Calibri, phông chữ mặc định của một bản trình chiếu mà Aspose.Slides tạo ra, không phải là một trong các phông chữ core, vì vậy nó vẫn bị thay thế. Xem [Đặt Phông chữ Mặc định cho Các Phông chữ Thiếu](#set-a-default-font-for-missing-fonts).

Các image Eclipse Temurin dựa trên Ubuntu bật `multiverse`, thành phần của Ubuntu chứa gói. Trên Debian, gói nằm trong thành phần `contrib`, mà các image Debian không bật. Trong một giai đoạn runtime dựa trên Debian, chẳng hạn như trong [Sử dụng Image Cơ sở Khác](/slides/vi/java/how-to-run-aspose-slides-in-docker/#use-another-base-image), bật `contrib` trong cùng một chỉ thị:

```dockerfile
RUN sed -i 's/^Components: main$/Components: main contrib/' /etc/apt/sources.list.d/debian.sources \
    && echo "ttf-mscorefonts-installer msttcorefonts/accepted-mscorefonts-eula select true" | debconf-set-selections \
    && apt-get update \
    && apt-get install -y --no-install-recommends ttf-mscorefonts-installer \
    && rm -rf /var/lib/apt/lists/*
```

### **Các gói phông chữ khác**

Debian và Ubuntu cũng cung cấp các phông chữ có giấy phép tự do, ví dụ:

| Package | Fonts |
|---|---|
| `fonts-dejavu-core` | DejaVu Sans, DejaVu Serif, DejaVu Sans Mono |
| `fonts-liberation` | Liberation Sans, Serif và Mono, với các chỉ số giống Arial, Times New Roman và Courier New |
| `fonts-crosextra-carlito` | Carlito, với các chỉ số giống Calibri |
| `fonts-crosextra-caladea` | Caladea, với các chỉ số giống Cambria |

Cài đặt chúng bằng `apt-get install` trong một chỉ thị `RUN` của giai đoạn runtime, tương tự như các phông chữ core của Microsoft. Aspose.Slides cho Java không áp dụng các bí danh phông chữ của cấu hình phông chữ Linux: ngay cả khi đã cài đặt `fonts-liberation`, văn bản trong Arial vẫn được vẽ bằng phông chữ thay thế chung, không phải Liberation Sans. Để sử dụng một phông chữ tương thích về chỉ số thay cho phông chữ thiếu, đặt nó làm [phông chữ mặc định](#set-a-default-font-for-missing-fonts) hoặc thêm một [quy tắc thay thế phông chữ](/slides/vi/java/font-substitution/).

## **Thêm các tệp phông chữ của riêng bạn**

Những phông chữ mà bản phân phối không cung cấp, chẳng hạn như phông chữ của tổ chức bạn hoặc các phông chữ khác mà bạn được cấp phép sử dụng trên máy chủ, có thể được thêm dưới dạng các tệp phông chữ. Đặt các tệp phông chữ, ví dụ các tệp *.ttf*, vào một thư mục có tên *fonts* bên trong thư mục *font-check*. Các ví dụ bên dưới sử dụng các tệp của Carlito, một phông chữ có chỉ số giống Calibri, bạn có thể tải xuống từ [Google Fonts](https://fonts.google.com/specimen/Carlito).

### **Cài đặt các phông chữ vào Thư mục Phông chữ Hệ thống**

Aspose.Slides đọc các phông chữ trong các thư mục được in trên dòng `Font folders`. Để cài đặt phông chữ của bạn cho mọi ứng dụng trong image, sao chép chúng vào */usr/local/share/fonts*, thư mục cho các phông chữ được cài đặt cục bộ. Thêm chỉ thị này vào giai đoạn runtime của *Dockerfile*, sau chỉ thị `RUN` cài đặt các phông chữ core của Microsoft:

```dockerfile
COPY fonts/ /usr/local/share/fonts/
```

Tái xây dựng image, sau đó kiểm tra Calibri và Carlito:

```bash
docker build -t font-check .
docker run --rm font-check Calibri Carlito
```

Carlito không còn bị thay thế nữa:

```text
Font folders: /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

### **Tải phông chữ từ Thư mục Ứng dụng**

Thay vì cài đặt phông chữ trong thư mục hệ thống, bạn có thể đóng gói chúng cùng với ứng dụng và tải chúng bằng [FontsLoader.loadExternalFonts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---). Khi đó các phông chữ chỉ khả dụng cho Aspose.Slides và chúng được triển khai cùng với ứng dụng. *FontCheck* làm như vậy: khi thư mục làm việc của nó, */app* trong container, chứa một thư mục *fonts*, chương trình truyền thư mục đó cho `loadExternalFonts` trước khi tạo bản trình chiếu. [Phông chữ Tùy chỉnh](/slides/vi/java/custom-font/) mô tả các cách khác để cung cấp phông chữ, chẳng hạn như tải chúng từ bộ nhớ.

Trong *Dockerfile*, loại bỏ chỉ thị `COPY fonts/ /usr/local/share/fonts/` và thêm chỉ thị này sau chỉ thị sao chép thư mục *lib*:

```dockerfile
COPY fonts/ ./fonts/
```

Tái xây dựng image và chạy kiểm tra với hai lệnh giống nhau. Thư mục ứng dụng giờ xuất hiện trong các thư mục phông chữ, và Carlito vẫn không bị thay thế:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Arial
```

`loadExternalFonts` thêm phông chữ vào các phông chữ đã cài đặt, nhưng hỗ trợ phông chữ của Java vẫn cần ít nhất một phông chữ đã được cài đặt. Trong một image không có phông chữ nào, `loadExternalFonts` dừng lại với lỗi "Fontconfig head is null, check your fonts or fonts configuration".

## **Đặt Phông chữ Mặc định cho Các Phông chữ Thiếu**

Khi một phông chữ bị thiếu, Aspose.Slides sử dụng một phông chữ thay thế do nó tự chọn. Để tự chọn phông chữ thay thế, truyền tên phông chữ vào phương thức [setDefaultRegularFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultRegularFont-java.lang.String-) của [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) và truyền các tùy chọn này cho hàm tạo [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). *FontCheck* đọc tên phông chữ từ biến môi trường `DEFAULT_FONT`. Khi Carlito đã được tải, sử dụng nó cho các phông chữ thiếu:

```bash
docker run --rm -e DEFAULT_FONT=Carlito font-check
```

Calibri giờ được vẽ bằng Carlito, các ký tự của nó có cùng độ rộng với Calibri, vì vậy văn bản giữ nguyên các ngắt dòng:

```text
Font folders: /app/fonts, /usr/share/fonts, /usr/local/share/fonts, /home/ubuntu/.local/share/fonts, /home/ubuntu/.fonts
Font substitutions:
  Calibri -> Carlito
```

Phông chữ mặc định thay thế mọi phông chữ bị thiếu. Để ánh xạ từng phông chữ, ví dụ Arial sang Liberation Sans và Calibri sang Carlito, sử dụng [các quy tắc thay thế phông chữ](/slides/vi/java/font-substitution/). Các quy tắc thay đổi đầu ra được render, nhưng `getSubstitutions` không phản ánh chúng, vì vậy hãy kiểm tra các phông chữ trong tệp đầu ra thay vì. Đối với văn bản Asian, cũng gọi [setDefaultAsianFont](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultAsianFont-java.lang.String-); xem [Phông chữ Mặc định](/slides/vi/java/default-font/).

## **Cài đặt phông chữ trên Alpine Linux**

Image Eclipse Temurin dựa trên Alpine cũng chứa các phông chữ DejaVu; [Chạy trên Alpine Linux](/slides/vi/java/how-to-run-aspose-slides-in-docker/#run-on-alpine-linux) mô tả giai đoạn runtime của nó. Để cài đặt các phông chữ core của Microsoft trên đó, thay thế giai đoạn runtime của Dockerfile *font-check* bằng đoạn sau:

```dockerfile
FROM eclipse-temurin:21-jre-alpine
RUN apk add --no-cache msttcorefonts-installer \
    && update-ms-fonts \
    && fc-cache -f
WORKDIR /app
COPY --from=build /src/target/font-check.jar .
COPY --from=build /src/target/lib ./lib
RUN adduser -D app && mkdir output && chown app output
USER app
ENTRYPOINT ["java", "-cp", "font-check.jar:lib/*", "FontCheck"]
```

`update-ms-fonts` tải về và cài đặt các phông chữ core của Microsoft giống như gói Debian và Ubuntu, và EULA của chúng áp dụng tương tự. `fc-cache` cập nhật bộ nhớ đệm phông chữ của fontconfig. Xây dựng image và chạy kiểm tra với hai lệnh từ [Kiểm tra các phông chữ nào bị thay thế](#check-which-fonts-are-substituted). Nó in ra:

```text
Font folders: /usr/share/fonts, /home/app/.local/share/fonts, /home/app/.fonts
Font substitutions:
  Calibri -> Arial
```

Các bước còn lại trên trang này hoạt động tương tự trên Alpine: sao chép thư mục *fonts* vào */usr/local/share/fonts* hoặc vào thư mục ứng dụng, và đặt `DEFAULT_FONT` để chọn phông chữ mặc định. Image Alpine không có thư mục */usr/local/share/fonts*, vì vậy thư mục này chỉ xuất hiện trên dòng `Font folders` sau khi một chỉ thị `COPY` tạo ra nó.

## **Câu hỏi thường gặp**

**Tại sao một bản trình chiếu trông khác khi được chuyển đổi trên máy chủ?**

Máy chủ không có các phông chữ mà bản trình chiếu sử dụng, vì vậy Aspose.Slides vẽ văn bản bằng phông chữ thay thế có độ rộng ký tự khác nhau. Chạy *FontCheck* với các tên phông chữ của bản trình chiếu để xem phông chữ nào bị thay thế, sau đó cài đặt các phông chữ đó hoặc tải chúng từ thư mục ứng dụng.

**Việc build đã cài đặt ttf-mscorefonts-installer, nhưng Arial vẫn bị thay thế. Tại sao?**

EULA không được chấp nhận trước khi gói được cài đặt, vì vậy trình cài đặt đã bỏ qua các phông chữ. Đặt lệnh `debconf-set-selections` trước `apt-get install` trong chỉ thị cài đặt gói, như được mô tả trong [Phông chữ Core của Microsoft](#microsoft-core-fonts), và xây dựng lại image.

**Máy tính mở PDF có cần các phông chữ không?**

Không. Trong các ví dụ này, PDF chứa các phông chữ đã được sử dụng để vẽ văn bản, vì vậy nó sẽ hiện ra giống nhau trên bất kỳ máy tính nào. Các phông chữ chỉ cần có ở nơi Aspose.Slides thực hiện việc render bản trình chiếu.