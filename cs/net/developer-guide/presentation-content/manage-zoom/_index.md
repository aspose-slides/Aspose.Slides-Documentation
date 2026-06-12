---
title: Spravovat zoom prezentace v .NET
linktitle: Spravovat zoom
type: docs
weight: 60
url: /cs/net/manage-zoom/
keywords:
- přiblížení
- rámec zoomu
- zoom snímku
- zoom sekce
- souhrnný zoom
- přidat zoom
- PowerPoint
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Vytvořte a přizpůsobte Zoom pomocí Aspose.Slides pro .NET — přecházejte mezi sekcemi, přidávejte náhledy a přechody v prezentacích PPT, PPTX a ODP."
---
## **Úvod**

Zoomy v PowerPointu vám umožňují přeskakovat na konkrétní snímky, sekce a části prezentace a zpět. Při prezentování může být tato schopnost rychle se orientovat v obsahu velmi užitečná. 

![overview_image](overview.png)

* Pro shrnutí celé prezentace na jediném snímku použijte [Souhrnný zoom](#Summary-Zoom).
* Pro zobrazení pouze vybraných snímků použijte [Zoom snímku](#Slide-Zoom).
* Pro zobrazení pouze jedné sekce použijte [Zoom sekce](#Section-Zoom).

## **Zoom snímku**
Zoom snímku může vaši prezentaci učinit dynamičtější, protože vám umožní volně přecházet mezi snímky v libovolném pořadí, aniž byste narušili tok prezentace. Zoomy snímků jsou skvělé pro krátké prezentace bez mnoha sekcí, ale můžete je použít i v různých prezentačních scénářích.

Zoomy snímků vám pomáhají prohloubit se do několika částí informací, zatímco máte pocit, že pracujete na jedné ploše. 

![overview_image](slidezoomsel.png)

Pro objekty zoomu snímku Aspose.Slides poskytuje výčtový typ [ZoomImageType](https://reference.aspose.com/slides/cs/net/aspose.slides/zoomimagetype), rozhraní [IZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/izoomframe) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection).

### **Vytvoření zoom rámců**

Můžete přidat zoom rámec na snímek takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nové snímky, ke kterým chcete propojit zoom rámy. 
3.	Přidejte identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoom rámy (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nové snímky do prezentace
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Vytvoří pozadí pro druhý snímek
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Vytvoří textové pole pro druhý snímek
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Vytvoří pozadí pro třetí snímek
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Přidá objekty ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Vytvoření zoom rámců s vlastními obrázky**
S Aspose.Slides pro .NET můžete vytvořit zoom rámec s jiným náhledem snímku takto: 
1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nový snímek, ke kterému chcete propojit zoom rámec. 
3.	Přidejte identifikační text a pozadí ke snímku.
4.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), který bude použit k vyplnění rámce.
5.	Přidejte zoom rámy (obsahující odkaz na vytvořený snímek) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Vytvoří pozadí pro druhý snímek
    slide.Background.Type = BackgroundType.OwnBackground;
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Vytvoří textové pole pro třetí snímek
    IAutoShape autoshape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Vytvoří nový obrázek pro zoom objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    //Přidá objekt ZoomFrame
    pres.Slides[0].Shapes.AddZoomFrame(20, 20, 300, 200, slide, ppImage);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formátování zoom rámců**
V předchozích částech jsme vám ukázali, jak vytvořit jednoduché zoom rámy. Pro vytvoření složitějších zoom rámců musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoom rámec použít. 

Můžete ovládat formátování zoom rámce na snímku takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nové snímky, ke kterým chcete propojit zoom rámec. 
3.	Přidejte nějaký identifikační text a pozadí k vytvořeným snímkům.
4.	Přidejte zoom rámy (obsahující odkazy na vytvořené snímky) na první snímek.
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), který bude použit k vyplnění rámce.
6.	Nastavte vlastní obrázek pro první objekt zoom rámce.
7.	Změňte formátování čáry pro druhý objekt zoom rámce.
8.	Odstraňte pozadí z obrázku druhého objektu zoom rámce.
5.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nové snímky do prezentace
    ISlide slide2 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    ISlide slide3 = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);

    // Vytvoří pozadí pro druhý snímek
    slide2.Background.Type = BackgroundType.OwnBackground;
    slide2.Background.FillFormat.FillType = FillType.Solid;
    slide2.Background.FillFormat.SolidFillColor.Color = Color.Cyan;

    // Vytvoří textové pole pro druhý snímek
    IAutoShape autoshape = slide2.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Second Slide";

    // Vytvoří pozadí pro třetí snímek
    slide3.Background.Type = BackgroundType.OwnBackground;
    slide3.Background.FillFormat.FillType = FillType.Solid;
    slide3.Background.FillFormat.SolidFillColor.Color = Color.DarkKhaki;

    // Vytvoří textové pole pro třetí snímek
    autoshape = slide3.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 200, 500, 200);
    autoshape.TextFrame.Text = "Trird Slide";

    //Přidá objekty ZoomFrame
    IZoomFrame zoomFrame1 = pres.Slides[0].Shapes.AddZoomFrame(20, 20, 250, 200, slide2);
    IZoomFrame zoomFrame2 = pres.Slides[0].Shapes.AddZoomFrame(200, 250, 250, 200, slide3);

    // Vytvoří nový obrázek pro zoom objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Nastaví vlastní obrázek pro objekt zoomFrame1
    zoomFrame1.ZoomImage = ppImage;

    // Nastaví formát zoom rámce pro objekt zoomFrame2
    zoomFrame2.LineFormat.Width = 5;
    zoomFrame2.LineFormat.FillFormat.FillType = FillType.Solid;
    zoomFrame2.LineFormat.FillFormat.SolidFillColor.Color = Color.HotPink;
    zoomFrame2.LineFormat.DashStyle = LineDashStyle.DashDot;

    // Nastavení pro nezobrazovat pozadí pro objekt zoomFrame2
    zoomFrame2.ShowBackground = false;

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Zoom sekce**

Zoom sekce je odkaz na sekci ve vaší prezentaci. Můžete jej použít k návratu k sekcím, které chcete opravdu zdůraznit. Nebo jej můžete použít k zvýraznění toho, jak se určité části vaší prezentace navzájem spojují. 

![overview_image](seczoomsel.png)

Pro objekty zoomu sekce Aspose.Slides poskytuje rozhraní [ISectionZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isectionzoomframe) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection).

