---
title: "Áp dụng hoạt ảnh Shape trong bài thuyết trình bằng C++"
linktitle: "Hoạt ảnh Shape"
type: docs
weight: 60
url: /vi/cpp/shape-animation/
keywords:
  - "hình dạng"
  - "hoạt ảnh"
  - "hiệu ứng"
  - "hình dạng hoạt ảnh"
  - "văn bản hoạt ảnh"
  - "thêm hoạt ảnh"
  - "lấy hoạt ảnh"
  - "trích xuất hoạt ảnh"
  - "thêm hiệu ứng"
  - "lấy hiệu ứng"
  - "trích xuất hiệu ứng"
  - "âm thanh hiệu ứng"
  - "áp dụng hoạt ảnh"
  - "PowerPoint"
  - "bài thuyết trình"
  - "C++"
  - "Aspose.Slides"
description: "Khám phá cách tạo và tùy chỉnh hoạt ảnh shape trong các bài thuyết trình PowerPoint với Aspose.Slides cho C++. Nổi bật!"
---
## **Giới thiệu**

Hoạt ảnh là các hiệu ứng trực quan có thể áp dụng cho văn bản, hình ảnh, hình dạng hoặc [đồ thị](/slides/vi/cpp/animated-charts/). Chúng mang lại sinh khí cho các bài thuyết trình hoặc các thành phần của chúng. 

## **Tại sao nên sử dụng hoạt ảnh trong bài thuyết trình?**

Sử dụng hoạt ảnh, bạn có thể 

* kiểm soát luồng thông tin
* nhấn mạnh các điểm quan trọng
* tăng sự quan tâm hoặc tham gia của khán giả
* làm cho nội dung dễ đọc, tiếp thu hoặc xử lý hơn
* thu hút sự chú ý của người đọc hoặc người xem tới các phần quan trọng trong bài thuyết trình

PowerPoint cung cấp nhiều tùy chọn và công cụ cho hoạt ảnh và các hiệu ứng hoạt ảnh trong các danh mục **entrance**, **exit**, **emphasis** và **motion paths**. 

## **Hoạt ảnh trong Aspose.Slides**

