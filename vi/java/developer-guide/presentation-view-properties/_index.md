---
title: Truy xuất và Cập nhật Thuộc tính Chế độ xem Bản trình chiếu trong Java
linktitle: Thuộc tính Chế độ xem
type: docs
weight: 80
url: /vi/java/presentation-view-properties/
keywords:
- thuộc tính chế độ xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính chế độ xem của Aspose.Slides for Java để tùy chỉnh định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties) và các lớp con của chúng, cùng với enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType) đã được thêm.

## **Về INormalViewProperties**

Đại diện cho thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh chia dọc có tự động chuyển sang trạng thái thu gọn khi vùng bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) chỉ định liệu người dùng muốn xem một vùng nội dung duy nhất toàn màn hình thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) chỉ định trạng thái mà thanh chia ngang hoặc dọc sẽ được hiển thị. Thanh chia ngang tách bản trình chiếu khỏi vùng nội dung phía dưới, thanh chia dọc tách bản trình chiếu khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu gọn hay phóng đại).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Khôi phục các thuộc tính chế độ xem của bản trình chiếu
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá Trị Phóng To Mặc Định**

{{% alert color="info" %}} 

Aspose.Slides for Java hiện hỗ trợ thiết lập giá trị phóng to mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của một bản trình chiếu. Cả [getSlideViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) đều có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
1. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) . Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho chế độ xem slide và chế độ xem ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính chế độ xem của bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị phóng to dưới dạng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị phóng to dưới dạng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) để truy cập các cài đặt chế độ xem toàn bộ bản trình chiếu. Các phương thức [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#getGridSpacing--) và [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

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

Lưới khác với [drawing guides](/slides/vi/java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng cách đều, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng biệt. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định liệu lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Xóa các hướng dẫn vẽ có làm thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[Các cài đặt chế độ xem](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) được định nghĩa ở mức độ bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tuân theo sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định trước để các bản trình chiếu mới mở ra cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) được lưu ở mức độ bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu với cấu hình chế độ xem ban đầu giống nhau.