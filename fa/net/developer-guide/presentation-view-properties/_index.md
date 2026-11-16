---
title: دریافت و به‌روزرسانی ویژگی‌های نمای ارائه در .NET
linktitle: ویژگی‌های نمایش
type: docs
weight: 80
url: /fa/net/presentation-view-properties/
keywords:
- ویژگی‌های نمای
- نمای عادی
- محتوای نمای کلی
- نمادهای نمای کلی
- چسباندن تقسیم‌کننده عمودی
- نمای تک
- وضعیت نوار
- اندازه بعدی
- تنظیم خودکار
- زوم پیش‌فرض
- PowerPoint
- OpenDocument
- ارائه
- .NET
- C#
- Aspose.Slides
description: "از Aspose.Slides برای .NET جهت پیکربندی چیدمان نمای عادی، زوم اسلاید و یادداشت‌ها، فاصله‌گذاری شبکه و قابلیت نمایش نظرات در ارائه‌های PowerPoint استفاده کنید."
---
## **مقدمه**

در نمای عادی PowerPoint، اسلاید بین یک پنل جانبی برای تصویرهای کوچک یا یک خط‌مطالعۀ کلی و یک پنل یادداشت‌ها در پایین نمایش داده می‌شود. Aspose.Slides برای .NET ترجیحات ذخیره‌شدهٔ ویرایشی ارائه را از طریق [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) نمایان می‌کند. این تنظیمات شامل طرح پنل، سطوح زوم، فاصله‌گذاری شبکه و نمایش نظرات می‌باشند.

## **درباره INormalViewProperties**

از [NormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/normalviewproperties/) برای دسترسی به رابط [INormalViewProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/) استفاده کنید. [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) تعیین می‌کند که آیا نمادها کنار عناوین اسلایدها در خط‌مطالعۀ کلی ظاهر شوند یا خیر. [SnapVerticalSplitter](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/snapverticalsplitter/) به پنل جانبی اجازه می‌دهد هنگام باریک شدن توسط کاربر به وضعیت به‌حداقل‌اش بچسبد. [PreferSingleView](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/prefersingleview/) نشان‌دهندهٔ ترجیح برای نمایش یک پنل در کل پنجره است.

[VerticalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/verticalbarstate/) تقسیم‌کننده بین پنل جانبی و اسلاید را کنترل می‌کند. [HorizontalBarState](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/horizontalbarstate/) تقسیم‌کننده بالای پنل یادداشت‌ها را کنترل می‌کند. هر دو مقدار از نوع [SplitterBarStateType](https://reference.aspose.com/slides/net/aspose.slides/splitterbarstatetype/) را می‌پذیرند: `Minimized`، `Maximized` یا `Restored`.

## **درباره بازگرداندن INormalViewProperties**

هنگامی که یک تقسیم‌کننده بازگردانده می‌شود، [RestoredLeft](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredleft/) اندازهٔ ذخیره‌شدهٔ پنل جانبی و [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) اندازهٔ ذخیره‌شدهٔ ناحیهٔ بالایی اسلاید را فراهم می‌کند. هر دو [INormalViewRestoredProperties](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/) را باز می‌نمایند. ویژگی [DimensionSize](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/dimensionsize/) درصدی بین 0 تا 100 می‌پذیرد و [AutoAdjust](https://reference.aspose.com/slides/net/aspose.slides/inormalviewrestoredproperties/autoadjust/) تعیین می‌کند که آیا ویرایشگر هنگام تغییر اندازهٔ پنجره اندازه را تنظیم کند یا نه.

این مثال یک ارائهٔ موجود را به‌روزرسانی می‌کند. تقسیم‌کنندهٔ افقی را بازگردانی می‌کند، [RestoredTop](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/restoredtop/) را به 80٪ تنظیم می‌کند و تنظیم خودکار را فعال می‌سازد، و تقسیم‌کنندهٔ عمودی را به حداکثر می‌رساند. همچنین [ShowOutlineIcons](https://reference.aspose.com/slides/net/aspose.slides/inormalviewproperties/showoutlineicons/) را برای نمای خط‌مطالعە فعال می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var normalView = presentation.ViewProperties.NormalViewProperties;
normalView.HorizontalBarState = SplitterBarStateType.Restored;
normalView.VerticalBarState = SplitterBarStateType.Maximized;
normalView.RestoredTop.AutoAdjust = true;
normalView.RestoredTop.DimensionSize = 80;
normalView.ShowOutlineIcons = true;

presentation.Save("presentation_normal_view_state.pptx", SaveFormat.Pptx);
```

## **تنظیم مقدار پیش‌فرض زوم**

[SlideViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/slideviewproperties/) و [NotesViewProperties](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/notesviewproperties/) تنظیمات زوم مستقل برای ویرایشگر ذخیره می‌کنند. این تنظیمات بر ابعاد اسلاید، پخش اسلایدشو یا وضوح خروجی تصویر تأثیر نمی‌گذارند.

این مثال یک ارائهٔ موجود را باز می‌کند و [VariableScale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/variablescale/) را برای مقیاس‌گذاری متغیر فعال می‌سازد تا اسلاید با پنجرهٔ ویرایشی وفق پیدا کند. برای صفحهٔ یادداشت‌ها، مقیاس‌گذاری خودکار را غیرفعال می‌کند و [Scale](https://reference.aspose.com/slides/net/aspose.slides/icommonslideviewproperties/scale/) را به زوم ثابت 80٪ تنظیم می‌کند.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
viewProperties.SlideViewProperties.VariableScale = true;
viewProperties.NotesViewProperties.VariableScale = false;
viewProperties.NotesViewProperties.Scale = 80;

presentation.Save("zoom.pptx", SaveFormat.Pptx);
```

## **تنظیم فاصله‌گذاری شبکه**

[GridSpacing](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/gridspacing/) فاصلهٔ بین خطوط شبکهٔ ویرایشی سرتاسر ارائه را تنظیم می‌کند. مقدار مثبت این ویژگی بر پایهٔ نقاط است، به‌طوری که 72 نقطه معادل یک اینچ است. این مثال فاصلهٔ کنونی را در یک ارائهٔ موجود چاپ می‌کند و یک شبکهٔ یک‌چهارم اینچی را با تنظیم فواصل به 18 نقطه ذخیره می‌کند.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("demo.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current grid spacing: {viewProperties.GridSpacing} points");

viewProperties.GridSpacing = 18f;
presentation.Save("grid-spacing.pptx", SaveFormat.Pptx);
```

شبکه در فواصل ثابت تکرار می‌شود. [راهنماهای رسم](/slides/fa/net/drawing-guides/) موقعیت‌های افقی یا عمودی جداگانه‌ای را علامت‌گذاری می‌کنند. هر دو ابزار کمکی ویرایشی هستند و فقط در ویرایشگرهایی که آن‌ها را نمایش می‌دهند ظاهر می‌شوند. اسلایدشوها و خروجی‌های PDF، تصویر یا SVG این راهنماها را حذف می‌کنند.

## **نمایش یا مخفی‌سازی نظرات هنگام باز کردن ارائه**

[ShowComments](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/showcomments/) ترجیحی را ذخیره می‌کند که ویرایشگرهای سازگار هنگام باز کردن ارائه از آن استفاده می‌کنند. برای یک ارائهٔ موجود با نظرات، این مثال تنظیم فعلی را چاپ می‌کند و یک نسخهٔ کپی با نظرات مخفی شده ذخیره می‌کند. همچنین [LastView](https://reference.aspose.com/slides/net/aspose.slides/iviewproperties/lastview/) را به [ViewType.SlideView](https://reference.aspose.com/slides/net/aspose.slides/viewtype/) تنظیم می‌کند تا نسخهٔ کپی در نمای اسلاید باز شود.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("comments.pptx");

var viewProperties = presentation.ViewProperties;
Console.WriteLine($"Current comment visibility: {viewProperties.ShowComments}");

viewProperties.ShowComments = NullableBool.False;
viewProperties.LastView = ViewType.SlideView;
presentation.Save("comments-hidden.pptx", SaveFormat.Pptx);
```

پنهان‌سازی نظرات متن، نویسندگان، موقعیت‌ها، پاسخ‌ها و وضعیت‌های آن‌ها را حفظ می‌کند. برای تغییر خود نظرات، به [Presentation Comments](/slides/fa/net/presentation-comments/) مراجعه کنید. تنظیمات خروجی تعیین می‌کند که آیا نظرات در PDF، HTML، تصاویر، یادداشت‌ها یا جزوه‌ها ظاهر شوند یا نه.

## **سوالات متداول**

**چرا شبکه هنگام بازگشت به ارائه پنهان می‌شود؟**  
ارائه فاصلهٔ شبکه را ذخیره می‌کند. برای مشاهدهٔ شبکه، قابلیت نمایش شبکه را در ویرایشگر فعال کنید.

**آیا پاک‌سازی راهنماهای رسم فاصلهٔ شبکه را تغییر می‌دهد؟**  
خیر. افزودن، جابه‌جایی یا پاک‌سازی یک راهنما، فاصلهٔ شبکه را تغییر نمی‌دهد.

**آیا بخش‌های مختلف یک ارائه می‌توانند تنظیمات نمای متفاوتی داشته باشند؟**  
خیر. [Presentation.ViewProperties](https://reference.aspose.com/slides/net/aspose.slides/presentation/viewproperties/) برای کل ارائه اعمال می‌شود.

**آیا می‌توان تنظیمات نمای متفاوتی را برای کاربران مختلف ذخیره کرد؟**  
فایل تنها یک مجموعهٔ تنظیمات نمای را برای همه ذخیره می‌کند. ویرایشگر ممکن است ترجیحات محلی کاربر را نیز اعمال کند.

**آیا می‌توان تنظیمات نمای را در یک الگو ذخیره کرد؟**  
بله. ارائه‌های ایجاد شده از الگو، تنظیمات نمای ذخیره‌شدهٔ آن الگو را به ارث می‌برند.