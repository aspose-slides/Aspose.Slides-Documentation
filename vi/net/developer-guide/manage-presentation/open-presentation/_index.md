---
title: Mở bản trình chiếu trong .NET
linktitle: Mở bản trình chiếu
type: docs
weight: 20
url: /vi/net/open-presentation/
keywords:
- mở PowerPoint
- mở bản trình chiếu
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình chiếu
- tải PPTX
- tải PPT
- tải ODP
- bản trình chiếu được bảo mật
- bản trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- .NET
- C#
- Aspose.Slides
description: "Tìm hiểu cách mở các bản trình chiếu PowerPoint và OpenDocument trong C#, cung cấp mật khẩu mở, kiểm soát việc tải tài nguyên và giảm sử dụng bộ nhớ với Aspose.Slides cho .NET."
---
## **Giới thiệu**

[Aspose.Slides for .NET](https://products.aspose.com/slides/vi/net/) có thể tải các bản trình chiếu PowerPoint và OpenDocument từ tệp và luồng. Sau khi bản trình chiếu được tải, bạn có thể kiểm tra cấu trúc của nó, chỉnh sửa các slide, quản lý tài nguyên và lưu lại ở định dạng gốc hoặc định dạng được hỗ trợ khác.

Hành vi tải có thể được tùy chỉnh thông qua lớp [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/). Ví dụ, bạn có thể cung cấp mật khẩu mở, giữ các đối tượng nhị phân lớn ngoài bộ nhớ quản lý, điều khiển tài nguyên bên ngoài, hoặc bỏ qua dữ liệu nhị phân được nhúng.

## **Mở Bản Trình Chiếu**

Sau khi tải tệp hoặc luồng, bạn có thể [xác định định dạng bản trình chiếu gốc](/slides/vi/net/detect-presentation-source-format/) để chọn cách ứng dụng của bạn xử lý nó.

Để mở một bản trình chiếu hiện có, truyền đường dẫn tệp của nó vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Hủy đối tượng presentation sau khi sử dụng để các tay cầm tệp, dữ liệu tạm thời và các tài nguyên khác được giải phóng kịp thời.

Ví dụ C# sau cho thấy cách mở một bản trình chiếu và lấy số lượng slide:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("sample.pptx");

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

## **Mở Bản Trình Chiếu Được Bảo Mật Bằng Mật Khẩu**

Mật khẩu mở mã hoá nội dung của bản trình chiếu. Để tải toàn bộ bản trình chiếu, gán mật khẩu đúng vào [LoadOptions.Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) và truyền các tùy chọn này vào hàm khởi tạo [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/). Việc tải sẽ thất bại nếu mật khẩu bị thiếu hoặc không chính xác.

```csharp
using System;
using Aspose.Slides;

var loadOptions = new LoadOptions { Password = "open_password" };
using var presentation = new Presentation("encrypted-presentation.pptx", loadOptions);

Console.WriteLine("Slide count: " + presentation.Slides.Count);
```

Đối với việc phát hiện mật khẩu, xác thực và quy trình mã hoá, xem [Password-Protect Presentations](/slides/vi/net/password-protected-presentation/). Nếu một bản trình chiếu đã được mã hoá nhưng được lưu có các thuộc tính tài liệu công khai, các thuộc tính đó vẫn có thể đọc được mà không cần mật khẩu; xem [Manage Presentation Properties](/slides/vi/net/presentation-properties/).

## **Mở Bản Trình Chiếu Lớn**

[LoadOptions.BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/blobmanagementoptions/) kiểm soát cách Aspose.Slides xử lý các đối tượng nhị phân lớn như ảnh, âm thanh và video. Bạn có thể giữ tệp nguồn bị khóa, cho phép tạo các tệp tạm thời và giới hạn lượng dữ liệu BLOB được giữ trong bộ nhớ.

Mã C# sau minh họa cách tải một bản trình chiếu lớn (ví dụ, 2 GB):

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

const string filePath = "large-presentation.pptx";

var loadOptions = new LoadOptions
{
    BlobManagementOptions =
    {
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024
    }
};

using var presentation = new Presentation(filePath, loadOptions);

presentation.Slides[0].Name = "Large presentation";
presentation.Save("large-presentation-copy.pptx", SaveFormat.Pptx);
```

{{% alert color="info" title="Note" %}}
Với `PresentationLockingBehavior.KeepLocked`, tệp nguồn vẫn bị khóa cho đến khi đối tượng `Presentation` được hủy. Không di chuyển, ghi đè hoặc xóa tệp nguồn trong khi đối tượng này còn tồn tại.

Aspose.Slides có thể sao chép nội dung của một luồng đầu vào trong quá trình tải. Đối với các bản trình chiếu lớn, việc sử dụng đường dẫn tệp thường hiệu quả hơn so với luồng. Xem [Manage BLOBs](/slides/vi/net/manage-blob/) để biết thêm các tùy chọn lưu trữ và quản lý bộ nhớ.
{{% /alert %}}

## **Kiểm Soát Tài Nguyên Bên Ngoài**

[LoadOptions.ResourceLoadingCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/resourceloadingcallback/) nhận một triển khai của [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iresourceloadingcallback/). Callback có thể cung cấp dữ liệu thay thế, chuyển hướng tài nguyên, sử dụng bộ tải mặc định, hoặc bỏ qua tài nguyên. Điều này hữu ích khi các bản trình chiếu chứa hình ảnh bên ngoài cần được giải quyết theo các quy tắc bảo mật hoặc lưu trữ riêng của ứng dụng.

```csharp
using System;
using System.IO;
using Aspose.Slides;

internal static class OpenPresentationExample
{
    private static void Main()
    {
        var loadOptions = new LoadOptions
        {
            ResourceLoadingCallback = new ImageLoadingHandler()
        };

        using var presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
        Console.WriteLine("Slide count: " + presentation.Slides.Count);
    }

    private sealed class ImageLoadingHandler : IResourceLoadingCallback
    {
        public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
        {
            var isJpeg = args.OriginalUri.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase);
            if (!isJpeg || !File.Exists("approved-image.jpg"))
            {
                return ResourceLoadingAction.Skip;
            }

            var imageData = File.ReadAllBytes("approved-image.jpg");
            args.SetData(imageData);
            return ResourceLoadingAction.UserProvided;
        }
    }
}
```

## **Tải Bản Trình Chiếu mà không có Các Đối Tượng Nhị Phân Được Nhúng**

Một bản trình chiếu có thể chứa dữ liệu nhị phân được nhúng mà ứng dụng không cần hoặc không muốn giữ lại. Các ví dụ bao gồm:

- Dự án VBA, có sẵn qua [IPresentation.VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/vbaproject/);
- dữ liệu OLE được nhúng, có sẵn qua [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/);
- dữ liệu điều khiển ActiveX, có sẵn qua [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/vi/net/aspose.slides/icontrol/activexcontrolbinary/).

Đặt [LoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/deleteembeddedbinaryobjects/) thành `true` để loại bỏ dữ liệu nhị phân này trong khi tải. Lưu bản trình chiếu đã tải để duy trì kết quả đã được làm sạch.

Tùy chọn này giảm thiểu nguy cơ các tải trọng nhúng không mong muốn, nhưng nó không phải là một hệ thống phát hiện phần mềm độc hại hoặc làm sạch nội dung hoàn chỉnh.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DeleteEmbeddedBinaryObjects = true
};

using var presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);

presentation.Save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
```

## **Câu Hỏi Thường Gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Aspose.Slides ném ra một ngoại lệ phân tích cú pháp hoặc định dạng trong quá trình tải. Hãy xử lý lỗi này riêng biệt với lỗi mật khẩu không đúng để ứng dụng có thể báo cáo nguyên nhân một cách chính xác.

**Điều gì xảy ra nếu các phông chữ bắt buộc bị thiếu?**

Bản trình chiếu vẫn có thể tải, nhưng việc hiển thị và xuất có thể thay thế phông chữ. Bạn có thể [configure font substitution](/slides/vi/net/font-substitution/) hoặc [provide custom fonts](/slides/vi/net/custom-font/) để làm cho kết quả đầu ra dự đoán được hơn.

**Việc tải một bản trình chiếu cũng tải các phương tiện nhúng của nó không?**

Âm thanh và video được nhúng sẽ khả dụng thông qua mô hình đối tượng của bản trình chiếu. Các tài nguyên bên ngoài được giải quyết theo hành vi tải tài nguyên đã cấu hình và có thể không khả dụng nếu không thể truy cập vị trí của chúng.