---
title: Áp dụng Hoạt ảnh Hình dạng trong Bản thuyết trình bằng PHP
linktitle: Hoạt ảnh Hình dạng
type: docs
weight: 60
url: /vi/php-java/shape-animation/
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
- bản thuyết trình
- PHP
- Aspose.Slides
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh hình dạng trong bản thuyết trình PowerPoint với Aspose.Slides cho PHP qua Java. Nổi bật!"
---
## **Giới thiệu**

Các hoạt ảnh là hiệu ứng hình ảnh có thể được áp dụng cho văn bản, hình ảnh, hình dạng hoặc [biểu đồ](https://docs.aspose.com/slides/vi/php-java/animated-charts/). Chúng mang lại sức sống cho các bài thuyết trình hoặc các thành phần của chúng.

## **Tại sao nên sử dụng hoạt ảnh trong bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc tham gia của khán giả
* làm cho nội dung dễ đọc, hấp thụ hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem đến các phần quan trọng trong bản thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis**, và **motion paths**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu bạn cần để làm việc với hoạt ảnh dưới không gian tên `Aspose.Slides.Animation`,
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** dưới liệt kê [EffectType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effecttype). Các hiệu ứng này về cơ bản là các hiệu ứng tương đương được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides for PHP via Java cho phép bạn áp dụng hoạt ảnh cho văn bản trong một hình dạng.

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
4. Thêm văn bản vào [TextFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/#getTextFrame) của `AutoShape`.
5. Lấy chuỗi chính của các hiệu ứng.
6. Thêm một hiệu ứng hoạt ảnh vào [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
7. Sử dụng phương thức `TextAnimation.setBuildType` và giá trị từ liệt kê `BuildType`.
8. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã PHP này cho bạn xem cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```php
  # Tạo một lớp trình bày đại diện cho tệp trình bày.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Thêm AutoShape mới với văn bản
    $autoShape = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 20, 20, 150, 100);
    $textFrame = $autoShape->getTextFrame();
    $textFrame->setText("First paragraph \nSecond paragraph \n Third paragraph");
    # Lấy chuỗi chính của slide.
    $sequence = $sld->getTimeline()->getMainSequence();
    # Thêm hiệu ứng hoạt ảnh Fade vào shape
    $effect = $sequence->addEffect($autoShape, EffectType::Fade, EffectSubType::None, EffectTriggerType::OnClick);
    # Hoạt ảnh văn bản shape theo các đoạn cấp 1
    $effect->getTextAnimation()->setBuildType(BuildType::ByLevelParagraphs1);
    # Lưu tệp PPTX ra đĩa
    $pres->save($path . "AnimText_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](https://reference.aspose.com/slides/vi/php-java/aspose.slides/paragraph/). Xem [**Animated Text**](/slides/vi/php-java/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe) trên slide.
4. Lấy chuỗi chính của các hiệu ứng.
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/php-java/aspose.slides/pictureframe).
6. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã PHP này cho bạn xem cách áp dụng hiệu ứng `Fly` cho một khung hình:

```php
  # Tạo một lớp trình bày đại diện cho tệp trình bày.
  $pres = new Presentation();
  try {
    # Tải hình ảnh để thêm vào bộ sưu tập hình ảnh của bản thuyết trình
    $picture;
    $image = Images->fromFile("aspose-logo.jpg");
    try {
      $picture = $pres->getImages()->addImage($image);
    } finally {
      if (!java_is_null($image)) {
        $image->dispose();
      }
    }
    # Thêm khung hình ảnh vào slide
    $picFrame = $pres->getSlides()->get_Item(0)->getShapes()->addPictureFrame(ShapeType::Rectangle, 50, 50, 100, 100, $picture);
    # Lấy chuỗi chính của slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Thêm hiệu ứng hoạt ảnh Fly từ trái vào khung hình ảnh
    $effect = $sequence->addEffect($picFrame, EffectType::Fly, EffectSubType::Left, EffectTriggerType::OnClick);
    # Lưu tệp PPTX ra đĩa
    $pres->save($path . "AnimImage_out.pptx", SaveFormat::Pptx);
  } catch (JavaException $e) {
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/Presentation).
2. Lấy tham chiếu slide thông qua chỉ mục của nó.
3. Thêm một hình chữ nhật [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/).
4. Thêm một [AutoShape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/autoshape/) có góc vát (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi các hiệu ứng cho hình dạng góc vát.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh di chuyển tới `UserPath`.
8. Ghi bản thuyết trình ra đĩa dưới dạng tệp PPTX.

Đoạn mã PHP này cho bạn xem cách áp dụng hiệu ứng `PathFootball` (đường đi bóng đá) cho một hình dạng:

```php
  # Tạo một lớp Presentation đại diện cho tệp PPTX.
  $pres = new Presentation();
  try {
    $sld = $pres->getSlides()->get_Item(0);
    # Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
    $ashp = $sld->getShapes()->addAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);
    $ashp->addTextFrame("Animated TextBox");
    # Thêm hiệu ứng hoạt ảnh PathFootBall
    $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence()->addEffect($ashp, EffectType::PathFootball, EffectSubType::None, EffectTriggerType::AfterPrevious);
    # Tạo một loại "button" nào đó.
    $shapeTrigger = $pres->getSlides()->get_Item(0)->getShapes()->addAutoShape(ShapeType::Bevel, 10, 10, 20, 20);
    # Tạo một chuỗi các hiệu ứng cho nút này.
    $seqInter = $pres->getSlides()->get_Item(0)->getTimeline()->getInteractiveSequences()->add($shapeTrigger);
    # Tạo một đường dẫn người dùng tùy chỉnh. Đối tượng của chúng ta sẽ chỉ di chuyển sau khi nút được nhấp.
    $fxUserPath = $seqInter->addEffect($ashp, EffectType::PathUser, EffectSubType::None, EffectTriggerType::OnClick);
    # Thêm các lệnh di chuyển vì đường dẫn đã tạo còn trống.
    $motionBhv = $fxUserPath->getBehaviors()->get_Item(0);
    $pts = new Point2DFloat[1];
    $pts[0] = new Point2DFloat(0.076, 0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, true);
    $pts[0] = new Point2DFloat(-0.076, -0.59);
    $motionBhv->getPath()->add(MotionCommandPathType::LineTo, $pts, MotionPathPointsType::Auto, false);
    $motionBhv->getPath()->add(MotionCommandPathType::End, null, MotionPathPointsType::Auto, false);
    # Ghi tệp PPTX ra đĩa
    $pres->save("AnimExample_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho Shape**

Các ví dụ sau cho bạn thấy cách sử dụng phương thức `getEffectsByShape` từ lớp [Sequence](https://reference.aspose.com/slides/vi/php-java/aspose.slides/sequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho một hình dạng.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một shape trên slide bình thường**

Trước đây, bạn đã học cách thêm các hiệu ứng hoạt ảnh vào shape trong bản thuyết trình PowerPoint. Đoạn mã mẫu dưới đây cho bạn thấy cách lấy các hiệu ứng đã áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bản thuyết trình `AnimExample_out.pptx`.

```php
  $Array = new java_class("java.lang.reflect.Array");
  $presentation = new Presentation("AnimExample_out.pptx");

  try {
    $firstSlide = $presentation->getSlides()->get_Item(0);

    # Lấy chuỗi hoạt ảnh chính của slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();

    # Lấy shape đầu tiên trên slide đầu tiên.
    $shape = $firstSlide->getShapes()->get_Item(0);

    # Lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape.
    $shapeEffects = $sequence->getEffectsByShape($shape);

    if (java_values($Array->getLength($shapeEffects)) > 0) {
      echo("The shape " . $shape->getName() . " has " . $Array->getLength($shapeEffects) . " animation effects.");
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm những hiệu ứng kế thừa từ placeholder**

Nếu một shape trên slide bình thường có placeholder nằm trên slide bố trí và/hoặc slide mẫu, và các hiệu ứng hoạt ảnh đã được thêm vào các placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong buổi trình chiếu, bao gồm các hiệu ứng kế thừa từ placeholder.

Giả sử chúng ta có một tệp bản thuyết trình PowerPoint `sample.pptx` với một slide chứa duy nhất một shape chân trang có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** được áp dụng cho shape này.

![Hiệu ứng hoạt ảnh shape trên slide](slide-shape-animation.png)

Giả sử nữa rằng hiệu ứng **Split** được áp dụng cho placeholder chân trang trên slide **layout**.

![Hiệu ứng hoạt ảnh shape trên layout](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** được áp dụng cho placeholder chân trang trên slide **master**.

![Hiệu ứng hoạt ảnh shape trên master](master-shape-animation.png)

Đoạn mã mẫu dưới đây cho bạn cách sử dụng phương thức `getBasePlaceholder` từ lớp [Shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape chân trang, bao gồm cả những hiệu ứng kế thừa từ placeholder nằm trên slide layout và master.

```php
$presentation = new Presentation("sample.pptx");

$slide = $presentation->getSlides()->get_Item(0);

// Lấy các hiệu ứng hoạt ảnh của shape trên slide bình thường.
$shape = $slide->getShapes()->get_Item(0);
$shapeEffects = $slide->getTimeline()->getMainSequence()->getEffectsByShape($shape);

// Lấy các hiệu ứng hoạt ảnh của placeholder trên slide layout.
$layoutShape = $shape->getBasePlaceholder();
$layoutShapeEffects = $slide->getLayoutSlide()->getTimeline()->getMainSequence()->getEffectsByShape($layoutShape);

// Lấy các hiệu ứng hoạt ảnh của placeholder trên slide master.
$masterShape = $layoutShape->getBasePlaceholder();
$masterShapeEffects = $slide->getLayoutSlide()->getMasterSlide()->getTimeline()->getMainSequence()->getEffectsByShape($masterShape);

echo "Main sequence of shape effects:" . PHP_EOL;
printEffects($masterShapeEffects);
printEffects($layoutShapeEffects);
printEffects($shapeEffects);

$presentation->dispose();
```
```php
function printEffects($effects) {
    foreach ($effects as $effect) {
        echo "Type: " . $effect->getType() . ", subtype: " . $effect->getSubtype() . PHP_EOL;
    }
}
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Bay, Dưới
Type: 134, subtype: 45            // Tách, Dọc vào
Type: 126, subtype: 22            // Thanh ngẫu nhiên, Ngang
```

## **Phương thức thay đổi thời gian hiệu ứng hoạt ảnh**

Aspose.Slides for PHP via Java cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Timing của hoạt ảnh trong Microsoft PowerPoint:

![example1_image](shape-animation.png)

Đây là các tương quan giữa Timing của PowerPoint và các thuộc tính [Effect Timing](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#getTiming):

- Danh sách thả xuống **Start** của PowerPoint tương ứng với phương thức [Timing::getTriggerType](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/#getTriggerType).
- **Duration** của PowerPoint tương ứng với phương thức [Timing::getDuration](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/#getDuration). Thời lượng của một hoạt ảnh (theo giây) là tổng thời gian hoạt ảnh hoàn thành một chu kỳ.
- **Delay** của PowerPoint tương ứng với phương thức [Timing::getTriggerDelayTime](https://reference.aspose.com/slides/vi/php-java/aspose.slides/timing/#getTriggerDelayTime).

Đây là cách bạn thay đổi các thuộc tính Timing của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới bạn cần bằng phương thức [Effect::getTiming](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#getTiming).
3. Lưu tệp PPTX đã chỉnh sửa.

Đoạn mã PHP này minh họa quy trình:

```php
  # Khởi tạo một lớp Presentation đại diện cho tệp trình bày.
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Lấy chuỗi chính của slide.
    $sequence = $pres->getSlides()->get_Item(0)->getTimeline()->getMainSequence();
    # Lấy hiệu ứng đầu tiên của chuỗi chính.
    $effect = $sequence->get_Item(0);
    # Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấp.
    $effect->getTiming()->setTriggerType(EffectTriggerType::OnClick);
    # Thay đổi Duration của hiệu ứng.
    $effect->getTiming()->setDuration(3.0);
    # Thay đổi TriggerDelayTime của hiệu ứng.
    $effect->getTiming()->setTriggerDelayTime(0.5);
    # Lưu tệp PPTX ra đĩa.
    $pres->save("AnimExample_changed.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Âm thanh cho hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các phương thức sau để cho phép bạn làm việc với âm thanh trong các hiệu ứng hoạt ảnh: 

- [setSound(IAudio value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-)
- [setStopPreviousSound(boolean value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setStopPreviousSound-boolean-)

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Đoạn mã PHP này cho bạn cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```php
  $pres = new Presentation("AnimExample_out.pptx");
  try {
    # Thêm âm thanh vào bộ sưu tập âm thanh của bản thuyết trình
$Array = new JavaClass("java.lang.reflect.Array");
$Byte = (new JavaClass("java.lang.Byte"))->TYPE;
try {
    $dis = new Java("java.io.DataInputStream", new Java("java.io.FileInputStream", "sampleaudio.wav"));
    $bytes = $Array->newInstance($Byte, $dis->available());
    $dis->readFully($bytes);
} finally {
    if (!java_is_null($dis)) $dis->close();
}
    $effectSound = $pres->getAudios()->addAudio($bytes);

    $firstSlide = $pres->getSlides()->get_Item(0);
    # Lấy chuỗi chính của slide.
    $sequence = $firstSlide->getTimeline()->getMainSequence();
    # Lấy hiệu ứng đầu tiên của chuỗi chính
    $firstEffect = $sequence->get_Item(0);
    # Kiểm tra hiệu ứng cho "No Sound"
    if (java_is_null(!$firstEffect->getStopPreviousSound() && $firstEffect->getSound())) {
      # Thêm âm thanh cho hiệu ứng đầu tiên
      $firstEffect->setSound($effectSound);
    }
    # Lấy chuỗi tương tác đầu tiên của slide.
    $interactiveSequence = $firstSlide->getTimeline()->getInteractiveSequences()->get_Item(0);
    # Đặt cờ "Stop previous sound" cho hiệu ứng
    $interactiveSequence->get_Item(0)->setStopPreviousSound(true);
    # Ghi tệp PPTX ra đĩa
    $pres->save("AnimExample_Sound_out.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

### **Trích xuất âm thanh từ hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/presentation/) .
2. Lấy tham chiếu slide thông qua chỉ mục của nó. 
3. Lấy chuỗi chính của các hiệu ứng. 
4. Trích xuất phương thức [setSound(IAudio value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setSound-com.aspose.slides.IAudio-) được nhúng vào mỗi hiệu ứng hoạt ảnh.

Đoạn mã PHP này cho bạn cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```php
  # Khởi tạo một lớp presentation đại diện cho tệp trình bày.
  $presentation = new Presentation("EffectSound.pptx");
  try {
    $slide = $presentation->getSlides()->get_Item(0);
    # Lấy chuỗi chính của slide.
    $sequence = $slide->getTimeline()->getMainSequence();
    foreach($sequence as $effect) {
      if (java_is_null($effect->getSound())) {
        continue;
      }
      # Trích xuất âm thanh của hiệu ứng dưới dạng mảng byte
      $audio = $effect->getSound()->getBinaryData();
    }
  } finally {
    if (!java_is_null($presentation)) {
      $presentation->dispose();
    }
  }
```

## **After Animation**

Aspose.Slides for PHP via Java cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Effect và menu mở rộng trong Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint tương ứng với các phương thức sau: 

- Phương thức [setAfterAnimationType(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setAfterAnimationType) mô tả kiểu After animation:
  * **More Colors** của PowerPoint tương ứng với kiểu [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/#Color);
  * Mục **Don't Dim** của PowerPoint tương ứng với kiểu [AfterAnimationType::DoNotDim](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/#DoNotDim) (kiểu After animation mặc định);
  * Mục **Hide After Animation** của PowerPoint tương ứng với kiểu [AfterAnimationType::HideAfterAnimation](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/#HideAfterAnimation);
  * Mục **Hide on Next Mouse Click** của PowerPoint tương ứng với kiểu [AfterAnimationType::HideOnNextMouseClick](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/#HideOnNextMouseClick);
- Phương thức [setAfterAnimationColor(IColorFormat value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setAfterAnimationColor) xác định định dạng màu sau hoạt ảnh. Phương thức này hoạt động cùng với kiểu [AfterAnimationType::Color](https://reference.aspose.com/slides/vi/php-java/aspose.slides/afteranimationtype/#Color). Nếu bạn thay đổi kiểu sang khác, màu after animation sẽ bị xoá.

Đoạn mã PHP này cho bạn cách thay đổi một hiệu ứng after animation:

```php
  # Khởi tạo một lớp presentation đại diện cho tệp trình bày
  $pres = new Presentation("AnimImage_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Lấy hiệu ứng đầu tiên của chuỗi chính
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Thay đổi kiểu after animation thành Color
    $firstEffect->setAfterAnimationType(AfterAnimationType::Color);
    # Đặt màu dim cho after animation
    $firstEffect->getAfterAnimationColor()->setColor(java("java.awt.Color")->BLUE);
    # Ghi tệp PPTX ra đĩa
    $pres->save("AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Animate Text**

Aspose.Slides cung cấp các phương thức sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setAnimateTextType) mô tả kiểu animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh:
  - Cả một lúc ([AnimateTextType::AllAtOnce](https://reference.aspose.com/slides/vi/php-java/aspose.slides/animatetexttype/#AllAtOnce))
  - Theo từ ([AnimateTextType::ByWord](https://reference.aspose.com/slides/vi/php-java/aspose.slides/animatetexttype/#ByWord))
  - Theo ký tự ([AnimateTextType::ByLetter](https://reference.aspose.com/slides/vi/php-java/aspose.slides/animatetexttype/#ByLetter))
- [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setDelayBetweenTextParts) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương xác định phần trăm thời lượng hiệu ứng. Giá trị âm xác định độ trễ tính bằng giây.

Đây là cách bạn có thể thay đổi các thuộc tính Animate text của Effect:

1. [Áp dụng](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Sử dụng phương thức [setBuildType(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/textanimation/#setBuildType) và giá trị [BuildType::AsOneObject](https://reference.aspose.com/slides/vi/php-java/aspose.slides/buildtype/#AsOneObject) để tắt chế độ hoạt ảnh *By Paragraphs*.
3. Đặt các giá trị mới bằng các phương thức [setAnimateTextType(int value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setAnimateTextType) và [setDelayBetweenTextParts(float value)](https://reference.aspose.com/slides/vi/php-java/aspose.slides/effect/#setDelayBetweenTextParts).
4. Lưu tệp PPTX đã chỉnh sửa.

Đoạn mã PHP này minh họa quy trình:

```php
  # Khởi tạo một lớp presentation đại diện cho tệp trình bày.
  $pres = new Presentation("AnimTextBox_out.pptx");
  try {
    $firstSlide = $pres->getSlides()->get_Item(0);
    # Lấy hiệu ứng đầu tiên của chuỗi chính
    $firstEffect = $firstSlide->getTimeline()->getMainSequence()->get_Item(0);
    # Thay đổi kiểu hoạt ảnh Text của hiệu ứng thành "As One Object"
    $firstEffect->getTextAnimation()->setBuildType(BuildType::AsOneObject);
    # Thay đổi kiểu Animate text của hiệu ứng thành "By word"
    $firstEffect->setAnimateTextType(AnimateTextType::ByWord);
    # Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
    $firstEffect->setDelayBetweenTextParts(20.0);
    # Ghi tệp PPTX ra đĩa
    $pres->save("AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
  } finally {
    if (!java_is_null($pres)) {
      $pres->dispose();
    }
  }
```

## **Câu hỏi thường gặp**

**Làm sao tôi có thể đảm bảo hoạt ảnh được giữ lại khi xuất bản bài thuyết trình lên web?**

[Export to HTML5](/slides/vi/php-java/export-to-html5/) và bật các [tùy chọn](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimateshapes/) và [transition](https://reference.aspose.com/slides/vi/php-java/aspose.slides/html5options/setanimatetransitions/). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có thể.

**Thay đổi thứ tự z-order (thứ tự lớp) của các shape ảnh hưởng như thế nào đến hoạt ảnh?**

Thứ tự hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng điều khiển thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/php-java/aspose.slides/shape/getzorderposition/) quyết định gì phủ lên gì. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic tương tự.)

**Có hạn chế nào khi chuyển đổi hoạt ảnh sang video đối với một số hiệu ứng không?**

Nhìn chung, [các hoạt ảnh đều được hỗ trợ](/slides/vi/php-java/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc với các hiệu ứng cụ thể có thể được hiển thị khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn sử dụng và với phiên bản thư viện hiện tại.