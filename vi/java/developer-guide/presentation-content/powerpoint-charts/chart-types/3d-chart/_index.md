---
title: Tùy chỉnh biểu đồ 3D trong bản trình chiếu bằng Java
linktitle: Biểu đồ 3D
type: docs
url: /vi/java/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình chiếu PowerPoint với Aspose.Slides cho Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các dãy bằng các ví dụ Java."
---
## **Tổng quan**

Aspose.Slides for Java cho phép bạn tùy chỉnh chế độ xem của biểu đồ 3D thông qua phương thức [IChart.getRotation3D](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getRotation3D--) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc phải và khoảng cách giữa các dãy, sau đó lưu bản trình chiếu ở định dạng PPTX.

## **Đặt góc quay và độ sâu của biểu đồ 3D**

Ví dụ dưới tạo một [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và sử dụng [IShapeCollection.addChart](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) để thêm một biểu đồ cột 3D xếp chồng vào slide đầu tiên. Nó thay thế các dãy và danh mục mặc định bằng hai dãy, mỗi dãy có ba giá trị. Chỉ số worksheet `0` xác định worksheet dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên dãy, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationX-byte-) và [setRotationY](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRotationY-int-) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) đặt độ sâu của nó bằng 150 % chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) bật trục góc phải thay vì phối cảnh. Bản trình chiếu kết quả chứa biểu đồ đã được điền dữ liệu với các cài đặt chế độ xem 3D này.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.StackedColumn3D, 0, 0, 500, 500);

    chart.getChartData().getSeries().clear();
    chart.getChartData().getCategories().clear();

    IChartDataWorkbook workbook = chart.getChartData().getChartDataWorkbook();
    int worksheetIndex = 0;

    double[][] values = { { 20, 50, 30 }, { 30, 10, 60 } };

    for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
        IChartDataCell categoryCell = workbook.getCell(worksheetIndex, categoryIndex + 1, 0, "Category " + (categoryIndex + 1));
        chart.getChartData().getCategories().add(categoryCell);
    }

    for (int seriesIndex = 0; seriesIndex < 2; seriesIndex++) {
        IChartDataCell seriesCell = workbook.getCell(worksheetIndex, 0, seriesIndex + 1, "Series " + (seriesIndex + 1));
        IChartSeries series = chart.getChartData().getSeries().add(seriesCell, chart.getType());

        for (int categoryIndex = 0; categoryIndex < 3; categoryIndex++) {
            IChartDataCell valueCell = workbook.getCell(worksheetIndex, categoryIndex + 1, seriesIndex + 1, values[seriesIndex][categoryIndex]);
            series.getDataPoints().addDataPointForBarSeries(valueCell);
        }
    }

    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(270);
    chart.getRotation3D().setDepthPercents(150);

    presentation.save("Rotation3D_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Áp dụng tô màu Hình ảnh cho bề mặt biểu đồ 3D**

Một biểu đồ 3D có ba bề mặt mà bạn có thể tô riêng biệt: [side wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getSideWall--), [back wall](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getBackWall--) và [floor](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#getFloor--) . Đặt [fill type](https://reference.aspose.com/slides/java/com.aspose.slides/ifillformat/#setFillType-byte-) của bề mặt thành `Picture` và chỉ định một hình ảnh. Đặt cả [picture fill mode](https://reference.aspose.com/slides/java/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) và [picture type](https://reference.aspose.com/slides/java/com.aspose.slides/ichartwall/#setPictureType-int-) của bề mặt thành `Stretch` để kéo dài một bản sao của hình ảnh trên toàn bề mặt.

Lưu tập tin [arrow.png](arrow.png) trong thư mục làm việc. Ví dụ xoay biểu đồ và nâng giá trị tối đa trên trục dọc để sàn hiển thị giữa các cột. Sau đó nó sao chép slide hai lần và áp dụng mũi tên cho một bề mặt khác trên mỗi slide. Ba biểu đồ đều giữ cùng dữ liệu, góc nhìn và nền.

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 20, 30, 680, 480);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setRotationX((byte) 40);
    chart.getRotation3D().setRotationY(30);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(24);

    ISlide backSlide = presentation.getSlides().addClone(slide);
    ISlide floorSlide = presentation.getSlides().addClone(slide);
    IChart backChart = (IChart) backSlide.getShapes().get_Item(0);
    IChart floorChart = (IChart) floorSlide.getShapes().get_Item(0);

    byte[] imageBytes = Files.readAllBytes(Paths.get("arrow.png"));
    IPPImage arrow = presentation.getImages().addImage(imageBytes);

    IChartWall[] surfaces = { chart.getSideWall(), backChart.getBackWall(), floorChart.getFloor() };
    for (IChartWall surface : surfaces) {
        IFillFormat fill = surface.getFormat().getFill();
        fill.setFillType(FillType.Picture);
        fill.getPictureFillFormat().getPicture().setImage(arrow);
        fill.getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch);
        surface.setPictureType(PictureType.Stretch);
    }

    presentation.save("chart-surfaces.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Microsoft PowerPoint hiển thị ba slide như sau.

| Tường bên | Tường sau | Sàn |
| --- | --- | --- |
| ![Mũi tên chỉ vào biểu đồ dọc theo tường bên](side-wall.png) | ![Mũi tên chỉ sang phải trên tường sau](back-wall.png) | ![Mũi tên chỉ sang phải trên sàn giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Sử dụng [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ sau tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) với dữ liệu mặc định: ba dãy và bốn danh mục. Nó lưu ba bản trình chiếu với tỷ lệ chiều cao 50 %, 100 % và 200 %. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách dãy và định dạng đều giống nhau trong cả ba tệp; chỉ tỷ lệ chiều cao thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 460);
    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setRightAngleAxes(true);
    chart.getRotation3D().setDepthPercents(100);
    chart.getChartData().getSeries().get_Item(0).getParentSeriesGroup().setGapDepth(150);

    for (int heightPercent : new int[] { 50, 100, 200 }) {
        chart.getRotation3D().setHeightPercents(heightPercent);
        presentation.save("chart_height_" + heightPercent + ".pptx", SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới minh họa cùng một cài đặt chiều cao trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách đánh dấu trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt ở 50 % chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 100 % chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 200 % chiều rộng](height_percent_200.png) |

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Mô tả |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChart.setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/ishape/#setHeight-float-) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng điểm. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các dãy dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng đánh dấu. |

Cài đặt chiều cao ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ 3D dạng đường, vùng, bánh và bề mặt. So sánh ở trên sử dụng loại `Column3D` đã được xác nhận. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hay biểu đồ `BubbleWith3D`; các tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Chart Formatting](/slides/vi/java/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các dãy**

Sử dụng [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) để kiểm soát khoảng cách giữa các dãy dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng đánh dấu. Sử dụng giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng cách, trong khi giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, việc tăng khoảng cách làm cho các dấu mảnh hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getParentSeriesGroup--) . Cài đặt áp dụng cho mọi dãy trong nhóm đó, không chỉ dãy được dùng để truy cập. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getGapDepth--) trả về khoảng cách độ sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến các biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như các biểu đồ 3D dạng đường và vùng. Giao diện phụ thuộc vào việc các dãy được sắp xếp theo độ sâu, nhóm lại hay xếp chồng. Để so sánh rõ ràng khoảng cách giữa các dãy riêng biệt, hãy sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/).

