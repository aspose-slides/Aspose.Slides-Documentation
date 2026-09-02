---
title: مدیریت راهنماهای کشیده‌ای در ارائه‌ها در اندروید
linktitle: راهنماهای کشیده‌ای
type: docs
weight: 85
url: /fa/androidjava/drawing-guides/
keywords:
- راهنمای کشیده‌ای
- راهنمای افقی
- راهنمای عمودی
- راهنمای ترازبندی
- نمای اسلاید
- اسلاید مستر
- اسلاید چیدمان
- مستر یادداشت
- مستر جزوه
- PowerPoint
- ارائه
- Android
- Java
- Aspose.Slides
description: "راهنماهای کشیده‌ای افقی و عمودی را در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Android از طریق Java اضافه، دسترسی و حذف کنید."
---
## **مرور کلی**

راهنمای‌های کشیده‌ای خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند هنگام ویرایش یک ارائه در PowerPoint اشکال را به‌صورت یکنواخت تراز کنند. این راهنماها به‌ویژه زمانی مفید هستند که یک برنامه یک ارائه تولید می‌کند که بعداً به‌صورت دستی اصلاح خواهد شد: برنامه می‌تواند همان ابزارهای ترازبندی را ذخیره کند تا نویسندگان هنگام افزودن یا جابه‌جایی محتوا از آن‌ها پیروی کنند.

راهنمای‌های کشیده‌ای ابزارهای ویرایشی هستند، نه محتوای اسلاید. آن‌ها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای Android از طریق Java این‌ها را از طریق رابط [IDrawingGuidesCollection](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [IDrawingGuide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguide/) نمایش داده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب نقطه از گوشه بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید است. یک راهنمای افقی از مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید است.

## **افزودن راهنماها به نمای اسلاید**

از [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) برای مدیریت راهنماهایی که هنگام ویرایش اسلایدهای عادی نمایش داده می‌شوند، استفاده کنید. با مقدار [Orientation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/orientation/) و موقعیتی بر حسب نقطه، متد [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/#add-byte-float-) را فراخوانی کنید.

مثال زیر یک راهنمای عمودی به سمت راست مرکز اسلاید و یک راهنمای افقی زیر آن اضافه می‌کند:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, slideSize.getWidth() / 2 + 12.5f);
    guides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5f);

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی به راهنماهای کشیده‌ای**

متدهای [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/#getCount--) و [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/#get_Item-int-) دسترسی به راهنماهای موجود را فراهم می‌کنند. متدهای [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguide/#getOrientation--)، [IDrawingGuide.getPosition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguide/#getPosition--) و [IDrawingGuide.getColor](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguide/#getColor--) مقادیری را بر می‌گردانند که می‌توانند از طریق متدهای setter مرتبط تغییر یابند.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شده است، می‌خواند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("drawing-guides.pptx");
try {
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (int index = 0; index < guides.getCount(); index++) {
        IDrawingGuide guide = guides.get_Item(index);
        System.out.println("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **افزودن راهنماها به اسلایدهای مستر و چیدمان**

یک مستر اسلاید و هر یک از اسلایدهای چیدمان آن می‌توانند مجموعه‌های راهنمای کشیده‌ای خود را داشته باشند. برای یک مستر اسلاید از [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterslide/#getDrawingGuides--) استفاده کنید و برای یک اسلاید چیدمان از [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ilayoutslide/#getDrawingGuides--) استفاده کنید.

مثال زیر یک راهنمای عمودی به اولین مستر اسلاید و یک راهنمای افقی به اولین اسلاید چیدمان اضافه می‌کند:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن راهنماها به مسترهای یادداشت و جزوه**

مسترهای یادداشت و مسترهای جزوه نیز از راهنماهای کشیده‌ای پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آن‌ها از [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslide/#getDrawingGuides--) و [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) استفاده کنید. اگر یک ارائه یکی از این مسترها را نداشته باشد، [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) یا [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمای افقی به مستر یادداشت و یک راهنمای عمودی به مستر جزوه اضافه می‌کند:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation();
try {
    SizeF notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **حذف راهنماهای کشیده‌ای**

متد [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) را فراخوانی کنید تا تمام راهنماها از یک مجموعه مشخص حذف شوند. پاک‌سازی یک مجموعه روی راهنماهای ذخیره‌شده در حوزه‌ای دیگر تأثیری ندارد.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود در مسترهای اسلاید، اسلایدهای چیدمان، مستر یادداشت و مستر جزوه را بدون ایجاد مسترهای مفقود پاک می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (IMasterSlide masterSlide : presentation.getMasters()) {
        masterSlide.getDrawingGuides().clear();
    }

    for (ILayoutSlide layoutSlide : presentation.getLayoutSlides()) {
        layoutSlide.getDrawingGuides().clear();
    }

    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster != null) {
        notesMaster.getDrawingGuides().clear();
    }

    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster != null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**آیا راهنماهای کشیده‌ای در نمایش اسلاید یا تصاویر صادر شده ظاهر می‌شوند؟**

خیر. راهنماهای کشیده‌ای ابزارهای ترازبندی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای کشیده‌ای را مستقیماً به یک اسلاید عادی اضافه کرد؟**

راهنماهای ویرایشی اسلایدهای عادی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنمای جداگانه‌ای برای مسترهای اسلاید، اسلایدهای چیدمان، مسترهای یادداشت و مسترهای جزوه در دسترس هستند.

**واحدهای مورد استفاده برای موقعیت راهنماها چیست؟**

موقعیت‌ها به‌واحد نقطه مشخص می‌شوند که ۷۲ نقطه معادل یک اینچ است. موقعیت‌های عمودی از لبه چپ و موقعیت‌های افقی از لبه بالا اندازه‌گیری می‌شوند.

**آیا پاک‌سازی راهنماهای کشیده‌ای اشکال را حذف می‌کند یا محتوای اسلاید را تغییر می‌دهد؟**

خیر. متد [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/idrawingguidescollection/#clear--) تنها راهنماهای موجود در مجموعه انتخاب‌شده را حذف می‌کند. اشکال و سایر محتوای اسلاید بدون تغییر باقی می‌مانند.