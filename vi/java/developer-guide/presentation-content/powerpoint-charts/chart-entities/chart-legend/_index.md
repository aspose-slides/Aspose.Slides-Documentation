---
title: Tùy chỉnh chú giải biểu đồ trong bản trình chiếu bằng Java
linktitle: Chú giải biểu đồ
type: docs
url: /vi/java/chart-legend/
keywords:
- chú giải biểu đồ
- vị trí chú giải
- kích thước phông chữ
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tùy chỉnh chú giải biểu đồ với Aspose.Slides cho Java để tối ưu hoá các bản trình chiếu PowerPoint với định dạng chú giải được thiết kế riêng."
---
## **Tổng quan**

Aspose.Slides for Java cung cấp các tùy chọn để tùy chỉnh chú giải biểu đồ trong bản trình bày PowerPoint. Bài viết này trình bày cách định vị và kích thước một chú giải, đặt kích thước phông chữ cho toàn bộ chú giải, định dạng một mục chú giải riêng lẻ, và ẩn hoặc khôi phục các mục đã chọn.

Phần Câu hỏi thường gặp đề cập đến các hành vi liên quan, bao gồm việc dự trữ không gian cho chú giải, hiển thị nhãn đa dòng, và kế thừa định dạng từ chủ đề của bản trình bày.

## **Định vị chú giải**

Sử dụng các phương thức [setX](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setX-float-), [setY](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setY-float-), [setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setWidth-float-), và [setHeight](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setHeight-float-) của chú giải để chỉ định vị trí và kích thước của nó dưới dạng tỷ lệ của kích thước biểu đồ.

