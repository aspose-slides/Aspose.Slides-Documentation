---
title: مدیریت اشکال ارائه در C++
linktitle: دست‌کاری شکل
type: docs
weight: 40
url: /fa/cpp/shape-manipulations/
keywords:
- شکل PowerPoint
- شکل ارائه
- شکل در اسلاید
- یافتن شکل
- کلون کردن شکل
- حذف شکل
- پنهان کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه Interop شکل
- متن جایگزین شکل
- قالب‌های چیدمان شکل
- شکل به‌صورت SVG
- شکل به SVG
- تراز کردن شکل
- PowerPoint
- ارائه
- C++
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال را در Aspose.Slides برای C++ ایجاد، ویرایش و بهینه کنید و ارائه‌های PowerPoint با عملکرد بالا را تحویل دهید."
---
## **نمای کلی**

این مقاله نحوه کار با اشکال در ارائه‌ها با استفاده از Aspose.Slides را توضیح می‌دهد. نشان می‌دهد چگونه یک شکل را در اسلاید پیدا کنید، آن را کلون کنید، حذف کنید، پنهان کنید، ترتیب آن را تغییر دهید، شناسهٔ Interop Shape ID را دریافت کنید و متن جایگزین (AlternativeText) را برای شناسایی و پردازش‌های بعدی تنظیم کنید.

همچنین نحوه دسترسی به قالب‌های چیدمان برای اشکال، رندر کردن یک شکل به صورت SVG، تراز کردن اشکال در یک اسلاید و استفاده از ویژگی‌های flip برای آینه‌سازی افقی و عمودی را پوشش می‌دهد. علاوه بر این، مقاله شامل یک بخش کوتاه FAQ درباره ترکیب اشکال، ترتیب لایه‌بندی و قفل کردن شکل است.

## **پیدا کردن یک شکل در اسلاید**
این بخش یک تکنیک ساده را برای راحت‌تر کردن پیدا کردن یک شکل خاص در اسلاید بدون استفاده از شناسهٔ داخلی آن توصیف می‌کند. مهم است که بدانید فایل‌های ارائهٔ PowerPoint به جز شناسهٔ داخلی منحصر به فرد، راهی برای شناسایی اشکال در اسلاید ندارند. برای یافتن یک شکل با استفاده از شناسهٔ داخلی‌اش برای توسعه‌دهندگان دشوار است. تمام اشکالی که به اسلایدها اضافه می‌شوند دارای متنی جایگزین هستند. ما به توسعه‌دهندگان پیشنهاد می‌کنیم برای یافتن یک شکل خاص از متن جایگزین استفاده کنند. می‌توانید از MS PowerPoint برای تعریف متن جایگزین برای اشیائی که قصد تغییر آن‌ها را در آینده دارید، استفاده کنید.

