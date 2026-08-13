---
title: مدیریت انتقال اسلایدها در ارائه‌ها بر روی Android
linktitle: انتقال اسلاید
type: docs
weight: 80
url: /fa/androidjava/slide-transition/
keywords:
- انتقال اسلاید
- افزودن انتقال اسلاید
- اعمال انتقال اسلاید
- انتقال پیشرفته اسلاید
- انتقال مورف
- نوع انتقال
- اثر انتقال
- PowerPoint
- OpenDocument
- ارائه
- Android
- Java
- Aspose.Slides
description: "کشف کنید چگونه انتقال اسلایدها را در Aspose.Slides برای Android از طریق Java سفارشی کنید، با راهنمای گام به گام برای ارائه‌های PowerPoint و OpenDocument."
---
## **بررسی اجمالی**

این مقاله توضیح می‌دهد که چگونه می‌توان انتقال‌های اسلاید را در ارائه‌ها با استفاده از Aspose.Slides مدیریت کرد. این مقاله نشان می‌دهد چگونه انواع انتقال را به اسلایدها اعمال کنید، رفتار انتقال را تنظیم کنید مانند پیشروی با کلیک یا پس از زمان معین، از انتقال Morph و انواع آن استفاده کنید، و گزینه‌های اثر انتقال را تنظیم نمایید. مثال‌ها نشان می‌دهند چگونه یک ارائه را بارگیری یا ایجاد کنید، تنظیمات انتقال اسلایدهای انتخاب شده را تغییر دهید، و نتیجه را به صورت فایل PPTX ذخیره کنید. همچنین به سؤالات رایج درباره سرعت انتقال، صداهای انتقال، اعمال همان انتقال بر روی چندین اسلاید، و بررسی انتقال فعلی تنظیم‌شده بر روی اسلاید پاسخ می‌دهد.

## **افزودن انتقال اسلاید**
برای ایجاد یک اثر انتقال اسلاید ساده، مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای Android از طریق Java با استفاده از enum TransitionType اعمال کنید.
1. فایل ارائهٔ تغییر یافته را بنویسید.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation برای بارگذاری فایل ارائه منبع ایجاد کنید
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // انتقال نوع دایره‌ای را روی اسلاید 1 اعمال کنید
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // انتقال نوع شانه‌ای را روی اسلاید 2 اعمال کنید
    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);

    // ارائه را بر روی دیسک ذخیره کنید
    presentation.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **افزودن انتقال پیشرفته به اسلاید**
در بخش فوق، ما فقط یک اثر انتقال ساده بر روی اسلاید اعمال کردیم. حالا برای بهبود و کنترل بیشتر این اثر انتقال ساده، لطفاً مراحل زیر را دنبال کنید:

1. یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation) ایجاد کنید.
1. یک نوع انتقال اسلاید را بر روی اسلاید از میان اثرهای انتقال ارائه‌شده توسط Aspose.Slides برای Android از طریق Java اعمال کنید.
1. همچنین می‌توانید انتقال را به پیشروی با کلیک، پس از یک بازه زمان مشخص یا هر دو تنظیم کنید.
1. اگر انتقال اسلاید برای پیشروی با کلیک فعال باشد، انتقال تنها زمانی که کاربر کلیک کند پیش می‌رود. علاوه بر این، اگر ویژگی Advance After Time تنظیم شده باشد، انتقال به‌صورت خودکار پس از گذشت زمان مشخص پیش می‌رود.
1. ارائهٔ تغییر یافته را به‌عنوان یک فایل ارائه ذخیره کنید.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation که نمایانگر یک فایل ارائه است
Presentation pres = new Presentation("BetterSlideTransitions.pptx");
try {
    // انتقال نوع دایره‌ای را روی اسلاید 1 اعمال کنید
    pres.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Circle);

    // پیشروی با کلیک یا به‌صورت خودکار پس از 3 ثانیه
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(0).getSlideShowTransition().setAdvanceAfterTime(3000);

    // انتقال نوع شانه‌ای را روی اسلاید 2 اعمال کنید
    pres.getSlides().get_Item(1).getSlideShowTransition().setType(TransitionType.Comb);
    
    // پیشروی با کلیک یا به‌صورت خودکار پس از 5 ثانیه
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(1).getSlideShowTransition().setAdvanceAfterTime(5000);

    // انتقال نوع زوم را روی اسلاید 3 اعمال کنید
    pres.getSlides().get_Item(2).getSlideShowTransition().setType(TransitionType.Zoom);
    
    // پیشروی با کلیک یا به‌صورت خودکار پس از 7 ثانیه
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceOnClick(true);
    pres.getSlides().get_Item(2).getSlideShowTransition().setAdvanceAfterTime(7000);

    // ارائه را بر روی دیسک ذخیره کنید
    pres.save("SampleTransition_out.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

## **انتقال Morph**
{{% alert color="info" %}} 
Aspose.Slides برای Android از طریق Java اکنون از [Morph Transition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/IMorphTransition) پشتیبانی می‌کند. اینها نمایانگر انتقال morph جدیدی هستند که در PowerPoint 2019 معرفی شد.
{{% /alert %}} 

انتقال Morph به شما امکان می‌دهد حرکت صاف بین یک اسلاید و اسلاید بعدی را به‌صورت انیمیشن نشان دهید. این مقاله مفهوم و نحوه استفاده از انتقال Morph را توضیح می‌دهد. برای استفاده مؤثر از انتقال Morph، نیاز است دو اسلاید داشته باشید که حداقل یک شیء مشترک داشته باشند. ساده‌ترین روش این است که اسلاید را کپی کنید و سپس شیء را در اسلید دوم به مکان دیگری منتقل کنید.

قطعه کد زیر نشان می‌دهد چگونه یک کپی از اسلاید با متنی را به ارائه اضافه کنید و یک انتقال از نوع [morph type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TransitionType) را برای اسلاید دوم تنظیم کنید.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    AutoShape autoshape = (AutoShape)presentation.getSlides().get_Item(0).getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 400, 100);
    autoshape.getTextFrame().setText("Morph Transition in PowerPoint Presentations");

    presentation.getSlides().addClone(presentation.getSlides().get_Item(0));

    IShape shape = presentation.getSlides().get_Item(1).getShapes().get_Item(0);
    shape.setX(shape.getX() + 100);
    shape.setY(shape.getY() + 50);
    shape.setWidth(shape.getWidth() - 200);
    shape.setHeight(shape.getHeight() - 10);

    presentation.getSlides().get_Item(1).getSlideShowTransition().setType(com.aspose.slides.TransitionType.Morph);

    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **انواع انتقال Morph**
