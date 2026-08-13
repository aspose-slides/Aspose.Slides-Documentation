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
- ذخیره PPT به عنوان DOCX
- ذخیره PPTX به عنوان DOCX
- استخراج PPT به DOCX
- استخراج PPTX به DOCX
- C++
- Aspose.Slides
description: "تبدیل اسلایدهای PowerPoint (PPT و PPTX) به اسناد Word قابل ویرایش در C++ با استفاده از Aspose.Slides به صورت دقیق با حفظ چینش، تصاویر و قالب‌بندی."
---
## **مقدمه**

اگر قصد دارید محتوای متنی یا اطلاعاتی از یک ارائه (PPT یا PPTX) را به روش‌های جدید استفاده کنید، می‌توانید از تبدیل ارائه به Word (DOC یا DOCX) بهره‌مند شوید. 

* در مقایسه با Microsoft PowerPoint، برنامه Microsoft Word ابزارها یا قابلیت‌های بیشتری برای محتوای متنی دارد. 
* علاوه بر عملکردهای ویرایشی در Word، می‌توانید از قابلیت‌های پیشرفته همکاری، چاپ و اشتراک‌گذاری نیز بهره‌مند شوید. 

{{% alert color="info" %}} 

ممکن است بخواهید [**مبدل آنلاین ارائه به Word**](https://products.aspose.app/slides/fa/conversion/ppt-to-word) ما را امتحان کنید تا ببینید چه مزایایی می‌توانید از کار با محتوای متنی اسلایدها بدست آورید. 

{{% /alert %}} 

## **Aspose.Slides و Aspose.Words**

برای تبدیل یک فایل PowerPoint (PPTX یا PPT) به Word (DOCX یا DOCX)، به هر دو [Aspose.Slides for C++](https://products.aspose.com/slides/fa/cpp/) و [Aspose.Words for C++](https://products.aspose.com/words/cpp/) نیاز دارید.

به عنوان یک API مستقل، [Aspose.Slides](https://products.aspose.app/slides) برای C++ توابعی فراهم می‌کند که به شما امکان استخراج متن‌ها از ارائه‌ها را می‌دهد. 

[Aspose.Words](https://docs.aspose.com/words/cpp/) یک API پیشرفته پردازش اسناد است که به برنامه‌ها اجازه می‌دهد فایل‌ها را تولید، ویرایش، تبدیل، رندر، چاپ کنند و کارهای دیگر را با اسناد انجام دهند بدون اینکه به Microsoft Word نیاز داشته باشند.

## **تبدیل یک ارائه PowerPoint به یک سند Word**

از این کد برای تبدیل PowerPoint به Word استفاده کنید:

```cpp
#include <Aspose.Words.Cpp/BreakType.h>
#include <Aspose.Words.Cpp/Document.h>
#include <Aspose.Words.Cpp/DocumentBuilder.h>
#include <DOM/AutoShape.h>
#include <DOM/IShape.h>
#include <DOM/IShapeCollection.h>
#include <DOM/ISlide.h>
#include <DOM/ISlideCollection.h>
#include <DOM/ITextFrame.h>
#include <DOM/Presentation.h>
#include <IImage.h>
#include <ImageFormat.h>
#include <system/io/memory_stream.h>
#include <system/object_ext.h>
using namespace Aspose::Slides;
using namespace System;

auto presentation = MakeObject<Presentation>(u"sample.pptx");

auto doc = MakeObject<Aspose::Words::Document>();
auto builder = MakeObject<Aspose::Words::DocumentBuilder>(doc);

for (const auto& slide : presentation->get_Slides())
{
    // یک تصویر اسلاید را به‌صورت جریان بایت آرایه ایجاد می‌کند
    auto image = slide->GetImage(1.0f, 1.0f);
    auto imageStream = MakeObject<System::IO::MemoryStream>();
    image->Save(imageStream, Aspose::Slides::ImageFormat::Png);
    image->Dispose();

    builder->InsertImage(imageStream->ToArray());

    // متن‌های اسلاید را وارد می‌کند
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

doc->Save(u"output.docx");
presentation->Dispose();
```

## **سوالات متداول**

### چه اجزایی لازم است نصب شوند تا بتوان ارائه‌های PowerPoint و OpenDocument را به اسناد Word تبدیل کرد؟

فقط کافی است بسته‌های مربوط به [Aspose.Slides for C++](https://releases.aspose.com/slides/fa/cpp/) و [Aspose.Words for C++](https://releases.aspose.com/words/cpp/) را به پروژه خود اضافه کنید. هر دو کتابخانه به عنوان API مستقل عمل می‌کنند و نیازی به نصب Microsoft Office ندارید.

### آیا تمام فرمت‌های ارائه PowerPoint و OpenDocument پشتیبانی می‌شوند؟

Aspose.Slides [از تمام فرمت‌های ارائه پشتیبانی می‌کند](/slides/fa/cpp/supported-file-formats/)، از جمله PPT، PPTX، ODP و سایر انواع فایل‌های رایج. این اطمینان می‌دهد که می‌توانید با ارائه‌های ایجاد شده در نسخه‌های مختلف Microsoft PowerPoint کار کنید.