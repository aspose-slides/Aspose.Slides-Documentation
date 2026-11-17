---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng Java
linktitle: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/java/slide-transition/
keywords:
- chuyển đổi slide
- thêm chuyển đổi slide
- áp dụng chuyển đổi slide
- chuyển đổi slide nâng cao
- chuyển đổi morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bản trình chiếu
- Java
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tự động tiến tới slide, và tùy chỉnh Morph cũng như các hiệu ứng chuyển đổi khác với Aspose.Slides cho Java."
---
## **Tổng quan**

Các chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi chiếu slide. Với Aspose.Slides for Java, bạn có thể chọn hiệu ứng chuyển tiếp cho từng slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho mỗi hiệu ứng. Bài viết này sử dụng các ví dụ Java để áp dụng chuyển tiếp, đặt thời lượng chuyển tiếp chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển tiếp cho slide**

Để áp dụng một chuyển tiếp, tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/) và truy cập cài đặt chuyển tiếp của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Sử dụng [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

        presentation.save("slide-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển tiếp bánh xe**

Phương thức [setSpokes](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/#setSpokes-long-) của [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/) kiểm soát số sector tia radial hiển thị slide đích. Đặt loại chuyển tiếp của slide thành Wheel từ [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) bằng [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) trước khi truy cập [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--) dưới dạng [IWheelTransition](https://reference.aspose.com/slides/java/com.aspose.slides/iwheeltransition/).

Ví dụ này tạo hai cặp slide giống hệt nhau: một slide đen và một slide có hình chữ nhật màu vàng. Các slide đích sử dụng số spoke là 1 và 8, với cùng tốc độ được đặt qua [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) và thời lượng rõ ràng 8.000 mil giây được đặt qua [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) để dễ quan sát sự khác biệt.

```java
import java.awt.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    float slideWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float slideHeight = (float) presentation.getSlideSize().getSize().getHeight();

    ISlide blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(BackgroundType.OwnBackground);
    blackSlide.getBackground().getFillFormat().setFillType(FillType.Solid);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.BLACK);

    ISlide destinationSlide = presentation.getSlides().addClone(blackSlide);
    IAutoShape rectangle = destinationSlide.getShapes().addAutoShape(ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(FillType.Solid);
    Color gold = new Color(255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    long[] spokeCounts = { 1, 8 };
    for (int i = 0; i < spokeCounts.length; i++) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(TransitionType.Wheel);
        IWheelTransition wheelTransition = (IWheelTransition) transition.getValue();
        wheelTransition.setSpokes(spokeCounts[i]);
        transition.setSpeed(TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mở bản trình chiếu đầu ra trong PowerPoint và chạy buổi chiếu slide. Tiến tới slide 2 từ slide 1, sau đó từ slide 3 tới slide 4. Trong chế độ phát lại PowerPoint, số spoke 1 hiển thị slide bằng một vòng quay theo chiều kim đồng hồ; số spoke 8 hiển thị nó qua tám sector tia đồng thời. Nội dung đích và thời gian chuyển tiếp là giống nhau, vì vậy sự khác biệt chỉ nằm ở số sector hiển thị.

## **Thêm chuyển tiếp slide nâng cao**

Bạn có thể cấu hình thời gian một slide ở lại trên màn hình và việc một cú nhấp chuột có chuyển tiếp hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) bật tự động tiến tới.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) chỉ định độ trễ trước khi tự động tiến tới, tính bằng mil giây.

Kích hoạt cả tiến tới bằng nhấp chuột và bằng thời gian để người xem có thể chuyển bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `false` vào [setAdvanceOnClick](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Độ trễ kiểm soát thời điểm buổi chiếu slide tiến tới; nó không đặt thời lượng của hiệu ứng chuyển tiếp trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tự động tiến tới sau 3, 5 và 7 giây tương ứng. Các slide cũng có thể tiến tới bằng cú nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5000);

        ISlideShowTransition thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Để kiểm tra xem tự động tiến tới có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Một độ trễ lưu trữ riêng không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật, và tắt tự động tiến tới cho những slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho các slide đó và lưu lại cài đặt đã cập nhật.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("advanced-transitions.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            System.out.println("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm soát thời gian chuyển tiếp một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) để chỉ định độ dài chính xác của một hiệu ứng chuyển tiếp tính bằng mil giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide cung cấp các cài đặt này thông qua [ISlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Đặt thời lượng của hiệu ứng chuyển tiếp, tính bằng mil giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Đặt độ trễ trước khi slide tự động tiến tới, tính bằng mil giây. Truyền `true` vào [setAdvanceAfter](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Chọn một mức tốc độ đã định trước từ [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/): Slow, Medium, hoặc Fast. Được sử dụng khi không chỉ định thời lượng cụ thể. |

[setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) chỉ kiểm soát hiệu ứng chuyển tiếp; nó không quyết định thời gian slide ở lại hiển thị. Cấu hình độ trễ tự động tiến tới riêng biệt. Khi không có thời lượng rõ ràng, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển tiếp 750‑ms và cài đặt tự động tiến tới 5.000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung này đặt cho mỗi slide một chuyển đổi Fade 750‑ms và đồng thời bật tự động tiến tới sau 5.000 ms. Thời lượng chuyển đổi kiểm soát hiệu ứng; tiến tới kiểm soát thời điểm rời slide. Các thanh này là cài đặt sơ đồ, không phải một dòng thời gian đo đạc thực tế.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ đồng nhất, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/), và đặt thời lượng mỗi chuyển đổi là 750 mil giây. Đồng thời bật tự động tiến tới sau 5.000 mil giây và tắt tiến tới bằng nhấp chuột, rồi lưu kết quả dưới dạng PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Cấu hình tiến tới tự động độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Đặt thời lượng khác nhau cho từng slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi dài hơn cho slide giới thiệu phần. Ví dụ này đặt 500 ms cho slide đầu tiên và 1.200 ms cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(TransitionType.Fade);
        firstTransition.setDuration(500);

        ISlideShowTransition secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Kết hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/java/export-to-html5/), hoặc [video](/slides/vi/java/convert-powerpoint-to-video/), hãy đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng fade 600 ms giữa các cảnh và điều chỉnh độ trễ tiến tới của mỗi slide riêng để cho phép thời gian cho phần thuyết minh hoặc nội dung.

Đối với GIF và video, đồng bộ tốc độ khung hình của đầu ra với thời lượng hiệu ứng: 600 ms tương đương 18 khung hình ở 30 fps. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận sự đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getDuration--) trước khi sửa đổi chuyển đổi để xác định liệu có giá trị cụ thể nào đã được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng cụ thể được đặt; giá trị không âm chỉ thời lượng đã lưu tính bằng mil giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides sử dụng loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getSpeed--) để xác định thời lượng đó. Đặt loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        int duration = transition.getDuration();

        if (duration >= 0) {
            System.out.println("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            System.out.println("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Morph**

Chuyển đổi Morph hoạt họa các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cung cấp các đối tượng liên quan để hoạt họa giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide có hình chữ nhật văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);
    IAutoShape rectangle = firstSlide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    ISlide secondSlide = presentation.getSlides().addClone(firstSlide);
    IShape movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(TransitionType.Morph);

    presentation.save("morph-transition.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Các loại Morph Transition**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt họa nội dung:

- [ByObject](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByObject) xử lý mỗi hình dạng như một đối tượng nguyên khối.
- [ByWord](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByWord) hoạt họa văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/java/com.aspose.slides/transitionmorphtype/#ByChar) hoạt họa văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--). Giá trị trả về sẽ cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/), trong đó phương thức [setMorphType](https://reference.aspose.com/slides/java/com.aspose.slides/imorphtransition/#setMorphType-int-) chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt họa Morph dựa trên từ.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        ISlideShowTransition transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(TransitionType.Morph);
        ITransitionValueBase transitionValue = transition.getValue();

        if (transitionValue instanceof IMorphTransition) {
            IMorphTransition morphTransition = (IMorphTransition) transitionValue;
            morphTransition.setMorphType(TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", SaveFormat.Pptx);
        } else {
            System.out.println("Morph transition options are unavailable.");
        }
    } else {
        System.out.println("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn khả dụng phụ thuộc vào chuyển đổi đã chọn bằng [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-). Đặt loại trước, sau đó sử dụng giao diện thích hợp từ [getValue](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getValue--).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ioptionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlideShowTransition transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(TransitionType.Cut);
    ITransitionValueBase transitionValue = transition.getValue();

    if (transitionValue instanceof IOptionalBlackTransition) {
        IOptionalBlackTransition cutTransition = (IOptionalBlackTransition) transitionValue;
        cutTransition.setFromBlack(true);
        presentation.save("cut-from-black.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát lại của một chuyển đổi slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setDuration-int-) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mil giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/java/com.aspose.slides/transitionspeed/) đã định—Slow, Medium, hoặc Fast—đủ và không có thời lượng cụ thể được đặt. Những cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ tự động tiến tới.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và làm cho nó lặp lại không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), truyền `StartSound` từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), và bật [setSoundLoop](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getSlides--) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#setType-int-) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán trên tất cả các slide.

**Làm sao tôi kiểm tra được chuyển đổi nào đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/java/com.aspose.slides/islideshowtransition/#getType--) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/java/com.aspose.slides/transitiontype/); giá trị None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.