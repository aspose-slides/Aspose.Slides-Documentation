---
title: Quản lý BLOB trong bản trình chiếu trên Android để sử dụng bộ nhớ hiệu quả
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/androidjava/manage-blob/
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
- tệp tạm thời
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho Android qua Java để tối ưu hoá các thao tác tệp PowerPoint và OpenDocument cho việc xử lý bản trình chiếu hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bản trình chiếu để giúp giảm tiêu thụ bộ nhớ khi làm việc với hình ảnh, âm thanh, video và tệp trình chiếu có kích thước lớn.

Bài viết này mô tả cách sử dụng xử lý dựa trên BLOB để thêm phương tiện lớn vào bản trình chiếu, xuất phương tiện lớn từ bản trình chiếu và tải bản trình chiếu lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng tệp tạm thời trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

{{% alert title="Info" color="info" %}}
Để vượt qua một số hạn chế khi tương tác với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bản trình chiếu lớn thông qua luồng sẽ dẫn đến việc sao chép nội dung bản trình chiếu và gây chậm tải. Do đó, khi bạn muốn tải một bản trình chiếu lớn, chúng tôi khuyên bạn nên sử dụng đường dẫn tệp bản trình chiếu chứ không phải luồng của nó.
{{% /alert %}}

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bản trình chiếu, tài liệu hoặc phương tiện) được lưu ở định dạng nhị phân.

Aspose.Slides for Android via Java cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi làm việc với các tệp kích thước lớn.

{{% alert title="Info" color="info" %}}
Để vượt qua một số hạn chế khi tương tác với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bản trình chiếu lớn thông qua luồng sẽ dẫn đến việc sao chép nội dung bản trình chiếu và gây chậm tải. Do đó, khi bạn muốn tải một bản trình chiếu lớn, chúng tôi khuyên bạn nên sử dụng đường dẫn tệp bản trình chiếu chứ không phải luồng của nó.
{{% /alert %}}

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bản trình chiếu**

[Aspose.Slides](/slides/vi/androidjava/) for Java cho phép bạn thêm tệp lớn (trong trường hợp này là một tệp video lớn) thông qua quá trình sử dụng BLOB để giảm tiêu thụ bộ nhớ.

Mã Java dưới đây cho bạn thấy cách thêm một tệp video lớn qua quá trình BLOB vào bản trình chiếu:

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tạo một bản trình chiếu mới để thêm video vào
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Hãy thêm video vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // không có ý định truy cập tệp "veryLargeVideo.avi".
        IVideo video = pres.getVideos().addVideo(fileStream, LoadingStreamBehavior.KeepLocked);
        pres.getSlides().get_Item(0).getShapes().addVideoFrame(0, 0, 480, 270, video);

        // Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất ra, việc tiêu thụ bộ nhớ
        // vẫn ở mức thấp trong suốt vòng đời của đối tượng pres 
        pres.save("presentationWithLargeVideo.pptx", SaveFormat.Pptx);
    } finally {
        if (fileStream != null) fileStream.close();
    }
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

### **Xuất tệp lớn qua BLOB từ bản trình chiếu**

Aspose.Slides for Android via Java cho phép bạn xuất tệp lớn (ví dụ: tệp âm thanh hoặc video) thông qua quá trình sử dụng BLOB từ bản trình chiếu. Ví dụ, bạn có thể cần trích xuất một tệp phương tiện lớn từ bản trình chiếu nhưng không muốn tệp này được tải vào bộ nhớ máy tính. Bằng cách xuất tệp qua quá trình BLOB, bạn giữ cho việc tiêu thụ bộ nhớ ở mức thấp.

Mã Java dưới đây minh họa thao tác đã mô tả:

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Khóa tệp nguồn và KHÔNG tải nó vào bộ nhớ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// tạo một thể hiện Presentation, khóa tệp "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
    // để chuyển dữ liệu từ luồng video của bản trình chiếu sang một luồng cho tệp video mới tạo.
    byte[] buffer = new byte[8 * 1024];

    // Duyệt qua các video
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Mở luồng video của bản trình chiếu. Lưu ý, chúng tôi cố ý tránh truy cập các thuộc tính
        // như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, dẫn đến
        // việc các byte được tải vào bộ nhớ. Chúng tôi sử dụng video.GetStream, nó sẽ trả về Stream - và KHÔNG
        //  yêu cầu chúng tôi tải toàn bộ video vào bộ nhớ.
        InputStream presVideoStream = video.getStream();
        try {
            OutputStream outputFileStream = new FileOutputStream("video" + index + ".avi");
            try {
                int bytesRead;
                while ((bytesRead = presVideoStream.read(buffer, 0, buffer.length)) > 0) {
                    outputFileStream.write(buffer, 0, bytesRead);
                }
            } finally {
                outputFileStream.close();
            }
        } finally {
            presVideoStream.close();
        }
        // Việc tiêu thụ bộ nhớ sẽ vẫn thấp bất kể kích thước của video hay bản trình chiếu.
    }
    // Nếu cần, bạn có thể áp dụng các bước tương tự cho tệp âm thanh. 
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Thêm hình ảnh dưới dạng BLOB trong bản trình chiếu**

