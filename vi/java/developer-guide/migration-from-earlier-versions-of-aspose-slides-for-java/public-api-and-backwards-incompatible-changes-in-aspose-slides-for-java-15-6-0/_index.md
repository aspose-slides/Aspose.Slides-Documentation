---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 15.6.0
linktitle: Aspose.Slides cho Java 15.6.0
type: docs
weight: 140
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi phá vỡ trong Aspose.Slides cho Java để chuyển đổi suôn sẻ các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/), bất kỳ hạn chế mới và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-6-0/) nào được giới thiệu cùng với API Aspose.Slides for Java 15.6.0.

{{% /alert %}} 
## **Thay đổi API công khai**
#### **Chữ ký hàm tạo của com.aspose.slides.DataLabel đã được thay đổi**
Chữ ký của hàm tạo đã được thay đổi từ DataLabel(com.aspose.slides.IChartSeries) sang DataLabel(com.aspose.slides.IChartDataPoint).
#### **Các thành viên com.aspose.slides.IDocumentProperties.getCount(), .getPropertyName(int index)., .remove(String name), .contains(String name) đã được đánh dấu là Đã lỗi thời; các thay thế đã được giới thiệu**
Các phương thức IDocumentProperties.getCount(), IDocumentProperties.getPropertyName(int index)., .remove(string name), .contains(string name) đã được đánh dấu là Đã lỗi thời. Các phương thức IDocumentProperties.countOfCustomProperties(), IDocumentProperties.getCustomPropertyName(int index)., .removeCustomProperty(String name), .containsCustomProperty(string name) đã được giới thiệu thay thế.
#### **Phương thức com.aspose.slides.INotesSlideManager.removeNotesSlide() đã được thêm**
Phương thức com.aspose.slides.INotesSlideManager.RemoveNotesSlide() đã được thêm để xóa slide ghi chú của một slide nào đó.
#### **Phương thức com.aspose.slides.ISlide.getNotesSlideManager() đã được thêm. Các phương thức ISlide.getNotesSlide() và ISlide.addNotesSlide() đã được đánh dấu là Đã lỗi thời**
Các phương thức ISlide.getNotesSlide(), ISlide.addNotesSlide() đã được đánh dấu là Đã lỗi thời. Sử dụng phương thức mới ISlide.getNotesSlideManager() thay thế.

``` java

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.addNotesSlide(); - đã lỗi thời

// notes = slide.getNotesSlide(); - đã lỗi thời

notes = slide.getNotesSlideManager().getNotesSlide();

notes = slide.getNotesSlideManager().addNotesSlide();

slide.getNotesSlideManager().removeNotesSlide();

```
#### **Phương thức getAppVersion() đã được thêm vào com.aspose.slides.IDocumentProperties**
Phương thức com.aspose.slides.IDocumentProperties.getAppVersion() đã được thêm để lấy thuộc tính tài liệu tích hợp, đại diện cho số phiên bản nội bộ được Microsoft PowerPoint sử dụng.
#### **Phương thức remove() đã được thêm vào com.aspose.slides.IComment**
Phương thức com.aspose.slides.IComment.remove() đã được thêm để xóa bình luận khỏi bộ sưu tập.
#### **Phương thức remove() đã được thêm vào com.aspose.slides.ICommentAuthor**
Phương thức ICommentAuthor.Remove đã được thêm để xóa tác giả của các bình luận khỏi bộ sưu tập.
#### **Các phương thức clearCustomProperties() và clearBuiltInProperties() đã được thêm vào com.aspose.slides.IDocumentProperties**
Phương thức com.aspose.slides.IDocumentProperties.clearCustomProperties() đã được thêm để xóa tất cả các thuộc tính tài liệu tùy chỉnh.
Phương thức com.aspose.slides.IDocumentProperties.clearBuiltInProperties() đã được thêm để xóa và đặt lại giá trị mặc định cho tất cả các thuộc tính tài liệu tích hợp (Company, Subject, Author, v.v.).
#### **Các phương thức getBlackWhiteMode(), setBlackWhiteMode(byte) đã được thêm vào com.aspose.slides.IShape**
Các phương thức getBlackWhiteMode(), setBlackWhiteMode(byte) đã được thêm vào com.aspose.slides.IShape.
Các phương thức này xác định cách một hình dạng sẽ hiển thị trong chế độ đen‑trắng. Các giá trị khả dụng được xác định trong lớp com.aspose.slides.BlackWhiteMode.

|**Giá trị** |**Ý nghĩa** |
| :- | :- |
|Color |Trả về với màu bình thường |
|Automatic |Trả về với màu tự động |
|Gray |Trả về với màu xám |
|LightGray |Trả về với màu xám nhạt |
|InverseGray |Trả về với màu xám ngược |
|GrayWhite |Trả về với màu xám và trắng |
|BlackGray |Trả về với màu đen và xám |
|BlackWhite |Trả về với màu đen và trắng |
|Black |Trả về chỉ với màu đen |
|White |Trả về với màu trắng |
|Hidden |Đối tượng không được hiển thị |
#### **Các phương thức removeAt(int), remove(ICommentAuthor) và clear() đã được thêm vào com.aspose.slides.ICommentAuthorCollection**
Phương thức ICommentAuthorCollection.removeAt(int) đã được thêm để xóa tác giả theo chỉ số được chỉ định. Phương thức ICommentAuthorCollection.remove(ICommentAuthor) đã được thêm để xóa tác giả cụ thể khỏi bộ sưu tập. Phương thức ICommentAuthorCollection.clear() đã được thêm để xóa tất cả các mục khỏi bộ sưu tập.