---
title: Quản lý các Slide Master của bài thuyết trình trên Android
linktitle: Slide Master
type: docs
weight: 70
url: /vi/androidjava/slide-master/
keywords:
- slide chủ
- slide chủ
- slide chủ PPT
- nhiều slide chủ
- so sánh slide chủ
- nền
- trình giữ chỗ
- sao chép slide chủ
- sao chép slide chủ
- nhân bản slide chủ
- slide chủ không sử dụng
- PowerPoint
- OpenDocument
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Quản lý các slide master trong Aspose.Slides cho Android qua Java: truy cập, chỉnh sửa, sao chép, so sánh và xóa các slide chủ trong bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Một **slide master** định nghĩa các thiết lập thiết kế chung cho một nhóm slide. Nó có thể chứa các hình dạng chung, logo, nền, kiểu chữ, thiết lập chủ đề và thiết lập chân trang. Trong PowerPoint, chỉnh sửa một slide master là cách thường dùng để giữ cho bài thuyết trình nhất quán mà không phải lặp lại cùng một định dạng trên mỗi slide.

Aspose.Slides for Android via Java hỗ trợ cùng mô hình. Một bài thuyết trình có thể chứa một hoặc nhiều slide master, và mỗi slide master có thể chứa một số layout slide. Các slide thường không tham chiếu trực tiếp tới slide master. Thay vào đó, một slide thường sử dụng một layout slide, và layout slide đó thuộc về một slide master.

Cây phân cấp là:

1. **Slide master** - định nghĩa thiết kế và chủ đề chung.  
1. **Layout slide** - xác định một bố trí cụ thể của các placeholder và định dạng cấp bố cục.  
1. **Normal slide** - chứa nội dung thực tế của bài thuyết trình và sử dụng một layout slide.

![Cây phân cấp của slide master, layout slide và normal slide](slide-master_2.jpg)

Trong Aspose.Slides, một slide master được biểu diễn bằng giao diện [IMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslide/). Tất cả các slide master trong một bài thuyết trình có thể truy cập qua tập hợp [Presentation.getMasters](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getMasters--) , tập hợp này triển khai [IMasterSlideCollection](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/). Để xem toàn bộ API Android via Java, xem tham chiếu API [com.aspose.slides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/).

{{% alert color="info" title="Kế thừa" %}}
Khi cùng một thuộc tính được định nghĩa ở hơn một mức, mức cụ thể hơn sẽ thắng. Ví dụ, nếu một slide master và một layout slide đều định nghĩa nền, các slide dựa trên layout đó sẽ sử dụng nền của layout. Để biết thêm thông tin về layout slide, xem [Apply or Change Slide Layouts](/slides/vi/androidjava/slide-layout/).
{{% /alert %}}

## **Truy cập Slide Masters**

Trong PowerPoint, bạn có thể mở chế độ xem Slide Master từ **View** > **Slide Master**.

![Lệnh Slide Master trên thẻ View của PowerPoint](slide-master_3.jpg)

