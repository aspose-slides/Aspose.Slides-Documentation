---
title: Otevřít prezentace v Node.js přes .NET
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/nodejs-net/open-presentation/
keywords:
- otevřít prezentaci
- otevřít PowerPoint
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- prezentace z bufferu
- počet snímků
- převést prezentaci
- PowerPoint
- OpenDocument
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Otevřete PPTX, PPT a ODP prezentace v JavaScriptu pomocí Aspose.Slides pro Node.js přes .NET: načtěte z cesty k souboru nebo z Bufferu, přečtěte počet snímků a uložte v jiném formátu."
---
## **Přehled**

Aspose.Slides for Node.js via .NET otevírá prezentace PowerPoint a OpenDocument, například soubory PPTX, PPT a ODP, z cesty k souboru nebo z Node.js `Buffer`. Tento článek ukazuje oba způsoby, čte počet snímků a uloží otevřenou prezentaci v jiném formátu.

Příklady očekávají prezentaci s názvem `sample.pptx` v pracovním adresáři projektu, který jste nastavili v [Installation](/slides/cs/nodejs-net/installation/). Jakákoli prezentace PowerPoint bude fungovat. Uložte každý příklad jako soubor `.js` do adresáře projektu a spusťte jej z tohoto adresáře pomocí `node`.

{{% alert color="info" title="Note" %}}
Aspose.Slides for Node.js via .NET nemá vlastní referenční dokumentaci API. Zrcadlí API Aspose.Slides pro .NET s názvy v camelCase, takže odkazy na API v tomto článku vedou na odpovídající třídy a členy v [Aspose.Slides for .NET API reference](https://reference.aspose.com/slides/net/).
{{% /alert %}}

## **Otevření prezentace ze souboru**

Pro otevření prezentace předáte její cestu konstruktoru [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/presentation/). Aspose.Slides detekuje formát z obsahu souboru, nikoli z přípony, takže stejný kód otevře soubory PPTX, PPT i ODP. Relativní cesta je vyřešena vůči aktuálnímu pracovním adresáři, což je adresář projektu, pokud skript spustíte odtud.

```javascript
const { Presentation } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skript vypíše počet snímků v `sample.pptx`, například `Slide count: 9`. Vlastnost `count` kolekce [slides](https://reference.aspose.com/slides/net/aspose.slides/presentation/slides/) zahrnuje skryté snímky. Zavolejte `dispose` v bloku `finally`, jak je ukázáno, aby byly .NET zdroje za prezentací uvolněny i v případě selhání kódu.

## **Otevření prezentace z Bufferu**

Když prezentace pochází z databáze, HTTP nahrání nebo jiného zdroje, který poskytuje bajty místo cesty k souboru, předáte Node.js `Buffer` jako druhý argument konstruktoru a `null` jako první. Následující příklad načte `sample.pptx` do bufferu jako takový zdroj:

```javascript
const fs = require("fs");
const { Presentation } = require("aspose.slides.via.net");

const presentationData = fs.readFileSync("sample.pptx");

const presentation = new Presentation(null, presentationData);
try {
    console.log("Slide count: " + presentation.slides.count);
} finally {
    presentation.dispose();
}
```

Skript vypíše stejný počet snímků jako předchozí příklad. Druhý argument musí být `Buffer`. Pro jakýkoli jiný typ, například `Uint8Array`, konstruktor nehlásí chybu; místo toho vytvoří novou prezentaci s jedním prázdným snímkem. Předtím převádějte jiné binární typy pomocí `Buffer.from`.

## **Uložení prezentace v jiném formátu**

Pro převod prezentace do jiného formátu otevřete prezentaci a uložte ji s jinou hodnotou [SaveFormat](https://reference.aspose.com/slides/net/aspose.slides.export/saveformat/). Následující příklad vypíše formát, který Aspose.Slides detekoval, což vrací vlastnost [sourceFormat](https://reference.aspose.com/slides/net/aspose.slides/presentation/sourceformat/), a uloží prezentaci jako OpenDocument prezentaci:

```javascript
const { Presentation, SaveFormat } = require("aspose.slides.via.net");

const presentation = new Presentation("sample.pptx");
try {
    console.log("Source format: " + presentation.sourceFormat);
    presentation.save("sample.odp", SaveFormat.Odp);
} finally {
    presentation.dispose();
}
```

Skript vypíše `Source format: Pptx` a zapíše `sample.odp`, který obsahuje stejné snímky. `sourceFormat` vrací `Ppt`, `Pptx` nebo `Odp`. Pro uložení jako PDF nebo jako obrázky viz [Convert PowerPoint to PDF](/slides/cs/nodejs-net/convert-powerpoint-to-pdf/) a [Convert Slides to Images](/slides/cs/nodejs-net/convert-slide/).

## **Často kladené otázky**

**Jak otevřu prezentaci chráněnou heslem?**

Vytvořte objekt [LoadOptions](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/), nastavte jeho vlastnost [password](https://reference.aspose.com/slides/net/aspose.slides/loadoptions/password/) a předávejte objekt jako třetí argument konstruktoru: `new Presentation("protected.pptx", null, loadOptions)`. Bez správného hesla konstruktor vyhodí chybu.

**Proč konstruktor vyhodí `Error` s prázdnou zprávou?**

Když konstruktor `Presentation` selže v .NET, například protože soubor chybí, není prezentací nebo vyžaduje jiné heslo, JavaScript obdrží `Error`, jehož zpráva je prázdná. Před otevřením souboru zkontrolujte, že existuje relativně k pracovnímu adresáři, například pomocí `fs.existsSync`.

**Jaké formáty mohu otevřít?**

Formáty prezentací PowerPoint a OpenDocument, včetně PPT, PPTX, PPS, POT, POTX, PPTM, ODP, OTP a FODP.