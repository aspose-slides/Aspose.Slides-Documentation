---
title: Quản lý hyperlink trong bài thuyết trình Java
linktitle: Quản lý hyperlink
type: docs
weight: 20
url: /vi/java/manage-hyperlinks/
keywords:
- thêm URL
- thêm hyperlink
- tạo hyperlink
- định dạng hyperlink
- xóa hyperlink
- cập nhật hyperlink
- hyperlink văn bản
- hyperlink slide
- hyperlink hình dạng
- hyperlink hình ảnh
- hyperlink video
- hyperlink có thể thay đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa hyperlink trong các bài thuyết trình PowerPoint và OpenDocument với Aspose.Slides cho Java, sử dụng các ví dụ Java."
---
## **Giới thiệu**

Liên kết siêu văn bản (hyperlink) kết nối nội dung bài thuyết trình với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, hyperlink thường thực hiện hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung đa phương tiện.
* Điều hướng đến một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh, cập nhật thuộc tính và xóa chúng. Các ví dụ bên dưới cho thấy cách làm việc với hyperlink trên các yếu tố riêng lẻ và cách truy cập hyperlink ở mức bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Lưu ý" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu bằng [trình chỉnh sửa Aspose PowerPoint trực tuyến miễn phí](https://products.aspose.app/slides/vi/editor).
{{% /alert %}} 

## **Thêm Hyperlink URL**

Bạn có thể gán một URL trang web cho văn bản, hình dạng hoặc khung đa phương tiện. Yếu tố mà bạn gán hyperlink quyết định khu vực có thể nhấp: một phần văn bản liên kết chính xác văn bản đã chọn, trong khi một hình dạng hoặc khung liên kết đối tượng slide.

### **Thêm Hyperlink URL vào Văn bản**

Để liên kết văn bản với một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/vi/java/com.aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) của phần văn bản, như dưới đây. Chỉ phần văn bản đó sẽ trở nên có thể nhấp.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape textShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50, false);
    textShape.addTextFrame("Aspose: File Format APIs");
    IPortionFormat portionFormat = textShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    portionFormat.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");
    portionFormat.setFontHeight(32);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Thêm Hyperlink URL vào Hình dạng và Khung Đa phương tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) của nó. Hyperlink thuộc về đối tượng đó chứ không phải một phần văn bản bên trong.

Cách tiếp cận tương tự áp dụng cho khung ảnh, âm thanh và video: gán hyperlink cho khung và gọi [setTooltip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) nếu cần.

Ví dụ dưới đây tạo một hình chữ nhật có thể nhấp:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    IAutoShape shape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 600, 50);

    shape.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    shape.getHyperlinkClick().setTooltip("Explore Aspose file format APIs");

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Sử dụng Hyperlink để Tạo Mục Lục**

Hyperlink nội bộ cho phép người đọc nhảy từ mục lục tới một slide cụ thể. Ví dụ sau sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape tableOfContents = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 300, 100);
    tableOfContents.getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getLineFormat().getFillFormat().setFillType(FillType.NoFill);
    tableOfContents.getTextFrame().getParagraphs().clear();

    Paragraph paragraph = new Paragraph();
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().setFillType(FillType.Solid);
    paragraph.getParagraphFormat().getDefaultPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK);
    paragraph.setText("Title of slide 2 .......... ");

    Portion linkPortion = new Portion();
    linkPortion.setText("Page 2");
    linkPortion.getPortionFormat().getHyperlinkManager().setInternalHyperlinkClick(secondSlide);

    paragraph.getPortions().add(linkPortion);
    tableOfContents.getTextFrame().getParagraphs().add(paragraph);

    presentation.save("link_to_slide.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Định dạng Hyperlink**

### **Màu**

Phương thức [setColorSource](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setColorSource-int-) của [IHyperlink](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/) quyết định liệu hyperlink có sử dụng màu hyperlink của bản trình chiếu hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/vi/java/com.aspose.slides/hyperlinkcolorsource/) và đặt màu nền cho phần đó. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Ví dụ sau thêm hai hyperlink văn bản vào cùng một slide. Đầu tiên sử dụng màu nền đỏ, trong khi thứ hai giữ màu hyperlink mặc định.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    IAutoShape coloredShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 450, 50, false);
    coloredShape.addTextFrame("This hyperlink uses a custom color.");
    IPortionFormat coloredPortionFormat = coloredShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    coloredPortionFormat.setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));
    coloredPortionFormat.getHyperlinkClick().setColorSource(HyperlinkColorSource.PortionFormat);
    coloredPortionFormat.getFillFormat().setFillType(FillType.Solid);
    coloredPortionFormat.getFillFormat().getSolidFillColor().setColor(Color.RED);

    IAutoShape defaultShape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 450, 50, false);
    defaultShape.addTextFrame("This hyperlink uses the default color.");
    defaultShape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat().setHyperlinkClick(new Hyperlink("https://www.aspose.com/"));

    presentation.save("presentation-out-hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Âm thanh**

Hyperlink có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [IHyperlink.setSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) chỉ định âm thanh liên quan tới hyperlink.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) kiểm soát việc kích hoạt hyperlink có dừng âm thanh trước đó hay không.

