---
title: Chuyển đổi định dạng PPT sang PPTX trong Aspose.Slides
type: docs
weight: 10
url: /vi/net/conversion-from-ppt-to-pptx-format-in-aspose-slides/
---
**Aspose.Slides** cho .NET hiện cho phép các nhà phát triển truy cập PPT bằng thể hiện của lớp Presentation và chuyển đổi nó sang định dạng PPTX tương ứng. Hiện tại, nó hỗ trợ chuyển đổi một phần PPT sang PPTX. Để biết chi tiết về các tính năng được hỗ trợ và không được hỗ trợ trong việc chuyển đổi PPT sang PPTX, vui lòng truy cập liên kết tài liệu này.

**Aspose.Slides** cho .NET cung cấp lớp Presentation đại diện cho tệp tin trình chiếu PPTX. Lớp Presentation hiện cũng có thể truy cập PPT thông qua Presentation khi đối tượng được khởi tạo.

``` csharp

 //Khởi tạo một đối tượng Presentation đại diện cho tệp PPTX

PresentationEx pres = new PresentationEx("Conversion.ppt");

//Lưu bản trình chiếu PPTX sang định dạng PPTX

pres.Save(MyDir +"Converted.pptx", SaveFormat.Pptx);

``` 
## **Tải Mã Mẫu**
- [Bitbucket](https://bitbucket.org/asposemarketplace/aspose-for-openxml/downloads/Conversion%20PPT%20to%20PPTX%20%28Aspose.Slides%29.zip)