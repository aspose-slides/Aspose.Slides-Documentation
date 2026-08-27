---
title: مدیریت جعبه‌های متن در ارائه‌ها در Android
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/androidjava/manage-textbox/
keywords:
- جعبه متن
- چارچوب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای Android از طریق Java ایجاد، ویرایش و تکثیر جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Android از طریق Java رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) را ارائه می‌دهد که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) را ارائه می‌دهد که به شما امکان افزودن اشکال به اسلایدها را می‌دهد. با این حال، تمام اشکالی که از طریق رابط `IShape` اضافه می‌شوند نمی‌توانند متن نگه دارند. اما اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) اضافه می‌شوند می‌توانند متن داشته باشند.
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
بنابراین، هنگامی که با شکلی که می‌خواهید متن اضافه کنید کار می‌کنید، ممکن است بخواهید بررسی و اطمینان حاصل کنید که آن از طریق رابط `IAutoShape` تبدیل (cast) شده است. فقط در این صورت می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrame) کار کنید که یک ویژگی تحت `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/androidjava/manage-textbox/#update-text) را در این صفحه مشاهده کنید.
{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن روی اسلاید، این مراحل را انجام دهید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. مرجع اولین اسلاید در ارائه تازه ساخته‌شده را به دست آورید.  
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) با [ShapeType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) تنظیم‌شده به `Rectangle` در موقعیتی مشخص بر روی اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه اضافه‌شده را دریافت کنید.  
4. ویژگی `TextFrame` را به شیء `IAutoShape` اضافه کنید که متنی را در خود دارد. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox*  
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد جاوا—پیاده‌سازی مراحل بالا—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک شیء Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول ارائه را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // یک TextFrame به Rectangle اضافه می‌کند
    ashp.addTextFrame(" ");

    // به TextFrame دسترسی پیدا می‌کند
    ITextFrame txtFrame = ashp.getTextFrame();

    // شیء Paragraph را برای TextFrame ایجاد می‌کند
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // شیء Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = para.getPortions().get_Item(0);

    // متن را تنظیم می‌کند
    portion.setText("Aspose TextBox");

    // ارائه را روی دیسک ذخیره می‌کند
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **بررسی وجود یک شکل جعبه متن**

Aspose.Slides متد [isTextBox](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#isTextBox--) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) ارائه می‌دهد که به شما امکان بررسی اشکال و شناسایی جعبه‌های متن را می‌دهد.

![جعبه متن و شکل](istextbox.png)

این کد جاوا نشان می‌دهد که چگونه می‌توانید بررسی کنید آیا یک شکل به عنوان جعبه متن ایجاد شده است یا خیر:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ForEach.shape(presentation, (shape, slide, index) -> {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            System.out.println(autoShape.isTextBox() ? "shape is a text box" : "shape is not a text box");
        }
    });
} finally {
    presentation.dispose();
}
```

توجه داشته باشید که اگر فقط یک شکل خودکار را با فراخوانی متد `addAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) اضافه کنید، متد `isTextBox` برای آن شکل خودکار مقدار `false` برمی‌گرداند. با این حال، پس از افزودن متن به شکل خودکار با استفاده از متد `addTextFrame` یا متد `setText`، ویژگی `isTextBox` مقدار `true` برمی‌گرداند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() مقدار false بر می‌گرداند
shape1.addTextFrame("shape 1");
// shape1.isTextBox() مقدار true بر می‌گرداند

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() مقدار false بر می‌گرداند
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() مقدار true بر می‌گرداند

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() مقدار false بر می‌گرداند
shape3.addTextFrame("");
// shape3.isTextBox() مقدار false بر می‌گرداند

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() مقدار false بر می‌گرداند
shape4.getTextFrame().setText("");
// shape4.isTextBox() مقدار false بر می‌گرداند
```

## **یافتن شکلی که یک چارچوب متن را مالک است**

در کدهای عمومی پردازش متن، ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) را دریافت کنید بدون اینکه از قبل بدانید کدام شیء ارائه آن را شامل می‌شود. از متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentShape--) برای بازگشت به [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishape/) مالک استفاده کنید.

برای چارچوب متنی که متعلق به یک [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) یا شکل دیگری حاوی متن است، متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentShape--) صاحب را برمی‌گرداند و متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/#getParentCell--) مقدار `null` برمی‌گرداند. هر دو متد ناوبری فقط‑خواندنی هستند، بنابراین فراخوانی آنها مالکیت را تغییر نمی‌دهد. همیشه قبل از دسترسی به شکل مقدار برگشتی را برای `null` بررسی کنید.

