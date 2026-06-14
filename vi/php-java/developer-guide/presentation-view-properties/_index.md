---
title: Lấy và Cập nhật Thuộc tính Hiển thị Bản thuyết trình trong PHP
linktitle: Thuộc tính Hiển thị
type: docs
weight: 80
url: /vi/php-java/presentation-view-properties/
keywords:
- thuộc tính hiển thị
- chế độ xem bình thường
- nội dung đề cương
- biểu tượng đề cương
- bắt dính thanh phân tách dọc
- chế độ xem đơn
- trạng thái thanh
- kích thước chiều
- tự động điều chỉnh
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Khám phá Aspose.Slides cho PHP thông qua Java để tùy chỉnh các định dạng slide PPT, PPTX và ODP — điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản slide, một vùng nội dung phụ, và một vùng nội dung dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái hiển thị vào tệp, để khi mở lại, chế độ xem sẽ ở trong cùng trạng thái như khi bản thuyết trình được lưu lần cuối.

Phương thức [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) đã được thêm để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản thuyết trình. 

[NormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties) classes and its descendants, [SplitterBarStateType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType) enum have been added.

## **Giới thiệu về INormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getShowOutlineIcons) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setShowOutlineIcons) cho biết liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getSnapVerticalSplitter) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setSnapVerticalSplitter) cho biết liệu thanh phân tách dọc có nên bật vào trạng thái thu nhỏ khi vùng phụ đủ nhỏ hay không.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getPreferSingleView) và [setPreferSingleView](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#setPreferSingleView) chỉ ra liệu người dùng muốn xem một vùng nội dung duy nhất chiếm toàn bộ cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu được bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trong toàn bộ cửa sổ.

Phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) chỉ định trạng thái mà thanh phân tách ngang hoặc dọc nên hiển thị. Thanh phân tách ngang tách slide khỏi vùng nội dung bên dưới slide, thanh phân tách dọc tách slide khỏi vùng nội dung phụ. Các giá trị có thể là: [SplitterBarStateType::Minimized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Minimized), [SplitterBarStateType::Maximized](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Maximized) và [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored).

Phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft) và [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties#getRestoredTop) chỉ định kích thước của vùng slide trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType::Restored](https://reference.aspose.com/slides/vi/php-java/aspose.slides/SplitterBarStateType/#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getVerticalBarState) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getHorizontalBarState) tương ứng.

## **Về việc khôi phục INormalViewProperties**

Chỉ định kích thước của vùng slide (độ rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredTop), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewProperties/#getRestoredLeft)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng đại). 

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getDimensionSize) chỉ định kích thước của vùng slide (độ rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/php-java/aspose.slides/NormalViewRestoredProperties/#getAutoAdjust) chỉ ra liệu kích thước của vùng nội dung phụ có nên điều chỉnh để bù cho kích thước mới khi thay đổi kích thước của cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ được đưa ra bên dưới cho thấy cách bạn có thể truy cập các thuộc tính [ViewProperties::getNormalViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNormalViewProperties) cho một bản thuyết trình.

```php
  $pres = new Presentation();
  try {
    $pres->getViewProperties()->getNormalViewProperties()->setHorizontalBarState(SplitterBarStateType::Restored);
    $pres->getViewProperties()->getNormalViewProperties()->setVerticalBarState(SplitterBarStateType::Maximized);

    # Khôi phục các thuộc tính hiển thị của bản thuyết trình
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setAutoAdjust(true);
    $pres->getViewProperties()->getNormalViewProperties()->getRestoredTop()->setDimensionSize(80);
    $pres->getViewProperties()->getNormalViewProperties()->setShowOutlineIcons(true);
    $pres->save("presentation_normal_view_state.pptx", SaveFormat::Pptx);
  } finally {
    $pres->dispose();
  }
```

## **Đặt giá trị thu phóng mặc định**
{{% alert color="primary" %}} 

Aspose.Slides for PHP qua Java hiện hỗ trợ việc thiết lập giá trị thu phóng mặc định cho bản thuyết trình sao cho khi bản thuyết trình được mở, mức thu phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của một bản thuyết trình. [getSlideViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getSlideViewProperties) cũng như [getNotesViewProperties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties/#getNotesViewProperties) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách thiết lập [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation) trong [Aspose.Slides](/slides/vi/).

{{% /alert %}} 

Để thiết lập các thuộc tính hiển thị, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/ViewProperties) cho [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation).
1. Ghi bản thuyết trình thành tệp [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```php
  $presentation = new Presentation();
  try {
    # Đặt các thuộc tính hiển thị của bản thuyết trình
    $presentation->getViewProperties()->getSlideViewProperties()->setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    $presentation->getViewProperties()->getNotesViewProperties()->setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú

    $presentation->save("Zoom_out.pptx", SaveFormat::Pptx);
  } finally {
    $presentation->dispose();
  }
```

## **FAQ**

**Tôi có thể đặt các cài đặt hiển thị khác nhau cho các phần khác nhau của bản thuyết trình không?**

[View settings](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được xác định ở mức bản thuyết trình ([Normal View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/php-java/aspose.slides/viewproperties/getslideviewproperties/)), không phải theo từng phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi nó được mở.

**Tôi có thể định trước các trạng thái hiển thị khác nhau cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính hiển thị.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã được định trước để các bản thuyết trình mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức bản thuyết trình, bạn có thể nhúng chúng vào một mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình hiển thị ban đầu.