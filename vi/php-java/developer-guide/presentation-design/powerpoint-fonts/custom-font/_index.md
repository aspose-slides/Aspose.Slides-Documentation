---
title: Tùy chỉnh phông chữ PowerPoint trong PHP
linktitle: Phông chữ Tùy chỉnh
type: docs
weight: 20
url: /vi/php-java/custom-font/
keywords:
- phông chữ
- phông chữ tùy chỉnh
- phông chữ bên ngoài
- tải phông chữ
- quản lý phông chữ
- thư mục phông chữ
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Tùy chỉnh phông chữ trong các slide PowerPoint với Aspose.Slides cho PHP qua Java để giữ cho bản trình chiếu của bạn sắc nét và nhất quán trên mọi thiết bị."
---
## **Tổng quan**

Aspose.Slides cho phép bạn sử dụng phông chữ tùy chỉnh trong bản trình chiếu mà không cần cài đặt chúng trên hệ điều hành. Bạn có thể tải phông chữ từ các thư mục tùy chỉnh, cung cấp phông chữ cho một bản trình chiếu cụ thể thông qua nguồn phông chữ ở mức tài liệu, hoặc tải phông chữ bên ngoài trực tiếp từ dữ liệu nhị phân.

Các phông chữ đã tải sẽ được sử dụng khi bản trình chiếu được hiển thị hoặc xuất ra, ví dụ sang PDF, hình ảnh và các định dạng hỗ trợ khác. Điều này giúp duy trì độ nhất quán của kết quả bản trình chiếu trên các môi trường khác nhau. Bài viết cũng giải thích cách kiểm tra các thư mục phông chữ được Aspose.Slides sử dụng và cách xóa bộ nhớ cache phông chữ sau khi làm việc với phông chữ bên ngoài.

Đăng ký phông chữ tùy chỉnh để hiển thị là một quá trình riêng biệt so với việc nhúng phông chữ vào tệp PPTX. Nếu một phông chữ cần được lưu trữ bên trong bản trình chiếu, hãy sử dụng các tính năng nhúng phông chữ một cách rõ ràng.

Một chủ đề bản trình chiếu có thể tham chiếu các họ phông chữ khác nhau cho các hệ thống viết riêng lẻ. Những ánh xạ này chỉ lưu tên phông chữ mà không cài đặt hoặc tải tệp phông chữ. Xem [Script-Specific Theme Fonts](/slides/vi/php-java/script-specific-font-mappings/) để quản lý các ánh xạ, và sử dụng các tùy chọn tải bên dưới để làm cho các phông chữ được tham chiếu sẵn sàng cho việc hiển thị nhất quán.

{{% alert color="info" title="Note" %}}

Aspose Slides cho phép bạn tải các phông chữ này bằng phương thức [loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---):

