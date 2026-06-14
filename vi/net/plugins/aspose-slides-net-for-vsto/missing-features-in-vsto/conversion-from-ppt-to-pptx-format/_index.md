---
title: Chuyển đổi định dạng từ PPT sang PPTX
type: docs
weight: 20
url: /vi/net/conversion-from-ppt-to-pptx-format/
---
Tính năng độc đáo của Aspose.Slides cung cấp tính linh hoạt trong việc chuyển đổi phiên bản mà không ảnh hưởng tới công việc.
SaveFormat là một enumeration cho phép chuyển đổi tài liệu sang các định dạng được liệt kê dưới đây trong bảng.

|**Tên Thành viên**|**Giá trị**|**Mô tả**|
| :- | :- | :- |
|HTML|13||
|ODP|6||
|PDF|1||
|PDF Notes|12||
|POTM|11||
|POTX|10||
|PPS|0||
|PPSM|9||
|PPSX|4||
|PPT|0||
|PPTM|7||
|PPTX|3||
|TIFF|5||
|TiffNotes|14||
|XPS|2||
Dưới đây là đoạn mã mẫu cho thấy cách chuyển đổi từ PPT sang PPTX; bạn cũng có thể thực hiện ngược lại.

``` csharp

 string FilePath = @"..\..\..\Sample Files\";

string srcFileName = FilePath + "Conversion PPT to PPTX.ppt";

string destFileName = FilePath + "Conversion PPT to PPTX.pptx";

//Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX

Presentation pres = new Presentation(srcFileName);

//Lưu bản trình chiếu PPTX sang định dạng PPTX

pres.Save(destFileName, SaveFormat.Pptx);

``` 
## **Tải mã mẫu**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/MissingFeaturesAsposeSlidesForOpenXMLv1.1)
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-vsto/downloads/Conversion%20between%20different%20presentation%20version%20%28Aspose.Slides%29.zip)