---
title: مترجم ارائه مبتنی بر هوش مصنوعی
linktitle: مترجم مبتنی بر هوش مصنوعی
type: docs
weight: 20
url: /fa/python-net/ai/translator/
keywords:
- مترجم ارائه AI
- مترجم اسلاید AI
- ویژگی مبتنی بر هوش مصنوعی
- ارائه چندزبانه
- اسلاید چندزبانه
- ترجمه ارائه
- ترجمه اسلاید
- ویژگی‌های مبتنی بر هوش مصنوعی
- قابلیت‌های هوش مصنوعی
- عامل AI
- کلاینت وب
- PowerPoint
- OpenDocument
- ارائه
- Python
- Aspose.Slides
description: "اسلایدهای PowerPoint را با هوش مصنوعی با استفاده از Aspose.Slides برای Python ترجمه کنید. PPT، PPTX و ODP را محلی‌سازی کنید در حالی که چیدمان حفظ می‌شود—سرعت بالا و مناسب برای توسعه‌دهندگان. آن را امتحان کنید."
---
## **مقدمه**

Aspose.Slides یک API قدرتمند برای مدیریت برنامه‌نویسی ارائه‌های PowerPoint است. علاوه بر ایجاد، ویرایش و تبدیل اسلایدها، ویژگی‌های مبتنی بر هوش مصنوعی را ارائه می‌دهد - مانند [API ترجمه ارائه](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/) برای محتوای اسلایدهای چندزبانه.

## **چگونه کار می‌کند**

Aspose.Slides قابلیت‌های هوش مصنوعی داخلی را شامل نمی‌شود اما با مدل‌های هوش مصنوعی خارجی از طریق اینترنت یکپارچه می‌شود. این عملکرد از طریق کلاس [SlidesAIAgent](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/slidesaiagent/) در دسترس است که از زیر کلاس‌های [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) برای ارتباط با سرویس‌های هوش مصنوعی استفاده می‌کند.

می‌توانید از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) داخلی برای اتصال به API OpenAI استفاده کنید یا خودتان یک [IAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/iaiwebclient/) پیاده‌سازی کنید تا از یک ارائه‌دهنده هوش مصنوعی یا مدل زبانی متفاوت استفاده کنید.

Aspose.Slides ارتباطات را مدیریت می‌کند، پاسخ‌های هوش مصنوعی را تجزیه می‌نماید و به‌صورت هوشمند محتوای ترجمه‌شده را درج می‌کند در حالی که چیدمان و قالب‌بندی اصلی اسلاید را حفظ می‌کند.

{{% alert color="primary" %}}
توجه داشته باشید که API OpenAI یک سرویس پولی است، بنابراین برای استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) داخلی باید یک حساب کاربری ایجاد کنید و کلید API خود را تامین کنید.
{{% /alert %}}

## **مثال**

در این مثال، یک ارائه PowerPoint را به زبان ژاپنی با استفاده از [OpenAIWebClient](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/openaiwebclient/) داخلی و یک [مدل](https://platform.openai.com/docs/models) مشخص OpenAI ترجمه می‌کنیم.

```py
# یک ارائه برای ترجمه بارگذاری کنید.
with slides.Presentation("sample.pptx") as presentation:

    # یک کلاینت AI با OpenAIWebClient ایجاد کنید و مدل و کلید API خود را مشخص کنید.
    with slides.ai.OpenAIWebClient("gpt-4o-mini", "apiKey", "") as ai_web_client:

        # SlidesAIAgent را با کلاینت AI مقداردهی اولیه کنید.
        ai_agent = slides.ai.SlidesAIAgent(ai_web_client)

        # ارائه را به ژاپنی ترجمه کنید.
        ai_agent.translate(presentation, "japanese")

        # ارائه ترجمه‌شده را به عنوان PDF ذخیره کنید.
        presentation.save("sample_jp.pdf", slides.export.SaveFormat.PDF)
```

## **مزایای کلیدی**

Aspose.Slides [API ترجمه ارائه](https://reference.aspose.com/slides/fa/python-net/aspose.slides.ai/) یک راه‌حل مبتنی بر هوش مصنوعی برای ارائه‌های PowerPoint چندزبانه فراهم می‌کند. با خودکارسازی ترجمه در حالی که چیدمان و طراحی حفظ می‌شود، زمان را صرفه‌جویی می‌کند و خطاها را نسبت به جریان‌های کار دستی به حداقل می‌رساند. چه توسعه‌دهنده، معلم یا متخصص کسب‌وکار باشید، این API به شما امکان می‌دهد ارائه‌های جذاب و بومی‌شده برای مخاطبان جهانی ایجاد کنید - دسترسی خود را گسترش داده و ارتباط را بهبود بخشید.