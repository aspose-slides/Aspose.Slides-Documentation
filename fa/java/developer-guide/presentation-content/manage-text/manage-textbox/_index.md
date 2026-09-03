---
title: مدیریت جعبه‌های متن در ارائه‌ها با استفاده از جاوا
linktitle: مدیریت جعبه متن
type: docs
weight: 20
url: /fa/java/manage-textbox/
keywords:
- جعبه متن
- چارچوب متن
- اضافه‌کردن متن
- به‌روزرسانی متن
- ایجاد جعبه متن
- بررسی جعبه متن
- افزودن ستون متن
- افزودن پیوند
- PowerPoint
- ارائه
- Java
- Aspose.Slides
description: "ایجاد، شناسایی، قالب‌بندی و به‌روزرسانی جعبه‌های متن در ارائه‌های PowerPoint و OpenDocument با استفاده از Aspose.Slides برای جاوا."
---
## **مقدمه**

در Aspose.Slides for Java، متن اسلاید در چارچوب‌های متنی ذخیره می‌شود که به اشکال تعلق دارند. رابط [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) نمایانگر پرکاربردترین شکل حامل متن است و متن آن را از طریق متد [IAutoShape.getTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#getTextFrame--) در دسترس قرار می‌دهد.

{{% alert color="info" title="توجه" %}}

هر شکل خودکار پیاده‌سازی [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) را دارد، اما هر شکل خودکار نیست یا از چارچوب متن پشتیبانی نمی‌کند. هنگام پردازش یک ارائه موجود، قبل از دسترسی به متن، بررسی کنید که شکل پیاده‌سازی [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را دارد.

{{% /alert %}}

## **ایجاد یک جعبه متن در اسلاید**

برای ایجاد یک جعبه متن، یک شکل خودکار به اسلاید اضافه کنید، متن را به چارچوب متن آن اضافه کنید و ارائه را ذخیره کنید. مثال زیر یک جعبه متن مستطیلی ایجاد می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
    textBox.addTextFrame("Aspose TextBox");

    presentation.save("TextBox.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

مختصات و ابعاد پاس داده شده به متد [IShapeCollection.addAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) بر حسب پوینت اندازه‌گیری می‌شوند. متد [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) چارچوب متن را با متنی که فراهم می‌شود، مقداردهی اولیه می‌کند.

## **بررسی اینکه یک شکل جعبه متن است**

از متد [IAutoShape.isTextBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#isTextBox--) برای تعیین اینکه آیا یک شکل خودکار به عنوان جعبه متن در نظر گرفته می‌شود استفاده کنید. این روش زمانی مفید است که ارائه شامل هر دو شکل خودکار حامل متن و شکل‌های صرفاً گرافیکی باشد.

![یک جعبه متن و یک شکل](istextbox.png)

مثال زیر هر شکل خودکاری را در یک ارائه بررسی می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
    textBox.addTextFrame("Text box");
    slide.getShapes().addAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

    for (ISlide currentSlide : presentation.getSlides()) {
        for (IShape shape : currentSlide.getShapes()) {
            if (shape instanceof IAutoShape) {
                IAutoShape autoShape = (IAutoShape) shape;
                System.out.println(autoShape.isTextBox() ? "The shape is a text box." : "The shape is not a text box.");
            }
        }
    }
} finally {
    presentation.dispose();
}
```

یک شکل خودکار تازه اضافه شده تا زمانی که متن غیر خالی داشته باشد، به عنوان جعبه متن محسوب نمی‌شود. می‌توانید آن متن را از طریق [IAutoShape.addTextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#addTextFrame-java.lang.String-) یا [ITextFrame.setText](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#setText-java.lang.String-) فراهم کنید. افزودن یا اختصاص یک رشته خالی باعث می‌شود متد [IAutoShape.isTextBox](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/#isTextBox--) `false` برگرداند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape1 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
    shape1.addTextFrame("Shape 1");
    System.out.println(shape1.isTextBox());

    IAutoShape shape2 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
    shape2.getTextFrame().setText("Shape 2");
    System.out.println(shape2.isTextBox());

    IAutoShape shape3 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
    shape3.addTextFrame("");
    System.out.println(shape3.isTextBox());

    IAutoShape shape4 = slide.getShapes().addAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
    shape4.getTextFrame().setText("");
    System.out.println(shape4.isTextBox());
} finally {
    presentation.dispose();
}
```

دو فراخوانی اول `true` چاپ می‌کنند؛ دو فراخوانی آخر `false` چاپ می‌کنند.

## **پیدا کردن شکلی که چارچوب متن را در اختیار دارد**

کدهای عمومی پردازش متن ممکن است یک [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) را دریافت کنند بدون اینکه بدانند کدام شیء ارائه آن را دارای است. از متد فقط‑خواندنی [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) برای بازگشت به [IShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ishape/) صاحب آن استفاده کنید.

برای چارچوب متنی که توسط یک شکل خودکار یا شکل دیگری حامل متن در اختیار است، متد [ITextFrame.getParentShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentShape--) صاحب را برمی‌گرداند و متد [ITextFrame.getParentCell](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#getParentCell--) `null` برمی‌گرداند. قبل از دسترسی به مقدار برگشتی آن را بررسی کنید. برای شناسایی هر دو صاحب شکل و سلول‑جدول، از جمله اشکالی که به گره‌های SmartArt مرتبط هستند، به بخش [Search and Replace Text](/slides/fa/java/search-and-replace-text/) مراجعه کنید.

## **افزودن ستون‌ها به جعبه متن**

متد [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setColumnCount-int-) چارچوب متن را به ستون‌ها تقسیم می‌کند، در حالی که متد [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-) فاصله بین ستون‌ها را بر حسب پوینت تنظیم می‌کند. هر دو تنظیم متعلق به [ITextFrameFormat](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/) هستند و می‌توان آنها را از طریق چارچوب متن یک جعبه متن موجود تغییر داد. متن بین ستون‌ها در همان شکل جریان می‌یابد؛ به شکل دیگری ادامه نمی‌یابد.

مثال زیر یک جعبه متن سه‌ستونی با فاصله 10 پوینت بین ستون‌ها ایجاد می‌کند، ارائه را ذخیره می‌کند و تنظیمات ذخیره شده را از فایل خروجی می‌خواند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
    textBox.addTextFrame("This text is distributed automatically across all columns in the text box.");

    ITextFrameFormat textFrameFormat = textBox.getTextFrame().getTextFrameFormat();
    textFrameFormat.setColumnCount(3);
    textFrameFormat.setColumnSpacing(10);

    presentation.save("TextBoxColumns.pptx", SaveFormat.Pptx);

    Presentation savedPresentation = new Presentation("TextBoxColumns.pptx");
    try {
        IAutoShape savedTextBox = (IAutoShape) savedPresentation.getSlides().get_Item(0).getShapes().get_Item(0);
        ITextFrameFormat savedFormat = savedTextBox.getTextFrame().getTextFrameFormat();
        System.out.println("Columns: " + savedFormat.getColumnCount() + "; spacing: " + savedFormat.getColumnSpacing() + " points");
    } finally {
        savedPresentation.dispose();
    }
} finally {
    presentation.dispose();
}
```

## **استخراج متن از ستون‌های فردی**

از متد [ITextFrame.splitTextByColumns](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/#splitTextByColumns--) برای دریافت متنی که به هر ستون بصری در یک چارچوب متن موجود اختصاص داده شده استفاده کنید. این متد برای هر ستون یک رشته برمی‌گرداند، به ترتیب خواندن مبتنی بر ستون. یک چارچوب متن تک‑ستونی یک آرایه با یک عنصر تولید می‌کند و ستون خالی با یک رشته خالی نمایش داده می‌شود. رشته‌ها فقط شامل متن ساده هستند؛ قالب‌بندی در سطح بخش حفظ نمی‌شود.

این روش زمانی مفید است که نیاز به:

- استخراج متن همراه حفظ ترتیب خواندن مبتنی بر ستون داشته باشید.
- فهرست‌بندی یا مقایسه محتوای اسلایدهای چندستونه.
- استخراج هر ستون به فایلی جداگانه، فیلد پایگاه‌داده یا مقصد دیگر.
- بررسی چگونگی توزیع مجدد متن پس از تغییر تعداد ستون‌ها با [ITextFrameFormat.setColumnCount](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setColumnCount-int-)، فاصله با [ITextFrameFormat.setColumnSpacing](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframeformat/#setColumnSpacing-double-)، فونت یا اندازه چارچوب متن.

این متد متن توزیع‌شده در [ITextFrame](https://reference.aspose.com/slides/fa/java/com.aspose.slides/itextframe/) جاری را گزارش می‌دهد؛ به طور خودکار متن را بین شکل‌ها یا جعبه‌های متن جداگانه جریان نمی‌دهد. توزیع ستون می‌تواند به فونت‌های موجود و سایر تنظیمات چیدمان متن وابسته باشد، بنابراین هنگام نیاز به نتایج ثابت، اطمینان حاصل کنید فونت‌های مورد نیاز در دسترس باشند.

مثال زیر یک ارائه را بارگذاری می‌کند، اولین شکل خودکار چندستونی با چارچوب متن را پیدا می‌کند، تعداد ستون‌های پیکربندی‌شده آن را می‌خواند و متن هر ستون را به فایلی جداگانه می‌نویسد. اشکالی که چارچوب متنی ندارند، نادیده گرفته می‌شوند:

```java
import com.aspose.slides.*;
import java.io.IOException;
import java.nio.charset.StandardCharsets;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;

Presentation presentation = new Presentation("MultiColumnText.pptx");
try {
    IAutoShape textBox = null;
    for (IShape shape : presentation.getSlides().get_Item(0).getShapes()) {
        if (shape instanceof IAutoShape) {
            IAutoShape autoShape = (IAutoShape) shape;
            if (autoShape.getTextFrame() != null) {
                int columnCount = autoShape.getTextFrame().getTextFrameFormat().getColumnCount();
                if (columnCount > 1) {
                    textBox = autoShape;
                    break;
                }
            }
        }
    }

    if (textBox == null) {
        System.out.println("No multi-column text frame was found.");
    } else {
        ITextFrame textFrame = textBox.getTextFrame();
        int configuredColumnCount = textFrame.getTextFrameFormat().getColumnCount();
        String[] columnTexts = textFrame.splitTextByColumns();

        System.out.println("Configured columns: " + configuredColumnCount);

        for (int columnIndex = 0; columnIndex < columnTexts.length; columnIndex++) {
            int columnNumber = columnIndex + 1;
            String columnText = columnTexts[columnIndex];
            System.out.println("Column " + columnNumber + ": " + columnText);
            Path outputPath = Paths.get("Column-" + columnNumber + ".txt");
            byte[] textBytes = columnText.getBytes(StandardCharsets.UTF_8);
            try {
                Files.write(outputPath, textBytes);
            } catch (IOException exception) {
                System.out.println("Could not write column " + columnNumber + ": " + exception.getMessage());
            }
        }
    }
} finally {
    presentation.dispose();
}
```

## **به‌روزرسانی متن**

برای به‌روزرسانی متن در سراسر یک ارائه، اسلایدها و اشکال را پیمایش کنید، اشکال خودکار را انتخاب کنید و سپس بخش‌های متنی آنها را ویرایش کنید. کار بر روی سطح بخش امکان تغییر هم متن و هم قالب‌بندی کاراکترها را می‌دهد.

مثال زیر هر رخداد `years` را با `months` در متن اشکال خودکار جایگزین می‌کند و هر بخش تحت تأثیر را بولد می‌سازد:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("Text.pptx");
try {
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            if (!(shape instanceof IAutoShape)) {
                continue;
            }

            IAutoShape autoShape = (IAutoShape) shape;
            ITextFrame textFrame = autoShape.getTextFrame();
            if (textFrame == null) {
                continue;
            }

            for (IParagraph paragraph : textFrame.getParagraphs()) {
                for (IPortion portion : paragraph.getPortions()) {
                    String text = portion.getText();
                    if (text != null && text.contains("years")) {
                        portion.setText(text.replace("years", "months"));
                        portion.getPortionFormat().setFontBold(NullableBool.True);
                    }
                }
            }
        }
    }

    presentation.save("TextChanged.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

این گردش فقط متن را در اشکال خودکار به‌روز می‌کند. متنی که در جداول، نمودارها، SmartArt یا اشکال گروهی ذخیره شده است، نیاز به پیمایش مجموعه‌های خود آن اشیاء دارد.

## **افزودن جعبه متن با پیوند**

می‌توان یک پیوند را به بخش متنی خاصی اختصاص داد، طوری که فقط همان متن به عنوان لینک قابل کلیک باشد. از متد [IHyperlinkManager.setExternalHyperlinkClick](https://reference.aspose.com/slides/fa/java/com.aspose.slides/ihyperlinkmanager/#setExternalHyperlinkClick-java.lang.String-) برای ارتباط بخش با یک URL خارجی استفاده کنید.

مثال زیر متن لینک‌دار ایجاد کرده و آن را در یک ارائه ذخیره می‌کند:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape textBox = slide.getShapes().addAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
    textBox.addTextFrame("Aspose.Slides");

    IPortion textPortion = textBox.getTextFrame().getParagraphs().get_Item(0).getPortions().get_Item(0);
    textPortion.getPortionFormat().getHyperlinkManager().setExternalHyperlinkClick("https://www.aspose.com/");

    presentation.save("Hyperlink.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **پرسش‌های متداول**

**تفاوت جعبه متن و مکان‌نگهدار متن در اسلاید مستر یا طرح‌بندی چیست؟**

یک [placeholder](/slides/fa/java/manage-placeholder/) می‌تواند موقعیت و قالب‌بندی خود را از یک [master slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/masterslide/) یا [layout slide](https://reference.aspose.com/slides/fa/java/com.aspose.slides/layoutslide/) به ارث ببرد. یک جعبه متن معمولی شکل مستقلی بر روی اسلایدی است که در آن ایجاد شده و هنگام تغییر طرح‌بندی، رفتار placeholder را به‌دست نمی‌آورد.

**چگونه می‌توان متن را جایگزین کرد بدون آنکه متن در نمودارها، جداول یا SmartArt تغییر یابد؟**

پیمایش را به اشکالی که پیاده‌سازی [IAutoShape](https://reference.aspose.com/slides/fa/java/com.aspose.slides/iautoshape/) را دارند محدود کنید، همان‌طور که در مثال به‌روزرسانی متن نشان داده شد. نمودارها، جداول و SmartArt متن را در مدل‌های شیء خود ذخیره می‌کنند، بنابراین توسط آن حلقه تغییر نمی‌یابند.