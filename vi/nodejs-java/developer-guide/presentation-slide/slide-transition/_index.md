---
title: Quản lý chuyển đổi slide trong bản trình chiếu bằng JavaScript
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
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Áp dụng chuyển đổi slide, cấu hình tự động chuyển tiếp slide, và tùy chỉnh Morph và các hiệu ứng chuyển đổi khác với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Các chuyển đổi slide kiểm soát cách các slide xuất hiện trong buổi trình chiếu. Với Aspose.Slides cho Node.js thông qua Java, bạn có thể chọn hiệu ứng chuyển đổi cho mỗi slide, cấu hình việc chuyển tiếp bằng cú nhấp chuột hoặc bộ hẹn giờ, và điều chỉnh các tùy chọn riêng cho một hiệu ứng. Bài viết này sử dụng các ví dụ JavaScript để áp dụng chuyển đổi, đặt thời lượng chuyển đổi chính xác, quản lý thời gian slide, và tạo một chuyển đổi Morph giữa hai slide. Các ví dụ cũng cho thấy cách lưu các cài đặt vào tệp PPTX.

## **Thêm chuyển đổi slide**

Để áp dụng một chuyển đổi, tải một bản trình chiếu bằng lớp [Presentation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/) và truy cập cài đặt chuyển đổi của slide qua [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition). Sử dụng [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) với một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) , sau đó lưu bản trình chiếu.

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

## **Chuyển đổi bánh xe**

