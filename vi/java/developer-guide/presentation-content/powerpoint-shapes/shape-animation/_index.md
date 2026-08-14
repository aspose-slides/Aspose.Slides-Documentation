---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản trình bày sử dụng Java
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/java/shape-animation/
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
- bản trình bày
- Java
- Aspose.Slides
description: "Tìm hiểu cách thêm, kiểm tra và tùy chỉnh hoạt ảnh hình dạng, thời gian, âm thanh, hành vi sau hoạt ảnh và văn bản động với Aspose.Slides cho Java."
---
## **Tổng quan**

Aspose.Slides for Java đại diện cho các hiệu ứng chuyển động trên slide như các hiệu ứng trong một dòng thời gian slide. Một hiệu ứng có một hình dạng mục tiêu, một loại và phụ loại hoạt ảnh, một trình kích hoạt, cài đặt thời gian, và các thuộc tính tùy chọn như âm thanh hoặc hành vi sau hoạt ảnh.

Dòng thời gian chứa hai loại chuỗi:

- **Chuỗi chính** chạy khi slide tiến tới.
- **Chuỗi tương tác** bắt đầu khi hình dạng kích hoạt của nó được nhấp.

Vì các hộp văn bản, hình ảnh, biểu đồ, bảng và các đối tượng slide khác thực thi [IShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/), bạn sử dụng cùng một phương thức [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) cho phần lớn nội dung slide. Các hiệu ứng khả dụng được liệt kê trong lớp [EffectType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttype/).

## **Thêm Hoạt Ảnh Cho Hình**

Để thêm một hoạt ảnh, lấy chuỗi chính của slide và gọi [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) với hình dạng mục tiêu, loại hiệu ứng, phụ loại và trình kích hoạt. Đối với một hiệu ứng bắt đầu khi một hình dạng khác được nhấp, tạo một chuỗi tương tác mà trình kích hoạt là hình dạng khác đó.

Ví dụ sau tạo cả hai loại hoạt ảnh và lưu kết quả vào `shape-animations.pptx`.

```java
import com.aspose.slides.*;

public class AddShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);

            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Click to animate this shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            IEffect entranceEffect = mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            entranceEffect.getTiming().setDuration(1.5f);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            presentation.save("shape-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Trình kích hoạt kiểm soát thời điểm một hiệu ứng bắt đầu:

- [EffectTriggerType.OnClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttriggertype/#OnClick) chờ một cú nhấp trong chuỗi chính, hoặc một cú nhấp vào hình dạng kích hoạt trong chuỗi tương tác.
- [EffectTriggerType.WithPrevious](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttriggertype/#WithPrevious) bắt đầu cùng với hiệu ứng trước đó.
- [EffectTriggerType.AfterPrevious](https://reference.aspose.com/slides/vi/java/com.aspose.slides/effecttriggertype/#AfterPrevious) bắt đầu khi hiệu ứng trước đó kết thúc.

Để tạo hoạt ảnh cho hình ảnh, biểu đồ hoặc một loại hình dạng khác, truyền đối tượng đó vào [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-) thay vì `targetShape`. Đối với các tùy chọn nhóm riêng cho biểu đồ, xem [Animated Charts](/slides/vi/java/animated-charts/).

## **Đọc Hoạt Ảnh Cho Hình**

Sử dụng [ISequence.getEffectsByShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-) khi bạn biết hình dạng mục tiêu. Để kiểm tra mọi hiệu ứng, liệt kê chuỗi chính và mọi chuỗi tương tác. Việc liệt kê tránh giả định rằng một chuỗi chứa hiệu ứng tại chỉ số `0`.

Ví dụ sau tạo một hình dạng với các hiệu ứng trong chuỗi chính và chuỗi tương tác, lấy các hiệu ứng mục tiêu hình dạng, và sau đó liệt kê mọi chuỗi trên slide.

```java
import com.aspose.slides.*;

