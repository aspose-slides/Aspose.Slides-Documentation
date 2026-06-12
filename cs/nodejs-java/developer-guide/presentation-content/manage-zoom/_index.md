---
title: Správa zoomu prezentace v JavaScriptu
linktitle: Spravovat zoom
type: docs
weight: 60
url: /cs/nodejs-java/manage-zoom/
keywords:
- zoom
- zoom rámec
- zoom snímku
- zoom sekce
- zoom souhrnu
- přidat zoom
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro Node.js — přecházejte mezi sekcemi, přidávejte náhledy a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přecházet na konkrétní snímky, sekce a části prezentace a zpět. Když přednášíte, tato schopnost rychle se navigovat v obsahu může být velmi užitečná. 

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Summary Zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Slide Zoom](#Slide-Zoom).
* Pro zobrazení jen jedné sekce použijte [Section Zoom](#Section-Zoom).

## **Zoom snímku**

Zoom snímku může učinit vaši prezentaci dynamičtější a umožní vám volně navigovat mezi snímky v libovolném pořadí, aniž byste narušili tok prezentace. Zoomy snímku jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých scénářích prezentací.

Zoomy snímku vám pomáhají prozkoumat více informací, přičemž máte pocit, že pracujete na jedné ploše. 

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku Aspose.Slides poskytuje výčet [ZoomImageType](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ZoomImageType), třídu [ZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ZoomFrame) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection). 

### **Vytváření Zoom rámců**

Můžete přidat zoom rámec na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nové snímky, ke kterým chcete propojit zoom rámce. 
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit zoom rámec na snímku:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nové snímky do prezentace
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Vytvoří pozadí pro druhý snímek
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Vytvoří textové pole pro druhý snímek
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Vytvoří pozadí pro třetí snímek
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Přidá objekty ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření Zoom rámců s vlastním obrázkem**

S Aspose.Slides pro Node.js via Java můžete vytvořit zoom rámec s jiným náhledem snímku takto:
1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nový snímek, ke kterému chcete propojit zoom rámec. 
3.	Přidejte identifikační text a pozadí ke snímku.
4.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), který bude použit k vyplnění rámce.
5.	Přidejte zoom rámce (obsahující odkaz na vytvořený snímek) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit zoom rámec s jiným obrázkem:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Vytvoří pozadí pro druhý snímek
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Vytvoří textové pole pro třetí snímek
    var autoshape = slide.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Vytvoří nový obrázek pro zoom objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá objekt ZoomFrame
    pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 300, 200, slide, picture);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formátování Zoom rámců**

V předchozích částech jsme vám ukázali, jak vytvořit jednoduché zoom rámce. Pro vytvoření složitějších zoom rámců musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoom rámec použít. 

Můžete ovládat formátování zoom rámce na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nové snímky, ke kterým chcete propojit zoom rámec. 
3.	Přidejte nějaký identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoom rámce (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro první objekt zoom rámce.
7.	Změňte formátování čáry pro druhý objekt zoom rámce.
8.	Odstraňte pozadí z obrázku druhého objektu zoom rámce.
5.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak změnit formátování zoom rámce na snímku:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nové snímky do prezentace
    var slide2 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    var slide3 = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    // Vytvoří pozadí pro druhý snímek
    slide2.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide2.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide2.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    // Vytvoří textové pole pro druhý snímek
    var autoshape = slide2.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Second Slide");
    // Vytvoří pozadí pro třetí snímek
    slide3.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    slide3.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide3.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "darkGray"));
    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.getShapes().addAutoShape(aspose.slides.ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.getTextFrame().setText("Trird Slide");
    // Přidá objekty ZoomFrame
    var zoomFrame1 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(20, 20, 250, 200, slide2);
    var zoomFrame2 = pres.getSlides().get_Item(0).getShapes().addZoomFrame(200, 250, 250, 200, slide3);
    // Vytvoří nový obrázek pro zoom objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Nastaví vlastní obrázek pro objekt zoomFrame1
    zoomFrame1.setImage(picture);
    // Nastaví formát zoom rámce pro objekt zoomFrame2
    zoomFrame2.getLineFormat().setWidth(5);
    zoomFrame2.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    zoomFrame2.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "pink"));
    zoomFrame2.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    // Nastavení pro nezobrazování pozadí objektu zoomFrame2
    zoomFrame2.setShowBackground(false);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Section Zoom**

