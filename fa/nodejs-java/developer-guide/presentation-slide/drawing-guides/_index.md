---
title: مدیریت خطوط راهنمای رسم در ارائه‌ها در جاوااسکریپت
linktitle: خطوط راهنمای رسم
type: docs
weight: 85
url: /fa/nodejs-java/drawing-guides/
keywords:
- راهنمای رسم
- راهنمای افقی
- راهنمای عمودی
- راهنمای هم‌راستا سازی
- نمای اسلاید
- مستر اسلاید
- اسلاید طرح‌بندی
- مستر یادداشت
- مستر جزوه
- PowerPoint
- ارائه
- Node.js
- JavaScript
- Aspose.Slides
description: "افزودن، دسترسی و پاک‌سازی خطوط راهنمای افقی و عمودی در ارائه‌های PowerPoint با استفاده از Aspose.Slides برای Node.js از طریق Java."
---
## **نگاهی کلی**

خطوط راهنمای رسم خطوط افقی و عمودی قابل تنظیمی هستند که به کاربران کمک می‌کنند تا اشکال را به طور یکسان هنگام ویرایش یک ارائه در PowerPoint هم‌راستا کنند. این خطوط به‌ویژه زمانی مفیدند که یک برنامه یک ارائه تولید می‌کند که پس از آن به‌صورت دستی اصلاح می‌شود: برنامه می‌تواند همان ابزارهای هم‌راستا سازی را ذخیره کند تا نویسندگان هنگام افزودن یا جابجایی محتوا از آنها پیروی کنند.

خطوط راهنمای رسم ابزارهای ویرایشی هستند، نه محتوای اسلاید. آنها در نمایش اسلاید یا خروجی رندر شده ظاهر نمی‌شوند. Aspose.Slides برای Node.js از طریق Java این خطوط را از طریق کلاس [DrawingGuidesCollection](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/) در اختیار می‌گذارد. یک راهنما توسط [DrawingGuide](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguide/) نمایش داده می‌شود و دارای جهت‌گیری، موقعیت و رنگ است.

موقعیت بر حسب پوینت از گوشهٔ بالا‑چپ اسلاید یا مستر مربوطه اندازه‌گیری می‌شود. یک راهنمای عمودی از مختصات افقی استفاده می‌کند که معمولاً بین صفر و عرض اسلاید قرار دارد. یک راهنمای افقی از مختصات عمودی استفاده می‌کند که معمولاً بین صفر و ارتفاع اسلاید قرار دارد.

## **افزودن خطوط راهنما به نمای اسلاید**

