---
title: Quản lý OLE trong Bản trình chiếu bằng PHP
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/php-java/manage-ole/
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
- PHP
- Aspose.Slides
description: "Tối ưu hóa quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument với Aspose.Slides cho PHP qua Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="info" title="Note" %}}

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt vào một ứng dụng khác thông qua việc liên kết hoặc nhúng. 

{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể xuất hiện dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên kết (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng.  
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ được tải, và bạn có thể chỉnh sửa dữ liệu của biểu đồ ngay trong PowerPoint.  

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/php-java/) cho phép bạn chèn OLE Objects vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/)).

## **Thêm Khung Đối Tượng OLE vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for PHP via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó.
3. Đọc tệp Excel dưới dạng mảng byte.
4. Thêm [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) vào slide, chứa mảng byte và các thông tin khác về đối tượng OLE.
5. Ghi bản trình bày đã sửa đổi thành tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for PHP via Java. **Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/php-java/aspose.slides/oleembeddeddatainfo/) nhận một phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint giải thích đúng kiểu tệp và chọn ứng dụng phù hợp để mở đối tượng OLE này.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Chuẩn bị dữ liệu cho đối tượng OLE.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Thêm khung đối tượng OLE vào slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Thêm Khung Đối Tượng OLE Liên Kết**

Aspose.Slides for PHP via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) mà không nhúng dữ liệu mà chỉ với một liên kết tới tệp.

Đoạn mã PHP này cho thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào một slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Truy Cập Khung Đối Tượng OLE**

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể dễ dàng tìm hoặc truy cập nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ mục của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng file PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên.
4. Sau khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung đối tượng OLE (một đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Lấy dữ liệu tệp đã nhúng.
    // Lấy phần mở rộng của tệp đã nhúng.
    // ...
}
```

### **Truy Cập Thuộc Tính Khung Đối Tượng OLE Liên Kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung đối tượng OLE liên kết.

Đoạn mã PHP này cho thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // In ra đường dẫn đầy đủ tới tệp được liên kết.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // In ra đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản thuyết trình PPT mới có thể chứa đường dẫn tương đối.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Thay Đổi Dữ Liệu Đối Tượng OLE**

{{% alert color="info" title="Note" %}}

Trong phần này, đoạn mã ví dụ dưới đây sử dụng [Aspose.Cells for PHP via Java](https://docs.aspose.com/cells/php-java/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách này:

1. Tải một bản trình bày có đối tượng OLE được nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ mục của nó. 
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi đã sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên.
4. Sau khi đã truy cập khung đối tượng OLE, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và chỉnh sửa dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một stream.
8. Thay đổi dữ liệu của đối tượng OLE từ stream.

Trong ví dụ dưới đây, một khung đối tượng OLE (một đối tượng biểu đồ Excel được nhúng trong slide) được truy cập, và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new Java("java.io.ByteArrayInputStream", $oleFrame->getEmbeddedData()->getEmbeddedFileData());

    // Đọc dữ liệu đối tượng OLE dưới dạng đối tượng Workbook.
    $workbook = new Workbook($oleStream);

    $newOleStream = new Java("java.io.ByteArrayOutputStream");

    // Sửa đổi dữ liệu workbook.
    $workbook->getWorksheets()->get(0)->getCells()->get(0, 4)->putValue("E");
    $workbook->getWorksheets()->get(0)->getCells()->get(1, 4)->putValue(12);
    $workbook->getWorksheets()->get(0)->getCells()->get(2, 4)->putValue(14);
    $workbook->getWorksheets()->get(0)->getCells()->get(3, 4)->putValue(15);

    $fileOptions = new OoxmlSaveOptions(SaveFormat::XLSX);
    $workbook->save($newOleStream, $fileOptions);

    // Thay đổi dữ liệu đối tượng khung OLE.
    $newData = new OleEmbeddedDataInfo($newOleStream->toByteArray(), $oleFrame->getEmbeddedData()->getEmbeddedFileExtension());
    $oleFrame->setEmbeddedData($newData);

    $newOleStream->close();
    $oleStream->close();
}

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Nhúng Các Kiểu Tệp Khác vào Slide**

Ngoài biểu đồ Excel, Aspose.Slides for PHP via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn các tệp HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn một chương trình phù hợp để mở nó.

Đoạn mã PHP này cho thấy cách nhúng HTML và ZIP vào một slide:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$htmlData = file_get_contents("sample.html");
$htmlDataInfo = new OleEmbeddedDataInfo($htmlData, "html");
$htmlOleFrame = $slide->getShapes()->addOleObjectFrame(150, 120, 50, 50, $htmlDataInfo);
$htmlOleFrame->setObjectIcon(true);

$zipData = file_get_contents("sample.zip");
$zipDataInfo = new OleEmbeddedDataInfo($zipData, "zip");
$zipOleFrame = $slide->getShapes()->addOleObjectFrame(150, 220, 50, 50, $zipDataInfo);
$zipOleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Đặt Kiểu Tệp cho Các Đối Tượng Được Nhúng**

Khi làm việc với bản trình bày, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không được hỗ trợ bằng một đối tượng được hỗ trợ. Aspose.Slides for PHP via Java cho phép bạn đặt kiểu tệp cho một đối tượng được nhúng, cho phép bạn cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã PHP này cho thấy cách đặt kiểu tệp cho một đối tượng OLE được nhúng thành `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Change the file type to ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Đặt Hình Ảnh Biểu Tượng và Tiêu Đề cho Các Đối Tượng Được Nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được thêm tự động. Bản xem trước này là những gì người dùng thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm các thành phần trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng cách sử dụng Aspose.Slides cho PHP qua Java.

