---
title: API công khai và các thay đổi không tương thích ngược trong Aspose.Slides cho Java 14.9.0
linktitle: Aspose.Slides cho Java 14.9.0
type: docs
weight: 80
url: /vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/
keywords:
- di chuyển
- mã legacy
- mã hiện đại
- phương pháp legacy
- phương pháp hiện đại
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Xem xét các cập nhật API công khai và các thay đổi gây phá vỡ trong Aspose.Slides cho Java để di chuyển suôn sẻ các giải pháp trình chiếu PowerPoint PPT, PPTX và ODP của bạn."
---
{{% alert color="primary" %}} 

Trang này liệt kê tất cả các lớp, phương thức, thuộc tính và các mục tương tự đã được [added](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/), bất kỳ hạn chế mới nào và các [changes](/slides/vi/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-14-9-0/) khác được giới thiệu với API Aspose.Slides for Java 14.9.0.

{{% /alert %}} 
## **Thay đổi API công khai**
### **Các phương thức được thêm để thay thế Image bằng PPImage, IPPImage**
Các phương thức mới được thêm:

- IPPImage.replaceImage(byte[] newImageData)
- IPPImage.replaceImage(IPPImage newImage)

``` java

 Presentation presentation = new Presentation("presentation.pptx");

//Cách đầu tiên

byte[] imageData = // ...

presentation.getImages().get_Item(0).replaceImage(imageData);

//Cách thứ hai

presentation.getImages().get_Item(1).replaceImage(

    presentation.getImages().get_Item(0));

presentation.save("presentation_out.pptx", SaveFormat.Pptx);

```
### **Các phương thức được thêm để lưu Slides giữ số trang**
Các phương thức sau đã được thêm:

- void IPresentation.save(string fname, int[] slides, SaveFormat format);
- void IPresentation.save(string fname, int[] slides, SaveFormat format, ISaveOption options);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format);
- void IPresentation.save(Stream stream, int[] slides, SaveFormat format, ISaveOption options);

Các phương thức này cho phép lưu các slide trình chiếu được chỉ định sang các định dạng PDF, XPS, TIFF, HTML. Mảng 'slides' cho phép chỉ định số trang, bắt đầu từ 1.

``` java

 save(string fname, int\[\] slides, SaveFormat format);

```




``` java

 Presentation presentation = new Presentation(presentationFileName);

int[] slides = new int[] { 2, 3, 5 }; //Mảng các vị trí slide

presentation.save(outFileName, slides, SaveFormat.Pdf);

```
### **Đã thêm giá trị Enum SmartArtLayoutType.Custom**
Loại bố cục SmartArt này đại diện cho sơ đồ với mẫu tùy chỉnh. Các sơ đồ tùy chỉnh chỉ có thể được tải từ tệp trình chiếu và không thể được tạo thông qua phương thức ShapeCollection.addSmartArt(x, y, width, height, SmartArtLayoutType.Custom)
### **Đã thêm lớp SmartArtShape và giao diện ISmartArtShape**
Lớp Aspose.Slides.SmartArt.SmartArtShape (và giao diện Aspose.Slides.SmartArt.ISmartArtShape) thêm khả năng truy cập vào các hình dạng riêng lẻ trong sơ đồ SmartArt. SmartArtShape có thể được sử dụng để thay đổi FillFormat, LineFormat, thêm Hyperlinks, v.v.

{{% alert color="primary" %}} 

SmartArtShape không hỗ trợ các thuộc tính IShape RawFrame, Frame, Rotation, X, Y, Width, Height và sẽ ném System.NotSupportedException khi cố gắng truy cập chúng.

{{% /alert %}} 

Ví dụ sử dụng:

``` java

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
Lớp Aspose.Slides.SmartArt.SmartArtShapeCollection (và giao diện Aspose.Slides.SmartArt.ISmartArtShapeCollection) thêm khả năng truy cập vào các hình dạng riêng lẻ trong sơ đồ SmartArt. Bộ sưu tập chứa các hình dạng liên kết với SmartArtNode. Thuộc tính SmartArtNode.Shapes trả về tập hợp tất cả các hình dạng liên kết với nút.

{{% alert color="primary" %}} 

Tuỳ thuộc vào SmartArtLayoutType, một SmartArtShape có thể được chia sẻ giữa nhiều nút.

{{% /alert %}} 

 
``` java

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