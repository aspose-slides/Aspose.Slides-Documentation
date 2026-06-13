---
title: تبدیل ارائه‌های PowerPoint به اسناد Word در C++
linktitle: PowerPoint به Word
type: docs
weight: 110
url: /fa/cpp/convert-powerpoint-to-word/
keywords:
- تبدیل PowerPoint
- تبدیل ارائه
- تبدیل اسلاید
- تبدیل PPT
- تبدیل PPTX
- PowerPoint به Word
- ارائه به Word
- اسلاید به Word
- PPT به Word
- PPTX به Word
- PowerPoint به DOCX
- ارائه به DOCX
- اسلاید به DOCX
- PPT به DOCX
- PPTX به DOCX
- PowerPoint به DOC
- ارائه به DOC
- اسلاید به DOC
- PPT به DOC
- PPTX به DOC
- ذخیره PPT به صورت DOCX
- ذخیره PPTX به صورت DOCX
- صدور PPT به DOCX
- صدور PPTX به DOCX
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint PPT و PPTX به اسناد Word قابل ویرایش در C++ با استفاده از Aspose.Slides به‌صورت دقیق با حفظ چیدمان، تصاویر و قالب‌بندی."
---
## **معرفی**

اگر قصد دارید محتوا یا اطلاعات متنی یک ارائه (PPT یا PPTX) را به طرق جدید استفاده کنید، ممکن است از تبدیل ارائه به Word (DOC یا DOCX) سود ببرید. 

* در مقایسه با Microsoft PowerPoint، برنامه Microsoft Word ابزارها یا قابلیت‌های بیشتری برای محتوا دارد. 
* علاوه بر عملکردهای ویرایشی در Word، می‌توانید از ویژگی‌های پیشرفته همکاری، چاپ و به اشتراک‌گذاری نیز بهره‌مند شوید. 

{{% alert color="primary" %}} 

ممکن است بخواهید [**مبدل آنلاین ارائه به Word**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) را امتحان کنید تا ببینید با کار با محتوای متنی اسلایدها چه مزایایی می‌توانید کسب کنید. 

{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

برای تبدیل فایل PowerPoint (PPTX یا PPT) به Word (DOC یا DOCX)، به هر دو [Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/) و [Aspose.Words for C++](https://products.aspose.com/words/cpp/) نیاز دارید.

به‌ عنوان یک API مستقل، [Aspose.Slides](https://products.aspose.app/slides) برای C++ توابعی را فراهم می‌کند که به شما امکان استخراج متن از ارائه‌ها را می‌دهد. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) یک API پیشرفته پردازش اسناد است که به برنامه‌ها اجازه می‌دهد فایل‌ها را تولید، ویرایش، تبدیل، رندر، چاپ کرده و وظایف دیگر را بر روی اسناد انجام دهند بدون استفاده از Microsoft Word.

## **تبدیل ارائه PowerPoint به یک سند Word**

از این قطعه کد برای تبدیل PowerPoint به Word استفاده کنید:

```cpp
auto presentation = MakeObject<Presentation>();
auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // تصویر اسلاید را تولید و درج می‌کند
    auto image = slide->GetImage(1.0f, 1.0f);
    builder->InsertImage(image);

    // متن‌های اسلاید را درج می‌کند
    for (const auto& shape : slide->get_Shapes())
    {
        if (ObjectExt::Is<AutoShape>(shape))
        {
            auto autoShape = System::AsCast<AutoShape>(shape);
            builder->Writeln(autoShape->get_TextFrame()->get_Text());
        }
    }

    builder->InsertBreak(Aspose::Words::BreakType::PageBreak);
}
```

## **سؤالات متداول**

**برای تبدیل ارائه‌های PowerPoint و OpenDocument به اسناد Word، چه اجزائی باید نصب شوند؟**

فقط کافی است بسته‌های مربوط به [Aspose.Slides for C++](https://releases.aspose.com/slides/fa/cpp/) و [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) را به پروژه خود اضافه کنید. هر دو کتابخانه به‌عنوان API‌های مستقل عمل می‌کنند و نیازی به نصب Microsoft Office نیست.

**آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟**

Aspose.Slides [تمام فرمت‌های ارائه را پشتیبانی می‌کند](/slides/fa/cpp/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر انواع فایل‌های رایج. این تضمین می‌کند که می‌توانید با ارائه‌های ایجاد شده در نسخه‌های مختلف Microsoft PowerPoint کار کنید.