---
title: Các yêu cầu hệ thống
type: docs
weight: 60
url: /vi/java/system-requirements/
keywords:
- các yêu cầu hệ thống
- các nền tảng được hỗ trợ
- các phiên bản Java
- JDK
- JRE
- fontconfig
- phông chữ
- Docker
- Alpine
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Kiểm tra những gì Aspose.Slides for Java cần trước khi bạn cài đặt nó: các phiên bản Java được hỗ trợ và hệ điều hành, cũng như thư viện phông chữ và các phông chữ mà Linux yêu cầu."
---
## **Giới thiệu**

Aspose.Slides for Java là một thư viện độc lập: nó không cần Microsoft PowerPoint hay Microsoft Office. Nó là một tệp JAR duy nhất, được công bố trong kho Maven của Aspose. Tệp JAR chỉ chứa các lớp và tài nguyên Java, không có thư viện gốc, và không khai báo phụ thuộc vào bất kỳ thư viện nào khác. Do đó cùng một tệp có thể chạy trên mọi hệ điều hành và bộ xử lý mà môi trường Java hỗ trợ.

Trong bài viết này, chúng tôi liệt kê các phiên bản Java và hệ điều hành được hỗ trợ, cũng như thư viện phông chữ và các phông chữ mà Linux yêu cầu, và kết thúc bằng một chương trình ngắn kiểm tra cấu hình của bạn. Để thêm thư viện vào dự án, xem [Cài đặt](/slides/vi/java/installation/).

## **Các phiên bản Java được hỗ trợ**

Aspose.Slides for Java chạy trên Java 8 trở lên, với JDK hoặc JRE. Điều này bao gồm các bản phát hành hỗ trợ dài hạn Java 8, 11, 17, 21 và 25, và các bản phát hành sau này như Java 26 và Java 27. Môi trường Java có thể đến từ bất kỳ nhà cung cấp nào, ví dụ Eclipse Temurin, Amazon Corretto, Oracle, hoặc các gói OpenJDK của một bản phân phối Linux.

Aspose.Slides không cần tùy chọn JVM nào, chẳng hạn `--add-opens`, trên bất kỳ phiên bản nào trong số này. Trên Java 11, JVM sẽ in ra một cảnh báo bắt đầu bằng "WARNING: An illegal reflective access operation has occurred"; cảnh báo này không ảnh hưởng đến kết quả.

{{% alert color="warning" title="Warning" %}}
Java 6 và Java 7 đã lỗi thời. Aspose.Slides for Java 26.9 vẫn chạy trên chúng nhưng sẽ in cảnh báo lỗi thời. Bắt đầu từ phiên bản 26.10, Java 8 là yêu cầu tối thiểu, và Java 6 và Java 7 không còn được hỗ trợ.
{{% /alert %}}

