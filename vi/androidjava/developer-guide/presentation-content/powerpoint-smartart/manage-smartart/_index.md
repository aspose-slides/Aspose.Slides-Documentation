---
title: Quản lý SmartArt trong bản trình chiếu PowerPoint trên Android
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/androidjava/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Kiểu bố cục
- Thuộc tính ẩn
- Biểu đồ tổ chức
- Biểu đồ tổ chức có hình ảnh
- PowerPoint
- Bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tìm hiểu cách tạo và chỉnh sửa SmartArt trong PowerPoint bằng Aspose.Slides cho Android thông qua các mẫu mã Java rõ ràng, giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo thành từ các nút, hình dạng nút và bố cục. Với Aspose.Slides for Android qua Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức, và tạo biểu đồ tổ chức có hình ảnh.

## **Lấy văn bản từ một đối tượng SmartArt**

A SmartArt node can contain one or more shapes. Để đọc văn bản từ các hình dạng nút, lặp lại qua [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) trả về bởi [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt là hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản khả dụng ra console.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **Thay đổi loại bố cục của một đối tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList`, thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu. Vị trí và kích thước truyền cho [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) được đo bằng điểm. Sử dụng [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) để thay đổi bố cục.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm tra xem một nút SmartArt có bị ẩn hay không**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) chỉ ra liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các phần tử sơ đồ có thể nhìn thấy.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` và kiểm tra trạng thái ẩn của nút vừa thêm. Nó in một thông báo nếu nút bị ẩn và lưu sơ đồ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Lấy hoặc đặt bố cục biểu đồ tổ chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) và [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) định nghĩa cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo ở phía trái, phải, hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/).

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging`. Chỉ mục dựa trên zero `0` chọn nút cấp cao nhất đầu tiên; các nút con của nó sử dụng sắp xếp đã chọn. Bản trình chiếu đã được sửa đổi sau đó được lưu.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Tạo biểu đồ tổ chức có hình ảnh**

Một biểu đồ tổ chức có hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp bao gồm các trình giữ chỗ hình ảnh. Sử dụng giá trị [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` khi thêm đối tượng SmartArt vào một slide. Ví dụ này lưu một sơ đồ với các trình giữ chỗ hình ảnh; nó không điền các trình giữ chỗ bằng hình ảnh.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi sơ đồ kế thừa thành nhóm hình dạng**

Khi hiện đại hóa một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo ban đầu trong PowerPoint 97–2003. Aspose.Slides đại diện cho các sơ đồ kế thừa này dưới dạng các đối tượng [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) . Sử dụng [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) để chuyển đổi một sơ đồ thành một nhóm hình dạng để bạn có thể chỉnh sửa các yếu tố trực quan riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không loại bỏ sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) để tránh nội dung trùng lặp. Thu thập các sơ đồ kế thừa vào một danh sách trước khi chuyển đổi chúng để việc thêm và xóa hình dạng không gây gián đoạn vòng lặp.

Ví dụ sau mở một bản trình chiếu, tìm kiếm trên mọi slide, chuyển đổi các sơ đồ thành nhóm hình dạng, và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bản trình chiếu đã lưu sẽ chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ kế thừa đã được chuyển đổi, mà không còn sơ đồ gốc nào còn lại bên cạnh chúng. Mở tệp PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền, hoặc vị trí.

## **Câu hỏi thường gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho các ngôn ngữ RTL không?**

Có. Phương thức [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) thay đổi hướng của sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ việc đảo ngược.

**Làm sao tôi có thể sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/androidjava/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) hoặc [sao chép toàn bộ slide](/slides/vi/androidjava/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm thế nào để kết xuất SmartArt thành hình raster để xem trước hoặc xuất ra web?**

Bạn có thể [Kết xuất slide](/slides/vi/androidjava/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu thành PNG hoặc JPEG. SmartArt được kết xuất như một phần của slide.

**Làm sao tôi tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Sử dụng [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) hoặc [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) để gán một văn bản thay thế hoặc tên đặc trưng cho hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) và sau đó kiểm tra xem hình dạng khớp có phải là một [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/) hay không.