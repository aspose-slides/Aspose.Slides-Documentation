---
title: Převod PowerPoint do PDF v Node.js přes .NET
linktitle: PowerPoint do PDF
type: docs
weight: 30
url: /cs/nodejs-net/convert-powerpoint-to-pdf/
keywords:
- PowerPoint do PDF
- převést PowerPoint do PDF
- PPTX do PDF
- PPT do PDF
- ODP do PDF
- uložit prezentaci jako PDF
- PDF/A
- PdfOptions
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Převést prezentace PPTX, PPT a ODP do PDF v JavaScriptu s Aspose.Slides pro Node.js přes .NET a vytvořit archivní soubory PDF/A pomocí PdfOptions."
---
## **Přehled**

Aspose.Slides pro Node.js přes .NET převádí prezentace PowerPoint a OpenDocument do PDF bez Microsoft PowerPoint. Každý viditelný snímek se stane jednou stránkou PDF ve stejné velikosti jako snímek a text zůstane výběrný a prohledávatelný. Tento článek ukazuje výchozí převod a převod do PDF/A pomocí [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/).

Příklady předpokládají prezentaci pojmenovanou `sample.pptx` ve složce projektu, kterou jste vytvořili v [Installation](/slides/cs/nodejs-net/installation/). Jakákoliv prezentace PowerPoint bude fungovat. Uložte každý příklad jako soubor `.js` ve složce projektu a spusťte jej z této složky pomocí `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides pro Node.js přes .NET nemá vlastní referenci API. Zrcadlí API Aspose.Slides pro .NET s názvy ve formátu camelCase, takže odkazy na API v tomto článku vedou k odpovídajícím třídám a členům v [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Převod prezentace do PDF**

Pro převod prezentace do PDF postupujte podle následujících kroků:

1. Otevřete prezentaci předáním její cesty konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Stejný kód funguje pro soubory PPTX, PPT i ODP.
1. Zavolejte metodu [save](https://reference.aspose.com/slides/net/aspose.slides/presentation/save/) s výstupní cestou a `SaveFormat.Pdf`.
1. V `finally` bloku zavolejte `dispose`, abyste uvolnili .NET prostředky, které prezentaci podporují.

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample.pdf", SaveFormat.Pdf);
    console.log("Saved sample.pdf");
} finally {
    presentation.dispose();
}
```

Skript zapíše `sample.pdf` do složky projektu. Převod používá výchozí nastavení: každý snímek, který není skrytý, se stane stránkou, v pořadí snímků. Bez licence se na každé stránce zobrazí vodotisk evaluace; viz [Licensing](/slides/cs/nodejs-net/licensing/).

## **Převod prezentace do PDF/A**

Pro řízení výstupu předávejte objekt [PdfOptions](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/) jako třetí argument funkce `save`. Následující příklad nastavuje vlastnost [compliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/compliance/) na `PdfCompliance.PdfA2b`, což vytváří soubor PDF/A-2b. PDF/A je standard ISO pro dlouhodobou archivaci: mimo jiné vyžaduje, aby každé písmo používané dokumentem bylo vloženo do souboru.

```javascript
const { Presentation, SaveFormat, PdfOptions, PdfCompliance } = require("aspose.slides.via.net");

const pdfOptions = new PdfOptions();
pdfOptions.compliance = PdfCompliance.PdfA2b;

const presentation = new Presentation("sample.pptx");
try {
    presentation.save("sample-pdfa.pdf", SaveFormat.Pdf, pdfOptions);
    console.log("Saved sample-pdfa.pdf");
} finally {
    presentation.dispose();
}
```

Skript zapíše `sample-pdfa.pdf` se stejnými stránkami jako výchozí převod. Pro ověření, že soubor splňuje standard, zkontrolujte jej pomocí validátoru PDF/A jako je [veraPDF](https://verapdf.org/). Další hodnoty [PdfCompliance](https://reference.aspose.com/slides/net/aspose.slides.export/pdfcompliance/) vybírají jiné standardy, například `PdfA1b`, `PdfA2a` nebo `PdfUa` pro přístupnost.

## **Často kladené otázky**

**Jak zahrnout skryté snímky do PDF?**

Skryté snímky jsou ve výchozím nastavení přeskočeny. Nastavte vlastnost [showHiddenSlides](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/showhiddenslides/) objektu `PdfOptions` na `true` a předávejte možnosti funkci `save`.

**Mohu PDF chránit heslem?**

Ano. Před zavoláním `save` nastavte vlastnost [password](https://reference.aspose.com/slides/net/aspose.slides.export/pdfoptions/password/) objektu `PdfOptions`. PDF prohlížeče pak požádají o toto heslo před otevřením souboru.

**Mohu převést jen některé snímky?**

Ano. Předávejte pole pozic snímků jako čtvrtý argument funkce `save`. Pozice začínají od 1 a třetí argument může být `null`, pokud nepotřebujete žádné možnosti: `presentation.save("selected.pdf", SaveFormat.Pdf, null, [1, 3])` vytvoří PDF s prvním a třetím snímkem.

**Proč vypadá text jinak při převodu na Linuxu?**

Aspose.Slides může používat jen písma, která jsou nainstalována na počítači provádějícím převod. Když prezentace používá písmo, které chybí, například Calibri na typickém Linux serveru, Aspose.Slides nahradí toto písmo nainstalovaným písmem, což může změnit vzhled textu a zalomení řádků. Nainstalujte písma, která vaše prezentace používají, abyste získali stejný výsledek jako na Windows.

**Mohu získat PDF jako Buffer místo souboru?**

Ano. `presentation.saveToBuffer(SaveFormat.Pdf)` vrací PDF jako Node.js `Buffer`, což je vhodné, když výsledek posíláte v HTTP odpovědi. Také přijímá `PdfOptions` jako svůj druhý argument.