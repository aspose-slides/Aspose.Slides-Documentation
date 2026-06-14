---
title: Quản lý SmartArt trong Bản trình chiếu PowerPoint bằng Java
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/java/manage-smartart/
keywords:
- SmartArt
- văn bản SmartArt
- loại bố cục
- thuộc tính ẩn
- biểu đồ tổ chức
- biểu đồ tổ chức dạng ảnh
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint với Aspose.Slides cho Java bằng các mẫu mã rõ ràng, giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng ảnh.

## **Lấy văn bản từ đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, lặp qua [ISmartArt.getAllNodes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartart/#getAllNodes--), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/) trả về bởi [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartartshape/#getTextFrame--).

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Thay đổi loại bố cục của đối tượng SmartArt**

Bố cục SmartArt điều khiển cách các nút được sắp xếp và kết nối. Ví dụ dưới đây tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bài thuyết trình.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra một nút SmartArt có bị ẩn hay không**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartartnode/#isHidden--) cho biết nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử sơ đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` và kiểm tra trạng thái ẩn của nút.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy hoặc đặt bố cục biểu đồ tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) và [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo bên trái, bên phải hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OrganizationChartLayoutType) đã chọn.

Ví dụ dưới đây tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo biểu đồ tổ chức dạng ảnh**

Biểu đồ tổ chức dạng ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các khung ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Phương thức [ISmartArt.setReversed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartart/#setReversed-boolean-) chuyển hướng sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bài thuyết trình khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) hoặc [sao chép toàn slide](/slides/vi/java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao để render SmartArt thành hình raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/java/convert-powerpoint-to-png/) hoặc toàn bộ bài thuyết trình sang PNG hoặc JPEG. SmartArt sẽ được render như một phần của slide.

**Làm sao tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều đối tượng?**

Đặt một giá trị [Shape.getAlternativeText](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getAlternativeText--) hoặc [Shape.getName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getName--) đặc trưng cho hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/#getShapes--), sau đó kiểm tra xem hình dạng khớp có phải là [ISmartArt](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ismartart/) hay không.