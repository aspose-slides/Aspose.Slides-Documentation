---
title: مدیریت اشکال ارائه در جاوا
linktitle: دست‌کاری اشکال
type: docs
weight: 40
url: /fa/java/shape-manipulations/
keywords:
- شکل پاورپوینت
- شکل ارائه
- شکل روی اسلاید
- پیدا کردن شکل
- کلون کردن شکل
- حذف شکل
- مخفی کردن شکل
- تغییر ترتیب شکل
- دریافت شناسه شکل Interop
- متن جایگزین شکل
- فرمت‌های چینش شکل
- شکل به صورت SVG
- شکل به SVG
- تراز کردن شکل
- وارون کردن شکل
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را با Aspose.Slides برای جاوا شناسایی، کلون کنید، حذف کنید، مخفی کنید، دوباره ترتیب دهید، صادر کنید، تراز کنید و وارون کنید."
---
## **نمای کلی**

Aspose.Slides for Java اشکال موجود در یک اسلاید را به‌عنوان یک **[IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/)** مرتب‌شده نمایش می‌دهد. این مجموعه هم مکان یافتن و اصلاح اشکال است و هم منبع ترتیب انباشته‌شدن آن‌ها: اندیس `0` کم‌رنگ‌ترین شکل است، در حالی که آخرین اندیس، بالاترین شکل است.

این مقاله همین مدل را دنبال می‌کند. ابتدا توضیح می‌دهد چگونه یک شکل را به‌طور قابل‌اعتماد شناسایی کنید، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و دوباره ترتیب‌دهی کنید. بخش‌های نهایی قالب‌بندی سطح‑چیدمان، خروجی SVG، تراز و تنظیمات وارونگی را پوشش می‌دهند. هر مثال مستقل است، بنابراین می‌توانید فقط عملیاتی را که جریان کاری‌تان نیاز دارد استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه برای پردازش فایلی که شناخته شده است، راحت‌اند، اما شناسه‌های پایداری نیستند. اضافه، حذف یا تغییر ترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه را بر‑اساس نحوه‌ِ تولید و نگهداری ارائه انتخاب کنید:

- **[Name](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getName--)** برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب پاورپوینت به‌راحتی قابل‌مشاهده است. نام‌ها قابل ویرایش‌اند اما تضمینی برای یکتا بودن ندارند، بنابراین اگر کد به آن‌ها وابسته است یک قرارداد نام‌گذاری برقرار کنید.
- **[AlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getAlternativeText--)** وقتی توضیح دسترسی یا برچسبی که توسط نویسنده ارائه شده است، شکل را شناسایی می‌کند، مفید است. این متن برای کاربران قابل‌مشاهده است، می‌تواند محلی‌سازی یا برای دسترسی بازنویسی شود و تضمینی برای یکتا بودن ندارد. متن‌های دسترسی معنادار را به‌صورت ساکن برای کلید پایگاه‌داده استفاده نکنید.
- **[OfficeInteropShapeId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getOfficeInteropShapeId--)** یک شناسه فقط‑خواندنی است که درون یک اسلاید یکتا است و با شناسهٔ شکلی که پاورپوینت استفاده می‌کند مطابقت دارد. هنگام یکپارچه‌سازی با پاورپوینت یا زمانی که به یک مرجع بی‌ابهام در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته، شکل دیگری است و شناسهٔ مخصوص به خود را دریافت می‌کند.

متد مرتبط **[getUniqueId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getUniqueId--)** یک شناسه با دامنهٔ ارائه برمی‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند دوباره اختصاص یابد. نباید به‌عنوان کلید خارجی دائم رفتار شود. اگر هویت طولانی‌مدت ضروری است، نگاشت را در داده‌های برنامه نگه داشته و اطمینان حاصل کنید که شکل مورد انتظار هنوز وجود دارد.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شکل مورد انتظار را نداشته باشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه دادن با شیء اشتباه.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape targetShape = null;
    for (IShape shape : slide.getShapes()) {
        if ("RevenueChart".equals(shape.getName())) {
            targetShape = shape;
            break;
        }
    }

    if (targetShape == null) {
        System.out.println("The shape 'RevenueChart' was not found on slide 1.");
    } else {
        System.out.println("Found " + targetShape.getName() + "; interop ID: " + targetShape.getOfficeInteropShapeId());
    }
} finally {
    presentation.dispose();
}
```

هنگامی که عملیاتی به‌نوع خاصی از شکل مربوط است، قبل از استفاده از اعضای نوع‑خاص، اینترفیس را بررسی کنید. این مثال فقط در صورتی که شیء نام‌دار یک **[IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/)** باشد، متن و متن جایگزین را به‌روزرسانی می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape candidate = null;
    for (IShape shape : slide.getShapes()) {
        if ("StatusLabel".equals(shape.getName())) {
            candidate = shape;
            break;
        }
    }

    if (candidate instanceof IAutoShape) {
        IAutoShape autoShape = (IAutoShape) candidate;
        autoShape.getTextFrame().setText("Approved");
        autoShape.setAlternativeText("Approval status: approved");
        presentation.save("identified-shape.pptx", SaveFormat.Pptx);
    } else {
        System.out.println("'StatusLabel' is missing or is not an AutoShape.");
    }
} finally {
    presentation.dispose();
}
```

