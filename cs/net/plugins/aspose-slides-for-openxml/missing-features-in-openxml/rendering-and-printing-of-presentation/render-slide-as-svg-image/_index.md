---
title: Vykreslit snímek jako SVG obrázek
type: docs
weight: 50
url: /cs/net/render-slide-as-svg-image/
---
SVG—zkratka pro Scalable Vector Graphics—je standardní typ grafiky nebo formát používaný k vykreslování dvourozměrných obrázků. SVG ukládá obrázky jako vektory v XML s podrobnostmi, které definují jejich chování nebo vzhled. 

SVG je jedním z mála formátů pro obrázky, který splňuje velmi vysoké standardy v těchto oblastech: škálovatelnost, interaktivita, výkon, přístupnost, programovatelnost a další. Z těchto důvodů se běžně používá ve webovém vývoji. 

Můžete chtít použít soubory SVG v následujících situacích:

- když plánujete tisknout svou prezentaci ve velmi velkém formátu. Obrázky SVG lze škálovat na libovolné rozlišení či úroveň. Můžete měnit velikost obrázků SVG tolikrát, kolik je potřeba, aniž byste obětovali kvalitu.
- když chcete použít grafy a diagramy ze svých snímků v různých médiích nebo platformách. Většina čteček dokáže interpretovat soubory SVG. 
- když potřebujete použít co nejmenší velikosti obrázků. Soubory SVG jsou obecně menší než jejich vysoce rozlišené ekvivalenty v jiných formátech, zvláště u formátů založených na bitmapách (JPEG nebo PNG).

Aspose.Slides pro .NET vám umožňuje exportovat snímky ve vašich prezentacích jako **SVG** obrázky. Chcete-li vygenerovat SVG obrázek z libovolného, postupujte následovně:

- Vytvořte instanci třídy Presentation.
- Projděte všechny snímky v prezentaci.
- Zapište každý snímek do jeho vlastního SVG souboru pomocí FileStream.

{{% alert color="primary" %}} 

Můžete vyzkoušet naši [bezplatnou webovou aplikaci](https://products.aspose.app/slides/cs/conversion/ppt-to-svg), ve které jsme implementovali funkci konverze PPT na SVG z Aspose.Slides pro .NET.

{{% /alert %}} 

Tento ukázkový kód v C# vám ukazuje, jak převést PPT na SVG pomocí Aspose.Slides:

``` csharp
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