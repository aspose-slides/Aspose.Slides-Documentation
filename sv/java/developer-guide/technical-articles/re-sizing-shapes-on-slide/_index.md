---
title: Ändra storlek på former på presentationsbilder i Java
type: docs
weight: 130
url: /sv/java/resizing-shapes-on-slide/
aliases:
  - /java/re-sizing-shapes-on-slide/
  - /sv/java/re-sizing-shapes-on-slide/
keywords:
  - ändra storlek på form
  - ändra formens storlek
  - PowerPoint
  - OpenDocument
  - presentation
  - Java
  - Aspose.Slides
description: "Enkelt ändra storlek på former på PowerPoint- och OpenDocument-bilder med Aspose.Slides för Java — automatisera justering av bildlayout och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek på och flytta dess former så att de passar de nya måtten. Denna artikel visar hur man skalar former manuellt och hur man hanterar tabeller på bilder, huvudbilder och layouter.

## **Ändra storlek på former**

För att bevara varje formes relativa position och storlek, multiplicera dess horisontella koordinater och bredd med förhållandet mellan den nya bildbredden och den ursprungliga bredden. Använd motsvarande höjdförhållande på dess vertikala koordinater och höjd.

Det första exemplet laddar en presentation vars bilder inte innehåller tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-int-int-) med [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/java/com.aspose.slides/slidesizescaletype/#DoNotScale) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formernas positioner och dimensioner mäts i punkter. Olika bredd‑ och höjdförhållanden kan förvränga former, och att ändra en forms dimensioner skalar inte dess teckenstorlekar.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    for (ISlide slide : presentation.getSlides()) {
        for (IShape shape : slide.getShapes()) {
            shape.setWidth(shape.getWidth() * widthRatio);
            shape.setHeight(shape.getHeight() * heightRatio);
            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
Tabeller kräver separat hantering: skala deras kolumnbredder och radhöjder istället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stöder tabeller och bearbetar former på huvudbilder och layouter samt på enskilda bilder innan den sparade den ändrade presentationen. Dess hjälpfunktion hanterar varje [ITable](https://reference.aspose.com/slides/java/com.aspose.slides/itable/) genom att skala kolumnbredder med [IColumn.setWidth](https://reference.aspose.com/slides/java/com.aspose.slides/icolumn/#setWidth-double-) och minsta radhöjder med [IRow.setMinimalHeight](https://reference.aspose.com/slides/java/com.aspose.slides/irow/#setMinimalHeight-double-). Den skalar sedan tabellens position utan att separat skala dess totala dimensioner.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

class ShapeResizer {
    void resizeShapes(IShapeCollection shapes, float widthRatio, float heightRatio) {
        for (IShape shape : shapes) {
            if (shape instanceof ITable) {
                ITable table = (ITable) shape;
                // Tabellens dimensioner styrs av kolumnbredder och radhöjder.
                for (IColumn column : table.getColumns()) {
                    column.setWidth(column.getWidth() * widthRatio);
                }

                for (IRow row : table.getRows()) {
                    row.setMinimalHeight(row.getMinimalHeight() * heightRatio);
                }
            }
            else {
                shape.setWidth(shape.getWidth() * widthRatio);
                shape.setHeight(shape.getHeight() * heightRatio);
            }

            shape.setX(shape.getX() * widthRatio);
            shape.setY(shape.getY() * heightRatio);
        }
    }
}

Presentation presentation = new Presentation("sample.pptx");
try {
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    Dimension2D originalSize = presentation.getSlideSize().getSize();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    Dimension2D targetSize = presentation.getSlideSize().getSize();
    float widthRatio = (float) (targetSize.getWidth() / originalSize.getWidth());
    float heightRatio = (float) (targetSize.getHeight() / originalSize.getHeight());

    ShapeResizer resizer = new ShapeResizer();

    // Ändra storlek på former som är definierade på huvudbilder och layouter samt enskilda bilder.
    for (IMasterSlide master : presentation.getMasters()) {
        resizer.resizeShapes(master.getShapes(), widthRatio, heightRatio);

        for (ILayoutSlide layoutSlide : master.getLayoutSlides()) {
            resizer.resizeShapes(layoutSlide.getShapes(), widthRatio, heightRatio);
        }
    }

    for (ISlide slide : presentation.getSlides()) {
        resizer.resizeShapes(slide.getShapes(), widthRatio, heightRatio);
    }

    presentation.save("output.pptx", SaveFormat.Pptx);
}
finally {
    presentation.dispose();
}
```

## **Vanliga frågor**

**Varför blir former förvrängda eller avklippta efter att en bild har ändrats i storlek?**

Om du ändrar bildstorleken utan att skala formerna behåller de sina ursprungliga positioner och dimensioner och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla typer av former?**

Det första exemplet ändrar formens gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar bildens storlek?**

Skala kolumnbredder med breddförhållandet och minsta radhöjder med höjdförhållandet, skala sedan tabellens position, som visas i det andra exemplet.

**Fungerar denna storleksändring för huvudbilder och layoutbilder?**

Ja. Det andra exemplet itererar genom [Presentation.getMasters](https://reference.aspose.com/slides/java/com.aspose.slides/presentation/#getMasters--) och varje huvudbilds [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/java/com.aspose.slides/imasterslide/#getLayoutSlides--) och applicerar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storlek?**

Ja. Anropa [SlideSize.setOrientation](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setOrientation-int-) efter att du ändrat bildstorleken och innan du läser målmåtten, så att skalfaktorerna speglar den slutliga orienteringen.

**Finns det en gräns för hur stor bild jag kan ange?**

Du kan ange anpassade bildmått med [SlideSize.setSize](https://reference.aspose.com/slides/java/com.aspose.slides/slidesize/#setSize-float-float-int-). De stödjade måtten beror också på presentationsformatet och den applikation som används för att öppna filen.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Använd samma skalfaktor för bredd och höjd. För att få den ursprungliga layouten att passa inom de nya bildmåtten, använd det mindre av bredd‑ och höjdförhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.