### **Vytvoření zoom rámců sekce**

Můžete přidat zoom rámec sekce na snímek takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nový snímek. 
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Přidejte zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Vytvoření zoom rámců sekce s vlastními obrázky**

Pomocí Aspose.Slides pro .NET můžete vytvořit zoom rámec sekce s jiným náhledem snímku takto: 

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), který bude použit k vyplnění rámce.
5.	Přidejte zoom rámec sekce (obsahující odkaz na vytvořenou sekci) na první snímek.
6.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    // Vytvoří nový obrázek pro zoom objekt
    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1], ppImage);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```
### **Formátování zoom rámců sekce**

Pro vytvoření složitějších zoom rámců sekce musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na zoom rámec sekce použít. 

Můžete ovládat formátování zoom rámce sekce na snímku takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nový snímek.
3.	Přidejte identifikační pozadí k vytvořenému snímku.
4.	Vytvořte novou sekci, ke které chcete propojit zoom rámec. 
5.	Přidejte zoom rámec sekce (obsahující odkazy na vytvořenou sekci) na první snímek.
6.	Změňte velikost a umístění vytvořeného objektu zoom sekce.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do kolekce Images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt zoom sekce.
9.	Nastavte *vrácení na původní snímek z propojené sekce*.
10.	Odstraňte pozadí z obrázku objektu zoom sekce.
11.	Změňte formátování čáry pro druhý objekt zoom rámce.
12.	Změňte trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.YellowGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    // Přidá objekt SectionZoomFrame
    ISectionZoomFrame sectionZoomFrame = pres.Slides[0].Shapes.AddSectionZoomFrame(20, 20, 300, 200, pres.Sections[1]);

    // Formátování pro SectionZoomFrame
    sectionZoomFrame.X = 100;
    sectionZoomFrame.Y = 300;
    sectionZoomFrame.Width = 100;
    sectionZoomFrame.Height = 75;

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    sectionZoomFrame.ZoomImage = ppImage;

    sectionZoomFrame.ReturnToParent = true;
    sectionZoomFrame.ShowBackground = false;

    sectionZoomFrame.LineFormat.FillFormat.FillType = FillType.Solid;
    sectionZoomFrame.LineFormat.FillFormat.SolidFillColor.Color = Color.Brown;
    sectionZoomFrame.LineFormat.DashStyle = LineDashStyle.DashDot;
    sectionZoomFrame.LineFormat.Width = 2.5f;

    sectionZoomFrame.TransitionDuration = 1.5f;

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```


## **Souhrnný zoom**

Souhrnný zoom je jako vstupní stránka, kde jsou všechny části vaší prezentace zobrazeny najednou. Při prezentování můžete pomocí zoomu přecházet z jednoho místa v prezentaci na jiné v libovolném pořadí. Můžete být kreativní, přeskočit dopředu nebo se vrátit k částem vaší prezentace, aniž byste narušili její tok.

![overview_image](sumzoomsel.png)

Pro objekty souhrnného zoomu Aspose.Slides poskytuje rozhraní [ISummaryZoomFrame](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomframe), [ISummaryZoomFrameSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomsection) a [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomsectioncollection) a některé metody pod rozhraním [IShapeCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/ishapecollection).

### **Vytvoření souhrnného zoomu**

Můžete přidat souhrnný zoom rámec na snímek takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoom rámec na první snímek.
4.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 2", slide);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 3", slide);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.DarkGreen;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 4", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Přidání a odebrání sekce souhrnného zoomu**

