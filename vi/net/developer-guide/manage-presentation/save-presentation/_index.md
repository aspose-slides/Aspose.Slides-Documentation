---
title: Lưu Bài Thuyết Trình trong .NET
linktitle: Lưu Bài Thuyết Trình
type: docs
weight: 80
url: /vi/net/save-presentation/
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
- kiểu xem định nghĩa trước
- Định dạng Office Open XML chặt chẽ
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến trình lưu
- .NET
- C#
- Aspose.Slides
description: "Khám phá cách lưu bài thuyết trình trong .NET bằng Aspose.Slides—xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in C#](/slides/vi/net/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay chỉnh sửa một bài đã tồn tại, bạn sẽ muốn lưu nó khi hoàn tất. Với Aspose.Slides cho .NET, bạn có thể lưu dưới dạng **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài Thuyết Trình vào Tệp**

Lưu một bài thuyết trình vào tệp bằng cách gọi phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu vào phương thức. Ví dụ sau minh họa cách lưu một bài thuyết trình bằng Aspose.Slides.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo thể hiện lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Thực hiện một số công việc ở đây...

    // Lưu bài thuyết trình vào tệp.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Lưu Bài Thuyết Trình vào Luồng**

Bạn có thể lưu một bài thuyết trình vào luồng bằng cách truyền một luồng đầu ra cho phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Một bài thuyết trình có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bài thuyết trình mới và lưu nó vào một luồng tệp.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

// Tạo thể hiện lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    using (FileStream fileStream = new FileStream("Output.pptx", FileMode.Create))
    {
        // Lưu bài thuyết trình vào luồng.
        presentation.Save(fileStream, SaveFormat.Pptx);
    }
}
```

## **Lưu Bài Thuyết Trình với Kiểu Xem Định Nghĩa Trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bài thuyết trình được tạo mở thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/). Đặt thuộc tính [LastView](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/lastview/) thành một giá trị trong enumeration [ViewType](https://reference.aspose.com/slides/vi/net/aspose.slides/viewtype/).

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML Chặt Chẽ**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Office Open XML Chặt Chẽ. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.Iso29500_2008_Strict`, tệp đầu ra sẽ được lưu ở định dạng Office Open XML Chặt Chẽ.

Ví dụ dưới đây tạo một bài thuyết trình và lưu nó ở định dạng Office Open XML Chặt Chẽ.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Tạo thể hiện lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lưu bài thuyết trình ở định dạng Office Open XML chặt chẽ.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML ở Chế Độ Zip64**

Một tệp Office Open XML là một kho ZIP đặt ra giới hạn 4 GB (2^32 byte) cho kích thước không nén của bất kỳ tệp nào, kích thước nén của bất kỳ tệp nào và tổng kích thước của kho, đồng thời giới hạn kho tối đa 65.535 (2^16‑1) tệp. Các phần mở rộng định dạng ZIP64 nâng cao các giới hạn này lên 2^64.

Thuộc tính [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/zip64mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tệp Office Open XML.

Thuộc tính này cung cấp các chế độ sau:

- `IfNecessary` chỉ sử dụng các phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `Never` không bao giờ sử dụng các phần mở rộng ZIP64.
- `Always` luôn luôn sử dụng các phần mở rộng ZIP64.

Mã dưới đây minh họa cách lưu một bài thuyết trình dưới dạng tệp PPTX với các phần mở rộng ZIP64 được bật:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("OutputZip64.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        Zip64Mode = Zip64Mode.Always
    });
}
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.Never`, một [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/) sẽ được ném nếu bài thuyết trình không thể lưu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML với Các Cấp Nén**

Khi làm việc với các bài thuyết trình lớn, bạn có thể điều chỉnh cấp độ nén để cân bằng giữa kích thước tệp và thời gian xử lý. Tùy thuộc vào yêu cầu, bạn có thể ưu tiên xử lý nhanh hơn hoặc tệp đầu ra nhỏ hơn.

Aspose.Slides cung cấp thuộc tính [IPptxOptions.CompressionLevel](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/compressionlevel/), cho phép bạn chỉ định mức nén được sử dụng khi lưu một bài thuyết trình ở định dạng Office Open XML.

Các cấp độ nén khả dụng:

- **None**: Không có nén được áp dụng. Các tệp được lưu nguyên.
- **Level1**: Nén nhanh nhất nhưng tỷ lệ nén thấp nhất.
- **Level2**: Nén nhanh hơn với tỷ lệ nén hơi tốt hơn so với **Level1**.
- **Level3**: Cung cấp nén tốt hơn **Level2** với ảnh hưởng trung bình đến thời gian xử lý.
- **Level4**: Cung cấp nén tốt hơn **Level3**.
- **Level5**: Cung cấp nén cải thiện hơn **Level4** nhưng tốn thêm thời gian xử lý.
- **Level6**: Nén tiêu chuẩn mang lại cân bằng tốt giữa tốc độ xử lý và kích thước tệp. Đây là *mức nén mặc định*.
- **Level7**: Cung cấp nén tốt hơn **Level6** nhưng xử lý chậm hơn.
- **Level8**: Cung cấp nén tốt hơn **Level7**.
- **Level9**: Nén tối đa. Tạo kích thước tệp nhỏ nhất nhưng tốn thời gian xử lý lâu nhất.

Ví dụ dưới đây minh họa cách lưu một bài thuyết trình dưới dạng tệp PPTX *không nén*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-out.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.None
    });
}
```

Ví dụ này cho thấy cách lưu một bài thuyết trình dưới dạng tệp PPTX với *nén tối đa*:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation("Sample.pptx"))
{
    pres.Save("Sample-level9.pptx", SaveFormat.Pptx, new PptxOptions
    {
        CompressionLevel = CompressionLevel.Level9
    });
}
```

## **Lưu Bài Thuyết Trình mà không Làm Mới Hình Thu Nhỏ**

Thuộc tính [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bài thuyết trình dưới dạng PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới khi lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ nguyên. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo nào.

Trong mã dưới đây, bài thuyết trình được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ của nó.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pptx", SaveFormat.Pptx, new PptxOptions()
    {
        RefreshThumbnail = false
    });
}
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu theo Phần Trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) được sử dụng thông qua thuộc tính `ProgressCallback` được công khai bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/). Gán một triển khai của [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) cho `ProgressCallback` để nhận các cập nhật tiến trình lưu dưới dạng phần trăm.

Các đoạn mã sau đây cho thấy cách sử dụng `IProgressCallback`.

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

ISaveOptions saveOptions = new PdfOptions();
saveOptions.ProgressCallback = new ExportProgressHandler();

using (Presentation presentation = new Presentation("Sample.pptx"))
{
    presentation.Save("Output.pdf", SaveFormat.Pdf, saveOptions);
}
```

```cs
using Aspose.Slides;

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
Aspose đã phát triển một [ứng dụng PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của chính mình. Ứng dụng cho phép bạn tách một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu Hỏi Thường Gặp**

**Liệu “fast save” (lưu tăng dần) có được hỗ trợ để chỉ ghi các thay đổi không?**

Không. Khi lưu luôn tạo toàn bộ tệp đích mỗi lần; “fast save” tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/net/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được bảo lưu. Các tệp liên kết bên ngoài (ví dụ: video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [document properties](/slides/vi/net/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.