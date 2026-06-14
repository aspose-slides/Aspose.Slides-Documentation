---
title: Áp dụng Hoạt ảnh Hình dạng trong Bài thuyết trình trên Android
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/androidjava/shape-animation/
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
- Android
- Java
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bài thuyết trình PowerPoint với Aspose.Slides cho Android qua Java. Nổi bật!"
---
## **Giới thiệu**

Animations là các hiệu ứng hình ảnh có thể áp dụng cho văn bản, hình ảnh, hình dạng, hoặc [charts](https://docs.aspose.com/slides/vi/androidjava/animated-charts/). Chúng mang lại sức sống cho bài thuyết trình hoặc các thành phần của nó.

## **Tại sao nên sử dụng hoạt ảnh trong bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự hứng thú hoặc tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và các hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis**, và **motion paths**.

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hoạt ảnh trong namespace `Aspose.Slides.Animation`,
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** trong enumeration [EffectType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effecttype). Các hiệu ứng này về cơ bản là các hiệu ứng tương tự (hoặc tương đương) được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides for Android via Java cho phép bạn áp dụng hoạt ảnh cho văn bản trong một shape.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape).
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).
5. Lấy chuỗi chính của các hiệu ứng.
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape).
7. Đặt thuộc tính `TextAnimation.BuildType` thành giá trị từ enumeration `BuildType`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Java sau cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```java
// Khởi tạo lớp trình chiếu đại diện cho tệp trình chiếu.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape mới với văn bản
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lấy chuỗi chính của slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fade cho shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hoạt ảnh văn bản shape theo các đoạn mức 1
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Lưu tệp PPTX lên đĩa
    pres.save(path + "AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph] đơn lẻ. Xem [**Animated Text**](/slides/vi/androidjava/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe) trên slide.
4. Lấy chuỗi chính của các hiệu ứng.
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/pictureframe).
6. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Java sau cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```java
// Khởi tạo lớp trình chiếu đại diện cho tệp trình chiếu.
Presentation pres = new Presentation();
try {
    // Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của trình chiếu
    IPPImage picture;
    IImage image = Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Thêm khung ảnh vào slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fly từ trái vào khung ảnh
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu tệp PPTX lên đĩa
    pres.save(path + "AnimImage_out.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape).
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/iautoshape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi các hiệu ứng trên shape bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh để di chuyển tới `UserPath`.
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã Java sau cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường bóng đá) cho một shape:

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

    // Tạo một loại "button" nào đó.
    IShape shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Bevel, 10, 10, 20, 20);

    // Tạo một chuỗi hiệu ứng cho nút này.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ di chuyển chỉ sau khi nút được nhấp.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Thêm các lệnh di chuyển vì đường dẫn đã tạo hiện vẫn rỗng.
    IMotionEffect motionBhv = ((IMotionEffect)fxUserPath.getBehaviors().get_Item(0));

    Point2D.Float[] pts = new Point2D.Float[1];
    pts[0] = new Point2D.Float(0.076f, 0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, true);
    pts[0] = new Point2D.Float(-0.076f, -0.59f);
    motionBhv.getPath().add(MotionCommandPathType.LineTo, pts, MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(MotionCommandPathType.End, null, MotionPathPointsType.Auto, false);

     // Ghi tệp PPTX lên đĩa
    pres.save("AnimExample_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `getEffectsByShape` từ interface [ISequence](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho một shape.

**Ví dụ 1: Lấy hiệu ứng hoạt ảnh đã áp dụng cho shape trên slide bình thường**

Trước đây, bạn đã học cách thêm hiệu ứng hoạt ảnh vào các shape trong bài thuyết trình PowerPoint. Đoạn mã mẫu dưới đây cho bạn thấy cách lấy các hiệu ứng đã áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```java
Presentation presentation = new Presentation("AnimExample_out.pptx");
try {
    ISlide firstSlide = presentation.getSlides().get_Item(0);

    // Lấy chuỗi hoạt ảnh chính của slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy shape đầu tiên trên slide đầu tiên.
    IShape shape = firstSlide.getShapes().get_Item(0);

    // Lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape.
    IEffect[] shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0)
        System.out.println("The shape " + shape.getName() + " has " + shapeEffects.length + " animation effects.");
} finally {
    if (presentation != null) presentation.dispose();
}
```

**Ví dụ 2: Lấy tất cả hiệu ứng hoạt ảnh, bao gồm những hiệu ứng được kế thừa từ placeholders**

Nếu một shape trên slide bình thường có các placeholder nằm trên slide bố cục và/hoặc slide chủ, và các hiệu ứng hoạt ảnh đã được thêm vào những placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong buổi trình chiếu, bao gồm cả những hiệu ứng được kế thừa từ các placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** được áp dụng cho shape.

![Hiệu ứng hoạt ảnh shape trên slide](slide-shape-animation.png)

Giả sử thêm hiệu ứng **Split** được áp dụng cho placeholder footer trên slide **layout**.

![Hiệu ứng hoạt ảnh shape layout](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** được áp dụng cho placeholder footer trên slide **master**.

![Hiệu ứng hoạt ảnh shape master](master-shape-animation.png)

Đoạn mã mẫu dưới đây cho bạn thấy cách sử dụng phương thức `getBasePlaceholder` từ interface [IShape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm những hiệu ứng được kế thừa từ các placeholder nằm trên slide bố cục và slide chủ.

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

Output:
```text
Main sequence of shape effects:
Fly Bottom
Split VerticalIn
RandomBars Horizontal
```

## **Thay đổi thuộc tính thời gian của hiệu ứng hoạt ảnh**

Aspose.Slides for Android via Java cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Timing trong Microsoft PowerPoint:

![Cửa sổ Animation Timing trong Microsoft PowerPoint](shape-animation.png)

Đây là các tương quan giữa PowerPoint Timing và các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IEffect#getTiming--) :

- Danh sách thả xuống PowerPoint Timing **Start** tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITiming#getTriggerType--) .
- PowerPoint Timing **Duration** tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITiming#getDuration--) . Thời lượng của một hoạt ảnh (theo giây) là tổng thời gian mà hoạt ảnh cần để hoàn thành một chu kỳ.
- PowerPoint Timing **Delay** tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ITiming#getTriggerDelayTime--) .

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/IEffect#getTiming--) mà bạn cần.
3. Lưu tệp PPTX đã chỉnh sửa.

Đoạn mã Java sau minh họa thao tác:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Lấy hiệu ứng đầu tiên của chuỗi chính.
    IEffect effect = sequence.get_Item(0);

    // Thay đổi TriggerType của hiệu ứng để bắt đầu khi click
    effect.getTiming().setTriggerType(EffectTriggerType.OnClick);

    // Thay đổi Duration của hiệu ứng
    effect.getTiming().setDuration(3f);

    // Thay đổi TriggerDelayTime của hiệu ứng
    effect.getTiming().setTriggerDelayTime(0.5f);

    // Lưu tệp PPTX lên đĩa
    pres.save("AnimExample_changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Âm thanh hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Đoạn mã Java sau cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```java
Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Thêm âm thanh vào bộ sưu tập âm thanh của trình chiếu
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy chuỗi chính của slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = sequence.get_Item(0);

    // Kiểm tra hiệu ứng cho "No Sound"
    if (!firstEffect.getStopPreviousSound() && firstEffect.getSound() == null)
    {
        // Thêm âm thanh cho hiệu ứng đầu tiên
        firstEffect.setSound(effectSound);
    }

    // Lấy chuỗi tương tác đầu tiên của slide.
    ISequence interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);

    // Đặt cờ "Stop previous sound" cho hiệu ứng
    interactiveSequence.get_Item(0).setStopPreviousSound(true);

    // Ghi tệp PPTX lên đĩa
    pres.save("AnimExample_Sound_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Trích xuất âm thanh của hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/presentation/).
2. Lấy tham chiếu slide thông qua chỉ mục của nó. 
3. Lấy chuỗi chính của các hiệu ứng. 
4. Trích xuất thuộc tính [setSound(IAudio value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) được nhúng vào mỗi hiệu ứng hoạt ảnh.

Đoạn mã Java sau cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
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

## **Sau hoạt ảnh**

Aspose.Slides for Android via Java cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![Cửa sổ Animation Effect trong Microsoft PowerPoint](shape-after-animation.png)

Danh sách thả xuống PowerPoint Effect **After animation** tương ứng với các thuộc tính sau: 

- Thuộc tính [setAfterAnimationType(int value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationType-int-) mô tả loại After animation :
  * PowerPoint **More Colors** tương ứng với loại [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/afteranimationtype/#Color) ;
  * PowerPoint **Don't Dim** tương ứng với loại [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/afteranimationtype/#DoNotDim) (loại after animation mặc định) ;
  * PowerPoint **Hide After Animation** tương ứng với loại [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/afteranimationtype/#HideAfterAnimation) ;
  * PowerPoint **Hide on Next Mouse Click** tương ứng với loại [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick) ;
- Thuộc tính [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) định dạng màu sau hoạt ảnh. Thuộc tính này hoạt động cùng với loại [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/afteranimationtype/#Color). Nếu bạn thay đổi loại sang một loại khác, màu sau hoạt ảnh sẽ bị xóa.

Đoạn mã Java sau cho bạn thấy cách thay đổi một hiệu ứng after animation:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi loại after animation thành Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Đặt màu dim cho after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Ghi tệp PPTX lên đĩa
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Hoạt ảnh văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) mô tả loại animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh:
  - Cả một lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/animatetexttype/#AllAtOnce) type)
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/animatetexttype/#ByWord) type)
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ tỷ lệ phần trăm thời gian hiệu ứng. Giá trị âm chỉ thời gian trễ tính bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt thuộc tính [setBuildType(int value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/itextanimation/#setBuildType-int-) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/buildtype/#AsOneObject) để tắt chế độ *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setAnimateTextType-int-) và [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).
4. Lưu tệp PPTX đã chỉnh sửa.

Đoạn mã Java sau minh họa thao tác:

```java
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
Presentation pres = new Presentation("AnimTextBox_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi loại Text animation của hiệu ứng thành "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Thay đổi loại Animate text của hiệu ứng thành "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Đặt độ trễ giữa các từ là 20% thời lượng hiệu ứng
    firstEffect.setDelayBetweenTextParts(20f);

    // Ghi tệp PPTX lên đĩa
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Câu hỏi thường gặp**

**Làm sao để đảm bảo hoạt ảnh được giữ nguyên khi xuất bản bài thuyết trình lên web?**

[Export to HTML5](/slides/vi/androidjava/export-to-html5/) và bật các [options](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [transition](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có.

**Thay đổi thứ tự z-order (thứ tự lớp) của các shape ảnh hưởng như thế nào đến hoạt ảnh?**

Thứ tự hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/androidjava/com.aspose.slides/shape/#getZOrderPosition--) quyết định phần nào che phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic này.)

**Có hạn chế nào khi chuyển đổi hoạt ảnh sang video cho một số hiệu ứng không?**

Nhìn chung, [animations are supported](/slides/vi/androidjava/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc với các hiệu ứng cụ thể có thể được render khác nhau. Bạn nên kiểm thử với các hiệu ứng bạn dùng và với phiên bản thư viện hiện tại.