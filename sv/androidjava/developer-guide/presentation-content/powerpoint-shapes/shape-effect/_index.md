---
title: Applicera formseffekter i presentationer på Android
linktitle: Formseffekt
type: docs
weight: 30
url: /sv/androidjava/shape-effect/
keywords:
- formseffekt
- skuggeffekt
- reflektseffekt
- glödeffekt
- mjuk kantseffekt
- effektformat
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Omvandla dina PPT- och PPTX-filer med avancerade formseffekter med Aspose.Slides för Android via Java—skapa slående, professionella bildspel på några sekunder."
---
## **Introduktion**

Medan effekter i PowerPoint kan användas för att få en form att sticka ut, skiljer de sig från [fyllningar](/slides/sv/androidjava/shape-formatting/#gradient-fill) eller konturer. Med PowerPoint‑effekter kan du skapa övertygande reflektioner på en form, sprida en formens glöd osv.

![Formseffekt](shape-effect.png)

PowerPoint erbjuder sex effekter som kan tillämpas på former. Du kan tillämpa en eller flera effekter på en form.

Vissa kombinationer av effekter ser bättre ut än andra. Av den anledningen erbjuder PowerPoint alternativ under **Preset**. Preset‑alternativen är kombinationer av två eller fler effekter som är kända för att se bra ut. På så sätt, genom att välja ett förinställt värde, behöver du inte slösa tid på att testa eller kombinera olika effekter för att hitta en bra kombination.

Aspose.Slides tillhandahåller egenskaper och metoder under klassen [EffectFormat](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/) som låter dig tillämpa samma effekter på former i PowerPoint‑presentationer.

## **Tillämpa en skuggeffekt**

Aspose.Slides för Android via Java stöder yttre och inre skuggor för former. Du kan anpassa deras färg, riktning, avstånd och oskärpedjup för att matcha din presentationsdesign.

### **Tillämpa en yttre skugga**

Använd en yttre skugga för att få ett kort eller en panel att sticka ut mot bildbakgrunden. Skuggan sträcker sig utanför formens kanter och skapar intrycket att formen är upphöjd över bilden. Justera dess färg, riktning, avstånd och oskärpedjup för att matcha belysning och stil i din mall.

Denna Java‑kod visar hur du applicerar den [yttre skuggeffekten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getOuterShadowEffect--) på en rektangel:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableOuterShadowEffect();
    shape.getEffectFormat().getOuterShadowEffect().getShadowColor().setColor(Color.rgb(169, 169, 169));
    shape.getEffectFormat().getOuterShadowEffect().setDistance(10);
    shape.getEffectFormat().getOuterShadowEffect().setDirection(45);

    presentation.save("shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Skuggeffekt](shadow_effect.png)

### **Tillämpa en inre skugga**

När du återskapar en malls visuella stil, använd en inre skugga för att ge ett kort eller en panel ett nedsänkt utseende. En yttre skugga sträcker sig utanför formen och får den att se upphöjd ut, medan en inre skugga skuggar insidan av dess kanter.

Anropa [enableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#enableInnerShadowEffect--) och konfigurera sedan skuggan som returneras av [getInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getInnerShadowEffect--). Större värden för oskärpedjup ger mjukare kanter.

Detta Java‑exempel skapar ett ljusblått kort med en mörkgrå inre skugga och sparar det som en PPTX‑fil. Skuggans riktning är 225 grader, dess avstånd är 7 punkter och dess oskärpedjup är 6 punkter:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 20, 20, 200, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(173, 216, 230));
    shape.getLineFormat().getFillFormat().setFillType(FillType.NoFill);

    shape.getEffectFormat().enableInnerShadowEffect();
    IInnerShadow shadow = shape.getEffectFormat().getInnerShadowEffect();
    shadow.getShadowColor().setColor(Color.rgb(105, 105, 105));
    shadow.setDirection(225);
    shadow.setDistance(7);
    shadow.setBlurRadius(6);

    presentation.save("inner_shadow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Ljusblå rektangel med inre skugga](inner_shadow_effect.png)

För att ta bort den inre skuggan, anropa [disableInnerShadowEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#disableInnerShadowEffect--) på formens effektformat.

## **Tillämpa en reflektseffekt**

För att applicera en reflektseffekt i Aspose.Slides för Android via Java kan du lägga till en spegelliknande reflektion på former, justera parametrar som avstånd, transparens och storlek. Denna effekt förbättrar estetiken i dina presentationer genom att ge former ett mer polerat och sofistikerat utseende. Det är enkelt att implementera med enkel kod, vilket möjliggör snabb tillämpning på flera element för en enhetlig design.

Denna Java‑kod visar hur du applicerar [reflektseffekten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getReflectionEffect--) på en form:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableReflectionEffect();
    shape.getEffectFormat().getReflectionEffect().setRectangleAlign(RectangleAlignment.Bottom);
    shape.getEffectFormat().getReflectionEffect().setDirection(90);
    shape.getEffectFormat().getReflectionEffect().setDistance(40);
    shape.getEffectFormat().getReflectionEffect().setBlurRadius(2);

    presentation.save("reflection_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Reflektseffekt](reflection_effect.png)

## **Tillämpa en glödeffekt**

För att applicera en glödeffekt på en form i Aspose.Slides för Android via Java kan du lägga till en mjuk, ljusande aura runt former, justera egenskaper som färg och storlek. Denna effekt hjälper former att sticka ut och tillför ett attraktivt, iögonfallande visuellt element till din presentation. Det är enkelt att implementera med minimal kod, vilket förbättrar helhetsintrycket av dina bilder.

Denna Java‑kod visar hur du applicerar [glödeffekten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getGlowEffect--) på en form:

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 100);
    shape.getEffectFormat().enableGlowEffect();
    shape.getEffectFormat().getGlowEffect().getColor().setColor(Color.MAGENTA);
    shape.getEffectFormat().getGlowEffect().setRadius(15);

    presentation.save("glow_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Glödeffekt](glow_effect.png)

## **Tillämpa en mjukkantseffekt**

För att applicera en mjuk kant‑effekt i Aspose.Slides för Android via Java kan du skapa en jämn, suddig övergång runt en forms kanter. Denna effekt ger ett mer subtilt och raffinerat utseende, perfekt för designer som behöver ett mjukt, mjukare utseende. Du kan enkelt justera parametrar som radie för att uppnå önskad effekt på olika former i din presentation.

Denna Java‑kod visar hur du applicerar [mjuk kant‑effekten](https://reference.aspose.com/slides/androidjava/com.aspose.slides/effectformat/#getSoftEdgeEffect--) på en form:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IShape shape = slide.getShapes().addAutoShape(ShapeType.RoundCornerRectangle, 20, 20, 200, 150);
    shape.getEffectFormat().enableSoftEdgeEffect();
    shape.getEffectFormat().getSoftEdgeEffect().setRadius(8);

    presentation.save("soft_edges_effect.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

![Mjuk kant‑effekt](soft_edges_effect.png)

## **Tillämpa en oskärpeeffekt**

Använd formoskärpa för att mjukgöra en forms fyllning och kontur samtidigt som formen förblir redigerbar. Anropa [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) på formens effektformat. Radien mäts i punkter (1/72 tum): använd ett icke‑negativt värde, där större värden ger starkare oskärpa. En radie på noll lämnar utseendet oförändrat.

[getGrow](https://reference.aspose.com/slides/androidjava/com.aspose.slides/iblur/#getGrow--)‑inställningen styr de synliga gränserna för effekten. Med `false` klipps oskärpan till de ursprungliga målade gränserna, inklusive konturen. Med `true` kan oskärpan sträcka sig utanför dessa gränser. Ingen av inställningarna ändrar formens position eller dimensioner.

Jämförelsen nedan använder samma fyllning, kontur och formdimensioner hela tiden. Den övre raden använder `grow = false`; den nedre raden använder `grow = true`.

![Original rektangel jämfört med oskärperadier på 5 och 15 punkter, med grow inaktiverat och aktiverat](shape_blur_comparison.png)

Detta Java‑exempel skapar en orange rektangel med en mörkblå kontur, applicerar en 5‑punkts oskärpa och uppdaterar sedan till en 15‑punkts oskärpa genom att anropa [setBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#setBlurEffect-double-boolean-) igen. Det sparar båda oskärpta tillstånden, anropar sedan [disableBlurEffect](https://reference.aspose.com/slides/androidjava/com.aspose.slides/ieffectformat/#disableBlurEffect--) och sparar formen utan oskärpa.

```java
import com.aspose.slides.*;
import android.graphics.Color;

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);

    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 80, 160, 100);
    shape.getFillFormat().setFillType(FillType.Solid);
    shape.getFillFormat().getSolidFillColor().setColor(Color.rgb(255, 165, 0));
    shape.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    shape.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.rgb(0, 0, 139));
    shape.getLineFormat().setWidth(8);

    shape.getEffectFormat().setBlurEffect(5, false);
    presentation.save("shape_blur_5.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().setBlurEffect(15, true);
    presentation.save("shape_blur_15.pptx", SaveFormat.Pptx);

    shape.getEffectFormat().disableBlurEffect();
    presentation.save("shape_blur_removed.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Formoskärpa påverkar både fyllning och kontur tillsammans. En mjukkantseffekt tonar ner formens kanter, medan skuggoskärpa bara mjukar upp skuggan. Bildtransformeringseffekter verkar på bildinnehållet; detta exempel applicerar oskärpa direkt på formens effektformat utan att konvertera formen till en bild.

## **FAQ**

**Kan jag applicera flera effekter på samma form?**

Ja, du kan kombinera olika effekter, såsom skugga, reflektion och glöd, på en enda form för att skapa ett mer dynamiskt utseende.

**Vilka former kan jag applicera effekter på?**

Du kan applicera effekter på olika former, inklusive autoshapes, diagram, tabeller, bilder, SmartArt‑objekt, OLE‑objekt och mer.

**Kan jag applicera effekter på grupperade former?**

Ja, du kan applicera effekter på grupperade former. Effekten kommer att tillämpas på hela gruppen.