---
title: Quản lý BLOB của bản trình chiếu trong JavaScript để sử dụng bộ nhớ hiệu quả
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/nodejs-java/manage-blob/
keywords:
- đối tượng lớn
- mục lớn
- tệp lớn
- thêm BLOB
- xuất BLOB
- thêm hình ảnh dưới dạng BLOB
- giảm bộ nhớ
- tiêu thụ bộ nhớ
- bản trình chiếu lớn
- tệp tạm
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong JavaScript với Aspose.Slides cho Node.js để tối ưu hóa các thao tác với tệp PowerPoint và OpenDocument, giúp xử lý bản trình chiếu hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bản trình chiếu để giúp giảm tiêu dùng bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp bản trình chiếu lớn.

Bài viết này trình bày cách sử dụng xử lý dựa trên BLOB để thêm phương tiện lớn vào bản trình chiếu, xuất phương tiện lớn từ bản trình chiếu và tải các bản trình chiếu lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bản trình chiếu, tài liệu hoặc phương tiện) được lưu ở định dạng nhị phân.

Aspose.Slides for Node.js via Java cho phép bạn sử dụng BLOB cho các đối tượng sao cho giảm tiêu thụ bộ nhớ khi làm việc với các tệp lớn.

{{% alert title="Info" color="info" %}}
Để tránh một số hạn chế khi tương tác với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Việc tải một bản trình chiếu lớn thông qua luồng của nó sẽ dẫn đến việc sao chép nội dung bản trình chiếu và gây tải chậm. Do đó, khi bạn muốn tải một bản trình chiếu lớn, chúng tôi mạnh mẽ khuyên bạn nên sử dụng đường dẫn tệp bản trình chiếu chứ không phải luồng của nó.
{{% /alert %}}

## **Sử dụng BLOB để Giảm Tiêu Thụ Bộ Nhớ**

### **Thêm Tệp Lớn qua BLOB vào Bản Trình Chiếu**

[Aspose.Slides](/slides/vi/nodejs-java/) for Node.js via Java cho phép bạn thêm các tệp lớn (trong trường hợp này là một tệp video lớn) thông qua một quy trình liên quan đến BLOB để giảm tiêu thụ bộ nhớ.

