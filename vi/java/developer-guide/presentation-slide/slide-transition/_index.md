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
description: "Khám phá cách tùy chỉnh chuyển đổi slide trong Aspose.Slides cho Java, với hướng dẫn từng bước cho các bản trình chiếu PowerPoint và OpenDocument."
---
## **Tổng quan**

Bài viết này giải thích cách quản lý chuyển đổi slide trong bản trình chiếu bằng Aspose.Slides. Nó cho thấy cách áp dụng các loại chuyển đổi cho slide, cấu hình hành vi chuyển đổi như chuyển tiếp khi nhấn chuột hoặc sau một khoảng thời gian xác định, kiểm tra và tắt chuyển tiếp tự động, sử dụng chuyển đổi Morph và các loại của nó, và thiết lập các tùy chọn hiệu ứng chuyển đổi. Các ví dụ minh họa cách tải hoặc tạo một bản trình chiếu, sửa đổi cài đặt chuyển đổi cho các slide đã chọn, và lưu kết quả dưới dạng tệp PPTX. Bài viết cũng trả lời các câu hỏi thường gặp về tốc độ chuyển đổi, âm thanh chuyển đổi, áp dụng cùng một chuyển đổi cho nhiều slide, và kiểm tra chuyển đổi hiện đang được đặt trên một slide.

## **Thêm Chuyển Đổi Slide**
Để tạo hiệu ứng chuyển đổi slide đơn giản, thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Áp dụng một Loại Chuyển Đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for Java cung cấp thông qua enum TransitionType.
3. Ghi tệp bản trình chiếu đã sửa đổi.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation để tải tệp bản trình chiếu nguồn
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Áp dụng chuyển đổi kiểu vòng tròn cho slide 1
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Áp dụng chuyển đổi kiểu comb cho slide 2
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // Lưu bản trình chiếu vào đĩa
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thêm Chuyển Đổi Slide Nâng Cao**
Trong phần trên, chúng ta chỉ áp dụng một hiệu ứng chuyển đổi đơn giản trên slide. Bây giờ, để làm cho hiệu ứng chuyển đổi đơn giản đó tốt hơn và được kiểm soát, hãy thực hiện các bước sau:

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation).
2. Áp dụng một Loại Chuyển Đổi Slide trên slide từ một trong các hiệu ứng chuyển đổi do Aspose.Slides for Java cung cấp.
3. Bạn cũng có thể đặt chuyển đổi thành Tiến Tiếp Khi Nhấp, sau một khoảng thời gian cụ thể hoặc cả hai.
4. Nếu chuyển đổi slide được bật Tiến Tiếp Khi Nhấp, chuyển đổi sẽ chỉ tiến tiếp khi người dùng nhấp chuột. Hơn nữa, nếu thuộc tính Advance After Time được đặt, chuyển đổi sẽ tự động tiến tiếp sau thời gian đã chỉ định.
5. Ghi bản trình chiếu đã sửa đổi thành một tệp bản trình chiếu.

```java
import com.aspose.slides.*;

// Khởi tạo lớp Presentation đại diện cho một tệp bản trình chiếu
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // Áp dụng chuyển đổi kiểu vòng tròn cho slide 1
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // Đặt thời gian chuyển đổi là 3 giây
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // Áp dụng chuyển đổi kiểu comb cho slide 2
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // Đặt thời gian chuyển đổi là 5 giây
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // Áp dụng chuyển đổi kiểu zoom cho slide 3
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // Đặt thời gian chuyển đổi là 7 giây
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // Ghi bản trình chiếu vào đĩa
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **Chuyển Đổi Morph**
{{% alert color="info" %}} 
Aspose.Slides cho Java hiện hỗ trợ [Morph Transition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IMorphTransition). Chúng đại diện cho chuyển đổi morph mới được giới thiệu trong PowerPoint 2019.
{{% /alert %}} 

Chuyển đổi Morph cho phép bạn tạo hoạt ảnh chuyển động mượt mà từ một slide sang slide tiếp theo. Bài viết này mô tả khái niệm và cách sử dụng chuyển đổi Morph. Để sử dụng chuyển đổi Morph hiệu quả, bạn cần có hai slide có ít nhất một đối tượng chung. Cách dễ nhất là sao chép slide và sau đó di chuyển đối tượng trên slide thứ hai đến một vị trí khác.

Đoạn mã sau cho thấy cách thêm một bản sao của slide có một số văn bản vào bản trình chiếu và đặt một chuyển đổi [morph type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TransitionType) cho slide thứ hai.

```java
import com.aspose.slides.*;

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

