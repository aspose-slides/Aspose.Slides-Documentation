---
title: Áp dụng hoạt ảnh hình dạng trong các bài thuyết trình bằng Java
linktitle: Hoạt ảnh hình dạng
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

Các hoạt ảnh là các hiệu ứng hình ảnh có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [biểu đồ](https://docs.aspose.com/slides/vi/java/animated-charts/). Chúng mang lại sức sống cho các bài thuyết trình hoặc các thành phần của chúng.

## **Tại sao nên sử dụng hoạt ảnh trong bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin  
* nhấn mạnh các điểm quan trọng  
* tăng sự quan tâm hoặc tham gia của khán giả  
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn  
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong một bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho các hoạt ảnh và hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis**, và **motion paths**.

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hoạt ảnh dưới không gian tên `Aspose.Slides.Animation`,  
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** dưới enum [EffectType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttype). Các hiệu ứng này thực chất là cùng một (hoặc tương đương) các hiệu ứng được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides for Java cho phép bạn áp dụng hoạt ảnh cho văn bản trong một hình dạng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu slide thông qua chỉ mục của nó.  
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape).  
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IAutoShape#addTextFrame-java.lang.String-).  
5. Lấy chuỗi chính của các hiệu ứng.  
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape).  
7. Đặt thuộc tính `TextAnimation.BuildType` thành giá trị từ enum `BuildType`.  
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
Presentation pres = new Presentation();
try {
    ISlide sld = pres.getSlides().get_Item(0);

    // Thêm AutoShape mới có văn bản
    IAutoShape autoShape = sld.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 150, 100);

    ITextFrame textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");

    // Lấy chuỗi chính của slide.
    ISequence sequence = sld.getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fade vào shape
    IEffect effect = sequence.addEffect(autoShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

    // Hoạt ảnh văn bản shape theo các đoạn cấp độ 1
    effect.getTextAnimation().setBuildType(BuildType.ByLevelParagraphs1);

    // Lưu tệp PPTX vào đĩa
    pres.save("AnimText_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

{{%  alert color="info"  %}} 

Bên cạnh việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph) riêng lẻ. Xem [**Animated Text**](/slides/vi/java/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu slide thông qua chỉ mục của nó.  
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe) trên slide.  
4. Lấy chuỗi chính của các hiệu ứng.  
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/java/com.aspose.slides/pictureframe).  
6. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp trình chiếu đại diện cho tệp trình chiếu.
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

    // Thêm khung hình ảnh vào slide
    IPictureFrame picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(ShapeType.Rectangle, 50, 50, 100, 100, picture);

    // Lấy chuỗi chính của slide.
    ISequence sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();

    // Thêm hiệu ứng hoạt ảnh Fly từ trái vào khung hình ảnh
    IEffect effect = sequence.addEffect(picFrame, EffectType.Fly, EffectSubtype.Left, EffectTriggerType.OnClick);

    // Lưu tệp PPTX vào đĩa
    pres.save("AnimImage_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/Presentation).  
2. Lấy tham chiếu slide thông qua chỉ mục của nó.  
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape).  
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iautoshape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).  
5. Tạo một chuỗi các hiệu ứng trên hình dạng bevel.  
6. Tạo một `UserPath` tùy chỉnh.  
7. Thêm các lệnh di chuyển đến `UserPath`.  
8. Ghi bài thuyết trình ra đĩa dưới dạng tệp PPTX.

Mã Java này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường dẫn bóng đá) cho một shape:

