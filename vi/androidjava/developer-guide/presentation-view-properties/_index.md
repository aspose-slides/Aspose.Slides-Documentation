---
title: Truy xuất và Cập nhật Thuộc tính Chế độ xem Bản trình bày trên Android
linktitle: Thuộc tính xem
type: docs
weight: 80
url: /vi/androidjava/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- Android
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính chế độ xem của Aspose.Slides cho Android qua Java để tùy chỉnh các định dạng PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung này cho phép ứng dụng lưu trạng thái chế độ xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như lúc bản trình bày được lưu lần cuối.

Method [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm để cung cấp quyền truy cập tới các thuộc tính chế độ xem bình thường của bản trình bày. 

[INormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties) interfaces và các thành phần kế thừa, [SplitterBarStateType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType) enum đã được thêm.

## **Về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Methods [getShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) xác định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Methods [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) xác định liệu thanh chia dọc có nên “bắt” vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Property [getPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) xác định liệu người dùng muốn xem một vùng nội dung duy nhất toàn cửa sổ thay vì chế độ xem bình thường chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Methods [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh chia ngang hoặc dọc sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Methods [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) xác định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng to). 

Method [getDimensionSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Method [getAutoAdjust](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ được đưa ra bên dưới cho thấy cách truy cập thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình bày.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Khôi phục các thuộc tính chế độ xem của bản trình bày
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá Trị Thu Phóng Mặc Định**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình bày sao cho khi mở bản trình bày, thu phóng đã được thiết lập sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của một bản trình bày. Cả [getSlideViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) đều có thể được cấu hình bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính chế độ xem của bản trình bày
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

### Tôi có thể đặt các cài đặt xem khác nhau cho các phần khác nhau của bản trình bày không?

[Cài đặt xem](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được định nghĩa ở mức độ bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn tài liệu khi mở.

### Tôi có thể định sẵn các trạng thái xem khác nhau cho các người dùng khác nhau không?

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

### Tôi có thể chuẩn bị một mẫu với các thuộc tính chế độ xem được định trước để các bản trình bày mới mở cùng cách không?

Có. Vì [thuộc tính chế độ xem](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được lưu ở mức độ bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cấu hình chế độ xem ban đầu giống nhau.