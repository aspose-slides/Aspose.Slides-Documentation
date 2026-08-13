---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.9.0
linktitle: Aspose.Slides cho Java 14.9.0
type: docs
weight: 80
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- di chuyển
- mã kế thừa
- mã hiện đại
- phương pháp kế thừa
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Xem lại các cập nhật API công khai và các thay đổi gây gián đoạn trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp bản trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="info" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục khác [được thêm](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), bất kỳ hạn chế mới nào và các [thay đổi](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) được giới thiệu cùng với API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Các phương thức được thêm để thay thế Image bằng PPImage, IPPImage**
Các phương thức mới được thêm:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("presentation.pptx");
try {
    // Cách đầu tiên
    byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
    presentation.getImages().get_Item(0).replaceImage(imageData);

    // Cách thứ hai
    presentation.getImages().get_Item(1).replaceImage(presentation.getImages().get_Item(0));

    presentation.save("presentation_out.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Các phương thức được thêm để lưu slide giữ lại số trang**
Các phương thức sau đã được thêm:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Các phương thức này cho phép lưu các slide đã chỉ định của bản trình chiếu sang định dạng PDF, XPS, TIFF, HTML. Mảng 'slides' cho phép chỉ định số trang, bắt đầu từ 1.

``` java
// Các phiên bản overload được thêm vào IPresentation (các giá trị SaveFormat là hằng số int trong Java):
//
// void save(String fname, int[] slides, int format);
// void save(String fname, int[] slides, int format, ISaveOptions options);
// void save(OutputStream stream, int[] slides, int format);
// void save(OutputStream stream, int[] slides, int format, ISaveOptions options);
```




``` java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    int[] slides = new int[] { 2, 3, 5 }; // Mảng các vị trí slide

    presentation.save("presentation_out.pdf", slides, SaveFormat.Pdf);
} finally {
    if (presentation != null) presentation.dispose();
}
```
### **Đã thêm giá trị Enum SmartArtLayoutType.Custom**
Kiểu bố trí SmartArt này đại diện cho sơ đồ với mẫu tùy chỉnh. Các sơ đồ tùy chỉnh chỉ có thể được tải từ tệp bản trình chiếu và không thể tạo bằng phương thức ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Đã thêm lớp SmartArtShape và giao diện ISmartArtShape**
Lớp Aspose.Slides.SmartArt.SmartArtShape (và giao diện Aspose.Slides.SmartArt.ISmartArtShape) cung cấp quyền truy cập vào các hình dạng riêng lẻ bên trong sơ đồ SmartArt. SmartArtShape có thể được sử dụng để thay đổi FillFormat, LineFormat, thêm siêu liên kết, v.v.

{{% alert color="info" %}} 

SmartArtShape không hỗ trợ các thuộc tính IShape RawFrame, Frame, Rotation, X, Y, Width, Height và sẽ ném System.NotSupportedException khi cố gắng truy cập chúng.

{{% /alert %}} 

Ví dụ sử dụng:

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```
### **Đã thêm lớp SmartArtShapeCollection, giao diện ISmartArtShapeCollection và phương thức ISmartArtNode.getShapes()**
Lớp Aspose.Slides.SmartArt.SmartArtShapeCollection (và giao diện Aspose.Slides.SmartArt.ISmartArtShapeCollection) cung cấp quyền truy cập vào các hình dạng riêng lẻ trong sơ đồ SmartArt. Bộ sưu tập chứa các hình dạng liên kết với SmartArtNode. Thuộc tính SmartArtNode.Shapes trả về tập hợp của tất cả các hình dạng liên quan đến nút.

{{% alert color="info" %}} 

Tùy thuộc vào SmartArtLayoutType, một SmartArtShape có thể được chia sẻ giữa nhiều nút.

{{% /alert %}} 

``` java
import com.aspose.slides.*;
import java.awt.Color;


 Presentation pres = new Presentation();

ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

ISmartArtNode node = smart.getAllNodes().get_Item(0);

for (ISmartArtShape shape : node.getShapes())

{

    shape.getFillFormat().setFillType(FillType.Solid);

    shape.getFillFormat().getSolidFillColor().setColor(Color.RED);

}

pres.save("out.pptx", SaveFormat.Pptx);

```