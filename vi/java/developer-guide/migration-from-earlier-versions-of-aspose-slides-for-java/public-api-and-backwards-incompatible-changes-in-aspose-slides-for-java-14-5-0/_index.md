---
title: API Công cộng và Các Thay đổi Không Tương thích Ngược trong Aspose.Slides cho Java 14.5.0
linktitle: Aspose.Slides cho Java 14.5.0
type: docs
weight: 40
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp truyền thống
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công cộng và những thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [đã thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/), bất kỳ [hạn chế](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-5-0/) mới được giới thiệu trong Aspose.Slides for Java 14.5.0 API.

{{% /alert %}} 
## **API Công khai và Thay đổi Không tương thích ngược**
### **Các lớp và phương thức đã thêm**
#### **Thêm giao diện Aspose.Slides.IPresentationInfo và các lớp PresentationInfo**
Biểu diễn thông tin về bản trình bày.

Phương thức Boolean isEncrypted() trả về True nếu bản trình bày được mã hoá, nếu không trả về False.

Phương thức LoadFormat getLoadFormat() trả về loại bản trình bày.
#### **Thêm phương thức Aspose.Slides.IShape.isGrouped()**
Phương thức Aspose.Slides.IShape.isGrouped() xác định xem hình dạng có được nhóm hay không.
#### **Thêm phương thức Aspose.Slides.IShape.getParentGroup()**
Phương thức Aspose.Slides.IShape.getParentGroup() trả về đối tượng GroupShape cha nếu hình dạng được nhóm. Nếu không, nó trả về null.
#### **Thêm phương thức Aspose.Slides.IShapeCollection.addGroupShape()**
Phương thức Aspose.Slides.IShapeCollection.addGroupShape() tạo một GroupShape mới và thêm nó vào cuối bộ sưu tập.

Kích thước và vị trí khung của GroupShape sẽ được điều chỉnh phù hợp với nội dung khi hình dạng mới được thêm vào GroupShape.
#### **Thêm phương thức Aspose.Slides.IShapeCollection.clear()**
Phương thức Aspose.Slides.IShapeCollection.clear() loại bỏ tất cả các hình dạng khỏi bộ sưu tập.
#### **Thêm phương thức Aspose.Slides.IShapeCollection.insertGroupShape(int)**
Phương thức Aspose.Slides.IShapeCollection.insertGroupShape(int) tạo một GroupShape mới và chèn nó vào bộ sưu tập tại chỉ mục được chỉ định.

Kích thước và vị trí khung của GroupShape sẽ được điều chỉnh phù hợp với nội dung khi hình dạng mới được thêm vào GroupShape.
#### **Thêm các phương thức IPresentationFactory.getPresentationInfo(string file), IPresentatoinFactory.getPresentationInfo(InputStream stream)**
Các phương thức này cho phép các nhà phát triển nhận thông tin về tệp/băng truyền bản trình bày mà không cần tải toàn bộ bản trình bày.
#### **Thêm phương thức IPresentationFactory PresentationFactory.getInstance()**
Cho phép sử dụng chức năng của nhà máy mà không cần khởi tạo.
### **Hạn chế**
#### **Đã thêm hạn chế cho việc sử dụng các giá trị không xác định cho IShape.getFrame()**
Mã cố gắng gán một khung không xác định cho IShape.setFrame(IShapeFrame) không có ý nghĩa trong các trường hợp chung (đặc biệt khi GroupShape cha được lồng nhiều lần trong các {{GroupShape}} khác). Ví dụ:

``` java

 IShape shape = ...;

shape.setFrame(new ShapeFrame(Float.NaN, Float.NaN, Float.NaN, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, Float.NaN));

```

hoặc

``` java

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, Float.NaN, Float.NaN, Float.NaN, Float.NaN);

```

Mã như vậy có thể dẫn đến các tình huống không rõ ràng. Vì vậy đã thêm hạn chế cho việc sử dụng các giá trị không xác định cho IShape.Frame. Các giá trị x, y, width, height, flipH, flipV và rotationAngle phải được xác định (không phải Float.NaN hoặc NullableBool.NotDefined). Mã mẫu trên hiện sẽ ném ra ngoại lệ ArgumentException.
Điều này áp dụng cho các trường hợp sử dụng sau:

``` java

 IShape shape = ...;

shape.setFrame(...); // không thể là không xác định

IShapeCollection shapes = ...;

// các tham số x, y, width, height không được là Float.NaN:

{

    shapes.addAudioFrameCD(...);

    shapes.addAudioFrameEmbedded(...);

    shapes.addAudioFrameLinked(...);

    shapes.addAutoShape(...);

    shapes.addChart(...);

    shapes.addConnector(...);

    shapes.addOleObjectFrame(...);

    shapes.addPictureFrame(...);

    shapes.addSmartArt(...);

    shapes.addTable(...);

    shapes.addVideoFrame(...);

    shapes.insertAudioFrameEmbedded(...);

    shapes.insertAudioFrameLinked(...);

    shapes.insertAutoShape(...);

    shapes.insertChart(...);

    shapes.insertConnector(...);

    shapes.insertOleObjectFrame(...);

    shapes.insertPictureFrame(...);

    shapes.insertTable(...);

    shapes.insertVideoFrame(...);

}

```

Nhưng khung IShape.getRawFrame() có thể không xác định. Điều này có ý nghĩa khi một hình dạng được liên kết với một placeholder. Khi đó các giá trị khung không xác định của hình dạng sẽ được ghi đè từ hình dạng placeholder cha. Nếu không có placeholder cha cho hình dạng đó, nó sẽ sử dụng các giá trị mặc định khi đánh giá khung hiệu quả dựa trên IShape.getRawFrame() của nó. Các giá trị mặc định là 0 và NullableBool.False cho x, y, width, height, flipH, flipV và rotationAngle. Ví dụ:

``` java

 IShape shape = ...; // hình dạng được liên kết với placeholder

shape.setRawFrame(new ShapeFrame(Float.NaN, Float.NaN, 100, Float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0));

// bây giờ hình dạng kế thừa các giá trị x, y, height, flipH, flipV từ placeholder và ghi đè width=100 và rotationAngle=0.

```
### **Thuộc tính đã thay đổi**
#### **Thay đổi Kiểu và Tên của phương thức Aspose.Slides.IShapeCollection.getParent()**
Kiểu của thuộc tính Aspose.Slides.IShapeCollection.Parent đã được thay đổi từ ISlideComponent sang giao diện IGroupShape mới. Giao diện IGroupShape là một kế thừa của ISlideComponent nên mã hiện có không cần điều chỉnh.

Tên của phương thức Aspose.Slides.IShapeCollection.getParent() đã được thay đổi từ getParent sang getParentGroup().
#### **Thay đổi Kiểu của các phương thức Aspose.Slides.IShapeFrame.getFlipH() và .getFlipV()**
Kiểu của phương thức Aspose.Slides.IShapeFrame.getFlipH() đã được thay đổi từ bool sang NullableBool.

Phương thức IShape.getFrame() trả về một thể hiện hiệu quả của IShapeFrame (tất cả các thuộc tính của nó đều có giá trị hiệu quả đã được xác định).

Phương thức IShape.getRawFrame() trả về một thể hiện IShapeFrame mà mỗi thuộc tính có thể có giá trị không xác định (đặc biệt FlipH hoặc FlipV có thể có giá trị NullableBool.NotDefined).