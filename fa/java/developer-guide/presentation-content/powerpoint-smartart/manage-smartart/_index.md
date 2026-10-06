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
description: "یاد بگیرید چگونه با Aspose.Slides برای Java، SmartArt در PowerPoint را ایجاد و ویرایش کنید با استفاده از نمونه‌های کد واضح که طراحی اسلاید و خودکارسازی را شتاب می‌بخشند."
---
## **نمای کلی**

SmartArt یک نمودار PowerPoint است که از گره‌ها، شکل‌های گره و یک طرح ساخته شده است. با Aspose.Slides برای Java می‌توانید SmartArt ایجاد کنید، متن را از گره‌های آن بخوانید، طرح آن را تغییر دهید، گره‌های مخفی را بررسی کنید، طرح‌های نمودار سازمانی را پیکربندی کنید و نمودارهای سازمانی تصویری ایجاد کنید.

## **دریافت متن از یک شیء SmartArt**

یک گره SmartArt می‌تواند یک یا چند شکل داشته باشد. برای خواندن متن از شکل‌های گره، باید از [ISmartArt.getAllNodes](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#getAllNodes--) عبور کنید، سپس [ITextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/itextframe/) بازگردانده شده توسط [ISmartArtShape.getTextFrame](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartshape/#getTextFrame--) را بخوانید.

این مثال به یک ارائه حداقل با یک اسلاید و یک شیء SmartArt به عنوان اولین شکل در آن اسلاید نیاز دارد. این برنامه هر چارچوب متنی موجود را به کنسول چاپ می‌کند.

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

## **تغییر نوع طرح یک شیء SmartArt**

طرح SmartArt تعیین می‌کند گره‌ها چگونه چیده و به هم وصل شوند. مثال زیر یک شیء SmartArt را با مقدار `BasicBlockList` از [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) ایجاد می‌کند، آن را به مقدار `BasicProcess` تغییر می‌دهد و ارائه را ذخیره می‌کند. موقعیت و اندازه‌ای که به [IShapeCollection.addSmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#addSmartArt-float-float-float-float-int-) پاس داده می‌شود بر حسب نقاط اندازه‌گیری می‌شود. برای تغییر طرح از [ISmartArt.setLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setLayout-int-) استفاده کنید.

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

## **بررسی اینکه آیا گره SmartArt مخفی است**

[ISmartArtNode.isHidden](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#isHidden--) نشان می‌دهد آیا گره در مدل داده‌های SmartArt مخفی است یا نه. گره‌های مخفی می‌توانند در ساختار وجود داشته باشند حتی زمانی که طرح انتخاب شده آن‌ها را به‌عنوان عناصر قابل‌دید نمودار نمایش نمی‌دهد.

مثال زیر یک گره به شیء SmartArt که از مقدار `RadialCycle` از [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) استفاده می‌کند اضافه می‌کند و وضعیت مخفی بودن گره اضافه‌شده را بررسی می‌کند. اگر گره مخفی باشد، یک پیام چاپ می‌کند و نمودار را ذخیره می‌نماید.

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

## **دریافت یا تنظیم طرح نمودار سازمانی**

برای نمودارهای SmartArt که از طرح نمودار سازمانی استفاده می‌کنند، [ISmartArtNode.getOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#getOrganizationChartLayout--) و [ISmartArtNode.setOrganizationChartLayout](https://reference.aspose.com/slides/java/com.aspose.slides/ismartartnode/#setOrganizationChartLayout-int-) تعیین می‌کنند گره‌های فرزند تحت گره مادر چگونه چیده شوند. به عنوان مثال می‌توانید گره‌های فرزند را طوری تنظیم کنید که از سمت چپ، راست یا هر دو طرف آویزان شوند، بسته به [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) انتخاب‌شده.

مثال زیر یک نمودار سازمانی ایجاد می‌کند و طرح گره اول را به مقدار `LeftHanging` از [OrganizationChartLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/organizationchartlayouttype/) تنظیم می‌نماید. اندیس صفر‑مبنایی `0` اولین گره سطح بالا را انتخاب می‌کند؛ گره‌های فرزند آن از چیدمان انتخاب‌شده استفاده می‌کنند. سپس ارائهٔ اصلاح‌شده ذخیره می‌شود.

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

## **ایجاد نمودار سازمانی تصویری**

نمودار سازمانی تصویری یک طرح SmartArt است که برای نمودارهای سلسله‌مراتبی شامل محل‌های نگهداری تصویر طراحی شده است. هنگام افزودن شیء SmartArt به اسلاید، از مقدار `PictureOrganizationChart` از [SmartArtLayoutType](https://reference.aspose.com/slides/java/com.aspose.slides/smartartlayouttype/) استفاده کنید. این مثال یک نمودار با محل‌های نگهداری تصویر ذخیره می‌کند؛ اما این محل‌ها را با تصویر پر نمی‌کند.

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

## **تبدیل نمودارهای قدیمی به گروهی از اشکال**

در هنگام به‌روز رسانی یک ارائه موجود، ممکن است نیاز به به‌روزرسانی یک نمودار سازمانی داشته باشید که در PowerPoint 97–2003 ایجاد شده است. Aspose.Slides این نمودارهای قدیمی را به عنوان اشیاء [ILegacyDiagram](https://reference.aspose.com/slides/java/com.aspose.slides/ilegacydiagram/) نشان می‌دهد. برای تبدیل یک نمودار به گروهی از اشکال به‌طوری که بتوانید عناصر بصری فردی را ویرایش کنید، از [LegacyDiagram.convertToGroupShape](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/#convertToGroupShape--) استفاده کنید. برای جزئیات بیشتر به [LegacyDiagram API Reference](https://reference.aspose.com/slides/java/com.aspose.slides/legacydiagram/) مراجعه کنید.

تبدیل یک گروه جدید به مجموعهٔ اشکال اضافه می‌کند بدون این‌که نمودار اصلی حذف شود. پس از تبدیل موفق، برای جلوگیری از محتوای تکراری، اصلی را با [IShapeCollection.remove](https://reference.aspose.com/slides/java/com.aspose.slides/ishapecollection/#remove-com.aspose.slides.IShape-) حذف کنید. قبل از تبدیل، نمودارهای قدیمی را در فهرستی جمع‌آوری کنید تا افزودن و حذف اشکال باعث خراب شدن تکرار نشود.

مثال زیر یک ارائه را باز می‌کند، هر اسلاید را جستجو می‌کند، نمودارها را به گروهی از اشکال تبدیل می‌کند و ارائهٔ به‌روز شده را به صورت PPTX ذخیره می‌نماید.

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

ارائهٔ ذخیره‌شده شامل گروه‌های قابل ویرایش از اشکال به‌جای نمودارهای قدیمی تبدیل‌شده است و دیگر نمودارهای اصلی در کنار آن‌ها وجود ندارد. PPTX را در PowerPoint باز کنید تا عناصر فردی داخل هر گروه، مانند متن، پرکن یا موقعیت آن‌ها را ویرایش کنید.

## **FAQ**

**آیا SmartArt از انعکاس یا معکوس کردن برای زبان‌های راست‑به‑چپ پشتیبانی می‌کند؟**

بله. متد [ISmartArt.setReversed](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/#setReversed-boolean-) جهت نمودار را از چپ به راست به راست به چپ (یا برعکس) تغییر می‌دهد وقتی طرح SmartArt انتخاب‌شده از معکوس شدن پشتیبانی کند.

**چگونه می‌توانم SmartArt را به همان اسلاید یا به ارائهٔ دیگری کپی کنم در حالی که قالب‌بندی حفظ شود؟**

می‌توانید با استفاده از [کپی کردن شکل SmartArt](/slides/fa/java/shape-manipulations/) و [ShapeCollection.addClone](https://reference.aspose.com/slides/java/com.aspose.slides/shapecollection/#addClone-com.aspose.slides.IShape-float-float-float-float-) یا با [کلون کردن کل اسلاید](/slides/fa/java/clone-slides/) که شامل SmartArt است، SmartArt را کپی کنید. هر دو روش اندازه، موقعیت و قالب‌بندی را حفظ می‌کنند.

**چگونه می‌توانم SmartArt را به تصویر رستر برای پیش‌نمایش یا خروجی وب رندر کنم؟**

می‌توانید با [رندر کردن اسلاید](/slides/fa/java/convert-powerpoint-to-png/) یا کل ارائه به PNG یا JPEG. SmartArt به‌عنوان بخشی از اسلاید رندر می‌شود.

**چگونه می‌توانم یک شیء SmartArt خاص را در یک اسلاید پیدا کنم اگر چندین مورد وجود داشته باشد؟**

از [Shape.setAlternativeText](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setAlternativeText-java.lang.String-) یا [Shape.setName](https://reference.aspose.com/slides/java/com.aspose.slides/shape/#setName-java.lang.String-) برای اختصاص یک متن جایگزین یا نام متمایز به شکل SmartArt استفاده کنید، آن مقدار را در [BaseSlide.getShapes](https://reference.aspose.com/slides/java/com.aspose.slides/baseslide/#getShapes--) جستجو کنید، و سپس بررسی کنید که شکل یافت‌شده یک [ISmartArt](https://reference.aspose.com/slides/java/com.aspose.slides/ismartart/) است.