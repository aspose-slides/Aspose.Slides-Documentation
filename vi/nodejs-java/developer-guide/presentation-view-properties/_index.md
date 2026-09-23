---
title: Truy xuất và Cập nhật Thuộc tính chế độ xem Bản trình chiếu trong JavaScript
linktitle: Thuộc tính chế độ xem
type: docs
weight: 80
url: /vi/nodejs-java/presentation-view-properties/
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
- thu phóng mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá Aspose.Slides cho Node.js thông qua các thuộc tính chế độ xem Java để tùy chỉnh các định dạng PPT, PPTX và ODP—điều chỉnh bố cục, mức thu phóng và cài đặt hiển thị."
---
## **Giới thiệu**

Chế độ xem bình thường gồm ba khu vực nội dung: bản trình chiếu, một khu vực nội dung bên và một khu vực nội dung phía dưới. Các thuộc tính liên quan đến vị trí của các khu vực nội dung khác nhau. Thông tin này cho phép ứng dụng lưu trạng thái xem vào tệp, để khi mở lại, chế độ xem sẽ ở cùng trạng thái như khi bản trình chiếu được lưu lần cuối.

Phương thức [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) đã được thêm vào để cung cấp quyền truy cập vào các thuộc tính chế độ xem bình thường của bản trình chiếu. 

Các lớp [NormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties), [NormalViewRestoredProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties) và các lớp kế thừa của chúng, [SplitterBarStateType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType) enum đã được thêm.

## **Về NormalViewProperties**

Biểu diễn các thuộc tính chế độ xem bình thường.

Các phương thức [getShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getShowOutlineIcons--) và [setShowOutlineIcons](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setShowOutlineIcons-boolean-) chỉ định liệu ứng dụng có hiển thị biểu tượng khi hiển thị nội dung đề cương trong bất kỳ khu vực nội dung nào của chế độ xem bình thường hay không.

Các phương thức [getSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getSnapVerticalSplitter--) và [setSnapVerticalSplitter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setSnapVerticalSplitter-boolean-) chỉ định liệu thanh chia dọc có tự động thu gọn khi khu vực bên đủ nhỏ.