یک مقدار enum جدید به نام [TransitionMorphType](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/TransitionMorphType) افزوده شده است. این مقدار انواع مختلف انتقال اسلاید Morph را نشان می‌دهد.

enum TransitionMorphType دارای سه عضو است:

- ByObject: انتقال Morph با در نظر گرفتن اشکال به‌عنوان اشیاء غیرقابل تقسیم انجام می‌شود.
- ByWord: انتقال Morph با انتقال متن به‌صورت کلمات در صورتی که ممکن باشد انجام می‌شود.
- ByChar: انتقال Morph با انتقال متن به‌صورت حروف در صورتی که ممکن باشد انجام می‌شود.

قطعه کد زیر نشان می‌دهد چگونه انتقال morph را به اسلاید تنظیم کنید و نوع morph را تغییر دهید:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Morph);
    ((IMorphTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setMorphType(TransitionMorphType.ByWord);
    presentation.save("presentation-out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم اثرهای انتقال**
Aspose.Slides برای Android از طریق Java امکان تنظیم اثرهای انتقال مانند از سیاه، از چپ، از راست و غیره را دارد. برای تنظیم اثر انتقال، لطفاً مراحل زیر را دنبال کنید:

- یک نمونه از کلاس [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/Presentation) ایجاد کنید.
- مرجع اسلاید را دریافت کنید.
- اثر انتقال را تنظیم کنید.
- ارائه را به‌عنوان یک فایل [PPTX ](https://docs.fileformat.com/presentation/pptx/) بنویسید.

در مثال زیر، ما اثرهای انتقال را تنظیم کرده‌ایم.

```java
import com.aspose.slides.*;

// یک نمونه از کلاس Presentation ایجاد کنید
Presentation presentation = new Presentation("AccessSlides.pptx");
try {
    // تنظیم اثر
    presentation.getSlides().get_Item(0).getSlideShowTransition().setType(TransitionType.Cut);
    ((OptionalBlackTransition)presentation.getSlides().get_Item(0).getSlideShowTransition().getValue()).setFromBlack(true);
    
    // ارائه را بر روی دیسک ذخیره کنید
    presentation.save("SetTransitionEffects_out.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **سوالات متداول**

### می‌توانم سرعت پخش انتقال اسلاید را کنترل کنم؟
بله. سرعت انتقال را با استفاده از تنظیم [speed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSpeed-int-) از طریق تنظیم [TransitionSpeed](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/transitionspeed/) (مثلاً آهسته/متوسط/سریع) تنظیم کنید.

### آیا می‌توانم صدا به یک انتقال اضافه کنم و آن را حلقه‌ای کنم؟
بله. می‌توانید یک صدای پس‌زمینه برای انتقال تعبیه کنید و رفتار آن را از طریق تنظیماتی مانند حالت صدا و حلقه‌دار کردن (مثلاً [setSound](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSound-com.aspose.slides.IAudio-)، [setSoundMode](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundMode-int-)، [setSoundLoop](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundLoop-boolean-))، به‌علاوه متادیتاهایی مانند [setSoundIsBuiltIn](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundIsBuiltIn-boolean-) و [setSoundName](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setSoundName-java.lang.String-)) تنظیم کنید.

### سریع‌ترین روش برای اعمال یک انتقال یکسان بر روی همه اسلایدها چیست؟
نوع انتقال موردنظر را در تنظیمات انتقال هر اسلاید پیکربندی کنید؛ انتقال‌ها به‌صورت جداگانه برای هر اسلاید ذخیره می‌شوند، بنابراین اعمال یک نوع یکسان بر روی تمام اسلایدها نتیجهٔ یکنواختی می‌دهد.

### چگونه می‌توانم بررسی کنم که چه انتقالی در حال حاضر بر روی یک اسلاید تنظیم شده است؟
تنظیمات [transition](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/baseslide/#getSlideShowTransition--) اسلاید را بررسی کنید و [transition type](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/slideshowtransition/#setType-int-) آن را بخوانید؛ این مقدار دقیقاً نشان می‌دهد که چه اثری اعمال شده است.