```java
import com.aspose.slides.*;
import java.awt.geom.Point2D;

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

    // Tạo một chuỗi các hiệu ứng cho nút này.
    ISequence seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);

     // Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ chỉ di chuyển sau khi nút được nhấp.
    IEffect fxUserPath = seqInter.addEffect(ashp, EffectType.PathUser, EffectSubtype.None, EffectTriggerType.OnClick);

     // Thêm các lệnh di chuyển vì đường dẫn đã tạo hiện đang trống.
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

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `getEffectsByShape` từ giao diện [ISequence](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một shape trên slide bình thường**

Trước đó, bạn đã học cách thêm các hiệu ứng hoạt ảnh vào các shape trong bài thuyết trình PowerPoint. Đoạn mã mẫu sau cho bạn thấy cách lấy các hiệu ứng đã áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```java
import com.aspose.slides.*;

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

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm cả những hiệu ứng kế thừa từ các placeholder**

Nếu một shape trên slide bình thường có các placeholder nằm trên layout slide và/hoặc master slide, và các hiệu ứng hoạt ảnh đã được thêm vào các placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong buổi chiếu slide, bao gồm cả những hiệu ứng kế thừa từ các placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** đã được áp dụng cho shape này.

![Slide shape animation effect](slide-shape-animation.png)

Giả sử thêm nữa rằng hiệu ứng **Split** đã được áp dụng cho placeholder footer trên slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** đã được áp dụng cho placeholder footer trên slide **master**.

![Master shape animation effect](master-shape-animation.png)

