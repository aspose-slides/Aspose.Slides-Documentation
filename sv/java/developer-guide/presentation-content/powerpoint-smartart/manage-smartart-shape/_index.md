---
title: Hantera SmartArt-grafik i presentationer med Java
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/java/manage-smartart-shape/
keywords:
- SmartArt-objekt
- SmartArt-grafik
- SmartArt-stil
- SmartArt-färg
- skapa SmartArt
- lägga till SmartArt
- redigera SmartArt
- ändra SmartArt
- komma åt SmartArt
- SmartArt-layouttyp
- PowerPoint
- presentation
- Java
- Aspose.Slides
description: "Automatisera skapande, redigering och formgivning av PowerPoint SmartArt i Java med Aspose.Slides, med korta kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt-grafik i PowerPoint-presentationer programatiskt. Denna artikel förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt‑stil eller färgstils.

Exemplen visar hur du arbetar med SmartArt-former via presentationens bilds formsamling, kontrollerar om en form är SmartArt och sedan ändrar eller inspekterar dess egenskaper.

## **Skapa en SmartArt-form**
Aspose.Slides for Java har tillhandahållit ett API för att skapa SmartArt-former. För att skapa en SmartArt-form i en bild, följ stegen nedan:

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) .
1. Hämta referensen till en bild genom att använda dess index.
1. [Lägg till en SmartArt-form](https://reference.aspose.com/slides/sv/java/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) genom att ange dess [LayoutType](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArtLayoutType) .
1. Spara den ändrade presentationen som en PPTX‑fil.

```java
// Instansiera Presentation-klass
Presentation pres = new Presentation();
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägg till SmartArt-form
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Sparar presentationen
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form tillagd på bilden**|

## **Åtkomst till en SmartArt-form på en bild**
Följande kod används för att komma åt SmartArt-formerna som lagts till i presentationsbilden. I exempelkoden kommer vi att gå igenom varje form i bilden och kontrollera om den är en [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt). Om formen är av typen SmartArt kommer vi att type‑casta den till en [**SmartArt**](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt) .

```java
// Ladda den önskade presentationen
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt)
        {
            // Typecasta formen till SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en SmartArt-form med en specifik layouttyp**
Följande exempel kod hjälper dig att komma åt [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt) formen med en specifik LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt) formen läggs till.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) och läs in presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt), och type‑casta den valda formen till SmartArt om den är SmartArt.
1. Kontrollera SmartArt-formen med den specifika LayoutType och utför de åtgärder som krävs efteråt.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt)
        {
            // Typecasta formen till SmartArtEx
            ISmartArt smart = (ISmartArt) shape;

            // Kontrollerar SmartArt-layout
            if (smart.getLayout() == SmartArtLayoutType.BasicBlockList)
            {
                System.out.println("Do some thing here....");
            }
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Ändra en SmartArt-forms stil**
I det här exemplet kommer vi att lära oss att ändra snabbstilen för en SmartArt-form.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) och läs in presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt), och type‑casta den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en specifik stil.
1. Ställ in den nya stilen för SmartArt-formen.
1. Spara presentationen.

```java
// Instansiera Presentation-klass
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Gå igenom varje form i den första bilden
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt) 
        {
            // Typecasta formen till SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kontrollerar SmartArt-stil
            if (smart.getQuickStyle() == SmartArtQuickStyleType.SimpleFill) {
                // Ändrar SmartArt-stil
                smart.setQuickStyle(SmartArtQuickStyleType.Cartoon);
            }
        }
    }
    // Sparar presentationen
    pres.save("ChangeSmartArtStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form med ändrad stil**|

## **Ändra en SmartArt-forms färgstil**
I det här exemplet kommer vi att lära oss att ändra färgstilen för en SmartArt-form. I följande exempel kod kommer vi att komma åt SmartArt-formen med en specifik färgstil och ändra dess stil.

1. Skapa en instans av klassen [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/Presentation) och läs in presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av typen [SmartArt](https://reference.aspose.com/slides/sv/java/com.aspose.slides/SmartArt), och type‑casta den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en specifik färgstil.
1. Ställ in den nya färgstilen för SmartArt-formen.
1. Spara presentationen.

```java
// Instansiera Presentation-klass
Presentation pres = new Presentation("SimpleSmartArt.pptx");
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Gå igenom varje form i den första bilden
    for (IShape shape : slide.getShapes()) 
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt) 
        {
            // Typecasta formen till SmartArtEx
            ISmartArt smart = (ISmartArt) shape;
    
            // Kontrollerar SmartArt-färgtyp
            if (smart.getColorStyle() == SmartArtColorType.ColoredFillAccent1) {
                // Ändrar SmartArt-färgtyp
                smart.setColorStyle(SmartArtColorType.ColorfulAccentColors);
            }
        }
    }
    // Sparar presentationen
    pres.save("ChangeSmartArtColorStyle.pptx", SaveFormat.Pptx);
} finally {
    pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/v2Hwocs.png)|
| :- |
|**Figur: SmartArt-form med ändrad färgstil**|

## **Vanliga frågor**

**Kan jag animera SmartArt som ett enda objekt?**

Ja. SmartArt är en form, så du kan använda [standardanimationer](/slides/sv/java/powerpoint-animation/) via animations‑API:et (ingång, utgång, betoning, rörelsebanor) precis som för andra former.

**Hur kan jag hitta ett specifikt SmartArt på en bild om jag inte känner till dess interna ID?**

Ange och använd alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att hitta målformen.

**Kan jag gruppera SmartArt med andra former?**

Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan [manipulera gruppen](/slides/sv/java/group/).

**Hur får jag en bild av ett specifikt SmartArt (t.ex. för en förhandsvisning eller rapport)?**

Exportera en miniatyr/bild av formen; biblioteket kan [rendera individuella former](/slides/sv/java/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Kommer SmartArt-utseendet att bevaras när hela presentationen konverteras till PDF?**

Ja. Rendering‑motorn strävar efter hög trohet för [PDF-export](/slides/sv/java/convert-powerpoint-to-pdf/), med ett antal kvalitets‑ och kompatibilitetsalternativ.