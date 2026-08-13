---
title: Tạo biểu đồ bằng VSTO và Aspose.Slides cho Java
linktitle: Tạo biểu đồ
type: docs
weight: 70
url: /vi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/
keywords:
- tạo biểu đồ
- di chuyển
- VSTO
- tự động hoá Office
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Tìm hiểu cách tự động hoá việc tạo biểu đồ PowerPoint trong Java. Hướng dẫn từng bước này cho thấy tại sao Aspose.Slides cho Java là một giải pháp nhanh hơn, mạnh mẽ hơn so với Microsoft.Office.Interop."
---
{{% alert color="info" %}} 

Biểu đồ là biểu diễn trực quan của dữ liệu, được sử dụng rộng rãi trong các bài thuyết trình. Bài viết này trình bày mã để tạo biểu đồ trong Microsoft PowerPoint một cách lập trình bằng cách sử dụng [VSTO](/slides/vi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/) và [Aspose.Slides for Java](/slides/vi/java/create-a-chart-in-a-microsoft-powerpoint-presentation/).

{{% /alert %}} 
## **Tạo biểu đồ**
Các ví dụ mã dưới đây mô tả quy trình thêm một biểu đồ cột nhóm 3D đơn giản bằng VSTO. Bạn tạo một đối tượng trình chiếu, thêm một biểu đồ mặc định vào đó. Sau đó sử dụng sổ làm việc Microsoft Excel để truy cập và chỉnh sửa dữ liệu biểu đồ cùng với việc đặt các thuộc tính biểu đồ. Cuối cùng, lưu trình chiếu.
### **Ví dụ VSTO**
Using VSTO, the following steps are performed:

1. Tạo một thể hiện của trình chiếu Microsoft PowerPoint.
1. Thêm một slide trống vào trình chiếu.
1. Thêm một biểu đồ **3D clustered column** và truy cập vào nó.
1. Tạo một thể hiện mới của Microsoft Excel Workbook và tải dữ liệu biểu đồ.
1. Truy cập worksheet dữ liệu biểu đồ bằng cách sử dụng Microsoft Excel Workbook instancefromworkbook.
1. Đặt phạm vi biểu đồ trong worksheet và xóa series 2 và 3 khỏi biểu đồ.
1. Sửa đổi dữ liệu danh mục của biểu đồ trong worksheet dữ liệu biểu đồ.
1. Sửa đổi dữ liệu series 1 của biểu đồ trong worksheet dữ liệu biểu đồ.
1. Bây giờ, truy cập tiêu đề biểu đồ và setthefontrelatedproperties.
1. Truy cập trục giá trị của biểu đồ và đặt giá trị đơn vị chính, đơn vị phụ, giá trị max và min.
1. Truy cập độ sâu biểu đồ hoặc trục series và loại bỏ nó vì trong ví dụ này, onlyoneserieisused.
1. Bây giờ, đặt góc quay của biểu đồ theo hướng X và Y.
1. Lưu trình chiếu.
1. Đóng các thể hiện của Microsoft Excel và PowerPoint.

**Bản trình chiếu đầu ra, được tạo bằng VSTO** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_1.png)



{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-VSTOChart.cs" >}}

{{< gist "aspose-com-gists" "a56eda38c01ad33dc653116c7bae4293" "Examples-CSharp-VSTO-VSTOChart-EnsurePowerPointIsRunning.cs" >}}
### **Ví dụ Aspose.Slides for Java**
Using Aspose.Slides for Java, the following steps are performed:

1. Tạo một thể hiện của trình chiếu Microsoft PowerPoint.
1. Thêm một slide trống vào trình chiếu.
1. Thêm một biểu đồ **3D clustered column** và truy cập vào nó.
1. Truy cập worksheet dữ liệu biểu đồ bằng cách sử dụng Microsoft Excel Workbook instancefromworkbook.
1. Xóa series 2 và 3 không sử dụng.
1. Truy cập các danh mục của biểu đồ và sửa đổi nhãn.
1. Accesseries1 và sửa đổi các giá trị series.
1. Bây giờ, truy cập tiêu đề biểu đồ và đặt các thuộc tính phông chữ.
1. Truy cập trục giá trị của biểu đồ và đặt giá trị đơn vị chính, đơn vị phụ, giá trị max và min.
1. Bây giờ, đặt góc quay của biểu đồ theo hướng X và Y.
1. Lưu trình chiếu ở định dạng PPTX.

**Bản trình chiếu đầu ra, được tạo bằng Aspose.Slides** 

![todo:image_alt_text](create-a-chart-in-a-microsoft-powerpoint-presentation_2.png)

{{< gist "aspose-com-gists" "1f55f0222bc39a382d831900e8de7400" "Examples-src-main-java-com-aspose-slides-examples-Slides-Charts-CreateChart-CreateChart.java" >}}

## **Câu hỏi thường gặp**

### Can I create other types of charts like pie, line, or bar charts with Aspose.Slides?
Có. Aspose.Slides hỗ trợ một loạt rộng các [chart types](/slides/vi/java/create-chart/), bao gồm biểu đồ tròn, biểu đồ đường, biểu đồ cột, biểu đồ phân tán, biểu đồ bong bóng và nhiều hơn nữa. Bạn có thể chỉ định loại biểu đồ mong muốn bằng cách sử dụng lớp [ChartType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/charttype/) khi thêm biểu đồ.

### Can I apply custom styles or themes to the chart?
Có. Bạn có thể tùy chỉnh hoàn toàn giao diện của biểu đồ, bao gồm màu sắc, phông chữ, màu nền, viền, lưới và bố cục. Tuy nhiên, áp dụng các theme của Office chính xác như trong PowerPoint yêu cầu thiết lập thủ công từng kiểu riêng lẻ.

### Can I export the chart as an image separately from the slide?
Có, Aspose.Slides cho phép bạn xuất bất kỳ shape nào — bao gồm cả biểu đồ — dưới dạng hình ảnh riêng (ví dụ: PNG, JPEG) bằng cách sử dụng phương thức `getImage` trên [shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/).