برای یک مثال کامل که مالکین شکل و سلول جدول را شناسایی می‌کند، از جمله شکل‌های مرتبط با گره‌های SmartArt، به [Search and Replace Text](/slides/fa/androidjava/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به یک جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها را مشخص کنید و فاصله بین ستون‌ها را بر حسب نقطه تنظیم کنید.

این کد در جاوا عمل توصیف‌شده را نشان می‌دهد:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // اسلاید اول ارائه را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // یک TextFrame به Rectangle اضافه می‌کند
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // فرمت متن TextFrame را دریافت می‌کند
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // تعداد ستون‌ها در TextFrame را مشخص می‌کند
    format.setColumnCount(3);

    // فاصله بین ستون‌ها را مشخص می‌کند
    format.setColumnSpacing(10);

    // ارائه را ذخیره می‌کند
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن ستون‌ها به یک چارچوب متن**

Aspose.Slides برای Android از طریق Java ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat)) را ارائه می‌دهد که اجازه می‌دهد ستون‌ها در چارچوب‌های متن اضافه شوند. از طریق این ویژگی می‌توانید تعداد ستون‌های مورد نظر خود را در یک چارچوب متن مشخص کنید.

این کد جاوا نشان می‌دهد که چگونه می‌توانید یک ستون داخل یک چارچوب متن اضافه کنید:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    TextFrameFormat format = (TextFrameFormat)shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **به‌روزرسانی متن**

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متنی که در جعبه متن یا تمام متن‌های موجود در یک ارائه وجود دارد را می‌دهد.

این کد جاوا عملی را نشان می‌دهد که در آن تمام متن‌های یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //بررسی می‌کند که آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //از میان پاراگراف‌های فریم متن عبور می‌کند
                {
                    for (IPortion portion : paragraph.getPortions()) //از میان هر بخش در پاراگراف عبور می‌کند
                    {
                        portion.setText(portion.getText().replace("years", "months")); //متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(NullableBool.True); //قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }

    //ارائهٔ تغییر یافته را ذخیره می‌کند
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن یک جعبه متن با پیوند هیپرتکست**

می‌توانید یک پیوند را داخل جعبه متن درج کنید. وقتی جعبه متن کلیک شود، کاربران به باز کردن پیوند هدایت می‌شوند.

برای افزودن یک جعبه متن شامل یک پیوند، این مراحل را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. مرجع اولین اسلاید در ارائه تازه ساخته‌شده را به دست آورید.  
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیتی مشخص بر روی اسلاید اضافه کنید و مرجع شیء AutoShape تازه اضافه‌شده را دریافت کنید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید و متن بخش اول آن را تنظیم کنید. در مثال زیر از این متن استفاده کردیم: *Aspose.Slides*  
5. شیء [IHyperlinkManager](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/) را از `PortionFormat` بخش مورد نظر `TextFrame` خود به دست آورید.  
6. متد [setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) را بر روی آن شیء فراخوانی کنید تا پیوندی که هنگام کلیک بر متن باز می‌شود، تنظیم شود.  
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد جاوا—پیاده‌سازی مراحل بالا—نحوه افزودن یک جعبه متن با پیوند هیپرتکست به اسلاید را نشان می‌دهد:

```java
import com.aspose.slides.*;

// شیء Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اسلاید اول ارائه را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شیء AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // شکل را به AutoShape تبدیل می‌کند
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // متنی به فریم اضافه می‌کند
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // پیوند هیپرتکست برای متن Portion تنظیم می‌شود
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // ارائهٔ PPTX را ذخیره می‌کند
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**تفاوت جعبه متن و محل‌دار متن هنگام کار با اسلایدهای مستر چیست؟**

یک [placeholder](/slides/fa/androidjava/manage-placeholder/) سبک/موقعیت را از [master](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن عادی یک شیء مستقل بر روی اسلاید خاص است و هنگام تغییر طرح‌بندی‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متن به‌صورت انبوه در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را به اشکال خودکاری که دارای چارچوب متن هستند محدود کنید و اشیای توکار ([charts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/smartart/)) را به‌صورت جداگانه پیمایش کرده یا از آن نوع اشیاء صرف‌نظر کنید.