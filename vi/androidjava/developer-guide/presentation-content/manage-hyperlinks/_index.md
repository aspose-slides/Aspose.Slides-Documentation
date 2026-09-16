---
title: Quản lý Siêu Liên Kết Bài Thuyết Trình trên Android
linktitle: Quản lý Siêu Liên Kết
type: docs
weight: 20
url: /vi/androidjava/manage-hyperlinks/
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xóa siêu liên kết trong các bài thuyết trình PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, sử dụng các ví dụ Java."
---
## **Giới thiệu**

Liên kết siêu văn bản kết nối nội dung bài thuyết trình với một trang web hoặc một vị trí trong bài thuyết trình. Trong PowerPoint, liên kết siêu văn bản thường thực hiện hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung phương tiện.
* Điều hướng đến một slide khác, ví dụ như từ mục lục.

Aspose.Slides cho Android thông qua Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh, cập nhật thuộc tính và xóa chúng. Các ví dụ dưới đây cho thấy cách làm việc với liên kết siêu văn bản trên các phần tử riêng lẻ và cách truy cập liên kết ở mức bài thuyết trình, slide hoặc khung văn bản.

{{% alert color="info" title="Lưu ý" %}}
Bạn cũng có thể chỉnh sửa bài thuyết trình bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/vi/editor).
{{% /alert %}} 

## **Thêm Liên Kết URL**

Bạn có thể gán một URL website cho văn bản, hình dạng hoặc khung phương tiện. Phần tử mà bạn gán liên kết quyết định khu vực có thể nhấp: một đoạn văn bản sẽ liên kết phần văn bản đã chọn, trong khi một hình dạng hoặc khung sẽ liên kết đối tượng slide.

### **Thêm Liên Kết URL vào Văn Bản**

Để liên kết văn bản với một website, truyền một [Hyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) của đoạn văn bản, như minh họa bên dưới. Chỉ đoạn văn bản đó sẽ trở nên có thể nhấp.

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

### **Thêm Liên Kết URL vào Hình Dạng và Khung Phương Tiện**

Để làm cho một hình dạng hoặc khung có thể nhấp, gọi phương thức [setHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) của nó. Liên kết thuộc về đối tượng đó chứ không phải một đoạn văn bản bên trong.

Cách tiếp cận tương tự áp dụng cho khung hình ảnh, âm thanh và video: gán liên kết cho khung và gọi [setTooltip](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) nếu cần.

Ví dụ sau làm cho một hình chữ nhật có thể nhấp:

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

## **Sử Dụng Liên Kết Để Tạo Mục Lục**

Liên kết nội bộ cho phép người đọc chuyển từ mục lục sang một slide cụ thể. Ví dụ sau sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

## **Định Dạng Liên Kết**

### **Màu Sắc**

Phương thức [setColorSource](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) của [IHyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/) xác định liệu liên kết có sử dụng màu liên kết của bài thuyết trình hay định dạng của đoạn văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/hyperlinkcolorsource/) và đặt màu tô đầy cho đoạn. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng thiết lập này.

Ví dụ sau thêm hai liên kết văn bản vào cùng một slide. Liên kết đầu tiên sử dụng màu tô đỏ, trong khi liên kết thứ hai giữ màu liên kết mặc định.

