---
title: مدیریت SmartArt در ارائه‌های PowerPoint در اندروید
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
description: "یاد بگیرید چگونه SmartArt در PowerPoint را با Aspose.Slides برای اندروید بسازید و ویرایش کنید با استفاده از نمونه‌های واضح کد جاوا که طراحی اسلاید و خودکارسازی را سرعت می‌بخشند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، اشکال گره و یک طرح‌بندی ساخته می‌شود. با Aspose.Slides for Android via Java می‌توانید SmartArt را ایجاد کنید، متن را از گره‌های آن بخوانید، طرح‌بندی آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌بندی نمودارهای سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری بسازید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن از اشکال گره، از طریق [ISmartArt.getAllNodes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#getAllNodes--) مرور کنید، سپس [ITextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itextframe/) برگردانده شده توسط [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartshape/#getTextFrame--) را بخوانید.

این مثال نیاز به ارائه‌ای دارد که حداقل یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید داشته باشد. هر فریم متنی در دسترس را در کنسول چاپ می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = (ISmartArt) slide.getShapes().get_Item(0);
    for (ISmartArtNode node : smartArt.getAllNodes()) {
        for (ISmartArtShape nodeShape : node.getShapes()) {
            if (nodeShape.getTextFrame() != null) {
                System.out.println(nodeShape.getTextFrame().getText());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **تغییر نوع طرح‌بندی یک شیء SmartArt**

طرح‌بندی SmartArt کنترل می‌کند که گره‌ها چگونه مرتب و متصل شوند. مثال زیر یک شیء SmartArt با مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `BasicBlockList` ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) پاس داده می‌شود بر حسب نقطه (point) اندازه‌گیری می‌شود. برای تغییر طرح‌بندی از [ISmartArt.setLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setLayout-int-) استفاده کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.BasicBlockList);
    smartArt.setLayout(SmartArtLayoutType.BasicProcess);

    presentation.save("ChangeSmartArtLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **بررسی اینکه آیا یک گره SmartArt مخفی است**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#isHidden--) نشان می‌دهد که آیا گره در مدل داده SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی وقتی طرح‌بندی انتخاب شده آن‌ها را به ‌عنوان عناصر نمودار قابل رؤیت نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `RadialCycle` استفاده می‌کند، اضافه می‌کند و وضعیت مخفی بودن گره اضافه شده را بررسی می‌کند. اگر گره مخفی باشد پیغامی چاپ می‌کند و نمودار را ذخیره می‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.RadialCycle);
    ISmartArtNode node = smartArt.getAllNodes().addNode();
    boolean isHidden = node.isHidden();

    if (isHidden) {
        System.out.println("The node is hidden in the SmartArt data model.");
    }

    presentation.save("CheckSmartArtHiddenProperty.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دریافت یا تنظیم طرح‌بندی نمودار سازمانی**

برای نمودارهای SmartArt که از طرح‌بندی سازمانی استفاده می‌کنند، [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) و [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) نحوهٔ چیدمان گره‌های فرزند زیر یک گره والد را تعریف می‌کنند. به عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) انتخابی.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح‌بندی گرهٔ اول را به مقدار [OrganizationChartLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/organizationchartlayouttype/) `LeftHanging` تنظیم می‌کند. اندیس صفر‑مبنا `0` گرهٔ سطح‑بالای اول را انتخاب می‌کند؛ گره‌های فرزند آن از چیدمان انتخابی استفاده می‌کنند. سپس ارائهٔ اصلاح‌شده ذخیره می‌شود.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(10, 10, 400, 300, SmartArtLayoutType.OrganizationChart);
    ISmartArtNode rootNode = smartArt.getNodes().get_Item(0);
    rootNode.setOrganizationChartLayout(OrganizationChartLayoutType.LeftHanging);

    presentation.save("OrganizationChartLayout.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **ایجاد یک نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح‌بندی SmartArt است که برای نمودارهای سلسله‌مراتبی شامل مکان‌گیرهای تصویر طراحی شده است. هنگام اضافه کردن شیء SmartArt به اسلاید از مقدار [SmartArtLayoutType](https://reference.aspose.com/slides/androidjava/com.aspose.slides/smartartlayouttype/) `PictureOrganizationChart` استفاده کنید. این مثال یک نمودار با مکان‌گیرهای تصویر ذخیره می‌کند؛ اما مکان‌گیرها را با تصویر پر نمی‌کند.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    ISmartArt smartArt = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.PictureOrganizationChart);

    presentation.save("PictureOrganizationChart.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تبدیل نمودارهای قدیمی به گروه‌های شکل**

هنگام به‌روز رسانی یک ارائه موجود، ممکن است نیاز داشته باشید نمودار سازمانی‌ای که در PowerPoint 97–2003 ساخته شده است را به‌روزرسانی کنید. Aspose.Slides این نمودارهای قدیمی را به صورت اشیاء [ILegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ilegacydiagram/) نمایش می‌دهد. برای تبدیل یک نمودار به یک گروه از شکل‌ها از [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/#convertToGroupShape--) استفاده کنید تا بتوانید عناصر بصری فردی را ویرایش کنید. برای جزئیات به [مرجع API LegacyDiagram](https://reference.aspose.com/slides/androidjava/com.aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعهٔ شکل‌ها اضافه می‌کند بدون این که نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصل را با استفاده از [IShapeCollection.remove](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در یک فهرست جمع‌آوری کنید تا افزودن و حذف شکل‌ها باعث اختلال در تکرار نشود.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروه‌های شکل تبدیل می‌کند و ارائهٔ به‌روزشده را به صورت PPTX ذخیره می‌کند.

```java
import com.aspose.slides.*;
import java.util.ArrayList;
import java.util.List;

Presentation presentation = new Presentation("legacy-diagrams.ppt");
try {
    for (ISlide slide : presentation.getSlides()) {
        List<ILegacyDiagram> legacyDiagrams = new ArrayList<>();
        for (IShape shape : slide.getShapes()) {
            if (shape instanceof ILegacyDiagram) {
                legacyDiagrams.add((ILegacyDiagram) shape);
            }
        }

        for (ILegacyDiagram legacyDiagram : legacyDiagrams) {
            IGroupShape groupShape = legacyDiagram.convertToGroupShape();

            if (groupShape != null) {
                slide.getShapes().remove(legacyDiagram);
            }
        }
    }

    presentation.save("modernized.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

ارائهٔ ذخیره‌شده شامل گروه‌های قابل ویرایش از شکل‌ها به جای نمودارهای قدیمی تبدیل شده است و هیچ نمودار اصلی در کنار آن‌ها باقی نمی‌ماند. PPTX را در PowerPoint باز کنید تا عناصر فردی در هر گروه، مانند متن، پر یا موقعیت‌شان را ویرایش کنید.

## **FAQ**

**آیا SmartArt از انعکاس یا معکوس کردن برای زبان‌های راست‑به‑چپ پشتیبانی می‌کند؟**

بله. متد [ISmartArt.setReversed](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/#setReversed-boolean-) جهت نمودار را از چپ به راست به راست به چپ یا برعکس می‌کند وقتی که طرح‌بندی SmartArt انتخاب‌شده از معکوس‌پذیری پشتیبانی می‌کند.

**چگونه می‌توانم SmartArt را در همان اسلاید یا در ارائهٔ دیگری کپی کنم و قالب‌بندی را حفظ کنم؟**

می‌توانید با استفاده از [ShapeCollection.addClone](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) شکل SmartArt را [کلون کنید](/slides/fa/androidjava/shape-manipulations/) یا کل اسلاید را [کلون کنید](/slides/fa/androidjava/clone-slides/) که شامل SmartArt است. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستری برای پیش‌نمایش یا صادرات وب رندر کنم؟**

[اسلاید را رندر کنید](/slides/fa/androidjava/convert-powerpoint-to-png/) یا کل ارائه را به PNG یا JPEG. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود دارد؟**

از [Shape.setAlternativeText](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) یا [Shape.setName](https://reference.aspose.com/slides/androidjava/com.aspose.slides/shape/#setName-java.lang.String-) برای اختصاص متن جایگزین یا نام متمایز به شکل SmartArt استفاده کنید، مقدار آن را در [BaseSlide.getShapes](https://reference.aspose.com/slides/androidjava/com.aspose.slides/baseslide/#getShapes--) جستجو کنید و سپس بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ismartart/) است.