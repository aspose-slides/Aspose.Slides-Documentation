---
title: Změna velikosti a orientace stránky poznámek na Androidu
linktitle: Velikost stránky poznámek
type: docs
weight: 10
url: /cs/androidjava/notes-size/
keywords:
- velikost stránky poznámek
- orientace poznámek
- poznámky na šířku
- poznámky na výšku
- velikost podkladů
- PowerPoint
- prezentace
- PPT
- PPTX
- Android
- Java
- Aspose.Slides
description: "Přečtěte a změňte rozměry stránky poznámek v Aspose.Slides pro Android pomocí Javy, přepněte orientaci, ověřte uložené rozměry a exportujte poznámky nebo podklady do PDF a obrázků."
---
## **Přehled**

Použijte [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getNotesSize--) k přístupu k nastavením stránky poznámek prezentace. Vrací objekt [INotesSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotessize/) , jehož metoda [setSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/inotessize/#setSize-com.aspose.slides.android.SizeF-) nastavuje rozměry stránky. I když objekt nastavení nelze nahradit, můžete pomocí této metody přiřadit nové rozměry.

Šířka a výška jsou udávány v **bodech**, 72 bodů na palec. Například 900 × 600 bodů je 12,5 × 8 ⅓ palce. Tato nastavení se vztahují k celé prezentaci, nikoli k poznámkám jednotlivých snímků.

| Nastavení | Účel |
| --- | --- |
| [Presentation.getNotesSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getNotesSize--) | Řídí rozměry stránky poznámek a rozměry stránky používané pro export podkladů. |
| [Presentation.getSlideSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getSlideSize--) | Řídí rozměry běžných snímků prezentace prostřednictvím [ISlideSize](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/islidesize/). |

Změna některého nastavení automaticky nezmění druhé. Změna orientace stránky poznámek také neotočí běžné snímky. Viz [Slide Size](/slides/cs/androidjava/slide-size/) pro změnu velikosti běžných snímků.

Následující příklady používají existující soubor `sample.pptx`. Pro příklady exportu použijte prezentaci s alespoň jedním snímkem obsahujícím speaker notes. Každý příklad může být spuštěn samostatně.

## **Přečtěte si velikost a orientaci stránky poznámek**

Přečtěte šířku a výšku a porovnejte je, abyste určili orientaci: širší stránka je na šířku (landscape), vyšší stránka je na výšku (portrait) a stejné rozměry popisují čtvercovou stránku. Tento příklad vypíše skutečné rozměry v bodech, aniž by předpokládal standardní velikost papíru.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();
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

## **Přepněte na šířkový formát bez změny velikosti papíru**

Pro změnu pouze orientace prohoďte stávající šířku a výšku. Tím se zachová délka obou stran, včetně těch u vlastního formátu papíru. Níže uvedená podmínka zabraňuje tomu, aby již šířková stránka byla přepnuta zpět na výšku, a ponechává čtvercovou stránku beze změny.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = presentation.getNotesSize().getSize();

    if (size.getWidth() < size.getHeight()) {
        SizeF landscapeSize = new SizeF(size.getHeight(), size.getWidth());
        presentation.getNotesSize().setSize(landscapeSize);
    }

    presentation.save("landscape-notes.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

Pro výškový formát použijte stejné přiřazení, když `size.getWidth() > size.getHeight()`. Nenahrazujte rozměry A4 nebo Letter, pokud nechcete také změnit velikost papíru.

## **Nastavte a ověřte vlastní velikost stránky poznámek**

Přiřaďte oba rozměry najednou a poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#save-java.lang.String-int-) k zápisu prezentace. Tento příklad nastaví šířkovou stránku 900 × 600 bodů, uloží ji jako PPTX a znovu otevře uložený soubor pro kontrolu uložených hodnot. Porovnání dovoluje toleranci 0,01 bodu pro hodnoty s plovoucí řádovou čárkou; není to záruka přesnosti pro každý formát souboru.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF expectedSize = new SizeF(900, 600);
    presentation.getNotesSize().setSize(expectedSize);

    presentation.save("custom-notes.pptx", SaveFormat.Pptx);

    Presentation reopened = new Presentation("custom-notes.pptx");
    try {
        SizeF actualSize = reopened.getNotesSize().getSize();
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

Rozměry stránky určují dostupnou oblast pro rozvržení poznámek nebo podkladů. Samy o sobě tyto rozvržení neaktivují: je třeba také nastavit možnosti exportu. Export běžných snímků nadále používá rozměry snímku.

### **Export poznámek do PDF a PNG**

Přiřaďte [NotesCommentsLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notescommentslayoutingoptions/) k [PdfOptions.setSlidesLayoutOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/pdfoptions/#setSlidesLayoutOptions-com.aspose.slides.ISlidesLayoutOptions-) , aby se poznámky zahrnuly do PDF. Tento příklad také vykresluje první snímek s poznámkami do PNG pomocí [Slide.getImage](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/slide/#getImage-com.aspose.slides.IRenderingOptions-float-float-) a [RenderingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/renderingoptions/).

Režim [BottomTruncated](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notespositions/) udržuje poznámky na jedné stránce; poznámky, které se nevejdou, mohou být oříznuty. PDF používá stránky o rozměrech 900 × 600 bodů. Při měřítku obrazu 1 × 1 použitém níže je PNG 900 × 600 pixelů. Body popisují geometrii stránky; pixely popisují rastrový výstup, jehož rozměry také závisí na měřítku vykreslování.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Pro export PDF s dlouhými poznámkami umožňuje [BottomFull](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/notespositions/) přidávat další stránky podle potřeby. Tento režim nepoužívejte s výše uvedeným voláním obrázku jediného snímku, které jej nepodporuje. Po změně velikosti zkontrolujte výstup na oříznuté poznámky a umístění existujících objektů notes‑master; změna rozměrů stránky samotná by neměla být považována za záruku, že veškerý obsah bude mít místo. Více o exportu poznámek najdete v článku [Convert PowerPoint to PDF with Notes](/slides/cs/androidjava/convert-powerpoint-to-pdf-with-notes/).

### **Export podkladů do PDF**

Použijte [HandoutLayoutingOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handoutlayoutingoptions/) pro více miniatur snímků na jedné stránce. Následující příklad nastaví stránku o rozměrech 900 × 600 bodů a použije [HandoutType.Handouts4Horizontal](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/handouttype/) , aby uspořádal až čtyři snímky na stránku. Horizontální předvolba řídí pořadí snímků; orientace stránky plyne z její šířky a výšky.

```java
import com.aspose.slides.*;
import com.aspose.slides.android.SizeF;

Presentation presentation = new Presentation("sample.pptx");
try {
    SizeF size = new SizeF(900, 600);
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

Změna velikosti stránky mění oblast dostupnou pro mřížku podkladů, aniž by změnila rozměry původních snímků. Pro obrázky podkladů použijte [Presentation.getImages](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/#getImages-com.aspose.slides.IRenderingOptions-) s rozvržením podkladů, místo metody pro obrázek jednotlivého snímku. V Aspose.Slides vykreslování podkladů na úrovni prezentace používá rozměry stránky poznámek, zatímco volání obrázku jednotlivého snímku nevytváří stránku podkladů. Viz [Handout Mode](/slides/cs/androidjava/convert-powerpoint-in-handout-mode/) pro možnosti rozvržení.

## **Velikost stránky v prohlížečích, exportu a tisku**

Udržujte odlišně velikost uložené prezentace, velikost exportované stránky a velikost tištěného papíru:

- **Prohlížeče prezentací:** Prohlížeč může zobrazovat nebo tisknout poznámky podle vlastních pravidel rozvržení. Pokud jiná aplikace soubor uloží, otevřete jej znovu a zkontrolujte rozměry; konverze formátu v té aplikaci je může normalizovat.
- **Exportní formáty:** Výše uvedené příklady PDF pro poznámky a podklady používají nastavené rozměry stránky. Rastrové obrázky používají celočíselné rozměry v pixelech a měřítko vykreslování, takže desetinné hodnoty v bodech mohou být v obrázku zaokrouhleny. Export běžných snímků nepoužívá velikost stránky poznámek.
- **Ovladače tiskáren:** Výběr papíru, automatické otáčení a nastavení přizpůsobení stránce mohou změnit fyzický výstup bez změny rozměrů uložených v prezentaci nebo PDF. Pro konkrétní velikost papíru sladíte nastavení tiskárny a zkontrolujete náhled tisku.

## **Často kladené dotazy**

**Mohu nastavit velikost poznámek pouze pro jeden snímek?**

Velikost stránky poznámek je nastavení na úrovni celé prezentace. Jednotlivé snímky mohou mít odlišný obsah poznámek, ale tato vlastnost neposkytuje samostatnou velikost stránky pro každý snímek.

**Proč změna orientace poznámek neovlivnila mé snímky?**

Stránky poznámek a běžné snímky mají nezávislé rozměry. Použijte nastavení velikosti běžných snímků, pokud chcete změnit velikost samotných snímků.

**Proč má výsledek po uložení nebo tisku jinou velikost?**

Nejprve otevřete znovu uloženou prezentaci a porovnejte rozměry poznámek. Pokud se změnily, zkontrolujte, zda ukládání nebo konverze souboru v jiné aplikaci změnila nastavení stránky. Pokud ne, prověřte rozvržení exportu, měřítko obrázku, nastavení prohlížeče a výběr papíru tiskárny.