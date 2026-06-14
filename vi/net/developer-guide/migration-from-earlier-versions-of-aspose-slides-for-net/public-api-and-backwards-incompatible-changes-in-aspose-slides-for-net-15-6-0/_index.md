---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.6.0
linktitle: Aspose.Slides cho .NET 15.6.0
type: docs
weight: 170
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để chuyển đổi mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 
Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và những thứ khác đã [thêm](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) hoặc [gỡ bỏ](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) và các thay đổi khác được giới thiệu trong API Aspose.Slides for .NET 15.6.0.
{{% /alert %}} 
## **Thay đổi API công khai**
#### **Thông số hàm tạo DataLabel đã được thay đổi**
Đã thay đổi thông số hàm tạo DataLabel:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Các thành viên IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) đã được đánh dấu là lỗi thời và đã được thay thế bằng các thành phần mới.**
Thuộc tính IDocumentProperties.Count và các phương thức IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) đã được đánh dấu là lỗi thời. Thay vào đó, đã thêm thuộc tính IDocumentProperties.CountOfCustomProperties và các phương thức IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name).
#### **Phương thức INotesSlideManager.RemoveNotesSlide() đã được thêm**
Phương thức INotesSlideManager.RemoveNotesSlide() đã được thêm để xóa slide ghi chú của một slide.
#### **Phương thức Remove đã được thêm vào IComment**
Phương thức IComment.Remove đã được thêm để xóa bình luận khỏi bộ sưu tập.
#### **Phương thức Remove đã được thêm vào ICommentAuthor**
Phương thức ICommentAuthor.Remove đã được thêm để xóa tác giả của các bình luận khỏi bộ sưu tập.
#### **Các phương thức ClearCustomProperties và ClearBuiltInProperties đã được thêm vào IDocumentProperties**
Phương thức IDocumentProperties.ClearCustomProperties đã được thêm để xóa tất cả thuộc tính tài liệu tùy chỉnh.
Phương thức IDocumentProperties.ClearBuiltInProperties đã được thêm để xóa và đặt lại giá trị mặc định cho tất cả các thuộc tính tài liệu tích hợp (Company, Subject, Author, v.v.).
#### **Các phương thức RemoveAt, Remove và Clear đã được thêm vào ICommentAuthorCollection**
Phương thức ICommentAuthorCollection.RemoveAt đã được thêm để xóa tác giả theo chỉ mục được chỉ định.
Phương thức ICommentAuthorCollection.Remove đã được thêm để xóa tác giả đã chỉ định khỏi bộ sưu tập.
Phương thức ICommentAuthorCollection.Clear đã được thêm để xóa tất cả các mục khỏi bộ sưu tập.
#### **Thuộc tính AppVersion đã được thêm vào IDocumentProperties**
Thuộc tính IDocumentProperties.AppVersion đã được thêm để lấy thuộc tính tài liệu tích hợp, biểu thị các số phiên bản nội bộ mà Microsoft sử dụng trong quá trình phát triển.
#### **Thuộc tính BlackWhiteMode đã được thêm vào IShape và Shape**
Thuộc tính BlackWhiteMode đã được thêm vào IShape và Shape.

Thuộc tính này chỉ định cách một hình dạng sẽ được hiển thị trong chế độ đen‑trắng.

|**Giá trị** |**Ý nghĩa** |
| :- | :- |
|Color |Hiển thị với màu sắc bình thường |
|Automatic |Hiển thị với màu tự động |
|Gray |Hiển thị với màu xám |
|LightGray |Hiển thị với màu xám nhạt |
|InverseGray |Hiển thị với màu xám ngược |
|GrayWhite |Hiển thị với màu xám và trắng |
|BlackGray |Hiển thị với màu đen và xám |
|BlackWhite |Hiển thị với màu đen và trắng |
|Black |Chỉ hiển thị màu đen |
|White |Hiển thị với màu trắng |
|Hidden |Không hiển thị |
|NotDefined |có nghĩa là thuộc tính chưa được đặt |
#### **Thuộc tính ISlide.NotesSlideManager đã được thêm. Thuộc tính ISlide.NotesSlide và phương thức ISlide.AddNotesSlide() đã được đánh dấu là lỗi thời.**
Các thành viên ISlide.NotesSlide, ISlide.AddNotesSlide() đã được đánh dấu là lỗi thời. Thay vào đó, sử dụng thuộc tính mới ISlide.NotesSlideManager.

``` csharp

 ISlide slide = ...;

INotesSlide notes;

// notes = slide.AddNotesSlide(); - lỗi thời

// notes = slide.NotesSlide; - lỗi thời

notes = slide.NotesSlideManager.NotesSlide;

notes = slide.NotesSlideManager.AddNotesSlide();

slide.NotesSlideManager.RemoveNotesSlide();

```