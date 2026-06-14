---
title: Xuất bản trình chiếu sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 100
url: /vi/java/exporting-presentations-to-html-with-externally-linked-images/
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
- hình ảnh được liên kết
- hình ảnh được liên kết bên ngoài
- tài nguyên được liên kết
- tài nguyên bên ngoài
- Java
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML trong Java bằng Aspose.Slides với hình ảnh và các tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Theo mặc định, Aspose.Slides xuất bản trình chiếu thành một tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp duy nhất có thể di chuyển, nhưng không phải lúc nào cũng là định dạng tốt nhất cho một trang web, CMS, hoặc quy trình chuyển đổi phía máy chủ.

Sử dụng tài nguyên liên kết bên ngoài khi bạn muốn:
- giảm kích thước của tài liệu HTML;
- lưu bộ nhớ đệm hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý sau các tài nguyên được tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Convert PowerPoint Presentations to HTML](/slides/vi/java/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động của xuất tài nguyên liên kết**

[ILinkEmbedController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) cho phép ứng dụng của bạn quyết định, từng tài nguyên một, liệu trình xuất có nhúng dữ liệu vào HTML hay lưu bên ngoài và ghi một liên kết.

Giao diện này có ba phương thức:
- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) quyết định một tài nguyên nên được liên kết hay nhúng.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) trả về URL sẽ được ghi vào HTML được tạo hoặc vào tài nguyên liên kết khác.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) ghi dữ liệu tài nguyên liên kết ra đĩa hoặc vào mục tiêu lưu trữ khác.

Đường dẫn hệ thống tệp và URL trình duyệt là hai mối quan tâm riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt sẽ giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới tệp SVG sẽ dùng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới hình ảnh được lưu trong cùng thư mục `assets` sẽ dùng `resource-4.jpg`.

## **Xuất HTML với tài nguyên liên kết**

Mẫu Java sau tạo một thư mục đầu ra, lưu tệp HTML vào đó và lưu các tài nguyên liên kết trong một thư mục con `assets`. Bộ điều khiển sẽ liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void main(String[] args) throws IOException {
        Path inputFilePath = Paths.get("presentation.pptx");
        Path outputDirectory = Paths.get("html-output");
        String assetDirectoryName = "assets";
        Path assetDirectory = outputDirectory.resolve(assetDirectoryName);

        Files.createDirectories(outputDirectory);
        Files.createDirectories(assetDirectory);

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFilePath.toString());
        try {
            Path htmlFilePath = outputDirectory.resolve("presentation.html");
            presentation.save(htmlFilePath.toString(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final Path assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<>();

        private ExternalResourceController(Path assetDirectory, String assetUrlPrefix) {
            if (assetDirectory == null) {
                throw new IllegalArgumentException("The asset output directory must not be null.");
            }

            this.assetDirectory = assetDirectory;
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

            try {
                Files.createDirectories(assetDirectory);
                Path filePath = assetDirectory.resolve(fileName);
                Files.write(filePath, entityData);
            } catch (IOException exception) {
                throw new IllegalStateException("Failed to save external resource " + resourceId + ".", exception);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<>();
            extensionsByContentType.put("image/jpeg", ".jpg");
            extensionsByContentType.put("image/png", ".png");
            extensionsByContentType.put("image/gif", ".gif");
            extensionsByContentType.put("image/bmp", ".bmp");
            extensionsByContentType.put("image/svg+xml", ".svg");
            extensionsByContentType.put("image/tiff", ".tiff");
            extensionsByContentType.put("image/x-emf", ".emf");
            extensionsByContentType.put("image/x-wmf", ".wmf");
            extensionsByContentType.put("font/woff", ".woff");
            extensionsByContentType.put("font/woff2", ".woff2");
            extensionsByContentType.put("font/ttf", ".ttf");
            extensionsByContentType.put("application/font-woff", ".woff");
            extensionsByContentType.put("application/vnd.ms-fontobject", ".eot");
            extensionsByContentType.put("application/x-font-ttf", ".ttf");
            extensionsByContentType.put("text/css", ".css");
            extensionsByContentType.put("audio/mpeg", ".mp3");
            extensionsByContentType.put("audio/mp4", ".m4a");
            extensionsByContentType.put("audio/wav", ".wav");
            extensionsByContentType.put("video/mp4", ".mp4");
            extensionsByContentType.put("video/webm", ".webm");
            return extensionsByContentType;
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
                    (contentType.regionMatches(true, 0, "image/", 0, "image/".length()) ||
                     contentType.regionMatches(true, 0, "font/", 0, "font/".length()) ||
                     contentType.regionMatches(true, 0, "audio/", 0, "audio/".length()) ||
                     contentType.regionMatches(true, 0, "video/", 0, "video/".length()));
        }

        private static String normalizeExtension(String extension) {
            if (extension == null || extension.trim().isEmpty()) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.isEmpty()) {
                return null;
            }

            for (int index = 0; index < extensionCharacters.length(); index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
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
}
```

Sau khi xuất, thư mục đầu ra có cấu trúc như sau:

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

Các tệp cụ thể phụ thuộc vào nội dung bản trình chiếu và các tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn một codec ảnh khác so với codec được sử dụng trong bản trình chiếu gốc nếu điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Các hình ảnh có độ trong suốt sẽ được xuất dưới dạng PNG.

## **Chọn URL cho việc triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu tới tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) và trả về chỉ tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu tới `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng một tiền tố URL khác khi các tệp được triển khai ở nơi khác:
- Sử dụng `assets/` khi thư mục tài nguyên nằm bên cạnh tệp HTML.
- Sử dụng `../assets/` khi thư mục tài nguyên nằm một cấp trên tệp HTML.
- Sử dụng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tĩnh.

URL được trả về bởi [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) phải khớp với vị trí triển khai cuối cùng của tệp được ghi bởi [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/). Trong các ứng dụng máy chủ, hãy sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh việc ghi đè các tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì liên kết**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước offline, hoặc tài liệu sẽ được chuyển mà không có thư mục tài nguyên hỗ trợ. Các tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trong CMS, tối ưu hóa bằng quy trình xây dựng, hoặc được trình duyệt lưu bộ nhớ đệm một cách độc lập so với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách riêng hình ảnh ra bên ngoài và giữ các tài nguyên khác được nhúng không?**

Có. Trong [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/), trả về `LinkEmbedDecision.Link` chỉ cho các loại nội dung bạn muốn lưu dưới dạng tệp riêng, và trả về `LinkEmbedDecision.Embed` cho mọi thứ khác.

**Tại sao phần mở rộng ảnh xuất ra lại khác với bản trình chiếu nguồn?**

Aspose.Slides có thể mã hoá lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc khả năng tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu tới `assets/resource-1.png`, thư mục `assets` phải nằm bên cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Hãy sử dụng một thư mục đầu ra duy nhất hoặc tiền tố lưu trữ cho mỗi công việc chuyển đổi. Điều này tránh va chạm tên tệp và ngăn một lần xuất ghi đè lên tài nguyên được tạo bởi một lần xuất khác.