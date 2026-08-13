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
description: "Jednoduše sloučte PowerPoint (PPT, PPTX) a OpenDocument (ODP) prezentace pomocí Aspose.Slides pro .NET, zjednodušte svůj pracovní postup."
---
## **Přehled**

Aspose.Slides vám umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní motiv (slide master) nebo konkrétní rozvržení během sloučení, pracovat s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. Také zahrnuje praktické poznámky související se sloučeným obsahem, včetně poznámek k řečníkům, komentářů, souborů se zabezpečením heslem a používání vláken.

## **Optimalizujte sloučení prezentací**

S [Aspose.Slides for .NET](https://products.aspose.com/slides/cs/net/) plynule kombinujte PowerPoint prezentace při zachování stylů, rozvržení a všech prvků. Na rozdíl od jiných nástrojů Aspose.Slides spojuje prezentace, aniž by snižoval kvalitu nebo ztrácel data. Sloučte celé prezentace, konkrétní snímky a dokonce i různé formáty souborů (PPT na PPTX, atd.).

### **Funkce sloučení**

- **Plné sloučení prezentace:** Sestavte všechny snímky do jednoho souboru.  
- **Sloučení vybraných snímků:** Vyberte a spojte vybrané snímky.  
- **Napříč formáty sloučení:** Integrovat prezentace různých formátů při zachování integrity.  

{{% alert title="Tip" color="info" %}}  

Hledáte rychlý a **zdarma online nástroj** pro **sloučení PowerPoint prezentací**? Vyzkoušejte [**Aspose PowerPoint Merger**](https://products.aspose.app/slides/cs/merger).  

- **Jednoduše sloučte PowerPoint soubory**: Kombinujte více **PPT, PPTX, ODP** prezentací do jednoho souboru.  
- **Podporuje různé formáty**: Sloučte **PPT na PPTX**, **PPTX na ODP** a další.  
- **Bez nutnosti instalace**: Funguje přímo v prohlížeči, rychle a bezpečně.  

[![Merge PowerPoint Files Online](slides-merger.png)](https://products.aspose.app/slides/cs/merger)  

Začněte dnes sloučovat své PowerPoint soubory s **bezplatným online nástrojem Aspose**!  

{{% /alert %}}

## **Sloučení prezentací**

Když [sloučíte jednu prezentaci s jinou](https://products.aspose.com/slides/cs/net/merger/ppt/), efektivně kombinujete jejich snímky do jedné prezentace a získáte jeden soubor. 

{{% alert title="Info" color="info" %}}

Většina prezentačních programů (PowerPoint nebo OpenOffice) postrádá funkce, které uživatelům umožňují kombinovat prezentace tímto způsobem. 

[**Aspose.Slides for .NET**](https://products.aspose.com/slides/cs/net/) však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat. 

**Viz také**

[Clone Slides](https://docs.aspose.com/slides/cs/net/cloning-commenting-and-manipulating-slides/#cloning-commentingandmanipulatingslides-cloningslides)*.* 

{{% /alert %}}

### **Co může být sloučeno**

Pomocí Aspose.Slides můžete sloučit 

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci  
* konkrétní snímky. Vybrané snímky skončí v jedné prezentaci  
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX, atd.) i v různých formátech (PPT na PPTX, PPTX na ODP, atd.) mezi sebou.  

{{% alert title="Note" color="warning" %}} 

Kromě prezentací umožňuje Aspose.Slides sloučit i jiné soubory:

* [Obrázky](https://products.aspose.com/slides/cs/net/merger/image-to-image/), jako např. [JPG na JPG](https://products.aspose.com/slides/cs/net/merger/jpg-to-jpg/) nebo [PNG na PNG](https://products.aspose.com/slides/cs/net/merger/png-to-png/)  
* Dokumenty, například [PDF na PDF](https://products.aspose.com/slides/cs/net/merger/pdf-to-pdf/) nebo [HTML na HTML](https://products.aspose.com/slides/cs/net/merger/html-to-html/)  
* A dva různé soubory, například [obrázek na PDF](https://products.aspose.com/slides/cs/net/merger/image-to-pdf/), [JPG na PDF](https://products.aspose.com/slides/cs/net/merger/jpg-to-pdf/) nebo [TIFF na PDF](https://products.aspose.com/slides/cs/net/merger/tiff-to-pdf/).  

{{% /alert %}}

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci zachovává jedinečný styl  
* pro všechny snímky ve výstupní prezentaci je použit konkrétní styl.  

Pro sloučení prezentací poskytuje Aspose.Slides metody [AddClone](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection)). Existuje několik implementací metod `AddClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/properties/slides), takže můžete zavolat metodu `AddClone` z prezentace, do které chcete snímky sloučit. 

Metoda `AddClone` vrací objekt `ISlide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (např. aplikovat styly, formátování nebo rozvržení) bez obav, že by to ovlivnilo zdrojové prezentace. 

## **Sloučit prezentace** 

Aspose.Slides poskytuje metodu [**AddClone (ISlide)**](https://reference.aspose.com/slides/cs/net/aspose.slides/islidecollection/methods/addclone), která umožňuje kombinovat snímky, přičemž snímky zachovávají svá rozvržení a styly (výchozí parametry). 

Tento C# kód ukazuje, jak sloučit prezentace:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Sloučit prezentace s hlavním motivem (Slide Master)** 

Aspose.Slides poskytuje metodu [**AddClone (ISlide, IMasterSlide, Boolean)**](https://reference.aspose.com/slides/cs/net/aspose.slides.islidecollection/addclone/methods/2), která umožňuje kombinovat snímky při použití šablony hlavního motivu (slide master). Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci. 

Tento C# kód demonstruje popsanou operaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Rozvržení snímku pro hlavní motiv je určeno automaticky. Pokud nelze vhodné rozvržení určit a boolean parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/net/aspose.slides/pptxeditexception). 

{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, použijte při sloučení místo toho metodu [AddClone (ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/net/aspose.slides.islidecollection/addclone/methods/1). 

## **Sloučit konkrétní snímky z prezentací** 

Sloučení konkrétních snímků z více prezentací je užitečné pro tvorbu vlastních prezentací. Aspose.Slides for .NET vám umožňuje vybrat a importovat jen snímky, které potřebujete. API zachovává formátování, rozvržení a design původních snímků. 

Následující C# kód vytvoří novou prezentaci, přidá úvodní snímky ze dvou dalších prezentací a výsledek uloží do souboru:

```cs
using Aspose.Slides;
using Aspose.Slides.Export;

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
```cs
using Aspose.Slides;

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

## **Sloučit prezentace s rozvržením snímků** 

Tento C# kód ukazuje, jak kombinovat snímky z prezentací při aplikaci vámi preferovaného rozvržení snímků, abyste získali jednu výstupní prezentaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Sloučit prezentace s různými velikostmi snímků** 

{{% alert title="Note" color="warning" %}} 

Sloučení prezentací s různými velikostmi snímků nezpůsobí chybu, ale sloučené snímky přebírají velikost snímku cílové prezentace, zatímco jejich tvary si zachovávají původní pozice a velikosti, takže obsah může být nesprávně umístěn nebo ležet mimo hranice snímku. 

{{% /alert %}}

Aby bylo možné sloučit 2 prezentace s různými velikostmi snímků a zachovat jejich obsah správně uspořádaný, změňte velikost jedné z prezentací tak, aby odpovídala velikosti druhé prezentace. 

Tento ukázkový kód demonstruje popsanou operaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

## **Sloučit snímky do sekce prezentace** 

Tento C# kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

Snímek je přidán na konec sekce. 

{{% alert title="Tip" color="info" %}}

Aspose nabízí [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a podobně. 

{{% /alert %}}

## **Často kladené otázky**

### **Jsou poznámky řečníka zachovány během sloučení?**

Ano. Při klonování snímků Aspose.Slides přenáší všechny prvky snímku, včetně poznámek, formátování a animací.

### **Jsou komentáře a jejich autoři převedeni?**

Komentáře, jako součást obsahu snímku, jsou s ním zkopírovány. Štítky autorů komentářů jsou zachovány jako objekty komentářů v výsledné prezentaci.

### **Co když je zdrojová prezentace chráněna heslem?**

Musí být [otevřena s heslem](/slides/cs/net/password-protected-presentation/) pomocí [LoadOptions.Password](https://reference.aspose.com/slides/cs/net/aspose.slides/loadoptions/password/); po načtení mohou být tyto snímky bezpečně klonovány do nechráněného cílového souboru (nebo také do chráněného).

### **Jak je operace sloučení bezpečná pro více vláken?**

Nepoužívejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) z [více vláken](/slides/cs/net/multithreading/). Doporučené pravidlo je „jeden dokument — jedno vlákno“; různé soubory mohou být zpracovávány paralelně v samostatných vláknech.