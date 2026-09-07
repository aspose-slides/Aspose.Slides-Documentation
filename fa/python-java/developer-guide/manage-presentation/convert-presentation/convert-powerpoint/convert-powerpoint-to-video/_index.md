---
title: تبدیل ارائه‌های PowerPoint به ویدئو در Python
linktitle: PowerPoint به ویدئو
type: docs
weight: 130
url: /fa/python-java/convert-powerpoint-to-video/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به ویدئو
- ارائه به ویدئو
- PPT به ویدئو
- PPTX به ویدئو
- PowerPoint به MP4
- ارائه به MP4
- PPT به MP4
- PPTX به MP4
- ذخیره PPT به عنوان MP4
- ذخیره PPTX به عنوان MP4
- صادرات PPT به MP4
- صادرات PPTX به MP4
- تبدیل ویدئو
- PowerPoint
- Python
- Java
- Aspose.Slides
description: "تبدیل ارائه‌های PowerPoint به ویدئوی MP4 در Python از طریق Java. فریم‌ها را با Aspose.Slides تولید کنید و با FFmpeg رمزگذاری کنید، شامل انیمیشن‌ها و انتقال‌ها."
---
## **نمای کلی**

تبدیل یک ارائه PowerPoint یا OpenDocument به ویدئو به بینندگان امکان می‌دهد محتوا را در یک پلیر ویدئویی بدون باز کردن برنامهٔ ارائه مشاهده کنند. Aspose.Slides برای Python via Java انیمیشن‌ها و انتقال‌های ارائه را به فریم‌های تصویر تبدیل می‌کند. یک رمزگذار جداگانه، مانند FFmpeg، این فریم‌ها را به یک فایل ویدئویی ترکیب می‌کند.