Ví dụ này tạo một bản trình bày và thêm một biểu đồ cột nhóm với dữ liệu mặc định vào slide đầu tiên. Việc chia các lệch và kích thước mong muốn của chú giải cho chiều rộng và chiều cao của biểu đồ chuyển chúng thành các giá trị tương đối: chú giải được dịch chuyển 50 điểm từ góc trên‑trái của biểu đồ và có kích thước 100 × 100 điểm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 500, 500);

    // Diễn đạt vị trí và kích thước của chú giải so với biểu đồ.
    chart.getLegend().setX(50 / chart.getWidth());
    chart.getLegend().setY(50 / chart.getHeight());
    chart.getLegend().setWidth(100 / chart.getWidth());
    chart.getLegend().setHeight(100 / chart.getHeight());

    presentation.save("legend_position.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt kích thước phông chữ cho chú giải**

Sử dụng [getTextFormat](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getTextFormat--) của chú giải để truy cập định dạng văn bản và dùng [setFontHeight](https://reference.aspose.com/slides/java/com.aspose.slides/baseportionformat/#setFontHeight-float-) để đặt kích thước phông chữ tính bằng điểm.

Ví dụ này tạo một biểu đồ với dữ liệu mặc định và đặt văn bản chú giải thành 20 điểm. Nó cũng tắt giới hạn tự động cho trục tung và đặt phạm vi của trục từ -5 tới 10.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.getLegend().getTextFormat().getPortionFormat().setFontHeight(20);
    chart.getAxes().getVerticalAxis().setAutomaticMinValue(false);
    chart.getAxes().getVerticalAxis().setMinValue(-5);
    chart.getAxes().getVerticalAxis().setAutomaticMaxValue(false);
    chart.getAxes().getVerticalAxis().setMaxValue(10);

    presentation.save("legend_font_size.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt kích thước phông chữ cho một mục chú giải riêng lẻ**

Sử dụng bộ sưu tập trả về bởi phương thức [getEntries](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#getEntries--) của chú giải để truy cập định dạng cho một mục cụ thể. Chỉ số mục được đánh số bắt đầu từ 0, vì vậy chỉ số `1` tương ứng với mục thứ hai.

Ví dụ này tạo một biểu đồ cột nhóm mà dữ liệu mặc định bao gồm ít nhất hai chuỗi. Nó định dạng mục chú giải thứ hai với chữ đậm, nghiêng và màu xanh, kích thước 20 điểm.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    IChartTextFormat textFormat = chart.getLegend().getEntries().get_Item(1).getTextFormat();

    textFormat.getPortionFormat().setFontBold(NullableBool.True);
    textFormat.getPortionFormat().setFontHeight(20);
    textFormat.getPortionFormat().setFontItalic(NullableBool.True);
    textFormat.getPortionFormat().getFillFormat().setFillType(FillType.Solid);
    textFormat.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    presentation.save("legend_entry_format.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Ẩn các mục chú giải riêng lẻ**

Để loại bỏ một chuỗi phụ khỏi chú giải trong khi vẫn hiển thị dữ liệu của nó, gọi [ILegendEntryProperties.setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) với `true` thông qua [IChartSeries.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartseries/#getRelatedLegendEntry--). Điều này chỉ ẩn mục chú giải đã chọn; nó không xóa chuỗi hoặc các điểm dữ liệu của chuỗi đó. Ngược lại, gọi [IChart.setLegend](https://reference.aspose.com/slides/java/com.aspose.slides/ichart/#setLegend-boolean-) với `false` sẽ ẩn toàn bộ chú giải.

Ví dụ dưới đây tạo một biểu đồ cột nhóm với nhiều chuỗi sử dụng dữ liệu mặc định. Nó ẩn mục chú giải của chuỗi thứ hai (chỉ số `1`) và lưu bản trình bày. Sau đó khôi phục mục bằng cách gọi [setHide](https://reference.aspose.com/slides/java/com.aspose.slides/ilegendentryproperties/#setHide-boolean-) với `false` và lưu một bản sao thứ hai. Các cột vẫn hiển thị trong cả hai tệp.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IChart chart = slide.getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setLegend(true);

    ILegendEntryProperties legendEntry = chart.getChartData().getSeries().get_Item(1).getRelatedLegendEntry();

    legendEntry.setHide(true);
    presentation.save("hidden_legend_entry.pptx", SaveFormat.Pptx);

    // Khôi phục cùng một mục mà không thay đổi dữ liệu biểu đồ.
    legendEntry.setHide(false);
    presentation.save("restored_legend_entry.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

So sánh bên dưới cho thấy cùng một biểu đồ với tất cả các mục chú giải hiển thị và với mục thứ hai bị ẩn. Các cột của chuỗi thứ hai vẫn không thay đổi.

![So sánh biểu đồ với tất cả các mục chú giải hiển thị và với Series 2 ẩn khỏi chú giải; tất cả các cột vẫn hiển thị.](hide-legend-entry.png)

Trong các biểu đồ cột, thanh và đường, các mục chú giải xác định chuỗi. Đối với biểu đồ tròn, chúng xác định các điểm dữ liệu riêng lẻ (mẫu), vì vậy hãy sử dụng [IChartDataPoint.getRelatedLegendEntry](https://reference.aspose.com/slides/java/com.aspose.slides/ichartdatapoint/#getRelatedLegendEntry--) trên mẫu đã chọn. API ghi lại phương thức điểm dữ liệu này cho các kiểu biểu đồ `Pie`, `Pie3D`, `ExplodedPie`, `ExplodedPie3D`, `PieOfPie` và `BarOfPie`. Đừng cho rằng nó áp dụng cho biểu đồ vòng vòng, vì chúng không nằm trong danh sách này.

## **Câu hỏi thường gặp**

**Tôi có thể làm cho biểu đồ dành không gian cho chú giải thay vì phủ lên nó không?**

Có. Gọi [setOverlay](https://reference.aspose.com/slides/java/com.aspose.slides/legend/#setOverlay-boolean-) với `false` để dự trữ không gian cho chú giải thay vì cho phép nó phủ lên khu vực vẽ.

**Tôi có thể tạo nhãn chú giải đa dòng không?**

Có. Nhãn dài có thể được tự động ngắt dòng khi chiều rộng khả dụng không đủ. Bạn cũng có thể sử dụng ký tự xuống dòng trong tên chuỗi để yêu cầu ngắt dòng.

**Làm sao để chú giải tuân theo bảng màu của chủ đề bản trình bày?**

Để màu sắc, nền và phông chữ của chú giải không được thiết lập để nó có thể kế thừa định dạng của chủ đề. Định dạng rõ ràng sẽ ghi đè lên các cài đặt tương ứng của chủ đề.