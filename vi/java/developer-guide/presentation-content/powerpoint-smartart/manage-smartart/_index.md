---
title: Quản lý SmartArt trong Bản Trình Chiếu PowerPoint bằng Java
linktitle: Quản lý SmartArt
type: docs
weight: 10
url: /vi/java/manage-smartart/
keywords:
- SmartArt
- Văn bản SmartArt
- Kiểu bố cục
- Thuộc tính ẩn
- Biểu đồ tổ chức
- Biểu đồ tổ chức hình ảnh
- PowerPoint
- bản trình chiếu
- Java
- Aspose.Slides
description: "Học cách xây dựng và chỉnh sửa SmartArt PowerPoint với Aspose.Slides cho Java bằng các mẫu mã rõ ràng giúp tăng tốc thiết kế slide và tự động hoá."
---
## **Tổng quan**

SmartArt là một sơ đồ PowerPoint được tạo từ các nút, hình dạng nút và bố cục. Với Aspose.Slides cho Java, bạn có thể tạo SmartArt, đọc văn bản từ các nút của nó, thay đổi bố cục, kiểm tra các nút ẩn, cấu hình bố cục biểu đồ tổ chức và tạo biểu đồ tổ chức có ảnh.

## **Lấy Văn Bản từ Đối Tượng SmartArt**

Một nút SmartArt có thể chứa một hoặc nhiều hình dạng. Để đọc văn bản từ các hình dạng của nút, lặp qua [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--), sau đó đọc [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) trả về bởi [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--).

Ví dụ yêu cầu một bản trình chiếu có ít nhất một slide và một đối tượng SmartArt là hình dạng đầu tiên trên slide đó. Nó in mỗi khung văn bản có sẵn ra console.

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

## **Thay Đổi Kiểu Bố Cục của Đối Tượng SmartArt**

Bố cục SmartArt kiểm soát cách các nút được sắp xếp và kết nối. Ví dụ sau tạo một đối tượng SmartArt với giá trị `BasicBlockList` của [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/), thay đổi nó thành giá trị `BasicProcess`, và lưu bản trình chiếu. Vị trí và kích thước được truyền vào [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) được đo bằng điểm. Sử dụng [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) để thay đổi bố cục.

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

## **Kiểm Tra Liệu Nút SmartArt Có Bị Ẩn Không**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) cho biết liệu nút có bị ẩn trong mô hình dữ liệu SmartArt hay không. Các nút ẩn có thể tồn tại trong cấu trúc ngay cả khi bố cục đã chọn không hiển thị chúng như các thành phần biểu đồ nhìn thấy được.

Ví dụ sau thêm một nút vào đối tượng SmartArt sử dụng giá trị `RadialCycle` của [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) và kiểm tra trạng thái ẩn của nút vừa thêm. Nó in một thông báo nếu nút bị ẩn và lưu sơ đồ.

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

## **Lấy hoặc Đặt Bố Cục Biểu Đồ Tổ Chức**

Đối với các sơ đồ SmartArt sử dụng bố cục biểu đồ tổ chức, [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) và [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) xác định cách các nút con được sắp xếp dưới một nút cha. Ví dụ, bạn có thể đặt các nút con treo từ trái, phải, hoặc cả hai bên, tùy thuộc vào [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) đã chọn.

Ví dụ sau tạo một biểu đồ tổ chức và đặt bố cục cho nút đầu tiên thành giá trị `LeftHanging` của [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/). Chỉ mục bắt đầu từ 0 (`0`) chọn nút cấp cao nhất đầu tiên; các nút con của nó sử dụng cách sắp xếp đã chọn. Bản trình chiếu đã chỉnh sửa sau đó được lưu.

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

## **Tạo Biểu Đồ Tổ Chức Hình Ảnh**

Biểu đồ tổ chức hình ảnh là một bố cục SmartArt được thiết kế cho các sơ đồ phân cấp có chứa các vị trí giữ chỗ hình ảnh. Sử dụng giá trị `PictureOrganizationChart` của [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) khi thêm đối tượng SmartArt vào một slide. Ví dụ này lưu một sơ đồ với các vị trí giữ chỗ hình ảnh; nó không điền ảnh vào các vị trí này.

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

## **Chuyển Đổi Sơ Đồ Cũ Thành Nhóm Hình Dạng**

Khi hiện đại hóa một bản trình chiếu hiện có, bạn có thể cần cập nhật một biểu đồ tổ chức được tạo ban đầu trong PowerPoint 97–2003. Aspose.Slides biểu diễn các sơ đồ cũ này dưới dạng các đối tượng [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/). Sử dụng [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) để chuyển một sơ đồ thành một nhóm hình dạng để bạn có thể chỉnh sửa các yếu tố trực quan riêng lẻ. Xem [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) để biết chi tiết.

Quá trình chuyển đổi sẽ thêm một nhóm mới vào bộ sưu tập hình dạng mà không xóa bỏ sơ đồ gốc. Sau khi chuyển đổi thành công, hãy xóa bản gốc bằng [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) để tránh nội dung trùng lặp. Thu thập các sơ đồ cũ vào một danh sách trước khi chuyển đổi chúng để việc thêm và xóa hình dạng không làm gián đoạn vòng lặp.

Ví dụ sau mở một bản trình chiếu, tìm kiếm mọi slide, chuyển đổi các sơ đồ thành nhóm hình dạng, và lưu bản trình chiếu đã cập nhật dưới dạng PPTX.

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

Bản trình chiếu đã lưu chứa các nhóm hình dạng có thể chỉnh sửa thay cho các sơ đồ cũ đã chuyển đổi, không còn sơ đồ gốc nào còn lại. Mở PPTX trong PowerPoint để chỉnh sửa các yếu tố riêng lẻ trong mỗi nhóm, chẳng hạn như văn bản, màu nền hoặc vị trí của chúng.

## **Câu Hỏi Thường Gặp**

**SmartArt có hỗ trợ phản chiếu hoặc đảo ngược cho ngôn ngữ RTL không?**

Có. Phương thức [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) chuyển hướng của sơ đồ từ trái sang phải sang phải sang trái, hoặc ngược lại, khi bố cục SmartArt đã chọn hỗ trợ đảo ngược.

**Làm thế nào để sao chép SmartArt vào cùng một slide hoặc sang bản trình chiếu khác mà vẫn giữ định dạng?**

Bạn có thể [sao chép hình dạng SmartArt](/slides/vi/java/shape-manipulations/) bằng [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) hoặc [sao chép toàn bộ slide](/slides/vi/java/clone-slides/) chứa SmartArt. Cả hai cách đều giữ nguyên kích thước, vị trí và định dạng.

**Làm thế nào để render SmartArt thành hình ảnh raster để xem trước hoặc xuất ra web?**

[Render slide](/slides/vi/java/convert-powerpoint-to-png/) hoặc toàn bộ bản trình chiếu sang PNG hoặc JPEG. SmartArt được render như một phần của slide.

**Làm sao tôi có thể tìm một đối tượng SmartArt cụ thể trên slide nếu có nhiều?**

Sử dụng [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) hoặc [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) để gán một văn bản thay thế hoặc tên đặc trưng cho hình dạng SmartArt, tìm kiếm giá trị đó trong [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) , và sau đó kiểm tra rằng hình dạng khớp là một [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/).