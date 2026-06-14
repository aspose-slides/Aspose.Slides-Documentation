---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình chiếu trên Android
linktitle: Bảng Dữ Liệu
type: docs
url: /vi/androidjava/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong Java cho PPT và PPTX bằng Aspose.Slides cho Android để tăng hiệu quả và sức hấp dẫn trong các bản trình chiếu."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu đáp đậm và chiều cao phông. Ví dụ minh họa cách tải một bản trình chiếu, thêm biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản trình chiếu đã cập nhật.

## **Đặt Thuộc Tính Phông Chữ cho Bảng Dữ Liệu Biểu Đồ**
Aspose.Slides for Android via Java cung cấp hỗ trợ thay đổi màu của các danh mục trong màu chuỗi.

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Đặt bảng biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình chiếu đã sửa đổi.

Ví dụ mẫu dưới đây được đưa ra.

```java
// Tạo bản trình chiếu trống
Presentation pres = new Presentation();
try {
    IChart chart = pres.getSlides().get_Item(0).getShapes().addChart(ChartType.ClusteredColumn, 50, 50, 600, 400);

    chart.setDataTable(true);

    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);

    pres.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các ký hiệu chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/datatable/#setShowLegendKey-boolean-), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản trình chiếu sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy [PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/androidjava/convert-powerpoint-to-html/)/[image](/slides/vi/androidjava/convert-powerpoint-to-png/) xuất ra sẽ bao gồm biểu đồ cùng với bảng dữ liệu của nó.

**Các bảng dữ liệu có được hỗ trợ cho các biểu đồ đến từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ bản trình chiếu hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#hasDataTable--) bằng cách sử dụng các thuộc tính của biểu đồ.

**Làm thế nào để tôi nhanh chóng tìm thấy các biểu đồ nào trong tệp đã bật bảng dữ liệu?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/chart/#hasDataTable--) và lặp lại qua các slide để xác định các biểu đồ mà nó đã được bật.