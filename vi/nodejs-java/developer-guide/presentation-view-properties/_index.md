---
title: "Truy xuất và Cập nhật Thuộc tính chế độ xem Bản trình bày trong JavaScript"
linktitle: "Thuộc tính chế độ xem"
type: docs
weight: 80
url: /vi/nodejs-java/presentation-view-properties/
keywords:
- "thuộc tính chế độ xem"
- "chế độ xem bình thường"
- "nội dung đề cương"
- "biểu tượng đề cương"
- "bắt dính thanh chia dọc"
- "chế độ xem đơn"
- "trạng thái thanh"
- "kích thước chiều"
- "tự động điều chỉnh"
- "thu phóng mặc định"
- "PowerPoint"
- "OpenDocument"
- "bản trình bày"
- "Node.js"
- "JavaScript"
- "Aspose.Slides"
description: "Khám phá Aspose.Slides cho Node.js thông qua Java để tùy chỉnh các định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường bao gồm ba vùng nội dung: bản trình chiếu, một vùng nội dung bên và một vùng nội dung dưới. Các thuộc tính liên quan đến vị trí của các vùng nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem vẫn ở cùng trạng thái như lần cuối cùng lưu.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình bày.

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties) và các lớp con của chúng, enum [SplitterBarStateType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType) đã được bổ sung.

## **Về NormalViewProperties**

Biểu thị các thuộc tính chế độ xem bình thường.

Phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) xác định liệu ứng dụng có nên hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ vùng nội dung nào của chế độ xem bình thường hay không.

Phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) xác định liệu thanh chia dọc có nên “bám” vào trạng thái thu nhỏ khi vùng bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) xác định liệu người dùng có muốn xem một vùng nội dung duy nhất toàn cửa sổ thay vì chế độ xem bình thường tiêu chuẩn với ba vùng nội dung hay không. Nếu bật, ứng dụng có thể chọn hiển thị một trong các vùng nội dung trên toàn cửa sổ.

Phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) chỉ định trạng thái mà thanh chia dọc hoặc ngang sẽ được hiển thị. Thanh chia ngang tách slide khỏi vùng nội dung phía dưới, thanh chia dọc tách slide khỏi vùng nội dung bên. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) chỉ định kích thước của vùng slide phía trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về việc Khôi phục NormalViewProperties**

Xác định kích thước của vùng slide (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) trong chế độ xem bình thường, khi vùng này có kích thước khôi phục biến đổi (không phải thu nhỏ hay phóng to).

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) xác định kích thước của vùng slide (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) xác định liệu kích thước của vùng nội dung bên có nên tự điều chỉnh để bù đắp cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình bày.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Khôi phục các thuộc tính chế độ xem của bản trình bày
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá trị Thu phóng Mặc định**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java hiện hỗ trợ thiết lập giá trị thu phóng mặc định cho bản trình bày sao cho khi bản trình bày được mở, mức thu phóng đã được đặt sẵn. Điều này có thể thực hiện bằng cách thiết lập [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của bản trình bày. Các phương thức [getSlideViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) có thể được thiết lập qua mã. Trong chủ đề này, chúng ta sẽ xem một ví dụ về cách thiết lập [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để thiết lập các thuộc tính chế độ xem, vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Thiết lập [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Ghi bản trình bày dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã thiết lập giá trị thu phóng cho chế độ xem slide cũng như chế độ xem ghi chú.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Đặt các thuộc tính chế độ xem của bản trình bày
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng theo phần trăm cho chế độ xem ghi chú
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Khoảng cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getViewProperties--) để truy cập các cài đặt chế độ xem toàn bộ bản trình bày. Các phương thức [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) và [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa nền. Cài đặt này áp dụng cho toàn bộ bản trình bày, không phải cho một slide riêng lẻ. Khoảng cách lưới được xác định bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ dưới đây mở tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, thiết lập khoảng một phần tư inch và lưu kết quả.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation("demo.pptx");
try {
    var gridSpacing = presentation.getViewProperties().getGridSpacing();
    console.log("Current grid spacing: " + gridSpacing + " points");

    presentation.getViewProperties().setGridSpacing(18);
    presentation.save("grid-spacing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Lưới khác với [drawing guides](/slides/vi/nodejs-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng thời gian đều đặn, trong khi các hướng dẫn vẽ là các đường căn chỉnh ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xóa các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc bản trình chiếu. Lưu khoảng cách lưới không đảm bảo trình chỉnh sửa sẽ hiển thị lưới: tính khả kiến cũng phụ thuộc vào sở thích của người xem hoặc trình chỉnh sửa.

## **Câu hỏi thường gặp**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình bày?**  
Tệp lưu khoảng cách lưới, nhưng trình chỉnh sửa quyết định có hiển thị lưới hay không. Kiểm tra cài đặt hiển thị lưới của trình chỉnh sửa.

**Việc xóa các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**  
Không. Các hướng dẫn vẽ và khoảng cách lưới là hai cài đặt độc lập. Xóa hướng dẫn chỉ để lại khoảng lưới đã lưu mà không thay đổi.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình bày không?**  
[Cài đặt chế độ xem](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được định nghĩa ở mức bản trình bày ([Normal View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), không phải theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem khác nhau cho các người dùng khác nhau không?**  
Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tuân theo sở thích của người dùng, nhưng tệp tự nó chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể chuẩn bị một mẫu với các View Properties đã định trước để các bản trình bày mới mở cùng cách không?**  
Có. Vì [view properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức bản trình bày, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu đó với cùng cấu hình chế độ xem ban đầu.