Všechny sekce v souhrnném zoom rámci jsou reprezentovány objekty [ISummaryZoomFrameSection](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomsection), které jsou uloženy v objektu [ISummaryZoomSectionCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/isummaryzoomsectioncollection). Můžete přidat nebo odebrat objekt sekce souhrnného zoomu prostřednictvím rozhraní [ISummaryZoomSectionCollection] tímto způsobem:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoom rámec na první snímek.
4.	Přidejte nový snímek a sekci do prezentace.
5.	Přidejte vytvořenou sekci do souhrnného zoom rámce.
6.	Odeberte první sekci ze souhrnného zoom rámce.
7.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 2", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Chartreuse;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    ISection section3 = pres.Sections.AddSection("Section 3", slide);

    // Přidá sekci do Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.AddSummaryZoomSection(section3);

    // Odstraní sekci ze Summary Zoom
    summaryZoomFrame.SummaryZoomCollection.RemoveSummaryZoomSection(pres.Sections[1]);

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

### **Formátování sekcí souhrnného zoomu**

Pro vytvoření složitějších objektů sekce souhrnného zoomu musíte upravit formátování jednoduchého rámce. Existuje několik možností formátování, které můžete na objekt sekce souhrnného zoomu použít. 

Můžete ovládat formátování objektu sekce souhrnného zoomu v souhrnném zoom rámci takto:

1.	Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation).
2.	Vytvořte nové snímky s identifikačním pozadím a novými sekcemi pro vytvořené snímky.
3.	Přidejte souhrnný zoom rámec na první snímek.
4.	Získejte objekt sekce souhrnného zoomu pro první položku z `ISummaryZoomSectionCollection`.
7.	Vytvořte objekt [IPPImage](https://reference.aspose.com/slides/cs/net/aspose.slides/ippimage) přidáním obrázku do kolekce images spojené s objektem [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation), který bude použit k vyplnění rámce.
8.	Nastavte vlastní obrázek pro vytvořený objekt sekce zoomu.
9.	Nastavte *vrácení na původní snímek z propojené sekce*.
11.	Změňte formátování čáry pro druhý objekt zoom rámce.
12.	Změňte trvání přechodu.
13.	Zapište upravenou prezentaci jako soubor PPTX.

``` csharp 
using (Presentation pres = new Presentation())
{
    //Přidá nový snímek do prezentace
    ISlide slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Brown;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 1", slide);

    //Přidá nový snímek do prezentace
    slide = pres.Slides.AddEmptySlide(pres.Slides[0].LayoutSlide);
    slide.Background.FillFormat.FillType = FillType.Solid;
    slide.Background.FillFormat.SolidFillColor.Color = Color.Aqua;
    slide.Background.Type = BackgroundType.OwnBackground;

    // Přidá novou sekci do prezentace
    pres.Sections.AddSection("Section 2", slide);

    // Přidá objekt SummaryZoomFrame
    ISummaryZoomFrame summaryZoomFrame = pres.Slides[0].Shapes.AddSummaryZoomFrame(150, 50, 300, 200);

    // Získá první objekt SummaryZoomSection
    ISummaryZoomSection summarySection = summaryZoomFrame.SummaryZoomCollection[0];

    IImage image = Images.FromFile("image.png");
    IPPImage ppImage = pres.Images.AddImage(image);
    image.Dispose();

    // Formátování objektu SummaryZoomSection
    summarySection.ZoomImage = ppImage;
    summarySection.ReturnToParent = false;

    summarySection.LineFormat.FillFormat.FillType = FillType.Solid;
    summarySection.LineFormat.FillFormat.SolidFillColor.Color = Color.Black;
    summarySection.LineFormat.DashStyle = LineDashStyle.DashDot;
    summarySection.LineFormat.Width = 1.5f;

    summarySection.TransitionDuration = 1.5f;

    // Uloží prezentaci
    pres.Save("presentation.pptx", SaveFormat.Pptx);
}
```

## **Často kladené otázky**

**Mohu ovládat návrat na „rodičovský“ snímek po zobrazení cíle?**

Ano. Zoom rámec ([Zoom frame](https://reference.aspose.com/slides/cs/net/aspose.slides/zoomframe/)) nebo [section](https://reference.aspose.com/slides/cs/net/aspose.slides/sectionzoomframe/) má chování `ReturnToParent`, které při povolení pošle diváky zpět na původní snímek po návštěvě cílového obsahu.

**Mohu upravit „rychlost“ nebo dobu trvání přechodu Zoomu?**

Ano. Zoom podporuje nastavení `TransitionDuration`, takže můžete ovládat, jak dlouho trvá animace přeskoku.

**Existují omezení, kolik Zoom objektů může prezentace obsahovat?**

Neexistuje pevně daný limit API, který by byl zdokumentován. Praktická omezení závisí na celkové složitosti prezentace a výkonnosti prohlížeče. Můžete přidat mnoho Zoom rámců, ale mějte na paměti velikost souboru a dobu renderování.