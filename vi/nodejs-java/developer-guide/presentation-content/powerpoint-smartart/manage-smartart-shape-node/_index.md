---
title: Quản lý các nút hình dạng SmartArt trong Bản trình chiếu bằng JavaScript
linktitle: Nút Hình dạng SmartArt
type: docs
weight: 30
url: /vi/nodejs-java/manage-smartart-shape-node/
keywords:
- Nút SmartArt
- nút con
- thêm nút
- vị trí nút
- truy cập nút
- xóa nút
- vị trí tùy chỉnh
- nút trợ giúp
- định dạng đổ nền
- kết xuất nút
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Quản lý các nút hình dạng SmartArt trong PPT và PPTX với Aspose.Slides cho Node.js. Nhận các mẫu mã JavaScript rõ ràng và mẹo để tối ưu hoá các bản trình chiếu của bạn."
---
## **Tổng quan**

Đồ họa SmartArt trong các bản thuyết trình PowerPoint được tổ chức thông qua các nút chứa văn bản và xác định cấu trúc của sơ đồ. Aspose.Slides cho phép bạn làm việc với các nút SmartArt này một cách lập trình: thêm nút mới và nút con, chèn nút con ở vị trí cụ thể, truy cập các nút hiện có và đọc văn bản, cấp độ và vị trí của chúng.

Bài viết này giải thích cách quản lý các nút hình dạng SmartArt. Nó chỉ ra cách xóa nút, làm việc với các nút con bằng chỉ mục hoặc vị trí, chuyển đổi nút trợ giúp thành nút thường, điều chỉnh vị trí, kích thước và góc quay của các hình dạng nút SmartArt, đặt định dạng tô đầy cho nút và tạo hình thu nhỏ cho nút con của SmartArt.

