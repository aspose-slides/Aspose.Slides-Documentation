---
title: Quản lý SmartArt trong Bản trình chiếu PowerPoint bằng JavaScript
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/nodejs-java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức dạng ảnh
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho Node.js bằng các mẫu mã JavaScript rõ ràng, giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một biểu đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides cho Node.js qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức, và tạo biểu đồ tổ chức dạng ảnh.

## **Lấy Văn bản từ Đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, lặp qua [SmartArt.getAllNodes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/#getAllNodes--), sau đó đọc [TextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textframe/) được trả về bởi [SmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartshape/#getTextFrame--).

```javascript
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
    }
} finally {
    presentation.dispose();
}
```

## **Thay đổi Loại Bố cục của Đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(aspose.slides.SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra Nút SmartArt Có bị Ẩn hay không**

[SmartArtNode.isHidden](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartnode/ishidden/) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử biểu đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.RadialCycle);

    let node = smartArt.getAllNodes().addNode();
    let isHidden = node.isHidden();

    if (isHidden) {
        console.log("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy hoặc Đặt Bố cục Biểu đồ Tổ chức**

Đối với các biểu đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [SmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartnode/#getOrganizationChartLayout--) và [SmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartnode/#setOrganizationChartLayout-int-) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo ở phía trái, phải, hoặc cả hai, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/organizationchartlayouttype/).

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/organizationchartlayouttype/) `LeftHanging`.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, aspose.slides.SmartArtLayoutType.OrganizationChart);

    let rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(aspose.slides.OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo Biểu đồ Tổ chức dạng Ảnh**

Biểu đồ tổ chức dạng ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp bao gồm các vị trí giữ ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide.

```javascript
let presentation = new aspose.slides.Presentation();
try {
    let smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, aspose.slides.SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Đúng. Phương thức [SmartArt.setReversed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/setreversed/) chuyển hướng biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm thế nào tôi có thể sao chép SmartArt vào cùng một slide hoặc vào bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình SmartArt](/slides/vi/nodejs-java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/addclone/) hoặc [sao chép toàn bộ slide](/slides/vi/nodejs-java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm thế nào để render SmartArt thành ảnh raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/nodejs-java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên một slide nếu có nhiều?**

Đặt một giá trị [Shape.setAlternativeText](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/setalternativetext/) hoặc [Shape.setName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/setname/) đặc trưng trên hình SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getShapes), và sau đó kiểm tra xem hình khớp có phải là một [SmartArt](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/smartart/) không.