public class ReadShapeAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape targetShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            targetShape.addTextFrame("Animated shape");

            ISequence mainSequence = slide.getTimeline().getMainSequence();
            mainSequence.addEffect(targetShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            IAutoShape triggerShape = slide.getShapes().addAutoShape(ShapeType.Bevel, 20, 20, 100, 40);
            triggerShape.addTextFrame("Move");

            ISequence interactiveSequence = slide.getTimeline().getInteractiveSequences().add(triggerShape);
            interactiveSequence.addEffect(targetShape, EffectType.PathFootball, EffectSubtype.None, EffectTriggerType.OnClick);

            IEffect[] targetEffects = mainSequence.getEffectsByShape(targetShape);
            System.out.println("The main sequence contains " + targetEffects.length + " effect(s) for " + targetShape.getName() + ".");

            printSequence("Main sequence", mainSequence);

            int interactiveIndex = 1;
            for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                String triggerName = sequence.getTriggerShape() == null ? "unknown" : sequence.getTriggerShape().getName();
                String sequenceLabel = "Interactive sequence " + interactiveIndex + ", trigger: " + triggerName;
                printSequence(sequenceLabel, sequence);
                interactiveIndex++;
            }
        } finally {
            presentation.dispose();
        }
    }

    private static void printSequence(String label, ISequence sequence) {
        System.out.println("  " + label + ": " + sequence.getCount() + " effect(s)");

        for (IEffect effect : sequence) {
            String targetName = effect.getTargetShape() == null ? "unknown" : effect.getTargetShape().getName();
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            String triggerName = EffectTriggerType.getName(EffectTriggerType.class, effect.getTiming().getTriggerType());
            String effectDescription = typeName + " " + subtypeName + "; target: " + targetName + "; trigger: " + triggerName;
            System.out.println("    " + effectDescription);
        }
    }
}
```

Nếu bạn chỉ cần các hiệu ứng cho một hình dạng, trước tiên xác định hình dạng bằng tên, kiểu placeholder, hoặc thuộc tính ổn định khác; sau đó gọi [ISequence.getEffectsByShape](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#getEffectsByShape-com.aspose.slides.IShape-). Không giả định rằng [IShapeCollection.get_Item](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishapecollection/#get_Item-int-) tại chỉ số `0` luôn là đối tượng mong muốn.

## **Làm việc với Hiệu Ứng Placeholder Kế Thừa**

Một placeholder trên slide bình thường có thể kế thừa hành vi hoạt ảnh từ placeholder tương ứng trên slide bố cục và slide chủ. [IShape.getBasePlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getBasePlaceholder--) trả về placeholder cha đó, hoặc `null` khi không có cha.

Trong bản trình bày mẫu dưới đây, phần chân trang có **Random Bars** trên slide bình thường, **Split** trên slide bố cục, và **Fly In** trên slide chủ.

![Hiệu ứng hoạt ảnh chân trang trên slide bình thường](slide-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide bố cục](layout-shape-animation.png)

![Hiệu ứng hoạt ảnh placeholder chân trang trên slide chủ](master-shape-animation.png)

Ví dụ tiếp theo sử dụng một cây hierarchy placeholder từ một bản trình bày mới. Nó thêm các hiệu ứng vào một placeholder chủ, một placeholder bố cục, và placeholder tương ứng trên một slide bình thường. Mọi lần gọi [IShape.getBasePlaceholder](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ishape/#getBasePlaceholder--) đều được kiểm tra trước khi sử dụng hình dạng trả về.

```java
import com.aspose.slides.*;

public class InheritedPlaceholderAnimations {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ILayoutSlide layoutSlide = presentation.getLayoutSlides().getByType(SlideLayoutType.TitleAndObject);
            IShape layoutPlaceholder = findPlaceholderWithBase(layoutSlide);

            if (layoutPlaceholder == null) {
                throw new IllegalStateException("The layout slide does not contain a placeholder linked to its master slide.");
            }

