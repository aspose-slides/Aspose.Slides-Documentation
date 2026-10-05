---
title: Quản lý OLE trong Bản trình chiếu trên Android
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/androidjava/manage-ole/
keywords:
- đối tượng OLE
- Liên kết & Nhúng Đối tượng
- thêm OLE
- nhúng OLE
- thêm đối tượng
- nhúng đối tượng
- thêm tệp
- nhúng tệp
- đối tượng được liên kết
- tệp được liên kết
- thay đổi OLE
- biểu tượng OLE
- tiêu đề OLE
- trích xuất OLE
- trích xuất đối tượng
- trích xuất tệp
- PowerPoint
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Tối ưu hóa quản lý đối tượng OLE trong PowerPoint và các tệp OpenDocument với Aspose.Slides cho Android qua Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Lưu ý" %}}
OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào ứng dụng khác thông qua liên kết hoặc nhúng. 
{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt trong một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.  
- Một đối tượng OLE có thể hiển thị nội dung thực của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ được tải, và bạn có thể chỉnh sửa dữ liệu của biểu đồ trong PowerPoint.  

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/androidjava/) cho phép bạn chèn OLE Objects vào các slide như các khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame)).

## **Thêm Khung Đối tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for Android via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) vào slide kèm theo mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi trình chiếu đã sửa đổi dưới dạng tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for Android via Java. **Lưu ý** rằng [OleEmbeddedDataInfo](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleEmbeddedDataInfo) được truyền vào phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint diễn giải đúng loại tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```java 
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
Dimension2D slideSize = presentation.getSlideSize().getSize();
ISlide slide = presentation.getSlides().get_Item(0);

// Prepare data for the OLE object.
File file = new File("book.xlsx");
byte fileData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(fileData);

IOleEmbeddedDataInfo dataInfo = new OleEmbeddedDataInfo(fileData, "xlsx");

// Add the OLE object frame to the slide.
slide.getShapes().addOleObjectFrame(0, 0, (float) slideSize.getWidth(), (float) slideSize.getHeight(), dataInfo);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

### **Thêm Khung Đối tượng OLE Liên kết**

Aspose.Slides for Android via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) mà không nhúng dữ liệu mà chỉ với một liên kết tới tệp.

Đoạn mã Java này cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame) với tệp Excel được liên kết vào một slide:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
slide.getShapes().addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Truy cập Khung Đối tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách sau:

1. Tải một trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/OleObjectFrame). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó chỉ có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập vào khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong một slide) và dữ liệu tệp của nó được truy cập.

```java 
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;
    
    // Lấy dữ liệu tệp được nhúng.
    byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();

    // Lấy phần mở rộng của tệp được nhúng.
    String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

    // ...
}
```

### **Truy cập Thuộc tính Khung Đối tượng OLE Liên kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE được liên kết.

Đoạn mã Java này cho thấy cách kiểm tra xem một đối tượng OLE có phải được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.ppt");
ISlide slide = presentation.getSlides().get_Item(0);
IShape shape = slide.getShapes().get_Item(0);

if (shape instanceof IOleObjectFrame) {
    IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

    // Kiểm tra xem đối tượng OLE có được liên kết không.
    if (oleFrame.isObjectLink()) {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        System.out.println("OLE object frame is linked to: " + oleFrame.getLinkPathLong());

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình chiếu PPT mới có thể chứa đường dẫn tương đối.
        if (oleFrame.getLinkPathRelative() != null && !oleFrame.getLinkPathRelative().isEmpty()) {
            System.out.println("OLE object frame relative path: " + oleFrame.getLinkPathRelative());
        }
    }
}

presentation.dispose();
```

## **Thay đổi Dữ liệu Đối tượng OLE**

{{% alert color="info" title="Lưu ý" %}}
Trong phần này, đoạn mã mẫu dưới đây sử dụng [Aspose.Cells for Android via Java](https://docs.aspose.com/cells/androidjava/).
{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách sau:

1. Tải một trình chiếu có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập hình dạng khung đối tượng OLE. Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước đó chỉ có một hình dạng trên slide đầu tiên. Sau đó chúng tôi *ép* đối tượng đó thành một [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/). Đây là khung đối tượng OLE mong muốn để truy cập.
4. Khi đã truy cập vào khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một luồng.
8. Thay đổi dữ liệu đối tượng OLE từ luồng.

Trong ví dụ dưới đây, một khung đối tượng OLE (đối tượng biểu đồ Excel được nhúng trong một slide) được truy cập, và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```java 
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

Ngoài các biểu đồ Excel, Aspose.Slides cho Android via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn các tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được yêu cầu chọn một chương trình thích hợp để mở.

Đoạn mã Java này cho thấy cách nhúng HTML và ZIP vào một slide:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

File fileHtml = new File("sample.html");
byte htmlData[] = new byte[(int) fileHtml.length()];
BufferedInputStream bisHtml = new BufferedInputStream(new FileInputStream(fileHtml));
DataInputStream disHtml = new DataInputStream(bisHtml);
disHtml.readFully(htmlData);
IOleEmbeddedDataInfo htmlDataInfo = new OleEmbeddedDataInfo(htmlData, "html");
IOleObjectFrame htmlOleFrame = slide.getShapes().addOleObjectFrame(150, 120, 50, 50, htmlDataInfo);
htmlOleFrame.setObjectIcon(true);