#### **Thêm Âm thanh cho Hyperlink**

Ví dụ dưới đây tải `sampleaudio.wav` và liên kết nó với một nút trên slide đầu tiên. Nhấp vào nút sẽ phát âm thanh và chuyển tới slide tiếp theo. Một hình dạng thứ hai trên cùng slide sẽ dừng âm thanh trước đó khi nhấp, mà không thực hiện hành động chuyển slide.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    byte[] audioData = Files.readAllBytes(Paths.get("sampleaudio.wav"));
    IAudio hyperlinkSound = presentation.getAudios().addAudio(audioData);

    ISlide firstSlide = presentation.getSlides().get_Item(0);

    IAutoShape playButton = firstSlide.getShapes().addAutoShape(ShapeType.SoundButton, 100, 100, 100, 50);
    playButton.setHyperlinkClick(Hyperlink.getNextSlide());

    if (!playButton.getHyperlinkClick().getStopSoundOnClick() && playButton.getHyperlinkClick().getSound() == null)
    {
        playButton.getHyperlinkClick().setSound(hyperlinkSound);
    }

    ISlide secondSlide = presentation.getSlides().addEmptySlide(firstSlide.getLayoutSlide());

    IAutoShape stopButton = secondSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 100, 50);
    stopButton.setHyperlinkClick(Hyperlink.getNoAction());

    stopButton.getHyperlinkClick().setStopSoundOnClick(true);

    presentation.save("hyperlink-sound.pptx", SaveFormat.Pptx);
} catch (IOException exception) {
    System.out.println("Unable to read the audio file: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

#### **Trích xuất Âm thanh Hyperlink**

Ví dụ dưới đây mở bản trình chiếu đã tạo ở trên và đọc âm thanh hyperlink của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getSound--) và [getBinaryData](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudio/#getBinaryData--).

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("hyperlink-sound.pptx");
try {
    if (presentation.getSlides().size() > 0 && presentation.getSlides().get_Item(0).getShapes().size() > 0) {
        IHyperlink hyperlink = presentation.getSlides().get_Item(0).getShapes().get_Item(0).getHyperlinkClick();
        IAudio sound = hyperlink == null ? null : hyperlink.getSound();
        if (sound != null) {
            byte[] audioData = sound.getBinaryData();
            System.out.println("Extracted " + audioData.length + " bytes of hyperlink audio.");
        } else {
            System.out.println("The first shape has no hyperlink sound.");
        }
    } else {
        System.out.println("The presentation has no first slide or shape to inspect.");
    }
} finally {
    presentation.dispose();
}
```

### **Cài đặt Tooltip và Tương tác**

Bạn có thể gọi các phương thức [IHyperlink](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/) sau khi gán hyperlink cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) thiết lập văn bản mà người xem có thể hiển thị như gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) chỉ định khung mục tiêu trong một frameset HTML cha, nếu áp dụng.
- [setHistory](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setHistory-boolean-) kiểm soát việc kích hoạt liên kết có thêm đích đến của nó vào danh sách các hyperlink đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) kiểm soát việc hyperlink có được làm nổi bật khi được nhấp hay không.

## **Xóa Hyperlink khỏi Bản Trình Chiếu**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) để thu thập các container hyperlink, bao gồm các liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ dưới đây xóa cả hai loại kích hoạt khỏi slide đầu tiên. Để xóa chỉ một loại, chỉ gọi [removeHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); xóa hành động click không xóa hành động mouse‑over tương ứng.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("pres.pptx");
try {
    if (presentation.getSlides().size() > 0) {
        List<IHyperlinkContainer> containers = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getSlides().get_Item(0).getHyperlinkQueries().getAnyHyperlinks()) {
            containers.add(container);
        }
        for (IHyperlinkContainer container : containers) {
            container.getHyperlinkManager().removeHyperlinkClick();
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
        presentation.save("pres-removed-hyperlinks.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The presentation has no slides to process.");
    }
} finally {
    presentation.dispose();
}
```

Đối với việc xóa không điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) xóa cả hai loại kích hoạt trong phạm vi đã chọn bằng một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).

