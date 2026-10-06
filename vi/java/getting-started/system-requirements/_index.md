---
title: Yêu cầu hệ thống
type: docs
weight: 60
url: /vi/java/system-requirements/
keywords:
- yêu cầu hệ thống
- nền tảng được hỗ trợ
- phiên bản Java
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
description: "Kiểm tra những gì Aspose.Slides for Java cần trước khi bạn cài đặt: các phiên bản Java và hệ điều hành được hỗ trợ, cũng như thư viện font và các font mà Linux yêu cầu."
---
## **Giới thiệu**

Aspose.Slides for Java là một thư viện độc lập: nó không cần Microsoft PowerPoint hay Microsoft Office. Nó là một file JAR duy nhất, được công bố trong kho Maven của Aspose. File JAR chỉ chứa các lớp và tài nguyên Java, không có thư viện native, và không khai báo phụ thuộc vào thư viện khác. Vì vậy cùng một file có thể chạy trên mọi hệ điều hành và bộ xử lý mà môi trường Java hỗ trợ.

Bài viết này liệt kê các phiên bản Java và hệ điều hành được hỗ trợ cũng như thư viện font và các font mà Linux yêu cầu, và kết thúc bằng một chương trình ngắn kiểm tra thiết lập của bạn. Để thêm thư viện vào dự án, xem [Cài đặt](/slides/vi/java/installation/).

## **Phiên bản Java được hỗ trợ**

Aspose.Slides for Java chạy trên Java 8 trở lên, với JDK hoặc JRE. Điều này bao gồm các bản phát hành hỗ trợ dài hạn Java 8, 11, 17, 21, và 25, và các bản phát hành sau như Java 26 và Java 27. Môi trường Java có thể đến từ bất kỳ nhà cung cấp nào, ví dụ Eclipse Temurin, Amazon Corretto, Oracle, hoặc các gói OpenJDK của một bản phân phối Linux.

Aspose.Slides không cần tùy chọn JVM nào, chẳng hạn `--add-opens`, trên bất kỳ phiên bản nào trong số này. Trên Java 11, JVM sẽ in một cảnh báo bắt đầu bằng "WARNING: An illegal reflective access operation has occurred"; cảnh báo không ảnh hưởng tới kết quả.

{{% alert color="warning" title="Warning" %}}
Java 6 và Java 7 đã lỗi thời. Aspose.Slides for Java 26.9 vẫn chạy được trên chúng nhưng sẽ in cảnh báo lỗi thời. Bắt đầu từ phiên bản 26.10, Java 8 là yêu cầu tối thiểu, và Java 6, Java 7 không còn được hỗ trợ.
{{% /alert %}}