            IShape masterPlaceholder = layoutPlaceholder.getBasePlaceholder();
            layoutSlide.getMasterSlide().getTimeline().getMainSequence().addEffect(masterPlaceholder, EffectType.Fly, EffectSubtype.Bottom, EffectTriggerType.OnClick);
            layoutSlide.getTimeline().getMainSequence().addEffect(layoutPlaceholder, EffectType.Split, EffectSubtype.VerticalIn, EffectTriggerType.OnClick);

            ISlide slide = presentation.getSlides().addEmptySlide(layoutSlide);
            IShape slidePlaceholder = findPlaceholderWithBase(slide, layoutPlaceholder);

            if (slidePlaceholder == null) {
                throw new IllegalStateException("The slide does not contain a placeholder linked to its layout slide.");
            }

            slide.getTimeline().getMainSequence().addEffect(slidePlaceholder, EffectType.RandomBars, EffectSubtype.Horizontal, EffectTriggerType.OnClick);
            printEffects("Normal slide", slide.getTimeline().getMainSequence().getEffectsByShape(slidePlaceholder));

            IShape baseLayoutPlaceholder = slidePlaceholder.getBasePlaceholder();
            if (baseLayoutPlaceholder != null) {
                printEffects("Layout slide", layoutSlide.getTimeline().getMainSequence().getEffectsByShape(baseLayoutPlaceholder));

                IShape baseMasterPlaceholder = baseLayoutPlaceholder.getBasePlaceholder();
                if (baseMasterPlaceholder != null) {
                    printEffects("Master slide", layoutSlide.getMasterSlide().getTimeline().getMainSequence().getEffectsByShape(baseMasterPlaceholder));
                }
            }

            presentation.save("placeholder-animations.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }

    private static IShape findPlaceholderWithBase(ILayoutSlide layoutSlide) {
        for (IShape shape : layoutSlide.getShapes()) {
            if (shape.getBasePlaceholder() != null) {
                return shape;
            }
        }

        return null;
    }

    private static IShape findPlaceholderWithBase(ISlide slide, IShape expectedBase) {
        for (IShape shape : slide.getShapes()) {
            if (shape.getBasePlaceholder() == expectedBase) {
                return shape;
            }
        }

        return null;
    }

    private static void printEffects(String source, IEffect[] effects) {
        System.out.println(source + ": " + effects.length + " effect(s)");

        for (IEffect effect : effects) {
            String typeName = EffectType.getName(EffectType.class, effect.getType());
            String subtypeName = EffectSubtype.getName(EffectSubtype.class, effect.getSubtype());
            System.out.println("  " + typeName + " " + subtypeName);
        }
    }
}
```

## **Thay Đổi Thời Gian Hoạt Ảnh**

Hộp thoại **Timing** của PowerPoint ánh xạ đến các thuộc tính của [ITiming](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/).

![Hộp thoại Timing của PowerPoint cho một hiệu ứng hoạt ảnh](shape-animation.png)

- **Start** ánh xạ đến [ITiming.getTriggerType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getTriggerType--).
- **Duration** ánh xạ đến [ITiming.getDuration](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getDuration--), tính bằng giây.
- **Delay** ánh xạ đến [ITiming.getTriggerDelayTime](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getTriggerDelayTime--), tính bằng giây.
- **Repeat** ánh xạ đến [ITiming.getRepeatCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatCount--), [ITiming.getRepeatUntilNextClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatUntilNextClick--), hoặc [ITiming.getRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRepeatUntilEndSlide--).
- **Rewind when done playing** ánh xạ đến [ITiming.getRewind](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#getRewind--).

Ví dụ độc lập này thêm một hiệu ứng, thay đổi thời gian của nó thông qua đối tượng trả về bởi [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), và lưu kết quả. Giữ tham chiếu [IEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/) trả về giúp tránh một chỉ mục bộ sưu tập không cần thiết.

```java
import com.aspose.slides.*;

public class ChangeAnimationTiming {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Timed animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTiming().setTriggerType(EffectTriggerType.OnClick);
            effect.getTiming().setDuration(2.0f);
            effect.getTiming().setTriggerDelayTime(0.5f);
            effect.getTiming().setRepeatUntilNextClick(false);
            effect.getTiming().setRepeatUntilEndSlide(false);
            effect.getTiming().setRepeatCount(2.0f);
            effect.getTiming().setRewind(true);

