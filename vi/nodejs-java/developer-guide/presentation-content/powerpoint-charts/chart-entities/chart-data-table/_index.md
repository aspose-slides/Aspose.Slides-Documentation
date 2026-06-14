---
title: Tùy chỉnh bảng dữ liệu biểu đồ trong bản trình bày bằng JavaScript
linktitle: Bảng dữ liệu
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
description: "Tùy chỉnh bảng dữ liệu biểu đồ bằng JavaScript cho PPT và PPTX với Aspose.Slides cho Node.js qua Java để tăng hiệu quả và sự hấp dẫn trong các bản trình bày."
---
## **Tổng quan**

Bài viết này giải thích cách làm việc với bảng dữ liệu biểu đồ trong Aspose.Slides. Nó cho thấy cách hiển thị bảng dữ liệu cho một biểu đồ và tùy chỉnh định dạng văn bản bằng cách đặt các thuộc tính phông chữ như kiểu in đậm và kích thước phông chữ. Ví dụ minh họa cách tải một bản trình bày, thêm biểu đồ, bật bảng dữ liệu biểu đồ, áp dụng cài đặt phông chữ và lưu bản trình bày đã cập nhật.

Nó cũng bao gồm các câu trả lời ngắn gọn cho các câu hỏi thường gặp về việc hiển thị các chìa khóa chú giải trong bảng dữ liệu biểu đồ, bảo tồn bảng dữ liệu khi xuất, làm việc với các biểu đồ được tải từ bản trình bày hoặc mẫu hiện có, và xác định các biểu đồ mà bảng dữ liệu được bật.

## **Đặt Thuộc tính Phông chữ cho Bảng Dữ liệu Biểu đồ**

Aspose.Slides cho Node.js thông qua Java cung cấp hỗ trợ thay đổi màu của các danh mục trong một màu series.

1. Khởi tạo đối tượng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
1. Thêm biểu đồ vào slide.
1. Thiết lập bảng biểu đồ.
1. Đặt chiều cao phông chữ.
1. Lưu bản trình bày đã sửa đổi.

Dưới đây là ví dụ mẫu.

```javascript
// Tạo bản trình bày trống
var pres = new aspose.slides.Presentation();
try {
    var chart = pres.getSlides().get_Item(0).getShapes().addChart(aspose.slides.ChartType.ClusteredColumn, 50, 50, 600, 400);
    chart.setDataTable(true);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontBold(aspose.slides.NullableBool.True);
    chart.getChartDataTable().getTextFormat().getPortionFormat().setFontHeight(20);
    pres.save("output.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**Tôi có thể hiển thị các chìa khóa chú giải nhỏ bên cạnh các giá trị trong bảng dữ liệu của biểu đồ không?**

Có. Bảng dữ liệu hỗ trợ [legend keys](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/datatable/setshowlegendkey/), và bạn có thể bật hoặc tắt chúng.

**Bảng dữ liệu có được bảo tồn khi xuất bản trình bày sang PDF, HTML hoặc hình ảnh không?**

Có. Aspose.Slides render biểu đồ như một phần của slide, vì vậy bản xuất [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/)/[HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/)/[image](/slides/vi/nodejs-java/convert-powerpoint-to-png/) bao gồm biểu đồ cùng với bảng dữ liệu của nó.

**Các bảng dữ liệu có được hỗ trợ cho các biểu đồ được tạo từ tệp mẫu không?**

Có. Đối với bất kỳ biểu đồ nào được tải từ bản trình bày hoặc mẫu hiện có, bạn có thể kiểm tra và thay đổi việc bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/hasdatatable/) bằng cách sử dụng thuộc tính của biểu đồ.

**Làm thế nào tôi có thể nhanh chóng tìm ra những biểu đồ nào trong tệp có bảng dữ liệu được bật?**

Kiểm tra thuộc tính của từng biểu đồ cho biết bảng dữ liệu [is shown](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/chart/hasdatatable/) và duyệt qua các slide để xác định các biểu đồ mà bảng dữ liệu được bật.