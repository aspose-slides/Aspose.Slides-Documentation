---
title: Xuất bản trình bày sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 100
url: /vi/androidjava/exporting-presentations-to-html-with-externally-linked-images/
keywords:
- xuất PowerPoint
- xuất OpenDocument
- xuất bản trình bày
- xuất slide
- xuất PPT
- xuất PPTX
- xuất ODP
- PowerPoint sang HTML
- OpenDocument sang HTML
- bản trình bày sang HTML
- slide sang HTML
- PPT sang HTML
- PPTX sang HTML
- ODP sang HTML
- hình ảnh được liên kết
- hình ảnh được liên kết bên ngoài
- tài nguyên được liên kết
- tài nguyên bên ngoài
- Android
- Java
- Aspose.Slides
description: "Xuất các bản trình bày PowerPoint và OpenDocument sang HTML trên Android bằng Java sử dụng Aspose.Slides, với hình ảnh và các tài nguyên khác được lưu dưới dạng tệp liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bản trình bày thành tệp HTML độc lập. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp di động duy nhất, nhưng không luôn là định dạng tốt nhất cho chế độ xem web, CMS, hoặc quy trình chuyển đổi phía máy chủ mà sau này sẽ công bố đầu ra.

Sử dụng tài nguyên liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu bộ nhớ đệm hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên được tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Convert PowerPoint Presentations to HTML](/slides/vi/androidjava/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động xuất tài nguyên có liên kết**

[ILinkEmbedController](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) cho phép ứng dụng của bạn quyết định, tài nguyên từng cái, liệu trình xuất nhúng dữ liệu vào HTML hay lưu nó bên ngoài và viết liên kết.

Giao diện có ba phương thức:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) quyết định tài nguyên có nên được liên kết hay nhúng.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) trả về URL sẽ được ghi vào HTML được tạo hoặc vào tài nguyên liên kết khác.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) ghi dữ liệu tài nguyên liên kết ra đĩa hoặc vào mục lưu trữ khác.

Đường dẫn hệ thống tệp và URL trình duyệt là hai vấn đề riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trong bộ nhớ tệp của ứng dụng, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt sẽ giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới tệp SVG sẽ sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới hình ảnh được lưu trong cùng thư mục `assets` sẽ dùng `resource-4.jpg`.

## **Xuất HTML với tài nguyên liên kết**

Ví dụ Android Java sau tạo thư mục đầu ra, lưu tệp HTML ở đó và lưu các tài nguyên liên kết trong thư mục con `assets`. Đưa một thư mục do ứng dụng sở hữu như `context.getFilesDir()` làm `applicationFilesDirectory`. Mã tránh các API `java.nio.file`, vì vậy vẫn tương thích với Android `minSdk` 19.

Bộ điều khiển sẽ liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS thông thường khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận diện sẽ vẫn được nhúng.

