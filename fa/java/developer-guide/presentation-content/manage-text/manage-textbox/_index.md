---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/java/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- افزودن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "Aspose.Slides برای Java ایجاد، ویرایش و کلون‌کردن جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و به‌طور قابل‌توجهی خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا اشکال وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای جاوا رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) را فراهم می‌کند که به شما امکان اضافه کردن یک شکل حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}

Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) را فراهم می‌کند که به شما امکان اضافه کردن اشکال به اسلایدها را می‌دهد. با این حال، همه اشکالی که از طریق رابط `IShape` اضافه می‌شوند نمی‌توانند متن را نگه دارند. اما اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) اضافه می‌شوند می‌توانند متن داشته باشند. 

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بنابراین، هنگام کار با شکلی که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که این شکل از طریق رابط `IAutoShape` تبدیل شده است. فقط پس از آن می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrame) کار کنید، که یک ویژگی تحت `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/java/manage-textbox/#update-text) را در این صفحه ببینید. 

{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن در اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائه‌ای که به تازگی ایجاد کرده‌اید به دست آورید. 
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه اضافه‌شده را دریافت کنید. 
4. ویژگی `TextFrame` را به شیء `IAutoShape` اضافه کنید که شامل متنی خواهد بود. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox* 
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد Java—یک پیاده‌سازی از مراحل بالا—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک شی Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید را در ارائه دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع Rectangle اضافه می‌کند
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // یک TextFrame را به Rectangle اضافه می‌کند
    ashp.addTextFrame(" ");

    // به TextFrame دسترسی پیدا می‌کند
    ITextFrame txtFrame = ashp.getTextFrame();

    // شیء Paragraph را برای TextFrame می‌سازد
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // شیء Portion را برای پاراگراف می‌سازد
    IPortion portion = para.getPortions().get_Item(0);

    // متن را تنظیم می‌کند
    portion.setText("Aspose TextBox");

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **بررسی یک شکل جعبه متن**

Aspose.Slides متد [isTextBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/#isTextBox--) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) فراهم می‌کند تا به شما امکان بررسی اشکال و شناسایی جعبه‌های متن را بدهد.

![جعبه متن و شکل](istextbox.png)

این کد Java نشان می‌دهد که چگونه بررسی کنید آیا یک شکل به‌عنوان جعبه متن ایجاد شده است یا خیر: 

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

توجه داشته باشید که اگر به سادگی یک autoshape را با متد `addAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) اضافه کنید، متد `isTextBox` برای آن autoshape مقدار `false` برمی‌گرداند. با این حال، پس از افزودن متن به autoshape با استفاده از متد `addTextFrame` یا متد `setText`، ویژگی `isTextBox` مقدار `true` برمی‌گرداند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() مقدار false را برمی‌گرداند
shape1.addTextFrame("shape 1");
// shape1.isTextBox() مقدار true را برمی‌گرداند

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() مقدار false را برمی‌گرداند
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() مقدار true را برمی‌گرداند

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() مقدار false را برمی‌گرداند
shape3.addTextFrame("");
// shape3.isTextBox() مقدار false را برمی‌گرداند

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() مقدار false را برمی‌گرداند
shape4.getTextFrame().setText("");
// shape4.isTextBox() مقدار false را برمی‌گرداند
```

## **یافتن شکلی که یک TextFrame را در اختیار دارد**

در کدهای عمومی پردازش متن، ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) دریافت کنید بدون اینکه بدانید کدام شیء ارائه آن را شامل می‌شود. از متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) برای بازگشت به [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) مالک استفاده کنید.

برای یک TextFrame که به یک [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) یا شکل دیگری حاوی متن تعلق دارد، متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) مالک را برمی‌گرداند و متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) مقدار `null` را برمی‌گرداند. هر دو متد ناوش فقط‑خواندنی هستند، بنابراین فراخوانی آن‌ها مالکیت را تغییر نمی‌دهد. پیش از دسترسی به شکل، همیشه مقدار برگشتی را برای `null` بررسی کنید.

برای یک مثال کامل که مالکان شکل و سلول جدول، از جمله اشکال مرتبط با نودهای SmartArt را شناسایی می‌کند، به بخش [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به یک جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. می‌توانید تعداد ستون‌ها در یک جعبه متن را مشخص کنید و فاصله بین ستون‌ها را بر حسب نقطه تنظیم کنید. 

این کد Java عملیات توصیف‌شده را نشان می‌دهد: 

```java
import com.aspose.slides.*;

