---
title: Lấy và Cập nhật Thuộc tính Xem của Bản trình chiếu trong PHP
linktitle: Thuộc tính Xem
type: docs
weight: 80
url: /vi/php-java/presentation-view-properties/
keywords:
- thuộc tính xem
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh chia dọc
- xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Khám phá các thuộc tính xem của Aspose.Slides cho PHP thông qua Java để tùy chỉnh định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường gồm ba vùng nội dung: slide, một vùng nội dung bên và một vùng nội dung dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem nằm trong cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu.  

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties) và các lớp con của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType) đã được bổ sung.

## **Về INormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) chỉ định liệu thanh chia dọc có tự động gọn lại khi vùng bên đủ nhỏ hay không.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) chỉ ra liệu người dùng có ưu tiên xem một vùng nội dung duy nhất trên toàn cửa sổ so với chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) chỉ định trạng thái mà thanh chia ngang hoặc dọc nên được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới, còn thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Maximized) và [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) chỉ định kích thước của vùng slide bên hoặc trên trong chế độ xem bình thường, khi giá trị [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) tương ứng.

## **Về Restoring INormalViewProperties**

Xác định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) trong chế độ xem bình thường, khi vùng có kích thước khôi phục thay đổi (không phải thu nhỏ hay phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) chỉ ra liệu kích thước của vùng nội dung bên có tự động điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ bên dưới cho thấy cách truy cập các thuộc tính [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) cho một bản trình chiếu.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Khôi phục các thuộc tính xem của bản trình chiếu
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Đặt Giá Trị Thu Phóng Mặc Định**
{{% alert color="info" %}} 

Aspose.Slides for PHP via Java hiện hỗ trợ thiết lập giá trị thu phóng mặc định cho bản trình chiếu sao cho khi bản trình chiếu được mở, mức thu phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của một bản trình chiếu. Các phương thức [getSlideViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) có thể được thiết lập chương trình. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ cách đặt [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để thiết lập các thuộc tính chế độ xem, hãy làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
2. Thiết lập [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
3. Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```php
  $presentation = new Presentation();
  try {
    # Đặt các thuộc tính xem của bản trình chiếu
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem ghi chú

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation::getViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getViewProperties) để truy cập các cài đặt chế độ xem toàn bản trình chiếu. Các phương thức [ViewProperties::getGridSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#getGridSpacing) và [ViewProperties::setGridSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/#setGridSpacing) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền tảng. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được tính bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

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

Lưới khác với [drawing guides](/slides/vi/php-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều, trong khi các hướng dẫn vẽ là các đường cân chỉnh ngang hoặc dọc được đặt vị trí riêng biệt. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không làm thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc bản trình chiếu. Lưu khoảng cách lưới không đảm bảo rằng một trình chỉnh sửa sẽ hiển thị lưới: tính khả kiến còn phụ thuộc vào sở thích của người xem hoặc trình chỉnh sửa.

## **Câu Hỏi Thường Gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**

Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định liệu lưới có được hiển thị hay không. Hãy kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Xóa hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xóa các hướng dẫn không làm thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[View settings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), không phải cho từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã xác định trước để các bản trình chiếu mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu với cấu hình chế độ xem ban đầu giống nhau.