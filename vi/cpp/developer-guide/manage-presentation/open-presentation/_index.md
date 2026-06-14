---
title: Mở Bài Trình Chiếu trong C++
linktitle: Mở Bài Trình Chiếu
type: docs
weight: 20
url: /vi/cpp/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
- mở bài trình chiếu
- mở PPTX
- mở PPT
- mở ODP
- tải bài trình chiếu
- tải PPTX
- tải PPT
- tải ODP
- bài trình chiếu được bảo vệ
- bài trình chiếu lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- C++
- Aspose.Slides
description: "Mở các bài trình chiếu PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho C++—nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo bản trình chiếu PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bản trình chiếu đã tồn tại. Sau khi tải một bản trình chiếu, bạn có thể truy xuất thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có và nhiều hơn nữa.

## **Mở bản trình chiếu**

Để mở một bản trình chiếu đã tồn tại, tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm khởi tạo của nó.

Ví dụ C++ sau cho thấy cách mở một bản trình chiếu và lấy số lượng slide:

```cpp
// Tạo thể hiện của lớp Presentation và truyền đường dẫn tệp vào hàm khởi tạo.
auto presentation = MakeObject<Presentation>(u"Sample.pptx");

// In ra tổng số slide trong bản trình chiếu.
Console::WriteLine(presentation->get_Slides()->get_Count());

presentation->Dispose();
```

## **Mở bản trình chiếu có mật khẩu**

Khi bạn cần mở một bản trình chiếu được bảo vệ bằng mật khẩu, truyền mật khẩu qua phương thức [set_Password](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/set_password/) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã C++ sau minh họa thao tác này:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_Password(u"YOUR_PASSWORD");

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
    
// Thực hiện các thao tác trên bản trình chiếu đã giải mã.

presentation->Dispose();
```

## **Mở bản trình chiếu lớn**

Aspose.Slides cung cấp các tùy chọn — đặc biệt là phương thức [get_BlobManagementOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/get_blobmanagementoptions/) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/cpp/aspose.slides/loadoptions/) — để giúp bạn tải các bản trình chiếu lớn.

Đoạn mã C++ sau minh họa việc tải một bản trình chiếu lớn (ví dụ, 2 GB):

```cpp
auto filePath = u"LargePresentation.pptx";

auto loadOptions = MakeObject<LoadOptions>();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions->get_BlobManagementOptions()->set_PresentationLockingBehavior(PresentationLockingBehavior::KeepLocked);
loadOptions->get_BlobManagementOptions()->set_IsTemporaryFilesAllowed(true);
loadOptions->get_BlobManagementOptions()->set_MaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

auto presentation = MakeObject<Presentation>(filePath, loadOptions);

// The large presentation has been loaded and can be used, while memory consumption remains low.
// The large presentation has been loaded and can be used, while memory consumption remains low.
 // Actually we translate only original comment:
 // Đúng: We need replace original comment with translation:
 // Actually let's rewrite proper translation:

// Bản trình chiếu lớn đã được tải và có thể sử dụng, trong khi tiêu thụ bộ nhớ vẫn thấp.

// Make changes to the presentation.
 // Thực hiện các thay đổi cho bản trình chiếu.

presentation->get_Slide(0)->set_Name(u"Large presentation");

// Save the presentation to another file. Memory consumption remains low during this operation.
 // Lưu bản trình chiếu vào tệp khác. Tiêu thụ bộ nhớ vẫn thấp trong quá trình này.
presentation->Save(u"LargePresentation-copy.pptx", SaveFormat::Pptx);

// Don't do this! An I/O exception will be thrown because the file is locked until the presentation object is disposed.
 // Đừng làm điều này! Ngoại lệ I/O sẽ được ném ra vì tệp bị khóa cho đến khi đối tượng Presentation được giải phóng.
File::Delete(filePath);

presentation->Dispose();

// It is OK to do it here. The source file is no longer locked by the presentation object.
 // Có thể thực hiện ở đây. Tệp nguồn không còn bị khóa bởi đối tượng Presentation.
