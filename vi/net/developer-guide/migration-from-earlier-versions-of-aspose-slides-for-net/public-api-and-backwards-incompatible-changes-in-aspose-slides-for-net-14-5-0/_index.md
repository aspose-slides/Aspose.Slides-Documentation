---
title: API công cộng và các thay đổi không tương thích ngược trong Aspose.Slides cho .NET 14.5.0
linktitle: Aspose.Slides cho .NET 14.5.0
type: docs
weight: 70
url: /vi/net/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-net-14-5-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- cách tiếp cận kế thừa
- cách tiếp cận hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- .NET
- C#
- Aspose.Slides
description: "Xem xét các cập nhật API công cộng và các thay đổi gây phá vỡ trong Aspose.Slides cho .NET để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các thành phần khác đã được **thêm** vào, mọi **hạn chế** mới và các **thay đổi** khác được giới thiệu trong API Aspose.Slides for .NET 14.5.0.

{{% /alert %}} 
## **Public API and Backwards Incompatible Changes**
### **Added Interfaces, Classes, Properties and Methods**
#### **Added the Aspose.Slides.IPresentationInfo Interface and PresentationInfo Class**
Đại diện thông tin về bản trình chiếu.

- Thuộc tính Boolean IsEncrypted trả về True nếu bản trình chiếu được mã hóa, nếu không trả về False.
- Thuộc tính LoadFormat LoadFormat trả về kiểu của bản trình chiếu.
#### **Added the Aspose.Slides.IShape.IsGrouped Property**
Thuộc tính Aspose.Slides.IShape.IsGrouped xác định xem một hình dạng có được nhóm hay không.
#### **Added the Aspose.Slides.IShape.ParentGroup Property**
Thuộc tính Aspose.Slides.IShape.ParentGroup trả về đối tượng GroupShape cha nếu hình dạng được nhóm. Nếu không, trả về null.
#### **Added the Aspose.Slides.IShapeCollection.AddGroupShape() Method**
Phương thức Aspose.Slides.IShapeCollection.AddGroupShape() tạo một GroupShape mới và thêm nó vào cuối bộ sưu tập.
Kích thước và vị trí khung của GroupShape sẽ được điều chỉnh cho phù hợp với nội dung khi thêm hình dạng mới.
#### **Added the Aspose.Slides.IShapeCollection.Clear() Method**
Phương thức Aspose.Slides.IShapeCollection.Clear() xóa tất cả các hình dạng khỏi bộ sưu tập.
#### **Added the Aspose.Slides.IShapeCollection.InsertGroupShape(int) Method**
Phương thức Aspose.Slides.IShapeCollection.InsertGroupShape(int) tạo một GroupShape mới và chèn nó vào bộ sưu tập tại vị trí chỉ mục đã cho.
Kích thước và vị trí khung của GroupShape sẽ được điều chỉnh cho phù hợp với nội dung khi thêm hình dạng mới.
#### **Added the IPresentationFactory.GetPresentationInfo(string file), IPresentatoinFactory.GetPresentationInfo(Stream stream) Methods**
Các phương thức này cho phép nhận thông tin về tệp hoặc luồng bản trình chiếu mà không cần tải toàn bộ bản trình chiếu.
#### **Added the IPresentationFactory PresentationFactory.Instance Property**
Thuộc tính này cho phép nhà phát triển sử dụng chức năng factory mà không cần khởi tạo.
### **Restrictions**
#### **Restrictions to IShape.Frame**
Đã thêm các hạn chế khi sử dụng các giá trị không xác định cho IShape.Frame. Mã cố gắng gán một khung không xác định cho IShape.Frame thường không có ý nghĩa (đặc biệt khi GroupShape cha được lồng ghép nhiều cấp vào các {{GroupShape}} khác). Ví dụ:

``` csharp

 IShape shape = ...;

shape.Frame = new ShapeFrame(float.NaN, float.NaN, float.NaN, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, float.NaN);


``` 

