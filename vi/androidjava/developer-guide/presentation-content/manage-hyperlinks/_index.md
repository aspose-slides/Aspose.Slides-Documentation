---
title: Quản lý Siêu liên kết trong Bản trình chiếu trên Android
linktitle: Quản lý Siêu liên kết
type: docs
weight: 20
url: /vi/androidjava/manage-hyperlinks/
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
- Android
- Java
- Aspose.Slides
description: "Thêm, định dạng, cập nhật và xoá siêu liên kết trong các bản trình chiếu PowerPoint và OpenDocument bằng Aspose.Slides cho Android qua Java, sử dụng các ví dụ Java."
---
## **Giới thiệu**

Một siêu liên kết kết nối nội dung bản trình chiếu với một trang web hoặc một vị trí trong bản trình chiếu. Trong PowerPoint, siêu liên kết thường phục vụ hai mục đích:

* Mở một trang web từ văn bản, hình dạng hoặc khung đa phương tiện.
* Điều hướng tới một slide khác, ví dụ, từ mục lục.

Aspose.Slides for Android via Java cho phép bạn thêm các liên kết này, kiểm soát giao diện và âm thanh, cập nhật thuộc tính và xoá chúng. Các ví dụ bên dưới cho thấy cách làm việc với siêu liên kết trên các phần tử riêng lẻ và cách truy cập siêu liên kết ở cấp độ bản trình chiếu, slide hoặc khung văn bản.

