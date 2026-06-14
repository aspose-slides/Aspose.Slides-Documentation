---
title: Xuất Bản Trình Chiếu sang HTML với Hình Ảnh Được Liên Kết Bên Ngoài
type: docs
weight: 100
url: /vi/php-java/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình chiếu
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bản trình chiếu sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh liên kết
- hình ảnh liên kết bên ngoài
- tài nguyên liên kết
- tài nguyên bên ngoài
- PHP
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML trong PHP thông qua Java bằng Aspose.Slides với hình ảnh và các tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bản trình chiếu thành tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp di động duy nhất, nhưng không luôn là định dạng tốt nhất cho một trang web, CMS, hoặc quy trình chuyển đổi phía máy chủ.

- giảm kích thước của tài liệu HTML;
- lưu vào bộ nhớ cache hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên đã tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Convert PowerPoint Presentations to HTML](/slides/vi/php-java/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động của xuất tài nguyên liên kết**

[HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/) có thể sử dụng bộ điều khiển liên kết/nhúng tùy chỉnh khi Aspose.Slides xuất bản trình chiếu thành HTML. Trong PHP thông qua Java, kịch bản này thường được triển khai bằng một lớp trợ giúp Java nhỏ. Biên dịch lớp trợ giúp đó, thêm nó vào classpath của PHP Java Bridge, và tạo thể hiện từ PHP bằng `new Java(...)`.

Lớp trợ giúp quyết định, tài nguyên từng tài nguyên, liệu bộ xuất có nhúng dữ liệu vào HTML hay lưu bên ngoài và ghi một liên kết. Nó cần ba phương thức callback:

- `ExternalResourceController.getObjectStoringLocation` quyết định tài nguyên nào nên được liên kết hoặc nhúng.
- `ExternalResourceController.getUrl` trả về URL sẽ được ghi vào HTML đã tạo hoặc vào tài nguyên liên kết khác.
- `ExternalResourceController.saveExternal` ghi dữ liệu tài nguyên liên kết ra đĩa hoặc vào mục tiêu lưu trữ khác.

Đường dẫn hệ thống tệp và URL trình duyệt là hai mối quan tâm riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới tệp SVG sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới hình ảnh lưu trong cùng thư mục `assets` sử dụng `resource-4.jpg`.

## **Tạo lớp trợ giúp Java**

Tạo một lớp Java như `com.example.slides.ExternalResourceController`, biên dịch nó với Aspose.Slides cho Java trên classpath, và cung cấp lớp đã biên dịch hoặc JAR cho PHP Java Bridge.

Lớp trợ giúp dưới đây liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

```java
package com.example.slides;

import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public final class ExternalResourceController implements ILinkEmbedController {
    private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionMap();

    private final Path assetDirectory;
    private final String assetUrlPrefix;
    private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

    public ExternalResourceController(String assetDirectory, String assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().isEmpty()) {
            throw new IllegalArgumentException("The asset output directory must not be empty.");
        }

        this.assetDirectory = Paths.get(assetDirectory);
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
    }

    @Override
    public int getObjectStoringLocation(
            int resourceId,
            byte[] entityData,
            String semanticName,
            String contentType,
            String recommendedExtension) {
        String extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return LinkEmbedDecision.Embed;
        }

        fileNamesByResourceId.put(resourceId, "resource-" + resourceId + extension);
        return LinkEmbedDecision.Link;
    }

    @Override
    public String getUrl(int resourceId, int referrer) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (fileNamesByResourceId.containsKey(referrer)) {
            return fileName;
        }

        return assetUrlPrefix + fileName;
    }

    @Override
    public void saveExternal(int resourceId, byte[] entityData) {
        String fileName = fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length == 0) {
            throw new IllegalStateException(
                    "Resource " + resourceId + " contains no data and cannot be saved.");
        }

        Path filePath = assetDirectory.resolve(fileName);
        try {
            Files.createDirectories(assetDirectory);
            Files.write(filePath, entityData);
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Could not save linked resource " + resourceId + " to " + filePath + ".",
                    exception);
        }
    }

    private static Map<String, String> createExtensionMap() {
        Map<String, String> extensions = new HashMap<>();
        extensions.put("image/jpeg", ".jpg");
        extensions.put("image/png", ".png");
        extensions.put("image/gif", ".gif");
        extensions.put("image/bmp", ".bmp");
        extensions.put("image/svg+xml", ".svg");
        extensions.put("image/tiff", ".tiff");
        extensions.put("image/x-emf", ".emf");
        extensions.put("image/x-wmf", ".wmf");
        extensions.put("font/woff", ".woff");
        extensions.put("font/woff2", ".woff2");
        extensions.put("font/ttf", ".ttf");
        extensions.put("application/font-woff", ".woff");
        extensions.put("application/vnd.ms-fontobject", ".eot");
        extensions.put("application/x-font-ttf", ".ttf");
        extensions.put("text/css", ".css");
        extensions.put("audio/mpeg", ".mp3");
        extensions.put("audio/mp4", ".m4a");
        extensions.put("audio/wav", ".wav");
        extensions.put("video/mp4", ".mp4");
        extensions.put("video/webm", ".webm");
        return extensions;
    }

    private static String resolveExtension(String contentType, String recommendedExtension) {
        if (contentType != null && !contentType.trim().isEmpty()) {
            String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(contentType);
            if (mappedExtension != null) {
                return mappedExtension;
            }
        }

        if (!isSupportedContentType(contentType)) {
            return null;
        }

        return normalizeExtension(recommendedExtension);
    }

    private static boolean isSupportedContentType(String contentType) {
        return contentType != null &&
                (contentType.regionMatches(true, 0, "image/", 0, 6) ||
                 contentType.regionMatches(true, 0, "font/", 0, 5) ||
                 contentType.regionMatches(true, 0, "audio/", 0, 6) ||
                 contentType.regionMatches(true, 0, "video/", 0, 6));
    }

    private static String normalizeExtension(String extension) {
        if (extension == null || extension.trim().isEmpty()) {
            return null;
        }

        String extensionCharacters = extension.trim();
        while (extensionCharacters.startsWith(".")) {
            extensionCharacters = extensionCharacters.substring(1);
        }

        for (int characterIndex = 0; characterIndex < extensionCharacters.length(); characterIndex++) {
            if (!Character.isLetterOrDigit(extensionCharacters.charAt(characterIndex))) {
                return null;
            }
        }

        return "." + extensionCharacters.toLowerCase(Locale.ROOT);
    }

    private static String normalizeUrlPrefix(String urlPrefix) {
        if (urlPrefix == null || urlPrefix.isEmpty()) {
            return "";
        }

        String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
        return normalizedUrlPrefix.endsWith("/")
                ? normalizedUrlPrefix
                : normalizedUrlPrefix + "/";
    }
}
```

## **Xuất HTML với các tài nguyên liên kết**

Mã PHP sau tạo một thư mục đầu ra, lưu tệp HTML vào đó, và lưu các tài nguyên liên kết trong thư mục con `assets`. Nó kết hợp [HtmlOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/htmloptions/), [SVGOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/svgoptions/), [SlideImageFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/slideimageformat/), và [SaveFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/saveformat/) cho việc xuất.

```php
$inputFilePath = "presentation.pptx";
$outputDirectory = "html-output";
$assetDirectoryName = "assets";
$assetDirectory = $outputDirectory . DIRECTORY_SEPARATOR . $assetDirectoryName;

if (!is_dir($outputDirectory) && !mkdir($outputDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the HTML output directory: " . $outputDirectory);
}

if (!is_dir($assetDirectory) && !mkdir($assetDirectory, 0777, true)) {
    throw new RuntimeException("Could not create the asset output directory: " . $assetDirectory);
}

$assetUrlPrefix = $assetDirectoryName . "/";
$controller = new Java("com.example.slides.ExternalResourceController", $assetDirectory, $assetUrlPrefix);
$svgOptions = new SVGOptions($controller);
$slideImageFormat = SlideImageFormat::svg($svgOptions);

$htmlOptions = new HtmlOptions($controller);
$htmlFormatter = java("com.aspose.slides.HtmlFormatter")->createDocumentFormatter("", false);
$htmlOptions->setHtmlFormatter($htmlFormatter);
$htmlOptions->setSlideImageFormat($slideImageFormat);

$presentation = new Presentation($inputFilePath);
try {
    $htmlFilePath = $outputDirectory . DIRECTORY_SEPARATOR . "presentation.html";
    $presentation->save($htmlFilePath, SaveFormat::Html, $htmlOptions);
} finally {
    $presentation->dispose();
}
```

Sau khi xuất, thư mục đầu ra có cấu trúc sau:

```text
html-output/
  presentation.html
  assets/
    resource-1.svg
    resource-2.svg
    resource-3.svg
    resource-4.jpg
    resource-5.png
```

Các tệp cụ thể phụ thuộc vào nội dung bản trình chiếu và tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn codec hình ảnh khác so với codec được sử dụng trong bản trình chiếu gốc khi điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Các hình ảnh có độ trong suốt được xuất dưới dạng PNG.

## **Chọn URL cho việc triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu đến tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong `ExternalResourceController.getUrl` và chỉ trả về tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu tới `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng tiền tố URL khác khi các tệp được triển khai ở vị trí khác:

- Sử dụng `assets/` khi thư mục tài nguyên nằm cạnh tệp HTML.
- Sử dụng `../assets/` khi thư mục tài nguyên nằm một cấp trên tệp HTML.
- Sử dụng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL trả về bởi `ExternalResourceController.getUrl` phải khớp với vị trí triển khai cuối cùng của tệp được ghi bởi `ExternalResourceController.saveExternal`. Trong các ứng dụng máy chủ, sử dụng thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh ghi đè các tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài nguyên hỗ trợ. Các tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, được tối ưu hóa bằng quy trình xây dựng, hoặc được trình duyệt cache một cách độc lập với HTML.

## **FAQ**

**Tôi có thể chỉ tách riêng hình ảnh và giữ các tài nguyên khác được nhúng không?**

Đúng. Trong `ExternalResourceController.getObjectStoringLocation`, trả về giá trị `Link` từ [LinkEmbedDecision](https://reference.aspose.com/slides/vi/php-java/aspose.slides/linkembeddecision/) chỉ cho các loại nội dung bạn muốn lưu dưới dạng tệp riêng biệt, và trả về giá trị `Embed` cho các phần còn lại.

**Tại sao phần mở rộng hình ảnh xuất ra khác với bản trình chiếu nguồn?**

Aspose.Slides có thể mã hóa lại hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc tính tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

Các URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu đến `assets/resource-1.png`, thư mục `assets` phải nằm cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên sử dụng lại cùng một thư mục đầu ra không?**

Không. Sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh va chạm tên tệp và ngăn một lần xuất ghi đè tài nguyên được tạo bởi một lần xuất khác.