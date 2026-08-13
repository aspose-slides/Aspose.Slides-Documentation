---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides for Java 14.5.0
linktitle: Aspose.Slides cho Java 14.5.0
type: docs
weight: 40
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- di chuyển
- mã cũ
- mã hiện đại
- cách tiếp cận cũ
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây gián đoạn trong Aspose.Slides for Java để di chuyển mượt mà các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thứ khác [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), bất kỳ [hạn chế](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) mới được giới thiệu cùng với API Aspose.Slides for Java 14.5.0.

{{% /alert %}} 
## **API công cộng và các thay đổi không tương thích ngược**
### **Các lớp và phương thức được thêm**
#### **Đã thêm giao diện Aspose.Slides.IPresentationInfo và các lớp PresentationInfo**
Biểu diễn thông tin về bản trình chiếu.

Phương thức Boolean isEncrypted() trả về True nếu bản trình chiếu được mã hóa, nếu không trả về False.

Phương thức LoadFormat getLoadFormat() trả về loại bản trình chiếu.
#### **Đã thêm phương thức Aspose.Slides.IShape.isGrouped()**
Phương thức Aspose.Slides.IShape.isGrouped() xác định xem hình dạng có được nhóm hay không.
#### **Đã thêm phương thức Aspose.Slides.IShape.getParentGroup()**
Phương thức Aspose.Slides.IShape.getParentGroup() trả về đối tượng GroupShape cha nếu hình dạng được nhóm. Nếu không, nó trả về null.
#### **Đã thêm phương thức Aspose.Slides.IShapeCollection.addGroupShape()**
Phương thức Aspose.Slides.IShapeCollection.addGroupShape() tạo một GroupShape mới và thêm nó vào cuối bộ sưu tập.

Kích thước và vị trí khung GroupShape sẽ được điều chỉnh theo nội dung khi hình dạng mới được thêm vào GroupShape.
#### **Đã thêm phương thức Aspose.Slides.IShapeCollection.clear()**
Phương thức Aspose.Slides.IShapeCollection.clear() loại bỏ tất cả các hình dạng khỏi bộ sưu tập.
#### **Đã thêm phương thức Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Phương thức Aspose.Slides.IShapeCollection.insertGroupShape(int) tạo một GroupShape mới và chèn nó vào bộ sưu tập tại chỉ mục được chỉ định.

Kích thước và vị trí khung GroupShape sẽ được điều chỉnh theo nội dung khi hình dạng mới được thêm vào GroupShape.
#### **Đã thêm các phương thức IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Các phương thức này cho phép các nhà phát triển nhận thông tin về tệp/phân luồng bản trình chiếu mà không cần tải toàn bộ bản trình chiếu.
#### **Đã thêm phương thức IPresentationFactory PresentationFactory.getInstance()**
Cho phép sử dụng chức năng của nhà máy mà không cần khởi tạo.
### **Hạn chế**
#### **Đã thêm hạn chế cho việc sử dụng các giá trị không xác định cho IShape.getFrame()**
Mã cố gắng gán một khung không xác định cho IShape.setFrame(IShapeFrame) không có ý nghĩa trong các trường hợp chung (đặc biệt khi GroupShape cha được lồng nhiều lần trong các {{GroupShape}} khác). Ví dụ:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    IShape shape = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 200, 100);

    // Ném ra một ArgumentException: các giá trị khung phải được xác định.
    shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));
} finally {
    if (pres != null) pres.dispose();
}
```

hoặc

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    ISlide slide = pres.getSlides().get_Item(0);

    // Ném ra một ArgumentException: các giá trị x, y, width và height phải được xác định.
    slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);
} finally {
    if (pres != null) pres.dispose();
}
```

Mã như vậy có thể dẫn đến các tình huống không rõ ràng. Do đó đã thêm các hạn chế cho việc sử dụng các giá trị không xác định cho IShape.Frame. Các giá trị x, y, width, height, flipH, flipV và rotationAngle phải được xác định (không phải Float.NaN hoặc NullableBool.NotDefined). Mã mẫu ở trên hiện sẽ ném ra ngoại lệ ArgumentException.
Điều này áp dụng cho các trường hợp sử dụng sau:

``` java
// Khung được truyền vào IShape.setFrame(IShapeFrame) không được chứa các giá trị không xác định.

// Các tham số x, y, width và height của các phương thức IShapeCollection sau
// cũng không được là Float.NaN:
//
//     addAudioFrameCD
//     addAudioFrameEmbedded
//     addAudioFrameLinked
//     addAutoShape
//     addChart
//     addConnector
//     addOleObjectFrame
//     addPictureFrame
//     addSmartArt
//     addTable
//     addVideoFrame
//     insertAudioFrameEmbedded
//     insertAudioFrameLinked
//     insertAutoShape
//     insertChart
//     insertConnector
//     insertOleObjectFrame
//     insertPictureFrame
//     insertTable
//     insertVideoFrame
```

Nhưng khung IShape.getRawFrame() có thể không được xác định. Điều này hợp lý khi một hình dạng được liên kết với một placeholder. Khi đó các giá trị khung không xác định của hình dạng sẽ được ghi đè từ placeholder cha. Nếu không có placeholder cha cho hình dạng đó, nó sẽ sử dụng các giá trị mặc định khi đánh giá khung hiệu lực dựa trên IShape.getRawFrame() của nó. Các giá trị mặc định là 0 và NullableBool.False cho x, y, width, height, flipH, flipV và rotationAngle. Ví dụ:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("pres.pptx");
try {
    // Hình dạng được liên kết với một placeholder.
    IShape shape = pres.getSlides().get_Item(0).getShapes().get_Item(0);

    shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

    // Bây giờ hình dạng kế thừa các giá trị x, y, height, flipH và flipV từ placeholder
    // và ghi đè width = 100 và rotationAngle = 0.
} finally {
    if (pres != null) pres.dispose();
}
```
### **Thuộc tính đã thay đổi**
#### **Đã thay đổi Kiểu và Tên của phương thức Aspose.Slides.IShapeCollection.getParent()**
Kiểu của thuộc tính Aspose.Slides.IShapeCollection.Parent đã được thay đổi từ ISlideComponent sang giao diện IGroupShape mới. Giao diện IGroupShape là một phần tử con của ISlideComponent nên mã hiện có không cần điều chỉnh.

Tên của phương thức Aspose.Slides.IShapeCollection.getParent() đã được thay đổi từ getParent thành getParentGroup().
#### **Thay đổi Kiểu của các phương thức Aspose.Slides.IShapeFrame.getFlipH() và .getFlipV()**
Kiểu của phương thức Aspose.Slides.IShapeFrame.getFlipH() đã được thay đổi từ bool sang NullableBool.

Phương thức IShape.getFrame() trả về một thể hiện hiệu lực của IShapeFrame (tất cả các thuộc tính của nó đều có giá trị hiệu lực đã được xác định).

Phương thức IShape.getRawFrame() trả về một thể hiện IShapeFrame mà mỗi thuộc tính có thể có giá trị không xác định (đặc biệt FlipH hoặc FlipV có thể có giá trị NullableBool.NotDefined).