---
title: Změna velikosti a orientace stránky poznámek v Javě
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/java/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladu
- PowerPoint
- prezentace
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Přečtěte a změňte rozměry stránky poznámek v Aspose.Slides pro Java, přepněte orientaci, ověřte uložené velikosti a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getNotesSize--) k přístupu k nastavením stránky poznámek prezentace. Vrací objekt [INotesSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotessize/) jehož metoda [setSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/inotessize/#setSize-java.awt.geom.Dimension2D-) nastavuje rozměry stránky. Ačkoli nelze objekt nastavení nahradit, můžete přes tuto metodu přiřadit nové rozměry.

Šířka a výška jsou uváděny v **bodech**, s 72 body na palec. Například 900 × 600 bodů odpovídá 12,5 × 8 ⅓ palce. Tato nastavení se vztahují na celou prezentaci, nikoli na poznámky jednotlivých snímků.

| Nastavení | Účel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getNotesSize--) | Řídí rozměry stránky poznámek a rozměry stránky použité při exportu podkladů. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getSlideSize--) | Řídí rozměry běžných snímků prezentace pomocí [ISlideSize](https://reference.aspose.com/slides/cs/java/com.aspose.slides/islidesize/). |

Změna libovolného nastavení automaticky nemění to druhé. Změna orientace stránky poznámek také neotáčí běžné snímky. Viz [Velikost snímku](/slides/cs/java/slide-size/) pro změnu velikosti běžných snímků.

Níže uvedené příklady používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím poznámky řečníka. Každý příklad lze spustit samostatně.

## **Přečtení velikosti a orientace stránky poznámek**

Přečtěte šířku a výšku a porovnejte je pro určení orientace: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vypíše skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();
    String orientation = "Square";

    if (size.getWidth() > size.getHeight()) {
        orientation = "Landscape";
    } else if (size.getWidth() < size.getHeight()) {
        orientation = "Portrait";
    }

    System.out.println("Notes page: " + size.getWidth() + " x " + size.getHeight() + " points");
    System.out.println("Orientation: " + orientation);
} finally {
    presentation.dispose();
}
```

## **Přepnutí na šířkový formát bez změny velikosti papíru**

Pro změnu pouze orientace prohoďte stávající šířku a výšku. Tím se zachová délka obou stran, včetně těch u vlastní velikosti papíru. Níže uvedená podmínka zabraňuje převrácení již šířkové stránky zpět na výšku a ponechává čtvercovou stránku nezměněnou.

```java
import com.aspose.slides.*;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        double width = size.getWidth();
        size.setSize(size.getHeight(), width);
        presentation.getNotesSize().setSize(size);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro orientaci na výšku použijte stejné přiřazení, když `size.getWidth() > size.getHeight()`. Nepoužívejte rozměry A4 nebo Letter, pokud nechcete také změnit velikost papíru.

## **Nastavení a ověření vlastní velikosti stránky poznámek**

Přiřaďte oba rozměry najednou a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#save-java.lang.String-int-) k uložení prezentace. Tento příklad nastaví šířkovou stránku o rozměrech 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor k ověření zachovaných hodnot. Porovnání umožňuje toleranci 0,01 bodu pro hodnoty floating-point; není to záruka přesnosti pro každý formát souboru.

```java
import com.aspose.slides.*;
import java.awt.Dimension;
import java.awt.geom.Dimension2D;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension2D expectedSize = new Dimension(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        Dimension2D actualSize = reopened.getNotesSize().getSize();
        boolean widthMatches = Math.abs(actualSize.getWidth() - expectedSize.getWidth()) < 0.01;
        boolean heightMatches = Math.abs(actualSize.getHeight() - expectedSize.getHeight()) < 0.01;
        boolean preserved = widthMatches && heightMatches;

        System.out.println("Stored notes page: " + actualSize.getWidth() + " x " + actualSize.getHeight() + " points");
        System.out.println("Size preserved: " + preserved);
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

Očekávaný výsledek je `900.0 x 600.0 points` a `Size preserved: true`. Kontrola nově otevřené prezentace ověří uložený soubor, nikoli pouze nastavení v paměti.

## **Export poznámek a podkladů**

Rozměry stránky definují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě tyto rozvržení neaktivují: je třeba nastavit také exportní možnosti. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notescommentslayoutingoptions/) k [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) pro zahrnutí poznámek do PDF. Tento příklad také vykresluje první snímek s poznámkami do PNG pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/java/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) a [RenderingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notespositions/) udržuje poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky o rozměrech 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitém níže je PNG 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    NotesCommentsLayoutingOptions layout = new NotesCommentsLayoutingOptions();
    layout.setNotesPosition(NotesPositions.BottomTruncated);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("notes.pdf", SaveFormat.Pdf, pdfOptions);

    RenderingOptions renderingOptions = new RenderingOptions();
    renderingOptions.setSlidesLayoutOptions(layout);

    IImage image = presentation.getSlides().get_Item(0).getImage(renderingOptions, 1, 1);
    try {
        image.save("first-slide-notes.png", ImageFormat.Png);
    } finally {
        image.dispose();
    }
} finally {
    presentation.dispose();
}
```