## **تغییر مجموعهٔ اشکال**

متدهای افزودن، کلون، حذف و تغییر ترتیب بلافاصله بر روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، دیگر به اندیس‌های ثبت‌شده پیش از آن عملیات تکیه نکنید.

### **کلون کردن یک شکل**

**[addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-)** یک نسخهٔ مستقل می‌سازد و به انتهای مجموعه هدف اضافه می‌کند. **[insertClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-)** نیز یک نسخه می‌سازد اما آن را در اندیس z‑order مشخصی قرار می‌دهد. بارگذاری‌هایی که مختصات را می‌پذیرند، کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ بارگذاری‌های با عرض و ارتفاع می‌توانند آن را نیز تغییر اندازه دهند.

مثال یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلو کلون می‌کند و کلون دوم را در پشت درج می‌کند. تغییرات در هر یک از کلون‌ها شکل منبع را تغییر نمی‌دهد.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide sourceSlide = presentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 180, 60);
    sourceShape.setName("SourceLabel");
    sourceShape.getTextFrame().setText("Source");

    ILayoutSlide blankLayout = presentation.getMasters().get_Item(0).getLayoutSlides().getByType(SlideLayoutType.Blank);
    ISlide destinationSlide = presentation.getSlides().addEmptySlide(blankLayout);

    IShape frontCloneShape = destinationSlide.getShapes().addClone(sourceShape, 80, 80);
    frontCloneShape.setName("FrontClone");
    if (frontCloneShape instanceof IAutoShape) {
        IAutoShape frontClone = (IAutoShape) frontCloneShape;
        frontClone.getTextFrame().setText("Front clone");
    } else {
        System.out.println("The front clone is not an AutoShape; its text was not changed.");
    }

    IShape backCloneShape = destinationSlide.getShapes().insertClone(0, sourceShape, 80, 180);
    backCloneShape.setName("BackClone");
    if (backCloneShape instanceof IAutoShape) {
        IAutoShape backClone = (IAutoShape) backCloneShape;
        backClone.getTextFrame().setText("Back clone");
    } else {
        System.out.println("The back clone is not an AutoShape; its text was not changed.");
    }

    presentation.save("cloned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

کلون کردن محتوای شکل و قالب‌بندی آن، شامل نام و متن جایگزین، را کپی می‌کند. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شود، اما کلون همچنان یک آیتم جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

**[remove](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-)** یک شیء شکل خاص را از مجموعه‌اش حذف می‌کند. هنگام حذف چندین مطابقت در طول تکرار بر‑اندیس، از انتها به جلو عبور کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی که نامی معین داشته باشد حذف می‌کند. شکل را در اندیس جاری می‌خواند، نه آیتم ثابت مجموعه، و شکل را به‌طور غیرضروری کست نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape keepShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 140, 60);
    keepShape.setName("Keep");

    IAutoShape firstTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 220, 40, 80, 80);
    firstTemporaryShape.setName("Temporary");

    IAutoShape secondTemporaryShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 340, 40, 100, 80);
    secondTemporaryShape.setName("Temporary");

    for (int i = slide.getShapes().size() - 1; i >= 0; i--) {
        IShape shape = slide.getShapes().get_Item(i);
        if ("Temporary".equals(shape.getName())) {
            slide.getShapes().remove(shape);
        }
    }

    presentation.save("removed-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

پس از حذف، تعداد اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال بدون تغییر، نسبت به ذخیرهٔ اندیس‌های قبلی قابل‌اعتمادتر است. همچنین به ارتباط‌کننده‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل مشاهده می‌تواند بیش از ظاهر اسلاید تغییر ایجاد کند.

### **مخفی کردن یک شکل**

تنظیم **[Hidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setHidden-boolean-)** بر روی `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در اسلایدشو معمولی جلوگیری می‌کند. اندیس، قالب‌بندی و محتوا برای کد در دسترس می‌مانند، بنابراین مخفی کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape visibleShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 40, 40, 160, 60);
    visibleShape.setName("VisibleLabel");

    IAutoShape optionalShape = slide.getShapes().addAutoShape(ShapeType.Moon, 240, 40, 100, 100);
    optionalShape.setName("OptionalDecoration");

    for (IShape shape : slide.getShapes()) {
        if ("OptionalDecoration".equals(shape.getName())) {
            shape.setHidden(true);
        }
    }

    presentation.save("hidden-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مخفی کردن حذف یا امنیت نیست. شیء هنوز می‌تواند توسط کاربر یا کد کشف و آشکار شود و بخشی از فایل ارائه باقی می‌ماند.

### **تغییر Z‑Order**

اشکال همپوشانی‌شده به ترتیب مجموعه نقاشی می‌شوند. **[reorder](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-)** یک شکل موجود را به اندیس هدفی منتقل می‌کند بدون اینکه کلون شود. اندیس `0` پشت‌ترین است؛ `size() - 1` جلوترین.

```java
import com.aspose.slides.*;
import java.awt.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape blueRectangle = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 220, 120);
    blueRectangle.setName("BlueRectangle");
    blueRectangle.getFillFormat().setFillType(FillType.Solid);
    blueRectangle.getFillFormat().getSolidFillColor().setColor(Color.BLUE);

    IAutoShape orangeEllipse = slide.getShapes().addAutoShape(ShapeType.Ellipse, 180, 140, 220, 120);
    orangeEllipse.setName("OrangeEllipse");
    orangeEllipse.getFillFormat().setFillType(FillType.Solid);
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.ORANGE);

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مستطیل ابتدا ایجاد می‌شود و ابتدا پشت بیضی قرار دارد. انتقال آن به اندیس نهایی، آن را به جلو می‌برد. پس از اضافه یا کلون تمام اشکال مرتبط، Z‑Order را نهایی کنید، زیرا این عملیات‌ها آیتم‌های جدیدی به مجموعه اضافه یا درج می‌کنند و می‌توانند ترتیب مورد نظر را تغییر دهند.

