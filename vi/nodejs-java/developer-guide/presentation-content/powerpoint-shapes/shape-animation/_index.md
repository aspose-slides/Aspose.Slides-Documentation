---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản trình bày bằng JavaScript
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/nodejs-java/shape-animation/
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
- bản trình bày
- Node.js
- JavaScript
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong các bản trình bày PowerPoint bằng JavaScript và Aspose.Slides cho Node.js via Java. Nổi bật hơn!"
---
## **Giới thiệu**

Hoạt ảnh là các hiệu ứng hình ảnh có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [charts](/slides/vi/nodejs-java/animated-charts/). Chúng mang lại sức sống cho các bản trình bày hoặc các thành phần của chúng.

## **Tại sao nên sử dụng hoạt ảnh trong bản trình bày?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem tới các phần quan trọng trong bản trình bày

PowerPoint cung cấp nhiều tùy chọn và công cụ cho các hoạt ảnh và hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis** và **motion paths**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hoạt ảnh dưới không gian tên `Aspose.Slides.Animation`,
* Aspose.Slides cung cấp hơn **150 animation effects** dưới enumeration [EffectType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttype). Những hiệu ứng này về cơ bản là các hiệu ứng tương đương được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides for Node.js via Java cho phép bạn áp dụng hoạt ảnh cho văn bản trong một shape.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape).
4. Thêm văn bản bằng [AutoShape.addTextFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/AutoShape#addTextFrame-java.lang.String-).
5. Lấy một chuỗi hiệu ứng chính.
6. Thêm một hiệu ứng hoạt ảnh vào [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape).
7. Gọi phương thức `TextAnimation.setBuildType` với giá trị từ enumeration `BuildType`.
8. Ghi bản trình bày ra đĩa dưới dạng file PPTX.

Đoạn mã Javascript này cho bạn thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```javascript
// Tạo một lớp presentation đại diện cho một tệp trình chiếu.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Thêm AutoShape mới với văn bản
    var autoShape = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 20, 20, 150, 100);
    var textFrame = autoShape.getTextFrame();
    textFrame.setText("First paragraph \nSecond paragraph \n Third paragraph");
    // Lấy chuỗi chính của slide.
    var sequence = sld.getTimeline().getMainSequence();
    // Thêm hiệu ứng hoạt ảnh Fade vào shape
    var effect = sequence.addEffect(autoShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Hoạt ảnh văn bản shape theo các đoạn văn cấp 1
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.ByLevelParagraphs1);
    // Lưu tệp PPTX vào đĩa
    pres.save(path + "AnimText_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph) đơn lẻ. Xem [**Animated Text**](/slides/vi/nodejs-java/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe) trên slide.
4. Lấy chuỗi hiệu ứng chính.
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/pictureframe).
6. Ghi bản trình bày ra đĩa dưới dạng file PPTX.

Đoạn mã Javascript này cho bạn thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```javascript
// Tạo một lớp presentation đại diện cho một tệp trình chiếu.
var pres = new aspose.slides.Presentation();
try {
    // Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của bản trình bày
    var picture;
    var image = aspose.slides.Images.fromFile("aspose-logo.jpg");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Thêm khung hình ảnh vào slide
    var picFrame = pres.getSlides().get_Item(0).getShapes().addPictureFrame(aspose.slides.ShapeType.Rectangle, 50, 50, 100, 100, picture);
    // Lấy chuỗi chính của slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Thêm hiệu ứng hoạt ảnh Fly từ Trái vào khung hình ảnh
    var effect = sequence.addEffect(picFrame, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Left, aspose.slides.EffectTriggerType.OnClick);
    // Lưu tệp PPTX vào đĩa
    pres.save(path + "AnimImage_out.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape).
4. Thêm một `Bevel` [AutoShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/autoshape) (khi đối tượng này được nhấn, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi hiệu ứng trên shape bevel.
6. Tạo một `UserPath` tuỳ chỉnh.
7. Thêm các lệnh di chuyển vào `UserPath`.
8. Ghi bản trình bày ra đĩa dưới dạng file PPTX.

Đoạn mã Javascript này cho bạn thấy cách áp dụng hiệu ứng `PathFootball` (đường chạy bóng đá) cho một shape:

```javascript
// Tạo một lớp Presentation đại diện cho tệp PPTX.
var pres = new aspose.slides.Presentation();
try {
    var sld = pres.getSlides().get_Item(0);
    // Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    var ashp = sld.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 150, 150, 250, 25);
    ashp.addTextFrame("Animated TextBox");
    // Thêm hiệu ứng hoạt ảnh PathFootBall
    pres.getSlides().get_Item(0).getTimeline().getMainSequence().addEffect(ashp, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.AfterPrevious);
    // Tạo một loại "nút" nào đó.
    var shapeTrigger = pres.getSlides().get_Item(0).getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 10, 10, 20, 20);
    // Tạo một chuỗi hiệu ứng cho nút này.
    var seqInter = pres.getSlides().get_Item(0).getTimeline().getInteractiveSequences().add(shapeTrigger);
    // Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ chỉ di chuyển sau khi nút được nhấn.
    var fxUserPath = seqInter.addEffect(ashp, aspose.slides.EffectType.PathUser, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    // Thêm các lệnh di chuyển vì đường dẫn đã tạo hiện đang trống.
    var motionBhv = fxUserPath.getBehaviors().get_Item(0);
    var pts = java.newArray("com.aspose.slides.Point2DFloat", [java.newInstanceSync("com.aspose.slides.Point2DFloat", 0.076, 0.59)]);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, true);
    pts[0] = java.newInstanceSync("com.aspose.slides.Point2DFloat", java.newFloat(-0.076), java.newFloat(-0.59));
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.LineTo, pts, aspose.slides.MotionPathPointsType.Auto, false);
    motionBhv.getPath().add(aspose.slides.MotionCommandPathType.End, null, aspose.slides.MotionPathPointsType.Auto, false);
    // Ghi tệp PPTX ra đĩa
    pres.save("AnimExample_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho Shape**

Các ví dụ dưới đây cho bạn thấy cách sử dụng phương thức `getEffectsByShape` từ lớp [Sequence](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã được áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh được áp dụng cho một shape trên slide bình thường**

Trước đó, bạn đã học cách thêm hiệu ứng hoạt ảnh vào các shape trong bản trình bày PowerPoint. Đoạn mã mẫu sau cho bạn thấy cách lấy các hiệu ứng được áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bản trình bày `AnimExample_out.pptx`.

```javascript
var presentation = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    var firstSlide = presentation.getSlides().get_Item(0);

    // Lấy chuỗi hoạt ảnh chính của slide.
    var sequence = firstSlide.getTimeline().getMainSequence();

    // Lấy shape đầu tiên trên slide đầu tiên.
    var shape = firstSlide.getShapes().get_Item(0);

    // Lấy các hiệu ứng hoạt ảnh được áp dụng cho shape.
    var shapeEffects = sequence.getEffectsByShape(shape);

    if (shapeEffects.length > 0) {
        console.log("The shape", shape.getName(), "has", shapeEffects.length, "animation effects.");
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm cả những hiệu ứng được kế thừa từ placeholder**

Nếu một shape trên slide bình thường có các placeholder nằm trên layout slide và/hoặc master slide, và các hiệu ứng hoạt ảnh đã được thêm vào những placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong quá trình trình chiếu, bao gồm cả những hiệu ứng được kế thừa.

Giả sử chúng ta có một file PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** đã được áp dụng cho shape này.

![Hiệu ứng hoạt ảnh shape trên slide](slide-shape-animation.png)

Giả sử nữa rằng hiệu ứng **Split** đã được áp dụng cho placeholder footer trên **layout** slide.

![Hiệu ứng hoạt ảnh shape trên layout](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** đã được áp dụng cho placeholder footer trên **master** slide.

![Hiệu ứng hoạt ảnh shape trên master](master-shape-animation.png)

Đoạn mã mẫu sau cho bạn thấy cách sử dụng phương thức `getBasePlaceholder` từ lớp [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm cả những hiệu ứng được kế thừa từ placeholder nằm trên layout và master slide.

```js
var presentation = new aspose.slides.Presentation("sample.pptx");

var slide = presentation.getSlides().get_Item(0);

// Get animation effects of the shape on the normal slide.
var shape = slide.getShapes().get_Item(0);
var shapeEffects = slide.getTimeline().getMainSequence().getEffectsByShape(shape);

// Get animation effects of the placeholder on the layout slide.
var layoutShape = shape.getBasePlaceholder();
var layoutShapeEffects = slide.getLayoutSlide().getTimeline().getMainSequence().getEffectsByShape(layoutShape);

// Get animation effects of the placeholder on the master slide.
var masterShape = layoutShape.getBasePlaceholder();
var masterShapeEffects = slide.getLayoutSlide().getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(masterShape);

console.log("Main sequence of shape effects:");
printEffects(masterShapeEffects);
printEffects(layoutShapeEffects);
printEffects(shapeEffects);

presentation.dispose();
```
```js
function printEffects(effects) {
    for (const effect of effects) {
        console.log("Type:", effect.getType() + ", subtype:", effect.getSubtype());
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Bay, Dưới
Type: 134, subtype: 45            // Tách, Dọc Vào
Type: 126, subtype: 22            // Ruy-băng Ngẫu nhiên, Ngang
```

## **Thay đổi thuộc tính Timing của hiệu ứng hoạt ảnh**

Aspose.Slides for Node.js via Java cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Timing trong Microsoft PowerPoint:

![example1_image](shape-animation.png)

Đây là các tương quan giữa PowerPoint Timing và các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Effect#getTiming--) :

- Danh sách thả xuống PowerPoint Timing **Start** tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Timing#getTriggerType--).
- PowerPoint Timing **Duration** tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Timing#getDuration--). Thời lượng của một hoạt ảnh (giây) là tổng thời gian hoạt ảnh hoàn thành một chu kỳ.
- PowerPoint Timing **Delay** tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Timing#getTriggerDelayTime--).

Cách thay đổi các thuộc tính Timing của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/Effect#getTiming--) mà bạn cần.
3. Lưu file PPTX đã sửa đổi.

Đoạn mã Javascript này minh họa thao tác:

```javascript
// Tạo một lớp presentation đại diện cho một tệp trình chiếu.
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Lấy chuỗi chính của slide.
    var sequence = pres.getSlides().get_Item(0).getTimeline().getMainSequence();
    // Lấy hiệu ứng đầu tiên của chuỗi chính.
    var effect = sequence.get_Item(0);
    // Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấn
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    // Thay đổi Duration của hiệu ứng
    effect.getTiming().setDuration(3.0);
    // Thay đổi TriggerDelayTime của hiệu ứng
    effect.getTiming().setTriggerDelayTime(0.5);
    // Lưu tệp PPTX vào đĩa
    pres.save("AnimExample_changed.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Âm thanh cho hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong hiệu ứng hoạt ảnh: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Đoạn mã Javascript này cho bạn thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```javascript
var pres = new aspose.slides.Presentation("AnimExample_out.pptx");
try {
    // Thêm âm thanh vào bộ sưu tập âm thanh của bản trình bày
    var effectSound = pres.getAudios().addAudio(java.newInstanceSync("java.io.FileInputStream", java.newInstanceSync("java.io.File", "sampleaudio.wav")));
    var firstSlide = pres.getSlides().get_Item(0);
    // Lấy chuỗi chính của slide.
    var sequence = firstSlide.getTimeline().getMainSequence();
    // Lấy hiệu ứng đầu tiên của chuỗi chính
    var firstEffect = sequence.get_Item(0);
    // Kiểm tra hiệu ứng cho "Không có âm thanh"
    if ((!firstEffect.getStopPreviousSound()) && (firstEffect.getSound() == null)) {
        // Thêm âm thanh cho hiệu ứng đầu tiên
        firstEffect.setSound(effectSound);
    }
    // Lấy chuỗi tương tác đầu tiên của slide.
    var interactiveSequence = firstSlide.getTimeline().getInteractiveSequences().get_Item(0);
    // Đặt cờ "Stop previous sound" cho hiệu ứng
    interactiveSequence.get_Item(0).setStopPreviousSound(true);
    // Lưu tệp PPTX vào đĩa
    pres.save("AnimExample_Sound_out.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Trích xuất âm thanh từ hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/presentation/).
2. Lấy tham chiếu slide thông qua chỉ mục của nó. 
3. Lấy chuỗi hiệu ứng chính. 
4. Trích xuất [setSound(IAudio value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setSound-aspose.slides.IAudio-) đã được nhúng vào mỗi hiệu ứng hoạt ảnh.

Đoạn mã Javascript này cho bạn thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```javascript
// Tạo một lớp presentation đại diện cho tệp trình chiếu.
var presentation = new aspose.slides.Presentation("EffectSound.pptx");
try {
    var slide = presentation.getSlides().get_Item(0);
    // Lấy chuỗi chính của slide.
    var sequence = slide.getTimeline().getMainSequence();
    for (var i = 0; i < sequence.getCount(); i++) {
        var effect = sequence.get_Item(i);
        if (effect.getSound() == null) {
            continue;
        }
        // Trích xuất âm thanh của hiệu ứng thành mảng byte
        var audio = effect.getSound().getBinaryData();
    }
} finally {
    if (presentation != null) {
        presentation.dispose();
    }
}
```

## **Sau khi hoạt ảnh**

Aspose.Slides for Node.js via Java cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Danh sách thả xuống PowerPoint Effect **After animation** tương ứng với các thuộc tính sau: 

- Phương thức [setAfterAnimationType(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setAfterAnimationType-int-) mô tả kiểu After animation;
  * **More Colors** của PowerPoint tương ứng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#Color);
  * **Don't Dim** của PowerPoint tương ứng với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#DoNotDim) (kiểu after animation mặc định);
  * **Hide After Animation** tương ứng với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * **Hide on Next Mouse Click** tương ứng với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Phương thức [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setAfterAnimationColor-aspose.slides.IColorFormat-) định nghĩa định dạng màu after animation. Phương thức này hoạt động cùng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#Color). Nếu bạn thay đổi kiểu sang một kiểu khác, màu after animation sẽ bị xóa.

Đoạn mã Javascript này cho bạn thấy cách thay đổi một hiệu ứng after animation:

```javascript
// Tạo một lớp presentation đại diện cho tệp trình chiếu
var pres = new aspose.slides.Presentation("AnimImage_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Lấy hiệu ứng đầu tiên của chuỗi chính
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Thay đổi loại after animation thành Color
    firstEffect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    // Đặt màu dim cho after animation
    firstEffect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "BLUE"));
    // Ghi tệp PPTX vào đĩa
    pres.save("AnimImage_AfterAnimation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Hoạt ảnh văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) mô tả kiểu animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh:
  - Toàn bộ một lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/animatetexttype/#AllAtOnce) type)
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/animatetexttype/#ByWord) type)
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/animatetexttype/#ByLetter) type)
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ phần trăm thời lượng hiệu ứng, giá trị âm chỉ thời gian trễ tính bằng giây.

Cách thay đổi các thuộc tính Animate text của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt phương thức [setBuildType(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textanimation/#setBuildType-int-) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/buildtype/#AsOneObject) để tắt chế độ *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setAnimateTextType-int-) và [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setDelayBetweenTextParts-float-).
4. Lưu file PPTX đã sửa đổi.

Đoạn mã Javascript này minh họa thao tác:

```javascript
// Tạo một lớp presentation đại diện cho một tệp trình chiếu.
var pres = new aspose.slides.Presentation("AnimTextBox_out.pptx");
try {
    var firstSlide = pres.getSlides().get_Item(0);
    // Lấy hiệu ứng đầu tiên của chuỗi chính
    var firstEffect = firstSlide.getTimeline().getMainSequence().get_Item(0);
    // Thay đổi kiểu hoạt ảnh văn bản của hiệu ứng thành "As One Object"
    firstEffect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    // Thay đổi kiểu Animate text của hiệu ứng thành "By word"
    firstEffect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    // Đặt độ trễ giữa các từ là 20% thời lượng hiệu ứng
    firstEffect.setDelayBetweenTextParts(20.0);
    // Ghi tệp PPTX vào đĩa
    pres.save("AnimTextBox_AnimateText.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Làm sao tôi có thể đảm bảo các hoạt ảnh được giữ lại khi xuất bản bản trình bày lên web?**

[Export to HTML5](/slides/vi/nodejs-java/export-to-html5/) và bật các [options](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/setanimateshapes/) và [transition](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/setanimatetransitions/). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có.

**Thay đổi thứ tự lớp (z-order) của các shape ảnh hưởng như thế nào tới hoạt ảnh?**

Thứ tự hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng điều khiển thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/getzorderposition/) xác định lớp nào bao phủ lớp nào. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo cùng logic.)

**Có hạn chế nào khi chuyển đổi hoạt ảnh sang video cho một số hiệu ứng không?**

Nhìn chung, [animations are supported](/slides/vi/nodejs-java/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc với các hiệu ứng cụ thể có thể được render khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn sử dụng và với phiên bản thư viện hiện tại.