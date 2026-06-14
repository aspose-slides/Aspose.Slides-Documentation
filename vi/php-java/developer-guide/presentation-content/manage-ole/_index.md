---
title: Quản lý OLE trong bản trình chiếu bằng PHP
linktitle: Quản lý OLE
type: docs
weight: 40
url: /vi/php-java/manage-ole/
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
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tối ưu hóa việc quản lý đối tượng OLE trong các tệp PowerPoint và OpenDocument với Aspose.Slides for PHP via Java. Nhúng, cập nhật và xuất nội dung OLE một cách liền mạch."
---
## **Giới thiệu**

{{% alert color="primary" %}} 

OLE (Object Linking & Embedding) là công nghệ của Microsoft cho phép dữ liệu và đối tượng được tạo trong một ứng dụng được đặt trong một ứng dụng khác thông qua liên kết hoặc nhúng. 

{{% /alert %}} 

Xem xét một biểu đồ được tạo trong MS Excel. Biểu đồ này sau đó được đặt vào một slide PowerPoint. Biểu đồ Excel đó được coi là một đối tượng OLE. 

- Một đối tượng OLE có thể hiển thị dưới dạng biểu tượng. Trong trường hợp này, khi bạn nhấp đúp vào biểu tượng, biểu đồ sẽ được mở trong ứng dụng liên quan (Excel), hoặc bạn sẽ được yêu cầu chọn một ứng dụng để mở hoặc chỉnh sửa đối tượng. 
- Một đối tượng OLE có thể hiển thị nội dung thực tế của nó, chẳng hạn như nội dung của một biểu đồ. Trong trường hợp này, biểu đồ được kích hoạt trong PowerPoint, giao diện biểu đồ được tải và bạn có thể chỉnh sửa dữ liệu của biểu đồ trong PowerPoint.

[Aspose.Slides for PHP via Java](https://products.aspose.com/slides/vi/php-java/) cho phép bạn chèn các đối tượng OLE vào các slide dưới dạng khung đối tượng OLE ([OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/)).

## **Thêm khung OLE Object vào Slide**

Giả sử bạn đã tạo một biểu đồ trong Microsoft Excel và muốn nhúng nó vào một slide dưới dạng khung đối tượng OLE bằng cách sử dụng Aspose.Slides for PHP via Java, bạn có thể thực hiện như sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
1. Lấy tham chiếu của slide thông qua chỉ số của nó.
1. Đọc tệp Excel dưới dạng mảng byte.
1. Thêm [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) vào slide chứa mảng byte và các thông tin khác về đối tượng OLE.
1. Ghi bản trình bày đã chỉnh sửa ra tệp PPTX.

Trong ví dụ dưới đây, chúng tôi đã thêm một biểu đồ từ tệp Excel vào slide dưới dạng khung đối tượng OLE bằng Aspose.Slides for PHP via Java.  
**Lưu ý** rằng constructor của [OleEmbeddedDataInfo](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleembeddeddatainfo/) nhận phần mở rộng đối tượng có thể nhúng làm tham số thứ hai. Phần mở rộng này cho phép PowerPoint hiểu đúng loại tệp và chọn đúng ứng dụng để mở đối tượng OLE này.

```php
$presentation = new Presentation();
$slideSize = $presentation->getSlideSize()->getSize();
$slide = $presentation->getSlides()->get_Item(0);

// Prepare data for the OLE object.
$fileData = file_get_contents("book.xlsx");
$dataInfo = new OleEmbeddedDataInfo($fileData, "xlsx");

// Add the OLE object frame to the slide.
$slide->getShapes()->addOleObjectFrame(0, 0, $slideSize->getWidth(), $slideSize->getHeight(), $dataInfo);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

### **Thêm khung OLE Object liên kết**

Aspose.Slides for PHP via Java cho phép bạn thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) mà không nhúng dữ liệu mà chỉ có liên kết tới tệp.

Đoạn mã PHP này cho bạn thấy cách thêm một [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) với tệp Excel được liên kết vào slide:

```php
$presentation = new Presentation();
$slide = $presentation->getSlides()->get_Item(0);

// Thêm khung đối tượng OLE với tệp Excel được liên kết.
$slide->getShapes()->addOleObjectFrame(20, 20, 200, 150, "Excel.Sheet.12", "book.xlsx");

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Truy cập khung OLE Object**

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng tìm hoặc truy cập nó bằng cách sau:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide bằng cách sử dụng chỉ số của nó.
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có chỉ một hình dạng trên slide đầu tiên.
4. Khi đã truy cập được khung OLE Object, bạn có thể thực hiện bất kỳ thao tác nào trên nó.

Trong ví dụ dưới đây, một khung OLE Object (đối tượng biểu đồ Excel được nhúng trong slide) và dữ liệu tệp của nó được truy cập.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;
    
    // Lấy dữ liệu tệp được nhúng.
    // Lấy phần mở rộng của tệp được nhúng.
    // ...
}
```

### **Truy cập thuộc tính khung OLE Object liên kết**

Aspose.Slides cho phép bạn truy cập các thuộc tính của khung OLE Object được liên kết.

Đoạn mã PHP này cho bạn thấy cách kiểm tra xem một đối tượng OLE có được liên kết hay không và sau đó lấy đường dẫn tới tệp được liên kết:

```php
$presentation = new Presentation("sample.ppt");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    // Kiểm tra xem đối tượng OLE có được liên kết hay không.
    if (java_values($oleFrame->isObjectLink()) != 0) {
        // In đường dẫn đầy đủ tới tệp được liên kết.
        echo "OLE object frame is linked to: " . $oleFrame->getLinkPathLong() . PHP_EOL;

        // In đường dẫn tương đối tới tệp được liên kết nếu có.
        // Chỉ các bản trình bày PPT mới có thể chứa đường dẫn tương đối.
        $relativePath = java_values($oleFrame->getLinkPathRelative());
        if (!is_null($relativePath) && $relativePath !== "") {
            echo "OLE object frame relative path: " . $oleFrame->getLinkPathRelative() . PHP_EOL;
        }
    }
}

