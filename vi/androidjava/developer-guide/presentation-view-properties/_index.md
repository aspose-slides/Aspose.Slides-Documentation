---
title: Khôi phục và Cập nhật Thuộc tính hiển thị Bản trình chiếu trên Android
linktitle: Thuộc tính hiển thị
type: docs
weight: 80
url: /vi/androidjava/presentation-view-properties/
keywords: 
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh tách dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho Android via Java để tùy chỉnh định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung bên và một vùng nội dung bên dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái hiển thị vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.  

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties) và các lớp con của chúng, cùng enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType) đã được bổ sung.

## **Về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh tách dọc có tự động thu nhỏ khi vùng bên đủ nhỏ hay không.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) chỉ định liệu người dùng muốn xem một vùng nội dung duy nhất trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh tách ngang hoặc dọc phải được hiển thị. Thanh tách ngang tách bản trình chiếu khỏi vùng nội dung bên dưới, thanh tách dọc tách bản trình chiếu khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) chỉ định kích thước của vùng bản trình chiếu trên hoặc bên khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng bản trình chiếu (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng bản trình chiếu (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh để bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách bạn có thể truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```java
Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Khôi phục các thuộc tính hiển thị của bản trình chiếu
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá trị Phóng to Mặc định**

{{% alert color="primary" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ việc thiết lập giá trị phóng to mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của một bản trình chiếu. Cả [getSlideViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) có thể được thiết lập qua mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách thiết lập [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}} 

Để thiết lập các thuộc tính hiển thị, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Thiết lập [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Ghi bản trình chiếu thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho chế độ xem bản trình chiếu cũng như chế độ xem ghi chú.

```java
Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính hiển thị của bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị phóng to bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị phóng to bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể thiết lập các cài đặt hiển thị khác nhau cho các phần khác nhau của bản trình chiếu không?**

[View settings](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được định nghĩa ở mức độ bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái hiển thị khác nhau cho từng người dùng không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính hiển thị.

**Tôi có thể chuẩn bị một mẫu với View Properties đã được định trước để các bản trình chiếu mới mở theo cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được lưu ở mức độ bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu với cùng cấu hình hiển thị ban đầu.