Đoạn mã PHP này cho thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng được nhúng:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Thêm hình ảnh vào tài nguyên của bản trình chiếu.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ngăn Khung Đối Tượng OLE bị Thay Đổi Kích Thước và Vị Trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào một slide trình chiếu, khi mở bản trình bày trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấp vào nút "Update Links" có thể thay đổi kích thước và vị trí của khung đối tượng OLE vì PowerPoint cập nhật dữ liệu từ đối tượng OLE được liên kết và làm mới bản xem trước của đối tượng. Để ngăn PowerPoint hiển thị lời nhắc cập nhật dữ liệu của đối tượng, gọi phương thức [setUpdateAutomatic](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/#setUpdateAutomatic) của lớp [OleObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/) với `false`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$oleFrame->setUpdateAutomatic(false);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Trích Xuất Các Tệp Được Nhúng**

Aspose.Slides for PHP via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng đối tượng OLE theo cách này:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/php-java/aspose.slides/presentation/) chứa các đối tượng OLE mà bạn muốn trích xuất.
2. Duyệt qua tất cả các hình dạng trong bản trình bày và truy cập các hình dạng [OLEObjectFrame](https://reference.aspose.com/slides/php-java/aspose.slides/oleobjectframe/).
3. Truy cập dữ liệu của các tệp được nhúng từ khung đối tượng OLE và ghi chúng ra đĩa.

Đoạn mã PHP này cho thấy cách trích xuất các tệp được nhúng trong một slide dưới dạng đối tượng OLE:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);

$shapeCount = java_values($slide->getShapes()->size());
for ($index = 0; $index < $shapeCount; $index++) {
    $shape = $slide->getShapes()->get_Item($index);

    if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
        $oleFrame = $shape;

        $fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();
        $fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();

        $filePath = "OLE_object_" . $index . $fileExtension;
        file_put_contents($filePath, $fileData);
    }
}

$presentation->dispose();
```

## **Câu hỏi thường gặp**

**Nội dung OLE có được hiển thị khi xuất slide sang PDF/hình ảnh không?**

Những gì hiển thị trên slide sẽ được render — biểu tượng/hình ảnh thay thế (bản xem trước). Nội dung OLE "sống" không được thực thi trong quá trình render. Nếu cần, hãy đặt hình ảnh xem trước riêng của bạn để đảm bảo giao diện mong muốn trong PDF đã xuất.

Để cũng bảo tồn tệp được nhúng dưới dạng tệp đính kèm PDF, gọi [setIncludeOleData](https://reference.aspose.com/slides/php-java/aspose.slides/pdfoptions/#setIncludeOleData) với `true`. Tùy chọn này mặc định bị tắt. Đối với ví dụ và hướng dẫn kiểm tra tệp đính kèm, xem [Bảo Lưu Các Tệp OLE Được Nhúng Là Tệp Đính Kèm PDF](/slides/vi/php-java/convert-powerpoint-to-pdf/#preserve-embedded-ole-files-as-pdf-attachments).

**Làm thế nào để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**

Khóa hình dạng: Aspose.Slides cung cấp các khóa ở cấp độ hình dạng. Đây không phải là mã hoá, nhưng nó thực sự ngăn ngừa việc chỉnh sửa hoặc di chuyển vô tình.

**Các đường dẫn tương đối cho các đối tượng OLE được liên kết có được giữ lại trong định dạng PPTX không?**

Trong PPTX, thông tin "đường dẫn tương đối" không có sẵn — chỉ có đường dẫn đầy đủ. Các đường dẫn tương đối chỉ có trong định dạng PPT cũ. Để đảm bảo di động, nên ưu tiên sử dụng các đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.