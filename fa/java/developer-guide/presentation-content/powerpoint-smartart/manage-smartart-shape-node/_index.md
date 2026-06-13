---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها با استفاده از Java
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/java/manage-smartart-shape-node/
keywords:
- گره SmartArt
- گره فرزند
- افزودن گره
- موقعیت گره
- دسترسی به گره
- حذف گره
- موقعیت سفارشی
- گره دستیار
- فرمت پرکننده
- رندر گره
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای Java. دریافت نمونه کد واضح و نکات برای بهینه‌سازی ارائه‌های خود."
---
## **مروری کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن دارند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: افزودن گره‌ها و گره‌های فرزند جدید، درج گره‌های فرزند در موقعیت خاص، دسترسی به گره‌های موجود و خواندن متن، سطح و موقعیت آن‌ها.

این مقاله نحوه مدیریت گره‌های شکل SmartArt را توضیح می‌دهد. نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، یک گره دستیار را به گره عادی تغییر دهید، موقعیت، اندازه و چرخش اشکال گره‌های SmartArt را تنظیم کنید، فرمت پرکننده گره را تنظیم کنید و تصویر بندانگشتی یک گره فرزند SmartArt را تولید کنید.

## **افزودن یک گره SmartArt**
Aspose.Slides for Java ساده‌ترین API برای مدیریت اشکال SmartArt را به آسان‌ترین شکل ارائه داده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را داخل شکل SmartArt اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص آن، به اسلاید اول دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل (typecast) کنید.
5. در مجموعه گره‌های SmartArt shape **[NodeCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt#getAllNodes--)**، یک **[Add a new Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)** اضافه کنید و متن را در TextFrame تنظیم کنید.
6. حالا یک **[Child Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--)** در گره SmartArt تازه اضافه شده **[Add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)** کنید و متن را در TextFrame تنظیم کنید.
7. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // از طریق تمام اشکال داخل اسلاید اول پیمایش کنید
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل (typecast) شکل به SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // افزودن یک گره جدید SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // افزودن متن
            TemNode.getTextFrame().setText("Test");
    
            // افزودن گره فرزند جدید به گره والد. این گره در انتهای مجموعه اضافه خواهد شد
            SmartArtNode newNode = (SmartArtNode) TemNode.getChildNodes().addNode();
    
            // افزودن متن
            newNode.getTextFrame().setText("New Node Added");
        }
    }
    
    // ذخیره‌سازی ارائه
    pres.save("AddSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **افزودن گره SmartArt در موقعیت خاص**
در کد نمونهٔ زیر نحوه افزودن گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt در موقعیت خاص را شرح می‌دهیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. در اسلاید مورد دسترسی، یک شکل SmartArt از نوع **[StackedList](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType#StackedList)** اضافه کنید.
4. به اولین گره در شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
5. حالا **[Child Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--)** را برای **[Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtNode)** انتخاب‌شده در موقعیت ۲ اضافه کنید و متن آن را تنظیم کنید.
6. ارائه را ذخیره کنید.

```java
// ایجاد یک نمونه ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن IShape از نوع Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // دسترسی به گره SmartArt با شاخص 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);

    // افزودن گره فرزند جدید در موقعیت 2 در گره والد
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).addNodeByPosition(2);

    // افزودن متن
    chNode.getTextFrame().setText("Sample Text Added");

    // ذخیره‌سازی ارائه
    pres.save("AddSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به یک گره SmartArt**
کد نمونهٔ زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. توجه داشته باشید که شما نمی‌توانید LayoutType را تغییر دهید زیرا فقط در زمان افزودن شکل SmartArt قابل تنظیم است و فقط برای خواندن است.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
5. از طریق همهٔ **[Nodes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt#getAllNodes--)** داخل شکل SmartArt پیمایش کنید.
6. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```java
// ایجاد نمونه کلاس Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // دریافت اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش از طریق تمام اشکال داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل (typecast) شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // پیمایش از طریق تمام گره‌های داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // دسترسی به گره SmartArt با شاخص i
                SmartArtNode node = (SmartArtNode) smart.getAllNodes().get_Item(i);
    
                // چاپ پارامترهای گره SmartArt
                System.out.print(node.getTextFrame().getText() + " " + node.getLevel() + " " + node.getPosition());
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به یک گره فرزند SmartArt**
کد نمونهٔ زیر به شما کمک می‌کند گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt را دسترسی داشته باشید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
5. از طریق همهٔ **[Nodes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArt#getAllNodes--)** داخل شکل SmartArt پیمایش کنید.
6. برای هر **[Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtNode)** انتخاب‌شده، از طریق تمام **[Child Nodes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtNode#getChildNodes--)** داخل گره خاص پیمایش کنید.
7. اطلاعاتی مانند موقعیت **[Child Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--)**، سطح و متن را دسترسی و نمایش دهید.

```java
// ایجاد نمونه کلاس Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // دریافت اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش از طریق تمام اشکال داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل (typecast) شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // پیمایش از طریق تمام گره‌های داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // دسترسی به گره SmartArt با شاخص i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // پیمایش از طریق گره‌های فرزند در گره SmartArt با شاخص i
                for (int j = 0; j < node0.getChildNodes().size(); j++) 
                {
                    // دسترسی به گره فرزند در گره SmartArt
                    SmartArtNode node = (SmartArtNode) node0.getChildNodes().get_Item(j);
    
                    // چاپ پارامترهای گره فرزند SmartArt
                    System.out.print("j = " + j + ", Text = " + node.getTextFrame().getText() + ",  Level = " + node.getLevel() + ", Position = " + node.getPosition());
                }
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **دسترسی به یک گره فرزند SmartArt در موقعیت خاص**
در این مثال، نحوه دسترسی به گره‌های فرزند در موقعیت خاصی از گره‌های مربوط به شکل SmartArt را می‌آموزید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. یک شکل SmartArt از نوع **[StackedList](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType#StackedList)** اضافه کنید.
4. به شکل SmartArt افزوده‌شده دسترسی پیدا کنید.
5. گره‌ای با شاخص ۰ برای شکل SmartArt دسترسی یافته را دریافت کنید.
6. حالا با استفاده از متد **get_Item()**، **[Child Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--)** در موقعیت ۱ برای گره SmartArt دسترسی یافته را دریافت کنید.
7. اطلاعاتی مانند موقعیت **[Child Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--)**، سطح و متن را دسترسی و نمایش دهید.

```java
// ایجاد نمونه ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل SmartArt در اسلاید اول
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // دسترسی به گره SmartArt با شاخص 0
    ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
    // دسترسی به گره فرزند در موقعیت 1 در گره والد
    int position = 1;
    SmartArtNode chNode = (SmartArtNode) ((SmartArtNodeCollection) node.getChildNodes()).get_Item(position);
    
    // چاپ پارامترهای گره فرزند SmartArt
    System.out.print("Text = " + chNode.getTextFrame().getText() + ",  Level = " + chNode.getLevel() + ", Position = " + chNode.getPosition());
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یک گره SmartArt**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt را می‌آموزید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
5. بررسی کنید آیا [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) بیش از ۰ گره دارد.
6. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
7. حالا گره انتخاب‌شده را با استفاده از متد **[RemoveNode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)** حذف کنید.
8. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش از طریق تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // دسترسی به گره SmartArt با شاخص 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // حذف گره انتخاب‌شده
                smart.getAllNodes().removeNode(node);
            }
        }
    }
    
    // ذخیره‌سازی ارائه
    pres.save("RemoveSmartArtNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **حذف یک گره SmartArt از موقعیت خاص**
در این مثال، نحوه حذف گره‌های داخل شکل SmartArt در موقعیت خاصی را می‌آموزید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص، به اسلاید اول دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
5. گره شکل SmartArt در شاخص ۰ را انتخاب کنید.
6. حالا بررسی کنید آیا گره SmartArt انتخاب‌شده بیش از ۲ گره فرزند دارد.
7. حالا گره در **Position 1** را با استفاده از متد **[RemoveNode](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)** حذف کنید.
8. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش از طریق تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل شکل به SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // دسترسی به گره SmartArt با شاخص 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                if (node.getChildNodes().size() >= 2) 
                {
                    // حذف گره فرزند در موقعیت 1
                    (node.getChildNodes()).removeNode(1);
                }
            }
        }
    }
    
    // ذخیره‌سازی ارائه
    pres.save("RemoveSmartArtNodeByPosition.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تنظیم موقعیت سفارشی برای یک گره فرزند در یک شیء SmartArt**
اکنون Aspose.Slides for Java از تنظیم خصوصیات **X** (https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#setX-float-) و **Y** (https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#setY-float-) برای **SmartArtShape** پشتیبانی می‌کند. قطعه کد زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی برای SmartArtShape تنظیم شود؛ همچنین توجه داشته باشید که افزودن گره‌های جدید موجب بازمحاسبهٔ موقعیت و اندازهٔ تمام گره‌ها می‌شود. با تنظیمات موقعیت سفارشی، کاربر می‌تواند گره‌ها را برحسب نیاز تنظیم کند.

```java
// ایجاد نمونه کلاس Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // جابه‌جایی شکل SmartArt به موقعیت جدید
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // تغییر پهنای شکل SmartArt
    node = smart.getAllNodes().get_Item(2);
    shape = node.getShapes().get_Item(1);
    shape.setWidth(shape.getWidth() + shape.getWidth() * 2);

    // تغییر ارتفاع شکل SmartArt
    node = smart.getAllNodes().get_Item(3);
    shape = node.getShapes().get_Item(1);
    shape.setHeight(shape.getHeight() + shape.getHeight() * 2);

    // تغییر چرخش شکل SmartArt
    node = smart.getAllNodes().get_Item(4);
    shape = node.getShapes().get_Item(1);
    shape.setRotation(90);

    pres.save("SmartArt.pptx", SaveFormat.Pptx);
}finally {
    pres.dispose();
}
```

## **بررسی یک گره دستیار**
{{% alert color="primary" %}} 

در این مقاله به بررسی بیشتر ویژگی‌های اشکال SmartArt اضافه‌شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با استفاده از Aspose.Slides for Java می‌پردازیم.

{{% /alert %}} 

ما از شکل SmartArt زیر برای بررسی در بخش‌های مختلف این مقاله استفاده می‌کنیم.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**Figure: Source SmartArt shape in slide**|

در کد نمونهٔ زیر نحوه تشخیص **Assistant Nodes** در مجموعه گره‌های SmartArt و تغییر وضعیت آن‌ها را بررسی می‌کنیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه‌ای را که شامل شکل SmartArt است بارگذاری کنید.
2. با استفاده از شاخص، به اسلاید دوم دسترسی پیدا کنید.
3. از طریق همهٔ اشکال داخل اسلاید اول پیمایش کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، شکل انتخابی را به [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
5. از طریق تمام گره‌های داخل شکل SmartArt پیمایش کنید و بررسی کنید آیا آن‌ها **Assistant Nodes** هستند (https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtNode#isAssistant--).
6. وضعیت گره دستیار را به گره عادی تغییر دهید.
7. ارائه را ذخیره کنید.

```java
// ایجاد یک نمونه ارائه
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // پیمایش از طریق تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی کنید آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل شکل به SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // پیمایش از طریق تمام گره‌های شکل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // بررسی کنید آیا گره یک گره دستیار است
                if (node.isAssistant()) 
                {
                    // تنظیم گره دستیار به false و تبدیل آن به گره عادی
                    node.isAssistant();
                }
            }
        }
    }
    
    // ذخیره‌سازی ارائه
    pres.save("ChangeAssitantNode.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/qpAl4rN.png)|
| :- |
|**Figure: Assistant Nodes Changed in SmartArt shape inside slide**|

## **تنظیم فرمت پرکنندهٔ گره**
Aspose.Slides for Java امکان افزودن اشکال SmartArt سفارشی و تنظیم فرمت پرکنندهٔ آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد، دسترسی و فرمت پرکنندهٔ آن‌ها را با استفاده از Aspose.Slides for Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
2. با استفاده از شاخص، به یک اسلاید دسترسی پیدا کنید.
3. با تنظیم **[LayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)**، یک شکل [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) اضافه کنید.
4. برای گره‌های شکل SmartArt، **[FillFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/IShape#getFillFormat--)** را تنظیم کنید.
5. ارائهٔ تغییر یافته را به‌عنوان یک فایل PPTX ذخیره کنید.

```java
// ایجاد نمونه ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل SmartArt و گره‌ها
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // تنظیم رنگ پرکننده گره
    for (IShape item : node.getShapes()) 
    {
        item.getFillFormat().setFillType(FillType.Solid);
        item.getFillFormat().getSolidFillColor().setColor(Color.RED);
    }
    
    // ذخیره‌سازی ارائه
    pres.save("TestSmart.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

## **تولید تصویر بندانگشتی یک گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با دنبال کردن مراحل زیر، تصویر بندانگشتی گره فرزند یک SmartArt را تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
2. یک SmartArt **[Add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)** کنید.
3. با استفاده از شاخص، به یک گره دسترسی پیدا کنید.
4. تصویر بندانگشتی را دریافت کنید.
5. تصویر بندانگشتی را در هر قالب تصویری مورد نظر ذخیره کنید.

```java
// ایجاد نمونه کلاس Presentation که فایل PPTX را نمایندگی می‌کند
Presentation pres = new Presentation();
try {
    // افزودن SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // دریافت مرجع یک گره با استفاده از شاخص آن
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // دریافت تصویر بندانگشتی
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // ذخیره تصویر بندانگشتی
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سؤالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل معمولی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/java/shape-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم کنید. همچنین می‌توانید در صورت نیاز، شکل‌های داخل گره‌های SmartArt را نیز انیمیت کنید.

**چگونه می‌توانم یک SmartArt خاص را در اسلاید به‌دست آورم اگر شناسه داخلی آن ناشناخته باشد؟**

با اختصاص و جستجو بر اساس [متن جایگزین](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getAlternativeText--) می‌توانید آن را پیدا کنید. تنظیم AltText متمایز بر روی SmartArt به شما اجازه می‌دهد به‌صورت برنامه‌نویسی بدون وابستگی به شناسه‌های داخلی آن را بیابید.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides هنگام [صادرات PDF](/slides/fa/java/convert-powerpoint-to-pdf/)، SmartArt را با دقت بصری بالا رندر می‌کند و چیدمان، رنگ‌ها و اثرات را حفظ می‌نماید.

**آیا می‌توانم تصویری از کل SmartArt (برای پیش‌نمایش یا گزارش) استخراج کنم؟**

بله. می‌توانید یک شکل SmartArt را به [فرمت‌های رستر](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-) یا به [SVG](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) رندر کنید تا خروجی برداری مقیاس‌پذیر داشته باشید، که برای تصویر بندانگشتی، گزارش‌ها یا استفاده در وب مناسب است.