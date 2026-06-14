---
title: Quản lý chuyển đổi slide trong bản trình chiếu trên Android
linktitle: Chuyển đổi slide
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
- bản trình chiếu
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tùy chỉnh chuyển đổi slide trong Aspose.Slides cho Android qua Java, với hướng dẫn từng bước cho bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý chuyển đổi slide trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như tiến lên khi nhấp chuột hoặc sau một thời gian nhất định, kiểm tra và tắt việc tự động tiến lên, sử dụng chuyển đổi Morph và các loại của nó, và đặt các tùy chọn hiệu ứng chuyển đổi. Các ví dụ minh họa cách tải hoặc tạo một bản trình chiếu, sửa đổi cài đặt chuyển đổi cho các slide được chọn, và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide, và kiểm tra chuyển đổi hiện đang được đặt trên một slide.

## **Thêm chuyển đổi slide**
Để tạo hiệu ứng chuyển đổi slide đơn giản, hãy làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
2. Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for Android via Java cung cấp thông qua enum TransitionType.
3. Ghi tệp bản trình chiếu đã chỉnh sửa.

```java
// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Áp dụng chuyển đổi kiểu vòng tròn cho slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Áp dụng chuyển đổi kiểu chải cho slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Ghi bản trình chiếu ra đĩa
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm chuyển đổi slide nâng cao**
Trong phần trên, chúng ta chỉ áp dụng một hiệu ứng chuyển đổi đơn giản cho slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản đó trở nên tốt hơn và kiểm soát được, hãy làm theo các bước dưới đây:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation).
2. Áp dụng một Slide Transition Type cho slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for Android via Java cung cấp.
3. Bạn cũng có thể đặt chuyển đổi để Tiến lên Khi Nhấp, sau một khoảng thời gian cụ thể hoặc cả hai.
4. Nếu chuyển đổi slide được bật để Tiến lên Khi Nhấp, chuyển đổi sẽ chỉ tiến lên khi người dùng nhấp chuột. Ngoài ra, nếu thuộc tính Advance After Time được đặt, chuyển đổi sẽ tự động tiến lên sau thời gian đã chỉ định.
5. Ghi bản trình chiếu đã chỉnh sửa thành một tệp bản trình chiếu.

```java
// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Áp dụng chuyển đổi kiểu vòng tròn cho slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Đặt thời gian chuyển đổi là 3 giây
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Áp dụng chuyển đổi kiểu chải cho slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Đặt thời gian chuyển đổi là 5 giây
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Áp dụng chuyển đổi kiểu thu phóng cho slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Đặt thời gian chuyển đổi là 7 giây
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Ghi bản trình chiếu ra đĩa
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Chuyển đổi Morph**
{{% alert color="primary" %}} 

Aspose.Slides for Android via Java hiện hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IMorphTransition). Đây là chuyển đổi morph mới được giới thiệu trong PowerPoint 2019.

{{% /alert %}} 

Chuyển đổi Morph cho phép bạn tạo hoạt ảnh di chuyển mượt mà từ slide này sang slide tiếp theo. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph một cách hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến vị trí khác.

Đoạn mã sau cho bạn thấy cách thêm một bản sao của slide có một số văn bản vào bản trình chiếu và đặt một chuyển đổi [morph type](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TransitionType) cho slide thứ hai.

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

## **Các loại chuyển đổi Morph**
Enum mới [TransitionMorphType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/TransitionMorphType) đã được thêm vào. Nó đại diện cho các loại chuyển đổi slide Morph khác nhau.

Enum TransitionMorphType có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện xét các hình dạng như các đối tượng không thể chia nhỏ.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ khi có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự khi có thể.

Đoạn mã sau cho bạn thấy cách đặt chuyển đổi morph cho slide và thay đổi loại morph:

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

## **Đặt hiệu ứng chuyển đổi**
Aspose.Slides for Android via Java hỗ trợ thiết lập các hiệu ứng chuyển đổi như từ màu đen, từ trái, từ phải, v.v. Để đặt hiệu ứng chuyển đổi, vui lòng làm theo các bước dưới đây:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
- Lấy tham chiếu của slide.
- Thiết lập hiệu ứng chuyển đổi.
- Ghi bản trình chiếu thành tệp [PPTX](https://docs.fileformat.com/presentation/pptx/) .

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

```java
// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Đặt hiệu ứng
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Ghi bản trình chiếu ra đĩa
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **FAQ**

**Tôi có thể kiểm soát tốc độ phát lại của chuyển đổi slide không?**

Có. Đặt [speed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) của chuyển đổi bằng cách sử dụng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/transitionspeed/) (ví dụ: chậm/trung bình/nhanh).

**Tôi có thể đính kèm âm thanh vào chuyển đổi và lặp lại nó không?**

Có. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và vòng lặp (ví dụ: [setSound](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), cộng với siêu dữ liệu như [setSoundIsBuiltIn](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) và [setSoundName](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

**Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?**

Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của mỗi slide; chuyển đổi được lưu riêng cho từng slide, vì vậy việc áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả nhất quán.

**Làm sao tôi có thể kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?**

Kiểm tra [cài đặt chuyển đổi](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) của slide và đọc [loại chuyển đổi](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/slideshowtransition/#setType-int-); giá trị đó cho biết chính xác hiệu ứng nào đang được áp dụng.