---
title: Efektivně sloučit prezentace na Androidu
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/androidjava/merge-presentation/
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
- Android
- Java
- Aspose.Slides
description: "Jednoduše sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) pomocí Aspose.Slides pro Android v Javě, zefektivníte svůj pracovní postup."
---
## **Přehled**

Sloučení prezentací PowerPoint a OpenDocument je běžný úkol v mnoha aplikacích pro Android, zejména při generování zpráv, sestavování snímků z různých zdrojů nebo automatizaci pracovních postupů s prezentacemi. Aspose.Slides poskytuje výkonné a snadno použitelné API pro kombinování více souborů PPT, PPTX nebo ODP do jedné prezentace bez nutnosti instalovat Microsoft PowerPoint, LibreOffice nebo OpenOffice.

V tomto průvodci se naučíte, jak sloučit prezentace PowerPoint a OpenDocument pomocí několika řádků kódu. Poskytneme připravené příklady a ukážeme, jak během sloučení zachovat formátování snímků, rozvržení a další prvky prezentace.

Ať už vytváříte podnikové aplikace nebo jednoduchý automatizační nástroj, Aspose.Slides umožňuje rychlé, spolehlivé a škálovatelné sloučení prezentací. Aspose.Slides umožňuje sloučit prezentace různými způsoby. Můžete kombinovat prezentace se všemi jejich tvary, styly, textem, formátováním, komentáři, animacemi a dalšími — bez obav o ztrátu kvality nebo dat.

{{% alert color="primary" %}}
Viz také: [Klonování snímků](https://docs.aspose.com/slides/cs/androidjava/clone-slides/)
{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci
* konkrétní snímky. Vybrané snímky skončí v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX, atd.) a v různých formátech (PPT na PPTX, PPTX na ODP, atd.) mezi sebou.

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci si zachová jedinečný styl
* pro všechny snímky ve výstupní prezentaci se použije konkrétní styl.

Pro sloučení prezentací poskytuje Aspose.Slides metody [AddClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection) ). Existuje několik implementací metod `AddClone`, které určují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--) , takže můžete zavolat metodu `AddClone` z prezentace, do které chcete snímky sloučit.

Metoda `AddClone` vrací objekt `ISlide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (například aplikovat styly, možnosti formátování nebo rozvržení) bez obav, že by byly ovlivněny zdrojové prezentace.

## **Sloučení prezentací**

Aspose.Slides poskytuje metodu [**AddClone(ISlide)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) , která umožňuje kombinovat snímky, přičemž snímky si zachovají svá rozvržení a styly (výchozí parametry).

Tento Java kód ukazuje, jak sloučit prezentace:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Sloučení prezentací s hlavním snímkem (Slide Master)**

Aspose.Slides poskytuje metodu [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-) , která umožňuje kombinovat snímky a zároveň použít šablonu hlavního snímku prezentace. Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci.

Tento kód v Javě demonstruje popsanou operaci:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Note" color="warning" %}}
Rozvržení snímku pro hlavní snímek je určeno automaticky. Pokud není možné vhodné rozvržení určit, a parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, použijte při sloučení metodu [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-).

## **Sloučení konkrétních snímků z prezentací**

Sloučení konkrétních snímků z více prezentací je užitečné při tvorbě vlastních sad snímků. Aspose.Slides pro Android přes Java vám umožňuje vybrat a importovat pouze potřebné snímky. API zachovává formátování, rozvržení a design originálních snímků.

Následující Java kód vytvoří novou prezentaci, přidá titulní snímky ze dvou dalších prezentací a uloží výsledek do souboru:

```java
Presentation presentation = new Presentation();
Presentation presentation1 = new Presentation("presentation1.pptx");
Presentation presentation2 = new Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    ISlide slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    ISlide slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```
```java
static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Sloučení prezentací s rozvržením snímků**

Tento Java kód ukazuje, jak kombinovat snímky z prezentací a při tom použít vámi preferované rozvržení snímků, aby vznikla jedna výstupní prezentace:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Sloučení prezentací s různými velikostmi snímků**

{{% alert title="Note" color="warning" %}}
Nelze sloučit prezentace s různými rozměry snímků.
{{% /alert %}}

Pro sloučení dvou prezentací s různými velikostmi snímků musíte jednu z prezentací změnit tak, aby její velikost odpovídala velikosti druhé prezentace.

Tento ukázkový kód demonstruje popsanou operaci:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize((float)pres1.getSlideSize().getSize().getWidth(), (float)pres1.getSlideSize().getSize().getHeight(), SlideSizeScaleType.EnsureFit);

        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

## **Sloučení snímků do sekce prezentace**

Tento Java kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```java
Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

Snímek je přidán na konec sekce.

{{% alert title="Tip" color="primary" %}}
Aspose poskytuje [ZDARMA webovou aplikaci Collage](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG na JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a tak dále.
{{% /alert %}}

## **Často kladené otázky**

**Existují nějaká omezení počtu snímků při sloučení prezentací?**

Neexistují přísná omezení. Aspose.Slides dokáže zpracovat velké soubory, avšak výkon závisí na velikosti a systémových prostředcích. Pro velmi velké prezentace se doporučuje použít 64‑bitovou JVM a přidělit dostatečnou paměť heap.

**Mohu sloučit prezentace s vloženým videem nebo zvukem?**

Ano, Aspose.Slides zachovává multimediální obsah vložený do snímků, ale výsledná prezentace může být výrazně větší.

**Zůstanou písma zachována při sloučení prezentací?**

Ano. Písma použitá ve zdrojových prezentacích jsou zachována ve výstupním souboru, pokud jsou nainstalována v systému nebo [vložená](/slides/cs/androidjava/embedded-font/).