---
title: مدیریت اشکال ارائه در اندروید
linktitle: دستکاری اشکال
type: docs
weight: 40
url: /fa/androidjava/shape-manipulations/
keywords:
- اشکال پاورپوینت
- اشکال ارائه
- اشکال در اسلاید
- یافتن اشکال
- کلون کردن اشکال
- حذف اشکال
- مخفی کردن اشکال
- تغییر ترتیب اشکال
- دریافت شناسهٔ اشکال interop
- متن جایگزین اشکال
- قالب‌های لایهٔ اشکال
- اشکال به‌صورت SVG
- تبدیل اشکال به SVG
- تراز کردن اشکال
- چرخاندن اشکال
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "یاد بگیرید چگونه اشکال ارائه را شناسایی، کلون، حذف، مخفی، ترتیب‌داده، خروجی، تراز و چرخانده کنید با Aspose.Slides برای اندروید از طریق جاوا."
---
## **نمای کلی**

Aspose.Slides برای Android از طریق Java اشکال موجود در یک اسلاید را به عنوان یک [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) مرتب نمایش می‌دهد. این مجموعه هم محلی است که می‌توانید اشکال را پیدا و ویرایش کنید و هم منبع ترتیب لایه‌ای آن‌ها: اندیس `0` مربوط به پشت‌ترین شکل است، در حالی که آخرین اندیس مربوط به جلوی‌ترین شکل است.

این مقاله بر همین مدل استوار است. ابتدا توضیح می‌دهد چگونه می‌توان به‌صورت قابل‌اعتماد یک شکل را شناسایی کرد، سپس نشان می‌دهد چگونه اشکال را کلون، حذف، مخفی و ترتیب‌داده مجدد کنید. بخش‌های نهایی به قالب‌بندی در سطح لایه، خروجی SVG، تراز و تنظیمات چرخش می‌پردازند. هر مثال به‌صورت مستقل است، بنابراین می‌توانید فقط عملیات مورد نیاز جریان کار خود را استفاده کنید.

## **شناسایی و یافتن اشکال**

اندیس‌های مجموعه هنگام پردازش یک فایل شناخته‌شده راحت هستند، اما شناسه‌های پایداری نیستند. افزودن، حذف یا تغییر ترتیب یک شکل می‌تواند اندیس آن را تغییر دهد. یک شناسه را بر اساس نحوه‌ی نوشتن و نگهداری ارائه انتخاب کنید:

- [Name](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getName--) برای قالب‌های کنترل‌شده توسط توسعه‌دهنده مفید است و در پنل انتخاب PowerPoint به‌راحتی قابل مشاهده است. نام‌ها را می‌توان ویرایش کرد و تضمین نمی‌شود که یکتا باشند، بنابراین اگر کد به آن‌ها وابسته است، یک کنوانسیون نامگذاری تعیین کنید.
- [AlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getAlternativeText--) زمانی مفید است که یک توضیح دسترسی یا برچسبی که توسط نویسنده افزوده شده است، پیشاپیش شکل را شناسایی می‌کند. این متن برای کاربران قابل‌دید است، ممکن است محلی‌سازی یا بازنویسی برای دسترسی شود و یکتا نیست. از تبدیل بی‌صدا متن دسترسی معنادار به کلید پایگاه‌داده خودداری کنید.
- [OfficeInteropShapeId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getOfficeInteropShapeId--) یک شناسهٔ فقط‑خواندنی است که درون یک اسلاید یکتا بوده و با شناسهٔ شکلی که توسط PowerPoint interop استفاده می‌شود مطابقت دارد. وقتی با PowerPoint یکپارچه می‌شوید یا به یک مرجع واضح در طول عمر یک شکل نیاز دارید از آن استفاده کنید. یک شکل کلون‌شده یا بازساخته یک شکل متفاوت است و شناسهٔ خود را دریافت می‌کند.

متد مرتبط [getUniqueId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getUniqueId--) شناسه‌ای با دامنهٔ ارائه برمی‌گرداند، اما این شناسه برای افزونه‌ها در نظر گرفته شده و می‌تواند بازتخصیص یابد. نباید آن را به‌عنوان کلید ثابت خارجی در نظر گرفت. اگر هویت بلندمدت ضروری است، نگاشت را در داده‌های برنامه نگه داشته و صحت وجود شکل مورد انتظار را اعتبارسنجی کنید.

مثال زیر با مقایسهٔ دقیق بر اساس نام جستجو می‌کند و شناسهٔ interop scoped به اسلاید را گزارش می‌دهد. وقتی قالب شامل شکل مورد انتظار نباشد، کد همان نتیجه را گزارش می‌کند به‌جای ادامه با شیء نادرست.

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

هنگامی که عملیاتی مخصوص به نوعی از شکل باشد، قبل از استفاده از اعضای مخصوص نوع، اینترفیس را بررسی کنید. این مثال متن و متن جایگزین را فقط در صورتی به‌روز می‌کند که شیء نام‌گذاری‌شده یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) باشد.

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