Pro PDF export s dlouhými poznámkami [BottomFull](https://reference.aspose.com/slides/cs/java/com.aspose.slides/notespositions/) umožňuje přidat další stránky podle potřeby. Nepoužívejte tento režim s voláním vykreslení jedné stránky výše, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů notes‑master; samotná změna rozměrů stránky by neměla být považována za záruku, že veškerý obsah se vejde. Viz [Převod PowerPointu na PDF s poznámkami](/slides/cs/java/convert-powerpoint-to-pdf-with-notes/) pro více informací o exportu poznámek.

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku o rozměrech 900 × 600 bodů a použije [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/cs/java/com.aspose.slides/handouttype/) k uspořádání až čtyř snímků na stránku. Vodorovná předvolba řídí pořadí snímků; orientace stránky vyplývá z její šířky a výšky.

```java
import com.aspose.slides.*;
import java.awt.Dimension;

Presentation presentation = new Presentation("sample.pptx");
try {
    Dimension size = new Dimension(900, 600);
    presentation.getNotesSize().setSize(size);

    HandoutLayoutingOptions layout = new HandoutLayoutingOptions();
    layout.setHandout(HandoutType.Handouts4Horizontal);

    PdfOptions pdfOptions = new PdfOptions();
    pdfOptions.setSlidesLayoutOptions(layout);

    presentation.save("handouts.pdf", SaveFormat.Pdf, pdfOptions);
} finally {
    presentation.dispose();
}
```

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by změnila rozměry zdrojových snímků. Pro obrázky podkladů použijte [Presentation.getImages](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) s rozvržením podkladů, místo metody obrázku jednotlivého snímku. V Aspose.Slides se vykreslování podkladů na úrovni prezentace řídí rozměry stránky poznámek, zatímco volání obrázku jednotlivého snímku nevytváří stránku podkladů. Viz [Režim podkladů](/slides/cs/java/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky v prohlížečích, exportu a tisku**

Udržujte odlišné velikost uložené prezentace, exportovanou velikost stránky a velikost papíru při tisku:

- **Presentation viewers:** Prohlížeč může zobrazit nebo vytisknout poznámky pomocí svých vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, znovu jej otevřete a zkontrolujte rozměry; konverze formátu v té aplikaci je může normalizovat.
- **Export formats:** Výše uvedené příklady PDF pro poznámky a podklady používají nastavené rozměry stránky. Rastrové obrázky používají celočíselné rozměry pixelů a měřítko vykreslování, takže desetinné hodnoty bodů mohou být zaokrouhleny ve výstupu obrázku. Export běžných snímků nepoužívá velikost stránky poznámek.
- **Printer drivers:** Výběr papíru, automatické otáčení a nastavení přizpůsobení stránce mohou změnit fyzický výstup, aniž by změnily rozměry uložené v prezentaci nebo PDF. Pro konkrétní velikost papíru sladíte nastavení tiskárny a zkontrolujte náhled tisku.

## **Často kladené otázky**

**Mohu nastavit velikost poznámek jen pro jeden snímek?**

Velikost stránky poznámek je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít odlišný obsah poznámek, ale tato vlastnost nenabízí samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila mé snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek uložený nebo vytištěný jinou velikost?**

Nejprve znovu otevřete uloženou prezentaci a porovnejte rozměry poznámek. Pokud se změnily, zkontrolujte, zda ukládání nebo konverze souboru v jiné aplikaci změnily nastavení stránky. Pokud ne, prověřte rozvržení exportu, měřítko obrazu, nastavení prohlížeče a výběr papíru tiskárny.