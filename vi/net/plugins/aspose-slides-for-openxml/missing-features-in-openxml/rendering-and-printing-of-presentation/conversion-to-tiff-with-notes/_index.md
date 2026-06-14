---
title: Chuyển đổi sang Tiff có ghi chú
type: docs
weight: 10
url: /vi/net/conversion-to-tiff-with-notes/
---
TIFF là một trong số các định dạng hình ảnh được sử dụng rộng rãi mà Aspose.Slides for .NET hỗ trợ để chuyển đổi một bản trình chiếu có ghi chú sang hình ảnh. Bạn cũng có thể tạo hình thu nhỏ slide trong chế độ xem Notes Slide. Dưới đây là hai đoạn mã mẫu thể hiện cách tạo ảnh TIFF của bản trình chiếu trong chế độ xem Notes Slide.

Phương thức **Save** được cung cấp bởi lớp **Presentation** có thể được dùng để chuyển đổi toàn bộ bản trình chiếu trong chế độ xem Notes Slide sang TIFF. Bạn cũng có thể tạo hình thu nhỏ slide trong chế độ xem Notes Slide cho các slide riêng lẻ.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Tiff conversion with note.pptx";

string destFileName = FilePath + "Tiff conversion with note.tiff";

//Khởi tạo một đối tượng Presentation đại diện cho tệp bản trình chiếu

Presentation pres = new Presentation(srcFileName);

//Lưu bản trình chiếu dưới dạng ghi chú TIFF

pres.Save(destFileName, SaveFormat.TiffNotes);

``` 
## **Tải xuống mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)