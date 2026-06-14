---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bài thuyết trình trong JavaScript
linktitle: Thuộc tính hiển thị
type: docs
weight: 80
url: /vi/nodejs-java/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung dàn bài
- biểu tượng dàn bài
- bắt dọc thanh chia
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng đại mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js thông qua các thuộc tính hiển thị Java để tùy chỉnh định dạng slide PPT, PPTX và ODP—điều chỉnh bố cục, mức phóng đại và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bài thuyết trình được lưu lần cuối.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bài thuyết trình.

[NormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties) lớp và các lớp con của nó, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType) đã được thêm.

## **Về NormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung dàn bài trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh chia dọc có nên tự động thu gọn khi vùng bên đủ nhỏ hay không.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean--) chỉ định liệu người dùng có ưu tiên xem một vùng nội dung duy nhất toàn màn hình so với chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu được bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) chỉ định trạng thái mà thanh chia ngang hoặc dọc nên được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục NormalViewProperties**

Chỉ định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) của chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không thu nhỏ cũng không phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) cho một bài thuyết trình.

```javascript

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Khôi phục các thuộc tính hiển thị của bài thuyết trình
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá trị Phóng đại Mặc định**

{{% alert color="primary" %}} 

Aspose.Slides cho Node.js qua Java hiện đã hỗ trợ việc đặt giá trị phóng đại mặc định cho bài thuyết trình sao cho khi mở bài thuyết trình, mức phóng đại đã được thiết lập. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của một bài thuyết trình. Cả [getSlideViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) có thể được đặt bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Ghi bài thuyết trình dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/). Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng đại cho chế độ xem slide cũng như chế độ xem ghi chú.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    // Đặt các thuộc tính hiển thị của bài thuyết trình
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị phóng đại tính bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị phóng đại tính bằng phần trăm cho chế độ xem ghi chú
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của một bài thuyết trình không?**

Các [cài đặt chế độ xem](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được xác định ở mức độ của bài thuyết trình ([Normal View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), không phải theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định sẵn để các bài thuyết trình mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức độ của bài thuyết trình, bạn có thể nhúng chúng vào một mẫu và tạo các tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.