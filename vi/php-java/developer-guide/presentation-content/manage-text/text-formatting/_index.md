---
title: Định dạng văn bản trình chiếu trong PHP
linktitle: Định dạng văn bản
type: docs
weight: 50
url: /vi/php-java/text-formatting/
keywords:
- căn đoạn văn
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
- tab văn bản
- ngôn ngữ mặc định
- PowerPoint
- OpenDocument
- bản trình bày
- PHP
- Aspose.Slides
description: "Định dạng và tạo kiểu văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java. Tùy chỉnh phông chữ, màu sắc, căn chỉnh và nhiều hơn nữa."
---
## **Tổng quan**

Bài viết này mô tả cách định dạng văn bản trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho PHP thông qua Java. Nó bao gồm màu nền, độ trong suốt, khoảng cách ký tự, thuộc tính phông chữ, xoay, khoảng cách đoạn văn, hành vi tự động điều chỉnh kích thước, neo văn bản, vị trí tab và cài đặt ngôn ngữ.

Trừ khi được ghi chú khác, các ví dụ sử dụng [sample.pptx](sample.pptx). Đối tượng hình dạng đầu tiên trên slide đầu tiên là một hộp văn bản, và đoạn văn đầu tiên của nó chứa văn bản được hiển thị bên dưới. Cả chỉ số slide và hình dạng đều bắt đầu từ 0. Các ví dụ chọn phần in đậm sử dụng định dạng hiệu lực, bao gồm cả định dạng in đậm kế thừa:

![Văn bản mẫu](sample_text.png)

Để tìm và làm nổi bật văn bản nguyên bản hoặc các kết quả khớp biểu thức chính quy, xem [Search and Replace Text](/slides/vi/php-java/search-and-replace-text/).

## **Đặt Màu Nền Cho Văn Bản**

