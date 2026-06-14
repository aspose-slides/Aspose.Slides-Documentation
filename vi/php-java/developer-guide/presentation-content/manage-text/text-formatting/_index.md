---
title: Định dạng Văn bản Bản trình chiếu trong PHP
linktitle: Định dạng Văn bản
type: docs
weight: 50
url: /vi/php-java/text-formatting/
keywords:
- đánh dấu văn bản
- biểu thức chính quy
- căn đoạn
- kiểu văn bản
- nền văn bản
- độ trong suốt văn bản
- khoảng cách ký tự
- thuộc tính phông chữ
- họ phông chữ
- xoay văn bản
- góc xoay
- khung văn bản
- khoảng cách dòng
- thuộc tính tự động điều chỉnh
- neo khung văn bản
- tabulation văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình chiếu
- PHP
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và hơn thế nữa."
---
## **Tổng quan**

Bài viết này cho thấy cách định dạng văn bản trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho PHP qua Java. Nội dung bao gồm việc đánh dấu, màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn, hành vi tự động điều chỉnh, neo văn bản, tab, và cài đặt ngôn ngữ.

Trong các ví dụ bên dưới, chúng tôi sẽ sử dụng tệp có tên **sample.pptx**, chứa một hộp văn bản duy nhất trên slide đầu tiên với văn bản sau:

![Văn bản mẫu](sample_text.png)

## **Đánh dấu văn bản**

Sử dụng phương thức [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/)`::highlightText` khi bạn cần đánh dấu văn bản khớp với một mẫu cụ thể trong khung văn bản. Phương thức này áp dụng màu nền cho các đoạn văn bản khớp và có thể được sử dụng cùng với [TextHighlightingOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/texthighlightingoptions/) để kiểm soát cách tìm kiếm, ví dụ chỉ khớp toàn bộ từ.

Mẫu mã dưới đây đánh dấu tất cả các lần xuất hiện của ký tự **"try"** và sau đó chỉ đánh dấu từ **"to"** đầy đủ.

```php
$presentation = new Presentation("sample.pptx");
try {
    // Lấy hình dạng đầu tiên từ slide đầu tiên.
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $lightBlue = new Java("java.awt.Color", 173, 216, 230);
    $violet = new Java("java.awt.Color", 238, 130, 238);

    // Đánh dấu từ "try" trong hình dạng.
    $shape->getTextFrame()->highlightText("try", $lightBlue);

    $searchOptions = new TextHighlightingOptions();
    $searchOptions->setWholeWordsOnly(true);

    // Đánh dấu từ "to" trong hình dạng.
    $shape->getTextFrame()->highlightText("to", $violet, $searchOptions);

    $presentation->save("highlighted_text.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Văn bản đã đánh dấu](highlighted_text.png)

## **Đánh dấu văn bản bằng biểu thức chính quy**

Phương thức [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/)`::highlightRegex` đánh dấu các kết quả khớp được tìm thấy bằng biểu thức chính quy.

Mẫu mã dưới đây đánh dấu tất cả các từ chứa **bảy ký tự trở lên**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    // Đánh dấu tất cả các từ có bảy ký tự trở lên.
    $shape->getTextFrame()->highlightRegex("\\b[^\\s]{7,}\\b", java("java.awt.Color")->YELLOW, null);

    $presentation->save("highlighted_text_using_regex.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Văn bản đã đánh dấu bằng biểu thức chính quy](highlighted_text_using_regex.png)

## **Đặt màu nền cho văn bản**

Sử dụng định dạng phần mặc định của [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/) để đặt màu nền mặc định cho một đoạn, hoặc sử dụng [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/) cho các phần văn bản riêng lẻ.

Mẫu mã sau cho thấy cách đặt màu nền cho **toàn bộ đoạn**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Đặt màu nền đánh dấu cho toàn bộ đoạn.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn bản màu xám](gray_paragraph.png)

Mẫu mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông đậm**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Đặt màu nền đánh dấu cho phần văn bản.
            $portion->getPortionFormat()->getHighlightColor()->setColor(java("java.awt.Color")->LIGHT_GRAY);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn chỉnh các đoạn văn bản**

Sử dụng phương thức [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/)`::setAlignment` để đặt căn chỉnh đoạn trong khung văn bản. Giá trị có thể là căn giữa, căn trái, căn phải, căn đều, v.v.

Mẫu mã sau cho thấy cách căn đoạn về **giữa**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Đặt căn chỉnh của đoạn thành trung tâm.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn bản đã căn chỉnh](aligned_paragraph.png)

## **Đặt độ trong suốt cho văn bản**

Độ trong suốt của văn bản được điều khiển thông qua thành phần alpha của màu được chỉ định cho định dạng nền của [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0‑255, không phải là phần trăm trong suốt.

Mẫu mã sau cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Đặt màu tô của văn bản thành màu trong suốt.
    $fillFormat->setFillType(FillType::Solid);
    $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn bản trong suốt](transparent_paragraph.png)

Mẫu mã dưới đây cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông đậm**:

```php
$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Đặt độ trong suốt cho phần văn bản.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor(new Java("java.awt.Color", 0, 0, 0, $alpha));
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt khoảng cách ký tự cho văn bản**

