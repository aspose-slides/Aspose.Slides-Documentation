---
title: "اتوماتیک‌سازی بومی‌سازی ارائه در جاوااسکریپت"
linktitle: "بومی‌سازی ارائه"
type: docs
weight: 100
url: /fa/nodejs-java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- سرکوب بررسی املایی
- زبان اثبات
- شناسه زبان
- متن چندزبانه
- PowerPoint
- ارائه
- Node.js
- جاوااسکریپت
- Aspose.Slides
description: "تنظیم زبان‌های اثبات برای متن ارائه PowerPoint و OpenDocument در جاوااسکریپت با Aspose.Slides، شامل پیش‌فرض‌ها و پاراگراف‌های چندزبانه."
---
## **مروری**

Aspose.Slides for Node.js via Java به شما امکان پیکربندی فرادادهٔ اثبات برای بخش‌های متنی جداگانه را می‌دهد. برای شناسایی زبان اثبات از [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) استفاده کنید، برای فعال یا غیرفعال کردن بررسی املایی از [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) و برای کنترل وضعیت کلی «بدون اثبات» از [BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) بهره ببرید. چون این تنظیمات در سطح بخش (Portion) اعمال می‌شوند، یک پاراگراف می‌تواند شامل چند زبان و قوانین اثبات متفاوت باشد.

این مقاله توضیح می‌دهد که چگونه یک زبان را به متن خاصی اختصاص دهید، زبان پیش‌فرض را برای متن جدید با [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و تنظیمات موردنظر را هنگام استفاده از [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) حفظ کنید. این ویژگی‌ها فرادادهٔ اثبات را برای برنامه‌های ارائه ذخیره می‌کنند؛ آنها متن را ترجمه نمی‌کنند، بررسی املایی مبتنی بر واژه‌نامه انجام نمی‌دهند و کلمات غلط املایی را برنمی‌گردانند.

## **تنظیم زبان اثبات برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/) ایجاد یا بارگذاری کنید، بخش متنی موردنظر را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getPortionFormat--) دریافت کنید و شناسهٔ زبان آن را اختصاص دهید. مثال زیر یک شکل می‌سازد، زبان انگلیسی بریتانیایی را به عنوان زبان اثبات تنظیم می‌کند و نتیجه را با [Presentation.save](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌نماید:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    const portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

برای تعیین زبان اثباری که Aspose.Slides به متن تازه ایجاد شده اختصاص می‌دهد، از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) استفاده کنید. این تنظیم زمانی مفید است که بیشتر یا تمام متن‌های جدید در یک ارائه از یک زبان استفاده کنند. این تنظیم متادیتای زبانی متونی که قبلاً شناسهٔ زبان صریح داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه می‌سازد که متن جدید آن از قوانین اثبات آلمانی استفاده می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const loadOptions = new aspose.slides.LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

const presentation = new aspose.slides.Presentation(loadOptions);
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده از زبان‌های متعدد در یک پاراگراف**