Với các phương thức từ giao diện [**IImageCollection**](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IImageCollection) và lớp [**ImageCollection** ](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ImageCollection), bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.

Mã Java dưới đây cho bạn thấy cách thêm một hình ảnh lớn qua quá trình BLOB:

```java
String pathToLargeImage = "large_image.jpg";

// tạo một bản trình chiếu mới để thêm hình ảnh vào.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Hãy thêm hình ảnh vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
		// KHÔNG có ý định truy cập tệp "largeImage.png".
		IPPImage img = pres.getImages().addImage(fileStream, LoadingStreamBehavior.KeepLocked);
		pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 0, 0, 300, 200, img);

		// Lưu bản trình chiếu. Khi một bản trình chiếu lớn được xuất ra, việc tiêu thụ bộ nhớ
		// vẫn ở mức thấp trong suốt vòng đời của đối tượng pres
		pres.save("presentationWithLargeImage.pptx", SaveFormat.Pptx);
	} finally {
		if (fileStream != null) fileStream.close();
	}
} catch(IOException e) {
} finally {
	if (pres != null) pres.dispose();
}
```

## **Bộ nhớ và bản trình chiếu lớn**

Thông thường, để tải một bản trình chiếu lớn, máy tính cần rất nhiều bộ nhớ tạm thời. Toàn bộ nội dung của bản trình chiếu được tải vào bộ nhớ và tệp (từ đó bản trình chiếu được tải) ngừng được sử dụng.

Xem xét một bản trình chiếu PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp chuẩn để tải bản trình chiếu được mô tả trong đoạn mã Java sau:

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Nhưng phương pháp này tiêu tốn khoảng 1,6 GB bộ nhớ tạm.

### **Tải một bản trình chiếu lớn dưới dạng BLOB**

Thông qua quá trình sử dụng BLOB, bạn có thể tải một bản trình chiếu lớn trong khi sử dụng ít bộ nhớ. Đoạn mã Java dưới đây mô tả cách thực hiện nơi quá trình BLOB được dùng để tải tệp bản trình chiếu lớn (large.pptx):

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);

Presentation pres = new Presentation("large.pptx", loadOptions);
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Thay đổi thư mục cho tệp tạm thời**

Khi sử dụng quá trình BLOB, máy tính của bạn sẽ tạo các tệp tạm thời trong thư mục mặc định cho tệp tạm thời. Nếu bạn muốn các tệp tạm thời được lưu trong một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `TempFilesRootPath`:

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `TempFilesRootPath`, Aspose.Slides sẽ không tự động tạo thư mục để lưu tệp tạm thời. Bạn phải tự tạo thư mục này.
{{% /alert %}}

### **Giải phóng đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bản trình chiếu lớn, hãy đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ đã chiếm được giải phóng. Gọi `dispose()` sau khi bạn hoàn tất việc sử dụng bản trình chiếu để giải phóng các tài nguyên không được quản lý.

```java
Presentation presentation = new Presentation("large.pptx");

// ...xử lý bản trình chiếu...
presentation.save("large.pdf", SaveFormat.Pdf);

// Giải phóng tài nguyên một cách rõ ràng.
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong bản trình chiếu Aspose.Slides được coi là BLOB và được kiểm soát bởi các tùy chọn BLOB?**

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được xử lý như BLOB. Toàn bộ tệp bản trình chiếu cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Các đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.

**Tôi cấu hình quy tắc xử lý BLOB ở đâu khi tải bản trình chiếu?**

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/loadoptions/) cùng với [BlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/blobmanagementoptions/). Ở đó bạn đặt giới hạn bộ nhớ trong cho BLOB, cho phép hoặc không cho phép tệp tạm, chọn đường dẫn gốc cho tệp tạm và xác định hành vi khóa nguồn.

**Cài đặt BLOB có ảnh hưởng đến hiệu năng không, và làm sao cân bằng tốc độ với bộ nhớ?**

Có. Giữ BLOB trong bộ nhớ tối đa tốc độ nhưng tăng tiêu thụ RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tăng I/O. Sử dụng phương thức [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) để đạt được cân bằng phù hợp cho khối lượng công việc và môi trường của bạn.

**Các tùy chọn BLOB có hữu ích khi mở các bản trình chiếu cực kỳ lớn (ví dụ: hàng gigabyte) không?**

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM đỉnh và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.

**Tôi có thể sử dụng chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**

Có. Các quy tắc tương tự áp dụng cho luồng: thể hiện bản trình chiếu có thể sở hữu và khóa luồng đầu vào (tùy thuộc vào chế độ khóa được chọn), và tệp tạm sẽ được sử dụng khi được cho phép, giúp việc sử dụng bộ nhớ trở nên dự đoán được trong quá trình xử lý.