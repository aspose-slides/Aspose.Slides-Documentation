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
- گره کمکی
- فرمت پر کردن
- رندر گره
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای Java. دریافت نمونه کد واضح و نکات برای ساده‌سازی ارائه‌های شما."
---
## **مروری کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن را شامل می‌شوند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: گره‌ها و گره‌های فرزند جدید اضافه کنید، گره‌های فرزند را در موقعیت خاصی وارد کنید، به گره‌های موجود دسترسی پیدا کنید و متن، سطح و موقعیت آن‌ها را بخوانید.

این مقاله توضیح می‌دهد چگونه گره‌های شکل SmartArt را مدیریت کنید. نحوه حذف گره‌ها، کار با گره‌های فرزند بر اساس شاخص یا موقعیت، تبدیل یک گره کمکی به گره عادی، تنظیم موقعیت، اندازه و چرخش شکل گره SmartArt، تعیین فرمت پر کردن گره و تولید تصویر بندانگشتی برای گره فرزند SmartArt را نشان می‌دهد.

## **افزودن گره SmartArt**
Aspose.Slides for Java ساده‌ترین API را برای مدیریت شکل‌های SmartArt به راحت‌ترین روش ارائه کرده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را داخل شکل SmartArt اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل (Typecast) کنید.
1. یک گره جدید را با استفاده از [Add a new Node](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#addNode--) در مجموعهٔ **NodeCollection** شکل SmartArt اضافه کنید و متن را در TextFrame تنظیم کنید.
1. حالا یک [**Child Node**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--) را در گره SmartArt تازه اضافه شده اضافه کنید و متن را در TextFrame تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگیری ارائه مورد نظر
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // پیمایش هر شکل داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            SmartArt smart = (SmartArt) shape;
    
            // افزودن گره جدید SmartArt
            SmartArtNode TemNode = (SmartArtNode) smart.getAllNodes().addNode();
    
            // افزودن متن
            TemNode.getTextFrame().setText("Test");
    
            // افزودن گره فرزند جدید به گره والد. این گره در انتهای مجموعه اضافه می‌شود
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
در کد نمونهٔ زیر نحوهٔ افزودن گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt در موقعیت مشخصی توضیح داده شده است.

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. یک شکل SmartArt از نوع [**StackedList**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType#StackedList) در اسلاید دسترسی یافته اضافه کنید.
1. به اولین گره در شکل SmartArt اضافه شده دسترسی پیدا کنید.
1. حالا یک [**Child Node**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getChildNodes--) را برای گره انتخابی در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// ایجاد یک نمونه از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن Smart Art IShape
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

## **دسترسی به گره SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType را تغییر دهید زیرا فقط برای خواندن است و تنها هنگام افزودن شکل SmartArt تنظیم می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
1. تمام **Nodes** داخل شکل SmartArt را مرور کنید.
1. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```java
import com.aspose.slides.*;

// ایجاد نمونه از کلاس Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // دریافت اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش هر شکل داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // پیمایش تمام گره‌ها داخل SmartArt
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

## **دسترسی به گره فرزند SmartArt**
کد نمونه زیر به شما کمک می‌کند به گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt دسترسی پیدا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
1. تمام **Nodes** داخل شکل SmartArt را مرور کنید.
1. برای هر گره SmartArt انتخاب شده، تمام **Child Nodes** داخل آن گره خاص را مرور کنید.
1. اطلاعاتی مانند موقعیت، سطح و متن **Child Node** را دسترسی و نمایش دهید.

```java
import com.aspose.slides.*;

// ایجاد نمونه از کلاس Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // دریافت اسلاید اول
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش هر شکل داخل اسلاید اول
    for (IShape shape : slide.getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (ISmartArt) shape;
    
            // پیمایش تمام گره‌ها داخل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                // دسترسی به گره SmartArt در ایندکس i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // پیمایش گره‌های فرزند در گره SmartArt در ایندکس i
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

## **دسترسی به گره فرزند SmartArt در موقعیت خاص**
در این مثال نحوهٔ دسترسی به گره‌های فرزند در موقعیت‌های خاص متعلق به گره‌های مختلف شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. یک شکل SmartArt از نوع [**StackedList**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType#StackedList) اضافه کنید.
1. به شکل SmartArt اضافه شده دسترسی پیدا کنید.
1. گره‌ای با شاخص 0 را برای شکل SmartArt دسترسی یافته انتخاب کنید.
1. حالا با استفاده از متد **get_Item()** گره **Child Node** در موقعیت 1 را برای گره SmartArt دسترسی یافته دریافت کنید.
1. اطلاعاتی مانند موقعیت، سطح و متن **Child Node** را دسترسی و نمایش دهید.

```java
import com.aspose.slides.*;

// ایجاد نمونه از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید اول
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

## **حذف گره SmartArt**
در این مثال نحوهٔ حذف گره‌های داخل شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
1. بررسی کنید آیا SmartArt بیش از 0 گره دارد.
1. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
1. حالا با استفاده از متد [**RemoveNode**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) گره انتخاب‌شده را حذف کنید.
1. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگیری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش هر شکل داخل اسلاید اول
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

## **حذف گره SmartArt از موقعیت خاص**
در این مثال نحوهٔ حذف گره‌ها در موقعیت خاصی از داخل شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید اول را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
1. گره شکل SmartArt در شاخص 0 را انتخاب کنید.
1. حالا بررسی کنید آیا گره SmartArt انتخاب شده بیش از 2 گره فرزند دارد.
1. حالا گره در **Position 1** را با استفاده از متد [**RemoveNode**](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) حذف کنید.
1. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// بارگیری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش هر شکل داخل اسلاید اول
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

## **تنظیم موقعیت سفارشی برای گره فرزند در شیء SmartArt**
اکنون Aspose.Slides for Java پشتیبانی از تنظیم ویژگی‌های [SmartArtShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtShape) **X** و **Y** را دارد. بخش کد زیر نشان می‌دهد چگونه موقعیت، اندازه و چرخش سفارشی برای SmartArtShape تنظیم شود؛ همچنین توجه داشته باشید اضافه کردن گره‌های جدید منجر به محاسبهٔ دوبارهٔ موقعیت و اندازهٔ تمام گره‌ها می‌شود. با تنظیمات موقعیت سفارشی، کاربر می‌تواند گره‌ها را بر حسب نیاز تنظیم کند.

```java
import com.aspose.slides.*;

// ایجاد نمونه از کلاس Presentation
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

## **بررسی گره کمکی**
{{% alert color="info" %}} 

در این مقاله ویژگی‌های شکل‌های SmartArt اضافه‌شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با Aspose.Slides for Java را بررسی می‌کنیم.

{{% /alert %}} 

ما از شکل SmartArt منبع زیر برای بررسی در بخش‌های مختلف این مقاله استفاده می‌کنیم.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: SmartArt منبع در اسلاید**|

در کد نمونهٔ زیر نحوه شناسایی **Assistant Nodes** در مجموعهٔ گره‌های SmartArt و تغییر وضعیت آن‌ها بررسی می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از Index اسلاید دوم را دریافت کنید.
1. همهٔ شکل‌ها در اسلاید اول را مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) تبدیل کنید.
1. تمام گره‌ها در داخل شکل SmartArt را مرور کنید و بررسی کنید آیا آن‌ها **Assistant Nodes** هستند ([isAssistant](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtNode#isAssistant--)).
1. وضعیت گره کمکی را به گره عادی تغییر دهید.
1. ارائه را ذخیره کنید.

```java
import com.aspose.slides.*;

// ایجاد یک نمونه از ارائه
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // پیمایش هر شکل داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
            ISmartArt smart = (SmartArt) shape;
    
            // پیمایش تمام گره‌های شکل SmartArt
            for (int i = 0; i < smart.getAllNodes().size(); i++) 
            {
                ISmartArtNode node = smart.getAllNodes().get_Item(i);
                // بررسی اینکه آیا گره یک گره کمکی است
                if (node.isAssistant()) 
                {
                    // تنظیم گره کمکی به false و تبدیل آن به گره عادی
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
|**شکل: گره‌های کمکی در SmartArt تغییر یافتند**|

## **تنظیم فرمت پر کردن گره**
Aspose.Slides for Java امکان افزودن شکل‌های سفارشی SmartArt و تنظیم فرمت پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه شکل‌های SmartArt را ایجاد، دسترسی و فرمت پر کردن آن‌ها را با استفاده از Aspose.Slides for Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک اسلاید را با استفاده از شاخص آن دریافت کنید.
1. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArt) با تنظیم **LayoutType** مناسب اضافه کنید.
1. **FillFormat** را برای گره‌های شکل SmartArt تنظیم کنید.
1. ارائهٔ اصلاح‌شده را به‌صورت فایل PPTX ذخیره کنید.

```java
import com.aspose.slides.*;
import java.awt.Color;

// ایجاد نمونه‌ای از ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // افزودن شکل SmartArt و گره‌ها
    ISmartArt chevron = slide.getShapes().addSmartArt(10, 10, 800, 60, SmartArtLayoutType.ClosedChevronProcess);
    ISmartArtNode node = chevron.getAllNodes().addNode();
    node.getTextFrame().setText("Some text");
    
    // تنظیم رنگ پر کردن گره
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

## **ایجاد تصویر بندانگشتی از گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با دنبال کردن مراحل زیر تصویر بندانگشتی یک گره فرزند SmartArt را تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation) ایجاد کنید.
1. یک SmartArt اضافه کنید ([Add SmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNodeCollection#addNode--)).
1. یک گره را با استفاده از Index آن دریافت کنید.
1. تصویر بندانگشتی را دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

```java
import com.aspose.slides.*;

// ایجاد نمونه‌ای از کلاس Presentation که نمایانگر فایل PPTX است
Presentation pres = new Presentation();
try {
    // افزودن SmartArt
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // دریافت مرجع یک گره با استفاده از ایندکس آن
    ISmartArtNode node = smart.getNodes().get_Item(1);

    // دریافت تصویر بندانگشتی
    IImage slideImage = node.getShapes().get_Item(0).getImage();

    // ذخیره‌سازی تصویر بندانگشتی
    try {
          slideImage.save("SmartArt_ChildNote_Thumbnail.png", ImageFormat.Png);
    } finally {
         if (slideImage != null) slideImage.dispose();
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **سوالات متداول**

### آیا انیمیشن SmartArt پشتیبانی می‌شود؟

بله. SmartArt به‌عنوان یک شکل معمولی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/java/shape-animation/) (ورود، خروج، تأکید، مسیرهای حرکتی) را اعمال کرده و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید شکل‌های داخل گره‌های SmartArt را نیز انیمیشن کنید.

### چگونه می‌توانم یک SmartArt خاص را در اسلاید پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟

با استفاده از [متن جایگزین](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getAlternativeText--) جستجو کنید. تنظیم یک AltText متمایز بر روی SmartArt به شما امکان می‌دهد آن را برنامه‌نویسی پیدا کنید بدون اتکا به شناسه‌های داخلی.

### آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟

بله. Aspose.Slides هنگام [صدور PDF](/slides/fa/java/convert-powerpoint-to-pdf/) SmartArt را با دقت بصری بالا رندر می‌کند و طرح، رنگ‌ها و اثرات را حفظ می‌کند.

### آیا می‌توانم تصویر کل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟

بله. می‌توانید یک شکل SmartArt را به فرمت‌های رستر ([raster formats](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getImage-int-float-float-)) یا به SVG ([SVG](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-)) رندر کنید تا خروجی وکتور مقیاس‌پذیر تولید شود؛ این برای بندانگشتی‌ها، گزارش‌ها یا استفاده در وب مناسب است.