## **بازرسی اشکال در اسلایدهای Layout**

اسلایدهای عادی، اسلایدهای Layout و اسلایدهای Master مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ Layout همان شیء شکل در اسلاید عادی نیست. هنگام نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک Layout، اشکال Layout را بازبینی کنید.

مثال زیر **[FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getFillFormat--)** و **[LineFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#getLineFormat--)** هر شکل Layout را می‌خواند بدون این‌که فرض کند هر شکل یک `AutoShape` است.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("input.pptx");
try {
    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        for (IShape shape : layoutSlide.getShapes()) {
            int fillType = shape.getFillFormat().getFillType();
            double lineWidth = shape.getLineFormat().getWidth();
            System.out.println(layoutSlide.getName() + " / " + shape.getName() + ": fill=" + fillType + ", line width=" + lineWidth);
        }
    }
} finally {
    presentation.dispose();
}
```

ویرایش یک Layout می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند تأثیر بگذارد. قبل از تغییر یک شکل Layout، تعیین کنید آیا یک اسلاید عادی شیء را به ارث می‌برد یا یک بازنویسی محلی دارد، و هر اسلایدی که از آن Layout استفاده می‌کند تست شود.

## **خروجی یک شکل به SVG**

**[writeAsSvg](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-)** محتوای رندر شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل فقط همان شکل است، نه پس‌زمینهٔ کامل اسلاید یا شکل‌های همسایه.

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;
import java.io.IOException;

Presentation presentation = new Presentation("input.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    if (slide.getShapes().size() == 0) {
        System.out.println("Slide 1 does not contain a shape to export.");
    } else {
        IShape shape = slide.getShapes().get_Item(0);
        try (FileOutputStream svgStream = new FileOutputStream("shape.svg")) {
            shape.writeAsSvg(svgStream);
        } catch (IOException exception) {
            System.out.println("The SVG file could not be written: " + exception.getMessage());
        }
    }
} finally {
    presentation.dispose();
}
```

