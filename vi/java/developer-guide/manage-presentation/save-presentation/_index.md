---
title: Lưu bài thuyết trình trong Java
linktitle: Lưu bài thuyết trình
type: docs
weight: 80
url: /vi/java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài thuyết trình
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài thuyết trình sang tệp
- bài thuyết trình sang luồng
- kiểu xem đã định nghĩa trước
- Định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- Java
- Aspose.Slides
description: "Khám phá cách lưu bài thuyết trình trong Java bằng Aspose.Slides—xuất sang PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Mở bài thuyết trình trong Java](/slides/vi/java/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay sửa đổi một bài hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho Java, bạn có thể lưu vào **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu bài thuyết trình vào tệp**

Lưu một bài thuyết trình vào tệp bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ dưới đây cho thấy cách lưu một bài thuyết trình bằng Aspose.Slides.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bài thuyết trình vào tệp.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bài thuyết trình vào luồng**

Bạn có thể lưu một bài thuyết trình vào luồng bằng cách truyền một luồng đầu ra vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bài thuyết trình mới và lưu nó vào một luồng tệp.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Lưu bài thuyết trình vào luồng.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu bài thuyết trình với Kiểu xem đã định nghĩa trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bài thuyết trình được tạo mở ra thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị từ liệt kê [ViewType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewtype/).

```java
Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bài thuyết trình ở Định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

```java
PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation();
try {
    // Lưu bài thuyết trình ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bài thuyết trình ở Định dạng Office Open XML ở chế độ Zip64**

Tệp Office Open XML là một archive ZIP có các giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của archive, đồng thời giới hạn số tệp trong archive là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng những giới hạn này lên 2^64.

Phương thức [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng các phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never) không bao giờ sử dụng các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Always) luôn luôn sử dụng các phần mở rộng ZIP64.

Mã dưới đây minh họa cách lưu một bài thuyết trình dưới dạng PPTX với các phần mở rộng ZIP64 được bật:

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

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxexception/) sẽ được ném nếu bài thuyết trình không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bài thuyết trình mà không làm mới hình thu nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) điều khiển việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo gì cả.

Trong đoạn mã dưới đây, bài thuyết trình được lưu thành PPTX mà không làm mới hình thu nhỏ.

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

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

## **Lưu cập nhật tiến độ dưới dạng phần trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `setProgressCallback` được cung cấp bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) với `setProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

Các đoạn mã sau đây cho thấy cách sử dụng `IProgressCallback`.

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

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng tách PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có hỗ trợ “lưu nhanh” (lưu gia tăng) để chỉ ghi các thay đổi không?**

Không. Mỗi lần lưu đều tạo toàn bộ tệp đích; “lưu nhanh” gia tăng không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một instance Presentation từ nhiều luồng không?**

Không. Một instance [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/java/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/java/manage-hyperlinks/) được giữ nguyên. Các tệp được liên kết bên ngoài (ví dụ video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/java/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.