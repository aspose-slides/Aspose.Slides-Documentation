---
title: Chuyển đổi bản trình chiếu PowerPoint sang Markdown trong Java
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/java/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản trình chiếu
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản trình chiếu sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản trình chiếu dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- xuất ảnh Markdown
- liên kết ảnh CDN
- PowerPoint
- bản trình chiếu
- Markdown
- Java
- Aspose.Slides
description: "Chuyển đổi các bản trình chiếu PPT và PPTX sang Markdown trong Java và kiểm soát vị trí lưu và tham chiếu của các hình ảnh bitmap, metafile và SVG được xuất."
---
## **Tổng quan**

Aspose.Slides for Java có thể chuyển đổi các bản trình chiếu PPT và PPTX sang Markdown để sử dụng trong tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được hiển thị và quyết định nơi lưu trữ hình ảnh được xuất và cách Markdown tham chiếu tới chúng.

Mặc định, xuất Markdown chỉ tạo đầu ra dạng văn bản. Để xuất nội dung hình ảnh, hãy đặt kiểu xuất bằng phương thức [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) thành giá trị `Sequential` hoặc `Visual` từ enumeration [MarkdownExportType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownexporttype/). `Sequential` sẽ render các mục slide riêng biệt và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ thị giác. Giá trị `TextOnly` không tạo tài nguyên hình ảnh, vì vậy các callback lưu ảnh sẽ không được gọi ở chế độ này.

## **Chuyển đổi bản trình chiếu sang Markdown**

Tải file nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), sau đó gọi phương thức [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) với giá trị `Md` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveformat/).

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

## **Chọn kiểu Markdown**

Phương thức [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) điều khiển chuẩn Markdown được sử dụng cho đầu ra. Enumeration [Flavor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể hỗ trợ khác.

Ví dụ sau xuất bản trình chiếu dưới dạng CommonMark:

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

## **Xuất hình ảnh bằng hành vi lưu tạm mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) cung cấp hai phương thức để cấu hình việc lưu ảnh cục bộ:

- [setBasePath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) xác định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) xác định thư mục con chứa ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung hình ảnh, ghi ảnh vào `output/assets` và tạo các tham chiếu ảnh tương đối trong tài liệu Markdown:

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

Hành vi này cũng được dùng làm dự phòng khi một handler lưu ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh việc lưu ảnh và liên kết Markdown**

Sử dụng phương thức [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) để đăng ký callback cho các tài nguyên bitmap và metafile không phải SVG được tạo ra trong quá trình xuất Markdown. Callback `MarkdownImageSavingHandler` nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/), giá trị [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/) và liên kết Markdown được tạo dưới dạng một mảng `String[]` có một phần tử. Lưu hoặc tải lên ảnh với định dạng được cung cấp, và thay thế `link[0]` bằng tham chiếu cần xuất hiện trong kết quả Markdown.

