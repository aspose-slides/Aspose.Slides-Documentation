---
title: Lưu Bài Trình Chiếu trong Java
linktitle: Lưu Bài Trình Chiếu
type: docs
weight: 80
url: /vi/java/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bài trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bài trình chiếu thành tệp
- bài trình chiếu thành stream
- kiểu xem được định nghĩa trước
- Định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- Java
- Aspose.Slides
description: "Khám phá cách lưu các bài trình chiếu trong Java sử dụng Aspose.Slides — xuất ra PowerPoint hoặc OpenDocument trong khi giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in Java](/slides/vi/java/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) để mở một bài trình chiếu. Bài viết này giải thích cách tạo và lưu các bài trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) chứa nội dung của một bài trình chiếu. Cho dù bạn đang tạo một bài trình chiếu từ đầu hay chỉnh sửa một bài hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides for Java, bạn có thể lưu thành **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu một bài trình chiếu.

## **Lưu Bài Trình Chiếu vào Tập Tin**

Lưu một bài trình chiếu vào tập tin bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Cung cấp tên tập tin và định dạng lưu cho phương thức. Ví dụ sau cho thấy cách lưu một bài trình chiếu bằng Aspose.Slides.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bài trình chiếu.
Presentation presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bài trình chiếu thành tệp.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Trình Chiếu vào Stream**

Bạn có thể lưu một bài trình chiếu vào stream bằng cách truyền một output stream vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/). Một bài trình chiếu có thể được ghi vào nhiều loại stream. Trong ví dụ dưới đây, chúng tôi tạo một bài trình chiếu mới và lưu nó vào một file stream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Khởi tạo lớp Presentation đại diện cho một tệp bài trình chiếu.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Lưu bài trình chiếu vào stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Trình Chiếu với Kiểu Xem Được Định Nghĩa Trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi mở bài trình chiếu đã tạo thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewtype/).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("SlideMasterView.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Trình Chiếu ở Định Dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/java/com.aspose.slides/conformance/#Iso29500-2008-Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho một tệp bài trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lưu bài trình chiếu ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Trình Chiếu ở Định Dạng Office Open XML trong Chế Độ Zip64**

File Office Open XML là một archive ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước không nén, kích thước nén và tổng kích thước của archive, và cũng giới hạn số file trong archive là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#IfNecessary) sử dụng các phần mở rộng ZIP64 chỉ nếu bài trình chiếu vượt quá các giới hạn trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never) không bao giờ sử dụng các phần mở rộng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Always) luôn luôn sử dụng các phần mở rộng ZIP64.

Đoạn code dưới đây minh họa cách lưu một bài trình chiếu dưới dạng tệp PPTX với các phần mở rộng định dạng ZIP64 được bật:

```java
import com.aspose.slides.*;

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
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/java/com.aspose.slides/zip64mode/#Never), một [PptxException](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxexception/) sẽ được ném nếu không thể lưu bài trình chiếu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Trình Chiếu ở Định Dạng Office Open XML với Các Mức Nén**

Khi làm việc với các bài trình chiếu lớn, bạn có thể điều chỉnh mức nén để cân bằng giữa kích thước tệp và thời gian xử lý. Tùy theo nhu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp phương thức [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) cho phép bạn chỉ định mức nén được sử dụng khi lưu một bài trình chiếu ở định dạng Office Open XML.

Các mức nén sau có sẵn:

- [**None**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#None): Không áp dụng nén. Các tệp được lưu nguyên như hiện tại.
- [**Level1**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level1): Nén nhanh nhất với tỷ lệ nén thấp nhất.
- [**Level2**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level2): Nén nhanh hơn với tỷ lệ nén hơi tốt hơn **Level1**.
- [**Level3**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level3): Cung cấp nén tốt hơn **Level2** với ảnh hưởng vừa phải đến thời gian xử lý.
- [**Level4**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level4): Cung cấp nén tốt hơn **Level3**.
- [**Level5**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level5): Cung cấp nén cải thiện hơn **Level4** với thời gian xử lý bổ sung.
- [**Level6**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level6): Nén tiêu chuẩn, cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- [**Level7**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level7): Cung cấp nén tốt hơn **Level6** nhưng xử lý chậm hơn.
- [**Level8**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level8): Cung cấp nén tốt hơn **Level7**.
- [**Level9**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/compressionlevel/#Level9): Nén tối đa. Tạo kích thước tệp nhỏ nhất với thời gian xử lý dài nhất.

Đoạn code dưới đây minh họa cách lưu một bài trình chiếu dưới dạng tệp PPTX *không nén*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.None);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-out.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

Ví dụ này cho thấy cách lưu một bài trình chiếu dưới dạng tệp PPTX với *nén tối đa*:

```java
import com.aspose.slides.*;

PptxOptions pptxOptions = new PptxOptions();
pptxOptions.setCompressionLevel(CompressionLevel.Level9);

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Sample-level9.pptx", SaveFormat.Pptx, pptxOptions);
} finally {
    presentation.dispose();
}
```

## **Lưu Bài Trình Chiếu mà Không Làm Mới Hình Thu Nhỏ**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) kiểm soát việc tạo hình thu nhỏ khi lưu một bài trình chiếu sang PPTX:

- Nếu được đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu được đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài trình chiếu không có hình thu nhỏ, sẽ không tạo ra hình thu nhỏ nào.

Trong đoạn code dưới đây, bài trình chiếu được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ của nó.

```java
import com.aspose.slides.*;

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
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu Theo Phần Trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `setProgressCallback` được cung cấp bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iprogresscallback/) với `setProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

Đoạn code sau đây cho thấy cách sử dụng `IProgressCallback`.

```java
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}

ISaveOptions saveOptions = new PdfOptions();
saveOptions.setProgressCallback(new ExportProgressHandler());

Presentation presentation = new Presentation("Sample.pptx");
try {
    presentation.save("Output.pdf", SaveFormat.Pdf, saveOptions);
} finally {
    presentation.dispose();
}
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng tách PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bài trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Có hỗ trợ “lưu nhanh” (lưu tăng dần) để chỉ ghi những thay đổi không?**

Không. Khi lưu, luôn tạo ra toàn bộ tệp đích mỗi lần; “lưu nhanh” tăng dần không được hỗ trợ.

**Có thể lưu cùng một đối tượng Presentation từ nhiều luồng một cách an toàn không?**

Không. Một đối tượng [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) [không an toàn với đa luồng](/slides/vi/java/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với các siêu liên kết và tệp liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/java/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/java/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.