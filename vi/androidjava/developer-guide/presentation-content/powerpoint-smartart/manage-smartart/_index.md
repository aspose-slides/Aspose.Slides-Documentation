---
title: Quản lý SmartArt trong bản trình chiếu PowerPoint trên Android
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/androidjava/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Loại bố cục
- Thuộc tính ẩn
- Biểu đồ tổ chức
- Biểu đồ tổ chức dạng ảnh
- PowerPoint
- Bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Học cách tạo và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho Android bằng các mẫu mã Java rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một biểu đồ PowerPoint được tạo thành từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for Android qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức dạng ảnh.

## **Lấy văn bản từ một đối tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản hiển thị, duyệt qua [ISmartArt.getAllNodes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartart/#getAllNodes--), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/) được trả về bởi [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

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

## **Thay đổi loại bố cục của một đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ dưới đây tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess` và lưu bản trình chiếu.

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

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartartnode/#isHidden--) cho biết liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử biểu đồ nhìn thấy được.

Ví dụ dưới đây thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType) `RadialCycle` và kiểm tra trạng thái ẩn của nút.

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

Đối với các biểu đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) và [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ phía trái, phải, hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/OrganizationChartLayoutType) đã chọn.

Ví dụ dưới đây tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging`.

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

Biểu đồ tổ chức dạng ảnh là một bố cục SmartArt được thiết kế cho các biểu đồ phân cấp có chứa các vị trí giữ ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide.

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

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Phương thức [ISmartArt.setReversed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) chuyển hướng của biểu đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ nguyên định dạng?**

Bạn có thể [sao chép hình SmartArt](/slides/vi/androidjava/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) hoặc [sao chép toàn bộ slide](/slides/vi/androidjava/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm sao tôi có thể render SmartArt thành ảnh raster để xem trước hoặc xuất web?**

[Render slide](/slides/vi/androidjava/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu thành PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều đối tượng?**

Đặt một giá trị [Shape.getAlternativeText](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getAlternativeText--) hoặc [Shape.getName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getName--) đặc trưng cho hình SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslide/#getShapes--), và sau đó kiểm tra xem hình tương ứng có phải là [ISmartArt](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ismartart/) hay không.