---
title: اتوماسیون بومی‌سازی ارائه در جاوا
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/java/presentation-localization/
keywords:
- تغییر زبان
- بررسی املای
- سرکوب بررسی املای
- زبان تصحیح
- شناسه زبان
- متن چندزبانه
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "زبان‌های تصحیح را برای متن ارائه‌های PowerPoint و OpenDocument در جاوا با Aspose.Slides تنظیم کنید، شامل حالت پیش‌فرض و پاراگراف‌های چندزبانه."
---
## **بررسی کلی**

Aspose.Slides for Java به شما امکان می‌دهد متادیتای تصحیح را برای بخش‌های متنی فردی تنظیم کنید. برای شناسایی زبان تصحیح از [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) استفاده کنید، برای اجازه یا سرکوب بررسی املایی از [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) و برای کنترل وضعیت کلی «بدون تصحیح» از [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) استفاده کنید. از آنجا که این تنظیمات در سطح بخش (Portion) اعمال می‌شوند، یک پاراگراف می‌تواند شامل چندین زبان و قوانین تصحیح مختلف باشد.

این مقاله توضیح می‌دهد چگونه یک زبان را به متن خاص اختصاص دهید، زبان پیش‌فرض برای متن جدید را با [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و هنگام استفاده از [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) تنظیمات مورد نظر را حفظ کنید. این خصوصیت‌ها متادیتای مورد استفاده برنامه‌های ارائه را ذخیره می‌کنند؛ آن‌ها متن را ترجمه نمی‌کنند، بررسی املایی بر پایهٔ واژه‌نامه انجام نمی‌دهند و کلمات غلط املایی را بر نمی‌گردانند.

## **تنظیم زبان تصحیح برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/) ایجاد یا بارگذاری کنید، بخش متنی مورد نیاز را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getPortionFormat--) دریافت کنید و شناسهٔ زبان آن را تعیین کنید. مثال زیر یک شکل می‌سازد، انگلیسی بریتانیایی را به‌عنوان زبان تصحیح تنظیم می‌کند و نتیجه را با [Presentation.save](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌کند:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IPortion;
import com.aspose.slides.ISlide;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Set the proofing language for this text.");

    IPortion portion = shape.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    portion.getPortionFormat().setLanguageId("en-GB");

    presentation.save("proofing_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **تنظیم زبان پیش‌فرض برای متن جدید**

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای تعیین زبان تصحیحی که Aspose.Slides به متن تازه ایجاد شده اختصاص می‌دهد، استفاده کنید. این تنظیم زمانی مفید است که بیشتر یا تمام متن جدید در یک ارائه از یک زبان استفاده کند. این تنظیم متادیتای زبان متونی که قبلاً شناسهٔ صریح داشته‌اند را تغییر نمی‌دهد.

مثال زیر یک ارائه می‌سازد که متن جدید آن از قوانین تصحیح آلمانی استفاده می‌کند:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.ISlide;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDefaultTextLanguage("de-DE");

Presentation presentation = new Presentation(loadOptions);
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 320, 80);
    shape.getTextFrame().setText("Willkommen zur Präsentation");

    presentation.save("default_text_language.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **استفاده از چندین زبان در یک پاراگراف**

یک [IParagraph](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iparagraph/) شامل مجموعه‌ای از بخش‌های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/java/com.aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به‌صورت مستقل تنظیم کنید.

این مثال یک پاراگراف با بخش‌های انگلیسی و فرانسوی می‌سازد:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph paragraph = shape.getTextFrame().getParagraphs().get_Item(0);
    paragraph.getPortions().clear();

    Portion englishPortion = new Portion("Welcome");
    englishPortion.getPortionFormat().setLanguageId("en-US");
    paragraph.getPortions().add(englishPortion);

    Portion frenchPortion = new Portion(" — Bienvenue");
    frenchPortion.getPortionFormat().setLanguageId("fr-FR");
    paragraph.getPortions().add(frenchPortion);

    presentation.save("multilingual_text.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **فعال یا غیرفعال کردن بررسی املایی برای بخش‌های فردی**

[IPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportionformat/) ویژگی‌های متنی مشترکی که توسط [IBasePortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/) تعریف شده‌اند، به ارث می‌برد. از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iportion/#getPortionFormat--) به فرمت یک بخش دسترسی پیدا کنید و با استفاده از [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) کنترل کنید که آیا برنامهٔ ارائه می‌تواند املای آن بخش را بررسی کند یا نه. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املایی را می‌دهد، در حالی که `false` آن را سرکوب می‌کند.

این تنظیم برای بخش‌های متنی فردی اعمال می‌شود. بنابراین بخش‌های مختلف در همان پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) و `setSpellCheck` اهداف تکمیلی دارند: `setLanguageId` language تصحیح را شناسایی می‌کند، در حالی که `setSpellCheck` تعیین می‌کند آیا بررسی املایی برای بخش مجاز است یا خیر.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) همچنین کنترل تصحیح را بر عهده دارد، اما وضعیت گستردهٔ «عدم تصحیح» را به‌عنوان یک [NullableBool](https://reference.aspose.com/slides/fa/java/com.aspose.slides/nullablebool/) نمایان می‌کند. وقتی به یک سوئیچ Boolean مستقیم برای بررسی املایی نیاز دارید، از `setSpellCheck` استفاده کنید. وقتی می‌خواهید متادیتای «بدون تصحیح» ارائه را حفظ یا به‌صورت صریح کنترل کنید، شامل حالت `NotDefined`، از `setProofDisabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آن‌ها را سازگار نگه دارید؛ `setSpellCheck(true)` را همراه با `setProofDisabled(NullableBool.True)` ترکیب نکنید.

این خصوصیت‌ها متادیتای تصحیحی را که توسط PowerPoint و سایر برنامه‌های ارائه استفاده می‌شود، پیکربندی می‌کنند. Aspose.Slides از آن‌ها برای اجرای بررسی املایی بر پایهٔ واژه‌نامه یا بازگرداندن فهرست کلمات غلط املایی استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی می‌سازد، آن را بارگذاری می‌کند، تنظیمات مختلف بررسی املایی و زبان‌های تصحیحی را به دو بخش در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، دوباره باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

```java
import com.aspose.slides.IAutoShape;
import com.aspose.slides.IParagraph;
import com.aspose.slides.IPortion;
import com.aspose.slides.IPortionCollection;
import com.aspose.slides.ISlide;
import com.aspose.slides.Portion;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import com.aspose.slides.ShapeType;

String inputFile = "spell_check_input.pptx";
String outputFile = "spell_check_settings.pptx";

Presentation sourcePresentation = new Presentation();
try {
    ISlide sourceSlide = sourcePresentation.getSlides().get_Item(0);
    IAutoShape sourceShape = sourceSlide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 420, 80);
    IParagraph sourceParagraph = sourceShape.getTextFrame().getParagraphs().get_Item(0);
    sourceParagraph.getPortions().clear();

    Portion sourceEnglishPortion = new Portion("Check this text. ");
    sourceEnglishPortion.getPortionFormat().setLanguageId("en-US");
    sourceParagraph.getPortions().add(sourceEnglishPortion);

    Portion sourceFrenchPortion = new Portion("Ignorer ce code : ZX-81.");
    sourceFrenchPortion.getPortionFormat().setLanguageId("fr-FR");
    sourceParagraph.getPortions().add(sourceFrenchPortion);

    sourcePresentation.save(inputFile, SaveFormat.Pptx);
} finally {
    sourcePresentation.dispose();
}

Presentation presentation = new Presentation(inputFile);
try {
    IAutoShape shape = (IAutoShape) presentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection portions = shape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    IPortion checkedPortion = portions.get_Item(0);
    checkedPortion.getPortionFormat().setLanguageId("en-US");
    checkedPortion.getPortionFormat().setSpellCheck(true);

    IPortion suppressedPortion = portions.get_Item(1);
    suppressedPortion.getPortionFormat().setLanguageId("fr-FR");
    suppressedPortion.getPortionFormat().setSpellCheck(false);

    presentation.save(outputFile, SaveFormat.Pptx);
} finally {
    presentation.dispose();
}

Presentation reopenedPresentation = new Presentation(outputFile);
try {
    IAutoShape reopenedShape = (IAutoShape) reopenedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
    IPortionCollection storedPortions = reopenedShape.getTextFrame().getParagraphs().get_Item(0).getPortions();

    boolean firstPortionStored = storedPortions.getCount() == 2 && 
            "en-US".equals(storedPortions.get_Item(0).getPortionFormat().getLanguageId()) && 
            storedPortions.get_Item(0).getPortionFormat().getSpellCheck();

    boolean secondPortionStored = storedPortions.getCount() == 2 && 
            "fr-FR".equals(storedPortions.get_Item(1).getPortionFormat().getLanguageId()) && 
            !storedPortions.get_Item(1).getPortionFormat().getSpellCheck();

    if (firstPortionStored && secondPortionStored) {
        System.out.println("The proofing settings were stored correctly.");
    } else {
        System.out.println("The proofing settings could not be verified.");
    }
} finally {
    reopenedPresentation.dispose();
}
```

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/java/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) بخش‌های مجاور که فرمت یکسانی دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` کافی نیست تا این بخش‌ها جدا بمانند؛ پس از ترکیب، بخش حاصل مقدار `SpellCheck` اولین بخش را حفظ می‌کند. اگر بخش‌ها به تنظیمات متفاوتی برای بررسی املایی نیاز دارند، قبل از اختصاص این تنظیمات `joinPortionsWithSameFormatting` را صدا بزنید یا مرزهای بخش حاصل را بررسی کرده و پس از آن تنظیمات را دوباره اعمال کنید. بخش‌هایی که مقادیر `LanguageId` متفاوت دارند، به‌دلیل تفاوت در قالب‌بندی زبان تصحیح، جدا باقی می‌مانند.

## **FAQ**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

نه. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) متادیتای تصحیح برای املا و گرامر را ذخیره می‌کند؛ محتویات متن را تغییر نمی‌دهد. متن را به‌طور جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر بخش ترجمه‌شده تنظیم کنید.

**آیا زبان تصحیح قلم‌ها، هفتک‌گذاری یا چینش خطوط را کنترل می‌کند؟**

نه. شناسهٔ زبان صرفاً برای تصحیح است. رندرینگ متن و چینش عمدتاً به [قلم‌ها](/slides/fa/java/powerpoint-fonts/) موجود، سیستم نوشتاری و تنظیمات فریم متن وابسته است. برای رندرینگ قابل اطمینان، قلم‌های مورد نیاز را فراهم کنید، [جایگزینی قلم](/slides/fa/java/font-substitution/) را پیکربندی کنید یا [قلم‌ها را تعبیه](/slides/fa/java/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند چندین زبان تصحیح داشته باشد؟**

بله. همان‌طور که در مثال پاراگراف چندزبان نشان داده شد، هر زبان را به یک بخش جداگانه اختصاص دهید.

**کدامیک را استفاده کنم: `setDefaultTextLanguage` یا `setLanguageId`؟**

وقتی می‌خواهید یک پیش‌فرض برای متن تازه ایجاد شده داشته باشید، از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/java/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) استفاده کنید. وقتی یک بخش خاص به زبان تصحیح صریحی نیاز دارد یا پاراگراف شامل چندین زبان است، از [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) استفاده کنید.