Sử dụng phương thức [BasePortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/)`::setSpacing` để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong hộp văn bản.

Mã PHP sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Mở rộng khoảng cách ký tự.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn](character_spacing_in_paragraph.png)

Mẫu mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông đậm**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
            $portion->getPortionFormat()->setSpacing(3); // Mở rộng khoảng cách ký tự.
        }
    }

    $presentation->save("character_spacing_in_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong các phần văn bản](character_spacing_in_text_portions.png)

### **Vô hiệu hóa Kerning cho các phông chữ cụ thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để làm cho đầu ra render gần với PowerPoint hơn trong những trường hợp này, bạn có thể vô hiệu hóa kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt phương thức [BasePortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/)`::setKerningMinimalSize` thành một giá trị lớn hơn đáng kể so với kích thước phông chữ thực tế:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portionFormat->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Cài đặt này ngăn kerning được áp dụng cho các phần văn bản khớp và có thể giúp đồng bộ việc render của Aspose.Slides với đầu ra trực quan của PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint này.

## **Quản lý thuộc tính phông chữ của văn bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn thông qua định dạng phần mặc định của [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/) hoặc trên các phần riêng lẻ qua [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/).

Mẫu mã sau đặt phông chữ và kiểu văn bản cho toàn bộ đoạn: áp dụng kích thước phông, in đậm, in nghiêng, gạch chân chấm và phông Times New Roman cho tất cả các phần trong đoạn.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();

    // Đặt thuộc tính phông chữ cho đoạn.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont(new FontData("Times New Roman"));

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho đoạn](font_properties_for_paragraph.png)

Mẫu mã dưới đây áp dụng các thuộc tính tương tự cho **các phần văn bản có phông đậm**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold()) === NullableBool::True) {
            // Đặt thuộc tính phông chữ cho phần văn bản.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont(new FontData("Times New Roman"));
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt xoay văn bản**

Sử dụng phương thức [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/)`::setTextVerticalType` để đặt hướng văn bản cố định trong một hình dạng.

Mẫu mã sau đặt hướng văn bản trong hình dạng thành `Vertical270`, làm cho văn bản **xoay 90 độ ngược chiều kim đồng hồ**:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt xoay tùy chỉnh cho các khung văn bản**

Sử dụng phương thức [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/)`::setRotationAngle` để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/).

Mẫu mã dưới đây xoay khung văn bản 3 độ theo chiều kim đồng hồ trong hình dạng:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Xoay tùy chỉnh văn bản](custom_text_rotation.png)

## **Đặt khoảng cách dòng cho các đoạn văn**

Aspose.Slides cung cấp các phương thức [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/)`::setSpaceAfter`, `ParagraphFormat::setSpaceBefore` và `ParagraphFormat::setSpaceWithin` để kiểm soát khoảng cách đoạn. Các phương thức này được sử dụng như sau:

* Dùng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm chiều cao dòng.
* Dùng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Mẫu mã sau cho thấy cách chỉ định khoảng cách dòng trong đoạn:

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Khoảng cách dòng trong đoạn](line_spacing.png)

