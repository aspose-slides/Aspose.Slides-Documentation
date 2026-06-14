---
title: Mở bản trình chiếu trong JavaScript
linktitle: Mở Bản Trình Chiếu
type: docs
weight: 20
url: /vi/nodejs-java/open-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Mở các bản trình chiếu PowerPoint (.pptx, .ppt) và OpenDocument (.odp) một cách dễ dàng với Aspose.Slides cho Node.js qua Java - nhanh, đáng tin cậy, đầy đủ tính năng."
---
## **Giới thiệu**

Ngoài việc tạo các bản trình chiếu PowerPoint từ đầu, Aspose.Slides còn cho phép bạn mở các bản trình chiếu đã tồn tại. Sau khi tải một bản trình chiếu, bạn có thể truy xuất thông tin về nó, chỉnh sửa nội dung slide, thêm slide mới, xóa các slide hiện có, và hơn thế nữa.

## **Mở bản trình chiếu**

Để mở một bản trình chiếu đã tồn tại, khởi tạo lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và truyền đường dẫn tệp vào hàm tạo của nó.

Ví dụ JavaScript sau cho thấy cách mở một bản trình chiếu và lấy số lượng slide của nó:

```js
// Khởi tạo lớp Presentation và truyền đường dẫn tệp vào hàm tạo của nó.
let presentation = new aspose.slides.Presentation("Sample.pptx");
try {
    // In ra tổng số slide trong bản trình chiếu.
    console.log(presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Mở bản trình chiếu có mật khẩu**

Khi bạn cần mở một bản trình chiếu được bảo vệ bằng mật khẩu, hãy truyền mật khẩu qua phương thức [setPassword](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setPassword) của lớp [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/) để giải mã và tải nó. Đoạn mã JavaScript sau minh họa thao tác này:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setPassword("YOUR_PASSWORD");

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình chiếu đã giải mã.
} finally {
    presentation.dispose();
}
```

## **Mở bản trình chiếu lớn**

Aspose.Slides cung cấp các tùy chọn — đặc biệt là phương thức [getBlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) trong lớp [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/) — để giúp bạn tải các bản trình chiếu lớn.

Đoạn mã JavaScript sau minh họa việc tải một bản trình chiếu lớn (ví dụ, 2 GB):

```js
const filePath = "LargePresentation.pptx";

let loadOptions = new aspose.slides.LoadOptions();
// Choose the KeepLocked behavior—the presentation file will remain locked for the lifetime of
// the Presentation instance, but it does not need to be loaded into memory or copied to a temporary file.
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024); // 10 MB

let presentation = new aspose.slides.Presentation(filePath, loadOptions);
try {
    // Bản trình chiếu lớn đã được tải và có thể sử dụng, trong khi mức tiêu thụ bộ nhớ vẫn thấp.
    
    // Thực hiện các thay đổi cho bản trình chiếu.
    presentation.getSlides().get_Item(0).setName("Large presentation");

    // Lưu bản trình chiếu vào một tệp khác. Mức tiêu thụ bộ nhớ vẫn thấp trong quá trình này.
    presentation.save("LargePresentation-copy.pptx", aspose.slides.SaveFormat.Pptx);

    // Đừng làm điều này! Một ngoại lệ I/O sẽ được ném vì tệp bị khóa cho đến khi đối tượng presentation được giải phóng.
    //fs.unlinkSync(filePath);
} finally {
    presentation.dispose();
}

// Có thể thực hiện ở đây. Tệp nguồn không còn bị khóa bởi đối tượng presentation.
fs.unlinkSync(filePath);
```

{{% alert color="info" title="Info" %}}
Để khắc phục một số hạn chế khi làm việc với stream, Aspose.Slides có thể sao chép nội dung của stream. Tải một bản trình chiếu lớn từ stream sẽ gây sao chép bản trình chiếu và làm chậm quá trình tải. Do đó, khi bạn cần tải một bản trình chiếu lớn, chúng tôi mạnh mẽ khuyên bạn nên sử dụng đường dẫn tệp bản trình chiếu thay vì stream.