```java
import com.aspose.slides.*;
import android.graphics.Color;

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

### **Âm Thanh**

Một liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình hành vi này:

- [IHyperlink.setSound](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) chỉ định âm thanh liên quan đến liên kết.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) kiểm soát việc kích hoạt liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm Thanh cho Liên Kết**

Ví dụ sau tải `sampleaudio.wav` và gán nó cho một nút trên slide đầu tiên. Nhấp nút sẽ phát âm thanh và chuyển đến slide kế tiếp. Một hình dạng thứ hai trên slide đó sẽ dừng âm thanh trước khi thực hiện bất kỳ hành động chuyển slide nào.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.io.FileInputStream;

Presentation presentation = new Presentation();
try {
    IAudio hyperlinkSound;
    try (FileInputStream audioStream = new FileInputStream("sampleaudio.wav")) {
        hyperlinkSound = presentation.getAudios().addAudio(audioStream);
    }

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

#### **Trích Xuất Âm Thanh của Liên Kết**

Ví dụ sau mở lại bài thuyết trình đã tạo ở trên và đọc âm thanh của liên kết trong hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getSound--) và [getBinaryData](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Tooltip và Cài Đặt Tương Tác**

Bạn có thể gọi các phương thức [IHyperlink](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/) sau khi đã gán liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) đặt văn bản mà người xem có thể hiển thị dưới dạng gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) chỉ định khung đích trong một khung HTML cha, khi áp dụng.
- [setHistory](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) kiểm soát việc kích hoạt liên kết có được thêm vào danh sách các liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) kiểm soát việc liên kết được làm nổi bật khi nhấp.

## **Xóa Liên Kết khỏi Bài Thuyết Trình**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) để thu thập các container liên kết, bao gồm cả liên kết đoạn văn bản, trước khi thay đổi chúng. Ví dụ sau xóa cả hai kiểu kích hoạt khỏi slide đầu tiên. Để xóa chỉ một kiểu, chỉ cần gọi [removeHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); việc xóa hành động nhấp không xóa hành động rê chuột tương ứng.

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

Đối với việc xóa không điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) xóa cả hai kiểu kích hoạt trong phạm vi đã chọn chỉ bằng một lần gọi. Để thực hiện dọn dẹp có chọn lọc và bao phủ các master, layout và ghi chú, tham khảo [Báo cáo, Làm sạch và Xác minh Liên kết](#report-sanitize-and-verify-hyperlinks).

## **Xây Dựng Danh Mục Liên Kết Đầy Đủ**

Trước khi phân phối một bài thuyết trình, hãy liệt kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) trên mỗi container. Chúng độc lập: cùng một container có thể cung cấp cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai hàng cho mỗi container.

Việc chỉ quét các liên kết ở mức hình dạng có thể bỏ lỡ các liên kết gắn vào đoạn văn bản. Hãy truy vấn phạm vi phù hợp và giữ lại các container trả về để sau này có thể cập nhật hoặc xóa các hành động của chúng.

### **Truy Vấn Phạm Vi Bài Thuyết Trình, Slide và Khung Văn Bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/) có sẵn qua [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), và [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) trả về các container có hành động nhấp.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) trả về các container có hành động rê chuột.
- [getAnyHyperlinks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các container có một hoặc cả hai hành động.

Ví dụ sau tạo `hyperlink-audit-input.pptx` với một liên kết nhấp ngoài, một liên kết rê chuột tới tệp, điều hướng slide nội bộ, một liên kết rê chuột văn bản và một hành động macro. Nó không thực thi bất kỳ hành động nào trong số này. Ba truy vấn đều hoạt động ở mọi phạm vi; số lượng trả về là số container, không phải tổng hành động. Phạm vi khung văn bản loại trừ các liên kết riêng của hình dạng bao quanh.

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

Trong ví dụ này, truy vấn bài thuyết trình và slide mỗi đều báo cáo ba container nhấp, hai container rê chuột và ba container có ít nhất một hành động. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân Loại Hành Động và Đích Đến**

Sử dụng [IHyperlink.getActionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getActionType--) để giải thích một hành động trước khi xác định đích đến. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/hyperlinkactiontype/) bao gồm nhiều hơn chỉ điều hướng web:

| Giá trị | Ý nghĩa trong kiểm toán |
| --- | --- |
| `Hyperlink` | Liên kết ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng slide trình chiếu tích hợp, được xử lý trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi chiếu hiện tại hoặc bắt đầu buổi chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy một chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc bài thuyết trình khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không xác định cần kiểm tra. |

Đọc đích ngoài qua [getExternalUrl](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) và các đích nội bộ cụ thể qua [getTargetSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Các hành động nội bộ và lệnh tích hợp có thể không có URL ngoài; URL trống không có nghĩa là container không có hành động. Giữ lại giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) nếu có.

### **Báo Cáo, Làm Sạch và Xác Minh Liên Kết**

Ví dụ Java dưới đây đọc một bài thuyết trình hiện có (sử dụng tệp đã tạo ở trên), ghi `hyperlink-audit.json`, áp dụng chính sách, lưu `hyperlink-sanitized.pptx`, và mở lại để kiểm tra lại cả hai kiểu kích hoạt. Nó thu thập các container trước khi thay đổi và sử dụng so sánh tham chiếu để tránh xử lý cùng một container hai lần. Các truy vấn bài thuyết trình bao gồm các slide thường; để có danh mục toàn bộ gói, nó còn truy vấn rõ ràng các master, layout, ghi chú và cả master ghi chú và bản phát tay nếu có.

Báo cáo ghi lại chỉ mục slide bắt đầu từ 1 và [getSlideId](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) nếu có. [ISlideComponent.getSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islidecomponent/#getSlide--) cung cấp slide sở hữu cho các container hỗ trợ. Các master, layout và ghi chú không có chỉ mục slide thông thường và được xác định bởi phạm vi của chúng. Các container hình dạng và container định dạng đoạn văn bản được dán nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy. Mỗi container nhận một ID cục bộ trong báo cáo để có thể liên kết hai hành động của nó. Báo cáo lưu loại hành động dưới dạng các hằng số số nguyên được định nghĩa bởi enum Java.

Chính sách ứng dụng hạn chế này chỉ cho phép các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó loại bỏ macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các giao thức URL khác. Những từ chối này là quyết định chính sách, không phải kết luận an toàn của Aspose.Slides. HTTPS một mình không tạo nên độ tin cậy: hãy thêm danh sách cho phép host và các kiểm tra khác cho ứng dụng của bạn. Cả URL ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo dõi liên kết hay thực thi hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Ở đây, các liên kết nhấp ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các nhấp và rê chuột bị cấm khác được xóa riêng biệt. Đặt `replaceExternalClicks` thành `false` để xóa toàn bộ các vi phạm chính sách. Chọn một trang thay thế do ứng dụng sở hữu trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem xét PDF bảo thủ: đánh dấu các hành động rê chuột và bất kỳ thứ gì khác ngoài liên kết ngoài hoặc nhảy slide cụ thể là có khả năng không được hỗ trợ. Đây chỉ là gợi ý xem xét, không phải kiểm tra khả năng hoặc đảm bảo các liên kết không được đánh dấu sẽ tồn tại khi xuất. Các xuất PDF và HTML được hỗ trợ có thể giữ lại liên kết, tùy thuộc vào hành động, tùy chọn xuất và trình xem. Các hình ảnh raster và video không thể giữ lại liên kết tương tác; hãy đánh dấu mọi hành động khi kiểm toán cho các đầu ra đó.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.net.URI;
import java.net.URISyntaxException;
import java.nio.charset.StandardCharsets;
import java.io.FileOutputStream;
import android.text.TextUtils;
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

    // Serial hoá các hàng phẳng của báo cáo này mà không cần phụ thuộc vào JSON bổ sung.
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
            objects.add("  {\n" + TextUtils.join(",\n", fields) + "\n  }");
        }
        return "[\n" + TextUtils.join(",\n", objects) + "\n]\n";
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
    try (FileOutputStream reportStream = new FileOutputStream("hyperlink-audit.json")) {
        reportStream.write(jsonData);
    }

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

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết rê chuột tệp và macro nhấp được xóa, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Việc xác minh in ra không có hành động bị cấm. Một đầu vào có URL nhấp ngoài bị cấm cũng sẽ kích hoạt nhánh thay thế. Một container có nhấp được cho phép và rê chuột bị cấm sẽ giữ lại hành động nhấp của nó.

Việc dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) — phương pháp này xóa cả hai kiểu kích hoạt trên toàn phạm vi đã chọn bất kể chính sách. Việc xác minh ở đây chỉ kiểm tra các hành động liên kết; nó không xóa các dự án VBA nhúng, đối tượng OLE hay nội dung hoạt động khác, cũng không xác thực tệp PDF hoặc HTML đã xuất.

## **Câu Hỏi Thường Gặp**

**Làm thế nào để liên kết tới một phần hoặc slide đầu tiên của phần đó?**

Các phần trong PowerPoint nhóm các slide, nhưng một liên kết nội bộ chỉ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết tới slide đầu tiên của phần đó.

**Có thể gắn một liên kết vào các yếu tố slide master để nó hoạt động trên mọi slide không?**

Có. Các yếu tố slide master và layout hỗ trợ liên kết. Các liên kết trên các yếu tố này sẽ khả dụng trong chế độ chiếu slide trên các slide sử dụng master hoặc layout tương ứng.

**Liên kết có được giữ lại khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể giữ lại liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong [Báo cáo, Làm sạch và Xác minh Liên kết](#report-sanitize-and-verify-hyperlinks).