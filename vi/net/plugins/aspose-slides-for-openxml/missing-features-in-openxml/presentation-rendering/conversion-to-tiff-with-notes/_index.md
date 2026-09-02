---
title: Chuyển đổi sang Tiff với Ghi chú
type: docs
weight: 10
url: /vi/net/conversion-to-tiff-with-notes/
---
TIFF là một trong số các định dạng hình ảnh được sử dụng rộng rãi mà Aspose.Slides cho .NET hỗ trợ để chuyển đổi một bài thuyết trình có ghi chú thành hình ảnh. Bạn cũng có thể tạo các hình thu nhỏ của slide trong chế độ xem Notes Slide. Dưới đây là hai đoạn mã mẫu cho thấy cách tạo hình ảnh TIFF của một bài thuyết trình trong chế độ xem Notes Slide.

Phương thức **Save** được cung cấp bởi lớp **Presentation** có thể được sử dụng để chuyển đổi toàn bộ bài thuyết trình trong chế độ xem Notes Slide sang TIFF. Bạn cũng có thể tạo hình thu nhỏ của slide trong chế độ xem Notes Slide cho các slide riêng lẻ.

``` csharp
using Aspose.Slides;
using Aspose.Slides.Export;

string FilePath = @"..\..\..\Sample Files\";
string srcFileName = FilePath + "Tiff conversion with note.pptx";
string destFileName = FilePath + "Tiff conversion with note.tiff";

//    Khởi tạo một đối tượng Presentation đại diện cho tệp bài thuyết trình
using (Presentation pres = new Presentation(srcFileName))
{
    //    Đặt ghi chú người nói dưới mỗi slide đã được render
    TiffOptions tiffOptions = new TiffOptions();
    tiffOptions.SlidesLayoutOptions = new NotesCommentsLayoutingOptions
    {
        NotesPosition = NotesPositions.BottomFull
    };

    //    Lưu bài thuyết trình thành TIFF với ghi chú
    pres.Save(destFileName, SaveFormat.Tiff, tiffOptions);
}
``` 
## **Tải Mã Mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Tiff%20conversion%20with%20note%20%28Aspose.Slides%29.zip)