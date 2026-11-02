---
title: Quản lý Siêu liên kết Bản trình chiếu bằng JavaScript
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/nodejs-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xoá siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xoá siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java, sử dụng các ví dụ JavaScript."
---
## **Introduction**

Một siêu liên kết kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Node.js via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh của chúng, cập nhật thuộc tính và xóa chúng. Các ví dụ dưới đây minh họa cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở mức bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}} 

## **Add URL Hyperlinks**

Bạn có thể gán URL của một trang web cho văn bản, hình dạng hoặc khối phương tiện. Phần tử mà bạn gán siêu liên kết sẽ xác định khu vực có thể nhấp: một đoạn văn bản sẽ liên kết tới văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết tới đối tượng slide.

Đối với các bản trình chiếu chứa siêu liên kết tương đối, xem [Quản lý cơ sở siêu liên kết](/slides/vi/nodejs-java/presentation-properties/#manage-the-hyperlink-base) để đọc, thay đổi hoặc xóa cơ sở ở mức tài liệu.

### **Add URL Hyperlinks to Text**

Để liên kết văn bản tới một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) của đoạn văn bản, như được minh họa bên dưới. Chỉ phần văn bản đó sẽ có thể nhấp.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    const portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Add URL Hyperlinks to Shapes and Media Frames**

Để làm cho một hình dạng hoặc khung có thể nhấp, hãy gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#setHyperlinkClick) của nó. Siêu liên kết thuộc về đối tượng đó chứ không phải một đoạn văn bản bên trong.

Cùng cách tiếp cận này áp dụng cho khung hình ảnh, âm thanh và video: gán siêu liên kết cho khung và gọi [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) nếu cần.

Ví dụ sau tạo một hình chữ nhật có thể nhấp:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Use Hyperlinks to Create a Table of Contents**

Siêu liên kết nội bộ cho phép người đọc chuyển từ mục lục tới một slide cụ thể. Ví dụ dưới đây sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const tableOfContents = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.NoFill));
    tableOfContents.getTextFrame().getParagraphs().clear();

    const paragraph = new aspose.slides.Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLACK"));
    paragraph.setText("Title of slide 2 .......... ");

    const linkPortion = new aspose.slides.Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Format Hyperlinks**

### **Color**

Phương thức [setColorSource](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setColorSource) của [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) xác định việc siêu liên kết sử dụng màu siêu liên kết của bản trình chiếu hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkColorSource) và đặt màu nền cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng thiết lập này.

