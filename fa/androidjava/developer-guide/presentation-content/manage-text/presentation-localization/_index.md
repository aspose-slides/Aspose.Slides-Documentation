---
title: خودکارسازی بومی‌سازی ارائه در اندروید
linktitle: بومی‌سازی ارائه
type: docs
weight: 100
url: /fa/androidjava/presentation-localization/
keywords:
- تغییر زبان
- بررسی املایی
- حذف بررسی املایی
- زبان proofing
- شناسه زبان
- متن چندزبانه
- پاورپوینت
- ارائه
- اندروید
- جاوا
- Aspose.Slides
description: "تنظیم زبان‌های proofing برای متن ارائه PowerPoint و OpenDocument در اندروید با Aspose.Slides for Android via Java، شامل پیش‌فرض‌ها و پاراگراف‌های چندزبانه."
---
## **بررسی کلی**

Aspose.Slides for Android via Java به شما امکان پیکربندی متادیتای proofing برای بخش‌های متنی جداگانه را می‌دهد. برای شناسایی زبان proofing از [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) استفاده کنید، برای اجازه یا حذف بررسی املائی از [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) و برای کنترل حالت کلی «بدون proof» از [IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) استفاده کنید. چون این تنظیمات در سطح portion اعمال می‌شوند، یک پاراگراف می‌تواند شامل چندین زبان و قوانین proofing متفاوت باشد.

این مقاله توضیح می‌دهد چگونه به متن خاص یک زبان اختصاص دهید، زبان پیش‌فرض متن جدید را با [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) تنظیم کنید، پاراگراف‌های چندزبانه بسازید، بین `SpellCheck` و `ProofDisabled` انتخاب کنید و هنگام استفاده از [Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) تنظیمات مورد نظر را حفظ کنید. این خصوصیات متادیتای مورد استفاده برنامه‌های ارائه را ذخیره می‌کنند؛ آنها متن را ترجمه نمی‌کنند، بررسی املائی بر پایهٔ دیکشنری انجام نمی‌دهند و کلمهٔ غلط املایی را برنمی‌گردانند.

## **تنظیم زبان proofing برای متن**

یک [Presentation](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/) بسازید یا بارگذاری کنید، بخش متنی مورد نیاز را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getPortionFormat--) دریافت کنید و شناسهٔ زبان آن را اختصاص دهید. مثال زیر یک شکل ایجاد می‌کند، انگلیسی بریتانیایی را به عنوان زبان proofing تنظیم می‌کند و نتیجه را با [Presentation.save](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) ذخیره می‌گیرد:

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

از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) برای مشخص کردن زبانی که Aspose.Slides به متن تازه ایجاد شده اختصاص می‌دهد، استفاده کنید. این تنظیم زمانی مفید است که بیشتر یا تمام متن‌های جدید در ارائه از یک زبان استفاده کنند. این تنظیم متادیتای زبان متنی که پیش از این شناسهٔ صریح داشته است را تغییر نمی‌دهد.

مثال زیر یک ارائه می‌سازد که متن جدید آن از قوانین proofing آلمانی استفاده می‌کند:

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

## **استفاده از چند زبان در یک پاراگراف**

یک [IParagraph](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iparagraph/) شامل مجموعه‌ای از portion های متنی است. برای هر زبان یک [Portion](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/portion/) جداگانه ایجاد کنید و `LanguageId` آن را به‌طور مستقل تنظیم کنید.

مثال زیر یک پاراگراف با portion های انگلیسی و فرانسوی ایجاد می‌کند:

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

## **فعال یا غیرفعال کردن بررسی املائی برای portion های جداگانه**

[IPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportionformat/) ویژگی‌های متنی عمومی تعریف‌شده توسط [IBasePortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/) را به ارث می‌برد. قالب یک portion را از طریق [IPortion.getPortionFormat](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/iportion/#getPortionFormat--) دریافت کنید و با استفاده از [IBasePortionFormat.setSpellCheck](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setSpellCheck-boolean-) کنترل کنید که آیا برنامهٔ ارائه می‌تواند املا را برای آن portion بررسی کند یا نه. مقدار پیش‌فرض `false` است: `true` اجازهٔ بررسی املائی می‌دهد، در حالی که `false` آن را غیرفعال می‌کند.

این تنظیم برای portion های متنی جداگانه اعمال می‌شود. بنابراین portion های مختلف در یک پاراگراف می‌توانند مقادیر متفاوتی داشته باشند. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) و `setSpellCheck` اهداف مکملی دارند: `setLanguageId` زبان proofing را شناسایی می‌کند، در حالی که `setSpellCheck` تعیین می‌کند آیا بررسی املائی برای آن portion اجازه دارد یا خیر.