متدهای افزودن، کلون، حذف و ترتیب‌داده مجدد بلافاصله روی مجموعه عمل می‌کنند. اگر عملیاتی تعداد یا ترتیب اشکال را تغییر دهد، پس از آن عملیات دیگر بر روی اندیس‌های ضبط‌شده پیش از تغییر تکیه نکنید.

### **کلون یک شکل**

[addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#addClone-com.aspose.slides.IShape-) یک کپی مستقل ایجاد کرده و آن را به انتهای مجموعه هدف اضافه می‌کند. [insertClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#insertClone-int-com.aspose.slides.IShape-) نیز یک کپی می‌سازد اما آن را در اندیسی مشخص از z‑order قرار می‌دهد. اورلودهایی که مختصات می‌پذیرند کلون را بدون تغییر اندازه جابه‌جا می‌کنند؛ اورلودهایی که عرض و ارتفاع می‌گیرند می‌توانند اندازهٔ آن را نیز تغییر دهند.

مثال زیر یک اسلاید مقصد می‌سازد، یک مستطیل برچسب‌دار را به جلوی اسلاید کلون می‌کند و سپس یک کلون دوم را در پشت وارد می‌کند. تغییرات در هر یک از کلون‌ها منبع شکل را تحت تأثیر قرار نمی‌دهد.

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

کلون‌کردن محتوا و قالب‌بندی شکل را شامل می‌شود، از جمله نام و متن جایگزین آن. وقتی این مقادیر باید یکتا باشند، شناسه‌های منطقی جدیدی به کلون اختصاص دهید. منابع مورد استفادهٔ اشکال پیچیده توسط ارائه مدیریت می‌شود، اما یک کلون همچنان یک مورد جدید در مجموعه با هویت شکل جدید است.

### **حذف اشکال**

[remove](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) یک شیء شکل خاص را از مجموعهٔ خود حذف می‌کند. هنگام حذف چندین مورد مطابق در طول یک تکرار اندیسی، از انتها به ابتدا پیمایش کنید تا هر اندیس باقی‌مانده معتبر بماند.

این مثال هر شکلی را که نامی تعیین‌شده داشته باشد حذف می‌کند. شکل را در اندیس جاری می‌خواند، نه یک مورد ثابت از مجموعه، و شکل را به‌صورت غیرضروری تبدیل نوع نمی‌کند.

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

پس از حذف، تعداد اشکال و اندیس‌های اشکال بعدی تغییر می‌کند. ارجاع به اشکال بدون تغییر بیشتر قابل اعتماد است نسبت به ذخیرهٔ اندیس‌ها. همچنین به connector‌ها، انیمیشن‌ها و سایر ویژگی‌های ارائه که ممکن است به شیء حذف‌شده ارجاع دهند، توجه کنید؛ حذف یک شکل قابل‌مشاهده می‌تواند بیش از ظاهر اسلاید تغییر ایجاد کند.

### **مخفی کردن یک شکل**

تنظیم [Hidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setHidden-boolean-) به `true` شکل را در مجموعه نگه می‌دارد اما از نمایش در نمای اسلاید عادی جلوگیری می‌کند. اندیس، قالب‌بندی و محتوای آن برای کد در دسترس باقی می‌ماند، بنابراین مخفی‌کردن برای عناصر اختیاری که ممکن است بعداً بازگردانده شوند مناسب است.

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

مخفی‌کردن حذف یا امنیت نیست. شیء همچنان می‌تواند توسط کاربر یا کد کشف و دوباره آشکار شود و بخشی از فایل ارائه می‌ماند.

### **تغییر ترتیب Z‑Order**

اشکال که روی هم قرار می‌گیرند بر اساس ترتیب مجموعه رنگ می‌شوند. [reorder](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/#reorder-int-com.aspose.slides.IShape-) یک شکل موجود را به اندیس هدفی بدون کلون کردن منتقل می‌کند. اندیس `0` پشت‌ترین است؛ `size() - 1` جلوی‌ترین.

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
    orangeEllipse.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));

    slide.getShapes().reorder(slide.getShapes().size() - 1, blueRectangle);
    presentation.save("reordered-shapes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

در ابتدا مستطیل ایجاد می‌شود و پشت بیضی قرار می‌گیرد. جابجا کردن آن به اندیس نهایی، آن را به جلوی صفحه می‌آورد. پس از افزودن یا کلون تمام اشکال مرتبط، ترتیب Z‑order را نهایی کنید، چون این عملیات موارد جدیدی به مجموعه اضافه یا وارد می‌کنند و می‌توانند ترتیب دلخواه را تغییر دهند.

## **بازرسی اشکال در اسلایدهای لایه‌بندی**

اسلایدهای معمولی، اسلایدهای لایه‌بندی و اسلایدهای اصلی هرکدام مجموعهٔ اشکال جداگانه‌ای دارند. یک شکل در مجموعهٔ لایه‌بندی همان شیء شکل مشابه در یک اسلاید معمولی نیست. زمانی که نیاز به درک یا تغییر قالب‌بندی ارائه‌شده توسط یک لایه دارید، اشکال لایه را بررسی کنید.

مثال زیر برای هر شکل لایهٔ [FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getFillFormat--) و [LineFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#getLineFormat--) را می‌خواند بدون این فرض که هر شکل یک `AutoShape` است.

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

ویرایش یک لایه می‌تواند بر چندین اسلایدی که از آن استفاده می‌کنند تاثیر بگذارد. پیش از تغییر شکل لایه، تعیین کنید آیا یک اسلاید معمولی همان شیء را به ارث می‌برد یا یک بازنویسی محلی دارد و هر اسلایدی که آن لایه را به کار می‌برد تست کنید.

## **خروجی یک شکل به SVG**

[writeAsSvg](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#writeAsSvg-java.io.OutputStream-) محتوای رندر‌شدهٔ یک شکل را به یک جریان می‌نویسد. نتیجه شامل همان شکل است، نه پس‌زمینهٔ کامل اسلاید یا اشکال همسایه.

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

در هنگام رندر، ارائه را باز نگه دارید. خروجی به قالب‌بندی شکل و منابعی مانند قلم‌ها و تصاویر وابسته است. اگر به ترکیب کامل نیاز دارید، اسلاید را به‌جای یک شکل منفرد صادر کنید. فراخوانی‌کننده مالک جریان است و باید آن را ببندد.

## **تراز کردن اشکال**

متد [SlideUtil.alignShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideutil/#alignShapes-int-boolean-com.aspose.slides.IBaseSlide-int:A-) دو overload دارد: یکی برای تراز همه اشکال و دیگری برای اندیس‌های انتخابی مجموعه. [ShapesAlignmentType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapesalignmenttype/) لبه، خط مرکزی یا حالت توزیع را مشخص می‌کند. `alignToSlide` را به `true` تنظیم کنید تا از لبه‌های اسلاید استفاده شود؛ به `false` تنظیم کنید تا اشکال انتخابی نسبت به یکدیگر تراز شوند.

این مثال سه شکل را به لبهٔ بالایی اسلاید تراز می‌کند. ارجاع‌های شکل‌های بازگشتی بلافاصله قبل از تراز به اندیس‌های جاری خود تبدیل می‌شوند.

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

تراز موقعیت را تغییر می‌دهد، نه ترتیب Z‑order. تراز نسبی معمولاً به حداقل دو شکل نیاز دارد، در حالی که توزیع افقی یا عمودی برای تعیین فاصله به تعداد کافی شکل نیاز دارد. اگر پیش از فراخوانی متد مجموعه را تغییر دادید، اندیس‌ها را دوباره محاسبه کنید.

## **چرخاندن (فلیپ) یک شکل**

کلاس [ShapeFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapeframe/) موقعیت، اندازه، تنظیمات فلیپ افقی و عمودی و چرخش را ذخیره می‌کند. مقادیر `getFlipH` و `getFlipV` از [NullableBool](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/nullablebool/) استفاده می‌کنند: `True` فلیپ را فعال می‌کند، `False` غیرفعال می‌کند و `NotDefined` حالت نامشخص/پیش‌فرض را حفظ می‌کند.

ارائهٔ ورودی زیر شامل یک شکل بدون فلیپ است.

![The shape before flipping](shape_to_be_flipped.png)

مثال زیر فقط مقادیر دو تنظیم فلیپ را جایگزین می‌کند و سایر مقادیر فریم را همان‌گونه حفظ می‌کند. این مهم است زیرا اختصاص یک [Frame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/#setFrame-com.aspose.slides.IShapeFrame-) جدید فریم کامل را جایگزین می‌کند.

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

شکل ذخیره‌شده به صورت افقی و عمودی آینه‌ای می‌شود در حالی که موقعیت، اندازه و چرخش آن حفظ می‌شود.

![The shape after flipping](flipped_shape.png)

## **سوالات متداول**

**آیا باید از اندیس مجموعه به عنوان شناسهٔ شکل استفاده کنم؟**

فقط برای پردازش‌های کوتاه‌مدتی که مجموعه قبل از استفاده از اندیس تغییر نخواهد کرد. برای قالب‌های نویسنده‌دار، یک کنوانسیون معتبر `Name` یا `AlternativeText` را ترجیح دهید، یا برای کارهای مرتبط با interop در سطح اسلاید `OfficeInteropShapeId` را استفاده کنید.

**آیا مخفی‌کردن یک شکل آن را از ترتیب Z‑order حذف می‌کند؟**

خیر. یک شکل مخفی در همان اندیس در مجموعه باقی می‌ماند. می‌توان آن را یافت، ترتیب‌داده، ویرایش یا دوباره قابل‌مشاهده کرد.

**چرا یک شکل کلون‌شده در جلوی شکل دیگری ظاهر شد؟**

`addClone` کلون را به انتهای مجموعه اضافه می‌کند که جلوی Z‑order است. برای انتخاب اندیس اولیه از `insertClone` استفاده کنید یا پس از افزودن همهٔ اشکال از `reorder` بهره ببرید.