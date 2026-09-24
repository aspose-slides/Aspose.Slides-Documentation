---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình bày bằng JavaScript
linktitle: Bảng Dữ liệu
type: docs
url: /vi/nodejs-java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh phông chữ, đường viền và ký hiệu chú giải của bảng dữ liệu biểu đồ trong bản trình bày PowerPoint bằng cách sử dụng Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cho phép bạn hiển thị bảng dữ liệu của biểu đồ và tùy chỉnh định dạng văn bản, đường viền và các ký hiệu chú giải. Bài viết này giải thích cách bật bảng, định dạng văn bản, kiểm soát từng loại đường viền và hiển thị hoặc ẩn các ký hiệu chú giải. Các ví dụ lưu các biểu đồ đã cấu hình dưới dạng tệp PPTX.

## **Thiết lập Thuộc tính Phông chữ**

Để hiển thị bảng dữ liệu của biểu đồ, truyền `true` vào [setDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/setdatatable/). Sử dụng [getChartDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/getchartdatatable/) để truy cập bảng và cấu hình định dạng văn bản.

1. Tải bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) .
2. Thêm một biểu đồ cột nhóm vào slide đầu tiên.
3. Bật bảng dữ liệu của biểu đồ.
4. Bật văn bản đậm bằng [setFontBold](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setfontbold) và truyền `20` vào [setFontHeight](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setfontheight) để có văn bản 20 điểm.
5. Lưu bản trình bày đã chỉnh sửa.

Ví dụ dưới đây yêu cầu tệp `input.pptx` trong thư mục làm việc có ít nhất một slide. Nó thêm một biểu đồ với dữ liệu mặc định tại vị trí (50, 50), với chiều rộng 600 điểm và chiều cao 400 điểm. Tệp `output.pptx` đã lưu chứa biểu đồ với bảng dữ liệu được bật và các cài đặt phông chữ đã chỉ định được áp dụng.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const java = require("java");

const presentation = new aspose.slides.Presentation("input.pptx");
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const portionFormat = chart.getChartDataTable().getTextFormat().getPortionFormat();
    portionFormat.setFontBold(java.newByte(aspose.slides.NullableBool.True));
    portionFormat.setFontHeight(20);

    presentation.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tùy chỉnh Đường viền Bảng Dữ liệu**

Bật bảng bằng [Chart.setDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/setdatatable/) và truy cập nó qua [Chart.getChartDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/getchartdatatable/). Bạn có thể kiểm soát ba loại đường viền một cách độc lập:

- [setBorderHorizontal](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setborderhorizontal/) kiểm soát đường viền ô theo chiều ngang.
- [setBorderVertical](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setbordervertical/) kiểm soát đường viền ô theo chiều dọc.
- [setBorderOutline](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setborderoutline/) kiểm soát đường viền ngoài của bảng.

Truyền `true` vào mỗi phương thức để hiển thị đường viền hoặc `false` để ẩn chúng. Ví dụ dưới đây tạo một biểu đồ cột nhóm với dữ liệu mặc định, hiển thị đường viền ngang và đường viền ngoài, và ẩn đường viền dọc. Nó không yêu cầu tệp đầu vào. Vị trí và kích thước của biểu đồ được chỉ định bằng điểm.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(false);
    dataTable.setBorderOutline(true);

    presentation.save("data-table-borders.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây sử dụng cùng dữ liệu biểu đồ và cài đặt ký hiệu chú giải trong cả bốn trường hợp. Bắt đầu với tất cả các đường viền được bật, mỗi biến thể còn lại chỉ tắt một cài đặt đường viền. Biến thể ở góc trái dưới khớp với cài đặt đường viền trong ví dụ.

![Bảng dữ liệu biểu đồ với tất cả các đường viền được bật, không có đường viền ngang, không có đường viền dọc, và không có đường viền ngoài](data-table-borders.png)

## **Hiển thị hoặc Ẩn Ký hiệu Chú giải**

Ký hiệu chú giải là các dấu màu nhỏ bên cạnh tên chuỗi trong bảng dữ liệu. Chúng giúp người đọc khớp mỗi hàng bảng với một chuỗi biểu đồ. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) để hiển thị các dấu này hoặc `false` để ẩn chúng.

Chú giải riêng của biểu đồ được điều khiển bởi [Chart.setLegend](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/setlegend/). Các cài đặt này độc lập: ẩn chú giải riêng không làm ẩn các ký hiệu trong bảng dữ liệu, và ẩn ký hiệu trong bảng không làm ẩn chú giải riêng.

Ví dụ dưới đây tạo một biểu đồ với dữ liệu mặc định, bật bảng dữ liệu của nó, và hiển thị các ký hiệu chú giải bên trong khi ẩn chú giải riêng. Tất cả các đường viền của bảng được bật một cách rõ ràng. Không yêu cầu bản trình bày đầu vào. Để chỉ ẩn các ký hiệu trong bảng, truyền `false` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setshowlegendkey/).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.setLegend(false);

    const dataTable = chart.getChartDataTable();
    dataTable.setBorderHorizontal(true);
    dataTable.setBorderVertical(true);
    dataTable.setBorderOutline(true);
    dataTable.setShowLegendKey(true);

    presentation.save("data-table-legend-keys.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh dưới đây hiển thị cùng một bảng với ký hiệu chú giải được bật và tắt. Tất cả các đường viền vẫn được bật, và chú giải riêng của biểu đồ được ẩn trong cả hai trường hợp.

![Bảng dữ liệu biểu đồ với ký hiệu chú giải hiển thị ở phía trái và ẩn ở phía phải](data-table-legend-keys.png)

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị ký hiệu chú giải trong bảng dữ liệu của biểu đồ không?**

Có. Truyền `true` vào [setShowLegendKey](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setshowlegendkey/) để hiển thị ký hiệu chú giải hoặc `false` để ẩn chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình bày sang PDF, HTML hoặc ảnh không?**

Có. Aspose.Slides render biểu đồ và bảng dữ liệu được hiển thị như một phần của slide khi xuất sang [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/), hoặc [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/).

**Tôi có thể làm việc với bảng dữ liệu trong biểu đồ được tải từ mẫu không?**

Có. Đối với biểu đồ được tải từ một bản trình bày hoặc mẫu hiện có, sử dụng [hasDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/hasdatatable/) và [setDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/setdatatable/) để kiểm tra hoặc thay đổi việc bảng dữ liệu có được hiển thị hay không.

**Làm sao tôi có thể tìm các biểu đồ có bảng dữ liệu được bật?**

Duyệt qua các hình dạng trên mỗi slide, xác định các biểu đồ, và gọi phương thức [hasDataTable](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/hasdatatable/) của chúng. Giá trị `true` cho biết bảng dữ liệu được bật.