Thuộc tính [getPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getPreferSingleView--) và [setPreferSingleView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#setPreferSingleView-boolean-) chỉ định liệu người dùng ưu tiên xem một vùng nội dung duy nhất trên toàn cửa sổ so với chế độ xem bình thường tiêu chuẩn với ba khu vực nội dung. Nếu bật, ứng dụng có thể chọn hiển thị một trong các khu vực nội dung trên toàn cửa sổ.

Các phương thức [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) xác định trạng thái mà thanh chia dọc hoặc ngang sẽ hiển thị. Thanh chia dọc tách bản trình chiếu khỏi khu vực nội dung bên, thanh chia ngang tách bản trình chiếu khỏi khu vực nội dung dưới. Các giá trị có thể là: [SplitterBarStateType.Minimized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Minimized), [SplitterBarStateType.Maximized](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Maximized) và [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored).

Các phương thức [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--) và [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--) xác định kích thước của khu vực bản trình chiếu phía trên hoặc bên của chế độ xem bình thường, khi giá trị [SplitterBarStateType.Restored](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SplitterBarStateType#Restored) được áp dụng cho [getVerticalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getVerticalBarState--) và [getHorizontalBarState](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getHorizontalBarState--) tương ứng.

## **Về Restoring NormalViewProperties** 

Xác định kích thước của khu vực bản trình chiếu (chiều rộng khi là con của [getRestoredTop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredTop--), chiều cao khi là con của [getRestoredLeft](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewProperties#getRestoredLeft--)) của chế độ xem bình thường, khi khu vực có kích thước khôi phục biến đổi (không thu gọn và không phóng to). 

Phương thức [getDimensionSize](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getDimensionSize--) xác định kích thước của khu vực bản trình chiếu (chiều rộng khi là con của restoredTop, chiều cao khi là con của restoredLeft).

Phương thức [getAutoAdjust](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/NormalViewRestoredProperties#getAutoAdjust--) xác định liệu kích thước của khu vực nội dung bên có nên tự điều chỉnh để bù cho kích thước mới khi thay đổi kích thước cửa sổ chứa chế độ xem trong ứng dụng hay không.

Một ví dụ dưới đây cho thấy cách truy cập các thuộc tính [ViewProperties.getNormalViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNormalViewProperties--) cho một bản trình chiếu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var pres = new aspose.slides.Presentation();
try {
    pres.getViewProperties().getNormalViewProperties().setHorizontalBarState(aspose.slides.SplitterBarStateType.Restored);
    pres.getViewProperties().getNormalViewProperties().setVerticalBarState(aspose.slides.SplitterBarStateType.Maximized);

    // Khôi phục các thuộc tính chế độ xem của bản trình chiếu
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setAutoAdjust(true);
    pres.getViewProperties().getNormalViewProperties().getRestoredTop().setDimensionSize(80);
    pres.getViewProperties().getNormalViewProperties().setShowOutlineIcons(true);
    pres.save("presentation_normal_view_state.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Đặt Giá Trị Thu Phóng Mặc Định**

{{% alert color="info" %}} 

Aspose.Slides for Node.js via Java hiện hỗ trợ đặt giá trị thu phóng mặc định cho bản trình chiếu sao cho khi mở bản trình chiếu, mức thu phóng đã được thiết lập sẵn. Điều này có thể thực hiện bằng cách đặt [ViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của một bản trình chiếu. Các phương thức [getSlideViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getSlideViewProperties--) và [getNotesViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties#getNotesViewProperties--) có thể được thiết lập bằng mã. Trong chủ đề này, chúng ta sẽ xem qua một ví dụ về cách đặt [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) trong Aspose.Slides.

{{% /alert %}} 

Để đặt các thuộc tính chế độ xem, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Đặt [View Properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/ViewProperties) của [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Ghi bản trình chiếu thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/).  
   Trong ví dụ dưới đây, chúng tôi đã đặt giá trị thu phóng cho chế độ xem bản trình chiếu cũng như chế độ xem ghi chú.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

var presentation = new aspose.slides.Presentation();
try {
    // Đặt các thuộc tính chế độ xem của bản trình chiếu
    presentation.getViewProperties().getSlideViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem slide
    presentation.getViewProperties().getNotesViewProperties().setScale(100); // Giá trị thu phóng tính bằng phần trăm cho chế độ xem ghi chú
    presentation.save("Zoom_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Khoảng Cách Lưới**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getViewProperties--) để truy cập cài đặt chế độ xem trên toàn bộ bản trình chiếu. Các phương thức [ViewProperties.getGridSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#getGridSpacing--) và [ViewProperties.setGridSpacing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setGridSpacing-float-) đọc hoặc thay đổi khoảng cách của lưới chỉnh sửa cơ bản. Cài đặt này áp dụng cho toàn bộ bản trình chiếu, không phải cho một slide riêng lẻ. Khoảng cách lưới được tính bằng điểm, trong đó 72 điểm bằng một inch. Sử dụng giá trị dương, theo yêu cầu của tài liệu API.

Ví dụ sau mở một tệp `demo.pptx` hiện có, in ra khoảng cách lưới hiện tại, đặt khoảng cách một phần tư inch và lưu kết quả.

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

Lưới khác với [drawing guides](/slides/vi/nodejs-java/drawing-guides/). Khoảng cách lưới kiểm soát một khoảng đều đặn, trong khi các hướng dẫn vẽ là các đường thẳng ngang hoặc dọc được đặt vị trí riêng lẻ. Thêm, di chuyển hoặc xoá các hướng dẫn vẽ không thay đổi khoảng cách lưới.

Cả lưới và các hướng dẫn vẽ đều là công cụ hỗ trợ chỉnh sửa. Chúng không được hiển thị như nội dung slide trong PDF, hình ảnh, SVG hoặc bản trình chiếu. Lưu khoảng cách lưới không đảm bảo một trình soạn thảo sẽ hiển thị lưới: tính khả dụng còn phụ thuộc vào cài đặt của người xem hoặc trình soạn thảo.

## **Hiển Thị Hoặc Ẩn Bình Luận Khi Mở Bản Trình Chiếu**

Sử dụng [Presentation.getViewProperties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getViewProperties--) để truy cập cài đặt chế độ xem trên toàn bộ bản trình chiếu. Sử dụng [ViewProperties.getShowComments](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#getShowComments--) và [ViewProperties.setShowComments](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setShowComments-byte-) để đọc hoặc thay đổi tùy chọn lưu trữ về việc có hiển thị bình luận khi bản trình chiếu mở trong PowerPoint hoặc trình soạn thảo tương thích khác.

Cài đặt này chỉ kiểm soát tùy chọn chế độ xem được lưu. Nó không thêm, xoá, chỉnh sửa hay giải quyết bình luận. Ẩn bình luận vẫn giữ nguyên nội dung, tác giả, vị trí, trả lời và trạng thái của chúng. Xem [Presentation Comments](/slides/vi/nodejs-java/presentation-comments/) để biết các thao tác thay đổi bình luận.

Ví dụ sau yêu cầu một tệp `comments.pptx` hiện có có chứa bình luận. Nó in ra cài đặt hiển thị hiện tại, yêu cầu ẩn bình luận và lưu một tệp PPTX mới mà không xoá bất kỳ bình luận nào. Nó cũng sử dụng [ViewProperties.setLastView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/#setLastView-int-) với [ViewType.SlideView](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewtype/#SlideView) để cấu hình chế độ chỉnh sửa ban đầu cùng với khả năng hiển thị bình luận.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

var presentation = new aspose.slides.Presentation("comments.pptx");
try {
    var showComments = presentation.getViewProperties().getShowComments();
    console.log("Current comment visibility: " + showComments);

    var hideComments = java.newByte(aspose.slides.NullableBool.False);
    presentation.getViewProperties().setShowComments(hideComments);
    presentation.getViewProperties().setLastView(aspose.slides.ViewType.SlideView);
    presentation.save("comments-hidden.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Cài đặt này không quyết định việc bình luận có được bao gồm trong các xuất PDF, HTML, hình ảnh, ghi chú hay handout hay không. Hãy cấu hình các tùy chọn xuất riêng biệt cho từng định dạng.

## **FAQ**

**Tại sao lưới không hiển thị sau khi tôi mở lại bản trình chiếu?**

Tệp lưu khoảng cách lưới, nhưng trình soạn thảo kiểm soát việc lưới có được hiển thị hay không. Kiểm tra cài đặt hiển thị lưới của trình soạn thảo.

**Việc xoá các hướng dẫn vẽ có thay đổi khoảng cách lưới không?**

Không. Các hướng dẫn vẽ và khoảng cách lưới là các cài đặt độc lập. Xoá các hướng dẫn không thay đổi khoảng cách lưới đã lưu.

**Tôi có thể đặt các cài đặt chế độ xem khác nhau cho các phần khác nhau của bản trình chiếu không?**

[View settings](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được định nghĩa ở mức bản trình chiếu ([Normal View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getnormalviewproperties/)/[Slide View](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/viewproperties/getslideviewproperties/)), không theo phần, vì vậy một bộ tham số duy nhất áp dụng cho toàn bộ tài liệu khi mở.

**Tôi có thể định trước các trạng thái chế độ xem cho các người dùng khác nhau không?**

Không. Các cài đặt được lưu trong tệp và được chia sẻ. Các ứng dụng xem có thể tôn trọng tùy chọn của người dùng, nhưng tệp chỉ chứa một bộ thuộc tính chế độ xem.

**Tôi có thể tạo mẫu với các View Properties được định trước để các bản trình chiếu mới mở cùng cách không?**

Có. Vì [view properties](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/getviewproperties/) được lưu ở mức bản trình chiếu, bạn có thể nhúng chúng vào mẫu và tạo tài liệu mới từ mẫu với cùng cấu hình chế độ xem ban đầu.