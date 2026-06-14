---
title: Tạo và Nhúng Biểu đồ Excel dưới dạng OLE Objects bằng VSTO và Aspose.Slides cho Java
linktitle: Tạo và Nhúng Biểu đồ Excel dưới dạng OLE Objects
type: docs
weight: 60
url: /vi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/
keywords:
- tạo biểu đồ
- nhúng biểu đồ Excel
- đối tượng OLE
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bản trình bày
- Java
- Aspose.Slides
description: "Di chuyển từ tự động hoá Microsoft Office sang Aspose.Slides cho Java và nhúng biểu đồ Excel dưới dạng OLE objects vào các slide PowerPoint (PPT, PPTX) trong Java."
---
{{% alert color="primary" %}} 

Biểu đồ là cách thể hiện trực quan dữ liệu của bạn và được sử dụng rộng rãi trong các slide thuyết trình. Bài viết này sẽ cho bạn thấy mã để tạo và nhúng một Biểu đồ Excel dưới dạng OLE Object vào Slide PowerPoint một cách lập trình bằng cách sử dụng [VSTO](/slides/vi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/) và [Aspose.Slides for Java](/slides/vi/java/create-and-embed-an-excel-chart-as-an-ole-object-into-a-microsoft-powerpoint-slide/).

{{% /alert %}} 
## **Tạo và Nhúng Biểu đồ Excel**
Hai ví dụ mã dưới đây dài và chi tiết vì nhiệm vụ chúng mô tả khá phức tạp. Bạn tạo một workbook Microsoft Excel, tạo biểu đồ và sau đó tạo bản trình bày Microsoft PowerPoint mà bạn sẽ nhúng biểu đồ vào. Các đối tượng OLE chứa liên kết tới tài liệu gốc nên người dùng nhấp đúp vào tệp đã nhúng sẽ khởi chạy tệp và ứng dụng của nó.
### **Ví dụ VSTO**
Sử dụng VSTO, các bước sau được thực hiện:

1. Tạo một thể hiện của đối tượng Microsoft Excel ApplicationClass.
1. Tạo một workbook mới với một sheet trong đó.
1. Thêm biểu đồ vào sheet.
1. Lưu workbook.
1. Mở workbook Excel chứa worksheet có dữ liệu biểu đồ.
1. Lấy bộ sưu tập ChartObjects cho sheet.
1. Lấy biểu đồ để sao chép.
1. Tạo một bản trình bày Microsoft PowerPoint.
1. Thêm một slide trống vào bản trình bày.
1. Sao chép biểu đồ từ worksheet Excel vào clipboard.
1. Dán biểu đồ vào bản trình bày PowerPoint.
1. Đặt vị trí biểu đồ trên slide.
1. Lưu bản trình bày.



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateAndEmbedExcelChartAsOLEUsingVSTO.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-SetCellValue.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-CreateNewChartInExcel.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-CreateandEmbedExcelChartAsOLEUsingVSTO-UseCopyPaste.cs" >}}
### **Ví dụ Aspose.Slides for Java**
Sử dụng Aspose.Slides for .NET, các bước sau được thực hiện:

1. Tạo một workbook bằng Aspose.Cells for Java.
1. Tạo một biểu đồ Microsoft Excel.
1. Đặt kích thước OLE cho Biểu đồ Excel.
1. Lấy hình ảnh của biểu đồ.
1. Nhúng biểu đồ Excel dưới dạng OLE Object vào bản trình bày PPTX bằng Aspose.Slides for Java.
1. Thay thế hình ảnh đối tượng đã thay đổi bằng hình ảnh thu được ở bước 3 để giải quyết vấn đề thay đổi đối tượng.
1. Ghi bản trình bày đầu ra ra đĩa ở định dạng PPTX.



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-EmbedChartAsOLEObject.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInPresentation.java" >}}



{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-EmbedChartAsOLEObject-AddExcelChartInWorkbook.java" >}}