            presentation.save("shape-animation-timing.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Sử dụng một chế độ lặp lại duy nhất có chủ đích. Kết hợp số lần lặp với cờ “until” có thể tạo ra kết quả gây nhầm lẫn trên các trình xem khác nhau. Khi thay đổi chế độ lặp lại, hãy đặt [ITiming.setRepeatUntilNextClick](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#setRepeatUntilNextClick-boolean-) và [ITiming.setRepeatUntilEndSlide](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#setRepeatUntilEndSlide-boolean-) trước [ITiming.setRepeatCount](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itiming/#setRepeatCount-float-), vì việc đặt bất kỳ cờ nào cũng sẽ thay đổi chế độ lặp hiện hoạt.

## **Thêm và Trích Xuất Âm Thanh Hoạt Ảnh**

Một hiệu ứng hoạt ảnh có thể tham chiếu âm thanh nhúng qua [IEffect.getSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getSound--). [IEffect.setStopPreviousSound](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#setStopPreviousSound-boolean-) cho hiệu ứng biết dừng âm thanh đã được bắt đầu bởi hiệu ứng trước.

### **Thêm Âm Thanh Vào Một Hiệu Ứng**

Ví dụ sau yêu cầu một tệp âm thanh cục bộ có tên `animation-sound.wav`. Nó tạo hai hiệu ứng, nhúng tệp đó làm âm thanh cho hiệu ứng đầu tiên, và cấu hình hiệu ứng thứ hai để dừng âm thanh. Nó sử dụng các đối tượng trả về bởi [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IShape-int-int-int-), vì vậy không cần chỉ mục chuỗi.

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

public class AddAnimationSound {
    public static void main(String[] args) throws IOException {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 100, 240, 80);
            IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 400, 100, 240, 80);
            firstShape.addTextFrame("Starts sound");
            secondShape.addTextFrame("Stops sound");

            ISequence sequence = slide.getTimeline().getMainSequence();
            IEffect firstEffect = sequence.addEffect(firstShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            IEffect secondEffect = sequence.addEffect(secondShape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);

            byte[] audioData = Files.readAllBytes(Paths.get("animation-sound.wav"));
            IAudio effectSound = presentation.getAudios().addAudio(audioData);
            firstEffect.setSound(effectSound);
            secondEffect.setStopPreviousSound(true);

            presentation.save("shape-animation-sound.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

### **Trích Xuất Âm Thanh Nhúng Của Hiệu Ứng**

Ví dụ sau yêu cầu một bản trình bày cục bộ có tên `presentation-with-animation-sounds.pptx`. Nó quét cả chuỗi chính và chuỗi tương tác và ghi mọi âm thanh hiệu ứng nhúng vào thư mục `extracted-animation-sounds`. Phần mở rộng được chọn dựa trên loại MIME âm thanh được cung cấp bởi [IAudio.getContentType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudio/#getContentType--).

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

public class ExtractAnimationSounds {
    public static void main(String[] args) throws IOException {
        Path inputPath = Paths.get("presentation-with-animation-sounds.pptx");
        Path outputDirectory = Paths.get("extracted-animation-sounds");

        Files.createDirectories(outputDirectory);

        Presentation presentation = new Presentation(inputPath.toString());
        try {
            int soundIndex = 1;

            for (ISlide slide : presentation.getSlides()) {
                soundIndex = saveSounds(slide.getTimeline().getMainSequence(), outputDirectory, soundIndex);

                for (ISequence sequence : slide.getTimeline().getInteractiveSequences()) {
                    soundIndex = saveSounds(sequence, outputDirectory, soundIndex);
                }
            }

            System.out.println("Extracted " + (soundIndex - 1) + " sound file(s) to " + outputDirectory.toAbsolutePath() + ".");
        } finally {
            presentation.dispose();
        }
    }

    private static int saveSounds(ISequence sequence, Path outputDirectory, int soundIndex) throws IOException {
        for (IEffect effect : sequence) {
            if (effect.getSound() == null) {
                continue;
            }

            String extension = getAudioExtension(effect.getSound().getContentType());
            Path outputPath = outputDirectory.resolve("effect-sound-" + soundIndex + extension);
            Files.write(outputPath, effect.getSound().getBinaryData());
            soundIndex++;
        }

        return soundIndex;
    }

    private static String getAudioExtension(String contentType) {
        String normalizedType = contentType == null ? "" : contentType.toLowerCase(Locale.ROOT);

        if (normalizedType.equals("audio/mpeg")) {
            return ".mp3";
        }

        if (normalizedType.equals("audio/mp4")) {
            return ".m4a";
        }

        if (normalizedType.equals("audio/ogg")) {
            return ".ogg";
        }

        if (normalizedType.equals("audio/wav") || normalizedType.equals("audio/x-wav")) {
            return ".wav";
        }

        return ".bin";
    }
}
```

Đối với các đối tượng âm thanh lớn, sử dụng [IAudio.getStream](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iaudio/#getStream--) và sao chép luồng tới tệp thay vì tải toàn bộ đối tượng vào mảng byte.

## **Đặt Hành Vi Sau Hoạt Ảnh**

Tùy chọn **After animation** kiểm soát những gì xảy ra với một hình dạng sau khi hiệu ứng của nó kết thúc.

![Hộp thoại tùy chọn hiệu ứng PowerPoint hiển thị cài đặt After animation](shape-after-animation.png)

Lớp [AfterAnimationType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/) hỗ trợ giữ nguyên hình dạng, thay đổi màu, ẩn nó sau hoạt ảnh, hoặc ẩn nó khi nhấp tiếp theo. Khi loại là [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color), cũng đặt [IEffect.getAfterAnimationColor](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getAfterAnimationColor--).

Ví dụ độc lập này tạo một hiệu ứng, đặt hành vi sau hoạt ảnh thông qua đối tượng hiệu ứng trả về, và lưu kết quả.

```java
import com.aspose.slides.*;
import java.awt.Color;

public class SetAfterAnimationBehavior {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 120, 100, 320, 80);
            shape.addTextFrame("Dim after animation");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(shape, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.setAfterAnimationType(AfterAnimationType.Color);
            effect.getAfterAnimationColor().setColor(Color.LIGHT_GRAY);

            presentation.save("shape-animation-after-effect.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Thay đổi loại khỏi [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/java/com.aspose.slides/afteranimationtype/#Color) sẽ xóa thiết lập màu sau hoạt ảnh.

## **Hoạt Ảnh Văn Bản**

Hoạt ảnh văn bản có hai điều khiển liên quan:

- [ITextAnimation.getBuildType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/itextanimation/#getBuildType--) kiểm soát liệu các đoạn văn hiện cùng nhau hay theo mức độ đoạn.
- [IEffect.getAnimateTextType](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getAnimateTextType--) kiểm soát liệu văn bản hiện toàn bộ, theo từ, hoặc theo ký tự. [IEffect.getDelayBetweenTextParts](https://reference.aspose.com/slides/vi/java/com.aspose.slides/ieffect/#getDelayBetweenTextParts--) đặt độ trễ giữa các từ hoặc ký tự. Giá trị dương là phần trăm của thời lượng hiệu ứng; giá trị âm là độ trễ tính bằng giây.

Ví dụ độc lập sau hoạt ảnh các từ trong một hộp văn bản. [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/java/com.aspose.slides/buildtype/#AsOneObject) tắt việc xây dựng đoạn theo đoạn để cài đặt từ áp dụng cho toàn bộ khung văn bản.

```java
import com.aspose.slides.*;

public class AnimateTextByWord {
    public static void main(String[] args) {
        Presentation presentation = new Presentation();
        try {
            ISlide slide = presentation.getSlides().get_Item(0);
            IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 80, 80, 560, 100);
            textBox.addTextFrame("Aspose.Slides animates this sentence word by word.");

            IEffect effect = slide.getTimeline().getMainSequence().addEffect(textBox, EffectType.Fade, EffectSubtype.None, EffectTriggerType.OnClick);
            effect.getTextAnimation().setBuildType(BuildType.AsOneObject);
            effect.setAnimateTextType(AnimateTextType.ByWord);
            effect.setDelayBetweenTextParts(20.0f);

            presentation.save("animated-text.pptx", SaveFormat.Pptx);
        } finally {
            presentation.dispose();
        }
    }
}
```

Để xây dựng một hộp văn bản theo đoạn, đặt [BuildType.ByLevelParagraphs1](https://reference.aspose.com/slides/vi/java/com.aspose.slides/buildtype/#ByLevelParagraphs1) (hoặc mức độ đoạn khác). Để mục tiêu một đoạn riêng biệt với hiệu ứng riêng, sử dụng phương thức quá tải [ISequence.addEffect](https://reference.aspose.com/slides/vi/java/com.aspose.slides/isequence/#addEffect-com.aspose.slides.IParagraph-int-int-int-) chấp nhận một [IParagraph](https://reference.aspose.com/slides/vi/java/com.aspose.slides/iparagraph/). Xem [Animated Text](/slides/vi/java/animated-text/) để biết các ví dụ mức độ đoạn.

## **Xuất và Ghi chú Tương Thích**

- Lưu thành PPT hoặc PPTX giữ mô hình hoạt ảnh, nhưng việc phát lại cuối cùng được điều khiển bởi trình xem bản trình bày.
- PDF và hình ảnh tĩnh không phát hoạt ảnh. Sử dụng [HTML5 export](/slides/vi/java/export-to-html5/), GIF động, hoặc [video conversion](/slides/vi/java/convert-powerpoint-to-video/) khi đầu ra phải hiển thị chuyển động.
- Đối với HTML5, bật [Html5Options.setAnimateShapes](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateShapes-boolean-) và, khi cần, [Html5Options.setAnimateTransitions](https://reference.aspose.com/slides/vi/java/com.aspose.slides/html5options/#setAnimateTransitions-boolean-).
- Kết xuất video hỗ trợ nhiều hiệu ứng vào, nhấn mạnh, ra và đường chuyển động phổ biến, nhưng không phải mọi hiệu ứng PowerPoint đều được hỗ trợ. Kiểm tra [supported animations and effects](/slides/vi/java/convert-powerpoint-to-video/#supported-animations-and-effects) hiện tại và thử nghiệm các bản trình bày quan trọng với phiên bản Aspose.Slides mục tiêu của bạn.
- Các hiệu ứng tùy chỉnh nâng cao và các hiệu ứng được nhập từ các định dạng bản trình bày khác có thể được giữ trong tệp nhưng hiển thị khác nhau trong PowerPoint, HTML5 hoặc video. Xác thực kết quả xuất thay vì chỉ dựa vào tên hiệu ứng.

## **Câu Hỏi Thường Gặp**

**Tại sao một hoạt ảnh xuất hiện trong PowerPoint nhưng không trong PDF?**

PDF là định dạng tĩnh, vì vậy hoạt ảnh và chuyển tiếp slide không được phát. Xuất sang HTML5, GIF động, hoặc video khi cần giữ chuyển động.

**Tại sao một hiệu ứng phát khác nhau trong video?**

Xuất video render hoạt ảnh thay vì lưu trữ hành vi PowerPoint gốc. Một số hiệu ứng nâng cao không được hỗ trợ hoặc chỉ được ước tính. Xem bảng các hiệu ứng được hỗ trợ và thử nghiệm bản trình bày thực tế trước khi dùng trong sản xuất.

**Di chuyển một hình dạng lên phía trước hoặc phía sau có thay đổi thứ tự hoạt ảnh không?**

Không. Thứ tự z-order của hình dạng kiểm soát chồng lặp, trong khi thứ tự chuỗi và trình kích hoạt kiểm soát việc phát hoạt ảnh. Thay đổi dòng thời gian nếu bạn cần một thứ tự phát khác.