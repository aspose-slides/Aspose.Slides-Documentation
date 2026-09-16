---
title: Quản lý siêu liên kết trong bản trình bày bằng JavaScript
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/nodejs-java/manage-hyperlinks/
keywords:
- thêm URL
- thêm siêu liên kết
- tạo siêu liên kết
- định dạng siêu liên kết
- xóa siêu liên kết
- cập nhật siêu liên kết
- siêu liên kết văn bản
- siêu liên kết slide
- siêu liên kết hình dạng
- siêu liên kết hình ảnh
- siêu liên kết video
- siêu liên kết có thể thay đổi
- PowerPoint
- OpenDocument
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bản trình bày PowerPoint và OpenDocument bằng Aspose.Slides cho Node.js qua Java, sử dụng các ví dụ JavaScript."
---
## **Giới thiệu**

Một siêu liên kết kết nối nội dung bản trình bày với một trang web hoặc một vị trí trong bản trình bày. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung media.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Node.js via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh, cập nhật thuộc tính và xoá chúng. Các ví dụ dưới đây cho thấy cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở mức bản trình bày, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}

Bạn cũng có thể chỉnh sửa bản trình bày bằng [trình chỉnh sửa Aspose PowerPoint trực tuyến miễn phí](https://products.aspose.app/slides/vi/editor).

{{% /alert %}} 

## **Thêm Siêu Liên Kết URL**

Bạn có thể gán một URL trang web cho văn bản, hình dạng hoặc khung media. Phần tử mà bạn gán siêu liên kết quyết định vùng có thể nhấp: một đoạn văn bản liên kết phần văn bản đã chọn, trong khi một hình dạng hoặc khung liên kết đối tượng slide.

### **Thêm Siêu Liên Kết URL vào Văn Bản**

Để liên kết văn bản đến một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/PortionFormat#setHyperlinkClick) của đoạn văn bản, như dưới đây. Chỉ đoạn văn bản đó trở nên có thể nhấp.

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

### **Thêm Siêu Liên Kết URL vào Hình Dạng và Khung Media**

Để làm cho một hình dạng hoặc khung có thể nhấp, gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#setHyperlinkClick) của nó. Siêu liên kết thuộc về đối tượng tự nó chứ không phải một đoạn văn bản bên trong.

Cách tiếp cận tương tự áp dụng cho khung ảnh, âm thanh và video: gán siêu liên kết cho khung và gọi [setTooltip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setTooltip) nếu cần.

Ví dụ sau làm cho một hình chữ nhật có thể nhấp:

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

## **Sử Dụng Siêu Liên Kết để Tạo Mục Lục**

Siêu liên kết nội bộ cho phép người đọc nhảy từ mục lục đến một slide cụ thể. Ví dụ sau sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#setInternalHyperlinkClick) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

## **Định Dạng Siêu Liên Kết**

### **Màu Sắc**

Phương thức [setColorSource](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setColorSource) của [Hyperlink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink) xác định liệu siêu liên kết có sử dụng màu siêu liên kết của bản trình bày hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkColorSource) và đặt màu nền cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Ví dụ sau thêm hai siêu liên kết văn bản vào cùng một slide. Siêu liên kết đầu tiên sử dụng màu nền đỏ, trong khi siêu liên kết thứ hai giữ màu siêu liên kết mặc định.

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
### **Âm Thanh**

Một siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng một âm thanh đang phát. Sử dụng các phương thức sau để cấu hình hành vi này:

- [Hyperlink.setSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setSound) chỉ định âm thanh liên kết với siêu liên kết.
- [Hyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setStopSoundOnClick) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó không.

#### **Thêm Âm Thanh Cho Siêu Liên Kết**

Ví dụ sau tải `sampleaudio.wav` và gắn nó vào một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển đến slide tiếp theo. Một hình dạng thứ hai trên slide đó sẽ dừng âm thanh trước khi nhấp mà không thực hiện hành động chuyển slide.

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