پس از تنظیم متن جایگزین هر شکل دلخواه، می‌توانید ارائه را با Aspose.Slides for C++ باز کنید و از طریق تمام اشکال اضافه شده به یک اسلاید تکرار کنید. در هر تکرار می‌توانید متن جایگزین شکل را بررسی کنید و شکلی که متن جایگزین آن منطبق باشد، همان شکل مورد نظر شما خواهد بود. برای نمایش بهتر این تکنیک، ما یک متد [FindShape](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.slide_util#ad6ecc982512ef758ea4d5d28672db71f) ایجاد کرده‌ایم که کار پیدا کردن یک شکل خاص در اسلاید را انجام می‌دهد و سپس همان شکل را برمی‌گرداند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-FindShapeInSlide-FindShapeInSlide.cpp" >}}

## **کلون کردن یک شکل**
برای کلون کردن یک شکل به اسلاید با Aspose.Slides for C++:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. مرجع یک اسلاید را با استفاده از اندیس آن به دست آورید.
3. به مجموعهٔ اشکال اسلاید منبع دسترسی پیدا کنید.
4. یک اسلاید جدید به ارائه اضافه کنید.
5. اشکال را از مجموعهٔ اشکال اسلاید منبع به اسلاید جدید کلون کنید.
6. ارائهٔ اصلاح‌شده را به عنوان فایل PPTX ذخیره کنید.

مثال زیر یک گروه شکل را به اسلاید اضافه می‌کند.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-CloneShapes-CloneShapes.cpp" >}}

## **حذف یک شکل**
Aspose.Slides for C++ به توسعه‌دهندگان امکان حذف هر شکلی را می‌دهد. برای حذف شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. شکلی با AlternativeText خاص پیدا کنید.
4. شکل را حذف کنید.
5. فایل را روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-RemoveShape-RemoveShape.cpp" >}}

## **پنهان کردن یک شکل**
Aspose.Slides for C++ به توسعه‌دهندگان امکان پنهان کردن هر شکلی را می‌دهد. برای پنهان کردن شکل از هر اسلاید، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. شکلی با AlternativeText خاص پیدا کنید.
4. شکل را پنهان کنید.
5. فایل را روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-Hidingshapes-Hidingshapes.cpp" >}}

## **تغییر ترتیب شکل**
Aspose.Slides for C++ به توسعه‌دهندگان امکان تغییر ترتیب اشکال را می‌دهد. تغییر ترتیب مشخص می‌کند کدام شکل در جلو و کدام شکل در پس‌زمینه قرار بگیرد. برای تغییر ترتیب اشکال در هر اسلاید، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. یک شکل اضافه کنید.
4. متنی در فریم متن شکل اضافه کنید.
5. شکل دیگری با همان مختصات اضافه کنید.
6. ترتیب اشکال را تغییر دهید.
7. فایل را روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-ChangeShapeOrder-ChangeShapeOrder.cpp" >}}

## **دریافت Interop Shape ID**
Aspose.Slides for C++ به توسعه‌دهندگان امکان دریافت شناسهٔ منحصر به فرد یک شکل در محدودهٔ اسلاید را می‌دهد؛ در مقابل ویژگی UniqueId که شناسهٔ منحصر به فرد را در محدودهٔ ارائه فراهم می‌کند. ویژگی OfficeInteropShapeId به اینترفیس‌های IShape و کلاس Shape اضافه شده است. مقدار بازگردانده‌شده توسط این ویژگی متناظر با مقدار Id شیء Microsoft.Office.Interop.PowerPoint.Shape است. کد نمونه در زیر ارائه شده است.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-InterlopShapeID-InterlopShapeID.cpp" >}}

## **تنظیم ویژگی AlternativeText**
Aspose.Slides for C++ به توسعه‌دهندگان امکان تنظیم AlternateText برای هر شکل را می‌دهد. برای تنظیم AlternateText یک شکل، مراحل زیر را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.presentation) ایجاد کنید.
2. به اولین اسلاید دسترسی پیدا کنید.
3. هر شکلی را به اسلاید اضافه کنید.
4. کاری با شکل جدید اضافه‌شده انجام دهید.
5. از میان اشکال عبور کنید تا شکلی پیدا کنید.
6. AlternativeText را تنظیم کنید.
7. فایل را روی دیسک ذخیره کنید.

{{< gist "aspose-slides" "a690df625dc0b1fff869ab198affe7a4" "Examples-SlidesCPP-SetAlternativeText-SetAlternativeText.cpp" >}}

## **دسترسی به قالب‌های Layout برای یک شکل**
Aspose.Slides for C++ به توسعه‌دهندگان امکان دسترسی به قالب‌های Layout برای یک شکل را می‌دهد. این مقاله نشان می‌دهد چگونه می‌توانید به ویژگی‌های **FillFormat** و **LineFormat** برای یک شکل دسترسی داشته باشید.

کد نمونه در زیر آورده شده است.

