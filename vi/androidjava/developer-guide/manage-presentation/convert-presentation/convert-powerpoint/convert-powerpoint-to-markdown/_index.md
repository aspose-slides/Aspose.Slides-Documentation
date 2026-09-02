---
title: Chuyển đổi Bài thuyết trình PowerPoint sang Markdown trên Android
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/androidjava/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bài thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bài thuyết trình sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bài thuyết trình dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- xuất ảnh Markdown
- liên kết ảnh CDN
- PowerPoint
- bài thuyết trình
- Markdown
- Android
- Java
- Aspose.Slides
description: "Chuyển đổi các bài thuyết trình PPT và PPTX sang Markdown trên Android qua Java và kiểm soát nơi lưu và tham chiếu các ảnh bitmap, metafile và SVG được xuất."
---
## **Tổng quan**

Aspose.Slides for Android via Java có thể chuyển đổi các bài thuyết trình PPT và PPTX sang Markdown cho tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được hiển thị và quyết định nơi lưu ảnh xuất ra cũng như cách Markdown tạo liên kết tới chúng.

Mặc định, xuất Markdown chỉ tạo đầu ra dạng văn bản. Để xuất nội dung trực quan, đặt loại xuất bằng phương thức [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) thành giá trị `Sequential` hoặc `Visual` trong enum [MarkdownExportType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownexporttype/). `Sequential` sẽ render các mục slide riêng lẻ và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo tồn mối quan hệ trực quan. Giá trị `TextOnly` không tạo tài nguyên ảnh, vì vậy các callback lưu ảnh sẽ không được gọi trong chế độ này.

## **Chuyển đổi Bài thuyết trình sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/), sau đó gọi phương thức [Presentation.save](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) với giá trị `Md` trong enum [SaveFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveformat/).

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Chọn Kiểu Markdown**

Phương thức [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) kiểm soát đặc tả Markdown được sử dụng cho đầu ra. Enum [Flavor](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể được hỗ trợ khác.

Ví dụ sau xuất một bài thuyết trình dưới dạng CommonMark:

```java
import com.aspose.slides.Flavor;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setFlavor(Flavor.CommonMark);

    presentation.save("presentation.md", SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Xuất ảnh bằng hành vi lưu cục bộ mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) cung cấp hai phương thức để cấu hình ảnh được lưu cục bộ:

- [setBasePath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) chỉ định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) chỉ định thư mục con cho ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung trực quan, ghi ảnh vào `output/assets`, và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Path outputDirectory = Paths.get("output");
Files.createDirectories(outputDirectory);

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("assets");

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Hành vi này cũng được sử dụng làm dự phòng khi một handler lưu ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh việc lưu ảnh và liên kết Markdown**

Sử dụng phương thức [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) để đăng ký callback cho các tài nguyên bitmap và metafile không phải SVG được xuất trong quá trình xuất Markdown. Callback `MarkdownImageSavingHandler` của nó nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/), giá trị [ImageFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/), và liên kết Markdown đã tạo dưới dạng một mảng `String[]` có một phần tử. Lưu hoặc tải lên ảnh với định dạng đã cung cấp, và thay thế `link[0]` bằng tham chiếu cần xuất hiện trong đầu ra Markdown.

Các tài nguyên được xuất ở định dạng SVG được xử lý riêng. Đăng ký callback bằng phương thức [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` của nó nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) và tham số `String[] link` có một phần tử. SVG không có tham số `ImageFormat`; thay vào đó ghi hoặc tải lên dữ liệu XML từ phương thức [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/). Tùy thuộc vào chế độ xuất và việc nhóm trực quan, một SVG trong bản trình bày nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sẽ được chuyển cho callback lưu ảnh. Đăng ký cả hai callback khi mọi tài nguyên trực quan được xuất cần xử lý tùy chỉnh.

Giá trị trả về của handler quyết định ai sẽ xử lý ảnh:

- Trả về `true` sau khi handler đã lưu, tải lên, chuyển đổi hoặc xử lý ảnh theo cách nào đó và đã gán một giá trị hợp lệ cho `link[0]`. Aspose.Slides sẽ ghi giá trị đó vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để cho phép Aspose.Slides lưu ảnh cục bộ và tạo liên kết theo các giá trị được đặt bằng [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}
Một handler trả về `true` sẽ chịu trách nhiệm cho ảnh. Nếu nó trả về `true` mà không gán một liên kết hợp lệ, không rỗng, việc xuất sẽ thất bại với `InvalidOperationException`.
{{% /alert %}}

### **Lưu ảnh vào thư mục gốc CDN và sử dụng URL bên ngoài**

Ví dụ sau coi `cdn-origin/presentations/quarterly-report` là một thư mục gốc CDN đã được gắn hoặc đồng bộ. Mỗi handler trích xuất tên tệp đã tạo, lưu ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng một URL công khai của CDN. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các tệp của nó được công bố lên CDN. Đối với lưu trữ đối tượng, thay thế việc ghi tệp hệ thống bằng thao tác tải lên của SDK lưu trữ và gán `link[0]` chỉ sau khi tải lên thành công.

