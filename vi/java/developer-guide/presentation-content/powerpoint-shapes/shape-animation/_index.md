---
title: Áp dụng Hoạt ảnh Hình dạng trong Bài thuyết trình bằng Java
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/java/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng hoạt ảnh
- văn bản hoạt ảnh
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bài thuyết trình
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bài thuyết trình PowerPoint với Aspose.Slides cho Java. Nổi bật!"
---
## **Giới thiệu**

Hoạt ảnh là các hiệu ứng hình ảnh có thể áp dụng cho văn bản, hình ảnh, hình dạng, hoặc [biểu đồ](https://docs.aspose.com/slides/vi/java/animated-charts/). Chúng mang lại sức sống cho các bài thuyết trình hoặc các thành phần của chúng. 

## **Tại sao nên sử dụng Hoạt ảnh trong Bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc sự tham gia của khán giả
* làm cho nội dung dễ đọc, hấp thụ hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và các hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis**, và **motion paths**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hoạt ảnh trong không gian tên `Aspose.Slides.Animation`,
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** trong enumeration [EffectType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttype). Những hiệu ứng này về cơ bản tương tự (hoặc tương đương) các hiệu ứng được sử dụng trong PowerPoint.

## **Áp dụng Hoạt ảnh cho TextBox**

Aspose.Slides cho Java cho phép bạn áp dụng hoạt ảnh cho văn bản trong một hình dạng. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape). 
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Lấy một chuỗi hiệu ứng chính.
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape). 
7. Đặt thuộc tính `TextAnimation.BuildType` thành giá trị từ enumeration `BuildType`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape mới với văn bản
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lấy chuỗi chính của slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fade vào shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hoạt ảnh văn bản shape theo các đoạn cấp 1
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Lưu tệp PPTX vào đĩa
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph) đơn lẻ. Xem [**Animated Text**](/slides/vi/java/animated-text/).

{{% /alert %}} 

## **Áp dụng Hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe) trên slide. 
4. Lấy chuỗi hiệu ứng chính.
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe).
6. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation pres = new Presentation();
try {
    // Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của bài thuyết trình
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm picture frame vào slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fly từ trái vào picture frame
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu tệp PPTX vào đĩa
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng Hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape). 
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi hiệu ứng trên hình bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh di chuyển tới `UserPath`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường bóng) cho một shape:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp PPTX.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");

    // Thêm hiệu ứng hoạt ảnh PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, EffectType.PathFootball,
            EffectSubtype.None, EffectTriggerType.AfterPrevious);

    // Tạo một loại "button".
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tạo một chuỗi hiệu ứng cho nút này.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Tạo đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ chỉ di chuyển sau khi nút được nhấp.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Thêm các lệnh di chuyển vì đường dẫn đã tạo hiện đang rỗng.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Ghi tệp PPTX vào đĩa
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy các Hiệu ứng Hoạt ảnh Được Áp dụng cho Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `getEffectsByShape` từ giao diện [ISequence](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh được áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh được áp dụng cho shape trên slide bình thường**

Trước đây, bạn đã học cách thêm hiệu ứng hoạt ảnh vào các shape trong bài thuyết trình PowerPoint. Mã mẫu sau cho bạn thấy cách lấy các hiệu ứng được áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lấy chuỗi hoạt ảnh chính của slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy shape đầu tiên trên slide đầu tiên.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Lấy các hiệu ứng hoạt ảnh được áp dụng cho shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm cả những hiệu ứng kế thừa từ placeholders**

Nếu một shape trên slide bình thường có các placeholder nằm trên slide bố cục và/hoặc slide chủ, và các hiệu ứng hoạt ảnh đã được thêm vào các placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong khi trình chiếu, bao gồm cả những hiệu ứng kế thừa từ các placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape chân trang với văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** đã được áp dụng cho shape.

![Slide shape animation effect](slide-shape-animation.png)

Giả sử nữa rằng hiệu ứng **Split** đã được áp dụng cho placeholder chân trang trên slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Cuối cùng, hiệu ứng **Fly In** đã được áp dụng cho placeholder chân trang trên slide **master**.

![Master shape animation effect](master-shape-animation.png)

Mã mẫu sau cho bạn thấy cách sử dụng phương thức `getBasePlaceholder` từ giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh được áp dụng cho shape chân trang, bao gồm cả những hiệu ứng kế thừa từ các placeholder nằm trên slide bố cục và slide chủ.

```java
Presentation presentation = new Presentation("sample.pptx");

ISlide slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
IShape shape = slide.getShapes().get_Item(0);
IEffect[] shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
IShape layoutShape = shape.getBasePlaceholder();
IEffect[] layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
IShape masterShape = layoutShape.getBasePlaceholder();
IEffect[] masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

System.out.println("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```java
static void printEffects(IEffect[] effects)
{
    for (IEffect effect : effects)
    {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}
```

```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Thay đổi Thuộc tính Thời gian của Hiệu ứng Hoạt ảnh**

Aspose.Slides cho Java cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

![example1_image](shape-animation.png)

Đây là các tương quan giữa Timing trong PowerPoint và các thuộc tính của [Effect.Timing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IEffect#getTiming--):

- Danh sách thả xuống **Start** của PowerPoint Timing tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getTriggerType--). 
- PowerPoint Timing **Duration** tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getDuration--). Thời lượng của một hoạt ảnh (tính bằng giây) là tổng thời gian mà hoạt ảnh hoàn thành một chu kỳ. 
- PowerPoint Timing **Delay** tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getTriggerDelayTime--). 

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính của [Effect.Timing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IEffect#getTiming--) mà bạn cần. 
3. Lưu tệp PPTX đã chỉnh sửa.

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lấy hiệu ứng đầu tiên của chuỗi chính.
    IEffect effect = sequence.get_Item(0);

    // Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấp chuột
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Thay đổi Duration của hiệu ứng
    effect.getTiming().setDuration(3f);

    // Thay đổi TriggerDelayTime của hiệu ứng
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Lưu tệp PPTX vào đĩa
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Âm thanh cho Hiệu ứng Hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) 
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Thêm Âm thanh cho Hiệu ứng Hoạt ảnh**

