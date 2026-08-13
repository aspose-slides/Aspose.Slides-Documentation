---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 15.6.0
linktitle: Aspose.Slides cho .NET 15.6.0
type: docs
weight: 170
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để chuyển đổi mượt mà các giải pháp bài thuyết trình PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và những thứ khác đã được [added](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/) hoặc [removed](/slides/vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-15-6-0/), và các thay đổi khác được giới thiệu với Aspose.Slides for .NET 15.6.0 API.

{{% /alert %}} 
## **Thay đổi API công cộng**
#### **Chữ ký Constructor của DataLabel đã được thay đổi**
Chữ ký constructor của DataLabel đã được thay đổi:
was: DataLabel.#ctor(Aspose.Slides.Charts.IChartSeries);
now: DataLabel.#ctor(Aspose.Slides.Charts.IChartDataPoint).
#### **Các thành viên IDocumentProperties.Count, .GetPropertyName(int index), .Remove(string name), .Contains(string name) đã được đánh dấu là Obsolete và đã được thay thế bằng các thành viên mới.**
Thuộc tính IDocumentProperties.Count và các phương thức IDocumentProperties.GetPropertyName(int index), .Remove(string name), .Contains(string name) đã được đánh dấu là Obsolete. Thuộc tính IDocumentProperties.CountOfCustomProperties và các phương thức IDocumentProperties.GetCustomPropertyName(int index), .RemoveCustomProperty(string name), .ContainsCustomProperty(string name) đã được thêm thay thế.
#### **Phương thức INotesSlideManager.RemoveNotesSlide() đã được thêm**
Phương thức INotesSlideManager.RemoveNotesSlide() đã được thêm để loại bỏ slide ghi chú của một slide nào đó.
#### **Phương thức Remove đã được thêm vào IComment**
Phương thức IComment.Remove đã được thêm để loại bỏ bình luận khỏi bộ sưu tập.
#### **Phương thức Remove đã được thêm vào ICommentAuthor**
Phương thức ICommentAuthor.Remove đã được thêm để loại bỏ tác giả của bình luận khỏi bộ sưu tập.
#### **Các phương thức ClearCustomProperties và ClearBuiltInProperties đã được thêm vào IDocumentProperties**
Phương thức IDocumentProperties.ClearCustomProperties đã được thêm để loại bỏ tất cả thuộc tính tài liệu tùy chỉnh.
Phương thức IDocumentProperties.ClearBuiltInProperties đã được thêm để xóa và đặt lại giá trị mặc định cho tất cả các thuộc tính tài liệu tích hợp (Company, Subject, Author etc).
#### **Các phương thức RemoveAt, Remove và Clear đã được thêm vào ICommentAuthorCollection**
Phương thức ICommentAuthorCollection.RemoveAt đã được thêm để loại bỏ tác giả theo chỉ số được chỉ định.
Phương thức ICommentAuthorCollection.Remove đã được thêm để loại bỏ tác giả được chỉ định khỏi bộ sưu tập.
Phương thức ICommentAuthorCollection.Clear đã được thêm để loại bỏ tất cả mục khỏi bộ sưu tập.
#### **Thuộc tính AppVersion đã được thêm vào IDocumentProperties**
Thuộc tính IDocumentProperties.AppVersion đã được thêm để lấy thuộc tính tài liệu tích hợp đại diện cho số phiên bản nội bộ mà Microsoft sử dụng trong quá trình phát triển.
#### **Thuộc tính BlackWhiteMode đã được thêm vào IShape và Shape**
Thuộc tính BlackWhiteMode đã được thêm vào IShape và Shape.

Thuộc tính này xác định cách một hình dạng sẽ được hiển thị trong chế độ đen‑trắng.

|**Giá trị**|**Ý nghĩa**|
| :- | :- |
|Color|Hiển thị với màu bình thường|
|Automatic|Hiển thị với màu tự động|
|Gray|Hiển thị với màu xám|
|LightGray|Hiển thị với màu xám nhạt|
|InverseGray|Hiển thị với màu xám đảo ngược|
|GrayWhite|Hiển thị với màu xám và trắng|
|BlackGray|Hiển thị với màu đen và xám|
|BlackWhite|Hiển thị với màu đen và trắng|
|Black|Chỉ hiển thị với màu đen|
|White|Hiển thị với màu trắng|
|Hidden|Không hiển thị|
|NotDefined|Có nghĩa là thuộc tính chưa được đặt|

#### **Thuộc tính ISlide.NotesSlideManager đã được thêm. Thuộc tính ISlide.NotesSlide và phương thức ISlide.AddNotesSlide() đã được đánh dấu là Obsolete.**
Các thành viên ISlide.NotesSlide, ISlide.AddNotesSlide() đã được đánh dấu là Obsolete. Sử dụng thuộc tính mới ISlide.NotesSlideManager thay thế.

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("sample.pptx"))
{
    ISlide slide = pres.Slides[0];

    INotesSlide notes;

    // notes = slide.AddNotesSlide(); - đã lỗi thời
    // notes = slide.NotesSlide; - đã lỗi thời

    notes = slide.NotesSlideManager.NotesSlide;
    notes = slide.NotesSlideManager.AddNotesSlide();

    slide.NotesSlideManager.RemoveNotesSlide();
}
```