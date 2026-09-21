---
title: Quản lý các Trường Văn bản trong Bản trình chiếu PowerPoint bằng PHP
linktitle: Trường Văn bản
type: docs
weight: 52
url: /vi/php-java/text-fields/
keywords:
- trường văn bản
- văn bản tự động
- số slide
- ngày và giờ
- tiêu đề
- chân trang
- phần văn bản
- PowerPoint
- PPT
- PPTX
- PHP
- Aspose.Slides
description: "Tạo, kiểm tra, sửa đổi và xóa các trường văn bản trong bản trình chiếu PowerPoint bằng Aspose.Slides cho PHP qua Java. Bảo tồn định dạng và xác minh các tệp PPTX và PPT đã lưu."
---
## **Tổng quan**

Một đoạn văn bản bao gồm các phần. Một [Portion](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/) thông thường chứa văn bản nguyên bản; một phần trường (field portion) còn có một [Field](https://reference.aspose.com/slides/vi/php-java/aspose.slides/field/) mà loại của nó xác định một giá trị được cập nhật tự động, chẳng hạn như số slide hoặc ngày. Hai phần có thể hiển thị cùng ký tự trong khi chỉ một trong số chúng chứa trường.

Sử dụng [Portion::getField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getField) để phân biệt chúng: nó trả về `null` đối với văn bản thông thường. [Portion::addField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#addField) chuyển một phần hiện có thành trường. Giữ nhãn và giá trị động của nó trong các phần riêng biệt để việc chuyển đổi giá trị không đồng thời thay thế nhãn.

Hướng dẫn này bao gồm các trường trong văn bản, cách định dạng chúng và cách lưu chúng trong PPTX và PPT. Đối với khung văn bản và các đoạn, xem [Manage Text](/slides/vi/php-java/manage-text/).

## **Tạo trường Số Slide**

Ví dụ đầy đủ dưới đây tạo một hộp văn bản chứa nhãn nguyên bản `Slide ` sau đó là số được cập nhật tự động. Nó đặt kích thước, độ đậm và màu của số trước khi thêm trường, sau đó mở lại bản trình chiếu đã lưu và kiểm tra loại trường, văn bản và định dạng. Không cần tệp đầu vào.

```php
use aspose\slides\FieldType;
use aspose\slides\FillType;
use aspose\slides\NullableBool;
use aspose\slides\Portion;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $slide = $presentation->getSlides()->get_Item(0);
    $shape = $slide->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 240, 50);
    $shape->addTextFrame("Slide ");
    $paragraph = $shape->getTextFrame()->getParagraphs()->get_Item(0);

    $numberPortion = new Portion();
    $numberColor = new Java("java.awt.Color", 0, 0, 139);
    $numberPortion->getPortionFormat()->setFontHeight(24);
    $numberPortion->getPortionFormat()->setFontBold(NullableBool::True);
    $numberPortion->getPortionFormat()->getFillFormat()->setFillType(FillType::Solid);
    $numberPortion->getPortionFormat()->getFillFormat()->getSolidFillColor()->setColor($numberColor);
    $paragraph->getPortions()->add($numberPortion);
    $numberPortion->addField(FieldType::getSlideNumber());

    $presentation->save("slide_number.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("slide_number.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedNumber = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(1);
        $savedField = $savedNumber->getField();
        $hasNumberField = !java_is_null($savedField) && java_values(FieldType::getSlideNumber()->getInternalString()) === java_values($savedField->getType()->getInternalString());
        $format = $savedNumber->getPortionFormat();
        $formattingPreserved = java_values($format->getFontHeight()) == 24 && java_values($format->getFontBold()) == NullableBool::True;
        $formattingPreserved = $formattingPreserved && java_values($format->getFillFormat()->getSolidFillColor()->getColor()->getRGB()) == java_values($numberColor->getRGB());

        echo "Text: " . $savedShape->getTextFrame()->getText() . PHP_EOL;
        echo "Slide number field: " . ($hasNumberField ? "true" : "false") . PHP_EOL;
        echo "Formatting preserved: " . ($formattingPreserved ? "true" : "false") . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Bản trình chiếu mới bắt đầu với số slide 1, vì vậy văn bản là `Slide 1`, và cả hai kiểm tra đều in ra `true`. Số vẫn là một trường sau khi mở lại; nó không phải là nguyên văn bản `1`. Các chỉ mục trong quá trình xác minh đề cập đến hình dạng và các phần được tạo bởi ví dụ này.

## **Chọn loại Trường**

[FieldType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/) cung cấp các phương thức sau để lấy các giá trị định trước. Gửi giá trị phù hợp tới [addField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#addField).

| Phương thức | Mục đích |
|---|---|
| [getSlideNumber](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getSlideNumber) | Số slide hiện tại. |
| [getDateTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime) | Ngày/giờ theo định dạng mặc định của ứng dụng rendering. |
| [getDateTime1](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime1)–[getDateTime9](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime9) | Định dạng ngày hoặc ngày/giờ kết hợp đã được định trước. |
| [getDateTime10](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime10)–[getDateTime13](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime13) | Định dạng thời gian đã định trước, có tùy chọn giây và đồng hồ 12 giờ. |
| [getHeader](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getHeader) | Trường tiêu đề; xem các hạn chế về placeholder và định dạng bên dưới. |
| [getFooter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getFooter) | Trường chân trang. |

Ví dụ, [getDateTime3](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getDateTime3) đại diện cho ngày, tên tháng đầy đủ và năm bằng tiếng Anh. Đây là các định dạng trường đã được định trước, không phải chuỗi định dạng ngày PHP tùy ý. Ngôn ngữ được đặt bằng [setLanguageId](https://reference.aspose.com/slides/vi/php-java/aspose.slides/baseportionformat/#setLanguageId) và ứng dụng xử lý bản trình chiếu có thể ảnh hưởng đến kết quả hiển thị.

## **Tạo Trường từ Chuỗi Nội bộ**

Phiên bản nhận chuỗi của [addField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#addField) chấp nhận một định danh trường nội bộ. Sử dụng nó khi cần bảo tồn định danh do ứng dụng khác cung cấp mà không có giá trị định trước. Bạn cũng có thể tạo một [FieldType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#FieldType) từ định danh này. [FieldType::getInternalString](https://reference.aspose.com/slides/vi/php-java/aspose.slides/fieldtype/#getInternalString) cho phép kiểm tra định danh đó.

Ví dụ này lưu trữ một trường `custom-report-id` đặc thù cho ứng dụng với văn bản dự phòng `Report-042`. Định danh này không đăng ký tính toán: Aspose.Slides không tạo ID báo cáo cho kiểu không xác định. Ứng dụng hiểu định danh này phải cung cấp ý nghĩa và cập nhật giá trị.

```php
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;
use aspose\slides\ShapeType;

$presentation = new Presentation();
try {
    $shape = $presentation->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Rectangle, 40, 40, 300, 50);
    $shape->addTextFrame("Report-042");
    $portion = $shape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
    $portion->addField("custom-report-id");

    $presentation->save("custom_field.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("custom_field.pptx");
    try {
        $savedShape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item(0);
        $savedPortion = $savedShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
        $savedField = $savedPortion->getField();
        $typeName = java_is_null($savedField) ? "ordinary text" : java_values($savedField->getType()->getInternalString());
        echo "Type: " . $typeName . PHP_EOL;
        echo "Text: " . $savedPortion->getText() . PHP_EOL;
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Sau vòng quay PPTX này, loại là `custom-report-id` và văn bản là `Report-042`. Gửi một chuỗi như `Y-m-d` sẽ đặt tên cho một loại trường; nó sẽ không cấu hình định dạng ngày tùy chỉnh. Đối với một ngày cố định ở định dạng tùy ý, hãy sử dụng văn bản thông thường.

## **Kiểm tra, Sửa đổi và Xóa Trường Ngày/Giờ**

Thay đổi một trường hiện có bằng [Field::setType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/field/#setType). Kiểm tra trường tồn tại trước khi truy cập loại của nó. Để dừng cập nhật tự động, gọi [Portion::removeField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#removeField). Thao tác này giữ lại phần và văn bản hiện tại trong khi xóa liên kết trường. Nếu bạn cần một giá trị cố định cụ thể, gán văn bản đó sau khi xóa trường.

Đối với cài đặt API liên quan tới xử lý trường ngày/giờ, xem [Presentation::setCurrentDateTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/#setCurrentDateTime). Ví dụ dưới đây sử dụng ngày phê duyệt rõ ràng khi chuyển một trường thành văn bản thông thường.

Tải xuống [sample.pptx](sample.pptx) và đặt nó vào thư mục làm việc JavaBridge, hoặc truyền đường dẫn tuyệt đối tới hàm khởi tạo bản trình chiếu. Tệp này chứa hai hình dạng văn bản có tên, `UpdatedAt` và `ApprovedDate`, mỗi cái có một trường ngày/giờ, cộng với các nhãn văn bản thông thường. Ví dụ sau duyệt các hình dạng văn bản cấp cao trên các slide thường. Nó đổi trường ngày/giờ sang định dạng ngày dài và làm chúng in nghiêng, trong khi giữ nguyên các định dạng khác. Chỉ các trường trong `ApprovedDate` trở thành văn bản cố định.

Các định danh nội bộ tích hợp `datetime` và `datetime1` đến `datetime13` được nhận dạng. Nhóm, bảng, ghi chú, bố cục và master yêu cầu duyệt các container văn bản của chúng và nằm ngoài phạm vi ví dụ này.

```php
use aspose\slides\FieldType;
use aspose\slides\NullableBool;
use aspose\slides\Presentation;
use aspose\slides\SaveFormat;

$presentation = new Presentation("sample.pptx");
try {
    $approvalDate = new DateTimeImmutable("2030-04-05");
    $autoShapeClass = new JavaClass("com.aspose.slides.AutoShape");

    for ($slideIndex = 0; $slideIndex < java_values($presentation->getSlides()->size()); $slideIndex++) {

        $slide = $presentation->getSlides()->get_Item($slideIndex);
        for ($shapeIndex = 0; $shapeIndex < java_values($slide->getShapes()->size()); $shapeIndex++) {
            $shape = $slide->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }

            for ($paragraphIndex = 0; $paragraphIndex < java_values($textShape->getTextFrame()->getParagraphs()->getCount()); $paragraphIndex++) {

                $paragraph = $textShape->getTextFrame()->getParagraphs()->get_Item($paragraphIndex);
                for ($portionIndex = 0; $portionIndex < java_values($paragraph->getPortions()->getCount()); $portionIndex++) {
                    $portion = $paragraph->getPortions()->get_Item($portionIndex);
                    $field = $portion->getField();
                    if (java_is_null($field)) {
                        continue;
                    }

                    $typeName = java_values($field->getType()->getInternalString());
                    $isDateTime = $typeName != null && preg_match("/\Adatetime([1-9]|1[0-3])?\z/", $typeName) === 1;
                    if (!$isDateTime) {
                        continue;
                    }

                    $field->setType(FieldType::getDateTime3());
                    $portion->getPortionFormat()->setLanguageId("en-US");
                    $portion->getPortionFormat()->setFontItalic(NullableBool::True);

                    if (java_values($textShape->getName()) === "ApprovedDate") {
                        $portion->removeField();
                        $fixedDate = $approvalDate->format("d F Y");
                        $portion->setText($fixedDate);
                    }
                }
            }
        }
    }

    $presentation->save("updated_dates.pptx", SaveFormat::Pptx);

    $reopened = new Presentation("updated_dates.pptx");
    try {
        for ($shapeIndex = 0; $shapeIndex < java_values($reopened->getSlides()->get_Item(0)->getShapes()->size()); $shapeIndex++) {
            $shape = $reopened->getSlides()->get_Item(0)->getShapes()->get_Item($shapeIndex);
            if (!java_instanceof($shape, $autoShapeClass)) {
                continue;
            }
            $textShape = $shape;
            if (java_is_null($textShape->getTextFrame())) {
                continue;
            }
            if (java_values($textShape->getName()) !== "UpdatedAt" && java_values($textShape->getName()) !== "ApprovedDate") {
                continue;
            }

            $portion = $textShape->getTextFrame()->getParagraphs()->get_Item(0)->getPortions()->get_Item(0);
            $field = $portion->getField();
            $typeName = java_is_null($field) ? "ordinary text" : java_values($field->getType()->getInternalString());
            echo $textShape->getName() . ": " . $typeName . "; " . $portion->getText() . PHP_EOL;
            echo "Italic: " . $portion->getPortionFormat()->getFontItalic() . PHP_EOL;
        }
    } finally {
        $reopened->dispose();
    }
} finally {
    $presentation->dispose();
}
```

Sau khi mở lại, `UpdatedAt` có loại `datetime3` và vẫn động. `ApprovedDate` không còn trường và chứa `05 April 2030`. Cả hai phần ngày đều in nghiêng, và kích thước phông chữ, thiết lập in đậm và màu gốc vẫn giữ nguyên. Các nhãn văn bản thông thường không đổi. Việc xác minh đọc phần đầu tiên của hai hình dạng đã biết trong mẫu được cung cấp.

## **Bảo tồn Định dạng Văn bản**

Làm việc với phần hiện có khi thêm trường, thay đổi loại hoặc xóa nó. Các thao tác này giữ lại định dạng của phần đó. Sử dụng [Portion::getPortionFormat](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getPortionFormat) để thay đổi chỉ các thuộc tính cần thiết, như ví dụ thay đổi màu hoặc in nghiêng.

Tránh xây dựng lại toàn bộ khung văn bản chỉ để cập nhật một trường: việc đó có thể làm mất ranh giới phần gốc và định dạng riêng của chúng. Đồng thời phân biệt định dạng được thiết lập rõ ràng với định dạng kế thừa từ đoạn, bố cục hoặc theme. Xem [Text Formatting](/slides/vi/php-java/text-formatting/) để biết các tùy chọn định dạng rộng hơn.

## **Trường và Placeholder Tiêu đề/Chân trang**

Một trường là một phần của đoạn văn bản. Một placeholder là một hình dạng có vai trò trong bản trình chiếu, chẳng hạn như chân trang hoặc số slide. Thêm trường vào một hộp văn bản thông thường không biến hình dạng đó thành placeholder.

Các quản lý tiêu đề/chân trang kiểm soát văn bản placeholder và khả năng hiển thị trên slide, bố cục và master, bao gồm việc lan truyền tới các slide phụ thuộc. Vì vậy, một trường số trong hộp văn bản tùy chỉnh vẫn có thể hữu ích ngay cả khi bạn không sử dụng placeholder số slide. Ngược lại, thay đổi khả năng hiển thị placeholder không xóa trường khỏi hộp văn bản không liên quan.

Các loại tiêu đề và chân trang định trước không tạo ra các placeholder tương ứng hoặc cung cấp nội dung của chúng. Đặc biệt, một slide PowerPoint thông thường không có placeholder tiêu đề; tiêu đề thuộc về trang ghi chú và tài liệu phát tay. Đừng giả định rằng một trường tiêu đề hoặc chân trang trong một hình dạng bất kỳ sẽ tự động nhận văn bản được cấu hình qua trình quản lý placeholder. Đối với quy trình đó, xem [Presentation Headers and Footers](/slides/vi/php-java/presentation-header-and-footer/).

## **Giới hạn của PPTX và PPT**

Kiểm tra cả loại trường và văn bản kết quả sau khi lưu và mở lại. Bảo tồn một định danh không chứng minh rằng một ứng dụng có thể tính toán hoặc hiển thị giá trị của nó.

| Định dạng | Hành vi và giới hạn của trường |
|---|---|
| PPTX | Lưu trữ định danh trường nội bộ cùng với văn bản trường. Trong các kiểm tra vòng quay, các loại định trước và định danh tùy chỉnh được sử dụng ở trên vẫn tồn tại sau khi lưu và mở lại. Kiểu tùy chỉnh không biết trước giữ lại văn bản dự phòng; nó không nhận được logic tính toán tự động. Ứng dụng khác có thể xử lý các định danh không hỗ trợ theo cách khác nhau. |
| PPT | Sử dụng đại diện trường legacy và có khả năng tương thích hạn chế hơn. Trong các kiểm tra vòng quay, các trường số slide và ngày/giờ định trước vẫn tồn tại sau khi lưu và mở lại. Một trường tùy chỉnh trong hộp văn bản slide thông thường mở lại với định danh nhưng văn bản là `*`; một trường tiêu đề trong cùng ngữ cảnh cũng cho ra `*`. Đừng dựa vào việc các trường tùy chỉnh hoặc ngữ cảnh trường không được hỗ trợ giữ lại văn bản hiển thị. |

Để có đầu ra cố định, di chuyển các trường không được hỗ trợ sang văn bản thông thường và gán rõ ràng giá trị mong muốn trước khi lưu. Điều này giữ lại văn bản đã chọn nhưng cố ý dừng cập nhật tự động. Hãy kiểm tra ứng dụng đích khi việc tính lại trường của nó là một phần trong quy trình làm việc của bạn.

## **Câu hỏi thường gặp**

**Làm sao tôi biết một số hoặc ngày hiển thị là một trường?**

Kiểm tra [Portion::getField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#getField). Giá trị không null cho biết đó là một trường; chỉ dựa vào văn bản hiển thị không đủ.

**Việc xóa trường có xóa văn bản hoặc định dạng không?**

Không. [removeField](https://reference.aspose.com/slides/vi/php-java/aspose.slides/portion/#removeField) chuyển phần hiện có thành văn bản thông thường. Gán giá trị cụ thể sau khi xóa nếu bạn cần một ngày cố định hoặc văn bản dự phòng.

**Một chuỗi nội bộ có thể định nghĩa định dạng ngày mới hoặc công thức không?**

Không. Nó chỉ xác định một loại trường. Một định danh không biết không cung cấp bộ đánh giá hay mẫu định dạng ngày PHP. Hãy sử dụng một loại định trước được hỗ trợ hoặc tự định dạng giá trị dưới dạng văn bản thông thường.

**Tại sao phải kiểm tra bản trình chiếu lại sau khi lưu?**

Các định danh trường, văn bản đã tính và định dạng là các yếu tố riêng biệt cần xác minh. Việc chuyển đổi định dạng có thể thay đổi kết quả hiển thị ngay khi định danh trường vẫn tồn tại.