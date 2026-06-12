---
title: Spravovat zoom prezentace na Androidu
linktitle: Spravovat zoom
type: docs
weight: 60
url: /cs/androidjava/manage-zoom/
keywords:
- zoom
- rámec zoomu
- zoom snímku
- zoom sekce
- souhrnný zoom
- přidat zoom
- PowerPoint
- prezentace
- Android
- Java
- Aspose.Slides
description: "Vytvořte a přizpůsobte zoom pomocí Aspose.Slides pro Android v Javě — přecházejte mezi sekcemi, přidávejte miniatury a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet mezi konkrétními snímky, sekcemi a částmi prezentace. Když prezentujete, tato schopnost rychle se orientovat v obsahu může být velmi užitečná. 

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jednom snímku použijte [Souhrnný zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Zoom snímku](#Slide-Zoom).
* Pro zobrazení jedné sekce použijte [Zoom sekce](#Section-Zoom).

## **Zoom snímku**
Zoom snímku může učinit vaši prezentaci dynamičtější a umožní vám volně přecházet mezi snímky v libovolném pořadí, aniž byste narušili plynulost prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých jiných scénářích.

Zoomy snímků vám pomáhají podrobně zkoumat více informací, přičemž máte pocit, že pracujete na jedné plátně. 

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku poskytuje Aspose.Slides výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ZoomImageType), rozhraní [IZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IZoomFrame) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).

### **Vytvoření zoomových rámců**

