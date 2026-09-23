---
title: Lấy và Cập nhật Thuộc tính Chế độ xem Bài thuyết trình trong Java
linktitle: Thuộc tính xem
type: docs
weight: 80
url: /vi/java/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung dàn ý
- biểu tượng dàn ý
- định vị thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng đại mặc định
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá thuộc tính chế độ xem của Aspose.Slides cho Java để tùy chỉnh định dạng slide PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: chính slide, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem vẫn ở trạng thái giống như khi bài thuyết trình được lưu lần cuối.

Phương thức [IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bài thuyết trình. 

Các giao diện [INormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties), [INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties) và các lớp kế thừa của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType) đã được thêm vào.

## **Giới thiệu về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung dàn ý trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh chia dọc có nên khớp vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean--) chỉ định liệu người dùng có muốn xem một vùng nội dung duy nhất trên toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh chia ngang hoặc dọc sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--) xác định kích thước của vùng slide trên hoặc phía bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Xác định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredTop--), độ cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ cũng không phải phóng to). 

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, độ cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/java/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ được đưa dưới đây cho thấy cách bạn có thể truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bài thuyết trình.

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(SplitterBarStateType.Maximized);
    
    // Khôi phục các thuộc tính chế độ xem của bài thuyết trình
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);

    pres.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt giá trị phóng đại mặc định**

{{% alert color="info" %}} 

Aspose.Slides for Java hiện hỗ trợ việc đặt giá trị phóng đại mặc định cho bài thuyết trình sao cho khi mở bài thuyết trình, mức phóng đại đã được đặt. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của một bài thuyết trình. [getSlideViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getSlideViewProperties--) cũng như [getNotesViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties#getNotesViewProperties--) có thể được đặt bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
2. Đặt [View Properties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) .
3. Ghi bài thuyết trình thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .
   Trong ví dụ được đưa dưới đây, chúng tôi đã đặt giá trị phóng đại cho chế độ xem slide cũng như chế độ xem ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính chế độ xem của bài thuyết trình
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt khoảng cách lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) để truy cập cài đặt chế độ xem toàn bài thuyết trình. Các phương thức [IViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#getGridSpacing--) và [IViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bài thuyết trình, không phải cho một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ dưới đây mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

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

Lưới khác với [hướng dẫn vẽ](/slides/vi/java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị dưới dạng nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Hiển thị hoặc Ẩn bình luận khi mở bài thuyết trình**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getViewProperties--) để truy cập cài đặt chế độ xem toàn bài thuyết trình. Sử dụng [IViewProperties.getShowComments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#getShowComments--) và [IViewProperties.setShowComments](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#setShowComments-byte-) để đọc hoặc thay đổi tùy chọn lưu trữ về việc có nên hiển thị bình luận khi bài thuyết trình mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn chế độ xem đã lưu. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận giữ nguyên nội dung, tác giả, vị trí, trả lời và trạng thái của chúng. Xem [Bình luận bài thuyết trình](/slides/vi/java/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ dưới đây yêu cầu một tệp `comments.pptx` hiện có có chứa bình luận. Nó in ra cài đặt hiển thị hiện tại, yêu cầu ẩn bình luận, và lưu một tệp PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng sử dụng [IViewProperties.setLastView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iviewproperties/#setLastView-int-) cùng với [ViewType.SlideView](https://reference.aspose.com/slides/vi/java/com.aspose.slides/viewtype/#SlideView) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

```java
import com.aspose.slides.NullableBool;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ViewType;

Presentation presentation = new Presentation("comments.pptx");
try {
    byte showComments = presentation.getViewProperties().getShowComments();
    System.out.println("Current comment visibility: " + showComments);

    presentation.getViewProperties().setShowComments(NullableBool.False);
    presentation.getViewProperties().setLastView(ViewType.SlideView);
    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cài đặt này không quyết định liệu bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu phát tay hay không. Hãy cấu hình các tùy chọn xuất riêng biệt cho từng định dạng.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bài thuyết trình?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định việc lưới có được hiển thị hay không. Hãy kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là những cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bài thuyết trình không?**

[Cài đặt chế độ xem](/slides/vi/java/slides/vi/presentation/#getViewProperties--) được định nghĩa ở mức độ bài thuyết trình ([Chế độ xem bình thường](/slides/vi/java/slides/vi/viewproperties/#getNormalViewProperties--)/[Chế độ xem slide](/slides/vi/java/slides/vi/viewproperties/#getSlideViewProperties--)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định nghĩa trước các trạng thái chế độ xem khác nhau cho từng người dùng không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các Thuộc tính chế độ xem đã định nghĩa sẵn để các bài thuyết trình mới mở cùng cách không?**

Có. Vì [thuộc tính chế độ xem](/slides/vi/java/slides/vi/presentation/#getViewProperties--) được lưu ở mức độ bài thuyết trình, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.