در حین رندر کردن ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و به منابعی چون قلم‌ها و تصویرها وابسته است. اگر به کل ترکیب نیاز دارید، اسلاید را به‌جای یک شکل منفرد خروجی بگیرید. فراخواننده مالک جریان است و باید آن را ببندد.

## **تراز کردن اشکال**

متد **[SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-)** overloadهایی دارد که یا همهٔ اشکال یا اندیس‌های منتخب مجموعه را تراز می‌کند. **[ShapesAlignmentType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapesalignmenttype/)** لبه، خط مرکز یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا به لبه‌های اسلاید تراز شود؛ به `false` تنظیم کنید تا اشکال منتخب نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالا اسلاید تراز می‌کند. ارجاع‌های شکل برگردانده‌شده بلافاصله قبل از تراز به اندیس‌های فعلیشان تبدیل می‌شوند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape firstShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 60, 80, 120, 50);
    IAutoShape secondShape = slide.getShapes().addAutoShape(ShapeType.Ellipse, 240, 160, 120, 50);
    IAutoShape thirdShape = slide.getShapes().addAutoShape(ShapeType.Triangle, 420, 240, 120, 50);
    firstShape.setName("FirstAlignedShape");
    secondShape.setName("SecondAlignedShape");
    thirdShape.setName("ThirdAlignedShape");

    int[] shapeIndexes = {slide.getShapes().indexOf(firstShape), slide.getShapes().indexOf(secondShape), slide.getShapes().indexOf(thirdShape)};

    SlideUtil.alignShapes(ShapesAlignmentType.AlignTop, true, slide, shapeIndexes);
    presentation.save("aligned-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

تراز موقعیت‌ها را تغییر می‌دهد، نه Z‑Order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی به تعداد کافی شکل برای تعریف فاصله‌ها نیاز دارد. اگر قبل از فراخوانی متد مجموعه را تغییر می‌دهید، اندیس‌ها را مجدداً محاسبه کنید.

## **وارون کردن یک شکل**

کلاس **[ShapeFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapeframe/)** موقعیت، اندازه، تنظیمات وارونگی افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از **[NullableBool](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/)** استفاده می‌کنند: `True` وارونگی را فعال می‌کند، `False` آن را غیرفعال می‌کند و `NotDefined` حالت پیش‌فرض/نامشخص را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون وارونگی است.

![شکل قبل از وارونگی](shape_to_be_flipped.png)

مثال تنها مقادیر دیگر فریم را حفظ می‌کند و فقط دو تنظیم وارونگی را جایگزین می‌کند. این مهم است چون اختصاص یک **[Frame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-)** جدید، فریم کامل را جایگزین می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    IShape shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IShapeFrame frame = shape.getFrame();

    System.out.println("Horizontal flip before change: " + frame.getFlipH());
    System.out.println("Vertical flip before change: " + frame.getFlipV());

    shape.setFrame(new ShapeFrame(frame.getX(), frame.getY(), frame.getWidth(), frame.getHeight(), NullableBool.True, NullableBool.True, frame.getRotation()));

    presentation.save("flipped-shape.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

شکل ذخیره‌شده به‌صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش خود را حفظ می‌کند.

![شکل پس از وارونگی](flipped_shape.png)

## **سوالات متداول**

**آیا باید از اندیس مجموعه به‌عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدت که مجموعه قبل از استفاده از اندیس تغییر نمی‌کند. برای قالب‌های نویسندگی‌شده از یک قرارداد معتبر `Name` یا `AlternativeText` استفاده کنید، یا برای کارهای interop محدود به اسلاید، `OfficeInteropShapeId` را به کار ببرید.

**آیا مخفی کردن یک شکل آن را از Z‑Order حذف می‌کند؟**

خیر. یک شکل مخفی در مجموعه با همان اندیس باقی می‌ماند. می‌تواند پیدا شود، دوباره ترتیب داده شود، ویرایش شود یا دوباره قابل مشاهده شود.

**چرا یک شکل کلون شده در جلوی شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی Z‑Order محسوب می‌شود. برای انتخاب اندیس اولیه از `insertClone` استفاده کنید یا پس از افزودن تمام شکل‌ها از `reorder` بهره ببرید.