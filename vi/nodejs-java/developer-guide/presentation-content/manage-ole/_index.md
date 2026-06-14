---
title: Quản lý OLE trong Bản trình chiếu bằng JavaScript
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/nodejs-java/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng Đối tượng
- thêm OLE
- nhúng OLE
- thêm đối tượng
- nhúng đối tượng
- thêm tệp
- nhúng tệp
- đối tượng liên kết
- tệp liên kết
- thay đổi OLE
- biểu tượng OLE
- tiêu đề OLE
- trích xuất OLE
- trích xuất đối tượng
- trích xuất tệp
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho Node.js qua Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào một ứng dụng khác thông qua liên kết hoặc nhúng. 

{{% /alert %}} 

Xem một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ mở ra trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể chỉnh sửa dữ liệu biểu đồ trong PowerPoint.

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/vi/nodejs-java/) cho phép bạn chèn OLE Objects vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleObjectFrame)).

## **Thêm Khung Đối Tượng OLE vào Các Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Node.js via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).  
1. Lấy tham chiếu tới slide thông qua chỉ mục của nó.  
1. Đọc tệp Excel dưới dạng mảng byte.  
1. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleObjectFrame) vào slide chứa mảng byte và các thông tin khác về đối tượng OLE.  
1. Ghi bản trình chiếu đã chỉnh sửa thành tệp PPTX.  

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Node.js via Java.  
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleEmbeddedDataInfo) nhận phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint diễn giải đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```javascript
var presentation = new asposeSlides.Presentation();
var slideSize = presentation.getSlideSize().getSize();
var slide = presentation.getSlides().get_Item(0);

// Chuẩn bị dữ liệu cho đối tượng OLE.
var oleStream = fs.readFileSync("book.xlsx");
var fileData = Array.from(oleStream);
var dataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", fileData), "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, slideSize.getWidth(), slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

### **Thêm Khung Đối Tượng OLE Liên Kết**

Aspose.Slides for Node.js via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleObjectFrame) mà không nhúng dữ liệu mà chỉ có liên kết tới tệp.

Mã JavaScript dưới đây cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleObjectFrame) với tệp Excel được liên kết vào một slide:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Truy Cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).  
2. Lấy tham chiếu tới slide bằng cách sử dụng chỉ mục của nó.  
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/OleObjectFrame). Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên.  
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.  

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;
    
    // Lấy dữ liệu tệp được nhúng.
    var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Lấy phần mở rộng của tệp được nhúng.
    var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Truy Cập Thuộc Tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Mã JavaScript dưới đây cho thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```javascript
var presentation = new asposeSlides.Presentation("sample.ppt");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame.isObjectLink()) {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        console.log("OLE object frame is linked to:", oleFrame.getLinkPathLong());

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
        if (oleFrame.getLinkPathRelative() != null && oleFrame.getLinkPathRelative() != "") {
            console.log("OLE object frame relative path:", oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="primary" %}} 

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).  
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.  
3. Truy cập hình dạng khung đối tượng OLE. Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên.  
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.  
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.  
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.  
7. Lưu `Workbook` đã cập nhật vào một luồng.  
8. Thay đổi dữ liệu đối tượng OLE từ luồng.  

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var shape = slide.getShapes().get_Item(0);

if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
    var oleFrame = shape;

    var oleStream = java.newInstanceSync("java.io.ByteArrayInputStream", oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
    var workbook = java.newInstanceSync("Workbook", oleStream);

    var newOleStream = java.newInstanceSync("java.io.ByteArrayOutputStream");

    // Sửa đổi dữ liệu workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    var fileOptions = java.newInstanceSync("OoxmlSaveOptions", java.getStaticFieldValue("com.aspose.cells.SaveFormat", "XLSX"));
    workbook.save(newOleStream, fileOptions);

    // Thay đổi dữ liệu đối tượng khung OLE.
    var newData = new asposeSlides.OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);

    newOleStream.close();
    oleStream.close();
}

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Nhúng Các Kiểu Tệp Khác Vào Các Slide**

