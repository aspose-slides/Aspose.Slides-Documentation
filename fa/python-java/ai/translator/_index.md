---
title: مترجم ارائه‌ای مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/python-java/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ارائه چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- PowerPoint
- OpenDocument
- Python
- Aspose.Slides
description: "ارائه‌ها را با هوش مصنوعی با استفاده از Aspose.Slides برای Python از طریق Java ترجمه کنید. متن اسلایدها را بومی‌سازی کنید و ارائه ترجمه‌شده را به‌عنوان PowerPoint یا PDF ذخیره کنید."
---
## **مقدمه**

Aspose.Slides برای Python از طریق Java یک API ترجمه هوش مصنوعی ارائه می‌دهد که برای بومی‌سازی محتوای اسلایدها استفاده می‌شود. یک ارائه موجود را به زبان مورد نظر ترجمه کنید و سپس نسخه ترجمه‌شده را در قالبی که مخاطبان شما نیاز دارند ذخیره کنید.

## **نحوه کار**

[SlidesAIAgent](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesaiagent/) با یک سرویس هوش مصنوعی خارجی از طریق یک کلاینت هوش مصنوعی ارتباط برقرار می‌کند. مثال‌ها از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/openaiwebclient/) داخلی استفاده می‌کنند.

[SlidesAIAgent.translate](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesaiagent/#translate) ارائه‌ای که به آن پاس داده می‌شود را به‌روزرسانی می‌کند. Aspose.Slides پاسخ‌های هوش مصنوعی را پردازش کرده و متن اسلایدها را جایگزین می‌کند در حالی که طرح‌بندی و قالب‌بندی موجود حفظ می‌شود. نتیجه را مرور کنید: ممکن است متن ترجمه‌شده طولانی‌تر از متن اصلی باشد و نیاز به تنظیمات طرح داشته باشد.

## **پیش‌نیازها**

[Installation](/slides/fa/python-java/installation/) را دنبال کنید تا کتابخانه و زمان اجرای آن را پیکربندی کنید. قبل از اجرای مثال‌ها متغیرهای محیطی `OPENAI_API_KEY` و `OPENAI_MODEL` را تنظیم کنید. مدلی را انتخاب کنید که توسط کلاینت داخلی پشتیبانی می‌شود و برای حساب API شما در دسترس است.

{{% alert color="info" title="Note" %}}
ترجمه برای انجام نیاز به اتصال به اینترنت دارد و متن ارائه را به سرویس هوش مصنوعی پیکربندی‌شده ارسال می‌کند. دسترسی به API و هزینه‌های استفاده آن جدا از مجوز Aspose.Slides شما هستند.
{{% /alert %}}

مثال‌ها یک JVM فعال را مجدداً استفاده می‌کنند یا در صورت نیاز آن را راه‌اندازی می‌کنند. برای استفاده در نوت‌بوک‌ها به [JVM lifecycle guidance](/slides/fa/python-java/limitations-and-api-differences/#import-the-library) مراجعه کنید.

## **ترجمه یک ارائه**

فایل `sample.pptx` را در پوشهٔ کاری قرار دهید. این مثال آن را با [Presentation](https://reference.aspose.com/slides/fa/python-java/aspose.slides/presentation/) بارگذاری می‌کند، متن آن را به ژاپنی ترجمه می‌کند و نتیجه را به عنوان PDF ذخیره می‌نماید. حتی اگر عملیاتی با خطا مواجه شود نیز ارائه را آزاد کرده و کلاینت هوش مصنوعی را می‌بندد.

```python
import os
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
ai_client = OpenAIWebClient(model, api_key, None)
try:
    presentation = Presentation("sample.pptx")
    try:
        ai_agent = SlidesAIAgent(ai_client)
        ai_agent.translate(presentation, "Japanese")
        presentation.save("sample_ja.pdf", SaveFormat.Pdf)
    finally:
        presentation.dispose()
finally:
    ai_client.close()
```

## **پیکربندی اتصال HTTP**

به‌صورت پیش‌فرض، [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-java/aspose.slides/openaiwebclient/) اتصال HTTP خود را به‌صورت داخلی مدیریت می‌کند. سازندهٔ چهار آرگومان آن همچنین یک [HttpURLConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/HttpURLConnection.html) مدیریت‌شدهٔ خارجی جاوا را می‌پذیرد. زمانی که نیاز به پیکربندی پروکسی یا زمان‌سپری اتصال دارید از این بارگذاری استفاده کنید.

مثال زیر یک پروکسی HTTP جاوا را با [Proxy](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/Proxy.html) ایجاد می‌کند و یک اتصال را از طریق [URL.openConnection](https://docs.oracle.com/en/java/javase/17/docs/api/java.base/java/net/URL.html#openConnection(java.net.Proxy)) باز می‌کند. `proxy.example.com` و پورت را با تنظیمات پروکسی خود جایگزین کنید. این اتصال به‌صورت مستقیم از طریق JPype عبور می‌کند؛ یک نشست HTTP پایتون نمی‌تواند به‌جای آن استفاده شود.

```python
import os
import jpype
import jpype.imports
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from java.net import InetSocketAddress, Proxy, URL
from asposeslides.api import OpenAIWebClient, Presentation, SaveFormat, SlidesAIAgent

model = os.environ["OPENAI_MODEL"]
api_key = os.environ["OPENAI_API_KEY"]
proxy_address = InetSocketAddress("proxy.example.com", 8080)
proxy = Proxy(Proxy.Type.HTTP, proxy_address)
endpoint = URL("https://api.openai.com/v1/chat/completions")
connection = endpoint.openConnection(proxy)
try:
    connection.setConnectTimeout(30000)
    connection.setReadTimeout(60000)
    ai_client = OpenAIWebClient(model, api_key, None, connection)
    try:
        presentation = Presentation("sample.pptx")
        try:
            ai_agent = SlidesAIAgent(ai_client)
            ai_agent.translate(presentation, "Japanese")
            presentation.save("sample_ja.pptx", SaveFormat.Pptx)
        finally:
            presentation.dispose()
    finally:
        ai_client.close()
finally:
    connection.disconnect()
```

## **مزایای کلیدی**

ترجمه خودکار به تهیهٔ مواد آموزشی چند زبانه، ارائه‌های محصول و گزارش‌های مشتری کمک می‌کند در حالی که طراحی موجود اسلایدها را بازاستفاده می‌کند. یک ارائهٔ قابل ویرایش را برای بررسی‌های بعدی ذخیره کنید یا برای توزیع یک PDF صادر کنید.

## **پرسش‌های متداول**

**آیا ترجمه یک شی ارائه جداگانه ایجاد می‌کند؟**

خیر. [SlidesAIAgent.translate](https://reference.aspose.com/slides/fa/python-java/aspose.slides/slidesaiagent/#translate) ارائهٔ داده‌شده را اصلاح می‌کند. برای حفظ فایل اصلی آن را با نام فایل جدیدی ذخیره کنید.

**چگونه زبان هدف را مشخص کنم؟**

نام زبان را به‌عنوان آرگومان دوم پاس دهید، مانند `"Japanese"` یا `"Spanish"`. کیفیت ترجمه و پوشش زبانی به مدل انتخاب‌شده بستگی دارد.

**آیا می‌توانم بدون استفاده از پروکسی ترجمه کنم؟**

بله. از سازندهٔ کلاینت سه‌آرگومانی که در مثال اول نشان داده شده استفاده کنید. مثال اتصال سفارشی فقط زمانی لازم است که برنامهٔ شما به تنظیمات صریح اتصال نیاز داشته باشد.