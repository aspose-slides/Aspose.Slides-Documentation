---
title: Ändra storlek på former på presentationsbilder i Node.js
type: docs
weight: 130
url: /sv/nodejs-java/resizing-shapes-on-slide/
aliases:
  - /nodejs-java/re-sizing-shapes-on-slide/
  - /sv/nodejs-java/re-sizing-shapes-on-slide/
keywords:
- ändra storlek på form
- ändra formens storlek
- PowerPoint
- OpenDocument
- presentation
- Node.js
- JavaScript
- Aspose.Slides
description: "Enkelt ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Node.js via Java—automatisera bildlayoutjusteringar och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek och flytta om dess former så att de passar de nya dimensionerna. Den här artikeln visar hur man skalar former manuellt och hur man hanterar tabeller på bilder, masterbilder och layouter.

## **Ändra storlek på former**

För att bevara varje formens relativa position och storlek, multiplicera dess horisontella koordinater och bredd med förhållandet mellan den nya bildens bredd och den ursprungliga bredden. Applicera motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet laddar en presentation vars bilder inte innehåller några tabeller, ändrar bildens storlek till A4 och sparar resultatet. Det använder [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize) med [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesizescaletype/#DoNotScale) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formens positioner och dimensioner mäts i punkter. Olika bredd- och höjdförhållanden kan förvränga former, och att ändra en forms dimensioner skalar inte dess teckenstorlekar.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

const presentation = new slides.Presentation("sample.pptx");
try {
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        for (let shapeIndex = 0; shapeIndex < slide.getShapes().size(); shapeIndex++) {
            const shape = slide.getShapes().get_Item(shapeIndex);
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
            shape.setX(java.newFloat(shape.getX() * widthRatio));
            shape.setY(java.newFloat(shape.getY() * heightRatio));
        }
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder istället för att tilldela tabellens övergripande bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stödjer tabeller och bearbetar former på masterbilder och layouter samt enskilda bilder innan den sparar den ändrade presentationen. Dess hjälpfunktion hanterar varje [Table](https://reference.aspose.com/slides/nodejs-java/aspose.slides/table/) genom att skala kolumnbredder med [Column.setWidth](https://reference.aspose.com/slides/nodejs-java/aspose.slides/column/#setWidth) och minsta radhöjder med [Row.setMinimalHeight](https://reference.aspose.com/slides/nodejs-java/aspose.slides/row/#setMinimalHeight). Den skalar sedan tabellens position utan att separat skala dess övergripande dimensioner.

```javascript
const slides = require("aspose.slides.via.java");
const java = require("java");

function resizeShapes(shapes, widthRatio, heightRatio) {
    for (let shapeIndex = 0; shapeIndex < shapes.size(); shapeIndex++) {
        const shape = shapes.get_Item(shapeIndex);
        if (java.instanceOf(shape, "com.aspose.slides.ITable")) {
            const table = shape;
            // Tabellens dimensioner styrs av kolumnbredder och radhöjder.
            for (let columnIndex = 0; columnIndex < table.getColumns().size(); columnIndex++) {
                const column = table.getColumns().get_Item(columnIndex);
                column.setWidth(column.getWidth() * widthRatio);
            }

            for (let rowIndex = 0; rowIndex < table.getRows().size(); rowIndex++) {
                const row = table.getRows().get_Item(rowIndex);
                row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
            }
        }
        else {
            shape.setWidth(java.newFloat(shape.getWidth() * widthRatio));
            shape.setHeight(java.newFloat(shape.getHeight() * heightRatio));
        }

        shape.setX(java.newFloat(shape.getX() * widthRatio));
        shape.setY(java.newFloat(shape.getY() * heightRatio));
    }
}

const presentation = new slides.Presentation("sample.pptx");
try {
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    const originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(slides.SlideSizeType.A4Paper, slides.SlideSizeScaleType.DoNotScale);
    const targetSize = presentation.getSlideSize().getSize();
    const widthRatio = targetSize.getWidth() / originalSize.getWidth();
    const heightRatio = targetSize.getHeight() / originalSize.getHeight();

    // Ändra storlek på former som definierats på masterbilder och layouter samt enskilda bilder.
    for (let masterIndex = 0; masterIndex < presentation.getMasters().size(); masterIndex++) {
        const master = presentation.getMasters().get_Item(masterIndex);
        resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (let layoutSlideIndex = 0; layoutSlideIndex < master.getLayoutSlides().size(); layoutSlideIndex++) {
            const layoutSlide = master.getLayoutSlides().get_Item(layoutSlideIndex);
            resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (let slideIndex = 0; slideIndex < presentation.getSlides().size(); slideIndex++) {
        const slide = presentation.getSlides().get_Item(slideIndex);
        resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", slides.SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**  
Om du ändrar bildens storlek utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla formtyper?**  
Det första exemplet ändrar formens gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar en bilds storlek?**  
Skala kolumnbredder med breddförhållandet och minsta radhöjder med höjdförhållandet, skala sedan tabellens position, enligt det andra exemplet.

**Kommer denna storleksändring att fungera för masterbilder och layoutbilder?**  
Ja. Det andra exemplet itererar genom [Presentation.getMasters](https://reference.aspose.com/slides/nodejs-java/aspose.slides/presentation/#getMasters) och varje masters [MasterSlide.getLayoutSlides](https://reference.aspose.com/slides/nodejs-java/aspose.slides/masterslide/#getLayoutSlides) och tillämpar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) tillsammans med storleksändringen?**  
Ja. Anropa [SlideSize.setOrientation](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setOrientation) efter att du har ändrat bildens storlek och innan du läser målens dimensioner, så att skalningsfaktorerna speglar den slutgiltiga orienteringen.

**Finns det någon begränsning för den bildstorlek jag kan ange?**  
Du kan ange anpassade bilddimensioner med [SlideSize.setSize](https://reference.aspose.com/slides/nodejs-java/aspose.slides/slidesize/#setSize). De stödjade dimensionerna beror också på presentationsformatet och det program som används för att öppna filen.

**Hur kan jag förhindra att former med ett fast bildförhållande blir förvrängda?**  
Använd samma skalningsfaktor för bredd och höjd. För att passa den ursprungliga layouten inom de nya bilddimensionerna, använd den mindre av bredd- och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.