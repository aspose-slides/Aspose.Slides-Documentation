---
title: Mở các bản trình bày trong Java
linktitle: Mở bản trình bày
type: docs
weight: 20
url: /vi/java/open-presentation/
keywords:
- mở PowerPoint
- mở OpenDocument
- mở bản trình bày
- mở PPTX
- mở PPT
- mở ODP
- tải bản trình bày
- tải PPTX
- tải PPT
- tải ODP
- bản trình bày có bảo mật
- bản trình bày lớn
- tài nguyên bên ngoài
- đối tượng nhị phân
- Java
- Aspose.Slides
description: "Mở các bản trình bày PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho Java—nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo các bản trình bày PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bản trình bày đã tồn tại. Sau khi tải một bản trình bày, bạn có thể lấy thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có, và hơn thế nữa.

## **Mở bản trình bày**

Để mở một bản trình bày hiện có, tạo một đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm tạo của nó.

Ví dụ Java sau đây cho thấy cách mở một bản trình bày và lấy số lượng slide:

```java
// Khởi tạo lớp Presentation và truyền một đường dẫn tệp vào hàm tạo của nó.
Presentation presentation = new Presentation("Sample.pptx");
try {
    // In ra tổng số slide trong bản trình bày.
    System.out.println(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở bản trình bày có bảo mật bằng mật khẩu**

Để mở một bản trình bày được bảo vệ bằng mật khẩu, truyền mật khẩu thông qua phương thức [setPassword](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã Java sau đây minh họa thao tác này:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

Presentation presentation = new Presentation("Sample.pptx", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình bày đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Mở bản trình bày lớn**

Aspose.Slides cung cấp các tùy chọn—đặc biệt là phương thức [getBlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/)—để giúp bạn tải các bản trình bày lớn.

Đoạn mã Java sau đây minh họa cách tải một bản trình bày lớn (ví dụ, 2 GB):

```java
final String filePath = "LargePresentation.pptx";

LoadOptions loadOptions = new LoadOptions();
// Chọn hành vi KeepLocked—tệp bản trình bày sẽ vẫn bị khóa trong suốt thời gian tồn tại của
// đối tượng Presentation, nhưng không cần phải tải vào bộ nhớ hoặc sao chép vào tệp tạm thời.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    // Bản trình bày lớn đã được tải và có thể sử dụng, trong khi tiêu thụ bộ nhớ vẫn thấp.

    // Thực hiện các thay đổi trên bản trình bày.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Lưu bản trình bày vào tệp khác. Tiêu thụ bộ nhớ vẫn thấp trong quá trình này.
    presentation.save("LargePresentation-copy.pptx", SaveFormat.Pptx);

    // Đừng làm điều này! Một ngoại lệ I/O sẽ được ném ra vì tệp bị khóa cho đến khi đối tượng Presentation được giải phóng.
    //Files.delete(Paths.get(filePath));
} finally {
    presentation.dispose();
}

// Có thể thực hiện ở đây. Tệp nguồn không còn bị khóa bởi đối tượng Presentation.
Files.delete(Paths.get(filePath));
```

{{% alert color="info" title="Info" %}}
Để khắc phục một số hạn chế khi làm việc với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Việc tải một bản trình bày lớn từ luồng sẽ khiến bản trình bày được sao chép và có thể làm chậm quá trình tải. Do đó, khi bạn cần tải một bản trình bày lớn, chúng tôi mạnh mẽ khuyên bạn nên sử dụng đường dẫn tệp bản trình bày thay vì luồng.

Khi tạo một bản trình bày chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/java/manage-blob/) để giảm tiêu thụ bộ nhớ.
{{%/alert %}}

## **Kiểm soát tài nguyên bên ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý các tài nguyên bên ngoài. Đoạn mã Java sau đây cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

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
                byte[] imageData = Files.readAllBytes(new File("aspose-logo.jpg").toPath());
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
        // Bỏ qua mọi hình ảnh khác.
        return ResourceLoadingAction.Skip;
    }
}
```

## **Tải bản trình bày mà không có các đối tượng nhị phân nhúng**

Một bản trình bày PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [IPresentation.getVbaProject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getVbaProject--));
- Dữ liệu nhúng của đối tượng OLE (có thể truy cập qua [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/vi/java/com.aspose.slides/icontrol/#getActiveXControlBinary--)).

Bằng cách sử dụng phương thức [ILoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iloadoptions/#setDeleteEmbeddedBinaryObjects-boolean-), bạn có thể tải một bản trình bày mà không có bất kỳ đối tượng nhị phân nhúng nào.

Phương thức này hữu ích để loại bỏ nội dung nhị phân có khả năng độc hại. Đoạn mã Java sau đây minh họa cách tải một bản trình bày mà không có bất kỳ nội dung nhị phân nhúng nào:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("malware.ppt", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình bày.
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm sao tôi biết một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được một ngoại lệ khi phân tích/kiểm tra định dạng trong quá trình tải. Những lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì sẽ xảy ra nếu các phông chữ bắt buộc bị thiếu khi mở?**

Tệp sẽ mở được, nhưng sau này quá trình [rendering/export](/slides/vi/java/convert-presentation/) có thể thay thế phông chữ. Bạn có thể [cấu hình thay thế phông chữ](/slides/vi/java/font-substitution/) hoặc [thêm các phông chữ cần thiết](/slides/vi/java/custom-font/) vào môi trường chạy.

**Còn về phương tiện nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bản trình bày. Nếu các phương tiện được tham chiếu qua các đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó có thể truy cập trong môi trường của bạn; nếu không, quá trình [rendering/export](/slides/vi/java/convert-presentation/) có thể bỏ qua các phương tiện.