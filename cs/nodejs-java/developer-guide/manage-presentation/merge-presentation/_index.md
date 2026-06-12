---
title: Efektivně sloučit prezentace v JavaScriptu
linktitle: Sloučit prezentace
type: docs
weight: 40
url: /cs/nodejs-java/merge-presentation/
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
- Node.js
- JavaScript
- Aspose.Slides
description: "Jednoduše sloučte prezentace PowerPoint (PPT, PPTX) a OpenDocument (ODP) v JavaScriptu pomocí Aspose.Slides pro Node.js, což zefektivní váš pracovní postup."
---
## **Přehled**

Aspose.Slides umožňuje sloučit prezentace klonováním snímků z jedné prezentace do druhé. Tento článek vysvětluje, jak sloučit celé prezentace nebo vybrané snímky, použít hlavní snímek nebo konkrétní rozvržení během sloučení, zacházet s prezentacemi s různými velikostmi snímků a přidat sloučené snímky do sekce prezentace. Také pokrývá praktické poznámky související se sloučeným obsahem, včetně poznámek řečníka, komentářů, souborů chráněných heslem a používání vláken.

## **Sloučení prezentací**

Když sloučíte jednu prezentaci s druhou, efektivně kombinujete jejich snímky do jedné prezentace a získáte jeden soubor. 

{{% alert title="Info" color="info" %}}

Většina programů pro prezentace (PowerPoint nebo OpenOffice) postrádá funkce, které uživatelům umožňují kombinovat prezentace tímto způsobem. 

