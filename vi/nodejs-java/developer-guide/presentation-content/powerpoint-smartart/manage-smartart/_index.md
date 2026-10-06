---
title: Quản lý SmartArt trong bài thuyết trình PowerPoint bằng JavaScript
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- Biểu đồ tổ chức
- biểu đồ tổ chức hình ảnh
- PowerPoint
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho Node.js bằng các mẫu mã JavaScript rõ ràng, giúp tăng tốc thiết kế slide và tự động hóa."
---
## **Tổng quan**

SmartArt là một biểu đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides cho Node.js qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng của nút, lặp qua [SmartArt.getAllNodes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/getallnodes/), sau đó đọc [TextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartshape/gettextframe/).

Ví dụ yêu cầu một bản trình bày có ít nhất một slide và một đối tượng SmartArt làm hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản có sẵn ra console.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("sample.pptx");
try {
    let slide = presentation.getSlides().get_Item(0);
    let shape = slide.getShapes().get_Item(0);

    if (java.instanceOf(shape, "com.aspose.slides.ISmartArt")) {
        let smartArt = shape;
        let nodes = smartArt.getAllNodes();

        for (let nodeIndex = 0; nodeIndex < nodes.size(); nodeIndex++) {
            let node = nodes.get_Item(nodeIndex);
            let nodeShapes = node.getShapes();

            for (let shapeIndex = 0; shapeIndex < nodeShapes.size(); shapeIndex++) {
                let nodeShape = nodeShapes.get_Item(shapeIndex);

                if (nodeShape.getTextFrame() != null) {
                    console.log(nodeShape.getTextFrame().getText());
                }
            }
        }
    } else {
        console.log("The first shape is not a SmartArt object.");
    }
} finally {
    presentation.dispose();
}
```

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình bày. Vị trí và kích thước truyền vào [ShapeCollection.addSmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addsmartart/) được đo bằng điểm. Sử dụng [SmartArt.setLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setlayout/) để thay đổi bố cục.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra Nút SmartArt có bị Ẩn hay không**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các yếu tố biểu đồ hiển thị.

Ví dụ sau thêm một nút vào một đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút đã thêm. Nó in một thông báo nếu nút bị ẩn và lưu biểu đồ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);
    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các biểu đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/getorganizationchartlayout/) và [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartnode/setorganizationchartlayout/) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ phía trái, phải hoặc cả hai phía, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`. Chỉ mục bắt đầu từ 0 (`0`) chọn nút cấp đầu tiên; các nút con của nó sử dụng cách sắp xếp đã chọn. Bản trình bày đã sửa đổi sau đó được lưu.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);
    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo Biểu đồ Tổ chức Hình ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các biểu đồ phân cấp có chứa các chỗ giữ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide. Ví dụ này lưu một biểu đồ với các chỗ giữ hình ảnh; nó không điền hình vào các chỗ giữ.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");

let presentation = new aspose.slides.Presentation();
try {
    let slide = presentation.getSlides().get_Item(0);

    let smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Biểu đồ Cũ sang Nhóm Hình dạng**

Khi hiện đại hoá một bản trình bày hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo ban đầu trong PowerPoint 97–2003. Aspose.Slides biểu diễn các biểu đồ cũ này dưới dạng đối tượng [LegacyDiagram](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/). Sử dụng [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/converttogroupshape/) để chuyển đổi một biểu đồ thành một nhóm hình dạng để bạn có thể chỉnh sửa các yếu tố hình ảnh riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/nodejs-java/aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa biểu đồ gốc. Sau khi chuyển đổi thành công, hãy xóa biểu đồ gốc bằng [ShapeCollection.remove](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/remove/) để tránh nội dung trùng lặp. Thu thập các biểu đồ cũ vào một danh sách trước khi chuyển đổi chúng để việc thêm và xóa hình dạng không làm gián đoạn vòng lặp.

Ví dụ sau mở một bản trình bày, tìm kiếm mọi slide, chuyển đổi các biểu đồ thành nhóm hình dạng, và lưu bản trình bày đã cập nhật dưới dạng PPTX.

```javascript
var aspose = aspose || {};
aspose.slides = require("aspose.slides.via.java");
const java = require("java");

let presentation = new aspose.slides.Presentation("legacy-diagrams.ppt");
try {
    let slides = presentation.getSlides();
    for (let slideIndex = 0; slideIndex < slides.size(); slideIndex++) {
        let slide = slides.get_Item(slideIndex);
        let shapes = slide.getShapes();
        let legacyDiagrams = [];
        for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
            let shape = shapes.get_Item(shapeIndex);
            if (java.instanceOf(shape, "com.aspose.slides.ILegacyDiagram")) {
                legacyDiagrams.push(shape);
            }
        }

        for (let legacyDiagram of legacyDiagrams) {
            let groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                shapes.remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bản trình bày đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay thế cho các biểu đồ cũ đã chuyển đổi, không còn biểu đồ gốc nào còn lại. Mở file PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [SmartArt.setReversed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/setreversed/) chuyển hướng biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm sao tôi có thể sao chép SmartArt vào cùng slide hoặc sang bản trình bày khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [clone hình dạng SmartArt](/slides/vi/nodejs-java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shapecollection/addclone/) hoặc [clone toàn bộ slide](/slides/vi/nodejs-java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi có thể render SmartArt thành hình ảnh raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/nodejs-java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình bày thành PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Sử dụng [Shape.setAlternativeText](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setalternativetext/) hoặc [Shape.setName](https://reference.aspose.com/slides/nodejs-java/aspose.slides/shape/setname/) để gán một văn bản thay thế hoặc tên đặc trưng cho hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getShapes), và sau đó kiểm tra rằng hình dạng khớp là một [SmartArt](https://reference.aspose.com/slides/nodejs-java/aspose.slides/smartart/).