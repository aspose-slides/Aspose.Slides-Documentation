---
title: Xuất bản trình chiếu sang HTML với hình ảnh được liên kết bên ngoài
type: docs
weight: 100
url: /vi/nodejs-java/exporting-presentations-to-html-with-externally-linked-images/
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
- JavaScript
- Node.js
- Aspose.Slides
description: "Xuất bản trình chiếu PowerPoint và OpenDocument sang HTML trong JavaScript bằng cách sử dụng Aspose.Slides cho Node.js thông qua Java, với các hình ảnh và tài nguyên khác được lưu dưới dạng tệp được liên kết bên ngoài."
---
## **Tổng quan**

Mặc định, Aspose.Slides xuất một bản trình chiếu thành tệp HTML tự chứa. Hình ảnh và các tài nguyên khác được ghi trực tiếp vào HTML, thường dưới dạng dữ liệu Base64. Điều này thuận tiện khi bạn cần một tệp di động duy nhất, nhưng không phải luôn là định dạng tốt nhất cho một trang web, CMS hoặc quy trình chuyển đổi phía máy chủ.

Sử dụng tài nguyên được liên kết bên ngoài khi bạn muốn:

- giảm kích thước của tài liệu HTML;
- lưu bộ nhớ đệm hình ảnh, phông chữ, âm thanh hoặc video riêng biệt trong trình duyệt hoặc CDN;
- kiểm tra, thay thế, nén hoặc xử lý hậu kỳ các tài nguyên đã tạo sau khi xuất;
- giữ cấu trúc đầu ra gần hơn với những gì một ứng dụng web mong đợi.

Đối với quy trình chuyển đổi HTML chung, xem [Convert PowerPoint Presentations to HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/). Bài viết này tập trung vào phần liên kết tài nguyên của quá trình xuất.

## **Cách hoạt động xuất tài nguyên liên kết**

Một proxy Java cho [ILinkEmbedController](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) cho phép ứng dụng của bạn quyết định, từng tài nguyên một, việc exporter sẽ nhúng dữ liệu vào HTML hay lưu bên ngoài và ghi một liên kết.

Bộ điều khiển có ba phương thức:

- [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) quyết định một tài nguyên nên được liên kết hay nhúng.
- [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) trả về URL sẽ được ghi vào HTML đã tạo hoặc vào một tài nguyên liên kết khác.
- [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) ghi dữ liệu tài nguyên liên kết ra đĩa hoặc tới một mục lưu trữ khác.

Đường dẫn hệ thống tệp và URL trình duyệt là hai khía cạnh riêng biệt. Ví dụ, mẫu dưới đây ghi các tệp tài nguyên vào `html-output/assets` trên đĩa, trong khi HTML chứa các URL tương đối như `assets/resource-1.svg`. Trình duyệt sẽ giải quyết các URL này dựa trên tệp chứa liên kết. Do đó, một liên kết từ `presentation.html` tới một tệp SVG sẽ sử dụng `assets/resource-1.svg`, trong khi một liên kết từ tệp SVG đó tới một hình ảnh lưu trong cùng thư mục `assets` sẽ sử dụng `resource-4.jpg`.

## **Xuất HTML với tài nguyên liên kết**

Ví dụ JavaScript sau tạo một thư mục đầu ra, lưu tệp HTML ở đó và lưu các tài nguyên liên kết trong thư mục con `assets`. Bộ điều khiển sẽ liên kết các tài nguyên hình ảnh, phông chữ, âm thanh, video và CSS phổ biến khi Aspose.Slides cung cấp hoặc có thể suy ra phần mở rộng tệp an toàn. Các tài nguyên không được nhận dạng sẽ vẫn được nhúng.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

class ExternalResourceController {
    constructor(assetDirectory, assetUrlPrefix) {
        if (assetDirectory == null || assetDirectory.trim().length === 0) {
            throw new Error("The asset output directory must not be empty.");
        }

        this.assetDirectory = assetDirectory;
        this.assetUrlPrefix = normalizeUrlPrefix(assetUrlPrefix);
        this.fileNamesByResourceId = new Map();
    }

    createProxy() {
        const linkEmbedControllerInterfaceName = "com.aspose.slides.ILinkEmbedController";
        let controller = this;
        return java.newProxy(linkEmbedControllerInterfaceName, {
            getObjectStoringLocation: function(resourceId, entityData, semanticName, contentType, recommendedExtension) {
                return controller.getObjectStoringLocation(
                    resourceId,
                    entityData,
                    semanticName,
                    contentType,
                    recommendedExtension);
            },
            getUrl: function(resourceId, referrer) {
                return controller.getUrl(resourceId, referrer);
            },
            saveExternal: function(resourceId, entityData) {
                controller.saveExternal(resourceId, entityData);
            }
        });
    }