$presentation->dispose();
```

## **Thay đổi dữ liệu OLE Object**

{{% alert color="primary" %}} 

Trong phần này, ví dụ mã bên dưới sử dụng [Aspose.Cells for PHP via Java](/cells/php-java/).

{{% /alert %}}

Nếu một đối tượng OLE đã được nhúng trong một slide, bạn có thể dễ dàng truy cập đối tượng đó và sửa đổi dữ liệu của nó theo cách sau:

1. Tải một bản trình bày có đối tượng OLE đã nhúng bằng cách tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu của slide thông qua chỉ số của nó. 
3. Truy cập hình dạng [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/). Trong ví dụ của chúng tôi, chúng tôi sử dụng PPTX đã tạo trước có một hình dạng trên slide đầu tiên.
4. Khi đã truy cập được khung OLE Object, bạn có thể thực hiện bất kỳ thao tác nào trên nó.
5. Tạo một đối tượng `Workbook` và truy cập dữ liệu OLE.
6. Truy cập `Worksheet` mong muốn và sửa đổi dữ liệu.
7. Lưu `Workbook` đã cập nhật vào một luồng.
8. Thay đổi dữ liệu OLE Object từ luồng.

Trong ví dụ dưới đây, một khung OLE Object (đối tượng biểu đồ Excel được nhúng trong slide) được truy cập và dữ liệu tệp của nó được sửa đổi để cập nhật dữ liệu biểu đồ.

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$shape = $slide->getShapes()->get_Item(0);

if (java_instanceof($shape, new JavaClass("com.aspose.slides.OleObjectFrame"))) {
    $oleFrame = $shape;

    $oleStream = new ByteArrayInputStream($oleFrame->getEmbeddedData()->getEmbeddedFileData());

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

## **Nhúng các loại tệp khác vào Slide**

Ngoài biểu đồ Excel, Aspose.Slides for PHP via Java cho phép bạn nhúng các loại tệp khác vào slide. Ví dụ, bạn có thể chèn HTML, PDF và ZIP dưới dạng đối tượng. Khi người dùng nhấp đúp vào đối tượng đã chèn, nó sẽ tự động mở trong chương trình liên quan, hoặc người dùng sẽ được nhắc chọn chương trình thích hợp để mở.

Đoạn mã PHP này cho bạn thấy cách nhúng HTML và ZIP vào slide:

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

## **Đặt loại tệp cho đối tượng đã nhúng**

Khi làm việc với bản trình bày, bạn có thể cần thay thế các đối tượng OLE cũ bằng các đối tượng mới hoặc thay thế một đối tượng OLE không hỗ trợ bằng một đối tượng hỗ trợ. Aspose.Slides for PHP via Java cho phép bạn đặt loại tệp cho một đối tượng đã nhúng, cho phép cập nhật dữ liệu khung OLE hoặc phần mở rộng của nó.

Đoạn mã PHP này cho bạn thấy cách đặt loại tệp cho một đối tượng OLE đã nhúng thành `zip`:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

$fileExtension = $oleFrame->getEmbeddedData()->getEmbeddedFileExtension();
$fileData = $oleFrame->getEmbeddedData()->getEmbeddedFileData();

echo "Current embedded file extension is: " . $fileExtension . PHP_EOL;

// Thay đổi loại tệp thành ZIP.
$oleFrame->setEmbeddedData(new OleEmbeddedDataInfo($fileData, "zip"));

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Đặt hình ảnh biểu tượng và tiêu đề cho đối tượng đã nhúng**

Sau khi nhúng một đối tượng OLE, một bản xem trước gồm hình ảnh biểu tượng được tự động thêm. Bản xem trước này là những gì người dùng nhìn thấy trước khi truy cập hoặc mở đối tượng OLE. Nếu bạn muốn sử dụng một hình ảnh và văn bản cụ thể làm phần tử trong bản xem trước, bạn có thể đặt hình ảnh biểu tượng và tiêu đề bằng Aspose.Slides for PHP via Java.

Đoạn mã PHP này cho bạn thấy cách đặt hình ảnh biểu tượng và tiêu đề cho một đối tượng đã nhúng:

```php
$presentation = new Presentation("sample.pptx");
$slide = $presentation->getSlides()->get_Item(0);
$oleFrame = $slide->getShapes()->get_Item(0);

