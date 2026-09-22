---
title: Lưu Bài Thuyết Trình trong JavaScript
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/nodejs-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình thành tệp
- bài thuyết trình thành luồng
- kiểu xem được định nghĩa trước
- định dạng Office Open XML nghiêm ngặt
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- Node.js
- JavaScript
- Aspose.Slides
description: "Lưu các bài thuyết trình PowerPoint và OpenDocument thành tệp hoặc luồng trong JavaScript với Aspose.Slides, và cấu hình đầu ra PPTX cùng báo cáo tiến trình."
---
## **Tổng quan**

Sau khi bạn tạo một bài thuyết trình hoặc [mở một bài thuyết trình hiện có](/slides/vi/nodejs-java/open-presentation/), sử dụng phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để ghi kết quả. Aspose.Slides cho Node.js thông qua Java có thể lưu một bài thuyết trình thành tệp hoặc luồng ở định dạng PowerPoint, OpenDocument, PDF và các định dạng khác. Các phần tiếp theo mô tả các thao tác lưu chuẩn và các tùy chọn có sẵn cho đầu ra PPTX.

## **Lưu Bài Thuyết Trình vào Tệp**

Để lưu một bài thuyết trình vào tệp, truyền đường dẫn đầu ra và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) cho phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save). Giá trị định dạng xác định loại tệp mà Aspose.Slides tạo ra.

Ví dụ sau tạo một bài thuyết trình và lưu nó dưới dạng tệp PPTX:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    // Thêm hoặc sửa đổi nội dung bài thuyết trình ở đây.

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Gốc**

Đối với các ví dụ phát hiện tệp và luồng, hành vi của các bài thuyết trình mới tạo, và sự khác biệt giữa định dạng nguồn và đầu ra, xem [Xác Định Định Dạng Bài Thuyết Trình Gốc](/slides/vi/nodejs-java/detect-presentation-source-format/).

