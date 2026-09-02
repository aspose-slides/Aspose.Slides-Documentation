---
title: Tự động hoá việc Địa phương hoá Bản trình chiếu trong JavaScript
linktitle: Địa phương hoá Bản trình chiếu
type: docs
weight: 100
url: /vi/nodejs-java/presentation-localization/
keywords:
- thay đổi ngôn ngữ
- kiểm tra chính tả
- tắt kiểm tra chính tả
- ngôn ngữ kiểm tra
- định danh ngôn ngữ
- văn bản đa ngôn ngữ
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Đặt ngôn ngữ kiểm tra cho văn bản bản trình chiếu PowerPoint và OpenDocument trong JavaScript bằng Aspose.Slides, bao gồm các giá trị mặc định và đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java cho phép bạn cấu hình siêu dữ liệu kiểm tra chính tả cho các phần văn bản riêng lẻ. Sử dụng [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) để xác định ngôn ngữ kiểm tra, [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) để cho phép hoặc ngăn chặn kiểm tra chính tả, và [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) để kiểm soát trạng thái “không kiểm tra” tổng thể. Vì các cài đặt này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), xây dựng các đoạn văn đa ngôn ngữ, lựa chọn giữa `SpellCheck` và `ProofDisabled`, và bảo tồn các cài đặt mong muốn khi sử dụng [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--). Những thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, không thực hiện kiểm tra chính tả dựa trên từ điển, hoặc trả về các từ sai chính tả.

## **Đặt Ngôn Ngữ Kiểm Tra cho Văn Bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/), truy cập phần văn bản cần thiết qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getPortionFormat--), và gán định danh ngôn ngữ cho nó. Ví dụ sau tạo một hình, đặt tiếng Anh Anh làm ngôn ngữ kiểm tra, và lưu kết quả bằng [Presentation.save](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-):

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Ngôn Ngữ Mặc Định cho Văn Bản Mới**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides sẽ gán cho văn bản mới tạo. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ xác định.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sử Dụng Nhiều Ngôn Ngữ trong Một Đoạn Văn**

Một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/) chứa một tập hợp các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `LanguageId` của nó một cách độc lập.

Ví dụ này tạo một đoạn văn có các phần tiếng Anh và tiếng Pháp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bật hoặc Tắt Kiểm Tra Chính Tả cho Các Phần Riêng Lẻ**

[PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [BasePortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/). Truy cập định dạng của một phần qua [Portion.getPortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/portion/#getPortionFormat--) và sử dụng [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) để kiểm soát việc một ứng dụng trình chiếu có thể kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `false`: `true` cho phép kiểm tra chính tả, trong khi `false` ngăn chặn.

Cài đặt này áp dụng cho các phần văn bản riêng lẻ. Các phần khác nhau trong cùng một đoạn văn do đó có thể sử dụng các giá trị khác nhau. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) và `setSpellCheck` phục vụ các mục đích bổ trợ: `setLanguageId` xác định ngôn ngữ kiểm tra, trong khi `setSpellCheck` quyết định liệu có cho phép kiểm tra chính tả cho phần đó hay không.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) cũng kiểm soát việc kiểm tra, nhưng nó đại diện cho trạng thái “không kiểm tra” rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/nullablebool/). Sử dụng `setSpellCheck` khi bạn cần một công tắc Boolean trực tiếp cho kiểm tra chính tả. Sử dụng `setProofDisabled` khi bạn cần bảo lưu hoặc kiểm soát rõ ràng siêu dữ liệu “không kiểm tra” của bản trình chiếu, bao gồm trạng thái `NotDefined`. Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng nhất quán; không kết hợp `setSpellCheck(true)` với `setProofDisabled(NullableBool.True)`.

Những thuộc tính này cấu hình siêu dữ liệu kiểm tra được PowerPoint và các ứng dụng trình chiếu khác sử dụng. Aspose.Slides không dùng chúng để thực hiện kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai.

Ví dụ đầy đủ dưới đây tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai phần trong cùng một đoạn văn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) kết hợp các phần liền kề có cùng định dạng. Một sự khác biệt chỉ ở `SpellCheck` không giữ các phần này riêng biệt; sau khi được ghép, phần kết quả giữ giá trị `SpellCheck` của phần đầu tiên. Nếu các phần cần có cài đặt kiểm tra chính tả khác nhau, hãy gọi `joinPortionsWithSameFormatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới phần sau khi ghép và áp dụng lại cài đặt. Các phần có giá trị `LanguageId` khác nhau vẫn được giữ riêng vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **Câu Hỏi Thường Gặp**

**ID ngôn ngữ có dịch văn bản không?**

Không. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) lưu trữ siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Hãy dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ phù hợp cho mỗi phần đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, gạch đầu dòng hay ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dùng cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [phông chữ](/slides/vi/nodejs-java/powerpoint-fonts/) có sẵn, hệ thống viết và thiết lập khung văn bản. Để đảm bảo hiển thị đúng, cung cấp các phông chữ cần thiết, cấu hình [thay thế phông chữ](/slides/vi/nodejs-java/font-substitution/), hoặc [nhúng phông chữ](/slides/vi/nodejs-java/embedded-font/) trong bản trình chiếu.

**Một đoạn văn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng, như đã minh họa trong ví dụ đoạn văn đa ngôn ngữ.

**Nên dùng `setDefaultTextLanguage` hay `setLanguageId`?**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) khi bạn muốn có ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) khi một phần cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn văn chứa nhiều ngôn ngữ.