از [CommonSlideViewProperties.getDrawingGuides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/commonslideviewproperties/#getDrawingGuides) برای مدیریت خطوط راهنمای نمایش داده‌شده هنگام ویرایش اسلایدهای معمولی استفاده کنید. با فراخوانی [DrawingGuidesCollection.add](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/#add) یک مقدار [Orientation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/orientation/) و موقعیتی بر حسب پوینت، یک راهنما اضافه می‌شود.

مثال زیر یک راهنمای عمودی به سمت راست مرکز اسلاید و یک راهنمای افقی زیر آن اضافه می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    guides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 + 12.5);
    guides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 12.5);

    presentation.save("drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **دسترسی به خطوط راهنما**

متدهای [DrawingGuidesCollection.getCount](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/#getCount) و [DrawingGuidesCollection.get_Item](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/#get_Item) دسترسی به خطوط راهنمای موجود را فراهم می‌کنند. متدهای [DrawingGuide.getOrientation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguide/#getOrientation)، [DrawingGuide.getPosition](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguide/#getPosition) و [DrawingGuide.getColor](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguide/#getColor) مقادیری را برمی‌گردانند که می‌توان از طریق متدهای تنظیم‌گر مربوطه نیز آن‌ها را تغییر داد.

مثال زیر خطوط راهنمای نمای اسلاید را از ارائه‌ای که در بالا ایجاد شد می‌خواند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("drawing-guides.pptx");
try {
    const guides = presentation.getViewProperties().getSlideViewProperties().getDrawingGuides();

    for (let index = 0; index < guides.getCount(); index++) {
        const guide = guides.get_Item(index);
        console.log("Guide " + index + ": orientation = " + guide.getOrientation() + ", position = " + guide.getPosition() + ", color = " + guide.getColor());
    }
} finally {
    presentation.dispose();
}
```

## **افزودن خطوط راهنما به مسترها و اسلایدهای طرح‌بندی**

یک مستر اسلاید و هر یک از اسلایدهای طرح‌بندی می‌توانند مجموعهٔ خطوط راهنمای خود را داشته باشند. برای یک مستر اسلاید از [MasterSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterslide/#getDrawingGuides) و برای یک اسلاید طرح‌بندی از [LayoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/layoutslide/#getDrawingGuides) استفاده کنید.

مثال زیر یک راهنمای عمودی به اولین مستر اسلاید و یک راهنمای افقی به اولین اسلاید طرح‌بندی اضافه می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const slideSize = presentation.getSlideSize().getSize();
    const masterGuides = presentation.getMasters().get_Item(0).getDrawingGuides();
    const layoutGuides = presentation.getLayoutSlides().get_Item(0).getDrawingGuides();

    masterGuides.add(slides.Orientation.Vertical, slideSize.getWidth() / 2 - 20);
    layoutGuides.add(slides.Orientation.Horizontal, slideSize.getHeight() / 2 + 20);

    presentation.save("master-layout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن خطوط راهنما به مسترهای یادداشت و جزوه**

مسترهای یادداشت و جزوه نیز از خطوط راهنما پشتیبانی می‌کنند. از [MasterNotesSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masternotesslide/#getDrawingGuides) و [MasterHandoutSlide.getDrawingGuides](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/masterhandoutslide/#getDrawingGuides) برای دسترسی به مجموعه‌های آن‌ها استفاده کنید. اگر ارائه‌ای یکی از این مسترها را نداشته باشد، `MasterNotesSlideManager.setDefaultMasterNotesSlide` یا `MasterHandoutSlideManager.setDefaultMasterHandoutSlide` مستر پیش‌فرض را ایجاد کرده و برمی‌گرداند.

مثال زیر یک راهنمای افقی به مستر یادداشت و یک راهنمای عمودی به مستر جزوه اضافه می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation();
try {
    const notesSize = presentation.getNotesSize().getSize();
    const notesMaster = presentation.getMasterNotesSlideManager().setDefaultMasterNotesSlide();
    const handoutMaster = presentation.getMasterHandoutSlideManager().setDefaultMasterHandoutSlide();

    notesMaster.getDrawingGuides().add(slides.Orientation.Horizontal, notesSize.getHeight() / 2 + 50);
    handoutMaster.getDrawingGuides().add(slides.Orientation.Vertical, notesSize.getWidth() / 2 - 50);

    presentation.save("notes-handout-drawing-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پاک کردن خطوط راهنما**

با فراخوانی [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/#clear) می‌توانید تمام راهنماها را از یک مجموعهٔ خاص حذف کنید. پاک کردن یک مجموعه تأثیری بر خطوط راهنمای ذخیره‌شده در حوزهٔ دیگری ندارد.

مثال زیر خطوط راهنمای نمای اسلاید و تمام خطوط راهنما در مسترهای اسلاید، اسلایدهای طرح‌بندی، مستر یادداشت و مستر جزوه را بدون ایجاد مسترهای گمشده پاک می‌کند:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("presentation-with-guides.pptx");
try {
    presentation.getViewProperties().getSlideViewProperties().getDrawingGuides().clear();

    for (let index = 0; index < presentation.getMasters().size(); index++) {
        presentation.getMasters().get_Item(index).getDrawingGuides().clear();
    }

    for (let index = 0; index < presentation.getLayoutSlides().size(); index++) {
        presentation.getLayoutSlides().get_Item(index).getDrawingGuides().clear();
    }

    const notesMaster = presentation.getMasterNotesSlideManager().getMasterNotesSlide();
    if (notesMaster !== null) {
        notesMaster.getDrawingGuides().clear();
    }

    const handoutMaster = presentation.getMasterHandoutSlideManager().getMasterHandoutSlide();
    if (handoutMaster !== null) {
        handoutMaster.getDrawingGuides().clear();
    }

    presentation.save("presentation-without-guides.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

**آیا خطوط راهنمای رسم در نمایش اسلاید یا تصاویر صادرشده ظاهر می‌شوند؟**

خیر. خطوط راهنمای رسم ابزارهای هم‌راستا سازی برای ویرایش هستند و به‌عنوان محتوای ارائه رندر نمی‌شوند.

**آیا می‌توان یک خط راهنما را مستقیماً به یک اسلاید معمولی اضافه کرد؟**

راهنماهای ویرایشی اسلایدهای معمولی در ویژگی‌های نمای اسلاید ارائه ذخیره می‌شوند. مجموعه‌های جداگانه‌ای برای مسترهای اسلاید، اسلایدهای طرح‌بندی، مسترهای یادداشت و جزوه موجود است.

**واحدهای استفاده‌شده برای موقعیت راهنماها چه هستند؟**

موقعیت‌ها بر حسب پوینت مشخص می‌شوند، به‌طوری که ۷۲ پوینت برابر یک اینچ است. موقعیت‌های عمودی از لبهٔ چپ اندازه‌گیری می‌شوند و موقعیت‌های افقی از لبهٔ بالا.

**آیا پاک کردن خطوط راهنما باعث حذف اشکال یا تغییر محتوای اسلاید می‌شود؟**

خیر. متد [DrawingGuidesCollection.clear](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/drawingguidescollection/#clear) تنها راهنماهای موجود در مجموعهٔ انتخاب‌شده را حذف می‌کند. اشکال و سایر محتوای اسلاید بدون تغییر می‌مانند.