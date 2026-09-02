---
title: Chuyển đổi bài thuyết trình PowerPoint sang Markdown trong JavaScript
linktitle: PowerPoint sang Markdown
type: docs
weight: 140
url: /vi/nodejs-java/convert-powerpoint-to-markdown/
keywords:
- chuyển đổi PowerPoint
- chuyển đổi bản thuyết trình
- chuyển đổi slide
- chuyển đổi PPT
- chuyển đổi PPTX
- PowerPoint sang MD
- bản thuyết trình sang MD
- slide sang MD
- PPT sang MD
- PPTX sang MD
- lưu PowerPoint dưới dạng Markdown
- lưu bản thuyết trình dưới dạng Markdown
- lưu slide dưới dạng Markdown
- lưu PPT dưới dạng MD
- lưu PPTX dưới dạng MD
- xuất PPT sang MD
- xuất PPTX sang MD
- xuất hình ảnh Markdown
- liên kết hình ảnh CDN
- PowerPoint
- bản thuyết trình
- Markdown
- Node.js
- JavaScript
- Aspose.Slides
description: "Chuyển đổi các bản thuyết trình PPT và PPTX sang Markdown trong JavaScript và kiểm soát nơi lưu và tham chiếu các hình ảnh bitmap, metafile và SVG đã xuất."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java có thể chuyển đổi các bản thuyết trình PPT và PPTX sang Markdown để tài liệu, trang tĩnh, di chuyển nội dung và quy trình kiểm soát phiên bản. Bạn có thể chọn kiểu Markdown, kiểm soát cách nội dung slide được render, và quyết định nơi lưu trữ hình ảnh được xuất cùng với cách Markdown tham chiếu tới chúng.

Mặc định, xuất Markdown chỉ tạo ra đầu ra dạng văn bản. Để xuất nội dung hình ảnh, hãy đặt kiểu xuất bằng phương thức [MarkdownSaveOptions.setExportType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) thành giá trị `Sequential` hoặc `Visual` trong enumeration [MarkdownExportType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownexporttype/). `Sequential` render các mục slide riêng biệt và theo thứ tự, trong khi `Visual` giữ các mục được nhóm lại với nhau để bảo toàn mối quan hệ trực quan. Giá trị `TextOnly` không tạo ra tài nguyên hình ảnh, vì vậy các callback lưu hình ảnh sẽ không được gọi ở chế độ này.

## **Chuyển đổi bản thuyết trình sang Markdown**

