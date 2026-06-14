---
title: Mở các bản trình chiếu trong .NET
linktitle: Mở Bản Trình Chiếu
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
- bản trình chiếu được bảo vệ
- bản trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- .NET
- C#
- Aspose.Slides
description: "Mở các bản trình chiếu PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho .NET—nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo các bài thuyết trình PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bài thuyết trình đã tồn tại. Sau khi tải một bài thuyết trình, bạn có thể truy xuất thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có và nhiều hơn nữa.

## **Mở Bài Thuyết Trình**

Để mở một bài thuyết trình đã tồn tại, tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/net/aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm khởi tạo của nó.

Ví dụ C# sau đây cho thấy cách mở một bài thuyết trình và lấy số lượng slide của nó:

```cs
// Khởi tạo lớp Presentation và truyền đường dẫn tệp vào hàm khởi tạo của nó.
using (Presentation presentation = new Presentation("Sample.pptx"))
{
    // In ra tổng số slide trong bản trình chiếu.
    System.Console.WriteLine(presentation.Slides.Count);
}
```

## **Mở Bài Thuyết Trình Được Bảo Vệ Bằng Mật Khẩu**

Khi bạn cần mở một bài thuyết trình được bảo vệ bằng mật khẩu, hãy truyền mật khẩu qua thuộc tính [Password](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/password/) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã C# sau đây minh họa thao tác này:

```cs
LoadOptions loadOptions = new LoadOptions {Password = "YOUR_PASSWORD"};
using (Presentation presentation = new Presentation("Sample.pptx", loadOptions))
{
    // Thực hiện các thao tác trên bản trình chiếu đã giải mã.
}
```

## **Mở Bài Thuyết Trình Lớn**

Aspose.Slides cung cấp các tùy chọn—đặc biệt là thuộc tính [BlobManagementOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/blobmanagementoptions/) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/net/aspose.slides/loadoptions/)—để giúp bạn tải các bài thuyết trình lớn.

Đoạn mã C# sau đây minh họa cách tải một bài thuyết trình lớn (ví dụ, 2 GB):

```cs
const string filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions
{
    BlobManagementOptions = 
    {
        // Chọn hành vi KeepLocked — tệp bản trình chiếu sẽ vẫn bị khóa trong suốt thời gian tồn tại của
        // đối tượng Presentation, nhưng không cần phải tải vào bộ nhớ hoặc sao chép vào tệp tạm thời.
        PresentationLockingBehavior = PresentationLockingBehavior.KeepLocked,
        IsTemporaryFilesAllowed = true,
        MaxBlobsBytesInMemory = 10 * 1024 * 1024 // 10 MB
    }
};

using (Presentation presentation = new Presentation(filePath, loadOptions))
{
    // Bản trình chiếu lớn đã được tải và có thể sử dụng, trong khi mức tiêu thụ bộ nhớ vẫn thấp.

    // Thực hiện các thay đổi cho bản trình chiếu.
    presentation.Slides[0].Name = "Large presentation";

    // Lưu bản trình chiếu vào một tệp khác. Mức tiêu thụ bộ nhớ vẫn thấp trong quá trình này.
    presentation.Save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Đừng làm điều này! Một ngoại lệ I/O sẽ được ném ra vì tệp bị khóa cho đến khi đối tượng presentation được giải phóng.
    File.Delete(filePath);
}

// Ở đây có thể thực hiện. Tệp nguồn không còn bị đối tượng presentation khóa nữa.
File.Delete(filePath);
```

{{% alert color="info" title="Info" %}}
Để khắc phục một số hạn chế khi làm việc với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bài thuyết trình lớn từ một luồng sẽ khiến bài thuyết trình được sao chép và có thể làm chậm quá trình tải. Do đó, khi bạn cần tải một bài thuyết trình lớn, chúng tôi rất khuyến nghị sử dụng đường dẫn tệp của bài thuyết trình thay vì luồng.

Khi tạo một bài thuyết trình chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/net/manage-blob/) để giảm mức tiêu thụ bộ nhớ.
{{%/alert %}}

## **Kiểm Soát Tài Nguyên Ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/net/aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý các tài nguyên ngoài. Đoạn mã C# sau đây cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

```cs
LoadOptions loadOptions = new LoadOptions();
loadOptions.ResourceLoadingCallback = new ImageLoadingHandler();

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```

```cs
public class ImageLoadingHandler : IResourceLoadingCallback
{
    public ResourceLoadingAction ResourceLoading(IResourceLoadingArgs args)
    {
        if (args.OriginalUri.EndsWith(".jpg"))
        {
            try
            {
                // Tải một hình ảnh thay thế.
                byte[] imageData = File.ReadAllBytes("aspose-logo.jpg");
                args.SetData(imageData);
                return ResourceLoadingAction.UserProvided;
            }
            catch (Exception)
            {
                return ResourceLoadingAction.Skip;
            }
        }
        else if (args.OriginalUri.EndsWith(".png"))
        {
            // Đặt URL thay thế.
            args.Uri = "http://www.google.com/images/logos/ps_logo2.png";
            return ResourceLoadingAction.Default;
        }

        // Bỏ qua tất cả các hình ảnh khác.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Tải Bài Thuyết Trình Không Có Đối Tượng Nhị Phân Nhúng**

Một bài thuyết trình PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [IPresentation.VbaProject](https://reference.aspose.com/slides/vi/net/aspose.slides/ipresentation/vbaproject/));
- Dữ liệu nhúng của đối tượng OLE (có thể truy cập qua [IOleEmbeddedDataInfo.EmbeddedFileData](https://reference.aspose.com/slides/vi/net/aspose.slides/ioleembeddeddatainfo/embeddedfiledata/));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [IControl.ActiveXControlBinary](https://reference.aspose.com/slides/vi/net/aspose.slides/icontrol/activexcontrolbinary/)).

Sử dụng thuộc tính [ILoadOptions.DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/net/aspose.slides/iloadoptions/deleteembeddedbinaryobjects/), bạn có thể tải một bài thuyết trình mà không có bất kỳ đối tượng nhị phân nhúng nào.

Thuộc tính này hữu ích để loại bỏ nội dung nhị phân có khả năng độc hại. Đoạn mã C# sau đây minh họa cách tải một bài thuyết trình mà không có bất kỳ nội dung nhị phân nhúng nào:

```cs
LoadOptions loadOptions = new LoadOptions()
{
	DeleteEmbeddedBinaryObjects = true
}

using (Presentation presentation = new Presentation("malware.ppt", loadOptions))
{
    // Thực hiện các thao tác trên bản trình chiếu.
}
```

## **FAQ**

**Làm sao tôi có thể biết rằng một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được một ngoại lệ khi phân tích/kiểm tra định dạng trong quá trình tải. Các lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì xảy ra nếu các phông chữ yêu cầu thiếu khi mở?**

Tệp sẽ được mở, nhưng sau đó [kết xuất/định dạng](/slides/vi/net/convert-presentation/) có thể thay thế phông chữ. [Cấu hình thay thế phông chữ](/slides/vi/net/font-substitution/) hoặc [thêm các phông chữ cần thiết](/slides/vi/net/custom-font/) vào môi trường runtime.

**Còn các phương tiện nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bài thuyết trình. Nếu các phương tiện được tham chiếu qua đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó có thể truy cập được trong môi trường của bạn; nếu không, [kết xuất/định dạng](/slides/vi/net/convert-presentation/) có thể bỏ qua các phương tiện này.