Sử dụng [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) để đặt màu nổi bật mặc định cho một đoạn văn, hoặc sử dụng [BasePortionFormat::getHighlightColor](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#getHighlightColor) cho các phần văn bản riêng lẻ.

Ví dụ sau đặt màu nổi bật xám nhạt làm mặc định cho đoạn văn đầu tiên. Màu nổi bật cụ thể trên các phần riêng lẻ sẽ có độ ưu tiên cao hơn mặc định này:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    // Đặt màu nổi bật cho toàn bộ đoạn văn.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getHighlightColor()->setColor($highlightColor);

    $presentation->save("gray_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn màu xám](gray_paragraph.png)

Ví dụ mã dưới đây minh họa cách đặt màu nền cho **các phần văn bản có phông đậm**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $highlightColor = java("java.awt.Color")->LIGHT_GRAY;

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Đặt màu nổi bật cho phần văn bản.
            $portion->getPortionFormat()->getHighlightColor()->setColor($highlightColor);
        }
    }

    $presentation->save("gray_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các phần văn bản màu xám](gray_text_portions.png)

## **Căn Lề Các Đoạn Văn Bản**

Sử dụng [ParagraphFormat::setAlignment](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setAlignment) để cài đặt căn lề đoạn văn trong một khung văn bản. Giá trị có thể là centered, left-aligned, right-aligned, justified, v.v.

Ví dụ mã sau cho thấy cách căn đoạn văn **ở trung tâm**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Đặt căn chỉnh của đoạn văn thành trung tâm.
    $paragraph->getParagraphFormat()->setAlignment(TextAlignment::Center);

    $presentation->save("aligned_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn đã căn chỉnh](aligned_paragraph.png)

## **Đặt Độ Trong Suốt Cho Văn Bản**

Độ trong suốt của văn bản được điều khiển thông qua thành phần alpha của màu được gán cho [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#getFillFormat). Trong các ví dụ dưới đây, `alpha = 50` là giá trị kênh alpha ARGB trên thang 0–255, không phải là phần trăm độ trong suốt.

Ví dụ mã dưới đây cho thấy cách áp dụng độ trong suốt cho **toàn bộ đoạn văn**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $fillFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat()->getFillFormat();

    // Đặt màu tô của văn bản thành màu trong suốt.
    $fillFormat->setFillType(FillType::Solid);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);
    $fillFormat->getSolidFillColor()->setColor($transparentColor);

    $presentation->save("transparent_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Đoạn văn trong suốt](transparent_paragraph.png)

Ví dụ mã sau cho thấy cách áp dụng độ trong suốt cho **các phần văn bản có phông đậm**:

```php
use aspose\slides\FillType;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$alpha = 50;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $transparentColor = new Java("java.awt.Color", 0, 0, 0, $alpha);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Đặt độ trong suốt cho phần văn bản.
            $fillFormat = $portion->getPortionFormat()->getFillFormat();
            $fillFormat->setFillType(FillType::Solid);
            $fillFormat->getSolidFillColor()->setColor($transparentColor);
        }
    }

    $presentation->save("transparent_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các phần văn bản trong suốt](transparent_text_portions.png)

## **Đặt Khoảng Cách Ký Tự Cho Văn Bản**

Sử dụng [BasePortionFormat::setSpacing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setSpacing) để mở rộng hoặc thu hẹp khoảng cách giữa các ký tự trong một hộp văn bản. Các ví dụ thêm 3 điểm khoảng cách; giá trị âm sẽ làm văn bản lại gần nhau.

Mã PHP sau cho thấy cách mở rộng khoảng cách ký tự trong **toàn bộ đoạn văn**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    // Lưu ý: Sử dụng giá trị âm để nén khoảng cách ký tự.
    $paragraph->getParagraphFormat()->getDefaultPortionFormat()->setSpacing(3); // Mở rộng khoảng cách ký tự.

    $presentation->save("character_spacing_in_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Khoảng cách ký tự trong đoạn văn](character_spacing_in_paragraph.png)

Ví dụ mã dưới đây cho thấy cách mở rộng khoảng cách ký tự trong **các phần văn bản có phông đậm**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
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

### **Tắt Kerning cho Các Phông Chữ Cụ Thể**

Trong một số trường hợp, văn bản được render bởi Aspose.Slides có thể trông hơi chặt hơn so với cùng văn bản hiển thị trong PowerPoint. Điều này có thể xảy ra vì PowerPoint có thể bỏ qua dữ liệu kerning cho một số phông chữ, ngay cả khi phông chữ đó chứa thông tin kerning hợp lệ và kerning đã được bật trong cài đặt PowerPoint.

Để đưa kết quả render gần hơn với PowerPoint trong những trường hợp này, bạn có thể tắt kerning cho các phần văn bản sử dụng phông chữ bị ảnh hưởng. Đặt [BasePortionFormat::setKerningMinimalSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setKerningMinimalSize) thành giá trị lớn hơn kích thước phông chữ thực tế. Ví dụ này yêu cầu file "presentation.pptx" có một hộp văn bản là đối tượng hình dạng đầu tiên trên slide đầu tiên. Nó kiểm tra tên phông chữ hiệu lực, bao gồm các phông chữ kế thừa, và đặt ngưỡng 100 điểm cho các phần sử dụng Roboto. Điều này tắt kerning cho các phần phù hợp có kích thước phông chữ dưới 100 điểm:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $targetFont = "Roboto";

    $paragraphCount = java_values($autoShape->getTextFrame()->getParagraphs()->getCount());
    for ($paragraphIndex = 0; $paragraphIndex < $paragraphCount; $paragraphIndex++) {
        $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
        $portionCount = java_values($paragraph->getPortions()->getCount());
        for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
            $portion = $paragraph->getPortions()->get_Item($portionIndex);
            $portionFormat = $portion->getPortionFormat()->getEffective();
            $latinFont = $portionFormat->getLatinFont();
            $eastAsianFont = $portionFormat->getEastAsianFont();
            $complexScriptFont = $portionFormat->getComplexScriptFont();

            if ((!java_is_null($latinFont) && $latinFont->getFontName() == $targetFont) ||
                (!java_is_null($eastAsianFont) && $eastAsianFont->getFontName() == $targetFont) ||
                (!java_is_null($complexScriptFont) && $complexScriptFont->getFontName() == $targetFont)) {
                $portion->getPortionFormat()->setKerningMinimalSize(100);
            }
        }
    }

    $presentation->save("output.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Đối với văn bản phù hợp dưới ngưỡng, cài đặt này ngăn kerning và có thể giúp render của Aspose.Slides đồng bộ hơn với kết quả trực quan của PowerPoint đối với các phông chữ bị ảnh hưởng bởi hành vi đặc thù của PowerPoint.

## **Quản Lý Thuộc Tính Phông Chữ Cho Văn Bản**

Thuộc tính phông chữ có thể được đặt ở mức đoạn văn thông qua [ParagraphFormat::getDefaultPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getDefaultPortionFormat) hoặc trên các phần riêng lẻ thông qua [PortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portionformat/).

Ví dụ sau đặt phông chữ mặc định cho đoạn văn đầu tiên là Times New Roman 12 điểm với định dạng in đậm, in nghiêng và gạch chân chấm. Định dạng cụ thể trên các phần riêng lẻ sẽ có độ ưu tiên cao hơn các mặc định này:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $defaultPortionFormat = $paragraph->getParagraphFormat()->getDefaultPortionFormat();
    $font = new FontData("Times New Roman");

    // Đặt các thuộc tính phông chữ cho đoạn văn.
    $defaultPortionFormat->setFontHeight(12);
    $defaultPortionFormat->setFontBold(NullableBool::True);
    $defaultPortionFormat->setFontItalic(NullableBool::True);
    $defaultPortionFormat->setFontUnderline(TextUnderlineType::Dotted);
    $defaultPortionFormat->setLatinFont($font);

    $presentation->save("font_properties_for_paragraph.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho đoạn văn](font_properties_for_paragraph.png)

Ví dụ sau áp dụng Times New Roman 13 điểm, định dạng in nghiêng và gạch chân chấm cho các phần có định dạng hiệu lực là in đậm:

```php
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextUnderlineType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $font = new FontData("Times New Roman");

    $portionCount = java_values($paragraph->getPortions()->getCount());
    for ($portionIndex = 0; $portionIndex < $portionCount; $portionIndex++) {
        $portion = $paragraph->getPortions()->get_Item($portionIndex);
        if (java_values($portion->getPortionFormat()->getEffective()->getFontBold())) {
            // Đặt các thuộc tính phông chữ cho phần văn bản.
            $portionFormat = $portion->getPortionFormat();
            $portionFormat->setFontHeight(13);
            $portionFormat->setFontItalic(NullableBool::True);
            $portionFormat->setFontUnderline(TextUnderlineType::Dotted);
            $portionFormat->setLatinFont($font);
        }
    }

    $presentation->save("font_properties_for_text_portions.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Thuộc tính phông chữ cho các phần văn bản](font_properties_for_text_portions.png)

## **Đặt Xoay Văn Bản**

Sử dụng [TextFrameFormat::setTextVerticalType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setTextVerticalType) để đặt hướng văn bản định trước trong một hình dạng.

Ví dụ mã sau đặt hướng văn bản trong hình dạng thành [TextVerticalType::Vertical270](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textverticaltype/), khiến văn bản **xoay 90 độ ngược chiều kim đồng hồ**:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextVerticalType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setTextVerticalType(TextVerticalType::Vertical270);

    $presentation->save("text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Xoay văn bản](text_rotation.png)

## **Đặt Xoay Tùy Chỉnh Cho Khung Văn Bản**

Sử dụng [TextFrameFormat::setRotationAngle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setRotationAngle) để đặt góc xoay tùy chỉnh cho một [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframe/).

Mã dưới đây xoay khung văn bản lên 3 độ theo chiều kim đồng hồ trong hình dạng:

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setRotationAngle(3);

    $presentation->save("custom_text_rotation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Xoay văn bản tùy chỉnh](custom_text_rotation.png)

## **Đặt Khoảng Cách Dòng Cho Đoạn Văn**

Aspose.Slides cung cấp [ParagraphFormat::setSpaceAfter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setSpaceAfter), [ParagraphFormat::setSpaceBefore](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setSpaceBefore) và [ParagraphFormat::setSpaceWithin](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setSpaceWithin) để điều khiển khoảng cách đoạn. Các thuộc tính này được sử dụng như sau:

* Sử dụng giá trị dương để chỉ định khoảng cách dòng dưới dạng phần trăm của chiều cao dòng.
* Sử dụng giá trị âm để chỉ định khoảng cách dòng bằng điểm.

Ví dụ sau đặt khoảng cách trong đoạn văn đầu tiên thành 200 % chiều cao dòng (độ cách dòng gấp đôi):

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setSpaceWithin(200);

    $presentation->save("line_spacing.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Khoảng cách dòng trong đoạn văn](line_spacing.png)

## **Kiểm Soát Ngắt Dòng**

Các quy tắc ngắt dòng của đoạn văn hữu ích trong các khối văn bản hẹp và các bản trình bày pha trộn văn bản Latin và Đông Á. Các phương pháp sau thuộc về [ParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/), do đó chúng áp dụng cho toàn bộ đoạn văn:

- [setLatinLineBreak](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setLatinLineBreak) điều khiển quy tắc ngắt dòng Latin. Trong văn bản hỗn hợp, việc thay đổi nó cũng có thể thay đổi vị trí ngắt của văn bản và dấu câu Đông Á liền kề.
- [setEastAsianLineBreak](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setEastAsianLineBreak) điều khiển quy tắc ngắt dòng Đông Á, bao gồm các hạn chế về ký tự ở đầu và cuối dòng.

Các quy tắc này không thay thế [TextFrameFormat::setWrapText](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setWrapText), chức năng này bật tự động gói trong khung văn bản. Chúng ảnh hưởng đến bố cục khi gói xảy ra; chúng không chèn ký tự ngắt dòng. Một ký tự ngắt dòng rõ ràng buộc một dòng mới trong đoạn văn bất kể chiều rộng khả dụng.

Ví dụ tự chứa dưới đây tạo một khối văn bản hẹp chứa tiếng Trung và Latin. Nó đặt cả hai tùy chọn ngắt dòng một cách rõ ràng và lưu file "line_breaking.pptx". Để thử nghiệm một trong các quy tắc, thay đổi giá trị tương ứng trong khi giữ các cài đặt khác cố định. Ví dụ sử dụng Arial 24 điểm và SimSun, khung có chiều rộng 160 điểm và lề ngang bằng 0. [TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setAutofitType) được gọi với [TextAutofitType::None](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textautofittype/) để kích thước văn bản và khung giữ cố định.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 160, 300);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("中文排版测试，PowerPoint 中文演示。");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $eastAsianFont = new FontData("SimSun");
    $format->getDefaultPortionFormat()->setEastAsianFont($eastAsianFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setLatinLineBreak(NullableBool::False);
    $format->setEastAsianLineBreak(NullableBool::True);

    $presentation->save("line_breaking.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Kiểm Soát Dấu Điểm Treo**

[ParagraphFormat::setHangingPunctuation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setHangingPunctuation) cho phép các dấu câu đủ điều kiện kéo dài ra ngoài cạnh phải của dòng văn bản thay vì chiếm dòng tiếp theo. Nó áp dụng cho toàn bộ đoạn văn và khác với lề treo.

Ví dụ tự chứa dưới đây bật dấu câu treo trong một khung văn bản rộng 100 điểm và lưu file "hanging_punctuation.pptx". Với Arial 24 điểm và lề ngang bằng 0, dấu chấm cuối cùng vẫn ở sau từ "sentence" và kéo dài ra ngoài cạnh phải. Đặt thuộc tính thành [NullableBool::False](https://reference.aspose.com/slides/vi/php-java/aspose.slides/nullablebool/) để so sánh: với cài đặt này, dấu chấm sẽ nằm trên một dòng riêng. Việc gói văn bản được bật và autofit bị tắt để giữ chiều rộng khả dụng cố định.

```php
use aspose\slides\FillType;
use aspose\slides\FontData;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;
use aspose\slides\TextAlignment;
use aspose\slides\TextAutofitType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 50, 50, 100, 200);
    $shape->getFillFormat()->setFillType(FillType::NoFill);

    $textFrame = $shape->getTextFrame();
    $textFrame->getTextFrameFormat()->setWrapText(NullableBool::True);
    $textFrame->getTextFrameFormat()->setAutofitType(TextAutofitType::None);
    $textFrame->getTextFrameFormat()->setMarginLeft(0);
    $textFrame->getTextFrameFormat()->setMarginRight(0);

    $paragraph = $textFrame->getParagraphs()->get_Item(0);
    $paragraph->setText("Simple text, next sentence.");

    $format = $paragraph->getParagraphFormat();
    $format->setAlignment(TextAlignment::Left);
    $format->getDefaultPortionFormat()->setFontHeight(24);
    $latinFont = new FontData("Arial");
    $format->getDefaultPortionFormat()->setLatinFont($latinFont);
    $format->getDefaultPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $blackColor = java("java.awt.Color")->BLACK;
    $format->getDefaultPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($blackColor);
    $format->setHangingPunctuation(NullableBool::True);

    $presentation->save("hanging_punctuation.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Không phải mọi dấu câu đều có thể treo. Kết quả hiển thị phụ thuộc vào sự có sẵn của phông chữ và bố cục: thay đổi phông chữ, chiều rộng khả dụng, lề hoặc cài đặt autofit có thể loại bỏ sự khác biệt nhìn thấy được.

## **Đặt Kiểu Tự Động Điều Chỉnh Kích Thước Cho Khung Văn Bản**

[TextFrameFormat::setAutofitType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setAutofitType) xác định cách văn bản hành xử khi vượt quá ranh giới của vùng chứa. Sử dụng nó để kiểm soát việc văn bản co lại, tràn ra ngoài hoặc tự động thay đổi kích thước hình dạng. Ví dụ sau cấu hình hình dạng để thay đổi kích thước sao cho vừa với văn bản và lưu kết quả vào "autofit_type.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAutofitType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAutofitType(TextAutofitType::Shape);

    $presentation->save("autofit_type.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Để đếm số dòng sau khi tự động gói và xem cách thay đổi độ rộng văn bản hoặc hình dạng ảnh hưởng đến kết quả, xem [Count Rendered Lines](/slides/vi/php-java/manage-paragraph/). Số lượng dòng một mình không cho biết liệu văn bản có tràn ra ngoài vùng chứa hay không.

## **Đặt Neo Cho Khung Văn Bản**

[TextFrameFormat::setAnchoringType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textframeformat/#setAnchoringType) xác định cách vị trí văn bản theo chiều dọc bên trong một hình dạng, ví dụ ở trên, giữa hoặc dưới. Ví dụ sau neo văn bản vào phần dưới của hình dạng đầu tiên và lưu kết quả vào "text_anchor.pptx".

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TextAnchorType;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);
    $autoShape->getTextFrame()->getTextFrameFormat()->setAnchoringType(TextAnchorType::Bottom);

    $presentation->save("text_anchor.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Tab Văn Bản**

Sử dụng [ParagraphFormat::setDefaultTabSize](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#setDefaultTabSize) và [ParagraphFormat::getTabs](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraphformat/#getTabs) để cấu hình các vị trí tab trong một đoạn văn. Ví dụ sau đặt khoảng cách tab mặc định là 100 điểm và thêm một vị trí tab căn trái ở 30 điểm. Các cài đặt này ảnh hưởng đến văn bản chứa ký tự tab.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\TabAlignment;

$presentation = new Presentation("sample.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getParagraphFormat()->setDefaultTabSize(100);
    $paragraph->getParagraphFormat()->getTabs()->add(30, TabAlignment::Left);

    $presentation->save("paragraph_tabs.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

Kết quả:

![Các tab trong đoạn văn](paragraph_tabs.png)

## **Đặt Ngôn Ngữ Kiểm Tra Chính Tả**

Aspose.Slides cung cấp [BasePortionFormat::setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId), cho phép bạn đặt ngôn ngữ kiểm tra chính tả cho một phần văn bản. Ngôn ngữ kiểm tra quyết định ngôn ngữ được dùng để kiểm tra chính tả và ngữ pháp trong PowerPoint.

Ví dụ sau yêu cầu "presentation.pptx" có một hộp văn bản là đối tượng hình dạng đầu tiên trên slide đầu tiên và ít nhất một đoạn văn. Nó thay thế nội dung của đoạn văn đầu tiên bằng "1。", đặt SimSun làm phông chữ và gán ngôn ngữ chứng minh Simplified Chinese (`zh-CN`). Kết quả được lưu vào "proofing_language.pptx":

```php
use aspose\slides\FontData;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("presentation.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);

    $autoShape = $slide->getShapes()->get_Item(0);

    $paragraph = $autoShape->getTextFrame()->getParagraphs()->get_Item(0);
    $paragraph->getPortions()->clear();

    $font = new FontData("SimSun");

    $textPortion = new Portion();
    $textPortion->getPortionFormat()->setComplexScriptFont($font);
    $textPortion->getPortionFormat()->setEastAsianFont($font);
    $textPortion->getPortionFormat()->setLatinFont($font);

    // Đặt Id của một ngôn ngữ kiểm tra.
    $textPortion->getPortionFormat()->setLanguageId("zh-CN");

    $textPortion->setText("1。");
    $paragraph->getPortions()->add($textPortion);

    $presentation->save("proofing_language.pptx", SaveFormat::Pptx);
} finally {
    $presentation->dispose();
}
```

## **Đặt Ngôn Ngữ Mặc Định**

Sử dụng [LoadOptions::setDefaultTextLanguage](https://reference.aspose.com/slides/vi/php-java/aspose.slides/loadoptions/#setDefaultTextLanguage) để xác định ngôn ngữ mặc định cho văn bản được tạo khi tải hoặc tạo một bản trình bày. Ví dụ sau tạo một bản trình bày với tiếng Anh Mỹ làm ngôn ngữ văn bản mặc định, thêm một hộp văn bản và in `en-US` cho phần văn bản đầu tiên của nó.

```php
use aspose\slides\LoadOptions;
use aspose\slides\Presentation;
use aspose\slides\ShapeType;

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

## **Đặt Kiểu Văn Bản Mặc Định**

Để áp dụng định dạng văn bản mặc định ở mức bản trình bày, sử dụng [Presentation::getDefaultTextStyle](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#getDefaultTextStyle).

Ví dụ sau đặt phông chữ đậm 14 điểm làm mặc định cho các đoạn văn cấp cao nhất trong một bản trình bày mới và lưu nó vào "default_text_style.pptx". Văn bản có thể kế thừa các mặc định này trừ khi có định dạng cụ thể hơn ghi đè lên chúng.

```php
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation();
try {
    // Lấy định dạng đoạn văn cấp cao nhất.
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

## **Trích Xuất Văn Bản Với Hiệu Ứng All-Caps**

Trong PowerPoint, áp dụng hiệu ứng phông **All Caps** khiến văn bản hiển thị dưới dạng chữ hoa trên slide ngay cả khi gốc nó được gõ bằng chữ thường. Khi bạn truy xuất một phần văn bản như vậy bằng Aspose.Slides, thư viện trả về văn bản đúng như khi nhập. Để khớp với văn bản hiển thị, kiểm tra [TextCapType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textcaptype/) và chuyển chuỗi trả về thành chữ hoa khi giá trị là `All`.

Ví dụ này yêu cầu "sample2.pptx" có một hộp văn bản là đối tượng hình dạng đầu tiên trên slide đầu tiên. Phần đầu tiên của đoạn văn đầu tiên chứa "Hello, Aspose!" với hiệu ứng All Caps được áp dụng, như hình dưới.

![Hiệu ứng All Caps](all_caps_effect.png)

Mã dưới đây cho thấy cách trích xuất văn bản với hiệu ứng **All Caps** đã được áp dụng:

```php
use aspose\slides\Presentation;
use aspose\slides\TextCapType;

$presentation = new Presentation("sample2.pptx");
try {
    $slide = $presentation->getSlides()->get_Item(0);
    
    $autoShape = $slide->getShapes()->get_Item(0);
    $textPortion = $autoShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);

    $originalText = $textPortion->getText();
    echo "Original text: ", $originalText, "\n";

    $textFormat = $textPortion->getPortionFormat()->getEffective();
    if (java_values($textFormat->getTextCapType()) === TextCapType::All) {
        $text = strtoupper($originalText);
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

## **Câu Hỏi Thường Gặp**

**Làm cách nào để sửa đổi văn bản trong bảng trên một slide?**

Để sửa đổi văn bản trong bảng trên một slide, sử dụng [Table](https://reference.aspose.com/slides/vi/php-java/aspose.slides/table/). Duyệt qua các ô và cập nhật mỗi ô qua [Cell::getTextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/cell/#getTextFrame) và định dạng đoạn văn qua [Paragraph::getParagraphFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/#getParagraphFormat).

**Làm thế nào để áp dụng màu gradient cho văn bản trên slide PowerPoint?**

Để áp dụng màu gradient cho văn bản, sử dụng [BasePortionFormat::getFillFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#getFillFormat). Đặt [FillFormat::setFillType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fillformat/#setFillType) thành [FillType::Gradient](https://reference.aspose.com/slides/vi/php-java/aspose.slides/filltype/) và cấu hình các điểm dừng gradient, hướng và độ trong suốt.