Section Zoom je odkaz na sekci ve vaší prezentaci. Můžete použít sekční zoomy k návratu k sekcím, které chcete zdůraznit. Nebo je můžete použít k zobrazení, jak se určité části vaší prezentace navzájem propojují. 

![overview_image](seczoomsel.png)

Pro objekty sekčního zoomu Aspose.Slides poskytuje třídu [SectionZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SectionZoomFrame) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection). 

### **Vytváření Section Zoom rámců**

Můžete přidat sekční zoom rámec na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Přidejte sekční zoom rámec (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit zoom rámec na snímku:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Přidá objekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Vytváření Section Zoom rámců s vlastním obrázkem**

Pomocí Aspose.Slides pro Node.js via Java můžete vytvořit sekční zoom rámec s jiným náhledem snímku takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), který bude použit k vyplnění rámce.
5.	Přidejte sekční zoom rámec (obsahující odkaz na vytvořenou sekci) na první snímek.
6.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit zoom rámec s jiným obrázkem:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Vytvoří nový obrázek pro zoom objekt
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    // Přidá objekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1), picture);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formátování Section Zoom rámců**

Pro vytvoření složitějších sekčních zoom rámců musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na sekční zoom rámec použít. 

Můžete ovládat formátování sekčního zoom rámce na snímku tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Přidejte sekční zoom rámec (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Změňte velikost a umístění vytvořeného sekčního zoom objektu.
7.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do kolekce Images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený sekční zoom rámec.
9.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
10.	Odstraňte pozadí z obrázku sekčního zoom rámce.
11.	Změňte formátování čáry pro druhý zoom rámec.
12.	Změňte dobu trvání přechodu.
13.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak změnit formátování sekčního zoom rámce:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "yellow"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Přidá objekt SectionZoomFrame
    var sectionZoomFrame = pres.getSlides().get_Item(0).getShapes().addSectionZoomFrame(20, 20, 300, 200, pres.getSections().get_Item(1));
    // Formátování pro SectionZoomFrame
    sectionZoomFrame.setX(100);
    sectionZoomFrame.setY(300);
    sectionZoomFrame.setWidth(100);
    sectionZoomFrame.setHeight(75);
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(image);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    sectionZoomFrame.setImage(picture);
    sectionZoomFrame.setReturnToParent(true);
    sectionZoomFrame.setShowBackground(false);
    sectionZoomFrame.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    sectionZoomFrame.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    sectionZoomFrame.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    sectionZoomFrame.getLineFormat().setWidth(2.5);
    sectionZoomFrame.setTransitionDuration(1.5);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **Summary Zoom**

Summary Zoom je jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Když prezentujete, můžete pomocí zoomu přecházet z jednoho místa prezentace na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem prezentace, aniž byste narušili tok prezentace.

![overview_image](sumzoomsel.png)

Pro objekty summary zoom Aspose.Slides poskytuje třídy [SummaryZoomFrame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SummaryZoomFrame), [SummaryZoomSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SummaryZoomSection) a [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SummaryZoomSectionCollection) a některé metody ve třídě [ShapeCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/ShapeCollection). 

### **Vytváření Summary Zoom**

Můžete přidat summary zoom rámec na snímek tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte summary zoom rámec na první snímek.
4.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak vytvořit summary zoom rámec na snímku:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 3", slide);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "green"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 4", slide);
    // Přidá objekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Přidávání a odstraňování Summary Zoom sekcí**

