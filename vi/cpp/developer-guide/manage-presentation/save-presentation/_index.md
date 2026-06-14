---
title: Lưu bản trình chiếu trong C++
linktitle: Lưu bản trình chiếu
type: docs
weight: 80
url: /vi/cpp/save-presentation/
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
- loại chế độ xem đã định nghĩa trước
- định dạng Strict Office Open XML
- chế độ Zip64
- làm mới hình thu nhỏ
- tiến độ lưu
- C++
- Aspose.Slides
description: "Khám phá cách lưu bản trình chiếu trong C++ bằng Aspose.Slides—xuất sang PowerPoint hoặc OpenDocument đồng thời giữ nguyên bố cục, phông chữ và hiệu ứng."
---
## **Tổng quan**

[Open Presentations in C++](/slides/vi/cpp/open-presentation/) mô tả cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) để mở một bản trình chiếu. Bài viết này giải thích cách tạo và lưu bản trình chiếu. Lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) chứa nội dung của bản trình chiếu. Cho dù bạn tạo một bản trình chiếu từ đầu hay chỉnh sửa một bản đã tồn tại, bạn sẽ muốn lưu nó sau khi hoàn thành. Với Aspose.Slides cho C++, bạn có thể lưu dưới dạng **tệp** hoặc **luồng**. Bài viết này giải thích các cách khác nhau để lưu bản trình chiếu.

## **Lưu bản trình chiếu vào tệp**

Lưu một bản trình chiếu vào tệp bằng cách gọi phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Truyền tên tệp và định dạng lưu cho phương thức. Ví dụ dưới đây cho thấy cách lưu bản trình chiếu bằng Aspose.Slides.

```cpp
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Thực hiện một số công việc ở đây...

// Lưu bản trình chiếu vào tệp.
presentation->Save(u"Output.pptx", SaveFormat::Pptx);

presentation->Dispose();
```

## **Lưu bản trình chiếu vào luồng**

Bạn có thể lưu một bản trình chiếu vào luồng bằng cách truyền một luồng đầu ra cho phương thức `Save` của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/). Một bản trình chiếu có thể được ghi vào nhiều loại luồng. Trong ví dụ dưới đây, chúng tôi tạo một bản trình chiếu mới và lưu nó vào luồng tệp.

```cpp
// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

auto fileStream = MakeObject<FileStream>(u"Output.pptx", FileMode::Create);

// Lưu bản trình chiếu vào luồng.
presentation->Save(fileStream, SaveFormat::Pptx);

presentation->Dispose();
fileStream->Close();
```

## **Lưu bản trình chiếu với loại chế độ xem đã định nghĩa trước**

