---
title: Lưu Bản Trình Chiếu trên Android
linktitle: Lưu Bản Trình Chiếu
type: docs
weight: 80
url: /vi/androidjava/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành file
- bản trình chiếu thành stream
- kiểu xem được định trước
- Định dạng Strict Office Open XML
- chế độ Zip64
- làm mới thumbnail
- tiến độ lưu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách lưu bản trình chiếu trong Java bằng Aspose.Slides cho Android—xuất ra PowerPoint hoặc OpenDocument trong khi giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations on Android](/slides/vi/androidjava/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) để mở một bản trình chiếu. Bài viết này giải thích cách tạo và lưu bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) chứa nội dung của bản trình chiếu. Cho dù bạn đang tạo bản trình chiếu từ đầu hay chỉnh sửa một bản hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho Android, bạn có thể lưu vào **file** hoặc **stream**. Bài viết này giải thích các cách khác nhau để lưu bản trình chiếu.

## **Lưu bản trình chiếu vào File**

Lưu một bản trình chiếu vào file bằng cách gọi phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Truyền tên file và định dạng lưu vào phương thức. Ví dụ sau minh họa cách lưu một bản trình chiếu với Aspose.Slides.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình chiếu vào tệp.
    presentation.save("Output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu vào Stream**

Bạn có thể lưu một bản trình chiếu vào stream bằng cách truyền một output stream vào phương thức `save` của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/). Một bản trình chiếu có thể được ghi vào nhiều loại stream. Trong ví dụ dưới đây, chúng tôi tạo một bản trình chiếu mới và lưu nó vào một file stream.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.OutputStream;

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    OutputStream fileStream = new FileOutputStream("Output.pptx");
    try {
        // Lưu bản trình chiếu vào stream.
        presentation.save(fileStream, SaveFormat.Pptx);
    } finally {
        fileStream.close();
    }
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu với Kiểu xem Được Định trước**

Aspose.Slides cho phép bạn thiết lập chế độ xem ban đầu mà PowerPoint sử dụng khi mở bản trình chiếu được tạo thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/). Sử dụng phương thức [setLastView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#setLastView-int-) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewtype/).

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

## **Lưu bản trình chiếu ở Định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bản trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/) và thiết lập thuộc tính conformance khi lưu. Nếu bạn đặt [Conformance.Iso29500_2008_Strict](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/conformance/#Iso29500-2008-Strict), tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bản trình chiếu và lưu nó ở định dạng Strict Office Open XML.

```java
import com.aspose.slides.*;

PptxOptions options = new PptxOptions();
options.setConformance(Conformance.Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu.
Presentation presentation = new Presentation();
try {
    // Lưu bản trình chiếu ở định dạng Strict Office Open XML.
    presentation.save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
} finally {
    presentation.dispose();
}
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML ở Chế độ Zip64**

Một tệp Office Open XML là một kho ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của kho, đồng thời giới hạn số tệp trong kho ở mức 65 535 (2^16-1) tệp. Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [IPptxOptions.setZip64Mode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipptxoptions/#setZip64Mode-int-) cho phép bạn chọn thời điểm sử dụng các phần mở rộng định dạng ZIP64 khi lưu tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- [IfNecessary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#IfNecessary) chỉ sử dụng các phần mở rộng định dạng ZIP64 nếu bản trình chiếu vượt quá các giới hạn ở trên. Đây là chế độ mặc định.
- [Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never) không bao giờ sử dụng các phần mở rộng định dạng ZIP64.
- [Always](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Always) luôn luôn sử dụng các phần mở rộng định dạng ZIP64.

Mã sau minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX với các phần mở rộng định dạng ZIP64 được bật:

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
Khi bạn lưu với [Zip64Mode.Never](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/zip64mode/#Never) một [PptxException](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxexception/) sẽ được ném nếu bản trình chiếu không thể được lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bản trình chiếu ở Định dạng Office Open XML với Các mức nén**

Khi làm việc với các bản trình chiếu lớn, bạn có thể điều chỉnh mức nén để cân bằng giữa kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu của bạn, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp phương thức [IPptxOptions.setCompressionLevel](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipptxoptions/#setCompressionLevel-int-) cho phép bạn chỉ định mức nén được sử dụng khi lưu một bản trình chiếu ở định dạng Office Open XML.

Các mức nén sau đây có sẵn:

- [**None**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#None): Không áp dụng nén. Các tệp được lưu nguyên trạng.
- [**Level1**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level1): Nén nhanh nhất với tỷ lệ nén thấp nhất.
- [**Level2**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level2): Nén nhanh hơn với tỷ lệ nén hơi tốt hơn so với **Level1**.
- [**Level3**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level3): Cung cấp mức nén tốt hơn **Level2** với ảnh hưởng vừa phải tới thời gian xử lý.
- [**Level4**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level4): Cung cấp mức nén tốt hơn **Level3**.
- [**Level5**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level5): Cung cấp mức nén cải thiện hơn **Level4** nhưng tốn thời gian xử lý thêm.
- [**Level6**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level6): Nén tiêu chuẩn cung cấp cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- [**Level7**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level7): Cung cấp mức nén tốt hơn **Level6** nhưng xử lý chậm hơn.
- [**Level8**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level8): Cung cấp mức nén tốt hơn **Level7**.
- [**Level9**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compressionlevel/#Level9): Nén tối đa. Tạo kích thước tệp nhỏ nhất nhưng tốn thời gian xử lý lâu nhất.

Ví dụ sau minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX *không nén* :

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

Ví dụ này cho thấy cách lưu một bản trình chiếu dưới dạng tệp PPTX với *nén tối đa* :

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

## **Lưu bản trình chiếu mà không làm mới Thumbnail**

Phương thức [PptxOptions.setRefreshThumbnail](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pptxoptions/#setRefreshThumbnail-boolean-) điều khiển việc tạo thumbnail khi lưu một bản trình chiếu thành PPTX:

- Nếu đặt thành `true`, thumbnail sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, thumbnail hiện tại sẽ được giữ nguyên. Nếu bản trình chiếu không có thumbnail, sẽ không tạo thumbnail nào.

Trong đoạn mã dưới đây, bản trình chiếu được lưu dưới dạng PPTX mà không làm mới thumbnail của nó.

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
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bản trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Lưu Cập nhật Tiến trình dưới Dạng Phần trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `setProgressCallback` được cung cấp bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iprogresscallback/) bằng `setProgressCallback` để nhận cập nhật tiến độ lưu dưới dạng phần trăm.

Các đoạn mã sau cho thấy cách sử dụng `IProgressCallback`.

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

class ExportProgressHandler implements IProgressCallback {
    public void reporting(double progressValue) {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = (int) progressValue;

        System.out.println(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API riêng của mình. Ứng dụng cho phép bạn chia một bản trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **CÂU HỎI THƯỜNG GẶP**

**Liệu “fast save” (lưu tăng dần) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Việc lưu luôn tạo ra tệp đích đầy đủ mỗi lần; “fast save” tăng dần không được hỗ trợ.

**Có an toàn đa luồng để lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/androidjava/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/androidjava/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể thiết lập/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/androidjava/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.