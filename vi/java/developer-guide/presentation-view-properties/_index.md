---
title: Truy xuất và Cập nhật Thuộc tính Xem Bản trình chiếu trong Java
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/java/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- tự động gọn thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng đại mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides cho Java để tùy chỉnh định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức phóng đại và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như lần cuối cùng bản trình chiếu được lưu.

Phương thức [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties) và các thành phần con của chúng, [SplitterBarStateType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType) enum đã được bổ sung.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định xem ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định xem thanh chia dọc có nên tự động thu gọn khi vùng bên đủ nhỏ hay không.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) chỉ định người dùng có muốn xem một vùng nội dung duy nhất chiếm toàn bộ cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn bộ cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) xác định kích thước của vùng slide phía trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) của chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu gọn cũng không tối đa).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Khôi phục các thuộc tính xem của bản trình chiếu
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá trị Phóng đại Mặc định**

{{% alert color="primary" %}} 

Aspose.Slides for Java hiện hỗ trợ việc đặt giá trị phóng đại mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng đại đã được thiết lập sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của một bản trình chiếu. [getSlideViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) cũng như [getNotesViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) có thể được thiết lập thông qua mã. Trong chủ đề này, chúng tôi sẽ trình bày một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng đại cho chế độ xem slide cũng như chế độ xem ghi chú.

```java
Presentation presentation = new Presentation();
try {
    // Thiết lập các thuộc tính xem của bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị phóng đại tính bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị phóng đại tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[Cài đặt chế độ xem](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) được định nghĩa ở mức độ bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp chứa một bộ thuộc tính chế độ xem duy nhất.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định trước để các bản trình chiếu mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) được lưu ở mức độ bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.