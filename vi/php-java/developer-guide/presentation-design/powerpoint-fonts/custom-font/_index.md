---
title: Tùy chỉnh phông chữ PowerPoint trong PHP
linktitle: Phông tùy chỉnh
type: docs
weight: 20
url: /vi/php-java/custom-font/
keywords:
- phông
- phông tùy chỉnh
- phông bên ngoài
- tải phông
- quản lý phông
- thư mục phông
- PowerPoint
- OpenDocument
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint bằng Aspose.Slides cho PHP thông qua Java để giữ cho bài thuyết trình của bạn sắc nét và nhất quán trên bất kỳ thiết bị nào."
---
## **Overview**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong các bài thuyết trình mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông từ các thư mục tùy chỉnh, cung cấp phông cho một bài thuyết trình cụ thể thông qua các nguồn phông ở mức tài liệu, hoặc tải phông bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông đã tải sẽ được sử dụng khi bài thuyết trình được render hoặc xuất, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì đầu ra nhất quán trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông được Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông sau khi làm việc với phông bên ngoài.

Đăng ký phông tùy chỉnh để render là riêng biệt với việc nhúng phông vào tệp PPTX. Nếu một phông phải được lưu bên trong bản thuyết trình, hãy sử dụng các tính năng nhúng phông một cách rõ ràng.

{{% alert color="primary" %}} 
Aspose Slides cho phép bạn tải các phông này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).
* Phông OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).
{{% /alert %}}

## **Load Custom Fonts**