Các phương thức này kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Mô tả |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các dãy dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng đánh dấu. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, dưới dạng phần trăm của chiều rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/java/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu tổng thể của biểu đồ, dưới dạng phần trăm của chiều rộng biểu đồ. |

Ví dụ tự chứa dưới đây sử dụng dữ liệu mặc định của biểu đồ, bao gồm ba dãy và bốn danh mục. Nó lưu hai bản trình chiếu với dữ liệu, góc quay, độ rộng khoảng trống và độ sâu biểu đồ giống nhau; chỉ độ sâu khoảng trống thay đổi.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.Column3D, 40, 30, 620, 230);

    chart.getRotation3D().setRotationX((byte) 20);
    chart.getRotation3D().setRotationY(30);
    chart.getRotation3D().setDepthPercents(100);

    IChartSeries series = chart.getChartData().getSeries().get_Item(0);
    IChartSeriesGroup group = series.getParentSeriesGroup();
    group.setGapWidth(150);

    for (int gapDepth : new int[] { 0, 500 }) {
        group.setGapDepth(gapDepth);

        String fileName = "series_gap_depth_" + gapDepth + ".pptx";
        presentation.save(fileName, SaveFormat.Pptx);
    }
} finally {
    presentation.dispose();
}
```

Các hình ảnh dưới minh họa cùng một cài đặt độ sâu khoảng trống trong ví dụ .NET tương đương và đã được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng trống: 0% | Độ sâu khoảng trống: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng trống giữa các dãy dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D có khoảng trống 500 % giữa các dãy dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi Kiểu Dãy 3D và Hình dạng Thanh**

Trong biểu đồ hình trụ nhóm, dãy đầu tiên bắt đầu với hình dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên được trả về bởi [IChartSeries.getType](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getType--) và [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getBar3DShape--) trước và sau mỗi lần thay đổi. Bảng dưới cung cấp tên hằng số tương ứng.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    
    IChart chart = slide.getShapes().addChart(ChartType.ClusteredCylinder, 20, 20, 500, 300);
    IChartSeries series = chart.getChartData().getSeries().get_Item(0);

    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setType(ChartType.ClusteredCone);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    series.setBar3DShape(ChartShapeType.Box);
    System.out.println(series.getType() + " | " + series.getBar3DShape());

    presentation.save("series_shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

| Thay đổi dãy đầu tiên | Kiểu dãy | Hình dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt kiểu dãy thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt hình dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt hình dạng thành `Box` cũng thay đổi kiểu dãy thành `ClusteredColumn3D`. Nếu mã của bạn dựa trên kiểu dãy, hãy gọi `series.getType()` sau khi thay đổi hình dạng. Giá trị được lưu trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint hiển thị dãy đầu tiên là hình trụ, hình nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **FAQ**

**Các kiểu biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100 % Stacked Column 3D, cùng với các kiểu 3D liên quan được khai thác qua lớp [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/java/com.aspose.slides/charttype/) trong tài liệu API của phiên bản bạn đang dùng.

**Tôi có thể lấy hình raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ ra ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#getImage--) hoặc [render toàn bộ slide](/slides/vi/java/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước dạng raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc xây dựng và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào khối lượng dữ liệu và độ phức tạp của đồ họa. Để đạt kết quả tốt nhất, hạn chế tối đa hiệu ứng 3D, tránh sử dụng kết cấu nặng trên tường và vùng vẽ, giảm số điểm dữ liệu mỗi dãy khi có thể, và render với kích thước đầu ra phù hợp (độ phân giải và kích thước) để đáp ứng nhu cầu hiển thị hoặc in ấn.