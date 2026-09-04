---
title: "ژنراتور اسلاید چندزبانه مبتنی بر هوش مصنوعی"
linktitle: "ژنراتور مبتنی بر هوش مصنوعی"
type: docs
weight: 40
url: /fa/python-java/ai/generator/
keywords:
- "ارائه چندزبانه"
- "اسلاید چندزبانه"
- "ژنراتور ارائه هوش مصنوعی"
- "ژنراتور اسلاید هوش مصنوعی"
- "قالب ارائه"
- "PowerPoint"
- "OpenDocument"
- "Python"
- "Aspose.Slides"
description: "ارائه‌های چندزبانه را از متن با Aspose.Slides برای Python از طریق Java تولید کنید. جزئیات محتوا را انتخاب کنید، یک قالب اعمال کنید و به PowerPoint یا PDF صادر کنید."
---
## **معرفی**

ژنراتور ارائه هوش مصنوعی در Aspose.Slides برای Python از طریق Java ارائه‌ها را از توصیفات موضوع، خلاصه‌ها، نقل‌قول‌ها یا موارد بولت ایجاد می‌کند. زبان مورد نیاز را در درخواست خود مشخص کنید، مقدار محتوا را انتخاب کنید و به‌صورت اختیاری یک قالب ارائه برای تعریف چیدمان و طراحی ارائه دهید.

ژنراتور محتوا را با استفاده از بلوک‌های متنی، فهرست‌های بولت و جداول سازماندهی می‌کند. این ابزار تصویر تولید نمی‌کند؛ می‌توانید پس از تولید، تصویرها را به ارائه اضافه کنید. قبل از به اشتراک‌گذاری ارائه، محتوا و چیدمان تولید شده را بررسی کنید.

## **نحوه کار**

[SlidesAIAgent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesaiagent/) از یک مشتری هوش مصنوعی برای ارتباط با یک مدل خارجی استفاده می‌کند. مثال‌های زیر از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/openaiwebclient/) داخلی استفاده می‌کنند. Aspose.Slides پاسخ‌های مدل را پردازش کرده و یک ارائه می‌سازد که می‌توانید ویرایش یا صادر کنید.

از [SlidesAIAgent.generatePresentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesaiagent/#generatePresentation) با یک توضیح متنی و یک مقدار [PresentationContentAmountType](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/) استفاده کنید. نسخه overload با آرگومان سوم یک ارائه را به‌عنوان قالب طراحی می‌پذیرد.

## **پیش‌نیازها**

برای پیکربندی Python، Java، JPype و Aspose.Slides، به [Installation](/slides/fa/python-java/installation/) مراجعه کنید. قبل از اجرای نمونه‌ها، متغیرهای محیطی `OPENAI_API_KEY` و `OPENAI_MODEL` را تنظیم کنید. مدلی را انتخاب کنید که توسط مشتری داخلی پشتیبانی می‌شود و در حساب API شما در دسترس است.

{{% alert color="info" title="Note" %}}
سرویس هوش مصنوعی به اتصال اینترنت و دسترسی جداگانه به API نیاز دارد. درخواست‌ها به سرویس پیکربندی شده ارسال می‌شوند و هزینه‌های استفاده آن به‌ طور مستقل از لایسنس Aspose.Slides شما اعمال می‌شود.
{{% /alert %}}

هر مثال تنها در صورتی که JVM در حال اجرا نباشد، آن را راه‌اندازی می‌کند و برای عملیات‌های بعدی در دسترس می‌گذارد. هنگام سازگار کردن کد برای دفترچه‌ها، به [JVM lifecycle guidance](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) مراجعه کنید.

## **ایجاد ارائه از متن**

این مثال یک ارائه به زبان انگلیسی با مقدار محتوا [Medium](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/#Medium) ایجاد می‌کند و آن را به صورت فایل PowerPoint ذخیره می‌نماید.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    instruction = "Generate an English presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
    presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Medium)
    try:
        presentation.save("generated.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **ایجاد ارائه با استفاده از قالب**

`masterPresentation.pptx` را در پوشهٔ کاری قرار دهید. این مثال آن را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری می‌کند، یک ارائه به زبان اسپانیایی با محتویات [Detailed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/#Detailed) ایجاد می‌سازد و به PDF صادر می‌گردد. هم قالب و هم ارائهٔ تولید شده آزاد می‌شوند، حتی اگر تولید یا ذخیره‌سازی با خطا مواجه شود.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, PresentationContentAmountType, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    ai_agent = SlidesAIAgent(ai_client)
    template = Presentation("masterPresentation.pptx")
    try:
        instruction = "Generate a Spanish presentation about Aspose.Slides for Python via Java, highlighting its capabilities and use cases."
        presentation = ai_agent.generatePresentation(instruction, PresentationContentAmountType.Detailed, template)
        try:
            presentation.save("generated.pdf", SaveFormat.Pdf)
        finally:
            presentation.dispose()
    finally:
        template.dispose()
finally:
    ai_client.close()
```

اگر نیاز به پیکربندی پروکسی یا زمان‌سنجی‌های اتصال دارید، به [Configure the HTTP Connection](/slides/fa/python-java/ai/translator/#configure-the-http-connection) مراجعه کنید. همچنین می‌توانید مشتری حاصل را به ژنراتور پاس دهید.

## **مزایای کلیدی**

ایجاد می‌تواند کار نوشتن اولیه برای مطالب آموزشی، مرورهای محصول، گزارش‌های مشتری و ارائه‌های داخلی را کاهش دهد. درخواست‌ها موضوع و زبان را کنترل می‌کنند، در حالی که یک قالب به شما امکان می‌دهد طراحی یک ارائه موجود را دوباره استفاده کنید.

## **پرسش‌های متداول**

**چگونه می‌توانم طول ارائه تولید شده را کنترل کنم؟**

[Brief](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/#Brief)، [Medium](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/#Medium) یا [Detailed](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentationcontentamounttype/#Detailed) را انتخاب کنید. این تنظیمات هم بر تعداد اسلایدها و هم جزئیات هر اسلاید تأثیر می‌گذارد؛ آنها شمارش دقیق اسلاید را مشخص نمی‌کنند.

**آیا می‌توانم اسلایدها را به زبان دیگری تولید کنم؟**

بله. زبان مورد نیاز را در توصیف متنی گنجانده باشید. نتیجه بستگی به توانمندی‌های زبانی مدلی دارد که انتخاب کرده‌اید.

**آیا می‌توانم هنگام خروجی به PDF نسخه‌ای قابل ویرایش نگه دارم؟**

بله. قبل از آزاد کردن ارائهٔ تولید شده، آن را به‌صورت PPTX نیز ذخیره کنید؛ همان رویکرد در اولین مثال نشان داده شده است.