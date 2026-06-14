---
title: Tùy chỉnh Bảng Dữ liệu Biểu đồ trong Bản Thuyết Trình bằng Java
linktitle: Bảng Dữ liệu
type: docs
url: /vi/java/chart-data-table/
keywords:
- dữ liệu biểu đồ
- bảng dữ liệu
- thuộc tính phông chữ
- PowerPoint
- bản thuyết trình
- Java
- Aspose.Slides
description: "Tùy chỉnh bảng dữ liệu biểu đồ trong Java cho PPT và PPTX với Aspose.Slides để tăng hiệu suất và sức hấp dẫn trong bản thuyết trình."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu đậm và chiều cao phông. Ví dụ minh họa việc tải một bản thuyết trình, thêm một biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản thuyết trình đã cập nhật.

Nó cũng bao gồm các trả lời ngắn gọn cho các câu hỏi thường gặp về việc hiển thị các khóa chú giải trong bảng dữ liệu biểu đồ, bảo toàn bảng dữ liệu khi xuất, làm việc với các biểu đồ được tải từ bản thuyết trình hoặc mẫu hiện có, và xác định các biểu đồ có bật bảng dữ liệu.

## **Đặt Thuộc tính Phông chữ cho Bảng Dữ liệu Biểu đồ**
Aspose.Slides for Java cung cấp khả năng thay đổi màu của các danh mục trong một series màu.

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Thêm biểu đồ vào slide.
3. Cài đặt bảng dữ liệu cho biểu đồ.
4. Đặt chiều cao phông chữ.
5. Lưu bản thuyết trình đã chỉnh sửa.

Ví dụ mẫu dưới đây được đưa ra.

```java
// Tạo bản thuyết trình trống
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

**Có thể hiển thị các khóa chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/java/com.aspose.slides/datatable/#setShowLegendKey-boolean-), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được giữ lại khi xuất bản thuyết trình sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, do đó [PDF](/slides/vi/java/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/java/convert-powerpoint-to-html/)/[image](/slides/vi/java/convert-powerpoint-to-png/) xuất ra sẽ bao gồm biểu đồ cùng bảng dữ liệu của nó.

**Bảng dữ liệu có được hỗ trợ cho các biểu đồ được lấy từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ một bản thuyết trình hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#hasDataTable--) bằng các thuộc tính của biểu đồ.

**Làm sao tôi có thể nhanh chóng tìm ra những biểu đồ nào trong tệp có bật bảng dữ liệu không?**

Kiểm tra thuộc tính của mỗi biểu đồ cho biết bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/java/com.aspose.slides/chart/#hasDataTable--) và duyệt qua các slide để xác định các biểu đồ mà nó được bật.