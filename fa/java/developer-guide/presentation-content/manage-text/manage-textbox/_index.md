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
- پاورپوینت
- ارائه
- جاوا
- Aspose.Slides
description: "Aspose.Slides برای جاوا ایجاد، ویرایش و کپی‌برداری از جعبه‌های متن در فایل‌های PowerPoint و OpenDocument را آسان می‌کند و خودکارسازی ارائه شما را بهبود می‌بخشد."
---
## **معرفی**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی را داخل آن قرار دهید. Aspose.Slides for Java رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) را فراهم می‌کند که به شما امکان افزودن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}
Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape) را فراهم می‌کند که به شما امکان افزودن اشکال به اسلایدها را می‌دهد. با این حال، همه اشکالی که از طریق رابط `IShape` اضافه می‌شوند نمی‌توانند متن نگه دارند. اما اشکالی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) اضافه می‌شوند می‌توانند متن داشته باشند. 
{{% /alert %}}

{{% alert title="Note" color="warning" %}} 
بنابراین، هنگام کار با شکلی که می‌خواهید به آن متن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که از طریق رابط `IAutoShape` تبدیل شده است. تنها پس از آن می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrame) کار کنید که یک ویژگی تحت `IAutoShape` است. بخش [به‌روزرسانی متن](https://docs.aspose.com/slides/fa/java/manage-textbox/#update-text) را در این صفحه ببینید. 
{{% /alert %}}

## **ایجاد جعبه متن بر روی اسلاید**

برای ایجاد یک جعبه متن در یک اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائهٔ تازه ایجاد شده به‌دست آورید. 
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IAutoShape) با [ShapeType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IGeometryShape#setShapeType-int-) تنظیم‌شده به‌عنوان `Rectangle` در موقعیت مشخصی از اسلاید اضافه کنید و مرجع شیء `IAutoShape` جدید اضافه‌شده را به‌دست آورید. 
4. یک ویژگی `TextFrame` به شیء `IAutoShape` اضافه کنید که متنی را در بر خواهد گرفت. در مثال زیر، این متن را اضافه کردیم: *Aspose TextBox*
5. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد جاوا—امپلیمنتیشن مراحل بالا—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```java
// یک نمونه از Presentation ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    ISlide sld = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // یک TextFrame به Rectangle اضافه می‌کند
    ashp.addTextFrame(" ");

    // به فریم متن دسترسی پیدا می‌کند
    ITextFrame txtFrame = ashp.getTextFrame();

    // شیء Paragraph را برای فریم متن ایجاد می‌کند
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // شیء Portion را برای پاراگراف ایجاد می‌کند
    IPortion portion = para.getPortions().get_Item(0);

    // متن را تنظیم می‌کند
    portion.setText("Aspose TextBox");

    // ارائه را بر روی دیسک ذخیره می‌کند
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **بررسی وجود شکل جعبه متن**

Aspose.Slides متد [isTextBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/autoshape/#isTextBox--) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) فراهم می‌کند که به شما امکان بررسی اشکال و شناسایی جعبه‌های متن را می‌دهد.

![جعبه متن و شکل](istextbox.png)

این کد جاوا نشان می‌دهد چگونه بررسی کنید آیا یک شکل به‌عنوان جعبه متن ایجاد شده است یا خیر: 

```java
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

توجه داشته باشید که اگر به‌سادگی یک autoshape را با استفاده از متد `addAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/) اضافه کنید، متد `isTextBox` آن autoshape مقدار `false` را برمی‌گرداند. اما پس از افزودن متن به autoshape با استفاده از متد `addTextFrame` یا متد `setText`, ویژگی `isTextBox` مقدار `true` را برمی‌گرداند.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() مقدار false را بر می‌گرداند
shape1.addTextFrame("shape 1");
// shape1.isTextBox() مقدار true را بر می‌گرداند

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() مقدار false را بر می‌گرداند
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() مقدار true را بر می‌گرداند

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() مقدار false را بر می‌گرداند
shape3.addTextFrame("");
// shape3.isTextBox() مقدار false را بر می‌گرداند

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() مقدار false را بر می‌گرداند
shape4.getTextFrame().setText("");
// shape4.isTextBox() مقدار false را بر می‌گرداند
```

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/TextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. شما می‌توانید تعداد ستون‌ها در جعبه متن را تعیین کنید و فاصله بین ستون‌ها را بر حسب پوینت تنظیم کنید. 

این کد در جاوا عملیات توضیح‌داده‌شده را نشان می‌دهد: 

```java
Presentation pres = new Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
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

## **افزودن ستون‌ها به فریم متن**
Aspose.Slides برای جاوا ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ITextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها در فریم‌های متن را می‌دهد. با استفاده از این ویژگی می‌توانید تعداد ستون‌های دلخواه خود را در یک فریم متن مشخص کنید. 

این کد جاوا نشان می‌دهد چگونه یک ستون داخل فریم متن اضافه کنید:

```java
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
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(Double.NaN == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test != null) test.dispose();
    }

    format.setColumnSpacing(20);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test1 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test1.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(2 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(20 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test1 != null) test1.dispose();
    }

    format.setColumnCount(3);
    format.setColumnSpacing(15);
    pres.save(outPptxFileName, SaveFormat.Pptx);

    Presentation test2 = new Presentation(outPptxFileName);
    try {
        IAutoShape autoShape = ((AutoShape)test2.getSlides().get_Item(0).getShapes().get_Item(0));
        Assert.assertTrue(3 == autoShape.getTextFrame().getTextFrameFormat().getColumnCount());
        Assert.assertTrue(15 == autoShape.getTextFrame().getTextFrameFormat().getColumnSpacing());
    } finally {
        if (test2 != null) test2.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **به‌روزرسانی متن**

Aspose.Slides به شما امکان تغییر یا به‌روزرسانی متنی که در جعبه متن یا تمام متون موجود در یک ارائه وجود دارد را می‌دهد. 

این کد جاوا عملیاتی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌کنند:

```java
Presentation pres = new Presentation("text.pptx");
try {
    for (ISlide slide : pres.getSlides())
    {
        for (IShape shape : slide.getShapes())
        {
            if (shape instanceof IAutoShape) //بررسی می‌کند که آیا شکل از فریم متن (IAutoShape) پشتیبانی می‌کند.
            {
                IAutoShape autoShape = (IAutoShape)shape; 
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //تکرار بر پاراگراف‌ها در فریم متن
                {
                    for (IPortion portion : paragraph.getPortions()) //تکرار بر هر بخش (portion) در پاراگراف
                    {
                        portion.setText(portion.getText().replace("years", "months")); //تغییر متن
                        portion.getPortionFormat().setFontBold(NullableBool.True); //تغییر قالب‌بندی
                    }
                }
            }
        }
    }

    //ذخیره ارائهٔ تغییر یافته
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن جعبه متن با پیوند** 

می‌توانید یک پیوند را داخل جعبه متن وارد کنید. وقتی بر روی جعبه متن کلیک شود، کاربران به باز کردن پیوند هدایت می‌شوند. 

برای افزودن جعبه متنی که حاوی پیوند باشد، این مراحل را دنبال کنید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید. 
2. یک مرجع برای اولین اسلاید در ارائه تازه ایجاد شده به‌دست آورید. 
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به‌عنوان `Rectangle` در موقعیت مشخصی از اسلاید اضافه کنید و مرجع شیء AutoShape جدید اضافه‌شده را به‌دست آورید.
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که *Aspose TextBox* را به‌عنوان متن پیش‌فرض خود داشته باشد. 
5. کلاس `IHyperlinkManager` را نمونه‌سازی کنید. 
6. شیء `IHyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Shape#getHyperlinkClick--) مرتبط با بخش دلخواه شما از `TextFrame` اختصاص دهید. 
7. در نهایت، فایل PPTX را از طریق شیء `Presentation` بنویسید. 

این کد جاوا—امپلیمنتیشن مراحل بالا—نقش افزودن جعبه متن با پیوند به یک اسلاید را نشان می‌دهد:

```java
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شیء AutoShape با نوع تنظیم‌شده به Rectangle اضافه می‌کند
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // تبدیل شیء shape به AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // دسترسی به ویژگی ITextFrame مرتبط با AutoShape
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // افزودن متنی به فریم
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // تنظیم پیوند فراخوانی برای متن portion
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // ذخیره ارائهٔ PPTX
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**تفاوت جعبه متن و جای‌گیر متن در کار با اسلایدهای اصلی چیست؟**

یک [جای‌گیر](/slides/fa/java/manage-placeholder/) سبک/موقعیت خود را از [قالب اصلی](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [طرح‌بندی‌ها](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل در اسلاید خاصی است و هنگام تغییر طرح‌بندی‌ها تغییر نمی‌کند.

**چگونه می‌توانم جایگزینی گروهی متن را در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را به auto‑shapes‌هایی که فریم متن دارند محدود کنید و اشیاء تعبیه‌شده ([charts](https://reference.aspose.com/slides/fa/java/com.aspose.slides/chart/), [tables](https://reference.aspose.com/slides/fa/java/com.aspose.slides/table/), [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/smartart/)) را از طریق عبور از مجموعه‌هایشان به‌صورت جداگانه یا صرف‌نظر از آن نوع اشیاء حذف کنید.