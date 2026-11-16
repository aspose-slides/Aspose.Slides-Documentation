---
title: Truy xuất và Cập nhật Thuộc tính Hiển thị Bản trình chiếu trong JavaScript
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/nodejs-java/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung dàn ý
- biểu tượng dàn ý
- gắn bộ chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho Node.js thông qua Java để cấu hình bố cục chế độ xem bình thường, thu phóng slide và ghi chú, khoảng cách lưới và hiển thị bình luận trong bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide xuất hiện giữa một khung bên cho ảnh thu nhỏ hoặc dàn ý và một khung ghi chú ở phía dưới. Aspose.Slides cho Node.js thông qua Java cung cấp các tùy chọn chỉnh sửa đã lưu của bản trình chiếu thông qua [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties). Những tùy chọn này bao gồm bố cục khung, mức thu phóng, khoảng cách lưới và hiển thị bình luận.

## **Về NormalViewProperties**

Sử dụng [getNormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNormalViewProperties) để truy cập lớp [NormalViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) điều khiển việc có hiển thị biểu tượng bên cạnh tiêu đề slide trong dàn ý hay không. [setSnapVerticalSplitter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setSnapVerticalSplitter) cho phép khung bên bám vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [setPreferSingleView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setPreferSingleView) cho biết ưu tiên hiển thị một khung trong toàn bộ cửa sổ.

[setVerticalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setVerticalBarState) điều khiển thanh ngăn cách giữa khung bên và slide. [setHorizontalBarState](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setHorizontalBarState) điều khiển thanh ngăn cách phía trên khung ghi chú. Cả hai chấp nhận một giá trị [SplitterBarStateType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized` hoặc `Restored`.

## **Về việc khôi phục NormalViewProperties**

Khi một thanh ngăn cách được khôi phục, [getRestoredLeft](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredLeft) cung cấp kích thước đã lưu của khung bên và [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) cung cấp kích thước đã lưu của vùng slide trên cùng. Cả hai đều phơi bày [NormalViewRestoredProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/). Phương thức [setDimensionSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setDimensionSize) của nó chấp nhận một phần trăm từ 0 đến 100, và [setAutoAdjust](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewrestoredproperties/#setAutoAdjust) kiểm soát việc trình chỉnh sửa tự động điều chỉnh kích thước khi cửa sổ được thay đổi kích thước.

Ví dụ này cập nhật một bản trình chiếu hiện có. Nó khôi phục thanh ngang, đặt kích thước trả về bởi [getRestoredTop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#getRestoredTop) thành 80% với chế độ tự động điều chỉnh được bật, và mở rộng tối đa thanh dọc. Nó cũng gọi [setShowOutlineIcons](https://reference.aspose.com/slides/nodejs-java/aspose.slides/normalviewproperties/#setShowOutlineIcons) để hiển thị biểu tượng trong chế độ xem dàn ý.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const normalView = presentation.getViewProperties().getNormalViewProperties();
    normalView.setHorizontalBarState(slides.SplitterBarStateType.Restored);
    normalView.setVerticalBarState(slides.SplitterBarStateType.Maximized);
    normalView.getRestoredTop().setAutoAdjust(true);
    normalView.getRestoredTop().setDimensionSize(80);
    normalView.setShowOutlineIcons(true);

    presentation.save("presentation_normal_view_state.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt giá trị thu phóng mặc định**

[getSlideViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getSlideViewProperties) và [getNotesViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#getNotesViewProperties) lưu các cài đặt thu phóng độc lập cho trình chỉnh sửa. Những cài đặt này không ảnh hưởng tới kích thước slide, phát trình chiếu, hay độ phân giải xuất hình ảnh.

Ví dụ này mở một bản trình chiếu hiện có và gọi [setVariableScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setVariableScale) để vừa slide vào cửa sổ chỉnh sửa. Đối với trang ghi chú, nó tắt chế độ tự động thu phóng và gọi [setScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/commonslideviewproperties/#setScale) để đặt mức thu phóng cố định 80%.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    viewProperties.getSlideViewProperties().setVariableScale(true);
    viewProperties.getNotesViewProperties().setVariableScale(false);
    viewProperties.getNotesViewProperties().setScale(80);

    presentation.save("zoom.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt khoảng cách lưới**

[setGridSpacing](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setGridSpacing) đặt khoảng cách giữa các đường lưới chỉnh sửa trên toàn bộ bản trình chiếu. Nó nhận một giá trị dương bằng điểm, với 72 điểm mỗi inch. Ví dụ này in ra khoảng cách hiện tại trong một bản trình chiếu hiện có và lưu một lưới một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current grid spacing: " + viewProperties.getGridSpacing() + " points");

    viewProperties.setGridSpacing(18);

    presentation.save("grid-spacing.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưới lặp lại theo một khoảng cố định. [Hướng dẫn vẽ](/slides/vi/nodejs-java/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình chỉnh sửa hiển thị chúng. Các buổi trình chiếu và xuất ra PDF, hình ảnh hoặc SVG sẽ không bao gồm chúng.

## **Hiển thị hoặc ẩn bình luận khi mở bản trình chiếu**

[setShowComments](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setShowComments) lưu một tùy chọn mà các trình chỉnh sửa tương thích sử dụng khi mở bản trình chiếu. Đối với một bản trình chiếu hiện có có bình luận, ví dụ này in ra cài đặt hiện tại và lưu một bản sao với bình luận ẩn. Nó cũng gọi [setLastView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewproperties/#setLastView) với [ViewType.SlideView](https://reference.aspose.com/slides/nodejs-java/aspose.slides/viewtype/#SlideView) để bản sao mở trong chế độ xem slide.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const viewProperties = presentation.getViewProperties();
    console.log("Current comment visibility: " + viewProperties.getShowComments());

    const hideComments = java.newByte(slides.NullableBool.False);
    viewProperties.setShowComments(hideComments);
    viewProperties.setLastView(slides.ViewType.SlideView);

    presentation.save("comments-hidden.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Việc ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Để thay đổi nội dung bình luận, xem [Bình luận trong Presentation](/slides/vi/nodejs-java/presentation-comments/). Cài đặt xuất quyết định việc bình luận có xuất hiện trong PDF, HTML, hình ảnh, ghi chú hay tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới lại bị ẩn khi tôi mở lại bản trình chiếu?**

Bản trình chiếu lưu khoảng cách lưới. Để thấy lưới, bật hiển thị lưới trong trình chỉnh sửa.

**Việc xóa hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của bản trình chiếu có thể có các cài đặt hiển thị khác nhau không?**

Không. [Presentation.getViewProperties](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getViewProperties) áp dụng cho toàn bộ bản trình chiếu.

**Tôi có thể lưu các cài đặt hiển thị riêng cho từng người dùng không?**

Tệp chỉ lưu một bộ thuộc tính hiển thị cho tất cả mọi người. Một trình chỉnh sửa có thể áp dụng các tùy chọn cục bộ của người dùng.

**Tôi có thể lưu cài đặt hiển thị trong mẫu không?**

Có. Các bản trình chiếu tạo từ mẫu sẽ kế thừa các cài đặt hiển thị đã lưu.