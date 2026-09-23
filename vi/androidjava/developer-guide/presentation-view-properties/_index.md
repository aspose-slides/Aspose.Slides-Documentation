---
title: Truy xuất và Cập nhật Thuộc tính Xem Bản trình chiếu trên Android
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/androidjava/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính bộ chia dọc
- xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides for Android via Java để tùy chỉnh định dạng slide PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung bên và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức[IViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.

[INormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties),[INormalViewRestoredProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties) các giao diện và các khai thác của chúng, enum[SplitterBarStateType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType) đã được thêm.

## **Về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Các phương thức[getShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getShowOutlineIcons--) và[setShowOutlineIcons](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức[getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getSnapVerticalSplitter--) và[setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu bộ chia dọc có nên chuyển sang trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Thuộc tính[getPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getPreferSingleView--) và[setPreferSingleView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#setPreferSingleView-boolean-) chỉ định liệu người dùng muốn xem một vùng nội dung đơn toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức[getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và[getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) chỉ định trạng thái mà thanh chia dọc hoặc ngang nên được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là:[SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Minimized),[SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Maximized) và[SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored).

Các phương thức[getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--) và[getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--) chỉ định kích thước của vùng slide phía trên hoặc bên của chế độ xem bình thường, khi giá trị[SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SplitterBarStateType#Restored) được áp dụng cho[getVerticalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getVerticalBarState--) và[getHorizontalBarState](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Chỉ định kích thước của vùng slide (độ rộng khi là con của[getRestoredTop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredTop--), chiều cao khi là con của[getRestoredLeft](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewProperties#getRestoredLeft--)) của chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ cũng không phải phóng đại).

Phương thức[getDimensionSize](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getDimensionSize--) chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức[getAutoAdjust](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/INormalViewRestoredProperties#getAutoAdjust--) chỉ định liệu kích thước của vùng nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ được đưa ra bên dưới cho thấy cách truy cập các thuộc tính[ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```java
import com.aspose.slides.*;

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

## **Đặt giá trị phóng đại mặc định**

{{% alert color="info" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ đặt giá trị phóng đại mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập[ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của một bản trình chiếu. [getSlideViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getSlideViewProperties--) cũng như[getNotesViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties#getNotesViewProperties--) có thể được đặt bằng mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ về cách đặt[View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để thiết lập các thuộc tính xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Đặt[View Properties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ViewProperties) của[Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
1. Ghi bản trình chiếu dưới dạng tệp[PPTX](https://docs.fileformat.com/presentation/pptx/).Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng đại cho chế độ xem slide cũng như chế độ xem ghi chú.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    // Đặt các thuộc tính xem cho bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem ghi chú 

    presentation.save("Zoom_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt khoảng cách lưới**

Sử dụng[Presentation.getViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) để truy cập các cài đặt xem trên toàn bộ bản trình chiếu. Các phương thức[IViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#getGridSpacing--) và[IViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không chỉ một slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo tài liệu API.

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

Lưới khác với [drawing guides](/slides/vi/androidjava/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng cách đều, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là trợ giúp chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình chỉnh sửa sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình chỉnh sửa.

## **Hiển thị hoặc ẩn bình luận khi mở bản trình chiếu**

Sử dụng[Presentation.getViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getViewProperties--) để truy cập các cài đặt xem trên toàn bộ bản trình chiếu. Sử dụng[IViewProperties.getShowComments](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#getShowComments--) và[IViewProperties.setShowComments](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) để đọc hoặc thay đổi tùy chọn lưu trữ về việc có hiển thị bình luận khi bản trình chiếu mở trong PowerPoint hoặc trình chỉnh sửa tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn xem đã lưu. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận vẫn bảo toàn nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Xem[Presentation Comments](/slides/vi/androidjava/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có có chứa bình luận. Nó in ra tùy chọn hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một tệp PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng sử dụng[IViewProperties.setLastView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) với[ViewType.SlideView](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewtype/#SlideView) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

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

Cài đặt này không quyết định liệu bình luận có được đưa vào các xuất PDF, HTML, hình ảnh, ghi chú hoặc tài liệu phát tay hay không. Hãy cấu hình các tùy chọn xuất cụ thể riêng biệt.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa kiểm soát việc lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có làm thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các thiết lập độc lập. Xóa hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các thiết lập xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

Các thiết lập xem được định nghĩa ở cấp độ bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getNormalViewProperties--)/[Slide View](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/#getSlideViewProperties--)), không phải theo phần, vì vậy một tập tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái xem khác nhau cho các người dùng khác nhau không?**

Không. Các thiết lập được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính xem.

**Tôi có thể chuẩn bị một mẫu với các Thuộc tính Xem được định trước để các bản trình chiếu mới mở cùng cách không?**

Có. Vì các thuộc tính xem được lưu ở cấp độ bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình xem ban đầu.