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
- bài thuyết trình thành tập tin
- bài thuyết trình thành luồng
- kiểu xem được định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách lưu các bài thuyết trình bằng Aspose.Slides cho Node.js qua Java - xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng Quan**

[Open Presentations in JavaScript](/slides/vi/nodejs-java/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) chứa nội dung của bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay chỉnh sửa một bài đã có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho Node.js, bạn có thể lưu thành **tập tin** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài Thuyết Trình vào Tập Tin**

Lưu một bài thuyết trình vào tập tin bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Truyền tên tập tin và định dạng lưu vào phương thức. Ví dụ sau cho thấy cách lưu một bài thuyết trình với Aspose.Slides.

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình chiếu vào tệp.
    presentation.save("Output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình vào Luồng**

Bạn có thể lưu một bài thuyết trình vào luồng bằng cách truyền một luồng đầu ra vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại luồng khác nhau. Trong ví dụ dưới, chúng ta tạo một bài thuyết trình mới và lưu nó vào một luồng tập tin.

```js
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    let fileStream = java.newInstanceSync("java.io.FileOutputStream", "Output.pptx");
    try {
        // Lưu bản trình chiếu vào luồng.
        presentation.save(fileStream, aspose.slides.SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình với Kiểu Xem Được Định Nghĩa Trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bài thuyết trình được mở qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setLastView) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewtype/).

```js
let presentation = new aspose.slides.Presentation();
try {
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML Chặt Chẽ**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/conformance/#Iso29500_2008_Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

```js
let options = new aspose.slides.PptxOptions();
options.setConformance(aspose.slides.Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
let presentation = new aspose.slides.Presentation();
try {
    // Lưu bản trình chiếu ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", aspose.slides.SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML trong Chế Độ Zip64**

Một tệp Office Open XML là một kho lưu ZIP áp chế giới hạn 4 GB (2^32 byte) cho kích thước không nén của bất kỳ tệp nào, kích thước nén của bất kỳ tệp nào và tổng kích thước của kho lưu, đồng thời giới hạn số tệp trong kho lưu là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [PptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#getZip64Mode) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng các phần mở rộng định dạng ZIP64 chỉ khi bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never) không bao giờ sử dụng các phần mở rộng định dạng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Always) luôn luôn sử dụng các phần mở rộng định dạng ZIP64.

Đoạn mã sau minh họa cách lưu một bài thuyết trình dưới dạng PPTX với các phần mở rộng định dạng ZIP64 được bật:

```js
let pptxOptions = new aspose.slides.PptxOptions();
pptxOptions.setZip64Mode(aspose.slides.Zip64Mode.Always);

let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", aspose.slides.SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxexception/) sẽ được ném nếu bài thuyết trình không thể lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pptxoptions/#setRefreshThumbnail) điều khiển việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu đặt `true`, hình thu nhỏ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt `false`, hình thu nhỏ hiện tại được giữ nguyên. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo gì cả.

Trong đoạn mã dưới, bài thuyết trình được lưu thành PPTX mà không làm mới hình thu nhỏ.

```js
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

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

## **Lưu Cập Nhật Tiến Độ theo Phần Trăm**

Báo cáo tiến độ lưu được cấu hình qua phương thức [setProgressCallback](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/#setProgressCallback) trên [SaveOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/saveoptions/) và các lớp con của nó. Cung cấp một proxy Java triển khai giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/); trong quá trình xuất, callback sẽ nhận các cập nhật phần trăm định kỳ.

Các đoạn mã dưới đây cho thấy cách sử dụng `IProgressCallback`.

```javascript
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

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng Splitter PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) dựa trên API của mình. Ứng dụng này cho phép bạn tách một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **FAQ**

**“Lưu nhanh” (lưu tăng dần) có được hỗ trợ để chỉ ghi những thay đổi không?**

Không. Việc lưu luôn tạo ra toàn bộ tệp đích mỗi lần; “lưu nhanh” tăng dần không được hỗ trợ.

**Có an toàn khi lưu cùng một đối tượng Presentation từ nhiều luồng không?**

Không. Một đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) **không** an toàn trong môi trường đa luồng; hãy lưu nó từ một luồng duy nhất.

**Liên kết siêu văn bản và các tệp được liên kết bên ngoài sẽ xảy ra gì khi lưu?**

[Hyperlinks](/slides/vi/nodejs-java/manage-hyperlinks/) được giữ nguyên. Các tệp được liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) sẽ không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập được.

**Có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu chuẩn](/slides/vi/nodejs-java/presentation-properties/) được hỗ trợ và sẽ được ghi vào tệp khi lưu.