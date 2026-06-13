---
title: مدیریت SmartArt در ارائه‌های PowerPoint با استفاده از Java
linktitle: مدیریت SmartArt
type: docs
weight: 10
url: /fa/java/manage-smartart/
keywords:
- SmartArt
- متن SmartArt
- نوع طرح
- ویژگی مخفی
- نمودار سازمانی
- نمودار سازمانی تصویری
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای Java بسازید و ویرایش کنید با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را تسریع می‌کند."
---
## **بررسی کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح ساخته شده است. با Aspose.Slides for Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل را شامل شود. برای خواندن متن قابل مشاهده، از طریق [ISmartArt.getAllNodes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartart/#getAllNodes--) پیمایش کنید، سپس [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) برگشتی توسط [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartartshape/#getTextFrame--) را بخوانید.

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

## **تغییر نوع طرح یک شیء SmartArt**

طرح SmartArt نحوه چیدمان و اتصال گره‌ها را کنترل می‌کند. مثال زیر یک شیء SmartArt را با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند.

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

## **بررسی اینکه آیا گره SmartArt مخفی است**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartartnode/#isHidden--) نشان می‌دهد که آیا گره در مدل داده‌ای SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی اگر طرح انتخابی آن‌ها را به عنوان عناصر نمودار قابل مشاهده نشان ندهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره را بررسی می‌کند.

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

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#getOrganizationChartLayout--) و [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ISmartArtNode#setOrganizationChartLayout-int-) تعیین می‌کنند که گره‌های فرزند تحت یک گره والد چگونه چیده شوند. برای مثال، می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OrganizationChartLayoutType) انتخاب شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گره اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/OrganizationChartLayoutType) `LeftHanging` تنظیم می‌کند.

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

## **ایجاد یک نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله‌مراتبی شامل مکان‌های نگهداری تصویر طراحی شده است. هنگام افزودن شیء SmartArt به یک اسلاید، مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/fa/java/com.aspose.slides/SmartArtLayoutType) `PictureOrganizationChart` را استفاده کنید.

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

**آیا SmartArt پشتیبانی از آینه‌سازی یا معکوس کردن برای زبان‌های راست به چپ را دارد؟**

بله. متد [ISmartArt.setReversed](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartart/#setReversed-boolean-) جهت نمودار را از چپ به راست به راست به چپ یا برعکس تغییر می‌دهد، هنگامی که طرح SmartArt انتخاب شده از معکوس شدن پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائه دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید [شکل SmartArt را کلون کنید](/slides/fa/java/shape-manipulations/) با استفاده از [ShapeCollection.addClone](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) یا [کلون کل اسلاید](/slides/fa/java/clone-slides/) که شامل SmartArt است، انجام دهید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا خروجی وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/java/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG. SmartArt به عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

یک مقدار متمایز برای [Shape.getAlternativeText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getAlternativeText--) یا [Shape.getName](https://reference.aspose.com/slides/fa/java/com.aspose.slides/shape/#getName--) بر روی شکل SmartArt تنظیم کنید، سپس آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/fa/java/com.aspose.slides/baseslide/#getShapes--) جستجو کنید و اطمینان حاصل کنید که شکل یافت شده یک [ISmartArt](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ismartart/) است.