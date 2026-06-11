---
title: Hantera SmartArt-grafik i presentationer på Android
linktitle: SmartArt-grafik
type: docs
weight: 20
url: /sv/androidjava/manage-smartart-shape/
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
- SmartArt layouttyp
- PowerPoint
- presentation
- Android
- Java
- Aspose.Slides
description: "Automatisera skapande, redigering och styling av PowerPoint SmartArt med Aspose.Slides för Android, med kortfattade Java-kodexempel och prestandafokuserad vägledning."
---
## **Översikt**

Aspose.Slides låter dig skapa och hantera SmartArt-grafik i PowerPoint-presentationer programatiskt. Denna artikel förklarar hur du lägger till en SmartArt-form på en bild, får åtkomst till befintliga SmartArt-former, hittar SmartArt efter en specifik layouttyp och uppdaterar dess visuella utseende genom att ändra SmartArt-stilen eller färgstilen.

Exemplen visar hur du arbetar med SmartArt-former via presentationens bilds formsamling, kontrollerar om en form är SmartArt och sedan modifierar eller inspekterar dess egenskaper.

## **Skapa en SmartArt-form**
Aspose.Slides för Android via Java har tillhandahållit ett API för att skapa SmartArt-former. Följ stegen nedan för att skapa en SmartArt-form i en bild:

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen.
1. Hämta referensen till en bild genom att använda dess Index.
1. [Lägg till en SmartArt-form](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/IShapeCollection#addSmartArt-float-float-float-float-int-) genom att ange dess [LayoutType](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArtLayoutType).
1. Spara den modifierade presentationen som en PPTX-fil.

```java
// Instansiera Presentation-klass
Presentation pres = new Presentation();
try {
    // Hämta första bilden
    ISlide slide = pres.getSlides().get_Item(0);
    
    // Lägg till SmartArt-form
    ISmartArt smart = slide.getShapes().addSmartArt(0, 0, 400, 400, SmartArtLayoutType.BasicBlockList);
    
    // Spara presentationen
    pres.save("SimpleSmartArt.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

|![todo:image_alt_text](https://i.imgur.com/A7PUdeV.png)|
| :- |
|**Figur: SmartArt-form tillagd på bilden**|

## **Åtkomst till en SmartArt-form på en bild**
Följande kod används för att komma åt SmartArt-former som har lagts till i presentationsbilden. I exempelkoden kommer vi att gå igenom varje form i bilden och kontrollera om den är en [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) form. Om formen är av SmartArt-typ kommer vi att typkonvertera den till en [**SmartArt**](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) instans.

```java
// Läs in den önskade presentationen
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
            ISmartArt smart = (ISmartArt)shape;
            System.out.println("Shape Name:" + smart.getName());
        }
    }
} finally {
    if (pres != null) pres.dispose();
}
```

## **Åtkomst till en SmartArt-form med en viss layouttyp**
Följande exempelprogramkod hjälper dig att komma åt [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) formen med en viss LayoutType. Observera att du inte kan ändra LayoutType för SmartArt eftersom den är skrivskyddad och endast sätts när [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) formen läggs till.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) typ och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Kontrollera SmartArt-formen med den specifika LayoutType och utför vad som krävs därefter.

```java
Presentation pres = new Presentation("AccessSmartArtShape.pptx");
try {
    // Gå igenom varje form i den första bilden
    for (IShape shape : pres.getSlides().get_Item(0).getShapes())
    {
        // Kontrollera om formen är av SmartArt-typ
        if (shape instanceof ISmartArt)
        {
            // Typkonvertera formen till SmartArtEx
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

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) typ och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en viss Stil.
1. Ställ in den nya Stilen för SmartArt-formen.
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
            // Typkonvertera formen till SmartArtEx
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

## **Ändra en SmartArt-forms färgstils**
I det här exemplet kommer vi att lära oss att ändra färgstilen för en SmartArt-form. I följande exempelprogramkod kommer vi att komma åt SmartArt-formen med en viss färgstil och ändra dess stil.

1. Skapa en instans av [Presentation](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/Presentation) klassen och ladda presentationen med SmartArt-form.
1. Hämta referensen till den första bilden genom att använda dess Index.
1. Gå igenom varje form i den första bilden.
1. Kontrollera om formen är av [SmartArt](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/SmartArt) typ och typkonvertera den valda formen till SmartArt om den är SmartArt.
1. Hitta SmartArt-formen med en viss Färgstil.
1. Ställ in den nya Färgstilen för SmartArt-formen.
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
            // Typkonvertera formen till SmartArtEx
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
Ja. SmartArt är en form, så du kan använda [standard animationer](/slides/sv/androidjava/powerpoint-animation/) via animations-API:t (ingång, utgång, betoning, rörelsesökvägar) precis som för andra former.

**Hur kan jag hitta en specifik SmartArt på en bild om jag inte känner till dess interna ID?**
Ställ in och använd Alternativ text (AltText) och sök efter formen med det värdet – detta är ett rekommenderat sätt att lokalisera målformen.

**Kan jag gruppera SmartArt med andra former?**
Ja. Du kan gruppera SmartArt med andra former (bilder, tabeller osv.) och sedan [manipulera gruppen](/slides/sv/androidjava/group/).

**Hur får jag en bild av en specifik SmartArt (t.ex. för en förhandsgranskning eller rapport)?**
Exportera en miniatyr/bild av formen; biblioteket kan [rendera enskilda former](/slides/sv/androidjava/create-shape-thumbnails/) till rasterfiler (PNG/JPG/TIFF).

**Behåller SmartArt sitt utseende när hela presentationen konverteras till PDF?**
Ja. Renderingsmotorn strävar efter hög noggrannhet för [PDF-export](/slides/sv/androidjava/convert-powerpoint-to-pdf/), med ett brett urval av kvalitets- och kompatibilitetsalternativ.