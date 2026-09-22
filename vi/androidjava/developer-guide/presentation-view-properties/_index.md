---
title: "Lấy và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trên Android"
linktitle: "Thuộc tính Hiển thị"
type: docs
weight: 80
url: /vi/androidjava/presentation-view-properties/
keywords:
- "thuộc tính hiển thị"
- "chế độ xem bình thường"
- "nội dung đề cương"
- "biểu tượng đề cương"
- "đặt chốt thanh chia dọc"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự động điều chỉnh"
- "thu phóng mặc định"
- "PowerPoint"
- "OpenDocument"
- "bản trình chiếu"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Khám phá các thuộc tính hiển thị của Aspose.Slides cho Android via Java để tùy chỉnh các định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.  

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties) và các lớp kế thừa của chúng, cùng enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType) đã được bổ sung.

## **Về INormalViewProperties**

Đại diện cho các thuộc tính chế độ xem bình thường.

Phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường.

Phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh chia dọc có nên khớp vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) chỉ định liệu người dùng muốn xem một vùng nội dung duy nhất trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh chia ngang hoặc dọc sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, còn thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị khả dụng là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) xác định kích thước của vùng slide bên hoặc trên trong chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về Restoring INormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước phục hồi thay đổi (không phải thu nhỏ hay phóng to).  

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).  

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên tự động điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```java
import com.aspose.slides.*;

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

## **Đặt Giá Trị Thu Phóng Mặc Định**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình chiếu sao cho khi bản trình chiếu được mở, mức thu phóng đã được thiết lập sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của một bản trình chiếu. Cả [getSlideViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) đều có thể được thiết lập theo chương trình. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách thiết lập [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) trong Aspose.Slides.  

{{% /alert %}} 

Để thiết lập các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Ghi bản trình chiếu ra tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã thiết lập giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính hiển thị của bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng dưới dạng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng dưới dạng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) để truy cập các cài đặt chế độ xem toàn bản trình chiếu. Các phương thức [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) và [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được tính bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách thành một phần tư inch và lưu kết quả.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("demo.pptx");
try {
    float gridSpacing = presentation.getViewProperties().getGridSpacing();
    System.out.println("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18f);
    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưới khác với [drawing guides](/slides/vi/androidjava/drawing-guides/). Khoảng cách lưới kiểm soát một độ lệch đều đặn, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không bảo đảm rằng một trình chỉnh sửa sẽ hiển thị lưới: tính hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Câu Hỏi Thường Gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**  

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định liệu lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**  

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**  

[View settings](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không phải theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**  

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích người dùng, nhưng tệp tự nó chỉ chứa một tập hợp thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định nghĩa sẵn để các bản trình chiếu mới mở cùng cách không?**  

Có. Vì [view properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cấu hình chế độ xem ban đầu giống nhau.