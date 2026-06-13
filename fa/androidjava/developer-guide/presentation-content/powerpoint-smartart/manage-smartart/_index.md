---
title: مدیریت SmartArt در ارائه‌های PowerPoint در Android
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/androidjava/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح‌بندی
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای Android بسازید و ویرایش کنید با استفاده از نمونه‌های واضح کد Java که سرعت طراحی اسلاید و خودکارسازی را افزایش می‌دهند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح‌بندی ساخته شده است. با Aspose.Slides برای Android از طریق Java، می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را در بر داشته باشد. برای خواندن متن قابل مشاهده، از طریق [ISmartArt.getAllNodes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartart/#getAllNodes--) پیمایش کنید، سپس [ITextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/itextframe/) بازگردانده‌شده توسط [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) را بخوانید.

```java
Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IShape shape = slide.getShapes().get_Item(0);

    if (shape instanceof ISmartArt) {
        ISmartArt smartArt = (ISmartArt) shape;

        for (ISmartArtNode node : smartArt.getAllNodes()) {
            for (ISmartArtShape nodeShape : node.getShapes()) {
                if (nodeShape.getTextFrame() != null) {
                    System.out.println(nodeShape.getTextFrame().getText());
                }
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt تعیین می‌کند گره‌ها چگونه چیده و به یکدیگر متصل می‌شوند. مثال زیر یک شیء SmartArt را با مقدار `BasicBlockList` از نوع [SmartArtLayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);

    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است یا خیر**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartartnode/#isHidden--) نشان می‌دهد آیا گره در مدل داده‌ای SmartArt مخفی است یا خیر. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح‌بندی انتخاب‌شده آن‌ها را به‌عنوان عناصر نموداری قابل مشاهده نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار `RadialCycle` از نوع [SmartArtLayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType) استفاده می‌کند اضافه می‌کند و وضعیت مخفی بودن گره را بررسی می‌کند.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.RadialCycle);

    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی نمودار سازمانی استفاده می‌کنند، متدهای [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) تعیین می‌کنند گره‌های فرزند زیر یک گره والد چگونه چیده شوند. به‌عنوان مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OrganizationChartLayoutType) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و برای اولین گره، طرح‌بندی را به مقدار `LeftHanging` از نوع [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/OrganizationChartLayoutType) تنظیم می‌نماید.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);

    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌های قرارگیری تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، از مقدار `PictureOrganizationChart` از نوع [SmartArtLayoutType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/SmartArtLayoutType) استفاده کنید.

```java
Presentation presentation = new Presentation();
try {
    ISmartArt smartArt = presentation.getSlides().get_Item(0).getShapes().addSmartArt(
        0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا SmartArt از انعکاس یا معکوس کردن برای زبان‌های راست به چپ پشتیبانی می‌کند؟**

بله. متد [ISmartArt.setReversed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) جهت نمودار را از چپ به راست به راست به چپ، یا برعکس، تغییر می‌دهد هنگامی که طرح‌بندی SmartArt انتخاب‌شده از معکوس شدن پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائه دیگر کپی کنم در حالی که قالب‌بندی حفظ می‌شود؟**

می‌توانید با استفاده از [ShapeCollection.addClone](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-)، [کپی شکل SmartArt](/slides/fa/androidjava/shape-manipulations/) کنید یا با استفاده از [کپی کل اسلاید](/slides/fa/androidjava/clone-slides/) کل اسلاید حاوی SmartArt را کپی کنید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به یک تصویر رستر برای پیش‌نمایش یا خروجی وب رندر کنم؟**

[رندر اسلاید](/slides/fa/androidjava/convert-powerpoint-to-png/) یا کل ارائه به فرمت PNG یا JPEG. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین شیء وجود داشته باشد؟**

یک مقدار متمایز برای [Shape.getAlternativeText](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getAlternativeText--) یا [Shape.getName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/shape/#getName--) بر روی شکل SmartArt تنظیم کنید، سپس آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/#getShapes--) جستجو کنید و بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ismartart/) باشد.