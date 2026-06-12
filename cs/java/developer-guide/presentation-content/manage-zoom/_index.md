---
title: Spravovat zoom prezentace v Javě
linktitle: Spravovat zoom
type: docs
weight: 60
url: /cs/java/manage-zoom/
keywords:
- zoom
- rámec zoomu
- zoom snímku
- zoom sekce
- zoom shrnutí
- přidat zoom
- PowerPoint
- prezentace
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro Java — přeskakujte mezi sekcemi, přidávejte miniatury a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet na konkrétní snímky, sekce a části prezentace a zpět. Když prezentujete, tato schopnost rychle se pohybovat po obsahu může být velmi užitečná. 

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Shrnutí Zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Zoom snímku](#Slide-Zoom).
* Pro zobrazení jedné sekce použijte [Zoom sekce](#Section-Zoom).

## **Zoom snímku**
Zoom snímku může učinit vaši prezentaci dynamičtější, umožní vám volně přecházet mezi snímky v libovolném pořadí, aniž byste přerušili průběh prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých prezentačních scénářích.

Zoomy snímků vám pomáhají prozkoumat více informací, přičemž máte pocit, že jste na jediné ploše. 

![overview_image](slidezoomsel.png)

Pro objekty Zoom snímku poskytuje Aspose.Slides výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ZoomImageType) , rozhraní [IZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IZoomFrame) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).

### **Vytvoření Zoom rámců**

Můžete přidat Zoom rámec na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nové snímky, na které chcete odkazovat Zoom rámce. 
3. Přidejte identifikační text a pozadí k vytvořeným snímkům.
4. Přidejte Zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Přidá nové snímky do prezentace
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Vytvoří pozadí pro druhý snímek
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Vytvoří textové pole pro druhý snímek
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Vytvoří pozadí pro třetí snímek
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Přidá objekty ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Vytvoření Zoom rámců s vlastními obrázky**
S Aspose.Slides pro Java můžete vytvořit Zoom rámec s jiným náhledem snímku tímto způsobem: 
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nový snímek, na který chcete odkazovat Zoom rámec. 
3. Přidejte identifikační text a pozadí k snímku.
4. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images asociované s objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
5. Přidejte Zoom rámce (obsahující odkaz na vytvořený snímek) na první snímek.
6. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Vytvoří pozadí pro druhý snímek
    slide.getBackground().setType(BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Vytvoří textové pole pro třetí snímek
    IAutoShape autoshape = slide.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Vytvoří nový obrázek pro objekt zoomu
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Přidá objekt ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formátování Zoom rámců**
V předchozích sekcích jsme vám ukázali, jak vytvořit jednoduché Zoom rámce. Pro vytvoření složitějších Zoom rámců musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na Zoom rámec použít. 

Můžete řídit formátování Zoom rámce na snímku tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nové snímky, na které chcete odkazovat Zoom rámec. 
3. Přidejte identifikační text a pozadí k vytvořeným snímkům.
4. Přidejte Zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images asociované s objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
6. Nastavte vlastní obrázek pro první objekt Zoom rámce.
7. Změňte formát čáry pro druhý objekt Zoom rámce.
8. Odstraňte pozadí z obrázku druhého objektu Zoom rámce.
9. Zapište upravenou prezentaci jako soubor PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Přidá nové snímky do prezentace
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    // Vytvoří pozadí pro druhý snímek
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    // Vytvoří textové pole pro druhý snímek
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    // Vytvoří pozadí pro třetí snímek
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Přidá objekty ZoomFrame
    IZoomFrame zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    // Vytvoří nový obrázek pro objekt zoomu
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Nastaví vlastní obrázek pro objekt zoomFrame1
    zoomFrame1.setImage(picture);

    // Nastaví formát zoom rámce pro objekt zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Nastavení pro neukazovat pozadí pro objekt zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete použít Zoomy sekce k návratu na sekce, které chcete opravdu zdůraznit. Nebo je můžete použít k zvýraznění toho, jak určité části vaší prezentace spolu souvisejí. 

![overview_image](seczoomsel.png)

Pro objekty Zoom sekce poskytuje Aspose.Slides rozhraní [ISectionZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISectionZoomFrame) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).

### **Vytvoření Zoom rámců sekce**

Můžete přidat Zoom rámec sekce na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nový snímek. 
3. Přidejte identifikační pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, na kterou chcete odkazovat Zoom rámec. 
5. Přidejte Zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    // Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Vytvoření Zoom rámců sekce s vlastními obrázky**

Pomocí Aspose.Slides pro Java můžete vytvořit Zoom rámec sekce s jiným náhledem snímku tímto způsobem: 

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nový snímek.
3. Přidejte identifikační pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, na kterou chcete odkazovat Zoom rámec. 
5. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images asociované s objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
6. Přidejte Zoom rámec sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
7. Zapište upravenou prezentaci jako soubor PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    // Vytvoří nový obrázek pro objekt zoomu
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) image.dispose();
    }

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formátování Zoom rámců sekce**

Pro vytvoření složitějších Zoom rámců sekce musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na Zoom rámec sekce použít. 

