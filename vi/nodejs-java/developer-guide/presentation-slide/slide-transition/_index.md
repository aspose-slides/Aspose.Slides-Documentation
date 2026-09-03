---
title: Quản lý chuyển đổi slide trong bài thuyết trình bằng JavaScript
linktitle: Chuyển đổi slide
type: docs
weight: 80
url: /vi/nodejs-java/slide-transition/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tiến hành slide tự động, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho Node.js qua Java."
---
## **Tổng quan**

Các chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi chiếu slide. Với Aspose.Slides cho Node.js qua Java, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc tiến tới bằng cú nhấp chuột hoặc bộ đếm thời gian, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ JavaScript để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide và tạo chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình bày bằng lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/) và truy cập cài đặt chuyển đổi của slide thông qua [getSlideShowTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitiontype/), sau đó lưu bản trình bày.

Ví dụ sau áp dụng chuyển đổi Circle cho slide đầu tiên và chuyển đổi Comb cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        presentation.getSlides().get_Item(0).getSlideShowTransition().setType(slides.TransitionType.Circle);
        presentation.getSlides().get_Item(1).getSlideShowTransition().setType(slides.TransitionType.Comb);

        presentation.save("slide-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide hiển thị trên màn hình và liệu một cú nhấp chuột có tiến tới buổi chiếu slide hay không. Các phương thức sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem tiến tới bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật tiến tới tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi tiến tới tự động, tính bằng mili giây.

Bật cả tiến tới bằng cú nhấp và thời gian để cho phép người xem di chuyển bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ sử dụng bộ hẹn giờ, truyền `false` vào [setAdvanceOnClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ điều khiển thời điểm buổi chiếu slide tiến tới; nó không đặt thời lượng của hiệu ứng chuyển đổi trực quan.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật tiến tới tự động sau 3, 5 và 7 giây, tương ứng. Các cú nhấp chuột cũng có thể tiến tới các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 3) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Circle);
        firstTransition.setAdvanceOnClick(true);
        firstTransition.setAdvanceAfter(true);
        firstTransition.setAdvanceAfterTime(3000);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Comb);
        secondTransition.setAdvanceOnClick(true);
        secondTransition.setAdvanceAfter(true);
        secondTransition.setAdvanceAfterTime(5
000);

        const thirdTransition = presentation.getSlides().get_Item(2).getSlideShowTransition();
        thirdTransition.setType(slides.TransitionType.Zoom);
        thirdTransition.setAdvanceOnClick(true);
        thirdTransition.setAdvanceAfter(true);
        thirdTransition.setAdvanceAfterTime(7000);

        presentation.save("advanced-transitions.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least three slides.");
    }
} finally {
    presentation.dispose();
}
```

Để kiểm tra xem tiến tới có thời gian đã được bật hay chưa, gọi [getAdvanceAfter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ được lưu không đồng nghĩa với việc bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ được bật và vô hiệu hoá tiến tới tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật tiến tới bằng cú nhấp cho những slide đó và lưu lại các cài đặt đã cập nhật.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("advanced-transitions.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();

        if (transition.getAdvanceAfter()) {
            console.log("Slide " + slide.getSlideNumber() + ": advance after " + transition.getAdvanceAfterTime() + " ms.");

            if (transition.getAdvanceAfterTime() > 2000) {
                transition.setAdvanceAfter(false);
                transition.setAdvanceOnClick(true);
            }
        }
    }

    presentation.save("adjusted-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kiểm soát thời gian chuyển đổi một cách chính xác**

Sử dụng [setDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng mili giây. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) của slide cung cấp các cài đặt này qua [SlideShowTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của chính hiệu ứng chuyển đổi, tính bằng mili giây. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tiến tới tự động, tính bằng mili giây. Truyền `true` vào [setAdvanceAfter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một loại tốc độ được định trước từ liệt kê [TransitionSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium hoặc Fast. Được sử dụng khi không chỉ định thời lượng cụ thể. |

[setDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ tiến tới tự động riêng biệt. Khi không đặt thời lượng cụ thể, Aspose.Slides sẽ xác định thời lượng hiệu ứng dựa trên kiểu chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ đồng nhất, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitiontype/), và đặt thời lượng cho mỗi chuyển đổi là 750 mili giây. Đồng thời bật tiến tới tự động sau 5.000 mili giây và tắt tiến tới bằng cú nhấp chuột, rồi lưu kết quả dưới dạng PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Cấu hình tiến trình tự động một cách độc lập với thời lượng hiệu ứng.
        transition.setAdvanceAfter(true);
        transition.setAdvanceAfterTime(5000);
        transition.setAdvanceOnClick(false);
    }

    presentation.save("precise-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Đặt thời lượng khác nhau cho từng slide**

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng chuyển đổi ngắn cho slide tiêu đề và chuyển đổi dài hơn cho phần giới thiệu chương. Ví dụ này đặt 500 mili giây cho slide đầu tiên và 1.200 mili giây cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const firstTransition = presentation.getSlides().get_Item(0).getSlideShowTransition();
        firstTransition.setType(slides.TransitionType.Fade);
        firstTransition.setDuration(500);

        const secondTransition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        secondTransition.setType(slides.TransitionType.Push);
        secondTransition.setDuration(1200);

        presentation.save("individual-transition-durations.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

### **Phối hợp chuyển đổi với đầu ra động**

Khi chuẩn bị một [animated GIF](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/nodejs-java/export-to-html5/), hoặc [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 mili giây giữa các cảnh, và điều chỉnh độ trễ tiến tới của từng slide riêng biệt để cho phép thời gian cho lời thuyết minh hoặc nội dung.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 mili giây tương đương 18 khung hình ở 30 khung hình mỗi giây. Trong HTML5, bật chuyển đổi động trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ bởi định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getDuration) trước khi chỉnh sửa chuyển đổi để xác định liệu đã lưu giá trị cụ thể nào hay chưa. Giá trị `-1` có nghĩa là chưa đặt thời lượng cụ thể; một giá trị không âm chỉ thời lượng đã lưu tính bằng mili giây. Giá trị chưa đặt không phải là thời lượng phát lại được tính toán: Aspose.Slides sử dụng kiểu chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt kiểu chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra cài đặt gốc trước.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        const duration = transition.getDuration();

        if (duration >= 0) {
            console.log("Slide " + slide.getSlideNumber() + ": stored transition duration is " + duration + " ms.");
        } else {
            console.log("Slide " + slide.getSlideNumber() + ": no explicit duration; timing depends on transition type " + transition.getType() + " and speed " + transition.getSpeed() + ".");
        }
    }
} finally {
    presentation.dispose();
}
```