Tải tệp nguồn bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), sau đó gọi phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) với giá trị `Md` từ enumeration [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/).

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.save("presentation.md", aspose.slides.SaveFormat.Md);
} finally {
    presentation.dispose();
}
```

## **Chọn kiểu Markdown**

Phương thức [MarkdownSaveOptions.setFlavor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) kiểm soát đặc tả Markdown được dùng cho đầu ra. Enumeration [Flavor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/flavor/) bao gồm CommonMark, GitHub Flavored Markdown và các biến thể được hỗ trợ khác.

Ví dụ sau xuất một bản thuyết trình dưới dạng CommonMark:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setFlavor(aspose.slides.Flavor.CommonMark);

    presentation.save("presentation.md", aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

## **Xuất hình ảnh bằng hành vi lưu cục bộ mặc định**

Lớp [MarkdownSaveOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) cung cấp hai phương thức để cấu hình việc lưu hình ảnh cục bộ:

- [setBasePath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) xác định thư mục gốc cho tài liệu Markdown và các tài nguyên của nó.
- [setImagesSaveFolderName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) xác định thư mục con cho hình ảnh. Giá trị mặc định là `Images`.

Ví dụ sau render nội dung hình ảnh, ghi hình ảnh vào `output/assets`, và tạo các tham chiếu hình ảnh tương đối trong tài liệu Markdown:

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
fs.mkdirSync(outputDirectory, { recursive: true });

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("assets");

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Hành vi này cũng được dùng làm dự phòng khi một trình xử lý lưu hình ảnh tùy chỉnh trả về `false`.

## **Tùy chỉnh lưu hình ảnh và liên kết Markdown**

Sử dụng phương thức [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) để đăng ký một callback cho các tài nguyên bitmap và metafile không phải SVG được phát ra trong quá trình xuất Markdown. Callback `MarkdownImageSavingHandler` của nó nhận đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/), giá trị [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/), và liên kết Markdown được tạo dưới dạng mảng chuỗi một phần tử. Lưu hoặc tải lên hình ảnh với định dạng đã cung cấp, và thay thế `link[0]` bằng tham chiếu phải xuất hiện trong đầu ra Markdown.

Các tài nguyên được phát ra dưới dạng SVG được xử lý riêng. Đăng ký một callback với phương thức [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/). Callback `MarkdownSvgImageSavingHandler` của nó nhận một đối tượng `ISvgImage` và mảng `link` một phần tử. SVG không có đối số `ImageFormat`; thay vào đó hãy ghi hoặc tải lên dữ liệu XML của nó qua phương thức `ISvgImage.getSvgData`. Tùy thuộc vào chế độ xuất và việc nhóm trực quan, một SVG trong bản thuyết trình nguồn có thể được raster hóa hoặc kết hợp với nội dung khác; tài nguyên không phải SVG kết quả sau đó sẽ được truyền tới callback lưu hình ảnh. Đăng ký cả hai callback khi mọi tài nguyên hình ảnh được xuất cần xử lý tùy chỉnh.

Trong Node.js, tạo các triển khai của các giao diện callback này bằng `java.newProxy`.

Giá trị trả về của handler quyết định ai sẽ xử lý hình ảnh:

- Trả về `true` sau khi handler đã lưu, tải lên, chuyển đổi hoặc xử lý hình ảnh và đã gán giá trị hợp lệ cho `link[0]`. Aspose.Slides sẽ ghi giá trị đó vào tài liệu Markdown và không thực hiện lưu cục bộ mặc định.
- Trả về `false` để cho Aspose.Slides lưu hình ảnh cục bộ và tạo liên kết theo các giá trị được đặt bằng [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/).

{{% alert color="warning" title="Important" %}}

Một handler trả về `true` chịu trách nhiệm về hình ảnh. Nếu nó trả về `true` mà không gán một liên kết hợp lệ, không rỗng, quá trình xuất sẽ thất bại với `InvalidOperationException`.

{{% /alert %}}

### **Lưu hình ảnh vào thư mục gốc CDN và sử dụng URL ngoài**

Ví dụ sau coi `cdn-origin/presentations/quarterly-report` là một thư mục gốc CDN đã được gắn kết hoặc đồng bộ. Mỗi handler trích xuất tên tệp đã tạo, lưu hình ảnh vào thư mục tùy chỉnh đó, và thay thế tham chiếu cục bộ đã tạo bằng một URL CDN công cộng. Mẫu này không thực hiện tải lên mạng: URL chỉ hợp lệ sau khi thư mục được gắn làm gốc CDN hoặc các tệp của nó được công bố lên CDN. Đối với lưu trữ đối tượng, thay đổi thao tác ghi hệ thống tệp bằng hoạt động tải lên của SDK lưu trữ và gán `link[0]` chỉ sau khi tải lên thành công.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");
const fs = require("fs");
const path = require("path");

const outputDirectory = "output";
const publicBaseUrl = "https://cdn.example.com/presentations/quarterly-report";
const storageDirectory = path.join("cdn-origin", "presentations", "quarterly-report");
fs.mkdirSync(outputDirectory, { recursive: true });
fs.mkdirSync(storageDirectory, { recursive: true });

const getFileNameFromLink = generatedLink => {
    const urlCompatibleLink = String(generatedLink).replace(/\\/g, "/");
    return path.posix.basename(urlCompatibleLink);
};
const buildPublicUrl = fileName => publicBaseUrl + "/" + encodeURIComponent(fileName);

const imageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownImageSavingHandler", {
    invoke: function(image, format, link) {
        if (image.getWidth() < 128 || image.getHeight() < 128) {
            return false;
        }

        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        image.save(storagePath, format);
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

const svgImageSavingHandler = java.newProxy("com.aspose.slides.MarkdownSaveOptions$MarkdownSvgImageSavingHandler", {
    invoke: function(svgImage, link) {
        const fileName = getFileNameFromLink(link[0]);
        const storagePath = path.join(storageDirectory, fileName);
        fs.writeFileSync(storagePath, svgImage.getSvgData());
        link[0] = buildPublicUrl(fileName);
        return true;
    }
});

var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    var options = new aspose.slides.MarkdownSaveOptions();
    options.setExportType(aspose.slides.MarkdownExportType.Visual);
    options.setBasePath(outputDirectory);
    options.setImagesSaveFolderName("fallback-images");
    options.setImageSaving(imageSavingHandler);
    options.setSvgImageSaving(svgImageSavingHandler);

    const markdownPath = path.join(outputDirectory, "presentation.md");
    presentation.save(markdownPath, aspose.slides.SaveFormat.Md, options);
} finally {
    presentation.dispose();
}
```