File fileZip = new File("sample.zip");
byte zipData[] = new byte[(int) fileZip.length()];
BufferedInputStream bisZip = new BufferedInputStream(new FileInputStream(fileZip));
DataInputStream disZip = new DataInputStream(bisZip);
disZip.readFully(zipData);
IOleEmbeddedDataInfo zipDataInfo = new OleEmbeddedDataInfo(zipData, "zip");
IOleObjectFrame zipOleFrame = slide.getShapes().addOleObjectFrame(150, 220, 50, 50, zipDataInfo);
zipOleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Đặt Loại Tệp cho Các Đối Tượng Nhúng**

Khi làm việc với các bản trình chiếu, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides cho Android via Java cho phép bạn đặt loại tệp cho một đối tượng được nhúng, cho phép cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã Java này cho thấy cách đặt loại tệp cho một đối tượng OLE được nhúng thành `zip`:

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

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề cho Các Đối Tượng Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng cách sử dụng Aspose.Slides cho Android via Java.

Đoạn mã Java này cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng được nhúng:

```java
import com.aspose.slides.*;
import java.io.BufferedInputStream;
import java.io.DataInputStream;
import java.io.File;
import java.io.FileInputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);
IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

// Thêm hình ảnh vào tài nguyên của bản trình chiếu.
File file = new File("image.png");
byte imageData[] = new byte[(int) file.length()];
BufferedInputStream bis = new BufferedInputStream(new FileInputStream(file));
DataInputStream dis = new DataInputStream(bis);
dis.readFully(imageData);
IPPImage oleImage = presentation.getImages().addImage(imageData);

// Set a title and the image for the OLE preview.
oleFrame.setSubstitutePictureTitle("My title");
oleFrame.getSubstitutePictureFormat().getPicture().setImage(oleImage);
oleFrame.setObjectIcon(true);

presentation.save("output.pptx", SaveFormat.Pptx);
presentation.dispose();
```

## **Ngăn Khung Đối Tượng OLE bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào một slide của bản trình chiếu, khi mở bản trình chiếu trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấp vào nút "Update Links" có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE được liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint yêu cầu cập nhật dữ liệu của đối tượng, hãy gọi phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/#setUpdateAutomatic-boolean-) của giao diện [IOleObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ioleobjectframe/) với `false`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IOleObjectFrame oleFrame = (IOleObjectFrame) slide.getShapes().get_Item(0);

    oleFrame.setUpdateAutomatic(false);

    presentation.save("output.pptx", SaveFormat.Pptx);
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Trích Xuất Các Tệp Đã Nhúng**

Aspose.Slides cho Android via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng các đối tượng OLE theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/Presentation) chứa các đối tượng OLE bạn muốn trích xuất.
2. Lặp qua tất cả các hình dạng trong bản trình chiếu và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/oleobjectframe).
3. Truy cập dữ liệu của các tệp đã nhúng từ các khung đối tượng OLE và ghi chúng lên đĩa.

Đoạn mã Java này cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng các đối tượng OLE:

```java
import com.aspose.slides.*;
import java.io.File;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("sample.pptx");
ISlide slide = presentation.getSlides().get_Item(0);

for (int index = 0; index < slide.getShapes().size(); index++) {
    IShape shape = slide.getShapes().get_Item(index);

    if (shape instanceof IOleObjectFrame) {
        IOleObjectFrame oleFrame = (IOleObjectFrame) shape;

        byte[] fileData = oleFrame.getEmbeddedData().getEmbeddedFileData();
        String fileExtension = oleFrame.getEmbeddedData().getEmbeddedFileExtension();

        FileOutputStream fos = new FileOutputStream(new File("OLE_object_" + index + fileExtension));
        fos.write(fileData);
        fos.close();
    }
}

presentation.dispose();
```

## **FAQ**

**Nội dung OLE có được kết xuất khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được kết xuất — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE "sống" không được thực thi trong quá trình kết xuất. Nếu cần, hãy đặt hình ảnh xem trước riêng của bạn để đảm bảo giao diện mong muốn trong PDF đã xuất.

Để cũng giữ lại tệp đã nhúng như một tệp đính kèm PDF, gọi [setIncludeOleData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/pdfoptions/#setIncludeOleData-boolean-) với `true`. Tùy chọn này mặc định bị tắt. Để xem ví dụ và hướng dẫn kiểm tra tệp đính kèm, xem [Preserve Embedded OLE Files as PDF Attachments](/slides/vi/androidjava/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Làm thế nào để khóa một đối tượng OLE trên slide sao cho người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp khóa ở mức hình dạng. Đây không phải là mã hoá, nhưng nó thực sự ngăn ngừa việc chỉnh sửa hoặc di chuyển vô ý.

**Tại sao một đối tượng Excel được liên kết lại "nhảy" hoặc thay đổi kích thước khi tôi mở bản trình chiếu?**

PowerPoint có thể làm mới bản xem trước của OLE được liên kết. Để có giao diện ổn định, hãy tham khảo các thực hành trong [Working Solution for Worksheet Resizing](/slides/vi/androidjava/working-solution-for-worksheet-resizing/) — hoặc điều chỉnh khung cho phù hợp với phạm vi, hoặc thu phóng phạm vi vào một khung cố định và đặt hình ảnh thay thế phù hợp.

**Các đường dẫn tương đối cho các đối tượng OLE được liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin "đường dẫn tương đối" không có sẵn — chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ xuất hiện trong định dạng PPT cũ. Để dễ di chuyển, nên sử dụng các đường dẫn tuyệt đối đáng tin cậy / URI có thể truy cập hoặc nhúng.