Trong Aspose.Slides, dùng tập hợp `getMasters()` để truy cập các slide master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide firstMasterSlide = presentation.getMasters().get_Item(0);
    int masterSlideCount = presentation.getMasters().size();
    int firstMasterLayoutSlideCount = firstMasterSlide.getLayoutSlides().size();

    System.out.println("Master slides: " + masterSlideCount);
    System.out.println("Layouts in the first master: " + firstMasterLayoutSlideCount);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể lấy slide master được sử dụng bởi một slide thường thông qua layout của nó:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    ILayoutSlide layoutSlide = slide.getLayoutSlide();
    IMasterSlide masterSlide = layoutSlide.getMasterSlide();
    String masterSlideName = masterSlide.getName();

    System.out.println(masterSlideName);
} finally {
    presentation.dispose();
}
```

## **Nội dung của Slide Master**

Một master slide là một đối tượng giống slide. Nó triển khai [IBaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/), vì vậy nó cung cấp nhiều thuộc tính slide giống như các slide thường và layout.

Các thành viên thường dùng của master slide bao gồm:

| Thành viên | Mục đích |
| --- | --- |
| `getBackground()` | Đặt nền cho slide ở mức master. |
| `getShapes()` | Lưu trữ các hình dạng được đặt trên master, như logo, khung hình ảnh và văn bản chung. |
| `getLayoutSlides()` | Lưu trữ các layout slide thuộc về master. |
| `getThemeManager()` | Cung cấp truy cập vào các API chủ đề của master. |
| `getHeaderFooterManager()` | Điều khiển header, footer, ngày tháng và số slide cho master và các layout con. |
| `getDependingSlides()` | Trả về các normal slide phụ thuộc vào master thông qua layout của chúng. |

## **Thêm hình ảnh vào Slide Master**

Khi bạn thêm một hình ảnh vào master slide, nó sẽ xuất hiện trên các slide sử dụng layout từ master đó. Điều này hữu ích cho logo, watermark, dải trang trí và các yếu tố hình ảnh lặp lại khác.

Ví dụ sau thêm một logo vào slide master đầu tiên:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IImage logo = Images.fromFile("logo.png");

    try {
        IPPImage logoImage = presentation.getImages().addImage(logo);

        masterSlide.getShapes().addPictureFrame(
                ShapeType.Rectangle,
                20,
                20,
                80,
                80,
                logoImage);
    } finally {
        logo.dispose();
    }

    presentation.save("presentation-with-logo.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm thông tin về khung hình ảnh, xem [Picture Frame](/slides/vi/androidjava/picture-frame/).

## **Kiểm soát hiển thị đồ họa Master**

Sử dụng [IBaseSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#setShowMasterShapes-boolean-) để ẩn các đồ họa master kế thừa, như logo hoặc hình trang trí, mà không xóa chúng khỏi master. Truyền `false` cho [Slide.setShowMasterShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slide/#setShowMasterShapes-boolean-) trên slide cần bỏ các đồ họa và giữ `true` trên các slide muốn hiển thị chúng.

Ví dụ tự chứa sau tạo một dải trang trí màu xanh trên master và hai slide sử dụng cùng một layout trống. Dải này hiển thị trên slide đầu tiên và ẩn trên slide thứ hai. Không cần bất kỳ bài thuyết trình hoặc hình ảnh đầu vào nào.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide layoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    layoutSlide.setShowMasterShapes(true);

    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();
    IAutoShape band = masterSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, 60, slideHeight);
    int bandColor = Color.rgb(70, 130, 180);
    band.getFillFormat().setFillType(FillType.Solid);
    band.getFillFormat().getSolidFillColor().setColor(bandColor);
    band.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    ISlide visibleSlide = presentation.getSlides().get_Item(0);
    visibleSlide.setLayoutSlide(layoutSlide);
    visibleSlide.getShapes().clear();

    ISlide hiddenSlide = presentation.getSlides().addEmptySlide(layoutSlide);

    visibleSlide.setShowMasterShapes(true);
    hiddenSlide.setShowMasterShapes(false);

    presentation.save("master-graphics.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Ví dụ sử dụng layout **Blank** được cung cấp với một bài mới và loại bỏ các placeholder riêng của slide đầu tiên.

### **Chọn phạm vi của cài đặt**

Một normal slide sử dụng master của nó qua [ISlide.getLayoutSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islide/#getLayoutSlide--) và [ILayoutSlide.getMasterSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ilayoutslide/#getMasterSlide--). Đặt thuộc tính trên một slide riêng chỉ ảnh hưởng tới slide đó. Truyền `false` cho [LayoutSlide.setShowMasterShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/layoutslide/#setShowMasterShapes-boolean-) sẽ ẩn đồ họa master cho các slide dùng layout chung, ngay cả khi cài đặt riêng của chúng là `true`. Để ẩn đồ họa chỉ trên một slide, thay đổi thuộc tính của slide và giữ layout chung không thay đổi.

Cài đặt này không được hỗ trợ làm điều khiển hiển thị trên chính slide master. Trên master, [getShowMasterShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterslide/#getShowMasterShapes--) luôn trả về `false`, và truyền `true` cho [setShowMasterShapes](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/masterslide/#setShowMasterShapes-boolean-) sẽ ném ngoại lệ. Áp dụng nó cho một normal slide hoặc một layout thay vì master.

### **Phân biệt đồ họa và nền**

| Hoạt động | Hiệu quả |
| --- | --- |
| Ẩn đồ họa master | Điều khiển việc hiển thị các shape kế thừa từ master mà không xóa chúng hoặc thay đổi các shape của slide. |
| Thay đổi nền slide | Thay đổi màu nền, gradient hoặc hình ảnh. Đồ họa master là các shape riêng biệt và có thể vẫn hiển thị trên nền đó. Xem [Presentation Background](/slides/vi/androidjava/presentation-background/). |
| Xóa shape khỏi master | Loại bỏ shape nguồn chung, vì vậy nó không còn khả dụng cho bất kỳ slide nào sử dụng master đó. |

## **Làm việc với Placeholder**

Placeholder thường được định nghĩa trên layout slide. Master slide cung cấp style và theme chung mà các layout kế thừa, trong khi mỗi layout quyết định placeholder nào có sẵn và vị trí đặt chúng.

Trong PowerPoint, các lệnh placeholder có sẵn trong chế độ xem Slide Master.

![Lệnh Insert Placeholder trong chế độ Slide Master của PowerPoint](slide-master_5.png)

Để thêm placeholder mới với Aspose.Slides, làm việc với layout slide thuộc về master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    ILayoutSlide blankLayoutSlide = masterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);

    if (blankLayoutSlide == null) {
        blankLayoutSlide = masterSlide.getLayoutSlides().add(SlideLayoutType.Blank, "Blank");
    }

    blankLayoutSlide.getPlaceholderManager().addTextPlaceholder(60, 120, 600, 80);

    presentation.getSlides().addEmptySlide(blankLayoutSlide);
    presentation.save("presentation-with-placeholder.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể định dạng các shape placeholder đã tồn tại trên master slide. Ví dụ sau tìm placeholder tiêu đề và áp dụng màu gradient tuyến tính:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    IAutoShape titlePlaceholder = null;

    for (IShape shape : masterSlide.getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;

            if (autoShape.getPlaceholder() != null &&
                    autoShape.getPlaceholder().getType() == PlaceholderType.Title) {
                titlePlaceholder = autoShape;
                break;
            }
        }
    }

    if (titlePlaceholder != null) {
        Color redGradientColor = new Color(255, 0, 0);
        Color purpleGradientColor = new Color(128, 0, 128);

        titlePlaceholder.getFillFormat().setFillType(FillType.Gradient);
        titlePlaceholder.getFillFormat().getGradientFormat().setGradientShape(GradientShape.Linear);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(0.0f, redGradientColor);
        titlePlaceholder.getFillFormat().getGradientFormat().getGradientStops().add(1.0f, purpleGradientColor);
    }

    presentation.save("presentation-title-style.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Placeholder tiêu đề đã định dạng được kế thừa bởi normal slides](slide-master_8.png)

Để biết thêm các tùy chọn định dạng placeholder và văn bản, xem [Set Prompt Text in Placeholder](/slides/vi/androidjava/manage-placeholder/) và [Text Formatting](/slides/vi/androidjava/text-formatting/).

## **Thay đổi nền Slide Master**

Nền master được kế thừa bởi các layout và slide không ghi đè nó. Ví dụ sau đặt màu nền đặc cho slide master đầu tiên:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide masterSlide = presentation.getMasters().get_Item(0);
    Color masterBackgroundColor = Color.GREEN;

    masterSlide.getBackground().setType(BackgroundType.OwnBackground);
    masterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    masterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(masterBackgroundColor);

    presentation.save("presentation-master-background.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xem các chủ đề liên quan, xem [Presentation Background](/slides/vi/androidjava/presentation-background/) và [Presentation Theme](/slides/vi/androidjava/presentation-theme/).

## **Sao chép Slide Master sang một Bài thuyết trình khác**

Sử dụng [IMasterSlideCollection.addClone](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imasterslidecollection/#addClone-com.aspose.slides.IMasterSlide-) để sao chép một slide master vào bài thuyết trình khác. Master đã sao chép sau đó có thể được sử dụng bởi các layout và slide trong bài đích.

```java
import com.aspose.slides.*;