Aspose.Slides cho phép bạn tải các phông được sử dụng trong một bài thuyết trình mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến kết quả xuất — chẳng hạn PDF, hình ảnh và các định dạng hỗ trợ khác — để các tài liệu tạo ra trông nhất quán trên mọi môi trường. Các phông được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa các tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông từ các thư mục đó.
3. Tải và render/​xuất bài thuyết trình.
4. Gọi [FontsLoader::clearCache](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#clearCache--) để xóa bộ nhớ cache phông.

Ví dụ mã sau trình bày quá trình tải phông:

```php
// Xác định các thư mục chứa tệp phông chữ tùy chỉnh.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Tải phông chữ tùy chỉnh từ các thư mục đã chỉ định.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Render/​xuất bài thuyết trình (ví dụ sang PDF, hình ảnh hoặc các định dạng khác) bằng cách sử dụng các phông đã tải.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Xóa bộ nhớ cache phông sau khi công việc hoàn thành.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}
[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục bổ sung vào đường dẫn tìm kiếm phông, nhưng không thay đổi thứ tự khởi tạo phông. Các phông được khởi tạo theo thứ tự sau:

1. Đường dẫn phông mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/).
{{%/alert %}}

## **Get Custom Font Folders**
Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông. Phương thức này trả về các thư mục đã được thêm qua phương thức `LoadExternalFonts` và các thư mục phông hệ thống.

Đoạn mã PHP dưới đây cho thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Dòng này xuất ra các thư mục nơi các tệp phông chữ được tìm kiếm.
# Đó là các thư mục được thêm qua phương thức LoadExternalFonts và các thư mục phông hệ thống.
$fontFolders = FontsLoader::getFontFolders();
```

## **Specify Custom Fonts Used with a Presentation**
Aspose.Slides cung cấp phương thức [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông bên ngoài sẽ được sử dụng với bài thuyết trình.

Đoạn mã PHP dưới đây cho thấy cách sử dụng phương thức [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;

$customFontsDirectory = __DIR__ . "/customfonts/";
$customFont1Path = $customFontsDirectory . "CustomFont1.ttf";
$customFontFile1 = new Java("java.io.File", $customFont1Path);
$customFontFile1Length = $customFontFile1->length();
$memoryFont1 = $javaArray->newInstance($javaByteType, $customFontFile1Length);
$dataInputStream1 = null;
try {
    $fileInputStream1 = new Java("java.io.FileInputStream", $customFontFile1);
    $dataInputStream1 = new Java("java.io.DataInputStream", $fileInputStream1);
    $dataInputStream1->readFully($memoryFont1);
} finally {
    if (!java_is_null($dataInputStream1)) $dataInputStream1->close();
}

$customFont2Path = $customFontsDirectory . "CustomFont2.ttf";
$customFontFile2 = new Java("java.io.File", $customFont2Path);
$customFontFile2Length = $customFontFile2->length();
$memoryFont2 = $javaArray->newInstance($javaByteType, $customFontFile2Length);
$dataInputStream2 = null;
try {
    $fileInputStream2 = new Java("java.io.FileInputStream", $customFontFile2);
    $dataInputStream2 = new Java("java.io.DataInputStream", $fileInputStream2);
    $dataInputStream2->readFully($memoryFont2);
} finally {
    if (!java_is_null($dataInputStream2)) $dataInputStream2->close();
}

$loadOptions = new LoadOptions();
$assetFontsFolder = __DIR__ . "/assets/fonts";
$globalFontsFolder = __DIR__ . "/global/fonts";
$loadOptions->getDocumentLevelFontSources()->setFontFolders(array($assetFontsFolder, $globalFontsFolder));
$loadOptions->getDocumentLevelFontSources()->setMemoryFonts(array($memoryFont1, $memoryFont2 ));

$presentationPath = __DIR__ . "/MyPresentation.pptx";
$presentation = new Presentation($presentationPath, $loadOptions);
try {
    # Làm việc với bài thuyết trình
    # CustomFont1, CustomFont2, và các phông chữ từ assets\fonts & global\fonts và các thư mục con của chúng đều khả dụng cho bài thuyết trình
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Manage Fonts Externally**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông bên ngoài từ dữ liệu nhị phân.

Đoạn mã PHP dưới đây minh họa quá trình tải phông từ mảng byte:

```php
$javaArray = new JavaClass("java.lang.reflect.Array");
$javaByteType = (new JavaClass("java.lang.Byte"))->TYPE;
$fontDirectory = __DIR__ . "/";

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALN.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNBI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

$dataInputStream = null;
try {
    $fontPath = $fontDirectory . "ARIALNI.TTF";
    $fileInputStream = new Java("java.io.FileInputStream", $fontPath);
    $dataInputStream = new Java("java.io.DataInputStream", $fileInputStream);
    $fontBytes = $javaArray->newInstance($javaByteType, $dataInputStream->available());
    $dataInputStream->readFully($fontBytes);
} finally {
    if (!java_is_null($dataInputStream)) $dataInputStream->close();
}
FontsLoader::loadExternalFont($fontBytes);

try {
    $presentation = new Presentation();
    try {
        # phông chữ bên ngoài được tải trong thời gian tồn tại của bài thuyết trình
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **FAQ**

**Phông tùy chỉnh có ảnh hưởng đến việc xuất ra tất cả các định dạng (PDF, PNG, SVG, HTML) không?**

Có. Các phông được kết nối được renderer sử dụng cho mọi định dạng xuất.

**Các phông tùy chỉnh có tự động được nhúng vào tệp PPTX đầu ra không?**

Không. Đăng ký phông để render không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông được chứa trong tệp bài thuyết trình, phải sử dụng các [embedding features](/slides/vi/php-java/embedded-font/).

**Tôi có thể kiểm soát hành vi dự phòng khi một phông tùy chỉnh thiếu một số glyph không?**

Có. Cấu hình [font substitution](/slides/vi/php-java/font-substitution/), [replacement rules](/slides/vi/php-java/font-replacement/) và [fallback sets](/slides/vi/php-java/fallback-font/) để xác định chính xác phông nào sẽ được dùng khi glyph yêu cầu không có.

**Tôi có thể sử dụng phông trong các container Linux/Docker mà không cần cài đặt chúng trên toàn hệ thống không?**

Có. Chỉ định thư mục phông của riêng bạn hoặc tải phông từ mảng byte. Điều này loại bỏ mọi phụ thuộc vào thư mục phông hệ thống trong image container.

**Còn về giấy phép—tôi có thể nhúng bất kỳ phông tùy chỉnh nào mà không có hạn chế không?**

Bạn chịu trách nhiệm tuân thủ giấy phép phông. Điều khoản khác nhau; một số giấy phép cấm nhúng hoặc sử dụng thương mại. Luôn xem lại EULA của phông trước khi phân phối kết quả.