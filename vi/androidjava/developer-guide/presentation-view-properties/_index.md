---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trên Android
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/androidjava/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung dàn ý
- biểu tượng dàn ý
- bộ chia dọc tự dính
- chế độ xem đơn
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
description: "Sử dụng Aspose.Slides cho Android qua Java để cấu hình bố cục chế độ xem bình thường, thu phóng slide và ghi chú, khoảng cách lưới và khả năng hiển thị bình luận trong các bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide xuất hiện giữa một khung bên cho hình thu nhỏ hoặc dàn ý và một khung ghi chú ở phía dưới. Aspose.Slides cho Android qua Java cung cấp các tùy chọn chỉnh sửa đã lưu của bản trình bày thông qua [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--). Các tùy chọn này bao gồm bố cục khung, mức thu phóng, khoảng cách lưới và khả năng hiển thị bình luận.

## **Về INormalViewProperties**

Sử dụng [getNormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNormalViewProperties--) để truy cập giao diện [INormalViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) điều khiển việc các biểu tượng có xuất hiện bên cạnh tiêu đề slide trong dàn ý hay không. [setSnapVerticalSplitter](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setSnapVerticalSplitter-boolean-) cho phép khung bên dính vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [setPreferSingleView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setPreferSingleView-boolean-) chỉ ra ưu tiên hiển thị một khung duy nhất trong toàn bộ cửa sổ.

[setVerticalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setVerticalBarState-int-) điều khiển bộ chia giữa khung bên và slide. [setHorizontalBarState](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setHorizontalBarState-int-) điều khiển bộ chia phía trên khung ghi chú. Cả hai chấp nhận một giá trị của [SplitterBarStateType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized`, hoặc `Restored`.

## **Về việc khôi phục INormalViewProperties**

Khi một bộ chia được khôi phục, [getRestoredLeft](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredLeft--) cung cấp kích thước đã lưu của khung bên và [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) cung cấp kích thước đã lưu của khu vực slide phía trên. Cả hai đều cung cấp [INormalViewRestoredProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/). Phương thức [setDimensionSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setDimensionSize-float-) của nó chấp nhận phần trăm từ 0 đến 100, và [setAutoAdjust](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewrestoredproperties/#setAutoAdjust-boolean-) điều khiển việc trình chỉnh sửa tự điều chỉnh kích thước khi cửa sổ được thay đổi kích thước.

Ví dụ này cập nhật một bản trình bày hiện có. Nó khôi phục bộ chia ngang, đặt kích thước trả về bởi [getRestoredTop](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#getRestoredTop--) thành 80% với việc tự động điều chỉnh được bật, và phóng đại bộ chia dọc. Nó cũng gọi [setShowOutlineIcons](https://reference.aspose.com/slides/androidjava/com.aspose.slides/inormalviewproperties/#setShowOutlineIcons-boolean-) để hiển thị các biểu tượng trong chế độ xem dàn ý.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    INormalViewProperties normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(SplitterBarStateType.Restored);
    normalView.setVerticalBarState(SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Đặt giá trị thu phóng mặc định**

[getSlideViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#getNotesViewProperties--) lưu các cài đặt thu phóng độc lập cho trình chỉnh sửa. Các cài đặt này không ảnh hưởng đến kích thước slide, việc phát trình chiếu, hoặc độ phân giải xuất hình ảnh.

Ví dụ này mở một bản trình bày hiện có và gọi [setVariableScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setVariableScale-boolean-) để vừa khít slide với cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt việc thu phóng tự động và gọi [setScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icommonslideviewproperties/#setScale-int-) để đặt mức thu phóng cố định 80%.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
## **Đặt khoảng cách lưới**

[setGridSpacing](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setGridSpacing-float-) đặt khoảng cách giữa các đường lưới chỉnh sửa trong toàn bộ bản trình bày. Nó nhận một giá trị dương tính bằng điểm, với 72 điểm mỗi inch. Ví dụ này in ra khoảng cách hiện tại trong một bản trình bày hiện có và lưu một lưới một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("demo.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18f);

    presentation.save("grid-spacing.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưới lặp lại ở một khoảng cách cố định. [Drawing guides](/slides/vi/androidjava/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình chỉnh sửa hiển thị chúng. Các buổi trình chiếu và xuất ra PDF, hình ảnh, hoặc SVG sẽ bỏ qua chúng.

## **Hiển thị hoặc ẩn bình luận khi mở bản trình bày**

[setShowComments](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setShowComments-byte-) lưu một tùy chọn mà các trình chỉnh sửa tương thích sử dụng khi mở bản trình bày. Đối với một bản trình bày hiện có có bình luận, ví dụ này in ra cài đặt hiện tại và lưu một bản sao với bình luận ẩn. Nó cũng gọi [setLastView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iviewproperties/#setLastView-int-) với [ViewType.SlideView](https://reference.aspose.com/slides/androidjava/com.aspose.slides/viewtype/#SlideView) để bản sao mở ở chế độ xem slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("comments.pptx");
try {
    IViewProperties viewProperties = presentation.getViewProperties();
    System.out.println("Current comment visibility: " + viewProperties.getShowComments());

    viewProperties.setShowComments(NullableBool.False);
    viewProperties.setLastView(ViewType.SlideView);

    presentation.save("comments-hidden.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc ẩn bình luận giữ lại nội dung, tác giả, vị trí, câu trả lời và trạng thái của chúng. Để thay đổi chính các bình luận, xem [Presentation Comments](/slides/vi/androidjava/presentation-comments/). Cài đặt xuất kiểm soát việc bình luận có xuất hiện trong PDF, HTML, hình ảnh, ghi chú, hoặc tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới lại bị ẩn khi tôi mở lại bản trình bày?**

Bản trình bày lưu khoảng cách lưới. Để xem lưới, bật tính năng hiển thị lưới trong trình chỉnh sửa.

**Việc xoá hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Thêm, di chuyển hoặc xoá một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của một bản trình bày có thể có cài đặt xem khác nhau không?**

Không. [Presentation.getViewProperties](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getViewProperties--) áp dụng cho toàn bộ bản trình bày.

**Tôi có thể lưu các cài đặt xem khác nhau cho các người dùng khác nhau không?**

Tệp chỉ lưu một bộ thuộc tính xem cho mọi người. Trình chỉnh sửa cũng có thể áp dụng các tùy chọn cục bộ của người dùng.

**Tôi có thể lưu cài đặt xem trong mẫu không?**

Có. Các bản trình bày được tạo từ mẫu sẽ kế thừa các cài đặt xem đã lưu của nó.