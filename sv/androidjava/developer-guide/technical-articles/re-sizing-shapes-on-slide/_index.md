---
title: Ändra storlek på former på presentationsbilder på Android
type: docs
weight: 130
url: /sv/androidjava/resizing-shapes-on-slide/
aliases:
  /androidjava/andra-storlek-pa-former-pa-bild/
keywords:
  - ändra formstorlek
  - ändra formens storlek
  - PowerPoint
  - OpenDocument
  - presentation
  - Android
  - Aspose.Slides
description: "Enkelt ändra storlek på former i PowerPoint- och OpenDocument-bilder med Aspose.Slides för Android via Java—automatisera anpassning av bildlayout och öka produktiviteten."
---
## **Översikt**

När du ändrar en presentations bildstorlek kan du också behöva ändra storlek på och omplacera dess former så att de passar de nya dimensionerna. Den här artikeln visar hur du skalar former manuellt och hur du hanterar tabeller på bilder, masterbilder och layouter.

## **Ändra storlek på former**

För att bevara varje formas relativa position och storlek, multiplicera dess horisontella koordinater och bredd med förhållandet mellan den nya bildens bredd och den ursprungliga bredden. Använd motsvarande höjdförhållande för dess vertikala koordinater och höjd.

Det första exemplet läser in en presentation vars bilder inte innehåller några tabeller, ändrar bildstorleken till A4 och sparar resultatet. Det använder [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-int-int-) med [SlideSizeScaleType.DoNotScale](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesizescaletype/#DoNotScale) så att den efterföljande loopen styr skalningen. Förhållandena är enhetslösa; formernas positioner och mått mäts i punkter. Olika bredd‑ och höjdförhållanden kan förvränga former, och att ändra en forms mått skalar inte dess teckenstorlekar.

```java
import com.aspose.slides.*;

Presentation presentation = new Presentation("sample.pptx");
try {
    // Beräkna oberoende horisontella och vertikala skalningsfaktorer.
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

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
Tabeller kräver separat hantering: skalera deras kolumnbredder och radhöjder istället för att tilldela tabellens totala bredd och höjd. Radhöjder kan förbli större än begärt om cellinnehållet kräver mer utrymme.
{{% /alert %}}

Det andra exemplet stödjer tabeller och bearbetar former på master‑bilder och layouter såväl som enskilda bilder innan den storleksändrade presentationen sparas. Dess hjälpfunktion hanterar varje [ITable](https://reference.aspose.com/slides/androidjava/com.aspose.slides/itable/) genom att skala kolumnbredder med [IColumn.setWidth](https://reference.aspose.com/slides/androidjava/com.aspose.slides/icolumn/#setWidth-double-) och minsta radhöjder med [IRow.setMinimalHeight](https://reference.aspose.com/slides/androidjava/com.aspose.slides/irow/#setMinimalHeight-double-). Den skalar sedan tabellens position utan att separat skala dess totala mått.

```java
import com.aspose.slides.*;

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
    float originalWidth = (float) presentation.getSlideSize().getSize().getWidth();
    float originalHeight = (float) presentation.getSlideSize().getSize().getHeight();
    presentation.getSlideSize().setSize(SlideSizeType.A4Paper, SlideSizeScaleType.DoNotScale);
    float widthRatio = (float) presentation.getSlideSize().getSize().getWidth() / originalWidth;
    float heightRatio = (float) presentation.getSlideSize().getSize().getHeight() / originalHeight;

    ShapeResizer resizer = new ShapeResizer();

    // Ändra storlek på former definierade på masterbilder och layouter samt enskilda bilder.
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

## **FAQ**

**Varför blir former förvrängda eller avklippta efter att bildens storlek ändrats?**

Om du ändrar bildens storlek utan att skala formerna behåller de sina ursprungliga positioner och mått och kan sträcka sig utanför bilden. Att skala bredd och höjd med olika förhållanden kan också förvränga former.

**Fungerar den medföljande koden för alla formtyper?**

Det första exemplet ändrar formernas gränser direkt och är avsett för bilder utan tabeller. Det andra exemplet hanterar tabeller separat. Kontrollera den resulterande layouten, särskilt text och tabeller, eftersom dessa exempel inte skalar teckenstorlekar och tabellinnehåll kan begränsa radhöjder.

**Hur ändrar jag storlek på tabeller när jag ändrar bildens storlek?**

Skala kolumnbredder med bredd‑förhållandet och minsta radhöjder med höjd‑förhållandet, och skala sedan tabellens position, som visas i det andra exemplet.

**Fungerar denna storleksändring för master‑bilder och layout‑bilder?**

Ja. Det andra exemplet itererar genom [Presentation.getMasters](https://reference.aspose.com/slides/androidjava/com.aspose.slides/presentation/#getMasters--) och varje masters [IMasterSlide.getLayoutSlides](https://reference.aspose.com/slides/androidjava/com.aspose.slides/imasterslide/#getLayoutSlides--) och tillämpar samma storleksändringslogik på deras former.

**Kan jag ändra orienteringen på en bild (porträtt/landskap) samtidigt som jag ändrar storleken?**

Ja. Anropa [SlideSize.setOrientation](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setOrientation-int-) efter att du har ändrat bildens storlek och innan du läser av målmåtten, så att skalfaktorerna återspeglar den slutgiltiga orienteringen.

**Finns det någon gräns för den bildstorlek jag kan ange?**

Du kan ange egna bilddimensioner med [SlideSize.setSize](https://reference.aspose.com/slides/androidjava/com.aspose.slides/slidesize/#setSize-float-float-int-). De stödjda dimensionerna beror också på presentationsformatet och det program som används för att öppna filen.

**Hur kan jag förhindra att former med fast bildförhållande blir förvrängda?**

Använd samma skalfaktor för bredd och höjd. För att få den ursprungliga layouten att passa i de nya bildmåtten, använd det mindre av bredd‑ och höjd‑förhållandena för både dimensioner och positioner. Detta bevarar proportionerna men kan lämna oanvänt utrymme längs en kant.