{{% alert color="info" title="Note" %}}
سعی کنید مبدل آنلاین [PowerPoint to Video converter](https://products.aspose.app/slides/fa/video) را امتحان کنید تا تبدیل ارائه به ویدئو را در عمل ببینید.
{{% /alert %}}

## **تبدیل PowerPoint به Video**

این فرآیند دو مرحله دارد: تولید فریم‌های PNG با نرخ فریم انتخابی، سپس رمزگذاری توالی تصویر به صورت MP4. برای حفظ زمان‌بندی انیمیشن، از همان نرخ فریم در هر دو مرحله استفاده کنید.

قبل از اجرای مثال:

1. نصب [Aspose.Slides برای Python via Java](/slides/fa/python-java/installation/).
2. دانلود [FFmpeg](https://ffmpeg.org/download.html) و اطمینان از این که اجرایی آن در `PATH` در دسترس است. مثال از یک build با رمزگذار `libx264` استفاده می‌کند.
3. کد Python زیر را در یک دایرکتوری قابل نوشتن اجرا کنید.

مثال یک شکل خندان با انیمیشن‌های ورود و خروج ایجاد می‌کند، فریم‌ها را با 30 FPS رندر می‌کند و با FFmpeg فایل `output.mp4` را می‌سازد. یک دایرکتوری فریم تازه از افزودن فریم‌های اجراهای قبلی به ویدئو جلوگیری می‌کند.

```python
import shutil
import subprocess
import tempfile
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectPresetClassType, EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, PresentationPlayer, ShapeType

fps = 30
frames_directory = Path(tempfile.mkdtemp(prefix="video_frames_", dir="."))
frame_count = 0

def save_frame(sender, arguments):
    global frame_count
    frame_path = frames_directory / f"frame_{frame_count:06d}.png"
    frame = arguments.getFrame()
    try:
        frame.save(str(frame_path), ImageFormat.Png)
    finally:
        frame.dispose()
    frame_count += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    entrance = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    entrance.getTiming().setDuration(2.0)
    exit_effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.BottomRight, EffectTriggerType.AfterPrevious)
    exit_effect.setPresetClassType(EffectPresetClassType.Exit)
    exit_effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        player = PresentationPlayer(generator, fps)
        try:
            callback = jpype.JProxy("com.aspose.slides.PresentationPlayer$FrameTick", dict(invoke=save_frame))
            player.setFrameTick(callback)
            generator.run(presentation.getSlides())
        finally:
            player.dispose()
    finally:
        generator.dispose()
finally:
    presentation.dispose()

ffmpeg = shutil.which("ffmpeg")
if frame_count == 0:
    print("No frames were generated.")
elif ffmpeg is None:
    print(f"FFmpeg was not found on PATH. PNG frames are available in {frames_directory}.")
else:
    input_pattern = str(frames_directory / "frame_%06d.png")
    command = [ffmpeg, "-n", "-framerate", str(fps), "-start_number", "0", "-i", input_pattern, "-vf", "pad=ceil(iw/2)*2:ceil(ih/2)*2", "-c:v", "libx264", "-pix_fmt", "yuv420p", "output.mp4"]
    result = subprocess.run(command, check=False)
    if result.returncode == 0:
        print("Saved output.mp4")
    else:
        print(f"FFmpeg failed with exit code {result.returncode}. Frames are available in {frames_directory}.")
```

برای تبدیل یک فایل موجود، [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) را با مسیر آن مقداردهی کنید و خطوط ایجاد شکل و انیمیشن را حذف کنید.

دستور FFmpeg یک [image sequence](https://ffmpeg.org/ffmpeg-formats.html#image2) عددی را می‌خواند، ابعاد فرد را به مقادیر زوج تبدیل می‌کند و ویدئوی H.264 را با فرمت پیکسل `yuv420p` می‌نویسد. گزینه `-n` از نوشتن روی یک فایل خروجی موجود جلوگیری می‌کند. فایل‌های PNG تولید شده در دایرکتوری فریم باقی می‌مانند؛ هنگام عدم نیاز آنها را حذف کنید.

{{% alert color="info" title="Note" %}}
این مثال فقط فریم‌های تصویر را رمزگذاری می‌کند. روایت یا صدای داخلی ارائه به ویدئو اضافه نمی‌شود.
{{% /alert %}}

## **افکت‌های ویدئویی**

انیمیشن‌ها کنترل می‌کنند که اشیا اسلاید چگونه ظاهر، حرکت یا ناپدید شوند. انتقال‌ها تغییر بین اسلایدها را کنترل می‌کنند. این افکت‌ها را قبل از تولید فریم‌های ویدئویی اضافه کنید.

به [PowerPoint Animation](/slides/fa/python-java/powerpoint-animation/)، [Shape Animation](/slides/fa/python-java/shape-animation/)، [Shape Effects](/slides/fa/python-java/shape-effect/) و [Slide Transitions](/slides/fa/python-java/slide-transition/) مراجعه کنید.

### **افزودن یک انتقال اسلاید**

مثال خودکفای زیر یک ارائه با دو اسلاید ایجاد می‌کند. اسلاید دوم پس‌زمینهٔ مِجنتا و یک انتقال push دارد. ارائه را ذخیره کنید، سپس به عنوان ورودی به مثال تولید فریم‌های بالا بدهید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import BackgroundType, FillType, Presentation, SaveFormat, ShapeType, TransitionType

Color = jpype.JClass("java.awt.Color")

presentation = Presentation()
try:
    first_slide = presentation.getSlides().get_Item(0)
    first_slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    new_slide = presentation.getSlides().addEmptySlide(first_slide.getLayoutSlide())
    new_slide.getBackground().setType(BackgroundType.OwnBackground)
    new_slide.getBackground().getFillFormat().setFillType(FillType.Solid)
    new_slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.MAGENTA)
    new_slide.getSlideShowTransition().setType(TransitionType.Push)
    presentation.save("transition.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **انیمیشن پاراگراف‌ها**

متن می‌تواند پاراگراف به پاراگراف ظاهر شود. این مثال سه پاراگراف با افکت‌های ورودی fade متوالی ایجاد می‌کند که هر کدام یک ثانیه پس از افکت قبلی تأخیر دارند. از فایل `paragraphs.pptx` ذخیره‌شده به عنوان ورودی به مثال تبدیل ویدئو استفاده کنید.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, Paragraph, Portion, Presentation, SaveFormat, ShapeType

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 210, 120, 300, 300)
    shape.addTextFrame("")
    paragraphs = shape.getTextFrame().getParagraphs()
    paragraphs.clear()
    sequence = slide.getTimeline().getMainSequence()
    texts = ["Aspose.Slides for Python via Java", "Convert presentation text to video", "Paragraph by paragraph"]

    for text in texts:
        paragraph = Paragraph()
        portion = Portion(text)
        paragraph.getPortions().add(portion)
        paragraphs.add(paragraph)
        effect = sequence.addEffect(paragraph, EffectType.Fade, EffectSubtype.None_, EffectTriggerType.AfterPrevious)
        effect.getTiming().setTriggerDelayTime(1.0)
        effect.getTiming().setDuration(1.0)

    presentation.save("paragraphs.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **کلاس‌های تبدیل ویدئو**

[PresentationAnimationsGenerator](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationanimationsgenerator/) رویدادهای انیمیشن اسلایدها را تولید می‌کند. ساخت آن از یک ارائه از اندازهٔ اسلاید ارائه برای فریم‌ها استفاده می‌کند. برای تنظیم تاخیر پیش‌فرض به میلی‌ثانیه از [setDefaultDelay](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationanimationsgenerator/#setDefaultDelay) استفاده کنید.

[PresentationPlayer](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationplayer/) انیمیشن‌های تولید شده را با نرخ فریمی که به سازنده‌اش می‌دهید نمونه‌برداری می‌کند. با JPype یک callback پایتون را از طریق [setFrameTick](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationplayer/#setFrameTick) ثبت کنید، سپس با [run](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationanimationsgenerator/#run) فریم‌ها را تولید کنید. مثال اول از شمارندهٔ صفر پایهٔ خود استفاده می‌کند تا نام‌فایل‌ها با دنبالهٔ ورودی FFmpeg مطابقت داشته باشند.

برای وضعیت‌های انیمیشن فردی، یک callback با [setNewAnimation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationanimationsgenerator/#setNewAnimation) ثبت کنید. این callback یک پخش‌کنندهٔ انیمیشن دریافت می‌کند که می‌تواند در زمان انتخابی موقعیت‌گیری شود. مثال زیر اولین و آخرین فریم هر انیمیشن تولید شده را با نام‌های منحصر به فرد ذخیره می‌کند:

```python
from pathlib import Path

import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import EffectSubtype, EffectTriggerType, EffectType, ImageFormat, Presentation, PresentationAnimationsGenerator, ShapeType

output_directory = Path("animation_states")
output_directory.mkdir(exist_ok=True)
animation_index = 0

def save_animation_states(animation_player):
    global animation_index
    duration = animation_player.getDuration()
    print(f"Animation {animation_index}: {duration} milliseconds")
    for label, position in [("first", 0.0), ("last", duration)]:
        animation_player.setTimePosition(position)
        frame = animation_player.getFrame()
        try:
            frame_path = output_directory / f"animation_{animation_index:04d}_{label}.png"
            frame.save(str(frame_path), ImageFormat.Png)
        finally:
            frame.dispose()
    animation_index += 1

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    smile = slide.getShapes().addAutoShape(ShapeType.SmileyFace, 110, 20, 500, 500)
    sequence = slide.getTimeline().getMainSequence()
    effect = sequence.addEffect(smile, EffectType.Fly, EffectSubtype.TopLeft, EffectTriggerType.AfterPrevious)
    effect.getTiming().setDuration(2.0)

    generator = PresentationAnimationsGenerator(presentation)
    try:
        callback = jpype.JProxy("com.aspose.slides.PresentationAnimationsGenerator$NewAnimation", dict(invoke=save_animation_states))
        generator.setNewAnimation(callback)
        generator.run(presentation.getSlides())
    finally:
        generator.dispose()
finally:
    presentation.dispose()
```

## **انیمیشن‌ها و افکت‌های پشتیبانی‌شده**

جداول زیر پشتیبانی رندر را که در مقالهٔ تبدیل Java توضیح داده شده است، خلاصه می‌کنند. هنگام استفاده از افکت‌های غیرپشتیبانی‌شده در یک ارائه، فریم‌های تولید شده را پیش‌نمایش کنید.

**ورود**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Appear** | خیر | بله |
| **Fade** | بله | بله |
| **Fly In** | بله | بله |
| **Float In** | بله | بله |
| **Split** | بله | بله |
| **Wipe** | بله | بله |
| **Shape** | بله | بله |
| **Wheel** | بله | بله |
| **Random Bars** | بله | بله |
| **Grow & Turn** | خیر | بله |
| **Zoom** | بله | بله |
| **Swivel** | بله | بله |
| **Bounce** | بله | بله |

**تاکید**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Pulse** | خیر | بله |
| **Color Pulse** | خیر | بله |
| **Teeter** | بله | بله |
| **Spin** | بله | بله |
| **Grow/Shrink** | خیر | بله |
| **Desaturate** | خیر | بله |
| **Darken** | خیر | بله |
| **Lighten** | خیر | بله |
| **Transparency** | خیر | بله |
| **Object Color** | خیر | بله |
| **Complementary Color** | خیر | بله |
| **Line Color** | خیر | بله |
| **Fill Color** | خیر | بله |

**خروج**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Disappear** | خیر | بله |
| **Fade** | بله | بله |
| **Fly Out** | بله | بله |
| **Float Out** | بله | بله |
| **Split** | بله | بله |
| **Wipe** | بله | بله |
| **Shape** | بله | بله |
| **Random Bars** | بله | بله |
| **Shrink & Turn** | خیر | بله |
| **Zoom** | بله | بله |
| **Swivel** | بله | بله |
| **Bounce** | بله | بله |

**مسیرهای حرکتی**:

| نوع انیمیشن | Aspose.Slides | PowerPoint |
|---|---|---|
| **Lines** | بله | بله |
| **Arcs** | بله | بله |
| **Turns** | بله | بله |
| **Shapes** | بله | بله |
| **Loops** | بله | بله |
| **Custom Path** | بله | بله |

## **سوالات متداول**

**آیا Aspose.Slides مستقیماً یک فایل MP4 ایجاد می‌کند؟**  
خیر. Aspose.Slides فریم‌های ارائه را تولید می‌کند. برای ترکیب آنها به یک فایل MP4 از یک رمزگذار ویدئویی مانند FFmpeg استفاده کنید.

**چرا ویدئو سریع‌تر یا کندتر از حد انتظار پخش می‌شود؟**  
از همان FPS برای تولید فریم و نرخ فریم ورودی رمزگذار استفاده کنید. عدم تطابق باعث تغییر طول مدت پخش توالی تصویر می‌شود.

**آیا می‌توانم یک ارائهٔ دارای رمز عبور را تبدیل کنم؟**  
بله. هنگام [بارگذاری ارائهٔ محافظت‌شده](/slides/fa/python-java/password-protected-presentation/) رمز عبور صحیح را فراهم کنید، سپس فریم‌ها را از محتوای بارگذاری‌شده تولید کنید.

**آیا این جریان کاری صداهای ارائه را حفظ می‌کند؟**  
مثال‌ها فقط فریم‌های تصویر را صادر می‌کنند، بنابراین ویدئوی حاصل بی‌صدا است. برای افزودن صدا، یک مسیر صوتی را به‌صورت جداگانه هنگام رمزگذاری ویدئو فراهم کنید.

**چگونه می‌توانم استفاده موقت از دیسک را کاهش دهم؟**  
از اندازهٔ فریم کوچک‌تر یا FPS پایین‌تر استفاده کنید و پس از رمزگذاری موفق، فایل‌های PNG موقت را حذف کنید. هنگام کاهش هر یک از این تنظیمات، کیفیت ویدئوی نهایی را بررسی کنید.