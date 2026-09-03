---
title: Nhúng Phông Chữ trong Bài Thuyết Trình bằng PHP
linktitle: Phông Chữ Đã Nhúng
type: docs
weight: 40
url: /vi/php-java/embedded-font/
keywords:
- thêm phông chữ
- nhúng phông chữ
- nhúng phông chữ
- lấy phông chữ đã nhúng
- thêm phông chữ đã nhúng
- xóa phông chữ đã nhúng
- nén phông chữ đã nhúng
- PowerPoint
- bài thuyết trình
- PHP
- Aspose.Slides
description: "Quản lý phông chữ đã nhúng trong PowerPoint với Aspose.Slides cho PHP qua Java. Thêm, truy xuất, xóa và nén phông chữ để giữ nguyên diện mạo văn bản và giảm kích thước tệp."
---
## **Giới thiệu**

Nhúng phông chữ lưu trữ dữ liệu phông trong một bài thuyết trình PowerPoint. Khi một trình xem hỗ trợ phông chữ nhúng, nó có thể hiển thị văn bản sử dụng các phông chữ đó ngay cả khi chúng không được cài đặt trên hệ thống đích. Điều này giúp giữ nguyên ngắt dòng, khoảng cách văn bản và bố cục slide.

Aspose.Slides for PHP qua Java cho phép bạn truy xuất, thêm và xóa phông chữ nhúng thông qua lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/) được trả về bởi [Presentation::getFontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getFontsManager). Bạn cũng có thể giảm kích thước dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự mà bản thuyết trình không sử dụng.

Các ví dụ dưới đây hoạt động với các tệp PPTX. Trước khi nhúng một phông chữ, hãy đảm bảo dữ liệu phông chữ của nó có sẵn cho Aspose.Slides và giấy phép của nó cho phép nhúng.

## **Lấy và Xóa Phông Chữ Nhúng**

