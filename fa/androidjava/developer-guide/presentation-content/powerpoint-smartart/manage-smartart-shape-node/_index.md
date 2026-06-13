---
title: مدیریت گره‌های شکل SmartArt در ارائه‌های Android
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
- قالب پر کردن
- رندر گره
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "مدیریت گره‌های شکل SmartArt در فایل‌های PPT و PPTX با Aspose.Slides برای Android. نمونه‌های کد واضح Java و نکات برای بهینه‌سازی ارائه‌های شما را دریافت کنید."
---
## **بررسی کلی**

گرافیک‌های SmartArt در ارائه‌های PowerPoint از طریق گره‌هایی که متن دارند و ساختار نمودار را تعریف می‌کنند، سازماندهی می‌شوند. Aspose.Slides به شما امکان می‌دهد که به‌صورت برنامه‌نویسی با این گره‌های SmartArt کار کنید: گره‌ها و گره‌های فرزند جدید اضافه کنید، گره‌های فرزند را در موقعیت خاصی وارد کنید، به گره‌های موجود دسترسی داشته باشید و متن، سطح و موقعیت آن‌ها را بخوانید.

این مقاله توضیح می‌دهد چگونه گره‌های شکل SmartArt را مدیریت کنید. نشان می‌دهد چگونه گره‌ها را حذف کنید، با گره‌های فرزند بر اساس شاخص یا موقعیت کار کنید، یک گره دستیار را به گره عادی تغییر دهید، موقعیت، اندازه و چرخش شکل‌های گره SmartArt را تنظیم کنید، قالب پر کردن گره‌ها را تعیین کنید و تصویر بندانگشتی برای یک گره فرزند SmartArt تولید کنید.

## **اضافه کردن یک گره SmartArt**
Aspose.Slides برای Android به‌وسیله Java ساده‌ترین API را برای مدیریت شکل‌های SmartArt به آسان‌ترین شکل فراهم کرده است. کد نمونه زیر به شما کمک می‌کند گره و گره فرزند را داخل شکل SmartArt اضافه کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
1. یک [گره جدید](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) را در مجموعه گره‌های SmartArt (**NodeCollection**) اضافه کنید و متن را در TextFrame تنظیم کنید.
1. حالا یک [گره فرزند](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) را به گره SmartArt تازه اضافه شده اضافه کنید و متن را در TextFrame تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
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

## **اضافه کردن یک گره SmartArt در موقعیت خاص**
در کد نمونه زیر نحوه اضافه کردن گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt در موقعیت خاص توضیح داده شده است.