Presentation sourcePresentation = new Presentation("source.pptx");
Presentation destinationPresentation = new Presentation("destination.pptx");
try {
    IMasterSlide sourceMasterSlide = sourcePresentation.getMasters().get_Item(0);
    IMasterSlide clonedMasterSlide = destinationPresentation.getMasters().addClone(sourceMasterSlide);

    destinationPresentation.save("destination-with-master.pptx", SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
    destinationPresentation.dispose();
}
```

Nếu bạn cần sao chép các slide thường cùng với master của chúng, xem [Clone Slides](/slides/vi/androidjava/clone-slides/).

## **Thêm nhiều Slide Master**

Một bài thuyết trình có thể chứa nhiều slide master. Điều này hữu ích khi các phần khác nhau yêu cầu branding, cấu trúc trang hoặc cài đặt theme khác nhau.

![Các lệnh PowerPoint để chèn và quản lý slide master](slide-master_9.jpg)

Ví dụ sau sao chép master mặc định, đặt nền khác cho bản sao, tạo một layout dưới master đã sao chép, và thêm một slide mới dựa trên layout đó:

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation("presentation.pptx");
try {
    IMasterSlide defaultMasterSlide = presentation.getMasters().get_Item(0);
    IMasterSlide sectionMasterSlide = presentation.getMasters().addClone(defaultMasterSlide);
    Color sectionMasterBackgroundColor = Color.GRAY;

    sectionMasterSlide.getBackground().setType(BackgroundType.OwnBackground);
    sectionMasterSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    sectionMasterSlide.getBackground().getFillFormat().getSolidFillColor().setColor(sectionMasterBackgroundColor);

    ILayoutSlide sourceBlankLayout = defaultMasterSlide.getLayoutSlides().getByType(SlideLayoutType.Blank);
    if (sourceBlankLayout == null) {
        sourceBlankLayout = defaultMasterSlide.getLayoutSlides().get_Item(0);
    }

    ILayoutSlide sectionBlankLayout = sectionMasterSlide.getLayoutSlides().addClone(sourceBlankLayout);

    presentation.getSlides().addEmptySlide(sectionBlankLayout);
    presentation.save("presentation-with-multiple-masters.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **So sánh Slide Masters**

Slide master có thể so sánh bằng phương thức `equals` kế thừa từ [IBaseSlide](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/). Việc so sánh kiểm tra cấu trúc và nội dung tĩnh, như shape, văn bản, định dạng, hoạt ảnh và các cài đặt slide khác. Nó không so sánh các định danh duy nhất, như ID slide, hoặc giá trị placeholder động, như ngày hiện tại.

```java
import com.aspose.slides.*;

Presentation firstPresentation = new Presentation("first.pptx");
Presentation secondPresentation = new Presentation("second.pptx");
try {
    int firstPresentationMasterCount = firstPresentation.getMasters().size();
    int secondPresentationMasterCount = secondPresentation.getMasters().size();

    for (int firstMasterIndex = 0; firstMasterIndex < firstPresentationMasterCount; firstMasterIndex++) {
        for (int secondMasterIndex = 0; secondMasterIndex < secondPresentationMasterCount; secondMasterIndex++) {
            IMasterSlide firstMasterSlide = firstPresentation.getMasters().get_Item(firstMasterIndex);
            IMasterSlide secondMasterSlide = secondPresentation.getMasters().get_Item(secondMasterIndex);
            boolean areMasterSlidesEqual = firstMasterSlide.equals(secondMasterSlide);

            if (areMasterSlidesEqual) {
                System.out.printf(
                        "first.pptx master #%d equals second.pptx master #%d%n",
                        firstMasterIndex,
                        secondMasterIndex);
            }
        }
    }
} finally {
    firstPresentation.dispose();
    secondPresentation.dispose();
}
```

Để biết thêm thông tin, xem [Compare Presentation Slides](/slides/vi/androidjava/compare-slides/).

## **Đặt chế độ Slide Master làm chế độ xem mặc định**

Sử dụng phương thức `setLastView` trên [ViewProperties](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/viewproperties/) để điều khiển chế độ xem mà PowerPoint mở đầu tiên. Ví dụ sau mở bài thuyết trình ở chế độ Slide Master:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getViewProperties().setLastView(ViewType.SlideMasterView);
    presentation.save("presentation-master-view.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để biết thêm các cài đặt chế độ xem, xem [Save Presentation](/slides/vi/androidjava/save-presentation/).

## **Xóa các Slide Master không sử dụng**

Bài thuyết trình đôi khi chứa các slide master không còn được bất kỳ slide thường nào sử dụng. Xóa các master không dùng có thể giảm kích thước tệp và đơn giản hóa việc bảo trì mẫu.

Sử dụng `removeUnused` để xóa các master không dùng khỏi tập hợp `getMasters()`:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getMasters().removeUnused(true);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bạn cũng có thể dùng phương thức low-code [Compress.removeUnusedMasterSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/compress/#removeUnusedMasterSlides-com.aspose.slides.Presentation-) :

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    Compress.removeUnusedMasterSlides(presentation);
    presentation.save("presentation-clean.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Sự khác nhau giữa slide master và layout slide là gì?**

Slide master định nghĩa các thiết lập thiết kế chung như theme, nền, hình dạng chung và kiểu chữ. Layout slide thuộc về một slide master và xác định bố trí cụ thể của các placeholder. Một normal slide sử dụng một layout slide, vì vậy nó kế thừa từ cả layout và master.

**Một bài thuyết trình có thể chứa nhiều slide master không?**

Có. Một bài thuyết trình có thể chứa nhiều slide master. Sử dụng nhiều master khi các phần khác nhau cần hệ thống hình ảnh hoặc branding khác nhau.

**Nên thêm placeholder vào slide master hay layout slide?**

Trong hầu hết các trường hợp, thêm placeholder vào layout slide. Đặt các yếu tố hình ảnh chung và định dạng chung trên slide master, sau đó đặt các placeholder nội dung trên layout mà các slide thường sẽ sử dụng.

**Tôi có thể xóa một slide master đang được sử dụng không?**

Không. Slide master có các slide phụ thuộc không thể xóa trực tiếp một cách an toàn. Đầu tiên chuyển các slide đó sang layout dưới một master khác, hoặc dùng phương pháp dọn dẹp master không dùng để chỉ xóa các master không có slide nào sử dụng.