Đoạn JavaScript này cho bạn thấy cách thêm một tệp video lớn qua quy trình BLOB vào bản trình chiếu:
```javascript
var pathToVeryLargeVideo = "veryLargeVideo.avi";
// Tạo một bản trình chiếu mới mà video sẽ được thêm vào
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToVeryLargeVideo);
    try {
        // Hãy thêm video vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // không có ý định truy cập tệp "veryLargeVideo.avi".
        var video = pres.getVideos().addVideo(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);
        // Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất ra, mức tiêu thụ bộ nhớ
        // vẫn thấp suốt vòng đời của đối tượng pres
        pres.save("presentationWithLargeVideo.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Xuất Tệp Lớn qua BLOB từ Bản Trình Chiếu**

Aspose.Slides for Node.js via Java cho phép bạn xuất các tệp lớn (trong trường hợp này là tệp âm thanh hoặc video) qua một quy trình liên quan đến BLOB từ các bản trình chiếu. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bản trình chiếu nhưng không muốn tệp này được tải vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn có thể giữ mức tiêu thụ bộ nhớ thấp.

Đoạn mã này trong JavaScript minh họa thao tác đã mô tả:
```javascript
var hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";
var loadOptions = new aspose.slides.LoadOptions();
// Khóa tệp nguồn và KHÔNG tải nó vào bộ nhớ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
// Tạo thực thể Presentation, khóa tệp "hugePresentationWithAudiosAndVideos.pptx".
var pres = new aspose.slides.Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc tiêu thụ bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
    // để chuyển dữ liệu từ luồng video của bản trình chiếu sang một luồng cho tệp video mới được tạo.
    var buffer = new byte[8 * 1024];
    // Duyệt qua các video
    for (var index = 0; index < pres.getVideos().size(); index++) {
        var video = pres.getVideos().get_Item(index);
        // Mở luồng video của bản trình chiếu. Lưu ý, chúng tôi cố ý tránh truy cập vào các thuộc tính
        // như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, sau đó
        // gây ra việc tải byte vào bộ nhớ. Chúng tôi sử dụng video.GetStream, sẽ trả về Stream - và KHÔNG
        // yêu cầu chúng tôi tải toàn bộ video vào bộ nhớ.
        var presVideoStream = video.getStream();
        try {
            var outputFileStream = java.newInstanceSync("java.io.FileOutputStream", ("video" + index) + ".avi");
            try {
                var bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Tiêu thụ bộ nhớ sẽ vẫn thấp bất kể kích thước của video hay bản trình chiếu.
    }
    // Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh.
} catch (e) {console.log(e);
} finally {
    pres.dispose();
}
```

### **Thêm Hình Ảnh dưới dạng BLOB trong Bản Trình Chiếu**

Với các phương thức từ lớp [**ImageCollection**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection) và lớp [**ImageCollection** ](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ImageCollection), bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.

Đoạn JavaScript này cho bạn thấy cách thêm một hình ảnh lớn qua quy trình BLOB:
```javascript
var pathToLargeImage = "large_image.jpg";
// tạo một bản trình chiếu mới mà hình ảnh sẽ được thêm vào.
var pres = new aspose.slides.Presentation();
try {
    var fileStream = java.newInstanceSync("java.io.FileInputStream", pathToLargeImage);
    try {
        // Hãy thêm hình ảnh vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // KHÔNG có ý định truy cập tệp "largeImage.png" file.
        var img = pres.getImages().addImage(fileStream, aspose.slides.LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 0, 0, 300, 200, img);
        // Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất ra, mức tiêu thụ bộ nhớ
        // vẫn thấp suốt vòng đời của đối tượng pres
        pres.save("presentationWithLargeImage.pptx", aspose.slides.SaveFormat.Pptx);
    } finally {
        if (fileStream != null) {
            fileStream.close();
        }
    }
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Bộ nhớ và Bản trình chiếu lớn**

Thông thường, để tải một bản trình chiếu lớn, máy tính cần rất nhiều bộ nhớ tạm. Toàn bộ nội dung của bản trình chiếu được tải vào bộ nhớ và tệp (từ đó bản trình chiếu được tải) không còn được sử dụng.

Xét một bản PowerPoint lớn (large.pptx) chứa một tệp video 1.5 GB. Phương pháp tiêu chuẩn để tải bản trình chiếu được mô tả trong đoạn JavaScript này:
```javascript
var pres = new aspose.slides.Presentation("large.pptx");
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

Nhưng phương pháp này tiêu tốn khoảng 1.6 GB bộ nhớ tạm.

### **Tải Bản Trình Chiếu Lớn dưới dạng BLOB**

Thông qua quy trình liên quan đến BLOB, bạn có thể tải một bản trình chiếu lớn trong khi sử dụng ít bộ nhớ. Đoạn JavaScript này mô tả cách thực hiện khi quy trình BLOB được dùng để tải một tệp bản trình chiếu lớn (large.pptx):
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
var pres = new aspose.slides.Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", aspose.slides.SaveFormat.Pdf);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Thay Đổi Thư Mục cho Tệp Tạm**

Khi quy trình BLOB được sử dụng, máy tính của bạn tạo các tệp tạm trong thư mục mặc định cho tệp tạm. Nếu bạn muốn các tệp tạm được lưu ở một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `setTempFilesRootPath`:
```javascript
var loadOptions = new aspose.slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(aspose.slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `setTempFilesRootPath`, Aspose.Slides sẽ không tự động tạo thư mục để lưu trữ tệp tạm. Bạn phải tạo thư mục này thủ công.
{{% /alert %}}

### **Giải Phóng Đối Tượng Presentation để Giải Phóng Bộ Nhớ**

Khi xử lý các bản trình chiếu lớn, hãy đảm bảo rằng đối tượng [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ mà nó chiếm được giải phóng. Gọi `dispose()` sau khi bạn đã hoàn tất việc sử dụng bản trình chiếu để giải phóng các tài nguyên không được quản lý.
```js
let presentation = new aspose.slides.Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", aspose.slides.SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong bản trình chiếu Aspose.Slides được coi là BLOB và được kiểm soát bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được coi là BLOB. Toàn bộ tệp bản trình chiếu cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Những đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.

**Tôi cấu hình các quy tắc xử lý BLOB trong quá trình tải bản trình chiếu ở đâu?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/) cùng với [BlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/blobmanagementoptions/). Tại đó bạn thiết lập giới hạn bộ nhớ trong cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm và chọn hành vi khóa nguồn.

**Cài đặt BLOB có ảnh hưởng tới hiệu năng không, và tôi cân bằng tốc độ với bộ nhớ như thế nào?**

Có. Giữ BLOB trong bộ nhớ giúp tối đa tốc độ nhưng tăng tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tốn thêm I/O. Sử dụng phương thức [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/blobmanagementoptions/setmaxblobsbytesinmemory/) để đạt được cân bằng phù hợp cho khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có giúp khi mở các bản trình chiếu cực lớn (ví dụ, hàng gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/blobmanagementoptions/) được thiết kế cho các trường hợp như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM đỉnh và ổn định quá trình xử lý cho các bộ slide rất lớn.

**Tôi có thể sử dụng các chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**

Có. Các quy tắc tương tự áp dụng cho luồng: thể hiện Presentation có thể sở hữu và khóa luồng đầu vào (tùy thuộc vào chế độ khóa đã chọn), và tệp tạm sẽ được sử dụng khi được cho phép, giúp việc tiêu thụ bộ nhớ dự đoán được trong quá trình xử lý.