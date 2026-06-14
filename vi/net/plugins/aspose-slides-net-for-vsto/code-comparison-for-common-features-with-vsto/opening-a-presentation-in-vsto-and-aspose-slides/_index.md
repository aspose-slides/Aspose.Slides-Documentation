---
title: Mở một Bản trình bày trong VSTO và Aspose.Slides
type: docs
weight: 120
url: /vi/net/opening-a-presentation-in-vsto-and-aspose-slides/
---
## **VSTO**
Dưới đây là đoạn mã mẫu để mở bản trình bày:

``` csharp

  string FileName = "Open Presentation.pptx";

 Application.Presentations.Open(FileName);


``` 
## **Aspose.Slides**
Aspose.Slides cho .NET cung cấp lớp **Presentation** được sử dụng để mở một bản trình bày hiện có. Nó cung cấp một số hàm khởi tạo nạp chồng và chúng ta có thể sử dụng một trong các hàm khởi tạo phù hợp của lớp **Presentation** để tạo đối tượng dựa trên một bản trình bày hiện có. Trong ví dụ dưới đây, chúng tôi đã truyền tên tệp bản trình bày (cần mở) vào hàm khởi tạo của lớp Presentation. Sau khi tệp được mở, chúng tôi lấy tổng số slide có trong bản trình bày để in ra màn hình.

``` csharp

  string FileName = "Open Presentation.pptx";

 Presentation MyPresentation = new Presentation(FileName);

``` 
## **Download Running Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/releases/tag/AsposeSlidesVsVSTOv1.1)
## **Download Sample Code**
- [Github](https://github.com/aspose-slides/Aspose.Slides-for-.NET/tree/master/Plugins/Aspose.Slides%20Vs%20VSTO%20Presentations/Code%20Comparison%20of%20Common%20Features/Opening%20a%20Presentation)