* Aspose.Slides cung cấp các lớp và kiểu cần thiết để làm việc với hoạt ảnh dưới không gian tên [Aspose.Slides.Animation](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation),
* Aspose.Slides cung cấp hơn **150 hiệu ứng hoạt ảnh** dưới enumeration [EffectType](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#ae0da11508d382465aa4e7a011df1bf31). Những hiệu ứng này về cơ bản là các hiệu ứng (hoặc tương đương) được sử dụng trong PowerPoint.

## **Áp dụng hoạt ảnh cho TextBox**

Aspose.Slides for C++ cho phép bạn áp dụng hoạt ảnh cho văn bản trong một shape. 

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape). 
4. Thêm văn bản vào [IAutoShape.TextFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape#afb267108fea5ee5a213c162c004fcef3).
5. Lấy chuỗi chính của các hiệu ứng.
6. Thêm một hiệu ứng hoạt ảnh vào [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape). 
7. Đặt thuộc tính [TextAnimation.BuildType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.text_animation#afa90da088213f947baf64f8cdddd18b8) thành giá trị từ enumeration [BuildType](https://reference.aspose.com/slides/vi/cpp/namespace/aspose.slides.animation#a1b0f1615881ac05b1a72c670a125b8e7).
8. Ghi bài thuyết trình ra đĩa dưới dạng file PPTX.

Mã C++ này cho thấy cách áp dụng hiệu ứng `Fade` cho AutoShape và đặt hoạt ảnh văn bản thành giá trị *By 1st Level Paragraphs*:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

System::SharedPtr<ISlide> sld = pres->get_Slides()->idx_get(0);

// Thêm AutoShape mới với văn bản
System::SharedPtr<IAutoShape> autoShape =
    sld->get_Shapes()->AddAutoShape(Aspose::Slides::ShapeType::Rectangle, 20.0f, 20.0f, 150.0f, 100.0f);

System::SharedPtr<ITextFrame> textFrame = autoShape->get_TextFrame();
textFrame->set_Text(u"First paragraph \nSecond paragraph \n Third paragraph");

// Lấy chuỗi chính của slide.
System::SharedPtr<ISequence> sequence = sld->get_Timeline()->get_MainSequence();

// Thêm hiệu ứng hoạt ảnh Fade vào shape
System::SharedPtr<IEffect> effect = sequence->AddEffect(autoShape, Aspose::Slides::Animation::EffectType::Fade,
    Aspose::Slides::Animation::EffectSubtype::None, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Hoạt ảnh văn bản shape theo các đoạn cấp độ 1
effect->get_TextAnimation()->set_BuildType(Aspose::Slides::Animation::BuildType::ByLevelParagraphs1);

// Lưu tệp PPTX vào đĩa
pres->Save(path + u"AnimText_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

{{%  alert color="primary"  %}} 

Ngoài việc áp dụng hoạt ảnh cho văn bản, bạn cũng có thể áp dụng hoạt ảnh cho một [Paragraph](/slides/vi/cpp/animated-text/) duy nhất. Xem [**Animated Text**](/slides/vi/cpp/animated-text/).

{{% /alert %}} 

## **Áp dụng hoạt ảnh cho PictureFrame**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm hoặc lấy một [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_picture_frame) trên slide. 
4. Lấy chuỗi chính của các hiệu ứng.
5. Thêm một hiệu ứng hoạt ảnh vào [PictureFrame](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_picture_frame).
6. Ghi bài thuyết trình ra đĩa dưới dạng file PPTX.

Mã C++ này cho thấy cách áp dụng hiệu ứng `Fly` cho một picture frame:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>();

// Tải hình ảnh để thêm vào bộ sưu tập ảnh của trình chiếu
System::SharedPtr<IImage> img = Images::FromFile(u"aspose-logo.jpg");
System::SharedPtr<IPPImage> image = pres->get_Images()->AddImage(img);

// Thêm khung ảnh vào slide
System::SharedPtr<IPictureFrame> picFrame =
    pres->get_Slides()->idx_get(0)->get_Shapes()->AddPictureFrame(Aspose::Slides::ShapeType::Rectangle, 50.0f, 50.0f, 100.0f, 100.0f, image);

// Lấy chuỗi chính của slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Thêm hiệu ứng Fly từ bên trái vào khung ảnh
System::SharedPtr<IEffect> effect = sequence->AddEffect(picFrame, Aspose::Slides::Animation::EffectType::Fly,
    Aspose::Slides::Animation::EffectSubtype::Left, Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Lưu tệp PPTX vào đĩa
pres->Save(path + u"AnimImage_out.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Áp dụng hoạt ảnh cho Shape**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.presentation/).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó.
3. Thêm một `rectangle` [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape). 
4. Thêm một `Bevel` [IAutoShape](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.i_auto_shape) (khi đối tượng này được nhấp, hoạt ảnh sẽ được phát).
5. Tạo một chuỗi các hiệu ứng trên shape bevel.
6. Tạo một `UserPath` tùy chỉnh.
7. Thêm các lệnh di chuyển tới `UserPath`.
8. Ghi bài thuyết trình ra đĩa dưới dạng file PPTX.

Mã C++ này cho thấy cách áp dụng hiệu ứng `PathFootball` (đường đi bóng đá) cho một shape:

```c++
	// Đường dẫn tới thư mục tài liệu.
	const String outPath = u"../out/AnimationsOnShapes_out.pptx";
	const String templatePath = u"../templates/ConnectorLineAngle.pptx";

	// Tải bài thuyết trình
	SharedPtr<Presentation> pres = MakeObject<Presentation>();

	// Truy cập slide đầu tiên
	SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);

	// Truy cập bộ sưu tập shape của slide đã chọn
	SharedPtr<IShapeCollection> shapes = slide->get_Shapes();

	// Tạo hiệu ứng PathFootball cho shape hiện có từ đầu.
	SharedPtr<IAutoShape> ashp = slide->get_Shapes()->AddAutoShape(ShapeType::Rectangle, 150, 150, 250, 25);

	ashp->AddTextFrame(u"Animated TextBox");

	// Thêm hiệu ứng PathFootBall
	slide->get_Timeline()->get_MainSequence()->AddEffect(ashp, EffectType::PathFootball,
		EffectSubtype::None, EffectTriggerType::AfterPrevious);

	// Tạo một loại "button".
	SharedPtr<IAutoShape> shapeTrigger = slide->get_Shapes()->AddAutoShape(ShapeType::Bevel, 10, 10, 20, 20);

	// Tạo một chuỗi các hiệu ứng cho nút này.
	SharedPtr<ISequence> seqInter = slide->get_Timeline()->get_InteractiveSequences()->Add(shapeTrigger);
	
	 // Tạo một đường người dùng tùy chỉnh. Đối tượng của chúng ta sẽ di chuyển chỉ sau khi nút được nhấp.
	SharedPtr<IEffect> fxUserPath = seqInter->AddEffect(ashp, EffectType::PathUser, EffectSubtype::None, EffectTriggerType::OnClick);

	// Thêm các lệnh di chuyển vì đường đã tạo hiện đang rỗng.
	 SharedPtr<MotionEffect> motionBhv = ExplicitCast<MotionEffect>(fxUserPath->get_Behaviors()->idx_get(0));

	// SharedPtr<PointF> point = MakeObject<PointF >(0.076, 0.59);
	 const PointF point = PointF (0.076, 0.59);
	 System::ArrayPtr<PointF> pts = System::MakeObject<System::Array<PointF>>(1, point);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts, MotionPathPointsType::Auto, true);
	 
	 //PointF point2[1] = { -0.076, -0.59 };
	const  PointF point2 = PointF(-0.076, -0.59 );

	 System::ArrayPtr<PointF> pts2 = System::MakeObject<System::Array<PointF>>(1, point2);
	 motionBhv->get_Path()->Add(MotionCommandPathType::LineTo, pts2, MotionPathPointsType::Auto, false);
	 
	 motionBhv->get_Path()->Add(MotionCommandPathType::End, nullptr, MotionPathPointsType::Auto, false);
	 
	 //Ghi tệp PPTX vào đĩa
	 pres->Save(outPath, Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Lấy các hiệu ứng hoạt ảnh đã áp dụng cho Shape**

Các ví dụ sau cho thấy cách sử dụng phương thức `GetEffectsByShape` từ giao diện [ISequence](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/isequence/) để lấy tất cả các hiệu ứng hoạt ảnh đã áp dụng cho một shape.

**Ví dụ 1: Lấy các hiệu ứng hoạt ảnh đã áp dụng cho một shape trên slide bình thường**

Trước đây, bạn đã học cách thêm các hiệu ứng hoạt ảnh vào các shape trong bài thuyết trình PowerPoint. Mã mẫu dưới đây cho thấy cách lấy các hiệu ứng đã được áp dụng cho shape đầu tiên trên slide bình thường đầu tiên trong bài thuyết trình `AnimExample_out.pptx`.

```c++
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"AnimExample_out.pptx");

SharedPtr<ISlide> firstSlide = presentation->get_Slide(0);

// Gets the main animation sequence of the slide.
SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Gets the first shape on the first slide.
SharedPtr<IShape> shape = firstSlide->get_Shape(0);

// Gets animation effects applied to the shape.
ArrayPtr<SharedPtr<IEffect>> shapeEffects = sequence->GetEffectsByShape(shape);

if (shapeEffects->get_Length() > 0)
{
    Console::WriteLine(u"The shape " + shape->get_Name() + u" has " + shapeEffects->get_Length() + u" animation effects.");
}

presentation->Dispose();
```

**Ví dụ 2: Lấy tất cả các hiệu ứng hoạt ảnh, bao gồm cả những hiệu ứng kế thừa từ placeholder**

Nếu một shape trên slide bình thường có placeholder nằm trên layout slide và/hoặc master slide, và các hiệu ứng hoạt ảnh đã được thêm vào các placeholder này, thì tất cả các hiệu ứng của shape sẽ được phát trong khi trình diễn, bao gồm cả những hiệu ứng kế thừa từ placeholder.

Giả sử chúng ta có một tệp PowerPoint `sample.pptx` với một slide chỉ chứa một shape footer có văn bản "Made with Aspose.Slides" và hiệu ứng **Random Bars** được áp dụng cho shape.

![Slide shape animation effect](slide-shape-animation.png)

Giả sử nữa rằng hiệu ứng **Split** được áp dụng cho placeholder footer trên slide **layout**.

![Layout shape animation effect](layout-shape-animation.png)

Và cuối cùng, hiệu ứng **Fly In** được áp dụng cho placeholder footer trên slide **master**.

![Master shape animation effect](master-shape-animation.png)

Mã mẫu dưới đây cho thấy cách sử dụng phương thức `GetBasePlaceholder` từ giao diện [IShape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.ishape/) để truy cập các placeholder của shape và lấy các hiệu ứng hoạt ảnh đã áp dụng cho shape footer, bao gồm cả những hiệu ứng kế thừa từ placeholder trên layout và master slide.

```cpp
void PrintEffects(ArrayPtr<SharedPtr<IEffect>> effects)
{
    for (SharedPtr<IEffect> effect : effects)
    {
        Console::WriteLine(String::Format(u"Type: {0}, subtype: {1}", effect->get_Type(), effect->get_Subtype()));
    }
}
```
```cpp
SharedPtr<Presentation> presentation = MakeObject<Presentation>(u"sample.pptx");

SharedPtr<ISlide> slide = presentation->get_Slide(0);

// Lấy các hiệu ứng hoạt ảnh của shape trên slide bình thường.
SharedPtr<IShape> shape = slide->get_Shape(0);
ArrayPtr<SharedPtr<IEffect>> shapeEffects = slide->get_Timeline()->get_MainSequence()->GetEffectsByShape(shape);

// Lấy các hiệu ứng hoạt ảnh của placeholder trên slide layout.
SharedPtr<IShape> layoutShape = shape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> layoutShapeEffects = slide->get_LayoutSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(layoutShape);

// Lấy các hiệu ứng hoạt ảnh của placeholder trên slide master.
SharedPtr<IShape> masterShape = layoutShape->GetBasePlaceholder();
ArrayPtr<SharedPtr<IEffect>> masterShapeEffects = slide->get_LayoutSlide()->get_MasterSlide()->get_Timeline()->get_MainSequence()->GetEffectsByShape(masterShape);

presentation->Dispose();

Console::WriteLine(u"Main sequence of shape effects:");
PrintEffects(masterShapeEffects);
PrintEffects(layoutShapeEffects);
PrintEffects(shapeEffects);
```

Output:
```text
Main sequence of shape effects:
Type: 47, subtype: 2              // Fly, Bottom
Type: 134, subtype: 45            // Split, VerticalIn
Type: 126, subtype: 22            // RandomBars, Horizontal
```

## **Thay đổi thuộc tính thời gian của hiệu ứng hoạt ảnh**

Aspose.Slides for C++ cho phép bạn thay đổi các thuộc tính Timing của một hiệu ứng hoạt ảnh.

Đây là bảng Timing của Animation trong Microsoft PowerPoint:

![example1_image](shape-animation.png)

Các tương quan giữa Timing của PowerPoint và thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) như sau:

- Danh sách thả xuống **Start** của PowerPoint tương ứng với thuộc tính [Effect.Timing.TriggerType](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.i_timing#a9cec24d555c39e33f0b71dc2210daab3). 
- **Duration** của PowerPoint tương ứng với thuộc tính [Effect.Timing.Duration](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.i_timing#a4f5eebdec3b0b2e6d57ee944b5a8a340). Thời lượng của một hoạt ảnh (giây) là tổng thời gian hoạt ảnh cần để hoàn thành một chu kỳ. 
- **Delay** của PowerPoint tương ứng với thuộc tính [Effect.Timing.TriggerDelayTime](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.i_timing#a947ac2f79c7310d0276ef17999b7214b). 

Cách thay đổi các thuộc tính Timing của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt các giá trị mới cho các thuộc tính [Effect.Timing](https://reference.aspose.com/slides/vi/cpp/class/aspose.slides.animation.effect#a333640cbb8d32c413ccda11c1a7c3b4c) mà bạn cần. 
3. Lưu file PPTX đã sửa đổi.

Mã C++ này minh họa thao tác:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp bài thuyết trình.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Lấy chuỗi chính của slide.
System::SharedPtr<ISequence> sequence = pres->get_Slides()->idx_get(0)->get_Timeline()->get_MainSequence();

// Lấy hiệu ứng đầu tiên của chuỗi chính.
System::SharedPtr<IEffect> effect = sequence->idx_get(0);

// Thay đổi TriggerType của hiệu ứng để bắt đầu khi nhấp
effect->get_Timing()->set_TriggerType(Aspose::Slides::Animation::EffectTriggerType::OnClick);

// Thay đổi Duration của hiệu ứng
effect->get_Timing()->set_Duration(3.f);

// Thay đổi TriggerDelayTime của hiệu ứng
effect->get_Timing()->set_TriggerDelayTime(0.5f);

// Lưu tệp PPTX vào đĩa
pres->Save(u"AnimExample_changed.pptx", Aspose::Slides::Export::SaveFormat::Pptx);
```

## **Âm thanh của hiệu ứng hoạt ảnh**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với âm thanh trong hiệu ứng hoạt ảnh: 

- [set_Sound()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effect/set_sound/) 
- [set_StopPreviousSound()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effect/set_stopprevioussound/) 

### **Thêm âm thanh cho hiệu ứng hoạt ảnh**

Mã C++ này cho thấy cách thêm âm thanh cho một hiệu ứng hoạt ảnh và dừng nó khi hiệu ứng tiếp theo bắt đầu:

```c++
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimExample_out.pptx");

// Thêm âm thanh vào bộ sưu tập âm thanh của bài thuyết trình
System::SharedPtr<IAudio> effectSound = pres->get_Audios()->AddAudio(System::IO::File::ReadAllBytes(u"sampleaudio.wav"));
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lấy chuỗi chính của slide.
System::SharedPtr<ISequence> sequence = firstSlide->get_Timeline()->get_MainSequence();

// Lấy hiệu ứng đầu tiên của chuỗi chính
System::SharedPtr<IEffect> firstEffect = sequence->idx_get(0);

// Kiểm tra hiệu ứng cho "No Sound"
if (!firstEffect->get_StopPreviousSound() && firstEffect->get_Sound() == nullptr)
{
    // Thêm âm thanh cho hiệu ứng đầu tiên
    firstEffect->set_Sound(effectSound);
}

// Lấy chuỗi tương tác đầu tiên của slide.
System::SharedPtr<ISequence> interactiveSequence = firstSlide->get_Timeline()->get_InteractiveSequence(0);

// Đặt cờ "Stop previous sound" cho hiệu ứng
interactiveSequence->idx_get(0)->set_StopPreviousSound(true);

// Ghi tệp PPTX vào đĩa
pres->Save(u"AnimExample_Sound_out.pptx", SaveFormat::Pptx);
```

### **Trích xuất âm thanh của hiệu ứng hoạt ảnh**

1. Tạo một thể hiện của lớp [Presentation](https://reference.aspose.com/slides/vi/cpp/aspose.slides/presentation/).
2. Lấy tham chiếu tới slide thông qua chỉ mục của nó. 
3. Lấy chuỗi chính của các hiệu ứng. 
4. Trích xuất phương thức [set_Sound()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/effect/set_sound/) được nhúng vào mỗi hiệu ứng hoạt ảnh. 

Mã C++ này cho thấy cách trích xuất âm thanh được nhúng trong một hiệu ứng hoạt ảnh:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"EffectSound.pptx");
System::SharedPtr<ISlide> slide = pres->get_Slide(0);

// Lấy chuỗi chính của slide.
System::SharedPtr<ISequence> sequence = slide->get_Timeline()->get_MainSequence();

for (auto&& effect : sequence)
{
    System::SharedPtr<IAudio> sound = effect->get_Sound();

    if (sound == nullptr)
        continue;

    auto audio = sound->get_BinaryData();
}
```

## **Sau khi hoạt ảnh**

Aspose.Slides for C++ cho phép bạn thay đổi thuộc tính After animation của một hiệu ứng hoạt ảnh.

Đây là bảng Animation Effect và menu mở rộng trong Microsoft PowerPoint:

![example1_image](shape-after-animation.png)

Danh sách thả xuống **After animation** của PowerPoint tương ứng với các thuộc tính sau: 

- Thuộc tính [set_AfterAnimationType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_afteranimationtype/) mô tả kiểu After animation :
  * **More Colors** của PowerPoint tương ứng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Mục **Don't Dim** của PowerPoint tương ứng với kiểu [AfterAnimationType.DoNotDim](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) (kiểu After animation mặc định);
  * Mục **Hide After Animation** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideAfterAnimation](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) ;
  * Mục **Hide on Next Mouse Click** của PowerPoint tương ứng với kiểu [AfterAnimationType.HideOnNextMouseClick](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/) ;
- Thuộc tính [set_AfterAnimationColor()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_afteranimationcolor/) định nghĩa định dạng màu After animation. Thuộc tính này hoạt động cùng với kiểu [AfterAnimationType.Color](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/afteranimationtype/). Nếu bạn thay đổi kiểu sang kiểu khác, màu After animation sẽ bị xóa.

Mã C++ này cho thấy cách thay đổi hiệu ứng After animation:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimImage_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lấy hiệu ứng đầu tiên của chuỗi chính
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Thay đổi loại after animation thành Color
firstEffect->set_AfterAnimationType(AfterAnimationType::Color);

// Đặt màu after animation dim
firstEffect->get_AfterAnimationColor()->set_Color(System::Drawing::Color::get_AliceBlue());

// Ghi tệp PPTX vào đĩa
pres->Save(u"AnimImage_AfterAnimation.pptx", SaveFormat::Pptx);
```

## **Hoạt ảnh văn bản**

Aspose.Slides cung cấp các thuộc tính sau để cho phép bạn làm việc với khối *Animate text* của một hiệu ứng hoạt ảnh:

- [set_AnimateTextType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) mô tả kiểu animate text của hiệu ứng. Văn bản của shape có thể được hoạt ảnh:
  - Tất cả cùng một lúc ([AnimateTextType.AllAtOnce](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/animatetexttype/) )
  - Theo từ ([AnimateTextType.ByWord](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/animatetexttype/) )
  - Theo ký tự ([AnimateTextType.ByLetter](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/animatetexttype/) )
- [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/) đặt độ trễ giữa các phần văn bản được hoạt ảnh (từ hoặc ký tự). Giá trị dương chỉ phần trăm thời lượng hiệu ứng. Giá trị âm chỉ thời gian trễ tính bằng giây.

Cách thay đổi các thuộc tính Animate text của Effect:

1. [Apply](#apply-animation-to-shape) hoặc lấy hiệu ứng hoạt ảnh.
2. Đặt thuộc tính [set_BuildType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation.itextanimation/set_buildtype/) thành giá trị [BuildType.AsOneObject](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/buildtype/) để tắt chế độ *By Paragraphs*.
3. Đặt các giá trị mới cho các thuộc tính [set_AnimateTextType()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_animatetexttype/) và [set_DelayBetweenTextParts()](https://reference.aspose.com/slides/vi/cpp/aspose.slides.animation/ieffect/set_delaybetweentextparts/).
4. Lưu file PPTX đã sửa đổi.

Mã C++ này minh họa thao tác:

```c++
// Khởi tạo một lớp Presentation đại diện cho tệp trình chiếu.
System::SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"AnimTextBox_out.pptx");
System::SharedPtr<ISlide> firstSlide = pres->get_Slide(0);

// Lấy hiệu ứng đầu tiên của chuỗi chính
System::SharedPtr<IEffect> firstEffect = firstSlide->get_Timeline()->get_MainSequence()->idx_get(0);

// Thay đổi kiểu hoạt ảnh văn bản của hiệu ứng thành "As One Object"
firstEffect->get_TextAnimation()->set_BuildType(BuildType::AsOneObject);

// Thay đổi kiểu Animate text của hiệu ứng thành "By word"
firstEffect->set_AnimateTextType(AnimateTextType::ByWord);

// Đặt độ trễ giữa các từ thành 20% thời lượng hiệu ứng
firstEffect->set_DelayBetweenTextParts(20.0f);

// Ghi tệp PPTX vào đĩa
pres->Save(u"AnimTextBox_AnimateText.pptx", SaveFormat::Pptx);
```

## **FAQ**

**Làm sao tôi có thể đảm bảo hoạt ảnh được giữ nguyên khi xuất bản bài thuyết trình lên web?**

[Export to HTML5](/slides/vi/cpp/export-to-html5/) và bật các [options](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/) chịu trách nhiệm cho hoạt ảnh [shape](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animateshapes/) và [transition](https://reference.aspose.com/slides/vi/cpp/aspose.slides.export/html5options/set_animatetransitions/). HTML thuần không phát hoạt ảnh slide, trong khi HTML5 có.

**Thay đổi thứ tự z-order (thứ tự lớp) của các shape ảnh hưởng như thế nào tới hoạt ảnh?**

Thứ tự hoạt ảnh và thứ tự vẽ là độc lập: một hiệu ứng kiểm soát thời gian và kiểu xuất hiện/biến mất, trong khi [z-order](https://reference.aspose.com/slides/vi/cpp/aspose.slides/shape/get_zorderposition/) quyết định gì che gì. Kết quả hiển thị được xác định bởi sự kết hợp của chúng. (Đây là hành vi chung của PowerPoint; mô hình effects-and-shapes của Aspose.Slides tuân theo logic giống nhau.)

**Có những hạn chế nào khi chuyển hoạt ảnh sang video đối với một số hiệu ứng không?**

Nhìn chung, [animations are supported](/slides/vi/cpp/convert-powerpoint-to-video/), nhưng trong một số trường hợp hiếm hoặc đối với các hiệu ứng cụ thể có thể được render khác nhau. Bạn nên kiểm tra với các hiệu ứng bạn dùng và với phiên bản thư viện hiện tại.