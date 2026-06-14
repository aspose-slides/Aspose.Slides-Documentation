---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.3.0
linktitle: Aspose.Slides cho .NET 14.3.0
type: docs
weight: 50
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-3-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- phương pháp cũ
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP một cách suôn sẻ."
---
## **API công khai và các thay đổi không tương thích ngược**
### **Đã thêm Enumeration Aspose.Slides.ShapeThumbnailBounds và các phương thức Aspose.Slides.IShape.GetThumbnail()**
Các phương thức GetThumbnail() và GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY) được sử dụng để tạo một hình thu nhỏ riêng cho shape. Enumeration ShapeThumbnailBounds định nghĩa các loại ràng buộc hình thu nhỏ cho shape có thể có.
### **Đã thêm Thuộc tính UniqueId vào Aspose.Slides.IShape**
Thuộc tính Aspose.Slides.IShape.UniqueId trả về một định danh shape duy nhất trong phạm vi của bản trình chiếu. Các định danh duy nhất này được lưu trong các thẻ tùy chỉnh của shape.
### **Chữ ký của phương thức SetGroupingItem đã thay đổi trong IChartCategoryLevelsManager**
Chữ ký của phương thức IChartCategoryLevelsManager

``` csharp

 void SetGroupingItem(int level, IChartDataCell value);

``` 

đã lỗi thời và được thay thế bằng chữ ký

``` csharp

 void SetGroupingItem(int level, object value);

``` 

Hiện tại các lời gọi như

``` csharp

 .SetGroupingItem(1, workbook.GetCell(0, "A2", "Group 1"));

``` 

phải được thay đổi thành các lời gọi như

``` csharp

 .SetGroupingItem(1, "Group 1");

``` 

Truyền một giá trị như "Group 1" vào SetGroupingItem nhưng không phải một giá trị thuộc kiểu IChartDataCell. Việc tạo IChartDataCell với một worksheet, hàng và cột đã xác định cho các cấp độ danh mục phải đáp ứng một số yêu cầu và đã được đóng gói trong phương thức SetGroupingItem(int, object).
### **Đã thêm Thuộc tính SlideId vào giao diện Aspose.Slides.IBaseSlide**
Thuộc tính SlideId trả về một định danh slide duy nhất.
### **Đã thêm Thuộc tính SoundName vào ISlideShowTransition**
Chuỗi đọc‑ghi. Xác định tên có thể đọc được bởi con người cho âm thanh của chuyển đổi. Thuộc tính Sound phải được gán để lấy hoặc đặt tên âm thanh. Tên này xuất hiện trong giao diện người dùng PowerPoint khi cấu hình âm thanh chuyển đổi theo cách thủ công. Có thể ném PptxException khi thuộc tính Sound không được gán.
### **Kiểu của Thuộc tính ChartSeriesGroup.Type đã thay đổi**
Thuộc tính ChartSeriesGroup.Type đã được thay đổi từ enumeration ChartType sang enumeration mới CombinableSeriesTypesGroup. Enum CombinableSeriesTypesGroup đại diện cho các nhóm kiểu series có thể kết hợp.
### **Đã thêm hỗ trợ tạo hình thu nhỏ riêng cho từng shape**
Aspose.Slides.ShapeThumbnailBounds

Các thành viên mới trong Aspose.Slides.IShape, Aspose.Slides.Shape:
public Bitmap GetThumbnail()
public Bitmap GetThumbnail(ShapeThumbnailBounds bounds, float scaleX, float scaleY)