#### **Trích Xuất Âm Thanh Siêu Liên Kết**

Ví dụ sau mở bản trình bày đã tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getSound) và [getBinaryData](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Audio#getBinaryData).

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

### **Tooltip và Cài Đặt Tương Tác**

Bạn có thể gọi các phương thức [Hyperlink](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink) sau khi đã gán siêu liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setTooltip) đặt văn bản mà người xem có thể hiển thị như gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setTargetFrame) chỉ định khung mục tiêu trong một khung HTML cha, khi áp dụng.
- [setHistory](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setHistory) kiểm soát việc kích hoạt liên kết có thêm đích đến vào danh sách các siêu liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#setHighlightClick) kiểm soát việc siêu liên kết được đánh dấu khi nhấp.

## **Xoá Siêu Liên Kết Khỏi Bản Trình Bày**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) để thu thập các bộ chứa siêu liên kết, bao gồm các liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ sau xoá cả hai kiểu kích hoạt khỏi slide đầu tiên. Để xoá chỉ một kiểu, gọi chỉ [removeHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver); việc xoá hành động nhấp không xoá hành động rê chuột tương ứng.

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

Đối với việc xoá không điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks) xoá cả hai kiểu kích hoạt trong phạm vi đã chọn trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, hãy xem phần [Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Danh Mục Siêu Liên Kết Đầy Đủ**

Trước khi phân phối bản trình bày, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) trả về các bộ chứa siêu liên kết, không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getHyperlinkClick) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getHyperlinkMouseOver) trên mỗi bộ chứa. Chúng là độc lập: cùng một bộ chứa có thể hiển thị cả hai hành động, vì vậy một báo cáo đầy đủ cần tối đa hai hàng cho mỗi bộ chứa.

Chỉ quét các siêu liên kết ở mức hình dạng có thể bỏ qua các liên kết gắn vào các đoạn văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các bộ chứa đã trả về để bạn có thể cập nhật hoặc xoá chúng sau này.

### **Truy Vấn Phạm Vi Bản Trình Bày, Slide và Khung Văn Bản**