```java
import com.aspose.slides.HtmlFormatter;
import com.aspose.slides.HtmlOptions;
import com.aspose.slides.ILinkEmbedController;
import com.aspose.slides.LinkEmbedDecision;
import com.aspose.slides.Presentation;
import com.aspose.slides.SVGOptions;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.SlideImageFormat;

import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class ExportToHtmlWithLinkedResources {
    public static void exportPresentation(File applicationFilesDirectory) {
        if (applicationFilesDirectory == null) {
            throw new IllegalArgumentException("The application files directory must not be null.");
        }

        File inputFile = new File(applicationFilesDirectory, "presentation.pptx");
        File outputDirectory = new File(applicationFilesDirectory, "html-output");
        String assetDirectoryName = "assets";
        File assetDirectory = new File(outputDirectory, assetDirectoryName);

        createDirectory(outputDirectory, "HTML output");
        createDirectory(assetDirectory, "asset output");

        String assetUrlPrefix = assetDirectoryName + "/";
        ExternalResourceController controller = new ExternalResourceController(assetDirectory, assetUrlPrefix);
        SVGOptions svgOptions = new SVGOptions(controller);
        SlideImageFormat slideImageFormat = SlideImageFormat.svg(svgOptions);

        HtmlOptions htmlOptions = new HtmlOptions(controller);
        htmlOptions.setHtmlFormatter(HtmlFormatter.createDocumentFormatter("", false));
        htmlOptions.setSlideImageFormat(slideImageFormat);

        Presentation presentation = new Presentation(inputFile.getAbsolutePath());
        try {
            File htmlFile = new File(outputDirectory, "presentation.html");
            presentation.save(htmlFile.getAbsolutePath(), SaveFormat.Html, htmlOptions);
        } finally {
            presentation.dispose();
        }
    }

    private static final class ExternalResourceController implements ILinkEmbedController {
        private static final Map<String, String> EXTENSIONS_BY_CONTENT_TYPE = createExtensionsByContentType();

        private final File assetDirectory;
        private final String assetUrlPrefix;
        private final Map<Integer, String> fileNamesByResourceId = new HashMap<Integer, String>();

        private ExternalResourceController(File assetDirectory, String assetUrlPrefix) {
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

            createDirectory(assetDirectory, "asset output");

            File outputFile = new File(assetDirectory, fileName);
            FileOutputStream outputStream = null;
            try {
                outputStream = new FileOutputStream(outputFile);
                outputStream.write(entityData);
            } catch (IOException exception) {
                throw new IllegalStateException(
                        "Failed to save external resource " + resourceId +
                                " to " + outputFile.getAbsolutePath() + ".",
                        exception);
            } finally {
                closeOutputStream(outputStream, outputFile);
            }
        }

        private static Map<String, String> createExtensionsByContentType() {
            Map<String, String> extensionsByContentType = new HashMap<String, String>();
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
            if (contentType != null && !contentType.trim().equals("")) {
                String normalizedContentType = contentType.toLowerCase(Locale.US);
                String mappedExtension = EXTENSIONS_BY_CONTENT_TYPE.get(normalizedContentType);
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
            if (extension == null || extension.trim().equals("")) {
                return null;
            }

            String extensionCharacters = extension.trim();
            while (extensionCharacters.startsWith(".")) {
                extensionCharacters = extensionCharacters.substring(1);
            }

            if (extensionCharacters.equals("")) {
                return null;
            }

            int characterCount = extensionCharacters.length();
            for (int index = 0; index < characterCount; index++) {
                char character = extensionCharacters.charAt(index);
                if (!Character.isLetterOrDigit(character)) {
                    return null;
                }
            }

            return "." + extensionCharacters.toLowerCase(Locale.US);
        }

        private static String normalizeUrlPrefix(String urlPrefix) {
            if (urlPrefix == null || urlPrefix.equals("")) {
                return "";
            }

            String normalizedUrlPrefix = urlPrefix.replace('\\', '/');
            return normalizedUrlPrefix.endsWith("/")
                    ? normalizedUrlPrefix
                    : normalizedUrlPrefix + "/";
        }
    }

    private static void createDirectory(File directory, String description) {
        if (directory.exists()) {
            if (!directory.isDirectory()) {
                throw new IllegalStateException(
                        "The " + description + " path exists but is not a directory: " +
                                directory.getAbsolutePath());
            }

            return;
        }

        if (!directory.mkdirs()) {
            throw new IllegalStateException(
                    "Failed to create the " + description + " directory: " +
                            directory.getAbsolutePath());
        }
    }

    private static void closeOutputStream(FileOutputStream outputStream, File outputFile) {
        if (outputStream == null) {
            return;
        }

        try {
            outputStream.close();
        } catch (IOException exception) {
            throw new IllegalStateException(
                    "Failed to close the external resource file: " +
                            outputFile.getAbsolutePath(),
                    exception);
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

Các tệp chính xác phụ thuộc vào nội dung bản trình bày và tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn bộ mã hóa hình ảnh khác so với trong bản trình bày nguồn khi điều đó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Hình ảnh có độ trong suốt sẽ được xuất dưới dạng PNG.

## **Chọn URL cho việc triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu tới tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) và chỉ trả về tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu tới `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng tiền tố URL khác khi các tệp được triển khai ở nơi khác:

- Dùng `assets/` khi thư mục tài nguyên nằm cạnh tệp HTML.
- Dùng `../assets/` khi thư mục tài nguyên nằm một cấp trên tệp HTML.
- Dùng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL trả về bởi [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/) phải khớp với vị trí cuối cùng đã triển khai của tệp được ghi bởi [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/). Trong ứng dụng Android, sử dụng lưu trữ đặc thù cho ứng dụng, thư mục bộ nhớ đệm, hoặc thư mục lấy qua Storage Access Framework tùy theo quy trình công bố của bạn. Trong ứng dụng máy chủ, sử dụng thư mục đầu ra duy nhất hoặc tiền tố lưu trữ đối tượng cho mỗi công việc chuyển đổi để tránh ghi đè tệp từ một lần xuất khác.

## **Khi nào nên nhúng thay vì**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như tệp đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài nguyên hỗ trợ. Tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, tối ưu hóa qua quy trình xây dựng, hoặc được bộ nhớ đệm của trình duyệt lưu riêng biệt so với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách riêng hình ảnh ra bên ngoài và giữ các tài nguyên khác được nhúng không?**

Có. Trong [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilinkembedcontroller/), trả về `Link` từ [LinkEmbedDecision](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/linkembeddecision/) chỉ cho các loại nội dung bạn muốn lưu dưới dạng tệp riêng, và trả về `Embed` cho mọi thứ còn lại.

**Tại sao phần mở rộng hình ảnh xuất ra lại khác với bản trình bày nguồn?**

Aspose.Slides có thể mã lại lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc khả năng tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy theo kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

Các URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu tới `assets/resource-1.png`, thư mục `assets` phải ở cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Tôi có thể ghi tài nguyên vào bộ nhớ ngoài công cộng trên Android không?**

Có, nếu ứng dụng của bạn có đích đến hợp lệ và mô hình quyền phù hợp cho phiên bản Android mục tiêu. Đối với HTML được tạo chỉ dùng trong ứng dụng của bạn, các tệp đặc thù cho ứng dụng hoặc thư mục bộ nhớ đệm thường đơn giản hơn. Đối với đầu ra mà người dùng sẽ nhìn thấy, hãy sử dụng vị trí do người dùng chọn hoặc cách lưu trữ khác phù hợp với ứng dụng của bạn.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Sử dụng thư mục đầu ra hoặc tiền tố lưu trữ duy nhất cho mỗi công việc chuyển đổi. Điều này tránh xung đột tên tệp và ngăn một lần xuất ghi đè tài nguyên được tạo bởi lần xuất khác.