---
title: Vykreslit snímek jako SVG obrázek
type: docs
weight: 50
url: /cs/net/render-slide-as-svg-image/
---
SVG — zkratka pro Scalable Vector Graphics — je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled.  

SVG je jedním z mála formátů obrázků, které splňují velmi vysoké nároky v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů je běžně používán ve vývoji webu.  

Můžete chtít používat SVG soubory v následujících situacích:

- když plánujete tisknout svou prezentaci ve velmi velkém formátu. SVG obrázky mohou škálovat na libovolné rozlišení nebo úroveň. Můžete měnit velikost SVG obrázků kolikrát jen potřebujete, aniž byste ztratili kvalitu.  
- když chcete použít grafy a diagramy ze svých slidů na různých médiích nebo platformách. Většina čteček dokáže interpretovat SVG soubory.  
- když potřebujete použít co nejmenší velikosti obrázků. SVG soubory jsou obecně menší než jejich vysoké rozlišení ekvivalenty v jiných formátech, zejména ve formátech založených na bitmapě (JPEG nebo PNG).  

Aspose.Slides for .NET vám umožňuje exportovat snímky ve vašich prezentacích jako **SVG** obrázky. Chcete‑li z libovolného snímku vytvořit SVG obrázek, postupujte takto:

- Vytvořte instanci třídy Presentation.  
- Projděte všechny snímky v prezentaci.  
- Každý snímek zapište do vlastního SVG souboru pomocí FileStream.  

{{% alert color="info" %}} 

Můžete si vyzkoušet naši [bezplatná webová aplikace](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides for .NET.  

{{% /alert %}} 

Tento ukázkový kód v C# vám ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

``` csharp
using Aspose.Slides;

using (Presentation pres = new Presentation("pres.pptx"))
{
    for (var index = 0; index < pres.Slides.Count; index++)
    {
        ISlide slide = pres.Slides[index];

        using (FileStream fileStream = new FileStream($"slide-{index}.svg", FileMode.Create, FileAccess.Write))
        {
            slide.WriteAsSvg(fileStream);   
        }
    }
}
```