## **Thêm Nút SmartArt trong Bản trình chiếu PowerPoint bằng JavaScript**
Aspose.Slides for Node.js via Java đã cung cấp API đơn giản nhất để quản lý các hình dạng SmartArt một cách dễ dàng. Mã mẫu dưới đây sẽ giúp thêm nút và nút con vào trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Thêm một [Node mới](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) vào hình dạng SmartArt [**NodeCollection**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt#getAllNodes--) và đặt văn bản trong TextFrame.
1. Bây giờ, [Thêm](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--) một [**Child Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) vào Node [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) vừa được thêm và đặt văn bản trong TextFrame.
1. Lưu bản trình chiếu.

```javascript
// Tải bản trình chiếu mong muốn
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            // Thêm một nút SmartArt mới
            var TemNode = smart.getAllNodes().addNode();
            // Thêm văn bản
            TemNode.getTextFrame().setText("Test");
            // Thêm nút con mới vào nút cha. Nó sẽ được thêm vào cuối bộ sưu tập
            var newNode = TemNode.getChildNodes().addNode();
            // Thêm văn bản
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    // Lưu bản trình chiếu
    pres.save("AddSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Thêm Nút SmartArt tại Vị trí Cụ thể**
Trong đoạn mã mẫu dưới đây, chúng tôi giải thích cách thêm các nút con thuộc về các nút tương ứng của hình dạng SmartArt tại vị trí nhất định.

1. Tạo một thể hiện của lớp Presentation.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Thêm một hình dạng [**StackedList**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList) loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) vào slide đã truy cập.
1. Truy cập nút đầu tiên trong hình dạng SmartArt đã thêm.
1. Bây giờ, thêm [**Child Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) cho [**Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode) đã chọn ở vị trí 2 và đặt văn bản cho nó.
1. Lưu bản trình chiếu.

```javascript
// Tạo một thể hiện bản trình chiếu
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide của bản trình chiếu
    var slide = pres.getSlides().get_Item(0);
    // Thêm Smart Art IShape
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Truy cập nút SmartArt tại chỉ mục 0
    var node = smart.getAllNodes().get_Item(0);
    // Thêm nút con mới tại vị trí 2 trong nút cha
    var chNode = node.getChildNodes().addNodeByPosition(2);
    // Thêm Văn bản
    chNode.getTextFrame().setText("Sample Text Added");
    // Lưu bản trình chiếu
    pres.save("AddSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Nút SmartArt trong Bản trình chiếu PowerPoint bằng JavaScript**
Mã mẫu dưới đây sẽ giúp truy cập các nút bên trong hình dạng SmartArt. Lưu ý rằng bạn không thể thay đổi LayoutType của SmartArt vì nó chỉ đọc và chỉ được đặt khi hình dạng SmartArt được thêm.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả [**Nodes**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt#getAllNodes--) bên trong hình dạng SmartArt.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của Nút SmartArt.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("SmartArtShape.pptx");
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let i = 0; i < slide.getShapes().size(); i++) {
        let shape = slide.getShapes().get_Item(i);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            // Duyệt qua tất cả các nút trong SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                // Truy cập nút SmartArt tại chỉ mục i
                var node = smart.getAllNodes().get_Item(j);
                // In ra các tham số của nút SmartArt
                console.log(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Nút Con SmartArt**
Mã mẫu dưới đây sẽ giúp truy cập các nút con thuộc về các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả [**Nodes**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt#getAllNodes--) bên trong hình dạng SmartArt.
1. Đối với mỗi [**Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode) đã chọn, duyệt qua tất cả [**Child Nodes**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) bên trong nút cụ thể.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của [**Child Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("AccessChildNodes.pptx");
try {
    // Lấy slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let s = 0; s < slide.getShapes().size(); s++) {
        let shape = slide.getShapes().get_Item(s);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            // Duyệt qua tất cả các nút trong SmartArt
            for (var i = 0; i < smart.getAllNodes().size(); i++) {
                // Truy cập nút SmartArt tại chỉ mục i
                var node0 = smart.getAllNodes().get_Item(i);
                // Duyệt qua các nút con trong nút SmartArt tại chỉ mục i
                for (var j = 0; j < node0.getChildNodes().size(); j++) {
                    // Truy cập nút con trong nút SmartArt
                    var node = node0.getChildNodes().get_Item(j);
                    // In ra các tham số của nút con SmartArt
                    console.log("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Truy cập Nút Con SmartArt tại Vị trí Cụ thể**
Trong ví dụ này, chúng ta sẽ học cách truy cập các nút con ở một số vị trí cụ thể thuộc về các nút tương ứng của hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Thêm một hình dạng SmartArt loại [**StackedList**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtLayoutType#StackedList).
1. Truy cập hình dạng SmartArt đã thêm.
1. Truy cập nút tại chỉ mục 0 cho hình dạng SmartArt đã truy cập.
1. Bây giờ, truy cập [**Child Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--) ở vị trí 1 cho nút SmartArt đã truy cập bằng phương thức **get_Item()**.
1. Truy cập và hiển thị thông tin như vị trí, cấp độ và Văn bản của [**Child Node**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#getChildNodes--).

```javascript
// Khởi tạo bản trình chiếu
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide đầu tiên
    var slide = pres.getSlides().get_Item(0);
    // Thêm hình dạng SmartArt vào slide đầu tiên
    var smart = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.StackedList);
    // Truy cập nút SmartArt tại chỉ mục 0
    var node = smart.getAllNodes().get_Item(0);
    // Truy cập nút con tại vị trí 1 trong nút cha
    var position = 1;
    var chNode = node.getChildNodes().get_Item(position);
    // In ra các tham số của nút con SmartArt
    console.log("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Nút SmartArt trong Bản trình chiếu PowerPoint bằng JavaScript**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Kiểm tra xem [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) có nhiều hơn 0 nút hay không.
1. Chọn nút SmartArt cần xóa.
1. Bây giờ, xóa nút đã chọn bằng phương thức [**RemoveNode**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-aspose.slides.ISmartArtNode-).
1. Lưu bản trình chiếu.

```javascript
// Tải bản trình chiếu mong muốn
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Truy cập nút SmartArt tại chỉ mục 0
                var node = smart.getAllNodes().get_Item(0);
                // Xóa nút đã chọn
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    // Lưu bản trình chiếu
    pres.save("RemoveSmartArtNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Xóa Nút SmartArt tại Vị trí Cụ thể**
Trong ví dụ này, chúng ta sẽ học cách xóa các nút bên trong hình dạng SmartArt tại vị trí nhất định.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide đầu tiên bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Chọn nút hình dạng SmartArt tại chỉ mục 0.
1. Bây giờ, kiểm tra xem nút SmartArt đã chọn có nhiều hơn 2 nút con không.
1. Bây giờ, xóa nút ở **Position 1** bằng phương thức [**RemoveNode**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNodeCollection#removeNode-int-).
1. Lưu bản trình chiếu.

```javascript
// Tải bản trình chiếu mong muốn
var pres = new aspose.slides.Presentation("AddSmartArtNode.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.SmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            if (smart.getAllNodes().size() > 0) {
                // Truy cập nút SmartArt tại chỉ mục 0
                var node = smart.getAllNodes().get_Item(0);
                if (node.getChildNodes().size() >= 2) {
                    // Xóa nút con ở vị trí 1
                    node.getChildNodes().removeNode(1);
                }
            }
        }
    }
    // Lưu bản trình chiếu
    pres.save("RemoveSmartArtNodeByPosition.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Đặt Vị trí Tùy chỉnh cho Nút Con trong SmartArt**
Bây giờ Aspose.Slides for Node.js via Java hỗ trợ việc thiết lập các thuộc tính [SmartArtShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtShape) [X](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setX-float-) và [Y](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setY-float-). Đoạn mã dưới đây cho thấy cách đặt vị trí, kích thước và góc quay tùy chỉnh cho SmartArtShape; cũng lưu ý rằng việc thêm nút mới sẽ gây tính lại vị trí và kích thước của tất cả các nút. Với cài đặt vị trí tùy chỉnh, người dùng có thể đặt các nút theo nhu cầu.

```javascript
// Khởi tạo lớp Presentation
var pres = new aspose.slides.Presentation("SimpleSmartArt.pptx");
try {
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, aspose.slides.SmartArtLayoutType.OrganizationChart);
    // Di chuyển hình dạng SmartArt đến vị trí mới
    var node = smart.getAllNodes().get_Item(1);
    var shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + (shape.getWidth() * 2));
    shape.setY(shape.getY() - (shape.getHeight() * 2));
    // Thay đổi chiều rộng của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + (shape.getWidth() * 2));
    // Thay đổi chiều cao của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + (shape.getHeight() * 2));
    // Thay đổi góc quay của hình dạng SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);
    pres.save("SmartArt.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Kiểm tra Nút Trợ giúp**
{{% alert color="primary" %}} 

Trong bài viết này, chúng tôi sẽ tìm hiểu sâu hơn về các tính năng của hình dạng SmartArt được thêm vào các slide bài thuyết trình một cách lập trình bằng Aspose.Slides cho Node.js qua Java.

{{% /alert %}} 

Chúng tôi sẽ sử dụng hình dạng SmartArt nguồn sau để nghiên cứu trong các phần khác nhau của bài viết này.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Hình: Hình SmartArt nguồn trong slide**|

Trong đoạn mã mẫu dưới đây, chúng tôi sẽ khảo sát cách xác định **Assistant Nodes** trong bộ sưu tập nút SmartArt và thay đổi chúng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) và tải bản trình chiếu có hình dạng SmartArt.
1. Lấy tham chiếu của slide thứ hai bằng cách sử dụng chỉ số của nó.
1. Duyệt qua mọi hình dạng trong slide đầu tiên.
1. Kiểm tra xem hình dạng có phải là loại [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) không và ép kiểu hình dạng đã chọn sang [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) nếu nó là SmartArt.
1. Duyệt qua tất cả các nút bên trong hình dạng SmartArt và kiểm tra xem chúng có phải là [**Assistant Nodes**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNode#isAssistant--) hay không.
1. Thay đổi trạng thái của Nút Trợ giúp thành nút thường.
1. Lưu bản trình chiếu.

```javascript
// Tạo một thể hiện bản trình chiếu
var pres = new aspose.slides.Presentation("AddNodes.pptx");
try {
    // Duyệt qua mọi hình dạng trong slide đầu tiên
    for (let i = 0; i < pres.getSlides().get_Item(0).getShapes().size(); i++) {
        let shape = pres.getSlides().get_Item(0).getShapes().get_Item(i);
        // Kiểm tra xem hình dạng có phải là loại SmartArt không
        if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
            // Ép kiểu hình dạng sang SmartArt
            var smart = shape;
            // Duyệt qua tất cả các nút của hình dạng SmartArt
            for (var j = 0; j < smart.getAllNodes().size(); j++) {
                var node = smart.getAllNodes().get_Item(j);
                // Kiểm tra xem nút có phải là nút trợ giúp không
                if (node.isAssistant()) {
                    // Đặt nút trợ giúp thành false và chuyển nó thành nút thường
                    node.isAssistant();
                }
            }
        }
    }
    // Lưu bản trình chiếu
    pres.save("ChangeAssitantNode.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Hình: Nút Trợ giúp đã được thay đổi trong hình dạng SmartArt trong slide**|

## **Đặt Định dạng Đổ nền cho Nút**
Aspose.Slides for Node.js via Java cho phép thêm các hình dạng SmartArt tùy chỉnh và đặt định dạng đổ nền cho chúng. Bài viết này giải thích cách tạo và truy cập các hình dạng SmartArt và đặt định dạng đổ nền bằng Aspose.Slides for Node.js via Java.

Vui lòng thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. Lấy tham chiếu của một slide bằng cách sử dụng chỉ số của nó.
1. Thêm một hình dạng [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArt) bằng cách thiết lập [**LayoutType**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtLayoutType#ClosedChevronProcess).
1. Đặt [**FillFormat**](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getFillFormat--) cho các nút hình dạng SmartArt.
1. Ghi bản trình chiếu đã sửa đổi thành file PPTX.

```javascript
// Khởi tạo bản trình chiếu
var pres = new aspose.slides.Presentation();
try {
    // Truy cập slide
    var slide = pres.getSlides().get_Item(0);
    // Thêm hình dạng SmartArt và các nút
    var chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, aspose.slides.SmartArtLayoutType.ClosedChevronProcess);
    var node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    // Đặt màu tô đầy cho nút
    for (let i = 0; i < node.getShapes().size(); i++) {
        let item = node.getShapes().get_Item(i);
        item.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
        item.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));
    }
    // Lưu bản trình chiếu
    pres.save("TestSmart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Tạo Thu nhỏ cho Nút Con SmartArt**
Các nhà phát triển có thể tạo hình thu nhỏ cho nút con của SmartArt bằng cách thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation).
1. [Add SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/SmartArtNodeCollection#addNode--).
1. Lấy tham chiếu của một nút bằng cách sử dụng chỉ số của nó.
1. Lấy hình ảnh thu nhỏ.
1. Lưu hình ảnh thu nhỏ ở bất kỳ định dạng ảnh nào mong muốn.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp PPTX
var pres = new aspose.slides.Presentation();
try {
    // Thêm SmartArt
    var smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicCycle);
    // Lấy tham chiếu của một nút bằng cách sử dụng chỉ mục của nó
    var node = smart.getNodes().get_Item(1);
    // Lấy hình thu nhỏ
    var slideImage = node.getShapes().get_Item(0).getImage();
    // Lưu hình thu nhỏ
    try {
        slideImage.save("SmartArt_ChildNote_Thumbnail.png", aspose.slides.ImageFormat.Png);
    } finally {
        if (slideImage != null) {
            slideImage.dispose();
        }
    }
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ hoạt ảnh không?**

Có. SmartArt được xem như một hình dạng thông thường, vì vậy bạn có thể [apply standard animations](/slides/vi/nodejs-java/shape-animation/) (hiệu ứng xuất hiện, thoát, nhấn mạnh, đường chuyển động) và điều chỉnh thời gian. Bạn cũng có thể tạo hoạt ảnh cho các hình dạng bên trong các nút SmartArt khi cần.

**Làm sao tôi có thể xác định chính xác một SmartArt cụ thể trên slide nếu không biết ID nội bộ của nó?**

Gán và tìm kiếm bằng [alternative text](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getalternativetext/). Đặt một AltText đặc trưng cho SmartArt giúp bạn tìm thấy nó mà không cần dựa vào các định danh nội bộ.

**Hình dạng SmartArt có được giữ nguyên khi chuyển đổi bản trình chiếu sang PDF không?**

Có. Aspose.Slides render SmartArt với độ chính xác hình ảnh cao trong quá trình [PDF export](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/), bảo toàn bố cục, màu sắc và hiệu ứng.

**Tôi có thể trích xuất hình ảnh của toàn bộ SmartArt (cho bản preview hoặc báo cáo) không?**

Có. Bạn có thể render một hình dạng SmartArt ra [raster formats](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getImage) hoặc ra [SVG](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/writeassvg/) cho đầu ra vector có thể mở rộng, phù hợp cho ảnh thu nhỏ, báo cáo hoặc sử dụng trên web.