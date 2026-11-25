---
title: Tùy chỉnh biểu đồ 3D trong bản trình chiếu trên Android
linktitle: Biểu đồ 3D
type: docs
url: /vi/androidjava/3d-chart/
keywords:
- biểu đồ 3D
- xoay
- độ sâu
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tạo biểu đồ 3D trong bản trình chiếu PowerPoint với Aspose.Slides cho Android qua Java. Điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu biểu đồ và khoảng cách giữa các chuỗi bằng các ví dụ Java."
---
## **Tổng quan**

Aspose.Slides for Android via Java cho phép bạn tùy chỉnh cách hiển thị của biểu đồ 3D thông qua phương thức [IChart.getRotation3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getRotation3D--) . Bài viết này trình bày cách điều chỉnh góc quay, tỷ lệ chiều cao, độ sâu, trục góc vuông và khoảng cách giữa các chuỗi, sau đó lưu bản trình bày ở định dạng PPTX.

## **Đặt góc quay và độ sâu của biểu đồ 3D**

Ví dụ dưới đây tạo một [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/) và sử dụng [IShapeCollection.addChart](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addChart-int-float-float-float-float-) để thêm một biểu đồ cột 3D chồng vào slide đầu tiên. Nó thay thế các chuỗi và danh mục mặc định bằng hai chuỗi, mỗi chuỗi chứa ba giá trị. Chỉ mục bảng tính `0` xác định bảng dữ liệu đầu tiên của biểu đồ; hàng `0` chứa tên chuỗi, và cột `0` chứa nhãn danh mục.

Các phương thức [setRotationX](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationX-byte-) và [setRotationY](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRotationY-int-) đặt góc quay của biểu đồ lần lượt là 40 và 270 độ. [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) đặt độ sâu của nó bằng 150% chiều rộng, trong khi [setRightAngleAxes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setRightAngleAxes-boolean-) bật trục góc vuông thay vì phối cảnh. Bản trình bày kết quả chứa biểu đồ đã được điền dữ liệu với các thiết lập hiển thị 3D này.

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

## **Áp dụng tô ảnh cho bề mặt biểu đồ 3D**