Sử dụng [FontsManager::getEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getEmbeddedFonts) để liệt kê các phông chữ được lưu trong một bản thuyết trình. Để xóa một phông chữ, truyền một phông chữ từ danh sách đó vào [FontsManager::removeEmbeddedFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#removeEmbeddedFont), sau đó lưu bản thuyết trình.

Ví dụ sau liệt kê các phông chữ nhúng trong `EmbeddedFonts.pptx` và xóa Calibri nếu nó có mặt:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();

    foreach ($embeddedFonts as $font) {
        echo java_values($font->getFontName()) . PHP_EOL;
    }

    $fontToRemove = null;
    foreach ($embeddedFonts as $font) {
        $fontName = java_values($font->getFontName());
        if (strcasecmp($fontName, "Calibri") === 0) {
            $fontToRemove = $font;
            break;
        }
    }

    if ($fontToRemove !== null) {
        $fontsManager->removeEmbeddedFont($fontToRemove);
        $presentation->save("WithoutEmbeddedCalibri.pptx", SaveFormat::Pptx);
    } else {
        echo "Calibri is not embedded. No output file was created." . PHP_EOL;
    }
} finally {
    $presentation->dispose();
}
```

Việc xóa một phông chữ nhúng sẽ xóa dữ liệu phông chữ đã lưu; nó không thay đổi phông chữ được gán cho văn bản. Nếu phông chữ được cài đặt trên hệ thống đích, văn bản vẫn có thể sử dụng nó. Nếu không, quá trình render có thể yêu cầu [thay thế phông chữ](/slides/vi/php-java/font-substitution/), điều này có thể ảnh hưởng đến bố cục.

## **Kiểm Tra Dữ Liệu Phông Chữ và Quyền Nhúng**

Sử dụng lớp [FontsManager](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/) để kiểm tra các phông chữ trước khi nhúng chúng. Gọi [FontsManager::getFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được sử dụng trong bản thuyết trình. Đối với mỗi phông chữ, truyền một đối tượng [FontData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontdata/) và giá trị [FontStyleType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontstyletype/) yêu cầu vào [FontsManager::getFontBytes](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getFontBytes). Phương thức này trả về dữ liệu nhị phân cho kiểu phông chữ đó, hoặc `null` khi phông chữ hoặc kiểu được yêu cầu không khả dụng. Không truyền kết quả `null` vào [FontsManager::getFontEmbeddingLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getFontEmbeddingLevel), vì phương thức đó yêu cầu một mảng byte.

[EmbeddingLevel](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embeddinglevel/) là một kiểu liệt kê cờ báo cáo các hạn chế nhúng được lưu trong phông chữ:

- `Installable` cho phép nhúng và cài đặt vĩnh viễn trên hệ thống khác, tùy thuộc vào giấy phép phông chữ.
- `Restricted` cấm nhúng trừ khi có được sự cho phép từ chủ sở hữu hợp pháp của phông chữ khi đây là cờ quyền sử dụng duy nhất.
- `PreviewPrint` cho phép sử dụng tạm thời để xem và in; tài liệu chứa phông chữ phải ở chế độ chỉ đọc.
- `Editable` cho phép sử dụng tạm thời và cho phép tài liệu được chỉnh sửa và lưu.
- `NoSubsetting` là một hạn chế bổ sung ngăn việc nhúng chỉ một phần con của các glyph. Khi cờ này hiện diện, phải nhúng toàn bộ ký tự.
- `BitmapOnly` là một hạn chế bổ sung cho phép chỉ nhúng các dạng bitmap, không phải dữ liệu outline. Nếu phông chữ không có dạng bitmap, nó không thể được nhúng.

Bốn giá trị đầu mô tả quyền sử dụng, trong khi `NoSubsetting` và `BitmapOnly` có thể được kết hợp với chúng. Kiểm tra các bộ điều chỉnh bằng các phép toán bitwise. Vì `Installable` có giá trị zero, hãy tạo mặt nạ các bit quyền sử dụng và so sánh kết quả với `Installable` thay vì kiểm tra nó như một cờ. Các phông chữ hiện tại nên đặt tối đa một bit quyền sử dụng. Để tương thích với các phông chữ cũ đặt nhiều hơn một bit, trợ giúp bên dưới chọn quyền ít hạn chế nhất: `Editable`, rồi `PreviewPrint`, rồi `Restricted`.

Ví dụ sau kiểm tra dữ liệu thường, đậm, nghiêng và đậm-ngoại lệ có sẵn cho mỗi phông chữ được trả về bởi `FontsManager::getFonts`. Nó bỏ qua các kiểu không khả dụng, các phông chữ bị hạn chế, phông chữ chỉ bitmap, các phông chữ giới hạn chỉ xem trước và in vì đầu ra vẫn có thể chỉnh sửa, và các phông chữ đã được nhúng. Nếu bất kỳ kiểu nào có sẵn có `NoSubsetting`, nó sẽ nhúng toàn bộ ký tự cho họ phông chữ đó.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\EmbeddingLevel;
use aspose\slides\FontStyleType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

function getUsagePermission($level) {
    $permissionMask = EmbeddingLevel::Restricted | EmbeddingLevel::PreviewPrint | EmbeddingLevel::Editable;
    $permissions = $level & $permissionMask;

    if (($permissions & EmbeddingLevel::Editable) !== 0) {
        return EmbeddingLevel::Editable;
    }

    if (($permissions & EmbeddingLevel::PreviewPrint) !== 0) {
        return EmbeddingLevel::PreviewPrint;
    }

    if (($permissions & EmbeddingLevel::Restricted) !== 0) {
        return EmbeddingLevel::Restricted;
    }

    return EmbeddingLevel::Installable;
}

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $fontStyles = [
        FontStyleType::Regular,
        FontStyleType::Bold,
        FontStyleType::Italic,
        FontStyleType::Bold | FontStyleType::Italic
    ];

    $embeddedFontNames = [];
    foreach ($fontsManager->getEmbeddedFonts() as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    $fontsToEmbed = [];
    $embeddingRules = [];
    foreach ($fontsManager->getFonts() as $font) {
        $fontName = java_values($font->getFontName());
        if (isset($embeddedFontNames[strtolower($fontName)])) {
            echo $fontName . ": already embedded." . PHP_EOL;
            continue;
        }

        $hasAvailableData = false;
        $allAvailableStylesCanBeEmbedded = true;
        $previewPrintOnly = false;
        $requiresFullFont = false;

        foreach ($fontStyles as $fontStyle) {
            $fontBytes = $fontsManager->getFontBytes($font, $fontStyle);
            if (java_is_null($fontBytes)) {
                echo $fontName . " (" . $fontStyle . "): font data is unavailable." . PHP_EOL;
                continue;
            }

            $hasAvailableData = true;
            $embeddingLevel = java_values($fontsManager->getFontEmbeddingLevel($fontBytes, $fontName));
            $usagePermission = getUsagePermission($embeddingLevel);
            $noSubsetting = ($embeddingLevel & EmbeddingLevel::NoSubsetting) !== 0;
            $bitmapOnly = ($embeddingLevel & EmbeddingLevel::BitmapOnly) !== 0;

            $requiresFullFont = $requiresFullFont || $noSubsetting;
            $previewPrintOnly = $previewPrintOnly || $usagePermission === EmbeddingLevel::PreviewPrint;
            $allAvailableStylesCanBeEmbedded = $allAvailableStylesCanBeEmbedded && $usagePermission !== EmbeddingLevel::Restricted && !$bitmapOnly;

            echo $fontName . " (" . $fontStyle . "): " . $embeddingLevel . "." . PHP_EOL;
        }

        if (!$hasAvailableData) {
            echo $fontName . ": skipped because no requested style is available." . PHP_EOL;
        } elseif (!$allAvailableStylesCanBeEmbedded) {
            echo $fontName . ": skipped because at least one available style does not permit outline embedding." . PHP_EOL;
        } elseif ($previewPrintOnly) {
            echo $fontName . ": skipped because this example produces an editable presentation." . PHP_EOL;
        } else {
            $rule = $requiresFullFont ? EmbedFontCharacters::All : EmbedFontCharacters::OnlyUsed;
            $fontsToEmbed[] = $font;
            $embeddingRules[] = $rule;
        }
    }

    for ($i = 0; $i < count($fontsToEmbed); $i++) {
        $fontsManager->addEmbeddedFont($fontsToEmbed[$i], $embeddingRules[$i]);
    }

    $presentation->save("WithAuditedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Việc kiểm tra này báo cáo các hạn chế được mã hoá trong mỗi tệp phông chữ. Nó không cấp giấy phép, không chứng minh rằng bạn đã lấy phông chữ một cách hợp pháp, và không thay thế việc kiểm tra thỏa thuận giấy phép của phông chữ trước khi phân phối bản sao đã nhúng.

## **Thêm Phông Chữ Nhúng**

Sử dụng [FontsManager::addEmbeddedFont](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#addEmbeddedFont) để nhúng một phông chữ. Các overload của nó chấp nhận một đối tượng [FontData](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontdata/) hoặc một mảng byte chứa dữ liệu phông chữ. Kiểu liệt kê [EmbedFontCharacters](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedfontcharacters/) điều khiển các ký tự sẽ được bao gồm:

- [All](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedfontcharacters/) nhúng tất cả các ký tự trong phông chữ. Sử dụng tùy chọn này khi người nhận cần chỉnh sửa bản thuyết trình và nhập văn bản mới.
- [OnlyUsed](https://reference.aspose.com/slides/vi/php-java/aspose.slides/embedfontcharacters/) chỉ nhúng các ký tự được sử dụng trong bản thuyết trình để giảm kích thước tệp. Chọn tùy chọn này cho một bản thuyết trình đã hoàn thiện và chủ yếu được dùng để xem.

Ví dụ sau sử dụng [FontsManager::getFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getFonts) để lấy các phông chữ được sử dụng trong `Fonts.pptx` và nhúng những phông chữ chưa được nhúng. Các phông chữ cần thêm phải có sẵn trên máy chạy mã. Các phông chữ nhúng hiện có giữ nguyên bộ ký tự hiện tại của chúng.

```php
use aspose\slides\EmbedFontCharacters;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("Fonts.pptx");
try {
    $fontsManager = $presentation->getFontsManager();
    $allFonts = $fontsManager->getFonts();
    $embeddedFonts = $fontsManager->getEmbeddedFonts();
    $embeddedFontNames = [];

    foreach ($embeddedFonts as $embeddedFont) {
        $fontName = java_values($embeddedFont->getFontName());
        $embeddedFontNames[strtolower($fontName)] = true;
    }

    foreach ($allFonts as $font) {
        $fontName = java_values($font->getFontName());
        $normalizedFontName = strtolower($fontName);
        if (!isset($embeddedFontNames[$normalizedFontName])) {
            $fontsManager->addEmbeddedFont($font, EmbedFontCharacters::All);
            $embeddedFontNames[$normalizedFontName] = true;
        }
    }

    $presentation->save("WithEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Nén Phông Chữ Nhúng**

[Compress::compressEmbeddedFonts](https://reference.aspose.com/slides/vi/php-java/aspose.slides/compress/#compressEmbeddedFonts) giảm dữ liệu phông chữ nhúng bằng cách loại bỏ các ký tự không dùng. Nó hoạt động trên các phông chữ đã được nhúng, vì vậy mức giảm kích thước phụ thuộc vào lượng dữ liệu phông chữ không dùng mà bản thuyết trình chứa.

Ví dụ sau nén các phông chữ trong `EmbeddedFonts.pptx` và lưu kết quả thành một tệp riêng:

```php
use aspose\slides\Compress;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("EmbeddedFonts.pptx");
try {
    Compress::compressEmbeddedFonts($presentation);
    $presentation->save("CompressedEmbeddedFonts.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Giữ lại tệp gốc nếu người nhận có thể cần thêm văn bản sau này. Các ký tự bị loại bỏ trong quá trình nén sẽ không còn khả dụng từ phông chữ nhúng, ngay cả khi bạn ban đầu đã nhúng tất cả các ký tự.

## **Câu Hỏi Thường Gặp**

**Làm sao tôi có thể kiểm tra xem một phông chữ nhúng có vẫn bị thay thế trong quá trình render không?**

Gọi [FontsManager::getSubstitutions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fontsmanager/#getSubstitutions) trong môi trường mà bạn render bản thuyết trình để xem Aspose.Slides sẽ thay thế những phông chữ nào. Cũng kiểm tra cài đặt [thay thế phông chữ](/slides/vi/php-java/font-substitution/) và quy tắc [phông chữ dự phòng](/slides/vi/php-java/fallback-font/). Fallback xử lý các ký tự thiếu, vì vậy việc nhúng một phông chữ không giải quyết được các ký tự mà phông chữ đó không chứa.

**Tôi có nên nhúng các phông chữ phổ biến như Arial và Calibri không?**

Quyết định dựa trên môi trường đích. Nếu các phông chữ cần thiết có sẵn trên mọi máy mở hoặc render bản thuyết trình, việc nhúng chúng có thể làm tăng kích thước tệp không cần thiết. Nếu người nhận hoặc máy chủ có thể thiếu các phông chữ đó, việc nhúng chúng có thể giúp giữ nguyên giao diện dự định, với điều kiện giấy phép của chúng cho phép.