Dự án Maven và các lệnh trong [Cài đặt](/slides/vi/java/installation/) yêu cầu JDK 11 trở lên. Với Java 8, hãy biên dịch và chạy chương trình như được mô tả trong [Kiểm tra cấu hình](#check-your-setup).

## **Hệ điều hành được hỗ trợ**

Vì tệp JAR không chứa mã gốc, Aspose.Slides for Java chạy trên Windows, Linux và macOS, trên bất kỳ kiến trúc bộ xử lý nào mà môi trường Java hỗ trợ, chẳng hạn x64 và ARM64. Môi trường Java là yêu cầu duy nhất trên Windows. Trên Linux, hỗ trợ phông chữ của Java cũng cần thư viện phông chữ và các phông chữ được mô tả trong [Linux](#linux).

## **Linux**

Aspose.Slides for Java bố trí và vẽ văn bản bằng hỗ trợ phông chữ của môi trường Java. Trên Linux, hỗ trợ này yêu cầu thư viện fontconfig và ít nhất một phông chữ đã được cài đặt. Các ảnh hưởng chính của các hình ảnh chứa không thường có chúng. Nếu không có chúng, ví dụ đầu tiên trong [Create Presentations](/slides/vi/java/create-presentation/) sẽ thất bại khi lưu bản trình diễn, để lại tệp trống và báo lỗi sau:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Các ảnh Docker chính thức `eclipse-temurin`, cho Ubuntu và Alpine Linux, đã bao gồm fontconfig và các phông chữ DejaVu, vì vậy không cần cài đặt gì thêm. Trên các hệ thống khác, hãy cài đặt các gói dưới đây. Các lệnh Debian, Ubuntu và Red Hat sử dụng `sudo`; trong Dockerfile, chạy chúng trong một chỉ thị `RUN` mà không có `sudo`. Các phông chữ DejaVu là đủ để Aspose.Slides hoạt động; các phông chữ mà bản trình diễn của bạn sử dụng được đề cập trong [Phông chữ](#fonts).

### **Debian và Ubuntu**

Nếu bạn cài đặt Java từ các gói Debian hoặc Ubuntu với cài đặt mặc định của `apt-get`, như lệnh trong [Cài đặt](/slides/vi/java/installation/#linux) thực hiện, các gói Java cũng sẽ cài đặt thư viện fontconfig, các phông chữ DejaVu và thư viện HarfBuzz mà các gói Java này cần, và không cần gì khác.

Với môi trường Java từ nguồn khác, chẳng hạn một bản lưu trữ Eclipse Temurin, hãy cài đặt fontconfig và các phông chữ DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Một Dockerfile thường cài đặt các gói Java Debian hoặc Ubuntu, như `openjdk-21-jdk-headless` hoặc `default-jdk-headless`, với tùy chọn `--no-install-recommends`, tùy chọn này sẽ bỏ qua cả ba. Hãy cài đặt fontconfig và các phông chữ DejaVu bằng lệnh trên, và cũng cài đặt HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Không có HarfBuzz, các gói Java này sẽ in `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, và việc lưu sẽ thất bại với một `UnsatisfiedLinkError` báo rằng `libharfbuzz.so.0` không thể mở.

### **Red Hat Enterprise Linux**

Các gói `java-<version>-openjdk-headless` của Red Hat Enterprise Linux không cài đặt thư viện fontconfig. Hãy cài đặt nó cùng với các phông chữ DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Các gói đầy đủ `java-<version>-openjdk` sẽ cài đặt fontconfig và các phông chữ như các phụ thuộc, và các gói Amazon Corretto của Amazon Linux 2023, chẳng hạn `java-21-amazon-corretto-headless`, cũng vậy.

### **Alpine Linux**

Trong một Dockerfile dựa trên Alpine Linux, hãy cài đặt fontconfig và các phông chữ DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Trên các phiên bản Alpine hiện tại, `ttf-dejavu` sẽ cài đặt gói `font-dejavu`. Cài đặt Java với gói `openjdk<version>-jre` hoặc `openjdk<version>-jdk`, chẳng hạn `openjdk25-jdk`. Các gói `openjdk<version>-jre-headless` của Alpine Linux không chứa thư viện phông chữ của Java, vì vậy khi dùng chúng, chương trình sẽ thất bại với `UnsatisfiedLinkError: no fontmanager in system library path`, ngay cả khi đã cài đặt phông chữ.

### **Phông chữ**

Để văn bản được hiển thị với phông chữ và chỉ số đo chính xác, các phông chữ được sử dụng trong bản trình diễn của bạn, hoặc các thay thế phù hợp, phải có sẵn trên hệ thống hoặc được tải bởi ứng dụng của bạn. Xem [Triển khai phông chữ](/slides/vi/java/deploy-fonts/), [Thay thế](/slides/vi/java/font-substitution/), và [Phông chữ tùy chỉnh](/slides/vi/java/custom-font/).

## **Kiểm tra cấu hình**

Để kiểm tra rằng thư viện và các yêu cầu của nó đã sẵn sàng, hãy chạy một chương trình lưu bản trình diễn và render một slide thành hình ảnh. Việc lưu và render sử dụng hỗ trợ phông chữ của môi trường Java, mà các yêu cầu Linux ở trên cung cấp.

Lưu đoạn mã dưới đây thành *CheckSetup.java* trong thư mục chứa tệp JAR Aspose.Slides. Để tải tệp JAR, xem [Sử dụng tệp JAR mà không cần Maven](/slides/vi/java/installation/#use-the-jar-file-without-maven).

```java
import com.aspose.slides.*;

public class CheckSetup {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            // Thêm một hình chữ nhật có văn bản vào slide đầu tiên và lưu bản trình chiếu.
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
            shape.getTextFrame().setText("Hello, Aspose.Slides!");
            presentation.save("hello.pptx", SaveFormat.Pptx);

            // Render slide với một pixel cho mỗi point và lưu hình ảnh.
            IImage image = slide.getImage(1f, 1f);
            try {
                image.save("hello.png", ImageFormat.Png);
            } finally {
                image.dispose();
            }
        } finally {
            presentation.dispose();
        }
    }
}
```

Với JDK 11 hoặc cao hơn, chạy chương trình trong thư mục đó bằng lệnh dưới đây. Nếu tệp JAR của bạn có tên khác, hãy thay đổi tên trong các lệnh.

```bash
java -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
```

Với Java 8, hoặc trên hệ thống chỉ có JRE, biên dịch chương trình bằng `javac` từ một JDK rồi chạy lớp đã biên dịch. Trên Linux và macOS, chạy:

```bash
javac -cp aspose-slides-26.10-jdk8.jar CheckSetup.java
java -cp aspose-slides-26.10-jdk8.jar:. CheckSetup
```

Trên Windows, chạy cùng lệnh `javac`, rồi chạy lớp với dấu chấm phẩy làm dấu phân cách đường dẫn lớp. Giữ lại dấu ngoặc kép, để PowerShell không coi dấu chấm phẩy là kết thúc lệnh: `java -cp "aspose-slides-26.10-jdk8.jar;." CheckSetup`.

Chương trình thêm một hình chữ nhật chứa văn bản vào slide đầu tiên và lưu bản trình diễn thành *hello.pptx* bằng phương thức [save](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Sau đó, nó render slide bằng [getImage](https://reference.aspose.com/slides/java/com.aspose.slides/slide/#getImage-float-float-) và lưu kết quả thành *hello.png* bằng [IImage.save](https://reference.aspose.com/slides/java/com.aspose.slides/iimage/#save-java.lang.String-int-) trong định dạng [ImageFormat.Png](https://reference.aspose.com/slides/java/com.aspose.slides/imageformat/). Hệ số tỉ lệ 1 sẽ render một pixel cho mỗi point, vì vậy slide mặc định 720 × 540 point sẽ thành ảnh 720 × 540 pixel, với văn bản hiển thị bên trong hình chữ nhật. Khi không có giấy phép, cả hai tệp cũng chứa dấu nước đánh giá; xem [Licensing](/slides/vi/java/licensing/). Nếu thiếu bất kỳ yêu cầu nào, chương trình sẽ dừng với một trong các lỗi được mô tả trong [Linux](#linux).

## **Công cụ phát triển**

Bạn có thể xây dựng các ứng dụng sử dụng Aspose.Slides với bất kỳ JDK nào của phiên bản Java được hỗ trợ. Sử dụng Apache Maven với kho Maven của Aspose, như mô tả trong [Cài đặt](/slides/vi/java/installation/), hoặc bất kỳ công cụ xây dựng nào khác có thể sử dụng kho Maven. Bạn cũng có thể thêm tệp JAR vào đường dẫn lớp của IDE hoặc công cụ xây dựng của mình.

## **Câu hỏi thường gặp**

**Có cần cài đặt Microsoft PowerPoint để thực hiện chuyển đổi và render không?**

Không, PowerPoint không bắt buộc. Aspose.Slides là một engine độc lập để [tạo](/slides/vi/java/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/java/convert-presentation/), và [render](/slides/vi/java/convert-powerpoint-to-png/) các bản trình diễn.

**Aspose.Slides for Java có cần màn hình hoặc môi trường desktop trên máy chủ Linux không?**

Không. Aspose.Slides không cần X server hay màn hình, vì vậy nó có thể chạy trên máy chủ và trong container. Trên Linux, nó chỉ cần thư viện phông chữ và các phông chữ được mô tả trong [Linux](#linux).

**Những phông chữ nào cần thiết cho việc render chính xác?**

Các phông chữ được sử dụng trong bản trình diễn, hoặc các [thay thế](/slides/vi/java/font-substitution/) phù hợp, phải có sẵn. Trên Linux và macOS, hãy cài đặt các gói phông chữ mà bản trình diễn của bạn cần để đạt được việc render nhất quán.

**Tại sao một phông chữ tùy chỉnh lại được render như dự phòng hoặc hiển thị thiếu trên Linux?**

Nếu tệp phông chữ có các mục bảng tên không nhất quán hoặc bị hỏng, stack khớp phông chữ của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, dẫn tới việc phông chữ không được giải quyết. Sử dụng phiên bản phông chữ có bảng tên đã được sửa hoặc cài đặt một bản thay thế nhất quán sẽ giải quyết vấn đề.