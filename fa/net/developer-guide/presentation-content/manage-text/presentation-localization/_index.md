---
title: اتوماسیون بومی‌سازی ارائه در .NET
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/net/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- سرکوب بررسی املایی
- زبان اثبات
- شناسهٔ زبان
- متن چندزبانه
- PowerPoint
- ارائه
- .NET
- C#
- Aspose.Slides
description: "زبان‌های اثباتی را برای متن ارائه‌های PowerPoint و OpenDocument در .NET با Aspose.Slides تنظیم کنید، شامل پیش‌فرض‌ها و پاراگراف‌های چندزبانه."
---
## **بررسی کلی**

Aspose.Slides for .NET به شما امکان می‌دهد متادادهٔ اثبات نوشتار را برای بخش‌های متنی جداگانه پیکربندی کنید. برای شناسایی زبان اثبات از [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) استفاده کنید، برای فعال یا غیرفعال کردن بررسی املایی از [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/spellcheck/) و برای کنترل حالت گستردهٔ «بدون اثبات» از [BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/proofdisabled/) استفاده کنید. از آنجا که این تنظیمات در سطح بخش اعمال می‌شوند، یک پاراگراف می‌تواند شامل چندین زبان و قوانین اثبات متفاوت باشد.

این مقاله توضیح می‌دهد چگونه یک زبان را به متن خاصی اختصاص دهید، زبان پیش‌فرض برای متن‌های جدید را با [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و تنظیمات موردنظر را هنگام استفاده از [Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/joinportionswithsameformatting/) حفظ کنید. این ویژگی‌ها متاداده‌ای برای برنامه‌های ارائه ذخیره می‌کنند؛ آن‌ها متن را ترجمه نمی‌کنند، بررسی املایی مبتنی بر واژه‌نامه انجام نمی‌دهند و کلمات غلط املایی را بر نمی‌گردانند.

## **تنظیم زبان اثبات برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/) را ایجاد یا بارگذاری کنید، به بخش متنی مورد نیاز از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/portionformat/) دسترسی پیدا کنید و شناسهٔ زبان آن را اختصاص دهید. مثال زیر یک شکل ایجاد می‌کند، انگلیسی بریتانیایی را به عنوان زبان اثبات تنظیم می‌کند و نتیجه را با [Presentation.Save](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/save/) ذخیره می‌نماید:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Set the proofing language for this text.";

var portion = shape.TextFrame.Paragraphs[0].Portions[0];
portion.PortionFormat.LanguageId = "en-GB";

presentation.Save("proofing_language.pptx", SaveFormat.Pptx);
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) برای تعیین زبان اثباتی که Aspose.Slides به متن‌های تازه ایجاد شده اختصاص می‌دهد، استفاده کنید. این تنظیم زمانی مفید است که اکثر یا تمام متن‌های جدید در یک ارائه از یک زبان استفاده کنند. این تنظیم متادادهٔ زبانی متن‌هایی که قبلاً یک زبان صریح داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه ایجاد می‌کند که متن جدید آن از قواعد اثبات آلمانی استفاده می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

var loadOptions = new LoadOptions
{
    DefaultTextLanguage = "de-DE"
};

using var presentation = new Presentation(loadOptions);
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
shape.TextFrame.Text = "Willkommen zur Präsentation";

presentation.Save("default_text_language.pptx", SaveFormat.Pptx);
```

## **استفاده از چند زبان در یک پاراگراف**

یک [IParagraph](https://reference.aspose.com/slides/fa/net/aspose.slides/iparagraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/net/aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به طور مستقل تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی ایجاد می‌کند:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
var paragraph = shape.TextFrame.Paragraphs[0];
paragraph.Portions.Clear();

var englishPortion = new Portion("Welcome");
englishPortion.PortionFormat.LanguageId = "en-US";
paragraph.Portions.Add(englishPortion);

var frenchPortion = new Portion(" — Bienvenue");
frenchPortion.PortionFormat.LanguageId = "fr-FR";
paragraph.Portions.Add(frenchPortion);

presentation.Save("multilingual_text.pptx", SaveFormat.Pptx);
```

## **فعال یا غیرفعال کردن بررسی املایی برای بخش‌های جداگانه**

[IPortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportionformat/) ویژگی‌های متنی عمومی تعریف‌شده توسط [IBasePortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/) را به ارث می‌برد. از طریق [IPortion.PortionFormat](https://reference.aspose.com/slides/fa/net/aspose.slides/iportion/portionformat/) به قالب یک بخش دسترسی پیدا کنید و [BasePortionFormat.SpellCheck](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/spellcheck/) را تنظیم کنید تا تعیین شود آیا برنامهٔ ارائه می‌تواند برای آن بخش املاء را بررسی کند یا خیر. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املایی را می‌دهد، در حالی که `false` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی جداگانه اعمال می‌شود. بنابراین بخش‌های مختلف در همان پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/languageid/) و `SpellCheck` مقاصد تکمیلی دارند: `LanguageId` زبان اثبات را شناسایی می‌کند، در حالی که `SpellCheck` تعیین می‌کند آیا بررسی املایی برای بخش مجاز است یا نه.

[BasePortionFormat.ProofDisabled](https://reference.aspose.com/slides/fa/net/aspose.slides/baseportionformat/proofdisabled/) نیز اثبات را کنترل می‌کند، اما وضعیت گستردهٔ «بدون اثبات» را به عنوان یک [NullableBool](https://reference.aspose.com/slides/fa/net/aspose.slides/nullablebool/) نشان می‌دهد. وقتی به یک کلید بولی مستقیم مخصوص بررسی املایی نیاز دارید، از `SpellCheck` استفاده کنید. وقتی نیاز به حفظ یا کنترل صریح متادادهٔ «بدون اثبات» ارائه دارید، شامل وضعیت `NotDefined`، از `ProofDisabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آن‌ها را سازگار نگه دارید؛ ترکیب `SpellCheck = true` با `ProofDisabled = NullableBool.True` مجاز نیست.

این ویژگی‌ها متادادهٔ اثباتی را که توسط PowerPoint و سایر برنامه‌های ارائه مورد استفاده قرار می‌گیرد، پیکربندی می‌کنند. Aspose.Slides از آن‌ها برای اجرای بررسی املایی مبتنی بر واژه‌نامه یا بازگرداندن لیستی از کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی ایجاد می‌کند، آن را بارگذاری می‌کند، تنظیمات مختلف بررسی املایی و زبان‌های اثبات را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، دوباره باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

const string inputFile = "spell_check_input.pptx";
const string outputFile = "spell_check_settings.pptx";

using (var sourcePresentation = new Presentation())
{
    var sourceSlide = sourcePresentation.Slides[0];
    var sourceShape = sourceSlide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    var sourceParagraph = sourceShape.TextFrame.Paragraphs[0];
    sourceParagraph.Portions.Clear();

    var sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.PortionFormat.LanguageId = "en-US";
    sourceParagraph.Portions.Add(sourceEnglishPortion);

    var sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.PortionFormat.LanguageId = "fr-FR";
    sourceParagraph.Portions.Add(sourceFrenchPortion);

    sourcePresentation.Save(inputFile, SaveFormat.Pptx);
}

using (var presentation = new Presentation(inputFile))
{
    var shape = (IAutoShape)presentation.Slides[0].Shapes[0];
    var portions = shape.TextFrame.Paragraphs[0].Portions;

    var checkedPortion = portions[0];
    checkedPortion.PortionFormat.LanguageId = "en-US";
    checkedPortion.PortionFormat.SpellCheck = true;

    var suppressedPortion = portions[1];
    suppressedPortion.PortionFormat.LanguageId = "fr-FR";
    suppressedPortion.PortionFormat.SpellCheck = false;

    presentation.Save(outputFile, SaveFormat.Pptx);
}

using var reopenedPresentation = new Presentation(outputFile);
var reopenedShape = (IAutoShape)reopenedPresentation.Slides[0].Shapes[0];
var storedPortions = reopenedShape.TextFrame.Paragraphs[0].Portions;

var firstPortionStored = storedPortions.Count == 2 &&
    storedPortions[0].PortionFormat.LanguageId == "en-US" &&
    storedPortions[0].PortionFormat.SpellCheck;

var secondPortionStored = storedPortions.Count == 2 &&
    storedPortions[1].PortionFormat.LanguageId == "fr-FR" &&
    !storedPortions[1].PortionFormat.SpellCheck;

if (firstPortionStored && secondPortionStored)
{
    Console.WriteLine("The proofing settings were stored correctly.");
}
else
{
    Console.WriteLine("The proofing settings could not be verified.");
}
```

[Presentation.JoinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/net/aspose.slides/presentation/joinportionswithsameformatting/) بخش‌های مجاور که قالب یکسان دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` باعث نگه داشتن بخش‌ها به صورت جداگانه نمی‌شود؛ پس از ترکیب، بخش حاصل مقدار `SpellCheck` بخش اول را حفظ می‌کند. اگر بخش‌ها به تنظیمات متفاوتی برای بررسی املایی نیاز دارند، قبل از اختصاص این تنظیمات، `JoinPortionsWithSameFormatting` را فراخوانی کنید یا مرزهای بخش ترکیبی را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌های دارای مقادیر متفاوت `LanguageId` به دلیل متفاوت بودن قالب زبان اثبات، جدا می‌مانند.

## **سؤالات متداول**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

خیر. [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) متادادهٔ اثباتی برای املاء و دستور زبان را ذخیره می‌کند؛ محتوای متن را تغییر نمی‌دهد. متن را جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان اثبات فونت‌ها، هیفن‌گذاری یا بسته‌بندی خطوط را کنترل می‌کند؟**

خیر. شناسهٔ زبان برای اثبات است. رندر متن و چیدمان عمدتاً به فونت‌های موجود [fonts](/slides/fa/net/powerpoint-fonts/)، سیستم نوشتاری و تنظیمات فریم متن وابسته‌اند. برای رندر قابل اعتماد، فونت‌های مورد نیاز را فراهم کنید، [font substitution](/slides/fa/net/font-substitution/) را پیکربندی کنید یا [embed fonts](/slides/fa/net/embedded-font/) را در ارائه گنجانید.

**آیا یک پاراگراف می‌تواند چندین زبان اثبات داشته باشد؟**

بله. همان‌طور که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به یک بخش جداگانه اختصاص دهید.

**کدامیک را باید استفاده کنم: `DefaultTextLanguage` یا `LanguageId`؟**

زمانی که می‌خواهید برای متن‌های تازه ایجاد شده پیش‌فرضی داشته باشید، از [LoadOptions.DefaultTextLanguage](https://reference.aspose.com/slides/fa/net/aspose.slides/loadoptions/defaulttextlanguage/) استفاده کنید. زمانی که یک بخش خاص به زبان اثبات صریح نیاز دارد یا پاراگرافی شامل چندین زبان است، از [IBasePortionFormat.LanguageId](https://reference.aspose.com/slides/fa/net/aspose.slides/ibaseportionformat/languageid/) استفاده کنید.