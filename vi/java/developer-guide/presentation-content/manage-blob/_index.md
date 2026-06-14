---
title: Quản lý BLOB trong bản trình bày bằng Java để sử dụng bộ nhớ hiệu quả
linktitle: Quản lý BLOB
type: docs
weight: 10
url: /vi/java/manage-blob/
keywords:
- đối tượng lớn
- mục lớn
- tệp lớn
- thêm BLOB
- xuất BLOB
- thêm hình ảnh dưới dạng BLOB
- giảm bộ nhớ
- tiêu thụ bộ nhớ
- bản trình bày lớn
- tệp tạm thời
- PowerPoint
- OpenDocument
- bản trình bày
- Java
- Aspose.Slides
description: "Quản lý dữ liệu BLOB trong Aspose.Slides cho Java để tối ưu hoá việc thao tác các tệp PowerPoint và OpenDocument, giúp xử lý bản trình bày hiệu quả."
---
## **Tổng quan**

Aspose.Slides cung cấp việc xử lý dựa trên BLOB cho dữ liệu nhị phân lớn trong các bản trình bày nhằm giúp giảm tiêu thụ bộ nhớ khi làm việc với các hình ảnh, âm thanh, video và tệp trình chiếu kích thước lớn.

Bài viết này chỉ ra cách sử dụng xử lý dựa trên BLOB để thêm media lớn vào bản trình bày, xuất media lớn ra khỏi bản trình bày, và tải các bản trình bày lớn một cách hiệu quả hơn. Nó cũng giải thích cách sử dụng các tệp tạm thời trong quá trình xử lý và cách thay đổi thư mục lưu trữ chúng.

## **Về BLOB**

**BLOB** (**Binary Large Object**) thường là một mục lớn (hình ảnh, bản trình bày, tài liệu hoặc phương tiện) được lưu ở định dạng nhị phân.  

Aspose.Slides for Java cho phép bạn sử dụng BLOB cho các đối tượng theo cách giảm tiêu thụ bộ nhớ khi có các tệp lớn liên quan.  

{{% alert title="Info" color="info" %}}
Để tránh một số hạn chế khi tương tác với luồng, Aspose.Slides có thể sao chép nội dung của luồng. Tải một bản trình bày lớn thông qua luồng sẽ dẫn đến việc sao chép nội dung bản trình bày và gây chậm tải. Do đó, khi bạn muốn tải một bản trình bày lớn, chúng tôi khuyến nghị mạnh mẽ bạn sử dụng đường dẫn tệp bản trình bày thay vì luồng của nó.  
{{% /alert %}}

## **Sử dụng BLOB để giảm tiêu thụ bộ nhớ**

### **Thêm tệp lớn qua BLOB vào bản trình bày**

[Aspose.Slides](/slides/vi/java/) for Java cho phép bạn thêm các tệp lớn (trong trường hợp này là một tệp video lớn) thông qua quy trình sử dụng BLOB để giảm tiêu thụ bộ nhớ.  

Mẫu Java này cho thấy cách thêm một tệp video lớn qua quy trình BLOB vào bản trình bày:  

```java
String pathToVeryLargeVideo = "veryLargeVideo.avi";

// Tạo một bản trình chiếu mới mà video sẽ được thêm vào
Presentation pres = new Presentation();
try {
    FileInputStream fileStream = new FileInputStream(pathToVeryLargeVideo);
    try {
        // Hãy thêm video vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
        // không dự định truy cập tệp "veryLargeVideo.avi".
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

### **Xuất tệp lớn qua BLOB từ bản trình bày**

Aspose.Slides for Java cho phép bạn xuất các tệp lớn (trong trường hợp này là một tệp âm thanh hoặc video) qua quy trình sử dụng BLOB từ các bản trình bày. Ví dụ, bạn có thể cần trích xuất một tệp media lớn từ bản trình bày nhưng không muốn tệp đó được tải vào bộ nhớ máy tính của bạn. Bằng cách xuất tệp qua quy trình BLOB, bạn giữ được mức tiêu thụ bộ nhớ thấp.  

Đoạn mã Java dưới đây minh họa thao tác đã mô tả:  

```java
String hugePresentationWithAudiosAndVideosFile = "LargeVideoFileTest.pptx";

