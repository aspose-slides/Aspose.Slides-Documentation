---
title: Lấy và Cập nhật Thuộc tính Xem Bản trình chiếu trong PHP
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/php-java/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung dàn ý
- biểu tượng dàn ý
- kẹp dọc tự động
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Sử dụng Aspose.Slides cho PHP thông qua Java để cấu hình bố cục chế độ xem bình thường, mức thu phóng slide và ghi chú, khoảng cách lưới và hiển thị bình luận trong các bản trình chiếu PowerPoint."
---
## **Giới thiệu**

Trong chế độ xem bình thường của PowerPoint, slide xuất hiện giữa một khung bên cho các thumbnail hoặc dàn ý và một khung ghi chú ở phía dưới. Aspose.Slides cho PHP thông qua Java cung cấp các tùy chọn chỉnh sửa đã lưu của bản trình chiếu qua [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/). Các tùy chọn này bao gồm bố cục khung, mức thu phóng, khoảng cách lưới và hiển thị bình luận.

## **Về NormalViewProperties**

Sử dụng [getNormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnormalviewproperties/) để truy cập lớp [NormalViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/). [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) kiểm soát việc có hiển thị biểu tượng bên cạnh tiêu đề slide trong dàn ý hay không. [setSnapVerticalSplitter](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setsnapverticalsplitter/) cho phép khung bên dính vào trạng thái thu nhỏ khi người dùng thu hẹp nó. [setPreferSingleView](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setprefersingleview/) cho biết ưu tiên hiển thị một khung trong toàn bộ cửa sổ.

[setVerticalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setverticalbarstate/) kiểm soát phần tách giữa khung bên và slide. [setHorizontalBarState](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/sethorizontalbarstate/) kiểm soát phần tách phía trên khung ghi chú. Cả hai đều chấp nhận một giá trị của [SplitterBarStateType](https://reference.aspose.com/slides/php-java/aspose.slides/splitterbarstatetype/) là `Minimized`, `Maximized`, hoặc `Restored`.

## **Về việc khôi phục NormalViewProperties**

Khi một phần tách được khôi phục, [getRestoredLeft](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredleft/) cung cấp kích thước đã lưu của khung bên và [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) cung cấp kích thước đã lưu của khu vực slide phía trên. Cả hai đều hiển thị [NormalViewRestoredProperties](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/). Phương thức [setDimensionSize](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setdimensionsize/) của nó chấp nhận một phần trăm từ 0 đến 100, và [setAutoAdjust](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewrestoredproperties/setautoadjust/) kiểm soát việc trình soạn thảo có điều chỉnh kích thước khi cửa sổ được thay đổi kích thước hay không.

Ví dụ này cập nhật một bản trình chiếu hiện có. Nó khôi phục phần tách ngang, đặt kích thước trả về bởi [getRestoredTop](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/getrestoredtop/) thành 80% với tự động điều chỉnh được bật, và phóng đại phần tách dọc. Nó cũng gọi [setShowOutlineIcons](https://reference.aspose.com/slides/php-java/aspose.slides/normalviewproperties/setshowoutlineicons/) để hiển thị biểu tượng trong chế độ xem dàn ý.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\SplitterBarStateType;

$presentation = new Presentation("demo.pptx");
try {
    $normalView = $presentation->getViewProperties()->getNormalViewProperties();
    $normalView->setHorizontalBarState(SplitterBarStateType::Restored);
    $normalView->setVerticalBarState(SplitterBarStateType::Maximized);
    $normalView->getRestoredTop()->setAutoAdjust(true);
    $normalView->getRestoredTop()->setDimensionSize(80);
    $normalView->setShowOutlineIcons(true);

    $presentation->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt giá trị thu phóng mặc định**

[getSlideViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getslideviewproperties/) và [getNotesViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/getnotesviewproperties/) lưu các cài đặt thu phóng độc lập cho trình soạn thảo. Những cài đặt này không ảnh hưởng tới kích thước slide, việc phát trình chiếu, hoặc độ phân giải khi xuất ảnh.

Ví dụ này mở một bản trình chiếu hiện có và gọi [setVariableScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setvariablescale/) để vừa khít slide với cửa sổ soạn thảo. Đối với trang ghi chú, nó tắt việc thu phóng tự động và gọi [setScale](https://reference.aspose.com/slides/php-java/aspose.slides/commonslideviewproperties/setscale/) để đặt mức thu phóng cố định 80%.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    $viewProperties->getSlideViewProperties()->setVariableScale(true);
    $viewProperties->getNotesViewProperties()->setVariableScale(false);
    $viewProperties->getNotesViewProperties()->setScale(80);

    $presentation->save("zoom.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt khoảng cách lưới**

Phương thức `setGridSpacing` của [ViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/) đặt khoảng cách giữa các đường lưới chỉnh sửa trong toàn bộ bản trình chiếu. Nó nhận một giá trị dương tính bằng điểm, với 72 điểm mỗi inch. Ví dụ này in ra khoảng cách hiện tại trong một bản trình chiếu hiện có và lưu một lưới dài một phần tư inch bằng cách đặt khoảng cách thành 18 điểm.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current grid spacing: " . java_values($viewProperties->getGridSpacing()) . " points" . PHP_EOL;

    $viewProperties->setGridSpacing(18.0);
    
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lưới lặp lại ở một khoảng cách cố định. [Hướng dẫn vẽ](/slides/vi/php-java/drawing-guides/) đánh dấu các vị trí ngang hoặc dọc riêng lẻ. Cả hai đều là công cụ hỗ trợ chỉnh sửa và chỉ xuất hiện trong các trình soạn thảo hiện chúng. Các trình chiếu và xuất ra PDF, ảnh, hoặc SVG sẽ không bao gồm chúng.

## **Hiển thị hoặc Ẩn bình luận khi mở bản trình chiếu**

[setShowComments](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setshowcomments/) lưu một tùy chọn mà các trình soạn thảo tương thích sử dụng khi mở bản trình chiếu. Đối với một bản trình chiếu hiện có có bình luận, ví dụ này in ra cài đặt hiện tại và lưu một bản sao với bình luận bị ẩn. Nó cũng gọi [setLastView](https://reference.aspose.com/slides/php-java/aspose.slides/viewproperties/setlastview/) với [ViewType::SlideView](https://reference.aspose.com/slides/php-java/aspose.slides/viewtype/#SlideView) để bản sao mở ở chế độ xem slide.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $viewProperties = $presentation->getViewProperties();
    echo "Current comment visibility: " . java_values($viewProperties->getShowComments()) . PHP_EOL;

    $viewProperties->setShowComments(NullableBool::False);
    $viewProperties->setLastView(ViewType::SlideView);

    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Việc ẩn bình luận vẫn giữ lại nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Để thay đổi các bình luận, xem [Bình luận Bản trình chiếu](/slides/vi/php-java/presentation-comments/). Các cài đặt xuất kiểm soát việc bình luận có xuất hiện trong PDF, HTML, ảnh, ghi chú hay tài liệu phát tay hay không.

## **Câu hỏi thường gặp**

**Tại sao lưới lại ẩn khi tôi mở lại bản trình chiếu?**  
Bản trình chiếu lưu khoảng cách lưới. Để nhìn thấy lưới, hãy bật tính năng hiển thị lưới trong trình soạn thảo.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**  
Không. Thêm, di chuyển hoặc xóa một hướng dẫn không làm thay đổi khoảng cách lưới.

**Các phần khác nhau của một bản trình chiếu có thể có các cài đặt hiển thị khác nhau không?**  
Không. [Presentation::getViewProperties](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/getviewproperties/) áp dụng cho toàn bộ bản trình chiếu.

**Tôi có thể lưu các cài đặt hiển thị khác nhau cho các người dùng khác nhau không?**  
Tệp lưu một bộ thuộc tính hiển thị cho tất cả mọi người. Trình soạn thảo cũng có thể áp dụng các tùy chọn cục bộ của người dùng.

**Tôi có thể lưu các cài đặt hiển thị trong mẫu không?**  
Có. Các bản trình chiếu được tạo từ mẫu sẽ kế thừa các cài đặt hiển thị đã lưu của mẫu.