## **Đặt loại tự động điều chỉnh cho các khung văn bản**

Phương thức [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/)`::setAutofitType` xác định cách văn bản hành xử khi vượt quá giới hạn của vùng chứa. Sử dụng để kiểm soát việc văn bản co lại, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt neo cho các khung văn bản**

Phương thức [TextFrameFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/)`::setAnchoringType` xác định cách văn bản được định vị theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt tab cho văn bản**

Sử dụng phương thức [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/)`::setDefaultTabSize` và bộ sưu tập tab của nó để cấu hình các vị trí tab trong một đoạn.

```php
$presentation = new Presentation("sample.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Tab của đoạn](paragraph_tabs.png)

## **Đặt ngôn ngữ kiểm tra chính tả**

Aspose.Slides cung cấp phương thức [BasePortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/)`::setLanguageId`, cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ này quyết định ngôn ngữ được dùng cho việc kiểm tra chính tả và ngữ pháp trong PowerPoint.

Mẫu mã sau cho thấy cách đặt ngôn ngữ kiểm tra cho một phần văn bản:

```php
$presentation = new Presentation("presentation.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Đặt ID của ngôn ngữ kiểm tra.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1.");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt ngôn ngữ mặc định**

Sử dụng phương thức [LoadOptions](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/)`::setDefaultTextLanguage` để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình chiếu.

```php
$loadOptions = new LoadOptions();
$loadOptions->setDefaultTextLanguage("en-US");

$presentation = new Presentation($loadOptions);
try {
    $slide = $presentation->getSlides()->get_Item(0);

    // Thêm một hình chữ nhật mới có văn bản.
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 50);
    $shape->getTextFrame()->setText("Sample text");

    // Kiểm tra ngôn ngữ của phần văn bản đầu tiên.
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    echo $portion->getPortionFormat()->getLanguageId();
} finally {
    $presentation->dispose();
}
```

## **Đặt kiểu văn bản mặc định**

Để áp dụng định dạng văn bản mặc định ở cấp độ bản trình chiếu, sử dụng kiểu văn bản mặc định của [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/).

Mẫu mã sau thiết lập phông chữ đậm mặc định với kích thước 14 pt cho tất cả văn bản trên các slide trong một bản trình chiếu mới.

```php
$presentation = new Presentation();
try {
    // Lấy định dạng đoạn cấp cao nhất.
    $paragraphFormat = $presentation->getDefaultTextStyle()->getLevel(0);

    if (!java_is_null($paragraphFormat)) {
        $paragraphFormat->getDefaultPortionFormat()->setFontHeight(14);
        $paragraphFormat->getDefaultPortionFormat()->setFontBold(NullableBool::True);
    }

    $presentation->save("default_text_style.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Trích xuất văn bản với hiệu ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng **All Caps** làm cho văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi nó được gõ bằng chữ thường. Khi bạn truy xuất phần văn bản như vậy bằng Aspose.Slides, thư viện sẽ trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về sang chữ hoa khi giá trị là `All`.

Giả sử chúng ta có hộp văn bản sau trên slide đầu tiên của tệp **sample2.pptx**.

![Hiệu ứng All Caps](all_caps_effect.png)

Mẫu mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```php
$presentation = new Presentation("sample2.pptx");
try {
    $autoShape = $presentation->getSlides()->get_Item(0)->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    echo "Original text: ", $textPortion->getText(), "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($textPortion->getText());
        echo "All-Caps effect: ", $text, "\n";
    }
} finally {
    $presentation->dispose();
}
```

Kết quả:

```text
Original text: Hello, Aspose!
All-Caps effect: HELLO, ASPOSE!
```

## **Câu hỏi thường gặp**

**Làm thế nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô thông qua khung văn bản của [Cell](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/) và định dạng đoạn của [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/)`.

**Làm thế nào để áp dụng màu gradient cho văn bản trong slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng định dạng nền của [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/). Đặt kiểu tô của [FillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/) thành [FillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) `Gradient` và cấu hình các điểm dừng gradient, hướng và độ trong suốt.