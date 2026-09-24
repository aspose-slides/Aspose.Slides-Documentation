---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình chiếu bằng Java
linktitle: Bảng dữ liệu
type: docs
url: /vi/java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ, đường viền và ký hiệu chú giải của bảng dữ liệu biểu đồ trong bản trình chiếu PowerPoint bằng cách sử dụng Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, đường viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, kiểm soát từng loại đường viền và hiển thị hoặc ẩn các ký hiệu chú giải. Các ví dụ lưu các biểu đồ đã cấu hình vào các tệp PPTX.

## **Thiết lập thuộc tính phông chữ**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `true` vào [setDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#setDataTable-boolean-). Sử dụng [getChartDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#getChartDataTable--) để truy cập bảng và cấu hình định dạng văn bản của nó.

1. Tải bản trình chiếu bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).
1. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
1. Bật bảng dữ liệu của biểu đồ.
1. Bật văn bản đậm bằng [setFontBold](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setFontBold-byte-) và truyền `20` vào [setFontHeight](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) để có văn bản kích thước 20 điểm.
1. Lưu bản trình chiếu đã chỉnh sửa.

Ví dụ sau yêu cầu tệp `test.pptx` có trong thư mục làm việc với ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), với chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` được lưu chứa biểu đồ với bảng dữ liệu đã bật và các thiết lập phông chữ đã chỉ định được áp dụng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("test.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IChartPortionFormat portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(NullableBool.True);
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tùy chỉnh đường viền bảng dữ liệu**

Bật bảng bằng [IChart.setDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#setDataTable-boolean-) và truy cập nó qua [IChart.getChartDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#getChartDataTable--). Bạn có thể kiểm soát ba loại đường viền một cách độc lập:

- [setBorderHorizontal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) kiểm soát đường viền ô theo chiều ngang.
- [setBorderVertical](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatatable/#setBorderVertical-boolean-) kiểm soát đường viền ô theo chiều dọc.
- [setBorderOutline](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatatable/#setBorderOutline-boolean-) kiểm soát đường viền bên ngoài của bảng.

Truyền `true` vào mỗi phương thức để hiển thị các đường viền hoặc `false` để ẩn chúng. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị các đường viền ngang và đường viền ngoài, và ẩn các đường viền dọc. Nó không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây sử dụng cùng dữ liệu biểu đồ và cài đặt ký hiệu chú giải trong tất cả bốn trường hợp. Bắt đầu với tất cả các đường viền được bật, mỗi biến thể còn lại chỉ tắt một cài đặt đường viền. Biến thể phía dưới bên trái khớp với cài đặt đường viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả đường viền bật, không có đường viền ngang, không có đường viền dọc, và không có đường viền ngoài](data-table-borders.png)

## **Hiển thị hoặc Ẩn Ký hiệu Chú giải**

Ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên series trong bảng dữ liệu. Chúng giúp người đọc ghép mỗi hàng bảng với một series trong biểu đồ. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) để hiển thị các dấu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bằng [IChart.setLegend](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ichart/#setLegend-boolean-). Các cài đặt này độc lập: ẩn chú giải riêng không ẩn các ký hiệu trong bảng dữ liệu, và ẩn các ký hiệu trong bảng không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu của nó, và hiển thị các ký hiệu chú giải bên trong khi ẩn chú giải riêng. Tất cả các đường viền bảng đều được bật rõ ràng. Không cần bản trình chiếu đầu vào. Để chỉ ẩn các ký hiệu trong bảng, truyền `false` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/java/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    IDataTable dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây hiển thị cùng một bảng với ký hiệu chú giải được bật và tắt. Tất cả các đường viền vẫn bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với ký hiệu chú giải hiển thị ở phía bên trái và ẩn ở phía bên phải](data-table-legend-keys.png)

## **Câu hỏi thường gặp**

**Bạn có thể hiển thị ký hiệu chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-) để hiển thị ký hiệu chú giải hoặc `false` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ và bảng dữ liệu đã hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/java/convert-powerpoint-to-pdf/), [HTML](/slides/vi/java/convert-powerpoint-to-html/) hoặc [images](/slides/vi/java/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ một bản trình chiếu hoặc mẫu hiện có, sử dụng [hasDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#hasDataTable--) và [setDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#setDataTable-boolean-) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm thế nào để tôi tìm các biểu đồ có bảng dữ liệu được bật?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ và gọi phương thức [hasDataTable](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#hasDataTable--) của chúng. Giá trị `true` cho biết bảng dữ liệu đã được bật.