File::Delete(filePath);
```

{{% alert color="info" title="Thông tin" %}}
Để khắc phục một số hạn chế khi làm việc với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bản trình chiếu lớn từ luồng sẽ gây sao chép bản trình chiếu và có thể làm chậm quá trình tải. Vì vậy, khi bạn cần tải một bản trình chiếu lớn, chúng tôi khuyên mạnh mẽ nên sử dụng đường dẫn tệp của bản trình chiếu thay vì một luồng.

Khi tạo một bản trình chiếu chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/cpp/manage-blob/) để giảm tiêu thụ bộ nhớ.
{{%/alert %}}

## **Kiểm soát tài nguyên bên ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý các tài nguyên bên ngoài. Đoạn mã C++ sau cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

```cpp
class ImageLoadingHandler : public IResourceLoadingCallback
{
public:
    ResourceLoadingAction ResourceLoading(SharedPtr<IResourceLoadingArgs> args) override
    {
        if (args->get_OriginalUri().EndsWith(u".jpg"))
        {
            try
            {
                // Tải một hình ảnh thay thế.
                auto imageData = File::ReadAllBytes(u"aspose-logo.jpg");
                args->SetData(imageData);
                return ResourceLoadingAction::UserProvided;
            }
            catch (Exception&)
            {
                return ResourceLoadingAction::Skip;
            }
        }
        else if (args->get_OriginalUri().EndsWith(u".png"))
        {
            // Đặt URL thay thế.
            args->set_Uri(u"http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction::Default;
        }

        // Bỏ qua tất cả các hình ảnh khác.
        return ResourceLoadingAction::Skip;
    }
};
```

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_ResourceLoadingCallback(MakeObject<ImageLoadingHandler>());

auto presentation = MakeObject<Presentation>(u"Sample.pptx", loadOptions);
```

## **Tải bản trình chiếu mà không có các đối tượng nhị phân nhúng**

Một bản trình chiếu PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [IPresentation::get_VbaProject](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ipresentation/get_vbaproject/));
- Dữ liệu nhúng của đối tượng OLE (có thể truy cập qua [IOleEmbeddedDataInfo::get_EmbeddedFileData](https://reference.aspose.com/slides/vi/cpp/aspose.slides/ioleembeddeddatainfo/get_embeddedfiledata/));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [IControl::get_ActiveXControlBinary](https://reference.aspose.com/slides/vi/cpp/aspose.slides/icontrol/get_activexcontrolbinary/)).

Bằng cách sử dụng phương thức [ILoadOptions::set_DeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/cpp/aspose.slides/iloadoptions/set_deleteembeddedbinaryobjects/), bạn có thể tải một bản trình chiếu mà không có bất kỳ đối tượng nhị phân nhúng nào.

Phương thức này hữu ích để loại bỏ nội dung nhị phân tiềm năng có thể gây hại. Đoạn mã C++ sau minh họa cách tải một bản trình chiếu mà không có bất kỳ nội dung nhị phân nhúng nào:

```cpp
auto loadOptions = MakeObject<LoadOptions>();
loadOptions->set_DeleteEmbeddedBinaryObjects(true);

auto presentation = MakeObject<Presentation>(u"malware.ppt", loadOptions);

// Thực hiện các thao tác trên bản trình chiếu.

presentation->Dispose();
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được một ngoại lệ khi phân tích/kiểm tra định dạng trong quá trình tải. Các lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì xảy ra nếu các phông chữ bắt buộc bị thiếu khi mở?**

Tệp sẽ được mở, nhưng sau đó quá trình [rendering/export](/slides/vi/cpp/convert-presentation/) có thể thay thế phông chữ. [Configure font substitutions](/slides/vi/cpp/font-substitution/) hoặc [add the required fonts](/slides/vi/cpp/custom-font/) vào môi trường runtime.

**Còn các phương tiện nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bản trình chiếu. Nếu phương tiện được tham chiếu qua đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó có thể truy cập trong môi trường của bạn; nếu không, quá trình [rendering/export](/slides/vi/cpp/convert-presentation/) có thể bỏ qua các phương tiện đó.