---
title: Áp dụng hoạt ảnh hình dạng trong bản trình chiếu bằng JavaScript
linktitle: Hoạt ảnh hình dạng
type: docs
weight: 60
url: /vi/nodejs-java/shape-animation/
keywords:
- hình dạng
- hoạt ảnh
- hiệu ứng
- hình dạng động
- văn bản động
- thêm hoạt ảnh
- lấy hoạt ảnh
- trích xuất hoạt ảnh
- thêm hiệu ứng
- lấy hiệu ứng
- trích xuất hiệu ứng
- âm thanh hiệu ứng
- áp dụng hoạt ảnh
- PowerPoint
- bản trình chiếu
- Node.js
- JavaScript
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản động với Aspose.Slides cho Node.js thông qua Java."
---
## **Tổng quan**

Aspose.Slides for Node.js via Java biểu diễn hoạt ảnh slide dưới dạng các hiệu ứng trong dòng thời gian của slide. Một hiệu ứng có hình dạng mục tiêu, loại và phụ loại hoạt ảnh, bộ kích hoạt, cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau khi hoạt ảnh kết thúc.

Dòng thời gian chứa hai loại chuỗi:

- **chuỗi chính** chạy khi slide tiến lên.
- **chuỗi tương tác** bắt đầu khi hình dạng kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác là các đối tượng [Shape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/), bạn sử dụng cùng một phương thức [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) cho hầu hết nội dung slide. Các hiệu ứng khả dụng được liệt kê trong enumeration [EffectType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttype/).