Đoạn mã mẫu sau cho bạn thấy cách sử dụng phương thức `getBasePlaceholder` từ giao diện [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm cả các hiệu ứng kế thừa từ các placeholder nằm trên layout và master slide.

```java
import com.aspose.slides.*;

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
for (IEffect[] effects : new IEffect[][] { masterShapeEffects, layoutShapeEffects, shapeEffects }) {
    for (IEffect effect : effects) {
        String typeName = EffectType.getName(EffectType.class, effect.getType());
        String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());

        System.out.println(typeName + " " + subtypeName);
    }
}

presentation.dispose();
```
```java
import com.aspose.slides.*;

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

## **Thay đổi các thuộc tính thời gian của hiệu ứng hoạt ảnh**

Aspose.Slides for Java cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Timing trong Microsoft PowerPoint:

![example1_image](shape-animation.png)

Đây là các tương quan giữa Timing của PowerPoint và các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IEffect#getTiming--) :

- Danh sách thả xuống **Start** của PowerPoint tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getTriggerType--).  
- **Duration** của PowerPoint tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getDuration--). Thời lượng của một hoạt ảnh (tính bằng giây) là tổng thời gian hoạt ảnh cần để hoàn thành một chu kỳ.  
- **Delay** của PowerPoint tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ITiming#getTriggerDelayTime--).  

Cách thay đổi các thuộc tính Timing của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.  
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/java/com.aspose.slides/IEffect#getTiming--) mà bạn cần.  
3. Lưu tệp PPTX đã chỉnh sửa.

Mã Java này minh họa thao tác:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
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

## **Âm thanh cho hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)  
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setStopPreviousSound-boolean-) 

### **Thêm âm thanh cho một hiệu ứng hoạt ảnh**

Mã Java này cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng kế tiếp bắt đầu:

```java
import com.aspose.slides.*;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation pres = new Presentation("AnimExample_out.pptx");
try {
    // Thêm âm thanh vào bộ sưu tập âm thanh của bài thuyết trình
    IAudio effectSound = pres.getAudios().addAudio(Files.readAllBytes(Paths.get("sampleaudio.wav")));

    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy chuỗi chính của slide.
    ISequence sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = sequence.get_Item(0);

    // Kiểm tra hiệu ứng xem có "No Sound" không
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

### **Trích xuất âm thanh từ một hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/presentation/).  
2. Lấy tham chiếu slide thông qua chỉ mục của nó.  
3. Lấy chuỗi chính của các hiệu ứng.  
4. Trích xuất âm thanh được nhúng trong mỗi hiệu ứng hoạt ảnh thông qua phương thức [setSound(IAudio value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effect/#setSound-com.aspose.slides.IAudio-).  

Mã Java này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```java
import com.aspose.slides.*;

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

## **After Animation**

Aspose.Slides for Java cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint tương ứng với các thuộc tính sau: 

- Thuộc tính [setAfterAnimationType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAfterAnimationType-int-) mô tả kiểu After animation :  
  * **More Colors** của PowerPoint tương ứng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color);  
  * Mục **Don't Dim** của PowerPoint tương ứng với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#DoNotDim) (kiểu after animation mặc định);  
  * Mục **Hide After Animation** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#HideAfterAnimation);  
  * Mục **Hide on Next Mouse Click** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#HideOnNextMouseClick);  
- Thuộc tính [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAfterAnimationColor-com.aspose.slides.IColorFormat-) định nghĩa định dạng màu sau hoạt ảnh. Thuộc tính này hoạt động cùng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color). Nếu bạn thay đổi kiểu sang kiểu khác, màu after animation sẽ bị xóa.

Mã Java này cho bạn thấy cách thay đổi một hiệu ứng after animation:

```java
import com.aspose.slides.*;
import java.awt.Color;

// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
Presentation pres = new Presentation("AnimImage_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi kiểu after animation sang Color
    firstEffect.setAfterAnimationType(AfterAnimationType.Color);

    // Đặt màu after animation
    firstEffect.getAfterAnimationColor().setColor(Color.BLUE);

    // Ghi tệp PPTX vào đĩa
    pres.save("AnimImage_AfterAnimation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **Animate Text**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) mô tả kiểu animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh:  
  - Cả một lần ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#AllAtOnce));  
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#ByWord));  
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/java/com.aspose.slides/animatetexttype/#ByLetter)).  
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ tỷ lệ phần trăm của thời lượng hiệu ứng. Giá trị âm chỉ thời gian trễ tính bằng giây.

Cách thay đổi các thuộc tính Effect Animate text:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.  
2. Đặt thuộc tính [setBuildType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextanimation/#setBuildType-int-) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/buildtype/#AsOneObject) để tắt chế độ hoạt ảnh *By Paragraphs*.  
3. Đặt các giá trị mới cho các thuộc tính [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setAnimateTextType-int-) và [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setDelayBetweenTextParts-float-).  
4. Lưu tệp PPTX đã chỉnh sửa.

Mã Java này minh họa thao tác:

```java
import com.aspose.slides.*;

// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
Presentation pres = new Presentation("AnimText_out.pptx");
try {
    ISlide firstSlide = pres.getSlides().get_Item(0);

    // Lấy hiệu ứng đầu tiên của chuỗi chính
    IEffect firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);

    // Thay đổi kiểu hoạt ảnh Văn bản của hiệu ứng thành "As One Object"
    firstEffect.getTextAnimation().setBuildType(BuildType.AsOneObject);

    // Thay đổi kiểu Animate text của hiệu ứng thành "By word"
    firstEffect.setAnimateTextType(AnimateTextType.ByWord);

    // Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
    firstEffect.setDelayBetweenTextParts(20f);

    // Ghi tệp PPTX vào đĩa
    pres.save("AnimTextBox_AnimateText.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

### Làm thế nào để đảm bảo hoạt ảnh được giữ nguyên khi xuất bản bài thuyết trình lên web?

[Export to HTML5](/slides/vi/java/export-to-html5/) và bật các [tùy chọn](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và [transition](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có thể.

### Thay đổi thứ tự z (layer order) của các shape có ảnh hưởng như thế nào đến hoạt ảnh?

Thứ tự hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng điều khiển thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/java/com.aspose.slides/shape/#getZOrderPosition--) xác định phần nào che phần nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic tương tự.)

### Có những hạn chế nào khi chuyển đổi hoạt ảnh sang video cho một số hiệu ứng không?

Nhìn chung, [các hoạt ảnh được hỗ trợ](/slides/vi/java/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc các hiệu ứng cụ thể có thể được render khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn sử dụng và với phiên bản thư viện hiện tại.