```java
import com.aspose.slides.MarkdownExportType;
import com.aspose.slides.MarkdownSaveOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.IOException;
import java.io.UnsupportedEncodingException;
import java.net.URLEncoder;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.function.Function;

Path outputDirectory = Paths.get("output");
String publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
Path storageDirectory = Paths.get("cdn-origin", "presentations", "quarterly-report");
Files.createDirectories(outputDirectory);
Files.createDirectories(storageDirectory);

Function<String, String> getFileNameFromLink = generatedLink -> {
    String urlCompatibleLink = generatedLink.replace('\\', '/');
    return urlCompatibleLink.substring(urlCompatibleLink.lastIndexOf('/') + 1);
};
Function<String, String> buildPublicUrl = fileName -> {
    try {
        String encodedFileName = URLEncoder.encode(fileName, "UTF-8").replace("+", "%20");
        return publicBaseUrl + "/" + encodedFileName;
    } catch (UnsupportedEncodingException exception) {
        System.err.println("Could not encode the image file name: " + exception.getMessage());
        return null;
    }
};

Presentation presentation = new Presentation("presentation.pptx");
try {
    MarkdownSaveOptions options = new MarkdownSaveOptions();
    options.setExportType(MarkdownExportType.Visual);
    options.setBasePath(outputDirectory.toString());
    options.setImagesSaveFolderName("fallback-images");

    options.setImageSaving((image, format, link) -> {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        image.save(storagePath.toString(), format);
        link[0] = publicUrl;
        return true;
    });

    options.setSvgImageSaving((svgImage, link) -> {
        String fileName = getFileNameFromLink.apply(link[0]);
        String publicUrl = buildPublicUrl.apply(fileName);
        if (publicUrl == null) {
            return false;
        }
        Path storagePath = storageDirectory.resolve(fileName);
        try {
            Files.write(storagePath, svgImage.getSvgData());
        } catch (IOException exception) {
            System.err.println("Could not save the SVG image: " + exception.getMessage());
            return false;
        }
        link[0] = publicUrl;
        return true;
    });

    Path markdownPath = outputDirectory.resolve("presentation.md");
    presentation.save(markdownPath.toString(), SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Handler bitmap cố ý trả về `false` cho các ảnh có kích thước nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu các ảnh đó vào `output/fallback-images` bằng hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như tài nguyên SVG, được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ được tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các handler chỉ sử dụng đường dẫn hệ điều hành khi ghi tệp; các liên kết được ghi vào Markdown sử dụng dấu gạch chéo `/` và các tên tệp đã được mã hoá URL. Áp dụng cùng quy tắc khi xây dựng liên kết tương đối: dùng `/`, không phải dấu phân cách thư mục đặc thù của nền tảng.

## **Câu hỏi thường gặp**

**Có một handler có thể xử lý cả ảnh raster và ảnh SVG không?**

Không. Sử dụng [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) cho các tài nguyên bitmap và metafile và [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) cho các tài nguyên được xuất dưới dạng SVG. Thứ nhất cung cấp đối tượng [IImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iimage/) và giá trị [ImageFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imageformat/); thứ hai cung cấp đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/) mà dữ liệu SVG có thể đọc bằng [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isvgimage/). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi callback lưu ảnh thay vì callback SVG.

**Điều gì xảy ra khi một handler lưu ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí ảnh và tham chiếu được tạo ra được kiểm soát bởi các giá trị được đặt bằng [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/markdownsaveoptions/).

**Handler có thể cung cấp URL mà không lưu ảnh cục bộ không?**

Có. Handler có thể tải ảnh lên lưu trữ đối tượng hoặc truyền cho dịch vụ khác, gán URL thu được cho `link[0]`, và trả về `true`. Handler phải tự thực hiện toàn bộ quá trình; trả về `true` ngăn hành vi lưu cục bộ mặc định.

**Tại sao việc xuất Markdown gây ra `InvalidOperationException` từ một handler?**

Ngoại lệ này xuất hiện khi handler trả về `true` nhưng không cung cấp một liên kết hợp lệ. Gán đường dẫn tương đối hoặc URL bên ngoài mà phải được ghi vào Markdown trước khi trả về `true`.

**Ký tự phân cách đường dẫn nào nên được sử dụng cho liên kết ảnh?**

Sử dụng dấu gạch chéo `/` trong các liên kết Markdown và URL. Dùng `Path.resolve` chỉ cho các đường dẫn hệ thống, sau đó tạo hoặc chuẩn hoá tham chiếu Markdown riêng biệt.

**Liên kết siêu văn bản có được giữ nguyên khi xuất Markdown không?**

Có. Các [liên kết siêu văn bản](/slides/vi/androidjava/manage-hyperlinks/) trong văn bản được giữ nguyên dưới dạng liên kết Markdown tiêu chuẩn. Các [chuyển động slide](/slides/vi/androidjava/slide-transition/) và [hiệu ứng hoạt ảnh](/slides/vi/androidjava/powerpoint-animation/) không được chuyển đổi.

**Có thể chuyển đổi nhiều bài thuyết trình sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bài thuyết trình khác nhau song song, nhưng không nên chia sẻ cùng một instance của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) giữa các luồng. Tuân theo [hướng dẫn đa luồng](/slides/vi/androidjava/multithreading/) và sử dụng một instance riêng cho mỗi tệp.