Handler bitmap cố ý trả về `false` cho các hình ảnh có kích thước nhỏ hơn 128 × 128 pixel, vì vậy Aspose.Slides sẽ lưu các hình ảnh đó vào `output/fallback-images` theo hành vi mặc định. Các tài nguyên bitmap và metafile lớn hơn, cũng như tài nguyên SVG, được xử lý bởi mã tùy chỉnh. Ví dụ, một tham chiếu cục bộ đã tạo như `fallback-images/image1.png` sẽ trở thành `https://cdn.example.com/presentations/quarterly-report/image1.png`. Các handler chỉ sử dụng đường dẫn hệ điều hành khi ghi tệp; các liên kết ghi vào Markdown dùng dấu gạch chéo `/` và tên tệp đã được mã hoá URL. Áp dụng quy tắc tương tự khi xây dựng các liên kết tương đối: dùng `/`, không phải dấu phân tách thư mục đặc thù nền tảng.

## **Câu hỏi thường gặp**

**Một handler có thể xử lý cả hình raster và SVG không?**

Không. Dùng [MarkdownSaveOptions.setImageSaving](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên bitmap và metafile được phát ra và [MarkdownSaveOptions.setSvgImageSaving](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) cho các tài nguyên được phát ra dưới dạng SVG. Cái đầu cung cấp một đối tượng [IImage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/iimage/) và một giá trị [ImageFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/imageformat/); cái sau cung cấp một đối tượng `ISvgImage` mà dữ liệu SVG có thể đọc bằng `ISvgImage.getSvgData`. Một SVG nguồn bị raster hóa trong quá trình xuất sẽ được xử lý bởi callback lưu hình ảnh.

**Xảy ra gì khi một handler lưu hình ảnh trả về `false`?**

Aspose.Slides sẽ sử dụng hành vi lưu cục bộ mặc định. Vị trí hình ảnh và tham chiếu được tạo ra được điều khiển bởi các giá trị được đặt bằng [MarkdownSaveOptions.setBasePath](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/) và [MarkdownSaveOptions.setImagesSaveFolderName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/markdownsaveoptions/).

**Handler có thể cung cấp URL mà không lưu hình ảnh cục bộ không?**

Có. Handler có thể tải hình ảnh lên lưu trữ đối tượng hoặc chuyển cho dịch vụ khác, gán URL thu được cho `link[0]`, và trả về `true`. Handler phải tự hoàn thành việc xử lý; trả về `true` sẽ ngăn hành vi lưu cục bộ mặc định.

**Tại sao quá trình xuất Markdown gây ra `InvalidOperationException` từ một handler?**

Ngoại lệ này xảy ra khi handler trả về `true` nhưng không cung cấp một liên kết hợp lệ. Gán đường dẫn tương đối hoặc URL ngoài mà sẽ được ghi vào Markdown trước khi trả về `true`.

**Dấu phân tách đường dẫn nào nên dùng cho liên kết hình ảnh?**

Sử dụng dấu gạch chéo `/` trong các liên kết Markdown và URL. Dùng `path.join` chỉ cho các đường dẫn hệ thống, sau đó xây dựng hoặc chuẩn hoá tham chiếu Markdown riêng.

**Liên kết siêu văn bản có được giữ lại khi xuất Markdown không?**

Có. Các [hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) trong văn bản được giữ lại dưới dạng liên kết Markdown tiêu chuẩn. Các [transitions](/slides/vi/nodejs-java/slide-transition/) và [animations](/slides/vi/nodejs-java/powerpoint-animation/) của slide không được chuyển đổi.

**Có thể chuyển đổi nhiều bản thuyết trình sang Markdown đồng thời không?**

Bạn có thể xử lý các tệp bản thuyết trình khác nhau song song, nhưng không chia sẻ cùng một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) giữa các luồng. Hãy tuân theo [hướng dẫn đa luồng](/slides/vi/nodejs-java/multithreading/) và tạo một thể hiện riêng cho mỗi tệp.