Můžete řídit formátování Zoom rámce sekce na snímku tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nový snímek.
3. Přidejte identifikační pozadí k vytvořenému snímku.
4. Vytvořte novou sekci, na kterou chcete odkazovat Zoom rámec. 
5. Přidejte Zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6. Změňte velikost a pozici vytvořeného objektu Zoom sekce.
7. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images asociované s objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
8. Nastavte vlastní obrázek pro vytvořený objekt Zoom sekce.
9. Nastavte možnost *návratu na původní snímek z propojené sekce*.
10. Odstraňte pozadí z obrázku objektu Zoom sekce.
11. Změňte formát čáry pro druhý objekt Zoom.
12. Změňte dobu trvání přechodu.
13. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    // Formátování pro SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);

    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
         picture = pres.getImages().addImage(image);
     } finally {
        if (image != null) image.dispose();
     }
    sectionZoomFrame.setImage(picture);

    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);

    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.gray);
    sectionZoomFrame.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5f);

    sectionZoomFrame.setTransitionDuration(1.5f);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom shrnutí**

Zoom shrnutí je jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete Zoom použít k přechodu z jednoho místa v prezentaci na jiné v libovolném pořadí. Můžete být kreativní, přeskakovat dopředu nebo se vracet k částem prezentace, aniž byste narušili její tok.

![overview_image](sumzoomsel.png)

Pro objekty Zoom shrnutí poskytuje Aspose.Slides rozhraní [ISummaryZoomFrame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISummaryZoomSection) a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISummaryZoomSectionCollection) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IShapeCollection).

### **Vytvoření Zoom shrnutí**

Můžete přidat Zoom shrnutí na snímek tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3. Přidejte Zoom shrnutí na první snímek.
4. Zapište upravenou prezentaci jako soubor PPTX.

``` java 
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 3", slide);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.green);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 4", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Přidání a odebrání sekce Zoom shrnutí**

Všechny sekce v Zoom shrnutí jsou reprezentovány objekty [ISummaryZoomSection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISummaryZoomSection), které jsou uloženy v objektu [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ISummaryZoomSectionCollection). Sekci Zoom shrnutí můžete přidat nebo odebrat přes rozhraní [ISummaryZoomSectionCollection] tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3. Přidejte Zoom shrnutí do prvního snímku.
4. Přidejte nový snímek a sekci do prezentace.
5. Přidejte vytvořenou sekci do Zoom shrnutí.
6. Odeberte první sekci ze Zoom shrnutí.
7. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.magenta);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    ISection section3 = pres.getSections().addSection("Section 3", slide);

    // Přidá sekci do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);

    // Odebere sekci ze Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```

### **Formátování sekcí Zoom shrnutí**

Pro vytvoření složitějších objektů sekcí Zoom shrnutí musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce Zoom shrnutí použít. 

Můžete řídit formátování objektu sekce Zoom shrnutí v Zoom shrnutí tímto způsobem:

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation).
2. Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3. Přidejte Zoom shrnutí do prvního snímku.
4. Získejte objekt sekce Zoom shrnutí pro první objekt z `ISummaryZoomSectionCollection`.
5. Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/IPPImage) přidáním obrázku do kolekce images asociované s objektem [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
6. Nastavte vlastní obrázek pro vytvořený objekt Zoom sekce.
7. Nastavte možnost *návratu na původní snímek z propojené sekce*.
8. Změňte formát čáry pro druhý objekt Zoom rámce.
9. Změňte dobu trvání přechodu.
10. Zapište upravenou prezentaci jako soubor PPTX.

``` java
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.gray);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);

    // Získá první objekt SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);

    // Formátování pro objekt SummaryZoomSection
    IPPImage picture;
    IImage image = Images.fromFile("image.png");
    try {
    picture = pres.getImages().addImage(picture);
    } finally {
          if (image != null) image.dispose();
    }
    summarySection.setImage(picture);

    summarySection.setReturnToParent(false);

    summarySection.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.black);
    summarySection.getLineFormat().setDashStyle(LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5f);

    summarySection.setTransitionDuration(1.5f);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Často kladené otázky**

**Mohu řídit návrat na nadřazený snímek po zobrazení cíle?**

Ano. Zoom rámec ([Zoom frame](https://reference.aspose.com/slides/cs/java/com.aspose.slides/zoomframe/)) nebo sekce ([section](https://reference.aspose.com/slides/cs/java/com.aspose.slides/sectionzoomframe/)) má vlastnost `ReturnToParent`, která při povolení po návštěvě cílového obsahu vrátí diváky zpět na výchozí snímek.

**Mohu upravit “rychlost” nebo dobu trvání přechodu Zoomu?**

Ano. Zoom podporuje nastavení `TransitionDuration`, takže můžete řídit, jak dlouho trvá animace skoku.

**Existují omezení, kolik Zoom objektů může prezentace obsahovat?**

Neexistuje pevně stanovený limit API, který by byl dokumentován. Praktická omezení závisí na celkové složitosti prezentace a výkonu zařízení. Můžete přidat mnoho Zoom rámců, ale zvažte velikost souboru a dobu renderování.