Khi tạo một bản trình chiếu chứa các đối tượng lớn (video, audio, hình ảnh độ phân giải cao, v.v.), bạn có thể sử dụng [BLOB management](/slides/vi/nodejs-java/manage-blob/) để giảm tiêu thụ bộ nhớ.
{{%/alert %}}

## **Kiểm soát tài nguyên bên ngoài**

Aspose.Slides cung cấp giao diện [IResourceLoadingCallback](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iresourceloadingcallback/) cho phép bạn quản lý các tài nguyên bên ngoài. Đoạn mã JavaScript sau cho thấy cách sử dụng giao diện `IResourceLoadingCallback`:

```js
const ImageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
  resourceLoading: function(args) {
        if (args.getOriginalUri().endsWith(".jpg")) {
            try {
                // Tải một hình ảnh thay thế.
                const imageData = fs.readFileSync("aspose-logo.jpg");
                args.setData(imageData);
                return aspose.slides.ResourceLoadingAction.UserProvided;
            } catch {
                return aspose.slides.ResourceLoadingAction.Skip;
            }
        } else if (args.getOriginalUri().endsWith(".png")) {
            // Đặt URL thay thế.
            args.setUri("http://www.google.com/images/logos/ps_logo2.png");
            return aspose.slides.ResourceLoadingAction.Default;
        }
        // Bỏ qua tất cả các hình ảnh khác.
        return aspose.slides.ResourceLoadingAction.Skip;
      }
});
```

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setResourceLoadingCallback(ImageLoadingHandler);

let presentation = new aspose.slides.Presentation("Sample.pptx", loadOptions);
```

## **Tải bản trình chiếu mà không có đối tượng nhị phân nhúng**

Một bản trình chiếu PowerPoint có thể chứa các loại đối tượng nhị phân nhúng sau:

- Dự án VBA (có thể truy cập qua [Presentation.getVbaProject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getVbaProject));
- Dữ liệu nhúng OLE object (có thể truy cập qua [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData));
- Dữ liệu nhị phân của điều khiển ActiveX (có thể truy cập qua [Control.getActiveXControlBinary](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/control/#getActiveXControlBinary)).

Bằng cách sử dụng phương thức [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects), bạn có thể tải một bản trình chiếu mà không có bất kỳ đối tượng nhị phân nhúng nào.

Phương thức này hữu ích để loại bỏ nội dung nhị phân có khả năng gây hại. Đoạn mã JavaScript sau minh họa cách tải một bản trình chiếu mà không có bất kỳ nội dung nhị phân nhúng nào:

```js
let loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

let presentation = new aspose.slides.Presentation("malware.ppt", loadOptions);
try {
    // Thực hiện các thao tác trên bản trình chiếu.
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm thế nào tôi có thể nhận biết rằng một tệp bị hỏng và không thể mở được?**

Bạn sẽ nhận được ngoại lệ xác thực/phân tích cú pháp khi tải. Các lỗi này thường đề cập đến cấu trúc ZIP không hợp lệ hoặc các bản ghi PowerPoint bị hỏng.

**Điều gì xảy ra nếu các phông chữ cần thiết bị thiếu khi mở?**

Tệp sẽ mở được, nhưng sau đó [rendering/export](/slides/vi/nodejs-java/convert-presentation/) có thể thay thế phông chữ. [Configure font substitutions](/slides/vi/nodejs-java/font-substitution/) hoặc [add the required fonts](/slides/vi/nodejs-java/custom-font/) vào môi trường chạy.

**Còn về media nhúng (video/audio) khi mở thì sao?**

Chúng sẽ trở thành tài nguyên của bản trình chiếu. Nếu media được tham chiếu qua các đường dẫn bên ngoài, hãy đảm bảo các đường dẫn đó có thể truy cập trong môi trường của bạn; nếu không, [rendering/export](/slides/vi/nodejs-java/convert-presentation/) có thể bỏ qua media.