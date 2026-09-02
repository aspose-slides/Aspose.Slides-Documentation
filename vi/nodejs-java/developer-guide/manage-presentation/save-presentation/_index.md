---
title: Lưu Bản Trình Chiếu trong JavaScript
linktitle: Lưu Bản Trình Chiếu
type: docs
weight: 80
url: /vi/nodejs-java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành tệp
- bản trình chiếu thành stream
- kiểu xem đã định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách lưu bản trình chiếu bằng Aspose.Slides cho Node.js thông qua Java — xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in JavaScript](/slides/vi/nodejs-java/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để mở một bản trình chiếu. Bài viết này giải thích cách tạo và lưu bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) chứa nội dung của bản trình chiếu. Cho dù bạn đang tạo một bản trình chiếu từ đầu hay chỉnh sửa một bản hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho Node.js, bạn có thể lưu vào **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu một bản trình chiếu.

## **Lưu bản trình chiếu vào Files**

Lưu một bản trình chiếu vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Pass the file name and save format to the method. The following example show how to save a presentation with Aspose.Slides.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình chiếu vào tệp.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu vào Streams**

Bạn có thể lưu một bản trình chiếu vào stream bằng cách truyền một output stream vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Một bản trình chiếu có thể được ghi vào nhiều loại stream. Trong ví dụ dưới đây, chúng tôi tạo một bản trình chiếu mới và lưu nó vào một file stream.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Lưu bản trình chiếu vào stream.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu với Kiểu xem đã định nghĩa trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bản trình chiếu được mở qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setLastView) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewtype/).

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bản trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bản trình chiếu và lưu nó ở định dạng Strict Office Open XML.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lưu bản trình chiếu ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở định dạng Office Open XML ở chế độ Zip64**

Một tệp Office Open XML là một tập tin ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của archive, đồng thời giới hạn số tệp trong archive là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng những giới hạn này lên 2^64.

Phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) cho phép bạn chọn khi nào sử dụng phần mở rộng định dạng ZIP64 khi lưu tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#IfNecessary) sử dụng phần mở rộng định dạng ZIP64 chỉ nếu bản trình chiếu vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never) không bao giờ sử dụng phần mở rộng định dạng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Always) luôn luôn sử dụng phần mở rộng định dạng ZIP64.

Mã dưới đây minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX với phần mở rộng định dạng ZIP64 được bật:

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="LƯU Ý" color="warning" %}}
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxexception/) sẽ được ném nếu bản trình chiếu không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bản trình chiếu ở định dạng Office Open XML với các mức nén**

Khi làm việc với các bản trình chiếu lớn, bạn có thể điều chỉnh mức nén để cân bằng giữa kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp phương thức [PptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setCompressionLevel), cho phép bạn chỉ định mức nén được sử dụng khi lưu bản trình chiếu ở định dạng Office Open XML.

Các mức nén sau đây có sẵn:

- [**None**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#None): Không áp dụng nén. Các tệp được lưu nguyên.
- [**Level1**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level1): Nén nhanh nhất với tỷ lệ nén thấp nhất.
- [**Level2**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level2): Nén nhanh hơn với tỷ lệ nén hơi tốt hơn **Level1**.
- [**Level3**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level3): Cung cấp nén tốt hơn **Level2** với ảnh hưởng vừa phải tới thời gian xử lý.
- [**Level4**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level4): Cung cấp nén tốt hơn **Level3**.
- [**Level5**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level5): Cải thiện nén hơn **Level4** với thời gian xử lý bổ sung.
- [**Level6**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level6): Nén tiêu chuẩn cung cấp cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- [**Level7**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level7): Cung cấp nén tốt hơn **Level6** nhưng xử lý chậm hơn.
- [**Level8**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level8): Cung cấp nén tốt hơn **Level7**.
- [**Level9**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/compressionlevel/#Level9): Nén tối đa. Tạo kích thước tệp nhỏ nhất với thời gian xử lý lâu nhất.

Ví dụ sau đây minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX *không có nén*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.None);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ví dụ này cho thấy cách lưu một bản trình chiếu dưới dạng tệp PPTX với *nén tối đa*:

```js
const aspose = { slides: require("aspose.slides.via.java") };

const pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setCompressionLevel(aspose.slides.CompressionLevel.Level9);

const presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) kiểm soát việc tạo hình thu nhỏ khi lưu bản trình chiếu thành PPTX:

- Nếu đặt `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bản trình chiếu không có hình thu nhỏ, sẽ không tạo hình nào.

Trong đoạn mã dưới đây, bản trình chiếu được lưu thành PPTX mà không làm mới hình thu nhỏ của nó.

```js
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setRefreshThumbnail(false);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Thông tin" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu bản trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Lưu cập nhật tiến độ dưới dạng phần trăm**

Báo cáo tiến độ lưu được cấu hình qua phương thức [setProgressCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) trên [SaveOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/) và các lớp con của nó. Cung cấp một proxy Java thực thi giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/); trong quá trình xuất, callback sẽ nhận các cập nhật phần trăm định kỳ.

Các đoạn mã dưới đây cho thấy cách sử dụng `IProgressCallback`.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

const ExportProgressHandler = java.newProxy("com.aspose.slides.IProgressCallback", {
    reporting: function(progressValue) {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        const progress = Math.floor(progressValue);
        console.log(`${progress}% of the file has been converted.`);
    }
});

let saveOptions = new aspose.slides.PdfOptions();
saveOptions.setProgressCallback(ExportProgressHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", aspose.slides.SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Thông tin" color="info" %}}
Aspose đã phát triển một ứng dụng [PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bản trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Liệu “fast save” (lưu tăng dần) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Mỗi lần lưu đều tạo ra tệp đích đầy đủ; “fast save” tăng dần không được hỗ trợ.

**Liệu có an toàn đa luồng khi lưu cùng một đối tượng Presentation từ nhiều luồng không?**

Không. Một đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) **không an toàn đa luồng**; hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu tiêu chuẩn](/slides/vi/nodejs-java/presentation-properties/) được hỗ trợ và sẽ được ghi vào tệp khi lưu.