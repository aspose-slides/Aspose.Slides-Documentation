---
title: Ändra storlek på former på presentationsbilder
type: docs
weight: 110
url: /sv/java/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Skala enkelt former på PowerPoint- och OpenDocument-bilder med Aspose.Slides för Java—automatisera justeringar av bildlayout och öka produktiviteten."
---
## **Översikt**

En av de vanligaste frågorna från Aspose.Slides för Java‑kunder är hur man ändrar storlek på former så att, när bildens storlek ändras, informationen inte kapas bort. Denna korta tekniska artikel visar hur man gör det.

## **Ändra storlek på former**

För att förhindra att former blir feljusterade när bildens storlek ändras, uppdatera varje forms position och dimensioner så att de anpassas till den nya bildlayouten.

```java
// Ladda presentationsfilen.
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

    // Ändra storlek och ompositionera former på varje bild.
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

{{% alert color="primary" %}} 
Om en bild innehåller en tabell kommer koden ovan inte att fungera korrekt. I så fall måste varje cell i tabellen ändras i storlek.
{{% /alert %}} 

Använd följande kod på din sida för att ändra storlek på bilder som innehåller tabeller. För tabeller är det en speciell situation att sätta bredd eller höjd: du måste justera enskilda radhöjder och kolumnbredder för att ändra tabellens totala storlek.

```java
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
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                for (int i = 0; i < table.getRows().size(); i++) {
                    IRow row = table.getRows().get_Item(i);
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
                for (int j = 0; j < table.getColumns().size(); j++) {
                    IColumn column = table.getColumns().get_Item(j);
                    column.setWidth(column.getWidth() * widthRatio);
                }
            }
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

När en bild ändras i storlek behåller former sina ursprungliga position och storlek om skalan inte uttryckligen ändras. Detta kan leda till att innehållet beskärs eller att former blir feljusterade.

**Fungerar den medföljande koden för alla typer av former?**

Det grundläggande exemplet fungerar för de flesta former (textrutor, bilder, diagram osv.). För tabeller måste du dock hantera rader och kolumner separat, eftersom en tabells höjd och bredd bestäms av dimensionerna på de enskilda cellerna.

**Hur ändrar jag storlek på tabeller när jag ändrar storlek på en bild?**

Du måste iterera igenom alla rader och kolumner i tabellen och ändra deras höjd och bredd proportionellt, som visas i det andra kodexemplet.

**Kommer denna storleksändring att fungera för masterbilder och layoutbilder?**

Ja, men du bör också iterera genom [Masterbilder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getMasters--) och [Layoutbilder](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getLayoutSlides--) och tillämpa samma skalningslogik på deras former för att säkerställa konsistens i hela presentationen.

**Kan jag ändra orienteringen på en bild (porträtt/landskaps) samtidigt som jag ändrar storlek?**

Ja. Du kan använda [presentation.getSlideSize().setOrientation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/islidesize/#setOrientation-int-) för att ändra orienteringen. Se till att du anpassar skalningslogiken så att layouten bevaras.

**Finns det någon gräns för den bildstorlek jag kan ange?**

Aspose.Slides stöder anpassade storlekar, men mycket stora storlekar kan påverka prestanda eller kompatibilitet med vissa versioner av PowerPoint.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Du kan kontrollera metoden `getAspectRatioLocked` för formen innan du skalar. Om den är låst, justera bredden eller höjden proportionellt i stället för att skala dem individuellt.