Biểu đồ 3D có ba bề mặt mà bạn có thể tô riêng biệt: [tường bên](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getSideWall--), [tường sau](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getBackWall--) và [sàn](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichart/#getFloor--). Đặt [kiểu tô](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ifillformat/#setFillType-byte-) của bề mặt thành `Picture` và chỉ định một hình ảnh. Đặt cả [chế độ tô ảnh](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipicturefillformat/#setPictureFillMode-int-) và [kiểu ảnh](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartwall/#setPictureType-int-) của bề mặt thành `Stretch` để ảnh chỉ xuất hiện một lần trên toàn bề mặt.

Lưu [arrow.png](arrow.png) vào thư mục làm việc. Ví dụ quay biểu đồ và tăng giá trị tối đa trên trục dọc để sàn hiển thị giữa các cột. Sau đó nó sao chép slide hai lần và áp dụng mũi tên vào một bề mặt khác trên mỗi slide. Ba biểu đồ đều giữ cùng dữ liệu, góc nhìn và nền.

```java
import com.aspose.slides.*;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try (FileInputStream image = new FileInputStream("arrow.png")) {
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

    IPPImage arrow = presentation.getImages().addImage(image);

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
| ![Mũi tên chỉ vào biểu đồ dọc theo tường bên](side-wall.png) | ![Mũi tên chỉ sang phải qua tường sau](back-wall.png) | ![Mũi tên chỉ sang phải trên sàn giữa các cột](floor.png) |

## **Điều chỉnh tỷ lệ chiều cao của biểu đồ 3D**

Dùng [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) để đặt chiều cao của biểu đồ 3D dưới dạng phần trăm của chiều rộng. Điều này thay đổi tỷ lệ của cảnh 3D mà không thay đổi kích thước đối tượng biểu đồ trên slide.

Ví dụ dưới đây tạo một biểu đồ [Column3D](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) với dữ liệu mặc định: ba chuỗi và bốn danh mục. Nó lưu ba bản trình bày với tỷ lệ chiều cao 50%, 100% và 200%. Vị trí, chiều rộng và chiều cao của biểu đồ vẫn cố định. Dữ liệu, góc quay, độ sâu, khoảng cách chuỗi và định dạng đều giống nhau trong ba tệp; chỉ có phần trăm chiều cao thay đổi.

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

Các hình ảnh dưới đây minh họa cùng cài đặt chiều cao trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint. Phần trăm nhỏ hơn tạo ra cảnh phẳng hơn, trong khi phần trăm lớn hơn tạo ra cảnh cao hơn trong cùng một đối tượng biểu đồ. PowerPoint cũng có thể điều chỉnh khoảng cách các đánh dấu trục và vị trí nhãn để phù hợp với cảnh.

| Chiều cao: 50% | Chiều cao: 100% | Chiều cao: 200% |
| --- | --- | --- |
| ![Biểu đồ cột 3D với chiều cao đặt ở 50% chiều rộng](height_percent_50.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 100% chiều rộng](height_percent_100.png) | ![Biểu đồ cột 3D với chiều cao đặt ở 200% chiều rộng](height_percent_200.png) |

Các phương thức kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [IRotation3D.setHeightPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setHeightPercents-int-) | Chiều cao của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChart.setHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishape/#setHeight-float-) | Chiều cao của đối tượng biểu đồ trên slide, tính bằng point. |
| [IRotation3D.setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu của cảnh 3D dưới dạng phần trăm của chiều rộng. |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |

Cài đặt chiều cao ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, hình nón và hình kim tự tháp, cũng như biểu đồ đường, diện tích, bánh và bề mặt 3D. So sánh ở trên sử dụng kiểu `Column3D` đã được xác minh. Cài đặt này không thay đổi giao diện của biểu đồ 2D `ClusteredColumn` hoặc `BubbleWith3D`; các tên này là thành viên của lớp [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Đối với các cài đặt giao diện biểu đồ khác, xem [Định dạng Biểu đồ](/slides/vi/androidjava/chart-formatting/).

## **Điều chỉnh khoảng cách giữa các chuỗi**

Dùng [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) để kiểm soát khoảng cách giữa các chuỗi dữ liệu dọc theo trục độ sâu của biểu đồ 3D, biểu thị dưới dạng phần trăm của chiều rộng marker. Sử dụng các giá trị từ **0 đến 500**, bao gồm: `0` loại bỏ khoảng trống, trong khi giá trị lớn hơn tăng khoảng cách. Với độ sâu biểu đồ cố định, tăng khoảng trống khiến các marker mỏng hơn dọc theo trục độ sâu.

Truy cập nhóm qua [IChartSeries.getParentSeriesGroup](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getParentSeriesGroup--). Cài đặt áp dụng cho mọi chuỗi trong nhóm đó, không chỉ chuỗi được dùng để truy cập. [IChartSeries.getGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getGapDepth--) trả về khoảng cách sâu và phản ánh cài đặt của nhóm cha.

Cài đặt này ảnh hưởng đến biểu đồ cột và thanh 3D, bao gồm các biến thể hình trụ, nón và kim tự tháp, cũng như biểu đồ đường và diện tích 3D. Giao diện phụ thuộc vào việc các chuỗi được sắp xếp theo độ sâu, nhóm hoặc chồng. Để so sánh rõ ràng các khoảng cách giữa các chuỗi riêng biệt, sử dụng `ChartType.Column3D` từ lớp [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/).

Các phương thức kiểm soát các khía cạnh khác nhau của biểu đồ:

| Phương thức | Hiệu quả |
| --- | --- |
| [IChartSeriesGroup.setGapDepth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapDepth-int-) | Khoảng cách giữa các chuỗi dọc theo trục độ sâu, dưới dạng phần trăm của chiều rộng marker. |
| [IChartSeriesGroup.setGapWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseriesgroup/#setGapWidth-int-) | Khoảng cách giữa các cụm thanh hoặc cột liền kề, dưới dạng phần trăm của chiều rộng thanh hoặc cột. |
| [setDepthPercents](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irotation3d/#setDepthPercents-int-) | Độ sâu tổng thể của biểu đồ, dưới dạng phần trăm của chiều rộng biểu đồ. |

Ví dụ dưới đây sử dụng dữ liệu biểu đồ mặc định, chứa ba chuỗi và bốn danh mục. Nó lưu hai bản trình bày với dữ liệu, góc quay, độ rộng khoảng trống và độ sâu biểu đồ giống nhau; chỉ có độ sâu khoảng trống thay đổi.

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

Các hình ảnh dưới đây minh họa cùng cài đặt độ sâu khoảng trống trong ví dụ .NET tương đương và được xuất bằng Microsoft PowerPoint.

| Độ sâu khoảng trống: 0% | Độ sâu khoảng trống: 500% |
| --- | --- |
| ![Biểu đồ cột 3D không có khoảng trống giữa các chuỗi dọc theo trục độ sâu](gap_depth_0.png) | ![Biểu đồ cột 3D với khoảng trống 500% giữa các chuỗi dọc theo trục độ sâu](gap_depth_500.png) |

## **Thay đổi loại chuỗi 3D và dạng thanh**

Trong biểu đồ hình trụ nhóm, chuỗi đầu tiên bắt đầu với dạng thanh hình trụ. Ví dụ in ra các giá trị nguyên được trả về bởi [IChartSeries.getType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getType--) và [IChartSeries.getBar3DShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ichartseries/#getBar3DShape--) trước và sau mỗi thay đổi. Bảng dưới đây cung cấp các tên hằng số tương ứng.

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

| Thay đổi cho chuỗi đầu tiên | Loại chuỗi | Dạng thanh |
| --- | --- | --- |
| Tạo biểu đồ | `ClusteredCylinder` | `Cylinder` |
| Đặt loại chuỗi thành `ClusteredCone` | `ClusteredCone` | `Cone` |
| Đặt dạng thanh thành `Box` | `ClusteredColumn3D` | `Box` |

Đặt dạng thanh thành `Box` cũng thay đổi loại chuỗi thành `ClusteredColumn3D`. Nếu code của bạn nhánh dựa trên loại chuỗi, hãy gọi `series.getType()` sau khi thay đổi dạng thanh. Giá trị được lưu trước khi gán vẫn sẽ chọn nhánh `ClusteredCone`.

![So sánh PowerPoint cho thấy chuỗi đầu tiên dưới dạng hình trụ, hình nón và cột hình chữ nhật từ trái sang phải](series-shapes.png)

## **Câu hỏi thường gặp**

**Các loại biểu đồ nào hỗ trợ chế độ 3D trong Aspose.Slides?**

Aspose.Slides hỗ trợ các biến thể 3D của biểu đồ cột, bao gồm Column 3D, Clustered Column 3D, Stacked Column 3D và 100% Stacked Column 3D, cùng với các loại 3D liên quan được mở ra thông qua [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/). Để có danh sách chính xác và cập nhật, hãy kiểm tra các thành viên của [ChartType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/charttype/) trong tài liệu API của phiên bản đã cài đặt.

**Có thể lấy hình ảnh raster của biểu đồ 3D cho báo cáo hoặc web không?**

Có. Bạn có thể xuất biểu đồ sang hình ảnh bằng [Shape.getImage](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#getImage--) hoặc [render the entire slide](/slides/vi/androidjava/convert-powerpoint-to-png/) sang các định dạng như PNG hoặc JPEG. Điều này hữu ích khi bạn cần bản xem trước raster hoặc muốn nhúng biểu đồ vào tài liệu, bảng điều khiển hoặc trang web mà không cần PowerPoint.

**Hiệu năng của việc tạo và render các biểu đồ 3D lớn như thế nào?**

Hiệu năng phụ thuộc vào lượng dữ liệu và độ phức tạp visual. Để đạt kết quả tốt nhất, hãy giữ các hiệu ứng 3D ở mức tối thiểu, tránh sử dụng texture nặng trên tường và khu vực vẽ, hạn chế số điểm dữ liệu mỗi chuỗi khi có thể, và render ra kích thước đầu ra phù hợp (độ phân giải và kích thước) để khớp với nhu cầu hiển thị hoặc in.