hoặc

``` csharp

 slide.Shapes.AddAutoShape(ShapeType.RoundCornerRectangle, float.NaN, float.NaN, float.NaN, float.NaN);

``` 

Mã như vậy có thể dẫn đến các tình huống không rõ ràng. Vì vậy đã thêm hạn chế cho việc sử dụng các giá trị không xác định cho IShape.Frame. Các giá trị x, y, width, height, flipH, flipV và rotationAngle phải được xác định (không được đặt thành float.NaN hoặc NullableBool.NotDefined). Mã mẫu ở trên hiện sẽ ném ngoại lệ ArgumentException.
Điều này áp dụng cho các trường hợp sử dụng sau:

``` csharp

 IShape shape = ...;

shape.Frame = ...; // Không được để không xác định

IShapeCollection shapes = ...;

// Các tham số x, y, width, height không được là float.NaN:

{

    shapes.AddAudioFrameCD(...);

    shapes.AddAudioFrameEmbedded(...);

    shapes.AddAudioFrameLinked(...);

    shapes.AddAutoShape(...);

    shapes.AddChart(...);

    shapes.AddConnector(...);

    shapes.AddOleObjectFrame(...);

    shapes.AddPictureFrame(...);

    shapes.AddSmartArt(...);

    shapes.AddTable(...);

    shapes.AddVideoFrame(...);

    shapes.InsertAudioFrameEmbedded(...);

    shapes.InsertAudioFrameLinked(...);

    shapes.InsertAutoShape(...);

    shapes.InsertChart(...);

    shapes.InsertConnector(...);

    shapes.InsertOleObjectFrame(...);

    shapes.InsertPictureFrame(...);

    shapes.InsertTable(...);

    shapes.InsertVideoFrame(...);

}
``` 

Tuy nhiên các thuộc tính khung IShape.RawFrame có thể không xác định. Điều này có ý nghĩa khi một hình dạng được liên kết với một placeholder. Khi đó các giá trị khung không xác định của hình dạng sẽ được ghi đè từ placeholder cha. Nếu không có placeholder cha, hình dạng sẽ sử dụng các giá trị mặc định khi tính khung hiệu quả dựa trên IShape.RawFrame. Các giá trị mặc định là 0 và NullableBool.False cho x, y, width, height, flipH, flipV và rotationAngle. Ví dụ:

``` csharp

 IShape shape = ...; // hình được liên kết với placeholder

shape.RawFrame = new ShapeFrame(float.NaN, float.NaN, 100, float.NaN, NullableBool.NotDefined, NullableBool.NotDefined, 0);

// bây giờ hình kế thừa các giá trị x, y, height, flipH, flipV từ placeholder và ghi đè width=100 và rotationAngle=0.
``` 
### **Changed Properties**
#### **Changed the Aspose.Slides.IShapeCollection.Parent Property Name and Type**
- Kiểu của thuộc tính Aspose.Slides.IShapeCollection.Parent đã được đổi từ ISlideComponent sang giao diện IGroupShape mới. Giao diện IGroupShape kế thừa từ ISlideComponent nên mã hiện có không cần điều chỉnh.
- Tên của thuộc tính Aspose.Slides.IShapeCollection.Parent đã được đổi từ Parent sang ParentGroup.
#### **Changed the Aspose.Slides.IShapeFrame.FlipH, .FlipV Properties Types**
- Kiểu của thuộc tính Aspose.Slides.IShapeFrame.FlipH đã được đổi từ bool sang NullableBool.
- Thuộc tính IShape.Frame trả về một thể hiện hiệu quả của IShapeFrame (tất cả các thuộc tính đều có giá trị hiệu quả được xác định).
- Thuộc tính IShape.RawFrame trả về một thể hiện của IShapeFrame trong đó mỗi thuộc tính có thể không xác định (đặc biệt FlipH hoặc FlipV có thể có giá trị NullableBool.NotDefined).