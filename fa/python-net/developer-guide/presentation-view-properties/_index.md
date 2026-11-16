---
title: بازیابی و به‌روزرسانی ویژگی‌های نمای ارائه در پایتون
linktitle: ویژگی‌های نمای
type: docs
weight: 80
url: /fa/python-net/presentation-view-properties/
keywords: 
- ویژگی‌های نمای
- نمای عادی
- محتوای طرح کلی
- نمادهای طرح کلی
- قابلیت چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازهٔ بعد
- تنظیم خودکار
- بزرگنمایی پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- پایتون
- Aspose.Slides
description: "از Aspose.Slides برای پایتون از طریق .NET استفاده کنید تا تنظیمات نمای عادی، بزرگنمایی اسلاید و یادداشت‌ها، فاصله‌بندی شبکه و قابلیت نمایش نظرات را در ارائه‌های PowerPoint پیکربندی کنید."
---
## **مقدمه**

در نمای عادی PowerPoint، اسلاید بین یک نوار کناری برای تصویرهای کوچک یا طرح کلی و یک نوار یادداشت در پایین ظاهر می‌شود. Aspose.Slides برای Python از طریق .NET تنظیمات ذخیره‌شدهٔ ویرایشی ارائه را از طریق [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) نمایان می‌کند. این تنظیمات شامل چیدمان نوارها، سطح بزرگنمایی، فاصله‌بندی شبکه و قابلیت مشاهدهٔ نظرات می‌باشد.

## **درباره NormalViewProperties**

از [normal_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/normal_view_properties/) برای دسترسی به شیء [NormalViewProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/) استفاده کنید. [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) تعیین می‌کند که آیا نمادها در کنار عناوین اسلایدها در طرح کلی ظاهر می‌شوند یا خیر. [snap_vertical_splitter](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/snap_vertical_splitter/) به نوار کناری اجازه می‌دهد هنگام باریک شدن توسط کاربر به حالت به‌حداقل خود بچسبد. [prefer_single_view](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/prefer_single_view/) نشان‌دهندهٔ ترجیح برای نمایش یک نوار در تمام پنجره است.

