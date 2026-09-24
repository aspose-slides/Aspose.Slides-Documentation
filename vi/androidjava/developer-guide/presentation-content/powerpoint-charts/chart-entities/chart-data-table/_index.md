---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình bày trên Android
linktitle: Bảng dữ liệu
type: docs
url: /vi/androidjava/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh phông chữ, viền và các ký hiệu chú giải của bảng dữ liệu biểu đồ trong bản trình bày PowerPoint bằng Aspose.Slides cho Android qua Java."
---
## **Tổng quan**

Aspose.Slides for Android via Java cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, điều khiển từng loại viền và hiển thị hoặc ẩn các ký hiệu chú giải. Các ví dụ lưu các biểu đồ đã cấu hình vào tệp PPTX.

## **Thiết lập thuộc tính phông chữ**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `true` vào [setDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#setDataTable-boolean-). Sử dụng [getChartDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#getChartDataTable--) để truy cập bảng và cấu hình định dạng văn bản của nó.

1. Tải bản trình bày bằng cách sử dụng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
3. Bật bảng dữ liệu của biểu đồ.
4. Bật chữ đậm bằng [setFontBold](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setFontBold-byte-) và truyền `20` vào [setFontHeight](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseportionformat/#setFontHeight-float-) để có văn bản 20 điểm.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ sau yêu cầu tệp `test.pptx` trong thư mục làm việc có ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), với độ rộng 600 điểm và độ cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các cài đặt phông chữ đã chỉ định được áp dụng.

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

## **Tùy chỉnh viền bảng dữ liệu**

Bật bảng bằng [IChart.setDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setDataTable-boolean-) và truy cập nó qua [IChart.getChartDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#getChartDataTable--). Bạn có thể điều khiển ba loại viền độc lập:

- [setBorderHorizontal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idatatable/#setBorderHorizontal-boolean-) điều khiển viền ô theo chiều ngang.
- [setBorderVertical](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idatatable/#setBorderVertical-boolean-) điều khiển viền ô theo chiều dọc.
- [setBorderOutline](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idatatable/#setBorderOutline-boolean-) điều khiển viền ngoài của bảng.

Truyền `true` vào mỗi phương thức để hiển thị viền hoặc `false` để ẩn chúng. Ví dụ sau tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị viền ngang và viền ngoài, và ẩn viền dọc. Không cần tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

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

So sánh dưới đây sử dụng cùng một dữ liệu biểu đồ và cùng cài đặt ký hiệu chú giải trong bốn trường hợp. Bắt đầu với tất cả viền được bật, mỗi biến thể còn lại sẽ tắt một loại viền. Biến thể góc dưới trái khớp với cài đặt viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả viền bật, không có viền ngang, không có viền dọc, và không có viền ngoài](data-table-borders.png)

## **Hiển thị hoặc ẩn các ký hiệu chú giải**

Ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc khớp mỗi hàng bảng với một chuỗi biểu đồ. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-) để hiển thị các dấu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bằng [IChart.setLegend](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ichart/#setLegend-boolean-). Các cài đặt này độc lập: ẩn chú giải riêng không ẩn các ký hiệu trong bảng dữ liệu, và ẩn ký hiệu trong bảng không ẩn chú giải riêng.

Ví dụ sau tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu, và hiển thị các ký hiệu chú giải trong bảng trong khi ẩn chú giải riêng. Tất cả viền bảng được bật rõ ràng. Không cần bản trình bày đầu vào. Để chỉ ẩn ký hiệu trong bảng, truyền `false` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/idatatable/#setShowLegendKey-boolean-).

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

So sánh dưới đây hiển thị cùng một bảng với ký hiệu chú giải được bật và tắt. Tất cả viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với ký hiệu chú giải hiển thị ở bên trái và ẩn ở bên phải](data-table-legend-keys.png)

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các ký hiệu chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-) để hiển thị các ký hiệu chú giải hoặc `false` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình bày ra PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides sẽ render biểu đồ và bảng dữ liệu đang hiển thị như một phần của slide khi xuất ra [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/), [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/), hoặc [images](/slides/vi/androidjava/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ một bản trình bày hoặc mẫu hiện có, sử dụng [hasDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#hasDataTable--) và [setDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#setDataTable-boolean-) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm thế nào để tôi tìm các biểu đồ có bảng dữ liệu được bật?**

Duyệt qua các shape trên mỗi slide, xác định các biểu đồ, và gọi phương thức [hasDataTable](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#hasDataTable--) của chúng. Giá trị `true` cho biết bảng dữ liệu đang được bật.