Mã Java này cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Thêm âm thanh vào bộ sưu tập âm thanh của bài thuyết trình
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy chuỗi chính của slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = sequence.get_Item(0);

    // Kiểm tra hiệu ứng có "Không âm thanh" không
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Thêm âm thanh cho hiệu ứng đầu tiên
        firstEffect.setSound(effectSound);
    }

    // Lấy chuỗi tương tác đầu tiên của slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Đặt cờ "Stop previous sound" cho hiệu ứng
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Ghi tệp PPTX vào đĩa
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Trích xuất Âm thanh của Hiệu ứng Hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/) .
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Lấy chuỗi hiệu ứng chính. 
4. Trích xuất [setSound(IAudio value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) được nhúng vào mỗi hiệu ứng hoạt ảnh. 

Mã Java này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation presentation = new Presentation("EffectSound.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    // Lấy chuỗi chính của slide.
    ISequence sequence = slide.getTimeline().getMainSequence();

    for (IEffect effect : sequence)
    {
        if (effect.getSound() == null)
            continue;

        // Trích xuất âm thanh của hiệu ứng thành mảng byte
        byte[] audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) presentation.dispose();
}
```

## **Sau Hoạt ảnh**

Aspose.Slides cho Java cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

![example1_image](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint Effect tương ứng với các thuộc tính sau: 

- Thuộc tính [setAfterAnimationType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) mô tả kiểu After animation :
  * PowerPoint **More Colors** tương ứng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color);
  * PowerPoint **Don't Dim** tương ứng với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#DoNotDim) (kiểu After animation mặc định);
  * PowerPoint **Hide After Animation** tương ứng với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);
  * PowerPoint **Hide on Next Mouse Click** tương ứng với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Thuộc tính [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) định nghĩa định dạng màu sau hoạt ảnh. Thuộc tính này hoạt động cùng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color). Nếu bạn đổi kiểu sang khác, màu sau hoạt ảnh sẽ bị xóa.

Mã Java này cho bạn thấy cách thay đổi một hiệu ứng after animation:

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi kiểu after animation thành Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Đặt màu giảm sáng after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Ghi tệp PPTX vào đĩa
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh Văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) mô tả kiểu animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh theo:
  - Tất cả cùng một lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#AllAtOnce) kiểu)
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#ByWord) kiểu)
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#ByLetter) kiểu)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ tỷ lệ phần trăm thời gian hiệu ứng. Giá trị âm chỉ thời gian trễ tính bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt thuộc tính [setBuildType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextanimation/#setBuildType-int-) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/buildtype/#AsOneObject) để tắt chế độ hoạt ảnh *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) và [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Lưu tệp PPTX đã chỉnh sửa.

```java
// Khởi tạo một lớp Presentation đại diện cho một tệp bài thuyết trình.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi kiểu hoạt ảnh văn bản của hiệu ứng thành "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Thay đổi kiểu Animate text của hiệu ứng thành "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Đặt độ trễ giữa các từ là 20% thời lượng hiệu ứng
    firstEffect.setDelayBetweenTextParts(20f);

    // Ghi tệp PPTX vào đĩa
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**Làm sao để đảm bảo hoạt ảnh được giữ nguyên khi xuất bản bài thuyết trình lên web?**

[Export to HTML5](/slides/vi/java/export-to-html5/) và bật [các tùy chọn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/) chịu trách nhiệm cho các hoạt ảnh [shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [transition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có.

**Thay đổi thứ tự z (thứ tự lớp) của các shape ảnh hưởng như thế nào đến hoạt ảnh?**

Hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và loại xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getZOrderPosition--) xác định phần nào che phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic tương tự.)

**Có hạn chế nào khi chuyển đổi hoạt ảnh sang video cho một số hiệu ứng không?**

Nhìn chung, [các hoạt ảnh được hỗ trợ](/slides/vi/java/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc một số hiệu ứng cụ thể có thể được hiển thị khác. Bạn nên kiểm tra với các hiệu ứng bạn dùng và với phiên bản thư viện.