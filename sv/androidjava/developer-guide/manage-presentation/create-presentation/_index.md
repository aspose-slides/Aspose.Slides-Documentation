---
title: Skapa presentationer på Android
linktitle: Skapa presentation
type: docs
weight: 10
url: /sv/androidjava/create-presentation/
keywords:
- skapa presentation
- ny presentation
- skapa PPT
- ny PPT
- skapa PPTX
- ny PPTX
- skapa ODP
- ny ODP
- PowerPoint
- OpenDocument
- presentation
- Android
- Java
- Aspose.Slides
description: "Skapa presentationer i Java med Aspose.Slides för Android — skapa PPT-, PPTX- och ODP-filer, dra nytta av OpenDocument-stöd och spara dem programmässigt för pålitliga resultat."
---
## **Översikt**

Den här artikeln visar hur du skapar en presentation i Aspose.Slides för Android via Java, lägger till en textruta på den första bilden och sparar resultatet som en fil i appens lagring. För att öppna en befintlig presentation eller spara den i ett annat format, se [Open Presentation](/slides/sv/androidjava/open-presentation/) och [Save Presentation](/slides/sv/androidjava/save-presentation/). En kort FAQ i slutet täcker vanliga frågor om format, mallar, bildstorlek, enheter, minnesanvändning, trådar, licensiering, digitala signaturer och VBA-stöd.

Innan du börjar, lägg till Aspose.Slides i ditt Android‑projekt från Asposes Maven‑arkiv. Se [Installation](/slides/sv/androidjava/install-aspose-slides-for-android-via-java/).

## **Skapa en PowerPoint‑presentation**

För att skapa en presentation och placera en textruta på den första bilden, följ dessa steg:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/). En ny presentation innehåller redan en tom bild.
1. Hämta den bilden från [slide collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/islidecollection/) med dess index, 0.
1. Lägg till en rektangel med metoden [addAutoShape](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/#addAutoShape-int-float-float-float-float-) från [shape collection](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ishapecollection/) och sätt texten i dess [text frame](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/) med metoden [setText](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/itextframe/#setText-java.lang.String-).
1. Spara presentationen som en PPTX‑fil med metoden [save](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-), i formatet [SaveFormat.Pptx](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/).

Koden körs inne i en `Activity`, till exempel i dess `onCreate`‑metod. Den sparar filen till katalogen som returneras av metoden [getFilesDir](https://developer.android.com/reference/android/content/Context#getFilesDir()): appens privata lagring, som den kan skriva till utan att begära någon behörighet.

```java
import com.aspose.slides.*;
import java.io.File;

File outputFile = new File(getFilesDir(), "hello.pptx");

Presentation presentation = new Presentation();
try {
    ISlide slide = presentation.getSlides().get_Item(0);
    IAutoShape shape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 50, 50, 400, 100);
    shape.getTextFrame().setText("Hello, Aspose.Slides!");
    presentation.save(outputFile.getAbsolutePath(), SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Rektangelns övre vänstra hörn ligger 50 punkter från vänster kant och 50 punkter från toppen av bilden, och rektangeln är 400 punkter bred och 100 punkter hög. Den sparade filen innehåller en bild med den rektangeln och dess text. Utan licens lägger Aspose.Slides även till en utvärderingsvattenstämpel på varje bild den sparar; se [Licensing](/slides/sv/androidjava/licensing/).

För att titta på filen, öppna Android Studios [Device Explorer](https://developer.android.com/studio/debug/device-file-explorer) och hitta *hello.pptx* under *data/data/*, i *files*-mappen i din app. I en riktig app bör du bearbeta presentationer på en bakgrundstråd så att användargränssnittet förblir responsivt.

## **Vanliga frågor**

### Vilka format kan jag spara en ny presentation till?

Du kan spara till [PPTX, PPT och ODP](/slides/sv/androidjava/save-presentation/), och exportera till [PDF](/slides/sv/androidjava/convert-powerpoint-to-pdf/), [XPS](/slides/sv/androidjava/convert-powerpoint-to-xps/), [HTML](/slides/sv/androidjava/convert-powerpoint-to-html/), [SVG](/slides/sv/androidjava/render-a-slide-as-an-svg-image/), och [bilder](/slides/sv/androidjava/convert-powerpoint-to-png/), bland annat.

### Kan jag starta från en mall (POTX/POTM) och spara som en vanlig PPTX?

Ja. Läs in mallen och spara i önskat format; POTX/POTM/PPTM och liknande format [stöds](/slides/sv/androidjava/supported-file-formats/).

### Hur kontrollerar jag bildstorlek/bildförhållande när jag skapar en presentation?

Ställ in [slide size](/slides/sv/androidjava/slide-size/) (inklusive förinställningar som 4:3 och 16:9 eller egna mått) och välj hur innehållet ska skalas.

### I vilka enheter mäts storlekar och koordinater?

I punkter: 1 tum motsvarar 72 enheter.

### Hur hanterar jag mycket stora presentationer (med många mediafiler) för att minska minnesanvändning?

Använd [BLOB management strategies](/slides/sv/androidjava/manage-blob/), begränsa minneslagring genom att utnyttja temporära filer, och föredra filbaserade arbetsflöden framför enbart minnesströmmar.

### Kan jag skapa/spara presentationer parallellt?

Du kan inte arbeta på samma [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/)-instans från [multiple threads](/slides/sv/androidjava/multithreading/). Kör separata, isolerade instanser per tråd eller process.

### Hur tar jag bort testvattenstämpeln och begränsningarna?

[Apply a license](/slides/sv/androidjava/licensing/) en gång per process. Licens‑XML‑filen måste förbli oförändrad, och licensinställningarna bör synkroniseras om flera trådar är inblandade.

### Kan jag digitalt signera den PPTX jag skapar?

Ja. [Digital signatures](/slides/sv/androidjava/digital-signature-in-powerpoint/) (lägg till och verifiera) stöds för presentationer.

### Stöds makron (VBA) i skapade presentationer?

Ja. Du kan [create/edit VBA projects](/slides/sv/androidjava/presentation-via-vba/) och spara makro‑aktiverade filer som PPTM/PPSM.