Các tài nguyên được xuất dưới dạng SVG được xử lý riêng. Đăng ký callback bằng phương thức [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` nhận một đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) và mảng `String[] link` có một phần tử. SVG không có tham số `ImageFormat`; thay vào đó, ghi hoặc tải lên dữ liệu XML của nó từ phương thức [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/). Tùy thuộc vào chế độ xuất và cách nhóm hình ảnh, một SVG trong bản trình chiếu nguồn có thể được raster hoá hoặc kết hợp với nội dung khác; tài nguyên không phải SVG sau đó sẽ được truyền tới callback lưu ảnh. Hãy đăng ký cả hai callback khi mọi tài nguyên hình ảnh xuất cần xử lý tùy chỉnh.

Giá trị trả về của handler quyết định ai sẽ xử lý ảnh:

- Trả về `true` sau khi handler đã lưu, tải lên, chuyển đổi hoặc xử lý ảnh và đã gán giá trị hợp lệ cho `link[0]`. Aspose.Slides sẽ ghi giá trị này vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để cho phép Aspose.Slides lưu ảnh cục bộ và tạo liên kết dựa trên các giá trị được đặt bởi [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Quan trọng" %}}
Một handler trả về `true` sẽ chịu trách nhiệm đối với ảnh. Nếu nó trả về `true` mà không gán một liên kết hợp lệ, không rỗng, quá trình xuất sẽ thất bại với `InvalidOperationException`.
{{% /alert %}}

### **Lưu ảnh vào thư mục gốc CDN và sử dụng URL bên ngoài**

Ví dụ sau coi `cdn-origin/presentations/quarterly-report` là một thư mục gốc CDN đã được gắn hoặc đồng bộ. Mỗi handler sẽ trích xuất tên file đã tạo, lưu ảnh vào thư mục tùy chỉnh đó và thay thế tham chiếu cục bộ bằng URL CDN công khai. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các file được công bố lên CDN. Đối với lưu trữ đối tượng, hãy thay thế việc ghi file hệ thống bằng thao tác tải lên của SDK lưu trữ và chỉ gán `link[0]` sau khi việc tải lên thành công.

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

Handler bitmap cố tình trả về `false` cho các ảnh nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu những ảnh này vào `output/fallback-images` theo hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như các tài nguyên SVG, sẽ được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ được tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các handler chỉ sử dụng đường dẫn hệ điều hành khi ghi file; các liên kết ghi vào Markdown luôn dùng dấu gạch chéo `/` và tên file đã được mã hoá URL. Áp dụng quy tắc tương tự khi xây dựng liên kết tương đối: dùng `/`, không dùng ký tự phân cách thư mục đặc thù của nền tảng.

## **Câu hỏi thường gặp**

**Một handler có thể xử lý cả ảnh raster và SVG không?**

Không. Sử dụng [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) cho các tài nguyên bitmap và metafile, và [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) cho các tài nguyên được xuất dưới dạng SVG. Phương thức đầu tiên cung cấp đối tượng [IImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iimage/) và giá trị [ImageFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imageformat/); phương thức thứ hai cung cấp đối tượng [ISvgImage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/) mà dữ liệu SVG có thể đọc bằng [ISvgImage.getSvgData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isvgimage/). Một SVG nguồn bị raster hoá trong quá trình xuất sẽ được xử lý bởi callback lưu ảnh thay vì callback SVG.

**Xảy ra gì khi một handler lưu ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí ảnh và liên kết được tạo ra được điều khiển bằng các giá trị được đặt bởi [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/markdownsaveoptions/).

**Handler có thể cung cấp URL mà không lưu ảnh cục bộ không?**

Có. Handler có thể tải ảnh lên lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL thu được cho `link[0]` và trả về `true`. Handler phải tự hoàn thành toàn bộ quá trình; việc trả về `true` sẽ ngăn hành vi lưu cục bộ mặc định.

**Tại sao quá trình xuất Markdown lại ném `InvalidOperationException` từ một handler?**

Ngoại lệ này xảy ra khi handler trả về `true` nhưng không cung cấp một liên kết hợp lệ. Hãy gán đường dẫn tương đối hoặc URL bên ngoài cần ghi vào Markdown trước khi trả về `true`.

**Dấu phân cách đường dẫn nào nên dùng cho liên kết ảnh?**

Sử dụng dấu gạch chéo `/` trong các liên kết Markdown và URL. Dùng `Path.resolve` chỉ cho các đường dẫn hệ thống, sau đó tự xây dựng hoặc chuẩn hoá tham chiếu Markdown riêng.

**Liên kết siêu văn bản có được giữ lại khi xuất Markdown không?**

Có. Các [hyperlinks](/slides/vi/java/manage-hyperlinks/) trong văn bản được giữ dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/java/slide-transition/) và [animations](/slides/vi/java/powerpoint-animation/) của slide không được chuyển đổi.

**Có thể chuyển đổi nhiều bản trình chiếu sang Markdown đồng thời không?**

Bạn có thể xử lý các file bản trình chiếu khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) giữa các luồng. Hãy tuân theo [multithreading guidelines](/slides/vi/java/multithreading/) và tạo một thể hiện riêng cho mỗi file.