{{< gist "aspose-com-gists" "81aeb05e6d3a070aa76fdea22ed53bc7" "Examples-SlidesCPP-AccessLayoutFormats-AccessLayoutFormats.cpp" >}}

## **رندر کردن یک شکل به صورت SVG**
اکنون Aspose.Slides for C++ از رندر کردن یک شکل به صورت SVG پشتیبانی می‌کند. متد WriteAsSvg (و overload آن) به کلاس Shape و اینترفیس IShape اضافه شده است. این متد امکان ذخیره محتوای شکل به عنوان فایل SVG را می‌دهد. کد زیر نشان می‌دهد چگونه شکل اسلاید را به فایل SVG صادر کنید.

``` cpp
String outSvgFileName = u"SingleShape.svg";

auto pres = System::MakeObject<Presentation>(u"TestExportShapeToSvg.pptx");

auto stream = System::MakeObject<FileStream>(outSvgFileName, FileMode::Create, FileAccess::Write);
pres->get_Slides()->idx_get(0)->get_Shapes()->idx_get(0)->WriteAsSvg(stream);
```

## **تراز کردن اشکال**
Aspose.Slides امکان تراز کردن اشکال را نسبت به حاشیه‌های اسلاید یا نسبت به یکدیگر فراهم می‌کند. برای این منظور، متد overload شده [SlidesUtil.AlignShapes()](https://reference.aspose.com/slides/fa/cpp/class/aspose.slides.util.slide_util#a2263709efa423c11706e57b21014d3ab) اضافه شده است. enumeration [ShapesAlignmentType](https://reference.aspose.com/slides/fa/cpp/namespace/aspose.slides#aeb3015a196294029a0ee1f545bc5887f) گزینه‌های ممکن تراز را تعریف می‌کند.

**مثال 1**

کد منبع زیر اشکالی با ایندکس‌های 1، 2 و 4 را در لبهٔ بالای اسلاید تراز می‌کند.

``` cpp
SharedPtr<Presentation> pres = System::MakeObject<Presentation>(u"example.pptx");

SharedPtr<ISlide> slide = pres->get_Slides()->idx_get(0);
SharedPtr<IShape> shape1 = slide->get_Shapes()->idx_get(1);
SharedPtr<IShape> shape2 = slide->get_Shapes()->idx_get(2);
SharedPtr<IShape> shape3 = slide->get_Shapes()->idx_get(4);
SlideUtil::AlignShapes(ShapesAlignmentType::AlignTop, true, pres->get_Slides()->idx_get(0), 
System::MakeArray<int32_t>(
    {
        slide->get_Shapes()->IndexOf(shape1),
        slide->get_Shapes()->IndexOf(shape2),
        slide->get_Shapes()->IndexOf(shape3)
    }));
```

**مثال 2**

مثال زیر نشان می‌دهد چگونه کل مجموعهٔ اشکال را نسبت به پایین‌ترین شکل در مجموعه تراز کنیم.

``` cpp
SharedPtr<Presentation> pres = MakeObject<Presentation>(u"example.pptx");
SlideUtil::AlignShapes(ShapesAlignmentType::AlignBottom, false, pres->get_Slides()->idx_get(0)->get_Shapes());
```

## **ویژگی‌های Flip**

در Aspose.Slides، کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeframe/) کنترل آینه‌سازی افقی و عمودی اشکال را از طریق ویژگی‌های `flipH` و `flipV` فراهم می‌کند. هر دو ویژگی از نوع [NullableBool](https://reference.aspose.com/slides/fa/cpp/aspose.slides/nullablebool/) هستند و مقادیر `True` برای معکوس، `False` برای عدم معکوس و `NotDefined` برای رفتار پیش‌فرض را می‌پذیرند. این مقادیر از طریق [Frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_frame/) شکل قابل دسترسی هستند.

برای تغییر تنظیمات flip، یک نمونهٔ جدید از [ShapeFrame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/shapeframe/) با موقعیت و اندازه فعلی شکل، مقادیر دلخواه برای `flipH` و `flipV` و زاویهٔ چرخش ساخته می‌شود. اختصاص این نمونه به [Frame](https://reference.aspose.com/slides/fa/cpp/aspose.slides/ishape/get_frame/) شکل و ذخیرهٔ ارائه، تبدیل‌های آینه‌ای را اعمال و در فایل خروجی ذخیره می‌کند.

فرض کنید فایلی به نام sample.pptx داریم که اسلاید اول آن یک شکل با تنظیمات پیش‌فرض flip دارد، همان‌طور که در زیر نشان داده شده است.

![The shape to be flipped](shape_to_be_flipped.png)

کد زیر ویژگی‌های flip فعلی شکل را بازیابی کرده و آن را هم به صورت افقی و هم عمودی معکوس می‌کند.

```cpp
auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto shape = presentation->get_Slide(0)->get_Shape(0);

// دریافت ویژگی معکوس افقی شکل.
auto horizontalFlip = shape->get_Frame()->get_FlipH();
Console::WriteLine(u"Horizontal flip: " + ObjectExt::ToString(horizontalFlip));

// دریافت ویژگی معکوس عمودی شکل.
auto verticalFlip = shape->get_Frame()->get_FlipV();
Console::WriteLine(u"Vertical flip: " + ObjectExt::ToString(verticalFlip));

auto x = shape->get_Frame()->get_X();
auto y = shape->get_Frame()->get_Y();
auto width = shape->get_Frame()->get_Width();
auto height = shape->get_Frame()->get_Height();
auto flipH = NullableBool::True; // معکوس افقی.
auto flipV = NullableBool::True; // معکوس افقی.
auto rotation = shape->get_Frame()->get_Rotation();

shape->set_Frame(MakeObject<ShapeFrame>(x, y, width, height, flipH, flipV, rotation));

presentation->Save(u"output.pptx", SaveFormat::Pptx);
presentation->Dispose();
```

نتیجه:

![The flipped shape](flipped_shape.png)

## **FAQ**

**آیا می‌توانم اشکال (union/intersect/subtract) را در اسلاید مانند یک ویرایشگر دسکتاپ ترکیب کنم؟**

یک API عملیات بولی داخلی وجود ندارد. می‌توانید با ساختن شکل مرزی دلخواه خود—مثلاً محاسبه هندسهٔ نتیجه‌دار (از طریق [GeometryPath](https://reference.aspose.com/slides/fa/cpp/aspose.slides/geometrypath/)) و ایجاد یک شکل جدید با همان کانتور، تقریب بزنید و در صورت نیاز اشکال اصلی را حذف کنید.

**چطور می‌توانم ترتیب لایه‌بندی (z-order) را طوری کنترل کنم که یک شکل همیشه «روی پایه» بماند؟**

ترتیب درج/انتقال را در مجموعهٔ [shapes](https://reference.aspose.com/slides/fa/cpp/aspose.slides/baseslide/get_shapes/) اسلاید تغییر دهید. برای نتایج پیش‌بینی‌شده، پس از تمام تغییرات دیگر اسلاید، ترتیب z را نهایی کنید.

**آیا می‌توانم یک شکل را «قفل» کنم تا کاربران در PowerPoint نتوانند آن را ویرایش کنند؟**

بله. پرچم‌های محافظت در سطح شکل را تنظیم کنید (مثلاً قفل انتخاب، جابجایی، تغییر اندازه، ویرایش متن). در صورت نیاز، محدودیت‌ها را در ماسټر یا لآوت نیز اعمال کنید. توجه داشته باشید این محافظت سطح UI است و نه یک ویژگی امنیتی؛ برای محافظت قوی‌تر می‌توانید آن را با محدودیت‌های سطح فایل مثل توصیه‌های فقط‑خواندنی یا رمز عبور ترکیب کنید.