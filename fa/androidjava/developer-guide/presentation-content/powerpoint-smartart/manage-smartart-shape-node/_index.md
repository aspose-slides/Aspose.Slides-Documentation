---
title: مدیریت گره‌های شکل SmartArt در ارائه‌ها بر روی Android
linktitle: گره شکل SmartArt
type: docs
weight: 30
url: /fa/androidjava/manage-smartart-shape-node/
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
- Android
- Java
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای Android. نمونه‌های واضح کد Java و نکات برای بهینه‌سازی ارائه‌های شما را دریافت کنید."
---
## **بررسی کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن دارند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد که به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: گره‌ها و گره‌های فرزند جدید اضافه کنید، گره‌های فرزند را در موقعیت خاصی وارد کنید، به گره‌های موجود دسترسی داشته باشید و متن، سطح و موقعیت آن‌ها را بخوانید.

این مقاله توضیح می‌دهد که چگونه گره‌های شکل SmartArt را مدیریت کنید. نحوه حذف گره‌ها، کار با گره‌های فرزند بر اساس شاخص یا موقعیت، تبدیل گره‌ی دستیار به گره عادی، تنظیم موقعیت، اندازه و چرخش اشکال گره‌های SmartArt، تنظیم فرمت پرکننده گره و تولید تصویر بندانگشتی برای یک گره SmartArt را نشان می‌دهد.

## **Add a SmartArt Node**
Aspose.Slides for Android via Java ساده‌ترین API را برای مدیریت اشکال SmartArt به آسان‌ترین شکل ارائه داده است. کد نمونه زیر به افزودن گره و گره فرزند داخل شکل SmartArt کمک می‌کند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. در شکل SmartArt، **[Add a new Node](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)** در **[NodeCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt#getAllNodes--)** اضافه کنید و متن را در TextFrame تنظیم کنید.
6. حالا، **[Add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)** یک **[Child Node](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)** در گره SmartArt تازه اضافه شده ایجاد کنید و متن را در TextFrame تنظیم کنید.
7. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
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

## **Add a SmartArt Node at a Specific Position**
در کد نمونه زیر نحوه افزودن گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt در موقعیت خاص توضیح داده شده است.

1. یک نمونه از کلاس Presentation ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. یک شکل SmartArt از نوع **[StackedList](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)** در اسلاید دسترسی یافته اضافه کنید.
4. به اولین گره در شکل SmartArt اضافه شده دسترسی پیدا کنید.
5. حالا، **[Child Node](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--)** را برای گره انتخاب شده در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
6. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// ساختن یک نمونه از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن IShape Smart Art
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);

    // دسترسی به گره SmartArt در ایندکس 0
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

