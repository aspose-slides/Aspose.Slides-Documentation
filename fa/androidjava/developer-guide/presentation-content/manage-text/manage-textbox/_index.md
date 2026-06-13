---
title: مدیریت جعبه‌های متن در ارائه‌ها در اندروید
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/androidjava/manage-textbox/
keywords:
- جعبه متن
- قاب متن
- اضافه کردن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- اضافه کردن ستون متن
- اضافه کردن پیوند
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "Aspose.Slides برای اندروید از طریق جاوا ایجاد، ویرایش و تکثیر جعبه‌های متن را در فایل‌های PowerPoint و OpenDocument به راحتی امکان‌پذیر می‌کند و خودکارسازی ارائه‌های شما را ارتقا می‌دهد."
---
## **مقدمه**

متن‌ها در اسلایدها معمولاً در جعبه‌های متن یا شکل‌ها وجود دارند. بنابراین، برای افزودن متن به یک اسلاید، باید یک جعبه متن اضافه کنید و سپس متنی داخل آن قرار دهید. Aspose.Slides برای Android از طریق Java رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) را فراهم می‌کند که به شما امکان اضافه کردن شکلی حاوی متن را می‌دهد.

{{% alert title="Info" color="info" %}}

Aspose.Slides همچنین رابط [IShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape) را فراهم می‌کند که به شما امکان اضافه کردن شکل‌ها به اسلایدها را می‌دهد. با این حال، همه شکل‌هایی که از طریق رابط `IShape` اضافه می‌شوند نمی‌توانند متن نگه دارند. اما شکل‌هایی که از طریق رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) اضافه می‌شوند می‌توانند متن داشته باشند.

{{% /alert %}}

{{% alert title="Note" color="warning" %}} 

بنابراین، زمانی که با شکلی سر و کار دارید که می‌خواهید متن به آن اضافه کنید، ممکن است بخواهید بررسی و تأیید کنید که آن شیء از طریق رابط `IAutoShape` تبدیل شده است. فقط پس از آن می‌توانید با [TextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrame) کار کنید که یک ویژگی تحت `IAutoShape` است. بخش [Update Text](https://docs.aspose.com/slides/fa/androidjava/manage-textbox/#update-text) در این صفحه را ببینید.

{{% /alert %}}

## **ایجاد جعبه متن در یک اسلاید**

برای ایجاد یک جعبه متن در یک اسلاید، این مراحل را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.  
2. یک مرجع برای اولین اسلاید در ارائهٔ تازه ساخته‌شده به دست آورید.  
3. یک شیء [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IAutoShape) با [ShapeType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IGeometryShape#setShapeType-int-) تنظیم‌شده به `Rectangle` در موقعیت مشخصی از اسلاید اضافه کنید و مرجع شیء `IAutoShape` تازه‌اضافه‌شده را دریافت کنید.  
4. ویژگی `TextFrame` را به شیء `IAutoShape` اضافه کنید که متنی را در خود خواهد داشت. در مثال زیر این متن را اضافه کردیم: *Aspose TextBox*  
5. در پایان، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد جاوا—یک پیاده‌سازی از مراحل بالا—نحوه افزودن متن به یک اسلاید را نشان می‌دهد:

```java
// ایجاد نمونه Presentation
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید در ارائه
    ISlide sld = pres.getSlides().get_Item(0);

    // افزودن AutoShape با تنظیم نوع به Rectangle
    IAutoShape ashp = sld.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 150, 50);

    // افزودن TextFrame به Rectangle
    ashp.addTextFrame(" ");

    // دسترسی به فریم متن
    ITextFrame txtFrame = ashp.getTextFrame();

    // ایجاد شی Paragraph برای فریم متن
    IParagraph para = txtFrame.getParagraphs().get_Item(0);

    // ایجاد شی Portion برای پاراگراف
    IPortion portion = para.getPortions().get_Item(0);

    // تنظیم متن
    portion.setText("Aspose TextBox");

    // ذخیره ارائه بر روی دیسک
    pres.save("TextBox_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **بررسی وجود شکل جعبه متن**

Aspose.Slides روش [isTextBox](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/#isTextBox--) را از رابط [IAutoShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iautoshape/) ارائه می‌دهد که به شما امکان بررسی شکل‌ها و شناسایی جعبه‌های متن را می‌دهد.

![جعبه متن و شکل](istextbox.png)

این کد جاوا نشان می‌دهد چگونه بررسی کنید که آیا یک شکل به عنوان جعبه متن ایجاد شده است یا نه:

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

توجه داشته باشید اگر به سادگی یک شکل خودکار را با استفاده از روش `addAutoShape` از رابط [IShapeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ishapecollection/) اضافه کنید، متد `isTextBox` برای آن شکل خودکار مقدار `false` برمی‌گرداند. اما پس از اینکه متن را به شکل خودکار با استفاده از روش `addTextFrame` یا `setText` اضافه کردید، ویژگی `isTextBox` مقدار `true` می‌شود.

```java
Presentation presentation = new Presentation();
ISlide slide = presentation.getSlides().get_Item(0);

IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
// shape1.isTextBox() مقدار false برمی‌گردد
shape1.addTextFrame("shape 1");
// shape1.isTextBox() مقدار true برمی‌گردد

IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 110, 100, 40);
// shape2.isTextBox() مقدار false برمی‌گردد
shape2.getTextFrame().setText("shape 2");
// shape2.isTextBox() مقدار true برمی‌گردد

IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 210, 100, 40);
// shape3.isTextBox() مقدار false برمی‌گردد
shape3.addTextFrame("");
// shape3.isTextBox() مقدار false برمی‌گردد

IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 310, 100, 40);
// shape4.isTextBox() مقدار false برمی‌گردد
shape4.getTextFrame().setText("");
// shape4.isTextBox() مقدار false برمی‌گردد
```

## **افزودن ستون‌ها به جعبه متن**

Aspose.Slides ویژگی‌های [ColumnCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) و [ColumnSpacing](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnSpacing-double-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat) و کلاس [TextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها به جعبه‌های متن را می‌دهد. شما می‌توانید تعداد ستون‌ها در یک جعبه متن را مشخص کنید و فاصلهٔ بین ستون‌ها را بر حسب نقطه تنظیم کنید.

این کد جاوا عملیات شرح‌داده‌شده را نشان می‌دهد:

```java
Presentation pres = new Presentation();
try {
    // دریافت اولین اسلاید در ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن AutoShape با تنظیم نوع به Rectangle
    IAutoShape aShape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 300);

    // افزودن TextFrame به Rectangle
    aShape.addTextFrame("All these columns are limited to be within a single text container -- " +
            "you can add or delete text and the new or remaining text automatically adjusts " +
            "itself to flow within the container. You cannot have text flow from one container " +
            "to other though -- we told you PowerPoint's column options for text are limited!");

    // دریافت قالب متن TextFrame
    ITextFrameFormat format = aShape.getTextFrame().getTextFrameFormat();

    // تعیین تعداد ستون‌ها در TextFrame
    format.setColumnCount(3);

    // تعیین فاصله بین ستون‌ها
    format.setColumnSpacing(10);

    // ذخیره ارائه
    pres.save("ColumnCount.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن ستون‌ها به چارچوب متن**

Aspose.Slides برای Android از طریق Java ویژگی [ColumnCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat#setColumnCount-int-) (از رابط [ITextFrameFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ITextFrameFormat)) را فراهم می‌کند که به شما امکان افزودن ستون‌ها در چارچوب‌های متن را می‌دهد. با استفاده از این ویژگی می‌توانید تعداد ستون‌های دلخواه خود را در یک چارچوب متن تعیین کنید.

این کد جاوا نشان می‌دهد چگونه یک ستون داخل چارچوب متن اضافه کنید:

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

Aspose.Slides به شما اجازه می‌دهد متن موجود در یک جعبه متن یا تمام متون موجود در یک ارائه را تغییر یا به‌روزرسانی کنید.

این کد جاوا عملی را نشان می‌دهد که در آن تمام متون یک ارائه به‌روزرسانی یا تغییر می‌یابند:

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
                for (IParagraph paragraph : autoShape.getTextFrame().getParagraphs()) //در میان پاراگراف‌های فریم متن تکرار می‌کند
                {
                    for (IPortion portion : paragraph.getPortions()) //در میان هر بخش (portion) در پاراگراف تکرار می‌کند
                    {
                        portion.setText(portion.getText().replace("years", "months")); //متن را تغییر می‌دهد
                        portion.getPortionFormat().setFontBold(NullableBool.True); //قالب‌بندی را تغییر می‌دهد
                    }
                }
            }
        }
    }

    //ارائه اصلاح‌شده را ذخیره می‌کند
    pres.save("text-changed.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن جعبه متن با پیوندهای فرامونی**

شما می‌توانید یک پیوند را داخل جعبه متن وارد کنید. وقتی جعبه متن کلیک شود، کاربران به باز کردن پیوند هدایت می‌شوند.

برای افزودن یک جعبه متن شامل پیوند، این مراحل را انجام دهید:

1. یک نمونه از کلاس `Presentation` ایجاد کنید.  
2. یک مرجع برای اولین اسلاید در ارائهٔ تازه ساخته‌شده به دست آورید.  
3. یک شیء `AutoShape` با `ShapeType` تنظیم‌شده به `Rectangle` در موقعیت مشخصی از اسلید اضافه کنید و مرجع شیء AutoShape تازه‌اضافه‌شده را دریافت کنید.  
4. یک `TextFrame` به شیء `AutoShape` اضافه کنید که متن پیش‌فرض *Aspose TextBox* را در خود دارد.  
5. کلاس `IHyperlinkManager` را نمونه‌سازی کنید.  
6. شیء `IHyperlinkManager` را به ویژگی [HyperlinkClick](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Shape#getHyperlinkClick--) مربوط به بخش دلخواه شما از `TextFrame` اختصاص دهید.  
7. در پایان، فایل PPTX را از طریق شیء `Presentation` بنویسید.  

این کد جاوا—یک پیاده‌سازی از مراحل بالا—نحوه افزودن جعبه متن با پیوند فرامونی به یک اسلاید را نشان می‌دهد:

```java
// یک شیء از کلاس Presentation که نمایانگر یک فایل PPTX است را ایجاد می‌کند
Presentation pres = new Presentation();
try {
    // اولین اسلاید در ارائه را دریافت می‌کند
    ISlide slide = pres.getSlides().get_Item(0);

    // یک شیء AutoShape با نوع تنظیم شده به Rectangle اضافه می‌کند
    IShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 150, 50);

    // تبدیل شکل به AutoShape
    IAutoShape pptxAutoShape = (IAutoShape)shape;

    // به ویژگی ITextFrame مرتبط با AutoShape دسترسی پیدا می‌کند
    pptxAutoShape.addTextFrame("");

    ITextFrame textFrame = pptxAutoShape.getTextFrame();

    // مقداری متن به فریم اضافه می‌کند
    textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).setText("Aspose.Slides");

    // پیوند (Hyperlink) را برای متن بخش تنظیم می‌کند
    IHyperlinkManager hyperlinkManager = textFrame.getParagraphs().get_Item(0).getPortions().get_Item(0).
            getPortionFormat().getHyperlinkManager();
    hyperlinkManager.setExternalHyperlinkClick("http://www.aspose.com");

    // ارائه PPTX را ذخیره می‌کند
    pres.save("hLink_out.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **پرسش‌های متداول**

**تفاوت جعبه متن و محل نگهداری متن (placeholder) هنگام کار با اسلایدهای اصلی چیست؟**

یک [placeholder](/slides/fa/androidjava/manage-placeholder/) سبک/موقعیت خود را از [master](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/masterslide/) به ارث می‌برد و می‌تواند در [layouts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/layoutslide/) بازنویسی شود، در حالی که یک جعبه متن معمولی یک شیء مستقل در یک اسلاید خاص است و هنگام تغییر لایه‌ها تغییر نمی‌کند.

**چگونه می‌توانم یک جایگزینی متن به‌صورت گروهی در سراسر ارائه انجام دهم بدون اینکه به متن داخل نمودارها، جداول و SmartArt دست بزنم؟**

تکرار خود را به auto‑shapesهایی که چارچوب متن دارند محدود کنید و اشیای توکار مثل [charts](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/chart/)، [tables](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/table/)، [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/smartart/) را از طریق پیمایش مجموعه‌های آن‌ها به‌صورت جداگانه حذف کنید یا آن نوع اشیا را نادیده بگیرید.