## **Chuyển đổi Morph**

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép các đối tượng tương ứng được hoạt ảnh giữa trạng thái gốc và đã chỉnh sửa.

Ví dụ sau tạo một slide với một hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong trình xem bản trình bày hỗ trợ Morph để xem hiệu ứng trong buổi chiếu slide.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const firstSlide = presentation.getSlides().get_Item(0);
    const rectangle = firstSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 100, 100, 400, 100);
    rectangle.getTextFrame().setText("Morph transition");

    const secondSlide = presentation.getSlides().addClone(firstSlide);
    const movedRectangle = secondSlide.getShapes().get_Item(0);
    movedRectangle.setX(movedRectangle.getX() + 100);
    movedRectangle.setY(movedRectangle.getY() + 50);
    movedRectangle.setWidth(movedRectangle.getWidth() - 200);
    movedRectangle.setHeight(movedRectangle.getHeight() - 10);

    secondSlide.getSlideShowTransition().setType(slides.TransitionType.Morph);

    presentation.save("morph-transition.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Các loại chuyển đổi Morph**

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) xử lý mỗi hình dạng như một đối tượng hoàn chỉnh.
- [ByWord](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getValue). Giá trị sau đó cung cấp một đối tượng [MorphTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/morphtransition/), phương thức [setMorphType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/morphtransition/#setMorphType) của nó chọn chế độ khớp.

Ví dụ này mở bản trình bày đã tạo ở phần trước và cấu hình slide thứ hai sử dụng hoạt ảnh Morph dựa trên từ.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("morph-transition.pptx");
try {
    if (presentation.getSlides().size() >= 2) {
        const transition = presentation.getSlides().get_Item(1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Morph);
        const transitionValue = transition.getValue();

        if (java.instanceOf(transitionValue, "com.aspose.slides.IMorphTransition")) {
            transitionValue.setMorphType(slides.TransitionMorphType.ByWord);
            presentation.save("morph-by-word.pptx", slides.SaveFormat.Pptx);
        } else {
            console.log("Morph transition options are unavailable.");
        }
    } else {
        console.log("The input presentation must contain at least two slides.");
    }
} finally {
    presentation.dispose();
}
```

## **Đặt hiệu ứng chuyển đổi**

Một số chuyển đổi cung cấp các tùy chọn bổ sung, chẳng hạn như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn có sẵn phụ thuộc vào chuyển đổi đã chọn bằng [setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setType). Đặt kiểu trước, sau đó sử dụng đối tượng chuyển đổi thích hợp từ [getValue](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) qua [OptionalBlackTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    const transition = presentation.getSlides().get_Item(0).getSlideShowTransition();
    transition.setType(slides.TransitionType.Cut);
    const transitionValue = transition.getValue();

    if (java.instanceOf(transitionValue, "com.aspose.slides.IOptionalBlackTransition")) {
        transitionValue.setFromBlack(true);
        presentation.save("cut-from-black.pptx", slides.SaveFormat.Pptx);
    } else {
        console.log("Cut transition options are unavailable.");
    }
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của chuyển đổi slide không?**

Có. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng mili giây. Sử dụng [setSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionspeed/) đã định trước—Slow, Medium hoặc Fast—đủ và không có thời lượng cụ thể nào được đặt. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ tiến tới tự động.

**Tôi có thể gắn âm thanh vào chuyển đổi và làm cho nó lặp lại không?**

Có. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setSound), truyền StartSound từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi chiếu slide.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/#getSlides) của bản trình bày và gọi [setType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho mỗi chuyển đổi của slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán giữa các slide.

**Làm sao tôi kiểm tra chuyển đổi hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/#getType) trên kết quả của [getSlideShowTransition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.