## **Access a SmartArt Node**
کد نمونه زیر به شما کمک می‌کند تا به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که LayoutType مربوط به SmartArt هنگام افزودن شکل انتخاب می‌شود؛ تغییر آن پس از افزودن با **setLayout** کل نمودار را بازسازی می‌کند و موقعیت‌ها و اندازه‌های گره‌هایی که تنظیم کرده‌اید دوباره محاسبه می‌شوند.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. تمام **[Nodes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt#getAllNodes--)** داخل شکل SmartArt را مرور کنید.
6. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی داده و نمایش دهید.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // مرور تمام گره‌ها داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // دسترسی به گره SmartArt در ایندکس i
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

## **Access a SmartArt Child Node**
کد نمونه زیر به شما کمک می‌کند تا گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt را دسترسی پیدا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. تمام **[Nodes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt#getAllNodes--)** داخل شکل SmartArt را مرور کنید.
6. برای هر **Node** انتخاب شده در شکل SmartArt، تمام **[Child Nodes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--)** داخل گره خاص را مرور کنید.
7. اطلاعاتی مانند موقعیت **Child Node**، سطح و متن را دسترسی داده و نمایش دهید.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // مرور تمام گره‌ها داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // دسترسی به گره SmartArt در ایندکس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // مرور گره‌های فرزند در گره SmartArt در ایندکس i
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

## **Access a SmartArt Child Node at a Specific Position**
در این مثال نحوه دسترسی به گره‌های فرزند در موقعیت خاصی که به گره‌های مربوط به شکل SmartArt تعلق دارند، آموزش داده می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. یک شکل SmartArt از نوع **[StackedList](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList)** اضافه کنید.
4. به شکل SmartArt اضافه شده دسترسی پیدا کنید.
5. گره‌ای با ایندکس 0 را برای شکل SmartArt دسترسی یافته انتخاب کنید.
6. حالا، **Child Node** را در موقعیت 1 برای گره SmartArt دسترسی یافته با استفاده از متد **get_Item()** دسترسی پیدا کنید.
7. اطلاعاتی مانند موقعیت **Child Node**، سطح و متن را دسترسی داده و نمایش دهید.

```java
import com.aspose.slides.*;

// ایجاد نمونه ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل SmartArt در اسلاید اول
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.StackedList);
    
    // دسترسی به گره SmartArt در ایندکس 0
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

## **Remove a SmartArt Node**
در این مثال نحوه حذف گره‌ها داخل شکل SmartArt آموزش داده می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. بررسی کنید آیا SmartArt بیش از 0 گره دارد.
6. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
7. حالا، گره انتخاب شده را با استفاده از متد **[RemoveNode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-)** حذف کنید.
8. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // دسترسی به گره SmartArt در ایندکس 0
                ISmartArtNode node = smart.getAllNodes().get_Item(0);
    
                // حذف گره انتخاب شده
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

## **Remove a SmartArt Node from a Specific Position**
در این مثال نحوه حذف گره‌ها داخل شکل SmartArt در موقعیت خاص آموزش داده می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. گره شکل SmartArt در ایندکس 0 را انتخاب کنید.
6. حالا بررسی کنید آیا گره SmartArt انتخاب شده بیش از 2 گره فرزند دارد.
7. حالا، گره در **Position 1** را با استفاده از متد **[RemoveNode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-)** حذف کنید.
8. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            SmartArt smart = (SmartArt) shape;
    
            if (smart.getAllNodes().size() > 0) 
            {
                // دسترسی به گره SmartArt در ایندکس 0
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

## **Set a Custom Position for a Child Node in a SmartArt Object**
اکنون Aspose.Slides for Android via Java امکان تنظیم ویژگی‌های **X** و **Y** برای **SmartArtShape** را پشتیبانی می‌کند. قطعه کد زیر نشان می‌دهد چگونه موقعیت سفارشی، اندازه و چرخش **SmartArtShape** را تنظیم کنید؛ همچنین توجه داشته باشید افزودن گره‌های جدید منجر به محاسبه دوباره موقعیت‌ها و اندازه‌های تمام گره‌ها می‌شود. با تنظیمات موقعیت سفارشی کاربر می‌تواند گره‌ها را مطابق نیاز تنظیم کند.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // حرکت شکل SmartArt به موقعیت جدید
    ISmartArtNode node = smart.getAllNodes().get_Item(1);
    ISmartArtShape shape = node.getShapes().get_Item(1);
    shape.setX(shape.getX() + shape.getWidth() * 2);
    shape.setY(shape.getY() - shape.getHeight() * 2);

    // تغییر عرض‌های شکل SmartArt
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

## **Check an Assistant Node**
{{% alert color="info" %}} 

در این مقاله ویژگی‌های اشکال SmartArt اضافه‌شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با Aspose.Slides for Android via Java بررسی می‌شود.

{{% /alert %}} 

ما از شکل SmartArt زیر به‌عنوان منبع برای بررسی در بخش‌های مختلف این مقاله استفاده خواهیم کرد.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: SmartArt منبع در اسلاید**|

در کد نمونه زیر نحوه شناسایی **Assistant Nodes** در مجموعه گره‌های SmartArt و تغییر وضعیت آن‌ها بررسی می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
2. مرجع اسلاید اول را با استفاده از ایندکس آن به‌دست آورید.
3. تمام اشکال داخل اسلاید اول را مرور کنید.
4. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و اگر بود، شکل انتخابی را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
5. تمام گره‌های داخل شکل SmartArt را مرور کنید و بررسی کنید آیا آن‌ها **Assistant Nodes** هستند یا نه.
6. وضعیت Assistant Node را به گره عادی تغییر دهید.
7. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// ایجاد یک نمونه ارائه
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // مرور تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // مرور تمام گره‌های شکل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // بررسی اینکه آیا گره یک گره دستیار است
                if (node.isAssistant()) 
                {
                    // تنظیم مقدار دستیار به false و تبدیل به گره عادی
                    node.setAssistant(false);
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
|**شکل: Assistant Nodes در شکل SmartArt داخل اسلاید تغییر یافتند**|

## **Set a Node's Fill Format**
Aspose.Slides for Android via Java امکان افزودن اشکال سفارشی SmartArt و تنظیم فرمت پرکننده آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه اشکال SmartArt را ایجاد و دسترسی پیدا کنید و فرمت پرکننده آن‌ها را با استفاده از Aspose.Slides for Android via Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. مرجع اسلایدی را با استفاده از ایندکس آن به‌دست آورید.
3. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) با تنظیم **[LayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)** اضافه کنید.
4. **[FillFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getFillFormat--)** را برای گره‌های شکل SmartArt تنظیم کنید.
5. ارائه تغییر یافته را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// نمونه‌سازی ارائه
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

## **Generate a Thumbnail of a SmartArt Node**
توسعه‌دهندگان می‌توانند با پیروی از مراحل زیر، تصویر بندانگشتی یک گره از SmartArt تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
2. **[Add SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--)**.
3. مرجع یک گره را با استفاده از ایندکس آن به‌دست آورید.
4. تصویر بندانگشتی را دریافت کنید.
5. تصویر بندانگشتی را در هر قالب تصویر دلخواهی ذخیره کنید.

```java
import com.aspose.slides.*;

// نمونه‌سازی کلاس Presentation که فایل PPTX را نشان می‌دهد 
Presentation pres = new Presentation();
try {
    // افزودن SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // دسترسی به مرجع یک گره با استفاده از ایندکس آن  
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

## **FAQ**

### آیا انیمیشن SmartArt پشتیبانی می‌شود؟

بله. SmartArt به‌عنوان یک شکل عادی در نظر گرفته می‌شود، بنابراین می‌توانید **انیمیشن‌های استاندارد** (/slides/fa/androidjava/shape-animation/) (ورود، خروج، تأکید، مسیرهای حرکتی) را اعمال کرده و زمان‌بندی آن‌ها را تنظیم کنید. همچنین می‌توانید در صورت نیاز، اشکال داخل گره‌های SmartArt را نیز انیمیت کنید.

### اگر شناسه داخلی یک SmartArt مشخص نباشد، چگونه می‌توانم آن را به‌طور قابل اعتماد در یک اسلاید پیدا کنم؟

با اختصاص و جستجو بر اساس **متن Alt** ([alternative text](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getAlternativeText--)) می‌توانید SmartArt را برنامه‌نویسی پیدا کنید؛ تنظیم یک AltText متمایز به شما این امکان را می‌دهد بدون نیاز به شناسه‌های داخلی آن را شناسایی کنید.

### آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟

بله. Aspose.Slides هنگام **صادرات PDF** (/slides/fa/androidjava/convert-powerpoint-to-pdf/)، SmartArt را با دقت بصری بالا رندر می‌کند و طرح، رنگ‌ها و افکت‌ها را حفظ می‌نماید.

### آیا می‌توانم تصویر کل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟

بله. می‌توانید شکل SmartArt را به **فرمت‌های رستری** (https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) یا **SVG** (https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) رندر کنید؛ این امکان برای تولید تصویر بندانگشتی، گزارش یا استفاده در وب مناسب است.