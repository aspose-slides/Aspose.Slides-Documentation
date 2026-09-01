---
title: "Tự động hoá Địa phương hoá Bản trình chiếu trong Java"
linktitle: "Địa phương hoá Bản trình chiếu"
type: docs
weight: 100
url: /vi/java/presentation-localization/
keywords:
- "thay đổi ngôn ngữ"
- "kiểm tra chính tả"
- "vô hiệu hoá kiểm tra chính tả"
- "ngôn ngữ kiểm tra"
- "id ngôn ngữ"
- "văn bản đa ngôn ngữ"
- "PowerPoint"
- "bản trình chiếu"
- "Java"
- "Aspose.Slides"
description: "Đặt ngôn ngữ kiểm tra cho văn bản bản trình chiếu PowerPoint và OpenDocument trong Java bằng Aspose.Slides, bao gồm các mặc định và các đoạn văn đa ngôn ngữ."
---
## **Tổng quan**

Aspose.Slides for Java cho phép bạn cấu hình siêu dữ liệu kiểm tra chứng thực cho từng phần văn bản. Sử dụng [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) để xác định ngôn ngữ kiểm tra, [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) để cho phép hoặc vô hiệu hoá kiểm tra chính tả, và [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) để kiểm soát trạng thái không kiểm tra rộng hơn. Vì các thiết lập này được áp dụng ở mức phần, một đoạn văn có thể chứa nhiều ngôn ngữ và các quy tắc kiểm tra khác nhau.

Bài viết này giải thích cách gán ngôn ngữ cho văn bản cụ thể, đặt ngôn ngữ mặc định cho văn bản mới bằng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-), xây dựng các đoạn đa ngôn ngữ, chọn giữa `SpellCheck` và `ProofDisabled`, và bảo tồn các thiết lập mong muốn khi sử dụng [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--). Các thuộc tính này lưu trữ siêu dữ liệu cho các ứng dụng trình chiếu; chúng không dịch văn bản, thực hiện kiểm tra chính tả dựa trên từ điển, hoặc trả về các từ sai chính tả.

## **Đặt Ngôn ngữ Kiểm tra Đánh vần cho Văn bản**

Tạo hoặc tải một [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/), truy cập phần văn bản cần thiết qua [IPortion.getPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getPortionFormat--), và gán định danh ngôn ngữ cho nó. Ví dụ dưới đây tạo một hình, đặt tiếng Anh Anh làm ngôn ngữ kiểm tra, và lưu kết quả bằng [Presentation.save](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#save-java.lang.String-int-):

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Ngôn ngữ Mặc định cho Văn bản Mới**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) để chỉ định ngôn ngữ kiểm tra mà Aspose.Slides sẽ gán cho văn bản mới tạo. Cài đặt này hữu ích khi hầu hết hoặc toàn bộ văn bản mới trong bản trình chiếu sử dụng cùng một ngôn ngữ. Nó không thay đổi siêu dữ liệu ngôn ngữ của văn bản đã có ngôn ngữ xác định.

Ví dụ sau tạo một bản trình chiếu mà văn bản mới sử dụng quy tắc kiểm tra tiếng Đức:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sử dụng Nhiều Ngôn ngữ trong Một Đoạn Văn bản**

Một [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/) chứa một tập hợp các phần văn bản. Tạo một [Portion](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portion/) riêng cho mỗi ngôn ngữ và đặt `LanguageId` của nó một cách độc lập.

Ví dụ này tạo một đoạn với các phần tiếng Anh và tiếng Pháp:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Bật hoặc Vô hiệu Kiểm tra Chính tả cho Các Phần riêng lẻ**

[IPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportionformat/) kế thừa các thuộc tính văn bản chung được định nghĩa bởi [IBasePortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/). Truy cập định dạng của một phần qua [IPortion.getPortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iportion/#getPortionFormat--) và sử dụng [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) để kiểm soát việc ứng dụng trình chiếu có thể kiểm tra chính tả cho phần đó hay không. Giá trị mặc định là `false`: `true` cho phép kiểm tra chính tả, trong khi `false` vô hiệu hoá.

Cài đặt này áp dụng cho các phần văn bản riêng lẻ. Các phần khác nhau trong cùng một đoạn vì vậy có thể sử dụng các giá trị khác nhau. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) và `setSpellCheck` có mục đích bổ sung nhau: `setLanguageId` xác định ngôn ngữ kiểm tra, còn `setSpellCheck` quyết định có cho phép kiểm tra chính tả cho phần đó hay không.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) cũng điều khiển việc kiểm tra, nhưng nó đại diện cho trạng thái “không kiểm tra” rộng hơn dưới dạng một [NullableBool](https://reference.aspose.com/slides/vi/java/com.aspose.slides/nullablebool/). Sử dụng `setSpellCheck` khi bạn cần một công tắc Boolean trực tiếp chỉ cho kiểm tra chính tả. Sử dụng `setProofDisabled` khi bạn cần bảo tồn hoặc kiểm soát rõ ràng siêu dữ liệu không kiểm tra của bản trình chiếu, bao gồm trạng thái `NotDefined`. Nếu bạn đặt cả hai thuộc tính, hãy giữ giá trị của chúng đồng nhất; không kết hợp `setSpellCheck(true)` với `setProofDisabled(NullableBool.True)`.

Các thuộc tính này cấu hình siêu dữ liệu kiểm tra được PowerPoint và các ứng dụng trình chiếu khác sử dụng. Aspose.Slides không dùng chúng để chạy kiểm tra chính tả dựa trên từ điển hoặc trả về danh sách các từ sai.

Ví dụ hoàn chỉnh dưới đây tạo một bản trình chiếu đầu vào, tải nó, gán các cài đặt kiểm tra chính tả và ngôn ngữ kiểm tra khác nhau cho hai phần trong cùng một đoạn, lưu kết quả, mở lại và xác minh các giá trị đã lưu:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) kết hợp các phần liền kề có cùng định dạng. Khi chỉ có sự khác nhau ở `SpellCheck` thì các phần vẫn không tách biệt; sau khi được ghép, phần kết quả giữ giá trị `SpellCheck` của phần đầu tiên. Nếu các phần cần các cài đặt kiểm tra khác nhau, hãy gọi `joinPortionsWithSameFormatting` trước khi gán các cài đặt đó, hoặc kiểm tra ranh giới của phần sau khi ghép và áp dụng lại các cài đặt. Các phần có giá trị `LanguageId` khác nhau vẫn được giữ riêng biệt vì định dạng ngôn ngữ kiểm tra của chúng khác nhau.

## **Câu hỏi thường gặp**

**ID ngôn ngữ có dịch văn bản không?**

Không. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) lưu trữ siêu dữ liệu kiểm tra cho chính tả và ngữ pháp; nó không thay đổi nội dung văn bản. Hãy dịch văn bản riêng biệt, sau đó đặt định danh ngôn ngữ thích hợp cho mỗi phần đã dịch.

**Ngôn ngữ kiểm tra có kiểm soát phông chữ, gạch nối hoặc ngắt dòng không?**

Không. Định danh ngôn ngữ chỉ dành cho việc kiểm tra. Việc hiển thị và bố cục văn bản chủ yếu phụ thuộc vào [fonts](/slides/vi/java/powerpoint-fonts/), hệ thống viết, và cài đặt khung văn bản. Để đảm bảo hiển thị đáng tin cậy, cung cấp các phông chữ cần thiết, cấu hình [font substitution](/slides/vi/java/font-substitution/), hoặc [embed fonts](/slides/vi/java/embedded-font/) trong bản trình chiếu.

**Một đoạn văn có thể sử dụng nhiều ngôn ngữ kiểm tra không?**

Có. Gán mỗi ngôn ngữ cho một phần riêng, như trong ví dụ đoạn văn đa ngôn ngữ.

**Tôi nên sử dụng `setDefaultTextLanguage` hay `setLanguageId`?**

Sử dụng [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/vi/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) khi bạn muốn một ngôn ngữ mặc định cho văn bản mới tạo. Sử dụng [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) khi một phần cụ thể cần một ngôn ngữ kiểm tra rõ ràng hoặc khi một đoạn chứa nhiều ngôn ngữ.