## **Các Loại Chuyển Đổi Morph**
Enum [TransitionMorphType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/TransitionMorphType) mới đã được thêm. Nó đại diện cho các loại chuyển đổi slide Morph khác nhau.

TransitionMorphType enum có ba thành viên:

- ByObject: Chuyển đổi Morph sẽ được thực hiện khi xem các hình dạng như các đối tượng không thể chia nhỏ.
- ByWord: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo từ khi có thể.
- ByChar: Chuyển đổi Morph sẽ được thực hiện bằng cách chuyển văn bản theo ký tự khi có thể.

Đoạn mã sau cho thấy cách đặt chuyển đổi morph cho slide và thay đổi loại morph:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Đặt Hiệu Ứng Chuyển Đổi**
Aspose.Slides cho Java hỗ trợ thiết lập các hiệu ứng chuyển đổi như, từ màu đen, từ trái, từ phải, v.v. Để đặt Hiệu Ứng Chuyển Đổi, vui lòng thực hiện các bước sau:

- Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
- Lấy tham chiếu của slide.
- Thiết lập hiệu ứng chuyển đổi.
- Ghi bản trình chiếu dưới dạng tệp [PPTX ](https://docs.fileformat.com/presentation/pptx/)file.

Trong ví dụ dưới đây, chúng tôi đã đặt các hiệu ứng chuyển đổi.

```java
import com.aspose.slides.*;

// Tạo một thể hiện của lớp Presentation
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // Đặt hiệu ứng
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // Ghi bản trình chiếu vào đĩa
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Câu hỏi thường gặp**

### Tôi có thể kiểm soát tốc độ phát lại của một chuyển đổi slide không?
Đúng. Đặt [speed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSpeed-int-) của chuyển đổi bằng cách sử dụng cài đặt [TransitionSpeed](https://reference.aspose.com/slides/vi/java/com.aspose.slides/transitionspeed/) (ví dụ: slow/medium/fast).

### Tôi có thể đính kèm âm thanh vào một chuyển đổi và lặp lại nó không?
Đúng. Bạn có thể nhúng âm thanh cho chuyển đổi và kiểm soát hành vi qua các cài đặt như chế độ âm thanh và lặp lại (ví dụ: [setSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-), [setSoundMode](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundMode-int-), [setSoundLoop](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-), cộng với siêu dữ liệu như [setSoundIsBuiltIn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) và [setSoundName](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)).

### Cách nhanh nhất để áp dụng cùng một chuyển đổi cho mọi slide là gì?
Cấu hình loại chuyển đổi mong muốn trên cài đặt chuyển đổi của từng slide; các chuyển đổi được lưu theo từng slide, vì vậy việc áp dụng cùng một loại cho tất cả các slide sẽ cho kết quả đồng nhất.

### Làm sao tôi có thể kiểm tra chuyển đổi nào hiện đang được đặt trên một slide?
Kiểm tra [transition settings](https://reference.aspose.com/slides/vi/java/com.aspose.slides/baseslide/#getSlideShowTransition--) của slide và đọc [transition type](https://reference.aspose.com/slides/vi/java/com.aspose.slides/slideshowtransition/#setType-int-); giá trị đó cho biết chính xác hiệu ứng nào đã được áp dụng.