Phương thức [setSpokes](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/#setSpokes) của [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/) kiểm soát số lượng sector (khoảng) bán kính mà tiết lộ slide đích. Đặt loại chuyển đổi của slide thành Wheel từ [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) bằng cách sử dụng [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) trước khi truy cập [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue) như [WheelTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/wheeltransition/).

Ví dụ này tạo hai cặp slide giống hệt nhau: một slide màu đen tiếp theo là một slide có hình chữ nhật màu vàng. Các slide đích sử dụng số spoke là 1 và 8, với tốc độ giống nhau được đặt qua [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) và thời lượng rõ ràng là 8.000 millisecond được đặt qua [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) để dễ quan sát sự khác biệt.

```javascript
const java = require("java");
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideWidth = presentation.getSlideSize().getSize().getWidth();
    const slideHeight = presentation.getSlideSize().getSize().getHeight();

    const blackSlide = presentation.getSlides().get_Item(0);
    blackSlide.getShapes().clear();
    blackSlide.getBackground().setType(java.newByte(slides.BackgroundType.OwnBackground));
    blackSlide.getBackground().getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const black = java.newInstanceSync("java.awt.Color", 0, 0, 0);
    blackSlide.getBackground().getFillFormat().getSolidFillColor().setColor(black);

    const destinationSlide = presentation.getSlides().addClone(blackSlide);
    const rectangle = destinationSlide.getShapes().addAutoShape(slides.ShapeType.Rectangle, 0, 0, slideWidth, slideHeight);
    rectangle.getFillFormat().setFillType(java.newByte(slides.FillType.Solid));
    const gold = java.newInstanceSync("java.awt.Color", 255, 215, 0);
    rectangle.getFillFormat().getSolidFillColor().setColor(gold);
    rectangle.getTextFrame().setText("Wheel transition");

    presentation.getSlides().addClone(blackSlide);
    presentation.getSlides().addClone(destinationSlide);

    const spokeCounts = [1, 8];
    for (let i = 0; i < spokeCounts.length; i++) {
        const transition = presentation.getSlides().get_Item(i * 2 + 1).getSlideShowTransition();
        transition.setType(slides.TransitionType.Wheel);
        const wheelTransition = transition.getValue();
        wheelTransition.setSpokes(java.newLong(spokeCounts[i]));
        transition.setSpeed(slides.TransitionSpeed.Slow);
        transition.setDuration(8000);
    }

    presentation.save("wheel-transitions.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Mở bản trình chiếu đầu ra trong PowerPoint và chạy buổi trình chiếu. Chuyển từ slide 1 sang slide 2, sau đó từ slide 3 sang slide 4. Trong phát lại PowerPoint, số spoke đã xác nhận là 1 sẽ tiết lộ slide bằng một vòng quay theo chiều kim đồng hồ; số đã xác nhận là 8 sẽ tiết lộ nó qua tám sector bán kính đồng thời. Nội dung đích và thời gian chuyển đổi đều giống nhau, vì vậy sự khác biệt là số lượng sector tiết lộ.

## **Thêm chuyển đổi slide nâng cao**

Bạn có thể cấu hình thời gian một slide giữ trên màn hình và liệu một cú nhấp chuột có chuyển tiếp buổi trình chiếu hay không. Các phương pháp sau kiểm soát hành vi này:

- [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick) cho phép người xem chuyển tiếp bằng cách nhấp chuột.
- [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) bật chuyển tiếp tự động.
- [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) chỉ định độ trễ trước khi tự động chuyển tiếp, tính bằng millisecond.

Kích hoạt cả chuyển tiếp bằng nhấp chuột và thời gian để cho phép người xem tiếp tục bằng một cú nhấp hoặc chờ bộ hẹn giờ. Để chỉ dùng bộ hẹn giờ, truyền `false` vào [setAdvanceOnClick](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceOnClick). Độ trễ kiểm soát thời điểm buổi trình chiếu chuyển tiếp; nó không đặt thời lượng của hiệu ứng chuyển đổi hình ảnh.

Ví dụ này gán các hiệu ứng khác nhau cho ba slide đầu tiên và bật chuyển tiếp tự động sau 3, 5 và 7 giây, tương ứng. Nhấp chuột cũng có thể chuyển tiếp các slide này. Sử dụng tệp `input.pptx` có ít nhất ba slide.

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
        secondTransition.setAdvanceAfterTime(5000);

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

Để kiểm tra xem chuyển tiếp thời gian có được bật hay không, gọi [getAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getAdvanceAfter). Một độ trễ lưu trữ một mình không chỉ ra rằng bộ hẹn giờ đang hoạt động.

Ví dụ tiếp theo mở tệp đã lưu ở trên, báo cáo mỗi bộ hẹn giờ đã bật, và tắt chuyển tiếp tự động cho các slide có độ trễ lớn hơn hai giây. Nó bật nhấp chuột cho những slide đó và lưu các cài đặt đã cập nhật.

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

Sử dụng [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) để chỉ định độ dài chính xác của một hiệu ứng chuyển đổi tính bằng millisecond. Phương thức [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) của slide tiết lộ các cài đặt này qua [SlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/):

| Phương thức | Mục đích |
| --- | --- |
| [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) | Đặt thời lượng của hiệu ứng chuyển đổi, tính bằng millisecond. |
| [setAdvanceAfterTime](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfterTime) | Đặt độ trễ trước khi slide tự động chuyển tiếp, tính bằng millisecond. Truyền `true` vào [setAdvanceAfter](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setAdvanceAfter) để kích hoạt bộ hẹn giờ này. |
| [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) | Chọn một danh mục tốc độ đã định sẵn từ [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/): Slow, Medium, hoặc Fast. Được sử dụng khi không chỉ định thời lượng chính xác. |

[setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) chỉ kiểm soát hiệu ứng chuyển đổi; nó không quyết định thời gian slide vẫn hiển thị. Cấu hình độ trễ chuyển tiếp tự động riêng biệt. Khi không có thời lượng rõ ràng nào được đặt, Aspose.Slides xác định thời lượng hiệu ứng dựa trên loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed).

<!-- visual-explanation:slide-transition:start -->
[![Các thanh riêng biệt xác định thời lượng chuyển đổi 750‑ms và cài đặt tự động chuyển tiếp 5.000‑ms.](visual-slide-transition-1f705a740cf6.svg)](visual-slide-transition-1f705a740cf6.svg)

*Ví dụ chung này áp dụng cho mỗi slide một chuyển đổi Fade 750‑ms và riêng biệt bật tự động chuyển tiếp sau 5.000 ms. Thời lượng chuyển đổi điều khiển hiệu ứng; chuyển tiếp quyết định thời điểm rời slide. Các thanh này là cài đặt sơ đồ, không phải một thời gian thực đo lường kết hợp.*
<!-- visual-explanation:slide-transition:end -->

### **Áp dụng cùng một thời lượng cho mọi slide**

Để duy trì nhịp độ nhất quán, áp dụng cùng một hiệu ứng và thời lượng chính xác cho mọi slide. Ví dụ này tải `input.pptx`, chọn Fade từ [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/), và đặt thời lượng 750 millisecond cho mỗi chuyển đổi. Nó riêng biệt bật tự động chuyển tiếp sau 5.000 millisecond và tắt chuyển tiếp bằng nhấp chuột, sau đó lưu kết quả dưới dạng PPTX.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("input.pptx");
try {
    for (let i = 0; i < presentation.getSlides().size(); i++) {
        const slide = presentation.getSlides().get_Item(i);
        const transition = slide.getSlideShowTransition();
        transition.setType(slides.TransitionType.Fade);
        transition.setDuration(750);

        // Cấu hình tự động chuyển tiếp độc lập với thời lượng hiệu ứng.
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

Các slide khác nhau có thể sử dụng thời lượng hiệu ứng khác nhau. Ví dụ, sử dụng một chuyển đổi ngắn cho slide tiêu đề và một chuyển đổi lâu hơn cho phần giới thiệu. Ví dụ này đặt 500 millisecond cho slide đầu tiên và 1.200 millisecond cho slide thứ hai. Sử dụng tệp `input.pptx` có ít nhất hai slide.

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

### **Phối hợp chuyển đổi với đầu ra hoạt ảnh**

Khi chuẩn bị một [animated GIF](/slides/vi/nodejs-java/convert-powerpoint-to-animated-gif/), [HTML5 presentation](/slides/vi/nodejs-java/export-to-html5/), hoặc [video](/slides/vi/nodejs-java/convert-powerpoint-to-video/), đặt thời lượng chuyển đổi chính xác trước khi xuất để phù hợp với nhịp độ mong muốn. Ví dụ, sử dụng hiệu ứng fade 600 millisecond giữa các cảnh, và điều chỉnh độ trễ chuyển tiếp của mỗi slide riêng biệt để cho phép thời gian cho phần thuyết minh hoặc nội dung của nó.

Đối với GIF và video, phối hợp tốc độ khung hình đầu ra với thời lượng hiệu ứng: 600 millisecond tương ứng với 18 khung hình ở 30 khung/giây. Trong HTML5, bật chuyển đổi hoạt ảnh trong cài đặt xuất. Kiểm tra các hiệu ứng và tùy chọn thời gian được hỗ trợ của định dạng xuất đã chọn, và xem trước đầu ra để xác nhận đồng bộ.

### **Đọc thời lượng chuyển đổi hiện có**

Gọi [getDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getDuration) trước khi sửa đổi chuyển đổi để xác định liệu có giá trị rõ ràng nào được lưu hay không. Giá trị `-1` có nghĩa là không có thời lượng rõ ràng được đặt; một giá trị không âm chỉ định thời lượng đã lưu tính bằng millisecond. Giá trị chưa đặt không phải là thời lượng phát lại đã tính: Aspose.Slides sử dụng loại chuyển đổi và giá trị [getSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getSpeed) để xác định thời lượng đó. Đặt một loại chuyển đổi có thể khởi tạo thời lượng, vì vậy hãy kiểm tra các cài đặt gốc trước.

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

Chuyển đổi Morph tạo hoạt ảnh cho các thay đổi giữa các đối tượng trên các slide liên tiếp. Để tạo hiệu ứng Morph đơn giản, sao chép một slide, di chuyển hoặc thay đổi kích thước một đối tượng trên bản sao, và áp dụng chuyển đổi Morph cho slide thứ hai. Điều này cho phép chuyển đổi các đối tượng tương ứng để hoạt ảnh giữa trạng thái gốc và đã sửa đổi.

Ví dụ sau tạo một slide có hình chữ nhật chứa văn bản, sao chép slide, và thay đổi vị trí và kích thước của hình chữ nhật trên bản sao. Sau đó chọn Morph từ liệt kê [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/) cho slide thứ hai. Mở tệp đã lưu trong một trình xem bản trình chiếu hỗ trợ Morph để xem hiệu ứng trong buổi trình chiếu.

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

Liệt kê [TransitionMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/) kiểm soát cách Morph khớp và hoạt ảnh nội dung:

- [ByObject](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByObject) coi mỗi hình dạng như một đối tượng toàn bộ.
- [ByWord](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByWord) hoạt ảnh văn bản bằng cách khớp các từ khi có thể.
- [ByChar](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionmorphtype/#ByChar) hoạt ảnh văn bản bằng cách khớp các ký tự khi có thể.

Sử dụng [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) để chọn Morph trước khi truy cập [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue). Giá trị sau đó cung cấp một đối tượng [MorphTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/), mà phương thức [setMorphType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/morphtransition/#setMorphType) chọn chế độ khớp.

Ví dụ này mở bản trình chiếu được tạo trong phần trước và cấu hình slide thứ hai để sử dụng hoạt ảnh Morph dựa trên từ.

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

Một số chuyển đổi cung cấp các tùy chọn bổ sung, như hướng hoặc việc hiệu ứng bắt đầu từ màn hình đen. Các tùy chọn có sẵn phụ thuộc vào chuyển đổi được chọn bằng [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType). Đặt loại trước, sau đó sử dụng đối tượng chuyển đổi thích hợp từ [getValue](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getValue).

Ví dụ sau áp dụng chuyển đổi Cut cho slide đầu tiên của `input.pptx`. Nó gọi [setFromBlack](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/#setFromBlack) qua [OptionalBlackTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/optionalblacktransition/) để chuyển đổi bắt đầu từ màn hình đen.

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

**Tôi có thể kiểm soát tốc độ phát lại của chuyển đổi slide không?**

Đúng. Ưu tiên sử dụng [setDuration](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setDuration) khi bạn cần thời lượng hiệu ứng chính xác tính bằng millisecond. Sử dụng [setSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSpeed) khi một danh mục [TransitionSpeed](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionspeed/) đã định sẵn—Slow, Medium, hoặc Fast—đủ và không cần đặt thời lượng rõ ràng. Các cài đặt này kiểm soát hiệu ứng chuyển đổi độc lập với độ trễ chuyển tiếp tự động.

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại nó không?**

Đúng. Gán âm thanh nhúng bằng [setSound](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSound), truyền StartSound từ liệt kê [TransitionSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitionsoundmode/) vào [setSoundMode](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundMode), và bật [setSoundLoop](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setSoundLoop) với `true`. Âm thanh sẽ lặp lại cho đến sự kiện âm thanh tiếp theo trong buổi trình chiếu.

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Lặp qua bộ sưu tập [getSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getSlides) của bản trình chiếu và gọi [setType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#setType) với cùng một giá trị cho chuyển đổi của mỗi slide. Đặt bất kỳ tùy chọn thời gian và hiệu ứng nào trong cùng một vòng lặp để duy trì hành vi nhất quán trên các slide.

**Làm sao tôi có thể kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Gọi [getType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slideshowtransition/#getType) trên kết quả [getSlideShowTransition](https://reference.aspose.com/slides/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) của slide. Nó trả về một giá trị từ liệt kê [TransitionType](https://reference.aspose.com/slides/nodejs-java/aspose.slides/transitiontype/); None có nghĩa là không có hiệu ứng chuyển đổi nào được áp dụng.