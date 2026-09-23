---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bản trình bày trong PHP
linktitle: Thuộc tính hiển thị
type: docs
weight: 80
url: /vi/php-java/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bám thanh chia dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- phóng to mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Khám phá thuộc tính hiển thị của Aspose.Slides cho PHP thông qua Java để tùy chỉnh các định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức phóng to và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: slide, một vùng nội dung bên, và một vùng nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình bày được lưu lần cuối.

Phương thức [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày.  

Đã thêm các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties) và các lớp con của chúng, cùng với enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType).

## **Về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) chỉ định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) chỉ định liệu thanh chia dọc có nên "bám" vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) chỉ định liệu người dùng muốn xem một vùng nội dung duy nhất chiếm toàn bộ cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn bộ cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) chỉ định trạng thái mà thanh chia dọc hoặc ngang nên được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung bên dưới slide, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Maximized) và [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) chỉ định kích thước của vùng slide bên hoặc trên của chế độ xem bình thường, khi giá trị [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) tương ứng.

## **Về Restoring INormalViewProperties**

Chỉ định kích thước của vùng slide (rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) của chế độ xem bình thường, khi vùng có kích thước phục hồi biến đổi (không phải thu nhỏ cũng không phải phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) chỉ định kích thước của vùng slide (rộng khi là con của restoredTop, cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) chỉ định liệu kích thước của vùng nội dung bên có nên bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) cho một bản trình bày.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Khôi phục các thuộc tính hiển thị của bản trình bày
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Đặt Giá Trị Phóng To Mặc Định**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java hiện hỗ trợ việc đặt giá trị phóng to mặc định cho bản trình bày sao cho khi mở bản trình bày, mức phóng to đã được đặt sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của một bản trình bày. Các phương thức [getSlideViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để đặt các thuộc tính xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị phóng to cho chế độ xem slide cũng như chế độ xem ghi chú.

```php
  $presentation = new Presentation();
  try {
    # Đặt các thuộc tính hiển thị của bản trình bày
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Giá trị phóng to tính bằng phần trăm cho chế độ xem slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Giá trị phóng to tính bằng phần trăm cho chế độ xem ghi chú

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation::getViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getViewProperties) để truy cập cài đặt chế độ xem toàn bộ bản trình bày. Các phương thức [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#getGridSpacing) và [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#setGridSpacing) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải cho từng slide riêng lẻ. Khoảng cách lưới được chỉ định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("demo.pptx");
try {
    $gridSpacing = $presentation->getViewProperties()->getGridSpacing();
    echo "Current grid spacing: " . $gridSpacing . " points\n";

    $presentation->getViewProperties()->setGridSpacing(18.0);
    $presentation->save("grid-spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Lưới khác với [drawing guides](/slides/vi/php-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi các drawing guides là các đường căn chỉnh ngang hoặc dọc được định vị riêng lẻ. Thêm, di chuyển hoặc xóa drawing guides không thay đổi khoảng cách lưới.

Cả lưới và drawing guides đều là công cụ hỗ trợ chỉnh sửa. Chúng không được render như nội dung slide trong PDF, hình ảnh, SVG hoặc trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình soạn thảo sẽ hiển thị lưới: khả năng hiển thị còn phụ thuộc vào tùy chọn của người xem hoặc trình soạn thảo.

## **Hiển Thị hoặc Ẩn Bình Luận Khi Mở Bản Trình Bày**

Sử dụng [Presentation::getViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) để truy cập cài đặt chế độ xem toàn bộ bản trình bày. Sử dụng [ViewProperties::getShowComments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getshowcomments/) và [ViewProperties::setShowComments](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/setshowcomments/) để đọc hoặc thay đổi tùy chọn lưu trữ về việc có hiển thị bình luận khi bản trình bày mở trong PowerPoint hoặc trình soạn thảo tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn lưu trữ chế độ xem. Nó không thêm, xóa, chỉnh sửa hoặc giải quyết bình luận. Ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, phản hồi và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/php-java/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có chứa bình luận. Nó in ra cài đặt hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một tệp PPTX mới mà không xóa bất kỳ bình luận nào. Nó cũng sử dụng [ViewProperties::setLastView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/setlastview/) cùng với [ViewType::SlideView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewtype/#SlideView) để cấu hình chế độ chỉnh sửa ban đầu cùng với việc hiển thị bình luận.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ViewType;

$presentation = new Presentation("comments.pptx");
try {
    $showComments = $presentation->getViewProperties()->getShowComments();
    echo "Current comment visibility: " . java_values($showComments) . PHP_EOL;

    $presentation->getViewProperties()->setShowComments(NullableBool::False);
    $presentation->getViewProperties()->setLastView(ViewType::SlideView);
    $presentation->save("comments-hidden.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cài đặt này không quyết định liệu bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hoặc handout hay không. Hãy cấu hình các tùy chọn xuất riêng biệt tương ứng.

## **FAQ**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình bày?**

Tệp lưu khoảng cách lưới, nhưng trình soạn thảo kiểm soát việc lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình soạn thảo.

**Xóa drawing guides có thay đổi khoảng cách lưới không?**

Không. Drawing guides và khoảng cách lưới là các cài đặt độc lập. Xóa guides không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình bày không?**

[View settings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích người dùng, nhưng tệp chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với View Properties được định trước để các bản trình bày mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.