---
title: Tùy chỉnh biểu đồ 3D trong bản trình bày bằng JavaScript
linktitle: Biểu đồ 3D
type: docs
url: /vi/nodejs-java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình bày PowerPoint với Aspose.Slides cho Node.js thông qua Java. Điều chỉnh góc xoay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các chuỗi bằng các ví dụ JavaScript."
---
## **Tổng quan**

Aspose.Slides cho Node.js thông qua Java cho phép bạn tùy chỉnh góc nhìn của biểu đồ 3D thông qua phương thức [Chart.getRotation3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getrotation3d/). Bài viết này trình bày cách điều chỉnh góc xoay, tỷ lệ chiều cao, độ sâu, trục góc phải và khoảng cách giữa các chuỗi, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc xoay và độ sâu cho biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và sử dụng [ShapeCollection.addChart](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addchart/) để thêm một biểu đồ cột 3D chồng lên slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi chứa ba giá trị. Chỉ mục worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationx/) và [setRotationY](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrotationy/) đặt góc xoay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) đặt độ sâu của nó ở mức 150 % so với chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setrightangleaxes/) bật trục góc phải thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập góc nhìn 3D này.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    const workbook = chart.getChartData().getChartDataWorkbook();
    const worksheetIndex = 0;

    const values = [[20, 50, 30], [30, 10, 60]];

    for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        const categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (let seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        const seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        const series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (let categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            const valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Áp dụng nền ảnh cho bề mặt biểu đồ 3D**

Bạn có thể đặt nền cho [side wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getsidewall/), [back wall](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getbackwall/) và [floor](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chart/getfloor/) của biểu đồ 3D một cách độc lập. Đặt [fill type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/fillformat/setfilltype/) của bề mặt thành `Picture` và gán một hình ảnh. Đặt cả [picture fill mode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/picturefillformat/setpicturefillmode/) và [picture type](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartwall/setpicturetype/) của bề mặt thành `Stretch` để làm vừa một bản sao của hình ảnh trên toàn bề mặt.

Lưu tệp [arrow.png](arrow.png) vào thư mục làm việc. Ví dụ này xoay biểu đồ và nâng giá trị tối đa trên trục dọc sao cho nền (floor) hiển thị giữa các cột. Sau đó nó sao chép slide hai lần và áp dụng mũi tên vào một bề mặt khác trên mỗi slide. Cả ba biểu đồ đều giữ nguyên dữ liệu, góc nhìn và nền.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    
    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX(java.newByte(40));
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    const backSlide = presentation.getSlides().addClone(slide);
    const floorSlide = presentation.getSlides().addClone(slide);
    const backChart = backSlide.getShapes().get_Item(0);
    const floorChart = floorSlide.getShapes().get_Item(0);

    const image = slides.Images.fromFile("arrow.png");
    try {
        const arrow = presentation.getImages().addImage(image);
        const surfaces = [chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor()];
        for (const surface of surfaces) {
            const fill = surface.getFormat().getFill();
            fill.setFillType(java.newByte(slides.FillType.Picture));
            const pictureFill = fill.getPictureFillFormat();
            pictureFill.getPicture().setImage(arrow);
            pictureFill.setPictureFillMode(slides.PictureFillMode.Stretch);
            surface.setPictureType(slides.PictureType.Stretch);
        }
    } finally {
        image.dispose();
    }

    presentation.save("chart-surfaces.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Bề mặt bên | Bề mặt sau | Nền |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo bề mặt bên](side-wall.png) | ![Mũi tên chỉ sang phải trên bề mặt sau](back-wall.png) | ![Mũi tên chỉ sang phải trên nền giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao lần lượt là 50 %, 100 % và 200 %. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc xoay, độ sâu, khoảng cách chuỗi và định dạng đều giống nhau trong cả ba tệp; chỉ có phần trăm chiều cao thay đổi.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (const heightPercent of [50, 100, 200]) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây minh họa cùng một thiết lập chiều cao trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các nhãn trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50 % | Chiều cao: 100 % | Chiều cao: 200 % |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao bằng 50 % chiều rộng của nó](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao bằng 100 % chiều rộng của nó](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao bằng 200 % chiều rộng của nó](height_percent_200.png) |

Các phương pháp này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [Rotation3D.setHeightPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setheightpercents/) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [Chart.setHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setheight/) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [Rotation3D.setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường, vùng, bánh và bề mặt 3D. So sánh bên trên sử dụng kiểu `Column3D` đã được xác thực. Cài đặt này không thay đổi giao diện của biểu đồ `ClusteredColumn` 2D hoặc biểu đồ `BubbleWith3D`; các tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/nodejs-java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Sử dụng [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng dấu. Sử dụng giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng trống, trong khi các giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng trống làm cho các dấu mảnh hơn dọc theo trục độ sâu.

Truy cập nhóm qua [ChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getparentseriesgroup/). Cài đặt này áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được sử dụng để truy cập. [ChartSeries.getGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getgapdepth/) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ đường và vùng 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, nhóm lại hoặc chồng lên nhau. Để so sánh rõ ràng khoảng cách giữa các chuỗi riêng biệt, hãy dùng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/).

Các phương pháp này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [ChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapdepth/) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, tính bằng phần trăm của chiều rộng dấu. |
| [ChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseriesgroup/setgapwidth/) | Khoảng cách giữa các cụm cột hoặc thanh liền kề, tính bằng phần trăm của chiều rộng cột hoặc thanh. |
| [setDepthPercents](https://reference.aspose.com/slides/nodejs-java/aspose.slides/rotation3d/setdepthpercents/) | Độ sâu tổng thể của biểu đồ, tính bằng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu biểu đồ mặc định, bao gồm ba chuỗi và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc xoay, khoảng cách và độ sâu biểu đồ giống nhau; chỉ có khoảng cách độ sâu thay đổi.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX(java.newByte(20));
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    const series = chart.getChartData().getSeries().get_Item(0);
    const group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (const gapDepth of [0, 500]) {
        group.setGapDepth(gapDepth);

        const fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, slides.SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới đây minh họa cùng một cài đặt khoảng cách độ sâu trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint.

| Khoảng cách độ sâu: 0 % | Khoảng cách độ sâu: 500 % |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng trống giữa các chuỗi dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng trống 500 % giữa các chuỗi dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi kiểu chuỗi 3D và hình dạng thanh**

Trong biểu đồ trụ nhóm, chuỗi đầu tiên bắt đầu với hình dạng thanh trụ. Ví dụ in ra các giá trị nguyên trả về bởi [ChartSeries.getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/gettype/) và [ChartSeries.getBar3DShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/chartseries/getbar3dshape/) trước và sau mỗi thay đổi. Bảng dưới đây đưa ra các tên hằng số tương ứng.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const chart = slide.getShapes().addChart(slides.ChartType.ClusteredCylinder, 20, 20, 500, 300);
    const series = chart.getChartData().getSeries().get_Item(0);

    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setType(slides.ChartType.ClusteredCone);
    console.log(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(slides.ChartShapeType.Box);
    console.log(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Thay đổi chuỗi đầu tiên | Kiểu chuỗi | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt kiểu chuỗi thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi kiểu chuỗi thành `ClusteredColumn3D`. Nếu mã của bạn phân nhánh dựa trên kiểu chuỗi, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị được lưu trước khi gán sẽ vẫn chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị chuỗi đầu tiên dưới dạng trụ, nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100 % Stacked Column 3D, cùng các kiểu 3D liên quan được mở ra thông qua lớp [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đã cài đặt.

**Tôi có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ thành hình ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/) hoặc [render toàn bộ slide](/slides/vi/nodejs-java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc tạo và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp trực quan. Để đạt kết quả tốt nhất, hãy giữ hiệu ứng 3D ở mức tối thiểu, tránh sử dụng kết cấu nặng trên các bề mặt và vùng vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in.