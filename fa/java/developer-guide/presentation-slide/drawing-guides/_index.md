---
title: مدیریت راهنماهای کشیدنی در ارائه‌های جاوا
linktitle: راهنماهای کشیدنی
type: docs
weight: 85
url: /fa/java/drawing-guides/
keywords:
- راهنمای کشیدنی
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌راستایی
- نمای اسلاید
- اسلاید مستر
- اسلید طرح‌بندی
- مستر یادداشت
- مستر توزیع
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "افزودن، دسترسی و حذف راهنماهای کشیدنی افقی و عمودی در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Java."
---
## **بررسی اجمالی**

راهنماهای کشیدنی خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند تا شکل‌ها را در حین ویرایش یک ارائه در PowerPoint به‌صورت یکنواخت هم‌راستا کنند. این راهنماها به‌ویژه زمانی مفید هستند که یک برنامه یک ارائه را تولید می‌کند که بعدها به‌صورت دستی بهبود یابد: برنامه می‌تواند همان ابزارهای هم‌راستایی را ذخیره کند تا نویسندگان هنگام افزودن یا جابه‌جایی محتوا از آن‌ها پیروی کنند.

راهنماهای کشیدنی ابزارهای ویرایشی هستند، نه محتوای اسلاید. آن‌ها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای Java این راهنماها را از طریق رابط [IDrawingGuidesCollection](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/) در دسترس قرار می‌دهد. یک راهنما توسط [IDrawingGuide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguide/) نمایش داده می‌شود و دارای جهت، موقعیت و رنگ است.

موقعیت بر حسب پوینت از گوشه بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از یک مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمای افقی از یک مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید قرار دارد.

## **افزودن راهنماها به نمای اسلاید**

از [ICommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/icommonslideviewproperties/#getDrawingGuides--) برای مدیریت راهنماهای نمایش داده‌شده هنگام ویرایش اسلایدهای عادی استفاده کنید. با مقدار [Orientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/orientation/) و موقعیتی بر حسب پوینت، متد [IDrawingGuidesCollection.add](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/#add-byte-float-) را فراخوانی کنید.

مثال زیر یک راهنمای عمودی در سمت راست مرکز اسلاید و یک راهنمای افقی در زیر آن اضافه می‌کند:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 + 12.5));
    guides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 12.5));

    presentation.save("drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی به راهنماهای کشیدنی**

متدهای [IDrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/#getCount--) و [IDrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/#get_Item-int-) دسترسی به راهنماهای **موجود** را فراهم می‌کنند. متدهای [IDrawingGuide.getOrientation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguide/#getOrientation--)، [IDrawingGuide.getPosition](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguide/#getPosition--) و [IDrawingGuide.getColor](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguide/#getColor--) مقادیری را بر می‌گردانند که می‌توانند از طریق متدهای setter مربوطه نیز تغییر یابند.

مثال زیر راهنماهای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شد می‌خواند:

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

## **افزودن راهنماها به مسترها و اسلایدهای طرح‌بندی**

یک مستر اسلاید و هر یک از اسلایدهای طرح‌بندی آن می‌توانند مجموعه‌های راهنمای کشیدنی خود را داشته باشند. برای یک مستر اسلاید از [IMasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterslide/#getDrawingGuides--) و برای یک اسلاید طرح‌بندی از [ILayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ilayoutslide/#getDrawingGuides--) استفاده کنید.

مثال زیر یک راهنمای عمودی به اولین مستر اسلاید و یک راهنمای افقی به اولین اسلاید طرح‌بندی اضافه می‌کند:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D slideSize = presentation.getSlideSize().getSize();
    IDrawingGuidesCollection masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    IDrawingGuidesCollection layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(Orientation.Vertical, (float) (slideSize.getWidth() / 2 - 20));
    layoutGuides.add(Orientation.Horizontal, (float) (slideSize.getHeight() / 2 + 20));

    presentation.save("master-layout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن راهنماها به مسترهای یادداشت و توزیع**

مستارهای یادداشت و مستارهای توزیع نیز از راهنماهای کشیدنی پشتیبانی می‌کنند. برای دسترسی به مجموعه‌های آن‌ها از [IMasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslide/#getDrawingGuides--) و [IMasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslide/#getDrawingGuides--) استفاده کنید. اگر ارائه شامل یکی از این مستارها نباشد، متدهای [IMasterNotesSlideManager.setDefaultMasterNotesSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasternotesslidemanager/#setDefaultMasterNotesSlide--) یا [IMasterHandoutSlideManager.setDefaultMasterHandoutSlide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/imasterhandoutslidemanager/#setDefaultMasterHandoutSlide--) مستار پیش‌فرض را ایجاد و بر می‌گردانند.

مثال زیر یک راهنمای افقی به یک مستر یادداشت و یک راهنمای عمودی به یک مستر توزیع اضافه می‌کند:

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation();
try {
    Dimension2D notesSize = presentation.getNotesSize().getSize();
    IMasterNotesSlide notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    IMasterHandoutSlide handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(Orientation.Horizontal, (float) (notesSize.getHeight() / 2 + 50));
    handoutMaster.getDrawingGuides().add(Orientation.Vertical, (float) (notesSize.getWidth() / 2 - 50));

    presentation.save("notes-handout-drawing-guides.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پاک‌سازی راهنماهای کشیدنی**

برای حذف تمام راهنماها از یک مجموعه خاص، متد [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/#clear--) را صدا بزنید. پاک‌سازی یک مجموعه باعث تأثیر بر راهنماهای ذخیره‌شده در حوزه دیگر نمی‌شود.

مثال زیر راهنماهای نمای اسلاید و تمام راهنماهای موجود بر روی مسترهای اسلاید، اسلایدهای طرح‌بندی، مستر یادداشت و مستر توزیع را بدون ایجاد مستارهای گمشده پاک می‌کند:

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

## **سوالات متداول**

**آیا راهنماهای کشیدنی در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**

خیر. راهنماهای کشیدنی ابزارهای هم‌راستایی برای ویرایش هستند و به عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک راهنمای کشیدنی را مستقیماً به یک اسلاید نرمال فردی اضافه کرد؟**

راهنماهای ویرایشی اسلایدهای نرمال در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های راهنماهای جداگانه‌ای برای مسترهای اسلاید، اسلایدهای طرح‌بندی، مسترهای یادداشت و مسترهای توزیع موجود است.

**کدام واحدها برای موقعیت راهنماها استفاده می‌شود؟**

موقعیت‌ها بر حسب پوینت مشخص می‌شوند، به‌طوری که ۷۲ پوینت معادل یک اینچ است. موقعیت‌های عمودی از لبه چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبه بالا.

**آیا پاک‌سازی راهنماهای کشیدنی اشکال را حذف می‌کند یا محتوای اسلاید را تغییر می‌دهد؟**

خیر. متد [IDrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/java/com.aspose.slides/idrawingguidescollection/#clear--) فقط راهنماهای موجود در مجموعه انتخاب‌شده را حذف می‌کند. اشکال و دیگر محتوای اسلاید بدون تغییر باقی می‌مانند.