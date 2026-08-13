---
title: Ändra storlek på former på presentationsbilder
type: docs
weight: 110
url: /sv/java/re-sizing-shapes-on-slide/
keywords:
- ändra formstorlek
- ändra storlek på form
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Ändra enkelt storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Java—automatisera justeringar av bildlayouten och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för Java‑kunder är hur man ändrar storlek på former så att, när bildstorleken förändras, data inte kapas bort. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir feljusterade när bildstorleken ändras, uppdatera varje formens position och dimensioner så att de följer den nya bildlayouten.

```java
import com.aspose.slides.*;

// Läs in presentationsfilen.
Presentation presentation = new Presentation("sample.ppt");
try {
    // Hämta den ursprungliga bildstorleken.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Ändra bildstorleken utan att skala befintliga former.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);

    // Hämta den nya bildstorleken.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    // Ändra storlek och flytta om former på varje bild.
    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            
            // Skala formens storlek.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala formens position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" %}} 
Tabeller kräver ingen särskild behandling: att sätta en tabells bredd och höjd omräknar dess kolumner och rader proportionellt, så att skala radhöjder och kolumnbredder igen skulle tillämpa förhållandet två gånger.
{{% /alert %}} 

Koden ovan ändrar endast formerna på bilderna. Masternbilder och layoutbilder behåller sina egna former, så skala även dem när du vill att hela presentationen ska följa den nya bildstorleken:

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Hämta den ursprungliga bildstorleken.
    float currentHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float currentWidth = (float) presentation.getSlideSize().getSize().getWidth();

    // Ändra bildstorleken utan att skala befintliga former.
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    // presentation.getSlideSize().setOrientation(SlideOrientation.Portrait);

    // Hämta den nya bildstorleken.
    float newHeight = (float) presentation.getSlideSize().getSize().getHeight();
    float newWidth = (float) presentation.getSlideSize().getSize().getWidth();

    float heightRatio = newHeight / currentHeight;
    float widthRatio = newWidth / currentWidth;

    for (IMasterSlide master : presentation.getMasters()) {
        for (IShape shape : master.getShapes()) {
            // Skala formens storlek.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala formens position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            for (IShape shape : layoutSlide.getShapes()) {
                // Skala formens storlek.
                shape.setHeight(shape.getHeight() * heightRatio);
                shape.setWidth(shape.getWidth() * widthRatio);

                // Skala formens position.
                shape.setY(shape.getY() * heightRatio);
                shape.setX(shape.getX() * widthRatio);
            }
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            // Skala formens storlek.
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setWidth(shape.getWidth() * widthRatio);

            // Skala formens position.
            shape.setY(shape.getY() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

### Varför blir former förvrängda eller avkapade efter att en bild har ändrats i storlek?

När en bild ändras i storlek behåller formerna sin ursprungliga position och storlek om skalan inte ändras explicit. Detta kan leda till att innehåll kapas bort eller att former blir feljusterade.

### Fungerar den medföljande koden för alla former?

Ja. Att ange höjd och bredd fungerar för textrutor, bilder, diagram och tabeller lika.

### Hur ändrar jag storlek på tabeller när jag ändrar bildens storlek?

Skala själva tabellformen, precis som vilken annan form som helst. Dess rader och kolumner följer proportionellt, så skala dem inte igen efteråt.

### Kommer denna storleksändring att fungera för masterbilder och layoutbilder?

Ja, men du bör också loopa igenom [Masters](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasters--) och [Layout slides](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getLayoutSlides--) och tillämpa samma skalningslogik på deras former för att säkerställa konsekvens i hela presentationen.

### Kan jag ändra orienteringen på en bild (stående/liggande) samtidigt som jag ändrar storlek?

Ja. Du kan använda [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidesize/#setOrientation-int-) för att ändra orienteringen. Se till att du justerar skalningslogiken därefter för att bevara layouten.

### Finns det någon gräns för den bildstorlek jag kan ställa in?

Aspose.Slides stödjer anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

### Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?

Du kan kontrollera metoden `getAspectRatioLocked` för formen innan du skalar. Om den är låst, justera bredd eller höjd proportionellt snarare än att skala dem individuellt.