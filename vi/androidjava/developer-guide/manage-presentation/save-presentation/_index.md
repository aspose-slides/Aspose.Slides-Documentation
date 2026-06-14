---
title: Lưu bản trình bày trên Android
linktitle: Lưu Bản trình bày
type: docs
weight: 80
url: /vi/androidjava/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình bày
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình bày thành tệp
- bản trình bày thành luồng
- loại chế độ xem đã xác định trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách lưu bản trình bày trong Java bằng Aspose.Slides cho Android—xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations on Android](/slides/vi/androidjava/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) để mở một bản trình bày. Bài viết này giải thích cách tạo và lưu các bản trình bày. Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) chứa nội dung của bản trình bày. Cho dù bạn đang tạo một bản trình bày mới từ đầu hay chỉnh sửa bản hiện có, bạn sẽ muốn lưu nó khi đã hoàn thành. Với Aspose.Slides for Android, bạn có thể lưu thành **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bản trình bày.

## **Lưu bản trình bày vào tệp**

Lưu một bản trình bày vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ sau cho thấy cách lưu một bản trình bày bằng Aspose.Slides.

```java
// Tạo một đối tượng lớp Presentation đại diện cho tệp bản trình bày.
Presentation presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình bày vào tệp.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình bày vào luồng**

Bạn có thể lưu một bản trình bày vào luồng bằng cách truyền một luồng đầu ra vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một bản trình bày có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng ta tạo một bản trình bày mới và lưu nó vào luồng tệp.

```java
// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Lưu bản trình bày vào luồng.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình bày với loại chế độ xem đã xác định trước**

Aspose.Slides cho phép bạn đặt chế độ xem khởi đầu mà PowerPoint sử dụng khi bản trình bày được tạo mở thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị từ enumerations [ViewType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình bày ở định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bản trình bày ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới tạo một bản trình bày và lưu nó ở định dạng Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho tệp bản trình bày.
Presentation presentation = new Presentation();
try {
    // Lưu bản trình bày ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình bày ở định dạng Office Open XML ở chế độ Zip64**

Một tệp Office Open XML là một kho lưu ZIP có giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của kho, đồng thời giới hạn số tệp trong kho là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng phần mở rộng ZIP64 nếu bản trình bày vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never) không bao giờ sử dụng phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Always) luôn luôn sử dụng phần mở rộng ZIP64.

Đoạn code sau minh họa cách lưu một bản trình bày dưới dạng PPTX với phần mở rộng ZIP64 được bật:

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setZip64Mode(Zip64Mode.Always);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("OutputZip64.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="LƯU Ý" color="warning" %}}
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxexception/) sẽ được ném nếu không thể lưu bản trình bày ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bản trình bày mà không làm mới hình thu nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kiểm soát việc tạo hình thu nhỏ khi lưu bản trình bày thành PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bản trình bày không có hình thu nhỏ, sẽ không tạo nào cả.

Trong đoạn code dưới, bản trình bày được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ.

```java
PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setRefreshThumbnail(false);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pptx", SaveFormat.Pptx, pptxOptions);
}
finally {
    presentation.dispose();
}
```

{{% alert title="Thông tin" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu bản trình bày ở định dạng PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu dưới dạng phần trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `setProgressCallback` được cung cấp bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/) với `setProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

Các đoạn code sau cho thấy cách sử dụng `IProgressCallback`.

```java
ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```
```java
class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Thông tin" color="info" %}}
Aspose đã phát triển một [ứng dụng chia tách PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của riêng mình. Ứng dụng cho phép bạn chia tách một bản trình bày thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Liệu “lưu nhanh” (lưu tăng dần) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Việc lưu luôn tạo ra tệp đích đầy đủ mỗi lần; “lưu nhanh” tăng dần không được hỗ trợ.

**Việc lưu cùng một thể hiện Presentation từ nhiều luồng có an toàn không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) **không phải là thread‑safe** (/slides/vi/androidjava/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Các siêu liên kết và tệp liên kết bên ngoài sẽ như thế nào khi lưu?**

[Hyperlinks](/slides/vi/androidjava/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ video qua đường dẫn tương đối) sẽ không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/luận dữ liệu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu chuẩn](/slides/vi/androidjava/presentation-properties/) được hỗ trợ và sẽ được ghi vào tệp khi lưu.