    getObjectStoringLocation(resourceId, entityData, semanticName, contentType, recommendedExtension) {
        let extension = resolveExtension(contentType, recommendedExtension);
        if (extension == null) {
            return aspose.slides.LinkEmbedDecision.Embed;
        }

        this.fileNamesByResourceId.set(resourceId, "resource-" + resourceId + extension);
        return aspose.slides.LinkEmbedDecision.Link;
    }

    getUrl(resourceId, referrer) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            return null;
        }

        if (this.fileNamesByResourceId.has(referrer)) {
            return fileName;
        }

        return this.assetUrlPrefix + fileName;
    }

    saveExternal(resourceId, entityData) {
        let fileName = this.fileNamesByResourceId.get(resourceId);
        if (fileName == null) {
            throw new Error("Resource " + resourceId + " was not registered for external storage.");
        }

        if (entityData == null || entityData.length === 0) {
            throw new Error("Resource " + resourceId + " contains no data and cannot be saved.");
        }

        fs.mkdirSync(this.assetDirectory, { recursive: true });

        let filePath = path.join(this.assetDirectory, fileName);
        let fileData = Buffer.from(entityData);
        fs.writeFileSync(filePath, fileData);
    }
}

function createExtensionsByContentType() {
    let extensionsByContentType = new Map();
    extensionsByContentType.set("image/jpeg", ".jpg");
    extensionsByContentType.set("image/png", ".png");
    extensionsByContentType.set("image/gif", ".gif");
    extensionsByContentType.set("image/bmp", ".bmp");
    extensionsByContentType.set("image/svg+xml", ".svg");
    extensionsByContentType.set("image/tiff", ".tiff");
    extensionsByContentType.set("image/x-emf", ".emf");
    extensionsByContentType.set("image/x-wmf", ".wmf");
    extensionsByContentType.set("font/woff", ".woff");
    extensionsByContentType.set("font/woff2", ".woff2");
    extensionsByContentType.set("font/ttf", ".ttf");
    extensionsByContentType.set("application/font-woff", ".woff");
    extensionsByContentType.set("application/vnd.ms-fontobject", ".eot");
    extensionsByContentType.set("application/x-font-ttf", ".ttf");
    extensionsByContentType.set("text/css", ".css");
    extensionsByContentType.set("audio/mpeg", ".mp3");
    extensionsByContentType.set("audio/mp4", ".m4a");
    extensionsByContentType.set("audio/wav", ".wav");
    extensionsByContentType.set("video/mp4", ".mp4");
    extensionsByContentType.set("video/webm", ".webm");
    return extensionsByContentType;
}

let extensionsByContentType = createExtensionsByContentType();

function resolveExtension(contentType, recommendedExtension) {
    if (contentType != null && contentType.trim().length > 0) {
        let mappedExtension = extensionsByContentType.get(contentType);
        if (mappedExtension != null) {
            return mappedExtension;
        }
    }

    if (!isSupportedContentType(contentType)) {
        return null;
    }

    return normalizeExtension(recommendedExtension);
}

function isSupportedContentType(contentType) {
    if (contentType == null) {
        return false;
    }

    let normalizedContentType = contentType.toLowerCase();
    return normalizedContentType.startsWith("image/") ||
        normalizedContentType.startsWith("font/") ||
        normalizedContentType.startsWith("audio/") ||
        normalizedContentType.startsWith("video/");
}

function normalizeExtension(extension) {
    if (extension == null || extension.trim().length === 0) {
        return null;
    }

    let extensionCharacters = extension.trim();
    while (extensionCharacters.startsWith(".")) {
        extensionCharacters = extensionCharacters.substring(1);
    }

    if (extensionCharacters.length === 0) {
        return null;
    }

    for (let index = 0; index < extensionCharacters.length; index++) {
        let character = extensionCharacters[index];
        if (!/[A-Za-z0-9]/.test(character)) {
            return null;
        }
    }

    return "." + extensionCharacters.toLowerCase();
}

function normalizeUrlPrefix(urlPrefix) {
    if (urlPrefix == null || urlPrefix.length === 0) {
        return "";
    }

    let normalizedUrlPrefix = urlPrefix.replace(/\\/g, "/");
    return normalizedUrlPrefix.endsWith("/")
        ? normalizedUrlPrefix
        : normalizedUrlPrefix + "/";
}

let inputFilePath = "presentation.pptx";
let outputDirectory = "html-output";
let assetDirectoryName = "assets";
let assetDirectory = path.join(outputDirectory, assetDirectoryName);

fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(assetDirectory, { recursive: true });

let assetUrlPrefix = assetDirectoryName + "/";
let controllerWrapper = new ExternalResourceController(assetDirectory, assetUrlPrefix);
let controller = controllerWrapper.createProxy();
let svgOptions = new aspose.slides.SVGOptions(controller);
let slideImageFormat = aspose.slides.SlideImageFormat.svg(svgOptions);

