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
- chuyển đổi Morph
- loại chuyển đổi
- hiệu ứng chuyển đổi
- PowerPoint
- OpenDocument
- bài thuyết trình
- Node.js
- JavaScript
- Aspose.Slides
description: "Tùy chỉnh chuyển đổi slide trong JavaScript với Aspose.Slides cho Node.js qua Java, với hướng dẫn từng bước cho các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý chuyển đổi slide trong bài thuyết trình bằng Aspose.Slides. Nó chỉ ra cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như tiến tới khi nhấn hoặc sau một khoảng thời gian nhất định, kiểm tra và tắt việc tiến tới tự động, sử dụng chuyển đổi Morph và các loại của nó, và thiết lập các tùy chọn hiệu ứng chuyển đổi. Các ví dụ minh họa cách tải hoặc tạo một bài thuyết trình, sửa đổi cài đặt chuyển đổi cho các slide được chọn và lưu kết quả thành tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide và kiểm tra chuyển đổi hiện đang được đặt trên một slide.

## **Thêm Chuyển Đổi Slide**
Để tạo một hiệu ứng chuyển đổi slide đơn giản, làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
2. Áp dụng một loại Chuyển Đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides cho Node.js qua Java cung cấp thông qua enum TransitionType.
3. Ghi tệp bản trình chiếu đã sửa đổi.

```javascript
// Khởi tạo lớp Presentation để tải tệp trình chiếu nguồn
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Áp dụng chuyển đổi kiểu circle trên slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Áp dụng chuyển đổi kiểu comb trên slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Ghi trình chiếu ra đĩa
    presentation.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Chuyển Đổi Slide Nâng Cao**
Trong phần trên, chúng ta chỉ áp dụng một hiệu ứng chuyển đổi đơn giản trên slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản đó tốt hơn và được kiểm soát, vui lòng làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation) .
2. Áp dụng một loại Chuyển Đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides cho Node.js qua Java.
3. Bạn cũng có thể đặt chuyển đổi để Tiến Tới Khi Nhấn, sau một khoảng thời gian cụ thể hoặc cả hai.
4. Nếu chuyển đổi slide được bật để Tiến Tới Khi Nhấn, chuyển đổi sẽ chỉ tiến tới khi người dùng nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được thiết lập, chuyển đổi sẽ tự động tiến tới sau thời gian đã chỉ định.
5. Ghi bản trình chiếu đã sửa đổi dưới dạng tệp bản trình chiếu.

```javascript
// Khởi tạo lớp Presentation đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("BetterSlideTransitions.pptx");
try {
    // Áp dụng chuyển đổi kiểu circle trên slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Circle);
    // Đặt thời gian chuyển đổi là 3 giây
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);
    // Áp dụng chuyển đổi kiểu comb trên slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Comb);
    // Đặt thời gian chuyển đổi là 5 giây
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);
    // Áp dụng chuyển đổi kiểu zoom trên slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(aspose.slides.TransitionType.Zoom);
    // Đặt thời gian chuyển đổi là 7 giây
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);
    // Ghi trình chiếu ra đĩa
    pres.save("SampleTransition_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Chuyển Đổi Morph**
{{% alert color="primary" %}} 

Aspose.Slides cho Node.js qua Java hiện hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/MorphTransition). Đây là chuyển đổi Morph mới được giới thiệu trong PowerPoint 2019.

{{% /alert %}} 

Chuyển đổi Morph cho phép bạn hoạt ảnh di chuyển mượt mà từ slide này sang slide kế tiếp. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến vị trí khác.

Đoạn mã sau cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bản trình chiếu và đặt một chuyển đổi dạng [morph type](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TransitionType) cho slide thứ hai.

```javascript
var presentation = new aspose.slides.Presentation();
try {
    var autoshape = presentation.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");
    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));
    var shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Các Loại Chuyển Đổi Morph**
Enum mới [TransitionMorphType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/TransitionMorphType) đã được thêm. Nó đại diện cho các loại chuyển đổi slide Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện khi xem các hình dạng như các đối tượng không thể chia nhỏ.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ khi có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự khi có thể.

Đoạn mã sau cho bạn thấy cách đặt chuyển đổi Morph cho slide và thay đổi loại Morph:

```javascript
var presentation = new aspose.slides.Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Morph);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setMorphType(aspose.slides.TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Hiệu Ứng Chuyển Đổi**
Aspose.Slides cho Node.js qua Java hỗ trợ thiết lập các hiệu ứng chuyển đổi như chuyển từ màu đen, từ trái, từ phải, v.v. Để đặt Hiệu Ứng Chuyển Đổi, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation) .
- Lấy tham chiếu của slide.
- Thiết lập hiệu ứng chuyển đổi.
- Ghi bản trình chiếu dưới dạng tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

```javascript
// Tạo một thể hiện của lớp Presentation
var presentation = new aspose.slides.Presentation("AccessSlides.pptx");
try {
    // Đặt hiệu ứng
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(aspose.slides.TransitionType.Cut);
    presentation.getSlides().get_Item(0).getSlideShowTransition().getValue().setFromBlack(true);
    // Ghi trình chiếu ra đĩa
    presentation.save("SetTransitionEffects_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể điều chỉnh tốc độ phát của chuyển đổi slide không?**

Có. Thiết lập [speed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setspeed/) của chuyển đổi bằng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/transitionspeed/) (ví dụ: chậm/trung bình/nhanh).

**Tôi có thể đính kèm âm thanh vào một chuyển đổi và lặp lại không?**

Có. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [setSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setsound/), [setSoundMode](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setsoundmode/), [setSoundLoop](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setsoundloop/), cùng các siêu dữ liệu như [setSoundIsBuiltIn](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setsoundisbuiltin/) và [setSoundName](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/setsoundname/)).

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của mỗi slide; vì chuyển đổi được lưu riêng cho mỗi slide, việc áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả đồng nhất.

**Làm sao tôi có thể kiểm tra chuyển đổi nào đang được đặt trên một slide?**

Kiểm tra [cài đặt chuyển đổi](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/baseslide/#getSlideShowTransition) của slide và đọc [loại chuyển đổi](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/slideshowtransition/gettype/); giá trị đó cho biết chính xác hiệu ứng nào đang được áp dụng.