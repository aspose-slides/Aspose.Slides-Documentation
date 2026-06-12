---
title: Efektivně sloučit prezentace v .NET
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/net/merge-presentation/
keywords:
- sloučit PowerPoint
- sloučit prezentace
- sloučit snímky
- sloučit PPT
- sloučit PPTX
- sloučit ODP
- kombinovat PowerPoint
- kombinovat prezentace
- kombinovat snímky
- kombinovat PPT
- kombinovat PPTX
- kombinovat ODP
- .NET
- C#
- Aspose.Slides
description: "Bez námahy sloučte PowerPoint (PPT, PPTX) a OpenDocument (ODP) prezentace pomocí Aspose.Slides pro .NET, zjednodušíte tak svůj pracovní postup."
---
## **Přehled**

Aspose.Slides vám umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní motiv snímku nebo konkrétní rozvržení během sloučení, pracovat s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. Dále se zabývá praktickými poznámkami souvisejícími se sloučeným obsahem, včetně poznámek k řečníkovi, komentářů, souborů chráněných heslem a použití vláken.

## **Optimalizace sloučení prezentací**

Pomocí [Aspose.Slides for .NET](https://products.aspose.com/slides/cs/net/), plynule kombinujte PowerPoint prezentace při zachování stylů, rozvržení a všech prvků. Na rozdíl od jiných nástrojů Aspose.Slides kombinuje prezentace, aniž by snižoval kvalitu nebo ztrácel data. Sloučte celé prezentace, konkrétní snímky a dokonce různé formáty souborů (PPT na PPTX apod.).

### **Funkce sloučení**

- **Full Presentation Merge:** Sestavit všechny snímky do jednoho souboru.  
- **Specific Slide Merge:** Vybrat a spojit vybrané snímky.  
- **Cross-Format Merge:** Integrovat prezentace různých formátů při zachování integrity.  

{{% alert title="Tip" color="primary" %}}  
Potřebujete rychlý a **zdarma online nástroj** pro **sloučení PowerPoint prezentací**? Vyzkoušejte [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/cs/merger).  

- **Merge PowerPoint files easily**: Sloučte více **PPT, PPTX, ODP** prezentací do jednoho souboru.  
- **Supports different formats**: Sloučte **PPT na PPTX**, **PPTX na ODP**, a další.  
- **No installation required**: Funguje přímo v prohlížeči, rychle a bezpečně.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/cs/merger)  

Začněte dnes sloučovat své PowerPoint soubory pomocí **zdarma online nástroje Aspose**!  
{{% /alert %}}

## **Sloučení prezentací**

Když [sloučíte jednu prezentaci s druhou](https://products.aspose.com/slides/cs/net/merger/ppt/), efektivně kombinujete jejich snímky v jedné prezentaci a získáte jeden soubor.  

{{% alert title="Info" color="info" %}}

Většina programů pro prezentace (PowerPoint nebo OpenOffice) postrádá funkce, které umožňují uživatelům kombinovat prezentace tímto způsobem.  

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/cs/net/) vám však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat.  

**Viz také**  