Ví dụ dưới đây thêm hai siêu liên kết văn bản vào cùng một slide. Siêu liên kết đầu tiên sử dụng màu nền văn bản đỏ, trong khi siêu liên kết thứ hai giữ màu siêu liên kết mặc định.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    const coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(aspose.slides.HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "RED"));

    const defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new aspose.slides.Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```
### **Sound**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [Hyperlink.setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setSound) chỉ định âm thanh liên kết với siêu liên kết.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Add a Hyperlink Sound**

Ví dụ dưới đây tải `sampleaudio.wav` và gán nó với một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển đến slide tiếp theo. Một hình dạng thứ hai trên slide đó sẽ dừng âm thanh trước khi được nhấp, mà không thực hiện hành động điều hướng nào.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const audioStream = java.newInstanceSync("java.io.FileInputStream", "sampleaudio.wav");
    let hyperlinkSound;
    try {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    } finally {
        audioStream.close();
    }

    const firstSlide = presentation.getSlides().get_Item(0);

    const playButton = firstSlide.getShapes().addAutoShape(aspose.slides.ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(aspose.slides.Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    const secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    const stopButton = secondSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(aspose.slides.Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

#### **Extract a Hyperlink Sound**

Ví dụ dưới đây mở bản trình chiếu đã tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getSound) và [getBinaryData](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Audio#getBinaryData).

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        const hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        const sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            const audioData = sound.getBinaryData();
            console.log("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            console.log("The first shape has no hyperlink sound.");
        }
    } else {
        console.log("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Tooltip and Interaction Settings**

Bạn có thể gọi các phương thức [Hyperlink](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink) sau khi đã gán siêu liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTooltip) đặt văn bản mà người xem có thể hiển thị như một gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) chỉ định khung đích trong một khung HTML cha, nếu có.
- [setHistory](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHistory) kiểm soát việc kích hoạt liên kết có thêm đích của nó vào danh sách các siêu liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) kiểm soát việc siêu liên kết được làm nổi bật khi nhấp.

## **Remove Hyperlinks from Presentations**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) để thu thập các container siêu liên kết, bao gồm cả các liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ dưới đây loại bỏ cả hai kiểu kích hoạt khỏi slide đầu tiên. Để chỉ xóa một kiểu, gọi chỉ [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); việc xóa hành động click không xóa hành động di chuột qua.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        const found = presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks();
        const containers = [];
        for (let index = 0; index < found.size(); index++) {
            containers.push(found.get_Item(index));
        }
        for (const container of containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", aspose.slides.SaveFormat.Pptx);
    } else {
        console.log("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Đối với việc xóa không điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) loại bỏ cả hai kiểu kích hoạt trong phạm vi đã chọn bằng một lần gọi. Đối với việc làm sạch có chọn lọc và bao phủ các master, layout và ghi chú, xem [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).

## **Build a Complete Hyperlink Inventory**

Trước khi phân phối một bản trình chiếu, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) trả về các container siêu liên kết, không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkClick) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) trên mỗi container. Chúng độc lập: cùng một container có thể cung cấp cả hai hành động, vì vậy báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Việc chỉ quét các siêu liên kết ở mức hình dạng có thể bỏ lỡ các liên kết được đính kèm vào đoạn văn bản. Thay vào đó, truy vấn phạm vi phù hợp và giữ lại các container được trả về để sau này bạn có thể cập nhật hoặc xóa các hành động của chúng.

### **Query Presentation, Slide, and Text-Frame Scopes**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries) có sẵn thông qua [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries), và [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) trả về các container có hành động click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) trả về các container có hành động di chuột qua.
- [getAnyHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) trả về các container có một hoặc cả hai hành động.

Ví dụ dưới đây tạo `hyperlink-audit-input.pptx` với một liên kết click bên ngoài, một liên kết di chuột qua tệp, điều hướng slide nội bộ, một liên kết di chuột qua văn bản, và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Cả ba truy vấn đều hoạt động ở mọi phạm vi; số lượng mô tả các container, không phải tổng số hành động. Phạm vi khung văn bản loại trừ các liên kết của hình dạng bao quanh.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function printQueryCounts(scope, queries) {
const clickCount = queries.getHyperlinkClicks().size();
const mouseOverCount = queries.getHyperlinkMouseOvers().size();
const anyCount = queries.getAnyHyperlinks().size();
console.log(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    const portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    const macroButton = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    printQueryCounts("Presentation", presentation.getHyperlinkQueries());
    printQueryCounts("Slide 1", slide.getHyperlinkQueries());
    printQueryCounts("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với ví dụ này, các truy vấn ở mức bản trình chiếu và slide mỗi đều báo cáo ba container click, hai container di chuột qua và ba container có một trong hai hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Classify Actions and Destinations**

Sử dụng [Hyperlink.getActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getActionType) để giải thích một hành động trước khi giải thích đích của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkActionType) bao gồm nhiều hơn chỉ điều hướng web:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Siêu liên kết ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng slide trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc trình chiếu hiện tại hoặc bắt đầu một trình chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở một tệp hoặc một bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận diện được cần xem xét. |

Đọc các đích ngoài từ [getExternalUrl](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) và các đích nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Các hành động nội bộ và lệnh tích hợp có thể không có URL ngoài; một URL trống không có nghĩa là container không có hành động. Giữ nguyên giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) khi nó khác với URL đã chuẩn hóa, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Hyperlink#getTooltip) khi có.

### **Report, Sanitize, and Verify Hyperlinks**

Ví dụ JavaScript dưới đây đọc một bản trình chiếu hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng một chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại nó để kiểm tra lại cả hai kiểu kích hoạt. Nó thu thập các container trước khi thay đổi chúng và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bản trình chiếu bao phủ các slide thường; để có kiểm kê toàn gói, nó cũng truy vấn rõ ràng các master, layout, ghi chú, và các master ghi chú và handout khi có.

Báo cáo ghi lại chỉ số slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/nodejs-java/aspose.slides/BaseSlide#getSlideId) nếu có. [getSlide](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getSlide) cung cấp slide sở hữu cho các container được hỗ trợ. Các master, layout và ghi chú không có chỉ số slide thông thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng đoạn văn bản được gắn nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy của chúng. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết. Báo cáo lưu các loại hành động dưới dạng các hằng số nguyên được định nghĩa bởi liệt kê HyperlinkActionType.

Chính sách ứng dụng có mục đích này giới hạn cho phép chỉ các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các giao thức URL khác. Những từ chối này là quyết định chính sách, không phải là phán quyết an toàn của Aspose.Slides. HTTPS một mình không tạo lòng tin: hãy thêm danh sách cho phép máy chủ và các kiểm tra khác cho ứng dụng của bạn. Cả URL ngoài gốc và đã chuẩn hóa đều được kiểm tra. Ví dụ kiểm tra siêu dữ liệu mà không theo dõi liên kết hoặc chạy hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/nodejs-java/aspose.slides/Shape#getHyperlinkManager) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick), và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Ở đây, các liên kết click ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các click bị cấm khác và các hành động di chuột qua bị cấm được xóa riêng rẽ. Đặt `replaceExternalClicks` thành `false` để xóa tất cả các vi phạm chính sách. Chọn một trang thay thế thuộc sở hữu ứng dụng trước khi triển khai.

Cờ xuất khẩu của báo cáo sử dụng chính sách kiểm tra PDF thận trọng: đánh dấu các hành động di chuột qua và bất kỳ thứ gì không phải là liên kết ngoài hoặc chuyển slide cụ thể là có thể không được hỗ trợ. Đây là gợi ý kiểm tra, không phải là bài kiểm tra khả năng hoặc đảm bảo các liên kết không được đánh dấu sẽ tồn tại sau xuất khẩu. Các xuất khẩu PDF và HTML được hỗ trợ [PDF](/slides/vi/nodejs-java/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/nodejs-java/convert-powerpoint-to-html/) có thể giữ lại siêu liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/) và [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) dạng raster không thể giữ lại siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");
const fs = require("fs");

function slideIndex(presentation, slide) {
    if (slide == null) return null;
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        if (presentation.getSlides().get_Item(index).equals(slide)) return index + 1;
    }
    return null;
}

function isHttps(value) {
    if (value == null || value.length === 0) return false;
    try {
        const uri = java.newInstanceSync("java.net.URI", value);
        const scheme = uri.getScheme();
        return uri.isAbsolute() && scheme != null && scheme.toLowerCase() === "https" && uri.getHost() != null;
    } catch (exception) {
        return false;
    }
}

function policyViolation(link) {
    if (link == null) return null;
    if (link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide) {
        return link.getTargetSlide() == null ? "Missing target slide" : null;
    }
    if (link.getActionType() !== aspose.slides.HyperlinkActionType.Hyperlink) return "Action is not allowed";
    if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
    const original = link.getExternalUrlOriginal();
    if (original != null && original.length > 0 && !isHttps(original)) return "Original URL is not absolute HTTPS";
    return null;
}

function collectContainers(presentation) {
    const found = [];
    function addQueries(queries) {
        const containers = queries.getAnyHyperlinks();
        for (let index = 0; index < containers.size(); index++) {
            found.push(containers.get_Item(index));
        }
    }
    function addScope(slide) {
        if (slide != null) addQueries(slide.getHyperlinkQueries());
    }
    addQueries(presentation.getHyperlinkQueries());
    for (let index = 0; index < presentation.getMasters().size(); index++) {
        addScope(presentation.getMasters().get_Item(index));
    }
    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        addScope(presentation.getLayoutSlides().get_Item(index));
    }
    for (let index = 0; index < presentation.getSlides().size(); index++) {
        addScope(presentation.getSlides().get_Item(index).getNotesSlideManager().getNotesSlide());
    }
    addScope(presentation.getMasterNotesSlideManager().getMasterNotesSlide());
    addScope(presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
    const seen = java.newInstanceSync("java.util.IdentityHashMap");
    const unique = [];
    for (const container of found) {
        if (!seen.containsKey(container)) {
            seen.put(container, true);
            unique.push(container);
        }
    }
    return unique;
}

function addRow(rows, presentation, link, activation, container, containerId) {
    if (link == null) return;
    const ownerSlide = java.instanceOf(container, "com.aspose.slides.ISlideComponent") ? container.getSlide() : null;
    const targetSlide = link.getTargetSlide();
    const violation = policyViolation(link);
    const ownerType = java.instanceOf(container, "com.aspose.slides.IShape") ? "Shape" : java.instanceOf(container, "com.aspose.slides.IPortionFormat") ? "Text portion" : container.getClass().getSimpleName();
    const ordinaryAction = link.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink || link.getActionType() === aspose.slides.HyperlinkActionType.JumpSpecificSlide;
    rows.push({
        ContainerId: containerId,
        SlideIndex: slideIndex(presentation, ownerSlide),
        SlideId: ownerSlide == null ? null : ownerSlide.getSlideId(),
        Scope: ownerSlide == null ? null : ownerSlide.getClass().getSimpleName(),
        OwnerType: ownerType,
        Activation: activation,
        ActionType: link.getActionType(),
        ExternalUrl: link.getExternalUrl(),
        TargetSlideIndex: slideIndex(presentation, targetSlide),
        TargetSlideId: targetSlide == null ? null : targetSlide.getSlideId(),
        Tooltip: link.getTooltip(),
        OriginalExternalUrl: link.getExternalUrlOriginal() === link.getExternalUrl() ? null : link.getExternalUrlOriginal(),
        PotentiallyUnsafe: violation != null,
        PolicyViolation: violation,
        TargetExport: "PDF",
        PotentiallyUnsupportedByExport: activation === "mouse-over" || !ordinaryAction
    });
}

const replaceExternalClicks = true;
const replacementUrl = "https://example.com/blocked-link";
const presentation = new aspose.slides.Presentation("hyperlink-audit-input.pptx");
try {
    const containers = collectContainers(presentation);
    const rows = [];
    for (let index = 0; index < containers.length; index++) {
        const container = containers[index];
        addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    const json = JSON.stringify(rows, null, 2);
    fs.writeFileSync("hyperlink-audit.json", json, "utf8");

    for (const container of containers) {
        const click = container.getHyperlinkClick();
        if (policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() === aspose.slides.HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", aspose.slides.SaveFormat.Pptx);

    const reopened = new aspose.slides.Presentation("hyperlink-sanitized.pptx");
    try {
        const remainingContainers = collectContainers(reopened);
        let violations = 0;
        for (const container of remainingContainers) {
            if (policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        console.log("Audit rows: " + rows.length + "; prohibited actions after reopening: " + violations);
        if (violations !== 0) {
            console.log("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Với đầu vào đã tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột qua tệp và click macro đã bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Việc xác minh hiển thị không có hành động bị cấm. Một đầu vào chứa URL click ngoài bị cấm cũng thực hiện nhánh thay thế. Một container có click được cho phép và di chuột qua bị cấm sẽ giữ hành động click của nó.

Quá trình làm sạch có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), vốn xóa cả hai kiểu kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Việc xác minh ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực tệp PDF hoặc HTML đã xuất.

## **FAQ**

**Làm thế nào để tôi liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide lại với nhau, nhưng một siêu liên kết nội bộ lại nhắm tới một slide riêng lẻ. Để tạo navigation tới một phần, hãy liên kết tới slide đầu tiên của phần đó.

**Tôi có thể gắn siêu liên kết vào các yếu tố master slide để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố master slide và layout hỗ trợ siêu liên kết. Các liên kết trên những yếu tố này sẽ khả dụng trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Siêu liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; hình ảnh raster và video thì không. Xem các lưu ý xuất khẩu trong [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).