// Thêm một hình ảnh vào tài nguyên của bản trình bày.
$imageData = file_get_contents("image.png");
$oleImage = $presentation->getImages()->addImage($imageData);

// Đặt tiêu đề và hình ảnh cho bản xem trước OLE.
$oleFrame->setSubstitutePictureTitle("My title");
$oleFrame->getSubstitutePictureFormat()->getPicture()->setImage($oleImage);
$oleFrame->setObjectIcon(true);

$presentation->save("output.pptx", SaveFormat::Pptx);
$presentation->dispose();
```

## **Ngăn không cho khung OLE Object bị thay đổi kích thước và vị trí**

Sau khi bạn thêm một đối tượng OLE được liên kết vào slide, khi mở bản trình bày trong PowerPoint, bạn có thể thấy một thông báo yêu cầu cập nhật các liên kết. Nhấn nút "Update Links" có thể thay đổi kích thước và vị trí của khung OLE Object vì PowerPoint cập nhật dữ liệu từ đối tượng OLE được liên kết và làm mới bản xem trước đối tượng. Để ngăn PowerPoint thông báo để cập nhật dữ liệu của đối tượng, đặt phương thức `setUpdateAutomatic` của lớp [OleObjectFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/oleobjectframe/) thành `false`:

```php
$oleFrame->setUpdateAutomatic(false);
```

## **Trích xuất các tệp đã nhúng**

Aspose.Slides for PHP via Java cho phép bạn trích xuất các tệp được nhúng trong slide dưới dạng OLE Object theo cách sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) chứa các OLE Object bạn muốn trích xuất.
2. Duyệt qua tất cả các shape trong bản trình bày và truy cập các shape [OLEObjectFrame].
3. Truy cập dữ liệu của các tệp đã nhúng từ khung OLE Object và ghi chúng ra đĩa.

Đoạn mã PHP này cho bạn thấy cách trích xuất các tệp đã nhúng trong slide dưới dạng OLE Object:

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

## **CÂU HỎI THƯỜNG GẶP**

**Liệu nội dung OLE có được render khi xuất slide sang PDF/hình ảnh không?**  
Chỉ những gì hiển thị trên slide sẽ được render — biểu tượng/hình ảnh thay thế (bản preview). Nội dung OLE “sống” không được thực thi trong quá trình render. Nếu cần, hãy đặt hình preview của riêng bạn để đảm bảo giao diện mong muốn trong PDF đã xuất.

**Làm thế nào để khóa một đối tượng OLE trên slide để người dùng không thể di chuyển/chỉnh sửa nó trong PowerPoint?**  
Khóa shape: Aspose.Slides cung cấp các khóa ở mức shape. Đây không phải là mã hóa, nhưng nó thực sự ngăn ngừa việc chỉnh sửa hoặc di chuyển vô tình.

**Liệu các đường dẫn tương đối cho các đối tượng OLE được liên kết có được bảo tồn trong định dạng PPTX không?**  
Trong PPTX, thông tin “đường dẫn tương đối” không có — chỉ có đường dẫn đầy đủ. Đường dẫn tương đối chỉ có trong định dạng PPT cũ hơn. Để di động, ưu tiên sử dụng các đường dẫn tuyệt đối đáng tin cậy/URI có thể truy cập hoặc nhúng.