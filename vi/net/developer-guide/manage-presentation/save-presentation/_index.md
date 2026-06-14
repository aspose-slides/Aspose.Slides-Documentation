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
- bài thuyết trình thành tập tin
- bài thuyết trình thành luồng
- kiểu xem đã định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách lưu bài thuyết trình trong .NET bằng Aspose.Slides—xuất ra PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in C#](/slides/vi/net/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) để mở một bài thuyết trình. Bài viết này giải thích cách tạo và lưu các bài thuyết trình. Lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) chứa nội dung của một bài thuyết trình. Cho dù bạn đang tạo một bài thuyết trình từ đầu hay chỉnh sửa một bài hiện có, bạn sẽ muốn lưu nó khi hoàn thành. Với Aspose.Slides cho .NET, bạn có thể lưu vào **tập tin** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu một bài thuyết trình.

## **Lưu Bài Thuyết Trình vào Tập Tin**

Lưu một bài thuyết trình vào tập tin bằng cách gọi phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) . Truyền tên tập tin và định dạng lưu cho phương thức. Ví dụ sau cho thấy cách lưu một bài thuyết trình bằng Aspose.Slides.

```cs
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Thực hiện một số công việc ở đây...

    // Lưu bài thuyết trình vào một tệp.
    presentation.Save("Output.pptx", SaveFormat.Pptx);
}
```

## **Lưu Bài Thuyết Trình vào Luồng**

Bạn có thể lưu một bài thuyết trình vào luồng bằng cách truyền một luồng đầu ra cho phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) . Một bài thuyết trình có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bài thuyết trình mới và lưu nó vào một luồng tập tin.

```cs
// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
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

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bài thuyết trình được tạo mở ra thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/) . Đặt thuộc tính [LastView](https://reference.aspose.com/slides/vi/net/aspose.slides/viewproperties/lastview/) thành một giá trị trong enum [ViewType](https://reference.aspose.com/slides/vi/net/aspose.slides/viewtype/) .

```cs
using (Presentation presentation = new Presentation())
{
    presentation.ViewProperties.LastView = ViewType.SlideMasterView;
    presentation.Save("SlideMasterView.pptx", SaveFormat.Pptx);
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bài thuyết trình ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.Iso29500_2008_Strict`, tập tin đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới tạo một bài thuyết trình và lưu nó ở định dạng Strict Office Open XML.

```cs
PptxOptions options = new PptxOptions()
{
    Conformance = Conformance.Iso29500_2008_Strict
};

// Khởi tạo lớp Presentation đại diện cho một tệp bài thuyết trình.
using (Presentation presentation = new Presentation())
{
    // Lưu bài thuyết trình ở định dạng Strict Office Open XML.
    presentation.Save("StrictOfficeOpenXml.pptx", SaveFormat.Pptx, options);
}
```

## **Lưu Bài Thuyết Trình ở Định Dạng Office Open XML ở Chế Độ Zip64**

Tập tin Office Open XML là một kho ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tập tin nào, kích thước nén của bất kỳ tập tin nào và tổng kích thước của kho, đồng thời giới hạn số tập tin trong kho tối đa 65 535 (2^16‑1) tập. Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Thuộc tính [IPptxOptions.Zip64Mode](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/zip64mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu một tập tin Office Open XML.

Thuộc tính này cung cấp các chế độ sau:

- `IfNecessary` chỉ sử dụng các phần mở rộng ZIP64 nếu bài thuyết trình vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `Never` không bao giờ sử dụng các phần mở rộng ZIP64.
- `Always` luôn luôn sử dụng các phần mở rộng ZIP64.

Mã sau minh họa cách lưu một bài thuyết trình dưới dạng PPTX với các phần mở rộng định dạng ZIP64 được bật:

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
Khi bạn lưu với `Zip64Mode.Never`, một [PptxException](https://reference.aspose.com/slides/vi/net/aspose.slides/pptxexception/) sẽ được ném nếu không thể lưu bài thuyết trình ở định dạng ZIP32.
{{% /alert %}}

## **Lưu Bài Thuyết Trình mà Không Làm Mới Hình Thu Nhỏ**

Thuộc tính [PptxOptions.RefreshThumbnail](https://reference.aspose.com/slides/vi/net/aspose.slides.export/ipptxoptions/refreshthumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu một bài thuyết trình thành PPTX:

- Nếu được đặt là `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu được đặt là `false`, hình thu nhỏ hiện tại sẽ được bảo tồn. Nếu bài thuyết trình không có hình thu nhỏ, sẽ không tạo mới.

Trong mã dưới đây, bài thuyết trình được lưu thành PPTX mà không làm mới hình thu nhỏ.

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
Tùy chọn này giúp giảm thời gian cần thiết để lưu một bài thuyết trình ở định dạng PPTX.
{{% /alert %}}

## **Cập Nhật Tiến Trình Lưu Theo Phần Trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) được sử dụng thông qua thuộc tính `ProgressCallback` được cung cấp bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/net/aspose.slides.export/saveoptions/) . Gán một triển khai của [IProgressCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iprogresscallback/) cho `ProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

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
Aspose đã phát triển một [ứng dụng Splitter PowerPoint miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn chia một bài thuyết trình thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **FAQ**

**Có hỗ trợ “lưu nhanh” (lưu tăng dần) để chỉ ghi các thay đổi không?**

Không. Khi lưu sẽ tạo toàn bộ tệp mục tiêu mỗi lần; “lưu nhanh” tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/net/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/net/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ, video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn được tham chiếu vẫn có thể truy cập.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [đặc tính tài liệu](/slides/vi/net/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.