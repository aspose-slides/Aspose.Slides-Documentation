---
title: Hantera bläckobjekt i presentationer på Android
linktitle: Hantera bläck
type: docs
weight: 95
url: /sv/androidjava/manage-ink/
keywords:
- bläck
- bläckobjekt
- bläckspår
- hantera bläck
- rita bläck
- ritning
- bläckexport
- bläckrendering
- dölja bläck
- IInkOptions
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Hantera PowerPoint bläckobjekt, redigera spår och penselns egenskaper samt kontrollera bläckens utseende vid export till PDF, HTML, SVG, TIFF och bild med Aspose.Slides för Android."
---
## **Introduktion**

PowerPoint erbjuder en bläckfunktion som låter dig rita fria penseldrag. Bläck kan användas för att markera andra objekt, visa samband och processer samt rikta uppmärksamhet mot specifika element på en bild.

Aspose.Slides tillhandahåller de typer som behövs för att arbeta med bläckobjekt. Till exempel representerar gränssnittet [IInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iink/) ett bläckobjekt på en bild.

## **Skillnader mellan vanliga objekt och bläckobjekt**

Objekt på en PowerPoint‑bild representeras vanligtvis av formobjekt. I sin enklaste form är en form en behållare som definierar objektets område (dess ram) tillsammans med egenskaper såsom behållarens storlek, form och bakgrund. För mer information, se [Shape Layout Format](https://docs.aspose.com/slides/sv/androidjava/shape-manipulations/#access-layout-formats-for-shape).

När PowerPoint däremot hanterar ett bläckobjekt ignorerar den alla egenskaper för objektets ram (behållare) förutom dess storlek. Storleken på behållarområdet bestäms av de standardmetoderna [IShape.getWidth](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getWidth--) och [IShape.getHeight](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishape/#getHeight--) :

![ink_powerpoint1](ink_powerpoint1.png)

## **Bläckspår**

Ett bläckspår är ett grundläggande element som används för att registrera en pennas bana när en användare skriver digitalt bläck. Ett spår lagrar en sekvens av sammankopplade punkter.

Den enklaste kodningsformen specificerar X- och Y-koordinaterna för varje samplingspunkt. När alla sammankopplade punkter renderas bildas en bild som denna:

![ink_powerpoint2](ink_powerpoint2.png)

## **Penselns egenskaper för ritning**

En pensel används för att rita linjer som kopplar ihop punkterna i ett bläckspår. Penseln har sin egen färg och storlek, representerade av metoderna [IInkBrush.getColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkbrush/#getColor--) och [IInkBrush.getSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkbrush/#getSize--) .

### **Ange bläckpenselns färg**

Denna Java‑kod visar hur du anger färgen på en bläckpensel:

```java
import android.graphics.Color;
import com.aspose.slides.*;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    brush.setColor(Color.RED);
} finally {
    presentation.dispose();
}
```

### **Ange bläckpenselns storlek**

Denna Java‑kod visar hur du anger storleken på en bläckpensel:

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("pres.pptx");
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IInk ink = (IInk) slide.getShapes().get_Item(0);
    IInkBrush brush = ink.getTraces()[0].getBrush();
    SizeF brushSize = new SizeF(5, 10);
    brush.setSize(brushSize);
} finally {
    presentation.dispose();
}
```

Generellt matchar en pensels bredd och höjd inte, så PowerPoint visar inte penselns storlek (den motsvarande datasektionen är gråtonad). När penselns bredd och höjd matchar visar PowerPoint dess storlek på följande sätt:

![ink_powerpoint3](ink_powerpoint3.png)

För tydlighetens skull, låt oss öka höjden på bläckobjektet och granska de viktiga dimensionerna:

![ink_powerpoint4](ink_powerpoint4.png)

Behållaren (ramen) tar inte hänsyn till penselns storlek – den antar alltid att linjetjockleken är noll (se föregående bild).

Därför måste penselstorleken för dess spår beaktas för att bestämma det synliga området för hela bläckobjektet. Här har målobjektet (det handskrivna textspåret) skalats till behållarens (ramens) storlek. När behållarens storlek ändras förblir penselstorleken konstant, och vice versa.

![ink_powerpoint5](ink_powerpoint5.png)

PowerPoint använder liknande beteende för textobjekt:

![ink_powerpoint6](ink_powerpoint6.png)

## **Styr bläckens utseende vid export och rendering**

Aspose.Slides tillhandahåller gränssnittet [IInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/) för att kontrollera hur bläckobjekt visas i exporterad eller renderad output. Du kan använda dess egenskaper för att helt dölja bläck eller ändra hur maskoperationer för bläckpenslar tolkas.

Bläckalternativ är tillgängliga genom export‑ eller renderingsalternativen för flera utdatatyper:

| Utdata | Egenskap för bläckalternativ |
| --- | --- |
| PDF | [PdfOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/pdfoptions/#getInkOptions--) |
| HTML | [HtmlOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/htmloptions/#getInkOptions--) |
| SVG | [SVGOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/svgoptions/#getInkOptions--) |
| TIFF | [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) |
| Slide image | [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) |

Följande [IInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/)‑metoder exponeras med samma två inställningar:

- [IInkOptions.getHideInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) bestämmer om bläckobjekt inkluderas i output. Dess standardvärde är `false`.
- [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) bestämmer om en maskoperation tolkas som opacitet när en bläckpensel renderas. Dess standardvärde är `true`; anropa [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) med `false` för att använda ROP‑operationen i stället.

### **Dölj bläckobjekt i PDF‑utdata**

Som standard förblir bläckobjekt synliga vid export. För att skapa en ren output utan handskrivna kommentarer eller annat bläckinnehåll, anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) med `true`.

Följande Java‑exempel exporterar en presentation till PDF samtidigt som alla bläckobjekt döljs:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.getInkOptions().setHideInk(true);

    presentation.save("presentation_without_ink.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

### **Dölj bläckobjekt vid rendering av en bild som bitmap**

För att dölja bläckobjekt vid rendering av bilder som bitmap‑bilder, konfigurera [RenderingOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/renderingoptions/#getInkOptions--) och skicka renderingsalternativen till [ISlide.getImage](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islide/#getImage-com.aspose.slides.IRenderingOptions-).

Följande Java‑exempel renderar den första bilden som en PNG‑bild utan bläckobjekt:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("presentation.pptx");
try {
    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.getInkOptions().setHideInk(true);

    ISlide slide = presentation.getSlides().get_Item(0);
    IImage image = slide.getImage(renderingOptions);
    try {
        image.save("slide_without_ink.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

### **Styr rendering av bläckmask**

Inställningen [IInkOptions.getInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#getInterpretMaskOpAsOpacity--) styr hur maskoperationer tolkas vid rendering av bläckpenslar. Standardvärdet är `true`, vilket använder opacitet. För att i stället använda ROP‑operationen, anropa [IInkOptions.setInterpretMaskOpAsOpacity](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#setInterpretMaskOpAsOpacity-boolean-) med `false`.

Följande Java‑exempel exporterar en bild till SVG och använder ROP‑baserad rendering för bläckmaskoperationer:

```java
import com.aspose.slides.*;
import java.io.FileOutputStream;

Presentation presentation = new Presentation("presentation.pptx");
try {
    SVGOptions svgOptions = new SVGOptions();
    svgOptions.getInkOptions().setInterpretMaskOpAsOpacity(false);

    ISlide slide = presentation.getSlides().get_Item(0);
    FileOutputStream stream = new FileOutputStream("slide.svg");
    try {
        slide.writeAsSvg(stream, svgOptions);
    } finally {
        stream.close();
    }
} finally {
    presentation.dispose();
}
```

Samma inställning kan tillämpas via [TiffOptions.getInkOptions](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/tiffoptions/#getInkOptions--) när en presentation exporteras eller en bild renderas till TIFF.

### **Välj om du vill dölja eller bevara bläck**

När du behöver en ren version av en annoterad presentation för distribution utan granskningsmarkeringar, anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) med `true` under export.

Låt [IInkOptions.getHideInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#getHideInk--) ha sitt standardvärde `false` när bläckanteckningar är en del av det avsedda innehållet, t.ex. granskningskommentarer, handskrivna anteckningar, markeringar eller teckningar som ska vara synliga i det exporterade resultatet. Detta gör att applikationer kan generera separata gransknings‑ och slutresultat från samma presentation utan att ändra de ursprungliga bläckobjekten.

## **Vanliga frågor**

**Kan jag ändra färgen eller storleken på ett befintligt bläcksteg?**

Ja. Hämta spåret från [IInk.getTraces](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iink/#getTraces--), ändra sedan dess [IInkTrace.getBrush](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinktrace/#getBrush--). Anropa [IInkBrush.setColor](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkbrush/#setColor-java.lang.Integer-) eller [IInkBrush.setSize](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkbrush/#setSize-com.aspose.slides.android.SizeF-) för att ändra penseln.

**Påverkar dölja av bläck källpresentationen?**

Nej. Att anropa [IInkOptions.setHideInk](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/iinkoptions/#setHideInk-boolean-) påverkar endast det renderade eller exporterade resultatet; det tar inte bort eller ändrar bläckobjekt i källpresentationen.

**Vilka exportformat stödjer bläckalternativ?**

Du kan konfigurera bläckalternativ för PDF, HTML, SVG, TIFF och bitmap‑bildspel via de motsvarande export‑ eller renderingsalternativen som visas ovan.

**Ytterligare läsning**

* För att läsa om former i allmänhet, se avsnittet [PowerPoint‑former](https://docs.aspose.com/slides/sv/androidjava/powerpoint-shapes/).
* För mer information om effektiva värden, se [Formens effektiva egenskaper](https://docs.aspose.com/slides/sv/androidjava/shape-effective-properties/#get-effective-font-height-value).
* För detaljer om PDF‑export, se [Konvertera PPT och PPTX till PDF](https://docs.aspose.com/slides/sv/androidjava/convert-powerpoint-to-pdf/).
* För detaljer om HTML‑export, se [Konvertera PowerPoint‑presentationer till HTML](https://docs.aspose.com/slides/sv/androidjava/convert-powerpoint-to-html/).
* För detaljer om SVG‑export, se [Rendera presentationsbilder som SVG‑bilder](https://docs.aspose.com/slides/sv/androidjava/render-a-slide-as-an-svg-image/).
* För detaljer om TIFF‑export, se [Konvertera PowerPoint‑presentationer till TIFF](https://docs.aspose.com/slides/sv/androidjava/convert-powerpoint-to-tiff/).
* För detaljer om rendering av bild till bild, se [Konvertera presentationsbilder till bilder](https://docs.aspose.com/slides/sv/androidjava/convert-slide/).