Zoomový rámec můžete na snímku přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nové snímky, ke kterým chcete zoomové rámečky propojit. 
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámečky (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit zoomový rámec na snímku:

``` java
Presentation pres = new Presentation();
try {
    //Přidá nové snímky do prezentace
    ISlide slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    ISlide slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());

    //Vytvoří pozadí pro druhý snímek
    slide2.getBackground().setType(BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(Color.cyan);

    //Vytvoří textové pole pro druhý snímek
    IAutoShape autoshape = slide2.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");

    //Vytvoří pozadí pro třetí snímek
    slide3.getBackground().setType(BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(Color.darkGray);

    //Vytvoří textové pole pro třetí snímek
    autoshape = slide3.getShapes().addAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");

    //Přidá objekty ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);

    //Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Vytvoření zoomových rámců s vlastními obrázky**
S Aspose.Slides for Android via Java můžete vytvořit zoomový rámec s jiným náhledem snímku takto:
1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nový snímek, ke kterému chcete zoomový rámec propojit. 
3.	Přidejte identifikační text a pozadí k snímku.
4.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
5.	Přidejte zoomové rámečky (obsahující odkaz na vytvořený snímek) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit zoomový rámec s jiným obrázkem:

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

    // Vytvoří nový obrázek pro zoom objekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    //Přidá objekt ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);

    //Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```
### **Formátování zoomových rámců**
V předchozích sekcích jsme vám ukázali, jak vytvořit jednoduché zoomové rámečky. Pro vytvoření složitějších zoomových rámců musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoomový rámec použít. 

Formátování zoomového rámce na snímku můžete ovládat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nové snímky, ke kterým chcete zoomový rámec propojit. 
3.	Přidejte nějaký identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoomové rámečky (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro první objekt zoomového rámce.
7.	Změňte formát čáry pro druhý objekt zoomového rámce.
8.	Odeberte pozadí z obrázku druhého objektu zoomového rámce.
5.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak změnit formátování zoomového rámce na snímku: 

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

    // Vytvoří nový obrázek pro zoom objekt
    IPPImage picture;
        IImage image = Images.fromFile("image.png");
        try {
            picture = pres.getImages().addImage(image);
        } finally {
            if (image != null) image.dispose();
        }
    // Nastaví vlastní obrázek pro objekt zoomFrame1
    zoomFrame1.setImage(picture);

    // Nastaví formát zoomového rámce pro objekt zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(FillType.Solid);
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(Color.pink);
    zoomFrame2.getLineFormat().setDashStyle(LineDashStyle.DashDot);

    // Nastavení pro nezobrazovat pozadí u objektu zoomFrame2
    zoomFrame2.setShowBackground(false);

    // Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete jej použít k návratu na sekce, které chcete zvláště zdůraznit. Nebo jej můžete použít k zvýraznění toho, jak se určité části prezentace navzájem spojují. 

![overview_image](seczoomsel.png)

Pro objekty zoomu sekce poskytuje Aspose.Slides rozhraní [ISectionZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISectionZoomFrame) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).

### **Vytvoření zoomových rámců sekce**

Zoomový rámec sekce můžete na snímku přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete zoomový rámec propojit. 
5.	Přidejte zoomový rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit zoomový rámec na snímku:

``` java
Presentation pres = new Presentation();
try {
    //Přidá nový snímek do prezentace
    ISlide slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(FillType.Solid);
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(Color.yellow);
    slide.getBackground().setType(BackgroundType.OwnBackground);

    //Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);

    //Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));

    //Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} finally {
    if (pres != null) pres.dispose();
}
```
### **Vytvoření zoomových rámců sekce s vlastními obrázky**

Pomocí Aspose.Slides for Android via Java můžete vytvořit zoomový rámec sekce s jiným náhledem snímku takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete zoomový rámec propojit. 
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
5.	Přidejte zoomový rámec sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit zoomový rámec s jiným obrázkem:

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

    // Vytvoří nový obrázek pro zoom objekt
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
### **Formátování zoomových rámců sekce**

Pro vytvoření složitějších zoomových rámců sekce musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoomový rámec sekce aplikovat. 

Formátování zoomového rámce sekce na snímku můžete ovládat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete zoomový rámec propojit. 
5.	Přidejte zoomový rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Změňte velikost a umístění vytvořeného objektu zoomu sekce.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoomu sekce.
9.	Nastavte možnost *návratu na původní snímek z propojené sekce*. 
10.	Odeberte pozadí z obrázku objektu zoomu sekce.
11.	Změňte formát čáry pro druhý objekt zoomu.
12.	Změňte dobu trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak změnit formátování zoomového rámce sekce:

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

    //Uloží prezentaci
    pres.save("presentation.pptx", SaveFormat.Pptx);
} catch(IOException e) {
} finally {
    if (pres != null) pres.dispose();
}
```


## **Souhrnný zoom**

Souhrnný zoom funguje jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete pomocí zoomu přecházet z jednoho místa v prezentaci na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem prezentace, aniž byste narušili její plynulost.

![overview_image](sumzoomsel.png)

Pro objekty souhrnného zoomu poskytuje Aspose.Slides rozhraní [ISummaryZoomFrame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomFrame), [ISummaryZoomSection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomSection) a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IShapeCollection).

### **Vytvoření souhrnného zoomu**

Souhrnný zoomový rámec můžete na snímku přidat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámec na první snímek.
4.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak vytvořit souhrnný zoomový rámec na snímku:

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

### **Přidání a odebrání sekce souhrnného zoomu**

Všechny sekce v souhrnném zoomovém rámci jsou reprezentovány objekty [ISummaryZoomSection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomSection), které jsou uloženy v objektu [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomSectionCollection). Můžete přidávat nebo odebírat sekci souhrnného zoomu prostřednictvím rozhraní [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISummaryZoomSectionCollection) takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámec do prvního snímku.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do souhrnného zoomového rámce.
6.	Odeberte první sekci ze souhrnného zoomového rámce.
7.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak přidat a odebrat sekce v souhrnném zoomovém rámci:

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

### **Formátování sekcí souhrnného zoomu**

Pro vytvoření složitějších objektů sekcí souhrnného zoomu musíte změnit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce souhrnného zoomu aplikovat. 

Formátování objektu sekce souhrnného zoomu v souhrnném zoomovém rámci můžete ovládat takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoomový rámec na první snímek.
4.	Získejte objekt sekce souhrnného zoomu pro první objekt z `ISummaryZoomSectionCollection`.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/IPPImage) přidáním obrázku do kolekce images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoomu sekce.
9.	Nastavte možnost *návratu na původní snímek z propojené sekce*. 
11.	Změňte formát čáry pro druhý objekt zoomu.
12.	Změňte dobu trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

Tento Java kód ukazuje, jak změnit formátování objektu sekce souhrnného zoomu:

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

    //Adds a new slide to the presentation
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

    // Formátování objektu SummaryZoomSection
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

**Mohu ovládat návrat na „rodičovský“ snímek po zobrazení cíle?**

Ano. [Zoom frame](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/zoomframe/) nebo [section](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/sectionzoomframe/) má chování návratu na rodiče, které při povolení po návštěvě cílového obsahu pošle diváky zpět na výchozí snímek.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoomu?**

Ano. Zoom podporuje nastavení doby trvání přechodu, takže můžete ovládat, jak dlouho trvá animace skoku.

**Existují omezení počtu Zoom objektů, které může prezentace obsahovat?**

Neexistuje pevně daný limit API, který by byl zdokumentován. Praktická omezení závisí na celkové složitosti prezentace a výkonu zařízení. Můžete přidat mnoho Zoom rámců, ale zvažte velikost souboru a čas vykreslování.