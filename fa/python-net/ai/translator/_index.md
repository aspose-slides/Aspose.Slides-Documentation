---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/python-net/ai/translator/
keywords:
- مترجم ارائه هوش مصنوعی
- مترجم اسلاید هوش مصنوعی
- ویژگی مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های هدایت‌شده توسط هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل هوش مصنوعی
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Python ترجمه کنید. فایل‌های PPT، PPTX و ODP را در حالی که چیدمان حفظ می‌شود، بومی‌سازی کنید — سریع و مناسب برای توسعه‌دهندگان. امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌ای ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی ارائه می‌دهد – مانند [Presentation Translation API](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/) برای محتوای چندزبانه اسلایدها.

## **چگونه کار می‌کند**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی ندارد ولی با مدل‌های هوش مصنوعی خارجی از طریق اینترنت ادغام می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/slidesaiagent/) در دسترس است که از زیرکلاس‌های [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

شما می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) داخلی برای اتصال به API اوپن‌ای‌آی استفاده کنید یا [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) خود را پیاده‌سازی کنید تا از ارائه‌دهنده یا مدل زبانی متفاوتی استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌نماید و به‌صورت هوشمند محتوی ترجمه‌شده را درج می‌کند در حالی که چیدمان و قالب‌بندی اصلی اسلاید حفظ می‌شود.

{{% alert color="info" %}}
توجه داشته باشید که API اوپن‌ای‌آی یک سرویس پرداختی است، لذا برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) باید یک حساب کاربری بسازید و کلید API خود را ارائه دهید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) داخلی و یک [model](https://platform.openai.com/docs/models) مشخص اوپن‌ای‌آی به زبان ژاپنی ترجمه می‌کنیم.

```py
import aspose.slides as slides

# یک ارائه را برای ترجمه بارگذاری کنید.
with slides.Presentation("sample.pptx") as presentation:

    # یک مشتری هوش مصنوعی با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # SlidesAIAgent را با مشتری هوش مصنوعی مقداردهی اولیه کنید.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # ارائه را به زبان ژاپنی ترجمه کنید.
        ai_agent.translate(presentation, "japanese")

        # ارائه ترجمه‌شده را به صورت PDF ذخیره کنید.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

### **مثال Azure OpenAI**

از نسخه **26.7.0**، Aspose.Slides برای Python از طریق .NET از ارائه‌دهندگان سازگار با OpenAI، از جمله Azure OpenAI، پشتیبانی می‌کند. می‌توانید مترجم را طوری تنظیم کنید که از استقرار داخلی Azure شما با استفاده از [OpenAICompatibleWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaicompatiblewebclient/) استفاده کند.

```py
import aspose.slides as slides

model = "your-azure-deployment-name"
api_key = "your-azure-api-key"
base_url = "https://your-resource.openai.azure.com/openai/v1/"

with slides.ai.OpenAICompatibleWebClient(model, api_key, base_url) as ai_web_client:
    ai_agent = slides.ai.SlidesAIAgent(ai_web_client)
    with slides.Presentation("Presentation.pptx") as presentation:
        ai_agent.translate(presentation, "spanish")
        presentation.save("Translated.pptx", slides.export.SaveFormat.PPTX)
```

این قسمت کد نشان می‌دهد که چگونه یک ارائه را با استفاده از نقطه پایان Azure OpenAI شما ترجمه کنید. مقادیر جایگزین را با نام استقرار، کلید API و URL نقطه پایان خود عوض کنید.

## **مزایای کلیدی**

Aspose.Slides [Presentation Translation API](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/) یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه PowerPoint چندزبانه ارائه می‌دهد. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان صرفه‌جویی می‌کند و نسبت به روش‌های دستی خطاها را به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا حرفه‌ای کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و محلی‌سازی‌شده برای مخاطبان جهانی ایجاد کنید – دامنهٔ دسترسی‌تان را گسترش داده و ارتباطاتتان را بهبود می‌بخشد.