* Phông chữ TrueType (.ttf) và TrueType Collection (.ttc). Xem [TrueType](https://en.wikipedia.org/wiki/TrueType).

* Phông chữ OpenType (.otf). Xem [OpenType](https://en.wikipedia.org/wiki/OpenType).

{{% /alert %}}

## **Tải phông chữ tùy chỉnh**

Aspose.Slides cho phép bạn tải các phông chữ được sử dụng trong bản trình chiếu mà không cần cài đặt chúng trên hệ thống. Điều này ảnh hưởng đến đầu ra xuất ra — như PDF, hình ảnh và các định dạng hỗ trợ khác — sao cho tài liệu kết quả trông nhất quán trên mọi môi trường. Các phông chữ được tải từ các thư mục tùy chỉnh.

1. Xác định một hoặc nhiều thư mục chứa tệp phông chữ.
2. Gọi phương thức tĩnh [FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) để tải phông chữ từ các thư mục đó.
3. Tải và hiển thị/​​xuất bản trình chiếu.
4. Gọi [FontsLoader::clearCache](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#clearCache--) để xóa bộ nhớ cache phông chữ.

Ví dụ mã sau minh họa quy trình tải phông chữ:

```php
// Định nghĩa các thư mục chứa tệp phông chữ tùy chỉnh.
$externalFontFolder1 = __DIR__ . "/external-fonts-1";
$externalFontFolder2 = __DIR__ . "/external-fonts-2";
$fontFolders = array($externalFontFolder1, $externalFontFolder2);

// Tải phông chữ tùy chỉnh từ các thư mục được chỉ định.
FontsLoader::loadExternalFonts($fontFolders);

$presentation = null;
try {
    $presentationPath = __DIR__ . "/sample.pptx";
    $presentation = new Presentation($presentationPath);
    
    // Hiển thị/​​xuất bản trình chiếu (ví dụ, sang PDF, hình ảnh, hoặc các định dạng khác) bằng các phông chữ đã tải.
    $outputPath = __DIR__ . "/output.pdf";
    $presentation->save($outputPath, SaveFormat::Pdf);
} finally {
    if ($presentation != null) $presentation->dispose();

    // Xóa bộ nhớ cache phông chữ sau khi công việc hoàn tất.
    FontsLoader::clearCache();
}
```

{{% alert color="info" title="Note" %}}

[FontsLoader::loadExternalFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFonts-java.lang.String---) thêm các thư mục bổ sung vào đường dẫn tìm kiếm phông chữ, nhưng không thay đổi thứ tự khởi tạo phông chữ.
Phông chữ được khởi tạo theo thứ tự sau:

1. Đường dẫn phông chữ mặc định của hệ điều hành.
1. Các đường dẫn được tải qua [FontsLoader](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/).

{{%/alert %}}

## **Lấy các thư mục phông chữ tùy chỉnh**
Aspose.Slides cung cấp phương thức [getFontFolders](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#getFontFolders--) để cho phép bạn tìm các thư mục phông chữ. Phương thức này trả về các thư mục được thêm thông qua phương thức `LoadExternalFonts` và các thư mục phông chữ hệ thống.

Mã PHP sau cho thấy cách sử dụng [getFontFolders](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#getFontFolders--):

```php
# Dòng này xuất ra các thư mục nơi tìm kiếm tệp phông chữ.
# Đó là các thư mục được thêm qua phương thức LoadExternalFonts và các thư mục phông chữ hệ thống.
$fontFolders = FontsLoader::getFontFolders();
```

## **Xác định phông chữ tùy chỉnh được sử dụng cho một bản trình chiếu**
Aspose.Slides cung cấp phương thức [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-) để cho phép bạn chỉ định các phông chữ bên ngoài sẽ được sử dụng cho bản trình chiếu.

Mã PHP sau cho thấy cách sử dụng phương thức [LoadOptions.setDocumentLevelFontSources](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDocumentLevelFontSources-com.aspose.slides.IFontSources-):

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
    # Làm việc với bản trình chiếu
    # CustomFont1, CustomFont2, và các phông chữ từ thư mục assets\fonts & global\fonts và các thư mục con của chúng khả dụng cho bản trình chiếu
} finally {
    if (!java_is_null($presentation)) {
        $presentation->dispose();
    }
}
```

## **Quản lý phông chữ từ bên ngoài**

Aspose.Slides cung cấp phương thức [loadExternalFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsloader/#loadExternalFont-byte---)(byte[] data) để cho phép bạn tải phông chữ bên ngoài từ dữ liệu nhị phân.

Mã PHP sau minh họa quy trình tải phông chữ từ mảng byte:

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
        # phông chữ bên ngoài được tải trong thời gian sống của bản trình chiếu
    } finally {
        if (!java_is_null($presentation)) {
            $presentation->dispose();
        }
    }
} finally {
    FontsLoader->clearCache();
}
```

## **Câu hỏi thường gặp**

### Phông chữ tùy chỉnh có ảnh hưởng đến việc xuất ra tất cả các định dạng (PDF, PNG, SVG, HTML) không?

Có. Các phông chữ được kết nối sẽ được trình kết xuất sử dụng cho tất cả các định dạng xuất.

### Phông chữ tùy chỉnh có tự động được nhúng vào tệp PPTX kết quả không?

Không. Đăng ký một phông chữ để hiển thị không đồng nghĩa với việc nhúng nó vào PPTX. Nếu bạn cần phông chữ được mang theo trong tệp bản trình chiếu, phải sử dụng các [tính năng nhúng](/slides/vi/php-java/embedded-font/) một cách rõ ràng.

### Tôi có thể kiểm soát hành vi fallback khi phông chữ tùy chỉnh thiếu một số glyph không?

Có. Cấu hình [font substitution](/slides/vi/php-java/font-substitution/), [replacement rules](/slides/vi/php-java/font-replacement/) và [fallback sets](/slides/vi/php-java/fallback-font/) để xác định chính xác phông chữ nào sẽ được dùng khi glyph yêu cầu không có.

### Tôi có thể sử dụng phông chữ trong các container Linux/Docker mà không cài đặt chúng trên hệ thống không?

Có. Chỉ định thư mục phông chữ của riêng bạn hoặc tải phông chữ từ mảng byte. Điều này loại bỏ bất kỳ phụ thuộc nào vào các thư mục phông chữ hệ thống trong hình ảnh container.

### Về giấy phép—tôi có thể nhúng bất kỳ phông chữ tùy chỉnh nào mà không có hạn chế không?

Bạn chịu trách nhiệm tuân thủ giấy phép phông chữ. Điều kiện có thể khác nhau; một số giấy phép cấm nhúng hoặc sử dụng thương mại. Luôn xem lại EULA của phông chữ trước khi phân phối các đầu ra.