Aspose.Slides cho phép bạn đặt chế độ xem ban đầu mà PowerPoint sử dụng khi bản trình chiếu được tạo ra mở thông qua lớp [ViewProperties](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/). Sử dụng phương thức [set_LastView](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewproperties/set_lastview/) với một giá trị từ enumeration [ViewType](https://reference.aspose.com/slides/vi/cpp/aspose.slides/viewtype/).

```cpp
auto presentation = MakeObject<Presentation>();

presentation->get_ViewProperties()->set_LastView(ViewType::SlideMasterView);

presentation->Save(u"SlideMasterView.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

## **Lưu bản trình chiếu ở định dạng Strict Office Open XML**

Aspose.Slides cho phép bạn lưu một bản trình chiếu ở định dạng Strict Office Open XML. Sử dụng lớp [PptxOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/) và đặt thuộc tính conformance khi lưu. Nếu bạn đặt `Conformance.Iso29500_2008_Strict`, tệp đầu ra sẽ được lưu ở định dạng Strict Office Open XML.

Ví dụ dưới đây tạo một bản trình chiếu và lưu nó ở định dạng Strict Office Open XML.

```cpp
auto options = MakeObject<PptxOptions>();
options->set_Conformance(Conformance::Iso29500_2008_Strict);

// Khởi tạo lớp Presentation đại diện cho tệp bản trình chiếu.
auto presentation = MakeObject<Presentation>();

// Lưu bản trình chiếu ở định dạng Strict Office Open XML.
presentation->Save(u"StrictOfficeOpenXml.pptx", SaveFormat::Pptx, options);
presentation->Dispose();
```

## **Lưu bản trình chiếu ở định dạng Office Open XML ở chế độ Zip64**

Một tệp Office Open XML là một lưu trữ ZIP áp đặt giới hạn 4 GB (2^32 byte) cho kích thước chưa nén của bất kỳ tệp nào, kích thước đã nén của bất kỳ tệp nào và tổng kích thước của lưu trữ, đồng thời giới hạn lưu trữ ở 65 535 (2^16-1) tệp. Các phần mở rộng định dạng ZIP64 nâng các giới hạn này lên 2^64.

Phương thức [IPptxOptions::set_Zip64Mode](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/ipptxoptions/set_zip64mode/) cho phép bạn chọn khi nào sử dụng các phần mở rộng định dạng ZIP64 khi lưu tệp Office Open XML.

Phương thức này có thể được sử dụng với các chế độ sau:

- `IfNecessary` chỉ sử dụng phần mở rộng ZIP64 nếu bản trình chiếu vượt quá các giới hạn trên. Đây là chế độ mặc định.
- `Never` không bao giờ sử dụng phần mở rộng ZIP64.
- `Always` luôn luôn sử dụng phần mở rộng ZIP64.

Mã dưới đây minh họa cách lưu một bản trình chiếu dưới dạng PPTX với phần mở rộng ZIP64 được bật:

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_Zip64Mode(Zip64Mode::Always);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"OutputZip64.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="NOTE" color="warning" %}}
Khi bạn lưu với `Zip64Mode.Never`, một [PptxException](https://reference.aspose.com/slides/vi/cpp/aspose.slides/pptxexception/) sẽ được ném nếu không thể lưu bản trình chiếu ở định dạng ZIP32.
{{% /alert %}}

## **Lưu bản trình chiếu mà không làm mới hình thu nhỏ**

Phương thức [PptxOptions::set_RefreshThumbnail](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/pptxoptions/set_refreshthumbnail/) kiểm soát việc tạo hình thu nhỏ khi lưu bản trình chiếu sang PPTX:

- Nếu đặt thành `true`, hình thu nhỏ sẽ được làm mới trong quá trình lưu. Đây là mặc định.
- Nếu đặt thành `false`, hình thu nhỏ hiện tại sẽ được giữ lại. Nếu bản trình chiếu không có hình thu nhỏ, sẽ không tạo hình thu nhỏ nào.

Trong đoạn mã dưới đây, bản trình chiếu được lưu dưới dạng PPTX mà không làm mới hình thu nhỏ.

```cpp
auto pptxOptions = MakeObject<PptxOptions>();
pptxOptions->set_RefreshThumbnail(false);

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pptx", SaveFormat::Pptx, pptxOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Tùy chọn này giúp giảm thời gian lưu bản trình chiếu ở định dạng PPTX.
{{% /alert %}}

## **Cập nhật tiến độ lưu dưới dạng phần trăm**

Giao diện [IProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/) được sử dụng thông qua phương thức `set_ProgressCallback` được công khai bởi giao diện [ISaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/isaveoptions/) và lớp trừu tượng [SaveOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/saveoptions/). Gán một triển khai [IProgressCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iprogresscallback/) với `set_ProgressCallback` để nhận các cập nhật tiến độ lưu dưới dạng phần trăm.

Các đoạn mã dưới đây cho thấy cách sử dụng `IProgressCallback`.

```cpp
class ExportProgressHandler : public IProgressCallback
{
public:
    void Reporting(double progressValue)
    {
        // Sử dụng giá trị phần trăm tiến độ ở đây.
        int progress = static_cast<int>(progressValue);

        Console::WriteLine(u"{0}% of the file has been converted.", progress);
    }
};
```
```cpp
auto saveOptions = MakeObject<PdfOptions>();
saveOptions->set_ProgressCallback(MakeObject<ExportProgressHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx");

presentation->Save(u"Output.pdf", SaveFormat::Pdf, saveOptions);
presentation->Dispose();
```

{{% alert title="Info" color="info" %}}
Aspose đã phát triển một [ứng dụng PowerPoint Splitter miễn phí](https://products.aspose.app/slides/vi/splitter) sử dụng API của mình. Ứng dụng cho phép bạn tách một bản trình chiếu thành nhiều tệp bằng cách lưu các slide đã chọn thành các tệp PPTX hoặc PPT mới.
{{% /alert %}}

## **Câu hỏi thường gặp**

**Có hỗ trợ “lưu nhanh” (lưu tăng dần) để chỉ ghi các thay đổi không?**

Không. Mỗi lần lưu sẽ tạo toàn bộ tệp đích; “lưu nhanh” tăng dần không được hỗ trợ.

**Có an toàn đa luồng khi lưu cùng một thể hiện Presentation từ nhiều luồng không?**

Không. Một thể hiện [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) [không an toàn đa luồng](/slides/vi/cpp/multithreading/); hãy lưu nó từ một luồng duy nhất.

**Điều gì xảy ra với siêu liên kết và các tệp được liên kết bên ngoài khi lưu?**

[Hyperlinks](/slides/vi/cpp/manage-hyperlinks/) được giữ nguyên. Các tệp liên kết bên ngoài (ví dụ video qua đường dẫn tương đối) không được sao chép tự động — hãy đảm bảo các đường dẫn được tham chiếu vẫn khả dụng.

**Tôi có thể đặt/lưu siêu dữ liệu tài liệu (Tác giả, Tiêu đề, Công ty, Ngày) không?**

Có. Các [thuộc tính tài liệu](/slides/vi/cpp/presentation-properties/) tiêu chuẩn được hỗ trợ và sẽ được ghi vào tệp khi lưu.