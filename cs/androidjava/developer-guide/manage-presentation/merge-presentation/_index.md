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
description: "Bez námahy sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) pomocí Aspose.Slides pro Android prostřednictvím Javy, zjednodušující váš pracovní tok."
---
## **Přehled**

Sloučení prezentací PowerPoint a OpenDocument je běžný úkol v mnoha Android aplikacích, zejména při generování reportů, sestavování snímků z různých zdrojů nebo automatizaci pracovních toků prezentací. Aspose.Slides poskytuje výkonné a snadno použitelné API pro kombinaci více souborů PPT, PPTX nebo ODP do jedné prezentace bez nutnosti instalace Microsoft PowerPoint, LibreOffice nebo OpenOffice.

V tomto průvodci se naučíte, jak sloučit prezentace PowerPoint a OpenDocument pomocí několika řádků kódu. Poskytneme připravené příklady a ukážeme, jak během sloučení zachovat formátování snímků, rozvržení a další prvky prezentace.

Ať už vytváříte enterprise aplikaci nebo jednoduchý automatizační nástroj, Aspose.Slides dělá sloučení prezentací rychlé, spolehlivé a škálovatelné. Aspose.Slides umožňuje sloučit prezentace různými způsoby. Můžete kombinovat prezentace se všemi jejich tvary, styly, textem, formátováním, komentáři, animacemi a dalšími – aniž byste se museli obávat ztráty kvality nebo dat.

{{% alert color="info" %}}
Viz také: [Klonovat snímky](https://docs.aspose.com/slides/cs/androidjava/clone-slides/)
{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit 

* celé prezentace. Všechny snímky z prezentací jsou umístěny v jedné prezentaci
* konkrétní snímky. Vybrané snímky jsou umístěny v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX atd.) i v různých formátech (PPT na PPTX, PPTX na ODP atd.) do sebe. 

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci si zachová jedinečný styl
* pro všechny snímky ve výstupní prezentaci je použit specifický styl. 

Pro sloučení prezentací Aspose.Slides poskytuje metody [AddClone](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-) (z rozhraní [ISlideCollection](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection)). Existuje několik implementací metod `AddClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/Presentation#getSlides--), takže můžete zavolat metodu `AddClone` z prezentace, do které chcete sloučit snímky.

Metoda `AddClone` vrací objekt `ISlide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (např. aplikovat styly, formátovací možnosti nebo rozvržení) aniž byste se obávali, že se zdrojové prezentace změní. 

## **Sloučit prezentace** 

Aspose.Slides poskytuje metodu [**AddClone(ISlide)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-), která umožňuje kombinovat snímky a přitom si snímky zachovávají své rozvržení a styly (výchozí parametry).

Tento Java kód ukazuje, jak sloučit prezentace:

```java
import com.aspose.slides.*;

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

## **Sloučit prezentace s předlohou snímků** 

Aspose.Slides poskytuje metodu [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.IMasterSlide-boolean-), která umožňuje kombinovat snímky a při tom použít šablonu předlohy prezentace. Tím získáte možnost změnit styl snímků ve výstupní prezentaci, pokud je to potřeba.

Tento Java kód demonstruje popsanou operaci:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}
```

{{% alert title="Poznámka" color="warning" %}} 
Rozvržení snímku pro hlavní předlohu je určeno automaticky. Když nelze najít vhodné rozvržení a parametr `allowCloneMissingLayout` metody `AddClone` je nastaven na true, použije se rozvržení zdrojového snímku. V opačném případě bude vyvolána výjimka [PptxEditException](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/PptxEditException).
{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, použijte při sloučení místo toho metodu [AddClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ISlideCollection#addClone-com.aspose.slides.ISlide-com.aspose.slides.ILayoutSlide-).

## **Sloučit konkrétní snímky z prezentací** 

Sloučení konkrétních snímků z několika prezentací je užitečné při vytváření vlastních sad snímků. Aspose.Slides pro Android via Java vám umožňuje vybrat a importovat jen snímky, které potřebujete. API zachovává formátování, rozvržení a design původních snímků.

Následující Java kód vytvoří novou prezentaci, přidá úvodní snímky ze dvou dalších prezentací a výsledek uloží do souboru:

```java
import com.aspose.slides.*;

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
import com.aspose.slides.*;

static ISlide getTitleSlide(IPresentation presentation) {
    for (ISlide slide : presentation.getSlides()) {
        if (slide.getLayoutSlide().getLayoutType() == SlideLayoutType.Title) {
            return slide;
        }
    }
    return null;
}
```

## **Sloučit prezentace s rozvržením snímků** 

Tento Java kód ukazuje, jak kombinovat snímky z prezentací a při tom použít preferované rozvržení snímků, aby vznikla jedna výstupní prezentace:

```java
import com.aspose.slides.*;

Presentation pres1 = new Presentation("pres1.pptx");
try {
    Presentation pres2 = new Presentation("pres2.pptx");
    try {
        for(ISlide slide : pres2.getSlides())
        {
            pres1.getSlides().addClone(slide, pres1.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) pres2.dispose();
    }
    pres1.save("combined.pptx", SaveFormat.Pptx);
} finally {
    if (pres1 != null) pres1.dispose();
}

```

## **Sloučit prezentace s různými velikostmi snímků** 

{{% alert title="Poznámka" color="warning" %}} 
Nelze sloučit prezentace s různými velikostmi snímků. 
{{% /alert %}}

Pro sloučení dvou prezentací s odlišnými velikostmi snímků musíte velikost jedné z prezentací změnit tak, aby odpovídala velikosti druhé.

Tento ukázkový kód demonstruje popsanou operaci:

```java
import com.aspose.slides.*;

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

## **Sloučit snímky do sekce prezentace** 

Tento Java kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```java
import com.aspose.slides.*;

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

{{% alert title="Tip" color="info" %}}
Aspose poskytuje [FREE Collage web app](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG to JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG to PNG obrázky, vytvořit [photo grids](https://products.aspose.app/slides/cs/collage/photo-grid) a další. 
{{% /alert %}}

## **Často kladené otázky**

### Existují omezení počtu snímků při sloučení prezentací?

Žádná striktní omezení. Aspose.Slides dokáže zpracovat velké soubory, ale výkon závisí na velikosti a systémových zdrojích. Pro velmi velké prezentace se doporučuje použít 64‑bitovou JVM a přidělit dostatek haldy.

### Mohu sloučit prezentace s vloženým videem nebo zvukem?

Ano, Aspose.Slides zachovává multimediální obsah vložený do snímků, ale výsledná prezentace může být výrazně větší.

### Budou písma zachována při sloučení prezentací?

Ano. Písma použitá ve zdrojových prezentacích jsou v výstupním souboru zachována, za předpokladu že jsou nainstalována v systému nebo [vložená](/slides/cs/androidjava/embedded-font/).