LoadOptions loadOptions = new LoadOptions();
// Khoá tệp nguồn và KHÔNG tải vào bộ nhớ
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);

// tạo một thể hiện Presentation, khoá tệp "hugePresentationWithAudiosAndVideos.pptx".
Presentation pres = new Presentation(hugePresentationWithAudiosAndVideosFile, loadOptions);
try {
    // Hãy lưu mỗi video vào một tệp. Để ngăn ngừa việc sử dụng bộ nhớ cao, chúng ta cần một bộ đệm sẽ được sử dụng
    // để chuyển dữ liệu từ luồng video của bản trình chiếu sang luồng cho một tệp video mới được tạo.
    byte[] buffer = new byte[8 * 1024];

    // Duyệt qua các video
    for (int index = 0; index < pres.getVideos().size(); index++) {
        IVideo video = pres.getVideos().get_Item(index);

        // Mở luồng video của bản trình chiếu. Vui lòng lưu ý rằng chúng tôi cố ý tránh truy cập các thuộc tính
        // như video.BinaryData - vì thuộc tính này trả về một mảng byte chứa toàn bộ video, sau đó
        // khiến các byte được tải vào bộ nhớ. Chúng tôi sử dụng video.GetStream, nó sẽ trả về Stream - và KHÔNG
        //  yêu cầu chúng ta tải toàn bộ video vào bộ nhớ.
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
        // Tiêu thụ bộ nhớ sẽ vẫn thấp bất kể kích thước của video hay bản trình chiếu.
    }
    // Nếu cần, bạn có thể áp dụng các bước tương tự cho các tệp âm thanh.
} catch (IOException e) {
} finally {
    pres.dispose();
}
```

### **Thêm hình ảnh dưới dạng BLOB vào bản trình bày**

Với các phương thức từ giao diện [**IImageCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IImageCollection) và lớp [**ImageCollection**](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ImageCollection), bạn có thể thêm một hình ảnh lớn dưới dạng luồng để nó được xử lý như một BLOB.  

Đoạn mã Java này cho thấy cách thêm một hình ảnh lớn qua quy trình BLOB:  

```java
String pathToLargeImage = "large_image.jpg";