Všechny sekce v summary zoom rámci jsou reprezentovány objekty [SummaryZoomSection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SummaryZoomSection), které jsou uloženy v objektu [SummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SummaryZoomSectionCollection). Sekci můžete přidat nebo odebrat prostřednictvím třídy [SummaryZoomSectionCollection] tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte summary zoom rámec do prvního snímku.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do summary zoom rámce.
6.	Odeberte první sekci ze summary zoom rámce.
7.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak přidat a odebrat sekce v summary zoom rámci:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);
    // Přidá objekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "magenta"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    var section3 = pres.getSections().addSection("Section 3", slide);
    // Přidá sekci do Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().addSummaryZoomSection(section3);
    // Odebere sekci ze Summary Zoom
    summaryZoomFrame.getSummaryZoomCollection().removeSummaryZoomSection(pres.getSections().get_Item(1));
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

### **Formátování Summary Zoom sekcí**

Pro vytvoření složitějších objektů summary zoom sekcí musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt summary zoom sekce použít. 

Můžete ovládat formátování objektu summary zoom sekce v summary zoom rámci tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a nové sekce pro vytvořené snímky.
3.	Přidejte summary zoom rámec na první snímek.
4.	Získejte objekt summary zoom sekce pro první objekt z `ISummaryZoomSectionCollection`.
7.	Vytvořte objekt [PPImage](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PPImage) přidáním obrázku do kolekce images přidružené k objektu [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený sekční zoom rámec.
9.	Nastavte schopnost *návratu na původní snímek z propojené sekce*. 
11.	Změňte formátování čáry pro druhý zoom rámec.
12.	Změňte dobu trvání přechodu.
13.	Uložte upravenou prezentaci jako soubor PPTX.

Tento JavaScriptový kód ukazuje, jak změnit formátování objektu summary zoom sekce:

```javascript
var pres = new aspose.slides.Presentation();
try {
    // Přidá nový snímek do prezentace
    var slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "gray"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 1", slide);
    // Přidá nový snímek do prezentace
    slide = pres.getSlides().addEmptySlide(pres.getSlides().get_Item(0).getLayoutSlide());
    slide.getBackground().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    slide.getBackground().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "cyan"));
    slide.getBackground().setType(aspose.slides.BackgroundType.OwnBackground);
    // Přidá novou sekci do prezentace
    pres.getSections().addSection("Section 2", slide);
    // Přidá objekt SummaryZoomFrame
    var summaryZoomFrame = pres.getSlides().get_Item(0).getShapes().addSummaryZoomFrame(150, 50, 300, 200);
    // Získá první objekt SummaryZoomSection
    var summarySection = summaryZoomFrame.getSummaryZoomCollection().get_Item(0);
    // Formátování objektu SummaryZoomSection
    var picture;
    var image = aspose.slides.Images.fromFile("image.png");
    try {
        picture = pres.getImages().addImage(picture);
    } finally {
        if (image != null) {
            image.dispose();
        }
    }
    summarySection.setImage(picture);
    summarySection.setReturnToParent(false);
    summarySection.getLineFormat().getFillFormat().setFillType(java.newByte(aspose.slides.FillType.Solid));
    summarySection.getLineFormat().getFillFormat().getSolidFillColor().setColor(java.getStaticFieldValue("java.awt.Color", "black"));
    summarySection.getLineFormat().setDashStyle(aspose.slides.LineDashStyle.DashDot);
    summarySection.getLineFormat().setWidth(1.5);
    summarySection.setTransitionDuration(1.5);
    // Uloží prezentaci
    pres.save("presentation.pptx", aspose.slides.SaveFormat.Pptx);
} catch (e) {console.log(e);
} finally {
    if (pres != null) {
        pres.dispose();
    }
}
```

## **FAQ**

**Mohu ovládat návrat na „rodičovský“ snímek po zobrazení cíle?**

Ano. [Zoom frame](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/zoomframe/) nebo [section](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/sectionzoomframe/) má metodu `setReturnToParent`, která při povolení po návštěvě cílového obsahu vrací diváka zpět na původní snímek.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoomu?**

Ano. Zoom poskytuje metodu `setTransitionDuration`, pomocí které můžete řídit, jak dlouhá je animace skoku.

**Existují limity na počet Zoom objektů, které může prezentace obsahovat?**

Neexistuje žádný pevně stanovený limit API. Praktické limity závisí na celkové složitosti prezentace a výkonu prohlížeče. Můžete přidat mnoho Zoom rámců, ale zvažte velikost souboru a čas renderování.