{{% alert color="info" title="Note" %}}
Bạn cũng có thể chỉnh sửa bản trình chiếu bằng [trình chỉnh sửa PowerPoint trực tuyến miễn phí của Aspose](https://products.aspose.app/slides/editor).
{{% /alert %}}

## **Thêm Siêu liên kết URL**

Bạn có thể gán URL trang web cho văn bản, hình dạng hoặc khung đa phương tiện. Phần tử mà bạn gán siêu liên kết quyết định vùng có thể nhấp: một đoạn văn bản liên kết phần văn bản đã chọn, trong khi một hình dạng hoặc khung liên kết toàn bộ đối tượng slide.

Đối với các bản trình chiếu chứa siêu liên kết tương đối, xem [Quản lý Cơ sở Siêu liên kết](/slides/vi/androidjava/presentation-properties/#manage-the-hyperlink-base) để đọc, thay đổi hoặc xóa cơ sở cấp tài liệu.

### **Thêm Siêu liên kết URL cho Văn bản**

Để liên kết văn bản với một trang web, truyền một [Hyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlink/) vào phương thức [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/portionformat/#setHyperlinkClick-com.aspose.slides.IHyperlink-) của phần văn bản, như minh họa bên dưới. Chỉ phần văn bản đó sẽ trở thành có thể nhấp.

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

### **Thêm Siêu liên kết URL cho Hình dạng và Khung Đa phương tiện**

Gọi [setHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setHyperlinkClick-com.aspose.slides.IHyperlink-) trên hình chữ nhật để làm cho toàn bộ khu vực của nó có thể nhấp. Sử dụng [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) để hiển thị gợi ý cho người đọc về đích khi họ di chuột qua hình chữ nhật. Cả hai phương thức cũng áp dụng cho khung ảnh, âm thanh và video.

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

## **Sử dụng Siêu liên kết để Tạo Mục lục**

Siêu liên kết nội bộ cho phép người đọc chuyển từ mục lục đến một slide cụ thể. Ví dụ dưới đây sử dụng [setInternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setInternalHyperlinkClick-com.aspose.slides.ISlide-) để liên kết văn bản “Page 2” trên slide đầu tiên tới slide thứ hai.

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

## **Định dạng Siêu liên kết**

Bạn có thể thay đổi màu của văn bản có liên kết, phát hoặc dừng âm thanh khi người đọc kích hoạt liên kết, và đặt tooltip xuất hiện khi di chuột.

### **Màu**

Phương thức [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) của [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) quyết định siêu liên kết sử dụng màu siêu liên kết của bản trình chiếu hay định dạng của phần văn bản. Để áp dụng màu văn bản tùy chỉnh, chọn [HyperlinkColorSource.PortionFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkcolorsource/) và đặt màu nền của phần. Tính năng này được giới thiệu trong PowerPoint 2019; các phiên bản cũ hơn không áp dụng cài đặt này.

Trong ví dụ này, [setColorSource](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setColorSource-int-) làm cho liên kết đầu tiên sử dụng màu nền đỏ của phần văn bản. Liên kết thứ hai giữ màu siêu liên kết của bản trình chiếu.

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

### **Âm thanh**

Siêu liên kết có thể phát âm thanh khi được kích hoạt hoặc dừng âm thanh đang phát. Sử dụng các phương thức sau để cấu hình các hành vi này:

- [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) chỉ định âm thanh liên quan đến siêu liên kết.
- [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) kiểm soát việc kích hoạt siêu liên kết có dừng âm thanh trước đó hay không.

#### **Thêm Âm thanh Siêu liên kết**

Nút trên slide đầu tiên sử dụng [IHyperlink.setSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setSound-com.aspose.slides.IAudio-) để phát âm thanh từ `sampleaudio.wav` khi người đọc nhấp để tiếp tục. Trên slide thứ hai, một nút riêng biệt sử dụng [IHyperlink.setStopSoundOnClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setStopSoundOnClick-boolean-) để dừng phát và giữ người đọc trên slide đó.

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

#### **Trích xuất Âm thanh Siêu liên kết**

Ví dụ sau mở bản trình chiếu được tạo ở trên và đọc âm thanh siêu liên kết của hình dạng đầu tiên vào bộ nhớ thông qua [getSound](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getSound--) và [getBinaryData](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iaudio/#getBinaryData--).

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

### **Tooltip và Cài đặt Tương tác**

Bạn có thể gọi các phương thức [IHyperlink](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/) sau khi gán siêu liên kết cho văn bản hoặc hình dạng:

- [setTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTooltip-java.lang.String-) đặt văn bản mà người xem có thể hiển thị dưới dạng gợi ý cho liên kết.
- [setTargetFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setTargetFrame-java.lang.String-) chỉ định khung đích trong một khung HTML cha, nếu có.
- [setHistory](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHistory-boolean-) kiểm soát việc kích hoạt liên kết có thêm đích đến vào danh sách các siêu liên kết đã xem hay không.
- [setHighlightClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#setHighlightClick-boolean-) kiểm soát việc siêu liên kết có được làm nổi bật khi nhấp hay không.

## **Xoá Siêu liên kết khỏi Bản trình chiếu**

Sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) để thu thập các container siêu liên kết, bao gồm các liên kết phần văn bản, trước khi thay đổi chúng. Ví dụ dưới đây xoá cả hai loại kích hoạt khỏi slide đầu tiên. Để xoá chỉ một loại, gọi chỉ [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) hoặc [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--); việc xoá hành động click không xoá hành động di chuột tương ứng.

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

Đối với việc xoá không điều kiện, [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) xoá cả hai loại kích hoạt trong phạm vi đã chọn chỉ trong một lần gọi. Đối với việc dọn dẹp có chọn lọc và bao phủ các master, layout và notes, xem [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).

### **Xóa Siêu liên kết Trước Khi Thay Thế Văn bản SmartArt**

Khi bạn thay thế một đoạn trong một nút SmartArt hiện có, việc xóa các phần văn bản có thể để lại một siêu liên kết cũ vẫn hoạt động. Lấy đoạn thông qua [ISmartArtNode.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getTextFrame--). Trước khi xóa các phần, gọi [getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--) trên khung văn bản của hình dạng nút hiển thị đoạn, sau đó gọi [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--) trên đối tượng được trả về. Điều này xoá mọi siêu liên kết trong khung đó, bao gồm các liên kết trong các đoạn khác.

Ví dụ giả định rằng hình dạng thứ ba trên slide đầu tiên của `SmartArtHyperlink.pptx` là một đồ họa SmartArt. Nó thay thế đoạn đầu tiên của nút thứ tư. Trong bản trình chiếu này, hình dạng đầu tiên của nút hiển thị đoạn đó.

Sau khi thêm cả hai phần, ví dụ đọc định dạng hiệu lực của chúng bằng [getEffective](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformat/#getEffective--). Trên định dạng đó, [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iportionformateffectivedata/#getHyperlinkClick--) trả về siêu liên kết mới cho phần đầu và `null` cho phần thứ hai.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("SmartArtHyperlink.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(2);
    ISmartArtNode node = smartArt.getAllNodes().get_Item(3);
    IParagraph paragraph = node.getTextFrame().getParagraphs().get_Item(0);

    node.getShapes().get_Item(0).getTextFrame().getHyperlinkQueries().removeAllHyperlinks();
    paragraph.getPortions().clear();

    IPortion link = new Portion("New reference");
    link.getPortionFormat().setHyperlinkClick(new Hyperlink("https://example.com/new"));
    paragraph.getPortions().add(link);
    IPortion text = new Portion(" (updated)");
    paragraph.getPortions().add(text);

    System.out.println(link.getPortionFormat().getEffective().getHyperlinkClick().getExternalUrl()); // https://example.com/new
    System.out.println(text.getPortionFormat().getEffective().getHyperlinkClick()); // null
} finally {
    presentation.dispose();
}
```

## **Xây dựng Danh mục Siêu liên kết Hoàn chỉnh**

Trước khi phân phối một bản trình chiếu, hãy kiểm kê các hành động tương tác cũng như các liên kết web của nó. [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các đối tượng [IHyperlinkContainer](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/), không phải danh sách phẳng các chuỗi URL. Kiểm tra cả [getHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkClick--) và [getHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkMouseOver--) trên mỗi container. Chúng độc lập: cùng một container có thể cung cấp cả hai hành động, vì vậy một báo cáo đầy đủ có thể cần tới hai dòng cho mỗi container.

Việc chỉ quét siêu liên kết ở cấp độ hình dạng có thể bỏ sót các liên kết gắn vào các phần văn bản. Hãy truy vấn phạm vi thích hợp thay vì vậy, và giữ lại các container được trả về để sau này có thể cập nhật hoặc xoá hành động của chúng.

### **Truy vấn Phạm vi Bản trình chiếu, Slide và Khung Văn bản**

Giao diện [IHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/) có sẵn qua [IPresentation.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ipresentation/#getHyperlinkQueries--), [IBaseSlide.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getHyperlinkQueries--), và [ITextFrame.getHyperlinkQueries](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/#getHyperlinkQueries--). Mỗi phạm vi hỗ trợ các truy vấn giống nhau:

- [getHyperlinkClicks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkClicks--) trả về các container có hành động click.
- [getHyperlinkMouseOvers](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getHyperlinkMouseOvers--) trả về các container có hành động di chuột.
- [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) trả về các container có một hoặc cả hai hành động.

Ví dụ này gán hành động click và di chuột cho một hình dạng và văn bản của nó, và một hành động macro cho một nút riêng. Nó so sánh số lượng container trả về bởi [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) với số lượng cho từng loại kích hoạt. Một truy vấn khung văn bản chỉ đếm các liên kết trong văn bản. Các hành động của hình dạng bao quanh xuất hiện trong các truy vấn slide và bản trình chiếu.

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

Đối với ví dụ này, các truy vấn bản trình chiếu và slide mỗi đều báo cáo ba container click, hai container di chuột, và ba container có bất kỳ hành động nào. Truy vấn khung văn bản báo cáo một container trong mỗi danh mục.

### **Phân loại Hành động và Đích đến**

Sử dụng [IHyperlink.getActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getActionType--) để giải thích một hành động trước khi giải thích đích đến của nó. Các giá trị [HyperlinkActionType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/hyperlinkactiontype/) bao phủ nhiều hơn chỉ điều hướng web:

| Values | Meaning for an audit |
| --- | --- |
| `Hyperlink` | Siêu liên kết bên ngoài; kiểm tra URL và giao thức của nó. |
| `JumpSpecificSlide` | Điều hướng nội bộ tới một slide cụ thể. |
| `JumpFirstSlide`, `JumpPreviousSlide`, `JumpNextSlide`, `JumpLastSlide`, `JumpLastViewedSlide` | Điều hướng trình chiếu tích hợp, được giải quyết trong ngữ cảnh trình chiếu. |
| `JumpEndShow`, `StartCustomSlideShow` | Kết thúc buổi chiếu hiện tại hoặc bắt đầu một buổi chiếu tùy chỉnh. |
| `StartMacro` | Thực thi macro. |
| `StartProgram` | Khởi chạy chương trình. |
| `OpenFile`, `OpenPresentation` | Mở tệp hoặc bản trình chiếu khác; xem xét riêng biệt so với URL web. |
| `StartStopMedia` | Bắt đầu hoặc dừng phát phương tiện. |
| `NoAction`, `Unknown` | Không có hành động điều hướng, hoặc hành động không nhận dạng được cần xem xét. |

Đọc các đích đến bên ngoài từ [getExternalUrl](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrl--) và các đích đến nội bộ cụ thể từ [getTargetSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTargetSlide--). Các hành động nội bộ và lệnh tích hợp có thể không có URL bên ngoài; một URL trống không có nghĩa là container không có hành động. Bảo tồn giá trị trả về bởi [getExternalUrlOriginal](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getExternalUrlOriginal--) khi nó khác với URL đã chuẩn hoá, và bao gồm tooltip trả về bởi [getTooltip](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlink/#getTooltip--) khi có.

### **Báo cáo, Làm sạch và Xác minh Siêu liên kết**

Ví dụ này mở bản trình chiếu từ ví dụ trước và ghi một bản ghi JSON cho mỗi hành động. Nó sử dụng [getAnyHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#getAnyHyperlinks--) để thu thập các container trên các slide thường, master, layout và notes, bao gồm cả master notes và handout khi có. Nó sử dụng so sánh tham chiếu để đếm mỗi container một lần, áp dụng chính sách được mô tả dưới đây, và mở lại bản trình chiếu đã lưu để kiểm tra cả hành động click và di chuột.

Báo cáo ghi chỉ mục slide (bắt đầu từ 1) và [getSlideId](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ibaseslide/#getSlideId--) khi có. [ISlideComponent.getSlide](https://reference.aspose.com/slides/androidjava/com.aspose.slides/islidecomponent/#getSlide--) cung cấp slide sở hữu cho các container được hỗ trợ. Master, layout và notes không có chỉ mục slide thường và được xác định bằng phạm vi của chúng. Các container hình dạng và container định dạng phần văn bản được đặt nhãn riêng; các loại container khác giữ tên kiểu thời gian chạy. Mỗi container nhận một ID báo cáo cục bộ để hai hành động của nó có thể được liên kết. Báo cáo lưu trữ kiểu hành động dưới dạng các hằng số nguyên được định nghĩa bởi enum Java.

Chính sách ứng dụng có tính hạn chế này cho phép chỉ các URL HTTPS tuyệt đối và các đích slide nội bộ hợp lệ. Nó từ chối macro, chương trình, hành động tệp, các hành động trình chiếu khác, hành động không xác định và các giao thức URL khác. Những từ chối này là quyết định chính sách, không phải phán quyết an toàn của Aspose.Slides. HTTPS một mình không tạo niềm tin: hãy thêm danh sách cho phép máy chủ và các kiểm tra khác cho ứng dụng của bạn. Cả URL bên ngoài gốc và đã chuẩn hoá đều được kiểm tra. Ví dụ kiểm toán siêu dữ liệu mà không theo liên kết hoặc chạy hành động.

Để khắc phục, [getHyperlinkManager](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkcontainer/#getHyperlinkManager--) của container hỗ trợ [setExternalHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-), [removeHyperlinkClick](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkClick--) và [removeHyperlinkMouseOver](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkmanager/#removeHyperlinkMouseOver--). Ở đây, các liên kết click bên ngoài bị cấm được thay thế bằng một trang đích HTTPS cố định; các click và di chuột bị cấm khác được xoá độc lập. Đặt `replaceExternalClicks` thành `false` để xoá tất cả các vi phạm chính sách. Chọn một trang thay thế sở hữu bởi ứng dụng trước khi triển khai.

Cờ xuất báo cáo sử dụng chính sách xem xét PDF thận trọng: gắn cờ các hành động di chuột và bất kỳ thứ gì không phải là liên kết bên ngoài hoặc chuyển slide cụ thể là có thể không được hỗ trợ. Đó là gợi ý xem xét, không phải kiểm tra khả năng hoặc bảo đảm các liên kết không có cờ sẽ tồn tại khi xuất. Các xuất PDF và HTML được hỗ trợ ([PDF](/slides/vi/androidjava/convert-powerpoint-to-pdf/) và [HTML](/slides/vi/androidjava/convert-powerpoint-to-html/)) có thể bảo toàn siêu liên kết, tùy vào hành động, tùy chọn xuất và trình xem. Các [hình ảnh](/slides/vi/androidjava/convert-powerpoint-to-png/) và [video](/slides/vi/androidjava/convert-powerpoint-to-video/) dạng raster không thể bảo toàn siêu liên kết tương tác; hãy gắn cờ mọi hành động khi kiểm toán cho các đầu ra đó.

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

    // Chuỗi hoá các hàng phẳng của báo cáo này mà không cần phụ thuộc JSON bổ sung.
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

Với đầu vào được tạo ở trên, báo cáo chứa năm hàng hành động. Liên kết di chuột của tệp và macro click bị xoá, trong khi các liên kết HTTPS và điều hướng slide nội bộ vẫn còn. Việc xác minh in ra không có hành động bị cấm. Một đầu vào chứa URL click bên ngoài bị cấm cũng thử nhánh thay thế. Một container có click cho phép và di chuột bị cấm giữ lại hành động click của nó.

Việc dọn dẹp có chọn lọc này khác với [removeAllHyperlinks](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ihyperlinkqueries/#removeAllHyperlinks--), vốn xoá cả hai loại kích hoạt trong phạm vi đã chọn bất kể chính sách. Việc xác minh ở đây chỉ kiểm tra hành động siêu liên kết; nó không xoá các dự án VBA nhúng, đối tượng OLE hoặc nội dung hoạt động khác, và không xác thực một tệp PDF hoặc HTML đã xuất.

## **FAQ**

**Làm sao tôi có thể liên kết đến một phần hoặc slide đầu tiên của phần đó?**

Các phần trong PowerPoint nhóm các slide, nhưng một siêu liên kết nội bộ chỉ nhắm tới một slide riêng lẻ. Để tạo điều hướng tới một phần, hãy liên kết đến slide đầu tiên trong phần đó.

**Tôi có thể gắn siêu liên kết vào các yếu tố slide master để nó hoạt động trên tất cả các slide không?**

Có. Các yếu tố slide master và layout hỗ trợ siêu liên kết. Các liên kết trên các yếu tố này sẽ có sẵn trong chế độ trình chiếu trên các slide sử dụng master hoặc layout tương ứng.

**Siêu liên kết có được bảo toàn khi xuất ra PDF, HTML, hình ảnh hoặc video không?**

Các xuất PDF và HTML được hỗ trợ có thể bảo toàn siêu liên kết; hình ảnh raster và video không thể. Xem các lưu ý xuất trong [Báo cáo, Làm sạch và Xác minh Siêu liên kết](#report-sanitize-and-verify-hyperlinks).