// tạo một bản trình chiếu mới mà hình ảnh sẽ được thêm vào.
Presentation pres = new Presentation();
try {
	FileInputStream fileStream = new FileInputStream(pathToLargeImage);
	try {
		// Hãy thêm hình ảnh vào bản trình chiếu - chúng tôi chọn hành vi KeepLocked vì chúng tôi
		// KHÔNG dự định truy cập tệp "largeImage.png" file.
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

## **Bộ nhớ và bản trình bày lớn**

Thông thường, để tải một bản trình bày lớn, máy tính cần rất nhiều bộ nhớ tạm thời. Toàn bộ nội dung của bản trình bày được tải vào bộ nhớ và tệp (từ đó bản trình bày được tải) ngừng được sử dụng.  

Xem xét một bản PowerPoint lớn (large.pptx) chứa một tệp video 1,5 GB. Phương pháp tiêu chuẩn để tải bản trình bày được mô tả trong đoạn mã Java này:  

```java
Presentation pres = new Presentation("large.pptx");
try {
    pres.save("large.pdf", SaveFormat.Pdf);
} finally {
    if (pres != null) pres.dispose();
}
```

Nhưng phương pháp này tiêu tốn khoảng 1,6 GB bộ nhớ tạm.  

### **Tải bản trình bày lớn dưới dạng BLOB**

Thông qua quy trình sử dụng BLOB, bạn có thể tải một bản trình bày lớn trong khi sử dụng ít bộ nhớ. Đoạn mã Java dưới đây mô tả cách triển khai khi dùng quy trình BLOB để tải một tệp bản trình bày lớn (large.pptx):  

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

### **Thay đổi thư mục cho các tệp tạm thời**

Khi sử dụng quy trình BLOB, máy tính của bạn sẽ tạo các tệp tạm thời trong thư mục mặc định dành cho tệp tạm. Nếu bạn muốn các tệp tạm thời được lưu trong một thư mục khác, bạn có thể thay đổi cài đặt lưu trữ bằng cách sử dụng `TempFilesRootPath`:  

```java
LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setTempFilesRootPath("temp");
```

{{% alert title="Info" color="info" %}}
Khi bạn sử dụng `TempFilesRootPath`, Aspose.Slides không tự động tạo thư mục để lưu các tệp tạm. Bạn phải tự tạo thư mục đó.  
{{% /alert %}}

### **Giải phóng đối tượng Presentation để giải phóng bộ nhớ**

Khi xử lý các bản trình bày lớn, hãy đảm bảo rằng thể hiện [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) được giải phóng đúng cách để bộ nhớ nó chiếm giữ được giải phóng. Gọi `dispose()` sau khi bạn đã hoàn thành việc sử dụng bản trình bày để giải phóng các tài nguyên không được quản lý.  

```java
Presentation presentation = new Presentation("large.pptx");

// ...process the presentation...
presentation.save("large.pdf", SaveFormat.Pdf);

// Explicitly release resources.
presentation.dispose();
```

## **Câu hỏi thường gặp**

**Dữ liệu nào trong bản trình bày Aspose.Slides được coi là BLOB và được kiểm soát bởi các tùy chọn BLOB?**  

Các đối tượng nhị phân lớn như hình ảnh, âm thanh và video được coi là BLOB. Toàn bộ tệp bản trình bày cũng liên quan đến việc xử lý BLOB khi nó được tải hoặc lưu. Những đối tượng này được quản lý bởi các chính sách BLOB cho phép bạn kiểm soát việc sử dụng bộ nhớ và chuyển sang tệp tạm khi cần.  

**Tôi cấu hình các quy tắc xử lý BLOB trong quá trình tải bản trình bày ở đâu?**  

Sử dụng [LoadOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/) với [BlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/blobmanagementoptions/). Ở đó bạn thiết lập giới hạn bộ nhớ cho BLOB, cho phép hoặc không cho phép tệp tạm, chỉ định đường dẫn gốc cho tệp tạm và lựa chọn hành vi khóa nguồn.  

**Các cài đặt BLOB có ảnh hưởng đến hiệu năng không, và tôi cân bằng tốc độ với bộ nhớ như thế nào?**  

Có. Giữ BLOB trong bộ nhớ tối ưu tốc độ nhưng làm tăng mức RAM; giảm giới hạn bộ nhớ sẽ chuyển nhiều công việc sang tệp tạm, giảm RAM nhưng tăng I/O. Sử dụng phương thức [setMaxBlobsBytesInMemory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/blobmanagementoptions/#setMaxBlobsBytesInMemory-long-) để đạt được cân bằng phù hợp cho tải công việc và môi trường của bạn.  

**Các tùy chọn BLOB có hữu ích khi mở các bản trình bày cực kỳ lớn (ví dụ hàng gigabyte) không?**  

Có. [BlobManagementOptions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/blobmanagementoptions/) được thiết kế cho các kịch bản như vậy: bật tệp tạm và sử dụng khóa nguồn có thể giảm đáng kể mức RAM tối đa và ổn định quá trình xử lý cho các bộ sưu tập rất lớn.  

**Tôi có thể áp dụng chính sách BLOB khi tải từ luồng thay vì tệp trên đĩa không?**  

Có. Các quy tắc giống nhau áp dụng cho luồng: thể hiện bản trình bày có thể sở hữu và khóa luồng đầu vào (tùy theo chế độ khóa được chọn), và các tệp tạm sẽ được sử dụng khi được cho phép, giúp việc sử dụng bộ nhớ trong quá trình xử lý dự đoán được.  