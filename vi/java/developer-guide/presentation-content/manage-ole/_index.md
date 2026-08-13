---
title: Quản lý OLE trong Bản trình bày bằng Java
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/java/manage-ole/
keywords:
- Đối tượng OLE
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
- bản trình bày
- Java
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument với Aspose.Slides cho Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" %}} 

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng tạo ra trong một ứng dụng được đặt trong một ứng dụng khác thông qua liên kết hoặc nhúng. 

{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên và bạn có thể sửa đổi dữ liệu biểu đồ ngay trong PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/vi/java/) cho phép bạn chèn các Đối tượng OLE vào slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleObjectFrame)).

## **Thêm Khung Đối tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
1. Lấy tham chiếu tới slide thông qua chỉ mục của nó.  
1. Đọc tệp Excel dưới dạng mảng byte.  
1. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleObjectFrame) vào slide cùng với mảng byte và các thông tin khác về đối tượng OLE.  
1. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.  

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Java.  
**Lưu ý** rằng hàm khởi tạo [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleEmbeddedDataInfo) nhận phần mở rộng của đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint giải thích đúng loại tệp và chọn ứng dụng thích hợp để mở đối tượng OLE này.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Thêm Khung Đối tượng OLE Liên kết**

Aspose.Slides for Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleObjectFrame) mà không nhúng dữ liệu, chỉ với liên kết tới tệp.

Mã Java dưới đây cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleObjectFrame) có liên kết tới tệp Excel vào slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm một khung đối tượng OLE với tệp Excel được liên kết.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Truy cập Khung Đối tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu tới slide bằng cách sử dụng chỉ mục của nó.  
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/OleObjectFrame).  
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IOleObjectFrame). Đây là khung đối tượng OLE mong muốn để truy cập.  
4. Khi khung đối tượng OLE đã được truy cập, bạn có thể thực hiện bất kỳ thao tác nào trên nó.  

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Lấy dữ liệu tệp được nhúng.
    // Lấy phần mở rộng của tệp được nhúng.
    // ...
}
```

### **Truy cập Thuộc tính Khung Đối tượng OLE Liên kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Mã Java dưới đây cho thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame.isObjectLink()) {
        // In ra đường dẫn đầy đủ tới tệp liên kết.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // In ra đường dẫn tương đối tới tệp liên kết nếu có.
        // Chỉ các bản trình bày PPT mới có thể chứa đường dẫn tương đối.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Thay đổi Dữ liệu Đối tượng OLE**

{{% alert color="info" %}} 

Trong phần này, ví dụ mã dưới đây sử dụng [Aspose.Cells for Java](/cells/java/). 

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.  
3. Truy cập hình dạng khung đối tượng OLE.  
   Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IOleObjectFrame). Đây là khung đối tượng OLE mong muốn để truy cập.  
4. Khi khung đối tượng OLE đã được truy cập, bạn có thể thực hiện bất kỳ thao tác nào trên nó.  
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.  
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.  
7. Lưu `Workbook` đã cập nhật vào một luồng.  
8. Thay đổi dữ liệu đối tượng OLE từ luồng.  

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

``` java 
import com.aspose.slides.*;
import com.aspose.cells.Workbook;
import com.aspose.cells.OoxmlSaveOptions;
import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    ByteArrayInputStream oleStream = new ByteArrayInputStream(oleFrame.getEmbeddedData().getEmbeddedFileData());

    // Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
    Workbook workbook = new Workbook(oleStream);

    ByteArrayOutputStream newOleStream = new ByteArrayOutputStream();

    // Sửa đổi dữ liệu workbook.
    workbook.getWorksheets().get(0).getCells().get(0, 4).putValue("E");
    workbook.getWorksheets().get(0).getCells().get(1, 4).putValue(12);
    workbook.getWorksheets().get(0).getCells().get(2, 4).putValue(14);
    workbook.getWorksheets().get(0).getCells().get(3, 4).putValue(15);

    OoxmlSaveOptions fileOptions = new OoxmlSaveOptions(com.aspose.cells.SaveFormat.XLSX);
    workbook.save(newOleStream, fileOptions);

    // Thay đổi dữ liệu đối tượng khung OLE.
    IOleEmbeddedDataInfo newData = new OleEmbeddedDataInfo(newOleStream.toByteArray(), oleFrame.getEmbeddedData().getEmbeddedFileExtension());
    oleFrame.setEmbeddedData(newData);
}

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Nhúng Các Loại Tệp Khác vào Slide**

Ngoài các biểu đồ Excel, Aspose.Slides for Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình tương ứng, hoặc người dùng sẽ được nhắc chọn một chương trình phù hợp để mở nó.

Mã Java dưới đây cho thấy cách nhúng HTML và ZIP vào một slide:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

byte[] htmlData = Files.readAllBytes(Paths.get("sample.html"));
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

byte[] zipData = Files.readAllBytes(Paths.get("sample.zip"));
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt Loại Tệp cho Đối tượng Nhúng**

Khi làm việc với bản trình bày, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Java cho phép bạn đặt loại tệp cho một đối tượng được nhúng, giúp bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Mã Java dưới đây cho thấy cách đặt loại tệp cho một đối tượng OLE được nhúng thành `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Thay đổi loại tệp thành ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt Hình ảnh Biểu tượng và Tiêu đề cho Đối tượng Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng nhìn thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm các yếu tố trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Java.

Mã Java dưới đây cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng được nhúng:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Thêm một hình ảnh vào tài nguyên của bản trình bày.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ngăn Khung Đối tượng OLE bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE liên kết vào slide của bản trình bày, khi mở bản trình bày trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật liên kết. Nhấn nút "Update Links" có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị yêu cầu cập nhật dữ liệu của đối tượng, đặt phương thức `setUpdateAutomatic` của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioleobjectframe/) thành `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Trích xuất Các Tệp Được Nhúng**

Aspose.Slides for Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) chứa các đối tượng OLE bạn muốn trích xuất.  
2. Duyệt qua tất cả các hình dạng trong bản trình bày và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/oleobjectframe).  
3. Truy cập dữ liệu của các tệp được nhúng từ các khung đối tượng OLE và ghi chúng ra đĩa.  

Mã Java dưới đây cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        Path filePath = Paths.get("OLE_object_" + index + fileExtension);
        Files.write(filePath, fileData);
    }
}

presentation.dispose();
```

## **Câu hỏi thường gặp**

### Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?

Những gì hiển thị trên slide sẽ được render—biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE "sống" không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh bản xem trước riêng của bạn để đảm bảo hiển thị mong muốn trong PDF đã xuất.

### Làm sao để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?

Khóa hình dạng: Aspose.Slides cung cấp [khóa ở mức hình dạng](/slides/vi/java/applying-protection-to-presentation/). Đây không phải là mã hoá, nhưng nó ngăn việc chỉnh sửa hoặc di chuyển tình cờ.

### Tại sao một đối tượng Excel liên kết "nhảy" hoặc thay đổi kích thước khi tôi mở bản trình bày?

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để có giao diện ổn định, hãy tuân theo các thực hành [Giải pháp hoạt động cho việc thay đổi kích thước Worksheet](/slides/vi/java/working-solution-for-worksheet-resizing/)—hoặc vừa khung với phạm vi, hoặc co phạm vi vào khung cố định và đặt hình ảnh thay thế phù hợp.

### Các đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ lại trong định dạng PPTX không?

Trong PPTX, thông tin "đường dẫn tương đối" không có—chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để di động, hãy ưu tiên sử dụng các đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.