1. یک نمونه از کلاس Presentation ایجاد کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt) از نوع [**StackedList**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) در اسلاید دسترسی یافته اضافه کنید.
1. به اولین گره در شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
1. حالا یک [گره فرزند](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#getChildNodes--) برای گره منتخب (**Node**) در موقعیت 2 اضافه کنید و متن آن را تنظیم کنید.
1. ارائه را ذخیره کنید.

```java
// ایجاد یک نمونه ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اسلاید ارائه
    ISlide slide = pres.getSlides().get_Item(0);

    // افزودن IShape Smart Art
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
کد نمونه زیر به شما کمک می‌کند به گره‌های داخل شکل SmartArt دسترسی پیدا کنید. لطفاً توجه داشته باشید که نمی‌توانید LayoutType SmartArt را تغییر دهید زیرا فقط به صورت خواندنی است و تنها هنگام افزودن شکل SmartArt تنظیم می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
1. در تمام [گره‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt مرور کنید.
1. اطلاعاتی مانند موقعیت گره SmartArt، سطح و متن را دسترسی و نمایش دهید.

```java
// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("SmartArtShape.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش تمام اشکال داخل اسلاید اول
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
کد نمونه زیر به شما کمک می‌کند به گره‌های فرزند متعلق به گره‌های مختلف شکل SmartArt دسترسی پیدا کنید.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
1. در تمام [گره‌ها](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArt#getAllNodes--) داخل شکل SmartArt مرور کنید.
1. برای هر گره SmartArt منتخب (**Node**)، در تمام [گره‌های فرزند](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtNode#getChildNodes--) داخل گره خاص مرور کنید.
1. اطلاعاتی مانند موقعیت، سطح و متن گره فرزند را دسترسی و نمایش دهید.

```java
// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("AccessChildNodes.pptx");
try {
    // دریافت اولین اسلاید
    ISlide slide = pres.getSlides().get_Item(0);
    
    // پیمایش تمام اشکال داخل اسلاید اول
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
                // دسترسی به گره SmartArt با شاخص i
                SmartArtNode node0 = (SmartArtNode) smart.getAllNodes().get_Item(i);
                
                // پیمایش گره‌های فرزند در گره SmartArt با شاخص i
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
در این مثال، به دسترسی به گره‌های فرزند در موقعیت‌های خاص متعلق به گره‌های مختلف شکل SmartArt می‌پردازیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. یک شکل SmartArt از نوع [**StackedList**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#StackedList) اضافه کنید.
1. به شکل SmartArt اضافه‌شده دسترسی پیدا کنید.
1. گره‌ای با شاخص 0 برای شکل SmartArt دسترسی یافته دریافت کنید.
1. اکنون، گره فرزند را در موقعیت 1 برای گره SmartArt دسترسی یافته با استفاده از متد **get_Item()** دریافت کنید.
1. اطلاعاتی مانند موقعیت، سطح و متن گره فرزند را دسترسی و نمایش دهید.

```java
// نمونه‌سازی ارائه
Presentation pres = new Presentation();
try {
    // دسترسی به اولین اسلاید
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
در این مثال، نحوه حذف گره‌ها داخل شکل SmartArt را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
1. بررسی کنید آیا SmartArt بیش از 0 گره دارد.
1. گره SmartArt مورد نظر برای حذف را انتخاب کنید.
1. حالا گره انتخاب‌شده را با استفاده از متد [**RemoveNode**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-com.aspose.slides.ISmartArtNode-) حذف کنید.
1. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof ISmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
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
در این مثال، نحوه حذف گره‌ها داخل شکل SmartArt در موقعیت خاصی را می‌آموزیم.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید اول را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) تبدیل کنید.
1. گره شکل SmartArt در شاخص 0 را انتخاب کنید.
1. اکنون بررسی کنید آیا گره SmartArt انتخاب‌شده بیش از 2 گره فرزند دارد.
1. گره در **موقعیت 1** را با استفاده از متد [**RemoveNode**](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#removeNode-int-) حذف کنید.
1. ارائه را ذخیره کنید.

```java
// بارگذاری ارائه مورد نظر
Presentation pres = new Presentation("AddSmartArtNode.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
    for (IShape shape : pres.getSlides().get_Item(0).getShapes()) 
    {
        // بررسی اینکه آیا شکل از نوع SmartArt است
        if (shape instanceof SmartArt) 
        {
            // تبدیل نوع شکل به SmartArt
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
اکنون Aspose.Slides برای Android به‌وسیله Java از تنظیم ویژگی‌های [SmartArtShape](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtShape) **X**([IShape#setX-float-](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#setX-float-)) و **Y**([IShape#setY-float-](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#setY-float-)) پشتیبانی می‌کند. قطعه کد زیر نشان می‌دهد چطور موقعیت، اندازه و چرخش سفارشی SmartArtShape را تنظیم کنید؛ همچنین توجه داشته باشید که افزودن گره‌های جدید باعث بازمحاسبه موقعیت‌ها و اندازه‌های تمام گره‌ها می‌شود. با تنظیمات موقعیت سفارشی، کاربر می‌تواند گره‌ها را بر حسب نیاز تنظیم کند.

```java
// نمونه‌سازی کلاس Presentation
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try{
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(20, 20, 600, 500, SmartArtLayoutType.OrganizationChart);

    // جابه‌جایی شکل SmartArt به موقعیت جدید
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

## **بررسی یک گره دستیار**
{{% alert color="primary" %}} 

در این مقاله ویژگی‌های شکل‌های SmartArt اضافه‌شده به اسلایدهای ارائه به‌صورت برنامه‌نویسی با Aspose.Slides برای Android به‌وسیله Java را بیشتر بررسی می‌کنیم.

{{% /alert %}} 

ما از شکل SmartArt منبع زیر برای بررسی در بخش‌های مختلف این مقاله استفاده می‌کنیم.

|![todo:image_alt_text](https://i.imgur.com/FItwczY.png)|
| :- |
|**شکل: شکل SmartArt منبع در اسلاید**|

در کد نمونه زیر نحوه شناسایی **گره‌های دستیار** در مجموعه گره‌های SmartArt و تغییر وضعیت آن‌ها بررسی می‌شود.

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید و ارائه را با شکل SmartArt بارگذاری کنید.
1. با استفاده از شاخص آن، مرجع اسلاید دوم را به‌دست آورید.
1. در تمام اشکال داخل اسلاید اول مرور کنید.
1. بررسی کنید آیا شکل از نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) است و در صورت بودن، آن را به نوع [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISSmartArt) تبدیل کنید.
1. در تمام گره‌های داخل شکل SmartArt مرور کنید و بررسی کنید آیا آن‌ها **گره‌های دستیار** هستند ([SmartArtNode#isAssistant--](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtNode#isAssistant--)).
1. وضعیت گره دستیار را به گره عادی تغییر دهید.
1. ارائه را ذخیره کنید.

```java
// ایجاد یک نمونه ارائه
Presentation pres = new Presentation("AddNodes.pptx");
try {
    // پیمایش تمام اشکال داخل اسلاید اول
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
                // بررسی اینکه آیا گره گره دستیار است
                if (node.isAssistant()) 
                {
                    // تنظیم گره دستیار به مقدار false و تبدیل آن به گره عادی
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
|**شکل: گره‌های دستیار در شکل SmartArt داخل اسلاید تغییر یافتند**|

## **تنظیم قالب پر کردن یک گره**
Aspose.Slides برای Android به‌وسیله Java امکان افزودن شکل‌های SmartArt سفارشی و تنظیم قالب پر کردن آن‌ها را فراهم می‌کند. این مقاله توضیح می‌دهد چگونه شکل‌های SmartArt را ایجاد و دسترسی پیدا کنید و قالب پر کردن آن‌ها را با استفاده از Aspose.Slides برای Android به‌وسیله Java تنظیم کنید.

لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. با استفاده از شاخص، مرجع یک اسلاید را به‌دست آورید.
1. یک شکل [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArt) با تنظیم **LayoutType** ([SmartArtLayoutType#ClosedChevronProcess](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType#ClosedChevronProcess)) اضافه کنید.
1. **FillFormat** ([IShape#getFillFormat--](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IShape#getFillFormat--)) را برای گره‌های شکل SmartArt تنظیم کنید.
1. ارائه تغییر یافته را به‌عنوان فایل PPTX ذخیره کنید.

```java
// نمونه‌سازی ارائه
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

## **تولید تصویر بندانگشتی از یک گره فرزند SmartArt**
توسعه‌دهندگان می‌توانند با پیروی از مراحل زیر تصویر بندانگشتی گره فرزند یک SmartArt را تولید کنند:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. [SmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNodeCollection#addNode--) اضافه کنید.
1. با استفاده از شاخص، مرجع یک گره را به‌دست آورید.
1. تصویر بندانگشتی را دریافت کنید.
1. تصویر بندانگشتی را در هر فرمت تصویری دلخواه ذخیره کنید.

```java
// نمونه‌سازی کلاس Presentation که نمایانگر فایل PPTX است 
Presentation pres = new Presentation();
try {
    // افزودن SmartArt 
    ISmartArt smart = pres.getSlides().get_Item(0).getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicCycle);

    // دریافت مرجع یک گره با استفاده از شاخص آن  
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

## **سؤالات متداول**

**آیا انیمیشن SmartArt پشتیبانی می‌شود؟**

بله. SmartArt به‌عنوان یک شکل عادی در نظر گرفته می‌شود، بنابراین می‌توانید [انیمیشن‌های استاندارد](/slides/fa/androidjava/shape-animation/) (ورودی، خروجی، تأکید، مسیرهای حرکتی) را اعمال کنید و زمان‌بندی را تنظیم کنید. در صورت نیاز می‌توانید اشکال داخل گره‌های SmartArt را نیز انیمیشن کنید.

**چگونه می‌توانم به‌صورت قابل‌اعتماد یک SmartArt خاص را در اسلاید پیدا کنم اگر شناسه داخلی آن ناشناخته باشد؟**

با اختصاص و جستجو بر اساس [متن جایگزین](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getAlternativeText--) (AltText) می‌توانید. تنظیم یک AltText متمایز بر روی SmartArt به شما امکان می‌دهد آن را برنامه‌نویسی پیدا کنید بدون اتکا به شناسه‌های داخلی.

**آیا ظاهر SmartArt هنگام تبدیل ارائه به PDF حفظ می‌شود؟**

بله. Aspose.Slides هنگام [صادرات PDF](/slides/fa/androidjava/convert-powerpoint-to-pdf/) SmartArt را با دقت بصری بالا رندر می‌کند و طرح، رنگ‌ها و افکت‌ها را حفظ می‌نماید.

**آیا می‌توانم تصویر کل SmartArt را استخراج کنم (برای پیش‌نمایش یا گزارش‌ها)؟**

بله. می‌توانید یک شکل SmartArt را به فرمت‌های [رتراس](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getImage-int-float-float-) یا به [SVG](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#writeAsSvg-java.io.OutputStream-com.aspose.slides.ISVGOptions-) رندر کنید تا خروجی وکتور مقیاس‌پذیر داشته باشید، که برای بندانگشتی‌ها، گزارش‌ها یا استفاده در وب مناسب است.