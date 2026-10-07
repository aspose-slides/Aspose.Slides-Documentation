---
title: Aspose.Slides cho Java
second_title: Aspose.Slides cho Java
type: docs
weight: 20
url: /vi/java/
keywords:
- tài liệu
- xử lý bài thuyết trình
- chuyển đổi bài thuyết trình
- PowerPoint
- OpenDocument
- Java
- Aspose.Slides
description: "Bắt đầu tại đây: cài đặt Aspose.Slides cho Java, tạo một bài thuyết trình đầu tiên, và tìm các hướng dẫn cho các nhiệm vụ phổ biến, triển khai và tham chiếu API."
is_root: true
---
<img src="home_1.png" alt="Aspose.Slides for Java" align="left" style="width:110px; margin: 0 30px 20px 0"/>

Aspose.Slides for Java là một thư viện lớp để tạo, đọc, chỉnh sửa và chuyển đổi các bài thuyết trình PowerPoint và OpenDocument trong các ứng dụng Java, mà không cần Microsoft PowerPoint.

Thư viện này tải và lưu các định dạng PPT, PPTX, PPS, POT và ODP, bao gồm các biến thể hỗ trợ macro và mẫu, và xuất ra PDF, XPS, HTML, SVG, TIFF, Markdown và hình ảnh.

<div style="clear:both"></div>

------

<div class="row">
<div class="col-md-4">
<p><b>Bắt đầu</b></p>
<hr>
<p>BẮT ĐẦU</p>
<ul>
<li><a href="/slides/vi/java/installation/">Cài đặt</a></li>
<li><a href="/slides/vi/java/create-presentation/">Tạo bài thuyết trình đầu tiên của bạn</a></li>
<li><a href="/slides/vi/java/system-requirements/">Yêu cầu hệ thống</a></li>
<li><a href="/slides/vi/java/getting-started/">Hướng dẫn bắt đầu</a></li>
</ul>
<p>ĐÁNH GIÁ</p>
<ul>
<li><a href="/slides/vi/java/supported-file-formats/">Định dạng tệp được hỗ trợ</a></li>
<li><a href="/slides/vi/java/features-overview/">Tổng quan tính năng</a></li>
<li><a href="/slides/vi/java/evaluate-aspose-slides/">Giới hạn dùng thử</a></li>
<li><a href="/slides/vi/java/licensing/">Cấp phép</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Xây dựng với Slides</b></p>
<hr>
<p>CÔNG VIỆC PHỔ BIẾN</p>
<ul>
<li><a href="/slides/vi/java/open-presentation/">Mở bài thuyết trình</a></li>
<li><a href="/slides/vi/java/save-presentation/">Lưu bài thuyết trình</a></li>
<li><a href="/slides/vi/java/convert-powerpoint-to-pdf/">Chuyển đổi sang PDF</a></li>
<li><a href="/slides/vi/java/convert-slide/">Kết xuất slide dưới dạng hình ảnh</a></li>
<li><a href="/slides/vi/java/manage-text/">Chỉnh sửa văn bản và hình dạng</a></li>
</ul>
<p>QUY TRÌNH SLIDES</p>
<ul>
<li><a href="/slides/vi/java/powerpoint-charts/">Biểu đồ</a></li>
<li><a href="/slides/vi/java/powerpoint-animation/">Hoạt hình</a></li>
<li><a href="/slides/vi/java/manage-media-files/">Âm thanh và video</a></li>
<li><a href="/slides/vi/java/presentation-design/">Thiết kế slide</a></li>
<li><a href="/slides/vi/java/merge-presentation/">Hợp nhất bài thuyết trình</a></li>
</ul>
<p>VÍ DỤ</p>
<ul>
<li><a href="/slides/vi/java/examples/">Ví dụ theo thành phần slide</a></li>
<li><a href="https://github.com/aspose-slides/Aspose.Slides-for-Java">Ví dụ trên GitHub</a></li>
</ul>
</div>
<div class="col-md-4">
<p><b>Triển khai &amp; Hỗ trợ</b></p>
<hr>
<p>TRIỂN KHAI</p>
<ul>
<li><a href="/slides/vi/java/system-requirements/#linux">Yêu cầu trước cho Linux</a></li>
<li><a href="/slides/vi/java/how-to-run-aspose-slides-in-docker/">Chạy trong Docker</a></li>
<li><a href="/slides/vi/java/deploy-fonts/">Phông chữ</a></li>
<li><a href="/slides/vi/java/security/">Bảo mật</a></li>
</ul>
<p>THAM KHẢO</p>
<ul>
<li><a href="https://reference.aspose.com/slides/java/">Tham chiếu API</a></li>
<li><a href="https://releases.aspose.com/slides/java/release-notes/">Ghi chú phát hành</a></li>
<li><a href="/slides/vi/java/known-issues/">Vấn đề đã biết</a></li>
<li><a href="/slides/vi/java/api-limitations/">Giới hạn siêu dữ liệu đầu ra</a></li>
<li><a href="https://products.aspose.com/slides/java/">Trang sản phẩm</a></li>
<li><a href="https://releases.aspose.com/slides/java/">Tải xuống</a></li>
</ul>
<p>HỖ TRỢ</p>
<ul>
<li><a href="https://forum.aspose.com/c/slides/11">Diễn đàn hỗ trợ miễn phí</a></li>
<li><a href="https://helpdesk.aspose.com/">Hỗ trợ khách hàng trả phí</a></li>
</ul>
</div>
</div>

------

<a name="your-first-presentation"></a>

## **Bài thuyết trình đầu tiên của bạn**

Aspose.Slides for Java được phát hành trên kho Maven riêng của Aspose, không phải trên Maven Central. Tạo một thư mục cho dự án Maven và lưu *pom.xml* vào đó. Tệp này khai báo kho, thêm thư viện và chỉ định lớp cần chạy:

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

Lưu mã này thành *src/main/java/HelloSlides.java*:

```java
import com.aspose.slides.*;

public class HelloSlides {
    public static void main(String[] args) {
        // Tạo một bài thuyết trình. Nó đã chứa một slide trống.
        Presentation presentation = new Presentation();
        try {
            // Lấy slide đầu tiên.
            ISlide slide = presentation.getSlides().get_Item(0);

            // Thêm một hình dạng đám mây và đặt văn bản vào bên trong.
            IAutoShape autoShape = slide.getShapes().addAutoShape(ShapeType.Cloud, 20, 20, 200, 80);
            autoShape.getTextFrame().setText("Hello, Aspose!");

            // Lưu bài thuyết trình dưới dạng tệp PPTX.
            presentation.save("new_presentation.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Sau đó, với JDK 11 trở lên và Apache Maven đã được cài đặt, chạy lệnh sau trong thư mục dự án:

```bash
mvn compile exec:java
```

Chương trình sẽ lưu *new_presentation.pptx* vào thư mục dự án, với một slide chứa hình dạng đám mây và văn bản. Trên Linux, phải cài đặt fontconfig và ít nhất một phông chữ; xem [Cài đặt](/slides/vi/java/installation/#linux). Nếu không có bản quyền, tệp đã lưu sẽ có dấu watermark đánh giá — xem [Cấp phép](/slides/vi/java/licensing/). Để biết thêm các cách tạo và lấp đầy một bài thuyết trình, hãy xem [Tạo Bài thuyết trình](/slides/vi/java/create-presentation/).