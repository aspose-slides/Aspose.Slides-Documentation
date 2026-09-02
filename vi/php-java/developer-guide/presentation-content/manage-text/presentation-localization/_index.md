---
title: Tự động hoá việc địa phương hoá bản trình chiếu trong PHP
linktitle: Địa phương hoá bản trình chiếu
type: docs
weight: 100
url: /vi/php-java/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- tắt kiểm tra chính tả
- ngôn ngữ kiểm tra
- định danh ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Đặt ngôn ngữ kiểm tra cho văn bản bản trình chiếu PowerPoint và OpenDocument trong PHP với Aspose.Slides, bao gồm các mặc định và đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for PHP via Java cho phép bạn cấu hình siêu dữ liệu kiểm tra chính tả cho các phần văn bản riêng lẻ. Sử dụng [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) để xác định ngôn ngữ kiểm tra, [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setSpellCheck) để cho phép hoặc ngăn kiểm tra chính tả, và [BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setProofDisabled) để kiểm soát trạng thái không kiểm tra rộng hơn. Vì các cài đặt này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage), xây dựng các đoạn văn đa ngôn ngữ, chọn giữa `SpellCheck` và `ProofDisabled`, và bảo tồn các cài đặt mong muốn khi sử dụng [Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting). Các thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, không thực hiện kiểm tra chính tả dựa trên từ điển, và không trả về các từ sai chính tả.

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả cho Văn Bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/), truy cập phần văn bản cần thiết thông qua [Portion::getPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getPortionFormat), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình, đặt tiếng Anh Anh làm ngôn ngữ kiểm tra và lưu kết quả bằng [Presentation::save](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#save):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Set the proofing language for this text.");

    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->getPortionFormat()->setLanguageId("en-GB");

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Ngôn Ngữ Mặc Định cho Văn Bản Mới**

Sử dụng [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides sẽ gán cho văn bản được tạo mới. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong một bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có định danh ngôn ngữ rõ ràng.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("de-DE");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 320, 80);
    $shape->getTextFrame()->setText("Willkommen zur Präsentation");

    $presentation->save("default_text_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Sử Dụng Nhiều Ngôn Ngữ trong Một Đoạn Văn**

Một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/) chứa một bộ sưu tập các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `LanguageId` của nó một cách độc lập.

Ví dụ này tạo một đoạn văn với các phần tiếng Anh và tiếng Pháp:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $englishPortion = new Portion("Welcome");
    $englishPortion->getPortionFormat()->setLanguageId("en-US");
    $paragraph->getPortions()->add($englishPortion);

    $frenchPortion = new Portion(" — Bienvenue");
    $frenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $paragraph->getPortions()->add($frenchPortion);

    $presentation->save("multilingual_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Bật hoặc Tắt Kiểm Tra Chính Tả cho Các Phần Riêng Lẻ**

[PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [BasePortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/). Truy cập định dạng của một phần qua [Portion::getPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getPortionFormat) và sử dụng [BasePortionFormat::setSpellCheck](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setSpellCheck) để kiểm soát liệu ứng dụng trình chiếu có kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `false`: `true` cho phép kiểm tra chính tả, trong khi `false` ngăn chặn nó.

Cài đặt này áp dụng cho các phần văn bản riêng lẻ. Do đó, các phần khác nhau trong cùng một đoạn có thể sử dụng các giá trị khác nhau. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) và `setSpellCheck` có mục đích bổ trợ: `setLanguageId` xác định ngôn ngữ kiểm tra, trong khi `setSpellCheck` quyết định liệu có cho phép kiểm tra chính tả cho phần đó hay không.

[BasePortionFormat::setProofDisabled](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setProofDisabled) cũng điều khiển việc kiểm tra, nhưng nó biểu thị trạng thái “không kiểm tra” rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/). Sử dụng `setSpellCheck` khi bạn cần một công tắc Boolean trực tiếp chỉ cho kiểm tra chính tả. Sử dụng `setProofDisabled` khi bạn cần bảo tồn hoặc kiểm soát một cách rõ ràng siêu dữ liệu “không kiểm tra” của bản trình chiếu, bao gồm trạng thái `NotDefined`. Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; đừng kết hợp `setSpellCheck(true)` với `setProofDisabled(NullableBool::True)`.

Các thuộc tính này cấu hình siêu dữ liệu kiểm tra được các ứng dụng PowerPoint và các trình chiếu khác sử dụng. Aspose.Slides không dùng chúng để thực hiện kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai.

Ví dụ đầy đủ sau tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai phần trong cùng một đoạn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```php
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$inputFile = "spell_check_input.pptx";
$outputFile = "spell_check_settings.pptx";

$sourcePresentation = new Presentation();
try {
    $sourceSlide = $sourcePresentation->getSlides()->get_Item(0);
    $sourceShape = $sourceSlide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 420, 80);
    $sourceParagraph = $sourceShape->getTextFrame()->getParagraphs()->get_Item(0);
    $sourceParagraph->getPortions()->clear();

    $sourceEnglishPortion = new Portion("Check this text. ");
    $sourceEnglishPortion->getPortionFormat()->setLanguageId("en-US");
    $sourceParagraph->getPortions()->add($sourceEnglishPortion);

    $sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    $sourceFrenchPortion->getPortionFormat()->setLanguageId("fr-FR");
    $sourceParagraph->getPortions()->add($sourceFrenchPortion);

    $sourcePresentation->save($inputFile, SaveFormat::Pptx);
} finally {
    $sourcePresentation->dispose();
}

$presentation = new Presentation($inputFile);
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $portions = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $checkedPortion = $portions->get_Item(0);
    $checkedPortion->getPortionFormat()->setLanguageId("en-US");
    $checkedPortion->getPortionFormat()->setSpellCheck(true);

    $suppressedPortion = $portions->get_Item(1);
    $suppressedPortion->getPortionFormat()->setLanguageId("fr-FR");
    $suppressedPortion->getPortionFormat()->setSpellCheck(false);

    $presentation->save($outputFile, SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}

$reopenedPresentation = new Presentation($outputFile);
try {
    $reopenedShape = $reopenedPresentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $storedPortions = $reopenedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions();

    $storedPortionCount = java_values($storedPortions->getCount());
    $firstStoredFormat = $storedPortions->get_Item(0)->getPortionFormat();
    $secondStoredFormat = $storedPortions->get_Item(1)->getPortionFormat();

    $firstPortionStored = $storedPortionCount === 2 && 
        java_values($firstStoredFormat->getLanguageId()) === "en-US" && 
        java_values($firstStoredFormat->getSpellCheck());

    $secondPortionStored = $storedPortionCount === 2 && 
        java_values($secondStoredFormat->getLanguageId()) === "fr-FR" && 
        !java_values($secondStoredFormat->getSpellCheck());

    if ($firstPortionStored && $secondPortionStored) {
        echo "The proofing settings were stored correctly.";
    } else {
        echo "The proofing settings could not be verified.";
    }
} finally {
    $reopenedPresentation->dispose();
}
```

[Presentation::joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#joinPortionsWithSameFormatting) kết hợp các phần liền kề có cùng định dạng. Một sự khác nhau chỉ ở `SpellCheck` không giữ các phần đó tách biệt; sau khi chúng được kết hợp, phần kết quả giữ giá trị `SpellCheck` của phần đầu tiên. Nếu các phần cần các cài đặt kiểm tra chính tả khác nhau, hãy gọi `joinPortionsWithSameFormatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của phần đã kết hợp và áp dụng lại các cài đặt sau. Các phần có giá trị `LanguageId` khác nhau vẫn giữ tách biệt vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **Câu Hỏi Thường Gặp**

**ID ngôn ngữ có dịch nội dung không?**

Không. [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) lưu trữ siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ thích hợp cho mỗi phần đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, cách gạch nối hay ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào các [phông chữ](/slides/vi/php-java/powerpoint-fonts/) có sẵn, hệ thống viết, và cài đặt khung văn bản. Để đảm bảo hiển thị chính xác, hãy cung cấp các phông chữ cần thiết, cấu hình [thay thế phông chữ](/slides/vi/php-java/font-substitution/), hoặc [nhúng phông chữ](/slides/vi/php-java/embedded-font/) trong bản trình chiếu.

**Một đoạn văn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng, như trong ví dụ đoạn văn đa ngôn ngữ.

**Nên dùng `setDefaultTextLanguage` hay `setLanguageId`?**

Sử dụng [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) khi bạn muốn một ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) khi một phần cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn chứa nhiều ngôn ngữ.