[Clone Slides](https://docs.aspose.com/slides/cs/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.*  
{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit  

* celé prezentace. Všechny snímky z prezentací končí v jedné prezentaci  
* konkrétní snímky. Vybrané snímky končí v jedné prezentaci  
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX, atd.) a v různých formátech (PPT na PPTX, PPTX na ODP, atd.) mezi sebou.  

{{% alert title="Note" color="warning" %}}  
Vedle prezentací vám Aspose.Slides umožňuje sloučit i jiné soubory:  

* [Images](https://products.aspose.com/slides/cs/net/merger/image-to-image/), například [JPG na JPG](https://products.aspose.com/slides/cs/net/merger/jpg-to-jpg/) nebo [PNG na PNG](https://products.aspose.com/slides/cs/net/merger/png-to-png/)  
* Documents, například [PDF na PDF](https://products.aspose.com/slides/cs/net/merger/pdf-to-pdf/) nebo [HTML na HTML](https://products.aspose.com/slides/cs/net/merger/html-to-html/)  
* A dva různé soubory, například [image to PDF](https://products.aspose.com/slides/cs/net/merger/image-to-pdf/) nebo [JPG to PDF](https://products.aspose.com/slides/cs/net/merger/jpg-to-pdf/) nebo [TIFF to PDF](https://products.aspose.com/slides/cs/net/merger/tiff-to-pdf/).  
{{% /alert %}}

### **Možnosti sloučení**

Můžete použít možnosti, které určují,  

* každý snímek ve výstupní prezentaci si zachová jedinečný styl  
* pro všechny snímky ve výstupní prezentaci se použije konkrétní styl.  

Pro sloučení prezentací poskytuje Aspose.Slides metody [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection)). Existuje několik implementací metod `AddClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides), takže můžete zavolat metodu `AddClone` z prezentace, do které chcete snímky sloučit.  

`AddClone` metoda vrací objekt `ISlide`, což je klon zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete upravovat výsledné snímky (např. aplikovat styly, možnosti formátování nebo rozvržení) aniž byste se museli obávat, že se změní zdrojové prezentace.  

## **Sloučení prezentací**

Aspose.Slides poskytuje metodu [**AddClone (ISlide)**](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone), která vám umožní kombinovat snímky tak, že snímky si zachovají svá rozvržení a styly (výchozí parametry).  

Tento C# kód ukazuje, jak sloučit prezentace:  

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Sloučení prezentací s hlavním motivem snímku**

Aspose.Slides poskytuje metodu [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/cs/net/aspose.slides.islidecollection/addclone/methods/2), která vám umožní kombinovat snímky při aplikaci šablony hlavního motivu snímku. Tím můžete v případě potřeby změnit styl snímků ve výstupní prezentaci.  

Tento C# kód demonstruje popsanou operaci:  

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.Masters[0], allowCloneMissingLayout: true);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

{{% alert title="Note" color="warning" %}}  
Rozvržení snímku pro hlavní motiv je určeno automaticky. Pokud nelze vhodné rozvržení zjistit a parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception).  
{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, při sloučení použijte místo toho metodu [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/net/aspose.slides.islidecollection/addclone/methods/1).  

## **Sloučení konkrétních snímků z prezentací**

Sloučení konkrétních snímků z více prezentací je užitečné při tvorbě vlastních prezentací. Aspose.Slides for .NET vám umožňuje vybrat a importovat pouze snímky, které potřebujete. API zachovává formátování, rozvržení a design původních snímků.  

Následující C# kód vytvoří novou prezentaci, přidá úvodní snímky ze dvou dalších prezentací a uloží výsledek do souboru:  

```cs
using (Presentation presentation = new Presentation())
using (Presentation presentation1 = new Presentation("presentation1.pptx"))
using (Presentation presentation2 = new Presentation("presentation2.pptx"))
{
    presentation.Slides.RemoveAt(0);

    ISlide slide1 = GetTitleSlide(presentation1);

    if (slide1 != null)
        presentation.Slides.AddClone(slide1);

    ISlide slide2 = GetTitleSlide(presentation2);

    if (slide2 != null)
        presentation.Slides.AddClone(slide2);

    presentation.Save("combined.pptx", SaveFormat.Pptx);
}
```
```cs
static ISlide GetTitleSlide(IPresentation presentation)
{
    foreach (ISlide slide in presentation.Slides)
    {
        if (slide.LayoutSlide.LayoutType == SlideLayoutType.Title)
        {
            return slide;
        }
    }
    return null;
}
```

## **Sloučení prezentací s rozvržením snímku**

Tento C# kód ukazuje, jak kombinovat snímky z prezentací a zároveň na ně aplikovat vámi zvolené rozvržení snímku, abyste získali jednu výstupní prezentaci:  

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    foreach (ISlide slide in pres2.Slides)
    {
        pres1.Slides.AddClone(slide, pres2.LayoutSlides[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Sloučení prezentací s různými velikostmi snímků**

{{% alert title="Note" color="warning" %}}  
Nelze sloučit prezentace s různými velikostmi snímků.  
{{% /alert %}}

Aby bylo možné sloučit 2 prezentace s různými velikostmi snímků, musíte změnit velikost jedné z nich tak, aby odpovídala velikosti druhé prezentace.  

Tento ukázkový kód demonstruje popsanou operaci:  

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
   pres2 = new Presentation("pres2.pptx"))
{
   pres2.SlideSize.SetSize(pres1.SlideSize.Size.Width, pres1.SlideSize.Size.Height, SlideSizeScaleType.EnsureFit);
 
   foreach (ISlide slide in pres2.Slides)
   {
       pres1.Slides.AddClone(slide);
   }
 
   pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

## **Sloučení snímků do sekce prezentace**

Tento C# kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:  

```c#
using (Presentation pres1 = new Presentation("pres1.pptx"),
    pres2 = new Presentation("pres2.pptx"))
{
    for (var index = 0; index < pres2.Slides.Count; index++)
    {
        ISlide slide = pres2.Slides[index];
        pres1.Slides.AddClone(slide, pres1.Sections[0]);
    }

    pres1.Save("combined.pptx", SaveFormat.Pptx);
}
```

Snímek je přidán na konci sekce.  

{{% alert title="Tip" color="primary" %}}  
Aspose poskytuje [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit obrázky [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG, vytvářet [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a tak dále.  
{{% /alert %}}

## **Často kladené otázky**

**Jsou během sloučení zachovány poznámky k řečníkovi?**

**Ano.** Při klonování snímků Aspose.Slides přenáší všechny prvky snímku, včetně poznámek, formátování a animací.  

**Jsou komentáře a jejich autoři přeneseni?**

Komentáře jako součást obsahu snímku jsou zkopírovány spolu se snímkem. Štítky autorů komentářů jsou zachovány jako objekty komentářů v výsledné prezentaci.  

**Co když je zdrojová prezentace chráněna heslem?**

Musí být [otevřena s heslem](/slides/cs/net/password-protected-presentation/) pomocí [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/); po načtení lze tyto snímky bezpečně klonovat do nechráněného cílového souboru (nebo také do chráněného).  

**Jak je operace sloučení bezpečná pro více vláken?**

Nepoužívejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) z [více vláken](/slides/cs/net/multithreading/). Doporučené pravidlo je „jeden dokument — jedno vlákno“; různé soubory lze zpracovávat paralelně v oddělených vláknech.