Trong một ứng dụng xử lý hàng loạt, định dạng đầu vào có thể không được biết trước. Sau khi tải một tệp, đọc định dạng gốc của nó từ phương thức [Presentation.getSourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSourceFormat). Đưa giá trị [SourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sourceformat/) vào [SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#toSaveFormat) để nhận giá trị [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) tương ứng, sau đó dùng [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save) để ghi bài thuyết trình đã sửa đổi.

Ví dụ hoàn chỉnh sau xử lý mọi tệp trong thư mục đầu vào, cập nhật tiêu đề của chúng, và lưu chúng vào thư mục đầu ra ở định dạng mà chúng được tải lên:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const fs = require("fs");
const path = require("path");

const inputDirectory = "Input";
const outputDirectory = "Output";

if (!fs.existsSync(inputDirectory)) {
    console.error("The input directory does not exist.");
} else {
    fs.mkdirSync(outputDirectory, { recursive: true });

    const inputFiles = fs.readdirSync(inputDirectory, { withFileTypes: true })
        .filter((entry) => entry.isFile());

    for (const inputFile of inputFiles) {
        const inputPath = path.join(inputDirectory, inputFile.name);
        try {
            const presentation = new aspose.slides.Presentation(inputPath);
            try {
                const saveFormat = aspose.slides.SlideUtil.toSaveFormat(presentation.getSourceFormat());
                presentation.getDocumentProperties().setTitle("Processed by the batch application");

                const outputPath = path.join(outputDirectory, inputFile.name);
                presentation.save(outputPath, saveFormat);
            } finally {
                presentation.dispose();
            }
        } catch (error) {
            console.error(`Cannot process '${inputPath}': ${error.message}`);
        }
    }
}
```

[SlideUtil.toSaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideutil/#toSaveFormat) ánh xạ PPT, PPTX, ODP, PPTM, PPSX, PPSM, POTX, POTM, PPS, POT, OTP, FODP và PowerPoint XML sang các định dạng lưu bài thuyết trình tương ứng. Nó chỉ ánh xạ các định dạng nguồn của bài thuyết trình; không nhằm chọn các định dạng xuất như PDF, HTML, TIFF hoặc hình ảnh. Việc truyền một giá trị [SourceFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sourceformat/) không được hỗ trợ hoặc không hợp lệ sẽ gây lỗi.

Các tệp PPT, PPS và POT cũ sử dụng cùng một container nhị phân. Khi một bài thuyết trình như vậy được tải từ luồng mà không có phần mở rộng tệp, một tệp PPS hoặc POT có thể được nhận dạng là PPT. Nếu cần bảo tồn các loại phụ cũ này, hãy giữ lại tên tệp gốc hoặc siêu dữ liệu định dạng riêng và sử dụng chúng khi chọn tên tệp và định dạng đầu ra.

## **Lưu Bài Thuyết Trình vào Luồng**

Để ghi một bài thuyết trình mà không dựa vào đường dẫn tệp cuối cùng, truyền một luồng ghi và một giá trị [SaveFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveformat/) cho [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save). Cách tiếp cận này hữu ích khi kết quả phải được trả về từ dịch vụ web, lưu trong cơ sở dữ liệu, hoặc xử lý trong bộ nhớ.

Ví dụ sau lưu một bài thuyết trình mới vào luồng tệp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const outputStream = java.newInstanceSync("java.io.FileOutputStream", "output.pptx");
    try {
        presentation.save(outputStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        outputStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình với Kiểu Xem Được Xác Định Trước**

Bạn có thể chỉ định chế độ xem mà PowerPoint mở bài thuyết trình đã lưu ban đầu. Sử dụng phương thức [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setLastView) với một giá trị [ViewType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewtype/) trước khi lưu.

Ví dụ sau cấu hình chế độ xem Slide Master làm chế độ xem ban đầu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("slide-master-view.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML Nghiêm Ngặt**

Để tạo tệp PPTX tuân theo hồ sơ Strict của Office Open XML, tạo một thể hiện [PptxOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/) và sử dụng phương thức [setConformance](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setConformance) với [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict). Sau đó truyền các tùy chọn này cho phương thức [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

const presentation = new aspose.slides.Presentation();
try {
    presentation.save("strict-office-open-xml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML ở Chế Độ Zip64**

Một kho lưu trữ ZIP tiêu chuẩn giới hạn kích thước nén và không nén của mỗi mục, tổng kích thước kho lưu trữ và số lượng mục. Vì tệp PPTX là một kho ZIP, một bài thuyết trình rất lớn có thể vượt quá các giới hạn này. Các phần mở rộng ZIP64 nâng các giới hạn kích thước và số mục áp dụng.

Sử dụng phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setZip64Mode) để kiểm soát việc Aspose.Slides có ghi các phần mở rộng ZIP64 hay không:

- [IfNecessary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng ZIP64 khi bài thuyết trình vượt quá giới hạn ZIP tiêu chuẩn. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never) tắt các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Always) luôn ghi các phần mở rộng ZIP64.

Ví dụ sau luôn bật các phần mở rộng ZIP64 cho bài thuyết trình đầu ra:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setZip64Mode(aspose.slides.Zip64Mode.Always);

    presentation.save("output-zip64.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="warning" title="Warning" %}}
Nếu sử dụng [Zip64Mode.Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never), và bài thuyết trình không thể nằm trong giới hạn ZIP tiêu chuẩn, thao tác lưu sẽ ném ra một [PptxException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxexception/).
{{% /alert %}}

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML với Các Cấp Nén**

Đối với đầu ra PPTX, bạn có thể cân bằng tốc độ lưu và kích thước tệp bằng cách sử dụng phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel). Lớp [CompressionLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/) cung cấp các giá trị sau:

- [None](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#None) lưu dữ liệu mà không nén.
- [Level1](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level1) cung cấp mức nén nhanh nhất và đầu ra nén lớn nhất.
- [Level2](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level2) đến [Level5](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level5) dần dần ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level6](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level6) cân bằng tốc độ lưu và kích thước tệp. Đây là mức mặc định.
- [Level7](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level7) và [Level8](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level8) tiếp tục ưu tiên đầu ra nhỏ hơn hơn tốc độ lưu.
- [Level9](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level9) cung cấp mức nén mạnh nhất và yêu cầu thời gian xử lý nhiều nhất.

Ví dụ sau lưu một bài thuyết trình mà không nén:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.None);

    presentation.save("output-no-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

Ví dụ sau sử dụng mức nén tối đa:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

    presentation.save("output-maximum-compression.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Khi một bài thuyết trình được lưu dưới dạng PPTX, phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) điều khiển hình thu nhỏ của tài liệu:

- `true` tạo lại hình thu nhỏ trong quá trình lưu. Đây là giá trị mặc định.
- `false` giữ nguyên hình thu nhỏ hiện có. Nếu bài thuyết trình không có hình thu nhỏ, Aspose.Slides sẽ không tạo.

Ví dụ sau lưu một bài thuyết trình mà không làm mới hình thu nhỏ của nó:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const options = new aspose.slides.PptxOptions();
    options.setRefreshThumbnail(false);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tắt việc làm mới hình thu nhỏ có thể giảm thời gian cần thiết để lưu một tệp PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu Theo Phần Trăm**

Để giám sát một thao tác lưu, thực hiện giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) bằng một proxy Java và truyền thực thi này cho phương thức [SaveOptions.setProgressCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setProgressCallback). Aspose.Slides sau đó gọi phương thức [IProgressCallback.reporting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/#reporting-double-) với các giá trị tiến độ trong quá trình xuất.

Ví dụ sau báo cáo tiến độ xuất PDF lên bảng console:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const exportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

const options = new aspose.slides.PdfOptions();
options.setProgressCallback(exportProgressHandler);

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    presentation.save("output.pdf", aspose.slides.SaveFormat.Pdf, options);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Aspose cung cấp một công cụ [PowerPoint Splitter](https://products.aspose.app/slides/vi/splitter) miễn phí được xây dựng bằng API Aspose.Slides. Nó lưu các slide đã chọn từ một bài thuyết trình dưới dạng các tệp PPT hoặc PPTX riêng biệt.
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Aspose.Slides có hỗ trợ lưu tăng dần hoặc “lưu nhanh” không?**

Không. Mỗi thao tác lưu ghi một tệp đầu ra hoàn chỉnh thay vì chỉ cập nhật các phần đã thay đổi.

**Nhiều luồng có thể lưu cùng một thể hiện Presentation không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/nodejs-java/multithreading/). Truy cập và lưu mỗi thể hiện chỉ từ một luồng tại một thời điểm.

**Điều gì xảy ra với siêu liên kết và các tệp liên kết bên ngoài khi tôi lưu một bài thuyết trình?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) vẫn còn trong bài thuyết trình. Aspose.Slides không sao chép các tệp liên kết bên ngoài, vì vậy bài thuyết trình đã lưu vẫn phải có khả năng truy cập vị trí của chúng.

**Tôi có thể lưu siêu dữ liệu tài liệu như tác giả, tiêu đề, công ty và ngày tạo không?**

Có. Đặt các [document properties](/slides/vi/nodejs-java/presentation-properties/) thích hợp trước khi lưu, và Aspose.Slides sẽ ghi chúng vào tệp đầu ra.