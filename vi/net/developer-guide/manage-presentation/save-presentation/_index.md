---
title: Lưu các bản trình chiếu trong .NET
linktitle: Lưu Bản Trình Chiếu
type: docs
weight: 80
url: /vi/net/save-presentation/
keywords:
- lưu PowerPoint
- lưu OpenDocument
- lưu bản trình chiếu
- lưu slide
- lưu PPT
- lưu PPTX
- lưu ODP
- bản trình chiếu thành tệp
- bản trình chiếu thành luồng
- kiểu hiển thị đã định nghĩa trước
- Định dạng Office Open XML Chặt chẽ
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách lưu các bản trình chiếu trong .NET bằng Aspose.Slides—xuất sang PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in C#](/slides/vi/net/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để mở một bản trình chiếu. Bài viết này giải thích cách tạo và lưu các bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) chứa nội dung của bản trình chiếu. Cho dù bạn đang tạo một bản trình chiếu từ đầu hay sửa đổi một bản hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho .NET, bạn có thể lưu vào **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bản trình chiếu.

## **Lưu bản trình chiếu thành tệp**

Lưu một bản trình chiếu vào tệp bằng cách gọi phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ sau đây cho thấy cách lưu một bản trình chiếu bằng Aspose.Slides.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Thực hiện một số công việc ở đây...

    // Lưu bản trình chiếu vào một tệp.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Lưu bản trình chiếu vào luồng**

Bạn có thể lưu một bản trình chiếu vào luồng bằng cách truyền một luồng đầu ra vào phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Một bản trình chiếu có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng ta tạo một bản trình chiếu mới và lưu nó vào một luồng tệp.

```cs
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Lưu bản trình chiếu vào luồng.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Lưu bản trình chiếu với Kiểu hiển thị đã định nghĩa trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bản trình chiếu được tạo mở thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/). Đặt thuộc tính [LastView](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/lastview/) thành một giá trị trong enum [ViewType](https://reference.aspose.com/slides/vi/net/aspose.slides/viewtype/).

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML Chặt chẽ**

Aspose.Slides cho phép bạn lưu một bản trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.Iso29500_2008_Strict`, tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bản trình chiếu và lưu nó ở định dạng Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
using (Presentation presentation = new Presentation())
{
    // Lưu bản trình chiếu ở định dạng Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Lưu bản trình chiếu ở Định dạng Office Open XML trong chế độ Zip64**

Một tệp Office Open XML là một kho ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước không nén của bất kỳ tệp nào, kích thước nén của bất kỳ tệp nào và tổng kích thước của kho, đồng thời giới hạn số tệp trong kho là 65 535 (2^16‑1). Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Thuộc tính [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/zip64mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng ZIP64 khi lưu một tệp Office Open XML.

Thuộc tính này cung cấp các chế độ sau:

- `IfNecessary` sử dụng phần mở rộng ZIP64 chỉ nếu bản trình chiếu vượt quá các hạn chế trên. Đây là chế độ mặc định.
- `Never` không bao giờ sử dụng phần mở rộng ZIP64.
- `Always` luôn sử dụng phần mở rộng ZIP64.

Đoạn mã sau minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX với phần mở rộng ZIP64 được bật:

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.Never`, một [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/) sẽ được ném nếu không thể lưu bản trình chiếu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bản trình chiếu ở Định dạng Office Open XML với Các mức nén**

Khi làm việc với các bản trình chiếu lớn, bạn có thể điều chỉnh mức nén để cân bằng kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp thuộc tính [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/compressionlevel/), cho phép bạn chỉ định mức nén được sử dụng khi lưu một bản trình chiếu ở định dạng Office Open XML.

Các mức nén sau đây khả dụng:

- **None**: Không áp dụng nén. Các tệp được lưu nguyên trạng.
- **Level1:** Nén nhanh nhất với tỷ lệ nén thấp nhất.
- **Level2:** Nén nhanh hơn với tỷ lệ nén hơi tốt hơn **Level1**.
- **Level3:** Cung cấp nén tốt hơn **Level2** với ảnh hưởng trung bình tới thời gian xử lý.
- **Level4:** Cung cấp nén tốt hơn **Level3**.
- **Level5:** Cung cấp nén cải thiện hơn **Level4** với thời gian xử lý bổ sung.
- **Level6:** Nén tiêu chuẩn, cung cấp cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- **Level7:** Cung cấp nén tốt hơn **Level6** nhưng chậm hơn.
- **Level8:** Cung cấp nén tốt hơn **Level7**.
- **Level9:** Nén tối đa. Tạo kích thước tệp nhỏ nhất với thời gian xử lý dài nhất.

Ví dụ sau minh họa cách lưu một bản trình chiếu dưới dạng tệp PPTX *không nén*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Ví dụ này cho thấy cách lưu một bản trình chiếu dưới dạng tệp PPTX với *nén tối đa*:

```cs
using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Thuộc tính [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bản trình chiếu thành PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bản trình chiếu không có hình thu nhỏ, sẽ không tạo hình thu nhỏ.

Trong đoạn mã dưới đây, bản trình chiếu được lưu thành PPTX mà không làm mới hình thu nhỏ.

```cs
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu bản trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu dưới dạng phần trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) được sử dụng thông qua thuộc tính `ProgressCallback` do giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/) cung cấp. Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) cho `ProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

Các đoạn mã sau cho thấy cách sử dụng `IProgressCallback`.

```cs
ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
class ExportProgressHandler : IProgressCallback
{
    public void Reporting(double progressValue)
    {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = Convert.ToInt32(progressValue);

        Console.WriteLine(progress + "% of the file has been converted.");
    }
}
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng Splitter PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bản trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn dưới dạng tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**"Lưu nhanh" (lưu tăng) có được hỗ trợ để chỉ ghi những thay đổi không?**

Không. Mỗi lần lưu đều tạo ra toàn bộ tệp đích; không hỗ trợ "lưu nhanh" (tăng).

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) [không an toàn đa luồng]; hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với các liên kết siêu văn bản và tệp liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ, video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/net/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.