[**Aspose.Slides pro Node.js via Java**](https://products.aspose.com/slides/cs/nodejs-java/), však umožňuje sloučit prezentace různými způsoby. Můžete sloučit prezentace se všemi jejich tvary, styly, texty, formátováním, komentáři, animacemi atd., aniž byste se museli obávat ztráty kvality nebo dat.

**Viz také**

[Clone Slides](https://docs.aspose.com/slides/cs/nodejs-java/clone-slides/).

{{% /alert %}}

### **Co lze sloučit**

S Aspose.Slides můžete sloučit 

* celé prezentace. Všechny snímky z prezentací skončí v jedné prezentaci
* konkrétní snímky. Vybrané snímky skončí v jedné prezentaci
* prezentace v jednom formátu (PPT na PPT, PPTX na PPTX, atd.) a v různých formátech (PPT na PPTX, PPTX na ODP, atd.) mezi sebou. 

### **Možnosti sloučení**

Můžete použít možnosti, které určují, zda

* každý snímek ve výstupní prezentaci zachová jedinečný styl
* pro všechny snímky ve výstupní prezentaci se použije konkrétní styl. 

Pro sloučení prezentací poskytuje Aspose.Slides metody [addClone](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) (z třídy [SlideCollection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection)). Existuje několik implementací metod `addClone`, které definují parametry procesu sloučení prezentací. Každý objekt Presentation má kolekci [Slides](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/Presentation#getSlides--) , takže můžete zavolat metodu `addClone` z prezentace, do které chcete snímky sloučit.

Metoda `addClone` vrací objekt `Slide`, který je klonem zdrojového snímku. Snímky ve výstupní prezentaci jsou jednoduše kopií snímků ze zdroje. Proto můžete měnit výsledné snímky (například aplikovat styly, možnosti formátování nebo rozvržení) bez obav, že by byly ovlivněny zdrojové prezentace. 

## **Sloučení prezentací** 

Aspose.Slides poskytuje metodu [**AddClone(ISlide)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-) , která umožňuje kombinovat snímky tak, aby snímky zachovaly svá rozvržení a styly (výchozí parametry).

Tento JavaScriptový kód ukazuje, jak sloučit prezentace:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Sloučení prezentací s hlavním snímkem**

Aspose.Slides poskytuje metodu [**AddClone(ISlide, IMasterSlide, boolean)**](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.IMasterSlide-boolean-) , která umožňuje kombinovat snímky při aplikaci šablony hlavního snímku (slide master). Tímto způsobem můžete v případě potřeby změnit styl snímků ve výstupní prezentaci.

Tento kód v JavaScriptu demonstruje popsanou operaci:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getMasters().get_Item(0), true);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

{{% alert title="Poznámka" color="warning" %}} 

Rozvržení snímku pro hlavní snímek je určeno automaticky. Pokud nelze vhodné rozvržení určit, a parametr `allowCloneMissingLayout` metody `addClone` je nastaven na true, použije se rozvržení ze zdrojového snímku. V opačném případě bude vyhozena výjimka [PptxEditException](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/PptxEditException).

{{% /alert %}}

Pokud chcete, aby snímky ve výstupní prezentaci měly jiné rozvržení, při sloučení použijte místo toho metodu [addClone(ISlide, ILayoutSlide)](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/SlideCollection#addClone-aspose.slides.ISlide-aspose.slides.ILayoutSlide-).

## **Sloučení specifických snímků z prezentací**

Sloučení konkrétních snímků z několika prezentací je užitečné při tvorbě vlastních sad snímků. Aspose.Slides pro Node.js via Java umožňuje vybrat a importovat pouze snímky, které potřebujete. API zachovává formátování, rozvržení a design originálních snímků.

Následující JavaScriptový kód vytvoří novou prezentaci, přidá titulní snímky ze dvou dalších prezentací a výsledek uloží do souboru:

```js
function getTitleSlide(presentation) {
  for (let i = 0; i < presentation.getSlides().size(); i++) {
    let slide = presentation.getSlides().get_Item(i);
    if (slide.getLayoutSlide().getLayoutType() == aspose.slides.SlideLayoutType.Title) {
      return slide;
    }
  }
  return null;
}
```
```js
let presentation = new aspose.slides.Presentation();
let presentation1 = new aspose.slides.Presentation("presentation1.pptx");
let presentation2 = new aspose.slides.Presentation("presentation2.pptx");
try {
    presentation.getSlides().removeAt(0);
    
    let slide1 = getTitleSlide(presentation1);

    if (slide1 != null)
        presentation.getSlides().addClone(slide1);

    let slide2 = getTitleSlide(presentation2);

    if (slide2 != null)
        presentation.getSlides().addClone(slide2);

    presentation.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    presentation2.dispose();
    presentation1.dispose();
    presentation.dispose();
}
```

## **Sloučení prezentací s rozvržením snímků**

Tento JavaScriptový kód ukazuje, jak kombinovat snímky z prezentací při aplikaci preferovaného rozvržení snímků, aby vznikla jedna výstupní prezentace:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres2.getLayoutSlides().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Sloučení prezentací s různými velikostmi snímků**

{{% alert title="Poznámka" color="warning" %}} 

Nelze sloučit prezentace s různými velikostmi snímků. 

{{% /alert %}}

Pro sloučení dvou prezentací s různými velikostmi snímků musíte velikost jedné z nich upravit tak, aby odpovídala velikosti druhé prezentace. 

Tento ukázkový kód demonstruje popsanou operaci:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        pres2.getSlideSize().setSize(pres1.getSlideSize().getSize().getWidth(), pres1.getSlideSize().getSize().getHeight(), aspose.slides.SlideSizeScaleType.EnsureFit);
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide);
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

## **Sloučení snímků do sekce prezentace**

Tento JavaScriptový kód ukazuje, jak sloučit konkrétní snímek do sekce v prezentaci:

```javascript
let pres1 = new aspose.slides.Presentation("pres1.pptx");
try {
    let pres2 = new aspose.slides.Presentation("pres2.pptx");
    try {
        for (let i = 0; i < pres2.getSlides().size(); i++) {
            let slide = pres2.getSlides().get_Item(i);
            pres1.getSlides().addClone(slide, pres1.getSections().get_Item(0));
        }
    } finally {
        if (pres2 != null) {
            pres2.dispose();
        }
    }
    pres1.save("combined.pptx", aspose.slides.SaveFormat.Pptx);
} finally {
    if (pres1 != null) {
        pres1.dispose();
    }
}
```

Snímek je přidán na konec sekce. 

## **FAQ**

**Zůstávají poznámky řečníka při sloučení zachovány?**

Ano. Při klonování snímků Aspose.Slides přenáší všechny prvky snímku, včetně poznámek, formátování a animací.

**Přenesou se komentáře a jejich autoři?**

Komentáře, jako součást obsahu snímku, jsou s ním zkopírovány. Štítky autorů komentářů jsou zachovány jako objekty komentářů v výsledné prezentaci.

**Co když je zdrojová prezentace chráněna heslem?**

Musí být [otevřena s heslem](/slides/cs/nodejs-java/password-protected-presentation/) pomocí [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/setpassword/); po načtení lze tyto snímky bezpečně klonovat do nechráněného cílového souboru (nebo také do chráněného).

**Jak je operace sloučení vlákny bezpečná?**

Nepoužívejte stejnou instanci [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) z [více vláken](/slides/cs/nodejs-java/multithreading/). Doporučené pravidlo je „jeden dokument — jedno vlákno“; různé soubory lze zpracovávat paralelně v samostatných vláknech.

## **Viz také**

Aspose poskytuje [ZDARMA Online Collage Maker](https://products.aspose.app/slides/cs/collage). Pomocí této online služby můžete sloučit [JPG to JPG](https://products.aspose.app/slides/cs/collage/jpg) nebo PNG na PNG obrázky, vytvořit [foto mřížky](https://products.aspose.app/slides/cs/collage/photo-grid) a další.

Vyzkoušejte [Aspose ZDARMA Online Merger](https://products.aspose.app/slides/cs/merger). Umožňuje sloučit PowerPointové prezentace ve stejném formátu (např. PPT na PPT, PPTX na PPTX) nebo mezi různými formáty (např. PPT na PPTX, PPTX na ODP).

[![Aspose ZDARMA Online Merger](slides-merger.png)](https://products.aspose.app/slides/cs/merger)