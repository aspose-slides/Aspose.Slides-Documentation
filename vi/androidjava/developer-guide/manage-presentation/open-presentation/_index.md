---
title: Mở bản trình chiếu trên Android
linktitle: Mở bản trình chiếu
type: docs
weight: 20
url: /vi/androidjava/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
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
- Android
- Java
- Aspose.Slides
description: "Mở các bản trình chiếu PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho Android qua Java—nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo các bản trình chiếu PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bản trình chiếu hiện có. Sau khi tải một bản trình chiếu, bạn có thể truy xuất thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có và nhiều hơn nữa.

## **Mở bản trình chiếu**

Để mở một bản trình chiếu hiện có, khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm tạo của nó.

Ví dụ Java sau đây cho thấy cách mở một bản trình chiếu và lấy số lượng slide:

```java
// Khởi tạo lớp Presentation và truyền đường dẫn tệp vào hàm tạo của nó.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // In ra tổng số slide trong bản trình chiếu.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở bản trình chiếu được bảo vệ bằng mật khẩu**

Khi bạn cần mở một bản trình chiếu được bảo vệ bằng mật khẩu, truyền mật khẩu qua phương thức [setPassword](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã Java sau đây minh họa thao tác này:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình chiếu đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Mở bản trình chiếu lớn**

Aspose.Slides cung cấp các tùy chọn—đặc biệt là phương thức [getBlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/)—để giúp bạn tải các bản trình chiếu lớn.

Đoạn mã Java sau đây minh họa việc tải một bản trình chiếu lớn (ví dụ, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Chọn hành vi KeepLocked—tệp bản trình chiếu sẽ vẫn bị khóa trong suốt thời gian tồn tại của
// đối tượng Presentation, nhưng không cần phải được tải vào bộ nhớ hoặc sao chép vào tệp tạm thời.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Bản trình chiếu lớn đã được tải và có thể dùng, trong khi tiêu thụ bộ nhớ vẫn ở mức thấp.

    // Thực hiện các thay đổi đối với bản trình chiếu.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Lưu bản trình chiếu tới một tệp khác. Tiêu thụ bộ nhớ vẫn ở mức thấp trong quá trình này.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Đừng làm điều này! Một ngoại lệ I/O sẽ được ném vì tệp bị khóa cho đến khi đối tượng Presentation được giải phóng.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Có thể thực hiện ở đây. Tệp nguồn không còn bị khóa bởi đối tượng presentation.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Để khắc phục một số hạn chế khi làm việc với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bản trình chiếu lớn từ luồng sẽ gây sao chép bản trình chiếu và có thể làm chậm quá trình tải. Do đó, khi bạn cần tải một bản trình chiếu lớn, chúng tôi mạnh dạn khuyến nghị sử dụng đường dẫn tệp bản trình chiếu thay vì luồng.

Khi tạo một bản trình chiếu chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/androidjava/manage-blob/) để giảm tiêu thụ bộ nhớ.
{{%/alert %}}

## **Kiểm soát tài nguyên bên ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý các tài nguyên bên ngoài. Đoạn mã Java sau đây cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
```
```java
class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Tải một hình ảnh thay thế.
                byte[] imageData = getImageBytes("aspose-logo.jpg"); // Dùng bất kỳ phương pháp nào để lấy byte
                args.setData(imageData);
                return ResourceLoadingAction.UserProvided;
            } catch (RuntimeException ex) {
                return ResourceLoadingAction.Skip;
            }  catch (IOException ex) {
                ex.printStackTrace();
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Đặt URL thay thế.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return ResourceLoadingAction.Default;
        }
        // Bỏ qua tất cả các hình ảnh khác.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Tải bản trình chiếu mà không có các đối tượng nhị phân nhúng**

Một bản trình chiếu PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [IPresentation.getVbaProject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getVbaProject--));
- Dữ liệu nhúng của đối tượng OLE (có thể truy cập qua [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Bằng cách sử dụng phương thức [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), bạn có thể tải một bản trình chiếu mà không có bất kỳ đối tượng nhị phân nhúng nào.

Phương thức này hữu ích để loại bỏ nội dung nhị phân có khả năng độc hại. Đoạn mã Java sau đây minh họa cách tải một bản trình chiếu mà không có bất kỳ nội dung nhị phân nhúng nào:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình chiếu.
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được một ngoại lệ khi phân tích/kiểm tra định dạng trong quá trình tải. Những lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì xảy ra nếu phông chữ cần thiết bị thiếu khi mở?**

Tệp sẽ được mở, nhưng sau đó [rendering/export](/slides/vi/androidjava/convert-presentation/) có thể thay thế phông chữ. [Configure font substitutions](/slides/vi/androidjava/font-substitution/) hoặc [add the required fonts](/slides/vi/androidjava/custom-font/) vào môi trường runtime.

**Còn media nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bản trình chiếu. Nếu media được tham chiếu qua các đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó khả dụng trong môi trường của bạn; nếu không, [rendering/export](/slides/vi/androidjava/convert-presentation/) có thể bỏ qua media.