Dự án Maven và các lệnh trong [Cài đặt](/slides/vi/java/installation/) cần JDK 11 trở lên. Với Java 8, biên dịch và chạy chương trình như mô tả trong [Kiểm tra thiết lập của bạn](#check-your-setup).

## **Hệ điều hành được hỗ trợ**

Vì file JAR không chứa mã native, Aspose.Slides for Java chạy trên Windows, Linux và macOS, trên bất kỳ kiến trúc bộ xử lý nào mà môi trường Java hỗ trợ, như x64 và ARM64. Môi trường Java là yêu cầu duy nhất trên Windows. Trên Linux, hỗ trợ font của Java cũng cần thư viện font và các font được mô tả trong [Linux](#linux).

## **Linux**

Aspose.Slides for Java bố trí và vẽ văn bản dựa trên hỗ trợ font của môi trường Java. Trên Linux, hỗ trợ này yêu cầu thư viện fontconfig và ít nhất một font đã được cài đặt. Các image container chính thức của các bản phân phối Linux thường không có cả hai. Nếu thiếu, ví dụ đầu tiên trong [Tạo bản trình chiếu](/slides/vi/java/create-presentation/) sẽ thất bại khi lưu bản trình chiếu, để lại file rỗng và báo lỗi sau:

```text
java.lang.RuntimeException: Fontconfig head is null, check your fonts or fonts configuration
```

Các image container `eclipse-temurin` chính thức, cho Ubuntu và Alpine Linux, đã bao gồm fontconfig và các font DejaVu, vì vậy không cần cài đặt gì thêm. Trên các hệ thống khác, hãy cài đặt các gói dưới đây. Các lệnh cho Debian, Ubuntu và Red Hat sử dụng `sudo`; trong Dockerfile, chạy chúng trong một chỉ thị `RUN` mà không có `sudo`. Các font DejaVu đủ cho Aspose.Slides hoạt động; các font mà bản trình chiếu của bạn sử dụng được đề cập trong [Font](/#fonts).

### **Debian và Ubuntu**

Nếu bạn cài đặt Java từ các gói Debian hoặc Ubuntu với cài đặt mặc định `apt-get`, như lệnh trong [Cài đặt](/slides/vi/java/installation/#linux) thực hiện, các gói Java cũng sẽ cài đặt thư viện fontconfig, các font DejaVu và thư viện HarfBuzz mà các gói Java này cần, và không cần gì thêm.

Với môi trường Java từ nguồn khác, chẳng hạn một archive Eclipse Temurin, hãy cài đặt fontconfig và các font DejaVu:

```bash
sudo apt-get update && sudo apt-get install -y fontconfig fonts-dejavu-core
```

Một Dockerfile thường cài đặt các gói Java Debian hoặc Ubuntu, như `openjdk-21-jdk-headless` hoặc `default-jdk-headless`, với tùy chọn `--no-install-recommends`, bỏ qua ba thành phần trên. Hãy cài đặt fontconfig và các font DejaVu bằng lệnh ở trên, và cũng cài đặt HarfBuzz:

```bash
sudo apt-get install -y libharfbuzz0b
```

Nếu không có HarfBuzz, các gói Java này sẽ in `Please install the openjdk-*-jre package or recommended packages for openjdk-*-jre-headless`, và việc lưu sẽ thất bại với `UnsatisfiedLinkError` báo rằng `libharfbuzz.so.0` không thể mở.

### **Red Hat Enterprise Linux**

Các gói `java-<version>-openjdk-headless` của Red Hat Enterprise Linux không cài đặt thư viện fontconfig. Hãy cài đặt nó cùng với các font DejaVu:

```bash
sudo dnf install -y fontconfig dejavu-sans-fonts
```

Các gói `java-<version>-openjdk` đầy đủ sẽ cài đặt fontconfig và các font như phụ thuộc, và các gói Amazon Corretto của Amazon Linux 2023 cũng vậy, ví dụ `java-21-amazon-corretto-headless`.

### **Alpine Linux**

Trong một Dockerfile dựa trên Alpine Linux, hãy cài đặt fontconfig và các font DejaVu:

```dockerfile
RUN apk add --no-cache fontconfig ttf-dejavu
```

Trên các phiên bản Alpine hiện tại, `ttf-dejavu` sẽ cài đặt gói `font-dejavu`. Cài đặt Java bằng gói `openjdk<version>-jre` hoặc `openjdk<version>-jdk`, chẳng hạn `openjdk25-jdk`. Các gói `openjdk<version>-jre-headless` của Alpine Linux không chứa thư viện font của Java, vì vậy với chúng chương trình sẽ thất bại với `UnsatisfiedLinkError: no fontmanager in system library path`, ngay cả khi đã cài đặt font.

### **Font**

Để văn bản được hiển thị đúng font và mét, các font mà bản trình chiếu của bạn sử dụng, hoặc các font thay thế phù hợp, phải được cài đặt trên hệ thống hoặc được tải bởi ứng dụng của bạn. Xem [Triển khai Font](/slides/vi/java/deploy-fonts/), [Thay thế Font](/slides/vi/java/font-substitution/), và [Font Tùy chỉnh](/slides/vi/java/custom-font/).

## **Kiểm tra thiết lập của bạn**

Để kiểm tra rằng thư viện và các yêu cầu đã sẵn sàng, chạy một chương trình lưu bản trình chiếu và render một slide thành hình ảnh. Việc lưu và render sử dụng hỗ trợ font của môi trường Java, như các yêu cầu Linux ở trên cung cấp.

Lưu mã dưới đây thành *CheckSetup.java* trong thư mục chứa file JAR Aspose.Slides. Để tải file JAR, xem [Sử dụng file JAR mà không cần Maven](/slides/vi/java/installation/#use-the-jar-file-without-maven).

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

Với JDK 11 hoặc cao hơn, chạy chương trình trong thư mục đó bằng lệnh dưới đây. Nếu file JAR của bạn có tên khác, hãy đổi tên trong các lệnh.

```bash
java -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
```

Với Java 8, hoặc trên hệ thống chỉ có JRE, biên dịch chương trình bằng `javac` từ một JDK rồi chạy lớp đã biên dịch. Trên Linux và macOS, chạy:

```bash
javac -cp aspose-slides-26.9-jdk16.jar CheckSetup.java
java -cp aspose-slides-26.9-jdk16.jar:. CheckSetup
```

Trên Windows, chạy cùng lệnh `javac`, sau đó chạy lớp với dấu chấm phẩy làm dấu phân cách classpath. Giữ dấu ngoặc kép, để PowerShell không xem dấu chấm phẩy là kết thúc lệnh: `java -cp "aspose-slides-26.9-jdk16.jar;." CheckSetup`.

Chương trình thêm một hình chữ nhật có văn bản vào slide đầu tiên và lưu bản trình chiếu thành *hello.pptx* bằng phương thức [save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-). Sau đó render slide bằng [getImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slide/#getImage-float-float-) và lưu kết quả thành *hello.png* bằng [IImage.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/#save-java.lang.String-int-) ở định dạng [ImageFormat.Png](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/). Hệ số tỷ lệ 1 sẽ render một pixel cho mỗi point, vì vậy slide mặc định 720 × 540 point trở thành ảnh 720 × 540 pixel, với văn bản hiển thị bên trong hình chữ nhật. Không có giấy phép, cả hai file đều có watermark đánh giá; xem [Giấy phép](/slides/vi/java/licensing/). Nếu thiếu một yêu cầu, chương trình sẽ dừng với một trong các lỗi được mô tả trong [Linux](#linux).

## **Công cụ phát triển**

Bạn có thể xây dựng các ứng dụng sử dụng Aspose.Slides với bất kỳ JDK nào của phiên bản Java được hỗ trợ. Sử dụng Apache Maven với kho Maven của Aspose, như mô tả trong [Cài đặt](/slides/vi/java/installation/), hoặc bất kỳ công cụ xây dựng nào khác có thể sử dụng kho Maven. Bạn cũng có thể tự thêm file JAR vào classpath của IDE hoặc công cụ xây dựng.

## **FAQ**

**Có cần cài đặt Microsoft PowerPoint để thực hiện chuyển đổi và render không?**

Không, PowerPoint không bắt buộc. Aspose.Slides là một engine độc lập cho việc [tạo](/slides/vi/java/create-presentation/), chỉnh sửa, [chuyển đổi](/slides/vi/java/convert-presentation/), và [render](/slides/vi/java/convert-powerpoint-to-png/) bản trình chiếu.

**Aspose.Slides for Java có cần màn hình hoặc môi trường desktop trên server Linux không?**

Không. Aspose.Slides không cần X server hay màn hình, vì vậy nó chạy được trên server và trong container. Trên Linux, nó chỉ cần thư viện font và các font được mô tả trong [Linux](#linux).

**Cần những font nào để render đúng?**

Các font được sử dụng trong bản trình chiếu, hoặc các [thay thế](/slides/vi/java/font-substitution/) phù hợp, phải có sẵn. Trên Linux và macOS, cài đặt các gói font mà bản trình chiếu của bạn cần để có kết quả render đồng nhất.

**Tại sao một font tùy chỉnh lại render thành fallback hoặc mất chữ trên Linux?**

Nếu file font có các mục bảng tên không nhất quán hoặc bị hỏng, ngăn xếp khớp font của Linux (FreeType/fontconfig) có thể chọn một bản ghi không hợp lệ, khiến font không được giải quyết. Sử dụng phiên bản font có các mục bảng tên đã được sửa hoặc cài đặt một bản thay thế nhất quán sẽ giải quyết vấn đề.