let htmlOptions = new aspose.slides.HtmlOptions(controller);
htmlOptions.setHtmlFormatter(aspose.slides.HtmlFormatter.createDocumentFormatter("", false));
htmlOptions.setSlideImageFormat(slideImageFormat);

let presentation = new aspose.slides.Presentation(inputFilePath);
try {
    let htmlFilePath = path.join(outputDirectory, "presentation.html");
    presentation.save(htmlFilePath, aspose.slides.SaveFormat.Html, htmlOptions);
} finally {
    if (presentation != null) {
        presentation.dispose();
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

Các tệp cụ thể phụ thuộc vào nội dung bản trình chiếu và các tùy chọn xuất. Ví dụ, hình ảnh raster thường được xuất dưới dạng JPEG hoặc PNG. Aspose.Slides có thể chọn một codec hình ảnh khác với codec dùng trong bản trình chiếu nguồn nếu như nó tạo ra tệp nhỏ hơn hoặc phù hợp hơn. Các hình ảnh có độ trong suốt sẽ được xuất dưới dạng PNG.

## **Chọn URL cho triển khai**

Mẫu sử dụng tiền tố URL tương đối: `assets/`. Nếu `presentation.html` được mở từ `html-output/presentation.html`, trình duyệt sẽ tải `html-output/assets/resource-1.svg`.

Khi một tài nguyên liên kết tham chiếu tới tài nguyên liên kết khác, mẫu sử dụng tham số `referrer` trong [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) và trả về chỉ tên tệp. Ví dụ, nếu `resource-1.svg` và `resource-4.jpg` đều nằm trong thư mục `assets`, tệp SVG nên tham chiếu tới `resource-4.jpg`, không phải `assets/resource-4.jpg`.

Sử dụng một tiền tố URL khác khi các tệp được triển khai ở nơi khác:

- Dùng `assets/` khi thư mục tài nguyên nằm cùng cấp với tệp HTML.
- Dùng `../assets/` khi thư mục tài nguyên nằm một cấp trên tệp HTML.
- Dùng `https://cdn.example.com/presentations/job-123/assets/` khi các tệp được tải lên CDN hoặc máy chủ tệp tĩnh.

URL trả về bởi [ILinkEmbedController.getUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/) phải khớp với vị trí cuối cùng mà tệp được ghi bởi [ILinkEmbedController.saveExternal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/). Trong các ứng dụng máy chủ, sử dụng một thư mục đầu ra hoặc tiền tố lưu trữ đối tượng duy nhất cho mỗi công việc chuyển đổi để tránh ghi đè lên các tệp của lần xuất khác.

## **Khi nào nên nhúng thay vì**

HTML nhúng Base64 vẫn hữu ích khi đầu ra phải là một tệp duy nhất, chẳng hạn như đính kèm email, bản xem trước ngoại tuyến, hoặc tài liệu sẽ được di chuyển mà không có thư mục tài nguyên hỗ trợ. Các tài nguyên liên kết phù hợp hơn khi HTML sẽ được phục vụ bởi một ứng dụng web, lưu trữ trong CMS, tối ưu hoá qua quy trình xây dựng, hoặc được các trình duyệt lưu bộ nhớ đệm độc lập với HTML.

## **Câu hỏi thường gặp**

**Tôi có thể chỉ tách hình ảnh ra ngoài và giữ các tài nguyên khác được nhúng không?**

Có. Trong [ILinkEmbedController.getObjectStoringLocation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ilinkembedcontroller/), trả về `LinkEmbedDecision.Link` chỉ cho các kiểu nội dung bạn muốn lưu dưới dạng tệp riêng, và trả về `LinkEmbedDecision.Embed` cho mọi thứ còn lại.

**Tại sao phần mở rộng của hình ảnh xuất ra lại khác với bản trình chiếu nguồn?**

Aspose.Slides có thể mã hoá lại các hình ảnh raster trong quá trình xuất HTML để cải thiện kích thước hoặc tính tương thích với trình duyệt. Ví dụ, một hình ảnh từ tệp nguồn có thể được ghi dưới dạng JPEG hoặc PNG tùy thuộc vào kết quả hiển thị.

**Các URL tương đối có hoạt động sau khi tôi di chuyển tệp HTML không?**

Các URL tương đối chỉ hoạt động khi cấu trúc thư mục tương đối được giữ nguyên. Nếu HTML tham chiếu tới `assets/resource-1.png`, thư mục `assets` phải ở cạnh tệp HTML trừ khi bạn tạo một tiền tố URL khác.

**Các ứng dụng máy chủ có nên tái sử dụng cùng một thư mục đầu ra không?**

Không. Hãy sử dụng một thư mục đầu ra hoặc tiền tố lưu trữ duy nhất cho mỗi công việc chuyển đổi. Điều này tránh xung đột tên tệp và ngăn một lần xuất ghi đè lên tài nguyên được tạo bởi lần xuất khác.