Ngoài biểu đồ Excel, Aspose.Slides for Node.js via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn một chương trình phù hợp để mở.

Mã JavaScript dưới đây cho thấy cách nhúng HTML và ZIP vào một slide:

```javascript
var presentation = new asposeSlides.Presentation();
var slide = presentation.getSlides().get_Item(0);

var htmlBuffer = fs.readFileSync("sample.html");
var htmlData = Array.from(htmlBuffer);
var htmlDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", htmlData), "html");
var htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

var zipBuffer = fs.readFileSync("sample.zip");
var zipData = Array.from(zipBuffer);
var zipDataInfo = new asposeSlides.OleEmbeddedDataInfo(java.newArray("byte", zipData), "zip");
var zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt Kiểu Tệp Cho Đối Tượng Được Nhúng**

Khi làm việc với bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Node.js via Java cho phép bạn đặt kiểu tệp cho một đối tượng được nhúng, cho phép bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Mã JavaScript dưới đây cho thấy cách đặt kiểu tệp cho một đối tượng OLE đã nhúng thành `zip`:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
var oleFileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

console.log("Current embedded file extension is:", fileExtension);

// Thay đổi kiểu tệp thành ZIP.
var fileData = java.newArray("byte", Array.from(oleFileData));
oleFrame.setEmbeddedData(new asposeSlides.OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề Cho Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước bao gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Node.js via Java.

Mã JavaScript dưới đây cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);
var oleFrame = slide.getShapes().get_Item(0);

// Thêm hình ảnh vào tài nguyên của bản trình chiếu.
var image = asposeSlides.Images.fromFile("image.png");
var oleImage = presentation.getImages().addImage(image);
image.dispose();

// Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", asposeSlides.SaveFormat.Pptx);
presentation.dispose();
```

## **Ngăn Không Cho Khung Đối Tượng OLE Bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào slide trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấn nút "Update Links" có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị yêu cầu cập nhật dữ liệu của đối tượng, hãy sử dụng phương thức `setUpdateAutomatic` của lớp [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe/) với giá trị `false`:

```javascript
oleFrame.setUpdateAutomatic(false);
```

## **Trích Xuất Các Tệp Được Nhúng**

Aspose.Slides for Node.js via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) chứa các đối tượng OLE bạn muốn trích xuất.  
2. Duyệt qua tất cả các hình dạng trong bản trình chiếu và truy cập các hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/oleobjectframe).  
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi chúng ra đĩa.  

Mã JavaScript dưới đây cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```javascript
var presentation = new asposeSlides.Presentation("sample.pptx");
var slide = presentation.getSlides().get_Item(0);

for (var index = 0; index < slide.getShapes().size(); index++) {
    var shape = slide.getShapes().get_Item(index);

    if (java.instanceOf(shape, "com.aspose.slides.OleObjectFrame")) {
        var oleFrame = shape;

        var fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        var fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        var filePath = "OLE_object_" + index + fileExtension;
        fs.writeFileSync(filePath, Buffer.from(fileData));
    }
}

presentation.dispose();
```

## **FAQ**

**Nội dung OLE có được hiển thị khi xuất slide thành PDF/ảnh không?**

Những gì hiển thị trên slide sẽ được xuất – biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE “sống” không được thực thi trong quá trình xuất. Nếu cần, hãy đặt hình ảnh xem trước riêng để đảm bảo hiển thị mong muốn trong PDF đã xuất.

**Làm sao tôi có thể khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp các khóa ở mức hình dạng. Đây không phải là mã hóa, nhưng thực sự ngăn ngừa việc chỉnh sửa và di chuyển vô tình.

**Các đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ nguyên trong định dạng PPTX không?**

Trong PPTX, thông tin “đường dẫn tương đối” không có – chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để tăng khả năng di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.