Presentation pres = new Presentation();
try {
    // اولین اسلاید را در ارائه دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع Rectangle اضافه می‌کند
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // یک TextFrame به Rectangle اضافه می‌کند
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // قالب متن TextFrame را دریافت می‌کند
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

## **افزودن ستون‌ها به یک TextFrame**

Aspose.Slides برای Java ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها در TextFrame‌ها را می‌دهد. از طریق این ویژگی می‌توانید تعداد ستون دلخواه خود را در یک TextFrame مشخص کنید. 

این کد Java نشان می‌دهد که چگونه یک ستون داخل یک TextFrame اضافه کنید:

```java
import com.aspose.slides.*;

String outPptxFileName = "ColumnsTest.pptx";
Presentation pres = new Presentation();
try {
    IAutoShape shape1 = pres.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);
    ITextFrameFormat format = shape1.getTextFrame().getTextFrameFormat();

    format.setColumnCount(2);
    shape1.getTextFrame().setText("All these columns are forced to stay within a single text container -- " +
            "you can add or delete text - and the new or remaining text automatically adjusts " +
            "itself to stay within the container. You cannot have text spill over from one container " +
            "to other, though -- because PowerPoint's column options for text are limited!");
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test.getSlides().get_Item(0).getShapes().get_Item(0);
        System.out.println("Column count: " + autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        System.out.println("Column spacing: " + autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = (IAutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0);
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
        IAutoShape autoShape = (IAutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0);
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

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک جعبه متن یا تمام متون موجود در یک ارائه را تغییر یا به‌روزرسانی کنید. 

این کد Java عملیاتی را نشان می‌دهد که در آن تمام متن‌های یک ارائه به‌روزرسانی یا تغییر می‌یابند:

```java
import com.aspose.slides.*;

Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //بررسی می‌کند آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //در میان پاراگراف‌های فریم متن تکرار می‌کند
                {
                    for (IPortion portion : paragraph.getPortions()) //در میان هر بخش در پاراگراف تکرار می‌کند
                    {
                        portion.setText(portion.getText().replace("years", "months")); //متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(NullableBool.True); //قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }

    //ارائه تغییر یافته را ذخیره می‌کند
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **اضافه کردن یک جعبه متن با پیوند**

شما می‌توانید یک پیوند را داخل یک جعبه متن قرار دهید. وقتی جعبه متن کلیک شود، کاربران به باز کردن پیوند هدایت می‌شوند. 

برای افزودن یک جعبه متن شامل پیوند، این مراحل را طی کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائه‌ی تازه ایجاد‌شده به دست آورید. 
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی روی اسلاید اضافه کنید و مرجع شیء AutoShape تازه اضافه‌شده را دریافت کنید. 
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که شامل *Aspose TextBox* به‌عنوان متن پیش‌فرض باشد. 
5. نمونه‌ای از کلاس `IHyperlinkManager` بسازید. 
6. شیء `IHyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Shape#getHyperlinkClick--) مرتبط با بخش مورد نظر شما از `TextFrame` اختصاص دهید. 
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد Java—یک پیاده‌سازی از مراحل بالا—نحوه اضافه کردن یک جعبه متن با پیوند به اسلاید را نشان می‌دهد:

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک PPTX است
Presentation pres = new Presentation();
try {
    // اولین اسلاید را در ارائه دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شی AutoShape با نوع Rectangle اضافه می‌کند
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // تبدیل شی به AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // دسترسی به ویژگی ITextFrame مرتبط با AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // افزودن متنی به فریم
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // تنظیم Hyperlink برای متن Portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // ذخیره ارائه PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **FAQ**

**تفاوت بین جعبه متن و جای‌نگهدارنده متن هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/java/manage-placeholder/) سبک/موقعیت خود را از [master](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل در اسلاید خاص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی متن به‌صورت انبوه در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جدول‌ها و SmartArt دست بزنم؟**

تکرار خود را به auto‑shapesی که دارای TextFrame هستند محدود کنید و اشیای توکار ([charts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/java/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/smartart/)) را با پیمایش مجموعه‌هایشان جداگانه یا حذف آن نوع اشیاء نادیده بگیرید.