---
title: Quản lý OLE trong Bản trình bày bằng Java
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/java/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng đối tượng
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
description: "Tối ưu hóa việc quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Note" %}}
OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào ứng dụng khác thông qua liên kết hoặc nhúng.
{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.
- Đối tượng OLE có thể hiển thị nội dung thực tế, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ tải lên, và bạn có thể sửa đổi dữ liệu của biểu đồ trong PowerPoint.

[Aspose.Slides for Java](https://products.aspose.com/slides/java/) cho phép bạn chèn OLE Objects vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame)).

## **Thêm khung đối tượng OLE vào slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Đọc tệp Excel dưới dạng mảng byte.
1. Thêm [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) vào slide chứa mảng byte và các thông tin khác về đối tượng OLE.
1. Ghi bản trình bày đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for Java.
**Lưu ý** rằng bộ tạo [OleEmbeddedDataInfo](https://reference.aspose.com/slides/java/com.aspose.slides/OleEmbeddedDataInfo) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint diễn giải đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

``` java 
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Chuẩn bị dữ liệu cho đối tượng OLE.
byte[] fileData = Files.readAllBytes(Paths.get("book.xlsx"));
IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Thêm khung đối tượng OLE vào slide.
slide.getShapes().addOleObjectFrame(0, 0, (float)slideSize.getWidth(), (float)slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Thêm khung đối tượng OLE liên kết**

Aspose.Slides for Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) mà không nhúng dữ liệu mà chỉ có liên kết tới tệp.

Đoạn mã Java dưới đây cho bạn biết cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame) với tệp Excel được liên kết vào một slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Truy cập khung đối tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/OleObjectFrame).
   Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel nhúng trong slide) và dữ liệu tệp của nó được truy cập.

``` java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Lấy dữ liệu tệp đã nhúng.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Lấy phần mở rộng của tệp đã nhúng.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Truy cập thuộc tính khung đối tượng OLE liên kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Đoạn mã Java dưới đây cho bạn biết cách kiểm tra xem một đối tượng OLE có được liên kết không và sau đó lấy đường dẫn tới tệp liên kết:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (oleFrame.isObjectLink()) {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình bày PPT mới có thể chứa đường dẫn tương đối.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Thay đổi dữ liệu đối tượng OLE**

{{% alert color="info" title="Note" %}}
Trong phần này, đoạn mã mẫu dưới đây sử dụng [Aspose.Cells for Java](https://docs.aspose.com/cells/java/).
{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập hình dạng khung đối tượng OLE.
   Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép kiểu* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/IOleObjectFrame). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập được khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel nhúng trong slide) được truy cập, và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

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

## **Nhúng các loại tệp khác vào slide**

Ngoài biểu đồ Excel, Aspose.Slides for Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn tệp HTML, PDF và ZIP làm đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn chương trình phù hợp để mở.

Đoạn mã Java dưới đây cho bạn biết cách nhúng HTML và ZIP vào một slide:

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

## **Đặt loại tệp cho các đối tượng đã nhúng**

Khi làm việc với bản trình bày, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for Java cho phép bạn đặt loại tệp cho một đối tượng đã nhúng, cho phép bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã Java dưới đây cho bạn biết cách đặt loại tệp cho một đối tượng OLE đã nhúng thành `zip`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();
byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

System.out.println("Current embedded file extension is: " + fileExtension);

// Change the file type to ZIP.
oleFrame.setEmbeddedData(new OleEmbeddedDataInfo(fileData, "zip"));

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt hình ảnh biểu tượng và tiêu đề cho các đối tượng đã nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for Java.

Đoạn mã Java dưới đây cho bạn biết cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Thêm một hình ảnh vào tài nguyên bản trình bày.
byte[] imageData = Files.readAllBytes(Paths.get("image.png"));
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ngăn khung đối tượng OLE bị thay đổi kích thước và vị trí lại**

Sau khi bạn thêm một đối tượng OLE liên kết vào slide bản trình bày, khi mở bản trình bày trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật liên kết. Nhấn nút "Update Links" có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị lời nhắc cập nhật dữ liệu của đối tượng, gọi phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ioleobjectframe/) với `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

oleFrame.setUpdateAutomatic(false);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Trích xuất tệp đã nhúng**

Aspose.Slides for Java cho phép bạn trích xuất các tệp đã nhúng trong slide dưới dạng đối tượng OLE theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/Presentation) chứa các đối tượng OLE bạn muốn trích xuất.
2. Duyệt qua tất cả các hình dạng trong bản trình bày và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/java/com.aspose.slides/oleobjectframe).
3. Truy cập dữ liệu của các tệp đã nhúng từ khung đối tượng OLE và ghi ra đĩa.

Đoạn mã Java dưới đây cho bạn biết cách trích xuất các tệp đã nhúng trong một slide dưới dạng đối tượng OLE:

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

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được render—biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE "sống" không được thực thi trong quá trình render. Nếu cần, đặt hình ảnh xem trước của riêng bạn để đảm bảo giao diện mong muốn trong PDF đã xuất.

Để cũng giữ lại tệp đã nhúng dưới dạng tệp đính kèm PDF, gọi [setIncludeOleData](https://reference.aspose.com/slides/java/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) với `true`. Tùy chọn này mặc định bị tắt. Để xem ví dụ và hướng dẫn kiểm tra tệp đính kèm, xem [Preserve Embedded OLE Files as PDF Attachments](/slides/vi/java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Làm thế nào để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp [shape-level locks](/slides/vi/java/applying-protection-to-presentation/). Đây không phải là mã hóa, nhưng nó ngăn ngừa việc chỉnh sửa và di chuyển ngoài ý muốn.

**Tại sao một đối tượng Excel liên kết "nhảy" hoặc thay đổi kích thước khi tôi mở bản trình bày?**

PowerPoint có thể làm mới bản xem trước của OLE liên kết. Để có giao diện ổn định, hãy làm theo các thực hành [Working Solution for Worksheet Resizing](/slides/vi/java/working-solution-for-worksheet-resizing/)—hoặc điều chỉnh khung cho phù hợp với phạm vi, hoặc tỉ lệ phạm vi vào một khung cố định và đặt hình ảnh thay thế thích hợp.

**Đường dẫn tương đối cho các đối tượng OLE liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin "đường dẫn tương đối" không có—chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ tồn tại trong định dạng PPT cũ. Để di động, nên sử dụng đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.