یک [Paragraph](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/paragraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به‌صورت مستقل تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی می‌سازد:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const presentation = new aspose.slides.Presentation();
try {
    const slide = presentation.getSlides().get_Item(0);
    const shape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    const englishPortion = new aspose.slides.Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    const frenchPortion = new aspose.slides.Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فعال یا غیرفعال کردن بررسی املایی برای بخش‌های جداگانه**

[PortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portionformat/) ویژگی‌های متنی عمومی تعریف‌شده توسط [BasePortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/) را به ارث می‌برد. قالب یک بخش را از طریق [Portion.getPortionFormat](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/portion/#getPortionFormat--) دریافت کنید و با استفاده از [BasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setSpellCheck-boolean-) کنترل کنید که آیا برنامهٔ ارائه می‌تواند املای آن بخش را بررسی کند یا نه. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املایی را می‌دهد، در حالی که `false` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی جداگانه اعمال می‌شود. بنابراین بخش‌های مختلف در یک پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) و `setSpellCheck` مقاصد تکمیلی دارند: `setLanguageId` زبان اثبات را شناسایی می‌کند، در حالی که `setSpellCheck` تعیین می‌کند آیا بررسی املایی برای بخش مجاز است یا نه.

[BasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setProofDisabled-byte-) نیز بر اثبات اثر می‌گذارد، اما وضعیت گسترده‌تر «بدون اثبات» را به‌صورت یک [NullableBool](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/nullablebool/) نشان می‌دهد. وقتی به یک سوئیچ بولی مستقیم برای بررسی املایی نیاز دارید، از `setSpellCheck` استفاده کنید. وقتی می‌خواهید متادیتای «بدون اثبات» ارائه را حفظ یا به‌طور صریح کنترل کنید (از جمله وضعیت `NotDefined`)، از `setProofDisabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آنها باید سازگار باشند؛ `setSpellCheck(true)` را با `setProofDisabled(NullableBool.True)` ترکیب نکنید.

این ویژگی‌ها فرادادهٔ اثبات را که توسط PowerPoint و سایر برنامه‌های ارائه استفاده می‌شود، پیکربندی می‌کنند. Aspose.Slides از آن‌ها برای اجرای بررسی املایی مبتنی بر واژه‌نامه یا بازگرداندن فهرست کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی می‌سازد، آن را بارگذاری می‌کند، تنظیمات متفاوت بررسی املایی و زبان‌های اثبات را برای دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، مجدداً باز می‌کند و مقادیر ذخیره‌شده را اعتبارسنجی می‌کند:

```javascript
const aspose = { slides: require("aspose.slides.via.java") };

const inputFile = "spell_check_input.pptx";
const outputFile = "spell_check_settings.pptx";

const sourcePresentation = new aspose.slides.Presentation();
try {
    const sourceSlide = sourcePresentation.getSlides().get_Item(0);
    const sourceShape = sourceSlide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 50, 50, 420, 80);
    const sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    const sourceEnglishPortion = new aspose.slides.Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    const sourceFrenchPortion = new aspose.slides.Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

const presentation = new aspose.slides.Presentation(inputFile);
try {
    const shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    const suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, aspose.slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

const reopenedPresentation = new aspose.slides.Presentation(outputFile);
try {
    const reopenedShape = reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    const storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    const firstPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(0).getPortionFormat().getLanguageId() === "en-US" && 
        storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    const secondPortionStored = storedPortions.getCount() === 2 && 
        storedPortions.get_Item(1).getPortionFormat().getLanguageId() === "fr-FR" && 
        !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        console.log("The proofing settings were stored correctly.");
    } else {
        console.log("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/presentation/#joinPortionsWithSameFormatting--) بخش‌های مجاور که قالب یکسانی دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` کافی نیست تا این بخش‌ها جدا بمانند؛ پس از ترکیب، بخش حاصل مقدار `SpellCheck` بخش اول را نگه می‌دارد. اگر بخش‌ها نیاز به تنظیمات متفاوت بررسی املایی داشته باشند، قبل از اختصاص این تنظیمات `joinPortionsWithSameFormatting` را فراخوانی کنید یا مرزهای بخش ترکیبی را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌هایی که مقدار `LanguageId` متفاوت دارند جدا می‌مانند زیرا قالب زبان اثبات آن‌ها متفاوت است.

## **سوالات متداول**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

خیر. [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) فرادادهٔ اثبات برای املاء و گرامر را ذخیره می‌کند؛ محتوای متن را تغییر نمی‌دهد. متن را به‌صورت جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان اثبات بر فونت‌ها، شکستهٔ کلمات یا بسته‌بندی خطوط تأثیر می‌گذارد؟**

خیر. شناسهٔ زبان صرفاً برای اثبات است. رندرینگ متن و چیدمان عمدتاً به [فونت‌های](/slides/fa/nodejs-java/powerpoint-fonts/) موجود، سیستم نوشتاری و تنظیمات فریم متنی وابسته‌اند. برای رندرینگ قابل اعتماد، فونت‌های موردنیاز را فراهم کنید، [جایگزینی فونت](/slides/fa/nodejs-java/font-substitution/) را پیکربندی کنید یا فونت‌ها را در ارائه [امبد](/slides/fa/nodejs-java/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند از چند زبان اثبات استفاده کند؟**

بله. همان‌گونه که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به بخش جداگانه‌ای اختصاص دهید.

**کدامیک را باید استفاده کنم: `setDefaultTextLanguage` یا `setLanguageId`؟**

وقتی می‌خواهید یک مقدار پیش‌فرض برای متن تازه ایجاد شده داشته باشید، از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) استفاده کنید. وقتی یک بخش خاص نیاز به زبان اثبات صریح دارد یا پاراگراف حاوی چند زبان است، از [BasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/nodejs-java/aspose.slides/baseportionformat/#setLanguageId-java.lang.String-) استفاده کنید.