[IBasePortionFormat.setProofDisabled](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setProofDisabled-byte-) نیز proofing را کنترل می‌کند، اما حالت گستردهٔ «بدون proof» را به‌صورت یک [NullableBool](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/nullablebool/) نشان می‌دهد. وقتی به‌دنبال یک سوئیچ Boolean مستقیم برای بررسی املائی هستید، از `setSpellCheck` استفاده کنید. وقتی نیاز به حفظ یا کنترل صریح متادیتای «بدون proof» ارائه دارید، شامل حالت `NotDefined`، از `setProofDisabled` استفاده کنید. اگر هر دو ویژگی را تنظیم کنید، مقادیر آنها باید سازگار باشد؛ `setSpellCheck(true)` را با `setProofDisabled(NullableBool.True)` ترکیب نکنید.

این ویژگی‌ها متادیتای proofing را برای PowerPoint و سایر برنامه‌های ارائه پیکربندی می‌کنند. Aspose.Slides از آنها برای اجرای بررسی املائی بر پایهٔ دیکشنری یا برگرداندن لیست کلمات غلط استفاده نمی‌کند.

مثال کامل زیر یک ارائهٔ ورودی می‌سازد، آن را بارگذاری می‌کند، تنظیمات مختلف بررسی املائی و زبان proofing را به دو portion در همان پاراگراف اختصاص می‌دهد، نتیجه را ذخیره می‌کند، مجدداً باز می‌کند و مقادیر ذخیره‌شده را تأیید می‌کند:

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

[Presentation.joinPortionsWithSameFormatting](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/presentation/#joinPortionsWithSameFormatting--) portion های مجاور که قالب یکسان دارند را ترکیب می‌کند. تنها تفاوت در `SpellCheck` باعث عدم جداسازی آنها نمی‌شود؛ پس از ترکیب، portion حاصل مقدار `SpellCheck` اولین portion را حفظ می‌کند. اگر portion ها نیاز به تنظیمات متفاوت بررسی املائی داشته باشند، قبل از اختصاص این تنظیمات `joinPortionsWithSameFormatting` را فراخوانی کنید یا مرزهای portion حاصل را بررسی کرده و پس از آن تنظیمات را مجدداً اعمال کنید. portion های با مقادیر متفاوت `LanguageId` به‌دلیل متفاوت بودن قالب زبان proofing، جدا می‌مانند.

## **سوالات متداول**

**آیا شناسهٔ زبان متن را ترجمه می‌کند؟**

خیر. [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) متادیتای proofing برای املا و گرامر را ذخیره می‌کند؛ مطمئناً محتوای متن را تغییر نمی‌دهد. متن را به‌صورت جداگانه ترجمه کنید و سپس شناسهٔ زبان مناسب را برای هر portion ترجمه‌شده تنظیم کنید.

**آیا زبان proofing فونت‌ها، شکست کلمات یا بسته‌بندی خطوط را کنترل می‌کند؟**

خیر. شناسهٔ زبان فقط برای proofing است. رندرینگ متن و چیدمان عمدتاً به [فونت‌های](/slides/fa/androidjava/powerpoint-fonts/) در دسترس، سیستم نوشتاری و تنظیمات فریم متن وابسته است. برای رندرینگ قابل اعتماد، فونت‌های مورد نیاز را فراهم کنید، [جایگزینی فونت](/slides/fa/androidjava/font-substitution/) را پیکربندی کنید یا [فونت‌ها را درون‌ساز](/slides/fa/androidjava/embedded-font/) کنید.

**آیا یک پاراگراف می‌تواند چندین زبان proofing داشته باشد؟**

بله. همان‌طور که در مثال پاراگراف چندزبانه نشان داده شد، هر زبان را به یک portion جداگانه اختصاص دهید.

**کدام یک را باید استفاده کنم: `setDefaultTextLanguage` یا `setLanguageId`؟**

وقتی می‌خواهید برای متن تازه ایجاد شده پیش‌فرضی داشته باشید، از [LoadOptions.setDefaultTextLanguage](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/loadoptions/#setDefaultTextLanguage-java.lang.String-) استفاده کنید. وقتی یک portion خاص نیاز به زبان proofing صریح دارد یا پاراگراف شامل چند زبان است، از [IBasePortionFormat.setLanguageId](https://reference.aspose.com/slides/fa/androidjava/com.aspose.slides/ibaseportionformat/#setLanguageId-java.lang.String-) استفاده کنید.