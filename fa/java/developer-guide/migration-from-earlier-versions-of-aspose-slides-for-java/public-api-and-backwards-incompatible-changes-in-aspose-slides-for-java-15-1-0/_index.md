---
title: "API عمومی و تغییرات ناسازگار به سمت عقب در Aspose.Slides for Java نسخه 15.1.0"
linktitle: "Aspose.Slides for Java 15.1.0"
type: docs
weight: 100
url: /fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/
keywords:
- مهاجرت
- کدهای قدیمی
- کدهای مدرن
- رویکرد قدیمی
- رویکرد مدرن
- PowerPoint
- OpenDocument
- ارائه
- Java
- Aspose.Slides
description: "به‌روزرسانی‌های API عمومی و تغییرات شکسته‌کننده در Aspose.Slides for Java را بررسی کنید تا بتوانید به‌صورت روان ارائه‌های PowerPoint PPT، PPTX و ODP خود را مهاجرت دهید."
---
{{% alert color="info" %}} 

این صفحه تمام کلاس‌های [اضافه‌شده](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) ، متدها، خصوصیات و غیره، محدودیت‌های جدید و سایر [تغییرات](/slides/fa/java/public-api-and-backwards-incompatible-changes-in-aspose-slides-for-java-15-1-0/) معرفی‌شده با Aspose.Slides for Java نسخه 15.1.0 API را فهرست می‌کند.

{{% /alert %}} {{% alert color="info" %}} 

مسائل شناخته‌شده‌ای در برخی از گلوله‌های تصویری و اشیای WordArt وجود دارد که در Aspose.Slides for Java نسخه 15.2.0 برطرف خواهند شد.

{{% /alert %}} 
## **تغییرات API عمومی**
### **قابلیت جایگزینی قلم‌ها اضافه شد**
امکان جایگزینی قلم‌ها به صورت سراسری در تمام ارائه و به‌صورت موقت برای رندرینگ اضافه شد.

متد جدید **getFontsManager()** از کلاس **Presentation** معرفی شد. کلاس **FontsManager** دارای اعضای زیر است:

**IFontSubstRuleCollection getFontSubstRuleList**() متد  
این مجموعه‌ای از نمونه‌های **IFontSubstRule** است که برای جایگزینی قلم‌ها هنگام رندرینگ استفاده می‌شود. **IFontSubstRule** دارای متدهای **getSourceFont()** و **getDestFont()** است که رابط **IFontData** را پیاده‌سازی می‌کنند و متد **getReplaceFontCondition()** که امکان انتخاب شرط جایگزینی را می‌دهد («WhenInaccessible» یا «Always»).

**IFontData[] getFonts()** متد می‌تواند برای دریافت تمام قلم‌های استفاده‌شده در ارائهٔ فعلی مورد استفاده قرار گیرد.

متدهای **replaceFont(...)** می‌توانند برای جایگزینی دائمی یک قلم در یک ارائه استفاده شوند.

مثال زیر نشان می‌دهد چگونه یک قلم را در یک ارائه جایگزین کنیم:

``` java
import com.aspose.slides.*;


 Presentation pres = new Presentation("PresContainsArialFont.pptx");

IFontData sourceFont = new FontData("Arial");

IFontData destFont = new FontData("Times New Roman");

pres.getFontsManager().replaceFont(sourceFont, destFont);

pres.save("PresContainsTimesNoewRomanFont.pptx", SaveFormat.Pptx);

```

مثال دیگر، جایگزینی قلم برای رندرینگ زمانی که در دسترس نیست را نشان می‌دهد:

``` java
import com.aspose.slides.*;

Presentation pres = new Presentation("PresContainsSomeRareFontFont.pptx");
try {
    IFontData sourceFont = new FontData("SomeRareFont");
    IFontData destFont = new FontData("Arial");

    IFontSubstRule fontSubstRule = new FontSubstRule(sourceFont, destFont, FontSubstCondition.WhenInaccessible);

    IFontSubstRuleCollection fontSubstRuleCollection = new FontSubstRuleCollection();
    fontSubstRuleCollection.add(fontSubstRule);

    pres.getFontsManager().setFontSubstRuleList(fontSubstRuleCollection);

    // فونت Arial به جای SomeRareFont وقتی در دسترس نیست استفاده خواهد شد.
    IImage slideImage = pres.getSlides().get_Item(0).getImage(1, 1);
    slideImage.dispose();
} finally {
    if (pres != null) pres.dispose();
}
```