## **Thêm Hoạt Ảnh cho Hình Dạng**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) với hình dạng mục tiêu, loại hiệu ứng, phụ loại và bộ kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một chuỗi tương tác mà bộ kích hoạt là hình dạng đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);

    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Click to animate this shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    const entranceEffect = mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    entranceEffect.getTiming().setDuration(java.newFloat(1.5));

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    presentation.save("shape-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Bộ kích hoạt quyết định khi nào một hiệu ứng bắt đầu:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttriggertype/#OnClick) chờ một lần nhấp trong chuỗi chính, hoặc một lần nhấp trên hình dạng kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttriggertype/#WithPrevious) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effecttriggertype/#AfterPrevious) bắt đầu khi hiệu ứng trước đó kết thúc.

Để hoạt ảnh một hình ảnh, biểu đồ, hoặc một loại hình dạng khác, truyền đối tượng đó vào [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) thay vì `targetShape`. Đối với các tùy chọn nhóm đặc thù cho biểu đồ, xem [Animated Charts](/slides/vi/nodejs-java/animated-charts/).

## **Đọc Hoạt Ảnh của Hình Dạng**

Sử dụng [Sequence.getEffectsByShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#getEffectsByShape) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, duyệt chuỗi chính và mọi chuỗi tương tác. Việc duyệt giúp tránh giả định rằng một chuỗi chứa hiệu ứng tại chỉ mục `0`.

Ví dụ sau tạo một hình dạng có hiệu ứng chuỗi‑chính và chuỗi‑tương tác, lấy các hiệu ứng mục tiêu hình dạng, và sau đó duyệt mọi chuỗi trên slide.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printSequence(label, sequence) {
    console.log(`  ${label}: ${sequence.getCount()} effect(s)`);

    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);
        const targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        const triggerName = getEnumName(aspose.slides.EffectTriggerType, effect.getTiming().getTriggerType());
        console.log(`    ${typeName} ${subtypeName}; target: ${targetName}; trigger: ${triggerName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const targetShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    targetShape.addTextFrame("Animated shape");

    const mainSequence = slide.getTimeline().getMainSequence();
    mainSequence.addEffect(targetShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const triggerShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Bevel, 20, 20, 100, 40);
    triggerShape.addTextFrame("Move");

    const interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
    interactiveSequence.addEffect(targetShape, aspose.slides.EffectType.PathFootball, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const targetEffects = mainSequence.getEffectsByShape(targetShape);
    console.log(`The main sequence contains ${targetEffects.length} effect(s) for ${targetShape.getName()}.`);

    printSequence("Main sequence", mainSequence);

    const interactiveSequences = slide.getTimeline().getInteractiveSequences();
    for (let i = 0; i < interactiveSequences.getCount(); i++) {
        const sequence = interactiveSequences.get_Item(i);
        const triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
        printSequence(`Interactive sequence ${i + 1}, trigger: ${triggerName}`, sequence);
    }
} finally {
    presentation.dispose();
}
```

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước tiên xác định hình dạng bằng tên, kiểu placeholder hoặc thuộc tính ổn định khác; sau đó gọi [Sequence.getEffectsByShape](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#getEffectsByShape). Đừng giả định rằng [ShapeCollection.get_Item](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shapecollection/#get_Item) tại chỉ mục `0` luôn là đối tượng mong muốn.

## **Làm Việc với Hiệu Ứng Placeholder Kế Thừa**

Một placeholder trên slide thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide mẫu. [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) trả về placeholder cha đó, hoặc `null` khi không có cha.

Trong bản trình diễn mẫu sau, footer có **Random Bars** trên slide thường, **Split** trên slide bố cục, và **Fly In** trên slide mẫu.

![Hiệu ứng hoạt ảnh footer trên slide thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder footer trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder footer trên slide mẫu](master-shape-animation.png)

Ví dụ tiếp theo sử dụng một hiearchy placeholder từ một bản trình chiếu mới. Nó thêm hiệu ứng vào placeholder mẫu, placeholder bố cục, và placeholder tương ứng trên slide thường. Mọi lần gọi [Shape.getBasePlaceholder](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/shape/#getBasePlaceholder) đều được kiểm tra trước khi sử dụng hình dạng trả về.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

function findPlaceholderWithBase(baseSlide, expectedBase) {
    const shapes = baseSlide.getShapes();

    for (let i = 0; i < shapes.size(); i++) {
        const shape = shapes.get_Item(i);
        const basePlaceholder = shape.getBasePlaceholder();

        if (basePlaceholder == null) {
            continue;
        }

        if (expectedBase == null || basePlaceholder.getPlaceholder().getType() === expectedBase.getPlaceholder().getType()) {
            return shape;
        }
    }

    return null;
}

function getEnumName(enumType, value) {
    for (const [name, enumValue] of Object.entries(enumType)) {
        if (enumValue === value) {
            return name;
        }
    }

    return String(value);
}

function printEffects(source, effects) {
    console.log(`${source}: ${effects.length} effect(s)`);

    for (const effect of effects) {
        const typeName = getEnumName(aspose.slides.EffectType, effect.getType());
        const subtypeName = getEnumName(aspose.slides.EffectSubtype, effect.getSubtype());
        console.log(`  ${typeName} ${subtypeName}`);
    }
}

const presentation = new aspose.slides.Presentation();
try {
    const layoutSlide = presentation.getLayoutSlides().getByType(java.newByte(aspose.slides.SlideLayoutType.TitleAndObject));
    const layoutPlaceholder = findPlaceholderWithBase(layoutSlide, null);

    if (layoutPlaceholder == null) {
        throw new Error("The layout slide does not contain a placeholder linked to its master slide.");
    }

    const masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
    layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, aspose.slides.EffectType.Fly, aspose.slides.EffectSubtype.Bottom, aspose.slides.EffectTriggerType.OnClick);
    layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, aspose.slides.EffectType.Split, aspose.slides.EffectSubtype.VerticalIn, aspose.slides.EffectTriggerType.OnClick);

    const slide = presentation.getSlides().addEmptySlide(layoutSlide);
    const slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

    if (slidePlaceholder == null) {
        throw new Error("The slide does not contain a placeholder linked to its layout slide.");
    }

    slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, aspose.slides.EffectType.RandomBars, aspose.slides.EffectSubtype.Horizontal, aspose.slides.EffectTriggerType.OnClick);
    printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

    const baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
    if (baseLayoutPlaceholder != null) {
        printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

        const baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
        if (baseMasterPlaceholder != null) {
            printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
        }
    }

    presentation.save("placeholder-animations.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Thay Đổi Thời Gian Hoạt Ảnh**

Hộp thoại **Timing** của PowerPoint tương ứng với các thuộc tính của [Timing](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Start** tương ứng với [Timing.getTriggerType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getTriggerType).
- **Duration** tương ứng với [Timing.getDuration](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getDuration) (giây).
- **Delay** tương ứng với [Timing.getTriggerDelayTime](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getTriggerDelayTime) (giây).
- **Repeat** tương ứng với [Timing.getRepeatCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatCount), [Timing.getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatUntilNextClick) hoặc [Timing.getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRepeatUntilEndSlide).
- **Rewind when done playing** tương ứng với [Timing.getRewind](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#getRewind).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó qua đối tượng trả về bởi [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect), và lưu kết quả. Giữ tham chiếu đến [Effect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/) trả về giúp tránh việc truy cập chỉ mục bộ sưu tập không cần thiết.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Timed animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setTriggerType(aspose.slides.EffectTriggerType.OnClick);
    effect.getTiming().setDuration(java.newFloat(2.0));
    effect.getTiming().setTriggerDelayTime(java.newFloat(0.5));
    effect.getTiming().setRepeatUntilNextClick(false);
    effect.getTiming().setRepeatUntilEndSlide(false);
    effect.getTiming().setRepeatCount(java.newFloat(2.0));
    effect.getTiming().setRewind(true);

    presentation.save("shape-animation-timing.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Sử dụng một chế độ lặp lại duy nhất. Kết hợp số lần lặp với cờ “until” có thể tạo ra kết quả khó hiểu trên các trình xem khác nhau. Khi thay đổi chế độ lặp, đặt [Timing.setRepeatUntilNextClick](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#setRepeatUntilNextClick) và [Timing.setRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#setRepeatUntilEndSlide) trước [Timing.setRepeatCount](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/timing/#setRepeatCount), vì việc thiết lập bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp hiện tại.

## **Thêm và Trích Xuất Âm Thanh cho Hiệu Ứng**

Một hiệu ứng hoạt ảnh có thể tham chiếu tới âm thanh nhúng thông qua [Effect.getSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getSound). [Effect.setStopPreviousSound](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#setStopPreviousSound) cho phép hiệu ứng dừng âm thanh đã được khởi động bởi hiệu ứng trước.

### **Thêm Âm Thanh vào Hiệu Ứng**

Ví dụ sau yêu cầu một tệp âm thanh cục bộ tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Ví dụ sử dụng các đối tượng trả về bởi [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect), vì vậy không cần chỉ mục chuỗi.

```javascript
const fs = require("fs");
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const firstShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 100, 240, 80);
    const secondShape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 400, 100, 240, 80);
    firstShape.addTextFrame("Starts sound");
    secondShape.addTextFrame("Stops sound");

    const sequence = slide.getTimeline().getMainSequence();
    const firstEffect = sequence.addEffect(firstShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    const secondEffect = sequence.addEffect(secondShape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);

    const audioData = java.newArray("byte", Array.from(fs.readFileSync("animation-sound.wav")));
    const effectSound = presentation.getAudios().addAudio(audioData);
    firstEffect.setSound(effectSound);
    secondEffect.setStopPreviousSound(true);

    presentation.save("shape-animation-sound.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

### **Trích Xuất Âm Thanh Nhúng của Hiệu Ứng**

Ví dụ sau yêu cầu một bản trình chiếu cục bộ tên `presentation-with-animation-sounds.pptx`. Nó duyệt cả chuỗi chính và chuỗi tương tác và ghi mỗi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn dựa trên MIME type của âm thanh được cung cấp bởi [Audio.getContentType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audio/#getContentType).

```javascript
const fs = require("fs");
const path = require("path");
const aspose = { slides: require("aspose.slides.via.java") };

function getAudioExtension(contentType) {
    const normalizedType = contentType == null ? "" : contentType.toLowerCase();

    if (normalizedType === "audio/mpeg") {
        return ".mp3";
    }

    if (normalizedType === "audio/mp4") {
        return ".m4a";
    }

    if (normalizedType === "audio/ogg") {
        return ".ogg";
    }

    if (normalizedType === "audio/wav" || normalizedType === "audio/x-wav") {
        return ".wav";
    }

    return ".bin";
}

function saveSounds(sequence, outputDirectory, soundIndex) {
    for (let i = 0; i < sequence.getCount(); i++) {
        const effect = sequence.get_Item(i);

        if (effect.getSound() == null) {
            continue;
        }

        const extension = getAudioExtension(effect.getSound().getContentType());
        const outputPath = path.join(outputDirectory, `effect-sound-${soundIndex}${extension}`);
        fs.writeFileSync(outputPath, Buffer.from(effect.getSound().getBinaryData()));
        soundIndex++;
    }

    return soundIndex;
}

const outputDirectory = "extracted-animation-sounds";
fs.mkdirSync(outputDirectory, { recursive: true });

const presentation = new aspose.slides.Presentation("presentation-with-animation-sounds.pptx");
try {
    let soundIndex = 1;

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

        const interactiveSequences = slide.getTimeline().getInteractiveSequences();
        for (let sequenceIndex = 0; sequenceIndex < interactiveSequences.getCount(); sequenceIndex++) {
            soundIndex = saveSounds(interactiveSequences.get_Item(sequenceIndex), outputDirectory, soundIndex);
        }
    }

    console.log(`Extracted ${soundIndex - 1} sound file(s) to ${path.resolve(outputDirectory)}.`);
} finally {
    presentation.dispose();
}
```

Đối với các đối tượng âm thanh lớn, sử dụng [Audio.getStream](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/audio/#getStream) và sao chép luồng vào tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt Hành Vi Sau Khi Hoạt Ảnh Kết Thúc**

Tùy chọn **After animation** kiểm soát những gì xảy ra với một hình dạng sau khi hiệu ứng của nó kết thúc.

![Hộp thoại PowerPoint Effect Options hiển thị cài đặt After animation](shape-after-animation.png)

Enumeration [AfterAnimationType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/) hỗ trợ giữ nguyên hình dạng, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó ở lần nhấp tiếp theo. Khi loại là [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#Color), cũng phải đặt [Effect.getAfterAnimationColor](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getAfterAnimationColor).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi after‑animation thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 120, 100, 320, 80);
    shape.addTextFrame("Dim after animation");

    const effect = slide.getTimeline().getMainSequence().addEffect(shape, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.setAfterAnimationType(aspose.slides.AfterAnimationType.Color);
    effect.getAfterAnimationColor().setColor(java.getStaticFieldValue("java.awt.Color", "LIGHT_GRAY"));

    presentation.save("shape-animation-after-effect.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Thay đổi loại khỏi [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/afteranimationtype/#Color) sẽ xóa cài đặt màu after‑animation.

## **Hoạt Ảnh Văn Bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [TextAnimation.getBuildType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/textanimation/#getBuildType) điều khiển việc các đoạn văn xuất hiện cùng nhau hay theo mức đoạn.
- [Effect.getAnimateTextType](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getAnimateTextType) điều khiển việc văn bản xuất hiện một lúc, theo từ hoặc theo ký tự. [Effect.getDelayBetweenTextParts](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/effect/#getDelayBetweenTextParts) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập sau hoạt ảnh các từ trong một hộp văn bản. [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/buildtype/#AsOneObject) vô hiệu hoá việc xây dựng theo đoạn, để thiết lập từ áp dụng cho toàn bộ khung văn bản.

```javascript
const aspose = { slides: require("aspose.slides.via.java") };
const java = require("java");

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const textBox = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 80, 80, 560, 100);
    textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

    const effect = slide.getTimeline().getMainSequence().addEffect(textBox, aspose.slides.EffectType.Fade, aspose.slides.EffectSubtype.None, aspose.slides.EffectTriggerType.OnClick);
    effect.getTextAnimation().setBuildType(aspose.slides.BuildType.AsOneObject);
    effect.setAnimateTextType(aspose.slides.AnimateTextType.ByWord);
    effect.setDelayBetweenTextParts(java.newFloat(20.0));

    presentation.save("animated-text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Để xây dựng hộp văn bản theo đoạn, đặt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/buildtype/#ByLevelParagraphs1) (hoặc mức đoạn khác). Để mục tiêu một đoạn riêng biệt với hiệu ứng riêng, dùng overload của [Sequence.addEffect](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/sequence/#addEffect) chấp nhận một [Paragraph](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/paragraph/). Xem [Animated Text](/slides/vi/nodejs-java/animated-text/) để biết các ví dụ mức đoạn.

## **Xuất và Ghi Chú Tương Thích**

- Lưu dưới dạng PPT hoặc PPTX giữ nguyên mô hình hoạt ảnh, nhưng việc phát lại cuối cùng phụ thuộc vào trình xem bản trình chiếu.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/nodejs-java/export-to-html5/), GIF động, hoặc [video conversion](/slides/vi/nodejs-java/convert-powerpoint-to-video/) khi đầu ra cần hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/#setAnimateShapes) và, khi cần, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/vi/nodejs-java/aspose.slides/html5options/#setAnimateTransitions).
- Kết xuất video hỗ trợ nhiều hiệu ứng nhập, nhấn mạnh, thoát và đường chuyển động phổ biến, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra bảng [supported animations and effects](/slides/vi/nodejs-java/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình chiếu quan trọng với phiên bản Aspose.Slides bạn sẽ sử dụng.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng được nhập từ định dạng bản trình chiếu khác có thể được lưu trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Hãy xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu Hỏi Thường Gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint mà không xuất hiện trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển đổi slide không được phát. Xuất sang HTML5, GIF động, hoặc video khi cần giữ chuyển động.

**Tại sao một hiệu ứng lại phát khác nhau trong video?**

Xuất video render hoạt ảnh thay vì lưu nguyên hành vi PowerPoint. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được ước tính. Kiểm tra bảng hiệu ứng hỗ trợ và thử nghiệm bản trình chiếu thực tế trước khi đưa vào sản xuất.

**Việc di chuyển một hình dạng lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh không?**

Không. Z‑order của hình dạng chỉ điều khiển chồng lấp, còn thứ tự chuỗi và bộ kích hoạt điều khiển thứ tự phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.