[vertical_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/vertical_bar_state/) تقسیم‌کننده بین نوار کناری و اسلاید را کنترل می‌کند. [horizontal_bar_state](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/horizontal_bar_state/) تقسیم‌کننده بالای نوار یادداشت‌ها را کنترل می‌کند. هر دو مقدار [SplitterBarStateType](https://reference.aspose.com/slides/python-net/aspose.slides/splitterbarstatetype/) با مقادیر `MINIMIZED`، `MAXIMIZED` یا `RESTORED` را می‌پذیرند.

<!-- visual-explanation:presentation-view-properties:start -->
[![یک ویرایشگر مفهومی نوار کناری، ناحیهٔ اسلاید و ناحیهٔ پایین را با تقسیم‌کننده‌های عمودی و افقی برچسب‌گذاری شده جدا می‌کند.](visual-presentation-view-properties-40ae1765a743.svg)](visual-presentation-view-properties-40ae1765a743.svg)

*در نمای عادی، تقسیم‌کنندهٔ عمودی عرض نوار کناری را کنترل می‌کند. تقسیم‌کنندهٔ افقی فضای بالای نوار یادداشت‌ها را کنترل می‌کند.*
<!-- visual-explanation:presentation-view-properties:end -->

## **درباره بازگرداندن NormalViewProperties**

هنگامی که یک تقسیم‌کننده بازگردانده می‌شود، [restored_left](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_left/) اندازهٔ ذخیره‌شدهٔ نوار کناری را فراهم می‌کند و [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را فراهم می‌کند. هر دو [NormalViewRestoredProperties](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/) را نشان می‌دهند. ویژگی [dimension_size](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/dimension_size/) آن درصدی بین ۰ تا ۱۰۰ می‌پذیرد و [auto_adjust](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewrestoredproperties/auto_adjust/) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازهٔ پنجره، اندازه را تنظیم کند یا نه.

این مثال یک ارائهٔ موجود را به‌روز می‌کند. تقسیم‌کنندهٔ افقی را بازگردانی می‌کند، [restored_top](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/restored_top/) را به ۸۰٪ تنظیم می‌کند با فعال‌سازی تنظیم خودکار، و تقسیم‌کنندهٔ عمودی را حداکثر می‌کند. همچنین برای نمای طرح کلی، [show_outline_icons](https://reference.aspose.com/slides/python-net/aspose.slides/normalviewproperties/show_outline_icons/) را فعال می‌سازد.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    normal_view = presentation.view_properties.normal_view_properties
    normal_view.horizontal_bar_state = slides.SplitterBarStateType.RESTORED
    normal_view.vertical_bar_state = slides.SplitterBarStateType.MAXIMIZED
    normal_view.restored_top.auto_adjust = True
    normal_view.restored_top.dimension_size = 80
    normal_view.show_outline_icons = True

    presentation.save("presentation_normal_view_state.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم مقدار پیش‌فرض بزرگنمایی**

[slide_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/slide_view_properties/) و [notes_view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/notes_view_properties/) تنظیمات بزرگنمایی مستقل برای ویرایشگر را ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح صادرات تصویر تأثیری ندارند.

این مثال یک ارائهٔ موجود را باز می‌کند و [variable_scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/variable_scale/) را برای تنظیم اسلاید به اندازهٔ پنجرهٔ ویرایش فعال می‌سازد. برای صفحهٔ یادداشت‌ها، مقیاس خودکار را غیرفعال می‌کند و [scale](https://reference.aspose.com/slides/python-net/aspose.slides/commonslideviewproperties/scale/) را بر روی بزرگنمایی ثابت ۸۰٪ تنظیم می‌کند.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    view_properties.slide_view_properties.variable_scale = True
    view_properties.notes_view_properties.variable_scale = False
    view_properties.notes_view_properties.scale = 80

    presentation.save("zoom.pptx", slides.export.SaveFormat.PPTX)
```

## **تنظیم فاصله‌بندی شبکه**

[grid_spacing](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/grid_spacing/) فاصله بین خطوط شبکهٔ ویرایشی در تمام ارائه را تعیین می‌کند. این مقدار یک مقدار مثبت بر حسب پوینت است که ۷۲ پوینت برابر با یک اینچ می‌باشد. این مثال فاصلهٔ فعلی را در یک ارائهٔ موجود چاپ می‌کند و با تنظیم بازه به ۱۸ پوینت، شبکهٔ یک‌چهارم اینچ را ذخیره می‌سازد.

```py
import aspose.slides as slides

with slides.Presentation("demo.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current grid spacing: {view_properties.grid_spacing} points")

    view_properties.grid_spacing = 18.0

    presentation.save("grid-spacing.pptx", slides.export.SaveFormat.PPTX)
```

شبکه با یک بازهٔ ثابت تکرار می‌شود. [Drawing guides](/slides/fa/python-net/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه را علامت‌گذاری می‌کنند. هر دو به‌عنوان کمک‌کننده‌های ویرایشی هستند و تنها در ویرایشگرهایی که آن‌ها را نمایش می‌دهند ظاهر می‌شوند. نمایش اسلاید و صادرات به PDF، تصاویر یا SVG آن‌ها را حذف می‌کنند.

## **نمایش یا مخفی کردن نظرات هنگام باز کردن یک ارائه**

[show_comments](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/show_comments/) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائهٔ موجود که شامل نظرات است، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخهٔ کپی با نظرات مخفی ذخیره می‌سازد. همچنین [last_view](https://reference.aspose.com/slides/python-net/aspose.slides/viewproperties/last_view/) را به [ViewType.SLIDE_VIEW](https://reference.aspose.com/slides/python-net/aspose.slides/viewtype/) تنظیم می‌کند تا نسخهٔ کپی در نمای اسلاید باز شود.

```py
import aspose.slides as slides

with slides.Presentation("comments.pptx") as presentation:
    view_properties = presentation.view_properties
    print(f"Current comment visibility: {view_properties.show_comments}")

    view_properties.show_comments = slides.NullableBool.FALSE
    view_properties.last_view = slides.ViewType.SLIDE_VIEW
    
    presentation.save("comments-hidden.pptx", slides.export.SaveFormat.PPTX)
```

مخفی کردن نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آن‌ها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/python-net/presentation-comments/) مراجعه کنید. تنظیمات صادرات تعیین می‌کند که آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوات ظاهر شوند یا نه.

## **سوالات متداول**

**چرا هنگام باز کردن دوبارهٔ ارائه، شبکه مخفی است؟**

ارائه بازهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، قابلیت نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک کردن راهنمایی‌های رسم (drawing guides) فاصلهٔ شبکه را تغییر می‌دهد؟**

خیر. افزودن، جابجایی یا پاک کردن یک راهنما بازهٔ شبکه را تحت تأثیر قرار نمی‌دهد.

**آیا بخش‌های مختلف یک ارائه می‌توانند تنظیمات نمای متفاوتی داشته باشند؟**

خیر. [Presentation.view_properties](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/view_properties/) بر تمام ارائه اعمال می‌شود.

**آیا می‌توانم تنظیمات نمای مختلفی برای کاربران مختلف ذخیره کنم؟**

فایل یک مجموعهٔ تنظیمات نمای برای همه ذخیره می‌کند. یک ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توانم تنظیمات نمای را در یک الگو ذخیره کنم؟**

بله. ارائه‌های ایجاد شده از الگو، تنظیمات نمای ذخیره‌شدهٔ آن را به ارث می‌برند.