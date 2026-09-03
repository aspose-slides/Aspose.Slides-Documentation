---
title: Quản lý chuyển tiếp slide trong bài thuyết trình bằng Java
linktitle: Chuyển tiếp slide
type: docs
weight: 80
url: /vi/java/slide-transition/
keywords:
- chuyển tiếp slide
- thêm chuyển tiếp slide
- áp dụng chuyển tiếp slide
- chuyển tiếp slide nâng cao
- chuyển tiếp morph
- loại chuyển tiếp
- hiệu ứng chuyển tiếp
- PowerPoint
- OpenDocument
- bài thuyết trình
- Java
- Aspose.Slides
description: "Áp dụng chuyển tiếp slide, cấu hình tiến trình tự động của slide, và tùy chỉnh Morph và các hiệu ứng chuyển tiếp khác với Aspose.Slides cho Java."
---
## **Tổng quan**

Chuyển tiếp slide kiểm soát cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides for Java, bạn có thể chọn hiệu ứng chuyển tiếp cho mỗi slide, cấu hình tiến trình bằng cú nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn đặc thù cho một hiệu ứng. Bài viết này sử dụng các ví dụ Java để áp dụng chuyển tiếp, đặt thời lượng chuyển tiếp chính xác, quản lý thời gian slide và tạo chuyển tiếp Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển tiếp slide**

Để áp dụng một chuyển tiếp, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) và truy cập cài đặt chuyển tiếp của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Sử dụng [setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setType-int-) với giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ sau áp dụng chuyển tiếp Circle cho slide đầu tiên và chuyển tiếp Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

## **Thêm chuyển tiếp slide nâng cao**

Bạn có thể cấu hình thời gian một slide ở trên màn hình và liệu một cú nhấp chuột có tiến tới buổi trình chiếu hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) cho phép tiến tới tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) chỉ định độ trễ trước khi tiến tới tự động, tính bằng milisecond.

Kích hoạt cả hai cách tiến tới bằng nhấp chuột và thời gian để cho phép người xem chuyển tiếp bằng nhấp chuột hoặc chờ bộ đếm. Để chỉ sử dụng bộ đếm, truyền `false` cho [setAdvanceOnClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Độ trễ kiểm soát thời điểm buổi trình chiếu tiến tới; nó không xác định thời lượng của hiệu ứng chuyển tiếp hình ảnh.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và kích hoạt tiến trình tự động sau 3, 5 và 7 giây tương ứng. Các slide cũng có thể được tiến tới bằng nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem tiến trình tự động có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Một độ trễ được lưu không đồng nghĩa với việc bộ đếm đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ đếm được bật, và tắt tiến trình tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide này và lưu lại cài đặt đã cập nhật.

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

Sử dụng [setDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) để chỉ định độ dài chính xác của hiệu ứng chuyển tiếp tính bằng milisecond. Phương pháp [getSlideShowTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide tiết lộ các cài đặt này thông qua [ISlideShowTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) | Đặt thời lượng của hiệu ứng chuyển tiếp tính bằng milisecond. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Đặt độ trễ trước khi slide tiến tới tự động, tính bằng milisecond. Truyền `true` cho [setAdvanceAfter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) để kích hoạt bộ đếm này. |
| [setSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Chọn một danh mục tốc độ được xác định trước từ [TransitionSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được dùng khi không chỉ định thời lượng cụ thể. |

[setDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) chỉ điều khiển hiệu ứng chuyển tiếp; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến trình tự động riêng biệt. Khi không có thời lượng cụ thể, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getSpeed--) .

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ đồng nhất, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitiontype/), và cho mỗi chuyển tiếp thời lượng 750 milisecond. Nó cũng bật tiến trình tự động sau 5.000 milisecond và tắt tiến trình bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Cấu hình tiến trình tự động một cách độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Đặt thời lượng khác nhau cho các slide riêng lẻ**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển tiếp ngắn cho slide tiêu đề và chuyển tiếp dài hơn cho phần giới thiệu. Ví dụ này đặt 500 milisecond cho slide đầu tiên và 1.200 milisecond cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển tiếp với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/java/export-to-html5/), hoặc [video](/slides/vi/java/convert-powerpoint-to-video/), đặt thời lượng chuyển tiếp chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng fade 600 milisecond giữa các cảnh, và điều chỉnh độ trễ tiến trình của mỗi slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, đồng bộ tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 milisecond tương đương 18 khung hình ở 30 khung hình/giây. Trong HTML5, bật chuyển tiếp hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước kết quả để xác nhận đồng bộ.

### **Đọc thời lượng chuyển tiếp hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getDuration--) trước khi sửa đổi chuyển tiếp để xác định xem có giá trị rõ ràng nào đã được lưu không. Giá trị `-1` có nghĩa là không có thời lượng cụ thể được đặt; giá trị không âm chỉ thời lượng đã lưu tính bằng milisecond. Giá trị chưa đặt không phải là thời lượng phát tính toán: Aspose.Slides sử dụng loại chuyển tiếp và giá trị [getSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getSpeed--) để xác định thời lượng đó. Việc đặt loại chuyển tiếp có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

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

## **Chuyển tiếp Morph**

Chuyển tiếp Morph hoạt ảnh các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển tiếp Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng chuyển động giữa trạng thái ban đầu và trạng thái đã sửa đổi.

Ví dụ sau tạo một slide có hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

## **Các loại chuyển tiếp Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionmorphtype/) quy định cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionmorphtype/#ByObject) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách ghép các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách ghép ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setType-int-) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getValue--). Giá trị trả về cung cấp giao diện [IMorphTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imorphtransition/), trong đó phương thức [setMorphType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/imorphtransition/#setMorphType-int-) chọn chế độ ghép.

Ví dụ này mở bản trình chiếu đã tạo ở phần trước và cấu hình slide thứ hai sử dụng hoạt ảnh Morph dựa trên từ.

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

## **Đặt hiệu ứng chuyển tiếp**

Một số chuyển tiếp cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc liệu hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào chuyển tiếp đã chọn bằng [setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setType-int-). Đặt loại trước, sau đó sử dụng giao diện thích hợp từ [getValue](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getValue--).

Ví dụ sau áp dụng chuyển tiếp Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ioptionalblacktransition/) để chuyển tiếp bắt đầu từ màn hình đen.

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

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát của chuyển tiếp slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setDuration-int-) khi bạn cần thời lượng hiệu ứng chính xác tính bằng milisecond. Sử dụng [setSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setSpeed-int-) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionspeed/) đã định (Slow, Medium hoặc Fast) là đủ và không có thời lượng cụ thể nào được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển tiếp một cách độc lập so với độ trễ tiến trình tự động.

**Tôi có thể đính kèm âm thanh vào một chuyển tiếp và lặp lại không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), truyền StartSound từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionsoundmode/) cho [setSoundMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setSoundMode-int-), và bật [setSoundLoop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển tiếp cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/#getSlides--) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#setType-int-) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để giữ hành vi nhất quán giữa các slide.

**Làm thế nào để kiểm tra chuyển tiếp nào hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/islideshowtransition/#getType--) trên kết quả trả về của [getSlideShowTransition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitiontype/); None nghĩa là không có hiệu ứng chuyển tiếp nào được áp dụng.