Lớp [HyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries) có sẵn qua [Presentation.getHyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation#getHyperlinkQueries), [BaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide#getHyperlinkQueries) và [TextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TextFrame#getHyperlinkQueries). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkClicks) trả về các bộ chứa có hành động nhấp.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getHyperlinkMouseOvers) trả về các bộ chứa có hành động rê chuột.
- [getAnyHyperlinks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#getAnyHyperlinks) trả về các bộ chứa có một hoặc cả hai hành động.

Ví dụ sau tạo `hyperlink-audit-input.pptx` với một liên kết nhấp ngoài, một liên kết rê chuột tập tin, điều hướng slide nội bộ, một liên kết rê chuột văn bản và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Ba truy vấn cùng hoạt động ở mọi phạm vi; số lượng mô tả các bộ chứa, không phải tổng hành động. Phạm vi khung văn bản không bao gồm các liên kết của chính hình dạng bao quanh.

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

Trong ví dụ này, các truy vấn bản trình bày và slide mỗi đều báo cáo ba bộ chứa nhấp, hai bộ chứa rê chuột và ba bộ chứa có bất kỳ hành động nào. Truy vấn khung văn bản báo cáo một bộ chứa trong mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [Hyperlink.getActionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getActionType) để giải thích hành động trước khi giải thích đích đến. Các giá trị của [HyperlinkActionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkActionType) bao phủ nhiều hơn chỉ điều hướng web:

| Giá Trị | Ý Nghĩa cho kiểm toán |
| --- | --- |
| `Hyperlink` | Siêu liên kết ngoài; kiểm tra URL và scheme của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc show hiện tại hoặc bắt đầu một show tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc bản trình bày khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát media. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận dạng được cần xem xét. |

Đọc các đích đến ngoài qua [getExternalUrl](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getExternalUrl) và các đích đến nội bộ cụ thể qua [getTargetSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getTargetSlide). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL rỗng không có nghĩa là bộ chứa không có hành động. Giữ nguyên giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getExternalUrlOriginal) khi nó khác URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Hyperlink#getTooltip) khi có.

### **Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết**

Ví dụ JavaScript sau đọc một bản trình bày hiện có (sử dụng tệp được tạo ở trên), ghi `hyperlink-audit.json`, áp dụng chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra lại cả hai kiểu kích hoạt. Nó thu thập các bộ chứa trước khi thay đổi và sử dụng so sánh tham chiếu để tránh xử lý cùng một bộ chứa hai lần. Các truy vấn bản trình bày bao phủ các slide thường; để có kiểm kê trên toàn bộ gói, nó còn truy vấn rõ ràng các master, layout, notes và các master notes và handout khi có.

Báo cáo ghi lại chỉ số slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/BaseSlide#getSlideId) khi có. [getSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getSlide) cung cấp slide sở hữu cho các bộ chứa được hỗ trợ. Master, layout và notes không có chỉ số slide bình thường và được xác định bằng phạm vi của chúng. Các bộ chứa hình dạng và các bộ chứa định dạng đoạn văn bản được gán nhãn riêng; các loại bộ chứa khác giữ tên kiểu thời gian chạy. Mỗi bộ chứa có một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết. Báo cáo lưu loại hành động dưới dạng các hằng số nguyên được định nghĩa bởi enum HyperlinkActionType.

Chính sách ứng dụng có tính hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích đến slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những từ chối này là quyết định chính sách, không phải là phán đoán an toàn của Aspose.Slides. HTTPS một mình không tạo nên sự tin cậy: hãy thêm danh sách trắng host và các kiểm tra khác cho ứng dụng của bạn. Cả URL ngoài gốc và URL đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo dõi liên kết hay thực thi hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Shape#getHyperlinkManager) của bộ chứa hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#setExternalHyperlinkClick), [removeHyperlinkClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkClick) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkManager#removeHyperlinkMouseOver). Ở đây, các liên kết nhấp ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp bị cấm khác và các hành động rê chuột bị cấm được xoá độc lập. Đặt `replaceExternalClicks` thành `false` để xoá toàn bộ vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem xét PDF bảo thủ: đánh dấu các hành động rê chuột và bất kỳ thứ gì không phải là liên kết ngoài hoặc nhảy slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý xem xét, không phải là bài kiểm tra khả năng hay bảo đảm các liên kết không được đánh dấu sẽ tồn tại sau khi xuất. Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết, tùy vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh](/slides/vi/nodejs-java/convert-powerpoint-to-png/) và [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/) raster không thể giữ lại siêu liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra này.

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

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết rê chuột tệp và macro nhấp được xoá, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra in ra không có hành động bị cấm. Một đầu vào chứa URL nhấp ngoài bị cấm cũng sẽ thực hiện nhánh thay thế. Một bộ chứa có nhấp được cho phép và rê chuột bị cấm sẽ giữ lại hành động nhấp.

Việc dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/HyperlinkQueries#removeAllHyperlinks), lệnh này xoá cả hai kiểu kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Việc xác minh ở đây chỉ kiểm tra các hành động siêu liên kết; nó không xoá các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác nhận một tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để liên kết tới một phần hoặc slide đầu tiên của phần đó?**

Các phần trong PowerPoint nhóm các slide lại, nhưng một siêu liên kết nội bộ hướng tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể gắn siêu liên kết vào các thành phần master slide để nó hoạt động trên tất cả các slide không?**

Có. Các thành phần master slide và layout hỗ trợ siêu liên kết. Các liên kết trên các thành phần này có sẵn trong chế độ chiếu slide trên các slide sử dụng master hoặc layout tương ứng.

**Siêu liên kết có được giữ lại khi xuất sang PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể giữ lại siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong phần [Báo Cáo, Làm Sạch và Xác Minh Siêu Liên Kết](#report-sanitize-and-verify-hyperlinks).