## **Xây dựng Kiểm kê Hyperlink Đầy đủ**

Trước khi phân phối bản trình chiếu, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) trên mỗi container. Chúng độc lập: cùng một container có thể hiển thị cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai dòng cho mỗi container.

Quét chỉ các hyperlink ở mức hình dạng có thể bỏ qua các liên kết gắn vào phần văn bản. Thay vào đó, truy vấn phạm vi thích hợp và giữ lại các container đã trả về để bạn có thể cập nhật hoặc xóa hành động sau này.

### **Truy vấn phạm vi Bản Trình Chiếu, Slide và Khung Văn bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/) có sẵn qua [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), và [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextframe/#getHyperlinkQueries--). Mỗi phạm vi hỗ trợ cùng các truy vấn:

- [getHyperlinkClicks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) trả về các container có hành động click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) trả về các container có hành động mouse‑over.
- [getAnyHyperlinks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các container có một hoặc cả hai hành động.

Ví dụ dưới đây tạo `hyperlink-audit-input.pptx` với một liên kết click ngoài, một liên kết mouse‑over file, điều hướng slide nội bộ, một liên kết mouse‑over văn bản và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Ba truy vấn cùng hoạt động ở mọi phạm vi; các đếm mô tả số container, không phải tổng hành động. Phạm vi khung văn bản loại bỏ các liên kết của hình dạng bao quanh.

```java
import com.aspose.slides.*;

class QueryCounts {
    void print(String scope, IHyperlinkQueries queries) {
        int clickCount = queries.getHyperlinkClicks().size();
        int mouseOverCount = queries.getHyperlinkMouseOvers().size();
        int anyCount = queries.getAnyHyperlinks().size();
        System.out.println(scope + ": click=" + clickCount + ", mouse-over=" + mouseOverCount + ", any=" + anyCount);
    }
}

QueryCounts counts = new QueryCounts();
Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ISlide destination = presentation.getSlides().addEmptySlide(slide.getLayoutSlide());
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 400, 60);
    shape.getTextFrame().setText("Click the text to go to slide 2");
    shape.getHyperlinkManager().setExternalHyperlinkClick("https://example.com/");
    shape.getHyperlinkClick().setTooltip("Public website");
    shape.getHyperlinkManager().setExternalHyperlinkMouseOver("file:///C:/private/report.xlsx");

    IPortionFormat portionFormat = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0).getPortionFormat();
    portionFormat.getHyperlinkManager().setInternalHyperlinkClick(destination);
    portionFormat.getHyperlinkManager().setExternalHyperlinkMouseOver("https://example.com/help");
    IAutoShape macroButton = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 120, 200, 60);
    macroButton.getHyperlinkManager().setMacroHyperlinkClick("ReviewPresentation");

    counts.print("Presentation", presentation.getHyperlinkQueries());
    counts.print("Slide 1", slide.getHyperlinkQueries());
    counts.print("Text frame", shape.getTextFrame().getHyperlinkQueries());
    presentation.save("hyperlink-audit-input.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Đối với ví dụ này, các truy vấn bản trình chiếu và slide đều báo cáo ba container click, hai container mouse‑over và ba container có bất kỳ hành động nào. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân loại Hành động và Đích đến**

Sử dụng [IHyperlink.getActionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getActionType--) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/hyperlinkactiontype/) bao gồm hơn việc điều hướng web:

| Values | Ý nghĩa cho việc kiểm toán |
| --- | --- |
| `Hyperlink` | Liên kết ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi chiếu hiện tại hoặc bắt đầu buổi chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc một bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát đa phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc một hành động không xác định cần xem xét. |

Đọc các đích đến bên ngoài từ [getExternalUrl](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getExternalUrl--) và các đích đến nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getTargetSlide--). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; URL rỗng không có nghĩa là container không có hành động. Bảo lưu giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlink/#getTooltip--) nếu có.

### **Báo cáo, Làm sạch và Xác minh Hyperlink**

Ví dụ Java sau đọc một bản trình chiếu hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng một chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra cả hai loại kích hoạt một lần nữa. Nó thu thập các container trước khi thay đổi chúng và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bản trình chiếu bao phủ các slide thường; để có kiểm kê toàn gói, nó cũng truy vấn một cách rõ ràng các master, layout, notes và các master notes và handout khi có.

Báo cáo ghi lại chỉ số slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getSlideId--) khi có. [ISlideComponent.getSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islidecomponent/#getSlide--) cung cấp slide chủ sở hữu cho các container được hỗ trợ. Các master, layout và notes không có chỉ số slide bình thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng phần văn bản được gán nhãn riêng; các loại container khác giữ nguyên tên kiểu runtime. Mỗi container nhận một ID cục bộ trong báo cáo để hai hành động của nó có thể được liên kết. Báo cáo lưu trữ các loại hành động dưới dạng các hằng số nguyên được định nghĩa bởi enum Java.

Chính sách ứng dụng có tính hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động file, các hành động trình chiếu khác, hành động không xác định và các scheme URL khác. Những từ chối này là quyết định chính sách, không phải phán quyết an toàn của Aspose.Slides. HTTPS một mình không tạo ra niềm tin: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo dõi liên kết hay chạy hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Ở đây, các liên kết click bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các click và mouse‑over bị cấm khác được xóa độc lập. Đặt `replaceExternalClicks` thành `false` để xóa tất cả vi phạm chính sách. Chọn một trang thay thế thuộc sở hữu ứng dụng trước khi triển khai.

Cờ xuất khẩu của báo cáo sử dụng một chính sách xem xét PDF bảo thủ: đánh dấu các hành động mouse‑over và bất kỳ thứ gì khác ngoài liên kết ngoài hoặc nhảy slide cụ thể là có khả năng không được hỗ trợ. Đây là gợi ý kiểm tra, không phải kiểm tra khả năng hay bảo đảm các liên kết không được đánh dấu sẽ tồn tại sau xuất khẩu. Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại hyperlink, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các hình ảnh raster và video không thể giữ lại hyperlink tương tác; đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;
import java.util.IdentityHashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Objects;
import java.util.Set;

class HyperlinkAudit {
    Integer slideIndex(IPresentation presentation, IBaseSlide slide) {
        for (int index = 0; index < presentation.getSlides().size(); index++) {
            if (presentation.getSlides().get_Item(index) == slide) return index + 1;
        }
        return null;
    }

    boolean isHttps(String value) {
        if (value == null || value.isEmpty()) return false;
        try {
            URI uri = new URI(value);
            return uri.isAbsolute() && "https".equalsIgnoreCase(uri.getScheme()) && uri.getHost() != null;
        } catch (URISyntaxException exception) {
            return false;
        }
    }

    String policyViolation(IHyperlink link) {
        if (link == null) return null;
        if (link.getActionType() == HyperlinkActionType.JumpSpecificSlide) {
            return link.getTargetSlide() == null ? "Missing target slide" : null;
        }
        if (link.getActionType() != HyperlinkActionType.Hyperlink) return "Action is not allowed";
        if (!isHttps(link.getExternalUrl())) return "Normalized URL is not absolute HTTPS";
        String original = link.getExternalUrlOriginal();
        if (original != null && !original.isEmpty() && !isHttps(original)) return "Original URL is not absolute HTTPS";
        return null;
    }

    void addScope(List<IHyperlinkContainer> found, IBaseSlide slide) {
        if (slide != null) {
            for (IHyperlinkContainer container : slide.getHyperlinkQueries().getAnyHyperlinks()) {
                found.add(container);
            }
        }
    }

    List<IHyperlinkContainer> collectContainers(IPresentation presentation) {
        List<IHyperlinkContainer> found = new ArrayList<>();
        for (IHyperlinkContainer container : presentation.getHyperlinkQueries().getAnyHyperlinks()) {
            found.add(container);
        }
        for (IMasterSlide master : presentation.getMasters()) addScope(found, master);
        for (ILayoutSlide layout : presentation.getLayoutSlides()) addScope(found, layout);
        for (ISlide slide : presentation.getSlides()) addScope(found, slide.getNotesSlideManager().getNotesSlide());
        addScope(found, presentation.getMasterNotesSlideManager().getMasterNotesSlide());
        addScope(found, presentation.getMasterHandoutSlideManager().getMasterHandoutSlide());
        Set<IHyperlinkContainer> seen = Collections.newSetFromMap(new IdentityHashMap<IHyperlinkContainer, Boolean>());
        List<IHyperlinkContainer> unique = new ArrayList<>();
        for (IHyperlinkContainer container : found) {
            if (seen.add(container)) unique.add(container);
        }
        return unique;
    }

    void addRow(List<Map<String, Object>> rows, IPresentation presentation, IHyperlink link, String activation, IHyperlinkContainer container, int containerId) {
        if (link == null) return;
        IBaseSlide ownerSlide = container instanceof ISlideComponent ? ((ISlideComponent) container).getSlide() : null;
        ISlide targetSlide = link.getTargetSlide();
        String violation = policyViolation(link);
        String ownerType = container instanceof IShape ? "Shape" : container instanceof IPortionFormat ? "Text portion" : container.getClass().getSimpleName();
        boolean ordinaryAction = link.getActionType() == HyperlinkActionType.Hyperlink || link.getActionType() == HyperlinkActionType.JumpSpecificSlide;
        Map<String, Object> row = new LinkedHashMap<>();
        row.put("ContainerId", containerId);
        row.put("SlideIndex", slideIndex(presentation, ownerSlide));
        row.put("SlideId", ownerSlide == null ? null : ownerSlide.getSlideId());
        row.put("Scope", ownerSlide == null ? null : ownerSlide.getClass().getSimpleName());
        row.put("OwnerType", ownerType);
        row.put("Activation", activation);
        row.put("ActionType", link.getActionType());
        row.put("ExternalUrl", link.getExternalUrl());
        row.put("TargetSlideIndex", slideIndex(presentation, targetSlide));
        row.put("TargetSlideId", targetSlide == null ? null : targetSlide.getSlideId());
        row.put("Tooltip", link.getTooltip());
        row.put("OriginalExternalUrl", Objects.equals(link.getExternalUrlOriginal(), link.getExternalUrl()) ? null : link.getExternalUrlOriginal());
        row.put("PotentiallyUnsafe", violation != null);
        row.put("PolicyViolation", violation);
        row.put("TargetExport", "PDF");
        row.put("PotentiallyUnsupportedByExport", "mouse-over".equals(activation) || !ordinaryAction);
        rows.add(row);
    }

    // Chuẩn bị các dòng phẳng của báo cáo này dưới dạng JSON mà không cần phụ thuộc JSON bổ sung.
    String jsonValue(Object value) {
        if (value == null) return "null";
        if (value instanceof Number || value instanceof Boolean) return value.toString();
        StringBuilder escaped = new StringBuilder("\"");
        for (char character : value.toString().toCharArray()) {
            if (character == '"' || character == '\\') {
                escaped.append('\\').append(character);
            } else if (character < 0x20 || Character.isSurrogate(character)) {
                escaped.append(String.format("\\u%04x", (int) character));
            } else {
                escaped.append(character);
            }
        }
        return escaped.append('"').toString();
    }

    String toJson(List<Map<String, Object>> rows) {
        List<String> objects = new ArrayList<>();
        for (Map<String, Object> row : rows) {
            List<String> fields = new ArrayList<>();
            for (Map.Entry<String, Object> field : row.entrySet()) {
                fields.add("    " + jsonValue(field.getKey()) + ": " + jsonValue(field.getValue()));
            }
            objects.add("  {\n" + String.join(",\n", fields) + "\n  }");
        }
        return "[\n" + String.join(",\n", objects) + "\n]\n";
    }
}

boolean replaceExternalClicks = true;
String replacementUrl = "https://example.com/blocked-link";
HyperlinkAudit audit = new HyperlinkAudit();
Presentation presentation = new Presentation("hyperlink-audit-input.pptx");
try {
    List<IHyperlinkContainer> containers = audit.collectContainers(presentation);
    List<Map<String, Object>> rows = new ArrayList<>();
    for (int index = 0; index < containers.size(); index++) {
        IHyperlinkContainer container = containers.get(index);
        audit.addRow(rows, presentation, container.getHyperlinkClick(), "click", container, index + 1);
        audit.addRow(rows, presentation, container.getHyperlinkMouseOver(), "mouse-over", container, index + 1);
    }
    String json = audit.toJson(rows);
    byte[] jsonData = json.getBytes(StandardCharsets.UTF_8);
    Files.write(Paths.get("hyperlink-audit.json"), jsonData);

    for (IHyperlinkContainer container : containers) {
        IHyperlink click = container.getHyperlinkClick();
        if (audit.policyViolation(click) != null) {
            if (replaceExternalClicks && click.getActionType() == HyperlinkActionType.Hyperlink) {
                container.getHyperlinkManager().setExternalHyperlinkClick(replacementUrl);
            } else {
                container.getHyperlinkManager().removeHyperlinkClick();
            }
        }
        if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) {
            container.getHyperlinkManager().removeHyperlinkMouseOver();
        }
    }
    presentation.save("hyperlink-sanitized.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("hyperlink-sanitized.pptx");
    try {
        List<IHyperlinkContainer> remainingContainers = audit.collectContainers(reopened);
        int violations = 0;
        for (IHyperlinkContainer container : remainingContainers) {
            if (audit.policyViolation(container.getHyperlinkClick()) != null) violations++;
            if (audit.policyViolation(container.getHyperlinkMouseOver()) != null) violations++;
        }
        System.out.println("Audit rows: " + rows.size() + "; prohibited actions after reopening: " + violations);
        if (violations != 0) {
            System.out.println("Verification failed: do not distribute the saved presentation.");
        }
    } finally {
        reopened.dispose();
    }
} catch (IOException exception) {
    System.out.println("Unable to write the audit report: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Với dữ liệu đầu vào được tạo ở trên, báo cáo chứa năm dòng hành động. Liên kết mouse‑over file và click macro bị xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Kiểm tra xác minh in ra không có hành động bị cấm. Dữ liệu đầu vào chứa một URL click bên ngoài bị cấm cũng sẽ kích hoạt nhánh thay thế. Một container có click cho phép và mouse‑over bị cấm vẫn giữ lại hành động click của nó.

Việc dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) – phương pháp này xóa cả hai loại kích hoạt trong toàn bộ phạm vi đã chọn bất kể chính sách. Kiểm tra ở đây chỉ kiểm tra các hành động hyperlink; nó không xóa các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực một tệp PDF hoặc HTML đã xuất.

## **Câu hỏi thường gặp**

**Làm sao tôi có thể liên kết tới một phần hoặc slide đầu tiên của nó?**

Các phần trong PowerPoint nhóm các slide, nhưng một hyperlink nội bộ chỉ mục tiêu một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên trong phần đó.

**Tôi có thể đính kèm hyperlink vào các thành phần slide mẫu để nó hoạt động trên tất cả các slide không?**

Có. Các thành phần slide mẫu và layout hỗ trợ hyperlink. Các liên kết trên những thành phần này khả dụng trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Liên kết sẽ được giữ lại khi xuất ra PDF, HTML, hình ảnh hay video không?**

Các xuất khẩu PDF và HTML được hỗ trợ có thể giữ lại hyperlink; hình ảnh raster và video không thể. Xem các lưu ý xuất khẩu trong [Report, Sanitize, and Verify Hyperlinks](#report-sanitize-and-verify-hyperlinks).