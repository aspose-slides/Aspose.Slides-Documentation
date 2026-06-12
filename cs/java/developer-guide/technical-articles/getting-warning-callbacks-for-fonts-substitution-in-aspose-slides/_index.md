---
title: Získání výstražných volání pro substituci fontů
type: docs
weight: 90
url: /cs/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- výstražné volání
- substituce fontu
- proces vykreslování
- PowerPoint
- OpenDocument
- prezentace
- Java
- Aspose.Slides
description: "Naučte se získávat výstražná zpětná volání pro substituci fontů v Aspose.Slides pro Javu a přesně zobrazovat prezentace PowerPoint a OpenDocument."
---
## **Úvod**

Aspose.Slides for Java vám umožňuje získávat výstražná zpětná volání pro náhradu písma, když požadované písmo během vykreslování není na počítači k dispozici. Tato zpětná volání pomáhají diagnostikovat problémy s chybějícími nebo nedostupnými písmy.

## **Povolení výstražných zpětných volání**

Aspose.Slides for Java poskytuje jednoduchá API pro přijímání výstražných zpětných volání při vykreslování snímků prezentace. Postupujte podle následujících kroků pro konfiguraci výstražných zpětných volání:

1. Vytvořte vlastní třídu zpětného volání, která implementuje rozhraní [IWarningCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iwarningcallback/) pro zpracování výstrah.
1. Nastavte výstražné zpětné volání pomocí tříd možností, jako jsou [RenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/htmloptions/) a další.
1. Načtěte prezentaci, která používá písmo, které není na cílovém počítači k dispozici.
1. Vygenerujte miniaturu snímku nebo exportujte prezentaci a pozorujte výsledek.

**Vlastní třída výstražného zpětného volání:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Příklad výstupu:
//
// Písmo bude nahrazeno z XYZ na {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Vytvořit miniaturu snímku:**

```java
// Nastavte výstražné zpětné volání pro zpracování varování souvisejících s fonty během vykreslování snímků.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Načtěte prezentaci ze zadané cesty k souboru.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Vygenerujte miniaturu obrázku pro každý snímek v prezentaci.
    for (ISlide slide : presentation.getSlides()) {
        // Získejte miniaturu snímku pomocí zadaných možností vykreslování.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Export do formátu PDF:**

```java
// Nastavte výstražné zpětné volání pro zpracování varování souvisejících s fonty během exportu do PDF.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Načtěte prezentaci ze zadané cesty k souboru.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportujte prezentaci do PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Export do formátu HTML:**

```java
// Nastavte výstražné zpětné volání pro zpracování varování souvisejících s fonty během exportu do HTML.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Načtěte prezentaci ze zadané cesty k souboru.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportujte prezentaci ve formátu HTML.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```