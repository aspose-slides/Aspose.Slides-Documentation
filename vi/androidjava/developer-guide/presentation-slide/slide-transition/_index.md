---
title: Quản lý chuyển đổi slide trong các bài thuyết trình trên Android
linktitle: Chuyển đổi Slide
type: docs
weight: 80
url: /vi/androidjava/slide-transition/
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
- bài thuyết trình
- Android
- Java
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tự động chuyển tiếp slide, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides for Android qua Java."
---
## **Tổng quan**

Các chuyển đổi slide điều khiển cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides for Android qua Java, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn dành riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ Java để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/) và truy cập cài đặt chuyển đổi của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--). Sử dụng [setType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) với một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitiontype/), sau đó lưu bản trình chiếu.

Ví dụ dưới đây áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có chuyển tiếp buổi trình chiếu hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) kích hoạt chuyển tiếp tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) chỉ định độ trễ trước khi chuyển tiếp tự động, tính bằng mili giây.

Bật cả chuyển tiếp bằng nhấp chuột và bằng thời gian để cho phép người xem chuyển tiếp bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ dùng bộ hẹn giờ, truyền `false` cho [setAdvanceOnClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceOnClick-boolean-). Độ trễ chỉ kiểm soát thời điểm buổi trình chiếu tiến tới; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật chuyển tiếp tự động sau 3, 5 và 7 giây tương ứng. Người dùng cũng có thể chuyển tiếp các slide này bằng cú nhấp chuột. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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

Để kiểm tra xem chuyển tiếp có được bật theo thời gian hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getAdvanceAfter--). Một độ trễ đã lưu không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật chuyển tiếp bằng nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

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

## **Điều khiển thời gian chuyển đổi một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide cung cấp các cài đặt này thông qua interface [ISlideShowTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfterTime-long-) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng mili giây. Truyền `true` cho [setAdvanceAfter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setAdvanceAfter-boolean-) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) | Chọn một hạng mục tốc độ định trước từ [TransitionSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được dùng khi không chỉ định thời lượng chính xác. |

[setDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) chỉ điều khiển hiệu ứng chuyển đổi; nó không quyết định thời gian slide hiển thị. Cấu hình độ trễ chuyển tiếp tự động riêng biệt. Khi không đặt thời lượng cụ thể, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) .

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitiontype/), và đặt thời lượng của mỗi chuyển đổi là 750 mili giây. Nó tách biệt bật chuyển tiếp tự động sau 5.000 mili giây và tắt chuyển tiếp bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        ISlideShowTransition transition = slide.getSlideShowTransition();
        transition.setType(TransitionType.Fade);
        transition.setDuration(750);

        // Cấu hình chuyển tiếp tự động độc lập với thời lượng hiệu ứng.
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

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, dùng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi lâu hơn cho phần giới thiệu mục. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra hoạt hình**

Khi chuẩn bị một [animated GIF](/slides/vi/androidjava/convert-powerpoint-to-animated-gif/), một [HTML5 presentation](/slides/vi/androidjava/export-to-html5/), hoặc một [video](/slides/vi/androidjava/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để khớp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ chuyển tiếp của từng slide riêng biệt để cho phép thời gian cho phần thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở 30 khung hình mỗi giây. Trong HTML5, bật chuyển đổi hoạt hình trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận sự đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getDuration--) trước khi chỉnh sửa chuyển đổi để xác định xem có giá trị thời lượng cụ thể nào được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng cụ thể được đặt; một giá trị không âm chỉ thời lượng được lưu tính bằng mili giây. Giá trị chưa được đặt không phải là thời lượng phát lại đã tính: Aspose.Slides sử dụng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getSpeed--) để xác định thời lượng đó. Việc đặt loại chuyển đổi có thể khởi tạo một thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

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

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng được hoạt ảnh giữa trạng thái gốc và đã sửa đổi.

Ví dụ dưới đây tạo một slide có một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó nó chọn Morph từ enumeration [TransitionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

## **Các loại chuyển đổi Morph**

Enumeration [TransitionMorphType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionmorphtype/) điều khiển cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionmorphtype/#ByObject) xem mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getValue--). Giá trị trả về sẽ cung cấp interface [IMorphTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imorphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/imorphtransition/#setMorphType-int-) của nó chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo ở phần trước và cấu hình slide thứ hai để sử dụng hoạt ảnh Morph dựa trên từ.

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

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng có bắt đầu từ màn hình đen hay không. Các tùy chọn khả dụng phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-). Đặt loại trước, sau đó sử dụng interface thích hợp từ [getValue](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getValue--).

Ví dụ dưới đây áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioptionalblacktransition/#setFromBlack-boolean-) thông qua [IOptionalBlackTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ioptionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setDuration-int-) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setSpeed-int-) khi một hạng mục [TransitionSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionspeed/) định trước—Slow, Medium hoặc Fast—đủ và không có thời lượng cụ thể được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ chuyển tiếp tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại không?**

Có. Gắn âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setSound-com.aspose.slides.IAudio-), truyền giá trị StartSound từ enumeration [TransitionSoundMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionsoundmode/) cho [setSoundMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setSoundMode-int-), và bật [setSoundLoop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setSoundLoop-boolean-) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/#getSlides--) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#setType-int-) với cùng một giá trị cho mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao kiểm tra chuyển đổi nào đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/islideshowtransition/#getType--) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ibaseslide/#getSlideShowTransition--) của slide. Nó trả về một giá trị từ enumeration [TransitionType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.