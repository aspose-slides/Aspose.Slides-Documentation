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
description: "Khám phá cách tùy chỉnh chuyển tiếp slide trong Aspose.Slides cho Java, với hướng dẫn chi tiết từng bước cho các bài thuyết trình PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý các chuyển tiếp slide trong bài thuyết trình bằng Aspose.Slides. Nó chỉ ra cách áp dụng các loại chuyển tiếp cho slide, cấu hình hành vi chuyển tiếp như chuyển tiếp khi nhấp chuột hoặc sau một khoảng thời gian nhất định, kiểm tra và tắt việc tự động chuyển tiếp, sử dụng chuyển tiếp Morph và các loại của nó, và thiết lập các tùy chọn hiệu ứng chuyển tiếp. Các ví dụ minh họa cách tải hoặc tạo một bài thuyết trình, chỉnh sửa cài đặt chuyển tiếp cho các slide đã chọn, và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi phổ biến về tốc độ chuyển tiếp, âm thanh chuyển tiếp, áp dụng cùng một chuyển tiếp cho nhiều slide, và kiểm tra chuyển tiếp hiện đang được đặt trên một slide.

## **Thêm chuyển tiếp slide**
Để tạo một hiệu ứng chuyển tiếp slide đơn giản, làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) class.
2. Áp dụng một loại Slide Transition Type trên slide từ một trong các hiệu ứng chuyển tiếp do Aspose.Slides for Java cung cấp thông qua TransitionType enum
3. Ghi tệp bài thuyết trình đã sửa đổi.

```java
// Khởi tạo lớp Presentation để tải tệp bài thuyết trình nguồn
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Áp dụng chuyển tiếp kiểu vòng tròn cho slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Áp dụng chuyển tiếp kiểu lược cho slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Ghi bài thuyết trình ra đĩa
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm chuyển tiếp slide nâng cao**
Trong phần trên, chúng ta chỉ áp dụng một hiệu ứng chuyển tiếp đơn giản trên slide. Bây giờ, để làm cho hiệu ứng chuyển tiếp đơn giản đó tốt hơn và được kiểm soát, hãy làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation) class.
2. Áp dụng một loại Slide Transition Type trên slide từ một trong các hiệu ứng chuyển tiếp do Aspose.Slides for Java cung cấp
3. Bạn cũng có thể đặt chuyển tiếp để Advance On Click, sau một khoảng thời gian cụ thể hoặc cả hai.
4. Nếu chuyển tiếp slide được bật để Advance On Click, chuyển tiếp sẽ chỉ tiến lên khi ai đó nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được đặt, chuyển tiếp sẽ tự động tiến lên sau khoảng thời gian đã chỉ định.
5. Ghi bài thuyết trình đã sửa đổi dưới dạng tệp bài thuyết trình.

```java
// Khởi tạo lớp Presentation đại diện cho tệp bài thuyết trình
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Áp dụng chuyển tiếp kiểu vòng tròn cho slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Đặt thời gian chuyển tiếp là 3 giây
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Áp dụng chuyển tiếp kiểu lược cho slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Đặt thời gian chuyển tiếp là 5 giây
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Áp dụng chuyển tiếp kiểu thu phóng cho slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Đặt thời gian chuyển tiếp là 7 giây
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Ghi bài thuyết trình ra đĩa
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Chuyển tiếp Morph**
{{% alert color="primary" %}} 
Aspose.Slides for Java hiện đã hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMorphTransition). Chúng đại diện cho chuyển tiếp morph mới được giới thiệu trong PowerPoint 2019.
{{% /alert %}} 

Chuyển tiếp Morph cho phép bạn tạo hoạt ảnh di chuyển mượt mà từ slide này sang slide tiếp theo. Bài viết này mô tả khái niệm và cách sử dụng chuyển tiếp Morph. Để sử dụng chuyển tiếp Morph một cách hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến vị trí khác.

Đoạn mã sau đây cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bài thuyết trình và đặt chuyển tiếp loại [morph type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TransitionType) cho slide thứ hai.

```java
Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Các loại chuyển tiếp Morph**
Enum mới [TransitionMorphType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TransitionMorphType) đã được thêm. Nó đại diện cho các loại chuyển tiếp slide Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển tiếp Morph sẽ được thực hiện bằng cách xem các hình dạng như các đối tượng không thể chia tách.
- ByWord: Chuyển tiếp Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ khi có thể.
- ByChar: Chuyển tiếp Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự khi có thể.

Đoạn mã sau đây cho bạn thấy cách đặt chuyển tiếp morph cho slide và thay đổi loại morph:

```java
Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt hiệu ứng chuyển tiếp**
Aspose.Slides for Java hỗ trợ thiết lập các hiệu ứng chuyển tiếp như, từ đen, từ trái, từ phải, v.v. Để đặt hiệu ứng chuyển tiếp, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation) class.
- Lấy tham chiếu của slide.
- Thiết lập hiệu ứng chuyển tiếp.
- Ghi bài thuyết trình dưới dạng tệp [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển tiếp.

```java
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Đặt hiệu ứng
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Ghi bài thuyết trình ra đĩa
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

**Tôi có thể kiểm soát tốc độ phát của chuyển tiếp slide không?**

Có. Đặt [speed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) của chuyển tiếp bằng cách sử dụng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionspeed/) (ví dụ: chậm/trung bình/nhanh).

**Tôi có thể đính kèm âm thanh vào chuyển tiếp và làm cho nó lặp lại không?**

Có. Bạn có thể nhúng âm thanh cho chuyển tiếp và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [setSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), cùng với siêu dữ liệu như [setSoundIsBuiltIn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) và [setSoundName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Cách nhanh nhất để áp dụng cùng một chuyển tiếp cho mọi slide là gì?**

Cấu hình loại chuyển tiếp mong muốn trên cài đặt chuyển tiếp của từng slide; chuyển tiếp được lưu riêng cho mỗi slide, vì vậy áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả nhất quán.

**Làm thế nào tôi có thể kiểm tra chuyển tiếp nào hiện đang được đặt trên một slide?**

Kiểm tra [cài đặt chuyển tiếp](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/#getSlideShowTransition--) của slide và đọc [loại chuyển tiếp](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setType-int-); giá trị đó cho bạn biết chính xác hiệu ứng nào đã được áp dụng.